using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
namespace DL_Compzit.DataLayer_FMS
{
     public class clsDataLayer_Cost_Center
    {
         public DataTable ReadCostGroup(clsEntityLayer_Cost_Center objEntity)
         {
             string strQueryReadCostGroup = "FMS_COST_CENTER.SP_READ_COST_GRP";
             OracleCommand cmdReadCostGrp = new OracleCommand();
             cmdReadCostGrp.CommandText = strQueryReadCostGroup;
             cmdReadCostGrp.CommandType = CommandType.StoredProcedure;
             cmdReadCostGrp.Parameters.Add("CC_ORGID", OracleDbType.Int32).Value = objEntity.Org_Id;
             cmdReadCostGrp.Parameters.Add("CC_CORPID", OracleDbType.Int32).Value = objEntity.Corp_Id;
             cmdReadCostGrp.Parameters.Add("CC_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
             DataTable dtEmpGRP = new DataTable();
             dtEmpGRP = clsDataLayer.ExecuteReader(cmdReadCostGrp);
             return dtEmpGRP;
         }


        public string InsertCostCenter(clsEntityLayer_Cost_Center objEntity)
        {

            OracleTransaction tran;

            string strReturn = "";
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();

                tran = con.BeginTransaction();

                try
                {
                    //commented by evm 0044
   //                 if (objEntity.CodePrsntSts==1)
   //                 {
   //                 if (objEntity.CodeSts == 0)
   //                 {

   //                     clsCommonLibrary objCommon = new clsCommonLibrary();
   //                     clsEntityCommon objEntityCommon = new clsEntityCommon();
   //                     clsDataLayer ObjDataLayer = new clsDataLayer();



   //                     int intCorpId = 0;
   //                     if (objEntity.Corp_Id != 0)
   //                     {

   //                         intCorpId = objEntity.Corp_Id;
   //                         objEntityCommon.CorporateID = objEntity.Corp_Id;

   //                     }

   //                     if (objEntity.Org_Id != 0)
   //                     {

   //                         objEntityCommon.Organisation_Id = objEntity.Org_Id;

   //                     }

   //                     objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTER);
   //                     DataTable dtFormate = ObjDataLayer.ReadCodeFormate(objEntityCommon);
   //                     string refFormatByDiv = "";
   //                     string strRealFormat = "";






   //                     if (dtFormate.Rows.Count > 0)
   //                     {


   //                         if (dtFormate.Rows[0]["CODE_FORMATE"].ToString() != "")
   //                         {
   //                             refFormatByDiv = dtFormate.Rows[0]["CODE_FORMATE"].ToString();
   //                             string strReferenceFormat = "";
   //                             strReferenceFormat = refFormatByDiv;
   //                             string[] arrReferenceSplit = strReferenceFormat.Split('*');
   //                             int intArrayRowCount = arrReferenceSplit.Length;
   //                             int Codecount = 0;
   //                             strRealFormat = refFormatByDiv.ToString();

   //                             if (strRealFormat.Contains("#NUM#"))
   //                             {
   //                                 string dtNextNumber = ObjDataLayer.ReadNextNumberSequanceForUI(objEntityCommon);


   //                                 strRealFormat = strRealFormat.Replace("#NUM#", dtNextNumber);


   //                             }
   //                             if (strRealFormat.Contains("#CSTGRP#"))
   //                             {

   //                                 strRealFormat = strRealFormat.Replace("#CSTGRP#", objEntity.grpId.ToString());


   //                             }
   //                             if (dtFormate.Rows[0]["CODE_COUNT"].ToString() != "")
   //                             {
   //                                 Codecount = Convert.ToInt32(dtFormate.Rows[0]["CODE_COUNT"].ToString());
   //                             }

   //                             int k = strRealFormat.Length;
   //                             if (k < Codecount)
   //                             {
   //                                 int Difrnce = Codecount - k;
   //                                 k = k + Difrnce;
   //                                 //  hello.PadLeft(50, '#');
   //                                 strRealFormat = strRealFormat.PadLeft(k, '0');
   //                             }


   //                             objEntity.GrpCode = strRealFormat;
   //                         }

   //                     }

   //                 }

   //}
   //       else
   //       {
   //           objEntity.GrpCode = null;
   //       }


                    string strQueryCostGroup = "FMS_COST_CENTER.SP_INS_COST_CENTER";
                    using (OracleCommand cmdAddCostCenter = new OracleCommand(strQueryCostGroup, con))
                    {
                        cmdAddCostCenter.CommandType = CommandType.StoredProcedure;
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        cmdAddCostCenter.Parameters.Add("CC_GRPID", OracleDbType.Int32).Value = objEntity.grpId;
                        cmdAddCostCenter.Parameters.Add("CC_NAME", OracleDbType.Varchar2).Value = objEntity.Name;
                        cmdAddCostCenter.Parameters.Add("CC_STS", OracleDbType.Int32).Value = objEntity.Status;
                      
                        if (objEntity.DCStatus == -1)
                        {
                            cmdAddCostCenter.Parameters.Add("CC_DC_STS", OracleDbType.Int32).Value = null;
                                                 
                        }
                        else if (objEntity.DCStatus == 0)
                        {
                            cmdAddCostCenter.Parameters.Add("CC_DC_STS", OracleDbType.Int32).Value = objEntity.DCStatus;
                         
                         }
                        else if (objEntity.DCStatus == 1)
                        {
                            cmdAddCostCenter.Parameters.Add("CC_DC_STS", OracleDbType.Int32).Value = objEntity.DCStatus;
                         
                         
                        }
                        if (objEntity.Balance != 0)
                        {
                            cmdAddCostCenter.Parameters.Add("CC_CREDIT_BALANCE", OracleDbType.Decimal).Value = objEntity.Balance;
                        }
                        else
                        {
                            cmdAddCostCenter.Parameters.Add("CC_CREDIT_BALANCE", OracleDbType.Decimal).Value = null;
                        }
                       
                        cmdAddCostCenter.Parameters.Add("CC_ORGID", OracleDbType.Int32).Value = objEntity.Org_Id;
                        cmdAddCostCenter.Parameters.Add("CC_CORPID", OracleDbType.Int32).Value = objEntity.Corp_Id;
                        cmdAddCostCenter.Parameters.Add("CC_INS_USRID", OracleDbType.Int32).Value = objEntity.UserId;
                        cmdAddCostCenter.Parameters.Add("CC_NATURE", OracleDbType.Int32).Value = objEntity.Nature;
                        cmdAddCostCenter.Parameters.Add("C_CODE", OracleDbType.Varchar2).Value = objEntity.GrpCode;
                        cmdAddCostCenter.Parameters.Add("CC_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                        cmdAddCostCenter.ExecuteNonQuery();
                        strReturn = cmdAddCostCenter.Parameters["CC_ID"].Value.ToString();
                       
                    }
                    tran.Commit();
                    return strReturn;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }
            }
        }
         public string CheckCostName(clsEntityLayer_Cost_Center objEntity)
        {

            string strQueryAddTaxCollectedAtSource = "FMS_COST_CENTER.SP_CHECK_COST_NAME";
            OracleCommand cmdCheckCostName = new OracleCommand();
            cmdCheckCostName.CommandText = strQueryAddTaxCollectedAtSource;
            cmdCheckCostName.CommandType = CommandType.StoredProcedure;
            cmdCheckCostName.Parameters.Add("CC_ID", OracleDbType.Int32).Value = objEntity.CostId;
            cmdCheckCostName.Parameters.Add("CC_NAME", OracleDbType.Varchar2).Value = objEntity.Name;
            cmdCheckCostName.Parameters.Add("CC_CORPID", OracleDbType.Int32).Value = objEntity.Corp_Id;
            cmdCheckCostName.Parameters.Add("CC_ORGID", OracleDbType.Int32).Value = objEntity.Org_Id;
            cmdCheckCostName.Parameters.Add("CC_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;

            clsDataLayer.ExecuteScalar(ref cmdCheckCostName);
            string strReturn = cmdCheckCostName.Parameters["CC_COUNT"].Value.ToString();
            cmdCheckCostName.Dispose();
            return strReturn;
        }
         public DataTable ReadCostCenterList(clsEntityLayer_Cost_Center objEntity)
         {
             string strQueryReadCOSTCENTER = "FMS_COST_CENTER.SP_COST_CENTER_LIST";
             OracleCommand cmdReadCOSTCENTER = new OracleCommand();
             cmdReadCOSTCENTER.CommandText = strQueryReadCOSTCENTER;
             cmdReadCOSTCENTER.CommandType = CommandType.StoredProcedure;
             cmdReadCOSTCENTER.Parameters.Add("CC_CORPID", OracleDbType.Int32).Value = objEntity.Corp_Id;
             cmdReadCOSTCENTER.Parameters.Add("CC_STS", OracleDbType.Int32).Value = objEntity.Status;
             cmdReadCOSTCENTER.Parameters.Add("CC_ORGID", OracleDbType.Int32).Value = objEntity.Org_Id;
             cmdReadCOSTCENTER.Parameters.Add("CC_CNCL_STS", OracleDbType.Int32).Value = objEntity.Cancl_Status;
             cmdReadCOSTCENTER.Parameters.Add("CC_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

             DataTable dtLeav = new DataTable();
             dtLeav = clsDataLayer.ExecuteReader(cmdReadCOSTCENTER);
             return dtLeav;

         }
         public DataTable ReadCostCenterById(clsEntityLayer_Cost_Center objEntity)
         {
             string strQueryReadCostCenter = "FMS_COST_CENTER.SP_READ_COST_CENTER_BYID";
             OracleCommand cmdReadCostCenter = new OracleCommand();
             cmdReadCostCenter.CommandText = strQueryReadCostCenter;
             cmdReadCostCenter.CommandType = CommandType.StoredProcedure;

             cmdReadCostCenter.Parameters.Add("CC_ORG_ID", OracleDbType.Int32).Value = objEntity.Org_Id;
             cmdReadCostCenter.Parameters.Add("CC_CORPID", OracleDbType.Int32).Value = objEntity.Corp_Id;
             cmdReadCostCenter.Parameters.Add("CC_COST_ID", OracleDbType.Int32).Value = objEntity.CostId;
             cmdReadCostCenter.Parameters.Add("CC_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
             DataTable dtLeav = new DataTable();
             dtLeav = clsDataLayer.ExecuteReader(cmdReadCostCenter);
             return dtLeav;

         }
         public void CancelCostCenter(clsEntityLayer_Cost_Center objEntity)
         {
             string strQueryCnclCost = " FMS_COST_CENTER.SP_CANCEL_COST_CENTER";
             using (OracleCommand cmdCnclCostCenter = new OracleCommand())
             {
                 cmdCnclCostCenter.CommandText = strQueryCnclCost;
                 cmdCnclCostCenter.CommandType = CommandType.StoredProcedure;
                 cmdCnclCostCenter.Parameters.Add("CC_COST_ID", OracleDbType.Int32).Value = objEntity.CostId;
                 cmdCnclCostCenter.Parameters.Add("CC_CNCL_USRID", OracleDbType.Int32).Value = objEntity.UserId;
                 cmdCnclCostCenter.Parameters.Add("CC_CNSL_RSN", OracleDbType.Varchar2).Value = objEntity.CancelReason;
                 cmdCnclCostCenter.Parameters.Add("CC_ORGID", OracleDbType.Int32).Value = objEntity.Org_Id;
                 cmdCnclCostCenter.Parameters.Add("CC_CORPID", OracleDbType.Int32).Value = objEntity.Corp_Id;
                 clsDataLayer.ExecuteNonQuery(cmdCnclCostCenter);
             }
         }
         public void UpdateCostCenter(clsEntityLayer_Cost_Center objEntity)
         {
             OracleTransaction tran;


             using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
             {
                 con.Open();

                 tran = con.BeginTransaction();

                 try
                 {
                     //Commented by evm 0044
                     //if (objEntity.CodePrsntSts == 1)
                     //{


                     //    if (objEntity.CodeSts == 0)
                     //    {
                     //        DataTable CheckNatureChange = ReadCostCenterById(objEntity);
                     //        if (CheckNatureChange.Rows.Count > 0)
                     //        {

                     //            if (objEntity.grpId != Convert.ToInt32(CheckNatureChange.Rows[0]["COSTGRP_ID"].ToString()))
                     //            {

                     //                clsCommonLibrary objCommon = new clsCommonLibrary();
                     //                clsEntityCommon objEntityCommon = new clsEntityCommon();
                     //                clsDataLayer ObjDataLayer = new clsDataLayer();



                     //                int intCorpId = 0;
                     //                if (objEntity.Corp_Id != 0)
                     //                {

                     //                    intCorpId = objEntity.Corp_Id;
                     //                    objEntityCommon.CorporateID = objEntity.Corp_Id;

                     //                }

                     //                if (objEntity.Org_Id != 0)
                     //                {

                     //                    objEntityCommon.Organisation_Id = objEntity.Org_Id;

                     //                }

                     //                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTER);
                     //                DataTable dtFormate = ObjDataLayer.ReadCodeFormate(objEntityCommon);
                     //                string refFormatByDiv = "";
                     //                string strRealFormat = "";




                     //                if (dtFormate.Rows.Count > 0)
                     //                {


                     //                    // CodeFormate = NaureCode.ToString() + dtNextNumber;
                     //                    if (dtFormate.Rows[0]["CODE_FORMATE"].ToString() != "")
                     //                    {
                     //                        refFormatByDiv = dtFormate.Rows[0]["CODE_FORMATE"].ToString();
                     //                        string strReferenceFormat = "";
                     //                        strReferenceFormat = refFormatByDiv;
                     //                        string[] arrReferenceSplit = strReferenceFormat.Split('*');
                     //                        int intArrayRowCount = arrReferenceSplit.Length;
                     //                        int Codecount = 0;
                     //                        strRealFormat = refFormatByDiv.ToString();

                     //                        if (strRealFormat.Contains("#NUM#"))
                     //                        {
                     //                            string dtNextNumber = ObjDataLayer.ReadNextNumberSequanceForUI(objEntityCommon);


                     //                            strRealFormat = strRealFormat.Replace("#NUM#", dtNextNumber);


                     //                        }
                     //                        if (strRealFormat.Contains("#CSTGRP#"))
                     //                        {

                     //                            strRealFormat = strRealFormat.Replace("#CSTGRP#", objEntity.grpId.ToString());


                     //                        }
                     //                        if (dtFormate.Rows[0]["CODE_COUNT"].ToString() != "")
                     //                        {
                     //                            Codecount = Convert.ToInt32(dtFormate.Rows[0]["CODE_COUNT"].ToString());
                     //                        }

                     //                        int k = strRealFormat.Length;
                     //                        if (k < Codecount)
                     //                        {
                     //                            int Difrnce = Codecount - k;
                     //                            k = k + Difrnce;
                     //                            //  hello.PadLeft(50, '#');
                     //                            strRealFormat = strRealFormat.PadLeft(k, '0');
                     //                        }


                     //                        objEntity.GrpCode = strRealFormat;
                     //                    }

                     //                }
                     //            }
                     //        }

                     //    }
                     //}
                     //else
                     //{
                     //    objEntity.GrpCode = null;
                     //}
                     string strQueryCostGroup = "FMS_COST_CENTER.SP_UPD_COST_CENTER";
                     using (OracleCommand cmdUpdCostCenter = new OracleCommand(strQueryCostGroup, con))
                     {
                         cmdUpdCostCenter.CommandType = CommandType.StoredProcedure;
                         clsEntityCommon objEntCommon = new clsEntityCommon();
                         cmdUpdCostCenter.Parameters.Add("CC_COST_ID", OracleDbType.Int32).Value = objEntity.CostId;
                         cmdUpdCostCenter.Parameters.Add("CC_GRPID", OracleDbType.Int32).Value = objEntity.grpId;
                         cmdUpdCostCenter.Parameters.Add("CC_NAME", OracleDbType.Varchar2).Value = objEntity.Name;
                         cmdUpdCostCenter.Parameters.Add("CC_STS", OracleDbType.Int32).Value = objEntity.Status;

                         if (objEntity.DCStatus == -1)
                         {
                             cmdUpdCostCenter.Parameters.Add("CC_DC_STS", OracleDbType.Int32).Value = null;
                          
                          
                         }
                         else if (objEntity.DCStatus == 0)
                         {
                             cmdUpdCostCenter.Parameters.Add("CC_DC_STS", OracleDbType.Int32).Value = objEntity.DCStatus;
                           
                           
                         }
                         else if (objEntity.DCStatus == 1)
                         {
                             cmdUpdCostCenter.Parameters.Add("CC_DC_STS", OracleDbType.Int32).Value = objEntity.DCStatus;
                          
                          
                         }
                         if (objEntity.Balance != 0)
                         {
                             cmdUpdCostCenter.Parameters.Add("CC_CREDIT_BALANCE", OracleDbType.Decimal).Value = objEntity.Balance;
                         }
                         else
                         {
                             cmdUpdCostCenter.Parameters.Add("CC_CREDIT_BALANCE", OracleDbType.Decimal).Value = null;
                         }

                         cmdUpdCostCenter.Parameters.Add("CC_ORGID", OracleDbType.Int32).Value = objEntity.Org_Id;
                         cmdUpdCostCenter.Parameters.Add("CC_CORPID", OracleDbType.Int32).Value = objEntity.Corp_Id;
                         cmdUpdCostCenter.Parameters.Add("CC_UPD_USRID", OracleDbType.Int32).Value = objEntity.UserId;
                         cmdUpdCostCenter.Parameters.Add("CC_NATURE", OracleDbType.Int32).Value = objEntity.Nature;
                         cmdUpdCostCenter.Parameters.Add("C_CODE", OracleDbType.Varchar2).Value = objEntity.GrpCode;
                         cmdUpdCostCenter.ExecuteNonQuery();

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
         public DataTable CostCenterCancelChk(clsEntityLayer_Cost_Center objEntity)
         {
             string strQueryReadCostCenter = "FMS_COST_CENTER.SP_READ_COST_CENTER_CNCLCHK";
             OracleCommand cmdReadCostCenter = new OracleCommand();
             cmdReadCostCenter.CommandText = strQueryReadCostCenter;
             cmdReadCostCenter.CommandType = CommandType.StoredProcedure;

             cmdReadCostCenter.Parameters.Add("CC_ORG_ID", OracleDbType.Int32).Value = objEntity.Org_Id;
             cmdReadCostCenter.Parameters.Add("CC_CORPID", OracleDbType.Int32).Value = objEntity.Corp_Id;
             cmdReadCostCenter.Parameters.Add("CC_COST_ID", OracleDbType.Int32).Value = objEntity.CostId;
             cmdReadCostCenter.Parameters.Add("CC_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
             DataTable dtLeav = new DataTable();
             dtLeav = clsDataLayer.ExecuteReader(cmdReadCostCenter);
             return dtLeav;

         }


         public string CheckCodeDuplicatn(clsEntityLayer_Cost_Center objEntityAccountGroup)
         {
             string strQueryAddBank = "FMS_COST_CENTER.SP_CHECK_DUP_CODE";
             OracleCommand cmdAddBankName = new OracleCommand();
             cmdAddBankName.CommandText = strQueryAddBank;
             cmdAddBankName.CommandType = CommandType.StoredProcedure;
             cmdAddBankName.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityAccountGroup.CostId;
             cmdAddBankName.Parameters.Add("B_CODE", OracleDbType.Varchar2).Value = objEntityAccountGroup.GrpCode;
             cmdAddBankName.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityAccountGroup.Corp_Id;
             cmdAddBankName.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityAccountGroup.Org_Id;
             cmdAddBankName.Parameters.Add("B_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
             clsDataLayer.ExecuteScalar(ref cmdAddBankName);
             string strReturn = cmdAddBankName.Parameters["B_COUNT"].Value.ToString();
             cmdAddBankName.Dispose();
             return strReturn;
         }
         public void DeleteCostCenter(clsEntityLayer_Cost_Center objEntity)
         {
             OracleTransaction tran;


             using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
             {
                 con.Open();

                 tran = con.BeginTransaction();

                 try
                 {
                     string strQueryCostGroup = "FMS_COST_CENTER.SP_DEL_COST_CENTER";
                     using (OracleCommand cmdUpdCostCenter = new OracleCommand(strQueryCostGroup, con))
                     {
                         cmdUpdCostCenter.CommandType = CommandType.StoredProcedure;
                         clsEntityCommon objEntCommon = new clsEntityCommon();
                         cmdUpdCostCenter.Parameters.Add("CC_COST_ID", OracleDbType.Int32).Value = objEntity.CostId;
                        

                         cmdUpdCostCenter.Parameters.Add("CC_ORGID", OracleDbType.Int32).Value = objEntity.Org_Id;
                         cmdUpdCostCenter.Parameters.Add("CC_CORPID", OracleDbType.Int32).Value = objEntity.Corp_Id;
                         cmdUpdCostCenter.Parameters.Add("CC_UPD_USRID", OracleDbType.Int32).Value = objEntity.UserId;

                         cmdUpdCostCenter.ExecuteNonQuery();

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
         //evm 0044
         public void UpdateCostGroupNextId(clsEntityLayer_Cost_Center objEntityCostCenter)
         {
             OracleTransaction tran;
             using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
             {
                 con.Open();
                 tran = con.BeginTransaction();
                 try
                 {

                     string strQueryUpdateAccount = "FMS_COST_GROUP.UP_COSGRP_NEXT_COSTCNTRID";
                         using (OracleCommand cmdUpdateCostGroup = new OracleCommand(strQueryUpdateAccount, con))
                         {
                             cmdUpdateCostGroup.Transaction = tran;
                             cmdUpdateCostGroup.CommandType = CommandType.StoredProcedure;
                             cmdUpdateCostGroup.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCostCenter.Org_Id ;
                             cmdUpdateCostGroup.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCostCenter.Corp_Id ;
                             cmdUpdateCostGroup.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCostCenter.grpId ;
                             cmdUpdateCostGroup.ExecuteNonQuery();
                         }
                     

                     tran.Commit();
                 }
                 catch (Exception ex)
                 {
                     tran.Rollback();
                     throw ex;
                 }
             }
         }
    }
}
