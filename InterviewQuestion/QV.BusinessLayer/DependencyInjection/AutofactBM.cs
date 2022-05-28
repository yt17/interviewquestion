using Autofac;
using IQ.BusinessLayer.Abstracts;
using IQ.BusinessLayer.Concrete;
using IQ.DAL.Concrete;
using QV.DAL.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.BusinessLayer.DependencyInjection
{
    public class AutofactBM:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<ProductService>().As<IProductService>();
            //builder.RegisterType<ProductDAL>().As<IProductDAL>();
            builder.RegisterType<InvoiceService>().As<IInvoiceService>();
            builder.RegisterType<UserDAL>().As<IUserDAL>();
            builder.RegisterType<CampaignDAL>().As<ICampaignDAL>();
            builder.RegisterType<CampignRuleDAL>().As<ICampignRuleDAL>();
            builder.RegisterType<UserService>().As<IUserService>();

            //builder.RegisterType<InvoiceDAL>().As<IInvoiceDAL>();
            //builder.RegisterType<InvoiceService>().As<IAddRuleTypeDAL>();        
            //builder.RegisterType<InvoiceService>().As<IComparingDAL>();
            //builder.RegisterType<InvoiceService>().As<IDiscountTypeDAL>();            
            //builder.RegisterType<InvoiceService>().As<IOperationClaims>();
            //builder.RegisterType<InvoiceService>().As<IProductDAL>();           
            //builder.RegisterType<InvoiceService>().As<IUserOperationClaims>();
        }
    }
}
