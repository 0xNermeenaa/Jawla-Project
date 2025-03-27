using Infrastructure.DTO.UserDTO;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repository.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            this.configuration = configuration;

        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterNewUser(RegisterDTO user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }

            if (string.IsNullOrWhiteSpace(user.password))
            {
                return BadRequest("Password cannot be empty.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var check = await _userManager.FindByNameAsync(user.Username);
            if (check != null)
            {
                return BadRequest("Username is already taken.");
            }

            User appUser = new()
            {
                UserName = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                password = user.password
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, user.password);
            if (result.Succeeded)
            {
                return Ok(new { Message = "User registered successfully." });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LogIn(LoginDTO login)
        {
            if (login == null)
            {
                return BadRequest("Invalid login data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User? user = await _userManager.FindByNameAsync(login.Username);
            if (user == null)
            {
                return Unauthorized("Invalid username.");
            }

            bool passwordValid = await _userManager.CheckPasswordAsync(user, login.password);
            if (!passwordValid)
            {
                return Unauthorized("Invalid password.");
            }
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
            var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                expires: DateTime.Now.AddHours(1),
                signingCredentials: sc
                );
            var _token = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
            };
            return Ok(_token);
        }
        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword(ForgotPasswordRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest("User not found.");

            // إنشاء توكن إعادة تعيين كلمة المرور
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // إنشاء رابط إعادة التعيين
            var resetLink = $"http://localhost:5172/restpass?code={model.Email}&token={Uri.EscapeDataString(token)}";


            // إرسال الإيميل
            var emailService = new EmailService();
            await emailService.SendEmailAsync(model.Email, "Reset Password", $"Click <a href='{resetLink}'>here</a> to reset your password.");

            return Ok(new
            {
                token = token,
                email = user.Email,
                user = user.UserName
            });
        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ReservationDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest("User not found.");

            var resetResult = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (!resetResult.Succeeded)
                return BadRequest(resetResult.Errors);

            return Ok("Password has been reset successfully.");
        }
    }

}