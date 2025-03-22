using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelpIssueController : ControllerBase
    {
        private readonly IHelpIssueService _helpIssueService;

        public HelpIssueController(IHelpIssueService helpIssueService)
        {
            _helpIssueService = helpIssueService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HelpIssue>>> GetAllIssues()
        {
            var issues = await _helpIssueService.GetAllIssuesAsync();
            return Ok(issues);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HelpIssue>> GetIssueById(int id)
        {
            var issue = await _helpIssueService.GetIssueByIdAsync(id);
            if (issue == null) return NotFound();
            return Ok(issue);
        }

        [HttpPost]
        public async Task<ActionResult> CreateIssue(HelpIssue helpIssue)
        {
            await _helpIssueService.CreateIssueAsync(helpIssue);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIssue(int id)
        {
            await _helpIssueService.DeleteIssueAsync(id);
            return Ok();
        }
    }
}
