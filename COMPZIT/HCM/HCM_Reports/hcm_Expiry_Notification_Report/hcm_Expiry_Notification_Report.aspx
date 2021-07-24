<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Expiry_Notification_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_OnBoard_Status_Report_hcm_Onboard_Status_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

       <style>
             input[type="radio"] {
            display: block;
            float: left;
            font-family: Calibri;
        }


         input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
            cursor:default;
        }
        .searchlist_btn_rght {
        
         cursor:pointer;
         font-size: 13px; 
         float:left;
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
            document.getElementById("<%=ddlDepartmnt.ClientID%>").focus();

     });

        function getdetails(href) {
            window.location = href;
            return false;
        }
        function printsorted() {
            document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
            //   $('#cphMain_divPrintReportSorted table tr').find('td:eq(3),th:eq(3)').remove();
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
        // for not allowing enter
        function DisableEnter(evt) {

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
    <script>
        function SearchValidation() {

            var ret = true;
            document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
            var fromdate = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var toDate = document.getElementById("<%=txtTodate.ClientID%>").value;
     
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
                    document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "Red";
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
  <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                // "pageLength": 25
                "bLengthChange": false,
                "bPaginate": false
            });
        });


    </script>



    <style>
        #cphMain_divReport {
            float: left;
            width: 98.5%;
        }

        #cphMain_divAdd {
            position: fixed;
            /*right: 4%;*/
            padding-left: 83.5%;
        }

        #TableRprtRow .tdT {
            line-height: 100%;
        }
        .open > .dropdown-menu {
            display: none;
        }

        .cont_rght {
            width: 98%;
        }
    </style>
    <script>
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
       <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <asp:HiddenField ID="hiddenNext" runat="server" />
    <asp:HiddenField ID="hiddenPrevious" runat="server" />
    <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
    <asp:HiddenField ID="hiddenMemorySize" runat="server" />
    <asp:HiddenField ID="hiddenSearch" runat="server" Value="--SELECT ALL DIVISION--" />


        <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />


    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
      <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:1.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A3"  data-title="Item Listing"  style="float: right; margin-top:5.5%;color:rgb(83, 101, 51);font-family:Calibri;width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left:49%;margin-top: 5%;" ><span style="margin-top: 7%;float: right;margin-right: 10%;">CSV</span> </a> 

     <div style="cursor: default; float: right; height: 25px; margin-right:-3.5%;margin-top:6%;font-family:Calibri;" class="print" onclick="printsorted()">            
                                 <a id="A1" target="_blank" data-title="Document Expiry Report"  href="/HCM/HCM_Reports/Print/sort_EmpDtlsRprt.htm" style="color:rgb(83, 101, 51)" >
                                <img src="../../../Images/Other%20Images/imgPrint.png" style="max-width: 45%">
                                 <span style="margin-top: 2%;float: right;margin-right: 0%;">Print</span></a>                                    
                                </div>
    <div style="display:none;cursor: default; float: right; height: 25px; margin-right:3.5%;margin-top:6%;font-family:Calibri;" class="print" onclick="printredirect()">            
                                 <a id="print_cap" target="_blank" data-title="Document Expiry Report"  href="/HCM/HCM_Reports/Print/Common_print.htm" style="color:rgb(83, 101, 51)" >
                                <img src="../../../Images/Other%20Images/imgPrint.png" style="max-width: 45%">
                                 Print</a>                                    
                                </div>

    <div id="divSuccessUpd" style="visibility: hidden">
        <asp:Label ID="lblSuccessUpd" runat="server"></asp:Label>
    </div>
    <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
    <div class="cont_rght">
   
                             
     

        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/Expiry Notification Report.png" style="vertical-align: middle;" />
      Expiry Notification Report

        </div>
        
        <br />
             
                           <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;width: 98%;margin-top:3%;height:135px;">
          
           <br />

                        <div class="row">
                              <asp:UpdatePanel ID="UpdatePanel1" style="width: 79%;" EnableViewState="true" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                    <div class="col-md-4" style="width: 38%;">
                                        <%--<div style="margin-top:2.5%;margin-left:5%">--%>
                                        <h2 style="margin-left: 1%;">Department   </h2>

                                        <asp:DropDownList ID="ddlDepartmnt" class="form1" runat="server" Style="height: 28px; width: 57%; float: left; margin-left: 6%;" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartmnt_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <%--</div>--%>
                                    </div>

                                    <div class="col-sm-4" style="width: 38%; padding-left: 5px;">
                                        <%--<div  style="margin-top: 2.5%; margin-left: 8%">--%>
                                        <h2>Division </h2>

                                        <asp:DropDownList ID="ddlDivision" class="form1" runat="server" Style="height: 28px; float: left; margin-left: 8%; width: 56%;">
                                        </asp:DropDownList>
                                        <%--</div>--%>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                           <div class="col-md-4" style="float: left; margin-left: -4%;">


                              <%--  <div class="eachform" style="width: 70%; padding: 1%; float: left; margin: 0%;">--%>
                                    <div id="div15" class="subform" style="float: left; width: 430px; border: 1px solid rgb(155, 164, 139); margin-top: 1%; padding: 3%;">
                                        <asp:RadioButton ID="Radiopassport" onkeypress="return isTag(event);" Style="float: left; width: 24%;" Checked="True" Text="Passport" runat="server" GroupName="RadioHusfathernone" />

                                        <asp:RadioButton ID="RadioNationlid" onkeypress="return isTag(event);" Style="float: left;width: 34%;" Text="National Id Card" runat="server" onchange="IncrmntConfrmCounterDep();" GroupName="RadioHusfathernone" />
                                     

                                        <asp:RadioButton ID="Radiovisa" onkeypress="return isTag(event);" Style="float: left;width: 17%;" Text="Visa" runat="server" onchange="IncrmntConfrmCounterDep();" GroupName="RadioHusfathernone" />
                                         <asp:RadioButton ID="RadioHC" onkeypress="return isTag(event);" Style="float: left;" Text="Health Card" runat="server" onchange="IncrmntConfrmCounterDep();" GroupName="RadioHusfathernone" />



                                    </div>
                                <%--</div>--%>


                            </div>

                            

                        </div>
                              <br />

                        <div class="row">
                            
                           <div class="col-sm-4" style="width: 28%;">
                                <%--<div class="eachform" style="float: left; width: 19%; margin-top: 1.5%; margin-left: -22.3%;">--%>
                                <h2 style="margin-left: 0.5%;">From Date </h2>

                                <div id="div1" class="input-append date" style="float: left;">



                                    <asp:TextBox ID="txtFromDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Style="height:30px;width: 76%;height: 30px;margin-top: 0%;float: left;/* width: 75.6%; */margin-left: 18.7%;"></asp:TextBox>

                                    <input type="image" runat="server" id="Image1" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style="height: 22px; width: 22px;" />
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

                            <div class="col-sm-4" >
                                <%--<div class="eachform" style="float:left;width:25%;margin-top:1.5%;margin-left:2%;">--%>
                                <h2>To Date </h2>

                                <div id="div2" class="input-append date" style="float: left;margin-left: 10%;">

                                    <asp:TextBox ID="txtTodate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="height:30px;width: 79%;height: 30px;/* width: 79.6%; */margin-top: 0%;float: left;"></asp:TextBox>

                                    <input type="image" runat="server" id="Image2" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style="height: 22px; width: 22px; " />
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
                                <%--</div>--%>
                            </div>

                                      <div class="col-md-4" style="width: 25.6%;margin-left: -5.5%;">
                                        <%--<div style="margin-top:2.5%;margin-left:5%">--%>
                                        <h2 style="margin-left: 1%;">Status   </h2>

                                        <asp:DropDownList ID="ddlStatus" class="form1" runat="server" Style="height: 28px;width: 62%;float: left;margin-left: 14%;">
                                              <asp:ListItem Selected="True">-- SELECT STATUS--</asp:ListItem>
                                            <asp:ListItem Value="1">Expired</asp:ListItem>
                                            <asp:ListItem Value="2">Not Expired</asp:ListItem>

                                        </asp:DropDownList>
                                        <%--</div>--%>
                                    </div>



 <div class="col-sm-4" style="width: 0%;margin-left: -0.5%;float: left;">



                            <div class="eachform" >
                                <asp:Button ID="btnsearch" Style="cursor: pointer;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />
                            </div>
                                   </div>
                        </div>

                        <br style="clear: both" />
                    </div>
                 
        

        <br />
        <table>
            <tr>
                <td style="width:50%;">
                    <asp:Button ID="btnPrevious"   Width="98%" runat="server" class="searchlist_btn_rght" Text="Show Previous 500 Records" OnClick="btnPrevious_Click" Visible="false" OnClientClick="SetHiddenSearchCriteria(); " />
                </td>
                <td style="width:50%;">

                    <asp:Button ID="btnNext" Width="98%"  runat="server" Visible="false" class="searchlist_btn_rght" Text="Show Next 500 Records" OnClick="btnNext_Click" OnClientClick="SetHiddenSearchCriteria();"/>
                </td>
            </tr>
        </table>
         
         
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
            
         <div id="divPrintReport" runat="server" style="display: none">
                                    <br />
                                </div>
        <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
    </div>
             <div id="divTitle" runat="server" style="display: none">
     Expiry Notification Report
      </div>
                <div id="divPrintReportSorted" runat="server" style="display: none">
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
              .cont_rght 
              {
             width: 102%;
               min-height: 307px;
                }
              .open > .dropdown-menu {
            display: none;
        }
                              </style>


    
  </div> 
</asp:Content>

