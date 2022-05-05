using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timely_v1.DatabaseContext;
using Timely_v1.Models;

namespace Timely_v1.Repository.Sessions
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _dbContext;
        public SessionRepository(AppDbContext dbContext) 
            => _dbContext = dbContext;

        public Task<Session> GetActiveSession() 
            => _dbContext.Set<Session>().FirstOrDefaultAsync(x => x.EndDate == DateTime.MinValue);

        public List<Session> GetAllSessions() 
            => _dbContext.Set<Session>().ToListAsync().Result;

        public async Task<Session> Create()
        {
            var addingSession = new Session()
            {
                EndDate = DateTime.MinValue,
                StartDate = DateTime.Now
            };

            _dbContext.Set<Session>().Add(addingSession);
            await _dbContext.SaveChangesAsync();

            return addingSession;
        }

        public async Task<Session> UpdateActiveSession(string projectName)
        {
            var updatingSession = _dbContext.Set<Session>().FirstOrDefaultAsync(x => x.EndDate == DateTime.MinValue).Result;
            updatingSession.EndDate = DateTime.Now;
            updatingSession.ProjectName = projectName;
            await _dbContext.SaveChangesAsync();

            return updatingSession;
        }
    }
}