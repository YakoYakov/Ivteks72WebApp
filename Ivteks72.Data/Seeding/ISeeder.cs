namespace Ivteks72.Data.Seeding
{
    using System;
    using System.Threading.Tasks;
 
    public interface ISeeder
    {
        Task SeedAsync(Ivteks72DbContext dbContext, IServiceProvider serviceProvider);
    }
}
