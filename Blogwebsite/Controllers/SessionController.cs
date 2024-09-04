namespace BlogWebsite.Controllers
{
    public class SessionController(HttpContext httpContext)
    {
        public IEnumerable<string> GetSessionInfo()
        {
            List<string>? sessionInfo = new List<string>();

            if(httpContext.Session.GetString(SessionVariables.SessionKeyUsername) == null)
            {
                httpContext.Session.SetString(SessionVariables.SessionKeyUsername, "");
                httpContext.Session.SetString(SessionVariables.SessionKeyUserId, "");
                httpContext.Session.SetString(SessionVariables.SessionKeySessionId, "");
            }

            sessionInfo.Add(httpContext.Session.GetString(SessionVariables.SessionKeyUsername)?? "");
            sessionInfo.Add(httpContext.Session.GetString(SessionVariables.SessionKeyUserId)?? "");
            sessionInfo.Add(httpContext.Session.GetString(SessionVariables.SessionKeySessionId)?? "");

            return sessionInfo;
        }
    }
}
