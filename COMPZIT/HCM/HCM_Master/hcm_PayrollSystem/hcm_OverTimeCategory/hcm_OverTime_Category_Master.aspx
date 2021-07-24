<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_OverTime_Category_Master.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_OverTimeCategory_hcm_OverTime_Category_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">


    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script> 

    <script src="/js/jQuery/jquery-2.2.3.min.js"></script>
    <script src="/js/bootstrap/bootstrap.min.js"></script>

    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />

        <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />

     <link href="../../../../css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="/js/HCM/Common.js"></script>
      

    <script>
        var $NoConfi = jQuery.noConflict();
        $NoConfi(window).load(function () {
            checkAllChange();
            AmountCheck('cphMain_txtRate');
            var cancelSts = '<%= Session["OvrViewId"] %>';

            if (cancelSts != "") {
                
                $NoConfi("#cphMain_txtCatgName").attr("disabled", true);
                $NoConfi("#cphMain_txtRate").attr("disabled", true);
                $NoConfi("#cphMain_CbxStatus").attr("disabled", true);
                $NoConfi("#cphMain_CbxStatus").attr("disabled", true);
                document.getElementById("cphMain_Chkall").disabled = true;

                var RowCount = document.getElementById("<%=HiddenFieldCbxCount.ClientID%>").value;
                for (var i = 0; i < RowCount; i++) {
                    document.getElementById("cphMain_chkbxListPayGrd_" + i).disabled = true;
                }
            }

            //messages
            var SuccessMsg = document.getElementById("<%=HiddenSuccessMsgType.ClientID%>").value;

            if (SuccessMsg == "SAVE") {
                AddSuccesMessage();
            }
            else if (SuccessMsg == "UPDATE") {
                UpdateSuccesMessage();
            }
            else if (SuccessMsg == "DUPLICATE") {
                DuplicateSuccesMessage();
                
            }
            else if (SuccessMsg == "DELETE") {
                DeleteSuccesMessage();
            }
            document.getElementById("<%=HiddenSuccessMsgType.ClientID%>").value = "0";


            });


        //show messages 

        function AddSuccesMessage() {
            $noCon4("#success-alert").html("Over time category details inserted successfully.");
            $noCon4("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon4("#success-alert").alert();

            return false;
        }
        function UpdateSuccesMessage() {
            $noCon4("#success-alert").html("Over time category details updated successfully.");
            $noCon4("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon4("#success-alert").alert();

            return false;
        }

        function DeleteSuccesMessage() {
            $noCon4("#success-alert").html("Over time category cancelled successfully.");
            $noCon4("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon4("#success-alert").alert();

            return false;
        }
        function DuplicateSuccesMessage() {
            $noCon4("#success-alert").html("Category Name Cannot be Duplicated.");
            document.getElementById("<%=txtCatgName.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtCatgName.ClientID%>").focus();
            $noCon4("#success-alert").fadeTo(2000, 500).slideUp(500, function () {

                        $noCon4("#cphMain_txtDocnum").focus();
                    });

            $noCon4("#success-alert").alert();
                    return false;
         }


    </script>
       

 
    <script>
        var $noCon4 = jQuery.noConflict();
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }

        function ConfirmCancel() {
            if (confirmbox > 0)
                CancelAlert("hcm_OverTime_CategoryList.aspx");
            else
                window.location.href = "hcm_OverTime_CategoryList.aspx";
            return false;
        }
        function ConfirmMessageforlist() {
            if (confirmbox > 0)
                ConfirmMessage("hcm_OverTime_CategoryList.aspx");
            else
                window.location.href = "hcm_OverTime_CategoryList.aspx";
            return false;
        }

        function CleartAlert() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to clear data?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    $noCon4("#cphMain_txtCatgName").val('');
                    $noCon4("#cphMain_txtRate").val('');
                    $noCon4('input:checkbox').prop('checked', false);

                    $noCon4(this).val('uncheck all');
                    $noCon4('#cphMain_CbxStatus').prop('checked', true);
                    
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;           
        }


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

        //pay grade check list select all
        function changeAll() {
            var RowCount = document.getElementById("<%=HiddenFieldCbxCount.ClientID%>").value;
                    if (document.getElementById("cphMain_Chkall").checked == true) {
                        for (var i = 0; i < RowCount; i++) {
                            if (document.getElementById("cphMain_chkbxListPayGrd_" + i).disabled == false) {
                                document.getElementById("cphMain_chkbxListPayGrd_" + i).checked = true;
                            }
                        }
                    }
                    else {
                        for (var i = 0; i < RowCount; i++) {
                            if (document.getElementById("cphMain_chkbxListPayGrd_" + i).disabled == false) {
                                document.getElementById("cphMain_chkbxListPayGrd_" + i).checked = false;
                            }
                        }
                    }
                    return false;
                }

        //all change while clearing paygrade check box list 
                function checkAllChange() {
                    var RowCount = document.getElementById("<%=HiddenFieldCbxCount.ClientID%>").value;
            flag = true;

            for (var i = 0; i < RowCount; i++) {

                if (document.getElementById("cphMain_chkbxListPayGrd_" + i).checked == false) {
                    flag = false;
                }
            }
            if (flag == true) {
                document.getElementById("cphMain_Chkall").checked = true
            }
                }

        function isNumber(evt, textboxid) {
            
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            var txtPerVal = document.getElementById(textboxid).value;
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



        //for decimal part of currencies
        function AmountCheck(textboxid) {
            var txtPerVal = (document.getElementById(textboxid).value).split(',').join('');
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
                   // document.getElementById('' + textboxid + '').value = addCommas(n);
                    document.getElementById('' + textboxid + '').value = n;
                }
            }
        }

        

        function Validate() {
            
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtCatgName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");

            document.getElementById("<%=txtCatgName.ClientID%>").value = replaceText2;
            NameWithoutReplace = document.getElementById("<%=txtRate.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtRate.ClientID%>").value = replaceText2;

            document.getElementById("<%=txtCatgName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtRate.ClientID%>").style.borderColor = "";

      
            var rate = document.getElementById("<%=txtRate.ClientID%>").value.trim();
            var Name = document.getElementById("<%=txtCatgName.ClientID%>").value.trim();
            

            if (rate == "") {
                document.getElementById("<%=txtRate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtRate.ClientID%>").focus();
       
                
                ret = false;
               
            }

            if (Name == "") {
                document.getElementById("<%=txtCatgName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCatgName.ClientID%>").focus();
               ret = false;
                        }

            var paygrde = document.getElementById("<%=chkbxListPayGrd.ClientID%>").value;
            var flag = 0;
            var RowCount = document.getElementById("<%=HiddenFieldCbxCount.ClientID%>").value;
            if (document.getElementById("cphMain_Chkall").checked == false) {
                for (var i = 0; i < RowCount; i++) {
                    if (document.getElementById("cphMain_chkbxListPayGrd_" + i).checked == true) {
                        flag = 1;
                    }
                }
            }
            else
                flag = 1;


            if (flag == "0") {
                document.getElementById("cphMain_divCheckBox").style.borderColor = "Red";
                $noCon4("#success-alert-danger").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon4("#success-alert-danger").fadeTo(2000, 500).slideUp(500, function () {
                    $noCon4("#cphMain_chkbxListPayGrd").focus();
                });

                $noCon4("#success-alert-danger").alert();
                document.getElementById("<%=chkbxListPayGrd.ClientID%>").focus();//evm-20
                ret = false;
            }

            if (ret == false) {
         
                CheckSubmitZero();
            }

            return ret;
        }

    </script>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">


         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="HiddenFieldCbxCount" runat="server" />
    <asp:HiddenField ID="HiddenOvertTimeCatgId" Value="0" runat="server" />
    <asp:HiddenField ID="HiddenFieldjsonData" runat="server" />
    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <asp:HiddenField ID="hiddenRoleAdd" runat="server" />
    <asp:HiddenField ID="HiddenSuccessMsgType" runat="server" />




    <div class="cont_rght" style="width: 100%; padding:0px">


        <div id="divList" class="list" onclick="ConfirmMessageforlist();" runat="server" style="position: fixed; right: 0%; top: 22%; height: 26.5px;z-index: 1;">
        </div>

             <div class="alert alert-success" id="success-alert" style="display: none">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
               <div class="alert alert-danger" id="success-alert-danger" style="display:none">
                 <button type="button" class="close" data-dismiss="alert">x</button>
                 <strong>Warning! </strong>
                  
               </div>


             <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>

           <div id="div2" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;margin-left: 15px;">
           
            </div >


        </br>
        
 
    
                <div class="smart-form" style="float: left; width: 100%;">
            
   
           <div style="width: 50%; float: left;" class="formdiv">
               <br/>
             <div style="width: 100%; float: left;">
                <section style="width: 95%; margin-left: 5%;">
                 <label class="lblh2" style="float: left;width: 27%;Height:33px;">Name* </label>
                <label class="input" style="float: left;width: 60%;">
                <asp:TextBox ID="txtCatgName" class="form-control" runat="server" MaxLength="70" Width="57%" onchange="IncrmntConfrmCounter();" Height="33px" onblur="RemoveTag('cphMain_txtCatgName');" onkeydown="return DisableEnter(event);" onkeypress="return isTag(event);" Style="resize: none; text-transform: uppercase; font-family: calibri; float: left;"></asp:TextBox>
                 </label>
                 </section>    
              </div>
                 
    
           <div style="width: 100%; float: left;">
                <section style="width: 95%; margin-left: 5%;">
                 <label class="lblh2" style="float: left;width: 27%;Height:33px;">Rate* </label>
               <label class="input" style="float: left;width: 60%;">
                <asp:TextBox ID="txtRate" class="form-control" runat="server" MaxLength="12" Width="32%"   onchange="IncrmntConfrmCounter();" Height="33px" Style="resize: none; margin-top: 3px; text-align:right; float: left; text-transform: uppercase; font-family: calibri;" onblur="AmountCheck('cphMain_txtRate');" onkeydown="return isNumber(event,'cphMain_txtRate');"></asp:TextBox>
                   <h2 style="float: left; margin-left: 13px; margin-top: 15px;font-size: 17px;">Per Hour</h2>
                 </label>
                   </section>
                   
            </div>

            <div style="width: 100%; float: left;">
                <section style="width: 95%; margin-left: 5%;">
                      <label class="lblh2" style="float: left;width: 27%;Height:33px;">Status* </label>
             
                <label class="checkbox" style="float: left;width: 60%;">
                <input name="checkbox-inline" id="CbxStatus" onkeydown="return DisableEnter(event)" runat="server"   checked="checked" type="checkbox" />
                 <i></i></label>
                 </section> 
            </div>

       </div>


          <div style="width: 50%; float: left;" class="formdiv">
               <br/>
             <div style="width: 50%; float: left;">
                   <section style="width: 95%; margin-left: 5%;">
                 <label class="lblh2" style="float: left;width: 30%;">Pay Grades* </label>
                    

                  <label class="checkbox" style="float:right;width: 20%;color: #909c7b;margin-right:16px;">
                 <input name="checkbox-inline" id="Chkall" runat="server" type="checkbox" onkeydown="return DisableEnter(event)" onchange="return changeAll();"/>
                 <i></i>ALL</label>
                   <div id="divCheckBox" runat="server" style="width: 82%; margin-right: 17.9%; height: 100px; padding-bottom: 8px;margin-top: 5px;">

                <asp:CheckBoxList ID="chkbxListPayGrd" onkeydown="return DisableEnter(event)" runat="server" type="checkbox"  >
                </asp:CheckBoxList>
                </div>
                  
                   </section>

              </div>
           </div>

 
   
             <footer style="background: white;">
                   <div style="float:right;margin-right:45%;margin-top: 70px;">
               

                 <asp:Button ID="btnAdd" runat="server"  class="btn btn-primary" Text=" Save" OnClientClick="return Validate();" OnClick="btnAdd_Click" Style="float:left" />
                  <asp:Button ID="btnAddCls" runat="server"  class="btn btn-primary" Text=" Save & Close" OnClientClick="return Validate();" OnClick="btnAdd_Click" Style="float:left"/>
                <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return Validate();" Style="float:left" />
                 <asp:Button ID="btnUpdateCls" runat="server" class="btn btn-primary" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return Validate();" Style="float:left" />
                 <asp:Button ID="btnClear" runat="server"  OnClick="btnClear_Click" OnClientClick="return CleartAlert();" class="btn btn-primary" Text="Clear" Style="float:left" />                
                <asp:Button ID="btnCancel" runat="server"  class="btn btn-primary" Text="Cancel" onchange="IncrmntConfrmCounter();" OnClick="btnCancel_Click" OnClientClick="return ConfirmCancel();" Style="float:left" />
                
               
                
                      
                    </div>
                </footer>

         </div>

    </div>


    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />


    <style>
        .select2-container--default .select2-selection--multiple .select2-selection__choice {
            background-color: #a5a5a5;
            border-color: #8d8d8d;
            padding: 1px 5px;
            color: #fff;
            font-size: 14px;
            margin: 2px;
            max-width: 260px;
            font-family: Calibri;
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

        #cphMain_divCheckBox label {
            /*float: right;*/
            margin-bottom: 0px;
            color: #16682a;
            font-family: Calibri;
            font-size: 15px;
        }

            #cphMain_divCheckBox label.hover {
                color: #1acc45;
            }

        #cphMain_divCheckBox input[type="checkbox"] {
            float: left;
            margin: 3px 8px 3px 3px;
            
        }

        #cphMain_divCheckBox {
            
            float: right;
            height: 80px;
            width: 63%;
            max-height: 100px;
            overflow: auto;
            border: 1px solid;
            border-color: #90a8b0;
            background-color: #f9f9f9;
        }

        #cphMain_chkbxListPayGrd :focus {
            background: #bbf2cf;
            outline: 3px solid #72c08e !important;
            cursor: pointer;
        }
     

    </style>
</asp:Content>

