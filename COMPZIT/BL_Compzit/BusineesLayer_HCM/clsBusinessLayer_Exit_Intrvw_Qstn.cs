using DL_Compzit.DataLayer_HCM;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusineesLayer_HCM
{
   public class clsBusinessLayer_Exit_Intrvw_Qstn
    {
        clsDataLayer_Exit_Intrvw_Qstn objDataExitIntrvwQstn = new clsDataLayer_Exit_Intrvw_Qstn();

        public DataTable ReadDesignationBySearch(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            DataTable dtIndenter = objDataExitIntrvwQstn.ReadDesignationBySearch(objEntityExitIntrvwQstn);
            return dtIndenter;
        }
        public DataTable ReadDesignation(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            DataTable dtIndenter = objDataExitIntrvwQstn.ReadDesignation(objEntityExitIntrvwQstn);
            return dtIndenter;
        }
        public void InsertExitIntrvwQstn(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn, List<clsEntityLayer_Exit_Intrvw_Qstn_List> objEntityExitIntrvwQstnList)
        {
            objDataExitIntrvwQstn.InsertExitIntrvwQstn(objEntityExitIntrvwQstn, objEntityExitIntrvwQstnList);
        }
        public DataTable ReadDtls(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            DataTable dtIndenter = objDataExitIntrvwQstn.ReadDtls(objEntityExitIntrvwQstn);
            return dtIndenter;
        }
        public DataTable ReadDtlsById(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            DataTable dtIndenter = objDataExitIntrvwQstn.ReadDtlsById(objEntityExitIntrvwQstn);
            return dtIndenter;
        }
        public void UpdateCertificateTemplate(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn, List<clsEntityLayer_Exit_Intrvw_Qstn_List> objEntityIntrvwINSERTList, List<clsEntityLayer_Exit_Intrvw_Qstn_List> objEntityIntrvwUPDATEList, List<clsEntityLayer_Exit_Intrvw_Qstn_List> objEntityIntrvwDELETEList)
        {
            objDataExitIntrvwQstn.UpdExitIntrvwQstn(objEntityExitIntrvwQstn, objEntityIntrvwINSERTList, objEntityIntrvwUPDATEList, objEntityIntrvwDELETEList);
        }
        public void DelExitIntrvwQstn(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            objDataExitIntrvwQstn.DelExitIntrvwQstn(objEntityExitIntrvwQstn);
        }
        public DataTable SearchExitIntrvwQstn(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            DataTable dtIndenter = objDataExitIntrvwQstn.SearchExitIntrvwQstn(objEntityExitIntrvwQstn);
            return dtIndenter;
        }
        public DataTable GetCommonQuestions(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            DataTable dtIndenter = objDataExitIntrvwQstn.GetCommonQuestions(objEntityExitIntrvwQstn);
            return dtIndenter;
        }
        public DataTable CheckSubTbl(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            DataTable dtIndenter = objDataExitIntrvwQstn.CheckSubTbl(objEntityExitIntrvwQstn);
            return dtIndenter;
        }
        public DataTable CountTransaction(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            DataTable dtIndenter = objDataExitIntrvwQstn.CountTransaction(objEntityExitIntrvwQstn);
            return dtIndenter;
        }
    }
}
