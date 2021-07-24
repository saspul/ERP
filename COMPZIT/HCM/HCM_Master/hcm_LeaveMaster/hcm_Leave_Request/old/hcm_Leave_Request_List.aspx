<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Leave_Request_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_OnBoarding_hcm_Leave_Management_hcm_Leave_Management_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
            <style>
         /*--------------------------------------------------for modal Cancel Reason------------------------------------------------------*/
        .modalCancelView {
             display: none; /* Hidden by default */
             position: fixed; /* Stay in place */
             z-index: 30; /* Sit on top */
             padding-top: 0%; /* Location of the box */
             left: 23%;
             top: 30%;
             width: 50%; /* Full width */
             /*height: 58%;*/ /* Full height */
             overflow: auto; /* Enable scroll if needed */
             background-color: transparent;
         }


         /* Modal Content */
         .modal-CancelView {
             /*position: relative;*/
             background-color: #fefefe;
             margin: auto;
             padding: 0;
             /*border: 1px solid #888;*/
             width: 95.6%;
             box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
         }


         /* The Close Button */
         .closeCancelView {
             color: white;
             float: right;
             font-size: 28px;
             font-weight: bold;
         }

             .closeCancelView:hover,
             .closeCancelView:focus {
                 color: #000;
                 text-decoration: none;
                 cursor: pointer;
             }

         .modal-headerCancelView {
             /*padding: 1% 1%;*/
            background-color: #91a172;
             color: white;
         }

         .modal-bodyCancelView {
             padding: 4% 4% 7% 4%;
         }

         .modal-footerCancelView {
             padding: 2% 1%;
           background-color: #91a172;
             color: white;
         }
         #divErrorRsnAWMS {
    border-radius: 4px;
    background: #fff;
    color: #53844E;
    font-size: 12.5px;
    font-family: Calibri;
    font-weight: bold;
    border: 2px solid #53844E;
    margin-top: -3.5%;
    margin-bottom: 2%;
}

     </style>
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
  
    <script src="../../../../JavaScript/jquery-1.8.3.min.js"></script>
   
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {

              document.getElementById("freezelayer").style.display = "none";
              document.getElementById('MymodalCancelView').style.display = "none";
              var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
              if (CancelPrimaryId != "") {
                  OpenCancelView();
              }
          });


          </script>
     <script type="text/javascript">
         var $Mo = jQuery.noConflict();

         function OpenCancelView() {



             document.getElementById("MymodalCancelView").style.display = "block";
             document.getElementById("freezelayer").style.display = "";
             document.getElementById("<%=txtCnclReason.ClientID%>").focus();

             return false;

         }
         function CloseCancelView() {
             if (confirm("Do you want to close  without completing cancellation process?")) {
                 document.getElementById('divMessageArea').style.display = "none";
                 document.getElementById('imgMessageArea').src = "";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                 document.getElementById("MymodalCancelView").style.display = "none";
                 document.getElementById("freezelayer").style.display = "none";
                 document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
             }
         }



    </script>
    <style>

        #cphMain_btnNext.aspNetDisabled {
            width: 202px;
            height: 33px;
            margin-top: -5px;
            font-size: 13px;
            cursor: default;
        }
        #cphMain_btnPrevious.aspNetDisabled {
            width: 202px;
            height: 33px;
            margin-top: -5px;
            font-size: 13px;
            cursor: default;
        }
        .searchlist_btn_rght {
            cursor: pointer;
        }
           input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
        }
        #a_Caption:hover {
        color: rgb(83, 101, 51);
        
        }
        #a_Caption {
        color: rgb(88, 134, 7);
        
        }
        #a_Caption:focus {
        color: rgb(83, 101, 51);
        
        }
         .searchlist_btn_lft:hover {
        background:url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        
        }
        .searchlist_btn_lft:focus {
        background:url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        
        }
        input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
            cursor:default;
        }
         .searchlist_btn_rght:hover {
                background: #7B866A;
            }
             .searchlist_btn_rght:focus {
                background: #7B866A;
            }
    </style>



    <script type="text/javascript">



        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave request details inserted successfully.";
        }

        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave request details updated successfully.";
        }

        function SuccessCancelation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave request cancelled successfully.";
         }
         function SuccessRecall() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave request recalled successfully.";
        }

        function SuccessReOpen() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave request re-opened successfully.";
        }
        function getdetails(href) {
            window.location = href;
            return false;
        }

        function CancelAlert(href) {

            if (confirm("Do you want to cancel this entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }
        function ReCallAlert(href) {

            if (confirm("Do you want to recall this entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }

        function ReOpenAlert() {

            if (confirm("Do you want to re-open this entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }

        function CancelNotPossible() {
            alert("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
            return false;
        }
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }
        function SearchValidation() {
           
        }
        // }

        // for not allowing <> tags
        function isTag(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }
        function DisableEnter(evt) {
            //  var b = new Date(); alert(b);

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }
        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }


        </script>

      <%--  for giving pagination to the html table--%>
    <script src="../../../../JavaScript/JavaScriptPagination1.js"></script>
    <script src="../../../../JavaScript/JavaScriptPagination2.js"></script>
    <link href="../../../../css/StyleSheetPagination.css" rel="stylesheet" />

    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true
            });
        });


            </script>



    <style>
        #cphMain_divReport {
            float: left;
            width: 93.5%;
        }

       

        #TableRprtRow .tdT {
            line-height: 100%;
        }


        .cont_rght {
            width: 98%;
        }
    </style>

     <script>
        
         //validation when cancel process
         function ValidateCancelReason() {
             // replacing < and > tags
             var NameWithoutReplace = document.getElementById("<%=txtCnclReason.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtCnclReason.ClientID%>").value = replaceText2;

             var divErrorMsg = document.getElementById('divErrorRsnAWMS').style.visibility = "hidden";
             var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "";
             var Reason = document.getElementById("<%=txtCnclReason.ClientID%>").value.trim();
             if (Reason == "") {
                 document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                 document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Please fill this out";
                 document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                 return false;
             }
             else {
                 Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                 Reason = Reason.replace(/[ ]{2,}/gi, " ");
                 Reason = Reason.replace(/\n /, "\n");
                 if (Reason.length < "10") {
                     document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                     document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Cancel reason should be minimum 10 characters";
                     var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                     return false;
                 }
             }
         }

         function LeavRqstId(id) {

             var nWindow = window.open('/HCM/HCM_Master/hcm_LeaveMaster/hcm_Leave_Request/hcm_Leave_Request.aspx?Id=' + id + '&RFGP=VW', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
             // nWindow.focus();
         }

         function LeavRqstExpId(id) {

             var nWindow = window.open('/HCM/HCM_Master/hcm_LeaveMaster/hcm_Leave_Request/hcm_Leave_Request.aspx?Id=' + id + '&RFGP=VW&Sts=Exp', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
             // nWindow.focus();
         }

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <br />
    
     <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <%--<asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />--%>



    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>

            <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">

            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <img src="/Images/BigIcons/Leave Request.png" style="vertical-align: middle;"  />   <asp:Label ID="lblEntry" runat="server">Leave Request</asp:Label>
            </div>
   <%--0006 start--%>
        <br/>
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 93.5%;margin-top:0.5%;height:10%;">

             <div class="eachform" style="width: 20% ;float: left;margin-top:1.5%;margin-left:1%;">
            <h2 style="margin-top: 0.5%;margin-left: 0%;">Status</h2>

            <asp:DropDownList ID="ddlStatus" class="form1"   style="height:30px;width:50%;float: left;margin-left: 6%;" runat="server">    
                 <asp:ListItem Text="ACTIVE" Value="0"></asp:ListItem>
                 <asp:ListItem Text="EXPIRED" Value="1"></asp:ListItem>                
            </asp:DropDownList>
             
        </div>

             <div class="eachform" style="width: 23% ;float: left;margin-top:1.5%;margin-left:-2%;">
            <h2 style="margin-top: 0.5%;margin-left: 0%;">Approval Status</h2>

            <asp:DropDownList ID="ddlAprvlSts" class="form1"   style="height:30px;width:50%;float: left;margin-left: 6%;" runat="server">     
                 <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                 <asp:ListItem Text="APPROVED" Value="1"></asp:ListItem> 
                 <asp:ListItem Text="REJECTED" Value="2"></asp:ListItem>
                 <asp:ListItem Text="CANCELLED" Value="3"></asp:ListItem> 
            </asp:DropDownList>
             
        </div>


    <div class="eachform" style="float:left;width:19%;margin-top:1.5%;margin-left:1%;">
                <h2>From Date</h2>
                
               <div id="div1" class="input-append date" style="float:right;margin-right:8%;width: 42%;">

                 
                   
                        <asp:TextBox ID="txtFromDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="height:30px;width:88.6%;margin-top: 0%;float:left;margin-left: -2.3%;"></asp:TextBox>

                        <input type="image" runat="server" id="Image1" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:-0.2%;" />
                           <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                               <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
                           <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate1_8_3.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker_pt_br.js">
                            </script>
                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#div1').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div>
      

      <div class="eachform" style="float:left;width:25%;margin-top:1.5%;margin-left:4%;">
                <h2>To Date</h2>
                
               <div id="div2" class="input-append date" style="float:right;margin-right:38%;width: 32%;">

                        <asp:TextBox ID="txtTodate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="height:30px;width:88.6%;margin-top: 0%;float:left;margin-left: -2.3%;"></asp:TextBox>

                        <input type="image" runat="server" id="Image2" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:-0.2%;" />
                    <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                               <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
                           <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate1_8_3.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker_pt_br.js">
                            </script>
                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#div2').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                // startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div>
            
               
 
             <div style="width:12%;float:right;margin-left: 0%;margin-top:-4.2%;">


        
                <div class="eachform" style="width:98%;float: left;">
                <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: -0.4%;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />
                     </div>
                 </div>
            <br style="clear: both" />
            </div>
                
        <%--stop 0006--%>

        <br />

        <div onclick="location.href='hcm_Leave_Request.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;">

           <%-- <a href="gen_Product_Category.aspx">
                <img src="../../Images/BigIcons/add.png" alt="Add" />
            </a>--%>
        </div>
         <asp:HiddenField ID="hiddenNext" runat="server" />
        <asp:HiddenField ID="hiddenPrevious" runat="server" />
    <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
     <asp:HiddenField ID="hiddenMemorySize" runat="server" />
         <asp:HiddenField ID="hiddenRoleAdd" runat="server" />
         <asp:HiddenField ID="hiddenRoleUpdate" runat="server" />
         <asp:HiddenField ID="hiddenRoleCancel" runat="server" />
        <asp:HiddenField ID="hiddenRoleRecall" runat="server" />
        <asp:HiddenField ID="hiddenCommodityValue" runat="server" />
         <asp:HiddenField ID="hiddenRoleReOpen" runat="server" />
         <asp:HiddenField ID="HiddenSearchField" runat="server" />
        
        <%--  <br />
        <br />--%>
        <div id="divReport" class="table-responsive" runat="server">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
                  
                <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 40%; padding-bottom: 0.7%; padding-top: 0.6%;"> Leave Allocation </h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCancelView();"  runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   


     <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>

    </div>
    <style>
         
         .open > .dropdown-menu {
            display: none;
        }
         #ReportTable_filter input {
    height: 18px;
    width: 200px;
    color: #336B16;
    font-size: 14px;
}

    </style>
</asp:Content>

