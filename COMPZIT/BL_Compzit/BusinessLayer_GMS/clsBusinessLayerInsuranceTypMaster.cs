using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;

namespace BL_Compzit.BusinessLayer_GMS
{
    public class clsBusinessLayerInsuranceTypMaster
    {
        public void AddInsuranceTyp(clsEntityLayerInsuranceTypMaster objEntityInsrTyp)
        {
            clsDataLayerInsuranceTypMaster ObjInsuranceTyp = new clsDataLayerInsuranceTypMaster();
            ObjInsuranceTyp.AddInsuranceTyp(objEntityInsrTyp);
        }

        public void UpdateInsuranceTyp(clsEntityLayerInsuranceTypMaster objEntityInsrTyp)
        {
            clsDataLayerInsuranceTypMaster ObjInsuranceTyp = new clsDataLayerInsuranceTypMaster();
            ObjInsuranceTyp.UpdateInsuranceTyp(objEntityInsrTyp);
        }

        // This Method checks job category name in the database for duplication.
        public string CheckInsuranceTypName(clsEntityLayerInsuranceTypMaster objEntityInsrTyp)
        {
            clsDataLayerInsuranceTypMaster ObjInsuranceTyp = new clsDataLayerInsuranceTypMaster();
            string strReturn = ObjInsuranceTyp.CheckInsuranceTypName(objEntityInsrTyp);
            return strReturn;
        }
        // This Method will fetCH job category DEATILS BY ID
        public DataTable ReadInsuranceTypById(clsEntityLayerInsuranceTypMaster objEntityInsrTyp)
        {
            clsDataLayerInsuranceTypMaster ObjInsuranceTyp = new clsDataLayerInsuranceTypMaster();
            DataTable dtCategory = new DataTable();
            dtCategory = ObjInsuranceTyp.ReadInsuranceTypById(objEntityInsrTyp);
            return dtCategory;
        }
        // This Method will fetch job category list
        public DataTable ReadInsuranceTypList(clsEntityLayerInsuranceTypMaster objEntityInsrTyp)
        {
            clsDataLayerInsuranceTypMaster ObjInsuranceTyp = new clsDataLayerInsuranceTypMaster();
            DataTable dtCategory = new DataTable();
            dtCategory = ObjInsuranceTyp.ReadInsuranceTypList(objEntityInsrTyp);
            return dtCategory;
        }
        //Method for cancel job category
        public void CancelInsuranceTyp(clsEntityLayerInsuranceTypMaster objEntityInsrTyp)
        {
            clsDataLayerInsuranceTypMaster ObjInsuranceTyp = new clsDataLayerInsuranceTypMaster();
            ObjInsuranceTyp.CancelInsuranceTyp(objEntityInsrTyp);
        }
        public DataTable CheckInsrncTypCnclSts(clsEntityLayerInsuranceTypMaster objEntityInsrTyp)
        {
            clsDataLayerInsuranceTypMaster ObjInsuranceTyp = new clsDataLayerInsuranceTypMaster();
            DataTable dtCategory = new DataTable();
            dtCategory = ObjInsuranceTyp.CheckInsrncTypCnclSts(objEntityInsrTyp);
            return dtCategory;
        }
    }
}
