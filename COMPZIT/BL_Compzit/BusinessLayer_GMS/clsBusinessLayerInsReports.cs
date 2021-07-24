using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;
using EL_Compzit;


namespace BL_Compzit.BusinessLayer_GMS
{
  public  class clsBusinessLayerInsReports
    {
      clsDataLayerInsReports objDataLayerReports = new clsDataLayerInsReports();
      public DataTable Read_Insurance_Expiry_Details(clsEntityReports objEntityInsurance)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objDataLayerReports.Read_Insurance_Expiry_Details(objEntityInsurance);
          return dtGuarnt;
      }
      public DataTable Read_Insurance_Project_Wise(clsEntityReports objEntityInsurance)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objDataLayerReports.Read_Insurance_Project_Wise(objEntityInsurance);
          return dtGuarnt;
      }
      public DataTable Read_Corp_Details(clsEntityReports objEntityReport)
      {
          DataTable dtCorp = objDataLayerReports.ReadCorporateAddress(objEntityReport);
          return dtCorp;
      }
      public DataTable ReadCurrency(clsEntityReports objEntityInsurance)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objDataLayerReports.ReadCurrency(objEntityInsurance);
          return dtGuarnt;
      }
      public DataTable Read_Division(clsEntityReports objEntityReport)
      {
          DataTable dtReadDivision = objDataLayerReports.ReadDivision(objEntityReport);
          return dtReadDivision;
      }
      public DataTable ReadDefualtCurrency(clsEntityReports objEntityInsurance)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objDataLayerReports.ReadDefualtCurrency(objEntityInsurance);
          return dtGuarnt;
      }
      public DataTable ReadInsuranceProvider(clsEntityReports objEntityInsurance)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objDataLayerReports.ReadInsuranceProvider(objEntityInsurance);
          return dtGuarnt;
      }
      public DataTable ReadProject(clsEntityReports objEntityReport)
      {
          DataTable dtCorp = objDataLayerReports.ReadProject(objEntityReport);
          return dtCorp;
      }
      public DataTable ReadInsurance_Type(clsEntityReports objEntityReport)
      {
          DataTable dtCorp = objDataLayerReports.ReadInsurance_Type(objEntityReport);
          return dtCorp;
      }
      public DataTable Read_Insurance_TypeReport(clsEntityReports objEntityInsurance)
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objDataLayerReports.Read_Insurance_TypeReport(objEntityInsurance);
          return dtGuarnt;
      }


    }
}
