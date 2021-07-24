using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;
using EL_Compzit;

namespace BL_Compzit.BusinessLayer_GMS
{
    public class clsBusinessLayerGmsReports
    {
        clsDataLayerGmsReports objDataLayerReports = new clsDataLayerGmsReports();
        public DataTable ReadDivision(clsEntityReports objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataLayerReports.ReadDivision(objEntityBnkGuarnte);
            return dtGuarnt;
        }

        public DataTable ReadExpiredGurntyReprtList(clsEntityReports objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataLayerReports.ReadExpiredGurntyReprtList(objEntityBnkGuarnte);
            return dtGuarnt;
        }

        public DataTable ReadCtagory(clsEntityReports objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataLayerReports.ReadCtagory(objEntityBnkGuarnte);
            return dtGuarnt;
        }
        public DataTable Read_Guarantee_List(clsEntityReports objEntityReport)
        {
            DataTable dtProductList = objDataLayerReports.Read_Guarantee_List(objEntityReport);
            return dtProductList;
        }
        public DataTable Read_Division(clsEntityReports objEntityReport)
        {
            DataTable dtReadDivision = objDataLayerReports.ReadDivision(objEntityReport);
            return dtReadDivision;
        }
        public DataTable Read_Category(clsEntityReports objEntityReport)
        {
            DataTable dtReadCategory = objDataLayerReports.Read_Category(objEntityReport);
            return dtReadCategory;
        }
        public DataTable Read_Corp_Details(clsEntityReports objEntityReport)
        {
            DataTable dtCorp = objDataLayerReports.ReadCorporateAddress(objEntityReport);
            return dtCorp;
        }
        public DataTable ReadClientGurntyReprtList(clsEntityReports objEntityReport)
        {
            DataTable dtCorp = objDataLayerReports.ReadClientGurntyReprtList(objEntityReport);
            return dtCorp;
        }
        public DataTable ReadProject(clsEntityReports objEntityReport)
        {
            DataTable dtCorp = objDataLayerReports.ReadProject(objEntityReport);
            return dtCorp;
        }

        public DataTable ReadGurntyReprtProjctWise(clsEntityReports objEntityReport)
        {
            DataTable dtCorp = objDataLayerReports.ReadGurntyReprtProjctWise(objEntityReport);
            return dtCorp;
        }
        public DataTable getDataSuppliGuarantee(clsEntityReports objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataLayerReports.ReadSuppGurntyReprtList(objEntityBnkGuarnte);
            return dtGuarnt;
        }
        public DataTable Read_Expiry_LIstDetails(clsEntityReports objEntityReport)
        {
            DataTable dtCorp = objDataLayerReports.Read_Expiry_LIstDetails(objEntityReport);
            return dtCorp;
        }
        public DataTable Fetch_Division(clsEntityReports objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataLayerReports.Fetch_Division(objEntityBnkGuarnte);
            return dtGuarnt;
        }
        public DataTable Fetch_Bank(clsEntityReports objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataLayerReports.Fetch_Bank(objEntityBnkGuarnte);
            return dtGuarnt;
        }
                public DataTable Read_Supplier(clsEntityReports objEntityBnkGuarnte)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataLayerReports.READ_SUPPLIER(objEntityBnkGuarnte);
            return dtGuarnt;
        }
                public DataTable Read_Client(clsEntityReports objEntityBnkGuarnte)
                {
                    DataTable dtGuarnt = new DataTable();
                    dtGuarnt = objDataLayerReports.READ_Client(objEntityBnkGuarnte);
                    return dtGuarnt;
                }
                public DataTable Read_MailTrackingDetails(clsEntityReports objEntityBnkGuarnte)
                {
                    DataTable dtGuarnt = new DataTable();
                    dtGuarnt = objDataLayerReports.Read_MailTrackingDetails(objEntityBnkGuarnte);
                    return dtGuarnt;
                }
                public DataTable ReadCurrency(clsEntityReports objEntityBnkGuarnte)
                {
                    DataTable dtGuarnt = new DataTable();
                    dtGuarnt = objDataLayerReports.ReadCurrency(objEntityBnkGuarnte);
                    return dtGuarnt;
                }
                public DataTable ReadDefualtCurrency(clsEntityReports objEntityBnkGuarnte)
                {
                    DataTable dtGuarnt = new DataTable();
                    dtGuarnt = objDataLayerReports.ReadDefualtCurrency(objEntityBnkGuarnte);
                    return dtGuarnt;
                }
    }
}
