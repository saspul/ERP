using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;

// CREATED BY:EVM-0001
// CREATED DATE:06/06/2015
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsbusinesslayerPremise
    {

        //Creating object for datalayer
        clsDataLayerPremise objDataLayerPremise = new clsDataLayerPremise();
        //Method of passing corporate department table from datalayer to ui layer
        public DataTable ReadCorpDept(clsEntityPremise objEntityPremise)
        {
            DataTable dtCorpDept = objDataLayerPremise.ReadCorporateDept(objEntityPremise);
            return dtCorpDept;
        }
        //Method of passing premise name count that have in the table.
        public string Check_Premise_Name(clsEntityPremise objEntityPremise)
        {
            string strCount = objDataLayerPremise.CheckPremiseName(objEntityPremise);
            return strCount;
        }
        //Method of passing data about premise for insertion from ui layer to datalayer.
        public void Insert_Premise(clsEntityPremise objEntityPremise)
        {
            objDataLayerPremise.Insert_Premise(objEntityPremise);
        }
        //Method for passing Premise master table from datalayer to uilayer for list view.
        public DataTable ReadPremiseList(clsEntityPremise objEntityPremise)
        {
            DataTable dtPremiseList = objDataLayerPremise.ReadPremiseList(objEntityPremise);
            return dtPremiseList;
        }
        //Passing the details about new status about the premise 
        public void Update_Premise_Status(clsEntityPremise objEntityPremise)
        {
            if (objEntityPremise.Premise_Status == 1)
            {
                objEntityPremise.Premise_Status = 0;
            }
            else
            {
                objEntityPremise.Premise_Status = 1;
            }
            objDataLayerPremise.Update_Premise_Status(objEntityPremise);
        }
        //Method of passing Premise table from datalayer to ui layer with their id
        public DataTable ReadPremiseById(clsEntityPremise objEntityPremise)
        {
            DataTable dtPremiseById = objDataLayerPremise.ReadPremiseListById(objEntityPremise);
            return dtPremiseById;
        }
        //Method for passing data about Premise modification for updation ui layer to data layer
        public void Update_Premise(clsEntityPremise objEntityPremise)
        {
            objDataLayerPremise.Update_Premise(objEntityPremise);
        }
        //Passing premise name for checking duplication at the time of updation
        public string Check_Premise_NameUpdation(clsEntityPremise objEntityPremise)
        {
            string strCount = objDataLayerPremise.CheckPremiseNameUpdate(objEntityPremise);
            return strCount;
        }
        //Method for cancel the department so passing data about department that get cancel
        public void Cancel_Premise(clsEntityPremise objEntityPremise)
        {
            objDataLayerPremise.Cancel_Premise(objEntityPremise);
        }
    }
}