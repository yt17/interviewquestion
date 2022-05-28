using IQ.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.BusinessLayer.Abstracts
{
    public interface IUserService
    {
        public User GetUserInfo(int userID);
    }
}
