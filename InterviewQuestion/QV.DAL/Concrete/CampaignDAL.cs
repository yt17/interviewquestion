using IQ.Entity.Models;
using Microsoft.EntityFrameworkCore;
using QV.CORE.EF;
using QV.DAL.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.DAL.Concrete
{
    public class CampaignDAL : EfRepository<interviewDBContext, Campaign>, ICampaignDAL
    {
        public List<Campaign> GetActiveCampaings()
        {
            using(var context=new interviewDBContext())
            {
                return context.Campaigns.Include("CampignRules").Include("CampignRules.AddRuleTypeNavigation").Where(w => w.CampaignStatus == 1 &&
                  (
                  (w.BeginDate <= DateTime.Now && w.EndDate! > DateTime.Now) ||
                  (w.BeginDate == null && w.EndDate == null))
                  //surekli olabilecek bir kampanya icin bu kosulu ekledim bunun yerine baslangic ve bitis tarhileride cok uzun tutulabilir 2000'den 2100 kadar gibi
                ).ToList();
            }
        }
    }
}
