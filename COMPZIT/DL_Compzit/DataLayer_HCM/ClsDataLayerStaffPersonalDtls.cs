using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit;
namespace DL_Compzit.DataLayer_HCM
{

    public class ClsDataLayerStaffPersonalDtls
    {

        public void insertPersonalDtls(clsEntityStaffPersonalDtls objEntityPersonalDtls)
        {
            string strQueryAddPersnlDtls = "STAFF_PERSONAL_DETAILS.SP_INS_STAFF_PERSNL_DETAILS";
            using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
            {
                cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
                cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
                cmdAddPersnlDtls.Parameters.Add("P_CND_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.CandidadteId;
                cmdAddPersnlDtls.Parameters.Add("P_STAFFPR_NAME", OracleDbType.Varchar2).Value = objEntityPersonalDtls.StaffName;
                cmdAddPersnlDtls.Parameters.Add("P_STAFFLCLCONTACT", OracleDbType.Varchar2).Value = objEntityPersonalDtls.LocalContact;
                cmdAddPersnlDtls.Parameters.Add("P_STAFFTELEPHN", OracleDbType.Varchar2).Value = objEntityPersonalDtls.TelaephoneNmbr;
                cmdAddPersnlDtls.Parameters.Add("P_STAFFMAIL", OracleDbType.Varchar2).Value = objEntityPersonalDtls.emailid;
                if (objEntityPersonalDtls.country == 0)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_STAFFCOUNTRY", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_STAFFCOUNTRY", OracleDbType.Int32).Value = objEntityPersonalDtls.country;
                }
                cmdAddPersnlDtls.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPersonalDtls.OrgId;
                cmdAddPersnlDtls.Parameters.Add("P_CORP_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.corpId;
                cmdAddPersnlDtls.Parameters.Add("P_INSUSRID", OracleDbType.Int32).Value = objEntityPersonalDtls.UserId;
                cmdAddPersnlDtls.Parameters.Add("P_INSDATE", OracleDbType.Date).Value = objEntityPersonalDtls.Date;
                if(objEntityPersonalDtls.designationId==0){
                    cmdAddPersnlDtls.Parameters.Add("P_DESIG_ID", OracleDbType.Int32).Value = null; ;
             

                }
                else
                cmdAddPersnlDtls.Parameters.Add("P_DESIG_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.designationId;

                if (objEntityPersonalDtls.crprtdivision == 0)
                {
                    cmdAddPersnlDtls.Parameters.Add("P_DIV_ID", OracleDbType.Int32).Value = null; ;


                }
                else
                cmdAddPersnlDtls.Parameters.Add("P_DIV_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.crprtdivision;
                cmdAddPersnlDtls.Parameters.Add("FIRSTNM", OracleDbType.Varchar2).Value = objEntityPersonalDtls.Firstname;


                cmdAddPersnlDtls.Parameters.Add("MIDDLENM", OracleDbType.Varchar2).Value = objEntityPersonalDtls.Middlename;
                cmdAddPersnlDtls.Parameters.Add("LASTNM", OracleDbType.Varchar2).Value = objEntityPersonalDtls.Lastname;


                if (objEntityPersonalDtls.FileName != "")
                {
                    cmdAddPersnlDtls.Parameters.Add("P_FILENAME", OracleDbType.Varchar2).Value = objEntityPersonalDtls.FileName;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_FILENAME", OracleDbType.Varchar2).Value = null;
                }
                if (objEntityPersonalDtls.FileNameAct != "")
                {
                    cmdAddPersnlDtls.Parameters.Add("P_FILEACT", OracleDbType.Varchar2).Value = objEntityPersonalDtls.FileNameAct;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("P_FILEACT", OracleDbType.Varchar2).Value = null;
                }


                clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
            }
        }







        public DataTable ReadDivision(clsEntityStaffPersonalDtls objEntityPersonalDtls)
        {
            string strQueryReadProj = "STAFF_PERSONAL_DETAILS.SP_READ_DIVISION";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPersonalDtls.UserId;
                cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPersonalDtls.OrgId;
                cmdReadProj.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPersonalDtls.corpId;


                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable ReadDesignation(clsEntityStaffPersonalDtls objEntityPersonalDtls)
        {
            string strQueryReadProj = "STAFF_PERSONAL_DETAILS.SP_READ_DSGN_BY_USRID";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPersonalDtls.UserId;
                cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPersonalDtls.OrgId;
                cmdReadProj.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPersonalDtls.corpId;
                cmdReadProj.Parameters.Add("P_DIV_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.designationId;
                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }



        public DataTable ReadCountryList()
        {
            DataTable dtCountryList = new DataTable();
            using (OracleCommand cmdReadCountryList = new OracleCommand())
            {
                cmdReadCountryList.CommandText = "STAFF_PERSONAL_DETAILS.SP_READ_GEN_COUNTRY_MSTR";
                cmdReadCountryList.CommandType = CommandType.StoredProcedure;
                cmdReadCountryList.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtCountryList = clsDataLayer.SelectDataTable(cmdReadCountryList);
            }
            return dtCountryList;

        }



        public DataTable ReadPersonalDetailsId(clsEntityStaffPersonalDtls objEntityPersonalDtls)
        {
            string strQueryReadUsers = "STAFF_PERSONAL_DETAILS.SP_READ_PERSONALDTLS_BYID";
            using (OracleCommand cmdReadManpower = new OracleCommand())
            {
                cmdReadManpower.CommandText = strQueryReadUsers;
                cmdReadManpower.CommandType = CommandType.StoredProcedure;
                cmdReadManpower.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPersonalDtls.OrgId;

                cmdReadManpower.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPersonalDtls.corpId;
                cmdReadManpower.Parameters.Add("P_CND_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.CandidadteId;
                cmdReadManpower.Parameters.Add("P_DSGN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadManpower);
                return dtCust;
            }
        }


        public void UpdatepersonalDetails(clsEntityStaffPersonalDtls objEntityPersonalDtls)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();

                //generate next value
                tran = con.BeginTransaction();

                try
                {

                    string strQueryAddManpowerRqrmnt = "STAFF_PERSONAL_DETAILS.SP_UPD_STAFF_PERSNL_DETAILS";
                    using (OracleCommand cmdAddManpowerRqrmnt = new OracleCommand(strQueryAddManpowerRqrmnt, con))
                    {

                        cmdAddManpowerRqrmnt.CommandType = CommandType.StoredProcedure;



                        cmdAddManpowerRqrmnt.Transaction = tran;

                        cmdAddManpowerRqrmnt.Parameters.Add("P_STAFF_PR_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.StaffId;


                        cmdAddManpowerRqrmnt.Parameters.Add("P_CND_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.CandidadteId;
                        cmdAddManpowerRqrmnt.Parameters.Add("P_STAFFPR_NAME", OracleDbType.Varchar2).Value = objEntityPersonalDtls.StaffName;

                        cmdAddManpowerRqrmnt.Parameters.Add("P_STAFFLCLCONTACT", OracleDbType.Varchar2).Value = objEntityPersonalDtls.LocalContact;



                        cmdAddManpowerRqrmnt.Parameters.Add("P_STAFFTELEPHN", OracleDbType.Varchar2).Value = objEntityPersonalDtls.TelaephoneNmbr;

                        cmdAddManpowerRqrmnt.Parameters.Add("P_STAFFMAIL", OracleDbType.Varchar2).Value = objEntityPersonalDtls.emailid;



                        if (objEntityPersonalDtls.country == 0)
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("P_STAFFCOUNTRY", OracleDbType.Int32).Value = null;
                        }
                        else
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("P_STAFFCOUNTRY", OracleDbType.Int32).Value = objEntityPersonalDtls.country;


                        }



                        cmdAddManpowerRqrmnt.Parameters.Add("P_UPUSRID", OracleDbType.Varchar2).Value = objEntityPersonalDtls.UserId;

                        cmdAddManpowerRqrmnt.Parameters.Add("P_UPDATE", OracleDbType.Date).Value = objEntityPersonalDtls.Date;


                        if (objEntityPersonalDtls.designationId == 0)
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("P_DESIG_ID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("P_DESIG_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.designationId;


                        }
                        if (objEntityPersonalDtls.crprtdivision == 0)
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("P_DIV_ID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {

                            cmdAddManpowerRqrmnt.Parameters.Add("P_DIV_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.crprtdivision;


                        }
                        cmdAddManpowerRqrmnt.Parameters.Add("P_FIRSTNM", OracleDbType.Varchar2).Value = objEntityPersonalDtls.Firstname;
                        cmdAddManpowerRqrmnt.Parameters.Add("P_MIDDLENM", OracleDbType.Varchar2).Value = objEntityPersonalDtls.Middlename;
                        cmdAddManpowerRqrmnt.Parameters.Add("P_LASTNM", OracleDbType.Varchar2).Value = objEntityPersonalDtls.Lastname;


                        if (objEntityPersonalDtls.FileName != "")
                        {
                            cmdAddManpowerRqrmnt.Parameters.Add("P_FILENAME", OracleDbType.Varchar2).Value = objEntityPersonalDtls.FileName;
                        }
                        else
                        {
                            cmdAddManpowerRqrmnt.Parameters.Add("P_FILENAME", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityPersonalDtls.FileNameAct != "")
                        {
                            cmdAddManpowerRqrmnt.Parameters.Add("P_FILEACT", OracleDbType.Varchar2).Value = objEntityPersonalDtls.FileNameAct;
                        }
                        else
                        {
                            cmdAddManpowerRqrmnt.Parameters.Add("P_FILEACT", OracleDbType.Varchar2).Value = null;
                        }


                        clsDataLayer.ExecuteNonQuery(cmdAddManpowerRqrmnt);
                    }
                    tran.Commit();
                }

                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;
                }
            }
        }
    }
}
                  
   


            
        
    

    

