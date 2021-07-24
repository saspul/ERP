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
    public class clsBusinessImmigrationTasks
    {

        clsDataLayerImmigrationTasks objDataImgrtnTasks = new clsDataLayerImmigrationTasks();
        public DataTable ReadAsgndImgrtnCandts(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            DataTable dtDiv = objDataImgrtnTasks.ReadAsgndImgrtnCandts(objEntityImgrtnTasks);
            return dtDiv;
        }
        public DataTable ReadEmpLoad(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            DataTable dtDiv = objDataImgrtnTasks.ReadEmpLoad(objEntityImgrtnTasks);
            return dtDiv;
        }
        public DataTable ReadEmpInfoById(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            DataTable dtDiv = objDataImgrtnTasks.ReadEmpInfoById(objEntityImgrtnTasks);
            return dtDiv;
        }
        public DataTable ReadEmpRoundDtls(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            DataTable dtDiv = objDataImgrtnTasks.ReadEmpRoundDtls(objEntityImgrtnTasks);
            return dtDiv;
        }
        public DataTable ReadEmpAsgnedForRnd(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            DataTable dtDiv = objDataImgrtnTasks.ReadEmpAsgnedForRnd(objEntityImgrtnTasks);
            return dtDiv;
        }
        public DataTable ReadEmpRoundDtlsID(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            DataTable dtDiv = objDataImgrtnTasks.ReadEmpRoundDtlsID(objEntityImgrtnTasks);
            return dtDiv;
        }
        public DataTable ReadStatusDdl(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            DataTable dtDiv = objDataImgrtnTasks.ReadStatusDdl(objEntityImgrtnTasks);
            return dtDiv;
        }

        public void addRoundDtls(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            objDataImgrtnTasks.addRoundDtls(objEntityImgrtnTasks);
        }
        public void CloseRound(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            objDataImgrtnTasks.CloseRound(objEntityImgrtnTasks);
        }
        public void finisRound(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            objDataImgrtnTasks.finisRound(objEntityImgrtnTasks);
        }
        public DataTable CheckRoundFinisdClsd(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            DataTable dtDiv = objDataImgrtnTasks.CheckRoundFinisdClsd(objEntityImgrtnTasks);
            return dtDiv;
        }
    }
}
