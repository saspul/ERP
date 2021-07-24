<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" CodeFile="hcm_Mess_Calculation_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_Mess_Calculation_Report_hcm_Mess_Calculation_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

     <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
<link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
<script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
<link href="/JavaScript/multiselect/AdminLTE.min.css" rel="stylesheet" />

<style>
        .cont_rght {
            width: 98%;
        }

    /*--------------------------------------------------for modal ManPower Requirement info------------------------------------------------------*/
         .modalInfoView {
             display: none; /* Hidden by default */
             position: fixed; /* Stay in place */
             z-index: 30; /* Sit on top */
             padding-top: 0%; /* Location of the box */
             left: 10%;
             top: 10%;
             width: 80%; /* Full width */
             height: 250px; /* Full height */
             /*overflow: auto;*/ /* Enable scroll if needed */
             background-color: transparent;
         }

         .modal-InfoView {
             /*position: relative;*/
             background-color: #fefefe;
             margin: auto;
             padding: 0;
             /*border: 1px solid #888;*/
             width: 95.6%;
             box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
         }


         /* The Close Button */
         .closeInfoView {
             color: white;
             float: right;
             font-size: 28px;
             font-weight: bold;
         }

             .closeInfoView:hover,
             .closeInfoView:focus {
                 color: #000;
                 text-decoration: none;
                 cursor: pointer;
             }

         .modal-headerInfoView {
             /*padding: 1% 1%;*/
            background-color: #91a172;
             color: white;
         }

         .modal-bodyInfoView {
             padding: 4% 4% 7% 4%;
         }

         .modal-footerInfoView {
             padding: 1% 1%;
           background-color: #91a172;
             color: white;
         }

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

     <style>
        
        #tblOnBoardMult > tbody > tr:nth-child(2n+1) > td, .main_table > tbody > tr:nth-child(2n+1) > th {
            height: 30px;
            background: #DDD;
            font-size: 14px;
            color: #5c5c5e;
        }

        #tblOnBoardMult > tbody > tr:nth-child(2n) > td, .main_table > tbody > tr:nth-child(2n) > th {
            height: 30px;
            background: #C2C2C2;
            font-size: 14px;
            color: #000;
        }

        .select2-container--default .select2-selection--multiple .select2-selection__choice {
            background-color: #a5a5a5;
            border-color: #8d8d8d;
            padding: 1px 5px;
            color: #fff;
            font-size: 14px;
            margin: 2px;
            max-width: 260px;
        }
        .select2-container--default .select2-selection--multiple .select2-selection__choice__remove {
    color: #fff;
    cursor: pointer;
    display: inline-block;
    font-weight: bold;
    margin-right: 5px;
}

        .select2-container--default.select2-container--focus .select2-selection--multiple {
    border: solid #aeaeae 1px;
    outline: 0;
}
    </style>
 

<%-- <script src="/JavaScript/jquery-1.8.3.min.js"></script>--%>

 <script type="text/javascript">

     var $noCon1 = jQuery.noConflict();
     $noCon1(window).load(function () {
         //document.getElementById("MymodalBundleInfo").style.display = "none";
         //document.getElementById("freezelayer").style.display = "none";



         document.getElementById("<%=divPrintCaptionDetails.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=lblPrintOnBrdDtls.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=divPrintReportDetails.ClientID%>").style.visibility = "hidden";


     });







     </script>

     <%--  for giving pagination to the html table--%>
<%--    <script src="/JavaScript/JavaScriptPagination1.js"></script>--%>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            //$p('#ReportTable').DataTable({
            //    "pagingType": "full_numbers",
            //    "bSort": false,
            //    "pageLength": 25,
            //    "bDestroy": true
            //});
        });

     </script>

    

<%--    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />--%>

<%--    <script>
        var $au = jQuery.noConflict();
        (function ($au) {
            $au(function () {
                $au('#cphMain_ddlDepartmnt').selectToAutocomplete1Letter();
                $au('form').submit(function () {
                });
            });
        })(jQuery);

        (function ($au) {
            $au(function () {
                $au('#cphMain_ddlDivision').selectToAutocomplete1Letter();
                $au('form').submit(function () {
                });
            });
        })(jQuery);

    </script>--%>
        <script>

            $noCon = jQuery.noConflict();
            $noCon2 = jQuery.noConflict();
            $noCon(function () {
                //Initialize Select2 Elements

                var prm = Sys.WebForms.PageRequestManager.getInstance();
                //  prm.add_initializeRequest(InitializeRequest);
                prm.add_endRequest(EndRequest);
                //  $noCon2(".select2").select2();



                // var data = document.getElementById("<%=hiddenselectedlist.ClientID%>").value;
                // var totalString = data;
                // var eachString = totalString.split(',');
                //  var newVar = new Array();
                //for (count = 0; count < eachString.length; count++) {
                //    if (eachString[count] != "") {
                //        newVar.push(eachString[count]);
                //        //alert(newVar);
                //    }
                //}

                //$noCon2('#cphMain_ddlemployee').val(newVar);
                // $noCon2("#cphMain_ddlemployee").trigger("change");


                //  checkclickedradio();



            });



            function EndRequest(sender, args) {
                // after update occur on UpdatePanel re-init the Autocomplete



                //$p('#ReportTable').DataTable({
                //    "bDestroy": true,
                //    "pagingType": "full_numbers",
                //    "bSort": false,
                //    "pageLength": 25,

                //});

            }





        </script>

         <script>


             function SearchValidation() {

                 var ret = true;


                 document.getElementById("<%=ddlDepartmnt.ClientID%>").style.borderColor = "";

                 document.getElementById('divMessageArea').style.display = "none";
                 var fromdate = document.getElementById("<%=ddlDepartmnt.ClientID%>").value;

                 //  var varddlDep = document.getElementById("<%=ddlDepartmnt.ClientID%>").value;


                 if (fromdate == "--SELECT DEPARTMENT--") {
                     document.getElementById('divMessageArea').style.display = "";
                     document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                     document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlDepartmnt.ClientID%>").style.borderColor = "Red";
                     document.getElementById("<%=ddlDepartmnt.ClientID%>").focus();
                     ret = false;
                 }


                 return ret;


             }



          </script>
    <script>
        function myFunction() {
            var varin=0;
            var input, filter, table, tr, td, i;
            input = document.getElementById("myInput");
            filter = input.value.toUpperCase();
            table = document.getElementById("ReportTable");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[1];
                if (td) {
                    if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                        varin = 1;
                    } else {
                        tr[i].style.display = "none";
                       
                    }
                }
            }
       
               
            if (varin == 0) {
                // $('#ReportTable ').append('<tr><td class="thT"colspan=8 style="width:100%;text-align: center; word-wrap:break-word;">NO DATA AVAILABLE</td></tr>');
               // if ($("tr td:contains('NO DATA AVAILABLE')")) {
                    document.getElementById('Tdisplay').style.display = "";
                    $('table#ReportTable tr#Remdisplay').remove();
               // }
               // else {
                   
               // }
                   
            }
            else {
                document.getElementById('Tdisplay').style.display = "none";
            }
                //alert(rowCount);
            
        }
        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }
        function CallCSVBtn() {
            document.getElementById("<%=BtnCSV.ClientID%>").click();
         }
</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

<asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenCorpId" runat="server" />
    <asp:HiddenField ID="hiddenOrgId" runat="server" />
    <asp:HiddenField ID="hiddenManpwrId" runat="server" />
    
    
     <asp:HiddenField ID="Hiddenselectedtext" runat="server" />
     <asp:HiddenField ID="hiddenselectedlist" runat="server" />
    <div id="divTitle" style="display:none" runat="server"></div>
       <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:4.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
        <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 3.5%; font-family: Calibri;" class="print" >
     <a id="A1" data-title="Visa Bundle"  href="javascript:;" onclick="CallCSVBtn();" style="color: rgb(83, 101, 51);margin-right:15%;">
       <img src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 60%;margin-right:15%;height: 96%;">
        <span style="margin-top: -28px; float: right;">CSV</span></a>                                  
</div>
    <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 3.5%; font-family: Calibri;" class="print">
     <a id="print_cap" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/Common_print.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -28px; float: right;">Print</span></a>                                  
</div>


    <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">
    
    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="\Images\BigIcons\Mess Calculation Report.png" style="vertical-align: middle;" />
     		Mess Calculation Report
        </div >


        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;width: 99%;margin-top:3%;min-height:190px;padding: 7px 0px 10px 12px;">


        
        <div class="col-lg-4" style="width: 33.3%;">
       
        <div class="eachform" style="margin-top:2.5%;margin-left:0%;width: 100%;height:35px">
         <h2 >Year* </h2>
        <asp:DropDownList ID="ddlYear" class="form1" runat="server" Style="height: 28px; width: 55%; float: left; margin-left: 13%;" >
           </asp:DropDownList>
        </div>
 
              </div>
              
        <div class="col-lg-4" style="width: 33.3%;">
       
        <div class="eachform" style="margin-top:2.5%;margin-left:0%;width: 100%;height:35px">
         <h2 >Month* </h2>
        <asp:DropDownList ID="ddlMonth" class="form1" runat="server" Style="height: 28px; width: 55%; float: left; margin-left: 13%;" >
           </asp:DropDownList>
        </div>
 
              </div>
        
        <div class="col-md-4" style="width: 33.3%;width: 33.3%;">

        <div class="eachform" style="margin-top:2.5%;margin-left:0%;width: 100%;height:35px">
         <h2 >Department * </h2>
        <asp:DropDownList ID="ddlDepartmnt" class="form1" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartmnt_SelectedIndexChanged"  runat="server" Style="height: 28px; width: 57%; float: left; margin-left: 2%;" >
           </asp:DropDownList>
        </div>
            </div>
     
         <div class="col-md-4" style="height: 69px;width: 33.3%;">
           <div class="eachform" style="margin-top:2.5%;margin-left:0%;">
         <h2 style="margin-left: 0%;">Division </h2>
        <asp:DropDownList ID="ddlDiv" class="form1" runat="server" Style="height: 28px; width: 55%; float: left; margin-left: 8%;">
           </asp:DropDownList>
        </div>
        </div>
                     <div class="col-md-4" style="width: 33.3%;">
           <div class="eachform" style="margin-top:2.5%;margin-left:1%;">
         <h2 style="margin-left: 0%;">Mess   </h2>
        <asp:DropDownList ID="ddlLeavTyp" class="form1" runat="server" Style="height: 28px; width: 55%; float: left; margin-left: 17%;">
           </asp:DropDownList>
        </div>
        </div>
                <div class="col-md-4" style="height:70px;width: 33.3%;">
    <asp:Button ID="btnSearch" style="cursor:pointer;float:right;margin-right:13%;margin-top: 3%;"  runat="server" OnClick="btnSearch_Click" class="searchlist_btn_lft" Text="Search"   OnClientClick="return SearchValidation()" />
</div> 

                        <div class="col-md-4" style="width: 30.3%;">
                            <style>
                                #myInput {
background-image: url('/css/searchicon.png');
background-position: 10px 10px;
background-repeat: no-repeat;
width: 42%;
font-size: 14px;
padding: 12px 20px 12px 40px;
border: 1px solid #ddd;
margin-bottom: 11px;
height: 9px;
}

                            </style>
           <div class="eachform" style="margin-top:2.5%;margin-left:1%;">
         <h2 style="margin-left: 0%; width:23%">Employee   </h2>
  <input type="text" id="myInput" onkeydown="return DisableEnter(event);" onkeyup="myFunction()" placeholder="Search Employee." title="Type in a name" style="margin-left: 2%;">
        </div>
        </div>
    
   </div>

<br />


     <div id="divReport"  runat="server" >
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>

    <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>


    <div id="divPrintReport" runat="server" style="display: none">
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>

</ContentTemplate>
        </asp:UpdatePanel>

</div>


 <%--------------------------------View for ManPower Requirement informatn--------------------------%>

   <%-- <div id="MymodalBundleInfo" class="modalInfoView" >

         <div class="modal-InfoView" style="width:100%">
 

            <div class="modal-headerInfoView">
                  <img class="closeInfoView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseManPowerRequiremtDetails();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                  <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Manpower Requirement Details</h3>
             </div>
            

            <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 1%; font-family: Calibri;" class="print">
            <a id="A1" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/24_Print.htm" style="color: rgb(83, 101, 51)">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -28px; float: right;">Print</span></a>    </div>   

           <div class="modal-bodyInfoView">

               <div style="border:.5px solid #929292; background-color: #c9c9c9;width: 100%;margin-top:1%;height:90px;">


               <div id="divRef" style="width: 55%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 1%; width: 16%; float: left;color: #603504;">Ref#</h2>
                   <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="lblRef" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 30%; cursor: inherit"></label>
                 </div>

               <div id="divResrc" style="width: 45%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 1%; width: 34%; float: left;color: #603504;">No of Resources</h2>
                   <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="lblResrc" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 59%; cursor: inherit;"></label>
                </div>

                <div id="divDivsn" style="width: 55%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 1%; width: 16%; float: left;color: #603504;">Division</h2>
                   <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="lblDivsn" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 64%; cursor: inherit"></label>
                </div>

               <div id="divDsgntn" style="width: 45%; float: left; margin-top: 1%;word-wrap:break-word;">
                   <h2 style="margin-left: 1%; width: 34%; float: left;color: #603504;">Designation</h2>
                   <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="lblDsgntn" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 60%; cursor: inherit;"></label>
                   <br />
                   <br />
                   <br />

               </div>
                  
              </div>

               <h2><u>Selected Candidates</u></h2><br /><br /><br />

            <div id="divOnBoardingDtls" class="table-responsive" runat="server" style="overflow:auto;max-height:220px;" >
            <br />
            <br />
            <br />
            </div>

          </div>

          <div class="modal-footerInfoView" style="margin-top: 21px;">
                   </div>


        </div>

       </div>--%>

       <%-- <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>--%>



    <div id="divPrintCaptionDetails" class="table-responsive" runat="server">
            </div>

   <label id="lblPrintOnBrdDtls" runat="server" style="float: left; cursor: inherit"></label>

    <div id="divPrintReportDetails" class="table-responsive" runat="server">
         <br />
       </div>

  

    <style>


    #ReportTableDtl_length {
    margin-bottom: 1%;
    font-family: Calibri;
    font-weight: bold;
    font-size: 14px;
    padding-bottom: 0.7%;
}

    #ReportTableDtl_filter {
    font-family: Calibri;
    font-weight: bold;
    font-size: 14px;
}

    #ReportTableDtl_info {
    font-family: Calibri;
    font-weight: 600;
    font-size: 14px;
}

    #ReportTableDtl_paginate {
    font-family: Calibri;
    font-size: 13px;
}


        .open > .dropdown-menu {
            display: none;
        }
    </style>

</asp:Content>

