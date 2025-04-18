using Intelect.Application.Core.Services;
using Intelect.Domain.Core.Configurations;
using Intelect.Infrastructure.Core.Concepts.CorrelationConcept;
using Intelect.Infrastructure.Core.Concepts.TransactionalConcept;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Api.Pipeline;
using NeftchiLLC.Application;
using NeftchiLLC.Domain.Contexts;
using NeftchiLLC.Domain.Models.Membership;

var builder = WebApplication.CreateBuilder(args);
if (builder.Environment.IsProduction())
{
	Console.WriteLine(">>> Starting backend for Production...");
}
builder.Services.AddControllers();

builder.Services.AddCorrelation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseServiceProviderFactory(new NeftchiServiceProviderFactory());
builder.Services.AddCors(cfg => cfg.AddPolicy("allowAll", p =>
{
	p.AllowAnyOrigin()
	.AllowAnyHeader()
	.AllowAnyMethod();
}));
builder.Services.AddDbContext<DbContext>(cfg =>
{
	cfg.UseSqlServer(builder.Configuration.GetConnectionString("cString"), cfg =>
	{
		cfg.MigrationsHistoryTable("MigrationHistory");
	});
});

builder.Services.AddIdentity<NeftchiUser, IdentityRole>(options =>
{
	options.Password.RequireDigit = false;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequiredUniqueChars = 0;
	options.Password.RequireUppercase = false;
	options.Password.RequiredLength = 6;
	options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<NeftchiContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.SameSite = SameSiteMode.None; // Required for cross-site cookie usage
	options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Use secure cookies
});

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddCors(cfg =>
{
	cfg.AddPolicy("allowAll", p =>
	{
		if (builder.Environment.IsDevelopment())
		{
			p.SetIsOriginAllowed(_ => true)
			 .AllowAnyHeader()
			 .AllowAnyMethod()
			 .AllowCredentials();
		}
		else
		{
			p.SetIsOriginAllowed(_ => true) //p.WithOrigins("https://api.neftchi-smf.com")
			 .AllowAnyHeader()
			 .AllowAnyMethod()
			 .AllowCredentials();
		}
	});
});

builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);

builder.Services.AddMediatR(cfg =>
{
	cfg.RegisterServicesFromAssemblyContaining<IApplicationReference>();
});

builder.Services.Configure<JwtOptions>(cfg => builder.Configuration.Bind(cfg.GetType().Name, cfg));

builder.Services.AddScoped<LocalFileService>();

var app = builder.Build();
app.UseCorrelation();
app.UseDbTransaction();
app.Seed();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("allowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapFallbackToFile("index.html");

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	await NeftchiContextSeed.SeedAdminAsync(services);
}


app.Run();

//public class XEnumerableModelBinderProvider : IModelBinderProvider
//{
//	public IModelBinder? GetBinder(ModelBinderProviderContext context)
//	{
//		if (context == null)
//			throw new ArgumentNullException(nameof(context));

//		if (context.Metadata.IsEnumerableType)
//		{
//			Type? elementType = context.Metadata.ElementType;
//			if (((object)elementType == null || !elementType.IsEnum) && IsSimpleType(context.Metadata.ElementType))
//			{
//				return new BinderTypeModelBinder(typeof(EnumerableModelBinder<>).MakeGenericType(context.Metadata.ElementType));
//			}
//			else if (context.Metadata.ElementType?.IsEnum != true && context.BindingInfo.BindingSource?.IsFromRequest == true)
//				return new BinderTypeModelBinder(typeof(EnumerableModelBinder<>).MakeGenericType(context.Metadata.ElementType!));
//		}
//		return null;
//	}

//	private bool IsSimpleType(Type? type)
//	{
//		return type != null && (type.IsPrimitive || type == typeof(string) || type == typeof(decimal) || type == typeof(DateTime) || type == typeof(Guid));
//	}
//}
