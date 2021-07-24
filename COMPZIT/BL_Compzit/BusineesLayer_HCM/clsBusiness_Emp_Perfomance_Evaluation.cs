using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL_Compzit.HCM;
using EL_Compzit.HCM;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;

namespace BL_Compzit.BusineesLayer_HCM
{
   public class clsBusiness_Emp_Perfomance_Evaluation
    {

        clsData_Emp_Perfomance_Evaluation objDataPerfmnc_Evltion = new clsData_Emp_Perfomance_Evaluation();
        public DataTable ReadPerfomanceEvaluationList(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrmnceEvltion = new DataTable();
            dtReadPrmnceEvltion = objDataPerfmnc_Evltion.ReadPerfomanceEvaluationList(objEntityPermne_Evltion);
            return dtReadPrmnceEvltion;
        }
        public DataTable ReadPerfomanceEvaluationCount(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrmnceEvltion = new DataTable();
            dtReadPrmnceEvltion = objDataPerfmnc_Evltion.ReadPerfomanceEvaluationCount(objEntityPermne_Evltion);
            return dtReadPrmnceEvltion;
        }
        public DataTable ReadPerfomanceEvltionById(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrmnceEvltion = new DataTable();
            dtReadPrmnceEvltion = objDataPerfmnc_Evltion.ReadPerfomanceEvltionById(objEntityPermne_Evltion);
            return dtReadPrmnceEvltion;
        }
        public DataTable ReadGrpQstnById(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrmnceEvltion = new DataTable();
            dtReadPrmnceEvltion = objDataPerfmnc_Evltion.ReadGrpQstnById(objEntityPermne_Evltion);
            return dtReadPrmnceEvltion;
        }
        public DataTable ReadGrpId(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrmnceEvltion = new DataTable();
            dtReadPrmnceEvltion = objDataPerfmnc_Evltion.ReadGrpId(objEntityPermne_Evltion);
            return dtReadPrmnceEvltion;
        }
        public DataTable ReadQstnById(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrmnceEvltion = new DataTable();
            dtReadPrmnceEvltion = objDataPerfmnc_Evltion.ReadQstnById(objEntityPermne_Evltion);
            return dtReadPrmnceEvltion;
        }
        public void insert_Evaluatn_Dtls(clsEntity_Emp_perfomance_Evaluation objEntity, List<clsEntity_Emp_perfomance_Evaluation> objGrp, List<clsEntity_Emp_perfomance_Evaluation> objTotalList)
        {
            objDataPerfmnc_Evltion.insert_Evaluatn_Dtls(objEntity, objGrp, objTotalList);
        }
        public DataTable ReadEvltnAns(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrmnceEvltion = new DataTable();
            dtReadPrmnceEvltion = objDataPerfmnc_Evltion.ReadEvltnAns(objEntityPermne_Evltion);
            return dtReadPrmnceEvltion;
        }
        public void Update_Evaluatn_Dtls(clsEntity_Emp_perfomance_Evaluation objEntity, List<clsEntity_Emp_perfomance_Evaluation> objGrp, List<clsEntity_Emp_perfomance_Evaluation> objTotalList)
        {
            objDataPerfmnc_Evltion.Update_Evaluatn_Dtls(objEntity, objGrp, objTotalList);
        }
        public DataTable ReadEvltnAnsById(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrmnceEvltion = new DataTable();
            dtReadPrmnceEvltion = objDataPerfmnc_Evltion.ReadEvltnAnsById(objEntityPermne_Evltion);
            return dtReadPrmnceEvltion;
        }
        public DataTable ReadEvltnGrpAns(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrmnceEvltion = new DataTable();
            dtReadPrmnceEvltion = objDataPerfmnc_Evltion.ReadEvltnGrpAns(objEntityPermne_Evltion);
            return dtReadPrmnceEvltion;
        }
        public void Cnfrm_Evaluatn_Dtls(clsEntity_Emp_perfomance_Evaluation objEntity)
        {
            objDataPerfmnc_Evltion.Cnfrm_Evaluatn_Dtls(objEntity);
        }
        public DataTable ReadUsrDtls(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrmnceEvltion = new DataTable();
            dtReadPrmnceEvltion = objDataPerfmnc_Evltion.ReadUsrDtls(objEntityPermne_Evltion);
            return dtReadPrmnceEvltion;
        }
        public DataTable ReadUsrDesgDept(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrmnceEvltion = new DataTable();
            dtReadPrmnceEvltion = objDataPerfmnc_Evltion.ReadUsrDesgDept(objEntityPermne_Evltion);
            return dtReadPrmnceEvltion;
        }
        public DataTable ReadUsrEvltr(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrmnceEvltion = new DataTable();
            dtReadPrmnceEvltion = objDataPerfmnc_Evltion.ReadUsrEvltr(objEntityPermne_Evltion);
            return dtReadPrmnceEvltion;
        }
        public DataTable ReadEvltrsDtls(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrmnceEvltion = new DataTable();
            dtReadPrmnceEvltion = objDataPerfmnc_Evltion.ReadEvltrsDtls(objEntityPermne_Evltion);
            return dtReadPrmnceEvltion;
        }
    }
}
