<%@ Page Language="C#" AutoEventWireup="true" enableEventValidation="false"  MasterPageFile="~/MasterPage/MasterPageNewHcm.master" CodeFile="hcm_Monthly_Salary_Process_Master.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_Process_hcm_Monthly_Salary_Process_Master" %>

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

      
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
 <%--  <script src="/JavaScript/multiselect/jQuery/jquery-3.1.1.min.js">--%>
      


       <script type="text/javascript">
           var $noCon1 = jQuery.noConflict();
           $noCon1(window).load(function () {
               if (document.getElementById("<%=HiddenSalaryDedctnId.ClientID%>").value == "") {
                   document.getElementById("<%=radPercntge.ClientID%>").checked = true;
                  document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = true;
                  RadioPerClick();

              }
               LoadddlAllwncededctn();
              
               LoadListPageallwnce();
               //  LoadEmpList();
              
          
              // RadioPerClick();
               addCommas('cphMain_txtAmntRedcnFrom');
               addCommas('cphMain_txtAmntRgeFrm');
               
               addCommas('cphMain_txtperctg');
               //SALARY DETAILS 0008

               var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var basicpay = parseFloat(document.getElementById("<%=HiddenSalarSummry.ClientID%>").value);
               var a = parseFloat(basicpay).toFixed(FloatingValue);
               toatlpay = parseFloat(a);
               addCommasSummry(a);
               a = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;

            document.getElementById('SumryPayRng').innerHTML = a + " " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
               var totalpay = parseFloat(document.getElementById("<%=HiddenSalarSummry.ClientID%>").value);


               totalpay = totalpay + parseFloat(document.getElementById("<%=HiddenTotalpay.ClientID%>").value);
               var SuccessMsg = '<%=Session["MESSGSALARY"]%>';

               if (SuccessMsg == "SAVEALLOW") {
                   SuccessConfirmationAllwnce();
               }
               else if (SuccessMsg == "SAVEDEDCTN") {
                   SuccessConfirmationDedctn();
               }
               else if (SuccessMsg == "SAVEDEL") {
                   SuccessCancelationAllwnce();
               }
               else if (SuccessMsg == "SAVEDELL") {
                   SuccessCancelationDedctn();
               }
               else if (SuccessMsg == "UPDADDTN") {
                   UpdatePayGradeAllwnce();
               }
               else if (SuccessMsg == "UPDDEDTN") {
                   UpdatePayGradeDedctn();
               }
            
           });

         </script>

       <script>
           //for search option
           var $NoConfi = jQuery.noConflict();
           var $NoConfi3 = jQuery.noConflict();


           function LoadEmpList() {


               var orgID = '<%= Session["ORGID"] %>';
           var corptID = '<%= Session["CORPOFFICEID"] %>';



           var responsiveHelper_datatable_fixed_column = undefined;


           var breakpointDefinition = {
               tablet: 1024,
               phone: 480
           };
         
           /* COLUMN FILTER  */
           var otable = $NoConfi3('#ReportTableAllow').DataTable({
               //"bFilter": false,
               //"bInfo": false,
               //"bLengthChange": false
               //"bAutoWidth": false,
               //"bPaginate": false,
               //"bStateSave": true // saves sort state using localStorage
               "bDestroy": true,
              
               "preDrawCallback": function () {
                   // Initialize the responsive datatables helper once.
                   if (!responsiveHelper_datatable_fixed_column) {
                       responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($NoConfi3('#ReportTableAllow'), breakpointDefinition);
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
           $NoConfi("#ReportTableAllow thead th input[type=text]").on('keyup change', function () {

               otable
                   .column($NoConfi(this).parent().index() + ':visible')
                   .search(this.value)
                   .draw();

           });

       

        
               /* END COLUMN FILTER */


               /* COLUMN FILTER  */
           var otable = $NoConfi3('#ReportTableDedtn').DataTable({
               //"bFilter": false,
               //"bInfo": false,
               //"bLengthChange": false
               //"bAutoWidth": false,
               //"bPaginate": false,
               //"bStateSave": true // saves sort state using localStorage
               "bDestroy": true,

               "preDrawCallback": function () {
                   // Initialize the responsive datatables helper once.
                   if (!responsiveHelper_datatable_fixed_column) {
                       responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($NoConfi3('#ReportTableDedtn'), breakpointDefinition);
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
           $NoConfi("#ReportTableDedtn thead th input[type=text]").on('keyup change', function () {

               otable
                   .column($NoConfi(this).parent().index() + ':visible')
                   .search(this.value)
                   .draw();

           });
         
           }

          
           </script>

         
            <!-- SmartChat UI : plugin -->
   
     <script type="text/javascript">
         var confirmbox = 0;
         var confirmboxDepnt = 0;

         //SALARY DETAILS
         var confirmboxSalryPaygrd = 0;
         var confirmboxSalryAllwnce = 0;
         var confirmboxSalryDedctn = 0;
         function IncrmntConfrmCounter() {

             confirmbox++;
         }
         function IncrmntConfrmCounterDepnt() {

             confirmboxDepnt++;
         }

         function IncrmntConfrmCounterSalryPaygrd() {
             confirmboxSalryPaygrd++;
         }
         function IncrmntConfrmCounterSalryAllwnce() {
             confirmboxSalryAllwnce++;
         }
         function IncrmntConfrmCounterSalryDedctn() {
             confirmboxSalryDedctn++;
         }



         </script>
    <script type="text/javascript">
       function NumChecking(textboxid) {
            
            var txtPerVal = document.getElementById(textboxid).value;

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
                    textCounter(textboxid, 6);
                }
            }

           
       }

       function DisableEnter(evt) {

           evt = (evt) ? evt : window.event;
           var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
           if (keyCodes == 13) {
               return false;
           }
       }
    
       function RadioAmountClick() {

           document.getElementById('divperclk').style.display = "none";
           document.getElementById('divAmtClk').style.display = "block";
           IncrmntConfrmCounterSalryAllwnce();

       }
       function RadioPerClick() {
           document.getElementById('divperclk').style.display = "block";
           document.getElementById('divAmtClk').style.display = "none";
           IncrmntConfrmCounterSalryAllwnce();
       }

       function AmountChecking(textboxid) {
           IncrmntConfrmCounterSalryAllwnce();
           var txtPerVal = document.getElementById(textboxid).value;

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
                   var n = 0;
                   // for floatting number adjustment from corp global
                   var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);

                    }
                    document.getElementById('' + textboxid + '').value = n;

                }
            }

            addCommas(textboxid);
        }
        function isNumberSalary(evt, textboxid) {
            //  alert('a');
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //  alert(textboxid);
            // alert(keyCode);
            // var txtPerVal = document.getElementById(textboxid).value;
            // alert(txtPerVal);
            //enter
            //if(keyCodes==86||keyCodes==17)
            //    return true;
           
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40 ||keyCodes==118||keyCodes==17) {
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
                    if(keyCodes==118||keyCodes==17)
                        ret=true;
                }
                if(keyCodes==86||keyCodes==17 || keyCodes==67)
                    ret=true;
             
              
                return ret;
            }
        }
         </script>
       <script type="text/javascript">

           //SALARY DETAILS

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




                 if (isNaN(x2))
                     document.getElementById('' + textboxid + '').value = x1;
                     //return x1;
                 else
                     document.getElementById('' + textboxid + '').value = x1 + "." + x2;
                 // return x1 + "." + x2;

             }

    </script>
    <script type="text/javascript">
        function  RestrictionCalnAllownce()
        {
     
            IncrmntConfrmCounterSalryAllwnce();
            var AllwOrDed=1;
            var varddlAddtn = document.getElementById("<%=ddlAddtn.ClientID%>");
            var ddlAddtnText = varddlAddtn.options[varddlAddtn.selectedIndex].value;
            CheckForDupAllow(ddlAddtnText);
            if(ddlAddtnText!="--SELECT SALARY ADDITION--")
                CheckForRestriction(ddlAddtnText, AllwOrDed);
        }
        function RestrictionCalnDedcn()
        {
        
            IncrmntConfrmCounterSalryAllwnce();
            var AllwOrDed=2;
            var varddlAddtn = document.getElementById("<%=ddldedctn.ClientID%>");
            var ddlAddtnText = varddlAddtn.options[varddlAddtn.selectedIndex].value;
            //  alert(ddlAddtnText);
            CheckForDupDedctn(ddlAddtnText);
            if(ddlAddtnText!="--SELECT SALARY DEDUCTION--")
                CheckForRestriction(ddlAddtnText, AllwOrDed);
        }
        function CheckForDupAllow(x)
        {
          var EmpId=  document.getElementById("<%=HiddenEmployeeMasterId.ClientID%>").value;
         var PaygrdId=   document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value;
            var SalId = document.getElementById("<%=HiddenEmpSalryId.ClientID%>").value;
            var AlloId = 0;
            if (document.getElementById("<%=UpdateAddtn.ClientID%>").style.display == "none") {
                AlloId = 0;
            }
            else {
               
                AlloId = document.getElementById("<%=HiddenSalaryAllwceId.ClientID%>").value;
               
            }
            
            var AllowId =x;
            var Orgid = '<%=Session["ORGID"]%>';
            var CorpId = '<%=Session["CORPOFFICEID"]%>';

            var Details = PageMethods.CheckForDupAllow(EmpId,PaygrdId,SalId,AllowId, Orgid, CorpId,AlloId, function (response) {
                //  alert(response.Amnt);

                document.getElementById("<%=HiddenDuplChkAllow.ClientID%>").value = response;
                     //return true;
                 });
            
        }

        function CheckForDupDedctn(x) {
            var EmpId = document.getElementById("<%=HiddenEmployeeMasterId.ClientID%>").value;
            var PaygrdId = document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value;
            var SalId = document.getElementById("<%=HiddenEmpSalryId.ClientID%>").value;
            var DedctnId = x;
            var Orgid = '<%=Session["ORGID"]%>';
            var CorpId = '<%=Session["CORPOFFICEID"]%>';
            var AlloId = 0;
            if (document.getElementById("<%=UpdateDedctn.ClientID%>").style.display == "none") {
               
                AlloId = 0;
            }
            else {
        
                AlloId = document.getElementById("<%=HiddenSalaryDedctnId.ClientID%>").value;
            }
            var Details = PageMethods.CheckForDupDedctn(EmpId, PaygrdId, SalId, DedctnId, Orgid, CorpId,AlloId, function (response) {
                //  alert(response.Amnt);
                document.getElementById("<%=HiddenDuplChkDedctn.ClientID%>").value = response;
               
                 
                        //return true;
                    });

        }
    //    function UpdatePayGradePayGrade() {
                  
      //      LoadListPageallwnce();
                
                            
     //       LoadListPageallwnce();
         
     //       document.getElementById("<%=HiddenSalarSummry.ClientID%>").value = document.getElementById("<%=HiddenAmountRngeChk.ClientID%>").value;
       

        //  }

        function SuccessConfirmationAllwnce() {
            '<%Session["MESSGSALARY"] = "' + null + '"; %>';
          //  SuccessMsg("SAVE", "Salary allowance details inserted successfully.");
            $noCon1("#success-alert").html("Salary allowance details inserted successfully.");
            $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon1("#success-alert").alert();
            $noCon1(window).scrollTop(0);


        }



        function DuplicationSalaryAllwnce() {
           // "Duplication error.Salary allowance can't be duplicated.";
          //  SuccessMsg("SAVE", "Duplication error.Salary allowance can't be duplicated.");
            $noCon1("#success-alert").html("Duplication error.Salary allowance can't be duplicated.");
            $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon1("#success-alert").alert();
            $noCon1(window).scrollTop(0);
        }
        function SuccessCancelationAllwnce() {
            // "Allowance cancelled successfully.";
            '<%Session["MESSGSALARY"] = "' + null + '"; %>';
            //SuccessMsg("SAVE", "Allowance cancelled successfully.");
            $noCon1("#success-alert").html("Allowance cancelled successfully.");
            $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon1("#success-alert").alert();
            $noCon1(window).scrollTop(0);
        }
        function UpdatePayGradeAllwnce(x) {
         
            '<%Session["MESSGSALARY"] = "' + null + '"; %>';
      
          //  SuccessMsg("SAVE", "Allowance details updated successfully.");
            $noCon1("#success-alert").html("Allowance details updated successfully.");
            $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon1("#success-alert").alert();
            $noCon1(window).scrollTop(0);
      
        }
        function ClearAddition() {
            document.getElementById("<%=ddlAddtn.ClientID%>").selectedIndex = 0;
            document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value = "";

        }
        function AlertClearAddition() {
            if (confirmboxSalryAllwnce > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want clear all data in this section?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                       

                            document.getElementById("<%=ddlAddtn.ClientID%>").selectedIndex = 0;
                            document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value = "";

                            document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "block";
                            document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "none";
                                return true;
                            
                            //window.location = href;

                        }
                        else {
                        return false;

                        }
                    });
               // if (confirm("Are you sure you want clear all data in this section?")) {
                    // window.location.href = "gen_Bank_Guarantee.aspx";
                   // document.getElementById("<%=ddlAddtn.ClientID%>").selectedIndex = 0;
                   // document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value = "";

                  //  document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "block";
                   // document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "none";
                   // return false;
                //}
              //  else {
                //    return false;
               // }
            }
            else {
                //window.location.href = "gen_Bank_Guarantee.aspx";
                document.getElementById("<%=ddlAddtn.ClientID%>").selectedIndex = 0;
                document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value = "";

                document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "block";
                document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "none";
                return false;
            }
            return false;
        }


        function ValidateAllwnce() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value = replaceText2;



            var NameWithoutReplace = document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value;
              var AmntFrom = NameWithoutReplace.replace(/,/g, "");

              document.getElementById("<%=txtAmntRgeFrm.ClientID%>").style.borderColor = "";

            document.getElementById("<%=txtAmntRgeFrm.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlAddtn.ClientID%>").style.borderColor = "";
              // var AmntFrom = document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value.trim();


              var varddlAddtn = document.getElementById("<%=ddlAddtn.ClientID%>");
              var ddlAddtnText = varddlAddtn.options[varddlAddtn.selectedIndex].text;


              //Check for restriction AllwOrDed :0-SALRY RESTRCTION CHECK,1-ALLOWANCE RESTRCTION CHECK,2-DEDCTION RESTRCTION CHECK
              var RestrctedChk = 0, Restrcted = 0, AllwOrDed = 1;
              var RestrFrm, RestrTo;
              if (AmntFrom == "") {
                //  SuccessMsg("SAVE", "Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                  $noCon1("#success-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                  $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                  });
                  $noCon1("#success-alert").alert();
                  $noCon1(window).scrollTop(0);
              // "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtAmntRgeFrm.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtAmntRgeFrm.ClientID%>").focus();
                ret = false;
            }
            else {

                document.getElementById("<%=txtAmntRgeFrm.ClientID%>").style.borderColor = "";
            }

            if (AmntFrom != "") {

                if (ddlAddtnText != "--SELECT SALARY ADDITION--") {
                    var ddlAddtnValue = varddlAddtn.options[varddlAddtn.selectedIndex].value;

                    document.getElementById("<%=HiddenddlAllDed.ClientID%>").value = ddlAddtnValue;

                    // CheckForRestriction(ddlAddtnValue, AllwOrDed);
                    var RestrctnChk = document.getElementById("<%=HiddenRestrctRangeAllw.ClientID%>").value;
                 
                    RestrctnChk = RestrctnChk.split(",");

                    if (RestrctnChk != "") {
                        RestrFrm = RestrctnChk[0];
                        RestrTo = RestrctnChk[1];
                        Restrcted = RestrctnChk[2];

                        if (parseFloat(AmntFrom) < parseFloat(RestrFrm) || parseFloat(AmntFrom) > parseFloat(RestrTo)) {
                            RestrctedChk = 0;
                        }
                        else {

                            RestrctedChk = 1;
                        }

                    }

                }
            }


            if (RestrctedChk == 0) {
                if (Restrcted == 1) {
                  //  SuccessMsg("SAVE", "Amount should be in restricted range.");

                    $noCon1("#success-alert").html("Amount should be in restricted range.");
                    $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    $noCon1("#success-alert").alert();
                      $noCon1(window).scrollTop(0);
                   // "Amount should be in restricted range";
                    document.getElementById("<%=txtAmntRgeFrm.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtAmntRgeFrm.ClientID%>").focus();
                    ret = false;
                }
                if (Restrcted == 0) {

                }
            }

            if (ddlAddtnText == "--SELECT SALARY ADDITION--") {
               // SuccessMsg("SAVE", "Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon1("#success-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon1("#success-alert").alert();
                  $noCon1(window).scrollTop(0);
           //"Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlAddtn.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlAddtn.ClientID%>").focus();
                ret = false;
            }
            else
            {
                var ddlAddtnValues = varddlAddtn.options[varddlAddtn.selectedIndex].value;

                document.getElementById("<%=HiddenddlAllDed.ClientID%>").value = ddlAddtnValues;
            }
            if (document.getElementById("<%=HiddenDuplChkAllow.ClientID%>").value == 1) {
              
              //  SuccessMsg("SAVE", "Duplication error.Salary allowance can't be duplicated.");

                $noCon1("#success-alert").html("Duplication error.Salary allowance can't be duplicated.");
                $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon1("#success-alert").alert();
                  $noCon1(window).scrollTop(0);
             // "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
             document.getElementById("<%=ddlAddtn.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlAddtn.ClientID%>").focus();
             ret = false;
         }
        
            CheckSubmitZero();
            return ret;
        }

        

    </script>
    <script type="text/javascript">
        function SuccessConfirmationDedctn(x) {
            '<%Session["MESSGSALARY"] = "' + null + '"; %>';
           //"Salary deduction details inserted successfully.";
            //SuccessMsg("SAVE", "Salary deduction details inserted successfully.");
            $noCon1("#success-alert").html("Salary deduction details inserted successfully.");
            $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon1("#success-alert").alert();
              $noCon1(window).scrollTop(0);
              
           // $(window).scrollTop(0);
        }
        function DuplicationSalaryDedctn() {
          //  SuccessMsg("SAVE", "Duplication error.Salary allowance can't be duplicated.");
            //"Duplication error.Salary deduction can't be duplicated.";

            $noCon1("#success-alert").html("Duplication error.Salary allowance can't be duplicated.");
            $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon1("#success-alert").alert();
             $noCon1(window).scrollTop(0);
            document.getElementById("<%=ddldedctn.ClientID%>").style.borderColor = "Red";
         
          
            $noCon1(window).scrollTop(0);
        }
        function SuccessCancelationDedctn() {
            //"Deduction cancelled successfully.";
            '<%Session["MESSGSALARY"] = "' + null + '"; %>';
           // SuccessMsg("SAVE", "Deduction cancelled successfully.");


            $noCon1("#success-alert").html("Deduction cancelled successfully.");
            $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon1("#success-alert").alert();
             $noCon1(window).scrollTop(0);
            // document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value = x;
         //   ClearDedAll();
          //  LoadListPageallwnce();
            // LoadListPageDed();
            // LoadddlAllwncededctn();
         
         
          //  $(window).scrollTop(0);
        }
        function UpdatePayGradeDedctn(x) {
            '<%Session["MESSGSALARY"] = "' + null + '"; %>';
            //"Deduction details updated successfully.";
           // SuccessMsg("SAVE", "Deduction details updated successfully.");
            $noCon1("#success-alert").html("Deduction details updated successfully.");
            $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon1("#success-alert").alert();
             $noCon1(window).scrollTop(0);
             
            
          
           // $(window).scrollTop(0);
        }
        function AlertClearDedAll() {
            if (confirmboxSalryAllwnce > 0) {

                ezBSAlert({
                    type: "confirm",
                    messageText: "Are You Sure You Want Clear All Data In This Section?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                     

                            document.getElementById("<%=ddldedctn.ClientID%>").selectedIndex = 0;
                            document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value = "";


                            document.getElementById("<%=txtperctg.ClientID%>").value = "";


                            document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = true;
                            document.getElementById("<%=radPercntge.ClientID%>").checked = true;

                            document.getElementById("<%=SaveDedctn.ClientID%>").style.display = "block";
                            document.getElementById("<%=UpdateDedctn.ClientID%>").style.display = "none";
                            RadioPerClick();

                                return false;
                            
                            //window.location = href;

                        }
                        else {
                        return false;

                        }
                    });
            
            }
            else {
                //window.location.href = "gen_Bank_Guarantee.aspx";
                document.getElementById("<%=ddldedctn.ClientID%>").selectedIndex = 0;
                document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value = "";


                document.getElementById("<%=txtperctg.ClientID%>").value = "";


                document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = true;
                document.getElementById("<%=radPercntge.ClientID%>").checked = true;

                document.getElementById("<%=SaveDedctn.ClientID%>").style.display = "block";
                document.getElementById("<%=UpdateDedctn.ClientID%>").style.display = "none";
                RadioPerClick();
                return false;
            }
            return false;
        }

        function ClearDedAll() {
            document.getElementById("<%=ddldedctn.ClientID%>").selectedIndex = 0;
            document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value = "";
            document.getElementById("<%=txtperctg.ClientID%>").value = "";

            document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = true;
            document.getElementById("<%=radPercntge.ClientID%>").checked = true;
            RadioPerClick();

        }
        //SALARY DETAILS
        function ValidateDedctn(buttnId) {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            
            var NameWithoutReplace = document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value = replaceText2;


            var NameWithoutReplace = document.getElementById("<%=txtperctg.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtperctg.ClientID%>").value = replaceText2;


            var NameWithoutReplace = document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value;
            var AmntFrom = NameWithoutReplace.replace(/,/g, "");


            var NameWithoutReplace = document.getElementById("<%=txtperctg.ClientID%>").value;
            var Perctge = NameWithoutReplace.replace(/,/g, "");

            document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").style.borderColor = "";
                document.getElementById("<%=ddldedctn.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtperctg.ClientID%>").style.borderColor = "";
          
         


            var varddlAddtn = document.getElementById("<%=ddldedctn.ClientID%>");
            var ddlDedctnText = varddlAddtn.options[varddlAddtn.selectedIndex].text;

          


            //Check for restriction AllwOrDed :0-SALRY RESTRCTION CHECK,1-ALLOWANCE RESTRCTION CHECK,2-DEDCTION RESTRCTION CHECK
            var RestrctedChk = 0, Restrcted = 0, AllwOrDed = 2;
            var RestrFrm, RestrTo;
            if (document.getElementById("<%=radAmnt.ClientID%>").checked == true) {
                if (AmntFrom == "") {

                  
                  

   
                   
                        document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").focus();
                   // SuccessMsg("SAVE", "Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon1("#success-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    $noCon1("#success-alert").alert();
                      $noCon1(window).scrollTop(0);

                        ret = false;
                    }
                    else {

                        document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").style.borderColor = "";
                    }

                    if (AmntFrom != "") {

                        if (ddlDedctnText != "--SELECT SALARY DEDUCTION--") {
                            var ddlAddtnValue = varddlAddtn.options[varddlAddtn.selectedIndex].value;

                            document.getElementById("<%=HiddenddlAllDed.ClientID%>").value = ddlAddtnValue;
                           
                    
                        // CheckForRestriction(ddlAddtnValue, AllwOrDed);
                        var RestrctnChk = document.getElementById("<%=HiddenRestrctRangeDedctn.ClientID%>").value;
                        RestrctnChk = RestrctnChk.split(",");

                        if (RestrctnChk != "") {
                            RestrFrm = RestrctnChk[0];
                            RestrTo = RestrctnChk[1];
                            Restrcted = RestrctnChk[2];

                            if (parseFloat(AmntFrom) > parseFloat(RestrFrm) || parseFloat(AmntFrom) < parseFloat(RestrTo)) {
                                RestrctedChk = 0;
                            }
                            else {

                                RestrctedChk = 1;
                            }

                        }

                    }
                }


                if (RestrctedChk == 0) {
                    if (Restrcted == 1) {
                        //SuccessMsg("SAVE", "Amount should be in restricted range");

                        $noCon1("#success-alert").html("Amount should be in restricted range");
                        $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                        });
                        $noCon1("#success-alert").alert();
                          $noCon1(window).scrollTop(0);
                      // "Amount should be in restricted range";
                        document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").focus();
                        ret = false;
                    }
                    if (Restrcted == 0) {

                    }
                }




            }
            else if (document.getElementById("<%=radPercntge.ClientID%>").checked == true) {
                if (Perctge == "") {
                   // SuccessMsg("SAVE", "Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon1("#success-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    $noCon1("#success-alert").alert();
                    $noCon1(window).scrollTop(0);
                // "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById("<%=txtperctg.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtperctg.ClientID%>").focus();
                        ret = false;
                    }
                    else
                    {
                        if (parseFloat(Perctge) > parseFloat(100))
                        {
                           // SuccessMsg("SAVE", "Percentage should not exceed hundred.");
                            $noCon1("#success-alert").html("Percentage should not exceed hundred.");
                            $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                            });
                            $noCon1("#success-alert").alert();
                            $noCon1(window).scrollTop(0);
                          // "Percentage should not exceed hundred.";
                        document.getElementById("<%=txtperctg.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtperctg.ClientID%>").focus();
                        ret = false;
                    }
                    else
                    {
                        var perTotalChek=0;
                     
                        var PerTotal= parseFloat(document.getElementById("<%=HiddenTotalPerTotal.ClientID%>").value);
                      
                        var PerBasic= parseFloat(document.getElementById("<%=HiddenTotalPerBasic.ClientID%>").value);
                      
                     
                        if(buttnId=='UpdateDedctn')
                        {
                            
                            perTotalChek=parseFloat(PerTotal)+parseFloat(PerBasic)-parseFloat(Perctge) ;
                           
                        }
                        else if(buttnId=='SaveDedctn')
                        {
                           
                            perTotalChek=parseFloat(PerTotal)+parseFloat(PerBasic)+parseFloat(Perctge) ;
                           
                        }
                        if(parseFloat(perTotalChek)>parseFloat(100))
                        {
                         //   SuccessMsg("SAVE", "Sum of percentage in deduction should be less than or equal to hundred.");
                            $noCon1("#success-alert").html("Sum of percentage in deduction should be less than or equal to hundred.");
                            $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                            });
                            $noCon1("#success-alert").alert();
                            $noCon1(window).scrollTop(0);
                    //"Sum of percentage in deduction should be less than or equal to hundred.";
                            document.getElementById("<%=txtperctg.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtperctg.ClientID%>").focus();
                            ret = false;
                        }
                    }
                }
            }
           
        if (ddlDedctnText == "--SELECT SALARY DEDUCTION--") {


            document.getElementById("<%=HiddenddlAllDed.ClientID%>").value = ddlAddtnValue;
            //SuccessMsg("SAVE", "Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
            $noCon1("#success-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
            $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon1("#success-alert").alert();
            $noCon1(window).scrollTop(0);
            // "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
            document.getElementById("<%=ddldedctn.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=ddldedctn.ClientID%>").focus();
            ret = false;
        }
        else {
            var ddlAddtnValues = varddlAddtn.options[varddlAddtn.selectedIndex].value;

            document.getElementById("<%=HiddenddlAllDed.ClientID%>").value = ddlAddtnValues;
        }
            if (document.getElementById("<%=HiddenDuplChkDedctn.ClientID%>").value == 1)
            {
               
               // SuccessMsg("SAVE", "Duplication error.Salary deduction can't be duplicated.");
                $noCon1("#success-alert").html("Duplication error.Salary deduction can't be duplicated.");
                $noCon1("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon1("#success-alert").alert();
                $noCon1(window).scrollTop(0);
                // "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddldedctn.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddldedctn.ClientID%>").focus();
                ret = false;
            }
   
                CheckSubmitZero();
                return ret;

            }
            function CheckForRestriction(ddlAddtnValue, AllwOrDed) {
       
                var Orgid = '<%=Session["ORGID"]%>';
                var CorpId =  '<%=Session["CORPOFFICEID"]%>';

            var Details = PageMethods.CheckForRestriction(ddlAddtnValue, Orgid, CorpId, AllwOrDed, function (response) {
                //  alert(response.Amnt);
              
                
                if (AllwOrDed == "0")
                {
                    document.getElementById("<%=HiddenRestrctRange.ClientID%>").value = response.Amnt;
                    document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value = response.strCurrcAbbrv;
                    
                }
                if (AllwOrDed == "1")
                {
                    document.getElementById("<%=HiddenRestrctRangeAllw.ClientID%>").value = response.Amnt;
                         
                    
                }
                if (AllwOrDed == "2")
                {
                    document.getElementById("<%=HiddenRestrctRangeDedctn.ClientID%>").value = response.Amnt;
                      
                    
                }
                //return true;
            });
      
        }
        function LoadddlAllwncededctn() {

            var $Mo = jQuery.noConflict();
         //   var varddlAddtn =  document.getElementById("<%=HiddenPaygrdId.ClientID%>").value;
               
            var ddlpygdeValue = document.getElementById("<%=HiddenPaygrdId.ClientID%>").value;
                //varddlAddtn.options[varddlAddtn.selectedIndex].value;
            
            var Orgid = '<%=Session["ORGID"]%>';
                //document.getElementById("<%=HiddenOrgId.ClientID%>").value;
        
            var CorpId = '<%=Session["CORPOFFICEID"]%>';
                //document.getElementById("<%=HiddenCorpId.ClientID%>").value;
          
            var tableName = "dtTableAllwnce";
            var Details = PageMethods.Loadallwceddl(ddlpygdeValue, Orgid, CorpId, function (response) {


                var OptionStart = $Mo("<option>--SELECT SALARY ADDITION--</option>");

                OptionStart.attr("value", 0);
                $Mo('#<%=ddlAddtn.ClientID%>').empty();
                   $Mo('#<%=ddlAddtn.ClientID%>').append(OptionStart);

                   // Now find the Table from response and loop through each item (row).
                   $Mo(response).find(tableName).each(function () {
                       // Get the OptionValue and OptionText Column values.
                       var OptionValue = $Mo(this).find('PGALLCE_ID').text();
                       var OptionText = $Mo(this).find('PAYRL_NAME').text();
                       // Create an Option for DropDownList.
                       var option = $Mo("<option>" + OptionText + "</option>");
                       option.attr("value", OptionValue);
                       $Mo('#<%=ddlAddtn.ClientID%>').append(option);

            });
                   // return false;
               });
        LoadDedctionddl();
    }

    function LoadDedctionddl() {

        var $Mo = jQuery.noConflict();
       // var varddlAddtn = document.getElementById("<%=HiddenPaygrdId.ClientID%>").value;
        var ddlpygdeValue = document.getElementById("<%=HiddenPaygrdId.ClientID%>").value;
            //varddlAddtn.options[varddlAddtn.selectedIndex].value;
        var Orgid = '<%=Session["ORGID"]%>';
        var CorpId = '<%=Session["CORPOFFICEID"]%>';
               var tableName = "dtTableDedctn";
               var Details = PageMethods.LoadDedctionddl(ddlpygdeValue, Orgid, CorpId, function (response) {


                   var OptionStart = $Mo("<option>--SELECT SALARY DEDUCTION--</option>");

                   OptionStart.attr("value", 0);
                   $Mo('#<%=ddldedctn.ClientID%>').empty();
                   $Mo('#<%=ddldedctn.ClientID%>').append(OptionStart);

                   // Now find the Table from response and loop through each item (row).
                   $Mo(response).find(tableName).each(function () {
                       // Get the OptionValue and OptionText Column values.
                       var OptionValue = $Mo(this).find('PGDEDTN_ID').text();
                       var OptionText = $Mo(this).find('PAYRL_NAME').text();
                       // Create an Option for DropDownList.
                       var option = $Mo("<option>" + OptionText + "</option>");

                       option.attr("value", OptionValue);

                       $Mo('#<%=ddldedctn.ClientID%>').append(option);

                });
                   // return false;
               });
        }

        function LoadListPageallwnce() {
               
          
            var toatlpay=0;
            var EnableCanl = document.getElementById("<%=HiddnEnableCacel.ClientID%>").value;
          
                var CurrcyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
          
            var OrgId = '<%=Session["ORGID"]%>';
         
            var CorpId = '<%=Session["CORPOFFICEID"]%>';
         
                var varddlAddtn = document.getElementById("<%=HiddenEmployeeMasterId.ClientID%>").value;
            var salProssId =  document.getElementById("<%=HiddenEmpSalryId.ClientID%>").value;

            var Details = PageMethods.LoadListPageallwncee(EnableCanl, CurrcyId, CorpId, OrgId, varddlAddtn,salProssId, function (response) {

                    // alert(response);
                    //  reporttable();

                    document.getElementById('cphMain_divAllwList').innerHTML = response.strhtml;
               
                    //document.getElementById('SumryAdtnRng').innerHTML = response.strSummry;
                    // parseFloat(document.getElementById("<%=HiddenTotalpay.ClientID%>").value);
                    if (response.strSummry != "") {
                   
                        var n,n1;
                        var num = response.strSummry;
                        var sumry = num;
                        var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

                    if (FloatingValue != "") {
                        sumry = sumry.replace(/,/g, "");
                          
                        n = parseFloat(sumry).toFixed(FloatingValue);
                        toatlpay= parseFloat(n);
                        addCommasSummry(n);
                        n = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                          
                          
                          
                    }
                    document.getElementById('SumryAdtnRng').innerHTML = n + "  " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
                   
                    // alert(toatlpay+"1s");
                    document.getElementById("<%=HiddenTotalpay.ClientID%>").value=toatlpay;
                    LoadListPageDed();
                          
                        
                }
                else {
                    document.getElementById('SumryAdtnRng').innerHTML = response.strSummry;
                    document.getElementById("<%=HiddenTotalpay.ClientID%>").value=toatlpay;
                }
               
                    var Finaltotalpay=document.getElementById("<%=HiddenSalarSummry.ClientID%>").value;
           
                    //  Finaltotalpay=Finaltotalpay.replace(/,/g, "");
                    // Finaltotalpay=parseFloat(Finaltotalpay)+parseFloat(document.getElementById("<%=HiddenTotalpay.ClientID%>").value);
         
                    // document.getElementById('SumryTotalpay').innerHTML =Finaltotalpay+" "+document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;;
                    // alert( document.getElementById("<%=HiddenTotalpay.ClientID%>").value);
                });
              //  waitSeconds(100);
                // setTimeout(LoadListPageDed(),5000);
                LoadListPageDed();
            }

            function LoadListPageDed() {
                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                var basicpay=parseFloat(document.getElementById("<%=HiddenSalarSummry.ClientID%>").value);
           
                var toatlpay=0,vardedctn=0;
                var EnableCanl = document.getElementById("<%=HiddnEnableCacel.ClientID%>").value;
            var CurrcyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
                var OrgId = '<%=Session["ORGID"]%>';
                var CorpId = '<%=Session["CORPOFFICEID"]%>';
                var varddlAddtn = document.getElementById("<%=HiddenEmployeeMasterId.ClientID%>").value;
                var salProssId = document.getElementById("<%=HiddenEmpSalryId.ClientID%>").value;
                var deddctionamount = 0;
                var Details = PageMethods.LoadListPageDed(EnableCanl, CurrcyId, CorpId, OrgId, varddlAddtn,salProssId, function (response) {

                    // alert(response);
                    // reporttables();


                    document.getElementById('cphMain_divList').innerHTML = response.strhtml;
                 
                    document.getElementById("<%=HiddenTotalPerTotal.ClientID%>").value=response.strPerFromTotal;
                document.getElementById("<%=HiddenTotalPerBasic.ClientID%>").value=response.strPerFromBasic;
               
              
                //document.getElementById('SumryDedctnRng').innerHTML = response.strSummry;
           
                //=parseFloat(document.getElementById("<%=HiddenTotalpay.ClientID%>").value);
                
            
                if (response.strSummry != "") {
                    var n,n1;
                    var num = response.strSummry;
                    var sumry = num;
                    FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    deddctionamount = sumry;
                    if (FloatingValue != "") {
                        sumry = sumry.replace(/,/g, "");
                        vardedctn=sumry;
                        n = parseFloat(sumry).toFixed(FloatingValue);
                        toatlpay = parseFloat(n);
                       // deddctionamount = toatlpay;
                        addCommasSummry(n);
                        n = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                          
                        // Substractdedctn(vardedctn);
                          
                    }
                    document.getElementById('SumryDedctnRng').innerHTML = n + "  " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
                    Substractdedctn(vardedctn);
                 
                    // alert(parseFloat(n));
                  
                    //alert(toatlpay);
                    document.getElementById("<%=HiddenTotalpayAllw.ClientID%>").value=parseFloat(0)+toatlpay;
                }
                else {
                   
                    document.getElementById('SumryDedctnRng').innerHTML = response.strSummry;
                    document.getElementById("<%=HiddenTotalpayAllw.ClientID%>").value=parseFloat(toatlpay)+parseFloat(0);
                }
                    LoadEmpList();
                //DataTable
                //  ReportTable
            });
                // waitSeconds(100);
            var Finaltotalpay=document.getElementById("<%=HiddenSalarSummry.ClientID%>").value;
          
            
                Finaltotalpay=parseFloat(Finaltotalpay)+parseFloat(document.getElementById("<%=HiddenTotalpay.ClientID%>").value);
            
                // alert(document.getElementById("<%=HiddenTotalpayAllw.ClientID%>").value+"sustractn");
                Finaltotalpay=parseFloat(Finaltotalpay)- parseFloat(document.getElementById("<%=HiddenTotalpayAllw.ClientID%>").value);
                Finaltotalpay=parseFloat(Finaltotalpay)- parseFloat(document.getElementById("<%=HiddenTotalpayAllw.ClientID%>").value);
                var PerTotal= parseFloat(document.getElementById("<%=HiddenTotalPerTotal.ClientID%>").value);
                var PerBasic= parseFloat(document.getElementById("<%=HiddenTotalPerBasic.ClientID%>").value);
                var totalpercentage=0;
                if(PerTotal!=0)
                {
              
                    PerTotal=parseFloat(PerTotal)/100;
             
                    PerTotal=Finaltotalpay*PerTotal;
                    Finaltotalpay=Finaltotalpay-PerTotal;
           
                    totalpercentage=parseFloat(totalpercentage)+PerTotal;
             
              
                }
                if(PerBasic!=0)
                {
            
                    PerBasic=parseFloat(PerBasic)/100;
             
                    PerBasic=parseFloat(basicpay)*PerBasic;
                    Finaltotalpay=Finaltotalpay-PerBasic;
                    totalpercentage=parseFloat(totalpercentage)+PerBasic;
              
                }
          
                var a = parseFloat(Finaltotalpay).toFixed(FloatingValue);
              //  a = parseFloat(a) - parseFloat(deddctionamount);
                toatlpay = parseFloat(a);
              
                addCommasSummry(a);
                a = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                // alert(Finaltotalpay+"substarcted val");
            document.getElementById('SumryTotalpay').innerHTML =a+" "+document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;

                totalpercentage=parseFloat(totalpercentage)+parseFloat(vardedctn);
                var b = parseFloat(totalpercentage).toFixed(FloatingValue);
                toatlpay= parseFloat(b);
                addCommasSummry(b);
                b = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                // if(b!=0)
            document.getElementById("SumryDedctnRng").innerHTML= b + "  " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
          
               
           
            }


            function Substractdedctn(vardedctn)
            {
                
                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var Finaltotalpay=document.getElementById("<%=HiddenSalarSummry.ClientID%>").value;
            var basicpay=parseFloat(document.getElementById("<%=HiddenSalarSummry.ClientID%>").value);
             
            Finaltotalpay=parseFloat(Finaltotalpay)+parseFloat(document.getElementById("<%=HiddenTotalpay.ClientID%>").value);
             
               

                Finaltotalpay = parseFloat(Finaltotalpay)
                    //- parseFloat(document.getElementById("<%=HiddenTotalpayAllw.ClientID%>").value);
             
               // alert(Finaltotalpay);
            
            var PerTotal= parseFloat(document.getElementById("<%=HiddenTotalPerTotal.ClientID%>").value);
            var PerBasic= parseFloat(document.getElementById("<%=HiddenTotalPerBasic.ClientID%>").value);
            var totalpercentage=0;
            if(PerTotal!=0)
            {
               
                PerTotal=parseFloat(PerTotal)/100;
              
                PerTotal = Finaltotalpay * PerTotal;
            
                Finaltotalpay=Finaltotalpay-PerTotal;
           
                totalpercentage=parseFloat(totalpercentage)+PerTotal;
               

            }
            if(PerBasic!=0)
            {
            
                PerBasic=parseFloat(PerBasic)/100;
             
                PerBasic=basicpay*PerBasic;
                
                Finaltotalpay=parseFloat(Finaltotalpay)-PerBasic;
             
                totalpercentage=parseFloat(totalpercentage)+PerBasic;
              
            }
            var n = parseFloat(Finaltotalpay).toFixed(FloatingValue);
            n = n - parseFloat(document.getElementById("<%=HiddenTotalpayAllw.ClientID%>").value);
                n = parseFloat(n).toFixed(FloatingValue);
            toatlpay= parseFloat(n);
            addCommasSummry(n);
            n = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
            
            document.getElementById('SumryTotalpay').innerHTML =n+" "+document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
            totalpercentage=parseFloat(totalpercentage)+parseFloat(vardedctn);
          
            var b = parseFloat(totalpercentage).toFixed(FloatingValue);
            toatlpay= parseFloat(b);
            addCommasSummry(b);
            b = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
           
            // if(b!="0")
            document.getElementById('SumryDedctnRng').innerHTML= b + "  " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;

          

        }
        function ChangeStatus(CatId, CatStatus, AllwOrDed) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to process the monthly salary?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                  

                        var OrgId = '<%=Session["ORGID"]%>';
                        var CorpId = '<%=Session["CORPOFFICEID"]%>';

                        var Details = PageMethods.ChangeContractStatus(CatId, CatStatus, AllwOrDed, OrgId, CorpId, function (response) {
                            var SucessDetails = response;

                            if (SucessDetails == "success") {
                                // window.location = 'gen_Pay_Grade_Master.aspx?InsUpd=StsCh';
                                //reporttable();
                                SuccessChangeStatus();
                                LoadListPageallwnce();
                                // LoadListPageDed();
                            }
                            else {
                                // window.location = 'gen_Pay_Grade_Master_List.aspx?InsUpd=Error';
                            }
                        });

                                return true;
                            
                            //window.location = href;

                        }
                        else {
                    return false;

                        }
                    });
      
        }
        function getdetailsAllwceById(x) {
                      

            var OrgId = '<%=Session["ORGID"]%>';
            var CorpId = '<%=Session["CORPOFFICEID"]%>';
            document.getElementById("<%=ddlAddtn.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAmntRgeFrm.ClientID%>").style.borderColor = "";
            var Details = PageMethods.ReadAllwceById(x, CorpId, OrgId, function (response) {

                document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value = response.FrmAmount;

                // document.getElementById("<%=ddlAddtn.ClientID%>").value = response.ddlselectedVal;

                if (response.ddlBinding == 0) {
                    document.getElementById("<%=ddlAddtn.ClientID%>").value = response.ddlselectedVal;
                }
                else if (response.ddlBinding == 1) {
                    var $Mo = jQuery.noConflict();
                    var newOption = "<option value='" + response.ddlselectedVal + "'>" + response.ddltext + "</option>";

                    $Mo('#<%=ddlAddtn.ClientID%>').append(newOption);
                    //SORTING DDL
                    var options = $Mo("#<%=ddlAddtn.ClientID%> option");                    // Collect options         
                    options.detach().sort(function (a, b) {               // Detach from select, then Sort
                        var at = $Mo(a).text();
                        var bt = $Mo(b).text();
                        return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                    });
                    options.appendTo('#<%=ddlAddtn.ClientID%>');
                    document.getElementById("<%=ddlAddtn.ClientID%>").value = response.ddlselectedVal;

                }
                
                document.getElementById("<%=HiddenSalaryAllwceId.ClientID%>").value = response.SalaryAllwceId;

                document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value = response.PaygrdId;

                document.getElementById("<%=HiddenddlAllDed.ClientID%>").value = response.ddlselectedVal;
                document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "none";
                document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "block";
                var AllwOrDed = 1;
                document.getElementById("<%=ddlAddtn.ClientID%>").focus();
                CheckForDupAllow(response.ddlselectedVal);
                CheckForRestriction( response.ddlselectedVal,AllwOrDed);

            });
            return false;
        }

        function CancelAlertAllwceById(x, AllwOrDed) {


            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to cancel this entry?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=HiddenDelChk.ClientID%>").value = AllwOrDed;
                    document.getElementById("<%=hiddenRsnid.ClientID%>").value = x;
                    var userId = document.getElementById("<%=HiddenEmployeeMasterId.ClientID%>").value;
                    var CorpId = '<%=Session["CORPOFFICEID"]%>';
                    var Details = PageMethods.CancelAlertAllwceById(x, userId, CorpId, AllwOrDed, function (response) {

                        LoadListPageallwnce();
                        // LoadListPageDed();

                        if (response == 1) {
                            //OpenCancelView();
                            SuccessCancelationDedctn();
                        }
                        else if (response == 0) {

                            SuccessCancelationAllwnce();
                        }

                    });
                            //window.location = href;
                    return true;
                        }
                        else {

                    return false;
                        }
                    });
         
          
                return false;
            

        }

        function getdetailsDedctnById(x) {

            var OrgId = '<%=Session["ORGID"]%>';
            var CorpId = '<%=Session["CORPOFFICEID"]%>';
            document.getElementById("<%=ddldedctn.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").style.borderColor = "";
            var Details = PageMethods.ReadDedctnId(x, CorpId, OrgId, function (response) {

                document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value = response.FrmAmount;

                if (response.ddlBinding == 0) {
                    document.getElementById("<%=ddldedctn.ClientID%>").value = response.ddlselectedVal;
                }
                else if (response.ddlBinding == 1) {

                    var $Mo = jQuery.noConflict();
                    var newOption = "<option value='" + response.ddlselectedVal + "'>" + response.ddltext + "</option>";

                    $Mo('#<%=ddldedctn.ClientID%>').append(newOption);
                    //SORTING DDL
                    var options = $Mo("#<%=ddldedctn.ClientID%> option");                    // Collect options         
                    options.detach().sort(function (a, b) {               // Detach from select, then Sort
                        var at = $Mo(a).text();
                        var bt = $Mo(b).text();
                        return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                    });
                    options.appendTo('#<%=ddldedctn.ClientID%>');
                    document.getElementById("<%=ddldedctn.ClientID%>").value = response.ddlselectedVal;

                }
              
                if (response.BasicOrTotl == 1) {

                    document.getElementById("<%=radioBascPay.ClientID%>").checked = false;
                    document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = true;
                }
                else {
                    document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = false;
                    document.getElementById("<%=radioBascPay.ClientID%>").checked = true;
                }
                if (response.PerOrAmntck == 1) {
                    document.getElementById("<%=txtperctg.ClientID%>").value = response.strperct;
                    document.getElementById("<%=radPercntge.ClientID%>").checked = true;
                    document.getElementById("<%=radAmnt.ClientID%>").checked = false;
                    RadioPerClick();
                }
                else {

                    document.getElementById("<%=radAmnt.ClientID%>").checked = true;
                    document.getElementById("<%=radPercntge.ClientID%>").checked = false;
                    RadioAmountClick();
                }
                document.getElementById("<%=HiddenSalaryDedctnId.ClientID%>").value = response.SalaryAllwceId;



                document.getElementById("<%=HiddenddlAllDed.ClientID%>").value = response.ddlselectedVal;

                document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value = response.PaygrdId;
                document.getElementById("<%=SaveDedctn.ClientID%>").style.display = "none";
                document.getElementById("<%=UpdateDedctn.ClientID%>").style.display = "block";
                var AllwOrDed = 2;
                document.getElementById("<%=ddldedctn.ClientID%>").focus();
                CheckForDupDedctn(response.ddlselectedVal);
                CheckForRestriction( response.ddlselectedVal,AllwOrDed);
            });
            return false;


        }

    </script>
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
            // onclick = "location.href='hcm_Monthly_Salary_Process.aspx'"
         
            function ConfirmCancel1() {
                if ( confirmboxSalryAllwnce > 0 || confirmboxSalryDedctn>0)
                    ConfirmMessage("hcm_Monthly_Salary_Process.aspx");
                else
                    window.location.href = "hcm_Monthly_Salary_Process.aspx";
                return false;
            }
            function RadioopenClick()
            {
                IncrmntConfrmCounterSalryAllwnce();
            }

            function RadioLimitedClick() {
                IncrmntConfrmCounterSalryAllwnce();
            }
    </script>
      
       
      
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
     <asp:HiddenField ID="HiddenDuplChkAllow" runat="server" /> 
     <asp:HiddenField ID="HiddenDuplChkDedctn" runat="server" />
      <asp:HiddenField ID="HiddenDelChk" runat="server" />
       <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <asp:HiddenField ID="HiddenSalaryAllwceId" runat="server" />
        <asp:HiddenField ID="HiddenTotalpayAllw" runat="server" />
    <asp:HiddenField ID="HiddnEnableCacel" runat="server" />
          <asp:HiddenField ID="HiddenEmployeeMasterId" runat="server" />
        <asp:HiddenField ID="HiddenPaygrdId" runat="server" />
      <asp:HiddenField ID="HiddenRestrctRange" runat="server" />
 
      <asp:HiddenField ID="HiddenTotalPerTotal" runat="server" />
      <asp:HiddenField ID="HiddenTotalPerBasic" runat="server" />
      <asp:HiddenField ID="HiddenEmpSalryId" runat="server" />
      <asp:HiddenField ID="HiddenOrgId" runat="server" />
      <asp:HiddenField ID="HiddenCorpId" runat="server" />
       <asp:HiddenField ID="HiddenRestrctRangeDedctn" runat="server" />
    
     <asp:HiddenField ID="HiddenRestrctRangeAllw" runat="server" />

     <asp:HiddenField ID="HiddenddlAllDed" runat="server" />

     <asp:HiddenField ID="HiddenPayGrdeId" runat="server" />
     <asp:HiddenField ID="HiddenAmountRngeChk" runat="server" />

     <asp:HiddenField ID="HiddenTotalpay" runat="server" />
      <asp:HiddenField ID="HiddenSalaryAbbrv" runat="server" />
    <asp:HiddenField ID="HiddenSalarSummry" runat="server" />
      <asp:HiddenField ID="HiddenSalaryDedctnId" runat="server" />
     <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
         <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
     <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
     <asp:HiddenField ID="Hiddenreturnfun" runat="server" />

        <asp:HiddenField ID="hiddenEmp" runat="server" />
      <asp:HiddenField ID="HiddenFieldCbxCheck" runat="server" />
    <asp:HiddenField ID="HiddenFieldCheckEmp" runat="server" />
     

       <%-- <script src="/js/HCM/Common.js"></script>--%>
      <div id="main" role="main">
        <div id="ribbon" style="display:none">
            <span id="refresh" class="btn btn-ribbon" data-action="resetWidgets" data-title="refresh" rel="tooltip" data-placement="bottom" data-original-title="<i class='text-warning fa fa-warning'></i> Warning! This will reset all your widget settings." data-html="true">
                <i class="fa fa-refresh"></i>
            </span>
        </div>
        <div class="cont_rght" id="content">

                 <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button> 
        </div>
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

            <section id="widget-grid" class="">

                <div class="row">
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <div class="" id="wid-id-0">

                            <header>

                                <label id="lblHeader" class="pageh2"  runat="server">Monthly Salary Process</label>

                            </header>

                            <div class="smart-form" style="float: left; width: 100%;">
                                  <div id="div1" class="list"   onclick="return ConfirmCancel1();" runat="server" style="position:fixed; right:0%; top:26%;height:26.5px;z-index:1"> </div>
                             <%--   <div id="TabContainer" runat="server" style="float: left; width: 100%;">--%>
                                   
                   <div style="float: left; width: 95%;padding: 10px;margin-top: 2%;border: 1px solid #929292;background-color: #c9c9c9;font-family: Calibri;margin-left:1.5%">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Employee</h2>
                    <asp:Label ID="lblCandtName"  class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Month & Year</h2>
                    <asp:Label ID="lblLoctn" class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Designation</h2>
                    <asp:Label ID="lblRefEmp" class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Pay Grade</h2>
                    <asp:Label ID="lblResume" class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
               
            </div>
                                      <%-- NEXT DIV   allowance benifit --%>
            <div id="divAllnce" runat="server" style="float: left; width:97%; border : 2px solid rgb(207, 204, 204);margin-left : 1.3%;margin-top: 2%;">

                <div id="div2" style="font-size: 20px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;padding: 1%;">
            Allowance/Benefits
        </div >
             


                 <%-- <div  class="eachform" style="width: 99%; float: left;margin-top: 1%;">--%>
                      <div id="divAddtn" style="width: 100%; float: left;" class="formdiv">
                          <div style="width: 70%; float: left;margin-left: 8%;">

                                            <section style="width: 95%; margin-left: 7%;">
                                    <label class="lblh2" style="margin-left: 18.5%;float: left;width: 19%;">Salary Addition*</label>                         
                                   <label class="select" style="float: left;width: 50%;margin-left: 0%;">
                                                       <asp:DropDownList ID="ddlAddtn" class="form1" onchange="RestrictionCalnAllownce();" runat="server" Style="height:30px;width:79%;float:left; margin-left: 4.8%;">
                   
                </asp:DropDownList>

                                                   
                                                </label>     
                                                </section>
                              </div>           
                                                         
                                                </div>

                 <div id="div3" style="width: 100%; float: left;" class="formdiv">
                          <div style="width: 70%; float: left;margin-left: 8%;">

                                            <section style="width: 95%; margin-left: 7%;">
                                    <label class="lblh2" style="margin-left: 18.5%;width: 14%;">Amount *</label>                         
                                   <label class="input" style="float: left;width: 53%;">
                                                      <asp:TextBox ID="txtAmntRgeFrm"   runat="server" MaxLength="12" Style="width: 75%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 14.1%;" onkeydown="return isNumberSalary(event,'cphMain_txtAmntRgeFrm');" onkeyup="addCommas('cphMain_txtAmntRgeFrm')" onblur="AmountChecking('cphMain_txtAmntRgeFrm','cphMain_txtAmntRgeFrm','cphMain_txtAmntRgeTo');"></asp:TextBox>

                                                   
                                                </label>     
                                                </section>
                              </div>           
                                                         
                                                </div>

           

                 <div  style="width: 21%;  float: right;margin-top: 0%;">
                    <div  style="width: 58%; margin-left: 33%;padding: 2%;border: 2px solid rgb(207, 204, 204);margin-right: 3%;">
                     <%--  <asp:Button ID="Button1" runat="server" Style="  margin-left: 81%;height: 31px; margin-left: 5px;padding: 0 22px;font: 300 15px/29px 'Open Sans',Helvetica,Arial,sans-serif;cursor: pointer;" class="btn btn-primary" Text="Process"  OnClientClick="return validateProcess();" />   --%>
                     <asp:Button ID="UpdateAddtn"  runat="server" style="margin-top: 1%;display:none;width:94%;margin-left:1.5%" class="btn btn-primary" Text="Update" OnClientClick="return ValidateAllwnce();"  ONCLICK="btnUpdate_Addtn_Click"/>
                     <asp:Button ID="SaveAddtn" class="btn btn-primary"   runat="server" style="margin-top: 1%;width:94%;margin-left:1.5%"  Text="Save" OnClientClick="return ValidateAllwnce();" ONCLICK="btnAdd_Addtn_Click" />
                     <asp:Button ID="ClearAddtn" class="btn btn-primary"   runat="server" style="margin-top: 1%;margin-left: 2px;width:94%" OnClientClick="return AlertClearAddition();"  Text="Clear"/>
                        </div>
                     </div>
                             <div  class="jarviswidget-color-greenLight jarviswidget-sortable" id="Div10" data-widget-editbutton="false" role="widget">
                 <div id="divAllwList"  runat="server" style="float: left;margin-left: 1.5%;width: 96.6%;font-family:Calibri;margin-top:2%">
            <br />
          
                   <%--  style="margin-left: 3.2%;margin-bottom: 1%;"--%>
        </div>
                                 </div>
                <br /><br /><br />
                </div>

        <%-- NEXT DIV  deduction  --%>


                      <div id="divdedcn" runat="server" style="float:left;width:97%;border : 2px solid rgb(207, 204, 204);margin-left: 1.3%;margin-top: 3%;">

                <div id="div4" style="font-size: 20px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;padding: 1%;">
            Deduction
        </div >



                  <div id="div5" class="eachform" style="width: 99%; float: left;margin-top: 1%;">
                     <%-- div id="divDeduction" style="width: 100%; float: left;" class="formdiv">--%>
                          <div style="width: 70%; float: left;margin-left: 8%;">

                                            <section style="width: 95%; margin-left: 7%;">
                                    <label class="lblh2" style="margin-left: 18.5%;float: left;width: 19%;">Salary Deduction*</label>                         
                                   <label class="select" style="float: left;width: 50%;margin-left: 0%;">
                                   
                                          <asp:DropDownList ID="ddldedctn" class="form1" onchange="RestrictionCalnDedcn();" runat="server" Style="height:30px;width:79%;float:left; margin-left: 4.8%;">
                                        
                   
                </asp:DropDownList>

                                                   
                                                </label>     
                                                </section>


                                 <section style="width: 100%; margin-left: 45%;margin-top: 6%;">
                                              
                                              
                                                        <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px; width: 33%; float: left; border: 1px solid #04619c; margin-bottom: 1px;">

                                            <label class="radio" style="font-family: Calibri;">
                                                <input id="radAmnt" type="radio" runat="server" onkeydown="return DisableEnter(event)" onchange="RadioAmountClick()" name="radTyp" />
                                                <i></i>Amount</label>

                                                           
                                            <label class="radio" style="font-family: Calibri;margin-left: 16%;">
                                                <input  id="radPercntge" type="radio" runat="server" onkeydown="return DisableEnter(event)" onchange="RadioPerClick()" name="radTyp" />
                                                <i></i>Percentage</label>

                                        </div>
                                            
                                            </section>
                              </div>    
                      
                       <div id="divAmtClk" >
                        <div id="div8" style="width: 100%; float: left;" class="formdiv">
                          <div style="width: 70%; float: left;margin-left: 8%;">

                                            <section style="width: 95%; margin-left: 7%;">
                                    <label class="lblh2" style="margin-left: 18.5%;width: 14%;">Amount *</label>                         
                                   <label class="input" style="float: left;width: 53%;">
                                                      <asp:TextBox ID="txtAmntRedcnFrom" onkeydown="return isNumberSalary(event,'cphMain_txtAmntRedcnFrom');" onkeyup="addCommas('cphMain_txtAmntRedcnFrom')" onblur="AmountChecking('cphMain_txtAmntRedcnFrom','cphMain_txtAmntRedcnFrom','cphMain_txtAmntRedcnTo');"   runat="server" MaxLength="12" Style="width: 75%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 14.1%;" ></asp:TextBox>

                                                   
                                                </label>     
                                                </section>

                              </div>           
                                                         
                                                </div>       
                                                  </div>    
                      
                      
                       <div id="divperclk" >
                        <div id="div9" style="width: 98%;margin-top:1%;float: left;border: 2px solid rgb(207, 204, 204);background-color: #edecec;margin-left: .8%;padding-top: 1%;" class="formdiv">
                          <div style="width: 91%; float: left;margin-left: 8%;">

                                            <section style="width: 62%; margin-left: 7%;float: left;">
                                    <label class="lblh2" style="margin-left: 18.5%;width: 16%;">Percentage *</label>                         
                                   <label class="input" style="float: left;width: 54%;margin-left: 9%;">
                                                      <asp:TextBox ID="txtperctg" onkeydown="return isNumberSalary(event,'cphMain_txtperctg');" onkeyup="addCommas('cphMain_txtperctg')" onblur="AmountChecking('cphMain_txtperctg','cphMain_txtperctg','cphMain_txtperctg');"   runat="server" MaxLength="3" Style="width: 89%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 1%;" ></asp:TextBox>

                                                   
                                                </label>     
                                                </section>
                                       <section style="width: 30%; margin-left: 0%;margin-top: 0%;float: left;">
                                              
                                              
                                                        <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px; width: 89%; float: left; border: 1px solid #04619c; margin-bottom: 1px;">

                                            <label class="radio" style="font-family: Calibri;">
                                                <input  id="radioBascPay" type="radio" runat="server" onkeydown="return DisableEnter(event)" onchange="RadioopenClick()" name="radTypenxt" />
                                                <i></i>Basic Pay</label>

                                                           
                                            <label class="radio" style="font-family: Calibri;margin-left: 9%;">
                                                 <input id="radioTotlAmnt" type="radio" runat="server" onkeydown="return DisableEnter(event)" onchange="RadioLimitedClick()" name="radTypenxt" />
                                                <i></i>Total Amount</label>

                                        </div>
                                            
                                            </section>
                              </div>           
                                                         
                                                </div>       
                                                  </div>   
                          
                                                </div>



                        
                                                         
                                 
                       
                                                            
                                                         
                                         
                      
                       

                            <div  style="width: 21%;  float: right;margin-top: 0%;">
                    <div  style="width: 58%; margin-left: 33%;padding: 2%;border: 2px solid rgb(207, 204, 204);margin-right: 3%;">
                      
                     <asp:Button ID="UpdateDedctn"  runat="server" class="btn btn-primary"  style="display:none;width:94%;margin-top:1%;margin-left:1.5%" Text="Update" OnClientClick="return ValidateDedctn();" ONCLICK="btnUpdate_Dedctn_Click"  />
                     <asp:Button ID="SaveDedctn" style="width:94%;margin-top:1%;margin-left:1.5%" runat="server" class="btn btn-primary"  Text="Save" OnClientClick="return ValidateDedctn();" ONCLICK="btnAdd_Dedctn_Click"  />
                     <asp:Button ID="ClearDedctn"  runat="server" style="margin-left: 2px;width:94%;margin-top:1%" OnClientClick="return AlertClearDedAll();" class="btn btn-primary"  Text="Clear"/>
                        </div>
                     </div>
                             <div  class="jarviswidget-color-greenLight jarviswidget-sortable" id="Div7" data-widget-editbutton="false" role="widget">
                 <div id="divList"  runat="server" style="margin-left: 2.2%;margin-bottom: 1%;float: left;width: 96%;font-family:Calibri;margin-top:2%">
                     </div>
            <br />
          
        </div>
                </div>
              <div id="DivSalrysumry"  style="float:left;width:97%;border: 2px solid rgb(207, 204, 204);margin-left: 1.3%;margin-top: 3%;">
                          <div id="div6"  style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
         <label class="lblh2" style="padding-left: 1%;font-size: 23px;margin-top: 1%"> Salary Summary </label>   
                              <div style="padding:5%">
                               <label class="lblh2" style="">Basic Pay  </label>   <h2 id="SumryPayRng" style="margin-left: 9.5%;"> </h2> <br />
                               <label class="lblh2" style="">Addition  </label>   <h2 id="SumryAdtnRng" style="margin-left: 9.5%;"></h2> <br />
                               <label class="lblh2" style="">Deduction </label>     <h2 id="SumryDedctnRng" style="margin-left: 9.5%;"></h2>  <br />
                                    <h2 class="lblh2" style="">Total pay </h2>     <h2 id="SumryTotalpay" style="margin-left: 9.5%;"></h2>  <br />
                                  </div>
        </div >
                  </div>


                                </div>


                            
                            
                                <footer style="background: white;">
                                 <%--   <asp:Button ID="btnAddClose" runat="server" Style="float: left; margin-left: 80%;" class="btn btn-primary" Text="Save" OnClick="btnSave_Click" OnClientClick="return validatedinomn();" />
                                    <asp:Button ID="btnUpdClose" runat="server" Style="display: none; float: left; margin-left: 81%;" class="btn btn-primary" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return validatedinomn();" />
                                    <asp:Button ID="btnClear" runat="server" Style="float: left;" class="btn btn-primary" Text="Cancel" OnClientClick="return ConfirmCancel();" />--%>
                                    <%--      <button type="submit" class="btn btn-primary">
                                            SAVE float: left;margin-left: 80%;
                                        </button>--%>
                                </footer>
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

         <%--<div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>--%>

 
        <script type="text/javascript">
  


    </script>
    <style>
        table.dataTable tbody td {
            word-break:break-all;          
        }
        
         .table {
            font-size:13px;
        }
          
        #datatable_fixed_column_wrapper {
            border: 1px solid #ddd;
        }
    </style>
</asp:Content>

