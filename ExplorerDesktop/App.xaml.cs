using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace ExplorerDesktop
{
    public partial class App
    {
        private readonly IServiceProvider _serviceProvider;
        
        public App()
        {
            IServiceCollection services = new ServiceCollection();

            /*var store = new GoogleServiceStore();
            var googleAuth = new GoogleAuth(store);

            services.AddSingleton(store);*/
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<IEntriesController, SystemEntriesController>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();
        }
    }
}