<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" CodeFile="hcm_Monthly_Salary_Process.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_Process_hcm_Monthly_Salary_Process" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>

    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />
    <%--<link href="/css/HCM/main.css" rel="stylesheet" />--%>
    <link href="../../../../css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="../../../../js/jQueryUI/jquery-ui.min.js"></script>
    <script src="../../../../js/jQueryUI/jquery-ui.js"></script>
    <script src="../../../../js/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../../js/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="/js/HCM/Common.js"></script>


    
        <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
   <style>
       .auto1 {
    width: 97%;
}
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
 <%--  <script src="/JavaScript/multiselect/jQuery/jquery-3.1.1.min.js">--%>
      


      <script type="text/javascript">
          var $NoConfii = jQuery.noConflict();
          $NoConfii(document).ready(function () {
             
              $('#loading').hide();

          });

          function CloseLoading() {
              alert();
              $('#loading').hide();
          }
          var $noCon = jQuery.noConflict();
          $noCon2 = jQuery.noConflict();
          $noCon(function () {
             // LoadEmpList();
              $noCon2(".select2").select2();
            

              var data = document.getElementById("<%=hiddenEmp.ClientID%>").value;
              var totalString = data;
              var eachString = totalString.split(',');
              var newVar = new Array();
              for (count = 0; count < eachString.length; count++) {
                  if (eachString[count] != "") {
                      newVar.push(eachString[count]);
                      //alert(newVar);
                  }
              }
           
              $noCon2('#cphMain_ddlEmployee').val(newVar);
              $noCon2("#cphMain_ddlEmployee").trigger("change");

            
              
          });

         var $noCon1 = jQuery.noConflict();
         $noCon1(window).load(function () {
             localStorage.clear();
              document.getElementById("freezelayer").style.display = "none";
              document.getElementById('MymodalCancelView').style.display = "none";
            
              LoadEmpList();
              var SuccessMsg = '<%=Session["MESSG"]%>';

              if (SuccessMsg == "PROCSS") {
                  SuccessProcess();
              }
              else if (SuccessMsg == "CONF") {
                  SuccessConfirm();
              }
            if (document.getElementById("<%=HiddenEdit.ClientID%>").value == "1")
            {              
               document.getElementById("searchfield").style.display = "none";                 
            }

            
            // if (document.getElementById("<%=HiddenListView.ClientID%>").value == "0") {
              //   document.getElementById("searchfield").style.display = "block";

             // }
             if (document.getElementById("<%=HiddenFieldActiveCbxCnt.ClientID%>").value == "0") {
                 if ($("#cbMandatory").length > 0) {
                     $("#cbMandatory").prop("disabled", true);
                 }
             }
         });

        
         
          </script>
      <script>
          //for search option
          var $NoConfi = jQuery.noConflict();
          var $NoConfi3 = jQuery.noConflict();
      
          var otable = "";
          function LoadEmpList() {

              
              var orgID = '<%= Session["ORGID"] %>';
              var corptID = '<%= Session["CORPOFFICEID"] %>';

          

              var responsiveHelper_datatable_fixed_column = undefined;


              var breakpointDefinition = {
                  tablet: 1024,
                  phone: 480
              };
          
              /* COLUMN FILTER  */
               otable = $NoConfi3('#datatable_fixed_column').DataTable({
                  //"bFilter": false,
                  //"bInfo": false,
                  //"bLengthChange": false
                  //"bAutoWidth": false,
                  //"bPaginate": false,
                   //"bStateSave": true // saves sort state using localStorage
                   "order": [[1, 'asc']],
                  "bDestroy": true,
                  columnDefs: [
      { targets: 0, checkboxes: { selectRow: true } }
                  ],
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
                  }

              });

              // custom toolbar
              //$NoConfi("div.toolbar").html('<div class="text-right"><select / style="Margin-top:10px;"></div>');

              // Apply the filter
              $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                  otable
                      .column($NoConfi(this).parent().index() + ':visible')
                      .search(this.value)
                      .draw();

              });


             
          }

          function RemovePagn()
          {
              var responsiveHelper_datatable_fixed_column = undefined;


              var breakpointDefinition = {
                  tablet: 1024,
                  phone: 480
              };

              /* COLUMN FILTER  */
              var otable2 = $NoConfi3('#datatable_fixed_column').DataTable({
                  //"bFilter": false,
                  //"bInfo": false,
                  //"bLengthChange": false
                  //"bAutoWidth": false,
                  "bPaginate": false,
                  //"bStateSave": true // saves sort state using localStorage
                  "bDestroy": true,
                 
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
                  }

              });

              // custom toolbar
              //$NoConfi("div.toolbar").html('<div class="text-right"><select / style="Margin-top:10px;"></div>');

              // Apply the filter
              $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                  otable2
                      .column($NoConfi(this).parent().index() + ':visible')
                      .search(this.value)
                      .draw();

              });
          }
              /* END COLUMN FILTER */
              </script>

       <style>

          .datepicker.dropdown-menu {
           z-index: 10000;
           }

           .textDate:focus {
            border: 1px solid #bbf2cf;
            box-shadow: 0px 0px 4px 2.5px #bbf2cf;
        }
        .textDate {
            border: 1px solid #cfcccc;
        }
            .open > .dropdown-menu {
    display: none;
             }

            .bootstrap-datetimepicker-widget {

    z-index: 100;
}
              .eachform h2 {
                margin: 6px 0 6px;
            }
    </style>
    <style>
        
        .select2-container--default .select2-selection--multiple .select2-selection__choice {
            background-color: #a5a5a5;
            border-color: #8d8d8d;
            padding: 1px 5px;
            color: #fff;
            font-size: 14px;
            margin: 2px;
            max-width: 260px;
        }

        .select2-container--default .select2-selection--multiple .select2-selection__choice__remove {
            color: #fff;
            cursor: pointer;
            display: inline-block;
            font-weight: bold;
            margin-right: 5px;
        }

        .select2-container--default.select2-container--focus .select2-selection--multiple {
            border: solid #aeaeae 1px;
            outline: 0;
        }

        .select2-results__option[aria-selected] {
            cursor: pointer;
            font-size: small;
            font-family: calibri;
        }

    </style>

         
            <!-- SmartChat UI : plugin -->
   

   

     <style>
        table.dataTable tbody td {
            word-break:break-all;          
        }
        
         .table {
            font-size:13px;
        }
          .glyphicon-search::before {
    content:url(/Img/Icons/search.png);
    margin-left: -43%;
}
        #datatable_fixed_column_wrapper {
            border: 1px solid #ddd;
            padding: 2%;
        }

          
    </style>
        <script type="text/javascript">
            var submit = 0;
            function CheckIsRepeat() {
                if (++submit > 1) {

                    return false;
                }
                else {
                    return true;
                }
            } function CheckSubmitZero() {
                submit = 0;
            }
    </script>
      
        <script type="text/javascript">
            function EditRow(x, y, z, a, b) {
        
             var editvw= document.getElementById("HiddEditView"+b+"").value;
                
             document.getElementById("<%=HiddenViewId.ClientID%>").value = x + "~" + y + "~" + z + "~" + a + "~" + editvw;
              
           document.getElementById("<%=btnRedirect.ClientID%>").click();

                             return false;
                         }
            function validateSearch() {
                var ret = true;
                IncrmntConfrmCounter();
                if (CheckIsRepeat() == true) {
                }
                else {
                    ret = false;
                    return ret;
                }
                document.getElementById("txtDateFrom").style.borderColor = "";
                var date = document.getElementById("<%=Hiddentxtefctvedate.ClientID%>").value;
                var Empval = $noCon1('#cphMain_ddlEmployee').val();
                
                document.getElementById("<%=hiddenEmp.ClientID%>").value = Empval;
             
                if (date == "") {
                    document.getElementById("txtDateFrom").style.borderColor = "Red";
                    document.getElementById("txtDateFrom").focus();
                  //  SuccessMsg("SAVE", "Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#success-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    $noCon("#success-alert").alert();
                    $noCon1(window).scrollTop(0);
                    // return false;
                    ret = false;
                }
               
                if (ret == false) {
                    CheckSubmitZero();

                }
                if(ret==true)
                $('#loading').show();
                return ret;
            }
         //   function SuccessConfirm() {
              //  '<%Session["MESSG"] = "' + null + '"; %>';
              //  SuccessMsg("SAVE", "Monthly Salary process confirmed  successfully");

          //  }


            function SuccessConfirm() {

                '<%Session["MESSG"] = "' + null + '"; %>';

                $noCon("#success-alert").html("Monthly Salary process confirmed  successfully");
                $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#success-alert").alert();

                return false;
            }
            function SuccessProcess() {

                '<%Session["MESSG"] = "' + null + '"; %>';

                $noCon("#success-alert").html("Monthly Salary process Processed  successfully");
                $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                 });
                $noCon("#success-alert").alert();

                 return false;
            }

            function SuccessDelete() {

                '<%Session["MESSG"] = "' + null + '"; %>';

                            $noCon("#success-alert").html("Monthly Salary process deleted successfully");
                            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                            });
                            $noCon("#success-alert").alert();

                            return false;
                        }

            function CorpSalGreat() {
                $noCon("#divWarning").html("Salary processing month should be greater than or equal to corporate salary date!.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                 });
                $noCon("#divWarning").alert();
                return false;
             }
         //   function SuccessProcess()
         //   {
          //      '<%Session["MESSG"] = "' + null + '"; %>';
          //      SuccessMsg("SAVE", "Monthly Salary process Processed  successfully");

            //   }
            function valdatepross()
            {
                  otable.search('').draw();

               
                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure you want to process the monthly salary?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            if (validateProcess())
                            {
                               // otable.destroy();
                                document.getElementById("<%=butnprsstemp.ClientID%>").click();
                            
                                return true;
                            }
                            //window.location = href;
                        
                        }
                        else {
                          
                        
                        }
                    });
                
                return false;
            }

            function valdateConfirm() {

                document.getElementById("<%=hidden_Month.ClientID%>").value = document.getElementById("hiddenmonth").value;
                document.getElementById("<%=hidden_Year.ClientID%>").value = document.getElementById("hiddenyear").value;

                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to confirm the monthly salary?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        if (validateProcess()) {

                            document.getElementById("<%=BtnContemp.ClientID%>").click();

                                return true;
                            }
                            //window.location = href;

                        }
                        else {


                        }
                    });

                    return false;
                }
            function validateProcess() {
               
                var ret = true;
                //if (CheckIsRepeat() == true) {
                //}
                //else {
                //    ret = false;
                //    return ret;
                //}
                document.getElementById("txtDateFrom").style.borderColor = "";
                var Empval = $noCon1('#cphMain_ddlEmployee').val();
             
                document.getElementById("<%=hiddenEmp.ClientID%>").value = Empval;
                var date=  document.getElementById("<%=Hiddentxtefctvedate.ClientID%>").value;
                
                var RowCount = document.getElementById("<%=HiddenFieldCbxCheck.ClientID%>").value;
             
                var temp = "";
                var amount = "";
                var specialAmt = "";
                var MessDedctnAmt = "";
                var LVArrearAmt = "";
                var OtherAdditionAmt = "";
                var OtherDeductionAmt = "";
                var PrevArreAmt = "";
                var PrevRejoinDate = "";
                RemovePagn();
              
               
               // otable.destroy();


                //  for (i = 0; i < RowCount; i++) {
                // alert("dddddd");

               
                //var addRowtable = document.getElementById("datatable_fixed_column");
                //for (var i = 0; i < addRowtable.rows.length; i++) {
                //    var xLoop = (addRowtable.rows[i].cells[0].value);
                //    alert(xLoop);
                //    if (xLoop != "") {


             

                $('input[type="checkbox"]').each(function () {
                    var row = $(this).attr("id");
                    varSplit = row.split('cbMandatory');
              
                    if (varSplit[1] != "") {
                        if (temp == "") {
                            if (document.getElementById("cbMandatory" + varSplit[1]).checked) {
                              
                                temp = document.getElementById("cbMandatory" + varSplit[1]).value;
                                amount = document.getElementById("Totalamt" + varSplit[1]).value;
                                specialAmt = document.getElementById("TotalaLLOWdEDCTN" + varSplit[1]).value;
                                MessDedctnAmt = document.getElementById("TotalMessDedctn" + varSplit[1]).value;
                                LVArrearAmt = document.getElementById("TotalLvArrearAmt" + varSplit[1]).value;

                                OtherAdditionAmt = document.getElementById("TotalOtherAddtionAmt" + varSplit[1]).value;
                                OtherDeductionAmt = document.getElementById("TotalDeductionAmt" + varSplit[1]).value;
                                PrevArreAmt = document.getElementById("PrevMnthArrearAmt" + varSplit[1]).value;
                                PrevRejoinDate = document.getElementById("PrevRejoinDate" + varSplit[1]).value;
                            }
                        }
                        else {
                            if (document.getElementById("cbMandatory" + varSplit[1]).checked) {
                               

                                temp = temp + "," + document.getElementById("cbMandatory" + varSplit[1]).value;
                                amount = amount + "," + document.getElementById("Totalamt" + varSplit[1]).value;
                                specialAmt = specialAmt + "/" + document.getElementById("TotalaLLOWdEDCTN" + varSplit[1]).value;
                                MessDedctnAmt = MessDedctnAmt + "/" + document.getElementById("TotalMessDedctn" + varSplit[1]).value;
                                LVArrearAmt = LVArrearAmt + "/" + document.getElementById("TotalLvArrearAmt" + varSplit[1]).value;

                                OtherAdditionAmt = OtherAdditionAmt + "/" + document.getElementById("TotalOtherAddtionAmt" + varSplit[1]).value;
                                OtherDeductionAmt = OtherDeductionAmt + "/" + document.getElementById("TotalDeductionAmt" + varSplit[1]).value;
                                PrevArreAmt = PrevArreAmt + "/" + document.getElementById("PrevMnthArrearAmt" + varSplit[1]).value;
                                PrevRejoinDate = PrevRejoinDate + "/" + document.getElementById("PrevRejoinDate" + varSplit[1]).value;
                            }
                        }
                    }

                });
                //  }
          //  }
              
              
                document.getElementById("<%=HiddenFieldCheckEmp.ClientID%>").value = temp;
                document.getElementById("<%=HiddenAmount.ClientID%>").value = amount;
              
                document.getElementById("<%=HiddenFieldSpecialAmount.ClientID%>").value = specialAmt;
                document.getElementById("<%=HiddenDedctnMessAmount.ClientID%>").value = MessDedctnAmt;
                document.getElementById("<%=HiddenFieldLeaveArrearAmt.ClientID%>").value = LVArrearAmt;
                
                document.getElementById("<%=hiddenOtherAdditionAmt.ClientID%>").value = OtherAdditionAmt;
                document.getElementById("<%=hiddenOtherDeductionAmt.ClientID%>").value = OtherDeductionAmt;
                
                document.getElementById("<%=hiddenPrevArrAmt.ClientID%>").value = PrevArreAmt;
                document.getElementById("<%=hiddenPrevRejoinDate.ClientID%>").value = PrevRejoinDate;
                LoadEmpList();
          
                if (temp == "")
                {
                   // SuccessMsg("SAVE", "Please select the employee to continue.");

                    $noCon("#success-alert").html("Please select the employee to continue.");
                    $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    $noCon("#success-alert").alert();
                    $noCon1(window).scrollTop(0);
                   // return false;
                    ret = false;
                }

                if (date == "")
                {
                    document.getElementById("txtDateFrom").style.borderColor = "Red";
                    document.getElementById("txtDateFrom").focus();
                 //   SuccessMsg("SAVE", "Some of the information you entered is not correct or missing. Please check the highlighted fields below.");

                    $noCon("#success-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    $noCon("#success-alert").alert();
                    $noCon1(window).scrollTop(0);
                    // return false;
                    ret = false;
                }
                //if (ret == false) {
                //    CheckSubmitZero();

                //}

                return ret;
            }
            
            </script>
        <script type="text/javascript">
            var confirmbox = 0;

            function IncrmntConfrmCounter() {
           
                confirmbox++;
            }
            function changeSingle() {

                var RowCount = document.getElementById("<%=HiddenFieldCbxCheck.ClientID%>").value;
                IncrmntConfrmCounter();
                var oTable = $NoConfi3('#datatable_fixed_column').DataTable({
                    "bDestroy": true,
                    stateSave: true,

                });
                var flag = 0;
                var allPages = oTable.cells().nodes();
               // alert(allPages);

                $(allPages).find('input[type="checkbox"]:checked').each(function () {

                    flag++;
                    //this is the current checkbox
                });
             //  RemovePagn();
                if (flag == 0) {
                   
                    document.getElementById("<%= BtnPross.ClientID%>").style.display = "none";
                  }
                  else {
                    //alert(); 
                    if ((document.getElementById("<%=BtnCon.ClientID%>").style.display) == "block")
                        document.getElementById("<%=BtnPross.ClientID%>").style.display = "none";
                    else
                        document.getElementById("<%=BtnPross.ClientID%>").style.display = "block";
                     
                }
                $(allPages).find('input[type="checkbox"]:not(:checked)').each(function () {
                    document.getElementById("cbMandatory").checked = false;
                    //this is the current checkbox
                });
              // alert(RowCount);
              //  $('#datatable_fixed_column').find('input[type=checkbox]:not(:checked)').each(function () {
                  //  document.getElementById("cbMandatory").checked = false;
                  //  document.getElementById("<%=BtnPross.ClientID%>").style.display = "none";
                    //});
              //  alert("begin");

               //     $('#datatable_fixed_column').find('input[type="checkbox"]:checked').each(function () {
                        //  document.getElementById("<%=BtnPross.ClientID%>").style.display = "block";
               //         alert("in");
               //      });
                //alert(RowCount);
                <%--     
                    else {
                        flag++;
                    }
                }
           
               LoadEmpList();--%>
                //for (var i = 0; i < RowCount; i++) {
                //    if (document.getElementById("cbMandatory" + i).checked == true) {
                //        (document.getElementById("TotalAmt" + i).value == "0" || document.getElementById("TotalAmt" + i).value == "0.00")
                //        {
                //            document.getElementById("cbMandatory").checked = false;
                //        }
                //    }
                //}
                return false;
            }

            function changeAll() {
                // IncrmntConfrmCounter();
                var RowCount = document.getElementById("<%=HiddenFieldCbxCheck.ClientID%>").value;
                  IncrmntConfrmCounter();
                  var oTable = $NoConfi3('#datatable_fixed_column').DataTable({
                      "bDestroy": true,
                      stateSave: true,

                  });
                  var allPages = oTable.cells().nodes();
                  if (document.getElementById("cbMandatory").checked == true) {
                      if ((document.getElementById("<%=BtnCon.ClientID%>").style.display) == "block")
                          document.getElementById("<%=BtnPross.ClientID%>").style.display = "none";
                      else
                      document.getElementById("<%=BtnPross.ClientID%>").style.display = "block";

                      $(allPages).find('input[type="checkbox"]:not(:checked)').each(function () {
                          if ($(this).is(':enabled')) {
                              $(this).prop('checked', true);
                          }
                    //this is the current checkbox


                });



            }
            else {
                document.getElementById("<%=BtnPross.ClientID%>").style.display = "none";
                $(allPages).find('input[type="checkbox"]:checked').each(function () {
                    $(this).prop('checked', false);
                });

            }
            LoadEmpList();
            return false;

        }
         
            function ConfirmCancel() {
                if (confirmbox > 1)
                    ConfirmMessage("hcm_Monthly_Salary_Process_List.aspx");
                else
                    window.location.href ="hcm_Monthly_Salary_Process_List.aspx";
                return false;
            }
            function ConfirmMessageButtn() {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to process the monthly salary?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                       
                        //window.location = href;
                        return true;
                    }
                    else {
                       
                        return false;
                    }
                });
                //return false;

            }
       
            function DateCurrentValue()
            {
                
                var DateVal = document.getElementById("txtDateFrom").value;
                if (DateVal == "")
                {
                   
                    document.getElementById("txtDateFrom").value = document.getElementById("<%=Hiddendate.ClientID%>").value;
                  
                }
            }      
    </script>

    <script>

        function DeleteRow(PrcssId) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to cancel this entry?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var objOrg2 = {};
                    objOrg2.PrcssId = PrcssId;
                    $noCon.ajax({
                        async: false,
                        type: "POST",
                        url: "hcm_Monthly_Salary_Process.aspx/DeleteMonthlyProces",
                        data: JSON.stringify(objOrg2),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {                          
                            window.location.href = "hcm_Monthly_Salary_Process.aspx?Deleted=true";
                            return false;
                        },
                        failure: function (response) {
                            alert("Fail")

                        }
                    });
                       return false;

                   }
                else {
                       return false;
                   }
               });
               return false;
           }
    </script>

<script>

    function OtherAdd_Ded_Display(PayinfoId, EmpId, PayrolMod) {
        
        var PayinfoId = PayinfoId;
        var EmpId = EmpId;
        var PayrolMod = PayrolMod;       
        var corpid = '<%= Session["CORPOFFICEID"] %>';
        var orgid = '<%= Session["ORGID"] %>';



        if (PayinfoId != "") {
            var obj = {};
            obj.orgid = '<%= Session["ORGID"] %>';;
            obj.corpid = '<%= Session["CORPOFFICEID"] %>';
            obj.PayinfoId = PayinfoId;
            obj.EmpId = EmpId;
            obj.PayrolMod = PayrolMod;
            obj.IndividualRound = document.getElementById("<%=HiddenFieldIndividualRound.ClientID%>").value;
            $noCon.ajax({
                async: false,
                type: "POST",
                url: "hcm_Monthly_Salary_Process.aspx/OtherAdd_Ded_Details",
                data: JSON.stringify(obj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d != "") {
                        document.getElementById("divAddDedDetls").innerHTML = response.d;
                        if (PayrolMod == 1) {
                            document.getElementById("hStatementType").innerHTML = "Other Addition List";
                        }
                        else {
                            document.getElementById("hStatementType").innerHTML = "Other Deduction List";
                        }
                        $noCon('#dialog_simple').modal('show');
                    }
                },
                failure: function (response) {
                    alert("Fail")

                }
            });
        }
     }

</script>



    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
      <asp:HiddenField ID="HiddenFieldIndividualRound" runat="server" value="0"/> 
    <asp:HiddenField ID="HiddenRoleConf" runat="server" />
      <asp:HiddenField ID="HiddenAmount" runat="server" />
        <asp:HiddenField ID="hiddenEmp" runat="server" />
      <asp:HiddenField ID="HiddenFieldCbxCheck" runat="server" />
    <asp:HiddenField ID="HiddenFieldCheckEmp" runat="server" />
     <asp:HiddenField ID="HiddenViewId" runat="server" />
      <asp:HiddenField ID="HiddenSuccessMsgType" runat="server" />
     <asp:HiddenField ID="HiddenListView" runat="server" />
     <asp:HiddenField ID="HiddenFieldSpecialAmount" runat="server" />
    <asp:HiddenField ID="HiddenEdit" runat="server" />
      <asp:HiddenField ID="HiddenEditView" runat="server" />
      <asp:HiddenField ID="Hiddendate" runat="server" />
       <asp:HiddenField ID="HiddenDedctnMessAmount" runat="server" />
     
       <asp:HiddenField ID="HiddenFieldLeaveArrearAmt" runat="server" />
     <asp:HiddenField ID="hiddenPrevArrAmt" runat="server" />
    
    <%--EVM-0027--%>
    <asp:HiddenField ID="HiddenBasicSalary" runat="server" />
    <asp:HiddenField ID="HiddenAllwnc" runat="server" />
    <asp:HiddenField ID="HiddenDeduction" runat="server" />

     <asp:HiddenField ID="hiddenOtherAdditionAmt" runat="server" />
     <asp:HiddenField ID="hiddenOtherDeductionAmt" runat="server" />

     <asp:HiddenField ID="hidden_Month" runat="server" />
     <asp:HiddenField ID="hidden_Year" runat="server" />

     <asp:HiddenField ID="HiddenFieldActiveCbxCnt" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenPrevRejoinDate" runat="server" />
     <asp:HiddenField ID="HiddenFieldFixedPayrlMode" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldWorkdayFixedPayrlMode" runat="server" Value="0" />
    
   <%-- END--%>
    
    <asp:Button ID="btnRedirect" runat="server" Text="Button" style="display:none;" OnClick="btnRedirect_Click" />

       <%-- <script src="/js/HCM/Common.js"></script>--%>
      <div id="main" role="main">
        <div id="ribbon" style="display:none">
            <span id="refresh" class="btn btn-ribbon" data-action="resetWidgets" data-title="refresh" rel="tooltip" data-placement="bottom" data-original-title="<i class='text-warning fa fa-warning'></i> Warning! This will reset all your widget settings." data-html="true">
                <i class="fa fa-refresh"></i>
            </span>
        </div>
        <div id="content">
             
<%--            <div class="row">
                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-4">
                    <h1 class="page-title txt-color-blueDark">
                        <i class="fa-fw fa fa-home"></i>
                        Currency Master
                    </h1>
                </div>

                <div style="width: 11%; float: right;">
                    <a href="#" style="background-color: #1c74a4; width: 75px; height: 27px; padding: 2px;" onclick="return currentLangCodeSrch();" id="dialog_link" class="btn btn-info">Search </a>
                </div>
            </div>--%>
            <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button> 
        </div>
             <div class="alert alert-warning" id="divWarning" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>
            <section id="widget-grid" class="">

                <div class="row">
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <div class="" id="wid-id-0">

                            <header>

                                <label id="lblHeader" class="pageh2"  runat="server">Monthly Salary Process</label>

                            </header>

                            <div id="boarder"  class="smart-form" style="float: left; width: 99%;">

                                <div id="TabContainer" runat="server" style="float: left; width: 100%;">
                                </div>

                                 <div id="divList" class="list"  onclick="return ConfirmCancel();"  runat="server" style="position:fixed; right:0%; top:26%;height:26.5px;z-index:1;"> </div>
                                <div id="searchfield"  style="float: left; width: 98%; background: white; margin-top: 2%; padding-left: 1%;">
                                    
                                      
                                    <div style="width: 100%; float: left;" class="formdiv">


                                         <div style="width: 50%; float: left; ">

                                            <section style="width: 95%; margin-left: 5%;margin-bottom: 0px;">
                                                <label class="lblh2" style="float: left;width: 27%;">Month & Year*</label>
                                            
                                                         <div id="divDdlEmployee">

                                            <label class="select">
                                             
                                                   <asp:DropDownList ID="ddlMonth"    runat="server" style="width:45%;float:left" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" ></asp:DropDownList>
                                          <%--  </label>
                                             <label class="select">--%>
                                               <asp:DropDownList ID="ddlyear"   runat="server" onchange="IncrmntConfrmCounter();" style="width:15%" onkeypress="return DisableEnter(event)" ></asp:DropDownList>

                                            </label>
                                        </div>
                                                
                                            </section>


                                        </div>


                                        <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 7%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Date*</label>
                                             
                                                    <label class="input" style="float: left;width: 60%;">
                                                             <%--<label class="input" style="float: left;width: 77%;margin-left: 0%;">--%>
               <%--  <asp:TextBox ID="txtDateFrom" class="textDate"  placeholder="DD-MM-YYYY" MaxLength="20" runat="server"    Style="  font-family: calibri;width: 99%;margin-left: -1%;" ></asp:TextBox>--%>
                                                                    <input id="txtDateFrom" readonly="readonly" name="txtDateFrom" onblur="DateCurrentValue();" type="text" onkeypress="return DisableEnter(event)"   class="Tabletxt form-control datepicker"  data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" onchange="show()" />
                                                    <asp:HiddenField ID="Hiddentxtefctvedate" runat="server" value="0"/>
                                                                        <script>
                                                                            var $noCon4 = jQuery.noConflict();
                                                                            //$noCon4('#txtDateFrom').datepicker({
                                                                            //    autoclose: true,
                                                                            //    format: 'dd-mm-yyyy',
                                                                            //    //endDate: 'today',
                                                                                
                                                                            //});
                                                                            function show() {
                                                                                //DateCheck();
                                                                                IncrmntConfrmCounter();
                                                                               // $noCon4("#txtDateFrom").datetimepicker({ format: 'dd-mm-yyyy' })
                                                                                $noCon4('#cphMain_Hiddentxtefctvedate').val($noCon4('#txtDateFrom').val().trim());

                                                                            }
                                                                            function insert() {


                                                                                $noCon4('#txtDateFrom').val($noCon4('#cphMain_Hiddentxtefctvedate').val().trim());

                                                                            }
                                                                             </script>
             </label>
                       
                                                               
                
                                              <%--  </label>--%>
                                            </section>


                                        </div>
                                       
                                    </div>

                                   

                                    <div style="width: 100%; float: left;" class="formdiv">
                                        <div style="width: 50%; float: left;">

                                            <section style="width:95%; margin-left: 5%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Business Unit*</label>
                                                <label class="select" style="float: left;width:60%;">
                                                      <asp:DropDownList ID="ddlBussunit"   runat="server" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" ></asp:DropDownList>

                                                   
                                                </label>
                                            </section>


                                        </div>

                                     <%--   <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 7%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Year*</label>
                                                                        <div id="divdeduction">

                                           
                                        </div>
                                            </section>


                                        </div>--%>
                                  <%--  </div>--%>
                                  
                              <%--  <div style="width: 100%; float: left;" class="formdiv">--%>
                                       
                                   <%--EVM-0027--%>
                                    
                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
                                        <ContentTemplate>

                                       <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 7%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Department</label>
                                               
                                                          <label class="select" style="float: left;width: 60%;">
                                                      <asp:DropDownList ID="ddlDep" onchange="IncrmntConfrmCounter();"   runat="server"  onkeypress="return DisableEnter(event)" AutoPostBack="true" OnSelectedIndexChanged="ddlDep_SelectedIndexChange"></asp:DropDownList>

                                                   
                                                </label>
                                          
                                            </section>


                                        </div>
                                             
                                        
                                  
                                    
                            <div style="width: 100%; float: left;" class="formdiv">
                                 <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 5%;">
                                                <label class="lblh2" style="float: left;width:27%;">Division</label>
                                                 <label class="select" style="float: left;width:60%;">
                                                      <asp:DropDownList ID="ddlDivision" onchange="IncrmntConfrmCounter();"   runat="server"  onkeypress="return DisableEnter(event)" ></asp:DropDownList>

                                                   
                                                </label>
                                            </section>


                                        </div>
                                   
                                 
                                        <div style="width: 50%; float: left;">

                                            <section style="width:95%; margin-left:7%;">
                                                  <label class="lblh2" style="float: left;width: 27%;">Designation</label>
                                               
                                              <label class="select" style="float: left;width: 60%;">
                                                      <asp:DropDownList ID="ddldesg" onchange="IncrmntConfrmCounter();"   runat="server"  onkeypress="return DisableEnter(event)" ></asp:DropDownList>

                                                   
                                                </label>

                                             
                                            </section>


                                        </div>
                                    </div>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                  </div>
                                   <%-- END--%>
                                         <div style="width: 100%; float: left;" class="formdiv">


                                              <div style="width: 50%; float: left; """>

                                            <section style="width: 95%; margin-left: 5%;">
                                                <label class="lblh2" style="float: left;width: 27%;">Type*</label>
                                              
                                                        <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px; width: 33%; float: left; border: 1px solid #04619c; margin-bottom: 1px;">

                                            <label class="radio" style="font-family: Calibri;">
                                                <input name="radioCustType" checked="true"  runat="server" onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" type="radio" id="radioCustType2"  />
                                                <i></i>Staff</label>
                                            <label class="radio" style="font-family: Calibri;">
                                                <input name="radioCustType"  runat="server" onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" type="radio" id="radioCustType1"  />
                                                <i></i>Worker</label>

                                        </div>
                                            
                                            </section>


                                        </div>


                                      <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 7%;">
                                                 <label class="lblh2" style="float: left;width: 27%;">Employee</label>
                                                <div id="div1" style="word-break: break-all; word-wrap: break-word;">
                                          <label class="select" style="float: left;width: 60%;word-break: break-all; word-wrap: break-word;">
                                                      <asp:DropDownList ID="ddlEmployee" onchange="IncrmntConfrmCounter();"    data-placeholder="select employee"  multiple="multiple" class="form1 select2" runat="server"  onkeypress="return DisableEnter(event)" ></asp:DropDownList>

                                                   
                                                </label>
                                           </div>



                                            </section>
                                          </div>
                    </div>
                                       
                                              <div style="width: 100%; float: left;" class="formdiv">
                                   <%--  <footer style="background: white;">--%>
                                       <div style="width: 50%; float: right;">

                                            <section style="width: 95%; margin-left: 7%;">
                                                  <label  style="float: left;width: 21%;margin-top: 1%;margin-left: 43%;">
                                       <asp:Button ID="btnSrch" runat="server" Style="  margin-left: 81%;height: 31px; margin-left: 5px;padding: 0 22px;font: 300 15px/29px 'Open Sans',Helvetica,Arial,sans-serif;cursor: pointer;" class="btn btn-primary" Text="Search" OnClick="btnSrch_Click" OnClientClick="return validateSearch();" />
                                                       </label>

    </section>
                                          </div>
                                                   <div id="divNote" class="eachform" style="padding-left:1%; color: green; font-family:Calibri; padding: 2.5%; ">
                 <asp:Label ID="lblNote" runat="server" Text="NB: Exceeded Leaves will be settle on december"></asp:Label> 
                   </div>
                                              </div>

                                      
   
                                         <%--  </footer>--%>
         <%--  table--%>
                                </div>
                                
                                 	 <div id="loading">
                                    
       <img src="/Images/Other%20Images/loading.gif" style="width: 12%; margin-left: 46%; margin-top: 4%;" />

    </div>
 

                                  
                                   <div  class="jarviswidget-color-greenLight jarviswidget-sortable" id="wid-id-3" data-widget-editbutton="false" role="widget">
                                         <div style="width: 100%; float: left;margin-top: 1%; border: 1px solid #b0adad;" runat="server" id="ListPage">


                                        <div style="width: 100%; float: left;margin-top: 0%;" class="formdiv">
                                       
                                        <div style="width: 50%; float: right;">

                                            <section style="width: 95%; margin-left: 6%;">
                                                  <label  style="float: left;width: 23%;margin-top: 1%;margin-left: 43%;">
                                       <asp:Button ID="BtnPross" runat="server" Style="  display:none;margin-left: 81%;height: 31px; margin-left: 5px;padding: 0 22px;font: 300 15px/29px 'Open Sans',Helvetica,Arial,sans-serif;cursor: pointer;" class="btn btn-primary" Text="Process"  OnClientClick="return valdatepross();" />
                                                      <asp:Button ID="butnprsstemp" runat="server" OnClick="btnPrss_Click" Text="Button" Style="display:none" />     </label>
                                                  <label  style="float: right;width: 23%;margin-top: 1%;margin-right: 35%;">
                                       <asp:Button ID="BtnCon" runat="server" Style="  margin-left: 81%;height: 31px; margin-left: 5px;padding: 0 22px;font: 300 15px/29px 'Open Sans',Helvetica,Arial,sans-serif;cursor: pointer;" class="btn btn-primary" Text="Confirm"  OnClientClick="return valdateConfirm();" />
                                                        <asp:Button ID="BtnContemp" runat="server" OnClick="btnConfrm_Click" Text="Button" Style="display:none" />  </label>
    </section>
                                          </div>
                                            </div>
                                			<div  id="divlistview" style="width:100%;float:left;margin-top:1%"  runat="server">
	
										</div>
                                             </div>
				
									</div>
                               <%-- <footer style="background: white;">--%>
                                 <%--   <asp:Button ID="btnAddClose" runat="server" Style="float: left; margin-left: 80%;" class="btn btn-primary" Text="Save" OnClick="btnSave_Click" OnClientClick="return validatedinomn();" />
                                    <asp:Button ID="btnUpdClose" runat="server" Style="display: none; float: left; margin-left: 81%;" class="btn btn-primary" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return validatedinomn();" />
                                    <asp:Button ID="btnClear" runat="server" Style="float: left;" class="btn btn-primary" Text="Cancel" OnClientClick="return ConfirmCancel();" />--%>
                                    <%--      <button type="submit" class="btn btn-primary">
                                            SAVE float: left;margin-left: 80%;
                                        </button>--%>
                               <%-- </footer>--%>
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


        <div class="modal fade" id="dialog_simple" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog3 mod2" role="document" style="width: 480px;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title tr_c" id="hStatementType"></h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <div id="divAddDedDetls"></div>

                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>



         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>

 
        <script type="text/javascript">
  


    </script>
    <style>
        .jarviswidget {
            position: inherit;
        }
     /*#ListPage {
                    border: 1px solid #ddd;
                }*/
   
          /*#searchfield {
                    border: 1px solid #ddd;
                }*/
              #boarder {
                    border: 1px solid #b0adad;
                    padding:1%;
                }
                #datatable_fixed_column_wrapper {
            border: 1px solid #b0adad;
             padding-top: 1%;
        }
                   /*.hasinput sorting_asc {
                    border: 1px solid #b0adad;
                   
                }*/
        /*#datatable_fixed_column > tbody > tr:nth-child(2n+1) > td, .main_table > tbody > tr:nth-child(2n+1) > th {
            height: 30px;
            background: #DDD;
            font-size: 14px;
            color: #5c5c5e;
        }

        #datatable_fixed_column > tbody > tr:nth-child(2n) > td, .main_table > tbody > tr:nth-child(2n) > th {
            height: 30px;
            background: #C2C2C2;
            font-size: 14px;
            color: #000;
        }

        #datatable_fixed_column > tbody > tr:nth-child(2n+1) > td, .main_table > tbody > tr:nth-child(2n+1) > th {
            height: 30px;
            background: #DDD;
            font-size: 14px;
            color: #5c5c5e;
        }

        #datatable_fixed_column > tbody > tr:nth-child(2n) > td, .main_table > tbody > tr:nth-child(2n) > th {
            height: 30px;
            background: #C2C2C2;
            font-size: 14px;
            color: #000;
        }*/
      
    </style>
</asp:Content>


