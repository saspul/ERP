using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;

namespace DL_Compzit.DataLayer_HCM
{
    public class cls_DataLayer_Accomodation_Report
    {
        public DataTable ReadDepts(clsEntity_Accomodation_Report objEntityAccomodation_Report)
        {
            string strQueryReadDepts = "HCM_ACCOMODATION_REPORT.SP_READ_DEPARTMENTS";
            OracleCommand cmdReadDepts = new OracleCommand();
            cmdReadDepts.CommandText = strQueryReadDepts;
            cmdReadDepts.CommandType = CommandType.StoredProcedure;
            cmdReadDepts.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityAccomodation_Report.OrganizatonId;
            cmdReadDepts.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityAccomodation_Report.CorpId;
            cmdReadDepts.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDepts = new DataTable();
            dtDepts = clsDataLayer.ExecuteReader(cmdReadDepts);
            return dtDepts;
        }
        public DataTable ReadDivision(clsEntity_Accomodation_Report objEntityAccomodation_Report)
        {
            string strQueryReadDivision = "HCM_ACCOMODATION_REPORT.SP_READ_DIVISION";
            OracleCommand cmdReadDivision = new OracleCommand();
            cmdReadDivision.CommandText = strQueryReadDivision;
            cmdReadDivision.CommandType = CommandType.StoredProcedure;
            cmdReadDivision.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityAccomodation_Report.OrganizatonId;
            cmdReadDivision.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityAccomodation_Report.CorpId;
            cmdReadDivision.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityAccomodation_Report.DepartmentId;
            cmdReadDivision.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDivision = new DataTable();
            dtDivision = clsDataLayer.ExecuteReader(cmdReadDivision);
            return dtDivision;
        }
        public DataTable ReadAccommodation(clsEntity_Accomodation_Report objEntityAccomodation_Report)
        {
            string strQueryReadAccommodation = "HCM_ACCOMODATION_REPORT.SP_READ_ACCOMODATION";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityAccomodation_Report.OrganizatonId;
            cmdReadAccommodation.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityAccomodation_Report.CorpId;
            cmdReadAccommodation.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDepts = new DataTable();
            dtDepts = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtDepts;
        }
        public DataTable ReadAccommodationList(clsEntity_Accomodation_Report objEntityAccomodation_Report)
        {
            string strQueryReadAccommodationList = "HCM_ACCOMODATION_REPORT.SP_READ_ACMDATN_RPRT_LIST";
            OracleCommand cmdReadAccommodationList = new OracleCommand();
            cmdReadAccommodationList.CommandText = strQueryReadAccommodationList;
            cmdReadAccommodationList.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodationList.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityAccomodation_Report.OrganizatonId;
            cmdReadAccommodationList.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityAccomodation_Report.CorpId;
            cmdReadAccommodationList.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityAccomodation_Report.DepartmentId;
            cmdReadAccommodationList.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityAccomodation_Report.DivisionId;
            cmdReadAccommodationList.Parameters.Add("P_ACC", OracleDbType.Int32).Value = objEntityAccomodation_Report.Accomodation;
            if (objEntityAccomodation_Report.FromDate == DateTime.MinValue)
            {
                cmdReadAccommodationList.Parameters.Add("P_FRMDATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadAccommodationList.Parameters.Add("P_FRMDATE", OracleDbType.Date).Value = objEntityAccomodation_Report.FromDate;
            }
            if (objEntityAccomodation_Report.ToDate == DateTime.MinValue)
            {
                cmdReadAccommodationList.Parameters.Add("P_TODATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadAccommodationList.Parameters.Add("P_TODATE", OracleDbType.Date).Value = objEntityAccomodation_Report.ToDate;
            }
            cmdReadAccommodationList.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDepts = new DataTable();
            dtDepts = clsDataLayer.ExecuteReader(cmdReadAccommodationList);
            return dtDepts;
        }
        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntity_Accomodation_Report objEntityAccomodation_Report)
        {
            string strQueryReadCorp = "HCM_ACCOMODATION_REPORT.SP_READ_CORP_ADDRSS_PRINT";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityAccomodation_Report.OrganizatonId;
            cmdReadCorp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityAccomodation_Report.CorpId;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }
        public DataTable ReadDivisionOfEmp(clsEntity_Accomodation_Report objEntityAccomodation_Report)
        {
            string strQueryReadEmp = "HCM_ACCOMODATION_REPORT.SP_READ_EMPLOYEE_DIV";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityAccomodation_Report.UserId;
            cmdReadEmp.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtReadEmp = new DataTable();
            dtReadEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtReadEmp;
        }
    }
}
