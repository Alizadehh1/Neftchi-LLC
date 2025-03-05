using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NeftchiLLC.Domain.Contexts
{
	public static class NeftchiContextSeed
	{
		public static IApplicationBuilder Seed(this IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				var db = scope.ServiceProvider.GetRequiredService<DbContext>();
				db.Database.Migrate();
			}
			return app;
		}
	}
}
