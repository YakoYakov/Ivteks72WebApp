namespace Ivteks72.App
{
    using System.Reflection;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Ivteks72.Data;
    using Ivteks72.Domain;
    using Ivteks72.Data.Seeding;
    using Ivteks72.Service;
    using Ivteks72.App.Services;
    using Ivteks72.App.Models;
    using Ivteks72.AutoMapping;
    using Ivteks72.PostmanRecoder;

    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Http.Extensions;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Mvc.Razor;
    using System.Globalization;
    using Microsoft.AspNetCore.Localization;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(opt => opt.ResourcesPath = "Resources");

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<Ivteks72DbContext>(options =>
                options.UseSqlServer(
                    Configuration["ConnectionStrings:DefaultConnection"])
                );

            services.AddIdentity<ApplicationUser, ApplicationRole>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<Ivteks72DbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });

            Account cloudinaryCredentials = new Account(
                this.Configuration["Cloudinary:CloudName"],
                this.Configuration["Cloudinary:ApiKey"],
                this.Configuration["Cloudinary:ApiSecret"]);

            Cloudinary cloudinaryUtility = new Cloudinary(cloudinaryCredentials);

            services.AddSingleton(cloudinaryUtility);

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;

                options.User.RequireUniqueEmail = true;
            });

            services.AddAuthorization();

            services.AddTransient<IClothingService, ClothingService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<ISendGridEmailSender, EmailSender>();

            services.Configure<MessageSenderOptions>(Configuration);
            CultureInfo[] supportedCultures = new[]
            {
                    new CultureInfo("en"),
                    new CultureInfo("bg")
            };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(supportedCultures[0]);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new IRequestCultureProvider[]
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
            });
            services.AddRazorPages().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<Ivteks72DbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new RoleSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
                new AdminSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.MapWhen(context => context.Request.GetEncodedUrl().Contains("recording=1"), builder =>
            {
                builder.UsePostmanRecoder(true);
            });

            app.MapWhen(context => context.Request.GetEncodedUrl().Contains("recording=0"), builder =>
            {
                builder.UsePostmanRecoder(false);
                builder.Run(async (context) =>
                {
                    object result;
                    if (context.Items.TryGetValue("PResult", out result))
                    {
                        string resultAsString = result.ToString();
                        context.Response.Clear();
                        context.Response.Headers.Add("Content-Length", resultAsString.Length.ToString());
                        context.Response.Headers.Add("Content-Disposition", "attachment;filename=PJson.json");
                        await context.Response.WriteAsync(resultAsString);
                    }
                });
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRequestLocalization();

            app.UseAuthentication();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
