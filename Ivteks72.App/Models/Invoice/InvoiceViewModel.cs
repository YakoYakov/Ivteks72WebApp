namespace Ivteks72.App.Models.Invoice
{
    using AutoMapper;

    using Ivteks72.AutoMapping;
    using Ivteks72.Domain;

    public class InvoiceViewModel : IMapFrom<Invoice>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string BIlledToUser { get; set; }

        public string CompanyName { get; set; }

        public string ClothingName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {

            configuration.CreateMap<Invoice, InvoiceViewModel>()
                .ForMember(x => x.BIlledToUser,
                           opt => opt.MapFrom(x => x.BilledTo.FullName))
                .ForMember(x => x.CompanyName,
                           opt => opt.MapFrom(x => x.BilledTo.Company.Name));
        }
    }
}
