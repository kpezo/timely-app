using System.Collections.Generic;
using System.Threading.Tasks;
using Timely_v1.Models;

namespace Timely_v1.Repository.Sessions
{
    public interface ISessionRepository
    {
        Task<Session> GetActiveSession();
        Task<Session> Create();
        Task<Session> UpdateActiveSession(string projectName);
        List<Session> GetAllSessions();
        //Task<List<Session>> GetSessionsSameName(string projectName);
    }
}