<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Insurance_And_PermitRenewal_List.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Insurance_and_PermitRenewal_gen_Insurance_And_PermitRenewal_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
    <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/css/CssLeadIndividualModal.css" />
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
.Previous {
    background: url(/Images/BigIcons/Previous.png) no-repeat 0 0;
    width: 90px;
}
.ADD {
    background: url(/Images/BigIcons/add1.png) no-repeat 0 0;
    width: 90px;
}
    .open > .dropdown-menu {
    display: none;
}
     </style>
    

      <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
              
              document.getElementById("<%=txtDateFrom.ClientID%>").focus();
              document.getElementById("freezelayer").style.display = "none";
              document.getElementById('MymodalCancelView').style.display = "none";
              var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
              if (CancelPrimaryId != "") {
                  OpenCancelView();
              }
          });

          // for not allowing enter
          function DisableEnter(evt) {
              IncrmntConfrmCounter();
              evt = (evt) ? evt : window.event;
              var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
              if (keyCodes == 13) {
                  return false;
              }
          }
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
             if (confirm("Do you want to close  without completing Cancellation Process?")) {
                 document.getElementById('divMessageArea').style.display = "none";
                 document.getElementById('imgMessageArea').src = "";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                 document.getElementById("MymodalCancelView").style.display = "none";
                 document.getElementById("freezelayer").style.display = "none";
                 document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
            }
        }



    </script>
     <script language="javascript" type="text/javascript">
         var submit = 0;
         function CheckIsRepeat() {
             if (++submit > 1) {

                 return false;
             }
             else {
                 return true;
             }
         }
         function CheckSubmitZero() {
             submit = 0;
         }
    </script>
    <script>

        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }

        function ConfirmMessage() {
            if (confirmbox > 0) {
                if (confirm('Are You Sure You Want To Leave This Page ?')) {
                    window.location.href = "gen_Insurance_and_PermitRenewal.aspx";
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_Insurance_and_PermitRenewal.aspx";
            }
        }


        function SuccessCancelationInsur() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance Renewal details Cancelled Successfully.";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
        }
        function SuccessCancelationPermit() {
            var permitname = "";
            if (document.getElementById("<%=hiddenPermitName.ClientID%>").value != "") {
                  permitname = document.getElementById("<%=hiddenPermitName.ClientID%>").value;
            }
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = ""+permitname+" Renewal details Cancelled Successfully.";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
        }
        function Validate() {

            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

            document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtDateTo.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlVehicleRenewal.ClientID%>").style.borderColor = "";

            var DateTo = document.getElementById("<%=txtDateTo.ClientID%>").value.trim();
            var DateFrom = document.getElementById("<%=txtDateFrom.ClientID%>").value.trim();

            if (DateTo == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtDateTo.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtDateTo.ClientID%>").focus();
                ret = false;
            }
            else {
                var TaskdatepickerDate = document.getElementById("<%=txtDateTo.ClientID%>").value;
                var arrDatePickerDate = TaskdatepickerDate.split("-");
                var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);
                if (dateDateCntrlr > dateCurrentDate) {
                    document.getElementById("<%=txtDateTo.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtDateTo.ClientID%>").focus();
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, To Date should be less than Current Date !";
                    ret = false;
                }
            }

                if (DateFrom == "") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtDateFrom.ClientID%>").focus();
                    ret = false;
                }
                else
                {
                    var TaskdatepickerDate = document.getElementById("<%=txtDateFrom.ClientID%>").value;
                    var arrDatePickerDate = TaskdatepickerDate.split("-");
                    var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                    var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                    var arrCurrentDate = CurrentDateDate.split("-");
                    var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);
                    if (dateDateCntrlr > dateCurrentDate) {
                        document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtDateFrom.ClientID%>").focus();
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, From Date should be less than Current Date !";
                        ret = false;
                    }
                }
            if (ret == false) {
                CheckSubmitZero();

            }
            return ret;
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
        function CancelNotPossible1() {
            alert("Sorry, Cancellation Denied.Because It is already Cancelled!");
            return false;
        }
        function CancelNotPossible2() {
            alert("Sorry, Cancellation Denied.Please Cancel The Last Entry!");
            return false;
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
    <script src="../../../JavaScript/JavaScriptPagination1.js"></script>
    <script src="../../../JavaScript/JavaScriptPagination2.js"></script>
    <link href="../../../css/StyleSheetPagination.css" rel="stylesheet" />

    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
        
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bInfo": false
            });
        });


            </script>

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
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="hiddenRoleCancel" runat="server" />
    <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <asp:HiddenField ID="hiddenCancelMode" runat="server" />
    <asp:HiddenField ID="hiddenPermitName" runat="server" />

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
        <br />
     <div class="cont_rght" style="width:99%;padding-top:0%">

           <div id="divMessageArea" style="display: none; margin:0px 0 13px;">
                 <img id="imgMessageArea" src="" >
                <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>
          <div id="divList" class="ADD" text ="ADD" onclick="location.href='gen_Insurance_and_PermitRenewal.aspx'" runat="server" style="position:fixed; right:0%; top:25%;height:26.5px;cursor:pointer;"></div>
          <div class="fillform" style="width:99%;">
               <div id="divCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                 <img src="/Images/BigIcons/Insurance-and-Permit-Renewal.png" style="vertical-align: middle;" />  
                    <asp:Label ID="lblEntry" runat="server">Vehicle Renewal  List</asp:Label>
              </div>

              
       <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 100%; margin-top:3%;">


             <div id="datetimepickerFrom" class="input-append date" style="font-family: Calibri; width: 24%;float:left; /*! height:37px; */margin-left:2%;margin-top: 2%;">
                                <span style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left:0%;">From Date*</span>
                                <div style="float: right; width: 79%; margin-top: -10%;">
                                    
                                <asp:TextBox ID="txtDateFrom" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width: 47%; margin-top:0%;  font-family: calibri; float: left;font-size:15px;margin-left:12%;" onkeypress="return DisableEnter(event)" onkeydown="return isNumberDate(event);"></asp:TextBox>                                                                    
                                    <img class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="return IncrmntConfrmCounter();" style="height: 22px; float:left; cursor:pointer;margin-top:  -14.7%;margin-left: 66%;" />

                                
                                   <script type="text/javascript"
                            src="../../../JavaScript/Date/JavaScriptDate1_8_3.js"></script>
                        
                        <script type="text/javascript"
                            src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                        </script>
                        <script type="text/javascript"
                            src="../../../JavaScript/Date/bootstrap-datepicker.js">
                        </script>
                        <script type="text/javascript"
                            src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js">
                        </script>
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#datetimepickerFrom').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,

                                endDate: new Date(),

                            });


                                </script>
                            </div>
                               </div> 

            <div id="datePickerTo" class="input-append date" style="font-family: Calibri; width: 24%;float:left; /*! height:37px; */margin-top: 2%;margin-left:-2%">
                                <span style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left:0%;">To Date*</span>
                                <div style="float: right; width: 79%; margin-top: -10%;">
                                    
                                <asp:TextBox ID="txtDateTo" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width: 47%; margin-top:0%;  font-family: calibri; float: left;font-size:15px;margin-left:12%;" onkeypress="return DisableEnter(event)" onkeydown="return isNumberDate(event);"></asp:TextBox>                                                                    
                                    <img class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="return IncrmntConfrmCounter();" style="height: 22px; float:left; cursor:pointer;margin-top:  -14.7%;margin-left: 66%;" />

                   <script type="text/javascript">
                         var $noC = jQuery.noConflict();
                         $noC('#datePickerTo').datetimepicker({
                         format: 'dd-MM-yyyy',
                         language: 'en',
                         pickTime: false,
                         endDate: new Date(),
                         });


                           </script>
                             </div>
                               </div> 


       <div id="divVehRnwl" style="float: left; width: 24%; margin-top: 1.7%;margin-left: -3%;" >  
           <span style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left:0%;float: left;">Based On*</span> 
    <asp:DropDownList ID="ddlVehicleRenewal" CssClass="leads_field leads_field_dd dd2" Onchange="return IncrmntConfrmCounter();" style="width: 45% !important;height: 25px !important; margin-left:2%;margin-top: 0%;" runat="server"  autofocus="autofocus" autocorrect="off" autocomplete="off" >      
                 </asp:DropDownList>
           </div>

            <div  style="float: left; width: 19%; margin-top: 1.7%;margin-left: -6%;">               
                <div class="subform" style="width:89%;margin-left: 4.8%;">
                    <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" Checked="false" class="form2" onkeypress="return DisableEnter(event)" onclick="return IncrmntConfrmCounter();" />
                    <h3 style="margin-top:1%;">Show Deleted Entries</h3>
                  </div>
                </div>
           
    <asp:Button ID="btnSearch" style="margin-top:-3.2%; margin-right:4.5%; float:right; cursor:pointer; width: 104px;margin-left: 49%;margin-bottom: 2%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClick="btnSearch_Click"  OnClientClick="return Validate();"/>
     
               
 
          <div id="divReportDate" class="table-responsive" style="width: 96%;margin-left: 2%;background-color: #e0e0e0;margin-top: 4.5%;margin-bottom:1%" runat="server">

        </div>

               </div>
              </div>

                                  <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 42%; padding-bottom: 0.7%; padding-top: 0.6%;">Vehicle Renewal</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" style="visibility:hidden;  text-align: center; ">
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


     <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>





         </div>


                   <style>
        #ReportTable_filter input {
    height: 17px;
    width: 158px;
    color: #336B16;
    font-size: 14px;
}
       #ReportTable_wrapper {
    width: 98%;
    margin-left: 1%;
}
    </style>
</asp:Content>

