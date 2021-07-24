using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
using EL_Compzit;

namespace DL_Compzit.DataLayer_FMS
{
    public class clsDataLayerCostGrpPerfAnalysis
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        public DataTable ReadHeirarchies(clsEntityCostGrpPerfAnalysis objEntity)
        {
            string strQueryReadRcpt = "FMS_COSTGRP_ANALYSIS.SP_READ_HEIRARCHIES";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable ReadGrpHeirarchiesCostGrps(clsEntityCostGrpPerfAnalysis objEntity)
        {
            string strQueryReadRcpt = "FMS_COSTGRP_ANALYSIS.SP_READ_HEIRARCHIES_GRPS";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_HEIRACHY_ID", OracleDbType.Int32).Value = objEntity.HeirarchyId;
            cmdReadRcpt.Parameters.Add("R_DATEFROM", OracleDbType.Date).Value = objEntity.FromDate;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable ReadCostCenterList(clsEntityCostGrpPerfAnalysis objEntity)
        {
            string strQueryReadRcpt = "FMS_COSTGRP_ANALYSIS.SP_READ_LIST";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_HEIRACHY_ID", OracleDbType.Int32).Value = objEntity.HeirarchyId;
            cmdReadRcpt.Parameters.Add("R_DATEFROM", OracleDbType.Date).Value = objEntity.FromDate;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_COSTGRP_IDS", OracleDbType.Varchar2).Value = objEntity.CostGrpIds;           
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable ReadCostCentres(clsEntityCostGrpPerfAnalysis objEntity)
        {
            string strQueryReadRcpt = "FMS_COSTCNTR_ANALYSIS.SP_READ_COST_CENTRES";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATEFROM", OracleDbType.Date).Value = objEntity.FromDate;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable ReadCostCenterListCntr(clsEntityCostGrpPerfAnalysis objEntity)
        {
            string strQueryReadRcpt = "FMS_COSTCNTR_ANALYSIS.SP_READ_LIST";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATEFROM", OracleDbType.Date).Value = objEntity.FromDate;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_COSTCNTR_IDS", OracleDbType.Varchar2).Value = objEntity.CostCentreIds;
            cmdReadRcpt.Parameters.Add("R_ALLCOSTCNTR", OracleDbType.Int32).Value = objEntity.AllCostCentres;
            cmdReadRcpt.Parameters.Add("R_COSTGRPIDS", OracleDbType.Varchar2).Value = objEntity.CostGrpIds;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable ReadCostGroups(clsEntityCostGrpPerfAnalysis objEntity)
        {
            string strQueryReadRcpt = "FMS_COSTCNTR_ANALYSIS.SP_READ_COST_GROUPS";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }


    }
}
