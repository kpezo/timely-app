using AutoMapper;
using System.Collections.Generic;
using Timely_v1.Repository.Sessions;
using Timely_v1.ViewModels;
using System.Linq;

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
        {
            var model = _sessionRepository.Create();
            var result = model.Result;
            var viewModel = _mapper.Map<SessionViewModel>(result);
            return viewModel;
        }

        public bool CheckIfSessionIsActive()
            => _sessionRepository.GetActiveSession().Result == null ? false : true;
        
        public SessionViewModel GetLastProject(string projectName)
        {
            var allSessions = _mapper.Map<List<SessionViewModel>>(_sessionRepository.GetAllSessions());
            return allSessions
                .Where(x => x.ProjectName == projectName)
                .OrderByDescending(x => x.EndDate)
                .FirstOrDefault();
        }
        //public SessionViewModel GetTotalGetTotalProjectTime(string projectName)
        //{
        //    var all
        //}
    }
}