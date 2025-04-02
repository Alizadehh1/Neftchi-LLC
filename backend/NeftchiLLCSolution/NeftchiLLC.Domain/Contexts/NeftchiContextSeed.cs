using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NeftchiLLC.Domain.Models.Membership;

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

		public static async Task SeedAdminAsync(IServiceProvider services)
		{
			var userManager = services.GetRequiredService<UserManager<NeftchiUser>>();
			var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

			string adminEmail = "admin@neftchi.com";
			string adminPassword = "Access4Admin!";

			if (!await roleManager.RoleExistsAsync("Admin"))
				await roleManager.CreateAsync(new IdentityRole("Admin"));

			var existingAdmin = await userManager.FindByEmailAsync(adminEmail);
			if (existingAdmin == null)
			{
				var admin = new NeftchiUser
				{
					UserName = adminEmail,
					Email = adminEmail
				};

				var result = await userManager.CreateAsync(admin, adminPassword);
				if (result.Succeeded)
					await userManager.AddToRoleAsync(admin, "Admin");
			}
		}
	}
}
