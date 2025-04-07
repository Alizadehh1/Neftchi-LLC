using Autofac;
using Intelect.Application.Core.Services;
using Intelect.Infrastructure.Core.Services;
using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Application.Services;
using NeftchiLLC.Domain;
using NeftchiLLC.Domain.Contexts;

namespace NeftchiLLC.Application
{
	public class ApplicationModule : Intelect.Application.Core.ApplicationModule
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<DateTimeService>()
			   .As<IDateTimeService>()
			   .InstancePerLifetimeScope();

			builder.RegisterType<FtpFileService>()
			   .AsSelf()
			   .InstancePerLifetimeScope();

			builder.RegisterType<LocalFileService>()
			   .AsImplementedInterfaces()
			   .InstancePerLifetimeScope();

			var dbContextType = typeof(IDomainReference).Assembly.GetType("NeftchiLLC.Domain.Contexts.NeftchiContext");

			builder.RegisterType(dbContextType)
				.As<DbContext>()
				.InstancePerLifetimeScope();

			builder.RegisterType<NeftchiContext>()
			   .AsSelf()
			   .InstancePerLifetimeScope();

			builder.RegisterType<AzureBlobService>()
				  .AsSelf()
				  .SingleInstance();
		}
	}
}
