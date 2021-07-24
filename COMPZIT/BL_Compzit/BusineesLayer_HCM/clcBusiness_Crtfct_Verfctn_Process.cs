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
    public class clcBusiness_Crtfct_Verfctn_Process
    {
        clsDataLayer_Crtfct_Verfctn_Process objDataJobDescrptn = new clsDataLayer_Crtfct_Verfctn_Process();


        public DataTable ReadCandidateLoad(clsEntity_Crtfct_Verfctn_Process objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadCandidateLoad(objEntityjob);
            return dtGuarnt;
        }
        public DataTable ReadCertfctBundl(clsEntity_Crtfct_Verfctn_Process objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadCertfctBundl(objEntityjob);
            return dtGuarnt;
        }
        public DataTable ReadJobRole(clsEntity_Crtfct_Verfctn_Process objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadJobRole(objEntityjob);
            return dtGuarnt;
        }

        public DataTable ReadCertfctBundle(clsEntity_Crtfct_Verfctn_Process objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadCertfctBundle(objEntityjob);
            return dtGuarnt;
        }
        public void InsertVerfcnProcess(clsEntity_Crtfct_Verfctn_Process objEntityTemp, List<clsEntity_Crtverfcn_Dtls> objEntityIntervShedule)
        {
            // DataTable dtGuarnt = new DataTable();
            //int TempId;
            objDataJobDescrptn.InsertVerfcnProcess(objEntityTemp, objEntityIntervShedule);
           // return TempId;
        }
        
            
        public DataTable ReadCrtVerfctnPrss(clsEntity_Crtfct_Verfctn_Process objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadCrtVerfctnPrss(objEntityjob);
            return dtGuarnt;
        }
        public DataTable ReadCrtVerfctnPrssDtls(clsEntity_Crtfct_Verfctn_Process objEntityjob)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.ReadCrtVerfctnPrssDtls(objEntityjob);
            return dtGuarnt;
        }

        public void Update_VerfcnProcess(clsEntity_Crtfct_Verfctn_Process objEntityTemp, List<clsEntity_Crtverfcn_Dtls> objEntityIntervSheduleIns, List<clsEntity_Crtverfcn_Dtls> objEntityIntervSheduleUpd, string[] strarrCancldtlIds)
        {
            // DataTable dtGuarnt = new DataTable();

            objDataJobDescrptn.Update_VerfcnProcess(objEntityTemp, objEntityIntervSheduleIns, objEntityIntervSheduleUpd, strarrCancldtlIds);

        }

        public void Cancel_Cerfct_Valdatn(clsEntity_Crtfct_Verfctn_Process objEntityjob)
        {

            objDataJobDescrptn.Cancel_Cerfct_Valdatn(objEntityjob);

        }

        public DataTable Read_Cerfct_ValdatnList(clsEntity_Crtfct_Verfctn_Process objEntityintrvTem)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataJobDescrptn.Read_Cerfct_ValdatnList(objEntityintrvTem);
            return dtGuarnt;
        }


        public void ChangeReqToConplete(clsEntity_Crtfct_Verfctn_Process objEntityjob)
        {

            objDataJobDescrptn.ChangeReqToConplete(objEntityjob);

        }
        
    }
}
