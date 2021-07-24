using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EL_Compzit;
using System.Data;
using DL_Compzit;
using System.Threading.Tasks;

// CREATED BY:EVM-0014
// CREATED DATE:27/04/2017
// REVIEWED BY:
// REVIEW DATE:
// This is a Bussiness layer for the Employee Contact Details .

namespace BL_Compzit
{
    public class clsBusinessLayerContactDtls
    {
        clsDataLayerCountry objDataLayerCntryMstr = new clsDataLayerCountry();
        clsDataLayerContactDtls objDatalayrEmp = new clsDataLayerContactDtls();
        // This Method displays Country details By calling function in DataLayer and Passing the Data to the UI Layer
        public DataTable ReadRelation()
        {
            DataTable dtDisp = new DataTable();
            dtDisp = objDatalayrEmp.ReadRelate();
            return dtDisp;
        }
        public void add_Contact_Details(clsEntityLayerContactDtls objEntityContactemp)
        {
            objDatalayrEmp.Add_Emp_Contact_Details(objEntityContactemp);
        }
        public DataTable ReadContactDtlsById(clsEntityLayerContactDtls objentity)
        {
            DataTable dtDisp = new DataTable();
            dtDisp = objDatalayrEmp.Read_Contact_Details(objentity);
            return dtDisp;
        }
        public void Update_Contact_Details(clsEntityLayerContactDtls objEntityContactemp)
        {
            objDatalayrEmp.Update_Emp_Contact_Details(objEntityContactemp);
        }
        //EVM-0024
        public DataTable ReadCountry(clsEntityLayerContactDtls objentity)
        {
            DataTable dtDisp = new DataTable();
            dtDisp = objDatalayrEmp.ReadCountry(objentity);
            return dtDisp;
        }
    }
}
