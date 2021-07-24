<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_approval_assignment.aspx.cs" Inherits="Master_gen_approval_assignment_gen_approval_assignment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
 <script src="/js/New%20js/date_pick/datepicker.js"></script>

 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
   

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

           .ui-autocomplete {
               position: absolute;
               cursor: default;
               z-index: 4000 !important;
           }
    </style>
	
    <script>
        var $noCon = jQuery.noConflict();

        $noCon(window).load(function () {

            //$noCon("#divVendor> input").select();

        });

        var $au = jQuery.noConflict();
        $au(function () {
           
            $au(".ddl").selectToAutocomplete1Letter();
            $au(".ddl").select();
        });

    </script>
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

         <asp:HiddenField ID="HiddenEdit" runat="server"/>
     <asp:HiddenField ID="hiddenMainCanclDbId" runat="server" />
    <asp:HiddenField ID="HiddenMaincanceldl" runat="server" />
    <asp:HiddenField ID="HiddenFieldMainData" runat="server" />
     <asp:HiddenField ID="Hiddenview" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldView" runat="server" value="0"/>
    <asp:HiddenField ID="HiddenApprovalId" runat="server" />
    <asp:HiddenField ID="HiddenEditlist" runat="server" />
     <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="HiddenDesgid" runat="server" />
     <asp:HiddenField ID="HiddenCancel" runat="server"></asp:HiddenField>


     <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>

    <ol class="breadcrumb">
      <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
      <li><a href="/Master/gen_approval_assignment/gen_approval_assignment_list.aspx">Approval Assignment</a></li>
      <li class="active">Add Approval Assignment</li>
    </ol>

<!---breadcrumb_section_started----> 

    <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con"><asp:Label ID="lblEntry" runat="server">Add Purchase Order</asp:Label></h1>

        <div class="clearfix"></div>
    <div class="free_sp"></div>
            <div class="form-group fg2 fg5_r1 pa_ze">
            <label class="fg2_la1">Designation<span class="spn1"></span>:</label>
              <asp:DropDownList ID="ddldesg" runat="server" class="form-control fg2_inp1 fg_chs1 ddl" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);" TabIndex="0">
               </asp:DropDownList>           
          </div>

         
         
  

            <div style="display:none">
            <asp:DropDownList ID="ddlwrkflw" runat="server"></asp:DropDownList><asp:DropDownList ID="ddlapproval" runat="server"></asp:DropDownList></div>
         

           
 <!----==========--->
 <div class="clearfix"></div>  <div class="free_sp"></div>
 <!----==========--->

            <div class="tabl_set" >
          <table class="table table-bordered tbl_set_fix">
            <thead class="thead1">
              <tr>
               
                 <th class="th_b9 tr_l">Document</th>
            <th class="th_b4 tr_l">Approval Set</th>
            <th class="th_b4">Start Date</th>
            <th class="th_b4">End Date</th>
                   <th class="th_b4">Actions</th>
              </tr>
            </thead>
            <tbody id="mainTable">
            </tbody>
          </table>
        </div>

         
<!---inner_content_sections area_closed--->

<!---========area_devider==========---->
    <div class="clearfix"></div>
    <div class="free_sp"></div>
<!---========area_devider==========---->


<!--Buttons_Area_started--->
          <div class="sub_cont pull-right">
            <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClientClick="return mainValidate();" onclick="btnAdd_Click"/>
               <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClientClick="return mainValidate();" onclick="btnAdd_Click" />
                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" OnClientClick="return mainValidate();" class="btn sub1" Visible="False"/>
                 <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return mainValidate();" onclick="btnUpdate_Click" Visible="false" />
                <asp:Button ID="btnCancel" runat="server" class="btn sub4 notv" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                <asp:Button ID="btnClear" runat="server" class="btn sub2" Text="Clear" OnClientClick="return AlertClearAll();"  />
          </div>
<!--Buttons_area_closed--->



<!---frame_border_area_closed---->
        </div>
      </div>
    </div>
  </div>
<!----------------------------------------------Content_section_opened------------------------------------------------------------->

<!-------------------footer_section_opened------------------------------------->
  <div class="footer" onclick="closeNav4(), closeNav5(), closeNav()">
    <p class="tr_l foot_l up_cs"><i class="ft_ico"><img src="../images/ft_ico.png"></i> Procurement Management</p>
    <p class="p_col1"><img src="../images/logo.png" class="img_foot"></p>
    <p class="pull-right tr_c foot_l ">Designed by <span>democompany</span> Technologies</p>
  </div>
<!-------------------footer_section_closed------------------------------------->

</div><!--wrapper_closed-->

<!---back_button_fixed_section--->
 

   
<!---back_button_fixed_section--->


<!---back_button_fixed_section--->
  <a href="gen_approval_assignment_list.aspx" type="button" class="list_b" title="Back to List">
    <i class="fa fa-arrow-circle-left"></i>
  </a>
<!---back_button_fixed_section--->

<!----save_quick_actions_started--->
  <a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
    <i class="fa fa-save"></i>
  </a>

  <div class="mySave1" id="mySave">
     <asp:Button ID="btnsave" runat="server" class="btn sub1" Text="Save" OnClientClick="return mainValidate();" onclick="btnAdd_Click"/>
                <asp:Button ID="btnsaveclose" runat="server" class="btn sub3" Text="Save & Close" OnClientClick="return mainValidate();" onclick="btnAdd_Click" />
       <asp:Button ID="btnupdate2" runat="server" OnClick="btnUpdate_Click" Text="Update" OnClientClick="return mainValidate();" class="btn sub1" Visible="False"/>
                 <asp:Button ID="btnupdateclose2" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return mainValidate();" onclick="btnUpdate_Click" Visible="false" />

           
         <asp:Button ID="btncancel2" runat="server" class="btn sub4 notv" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                <asp:Button ID="btnclear2" runat="server" class="btn sub2" Text="Clear" OnClientClick="return AlertClearAll();"  />
        
  </div>
<!----save_quick_actions_closed--->

<!----modal popup_section for Substitute Employees_opened--->

<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Employees</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>


<!----modal popup_section for Substitute Employees_closed--->

<!--------script section_started---------->
    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            var EditVal = document.getElementById("<%=HiddenEdit.ClientID%>").value;
           // var EditVal = "";
             if (EditVal != "") {
                 
                
                 var find2 = '\\"\\[';
                 var re2 = new RegExp(find2, 'g');
                 var res2 = EditVal.replace(re2, '\[');

                 var find3 = '\\]\\"';
                 var re3 = new RegExp(find3, 'g');
                 var res3 = res2.replace(re3, '\]');
                 var json = $noCon.parseJSON(res3);
                 for (var key in json) {
                     if (json.hasOwnProperty(key)) {
                         
                         if (json[key].DTLID != "") {
                            
                             EditListRows(json[key].DOC, json[key].WRKNAME, json[key].APPRO, json[key].APPNAME, json[key].SDATE, json[key].EDATE, json[key].DTLID, json[key].CON);

                         }
                         
                     }
                     
                 }
             }
             else {
                 editlist(null);


             }
             if(EditVal=="[]")
             {
           
                         editlist(null);
         
             }
            // if (document.getElementById("<%=Hiddenview.ClientID%>").value == "1") {

              //  $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select").prop("disabled", true);
           // }
         });
    </script>
    <script>

        function OpenCancelView(DtlId,ROWNUM) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to cancel this Assignment?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    
                    var doc = document.getElementById("ddldocI_" + ROWNUM).value;
                   
                    var appro = document.getElementById("ddlapproI_" + ROWNUM).value;
                    var sdate = document.getElementById("dte_1_a_" + ROWNUM).value;
                    var edate = document.getElementById("dte_1_" + ROWNUM).value;
                    DeleteByID(DtlId,doc,appro,sdate,edate);
                    //DeleteByID(DtlId);
                }
                else {
                }
            });
            return false;
        }



        function DeleteByID(DtlId,doc,appro,sdate,edate) {
            
            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
            var strasid = document.getElementById("<%=HiddenApprovalId.ClientID%>").value;
            var desgid = document.getElementById("<%=HiddenDesgid.ClientID%>").value;
            //alert(doc);
            if (DtlId != "") {
              
               // var Details = PageMethods.CancelReason(strasid, DtlId, strUserID, strOrgIdID, strCorpID, function (response) {
               
                    $.ajax({
                        type: "POST",
                       async: false,
                       
                        contentType: "application/json; charset=utf-8",
                        url: "gen_approval_assignment.aspx/CancelReason",
                        data: '{strasid: "' + strasid + '",DtlId:"' + DtlId + '",strUserID:"' + strUserID + '",strOrgIdID:"' + strOrgIdID + '",strCorpID:"' + strCorpID + '",doc:"' + doc + '",appro:"' + appro + '",sdate:"' + sdate+ '",edate:"'+edate+'",desgid:"'+desgid+'"}',
                        dataType: "json",
                        success: function (data) {

                            //alert(data.d);
                            if (data.d == "successcncl") {
                                //window.location = 'gen_approval_assignment.aspx?InsUpd=Cncl';
                                $("#success-alert").html("Approval Set cancelled successfully.");
                                $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

                                });
                                var Id1 = document.getElementById("<%=HiddenCancel.ClientID%>").value;
                                window.location = "gen_approval_assignment.aspx?Id=" + Id1;
                            }
                            else if (data.d == "successcnclfull") {
                                window.location = "gen_approval_assignment_list.aspx?InsUpd=Cncl";
                            }
                           
                        }
                    });
                  
            }

            return false;
        }








        </script>
 	


    <script>
        var RowNumMain = 0;

        function AddNewRowMain(DTLID,CON) {
            var FrecRow = '';
            // RowNumMain=0;
           // var dtlId = COND;
            //var a = RowNumMain + 1;
            FrecRow += '<tr id="mainRowId_' + RowNumMain + '" class="tr_act">';
            FrecRow += '<td style="display:none" >' + RowNumMain + '</td>';
            FrecRow += '<td id="dbId_' + RowNumMain + '" style="display: none" >' + DTLID + '</td>';
            FrecRow += '<td id="dbId1_' + RowNumMain + '" style="display: none" >' + CON + '</td>';
            // FrecRow += '<td >' + a + '</td>';
           
            FrecRow += '<td> ';
          
                FrecRow += ' <div id="doc2_' + RowNumMain + '"><input placeholder="-Select-" id="ddldoc_' + RowNumMain + '" onchange="return changeDesgMain(\'' + RowNumMain + '\');"  maxlength="100" onkeypress="return selectorToAutocompleteTextBox(' + RowNumMain + ',0);" onkeydown="return selectorToAutocompleteTextBox(' + RowNumMain + ',0);" onkeyup="return selectorToAutocompleteTextBox(' + RowNumMain + ',0);" type="text" class="form-control fg2_inp2"></td>';
                FrecRow += '<td style="display: none;"><input id="ddldocI_' + RowNumMain + '" value="-Select-">';

             
                FrecRow += ' <td>';
                FrecRow += '<div id="app2_' + RowNumMain + '"><input placeholder="-Select-" id="ddlappro_' + RowNumMain + '" onchange="return changeappMain(\'' + RowNumMain + '\');"  maxlength="100" onkeypress="return selectorToAutocompleteTextBox(' + RowNumMain + ',1);" onkeydown="return selectorToAutocompleteTextBox(' + RowNumMain + ',1);" onkeyup="return selectorToAutocompleteTextBox(' + RowNumMain + ',1);" type="text" class="form-control fg2_inp2"></td>';
                FrecRow += '<td style="display: none;"><input id="ddlapproI_' + RowNumMain + '" value="-Select-">';

            FrecRow += '<td>';
            if (CON == "1") {
                FrecRow += '<div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">';
                FrecRow += '<input disabled="" class="form-control inp_bdr inp_pro1 pa_l1 pa_r1" id="dte_1_a_' + RowNumMain + '" onchange="return changeDate(\'' + 1 + '\',\'' + RowNumMain + '\');" type="text"  autocomplete="off" /><span class="input-group-addon date1 dt_pro1"><i class="fa fa-calendar"></i></span></div>';
            }
            else {
                FrecRow += '<div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">';
                FrecRow += '<input class="form-control inp_bdr inp_pro1 pa_l1 pa_r1" id="dte_1_a_' + RowNumMain + '"   onchange="return changeDate(\'' + 1 + '\',\'' + RowNumMain + '\');" type="text"  autocomplete="off" /><span class="input-group-addon date1 dt_pro1"><i class="fa fa-calendar"></i></span></div>';

            }
            FrecRow += '</td>';
            FrecRow += '<td>';
            if (CON == "1") {
                FrecRow += '<div id="datepicker2" class="input-group date" data-date-format="mm-dd-yyyy">';
                FrecRow += '<input  disabled="" class="form-control inp_bdr inp_pro1 pa_l1 pa_r1" id="dte_1_' + RowNumMain + '" type="text" onchange="return changeDate(\'' + 1 + '\',\'' + RowNumMain + '\');"  autocomplete="off"/><span class="input-group-addon date1 dt_pro1"><i class="fa fa-calendar"></i></span></div>';
            }
            else
            {
                FrecRow += '<div id="datepicker2" class="input-group date" data-date-format="mm-dd-yyyy" >';
                FrecRow += '<input class="form-control inp_bdr inp_pro1 pa_l1 pa_r1" id="dte_1_' + RowNumMain + '" type="text"   onchange="return changeDate(\'' + 1 + '\',\'' + RowNumMain + '\');"  autocomplete="off"/><span class="input-group-addon date1 dt_pro1"><i class="fa fa-calendar"></i></span></div>';

            }
                
            FrecRow += '</td>';

            FrecRow += '<td class="td1">';
            FrecRow += '<div class="btn_stl1">';
            if (CON == "1") {
                FrecRow += '<button class="btn act_btn bn4" title="Recall" data-toggle="modal" data-target="#exampleModalre" Onclick="return OpenReasign(\'' + DTLID + '\',\'' + RowNumMain + '\');"><i class="fa fa-repeat"></i></button>';
            }
            else {
                FrecRow += '<button class="btn act_btn bn4" title="Recall" data-toggle="modal" data-target="#exampleModalre" disabled=""><i class="fa fa-repeat"></i></button>';
            }
            FrecRow += '<button id="btnAdd_' + RowNumMain + '" onclick="return FuctionAddMain(\'' + RowNumMain + '\');" class="btn act_btn bn1 mainAdd" title="Add"><i class="fa fa-plus-circle"></i></button>';
           
            if (document.getElementById("<%=HiddenMaincanceldl.ClientID%>").value == "1") {
                if (CON == 1) {
                    FrecRow += '<button id="btnDele_' + RowNumMain + '" disabled="" class="btn act_btn bn3" title="Delete"><i class="fa fa-trash"></i></button>';

                }
                else {


                    FrecRow += '<button id="btnDele_' + RowNumMain + '" Onclick="return OpenCancelView(\'' + DTLID + '\',\'' + RowNumMain + '\');" class="btn act_btn bn3" title="Delete"><i class="fa fa-trash"></i></button>';
                }
            }
            else {
                FrecRow += '<button id="btnDele_' + RowNumMain + '" Onclick="return FuctionDeleMain(\'' + RowNumMain + '\');" class="btn act_btn bn3" title="Delete"><i class="fa fa-trash"></i></button>';

            }

            FrecRow += '</div>';
            FrecRow += '</td>';


            FrecRow += '</tr>';
            jQuery('#mainTable').append(FrecRow);
            $noCon('#dte_1_a_'+RowNumMain).datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                startDate: new Date(),
                timepicker: false
            });
            $noCon('#dte_1_'+RowNumMain).datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                startDate: new Date(),
                timepicker: false
            });
            //if (dtlId == "null" || dtlId == null || dtlId == "") {
            //  document.getElementById("ddlcon_" + RowNumMain).focus();
            //}
            $('.mainAdd').attr('disabled', 'disabled');
            var LastRowid = $("#mainTable tr:last td:first").html();
            document.getElementById("btnAdd_" + LastRowid).disabled = false;
            RowNumMain++;
            return false;
            enable();
        }

     </script>
   
   
    
        <script>
            function OpenReasign(DtlId, RowNum) {
                var sdte = document.getElementById("dte_1_a_" + RowNum).value;
                var edte = document.getElementById("dte_1_" + RowNum).value;
                var ddlwrk = document.getElementById("<%=ddlwrkflw.ClientID%>").value;
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_approval_assignment.aspx/updatewrkflwdtl",
                    data: '{DtlId: "' + DtlId + '",sdte:"'+sdte+'",edte:"'+edte+'",ddlwrk:"'+ddlwrk+'"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "" && data.d != null) {

                        }
                        else {

                        }
                    }

                });

            }



            function changeDate(mode,RowNum) {
                var app = document.getElementById("dte_1_" + RowNum).value;
                var sdate = document.getElementById("dte_1_a_" + RowNum).value;
                var doc = document.getElementById("ddldoc_" + RowNum).value;
                var orgID = '<%= Session["ORGID"] %>';
                var corptID = '<%= Session["CORPOFFICEID"] %>';
                if (app != "") {
                    var tableOtherItem = document.getElementById("mainTable");
                    var m = parseInt(tableOtherItem.rows.length) - 1;
                    for (var a = m; a >= 0; a--) {
                        var validRowID = (tableOtherItem.rows[a].cells[0].innerHTML);
                        var CheckappId = document.getElementById("dte_1_" + validRowID).value;
                        var Checksdate = document.getElementById("dte_1_a_" + validRowID).value;
                        var CheckdocId = document.getElementById("ddldoc_" + validRowID).value;

                     
                       
                     
                        var arrDateFromchk = app.split("-");
                        g1 = new Date(arrDateFromchk[2], arrDateFromchk[1] - 1, arrDateFromchk[0]);
                        var arrDateTochk = CheckappId.split("-");
                        g2 = new Date(arrDateTochk[2], arrDateTochk[1] - 1, arrDateTochk[0]);
                        var arrDateg3 = sdate.split("-");
                        g3 = new Date(arrDateg3[2], arrDateg3[1] - 1, arrDateg3[0]);
                        var arrDateg4 = Checksdate.split("-");
                        g4 = new Date(arrDateg4[2], arrDateg4[1] - 1, arrDateg4[0]);
                       
                        if ((g3 < g4)) {
                            
                            if ((g1 >= g4)) {
                                
                                $("#divWarning").html("Date Overlapping Not Allowed.");
                                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                });
                                document.getElementById("dte_1_" + RowNum).style.borderColor = "red";
                                document.getElementById("dte_1_" + RowNum).focus();
                                document.getElementById("dte_1_" + RowNum).value = "";
                                document.getElementById("dte_1_a_" + RowNum).style.borderColor = "red";
                                document.getElementById("dte_1_a_" + RowNum).focus();
                                document.getElementById("dte_1_a_" + RowNum).value = "";
                                return false;

                            }
                        }
                       else if ((g3 > g4)) {
                        
                           if ((g3 <= g2)) {

                               $("#divWarning").html("Date Overlapping Not Allowed.");
                               $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                               });
                               document.getElementById("dte_1_" + RowNum).style.borderColor = "red";
                               document.getElementById("dte_1_" + RowNum).focus();
                               document.getElementById("dte_1_" + RowNum).value = "";
                               document.getElementById("dte_1_a_" + RowNum).style.borderColor = "red";
                               document.getElementById("dte_1_a_" + RowNum).focus();
                               document.getElementById("dte_1_a_" + RowNum).value = "";
                               return false;

                           }
                       }
                       
                       else if (RowNum != validRowID && sdate == Checksdate)
                          {
                           $("#divWarning").html("Date Overlapping Not Allowed.");
                           $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                           });
                           document.getElementById("dte_1_" + RowNum).style.borderColor = "red";
                           document.getElementById("dte_1_" + RowNum).focus();
                           document.getElementById("dte_1_" + RowNum).value = "";
                           document.getElementById("dte_1_a_" + RowNum).style.borderColor = "red";
                           document.getElementById("dte_1_a_" + RowNum).focus();
                           document.getElementById("dte_1_a_" + RowNum).value = "";
                           return false;
                       }
                       else if (RowNum != validRowID && app == CheckappId ) {
                           $("#divWarning").html("Date Overlapping Not Allowed.");
                           $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                           });
                           document.getElementById("dte_1_" + RowNum).style.borderColor = "red";
                           document.getElementById("dte_1_" + RowNum).focus();
                           document.getElementById("dte_1_" + RowNum).value = "";
                           document.getElementById("dte_1_a_" + RowNum).style.borderColor = "red";
                           document.getElementById("dte_1_a_" + RowNum).focus();
                           document.getElementById("dte_1_a_" + RowNum).value = "";
                           return false;
                       }
                   
                       else {
                       }
                        if (RowNum != validRowID && app == CheckappId && doc == CheckdocId && sdate == Checksdate) {
                            
                           
                            
                                    $("#divWarning").html("Duplication Error!.Date can’t be duplicated in a hierarchy.");
                                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                    });
                                    document.getElementById("dte_1_" + RowNum).style.borderColor = "red";
                                    document.getElementById("dte_1_" + RowNum).focus();
                                    document.getElementById("dte_1_" + RowNum).value = "";
                                    document.getElementById("dte_1_a_" + RowNum).style.borderColor = "red";
                                    document.getElementById("dte_1_a_" + RowNum).focus();
                                    document.getElementById("dte_1_a_" + RowNum).value = "";
                                    return false;
                                
                          
                        }
                    }
                }
                var ret = true;
                document.getElementById("dte_1_a_"+RowNum).style.borderColor = "";
            document.getElementById("dte_1_"+RowNum).style.borderColor = "";
                var fromdate = document.getElementById("dte_1_a_"+RowNum).value;
                var toDate = document.getElementById("dte_1_"+RowNum).value;
                if (mode == "0") {
                   
                    if (fromdate == "") {
                        document.getElementById("dte_1_a_"+RowNum).style.borderColor = "Red";
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        $(window).scrollTop(0);
                        ret = false;
                    }
                    if (toDate == "") {
                        document.getElementById("dte_1_"+RowNum).style.borderColor = "Red";
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        $(window).scrollTop(0);
                        ret = false;
                    }
                }
                else {
                    IncrmntConfrmCounter();
                }
                if (fromdate != "" && toDate != "") {
                    var arrDateFromchk = fromdate.split("-");
                    dateDateFromchk = new Date(arrDateFromchk[2], arrDateFromchk[1] - 1, arrDateFromchk[0]);
                    var arrDateTochk = toDate.split("-");
                    dateDateTochk = new Date(arrDateTochk[2], arrDateTochk[1] - 1, arrDateTochk[0]);
                    if (dateDateFromchk > dateDateTochk) {
                        $("#divWarning").html("From date should not be greater than to date.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        $(window).scrollTop(0);
                        document.getElementById("dte_1_a_"+RowNum).style.borderColor = "Red";
                        document.getElementById("dte_1_"+RowNum).style.borderColor = "Red";
                        ret = false;
                    }
                }
             
                return ret;
            }




            function selectorToAutocompleteTextBox(x, mode) {
                var $au = jQuery.noConflict();
                var orgID = '<%= Session["ORGID"] %>';
                var corptID = '<%= Session["CORPOFFICEID"] %>';
                var desgid = document.getElementById("<%=ddldesg.ClientID%>").value;
               
               
                if (corptID != '' && corptID != null && (!isNaN(corptID)) && orgID != '' && orgID != null && (!isNaN(orgID))) {
                    if (mode == "0") {

                    $au("#ddldoc_" + x).autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: "gen_approval_assignment.aspx/ReadDocDdl",
                                data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'orgID': '" + parseInt(orgID) + "', 'corptID': '" + parseInt(corptID) + "','desgid':'"+desgid+"'}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {
                                    response($.map(data.d, function (item) {
                                        return {
                                            label: item.split('<->')[1],
                                            val: item.split('<->')[0]
                                        }
                                    }))
                                },
                                error: function (response) {
                                },
                                failure: function (response) {
                                }
                            });
                        },
                        autoFocus: true,
                        //focus: function (event, ui) {
                        //    $("#ddlDesgIdT_" + x).val(ui.item.label);
                        //    $("#ddlDesgId_" + x).val(ui.item.id);
                        //    return false;
                        //},
                        select: function (e, i) {
                            document.getElementById("ddldocI_" + x).value = i.item.val;
                            document.getElementById("ddldoc_" + x).value = i.item.label;
                        },
                        change: function (event, ui) {
                            if (ui.item) {
                            }
                            else {
                                document.getElementById("ddldoc_" + x).value = "-Select-";
                                document.getElementById("ddldocI_" + x).value = "";
                            }
                        },
                        minLength: 1

                    });
                }
                    else {
                       
                        var DesgId = document.getElementById("ddldocI_" + x).value;
                       
                        if (DesgId != "-Select-") {
                           
                            $au("#ddlappro_" + x).autocomplete({
                                source: function (request, response) {
                                    $.ajax({
                                        url: "gen_approval_assignment.aspx/ReadAssDdl",
                                        data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'orgID': '" + parseInt(orgID) + "', 'corptID': '" + parseInt(corptID) + "'}",
                                        dataType: "json",
                                        type: "POST",
                                        contentType: "application/json; charset=utf-8",
                                        success: function (data) {
                                            response($.map(data.d, function (item) {
                                                return {
                                                    label: item.split('<->')[1],
                                                    val: item.split('<->')[0]
                                                }
                                            }))
                                        },
                                        error: function (response) {
                                        },
                                        failure: function (response) {
                                        }
                                    });
                                },
                                autoFocus: true,
                                //focus: function (event, ui) {
                                //    $("#ddlEmpIdT_" + x).val(ui.item.label);
                                //    $("#ddlEmpId_" + x).val(ui.item.id);
                                //    return false;
                                //},
                                select: function (e, i) {
                                    document.getElementById("ddlapproI_" + x).value = i.item.val;
                                    document.getElementById("ddlappro_" + x).value = i.item.label;
                                },
                                change: function (event, ui) {
                                    if (ui.item) {
                                    }
                                    else {
                                        document.getElementById("ddlappro_" + x).value = "-Select-";
                                        document.getElementById("ddlapproI_" + x).value = "";
                                    }
                                },
                                minLength: 1

                            });
                        }
                    }
                }
            }
 </script>
    <script>
        function opensave() {
            document.getElementById("mySave").style.width = "140px";
        }

        function closesave() {
            document.getElementById("mySave").style.width = "0px";
        }
</script>
    <script>
  
        function SuccessIns() {
            $("#success-alert").html("Approval Assignment details inserted successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpd() {
            $("#success-alert").html("Approval Assignment details updated successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessCnfm() {
            $("#success-alert").html("Approval Assignment details Confirmed successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessReopen() {
            $("#success-alert").html("Approval Assignment details Reopened successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessCancelation() {
            $("#success-alert").html("Approval Set cancelled successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
               
            });
            return false;
        }

        function checkMainRow(RowNum) {
            var ret = true;
            var doc = document.getElementById("ddldoc_" + RowNum).value;
            var appro = document.getElementById("ddlappro_" + RowNum).value;

            document.getElementById("ddldoc_" + RowNum).style.borderColor = "";
            document.getElementById("ddlappro_" + RowNum).style.borderColor = "";

            if (appro == "0" || appro == "-Select-") {
                document.getElementById("ddlappro_" + RowNum).style.borderColor = "red";
                document.getElementById("ddlappro_" + RowNum).focus();
                ret = false;
            }
            if (doc == "0" || doc == "-Select-") {
                document.getElementById("ddldoc_" + RowNum).style.borderColor = "red";
                document.getElementById("ddldoc_" + RowNum).focus();
                ret = false;
            }
            return ret;
        }
        function FuctionAddMain(RowNum) {


            if (checkMainRow(RowNum) == true) {

                IncrmntConfrmCounter();
                editlist(RowNum);

            }
            return false;
        }
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
            return false;
        }
       

        function editlist(RowNum) {
            AddNewRowMain(null, null);
            var validRowID = RowNumMain - 1;
           // document.getElementById("dbId_" + validRowID).innerHTML = DTLID;
            //document.getElementById("doc2_" + validRowID).style.display = "block";
           // document.getElementById("doc1_" + validRowID).style.display = "none";
           // document.getElementById("app2_" + validRowID).style.display = "block";
            //document.getElementById("app1_" + validRowID).style.display = "none";
           
 	   
		
        }
        function FuctionDeleMain(RowNum) {

            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to cancel this hierarchy?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    IncrmntConfrmCounter();
                    var detailId = document.getElementById("dbId_" + RowNum).innerHTML;
                    if (detailId != "") {
                        var CanclIds = document.getElementById("cphMain_hiddenMainCanclDbId").value;
                        if (CanclIds == '') {
                            document.getElementById("cphMain_hiddenMainCanclDbId").value = detailId;
                        }
                        else {
                            document.getElementById("cphMain_hiddenMainCanclDbId").value = document.getElementById("cphMain_hiddenMainCanclDbId").value + ',' + detailId;
                        }
                    }
                    $('#mainRowId_' + RowNum).remove();
                    var TableRowCount = document.getElementById("mainTable").rows.length;
                    if (TableRowCount != 0) {
                        var LastRowid = $("#mainTable tr:last td:first").html();
                        document.getElementById("btnAdd_" + LastRowid).disabled = false;
                    }
                    else {
                        AddNewRowMain(null);
                    }
                    if (document.getElementById("cphMain_HiddenFieldCurrentDtlId").value == detailId) {
                        $(".hire").hide();
                        $("#subTable").empty();
                        document.getElementById("cphMain_hiddenSubCanclDbId").value = "";
                    }
                }
                else {
                }
            });
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
                        window.location.href = "gen_approval_assignment_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "gen_approval_assignment_List.aspx";
                return false;
            }
        }
        function AlertClearAll() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want clear all data in this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "gen_approval_assignment.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "gen_approval_assignment.aspx";
                return false;
            }
            return false;
        }
    </script>
    <script>
        function EditListRows(DOC,WRKNAME,APPRO,APPNAME,SDATE,EDATE,DTLID,CON) {
            AddNewRowMain(DTLID,CON);
            
             var validRowID = RowNumMain - 1;
             document.getElementById("dbId_" + validRowID).innerHTML = DTLID;
           // var wrkflw = document.getElementById("<%=ddlwrkflw.ClientID%>");
           // var wrk = document.getElementById("ddldoc_" + validRowID);
            //document.getElementById("ddldoc_" + validRowID).disabled = true;
            document.getElementById("dte_1_a_" + validRowID).value = SDATE;
            document.getElementById("dte_1_" + validRowID).value = EDATE;

            document.getElementById("ddldocI_" + validRowID).value = DOC;
            document.getElementById("ddldoc_" + validRowID).value = WRKNAME;

            document.getElementById("ddlapproI_" + validRowID).value = APPRO;
            document.getElementById("ddlappro_" + validRowID).value = APPNAME;

            if (CON != "1") {
            
            }
            else {
                document.getElementById("ddldocI_" + validRowID).disabled = true;
                document.getElementById("ddldoc_" + validRowID).disabled = true;
                document.getElementById("ddlappro_" + validRowID).disabled = true;
                document.getElementById("ddlapproI_" + validRowID).disabled = true;
            }
            
        }
        function AD(RowNum) {
          

            var wrkflw = document.getElementById("<%=ddlwrkflw.ClientID%>");
            var wrk = document.getElementById("ddldoc_" + RowNum);
           
            if (wrk.options.length == "1") {
                for (var i = 0; i < wrkflw.options.length; i++) {
                    // 
                    var opt = document.createElement("option");
                    opt.text = wrkflw[i].text;
                    opt.value = wrkflw[i].value;

                    wrk.options.add(opt);
                    //wrk.value = validRowID + 1;
                }
            }
        
        }
        function AD1(RowNum) {
             var app = document.getElementById("<%=ddlapproval.ClientID%>");
             var approv = document.getElementById("ddlappro_" + RowNum);
             if (approv.options.length == "1") {
                 for (var j = 0; j < app.options.length; j++) {
                     // 
                     var opt1 = document.createElement("option");
                     opt1.text = app[j].text;
                     opt1.value = app[j].value;

                     approv.options.add(opt1);
                 }
             }
         }
    </script>


     <script>
         function changeDesgMain(RowNum) {
             if (document.getElementById("<%=ddldesg.ClientID%>").value == "--Select--") {
                 $("#divWarning").html("Please Fill the Mandatory Fields.");
                 $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                 });
             }
             document.getElementById("ddldoc_" + RowNum).style.borderColor = "";
             document.getElementById("ddlappro_" + RowNum).style.borderColor = "";
             IncrmntConfrmCounter();
             if (document.getElementById("ddldoc_" + RowNum).value.trim() == "") {
                 document.getElementById("ddldoc_" + RowNum).value = "-Select-";
             }
             //document.getElementById("ddlappro_" + RowNum).value = "-Select-";
             //document.getElementById("ddlappro_" + RowNum).value = "";
           changeDate(1, RowNum);
             return false;
         }
         function changedatet(RowNum) {
           
             IncrmntConfrmCounter();
            
             //document.getElementById("dte_1_" + RowNum).style.borderColor = "";
          var app = document.getElementById("dte_1_" + RowNum).value;
             var sdate = document.getElementById("dte_1_a_" + RowNum).value;
             var doc = document.getElementById("ddldoc_" + RowNum).value;
             var orgID = '<%= Session["ORGID"] %>';
             var corptID = '<%= Session["CORPOFFICEID"] %>';
                if (app != "" ) {
                    var tableOtherItem = document.getElementById("mainTable");
                    var m = parseInt(tableOtherItem.rows.length) - 1;
                    for (var a = m; a >= 0; a--) {
                        var validRowID = (tableOtherItem.rows[a].cells[0].innerHTML);
                        var CheckappId = document.getElementById("dte_1_" + validRowID).value;
                        var CheckdocId = document.getElementById("ddldoc_" + validRowID).value;
                        if (RowNum != validRowID && app == CheckappId && doc == CheckdocId) {
                            $("#divWarning").html("Duplication Error!.Date can’t be duplicated in a hierarchy.");
                            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            document.getElementById("dte_1_" + RowNum).style.borderColor = "red";
                            document.getElementById("dte_1_" + RowNum).focus();
                            document.getElementById("dte_1_" + RowNum).value = "";
                            document.getElementById("dte_1_a_" + RowNum).style.borderColor = "red";
                            document.getElementById("dte_1_a_" + RowNum).focus();
                            document.getElementById("dte_1_a_" + RowNum).value = "";
                            return false;

                        }
                    }

                }
                return false;
            }
         function changeappMain(RowNum) {
             IncrmntConfrmCounter();
             document.getElementById("ddlappro_" + RowNum).style.borderColor = "";
             if (document.getElementById("ddlappro_" + RowNum).value.trim() == "" || document.getElementById("ddldoc_" + RowNum).value == "-Select-") {
                 document.getElementById("ddlappro_" + RowNum).value = "-Select-";
                 document.getElementById("ddlappro_" + RowNum).value = "";
                 return false;
             }
             var app = document.getElementById("ddlappro_" + RowNum).value;
             var doc = document.getElementById("ddldoc_" + RowNum).value;
             var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
    if (app != "-Select-") {
        var tableOtherItem = document.getElementById("mainTable");
        var m = parseInt(tableOtherItem.rows.length) - 1;
        for (var a = m; a >= 0; a--) {
            var validRowID = (tableOtherItem.rows[a].cells[0].innerHTML);
            var CheckappId = document.getElementById("ddlappro_" + validRowID).value;
            var CheckdocId = document.getElementById("ddldoc_" + validRowID).value;
            if (RowNum != validRowID && app == CheckappId && doc == CheckdocId) {
                $("#divWarning").html("Duplication Error!.Approval can’t be duplicated in a hierarchy.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("ddlappro_" + RowNum).style.borderColor = "red";
                document.getElementById("ddlappro_" + RowNum).focus();
                document.getElementById("ddlappro_" + RowNum).value = "";
                document.getElementById("ddlappro_" + RowNum).value = "-Select-";
                return false;
             
            }
        }
      
            }
            return false;
        }
    </script>
    <script>
        function mainValidate() {

            var ret = true;
          

             var tbClientJobSheduling = '';
             tbClientJobSheduling = [];

             var tableOtherItem = document.getElementById("mainTable");
             var m = parseInt(tableOtherItem.rows.length) - 1;
             for (var a = m; a >= 0; a--) {
                 var validRowID = (tableOtherItem.rows[a].cells[0].innerHTML);
                 if (checkMainRow(validRowID) == false) {
                     ret = false;
                 }
                 else {

                     var dtlId = (tableOtherItem.rows[a].cells[1].innerHTML);
                    
                     var dl = (tableOtherItem.rows[a].cells[2].innerHTML);
                    
                     if (dl !=1) {
                         var doc = document.getElementById("ddldocI_" + validRowID).value;
                         var docNAME = document.getElementById("ddldoc_" + validRowID).value;
                         var appro = document.getElementById("ddlapproI_" + validRowID).value;
                         var sdate = document.getElementById("dte_1_a_" + validRowID).value;
                         var edate = document.getElementById("dte_1_" + validRowID).value;

                         var $add = jQuery.noConflict();
                         var client = JSON.stringify({
                             DTLID: "" + dtlId + "",
                             DOC: "" + doc + "",
                             APPRO: "" + appro + "",
                             SDATE: "" + sdate + "",
                             EDATE: "" + edate + ""
                         });
                         tbClientJobSheduling.push(client);
                        // alert(client);
                     }
                 }
               
                 if (document.getElementById("dte_1_a_" + validRowID).value == "") {
                     document.getElementById("dte_1_a_" + validRowID).style.borderColor = "red";
                     document.getElementById("dte_1_a_" + validRowID).focus();
                     ret = false;
                 }
                 if (document.getElementById("dte_1_" + validRowID).value == "") {
                     document.getElementById("dte_1_" + validRowID).style.borderColor = "red";
                     document.getElementById("dte_1_" + validRowID).focus();
                     ret = false;
                 }
               
                   
            
             if (sdate != "" && edate != "") {
                 var arrDateFromchk = sdate.split("-");
                 dateDateFromchk = new Date(arrDateFromchk[2], arrDateFromchk[1] - 1, arrDateFromchk[0]);
                 var arrDateTochk = edate.split("-");
                 dateDateTochk = new Date(arrDateTochk[2], arrDateTochk[1] - 1, arrDateTochk[0]);
                 if (dateDateFromchk > dateDateTochk) {
                     $("#divWarning").html("From date should not be greater than to date.");
                     $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                     });
                     $(window).scrollTop(0);
                     document.getElementById("dte_1_a_"+validRowID).style.borderColor = "Red";
                     document.getElementById("dte_1_"+validRowID).style.borderColor = "Red";
                     ret = false;
                 }
          
                
                  
                 }
                 if (document.getElementById("<%=ddldesg.ClientID%>").value == "--SELECT DESIGNATION--") {

                     document.getElementById("<%=ddldesg.ClientID%>").style.borderColor = "red";
                     document.getElementById("<%=ddldesg.ClientID%>").focus();
                     ret = false;
                 }
                 if (docNAME== "" ) {
                
                 document.getElementById("ddldoc_" + validRowID).style.borderColor = "red";
                 document.getElementById("ddldoc_" + validRowID).focus();
                 ret = false;
             }
             if (document.getElementById("ddlappro_" + validRowID).value == 0) {
                 document.getElementById("ddlappro_" + validRowID).style.borderColor = "red";
                 document.getElementById("ddlappro_" + validRowID).focus();
                 ret = false;
             }
             if (ret == false) {
                 $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                 $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                 });
                 $(window).scrollTop(0);
                 return false;
             }
         

             }

            if (ret == true) {
                //alert(client);
                $add("#cphMain_HiddenFieldMainData").val(JSON.stringify(tbClientJobSheduling));
                //subValidate();
            }
            return ret;
        }
    </script>



<!-----table_search------------>
<script>
    $(document).ready(function () {
        $("#myInput").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $("#myTable tr").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });
    });
</script>
<!-----table_search_closed------------>


<!---Start_date section--->
<script>
    function dte_m() {

        if (document.getElementById("cbx_dte").checked == true) {
            document.getElementById("dte_1").disabled = false;
        } else {
            document.getElementById("dte_1").disabled = true;
        }

    }
</script>

<script>
    function dte_m_1() {

        if (document.getElementById("cbx_dte1").checked == true) {
            document.getElementById("dte_1_a").disabled = false;
        } else {
            document.getElementById("dte_1_a").disabled = true;
        }

    }
</script>

<!---closed_date section--->


<!----tree_jquery---->


 <style>
         .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            width: 218px;
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
    </style>
</asp:Content>

