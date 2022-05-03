using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Software_Requirement_Specification.Data;
using Microsoft.AspNetCore.Http;

namespace Software_Requirement_Specification
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
            services.AddControllersWithViews();
            services.AddSession();
            services.AddDbContext<Software_Requirement_SpecificationContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Software_Requirement_SpecificationContext")));
            services.ConfigureApplicationCookie(options => { options.LoginPath = "/Api/log"; });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
            app.UseSession();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapGet("/testMailUtils", async (context) =>
                 {
                     var mesage = await MailUtils.MailUtils.SendMail("0306191061@caothang.edu.vn",
                                                                     "ptranninh@gmail.com",
                                                                     "text",
                                                                     "Xin chào tôi là ai và ai là tôi");
                     await context.Response.WriteAsync(mesage);
                 });
                endpoints.MapGet("/testGmailUtils", async (context) =>
                {
                    var mesage = await MailUtils.MailUtils.SendGmail("ptranninh@gmail.com",
                                                                    "ptranninh@gmail.com",
                                                                    "text",
                                                                    "Xin chào tôi là ai và ai là tôi",
                                                                    "ptranninh@gmail.com",
                                                                    "tranninhphuc@1061");
                    await context.Response.WriteAsync(mesage);
                });
            });
        }
    }
}
