using IQ.BusinessLayer.Abstracts;
using IQ.Entity.Models;
using QV.DAL.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.BusinessLayer.Concrete
{
    public class UserService : IUserService
    {
        private IUserDAL userDAL;
        public UserService(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }
        public User GetUserInfo(int userID)
        {
            return userDAL.Get(w => w.UserId == userID);
        }
    }
}
