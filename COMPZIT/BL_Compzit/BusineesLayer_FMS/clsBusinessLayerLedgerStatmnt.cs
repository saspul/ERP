using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_FMS;
using DL_Compzit.DataLayer_FMS;

namespace BL_Compzit.BusineesLayer_FMS
{
    public class clsBusinessLayerLedgerStatmnt
    {
        clsDataLayerLedgerStatement objDataLedgerStatmnt = new clsDataLayerLedgerStatement();

        public DataTable ReadLedgers(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            DataTable dt = objDataLedgerStatmnt.ReadLedgers(objEntityLedgerStmnt);
            return dt;
        }

        //0039
        public DataTable Readvoucherinfo(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            DataTable dt = objDataLedgerStatmnt.Readvoucherinfo(objEntityLedgerStmnt);
            return dt;
        }
        //end

        public DataTable ReadLedgerStatementMain(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            DataTable dt = objDataLedgerStatmnt.ReadLedgerStatementMain(objEntityLedgerStmnt);
            return dt;
        }

        public DataTable ReadLedgerStatementDtls(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            DataTable dt = objDataLedgerStatmnt.ReadLedgerStatementDtls(objEntityLedgerStmnt);
            return dt;
        }

        public DataTable ReadLedgerStatementCostCentreDtls(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            DataTable dt = objDataLedgerStatmnt.ReadLedgerStatementCostCentreDtls(objEntityLedgerStmnt);
            return dt;
        }

        public DataTable ReadPostdatedChqDtls(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            DataTable dt = objDataLedgerStatmnt.ReadPostdatedChqDtls(objEntityLedgerStmnt);
            return dt;
        }

        public DataTable ReadCodes(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            DataTable dt = objDataLedgerStatmnt.ReadCodes(objEntityLedgerStmnt);
            return dt;
        }

        public DataTable ReadLedgerStatementAsPerDtls(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            DataTable dt = objDataLedgerStatmnt.ReadLedgerStatementAsPerDtls(objEntityLedgerStmnt);
            return dt;
        }

        public DataTable ReadJournalRemove(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            DataTable dt = objDataLedgerStatmnt.ReadJournalRemove(objEntityLedgerStmnt);
            return dt;
        }

        public DataTable ReadJournalInsert(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            DataTable dt = objDataLedgerStatmnt.ReadJournalInsert(objEntityLedgerStmnt);
            return dt;
        }

        public void DeleteAndInsertJrnl(List<clsEntityLedgerStatement> objEntityDELETE, List<clsEntityLedgerStatement> objEntityINSERT)
        {
            objDataLedgerStatmnt.DeleteAndInsertJrnl(objEntityDELETE, objEntityINSERT);
        }


    }
}
