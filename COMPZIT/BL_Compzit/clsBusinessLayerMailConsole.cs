using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using System.Data;

// CREATED BY:EVM-0002
// CREATED DATE:08/04/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinessLayerMailConsole
    {
        //create object for datalayer
        clsDataLayerMailConsole objDataLayerMailConsole = new clsDataLayerMailConsole();
        //read mail protocol from datalayer
        public DataTable ReadMailProtocol()
        {
            DataTable dtProtocol = objDataLayerMailConsole.ReadMailProtocol();
            return dtProtocol;
        }

        //insert mail details to the mail console table
        public void AddMailConsole(clsEntityMailConsole objEntityMailConsole)
        {
            objDataLayerMailConsole.AddMailConsole(objEntityMailConsole);
        }

        //update mail console details based mail id
        public void UpdateMailConsole(clsEntityMailConsole ObjEntityMailConsole)
        {
            objDataLayerMailConsole.UpdateMailConsole(ObjEntityMailConsole);
        }

        //update mail console details based mail id without password
        public void UpdateMailConsoleWithOut(clsEntityMailConsole ObjEntityMailConsole)
        {
            objDataLayerMailConsole.UpdateMailConsoleWithOut(ObjEntityMailConsole);
        }

        //cancel mail console so update cancel related fields
        public void CancelMailConsole(clsEntityMailConsole objEntityMailConsole)
        {
            objDataLayerMailConsole.CancelMailConsole(objEntityMailConsole);
        }

        //fetch mail console details based on mail console id
        public DataTable ReadMailConsoleById(clsEntityMailConsole objEntityMailConsole)
        {
            DataTable dtMailConsole = objDataLayerMailConsole.ReadMailConsoleById(objEntityMailConsole);
            return dtMailConsole;
        }

        //methode for checking email address already existed in the table or not
        public string CheckEmailAddress(clsEntityMailConsole objEntityMailConsole)
        {
            string strEmailCount = objDataLayerMailConsole.CheckEmailAddress(objEntityMailConsole);
            return strEmailCount;
        }

        //read total mail console for showing the list
        public DataTable ReadMailConsole(clsEntityMailConsole objEntityMailConsole)
        {
            DataTable dtMailConsole = objDataLayerMailConsole.ReadMailConsole(objEntityMailConsole);
            return dtMailConsole;
        }
        public void UpdateStatus(clsEntityMailConsole ObjEntityMailConsole)
        {
            objDataLayerMailConsole.UpdateStatus(ObjEntityMailConsole);
        }
    }
}
