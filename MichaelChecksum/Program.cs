using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MichaelChecksum
{
	/// <summary>
	/// Starting point of the application
	/// </summary>
	public static class Program
	{
		/// <summary>
		/// Entry methods of the application.
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		/// <summary>
		/// Creates an IHostBuilder for the application.
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
