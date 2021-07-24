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
/// Summary description for WebServiceJobshdlData
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebServiceJobshdlData : System.Web.Services.WebService {

    public WebServiceJobshdlData () {

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

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetTimeDutyrstr(string strLikeTime, string strStartTime, string strStopTime, int strHalfTime, int strHalfSec)
    {
        List<string> li_Time = new List<string>();
        clsBusinessLayerJobShdl objBusinessLayerJobSheduling = new clsBusinessLayerJobShdl();
        clsEntityLayerJobScheduleDtl objEntityJobShedulingDtl = new clsEntityLayerJobScheduleDtl();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (strStartTime != "" && strStopTime != "")
        {

            string strFromDatetime = Convert.ToString("01-01-1000-" + strStartTime);
            DateTime dtFromTime = Convert.ToDateTime(strFromDatetime);
            string strToDatetime = Convert.ToString("01-01-1000-" + strStopTime);
            DateTime dtToTime = Convert.ToDateTime(strToDatetime);

            if (strHalfSec == 2)
            {
                dtFromTime = dtFromTime.AddMinutes(strHalfTime);
            }
            else if (strHalfSec == 3)
            {
                dtToTime = dtFromTime.AddMinutes(strHalfTime);
               
            }

            string strFinalFrom = dtFromTime.ToString();
            string[] elem = strFinalFrom.Split(' ');
            string[] elem1 = elem[1].Split(':');
            if (elem1[0].Length < 2)
            {
                 elem1[0] = "0" + elem1[0];
             }           
            strFinalFrom = elem1[0] +":"+ elem1[1] +" "+elem[2];

            
                       
            string strFinalTo = dtToTime.ToString();
            elem = strFinalTo.Split(' ');
            elem1 = elem[1].Split(':');
            if (elem1[0].Length < 2)
            {
                elem1[0] = "0" + elem1[0];
            }  
            strFinalTo = elem1[0] +":"+ elem1[1] + " " + elem[2];



            string strFromDatetime1 = Convert.ToString("01-01-1000-" + strFinalFrom);
            DateTime dtFromTime1 = Convert.ToDateTime(strFromDatetime1);
            string strToDatetime1 = Convert.ToString("01-01-1000-" + strFinalTo);
            DateTime dtToTime1 = Convert.ToDateTime(strToDatetime1);



            objEntityJobShedulingDtl.FromTime = dtFromTime1;
            objEntityJobShedulingDtl.ToTime = dtToTime1;
            objEntityJobShedulingDtl.FromTimeString = strFinalFrom;
            objEntityJobShedulingDtl.ToTimeString = strFinalTo;
            if (dtFromTime1 > dtToTime1)
            {
                objEntityJobShedulingDtl.TimeDiffrncSts = 1;
            }
            else
            {

                objEntityJobShedulingDtl.TimeDiffrncSts = 0;
            }

            DataTable dtTimes = objBusinessLayerJobSheduling.ReadTimeListWebService(strLikeTime.ToUpper(), objEntityJobShedulingDtl);


            for ( int intRowCount = 0; intRowCount < dtTimes.Rows.Count; intRowCount++)
            {
                li_Time.Add(string.Format("{0}<->{1}<->{2}", dtTimes.Rows[intRowCount]["TIMELIST_TIME"].ToString(), dtTimes.Rows[intRowCount]["TIMELIST_ID"].ToString(), objEntityJobShedulingDtl.TimeDiffrncSts));
            }
        }
        return li_Time.ToArray();

    }

}
