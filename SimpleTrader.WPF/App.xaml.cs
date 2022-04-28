using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.AuthenticationServices;
using SimpleTrader.Domain.Services.TransactionService;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using SimpleTrader.FinancialModelingPrepAPI;
using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.State.Assets;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleTrader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //測試 股票API 能否讀到股價
            //new MajorIndexService().GetMajorIndex(Domain.Models.MajorIndexType.DowJones).ContinueWith((task) =>
            //{
            //    var index = task.Result;
            //});

            //IBuyStockService buyStockService = serviceProvider.GetRequiredService<IBuyStockService>();

            IServiceProvider serviceProvider = CreateServiceProvider();
            //IAuthenticationService authenticationService = serviceProvider.GetRequiredService<IAuthenticationService>();
            //authenticationService.Register("dennis@gmail.com", "dennis", "123", "123");
            //authenticationService.Login("dennis","123");

            Window window = new MainWindow();
            window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();

            base.OnStartup(e);
        }
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            string apiKey = ConfigurationManager.AppSettings.Get("financeApiKey");
            services.AddSingleton<FinancialModelingPrepHttpClientFactory>(new FinancialModelingPrepHttpClientFactory(apiKey));

            services.AddSingleton<SimpleTraderDbContextFactory>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<IAccountService, AccountDataService>();
            services.AddSingleton<IStockPriceService, StockPriceService>();
            services.AddSingleton<IBuyStockService, BuyStockService>();
            services.AddSingleton<IMajorIndexService, MajorIndexService>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddSingleton<ISimpleTraderViewModelFactory, SimpleTraderViewModelFactory>();
            services.AddSingleton<BuyViewModel>();
            services.AddSingleton<PortfolioViewModel>();
            services.AddSingleton<AssetSummaryViewModel>();
            services.AddSingleton<HomeViewModel>(services => new HomeViewModel(
                    services.GetRequiredService<AssetSummaryViewModel>(),
                    MajorIndexListingViewModel.LoadMajorIndexViewModel(
                        services.GetRequiredService<IMajorIndexService>())));
            

            services.AddSingleton<CreateViewModel<HomeViewModel>>(services =>
            {
                return () => services.GetRequiredService<HomeViewModel>();
            });
            services.AddSingleton<CreateViewModel<BuyViewModel>>(services =>
            {
                return () => services.GetRequiredService<BuyViewModel>();
            });
            services.AddSingleton<CreateViewModel<PortfolioViewModel>>(services =>
            {
                return () => services.GetRequiredService<PortfolioViewModel>();
            });

            services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
            services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
            {
                return () => new LoginViewModel(
                        services.GetRequiredService<IAuthenticator>(),
                        services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>());                        
            });

            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IAccountStore, AccountStore>();
            services.AddSingleton<AssetStore>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<BuyViewModel>();

            return services.BuildServiceProvider();
        }

    }
}
