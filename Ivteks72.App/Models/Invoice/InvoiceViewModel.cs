namespace Ivteks72.App.Models.Invoice
{
    using AutoMapper;
    using Ivteks72.AutoMapping;
    using Ivteks72.Common;
    using Ivteks72.Domain;
    using System;

    public class InvoiceViewModel : IMapFrom<Invoice>, IHaveCustomMappings
    {
        public string BIlledToUser { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        public DateTime DateOfIssue { get; set; }

        public string ClothingName { get; set; }

        public int Quantity { get; set; }

        public decimal InvoiceSubTotal { get; set; }

        public decimal VAT { get; set; }

        public decimal InvoiceTotalPrice { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            //BIlledToUser = invoice.BilledTo.FullName,
            //        CompanyName = invoice.BilledTo.Company.Name,
            //        CompanyAddress = invoice.BilledTo.Company.Address,
            //        DateOfIssue = invoice.DateOfIssue,
            //        ClothingName = invoice.Clothing.Name,
            //        Quantity = invoice.Clothing.Quantity,
            //        InvoiceSubTotal = invoice.Clothing.PricePerUnit * invoice.Clothing.Quantity,
            //        VAT = (invoice.Clothing.PricePerUnit * invoice.Clothing.Quantity) * GlobalConstants.VAT,
            //        InvoiceTotalPrice = (invoice.Clothing.PricePerUnit * invoice.Clothing.Quantity) +
            //                            ((invoice.Clothing.PricePerUnit * invoice.Clothing.Quantity) * GlobalConstants.VAT)

            configuration.CreateMap<Invoice, InvoiceViewModel>()
                .ForMember(x => x.BIlledToUser,
                           opt => opt.MapFrom(x => x.BilledTo.FullName))
                .ForMember(x => x.InvoiceSubTotal,
                           opt => opt.MapFrom(x => (x.Clothing.PricePerUnit * x.Clothing.Quantity)))
                .ForMember(x => x.VAT,
                           opt => opt.MapFrom(x => (x.Clothing.PricePerUnit * x.Clothing.Quantity) * GlobalConstants.VAT))
                .ForMember(x => x.InvoiceTotalPrice,
                           opt => opt.MapFrom(x => (x.Clothing.PricePerUnit * x.Clothing.Quantity) * GlobalConstants.VAT +
                                                   (x.Clothing.PricePerUnit * x.Clothing.Quantity)));

        }
    }
}
