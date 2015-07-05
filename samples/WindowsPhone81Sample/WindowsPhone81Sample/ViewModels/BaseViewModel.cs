using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using WindowsPhone81Sample.Views;

namespace WindowsPhone81Sample.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel(CoreDispatcher dispatcher)
        {
            this.Dispatcher = dispatcher;
        }

        protected CoreDispatcher Dispatcher { get; private set; }

        private Dictionary<string, object> properties = new Dictionary<string, object>();

        protected void SetProperty(string name, object item)
        {
            this.properties[name] = item;

            var propertyChangedEventArgs = new PropertyChangedEventArgs(name);
            this.OnPropertyChanged(propertyChangedEventArgs);
        }

        protected T GetProperty<T>(string name)
        {
            var item = this.properties.ContainsKey(name) ? (T)this.properties[name] : default(T);
            return item;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, e);
            }
        }
    }
}
