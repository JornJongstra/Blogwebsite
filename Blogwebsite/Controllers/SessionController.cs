using Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        public IEnumerable<string> GetSessionInfo()
        {
            List<string> sessionInfo = new List<string>();

            if(string.IsNullOrWhiteSpace(HttpContext.Session.GetString(SessionVariables.SessionKeyUsername)))
            {
                HttpContext.Session.SetString(SessionVariables.SessionKeyUsername, "test");
                HttpContext.Session.SetString(SessionVariables.SessionKeyUserId, "0");
                HttpContext.Session.SetString(SessionVariables.SessionKeySessionId, "test");
            }

            var username = HttpContext.Session.GetString(SessionVariables.SessionKeyUsername);
            var userId = HttpContext.Session.GetString(SessionVariables.SessionKeyUserId);
            var sessionId = HttpContext.Session.GetString(SessionVariables.SessionKeySessionId);

            sessionInfo.Add(username);
            sessionInfo.Add(userId);
            sessionInfo.Add(sessionId);

            return sessionInfo;
        }

        public List<string> GetSession()
        {
            List<string> sessionInfo = new List<string>();

            sessionInfo.Add(HttpContext.Session.GetString(SessionVariables.SessionKeyUsername));
            sessionInfo.Add(HttpContext.Session.GetString(SessionVariables.SessionKeyUserId));
            sessionInfo.Add(HttpContext.Session.GetString(SessionVariables.SessionKeySessionId));

            return sessionInfo;
        }
    }
}
