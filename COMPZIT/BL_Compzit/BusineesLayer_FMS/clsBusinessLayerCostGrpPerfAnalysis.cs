using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using DL_Compzit.DataLayer_FMS;
using System.Data;
using EL_Compzit.EntityLayer_FMS;

namespace BL_Compzit.BusineesLayer_FMS
{
    public class clsBusinessLayerCostGrpPerfAnalysis
    {
        clsDataLayerCostGrpPerfAnalysis objDataPaymnt = new clsDataLayerCostGrpPerfAnalysis();
        public DataTable ReadHeirarchies(clsEntityCostGrpPerfAnalysis objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadHeirarchies(objEntity);
            return dtRcpt;
        }
        public DataTable ReadGrpHeirarchiesCostGrps(clsEntityCostGrpPerfAnalysis objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadGrpHeirarchiesCostGrps(objEntity);
            return dtRcpt;
        }
        public DataTable ReadCostCenterList(clsEntityCostGrpPerfAnalysis objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadCostCenterList(objEntity);
            return dtRcpt;
        }

        public DataTable ReadCostCentres(clsEntityCostGrpPerfAnalysis objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadCostCentres(objEntity);
            return dtRcpt;
        }
        public DataTable ReadCostCenterListCntr(clsEntityCostGrpPerfAnalysis objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadCostCenterListCntr(objEntity);
            return dtRcpt;
        }

        public DataTable ReadCostGroups(clsEntityCostGrpPerfAnalysis objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadCostGroups(objEntity);
            return dtRcpt;
        }

    }
}
