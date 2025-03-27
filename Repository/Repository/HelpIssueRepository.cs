using Infrastructure.Models;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class HelpIssueRepository : IHelpIssueRepository
    {
        private readonly List<HelpIssue> _helpIssues = new();

        public async Task<List<HelpIssue>> GetAllAsync()
        {
            return await Task.FromResult(_helpIssues);
        }

        public async Task<HelpIssue> GetByIdAsync(int id)
        {
            return await Task.FromResult(_helpIssues.FirstOrDefault(h => h.Id == id));
        }

        public async Task AddAsync(HelpIssue helpIssue)
        {
            _helpIssues.Add(helpIssue);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(HelpIssue helpIssue)
        {
            _helpIssues.Remove(helpIssue);
            await Task.CompletedTask;
        }
    }
}
