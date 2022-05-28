using IQ.Entity.Models;
using QV.CORE.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QV.DAL.Abstracts
{
    public interface ICampignRuleDAL : IRepository<CampignRule>
    {
        public List<CampignRule> GetRulesActive();
    }
}
