using JobSpotAplication.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using JobSpotAplication.Services;

namespace JobSpotAplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddRazorPages();
            services.AddAuthentication()
                .AddFacebook(facebookOptions => {
                    facebookOptions.AppId = "771874213445629";
                    facebookOptions.AppSecret = "4e3372a45848581f4ec5347ff126cd3c";
                    facebookOptions.AccessDeniedPath = "/AccessDeniedPathInfo";
                })
                .AddGoogle(googleOptions => {
                    googleOptions.ClientId = "867196046966-08qftlfoqjt7e8katudbrfurhj58aifn.apps.googleusercontent.com";
                    googleOptions.ClientSecret = "MxHE8oBHg1k15Fxnxh2Ithfl";
                })
                .AddTwitter(twitterOptions => {
                    twitterOptions.ConsumerKey = "JOxmWjKXK5SkbWDTSxRdH50Ga";
                    twitterOptions.ConsumerSecret = "bBDfRy8itq3hsm33hhHxDdIFpOYF4TgtiryLQ91QrstODvfDSa";
                    twitterOptions.RetrieveUserDetails = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
