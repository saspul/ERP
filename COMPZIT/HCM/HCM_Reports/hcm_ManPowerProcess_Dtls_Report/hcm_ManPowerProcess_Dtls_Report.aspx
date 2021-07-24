<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_ManPowerProcess_Dtls_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_ManPowerProcess_Dtls_Report_hcm_ManPowerProcess_Dtls_Report" %>

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
         document.getElementById("MymodalBundleInfo").style.display = "none";
         document.getElementById("freezelayer").style.display = "none";

      

         document.getElementById("<%=divPrintCaptionDetails.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=lblPrintOnBrdDtls.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=divPrintReportDetails.ClientID%>").style.visibility = "hidden";


     });


     function OpenManPowerRequiremtDetails(ManPwrId, sts) {

         document.getElementById("MymodalBundleInfo").style.display = "block";
         document.getElementById("freezelayer").style.display = "";

         document.getElementById("<%=hiddenManpwrId.ClientID%>").value = ManPwrId;

         var Details = PageMethods.ManPowerRequiremtDetails(ManPwrId, sts, function (response) {

             if (response[0] != "" && response[0] != null) {
                 document.getElementById("<%=lblRef.ClientID%>").innerHTML = response[0];
             }

             if (response[1] != "" && response[1] != null) {
                 document.getElementById("<%=lblResrc.ClientID%>").innerHTML = response[1];
             }

             if (response[2] != "" && response[2] != null) {
                 document.getElementById("<%=lblDivsn.ClientID%>").innerHTML = response[2];
             }

             if (response[3] != "" && response[3] != null) {
                 document.getElementById("<%=lblDsgntn.ClientID%>").innerHTML = response[3];
             }

             if (response[4] != "" && response[4] != null) {
                 document.getElementById("<%=divOnBoardingDtls.ClientID%>").innerHTML = response[4];
             }


             $p(document).ready(function () {
                 $p('#ReportTableDtl').DataTable({
                     "pagingType": "full_numbers",
                     "bSort": true,
                     "pageLength": 25,
                     "bDestroy": true
                 });
             });



         });

     }


      function CloseManPowerRequiremtDetails() {
          document.getElementById('divMessageArea').style.display = "none";
          document.getElementById('imgMessageArea').src = "";
          document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
         document.getElementById("MymodalBundleInfo").style.display = "none";
         document.getElementById("freezelayer").style.display = "none";
     }

     </script>

     <%--  for giving pagination to the html table--%>
<%--    <script src="/JavaScript/JavaScriptPagination1.js"></script>--%>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": false,
           //     "pageLength": 25,
                "bDestroy": true,
                "bLengthChange": false,
                "bPaginate": false
            });
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
                $noCon2(".select2").select2();



                var data = document.getElementById("<%=hiddenselectedlist.ClientID%>").value;
                var totalString = data;
                var eachString = totalString.split(',');
                var newVar = new Array();
                for (count = 0; count < eachString.length; count++) {
                    if (eachString[count] != "") {
                        newVar.push(eachString[count]);
                        //alert(newVar);
                    }
                }

                $noCon2('#cphMain_ddlemployee').val(newVar);
                $noCon2("#cphMain_ddlemployee").trigger("change");


                //  checkclickedradio();
                document.getElementById("<%=ddlemployee.ClientID%>").style.borderColor = "";


          });


         
          function EndRequest(sender, args) {
              // after update occur on UpdatePanel re-init the Autocomplete

              $noCon2(".select2").select2();

              var data = document.getElementById("<%=hiddenselectedlist.ClientID%>").value;
              var totalString = data;
              var eachString = totalString.split(',');
              var newVar = new Array();
              for (count = 0; count < eachString.length; count++) {
                  if (eachString[count] != "") {
                      newVar.push(eachString[count]);
                      //alert(newVar);
                  }
              }

              $noCon2('#cphMain_ddlemployee').val(newVar);
              $noCon2("#cphMain_ddlemployee").trigger("change");

              $p('#ReportTable').DataTable({
                  "bDestroy": true,
                  "pagingType": "full_numbers",
                  "bSort": false,
                  // "pageLength": 25,
                  "bLengthChange": false,
                  "bPaginate": false
              });
              $noC('#divToDate').datetimepicker({
                  format: 'dd-MM-yyyy',
                  language: 'en',
                  pickTime: false,
                  //  startDate: new Date(),
              });
              $noC('#divFrmDate').datetimepicker({
                  format: 'dd-MM-yyyy',
                  language: 'en',
                  pickTime: false,
                  endDate: new Date(),
              });

          }





                    </script>

         <script>
      
             function selected() {
                 var a;
                 var sel = "";


                 a = $noCon2('#cphMain_ddlemployee').val();
                 $noCon2("#cphMain_ddlemployee option:selected").each(function () {
                     var $noCon2this = $noCon2(this);
                     if ($noCon2this.length) {
                         var selText = $noCon2this.text();
                         sel = sel + selText + ",";

                         document.getElementById("<%=Hiddenselectedtext.ClientID%>").value = sel;
                }
            });
 
                    document.getElementById("<%=hiddenselectedlist.ClientID%>").value = a;
               
                    return true;
             }

             function SearchValidation()
             {
                
                     var ret = true;
                     selected();
                     document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
               //  document.getElementById("<%=ddlDepartmnt.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";
                         //  document.getElementById('divMessageArea').style.display = "";
                         var fromdate = document.getElementById("<%=txtFromDate.ClientID%>").value;
                 var toDate = document.getElementById("<%=txtToDate.ClientID%>").value;

               //  var varddlDep = document.getElementById("<%=ddlDepartmnt.ClientID%>").value;
               

                         if (fromdate == "" && toDate == "") {
                             document.getElementById('divMessageArea').style.display = "";
                             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please select a date range";
                document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtFromDate.ClientID%>").focus();

                ret = false;
            }
            else if (fromdate == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please select a date range";
                document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtFromDate.ClientID%>").focus();

                ret = false;

            }
            else if (toDate == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please a date range";
                document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtToDate.ClientID%>").focus();
                ret = false;
            }

                 if (fromdate != "" && toDate != "") {

                     var arrDateFromchk = fromdate.split("-");
                     dateDateFromchk = new Date(arrDateFromchk[2], arrDateFromchk[1] - 1, arrDateFromchk[0]);

                     var arrDateTochk = toDate.split("-");
                     dateDateTochk = new Date(arrDateTochk[2], arrDateTochk[1] - 1, arrDateTochk[0]);
                     if (dateDateFromchk > dateDateTochk) {

                         document.getElementById('divMessageArea').style.display = "";
                         document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                         document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "From date should be less than to date";
                         document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                         document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                         document.getElementById("<%=txtFromDate.ClientID%>").focus();

                         ret = false;
                     }
                              }
    return ret;


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
     <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:1.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A3"  data-title="Item Listing"  style="float: right; margin-top:4.5%;color:rgb(83, 101, 51);font-family:Calibri;margin-right: 1.5%;width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left: 38%;" ><span style="margin-top: 3px; float: right;margin-right: 19%;margin-top: 0%;">CSV</span> </a>
    <div style="cursor: default; float: right; height: 25px; margin-right: -2.5%; margin-top: 4.5%; font-family: Calibri;" class="print">
     <a id="print_cap" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/hcm_ManPowerProcess_Dtls_Report/Print/26_Print.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -24px; float: right;">Print</span></a>                                  
</div>


    <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">
    
    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="\Images\BigIcons\Manpower Process Details.png" style="vertical-align: middle;" />
     	Manpower Process Details Report
        </div >


        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;width: 99%;margin-top:3%;min-height:150px;padding: 7px 0px 10px 12px;">


        
        <div class="col-lg-7">
        <div style="float: left;width: 100%;border: 1px solid #9ba48b;">
        <h2 style="float: left;width: 22%;margin-top: 1%;margin-left: 39%;color: #536533;">Approved Date </h2>
    <div class="eachform" style="float: left;width: 50%;">
                <h2 style="margin-top: 2%;margin-left: 9%;">From Date*</h2>
                
               <div id="divFrmDate" class="input-append date" style="float: left; width: 42%; margin-left: 11%;">
                        
                 <asp:TextBox ID="txtFromDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  Style="height:30px;width:77.6%;margin-top: 0%;float:left;margin-left: -2.3%;" onkeypress="return DisableEnter(event)"></asp:TextBox>

                        <input type="image"  id="Image1" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

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
                            $noC('#divFrmDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(),
                            });
                        </script>

                        <p style="visibility: hidden">Please enter</p>
                       </div>

            </div>
      

      <div class="eachform" style="float: left; width: 46%;">
                <h2 style="margin-top: 2%; margin-left: 8%;">To Date*</h2>
                
                 <div id="divToDate" class="input-append date" style="float:left;margin-left:15%;width: 46%;">

                  <asp:TextBox ID="txtToDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  Style="height:30px;width:73.6%;margin-top: 0%;float:left;margin-left: 0%;" onkeypress="return DisableEnter(event)"></asp:TextBox>

                        <input type="image" id="Image2" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;"  />
                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divToDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                              //  startDate: new Date(),
                            });

                        </script>

                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div>
             </div>
              </div>
        <div class="col-md-5">

        <div class="eachform" style="margin-top: 7.5%; width: 100%; height: 55px;">
         <h2 style="margin-left: 9%; width: 25%;" >Department  </h2>
        <asp:DropDownList ID="ddlDepartmnt" class="form1" runat="server" Style="height: 28px; width: 45%; float: left; margin-left: 2%;" >
           </asp:DropDownList>
        </div>
            </div>
        <div class="row">
          <div class="col-md-4" style="width: 30%;">
     
                <div class="eachform" style="margin-left: 6%; width: 94%;">
         <h2 style="width: 37%;">Assigned To</h2>
        <asp:DropDownList ID="ddlemployee" class="form-control select2" multiple="multiple" data-placeholder="Select an Employee" onchange="return selected()"  runat="server" Style="height: 28px; width: 63%; float: left; margin-left: 2%;" >
           </asp:DropDownList>
        </div>
            </div>
                     <div class="col-md-4" style="width: 30%;">
           <div class="eachform" >
         <h2 style="margin-left: 7%;">Project  </h2>
        <asp:DropDownList ID="ddlProjct" class="form1" runat="server" Style="height: 33px; width: 63%; float: left; margin-left: 7%;">
           </asp:DropDownList>
        </div>
        </div>
                <div class="col-md-4" style="width: 31%;">
    <asp:Button ID="btnSearch" style="cursor: pointer; float: right; margin-top: 0%;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClick="btnSearch_Click" OnClientClick="return SearchValidation()" />
</div> 
       </div> 
   </div>

<br />


     <div id="divReport" class="table-responsive" runat="server" >
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

    <div id="MymodalBundleInfo" class="modalInfoView" >

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

       </div>

        <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>



    <div id="divPrintCaptionDetails" class="table-responsive" runat="server">
            </div>

   <label id="lblPrintOnBrdDtls" runat="server" style="float: left; cursor: inherit"></label>

    <div id="divPrintReportDetails" class="table-responsive" runat="server">
         <br />
       </div>

  

    <style>

        #ReportTable_filter input {
            height: 20px;
            width: 208px;
            color: #336B16;
            font-size: 14px;
            margin-bottom: 5%;
        }

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

