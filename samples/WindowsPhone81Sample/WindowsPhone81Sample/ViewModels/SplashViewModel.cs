using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Security.Authentication.Web;
using WindowsPhone81Sample.Utils;

namespace WindowsPhone81Sample.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        public SplashViewModel()
        {
            this.SignInCommand = new DelegateCommand(
                (parameter) => true,
                (parameter) =>
                {
                    WebAuthenticationBroker.AuthenticateAndContinue(
                        new Uri("https://home.nest.com/login/oauth2?client_id=752da312-28e2-4254-a447-382a41309ecd&state=STATE"),
                        new Uri("https://dummy.com")
                        );
                }
                );
        }

        public ICommand SignInCommand { get; set; }
    }
}
