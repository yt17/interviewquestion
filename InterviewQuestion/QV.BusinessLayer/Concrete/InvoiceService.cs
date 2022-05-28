using IQ.BusinessLayer.Abstracts;
using IQ.DAL.Concrete;
using IQ.Entity.Models;
using IQ.ProjectClasses.DTO;
using QV.DAL.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.BusinessLayer.Concrete
{
    public class InvoiceService : IInvoiceService
    {
        private ICampaignDAL campaignDAL;
        private ICampignRuleDAL campignRuleDAL;
        private IUserService userService;
        public InvoiceService(ICampaignDAL campaignDAL, ICampignRuleDAL campignRuleDAL, IUserService userService)
        {
            this.campaignDAL = campaignDAL;
            this.campignRuleDAL = campignRuleDAL;
            this.userService = userService;
        }
        public List<CampaignResultDTO> SendInvoiceForControl(
            InvoiceCalculateDTO invoiceCalculateDTO)
        {
            var user = userService.GetUserInfo(invoiceCalculateDTO.UserID);
            List<ProductDTO> liste = new List<ProductDTO>();
            liste = invoiceCalculateDTO.Products;
           



            var activeCampaigns = campaignDAL.GetActiveCampaings();
            var rules = campignRuleDAL.GetRulesActive();
            decimal totalprice = liste.Sum(w => w.ProductPrice);
            List<Campaign> availableCampaign = new List<Campaign>();   
            foreach (var item in activeCampaigns)
            {                
                var available= controlCampaign(item.CampignRules.ToList(),user,liste);
                if (available)
                {
                    availableCampaign.Add(item);
                }
            }
            return CalculateDiscount(availableCampaign, totalprice);
        }

        private List<CampaignResultDTO> CalculateDiscount(List<Campaign> campaigns,decimal totalprice)
        {
            List<CampaignResultDTO> lc = new List<CampaignResultDTO>();
            if (campaigns.Count()==0)
            {
                CampaignResultDTO campaignResultDTO = new CampaignResultDTO()
                {
                    CampaignID = 0,
                    PriceWithCampaign = 0,
                    PriceWithoutCampaign = totalprice,
                    CampaignName="Tanımlı veya hakedilmiş bir kampanya bulunmamaktadır"                    
                };
                lc.Add(campaignResultDTO);
            }
           
            foreach (var item in campaigns)
            {
                decimal discount = 0;
                switch ((DiscountType)item.DiscountTypeId)
                {
                    case DiscountType.Net:
                        discount = PriceCalculaterforNetDiscount(totalprice, item.DiscountValue.Value);
                        break;
                    case DiscountType.Yuzde:
                        discount = PriceCalculaterforPercantage(totalprice, item.DiscountValue.Value);
                        break;
                    case DiscountType.YuzdeHerX:
                        discount = PriceCalculaterforEveryPrice(totalprice, item.DiscountValue.Value,Convert.ToDecimal(item.CampignRules.First(w=>w.AddRuleType==7).Splitter));
                        break;
                    default:
                        break;
                }
                CampaignResultDTO campaignResultDTO = new CampaignResultDTO()
                {
                    CampaignID = item.CampaignId,
                    PriceWithCampaign = discount,
                    PriceWithoutCampaign = discount,
                    CampaignName=item.CampaignName
                };
                lc.Add(campaignResultDTO);
            }
            return lc;

        }



        private decimal PriceCalculaterforNetDiscount(decimal totalPrice,decimal discountPrice)
        {
            return totalPrice - discountPrice;            
        }
        private decimal PriceCalculaterforPercantage(decimal totalPrice, decimal discountPrice)
        {
            return totalPrice- ( totalPrice * discountPrice);
        }
        private decimal PriceCalculaterforEveryPrice(decimal totalPrice, decimal discountPrice,decimal Split)
        {
            if (totalPrice>Split)
            {
                var parts = (int)totalPrice % (int)Split;
                return totalPrice - (discountPrice * parts);
            }
            return 0;
           
        }
        private bool controlCampaign(List<CampignRule> campignRule, User userDTO, List<ProductDTO> liste)
        {
            decimal TotalPrice = liste.Sum(w => w.ProductPrice);
            var res = false;
            foreach (var item in campignRule)
            {
                
                if (item.AddRuleTypeNavigation.ValType==1)//tarih karsilastirmalari 1
                {
                    res=CompareToDate((OperationType)item.Comparing, DateTime.Parse(item.Value),
                        item.AddRuleType==1 ? userDTO.CreatedDate:userDTO.Birthdate);
                }
                else if (item.AddRuleTypeNavigation.ValType == 2)//integer karsilastirmalari 2
                {
                    // karsilastirma tipi daha dinamik yapilabilir -kullanici cinsiyeti ,ozel vatandaslik durumlari engelli olmasi vs tarzi, 
                    res = CompareToInt((OperationType)item.Comparing, int.Parse(item.Value), 
                        item.AddRuleType==3?userDTO.RoleId: (int)(DateTime.Now.Date-userDTO.CreatedDate).TotalDays);
                }
                else
                {
                    res = CompareToDecimal((OperationType)item.Comparing, TotalPrice,Convert.ToDecimal(item.Splitter));
                }

                if (res==false)
                {
                    return false;
                }
                //item.AddRuleType.// value burada eger inttegere bir kontrol var integer base date varsa datebase olarak gidecek
               //item.AddRuleType
            }
            return res;
        }
        private bool CompareToDate(OperationType comp,DateTime target, DateTime userval)
        {            
            var res = false;
            switch (comp)
            {
                case OperationType.EqualTo:
                    res =(target == userval);
                    break;
                case OperationType.GreaterThan:
                    res = (target > userval);
                    break;
                case OperationType.GreaterThanOrEqualTo:
                    res = (target >= userval);
                    break;
                case OperationType.LessThan:
                    res = (target < userval);
                    break;
                case OperationType.LessThanOrEqualTo:
                    res = (target <= userval);
                    break;
                default:
                    break;
            }
            return res;
        }
        private bool CompareToInt(OperationType comp, int target, int userval)
        {
            var res = false;
            switch (comp)
            {
                case OperationType.EqualTo:
                    res = (userval == target);
                    break;
                case OperationType.GreaterThan:
                    res = (userval > target);
                    break;
                case OperationType.GreaterThanOrEqualTo:
                    res = (userval >= target);
                    break;
                case OperationType.LessThan:
                    res = (userval < target);
                    break;
                case OperationType.LessThanOrEqualTo:
                    res = (userval <= target);
                    break;
                default:
                    break;
            }
            return res;
        }
        private bool CompareToDecimal(OperationType comp, decimal target, decimal userval)
        {
            var res = false;
            switch (comp)
            {
                case OperationType.EqualTo:
                    res = (target == userval);
                    break;
                case OperationType.GreaterThan:
                    res = (target > userval);
                    break;
                case OperationType.GreaterThanOrEqualTo:
                    res = (target >= userval);
                    break;
                case OperationType.LessThan:
                    res = (target < userval);
                    break;
                case OperationType.LessThanOrEqualTo:
                    res = (target <= userval);
                    break;
                default:
                    break;
            }
            return res;
        }
        public enum OperationType
        {           
            EqualTo=1,            
            GreaterThan=2,
            GreaterThanOrEqualTo=3,
            LessThan=4,
            LessThanOrEqualTo=5
        }
        public enum DiscountType
        {
            Net=1,
            Yuzde=2,
            YuzdeHerX=3
        }




    }
}
