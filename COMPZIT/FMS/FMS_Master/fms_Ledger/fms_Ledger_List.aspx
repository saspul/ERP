<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Ledger_List.aspx.cs" Inherits="FMS_FMS_Master_fms_Ledger_fms_Ledger_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>

    <script>
        var $au = jQuery.noConflict();
        $au(function () {
            $au('#cphMain_ddlAccountGrp').selectToAutocomplete1Letter();
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

 </style>
    <script type="text/javascript">
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            var cnclSts = '<%= Session["CANCEL_STS"] %>';
            if (cnclSts != '') {
                if (cnclSts == 'successcncl') {
                    SuccessClose();
                }
                else if (cnclSts == 'UpdCancl') {
                    SuccessDeleted();
                }
                else if (cnclSts == 'fail') {
                    SuccessError();
                }
            }
            
        });
        var $NoConfi = jQuery.noConflict();
        var $NoConfi3 = jQuery.noConflict();
       
        function SuccessUpdMsg() {

            $noCon("#success-alert").html("Ledger details updated successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessMsg() {

            $noCon("#success-alert").html("Ledger details inserted successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        </script>









<script>

    //--------------------------------------Pagination--------------------------------------

    $(document).ready(function () {
        Load_dt();
        getdata(1);
    });

    function LoadList() {
        getdata(1);
        return false;
    }

    //Efficiently Paging Through Large Amounts of Data
    var intOrderByColumn = 0;
    var intOrderByStatus = 0;
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

        var url = "/FMS/FMS_Master/fms_Ledger/fms_Ledger_List.aspx/LoadStaticDatafordt";//path specified
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
                alert("error");
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

        //if (strOrgId == "" || strCorpId == "") {
        //    window.location.href = "/Default.aspx";
        //    return false;
        //}

        var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;

        var strddlAccountGrp = document.getElementById("<%=ddlAccountGrp.ClientID%>").value;

        var strCancelStatus = 0;
        if (document.getElementById("<%=CbxCnclStatus.ClientID%>").checked == true) {
            strCancelStatus = 1;
        }

        strEnableModify = document.getElementById("<%=HiddenRoleEdit.ClientID%>").value;
        strEnableCancel = document.getElementById("<%=hiddenEnableCancl.ClientID%>").value;


        var url = "/FMS/FMS_Master/fms_Ledger/fms_Ledger_List.aspx/GetData";
        var objData = {};
        objData.OrgId = strOrgId;
        objData.CorpId = strCorpId;
        objData.ddlStatus = strddlStatus;
        objData.ddlAccountGrp = strddlAccountGrp;
        objData.CancelStatus = strCancelStatus;
        objData.EnableModify = strEnableModify;
        objData.EnableCancel = strEnableCancel;
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
            url: "/FMS/FMS_Master/fms_Ledger/fms_Ledger_List.aspx/GetData",
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
                alert("error");
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

        //Efficiently Paging Through Large Amounts of Data

        //setup before functions
    var typingTimer;              //timer identifier
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

        //$("th i").click(function () {
        //    alert();
        //});

        //$('.pull-right hed_fa').click(function () {
        //    alert("1  " + $(this).hasClass('fa fa-sort')); alert("2  " + $(this).hasClass('fa fa-caret-up')); alert("3  " + $(this).hasClass('fa fa-caret-down'));
        //    if ($(this).hasClass('fa fa-sort') == true) {
        //        $(this).addClass('fa fa-caret-up');
        //    }
        //    else if ($(this).hasClass('fa fa-caret-up') == true) {
        //        $(this).addClass('fa fa-caret-down');
        //    }
        //    else {
        //        $(this).addClass('fa fa-sort');
        //    }
        //});

        //--------------------------------------Pagination--------------------------------------

    </script>
           












</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>




    <asp:HiddenField ID="hiddenEditID" runat="server" />
    <asp:HiddenField ID="hiddenViewID" runat="server" />
    <asp:HiddenField ID="hiddenCnclrsnMust" runat="server" />
    <asp:HiddenField ID="hiddenDeleteID" runat="server" />
    <asp:HiddenField ID="HiddenRoleEdit" runat="server" />
    <asp:HiddenField ID="HiddenRoleAllDiv" runat="server" />
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="Hiddencnclsts" runat="server" />
    <asp:HiddenField ID="Hiddencncl" runat="server" />
    <asp:HiddenField ID="hiddenEnableCancl" runat="server" />
    <asp:HiddenField ID="HiddensessionState" runat="server" />
    <asp:HiddenField ID="hiddenMemorySize" runat="server" />
    <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
    <asp:HiddenField ID="hiddenNext" runat="server" />
    <asp:HiddenField ID="hiddenPrevious" runat="server" />
    <asp:Button ID="btnEdit" runat="server" Text="Button" style="display:none"/>

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

<ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Ledger</li>
  </ol>
     <div id="divAdd" runat="server">
                    <a href="fms_Ledger.aspx" type="button" onclick="topFunction()" id="myBtn" title="Add New">
                        <i class="fa fa-plus-circle"></i>
                    </a>
                </div>
	<div class="content_sec2 cont_contr">
		<div class="content_area_container cont_contr">	
      <div class="content_box1 cont_contr">
        <h1 class="h1_con">Ledger</h1>

          <div class="form-group fg5">
            <label for="email" class="fg2_la1">Account Group<span class="spn1"></span>:</label>
               <asp:DropDownList ID="ddlAccountGrp" class="form-control fg2_inp1 fg_chs2" runat="server" Style="cursor: pointer;">
               </asp:DropDownList>
          </div>

              <div class="form-group fg8">
              <label for="email" class="fg2_la1">Status<span class="spn1"></span>:</label>
               <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1 fg_chs2" runat="server">
                        <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                        <asp:ListItem Text="All" Value="2"></asp:ListItem>
                    </asp:DropDownList>        
            </div>

             <div class="form-group fg5">
              <label class="form1 mar_bo mar_tp">
                <span class="button-checkbox">
                  <asp:CheckBox ID="CbxCnclStatus" Text="" class="hidden" runat="server" Checked="false" onclick="DisableEnter(event)" onkeydown="return DisableEnter(event)" />
                  <button type="button" class="btn-d" data-color="p"></button>
                </span>
                <p class="pz_s">Show Deleted Entries</p>
              </label>
             </div>

              <div class="fg8">
                <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
               <asp:Button ID="btnCnclSearch" Style="cursor: pointer;" runat="server" class="submit_ser" OnClick="btnCnclSearch_Click " OnClientClick="return LoadList();" /> 
              </div>

           <div runat="server" id="tblSearch">
              <div class="fg7 pull-right">
                <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <asp:Button ID="btnNext" class="btn tab_but1 btn_sw" runat="server" Text="Show Next 500 Records" OnClick="btnNext_Click" style="display:none;" />
              </div>
               <div class="fg7 pull-right">
                <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <asp:Button ID="btnPrevious" class="btn tab_but1 btn_sw" runat="server" Text="Show Previous 500 Records" OnClick="btnPrevious_Click" style="display:none;"  />
              </div>
          </div>

              <div class="clearfix"></div>

              <div class="devider"></div>



       <!----table---->
       <div id="divPagingTable_processing" style="display: none;">Processing...</div>
       <div id="divPagingTableContainer"></div>
       <div id="divReport" runat="server" class="tab_res"></div>
       <!----table---->

          

  </div><!--content_container_closed------>

<!----frame_closed section to footer script section--->
</div>
      

<!-------working area_closed---->

</div>

 <%--------------------------------View for error Reason--------------------------%>
            <!-- Modal1 -->
    <div class="modal fade" id="dialog_simple" tabindex="-1" role="dialog" data-backdrop="static"  aria-labelledby="exampleModalLabel" aria-hidden="true">
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
                    <textarea id="txtCancelReason" placeholder="Write reason for delete" rows="6" class="text_ar1"  onblur="RemoveTag('txtCancelReason')" onkeypress="return isTag(event)" onkeydown="textCounter(txtCancelReason,450)" onkeyup="textCounter(txtCancelReason,450)" style="resize: none;"></textarea>
                </div>
                <div class="modal-footer mo_ft1">
                    <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-success" data-toggle="modal">SAVE</button>
                    <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>

<!-- Modal1 -->   
    <script>

        function SuccessError() {
            $noCon("#danger-alert").html("Some error occured!.");
            $noCon("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            '<%Session["CANCEL_STS"] = "' + null + '"; %>';
            return false;
        }
        function SuccessDeleted() {
            $noCon("#danger-alert").html("This action is  denied! This ledger is already cancelled .");
            $noCon("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            '<%Session["CANCEL_STS"] = "' + null + '"; %>';
            return false;
        }
        function SuccessClose() {
            var ret = false;
            $noCon("#success-alert").html("Account deleted successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

            });
            '<%Session["CANCEL_STS"] = "' + null + '"; %>';
            return false;
        }
        function getdetails(href) {
            window.location = href;
            return false;
        }

        function OpenCancelView(StrId) {

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
                        $('#dialog_simple').modal('show')
                        $('#dialog_simple').on('shown.bs.modal', function () {
                            document.getElementById("txtCancelReason").focus();
                        });


                    }
                    else {
                        DeleteByID(StrId, strCancelReason, strCancelMust);
                        $('#dialog_simple').modal('hide')
                    }
                    return false;

                }
                else {
                    return false;
                }
            });




            return false;

        }
        function OpenCancelBlock() {
            $noCon("#danger-alert").html("Sorry, cancellation denied. This ledger is already selected somewhere!.");
            $noCon("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }

        function DeleteByID(strId, strCancelReason, strCancelMust) {

            var strUserID = '<%=Session["USERID"]%>';

            if (strId != "" && strUserID != '') {
                var Details = PageMethods.CancelMemoReason(strId, strCancelMust, strUserID, strCancelReason, function (response) {

                    var SucessDetails = response;

                    window.location = "fms_Ledger_List.aspx";
                });
            }

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
                    $('#dialog_simple').modal('show')
                    $('#dialog_simple').on('shown.bs.modal', function () {
                        document.getElementById("txtCancelReason").focus();
                    });
                      return false;
                  }
              });
              return false;
          }
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
    </script>
</asp:Content>

