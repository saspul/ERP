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
    public class clsBusnssLyr_gen_Interview_Temp
    {
        clsDataLayer_Interview_Temp objDataintrvTem = new clsDataLayer_Interview_Temp();

        public DataTable ReadShedTypLoad(clsEntity_Interview_Temp objEntityintrvTem)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataintrvTem.ReadDivision(objEntityintrvTem);
            return dtGuarnt;
        }
        public DataTable ReadCatagoryTypLoad(clsEntity_Interview_Temp objEntityintrvTem)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataintrvTem.ReadCatagoryTypLoad(objEntityintrvTem);
            return dtGuarnt;
        }
        public int Insert_Interv_Templates(clsEntity_Interview_Temp objEntityTemp, List<clsEntityInterviewShedule> objEntityIntervShedule)
        {
           // DataTable dtGuarnt = new DataTable();
            int TempId;
            TempId = objDataintrvTem.Insert_Interv_Templates(objEntityTemp, objEntityIntervShedule);
            return TempId;
        }

        public void CancelinterviewTem(clsEntity_Interview_Temp objEntityjob)
       {

           objDataintrvTem.CancelinterviewTem(objEntityjob);

       }

        public DataTable ReadinterviewTemList(clsEntity_Interview_Temp objEntityintrvTem)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataintrvTem.ReadinterviewTemList(objEntityintrvTem);
            return dtGuarnt;
        }
        public DataTable ReadIntervwTemDetailsTxt(clsEntity_Interview_Temp objEntityintrvTem)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataintrvTem.ReadIntervwTemDetailsTxt(objEntityintrvTem);
            return dtGuarnt;
        }

        public void ChangeRequestStatus(clsEntity_Interview_Temp objEntityjob)
       {

           objDataintrvTem.ChangeRequestStatus(objEntityjob);

       }

        public DataTable ReadIntervwTemDetails(clsEntity_Interview_Temp objEntityintrvTem)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataintrvTem.ReadIntervwTemDetails(objEntityintrvTem);
            return dtGuarnt;
        }
        public void Update_Interv_Templates(clsEntity_Interview_Temp objEntityTemp, List<clsEntityInterviewShedule> objEntityIntervSheduleIns, List<clsEntityInterviewShedule> objEntityIntervSheduleUpd, string[] strarrCancldtlIds)
        {
            // DataTable dtGuarnt = new DataTable();

            objDataintrvTem.Update_Interv_Templates(objEntityTemp, objEntityIntervSheduleIns, objEntityIntervSheduleUpd, strarrCancldtlIds);
          
        }


        public string DuplCheckIntervwTem(clsEntity_Interview_Temp objEntityintrvTem)
       {
           string dtGuarnt = "";
           dtGuarnt = objDataintrvTem.DuplCheckIntervwTem(objEntityintrvTem);
           return dtGuarnt;
       }
    }
}
