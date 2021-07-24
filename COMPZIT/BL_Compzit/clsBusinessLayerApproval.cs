using System;
using System.Text;
using EL_Compzit;
using System.Data;
using DL_Compzit;

// CREATED BY:EVM-0002
// CREATED DATE:30/05/2015
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinessLayerApproval
    {
        //Creating object for datalayer.
        clsDataLayerApproval objDataLayerApproval = new clsDataLayerApproval();
        //Passing details about approval pending organisations from datalayer to ui layer.
        public DataTable Approval_Pending()
        {
            DataTable dtAprvlPen = objDataLayerApproval.Approval_Pending();
            return dtAprvlPen;
        }
        //Passing the details about the organisation from datalayer to ui layer.
        public DataTable Select_Organisation(clsEntityLayerApproval objEntityApproval)
        {
            DataTable dtOrg = objDataLayerApproval.Select_Organisation(objEntityApproval);
            return dtOrg;
        }

        //Passing the status details for updating status of organisation from ui layer to data layer.
        public void Update_Organisation(clsEntityLayerApproval objEntityApproval)
        {
            objDataLayerApproval.Update_Organisation(objEntityApproval);
        }

        //Passing the status details for updating status of organisation to rejection from ui layer to data layer.
        public void Reject_Organisation(clsEntityLayerApproval objEntityApproval)
        {
            objDataLayerApproval.Reject_Organisation(objEntityApproval);
        }
    }
}
