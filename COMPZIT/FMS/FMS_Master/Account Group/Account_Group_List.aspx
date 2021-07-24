<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="Account_Group_List.aspx.cs" Inherits="FMS_FMS_Master_Account_Group_Account_Group_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>

    <script>
        var $au = jQuery.noConflict();
        $au(function () {
            $au('#cphMain_ddlParentGroup').selectToAutocomplete1Letter();
        });
    </script>

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

/*.table-bordered > tbody > tr > td + td+td+td

{
    text-align:left;
}*/

               /*.table-bordered > tbody >tr > td 
              
               {

    text-align: left;

}*/

 </style>
    <script type="text/javascript">
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

                   
            document.getElementById("<%=ddlParentGroup.ClientID%>").focus();
          
              LoadEmployeeList();
          });

          function getdetails(href) {
              window.location = href;
              return false;
          }

          function CloseCancelView() {
              ezBSAlert({
                  type: "confirm",
                  messageText: "Do you want to close  without completing cancellation process?",
                  alertType: "info"
              }).done(function (e) {
                  if (e == true) {
                      $('#dialog_simple').modal('hide');

                      document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = "";
                 }
                 else {
                      $('#dialog_simple').modal('show');
                      $('#dialog_simple').on('shown.bs.modal', function () {
                          document.getElementById("txtCancelReason").focus();
                      });
                     return false;
                 }
             });
             return false;
          }
        function CancelNotPossible() {
            $noCon("#danger-alert").html("Sorry, cancellation denied. This account group is already selected somewhere or it is a confirmed account group!");
            $noCon("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        
        function ChngStsNotPossible() {
            $noCon("#danger-alert").html("Sorry, primary account group status cannot be changed!");
            $noCon("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="HiddenEnableDelete" runat="server" />
    <asp:HiddenField ID="HiddenEnableModify" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Account Group</li>
    </ol>

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
          <div class="alert alert-success" id="success-alert1" style="display: none; margin-left: 0%;margin-top: 2%; width: 98%;">
        <button type="button" class="close" data-dismiss="alert">x</button>
    </div>
     <div class="alert alert-danger" id="danger-alert1" style="display: none; margin-left: 1%;margin-top: 2%; width: 98%;">
        <button type="button" class="close" data-dismiss="alert">x</button>
    </div>
        <div class="content_area_container cont_contr">
            <div class="content_box1 cont_contr">
                <h1 class="h1_con">ACCOUNT GROUP LIST</h1>

                <div class="form-group fg2">
                    <label for="email" class="fg2_la1">Parent Group<span class="spn1"></span>:</label>
                    <asp:DropDownList ID="ddlParentGroup" Height="30px" Width="160px" class="form-control fg2_inp1 fg_chs2" runat="server" Style="cursor: pointer;">
                    </asp:DropDownList>
                </div>
                <div class="form-group fg2">
                    <label for="email" class="fg2_la1">Status<span class="spn1"></span>:</label>
                    <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1 fg_chs2" runat="server">
                        <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                        <asp:ListItem Text="All" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="fg2">
                   <label class="form1 mar_bo mar_tp">
                        <span class="button-checkbox">
                            <asp:CheckBox ID="cbxCnclStatus" Text="" class="hidden" runat="server" Checked="false" onclick="DisableEnter(event)" onkeydown="return DisableEnter(event)" />
                            <button type="button" class="btn-d" data-color="p"></button>
                        </span>
                         <p class="pz_s">Show Deleted Entries</p>
                    </label>
                </div>

                <div class="fg2">
                    <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <asp:Button ID="btnSearch" Style="cursor: pointer;" runat="server" class="submit_ser" OnClientClick="return LoadEmployeeList();" />
                </div>

                <div class="clearfix"></div>
                <div class="devider"></div>


        <table id="datatable_fixed_column" class="display table-bordered" cellspacing="0" width="100%">
          <thead class="thead1">
            <tr> 
              <th class="col-md-5 tr_l">Account Group <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                  <br />
                  <input type="text" class="tb_inp_1 tb_in" placeholder="Account Group" onkeydown="return DisableEnter(event)"/>
              </th>
              <th class="col-md-3 tr_l">Parent Group
                <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                <input type="text" class="tb_inp_1 tb_in" placeholder="Parent Group" onkeydown="return DisableEnter(event)"/>
              </th>
              <th class="col-md-1 tr_c">Status
                <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                <p class="nbsp1">&nbsp;</p>
              </th>
              <th class="col-md-2 tr_c">Actions
                <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                <p class="nbsp1">&nbsp;</p>
              </th>
            </tr>
          </thead>
                    <tbody>
                        <tr>
                            <td colspan="4" class="dataTables_empty">Loading details...</td>
                        </tr>
                    </tbody>
                </table>

                <div id="divAdd" onclick="location.href='AccountGroup.aspx'" class="add" runat="server" style="position: fixed; height: 26.5px; right: 0.7%; display: block">
                    <a href="AccountGroup.aspx" type="button" onclick="topFunction()" id="myBtn" title="Add New">
                        <i class="fa fa-plus-circle"></i>
                    </a>
                </div>



                <div id="divReport" class="table-responsive" runat="server" style="display: none;">
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
            </div>
        </div>
    </div>
   
           
<%--------------------------------View for error Reason--------------------------%>
            <!-- Modal1 -->
    <div class="modal fade" id="dialog_simple" tabindex="-1"  data-backdrop="static" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod1" role="document">
            <div class="modal-content">
                <div class="modal-header mo_hd1">
                    <h5 class="modal-title" id="H1">Reason for delete</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                     <div id="lblErrMsgCancelReason" class="al-box war">Warning Alert !!!</div>
                    <textarea id="txtCancelReason" placeholder="Write reason for delete" rows="6" class="text_ar1" onblur="RemoveTag('txtCancelReason')" onkeypress="return isTag(event)" onkeydown="textCounter(txtCancelReason,450)" onkeyup="textCounter(txtCancelReason,450)" style="resize: none;"></textarea>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-success" data-toggle="modal">SAVE</button>
                    <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>

<!-- Modal1 -->

      <script>
          //for search option
          var $NoConfi = jQuery.noConflict();
          var $NoConfi3 = jQuery.noConflict();

          function LoadEmployeeList() {
              var orgID = '<%= Session["ORGID"] %>';
              var corptID = '<%= Session["CORPOFFICEID"] %>';
              var EnableEdit = document.getElementById("<%=HiddenEnableModify.ClientID%>").value;
              var EnableDelete = document.getElementById("<%=HiddenEnableDelete.ClientID%>").value;
              var Status = document.getElementById("cphMain_ddlStatus").value;
              var ParentGrp = document.getElementById("<%=ddlParentGroup.ClientID%>").value;
              var CnclSts = 0;
              if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                  CnclSts = 1;
              }
              var responsiveHelper_datatable_fixed_column = undefined;
              var breakpointDefinition = {
                  tablet: 1024,
                  phone: 480
              };

              /* COLUMN FILTER  */
              var otable = $NoConfi3('#datatable_fixed_column').DataTable({

                  'bProcessing': false,
                  'bServerSide': true,
                  'sAjaxSource': 'data.ashx',
                 // "order": [[0, 'asc']],
                  "bDestroy": true,
                  "autoWidth": true,
                  "preDrawCallback": function () {
                      // Initialize the responsive datatables helper once.
                      if (!responsiveHelper_datatable_fixed_column) {
                          responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($NoConfi3('#datatable_fixed_column'), breakpointDefinition);
                      }
                  },
                  "rowCallback": function (nRow) {
                      responsiveHelper_datatable_fixed_column.createExpandIcon(nRow);
                  },
                  "drawCallback": function (oSettings) {
                      responsiveHelper_datatable_fixed_column.respond();
                  },
                  "fnServerParams": function (aoData) {
                      aoData.push({ "name": "ORG_ID", "value": orgID });
                      aoData.push({ "name": "CORPT_ID", "value": corptID });
                      aoData.push({ "name": "STATUS", "value": Status });
                      aoData.push({ "name": "CNCL_STS", "value": CnclSts });
                      aoData.push({ "name": "PARNT_GRP", "value": ParentGrp });
                      aoData.push({ "name": "ENABLEDIT", "value": EnableEdit });
                      aoData.push({ "name": "ENABLEDELETE", "value": EnableDelete });
                  },
                  "columnDefs": [
                       {
                           "targets": [0],
                           "className": "tr_l",
                           "visible": true
                       },
                        {
                            "targets": [1],
                            "className": "tr_l",
                            "visible": true
                        },
                             {
                                 "targets": [2],
                                 "visible": true
                             },
                      {
                          "targets": [3],
                          "visible": true
                      },
                  ],


              });


              // Apply the filter

              $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                  otable
                      .column($NoConfi(this).parent().index() + ':visible')
                      .search(this.value)
                      .draw();

              });
              /* END COLUMN FILTER */
          }

    </script>
    <script>
        function ChangeStatus(StrId, stsmode, cnclusrId) {
            if (cnclusrId == "") {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to change the status of this account group?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        var usrId = '<%= Session["USERID"] %>';

                        var Details = PageMethods.ChangeAccountStatus(StrId, stsmode,usrId, function (response) {
                            var SucessDetails = response;
                            if (SucessDetails == "success") {
                                window.location = 'Account_Group_List.aspx?InsUpd=StsCh';
                            }
                            else {
                                window.location = 'Account_Group_List.aspx?InsUpd=Error';
                            }
                        });
                    }
                });
                return false;
            }
        }
      
        function OpenCancelView(StrId)
        {
           
            ezBSAlert({
                type: "confirm",
              messageText: "Do you want to delete this account group",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                  var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                      document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                         var strCancelReason = "";
                         if (strCancelMust == 1) {
                             //cancl rsn must
                             document.getElementById('txtCancelReason').style.borderColor = "";
                             document.getElementById('txtCancelReason').value = "";
                             //new 
                             $('#dialog_simple').modal('show');
                             $('#dialog_simple').on('shown.bs.modal', function () {
                                 document.getElementById("txtCancelReason").focus();
                             });
                     

                         }
                         else {
                             DeleteByID(StrId, strCancelReason, strCancelMust);
                             $('#dialog_simple').modal('hide');
                         }
                         return false;

                     }
                     else {
                       return false;
                     }
                 });




                 return false;

        }
        function DeleteByID(strId, strCancelReason, strCancelMust) {
            var strUserID = '<%=Session["USERID"]%>';
                if (strId != "" && strUserID != '') {
                    // alert(strId); alert(strCancelReason); alert(strCancelMust); alert(strUserID);
                    var Details = PageMethods.CancelAccountGrp(strId, strCancelMust, strUserID, strCancelReason, function (response) {

                        var SucessDetails = response;
                        if (SucessDetails == "successcncl") {

                            window.location = 'Account_Group_List.aspx?InsUpd=Cncl';


                        }
                        else {
                            window.location = 'Account_Group_List.aspx?InsUpd=Error';
                        }
                    });
                }

                return false;
            }
            //validation when cancel process
            function ValidateCancelReason() {
                // replacing < and > tags

                var ret = true;
                document.getElementById("txtCancelReason").style.borderColor = "";
                var strCancelReason = document.getElementById("txtCancelReason").value;
                if (strCancelReason == "") {
                    document.getElementById("txtCancelReason").style.borderColor = "red";
                    document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
                    document.getElementById("txtCancelReason").focus();
                    $("div.war").fadeIn(200).delay(500).fadeOut(400);
                    return ret;
                }
                else {
                    strCancelReason = strCancelReason.replace(/(^\s*)|(\s*$)/gi, "");
                    strCancelReason = strCancelReason.replace(/[ ]{2,}/gi, " ");
                    strCancelReason = strCancelReason.replace(/\n /, "\n");
                    if (strCancelReason.length < "10") {
                        document.getElementById("lblErrMsgCancelReason").innerHTML = " Cancel reason should be minimum 10 characters";
                        document.getElementById("txtCancelReason").style.borderColor = "red";
                        document.getElementById("txtCancelReason").focus();
                        $("div.war").fadeIn(200).delay(500).fadeOut(400);
                        return ret;
                    }
                    else {

                    }
                }
                if (ret == true) {
                    var strId = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
                     var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                     DeleteByID(strId, strCancelReason, strCancelMust);
                     $('#dialog_simple').modal('hide');
                 }

                 return false;

             }
        function SuccessConfirmation() {
            $noCon("#success-alert").html("Account group inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();
            return false;
        }
        function SuccessUpdation() {
            $noCon("#success-alert").html("Account group updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();
            return false;
        }

        function SuccessCancelation() {
            $noCon("#success-alert").html("Account group deleted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();
            return false;

        }
        function SuccessStatusChange() {
            $noCon("#success-alert").html("Account group status changed successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();
            return false;
        }
    </script>
 

   
                




   
    
</asp:Content>

