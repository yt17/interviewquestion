using IQ.Entity.Models;
using QV.CORE.EF;
using QV.DAL.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.DAL.Concrete
{
    public class UserDAL : EfRepository<interviewDBContext, User>, IUserDAL
    {
    }
}
