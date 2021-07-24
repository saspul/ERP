<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Notice_Period_Allocation.aspx.cs" Inherits="HCM_HCM_Master_hcm_Exit_Management_hcm_Notice_Period_Allocation_hcm_Notice_Period_Allocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
            <script src="/JavaScript/jquery-1.8.3.min.js"></script>


</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server"> 

    <asp:HiddenField ID="hiddenFieldDesgTypId" runat="server" />
    <asp:HiddenField ID="hiddenFieldDesgContrl" runat="server" />
    
    
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    






            <div id="divMessageArea" style="display: none">
                 <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div class="cont_rght" >

        


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <img src="/Images/BigIcons/Open_Leave_Alloc.png" style="vertical-align: middle;" /> Notice Period Allocation
        </div>          
        <div style="width:98%;border: 1px solid #065757;margin-top: 1%;background:#f4f6f0;">        
            </div>        
        <br />    
    

       
          <div id="divNoticePeriodAllocation" class="widget-body no-padding dataTables_wrapper" style="margin-top: 0.5%;width: 100%;margin-left:0.2%;">
            <table id="datatable_fixed_column" class="table table-striped table-bordered" width="100%" style="font-family: Calibri;">
                <thead>
                    <tr class="SearchRow" >
                         <th class="hasinput" style="width: 11.25%">
                            <input id="empid" type="text" class="form-control" placeholder="DESIGNATION" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 11.25%">
                            <input  type="text" class="form-control" placeholder="NOTICE PERIOD (DAYS)" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 11.25%">
                            <input  type="text" class="form-control" placeholder="STATUS" onkeydown="return DisableEnter(event)" /></th>                                                                      
                        <th class="hasinput" style="width: 5%"></th>
                    </tr>
                    <tr>
                        <th data-class="expand">DESIGNATION</th>
                        <th data-class="expand">NOTICE PERIOD (DAYS)</th>
                        <th data-class="expand">STATUS</th>
                        <th data-class="expand">ACTION</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td colspan="10" class="dataTables_empty">Loading details...</td>
                    </tr>
                </tbody>
            </table>
        </div>                                                                 
    </div>


     <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    

     <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />


    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script> 
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>  
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>


        <script type="text/javascript">
            $(window).load(function () {
                LoadDesignationList();
            });
    </script>


    <script>


        function SaveNoticePeriod(NoticePrdId, strDesignationId, UserId, OrgId, CorpId, Msg, RowCount)
        {
            ret = true;
            document.getElementById("NoticeDays_" + RowCount).style.borderColor = "";
            if (document.getElementById("NoticeDays_" + RowCount).value == "") {
                document.getElementById("NoticeDays_" + RowCount).style.borderColor = "red";
                document.getElementById("NoticeDays_" + RowCount).focus();
                ret = false;

            }
                                  
            if (ret == true) {

                var strStatus = 0;
                if (document.getElementById("cbxStatus_" + RowCount).checked == true) {
                    strStatus = 1;
                }
                var strDays = document.getElementById("NoticeDays_" + RowCount).value;

                var objData = {};

                objData.StrNoticePrdId = NoticePrdId; //For Update 
                objData.strDesignationId = strDesignationId;
                objData.strStatus = strStatus;
                objData.strDays = strDays;
                objData.UserId = UserId;
                objData.OrgId = OrgId;
                objData.CorpId = CorpId;

                $.ajax({
                    type: "POST",
                    url: "hcm_Notice_Period_Allocation.aspx/Insert_Notice_Period_Details",
                    data: JSON.stringify(objData),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d == "success") {
                            if (Msg == "INS") {
                                SuccessConfirmation();
                            }
                            else {
                                SuccessUpdation();
                            }
                            LoadDesignationList();
                        }
                        else {
                            alert("Oops!. Something error occured.");
                        }
                    },
                    failure: function (response) {

                    }
                });
            }

            return ret;
        }

    </script>

    <script type="text/javascript">
        var $NoConfi = jQuery.noConflict();
        var $NoConfi3 = jQuery.noConflict();
    function LoadDesignationList() {

        var OrgId = '<%= Session["ORGID"] %>';
        var UserId = '<%= Session["USERID"] %>';
        var CorpId = '<%= Session["CORPOFFICEID"] %>';

        if (OrgId == "" || UserId == "" || CorpId == "") {
            window.location = "Default.aspx";
        }

      var DesgTypId = document.getElementById("<%=hiddenFieldDesgTypId.ClientID%>").value;
      var DesgContrl = document.getElementById("<%=hiddenFieldDesgContrl.ClientID%>").value;

      var responsiveHelper_datatable_fixed_column = undefined;


      var breakpointDefinition = {
          tablet: 1024,
          phone: 480
      };

      /* COLUMN FILTER  */

      var otable = $NoConfi3('#datatable_fixed_column').DataTable({
          'bProcessing': true,
          'bServerSide': true,
          'sAjaxSource': 'dataNotice_Period_Allocation.ashx',

          "bDestroy": true,
          "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6 hidden-xs'f><'col-sm-6 col-xs-12 hidden-xs'<'toolbar'>>r>" +
                  "t" +
                  "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
          "autoWidth": true,
          "oLanguage": {
              "sSearch": '<span class="input-group-addon"><i  class="glyphicon glyphicon-search"></i></span>'

          },
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
              aoData.push({ "name": "ORG_ID", "value": OrgId });
              aoData.push({ "name": "DESGTYP_ID", "value": DesgTypId });
              aoData.push({ "name": "DESG_CNTRL", "value": DesgContrl });
              aoData.push({ "name": "USERID", "value": UserId });
              aoData.push({ "name": "CORPOFFICEID", "value": CorpId });
          }, 
          aoColumnDefs: [
            {
                bSortable: false,
                aTargets: [-1, -2, -3]
            }
          ]
      });


      // Apply the filter

      $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

          otable
              .column($NoConfi(this).parent().index() + ':visible')
              .search(this.value)
              .draw();

      });
      /* END COLUMN FILTER */
      ScrollTop();    
  }
    </script>


    <script>


        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Notice period details inserted successfully.";
                 ScrollTop();
             }
             function SuccessUpdation() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Notice period details updated successfully.";
                 ScrollTop();
             }

        function ScrollTop() {
            document.body.scrollTop = 0;
            document.documentElement.scrollTop = 0;
        }
        function DisableEnter(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }

 
        function isNum(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //at enter
            if (keyCodes == 13 || keyCodes == 16) {

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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                return true;

            }
            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                }
                return ret;
            }
        }

        function checkDays(RowCount) {
            var Days = document.getElementById("NoticeDays_" + RowCount).value;
            if (isNaN(parseInt(Days)) == true) {
                document.getElementById("NoticeDays_" + RowCount).value = "";
            }
        }

    </script>


      <script src="/js/jQuery/jquery-2.2.3.min.js"></script>  
       <script src="/js/jQueryUI/jquery-ui.min.js"></script>


   <style>
       .table td + td+td+td,
.table th + th+th+th
{
    text-align:center;
}
          #datatable_fixed_column_wrapper {
            border: 1px solid #065757;
        }
        .dt-toolbar  {
    border-bottom: 1px solid  #c8b6b6;
    background: #f4f6f0;
}
.dt-toolbar-footer  {
    border-top: 1px solid  #c8b6b6;
    background: #f4f6f0;
}
.table > thead > tr > th {
    background: #eee;
    color:#fff;
}
.table-bordered, .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
    border-bottom: 1px solid #c8b6b6;
    border-right: 1px solid  #c8b6b6;
}
.table {
    font-size: 13px;
}
.table-striped > tbody > tr:nth-of-type(2n+1) {
    background-color: #eaeaea;
}
        table.dataTable thead .sorting {
              background-color: #79895f;
        }
        table.dataTable thead .sorting_asc, table.dataTable thead .sorting_desc {
    background-color: #92a276;
}
        .table > thead > tr > th {
            padding: 8px 10px;
        }
        .table > tbody > tr > td {
            padding: 5px 10px;
            border-bottom: none;
        }

        .table {
            color: #3e3737;
            font-weight: bolder;
        }


        input[type=text] {
  width: 100%;
 
}
      .cont_rght {
            width: 98%;
        }  


div.dataTables_wrapper div.dataTables_processing {   
   top: 600%;
}


table.dataTable thead > tr > th.sorting_disabled {   
    background-color: #79895f;
}


    </style>
</asp:Content>

