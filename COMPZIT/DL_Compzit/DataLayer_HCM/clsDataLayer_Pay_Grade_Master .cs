
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using CL_Compzit;
using EL_Compzit.HCM;

namespace DL_Compzit.HCM
{
    public class clsDataLayer_Pay_Grade_Master
    {
        public DataTable ReadCurrency(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_READ_CURRENCY";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }


        public DataTable ReadSalaryAddn(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_READ_SALARYADDTN";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadSalaryDedctn(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_READ_SALARYDEDCTN";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public void AddPayGrade(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_INS_PAYGRD_DTLS";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityPayGrd.PayGrdName;
                cmdReadPayGrd.Parameters.Add("B_AMTRNGE_FRM", OracleDbType.Decimal).Value = objEntityPayGrd.AmountRangeFrm;
                cmdReadPayGrd.Parameters.Add("B_AMTRNGE_TO", OracleDbType.Decimal).Value = objEntityPayGrd.AmountRangeTo;
                cmdReadPayGrd.Parameters.Add("CRRNCY_ID", OracleDbType.Int32).Value = objEntityPayGrd.currcyId;
                    cmdReadPayGrd.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityPayGrd.PayGrdStatus;

                    cmdReadPayGrd.Parameters.Add("P_RSTRCT_STS", OracleDbType.Int32).Value = objEntityPayGrd.RestrctLimit;
                    cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
                    cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                    cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;

                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }

        public DataTable ReadPayGradeList(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_READ_PAY_GRADELIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("B_STS", OracleDbType.Int32).Value = objEntityPayGrd.PayGrdStatus;
            cmdReadPayGrd.Parameters.Add("B_CANCELSTS", OracleDbType.Int32).Value = objEntityPayGrd.Cancel_Status;
            cmdReadPayGrd.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }


        public void ChangeRequestStatus(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_UPDATE_STS";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityPayGrd.PayGrdStatus;
                    cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
                    cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                    cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;

                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }

        }

        public void CancelPayGrade(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_CANCEL_PYGRD";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("P_RESN", OracleDbType.Varchar2).Value = objEntityPayGrd.Cancel_reason;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayGrd.D_Date;
                    cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
                    cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                    cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;

                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }

        }

        public void ReCallPayGrade(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_RECALL_PYGRD";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
                
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayGrd.D_Date;
                    cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
                    cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                    cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;

                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }

        }

        public DataTable ReadPayGradeById(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_READ_PAY_GRADE_BYID";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public void UpdatePayGrade(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_UPDATE_PAYGRDE";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayGrd.D_Date;
                cmdReadPayGrd.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityPayGrd.PayGrdName;
                cmdReadPayGrd.Parameters.Add("B_AMTRNGE_FRM", OracleDbType.Decimal).Value = objEntityPayGrd.AmountRangeFrm;
                cmdReadPayGrd.Parameters.Add("B_AMTRNGE_TO", OracleDbType.Decimal).Value = objEntityPayGrd.AmountRangeTo;
                cmdReadPayGrd.Parameters.Add("CRRNCY_ID", OracleDbType.Int32).Value = objEntityPayGrd.currcyId;
                cmdReadPayGrd.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityPayGrd.PayGrdStatus;

                cmdReadPayGrd.Parameters.Add("P_RSTRCT_STS", OracleDbType.Int32).Value = objEntityPayGrd.RestrctLimit;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }

        public string DuplCheckNamePayGrade(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_PAY_GRADE_DUPNAME_CHK";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
            cmdReadPayGrd.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityPayGrd.PayGrdName;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadPayGrd);
            string strReturn = cmdReadPayGrd.Parameters["P_OUT"].Value.ToString();
            cmdReadPayGrd.Dispose();
            return strReturn;

          
        }

        public void AddSalaryAddnAllownce(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_INS_ALLOWNCE_DTLS";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("SALARYADDTN_ID", OracleDbType.Int32).Value = objEntityPayGrd.SalaryAllwnceId;
                if (objEntityPayGrd.PercOrAmountChk == 0)
                {
                    cmdReadPayGrd.Parameters.Add("B_AMTRNGE_FRM", OracleDbType.Decimal).Value = objEntityPayGrd.AmountRangeFrm;
                    cmdReadPayGrd.Parameters.Add("B_AMTRNGE_TO", OracleDbType.Decimal).Value = objEntityPayGrd.AmountRangeTo;
                }
                else
                {
                    cmdReadPayGrd.Parameters.Add("B_AMTRNGE_FRM", OracleDbType.Decimal).Value = 0;
                    cmdReadPayGrd.Parameters.Add("B_AMTRNGE_TO", OracleDbType.Decimal).Value = 0; 
                }
                    cmdReadPayGrd.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityPayGrd.PayGrdStatus;

                    if (objEntityPayGrd.PercOrAmountChk == 0)
                    {
                        cmdReadPayGrd.Parameters.Add("P_RSTRCT_STS", OracleDbType.Int32).Value = objEntityPayGrd.RestrctLimit;
                    }
                    else
                    {
                        cmdReadPayGrd.Parameters.Add("P_RSTRCT_STS", OracleDbType.Int32).Value = 0;
                    }
                    cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
                    cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                    cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
                    cmdReadPayGrd.Parameters.Add("P_PERORAMUT", OracleDbType.Int32).Value = objEntityPayGrd.PercOrAmountChk;

                    if (objEntityPayGrd.PercOrAmountChk == 1)
                    {
                        cmdReadPayGrd.Parameters.Add("P_PER", OracleDbType.Decimal).Value = objEntityPayGrd.Percentge;
                        cmdReadPayGrd.Parameters.Add("P_PER_TO", OracleDbType.Decimal).Value = objEntityPayGrd.PercentgeTo;
                        cmdReadPayGrd.Parameters.Add("P_RSTRCT_PERC_STS", OracleDbType.Int32).Value = objEntityPayGrd.RestrctLimitPerc;

                    }
                    else
                    {
                        cmdReadPayGrd.Parameters.Add("P_PER", OracleDbType.Decimal).Value = 0;
                        cmdReadPayGrd.Parameters.Add("P_PER_TO", OracleDbType.Decimal).Value = 0;
                        cmdReadPayGrd.Parameters.Add("P_RSTRCT_PERC_STS", OracleDbType.Int32).Value = 0;
                    }



                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }
        public string DuplCheckSalaryAllownce(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_PAYGRD_DUPSALRY_ADDTN_CHK";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
            cmdReadPayGrd.Parameters.Add("ALLW_ID", OracleDbType.Int32).Value = objEntityPayGrd.AlownceId;
            cmdReadPayGrd.Parameters.Add("SALARYADDTN_ID", OracleDbType.Int32).Value = objEntityPayGrd.SalaryAllwnceId;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadPayGrd);
            string strReturn = cmdReadPayGrd.Parameters["P_OUT"].Value.ToString();
            cmdReadPayGrd.Dispose();
            return strReturn;

        }

        public string DuplCheckSalaryDedctn(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_PAYGRD_DEDCTION_CHK";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
            cmdReadPayGrd.Parameters.Add("DED_ID", OracleDbType.Int32).Value = objEntityPayGrd.DedctnId;
            cmdReadPayGrd.Parameters.Add("SALARYDEDCTION_ID", OracleDbType.Int32).Value = objEntityPayGrd.SlaryDedctnId;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadPayGrd);
            string strReturn = cmdReadPayGrd.Parameters["P_OUT"].Value.ToString();
            cmdReadPayGrd.Dispose();
            return strReturn;

                    }

        public void AddSalaryDedction(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_INS_DEDCTION_DTLS";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("SALARYDEDCTN_ID", OracleDbType.Int32).Value = objEntityPayGrd.SlaryDedctnId;

                if (objEntityPayGrd.PercOrAmountChk == 0)
                {
                    cmdReadPayGrd.Parameters.Add("B_AMTRNGE_FRM", OracleDbType.Decimal).Value = objEntityPayGrd.AmountRangeFrm;
                    cmdReadPayGrd.Parameters.Add("B_AMTRNGE_TO", OracleDbType.Decimal).Value = objEntityPayGrd.AmountRangeTo;
                }
                else
                {
                    cmdReadPayGrd.Parameters.Add("B_AMTRNGE_FRM", OracleDbType.Decimal).Value = 0;
                    cmdReadPayGrd.Parameters.Add("B_AMTRNGE_TO", OracleDbType.Decimal).Value = 0;
                }
                cmdReadPayGrd.Parameters.Add("B_PER_OR_AMNT", OracleDbType.Decimal).Value = objEntityPayGrd.PercOrAmountChk;
                cmdReadPayGrd.Parameters.Add("B_BSC_OR_TOTAMNT", OracleDbType.Decimal).Value = objEntityPayGrd.BasicOrTotalAmtChk;
                 cmdReadPayGrd.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityPayGrd.PayGrdStatus;

                  if (objEntityPayGrd.PercOrAmountChk == 1)
                  {
                      cmdReadPayGrd.Parameters.Add("P_RSTRCT_STS", OracleDbType.Int32).Value = 0;
                      cmdReadPayGrd.Parameters.Add("P_PERCNTGE", OracleDbType.Decimal).Value = objEntityPayGrd.Percentge;
                  }
                  else
                  {
                      cmdReadPayGrd.Parameters.Add("P_RSTRCT_STS", OracleDbType.Int32).Value = objEntityPayGrd.RestrctLimit;
                      cmdReadPayGrd.Parameters.Add("P_PERCNTGE", OracleDbType.Decimal).Value = 0;
                  }


                  
                     cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
                    cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                    cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
                    if (objEntityPayGrd.PercOrAmountChk == 1)
                    {
                        cmdReadPayGrd.Parameters.Add("P_PERCNTGE_TO", OracleDbType.Decimal).Value = objEntityPayGrd.PercentgeTo;
                        cmdReadPayGrd.Parameters.Add("P_RSTRCT_PERC_STS", OracleDbType.Int32).Value = objEntityPayGrd.RestrctLimitPerc;

                    }
                    else
                    {
                        cmdReadPayGrd.Parameters.Add("P_PERCNTGE_TO", OracleDbType.Decimal).Value = 0;
                        cmdReadPayGrd.Parameters.Add("P_RSTRCT_PERC_STS", OracleDbType.Int32).Value = 0;

                    }
                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }



        public DataTable ReadAllounceList(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_READ_ALLONCE_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
            cmdReadPayGrd.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public void ChangeAllowStatus(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_UPDATE_ALLOW_STS";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityPayGrd.PayGrdStatus;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;

                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }

        }
        public DataTable ReadAllounceById(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_READ_ALLWCE_BYID";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }


        public void UpdSalaryAddnAllownce(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_UPDATE_ALLOWNCE";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("ALLW_ID", OracleDbType.Int32).Value = objEntityPayGrd.AlownceId;
                cmdReadPayGrd.Parameters.Add("ALLWNCE_ID", OracleDbType.Int32).Value = objEntityPayGrd.SalaryAllwnceId;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayGrd.D_Date;
                if (objEntityPayGrd.PercOrAmountChk == 0)
                {
                    cmdReadPayGrd.Parameters.Add("P_AMTRNGE_FRM", OracleDbType.Decimal).Value = objEntityPayGrd.AmountRangeFrm;
                    cmdReadPayGrd.Parameters.Add("P_AMTRNGE_TO", OracleDbType.Decimal).Value = objEntityPayGrd.AmountRangeTo;
                }
                else
                {
                    cmdReadPayGrd.Parameters.Add("P_AMTRNGE_FRM", OracleDbType.Decimal).Value = 0;
                    cmdReadPayGrd.Parameters.Add("P_AMTRNGE_TO", OracleDbType.Decimal).Value = 0;
                }
                cmdReadPayGrd.Parameters.Add("ADDTN_ID", OracleDbType.Int32).Value = objEntityPayGrd.currcyId;
                cmdReadPayGrd.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityPayGrd.PayGrdStatus;

                if (objEntityPayGrd.PercOrAmountChk == 0)
                {
                    cmdReadPayGrd.Parameters.Add("P_RSTRCT_STS", OracleDbType.Int32).Value = objEntityPayGrd.RestrctLimit;
                }
                else
                {
                    cmdReadPayGrd.Parameters.Add("P_RSTRCT_STS", OracleDbType.Int32).Value = 0;
                }
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
                cmdReadPayGrd.Parameters.Add("P_PERORAMUT", OracleDbType.Int32).Value = objEntityPayGrd.PercOrAmountChk;

                if (objEntityPayGrd.PercOrAmountChk == 1)
                {
                    cmdReadPayGrd.Parameters.Add("P_PER", OracleDbType.Decimal).Value = objEntityPayGrd.Percentge;
                    cmdReadPayGrd.Parameters.Add("P_PER_TO", OracleDbType.Decimal).Value = objEntityPayGrd.PercentgeTo;
                    cmdReadPayGrd.Parameters.Add("P_RSTRCT_PERC_STS", OracleDbType.Int32).Value = objEntityPayGrd.RestrctLimitPerc;

                }
                else
                {
                    cmdReadPayGrd.Parameters.Add("P_PER", OracleDbType.Decimal).Value = 0;
                    cmdReadPayGrd.Parameters.Add("P_PER_TO", OracleDbType.Decimal).Value = 0;
                    cmdReadPayGrd.Parameters.Add("P_RSTRCT_PERC_STS", OracleDbType.Int32).Value = 0;

                }
                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }
            
                  public void CancelAllownce(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_CANCEL_ALLWNCE";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("P_RESN", OracleDbType.Varchar2).Value = objEntityPayGrd.Cancel_reason;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayGrd.D_Date;
                    cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
                    cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                    cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;

                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }

        }


                  public DataTable ReadDedctnList(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_READ_DEDCTN_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
            cmdReadPayGrd.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

                  public void ChangeDedctnStatus(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_UPDATE_DEDCTN_STS";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityPayGrd.PayGrdStatus;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;

                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }

        }
                  public DataTable ReadDedctnById(clsEntity_Pay_Grade_Master objEntityPayGrd)
                  {
                      string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_READ_DEDCTN_BYID";
                      OracleCommand cmdReadPayGrd = new OracleCommand();
                      cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                      cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                      cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
                      cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
                      cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                      cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
                      cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                      DataTable dtCategory = new DataTable();
                      dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
                      return dtCategory;
                  }



                  public void CancelDedctn(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_CANCEL_DEDCTN";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("P_RESN", OracleDbType.Varchar2).Value = objEntityPayGrd.Cancel_reason;
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayGrd.D_Date;
                    cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
                    cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                    cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;

                    clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }

        }


                  public void UpdateSalaryDedction(clsEntity_Pay_Grade_Master objEntityPayGrd)
        {
            string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_UPDT_DEDCTION_DTLS";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
                cmdReadPayGrd.Parameters.Add("DED_ID", OracleDbType.Int32).Value = objEntityPayGrd.DedctnId;
                cmdReadPayGrd.Parameters.Add("SALARYDEDCTN_ID", OracleDbType.Int32).Value = objEntityPayGrd.SlaryDedctnId;
                if (objEntityPayGrd.PercOrAmountChk == 0)
                {
                    cmdReadPayGrd.Parameters.Add("B_AMTRNGE_FRM", OracleDbType.Decimal).Value = objEntityPayGrd.AmountRangeFrm;
                    cmdReadPayGrd.Parameters.Add("B_AMTRNGE_TO", OracleDbType.Decimal).Value = objEntityPayGrd.AmountRangeTo;
                }
                else
                {
                    cmdReadPayGrd.Parameters.Add("B_AMTRNGE_FRM", OracleDbType.Decimal).Value =0;
                    cmdReadPayGrd.Parameters.Add("B_AMTRNGE_TO", OracleDbType.Decimal).Value = 0;                
                }
                cmdReadPayGrd.Parameters.Add("B_PER_OR_AMNT", OracleDbType.Decimal).Value = objEntityPayGrd.PercOrAmountChk;
                cmdReadPayGrd.Parameters.Add("B_BSC_OR_TOTAMNT", OracleDbType.Decimal).Value = objEntityPayGrd.BasicOrTotalAmtChk;
                cmdReadPayGrd.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityPayGrd.PayGrdStatus;


                if (objEntityPayGrd.PercOrAmountChk == 1)
                {
                    cmdReadPayGrd.Parameters.Add("P_RSTRCT_STS", OracleDbType.Int32).Value = 0;
                    cmdReadPayGrd.Parameters.Add("P_PERCNTGE", OracleDbType.Decimal).Value = objEntityPayGrd.Percentge;
                }
                else
                {
                    cmdReadPayGrd.Parameters.Add("P_RSTRCT_STS", OracleDbType.Int32).Value = objEntityPayGrd.RestrctLimit;
                    cmdReadPayGrd.Parameters.Add("P_PERCNTGE", OracleDbType.Decimal).Value = 0;
                }



                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayGrd.D_Date;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;

                if (objEntityPayGrd.PercOrAmountChk == 1)
                {
                    cmdReadPayGrd.Parameters.Add("P_PERCNTGE_TO", OracleDbType.Decimal).Value = objEntityPayGrd.PercentgeTo;
                    cmdReadPayGrd.Parameters.Add("P_RSTRCT_PERC_STS", OracleDbType.Int32).Value = objEntityPayGrd.RestrctLimitPerc;
                }
                else
                {
                    cmdReadPayGrd.Parameters.Add("P_PERCNTGE_TO", OracleDbType.Decimal).Value = objEntityPayGrd.PercentgeTo;
                    cmdReadPayGrd.Parameters.Add("P_RSTRCT_PERC_STS", OracleDbType.Int32).Value = 0;
                }
               
                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }


                  public DataTable CurncyAbbrv(clsEntity_Pay_Grade_Master objEntityPayGrd)
                  {
                      string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_READ_CURRCY_ABBRV";
                      OracleCommand cmdReadPayGrd = new OracleCommand();
                      cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                      cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                      cmdReadPayGrd.Parameters.Add("CRRCY_ID", OracleDbType.Int32).Value = objEntityPayGrd.currcyId;
                      cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
                      cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                      cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
                      cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                      DataTable dtCategory = new DataTable();
                      dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
                      return dtCategory;
                  }


                  public DataTable ReadOvertimeById(clsEntity_Pay_Grade_Master objEntityPayGrd)
                  {
                      string strQueryReadPayGrd = "PAY_GRADE_MSTR.SP_READ_OVERTIME";
                      OracleCommand cmdReadPayGrd = new OracleCommand();
                      cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                      cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                      cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
                      cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPayGrd.User_Id;
                      cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                      cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
                      cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                      DataTable dtCategory = new DataTable();
                      dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
                      return dtCategory;
                  }

                  public DataTable ReadCountPayGradeOverTime(clsEntity_Pay_Grade_Master objEntityPayGrd)
                  {
                      string strQueryReadPayGrdCount = "PAY_GRADE_MSTR.SP_READ_COUNT_OVERTIME";
                      OracleCommand cmdReadPayGrdCount = new OracleCommand();
                      cmdReadPayGrdCount.CommandText = strQueryReadPayGrdCount;
                      cmdReadPayGrdCount.CommandType = CommandType.StoredProcedure;
                      cmdReadPayGrdCount.Parameters.Add("P_PYGRD_ID", OracleDbType.Int32).Value = objEntityPayGrd.NextIdForPayGrade;
                      cmdReadPayGrdCount.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayGrd.Organisation_Id;
                      cmdReadPayGrdCount.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayGrd.CorpOffice_Id;
                      cmdReadPayGrdCount.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                      DataTable dtCategory = new DataTable();
                      dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrdCount);
                      return dtCategory;
                  }

        }
    }

