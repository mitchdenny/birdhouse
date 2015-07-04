using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WindowsPhone81Sample.Utils;

namespace WindowsPhone81Sample.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        public SplashViewModel()
        {
            this.SignInCommand = new DelegateCommand();
        }

        public ICommand SignInCommand { get; set; }
    }
}
