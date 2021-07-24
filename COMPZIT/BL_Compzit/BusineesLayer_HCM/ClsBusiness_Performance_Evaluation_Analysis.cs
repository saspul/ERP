using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.HCM;
using EL_Compzit.HCM;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;

namespace BL_Compzit.BusineesLayer_HCM
{
   
   public class ClsBusiness_Performance_Evaluation_Analysis
    {
       ClsData_Performance_Evaluation_Analysis objDataPerfmnc_tmplte = new ClsData_Performance_Evaluation_Analysis();
       public DataTable ReadEmployeEvaluationSummary(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_tmplt)
       {
           DataTable dtReadPrmnceTmplt = new DataTable();
           dtReadPrmnceTmplt = objDataPerfmnc_tmplte.ReadEmployeEvaluationSummary(objEntityPermne_tmplt);
           return dtReadPrmnceTmplt;
       }
       public DataTable ReadPerfomanceIssue(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_Anlz)
       {
           DataTable dtReadPrmnceAnalysis = new DataTable();
           dtReadPrmnceAnalysis = objDataPerfmnc_tmplte.ReadPerfomanceIssue(objEntityPermne_Anlz);
           return dtReadPrmnceAnalysis;
       }
       public DataTable ReadPerEmployeeDtls(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_Anlz)
       {
           DataTable dtReadPrmnceAnalysis = new DataTable();
           dtReadPrmnceAnalysis = objDataPerfmnc_tmplte.ReadPerEmployeeDtls(objEntityPermne_Anlz);
           return dtReadPrmnceAnalysis;
       }
       public DataTable readEvaluation(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_Anlz)
       {
           DataTable dtReadPrmnceAnalysis = new DataTable();
           dtReadPrmnceAnalysis = objDataPerfmnc_tmplte.readEvaluation(objEntityPermne_Anlz);
           return dtReadPrmnceAnalysis;
       }
       public DataTable ReadGrpQstnById(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_Anlz)
       {
           DataTable dtReadPrmnceAnalysis = new DataTable();
           dtReadPrmnceAnalysis = objDataPerfmnc_tmplte.ReadGrpQstnById(objEntityPermne_Anlz);
           return dtReadPrmnceAnalysis;
       }
       public DataTable ReadQstnById(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_Anlz)
       {
           DataTable dtReadPrmnceAnalysis = new DataTable();
           dtReadPrmnceAnalysis = objDataPerfmnc_tmplte.ReadQstnById(objEntityPermne_Anlz);
           return dtReadPrmnceAnalysis;
       }
       public DataTable LoadEmployee(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_Anlz)
       {
           DataTable dtReadPrmnceAnalysis = new DataTable();
           dtReadPrmnceAnalysis = objDataPerfmnc_tmplte.LoadEmployee(objEntityPermne_Anlz);
           return dtReadPrmnceAnalysis;
       }
       public DataTable ReadGoals(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_Anlz)
       {
           DataTable dtReadPrmnceAnalysis = new DataTable();
           dtReadPrmnceAnalysis = objDataPerfmnc_tmplte.ReadGoals(objEntityPermne_Anlz);
           return dtReadPrmnceAnalysis;
       }
       public DataTable readEvaluator(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_Anlz)
       {
           DataTable dtReadPrmnceAnalysis = new DataTable();
           dtReadPrmnceAnalysis = objDataPerfmnc_tmplte.readEvaluator(objEntityPermne_Anlz);
           return dtReadPrmnceAnalysis;
       }
    }
}
