using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;
using System.Data;

namespace BL_Compzit
{
    public class clsBusinessLayerBank
    {
        clsDataLayerBank objDataBank = new clsDataLayerBank();
        // This Method adds bank details to the table


        public DataTable ReadChkBookDtlsById(clsEntityLayerBank objEntityBank)
        {
            DataTable dtAccodetails = objDataBank.ReadChkBookDtlsById(objEntityBank);
            return dtAccodetails;
        }

        public DataTable ReadChequeTemplateDtl(clsEntityLayerBank objEntityBank)
        {
            DataTable dtAccodetails = objDataBank.ReadChequeTemplateDtl(objEntityBank);
            return dtAccodetails;
        }

        public void AddBankName(clsEntityLayerBank objEntityBank,List<clsEntityLayerBank> objList)
        {
            objDataBank.AddBankName(objEntityBank, objList);

        }
        // This Method update bank details to the table
        public void UpdateBankName(clsEntityLayerBank objEntityBank,List<clsEntityLayerBank> objEntityPerfomList,string[] strarrCancldtlIds)
        {
            objDataBank.UpdateBankName(objEntityBank, objEntityPerfomList, strarrCancldtlIds);
        }

        // This Method checks Bank name in the database for duplication.
        public string CheckBankName(clsEntityLayerBank objEntityBank)
        {

            string count = objDataBank.CheckBankName(objEntityBank);
            return count;
        }
        //Method for cancel bank
        public void CancelBank(clsEntityLayerBank objEntityBank)
        {

            objDataBank.CancelBank(objEntityBank);
        }

        // This Method will fetCH bank DEATILS BY ID
        public DataTable ReadBankById(clsEntityLayerBank objEntityBank)
        {
            DataTable dtAccodetails = objDataBank.ReadBankById(objEntityBank);
            return dtAccodetails;
        }
        // This Method will fetch bank details list
        public DataTable ReadBankDetailList(clsEntityLayerBank objEntityBank)
        {
            DataTable dtAccodetails = objDataBank.ReadBankDetailList(objEntityBank);
            return dtAccodetails;
        }


        // This Method recll bank details to the table
        public void ReCallBank(clsEntityLayerBank objEntityBank)
        {
            objDataBank.ReCallBank(objEntityBank);
        }
        public void ChangeStatus(clsEntityLayerBank objEntityBank)
        {
            objDataBank.ChangeStatus(objEntityBank);
        }
    }
}
