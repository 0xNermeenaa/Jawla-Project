using Infrastructure.Models;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Service
{
    public class HelpIssueService : IHelpIssueService
    {
        private readonly IHelpIssueRepository _helpIssueRepository;

        public HelpIssueService(IHelpIssueRepository helpIssueRepository)
        {
            _helpIssueRepository = helpIssueRepository;
        }

        public async Task<List<HelpIssue>> GetAllIssuesAsync()
        {
            return await _helpIssueRepository.GetAllAsync();
        }

        public async Task<HelpIssue> GetIssueByIdAsync(int id)
        {
            return await _helpIssueRepository.GetByIdAsync(id);
        }

        public async Task CreateIssueAsync(HelpIssue helpIssue)
        {
            await _helpIssueRepository.AddAsync(helpIssue);
        }

        public async Task DeleteIssueAsync(int id)
        {
            var issue = await _helpIssueRepository.GetByIdAsync(id);
            if (issue != null)
            {
                await _helpIssueRepository.DeleteAsync(issue);
            }
        }
    }
}
