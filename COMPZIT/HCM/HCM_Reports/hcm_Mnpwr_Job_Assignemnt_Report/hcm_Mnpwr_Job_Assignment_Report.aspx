<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Mnpwr_Job_Assignment_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_Mnpwr_Job_Assignemnt_Report_hcm_Mnpwr_Job_Assignment_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
<link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
<script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
<link href="/JavaScript/multiselect/AdminLTE.min.css" rel="stylesheet" />

    <%-- <script src="../../../JavaScript/JavaScriptPagination1.js"></script>--%>
    <script src="../../../JavaScript/JavaScriptPagination2.js"></script>
    <link href="../../../css/StyleSheetPagination.css" rel="stylesheet" />
    <style>
         .cont_rght {
            width: 98%;
        }

              

    </style>
    <style>
        input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
            cursor: default;
        }

        .searchlist_btn_rght {
            cursor: pointer;
            font-size: 13px;
            float: left;
        }

            .searchlist_btn_rght:hover {
                background: #7B866A;
            }

            .searchlist_btn_rght:focus {
                background: #7B866A;
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
            background: url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        }

        .searchlist_btn_lft:focus {
            background: url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        }

     

        input[type="radio"] {
            display: block;
            float: left;
        }

        #divRadio {
            font-size: 15px;
            color: rgb(83, 101, 51);
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
 
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                //"pageLength": 25
                "bLengthChange": false,
                "bPaginate": false
            });
        });


    </script>
    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            //$noCon("#divddlEmployee input.ui-autocomplete-input").select();
        });
    </script>
 <%--   
    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>--%>

<%--    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />--%>

    <script>
        //var $au = jQuery.noConflict();
        //(function ($au) {
        //    $au(function () {
        //        $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
        //        $au('form').submit(function () {
        //        });
        //    });
        //})(jQuery);
        var $noCon = jQuery.noConflict();
        $noCon2 = jQuery.noConflict();
        $noCon(function () {
            // LoadEmpList();
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

              $noCon2('#cphMain_ddlEmployee').val(newVar);
              $noCon2("#cphMain_ddlEmployee").trigger("change");



          });


        function selected() {
       
            var a;
            var sel = "";


            a = $noCon2('#cphMain_ddlEmployee').val();
            $noCon2("#cphMain_ddlEmployee option:selected").each(function () {
                var $noCon2this = $noCon2(this);
               
                if ($noCon2this.length) {
                    var selText = $noCon2this.text();
                    sel = sel + selText + ",";

                    document.getElementById("<%=Hiddenselectedtext.ClientID%>").value = sel;
                       }
                   });
                   document.getElementById("<%=hiddensearchby.ClientID%>").value = "Employee";
              document.getElementById("<%=hiddenselectedlist.ClientID%>").value = a;

              return true;
          }


        function SearchValidation() {
            var ret = true;
            selected();
            document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
          //  document.getElementById('divMessageArea').style.display = "";
            var fromdate = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var toDate = document.getElementById("<%=txtTodate.ClientID%>").value;
            
            if (fromdate != "" && toDate != "")
            {

                var arrDateFromchk = fromdate.split("-");
                dateDateFromchk = new Date(arrDateFromchk[2], arrDateFromchk[1] - 1, arrDateFromchk[0]);

                var arrDateTochk = toDate.split("-");
                dateDateTochk = new Date(arrDateTochk[2], arrDateTochk[1] - 1, arrDateTochk[0]);
                if (dateDateFromchk > dateDateTochk)
                {

                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "From date should be less than to date";
                    document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtFromDate.ClientID%>").focus();

                    ret = false;
                }
                
            }

            if (fromdate == "" && toDate == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please select a date range";
                document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "Red";
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
                document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtTodate.ClientID%>").focus();
                ret = false;
            }
           
            return ret;
        }


        function DetailsPrint() {
            //printing detail table

            var ManpwrId = document.getElementById("<%=hiddenManpwrId.ClientID%>").value;
          var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
          var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
            var fromDate = document.getElementById("<%=hiddenFromDate.ClientID%>").value;
            var ToDate = document.getElementById("<%=hiddenTodate.ClientID%>").value;
            var AssignedTo = document.getElementById("<%=hiddenAssignedTo.ClientID%>").value;
            var Project = document.getElementById("<%=hiddenproject.ClientID%>").value;
            var sts1 = document.getElementById("<%=Hiddenstatus.ClientID%>").value;
            var Selectedsts = document.getElementById("<%=HiddenCheckedText.ClientID%>").value;
            var ProjectText = document.getElementById("<%=HiddenProjectText.ClientID%>").value; 
            var AssginedText = document.getElementById("<%=Hiddenselectedtext.ClientID%>").value;
            var Gnrtedby = '<%=Session["USERFULLNAME"]%>';
            //alert(ManpwrId);
            //alert(CorpId);

            //alert(OrgId);

            //alert(fromDate);
            //alert(ToDate);
            //alert(AssignedTo);
            //alert(Project);
            //alert(sts);
            //alert(Project);

           

            var Details = PageMethods.ManpwrDetailsPrint(ManpwrId, CorpId, OrgId,fromDate,ToDate,AssignedTo,Project,sts1,Selectedsts,ProjectText,AssginedText,Gnrtedby, function (response) {

              if (response[0] != "" && response[0] != null) {
                  document.getElementById("<%=divPrintCaption.ClientID%>").innerHTML = response[0];
             }

             if (response[1] != "" && response[1] != null) {
                 document.getElementById("<%=lblPrintOnBrdDtls.ClientID%>").innerHTML = response[1];
              }

             if (response[2] != "" && response[2] != null) {
                 document.getElementById("<%=divPrintReportDetails.ClientID%>").innerHTML = response[2];
             }
                var nWindow = window.open('../Print/49_print.htm');
         });
          
            return false;
      }

    </script>
      <script>
          $noCon = jQuery.noConflict();
          $noCon2 = jQuery.noConflict();
          $noCon(function () {
              //Initialize Select2 Elements
              $noCon2(".select2").select2();

              //  checkclickedradio();
              document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "";


          });

          function CaptionCall() {
              //printing detail table
              var ManpwrId = document.getElementById("<%=hiddenManpwrId.ClientID%>").value;
              var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
              var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
              var fromDate = document.getElementById("<%=hiddenFromDate.ClientID%>").value;
              var ToDate = document.getElementById("<%=hiddenTodate.ClientID%>").value;
              var AssignedTo = document.getElementById("<%=hiddenAssignedTo.ClientID%>").value;
              var Project = document.getElementById("<%=hiddenproject.ClientID%>").value;
              var sts1 = document.getElementById("<%=Hiddenstatus.ClientID%>").value;
              var Selectedsts = document.getElementById("<%=HiddenCheckedText.ClientID%>").value;
              var ProjectText = document.getElementById("<%=HiddenProjectText.ClientID%>").value;
              var AssginedText = document.getElementById("<%=Hiddenselectedtext.ClientID%>").value;
              var Gnrtedby = '<%=Session["USERFULLNAME"]%>';
              var Details = PageMethods.ManpwrDetailsPrint(ManpwrId, CorpId, OrgId, fromDate, ToDate, AssignedTo, Project, sts1, Selectedsts, ProjectText, AssginedText,Gnrtedby, function (response) {

                  if (response[0] != "" && response[0] != null) {
                      document.getElementById("<%=divPrintCaption.ClientID%>").innerHTML = response[0];
                  }
                  document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
                  var nWindow = window.open('/HCM/HCM_Reports/Print/sort_EmpDtlsRprt.htm');

              });
              return false;
          }
          function CallCSVBtn() {
              document.getElementById("<%=BtnCSV.ClientID%>").click();
            }
          </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
      <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
      <asp:HiddenField ID="hiddenFromDate" runat="server" />
      <asp:HiddenField ID="hiddenTodate" runat="server" />
      <asp:HiddenField ID="hiddenAssignedTo" runat="server" />
     <asp:HiddenField ID="hiddenproject" runat="server" />
     <asp:HiddenField ID="HiddenProjectText" runat="server" />

          <asp:HiddenField ID="Hiddenstatus" runat="server" />
    <asp:HiddenField ID="hiddenManpwrId" runat="server" />
     <asp:HiddenField ID="hiddenCorpId" runat="server" />
     <asp:HiddenField ID="hiddenOrgId" runat="server" />
     <asp:HiddenField ID="HiddenHr" runat="server" />
    <asp:HiddenField ID="hiddensearchby" Value="0" runat="server" />
    <asp:HiddenField ID="hiddenselectedlist"  runat="server" />
      <asp:HiddenField ID="Hiddenselectedtext" runat="server" />
        <asp:HiddenField ID="HiddenCheckedText" runat="server" />
          <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:4.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A2"  data-title="Item Listing"  style="float: right; margin-top:3.4%;color:rgb(83, 101, 51);font-family:Calibri;width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left: 33%;" ><span style="margin-top: 3px; float: right;margin-right: 25%;">CSV</span> </a> 
        <div style="cursor: default; float: right; height: 25px; margin-right: -2.5%; margin-top: 3.5%; font-family: Calibri;" class="print" >
     <a id="A1" target="_blank" data-title="Item Listing" href="#" onclick="return CaptionCall()" style="color: rgb(83, 101, 51)">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
        <span style="margin-top: 2px; float: right;"> Print</span></a>                                  
</div>
    <div style="display:none; cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 3.5%; font-family: Calibri;" class="print" onclick="return DetailsPrint()">
     <a id="print_cap" target="_blank" data-title="Item Listing" href="/HCM/HCM_Reports/Print/49_print.htm" style="color: rgb(83, 101, 51)">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
        <span style="margin-top: 2px; float: right;">Print</span></a>                                  
</div>
       <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

      <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="/Images/BigIcons/Manpower Job Assignment.png" style="vertical-align: middle;" />
    Manpower Job Assignment Report
        </div >
        <div >

            <div style="float:left;margin-top:14px;border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 99.8%;margin-bottom: 1%;">
                <div class="row">
                 <div class="eachform" style="width: 24%; margin-top: 1.5%; float: left; margin-left: 3%;">
                <h2>From Date*</h2>
                
               <div id="div1" class="input-append date" style="margin-right: 16%; width: 39%; float: right;">

                 
                   
                        <asp:TextBox ID="txtFromDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="float: left; width: 107.6%; height: 30px;"></asp:TextBox>

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
      

      <div class="eachform" style="width: 28%; margin-top: 1.5%; float: left; margin-left: 8%;">
                <h2>To Date*</h2>
                
               <div id="div2" class="input-append date" style="float: right; margin-right: 31%; width: 33%;">

                        <asp:TextBox ID="txtTodate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="height: 30px; float: left; width: 94.6%;"></asp:TextBox>

                        <input type="image" runat="server" id="Image2" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:-0.2%;" />
                    <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                            
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



                    <div class="eachform" style="width: 25%; margin-top: 1.5%; float: left; margin-left: 3%;">
                <h2> Project</h2>
                
               <div id="div5" class="input-append date" style="float: left; margin-left: 10%; width: 74%;">

                     
                   <asp:DropDownList ID="ddlProject" class="form1"   Height="30px" Width="71%" Style="height: 30px; width: 90.6%; margin-top: 0%; float: left; margin-left: 12.7%;" runat="server"  >      </asp:DropDownList>
                      
                       </div>
              

            </div></div>
                  <div class="row">
                       <div class="eachform" style="width: 25%; margin-top: 1.5%; float: left; margin-left: 3%;">

                <h2 style="margin-top:1%;">Status</h2>

                <asp:DropDownList ID="ddlSts" Height="25px"  Width="248px" class="form1"  runat="server" Style="height: 28px; float: right; width: 57%;">
                   <%--   <asp:ListItem Text="APPROVED" Value="4" ></asp:ListItem>
                       <asp:ListItem Text="CLOSED" Value="7"></asp:ListItem>
                    --%>
                    
                     
                </asp:DropDownList>


            </div>
               
                  <div class="eachform" style="width: 29%; margin-top: 1.5%; float: left; margin-left: 7%;">
                <h2 style="width:34%"> Assigned To</h2>
          <%--      
               <div id="div3"  style="float:right;margin-right:-1%;width: 69%;">--%>
                    <asp:DropDownList ID="ddlEmployee" class="form-control select2" multiple="multiple" onchange="return selected()"  data-placeholder="Select an Employee"  Style="width: 65%;" runat="server" >
                        </asp:DropDownList>
                  
                      <%-- </div>--%>
              
                      
            </div>
                 <asp:Button ID="btnSearch" style="cursor: pointer; float: right; margin-right: 8%; margin-top: 1.5%;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation()" OnClick="btnSearch_Click"/>
                 <%-- <div class="eachform" style="width:25%;">
              <asp:Button ID="btnSearch" style="cursor:pointer;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click"  />
         </div>  --%>
       </div>
            </div>               
     
   </div>
         
         <div id="divReport" class="table-responsive" runat="server" style="float: left;width:100%">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
          
    <div id="divPrintCaption" class="table-responsive" runat="server"  style="visibility: hidden;">
            </div>

   <label id="lblPrintOnBrdDtls" runat="server" style="float: left; cursor: inherit;visibility: hidden;" ></label>

    <div id="divPrintReportDetails" class="table-responsive" runat="server" style="visibility: hidden;">
         <br />
       </div>
             <div id="divTitle" runat="server" style="display: none">
      Manpower Job Assignment Report
      </div>

               <div id="divPrintReportSorted" runat="server" style="display: none">
                                    <br />
                                </div>
      </div>
    <style>
           #ReportTable_filter input {
            height: 18px;
            width: 208px;
            color: #336B16;
            font-size: 14px;
            margin-bottom: 5%;
        }
    </style>
</asp:Content>

