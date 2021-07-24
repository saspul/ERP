using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit;
using DL_Compzit;

namespace BL_Compzit
{
    public class clsBusinessLayerReportBuilder
    {
        clsDataLayerReportBuilder objDataLayer = new clsDataLayerReportBuilder();

        public DataTable ReadReportData(clsEntityReportBuilder objEntityCommon)
        {
            DataTable dtCommon = objDataLayer.ReadReportData(objEntityCommon);
            return dtCommon;
        }

        public DataTable ReadReportDtls(clsEntityReportBuilder objEntityCommon)
        {
            DataTable dtCommon = objDataLayer.ReadReportDtls(objEntityCommon);
            return dtCommon;
        }

        public DataTable ReadProcedure(string strProcedure, string strAction, int CorpId, int OrgId, DataTable dtParameters)
        {
            DataTable dtCommon = objDataLayer.ReadProcedure(strProcedure, strAction, CorpId, OrgId, dtParameters);
            return dtCommon;
        }

        public DataTable ReadProcedureParameters(string strPackage, string strProcedure)
        {
            DataTable dtCommon = objDataLayer.ReadProcedureParameters(strPackage, strProcedure);
            return dtCommon;
        }
    }
}
