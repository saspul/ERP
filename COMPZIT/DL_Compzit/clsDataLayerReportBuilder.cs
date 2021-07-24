using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit;
using CL_Compzit;

namespace DL_Compzit
{
    public class clsDataLayerReportBuilder
    {
        public DataTable ReadReportData(clsEntityReportBuilder objEntityCommon)
        {
            string strCommandText = "REPORT_BUILDER.SP_READ_REPORT";
            using (OracleCommand cmdCommon = new OracleCommand())
            {
                cmdCommon.CommandText = strCommandText;
                cmdCommon.CommandType = CommandType.StoredProcedure;
                cmdCommon.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityCommon.CorpId;
                cmdCommon.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityCommon.OrgId;
                cmdCommon.Parameters.Add("R_REPORT_ID", OracleDbType.Int32).Value = objEntityCommon.ReportId;
                cmdCommon.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.ExecuteReader(cmdCommon);
                return dtGridDisp;
            }
        }

        public DataTable ReadReportDtls(clsEntityReportBuilder objEntityCommon)
        {
            string strCommandText = "REPORT_BUILDER.SP_READ_REPORT_DTLS";
            using (OracleCommand cmdCommon = new OracleCommand())
            {
                cmdCommon.CommandText = strCommandText;
                cmdCommon.CommandType = CommandType.StoredProcedure;
                cmdCommon.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityCommon.CorpId;
                cmdCommon.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityCommon.OrgId;
                cmdCommon.Parameters.Add("R_REPORT_ID", OracleDbType.Int32).Value = objEntityCommon.ReportId;
                cmdCommon.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.ExecuteReader(cmdCommon);
                return dtGridDisp;
            }
        }

        public DataTable ReadProcedure(string strPackage, string strProcedure, int CorpId, int OrgId, DataTable dtParameters)
        {
            string strCommandText = strPackage + "." + strProcedure;
            using (OracleCommand cmdCommon = new OracleCommand())
            {
                cmdCommon.CommandText = strCommandText;
                cmdCommon.CommandType = CommandType.StoredProcedure;
                foreach (DataRow dt in dtParameters.Rows)
                {
                    clsCommonLibrary objCommon = new clsCommonLibrary();

                    string Paramtr = dt["PARAMETER_NAME"].ToString();

                    OracleParameter parameter = new OracleParameter();

                    parameter.ParameterName = dt["PARAMETER_NAME"].ToString();

                    if (dt["DATA_TYPE"].ToString().ToUpper() == "NUMBER")
                    {
                        string value = "";
                        if (dt["PARAMETER_NAME"].ToString() == "R_CORPID" || dt["PARAMETER_NAME"].ToString() == "R_ORGID")
                        {
                            if (dt["PARAMETER_NAME"].ToString() == "R_CORPID")
                            {
                                value = CorpId.ToString();
                            }
                            else if (dt["PARAMETER_NAME"].ToString() == "R_ORGID")
                            {
                                value = OrgId.ToString();
                            }
                        }
                        else
                        {
                            value = dt["VALUE"].ToString();
                        }
                        parameter.OracleDbType = OracleDbType.Int32;
                        if (value != "")
                        {
                            parameter.Value = Convert.ToInt32(value);
                        }
                        else
                        {
                            parameter.Value = DBNull.Value;
                        }
                        parameter.Direction = ParameterDirection.Input;
                    }
                    else if (dt["DATA_TYPE"].ToString().ToUpper() == "VARCHAR2")
                    {
                        parameter.OracleDbType = OracleDbType.Varchar2;
                        parameter.Value = dt["VALUE"];
                        parameter.Direction = ParameterDirection.Input;
                    }
                    else if (dt["DATA_TYPE"].ToString().ToUpper() == "NVARCHAR2")
                    {
                        parameter.OracleDbType = OracleDbType.NVarchar2;
                        parameter.Value = dt["VALUE"];
                        parameter.Direction = ParameterDirection.Input;
                    }
                    else if (dt["DATA_TYPE"].ToString().ToUpper() == "DECIMAL")
                    {
                        parameter.OracleDbType = OracleDbType.Decimal;
                        if (dt["VALUE"].ToString() != "")
                        {
                            parameter.Value = Convert.ToDecimal(dt["VALUE"]);
                        }
                        else
                        {
                            parameter.Value = DBNull.Value;
                        }
                        parameter.Direction = ParameterDirection.Input;
                    }
                    else if (dt["DATA_TYPE"].ToString().ToUpper() == "DATE")
                    {
                        parameter.OracleDbType = OracleDbType.Date;
                        if (dt["VALUE"].ToString() != "")
                        {
                            DateTime dateval = objCommon.textToDateTime(dt["VALUE"].ToString());
                            if (dateval != DateTime.MinValue)
                            {
                                parameter.Value = dateval;
                            }
                            else
                            {
                                parameter.Value = DBNull.Value;
                            }
                        }
                        else
                        {
                            parameter.Value = DBNull.Value;
                        }
                        parameter.Direction = ParameterDirection.Input;
                    }
                    else if (dt["DATA_TYPE"].ToString().ToUpper() == "REF CURSOR")
                    {
                        parameter.OracleDbType = OracleDbType.RefCursor;
                        parameter.Direction = ParameterDirection.Output;
                    }

                    cmdCommon.Parameters.Add(parameter);
                }

                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.ExecuteReader(cmdCommon);
                return dtGridDisp;
            }
        }

        public DataTable ReadProcedureParameters(string strPackage, string strProcedure)
        {
            string strCommandText = "REPORT_BUILDER.SP_READ_PARAMETERS";
            using (OracleCommand cmdCommon = new OracleCommand())
            {
                cmdCommon.CommandText = strCommandText;
                cmdCommon.CommandType = CommandType.StoredProcedure;
                cmdCommon.Parameters.Add("R_PACKAGE", OracleDbType.Varchar2).Value = strPackage;
                cmdCommon.Parameters.Add("R_PROCEDURE", OracleDbType.Varchar2).Value = strProcedure;
                cmdCommon.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.ExecuteReader(cmdCommon);
                return dtGridDisp;
            }
        }

    }
}
