using System.Collections.Generic;
using Timely_v1.ViewModels;

namespace Timely_v1.Services.Sessions
{
    public interface ISessionService
    {
        bool CheckIfSessionIsActive();
        SessionViewModel StartSession();
        SessionViewModel EndSession(string projectName);
        List<SessionViewModel> GetAllSessions();
    }
}