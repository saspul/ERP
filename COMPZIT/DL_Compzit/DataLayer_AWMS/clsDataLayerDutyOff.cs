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
using CL_Compzit;
// CREATED BY:EVM-0015
// CREATED DATE:05/12/2016
// REVIEWED BY:
// REVIEW DATE:
namespace DL_Compzit.DataLayer_AWMS
{
    public class clsDataLayerDutyOff
    {
        public void AddDutyOffDetails(clsEntityLayerDutyOff objEntitydutyOff)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {


                con.Open();
                tran = con.BeginTransaction();

                clsDataLayer objDataLayer = new clsDataLayer();
                clsEntityCommon objCommon = new clsEntityCommon();
                objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.DUTYOFF);
                objCommon.CorporateID = objEntitydutyOff.Corporate_id;

                string strNextValue = objDataLayer.ReadNextNumberWeb(objCommon, tran, con);
                objEntitydutyOff.OffdutyId = Convert.ToInt32(strNextValue);
                string strQueryReadHol = "DUTY_OFF.SP_INS_DUTYOFF_MASTER";
                using (OracleCommand cmdAddOff = new OracleCommand(strQueryReadHol, con))
                {
                    cmdAddOff.CommandText = strQueryReadHol;
                    cmdAddOff.CommandType = CommandType.StoredProcedure;
                    cmdAddOff.Parameters.Add("D_OFFDUTY_ID", OracleDbType.Int32).Value = objEntitydutyOff.OffdutyId;
                    // cmdAddHol.Parameters.Add("H_STATUS", OracleDbType.Int32).Value = objEntityHol.Status_id;
                    cmdAddOff.Parameters.Add("D_OFFDUTY_STATUS", OracleDbType.Int32).Value = objEntitydutyOff.OffdutyStatus;
                    cmdAddOff.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntitydutyOff.Organisation_id;
                    cmdAddOff.Parameters.Add("D_CORPID", OracleDbType.Int32).Value = objEntitydutyOff.Corporate_id;
                    // cmdAddOff.Parameters.Add("D_USERID", OracleDbType.Int32).Value = objEntitydutyOff.User_Id;



                    cmdAddOff.Parameters.Add("D_OFFDUTY_INS_USR_ID", OracleDbType.Int32).Value = objEntitydutyOff.Inserteduserid;
                    cmdAddOff.Parameters.Add("D_OFFDUTY_INS_DATE", OracleDbType.Date).Value = objEntitydutyOff.Insertedteduserdate;
                    //if (objEntitydutyOff.Updatedteduserid != 0)
                    //{
                    //    cmdAddOff.Parameters.Add("D_OFFDUTY_UPD_USR_ID", OracleDbType.Int32).Value = objEntitydutyOff.Updatedteduserid;
                    //    cmdAddOff.Parameters.Add("D_OFFDUTY_UPD_DATE", OracleDbType.Date).Value = objEntitydutyOff.Updateddate;
                    //}

                    cmdAddOff.ExecuteNonQuery();




                }
                // objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MONTHLY_DUTYOFF);


                // strNextValue = objDataLayer.ReadNextNumberWeb(objCommon, tran, con);


                // objEntitydutyOff.OffdutyId = Convert.ToInt32(strNextValue);
                if (objEntitydutyOff.weeklyOffdutytypeid == 1)
                {
                    string strQueryInsert = "DUTY_OFF.SP_INS_WEEKLYOFFDUTY";
                    using (OracleCommand cmdAddOffWeekly = new OracleCommand(strQueryInsert, con))
                    {
                        cmdAddOffWeekly.CommandText = strQueryInsert;
                        cmdAddOffWeekly.CommandType = CommandType.StoredProcedure;
                        cmdAddOffWeekly.Parameters.Add("D_WK_OFFDUTY_TYP_STATUS", OracleDbType.Int32).Value = objEntitydutyOff.WeeklyOffdutyStatus;
                        // cmdAddHol.Parameters.Add("H_STATUS", OracleDbType.Int32).Value = objEntityHol.Status_id;
                        cmdAddOffWeekly.Parameters.Add("D_WK_OFFDUTYDTL_DAYS", OracleDbType.Varchar2).Value = objEntitydutyOff.weeklyOffdutydays;
                        cmdAddOffWeekly.Parameters.Add("D_WK_OFFDUTY_ID", OracleDbType.Int32).Value = objEntitydutyOff.OffdutyId;
                        //if (objEntitydutyOff.Updatedteduserid != 0)
                        //{
                        //    cmdAddOff.Parameters.Add("D_OFFDUTY_UPD_USR_ID", OracleDbType.Int32).Value = objEntitydutyOff.Updatedteduserid;
                        //    cmdAddOff.Parameters.Add("D_OFFDUTY_UPD_DATE", OracleDbType.Date).Value = objEntitydutyOff.Updateddate;
                        //}

                        cmdAddOffWeekly.ExecuteNonQuery();




                    }
                }

                //monthlydetails
                for (int i = 0; i < 6; i++)
                {
                    if (objEntitydutyOff.monthlydatalist[i]!=null)
                    {
                    objEntitydutyOff.OffdutyDays = objEntitydutyOff.monthlydatalist[i];
                    objEntitydutyOff.MonthlyOffdutyId = int.Parse(objEntitydutyOff.monthlytypelist[i]);

                    // objEntitydutyOff.MonthlyOffdutyId = objEntitydutyOff.monthlydatalist[i];
                    string strQueryInsert1 = "DUTY_OFF.SP_INS_DUTYOFF_DETAILS";
                    using (OracleCommand cmdAddOffWeekly = new OracleCommand(strQueryInsert1, con))
                    {
                        cmdAddOffWeekly.CommandText = strQueryInsert1;
                        cmdAddOffWeekly.CommandType = CommandType.StoredProcedure;
                        cmdAddOffWeekly.Parameters.Add("D_OFFDUTY_ID", OracleDbType.Int32).Value = objEntitydutyOff.OffdutyId;
                        cmdAddOffWeekly.Parameters.Add("D_MN_OFFDUTY_TYP_ID", OracleDbType.Int32).Value = objEntitydutyOff.MonthlyOffdutyId;
                        cmdAddOffWeekly.Parameters.Add("D_OFFDUTYDTL_DAYS", OracleDbType.Varchar2).Value = objEntitydutyOff.OffdutyDays;

                        // cmdAddOffWeekly.Parameters.Add("D_OFFDUTY_ID", OracleDbType.Int32).Value = objEntitydutyOff.OffdutyId;
                        // cmdAddHol.Parameters.Add("H_STATUS", OracleDbType.Int32).Value = objEntityHol.Status_id;
                        //if (objEntitydutyOff.Updatedteduserid != 0)
                        //{
                        //    cmdAddOff.Parameters.Add("D_OFFDUTY_UPD_USR_ID", OracleDbType.Int32).Value = objEntitydutyOff.Updatedteduserid;
                        //    cmdAddOff.Parameters.Add("D_OFFDUTY_UPD_DATE", OracleDbType.Date).Value = objEntitydutyOff.Updateddate;
                        //}

                        cmdAddOffWeekly.ExecuteNonQuery();



                    }
                    }


                }






                tran.Commit();
            }

        }


        //fetch the existing data for load

        public DataTable getdutyoff(clsEntityLayerDutyOff objEntDuty)
        {
            string strQueryReadoffduty = "DUTY_OFF.SP_READ_DUTYOFF_LIST";
            OracleCommand cmdReadoffduty = new OracleCommand();

            cmdReadoffduty.CommandText = strQueryReadoffduty;
            cmdReadoffduty.CommandType = CommandType.StoredProcedure;
            cmdReadoffduty.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntDuty.Organisation_id;
            cmdReadoffduty.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntDuty.Corporate_id;
            cmdReadoffduty.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLoginDetail = new DataTable();
            dtLoginDetail = clsDataLayer.SelectDataTable(cmdReadoffduty);
            return dtLoginDetail;

        }
        public DataTable getmonthlytype()
        {
            string strQueryReadoffTYPE = "DUTY_OFF.SP_READ_DUTYOFF_MNTHLYTYPE";
            OracleCommand cmdReadoffdutytype = new OracleCommand();

            cmdReadoffdutytype.CommandText = strQueryReadoffTYPE;
            cmdReadoffdutytype.CommandType = CommandType.StoredProcedure;
            cmdReadoffdutytype.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLoginDetail = new DataTable();
            dtLoginDetail = clsDataLayer.SelectDataTable(cmdReadoffdutytype);
            return dtLoginDetail;

        }
        public void updatemnthlyoffdetails(clsEntityLayerDutyOff objEntitydutyOff)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {


                con.Open();
                tran = con.BeginTransaction();

                clsDataLayer objDataLayer = new clsDataLayer();
                clsEntityCommon objCommon = new clsEntityCommon();

                objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.DUTYOFF);
                objCommon.CorporateID = objEntitydutyOff.Corporate_id;
                for (int i = 0; i < 6; i++)
                {
                    objEntitydutyOff.OffdutyDays = objEntitydutyOff.monthlydatalist[i];
                    objEntitydutyOff.MonthlyOffdutyId =i+1;

                    string strQueryupdate = "DUTY_OFF.SP_UPDATE_DUTYOFF_DETAILS";
                    using (OracleCommand cmdAddOffmnthly = new OracleCommand(strQueryupdate, con))
                    {
                        cmdAddOffmnthly.CommandText = strQueryupdate;
                        cmdAddOffmnthly.CommandType = CommandType.StoredProcedure;
                        cmdAddOffmnthly.Parameters.Add("O_ID", OracleDbType.Int32).Value = objEntitydutyOff.OffdutyId;
                        cmdAddOffmnthly.Parameters.Add("O_DID", OracleDbType.Int32).Value = objEntitydutyOff.monthlydetailid[i];
                        cmdAddOffmnthly.Parameters.Add("O_DTYPE", OracleDbType.Int32).Value = objEntitydutyOff.monthlytypelist[i];
                        cmdAddOffmnthly.Parameters.Add("O_DAYS", OracleDbType.Varchar2).Value = objEntitydutyOff.OffdutyDays;


                        cmdAddOffmnthly.ExecuteNonQuery();
                    }
                }
                string strQueryupdate1 = "DUTY_OFF.SP_UPDATE_DUTYOFF_MASTER";
                using (OracleCommand cmdAddOffmnthly = new OracleCommand(strQueryupdate1, con))
                {
                    cmdAddOffmnthly.CommandText = strQueryupdate1;
                    cmdAddOffmnthly.CommandType = CommandType.StoredProcedure;
                    cmdAddOffmnthly.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntitydutyOff.Organisation_id;
                    cmdAddOffmnthly.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntitydutyOff.Corporate_id;
                    // cmdAddOff.Parameters.Add("D_USERID", OracleDbType.Int32).Value = objEntitydutyOff.User_Id;
                    cmdAddOffmnthly.Parameters.Add("O_DATE", OracleDbType.Date).Value = objEntitydutyOff.Updateddate;
                    cmdAddOffmnthly.Parameters.Add("O_USERID", OracleDbType.Int32).Value = objEntitydutyOff.Updatedteduserid;


                    cmdAddOffmnthly.ExecuteNonQuery();
                }

                string strQueryupdate2 = "DUTY_OFF.SP_UPDATE_WEEKLYOFFDUTY";
                using (OracleCommand cmdAddOffmnthly = new OracleCommand(strQueryupdate2, con))
                {
                    cmdAddOffmnthly.CommandText = strQueryupdate2;
                    cmdAddOffmnthly.CommandType = CommandType.StoredProcedure;
                    cmdAddOffmnthly.Parameters.Add("O_ID", OracleDbType.Int32).Value = objEntitydutyOff.OffdutyId;

                    cmdAddOffmnthly.Parameters.Add("O_TYPEID", OracleDbType.Int32).Value = objEntitydutyOff.weeklyOffdutytypeid;
                    cmdAddOffmnthly.Parameters.Add("O_DAYS", OracleDbType.Varchar2).Value = objEntitydutyOff.weeklyOffdutydays;

                    cmdAddOffmnthly.ExecuteNonQuery();
                }
                tran.Commit();



            }
        }
        // This Method checks customer name in the database for duplication.
        public string CheckDuplication(clsEntityLayerDutyOff objEntitydutyOff)
        {


            string strQueryCheckCustomerName = "DUTY_OFF.SP_CHECK_DUPLICATE_COMBINATION";
            OracleCommand cmdCheckCustomerName = new OracleCommand();
            cmdCheckCustomerName.CommandText = strQueryCheckCustomerName;
            cmdCheckCustomerName.CommandType = CommandType.StoredProcedure;
            cmdCheckCustomerName.Parameters.Add("C_DUTYID", OracleDbType.Int32).Value = objEntitydutyOff.OffdutyId;
            cmdCheckCustomerName.Parameters.Add("C_DATA", OracleDbType.Varchar2).Value = objEntitydutyOff.OffdutyDays;
            cmdCheckCustomerName.Parameters.Add("C_TYPID", OracleDbType.Int32).Value = objEntitydutyOff.MonthlyOffdutyId;
          
            cmdCheckCustomerName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCustomerName);
            string strReturn = cmdCheckCustomerName.Parameters["C_COUNT"].Value.ToString();
            cmdCheckCustomerName.Dispose();
            return strReturn;
        }
    
    
    
    }
}
