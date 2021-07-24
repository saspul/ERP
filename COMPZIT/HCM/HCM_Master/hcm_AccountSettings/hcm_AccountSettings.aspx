<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_AccountSettings.aspx.cs" Inherits="HCM_HCM_Master_hcm_AccountSettings_hcm_AccountSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
      <style>
        #divMessageAreaMain {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: -2%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }
        </style> 
    <script>
   
        function LoadLeaveDetails() {
            document.getElementById('loading').style.display = "block";
            var OrgId = '<%= Session["ORGID"] %>';
            var CorpId = '<%= Session["CORPOFFICEID"] %>';
            if (OrgId != "" && CorpId != "") {
                $.ajax({
                    type: "POST",
                    url: "hcm_AccountSettings.aspx/LoadLeaveDetails",
                    data: '{OrgId: "' + OrgId + '",CorpId:"' + CorpId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        

                        if (response.d == "True")
                        {

                            document.getElementById('loading').style.display = "none";
                            setInterval(LoadSucess(), 2000)

                                              

                        }

                    },
                    failure: function (response) {


                    }
                });
            }

            return false;

        }
        function LoadSucess() {
           
            document.getElementById('divMessageAreaMain').style.display = "block";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Employee leave details inserted successfully.";

        }
        
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

        <div id="divReportCaption" runat="server" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <img src="/Images/BigIcons/accnt_sttng.png" style="vertical-align: middle;" />
     <asp:Label ID="lblEntry" runat="server"></asp:Label>
        </div >
    <div id="divMessageAreaMain" style="display:none;width:90%;margin-left:0%;">
                 <img id="imgMessageAreaMain" style="float:left"  src="" />
                 <asp:Label ID="LblMessageAreaMain" runat="server"></asp:Label>
          </div>
    <br />
    <br />
            <div style="float: left;width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: #fff; float: left">

  
              <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
    <ContentTemplate>--%>
          <asp:Button ID="btnAdd" runat="server" class="save" Text="Load Leave Details" OnClientClick="return LoadLeaveDetails();" />
      
     <%--   <label id="Label_For_Server_Time" runat="server"></label>
        <progress id ="pp"  runat="server" ></progress>--%>
<%--    </ContentTemplate>
</asp:UpdatePanel>--%>
               
              <%--  <progress id="progressbar"  max="100"></progress>--%>

                </div>
                                   	 <div id="loading" style="display:none;">
                                    
       <img src="/Images/Other%20Images/loading.gif" style="width: 12%; margin-left: 46%; margin-top: 4%;" />

    </div>
</asp:Content>

