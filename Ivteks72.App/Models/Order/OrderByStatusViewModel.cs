namespace Ivteks72.App.Models.Order
{
    using System;
    using AutoMapper;
    using Ivteks72.AutoMapping;
    using Ivteks72.Domain;

    public class OrderByStatusViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public string ClothingName { get; set; }

        public int Quantity { get; set; }

        public DateTime IssuedOn { get; set; }

        public string IssuerName { get; set; }

        public string CompanyName { get; set; }

        public decimal TotalOrderPriceWithoutVAT { get; set; }

        public string OrderStatus { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            //TotalOrderPrice = orderFromDb.Quantity * orderFromDb.Clothing.PricePerUnit,
            //        Clothing = orderFromDb.Clothing.Name,
            //        Quantity = orderFromDb.Quantity,
            //        Company = orderFromDb.Issuer.Company.Name,
            //        IssuedOn = orderFromDb.IssuedOn,
            //        Status = OrderStatus.Accepted.ToString(),
            //        IssuerName = orderFromDb.Issuer.FullName

            configuration.CreateMap<Order, OrderByStatusViewModel>()
                .ForMember(x => x.TotalOrderPriceWithoutVAT,
                           opt => opt.MapFrom(x => (x.Quantity * x.Clothing.PricePerUnit)))
                .ForMember(x => x.IssuerName,
                           opt => opt.MapFrom(x => x.Issuer.FullName))
                .ForMember(x => x.OrderStatus,
                           opt => opt.MapFrom(x => x.Status.ToString()))
                .ForMember(x => x.CompanyName,
                           opt => opt.MapFrom(x => x.Issuer.Company.Name));
        }
    }
}
