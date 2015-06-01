using Nest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestConsole
{
    public class Program
    {
        [STAThread()]
        public static void Main(string[] args)
        {
            var clientID = ConfigurationManager.AppSettings["ClientID"];
            var clientSecret = ConfigurationManager.AppSettings["ClientSecret"];

            var prompter = new PrompterForm(clientID, clientSecret);
            prompter.ShowDialog();
        }
    }
}
