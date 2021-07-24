﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="hcm_Manual_AddDed_Entry.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Manual_AddDed_Entry_hcm_Manual_AddDed_Entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
 <script src="/js/New%20js/date_pick/datepicker.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
 <script src="/js/Common/Common.js"></script>
 <link rel="stylesheet" type="text/css" href="/css/New css/hcm_ns.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <style>
        .auto_b {
    color:#48a243;
    position: fixed;
    bottom: 100px;
    right: 40px;
    font-size: 29px;
}
.bounce {
  display: inline-block;
  position: relative;
  -moz-animation: bounce 4s infinite linear;
  -o-animation: bounce 4s infinite linear;
  -webkit-animation: bounce 4s infinite linear;
  animation: bounce 4s infinite linear;
  colr:000;
}
    </style>

     <asp:HiddenField ID="HiddenFieldPopOverId" runat="server" value="0"/>

    <asp:HiddenField ID="HiddenFieldEditMode" runat="server" value="0"/>

     <asp:HiddenField ID="HiddenFieldAddSpan" runat="server" value="0"/>
     <asp:HiddenField ID="HiddenFieldDedSpan" runat="server" value="0"/>

    <asp:HiddenField ID="HiddenFieldTotAddDedNum" runat="server" value="0"/>
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" Value="1"/>
    <asp:HiddenField ID="HiddenCurrencyAbrv" runat="server"/>
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" Value="2"/>
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server"/>
    <asp:HiddenField ID="HiddenFieldMasterDbId" runat="server" Value="0"/>  
    <asp:HiddenField ID="HiddenFieldOldRow" runat="server"/>
    <asp:HiddenField ID="HiddenFieldCurrMonth" runat="server"/>
    <asp:HiddenField ID="HiddenFieldCurrYear" runat="server"/>

     <asp:HiddenField ID="HiddenFieldSaveRole" runat="server" Value="0"/> 
     <asp:HiddenField ID="HiddenFieldUpdRole" runat="server" Value="0"/> 
     <asp:HiddenField ID="HiddenFieldConfRole" runat="server" Value="0"/> 
     <asp:HiddenField ID="HiddenFieldReopRole" runat="server" Value="0"/> 

    <ol class="breadcrumb">
        <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Hcm.aspx">HCM</a></li>
         <li><a href="hcm_Manual_AddDed_Entry_List.aspx">Manual Addition/Deduction Entry List</a></li>
        <li class="active" id="currPage" runat="server">Manual Addition/Deduction Entry</li>
   </ol>

    <div class="myAlert-top alert alert-success" id="success-alert"></div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning"></div>

  <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      <div class="content_box1 cont_contr">
        <div class="" onmouseover="closesave()">
        <h2 id="currPageHead">Manual Addition/Deduction Entry</h2>
        <div class="form-group fg2 fg2_adn">
          <label for="email" class="fg2_la1">Month:<span class="spn1"></span></label>
          <select class="form-control fg2_inp1 fg_chs2 notv" id="ddlMonth" runat="server">
          </select> 
        </div>
        <div class="form-group fg2 fg2_adn">
          <label for="email" class="fg2_la1">Year:<span class="spn1"></span></label>
          <select class="form-control fg2_inp1 fg_chs2 notv" id="ddlYear" runat="server" onchange="return changeYear();">
          </select> 
        </div>



        <div class="fg2 fg2_adn" id="divImportCsv">
           <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
           <label id="lblFileUpload" for="cphMain_FileUploader" class="btn tab_but1 butn5" style="padding-top:3px;"> <i class="fa fa-files-o"></i> Import from CSV file </label>
           <asp:FileUpload ID="FileUploader" class="imageUpload" onchange="FupSelectedFileName()" runat="server" Accept=".csv"  style="display:none;"/>  
           <asp:Label ID="Label1" runat="server" Text="No file selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
        </div>
        <div class="fg2 fg2_adn" id="divDownloadCsv">
          <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
          <a class="btn tab_but1 butn5" style="padding-top:3px;" href="/CustomFiles/csvTemplate/ManualAddDedSample .csv"><i class="fa fa-download"></i> Download CSV file format</a> 
        </div>

        <div class="clearfix"></div>
        <!-- <div class="free_sp"></div> -->
        <div class="devider"></div>
        
     <div class="tab_hcm Type" id="divType">
      <table class="table table-bordered tb_hcm_fx tbs1">
        <thead class="thead1" id="tMainHead" runat="server">         
        </thead>
        <tbody id="myTable"> 
        </tbody>
        <tfoot id="tMainFoot" runat="server">
        </tfoot>
      </table>
         <table class="table table-bordered tb_hcm_fx tbs1" style="margin-top: -1.7%;display:none;" id="tbNodata">
        <tbody >
       <tr>
           <td>No data available</td>
       </tr>
        </tbody>
      </table>
    </div>
  <!--Start:-For CSV file upload -->
            <div class="tab_hcm" id="divCsv" style="display:none;">
                <div id="divMissingCode" display: none;">
                      <h2>Incorrect List</h2>
                    <div class="eachform">
                        <div class="subform" style="float: right; width: 19%">
                            <asp:Button ID="btnCodeMissingNext" runat="server" class="btn sub1 notv" Text="Next>>" Style="float: right; margin-right: 6%;" OnClientClick="return ViewDuplication();" />
                            <asp:Button ID="btnCodeMissingCancel" runat="server" class="btn sub4 notv" Text="Cancel" Style="float: right; margin-right: 1%;" OnClientClick="return ConfirmMessageCsv();" />
                            <asp:Button ID="btnCodeMissingBack" runat="server" class="btn sub1 notv" Text="<<Back" Style="float: right; margin-right: 1%;" OnClientClick="return ConfirmMessageCsv();" />
                        </div>
                    </div>
                    <div class="eachform">
                        <h5>Following records in uploaded file contain either missing,duplicated or incorrect fields.These records will be excluded while importing.Use "Next" button to continue.</h5>
                    </div>




                    <div id="divTabs" style="margin-top:2%;margin-bottom:2%;">

                        <div class="tab">
                            <button class="tablinks notv" id="btnViewMissingCodeList" onclick="return OpenIncorrectList(event, 'divMissingCodeListTab')"></button>
                            <button class="tablinks notv" id="btnViewIncorrectCodeList" onclick="return OpenIncorrectList(event, 'divIncorrectCodeListTab')"></button>
                            <button class="tablinks notv" id="btnViewDuplicateCodeList" onclick="return OpenIncorrectList(event, 'divDuplicateCodeListTab')"></button>
                            <button class="tablinks notv" id="btnViewMissingAmountList" onclick="return OpenIncorrectList(event, 'divMissingAmountListTab')"></button>
                            <button class="tablinks notv" id="btnViewIncorrectAmountList" onclick="return OpenIncorrectList(event, 'divIncorrectAmountListTab')"></button>
                            <button class="tablinks notv" id="btnViewBlockedEmpList" onclick="return OpenIncorrectList(event, 'divBlockedEmpTab')"></button>
                        </div>

                        <div id="divMissingCodeListTab" class="tabcontent">
                            <h3>Missing Employee Code</h3>
                            <div class="eachform">
                                <asp:Button ID="btnMissingCodeListPrevious" Width="19%" runat="server" class="searchlist_btn_rght notv" Text="Show Previous 100 Records" disabled="disabled" Style="float: left;" OnClientClick="return MissingCodeListRecord(0);" />
                                <asp:Button ID="btnMissingCodeListNext" Width="19%" runat="server" class="searchlist_btn_rght notv" Text="Show Next 100 Records" Style="float: left;" OnClientClick="return MissingCodeListRecord(1);" />
                            </div>
                            <div id="divMissingCodeList" runat="server" class="tab_hcm"></div>
                             <div class="eachform">
                        <h5>These records in the given file does not have a employee code.</h5>
                    </div>
                        </div>
                        <div id="divIncorrectCodeListTab" class="tabcontent">
                            <h3>Mismatched Employee Code</h3>
                            <div class="eachform" >
                                <asp:Button ID="btnIncorrectCodeListPrevious" Width="19%" runat="server" class="searchlist_btn_rght notv" Text="Show Previous 100 Records" disabled="disabled" Style="float: left;" OnClientClick="return IncorrectCodeListRecord(0);" />
                                <asp:Button ID="btnIncorrectCodeListNext" Width="19%" runat="server" class="searchlist_btn_rght notv" Text="Show Next 100 Records" Style="float: left;" OnClientClick="return IncorrectCodeListRecord(1);" />
                            </div>
                            <div id="divIncorrectCodeList" runat="server" class="tab_hcm"></div>
                              <div class="eachform">
                        <h5>These records in the given file does not have a matching employee code.</h5>
                    </div>
                        </div>
                        <div id="divDuplicateCodeListTab" class="tabcontent">
                            <h3>Duplicate Employee Code</h3>
                            <div class="eachform">
                                <asp:Button ID="btnDuplicateCodeListPrevious" Width="19%" runat="server" class="searchlist_btn_rght notv" Text="Show Previous 100 Records" disabled="disabled" Style="float: left;" OnClientClick="return DuplicateCodeListRecord(0);" />
                                <asp:Button ID="btnDuplicateCodeListNext" Width="19%" runat="server" class="searchlist_btn_rght notv" Text="Show Next 100 Records" Style="float: left;" OnClientClick="return DuplicateCodeListRecord(1);" />
                            </div>
                            <div id="divDuplicateCodeList" runat="server" class="tab_hcm"></div>
                            <div class="eachform">
                        <h5>These records in the given file has duplicated employee code.</h5>
                    </div>
                        </div>
                        <div id="divMissingAmountListTab" class="tabcontent">
                            <h3>Missing Atleast One Addition/Deduction Amount</h3>
                            <div class="eachform" >
                                <asp:Button ID="btnMissingAmountListPrevious" Width="19%" runat="server" class="searchlist_btn_rght notv" Text="Show Previous 100 Records" disabled="disabled" Style="float: left;" OnClientClick="return MissingAmountListRecord(0);" />
                                <asp:Button ID="btnMissingAmountListNext" Width="19%" runat="server" class="searchlist_btn_rght notv" Text="Show Next 100 Records" Style="float: left;" OnClientClick="return MissingAmountListRecord(1);" />
                            </div>
                            <div id="divMissingAmountList" runat="server" class="tab_hcm"></div>
                             <div class="eachform">
                        <h5>These records in the given file does not have atleast one addition or deduction amount.</h5>
                    </div>
                        </div>
                        <div id="divIncorrectAmountListTab" class="tabcontent">
                            <h3>Incorrect Addition/Deduction Amount</h3>
                            <div class="eachform">
                                <asp:Button ID="btnIncorrectAmountListPrevious" Width="19%" runat="server" class="searchlist_btn_rght notv" Text="Show Previous 100 Records" disabled="disabled" Style="float: left;" OnClientClick="return IncorrectAmountListRecord(0);" />
                                <asp:Button ID="btnIncorrectAmountListNext" Width="19%" runat="server" class="searchlist_btn_rght notv" Text="Show Next 100 Records" Style="float: left;" OnClientClick="return IncorrectAmountListRecord(1);" />
                            </div>
                            <div id="divIncorrectAmountList" runat="server" class="tab_hcm"></div>
                              <div class="eachform">
                        <h5>These records in the given file has incorrect addition or deduction amount.</h5>
                    </div>
                        </div>
                        <div id="divBlockedEmpTab" class="tabcontent">
                            <h3>Blocked Employees</h3>
                            <div class="eachform">
                                <asp:Button ID="btnBlockedEmpListPrevious" Width="19%" runat="server" class="searchlist_btn_rght notv" Text="Show Previous 100 Records" disabled="disabled" Style="float: left;" OnClientClick="return BlockedEmpListRecord(0);" />
                                <asp:Button ID="btnBlockedEmpListNext" Width="19%" runat="server" class="searchlist_btn_rght notv" Text="Show Next 100 Records" Style="float: left;" OnClientClick="return BlockedEmpListRecord(1);" />
                            </div>
                            <div id="divBlockedEmpList" runat="server" class="tab_hcm"></div>
                              <div class="eachform">
                        <h5>These records in the given file has blocked employees.</h5>
                    </div>
                        </div>
                    </div>
                </div>
                <div id="divRateMissing" style="display: none;">
                    <h2>Correct List</h2>
                    <div class="eachform">
                       <div class="subform" style="float: right;width:19%;">
                            <asp:Button ID="btnCsvSave" runat="server" class="btn btn-primary notv" Text="Save"  OnClick="btnCsvSave_Click" Style="display:none;" />
                            <asp:Button ID="btnRateMissingUpdate" runat="server" class="btn sub1 notv" Text="Save" OnClientClick="return confirmUpdate();" Style="float: right; margin-right: 3%;" />
                            <asp:Button ID="btnRateMissingCancel" runat="server" class="btn sub4 notv" Text="Cancel" Style="float: right; margin-right: 1%;" OnClientClick="return ConfirmMessageCsv();" />
                        </div>
                    </div>
                    <div class="eachform">
                        <h5>Use "Save" button to add following records in uploaded file to the table.</h5>
                    </div>
                    <div class="eachform" style="margin-top:1%;">
                        <asp:Button ID="btnCostPriceMissingPrevious" disabled="disabled" Width="19%" runat="server" class="searchlist_btn_rght notv" Text="Show Previous 100 Records" Style="float: left;" OnClientClick="return RateMissingRecord(0);" />
                        <asp:Button ID="btnCostPriceMissingNextRecords" Width="19%" runat="server" class="searchlist_btn_rght notv" Text="Show Next 100 Records" Style="float: left;" OnClientClick="return RateMissingRecord(1);" />
                    </div>
                    <div id="divCostPriceMissingReport"  runat="server" class="tab_hcm">
                    </div>
                    <table class="table table-bordered tb_hcm_fx tbs1" id="tbNodataCrct" style="margin-top:-1.7%;display:none;">
                    <tbody >
                    <tr><td class="tr_c">No data available</td></tr>
                    </tbody>
                    </table>
                </div>
            </div>
  <!--End:-For CSV file upload -->
  <div class="clearfix Type"></div>
  <div class="devider divid Type"></div>
  <div class="free_sp Type"></div>

 <!--Buttons_Area_started--->
 <div class="sub_cont pull-right Type">
  <div class="save_sec">
    <button type="submit" class="btn sub1 notv" onclick="return FuctionSaveMain(null,0,event);" id="btnSave">Save</button>
    <button type="submit" class="btn sub1 notv" onclick="return FuctionSaveMain(null,0,event);" id="btnSaveClose">Save & Close</button>
    <button type="submit" class="btn sub2 notv" onclick="return confirmConf();">Confirm</button>
    <button type="submit" class="btn sub3 notv" onclick="return confirmReop();">Reopen</button>
    <button type="submit" class="btn sub4 notv" onclick="return ConfirmMessage();">Cancel</button>
  </div>
</div>
<!--buttons_area_closed--->

<!----frame_closed section to footer script section--->
               </div>
  </div>
<!-------working area_closed---->

    </div>    
  </div>


 <div class="mySave1 Type" id="mySave">
  <div class="save_sec">
    <button type="submit" class="btn sub1 bt_b notv" onclick="return FuctionSaveMain(null,0,event);" id="btnSaveF">Save</button>
    <button type="submit" class="btn sub1 bt_b notv" onclick="return FuctionSaveMain(null,0,event);" id="btnSaveFClose">Save & Close</button>
    <button type="submit" class="btn sub2 bt_b notv" onclick="return confirmConf();">Confirm</button>
    <button type="submit" class="btn sub3 bt_b notv" onclick="return confirmReop();">Reopen</button>
    <button type="submit" class="btn sub4 bt_b notv" onclick="return ConfirmMessage();">Cancel</button>
  </div>
</div>
<a href="#" onmouseover="opensave()" type="button" class="save_b Type" title="Save">
 <i class="fa fa-save"></i>
</a>
<a href="#" type="button" class="list_b" title="Back to List" onclick="return ConfirmMessage();">
 <i class="fa fa-arrow-circle-left"></i>
</a>
    <a href="#" type="button" class="auto_b" title="Auto save indication">
<i id="d_aut_s" class="fa fa-magic bounce"><i class="fa fa-save spn_qkr"></i></i>

</a>
<!--save_pop up_open-->
<asp:Button ID="btnAdd" runat="server" class="btn btn-primary" style="display:none;"  Text="Process" OnClick="btnAdd_Click" />
 <asp:HiddenField ID="HiddenFile" runat="server" />
     
 <asp:HiddenField ID="HiddenFieldHeaderList" runat="server" value=""/>  
     
 <asp:HiddenField ID="HiddenMissingCodeListNext" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenMissingCodeListCount" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenMissingCodeList" runat="server" value="0"/>

 <asp:HiddenField ID="HiddenDuplicateCodeListNext" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenDuplicateCodeListCount" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenDuplicateCodeList" runat="server" value="0"/>

 <asp:HiddenField ID="HiddenIncorrectCodeListNext" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenIncorrectCodeListCount" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenIncorrectCodeList" runat="server" value="0"/>

 <asp:HiddenField ID="HiddenMissingAmountListNext" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenMissingAmountListCount" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenMissingAmountList" runat="server" value="0"/>

 <asp:HiddenField ID="HiddenIncorrectAmountListNext" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenIncorrectAmountListCount" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenIncorrectAmountList" runat="server" value="0"/>


 <asp:HiddenField ID="HiddenBlockedEmpListNext" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenBlockedEmpListCount" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenBlockedEmpList" runat="server" value="0"/>

 <asp:HiddenField ID="HiddenCostPriceMissingCount" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenCostPriceMissingPrevious" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenCostPriceMissingNext" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenCostPriceMissingList" runat="server" value="0"/>

 <asp:HiddenField ID="HiddenFieldCsvDataSave" runat="server" value=""/>
 <style>
     /* Style the tab */
.tab {
  overflow: hidden;
  border: 1px solid #ccc;
  background-color: #f1f1f1;
  height:47px;
  font-size:12px;
  width: max-content;
}

/* Style the buttons that are used to open the tab content */
.tab button {
  background-color: inherit;
  float: left;
  border: none;
  outline: none;
  cursor: pointer;
  padding: 14px 16px;
  transition: 0.3s;
}

/* Change background color of buttons on hover */
.tab button:hover {
  background-color: #ddd;
}

/* Create an active/current tablink class */
.tab button.active {
  background-color: #ccc;
}

/* Style the tab content */
.tabcontent {
  display: none;
  padding: 6px 12px;
  border: 1px solid #ccc;
  /*border-top: none;*/
} 
</style>
<script>
  function opensave() {
    document.getElementById("mySave").style.width = "140px";
  }
  function closesave() {
    document.getElementById("mySave").style.width = "0px";
  }
</script>
<!--save_pop up_closed-->

    <script>
        function FupSelectedFileName() {
            var fileUploader = document.getElementById("<%=FileUploader.ClientID%>").value;
            var Extension = fileUploader.substring(fileUploader.lastIndexOf('.') + 1).toLowerCase();           
            if (fileUploader != "") {
                if (Extension == "csv") {
                    document.getElementById('<%=Label1.ClientID%>').innerHTML = document.getElementById('<%=FileUploader.ClientID %>').value;
                    document.getElementById('<%=btnAdd.ClientID %>').click();                    
                }
                else {
                    $("#divWarning").html("The specified file could not be uploaded. File type not supported. Allowed type is csv.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById('<%=FileUploader.ClientID %>').value = "";
                    document.getElementById('<%=Label1.ClientID %>').innerHTML = "No file selected";
                }
            }
            return false;
        }
        function ViewMissingProductCode() {
            document.getElementById('tbNodataCrct').style.display = "none";
            IncrmntConfrmCounter();
            document.getElementById('<%=HiddenFieldCsvDataSave.ClientID %>').value = "";
            document.getElementById('<%=Label1.ClientID%>').innerHTML = document.getElementById('<%=HiddenFile.ClientID %>').value;
            document.getElementById('divCsv').style.display = "";
            $(".Type").css("display", "none");
            var MissingCodeListCount = document.getElementById("<%=HiddenMissingCodeListCount.ClientID%>").value;
            var DuplicateCodeListCount = document.getElementById("<%=HiddenDuplicateCodeListCount.ClientID%>").value;
            var IncorrectCodeListCount = document.getElementById("<%=HiddenIncorrectCodeListCount.ClientID%>").value;
            var MissingAmountListCount = document.getElementById("<%=HiddenMissingAmountListCount.ClientID%>").value;
            var IncorrectAmountListCount = document.getElementById("<%=HiddenIncorrectAmountListCount.ClientID%>").value;
            var BlockedEmpListCount = document.getElementById("<%=HiddenBlockedEmpListCount.ClientID%>").value;
            document.getElementById('btnViewMissingCodeList').innerHTML = "Missing Employee Code <span style=\"color: #a94442;\">(" + MissingCodeListCount + ")</span>";
            document.getElementById('btnViewIncorrectCodeList').innerHTML = "Incorrect Employee Code <span style=\"color: #a94442;\">(" + IncorrectCodeListCount + ")</span>";
            document.getElementById('btnViewDuplicateCodeList').innerHTML = "Duplicate Employee Code <span style=\"color: #a94442;\">(" + DuplicateCodeListCount + ")</span>";
            document.getElementById('btnViewMissingAmountList').innerHTML = "Missing Atleast One Addition/Deduction Amount <span style=\"color: #a94442;\">(" + MissingAmountListCount + ")</span>";
            document.getElementById('btnViewIncorrectAmountList').innerHTML = "Incorrect Addition/Deduction Amount <span style=\"color: #a94442;\">(" + IncorrectAmountListCount + ")</span>";
            document.getElementById('btnViewBlockedEmpList').innerHTML = "Blocked Employees <span style=\"color: #a94442;\">(" + BlockedEmpListCount + ")</span>";
            //hide if no error
            if (MissingCodeListCount == '0')
                document.getElementById('btnViewMissingCodeList').style.display = "none";

            if (DuplicateCodeListCount == '0')
                document.getElementById('btnViewDuplicateCodeList').style.display = "none";

            if (IncorrectCodeListCount == '0')
                document.getElementById('btnViewIncorrectCodeList').style.display = "none";

            if (MissingAmountListCount == '0')
                document.getElementById('btnViewMissingAmountList').style.display = "none";

            if (IncorrectAmountListCount == '0')
                document.getElementById('btnViewIncorrectAmountList').style.display = "none";
            if (BlockedEmpListCount == '0')
                document.getElementById('btnViewBlockedEmpList').style.display = "none";

            if (MissingCodeListCount == '0' && DuplicateCodeListCount == '0' && IncorrectCodeListCount == '0' && MissingAmountListCount == '0' && IncorrectAmountListCount == '0' && BlockedEmpListCount=='0') {
                document.getElementById('divRateMissing').style.display = "";
                document.getElementById('divMissingCode').style.display = "none";
            }
            else {
                document.getElementById('divMissingCode').style.display = "";
                document.getElementById('divRateMissing').style.display = "none";
                if (MissingCodeListCount != '0')
                    document.getElementById('btnViewMissingCodeList').click();
                else if (IncorrectCodeListCount != '0')
                    document.getElementById('btnViewIncorrectCodeList').click();
                else if (DuplicateCodeListCount != '0')
                    document.getElementById('btnViewDuplicateCodeList').click();
                else if (MissingAmountListCount != '0')
                    document.getElementById('btnViewMissingAmountList').click();
                else if (IncorrectAmountListCount != '0')
                    document.getElementById('btnViewIncorrectAmountList').click();
                else if (BlockedEmpListCount != '0')
                    document.getElementById('btnViewBlockedEmpList').click();
            }
            return false;
        }     
        function OpenIncorrectList(evt, cityName) {
            var i, tabcontent, tablinks;
            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }
            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
            document.getElementById(cityName).style.display = "block";
            evt.currentTarget.className += " active";
            return false;
        }
        function ViewDuplication() {
            document.getElementById('divMissingCode').style.display = "none";
            document.getElementById('divRateMissing').style.display = "";
            return false;
        }
        function ConfirmMessageCsv() {           
            document.getElementById('divMissingCode').style.display = "none";
            document.getElementById('divRateMissing').style.display = "none";
            document.getElementById('divCsv').style.display = "none";
            $(".Type").css("display", "");
            document.getElementById('<%=FileUploader.ClientID %>').value = "";
            document.getElementById('<%=Label1.ClientID %>').innerHTML = "No file selected";
            document.getElementById('<%=HiddenFieldCsvDataSave.ClientID %>').value = "";
            changeMonthYear(0);
            return false;
        }
        function IncorrectHeader() {
            $("#divWarning").html("The specified file could not be uploaded. File type not supported.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById('<%=FileUploader.ClientID %>').value = "";
            document.getElementById('<%=Label1.ClientID %>').innerHTML = "No file selected";
            document.getElementById('<%=HiddenFieldCsvDataSave.ClientID %>').value = "";
        }
        function BlurNotNumberCsv(obj) {
            document.getElementById(obj).style.borderColor = "";
            var txt = document.getElementById(obj).value.trim();
            if (txt != "") {
                txt = txt.replace(/,/g, "");
                if (isNaN(txt)) {
                    document.getElementById(obj).value = "";
                    document.getElementById(obj).focus();
                }
                else {
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    txt = parseFloat(txt);
                    txt = txt.toFixed(FloatingValue);
                    document.getElementById(obj).value = addCommasSummry(txt);
                }
            }
            return false;
        }
        function FuctionDeleCsv(RowNum) {
            $('#tbodyCorrectRow_' + RowNum).remove();
            if ($("#tbodyCorrect > tr").length == 0) {
                document.getElementById('cphMain_btnRateMissingUpdate').style.display = "none";
            }
            if ($('#tbodyCorrect > tr:visible').length == 0) {
                document.getElementById('tbNodataCrct').style.display = "";
            }
            return false;
        }
        //pagenation functions
        function RateMissingRecord(Mode) {
            document.getElementById('tbNodataCrct').style.display = "none";
            var NextId = document.getElementById("<%=HiddenCostPriceMissingNext.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value
           
                if (Mode == '1') {
                    document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").disabled = false;
                    //document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").disabled = false;
                    //document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.cursor = 'pointer';
                }
                var intCount = parseInt(NextId);
                var intFinalCount = 0;
               

                if (parseInt(intCount) < 100)
                    intCount = 0;
                //strMode=1 for next and 0 for previous.
                if (Mode == "1")
                {
                    intFinalCount = parseInt(intCount) + 100;
                    if (parseInt(intFinalCount) > parseInt(TotalCount))
                        intFinalCount = parseInt(TotalCount);
                }
                else
                {
                    if (parseInt(intCount) % 100 == 0)
                    {
                        intFinalCount = parseInt(intCount) - 100;
                        intCount = parseInt(intCount) - 200;
                        if (parseInt(intCount) < 0)
                            intCount = 0;
                    }
                    else
                    {
                        intFinalCount = parseInt(intCount) / 100;
                        intFinalCount = parseInt(intFinalCount) * 100;
                        intCount = parseInt(intFinalCount) - 100;
                        if (parseInt(intCount) < 0)
                            intCount = 0;
                       
                    }
                }
                if (parseInt(intFinalCount) % 100 != 0)
                {
                    intCount = parseInt(intFinalCount) % 100;
                    intCount = parseInt(intFinalCount) - parseInt(intCount);
                }
                $(".CorrectRow").css("display", "none");
                for (var intRowBodyCount = parseInt(intCount); parseInt(intRowBodyCount) < parseInt(intFinalCount) ; intRowBodyCount++)
                {
                    if ($("#tbodyCorrectRow_" + intRowBodyCount).length) {
                        $("#tbodyCorrectRow_" + intRowBodyCount).css("display", "");
                    }
                }
                document.getElementById("<%=HiddenCostPriceMissingNext.ClientID%>").value = intFinalCount;  
                if (Mode == '1') {
                    if (parseInt(document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenCostPriceMissingNext.ClientID%>").value)) {
                        document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").disabled = true;
                        //document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenCostPriceMissingNext.ClientID%>").value == '100') {
                        document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").disabled = "disabled";
                        //document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            return false;
        }
        function MissingCodeListRecord(Mode) {
            var RemarkMode = 0;
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var month = document.getElementById("cphMain_ddlMonth").value;
            var year = document.getElementById("cphMain_ddlYear").value;

            var DecimalCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var CurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;

            var Header = document.getElementById("<%=HiddenFieldHeaderList.ClientID%>").value;
            var NextId = document.getElementById("<%=HiddenMissingCodeListNext.ClientID%>").value;
            var MissingCode = document.getElementById("<%=HiddenMissingCodeList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenMissingCodeListCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';
            var Create = PageMethods.ServiceListToHtmlIncrct(MissingCode, NextId, Mode, TotalCount, Header, DecimalCnt, CurrencyId, orgID, corptID, month, year, RemarkMode, function (response) {
                var MissingCodeList = response;
                document.getElementById('cphMain_divMissingCodeList').innerHTML = MissingCodeList[0];

                if (Mode == '1') {
                    document.getElementById("<%=btnMissingCodeListPrevious.ClientID%>").disabled = false;
                    //document.getElementById("<%=btnMissingCodeListPrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnMissingCodeListPrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnMissingCodeListNext.ClientID%>").disabled = false;
                    //document.getElementById("<%=btnMissingCodeListNext.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnMissingCodeListNext.ClientID%>").style.cursor = 'pointer';
                }
                document.getElementById("<%=HiddenMissingCodeListNext.ClientID%>").value = MissingCodeList[1];
                if (Mode == '1') {
                    if (parseInt(document.getElementById("<%=HiddenMissingCodeListCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenMissingCodeListNext.ClientID%>").value)) {
                        document.getElementById("<%=btnMissingCodeListNext.ClientID%>").disabled = true;
                        //document.getElementById("<%=btnMissingCodeListNext.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnMissingCodeListNext.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenMissingCodeListNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnMissingCodeListPrevious.ClientID%>").disabled = "disabled";
                        //document.getElementById("<%=btnMissingCodeListPrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnMissingCodeListPrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            })
            return false;
        }
        function DuplicateCodeListRecord(Mode) {
            var RemarkMode = 0;
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var month = document.getElementById("cphMain_ddlMonth").value;
            var year = document.getElementById("cphMain_ddlYear").value;

            var DecimalCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var CurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;

            var Header = document.getElementById("<%=HiddenFieldHeaderList.ClientID%>").value;
            var NextId = document.getElementById("<%=HiddenDuplicateCodeListNext.ClientID%>").value;
            var MissingCode = document.getElementById("<%=HiddenDuplicateCodeList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenDuplicateCodeListCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';
            var Create = PageMethods.ServiceListToHtmlIncrct(MissingCode, NextId, Mode, TotalCount, Header, DecimalCnt, CurrencyId, orgID, corptID, month, year, RemarkMode, function (response) {
                var DuplicateCodeList = response;
                document.getElementById('cphMain_divDuplicateCodeList').innerHTML = DuplicateCodeList[0];

                if (Mode == '1') {
                    document.getElementById("<%=btnDuplicateCodeListPrevious.ClientID%>").disabled = false;
                    //document.getElementById("<%=btnDuplicateCodeListPrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnDuplicateCodeListPrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnDuplicateCodeListNext.ClientID%>").disabled = false;
                    //document.getElementById("<%=btnDuplicateCodeListNext.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnDuplicateCodeListNext.ClientID%>").style.cursor = 'pointer';
                }
                document.getElementById("<%=HiddenDuplicateCodeListNext.ClientID%>").value = DuplicateCodeList[1];
                if (Mode == '1') {
                    if (parseInt(document.getElementById("<%=HiddenDuplicateCodeListCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenDuplicateCodeListNext.ClientID%>").value)) {
                        document.getElementById("<%=btnDuplicateCodeListNext.ClientID%>").disabled = true;
                        //document.getElementById("<%=btnDuplicateCodeListNext.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnDuplicateCodeListNext.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenDuplicateCodeListNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnDuplicateCodeListPrevious.ClientID%>").disabled = "disabled";
                        //document.getElementById("<%=btnDuplicateCodeListPrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnDuplicateCodeListPrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            })
            return false;
        }
        function IncorrectCodeListRecord(Mode) {
            var RemarkMode = 1;
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var month = document.getElementById("cphMain_ddlMonth").value;
            var year = document.getElementById("cphMain_ddlYear").value;

            var DecimalCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var CurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;

            var Header = document.getElementById("<%=HiddenFieldHeaderList.ClientID%>").value;
            var NextId = document.getElementById("<%=HiddenIncorrectCodeListNext.ClientID%>").value;
            var MissingCode = document.getElementById("<%=HiddenIncorrectCodeList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenIncorrectCodeListCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';
            var Create = PageMethods.ServiceListToHtmlIncrct(MissingCode, NextId, Mode, TotalCount, Header, DecimalCnt, CurrencyId, orgID, corptID, month, year, RemarkMode, function (response) {
                var IncorrectCodeList = response;
                document.getElementById('cphMain_divIncorrectCodeList').innerHTML = IncorrectCodeList[0];

                if (Mode == '1') {
                    document.getElementById("<%=btnIncorrectCodeListPrevious.ClientID%>").disabled = false;
                    //document.getElementById("<%=btnIncorrectCodeListPrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnIncorrectCodeListPrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnIncorrectCodeListNext.ClientID%>").disabled = false;
                    //document.getElementById("<%=btnIncorrectCodeListNext.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnIncorrectCodeListNext.ClientID%>").style.cursor = 'pointer';
                }
                document.getElementById("<%=HiddenIncorrectCodeListNext.ClientID%>").value = IncorrectCodeList[1];
                if (Mode == '1') {
                    if (parseInt(document.getElementById("<%=HiddenIncorrectCodeListCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenIncorrectCodeListNext.ClientID%>").value)) {
                        document.getElementById("<%=btnIncorrectCodeListNext.ClientID%>").disabled = true;
                        //document.getElementById("<%=btnIncorrectCodeListNext.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnIncorrectCodeListNext.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenIncorrectCodeListNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnIncorrectCodeListPrevious.ClientID%>").disabled = "disabled";
                        //document.getElementById("<%=btnIncorrectCodeListPrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnIncorrectCodeListPrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            })
            return false;
        }
        function MissingAmountListRecord(Mode) {
            var RemarkMode = 0;
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var month = document.getElementById("cphMain_ddlMonth").value;
            var year = document.getElementById("cphMain_ddlYear").value;
            var RemarkMode = 0;
            var DecimalCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var CurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;

            var Header = document.getElementById("<%=HiddenFieldHeaderList.ClientID%>").value;
            var NextId = document.getElementById("<%=HiddenMissingAmountListNext.ClientID%>").value;
            var MissingCode = document.getElementById("<%=HiddenMissingAmountList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenMissingAmountListCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';
            var Create = PageMethods.ServiceListToHtmlIncrct(MissingCode, NextId, Mode, TotalCount, Header, DecimalCnt, CurrencyId, orgID, corptID, month, year, RemarkMode, function (response) {
                var MissingAmountList = response;
                document.getElementById('cphMain_divMissingAmountList').innerHTML = MissingAmountList[0];

                if (Mode == '1') {
                    document.getElementById("<%=btnMissingAmountListPrevious.ClientID%>").disabled = false;
                    //document.getElementById("<%=btnMissingAmountListPrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnMissingAmountListPrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnMissingAmountListNext.ClientID%>").disabled = false;
                    //document.getElementById("<%=btnMissingAmountListNext.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnMissingAmountListNext.ClientID%>").style.cursor = 'pointer';
                }
                document.getElementById("<%=HiddenMissingAmountListNext.ClientID%>").value = MissingAmountList[1];
                if (Mode == '1') {
                    if (parseInt(document.getElementById("<%=HiddenMissingAmountListCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenMissingAmountListNext.ClientID%>").value)) {
                        document.getElementById("<%=btnMissingAmountListNext.ClientID%>").disabled = true;
                        //document.getElementById("<%=btnMissingAmountListNext.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnMissingAmountListNext.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenMissingAmountListNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnMissingAmountListPrevious.ClientID%>").disabled = "disabled";
                        //document.getElementById("<%=btnMissingAmountListPrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnMissingAmountListPrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            })
            return false;
        }
        function IncorrectAmountListRecord(Mode) {
            var RemarkMode = 0;
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var month = document.getElementById("cphMain_ddlMonth").value;
            var year = document.getElementById("cphMain_ddlYear").value;

            var DecimalCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var CurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;

            var Header = document.getElementById("<%=HiddenFieldHeaderList.ClientID%>").value;
            var NextId = document.getElementById("<%=HiddenIncorrectAmountListNext.ClientID%>").value;
            var MissingCode = document.getElementById("<%=HiddenIncorrectAmountList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenIncorrectAmountListCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';
            var Create = PageMethods.ServiceListToHtmlIncrct(MissingCode, NextId, Mode, TotalCount, Header, DecimalCnt, CurrencyId, orgID, corptID, month, year, RemarkMode, function (response) {
                var IncorrectAmountList = response;
                document.getElementById('cphMain_divIncorrectAmountList').innerHTML = IncorrectAmountList[0];

                if (Mode == '1') {
                    document.getElementById("<%=btnIncorrectAmountListPrevious.ClientID%>").disabled = false;
                    //document.getElementById("<%=btnIncorrectAmountListPrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnIncorrectAmountListPrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnIncorrectAmountListNext.ClientID%>").disabled = false;
                    //document.getElementById("<%=btnIncorrectAmountListNext.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnIncorrectAmountListNext.ClientID%>").style.cursor = 'pointer';
                }
                document.getElementById("<%=HiddenIncorrectAmountListNext.ClientID%>").value = IncorrectAmountList[1];
                if (Mode == '1') {
                    if (parseInt(document.getElementById("<%=HiddenIncorrectAmountListCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenIncorrectAmountListNext.ClientID%>").value)) {
                        document.getElementById("<%=btnIncorrectAmountListNext.ClientID%>").disabled = true;
                        //document.getElementById("<%=btnIncorrectAmountListNext.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnIncorrectAmountListNext.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenIncorrectAmountListNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnIncorrectAmountListPrevious.ClientID%>").disabled = "disabled";
                        //document.getElementById("<%=btnIncorrectAmountListPrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnIncorrectAmountListPrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            })
            return false;
        }
        function BlockedEmpListRecord(Mode) {
            var RemarkMode = 2;
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var month = document.getElementById("cphMain_ddlMonth").value;
            var year = document.getElementById("cphMain_ddlYear").value;

            var DecimalCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var CurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;

            var Header = document.getElementById("<%=HiddenFieldHeaderList.ClientID%>").value;
            var NextId = document.getElementById("<%=HiddenBlockedEmpListNext.ClientID%>").value;
            var MissingCode = document.getElementById("<%=HiddenBlockedEmpList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenBlockedEmpListCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';
            var Create = PageMethods.ServiceListToHtmlIncrct(MissingCode, NextId, Mode, TotalCount, Header, DecimalCnt, CurrencyId, orgID, corptID, month, year, RemarkMode, function (response) {
                var BlockedEmpList = response;
                document.getElementById('cphMain_divBlockedEmpList').innerHTML = BlockedEmpList[0];

                if (Mode == '1') {
                    document.getElementById("<%=btnBlockedEmpListPrevious.ClientID%>").disabled = false;
                    //document.getElementById("<%=btnBlockedEmpListPrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnBlockedEmpListPrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnBlockedEmpListNext.ClientID%>").disabled = false;
                    //document.getElementById("<%=btnBlockedEmpListNext.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnBlockedEmpListNext.ClientID%>").style.cursor = 'pointer';
                }
                document.getElementById("<%=HiddenBlockedEmpListNext.ClientID%>").value = BlockedEmpList[1];
                if (Mode == '1') {
                    if (parseInt(document.getElementById("<%=HiddenBlockedEmpListCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenBlockedEmpListNext.ClientID%>").value)) {
                        document.getElementById("<%=btnBlockedEmpListNext.ClientID%>").disabled = true;
                        //document.getElementById("<%=btnBlockedEmpListNext.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnBlockedEmpListNext.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenBlockedEmpListNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnBlockedEmpListPrevious.ClientID%>").disabled = "disabled";
                        //document.getElementById("<%=btnBlockedEmpListPrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnBlockedEmpListPrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            })
            return false;
        }
        function confirmUpdate() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to add the following records to the table?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    saveAllCsv();
                    document.getElementById("<%=btnCsvSave.ClientID%>").click();   
                }
                else {
                    return false;
                }
            });
            return false;
        }
        function saveAllCsv() {

            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];

            var tr = $("#tbodyCorrect > tr");
            var trHead = $("#theadCorrect > tr");
            var lengRow = trHead[0].getElementsByTagName("th").length;
            for (var i = 0; i < tr.length; i++) {
                var EmpCode = tr[i].getElementsByTagName("td")[0].innerHTML;
                var AddDedkeyValue = "";
                for (var j = 2; j < parseInt(lengRow)-1 ; j++) {
                    var AddDedId = trHead[0].getElementsByTagName("th")[j].innerHTML;
                    var AddDed = tr[i].getElementsByTagName("input")[j-2].value.trim();
                    if (AddDed != "" && AddDedId != "") {
                        if (AddDedkeyValue == "") {
                            AddDedkeyValue = AddDedId + "%" + AddDed ;
                        }
                        else {
                            AddDedkeyValue = AddDedkeyValue + "$" + AddDedId + "%" + AddDed ;
                        }
                    }
                }
                if (AddDedkeyValue != "") {
                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        EMPCODE: "" + EmpCode + "",
                        EMPADDDED: "" + AddDedkeyValue + ""
                    });
                    tbClientJobSheduling.push(client);
                }
            }
            $add("#cphMain_HiddenFieldCsvDataSave").val(JSON.stringify(tbClientJobSheduling));
        }
        function SuccCsvSave() {
            $("#success-alert").html("Manual addition/deduction entry saved successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=HiddenFieldCsvDataSave.ClientID%>").value = "";
            return false;
        }
        function Err() {     
            $("#divWarning").html("Some error occurred!.Try again.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=HiddenFieldCsvDataSave.ClientID%>").value = "";
            return false;
        }  
    </script>

    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            changeMonthYear(0);
            document.getElementById('<%=btnCodeMissingBack.ClientID %>').style.display = "";
            document.getElementById('<%=btnCodeMissingNext.ClientID %>').style.display = "";
            document.getElementById('<%=btnRateMissingUpdate.ClientID %>').style.display = "";
        });
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
            return false;
        }
        var Mainconfirmbox = 0;
        function MainIncrmntConfrmCounter() {
            Mainconfirmbox++;
            return false;
        }
        function ConfirmMessage() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "hcm_Manual_AddDed_Entry_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "hcm_Manual_AddDed_Entry_List.aspx";
                return false;
            }
        }
        function confirmConf() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to confirm manual addition/deduction entry?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    FuctionSaveMain(null, 1,null);
                }
                else {
                    return false;
                }
            });
            return false;
        }
        function confirmReop() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to reopen manual addition/deduction entry?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    FuctionSaveMain(null, 3,null);
                }
                else {
                    return false;
                }
            });
            return false;
        }
        function SuccessSave() {
            $("#success-alert").html("Manual addition/deduction entry saved successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpdate() {
            $("#success-alert").html("Manual addition/deduction entry updated successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessConf() {
            $("#success-alert").html("Manual addition/deduction entry confirmed successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessReop() {
            $("#success-alert").html("Manual addition/deduction entry reopened successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
    </script>
    <script>
        var RowNumMain = 0;
        function AddNewRowMain(mode) {
         var FrecRow = '';

         FrecRow += '<tr id="mainRowId_' + RowNumMain + '">';
         FrecRow += '<td style="display: none" >' + RowNumMain + '</td>';
         FrecRow += '<td id="dbId_' + RowNumMain + '" style="display: none" >0</td>';

         FrecRow += '<td id="tdChangeIcon_' + RowNumMain + '"></td>';
         FrecRow += '<td><input placeholder="-Select-" id="ddlEmpIdT_' + RowNumMain + '" onfocus="return focusMain(\'' + RowNumMain + '\');"  onchange="return changeEmpMain(\'' + RowNumMain + '\');"  maxlength="100"   onkeypress="return selectorToAutocompleteTextBox(' + RowNumMain + ',event);" onkeydown="return selectorToAutocompleteTextBox(' + RowNumMain + ',event);" type="text" class="form-control fg2_inp2 myTextBox"></td>';
         FrecRow += '<td style="display: none;"><input id="ddlEmpId_' + RowNumMain + '" value="-Select-"></td>';
         FrecRow += '<td style="display: none;"><input id="ddlEmpIdTold_' + RowNumMain + '" value=""></td>';

         FrecRow += '<td id="tdEmpName_' + RowNumMain + '" class=" tr_l"></td>';

         var AddColSpan = document.getElementById("cphMain_HiddenFieldAddSpan").value;
         var DedColSpan = document.getElementById("cphMain_HiddenFieldDedSpan").value;

         var tot = 0;
         var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
         tot = parseFloat(tot);
         tot = tot.toFixed(FloatingValue);

         for (var i = 0; i < parseInt(document.getElementById("cphMain_HiddenFieldTotAddDedNum").value) ; i++) {
             
             var AddDedCommonDesc = document.getElementById("tdDesc_" + i).value.trim();
             var AddDedId = document.getElementById("tdAddDedId_" + i).value.trim();
             var AddDedIdAct = document.getElementById("tdAddDedIdAct_" + i).value.trim();
             var AddDedName = document.getElementById("tdAddDedName_" + i).value.trim();
             FrecRow += '<td class=" tr_r">';
             if (mode == 0 && AddDedIdAct == 0) {
                 FrecRow += '<span id="spanVal_' + RowNumMain + '_' + AddDedId + '"><input disabled id="txtAddDed_' + RowNumMain + '_' + i + '" onfocus="return focusMain(\'' + RowNumMain + '\');" onchange="return BlurNotNumber(\'txtAddDed_' + RowNumMain + '_' + i + '\',1)" maxlength="12" onkeydown="return isDecimalNumber(event,\'txtAddDed_' + RowNumMain + '_' + i + '\');" onkeypress="return isDecimalNumber(event,\'TxtAmount_' + RowNumMain + '_' + i + '\');" type="text" class="form-control fg2_inp2 tr_r" name="txtAddDed_' + RowNumMain + '_' + i + '"></span>';
             }
             else {
                 FrecRow += '<span id="spanVal_' + RowNumMain + '_' + AddDedId + '"><input id="txtAddDed_' + RowNumMain + '_' + i + '" onfocus="return focusMain(\'' + RowNumMain + '\');" onchange="return BlurNotNumber(\'txtAddDed_' + RowNumMain + '_' + i + '\',1)" maxlength="12" onkeydown="return isDecimalNumber(event,\'txtAddDed_' + RowNumMain + '_' + i + '\');" onkeypress="return isDecimalNumber(event,\'TxtAmount_' + RowNumMain + '_' + i + '\');" type="text" class="form-control fg2_inp2 tr_r" name="txtAddDed_' + RowNumMain + '_' + i + '"></span>';
             }
             FrecRow += '<span id="spanDtl_' + RowNumMain + '_' + AddDedId + '"><input id="txtAddDedTbId_' + RowNumMain + '_' + i + '" value=\"0\" style="display: none"  type="text"></span>';
             FrecRow += '<a  href="#" onclick="return ShowDescCommonAll(' + RowNumMain + ',' + i + ');" data-toggle="popover" data-html="true" data-content="<textarea id=\'txtDescCommon_' + RowNumMain + '_' + i + '\' onkeydown=\'textCounterS(' + RowNumMain + ',' + i + ',450,event);\' onkeyup=\'textCounterS(' + RowNumMain + ',' + i + ',450,event);\' onchange=\'return changeTextDescInd(' + RowNumMain + ',' + i + ');\'  type=\'text\' row=\'2\' placeholder=\'Add Remarks\'></textarea>" class="fa fa-commenting-o fzd1" title="' + AddDedName + '"></a>';
             FrecRow += '<span id="spanValDesc_' + RowNumMain + '_' + AddDedId + '"><input id="tdDesc_' + RowNumMain + '_' + i + '" name="tdDesc_' + RowNumMain + '_' + i + '" value="' + AddDedCommonDesc + '" style=\"display:none;\"/></span>';
             FrecRow += '<span id="spanValDescSts_' + RowNumMain + '_' + AddDedId + '"><input id="tdDescChnageSts_' + RowNumMain + '_' + i + '" name="tdDescChnageSts_' + RowNumMain + '_' + i + '" style=\"display:none;\"/></span>';
             FrecRow += '</td>';

             if (AddColSpan != "0" && parseInt(AddColSpan) - 1 == i) {
                 FrecRow += '<td id="totAddRow_' + RowNumMain + '" class="tr_r fnt_w6 grn1">' + tot + '</td>';
             }
             if (DedColSpan != "0" && (parseInt(DedColSpan) + parseInt(AddColSpan)) - 1 == i) {
                 FrecRow += '<td id="totDedRow_' + RowNumMain + '" class="tr_r fnt_w6 red1">' + tot + '</td>';
             }
         }

         FrecRow += '<td>';
         FrecRow += '<div class="btn_stl1">';
         FrecRow += '<button id="btnAdd_' + RowNumMain + '" onfocus="return focusMain(\'' + RowNumMain + '\');" onclick="return FuctionAddMain(\'' + RowNumMain + '\');" class="btn act_btn bn2 mainAdd" title="Add">';
         FrecRow += '<i class="fa fa-plus-circle"></i>';
         FrecRow += '</button>';
         FrecRow += '<button id="btnClear_' + RowNumMain + '" onfocus="return focusMain(\'' + RowNumMain + '\');" onclick="return FuctionClearMain(\'' + RowNumMain + '\');" class="btn act_btn bn4" title="clear"><i class="fa fa-times"></i>';
         FrecRow += '</button>';
         FrecRow += '<button id="btnDele_' + RowNumMain + '" onfocus="return focusMain(\'' + RowNumMain + '\');" onclick="return FuctionDeleMain(\'' + RowNumMain + '\');" class="btn act_btn bn3" title="Delete">';
         FrecRow += '<i class="fa fa-trash"></i>';
         FrecRow += '</button>';
         FrecRow += '<button id="btnSave_' + RowNumMain + '" onfocus="return focusMain(\'' + RowNumMain + '\');" onclick="return FuctionSaveMain(\'' + RowNumMain + '\',0,null);" class="btn act_btn bn2" title="Save">';
         FrecRow += '<i class="fa fa-save"></i>';
         FrecRow += '</button>';
         FrecRow += '</div>';
         FrecRow += '</td>';

         FrecRow += '</tr>';
         jQuery('#myTable').append(FrecRow);
         if (mode == "0") {
             document.getElementById("ddlEmpIdT_" + RowNumMain).focus();
         }
         $('.mainAdd').attr('disabled', 'disabled');
         var LastRowid = $("#myTable tr:last td:first").html();
         document.getElementById("btnAdd_" + LastRowid).disabled = false;
         RowNumMain++;
         $("[data-toggle=popover]").popover();
         $("[data-toggle=popover]").on('shown.bs.popover', function () {
             var id = document.getElementById("<%=HiddenFieldPopOverId.ClientID%>").value;
                var CurrVal = $("#tdDesc_" + id).val();
                $("#txtDescCommon_" + id).val(CurrVal);
            });
         return false;
        }
        function changeMonthYear(mode) {
            if (mode == "1") {
                //MainIncrmntConfrmCounter();
                if (confirmbox > 0) {
                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure you want to change period?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            changeMonthyearSub();
                            document.getElementById("<%=HiddenFieldCurrMonth.ClientID%>").value = document.getElementById("cphMain_ddlMonth").value;
                            document.getElementById("<%=HiddenFieldCurrYear.ClientID%>").value = document.getElementById("cphMain_ddlYear").value;
                            confirmbox = 0;
                            document.getElementById('divMissingCode').style.display = "none";
                            document.getElementById('divRateMissing').style.display = "none";
                            document.getElementById('divCsv').style.display = "none";
                            $(".Type").css("display", "");
                            document.getElementById('<%=FileUploader.ClientID %>').value = "";
                            document.getElementById('<%=Label1.ClientID %>').innerHTML = "No file selected";
                            document.getElementById('<%=HiddenFieldCsvDataSave.ClientID %>').value = "";
                        }
                        else {
                            document.getElementById("cphMain_ddlMonth").value=document.getElementById("<%=HiddenFieldCurrMonth.ClientID%>").value;
                            document.getElementById("cphMain_ddlYear").value = document.getElementById("<%=HiddenFieldCurrYear.ClientID%>").value;
                        }
                    });
                }
                else {
                    changeMonthyearSub();
                    document.getElementById("<%=HiddenFieldCurrMonth.ClientID%>").value = document.getElementById("cphMain_ddlMonth").value;
                    document.getElementById("<%=HiddenFieldCurrYear.ClientID%>").value = document.getElementById("cphMain_ddlYear").value;
                    confirmbox = 0;
                    document.getElementById('divMissingCode').style.display = "none";
                    document.getElementById('divRateMissing').style.display = "none";
                    document.getElementById('divCsv').style.display = "none";
                    $(".Type").css("display", "");
                    document.getElementById('<%=FileUploader.ClientID %>').value = "";
                    document.getElementById('<%=Label1.ClientID %>').innerHTML = "No file selected";
                    document.getElementById('<%=HiddenFieldCsvDataSave.ClientID %>').value = "";
                }
            }
            else {
                changeMonthyearSub();
            }
            return false;
        }
        function changeMonthyearSub() {
            document.getElementById("tbNodata").style.display = "none";
            $("#txtSearch1,#txtSearch2").val("");
            $("#myTable").empty();
            RowNumMain = 0;
            document.getElementById("<%=HiddenFieldOldRow.ClientID%>").value = "";
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var month = document.getElementById("cphMain_ddlMonth").value;
            var year = document.getElementById("cphMain_ddlYear").value;
            var Id = document.getElementById("<%=HiddenFieldMasterDbId.ClientID%>").value;
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "hcm_Manual_AddDed_Entry.aspx/changeMonthYear",
                data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",month: "' + month + '",year: "' + year + '",Id: "' + Id + '"}',
                dataType: "json",
                success: function (data) {

                    if (data.d[0] != "" && data.d[0] != null) {
                        document.getElementById("<%=HiddenFieldMasterDbId.ClientID%>").value = data.d[0];
                    }
                    else {
                        document.getElementById("<%=HiddenFieldMasterDbId.ClientID%>").value = 0;
                    }
                    if (data.d[3] != "" && data.d[3] != null) {
                        var find2 = '\\"\\[';
                        var re2 = new RegExp(find2, 'g');
                        var res2 = data.d[3].replace(re2, '\[');

                        var find3 = '\\]\\"';
                        var re3 = new RegExp(find3, 'g');
                        var res3 = res2.replace(re3, '\]');
                        var json = $noCon.parseJSON(res3);
                        for (var key in json) {
                            if (json.hasOwnProperty(key)) {
                                if (json[key].EMPID != "") {
                                    EditListRowsMain(json[key].EMPID, json[key].EMPCODE, json[key].EMPNAME, json[key].ADDDEDSTLS, json[key].PROCESSD);
                                }
                            }
                        }
                        document.getElementById("btnSave").innerText = "Update";
                        document.getElementById("btnSaveF").innerText = "Update";

                        document.getElementById("btnSaveClose").innerText = "Update & Close";
                        document.getElementById("btnSaveFClose").innerText = "Update & Close";

                        document.getElementById("cphMain_currPage").innerHTML = "Edit Manual Addition/Deduction Entry";
                        document.getElementById("currPageHead").innerHTML = "Edit Manual Addition/Deduction Entry";
                    }
                    else {
                        document.getElementById("cphMain_currPage").innerHTML = "Add Manual Addition/Deduction Entry";
                        document.getElementById("currPageHead").innerHTML = "Add Manual Addition/Deduction Entry";

                        document.getElementById("btnSave").innerText = "Save";
                        document.getElementById("btnSaveF").innerText = "Save";

                        document.getElementById("btnSaveClose").innerText = "Save & Close";
                        document.getElementById("btnSaveFClose").innerText = "Save & Close";
                        AddNewRowMain(0);
                    }
                    if (data.d[1] != "" && data.d[1] != "null" && data.d[1] != null) {
                        $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select:not(.notv)").prop("disabled", true);
                        $(".sub1,.sub2").css("display", "none");
                        if (document.getElementById("<%=HiddenFieldReopRole.ClientID%>").value == "1") {
                            $(".sub3").css("display", "");
                        }
                        document.getElementById("divImportCsv").style.display = "none";
                        document.getElementById("divDownloadCsv").style.display = "none";
                        document.getElementById("cphMain_currPage").innerHTML = "View Manual Addition/Deduction Entry";
                        document.getElementById("currPageHead").innerHTML = "View Manual Addition/Deduction Entry";
                    }
                    else if (data.d[2] != "" && data.d[2] != "null" && data.d[2] != null) {
                        $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select:not(.notv)").prop("disabled", true);
                        $(".sub1,.sub2,.sub3 ").css("display", "none");
                        document.getElementById("divImportCsv").style.display = "none";
                        document.getElementById("divDownloadCsv").style.display = "none";
                        document.getElementById("cphMain_currPage").innerHTML = "View Manual Addition/Deduction Entry";
                        document.getElementById("currPageHead").innerHTML = "View Manual Addition/Deduction Entry";
                    }
                    else {
                        $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select:not(.notv)").prop("disabled", false);
                        $(".sub1 ").css("display", "");
                        if (document.getElementById("<%=HiddenFieldConfRole.ClientID%>").value == "1" && document.getElementById("<%=HiddenFieldEditMode.ClientID%>").value == "1") {
                            $(".sub2 ").css("display", "");
                        }
                        else {
                            $(".sub2 ").css("display", "none");
                        }
                        $(".sub3 ").css("display", "none");
                        $(".Processed").find("input:not(.notv),button:not(.notv),checkbox,select:not(.notv)").prop("disabled", true);

                        $('.mainAdd').attr('disabled', 'disabled');
                        var LastRowid = $("#myTable tr:last td:first").html();
                        document.getElementById("btnAdd_" + LastRowid).disabled = false;
                        document.getElementById("divImportCsv").style.display = "";
                        document.getElementById("divDownloadCsv").style.display = "";
                    }
                }
            });
            return false;
        }
        function EditListRowsMain(EMPID, EMPCODE, EMPNAME, ADDDEDSTLS, PROCESSD) {
            AddNewRowMain(1);
            var validRowID = RowNumMain - 1;
            document.getElementById("dbId_" + validRowID).innerHTML = "1";
            document.getElementById("tdChangeIcon_" + validRowID).innerHTML = "<i class=\"fa fa-hdd-o grn\" title=\"Saved\"></i>";
            document.getElementById("ddlEmpId_" + validRowID).value = EMPID;
            document.getElementById("ddlEmpIdT_" + validRowID).value = EMPCODE;
            document.getElementById("ddlEmpIdTold_" + validRowID).value = EMPCODE;
            document.getElementById("tdEmpName_" + validRowID).innerHTML = EMPNAME;
            var splitrow = ADDDEDSTLS.split("$");
            for (var Cst = 0; Cst < splitrow.length; Cst++) {
                var splitEach = splitrow[Cst].split("%");
                if (splitEach[0] != "") {
                    $("#spanValDesc_" + validRowID + "_" + splitEach[0]).find("input:text").val(splitEach[3]);
                    $("#spanValDescSts_" + validRowID + "_" + splitEach[0]).find("input:text").val(splitEach[4]);
                    $("#spanVal_" + validRowID + "_" + splitEach[0]).find("input:text").val(splitEach[1]);
                    $("#spanDtl_" + validRowID + "_" + splitEach[0]).find("input:text").val(splitEach[2]);
                    BlurNotNumber($("#spanVal_" + validRowID + "_" + splitEach[0]).find("input:text").attr('id'),0);
                }
            }
            if (PROCESSD == "1") {
                $("#mainRowId_" + validRowID).addClass("Processed");
            }
        }
        function selectorToAutocompleteTextBox(x, ev) {
            ev = (ev) ? ev : window.event;
            var keyCodes = ev.keyCode ? ev.keyCode : ev.which ? ev.which : ev.charCode;
            if (keyCodes == 39) {
                $("#ddlEmpIdT_" + x).closest('tr').next().find(':input:visible:first').focus();
                return false;
            }
            else if (keyCodes == 37) {
                $("#ddlEmpIdT_" + x).closest('tr').prev().find(':input:visible:first').focus();
                return false;
            }
            var OldVal = document.getElementById("ddlEmpId_" + x).value;
            var $au = jQuery.noConflict();
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var month = document.getElementById("cphMain_ddlMonth").value;
            var year = document.getElementById("cphMain_ddlYear").value;
            if (corptID != '' && corptID != null && (!isNaN(corptID)) && orgID != '' && orgID != null && (!isNaN(orgID))) {
                $au("#ddlEmpIdT_" + x).autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "hcm_Manual_AddDed_Entry.aspx/changeEmployee",
                            async: false,
                            data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'orgID': '" + parseInt(orgID) + "', 'corptID': '" + parseInt(corptID) + "', 'month': '" + parseInt(month) + "', 'year': '" + parseInt(year) + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        val: item.split('<,>')[0],
                                        label: item.split('<,>')[3],                                       
                                        key: item.split('<,>')[2]
                                    }
                                }))
                            },
                            error: function (response) {
                            },
                            failure: function (response) {
                            }
                        });
                    },
                    autoFocus: false,
                    select: function (e, i) {              
                            document.getElementById("ddlEmpId_" + x).value = i.item.val;
                            document.getElementById("ddlEmpIdT_" + x).value = i.item.label.split('-')[0];
                            document.getElementById("ddlEmpIdTold_" + x).value = i.item.label.split('-')[0];
                            document.getElementById("tdEmpName_" + x).innerHTML = i.item.key;                  
                    },
                    change: function (event, ui) {
                        if (ui.item) {
                            //if (OldVal != document.getElementById("ddlEmpId_" + x).value) {
                                document.getElementById("ddlEmpIdT_" + x).value = document.getElementById("ddlEmpIdT_" + x).value.split('-')[0];
                                document.getElementById("ddlEmpIdTold_" + x).value = document.getElementById("ddlEmpIdT_" + x).value.split('-')[0];
                                changeSub(x);
                            //}
                        }
                        else {
                            document.getElementById("ddlEmpIdT_" + x).value = document.getElementById("ddlEmpIdTold_" + x).value;
                        }
                    }
                });
            }
        }
        function changeEmpMain(RowNum) {
            document.getElementById("cphMain_FileUploader").disabled = true;
            document.getElementById("tdChangeIcon_" + RowNum).innerHTML = "<i class=\"fa fa-spinner ble\" title=\"Editing\"></i>";
            IncrmntConfrmCounter();
            if (document.getElementById("ddlEmpIdT_" + RowNum).value == "") {
                document.getElementById("ddlEmpIdT_" + RowNum).value = document.getElementById("ddlEmpIdTold_" + RowNum).value;
                return false;
            }
            //changeSub(RowNum);
            return false;
        }
        function changeSub(RowNum) {
            document.getElementById("ddlEmpIdT_" + RowNum).style.borderColor = "";
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var month = document.getElementById("cphMain_ddlMonth").value;
            var year = document.getElementById("cphMain_ddlYear").value;
            var EmpId = document.getElementById("ddlEmpId_" + RowNum).value;

            var AddDedTotNum = document.getElementById("cphMain_HiddenFieldTotAddDedNum").value;
            var AddDedkeyValue = "";        
                for (var i = 0; i < parseInt(AddDedTotNum) ; i++) {
                    var AddDedTbId = document.getElementById("txtAddDedTbId_" + RowNum + "_" + i).value.trim();                  
                        if (AddDedTbId != "0") {
                            if (AddDedkeyValue == "") {
                                AddDedkeyValue = AddDedTbId;
                            }
                            else {
                                AddDedkeyValue = AddDedkeyValue + "%" + AddDedTbId;
                            }
                        }
                    }
            if (EmpId != "-Select-" && EmpId != "") {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "hcm_Manual_AddDed_Entry.aspx/checkEmpDuplication",
                    data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",month: "' + month + '",year: "' + year + '",EmpId: "' + EmpId + '",AddDedkeyValue: "' + AddDedkeyValue + '"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {
                            if (data.d == "dup") {
                                $("#divWarning").html("Duplication Error!.Employee can’t be duplicated in a month.");
                            }
                            else if (data.d == "Not joined") {
                                $("#divWarning").html("Employee not joined yet.");
                            }
                            else if (data.d == "Monthly salary processed") {
                                $("#divWarning").html("Monthly salary processing of employee is already done.");
                            }
                            else if (data.d == "End of service settlement done") {
                                $("#divWarning").html("End of service settlement of emloyee is already done.");
                            }
                            else if (data.d == "Leave settlement done") {
                                $("#divWarning").html("Leave settlement of emloyee is already done.");
                            }
                            else if (data.d == "on leave") {
                                $("#divWarning").html("Emloyee is on leave.");
                            }
                            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            document.getElementById("ddlEmpIdT_" + RowNum).style.borderColor = "red";
                            document.getElementById("ddlEmpIdT_" + RowNum).focus();
                            document.getElementById("ddlEmpIdT_" + RowNum).value = "";
                            document.getElementById("ddlEmpIdTold_" + RowNum).value = "";
                            document.getElementById("ddlEmpId_" + RowNum).value = "-Select-";
                            document.getElementById("tdEmpName_" + RowNum).innerHTML = "";
                        }
                        else{
                            if ($("#ddlEmpIdT_" + RowNum).closest('tr').next().find(':input:visible:first').length == 0) {
                                AddNewRowMain(1);
                            }
                           }
                    }
                });
            }
            return false;
        }
        function changeYear() {
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var year = document.getElementById("cphMain_ddlYear").value;
            if (corptID != null && corptID != "") {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "hcm_Manual_AddDed_Entry.aspx/changeYear",
                    data: '{corptID: "' + corptID + '",year: "' + year + '"}',
                    dataType: "json",
                    success: function (data) {
                        document.getElementById("cphMain_ddlMonth").innerHTML = data.d;
                    }
                });
            }
            return false;
        }
        function BlurNotNumber(obj, mode) {
            if (mode == "1") {
                document.getElementById("cphMain_FileUploader").disabled = true;
                IncrmntConfrmCounter();
                var str = obj.split('_')[1];
                document.getElementById("tdChangeIcon_" + str).innerHTML = "<i class=\"fa fa-spinner ble\" title=\"Editing\"></i>";
            }
            document.getElementById(obj).style.borderColor = "";
            var txt = document.getElementById(obj).value.trim();
            if (txt != "") {
                txt = txt.replace(/,/g, "");
                if (isNaN(txt)) {
                    document.getElementById(obj).value = "";
                    document.getElementById(obj).focus();                   
                }
                else{
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    txt =parseFloat(txt);
                    txt = txt.toFixed(FloatingValue);
                    document.getElementById(obj).value = addCommasSummry(txt);                   
                }
            }
            totalRow(obj.split('_')[1]);
            totalCol(obj.split('_')[2]);  
            return false;
        }
        function totalCol(j) {
            var tr, td, i, tot = 0, grandAdd = 0, grandDed = 0;
            tr = $("#myTable > tr:visible")
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[0].innerHTML;
                var colVal = document.getElementById("txtAddDed_" + td + "_" + j).value.trim();
                colVal = colVal.replace(/,/g, "");
                if (colVal != "") {
                    tot = parseFloat(tot) + parseFloat(colVal);
                }


                var colVal1 = document.getElementById("totAddRow_" + td).innerHTML.trim();
                colVal1 = colVal1.replace(/,/g, "");
                if (colVal1 != "") {
                    grandAdd = parseFloat(grandAdd) + parseFloat(colVal1);
                }

                var colVal2 = document.getElementById("totDedRow_" + td).innerHTML.trim();
                colVal2 = colVal2.replace(/,/g, "");
                if (colVal2 != "") {
                    grandDed = parseFloat(grandDed) + parseFloat(colVal2);
                }

            }
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            tot = parseFloat(tot);
            tot = tot.toFixed(FloatingValue);
            document.getElementById("tdAddDedTotCol_" + j).innerHTML = addCommasSummry(tot);

            grandAdd = parseFloat(grandAdd);
            grandAdd = grandAdd.toFixed(FloatingValue);
            document.getElementById("tdAddTotAmnt").innerHTML = addCommasSummry(grandAdd);

            grandDed = parseFloat(grandDed);
            grandDed = grandDed.toFixed(FloatingValue);
            document.getElementById("tdDedTotAmnt").innerHTML = addCommasSummry(grandDed);
        }
        function totalRow(j) {
            var addTot = 0, dedTot = 0;
            var AddDedTotNum = document.getElementById("cphMain_HiddenFieldTotAddDedNum").value;
            var AddColSpan = document.getElementById("cphMain_HiddenFieldAddSpan").value;
            var DedColSpan = document.getElementById("cphMain_HiddenFieldDedSpan").value;

                for (var i = 0; i < parseInt(AddDedTotNum) ; i++) {     
                    var colVal = document.getElementById("txtAddDed_" + j + "_" + i).value.trim();
                    colVal = colVal.replace(/,/g, "");
                    if (colVal != "") {
                        if (AddColSpan != "0" && parseInt(AddColSpan) - 1 >= i) {
                            addTot = parseFloat(addTot) + parseFloat(colVal);
                        }
                        else if (DedColSpan != "0" && (parseInt(DedColSpan) + parseInt(AddColSpan)) - 1 >= i) {
                            dedTot = parseFloat(dedTot) + parseFloat(colVal);
                        }   
                    }
                }
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            addTot = parseFloat(addTot);
            addTot = addTot.toFixed(FloatingValue);
            document.getElementById("totAddRow_" + j).innerHTML = addCommasSummry(addTot);
            dedTot = parseFloat(dedTot);
            dedTot = dedTot.toFixed(FloatingValue);
            document.getElementById("totDedRow_" + j).innerHTML = addCommasSummry(dedTot);
        }
        function DelClearRow() {
            var AddDedTotNum = document.getElementById("cphMain_HiddenFieldTotAddDedNum").value;
            for (var i = 0; i < parseInt(AddDedTotNum) ; i++) {
                totalCol(i);
            }
          }
        function FuctionAddMain(RowNum) {
            IncrmntConfrmCounter();
            if (checkMainRow(RowNum) == true) {
                AddNewRowMain(0);
            }
            return false;
        }
        function FuctionDeleMain(RowNum) {
            IncrmntConfrmCounter();
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to delete this employee?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=HiddenFieldOldRow.ClientID%>").value = "";
                    var detailId = document.getElementById("dbId_" + RowNum).innerHTML;
                    if (detailId == "1") {
                        SaveUpdDelEmpDtls(RowNum, 2,0,1,null);
                    }
                    $('#mainRowId_' + RowNum).remove();
                    DelClearRow();
                    var TableRowCount = document.getElementById("myTable").rows.length;
                    if (TableRowCount != 0) {
                        var LastRowid = $("#myTable tr:last td:first").html();
                        document.getElementById("btnAdd_" + LastRowid).disabled = false;
                    }
                    else {
                        RowNumMain = 0;
                        AddNewRowMain(0);                        
                        if (document.getElementById("<%=HiddenFieldEditMode.ClientID%>").value != "1") {
                            document.getElementById("cphMain_ddlMonth").disabled = false;
                            document.getElementById("cphMain_ddlYear").disabled = false;
                            document.getElementById("<%=HiddenFieldMasterDbId.ClientID%>").value = "0";
                        }
                    }
                }
                else {
                }
                if (document.getElementById("<%=HiddenFieldMasterDbId.ClientID%>").value == "0") {
                    $(".pn_o2").css("display", "none"); //evm-0023-26aug
                }
            });
            return false;
        }
        function checkMainRow(RowNum) {
            var ret = true;
            var EmpId = document.getElementById("ddlEmpId_" + RowNum).value;
            document.getElementById("ddlEmpIdT_" + RowNum).style.borderColor = "";                       
            if (EmpId == "" || EmpId == "-Select-") {
                document.getElementById("ddlEmpIdT_" + RowNum).style.borderColor = "red";
                document.getElementById("ddlEmpIdT_" + RowNum).focus();
                return false;
            }

            if (document.getElementById("cphMain_HiddenFieldMasterDbId").value != "") {
                $(".pn_o2").css("display", ""); //evm-0023-26aug
            }

            for (var i = 0; i < parseInt(document.getElementById("cphMain_HiddenFieldTotAddDedNum").value) ; i++) {
                var AddDed = document.getElementById("txtAddDed_" + RowNum + "_" + i).value.trim();
                if (AddDed != "") {
                    return true;
                }
            }
            document.getElementById("txtAddDed_" + RowNum + "_0").focus();
            $("#divWarning").html("Atleast one addition or deduction is required.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            $(window).scrollTop(0);
            return false;
        }
        function FuctionClearMain(RowNum) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to clear this addition/deduction details?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    IncrmntConfrmCounter();
                    var detailId = document.getElementById("dbId_" + RowNum).innerHTML;
                    if (detailId == "0") {
                        $('#mainRowId_' + RowNum).find('input:text').val('');
                        document.getElementById("ddlEmpId_" + RowNum).value = "-Select-";
                        document.getElementById("tdEmpName_" + RowNum).innerHTML = "";
                        DelClearRow();
                    }
                    else {


                  var AddDedTotNum = document.getElementById("cphMain_HiddenFieldTotAddDedNum").value;
                  var MasterDbId = document.getElementById("<%=HiddenFieldMasterDbId.ClientID%>").value;
                  for (var i = 0; i < parseInt(AddDedTotNum) ; i++) {
                  var AddDedTbId = document.getElementById("txtAddDedTbId_" + RowNum + "_" + i).value.trim();
                  if (AddDedTbId != "0" && AddDedTbId != "") {
                      var flag = 0;
                      $.ajax({
                          type: "POST",
                          async: false,
                          contentType: "application/json; charset=utf-8",
                          url: "hcm_Manual_AddDed_Entry.aspx/ReadClearData",
                          data: '{MasterDbId: "' + MasterDbId + '",AddDedTbId: "' + AddDedTbId + '"}',
                          dataType: "json",
                          success: function (data) {

                              $('#mainRowId_' + RowNum).find('input:text').val('');
                              if (data.d[3] != "" && data.d[3] != null) {
                                  var find2 = '\\"\\[';
                                  var re2 = new RegExp(find2, 'g');
                                  var res2 = data.d[3].replace(re2, '\[');

                                  var find3 = '\\]\\"';
                                  var re3 = new RegExp(find3, 'g');
                                  var res3 = res2.replace(re3, '\]');
                                  var json = $noCon.parseJSON(res3);
                                  for (var key in json) {
                                      if (json.hasOwnProperty(key)) {
                                          if (json[key].EMPID != "") {

                                              document.getElementById("ddlEmpId_" + RowNum).value = json[key].EMPID;
                                              document.getElementById("ddlEmpIdT_" + RowNum).value = json[key].EMPCODE;
                                              document.getElementById("ddlEmpIdTold_" + RowNum).value = json[key].EMPCODE;
                                              document.getElementById("tdEmpName_" + RowNum).innerHTML = json[key].EMPNAME;
                                              var splitrow = json[key].ADDDEDSTLS.split("$");
                                              for (var Cst = 0; Cst < splitrow.length; Cst++) {
                                                  var splitEach = splitrow[Cst].split("%");
                                                  if (splitEach[0] != "") {
                                                      flag = 1;
                                                      $("#spanValDesc_" + RowNum + "_" + splitEach[0]).find("input:text").val(splitEach[3]);
                                                      $("#spanValDescSts_" + RowNum + "_" + splitEach[0]).find("input:text").val(splitEach[4]);
                                                      $("#spanVal_" + RowNum + "_" + splitEach[0]).find("input:text").val(splitEach[1]);
                                                      $("#spanDtl_" + RowNum + "_" + splitEach[0]).find("input:text").val(splitEach[2]);
                                                      BlurNotNumber($("#spanVal_" + RowNum + "_" + splitEach[0]).find("input:text").attr('id'), 0);
                                                  }
                                              }
                                              DelClearRow();
                                          }
                                      }
                                  }
                              }

                          }
                      });
                      if (flag == "1") {
                          return false;
                      }

                  }
              }
                    }




      }
      else {
          return false;
      }
            });
    return false;
        }
        function FuctionSaveMain(RowNum, Mode,ev) {
            if (RowNum == "" || RowNum == null || RowNum == "null") {
                RowNum = document.getElementById("<%=HiddenFieldOldRow.ClientID%>").value;
            }
            if (RowNum == "") {
                SaveUpdDelEmpDtls(null, Mode, 1,1,ev);
            }
            else {
                SaveUpdDelEmpDtls(RowNum, Mode,0,1,ev);
            }
            return false;
        }
        function SaveUpdDelEmpDtls(RowNum, Mode, MainMode, FocusMode, ev) {
            //Mode(0-save,1-confirm,2-delete,3-reopen)
            //MainMode(check main buttons direct click)
            //FocusMode(0-On focus,1-not on focus)
            if (parseInt(Mode) < 2 && MainMode=="0"&& checkMainRow(RowNum) == false) {
               return false;
            }
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var userID = '<%= Session["USERID"] %>';
            var MasterDbId = document.getElementById("<%=HiddenFieldMasterDbId.ClientID%>").value;
            var MonthNum = document.getElementById("cphMain_ddlMonth").value;
            var YearNum = document.getElementById("cphMain_ddlYear").value;
            var AddDedTotNum = document.getElementById("cphMain_HiddenFieldTotAddDedNum").value;           
            var Currency_id = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
            var EmpId =0;
            var AddDedkeyValue = "";
            if (Mode != "3" && MainMode=="0") {
                var EmpId = document.getElementById("ddlEmpId_" + RowNum).value;
                for (var i = 0; i < parseInt(AddDedTotNum) ; i++) {                   
                    var Desc = document.getElementById("tdDesc_" + RowNum + "_" + i).value.trim();
                    var DescSts = document.getElementById("tdDescChnageSts_" + RowNum + "_" + i).value.trim();
                    var AddDedId = document.getElementById("tdAddDedId_" + i).value.trim();
                    var AddDed = document.getElementById("txtAddDed_" + RowNum + "_" + i).value.trim();
                    var AddDedTbId = document.getElementById("txtAddDedTbId_" + RowNum + "_" + i).value.trim();
                    if (parseInt(Mode)<2) {
                        if (AddDed != "" || AddDedTbId != "0") {
                            if (AddDedkeyValue == "") {
                                AddDedkeyValue = AddDedId + "%" + AddDed + "%" + AddDedTbId+ "%" + Desc + "%" + DescSts;
                            }
                            else {
                                AddDedkeyValue = AddDedkeyValue + "$" + AddDedId + "%" + AddDed + "%" + AddDedTbId + "%" + Desc + "%" + DescSts;
                            }
                           if (AddDedTbId != "0" && AddDed == "") {
                                document.getElementById("txtAddDedTbId_" + RowNum + "_" + i).value = 0;
                            }
                        }
                    }
                    else if (Mode == "2") {
                        AddDed = "";
                        if (AddDedTbId != "0") {
                            if (AddDedkeyValue == "") {
                                AddDedkeyValue = AddDedId + "%" + AddDed + "%" + AddDedTbId + "%" + Desc + "%" + DescSts;
                            }
                            else {
                                AddDedkeyValue = AddDedkeyValue + "$" + AddDedId + "%" + AddDed + "%" + AddDedTbId + "%" + Desc + "%" + DescSts;
                            }
                        }
                    }
                }
            }  
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "hcm_Manual_AddDed_Entry.aspx/SaveUpdDelEmpDtls",
                data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",userID: "' + userID + '",MasterDbId: "' + MasterDbId + '",MonthNum: "' + MonthNum + '",YearNum: "' + YearNum + '",RowNum: "' + RowNum + '",Mode: "' + Mode + '",EmpId: "' + EmpId + '",AddDedkeyValue: "' + AddDedkeyValue + '",Currency_id: "' + Currency_id + '"}',
                dataType: "json",
                success: function (data) {
                    if (data.d[1] == "" || data.d[1] == null || data.d[1] == "null") {
                        document.getElementById("<%=HiddenFieldMasterDbId.ClientID%>").value = data.d[0];
                        if (Mode == 1) {
                            SuccessConf();
                        }
                        else if (Mode == 3) {
                            SuccessReop();
                            changeMonthYear(0);
                        }
                        else if (Mode == 0 && FocusMode == 1) {
                            var clickedBtnId = "";
                            if (ev != "null" && ev != null && ev != "") {
                                 clickedBtnId = ev.srcElement.id;
                            }
                            if (clickedBtnId == "btnSave" || clickedBtnId == "btnSaveF") {
                                if (document.getElementById("btnSaveF").innerText == "Update") {
                                    SuccessUpdate();
                                }
                                else {
                                    SuccessSave();
                                }
                            }
                            else if (clickedBtnId == "btnSaveClose" || clickedBtnId == "btnSaveFClose") {
                                if (document.getElementById("btnSaveFClose").innerText == "Update & Close") {
                                    window.location.href = "hcm_Manual_AddDed_Entry_List.aspx?InsUpd=Upd";
                                }
                                else {
                                    window.location.href = "hcm_Manual_AddDed_Entry_List.aspx?InsUpd=Ins";
                                }
                            }
                            else {
                                SuccessSave();
                            }
                        }
                        if (RowNum != null && RowNum != "null" && RowNum != "") {
                            document.getElementById("tdChangeIcon_" + RowNum).innerHTML = "<i class=\"fa fa-hdd-o grn\" title=\"Saved\"></i>";
                        }
                        if (parseInt(Mode) < 2 && MainMode == "0") {
                            document.getElementById("dbId_" + RowNum).innerHTML = "1";
                            if (data.d[2] != "" && data.d[2] != null && data.d[2] != "null" && RowNum != null && RowNum != "null" && RowNum != "") {
                                var splitrow = data.d[2].split("$");
                                for (var Cst = 0; Cst < splitrow.length; Cst++) {
                                    var splitEach = splitrow[Cst].split("%");
                                    if (splitEach[0] != "" && splitEach[1] != "0") {
                                        $("#spanDtl_" + RowNum + "_" + splitEach[0]).find("input:text").val(splitEach[1]);
                                    }
                                }
                            }                         
                        }
                    }
                    else if (data.d[1] == "DupEmp") {
                        if (RowNum != null && RowNum != "") {
                            $("#divWarning").html("Duplication Error!.Employee can’t be duplicated in a month.");
                            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            document.getElementById("ddlEmpIdT_" + RowNum).style.borderColor = "red";
                            document.getElementById("ddlEmpIdT_" + RowNum).focus();
                            document.getElementById("ddlEmpIdT_" + RowNum).value = "";
                            document.getElementById("ddlEmpIdTold_" + RowNum).value = "";
                            document.getElementById("ddlEmpId_" + RowNum).value = "-Select-";
                            document.getElementById("tdEmpName_" + RowNum).innerHTML = "";
                        }
                        return false;
                    }
                    else {
                        window.location.href = "hcm_Manual_AddDed_Entry_List.aspx?InsUpd=" + data.d[1];
                        return true;
                    }
                }
            });
            if (Mode == "1" ) {
                $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select:not(.notv)").prop("disabled", true);
                $(".sub1,.sub2").css("display", "none");
                if (document.getElementById("<%=HiddenFieldReopRole.ClientID%>").value == "1") {
                    $(".sub3").css("display", "");
                }
                document.getElementById("divImportCsv").style.display = "none";
                document.getElementById("divDownloadCsv").style.display = "none";
                document.getElementById("cphMain_currPage").innerHTML = "View Manual Addition/Deduction Entry";
                document.getElementById("currPageHead").innerHTML = "View Manual Addition/Deduction Entry";
            }
            else if (Mode == "3" ) {
                $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select:not(.notv)").prop("disabled", false);
                $(".sub1").css("display", "");
                if (document.getElementById("<%=HiddenFieldConfRole.ClientID%>").value == "1") {
                    $(".sub2 ").css("display", "");
                }
                $(".sub3 ").css("display", "none");
                $(".Processed").find("input:not(.notv),button:not(.notv),checkbox,select:not(.notv)").prop("disabled", true);
                $('.mainAdd').attr('disabled', 'disabled');
                var LastRowid = $("#myTable tr:last td:first").html();
                document.getElementById("btnAdd_" + LastRowid).disabled = false;
                document.getElementById("divImportCsv").style.display = "";
                document.getElementById("divDownloadCsv").style.display = "";
                document.getElementById("cphMain_currPage").innerHTML = "Edit Manual Addition/Deduction Entry";
                document.getElementById("currPageHead").innerHTML = "Edit Manual Addition/Deduction Entry";
            }
            if (document.getElementById("<%=HiddenFieldMasterDbId.ClientID%>").value != "0") {
                document.getElementById("cphMain_ddlMonth").disabled = true;
                document.getElementById("cphMain_ddlYear").disabled = true;
            }
            else {
                document.getElementById("cphMain_ddlMonth").disabled = true;
                document.getElementById("cphMain_ddlYear").disabled = true;
            }
            return true;
        }
        function focusMain(CurrentRow) {
            var oldRow = document.getElementById("<%=HiddenFieldOldRow.ClientID%>").value;
            if (CurrentRow != oldRow && oldRow != "") {
                if (SaveUpdDelEmpDtls(oldRow, 0,0,0,null) == false) {
                    return false;
                }
                if (document.getElementById("dbId_" + oldRow).innerHTML == "1") {
                    document.getElementById("tdChangeIcon_" + oldRow).innerHTML = "<i class=\"fa fa-hdd-o grn\" title=\"Saved\"></i>";
                }
                else {
                    document.getElementById("tdChangeIcon_" + oldRow).innerHTML = "";
                }
            }
            document.getElementById("<%=HiddenFieldOldRow.ClientID%>").value = CurrentRow;           
            return false;
        }
        $("#txtSearch2,#txtSearch1").bind("keyup keypress keydown", function (evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (keyCodes == 13) {
                return false;
            }
            var flag = 0;
            var input, filter, table, tr, td, i, td1, input2, filter2;
            input = document.getElementById("txtSearch1");
            input2 = document.getElementById("txtSearch2");
            filter = input.value.toUpperCase().toString().replace(/\s/g, '');
            filter2 = input2.value.toUpperCase().toString().replace(/\s/g, '');
            tr = $("#myTable > tr") 
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("input")[0];
                td1 = tr[i].getElementsByTagName("td")[6];
                if (td1) {                  
                    if (td1.innerHTML.toUpperCase().toString().replace(/\s/g, '').indexOf(filter2) > -1 && td.value.toUpperCase().toString().replace(/\s/g, '').indexOf(filter) > -1) {
                        tr[i].style.display = "";
                        flag = 1;
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
            //if (flag == 1) {
            //    document.getElementById("tbNodata").style.display = "none";
            //}
            //else {
            //    document.getElementById("tbNodata").style.display = "";              
            //}
            DelClearRow();
        });
        $(document).ready(function () {
            $('.myTextBox').bind('copy paste cut', function (e) {
                e.preventDefault(); //disable cut,copy,paste
            });
            if (document.getElementById('<%=HiddenFieldMasterDbId.ClientID %>').value == "" || document.getElementById('<%=HiddenFieldMasterDbId.ClientID %>').value == "0") {
                $(".pn_o2").css("display", "none"); //evm-0023-26aug
            }
        });
    </script>
     <script>
        function isDecimalNumber(evt, textboxid) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var txtPerVal = document.getElementById(textboxid).value;
            if (keyCodes == 39) {
                $("#" + textboxid).closest('tr').next().find(':input:visible:first').focus();
                return false;
            }
            else if (keyCodes == 37) {
                $("#" + textboxid).closest('tr').prev().find(':input:visible:first').focus();
                return false;
            }
            //enter
            if (keyCodes == 13) {
                return false;
            }
                //0-9
            else if (keyCodes >= 48 && keyCodes <= 57) {
                return true;
            }
                //numpad 0-9
            else if (keyCodes >= 96 && keyCodes <= 105) {
                return true;
            }
                //left arrow key,right arrow key,home,end ,delete
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 38 || keyCodes == 40) {
                return true;
            }
            else if (keyCodes == 46) {
                return true;
            }
            else if (keyCodes == 34 || keyCodes == 33 || keyCodes == 36 || keyCodes == 35 || keyCodes == 41) {

                return true;
            }

            else if ((keyCodes == 65 || keyCodes == 86 || keyCodes == 67) && (evt.ctrlKey === true || evt.metaKey === true)) {
                return true;
            }
                // . period and numpad . period
            else if (keyCodes == 190 || keyCodes == 110) {
                var ret = true;
                var count = txtPerVal.split('.').length - 1;
                if (count > 0) {
                    ret = false;
                }
                else {
                    ret = true;
                }
                return ret;
            }
            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    ret = false;
                }
                return ret;
            }
        }
        function addCommasSummry(nStr) {
            nStr += '';
            var x = nStr.split('.');
            var x1 = x[0];
            var x2 = x[1];

            if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "1") {
                var rgx = /(\d+)(\d{7})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{5})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{3})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
            }

            if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "2") {
                var rgx = /(\d+)(\d{9})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{6})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{5})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{3})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
            }
            if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "3") {
                var rgx = /(\d+)(\d{9})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{6})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
                rgx = /(\d+)(\d{3})/;
                if (rgx.test(x1)) {
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');
                }
            }
            if (isNaN(x2))
               return x1;
            else
               return x1 + "." + x2;
        }
        
    </script>
     <style>
         .ui-autocomplete {
             padding: 0;
             list-style: none;
             background-color: #fff;
             width: 300px;
             border: 1px solid #B0BECA;
             max-height: 140px;
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
            .searchlist_btn_rght {
            cursor:pointer;
            background: transparent;
        }
       .searchlist_btn_rght:disabled
       {
       background-color: #e6e6e6;
       }
    </style>

    <!---print_button--->
<asp:Button ID="btnPrint" runat="server" class="submit_ser" style="display:none" OnClick="btnPrint_Click" />
<a href="javascript:;" type="button" class="print_o pn_o2"  onclick="return PrintBtnClick()" title="Print page"> <%--//evm-0023-26aug--%>
  <i class="fa fa-print"></i>
</a>
<!---print_button_closed--->

    <script>
        function PrintBtnClick() {
            document.getElementById("<%=btnPrint.ClientID%>").click();
        }
  $(function(){
      // Enables popover
      $("[data-toggle=popover]").popover();
  });
  $('body').on('click', function (e) {
      $('[data-toggle=popover]').each(function () {
          // hide any open popovers when the anywhere else in the body is clicked
          if (!$(this).is(e.target) && $(this).has(e.target).length === 0 && $('.popover').has(e.target).length === 0) {
              $(this).popover('hide');
          }
      });
  });
  $(function () {
      $("[data-toggle=popover]").on('shown.bs.popover', function () {
          var id = document.getElementById("<%=HiddenFieldPopOverId.ClientID%>").value;
          var CurrVal = $("#tdDesc_" + id).val();
          $("#txtDescCommon_" + id).val(CurrVal);
          if (document.getElementById("cphMain_currPage").innerHTML == "View Manual Addition/Deduction Entry") {
              $("#txtDescCommon_" + id).prop('disabled', true);
          }
          else {
              var arrId = id.split('_');
              if (arrId.length > 1) {
                  if ($("#mainRowId_" + arrId[0]).hasClass("Processed")) {
                      $("#txtDescCommon_" + id).prop('disabled', true);
                  }
              }
          }
       });
    });
        function ShowDescCommon(id) {
            document.getElementById("<%=HiddenFieldPopOverId.ClientID%>").value = id;  
        }
        function ShowDescCommonAll(x,y) {
            document.getElementById("<%=HiddenFieldPopOverId.ClientID%>").value = x + "_" + y;
        }
        function changeTextDesc(id) {
         var userID = '<%= Session["USERID"] %>';
         var currVal = $("#txtDescCommon_" + id).val();
         $("#tdDesc_" + id).val(currVal);
         var ids = "";
         var Desc = currVal;
         var ChangeSts = 0;
         var tr, td, i;
         tr = $("#myTable > tr")
         for (i = 0; i < tr.length; i++) {
             td = tr[i].getElementsByTagName("td")[0].innerHTML;
             var colVal = document.getElementById("tdDescChnageSts_" + td + "_" + id).value.trim();
             if ($("#mainRowId_" + td).hasClass("Processed")) {
             }
             else {
                 if (colVal != "1") {
                     $("#tdDesc_" + td + "_" + id).val(currVal);
                     var AddDedTbId = document.getElementById("txtAddDedTbId_" + td + "_" + id).value.trim();
                     if (AddDedTbId != "" && AddDedTbId != "0") {
                         if (ids == "") {
                             ids = AddDedTbId;
                         }
                         else {
                             ids = ids + "-" + AddDedTbId;
                         }
                     }
                 }
             }
         }
         if (ids != "") {
             $.ajax({
                 type: "POST",
                 async: false,
                 contentType: "application/json; charset=utf-8",
                 url: "hcm_Manual_AddDed_Entry.aspx/changeDescription",
                 data: '{ids: "' + ids + '",Desc: "' + Desc + '",ChangeSts: "' + ChangeSts + '",userID: "' + userID + '"}',
                 dataType: "json",
                 success: function (data) {
                 }
             });
         }
        }
        function changeTextDescInd(x, y) {
            var userID = '<%= Session["USERID"] %>';
            var currVal = $("#txtDescCommon_" + x + "_" + y).val();
            $("#tdDesc_" + x + "_" + y).val(currVal);
            $("#tdDescChnageSts_" + x + "_" + y).val("1");
            var AddDedTbId = document.getElementById("txtAddDedTbId_" + x + "_" + y).value.trim();
            if (AddDedTbId != "" && AddDedTbId != "0") {
                var ids = AddDedTbId;
                var Desc = currVal;
                var ChangeSts = 1;
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "hcm_Manual_AddDed_Entry.aspx/changeDescription",
                    data: '{ids: "' + ids + '",Desc: "' + Desc + '",ChangeSts: "' + ChangeSts + '",userID: "' + userID + '"}',
                    dataType: "json",
                    success: function (data) {
                    }
                });
            }
        }
        function textCounter(field, maxlimit,evt) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {
            }
        } 
        function textCounterS(x, y, maxlimit,evt) {
            var currVal=$("#txtDescCommon_" + x + "_" + y).val();
            if (currVal.length > maxlimit) {
                currVal = currVal.substring(0, maxlimit);
                $("#txtDescCommon_" + x + "_" + y).val(currVal);
            } else {
            }   
        }
        $(document).on('keyup', function (evt) {
            if (evt.keyCode == 27) {
                var id = document.getElementById("<%=HiddenFieldPopOverId.ClientID%>").value;
                if (id != "" && id != null && id != "null") {
                    $("#txtDescCommon_" + id).change();
                }
                $('[data-toggle=popover]').each(function () {
                    $(this).popover('hide');
                });
            }
        });
    </script>

</asp:Content>

