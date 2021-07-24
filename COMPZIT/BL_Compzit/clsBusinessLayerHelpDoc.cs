using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL_Compzit;
using EL_Compzit;


namespace BL_Compzit
{
    public class clsBusinessLayerHelpDoc
    {
        clsDataLayerHelpDoc objDataLayerHelpDoc = new clsDataLayerHelpDoc();

        public DataTable ReadUserRollByURL(clsEntityHelpDoc objEntityHelpDoc)
        {
            DataTable dt = objDataLayerHelpDoc.ReadUserRollByURL(objEntityHelpDoc);
            return dt;
        }
        public DataTable ReadMainUserRolsByAppId(clsEntityHelpDoc objEntityHelpDoc)
        {
            DataTable dt = objDataLayerHelpDoc.ReadMainUserRolsByAppId(objEntityHelpDoc);
            return dt;
        }
        public DataTable ReadUserRolsByUserRolId(clsEntityHelpDoc objEntityHelpDoc)
        {
            DataTable dt = objDataLayerHelpDoc.ReadUserRolsByUserRolId(objEntityHelpDoc);
            return dt;
        }

        public DataTable ReadSectionsByURL(clsEntityHelpDoc objEntityHelpDoc)
        {
            DataTable dt = objDataLayerHelpDoc.ReadSectionsByURL(objEntityHelpDoc);
            return dt;
        }

        public void SaveHelpDoc(clsEntityHelpDoc objEntityHelpDoc)
        {
            objDataLayerHelpDoc.SaveHelpDoc(objEntityHelpDoc);
        }

        public DataTable ReadEditView(clsEntityHelpDoc objEntityHelpDoc)
        {
            DataTable dt = objDataLayerHelpDoc.ReadEditView(objEntityHelpDoc);
            return dt;
        }

        public void UpdateHelpDoc(clsEntityHelpDoc objEntityHelpDoc)
        {
            objDataLayerHelpDoc.UpdateHelpDoc(objEntityHelpDoc);
        }

        public DataTable ReadCurrentPageControls(clsEntityHelpDoc objEntityHelpDoc)
        {
            DataTable dt = objDataLayerHelpDoc.ReadCurrentPageControls(objEntityHelpDoc);
            return dt;
        }

        public DataTable ReadControlsDescription(clsEntityHelpDoc objEntityHelpDoc)
        {
            DataTable dt = objDataLayerHelpDoc.ReadControlsDescription(objEntityHelpDoc);
            return dt;
        }


        //Help-View

        public DataTable ReadHelpCenterSections(clsEntityHelpDoc objEntityHelpDoc)
        {
            DataTable dt = objDataLayerHelpDoc.ReadHelpCenterSections(objEntityHelpDoc);
            return dt;
        }
        public DataTable ReadHelpCenterDetails(clsEntityHelpDoc objEntityHelpDoc)
        {
            DataTable dt = objDataLayerHelpDoc.ReadHelpCenterDetails(objEntityHelpDoc);
            return dt;
        }

        public DataTable ReadHelpCenterDetailsById(clsEntityHelpDoc objEntityHelpDoc)
        {
            DataTable dt = objDataLayerHelpDoc.ReadHelpCenterDetailsById(objEntityHelpDoc);
            return dt;
        }
        public DataTable ReadHelpCenterSearch(clsEntityHelpDoc objEntityHelpDoc)
        {
            DataTable dt = objDataLayerHelpDoc.ReadHelpCenterSearch(objEntityHelpDoc);
            return dt;
        }

        public DataTable ReadAppIdUserRolId(clsEntityHelpDoc objEntityHelpDoc)
        {
            DataTable dt = objDataLayerHelpDoc.ReadAppIdUserRolId(objEntityHelpDoc);
            return dt;
        }
        
        
    }
}
