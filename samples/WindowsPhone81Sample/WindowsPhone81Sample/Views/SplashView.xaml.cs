using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WindowsPhone81Sample.Utils;
using WindowsPhone81Sample.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace WindowsPhone81Sample.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SplashView : BaseView
    {
        public SplashView()
        {
            this.InitializeComponent();
            this.ViewModel = new SplashViewModel(this.Dispatcher);
        }

        public void ContinueWithFailure()
        {

        }

        public void ContinueWithSuccess(string authorizationCode)
        {
            var viewModel = this.ViewModel as SplashViewModel;

            Task.Run(async () =>
            {
                await viewModel.UpdateAuthorizationCodeAsync(authorizationCode);
            });
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
