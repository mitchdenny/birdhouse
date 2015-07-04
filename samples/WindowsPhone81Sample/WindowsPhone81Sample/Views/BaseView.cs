using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using WindowsPhone81Sample.ViewModels;

namespace WindowsPhone81Sample.Views
{
    public class BaseView : Page
    {
        public BaseView()
        {
        }

        public BaseViewModel ViewModel
        {
            get { return (BaseViewModel)this.DataContext; }
            set { this.DataContext = value; }
        }
    }
}
