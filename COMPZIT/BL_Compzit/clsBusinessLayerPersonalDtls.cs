using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DL_Compzit;
using EL_Compzit;
using System.Data;
using DL_Compzit.DataLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;

namespace BL_Compzit
{
    public class clsBusinessLayerPersonalDtls
    {
        clsDataLayerPersonalDtls objDataLayerPersonalDtls = new clsDataLayerPersonalDtls();
        public DataTable readCountry()
        {
            DataTable dtReadCountry = objDataLayerPersonalDtls.readCountry();
            return dtReadCountry;
        }
        public DataTable ReadReligion()
        {

            DataTable dtReligion = objDataLayerPersonalDtls.ReadReligion();
            return dtReligion;
        }
        public DataTable ReadBloodgrp()
        {

            DataTable dtBloodgrp = objDataLayerPersonalDtls.ReadBloodgrp();
            return dtBloodgrp;
        }
        public void insertPersonalDtls(clsEntityPersonalDtls objEntityPersonalDtls, int SubcatgId, int MessAccmId)
        {
            objDataLayerPersonalDtls.insertPersonalDtls(objEntityPersonalDtls, SubcatgId, MessAccmId);
        }
        public void updatePersonalDtls(clsEntityPersonalDtls objEntityPersonalDtls, int SubcatgId, int MessAccmId)
        {
            objDataLayerPersonalDtls.updatePersonalDtls(objEntityPersonalDtls, SubcatgId, MessAccmId);
        }
        public DataTable ReadPersnlDtlsById(clsEntityPersonalDtls objEntityPersonalDtls)
        {

            DataTable dtDetailsById = objDataLayerPersonalDtls.ReadPersnlDtlsById(objEntityPersonalDtls);
            return dtDetailsById;
        }
        public string CheckPerDtlAddedOrNot(string strId)
        {

            string count = objDataLayerPersonalDtls.CheckPerDtlAddedOrNot(strId);
            return count;
        }

        public string checkEmpId(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            string strReturn = objDataLayerPersonalDtls.checkEmpId(objEntityPersonalDtls);
            return strReturn;
        }
        public DataTable ReadEmployee(clsEntityPersonalDtls objEntityPersonalDtls)
        {

            DataTable dtReligion = objDataLayerPersonalDtls.ReadEmployee(objEntityPersonalDtls);
            return dtReligion;
        }
        public DataTable ReadResignDetails(clsEntityPersonalDtls objEntityPersonalDtls)
        {

            DataTable dtReligion = objDataLayerPersonalDtls.ReadResignDetails(objEntityPersonalDtls);
            return dtReligion;
        }
        public void UpdateResignDetails(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            objDataLayerPersonalDtls.UpdateResignDetails(objEntityPersonalDtls);


        }
        public DataTable ReadAccnCatagry(clsEntityPersonalDtls objEntityPersonalDtls)
        {

            DataTable dtReligion = objDataLayerPersonalDtls.ReadAccnCatagry(objEntityPersonalDtls);
            return dtReligion;
        }

        public DataTable ReadAccnSubCatagry(clsEntityPersonalDtls objEntityPersonalDtls)
        {

            DataTable dtReligion = objDataLayerPersonalDtls.ReadAccnSubCatagry(objEntityPersonalDtls);
            return dtReligion;
        }
        public DataTable ReadAccomdtion(clsEntityPersonalDtls objEntityPersonalDtls)
        {

            DataTable dtReligion = objDataLayerPersonalDtls.ReadAccomdtion(objEntityPersonalDtls);
            return dtReligion;
        }
        public DataTable ReadAccomdtionMess(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            DataTable dtReligion = objDataLayerPersonalDtls.ReadAccomdtionMess(objEntityPersonalDtls);
            return dtReligion;
        }
        public void EmployeeResign()
        {
            objDataLayerPersonalDtls.EmployeeResign();
        }

        public DataTable ReadBank(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            DataTable dtBank = objDataLayerPersonalDtls.ReadBank(objEntityPersonalDtls);
            return dtBank;
        }

        public void InsertBankDtls(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            objDataLayerPersonalDtls.InsertBankDtls(objEntityPersonalDtls);
        }

        public DataTable ReadBankDtlsById(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            DataTable dtBank = objDataLayerPersonalDtls.ReadBankDtlsById(objEntityPersonalDtls);
            return dtBank;
        }

        public void UpdateBankDtls(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            objDataLayerPersonalDtls.UpdateBankDtls(objEntityPersonalDtls);
        }
        //emp-0043 strt
        //public void DeletekBankDtls(clsEntityPersonalDtls objEntityPersonalDtls)
        ////{
        ////    objDataLayerPersonalDtls.DeleteBankList(objEntityPersonalDtls);
        ////}
        ////end

        //EMP-0043 start
        public void CancelBankdtls(clsEntityPersonalDtls objEntityPersonalDtls)
        {
            objDataLayerPersonalDtls.CancelBankdtls(objEntityPersonalDtls);
        }
        //end

    }
}
