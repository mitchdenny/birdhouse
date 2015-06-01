using Nest;
using System;
using System.Collections.Generic;
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
            var prompter = new PrompterForm();
            prompter.ShowDialog();
        }
    }
}
