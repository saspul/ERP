<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="gen_Candidate_Id_Generator.aspx.cs" Inherits="HCM_HCM_Master_gen_Candidate_Login_gen_Candidate_Id_Generator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    

    <script>
        function ConfirmSave(obj) {
            var $noCong = jQuery.noConflict();

            $noCong("div#divDdlCandidate input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById('divMessageArea').style.display = "none";
           
            ret = true;
          
            
            if (obj == "save") {
                strEmpId = document.getElementById("<%=ddlcandidate.ClientID%>").value;
                if (strEmpId == "--SELECT CANDIDATE--" || srtEmpId=="") {
                  //  alert('strEmpId');
                    $noCong("div#divDdlCandidate input.ui-autocomplete-input").css("borderColor", "Red");
                    $noCong("div#divDdlCandidate input.ui-autocomplete-input").focus();
                    $noCong("div#divDdlCandidate input.ui-autocomplete-input").select();
                    document.getElementById("<%=ddlcandidate.ClientID%>").focus();
                   // InputDataErrorMsg();
                    //alert('strEmpId');
                    ret = false;
                }
            }


            function InputDataErrorMsg() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

        }
        
          

            return ret;

        }
        

    </script>
     <style type="text/css">
        .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            width: 218px;
            border: 1px solid #B0BECA;
            max-height: 135px;
            overflow-x: auto;
            font-family: Calibri;
        }

            .ui-autocomplete .ui-menu-item {
                border-top: 1px solid #B0BECA;
                display: block;
                padding: 4px 6px;
                color: #353D44;
                cursor: pointer;
                font-family: Calibri;
            }

                .ui-autocomplete .ui-menu-item:first-child {
                    border-top: none;
                    font-family: Calibri;
                }

                .ui-autocomplete .ui-menu-item.ui-state-focus {
                    background-color: #D5E5F4;
                    color: #161A1C;
                    font-family: Calibri;
                }
 
      
    </style>
    

    
    <script type="text/javascript" src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script type="text/javascript" src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script type="text/javascript" src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link rel="stylesheet" href="/css/Autocomplete/jquery-ui.css" />


 <%--   <script src="/JavaScript/jquery-1.8.3.min.js"></script>--%>

     <script type="text/javascript">

         var $noConf = jQuery.noConflict();

         $noConf(window).load(function () {

             $noConf('#cphMain_ddlcandidate').selectToAutocomplete1Letter();
             $noConf("div#divDdlCandidate input.ui-autocomplete-input").focus();

         });

         function Reload()
         {
             $noConf('#cphMain_ddlcandidate').selectToAutocomplete1Letter();
       
         }
         
         function GenCandID() {
           
             var ddlcandidate = document.getElementById("<%=ddlcandidate.ClientID%>").value;
             if (ddlcandidate != "--SELECT CANDIDATE--") {
                 var USERID = '<%=Session["USERID"] %>';
                 var CORPOFFICEID = '<%=Session["CORPOFFICEID"] %>';
                 var ORGID = '<%=Session["ORGID"] %>';

                 $noConf.ajax({
                     type: "POST",
                     url: "gen_Candidate_Id_Generator.aspx/CreateID",
                 data: '{orgID: "' +ORGID + '",corpID: "' +CORPOFFICEID + '",CandID: "' +ddlcandidate + '"}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: OnSuccess,
                 failure: function (response) {
                   
                 }
             });
             }
           
}
function OnSuccess(response) {
  
    document.getElementById("<%=lblcandidateid.ClientID%>").innerText  = response.d;
}

                    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

       <div class="BODYAREA1">
            <asp:HiddenField ID="hiddenCorpList" runat="server" />
             <asp:HiddenField ID="hiddenenxtid" runat="server" />
     
                <div class="loginarea">
                    <div class="logo">
                      
                         <%--<img src="/images/design_images/images/candidatelogin.jpg" class="logo_img" /></a>--%>
                        <%--   <img src="/Images/Design_Images/images/txt.png" class="txt" />--%>
                    </div>
                     <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
                    <div class="LOGIN1">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <h1 style="font-size: 18px; width: 53%; color: darkgray;margin-bottom: 2%;margin-top: -5%; font-family:Calibri;  margin-left: 30%;"">Candidate Id Generation</h1>
                    
                            <div class="eachform" style="margin-top: 6%;margin-left: 10%;">
                                <div id="divDdlCandidate">
                            <h2>Candidate*</h2>
                            <asp:DropDownList ID="ddlcandidate" class="form1"  onchange="GenCandID();" style="width: 56%; text-transform: uppercase; margin-right: 13.8%; height: 30px" runat="server"  onkeypress="return isTag(event);" ></asp:DropDownList>
                            <%--<asp:TextBox ID="txtcandidate" class="form1" Width="75%" runat="server"></asp:TextBox>--%>
</div>
                        </div>
                            <div class="eachfield" style="padding-left: 4%; margin: 27px 0px 10px 26px;float:right;">

                                  <asp:Label ID="lblcandidateid" runat="server" style="float:left; font-family:Calibri; background: white;" Text="Label" ></asp:Label>
                                     </div>
                             
                        <div style="float:left;margin-top: 5%;margin-left: 9%;">
                            <asp:Button ID="btnIdGenerate" runat="server" class="save" Text="Generate Id"  style="float:right" OnClientClick="return ConfirmSave('save');" OnClick="btnIdGenerate_Click" />
                      </div>
                   
                        <div>
                         </div>

                    
               

                    </div>
                </div>
            </div>


<%--            <!-- Trigger/Open The Modal -->

            <!-- The Modal Loading MAIL -->
            <div id="myModalCorpList" class="modalCorpList">
                <%--<div style="background-color: rgb(92, 111, 103); position: absolute; height: 53%; width: 39.5%;">j</div>--%>
              <%--<%--<%--<%--<%--<%--<%--  <div>
                    <!-- Modal content -->
                    <div id="divCorpList" runat="server">

                        <%--   <img src="../../Images/Other Images/LoadingMail.gif" style="width:12%;"  />--%>
                   <%--</div>--%>
                <%--</div>--%>
            <%--</div>--%>


            <%--<div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: rgb(69, 92, 78); filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.8; z-index: 29; height: auto !important;"--%>
                <%--class="freezelayer" id="freezelayer           </div>--%>

           <style>
               .BODYAREA1 {
                   width: 100%;
height: auto;
/*background: url(/../../../Images/Design_Images/images/ulli2/candidatelogin.jpg) no-repeat center top;*/

               }

               .LOGIN1 {
                 width: 500px;
                 /*background: url(/../../../Images/Design_Images/images/ulli2/candidatelogin.jpg) no-repeat center top;*/

    /*background: rgba(17, 17, 17, 0.7);;*/
    display: inline-block;
    padding: 36px 0 38px;
    border: 1px solid #e4e6e8;
background: #FFF;

}
           </style>


          
</asp:Content>


