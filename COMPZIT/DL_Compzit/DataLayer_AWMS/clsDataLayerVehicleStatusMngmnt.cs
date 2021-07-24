using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;

namespace DL_Compzit.DataLayer_AWMS
{
    public class clsDataLayerVehicleStatusMngmnt
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();

        // This Method will fetch vehicle details
        public DataTable ReadVehicles(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryReadVehicle = "VEHICLE_STATUS_MNGMNT.SP_READ_VEHICLE_ASIGN_LIST";
            OracleCommand cmdReadVehicle = new OracleCommand();
            cmdReadVehicle.CommandText = strQueryReadVehicle;
            cmdReadVehicle.CommandType = CommandType.StoredProcedure;
            cmdReadVehicle.Parameters.Add("I_MODE", OracleDbType.Int32).Value = ObjVehicleStatus.AssignMode;
            cmdReadVehicle.Parameters.Add("I_VEHCLID", OracleDbType.Int32).Value = ObjVehicleStatus.VehicleId;
            cmdReadVehicle.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = ObjVehicleStatus.Org_Id;
            cmdReadVehicle.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = ObjVehicleStatus.CorporateId;
            cmdReadVehicle.Parameters.Add(" I_VEHCLS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehicle = new DataTable();
            dtVehicle = clsDataLayer.ExecuteReader(cmdReadVehicle);
            return dtVehicle;
        }
        // This Method will fetch DIVISION details
        public DataTable ReadDivision(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryReadDivision = "VEHICLE_STATUS_MNGMNT.SP_READ_DIVISION";
            OracleCommand cmdReadDivision = new OracleCommand();
            cmdReadDivision.CommandText = strQueryReadDivision;
            cmdReadDivision.CommandType = CommandType.StoredProcedure;
            cmdReadDivision.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = ObjVehicleStatus.Org_Id;
            cmdReadDivision.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = ObjVehicleStatus.CorporateId;
            cmdReadDivision.Parameters.Add(" I_DIVISION", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehicle = new DataTable();
            dtVehicle = clsDataLayer.ExecuteReader(cmdReadDivision);
            return dtVehicle;
        }
        // This Method will fetch PROJECT details
        public DataTable ReadProject(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryReadDivision = "VEHICLE_STATUS_MNGMNT.SP_READ_PROJECT";
            OracleCommand cmdReadDivision = new OracleCommand();
            cmdReadDivision.CommandText = strQueryReadDivision;
            cmdReadDivision.CommandType = CommandType.StoredProcedure;
            cmdReadDivision.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = ObjVehicleStatus.Org_Id;
            cmdReadDivision.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = ObjVehicleStatus.CorporateId;
            cmdReadDivision.Parameters.Add("I_DIVID", OracleDbType.Int32).Value = ObjVehicleStatus.DivisionId;
            cmdReadDivision.Parameters.Add("I_PROJECT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehicle = new DataTable();
            dtVehicle = clsDataLayer.ExecuteReader(cmdReadDivision);
            return dtVehicle;
        }
        // This Method will fetch EMPLOYEE details
        public DataTable ReadEmployee(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryReadDivision = "VEHICLE_STATUS_MNGMNT.SP_READ_EMPLOYEE";
            OracleCommand cmdReadDivision = new OracleCommand();
            cmdReadDivision.CommandText = strQueryReadDivision;
            cmdReadDivision.CommandType = CommandType.StoredProcedure;
            cmdReadDivision.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = ObjVehicleStatus.Org_Id;
            cmdReadDivision.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = ObjVehicleStatus.CorporateId;
            cmdReadDivision.Parameters.Add("I_DIVID", OracleDbType.Int32).Value = ObjVehicleStatus.DivisionId;
            cmdReadDivision.Parameters.Add("I_EMPLOY", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehicle = new DataTable();
            dtVehicle = clsDataLayer.ExecuteReader(cmdReadDivision);
            return dtVehicle;
        }

        // This Method will fetch EMPLOYEE details
        public DataTable ReadVehicleStatsType(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryReadDivision = "VEHICLE_STATUS_MNGMNT.SP_READ_VHCL_STS_TYP";
            OracleCommand cmdReadDivision = new OracleCommand();
            cmdReadDivision.CommandText = strQueryReadDivision;
            cmdReadDivision.CommandType = CommandType.StoredProcedure;
            cmdReadDivision.Parameters.Add("I_STSTYP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehicle = new DataTable();
            dtVehicle = clsDataLayer.ExecuteReader(cmdReadDivision);
            return dtVehicle;
        }
        // This Method will fetch EMPLOYEE details
        public DataTable ReadVehicleStats(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryReadStatus = "VEHICLE_STATUS_MNGMNT.SP_READ_VHCL_STATUS";
            OracleCommand cmdReadStatus = new OracleCommand();
            cmdReadStatus.CommandText = strQueryReadStatus;
            cmdReadStatus.CommandType = CommandType.StoredProcedure;
            cmdReadStatus.Parameters.Add("A_ORG", OracleDbType.Int32).Value = ObjVehicleStatus.Org_Id;
            cmdReadStatus.Parameters.Add("A_CORP", OracleDbType.Int32).Value = ObjVehicleStatus.CorporateId;
            cmdReadStatus.Parameters.Add("A_STSTYP", OracleDbType.Int32).Value = ObjVehicleStatus.VehicleStsTyp;
            cmdReadStatus.Parameters.Add("A_STS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehicle = new DataTable();
            dtVehicle = clsDataLayer.ExecuteReader(cmdReadStatus);
            return dtVehicle;
        }

        // This Method adds water card details to the table
        public void AddAssignVehicle(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryAddAssignVehicle = "VEHICLE_STATUS_MNGMNT.SP_INS_ASSIGN_DETAIL";
            using (OracleCommand cmdAddAssign = new OracleCommand())
            {
                cmdAddAssign.CommandText = strQueryAddAssignVehicle;
                cmdAddAssign.CommandType = CommandType.StoredProcedure;
                cmdAddAssign.Parameters.Add("A_NXTNUM", OracleDbType.Int32).Value = ObjVehicleStatus.NextIdForAssign;
                cmdAddAssign.Parameters.Add("A_VHCL", OracleDbType.Int32).Value = ObjVehicleStatus.VehicleId;
                if (ObjVehicleStatus.DivisionId != 0)
                {
                    cmdAddAssign.Parameters.Add("A_CPRDIV", OracleDbType.Int32).Value = ObjVehicleStatus.DivisionId;
                }
                else
                {
                    cmdAddAssign.Parameters.Add("A_CPRDIV", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicleStatus.AssignMode != 0)
                {
                    cmdAddAssign.Parameters.Add("A_ASGNMOD", OracleDbType.Int32).Value = ObjVehicleStatus.AssignMode;
                }
                else
                {
                    cmdAddAssign.Parameters.Add("A_ASGNMOD", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicleStatus.AssignedToUser != 0)
                {
                    cmdAddAssign.Parameters.Add("A_AGNUSER", OracleDbType.Int32).Value = ObjVehicleStatus.AssignedToUser;
                }
                else
                {
                    cmdAddAssign.Parameters.Add("A_AGNUSER", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicleStatus.AssignedToPrjct != 0)
                {
                    cmdAddAssign.Parameters.Add("A_AGNPRJCT", OracleDbType.Int32).Value = ObjVehicleStatus.AssignedToPrjct;
                }
                else
                {
                    cmdAddAssign.Parameters.Add("A_AGNPRJCT", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicleStatus.VehicleStsTyp != 0)
                {
                    cmdAddAssign.Parameters.Add("A_STSTYP", OracleDbType.Int32).Value = ObjVehicleStatus.VehicleStsTyp;
                }
                else
                {
                    cmdAddAssign.Parameters.Add("A_STSTYP", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicleStatus.VehicleSts != 0)
                {
                    cmdAddAssign.Parameters.Add("A_STSID", OracleDbType.Int32).Value = ObjVehicleStatus.VehicleSts;
                }
                else
                {
                    cmdAddAssign.Parameters.Add("A_STSID", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicleStatus.FromDate != DateTime.MinValue)
                {
                    cmdAddAssign.Parameters.Add("A_FROM", OracleDbType.Date).Value = ObjVehicleStatus.FromDate;
                }
                else
                {
                    cmdAddAssign.Parameters.Add("A_FROM", OracleDbType.Date).Value = null;
                }
                if (ObjVehicleStatus.ToDate != DateTime.MinValue)
                {
                    cmdAddAssign.Parameters.Add("A_TO", OracleDbType.Date).Value = ObjVehicleStatus.ToDate;
                }
                else
                {
                    cmdAddAssign.Parameters.Add("A_TO", OracleDbType.Date).Value = null;
                }
                if (ObjVehicleStatus.VehicleAgnDescriptn != "")
                {
                    cmdAddAssign.Parameters.Add("A_DESC", OracleDbType.Varchar2).Value = ObjVehicleStatus.VehicleAgnDescriptn;
                }
                else
                {
                    cmdAddAssign.Parameters.Add("A_DESC", OracleDbType.Varchar2).Value =null;
                }
                cmdAddAssign.Parameters.Add("A_CNFRM", OracleDbType.Int32).Value = ObjVehicleStatus.Cnfrm_Sts;
                cmdAddAssign.Parameters.Add("A_ORG", OracleDbType.Int32).Value = ObjVehicleStatus.Org_Id;
                cmdAddAssign.Parameters.Add("A_CORP", OracleDbType.Int32).Value = ObjVehicleStatus.CorporateId;
                cmdAddAssign.Parameters.Add("A_INSUSERID", OracleDbType.Int32).Value = ObjVehicleStatus.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdAddAssign);
            }
        }

        public void UpdateAssignVehicle(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryUpdateAssignVehicle = "VEHICLE_STATUS_MNGMNT.SP_UPDATE_ASSIGN";
            using (OracleCommand cmdUpdateAssign = new OracleCommand())
            {
                cmdUpdateAssign.CommandText = strQueryUpdateAssignVehicle;
                cmdUpdateAssign.CommandType = CommandType.StoredProcedure;
                cmdUpdateAssign.Parameters.Add("A_ID", OracleDbType.Int32).Value = ObjVehicleStatus.VehAsignId;
                if (ObjVehicleStatus.DivisionId != 0)
                {
                    cmdUpdateAssign.Parameters.Add("A_CPRDIV", OracleDbType.Int32).Value = ObjVehicleStatus.DivisionId;
                }
                else
                {
                    cmdUpdateAssign.Parameters.Add("A_CPRDIV", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicleStatus.AssignMode != 0)
                {
                    cmdUpdateAssign.Parameters.Add("A_ASGNMOD", OracleDbType.Int32).Value = ObjVehicleStatus.AssignMode;
                }
                else
                {
                    cmdUpdateAssign.Parameters.Add("A_ASGNMOD", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicleStatus.AssignedToUser != 0)
                {
                    cmdUpdateAssign.Parameters.Add("A_AGNUSER", OracleDbType.Int32).Value = ObjVehicleStatus.AssignedToUser;
                }
                else
                {
                    cmdUpdateAssign.Parameters.Add("A_AGNUSER", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicleStatus.AssignedToPrjct != 0)
                {
                    cmdUpdateAssign.Parameters.Add("A_AGNPRJCT", OracleDbType.Int32).Value = ObjVehicleStatus.AssignedToPrjct;
                }
                else
                {
                    cmdUpdateAssign.Parameters.Add("A_AGNPRJCT", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicleStatus.VehicleStsTyp != 0)
                {
                    cmdUpdateAssign.Parameters.Add("A_STSTYP", OracleDbType.Int32).Value = ObjVehicleStatus.VehicleStsTyp;
                }
                else
                {
                    cmdUpdateAssign.Parameters.Add("A_STSTYP", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicleStatus.VehicleSts != 0)
                {
                    cmdUpdateAssign.Parameters.Add("A_STSID", OracleDbType.Int32).Value = ObjVehicleStatus.VehicleSts;
                }
                else
                {
                    cmdUpdateAssign.Parameters.Add("A_STSID", OracleDbType.Int32).Value = null;
                }
                if (ObjVehicleStatus.FromDate != DateTime.MinValue)
                {
                    cmdUpdateAssign.Parameters.Add("A_FROM", OracleDbType.Date).Value = ObjVehicleStatus.FromDate;
                }
                else
                {
                    cmdUpdateAssign.Parameters.Add("A_FROM", OracleDbType.Date).Value = null;
                }
                if (ObjVehicleStatus.ToDate != DateTime.MinValue)
                {
                    cmdUpdateAssign.Parameters.Add("A_TO", OracleDbType.Date).Value = ObjVehicleStatus.ToDate;
                }
                else
                {
                    cmdUpdateAssign.Parameters.Add("A_TO", OracleDbType.Date).Value = null;
                }
                if (ObjVehicleStatus.VehicleAgnDescriptn != "")
                {
                    cmdUpdateAssign.Parameters.Add("A_DESC", OracleDbType.Varchar2).Value = ObjVehicleStatus.VehicleAgnDescriptn;
                }
                else
                {
                    cmdUpdateAssign.Parameters.Add("A_DESC", OracleDbType.Varchar2).Value = null;
                }
                cmdUpdateAssign.Parameters.Add("A_UID", OracleDbType.Int32).Value = ObjVehicleStatus.User_Id;
                cmdUpdateAssign.Parameters.Add("A_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();

                clsDataLayer.ExecuteNonQuery(cmdUpdateAssign);
            }
        }

        public void MakeAvailVehicle(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryAddAssignVehicle = "VEHICLE_STATUS_MNGMNT.SP_MAKE_AVAILABLE";
            using (OracleCommand cmdUpdateAssign = new OracleCommand())
            {
                cmdUpdateAssign.CommandText = strQueryAddAssignVehicle;
                cmdUpdateAssign.CommandType = CommandType.StoredProcedure;
                cmdUpdateAssign.Parameters.Add("A_VEHID", OracleDbType.Int32).Value = ObjVehicleStatus.VehicleId;
                cmdUpdateAssign.Parameters.Add("A_UID", OracleDbType.Int32).Value = ObjVehicleStatus.User_Id;
                cmdUpdateAssign.Parameters.Add("A_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdUpdateAssign);
            }
        }
        public void CancelAssignVehicle(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryAddAssignVehicle = "VEHICLE_STATUS_MNGMNT.SP_CANCEL_ASSIGN";
            using (OracleCommand cmdAddAssign = new OracleCommand())
            {
                cmdAddAssign.CommandText = strQueryAddAssignVehicle;
                cmdAddAssign.CommandType = CommandType.StoredProcedure;
                cmdAddAssign.Parameters.Add("A_VEHID", OracleDbType.Int32).Value = ObjVehicleStatus.VehAsignId;
                cmdAddAssign.Parameters.Add("A_RSN", OracleDbType.Varchar2).Value = ObjVehicleStatus.CancelReason;
                cmdAddAssign.Parameters.Add("A_UID", OracleDbType.Int32).Value = ObjVehicleStatus.User_Id;
                cmdAddAssign.Parameters.Add("A_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdAddAssign);
            }
        }

        public void CancelOtherStatus(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryAddAssignVehicle = "VEHICLE_STATUS_MNGMNT.SP_CANCEL_OTHER_STATS";
            using (OracleCommand cmdAddAssign = new OracleCommand())
            {
                cmdAddAssign.CommandText = strQueryAddAssignVehicle;
                cmdAddAssign.CommandType = CommandType.StoredProcedure;
                cmdAddAssign.Parameters.Add("A_VEHID", OracleDbType.Int32).Value = ObjVehicleStatus.VehAsignId;
                cmdAddAssign.Parameters.Add("A_RSN", OracleDbType.Varchar2).Value = ObjVehicleStatus.CancelReason;
                cmdAddAssign.Parameters.Add("A_UID", OracleDbType.Int32).Value = ObjVehicleStatus.User_Id;
                cmdAddAssign.Parameters.Add("A_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdAddAssign);
            }
        }

        // This Method will fetch ASSIGN details BY VEH ID
        public DataTable ReadVehcicleStatusDetail(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryReadStatus = "VEHICLE_STATUS_MNGMNT.SP_READ_STATUS_MNGMNT_BY_VEH";
            OracleCommand cmdReadStatus = new OracleCommand();
            cmdReadStatus.CommandText = strQueryReadStatus;
            cmdReadStatus.CommandType = CommandType.StoredProcedure;
            cmdReadStatus.Parameters.Add("A_ORG", OracleDbType.Int32).Value = ObjVehicleStatus.Org_Id;
            cmdReadStatus.Parameters.Add("A_CORP", OracleDbType.Int32).Value = ObjVehicleStatus.CorporateId;
            cmdReadStatus.Parameters.Add("A_VEHID", OracleDbType.Int32).Value = ObjVehicleStatus.VehicleId;
            cmdReadStatus.Parameters.Add("A_STS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehicle = new DataTable();
            dtVehicle = clsDataLayer.ExecuteReader(cmdReadStatus);
            return dtVehicle;
        }

        // This Method checks water card number in the database for duplication.
        public string CheckDateInAsgn(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {

            string strQueryCheckdate = "VEHICLE_STATUS_MNGMNT.SP_CHECK_DATE";
            OracleCommand cmdCheckDate = new OracleCommand();
            cmdCheckDate.CommandText = strQueryCheckdate;
            cmdCheckDate.CommandType = CommandType.StoredProcedure;
            cmdCheckDate.Parameters.Add("A_FROM", OracleDbType.Date).Value = ObjVehicleStatus.FromDate;
            cmdCheckDate.Parameters.Add("A_TO", OracleDbType.Date).Value = ObjVehicleStatus.ToDate;
            cmdCheckDate.Parameters.Add("A_VEHID", OracleDbType.Int32).Value = ObjVehicleStatus.VehicleId;
            cmdCheckDate.Parameters.Add("A_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckDate);
            string strReturn = cmdCheckDate.Parameters["A_COUNT"].Value.ToString();
            cmdCheckDate.Dispose();
            return strReturn;
        }

        public void CloseVehicleStatus(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryCloseOther = "VEHICLE_STATUS_MNGMNT.SP_CLOSE_STATUS";
            using (OracleCommand cmdCloseOther = new OracleCommand())
            {
                cmdCloseOther.CommandText = strQueryCloseOther;
                cmdCloseOther.CommandType = CommandType.StoredProcedure;
                cmdCloseOther.Parameters.Add("A_STSID", OracleDbType.Int32).Value = ObjVehicleStatus.VehAsignId;
                cmdCloseOther.Parameters.Add("A_UID", OracleDbType.Int32).Value = ObjVehicleStatus.User_Id;
                cmdCloseOther.Parameters.Add("A_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdCloseOther);
            }
        }

        public void ConfirmVehicleStatus(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryCloseOther = "VEHICLE_STATUS_MNGMNT.SP_CONFIRM_STATUS";
            using (OracleCommand cmdCloseOther = new OracleCommand())
            {
                cmdCloseOther.CommandText = strQueryCloseOther;
                cmdCloseOther.CommandType = CommandType.StoredProcedure;
                cmdCloseOther.Parameters.Add("A_STSID", OracleDbType.Int32).Value = ObjVehicleStatus.VehAsignId;
                cmdCloseOther.Parameters.Add("A_UID", OracleDbType.Int32).Value = ObjVehicleStatus.User_Id;
                cmdCloseOther.Parameters.Add("A_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdCloseOther);
            }
        }

        // This Method will fetch ASSIGN details BY VEH ID
        public DataTable ReadStatusNotConfirmBydate(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryReadStatus = "VEHICLE_STATUS_MNGMNT.SP_READ_STATUS_CONFIRM_BY_DATE";
            OracleCommand cmdReadStatus = new OracleCommand();
            cmdReadStatus.CommandText = strQueryReadStatus;
            cmdReadStatus.CommandType = CommandType.StoredProcedure;
            cmdReadStatus.Parameters.Add("A_ORG", OracleDbType.Int32).Value = ObjVehicleStatus.Org_Id;
            cmdReadStatus.Parameters.Add("A_CORP", OracleDbType.Int32).Value = ObjVehicleStatus.CorporateId;
            cmdReadStatus.Parameters.Add("A_STS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehicle = new DataTable();
            dtVehicle = clsDataLayer.ExecuteReader(cmdReadStatus);
            return dtVehicle;
        }

        // This Method will fetch ASSIGN details BY VEH ID
        public DataTable ReadVehicleAssignListById(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryReadStatus = "VEHICLE_STATUS_MNGMNT.SP_READ_VHCL_OTHER_LIST";
            OracleCommand cmdReadStatus = new OracleCommand();
            cmdReadStatus.CommandText = strQueryReadStatus;
            cmdReadStatus.CommandType = CommandType.StoredProcedure;
            cmdReadStatus.Parameters.Add("A_STSTYP", OracleDbType.Int32).Value = ObjVehicleStatus.VehicleStsTyp;
            cmdReadStatus.Parameters.Add("A_ORG", OracleDbType.Int32).Value = ObjVehicleStatus.Org_Id;
            cmdReadStatus.Parameters.Add("A_CORP", OracleDbType.Int32).Value = ObjVehicleStatus.CorporateId;
            cmdReadStatus.Parameters.Add("A_VEHID", OracleDbType.Int32).Value = ObjVehicleStatus.VehicleId;
            cmdReadStatus.Parameters.Add("A_STS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehicle = new DataTable();
            dtVehicle = clsDataLayer.ExecuteReader(cmdReadStatus);
            return dtVehicle;
        }
        // This Method will fetch ASSIGN details BY VEH ID
        public DataTable ReadVehicleOthrStsConfrmList(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryReadStatus = "VEHICLE_STATUS_MNGMNT.SP_RD_OTHR_CNFRM_LIST_BY_VH";
            OracleCommand cmdReadStatus = new OracleCommand();
            cmdReadStatus.CommandText = strQueryReadStatus;
            cmdReadStatus.CommandType = CommandType.StoredProcedure;
            cmdReadStatus.Parameters.Add("A_VEHID", OracleDbType.Int32).Value = ObjVehicleStatus.VehicleId;
            cmdReadStatus.Parameters.Add("A_STS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehicle = new DataTable();
            dtVehicle = clsDataLayer.ExecuteReader(cmdReadStatus);
            return dtVehicle;
        }
        // This Method will fetch ASSIGN details BY VEH ID
        public DataTable ReadVehicleAssignDetailsById(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryReadStatus = "VEHICLE_STATUS_MNGMNT.SP_READ_VHCL_ASGN_DETAIL_BY_ID";
            OracleCommand cmdReadStatus = new OracleCommand();
            cmdReadStatus.CommandText = strQueryReadStatus;
            cmdReadStatus.CommandType = CommandType.StoredProcedure;
            cmdReadStatus.Parameters.Add("A_ID", OracleDbType.Int32).Value = ObjVehicleStatus.VehAsignId;
            cmdReadStatus.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehicle = new DataTable();
            dtVehicle = clsDataLayer.ExecuteReader(cmdReadStatus);
            return dtVehicle;
        }

        // This Method will fetch ASSIGN details BY VEH ID
        public DataTable ReadVehicleAssignForAllocate(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryReadStatus = "VEHICLE_STATUS_MNGMNT.SP_READ_VEHICLE_ASIGN";
            OracleCommand cmdReadStatus = new OracleCommand();
            cmdReadStatus.CommandText = strQueryReadStatus;
            cmdReadStatus.CommandType = CommandType.StoredProcedure;
            cmdReadStatus.Parameters.Add("A_ORG", OracleDbType.Int32).Value = ObjVehicleStatus.Org_Id;
            cmdReadStatus.Parameters.Add("A_CORP", OracleDbType.Int32).Value = ObjVehicleStatus.CorporateId;
            cmdReadStatus.Parameters.Add("I_VEHCLS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehicle = new DataTable();
            dtVehicle = clsDataLayer.ExecuteReader(cmdReadStatus);
            return dtVehicle;
        }
        // This Method will fetch Vehicle nUmber
        public DataTable ReadVehNumber(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryReadVehicle = "VEHICLE_STATUS_MNGMNT.SP_READ_VHCL_NUM";
            OracleCommand cmdReadVehicle = new OracleCommand();
            cmdReadVehicle.CommandText = strQueryReadVehicle;
            cmdReadVehicle.CommandType = CommandType.StoredProcedure;
            cmdReadVehicle.Parameters.Add("I_VEH", OracleDbType.Int32).Value = ObjVehicleStatus.VehicleId;
            cmdReadVehicle.Parameters.Add("I_ASGNID", OracleDbType.Int32).Value = ObjVehicleStatus.VehAsignId;
            cmdReadVehicle.Parameters.Add("OUT_VEH", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehicle = new DataTable();
            dtVehicle = clsDataLayer.ExecuteReader(cmdReadVehicle);
            return dtVehicle;
        }
        public void AutoCloseStatus(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryAllocate = "VEHICLE_STATUS_MNGMNT.SP_AUTOCLOSE_STATUS";
            using (OracleCommand cmdAllocate = new OracleCommand())
            {
                cmdAllocate.CommandText = strQueryAllocate;
                cmdAllocate.CommandType = CommandType.StoredProcedure;
                cmdAllocate.Parameters.Add("A_ASGNID", OracleDbType.Int32).Value = ObjVehicleStatus.VehAsignId;
                cmdAllocate.Parameters.Add("A_USRID", OracleDbType.Int32).Value = ObjVehicleStatus.User_Id;
                cmdAllocate.Parameters.Add("A_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdAllocate);
            }
        }
        // This Method will fetCH Vehicle Number
        public DataTable ReadVehicleNumber(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            string strQueryReadVehicleNumber = "VEHICLE_STATUS_MNGMNT.SP_RD_VEHICLE_NUMBER";
            OracleCommand cmdReadVehicleNumber = new OracleCommand();
            cmdReadVehicleNumber.CommandText = strQueryReadVehicleNumber;
            cmdReadVehicleNumber.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleNumber.Parameters.Add("OP_VEH_NUMBER", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadVehicleNumber);
            return dtCategory;
        }
    }
}
