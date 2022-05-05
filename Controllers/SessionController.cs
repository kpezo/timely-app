using Microsoft.AspNetCore.Mvc;
using Timely_v1.Services.Sessions;

namespace Timely_v1.Controllers
{
    public class SessionController : Controller
    {
        private ISessionService _sessionService;

        public SessionController(ISessionService sessionService) 
            => _sessionService = sessionService;

        public bool CheckIfSessionIsActive() 
            => _sessionService.CheckIfSessionIsActive();

        public IActionResult StartSession()
            => Ok(_sessionService.StartSession());
        public IActionResult EndSession(string projectName)
            => Ok(_sessionService.EndSession(projectName));

        public IActionResult GetAllSessions()
            => Ok(_sessionService.GetAllSessions());
    }
}