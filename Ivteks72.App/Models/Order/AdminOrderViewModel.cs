namespace Ivteks72.App.Models.Order
{
    using System;
    using System.Drawing;
    using AutoMapper;

    using Ivteks72.AutoMapping;
    using Ivteks72.Domain;

    public class AdminOrderViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string IssuerName { get; set; }

        public string CompanyName { get; set; }

        public string ClothingName { get; set; }

        public DateTime IssuedOn { get; set; }

        public int Quantity { get; set; }

        public decimal PricePerUnit { get; set; }

        public string OrderStatus { get; set; }

        //public Image Image { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Order, AdminOrderViewModel>()
                .ForMember(x => x.IssuerName,
                           opt => opt.MapFrom(x => x.Issuer.FullName))
                .ForMember(x => x.CompanyName,
                           opt => opt.MapFrom(x => x.Issuer.Company.Name))
                .ForMember(x => x.PricePerUnit,
                           opt => opt.MapFrom(x => x.Clothing.PricePerUnit))
                .ForMember(x => x.OrderStatus,
                           opt => opt.MapFrom(x => x.Status.ToString()));
        }
    }
}
