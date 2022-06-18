using System;
using System.Windows;
using ExplorerDesktop.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace ExplorerDesktop
{
    public partial class App
    {
        private readonly IServiceProvider _serviceProvider;
        
        public App()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ViewStore>();
            services.AddScoped<EntryStore>();
            services.AddScoped<IRepository<BaseEntry>, EntriesRepository>();
            services.AddScoped<HistoryNavigationService>();

            services.AddSingleton<ViewModelFactory<EntriesViewModel>>(provider =>
            {
                return () => new EntriesViewModel(provider.GetRequiredService<ViewStore>(),
                    provider.GetRequiredService<HistoryNavigationService>(),
                    provider.GetRequiredService<IRepository<BaseEntry>>(),
                    provider.GetRequiredService<ViewModelFactory<CreateDirectoryViewModel>>(),
                    provider.GetRequiredService<ViewModelFactory<CreateFileViewModel>>(),
                    provider.GetRequiredService<ViewModelFactory<FilePropertiesViewModel>>(),
                    provider.GetRequiredService<ViewModelFactory<DirectoryPropertiesViewModel>>());
            });
            services.AddSingleton<ViewModelFactory<CreateFileViewModel>>(provider =>
            {
                return () => new CreateFileViewModel(provider.GetRequiredService<ViewStore>(),
                    provider.GetRequiredService<HistoryNavigationService>(),
                    provider.GetRequiredService<IRepository<BaseEntry>>(),
                    provider.GetRequiredService<ViewModelFactory<EntriesViewModel>>());
            });
            services.AddSingleton<ViewModelFactory<CreateDirectoryViewModel>>(provider =>
            {
                return () => new CreateDirectoryViewModel(provider.GetRequiredService<ViewStore>(),
                    provider.GetRequiredService<HistoryNavigationService>(),
                    provider.GetRequiredService<IRepository<BaseEntry>>(),
                    provider.GetRequiredService<ViewModelFactory<EntriesViewModel>>());
            });
            services.AddSingleton<ViewModelFactory<FilePropertiesViewModel>>(provider =>
            {
                return () => new FilePropertiesViewModel(provider.GetRequiredService<ViewStore>(),
                    provider.GetRequiredService<ViewModelFactory<EntriesViewModel>>());
            });
            services.AddSingleton<ViewModelFactory<DirectoryPropertiesViewModel>>(provider =>
            {
                return () => new DirectoryPropertiesViewModel(provider.GetRequiredService<ViewStore>(),
                    provider.GetRequiredService<ViewModelFactory<EntriesViewModel>>());
            });

            services.AddSingleton<MainViewModel>();
            
            services.AddSingleton(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
        }
    }
}