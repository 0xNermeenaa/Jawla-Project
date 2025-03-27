using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IHelpIssueRepository
    {
        Task<List<HelpIssue>> GetAllAsync();
        Task<HelpIssue> GetByIdAsync(int id);
        Task AddAsync(HelpIssue helpIssue);
        Task DeleteAsync(HelpIssue helpIssue);
    }
}
