namespace Ivteks72.App.Models.Invoice
{
    using System;

    using AutoMapper;

    using Ivteks72.AutoMapping;
    using Ivteks72.Common;
  
    public class AdminAllInvoicesViewModel : IMapFrom<Ivteks72.Domain.Invoice>, IHaveCustomMappings
    {
        public string BIlledToUser { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        public DateTime DateOfIssue { get; set; }

        public string ClothingName { get; set; }

        public int Quantity { get; set; }

        public decimal InvoiceTotalPrice { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Ivteks72.Domain.Invoice, AdminAllInvoicesViewModel>()
                .ForMember(x => x.BIlledToUser,
                           opt => opt.MapFrom(x => x.BilledTo.FullName))
                .ForMember(x => x.CompanyName,
                           opt => opt.MapFrom(x => x.BilledTo.Company.Name))
                .ForMember(x => x.CompanyAddress,
                           opt => opt.MapFrom(x => x.BilledTo.Company.Address))
                .ForMember(x => x.Quantity,
                           opt => opt.MapFrom(x => x.Clothing.Quantity))
                .ForMember(x => x.InvoiceTotalPrice,
                           opt => opt.MapFrom(x => (x.Clothing.PricePerUnit * x.Clothing.Quantity) * GlobalConstants.VAT +
                                                   (x.Clothing.PricePerUnit * x.Clothing.Quantity)));
        }
    }
}
