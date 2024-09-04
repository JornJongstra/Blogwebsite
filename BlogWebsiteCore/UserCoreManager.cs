using Classes;

namespace BlogWebsiteCore
{
    public class UserCoreManager
    {
        public User GetUser(int id)
        {
            return ServiceHandler.Service.GetUser(id);
        }
    }
}
