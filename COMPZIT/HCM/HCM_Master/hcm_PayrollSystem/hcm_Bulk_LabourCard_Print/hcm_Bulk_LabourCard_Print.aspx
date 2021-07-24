<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="hcm_Bulk_LabourCard_Print.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Bulk_LabourCard_Print_hcm_Bulk_LabourCard_Print" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>

<style>
    .modalLoadingMail {
        display: none; /* Hidden by default */
        position: fixed; /* Stay in place */
        /* Sit on top */
        padding-top: 25%; /* Location of the box */
        margin-left: 45%;
        margin-top: 16%;
        width: 90%; /* Full width */
        height: 58%; /*/ /* Full height */
       
        background-color: transparent;
        padding: 4%; /* Location of the box */
        border: 16px solid #f3f3f3;
        border-radius:50%;
        border-top: 16px solid #3498db;
        border-bottom: 16px solid #3498db;
        width: 120px;
        height: 120px;
       
        animation: spin 1s linear infinite;
        
    }

    @-webkit-keyframes spin {
  0% { -webkit-transform: rotate(0deg); }
  100% { -webkit-transform: rotate(360deg); }
}

   
</style>

     <style>
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



    <script>
        $(document).ready(function () {
            Load_dt();
            getdata(1);
        });

        function LoadList() {
            getdata(1);
            return false;
        }
        //Efficiently Paging Through Large Amounts of Data
        var intOrderByColumn = 1;
        var intOrderByStatus = 1;
        var intToltalSearchColumns = 0;

        //------------Load column filters and table----------

        function Load_dt() {

            var strPagingTable = '';
            strPagingTable += '<div id="divHeader_dt"></div>';
            strPagingTable += '<div><table id="tblPagingTable" class="display table-bordered pro_tab1" style="width:100%;">';
            strPagingTable += '<thead class="thead1"><tr id="thPagingTable_SearchColumns"></tr><tr id="trPagingTableHeading"></tr></thead>';
            strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
            strPagingTable += '</table></div>';

            $("#divPagingTableContainer").html(strPagingTable);

            intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

            var url = "/HCM/HCM_Master/hcm_PayrollSystem/hcm_Bulk_LabourCard_Print/hcm_Bulk_LabourCard_Print.aspx/LoadStaticDatafordt";
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                url: url,
                success: function (result) {
                    $("#divHeader_dt").html(result.d[0]);
                    $("#thPagingTable_SearchColumns").html(result.d[1]);
                    intToltalSearchColumns = result.d[2];

                    //bind on paste event to enable search on paste via mouse
                    $("input").on('paste', function (e) {
                        setTimeout(function () { $(e.target).keyup(); }, 100);
                    });                    
                },
                error: function () {
                    Error();
                }
                
            });
        }


        //-----------Load datatable & pagination----------

        function getdata(strPageNumber) {

            document.getElementById("divPagingTable_processing").style.display = "";
            var strPageSize = 10;
            var strCommonSearchString = "";
            var strInputColumnSearch = getColumnSearchData();//individual column search

            if (document.getElementById("txtCommonSearch_dt")) {
                strCommonSearchString = document.getElementById("txtCommonSearch_dt").value.trim();
                strCommonSearchString = ValidateSearchInputData(strCommonSearchString);
            }

            if (document.getElementById("ddl_page_size")) {
                strPageSize = document.getElementById("ddl_page_size").value;
            }

            var strOrgId = '<%= Session["ORGID"] %>';
            var strCorpId = '<%= Session["CORPOFFICEID"] %>';
            var strddlMonth = document.getElementById("<%=ddlMonth.ClientID%>").value;
            var strddlYear = document.getElementById("<%=ddlyear.ClientID%>").value;
            var strddlDep = 0;
            if (document.getElementById("<%=ddlDep.ClientID%>").value != "--SELECT DEPARTMENT--") {
                strddlDep = document.getElementById("<%=ddlDep.ClientID%>").value;
            }
            var strddlEmpIdFirst = 0;
            if (document.getElementById("<%=ddlEmployeeFirst.ClientID%>").value != "--SELECT EMPLOYEE CODE--") {
                strddlEmpIdFirst = document.getElementById("<%=ddlEmployeeFirst.ClientID%>").value;
            }
            var strddlEmpIdSecond=0
            if (document.getElementById("<%=ddlEmployeeFirst.ClientID%>").value != "--SELECT EMPLOYEE CODE--") {
                strddlEmpIdSecond = document.getElementById("<%=ddlEmployeeSecond.ClientID%>").value;
            }            
            var strddlStffWrkr = document.getElementById("<%=ddlEmpTyp.ClientID%>").value;                       
            strPrint_Sts = 0;
            if (document.getElementById("<%=radio_Printed.ClientID%>").checked == true) {
                strPrint_Sts=1
            }
            //evm-0043 start
            var strMail_Sts = 0;
            if (document.getElementById("<%=radioMailed.ClientID%>").checked == true) {
                strMail_Sts = 1;
            }
            //evm-0043 end

            var url = "/HCM/HCM_Master/hcm_PayrollSystem/hcm_Bulk_LabourCard_Print/hcm_Bulk_LabourCard_Print.aspx/GetData";
            var objData = {};
            objData.OrgId = strOrgId;
            objData.CorpId = strCorpId;
            objData.ddlMonth = strddlMonth;
            objData.ddlYear = strddlYear;
            objData.ddlDep = strddlDep;
            objData.ddlStffWrkr = strddlStffWrkr;
            objData.ddlEmpIdFirst = strddlEmpIdFirst;
            objData.ddlEmpIdSecond = strddlEmpIdSecond;
            objData.Print_Sts = strPrint_Sts;
            //evm-0043 start
            objData.Mail_Sts = strMail_Sts;
            //evm-0043 end

            objData.PageNumber = strPageNumber;
            objData.PageMaxSize = strPageSize;
            objData.strCommonSearchTerm = strCommonSearchString;
            objData.OrderColumn = intOrderByColumn;
            objData.OrderMethod = intOrderByStatus;
            objData.strInputColumnSearch = strInputColumnSearch;


            $.ajax({

                type: 'POST',
                data: JSON.stringify(objData),
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                url: url,
                success: function (result) {

                    $('#trPagingTableHeading').html(result.d[0]);
                    $('#tblPagingTable tbody').html(result.d[1]);

                    $("#cphMain_divReport").html(result.d[2]);//datatable

                    var intToltalColumns = document.getElementById('tblPagingTable').rows[1].cells.length;

                    var intAdditionalCoumns = intToltalColumns - (intToltalSearchColumns);

                    if (intAdditionalCoumns < 0) {
                        intAdditionalCoumns = 0;
                    }

                    $("#thPagingTable_thAdjuster").attr('colspan', intAdditionalCoumns);

                    if (document.getElementById("td_No_data_row_dt")) {
                        $("#td_No_data_row_dt").attr('colspan', intToltalColumns);
                    }

                    //enable sort icon 

                    if (intOrderByStatus == 1) {
                        $("#tdColumnHead_" + intOrderByColumn).addClass("asc");
                    }
                    else {
                        $("#tdColumnHead_" + intOrderByColumn).addClass("desc");
                    }

                    document.getElementById("divPagingTable_processing").style.display = "none";

                },
                error: function () {
                    Error();
                }
            });
            return false;
        }

        function getColumnSearchData() {

            //this function collects data from input column search boxes and along with the id
            //— ‡
            var inputSearchTerms = "";
            for (var intSearchColumnCount = 0; intSearchColumnCount < intToltalSearchColumns; intSearchColumnCount++) {
                if (document.getElementById("txtSearchColumn_" + intSearchColumnCount)) {
                    var searchString = document.getElementById("txtSearchColumn_" + intSearchColumnCount).value.trim();
                    if (searchString != "") {

                        searchString = ValidateSearchInputData(searchString);

                        if (inputSearchTerms == "") {
                            inputSearchTerms = intSearchColumnCount + "‡" + searchString;
                        } else {
                            inputSearchTerms += "—" + intSearchColumnCount + "‡" + searchString;
                        }
                    }
                }
            }
            return inputSearchTerms;
        }

        function SetOrderByValue(intOrderBy) {
            intOrderByColumn = intOrderBy;
            if (intOrderByStatus == 1) {
                intOrderByStatus = 0;
            }
            else {
                intOrderByStatus = 1;
            }
            //redraw
            getdata(1);
        }

        function ValidateSearchInputData(strSearchString) {
            var text = strSearchString;
            var replaceText1 = text.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/'/g, "");
            strSearchString = replaceText3;
            if (strSearchString.length > 100) {
                strSearchString = strSearchString.substring(0, 100);
            }
            else {
            }
            return strSearchString;
        }

        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }

        //Efficiently Paging Through Large Amounts of Data

        //setup before functions
        var typingTimer;                //timer identifier
        var doneTypingInterval = 1000;  //time in ms (5 seconds)

        function SettypingTimer() {
            //on keyup, start the countdown
            clearTimeout(typingTimer);
            typingTimer = setTimeout(doneTyping, doneTypingInterval);
        }

        //user is "finished typing," do something
        function doneTyping() {
            //do something
            getdata(1);
        }

        function ClickPrint(x, y, z, date, Dep_Id) {          
            document.getElementById("<%=HiddenEmployeeId.ClientID%>").value = x;
            document.getElementById("<%=HiddenRowCount.ClientID%>").value = y;
            document.getElementById("<%=hiddenSalaryPrcsdId.ClientID%>").value = z;
            document.getElementById("<%=hiddenSlryPrcssdConfDate.ClientID%>").value = date;
            document.getElementById("<%=hiddenDep_Id.ClientID%>").value = Dep_Id;

            document.getElementById("<%=btnPrint.ClientID%>").click();
            return false;
        }

        function changeAll() {
            // IncrmntConfrmCounter();
            var RowCount = document.getElementById("chkbxTotalRowCount").value;
              IncrmntConfrmCounter();
              
              if (document.getElementById("cbMandatory").checked == true) {
                  for (var i = 0; i < RowCount; i++) {
                      document.getElementById("cbMandatory" + i).checked = true;
                  }
              }
              else {
                  for (var i = 0; i < RowCount; i++) {
                      document.getElementById("cbMandatory" + i).checked = false;
                  }
              }

                  return false;
        }

        function PrintBulk() {

            var RowCount = document.getElementById("chkbxTotalRowCount").value;
            IncrmntConfrmCounter();
            var arr = [];
                for (var i = 0; i < RowCount; i++) {
                    if (document.getElementById("cbMandatory" + i).checked == true) {
                        arr.push(document.getElementById("EmpId" + i).value);
                    }
                }
                document.getElementById("<%=hiddenAllEmpid.ClientID%>").value = arr; 
            if (document.getElementById("<%=hiddenAllEmpid.ClientID%>").value != "") {
                document.getElementById("<%=btnBulkPrint.ClientID%>").click();
            }
            else {
                $("#danger-alert").html("Please select the employee to continue.");
                $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
            }
            return false;
        }

        function PrintClick() {
            alert("Last")
        }

        //EVM-0043 start

        function MailSend() {

            var RowCount = document.getElementById("chkbxTotalRowCount").value;
            
            IncrmntConfrmCounter();
            var arr = [];
            for (var i = 0; i < RowCount; i++) {
                if (document.getElementById("cbMandatory" + i).checked == true) {
                    arr.push(document.getElementById("EmpId" + i).value);

                    document.getElementById("<%=HiddenEmployeeId.ClientID%>").value = document.getElementById("EmpId" + i).value;
                    document.getElementById("<%=HiddenRowCount.ClientID%>").value = i;
                    document.getElementById("<%=hiddenSalaryPrcsdId.ClientID%>").value = document.getElementById("SalaryPrcsdId" + i).value;
                    document.getElementById("<%=hiddenSlryPrcssdConfDate.ClientID%>").value = document.getElementById("SlryPrcssdConfDate" + i).value;
                    document.getElementById("<%=hiddenDep_Id.ClientID%>").value = document.getElementById("Dep_Id" + i).value;

                }
            }
            document.getElementById("<%=hiddenAllEmpid.ClientID%>").value = arr;
            if (document.getElementById("<%=hiddenAllEmpid.ClientID%>").value != "")
            {
                document.getElementById("<%=btnmail.ClientID%>").click();
                //0039
               
                ShowLoading();

                //$("#imgGif").on("load", function () {
                //aspertime();

                //});
                
                //end
            }
            else {
                $("#danger-alert").html("Please select the employee to continue.");
                $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
            }

            return false;
        }

        //EVM-0043 start
        function ClickMail(x, y, z, date, Dep_Id) {
            document.getElementById("<%=HiddenEmployeeId.ClientID%>").value = x;
            document.getElementById("<%=HiddenRowCount.ClientID%>").value = y;
            document.getElementById("<%=hiddenSalaryPrcsdId.ClientID%>").value = z;
            document.getElementById("<%=hiddenSlryPrcssdConfDate.ClientID%>").value = date;
            document.getElementById("<%=hiddenDep_Id.ClientID%>").value = Dep_Id;
            document.getElementById("<%=btnmail.ClientID%>").click();
            return false;


        }//evm-0043 end

        //0039

        function ErrorConfirmation(misslist)
        {
            $("#danger-alert").html("Selected employee " + empname + " does not have Email-Id.");
            $("#danger-alert").fadeTo(2000, 500).slideUp(50, function () {
            });
        }


        function MissingEmployeeMailID(empname) {


            $("#danger-alert").html("Selected employee " + empname + " does not have Email-Id.");
            $("#danger-alert").fadeTo(2000, 500).slideUp(50, function () {
            });
        }
        function ShowLoading() {
            document.getElementById("myModalLoadingMail").style.display = "block";
        }
        //0039
        function SuccessConfirmation()
        {
           
            var final = '<%= Session["MISS_LIST"] %>';
           
            if (final != "")
            {
                $("#danger-alert").html("Selected employee " + final + " does not have Email-Id.");
                $("#danger-alert").fadeTo(2000, 500).slideUp(50, function () {
                });

            }
            else
            {

                $("#success-alert").html("Mail sent successfully.");
                $("#success-alert").fadeTo(2000, 500).slideUp(600, function () {
                });
                return false;
            }
        }
        //end


        //0039
       // var delayInMilliseconds = 3900;
       // function aspertime() {
          //  if (document.getElementById("<%=hiddenAllEmpid.ClientID%>").value != "") {

           //     setTimeout(function ()
              //  {
             //       SuccessConfirmation();
                    //alert("hkdbvsihbfvihfs");
                    //$('#ShowLoading').hide();
               // }, delayInMilliseconds);
           // }
      //  }
        //end
        //end

    </script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="HiddenEmployeeId" runat="server" />
    <asp:HiddenField ID="hiddenSalaryPrcsdId" runat="server" />
    <asp:HiddenField ID="HiddenRowCount" runat="server" />
    <asp:HiddenField ID="hiddenSlryPrcssdConfDate" runat="server" />
    <asp:HiddenField ID="hiddenDep_Id" runat="server" />
    <asp:HiddenField ID="HiddenFieldCbxCheck" runat="server" />
    <asp:HiddenField ID="hiddenAllEmpid" runat="server" />
    <%--//0039--%>
      <asp:HiddenField ID="HiddenFieldmisslist" runat="server" />
    <%--//end--%>

    


<!---breadcrumb_section_started---->    
    <ol class="breadcrumb">
        <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Hcm.aspx">HCM</a></li>
        <li class="active">Bulk Labour Card Print</li>
    </ol>
<!---breadcrumb_section_started----> 

  <!---alert_message_section---->
<div class="myAlert-top alert alert-success" id="success-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Success!</strong> Changes completed succesfully
</div>

<div class="myAlert-bottom alert alert-danger" id="danger-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Danger!</strong> Request not conmpleted
</div>
<!----alert_message_section_closed---->

    <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con">Bulk Labour Card Print</h1>

          <div class="form-group fg2 fg2_blk">
          <label for="email" class="fg2_la1">Month<span class="spn1"></span>:</label>
            <asp:DropDownList runat="server" ID="ddlMonth" onchange="IncrmntConfrmCounter()" class="form-control fg2_inp1 fg_chs2"  onkeypress="return IsEnter(event);" >
            </asp:DropDownList>
        </div>
        <div class="form-group fg2 fg2_blk">
          <label for="email" class="fg2_la1">Year<span class="spn1"></span>:</label>
          <asp:DropDownList runat="server" ID="ddlyear" class="form-control fg2_inp1 fg_chs2"  onkeypress="return IsEnter(event);" onchange="IncrmntConfrmCounter()" >
           </asp:DropDownList>
        </div>
        <div class="form-group fg2 fg2_blk">
          <label for="email" class="fg2_la1">Department<span class="spn1"></span>:</label>
           <asp:DropDownList ID="ddlDep" onchange="IncrmntConfrmCounter();" class="form-control fg2_inp1 fg_chs2"   runat="server"  onkeypress="return DisableEnter(event)"></asp:DropDownList>
        </div> 
        <div class="form-group fg2 fg2_blk">
          <label for="email" class="fg2_la1">Employee Type<span class="spn1"></span>:</label>
          <asp:DropDownList ID="ddlEmpTyp" class="form-control fg2_inp1 fg_chs2" runat="server">
              <asp:ListItem Text="Staff" Value="0" Selected="True"></asp:ListItem>
              <asp:ListItem Text="Worker" Value="1" ></asp:ListItem>

           </asp:DropDownList>
        </div> 

        <div class="spl_hcm">
          <div class="form-group fg6 spl_fg2">
          <label for="email" class="fg2_la1">Employee Code From<span class="spn1"></span>:</label>
         <asp:DropDownList ID="ddlEmployeeFirst" onchange="IncrmntConfrmCounter();"  data-placeholder="select employee"  class="form-control fg2_inp1 fg_chs2" runat="server"  onkeypress="return DisableEnter(event)" ></asp:DropDownList>

        </div>
        <div class="form-group fg6 spl_fg2">
          <label for="email" class="fg2_la1">Employee Code To<span class="spn1"></span>:</label>
         <asp:DropDownList ID="ddlEmployeeSecond" onchange="IncrmntConfrmCounter();"  data-placeholder="select employee"  class="form-control fg2_inp1 fg_chs2" runat="server"  onkeypress="return DisableEnter(event)" ></asp:DropDownList>

        </div>
        </div>

        <div class="form-group fg2 fg2_blk fg2_blk1">
          <label for="email" class="fg2_la1">Print Status:<span class="spn1"></span></label>
          <div class="row rl_prt">
            <div class="prtd_rat">
              <div class="form-check">
                <input id="radio_Printed" name="radio_Printed" class="form-check-input" runat="server" onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" type="radio" checked="" />

                <label class="form-check-label" for="gridRadios1">Printed</label>
              </div>
              <div class="form-check">
                <input id="radio_NotPrinted" name="radio_Printed" class="form-check-input"  runat="server" onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" type="radio"  />

                <label class="form-check-label" for="gridRadios2">Not Printed</label>
              </div>
            </div>
          </div>
        </div>

           <%-- EVM-0043 start--%>
       <div class="form-group fg5 fg2_blk fg2_blk1">
          <label for="email" class="fg2_la1">Mail Status:<span class="spn1"></span></label>
          <div class="row rl_prt">
            <div class="prtd_rat">
              <div class="form-check">
                <input id="radioMailed" name="radio_Mailed" class="form-check-input" runat="server" onchange="IncrmntConfrmCounter();"  type="radio" checked="" />

                <label class="form-check-label" for="gridRadios1">Mailed</label>
              </div>
              <div class="form-check">
                <input id="radioNotMailed" name="radio_Mailed" class="form-check-input"  runat="server" onchange="IncrmntConfrmCounter();"  type="radio"  />

                <label class="form-check-label" for="gridRadios2">Not Mailed</label>
              </div>
            </div>
          </div>
        </div>
        <%-- EVM-0043 end--%>

        <div class="fg8 fg2_blk">
          <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>

           <asp:Button ID="btnSearch" runat="server" class="submit_ser" OnClientClick="return LoadList();" />
           <asp:Button ID="btnBulkPrint" style="display:none;" runat="server" class="submit"  OnClick="btnBulkPrint_Click" />
            <%--<input type="button" value="Bulk Print" class="submit" onclick="return PrintBulk();"/>--%>
            <asp:Button ID="btnPrint" runat="server" Style="display: none" Text="Print" OnClick="btnPrint_Click" />
             <%--  EVM-0043--%>
            <asp:Button ID="btnmail" runat="server" style="display:none" Text="Email" OnClick="btnmail_Click"/>
        </div>
<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="devider"></div>
<!---=================section_devider============--->


            <!----table---->
       <div id="divPagingTable_processing" style="display: none;">Processing...</div>
       <div id="divPagingTableContainer"></div>
       <div id="divReport" runat="server" class="tab_res"></div>
        <!----table---->

      
        </div>
      </div>
    </div>

        <!---print_button--->
<a href="#" type="button" class="print_o" title="Print page" style="display:none;">
  <i class="fa fa-print"></i>
</a>
<!---print_button_closed--->

<!---id_print_button--->

    <%--<input type="button" value="Bulk Print" class="submit" onclick="return PrintBulk();"/>--%>

<a href="#" type="button" class="id_print" onclick="return PrintBulk();" title="Labor card print">
  <i class="fa fa-newspaper-o" aria-hidden="true"></i>
</a>

<%--EVM-0043--%>
  <!---id_mail_button--->
<a href="javascript:;" type="button" class="id_mail2" title="Email" onclick="return MailSend();" >
  <i class="fa fa-envelope-o" aria-hidden="true"></i>
</a>
<!---id_mail_button_closed--->

   <%-- 0039--%>

         <div id="myModalLoadingMail" class="modalLoadingMail">
               <img id="imgGif" src="/Images/Other Images/LoadingMail.gif" style="width: 12%;" />
          </div>

     <%-- 0039--%>

    <script>
            var $au = jQuery.noConflict();
            $au(function () {
                $au('#cphMain_ddlEmployeeFirst').selectToAutocomplete1Letter();
                $au('#cphMain_ddlEmployeeSecond').selectToAutocomplete1Letter();
            });
    </script>



</asp:Content>

