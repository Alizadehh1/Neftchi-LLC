using Intelect.Infrastructure.Core.Services;

namespace NeftchiLLC.Application.Services
{
	public class DateTimeService : IDateTimeService
	{
		public DateTime ExecutingTime => DateTime.UtcNow.AddHours(4);
	}
}
