namespace BlogWebsite.Controllers
{
	public class AuthUser(HttpContext httpContext)
	{
		public bool IsAuthenticated()
		{
			if (httpContext.Session.GetString(SessionVariables.SessionKeyUsername) == null)
			{
				return false;
			} else
			{
				return true;
			}
		}

		public bool IsNotAuthenticated()
		{
			if (httpContext.Session.GetString(SessionVariables.SessionKeyUsername) != null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		public bool IsOwnedByUser(int blogUserId)
		{
			if (blogUserId == httpContext.Session.GetInt32(SessionVariables.SessionKeyUserId))
			{
				return true;
			} else
			{
				return false;
			}
		}
	}
}
