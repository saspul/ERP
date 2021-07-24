using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntity_Mess_Exemption
    {
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intAccomoDationId = 0;
        private int intMessexceptId = 0;
        private int intEmpId = 0;
        private DateTime dtFromdate;
        private DateTime dtTodate;

        //method for storing mess exception id
        public int EmpId
        {
            get
            {
                return intEmpId;
            }
            set
            {
                intEmpId = value;
            }
        }
        //method for storing mess exception id
        public int MessexceptId
        {
            get
            {
                return intMessexceptId;
            }
            set
            {
                intMessexceptId = value;
            }
        }
        //method for storing Accomodation id
        public int AccomoDationId
        {
            get
            {
                return intAccomoDationId;
            }
            set
            {
                intAccomoDationId = value;
            }
        }
        //method for storing organization id
        public int Organisation_Id
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


        //Method for storing Corporate office id.
        public int CorpOffice_Id
        {
            get
            {
                return intCorpOffice;
            }
            set
            {
                intCorpOffice = value;
            }
        }


        //Method for storing user id who do the event.
        public int User_Id
        {
            get
            {
                return intUserId;
            }
            set
            {
                intUserId = value;
            }
        }

        //Method for storing the to date.
        public DateTime Todate
        {
            get
            {
                return dtTodate;
            }
            set
            {
                dtTodate = value;
            }
        }
        //Method for storing the from date.
        public DateTime Fromdate
        {
            get
            {
                return dtFromdate;
            }
            set
            {
                dtFromdate = value;
            }
        }
    }
}
