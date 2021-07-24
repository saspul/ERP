using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_PMS;
using DL_Compzit.DataLayer_PMS;

namespace BL_Compzit.BusinessLayer_PMS
{
    public class clsBusinessLayerWarehouse
    {
        clsDataLayerWarehouse objDataWarehouse = new clsDataLayerWarehouse();

        public DataTable ReadCountry(clsEntityWarehouse objEntityWarehouse)
        {
            DataTable dt = objDataWarehouse.ReadCountry(objEntityWarehouse);
            return dt;
        }

        public DataTable ReadState(clsEntityWarehouse objEntityWarehouse)
        {
            DataTable dt = objDataWarehouse.ReadState(objEntityWarehouse);
            return dt;
        }

        public DataTable ReadCity(clsEntityWarehouse objEntityWarehouse)
        {
            DataTable dt = objDataWarehouse.ReadCity(objEntityWarehouse);
            return dt;
        }

        public void InsertWarehouse(clsEntityWarehouse objEntityWarehouse)
        {
            objDataWarehouse.InsertWarehouse(objEntityWarehouse);
        }

        public DataTable ReadWarehouseList(clsEntityWarehouse objEntityWarehouse)
        {
            DataTable dt = objDataWarehouse.ReadWarehouseList(objEntityWarehouse);
            return dt;
        }

        public DataTable ReadWarehouseById(clsEntityWarehouse objEntityWarehouse)
        {
            DataTable dt = objDataWarehouse.ReadWarehouseById(objEntityWarehouse);
            return dt;
        }

        public void UpdateWarehouse(clsEntityWarehouse objEntityWarehouse)
        {
            objDataWarehouse.UpdateWarehouse(objEntityWarehouse);
        }

        public void CancelWarehouse(clsEntityWarehouse objEntityWarehouse)
        {
            objDataWarehouse.CancelWarehouse(objEntityWarehouse);
        }

        public void StatusChangeWarehouse(clsEntityWarehouse objEntityWarehouse)
        {
            objDataWarehouse.StatusChangeWarehouse(objEntityWarehouse);
        }

        public DataTable CheckNameDuplictnWarehouse(clsEntityWarehouse objEntityWarehouse)
        {
            DataTable dt = objDataWarehouse.CheckNameDuplictnWarehouse(objEntityWarehouse);
            return dt;
        }

        public DataTable CheckCodeDuplictnWarehouse(clsEntityWarehouse objEntityWarehouse)
        {
            DataTable dt = objDataWarehouse.CheckCodeDuplictnWarehouse(objEntityWarehouse);
            return dt;
        }

        public DataTable ReadWarehouseListPage(clsEntityWarehouse objEntityWarehouse)
        {
            DataTable dt = objDataWarehouse.ReadWarehouseListPage(objEntityWarehouse);
            return dt;
        }


    }
}
