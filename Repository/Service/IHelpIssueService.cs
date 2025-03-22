using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Service
{
    public interface IHelpIssueService
    {
        Task<List<HelpIssue>> GetAllIssuesAsync();
        Task<HelpIssue> GetIssueByIdAsync(int id);
        Task CreateIssueAsync(HelpIssue helpIssue);
        Task DeleteIssueAsync(int id);
    }
}
