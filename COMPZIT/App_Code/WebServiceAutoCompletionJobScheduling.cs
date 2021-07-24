using BL_Compzit;
using BL_Compzit.BusinessLayer_AWMS;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for WebServiceAutoCompletionJobScheduling
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebServiceAutoCompletionJobScheduling : System.Web.Services.WebService {

    public WebServiceAutoCompletionJobScheduling () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetJob(string strLikeJobName, int intOrgId, int intCorpId)
    {
        List<string> li_Job = new List<string>();
        clsBusinessLayerJobShdl objBusinessLayerJobSheduling = new clsBusinessLayerJobShdl();
        clsEntityLayerJobSchedule objEntityJobSheduling = new clsEntityLayerJobSchedule();
        objEntityJobSheduling.Organisation_Id = intOrgId;
        objEntityJobSheduling.CorpOffice_Id = intCorpId;

        DataTable dtJobs = objBusinessLayerJobSheduling.ReadJobsWebService(strLikeJobName.ToUpper(), objEntityJobSheduling);

        for (int intRowCount = 0; intRowCount < dtJobs.Rows.Count; intRowCount++)
        {
            li_Job.Add(string.Format("{0}<->{1}", dtJobs.Rows[intRowCount]["JOBMSTR_TITLE"].ToString(), dtJobs.Rows[intRowCount]["JOBMSTR_ID"].ToString()));
        }

        return li_Job.ToArray();

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetVehicle(string strLikeVehicleNumbr, int intOrgId, int intCorpId)
    {
        List<string> li_Vehicle = new List<string>();
        clsBusinessLayerJobShdl objBusinessLayerJobSheduling = new clsBusinessLayerJobShdl();
        clsEntityLayerJobSchedule objEntityJobSheduling = new clsEntityLayerJobSchedule();
        objEntityJobSheduling.Organisation_Id = intOrgId;
        objEntityJobSheduling.CorpOffice_Id = intCorpId;

        DataTable dtVehicles = objBusinessLayerJobSheduling.ReadVehiclesWebService(strLikeVehicleNumbr.ToUpper(), objEntityJobSheduling);


        for (int intRowCount = 0; intRowCount < dtVehicles.Rows.Count; intRowCount++)
        {
            li_Vehicle.Add(string.Format("{0}<->{1}", dtVehicles.Rows[intRowCount]["VHCL_NUMBR"].ToString(), dtVehicles.Rows[intRowCount]["VHCL_ID"].ToString()));
        }

        return li_Vehicle.ToArray();

    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetProject(string strLikeProjectName, int intOrgId, int intCorpId)
    {
        List<string> li_Project = new List<string>();
        clsBusinessLayerJobShdl objBusinessLayerJobSheduling = new clsBusinessLayerJobShdl();
        clsEntityLayerJobSchedule objEntityJobSheduling = new clsEntityLayerJobSchedule();
        objEntityJobSheduling.Organisation_Id = intOrgId;
        objEntityJobSheduling.CorpOffice_Id = intCorpId;

        DataTable dtProjects = objBusinessLayerJobSheduling.ReadProjectsWebService(strLikeProjectName.ToUpper(), objEntityJobSheduling);


        for (int intRowCount = 0; intRowCount < dtProjects.Rows.Count; intRowCount++)
        {
            li_Project.Add(string.Format("{0}<->{1}", dtProjects.Rows[intRowCount]["PROJECT_NAME"].ToString(), dtProjects.Rows[intRowCount]["PROJECT_ID"].ToString()));
        }

        return li_Project.ToArray();

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetTime(string strLikeTime, string strStartTime, string strStopTime)
    {
        List<string> li_Time = new List<string>();
        clsBusinessLayerJobShdl objBusinessLayerJobSheduling = new clsBusinessLayerJobShdl();
        clsEntityLayerJobScheduleDtl objEntityJobShedulingDtl = new clsEntityLayerJobScheduleDtl();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (strStartTime != "" && strStopTime != "")
        {

            string strFromDatetime = Convert.ToString("01-01-1000-" + strStartTime);
            DateTime dtFromTime = objCommon.textWithTimeToDateTime(strFromDatetime);
            string strToDatetime = Convert.ToString("01-01-1000-" + strStopTime);
            DateTime dtToTime = objCommon.textWithTimeToDateTime(strToDatetime);
            objEntityJobShedulingDtl.FromTime = dtFromTime;
            objEntityJobShedulingDtl.ToTime = dtToTime;
            objEntityJobShedulingDtl.FromTimeString = strStartTime;
            objEntityJobShedulingDtl.ToTimeString = strStopTime;
            if (dtFromTime > dtToTime)
            {
                objEntityJobShedulingDtl.TimeDiffrncSts = 1;
            }
            else
            {

                objEntityJobShedulingDtl.TimeDiffrncSts = 0;
            }

            DataTable dtTimes = objBusinessLayerJobSheduling.ReadTimeListWebService(strLikeTime.ToUpper(), objEntityJobShedulingDtl);


            for (int intRowCount = 0; intRowCount < dtTimes.Rows.Count; intRowCount++)
            {
                li_Time.Add(string.Format("{0}<->{1}<->{2}", dtTimes.Rows[intRowCount]["TIMELIST_TIME"].ToString(), dtTimes.Rows[intRowCount]["TIMELIST_ID"].ToString(), objEntityJobShedulingDtl.TimeDiffrncSts));
            }
        }
        return li_Time.ToArray();

    }
}
