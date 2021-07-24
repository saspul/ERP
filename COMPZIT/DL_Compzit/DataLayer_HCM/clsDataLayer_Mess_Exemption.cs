using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_HCM;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayer_Mess_Exemption
    {
        //method to read employee
        public DataTable ReadEmployee(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            string strQueryReadEmp = "MESS_EXCEPTION.SP_READ_USERS";
            using (OracleCommand cmdReadEmp = new OracleCommand())
            {
                cmdReadEmp.CommandText = strQueryReadEmp;
                cmdReadEmp.CommandType = CommandType.StoredProcedure;
                cmdReadEmp.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityMessExcept.Organisation_Id;
                cmdReadEmp.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityMessExcept.CorpOffice_Id;
                cmdReadEmp.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadEmp);
                return dtCust;
            }
        }
        //metghod to read accomodation
        public DataTable ReadAccomodation(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            string strQueryReadAcco = "MESS_EXCEPTION.SP_READ_ACCOMODATION";
            using (OracleCommand cmdReadAcco = new OracleCommand())
            {
                cmdReadAcco.CommandText = strQueryReadAcco;
                cmdReadAcco.CommandType = CommandType.StoredProcedure;
                cmdReadAcco.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityMessExcept.Organisation_Id;
                cmdReadAcco.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityMessExcept.CorpOffice_Id;
                cmdReadAcco.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadAcco);
                return dtCust;
            }
        }
        //to read mess exception
        public DataTable ReadMessException_List(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            string strQueryReadEx = "MESS_EXCEPTION.SP_READ_EXCEPT_LIST";
            using (OracleCommand cmdReadEx = new OracleCommand())
            {
                cmdReadEx.CommandText = strQueryReadEx;
                cmdReadEx.CommandType = CommandType.StoredProcedure;
                if (objEntityMessExcept.Fromdate != DateTime.MinValue)
                    cmdReadEx.Parameters.Add("E_FROM", OracleDbType.Date).Value = objEntityMessExcept.Fromdate;
                else
                    cmdReadEx.Parameters.Add("E_FROM", OracleDbType.Date).Value = null;
                if (objEntityMessExcept.Todate != DateTime.MinValue)
                    cmdReadEx.Parameters.Add("E_TO", OracleDbType.Date).Value = objEntityMessExcept.Todate;
                else
                    cmdReadEx.Parameters.Add("E_TO", OracleDbType.Date).Value = null;

                cmdReadEx.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityMessExcept.EmpId;
                cmdReadEx.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityMessExcept.Organisation_Id;
                cmdReadEx.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityMessExcept.CorpOffice_Id;
                cmdReadEx.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadEx);
                return dtCust;
            }
        }
        //read mess exception data by id
        public DataTable ReadMessExceptionData_ById(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            string strQueryReadData = "MESS_EXCEPTION.SP_READ_EXCEPT_DATA_BYID";
            using (OracleCommand cmdReadData = new OracleCommand())
            {
                cmdReadData.CommandText = strQueryReadData;
                cmdReadData.CommandType = CommandType.StoredProcedure;
                cmdReadData.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityMessExcept.Organisation_Id;
                cmdReadData.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityMessExcept.CorpOffice_Id;
                cmdReadData.Parameters.Add("E_EXPT_ID", OracleDbType.Int32).Value = objEntityMessExcept.MessexceptId;
                cmdReadData.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadData);
                return dtCust;
            }
        }
      //to insert mess exception deatils
        public void InsertMessExcept(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            string strQueryInsertEx = "MESS_EXCEPTION.SP_INSERT_MESSEX";
            OracleCommand cmdInsertEx = new OracleCommand();
            cmdInsertEx.CommandText = strQueryInsertEx;
            cmdInsertEx.CommandType = CommandType.StoredProcedure;
            cmdInsertEx.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityMessExcept.Organisation_Id;
            cmdInsertEx.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityMessExcept.CorpOffice_Id;
            cmdInsertEx.Parameters.Add("E_FROM", OracleDbType.Date).Value = objEntityMessExcept.Fromdate;
            cmdInsertEx.Parameters.Add("E_TO", OracleDbType.Date).Value = objEntityMessExcept.Todate;
            cmdInsertEx.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityMessExcept.EmpId;
            cmdInsertEx.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityMessExcept.User_Id;
            clsDataLayer.ExecuteNonQuery(cmdInsertEx);
        }
        //update mess exception details
        public void UpdateMessExcept(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            string strQueryUpdateEx = "MESS_EXCEPTION.SP_UPDATE_MESSEX";
            OracleCommand cmdUpdateEx = new OracleCommand();
            cmdUpdateEx.CommandText = strQueryUpdateEx;
            cmdUpdateEx.CommandType = CommandType.StoredProcedure;
            cmdUpdateEx.Parameters.Add("E_EXPT_ID", OracleDbType.Int32).Value = objEntityMessExcept.MessexceptId;
            cmdUpdateEx.Parameters.Add("E_FROM", OracleDbType.Date).Value = objEntityMessExcept.Fromdate;
            cmdUpdateEx.Parameters.Add("E_TO", OracleDbType.Date).Value = objEntityMessExcept.Todate;
            cmdUpdateEx.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityMessExcept.User_Id;
            clsDataLayer.ExecuteNonQuery(cmdUpdateEx);
        }
        //read mess Employee data by ACCOMODATION Id


        //evm-0023
        public DataTable ReadEmployee_ByAccoId(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            string strQueryReadData = "MESS_EXCEPTION.SP_READ_EMP_DATA_BY_ACCID";
            using (OracleCommand cmdReadData = new OracleCommand())
            {
                cmdReadData.CommandText = strQueryReadData;
                cmdReadData.CommandType = CommandType.StoredProcedure;
                cmdReadData.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityMessExcept.Organisation_Id;
                cmdReadData.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityMessExcept.CorpOffice_Id;
                cmdReadData.Parameters.Add("E_FROM", OracleDbType.Date).Value = objEntityMessExcept.Fromdate;
                cmdReadData.Parameters.Add("E_TO", OracleDbType.Date).Value = objEntityMessExcept.Todate;
                cmdReadData.Parameters.Add("E_ACC_ID", OracleDbType.Int32).Value = objEntityMessExcept.AccomoDationId;
                cmdReadData.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadData);
                return dtCust;
            }
        }


        //public DataTable ReadEmployee_ByAccoId(clsEntity_Mess_Exemption objEntityMessExcept)
        //{
        //    string strQueryReadData = "MESS_EXCEPTION.SP_READ_EMP_DATA_BY_ACCID";
        //    using (OracleCommand cmdReadData = new OracleCommand())
        //    {
        //        cmdReadData.CommandText = strQueryReadData;
        //        cmdReadData.CommandType = CommandType.StoredProcedure;
        //        cmdReadData.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityMessExcept.Organisation_Id;
        //        cmdReadData.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityMessExcept.CorpOffice_Id;
        //        cmdReadData.Parameters.Add("E_ACC_ID", OracleDbType.Int32).Value = objEntityMessExcept.AccomoDationId;
        //        cmdReadData.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

        //        DataTable dtCust = new DataTable();
        //        dtCust = clsDataLayer.ExecuteReader(cmdReadData);
        //        return dtCust;
        //    }
        //}


        //To read the divisions of an employee
        public DataTable ReadDivisionOfEmp(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            string strQueryReadRound = "MESS_EXCEPTION.SP_READ_DIV_BY_EMP";
            OracleCommand cmdReadRound = new OracleCommand();
            cmdReadRound.CommandText = strQueryReadRound;
            cmdReadRound.CommandType = CommandType.StoredProcedure;
            cmdReadRound.Parameters.Add("I_EMP", OracleDbType.Int32).Value = objEntityMessExcept.EmpId;
            cmdReadRound.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRound);
            return dtCategory;
        }
        //To read the DATA of an employee
        public DataTable ReadEmpDetailById(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            string strQueryReadRound = "MESS_EXCEPTION.SP_READ_EMP_BYID";
            OracleCommand cmdReadRound = new OracleCommand();
            cmdReadRound.CommandText = strQueryReadRound;
            cmdReadRound.CommandType = CommandType.StoredProcedure;
            cmdReadRound.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityMessExcept.Organisation_Id;
            cmdReadRound.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityMessExcept.CorpOffice_Id;
            cmdReadRound.Parameters.Add("I_EMP", OracleDbType.Int32).Value = objEntityMessExcept.EmpId;
            cmdReadRound.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRound);
            return dtCategory;
        }
        //To check duplication in mess exemption
        public DataTable CheckDuplication(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            string strQueryReadDup = "MESS_EXCEPTION.SP_CHECK_DUPLICATION";
            OracleCommand cmdReadDup = new OracleCommand();
            cmdReadDup.CommandText = strQueryReadDup;
            cmdReadDup.CommandType = CommandType.StoredProcedure;
            cmdReadDup.Parameters.Add("I_EMP", OracleDbType.Int32).Value = objEntityMessExcept.EmpId;
            cmdReadDup.Parameters.Add("E_FROM", OracleDbType.Date).Value = objEntityMessExcept.Fromdate;
            cmdReadDup.Parameters.Add("E_TO", OracleDbType.Date).Value = objEntityMessExcept.Todate;
            cmdReadDup.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadDup);
            return dtCategory;
        }


        //evm-0023

        public DataTable ReadCurrentMess(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            string strQueryReadDup = "MESS_BILL.SP_READ_MESS_CURRENT";
            OracleCommand cmdReadDup = new OracleCommand();
            cmdReadDup.CommandText = strQueryReadDup;
            cmdReadDup.CommandType = CommandType.StoredProcedure;
            cmdReadDup.Parameters.Add("E_EMP_ID", OracleDbType.Int32).Value = objEntityMessExcept.EmpId;
            cmdReadDup.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadDup);
            return dtCategory;
        }

        public DataTable ReadMessBackup(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            string strQueryReadDup = "MESS_BILL.SP_READ_MESS_BACKUP";
            OracleCommand cmdReadDup = new OracleCommand();
            cmdReadDup.CommandText = strQueryReadDup;
            cmdReadDup.CommandType = CommandType.StoredProcedure;
            cmdReadDup.Parameters.Add("E_EMP_ID", OracleDbType.Int32).Value = objEntityMessExcept.EmpId;
            cmdReadDup.Parameters.Add("E_ACC", OracleDbType.Int32).Value = objEntityMessExcept.AccomoDationId;
            cmdReadDup.Parameters.Add("E_DATE", OracleDbType.Date).Value = objEntityMessExcept.Fromdate;
            cmdReadDup.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadDup);
            return dtCategory;
        }

    }
}
