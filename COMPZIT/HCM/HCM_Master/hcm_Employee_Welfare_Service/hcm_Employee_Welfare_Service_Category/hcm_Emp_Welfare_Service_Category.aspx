<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Emp_Welfare_Service_Category.aspx.cs" Inherits="HCM_HCM_Master_hcm_Employee_Welfare_Service_hcm_Employee_Welfare_Service_Category_hcm_Emp_Welfare_Service_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
     <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>


    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />
    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="/js/jQueryUI/jquery-ui.min.js"></script>
    <script src="/js/jQueryUI/jquery-ui.js"></script>

    <script src="/js/HCM/Common.js"></script>

        <script type="text/javascript" language="javascript">
        
            // for not allowing <> tags
          
            function isTag(evt) {

                evt = (evt) ? evt : window.event;
                var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                //if (keyCodes == 13) {
                //    return false;
                //}
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

                evt = (evt) ? evt : window.event;
                var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                if (keyCodes == 13) {
                    return false;
                }
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

            function isNumber(evt, textboxid) {
                evt = (evt) ? evt : window.event;
                var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                var charCode = (evt.which) ? evt.which : evt.keyCode;

                var txtPerVal = document.getElementById(textboxid).value;
                //enter
                if (keyCodes == 13 || keyCodes == 110) {
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
                    var ret = false;


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

            var $noCon = jQuery.noConflict();
            function CategoryValidate() {
                var ret = true;
                if (document.getElementById("<%=txtCategoryName.ClientID%>").value == "") {
                    document.getElementById("<%=txtCategoryName.ClientID%>").style.borderColor = "Red";
                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    $noCon("#divWarning").alert();

                    ret = false;
                }
                return ret;
               

            }
            function DuplicationName() {
               // alert();
                $noCon("#divWarning").html("Duplication Error!. Welfare service category name can’t be duplicated.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#divWarning").alert();

                return false;
            }
            function SuccessConfirmation() {
                $noCon("#success-alert").html("Welfare service category details inserted successfully.");
                $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#success-alert").alert();
                return false;
            }

            function SuccessUpdation() {
                $noCon("#success-alert").html("Welfare service category details updated successfully.");
                $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
                $noCon("#success-alert").alert();
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
                            window.location.href = "hcm_Emp_Welfare_Category_List.aspx";
                        }
                        else {
                            window.location.href = "hcm_Emp_Welfare_Service_Category.aspx";
                        }
                    });
                    return false;
                }
                else {
                    window.location.href = "hcm_Emp_Welfare_Category_List.aspx";
                }
            }
            function AlertClearAll() {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want clear all data in this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "hcm_Emp_Welfare_Service_Category.aspx";
                    }
                    else {
                        window.location.href = "hcm_Emp_Welfare_Service_Category.aspx";
                    }
                });
                return false;
            }
            function RemoveTag() {
                var SearchWithoutReplace = document.getElementById("<%=txtCategoryName.ClientID%>").value;
                       var replaceText1 = SearchWithoutReplace.replace(/</g, "");
                       var replaceText2 = replaceText1.replace(/>/g, "");
                       document.getElementById("<%=txtCategoryName.ClientID%>").value = replaceText2;

             var SearchWithoutReplace = document.getElementById("<%=txtCategoryName.ClientID%>").value;
                       var replaceText1 = SearchWithoutReplace.replace(/</g, "");
                       var replaceText2 = replaceText1.replace(/>/g, "");
                       document.getElementById("<%=txtCategoryName.ClientID%>").value = replaceText2;
         }
         function RemoveDescTag() {
             var SearchWithoutReplace = document.getElementById("<%=txtCatgoryDesc.ClientID%>").value;
            var replaceText1 = SearchWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCatgoryDesc.ClientID%>").value = replaceText2;

             var SearchWithoutReplace = document.getElementById("<%=txtCatgoryDesc.ClientID%>").value;
            var replaceText1 = SearchWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCatgoryDesc.ClientID%>").value = replaceText2;
         }
            function textCounter(field, maxlimit) {        
                RemoveTag();
                RemoveDescTag();
                if (field.value.length > maxlimit) {
                    field.value = field.value.substring(0, maxlimit);
                } else {
                    isTag(event);
                }
            }
            function isTag(evt) {
                IncrmntConfrmCounter();
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
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:HiddenField ID="hiddenCancelReason" runat="server" />
   <asp:HiddenField ID="HiddenEnableModify" runat="server" />


    <div class="cont_rght">


                
        <div class="alert alert-success" id="success-alert" style="display: none;margin-left: 0%;width: 98%;">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
                 <div class="alert alert-danger" id="divWarning" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>

          <div id="divList" class="list" tabindex="10"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:5%; top:42%;height:26.5px;">

        </div>

        <div class="fillform" style="width:100%;">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
            <br />
           <div id="divpageContent" style="margin-left:12%;">
              <div id="divCategoryName" class="eachform"  >   
                  <div class="eachform" style="width:66%">
             <h2 style="letter-spacing: 0px;">Category Name*</h2>
                <asp:TextBox ID="txtCategoryName" Height="30px" Width="50%" class="form1" runat="server" TabIndex="1" MaxLength="100" onchange="IncrmntConfrmCounter();" onkeypress="return isTag(event);" onblur="return textCounter(cphMain_txtCategoryName,190)" onkeydown=" return textCounter(cphMain_txtCategoryName,150)" Style="text-transform: uppercase; margin-right: 4%;" ></asp:TextBox>
              
                   </div></div>   
               <div id="divCatgoryDesc" class="eachform" >        <div class="eachform" style="width:66%" > 
             <h2 style="letter-spacing: 0px;">Description</h2>
                <asp:TextBox ID="txtCatgoryDesc" Height="100px" Width="50%" class="form1" runat="server" MaxLength="500" TabIndex="2" TextMode="MultiLine" onchange="IncrmntConfrmCounter();" onkeypress="return  isTag(event);" onblur="return textCounter(cphMain_txtCatgoryDesc,190)" onkeydown=" return textCounter(cphMain_txtCatgoryDesc,150)" Style="resize: none; margin-right: 4%;"></asp:TextBox>
              
                   </div></div>

           
            <div class="eachform"  > <div class="eachform" style="width:54%;padding-top: 2%;"> 
                  <h2 style="letter-spacing: 0px;">Status*</h2>
                <div class="subform"style="text-align:right" >


                    <asp:CheckBox ID="cbxStatus" TabIndex="3" Text="" runat="server" onkeydown="return DisableEnter(event)" Checked="true" class="form2" />
                    <h3>Active</h3>

                </div>                
                </div>   
            </div>
            <br />
                  </div>
            <div class="eachform">
                <div class="subform" style="width: 72%; margin-top:5%">

                    
                    <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" TabIndex="4" Text="Update" OnClientClick="return CategoryValidate();" OnClick="btnUpdate_Click"/> 
                      <asp:Button ID="btnUpdateClose" runat="server" class="btn btn-primary" TabIndex="5" Text="Update & Close"  OnClientClick="return CategoryValidate();" OnClick="btnUpdate_Click"/> 
                    <asp:Button ID="btnAdd" runat="server" class="btn btn-primary" Text="Save" TabIndex="6" OnClick="btnAdd_Click" OnClientClick="return CategoryValidate();"/>
                     <asp:Button ID="btnAddClose" runat="server" class="btn btn-primary" TabIndex="7" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return CategoryValidate();"/>
                     <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" TabIndex="8" Text="Cancel" OnClientClick="return ConfirmMessage();"/>
                 <asp:Button ID="btnClear" runat="server"  TabIndex="9" OnClientClick="return AlertClearAll();" class="btn btn-primary" Text="Clear"/> 
                </div>
            </div>

        </div>
          
    </div>
</asp:Content>

