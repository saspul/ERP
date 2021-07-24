<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Employee_Deduction_Master.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Employee_Deduction_hcm_Employee_Deduction_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
 
    <script src="/js/jQuery/jquery-2.2.3.min.js"></script>
      <script src="../../../../css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
    <script src="../../../../css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../../../../css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="../../../../css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/bootstrap/bootstrap.min.js"></script>

        <link href="../../../../css/HCM/CommonCss.css" rel="stylesheet" />
      <script src="../../../../js/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../../js/datepicker/datepicker3.css" rel="stylesheet" />
    <%--<link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
      <asp:HiddenField ID="HiddenFieldNewDate" runat="server" />
       <asp:HiddenField ID="HiddenBalncAmt" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
        <script src="/js/HCM/Common.js"></script>
      <div id="main" role="main">
        <div id="ribbon" style="display:none">
            <span id="refresh" class="btn btn-ribbon" data-action="resetWidgets" data-title="refresh" rel="tooltip" data-placement="bottom" data-original-title="<i class='text-warning fa fa-warning'></i> Warning! This will reset all your widget settings." data-html="true">
                <i class="fa fa-refresh"></i>
            </span>
        </div>
        <div id="content">
            <div class="row">
                      
                <div class="alert alert-success" id="successalert" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button>
    <strong>Success! </strong>
                 
   
</div>
                <div style="height:34px;">
    <div class="alert alert-danger" id="Warningalert" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button>
    <strong>Warning! </strong>
                 Date Should be Greater than Current date
   
</div>
                </div>
                            

         <div id="divList" class="list" onclick="ConfirmMessageforlist();" runat="server" style="position: fixed; right: 0%; top: 22%; height: 26.5px;z-index: 1;">

            <%--   <a href="gen_ProjectsList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>
        </div>
        <div class="alert alert-danger" id="success-alert-danger" style="display:none">
                 <button type="button" class="close" data-dismiss="alert">x</button>
                  
               </div><%--evm-20--%>

                <div style="width: 11%; float: right;">
                    <%--<a href="#" style="background-color: #1c74a4; width: 75px; height: 27px; padding: 2px;" onclick="return currentLangCodeSrch();" id="dialog_link" class="btn btn-info">Search </a>--%>
                </div>
            </div>

            <section id="widget-grid" class="">

                <div class="row">
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">

                            <header>
                                <asp:Label ID="lblHeader"  class="pageh2"  runat="server" Text=""></asp:Label>
                                <%--<label id="lblHeader"  class="pageh2"  runat="server">Add Employee Deduction</label>--%>

                            </header>
                            <div class="smart-form" style="float: left; width: 100%;">

                                <div id="TabContainer" runat="server" style="float: left; width: 100%;">
                                </div>


                                <div style="float: left;width: 93.5%; background: white; margin-top: 2%; padding-left: 1%;">

                                    <div style="width: 100%; float: left;" class="formdiv">
                                        <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 5%;">
                                                <%--evm-0027--%>
                                                <label class="lblh2" style="float: left;width: 27%;">Doc #*</label>
                                                <label class="input" style="float: left;width: 60%;">
                                                    <asp:TextBox ID="txtDocnum" onchange="IncrmntConfrmCounter()"  Name="Docnum" onblur="return chekdup();" onkeydown="return isNumber(event);" onkeypress="return isNumber(event);" runat="server" MaxLength="18" Style="text-transform: uppercase; margin-right: 4%;"></asp:TextBox>
                                                </label>
                                            </section>


                                        </div>
                        <script>
                            function chekdup() {
                                RemoveTagWithNumber('cphMain_txtDocnum');
                                $co = jQuery.noConflict();
                                var corpid = document.getElementById("<%=Hiddencorpid.ClientID%>").value;
                                var orgid = document.getElementById("<%=HiddenOrgid.ClientID%>").value;

                                txtDocnumval = $noCon.trim($noCon('#cphMain_txtDocnum').val());
                                if (HiddenNumberOfInstmts.Value != "0") {
                                    if (txtDocnumval != "") {
                                        $co.ajax({

                                            type: "POST",
                                            async: false,
                                            contentType: "application/json; charset=utf-8",
                                            url: "hcm_Employee_Deduction_Master.aspx/checkduplicate",
                                            data: '{txtDocnum:"' + txtDocnumval + '",corpid:"' + corpid + '",orgid:"' + orgid + '"}',
                                            // CheckDupIntwCatName(string strIntwCategoryId, string strIntwCategoryName, string strOrgId, string strCorpId)
                                            dataType: "json",
                                            success: function (data) {

                                                if (data.d != "0") {
                                                    $noCon4(window).scrollTop(0);
                                                    $noCon4("#Warningalert").html("Document Number Cannot be Duplicated.");
                                                    $noCon("#Warningalert").fadeTo(2000, 500).slideUp(500, function () {

                                                        $noCon("#cphMain_txtDocnum").focus();
                                                    });

                                                    $noCon("#Warningalert").alert();


                                                    //SuccessMsg("DUP", "Document Name Cannot be Duplicated.");
                                                    $noCon("#cphMain_txtDocnum").css({
                                                        "border": "1px solid red",
                                                        "background": ""
                                                    });

                                                }
                                            }
                                        });
                                    }
                                }
                            }

</script>
                                        <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 7%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Ref No.</label>
                                                <label class="input" style="float: left;width: 60%;">
                                                    <asp:TextBox ID="txtRefNo" onchange="IncrmntConfrmCounter()" onkeydown="return isTag(event,'cphMain_txtRefNo');" onblur="return RemoveTag('cphMain_txtRefNo');" onkeypress="return isTag(event);" runat="server" MaxLength="50" Style="text-transform: uppercase; margin-right: 4%;"></asp:TextBox>
                                                </label>
                                            </section>


                                        </div>
                                    </div>
                                    <div style="width: 100%; float: left;" class="formdiv">
                                        <div  style="width: 50%; float: left; ">

                                            <section style="width: 95%; margin-left: 5%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Employee*</label>
                                            
                                                         <div id="divDdlEmployee">

                                            <label class="select">
                                                <asp:DropDownList runat="server"  onchange="ChangeEmp()" ID="ddlEmployee"  CssClass="form-control" style="float: left;width: 60%;" onkeypress="return DisableEnter(event);" ></asp:DropDownList>

                                            </label>
                                        </div>
                                                
                                            </section>


                                        </div>

                                        <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 7%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Deduction*</label>
                                                                        <div id="divdeduction">

                                            <label class="select">
                                                <asp:DropDownList runat="server" ID="ddldeduction" onchange="IncrmntConfrmCounter()" style="float: left;width: 60%;" onkeypress="return DisableEnter(event);" >
                                                      <asp:ListItem Text="---SELECT DEDUCTION---" Value="0"></asp:ListItem>
                                                     <asp:ListItem Text="Loan" Value="1"></asp:ListItem>
                                                       <asp:ListItem Text="Advance Amount" Value="2"></asp:ListItem>
                                                       <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                                                </asp:DropDownList>

                                            </label>
                                        </div>
                                            </section>


                                        </div>
                                    </div>
                                  
                                <div style="width: 100%; float: left;" class="formdiv">
                                        <div style="width: 50%; float: left; """>

                                            <section style="width: 95%; margin-left: 5%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Amount*</label>
                                              
                                                           <label class="input" style="float: left;width: 60%;">
                                                    <asp:TextBox ID="txtamount" onchange="IncrmntConfrmCounter()" onkeydown="return isNumberAmount(event,'cphMain_txtamount');" onkeyup="addCommas('cphMain_txtamount')" onkeypress="return isTag(event);" onblur="return AmountCheck('cphMain_txtamount');" runat="server" MaxLength="12" Style="text-transform: uppercase; margin-right: 4%;text-align:right"></asp:TextBox>
                                                </label>
                                            
                                            </section>


                                        </div>

                                        <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 7%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Effective Month & Year*</label>
                                                <label class="input" style="float: left;width: 60%;">
                                                 <%--   evm-0027--%>
                                                           <label class="select">
                                             
                                                   <asp:DropDownList ID="ddlMonth"    runat="server" style="width:45%;float:left" onchange="EffectiveDateChanged();" onkeypress="return DisableEnter(event)" ></asp:DropDownList>
                                          <%--  </label>
                                             <label class="select">--%>
                                               <asp:DropDownList ID="ddlyear"   runat="server" onchange="EffectiveDateChanged();" style="width:15%" onkeypress="return DisableEnter(event)" ></asp:DropDownList>

                                            </label>
                                                <input id="txtefctvedate" style="display:none;" name="txtefctvedate" type="text" class="Tabletxt form-control datepicker"  data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" onchange="GetDate()" />
                                                  <%--  end--%>
                                                    <asp:HiddenField ID="Hiddentxtefctvedate" runat="server" value="0"/>
                                                     
                                                      <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" value="0"/>
                                          <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
                     
      <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server"  Value="0"/>
                                                                        <script>

                                                                            function EffectiveDateChanged() {
                                                                                IncrmntConfrmCounter();
                                                                                $noCon4('#txtefctvedate').datepicker('setDate', "01-" + $noCon4('#cphMain_ddlMonth').val() + "-" + $noCon4('#cphMain_ddlyear').val() + "")
                                                                            }
                                                                            var today = new Date();
                                                                            var tomorrow = new Date(today.getTime() + 24 * 60 * 60 * 1000);
                                                                          
                                                                            var $noCon4 = jQuery.noConflict();
                                                          $noCon4('#txtefctvedate').datepicker({
                                                                  autoclose: true,
                                                                  format: 'dd/mm/yyyy',
                                                                 //startDate: tomorrow,
                                                                  timepicker:false
                                                          });
                                                          if ($noCon4('#txtefctvedate').val() == "") 
                                                              $noCon4('#txtefctvedate').datepicker('setDate', today);
                                                             
                                                              
                                                          
                                                              function GetDate()
                                                             {
                                                                // alert(document.getElementById("<%=HiddenEditval.ClientID%>").value);
                                                                  if (document.getElementById("<%=HiddenEditval.ClientID%>").value != "1")
                                                                  {
                                                                      if ($noCon4('#txtefctvedate').val() != "") {




                                                                          if (document.getElementById("<%=HiddenFieldNewDate.ClientID%>").value.trim() != "")
                                                                          {

                                                                              var CurrentDate = document.getElementById("<%=HiddenFieldNewDate.ClientID%>").value.trim();
                                                                              var arrDatePickerDate1 = CurrentDate.split("/");
                                                                              CurrentDate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);


                                                                              var SelectedDate = $noCon4('#txtefctvedate').val();
                                                                              var arrCurrentDate = SelectedDate.split("/");
                                                                              var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);



                                                                              if (dateCurrentDate < CurrentDate) {
                                                                                  alert("Selected dates monthly salary already processed.");
                                                                                  $noCon4('#txtefctvedate').datepicker('setDate', new Date(CurrentDate));
                                                                              }

                                                                          }
                                                                          $noCon4('#cphMain_Hiddentxtefctvedate').val($noCon4('#txtefctvedate').val());

                                                                          $noCon4('#cphMain_divTables').html('');

                                                                      }
                                                                      else {
                                                                          if (document.getElementById("<%=HiddenFieldNewDate.ClientID%>").value.trim() != "") {

                                                                              var CurrentDate = document.getElementById("<%=HiddenFieldNewDate.ClientID%>").value.trim();
                                                                              var arrDatePickerDate1 = CurrentDate.split("/");
                                                                              CurrentDate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

                                                                              $noCon4('#txtefctvedate').datepicker('setDate', new Date(CurrentDate));
                                                                          }
                                                                          else {
                                                                              $noCon4('#txtefctvedate').datepicker('setDate', new Date());
                                                                          }
                                                                          $noCon4('#cphMain_Hiddentxtefctvedate').val($noCon4('#txtefctvedate').val());
                                                                      }
                                                                  }
                                                              }
                                                              function SetDate() {
                                                                  IncrmntConfrmCounter();
                                                                 // alert($noCon4('#cphMain_Hiddentxtefctvedate').val());
                                                                  $noCon4('#txtefctvedate').val($noCon4('#cphMain_Hiddentxtefctvedate').val());

                                                              }
                                                              function Recalculate(text)
                                                              {
                                                                  text = '#' + text;
                                                            
                                                                
                                                                  var amountchanged = $noCon4(text).val();
                                                                
                                                                  var total = $noCon4('#cphMain_txtamount').val();
                                                                  var noinstalmnt = $noCon4('#cphMain_txtinstallemntno').val();
                                                                  
                                                                  var reamount = parseFloat(total) - parseFloat(amountchanged);
                                                                  
                                                                  var recalculated = parseFloat(reamount) / (noinstalmnt - 1);
                                                                 
                                                                  for (i = 0; i < noinstalmnt; i++)
                                                                  {
                                                                      $noCon4('#InstlmntAmnt' + i).val(recalculated);
                                                                      AmountCheck('#InstlmntAmnt' + i);
                                                                      addCommas('#InstlmntAmnt' + i);


                                                                  }
                                                                  $noCon4(text).val(amountchanged);
                                                              }
                                                             
                                                              function removeRow(rownum, CofirmMsg) { 





                                                                  ConfirmMessageDelete(rownum);

                                                                     
                                                           
                                                                 
                                                              }
                                                              function Loadtable(mode) {
                                                                
                                                                  var corpid = document.getElementById("<%=Hiddencorpid.ClientID%>").value;
                                                                  IncrmntConfrmCounter();
                                                                  if (validateCalc() == false)
                                                                      return false;
                                                                      var Stramount = $noCon4('#cphMain_txtamount').val();
                                                                      var StrInstallementNo = $noCon4('#cphMain_txtinstallemntno').val();
                                                         
                                                                      var curid = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;

                                                                  
                                                                      if (mode == "remove") {
                                                                          var BforeRmvTableRowCount = document.getElementById("datatable_fixed_column").rows.length;
                                                                       
                                                                          var oTable = $noCon4('#datatable_fixed_column').dataTable();

                                                                          // Get the length
                                                                     
                                                                          BforeRmvTableRowCount= oTable.fnGetData().length;                                                                          BforeRmvTableRowCount = BforeRmvTableRowCount - 2;
                                                                          StrInstallementNo = BforeRmvTableRowCount;
                                                                         // var amountchanged = $noCon4(text).val();
                                                                      }
                                                                      var StrEffectiveDate = $noCon4('#txtefctvedate').val();

                                                                  //evm-0027
                                                                      var strEffectiveMonth = $noCon4('#cphMain_ddlMonth').val();
                                                                      var strEffectiveYear = $noCon4('#cphMain_ddlyear').val();
                                                                  //end
                                                                     
                                                                      var StrInstallementPlan = $noCon4('#cphMain_ddlinstallmentplan').val();
                                                                      $co = jQuery.noConflict();
                                                                  
                                                                      $co.ajax({
                                                                          type: "POST",
                                                                          async: false,
                                                                          contentType: "application/json; charset=utf-8",
                                                                          url: "hcm_Employee_Deduction_Master.aspx/convertdatatohtml",
                                                                          data: '{Stramount:"' + Stramount + '",StrInstallementNo:"' + StrInstallementNo + '",StrInstallementPlan:"' + StrInstallementPlan + '",StrEffectiveDate:"' + StrEffectiveDate + '",CurID:"' + curid + '",corpid:"' + corpid + '",strEffectiveMonth:"' + strEffectiveMonth + '",strEffectiveYear:"' + strEffectiveYear + '"}',
                                                                          // CheckDupIntwCatName(string strIntwCategoryId, string strIntwCategoryName, string strOrgId, string strCorpId)
                                                                          dataType: "json",
                                                                          success: function (data) {
                                                                            
                                                                              if (data.d != "") {
                                                                                  $noCon4('#cphMain_divTables').html(data.d);
                                                                                
                                                                                  var effctvedate = $noCon4('#cphMain_Hiddentxtefctvedate').val();
                                                                              
                                                                                  for (i = 0; i < StrInstallementNo; i++) {
                                                                                     
                                                                                      $noCon4('#PAiddate_' + i).datepicker({
                                                                                          autoclose: true,
                                                                                          format: 'dd/mm/yyyy',
                                                                                          startDate: effctvedate,
                                                                                          timepicker: false
                                                                                      });
                                                                                  } ret = true;
                                                                              }
                                                                              else {
                                                                                  //alert('Duplicate');
                                                                                  ret = false;
                                                                              }

                                                                              var responsiveHelper_datatable_fixed_column = undefined;


                                                                              var breakpointDefinition = {
                                                                                  tablet: 1024,
                                                                                  phone: 480
                                                                              };

                                                                              /* COLUMN FILTER  */

                                                                              var otable = $noCon4('#datatable_fixed_column').DataTable({
                                                                                  "bFilter": false,
                                                                                  "bPaginate": false,
                                                                                  // 'bProcessing': true,
                                                                                  // 'bServerSide': true,
                                                                                  //  'sAjaxSource': 'dataVIewDeduction.ashx',
                                                                               
                                                                                  "bDestroy": true,
                                                                                  "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6 hidden-xs'f><'col-sm-6 col-xs-12 hidden-xs'<'toolbar'>>r>" +
                                                                                          "t" +
                                                                                          "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
                                                                                  "autoWidth": true,
                                                                                  "oLanguage": {
                                                                                      //"sSearch": ' <span  class="input-group-addon"><i  class="glyphicon glyphicon-search"></i></span>'

                                                                                  },
                                                                                  "preDrawCallback": function () {
                                                                                      // Initialize the responsive datatables helper once.
                                                                                      if (!responsiveHelper_datatable_fixed_column) {
                                                                                          responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($noCon4('#datatable_fixed_column'), breakpointDefinition);
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
                                                                                  }
                                                                              });


                                                                              // Apply the filter

                                                                              $noCon4("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                                                                                  otable
                                                                                      .column($noCon4(this).parent().index() + ':visible')
                                                                                      .search(this.value)
                                                                                      .draw();

                                                                              });

                                                                          },
                                                                          error: function (response) {

                                                                          }

                                                                      });

                                                                      $noCon("#datatable_fixed_column_info").hide();
                                                                      validatepaylist('no');
                                                                      if (mode != "save")
                                                                          return false;
                                                                      else
                                                                          return true;
                                                                  }
                                                              
                                                          </script>

                                                    <script>
                                                        var $NoChage = jQuery.noConflict();
                                                        function ChangeEmp() {
                                                            document.getElementById("<%=HiddenFieldNewDate.ClientID%>").value = "";
                                                            IncrmntConfrmCounter();
                                                            if ($NoChage.trim($NoChage('#cphMain_ddlEmployee').val()) != '0' && $NoChage.trim($NoChage('#cphMain_ddlEmployee').val()) != '--SELECT EMPLOYEE--') {
                                                                var corpid = document.getElementById("<%=Hiddencorpid.ClientID%>").value;
                var orgid = document.getElementById("<%=HiddenOrgid.ClientID%>").value;
                var EmpId = $noCon('#cphMain_ddlEmployee').val();

                $NoChage.ajax({

                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "hcm_Employee_Deduction_Master.aspx/CheckEffctveDate",
                    data: '{EmpId:"' + EmpId + '",corpid:"' + corpid + '",orgid:"' + orgid + '"}',
                    dataType: "json",
                    success: function (data) {

                        if (data.d != "") {

                            var CurrentDate = data.d;
                            var arrDatePickerDate1 = CurrentDate.split("/");
                            var tomorrow = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
                            $noCon4('#txtefctvedate').datepicker("setDate", new Date(tomorrow));
                            document.getElementById("<%=HiddenFieldNewDate.ClientID%>").value = CurrentDate;
                           
                        }
                        else {

                            $noCon4('#txtefctvedate').datepicker("setDate", new Date());
                            document.getElementById("<%=HiddenFieldNewDate.ClientID%>").value = "";
                        }
                    }
                });


            }
        }
    </script>
                                                  
                                                </label>
                                            </section>


                                        </div>
                                    </div>
                            <div style="width: 100%; float: left;" class="formdiv">
                                        <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 5%;">
                                              <%--  evm-0027--%>
                                                <label class="lblh2" style="float: left;width: 27%;"> No of Installment*</label>
                                               
                                                           <label class="input" style="float: left;width: 60%;">
                                                    <asp:TextBox ID="txtinstallemntno" onchange="IncrmntConfrmCounter()"   onkeypress="return isNumber(event);" onkeydown="return  isNumber(event);"   onblur="return nozero('cphMain_txtinstallemntno');" runat="server" MaxLength="3" Style="text-transform: uppercase; margin-right: 4%;"></asp:TextBox>
                                                </label>
                                          
                                            </section>


                                        </div>

                                        <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 7%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Installment Plan*</label>
                                                <div id="div1">
                                            <label class="select">
                                                <asp:DropDownList runat="server" onchange="IncrmntConfrmCounter()" ID="ddlinstallmentplan" style="float: left;width: 60%;" onkeypress="return DisableEnter(event);" >
                                                                  <asp:ListItem Text="---SELECT PLAN---" Value="0"></asp:ListItem>
                                                     <asp:ListItem Text="Monthly" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Two Months" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Six Months" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Annually" Value="4"></asp:ListItem>
                                                </asp:DropDownList>

                                            </label> </div>
                                            </section>


                                        </div>
                                    </div>

                                         <div style="width: 100%; float: left;" class="formdiv">
                                      <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 5%;">
                                                <label class="lblh2" style="float: left;width: 27%;margin-top: 17px;">Remarks </label>
                                               
                                            <label class="input" style="float: left;width: 60%;">
                                            
                                                  <asp:TextBox ID="txtremarks" class="form-control" MaxLength="450" onchange="IncrmntConfrmCounter()" onkeypress="return isTag(event);" onkeydown="return textCounter(cphMain_txtremarks,450);" onblur="return textCounter(cphMain_txtremarks,450);" runat="server" Style="text-transform: uppercase; margin-right: 4%;resize: none;" TextMode="MultiLine" Type="textarea"></asp:TextBox>
                                    
                                            </label>
                                            </section>
                                          </div>
                                 <asp:Button ID="btncalc" runat="server" Style="float: left; " class="btn btn-primary" Text="Calculate"  OnClientClick="return Loadtable('new');" />
     
                                        </div>
                                           <div style="width: 100%; float: left;" class="formdiv">
                                     <%--<asp:Button ID="btncalc" runat="server" Style="float: left;width: 6%;"  class="btn btn-primary" Text="calculate"  />--%>
                                                                      </div>
                                    <asp:Label ID="lblinstalsectn" class="pageh2" runat="server" Text="Instalment List"></asp:Label>
                                    <div style="float: left; width: 100%;" >
                                 
                                      
                                 
                                                <div id="divTables" runat="server" class="widget-body" style="float:left;margin-left:5%;margin-top:2%">
                                             <%--   <div id="divTables" class="table-responsive" runat="server" style="width: 100%; margin: auto; padding-top: 0.6%;">
                                           --%>           
                                                 

                                                   </div>

                                      
                                               

                                       
                                             <footer style="background: white;">
                              
                                                 <div style="float:left;width:100%;margin-left: 50%">
                                                    
                                                     <asp:Button ID="btnsavepayment" runat="server" Style=" float: left; margin-left: 1%;" class="btn btn-primary" Text="Save" OnClick="btnSave_Click" OnClientClick="return validate('save');" />
                                                     
                                                     <asp:Button ID="btnsaveclose" runat="server" Style=" float: left; margin-left: 1%;" class="btn btn-primary" Text="Save & Close" OnClick="btnSave_Click" OnClientClick="return validate('save');" />

                                                        <asp:Button ID="btnUpdate" runat="server" Style="float: left;" class="btn btn-primary" Text="Update" OnClientClick="return SaveInstallment();" OnClick="btnUpdate_Click"/>
                                    <asp:Button ID="btnUpdateClose" runat="server" Style="float: left;" class="btn btn-primary" Text="Update & Close" OnClientClick="return SaveInstallment();" OnClick="btnUpdate_Click"/>
                                                     
                                                       <asp:Button ID="btnAddClose" runat="server" Style="float: left; " class="btn btn-primary" Text="Confirm"  OnClientClick="return ConfirmActionMessage()" />
                                      <asp:Button ID="btndummyconfrm" runat="server" Style="float: left;display:none " class="btn btn-primary" Text="Confirm" OnClick="btnUpdate_Click"  />
                                                  
                                                         <asp:Button ID="btnReopen" runat="server" Style="float: left;visibility:hidden; " class="btn btn-primary" Text="Reopen" OnClientClick="return ReopenActionMessage();" OnClick ="btnReopen_Click"    />
                                                          <asp:Button ID="btndummyReopen" runat="server" Style="float: left;display:none " class="btn btn-primary" Text="Reopen" OnClick="btnReopen_Click"  />
                                                                      <asp:Button ID="btnClear" runat="server" Style="float: left;" class="btn btn-primary" Text="Cancel" OnClientClick="return ConfirmCancel();" />
                                  
                                  
                                                 
                                           </div>       <%--      <button type="submit" class="btn btn-primary">
                                            SAVE float: left;margin-left: 80%;
                                        </button>--%>
                           
           </footer>
                                            </div>


                                   
 
     <asp:HiddenField ID="Hiddencorpid" runat="server" value="0"/>
                 <asp:HiddenField ID="HiddenOrgid" runat="server" value="0"/>                   
                              <asp:HiddenField ID="HiddenPaidAmt" runat="server" value="0"/>

                                     <asp:HiddenField ID="hiddentotaldata" runat="server" value="0"/>
                                            <asp:HiddenField ID="HiddenEditval" runat="server" value=""/>      
                                    <asp:HiddenField ID="HiddenCnfrmed" runat="server" value=""/>  
                               <asp:HiddenField ID="HiddenDeductID" runat="server" value=""/>  
                                           <asp:HiddenField ID="Hiddencurrentdate" runat="server" value=""/>  

                                      <asp:HiddenField ID="HiddenNumberOfInstmts" runat="server" value=""/>  
                                <%--  </form>--%>
                            </div>
                        </div>

                    </article>
                </div>
            </section>
        </div>
    </div>


                        <%--------------------------------View for error Reason--------------------------%>
           <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Visa Type Master</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                        <div id="divErrorRsnAWMS" class="error" style="visibility: hidden; text-align: center;">
                            <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                        </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri; float: left; margin-left: 11%; margin-top: 10%; padding-right: 2%; width: 22%; color: #909c7b;">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize: none; border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                        <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" Style="width: 90px; float: left; margin-left: 39%; margin-top: 3%;" />

                        <asp:Button ID="btnRsnCncl" class="save" Style="width: 90px; float: right; margin-right: 26%; margin-top: 3%;" OnClientClick="CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   

         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>


        <script type="text/javascript">
            var confirmbox = 0;

            function IncrmntConfrmCounter() {

                confirmbox++;
     
         
            }
           
            var $noCon = jQuery.noConflict();

            $noCon(document).ready(function () {
               // 
              //  $noCon("#success-alert").hide();
               
            });

            $noCon(window).load(function () {
              // $noCon("#success-alert").hide();
                document.getElementById("freezelayer").style.display = "none";
                document.getElementById('MymodalCancelView').style.display = "none";
                $noCon('#datepicker').datepicker('show');
            
             //   alert(document.getElementById("<%=HiddenEditval.ClientID%>").value);

                if (document.getElementById("<%=HiddenEditval.ClientID%>").value == "1") {

               
                 //   alert(document.getElementById("<%=HiddenNumberOfInstmts.ClientID%>").value);
                    if (document.getElementById("<%=HiddenNumberOfInstmts.ClientID%>").value == "1") {
                        $noCon("#cphMain_txtinstallemntno").attr('disabled', true);
                        $noCon("input[type=text]").attr('disabled', true);
                         $noCon("input[type=textarea]").attr('disabled', true);
                         $noCon("#cphMain_ddlinstallmentplan").attr('disabled', true);
                          $noCon("#cphMain_txtremarks").attr('disabled', true);
                          $noCon("#cphMain_ddlEmployee").attr('disabled', true);
                          $noCon("#cphMain_ddldeduction").attr('disabled', true);


                    }
                    else
                    {
                        $noCon("#cphMain_txtinstallemntno").attr('disabled', false);
                        $noCon("#cphMain_btncalc").attr('visiblity', true);
                      //  $noCon("input[type=text]").attr('disabled', false);
                        $noCon("input[type=textarea]").attr('disabled', false);
                        $noCon("#cphMain_ddlinstallmentplan").attr('disabled', false);



                        $noCon("#cphMain_txtremarks").attr('disabled', false);
                        $noCon("#cphMain_ddlEmployee").attr('disabled', false);
                        $noCon("#cphMain_ddldeduction").attr('disabled', false);
                    }


                  //  SetDate();
                    if (document.getElementById("<%=HiddenCnfrmed.ClientID%>").value == "1") {

                        validatepaylist('con');
                        $noCon("#cphMain_txtinstallemntno").attr('disabled', true);
                        $noCon("input[type=text]").attr('disabled', true);
                        $noCon("input[type=textarea]").attr('disabled', true);
                        $noCon("#cphMain_ddlinstallmentplan").attr('disabled', true);
                        $noCon("#cphMain_txtremarks").attr('disabled', true);
                        $noCon("#cphMain_ddlEmployee").attr('disabled', true);
                        $noCon("#cphMain_ddldeduction").attr('disabled', true);
                    }
                    else
                        validatepaylist('no');

                    if (document.getElementById("<%=HiddenPaidAmt.ClientID%>").value == "con") 
                        validatepaylist('con');
                }

                $noCon("#datatable_fixed_column_info").hide();
          
        });
            function validatepaylist(act)
            {
              
                
                var noinstalmnt = $noCon4('#cphMain_txtinstallemntno').val();


                var effctvedate = $noCon4('#cphMain_Hiddentxtefctvedate').val();
            
                for (i = 0; i < noinstalmnt; i++) {

                    var instdate = $noCon4('#InstlDate' + i).val();
                    var amount = $noCon4('#InstlmntAmnt' + i).val();
                    var paiddate = $noCon4('#PAiddate_' + i).val();
                    var status = $noCon4('#txtStatus' + i).val();
                    var paidamt = $noCon4('#txtamountpaid' + i).val().trim();
                    if (act != 'con')
                    {
                       // alert(status);
                        if (paidamt != "" && paidamt != "0" && paiddate != "" && status > 0)
                        {


                            $noCon4('#txtamountpaid' + i).prop("disabled", true);
                            $noCon4('#PAiddate_' + i).prop("disabled", true);
                        }
                        else
                        {

                            if (i != 0) {
                                var j = i - 1;
                                if ($noCon4('#txtamountpaid' + j).val().trim() == "") {
                                    $noCon4('#txtamountpaid' + i).prop("disabled", true);
                                    $noCon4('#PAiddate_' + i).prop("disabled", true);
                                }
                                else {
                                    $noCon4('#txtamountpaid' + i).prop("disabled", false);
                                    $noCon4('#PAiddate_' + i).prop("disabled", false);
                                }
                            } else {
                                $noCon4('#txtamountpaid' + i).prop("disabled", false);
                                $noCon4('#PAiddate_' + i).prop("disabled", false);
                            }
                        }




                        $noCon4('#PAiddate_' + i).datepicker({
                            autoclose: true,
                            format: 'dd/mm/yyyy',
                            startDate: effctvedate,
                            timepicker: false
                        });


                    }
                    else {

                        $noCon4('#txtamountpaid' + i).prop("disabled", true);
                        $noCon4('#PAiddate_' + i).prop("disabled", true);

                    }
                }
                $noCon("#datatable_fixed_column_info").hide();
            }
            function validate()
            {

                var flag = true;

                var focus = '';

                $noCon('#cphMain_ddlinstallmentplan').each(function () {

                    if ($noCon.trim($noCon(this).val()) == '0' || $noCon.trim($noCon(this).val()) == '--SELECT PLAN--') {
                        isValid = false;
                        $noCon(this).focus();
                        $noCon(this).css({
                            "border": "1px solid red",
                            "background": ""
                        });
                        flag = false;
                    }
                    else {
                        $noCon(this).css({
                            "border": "",
                            "background": ""
                        });
                    }
                });

                $noCon('#cphMain_txtinstallemntno').each(function () {

                    if ($noCon.trim($noCon(this).val()) == '') {
                        //  isValid = false;
                        flag = false;
                        $noCon(this).focus();
                        $noCon(this).css({
                            "border": "1px solid red",
                            "background": ""
                        });

                    }
                    else {
                        $noCon(this).css({
                            "border": "",
                            "background": ""
                        });
                    }
                });
                $noCon('#txtefctvedate,#cphMain_txtamount').each(function () {

                    if ($noCon.trim($noCon(this).val()) == '') {
                        //  isValid = false;
                        flag = false;
                        $noCon(this).focus();
                        $noCon(this).css({
                            "border": "1px solid red",
                            "background": ""
                        });

                    }
                    else {
                        $noCon(this).css({
                            "border": "",
                            "background": ""
                        });
                    }
                });

                $noCon('#cphMain_ddldeduction').each(function () {

                    if ($noCon.trim($noCon(this).val()) == '0' || $noCon.trim($noCon(this).val()) == '--SELECT DEDUCTION--') {
                        isValid = false;
                        $noCon(this).focus();
                        $noCon(this).css({
                            "border": "1px solid red",
                            "background": ""
                        });
                        flag = false;
                    }
                    else {
                        $noCon(this).css({
                            "border": "",
                            "background": ""
                        });
                    }
                });

                if ($noCon.trim($noCon('#cphMain_ddlEmployee').val()) == '0' || $noCon.trim($noCon('#cphMain_ddlEmployee').val()) == '--SELECT EMPLOYEE--') {

                    $noCon('div#divDdlEmployee input.ui-autocomplete-input').css({
                        "border": "1px solid red",
                        "background": ""
                    });
                    focus = 'div#divDdlEmployee input.ui-autocomplete-input';
                    $noCon(focus).focus();
                    flag = false;
                }
                else {
                    $noCon('div#divDdlEmployee input.ui-autocomplete-input').css({
                        "border": "",
                        "background": ""
                    });
                }

                $noCon('#cphMain_txtDocnum').each(function () {

                    if ($noCon.trim($noCon(this).val()) == '') {
                        //  isValid = false;
                        flag = false;
                        $noCon(this).focus();
                        $noCon(this).css({
                            "border": "1px solid red",
                            "background": ""
                        });

                    }
                    else {
                        $noCon(this).css({
                            "border": "",
                            "background": ""
                        });
                    }
                });

                //evm-20
                if (flag == false) {

                    $noCon("#success-alert-danger").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#success-alert-danger").fadeTo(2000, 500).slideUp(500, function () {

                    });
                    $noCon("#success-alert-danger").alert();

                }

                if (flag == true) {
                    // var BforeRmvTableRowCount = document.getElementById("datatable_fixed_column").rows.length;
                    // alert(BforeRmvTableRowCount);
                    // if(BforeRmvTableRowCount==0)
                    //  return false;
                    //   Loadtable("new")

                    flag = SaveInstallment();

                    if (document.getElementById("<%=hiddentotaldata.ClientID%>").value == 0) {
                            $noCon4(window).scrollTop(0);
                            $noCon4("#Warningalert").html("Cannot Save without Calculation.");
                            $noCon("#Warningalert").fadeTo(2000, 500).slideUp(500, function () {

                                $noCon("#cphMain_txtDocnum").focus();
                            });

                            $noCon("#Warningalert").alert();


                            flag = false;
                            return false;
                        }

                        //for (i = next; i < noinstalmnt; i++) {
                        //    $noCon('#InstlmntAmnt' + i).val(recalculated);
                        //    if (recalculated == 0) {
                        //        $noCon("#txtamountpaid" + i).attr("disabled", true);
                        //        $noCon("#InstlmntAmnt" + i).attr("disabled", true);
                        //        $noCon("#PAiddate_" + i).attr("disabled", true);

                        //    }
                        //}

                    }

                    return flag;
                }


            function validateCalc() {
                var flag = true;
                var focus = "";

                $noCon('#cphMain_ddlinstallmentplan').each(function () {

                    if ($noCon.trim($noCon(this).val()) == '0' || $noCon.trim($noCon(this).val()) == '--SELECT PLAN--') {
                        isValid = false;
                        $noCon(this).focus();
                        $noCon(this).css({
                            "border": "1px solid red",
                            "background": ""
                        });
                        flag = false;
                    }
                    else {
                        $noCon(this).css({
                            "border": "",
                            "background": ""
                        });
                    }
                });

                $noCon('#cphMain_txtinstallemntno').each(function () {

                    if ($noCon.trim($noCon(this).val()) == '') {
                        //  isValid = false;
                        flag = false;
                        $noCon(this).focus();
                        $noCon(this).css({
                            "border": "1px solid red",
                            "background": ""
                        });

                    }
                    else {
                        $noCon(this).css({
                            "border": "",
                            "background": ""
                        });
                    }
                });
                $noCon('#txtefctvedate,#cphMain_txtamount').each(function () {

                    if ($noCon.trim($noCon(this).val()) == '') {
                        //  isValid = false;
                        flag = false;
                        $noCon(this).focus();
                        $noCon(this).css({
                            "border": "1px solid red",
                            "background": ""
                        });

                    }
                    else {
                        $noCon(this).css({
                            "border": "",
                            "background": ""
                        });
                    }
                });

                $noCon('#cphMain_ddldeduction').each(function () {

                    if ($noCon.trim($noCon(this).val()) == '0' || $noCon.trim($noCon(this).val()) == '--SELECT DEDUCTION--') {
                        isValid = false;
                        $noCon(this).focus();
                        $noCon(this).css({
                            "border": "1px solid red",
                            "background": ""
                        });
                        flag = false;
                    }
                    else {
                        $noCon(this).css({
                            "border": "",
                            "background": ""
                        });
                    }
                });

                if ($noCon.trim($noCon('#cphMain_ddlEmployee').val()) == '0' || $noCon.trim($noCon('#cphMain_ddlEmployee').val()) == '--SELECT EMPLOYEE--') {

                    $noCon('div#divDdlEmployee input.ui-autocomplete-input').css({
                        "border": "1px solid red",
                        "background": ""
                    });
                    focus = 'div#divDdlEmployee input.ui-autocomplete-input';
                    $noCon(focus).focus();
                    flag = false;
                }
                else {
                    $noCon('div#divDdlEmployee input.ui-autocomplete-input').css({
                        "border": "",
                        "background": ""
                    });
                }

                $noCon('#cphMain_txtDocnum').each(function () {

                    if ($noCon.trim($noCon(this).val()) == '') {
                        //  isValid = false;
                        flag = false;
                        $noCon(this).focus();
                        $noCon(this).css({
                            "border": "1px solid red",
                            "background": ""
                        });

                    }
                    else {
                        $noCon(this).css({
                            "border": "",
                            "background": ""
                        });
                    }
                });

                //evm-20
                if (flag == false) {

                    $noCon("#success-alert-danger").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#success-alert-danger").fadeTo(2000, 500).slideUp(500, function () {

                    });
                    $noCon("#success-alert-danger").alert();

                }
                return flag;
            }
            var tbClientTotalValues = '';
            tbClientTotalValues = [];
            function addToList(instldate, amount, paiddate,amountpaid, DetailID) {

                var $add = jQuery.noConflict();


                var client = JSON.stringify({
                    ROWID: "" + 1 + "",
                    INSTALLMENTDATE: "" + instldate + "",
                    AMOUNT: "" + amount + "",
                    PAIDDATE: "" + paiddate + "",
                    PAIDAMT: "" + amountpaid + "",
                    DETAILID: "" + DetailID + "",
                    EVTACTION: "INS"
                });
                tbClientTotalValues.push(client);
                document.getElementById("<%=hiddentotaldata.ClientID%>").value = JSON.stringify(tbClientTotalValues);
           
         
            }


            function SaveInstallment() {

                tbClientTotalValues = [];
                var noinstalmnt = $noCon4('#cphMain_txtinstallemntno').val();




                for (i = 0; i < noinstalmnt; i++) {
                    if ($noCon4('#InstlDate' + i) == undefined)
                                          return false;
                    var instdate = $noCon4('#InstlDate' + i).val();
               
                    var amount = $noCon4('#InstlmntAmnt' + i).val();
                    if ($noCon4('#PAiddate_' + i).val() == undefined)
                        return false;
                    var paiddate = $noCon4('#PAiddate_' + i).val();	
               
                    var paiddate = $noCon4('#PAiddate_' + i).val();
                   
                    var paidamt = $noCon4('#txtamountpaid' + i).val();
                    if (instdate != "" && instdate != undefined)

                        addToList(instdate, amount, paiddate, paidamt, 0);

                    if (paidamt != ""&&paidamt != "0")
                    {
                        $noCon("#PAiddate_" + i).css({
                            "border": "",
                            "background": ""
                        });
                        if (paiddate == "")
                        {
                            $noCon("#PAiddate_"+i).css({
                                "border": "1px solid red",
                                "background": ""
                            });
                            $noCon("#PAiddate_" + i).focus();
                            return false;

                        }
                    }  if (paiddate != "") {
                        if (paidamt == "") {
                            $noCon("#txtamountpaid" + i).css({
                                "border": "1px solid red",
                                "background": ""
                            });
                            return false;

                        }
                    }
                }
                return true;
            }
        
         
            function ConfirmCancel()
            {
                if (confirmbox>0)
                    CancelAlert("hcm_Employee_Deduction_List.aspx");
                else
                window.location.href = "hcm_Employee_Deduction_List.aspx";
                return false;
            }
            function ConfirmMessageforlist() {
                if (confirmbox > 0)
                    ConfirmMessage("hcm_Employee_Deduction_List.aspx");
                else
                    window.location.href = "hcm_Employee_Deduction_List.aspx";
                return false;
            }
            function SuccesMessage() {
                window.location = "hcm_Employee_Deduction_List.aspx";
         
                return false;
            }

            function ConfirmActionMessage() {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to confirm this entry?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        if (SaveInstallment())
                        document.getElementById("<%=btndummyconfrm.ClientID%>").click();
                        else
                            return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;

            }
           

            function ReopenActionMessage() {

                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to confirm this entry?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        if (SaveInstallment())
                            document.getElementById("<%=btndummyReopen.ClientID%>").click();
                        else
                            return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;

            }


            function AlertFor() {
                
                $noCon4(window).scrollTop(0);
                $noCon4("#Warningalert").html("Document Name Cannot be Duplicated.");
                $noCon("#Warningalert").fadeTo(2000, 500).slideUp(500, function () {

                        $noCon("#cphMain_txtDocnum").focus();
                    });

                $noCon("#Warningalert").alert();
                    SetDate();
                    Loadtable('new');

                    $noCon("#datatable_fixed_column_info").hide();
                    //SuccessMsg("DUP", "Document Name Cannot be Duplicated.");
                    $noCon("#cphMain_txtDocnum").css({
                        "border": "1px solid red",
                        "background": ""
                    });

   
            }

            function SuccesUpdate() {

                $noCon4(window).scrollTop(0);
                $noCon4("#successalert").html("Employee deduction details updated sucessfully.");
                $noCon("#successalert").fadeTo(2000, 500).slideUp(500, function () {

                    $noCon("#cphMain_txtDocnum").focus();
                });

                $noCon("#successalert").alert();


             //   SuccessMsg("UPD", "Installment Details updateed Sucessfully");
              //  Loadtable('');
            }
            
            function SuccesReopen() {

                $noCon4(window).scrollTop(0);
                $noCon4("#successalert").html("Installment details reopened sucessfully.");
                $noCon("#successalert").fadeTo(2000, 500).slideUp(500, function () {

                    $noCon("#cphMain_txtDocnum").focus();
                });

                $noCon("#successalert").alert();


                //   SuccessMsg("UPD", "Installment Details updateed Sucessfully");
                //  Loadtable('');
            }
            function ConfirmMessageDelete(rownum) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "This will clear all the data in the table.Are you sure you want to Delete?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {

                        var text = '#row' + rownum;
                        var row_index = jQuery(text).index();
                        jQuery(text).remove();
                        var BforeRmvTableRowCount = document.getElementById("datatable_fixed_column").rows.length;
              
                        $noCon4('#cphMain_txtinstallemntno').val(parseFloat(BforeRmvTableRowCount)-2);
                        var mode = "remove";
                        Loadtable(mode);

                        $noCon("#datatable_fixed_column_info").hide();
                        return true;
                    }
                    else {
                        return false;
                    }
                });
             




            }
            // return false;
            function isNumberAmount(evt, textboxid) {
     
                evt = (evt) ? evt : window.event;
                var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                var charCode = (evt.which) ? evt.which : evt.keyCode;
                //  alert(textboxid);
                var txtPerVal = document.getElementById(textboxid).value;
                // alert(txtPerVal);
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
                else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                    return true;

                }
                    // . period and numpad . period
                else if (keyCodes == 190 || keyCodes == 110) {
                    var ret = true;
                    if (textboxid == textboxid) {
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
                        //alert("55");
                        return false;
                    }

                }

                else {
                    var ret = true;
                    if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                        ret = false;
                    }
                    return ret;
                }
            }
            function addCommas(textboxid) {
                if (document.getElementById(textboxid) != undefined)
                    nStr = document.getElementById(textboxid).value;
                else
                    nStr = textboxid;
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


                if (document.getElementById(textboxid) != undefined) {
                    if (isNaN(x2))
                        document.getElementById('' + textboxid + '').value = x1;
                        //return x1;
                    else
                        document.getElementById('' + textboxid + '').value = x1 + "." + x2;
                    // return x1 + "." + x2;

                }
            }
            function addCommasWithval(nStr) {

                nStr += '';
                var x = nStr.split('.');
                var x1 = x[0];
                var x2 = x[1];
                //var a = document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value;
                //alert('hi'+a);
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
            function AmountCheckWithVal(textboxid, txtPerVal) {

                if (txtPerVal == "") {
                    return false;
                }
                else {
                    if (!isNaN(txtPerVal) == false) {
                        $noCon4(textboxid).val('');
                        document.getElementById('' + textboxid + '').value = "";
                        return false;
                    }
                    else {
                        if (txtPerVal < 0) {
                            $noCon4(textboxid).val('');
                        
                            return false;
                        }
                        var amt = parseFloat(txtPerVal);
                        var num = amt;
                        var n = 0;
                        // for floatting number adjustment from corp global
                        var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                        if (FloatingValue != "") {
                            var n = num.toFixed(FloatingValue);
                        }
                        $noCon4(textboxid).val(n);
                        if ($noCon4(textboxid).val() == 0) {
                            $noCon4(textboxid).val('');
                        }

                    }
                }
            }


            function AmountCheck(textboxid) {
                if (document.getElementById(textboxid) != undefined)
                    var txtPerVal = (document.getElementById(textboxid).value).split(',').join('');
                else
                {
                    var txtPerVal = $noCon4(textboxid).val();
                    AmountCheckWithVal(textboxid,txtPerVal)
                    return false;;
                }
                if (txtPerVal == "") {
                    return false;
                }
                else {
                    if (!isNaN(txtPerVal) == false) {
                        document.getElementById('' + textboxid + '').value = "";
                        return false;
                    }
                    else {
                        if (txtPerVal < 0) {
                            document.getElementById('' + textboxid + '').value = "";
                            return false;
                        }
                        var amt = parseFloat(txtPerVal);
                        var num = amt;
                        var n = 0;
                        // for floatting number adjustment from corp global
                        var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                        if (FloatingValue != "") {
                            var n = num.toFixed(FloatingValue);
                        }
                        document.getElementById('' + textboxid + '').value = addCommasWithval(n);
                        if (document.getElementById('' + textboxid + '').value == 0)
                        {
                            document.getElementById('' + textboxid + '').value = "";
                           }

                    }
                }
            }
            function PaidDateValid(textboxid) {
                var index = textboxid.split("_");
                var textbox = index[0];
                index = index[1];
                var CurrentDate = document.getElementById("<%=Hiddentxtefctvedate.ClientID%>").value;

                var arrDatePickerDate1 = CurrentDate.split("/");
                CurrentDate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
            
                var TodayDate = document.getElementById("<%=Hiddencurrentdate.ClientID%>").value;
                var arrDatePickerDate1 = TodayDate.split("-");
                TodayDate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

                var SelectedDate = document.getElementById(textboxid).value;
                                                                
                var arrCurrentDate = SelectedDate.split("/");
                var Paiddate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);
                                                                       
          
                //if (Paiddate < CurrentDate || Paiddate > TodayDate) {
                if (Paiddate < CurrentDate ) {
                    $noCon4(window).scrollTop(0);
                    if (Paiddate < TodayDate)
                        $noCon4("#Warningalert").html("Date Cannot be lower than Effective date");
                   // else

                     //   $noCon4("#Warningalert").html("Date Cannot be grater than Current date");
                    $noCon4("#Warningalert").fadeTo(2000, 500).slideUp(500, function () {

                      //  $noCon4("#txtefctvedate").focus();
                    });
                    $noCon4("#Warningalert").alert();
                    document.getElementById(textboxid).value="";
               
                    $noCon4("#"+textboxid+"").css({
                        "border": "1px solid red",
                        "background": ""
                    });

                }

                if (index != 0)
                {
                    index = parseFloat(index - 1);
               
                    var textboid = textbox +"_"+ index
                    var Prevs = document.getElementById(textboid).value;
               
                    var PrevstDate = Prevs.split("/");
                    var PrevsDate = new Date(PrevstDate[2], PrevstDate[1] - 1, PrevstDate[0]);
              
                    if (PrevsDate > Paiddate) {

                        $noCon4(window).scrollTop(0);
                        $noCon4("#Warningalert").html("Date Cannot be grater than Previous date");
                        $noCon4("#Warningalert").fadeTo(2000, 1000).slideUp(1000, function () {

                            //$noCon4(textboid).focus();
                        });
                        $noCon4("#Warningalert").alert();
                        document.getElementById(textboxid).value = "";

                        $noCon4("#" + textboxid + "").css({
                            "border": "1px solid red",
                            "background": ""
                        });

                    }
                }

                validateInstallmentlistafterchange('no', index);

            }
            
    </script>


    <script>

        function RecalculateAfterpay(evt, text, amountvalue, index) {
           
         
            var total = $noCon4('#cphMain_txtamount').val();
         
            var noinstalmnt = $noCon4('#cphMain_txtinstallemntno').val();

            text = '#' + text;
            var next = index;
            next++;
            var instamnt = text + index;

            var paidamt = 0;
            for (i = 0; i < noinstalmnt; i++) {

                if ($noCon4('#txtamountpaid' + i).val() != "" && !isNaN($noCon4('#txtamountpaid' + i).val())) {
                    paidamt = parseFloat($noCon4('#txtamountpaid' + i).val()) + parseFloat(paidamt);
                }


            }
            var curpaid = $noCon4('#txtamountpaid' + index).val();

            var remainingamt = total;

            total = total.replace(/,/g, "");
            remainingamt = parseFloat(total) - parseFloat(paidamt);

            var calcindex = parseFloat(index) + 1;

            if (calcindex == noinstalmnt) {
                paidamt = parseFloat(paidamt) - parseFloat(curpaid);
                //  remainingamt = parseFloat(total) - parseFloat(paidamt);
                if (paidamt == 0) {

                    remainingamt = total;
                    paidamt = 0;
                }
                if (paidamt != total)
                    $noCon4('#txtamountpaid' + index).val($noCon4('#InstlmntAmnt' + index).val());
            }

            if (parseFloat(remainingamt) < 0) {

               // paidamt = parseFloat(paidamt) - parseFloat(curpaid);
               
                remainingamt = parseFloat(total) - parseFloat(paidamt);
                
                $noCon4('#txtamountpaid' + index).val(remainingamt);
                paidamt = parseFloat(paidamt) + parseFloat(remainingamt);
          
                AmountCheck('#txtamountpaid' + index);
               // addCommas('#txtamountpaid' + index);
            }



            AmountCheck('#txtamountpaid' + index);

            var recalculated = parseFloat(remainingamt) / (noinstalmnt - next);
            //  recalculated = Math.round(recalculated);
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            if (FloatingValue != "") {
                var n = recalculated.toFixed(FloatingValue);
            }
            recalculated = addCommasWithval(n);
           
            noinstalmnt = $noCon4('#cphMain_txtinstallemntno').val();
            if (paidamt >= total) {
                recalculated = 0;

                //  noinstalmnt = 0;
            }



            for (i = next; i < noinstalmnt; i++) {
                $noCon4('#InstlmntAmnt' + i).val(recalculated);
                if (recalculated == 0) {
                    $noCon4("#txtamountpaid" + i).attr("disabled", true);
                    $noCon4("#InstlmntAmnt" + i).attr("disabled", true);
                    $noCon4("#PAiddate_" + i).attr("disabled", true);

                }
                else {

                    $noCon4("#txtamountpaid" + i).attr("disabled", false);
                    $noCon4("#InstlmntAmnt" + i).attr("disabled", true);
                    $noCon4("#PAiddate_" + i).attr("disabled", false);
                }
                if ($noCon4("#txtamountpaid" + i).val() != "" && $noCon4("#txtamountpaid" + i).val() != "0") {

                    if ($noCon4("#PAiddate_" + i).val() == "") {
                        $noCon("#PAiddate_" + i).css({
                            "border": "1px solid red",
                            "background": ""
                        });
                        return false;

                    }
                }







            }
            var prevrow = "";
            for (i = 0; i < index; i++) {
                paidamt = $noCon4('#txtamountpaid' + index).val();
              
                var prev = i;
                prev--;
                if (paidamt != "" && paidamt != "0") {


                    $noCon4("#txtamountpaid" + prev).attr("disabled", true);
                    $noCon4("#InstlmntAmnt" + prev).attr("disabled", true);
                    //$noCon4("#InstlmntAmnt" + next).attr("disabled", false);
                }
                else {
                    prevrow = "enable";

                }
            }
            if (prevrow == "enable")
                $noCon4("#txtamountpaid" + prev).attr("disabled", false);
            //  validatepaylist('no');   
          //  if (recalculated != 0) 
            // validateInstallmentlistafterchange('no',index);
        
           
            balnAmt(index);

        }
        function balnAmt(index) {
            var decPaidamt=0;
            var strBalaneAmt = "";
            var decTotalAmt
           var  paidamt=0;
            var Balncamnt = 0;
            var paidamnt =parseFloat( $noCon4('#txtamountpaid' + index).val());
      
            decPaidamt = decPaidamt + paidamnt;
            decTotalAmt = parseFloat($noCon4('#cphMain_txtamount').val());
           
            //if (index == 0)
            //{
            //    Balncamnt = decTotalAmt - paidamnt;
             
            //    $noCon4("#txtBalanceamount" + index).attr("disabled", false);
            //    $noCon4('#txtBalanceamount' + index).val(Balncamnt);
            //    $noCon4("#txtBalanceamount" + index).attr("disabled", true);
              

            //}
            //else
            //{
                for (i = 0; i <= index; i++) {

                    paidamt =parseFloat(paidamt) +parseFloat( $noCon4('#txtamountpaid' + i).val());
                    
                }
         //   }
           
            Balncamnt = parseFloat(decTotalAmt) - parseFloat(paidamt);
            $noCon4('#txtBalanceamount' + index).val(parseFloat(Balncamnt));
            //alert(paidamt);
            // Balncamnt = decTotalAmt - paidamt;
            //alert(Balncamnt);
           
            //decBalanceAmt = decTotalAmt - decPaidamt;
            //strBalaneAmt = decBalanceAmt;
            //if (paidamnt == 0)
            //{
            //    strBalaneAmt = "";
            //}
        }

        function nozero(textboxid)
        {
            if (document.getElementById('' + textboxid + '').value==0)
                document.getElementById('' + textboxid + '').value = "";
            RemoveTagWithNumber(textboxid);
             
           
        }
        function validateInstallmentlistafterchange(act, index) {

           var noinstalmnt = $noCon4('#cphMain_txtinstallemntno').val();
            paidamt = $noCon4('#txtamountpaid' + index).val();
            paiddate=   $noCon4("#PAiddate_" + index).val() ;
            var next = index;
           // next++;
            if (paidamt != "" && paidamt != "0") {

                if (paiddate == "") {
                    $noCon4("#PAiddate_" + index).css({
                        "border": "1px solid red",
                        "background": ""
                    });
                    $noCon4("#PAiddate_" + index).focus();
                    $noCon4(window).scrollTop(0);
                    $noCon4("#Warningalert").html("Please enter the paid date.");
                    $noCon4("#Warningalert").fadeTo(2000, 500).slideUp(500, function () {

                        $noCon4("#PAiddate_" + index).focus();
                        //$noCon4(window).(0);
                    });

                    $noCon("#Warningalert").alert();
                    // return false;
               
                }
                else {
                    next++;
                    if ($noCon4('#txtamountpaid' + next).val().trim() == "") {
                        $noCon4('#txtamountpaid' + next).prop("disabled", false);
                        $noCon4('#PAiddate_' + next).prop("disabled", false);
                    }

                } if (index != 0) {
                    var prev = index;
                    prev--;
                    if ($noCon4('#txtamountpaid' + prev).val().trim() == "") {
                        $noCon4('#txtamountpaid' + prev).prop("disabled", true);
                        $noCon4('#PAiddate_' + prev).prop("disabled", true);
                    }
                    $noCon4("#PAiddate_" + prev).css({
                        "border": "",
                        "background": ""
                    });
                }
                next++;
                            for (i = next; i < noinstalmnt; i++) {

                                if ($noCon4('#txtamountpaid' + i).val().trim() == "") {
                                    $noCon4('#txtamountpaid' + i).prop("disabled", true);
                                    $noCon4('#PAiddate_' + i).prop("disabled", true);
                                }


                            }
                        } 




               

                    }
                   

                       // $noCon4('#txtamountpaid' + i).prop("disabled", true);
                      //  $noCon4('#PAiddate_' + i).prop("disabled", true);



        
     
    </script>






    <style>
        .datepicker table tr td, .datepicker table tr th {
    text-align: center;
    width: 10px;
    height: 0px;
    border-radius: 0px;
    border: none;
    visibility:visible
}
                .smart-form footer {
    display: block;
    padding: 7px 14px 15px;
    border-top: 0px solid rgba(0,0,0,.1);
    background: rgba(248,248,248,.9);
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

    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />


    <script>
        var $au = jQuery.noConflict();

        $au(function () {
            $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
        });
    </script>
    
</asp:Content>

