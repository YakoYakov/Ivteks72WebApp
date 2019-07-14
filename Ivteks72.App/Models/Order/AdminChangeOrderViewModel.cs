namespace Ivteks72.App.Models.Order
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Ivteks72.AutoMapping;
    using Ivteks72.Domain;
    using Ivteks72.Domain.Enums;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AdminChangeOrderViewModel : IMapFrom<Order>, IHaveCustomMappings
    {

        public string Id { get; set; }

        public List<SelectListItem> Statuses { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "Accepted", Text = "Accepted" },
            new SelectListItem {Value = "Pending", Text = "Pending" },
            new SelectListItem {Value = "Rejected", Text = "Rejected" },
            new SelectListItem {Value = "Finished", Text = "Finished" }
        };

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
