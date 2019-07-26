namespace Ivteks72.App.Models.Invoice
{
    using System;

    using AutoMapper;

    using Ivteks72.AutoMapping;
    using Ivteks72.Common;
    using Ivteks72.Domain;

    public class InvoiceDetailsViewModel : IMapFrom<Invoice>, IHaveCustomMappings
    {
        public int Number { get; set; }

        public string BIlledToUser { get; set; }

        public string Email { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        public DateTime DateOfIssue { get; set; }

        public string ClothingName { get; set; }

        public string Fabric { get; set; }

        public int Quantity { get; set; }

        public decimal PricePerUnit { get; set; }

        public decimal InvoiceSubTotal { get; set; }

        public decimal VAT { get; set; }

        public decimal InvoiceTotalPrice { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {

            configuration.CreateMap<Invoice, InvoiceDetailsViewModel>()
                .ForMember(x => x.BIlledToUser,
                           opt => opt.MapFrom(x => x.BilledTo.FullName))
                .ForMember(x => x.CompanyName,
                           opt => opt.MapFrom(x => x.BilledTo.Company.Name))
                .ForMember(x => x.CompanyAddress,
                           opt => opt.MapFrom(x => x.BilledTo.Company.Address))
                .ForMember(x => x.Quantity,
                           opt => opt.MapFrom(x => x.Clothing.Quantity))
                .ForMember(x => x.InvoiceSubTotal,
                           opt => opt.MapFrom(x => (x.Clothing.PricePerUnit * x.Clothing.Quantity)))
                .ForMember(x => x.VAT,
                           opt => opt.MapFrom(x => (x.Clothing.PricePerUnit * x.Clothing.Quantity) * GlobalConstants.VAT))
                .ForMember(x => x.InvoiceTotalPrice,
                           opt => opt.MapFrom(x => (x.Clothing.PricePerUnit * x.Clothing.Quantity) * GlobalConstants.VAT +
                                                   (x.Clothing.PricePerUnit * x.Clothing.Quantity)))
                .ForMember(x => x.Email,
                           opt => opt.MapFrom(x => x.BilledTo.Email))
                .ForMember(x => x.Fabric,
                           opt => opt.MapFrom(x => x.Clothing.Fabric))
                .ForMember(x => x.PricePerUnit,
                           opt => opt.MapFrom(x => x.Clothing.PricePerUnit));
        }
    }
}
