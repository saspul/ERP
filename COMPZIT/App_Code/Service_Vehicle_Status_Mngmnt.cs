using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DL_Compzit;
using EL_Compzit;
using System.Data;
using DL_Compzit.DataLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Web.Script.Serialization;
using CL_Compzit;
/// <summary>
/// Summary description for Service_Vehicle_Status_Mngmnt
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Service_Vehicle_Status_Mngmnt : System.Web.Services.WebService {

    public Service_Vehicle_Status_Mngmnt () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string MakeAvailable(int VehId, int strUserId)
    {
        string ret = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBussinesLayerVehicleStatusMngmnt objBusinesVehSts = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt ObjEntityVehicleStatus = new clsEntityVehicleStatusMngmnt();
        ObjEntityVehicleStatus.User_Id = strUserId;
        ObjEntityVehicleStatus.VehicleId = VehId;
        try
        {
            objBusinesVehSts.MakeAvailVehicle(ObjEntityVehicleStatus);
            ret = "success";

        }
        catch
        {
            ret = "failed";
        }
        return ret;
 
    }

   
    [WebMethod]
    public string CloseVehicleStatus(int strAsgnId, int strUserId)
    {
        string ret = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBussinesLayerVehicleStatusMngmnt objBusinesVehSts = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt ObjEntityVehicleStatus = new clsEntityVehicleStatusMngmnt();
        ObjEntityVehicleStatus.VehAsignId = strAsgnId;
        ObjEntityVehicleStatus.User_Id = strUserId;
        try
        {
            objBusinesVehSts.CloseVehicleStatus(ObjEntityVehicleStatus);
            ret = "success";

        }
        catch
        {
            ret = "failed";
        }
        return ret;

    }

    [WebMethod]
    public string ConfirmVehicleAssign(int strAsgnId, int strUserId, int strOrgId, int strCorpId)
    {
        string ret = "TRUE";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBussinesLayerVehicleStatusMngmnt objBusinesVehSts = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt ObjEntityVehicleStatus = new clsEntityVehicleStatusMngmnt();
        ObjEntityVehicleStatus.CorporateId = strCorpId;
        ObjEntityVehicleStatus.Org_Id = strOrgId;
        ObjEntityVehicleStatus.VehAsignId = strAsgnId;
        ObjEntityVehicleStatus.User_Id = strUserId;
        string strToDateNew = "";
        string strFromDateNew = "";
        DataTable dtAsignDetail=objBusinesVehSts.ReadVehicleAssignDetailsById(ObjEntityVehicleStatus);
        if (dtAsignDetail.Rows.Count > 0)
        {
            ObjEntityVehicleStatus.VehicleId = Convert.ToInt32(dtAsignDetail.Rows[0]["VHCL_ID"]);
            ObjEntityVehicleStatus.VehicleSts = Convert.ToInt32(dtAsignDetail.Rows[0]["VHCLSTS_ID"]);
            if (dtAsignDetail.Rows[0]["FROM_DATE"].ToString() != "")
            {
                ObjEntityVehicleStatus.FromDate = objCommon.textToDateTime(dtAsignDetail.Rows[0]["FROM_DATE"].ToString());
                strFromDateNew = dtAsignDetail.Rows[0]["FROM_DATE"].ToString();
            }
            if (dtAsignDetail.Rows[0]["TO_DATE"].ToString() != "")
            {
                ObjEntityVehicleStatus.ToDate = objCommon.textToDateTime(dtAsignDetail.Rows[0]["TO_DATE"].ToString());
                strToDateNew=dtAsignDetail.Rows[0]["TO_DATE"].ToString();
            }

            int VehStatusNew = ObjEntityVehicleStatus.VehicleSts;
           
            int intVehstsOld;
            string FromDateOld="";
            string ToDateOld="";
            DataTable dtAsignDetailOfVeh = objBusinesVehSts.ReadVehcicleStatusDetail(ObjEntityVehicleStatus);
            if (dtAsignDetailOfVeh.Rows.Count > 0)
            {
                for (int intCount = 0; intCount < dtAsignDetailOfVeh.Rows.Count; intCount++)
                {
                    intVehstsOld = Convert.ToInt32(dtAsignDetailOfVeh.Rows[intCount]["VHCLSTS_ID"]);
                    if (dtAsignDetailOfVeh.Rows[intCount]["FROM_DATE"].ToString() != "")
                    {
                        FromDateOld = dtAsignDetailOfVeh.Rows[intCount]["FROM_DATE"].ToString();
                    }
                    if (dtAsignDetailOfVeh.Rows[intCount]["TO_DATE"].ToString() != "")
                    {
                        ToDateOld = dtAsignDetailOfVeh.Rows[intCount]["TO_DATE"].ToString();
                    }


                    if (VehStatusNew == intVehstsOld)
                    {

                        if (ToDateOld == "")
                        {
                            ret = "FALSE";
                        }
                        else
                        {
                            if (ret == "TRUE")
                            {
                                if (strToDateNew != "")
                                {
                                    if (objCommon.textToDateTime(FromDateOld) >= objCommon.textToDateTime(strFromDateNew) && objCommon.textToDateTime(strToDateNew) <= objCommon.textToDateTime(ToDateOld))
                                    {
                                        ret = "FALSE";
                                    }
                                    else if (objCommon.textToDateTime(FromDateOld) <= objCommon.textToDateTime(strFromDateNew) && objCommon.textToDateTime(strToDateNew) >= objCommon.textToDateTime(ToDateOld))
                                    {
                                        ret = "FALSE";
                                    }
                                    else if (objCommon.textToDateTime(strFromDateNew) <= objCommon.textToDateTime(ToDateOld) && objCommon.textToDateTime(strToDateNew) >= objCommon.textToDateTime(ToDateOld))
                                    {
                                        ret = "FALSE";
                                    }
                                    else if (objCommon.textToDateTime(strToDateNew) >= objCommon.textToDateTime(FromDateOld) && objCommon.textToDateTime(strToDateNew) <= objCommon.textToDateTime(ToDateOld))
                                    {
                                        ret = "FALSE";
                                    }
                                }
                                else
                                {
                                    if (objCommon.textToDateTime(FromDateOld) >= objCommon.textToDateTime(strFromDateNew))
                                    {
                                        ret = "FALSE";
                                    }
                                    else if (objCommon.textToDateTime(FromDateOld) <= objCommon.textToDateTime(strFromDateNew) && objCommon.textToDateTime(ToDateOld) >= objCommon.textToDateTime(strFromDateNew))
                                    {
                                        ret = "FALSE";
                                    }

                                }
                            }
                        }
                    }

                }

            }
        }
        if (ret == "TRUE")
        {
            objBusinesVehSts.ConfirmVehicleStatus(ObjEntityVehicleStatus);
            ret = "success";
        }
        else if (ret == "FALSE")
        {
            ret = "duplication";
        }

        return ret;

    }

    [WebMethod]
    public string ConfirmVehicleAssignStatus(int strAsgnId, int strUserId)
    {
        string ret = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBussinesLayerVehicleStatusMngmnt objBusinesVehSts = new clsBussinesLayerVehicleStatusMngmnt();
        clsEntityVehicleStatusMngmnt ObjEntityVehicleStatus = new clsEntityVehicleStatusMngmnt();
        ObjEntityVehicleStatus.VehAsignId = strAsgnId;
        ObjEntityVehicleStatus.User_Id = strUserId;
        try
        {
            objBusinesVehSts.ConfirmVehicleStatus(ObjEntityVehicleStatus);
            ret = "success";

        }
        catch
        {
            ret = "failed";
        }
        return ret;

    }
}
