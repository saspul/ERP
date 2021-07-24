<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="Payroll_Structure_list.aspx.cs" Inherits="Master_Payroll_Structure_master_Payroll_Structure_list" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
  

    <%--  <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>--%>
  
    <script src="/js/Common/Common.js"></script> 
  
<%-- <script src="../../js/New%20js/js/ajax.js"></script>--%>
   <%--<link href="/css/New css/pro_mng.css" rel="stylesheet" />--%>
   <%--  for giving pagination to the html table--%>
    

   <link href="../../css/New%20css/hcm_ns.css" rel="stylesheet" />

    
<link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i" rel="stylesheet"/>

    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>


    <style>
  .table-bordered>tbody>tr>td, .table-bordered>tbody>tr>th, .table-bordered>tfoot>tr>td, .table-bordered>tfoot>tr>th, .table-bordered>thead>tr>td, .table-bordered>thead>tr>th{padding:3px!important;}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">



     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
 
    <asp:HiddenField ID="hiddenenableadd" runat="server" />
    <asp:HiddenField ID="hiddenenablemodify" runat="server" />
    <asp:HiddenField ID="Hiddenenablecancel" runat="server" />
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />

    




<!---breadcrumb_section_started---->    
    <ol class="breadcrumb">
        <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_Hcm.aspx">HCM</a></li>
      <li class="active">Payroll Configuration</li>
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
          <h1 class="h1_con">Payroll Configuration</h1>

       
         <div class="form-group fg2">
              <label for="email" class="fg2_la1">Status:<span class="spn1">*</span></label>
              <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1 inp_mst" runat="server" >
                    <asp:ListItem Value="1">Active</asp:ListItem>
                  <asp:ListItem Value="2">Inactive</asp:ListItem>
                  <asp:ListItem Value="0">All</asp:ListItem>
                </asp:DropDownList>          
            </div>

            <div class="fg7_5 sa_fg2">
            <label class="form1 mar_bo mar_tp">
              <span class="button-checkbox">
                <button type="button" class="btn-d" data-color="p"></button>
                <asp:CheckBox ID="cbxCnclStatus" Text="" class="hidden" runat="server" Checked="false" onclick="DisableEnter(event)" onkeydown="return DisableEnter(event)" />
              </span>
              <p class="pz_s">Show Deleted Entries</p>
            </label>
          </div>

            <div class="fg2">
              <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
             <asp:Button ID="btnSearch" runat="server" class="submit_ser" OnClientClick="return LoadList();" />
              <!-- <button class="btn tab_but1 butn5"><i class="fa fa-search"></i> Search</button>   -->
            </div>
<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="devider"></div>
<!---=================section_devider============--->
        
       
       <%-- <div class="r_640">  
<%--        --%>
            <%--<table id="example" class="display table-bordered tbl_640" cellspacing="0" width="100%">
          <thead class="thead1">
            <tr>
              <th class="col-md-4 tr_l">Name
                <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i><br>
                <input type="text" class="tb_inp_1 tb_in" placeholder="Name" onkeydown="return DisableEnter(event)">
              </th>
              <th class="col-md-3 tr_l">Code
                <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i><br>
                <input type="text" class="tb_inp_1 tb_in" placeholder="Code" onkeydown="return DisableEnter(event)">
              </th>
              <th class="col-md-3 tr_l">Mode
                <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i><br>
                <input type="text" class="tb_inp_1 tb_in" placeholder="Mode" onkeydown="return DisableEnter(event)">
              </th>
              <th class="col-md-2">Actions
                <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
              </th>
            </tr>
          </thead>
            <tbody>
              <tr>
                <td class="tr_l">Name 1</td>
                <td class="tr_l">Code 1</td>
                <td class="tr_l">Mode 1</td>
              <td> 
                <div class="btn_stl1">
                  <div class="btn_stl1">
                    <button class="btn tab_but1 butn4 btn_sti" data-toggle="modal" data-target="#exampleModal_st" title="Change Status">
                      <i class="fa fa-times-circle"></i>
                    </button>
                  <button class="btn act_btn bn1 bt_e" data-toggle="modal" data-target="#exampleModal" title="Edit">
                    <i class="fa fa-edit"></i>
                  </button>
                  <button class="btn act_btn bn3" data-toggle="modal" data-target="#exampleModal" title="Delete">
                    <i class="fa fa-trash"></i>
                  </button>
                </div>

                <div class="btn_stl2"> 
                  <button class="btn act_btn bn4 bt_v" data-toggle="modal" data-target="#exampleModal" title="View">
                    <i class="fa fa-list-alt"></i> View
                  </button>
                  <button class="btn act_btn bn1 bt_e" data-toggle="modal" data-target="#exampleModal">
                    <i class="fa fa-edit"></i> Edit
                  </button>
                  <button class="btn act_btn bn3" data-toggle="modal" data-target="#exampleModal">
                    <i class="fa fa-trash"></i> Delete
                  </button>
                </div>

                <div class="btn_stl3">
                  <button class="btn act_btn bn4 bt_v" data-toggle="modal" data-target="#exampleModal"> View</button>
                  <button class="btn act_btn bn1 bt_e" data-toggle="modal" data-target="#exampleModal">Edit</button>
                  <button class="btn act_btn bn3" data-toggle="modal" data-target="#exampleModal">Delete</button>
                </div>
              </td>
              </tr>
              <tr>
                <td class="tr_l">Name 2</td>
                <td class="tr_l">Code 2</td>
                <td class="tr_l">Mode 2</td>
                <td> 
                <div class="btn_stl1">
                  <button class="btn tab_but1 butn1 btn_sta" data-toggle="modal" data-target="#exampleModal_st" title="" disabled="">
                      <i class="fa fa-check-circle "></i>
                    </button>
                  <button class="btn act_btn bn4 bt_v" data-toggle="modal" data-target="#exampleModal" title="View">
                    <i class="fa fa-list-alt"></i>
                  </button>
                  <button class="btn act_btn bn3" data-toggle="modal" data-target="#exampleModal" title="Delete">
                    <i class="fa fa-trash"></i>
                  </button>
                </div>

                <div class="btn_stl2"> 
                  <button class="btn act_btn bn4 bt_v" data-toggle="modal" data-target="#exampleModal" title="View">
                    <i class="fa fa-list-alt"></i> View
                  </button>
                  <button class="btn act_btn bn1 bt_e" data-toggle="modal" data-target="#exampleModal">
                    <i class="fa fa-edit"></i> Edit
                  </button>
                  <button class="btn act_btn bn3" data-toggle="modal" data-target="#exampleModal">
                    <i class="fa fa-trash"></i> Delete
                  </button>
                </div>

                <div class="btn_stl3">
                  <button class="btn act_btn bn4 bt_v" data-toggle="modal" data-target="#exampleModal"> View</button>
                  <button class="btn act_btn bn1 bt_e" data-toggle="modal" data-target="#exampleModal">Edit</button>
                  <button class="btn act_btn bn3" data-toggle="modal" data-target="#exampleModal">Delete</button>
                </div>
              </td>
              </tr>

              <tr>
                <td class="tr_l">Name 3</td>
                <td class="tr_l">Code 3</td>
                <td class="tr_l">Mode 3</td>
                <td> 
                <div class="btn_stl1">
                    <button class="btn tab_but1 butn4 btn_sti" data-toggle="modal" data-target="#exampleModal_st" title="" disabled="">
                      <i class="fa fa-times-circle"></i>
                    </button>
                  <button class="btn act_btn bn1 bt_e" data-toggle="modal" data-target="#exampleModal" title="Edit">
                    <i class="fa fa-edit"></i>
                  </button>
                  <button class="btn act_btn bn3" data-toggle="modal" data-target="#exampleModal" title="Delete" disabled="">
                    <i class="fa fa-trash"></i>
                  </button>
                </div>

                <div class="btn_stl2"> 
                  <button class="btn act_btn bn4 bt_v" data-toggle="modal" data-target="#exampleModal" title="View">
                    <i class="fa fa-list-alt"></i> View
                  </button>
                  <button class="btn act_btn bn1 bt_e" data-toggle="modal" data-target="#exampleModal">
                    <i class="fa fa-edit"></i> Edit
                  </button>
                  <button class="btn act_btn bn3" data-toggle="modal" data-target="#exampleModal">
                    <i class="fa fa-trash"></i> Delete
                  </button>
                </div>

                <div class="btn_stl3">
                  <button class="btn act_btn bn4 bt_v" data-toggle="modal" data-target="#exampleModal"> View</button>
                  <button class="btn act_btn bn1 bt_e" data-toggle="modal" data-target="#exampleModal">Edit</button>
                  <button class="btn act_btn bn3" data-toggle="modal" data-target="#exampleModal">Delete</button>
                </div>
              </td>
              </tr>

              <tr>
                <td class="tr_l">Name 4</td>
                <td class="tr_l">Code 4</td>
                <td class="tr_l">Mode 4</td>
                <td> 
                <div class="btn_stl1">
                  <button class="btn tab_but1 butn1 btn_sta" data-toggle="modal" data-target="#exampleModal_st" title="Change Status">
                      <i class="fa fa-check-circle "></i>
                    </button>
                  <button class="btn act_btn bn4 bt_v" data-toggle="modal" data-target="#exampleModal" title="View">
                    <i class="fa fa-list-alt"></i>
                  </button>
                  <button class="btn act_btn bn3" data-toggle="modal" data-target="#exampleModal" title="Delete">
                    <i class="fa fa-trash"></i>
                  </button>
                </div>

                <div class="btn_stl2"> 
                  <button class="btn act_btn bn4 bt_v" data-toggle="modal" data-target="#exampleModal" title="View">
                    <i class="fa fa-list-alt"></i> View
                  </button>
                  <button class="btn act_btn bn1 bt_e" data-toggle="modal" data-target="#exampleModal">
                    <i class="fa fa-edit"></i> Edit
                  </button>
                  <button class="btn act_btn bn3" data-toggle="modal" data-target="#exampleModal">
                    <i class="fa fa-trash"></i> Delete
                  </button>
                </div>

                <div class="btn_stl3">
                  <button class="btn act_btn bn4 bt_v" data-toggle="modal" data-target="#exampleModal"> View</button>
                  <button class="btn act_btn bn1 bt_e" data-toggle="modal" data-target="#exampleModal">Edit</button>
                  <button class="btn act_btn bn3" data-toggle="modal" data-target="#exampleModal">Delete</button>
                </div>
              </td>
              </tr>
             
            </tbody>
          </table>--%>

             <div id="divPagingTable_processing" style="display: none;">Processing...</div>
      <div id="divPagingTableContainer"></div>
      <div id="divReport" runat="server" class="r_800"></div>

             <div class="clearfix"></div>

        </div>
      </div>


<!---inner_content_sections area_closed--->

<!---frame_border_area_closed---->
        </div>
      </div>
    </div>

    
<!---print_button--->
<a href="#" type="button" class="print_o" title="Print page">
  <i class="fa fa-print"></i>
</a>
<!---print_button_closed--->


<!---add_button--->
<a href="Payroll_Structure_Master.aspx" type="button" onclick="topFunction()" id="myBtn" title="Add New">
<i class="fa fa-plus-circle"></i>
</a>
<!---add_button_closed--->


 <button id="print" onclick="return PrintClick();" class="print_o" title="Print page"><i class="fa fa-print"></i></button>



    <div class="modal fade" id="dialog_simple" tabindex="-1" data-backdrop="static" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
                    <button type="button" id="btnCnclRsn" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>

 <script>

     //--------------------------------------Pagination--------------------------------------


     $(document).ready(function () {
          
         var  strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
            //  alert(strddlStatus);
        

            Load_dt();
            getdata(1);
        });



     function LoadList() {
         var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;

          getdata(1);
          return false;
     }


     //Efficiently Paging Through Large Amounts of Data
     var intOrderByColumn = 1;
     var intOrderByStatus = 0;
     var intToltalSearchColumns = 0;

     //------------Load column filters and table----------

     function Load_dt() {


         var strPagingTable = '';
         strPagingTable += '<div id="divHeader_dt"></div>';
         strPagingTable += '<div class="r_800"><table id="tblPagingTable" class="display table-bordered pro_tab1 tbl_800" style="width:100%;">';
         strPagingTable += '<thead class="thead1"><tr id="thPagingTable_SearchColumns"></tr></thead>';
         strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
        // strPagingTable += '<tfoot id="trPagingTableFoot"></tfoot>';
         strPagingTable += '</table></div>';

         $("#divPagingTableContainer").html(strPagingTable);

         intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;


         var url = "Payroll_Structure_list.aspx/LoadStaticDatafordt";
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
         //   alert("f");
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
         var strUserId = '<%= Session["USERID"] %>';

         var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
         var strCancelStatus = 0;
         if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
              strCancelStatus = 1;
         }

         var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
         var addenable = document.getElementById("<%=hiddenenableadd.ClientID%>").value;
         var modifyenable = document.getElementById("<%=hiddenenablemodify.ClientID%>").value;
         var cancelenable = document.getElementById("<%=Hiddenenablecancel.ClientID%>").value;

        
         //   alert(nature);
        
             var url = "Payroll_Structure_list.aspx/GetData";
             var objData = {};
             objData.OrgId = strOrgId;
             objData.addenable = addenable;
             objData.modifyenable = modifyenable;
             objData.cancelenable = cancelenable;
             objData.CorpId = strCorpId;
             objData.Userid = strUserId;
             objData.ddlStatus = strddlStatus;
         //  objData.nature = nature;
             objData.CancelStatus = strCancelStatus;
             objData.PageNumber = strPageNumber;
             objData.PageMaxSize = strPageSize;
             objData.strCommonSearchTerm = strCommonSearchString;
             objData.OrderColumn = intOrderByColumn;
             objData.OrderMethod = intOrderByStatus;
             objData.strInputColumnSearch = strInputColumnSearch;
            // alert("bb");

             $.ajax({

                 type: 'POST',
                 data: JSON.stringify(objData),
                 dataType: 'json',
                 contentType: "application/json; charset=utf-8",
                 url: url,
                 success: function (result) {
                     $('#tblPagingTable tbody').html(result.d[0]);
                     $('#tblPagingTable tfoot').html(result.d[1]);
                     $("#cphMain_divReport").html(result.d[2]);//datatable
                     //$("#lblNumRec").html("Total number of records: " + result.d[3]);

                     var intToltalColumns = document.getElementById('tblPagingTable').rows[1].cells.length;
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
         //  alert(inputSearchTerms);
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
     var typingTimer;                //timer identifier
     var doneTypingInterval = 1000;  //time in ms (5 seconds)

     function SettypingTimer(evt) {
         evt = (evt) ? evt : window.event;
         var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
         if (keyCodes == 13 || keyCodes == 9) {
             return false;
         }
         //on keyup, start the countdown
         clearTimeout(typingTimer);
         typingTimer = setTimeout(doneTyping, doneTypingInterval);
     }

     //user is "finished typing," do something
     function doneTyping() {
         //do something
         getdata(1);
     }




     function PrintClick() {

         var strOrgId = '<%= Session["ORGID"] %>';
         var strCorpId = '<%= Session["CORPOFFICEID"] %>';
         var strUserId = '<%= Session["USERID"] %>';

        //alert("a");

         var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
         var strCancelStatus = 0;
         if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
             strCancelStatus = 1;
         }

         // alert("a");
         if (strCorpId != "" && strCorpId != null && strOrgId != "" && strOrgId != null) {
                 $.ajax({
                     type: "POST",
                     async: false,
                     contentType: "application/json; charset=utf-8",
                     url: "Payroll_Structure_list.aspx/PrintList",
                     data: '{strOrgId: "' + strOrgId + '",strCorpId: "' + strCorpId + '",strddlStatus: "' + strddlStatus + '",strCancelStatus: "' + strCancelStatus + '",strUserId: "' + strUserId + '"}',
                     dataType: "json",
                     success: function (data) {
                         if (data.d != "") {
                             window.open(data.d, '_blank');
                         }
                         else {
                             Error();
                         }
                     }
                 });
             }
             else {
                 window.location = '/Security/Login.aspx';
             }
             return false;
         }


     


     function OpenCancelView(StrId) {

        
        
        // alert("b");
         
     
         ezBSAlert({
             type: "confirm",
             messageText: "Do you want to cancel this payroll ?",
             alertType: "info"
             
         }).done(function (e) {
             if (e == true) {
                 var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
                        //cancl rsn must
                  
                        document.getElementById("lblErrMsgCancelReason").style.display = "none";

                        document.getElementById("txtCancelReason").style.borderColor = "";
                        document.getElementById("txtCancelReason").value = "";
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
     






     function ValidateCancelReason() {
         var ret = true;
         document.getElementById("lblErrMsgCancelReason").style.display = "none";
         document.getElementById("txtCancelReason").style.borderColor = "";

         var strCancelReason = document.getElementById("txtCancelReason").value;
         if (strCancelReason == "") {
             document.getElementById("txtCancelReason").style.borderColor = "red";
             document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
             document.getElementById("lblErrMsgCancelReason").style.display = "";
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
                 document.getElementById("lblErrMsgCancelReason").style.display = "";
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



     function DeleteByID(strId, strCancelReason, strCancelMust) {
         var strUserID = '<%=Session["USERID"]%>';
         var strOrgIdID = '<%=Session["ORGID"]%>';
         var strCorpID = '<%=Session["CORPOFFICEID"]%>';

         if (strId != "" && strUserID != '') {
             var Details = PageMethods.CancelReason(strId, strCancelMust, strUserID, strCancelReason, strOrgIdID, strCorpID, function (response) {

                 var SucessDetails = response;
                 if (SucessDetails == "successcncl") {

                     // window.location = 'Payroll_Structure_List.aspx?InsUpd=Cncl';
                     getdata(1);

                     SuccessCancelation();
                 }
                 else {
                     Error();
                 }
             });
         }

         return false;
     }





     function ChangeStatus(strId, Status) {

       //  alert("B");
         ezBSAlert({
             type: "confirm",
             messageText: "Do you want to change the status of the Payroll?",
             alertType: "info"
         }).done(function (e) {
             if (e == true) {
                 if (strId != "") {
                     var Details = PageMethods.ChangeStatus(strId, Status, function (response) {

                         var SucessDetails = response;
                         if (SucessDetails == "successchng") {

                             //     window.location = 'Payroll_Structure_List.aspx?InsUpd=Sts';
                             getdata(1);

                             SuccessStatusChng();
                         }
                         else {
                             Error();
                         }
                     });
                 }
                 return false;

             }
             return false;

         });
         return false;
     }






     function SuccessInsertion() {
         $("#success-alert").html("Payroll inserted successfully.");
         $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
         });
         return false;
     }

     function SuccessUpdation() {
         $("#success-alert").html("Payroll updated successfully.");
         $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
         });
         return false;
     }

     function SuccessCancelation() {
         $("#success-alert").html("Payroll cancelled successfully.");
         $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
         });
         return false;
     }

     function SuccessStatusChng() {
         $("#success-alert").html("Payroll status changed successfully.");
         $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
         });
         return false;
     }

     function Error() {
         $("#danger-alert").html("Some error occured!");
         $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
         });
         return false;
     }


     function alreadys() {
         $("#danger-alert").html("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
         $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
         });
         return false;
     }
     </script>







    
<script>
    $(document).ready(function () {
        $("#hide").click(function () {
            $("p").hide();
        });
        $("#show").click(function () {
            $("p").show();
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(".slide-toggle").click(function () {
            $(".content_sec1").animate({
                width: "18%"
            });
        });
    });

</script>

<!--searchbox_list_script_opened------->

<script>
    function myFunction() {
        var input, filter, ul, li, a, i;
        input = document.getElementById("myInput");
        filter = input.value.toUpperCase();
        ul = document.getElementById("myUL");
        li = ul.getElementsByTagName("li");
        for (i = 0; i < li.length; i++) {
            a = li[i].getElementsByTagName("a")[0];
            if (a.innerHTML.toUpperCase().indexOf(filter) > -1) {
                li[i].style.display = "";
            } else {
                li[i].style.display = "none";
            }
        }
    }
</script>

<!----checkbox_started--->
<%--<script type="text/javascript">
    $(function () {
        $('.button-checkbox').each(function () {

            // Settings
            var $widget = $(this),
                $button = $widget.find('button'),
                $checkbox = $widget.find('input:checkbox'),
                color = $button.data('color'),
                settings = {
                    on: {
                        icon: 'fa fa-check-square-o'
                    },
                    off: {
                        icon: 'fa fa-square-o gly2'
                    }
                };

            // Event Handlers
            $button.on('click', function () {
                $checkbox.prop('checked', !$checkbox.is(':checked'));
                $checkbox.triggerHandler('change');
                updateDisplay();
            });
            $checkbox.on('change', function () {
                updateDisplay();
            });

            // Actions
            function updateDisplay() {
                var isChecked = $checkbox.is(':checked');

                // Set the button's state
                $button.data('state', (isChecked) ? "on" : "off");

                // Set the button's icon
                $button.find('.state-icon')
                    .removeClass()
                    .addClass('state-icon ' + settings[$button.data('state')].icon);

                // Update the button's color
                if (isChecked) {
                    $button
                        .removeClass('btn-d')
                        .addClass('btn-' + color + ' active');
                }
                else {
                    $button
                        .removeClass('btn-' + color)
                        .addClass('btn-d' + ' active');
                }
            }

            // Initialization
            function init() {

                updateDisplay();

                // Inject the icon if applicable
                if ($button.find('.state-icon').length == 0) {
                    $button.prepend('<i class="state-icon ' + settings[$button.data('state')].icon + '"></i> ');
                }
            }
            init();
        });
    });

</script>
<!--checkbox_closed-->

<script>
    //function openCity(evt, cityName) {
    //    var i, tabcontent, tablinks;
    //    tabcontent = document.getElementsByClassName("tab2content");
    //    for (i = 0; i < tabcontent.length; i++) {
    //        tabcontent[i].style.display = "none";
    //    }
    //    tablinks = document.getElementsByClassName("tablinks");
    //    for (i = 0; i < tablinks.length; i++) {
    //        tablinks[i].className = tablinks[i].className.replace(" active", "");
    //    }
    //    document.getElementById(cityName).style.display = "block";
    //    evt.currentTarget.className += " active";
    //}

    // Get the element with id="defaultOpen" and click on it
    document.getElementById("defaultOpen").click();
</script>--%>


<%--<script type="text/javascript">
    $(function () {
        $("#datepicker").datepicker({
            autoclose: true,
            todayHighlight: true
        }).datepicker('update', new Date());
    });
</script>
<script type="text/javascript">
    $(function () {
        $("#datepicker1").datepicker({
            autoclose: true,
            todayHighlight: true
        }).datepicker('update', new Date());
    });
</script>
<script type="text/javascript">
    $(function () {
        $("#datepicker2").datepicker({
            autoclose: true,
            todayHighlight: true
        }).datepicker('update', new Date());
    });
</script>
<script type="text/javascript">
    $(function () {
        $("#datepicker3").datepicker({
            autoclose: true,
            todayHighlight: true
        }).datepicker('update', new Date());
    });
</script>
<script type="text/javascript">
    $(function () {
        $("#datepicker4").datepicker({
            autoclose: true,
            todayHighlight: true
        }).datepicker('update', new Date());
    });
</script>--%>
<!--date_picker--->

<%--<link href="../date_pick/datepicker.css" rel="stylesheet" type="text/css" /><!-- 
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script> -->
<script src="../date_pick/datepicker.js"></script>--%>

<!---date_picker_closed-->

<!--------tooltips------------>
<%--<script>
    $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });
</script>

<script>
    $(document).ready(function () {
        $('[data-toggle="tooltip1"]').tooltip();
    });
</script>

<!--add new div---->
<script>
    $(document).ready(function () {
        $("#btx1").click(function () {
            $("p").append(" <b>Appended text</b>.");
        });
    });
</script>--%>

<%--<!--button_click_disable --->
<script>
    function myFunct() {
        document.getElementById("myinpb").disabled = false;
        document.getElementById("myinpc").disabled = true;
        document.getElementById("myinpc1").disabled = true;
        document.getElementById("myinpc2").disabled = true;
        document.getElementById("myinpc3").disabled = true;
    }
</script>--%>

<script>
    function mysave() {
        var x = document.getElementById("mysav");
        if (x.style.display === "block") {
            x.style.display = "none";
        } else {
            x.style.display = "block";
        }
    }
</script>

<script>
    function issue_chk() {
        var x = document.getElementById("is_chk");
        if (x.style.display === "block") {
            x.style.display = "none";
        } else {
            x.style.display = "block";
        }
    }
</script>

<!--save_pop up_open-->
<script>
    function opensave() {
        document.getElementById("mySave").style.width = "140px";
    }

    function closesave() {
        document.getElementById("mySave").style.width = "0px";
    }
</script>
<!--save_pop up_closed-->

<!----hide/Show_section---->
<script>
    $(document).ready(function () {
        $("#hide").click(function () {
            $(".c1h").hide();
        });
        $("#show").click(function () {
            $(".c1h").show();
        });
    });
</script>

<!----hide/Show_section2---->
<script>
    $(document).ready(function () {
        $("#hide").click(function () {
            $(".c2h").hide();
        });
        $("#show1").click(function () {
            $(".c2h").show();
        });
    });
</script>

<!-----Enable_disable script--->
<script>
    $(document).ready(function () {
        $(".bu1").click(function () {
            $("#mySe1").toggle();
        });
    });
</script>
<script>
    $(document).ready(function () {
        $(".bu").click(function () {
            $("#mySe").toggle();
        });
    });
</script>
<!-----Enable_disable script_closed--->

<!------hide and visible div--->
<script>
    function sel1() {
        var x = document.getElementById('sel');
        if (x.style.display === 'none') {
            x.style.display = 'block';
        } else {
            x.style.display = 'none';
        }
    }
</script>
<!------hide and visible div_closed--->


<!-----table_sec_fixed--->
<script type="text/javascript">
    // requires jquery library
    jQuery(document).ready(function () {
        jQuery(".main-table").clone(true).appendTo('#table-scroll').addClass('clone');
    });

</script>
</asp:Content>

