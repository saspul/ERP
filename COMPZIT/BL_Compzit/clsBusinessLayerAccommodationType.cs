using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;
using CL_Compzit;

// CREATED BY:EVM-0009
// CREATED DATE:13/12/2016
// REVIEWED BY:
// REVIEW DATE:
namespace BL_Compzit
{
   public class clsBusinessLayerAccommodationType
    {
        //Creating object for datalayer
        clsDataLayerAccommodationType objDataLayerAccommodationType = new clsDataLayerAccommodationType();
        clsCommonLibrary objCommonLibrary = new clsCommonLibrary();

        //Method for check AccommodationType Name already exist in the table or not.
        public string CheckAccommodationTypeName(clsEntityAccommodationType objEntityAccommodationType)
        {
            string strCount = objDataLayerAccommodationType.CheckAccommodationTypeName(objEntityAccommodationType);
            return strCount;
        }
        //Method of passing data about Accommodation Type for insertion from ui layer to datalayer.
        public void Insert_AccommodationType(clsEntityAccommodationType objEntityAccommodationType)
        {
            objDataLayerAccommodationType.Insert_AccommodationType(objEntityAccommodationType);
        }
        //Method for passing Accommodation Type master table from datalayer to uilayer for list view.
        public DataTable ReadAccommodationTypeList(clsEntityAccommodationType objEntityAccommodationType)
        {
            DataTable dtResultSet = objDataLayerAccommodationType.ReadAccommodationTypeList(objEntityAccommodationType);
            return dtResultSet;
        }

        //Method of passing Accommodation Type table from datalayer to ui layer with their id
        public DataTable ReadAccommodationTypeById(clsEntityAccommodationType objEntityAccommodationType)
        {
            DataTable dtResultSet = objDataLayerAccommodationType.ReadAccommodationTypeById(objEntityAccommodationType);
            return dtResultSet;
        }
        //Method for passing data about Accommodation Type modification for updation ui layer to data layer
        public void Update_AccommodationType(clsEntityAccommodationType objEntityAccommodationType)
        {
            objDataLayerAccommodationType.Update_AccommodationType(objEntityAccommodationType);
        }
        //Method for cancel the Accommodation Type so passing data about Accommodation Type that get cancel
        public void Cancel_AccommodationType(clsEntityAccommodationType objEntityAccommodationType)
        {
            objDataLayerAccommodationType.Cancel_AccommodationType(objEntityAccommodationType);
        }
        //Method for Recall Cancelled Accommodation Type from Accommodation Type master table so update cancel related fields
        public void Recall_AccommodationType(clsEntityAccommodationType objEntityAccommodationType)
        {
            objDataLayerAccommodationType.Recall_AccommodationType(objEntityAccommodationType);
        }
        public DataTable ReadAccommodationById(clsEntityAccommodationType objEntityAccommodationType)
        {
            DataTable dtResultSet = objDataLayerAccommodationType.ReadAccommodationById(objEntityAccommodationType);
            return dtResultSet;
        }
        public void UpdateStatus(clsEntityAccommodationType objEntityAccommodationType)
        {
            objDataLayerAccommodationType.UpdateStatus(objEntityAccommodationType);
        }
    }
}
