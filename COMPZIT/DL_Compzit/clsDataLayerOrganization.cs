using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using EL_Compzit;

namespace DL_Compzit
{
    public class clsDataLayerOrganization
    {
        
            //Method for obtaining organisation's basic details .
            public DataTable OrgDetails(clsEntityOrganization objEntityOrg)
            {
                string strQueryCheckOrg = "ORGANIZATION.SP_READ_ORG_DETAIL";
                using (OracleCommand cmdCheckOrg = new OracleCommand())
                {
                    cmdCheckOrg.CommandText = strQueryCheckOrg;
                    cmdCheckOrg.CommandType = CommandType.StoredProcedure;
                    cmdCheckOrg.Parameters.Add("ORG_ID", OracleDbType.Int32).Value = objEntityOrg.OrgId;
                    cmdCheckOrg.Parameters.Add("O_ORG", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    DataTable dtCheckOrg = new DataTable();
                    dtCheckOrg = clsDataLayer.SelectDataTable(cmdCheckOrg);
                    return dtCheckOrg;
                }
            }
        //method for reading organization category.
            public DataTable OrgType(clsEntityOrganization objEntityOrg)
            {
                string strQueryCheckOrg = "ORGANIZATION.SP_READ_ORG_CAT_BYID";
                using (OracleCommand cmdCheckOrg = new OracleCommand())
                {
                    cmdCheckOrg.CommandText = strQueryCheckOrg;
                    cmdCheckOrg.CommandType = CommandType.StoredProcedure;
                    cmdCheckOrg.Parameters.Add("ORG_ID", OracleDbType.Int32).Value = objEntityOrg.OrgTypeId;
                    cmdCheckOrg.Parameters.Add("O_ORG", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    DataTable dtCheckOrg = new DataTable();
                    dtCheckOrg = clsDataLayer.SelectDataTable(cmdCheckOrg);
                    return dtCheckOrg;
                }
            }
            //method for reading contry.
            public DataTable OrgContry(clsEntityOrganization objEntityOrg)
            {
                string strQueryCheckOrg = "ORGANIZATION.SP_READ_COUNTRY_BYID";
                using (OracleCommand cmdCheckOrg = new OracleCommand())
                {
                    cmdCheckOrg.CommandText = strQueryCheckOrg;
                    cmdCheckOrg.CommandType = CommandType.StoredProcedure;
                    cmdCheckOrg.Parameters.Add("CONTRY_ID", OracleDbType.Int32).Value = objEntityOrg.CountryId;
                    cmdCheckOrg.Parameters.Add("O_ORG", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    DataTable dtCheckOrg = new DataTable();
                    dtCheckOrg = clsDataLayer.SelectDataTable(cmdCheckOrg);
                    return dtCheckOrg;
                }
            }
            //method for reading state.
            public DataTable OrgState(clsEntityOrganization objEntityOrg)
            {
                string strQueryCheckOrg = "ORGANIZATION.SP_READ_STATE";
                using (OracleCommand cmdCheckOrg = new OracleCommand())
                {
                    cmdCheckOrg.CommandText = strQueryCheckOrg;
                    cmdCheckOrg.CommandType = CommandType.StoredProcedure;
                    cmdCheckOrg.Parameters.Add("S_STATEID", OracleDbType.Int32).Value = objEntityOrg.StateId;
                    cmdCheckOrg.Parameters.Add("O_ORG", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    DataTable dtCheckOrg = new DataTable();
                    dtCheckOrg = clsDataLayer.SelectDataTable(cmdCheckOrg);
                    return dtCheckOrg;
                }
            }
        //method for reading city.
            public DataTable OrgCity(clsEntityOrganization objEntityOrg)
            {
                string strQueryCheckOrg = "ORGANIZATION.SP_READ_CITY";
                using (OracleCommand cmdCheckOrg = new OracleCommand())
                {
                    cmdCheckOrg.CommandText = strQueryCheckOrg;
                    cmdCheckOrg.CommandType = CommandType.StoredProcedure;
                    cmdCheckOrg.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = objEntityOrg.CityId;
                    cmdCheckOrg.Parameters.Add("O_ORG", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    DataTable dtCheckOrg = new DataTable();
                    dtCheckOrg = clsDataLayer.SelectDataTable(cmdCheckOrg);
                    return dtCheckOrg;
                }
            }
            //method for reading licence pack
            public DataTable OrgLicPack(clsEntityOrganization objEntityOrg)
            {
                string strQueryCheckOrg = "ORGANIZATION.SP_READ_LICENSEPACK_BYID";
                using (OracleCommand cmdCheckOrg = new OracleCommand())
                {
                    cmdCheckOrg.CommandText = strQueryCheckOrg;
                    cmdCheckOrg.CommandType = CommandType.StoredProcedure;
                    cmdCheckOrg.Parameters.Add("LIC_ID", OracleDbType.Int32).Value = objEntityOrg.LicPacId;
                    cmdCheckOrg.Parameters.Add("O_ORG", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    DataTable dtCheckOrg = new DataTable();
                    dtCheckOrg = clsDataLayer.SelectDataTable(cmdCheckOrg);
                    return dtCheckOrg;
                }
            }
        //method for reading corporate pack
            public DataTable OrgCorpPack(clsEntityOrganization objEntityOrg)
            {
                string strQueryCheckOrg = "ORGANIZATION.SP_READ_CORPORATEPACK_BYID";
                using (OracleCommand cmdCheckOrg = new OracleCommand())
                {
                    cmdCheckOrg.CommandText = strQueryCheckOrg;
                    cmdCheckOrg.CommandType = CommandType.StoredProcedure;
                    cmdCheckOrg.Parameters.Add("CORP_ID", OracleDbType.Int32).Value = objEntityOrg.CorPacId;
                    cmdCheckOrg.Parameters.Add("O_ORG", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    DataTable dtCheckOrg = new DataTable();
                    dtCheckOrg = clsDataLayer.SelectDataTable(cmdCheckOrg);
                    return dtCheckOrg;
                }
            }
            //EVM-0016
        //method for updating organization details in to database.
            public void AddOrgDetails(clsEntityOrganization objEntityOrganization, List<clsEntityAttachment> objEntityAttchmntDeatilsList)
            {
                 OracleTransaction tran;
             using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
             {
                 con.Open();
                 tran = con.BeginTransaction();
                 try
                    {
                string strQueryUpdVehicle = "ORGANIZATION.SP_UPDATE_ORG_DETAILS";
                using (OracleCommand cmdUpdOrgDetail = new OracleCommand(strQueryUpdVehicle,con))
              {
                  cmdUpdOrgDetail.CommandText = strQueryUpdVehicle;
                  cmdUpdOrgDetail.CommandType = CommandType.StoredProcedure;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_ID", OracleDbType.Int32).Value = objEntityOrganization.NextId;
                  cmdUpdOrgDetail.Parameters.Add("U_ORGCITY_ID", OracleDbType.Int32).Value = objEntityOrganization.OrgTypeId;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_NAME", OracleDbType.Varchar2).Value = objEntityOrganization.Organisation_Name;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_ADD1", OracleDbType.Varchar2).Value = objEntityOrganization.Address1;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_ADD2", OracleDbType.Varchar2).Value = objEntityOrganization.Address2;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_ADD3", OracleDbType.Varchar2).Value = objEntityOrganization.Address3;
                  cmdUpdOrgDetail.Parameters.Add("U_CNTRY_ID", OracleDbType.Int32).Value = objEntityOrganization.CountryId;
                  cmdUpdOrgDetail.Parameters.Add("U_STATE_ID", OracleDbType.Int32).Value = objEntityOrganization.StateId;
                  cmdUpdOrgDetail.Parameters.Add("U_CITY_ID", OracleDbType.Int32).Value = objEntityOrganization.CityId;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_ZIP", OracleDbType.Varchar2).Value = objEntityOrganization.ZipCode;
                  cmdUpdOrgDetail.Parameters.Add("U_PRG_PHONE", OracleDbType.Varchar2).Value = objEntityOrganization.Phone_Number;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_MOBIL", OracleDbType.Varchar2).Value = objEntityOrganization.Mobile_Number;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_WEB", OracleDbType.Varchar2).Value = objEntityOrganization.Web_Address;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_EMAIL", OracleDbType.Varchar2).Value = objEntityOrganization.Email_Address;
                  cmdUpdOrgDetail.Parameters.Add("U_LIC_PACK_ID", OracleDbType.Int32).Value = objEntityOrganization.LicPacId;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_LIC_CONT", OracleDbType.Int32).Value = objEntityOrganization.LicPacCount;
                  cmdUpdOrgDetail.Parameters.Add("U_CORP_PACK_ID", OracleDbType.Int32).Value = objEntityOrganization.CorPacId;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_CORP_COUNT", OracleDbType.Int32).Value = objEntityOrganization.CorPacCount;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_CR_NUM", OracleDbType.Varchar2).Value = objEntityOrganization.CRnumber;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_CR_EX_DATE", OracleDbType.Date).Value = objEntityOrganization.CrNumExpDate;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_CR_ISSU_DATE", OracleDbType.Date).Value = objEntityOrganization.CrNumIssueDate;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_TX_NUM", OracleDbType.Varchar2).Value = objEntityOrganization.TxNumber;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_TX_EX_DATE", OracleDbType.Date).Value = objEntityOrganization.TxNumExpDate;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_TX_ISSU_DATE", OracleDbType.Date).Value = objEntityOrganization.TxNumIssueDate;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_COMP_NUM", OracleDbType.Varchar2).Value = objEntityOrganization.CompNumber;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_COMP_EX_DATE", OracleDbType.Date).Value = objEntityOrganization.CompNumExpDate;
                  cmdUpdOrgDetail.Parameters.Add("U_ORG_COMP_ISSU_DATE", OracleDbType.Date).Value = objEntityOrganization.CompNumIssueDate;
                  cmdUpdOrgDetail.ExecuteNonQuery();
                 }
              foreach (clsEntityAttachment objAttchDetail in objEntityAttchmntDeatilsList)
              {
                  string strQueryInsertAtcmntDtls = "ORGANIZATION.SP_INS_ORG_ATCHMNT_DTLS";
                  using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls,con))
                  {


                      cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                      cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                      cmdInsertAtcmntDtls.Parameters.Add("IN_ORG_ID", OracleDbType.Int32).Value = objAttchDetail.OrgId;
                      cmdInsertAtcmntDtls.Parameters.Add("IN_ORGFLS_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                      cmdInsertAtcmntDtls.Parameters.Add("IN_ORGFLS_FLNM_ACT", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                      cmdInsertAtcmntDtls.Parameters.Add("IN_ORGFLS_SLNUM", OracleDbType.Int32).Value = objAttchDetail.RnwlAttchmntSlNumber;
                      cmdInsertAtcmntDtls.Parameters.Add("IN_ORGFLS_DSCRPTN", OracleDbType.Varchar2).Value = objAttchDetail.Description;
                      cmdInsertAtcmntDtls.Parameters.Add("IN_ORGROLE_ID", OracleDbType.Int32).Value = objAttchDetail.CardRol;
                      cmdInsertAtcmntDtls.ExecuteNonQuery();
                  }
              }
              string strQueryUpdatePwd = "ORGANIZATION.SP_UPDATE_PASSWORD";
              if (objEntityOrganization.Password != null && objEntityOrganization.Password !="")
              {
                  using (OracleCommand cmdUpdOrgDetail = new OracleCommand(strQueryUpdatePwd,con))
                  {
                      cmdUpdOrgDetail.CommandText = strQueryUpdatePwd;
                      cmdUpdOrgDetail.CommandType = CommandType.StoredProcedure;
                      cmdUpdOrgDetail.Parameters.Add("U_ORG_ID", OracleDbType.Int32).Value = objEntityOrganization.NextId;
                      cmdUpdOrgDetail.Parameters.Add("U_USR_ID", OracleDbType.Int32).Value = objEntityOrganization.UserId;
                      cmdUpdOrgDetail.Parameters.Add("U_PASSWD", OracleDbType.Varchar2).Value = objEntityOrganization.Password;
                      cmdUpdOrgDetail.ExecuteNonQuery();
                  }
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
        //EVM-0016
        //method for reading card details.
            public DataTable OrgCrCard(clsEntityOrganization objEntityOrg)
            {
                string strQueryCheckOrg = "ORGANIZATION.SP_READ_CR_ATCHMNT";
                using (OracleCommand cmdCheckOrg = new OracleCommand())
                {
                    cmdCheckOrg.CommandText = strQueryCheckOrg;
                    cmdCheckOrg.CommandType = CommandType.StoredProcedure;
                    cmdCheckOrg.Parameters.Add("CORP_ID", OracleDbType.Int32).Value = objEntityOrg.OrgId;
                    cmdCheckOrg.Parameters.Add("ROLL_ID", OracleDbType.Int32).Value = objEntityOrg.CrRoll;
                    cmdCheckOrg.Parameters.Add("O_ORG", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    DataTable dtCheckOrg = new DataTable();
                    dtCheckOrg = clsDataLayer.SelectDataTable(cmdCheckOrg);
                    return dtCheckOrg;
                }
            }
        //method for deleting file attachment.
            public void DeletAttachment(List<clsEntityAttachment> objEntityPerDeleteAttchmntDeatilsList)
            {
                foreach (clsEntityAttachment objAttchDetail in objEntityPerDeleteAttchmntDeatilsList)
                {
                    string strQueryInsertAtcmntDtls = "ORGANIZATION.SP_DELET_ATCHMNT";
                    using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand())
                    {
                        cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                        cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                        cmdInsertAtcmntDtls.Parameters.Add("IN_ORG_ID", OracleDbType.Int32).Value = objAttchDetail.RnwlId;
                        clsDataLayer.ExecuteNonQuery(cmdInsertAtcmntDtls);
                    }
                }
            
            }
        //method for inserting partner details in to database.
            public void AddPartner(List<clsAddPartner> objEntityPartnerList)
            {
                foreach (clsAddPartner objAttchDetail in objEntityPartnerList)
                {
                    string strQueryInsertAtcmntDtls = "ORGANIZATION.SP_INS_ORG_PARTNER_DTLS";
                    using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand())
                    {
                        cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                        cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                        cmdInsertAtcmntDtls.Parameters.Add("IN_ORG_ID", OracleDbType.Int32).Value = objAttchDetail.orgId;
                        cmdInsertAtcmntDtls.Parameters.Add("IN_ORGPARTNR_NAME", OracleDbType.Varchar2).Value = objAttchDetail.PartnerName;
                        cmdInsertAtcmntDtls.Parameters.Add("IN_ORGPARTNR_DCMNT_NUM", OracleDbType.Varchar2).Value = objAttchDetail.DocNo;
                        cmdInsertAtcmntDtls.Parameters.Add("IN_ORGPARTNR_CRN_NUM", OracleDbType.Varchar2).Value = objAttchDetail.CrNo;
                        cmdInsertAtcmntDtls.Parameters.Add("IN_CNTRY_ID", OracleDbType.Int32).Value = objAttchDetail.Contry;
                        cmdInsertAtcmntDtls.Parameters.Add("IN_ORGPARTNR_PERCNT", OracleDbType.Decimal).Value = objAttchDetail.Percent;
                        cmdInsertAtcmntDtls.Parameters.Add("IN_ORGPARTNR_STATUS", OracleDbType.Int32).Value = objAttchDetail.Status;
                        clsDataLayer.ExecuteNonQuery(cmdInsertAtcmntDtls);
                    }
                }
            }
        //method for reading partner details from database.
            public DataTable OrgReadPartner(clsEntityOrganization objEntityOrg)
            {
                string strQueryCheckOrg = "ORGANIZATION.SP_READ_PARTNER";
                using (OracleCommand cmdCheckOrg = new OracleCommand())
                {
                    cmdCheckOrg.CommandText = strQueryCheckOrg;
                    cmdCheckOrg.CommandType = CommandType.StoredProcedure;
                    cmdCheckOrg.Parameters.Add("CORP_ID", OracleDbType.Int32).Value = objEntityOrg.OrgId;
                    cmdCheckOrg.Parameters.Add("O_ORG", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    DataTable dtCheckOrg = new DataTable();
                    dtCheckOrg = clsDataLayer.SelectDataTable(cmdCheckOrg);
                    return dtCheckOrg;
                }
            }
            
        //method for deleting partner details.
            public void DeletPartner(clsAddPartner objPartnerDtls)
            {
                
                    string strQueryInsertAtcmntDtls = "ORGANIZATION.SP_DELET_PARTNER";
                    using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand())
                    {
                        cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                        cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                        cmdInsertAtcmntDtls.Parameters.Add("IN_PARTNER_ID", OracleDbType.Int32).Value = objPartnerDtls.RnwlId;
                        clsDataLayer.ExecuteNonQuery(cmdInsertAtcmntDtls);
                    }
                

            }
        //method for updating partner details.
            public void UpdatePartner(List<clsAddPartner> objEntityPartnerUpdateList)
            {
                foreach (clsAddPartner objAttchDetail in objEntityPartnerUpdateList)
                {

                string strQueryInsertAtcmntDtls = "ORGANIZATION.UPD_PARTNER_DTLS";
                using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand())
                {
                    cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                    cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                    cmdInsertAtcmntDtls.Parameters.Add("P_PARTID", OracleDbType.Int32).Value = objAttchDetail.RnwlId;
                    cmdInsertAtcmntDtls.Parameters.Add("IN_ORG_ID", OracleDbType.Int32).Value = objAttchDetail.orgId;
                    cmdInsertAtcmntDtls.Parameters.Add("IN_ORGPARTNR_NAME", OracleDbType.Varchar2).Value = objAttchDetail.PartnerName;
                    cmdInsertAtcmntDtls.Parameters.Add("IN_ORGPARTNR_DCMNT_NUM", OracleDbType.Varchar2).Value = objAttchDetail.DocNo;
                    cmdInsertAtcmntDtls.Parameters.Add("IN_ORGPARTNR_CRN_NUM", OracleDbType.Varchar2).Value = objAttchDetail.CrNo;
                    cmdInsertAtcmntDtls.Parameters.Add("IN_CNTRY_ID", OracleDbType.Int32).Value = objAttchDetail.Contry;
                    cmdInsertAtcmntDtls.Parameters.Add("IN_ORGPARTNR_PERCNT", OracleDbType.Decimal).Value = objAttchDetail.Percent;
                    cmdInsertAtcmntDtls.Parameters.Add("IN_ORGPARTNR_STATUS", OracleDbType.Int32).Value = objAttchDetail.Status;
                    clsDataLayer.ExecuteNonQuery(cmdInsertAtcmntDtls);
                }
                }

            }
            public DataTable ReadState(clsEntityOrganization objEntityOrganization)
            {
                string strQueryReadState = "ORGANIZATION.SP_READ_STATE_DDL";
                using (OracleCommand cmdReadState = new OracleCommand())
                {
                    cmdReadState.CommandText = strQueryReadState;
                    cmdReadState.CommandType = CommandType.StoredProcedure;
                    cmdReadState.Parameters.Add("S_STATEID", OracleDbType.Int32).Value = objEntityOrganization.CountryId;
                    cmdReadState.Parameters.Add("S_STATETABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    DataTable dtReadState = new DataTable();
                    dtReadState = clsDataLayer.SelectDataTable(cmdReadState);
                    return dtReadState;
                }
            }
            public DataTable ReadCity(clsEntityOrganization objEntityOrganization)
            {
                string strQueryReadState = "ORGANIZATION.SP_READ_CITY_DDL";
                using (OracleCommand cmdReadCity = new OracleCommand())
                {
                    cmdReadCity.CommandText = strQueryReadState;
                    cmdReadCity.CommandType = CommandType.StoredProcedure;
                    cmdReadCity.Parameters.Add("C_CITYID", OracleDbType.Int32).Value = objEntityOrganization.StateId;
                    cmdReadCity.Parameters.Add("C_CITYTABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    DataTable dtReadCity = new DataTable();
                    dtReadCity = clsDataLayer.SelectDataTable(cmdReadCity);
                    return dtReadCity;
                }
            }
            public string ReadOrg(clsEntityOrganization objEntityOrganization)
            {
                string strQueryReadOrg = "ORGANIZATION.SP_READ_ORG_NAME";
                OracleCommand cmdCheckAccoName = new OracleCommand();
                cmdCheckAccoName.CommandText = strQueryReadOrg;
                cmdCheckAccoName.CommandType = CommandType.StoredProcedure;
                cmdCheckAccoName.Parameters.Add("IN_ORG", OracleDbType.Varchar2).Value = objEntityOrganization.Organisation_Name;
                cmdCheckAccoName.Parameters.Add("A_ID", OracleDbType.Int32).Value = objEntityOrganization.NextId;
                cmdCheckAccoName.Parameters.Add("A_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteScalar(ref cmdCheckAccoName);
                string strReturn = cmdCheckAccoName.Parameters["A_COUNT"].Value.ToString();
                cmdCheckAccoName.Dispose();
                return strReturn;
                
            }
            public string ReadCard(clsEntityOrganization objEntityOrganization)
            {
                string strQueryReadOrg = "ORGANIZATION.SP_READ_CARD_NAME";
                OracleCommand cmdCheckAccoName = new OracleCommand();
                cmdCheckAccoName.CommandText = strQueryReadOrg;
                cmdCheckAccoName.CommandType = CommandType.StoredProcedure;
                cmdCheckAccoName.Parameters.Add("CARD_NUM", OracleDbType.Varchar2).Value = objEntityOrganization.TxNumber;
                cmdCheckAccoName.Parameters.Add("ORG_ID", OracleDbType.Int32).Value = objEntityOrganization.NextId;
                cmdCheckAccoName.Parameters.Add("A_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteScalar(ref cmdCheckAccoName);
                string strReturn = cmdCheckAccoName.Parameters["A_COUNT"].Value.ToString();
                cmdCheckAccoName.Dispose();
                return strReturn;

            }
            public string ReadCrCard(clsEntityOrganization objEntityOrganization)
            {
                string strQueryReadOrg = "ORGANIZATION.SP_READ_CRCARD_NAME";
                OracleCommand cmdCheckAccoName = new OracleCommand();
                cmdCheckAccoName.CommandText = strQueryReadOrg;
                cmdCheckAccoName.CommandType = CommandType.StoredProcedure;
                cmdCheckAccoName.Parameters.Add("CARD_NUM", OracleDbType.Varchar2).Value = objEntityOrganization.CRnumber;
                cmdCheckAccoName.Parameters.Add("ORG_ID", OracleDbType.Int32).Value = objEntityOrganization.NextId;
                cmdCheckAccoName.Parameters.Add("A_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteScalar(ref cmdCheckAccoName);
                string strReturn = cmdCheckAccoName.Parameters["A_COUNT"].Value.ToString();
                cmdCheckAccoName.Dispose();
                return strReturn;

            }
            public string ReadCompCard(clsEntityOrganization objEntityOrganization)
            {
                string strQueryReadOrg = "ORGANIZATION.SP_READ_COMPCARD_NAME";
                OracleCommand cmdCheckAccoName = new OracleCommand();
                cmdCheckAccoName.CommandText = strQueryReadOrg;
                cmdCheckAccoName.CommandType = CommandType.StoredProcedure;
                cmdCheckAccoName.Parameters.Add("CARD_NUM", OracleDbType.Varchar2).Value = objEntityOrganization.CompNumber;
                cmdCheckAccoName.Parameters.Add("ORG_ID", OracleDbType.Int32).Value = objEntityOrganization.NextId;
                cmdCheckAccoName.Parameters.Add("A_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteScalar(ref cmdCheckAccoName);
                string strReturn = cmdCheckAccoName.Parameters["A_COUNT"].Value.ToString();
                cmdCheckAccoName.Dispose();
                return strReturn;

            }
            
            public DataTable ReadPasswrd(clsEntityOrganization objEntityOrganization)
            {
                string strQueryReadState = "ORGANIZATION.SP_READ_PASS_WORD";
                using (OracleCommand cmdReadPwd = new OracleCommand())
                {
                    cmdReadPwd.CommandText = strQueryReadState;
                    cmdReadPwd.CommandType = CommandType.StoredProcedure;
                    cmdReadPwd.Parameters.Add("U_ORG_ID", OracleDbType.Int32).Value = objEntityOrganization.UserId;
                    cmdReadPwd.Parameters.Add("C_ATCHMNT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    DataTable dtReadPwd = new DataTable();
                    dtReadPwd = clsDataLayer.SelectDataTable(cmdReadPwd);
                    return dtReadPwd;
                }
            }

            public DataTable ReadAppMode(clsEntityOrganization objEntityOrganization)
            {
                string strQueryReadState = "ORGANIZATION.SP_READ_APP_MODE";
                using (OracleCommand cmdReadPwd = new OracleCommand())
                {
                    cmdReadPwd.CommandText = strQueryReadState;
                    cmdReadPwd.CommandType = CommandType.StoredProcedure;
                    cmdReadPwd.Parameters.Add("A_ORG_ID", OracleDbType.Int32).Value = objEntityOrganization.OrgId;
                    cmdReadPwd.Parameters.Add("A_COUNT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    DataTable dtAppMode = new DataTable();
                    dtAppMode = clsDataLayer.SelectDataTable(cmdReadPwd);
                    return dtAppMode;
                }
            }

    }
}
