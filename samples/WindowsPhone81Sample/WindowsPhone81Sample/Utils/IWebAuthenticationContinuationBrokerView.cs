using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhone81Sample.Utils
{
    public interface IWebAuthenticationContinuationBrokerView
    {
        void ContinueWithSuccess(string authorizationCode);
        void ContinueWithFailure();
    }
}
