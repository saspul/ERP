using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusiness_OverTime_Category
    {
        clsDataLayer_OverTime_Category objOverTime_Category = new clsDataLayer_OverTime_Category();
        public DataTable ReadPaygrade(clsEntity_OverTime_Category objEntity_OverTime_Category)
        {
            DataTable dtPaygrade = objOverTime_Category.ReadPaygrade(objEntity_OverTime_Category);
            return dtPaygrade;
        }
        public void InsertOvrtmCategory(clsEntity_OverTime_Category objEntity_OverTime_Category,List<clsEntity_OverTIme_Category_List> objEntity_OverTIme_Category_List)
        {
            objOverTime_Category.InsertOvrtmCategory(objEntity_OverTime_Category, objEntity_OverTIme_Category_List);
        }
        public DataTable ReadOverTimeCateg(clsEntity_OverTime_Category objEntity_OverTime_Category)
        {
            DataTable dtOvrtm = objOverTime_Category.ReadOverTimeCateg(objEntity_OverTime_Category);
            return dtOvrtm;  
        }
        public DataTable ReadOverTimeCategById(clsEntity_OverTime_Category objEntity_OverTime_Category)
        {
            DataTable dtOvrtm = objOverTime_Category.ReadOverTimeCategById(objEntity_OverTime_Category);
            return dtOvrtm;
        }
        public void UpdateOverTimeCategory(clsEntity_OverTime_Category objEntity_OverTime_Category, List<clsEntity_OverTIme_Category_List> objEntity_OverTIme_Category_List)
        {
            objOverTime_Category.UpdateOverTimeCategory(objEntity_OverTime_Category, objEntity_OverTIme_Category_List);
        }
        public void CancelOverTimeCategory (clsEntity_OverTime_Category objEntity_OverTime_Category)
        {
            objOverTime_Category.CancelOverTimeCategory(objEntity_OverTime_Category);
        }
        // This Method checks job name in the database for duplication.
        public string CheckCategoryName(clsEntity_OverTime_Category objEntity_OverTime_Category)
        {
            string count = objOverTime_Category.CheckCategoryName(objEntity_OverTime_Category);
            return count;
        }
    }
}
