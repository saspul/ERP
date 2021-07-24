using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;
//using DL_Compzit;
namespace BL_Compzit.BusinessLayer_GMS
{
   public class clsBusiness_Template_Mail_Service
    {
        clsData_Template_Mail_Service objDatTemplMailServce = new clsData_Template_Mail_Service();
        public DataTable ReadBankDetails(Entity_Template_Mail_Service EntityTemMailServce)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDatTemplMailServce.ReadBankDetails(EntityTemMailServce);
            return dtGuarnt;
        }
        public DataTable ReadDivisiondetails(Entity_Template_Mail_Service EntityTemMailServce)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDatTemplMailServce.ReadDivisiondetails(EntityTemMailServce);
            return dtGuarnt;
        }

        public DataTable ReadDesignatndetails(Entity_Template_Mail_Service EntityTemMailServce)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDatTemplMailServce.ReadDesignatndetails(EntityTemMailServce);
            return dtGuarnt;
        }

        public DataTable ReadEmplydetails(Entity_Template_Mail_Service EntityTemMailServce)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDatTemplMailServce.ReadEmplydetails(EntityTemMailServce);
            return dtGuarnt;
        }

        public DataTable ReadMailAddress(Entity_Template_Mail_Service EntityTemMailServce)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDatTemplMailServce.ReadMailAddress(EntityTemMailServce);
            return dtGuarnt;
        }
        public DataTable ReadFromMailDetails(Entity_Template_Mail_Service objEntityUsrReg)
        {
           // clsDataLayer objDataLayer = new clsDataLayer();
            DataTable dtTeamName = objDatTemplMailServce.ReadFromMailDetails(objEntityUsrReg);
            return dtTeamName;
        }

        public void UpdateMailChk(Entity_Template_Mail_Service objEntityUsrReg)
        {
           // clsDataLayer objDataLayer = new clsDataLayer();
            objDatTemplMailServce.UpdateMailChk(objEntityUsrReg);
           
        }

        public DataTable ReqstGuarnteedetails(Entity_Template_Mail_Service objEntityUsrReg)
        {
            // clsDataLayer objDataLayer = new clsDataLayer();
            DataTable dtTeamName = objDatTemplMailServce.ReqstGuarnteedetails(objEntityUsrReg);
            return dtTeamName;
        }

        public void UpdateRfqCloseDate(Entity_Template_Mail_Service objEntityUsrReg)
        {
            // clsDataLayer objDataLayer = new clsDataLayer();
            objDatTemplMailServce.UpdateRfqCloseDate(objEntityUsrReg);

        }
        public DataTable ReadGuranteeById(Entity_Template_Mail_Service objEntityUsrReg)
        {
            // clsDataLayer objDataLayer = new clsDataLayer();
            DataTable dtTeamName = objDatTemplMailServce.ReadGuranteeById(objEntityUsrReg);
            return dtTeamName;
        }

              //this method is to stores the tracking details for the mail sending
        public void InsertMailTracking(Entity_Template_Mail_Service objEntityUsrReg)
        {
            objDatTemplMailServce.InsertMailTracking(objEntityUsrReg);

        }
       //read insurance details for mail service
        public DataTable ReadInsuranceDetails(Entity_Template_Mail_Service EntityTemMailServce)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDatTemplMailServce.ReadInsuranceDetails(EntityTemMailServce);
            return dtGuarnt;
        }
        public DataTable ReadInsuranceByID(Entity_Template_Mail_Service EntityTemMailServce)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDatTemplMailServce.ReadInsuranceByID(EntityTemMailServce);
            return dtGuarnt;
        }
        public void UpdateMailChk_Insurance(Entity_Template_Mail_Service objEntityUsrReg)
        {
            objDatTemplMailServce.UpdateMailChk_Insurance(objEntityUsrReg);
        }
        public DataTable ReadMailAddressInsurance(Entity_Template_Mail_Service EntityTemMailServce)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDatTemplMailServce.ReadMailAddressInsurance(EntityTemMailServce);
            return dtGuarnt;
        }
    }
}
