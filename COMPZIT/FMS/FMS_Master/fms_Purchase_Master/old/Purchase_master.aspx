<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="Purchase_master.aspx.cs" Inherits="FMS_FMS_Master_Purchase_Matser_Purchase_master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <%--<script src="../../../../js/jQueryUI/jquery-ui.min.js"></script>
    <script src="../../../../js/jQueryUI/jquery-ui.js"></script>--%>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
    <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
    
<%--  Date Functions--%>
    <script>

              function showFromDate() {
                  document.getElementById("cphMain_txtdate").style.borderColor = "";
                  IncrmntConfrmCounter();
                  var orgID = '<%= Session["ORGID"] %>';
                var corptID = '<%= Session["CORPOFFICEID"] %>';
                var jrnlDate = $('#cphMain_txtdate').val().trim();
                var usrID = '<%= Session["USERID"] %>';
                  var RcptDate = $('#cphMain_HiddenUpdatedDate').val().trim();
                 
                 var RefNum = $('#cphMain_HiddenUpdRefNum').val().trim();
                 var Purchaseid = $('#cphMain_HiddenPurchaseid').val().trim();
                 var AcntPrvsn = document.getElementById("<%=HiddenFieldAcntCloseReopenSts.ClientID%>").value
                  var AuditPrvsn = document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value
                if (jrnlDate != "") {

                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "Purchase_master.aspx/CheckAcntCloseSts",
                        data: '{jrnlDate: "' + jrnlDate + '",orgID: "' + orgID + '",corptID: "' + corptID + '",AuditPrvsn: "' + AuditPrvsn + '",AcntPrvsn: "' + AcntPrvsn + '"}',
                        dataType: "json",
                        success: function (data) {
                            if (data.d == "1") {
                                document.getElementById("cphMain_txtdate").style.borderColor = "Red";
                                document.getElementById("cphMain_txtdate").focus();
                                document.getElementById("cphMain_txtdate").value = "";
                                $noCon("#divWarning").html("This action is  denied! Audit is already closed for the selected date.");
                                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                });
                                return false;
                            }
                            else if (data.d == "2") {
                                document.getElementById("cphMain_txtdate").style.borderColor = "Red";
                                document.getElementById("cphMain_txtdate").focus();
                                document.getElementById("cphMain_txtdate").value = "";
                                $noCon("#divWarning").html("This action is  denied! Account is already closed for the selected date.");
                                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                });
                                return false;
                            }
                        }
                    });
                }
                if (jrnlDate != "" && (document.getElementById("<%=HiddenFieldAcntCloseReopenSts.ClientID%>").value == "1" || document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value == "1")) {

                      if (document.getElementById("<%=HiddenRefAccountCls.ClientID%>").value == "1") {
                          $.ajax({
                              type: "POST",
                              async: false,
                              contentType: "application/json; charset=utf-8",
                              url: "Purchase_master.aspx/CheckRefNumber",
                              data: '{jrnlDate: "' + jrnlDate + '",orgID: "' + orgID + '",corptID: "' + corptID + '",usrID: "' + usrID + '",RefNum: "' + RefNum + '",Purchaseid: "' + Purchaseid + '"}',
                              dataType: "json",
                              success: function (data) {
                                  if (data.d != "") {
                                      if (document.getElementById("<%=HiddenRefNum.ClientID%>").value != data.d && RcptDate != "") {
                                         
                                              if (document.getElementById("cphMain_txtRef").value != data.d) {
                                                  ezBSAlert({
                                                      type: "confirm",
                                                      messageText: "This action will change the reference number.Are you sure you want to continue ?",
                                                      alertType: "info"
                                                  }).done(function (e) {
                                                      if (e == true) {
                                                          document.getElementById("cphMain_txtRef").value = data.d;
                                                          document.getElementById("cphMain_HiddenRefNum").value = data.d;
                                                      }
                                                      else {
                                                          document.getElementById("cphMain_txtdate").value = $('#cphMain_HiddenUpdatedDate').val()
                                                          return false;
                                                      }
                                                  });
                                                  return false;
                                              }
                                              else {
                                                  document.getElementById("cphMain_txtRef").value = data.d;
                                              }
                                          }
                                          else {
                                              document.getElementById("cphMain_txtRef").value = data.d;
                                              document.getElementById("cphMain_HiddenRefNum").value = data.d;
                                          }
                                      }
                                  }
                              });
                          }


                      }
                  }
       </script>
 <%--   Exchang Rate--%>
    <script>
        function enableexchangeRate() {

            if (document.getElementById("<%=HiddenCurrncyId.ClientID%>").value != document.getElementById("cphMain_ddlCurrency").value) {
                if (document.getElementById("<%=HiddenInventoryForex.ClientID%>").value == "1") {
                    document.getElementById("DivCurrency").style.display = "";
                    document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "";
                        document.getElementById("DivForex_Amount_Tl").style.display = "";

                    }
                    else {
                        document.getElementById("DivCurrency").style.display = "none";
                        document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "none";
                                 document.getElementById("<%=txtExchangeRate.ClientID%>").value = "";
                        document.getElementById("DivForex_Amount_Tl").style.display = "none";
                        if (document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value != "") {
                            document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value = document.getElementById("<%=HiddenDefaultCurrency.ClientID%>").value;
                        }
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenInventoryForex.ClientID%>").value == "1") {
                    document.getElementById("DivCurrency").style.display = "";
                }
                else {
                    document.getElementById("DivCurrency").style.display = "none";
                }
                document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "none";
                document.getElementById("<%=txtExchangeRate.ClientID%>").value = "";
                document.getElementById("DivForex_Amount_Tl").style.display = "none";
            }


            var CurrencyId = document.getElementById("<%=ddlCurrency.ClientID%>").value;
            if (CurrencyId == "307") {
                document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value = "INR";
                }
                else if (CurrencyId == "308") {
                    document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value = "OMR";
                }
                else if (CurrencyId == "309") {
                    document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value = "USD";
                }

        var DftCurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
            if (CurrencyId == DftCurrencyId) {
                document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "none";
                }
                else if (CurrencyId == "--SELECT CURRENCY--") {
                    document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "none";
                }
                else {
                    document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "";
                }

            CalculateNetTotal(0);
        }
    </script>

  <%--  Confirmation Alerts--%>
    <script>
        function ConfirmReopen() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to reopen this purchase?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    //SalesValidate();
                    // alert();
                    document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value = "";
                   document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value = "";
                   document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value = "";
                   document.getElementById("<%=btnReopen1.ClientID%>").click();
               } else {
                   return false;
               }
           });
           return false;

       }
       function OpenSupplier() {
           if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {

                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure you want to create new supplier?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value = "";
                            document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value = "";
                            document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value = "";

                            var SupplierName = "";
                            var nWindow = window.open('../fms_Supplier/fms_Supplier.aspx?RFGP=SUL&SULMSTR=' + SupplierName + '', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                            nWindow.focus();
                        } else {
                            return false;
                        }
                    });
                }
                return false;



            }
        function GetValueFromChildProject(myVal) {
                if (myVal != '') {
                    PostbackFunProject(myVal);
                }
            }
        function PostbackFunProject(myValPrj) {

            document.getElementById("<%=HiddenSupplierId.ClientID%>").value = myValPrj;
            document.getElementById("<%=btnSupplier.ClientID%>").click();

            return false;
        }
           
            function OpenProduct(RowNum) {
                if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {

                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure you want to create new product?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            var SupplierName = "";// <a href="../../../Master/gen_Product_Master/gen_Product_Master.aspx">../../../Master/gen_Product_Master/gen_Product_Master.aspx</a>
                            var nWindow = window.open('/Master/gen_Product_Master/gen_Product_Master.aspx?PRCHS=PRDCT&ROW=' + RowNum + '', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                            nWindow.focus();
                        } else {
                            return false;
                        }
                    });
                }
                return false;
            }
            function GetValueFromProduct(myVal, Row) {
                if (myVal != '' && Row != '') {
                    PostbackFunProduct(myVal, Row);
                }
            }
            function PostbackFunProduct(myValPrj, num) {
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                var orgid = '<%= Session["ORGID"] %>';
                var userid = '<%= Session["USERID"] %>';
                $noCon.ajax({
                    type: "POST",
                    url: "Purchase_master.aspx/RedPrdtName",
                    data: '{intProductId:"' + myValPrj + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d != "0") {
                            $noCon("#ddlProduct_" + num).val(response.d);
                            $noCon("#txtproductId" + num).val(myValPrj);
                            $noCon("#ProductId" + num).val(myValPrj);
                            $noCon("#txtproductName" + num).val(response.d);
                            ProductsLoad(num);
                            $noCon("#ddlProduct_" + num).select();
                            ChangeProduct(num);
                        }
                        else {

                        }



                    },
                    failure: function (response) {
                    }
                });
                return false;
            }
        </script>
     <script>
         function OpenPrint(StrId) {
             var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var PreparedBy = '<%= Session["USERFULLNAME"] %>';
            var saleId = document.getElementById("<%=HiddenPurchaseId1.ClientID%>").value
             if (corptID != "" && corptID != null && orgID != "" && orgID != null && saleId != "") {
                 $.ajax({
                     type: "POST",
                     async: false,
                     contentType: "application/json; charset=utf-8",
                     url: "Purchase_master.aspx/PrintPDF",
                     data: '{saleId: "' + saleId + '",orgID: "' + orgID + '",corptID: "' + corptID + '",PreparedBy: "' + PreparedBy + '"}',
                     dataType: "json",
                     success: function (data) {
                         if (data.d != "") {
                             if (data.d != "false") {
                                 window.open(data.d, '_blank');
                             }
                         }
                         else {
                             PrintVersnError();
                         }
                     }
                 });
             }
             else {
                 window.location = '/Security/Login.aspx';
             }
            return false;
        }
        var $au = jQuery.noConflict();

        $au(function () {
            $au('#cphMain_ddlCustomerLdgr').selectToAutocomplete1Letter();
            //$au("#cphMain_ddlCustomer").focus();
        });
        //$au(document).ready(function () {
        //    $au("#cphMain_ddlCustomer").focus();
        //});
        //  var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

                var prm = Sys.WebForms.PageRequestManager.getInstance();
                //  prm.add_initializeRequest(InitializeRequest);
                prm.add_endRequest(EndRequest);

                $au('#cphMain_ddlCustomerLdgr').selectToAutocomplete1Letter();
                //  $au('#cphMain_ddlLeavTyp').selectToAutocomplete1Letter();

                $au('form').submit(function () {

                    //   alert($au(this).serialize());


                    //   return false;
                });
            });
        })(jQuery);

        //function InitializeRequest(sender, args) {
        //}

        function EndRequest(sender, args) {
            CheckSupplierType();
            // after update occur on UpdatePanel re-init the Autocomplete
            $au('#cphMain_ddlCustomerLdgr').selectToAutocomplete1Letter();
          
            $noCon("div#divddlCustomerLdgr input.ui-autocomplete-input").focus();
            $noCon("div#divddlCustomerLdgr input.ui-autocomplete-input").select();

            var StartDate = document.getElementById("<%=HiddenStartDate.ClientID%>").value;
            var curentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value;
            $noCon('#datepicker2').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                startDate: StartDate,
                endDate: curentDate,
            });
            // $au('#cphMain_ddlEmployee').autocomplete("destroy");

            if (document.getElementById("<%=HiddenCurrncyId.ClientID%>").value != document.getElementById("cphMain_ddlCurrency").value) {
                if (document.getElementById("<%=HiddenInventoryForex.ClientID%>").value == "1") {
                    document.getElementById("DivCurrency").style.display = "";
                    document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "";
                            document.getElementById("DivForex_Amount_Tl").style.display = "";

                        }
                        else {
                            document.getElementById("DivCurrency").style.display = "none";
                            document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "none";
                        document.getElementById("DivForex_Amount_Tl").style.display = "none";
                        if (document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value != "") {
                            document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value = document.getElementById("<%=HiddenDefaultCurrency.ClientID%>").value;
                        }
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenInventoryForex.ClientID%>").value == "1") {
                    document.getElementById("DivCurrency").style.display = "";
                }
                else {
                    document.getElementById("DivCurrency").style.display = "none";
                }
                document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "none";
                document.getElementById("DivForex_Amount_Tl").style.display = "none";
            }


      
        }

        function curncyChangeFunt(Id) {

            if (Id == 0) {
            }
            else {
                IncrmntConfrmCounter();
            }

            if (document.getElementById("cphMain_ddlCurrency").value != 0) {

                var ddlcrncyId = document.getElementById("cphMain_ddlCurrency").value;
                if (document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value == document.getElementById("cphMain_ddlCurrency").value || document.getElementById("cphMain_ddlCurrency").value == "--SELECT CURRENCY--") {

                    document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "none";
                    document.getElementById("DivForex_Amount_Tl").style.display = "none";
                    // document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value = 
                }
                else {
                    document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "block";
                    document.getElementById("DivForex_Amount_Tl").style.display = "block";

                }

                if (document.getElementById("cphMain_ddlCurrency").value != "--SELECT CURRENCY--") {

                    var corpid = '<%= Session["CORPOFFICEID"] %>';
                        var orgid = '<%= Session["ORGID"] %>';
                        var userid = '<%= Session["USERID"] %>';
                        //  var per
                        // alert(ddlAccntId);
                        // alert(userid);
                        // alert(orgid);
                        // alert(corpid);
                        $noCon.ajax({
                            type: "POST",
                            url: "Purchase_master.aspx/RedCurencyAbrvtn",
                            data: '{intCrncyId:"' + ddlcrncyId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" }',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                //  alert(response.d);

                                if (response.d != "0") {
                                    //   alert( response.d);
                                     document.getElementById("cphMain_lblCrncyAbrvtn").innerHTML = response.d;
                                    document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value = response.d;

                                    CalculateNetTotal(0);
                                    if (document.getElementById("cphMain_divExchangeRate").style.display != "none") {
                                        document.getElementById("<%=HiddenCurrcyFxAbbrvn.ClientID%>").value = response.d;


                                    }
                                    else {
                                     
                                    }
                                    addRowtable = document.getElementById("TableaddedRows");

                                    var RowCount = addRowtable.rows.length;
                                    //alert(RowCount);
                                    //    BlurValue(RowCount, null);
                                }



                                else {

                                }



                            },
                            failure: function (response) {

                            }


                        });

                    }



                }

            }
          
        </script>
      <script>

          //function loadTableDesg() {

          //    $noCon(function () {
          //        $noCon('#dialog_simple').dialog({
          //            autoOpen: false,
          //            width: 600,
          //            resizable: false,
          //            modal: true,
          //            title: "Remark",
          //        });
          //    });
          //}

       
          $noCon = jQuery.noConflict();
          var $noCon1 = jQuery.noConflict();
          $noCon1(window).load(function () {
              document.getElementById("cphMain_txtOrder").focus();
              localStorage.clear();
              var Id = 0;
              curncyChangeFunt(Id);
              CheckSupplierType();
              if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                    document.getElementById("EnableTax").style.display = "";
                    document.getElementById("DisableTax").style.display = "none";
                    document.getElementById("divTaxTotal").style.display = "";

                }
                else {
                    document.getElementById("EnableTax").style.display = "none";
                    document.getElementById("DisableTax").style.display = "";
                    document.getElementById("divTaxTotal").style.display = "none";

                }
                if (document.getElementById("<%=HiddenCurrncyId.ClientID%>").value != document.getElementById("cphMain_ddlCurrency").value) {
                    if (document.getElementById("<%=HiddenInventoryForex.ClientID%>").value == "1") {
                        document.getElementById("DivCurrency").style.display = "";
                        document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "";
                        document.getElementById("DivForex_Amount_Tl").style.display = "";

                    }
                    else {
                        document.getElementById("DivCurrency").style.display = "none";
                        document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "none";
                        document.getElementById("DivForex_Amount_Tl").style.display = "none";
                        if (document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value != "") {
                            document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value = document.getElementById("<%=HiddenDefaultCurrency.ClientID%>").value;
                        }
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenInventoryForex.ClientID%>").value == "1") {
                        document.getElementById("DivCurrency").style.display = "";
                    }
                    else {
                        document.getElementById("DivCurrency").style.display = "none";
                    }
                    document.getElementById("<%=divExchangeRate.ClientID%>").style.display = "none";
                    document.getElementById("DivForex_Amount_Tl").style.display = "none";
                }
                document.getElementById("<%=txtGrossTotal.ClientID%>").disabled = true;
                document.getElementById("<%=txtNetTotal.ClientID%>").disabled = true;
                document.getElementById("<%=txtTaxTotal.ClientID%>").disabled = true;
                document.getElementById("<%=txtTotalWithExchngRate.ClientID%>").disabled = true;
              document.getElementById("<%=btnConfirm1.ClientID%>").style.display = "none";
              document.getElementById("<%=btnFloatConfirm1.ClientID%>").style.display = "none";
            

                var EditVal = document.getElementById("<%=HiddenEdit.ClientID%>").value;
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
                            if (json[key].PURCHSE_ID != "") {
                                EditListRows(json[key].PURCHSE_ID, json[key].PRODUCT_ID, json[key].PRODUCTROW, json[key].SLNO, json[key].QUANTITY, json[key].RATE, json[key].DISPER, json[key].DISAMT, json[key].TAX, json[key].TAXAMT, json[key].PRICE, json[key].TAXTEXT, json[key].TAXPERCENTAGE, json[key].PRODUCT_NAME, json[key].PRDCT_CHCK, json[key].PURCHS_PRDUCT_REMARK, json[key].COSTCENTRE);
                            }
                        }
                    }
                }

                if (EditVal == "") {
                    addMoreRows();
                }
                // $noCon("div#divddlCustomerLdgr input.ui-autocomplete-input").focus();
                buttnVisibile();
                CalculateNetTotal(0);

                var EditAttachment = document.getElementById("<%=HiddenEditAttachment.ClientID%>").value;
                if (EditAttachment != "" && EditAttachment != "[]") {
                    var find2 = '\\"\\[';
                    var re2 = new RegExp(find2, 'g');
                    var res2 = EditAttachment.replace(re2, '\[');

                    var find3 = '\\]\\"';
                    var re3 = new RegExp(find3, 'g');
                    var res3 = res2.replace(re3, '\]');
                    var json = $noCon.parseJSON(res3);
                    for (var key in json) {
                        if (json.hasOwnProperty(key)) {
                            if (json[key].PURCHSE_ID != "") {
                                EditFileUpload(json[key].PURCHSE_ID, json[key].ATTACH_ID, json[key].FIMENAME, json[key].ACT_FILENAME);
                            }
                        }
                    }
                }
                if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                   

                    AddFileUploadVhcl();
                }
                buttnVisibileFileUpload();
                CheckAdAttachment();
            });
        </script>

        
        <script>
            function CheckSupplierType() {
                if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {


                    if (document.getElementById("<%=cbxExtngSplr.ClientID%>").checked == true) {
                        document.getElementById("SupllierAdd").style.display = "block";
                        document.getElementById("<%=txtsplrName.ClientID%>").disabled = true;
                        document.getElementById("<%=txtAddress1.ClientID%>").disabled = true;
                        document.getElementById("<%=txtAddress2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtAddress3.ClientID%>").disabled = true;
                        document.getElementById("<%=txtsplrName.ClientID%>").disabled = true;
                        document.getElementById("<%=txtAddress1.ClientID%>").disabled = true;
                        document.getElementById("<%=txtAddress2.ClientID%>").disabled = true;
                        document.getElementById("<%=txtAddress3.ClientID%>").disabled = true;
                        document.getElementById("<%=txtContactNumber.ClientID%>").disabled = true;

                        document.getElementById("<%=txtsplrName.ClientID%>").value = "";
                        document.getElementById("<%=txtAddress1.ClientID%>").value = "";
                        document.getElementById("<%=txtAddress2.ClientID%>").value = "";
                        document.getElementById("<%=txtAddress3.ClientID%>").value = "";
                        document.getElementById("<%=txtsplrName.ClientID%>").value = "";
                        document.getElementById("<%=txtAddress1.ClientID%>").value = "";
                        document.getElementById("<%=txtAddress2.ClientID%>").value = "";
                        document.getElementById("<%=txtAddress3.ClientID%>").value = "";
                        document.getElementById("<%=txtContactNumber.ClientID%>").value = "";


                        $au('input.grp').attr('disabled', false);

                      
                        // document.getElementById("<%=ddlCustomerLdgr.ClientID%>").disabled = false;


                    }
                    else {
                        document.getElementById("SupllierAdd").style.display = "block";
                        document.getElementById("<%=txtsplrName.ClientID%>").disabled = false;
                        document.getElementById("<%=txtAddress1.ClientID%>").disabled = false;
                        document.getElementById("<%=txtAddress2.ClientID%>").disabled = false;
                        document.getElementById("<%=txtAddress3.ClientID%>").disabled = false;
                        document.getElementById("<%=txtContactNumber.ClientID%>").disabled = false;

                        $au('input.grp').attr('disabled', 'disabled');
                        //   $au("value", "--SELECT SUPPLIER --");
                        document.getElementById("<%=ddlCustomerLdgr.ClientID%>").value = "--SELECT SUPPLIER --";
                        $au('input.grp').val("--SELECT SUPPLIER --");

                    }
                }
                if (document.getElementById("<%=HiddenAccountSpecificStatus.ClientID%>").value != "1") {
                    document.getElementById("SupllierAdd").style.display = "block";

                }
            }
    </script>

        <script>
            var submit = 0;

            function CheckIsRepeatSubmit() {
                if (submit++ > 1) {

                    return false;
                }
                else {

                    return true;
                }
            }
            function CheckSubmitZero() {
                submit = 0;
            }
       
          function SundryDebtorSelect() {
              $noCon("#divWarning").html("Please define the primary account group for supplier before creating new purchase ");
              $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
              });
             
          }
          function PrintVersnError() {
              $noCon("#divWarning").html("Please select a version for printing from account setting.");
              $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
              });
             
              return false;
          }

          function StatusError() {
              $noCon("#divWarning").html("Cannot be confirmed as status is inactive.");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });

              // ddlAccountName.Focus();
              return false;
          }

          //function Error() {
          //    $noCon("#divWarning").html("Some error occured!");
          //    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
          //    });
          //    return false;
          //}


          function OpenComment(StrId) {
              RemarkShow(StrId);
              //  document.getElementById("divErrMsgCnclRsn").style.display = "none";
              //  document.getElementById('txtProductRemark' + StrId).style.borderColor = "";
              //  document.getElementById('txtProductRemark' + StrId).value = "";
            
              $('#dialog_simple').modal('show');
              $('#dialog_simple').on('shown.bs.modal', function () {

                document.getElementById('txtProductRemark'+ StrId).focus();
              });

              return false;
          }
          function AddRemarks(StrId) {
            
             // if (document.getElementById('txtProductRemark' + StrId).value != "")
              document.getElementById('tdProductRemark' + StrId).innerHTML = document.getElementById('txtProductRemark' + StrId).value.trim();
              //document.getElementById('remarktxt'+StrId).value = document.getElementById('tdProductRemark' + StrId).innerHTML;
              document.getElementById('remarktxt' + StrId).value = document.getElementById('tdProductRemark' + StrId).innerHTML;
            
             
            
              $('#dialog_simple').modal('hide');

              
              $('#dialog_simple').on('hidden.bs.modal', function () {
                  $('#DivAddComment_' + StrId).focus();
              });

          }

        function CloseCancelView(RowId) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close  without add remark?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    $('#dialog_simple').modal('hide');
                    $('#dialog_simple').on('hidden.bs.modal', function () {
                        $('#DivAddComment_' + RowId).focus();
                    });
                }
                else {
                               
                    $('#dialog_simple').modal('show');
                    $('#dialog_simple').on('shown.bs.modal', function () {
                        document.getElementById("txtProductRemark" + RowId).focus();
                    });
                    return false;
                }
            });
            return false;
        }
    </script>
    <script>
        var $aa = jQuery.noConflict();
        $aa(function () {
            $aa.widget("custom.combobox", {
                _create: function () {
                    this.wrapper = $aa("<span>")
                      .addClass("custom-combobox " + $aa(this.element).prop("id"))
                      .insertAfter(this.element);

                    this.element.hide();
                    this._createAutocomplete();
                    // this._createShowAllButton();
                },




                _createAutocomplete: function () {

                    var selected = this.element.children(":selected"),

                      value = selected.val() ? selected.text() : "";
                    var idd = $aa(this.element).prop("id");
                    this.input = $aa("<input>")
                      .appendTo(this.wrapper)
                      .val(value)
                      .attr("title", "")
                      .attr("placeholder", "-Select Product-")
                        //danger custom function here
                   // attr("change","ChangeProduct()")
                        .attr("onkeydown", "return isTagDes(event);")
                         .attr("onkeypress", "return DisableEnter(event);")
                       // .attr("onchange", "return ChangeProduct(" + idd + ");")
                        //.attr("tabindex", 7)
                      //.addClass( "custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left" )
                      .addClass("form-control  ui-autocomplete-input " + $aa(this.element).prop("id"))
                      .autocomplete({
                          delay: 0,
                          minLength: 0,

                          select: function (event, ui) {


                              // alert(idd);
                              // loadDataToModule();

                          },
                          change: function (event, ui) {

                              ChangeProduct(idd);              //CHECKKKKKKKKK
                              // alert("SELECTTTT"+idd);
                              //  ChangeProduct( idd );
                              // alert(this.val());
                          },

                          source: $aa.proxy(this, "_source")


                      })

                      .tooltip({
                          classes: {
                              "ui-tooltip": "ui-state-highlight"
                          }
                      });

                    this._on(this.input, {
                        autocompleteselect: function (event, ui) {
                            ui.item.option.selected = true;
                            this._trigger("select", event, {
                                item: ui.item.option

                            });

                            $aa(".selector").autocomplete({
                                autoFocus: true
                            });
                            //$aa(".selector").autocomplete({
                            //    focus: function (event, ui) { }
                            //});
                            // alert("fgdf");

                            //var valuesSel = "";
                            // ChangeProduct(ui.item.option.val());
                            // $(".ddlProduct_" + x).focus();
                        },



                        autocompletechange: "_removeIfInvalid"
                    });

                    //$aa(".combobox_ui_ddlProduct").change(function () {
                    //    alert(this.value);
                    //});


                },



                _source: function (request, response) {
                    var matcher = new RegExp($aa.ui.autocomplete.escapeRegex(request.term), "i");
                    response(this.element.children("option").map(function () {
                        var text = $aa(this).text();
                        if (this.value && (!request.term || matcher.test(text)))
                            return {
                                label: text,
                                value: text,
                                option: this
                            };
                    }));
                },

                _removeIfInvalid: function (event, ui) {

                    // Selected an item, nothing to do
                    if (ui.item) {

                        //  alert(ui.item.label);
                        return;
                    }

                    // Search for a match (case-insensitive)
                    var value = this.input.val(),
                      valueLowerCase = value.toLowerCase(),
                      valid = false;
                    this.element.children("option").each(function () {
                        if ($aa(this).text().toLowerCase() === valueLowerCase) {
                            this.selected = valid = true;
                            return false;
                        }
                    });

                    // Found a match, nothing to do
                    if (valid) {

                        return;
                    }

                    // Remove invalid value
                    this.input
                      .val("")

                    //.attr( "title", value + " didn't match any item" )
                    //.tooltip( "open" );
                    this.element.val("");

                    var selected = this.element.children(":selected"),

                    value = selected.val() ? selected.text() : "";
                    var idd = $aa(this.element).prop("id");
                    // ChangeProduct(idd);
                    //this._delay(function() {
                    //    this.input.tooltip( "close" ).attr( "title", "" );
                    //}, 2500 );
                    this.input.autocomplete("instance").term = "";
                },

                _destroy: function () {
                    this.wrapper.remove();
                    this.element.show();
                }
            });

            //$( "#combobox" ).combobox();
            //$( "#toggle" ).on( "click", function() {
            //    $( "#combobox" ).toggle();
            //});


        });

        //$aa(function () {

        //    $aa(".combobox_ui_ddlProduct").change(function () {
        //        alert(this.value);
        //    });
        //});





    </script>




     <script type="text/javascript" language="javascript">




        

         </script>
    <script>

        //--------------Cost centre------------

       

        function CostCentr(x, y, CostCenterId) {
           
                $("#divProduct_" + x + "> input").css("borderColor", "");
                if ((document.getElementById("ddlProduct_" + x).value != "" && document.getElementById("ddlProduct_" + x).value != 0)) {
                    var LedgerId = document.getElementById("ddlProduct_" + x).value;
                    
                    if (document.getElementById("tdCostCenterDtls" + x).value != "") {
                        var CstCntrDtl = document.getElementById("tdCostCenterDtls" + x).value;
                        var splitrow = CstCntrDtl.split("$");
                        for (var Cst = 0; Cst < splitrow.length; Cst++) {
                            var splitEach = splitrow[Cst].split("%");
                           
                            if (splitEach[0] != "") {
                                FunctionQustn(x, currnty, splitEach[0], splitEach[2], splitEach[3]);
                                document.getElementById("ddlCostCtrId_" + x + '' + currnty).value = splitEach[0];
                                document.getElementById("TxtCstctrAmount_" + x + '' + currnty).value = splitEach[1];
                                addCommas("TxtCstctrAmount_" + x + '' + currnty);
                                document.getElementById("TxtActCstctrAmount_" + x + '' + currnty).value = splitEach[1];
                                document.getElementById("tdInxQstn" + x + '' + currnty).value = x + '' + currnty;
                                document.getElementById("btnCostCenter_" + x + '' + currnty).style.opacity = "0.3";
                            }
                        }
                    }
                    else {
                        
                        FunctionQustn(x, y, CostCenterId, CostCenterId, CostCenterId);
                    }
                    var Price = "";
                    if (document.getElementById("txtPrice" + x).value != "") {
                        Price = document.getElementById("txtPrice" + x).value;
                    }
                    addCommasSummry(Price);
                    document.getElementById("BtnPopupCstCntr").click();
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    document.getElementById("LedgerAmtInModal" + x).innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                    if (document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value != "") {
                        document.getElementById("LedgerAmtInModal" + x).innerText = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value;
                    }
                }
                if (document.getElementById("ddlProduct_" + x).value == "" || document.getElementById("ddlProduct_" + x).value == 0) {
                    $("#divProduct_" + x + "> input").css("borderColor", "red");
                    $("#divProduct_" + x + "> input").focus();
                    $("#divProduct_" + x + "> input").select();
                }
            }

            function buttnVisibile(x, Check) {

                var table = document.getElementById("TableaddedRows");
                var x = table.rows.length;
                var TableRowCount = document.getElementById("TableaddedRows").rows.length;
                if (TableRowCount != 0) {
                    var idlast = $noCon('#TableaddedRows  tr:last').attr('id');
                    if (idlast != "") {
                        var res = idlast.split("_");
                        document.getElementById("SpanAdd" + res[1]).disabled = false;
                        document.getElementById("SpanAdd" + res[1]).style.pointerEvents = 'auto';
                        BlurValue(res[1], 'txtDisAmt');
                    }
                }
                if (x != 0) {
                    if (Check == "0") {
                        var TableRowCount1 = document.getElementById("TableAddQstnCostCenter" + x).rows.length;
                        if (TableRowCount1 != 0) {
                            var idlast1 = $noCon('#TableAddQstnCostCenter' + x + ' tr:last').attr('id');
                            if (idlast1 != "") {
                                var res1 = idlast1.split("_");
                                document.getElementById("tdInxQstn" + res1[1]).value = "";
                                document.getElementById("btnCostCenter_" + res1[1]).style.opacity = "1";
                            }
                        }
                    }
                }
            }

            function focusCostCentre(Rowid) {

                $("#divCostGrp1" + Rowid + " > input").focus();
                $("#divCostGrp1" + Rowid + " > input").select();
            }

            

            function FillddlCostCenter(rowCountX, rowCountY, costId) {
               
              
                var ddlTestDropDownListXML1 = "";
                ddlTestDropDownListXML1 = $noCon("#ddlRecptCosCtr_" + rowCountX + "" + rowCountY);
                var intOrgID = '<%= Session["ORGID"] %>';
              var intCorrpID = '<%= Session["CORPOFFICEID"] %>';
                var tableName = "dtTableCostCenter";
             
              if (document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value != "0") {
                       ddlLed = document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value;
                       var OptionStart = $noCon("<option>--SELECT--</option>");
                       OptionStart.attr("value", 0);
                       ddlTestDropDownListXML1.append(OptionStart);
                       $noCon(ddlLed).find(tableName).each(function () {
                           var OptionValue = $noCon(this).find('COSTCNTR_ID').text();
                           var OptionText = $noCon(this).find('COSTCNTR_NAME').text();
                           var option = $noCon("<option>" + OptionText + "</option>");
                           option.attr("value", OptionValue);
                           ddlTestDropDownListXML1.append(option);
                           if (costId != "" && costId != null) {
                              
                               var arrayProduct = JSON.parse("[" + costId + "]");
                               $noCon("#ddlRecptCosCtr_" + rowCountX + "" + rowCountY).val(arrayProduct);
                           }
                       });
                   }
              else {
                
                       var OptionStart = $noCon("<option>--SELECT--</option>");
                       OptionStart.attr("value", 0);
                       ddlTestDropDownListXML1.append(OptionStart);
                   }
               }

               function FillddlAcntGrp1(rowCountX, rowCountY, COSTCNTR_ID) {
                   var ddlTestDropDownListXML1 = "";
                   ddlTestDropDownListXML1 = $noCon("#ddlRecptCosGrp1_" + rowCountX + "" + rowCountY);
                   var intOrgID = '<%= Session["ORGID"] %>';
              var intCorrpID = '<%= Session["CORPOFFICEID"] %>';
              var tableName = "dtTableCostCenter";
              if (document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value != "0") {
                    ddlLed = document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value;
                    var OptionStart = $noCon("<option>--SELECT--</option>");
                    OptionStart.attr("value", 0);
                    ddlTestDropDownListXML1.append(OptionStart);
                    $noCon(ddlLed).find(tableName).each(function () {
                        var OptionValue = $noCon(this).find('COSTGRP_ID').text();
                        var OptionText = $noCon(this).find('COSTGRP_NAME').text();
                        var option = $noCon("<option>" + OptionText + "</option>");
                        option.attr("value", OptionValue);
                        ddlTestDropDownListXML1.append(option);
                    });
                }
                else {
                    var OptionStart = $noCon("<option>--SELECT--</option>");
                    OptionStart.attr("value", 0);
                    ddlTestDropDownListXML1.append(OptionStart);
                }
                if (COSTCNTR_ID != "" && COSTCNTR_ID != null && COSTCNTR_ID != 0 && COSTCNTR_ID != "null") {
                    var arraycostcntr_VALUES = JSON.parse("[" + COSTCNTR_ID + "]");
                    $noCon("#ddlRecptCosGrp1_" + rowCountX + "" + rowCountY).val(arraycostcntr_VALUES);
                }
            }

            function FillddlAcntGrp2(rowCountX, rowCountY, COSTCNTR_ID) {
                var ddlTestDropDownListXML1 = "";
                ddlTestDropDownListXML1 = $noCon("#ddlRecptCosGrp2_" + rowCountX + "" + rowCountY);
                var intOrgID = '<%= Session["ORGID"] %>';
                var intCorrpID = '<%= Session["CORPOFFICEID"] %>';
                var tableName = "dtTableCostCenter";
                if (document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value != "0") {
                    ddlLed = document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value;
                    var OptionStart = $noCon("<option>--SELECT--</option>");
                    OptionStart.attr("value", 0);
                    ddlTestDropDownListXML1.append(OptionStart);
                    $noCon(ddlLed).find(tableName).each(function () {
                        var OptionValue = $noCon(this).find('COSTGRP_ID').text();
                        var OptionText = $noCon(this).find('COSTGRP_NAME').text();
                        var option = $noCon("<option>" + OptionText + "</option>");
                        option.attr("value", OptionValue);
                        ddlTestDropDownListXML1.append(option);
                    });
                }
                else {
                    var OptionStart = $noCon("<option>--SELECT--</option>");
                    OptionStart.attr("value", 0);
                    ddlTestDropDownListXML1.append(OptionStart);
                }
                if (COSTCNTR_ID != "" && COSTCNTR_ID != null && COSTCNTR_ID != 0 && COSTCNTR_ID != "null") {
                    var arraycostcntr_VALUES = JSON.parse("[" + COSTCNTR_ID + "]");
                    $noCon("#ddlRecptCosGrp2_" + rowCountX + "" + rowCountY).val(arraycostcntr_VALUES);
                }
            }

            function CheckaddMoreRowsQstn(x, y, xy) {
                IncrmntConfrmCounter();
                var addRowtable;
                var addRowResult = true;
                var check = document.getElementById("tdInxQstn" + x + '' + y).value;
                if (check == "") {
                    if (CCDuplication(x, xy) == false) {
                        addRowResult = false;
                    }
                    if (addRowResult == true) {
                        addRowtable = document.getElementById("TableAddQstnCostCenter_" + x);
                        if (CheckAndHighlightCostCenter(x) == false) {
                            addRowResult = false;
                        }
                    }
                    if (addRowResult == false) {
                        return false;
                    }
                    else {
                        document.getElementById("tdInxQstn" + x + '' + y).value = x + '' + y;
                        document.getElementById("btnCostCenter_" + x + '' + y).style.opacity = "0.3";
                        CheckSubmitZero();
                        FunctionQustn(x, y, null, null, null);
                        return false;
                    }
                }
                return false;
            }

            function CheckAndHighlightCostCenter(x) {
                var ret = true;
                var CstTotal = 0;
                var varId = "";
                var varfocus = "";
                $('#TableAddQstnCostCenter' + x + ' td:first-child').each(function () {
                    varId = $(this).text();
                    var Costcenterval = $("#ddlRecptCosCtr_" + varId).val();
                    var ledgerval = $("#ddlProduct_" + x).val();
                    document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "";
                    $("#divCostCenter" + varId + "> input").css("borderColor", "");
                    $("#divCostGrp1" + varId + "> input").css("borderColor", "");
                    $("#divCostGrp2" + varId + "> input").css("borderColor", "");
                    $("#ddlProduct_" + x + "> input").css("borderColor", "");
                    if (document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                        document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                        document.getElementById("TxtCstctrAmount_" + varId).focus();
                        ret = false;
                    }

                    if (document.getElementById("divCostCenter" + varId).style.display != "none") {
                        if (Costcenterval == 0) {
                            document.getElementById("ddlRecptCosCtr_" + varId).style.borderColor = "Red";
                            $("#divCostCenter" + varId + "> input").css("borderColor", "red");
                            $("#divCostCenter" + varId + "> input").focus();
                            $("#divCostCenter" + varId + "> input").select();
                            ret = false;
                        }
                    }
                    if (ledgerval == 0) {
                        $("#divLedger" + x + "> input").css("borderColor", "red");
                        $("#divLedger" + x + "> input").focus();
                        $("#divLedger" + x + "> input").select();
                        ret = false;
                    }
                });
                return ret;
            }

            function removeRowQstn(Rowid, y, removeNum, CofirmMsg) {
                IncrmntConfrmCounter();
                if (document.getElementById("cphMain_HiddenView").value != "1") {
                    ezBSAlert({
                        type: "confirm",
                        messageText: CofirmMsg,
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            var evt = document.getElementById("tdEvtQstn" + removeNum).value;
                            if (evt == 'UPD') {
                                var detailId = document.getElementById("tdDtlIdQstn" + removeNum).value;
                                var CanclIds = document.getElementById("cphMain_hiddenQstnCanclDtlId").value;
                                if (CanclIds == '') {
                                    document.getElementById("cphMain_hiddenQstnCanclDtlId").value = detailId;
                                }
                                else {
                                    document.getElementById("cphMain_hiddenQstnCanclDtlId").value = document.getElementById("cphMain_hiddenQstnCanclDtlId").value + ',' + detailId;
                                }
                            }
                            jQuery('#SubQstnRowId_' + removeNum).remove();
                            var TableRowCount = document.getElementById("TableAddQstnCostCenter" + Rowid).rows.length;
                            if (TableRowCount != 1) {
                                var idlast = "";
                                idlast = $noCon('#TableAddQstnCostCenter' + Rowid + ' tr:last').attr('id');
                                if (idlast != "") {
                                    var res = idlast.split("_");
                                    setTimeout(function () { focusCostCentre(res[1]); }, 350);
                                    document.getElementById("tdInxQstn" + res[1]).value = "";
                                    document.getElementById("btnCostCenter_" + res[1]).style.opacity = "1";
                                }
                            }
                            else {

                                FunctionQustn(Rowid, y, null, null, null);
                                document.getElementById("tdCostCenterDtls" + Rowid).value = "";
                            }
                        }
                        else {
                        }
                    });
                    return false;
                }
                else {
                    return false;
                }
            }

            //function ButtnFillClickCostCenter(x) {
            //    var ret = true;
            //    var TotalAmnt = 0;
            //    var purchaseFlag = 0;
            //    var CheckCount = 0;
            //    document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "none";
            //    var TotalAmnt = document.getElementById("txtPrice" + x).value;
            //    TotalAmnt = TotalAmnt.replace(/\,/g, '');
            //    var addRowtable = document.getElementById("TableAddQstnCostCenter" + x);
            //    document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "";
            //    document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "none";
            //    var CstTotal = 0;
            //    for (var i = 1; i < addRowtable.rows.length; i++) {
            //        var varId = (addRowtable.rows[i].cells[0].innerHTML);
            //        if (CCDuplication(x, varId) == false) {
            //            ret = false;
            //        }
            //        document.getElementById("divCostCenter" + varId).style.borderColor = "";
            //        document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "";
            //        var Costval = $("#ddlRecptCosCtr_" + varId).val();
            //        if (Costval == 0 && document.getElementById("TxtCstctrAmount_" + varId).value == "") {
            //        }
            //        else if (Costval == 0 && document.getElementById("TxtCstctrAmount_" + varId).value != "") {
            //            $("#divCostCenter" + varId + "> input").css("borderColor", "Red");
            //            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Please select a cost centre";
            //            $("div.war").fadeIn(200).delay(500).fadeOut(400);
            //            document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "";
            //            $("#divCostCenter" + varId + "> input").focus();
            //            $("#divCostCenter" + varId + "> input").select();
            //            ret = false;

            //        }
            //        else {
            //            if (document.getElementById("TxtCstctrAmount_" + varId).value != "") {
            //                var ldgramt = document.getElementById("TxtCstctrAmount_" + varId).value;
            //                ldgramt = ldgramt.replace(/\,/g, '');
            //                CstTotal = parseFloat(CstTotal) + parseFloat(ldgramt);
            //                purchaseFlag++;

            //            }
            //            if (document.getElementById("TxtCstctrAmount_" + varId).value == "") {
            //                document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";

            //            }
            //            if (Costval == 0) {
            //                $("#divCostCenter" + varId + "> input").css("borderColor", "red");
            //            }
            //        }
            //    }
            //    if (ret == true) {
            //        if (CstTotal != "") {
            //            if (parseFloat(TotalAmnt) != parseFloat(CstTotal)) {
            //                document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = " Product amount should be equal to cost centre amount";
            //                document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "";
            //                $("div.war").fadeIn(200).delay(500).fadeOut(400);
            //                document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
            //                document.getElementById("TxtCstctrAmount_" + varId).focus();

            //                ret = false;
            //            }
            //        }
            //    }
            //    if (ret == true) {
            //        if (purchaseFlag != 0) {
            //            document.getElementById("tdCostCenterDtls" + x).value = "";

            //            for (var i = 1; i < addRowtable.rows.length; i++) {
            //                var varId = (addRowtable.rows[i].cells[0].innerHTML);
            //                var Costval = $("#ddlRecptCosCtr_" + varId).val();
            //                if (Costval != 0 && document.getElementById("TxtCstctrAmount_" + varId).value != "") {
            //                    if (document.getElementById("tdCostCenterDtls" + x).value == "") {
            //                        document.getElementById("tdCostCenterDtls" + x).value = Costval + "%" + document.getElementById("TxtCstctrAmount_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp1_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp2_" + varId).value;
            //                    }
            //                    else {
            //                        document.getElementById("tdCostCenterDtls" + x).value = document.getElementById("tdCostCenterDtls" + x).value + "$" + Costval + "%" + document.getElementById("TxtCstctrAmount_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp1_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp2_" + varId).value;

            //                    }
            //                }
            //            }
            //            //alert(document.getElementById("tdCostCenterDtls" + x).value);
            //        }
            //        document.getElementById("BttnCost" + x).click();
            //        // document.getElementById("ChkCostCenter" + x).focus();
            //    }
            //}


            function ButtnFillClickCostCenter(x) {
                var ret = true;
                var TotalAmnt = 0;
                var purchaseFlag = 0;
                var CheckCount = 0;
                document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "none";
                var TotalAmnt = document.getElementById("txtPrice" + x).value;
                TotalAmnt = TotalAmnt.replace(/\,/g, '');
                var addRowtable = document.getElementById("TableAddQstnCostCenter" + x);
                document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "";
                document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "none";
                var CstTotal = 0;
                for (var i = 1; i < addRowtable.rows.length; i++) {
                    var varId = (addRowtable.rows[i].cells[0].innerHTML);
                    if (CCDuplication(x, varId) == false) {
                        ret = false;
                    }
                    document.getElementById("divCostCenter" + varId).style.borderColor = "";
                    document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "";
                    var Costval = $("#ddlRecptCosCtr_" + varId).val();
                    var CostGrp1 = $("#ddlRecptCosGrp1_" + varId).val();
                    var CostGrp2 = $("#ddlRecptCosGrp2_" + varId).val();
                   
                    if (CostGrp1 != 0 || CostGrp2 != 0 || Costval != 0 || document.getElementById("TxtCstctrAmount_" + varId).value != "")
                    {

                        if (document.getElementById("TxtCstctrAmount_" + varId).value == "") {
                         
                            document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Please enter cost centre amount";
                            document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "";
                            document.getElementById("TxtCstctrAmount_" + varId).focus();
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);
                            ret = false;
                        }
                        if (Costval == 0) {
                          
                            $("#divCostCenter" + varId + "> input").css("borderColor", "Red");
                            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Please select a cost centre";
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);
                            document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "";
                            $("#divCostCenter" + varId + "> input").focus();
                            $("#divCostCenter" + varId + "> input").select();
                            ret = false;
                        }
                        if (ret == true) {
                            if (document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                                var ldgramt = document.getElementById("TxtCstctrAmount_" + varId).value;
                                ldgramt = ldgramt.replace(/\,/g, '');
                                CstTotal = parseFloat(CstTotal) + parseFloat(ldgramt);
                                purchaseFlag++;

                            }
                        }
                    }
                }
                if (ret == true) {
                    if (CstTotal != "0") {
                        if (parseFloat(TotalAmnt) != parseFloat(CstTotal)) {
                            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = " Product amount should be equal to cost centre amount";
                            document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "";
                            document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "Red";
                            document.getElementById("TxtCstctrAmount_" + varId).focus();
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);

                            ret = false;
                        }
                    }
                }
                if (ret == true) {
                    if (purchaseFlag != 0) {
                        document.getElementById("tdCostCenterDtls" + x).value = "";

                        for (var i = 1; i < addRowtable.rows.length; i++) {
                            var varId = (addRowtable.rows[i].cells[0].innerHTML);
                            var Costval = $("#ddlRecptCosCtr_" + varId).val();
                            if (Costval != 0 && document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                                if (document.getElementById("tdCostCenterDtls" + x).value == "") {
                                    document.getElementById("tdCostCenterDtls" + x).value = Costval + "%" + document.getElementById("TxtCstctrAmount_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp1_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp2_" + varId).value;
                                }
                                else {
                                    document.getElementById("tdCostCenterDtls" + x).value = document.getElementById("tdCostCenterDtls" + x).value + "$" + Costval + "%" + document.getElementById("TxtCstctrAmount_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp1_" + varId).value + "%" + document.getElementById("ddlRecptCosGrp2_" + varId).value;

                                }
                            }
                        }
                        //alert(document.getElementById("tdCostCenterDtls" + x).value);
                    }
                    document.getElementById("BttnCost" + x).click();
                    // document.getElementById("ChkCostCenter" + x).focus();
                }
            }

            function ddlCostCenterOnchange(x, y) {
                IncrmntConfrmCounter();
                if (document.getElementById("ddlRecptCosCtr_" + x + '' + y).value != 0) {
                    var ddlCostcnt = document.getElementById("ddlRecptCosCtr_" + x + '' + y).value;
                    document.getElementById("ddlCostCtrId_" + x + '' + y).value = ddlCostcnt;
                }
                CCDuplication(x, x + '' + y);
            }

            function CCDuplication(x, xy) {
                var addRowtable = "";
                var ret = true;
                var flag = 0;
                addRowtable = document.getElementById("TableAddQstnCostCenter" + x);
                document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "";
                document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "none";
                for (var i = 0; i < addRowtable.rows.length; i++) {
                    $("#divCostGrp1" + xLoop + "> input").css("borderColor", "");
                    $("#divCostGrp2" + xLoop + "> input").css("borderColor", "");
                    $("#divCostCenter" + xLoop + "> input").css("borderColor", "");
                    var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                    var xLoopLdgrId = $("#ddlRecptCosCtr_" + xLoop).val();
                    var LedgerId = $("#ddlRecptCosCtr_" + xy).val();
                    var xLoopLdgrId2 = $("#ddlRecptCosGrp2_" + xLoop).val();
                    var LedgerId2 = $("#ddlRecptCosGrp2_" + xy).val();
                    var xLoopLdgrId1 = $("#ddlRecptCosGrp1_" + xLoop).val();
                    var LedgerId1 = $("#ddlRecptCosGrp1_" + xy).val();
                    if (xLoop != xy) {
                        if ((xLoopLdgrId == LedgerId) && (xLoopLdgrId1 == LedgerId1) && (xLoopLdgrId2 == LedgerId2)) {
                            $("#divCostGrp1" + xy + "> input").css("borderColor", "red");
                            $("#divCostGrp2" + xy + "> input").css("borderColor", "red");
                            $("#divCostCenter" + xy + "> input").css("borderColor", "red");
                            $("#divCostGrp1" + xy + "> input").focus();
                            $("#divCostGrp1" + xy + "> input").select();
                            document.getElementById("lblErrMsgCancelReasonCostCenter" + x).innerHTML = "Cost centres should not be duplicated for cost groups";
                            document.getElementById("divErrMsgCnclRsnCostCenter" + x).style.display = "";
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);
                            $noCon(window).scrollTop(0);

                            ret = false;
                        }
                        else {
                            $("#divCostGrp1" + xy + "> input").css("borderColor", "");
                            $("#divCostGrp2" + xy + "> input").css("borderColor", "");
                            $("#divCostCenter" + xy + "> input").css("borderColor", "");
                        }
                    }
                }
                return ret;
            }

            function CheckSumOfCstCntr(textboxid, x, y) {
                if (document.getElementById(textboxid).value != "" && document.getElementById(textboxid).value != "0") {
                    var CstTotal = 0;
                    var LedgerTotal = 0;
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                $('#TableAddQstnCostCenter' + x + ' td:first-child').each(function () {
                    var varId = $(this).text();
                    if (document.getElementById("TxtCstctrAmount_" + varId).value != "") {

                        if (document.getElementById("TxtRecptCosCtr_" + varId).value != "") {
                            var actAmt = document.getElementById("TxtActCstctrAmount_" + varId).value;
                            var ObjVal = document.getElementById("TxtCstctrAmount_" + varId).value;
                            if (document.getElementById("TxtActCstctrAmount_" + varId).value != "") {
                                ObjVal = ObjVal.replace(/\,/g, '');
                                if (parseFloat(ObjVal) > parseFloat(actAmt)) {

                                    $noCon("#divWarning").html("Paid amount can not exceed actual amount.");
                                    document.getElementById("TxtCstctrAmount_" + varId).style.borderColor = "red";
                                    $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                                    });
                                    
                                    $noCon(window).scrollTop(0);
                                    return false;
                                }
                            }
                        }
                    }
                    var cstamt = 0;
                    if (document.getElementById("TxtCstctrAmount_" + varId).value != "") {
                        cstamt = document.getElementById("TxtCstctrAmount_" + varId).value;
                        cstamt = cstamt.replace(/\,/g, '');
                        if (FloatingValue != "") {
                            cstamt = parseFloat(cstamt);
                            cstamt = cstamt.toFixed(FloatingValue);
                        }
                        document.getElementById("TxtCstctrAmount_" + varId).value = cstamt;
                        CstTotal = parseFloat(CstTotal) + parseFloat(cstamt);
                        addCommas("TxtCstctrAmount_" + varId);
                        if (document.getElementById("txtPrice" + x).value != "") {
                            var ledramt = document.getElementById("txtPrice" + x).value;
                            ledramt = ledramt.replace(/\,/g, '');
                            if (FloatingValue != "") {
                                ledramt = parseFloat(ledramt);
                                ledramt = ledramt.toFixed(FloatingValue);
                            }
                            LedgerTotal = parseFloat(LedgerTotal) + +parseFloat(ledramt);
                            addCommas("txtPrice" + x);
                        }
                    }
                });
            }
            else {
                document.getElementById(textboxid).value = "";
            }
            return true;
        }

            function ChangeProductTTT(PRowNum) {
                document.getElementById("<%=HiddenFocusId.ClientID%>").value = "";
                document.getElementById("<%=HiddenFocusName.ClientID%>").value = "";

                var QtnItemName = document.getElementById("txtproductName" + PRowNum).value;
                document.getElementById("<%=HiddenFocusName.ClientID%>").value = QtnItemName;

                var QtnItemId = document.getElementById("txtproductId" + PRowNum).value;
                document.getElementById("<%=HiddenFocusId.ClientID%>").value = QtnItemId;
            }

            function CloseModal(x) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to close?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        document.getElementById("BttnCost" + x).click();
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }

            //--------------Cost centre------------

            function buttnVisibile() {
                var TableRowCount = document.getElementById("TableaddedRows").rows.length;
                addRowtable = document.getElementById("TableaddedRows");
                //    var TableRowCount1 = document.getElementById("TableAddQstnCostCenter" + x).rows.length;
                if (TableRowCount != 0) {
                    var idlast1 = $noCon('#TableaddedRows tr:last').attr('id');
                    if (idlast1 != "") {
                        var res1 = idlast1.split("_");
                        //  document.getElementById("tdInxQstn" + res1[1]).value = "";
                        document.getElementById('SpanAdd' + res1[1]).disabled = false;
                        document.getElementById('SpanAdd' + RowNum).style.pointerEvents = "";
                    }
                }
            }
            function ProductsLoad(RowNum) {
                $noCon("#ddlProduct_" + RowNum).autocomplete({
                    source: function (request, response) {
                        var objSearchSrv = {};
                        var prefix = "";
                        prefix = request.term;
                        var strOrgId = '<%=Session["ORGID"]%>';
                        var strCorpId = '<%=Session["CORPOFFICEID"]%>';
                        $noCon.ajax({
                            // url: '<%=ResolveUrl("/Purchase_master.aspx/getItems") %>',
                            type: "POST",
                            url: "Purchase_master.aspx/getItems",
                            async: false,
                            data: '{prefix:"' + prefix + '",strOrgId:"' + strOrgId + '",strCorpId:"' + strCorpId + '"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (data) {
                                response($noCon.map(data.d, function (item) {

                                    return {
                                        label: item.split('—')[0],
                                        val: item.split('—')[1]
                                    }
                                }))
                            },
                            error: function (response) {

                            },
                            failure: function (response) {

                            }
                        });
                    },
                    select: function (e, i) {
                        var srtSearchItemMstr = i.item.label;
                        var srtSearch = i.item.val;
                        document.getElementById("ProductId" + RowNum).value = srtSearch;
                        document.getElementById("txtproductName" + RowNum).value = i.item.label;
                        $noCon("#ddlProduct_" + RowNum).attr("title", i.item.label);


                        document.getElementById('txtQntity' + RowNum).value = 1;
                        document.getElementById('txtQntity' + RowNum).readOnly = false;
                        document.getElementById('txtRate' + RowNum).readOnly = false;
                        if (document.getElementById("<%=HiddenDiscountEnableSts.ClientID%>").value == "1") {
                            document.getElementById('txtDisPercent' + RowNum).disabled = false;
                            document.getElementById('txtDisAmt' + RowNum).disabled = false;
                        }
                        else {
                            document.getElementById('txtDisPercent' + RowNum).disabled = true;
                            document.getElementById('txtDisAmt' + RowNum).disabled = true;
                        }
                        document.getElementById("ddlProduct_" + RowNum).focus();
                        BlurValue(RowNum, 'txtDisPercent');
                    },
                    minLength: 3
                });
            }

            function ChangeProduct(evt) {
                var x2 = evt;
                ProductDuplication(evt);
                var strproductId = document.getElementById("ddlProduct_" + x2).value;
                if (strproductId == "--SELECT PRODUCT--" || strproductId == "") {
                    document.getElementById('txtQntity' + x2).readOnly = true;
                    document.getElementById('txtRate' + x2).readOnly = true;
                    document.getElementById('txtQntity' + x2).value = "";
                    document.getElementById('txtRate' + x2).value = "";
                    document.getElementById('txtDisPercent' + x2).disabled = true;
                    document.getElementById('txtDisPercent' + x2).value = "";
                    document.getElementById('txtDisAmt' + x2).disabled = true;
                    document.getElementById('txtDisAmt' + x2).value = "";
                    if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                        document.getElementById('ddlTaxText' + x2).disabled = true;
                        document.getElementById('ddlTaxText' + x2).value = "";
                        document.getElementById('txtTaxAmt' + x2).disabled = true;
                        document.getElementById('txtTaxAmt' + x2).value = "";
                    }
                    document.getElementById('txtRate' + x2).disabled = true;
                    document.getElementById('txtRate' + x2).value = "";
                    document.getElementById('txtPrice' + x2).disabled = true;
                    document.getElementById('txtPrice' + x2).value = "";
                    BlurValue(x2, null);
                }
                else {

                    var PrdctName = document.getElementById("txtproductName" + x2).value.trim();
                    $noCon("#ddlProduct_" + x2).attr("title", PrdctName);
                    if (PrdctName != "" || PrdctName != "--SELECT PRODUCT--") {
                        document.getElementById("ddlProduct_" + x2).value = PrdctName;
                    }
                    FillddlTax(x2, null, null); 
                }

            }

            function CalculateNetTotal(str) {
                var NetAmt = 0;
                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;



                var FinalGrossTotal = 0;
                var FinalTax = 0;
                var NetTotal = 0;
                var NetTotal_Exchange = 0;
                var FinalDiscount = 0;
                $('#TableaddedRows').find('tr').each(function () {

                    var row = $(this);
                    var rowid1 = $('td:first-child', row).html();

                    if (rowid1 != "") {
                        var rate1 = document.getElementById("txtRate" + rowid1).value;
                        rate1 = rate1.replace(/,/g, "");
                        var qty1 = document.getElementById("txtQntity" + rowid1).value.replace(/,/g, "");
                        if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                            var txAmt1 = document.getElementById("txtTaxAmt" + rowid1).value;
                            txAmt1 = txAmt1.replace(/,/g, "");
                        }
                        var discnt1 = document.getElementById("txtDisAmt" + rowid1).value;
                        discnt1 = discnt1.replace(/,/g, "");
                        if (rate1 != "" && qty1 != "") {
                            FinalGrossTotal = parseFloat(FinalGrossTotal) + (parseFloat(rate1) * parseFloat(qty1));
                        }
                        if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                            if (txAmt1 != "") {
                                FinalTax = parseFloat(FinalTax) + parseFloat(txAmt1);
                            }
                        }
                        if (discnt1 != "") {
                            FinalDiscount = parseFloat(FinalDiscount) + parseFloat(discnt1);
                        }

                    }


                });

                // alert(FinalTax);

                if (FinalDiscount <= 0) {
                    if (document.getElementById("<%=HiddenDiscountEnableSts.ClientID%>").value == "1") {


                        if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                            document.getElementById("<%=txtDiscountTotal.ClientID%>").disabled = false;
                            if (str == 1 || document.getElementById("<%=Hiddendiscount.ClientID%>").value > 0) {

                                var dicntAmt = document.getElementById("<%=txtDiscountTotal.ClientID%>").value;



                                var x = dicntAmt.split(' ');


                                if (parseFloat(x[0]) > 0) {


                                    FinalDiscount = document.getElementById("<%=txtDiscountTotal.ClientID%>").value;
                                    FinalDiscount = FinalDiscount.replace(/,/g, "");
                                }

                                if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                                    document.getElementById("<%=txtDiscountTotal.ClientID%>").disabled = true;
                                }
                            }


                            //  document.getElementById("<%=txtDiscountTotal.ClientID%>").disabled = false;
                        }
                        else {
                            document.getElementById("<%=txtDiscountTotal.ClientID%>").disabled = true;
                            var dicntAmt = document.getElementById("<%=txtDiscountTotal.ClientID%>").value;



                            var x = dicntAmt.split(' ');


                            if (parseFloat(x[0]) > 0) {


                                FinalDiscount = document.getElementById("<%=txtDiscountTotal.ClientID%>").value;
                                FinalDiscount = FinalDiscount.replace(/,/g, "");
                            }

                            if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                                document.getElementById("<%=txtDiscountTotal.ClientID%>").disabled = true;
                            }
                        }




                        if (FinalDiscount == 0) {
                            FinalDiscount = 0;
                        }

                    }

                    else {
                        document.getElementById("<%=txtDiscountTotal.ClientID%>").disabled = true;
                    }
                }

                else {
                    document.getElementById("<%=txtDiscountTotal.ClientID%>").disabled = true;

                    document.getElementById("<%=txtDiscountTotal.ClientID%>").value = FinalDiscount;

                }




                NetTotal = (parseFloat(FinalGrossTotal) + parseFloat(FinalTax)) - parseFloat(FinalDiscount);

                NetTotal = parseFloat(NetTotal);

                if (FloatingValue != "") {
                    NetTotal = NetTotal.toFixed(FloatingValue);

                    var ExnhgRate = 0;
                    if (document.getElementById("<%=txtExchangeRate.ClientID%>").value != "") {
                        ExnhgRate = document.getElementById("<%=txtExchangeRate.ClientID%>").value;

                        NetTotal_Exchange = parseFloat(NetTotal);
                        NetTotal_Exchange = parseFloat(NetTotal) * parseFloat(document.getElementById("<%=txtExchangeRate.ClientID%>").value);

                    }

                    ExnhgRate = parseFloat(ExnhgRate);
                    ExnhgRate = ExnhgRate.toFixed(FloatingValue);
                    document.getElementById("<%=txtExchangeRate.ClientID%>").value = ExnhgRate;
                    NetTotal_Exchange = parseFloat(NetTotal_Exchange);
                    NetTotal_Exchange = NetTotal_Exchange.toFixed(FloatingValue);
                }




                addCommasSummry(NetTotal_Exchange);
                //  alert("Calculate   " + document.getElementById("<%=HiddenDefaultCurrency.ClientID%>").value);
                document.getElementById("<%=txtTotalWithExchngRate.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenDefaultCurrency.ClientID%>").value;
                document.getElementById("<%=lblExchnangAmt.ClientID%>").innerHTML = "Amount in " + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + " :" + document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;



                addCommas("cphMain_txtExchangeRate");

                if (document.getElementById("<%=HiddenInventoryForex.ClientID%>").value == "1") {
                    if (document.getElementById("<%=divExchangeRate.ClientID%>").style.display == "") {
                        if (document.getElementById("<%=txtExchangeRate.ClientID%>").value != "") {

                            //  NetTotal = (parseFloat(NetTotal) + parseFloat(document.getElementById("<%=txtExchangeRate.ClientID%>").value));
                        }
                    }
                }




                if (FloatingValue != "") {
                    FinalGrossTotal = parseFloat(FinalGrossTotal);
                    FinalTax = parseFloat(FinalTax);
                    FinalDiscount = parseFloat(FinalDiscount);
                    NetTotal = parseFloat(NetTotal);
                    FinalGrossTotal = FinalGrossTotal.toFixed(FloatingValue);
                    FinalTax = FinalTax.toFixed(FloatingValue);
                    FinalDiscount = FinalDiscount.toFixed(FloatingValue);

                    NetTotal = NetTotal.toFixed(FloatingValue);
                    //    NetTotal_Exchange = parseFloat(NetTotal_Exchange);
                    //   NetTotal_Exchange = NetTotal_Exchange.toFixed(FloatingValue);
                }
                document.getElementById("<%=Hiddendiscount.ClientID%>").value = FinalDiscount;
                document.getElementById("<%=HiddenGrossAmt.ClientID%>").value = FinalGrossTotal;
                document.getElementById("<%=HiddenNetAmt.ClientID%>").value = NetTotal;
                document.getElementById("<%=HiddenTax.ClientID%>").value = FinalTax;


                addCommasSummry(FinalDiscount);

                document.getElementById("<%=txtDiscountTotal.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value;
                addCommasSummry(FinalGrossTotal);
                document.getElementById("<%=txtGrossTotal.ClientID%>").innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value;
                addCommasSummry(NetTotal);
                // alert(NetTotal);
                document.getElementById("<%=txtNetTotal.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value;
                addCommasSummry(FinalTax);
                document.getElementById("<%=txtTaxTotal.ClientID%>").innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value;



            }





        function AmountChecking(textboxfeild, id) {
            // alert(textboxid);
            var textboxid = textboxfeild + id;
            var txtPerVal = document.getElementById(textboxid).value;
            //  alert(txtPerVal);

            txtPerVal = txtPerVal.replace(/,/g, "");



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
                    var n = num;
                    // for floatting number adjustment from corp global
                    var FloatingValue = "";

                    FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        n = num.toFixed(FloatingValue);

                    }
                    document.getElementById('' + textboxid + '').value = n;

                }
            }

            addCommas(textboxid);
        }



            var flag = 0;
            var discountOrAmt = "";
            function BlurValue(rowCount, textField) {
                IncrmntConfrmCounter();
                var Table = "";
                var VartxtQntity = 0;
                var VartxttaxAmt = 0;
                var VartxtRatevalue = 0;
                var OptionTaxPercentage = 0;
                var total = 0;
                var txtDisPercentage = "";
                var txtDisAmt = 0;
                var taxAmt = 0;
                var DisAmt = 0;
                var DisPer = 0;
                var Grosstotal = 0;


                if (textField != "ddlProduct_") {
                    AmountChecking(textField, rowCount);
                }
                //if (textField == "txtQntity") {
                //    RemoveNaN_OnBlur(textField + rowCount);
                //}

                // curncyChangeFunt('1');
                VartxtQntity = document.getElementById("txtQntity" + rowCount).value.replace(/,/g, "");
                VartxtRatevalue = document.getElementById("txtRate" + rowCount).value;

                if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {

                    VartxttaxAmt = document.getElementById("txtTaxAmt" + rowCount).value;
                    OptionTaxPercentage = document.getElementById("TaxPer" + rowCount).value;
                }
                //   alert(discountOrAmt+"  discountOrAmt");
                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;


                if (OptionTaxPercentage != "" && OptionTaxPercentage != 0) {
                    if (document.getElementById("txtQntity" + rowCount).value == "") {
                        var taxtAmtprcng = parseFloat(OptionTaxPercentage) / 100;
                        //alert("taxtAmtprcng  " + taxtAmtprcng);
                        // VartxtRatevalue = VartxtRatevalue.replace(",", "");
                        VartxtRatevalue = VartxtRatevalue.replace(/,/g, "");
                        taxAmtint = parseFloat(VartxtRatevalue) * parseFloat(taxtAmtprcng);
                        // alert(taxAmtint);
                        if (FloatingValue != "") {
                            taxAmtint = taxAmtint.toFixed(FloatingValue);

                        }
                        if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {

                            document.getElementById("txtTaxAmt" + rowCount).value = taxAmtint;
                        }
                        //return false;
                    }
                }



                VartxtRatevalue = VartxtRatevalue.replace(/,/g, "");
                if (VartxttaxAmt != 0)
                    VartxttaxAmt = VartxttaxAmt.replace(/,/g, "");


                if (VartxtQntity != 0 && VartxtRatevalue != 0) {
                    // alert(OptionTaxPercentage + "taxd");
                    total = parseFloat(VartxtQntity) * parseFloat(VartxtRatevalue);
                    if (FloatingValue != "") {
                        total = total.toFixed(FloatingValue);
                    }
                }
                if (flag == 1) {
                    if (document.getElementById('txtDisAmt' + rowCount).disabled == false && document.getElementById('txtDisPercent' + rowCount).disabled == false) {
                        flag = 0;
                        discountOrAmt = "";
                    }

                }
                if (textField == "txtDisPercent") {
                    if (flag == 0) {
                        flag++;
                        discountOrAmt = "txtDisPercent";
                    }
                }

                var discntprcntg = txtDisPercentage = document.getElementById("txtDisPercent" + rowCount).value;

                if (discountOrAmt == "txtDisPercent" || textField == "txtQntity") {
                    txtDisPercentage = document.getElementById("txtDisPercent" + rowCount).value;
                    VartxtRatevalue = VartxtRatevalue.replace(/,/g, "");
                    if (txtDisPercentage != "" && txtDisPercentage != 0 && txtDisPercentage != null && total != 0) {

                        DisAmt = parseFloat(VartxtRatevalue) * parseFloat(VartxtQntity) * parseFloat((parseFloat(txtDisPercentage) / 100));

                        if (FloatingValue != "") {
                            DisAmt = parseFloat(DisAmt);
                            DisAmt = DisAmt.toFixed(FloatingValue);
                        }
                        $noCon("#txtDisAmt" + rowCount).val(DisAmt);
                        if (DisAmt == 0) {
                            $noCon("#txtDisPercent" + rowCount).val(0);
                        }
                    }
                    else {
                        $noCon("#txtDisPercent" + rowCount).val(0);
                        $noCon("#txtDisAmt" + rowCount).val(0);
                        document.getElementById("<%=Hiddendiscount.ClientID%>").value = 0;
                        document.getElementById('txtDisPercent' + rowCount).style.pointerEvents = "";
                        if (document.getElementById("<%=HiddenDiscountEnableSts.ClientID%>").value == "1") {
                            document.getElementById('txtDisPercent' + rowCount).disabled = false;
                            document.getElementById('txtDisAmt' + rowCount).style.pointerEvents = "";
                            document.getElementById('txtDisAmt' + rowCount).disabled = false;
                        }
                        else {
                            document.getElementById('txtDisPercent' + rowCount).disabled = true;

                            document.getElementById('txtDisAmt' + rowCount).disabled = true;
                        }
                    }
                }
                if (textField == "txtDisAmt") {
                    if (flag == 0) {
                        flag++;
                        discountOrAmt = "txtDisAmt";
                    }
                }
                if (discountOrAmt == "txtDisAmt") {
                    DisAmt = document.getElementById("txtDisAmt" + rowCount).value;
                    DisAmt = DisAmt.replace(/,/g, "");
                    if (DisAmt != "" && DisAmt != 0 && DisAmt != null && total != 0) {
                        var prcntg = parseFloat(DisAmt) * 100;
                        DisPer = parseFloat(prcntg) / (parseFloat(VartxtQntity) * parseFloat(VartxtRatevalue));
                        if (FloatingValue != "") {
                            DisPer = DisPer.toFixed(FloatingValue);
                        }
                        $noCon("#txtDisPercent" + rowCount).val(DisPer);
                    }
                    else {
                        if (document.getElementById("<%=HiddenDiscountEnableSts.ClientID%>").value == "1") {
                            document.getElementById('txtDisPercent' + rowCount).style.pointerEvents = "";

                            document.getElementById('txtDisPercent' + rowCount).disabled = false;
                            document.getElementById('txtDisAmt' + rowCount).style.pointerEvents = "";
                            document.getElementById('txtDisAmt' + rowCount).disabled = false;
                        }
                        else {
                            document.getElementById('txtDisPercent' + rowCount).disabled = true;

                            document.getElementById('txtDisAmt' + rowCount).disabled = true;
                        }
                    }
                    if (DisAmt == 0) {
                        $noCon("#txtDisPercent" + rowCount).val(0);
                        $noCon("#txtDisAmt" + rowCount).val(0);
                        document.getElementById("<%=Hiddendiscount.ClientID%>").value = 0;

                   }
               }

               if (OptionTaxPercentage != "" && OptionTaxPercentage != 0 && total != 0) {
                   var taxtAmtprcng = parseFloat(OptionTaxPercentage) / 100;
                   taxAmt = parseFloat(VartxtQntity) * parseFloat(VartxtRatevalue) * parseFloat(taxtAmtprcng);
                   taxAmt = parseFloat(taxAmt);

                   if (FloatingValue != "") {
                       taxAmt = taxAmt.toFixed(FloatingValue);
                   }
                   if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                        $noCon("#txtTaxAmt" + rowCount).val(taxAmt);
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                        $noCon("#txtTaxAmt" + rowCount).val(0);
                    }
                }
                if (VartxtRatevalue != 0 && VartxtQntity != 0) {
                    VartxtRatevalue = VartxtRatevalue.replace(/,/g, "");
                    if (DisAmt != "" && DisAmt != null) {
                        var pricewithoutTax = ((parseFloat(VartxtRatevalue) * parseFloat(VartxtQntity)) - (parseFloat(DisAmt)));
                    }
                    else {
                        var pricewithoutTax = parseFloat(VartxtRatevalue) * parseFloat(VartxtQntity);
                    }
                    var price = parseFloat(pricewithoutTax) + parseFloat(taxAmt);
                    price = price.toFixed(FloatingValue);
                    $noCon("#txtPrice" + rowCount).val(price);
                }
                else {
                    $noCon("#txtPrice" + rowCount).val(0);
                }
                var FinalGrossTotal = 0;
                var FinalTax = 0;
                var NetTotal = 0;
                var NetTotal_Exchange = 0;
                var FinalDiscount = 0;
                var RowNum = document.getElementById("<%=HiddenRowNo.ClientID%>").value;
                //for (var i = 1; i <= RowNum; i++) {
                $('#TableaddedRows').find('tr').each(function () {
                    var row = $(this);
                    var rowid1 = $('td:first-child', row).html();
                    if (rowid1 != "") {
                        var rate1 = document.getElementById("txtRate" + rowid1).value;
                        rate1 = rate1.replace(/,/g, "");
                        var qty1 = document.getElementById("txtQntity" + rowid1).value;
                        if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                            var txAmt1 = document.getElementById("txtTaxAmt" + rowid1).value;
                            txAmt1 = txAmt1.replace(/,/g, "");
                        }
                        var discnt1 = document.getElementById("txtDisAmt" + rowid1).value;
                        discnt1 = discnt1.replace(/,/g, "");
                        if (rate1 != "" && qty1 != "") {
                            FinalGrossTotal = parseFloat(FinalGrossTotal) + (parseFloat(rate1) * parseFloat(qty1));
                        }
                        if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                            if (txAmt1 != "") {
                                FinalTax = parseFloat(FinalTax) + parseFloat(txAmt1);
                            }
                        }
                        if (discnt1 != "") {
                            FinalDiscount = parseFloat(FinalDiscount) + parseFloat(discnt1);
                        }
                        CalculateNetTotal(0);

                        if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                            addCommas("txtTaxAmt" + rowid1);
                        }
                        addCommas("txtRate" + rowid1);
                        addCommas("txtDisAmt" + rowid1);
                        addCommas("txtDisPercent" + rowid1);
                        addCommas("txtPrice" + rowid1);

                    }
                });



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
                    document.getElementById("<%=Hiddenreturnfun.ClientID%>").value = x1;
                     //return x1;
                 else
                     document.getElementById("<%=Hiddenreturnfun.ClientID%>").value = x1 + "." + x2;


             }
             function addCommas(textboxid) {
                 // alert(textboxid);
                 nStr = document.getElementById(textboxid).value;
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



                //alert(x1);
                if (isNaN(x2))
                    document.getElementById('' + textboxid + '').value = x1;
                    //return x1;
                else
                    document.getElementById('' + textboxid + '').value = x1 + "." + x2;
                // return x1 + "." + x2;
                //    alert(document.getElementById('' + textboxid + '').value);
            }


            //  }
            function AddDeleted(Delrowcount) {
                if (document.getElementById("tdEvt" + Delrowcount).innerHTML == "UPD") {
                    var detailId = document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value;
                    detailId = detailId + "," + document.getElementById("tdDtlId" + Delrowcount).innerHTML;
                    document.getElementById("<%=hiddenCanclDtlId.ClientID%>").value = detailId;
                }

            }

            var $noconfli = jQuery.noConflict();
            function CheckDelEachRow(Delrowcount) {
                //   var newCount = 0;
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to delete this product?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        AddDeleted(Delrowcount);
                        jQuery('#rowId_' + Delrowcount).remove();

                        var table = document.getElementById("TableaddedRows");
                        var x = table.rows.length;
                        var Rownum = document.getElementById("<%=HiddenRownum.ClientID%>").value;
                        var len;

                        ReNumberTable();
                        var TableRowCount = document.getElementById("TableaddedRows").rows.length;

                        if (TableRowCount != 0) {
                            var idlast = $noCon('#TableaddedRows  tr:last').attr('id');
                            //alert(idlast);
                            if (idlast != "") {

                                var res = idlast.split("_");

                                document.getElementById("SpanAdd" + res[1]).disabled = false;
                                document.getElementById("SpanAdd" + res[1]).style.pointerEvents = 'auto';
                                BlurValue(res[1], 'txtDisAmt');

                            }
                        }
                        else {

                            addMoreRows();
                        }

                    }
                });
                return false;
            }
            function ReNumberTable() {
                var Table = "";
                Table = $('#TableaddedRows > tbody > tr ');
                var count = 0;
                $(Table).each(function () {
                    var RowId = $(this).attr('id');
                    var SplitId = RowId.split('_');
                    var RowId = SplitId[0];
                    var rowCount = SplitId[1];
                    if (RowId == "rowId") {
                        count++;
                        $noCon("#txtSlno" + rowCount).val(count);
                    }
                });
                rowsl_no = count++;
            }
            function CheckDate(r) {
                var ret = true;

                document.getElementById("<%=HiddenRet.ClientID%>").value = "";
                document.getElementById("txtFromDate" + r).style.borderColor = "";
                document.getElementById("txtToDate" + r).style.borderColor = "";
                if (document.getElementById("txtFromDate" + r).value != "" && document.getElementById("txtToDate" + r).value != "") {
                    var DateToCurrent = document.getElementById("txtToDate" + r).value;
                    var arrToCurrent = DateToCurrent.split("-");
                    DateToCurrent = new Date(arrToCurrent[2], arrToCurrent[1], arrToCurrent[0]);

                    var DateFromCurrent = document.getElementById("txtFromDate" + r).value;
                    var arrFromCurrent = DateFromCurrent.split("-");
                    DateFromCurrent = new Date(arrFromCurrent[2], arrFromCurrent[1], arrFromCurrent[0]);
                    if (DateFromCurrent > DateToCurrent) {
                        document.getElementById("txtFromDate" + r).style.borderColor = "Red";
                        document.getElementById("txtToDate" + r).style.borderColor = "Red";

                        $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });

                        $noCon1(window).scrollTop(0);
                        ret = false;

                    }
                }
                var arrFromPrevius;
                var arrToprevius;
                var num = document.getElementById("<%=HiddenRownum.ClientID%>").value;
                var table = document.getElementById("TableaddedRows");
                //  alert(RowNum);
                for (var i = RowNum ; i >= 1 ; i--) {
                    var previus = i - 1;
                    var AddButton = $noconfli("#txtFromDate" + previus);
                    if (AddButton.length) {
                        var DateFromprevius = document.getElementById("txtFromDate" + previus).value;
                        arrFromPrevius = DateFromprevius.split("-");
                        DateFromprevius = new Date(arrFromPrevius[2], arrFromPrevius[1], arrFromPrevius[0]);
                        var DateToprevius = document.getElementById("txtToDate" + previus).value;
                        if (DateToprevius != "") {
                            arrToprevius = DateToprevius.split("-");
                            DateToprevius = new Date(arrToprevius[2], arrToprevius[1], arrToprevius[0]);


                            if (r != previus) {
                                if (DateFromprevius <= DateToCurrent && DateFromCurrent <= DateToprevius) {
                                    document.getElementById("txtFromDate" + r).style.borderColor = "Red";
                                    $noCon("#divWarning").html("Limit date range should not overlap.");
                                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                    });

                                    $noCon1(window).scrollTop(0);
                                    ret = false;
                                }
                            }
                        }
                    }
                }

                document.getElementById("<%=HiddenRet.ClientID%>").value = ret;
                return ret;
            }
            function FillddlProduct(rowCount, Product, PRODUCT_NAME, PRDCT_CHCK) {
                addCommas("txtRate" + rowCount);
                if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                    addCommas("txtTaxAmt" + rowCount);
                }
                addCommas("txtDisAmt" + rowCount);
                addCommas("txtPrice" + rowCount);
                //alert(Product + "PRDUCT");
                var ddlTestDropDownListXML = $noCon("#ddlProduct_" + rowCount);
                var strOrgId = '<%=Session["ORGID"]%>';
                var strCorpId = '<%=Session["CORPOFFICEID"]%>';
                var tableName = "dtTableLoadLdger";

                $noCon.ajax({
                    type: "POST",
                    url: "Purchase_master.aspx/DropdownProductBind",
                    async: false,
                    data: '{strOrgId:"' + strOrgId + '",strCorpId:"' + strCorpId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        $noCon(response.d).find(tableName).each(function () {
                            //  alert();
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noCon(this).find('PRDT_ID').text();
                            var OptionText = $noCon(this).find('PRDT_NAME').text();
                            //  
                            // Create an Option for DropDownList.
                            var option = $noCon("<option>" + OptionText + "</option>");
                            option.attr("value", OptionValue);
                            ddlTestDropDownListXML.append(option);


                            var currency = "";
                            if (Product != null)
                                currency = Product;
                            if (currency != "") {

                                var arrayProduct = JSON.parse("[" + Product + "]");
                                $noCon("#ddlProduct_" + rowCount).val(arrayProduct);

                            }

                        });

                        if (PRDCT_CHCK == 0) {
                            if (Product != null) {

                                document.getElementById("txtproductName" + rowCount).value = PRODUCT_NAME;
                                var newOption = "<option value='" + Product + "'>" + PRODUCT_NAME + "</option>";

                                $aa("#ddlProduct_" + rowCount).append(newOption);
                                //SORTING DDL
                                var options = $aa("#ddlProduct_" + rowCount + " option");                    // Collect options         
                                options.detach().sort(function (a, b) {               // Detach from select, then Sort
                                    var at = $aa(a).text();
                                    var bt = $aa(b).text();
                                    return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                                });
                                options.appendTo("#ddlProduct_" + rowCount);
                                //  $noCon("#ddlProduct_" + rowCount).val(PRODUCT_VALUES);
                            }
                        }



                    },
                    failure: function (response) {

                    }
                });

            }


            function FillddlTax(rowCount, Tax, RATE) {
                var Product = "";
                if (document.getElementById("ProductId" + rowCount).value != "") {
                    Product = document.getElementById("ProductId" + rowCount).value;
                }
                var VartxtQntity = 0;
                var VartxttaxAmt = 0;
                var VartxtRatevalue = 0;
                var VartxtRate = $noCon("#txtRate" + rowCount);
                VartxtQntity = document.getElementById("txtQntity" + rowCount).value;
                if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                    VartxttaxAmt = $noCon("#txtTaxAmt" + rowCount).value;
                }
                var strOrgId = '<%=Session["ORGID"]%>';
                var strCorpId = '<%=Session["CORPOFFICEID"]%>';
                var tableName = "dtTableLoadTax";
                $noCon.ajax({
                    type: "POST",
                    async: false,
                    url: "Purchase_master.aspx/DropdownTaxBind",
                    data: '{strOrgId:"' + strOrgId + '",strCorpId:"' + strCorpId + '",Product:"' + Product + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        // alert();
                        $noCon(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValueTax = 0;
                            var OptionTaxPercentage = 0;
                            var total = 0;

                            OptionValueTax = $noCon(this).find('TAX_ID').text();
                            var OptionTextTax = $noCon(this).find('TAX_NAME').text();
                            var OptionTextRate = $noCon(this).find('PRDT_COST_PRICE').text();
                            OptionTaxPercentage = $noCon(this).find('TAX_PERCENTAGE').text();

                            // alert(OptionTaxPercentage+"rgrgr");


                            document.getElementById("<%=HiddenTaxPercentage.ClientID%>").value = OptionTaxPercentage;

                            if (VartxtQntity != 0 && OptionTextRate != null) {
                                total = (parseFloat(VartxtQntity) * OptionTextRate);
                            }
                            // Create an Option for DropDownList.

                            //   alert("ttl" + OptionTextRate);


                            if (OptionValueTax != 0) {
                                if (OptionTaxPercentage != "") {
                                    if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                                        var taxAmt = ((total * OptionTaxPercentage) / 100);
                                        $noCon("#txtTaxAmt" + rowCount).val(taxAmt);
                                        $noCon("#TaxPer" + rowCount).val(OptionTaxPercentage);
                                    }
                                }
                            }
                            else {
                                if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                                    $noCon("#txtTaxAmt" + rowCount).val(0);
                                    $noCon("#TaxPer" + rowCount).val(0);
                                }
                            }

                            // alert(taxAmt);
                            //var optionTax = $noCon("<option>" + OptionTextTax + "</option>");
                            //optionTax.attr("value", OptionValueTax);
                            //ddlTestDropDownListXMLTax.append(optionTax);
                            // VartxtRate.append(OptionTextRate);
                            if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                                if (Tax == null || Tax == "") {
                                    if (OptionValueTax != "" && OptionTextTax != "") {
                                        var arrayTax1 = JSON.parse("[" + OptionValueTax + "]");
                                        $noCon("#ddlTax" + rowCount).val(OptionValueTax);
                                        $noCon("#ddlTaxText" + rowCount).val(OptionTextTax);
                                    }
                                    else {
                                        var arrayTax1 = ""
                                        $noCon("#ddlTaxText" + rowCount).val(arrayTax1);
                                        $noCon("#ddlTax" + rowCount).val(arrayTax1);
                                    }
                                }
                            }

                            if (RATE != null && RATE != "") {
                                $noCon("#txtRate" + rowCount).val(RATE);

                            }
                            else if (OptionTextRate != null) {
                                // alert(OptionTextRate);
                                $noCon("#txtRate" + rowCount).val(OptionTextRate);
                            }


                            var varTax = "";
                            if (Tax != null)
                                varTax = Tax;
                            //if (varTax != "") {

                            //    var arrayTax = JSON.parse("[" + Tax + "]");
                            //    $noCon("#ddlTaxText" + rowCount).val(arrayTax);
                            //   // $noCon("#ddlTaxText" + rowCount).val(arrayTax);
                            //}
                            //BlurValue(rowCount, 'ddlTaxText');
                        });
                    },
                    failure: function (response) {

                    }
                });
                //  alert(document.getElementById("txtTaxAmt" + rowCount).value + "pjknjhkner");
                if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {

                    addCommas("txtTaxAmt" + rowCount);
                }


            }
        function CheckaddMoreRows(x) {
         
                //alert(x);
            //  BlurValue(x, 'txtDisPercent');
            if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                $('#SpanAdd' + x).attr('disabled', true);
                $('#SpanDel' + x).attr('disabled', true);
                return false;
            }
                if (LimitTableCheck() == true && ProductDuplication(x) == true) {
                    // document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.6";
                    //   document.getElementById("SpanAdd" + x).disabled = true;
                    //$("SpanAdd" + x).attr("disabled", true);
                    document.getElementById('SpanAdd' + x).style.pointerEvents = 'none';
                    document.getElementById('SpanAdd' + x).disabled = true;
                    // document.getElementById('SpanAdd' + x).onclick = false;
                    addMoreRows();
                    var y = x + 1;
                    document.getElementById("ddlProduct_" + y).focus();
                    // $("ddlProduct_" + y).focus();
                    return false;
                }
                return false;
            }

            function LimitTableCheck() {

                var ret = true;
                var table = document.getElementById("TableaddedRows");
                    $('#TableaddedRows').find('tr').each(function () {
                    var row = $(this);
                    var x = $('td:first-child', row).html();
                    var table = document.getElementById("TableaddedRows");
                    var xLength = table.rows.length;
                    //  alert(rowid);
                    if (x != "") {

                        document.getElementById("txtQntity" + x).style.borderColor = "";
                        $("div#divProduct_" + x).css('border', '');

                        var value = $aa('#ddlProduct_' + x).val();


                        //   if (value != "" || xLength==1) {

                        var Qntity = document.getElementById("txtQntity" + x).value;
                        if (Qntity == "" || Qntity <= 0) {
                            document.getElementById("txtQntity" + x).style.borderColor = "Red";
                            document.getElementById("txtQntity" + x).focus();

                            ret = false;
                        }

                        var Rate = document.getElementById("txtRate" + x).value;
                        if (Rate == "" || Rate <= 0) {
                            document.getElementById("txtRate" + x).style.borderColor = "Red";
                            document.getElementById("txtRate" + x).focus();

                            ret = false;
                        }

                        if (value == "" || value == null) {
                            $("div#divProduct_" + x).css('border', '0.5px solid rgb(255, 0, 0)');
                            document.getElementById("ddlProduct_" + x).focus();
                            //  $(".ddlProduct_" + x).focus();
                            ret = false;


                        }
                        // }
                    }
                });




                if (ret == true) {
                    var tbClientTotalValues = '';
                    tbClientTotalValues = [];

                    var cbGatePassStatus;
                    var DisPerct = "0";
                    var DisAmt = "";
                    var todate = "0";
                    var table = document.getElementById("TableaddedRows");
                    $('#TableaddedRows').find('tr').each(function () {
                        var row = $(this);
                        var i = $('td:first-child', row).html();
                        //  alert(rowid);
                        if (i != "") {

                            var xLoop = i;

                            var prdct = document.getElementById("ProductId" + i).value;
                            //  alert(prdct);
                            if (prdct != "") {
                                var AddButton = $noconfli("#tdIndvlAddMoreRow" + i);

                                if (AddButton.length) {
                                    var tax = 0;
                                    var taxAmt = 0;
                                    var slno = document.getElementById("txtSlno" + i).value;
                                    var prdct = document.getElementById("ProductId" + i).value;
                                    var qty = document.getElementById("txtQntity" + i).value;
                                    var rate = document.getElementById("txtRate" + i).value;
                                    if (document.getElementById("txtDisPercent" + i).value != "" && document.getElementById("txtDisPercent" + i).value != null) {
                                        DisPerct = document.getElementById("txtDisPercent" + i).value;
                                    }
                                    else {
                                        DisPerct = 0;
                                    }
                                    // alert(i + "  i");
                                    // alert(DisPerct + "  gvevgv");
                                    if (document.getElementById("txtDisAmt" + i).value != "") {
                                        DisAmt = document.getElementById("txtDisAmt" + i).value;
                                    }
                                    // alert(DisAmt + "save");
                                    if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {

                                        if (document.getElementById("ddlTax" + i).value != "" && document.getElementById("ddlTax" + i).value != "null") {
                                            tax = document.getElementById("ddlTax" + i).value;
                                        }
                                        if (document.getElementById("txtTaxAmt" + i).value != "") {
                                            taxAmt = document.getElementById("txtTaxAmt" + i).value;
                                        }
                                    }
                                    var price = document.getElementById("txtPrice" + i).value;
                                    var detailId = document.getElementById("tdDtlId" + i).innerHTML;
                                    var evt = document.getElementById("tdEvt" + i).innerHTML;
                                    var gross = document.getElementById("<%=HiddenGrossAmt.ClientID%>").value;
                                    var netTax = document.getElementById("<%=HiddenTax.ClientID%>").value;
                                    var NetTotal_Exchng = document.getElementById("<%=HiddenTotal_Exchng.ClientID%>").value;
                                    var dis = document.getElementById("<%=Hiddendiscount.ClientID%>").value;
                                    var net = document.getElementById("<%=HiddenNetAmt.ClientID%>").value;
                                    // alert(evt);
                                    var client = JSON.stringify({
                                        ROWID: "" + i + "",
                                        SLNO: "" + slno + "",
                                        PRODUCT: "" + prdct + "",
                                        QUANTITY: "" + qty + "",
                                        RATE: "" + rate + "",
                                        DISPERCENTAGE: "" + DisPerct + "",
                                        DISCOUNTAMT: "" + DisAmt + "",
                                        TAX: "" + tax + "",
                                        TAXAMT: "" + taxAmt + "",
                                        PRICE: "" + price + "",
                                        GROSS: "" + gross + "",
                                        NETTAX: "" + netTax + "",
                                        NETDISCOUNT: "" + dis + "",
                                        NETAMT: "" + net + "",
                                        EVTACTION: "" + evt + "",
                                        DTLID: "" + detailId + "",
                                        XLOOP: "" + xLoop + "",
                                    });
                                    tbClientTotalValues.push(client);
                                }
                            }
                        }
                    });
                    document.getElementById("<%=HiddenAdd.ClientID%>").value = JSON.stringify(tbClientTotalValues);
                }
                return ret;
            }


            function PurchaseValidate() {
                var ret = true;
                var CostFlag = 0;
                var dupflg = true;
                document.getElementById("<%=txtdate.ClientID%>").style.border = "";
                document.getElementById("<%=ddlCustomerLdgr.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtExchangeRate.ClientID%>").style.borderColor = "";

                $noCon("div#divddlCustomerLdgr input.ui-autocomplete-input").css("borderColor", "");

                var CurrencyId = "";
                if (document.getElementById("<%=ddlCurrency.ClientID%>").value != "--SELECT CURRENCY--") {
                    CurrencyId = document.getElementById("<%=ddlCurrency.ClientID%>").value;
                }
                var DftCurrencyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
                if (CurrencyId != "") {
                    if (CurrencyId != DftCurrencyId) {
                        if (document.getElementById("<%=txtExchangeRate.ClientID%>").value == "") {
                            document.getElementById("<%=txtExchangeRate.ClientID%>").style.borderColor = "red";
                            ret = false;
                        }
                    }
                }
                if (document.getElementById("<%=txtdate.ClientID%>").value == "") {
                    document.getElementById("<%=txtdate.ClientID%>").style.borderColor = "red";
                    ret = false;
                }

                document.getElementById("<%=txtAddress1.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtsplrName.ClientID%>").style.borderColor = "";


                var acntflg = true;
                var acntSts = document.getElementById("cphMain_HiddenDefaultLdgrSts").value;
                if (acntSts == 1) {
                    acntflg = false;
                }
                else {
                    acntflg = true;
                }

                document.getElementById("<%=txtsplrName.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtAddress1.ClientID%>").style.borderColor = "";

                if (document.getElementById("<%=cbxExtngSplr.ClientID%>").checked == true) {

                    acntflg = true;
                    if (document.getElementById("<%=ddlCustomerLdgr.ClientID%>").value == "--SELECT SUPPLIER --") {
                    // alert();
                    $noCon("div#divddlCustomerLdgr input.ui-autocomplete-input").css("borderColor", "red");

                    $noCon("div#divddlCustomerLdgr input.ui-autocomplete-input").focus();
                    $noCon("div#divddlCustomerLdgr input.ui-autocomplete-input").select();
                    ret = false;
                }
            }
            else {

                if (document.getElementById("<%=txtsplrName.ClientID%>").value.trim() == "") {
                        document.getElementById("<%=txtsplrName.ClientID%>").style.borderColor = "red";
                        ret = false;
                    }


                    if (document.getElementById("<%=txtAddress1.ClientID%>").value.trim() == "") {
                        document.getElementById("<%=txtAddress1.ClientID%>").style.borderColor = "red";
                        ret = false;
                    }
                }

                if (document.getElementById("<%=HiddenCurrncyId.ClientID%>").value != document.getElementById("cphMain_ddlCurrency").value) {
                    if (document.getElementById("<%=HiddenInventoryForex.ClientID%>").value == "1") {
                        var ExchngRt = document.getElementById("<%=txtExchangeRate.ClientID%>").value;



                        var x = ExchngRt.split(' ');




                        if (document.getElementById("<%=txtExchangeRate.ClientID%>").value.trim() == "" || x[0] <= 0) {

                            document.getElementById("<%=txtExchangeRate.ClientID%>").style.borderColor = "red";
                            ret = false;
                        }

                    }
                }
                var ProductLdgrFlag = true;
                var DfltProductLdgr = document.getElementById("cphMain_HiddenDfltProductLdgr").value;
                if (DfltProductLdgr == "") {
                    ProductLdgrFlag = false;
                }
                var ProductDup = true;

                $('#TableaddedRows').find('tr').each(function () {
                    var row = $(this);
                    var x = $('td:first-child', row).html();
                    var table = document.getElementById("TableaddedRows");
                    var xLength = table.rows.length;
                    //  alert(rowid);
                    var TotalCost = 0;

                    if (x != "")
                    {
                        var costCntrAmt = document.getElementById("txtPrice" + x).value.replace(/,/g, "");
                        var CstCntrDtl = document.getElementById("tdCostCenterDtls" + x).value;
                        if (CstCntrDtl != "") {
                            var splitrow = CstCntrDtl.split("$");

                            for (var Cst = 0; Cst < splitrow.length; Cst++) {
                                var splitEach = splitrow[Cst].split("%");

                                if (splitEach[1] != "") {
                                    TotalCost = parseFloat(TotalCost) + parseFloat(splitEach[1].replace(/,/g, ""));
                                }
                            }

                            if (TotalCost != costCntrAmt) {
                                //  ret = false;
                                CostFlag = 1;
                            }

                        }

                        if (ProductDuplication(x) == false)
                        {
                            ProductDup = false;
                        }

                        document.getElementById("txtQntity" + x).style.borderColor = "";
                        $("div#divProduct_" + x).css('border', '');

                        var value = $aa('#ddlProduct_' + x).val();


                        if (value != "" || xLength == 1) {

                            var Qntity = document.getElementById("txtQntity" + x).value;
                            if (Qntity == "" || Qntity <= 0) {
                                document.getElementById("txtQntity" + x).style.borderColor = "Red";
                                document.getElementById("txtQntity" + x).focus();

                                ret = false;
                            }


                            var Rate = document.getElementById("txtRate" + x).value;
                            if (Rate == "" || Rate <= 0) {
                                document.getElementById("txtRate" + x).style.borderColor = "Red";
                                document.getElementById("txtRate" + x).focus();

                                ret = false;
                            }


                            if (value == "" || value == null) {
                                $("div#divProduct_" + x).css('border', '0.5px solid rgb(255, 0, 0)');
                                document.getElementById("ddlProduct_" + x).focus();
                                //  $(".ddlProduct_" + x).focus();
                                ret = false;


                            }
                        }
                    }
                });


                //   }


                if (ret == true) {
                    var chkDup = checkDuplication();
                    if (chkDup == true) {
                        dupflg = true;
                        // ret = true;

                    }
                    else {


                        dupflg = false;
                    }
                }


                if (ret == true && dupflg == true) {

                    var tbClientTotalValues = '';
                    tbClientTotalValues = [];
                    var tbClientUploadValues = '';
                    tbClientUploadValues = [];
                    var cbGatePassStatus;
                    var DisPerct = "0";
                    var DisAmt = "";
                    var todate = "0";
                    document.getElementById("<%=HiddenUploadInfo.ClientID%>").value = "";
                    var table = document.getElementById("TableaddedRows");
                    $('#TableaddedRows').find('tr').each(function () {
                        var row = $(this);
                        var i = $('td:first-child', row).html();

                        if (i != "") {
                            var prdct = document.getElementById("ProductId" + i).value;

                            if (prdct != "") {
                                var AddButton = $noconfli("#tdIndvlAddMoreRow" + i);

                                if (AddButton.length) {

                                    var tax = 0;
                                    var taxAmt = 0;
                                    var slno = document.getElementById("txtSlno" + i).value;
                                    var prdct = document.getElementById("ProductId" + i).value;
                                    var qty = document.getElementById("txtQntity" + i).value;
                                    var rate = document.getElementById("txtRate" + i).value;
                                    if (document.getElementById("txtDisPercent" + i).value != "" && document.getElementById("txtDisPercent" + i).value != null) {
                                        DisPerct = document.getElementById("txtDisPercent" + i).value;
                                    }
                                    else {
                                        DisPerct = 0;
                                    }
                                    // alert(i + "  i");
                                    // alert(DisPerct + "  gvevgv");
                                    if (document.getElementById("txtDisAmt" + i).value != "") {
                                        DisAmt = document.getElementById("txtDisAmt" + i).value;
                                    }
                                    // alert(DisAmt + "save");
                                    if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {

                                        if (document.getElementById("ddlTax" + i).value != "" && document.getElementById("ddlTax" + i).value != "null") {
                                            tax = document.getElementById("ddlTax" + i).value;
                                        }
                                        if (document.getElementById("txtTaxAmt" + i).value != "") {
                                            taxAmt = document.getElementById("txtTaxAmt" + i).value;
                                        }
                                    }
                                    var price = document.getElementById("txtPrice" + i).value;
                                    var detailId = document.getElementById("tdDtlId" + i).innerHTML;
                                    var evt = document.getElementById("tdEvt" + i).innerHTML;
                                    var Remark = document.getElementById("tdProductRemark" + i).innerHTML;
                                  
                                   
                                    var gross = document.getElementById("<%=HiddenGrossAmt.ClientID%>").value;
                                    var netTax = document.getElementById("<%=HiddenTax.ClientID%>").value;
                                    var NetTotal_Exchng = document.getElementById("<%=HiddenTotal_Exchng.ClientID%>").value;
                                    var dis = document.getElementById("<%=Hiddendiscount.ClientID%>").value;
                                    var net = document.getElementById("<%=HiddenNetAmt.ClientID%>").value;

                                    // alert(evt);
                                    var client = JSON.stringify({
                                        ROWID: "" + i + "",
                                        SLNO: "" + slno + "",
                                        PRODUCT: "" + prdct + "",
                                        QUANTITY: "" + qty + "",
                                        RATE: "" + rate + "",
                                        DISPERCENTAGE: "" + DisPerct + "",
                                        DISCOUNTAMT: "" + DisAmt + "",
                                        TAX: "" + tax + "",
                                        TAXAMT: "" + taxAmt + "",
                                        PRICE: "" + price + "",
                                        GROSS: "" + gross + "",
                                        NETTAX: "" + netTax + "",
                                        NETDISCOUNT: "" + dis + "",
                                        NETAMT: "" + net + "",
                                        EVTACTION: "" + evt + "",
                                        DTLID: "" + detailId + "",
                                        //REMARK: "" + Remark + ""
                                    });
                                    tbClientTotalValues.push(client);
                                }
                            }
                        }
                    });

                    var table = document.getElementById("TableFileCCN");
                    $('#TableFileCCN').find('tr').each(function () {
                        var row = $(this);
                        var i = $('td:first-child', row).html();
                        if (i != "") {
                            var FileUpdId = document.getElementById("tdFileId" + i).value;
                            if (FileUpdId != "") {
                                var AddButton = $noconfli("#FileIndvlAddMoreRow" + i);
                                if (AddButton.length) {
                                    var FilePath = document.getElementById("filePath" + i).innerHTML;
                                    var FdetailId = document.getElementById("FileDtlId" + i).innerHTML;
                                    var Fevt = document.getElementById("FileEvt" + i).innerHTML;
                                    if (Fevt == 'INS') {
                                        var $addFile = jQuery.noConflict();
                                        var client = JSON.stringify({
                                            ROWID: "" + i + "",
                                            FILENAME: "" + FilePath + "",
                                            EVTACTION: "" + Fevt + "",
                                            DTLID: "0"

                                        });
                                    }
                                    else if (Fevt == 'UPD') {
                                        var $addFile = jQuery.noConflict();
                                        FilePath = document.getElementById("DbFileName" + i).innerHTML;
                                        var client = JSON.stringify({
                                            ROWID: "" + i + "",
                                            FILENAME: "" + FilePath + "",
                                            EVTACTION: "" + Fevt + "",
                                            DTLID: "" + FdetailId + ""

                                        });
                                    }
                                    tbClientUploadValues.push(client);
                                }
                            }
                        }
                    });
                    document.getElementById("<%=HiddenUploadInfo.ClientID%>").value = JSON.stringify(tbClientUploadValues);
                    document.getElementById("<%=HiddenAdd.ClientID%>").value = JSON.stringify(tbClientTotalValues);

                }
                if (ret == true && dupflg == true) {
                    document.getElementById("<%=txtNetTotal.ClientID%>").disabled = false;
                }
                if (ret == false && acntflg == true && dupflg == true ) {
                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    $noCon1(window).scrollTop(0);
                }
                else if (ret == false && acntflg == false && dupflg == true) {
                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    $noCon1(window).scrollTop(0);
                }
                else if (ret == true && acntflg == false && dupflg == true) {
                    $noCon("#divWarning").html("Please define an account head  for supplier before creating new purchase");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    $noCon1(window).scrollTop(0);
                    ret = false;
                }


                else if (ret == false && acntflg == true && dupflg == false) {
                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    $noCon1(window).scrollTop(0);
                }
                else if (ret == false && acntflg == false && dupflg == false) {
                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    $noCon1(window).scrollTop(0);
                }
                else if (ret == true && acntflg == false && dupflg == false) {
                    $noCon("#divWarning").html("Please define an account head  for supplier before creating new purchase");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    $noCon1(window).scrollTop(0);
                    ret = false;
                }

                else if (ret == true && acntflg == true && dupflg == false) {
                    $noCon("#divWarning").html("Duplication Error!. Order number can’t be duplicated.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    $noCon1(window).scrollTop(0);
                    ret = false;
                }
                else if (ProductDup == false) {
                    $noCon("#divWarning").html("Duplication Error!. Pruducts can’t be duplicated.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    $noCon1(window).scrollTop(0);
                    ret = false;
                }
                else if (ProductLdgrFlag == false) {
                    $noCon("#divWarning").html("Please define an account head  for purchase before creating new purchase");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    $noCon1(window).scrollTop(0);
                    ret = false;
                }

                if ( CostFlag == 1) {
                    $noCon("#divWarning").html("Product amount should be equal to cost centre amount.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    $noCon1(window).scrollTop(0);
                    ret = false;
                }
                      

               
                   
                 

                if (ret == true) {
                    document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value = "";
                    document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value = "";
                    document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value = "";
                }



           
                return ret;
            }
        function ConfirmAlert() {

            if (PurchaseValidate() == true) {

                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to confirm this purchase?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        document.getElementById("<%=btnConfirm1.ClientID%>").click();
                } else {
                    return false;
                }

                });
            return false;
            }
            return false;
    }
            function ProductDuplication(rowId) {
                var addRowtable = "";
                var ret = true;
                var flag = 0;
                addRowtable = document.getElementById("TableaddedRows");
                var ProductDupCheck = document.getElementById("<%=HiddenProductDupSts.ClientID%>").value;

                if (ProductDupCheck == "1") {
                    return true;

                }
                else {
                    for (var i = 0; i < addRowtable.rows.length; i++) {
                        var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                        var xLoopLdgrId = $("#ddlProduct_" + xLoop).val();
                        var LedgerId = $("#ddlProduct_" + rowId).val();
                        if (xLoop != rowId) {
                            if (xLoopLdgrId == LedgerId) {
                                $noCon("#divWarning").html("Products should not be duplicated.");
                                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                                });

                                $noCon("div#divProduct_" + rowId + " input.ui-autocomplete-input").css("borderColor", "red");


                                $noCon("div#divProduct_" + rowId + " input.ui-autocomplete-input").select();

                                $noCon(window).scrollTop(0);

                                return false;

                            }
                        }
                    }
                }
                return ret;
            }

            function checkDuplication() {
                var orderNo = document.getElementById("<%=txtOrder.ClientID%>").value;
                var orgID = '<%= Session["ORGID"] %>';
                var corptID = '<%= Session["CORPOFFICEID"] %>';
                var UserID = '<%= Session["USERID"] %>';
                var ret = true;
                var PurchaseDate = document.getElementById("<%=txtdate.ClientID%>").value;
                var FinancialEndDate = document.getElementById("<%=HiddenFincancialEndDate.ClientID%>").value;
                var purchaseId = document.getElementById("<%=HiddenPurchaseid.ClientID%>").value;

                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "Purchase_master.aspx/CheckDuplication",
                    data: '{orderNo: "' + orderNo + '",orgID: "' + orgID + '",corptID: "' + corptID + '",UserID: "' + UserID + '",purchaseId: "' + purchaseId + '",PurchaseDate: "' + PurchaseDate + '"}',
                    dataType: "json",
                    success: function (data) {
                        // alert(data.d);

                        if (data.d != "") {



                            if (data.d == "false") {
                                ret = false;
                            }
                            else {
                                ret = true;
                            }

                            //   document.getElementById("cphMain_TxtRef").value = data.d;
                        }
                    }
                });
                return ret;

            }



        </script>
      <%-- //Design  Purchase ,Cost centr , Remark--%>
    <script>
     

        var rowSubCatagory = 0;
        var RowNum = 0;
        var rowsl_no = 0;
        function addMoreRows() {
            rowsl_no++;
            RowNum++;
            // alert(RowNum + "RowNum");
        

            document.getElementById("<%=HiddenRowNo.ClientID%>").value = RowNum;
             if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {

                 var recRow = '<tr  id="rowId_' + RowNum + '">';
                 recRow += '<td   id="tdidGrpDtls' + RowNum + '" style="display: none" >' + RowNum + '</td>';
                 recRow += '<td > ' + rowsl_no + '<input tabindex=\"-1\" style=\"  display:none\" disabled  id=\"txtSlno' + RowNum + '\" Value=\"' + rowsl_no + '\" maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\"  class=\"form-control\" /></td>';
                 recRow += '<td> <div class=\"input-group in_flw\" id=\"divProduct_' + RowNum + '\"><input id=\"ddlProduct_' + RowNum + '\"  placeholder="--Select Item--"  type=\"text\"   onkeydown=\"return isTag(event)\" onchange= \"ChangeProduct(' + RowNum + ')\" onblur="return BlurValue(' + RowNum + ',\'ddlProduct_\')" onkeypress=\"return DisableEnter(event)\"    onkeydown=\"return IncrmntConfrmCounter()\" class=\"fg2_inp2 fg2_inp3 fg_chs1 in_flw\"/> ';
                 recRow += '<a href=\"javascript:;\"  onclick=\"OpenProduct(' + RowNum + ');\"  class=\"input-group-addon cur1 spn1_pro gren\" title=\"Add\"> <i class="fa fa-plus-circle"></i></a> </div></td>';
                 recRow += '<td style=\"  display:none\"><input id=\"txtproductId' + RowNum + '\"   name=\"txtproductId' + RowNum + '\"  type=\"text\"  class=\"form-control\" /> <input id=\"txtproductName' + RowNum + '\"   name=\"txtproductName' + RowNum + '\"  type=\"text\"  class=\"fg2_inp2 fg2_inp3 fg_chs1 in_flw\" /></td> ';

                 recRow += '<td ><input  autocomplete=\'off\'   id=\"txtQntity' + RowNum + '\"   maxlength=\"8\" onkeypress=\"return isNumberAmount(event,\'txtQntity' + RowNum + '\')\" onkeydown=\"return isNumberAmount(event,\'txtQntity' + RowNum + '\')\" onblur="return BlurValue(' + RowNum + ',\'txtQntity\')" type=\"text\"  class=\"form-control fg2_inp2 inp_mst tr_c\" /></td>';
                 recRow += '<td ><input  autocomplete=\'off\'   id=\"txtRate' + RowNum + '\"  maxlength=\"10\" onblur="return BlurValue(' + RowNum + ',\'txtRate\')" onkeypress=\"return isNumberAmount(event,\'txtRate' + RowNum + '\');\" onkeydown=\"return isNumberAmount(event,\'txtRate' + RowNum + '\')\" type=\"text\"  class=\"form-control fg2_inp2 tr_r\" /></td>';
                 recRow += '<td> <div class=\"input-group ing1\"><input  autocomplete=\'off\' id=\"txtDisPercent' + RowNum + '\"   maxlength=\"5\" onkeypress=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\"  onkeydown=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onblur="return BlurValue(' + RowNum + ',\'txtDisPercent\')" type=\"text\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /> <span class=\"input-group-addon cur1 spn1_pro pur_pe\">%</span></div>';
                 recRow += '<div class=\"input-group ing2\"><input  autocomplete=\'off\'   id=\"txtDisAmt' + RowNum + '\"   maxlength=\"10\" onkeypress=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\" onkeydown=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + ')\"   onblur="return BlurValue(' + RowNum + ',\'txtDisAmt\')" type=\"text\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span></div></td>';
                    recRow += '<td ><input id=\"ddlTaxText' + RowNum + '\" disabled  maxlength=\"10\" onkeypress=\"return isNumber(event)\" onblur="return BlurValue(' + RowNum + ',\'ddlTax\')" type=\"text\"  class=\"form-control fg2_inp2 tr_l inp_3_1\" /> ';
                    recRow += '<div class="input-group ing1 inp_3_2"><input  id=\"TaxPer' + RowNum + '\" disabled tabindex=\"-1\" maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /> <span class="input-group-addon cur1 spn1_pro pur_pe">%</span></div>';
                    recRow += '<div class="input-group ing2 inp_3_3"><input id=\"txtTaxAmt' + RowNum + '\"   disabled=\"disabled\" tabindex=\"-1\"   maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span></td>';
                    recRow += '<td ><input tabindex=\"-1\" id=\ "txtPrice' + RowNum + '\"   maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\"  class=\"form-control fg2_inp2 tr_r\" /></td>';
                    recRow += '<td  class="td1" id= tdIndvlAddMoreRow' + RowNum + ' > <div class="btn_stl1"><a href="javascript:;" id="\DivAddComment_' + RowNum + '\" onclick="OpenComment(' + RowNum + ');"  class=\"btn act_btn bn9\" title=\"Add Remark\"><i class="fa fa-commenting"></i></a> ';
                    recRow += '<a  href="javascript:;" id=\"SpanAdd' + RowNum + '\"  onclick=\"return CheckaddMoreRows(' + RowNum + ');\"  class=\"btn act_btn bn2\" title=\"Add\"><i class="fa fa-plus-circle"></i> </a>';
                    recRow += '<a  href="javascript:;"  onclick=\"return CheckDelEachRow(' + RowNum + ');\"   class=\"btn act_btn bn3\" title=\"Delete\"><i class="fa fa-trash"></i></a></div></td>';
                    recRow += '<td><a href="javascript:;" id="\DivCostCentre_' + RowNum + '\" onclick="MyModalCostCenter(\'' + RowNum + '\',\'' + rowSubCatagory + '\',null);"title=\"Add Cost Centre\">  <i class=\"fa fa-filter ad_fa\"></i></a></td> ';
                    recRow += '<td id="tdEvt' + RowNum + '" style="display: none;">INS</td>';
                    recRow += '<td id="tdDtlId' + RowNum + '" style="display: none;"></td>';
                    recRow += '<td style="display: none;" ><input id=\"ddlTax' + RowNum + '\" style="display: none;" > </td> ';
                    recRow += '<td style="display: none;"  ><input id=\"TaxPer' + RowNum + '\" style="display: none;" > </td> ';
                    recRow += '<td style="display: none;"  ><input id=\"ProductId' + RowNum + '\" style="display: none;" > </td> ';
                    recRow += '<td id="tdProductRemark' + RowNum + '" style="display: none;"></td>';
                    recRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdCostCenterDtls' + RowNum + '" name="tdCostCenterDtls' + RowNum + '" placeholder=""/></td>';
                    recRow += '<td  style="width:0%;display: none;"><input id=\"remarktxt' + RowNum + '\" name=\"remarktxt' + RowNum + '\" style="display: none;" > </td> ';
                }
                else {
                    var recRow = '<tr  id="rowId_' + RowNum + '">';
                    recRow += '<td   id="tdidGrpDtls' + RowNum + '" style="display: none" >' + RowNum + '</td>';
                    recRow += '<td >' + rowsl_no + '<input tabindex=\"-1\" style="display: none" disabled id=\"txtSlno' + RowNum + '\" Value=\"' + rowsl_no + '\" maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\"  class=\"form-control\" /></td>';


                    

                    recRow += '<td > <div class=\"input-group in_flw\" id=\"divProduct_' + RowNum + '\"><input  placeholder="--Select Item--"  id=\"ddlProduct_' + RowNum + '\" type=\"text\"  onkeydown=\"return isTag(event)\" onchange= \"ChangeProduct(' + RowNum + ')\" onblur="return BlurValue(' + RowNum + ',\'ddlProduct_\')" onkeypress=\"return DisableEnter(event)\"    onkeydown=\"return IncrmntConfrmCounter()\"  class=\"fg2_inp2 fg2_inp3 fg_chs1 in_flw\"/> ';
                    recRow += '<a href=\"javascript:;\"  onclick=\"OpenProduct(' + RowNum + ');\" class=\"input-group-addon cur1 spn1_pro gren\" title=\"Add\"><i class="fa fa-plus-circle"></i></a> </div></td>';
                    recRow += '<td style=\" display:none\"><input id=\"txtproductId' + RowNum + '\"   name=\"txtproductId' + RowNum + '\"  type=\"text\"  class=\"form-control\" /> <input id=\"txtproductName' + RowNum + '\"   name=\"txtproductName' + RowNum + '\"  type=\"text\"  class=\"form-control\" /></td> ';

                    recRow += '<td ><input   autocomplete=\'off\'  id=\"txtQntity' + RowNum + '\"   maxlength=\"8\" onkeypress=\"return isNumberAmount(event,\'txtQntity' + RowNum + '\')\" onkeydown=\"return isNumberAmount(event,\'txtQntity' + RowNum + '\')\" onblur="return BlurValue(' + RowNum + ',\'txtQntity\')" type=\"text\"  class=\"form-control fg2_inp2 inp_mst tr_c\" /></td>';
                    recRow += '<td ><input  autocomplete=\'off\'  id=\"txtRate' + RowNum + '\"   maxlength=\"10\" onkeypress=\"return isNumberAmount(event,\'txtRate' + RowNum + '\')\" onkeydown=\"return isNumberAmount(event,\'txtRate' + RowNum + '\')\" type=\"text\" onblur="return BlurValue(' + RowNum + ',\'txtRate\')"  class=\"form-control fg2_inp2 tr_r\" /></td>';

                    recRow += '<td ><div class=\"input-group ing1\"><input  autocomplete=\'off\'  id=\"txtDisPercent' + RowNum + '\"   maxlength=\"5\" onkeypress=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onkeydown=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onblur="return BlurValue(' + RowNum + ',\'txtDisPercent\')" type=\"text\"  class=\"fg2_inp2 tr_r inp1_pro\" /><span class=\"input-group-addon cur1 spn1_pro pur_pe\">%</span></div>';
                    recRow += '<div class=\"input-group ing2\"><input  autocomplete=\'off\'    id=\"txtDisAmt' + RowNum + '\"   maxlength=\"10\" onkeypress=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\" onkeydown=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\" onblur="return BlurValue(' + RowNum + ',\'txtDisAmt\')" type=\"text\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span></div></td>';



                    recRow += '<td ><input tabindex=\"-1\" id=\ "txtPrice' + RowNum + '\"   maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\"  class=\"form-control fg2_inp2 tr_r\" /></td>';
                    recRow += '<td class="td1" id= tdIndvlAddMoreRow' + RowNum + '> <div class="btn_stl1"><a href="javascript:;" id="\DivAddComment_' + RowNum + '\" onclick="OpenComment(' + RowNum + ');"  class=\"btn act_btn bn9\" title=\"Add Remark\"><i class="fa fa-commenting"></i></a> ';

                    recRow += '<a  href="javascript:;"  id=\"SpanAdd' + RowNum + '\"  onclick=\"return CheckaddMoreRows(' + RowNum + ');\"  class=\"btn act_btn bn2\" title=\"Add\"><i class="fa fa-plus-circle"></i> </a>';
                    recRow += '<a  href="javascript:;" onclick=\"return CheckDelEachRow(' + RowNum + ');\"   class=\"btn act_btn bn3\" title=\"Delete\"><i class="fa fa-trash"></i></a></div></td>';
                    recRow += '<td ><a href="javascript:;" id="\DivCostCentre_' + RowNum + '\" onclick="MyModalCostCenter(\'' + RowNum + '\',\'' + rowSubCatagory + '\',null);" title=\"Add Cost Centre\">  <i class=\"fa fa-filter ad_fa\"></i></a></td> ';
                    recRow += '<td id="tdEvt' + RowNum + '" style="display: none;">INS</td>';
                    recRow += '<td id="tdDtlId' + RowNum + '" style="display: none;"></td>';
                    recRow += '<td  style="display: none;" ><input id=\"ddlTax' + RowNum + '\" style="display: none;" > </td> ';
                    recRow += '<td  style="display: none;"><input id=\"TaxPer' + RowNum + '\" style="display: none;" > </td> ';
                    recRow += '<td  style="display: none;"><input id=\"ProductId' + RowNum + '\" style="display: none;" > </td> ';
                    recRow += '<td id="tdProductRemark' + RowNum + '" style="display: none;"></td>';
                    recRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdCostCenterDtls' + RowNum + '" name="tdCostCenterDtls' + RowNum + '" placeholder=""/></td>';
                    recRow += '<td  style="width:0%;display: none;"><input id=\"remarktxt' + RowNum + '\" name=\"remarktxt' + RowNum + '\" style="display: none;" > </td> ';

                }
                recRow += '</tr>';
                jQuery('#TableaddedRows').append(recRow);
                ProductsLoad(RowNum);

                document.getElementById('txtPrice' + RowNum).disabled = true;

                document.getElementById("txtQntity" + RowNum).readOnly = true;
                document.getElementById("txtRate" + RowNum).readOnly = true;

                document.getElementById('txtDisPercent' + RowNum).disabled = true;

                document.getElementById('txtDisAmt' + RowNum).disabled = true;

                buttnVisibile();
            }

            function EditListRows(PURCHSE_ID, PRODUCT_ID, PRODUCTROW, SLNO, QUANTITY, RATE, DISPER, DISAMT, TAX, TAXAMT, PRICE, TAXTEXT, TAXPERCENTAGE, PRODUCT_NAME, PRDCT_CHCK, PURCHS_PRDUCT_REMARK, COSTCENTRE) {
                RowNum++;
                rowsl_no++;
                document.getElementById("<%=HiddenRowNo.ClientID%>").value = RowNum;
                if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                    var recRow = '<tr  id="rowId_' + RowNum + '">';
                    recRow += '<td   id="tdidGrpDtls' + RowNum + '" style="display: none" >' + RowNum + '</td>';

                    recRow += '<td >' + rowsl_no + '<input style="display: none" disabled  id=\"txtSlno' + RowNum + '\" Value=\"' + rowsl_no + '\" tabindex=\"-1\" maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\"  class=\"form-control\" /></td>';


                    //recRow += '<td> <div class=\"input-group in_flw\" id=\"divProduct_' + RowNum + '\"><input id=\"ddlProduct_' + RowNum + '\"  placeholder="--Select Item--"  type=\"text\"   onkeydown=\"return isTag(event)\" onchange= \"ChangeProduct(' + RowNum + ')\" onblur="return BlurValue(' + RowNum + ',\'ddlProduct_\')" onkeypress=\"return DisableEnter(event)\"    onkeydown=\"return IncrmntConfrmCounter()\" class=\"fg2_inp2 fg2_inp3 fg_chs1 in_flw\"/> ';
                    //recRow += '<a href=\"javascript:;\"  onclick=\"OpenProduct(' + RowNum + ');\"  class=\"input-group-addon cur1 spn1_pro gren\" title=\"Add\"> <i class="fa fa-plus-circle"></i></a> </div></td>';


                    recRow += '<td><div class=\"input-group in_flw\"  id=\"divProduct_' + RowNum + '\"> <input placeholder="--Select Item--"  id=\"ddlProduct_' + RowNum + '\"   value=\"' + PRODUCT_NAME + '\" type=\"text\"   onkeydown=\"return isTag(event)\" onchange=\"FillddlTax(' + RowNum + ',' + null + ',' + null + ')\" onblur="return BlurValue(' + RowNum + ',\'ddlProduct_\')" onkeypress=\"return DisableEnter(event)\"    onkeydown=\"return IncrmntConfrmCounter()\"  class=\"fg2_inp2 fg2_inp3 fg_chs1 in_flw\"/> ';

                    recRow += '<a href=\"javascript:;\"  onclick=\"OpenProduct(' + RowNum + ');\"  class=\"input-group-addon cur1 spn1_pro gren\" title=\"Add\"><i class="fa fa-plus-circle"></i></a> </div></td>';
                    recRow += '<td style=\"display:none\"><input id=\"txtproductId' + RowNum + '\"   name=\"txtproductId' + RowNum + '\"  type=\"text\"  class=\"form-control\" /> <input id=\"txtproductName' + RowNum + '\" value=\"' + PRODUCT_NAME + '\"   name=\"txtproductName' + RowNum + '\"  type=\"text\"  class=\"fg2_inp2 fg2_inp3 fg_chs1 in_flw\" /></td> ';

                    recRow += '<td><input  autocomplete=\'off\'  id=\"txtQntity' + RowNum + '\"   Value=\"' + QUANTITY + '\" maxlength=\"8\" onkeypress=\"return isNumberAmount(event,\'txtQntity' + RowNum + '\')\" onkeydown=\"return isNumberAmount(event,\'txtQntity' + RowNum + '\')\" onblur="return BlurValue(' + RowNum + ',\'txtQntity\')" type=\"text\"  class=\"form-control fg2_inp2 inp_mst tr_c\" /></td>';
                    recRow += '<td ><input  autocomplete=\'off\' id=\"txtRate' + RowNum + '\" onblur="return BlurValue(' + RowNum + ',\'txtRate\')" onkeypress=\"return isNumberAmount(event,\'txtRate' + RowNum + '\')\" onkeydown=\"return isNumberAmount(event,\'txtRate' + RowNum + '\')\"  tabindex=\"-1\" Value=\"' + RATE + '\" maxlength=\"10\"  type=\"text\"  class=\"form-control fg2_inp2 tr_r\" /></td>';

                    if (document.getElementById("<%=HiddenDiscountEnableSts.ClientID%>").value == "1") {
                        recRow += '<td>';
                        if (DISPER != null) {
                            recRow += '<div class="input-group ing1"><input  autocomplete=\'off\'  id=\"txtDisPercent' + RowNum + '\"   Value=\"' + DISPER + '\" maxlength=\"10\" onkeypress=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onkeydown=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onblur="return BlurValue(' + RowNum + ',\'txtDisPercent\')" type=\"text\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class=\"input-group-addon cur1 spn1_pro pur_pe\">%</span></div>';
                        }
                        else {
                            recRow += ' <div class="input-group ing1"><input  autocomplete=\'off\'  id=\"txtDisPercent' + RowNum + '\"  Value=\"0 \"  maxlength=\"10\" onkeypress=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onkeydown=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\"  onblur="return BlurValue(' + RowNum + ',\'txtDisPercent\')" type=\"text\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class=\"input-group-addon cur1 spn1_pro pur_pe\">%</span></div>';
                        }
                        if (DISAMT != null) {

                            recRow += ' <div class="input-group ing2"><input  autocomplete=\'off\'  id=\"txtDisAmt' + RowNum + '\"   Value=\"' + DISAMT + '\" maxlength=\"10\" onkeypress=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\" onkeydown=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\"  onblur="return BlurValue(' + RowNum + ',\'txtDisAmt\')" type=\"text\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span></div>';

                        }
                        else {
                            recRow += '<div class="input-group ing2"><input   autocomplete=\'off\' id=\"txtDisAmt' + RowNum + '\"  Value=\"0 \"   maxlength=\"10\" onkeypress=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\" onkeydown=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\"   onblur="return BlurValue(' + RowNum + ',\'txtDisAmt\')" type=\"text\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span></div>';
                        }
                        recRow += '</td>';
                    }
                    else {
                        recRow += '<td>';
                        if (DISPER != null) {
                            recRow += '<div class="input-group ing1"><input  autocomplete=\'off\'  disabled=\"disabled\" id=\"txtDisPercent' + RowNum + '\"  Value=\"' + DISPER + '\" maxlength=\"10\" onkeypress=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onkeydown=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onblur="return BlurValue(' + RowNum + ',\'txtDisPercent\')" type=\"text\"  class=\"form-control\" /><span class=\"input-group-addon cur1 spn1_pro pur_pe\">%</span>';
                        }
                        else {
                            recRow += '<div class="input-group ing1"><input  disabled=\"disabled\"  id=\"txtDisPercent' + RowNum + '\"   Value=\"0 \"  maxlength=\"10\" onkeypress=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onkeydown=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\"  onblur="return BlurValue(' + RowNum + ',\'txtDisPercent\')" type=\"text\"  class=\"form-control\" /><span class=\"input-group-addon cur1 spn1_pro pur_pe\">%</span>';
                        }
                        if (DISAMT != null) {
                            recRow += ' <div class="input-group ing2"><input  disabled=\"disabled\" id=\"txtDisAmt' + RowNum + '\"   Value=\"' + DISAMT + '\" maxlength=\"10\" onkeypress=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\" onkeydown=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\"  onblur="return BlurValue(' + RowNum + ',\'txtDisAmt\')" type=\"text\"  class=\"form-control\" /><span class="input-group-addon cur1 spn1_pro">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span>';

                        }
                        else {
                            recRow += ' <div class="input-group ing2"><input  disabled=\"disabled\" id=\"txtDisAmt' + RowNum + '\"   Value=\"0 \"   maxlength=\"10\" onkeypress=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\" onkeydown=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\"   onblur="return BlurValue(' + RowNum + ',\'txtDisAmt\')" type=\"text\"  class=\"form-control\" /><span class="input-group-addon cur1 spn1_pro">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span>';
                        }
                        recRow += '</td>';
                    }

                    if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                        recRow += '<td>';
                        if (TAXTEXT != null) {
                            recRow += '<input id=\"ddlTaxText' + RowNum + '\"  tabindex=\"-1\" title=\"' + TAXTEXT + '\" Value=\"' + TAXTEXT + '\" maxlength=\"10\" onkeypress=\"return isNumber(event)\" onblur="return BlurValue(' + RowNum + ',\'ddlTax\')" type=\"text\"  class=\"form-control fg2_inp2 tr_l inp_3_1\" />';
                        } else {
                            recRow += '<input id=\"ddlTaxText' + RowNum + '\"  tabindex=\"-1\"  maxlength=\"10\" onkeypress=\"return isNumber(event)\" onblur="return BlurValue(' + RowNum + ',\'ddlTax\')" type=\"text\"  class=\"form-control fg2_inp2 tr_l inp_3_1\" />  ';
                        }

                        recRow += '   <div class="input-group ing1 inp_3_2"><input id=\"TaxPer' + RowNum + '\" disabled=\"disabled\" tabindex=\"-1\" Value=\"' + TAXPERCENTAGE + '\" maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /> <span class="input-group-addon cur1 spn1_pro pur_pe">%</span></div>';
                        recRow += ' <div class="input-group ing2 inp_3_3"><input id=\"txtTaxAmt' + RowNum + '\"   disabled=\"disabled\" tabindex=\"-1\" Value=\"' + TAXAMT + '\" maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /> <span class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span></div>';
                        recRow += '</td>';
                    }

                    recRow += '<td ><input id=\"txtPrice' + RowNum + '\"  Value=\"' + PRICE + '\" tabindex=\"-1\" maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\"  class=\"form-control fg2_inp2 tr_r\" /></td>';
                    recRow += '<td  id= tdIndvlAddMoreRow' + RowNum + ' ><a href="javascript:;" id="\DivAddComment_' + RowNum + '\" onclick="OpenComment(' + RowNum + ');" class=\"btn act_btn bn9\" title=\"Add Remark\"><i class="fa fa-commenting"></i></a> ';
                    recRow += '<a  href="javascript:;" id=\"SpanAdd' + RowNum + '\"  onclick=\"return CheckaddMoreRows(' + RowNum + ');\"  class=\"btn act_btn bn2\" title=\"Add\"><i class="fa fa-plus-circle"></i> </a>';
                    recRow += '<a  href="javascript:;" id=\"SpanDel' + RowNum + '\"  onclick=\"return CheckDelEachRow(' + RowNum + ');\"   class=\"btn act_btn bn3\" title=\"Delete\"><i class="fa fa-trash"></i></a></div></td>';

                    recRow += '<td ><a href="javascript:;" id="\DivCostCentre_' + RowNum + '\" onclick="MyModalCostCenter(\'' + RowNum + '\',\'' + rowSubCatagory + '\',null);" title=\"Add Cost Centre\">  <i class=\"fa fa-filter ad_fa\"></i></a></td> ';
                    recRow += '<td style="display: none" id="tdEvt' + RowNum + '" style="display: none;">UPD</td>';
                    recRow += '<td style="display: none" id="tdDtlId' + RowNum + '" style="display: none;">' + PRODUCTROW + '</td>';
                    recRow += '<td style="display: none" ><input id=\"ddlTax' + RowNum + '\" Value=\"' + TAX + '\" style="display: none;" > </td> ';
                    recRow += '<td style="display: none" ><input id=\"ProductId' + RowNum + '\" value=\"' + PRODUCT_ID + '\" style="display: none;" > </td> ';
                    if (PURCHS_PRDUCT_REMARK != null)
                        recRow += '<td id="tdProductRemark' + RowNum + '" style="display: none;">' + PURCHS_PRDUCT_REMARK + '</td>';
                    else
                        recRow += '<td id="tdProductRemark' + RowNum + '" style="display: none;"></td>';

                    recRow += '<td  style="width:0%;display: none;"><input value=\"' + COSTCENTRE + '\" type="text" class="form-control" style="display:none;"  id="tdCostCenterDtls' + RowNum + '" name="tdCostCenterDtls' + RowNum + '" placeholder=""/></td>';
                    recRow += '<td  style="display: none;"><input id=\"remarktxt' + RowNum + '\" name=\"remarktxt' + RowNum + '\" value=' + PURCHS_PRDUCT_REMARK + ' style="display: none;" > </td> ';


                    recRow += '</tr>';
                    $noCon1("#ddlProduct_" + RowNum).attr("title", PRODUCT_NAME);
                }
                else {
                    var recRow = '<tr  id="rowId_' + RowNum + '">';
                    recRow += '<td   id="tdidGrpDtls' + RowNum + '" style="display: none" >' + RowNum + '</td>';
                    recRow += '<td >' + rowsl_no + '<input disabled  style="display: none" id=\"txtSlno' + RowNum + '\" Value=\"' + rowsl_no + '\" tabindex=\"-1\" maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\"  class=\"fg2_inp2 fg2_inp3 fg_chs1 in_flw\" /></td>';

                    recRow += '<td><div id=\"divProduct_' + RowNum + '\" class=\"input-group in_flw"\> <input id=\"ddlProduct_' + RowNum + '\" type=\"text\"  value=\"' + PRODUCT_NAME + '\" tabindex=\"7\" onkeydown=\"return isTag(event)\" onchange=\"FillddlTax(' + RowNum + ',' + null + ')\" onblur="return BlurValue(' + RowNum + ',\'ddlProduct_\')" onkeypress=\"return DisableEnter(event)\"    onkeydown=\"return IncrmntConfrmCounter()\"  class=\"fg2_inp2 fg2_inp3 fg_chs1 in_flw\"/> ';
                    recRow += '<a href=\"javascript:;\"  onclick=\"OpenProduct(' + RowNum + ');\"  class=\"input-group-addon cur1 spn1_pro gren\" title=\"Add\"><i class="fa fa-plus-circle"></i></a> </div></td>';

                    recRow += '<td style=\" display:none\"><input id=\"txtproductId' + RowNum + '\"   name=\"txtproductId' + RowNum + '\"  type=\"text\"  class=\"form-control\" /> <input id=\"txtproductName' + RowNum + '\" value=\"' + PRODUCT_NAME + '\"   name=\"txtproductName' + RowNum + '\"  type=\"text\"  class=\"form-control\" /></td> ';

                    recRow += '<td ><input  autocomplete=\'off\'  id=\"txtQntity' + RowNum + '\"  tabindex=\"7\" Value=\"' + QUANTITY + '\" maxlength=\"8\"  onkeypress=\"return isNumberAmount(event,\'txtQntity' + RowNum + '\')\" onkeydown=\"return isNumberAmount(event,\'txtQntity' + RowNum + '\')\" onblur="return BlurValue(' + RowNum + ',\'txtQntity\')" type=\"text\"  class=\"form-control fg2_inp2 inp_mst tr_c\" /></td>';
                    recRow += '<td ><input  autocomplete=\'off\'   id=\"txtRate' + RowNum + '\"  tabindex=\"-1\" Value=\"' + RATE + '\" maxlength=\"10\" onkeypress=\"return isNumberAmount(event,\'txtRate' + RowNum + '\')\" onkeydown=\"return isNumberAmount(event,\'txtRate' + RowNum + '\')\"  onblur="return BlurValue(' + RowNum + ',\'txtRate\')" type=\"text\"  class=\"form-control fg2_inp2 tr_r\" /></td>';
                    recRow += '<td >';
                    if (DISPER != null) {
                        recRow += '<div class="input-group ing1"><input   autocomplete=\'off\' id=\"txtDisPercent' + RowNum + '\"  Value=\"' + DISPER + '\" maxlength=\"10\" onkeypress=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onkeydown=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\"  onblur="return BlurValue(' + RowNum + ',\'txtDisPercent\')" type=\"text\"   class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class=\"input-group-addon cur1 spn1_pro pur_pe\">%</span></div>';
                    }
                    else {
                        recRow += '<div class="input-group ing1"><input  autocomplete=\'off\'  id=\"txtDisPercent' + RowNum + '\"  Value=\"0 \"  maxlength=\"10\" onkeypress=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\" onkeydown=\"return isDecimalNumberprcntg(event,\'txtDisPercent' + RowNum + '\')\"  onblur="return BlurValue(' + RowNum + ',\'txtDisPercent\')" type=\"text\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class=\"input-group-addon cur1 spn1_pro pur_pe\">%</span></div>';
                    }
                    if (DISAMT != null) {
                        recRow += '<div class="input-group ing2"><input  autocomplete=\'off\'  id=\"txtDisAmt' + RowNum + '\"  Value=\"' + DISAMT + '\" maxlength=\"10\" onkeypress=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\" onkeydown=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\"  onblur="return BlurValue(' + RowNum + ',\'txtDisAmt\')" type=\"text\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span></div>';
                    }
                    else {
                        recRow += '<div class="input-group ing2"><input  autocomplete=\'off\'  id=\"txtDisAmt' + RowNum + '\"   Value=\"0 \"   maxlength=\"10\" onkeypress=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\" onkeydown=\"return isDecimalNumber(event,\'txtDisAmt' + RowNum + '\')\"  onblur="return BlurValue(' + RowNum + ',\'txtDisAmt\')" type=\"text\"  class=\"form-control fg2_inp2 tr_r inp1_pro\" /><span class="input-group-addon cur1 spn1_pro pur_at">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span></div>';
                    }
                    recRow += '</td ></div>';
                    recRow += '<td ><input  id=\"txtPrice' + RowNum + '\"  Value=\"' + PRICE + '\" tabindex=\"-1\" maxlength=\"10\" onkeypress=\"return isNumber(event)\" type=\"text\"  class=\"form-control fg2_inp2 tr_r\" /></td>';
                    recRow += '<td id= tdIndvlAddMoreRow' + RowNum + ' ><a href="javascript:;" id="\DivAddComment_' + RowNum + '\" onclick="OpenComment(' + RowNum + ');" class=\"btn act_btn bn9\" title=\"Add Remark\"><i class="fa fa-commenting"></i></a> ';
                    recRow += '<a  href="javascript:;" id=\"SpanAdd' + RowNum + '\"  onclick=\"return CheckaddMoreRows(' + RowNum + ');\"  class=\"btn act_btn bn2\" title=\"Add\"><i class="fa fa-plus-circle"></i> </a>';
                    recRow += '<a  href="javascript:;" id=\"SpanDel' + RowNum + '\"  onclick=\"return CheckDelEachRow(' + RowNum + ');\"   class=\"btn act_btn bn3\" title=\"Delete\"><i class="fa fa-trash"></i></a></div></td>';
                    recRow += '<td ><a href="javascript:;" id="\DivCostCentre_' + RowNum + '\" onclick="MyModalCostCenter(\'' + RowNum + '\',\'' + rowSubCatagory + '\',null);" title=\"Add Cost Centre\">  <i class=\"fa fa-filter ad_fa\"></i></a></td> ';
                    recRow += '<td id="tdEvt' + RowNum + '" style="display: none;">UPD</td>';
                    recRow += '<td style="display: none;" id="tdDtlId' + RowNum + '" style="display: none;">' + PRODUCTROW + '</td>';
                    recRow += '<td style="display: none;"><input id=\"ddlTax' + RowNum + '\" Value=\"' + TAX + '\" style="display: none;" > </td> ';
                    recRow += '<td style="display: none;"><input id=\"TaxPer' + RowNum + '\" style="display: none;" value=\"' + TAXPERCENTAGE + '\"  > </td> ';
                    recRow += '<td style="display: none;"><input id=\"ProductId' + RowNum + '\" value=\"' + PRODUCT_ID + '\" style="display: none;" > </td> ';
                    if (PURCHS_PRDUCT_REMARK != null)
                        recRow += '<td id="tdProductRemark' + RowNum + '" style="display: none;">' + PURCHS_PRDUCT_REMARK + '</td>';
                    else
                        recRow += '<td id="tdProductRemark' + RowNum + '" style="display: none;"></td>';

                    recRow += '<td  style="width:0%;display: none;"><input value=\"' + COSTCENTRE + '\" type="text" class="form-control" style="display:none;"  id="tdCostCenterDtls' + RowNum + '" name="tdCostCenterDtls' + RowNum + '" placeholder=""/></td>';
                    recRow += '<td  style="display: none;"><input id=\"remarktxt' + RowNum + '\" name=\"remarktxt' + RowNum + '\" value=' + PURCHS_PRDUCT_REMARK + ' style="display: none;" > </td> ';

                    recRow += '</tr>';
                    $noCon1("#ddlProduct_" + RowNum).attr("title", PRODUCT_NAME);

                }
                jQuery('#TableaddedRows').append(recRow);
                ProductsLoad(RowNum);
                if (TAX != "") {
                    FillddlTax(RowNum, TAX, RATE);
                }
                // document.getElementById("txtRate" + RowNum).disabled = true;
                if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {

                    document.getElementById("ddlTaxText" + RowNum).disabled = true;
                    document.getElementById("txtTaxAmt" + RowNum).disabled = true;
                }
                document.getElementById("txtPrice" + RowNum).disabled = true;
                if (PRODUCT_ID != "") {
                    var FinalGrossTotal1 = 0;
                    var FinalTax1 = 0;
                    var NetTotal1 = 0;
                    var FinalDiscount1 = 0;
                    var Total_Exchange = 0;
                    FinalGrossTotal1 = document.getElementById("<%=HiddenGrossAmt.ClientID%>").value;
                    FinalTax1 = document.getElementById("<%=HiddenTax.ClientID%>").value;
                    NetTotal1 = document.getElementById("<%=HiddenNetAmt.ClientID%>").value;
                    FinalDiscount1 = document.getElementById("<%=Hiddendiscount.ClientID%>").value;
                    Total_Exchange = document.getElementById("<%=HiddenTotal_Exchng.ClientID%>").value;
                    addCommasSummry(FinalGrossTotal1);
                    addCommasSummry(FinalGrossTotal1);
                    document.getElementById("<%=txtGrossTotal.ClientID%>").innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value;;
                    addCommasSummry(NetTotal1);
                    document.getElementById("<%=txtNetTotal.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenDefaultCurrency.ClientID%>").value;;
                    addCommasSummry(FinalTax1);
                    document.getElementById("<%=txtTaxTotal.ClientID%>").innerHTML = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value;;
                    addCommasSummry(Total_Exchange);
                    document.getElementById("<%=txtTotalWithExchngRate.ClientID%>").value = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value + " " + document.getElementById("<%=HiddenExchngCurrency.ClientID%>").value;
                }
                
                document.getElementById('SpanAdd' + RowNum).disabled = true;
                document.getElementById('SpanAdd' + RowNum).style.pointerEvents = 'none';
                addCommas("txtRate" + RowNum);
                if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                    addCommas("txtTaxAmt" + RowNum);
                }
                addCommas("txtDisAmt" + RowNum);
                addCommas("txtPrice" + RowNum);

                if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {

                    $aa('#TableaddedRows').find(':input').prop("disabled", true);
                    document.getElementById('txtSlno' + RowNum).disabled = true;
                    document.getElementById('txtQntity' + RowNum).disabled = true;
                    document.getElementById('txtDisPercent' + RowNum).disabled = true;
                    document.getElementById('txtDisAmt' + RowNum).disabled = true;
                    if (document.getElementById("<%=HiddenTaxEnable.ClientID%>").value == "1") {
                        document.getElementById('ddlTaxText' + RowNum).disabled = true;
                    }
                    $('#SpanAdd' + RowNum).attr('disabled', true);
                    $('#SpanDel' + RowNum).attr('disabled', true);

                    //document.getElementById('SpanAdd' + RowNum).disabled = true;
                    //document.getElementById('SpanDel' + RowNum).disabled = true;
                    document.getElementById('SpanAdd' + RowNum).style.pointerEvents = 'none';
                    document.getElementById('SpanDel' + RowNum).style.pointerEvents = 'none';
                }
            }

        function MyModalCostCenter(x, y, CstCntr) {
            var SbCostCenter = '';
            SbCostCenter = '<div class=\"modal fade\" id=\"myModalCstCntr\" role=\"dialog\" data-backdrop=\"static\" data-keyboard=\"false\" >';
            SbCostCenter += '<div class=\"modal-dialog mod1\" role="document" >';
            SbCostCenter += '<div class=\"modal-content\">';
            SbCostCenter += '<div class=\"modal-header\">';
            SbCostCenter += '<button type=\"button\" class=\"close\" onclick=\"return CloseModal(\'' + x + '\')\">&times;</button>';
            SbCostCenter += "<h4 id=\"ModelHeading\" class=\"modal-title\"></h4>";
            SbCostCenter += "</div>";
            SbCostCenter += '<div class=\"alert alert-danger fade in\" id="divErrMsgCnclRsnCostCenter' + x + '" style=\"display: none; margin-top: 1%\">';
            SbCostCenter += '</div>';
            SbCostCenter += '<div class=\"al-box war\"  id="lblErrMsgCancelReasonCostCenter' + x + '"> Please fill this out</div>';
            SbCostCenter += '<div class=\"modal-body md_bd\">';
            SbCostCenter += '<div id=\"DivPopUpCostCenter\">';
            SbCostCenter += '<table class="table table-bordered"  id="TableAddQstnCostCenter' + x + '">';
            SbCostCenter += '<thead class="thead1">';
            SbCostCenter += ' <tr>';
            SbCostCenter += '<th class="col-md-2 tr_l">Cost Group1';
            SbCostCenter += ' </th>';
            SbCostCenter += '  <th class="col-md-2 tr_l">Cost Group2';
            SbCostCenter += '  </th>';
            SbCostCenter += '  <th class="col-md-2 tr_l">Cost Centre';
            SbCostCenter += ' </th>';
            SbCostCenter += '  <th class="col-md-3 tr_r">Amount';
            SbCostCenter += ' </th>';
            SbCostCenter += '  <th class="col-md-3">Actions';
            SbCostCenter += ' </th>';
            SbCostCenter += ' </tr>';
            SbCostCenter += '</thead>';
            SbCostCenter += '</table>';
            SbCostCenter += '</div></div>';
            SbCostCenter += '<div class=\"clearfix\"></div>';
            SbCostCenter += '<div class=\"modal-footer\">';
            SbCostCenter += '<div class="col-md-12 col_mar"><div class="box6 tr_r"><label id=\"Label1\" for=\"example-text-input\" class=\"fg2_la1 tt_am am1\" >Ledger Amount<span class="spn1"></span>:</label></div>';
            SbCostCenter += '<div class="box6 flt_r"><span id="LedgerAmtInModal' + x + '" class=\"tt_am am1 tt_al\" ></span></div></div>';
            SbCostCenter += '<label for="example-text-input" class=\"col-form-label\" id="lblCurrencyCC"></label>';
            SbCostCenter += '<button id="btnImportCostCenter' + x + '" type=\"button\" class=\"btn btn-success\"  onclick=\"ButtnFillClickCostCenter(\'' + x + '\');\" >Submit</button>';
            SbCostCenter += '<button id="BttnCost' + x + '" type=\"button\" style=\"display:none\" class=\"btn btn-primary\" data-dismiss=\"modal\"></button>';
            SbCostCenter += '</div></div> </div></div>';
            document.getElementById("CostCenterModal").innerHTML = SbCostCenter;
            CostCentr(x, y, CstCntr);

            if (document.getElementById("ddlProduct_" + x).value != "") {
                buttnVisibile(x, "0");
                if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                    document.getElementById("btnImportCostCenter" + x).disabled = true;
                }
                var idlast = "";
                var row = $noCon('#TableAddQstnCostCenter' + x).find(' tbody tr:first').attr('id');
                idlast = row.split('_');
                setTimeout(function () { focusCostCentre(idlast[1]); }, 350);

                if (document.getElementById("<%=HiddenView.ClientID%>").value == "0") {
                        var idlast1 = $noCon('#TableAddQstnCostCenter' + x + ' tr:last').attr('id');
                        if (idlast1 != "") {
                            var res1 = idlast1.split("_");
                            document.getElementById("tdInxQstn" + res1[1]).value = "";
                            document.getElementById("btnCostCenter_" + res1[1]).style.opacity = "1";
                        }
                    }
                }
        }

        var currntx = "";
        var currnty = "";
        function FunctionQustn(x, y, CostCenterId, CostGrp1Id, CostGroup2Id) {
          
            y++;
            submit++;
            var FrecRowQst = '';
            FrecRowQst += '<tr id="SubQstnRowId_' + x + '' + y + '" ><td   id="tdidQstnDtls' + x + '' + y + '" style="display: none" >' + x + '' + y + '</td>';
            FrecRowQst += '<td   id="tdvalidate' + x + '' + y + '" style="display: none" >' + x + '</td>';
            FrecRowQst += '<td   id="tdvalidatey' + x + '' + y + '" style="display: none" >' + y + '</td>';
            FrecRowQst += '<td >';

            FrecRowQst += '<input name="TxtRecptCosGrp1_' + x + '' + y + '"  style="display: none;" class="fg2_inp2 fg2_inp3 fg_chs1" id="TxtRecptCosGrp1_' + x + '' + y + '" ><div id="divCostGrp1' + x + '' + y + '"><select id="ddlRecptCosGrp1_' + x + '' + y + '" name="ddlRecptCosGrp1_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1 ddl" onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  ></select></div><input name="ddlCostGrp1Id_' + x + '' + y + '" style="display:none"  class="fg2_inp2 fg2_inp3 fg_chs1" id="ddlCostGrp1Id_' + x + '' + y + '" ></td>';
            FrecRowQst += '<td  ">';
            FrecRowQst += '<input name="TxtRecptCosGrp2_' + x + '' + y + '"  style="display: none;" class="fg2_inp2 fg2_inp3 fg_chs1" id="TxtRecptCosGrp2_' + x + '' + y + '" ><div id="divCostGrp2' + x + '' + y + '"><select id="ddlRecptCosGrp2_' + x + '' + y + '" name="ddlRecptCosGrp2_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1 ddl"  onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  ></select></div><input name="ddlCostGrp2Id_' + x + '' + y + '" style="display:none"  class="fg2_inp2 fg2_inp3 fg_chs1" id="ddlCostGrp2Id_' + x + '' + y + '" ></td>';
            FrecRowQst += '<td  ><input style="display:none" value="-1" name="TxtIdSales_' + x + '' + y + '" class="form-control" id="TxtIdSales_' + x + '' + y + '" ><input name="TxtRecptCosCtr_' + x + '' + y + '"  style="display: none;" class="fg2_inp2 fg2_inp3 fg_chs1" id="TxtRecptCosCtr_' + x + '' + y + '" ><div id="divCostCenter' + x + '' + y + '"><select id="ddlRecptCosCtr_' + x + '' + y + '" name="ddlRecptCosCtr_' + x + '' + y + '" class="fg2_inp2 fg2_inp3 fg_chs1" onchange="return ddlCostCenterOnchange(\'' + x + '\',\'' + y + '\');" onkeypress="return DisableEnter(event)"  >';
            FrecRowQst += '</select></div><input name="ddlCostCtrId_' + x + '' + y + '" style="display:none"  class="fg2_inp2 fg2_inp3 fg_chs1 ddl" id="ddlCostCtrId_' + x + '' + y + '" ></td>';
            FrecRowQst += '<td  class=" tr_r" > <div class="input-group">  <span class="input-group-addon cur1">' + document.getElementById("<%=HiddenDefultCrncAbrvtn.ClientID%>").value + '</span><input class="form-control fg2_inp2 tr_r" autocomplete="\off"\  maxlength="10"  id="TxtCstctrAmount_' + x + '' + y + '" name="TxtCstctrAmount_' + x + '' + y + '" value="" onblur="return CheckSumOfCstCntr(\'TxtCstctrAmount_' + x + '' + y + '\',' + x + ',' + y + ');"  onkeydown="return isDecimalNumber(event,\'TxtCstctrAmount_' + x + '' + y + '\');" onkeypress="return isDecimalNumber(event,\'TxtCstctrAmount_' + x + '' + y + '\');" id="TxtCstctrAmount_' + x + '' + y + '" type="text" ><input class="form-control fg2_inp2 tr_r"   id="TxtActCstctrAmount_' + x + '' + y + '" value="" onblur="return CheckSumOfLedger(\'TxtActCstctrAmount_' + x + '' + y + ',' + x + ',' + y + '\');" onkeyup="addCommas("TxtActCstctrAmount_' + x + '' + y + ')" style="display:none" onkeydown="return isNumber(event,TxtActCstctrAmount_' + x + '' + y + ');" name="TxtActCstctrAmount_' + x + '' + y + '" type="text"></td>';
          
            FrecRowQst += '<td class="td1"><div class="btn_stl1">';
                FrecRowQst += '<button title="ADD" id="btnCostCenter_' + x + '' + y + '" onclick="return CheckaddMoreRowsQstn(\'' + x + '\',\'' + y + '\',\'' + x + '' + y + '\');" class="btn act_btn bn2"><i class="fa fa-plus-circle"></i></button>';
                FrecRowQst += '<button class="btn act_btn bn3" id="btnCostCenterDel_' + x + '' + y + '" onclick="return removeRowQstn(' + x + ',' + y + ',' + x + '' + y + ',\'Are you sure you want to delete this cost centre?\')" style="">';
                FrecRowQst += '<span title="DELETE"   class="fa fa-trash" id="Span4" style="display: block;">&nbsp;</span></button></div></td>';

                FrecRowQst += '<td   style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;" value="INS" id="tdEvtQstn' + x + '' + y + '" name="tdEvtQstn' + x + '' + y + '" placeholder=""/></td>';
                FrecRowQst += '<td style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdDtlIdQstn' + x + '' + y + '" name="tdDtlIdQstn' + x + '' + y + '" placeholder=""/></td>';
                FrecRowQst += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdInxQstn' + x + '' + y + '" name="tdInxQstn' + x + '' + y + '" placeholder=""/> </td></tr>';
                jQuery('#TableAddQstnCostCenter' + x).append(FrecRowQst);

                FillddlAcntGrp1(x, y, CostGrp1Id);


                $au("#ddlRecptCosGrp1_" + x + '' + y).selectToAutocomplete1Letter();

                FillddlAcntGrp2(x, y, CostGroup2Id);


                $au("#ddlRecptCosGrp2_" + x + '' + y).selectToAutocomplete1Letter();

                FillddlCostCenter(x, y, CostCenterId);
                $au("#ddlRecptCosCtr_" + x + '' + y).selectToAutocomplete1Letter();

                //  CheckSubmitZero();

                currntx = x;
                currnty = y;
                if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                    document.getElementById("btnCostCenter_" + x + y).disabled = "true";
                    document.getElementById("btnCostCenterDel_" + x + y).disabled = "true";
                    $("#TableAddQstnCostCenter" + x).find("input").attr("disabled", "disabled");
                }
                $("#divCostGrp1" + x + "" + y + " > input").focus();
                $("#divCostGrp1" + x + "" + y + " > input").select();
                return false;
        }

        function RemarkShow(RowId) {

            var recRow = "";
            if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                  if (document.getElementById("tdProductRemark" + RowId).innerHTML != "") {
                      recRow += '<textarea name="txtProductRemark' + RowId + '" rows="2" disabled cols="20" id="txtProductRemark' + RowId + '" class="form-control" onblur="RemoveTag(\'txtProductRemark' + RowId + '\')" onkeypress="return isTag(event)" onkeydown="textCounter(txtProductRemark' + RowId + ',450)" onkeyup="textCounter(txtProductRemark' + RowId + ',450)" >' + document.getElementById("tdProductRemark" + RowId).innerHTML + '</textarea>';
                  }
                  else
                      recRow += '<textarea name="txtProductRemark' + RowId + '" rows="2" cols="20" disabled id="txtProductRemark' + RowId + '"  class="form-control" onblur="RemoveTag(\'txtProductRemark' + RowId + '\')" onkeypress="return isTag(event)" onkeydown="textCounter(txtProductRemark' + RowId + ',450)" onkeyup="textCounter(txtProductRemark' + RowId + ',450)"></textarea>';
                  recRow += '<div class="modal-footer">';
                  //recRow += '<div class="ui-dialog-buttonset">';
                  recRow += '<button type="button" id="btnCancelRsnSave" disabled onclick="return AddRemarks(' + RowId + ');" class="btn btn-success">Add</button>';
                  recRow += '<button type="button" disabled id="btnCnclRsn" onclick="return CloseCancelView(' + RowId + ');"class="btn btn-danger"  data-dismiss="modal" >Cancel</button></div>';
              }
              else {
                  if (document.getElementById("tdProductRemark" + RowId).innerHTML != "") {
                      recRow += '<textarea name="txtProductRemark' + RowId + '" rows="2" cols="20" id="txtProductRemark' + RowId + '" class="form-control" onblur="RemoveTag(\'txtProductRemark' + RowId + '\')" onkeypress="return isTag(event)" onkeydown="textCounter(txtProductRemark' + RowId + ',450)" onkeyup="textCounter(txtProductRemark' + RowId + ',450)" >' + document.getElementById("tdProductRemark" + RowId).innerHTML + '</textarea>';
                  }
                  else
                      recRow += '<textarea name="txtProductRemark' + RowId + '" rows="2" cols="20" id="txtProductRemark' + RowId + '"  class="form-control" onblur="RemoveTag(\'txtProductRemark' + RowId + '\')" onkeypress="return isTag(event)" onkeydown="textCounter(txtProductRemark' + RowId + ',450)" onkeyup="textCounter(txtProductRemark' + RowId + ',450)" ></textarea>';
                  //recRow += '</div>';
                  recRow += '<div class="modal-footer">';
                  recRow += '<button type="button" id="btnCancelRsnSave" onclick="return AddRemarks(' + RowId + ');" class="btn btn-success">Add</button>';
                  recRow += '<button type="button" id="btnCnclRsn" onclick="return CloseCancelView(' + RowId + ');"class="btn btn-danger" data-dismiss="modal"> Cancel</button></div>';
              }

                      //recRow += '</tr>';
                      //jQuery('#TableaddedRows').append(recRow);
            $("#divCancelPopUp").html(recRow);
        
          }

    </script>
   <%-- File Upload--%>
    <script>
        var FileCounterVhcl = 0;
        var currntx = 0;

        function AddFileUploadVhcl() {

            var FrecRow = '<tr id="FilerowId_' + FileCounterVhcl + '" >';
            FrecRow += '<td   id="tdFileId' + FileCounterVhcl + '" style="display: none" >' + FileCounterVhcl + '</td>';
            var labelForStyle = '<label for="file' + FileCounterVhcl + '" class="la_up"> <i class="fa fa-upload" aria-hidden="true"></i>Upload File</label>';
            var tdInner = labelForStyle + ' <div id="file-upload-filename" class="file_n"><input   id="file' + FileCounterVhcl + '" name = "file' + FileCounterVhcl +
            '" type="file" onchange="ChangeFileVhcl(' + FileCounterVhcl + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/></div>';
            FrecRow += '<td id="tdTdInner' + FileCounterVhcl + '" >' + tdInner + '</td>';



            FrecRow += '<td style="word-break: break-all;" id="filePath' + FileCounterVhcl + '"  ></td  >';
            FrecRow += '<td width=2% id="FileIndvlAddMoreRow' + FileCounterVhcl + '"  ><a  href="javascript:;" id=\"SpanAddUpload' + FileCounterVhcl + '\"  onclick="return CheckaddMoreRowsIndividualFilesVhcl(' + FileCounterVhcl + ');" class=\"btn act_btn bn2\" title=\"Add\"><i class="fa fa-plus-circle"></i></a> </td>';
            FrecRow += '<td   width=2% id="FileIndvlDelMoreRow' + FileCounterVhcl + '" ><a  href="javascript:;" id=\"SpanDelUpload' + FileCounterVhcl + '\"  onclick = "return RemoveFileUploadVhcl(' + FileCounterVhcl + ');"   class=\"btn act_btn bn3\" title=\"Delete\" ><i class="fa fa-trash"></i></a></td></div>';
            FrecRow += ' <td id="FileInx' + FileCounterVhcl + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + FileCounterVhcl + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + FileCounterVhcl + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId' + FileCounterVhcl + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName' + FileCounterVhcl + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableFileCCN').append(FrecRow);

            document.getElementById('filePath' + FileCounterVhcl).innerHTML = 'No File Uploaded';
            currntx = FileCounterVhcl;
            FileCounterVhcl++;
        }
        function EditFileUpload(PURCHSE_ID, ATTACH_ID, FIMENAME, ACT_FILENAME) {
            AddFileUploadVhcl();
            var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + FIMENAME + ' >' + ACT_FILENAME + '</a>';
            document.getElementById('filePath' + currntx).innerHTML = tdFileNameEdit;
            var filee = document.getElementById("<%=hiddenFilePath.ClientID%>").value + FIMENAME;
                document.getElementById("FileInx" + currntx).innerHTML = ATTACH_ID;
                document.getElementById("DbFileName" + currntx).innerHTML = ACT_FILENAME;
                document.getElementById("FileDtlId" + currntx).innerHTML = ATTACH_ID;
                document.getElementById("FileEvt" + currntx).innerHTML = "UPD";
                document.getElementById("tdTdInner" + currntx).style.display = "none";
                document.getElementById("filePath" + currntx).setAttribute("colspan", "2");
                document.getElementById("FileIndvlAddMoreRow" + currntx).style.opacity = "0.3";
                if (document.getElementById("<%=HiddenView.ClientID%>").value == "1") {
                document.getElementById('SpanAddUpload' + currntx).style.pointerEvents = "none";
                document.getElementById('SpanDelUpload' + currntx).style.pointerEvents = "none";
                document.getElementById("FileIndvlAddMoreRow" + currntx).style.opacity = "1";
            }
            //colspan = "2"
        }
        function CheckaddMoreRowsIndividualFilesVhcl(x) {
            var check = document.getElementById("FileInx" + x).innerHTML;
            if (check == " ") {
                var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                if (CheckFileUploaded(x) == true) {
                    document.getElementById("FileInx" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                    AddFileUploadVhcl();
                    return false;
                }
            }
            return false;
        }
        function RemoveFileUploadVhcl(removeNum) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to delete selected file?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var Filerow_index = jQuery('#FilerowId_' + removeNum).index();
                    AddDeletedAttachment(removeNum);
                    jQuery('#FilerowId_' + removeNum).remove();
                    var TableFileRowCount = document.getElementById("TableFileCCN").rows.length;
                    if (TableFileRowCount != 0) {
                        var idlast = $noCon1('#TableFileCCN tr:last').attr('id');
                        if (idlast != "") {
                            var res = idlast.split("_");
                            document.getElementById("FileInx" + res[1]).innerHTML = " ";
                            document.getElementById("FileIndvlAddMoreRow" + res[1]).style.opacity = "1";
                        }
                    }
                    else {
                        AddFileUploadVhcl();
                    }
                }
                else {
                    return false;
                }
            });

            return false;
        }
        function CheckFileUploaded(x) {
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            if (Fevt != 'UPD') {
                if (document.getElementById('file' + x).value != "") {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                var fileInx = "";
                if (document.getElementById("FileInx" + x).innerHTML != "")
                    fileInx = document.getElementById("FileInx" + x).innerHTML;
                if (fileInx != "") {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        function ChangeFileVhcl(x) {
            if (ClearDivDisplayImage1(x)) {
                IncrmntConfrmCounter();
                if (document.getElementById('file' + x).value != "") {
                    document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;
                }
                else {
                    document.getElementById('filePath' + x).innerHTML = 'No File Uploaded';
                }
                var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                if (SavedorNot == "saved") {
                    var row_index = jQuery('#FilerowId_' + x).index();
                }
                else {
                    //    FileLocalStorageAddVhcl(x);
                }
            }
        }
        function ClearDivDisplayImage1(x) {
            var fuData = document.getElementById('file' + x);
            var FileUploadPath = fuData.value;
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();
            if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                        || Extension == "jpeg" || Extension == "jpg" || Extension == "xlsx" || Extension == "xls" || Extension == "doc" ||
                Extension == "docx" || Extension == "csv" || Extension == "ppt" || Extension == "pptx"
               || Extension == "txt" || Extension == "pdf") {
                return true;
            }
            else {
                document.getElementById('file' + x).value = "";
                document.getElementById('filePath' + x).innerHTML = 'No File Selected';
                $noCon("#divWarning").html("The specified file type could not be uploaded.Only support image files and document files.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                return false;
            }
        }

        function buttnVisibileFileUpload() {
            var TableRowCount = document.getElementById("TableFileCCN").rows.length;
            addRowtable = document.getElementById("TableFileCCN");
            //    var TableRowCount1 = document.getElementById("TableAddQstnCostCenter" + x).rows.length;
            if (TableRowCount != 0) {
                var idlast = $noCon1('#TableFileCCN tr:last').attr('id');
                if (idlast != "") {
                    var res = idlast.split("_");
                    document.getElementById("FileInx" + res[1]).innerHTML = " ";
                    document.getElementById("FileIndvlAddMoreRow" + res[1]).style.opacity = "1";
                }
            }
        }
        function AddDeletedAttachment(Delrowcount) {
            if (document.getElementById("FileEvt" + Delrowcount).innerHTML == "UPD") {
                var detailId = document.getElementById("<%=hiddenFileCanclDtlId.ClientID%>").value;
                detailId = detailId + "," + document.getElementById("FileDtlId" + Delrowcount).innerHTML;
                document.getElementById("<%=hiddenFileCanclDtlId.ClientID%>").value = detailId;
            }

        }
        function CheckAdAttachment() {
            if (document.getElementById("<%=cbxAttachment.ClientID%>").checked == true)
                document.getElementById("<%=divAtchCCN.ClientID%>").style.display = "block";
            else
                document.getElementById("<%=divAtchCCN.ClientID%>").style.display = "none";
        }

    </script>
   <%-- Common Functions--%>

    <script>
  
     

        // for not allowing <> tags
        function isTagDes(evt) {

            if (DisableEnter(evt) == false) {

                return false;
            }

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return true;
            }
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }
        // for not allowing enter
        function DisableEnter(evt) {
            //  var b = new Date(); alert(b);
            IncrmntConfrmCounter();
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }

        }
        function textCounter1(field, maxlimit, evt) {
            if (DisableEnter(evt) == false) {

                return false;
            }
            if (field.value.length > maxlimit) {

                field.value = field.value.substring(0, maxlimit);
            }

            else {

            }
            var txt = field.value;
            var replaceText1 = txt.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            field.value = replaceText2;




        }
        function controlTab(obj, event) {
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 9) {
                document.getElementById(obj).focus();
                return false;
            }

            else {
                return true;
            }
        }


        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            //var txtPerVal = document.getElementById(textboxid).value;
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
            else if (keyCodes == 34 || keyCodes == 33 || keyCodes == 36 || keyCodes == 35 || keyCodes == 41) {

                return true;
            }
            else if ((keyCodes == 65 || keyCodes == 86 || keyCodes == 67) && (evt.ctrlKey === true || evt.metaKey === true)) {
                return true;
            }
            else if (keyCodes == 46) {
                return true;
            }

                // . period and numpad . period
            else if (keyCodes == 190 || keyCodes == 110) {
                //var ret = false;
                return false;

            }

            else {

                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                }

            }
            return ret;
        }
        function isNumberAmount(evt, textboxid) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            var txtPerVal = document.getElementById(textboxid).value;

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
            else if (keyCodes == 34 || keyCodes == 33 || keyCodes == 36 || keyCodes == 35 || keyCodes == 41) {

                return true;
            }
            else if ((keyCodes == 65 || keyCodes == 86 || keyCodes == 67) && (evt.ctrlKey === true || evt.metaKey === true)) {
                return true;
            }
            else if (keyCodes == 46) {
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
        function isDecimalNumberprcntg(evt, textboxid) {
            // alert(textboxid);
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            var txtPerVal = document.getElementById(textboxid).value;

            if (txtPerVal > 100) {
                return false;
            }

            var ret = true;

            if (keyCodes == 13) {
                ret = false;
            }
                //0-9
            else if (keyCodes >= 48 && keyCodes <= 57) {
                ret = true;
            }
                //numpad 0-9
            else if (keyCodes >= 96 && keyCodes <= 105) {
                ret = true;
            }
                //    //left arrow key,right arrow key,home,end ,delete
                //else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 38 || keyCodes == 40) {
                //    ret = false;

                //}
            else if (keyCodes == 34 || keyCodes == 33 || keyCodes == 36 || keyCodes == 35 || keyCodes == 41 || keyCodes == 37 || keyCodes == 39) {
          

                return true;
            }
            else if ((keyCodes == 65 || keyCodes == 86 || keyCodes == 67) && (evt.ctrlKey === true || evt.metaKey === true)) {
                return true;
            }
            else if (keyCodes == 46) {
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
                //return ret;

            }
            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                }
                //return ret;
            }
            if (ret == true) {


                if (txtPerVal.length == 0 || txtPerVal.length == 1) {

                    if ((charCode >= 48 && charCode <= 57) || (charCode >= 96 && charCode <= 105) || charCode == 190 || charCode == 8 || charCode == 9 || charCode == 46 || charCode == 13 || charCode == 9 || charCode == 110) {

                        return true;
                    }
                }
                else if (txtPerVal.length == 2) {
                    if ((txtPerVal > 10) && (charCode == 110 || charCode == 190 || charCode == 46 || charCode == 8 || charCode == 9)) {

                        return true;
                    }

                    else if ((txtPerVal == 10) && (charCode == 48 || charCode == 96 || charCode == 110 || charCode == 190 || charCode == 46 || charCode == 8 || charCode == 9)) {

                        return true;
                    }
                    else if ((txtPerVal < 10) && ((charCode >= 48 && charCode <= 57) || (charCode >= 96 && charCode <= 105) || charCode == 190 || charCode == 8 || charCode == 9 || charCode == 46 || charCode == 13 || charCode == 9 || charCode == 110)) {

                        return true;
                    }
                    else {

                        return false;
                    }
                }

                else if (txtPerVal.length == 3) {
                    if ((txtPerVal == 100) && (charCode == 110 || charCode == 190 || charCode == 46 || charCode == 8 || charCode == 9)) {

                        return true;
                    }
                    else if ((txtPerVal.indexOf(".") != -1) && ((charCode >= 48 && charCode <= 57) || (charCode >= 96 && charCode <= 105) || charCode == 190 || charCode == 8 || charCode == 9 || charCode == 46 || charCode == 13 || charCode == 9 || charCode == 35 || charCode == 36 || charCode == 37 || charCode == 39 || charCode == 110)) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else if (txtPerVal.length == 4) {
                    if ((txtPerVal.indexOf(".") != -1) && ((charCode >= 48 && charCode <= 57) || (charCode >= 96 && charCode <= 105) || charCode == 190 || charCode == 8 || charCode == 9 || charCode == 46 || charCode == 13 || charCode == 9 || charCode == 35 || charCode == 36 || charCode == 37 || charCode == 39 || charCode == 110)) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else if ((charCode == 46 || charCode == 8 || charCode == 9 || charCode == 37 || charCode == 39 || charCode == 35 || charCode == 36)) {
                    return true;
                }
            }

            return ret;


        }

        function isDecimalNumber(evt, textboxid) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var txtPerVal = document.getElementById(textboxid).value;
            if (keyCodes == 13) {
                return false;
            }
            else if (keyCodes >= 48 && keyCodes <= 57) {
                return true;
            }
            else if (keyCodes >= 96 && keyCodes <= 105) {
                return true;
            }
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 38 || keyCodes == 40) {
                return true;
            }
            else if (keyCodes == 46) {
                return true;
            }
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

        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }
       
        function ConfirmMessage() {
            //alert(confirmbox+"cnfrm");
            if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                if (confirmbox > 0) {
                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure you want to leave this page?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            window.location.href = "Purchase_Master_List.aspx";
                        }
                        else {
                            return false;
                            //window.location.href = "Purchase_master.aspx";
                        }
                    });
                    return false;
                }
                else {
                    window.location.href = "Purchase_Master_List.aspx";
                    return false;
                }
            }
            else {
                window.location.href = "Purchase_Master_List.aspx";
                return false;
            }

        }
        function AlertClearAll() {
            document.getElementById("<%=hiddenCostCenterddl.ClientID%>").value = "";
            document.getElementById("<%=HiddenCostGroup2ddl.ClientID%>").value = "";
            document.getElementById("<%=HiddenCostGroup1ddl.ClientID%>").value = "";
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want clear all data in this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "Purchase_Master.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                return true;
            }
        }

        function check() {
            $noCon("div#divddlCustomerLdgr input.ui-autocomplete-input").focus();
        }

            function BlurNotNumber(obj) {
                var txt = document.getElementById(obj).value;

                if (txt != "") {

                    if (isNaN(txt)) {
                        document.getElementById(obj).value = "";
                        document.getElementById(obj).focus();
                        return false;

                    }
                    if (txt < 0) {
                        document.getElementById(obj).value = "";
                        document.getElementById(obj).focus();
                        return false;

                    }

                    RemoveTag(obj);
                }
            }
            function opensave() {
                document.getElementById("cphMain_mySave").style.width = "140px";
            }

            function closesave() {
                document.getElementById("cphMain_mySave").style.width = "0px";
            }

            function mysave() {
                var x = document.getElementById("mysav");
                if (x.style.display === "block") {
                    x.style.display = "none";
                } else {
                    x.style.display = "block";
                }
            }
    </script>
    <%-- Alert message section--%>
    <script>
        function SuccessReopMsg() {
            $noCon("#success-alert").html("Purchase details reopened successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessConfirmation() {
            $noCon("#success-alert").html("Purchase details inserted successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });

            return false;
        }
        function SuccessCancel() {
            $noCon("#divWarning").html("Purchase details already cancelled.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

            return false;
        }
        function CreditLimtAlert() {
            $noCon("#divWarning").html("Purchase amount greater than credit amount.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

            return false;
        }
        function CreditPeriodAlert() {
            $noCon("#divWarning").html("Credit period exceeded.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

            return false;
        }
        function SuccessNotConfirmation() {
            $noCon("#divWarning").html("Purchase details already confirmed.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

            return false;
        }
        function SuccessUpdation() {
            $noCon("#success-alert").html("Purchase details updated successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });

            return false;
        }

        function AlreadyCancelMsg() {
            $noCon("#divWarning").html("Purchase details is already cancelled");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

        }
        function AlreadyReopened() {
            $noCon("#divWarning").html("Purchase information already reopened.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

            return false;
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:HiddenField ID="hiddenCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenGrossAmt" runat="server" />
    <asp:HiddenField ID="Hiddendiscount" runat="server" />
    <asp:HiddenField ID="HiddenTotal_Exchng" runat="server" />
    <asp:HiddenField ID="HiddenTax" runat="server" />
    <asp:HiddenField ID="HiddenNetAmt" runat="server" />
    <asp:HiddenField ID="HiddenPurchaseId1" runat="server" />
    <asp:HiddenField ID="HiddenCurrncyId" runat="server" />
    <asp:HiddenField ID="HiddenExchngCurrency" runat="server" />
    <asp:HiddenField ID="HiddenUploadInfo" runat="server" />
    <asp:HiddenField ID="hiddenRefSequence" runat="server" />
    <asp:HiddenField ID="HiddenAdd" runat="server" />
    <asp:HiddenField ID="HiddenRowNo" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="Hiddenreturnfun" runat="server" />
    <asp:HiddenField ID="HiddenDiscountEnableSts" runat="server" />
    <asp:HiddenField ID="HiddenDfltLdgr" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenDefultCrncAbrvtn" runat="server" />
    <asp:HiddenField ID="HiddenAccountSpecificStatus" runat="server" />
    <asp:HiddenField ID="HiddenFieldAuditCloseReopenSts" runat="server" />
    <asp:HiddenField ID="HiddenTaxPercentage" runat="server" />
    <asp:HiddenField ID="HiddenUnit" runat="server" />
    <asp:HiddenField ID="HiddenRownum" runat="server" />
    <asp:HiddenField ID="HiddenRet" runat="server" />
    <asp:HiddenField ID="HiddenDefaultCurrency" runat="server" />
    <asp:HiddenField ID="HiddenInventoryForex" runat="server" />
    <asp:HiddenField ID="HiddenTaxEnable" runat="server" />
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="HiddenEditAttachment" runat="server" />
    <asp:HiddenField ID="HiddenEdit" runat="server" />
    <asp:HiddenField ID="HiddenDfltProductLdgr" runat="server" />
    <asp:HiddenField ID="HiddenDfltProductLdgrSts" runat="server" />
    <asp:HiddenField ID="HiddenDefaultLdgrSts" runat="server" />
    <asp:HiddenField ID="HiddenView" runat="server" />
    <asp:HiddenField ID="HiddenCurrcyFxAbbrvn" runat="server" />
    <asp:HiddenField ID="HiddenProductId" runat="server" />
    <asp:HiddenField ID="HiddenSupplierId" runat="server" />
    <asp:HiddenField ID="hiddenFilePath" runat="server" />
    <asp:HiddenField ID="HiddenRestritionStatus" runat="server" />
    <asp:HiddenField ID="HiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="hiddenFileCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenFieldAcntCloseReopenSts" runat="server" />
    <asp:HiddenField ID="HiddenAcntClsDate" runat="server" />
    <asp:HiddenField ID="HiddenRefAccountCls" runat="server" />
    <asp:HiddenField ID="HiddenStartDate" runat="server" />
    <asp:HiddenField ID="HiddenAcntClsSts" runat="server" />
    <asp:HiddenField ID="HiddenPurchaseid" runat="server" />
    <asp:HiddenField ID="HiddenFincancialStartDate" runat="server" />
    <asp:HiddenField ID="HiddenFincancialEndDate" runat="server" />
    <asp:HiddenField ID="HiddenUpdatedDate" runat="server" />
    <asp:HiddenField ID="HiddenUpdRefNum" runat="server" />
    <asp:HiddenField ID="HiddenReopenStatus" runat="server" />
    <asp:HiddenField ID="HiddenRefNum" runat="server" />
    <asp:HiddenField ID="HiddenProductDupSts" runat="server" />
    <asp:HiddenField ID="HiddenFocusId" runat="server" />
    <asp:HiddenField ID="HiddenFocusName" runat="server" />
    <asp:HiddenField ID="hiddenCostCenterddl" runat="server" />
    <asp:HiddenField ID="HiddenCostGroup1ddl" runat="server" />
    <asp:HiddenField ID="HiddenCostGroup2ddl" runat="server" />


    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li><a href="Purchase_Master_List.aspx">Purchase</a></li>
        <li class="active">Add Purchase</li>
    </ol>
    <div class="myAlert-bottom alert alert-danger" id="divWarning" style="display: none">
        <button type="button" class="close" data-dismiss="alert">x</button>
    </div>
    <div class="myAlert-top alert alert-success" id="success-alert" style="display: none">
        <button type="button" class="close" data-dismiss="alert">x</button>
    </div>
     <%--   <div class="wrapper wr2">--%>
    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">
            <div class="content_box1 cont_contr">
 <div class="" onmouseover="closesave()">
                <h2>
                    <asp:Label ID="lblEntry" runat="server"></asp:Label>
                </h2>

                <div class="form-group fg5 fg2_mr">
                    <label for="email" class="fg2_la1">Purchase REF #:<span class="spn1">*</span></label>
                    <div id="divtxtRef" runat="server">
                        <asp:TextBox ID="txtRef" class="form-control fg2_inp1 inp_mst" ReadOnly="true"  runat="server" MaxLength="100" onchange="IncrmntConfrmCounter();" onkeypress="return isTag(event);" onblur="return textCounter(cphMain_txtRef,100)" onkeydown=" return textCounter(cphMain_txtRef,100)" TabIndex="-1"></asp:TextBox>
                    </div>
                </div>

    <asp:UpdatePanel ID="UpdatePanel1" EnableViewState="true" UpdateMode="Conditional" runat="server">
        <ContentTemplate>

                <div class="form-group fg5 fg2_mr">
                    <div class="tdte">
                        <label for="pwd" class="fg2_la1">Date:<span class="spn1">*</span> </label>
                        <div id="datepicker2" class="input-group date" data-date-format="mm-dd-yyyy">
                            <input id="txtdate" readonly="readonly" runat="server" type="text" onkeypress="return DisableEnter(event);" onkeydown="return  DisableEnter(event);" onchange="showFromDate()" class="form-control inp_bdr" placeholder="dd-mm-yyyy" maxlength="50" />
                            <span id="spandate" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                        </div>

                    </div>      
                    <script>
                        var $noCon4 = jQuery.noConflict();
                        // var dateToday = new Date();
                        var StartDate = document.getElementById("<%=HiddenStartDate.ClientID%>").value;
                        var curentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value
                        $noCon('#datepicker2').datepicker({
                            autoclose: true,
                            format: 'dd-mm-yyyy',
                            startDate: StartDate,
                            endDate: curentDate,
                        });
                    </script>
                  
                </div>

                <div class="form-group fg5 fg2_mr">
                    <label for="email" class="fg2_la1">Order#:<span class="spn1"></span></label>
                    <div id="div2" runat="server">
                        <asp:TextBox ID="txtOrder" AutoCompleteType="Disabled" class="form-control fg2_inp1" runat="server" MaxLength="100" onchange="IncrmntConfrmCounter();" onkeypress="return isTagDes(event);" onblur="return textCounter(cphMain_txtOrder,100)" onkeydown=" return textCounter1(cphMain_txtOrder,100,event)"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group fg5 fg2_mr">
                    <label for="email" class="fg2_la1">Quotation#:<span class="spn1"></span></label>
                    <asp:TextBox ID="txtReceipt" AutoCompleteType="Disabled" class="form-control fg2_inp1" runat="server" MaxLength="20" onchange="IncrmntConfrmCounter();" onkeypress="return isTagDes(event);" onblur="return textCounter(cphMain_txtReceipt,20)" onkeydown=" return textCounter1(cphMain_txtReceipt,20,event)"></asp:TextBox>
                </div>

            <div class="form-group fg5 fg2_mr">

                <label class="form1 mar_bo">
                  <p class="pz_s"> Existing Supplier:</p><span class="spn1 flt_l">*</span>
                  <span class=" mar_rgt1 flt_l">
                    <label class="switch">
                      <input type="checkbox" runat="server" checked="checked" onclick="CheckSupplierType();" onkeydown="return  IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" id="cbxExtngSplr" />
                     <span class="slider_tog round"></span>
                    </label>
                  </span>
                </label>
                <div id="SupllierAdd">
                    <div id="divddlCustomerLdgr">
                        <asp:DropDownList ID="ddlCustomerLdgr" class="form-control fg2_inp1 inp_mst custom-select grp" runat="server" onkeypress="return DisableEnter(event);" onkeydown="return  DisableEnter(event);" AutoPostBack="true" OnSelectedIndexChanged="ddlCustomerLdgr_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <a href="javascript:;" onclick="OpenSupplier();" title="Add new Supplier"><span class="input-group-addon cur6"><i class="fa fa-plus"></i></span></a>
            </div>

                <div class="form-group fg5 fg2_mr">
                    <label for="email" class="fg2_la1">Supplier:<span class="spn1">*</span></label>
                    <asp:TextBox ID="txtsplrName" AutoCompleteType="Disabled" MaxLength="20" class="form-control fg2_inp1 inp_mst" runat="server" onchange="IncrmntConfrmCounter();" onkeypress="return isTagDes(event);" onblur=" return textCounter1(cphMain_txtsplrName,20,event)"></asp:TextBox>
                </div>

                <div class="form-group fg5 fg2_mr">
                    <label for="email" class="fg2_la1">Address 1:<span class="spn1">*</span></label>
                    <asp:TextBox ID="txtAddress1" AutoCompleteType="Disabled" class="form-control fg2_inp1  inp_mst" runat="server" T MaxLength="499" onchange="IncrmntConfrmCounter();" onkeypress="return isTagDes(event);" onblur="return textCounter(cphMain_txtAddress1,499)" onkeydown=" return textCounter1(cphMain_txtAddress1,499,event)"></asp:TextBox>



                </div>
                <div class="form-group fg5 fg2_mr">
                    <label for="email" class="fg2_la1">Address 2:<span class="spn1">&nbsp;</span></label>
                    <asp:TextBox ID="txtAddress2" AutoCompleteType="Disabled" class="form-control fg2_inp1 " runat="server" MaxLength="499" onchange="IncrmntConfrmCounter();" onkeypress="return isTagDes(event);" onblur="return textCounter(cphMain_txtAddress2,499)" onkeydown=" return textCounter1(cphMain_txtAddress2,499,event)"></asp:TextBox>

                </div>

                <div class="form-group fg5 fg2_mr">
                    <label for="email" class="fg2_la1">Address 3:<span class="spn1">&nbsp;</span></label>
                    <asp:TextBox ID="txtAddress3" AutoCompleteType="Disabled" class="form-control fg2_inp1 " runat="server" MaxLength="499" onchange="IncrmntConfrmCounter();" onkeypress="return isTagDes(event);" onblur="return textCounter(cphMain_txtAddress3,499)" onkeydown=" return textCounter1(cphMain_txtAddress3,499,event)"></asp:TextBox>

                </div>
                <div class="form-group fg5 fg2_mr">
                    <label for="email" class="fg2_la1">Contact#:<span class="spn1">&nbsp;</span></label>
                    <asp:TextBox ID="txtContactNumber" onkeypress="return isNumber(event);" onblur="return BlurNotNumber('cphMain_txtContactNumber')" class="form-control fg2_inp1" runat="server" MaxLength="15" onchange="IncrmntConfrmCounter();"></asp:TextBox>
                </div>

                <div class="clearfix"></div>

                <div class="form-group fg5 fg2_mr" id="DivCurrency">
                    <label for="email" class="fg2_la1">Currency:</label>
                    <asp:DropDownList ID="ddlCurrency" class="form-control fg2_inp1 inp_mst custom-select" runat="server" Style="width: 100%;" onchange="return curncyChangeFunt(1);" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);"></asp:DropDownList>
                </div>

                <div class="form-group fg5 fg2_mr" id="divExchangeRate" runat="server" style="display: none">
                    <label class="form1 mar_bo">
                        <span class="">

                            <input type="checkbox" class="hidden" />
                        </span>
                        Exchange Rate:
                    </label>
                    <div class="input-group">
                        <asp:TextBox ID="txtExchangeRate" AutoCompleteType="Disabled" class="form-control inp_bdr inp_mst tr_r" runat="server" MaxLength="10" onblur="return isTagDes(event)" onchange="CalculateNetTotal(0);" onkeypress="return isNumber(event);" onkeydown=" return textCounter1(cphMain_txtExchangeRate,20,event)" Style="margin-right: 4%; text-align: right"></asp:TextBox>
                        <span class="input-group-addon date1" id="lblCrncyAbrvtn" runat="server">QAR</span>
                           <%--<asp:Label ID="lblCrncyAbrvtn" Height="30px"  class="col-sm-4 col-form-label font-sty"  runat="server"      style="width: 27%;" ></asp:Label>--%>
                    </div>
                </div>

                <div class="form-group fg5 fg2_mr">
                    <label for="email" class="fg2_la1 pad_l">Status: <span class="spn1">&nbsp;</span></label>
                    <div class="check1">
                        <div class="">
                            <label class="switch">
                                <input type="checkbox" runat="server" checked="checked" onkeydown="return  IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" id="ChkStatus" />

                                <span class="slider_tog round"></span>
                            </label>
                        </div>
                    </div>
                </div>

   <asp:Button ID="btnSupplier" runat="server" class="btn btn-primary" Style="display: none" Text="Reopen" OnClick="btnSupplier_Click" />

         </ContentTemplate>
    </asp:UpdatePanel>

                <div class="clearfix"></div>
                <div class="devider divid"></div>

                <div class="form-group fg2">
                    <label for="email" class="fg2_la1">Products:<span class="spn1">*</span></label>
                </div>

                <div id="divEmployeeTable" runat="server">
                    <table id="tableMain" class="table table-bordered">
                        <thead class="thead1">
                            <tr id="EnableTax">
                                <th class="th_b5">SL#</th>
                                <th class="th_b4 tr_l">PRODUCT Name</th>
                                <th class="th_b5 tr_c">QTY</th>
                                <th class="th_b1 tr_r">PRICE</th>
                                <th class="th_b8">DISCOUNT</th>
                                <th class="th_b3">TAX</th>
                                <th class="th_b7 tr_r">TOTAL AMOUNT</th>
                                <th class="th_b6">ACTIONS</th>
                                <th class="th_b5 tr_c">CC</th>

                            </tr>
                            <tr id="DisableTax">
                                <th class="th_b5">SL#</th>
                                <th class="th_b2 tr_l">PRODUCT Name</th>
                                <th class="th_b1 tr_c">QTY</th>
                                <th class="th_b1 tr_r">PRICE</th>
                                <th class="th_b4">DISCOUNT</th>
                                <th class="th_b7 tr_r">TOTAL AMOUNT</th>
                                <th class="th_b6">ACTIONS</th>
                                <th class="th_b5 tr_c">CC</th>
                            </tr>
                        </thead>

                        <tbody id="TableaddedRows">
                        </tbody>
                    </table>
                </div>

                <div class="text_area_container">
                    <div class="col-md-4 ma_at_fl">
                        <div class="form-group">
                            <label for="email" class="fg2_la1">Description: <span class="spn1">&nbsp;</span></label>

                            <textarea rows="4" cols="25" class="form-control" onchange="IncrmntConfrmCounter();" runat="server" style="height: 100px; resize: none;" id="txtDesc" onkeydown="textCounter(cphMain_txtDesc,498)" onkeyup="textCounter(cphMain_txtDesc,498)"></textarea>
                        </div>
                    </div>
                    <div class="col-md-4 ma_at_fl">
                        <div class="form-group">
                            <label for="email" class="fg2_la1">Terms: <span class="spn1">&nbsp;</span></label>

                            <textarea rows="4" cols="25" class="form-control" onchange="IncrmntConfrmCounter();" runat="server" style="height: 100px; resize: none;" id="txtTerms" onkeydown="textCounter(cphMain_txtTerms,498)" onkeyup="textCounter(cphMain_txtTerms,498)"></textarea>
                        </div>
                    </div>
                    <div class="col-md-4 txt_alg al1">
                        <div class="col-md-6">
                            <label for="email" class="fg2_la1 tt_am">Gross Amount: <span class="spn1">&nbsp;</span></label>
                        </div>
                        <div class="col-md-6">
                            <span id="txtGrossTotal" class="tt_am tt_al" runat="server" onchange="IncrmntConfrmCounter();" onkeypress="return isTag(event);" onblur="return textCounter(cphMain_txtServiceName,190)" onkeydown=" return textCounter(cphMain_txtServiceName,150)"></span>
                        </div>
                        <div  id="divTaxTotal">
                            <div class="col-md-6">
                                <label for="email" class="fg2_la1 tt_am am2">Tax Amount:<span class="spn1">&nbsp;</span></label>
                            </div>
                            <div class="col-md-6">
                                <span id="txtTaxTotal" class="tt_am tt_al" runat="server" onchange="IncrmntConfrmCounter();" onkeypress="return isTag(event);" onblur="return textCounter(cphMain_txtServiceName,190)" onkeydown=" return textCounter(cphMain_txtServiceName,150)"></span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label for="email" class="fg2_la1 tt_am am3">Total Discount:<span class="spn1">&nbsp;</span></label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtDiscountTotal" class="form-control fg2_inp2 tr_r mar_bo_d" runat="server" AutoCompleteType="Disabled" MaxLength="10" onchange="IncrmntConfrmCounter();" onkeydown="return isTag(event);" onkeypress="return DisableEnter(event)" onblur="CalculateNetTotal(1);"></asp:TextBox>
                        </div>

                        <hr class="hr_amt" />

                        <div class="col-md-6">
                            <label for="email" class="fg2_la1 tt_am am1 txt_l">Net Amount:<span class="spn1"></span></label>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtNetTotal" class="fg2_inp2 tr_r" runat="server" style="border: none;background: none;" onchange="IncrmntConfrmCounter();" onkeypress="return isTag(event);" onblur="return textCounter(cphMain_txtServiceName,190)" onkeydown=" return textCounter(cphMain_txtServiceName,150)"></asp:TextBox>
                        </div>
                        <div id="DivForex_Amount_Tl">
                            <div class="col-md-12">
                                <asp:Label ID="lblExchnangAmt" runat="server" class="fg2_la1 tt_am am1 txt_l"></asp:Label>
                                <%--<label for="email" class="fg2_la1 tt_am am1 txt_l">Net Amount:<span class="spn1"></span></label>--%>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txtTotalWithExchngRate" class="tt_am tt_al" runat="server" MaxLength="100" onchange="IncrmntConfrmCounter();" onkeypress="return isTag(event);" onblur="return textCounter(cphMain_txtServiceName,190)" onkeydown=" return textCounter(cphMain_txtServiceName,150)" Style="display: none;"></asp:TextBox>
                                <%-- <span id="Span1" class="tt_am tt_al" runat="server" onchange="IncrmntConfrmCounter();" onkeypress="return isTag(event);" onblur="return textCounter(cphMain_txtServiceName,190)" onkeydown=" return textCounter(cphMain_txtServiceName,150)"></span>--%>
                            </div>
                        </div>

                    </div>
                    <div id="">

                        <div class="col-md-6">
                        </div>
                    </div>
                </div>



                <div class="col-md-8">
                    <label for="email" class="fg2_la1 pad_l">Add Attachment:<span class="spn1">*</span></label>
                    <div class="check1 mar_btm1">
                        <div class="">
                            <label class="switch">

                                <input type="checkbox" runat="server"    class="bu1" checked="checked" onkeydown="return  IncrmntConfrmCounter();" onchange="return CheckAdAttachment();" onkeypress="return DisableEnter(event)" id="cbxAttachment" />
                                <span class="slider_tog round"></span>
                            </label>
                        </div>
                    </div>


                    <div id="divAtchCCN" runat="server">
                        <div id="divFileCCN" class="col-md-12">
                            <table id="TableFileCCN" width="100%">
                            </table>
                        </div>
                    </div>
                </div>
         </div>
                 <a id="btnFloat" runat="server" onmouseover="opensave()" type="button" class="save_b" title="Save" >
                    <i class="fa fa-save"></i>
                </a>
                <div class="clearfix"></div>
                <div class="free_sp"></div>
                <div class="devider divid"></div>
                <div class="mySave1" id="mySave" runat="server">
                    <div class="save_sec">
                        <asp:Button ID="btnFloatUpdate" runat="server" class="btn sub1" Text="Update" OnClientClick="return PurchaseValidate();" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnFloatUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return PurchaseValidate();" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnFloatConfirm1" runat="server" class="btn sub2" Text="Confirm" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnFloatReopen1" runat="server" Style="display: none" class="btn sub2" Text="Reopen" OnClick="btnReopen1_Click" />
                        <asp:Button ID="btnFloatReopen" runat="server" class="btn sub2" Text="Reopen" OnClientClick="return ConfirmReopen();" />
                        <asp:Button ID="btnFloatConfirm" runat="server" class="btn sub2" Text="Confirm" OnClientClick="return ConfirmAlert();" />
                        <asp:Button ID="btnFloatAdd" runat="server" class="btn sub1" Text="Save" OnClientClick="return PurchaseValidate();" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnFloatAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClientClick="return PurchaseValidate();" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnFloatCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                        <asp:Button ID="btnFloatClear" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                        <asp:Button ID="btnFloatPRint" runat="server" class="btn sub3" Text="Print" OnClientClick="return OpenPrint();" />
                        <button id="BtnFloatPopupCstCntr" type="button" style="display: none" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModalCstCntr">Open Modal</button>
                    </div>
                </div>
                <div class="sub_cont pull-right">
                    <div class="save_sec">
                        <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClientClick="return PurchaseValidate();" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return PurchaseValidate();" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnConfirm1" runat="server" class="btn sub2" Text="Confirm" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnReopen1" runat="server" Style="display: none" class="btn sub2" Text="Reopen" OnClick="btnReopen1_Click" />
                        <asp:Button ID="btnReopen" runat="server" class="btn sub2" Text="Reopen" OnClientClick="return ConfirmReopen();" />
                        <asp:Button ID="btnConfirm" runat="server" class="btn sub2" Text="Confirm" OnClientClick="return ConfirmAlert();" />
                        <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClientClick="return PurchaseValidate();" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClientClick="return PurchaseValidate();" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                        <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                        <asp:Button ID="btnPRint" runat="server" class="btn sub3" Text="Print" OnClientClick="return OpenPrint();" />
                        <button id="BtnPopupCstCntr" type="button" style="display: none" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModalCstCntr">Open Modal</button>
                    </div>
                </div>
                <div id="divList" style="cursor: pointer;" class="list_b" onclick="ConfirmMessage();" runat="server">
                    <i class="fa fa-arrow-circle-left"></i>
                </div>

            </div>
        </div>
    </div>


    <div id="dialog_simple" class="modal fade" tabindex="-1" data-backdrop="static" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod3" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title mod1 flt_l" id="exampleModalLabel"><i class="fa fa-commenting"></i>Remarks</h2>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body md_bd" id="divCancelPopUp">
                    <div id="divErrMsgCnclRsn" class="al-box war">Warning Alert !!!</div>
                    <textarea rows="4" cols="50" class="form-control" placeholder="Write Remarks here..."></textarea>
                </div>

            </div>
        </div>
    </div>
    <div id="CostCenterModal"></div>
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
</asp:Content>

