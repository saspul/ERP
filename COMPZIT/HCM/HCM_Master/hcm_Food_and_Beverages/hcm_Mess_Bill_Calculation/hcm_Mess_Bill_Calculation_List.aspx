<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Mess_Bill_Calculation_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_Food_and_Beverages_hcm_Mess_Bill_Calculation_hcm_Mess_Bill_Calculation_List" %>
 
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
</style>

        <script src="/JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
              document.getElementById("freezelayer").style.display = "none";
              document.getElementById('MymodalCancelView').style.display = "none";
              var CancelPrimaryId = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
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

        function DuplicationName() {

            document.getElementById('divMessageArea').style.display = "";

            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Recalling denied!.Accommodation name can’t be duplicated.";
        }
        function CloseCancelView() {
            if (confirm("Do you want to close  without completing Cancellation Process?")) {
                document.getElementById('divMessageArea').style.display = "none";
                document.getElementById('imgMessageArea').src = "";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                document.getElementById("MymodalCancelView").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
                document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = "";
            }
        }



    </script>

         <script>
             function SuccessConfirmation() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Mess bill details inserted successfully.";

             }
             function SuccessUpdation() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Mess bill  details updated successfully.";

             }
             function MessConfirmation() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Mess bill details confirmed successfully.";
           }
             function SuccessCancelation() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Mess bill details cancelled successfully.";

             }
             function SuccessRecall() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Mess bill  details recalled successfully.";
             }

             function getdetails(href) {
                 window.location = href;
                 return false;
             }
             function CancelAlert(href) {

                 if (confirm("Do you want to cancel this Entry?")) {
                     window.location = href;
                     return false;
                 }
                 else {
                     return false;
                 }
             }
             function ReCallAlert(href) {

                 if (confirm("Do you want to Recall this Entry?")) {
                     window.location = href;
                     return false;
                 }
                 else {
                     return false;
                 }
             }

             //  var $NoCn = jQuery.noConflict();
             function CancelNotPossible() {
                 alert("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
                 return false;


             }
             // for not allowing <> tags
             function isTag(evt) {

                 evt = (evt) ? evt : window.event;
                 var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

                 var charCode = (evt.which) ? evt.which : evt.keyCode;
                 var ret = true;
                 if (charCode == 60 || charCode == 62) {
                     ret = false;
                 }
                 return ret;
             }

             //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
             function textCounter(field, maxlimit) {
                 if (field.value.length > maxlimit) {
                     field.value = field.value.substring(0, maxlimit);
                 } else {

                 }
             }
             // for not allowing enter
             function DisableEnter(evt) {

                 evt = (evt) ? evt : window.event;
                 var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                 if (keyCodes == 13) {
                     return false;
                 }
             }
          </script>


    <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
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
            width: 97.5%;
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

    </script>
 
        <script>
            function InsertToSearchField() {

                var DropdownEmp = document.getElementById("<%=ddlAccomo.ClientID%>");
                var SelectedValueStatus = DropdownStatus.value;
                var ShwCancel = 0;
                if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked) {
                    ShwCancel = 1;
                }
                else {
                    ShwCancel = 0;
                }

                document.getElementById("<%=hiddenSearchField.ClientID%>").value = SelectedValueStatus + '_' + ShwCancel;
                return true;
            }
           </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
       <br />
      <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
       <asp:HiddenField ID="hiddenSearchField" runat="server" />
    
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
            <div id="divMessageArea" style="display: none">
                 <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div class="cont_rght" >

        


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <img src="/Images/BigIcons/mess-bill-calculation.png" style="vertical-align: middle;" /> Mess Bill Calculation
        </div>
        <div style="border: .5px solid; border-color: #9ba48b; background-color: #f3f3f3; width: 97.5%; margin-top: 0.5%; height: 10%;">




            <div style="width: 100%; float: left; margin-top: 14px">
               <div style="float: left;width: 32%;">
                   <div class="eachform" style="float:left;width:98%;margin-top:.5%;margin-left:2%;">
                <h2 style="margin-top: 2%;">From Date</h2>
                
               <div id="div1" class="input-append date" style="float:right;margin-right:25%;width: 42%;">

                        <asp:TextBox ID="txtFromDateSrch" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="height:30px;width:100%;margin-top: 0%;float:left;margin-left: -2.3%;"></asp:TextBox>

                       </div>
              

            </div>
      

      <div class="eachform" style="float:left;width:98%;margin-top:.5%;margin-left:2%;">
                <h2 style="margin-top: 2%;">To Date</h2>
                
               <div id="div2" class="input-append date" style="float:right;margin-right:25%;width: 42%;">

                <asp:TextBox ID="txtTodateSrch" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="height:30px;width:100%;margin-top: 0%;float:left;margin-left: -2.3%;"></asp:TextBox>
                </div>
            </div>
                   </div>
                <div  style="float: left;width: 35%;">
                 <div class="eachform" style="width: 98%; margin-top: 0.5%;  float: left;">

                    <h2 style="margin-top: 1%;">Accomodation</h2>
                    <div style="height: 25px; width: 69%; float: right; margin-right: 5%;">
                    <asp:DropDownList ID="ddlAccomo" class="form1" runat="server" >
                    </asp:DropDownList>
                    </div>

                </div>
                 <div class="subform" style="margin-right: 4%;" >


                    <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" Checked="false" class="form2" />
                    <h3 style="margin-top:1%;">Show Deleted Entries</h3>
                  </div>

                    </div>
                <div class="eachform" style="width: 13%; float: left;margin-left: 14%;margin-top: 1.5%;">
                    <asp:Button ID="btnSearch" Style="cursor: pointer; margin-top: 2.6%; margin-left: 10%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />
                </div>
            </div>


            <br style="clear: both" />
        </div>
     
        <br />

        <div onclick="location.href='hcm_Mess_Bill_Calculation.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px;right:1%;">

           <%--  <a href="gen_UserRegistration.aspx">
                 <img src="../../Images/BigIcons/add.png" alt="Add" />
            </a>--%>
        </div>
      <%--  <br />
        <br />--%>
        <div id="divReport" class="table-responsive" runat="server">
           
        </div>


        
           
                                            <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 40%; padding-bottom: 0.7%; padding-top: 0.6%;">Mess Bill </h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>       

    </div>
    <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>

   
      <script src="/JavaScript/multiselect/jQuery/jquery-3.1.1.min.js"></script>
    <%-- for datetime picker--%>
    <script src="/JavaScript/datepicker/bootstrap-datepicker.js"></script>
    <link href="/JavaScript/datepicker/datepicker3.css" rel="stylesheet" />
     <script>

         var $noConfi = jQuery.noConflict();
         $noConfi(function () {
             $noConfi('#cphMain_txtFromDateSrch').datepicker({
                 autoclose: true,
                 format: 'dd-mm-yyyy',
                 language: 'en',
                 // startDate: new Date()
             });
             $noConfi('#cphMain_txtTodateSrch').datepicker({
                 autoclose: true,
                 format: 'dd-mm-yyyy',
                 language: 'en',
                 //startDate: new Date()
             });
         });
    </script>
     <style>
        .cont_rght {
            padding-bottom: 2%;
            padding-top: 1%;
        }

        .datepicker table tr td, .datepicker table tr th {
            text-align: center;
            width: 0px;
            height: 0px;
            border-radius: 4px;
            border: none;
        }

        .table > thead > tr > th {
            vertical-align: bottom;
            background: #7b7b7b;
            color: #fff;
        }

        .datepicker table tr td.disabled, .datepicker table tr td.disabled:hover {
            background: none;
            color: #c5c5c5;
            cursor: default;
        }
    </style>
</asp:Content>





