using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
