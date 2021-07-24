<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Traffic_Violation_Settlement_List.aspx.cs" Inherits="AWMS_AWMS_Transaction_gen_Traffic_Violation_Settlement_gen_Traffic_Violation_Settlement" %>

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
    <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
    <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/css/CssLeadIndividualModal.css" />
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
     <script src="../../../JavaScript/jquery-1.8.2.min.js"></script>

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
       <script src="../../../JavaScript/jquery_2.1.3_jquery_min.js"></script>
    <link href="../../../JavaScript/ToolTip/jBox.css" rel="stylesheet" />
    <script src="../../../JavaScript/ToolTip/jBox.js"></script>

    <script>

        javascript
        new jBox('Tooltip', {
            attach: '.tooltip'
        });




    </script>
     <style>
.divbutton {
    display:inline-block;
    color:#0C7784;
    border:1px solid #999;
    background:#CBCBCB;
    /*box-shadow: 0 0 5px -1px rgba(0,0,0,0.2);*/
    cursor:pointer;
    vertical-align:middle;
    width: 18.7%;
    padding: 5px;
    text-align: center;
    font-family: calibri;
}
.divbutton:active {
    color:red;
    box-shadow: 0 0 5px -1px rgba(0,0,0,0.6);
}

    </style>
    <script src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="../../../css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>




        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

                $au('#cphMain_ddlVehicleNumber').selectToAutocomplete1Letter();

                $au('form').submit(function () {

                    //   alert($au(this).serialize());


                    //   return false;
                });
            });
        })(jQuery);





                    </script>


    <style type="text/css">
        

                 input[disabled], select[disabled], textarea[disabled], input[readonly], select[readonly], textarea[readonly] {
        cursor:default;
        }

                   input[type=text][disabled="disabled"] {
            margin-left: 28.5% !important;
            height: 30px !important;
        }
                       .open > .dropdown-menu {
    display: none;
}

                        #divCaption1 {
            font-size: 19px;
            font-weight: bold;
            color: rgb(83, 101, 51);
            font-family: Calibri;
            width: 128px;
            margin-left: 1%;
            margin-top: 2%;
            border-bottom: 1px solid;
        }
                        #divCaption2 {
                 font-size: 19px;
                 font-weight: bold;
                 color: rgb(83, 101, 51);
                 font-family: Calibri;
                 width: 162px;
                 margin-left: 2%;
                 margin-top: 2%;
                 border-bottom: 1px solid;
        }

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
    </style>

          <%--  for giving pagination to the html table--%>
    <script src="../../../JavaScript/JavaScriptPagination1.js"></script>
    <script src="../../../JavaScript/JavaScriptPagination2.js"></script>
    <link href="../../../css/StyleSheetPagination.css" rel="stylesheet" />

    <script>
        //var $p = jQuery.noConflict();
        //$p(document).ready(function () {
        //    document.getElementById('cphMain_txtDate').focus();
        //    $p('#ReportTable').DataTable({
        //        "pagingType": "full_numbers",
        //        "bInfo": false,
        //        "bSort": true
        //    });
        //});


            </script>



     <script type="text/javascript"
        src="../../../JavaScript/jquery_2.1.3_jquery_min.js"></script>

    <script type="text/javascript"
        src="../../../JavaScript/jquery_1.11.3_jquery_min.js"></script>
    <script src="../../../JavaScript/scripts/jquery-1.9.1.min.js"></script>
    


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
        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {

                return false;
            }
        }

    </script>
    <script>
        function getdetails(href) {
            window.location = href;
            return false;
        }

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            $(window).scrollTop(0);
            document.getElementById("<%=txtDate.ClientID%>").value="";
            document.getElementById("<%=txtToDate.ClientID%>").value = "";

            if (document.getElementById("<%=hiddenViewStatus.ClientID%>").value == "Pending") {
                
                divButtonExprdVhclDetailsLoad('1');
            }
            else if ((document.getElementById("<%=hiddenViewStatus.ClientID%>").value == "Settled")) {
                
                divButtonAsOnDateExprdVhclDetailsLoad('1');
            }
            else {
                divButtonExprdVhclDetailsLoad('1');

            }
            document.getElementById("freezelayer").style.display = "none";
            document.getElementById('MymodalCancelView').style.display = "none";
           var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
              if (CancelPrimaryId != "") {
                  OpenCancelView();
              }
                ////document.getElementById('divAsOnDateExprdVhclDetails').style.display = "none";
            ////document.getElementById('divExprdVhclDetails').style.display = "none";
            //document.getElementById("divVehRnwl").style.display = "";
            //var a = $noC("#cphMain_ddlVehicleRenewal option:selected").text();
            ////alert(a);
            //$noC("div#divVehRnwl input.ui-autocomplete-input").val(a);

            //document.getElementById("divVehNumbr").style.display = "";
            //var b = $noC("#cphMain_ddlVehicleNumber option:selected").text();
            ////alert(b);
            //$noC("div#divVehNumbr input.ui-autocomplete-input").val(b);

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
             if (confirm("Do you want to close  without completing Cancellation Process?")) {
                 document.getElementById('divMessageArea').style.display = "none";
                 document.getElementById('imgMessageArea').src = "";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                 document.getElementById("MymodalCancelView").style.display = "none";
                 document.getElementById("freezelayer").style.display = "none";
                 document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
                 divButtonAsOnDateExprdVhclDetailsClick('1');
             }
         }



    </script>

    <script>
        // document.getElementById('divMessageArea').style.display = "none";
        function divButtonExprdVhclDetailsLoad(type) {

            //hiding other
            document.getElementById('divButtonAsOnDateExprdVhclDetails').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonAsOnDateExprdVhclDetails').style.borderBottom = "1px solid #999";
            document.getElementById('divAsOnDateExprdVhclDetails').style.display = "none";
            //document.getElementById('divExprdVhclDetails').style.display = "none";

            //displaying current
            document.getElementById('divButtonExprdVhclDetails').style.backgroundColor = "#f9f9f9";
            //document.getElementById('divButtonExprdVhclDetails').style.borderBottom = "none";
            document.getElementById('divExprdVhclDetails').style.display = "block";
            //if (type == "1") {
            //    document.getElementById('cphMain_txtInsurance').focus();
            //}
        }
        function divButtonAsOnDateExprdVhclDetailsLoad(type) {


            //hiding other
            document.getElementById('divButtonExprdVhclDetails').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonExprdVhclDetails').style.borderBottom = "1px solid #999";
            document.getElementById('divExprdVhclDetails').style.display = "none";


            //displaying current
            document.getElementById('divButtonAsOnDateExprdVhclDetails').style.backgroundColor = "#f9f9f9";
            //document.getElementById('divButtonAsOnDateExprdVhclDetails').style.borderBottom = "none";
            document.getElementById('divAsOnDateExprdVhclDetails').style.display = "block";
            //if (type == "1") {
            //    document.getElementById('cphMain_txtInsurance').focus();
            //}
        }
        function divButtonExprdVhclDetailsClick(type) {
            document.getElementById('divMessageArea').style.display = "none";
            //hiding other
            document.getElementById('divButtonAsOnDateExprdVhclDetails').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonAsOnDateExprdVhclDetails').style.borderBottom = "1px solid #999";
            document.getElementById('divAsOnDateExprdVhclDetails').style.display = "none";
            //document.getElementById('divExprdVhclDetails').style.display = "none";

            //displaying current
            document.getElementById('divButtonExprdVhclDetails').style.backgroundColor = "#f9f9f9";
            //document.getElementById('divButtonExprdVhclDetails').style.borderBottom = "none";
            document.getElementById('divExprdVhclDetails').style.display = "block";
            //if (type == "1") {
            //    document.getElementById('cphMain_txtInsurance').focus();
            //}
        }
        function divButtonAsOnDateExprdVhclDetailsClick(type) {
            
            document.getElementById('divMessageArea').style.display = "none";
            //hiding other
            document.getElementById('divButtonExprdVhclDetails').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonExprdVhclDetails').style.borderBottom = "1px solid #999";
            document.getElementById('divExprdVhclDetails').style.display = "none";


            //displaying current
            document.getElementById('divButtonAsOnDateExprdVhclDetails').style.backgroundColor = "#f9f9f9";
            //document.getElementById('divButtonAsOnDateExprdVhclDetails').style.borderBottom = "none";
            document.getElementById('divAsOnDateExprdVhclDetails').style.display = "block";
            //if (type == "1") {
            //    document.getElementById('cphMain_txtInsurance').focus();
            //}
        }
       
       
       
       
      

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
        function SuccessUpdation1() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Traffic Violation Details Updated Successfully.";
        }
        function ConfirmSuccessfull() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Traffic Violation Settlement Confirmed Successfully.";
        }
        function SuccessCancelation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Traffic Violation Cancelled Successfully.";
        }
        function SuccessReOpen() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Traffic Violation Settlement Re-Opened Successfully.";
        }

        function FailureReOpen() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Re-Opening  Not Successfull. It is already Re-Opened.";

        }

        function CancelNotPossible() {
            alert("Sorry, Cancellation Denied. This Entry is Already Selected Somewhere Or It is a Confirmed Entry!");
            return false;
        }
        function ReOpenAlert(href) {
            if (confirm("Do you want to Re-Open this Entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }
        function DuplicateReceiptNoOnReOpen() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Receipt Number Can’t be Duplicated.";

        }
        function CancelSuccess() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Traffic Violation Cancelled Successfully.";
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

        var $Op = jQuery.noConflict();
        $Op(document).ready(function () {
            $Op('#ReportTable2').DataTable({
                "pagingType": "full_numbers",
                "bInfo": false
            });
        });
        function TablePagination() {
            $Op(document).ready(function () {
                $Op('#ReportTable2').DataTable({
                    "pagingType": "full_numbers",
                    "bInfo": false
                });
            });
        }
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
            .cont_rght h2 {
                padding-right: 1%;
                padding: 0.3%;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    <asp:HiddenField ID="hiddenViewStatus" runat="server" />
    <asp:HiddenField ID="hiddenOrgId" runat="server" />
    <asp:HiddenField ID="hiddenCorptId" runat="server" />
    <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    

    
     <div class="cont_rght" style="width:99%;padding-top:0%">
                         <div id="divMessageArea" style="display: none; margin:0px 0 13px;">
                 <img id="imgMessageArea" src="" >
                <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>

          
          
          <div id="divFill" class="fillform" style="width:99%;">
               <div id="divCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                 <img src="/Images/BigIcons/traffic violation settelement.png" style="vertical-align: middle;" />   <asp:Label ID="lblEntry" runat="server"> Traffic Violation Settlement </asp:Label>
             
                    </div> 
               <br />
           <div id="divButtonExprdVhclDetails" onclick="divButtonExprdVhclDetailsClick('1')" class="divbutton" >Pending Settlement </div>
          <div id="divButtonAsOnDateExprdVhclDetails" onclick="divButtonAsOnDateExprdVhclDetailsClick('1')" class="divbutton" >Settled</div>  
              <div id="divExprdVhclDetails" style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 100%; margin-top:1%;">
               
                     <div id="divCaption1" style="width: 27%;" >
            <asp:Label ID="Label1" runat="server">Settlement Of Pending Traffic Violations</asp:Label>
            </div>
                 <br style="clear:both" />
  
                <div id="divReport" class="table-responsive" runat="server" style="width: 100%;">

               
                </div>
                 <br style="clear:both" />
             </div>
              </div>

 <div  id="divAsOnDateExprdVhclDetails" class="fillform" style="width:99%;">
               

   <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 100%; margin-top:0%;">
                 
       
                 <asp:UpdatePanel ID="UpdatePanelForTable" runat="server" UpdateMode="Always">
                       <ContentTemplate> 
                           <div style="width:100%;margin-bottom: 2%;">
                                       <div id="divCaption2" style="width: 200px;">
            <asp:Label ID="lblHeader1" runat="server">Settled Traffic Violations</asp:Label>
            </div>
                           </div>
                           



<div style="width:100%;">
    <div>
 <h2 style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri; float: left;margin-left:2%;">From Date*</h2>
        <div id="datetimepickerFrom" class="input-append date" style="font-family: Calibri; width: 25%; /*! height:37px; */">
         <asp:TextBox ID="txtDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="10" runat="server" Style="width: 30%; margin-left: 3%; font-family: calibri; float: left;font-size:15px;height:23px;" onkeypress="return isTag(event)" onkeydown="return isNumberDate(event);"></asp:TextBox>                                                                    
                                    <img class="add-on" src="../../../Images/Icons/CalandarIcon.png" style="height: 15px; float:left; cursor:pointer;margin-left: 0%;" />

                                
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
                                defaultDate: null
                                //startDate: new Date(),

                            });
                            function ReloadFromDate() {
                                $noC('#datetimepickerFrom').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    defaultDate: null
                                    //startDate: new Date(),

                                });
                            }

                                </script>
            </div>
    </div>
    <div style="margin-left: 23%;">
<div >
              <h2 style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;float:left">To Date* </h2>

              </div>
        <div id="datetimepickerTo" class="input-append date" style="padding: 0.3%;padding-right:1%; font-family: Calibri; width: 25%; /*! height:37px; */margin-left:5%;">
                                <%--<span style="/*color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left:0%;*/">To Date*</span>--%>
              
                                <div style=" ">
                                <asp:TextBox ID="txtToDate"  class="form1" placeholder="DD-MM-YYYY" MaxLength="10" runat="server" Style="width: 30%; margin-left: 3%; font-family: calibri; float: left;font-size:15px;margin-left:0%;height:23px;" onkeypress="return isTag(event)" onkeydown="return isNumberDate(event);"></asp:TextBox>                                                                    
                                   
                                     <img class="add-on" src="../../../Images/Icons/CalandarIcon.png" style="height: 15px; float:left; cursor:pointer;margin-left: 0%;" />

                                
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
                            var $noCo = jQuery.noConflict();
                            $noCo('#datetimepickerTo').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //defaultDate: null
                                //startDate: new Date(),

                            });
                            function ReloadTodate() {
                                $noCo('#datetimepickerTo').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    //defaultDate: null
                                    //startDate: new Date(),

                                });
                            }


                                </script>
                            </div>
                               </div> 
    </div>
</div>

                    
      <div style="width:100%;">
         
          
          <div style=" margin-left: 0%;" >               
                <div>

     <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" Style="margin-left:3%" onkeypress="return isTag(event);" Checked="false" class="form2" />
                    <h3 style="font-family: Calibri;font-size: 17px;float: left;text-align: left;color: #7F8672;padding: 0%;margin: 04px 14px 6px 2px;line-height: 1;font-weight: normal;float: left;">Show Deleted Entries</h3>
          
                   
                  </div>
                </div>
         <%-- <div class="eachform" style="width:21%; margin-left: 0%;">               
                <div class="subform" style="width:89%;">

                     
                    
                    <h3 style="margin-top:1%;">Show Deleted Entries</h3>
                  </div>
                </div>--%>
           <div >   
           <div  style="width:0%;float:right;margin-right: 12%;">
               <asp:Button ID="btnSearch" style="float:right; cursor:pointer;width: 104px;" OnClick="btnSearch_Click" runat="server" class="searchlist_btn_lft" Text="Search"/>

           </div></div>
      </div>
             

        

         
           <div>
             
           </div>
            <%--OnClick="btnSearch_Click" OnClientClick="return SearchValidation();"--%>
               
           
           
      
       
       

           
    <%--<asp:Button ID="btnSearch" style="margin-top:-2.4%; margin-right:2%; float:right; cursor:pointer; width: 104px;margin-left: 49%;margin-bottom: 2%;" runat="server" class="searchlist_btn_lft" Text="Search"   OnClientClick="return Validate();"/>--%>
     
               
               
          <div id="divReportDate" class="table-responsive" runat="server" style="">

        </div>
             </ContentTemplate> 
                 </asp:UpdatePanel>
               </div>
      
      </div>
    
              <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 40%; padding-bottom: 0.7%; padding-top: 0.6%;">Traffic Violation Settlement</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                        <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" Style="width: 90px; float: left; margin-left: 39%; margin-top: 3%;" />
                    
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
    height: 18px;
    width: 200px;
    color: #336B16;
    font-size: 14px;
}
    </style>
</asp:Content>

