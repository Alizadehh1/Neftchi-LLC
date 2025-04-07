using Autofac;
using Autofac.Extensions.DependencyInjection;
using NeftchiLLC.Application;
using NeftchiLLC.Repositories;

namespace NeftchiLLC.Api.Pipeline
{
	public class NeftchiServiceProviderFactory : AutofacServiceProviderFactory
	{
		public NeftchiServiceProviderFactory() : base(Register) { }

		static void Register(ContainerBuilder builder)
		{
			builder.RegisterModule<ApplicationModule>();
			builder.RegisterModule<RepositoryModule>();
		}
	}
}
