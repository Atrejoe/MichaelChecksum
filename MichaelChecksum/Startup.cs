using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace MichaelChecksum
{

    /// <summary>
    /// Startup class, allows configuration of application startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Conventions-based constructor.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// The intro text
        /// </summary>
        public static readonly string Intro = $@"
<div style=""float:left""><img src=""/favicon""/></div>
This API allows calculating hashes for publicly available content... SHA1mone!
<br/>
This allows you to shows a badge with checksum, like when calculating the hash for the Google favicon (<img src=""https://www.google.com/favicon.ico"" style=""vertical-align: middle;""/>):
<p>
<code>{WebUtility.HtmlEncode(@"<img src=""https://michaelchecksum.(azurewebsites.)net/SHA1mone/?url=https%3A%2F%2Fwww.google.com%2Ffavicon.ico""/>")}</code>
</p>
Unless Google changes the favicon, the expected response is:<br/>
<code style=""margin-left:20px; font-family:Consolas;font-size:15px;"">49263695F6B0CDD72F45CF1B775E660FDC36C606</code>
<p>Badge calculated by the API:</p>
<a href=""/SHA1mone/?url=https%3A%2F%2Fwww.google.com%2Ffavicon.ico"">
<img src=""/SHA1mone/?url=https%3A%2F%2Fwww.google.com%2Ffavicon.ico""/>
</a>
<p>
The API will be size-restricted, for an unlimited-cross-platform experience a console application may be made available.
</p>
";

        /// <summary>
        /// Conventions-based, dependency-injectable configuration method.
        /// </summary>
        /// <param name="services"></param>
        /// <remarks>This method gets called by the runtime. Use this method to add services to the container.</remarks>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = $"Michael Checksum!",
                    Version = "v1",
                    Description = Intro
                ,
                    Contact = new Contact
                    {
                        Name = "Atrejoe",
                        //Email = "devlog@cs.nl",
                        Url = "https://github.com/Atrejoe"
                    }
                });

                c.DescribeAllEnumsAsStrings();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                //... and tell Swagger to use those XML comments.
                c.IncludeXmlComments(xmlPath, true);
            });
        }

        /// <summary>
        /// Conventions-based, dependency-injectable configuration method.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <remarks>This method gets called by the runtime. Use this method to configure the HTTP request pipeline.</remarks>
        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Michael Checksum V1");
            });
        }
    }
}
