using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class ClsEntity_Passport_Handover_Sts
    {
        private int intUserId = 0;
        private DateTime dDate;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intStatus = 0;
        private int intpassporthand_Id = 0;
        private DateTime dHandoverDate;
        private string strCancelReason = "";
        private int intCancelStat = 0;
        private int intemployee = 0;
        private int intdivision = 0;
        private int intdepartment = 0;
        private int intdesig = 0;


        public int employee
        {
            get { return intemployee; }

            set { intemployee = value; }
        }
        public int division
        {
            get { return intdivision; }

            set { intdivision = value; }
        }
        public int department
        {
            get { return intdepartment; }

            set { intdepartment = value; }
        }
        public int designation
        {
            get { return intdesig; }

            set { intdesig = value; }
        }


        public int UserId
        {
            get { return intUserId; }

            set { intUserId = value; }
        }

        public DateTime Date
        {

            get { return dDate; }
            set { dDate = value; }

        }
        public int CorpId
        {
            get { return intCorpId; }
            set { intCorpId = value; }
        }


        public int OrgId
        {
            get { return intOrgId; }
            set { intOrgId = value; }

        }

        public int HandStatus
        {

            get { return intStatus; }
            set { intStatus = value; }
        }
        public int passporthand_Id
        {

            get { return intpassporthand_Id; }
            set { intpassporthand_Id = value; }
        }
        public DateTime HandoverDate
        {

            get { return dHandoverDate; }
            set { dHandoverDate = value; }

        }

        public string CancelReason
        {

            get { return strCancelReason; }
            set { strCancelReason = value; }
        }


        public int CancelStatus
        {

            get { return intCancelStat; }
            set { intCancelStat = value; }
        }


    }
    public class clsEntity_Passport_Handover_Stslist
    {
        private int intEmployeeid_list = 0;



        public int Employeeid
        {
            get { return intEmployeeid_list; }

            set { intEmployeeid_list = value; }
        }
    }
}

