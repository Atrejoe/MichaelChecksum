using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
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
        public static string Intro(HttpRequest? request, bool light = false) { return $@"
<div style=""float:left; padding:0px 10px 10px 0px;""><img src=""/favicon?light={light}"" style=""width:100px;""/></div>
This API allows calculating hashes for publicly available content... SHA1mone!
<br/>
This allows you to show a badge with checksum for online content.
<div style=""clear:both""/>
<h5>Example</h5>
When calculating the hash for the Google favicon (<img src=""https://www.google.com/favicon.ico"" style=""vertical-align: middle;""/>), which is linked at: https://www.google.com/favicon.ico
<p>
<code title=""this example has been made simple, be sure to URL-encode the `url` argument"">{WebUtility.HtmlEncode($@"<img src=""{(string.IsNullOrWhiteSpace(request?.Host.Host)?"":"http://")}{request?.Host.Host}/SHA1mone/?url=https://www.google.com/favicon.ico""/>")}</code>
</p>
Unless Google changes the favicon, the expected response is:<br/>
<code style=""margin-left:20px; font-family:Consolas;font-size:15px;"">49263695F6B0CDD72F45CF1B775E660FDC36C606</code>
<p>Badge calculated by the API:</p>
<a href=""/SHA1mone/?url=https%3A%2F%2Fwww.google.com%2Ffavicon.ico"">
<img src=""/SHA1mone/?url=https%3A%2F%2Fwww.google.com%2Ffavicon.ico&light={light}""/>
</a>
<p>
The API will be size-restricted, for an unlimited-cross-platform experience install the command-line tool:
</p>
<h5>Alternative: commandline</h5>
Install Michael checksum on your machine:
<pre><code>dotnet tool install -g michaelchecksum.console</code></pre>
To calculate a checkum of a local file:
<pre><code>michaelchecksum mydownloadedfile.zip</code></pre>
To calculate a checkum of a remote:
<pre><code>michaelchecksum http://download.com/mydownloadedfile.zip</code></pre>
"; }

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

            //services.AddRazorPages();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddMvcOptions(options => options.EnableEndpointRouting = false);
            services.AddControllersWithViews();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"Michael Checksum!",
                    Version = "v1",
                    Description = Intro(null, false),
                    Contact = new OpenApiContact
                    {
                        Name = "Atrejoe",
                        //Email = "devlog@cs.nl",
                        Url = new Uri("https://github.com/Atrejoe"),
                    }
                });

                //c.DescribeAllEnumsAsStrings();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                //... and tell Swagger to use those XML comments.
                c.IncludeXmlComments(xmlPath, true);
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("192.168.1.110"));
                options.KnownProxies.Add(IPAddress.Parse("192.168.1.101"));
            });
        }

        /// <summary>
        /// Conventions-based, dependency-injectable configuration method.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <remarks>This method gets called by the runtime. Use this method to configure the HTTP request pipeline.</remarks>
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (app is null)
                throw new ArgumentNullException(nameof(app));

            if (env is null)
                throw new ArgumentNullException(nameof(env));

            app.UseStaticFiles();
            app.UseRouting();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });


            if (string.Equals(env.EnvironmentName, "Development", StringComparison.InvariantCultureIgnoreCase))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            app.UseCookiePolicy();
            
            app.UseMvc((routes) =>
            {
                routes.MapRoute(
                name: "default",
                template: "{action=Index}");
            });


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Michael Checksum V1");
                c.EnableDeepLinking();
            });
        }
    }
}
