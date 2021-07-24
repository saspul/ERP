using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;
using System.Data;

namespace BL_Compzit
{
    public class clsBusinessLayerCorpDivision
    {
        clsDataLayerCorpDivision objDataLayerCorpDiv = new clsDataLayerCorpDivision();

        // This Method adds Corporate Division details to the database by passing details to Data Layer
        public void AddCorporateDivision(clsEntityCorpDivision objEntityCorpDiv)  //emp0025
        {
            objDataLayerCorpDiv.AddCorporateDivisionMstr(objEntityCorpDiv);
        }
        // for listing the corp div table in corpdiv list

        public DataTable ReadCorpDivisionTable(clsEntityCorpDivision objEntityCorpDiv)
        {
            DataTable dtCorpDivTable = objDataLayerCorpDiv.ReadCorpDivisionTable(objEntityCorpDiv);
            return dtCorpDivTable;
        }

        //Fetch Corp Div table from datalayer and pass to ui layer.
        public DataTable EditViewCorpDiv(clsEntityCorpDivision objCorpDiv)
        {
            DataTable dtCorpDivTable = objDataLayerCorpDiv.EditViewCorpDiv(objCorpDiv);
            return dtCorpDivTable;

        }


        // updating corp divn detail to the table through datatlayer
        public void UpdateCorpDivision(clsEntityCorpDivision objCorpDiv)  //emp0025
        {
            objDataLayerCorpDiv.UpdateCorpDivision(objCorpDiv);
        }


        //updating cancel reasons to the corp div table through the data layer
        public void UpdateCorpDivCancel(clsEntityCorpDivision objCorpDivr)
        {
            objDataLayerCorpDiv.UpdateCorpDivCancel(objCorpDivr);
        }

        //Method of passing next value for insertion from datalayer to uilayer.
        public DataTable ReadNextId(clsEntityCorpDivision objEntityCorpDiv)
        {
            DataTable dtReadnextId = objDataLayerCorpDiv.ReadNextId(objEntityCorpDiv);
            return dtReadnextId;
        }

        // 
        public string CheckDupDivNameUpdate(clsEntityCorpDivision objEntityCorpDiv)
        {
            string strDiv = objDataLayerCorpDiv.CheckDupDivNameUpdate(objEntityCorpDiv);
            return strDiv;
        }

        public string CheckDupDivEmail(clsEntityCorpDivision objEntityCorpDiv)
        {
            string strDiv = objDataLayerCorpDiv.CheckDupDivEmail(objEntityCorpDiv);
            return strDiv;
        }

        public string CheckDupDivCode(clsEntityCorpDivision objEntityCorpDiv)
        {
            string strDiv = objDataLayerCorpDiv.CheckDupDivCode(objEntityCorpDiv);
            return strDiv;
        }

        //update mail console settings
        public void Update_Mail_Console(clsEntityCorpDivision objEntityCorpDiv)
        {
            objDataLayerCorpDiv.UpdateMailConsole(objEntityCorpDiv);
        }

        //fetch mail console settings on the basis of corporate id
        public DataTable Read_Mail_Console(clsEntityCorpDivision objEntityCorpDiv)
        {
            DataTable dtMailConsole = objDataLayerCorpDiv.ReadMailSettings(objEntityCorpDiv);
            return dtMailConsole;
        }

        public void Update_Division_Status(clsEntityCorpDivision objEntityCorpDiv)  //emp0025
        {
            objDataLayerCorpDiv.Update_Division_Status(objEntityCorpDiv);
        }
    }


}
