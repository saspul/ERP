using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_AWMS
{

    public   class clsEntityLayerTrafficViolationReport
    {

        
        private int intcorid=0;
        private int intOrgid = 0;
        private int intEmpid = 0;
        private int intVechId=0;
        private int intStatus=0;
        private DateTime dFromDate=new DateTime();
        private DateTime dToDate = new DateTime();




        public int CorpId
        {
            get
            {
                return intcorid;
            }
            set
            {
                intcorid = value;
            }
        }

        public int OrgID
        {
            get
            {
                return intOrgid;
            }
            set
            {
               intOrgid = value;
            }
        }

        //methode of storing employee id
        public int EmployeeID
        {
            get
            {
                return intEmpid;
            }
            set
            {
                intEmpid = value;
            }
        }
        //methode of storing vechcle id
        public int vehicleid
        {
            get
            {
                return intVechId;
            }
            set
            {
               intVechId = value;
            }
        }
        //methode of storing status
        public int Status
        {
            get
            {
                return intStatus;
            }
            set
            {
               intStatus = value;
            }
        }
        //methode of storing to date
        public DateTime ToDate
        {
            get
            {
                return dToDate;
            }
            set
            {
                dToDate = value;
            }
        }
        //methode of storing from date
        public DateTime FromDate
        {
            get
            {
                return dFromDate;
            }
            set
            {
                dFromDate = value;
            }
        }
    
    
    }
    public class clsEntityLayerEmployee
    {
        private int intEmpid=0; private int intVechId=0;
    private    string strsearchby="";
        public int EmployeeID
        {
            get
            {
                return intEmpid;
            }
            set
            {
                intEmpid = value;
            }
        } 
        public int vehicleid
        {
            get
            {
                return intVechId;
            }
            set
            {
                intVechId = value;
            }
        }
        public string searchby
        { 
         get
            {
                return strsearchby;
            }
            set
            {
                strsearchby = value;
            }
        }
        
    }


}
