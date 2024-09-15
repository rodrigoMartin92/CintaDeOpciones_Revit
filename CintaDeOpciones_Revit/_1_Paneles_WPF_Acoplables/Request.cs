using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace CintaDeOpciones_Revit._1_Paneles_WPF_Acoplables
{
    /// <summary>
    ///   A list of requests the dialog has available
    /// </summary>
    /// 
    public enum RequestId : int
    {
        None = 0,
    }

    public class Request
    {
        // Storing the value as a plain Int makes using the interlocking mechanism simpler
        private int m_request = (int)RequestId.None;
        public RequestId Take()
        {
            return (RequestId)Interlocked.Exchange(ref m_request, (int)RequestId.None);
        }

        public void Make(RequestId request)
        {
            Interlocked.Exchange(ref m_request, (int)request);
        }
    }
}
