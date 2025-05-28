
using GoldCS.API.Services;

namespace GoldCS.API.HostedServices
{
    public class RecycleRefreshTokenHostedService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRecycleTokenService _recycleTokenService;
        private Timer _timer;


        public RecycleRefreshTokenHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _recycleTokenService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IRecycleTokenService>();
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(RecycleTokensMoreThanOnePerUser, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        private async void RecycleTokensMoreThanOnePerUser(object state)
        {
            try
            {
                var deletedItems = await _recycleTokenService.RecycleRefreshTokenMoreThanOnePerUser();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer?.Change(Timeout.Infinite, 0);
        }


    }

}
