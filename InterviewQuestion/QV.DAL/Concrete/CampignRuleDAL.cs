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
    public class CampignRuleDAL : EfRepository<interviewDBContext, CampignRule>, ICampignRuleDAL
    {
        public List<CampignRule> GetRulesActive()
        {
            using (var context = new interviewDBContext())
            {
                return context.CampignRules.Where(w => w.Campaign.CampaignStatus==1 ).ToList();
            }
        }
    }
}
