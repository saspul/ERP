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
   public class classBusinessLayerGuaranteType
    {
       public string AddGuaranteType(classEntityLayerGuaranteType objEntityGuaranteType)
        {
            classDatalayerGuaranteType ObjDataGuarante = new classDatalayerGuaranteType();
            string strReturn= ObjDataGuarante.AddGuaranteType(objEntityGuaranteType);
            return strReturn;
        }

       public void UpdateGuaranteType(classEntityLayerGuaranteType objEntityGuaranteType)
        {
            classDatalayerGuaranteType ObjDataGuarante = new classDatalayerGuaranteType();
            ObjDataGuarante.UpdateGuaranteType(objEntityGuaranteType);
        }
              // This Method Update Guarantee Type details to the table
       public void ChangeGuaranteStatus(classEntityLayerGuaranteType objEntityGuaranteType)
       {
           classDatalayerGuaranteType ObjDataGuarante = new classDatalayerGuaranteType();
           ObjDataGuarante.ChangeGuaranteStatus(objEntityGuaranteType);
       }
             
       // This Method checks Guarantee Type name in the database for duplication.
       public string CheckGuaranteTypeName(classEntityLayerGuaranteType objEntityGuaranteType)
        {
            classDatalayerGuaranteType ObjDataGuarante = new classDatalayerGuaranteType();
            string strReturn = ObjDataGuarante.CheckGuaranteTypeName(objEntityGuaranteType);
            return strReturn;
        }
       // This Method will fetCH Guarantee Type DEATILS BY ID
       public DataTable ReadGuaranteTypeById(classEntityLayerGuaranteType objEntityGuaranteType)
        {
            classDatalayerGuaranteType ObjDataGuarante = new classDatalayerGuaranteType();
            DataTable dtCategory = new DataTable();
            dtCategory = ObjDataGuarante.ReadGuaranteTypeById(objEntityGuaranteType);
            return dtCategory;
        }
        // This Method will fetch Guarantee Type list
       public DataTable ReadGuaranteTypeList(classEntityLayerGuaranteType objEntityGuaranteType)
        {
            classDatalayerGuaranteType ObjDataGuarante = new classDatalayerGuaranteType();
            DataTable dtCategory = new DataTable();
            dtCategory = ObjDataGuarante.ReadGuaranteTypeList(objEntityGuaranteType);
            return dtCategory;
        }
        //Method for cancel Guarantee Type
        public void CancelGuaranteType(classEntityLayerGuaranteType objEntityGuaranteType)
        {
            classDatalayerGuaranteType ObjDataGuarante = new classDatalayerGuaranteType();
            ObjDataGuarante.CancelGuaranteType(objEntityGuaranteType);
        }
        //Method for Recall Cancelled Complaint from Guarantee Type master table so update cancel related fields
        public void ReCallGuaranteType(classEntityLayerGuaranteType objEntityGuaranteType)
        {
            classDatalayerGuaranteType ObjDataGuarante = new classDatalayerGuaranteType();
            ObjDataGuarante.ReCallGuaranteType(objEntityGuaranteType);
        }
        // This Method will fetCH Guarantee MODE
       public DataTable ReadGuaranteMode()
       {
           classDatalayerGuaranteType ObjDataGuarante = new classDatalayerGuaranteType();
           DataTable dtCategory = new DataTable();
           dtCategory = ObjDataGuarante.ReadGuaranteMode();
           return dtCategory;
       }

       public string CatagrychkBankGrnte(classEntityLayerGuaranteType objEntityGuaranteType)
        {
            classDatalayerGuaranteType ObjDataGuarante = new classDatalayerGuaranteType();
            string strReturn = ObjDataGuarante.CatagrychkBankGrnte(objEntityGuaranteType);
            return strReturn;
        }
    }
}
