<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" CodeFile="hcm_Arrivl_Confrmtn.aspx.cs" Inherits="HCM_HCM_Master_hcm_OnBoarding_hcm_Arrivl_Confrmtn_hcm_Arrivl_Confrmtn" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

  <style>
              #divMessageArea {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: 0%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }

        #imgMessageArea {
            float: left;
            margin-left: 1%;
            margin-top: -0.2%;
        }
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

      .closeCancelViewRenwl {
      
             color: white;
             float: right;
             font-size: 28px;
             font-weight: bold;
      
      }
        .closeCancelViewRenwl:hover,
             .closeCancelViewRenwl:focus {
                 color: #000;
                 text-decoration: none;
                 cursor: pointer;
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
              #divErrorRsnAWMSRenwl {
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
     .searchlist_btn_lft:hover {
        background:url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        
        }
        .searchlist_btn_lft:focus {
        background:url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        
        }

     </style>
    <script src="/JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
           
              document.getElementById("freezelayer").style.display = "none";
             
              document.getElementById('MymodalCancelView').style.display = "none";
              var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
              document.getElementById("<%=txtFromDate.ClientID%>").focus();
          
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

          function ReCallAlert(href) {

              if (confirm("Do you want to recall this entry?")) {
                  window.location = href;
                  return false;
              }
              else {
                  return false;
              }
          }

    </script>
    <script type="text/javascript">
        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = " Arrival status changed successfully.";
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
        </script>

   <%--  for giving pagination to the html table--%>


    
                   <script src="/JavaScript/jquery-1.8.3.min.js"></script>
                   <script src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
                   <script src="/JavaScript/Date/bootstrap-datepicker.js"></script>
                   <script src="/JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
                   <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                   <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
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

        // for not allowing enter


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


        function SearchValidation() {
            ret = true;
            var FromDate="";
            var ToDate="";
            var arrvlSts = document.getElementById("<%=ddlArvlSts.ClientID%>").value;
            if (arrvlSts == 0) {
                var CrdExpWithoutReplace = document.getElementById("<%=txtFromDate.ClientID%>").value;
                var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
                var replaceCode2 = replaceCode1.replace(/>/g, "");
                document.getElementById("<%=txtFromDate.ClientID%>").value = replaceCode2;

                var CrdExpWithoutReplace = document.getElementById("<%=txtToDate.ClientID%>").value;
                var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
                var replaceCode2 = replaceCode1.replace(/>/g, "");
                document.getElementById("<%=txtToDate.ClientID%>").value = replaceCode2;
                 FromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
                 ToDate = document.getElementById("<%=txtToDate.ClientID%>").value;
                if (ret == true) {
                  

                    document.getElementById("<%=HiddenSearchField.ClientID%>").value = FromDate + ',' + ToDate + ',' + arrvlSts;
                }
            }
            else {
               
                if (ret == true) {

                    document.getElementById("<%=HiddenSearchField.ClientID%>").value = FromDate + ',' + ToDate + ',' + arrvlSts;
                 }
            }

        
            
            
         

       

            
            return ret;

        }







        function ConfirmAlert() {
            ValidateVisaQuota();
            var chck = ValidateVisaQuota();

            if (chck == true) {

                if (confirm("Are You Sure You Want To Confirm?")) {
                    return true;
                }
                else {

                    CheckSubmitZero();
                    return false;
                }
            } else {

                CheckSubmitZero();
                return false;
            }

        }
    
         
        var confirmbox = 0;

        var confirmboxSalryAllwnce = 0;
        var confirmboxSalryDedctn = 0;
        var confirmboxSalryVisQut = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }


        function IncrmntConfrmCounterVisQut() {
            confirmboxSalryVisQut++;
        }

        function DateChkSearch() {

            if (document.getElementById("<%=txtFromDate.ClientID%>").value != "" && document.getElementById("<%=txtToDate.ClientID%>").value != "") {
                var datepickerDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var datepickerDate = document.getElementById("<%=txtToDate.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                if (dateTxIss >= dateCompExp) {
                    document.getElementById("<%=txtToDate.ClientID%>").value = "";
                   }
               }
               return false;

        }
        function ChangeStatus() {
            if (confirm("Do you want to change the arrival status of this entry?")) {

                //window.location = 'gen_Interview_CategoryList.aspx?StsCh=' + catId;
                return true;
            }
            else {
                return false;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
       <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
        <asp:HiddenField ID="HiddenSearchField" runat="server" />
        <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <%--<asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />--%>
     <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
     <asp:HiddenField ID="HiddenVisaQuotaId" runat="server" />
    <asp:HiddenField ID="HiddenBundlNum" runat="server" />

    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="/Images/BigIcons/Employee-Sponser-Master.png" style="vertical-align: middle;" />
     Arrival Confirmation
        </div >
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 93.5%;margin-top:0.5%;height:10%;">

            <div style="width:100%;float:left;margin-top:14px">

                         <div class="eachform" id="ddldiv" runat="server" style="width: 30.5% ;float: left;margin-top:.5%;margin-left:1%;">
            <h2 style="margin-top: 0.5%;margin-left: 0%;">Arrival Status*</h2>

            <asp:DropDownList ID="ddlArvlSts" class="form1"   style="height:30px;width:50%;float: left;margin-left: 6%;margin-top:-1%" runat="server">  
                  <asp:ListItem Text="PENDING" selected="true" Value="0"></asp:ListItem>
                    <asp:ListItem Text="ARRIVED"  Value="1"></asp:ListItem>
                    
            </asp:DropDownList>
             
        </div>
 
               
                        <div class="eachform" id="ArrvlDate" runat="server" style="width:27%;float:left;margin-top:-4px;border: 1px solid;border-color: #9ba48b;padding: 5px;margin-left: 1%;">
                 <h2 style="margin-top: 0.5%;margin-left: 34%;">Arrival Date</h2>
             <div class="eachform" style="font-family:Calibri;float:right;width:65%;margin-right:0%;margin-top: 1%;">
            <h2 style="margin-top: 1.5%;margin-left: -46%;float: left;">From Date</h2>

             <div id="Div3" class="input-append date" style="font-family:Calibri;float:right;width:89%;margin-right:7%;margin-top: 1%;">
                 <asp:TextBox ID="txtFromDate"  class="textDate form1" onblur="DateChkSearch();" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width:71.8%;height:27px; font-family: calibri;float: left;margin-left: 1%;" ></asp:TextBox>

                        <input type="image" runat="server" id= "img2" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return DateChkSearch()" style=" height:19px;float:left; width:12px; cursor:pointer;" />

                   <script src="/JavaScript/jquery-1.8.3.min.js"></script>
                   <script src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
                   <script src="/JavaScript/Date/bootstrap-datepicker.js"></script>
                   <script src="/JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
                   <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                   <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
                        <script type="text/javascript">
                            var $noC2 = jQuery.noConflict();
                            $noC2('#Div3').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                // startDate: new Date(),


                            });
                            function FocusOnDate() {

                                $noC2('#Div3').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    //startDate: new Date(),


                                });
                            }
                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                  


        </div>

            <div class="eachform" style="width: 100%; padding-left: 0.5%;padding-top:0% ;float: left;">
            <h2 style="margin-top: 1.5%;margin-left: 5%;">To Date </h2>

            <div id="ClosingDate" class="input-append date" style="font-family:Calibri;float:right;width:57%;margin-right:5%;margin-top: 1%;margin-bottom: -3px;">
                 <asp:TextBox ID="txtToDate"  class="textDate form1" onblur="DateChkSearch();" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width:73.8%;height:27px; font-family: calibri;float: left;margin-left: -1%;" ></asp:TextBox>

                        <input type="image" id="img1" runat="server" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return DateChkSearch()" style=" height:19px;float:left; width:12px; cursor:pointer;" />

                   <script src="/JavaScript/jquery-1.8.3.min.js"></script>
                   <script src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
                   <script src="/JavaScript/Date/bootstrap-datepicker.js"></script>
                   <script src="/JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
                   <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                   <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
                        <script type="text/javascript">
                            var $noC2 = jQuery.noConflict();
                            $noC2('#ClosingDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //  startDate: new Date(),


                            });
                            function FocusOnDate() {

                                $noC2('#ClosingDate').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    //  startDate: new Date(),


                                });
                            }
                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
           
        </div>
                </div>
                   
        
               
   
                </div>
             <div class="eachform" id="divserch" runat="server" style="width:12%;float:right;margin-top:-3.7%;margin-left: 0%;">


        
                <div class="eachform" style="width:98%;float: left;/*! margin-right: 9%; *//*! margin-top: 10%; */">
                <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: -0.4%;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClick="btnSearch_Click" OnClientClick="return SearchValidation();"   />
                     </div>
                 </div>
            <br style="clear: both" />
            </div>
        <br />

   <%--     <div onclick="location.href='gen_visa_quota_info.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;">--%>

          <%--  <a href="gen_Projects.aspx">
                <img src="../../Images/BigIcons/add.png" alt="Add" />
            </a>--%>
      <%--  </div>--%>
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

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Job Description</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 24%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();"  style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
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
    
              .open > .dropdown-menu {
            display: none;
        }
             
                #ReportTable_filter input {
               height: 17px;
        }
           
    </style>
</asp:Content>

