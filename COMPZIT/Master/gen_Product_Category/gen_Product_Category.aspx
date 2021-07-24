<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Product_Category.aspx.cs" Inherits="Master_gen_Product_Category_gen_Product_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
 <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />
 <script src="/js/New js/msdropdown/jquery.dd.js"></script>
 <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/hcm_ns.css" rel="stylesheet" />
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
     <script>
         var $au = jQuery.noConflict();
         $au(function () {
             $au('#cphMain_ddlLedger').selectToAutocomplete1Letter();
             $au('#cphMain_ddlPurchase').selectToAutocomplete1Letter();
             $au('#cphMain_ddlProductGroup').selectToAutocomplete1Letter();
         });

        </script>
    <script language="javascript" type="text/javascript">
        var submit = 0;
        function CheckIsRepeat() {
            if (++submit > 1) {

                return false;
            }
            else {
                return true;
            }
        }
        function CheckSubmitZero() {
            submit = 0;
        }
    </script>
   <script>

       //start-0006
       var confirmbox = 0;

       function IncrmntConfrmCounter() {
           confirmbox++;
       }
       function ConfirmMessage() {
           if (confirmbox > 0) {
               ezBSAlert({
                   type: "confirm",
                   messageText: "Do you want to leave this page?",
                   alertType: "info"
               }).done(function (e) {
                   if (e == true) {
                       window.location.href = "gen_Product_CategoryList.aspx";
                       return false;
                   }
                   else {
                       return false;
                   }
               });
               return false;
           }
           else {
               window.location.href = "gen_Product_CategoryList.aspx";

           }
           return false;
       }
       function AlertClearAll() {
           if (confirmbox > 0) {
               ezBSAlert({
                   type: "confirm",
                   messageText: "Do you want to clear all the data from this page?",
                   alertType: "info"
               }).done(function (e) {
                   if (e == true) {
                       window.location.href = "gen_Product_Category.aspx";
                       return false;
                   }
                   else {
                       return false;
                   }
               });
               return false;
           }
           else {
               window.location.href = "gen_Product_Category.aspx";
               return false;
           }
           return false;
       }
    </script>
    <script type="text/javascript">

        function DuplicationName() {
            $("#divWarning").html("Duplication error!. Product category name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtCategoryName.ClientID%>").style.borderColor = "Red";
        }

        function DuplicationCode() {
            $("#divWarning").html("Duplication error!. Product code can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtCategoryCode.ClientID%>").style.borderColor = "Red";
        }

        function SuccessConfirmation() {
            $("#success-alert").html("Product category details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }

        function SuccessUpdation() {
            $("#success-alert").html("Product category details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }

        function NameValidate() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtCategoryName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCategoryName.ClientID%>").value = replaceText2;

            var CodeWithoutReplace = document.getElementById("<%=txtCategoryCode.ClientID%>").value;
            var replaceCode1 = CodeWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtCategoryCode.ClientID%>").value = replaceCode2;

            document.getElementById("<%=txtCategoryName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlCategoryType.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlParentCategory.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlProductGroup.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCategoryCode.ClientID%>").style.borderColor = "";
            $("div#divProductGroup input.ui-autocomplete-input").css("borderColor", "");
            var Name = document.getElementById("<%=txtCategoryName.ClientID%>").value.trim();

            var CategoryType = document.getElementById("<%=ddlCategoryType.ClientID%>");
            var CategoryId = CategoryType.options[CategoryType.selectedIndex].value;
         

            if (CategoryId == 2 || CategoryId == 3 || CategoryId == 4) {

                    var ParentCategory = document.getElementById("<%=HiddenFieldParentCtgry.ClientID%>").value;
                if (ParentCategory == "--SELECT CATEGORY--" || ParentCategory == "") {
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        document.getElementById("<%=ddlParentCategory.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=ddlParentCategory.ClientID%>").focus();
                        ret = false;
                    }

                }
                else {
                    var ProductGroup = document.getElementById("<%=ddlProductGroup.ClientID%>");
                    var ProductGroupText = ProductGroup.options[ProductGroup.selectedIndex].text;
                    var CategoryCode = document.getElementById("<%=txtCategoryCode.ClientID%>").value;
                   

                    if (ProductGroupText == "--SELECT PRODUCT GROUP--") {
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        document.getElementById("<%=ddlProductGroup.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=ddlProductGroup.ClientID%>").focus();
                        $("div#divProductGroup input.ui-autocomplete-input").css("borderColor", "red");
                        $("div#divProductGroup input.ui-autocomplete-input").select();
                        $("div#divProductGroup input.ui-autocomplete-input").focus();
                        ret = false;
                    }
                }
                if (Name == "") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                document.getElementById("<%=txtCategoryName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCategoryName.ClientID%>").focus();
                ret = false;
                }
            if (ret == false) {
                CheckSubmitZero();

            }
            return ret;
        }

        function TypeChange(x) {
            if (x == 0) {
                IncrmntConfrmCounter();
                document.getElementById("cphMain_ddlParentCategory").value = "";
                document.getElementById("<%=HiddenFieldParentCtgry.ClientID%>").value = "";
            }
            var Category = document.getElementById("<%=ddlCategoryType.ClientID%>");
            var CategoryId = Category.options[Category.selectedIndex].value;
            if (CategoryId == 2 || CategoryId == 3 || CategoryId == 4) {
                document.getElementById('divProductGroup').style.display = "none";
                document.getElementById('divCategoryCode').style.display = "none";
                document.getElementById('divParentCategory').style.display = "";
            }
            else {
                document.getElementById('divProductGroup').style.display = "";
                document.getElementById('divCategoryCode').style.display = "";
                document.getElementById('divParentCategory').style.display = "none";
            }
        }

        function CategoryCodeOpen() {
            document.getElementById('divCategoryCode').style.display = "";
        }

        function CategoryCodeClose() {
            document.getElementById('divCategoryCode').style.display = "none";
        }

    </script>
    <script type="text/javascript" language="javascript">
        // for not allowing <> tags
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
        // for not allowing enter
        function DisableEnter(evt) {

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
        function selectorToAutocompleteLeaC(ev) {
            var $au = jQuery.noConflict();
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var Product_Ctgryd = document.getElementById("<%=ddlCategoryType.ClientID%>").value;
            var EditId = document.getElementById("<%=HiddenFieldEditId.ClientID%>").value;
            if (corptID != '' && corptID != null && (!isNaN(corptID)) && orgID != '' && orgID != null && (!isNaN(orgID))) {
                $au("#cphMain_ddlParentCategory").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "gen_Product_Category.aspx/changeProdCtgry",
                            async: false,
                            data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'orgID': '" + parseInt(orgID) + "', 'corptID': '" + parseInt(corptID) + "', 'Product_Ctgryd': '" + parseInt(Product_Ctgryd) + "', 'EditId': '" + EditId + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        val: item.split('<,>')[0],
                                        label: item.split('<,>')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                            },
                            failure: function (response) {
                            }
                        });
                    },
                    autoFocus: false,
                    select: function (e, i) {
                        document.getElementById("<%=HiddenFieldParentCtgry.ClientID%>").value = i.item.val;
                        document.getElementById("cphMain_ddlParentCategory").value = i.item.label;
                    },
                    change: function (event, ui) {
                        if (ui.item) {
                        }
                        else {
                            document.getElementById("cphMain_ddlParentCategory").value = "";
                            document.getElementById("<%=HiddenFieldParentCtgry.ClientID%>").value = "";
                        }
                    }
                });
            }
        }
    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <ol class="breadcrumb">
       <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
      <li><a href="gen_Product_CategoryList.aspx">Product Category</a></li>
        <li id="lblEntryB" runat="server" class="active">Add Product Category</li>
      </ol>
     <asp:HiddenField ID="HiddenFieldEditId" runat="server" />
     <asp:HiddenField ID="HiddenFieldParentCtgry" runat="server" /> 
   <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
    <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">Add Product Category</h2>

               <div class="form-group fg2 sa_fg4 sa_480" style=" padding-bottom: 2px;">
               <label for="email" class="fg2_la1">Category Type:<span class="spn1">*</span></label>
                <select class="form-control fg2_inp1 inp_mst" id="ddlCategoryType" runat="server"  onchange=" TypeChange(0);">
                  <option value='1' data-image="\Images\opp\c1.png" data-imagecss="flag ad" data-title="Main Category">Main Category</option>
                  <option value='2' data-image="\Images\opp\c2.png" data-imagecss="flag ae" data-title="Sub Category">Sub Category</option>
                  <option value='3' data-image="\Images\opp\c3.png" data-imagecss="flag af" data-title="Small Category">Small Category</option>
                  <option value='4' data-image="\Images\opp\c4.png" data-imagecss="flag ag" data-title="Least Category">Least Category</option>
                </select> 
              </div>
              <div class="form-group fg2 sa_fg4 sa_480">
                <label for="email" class="fg2_la1">Category Name:<span class="spn1">*</span></label>
                   <asp:TextBox ID="txtCategoryName" class="form-control fg2_inp1 inp_mst" placeholder="Category Name" runat="server" MaxLength="300" Style="text-transform: uppercase;"></asp:TextBox>
              </div>


            <div class="form-group fg2 sa_fg4 sa_480" id="divParentCategory" style="display:none">
               <label for="email" class="fg2_la1">Parent Category:<span class="spn1">*</span></label>
                 <asp:TextBox ID="ddlParentCategory" class="form-control fg2_inp1 inp_mst" placeholder="--SELECT CATEGORY--" runat="server" MaxLength="100" Style="text-transform: uppercase;" onkeypress="return selectorToAutocompleteLeaC(event);" onkeydown="return selectorToAutocompleteLeaC(event);"></asp:TextBox>
              </div>


              <div class="form-group fg2 sa_fg4 sa_480" id="divProductGroup" >
               <label for="email" class="fg2_la1">Product Group:<span class="spn1">*</span></label>
                <asp:DropDownList class="form-control fg2_inp1 inp_mst" id="ddlProductGroup" runat="server"></asp:DropDownList>
              </div>
             <div class="form-group fg2 sa_fg4 sa_480" id="divCategoryCode" style="display:none;">
                <label for="email" class="fg2_la1">Product Code:<span class="spn1"></span></label>
                   <asp:TextBox ID="txtCategoryCode" class="form-control fg2_inp1" placeholder="Product Code" runat="server" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox>
              </div>

              <div class="form-group fg2 sa_fg4 sa_480">
               <label for="email" class="fg2_la1">Sale Ledger:<span class="spn1"></span></label>
                <asp:DropDownList ID="ddlLedger" class="form-control fg2_inp1" runat="server"></asp:DropDownList>
              </div>
             

              <div class="form-group fg2 sa_fg4 sa_480">
               <label for="email" class="fg2_la1">Purchase Ledger:<span class="spn1"></span></label>
               <asp:DropDownList ID="ddlPurchase" class="form-control fg2_inp1" runat="server"></asp:DropDownList>
              </div>
              
                <div class="form-group fg2 fg2_mr">
                <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
                <div class="check1 tr_l">
                  <div class="">
                    <label class="switch">
                      <input type="checkbox" id="cbxStatus" runat="server" checked="checked"/>
                      <span class="slider_tog round"></span>
                    </label>
                  </div>
                </div>
              </div>
    
        <div class="clearfix"></div>
        <div class="devider"></div>

        <div class="sub_cont pull-right">
          <div class="save_sec">
            <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
            <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
            <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2" Text="Clear"/>
            <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();"  />
          </div>
        </div>
        
      </div>
    </div>
    </div>
     <div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">
         <asp:Button ID="btnUpdateF" runat="server" class="btn sub1 bt_b" Text="Update" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnUpdateCloseF" runat="server" class="btn sub3 bt_b" Text="Update & Close" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnAddF" runat="server" class="btn sub1 bt_b" Text="Save" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
            <asp:Button ID="btnAddCloseF" runat="server" class="btn sub3 bt_b" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
               <asp:Button ID="btnClearF" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2 bt_b" Text="Clear"/>
              <asp:Button ID="btnCancelF" runat="server" class="btn sub4 bt_b" Text="Cancel" OnClientClick="return ConfirmMessage();"  />
  </div> 
</div>
<a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
<i class="fa fa-save"></i>
</a>

       <!---back_button_fixed_section--->
  <a href="#" type="button" class="list_b" title="Back to List" onclick="return ConfirmMessage();" id="divList" runat="server">
    <i class="fa fa-arrow-circle-left"></i>
  </a>
<!---back_button_fixed_section--->
  <!--save_pop up_open-->
<script>
    function opensave() {
        document.getElementById("cphMain_mySave").style.width = "140px";
    }

    function closesave() {
        document.getElementById("cphMain_mySave").style.width = "0px";
    }
</script>
    <style>
         .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            width: 218px;
            border: 1px solid #B0BECA;
            max-height: 140px;
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
                .dd .ddTitle .ddTitleText {
    padding: 7px 20px 7px 5px;
}
                .dd .divider {
    border-left: none;
}
         #cphMain_ddlCategoryType_msdd:focus {
            border: 1px solid #48acf2 !important;
        }
          .disabledAll{
   background-color: #eee !important;
opacity: 1 !important;
color: #999 !important;
cursor: not-allowed !important;
 border: 1px solid #ffbfbf !important;
}

 .flag {
    padding: 0 !important;
    margin: 0 5px 0 0;
}
    </style>
    <script>
        $(document).ready(function () {
            var $aus = jQuery.noConflict();
            $aus("#cphMain_ddlCategoryType").msDropdown({ roundedBorder: false });
            $aus("#cphMain_ddlCategoryType").msDropdown({ visibleRows: 4 });
            $aus("").msDropdown();
            if (document.getElementById("cphMain_lblEntry").innerText != "VIEW PRODUCT CATEGORY")
            document.getElementById("cphMain_ddlCategoryType_msdd").focus();           
            TypeChange(1);
        });
</script>
<script>
    $(document).on('keydown', function (e) {
        var keyCode = e.keyCode || e.which;
        if (keyCode == 9) {
            $('.dd .ddChild').hide();
        }
    });
</script> 
</asp:Content>
