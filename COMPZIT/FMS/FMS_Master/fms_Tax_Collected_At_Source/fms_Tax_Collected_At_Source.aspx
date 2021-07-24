<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Tax_Collected_At_Source.aspx.cs" Inherits="FMS_fms_Tax_Collected_At_Source_fms_Tax_Collected_At_Source" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

     <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="../../../../js/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../../js/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
    <script type="text/javascript">
        var $noCon1 = jQuery.noConflict();
        $noCon1(window).load(function () {
            if (document.getElementById("<%=Hiddentxtefctvedate.ClientID%>").value != "") {
                insertFromDate()
            }
            if (document.getElementById("<%=HiddentxtefctveTodate.ClientID%>").value != "") {
                insertToDate()
            }


        });
        function check($char, obj) {
            if (obj.value > 100.0) {
                return false;
            }
            if ($char == 60 || $char == 62 || $char == 13) {
                return false;
            }
            //  alert($char);
            if ($char >= 65 && $char <= 90) {
                return false;
            }
            if (obj.value.length == 0 || obj.value.length == 1) {
                if (($char >= 48 && $char <= 57) || ($char >= 96 && $char <= 105) || $char == 190 || $char == 8 || $char == 9 || $char == 46 || $char == 13 || $char == 9 || $char == 35 || $char == 36 || $char == 37 || $char == 39 || $char == 110) {
                    return true;
                }
            }
            else if (obj.value.length == 2) {
                if ((obj.value > 10) && ($char == 110 || $char == 190 || $char == 46 || $char == 8 || $char == 9 || $char == 37 || $char == 39 || $char == 35 || $char == 36)) {
                    return true;
                }
                else if ((obj.value == 10) && ($char == 48 || $char == 96 || $char == 110 || $char == 190 || $char == 46 || $char == 8 || $char == 9 || $char == 37 || $char == 39 || $char == 35 || $char == 36)) {
                    return true;
                }
                else if ((obj.value < 10) && (($char >= 48 && $char <= 57) || ($char >= 96 && $char <= 105) || $char == 190 || $char == 8 || $char == 9 || $char == 46 || $char == 13 || $char == 9 || $char == 35 || $char == 36 || $char == 37 || $char == 39 || $char == 110)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else if (obj.value.length == 3) {
                if ((obj.value == 100) && ($char == 110 || $char == 190 || $char == 46 || $char == 8 || $char == 37 || $char == 39 || $char == 35 || $char == 36)) {
                    return true;
                }
                else if ((obj.value.indexOf(".") != -1) && (($char >= 48 && $char <= 57) || ($char >= 96 && $char <= 105) || $char == 190 || $char == 8 || $char == 9 || $char == 46 || $char == 13 || $char == 9 || $char == 35 || $char == 36 || $char == 37 || $char == 39 || $char == 110)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else if (obj.value.length == 4) {
                if ((obj.value.indexOf(".") != -1) && (($char >= 48 && $char <= 57) || ($char >= 96 && $char <= 105) || $char == 190 || $char == 8 || $char == 9 || $char == 46 || $char == 13 || $char == 9 || $char == 35 || $char == 36 || $char == 37 || $char == 39 || $char == 110)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else if (($char == 46 || $char == 8 || $char == 9 || $char == 37 || $char == 39 || $char == 35 || $char == 36)) {
                return true;
            }
            else {
                return false;
            }
        }
        function AmountChecking(textboxid) {

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
                        n = num.toFixed(FloatingValue);
                    }
                    else {
                        n = num;
                    }

                    document.getElementById(textboxid).style.borderColor = "";
                    document.getElementById('' + textboxid + '').value = n;

                    if (document.getElementById(textboxid).value != "") {
                        var NameWithoutReplace = document.getElementById(textboxid).value;
                        document.getElementById(textboxid).value = NameWithoutReplace.replace(/,/g, "");


                        var amtrnge1 = document.getElementById(textboxid).value;


                        if (100 < parseFloat(amtrnge1)) {

                            document.getElementById(textboxid).style.borderColor = "red";
                            document.getElementById(textboxid).value = "";
                            $noCon(window).scrollTop(0);
                            $noCon("#divWarning").html("Deductive percentage should  be less than hundered.");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                //  document.getElementById(textboxid).focus();

                            });

                          

                        }

                    }


                }
            }



              // alert("55");
            return true;
        }
        function ValidateTcs() {
            var ret = true;
            var flag = 0;
            var name = document.getElementById("<%=txtName.ClientID%>").value.trim();
            var prcntg = document.getElementById("<%=txtCltvPercng.ClientID%>").value.trim();
               var frmDate = document.getElementById("<%=txtDateFrom.ClientID%>").value.trim();
               var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value.trim();
               document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";
               document.getElementById("<%=txtCltvPercng.ClientID%>").style.borderColor = "";
               document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "";
               document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";
            if (prcntg == "") {
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
              
                document.getElementById("<%=txtCltvPercng.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCltvPercng.ClientID%>").focus();

                  ret = false;
              }
               if (name == "") {
                   $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                   $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                   });
                 
                   document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
                   document.getElementById("<%=txtName.ClientID%>").focus();

                ret = false;
            }

          
            if (frmDate == "" && ToDate == "") {

                document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                 // document.getElementById("<%=txtDateFrom.ClientID%>").focus();
                  $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                  $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                  });
                  // $noCon("#divWarning").alert();
                  $noCon1(window).scrollTop(0);
                  flag = 1;
                  ret = false;



              }

           else if (frmDate == "") {
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
              
                document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                flag = 1;
       //document.getElementById("<%=txtDateFrom.ClientID%>").focus();

       ret = false;
            }
         else  if (ToDate == "") {
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
              
                document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                  //document.getElementById("<%=txtDateFrom.ClientID%>").focus();

                  ret = false;
            }
            if (flag == 0) {


             
                var arrDatePickerDate1 = frmDate.split("-");
                frmDate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
                var arrDatePickerDate1 = ToDate.split("-");
                ToDate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
              //  alert(ToDate);
                if ((frmDate != "" && ToDate != "") && frmDate >= ToDate) {
                    document.getElementById("<%=txtDateFrom.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                   // document.getElementById("<%=txtToDate.ClientID%>").focus();
                    $noCon("#divWarning").html("From date should be less than To date");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    // $noCon("#divWarning").alert();
                    $noCon1(window).scrollTop(0);

                    ret = false;
                }
            }
            if (DateChk() == false) {
               
                ret = false;
            }
            return ret;
        }
        function DateChk() {
            var ret = true;
           

            if (document.getElementById("cphMain_txtDateFrom").value != "" && document.getElementById("cphMain_txtToDate").value != "") {

                var datepickerDate = document.getElementById("cphMain_txtDateFrom").value;
                        var arrDatePickerDate = datepickerDate.split("-");
                        var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                        var datepickerDate = document.getElementById("cphMain_txtToDate").value;
                        var arrDatePickerDate = datepickerDate.split("-");
                        var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);



                        if (dateTxIss >= dateCompExp) {



                            $noCon("#divWarning").html("From date should be less than  to date");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                          
                            $noCon(window).scrollTop(0);

                            document.getElementById("cphMain_txtToDate").focus();

                            document.getElementById("cphMain_txtToDate").style.borderColor = "red";
                            document.getElementById("cphMain_txtToDate").value = "";


                            ret = false;

                        }
                    }
                    return ret;
                }

</script>
    <script type="text/javascript">
        var $noCon = jQuery.noConflict();
   
 

         function isTag(evt) {
             IncrmntConfrmCounter();

             evt = (evt) ? evt : window.event;
             var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

             var charCode = (evt.which) ? evt.which : evt.keyCode;
             var ret = true;
             if (charCode == 60 || charCode == 62 || keyCodes == 13) {
                 ret = false;
             }
             return ret;
         }
         function textCounter(field, maxlimit) {        //emp25
             RemoveTag();
             RemoveDescTag();
             if (field.value.length > maxlimit) {
                 field.value = field.value.substring(0, maxlimit);
             } else {
                 isTag(event);
             }
         }
         function isTagEnter(evt) {
             IncrmntConfrmCounter();

             evt = (evt) ? evt : window.event;
             var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

             var charCode = (evt.which) ? evt.which : evt.keyCode;
             var ret = true;
             if (charCode == 60 || charCode == 62) {
                 ret = false;
             }
             return ret;
         }


         function SuccessConfirmation() {

             $noCon("#success-alert").html("Tax details inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
           

            return false;


        }
         function SuccessUpdation() {
             $noCon("#success-alert").html("Tax details updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
           

            return false;

        }
      function DuplicationName() {
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtName.ClientID%>").focus();

            $noCon("#divWarning").html("Duplication Error! TCS Name can’t be duplicated.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
          

            return false;


      }
        function CanclUpdMsg() {
            $noCon("#divWarning").html("This TCS is already cancelled .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }


        function ConfirmMessage() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Tax_Collected_At_Source_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "fms_Tax_Collected_At_Source_List.aspx";
            }
        }

 

        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }


        function isTag(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="Hiddentxtefctvedate" runat="server" />
     <asp:HiddenField ID="HiddentxtefctveTodate" runat="server" />
    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li><a href="fms_Tax_Collected_At_Source_List.aspx">TCS</a></li>
        <li class="active">Add TCS</li>
    </ol>
    <div class="myAlert-bottom alert alert-danger" id="divWarning" style="display: none">
        <button type="button" class="close" data-dismiss="alert">x</button>
    </div>
    <div class="myAlert-top alert alert-success" id="success-alert" style="display: none">
        <button type="button" class="close" data-dismiss="alert">x</button>
    </div>
    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">

            <div class="content_box1 cont_contr">
                <h1>
                    <asp:Label ID="lblEntry" runat="server"></asp:Label></h1>
                <div class="clearfix"></div>
                <div class="free_sp"></div>
                <div class="">
                    <div class="">
                        <div class="form-group fg4">
                            <label for="example-text-input" class="fg2_la1">Name<span class="spn1">*</span></label>
                            <asp:TextBox ID="txtName" runat="server" MaxLength="150" class="form-control fg2_inp1 inp_mst"  onkeypress="return DisableEnter(event)" onkeydown="textCounter('cphMain_txtName',180)" onkeyup="textCounter('cphMain_txtName',180)"></asp:TextBox>
                        </div>
                        <div class="form-group fg4">
                            <label for="example-text-input" class="fg2_la1">Deductive Percentage<span class="spn1">*</span></label>
                            <asp:TextBox ID="txtCltvPercng" class="form-control fg2_inp1 inp_st tr_r inp_mst br_1pro" runat="server" MaxLength="5" Style="text-align: right;" onkeypress="return  IncrmntConfrmCounter();" onkeydown="return check(event.keyCode, this);" onblur="AmountChecking('cphMain_txtCltvPercng');"></asp:TextBox>
                            <span class="input-group-addon cur3 r3">%</span>
                        </div>
                    </div>
                </div>


                <div class="clearfix"></div>
                <div class="free_sp"></div>
                <div class="devider divid"></div>

                <div class="">
                    <p class="plc1">Effective date range<span class="spn1">*</span></p>
                    <div class="form-group fg4">
                        <div class="tdte" id="divFromDate">
                            <label for="pwd" class="fg2_la1">From Date:<span class="spn1">*</span> </label>
                            <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
                                <input id="txtDateFrom" runat="server" type="text" onkeypress="return DisableEnter(event)" onchange="show()" class="form-control inp_bdr" placeholder="dd-mm-yyyy" maxlength="50" />
                                <span id="spanFromdate" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                            </div>
                        </div>
                    </div>
                    <div class="form-group fg4">
                        <div class="tdte" id="divToDate">
                            <label for="pwd" class="fg2_la1">To Date:<span class="spn1">*</span> </label>
                            <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
                                <input id="txtToDate" name="txtToDate" runat="server" type="text" onkeypress="return DisableEnter(event)" onchange="showTo()" class="form-control inp_bdr" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                                <span id="spanTodate" runat="server" class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                            </div>
                        </div>
                    </div>
                    <script>
                        var $noCon4 = jQuery.noConflict();
                        var dateToday = new Date();
                        $noCon4('#datepicker').datepicker({
                            autoclose: true,
                            format: 'dd-mm-yyyy',
                            //endDate: 'today',


                        });
                        function showFromDate() {
                            //DateCheck();
                            IncrmntConfrmCounter();
                            //  DateCurrentValue();
                            //  $noCon4("#txtDateFrom").datetimepicker({ format: 'dd-mm-yyyy' })
                            $noCon4('#cphMain_Hiddentxtefctvedate').val($noCon4('#cphMain_txtDateFrom').val().trim());


                        }
                        function insertFromDate() {

                            IncrmntConfrmCounter();
                            $noCon4('#cphMain_txtDateFrom').val($noCon4('#cphMain_Hiddentxtefctvedate').val().trim());

                        }
                    </script>
                    <script>

                        $noCon4('#datepicker1').datepicker({
                            autoclose: true,
                            format: 'dd-mm-yyyy',
                            //endDate: 'today',


                        });
                        function showToDate() {
                            //DateCheck();
                            IncrmntConfrmCounter();
                            //  DateCurrentValue();
                            //  $noCon4("#txtDateFrom").datetimepicker({ format: 'dd-mm-yyyy' })
                            $noCon4('#cphMain_HiddentxtefctveTodate').val($noCon4('#cphMain_txtToDate').val().trim());


                        }
                        function insertToDate() {

                            IncrmntConfrmCounter();
                            $noCon4('#cphMain_txtToDate').val($noCon4('#cphMain_HiddentxtefctveTodate').val().trim());

                        }
                    </script>


                </div>

                <div class="clearfix"></div>
                <div class="free_sp"></div>
                <div class="devider divid"></div>

                 <div class="form-group fg2 fg2_mr">
       <div class="">
        <div class="form-check">
           <input class="form-check-input" type="radio" checked="true" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" runat="server" id="typResident"  name="optradio" >
          <label class="form-check-label" for="gridRadios1">
            Resident
          </label>
        </div>
        <div class="form-check">
          <input class="form-check-input" type="radio" id="typeNonResident" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" runat="server" name="optradio">
          <label class="form-check-label" for="gridRadios2">
            Non-Resident
          </label>
        </div>
      </div>
    </div>
                <%--<div class="form-group fg2 fg2_mr">
                    <div class="">
                        <div class="form-check">
                           
                            <label class="form-check-label" for="gridRadios1">Resident  </label>
                        </div>
                        <div class="form-check">
                            
                            <label class="form-check-label" for="gridRadios2">
                                Non-Resident
                            </label>
                        </div>
                    </div>
                </div>--%>
                <div class="form-group fg2 fg2_mr">
                    <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
                    <div class="check1">
                        <div class="">
                            <label class="switch">
                                <input type="checkbox" runat="server" checked onchange="FunctStsChkBx();" onkeypress="return DisableEnter(event)" id="Chksts" />
                                <span class="slider_tog round"></span>
                            </label>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="free_sp"></div>
      

                <div id="divList" runat="server" class="list_b" style="cursor: pointer;" onclick="return ConfirmMessage()" title="Back to List">
                    <i class="fa fa-arrow-circle-left"></i>
                </div>

                <div class="sub_cont pull-right">
                    <div class="save_sec">
                        <asp:Button ID="bttnsave" TabIndex="8" runat="server" OnClientClick="return ValidateTcs();" class="btn sub1" Text="Save" OnClick="bttnsave_Click" />
                        <asp:Button ID="btnUpdate" TabIndex="9" runat="server" OnClientClick="return ValidateTcs();" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" />
                        <input type="button" tabindex="10" id="btnCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn sub4" />

                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="free_sp"></div>

            </div>
        </div>
    </div>



  
   
</asp:Content>

