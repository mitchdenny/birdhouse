using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Security.Authentication.Web;
using Windows.UI.Core;
using WindowsPhone81Sample.Utils;
using WindowsPhone81Sample.Views;

namespace WindowsPhone81Sample.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        private const string ClientID = "bcff7637-0bb8-424c-9056-c45806c75374";
        private const string ClientSecret = "AK5plLbNDAaS9GLlQPkqLPvf6";

        public SplashViewModel(CoreDispatcher dispatcher) : base(dispatcher)
        {
            this.SignInCommand = new DelegateCommand(this.CanSignIn, this.SignIn);
            this.ContinueCommand = new DelegateCommand(this.CanContinue, this.Continue);
        }

        private bool CanSignIn(object parameter)
        {
            return true;
        }

        private void SignIn(object parameter)
        {
            var authorizationUrl = NestAuthorizationHelper.GenerateAuthorizationCodeUrl(
                SplashViewModel.ClientID
                );

            WebAuthenticationBroker.AuthenticateAndContinue(
                new Uri(authorizationUrl),
                new Uri("https://dummy.com")
                );
        }

        private bool CanContinue(object parameter)
        {
            return true;
        }

        private void Continue(object parameter)
        {

        }

        public string AuthorizationCode
        {
            get { return this.GetProperty<string>("AuthorizationCode"); }
            private set { this.SetProperty("AuthorizationCode", value); }
        }

        public string AccessToken
        {
            get { return this.GetProperty<string>("AccessToken"); }
            private set { this.SetProperty("AccessToken", value); }
        }

        public async Task UpdateAuthorizationCodeAsync(string authorizationCode)
        {
            await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                this.AuthorizationCode = authorizationCode;
            });

            var accessToken = await NestAuthorizationHelper.RequestAccessTokenFromAuthorizationCodeAsync(
                SplashViewModel.ClientID,
                this.AuthorizationCode,
                SplashViewModel.ClientSecret
                );

            await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                this.AccessToken = accessToken;
            });
        }

        public ICommand SignInCommand { get; private set; }
        public ICommand ContinueCommand { get; private set; }
    }
}
