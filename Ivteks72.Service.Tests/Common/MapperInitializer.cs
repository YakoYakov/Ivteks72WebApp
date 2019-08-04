namespace Ivteks72.Service.Tests.Common
{
    using System.Reflection;

    using Ivteks72.App.Models.Invoice;
    using Ivteks72.AutoMapping;
    using Ivteks72.Domain;

    public class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(typeof(InvoiceViewModel).GetTypeInfo().Assembly,
                    typeof(Invoice).GetTypeInfo().Assembly);
        }
    }
}
