using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;
using EL_Compzit;

namespace BL_Compzit.BusinessLayer_GMS
{ 
  public  class clsBusinessLayerGms_Home
    {
      clsDataLayerGms_Home objHome = new clsDataLayerGms_Home();
      public DataTable Read_IMS_DashBoard()
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objHome.Read_IMS_DashBoard();
          return dtGuarnt;
      }
      public DataTable Read_BankGurnt_DashBoard()
      {
          DataTable dtGuarnt = new DataTable();
          dtGuarnt = objHome.Read_BankGurnt_DashBoard();
          return dtGuarnt;
      }
    }
}
