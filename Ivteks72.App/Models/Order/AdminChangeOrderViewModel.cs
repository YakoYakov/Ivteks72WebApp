namespace Ivteks72.App.Models.Order
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Ivteks72.AutoMapping;
    using Ivteks72.Domain;

    public class AdminChangeOrderViewModel : IMapFrom<Order> , IHaveCustomMappings
    {
        [Required]
        public string OrderStatus { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Order, AdminChangeOrderViewModel>()
                .ForMember(x => x.OrderStatus,
                           opt => opt.MapFrom(x => x.Status.ToString()));
        }
    }
}
