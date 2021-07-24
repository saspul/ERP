<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit_Sales.master" CodeFile="Compzit_Home_Sales.aspx.cs" Inherits="Home_Compzit_Home_Compzit_Home_Sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">


    <link href="../../css/bootstrap.min.3.3.5.css" rel="stylesheet" />

    <style>
        .bg_ul li {
            /*padding-top:34px;*/
        }

        .ullis {
            padding-bottom: 3px;
        }

        .cont_rght {
            width: 95%;
        }

        .right_circle:hover {
       border: 2px solid #43979b;
box-shadow: 1px 1px 16px 3px rgb(63, 133, 153);

            
             }
        .left_circle:hover {
       border: 2px solid #43979b;
box-shadow: 1px 1px 16px 3px rgb(63, 133, 153);

            
             }
    </style>



    <style>
        .heart {
            font-size: 152px;
            text-align: center;
            /*color: rgba(165, 25, 25, 1);*/
            padding: 0;
            margin: 0;
        }

        .pulse1 {
            -webkit-animation: pulse1 0.5s linear infinite;
            -moz-animation: pulse1 0.5s linear infinite;
            -ms-animation: pulse1 0.5s linear infinite;
            animation: pulse1 0.5s linear infinite;
        }
        /*""134578*/
        @keyframes pulse1 {
            0% {
                color: rgba(165, 25, 25, 1);
            }

            90% {
                color: rgba(255,0,0,0.0);
            }

            100% {
                color: rgba(255,0,0,1.0);
            }
        }

        @-moz-keyframes pulse1 {
            0% {
                color: rgba(165, 25, 25, 1);
            }

            90% {
                color: rgba(255,0,0,0.0);
            }

            100% {
                color: rgba(255,0,0,1.0);
            }
        }

        @-webkit-keyframes pulse1 {
            0% {
                color: rgba(165, 25, 25, 1);
            }

            90% {
                color: rgba(255,0,0,0.0);
            }

            100% {
                color: rgba(255,0,0,1.0);
            }
        }

        @-ms-keyframes pulse1 {
            0% {
                color: rgba(165, 25, 25, 1);
            }

            90% {
                color: rgba(255,0,0,0.0);
            }

            100% {
                color: rgba(255,0,0,1.0);
            }
        }

        .pulse2 {
            -webkit-animation: pulse2 1s linear infinite;
            -moz-animation: pulse2 1s linear infinite;
            -ms-animation: pulse2 1s linear infinite;
            animation: pulse2 1s linear infinite;
        }

        @keyframes pulse2 {
            0% {
                -webkit-transform: scale(1.1);
                -moz-transform: scale(1.1);
                -o-transform: scale(1.1);
                -ms-transform: scale(1.1);
                transform: scale(1.1);
            }

            50% {
                -webkit-transform: scale(0.8);
                -moz-transform: scale(0.8);
                -o-transform: scale(0.8);
                -ms-transform: scale(0.8);
                transform: scale(0.8);
            }

            100% {
                -webkit-transform: scale(1);
                -moz-transform: scale(1);
                -o-transform: scale(1);
                -ms-transform: scale(1);
                transform: scale(1);
            }
        }

        @-moz-keyframes pulse2 {
            0% {
                -moz-transform: scale(1.1);
                transform: scale(1.1);
            }

            50% {
                -moz-transform: scale(0.8);
                transform: scale(0.8);
            }

            100% {
                -moz-transform: scale(1);
                transform: scale(1);
            }
        }

        @-webkit-keyframes pulse2 {
            0% {
                -webkit-transform: scale(1.1);
                transform: scale(1.1);
            }

            50% {
                -webkit-transform: scale(0.8);
                transform: scale(0.8);
            }

            100% {
                -webkit-transform: scale(1);
                transform: scale(1);
            }
        }

        @-ms-keyframes pulse2 {
            0% {
                -ms-transform: scale(1.1);
                transform: scale(1.1);
            }

            50% {
                -ms-transform: scale(0.8);
                transform: scale(0.8);
            }

            100% {
                -ms-transform: scale(1);
                transform: scale(1);
            }
        }
    </style>

    <style>
        #divOpenTask {
            position: relative;
            /*display: inline-block;*/
            box-shadow: 0 1px 2px rgba(0,0,0,0.15);
            transition: all 0.3s ease-in-out;
        }

            #divOpenTask:hover {
                cursor: pointer;
                /*background-color: rgb(75, 155, 132);*/
                box-shadow: 4px 3px 12px 4px rgba(0, 0, 0, 0.2), 0px 3px 10px 0px rgba(0, 0, 0, 0.2);
                transform: scale(1.1, 1.1);
                z-index: 2;
            }

                #divOpenTask:hover::after {
                    opacity: 1;
                }

            #divOpenTask::after {
                content: '';
                position: absolute;
                z-index: -1;
                opacity: 0;
                box-shadow: 0 5px 10px rgba(0,0,0,0.3);
                transition: opacity 0.3s ease-in-out;
            }



        #divAbtToBreach {
            /*background-color: rgb(0, 227, 227);*/
            position: relative;
            /*display: inline-block;*/
            box-shadow: 0 1px 2px rgba(0,0,0,0.15);
            transition: all 0.3s ease-in-out;
        }

            #divAbtToBreach:hover {
                cursor: pointer;
                /*background-color: rgb(49, 161, 161);*/
                box-shadow: 4px 3px 12px 4px rgba(0, 0, 0, 0.2), 0px 3px 10px 0px rgba(0, 0, 0, 0.2);
                transform: scale(1.1, 1.1);
                z-index: 2;
            }

                #divAbtToBreach:hover::after {
                    opacity: 1;
                }

            #divAbtToBreach::after {
                content: '';
                position: absolute;
                z-index: -1;
                opacity: 0;
                box-shadow: 0 5px 15px rgba(0,0,0,0.3);
                transition: opacity 0.3s ease-in-out;
            }


        #divBreachedTask {
            /*background-color: rgb(251, 153, 153);*/
            position: relative;
            /*display: inline-block;*/
            box-shadow: 0 1px 2px rgba(0,0,0,0.15);
            transition: all 0.3s ease-in-out;
        }

            #divBreachedTask:hover {
                cursor: pointer;
                /*background-color: rgb(218, 143, 143);*/
                box-shadow: 4px 3px 12px 4px rgba(0, 0, 0, 0.2), 0px 3px 10px 0px rgba(0, 0, 0, 0.2);
                transform: scale(1.1, 1.1);
                z-index: 2;
            }

                #divBreachedTask:hover::after {
                    opacity: 1;
                }

            #divBreachedTask::after {
                content: '';
                position: absolute;
                z-index: -1;
                opacity: 0;
                box-shadow: 0 5px 15px rgba(0,0,0,0.3);
                transition: opacity 0.3s ease-in-out;
            }

        #divUpcomingTask {
            /*background-color: rgb(255, 218, 14);*/
            position: relative;
            /*display: inline-block;*/
            box-shadow: 0 1px 2px rgba(0,0,0,0.15);
            transition: all 0.3s ease-in-out;
        }

            #divUpcomingTask:hover {
                cursor: pointer;
                /*background-color: rgb(207, 176, 5);*/
                box-shadow: 4px 3px 12px 4px rgba(0, 0, 0, 0.2), 0px 3px 10px 0px rgba(0, 0, 0, 0.2);
                transform: scale(1.1, 1.1);
                z-index: 2;
            }

                #divUpcomingTask:hover::after {
                    opacity: 1;
                }

            #divUpcomingTask::after {
                content: '';
                position: absolute;
                z-index: -1;
                opacity: 0;
                box-shadow: 0 5px 15px rgba(0,0,0,0.3);
                transition: opacity 0.3s ease-in-out;
            }


        .MailView {
            position: relative;
            display: inline-block;
            box-shadow: 0 1px 2px rgba(0,0,0,0.15);
            transition: all 0.3s ease-in-out;
        }

            .MailView::after {
                content: '';
                position: absolute;
                z-index: -1;
                opacity: 0;
                box-shadow: 0 5px 15px rgba(0,0,0,0.3);
                transition: opacity 0.3s ease-in-out;
            }

            /* Scale up the box */
            .MailView:hover {
                transform: scale(1.1, 1.1);
            }

                /* Fade in the pseudo-element with the bigger shadow */
                .MailView:hover::after {
                    opacity: 1;
                }



        #divLeadNew {
            position: relative;
            /*display: inline-block;*/
            box-shadow: 0 1px 2px rgba(0,0,0,0.15);
            transition: all 0.3s ease-in-out;
        }

            #divLeadNew:hover {
                cursor: pointer;
                /*background-color: rgb(75, 155, 132);*/
                box-shadow: 4px 3px 12px 4px rgba(0, 0, 0, 0.2), 0px 3px 10px 0px rgba(0, 0, 0, 0.2);
                transform: scale(1.1, 1.1);
                z-index: 2;
            }

                #divLeadNew:hover::after {
                    opacity: 1;
                }

            #divLeadNew::after {
                content: '';
                position: absolute;
                z-index: -1;
                opacity: 0;
                box-shadow: 0 5px 10px rgba(0,0,0,0.3);
                transition: opacity 0.3s ease-in-out;
            }


        #divLeadApprove {
            position: relative;
            /*display: inline-block;*/
            box-shadow: 0 1px 2px rgba(0,0,0,0.15);
            transition: all 0.3s ease-in-out;
        }

            #divLeadApprove:hover {
                cursor: pointer;
                /*background-color: rgb(75, 155, 132);*/
                box-shadow: 4px 3px 12px 4px rgba(0, 0, 0, 0.2), 0px 3px 10px 0px rgba(0, 0, 0, 0.2);
                transform: scale(1.1, 1.1);
                z-index: 2;
            }

                #divLeadApprove:hover::after {
                    opacity: 1;
                }

            #divLeadApprove::after {
                content: '';
                position: absolute;
                z-index: -1;
                opacity: 0;
                box-shadow: 0 5px 10px rgba(0,0,0,0.3);
                transition: opacity 0.3s ease-in-out;
            }


        #divLeadActive {
            position: relative;
            /*display: inline-block;*/
            box-shadow: 0 1px 2px rgba(0,0,0,0.15);
            transition: all 0.3s ease-in-out;
        }

            #divLeadActive:hover {
                cursor: pointer;
                /*background-color: rgb(75, 155, 132);*/
                box-shadow: 4px 3px 12px 4px rgba(0, 0, 0, 0.2), 0px 3px 10px 0px rgba(0, 0, 0, 0.2);
                transform: scale(1.1, 1.1);
                z-index: 2;
            }

                #divLeadActive:hover::after {
                    opacity: 1;
                }

            #divLeadActive::after {
                content: '';
                position: absolute;
                z-index: -1;
                opacity: 0;
                box-shadow: 0 5px 10px rgba(0,0,0,0.3);
                transition: opacity 0.3s ease-in-out;
            }

        #divMnthConvertedLead {
            position: relative;
            /*display: inline-block;*/
            box-shadow: 0 1px 2px rgba(0,0,0,0.15);
            transition: all 0.3s ease-in-out;
        }

            #divMnthConvertedLead:hover {
                cursor: pointer;
                /*background-color: rgb(75, 155, 132);*/
                box-shadow: 4px 3px 12px 4px rgba(0, 0, 0, 0.2), 0px 3px 10px 0px rgba(0, 0, 0, 0.2);
                transform: scale(1.1, 1.1);
                z-index: 2;
            }

                #divMnthConvertedLead:hover::after {
                    opacity: 1;
                }

            #divMnthConvertedLead::after {
                content: '';
                position: absolute;
                z-index: -1;
                opacity: 0;
                box-shadow: 0 5px 10px rgba(0,0,0,0.3);
                transition: opacity 0.3s ease-in-out;
            }


        #divMnthJunkLead {
            position: relative;
            /*display: inline-block;*/
            box-shadow: 0 1px 2px rgba(0,0,0,0.15);
            transition: all 0.3s ease-in-out;
        }

            #divMnthJunkLead:hover {
                cursor: pointer;
                /*background-color: rgb(75, 155, 132);*/
                box-shadow: 4px 3px 12px 4px rgba(0, 0, 0, 0.2), 0px 3px 10px 0px rgba(0, 0, 0, 0.2);
                transform: scale(1.1, 1.1);
                z-index: 2;
            }

                #divMnthJunkLead:hover::after {
                    opacity: 1;
                }

            #divMnthJunkLead::after {
                content: '';
                position: absolute;
                z-index: -1;
                opacity: 0;
                box-shadow: 0 5px 10px rgba(0,0,0,0.3);
                transition: opacity 0.3s ease-in-out;
            }

        #divClientDecisionPending {
            position: relative;
            /*display: inline-block;*/
            box-shadow: 0 1px 2px rgba(0,0,0,0.15);
            transition: all 0.3s ease-in-out;
        }

            #divClientDecisionPending:hover {
                cursor: pointer;
                /*background-color: rgb(75, 155, 132);*/
                box-shadow: 4px 3px 12px 4px rgba(0, 0, 0, 0.2), 0px 3px 10px 0px rgba(0, 0, 0, 0.2);
                transform: scale(1.1, 1.1);
                z-index: 2;
            }

                #divClientDecisionPending:hover::after {
                    opacity: 1;
                }

            #divClientDecisionPending::after {
                content: '';
                position: absolute;
                z-index: -1;
                opacity: 0;
                box-shadow: 0 5px 10px rgba(0,0,0,0.3);
                transition: opacity 0.3s ease-in-out;
            }
        body {
       
        font-family:Calibri;
        
        }
        .ttd1 {
            padding:0px;
        }
        .ttd2{
            padding:0px;
        }
         .ttd3{
            padding:0px;
        }
          .ttd4{
            padding:0px;
        }
           table {
            border-collapse:separate;
        }
        .btn {
           padding-top: 0%;
padding-bottom: 0%;
padding-right: 7%;
padding-left: 7%;
        }
        .btn-primary {
        
        background-color: #bab82d;
border-color: #f0ff60;
        }
         .btn-primary:hover {        
        background-color: #bab82d;
border-color: #f0ff60;
        }
        .dropdown-toggle.btn-primary {
     background-color: #bab82d;
border-color: #f0ff60;
}
    </style>

    <style>
        .box {
            position: relative;
            display: inline-block;
            /*width: 100px;
            height: 100px;
            border-radius: 5px;
            background-color: #fff;*/
            /*box-shadow: 0 1px 2px rgba(0,0,0,0.15);*/
            transition: all 0.3s ease-in-out;
        }

            .box::after {
                content: '';
                position: absolute;
                z-index: -1;
                /*width: 100%;
                height: 100%;*/
                opacity: 0;
                /*border-radius: 5px;*/
                /*box-shadow: 0 5px 15px rgba(0,0,0,0.3);*/
                transition: opacity 0.3s ease-in-out;
            }

            /* Scale up the box */
            .box:hover {
                transform: scale(1.1, 1.1);
                cursor: pointer;
            }

                /* Fade in the pseudo-element with the bigger shadow */
                .box:hover::after {
                    opacity: 1;
                }
    </style>
    <script>
        function getdetailsMail() {
            window.location = "/Transaction/Compzit_Mailbox/Compzit_Mailbox.aspx";
            return false;
        }
        function getdetailsLead() {
            window.location = "/Transaction/gen_Lead/gen_LeadList.aspx";
            return false;
        }
        function getdetailsOpenTask() {
            window.location = "/Transaction/gen_Lead/gen_TaskManipulation.aspx?T_MODE=O";
            return false;
        }
        function getdetailsAbtToBreach() {
            window.location = "/Transaction/gen_Lead/gen_TaskManipulation.aspx?T_MODE=A";
            return false;
        }
        function getdetailsBreachedTask() {
            window.location = "/Transaction/gen_Lead/gen_TaskManipulation.aspx?T_MODE=B";
            return false;
        }
        function getdetailsUpcomingTask() {
            window.location = "/Transaction/gen_Lead/gen_TaskManipulation.aspx?T_MODE=U";
            return false;
        }


        function getdetailsLeadNew() {
            window.location = "/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=NEW";
            return false;
        }
        function getdetailsLeadApprove() {
            window.location = "/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=APRV";
            return false;
        }
        function getdetailsLeadActive() {
            window.location = "/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=ACTV";
            return false;
        }
        function getdetailsMnthConvertedLead() {
            window.location = "/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=MCNVRTD";
            return false;
        }
        function getdetailsMnthJunkLead() {
            window.location = "/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=MJUNK";
            return false;
        }
        function getdetailsClientDecisionPending() {
            window.location = "/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=DPEND";
            return false;
        }
        function ChangeTeam(intTID,strTeamName)
        {
        
           // alert(intTID);
            TermSelected(intTID, strTeamName)
        }
        function getdetailsApprovalPendingTeamWise() {
            var hiddenMixedTId = document.getElementById('<%=hiddenMixedTeamId.ClientID%>').value;
           // alert(hiddenMixedTId);
            window.location = "/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=APRV_PNDNG-"+hiddenMixedTId+"";
            return false;
        }
        function getdetailsUnreadAllctdMailTeamWise() {
            var hiddenMixedTId = document.getElementById('<%=hiddenMixedTeamId.ClientID%>').value;
           // alert(hiddenMixedTId);
            window.location = "/Home/Compzit_DashboardList/Cmpzit_DashboardMailList.aspx?TID=" + hiddenMixedTId + "";
            return false;
        } 
    </script>
      <script>


          function TermSelected(T_Id,TeamName) {

              //web method for drop down of narrations for common narration
              var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
              var UsrId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
              if (CorpId != '' && CorpId != null && OrgId != '' && OrgId != null && T_Id != '' && T_Id != null && (!isNaN(T_Id)) && UsrId != null && UsrId != '') {
                //  alert(TeamName);
               
                  $.ajax({

                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "Compzit_Home_Sales.aspx/TeamWiseDetails",
                    data: '{corporateId: "' + CorpId + '",organisationId:"' + OrgId + '" ,TeamId:"' + T_Id + '",strUserId:"' + UsrId + '"}',
                    dataType: "json",
                    success: function (data) {

                        if (data.d != '') {
                            document.getElementById("<%=h1MainTeam.ClientID%>").innerHTML = TeamName;
                            document.getElementById("<%=h1MainTeamRespnsvHead.ClientID%>").innerHTML = TeamName;
                            document.getElementById("<%=spanTeamHeadApprvlPndngCount.ClientID%>").innerHTML = "<span id='spanTeamHeadApprvlPndng' onclick=' return getdetailsApprovalPendingTeamWise();' style='cursor:pointer;'>" + data.d.intTeamCountApprovalPendingLead + "</span>";
                            document.getElementById("<%=spanTeamHeadUnreadMailCount.ClientID%>").innerHTML = "<span id='spanTeamHeadUnreadMail' onclick=' return getdetailsUnreadAllctdMailTeamWise();' style='cursor:pointer;'>" + data.d.intTeamCountUnReadAttchMail + "</span>";

                            document.getElementById("<%=hiddenMixedTeamId.ClientID%>").value = data.d.strTeamMixedId;

                        }
                    },
                    error: function (result) {
                        // alert("Error");
                    }
                });

            }
        }

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
     <asp:HiddenField ID="hiddenMixedTeamId" runat="server" />
      <asp:HiddenField ID="hiddenUserId" runat="server" />
        <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
        <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <%--    <div style="position:relative;">
       <img class="box" src="../../Images/Icons/corner-ribbon.png"  onclick="getdetailsLead();" alt="ViewMail" style="position: absolute; margin-left: -11.5%;width: 12.1%;">
    <div style="width: 40%; float: left; font-family: Calibri; border: 1px solid rgb(161, 203, 172); padding: 0.25%; background: rgb(222, 239, 226) none repeat scroll 0% 0%; box-shadow: 1px 4px 8px 4px rgba(0, 0, 0, 0.2), 0px 6px 20px 0px rgba(0, 0, 0, 0.19);">
     
        <div style="height: 50px; float: left; width: 50%; background-color: rgb(0, 221, 158);">
            <p style="font-size: 11px; width: 100%; color: rgb(255, 255, 255); background-color: rgb(83, 83, 83); opacity: 0.7;"><span style="padding-left: 2%;">NUMBER OF NEW LEADS</span></p>
            <p id="pCountNewLead" runat="server" style="text-align: center; font-size: 20px; font-weight: bold; margin-top: 1.5%; color: white;">0</p>
        </div>
        <div style="background-color: rgb(0, 227, 227); height: 50px; width: 50%; float: left;">
            <p style="font-size: 11px; width: 100%; color: rgb(255, 255, 255); background-color: rgb(83, 83, 83); opacity: 0.7;"><span style="padding-left: 2%;">NUMBER OF APPROVED LEADS</span></p>
            <p id="pCountApprovedLead" runat="server" style="text-align: center; font-size: 20px; font-weight: bold; margin-top: 1.5%; color: white;">0</p>
        </div>
        <div style="height: 50px; float: left; width: 100%; background-color: rgb(255, 218, 14);">
            <p style="font-size: 11px; width: 100%; color: rgb(255, 255, 255); background-color: rgb(83, 83, 83); opacity: 0.7;"><span style="padding-left: 2%;">NUMBER OF ACTIVE LEADS</span></p>
            <p id="pCountActiveLead" runat="server" style="text-align: center; font-size: 20px; font-weight: bold; margin-top: 1.5%; color: white;">0</p>
        </div>
        <div style="width: 100%; float: left; height: 25px; background-color: rgb(44, 72, 171); text-align: center; color: white; font-weight: bold;">
            <p style="margin-top: 1%; font-size: 13px;">MONTHLY CONVERSION</p>

        </div>
        <div style="width: 25%; float: left; height: 100px; background-color: rgb(151, 200, 58);">
            <p style="font-size: 11px; width: 100%; color: rgb(255, 255, 255); background-color: rgb(83, 83, 83); opacity: 0.7;"><span style="padding-left: 2%;">NUMBER OF CONVERTED LEADS</span></p>
            <p id="pCountConvertedLead" runat="server" style="text-align: center; font-size: 20px; font-weight: bold; margin-top: 17.5%; color: white;">0</p>
        </div>
        <div style="width: 25%; height: 100px; float: left; background-color: rgb(255, 77, 77);">
            <p style="font-size: 11px; width: 100%; color: rgb(255, 255, 255); background-color: rgb(83, 83, 83); opacity: 0.7;"><span style="padding-left: 2%;">NUMBER OF JUNK LEADS</span></p>
            <p id="pCountLostLead" runat="server" style="text-align: center; font-size: 20px; font-weight: bold; margin-top: 17.5%; color: white;">0</p>
        </div>
        <div style="float: left; width: 50%; height: 50px; background-color: rgb(151, 200, 58);">
            <p style="font-size: 11px; width: 100%; color: rgb(255, 255, 255); background-color: rgb(83, 83, 83); opacity: 0.7;"><span style="padding-left: 2%;">CONVERSION %</span></p>
            <p id="pCountConversionPerc" runat="server" style="text-align: center; font-size: 20px; font-weight: bold; margin-top: 2.5%; color: white;">0.0%</p>
        </div>
        <div style="float: left; height: 50px; width: 50%; background-color: rgb(245, 147, 0);">
            <p style="font-size: 11px; width: 100%; color: rgb(255, 255, 255); background-color: rgb(83, 83, 83); opacity: 0.7;"><span style="padding-left: 2%;">LOST %</span></p>
            <p id="pCountLostPerc" runat="server" style="text-align: center; font-size: 20px; font-weight: bold; margin-top: 2.5%; color: white;">0.0%</p>
        </div>
    </div>
        </div>--%>







    <%-- <div style="width: 40%; float: left; font-family: Calibri; border: 1px solid rgb(161, 203, 172); padding: 0.25%; background: rgb(222, 239, 226) none repeat scroll 0% 0%; box-shadow: 1px 4px 8px 4px rgba(0, 0, 0, 0.2), 0px 6px 20px 0px rgba(0, 0, 0, 0.19); margin-top: 2.5%; margin-left: 10%;">

        <div id="divOpenTask" onclick="getdetailsOpenTask();" style="height: 100px; float: left; width: 25%;">
            <p style="font-size: 11px; width: 100%; color: rgb(255, 255, 255); background-color: rgb(83, 83, 83); opacity: 0.7;"><span style="padding-left: 2%;">TASKS OPEN</span></p>
            <p id="pCountOpenTask" runat="server" style="text-align: center; font-size: 20px; font-weight: bold; margin-top: 25.5%; color: white;">0</p>
        </div>
        <div id="divAbtToBreach" onclick="getdetailsAbtToBreach();" style="height: 50px; width: 50%; float: left;">
            <p style="font-size: 11px; width: 100%; color: rgb(255, 255, 255); background-color: rgb(83, 83, 83); opacity: 0.7;"><span style="padding-left: 2%;">TASK ABOUT TO BREACH</span></p>
            <span id="spanCountAbtToBreachTask" runat="server" style="text-align: center; font-size: 20px; font-weight: bold; color: white;">0</span>
        </div>
        <div id="divBreachedTask" onclick="getdetailsBreachedTask();" style="height: 50px; width: 50%; float: left;">
            <p style="font-size: 11px; width: 100%; color: rgb(255, 255, 255); background-color: rgb(83, 83, 83); opacity: 0.7;"><span style="padding-left: 2%;">TASK BREACHED</span></p>
            <span id="spanCountBreachedTask" runat="server" style="text-align: center; font-size: 20px; font-weight: bold; color: white;">0</span>
        </div>
        <div id="divUpcomingTask" onclick="getdetailsUpcomingTask();" style="height: 100px; width: 25%; float: right; margin-top: -50px;">
            <p style="font-size: 11px; width: 100%; color: rgb(255, 255, 255); background-color: rgb(83, 83, 83); opacity: 0.7;"><span style="padding-left: 2%;">UPCOMING TASKS</span></p>
            <p id="pCountUpcomingTask" runat="server" style="text-align: center; font-size: 20px; font-weight: bold; margin-top: 25.5%; color: white;">0</p>
        </div>


    </div>--%>

    <%--//////////////////////////////////////--%>

    <div class="new_tables">
        <div id="divDashboardLead" runat="server" class="leads_table_area">
            <h1>My Leads</h1>
            <a href="/Transaction/gen_Lead/gen_LeadList.aspx">
                <img src="../../Images/Other Images/leads_more.gif" class="leads_more" /></a>
            <div style="clear: both"></div>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <th class="lth1" id="divLeadNew" onclick="getdetailsLeadNew();" style="cursor: pointer;">
                        <img src="../../Images/Other Images/leads_new.gif" /><h2>Number of New Leads</h2>
                    </th>
                    <th class="lth2" id="divLeadApprove" onclick="getdetailsLeadApprove();" style="cursor: pointer;">
                        <img src="../../Images/Other Images/leads_approve.gif" /><h2>Number of Approved Leads</h2>
                    </th>
                    <th class="lth3" id="divLeadActive" onclick="getdetailsLeadActive();" style="cursor: pointer;">
                        <img src="../../Images/Other Images/leads_active.gif" /><h2>Number of Active Leads</h2>
                    </th>
                </tr>
                <tr>
                    <td class="ld1">
                        <h3 id="h3NoNewLead" runat="server">0</h3>
                    </td>
                    <td class="ld2">
                        <h3 id="h3NoApprovedLead" runat="server">0</h3>
                    </td>
                    <td class="ld3">
                        <h3 id="h3NoActiveLead" runat="server">0</h3>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divDashboardMnthlyLead" runat="server" class="monthly_table_area">
            <h1>Monthly Conversion</h1>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <th class="mth1" id="divMnthConvertedLead" onclick="getdetailsMnthConvertedLead();" style="cursor: pointer;">
                        <img src="../../Images/Other Images/monthly_leads.gif" /><h2>Number of Leads Won</h2>
                    </th>
                    <th class="mth2" id="divMnthJunkLead" onclick="getdetailsMnthJunkLead();" style="cursor: pointer;">
                        <img src="../../Images/Other Images/monthly_junk.gif" /><h2>Number of Leads Lost</h2>
                    </th>
                    <th class="mth3">
                        <img src="../../Images/Other Images/monthly_covert.gif" /><h2>Win %</h2>
                    </th>
                    <th class="mth4">
                        <img src="../../Images/Other Images/monthly_loss.gif" /><h2>Lost %</h2>
                    </th>
                </tr>
                <tr>
                    <td class="md1">
                        <h3 id="h3NoCnvrsnLead" runat="server">0</h3>
                    </td>
                    <td class="md2">
                        <h3 id="h3NoJunkLead" runat="server">0</h3>
                    </td>
                    <td class="md3">
                        <h3 id="h3ConvrsnPerc" runat="server">0.00%</h3>
                    </td>
                    <td class="md4">
                        <h3 id="h3LossPerc" runat="server">0.00%</h3>
                    </td>
                </tr>
            </table>
        </div>
        <div style="clear: both"></div>
        <div id="divDashboardTask" runat="server" class="task_table_area">
            <h1>Task</h1>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <th class="tth1" id="divOpenTask" onclick="getdetailsOpenTask();" style="cursor: pointer;">
                        <img src="../../Images/Other Images/task_open.gif" /><h2>Tasks Open</h2>
                    </th>
                    <th class="tth2" id="divAbtToBreach" onclick="getdetailsAbtToBreach();" style="cursor: pointer;">
                        <img src="../../Images/Other Images/task_brnch.gif" /><h2>Tasks About To Breach</h2>
                    </th>
                    <th class="tth3" id="divBreachedTask" onclick="getdetailsBreachedTask();" style="cursor: pointer;">
                        <img src="../../Images/Other Images/task_brnchd.gif" /><h2>Tasks Breached</h2>
                    </th>
                    <th class="tth4" id="divUpcomingTask" onclick="getdetailsUpcomingTask();" style="cursor: pointer;">
                        <img src="../../Images/Other Images/task_upcoming.gif" /><h2>Upcoming Tasks</h2>
                    </th>
                </tr>
                <tr>
                    <td class="ttd1">
                        <h3 id="h3TaskOpen" runat="server">0</h3>
                    </td>
                    <td class="ttd2">
                        <h3 id="h3TaskAbtToBreach" runat="server">0</h3>
                    </td>
                    <td class="ttd3">
                        <h3 id="h3TaskBreached" runat="server">0</h3>
                    </td>
                    <td class="ttd4">
                        <h3 id="h3TaskUpcoming" runat="server">0</h3>
                    </td>
                </tr>
            </table>
        </div>


        <div id="divDashboardMail" runat="server" style="float: left; margin-left: 11.5%; width: 19.5%; font-family: Calibri; box-shadow: 1px 4px 8px 4px rgba(0, 0, 0, 0.2), 0px 6px 20px 0px rgba(0, 0, 0, 0.19); margin-top: 4.3%;">

            <div class="MailView" style="background: rgb(0, 128, 0) none repeat scroll 0% 0%; width: 100%; cursor: pointer;" onclick="getdetailsMail();">
                <div style="float: left; height: 81px; width: 30%; padding-top: 11%; padding-left: 5%;">
                    <img src="../../Images/Icons/mail3.png" alt="Mails" height="30" width="40">
                </div>
                <div style="float: left; height: 81px; width: 65%; padding-top: 10%; ">
                    <span id="spanCountUnreadMail" runat="server" style="text-align: center; color: white; font-size: 20px; font-weight: bold;">0</span>
                    <p style="text-align: center; color: white; font-size: 15px;">Un-Read Messages</p>
                </div>
            </div>
            <div style="float: left; height: 23px; width: 100%; background-color: rgb(238, 237, 237); color: rgb(0, 128, 0); margin-top: -2%;">
                <span style="padding-left: 5%;">View Details </span>
                <img src="../../Images/Icons/greenArrowIcon2.png" alt="ViewMail" style="float: right; padding-right: 5%; padding-top: 2%;">
            </div>
        </div>

        <div id="divDashboardClientApprvl" runat="server" style="float: left; margin-left: 1.8%; width: 19.5%; font-family: Calibri; box-shadow: 1px 4px 8px 4px rgba(0, 0, 0, 0.2), 0px 6px 20px 0px rgba(0, 0, 0, 0.19); margin-top: 4.3%;">
            <div id="divClientDecisionPending" onclick="getdetailsClientDecisionPending();" style="float: left; height: 81px; width: 100%; padding-top: 12%; background: rgb(42, 89, 135) none repeat scroll 0% 0%;">
                <h3 id="h3NoClientApprvl" runat="server" style="text-align: center; color: white; font-size: 20px; font-weight: bold;">0</h3>
                <p style="text-align: center; color: white; font-size: 15px;">Client Decision Pending</p>
            </div>
            <div style="float: left; height: 23px; width: 100%; background-color: rgb(238, 237, 237); color: rgb(0, 128, 0);">
              
            </div>
        </div>




         <div class="starpage" id="divTeamHead" runat="server" style="width: 60%; display:none;">
                	<div class="star_outer_circle" style="background:url(/Images/DashboardDivisionManager/star_bg_2.png);margin:0;"> 
                    <!-- write code for background  as url(images/star_bg_<?=no.of branches?>.png)-->
                    
                            
                            
                            
                            <div class="main_circle2">  <!-- this block will be displayed on top on small screens --> 
                                <h1 id="h1MainTeamRespnsvHead" runat="server">Division Name</h1>	<!-- pls give the division name  here also -->
                                <div id="divMultipleTeamRespnsvHead" runat="server" style="margin-left: 44%; margin-top: -10.5%;"></div>	
                               </div>
                            
                            
                            
                        <div class="circle_row">
                            <div class="top_left_circle" id="Div8" style="opacity:0"><!-- opacity:0, if no. of branches= 1, 2, 3, 4, or 5 -->
                                <h1><span>12</span><br /> unread mails</h1>
                            </div>
                            <div class="top_circle" id="Div9" style="opacity:0"><!-- opacity:0, if no. of branches= 1, 2, or 6 -->
                                <h1><span>12</span><br /> approvals pending</h1>
                            </div>
                            <div class="top_right_circle" id="Div10" style="opacity:0"><!-- opacity:0, if no. of branches= 1, 2, 3, 4, or 5 -->
                                <h1><span>12</span><br /> approvals pending</h1>	
                            </div>
                        </div>
                        <div class="circle_row">
                            <div class="left_circle" id="Div11" style="opacity:1"><!-- opacity:0, if no. of branches= 1, or 3 -->
                                <h1><span id="spanTeamHeadUnreadMailCount" runat="server">0</span><br /> Unattended Mails</h1>
                            </div>
                            <div class="main_circle">
                                <h1 id="h1MainTeam" runat="server">Division Name</h1>	
                                  <div id="divMultipleTeam" runat="server" style="margin-left: 44%; margin-top: -18%;"></div>	
                            </div>
                            <div class="right_circle" id="Div12" style="opacity:1"><!-- opacity:0, if no. of branches= 1, or 3 -->
                                <h1><span id="spanTeamHeadApprvlPndngCount" runat="server">0</span><br /> Approval Pending Lead</h1>	
                            </div>
                        </div>
                        <div class="circle_row">
                            <div class="bottom_left_circle" id="Div13" style="opacity:0"><!-- opacity:0, if no. of branches= 1, 2, or 4 -->
                                <h1><span>12</span><br /> approvals pending</h1>
                            </div>
                            <div class="bottom_circle" id="Div14" style="opacity:0"><!-- opacity:0, if no. of branches= 1, 2, or 4 -->
                                <h1><span>12</span><br /> approvals pending</h1>	
                            </div>
                            <div class="bottom_right_circle" id="Div15" style="opacity:0"><!-- opacity:0, if no. of branches= 2,3  5, 6 or 7 -->
                                <h1><span>12</span><br /> approvals pending</h1>	
                            </div>
                        </div>
                    </div>
                </div>





    </div>



</asp:Content>

