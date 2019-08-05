namespace Ivteks72.Service.Tests.Common
{
    using Ivteks72.Data;

    using Microsoft.EntityFrameworkCore;

    class InMemoryDatabase
    {
        public static Ivteks72DbContext GetDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Ivteks72DbContext>()
                .UseInMemoryDatabase("TestDatabase");

            var context = new Ivteks72DbContext(optionsBuilder.Options);

            return context;
        }
    }
}
