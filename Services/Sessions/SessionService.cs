using AutoMapper;
using System.Collections.Generic;
using Timely_v1.Repository.Sessions;
using Timely_v1.ViewModels;

namespace Timely_v1.Services.Sessions
{
    public class SessionService : ISessionService
    {
        private ISessionRepository _sessionRepository;
        private IMapper _mapper;

        public SessionService(ISessionRepository sessionRepository, IMapper mapper)
        {
            _sessionRepository = sessionRepository;
            _mapper = mapper;
        }

        public SessionViewModel EndSession(string projectName)
            => _mapper.Map<SessionViewModel>(_sessionRepository.UpdateActiveSession(projectName).Result);

        public List<SessionViewModel> GetAllSessions()
            => _mapper.Map<List<SessionViewModel>>(_sessionRepository.GetAllSessions());
        
        public SessionViewModel StartSession()
            => _mapper.Map<SessionViewModel>(_sessionRepository.Create().Result);

        public bool CheckIfSessionIsActive()
        {
            var currentSesion = _sessionRepository.GetActiveSession().Result;

            if(currentSesion == null) return false;

            return true;
        }
    }
}