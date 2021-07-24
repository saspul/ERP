using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;
using DL_Compzit.HCM;
using EL_Compzit.HCM;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;

namespace BL_Compzit.BusineesLayer_HCM
{
   public class clsBusinessLayerInterviewProcess
    {
       clsDataLayerInterviewProcesscs objDataIntervewProcess = new clsDataLayerInterviewProcesscs();

       public DataTable ReadDivision(clsEntityLayerInterviewProcess objEntityIntervewProcess)
        {
            DataTable dtDiv = objDataIntervewProcess.ReadDivision(objEntityIntervewProcess);
            return dtDiv;
        }
       public DataTable ReadDepartment(clsEntityLayerInterviewProcess objEntityIntervewProcess)
        {
            DataTable dtDpt = objDataIntervewProcess.ReadDepartment(objEntityIntervewProcess);
            return dtDpt;
        }
       public DataTable ReadDesignation(clsEntityLayerInterviewProcess objEntityIntervewProcess)
        {
            DataTable dtDesig = objDataIntervewProcess.ReadDesignation(objEntityIntervewProcess);
            return dtDesig;
        }

       public DataTable ReadAprvdManPwrReqstList(clsEntityLayerInterviewProcess objEntityIntervewProcess)
        {
            DataTable dtList = objDataIntervewProcess.ReadAprvdManPwrReqstList(objEntityIntervewProcess);
            return dtList;
        }
       public DataTable ReadProject(clsEntityLayerInterviewProcess objEntityIntervewProcess)
        {
            DataTable dtPrj = objDataIntervewProcess.ReadProject(objEntityIntervewProcess);
            return dtPrj;
        }
       public DataTable ReadShrtlistedCandidateList(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           DataTable dtList = objDataIntervewProcess.ReadShrtlistedCandidateList(objEntityIntervewProcess);
           return dtList;
       }
       public DataTable ReadRqmntDetails(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           DataTable dtList = objDataIntervewProcess.ReadRqmntDetails(objEntityIntervewProcess);
           return dtList;
       }
       public DataTable ReadEmpInfoById(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           DataTable dtList = objDataIntervewProcess.ReadEmpInfoById(objEntityIntervewProcess);
           return dtList;
       }
       public DataTable readSchdlList(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           DataTable dtList = objDataIntervewProcess.readSchdlList(objEntityIntervewProcess);
           return dtList;
       }
       public DataTable ReadScoreList()
       {
           DataTable dtList = objDataIntervewProcess.ReadScoreList();
           return dtList;
       }
       public DataTable ReadAsmntInfo(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           DataTable dtList = objDataIntervewProcess.ReadAsmntInfo(objEntityIntervewProcess);
           return dtList;
       }
       public DataTable ReadAsmntNotChcked(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           DataTable dtList = objDataIntervewProcess.ReadAsmntNotChcked(objEntityIntervewProcess);
           return dtList;
       }

       public void insertEvaltnDtls(clsEntityLayerInterviewProcess objEntityIntervewProcess, List<clsEntityLayerScheduleLevelDtls> objEntityJobSubmsnDtlList, List<clsEntityLayerAssessmentDtls> objEntityAddtnlJobsList)
       {
           objDataIntervewProcess.insertEvaltnDtls(objEntityIntervewProcess, objEntityJobSubmsnDtlList, objEntityAddtnlJobsList);
       }

       public void updateEvaltnDtls(clsEntityLayerInterviewProcess objEntityIntervewProcess, List<clsEntityLayerScheduleLevelDtls> objEntityJobSubmsnDtlListAdd, List<clsEntityLayerScheduleLevelDtls> objEntityJobSubmsnDtlListUpdate, List<clsEntityLayerAssessmentDtls> objEntityAddtnlJobsListAdd, List<clsEntityLayerAssessmentDtls> objEntityAddtnlJobsListUpdate)
       {
           objDataIntervewProcess.updateEvaltnDtls(objEntityIntervewProcess, objEntityJobSubmsnDtlListAdd, objEntityJobSubmsnDtlListUpdate, objEntityAddtnlJobsListAdd, objEntityAddtnlJobsListUpdate);
       }
       public DataTable readSchdlLVlEditInfoDtls(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           DataTable dtList = objDataIntervewProcess.readSchdlLVlEditInfoDtls(objEntityIntervewProcess);
           return dtList;
       }

       public DataTable ReadAsmntEditDtls(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           DataTable dtList = objDataIntervewProcess.ReadAsmntEditDtls(objEntityIntervewProcess);
           return dtList;
       }

       public DataTable CheckIntervProcessADDorUPD(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {

           DataTable dtList = objDataIntervewProcess.CheckIntervProcessADDorUPD(objEntityIntervewProcess);
           return dtList;
       }

       public void CloseIntervewProcess(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           objDataIntervewProcess.CloseIntervewProcess(objEntityIntervewProcess);
       }
       public void holdIntervewProcess(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           objDataIntervewProcess.holdIntervewProcess(objEntityIntervewProcess);
       }
       public void ReopenIntervewProcess(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           objDataIntervewProcess.ReopenIntervewProcess(objEntityIntervewProcess);
       }
       public DataTable checkCandStatus(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {

           DataTable dtList = objDataIntervewProcess.checkCandStatus(objEntityIntervewProcess);
           return dtList;
       }
       public DataTable readQualifiedLevel(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {

           DataTable dtList = objDataIntervewProcess.readQualifiedLevel(objEntityIntervewProcess);
           return dtList;
       }
       public void updateStatus(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           objDataIntervewProcess.updateStatus(objEntityIntervewProcess);
       }
       public DataTable readCompleteLevel(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {

           DataTable dtList = objDataIntervewProcess.readCompleteLevel(objEntityIntervewProcess);
           return dtList;
       }
       public DataTable readPanelDtls(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {

           DataTable dtList = objDataIntervewProcess.readPanelDtls(objEntityIntervewProcess);
           return dtList;
       }

       public DataTable Read_Corp_Details(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {

           DataTable dtList = objDataIntervewProcess.Read_Corp_Details(objEntityIntervewProcess);
           return dtList;
       }
    }
}
