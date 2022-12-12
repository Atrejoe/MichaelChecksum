using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

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
			CreateWebHostBuilder(args).Build().Run();
		}

		/// <summary>
		/// Created a webhost.
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
