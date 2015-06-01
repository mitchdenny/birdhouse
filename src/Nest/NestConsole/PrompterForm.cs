using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NestConsole
{
    public partial class PrompterForm : Form
    {
        public PrompterForm(string clientID, string clientSecret) : this()
        {
            this.clientID = clientID;
            this.clientSecret = clientSecret;
        }

        private string clientID;
        private string clientSecret;

        public PrompterForm()
        {
            InitializeComponent();

            var url = string.Format("https://home.nest.com/login/oauth2?client_id={0}&state=STATE", this.clientID);
            this.webBrowser.Url = new Uri(url);
        }
    }
}
