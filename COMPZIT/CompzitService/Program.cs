using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Data;

namespace CompzitService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

//#if(!DEBUG)
            
//            string strServerPath1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString();

//            System.IO.Directory.SetCurrentDirectory(strServerPath1);
//            ServiceBase[] ServicesToRun;
//            ServicesToRun = new ServiceBase[] 
//            { 
//                new CompzitMailClient()
//            };
//            ServiceBase.Run(ServicesToRun);

            
//#else
//            CompzitMailClient myServ = new CompzitMailClient();
//            myServ.serviceStart();

//            // here Process is my Service function
//            // that will run when my service onstart is call
//            // you need to call your own method or function name here instead of Process();
//#endif

            // To be uncommented for this

            string strServerPath1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString();

            System.IO.Directory.SetCurrentDirectory(strServerPath1);
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new CompzitMailClient()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
