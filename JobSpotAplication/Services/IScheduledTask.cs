using System.Threading;
using System.Threading.Tasks;

namespace JobSpotAplication.Services
{
    public interface IScheduledTask
    {
        string Schedule { get; set; }

        public Task ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}