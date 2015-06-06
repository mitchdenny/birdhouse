using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NestConsole
{
    public partial class PrompterForm : Form
    {
        public PrompterForm(string clientID, string clientSecret)
            : this()
        {
            this.clientID = clientID;
            this.clientSecret = clientSecret;
        }

        private string clientID;
        private string clientSecret;

        public PrompterForm()
        {
            InitializeComponent();
        }

        private void PrompterForm_Load(object sender, EventArgs e)
        {
            var url = string.Format("https://home.nest.com/login/oauth2?client_id={0}&state=STATE", this.clientID);
            this.webBrowser.Navigate(url);
        }

        public string AuthorizationCode { get; private set; }

        private Thread pinDetectThread;

        private void DetectPin()
        {
            while (this.AuthorizationCode == null)
            {
                Thread.Sleep(500);

                this.webBrowser.Invoke(new MethodInvoker(() =>
                {
                    var document = this.webBrowser.Document;
                    var pincodeViewElement = document.GetElementById("pincode-view");

                    if (pincodeViewElement != null)
                    {
                        var pincodeElement = pincodeViewElement.GetElementsByTagName("div")[0];
                        var pincode = pincodeElement.InnerText;
                        this.AuthorizationCode = pincode;

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }));
            }

        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            Console.WriteLine(e.Url);
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.pinDetectThread = new Thread(this.DetectPin);
            this.pinDetectThread.IsBackground = true;
            this.pinDetectThread.Start();
        }
    }
}
