<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefaultAutoCmplt.aspx.cs" Inherits="TEST_AUTOCMPLT_DATABASE_DefaultAutoCmplt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script type="text/javascript" src="../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <link rel="stylesheet" href="../../css/Autocomplete/jquery-ui.css" />
  <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
         <style type="text/css">
             .ui-autocomplete {
            width: 32.5% !important;
            max-height: 190px !important;
        }
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

     <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"
type = "text/javascript"></script>
<script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
type = "text/javascript"></script>
<link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
rel = "Stylesheet" type="text/css" />--%>

        <script>

            var $au = jQuery.noConflict();

            (function ($au) {
                $au(function () {
            
                    selectorToAutocompleteTextBox('txtSearch');
                });
            })(jQuery);

            
                    </script>
    <script>
        function selectorToAutocompleteTextBox(obj)
        {
            var QtnItemWithoutReplace = document.getElementById(obj).value;

            var replaceText1 = QtnItemWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/'/g, "");
            var replaceText4 = replaceText3.replace(/"/g, "");
            var replaceText5 = replaceText4.replace(/\\/g, "");
            document.getElementById(obj).value = replaceText5.trim();
            alert(obj);
            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
            var ListModId = document.getElementById("<%=hiddenLimtdMod.ClientID%>").value;
            var DivIds = document.getElementById("<%=hiddenDivisionIds.ClientID%>").value;
            alert("hello" + CorpId + " " + OrgId + " " + ListModId + " " + DivIds + " ");
            //$au('#cphMain_ddlExistingCustomer').selectToAutocomplete1Letter();
            //$au('#cphMain_ddlExistingProject').selectToAutocomplete1Letter();
            //$au('#cphMain_ddlExistingClient').selectToAutocomplete1Letter();
            //$au('#cphMain_ddlExistingContractor').selectToAutocomplete1Letter();
            //$au('#cphMain_ddlExistingConsultant').selectToAutocomplete1Letter();
            if (CorpId != '' && CorpId != null && (!isNaN(CorpId)) && OrgId != '' && OrgId != null && (!isNaN(OrgId)) && ListModId != '' && ListModId != null && (!isNaN(ListModId))) {
                $("#" + obj).autocomplete({
              
                            source: function (request, response) {
                                $.ajax({
                                    url: '<%=ResolveUrl("WebServiceACD.asmx/GetProducts") %>',
                                    data: "{ 'strLikePrdctName': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'intListingMode': '" + parseInt(ListModId) + "' ,'intOrgId': '" + parseInt(OrgId) + "', 'intCorpId': '" + parseInt(CorpId) + "', 'strDivsionIds': '" + DivIds + "'}",
                                           dataType: "json",
                                           type: "POST",
                                           contentType: "application/json; charset=utf-8",
                                           success: function (data) {
                                               response($.map(data.d, function (item) {
                                                   return {
                                                       label: item.split('<->')[0],
                                                       val: item.split('<->')[1]
                                                   }
                                               }))
                                           },
                                           error: function (response) {
                                               alert(response.responseText);
                                           },
                                           failure: function (response) {
                                               alert(response.responseText);
                                           }
                                       });
                            },
                    autoFocus: true,
              
                            select: function (e, i) {
                                $("#<%=hfFocusSelectPrdctId.ClientID %>").val(i.item.val);
                                $("#<%=hfFocusSelectPrdctName.ClientID %>").val(i.item.label);
                  //  alert(i.item.val);
                  //  alert(i.item.label);
                },

                minLength: 2

                        });
            }


        }
        </script>
    <script>

        function BlurValue()
        {
            if (document.getElementById("<%=hfFocusSelectPrdctId.ClientID%>").value == "")
            {
               
                document.getElementById("<%=txtSearch.ClientID%>").value = "--Select Item--";
            }
        
            var TxtName = document.getElementById("<%=txtSearch.ClientID%>").value.trim();
            
            if (TxtName == "" || TxtName == "--Select Item--")
            {
                document.getElementById("<%=hfFocusSelectPrdctId.ClientID%>").value = "";
                document.getElementById("<%=hfFocusSelectPrdctName.ClientID%>").value = "";
                document.getElementById("<%=txtSearch.ClientID%>").value = "--Select Item--";
            }
            var PrdctId = document.getElementById("<%=hfFocusSelectPrdctId.ClientID%>").value;
            var PrdctName = document.getElementById("<%=hfFocusSelectPrdctName.ClientID%>").value.trim();
            if (PrdctName != "") {
                document.getElementById("<%=txtSearch.ClientID%>").value = PrdctName;
            }
         //   alert("Product Id= " + PrdctId);
         //   alert("Product name= " + PrdctName);
            return false;
        }

        function ShowHiddenVal() {

            var PrdctId = document.getElementById("<%=hfFocusSelectPrdctId.ClientID%>").value;
              var PrdctName = document.getElementById("<%=hfFocusSelectPrdctName.ClientID%>").value;
              alert("Product Id= " + PrdctId);
              alert("Product name= " + PrdctName);
              return false;
          }
        </script>

</head>
<body>
    <form id="form1" runat="server">
         <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenLimtdMod" runat="server" />
    <asp:HiddenField ID="hiddenDivisionIds" runat="server" />
    <div>
    <asp:TextBox ID="txtSearch" runat="server" onblur="return BlurValue()" Text="--Select Item--"></asp:TextBox>
    <asp:HiddenField ID="hfFocusSelectPrdctId" runat="server" />
         <asp:HiddenField ID="hfFocusSelectPrdctName" runat="server" />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick = "Submit" OnClientClick="return ShowHiddenVal();" />
    </div>
    </form>
</body>
</html>
