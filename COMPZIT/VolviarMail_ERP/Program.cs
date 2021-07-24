using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailUtility_ERP;
namespace VolviarMail_ERP
{
    class Program
    {
        static void Main(string[] args)
        {
            clsMail objMailUtility = new clsMail();
            objMailUtility.BulkMail();
        }
    }
}
