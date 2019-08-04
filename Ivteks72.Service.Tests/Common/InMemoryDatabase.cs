using Ivteks72.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ivteks72.Service.Tests.Common
{
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
