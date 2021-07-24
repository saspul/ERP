<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Lead.aspx.cs" Inherits="MasterPage_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
 <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
 <script src="/js/New%20js/date_pick/datepicker.js"></script>
 <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />
 <script src="/js/New js/msdropdown/jquery.dd.js"></script>
 <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/hcm_ns.css" rel="stylesheet" />
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
     <script language="javascript" type="text/javascript">
         //for disable second click
         var submit = 0;
         function CheckIsRepeat() {
             if (++submit > 1) {
                 //   alert('An attempt was made to submit this form more than once; this extra attempt will be ignored.');
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
            history.pushState(null, null, document.URL);
            window.addEventListener('popstate', function () {
                history.pushState(null, null, document.URL);
            });
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
                         if (document.getElementById("<%=hiddenL_MODE.ClientID%>").value != "") {
                             window.location.href = "gen_LeadList.aspx?L_MODE=" + document.getElementById("<%=hiddenL_MODE.ClientID%>").value + "";
                         }
                         else {
                             window.location.href = "gen_LeadList.aspx";
                         }
                         return false;
                     }
                     else {
                         return false;
                     }
                 });               
             }
             else {
                 if (document.getElementById("<%=hiddenL_MODE.ClientID%>").value != "") {
                     window.location.href = "gen_LeadList.aspx?L_MODE=" + document.getElementById("<%=hiddenL_MODE.ClientID%>").value + "";
                 }
                 else {
                     window.location.href = "gen_LeadList.aspx";
                 }
             }
             return false;
         }
         function ConfirmMessage1() {
             if (confirmbox > 0) {
                 ezBSAlert({
                     type: "confirm",
                     messageText: "Do you want to leave this page?",
                     alertType: "info"
                 }).done(function (e) {
                     if (e == true) {
                         __doPostBack("<%=Button1.UniqueID %>", "");
                         return false;
                     }
                     else {
                         return false;
                     }
                 });               
             }
             else {
                 __doPostBack("<%=Button1.UniqueID %>", "");
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
                         if (document.getElementById("<%=hiddenL_MODE.ClientID%>").value != "") {
                             window.location.href = "gen_Lead.aspx?L_MODE=" + document.getElementById("<%=hiddenL_MODE.ClientID%>").value + "";
                         }
                         else {
                             window.location.href = "gen_Lead.aspx";
                         }
                         return false;
                     }
                     else {
                         return false;
                     }
                 });
                 return false;
             }
             else {
                 if (document.getElementById("<%=hiddenL_MODE.ClientID%>").value != "") {
                     window.location.href = "gen_Lead.aspx?L_MODE=" + document.getElementById("<%=hiddenL_MODE.ClientID%>").value + "";
                 }
                 else {
                     window.location.href = "gen_Lead.aspx";
                 }
                 return false;
             }
             return false;
         }
         function selectorToAutocompleteState(ev) {
             var $au = jQuery.noConflict();
             var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
              var countryID = document.getElementById("cphMain_ddlCountry").value;
              if (countryID != "--Select Country--" && countryID != "" && corptID != '' && corptID != null && (!isNaN(corptID)) && orgID != '' && orgID != null && (!isNaN(orgID))) {
                  $au("#cphMain_ddlState").autocomplete({
                      source: function (request, response) {
                          $.ajax({
                              url: "gen_Lead.aspx/changeState",
                              async: false,
                              data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'orgID': '" + parseInt(orgID) + "', 'corptID': '" + parseInt(corptID) + "', 'countryID': '" + parseInt(countryID) + "'}",
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
                          document.getElementById("<%=HiddenFieldState.ClientID%>").value = i.item.val;
                        document.getElementById("cphMain_ddlState").value = i.item.label;
                    },
                    change: function (event, ui) {
                        if (ui.item) {
                        }
                        else {
                            document.getElementById("cphMain_ddlState").value = "";
                            document.getElementById("<%=HiddenFieldState.ClientID%>").value = "";
                        }
                    }
                });
            }
        }
        function selectorToAutocompleteCity(ev) {
            var $au = jQuery.noConflict();
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var stateID = document.getElementById("<%=HiddenFieldState.ClientID%>").value;
            if (stateID != "" && corptID != '' && corptID != null && (!isNaN(corptID)) && orgID != '' && orgID != null && (!isNaN(orgID))) {
                $au("#cphMain_ddlCity").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "gen_Lead.aspx/changeCity",
                            async: false,
                            data: "{ 'strLikeEmployee': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'orgID': '" + parseInt(orgID) + "', 'corptID': '" + parseInt(corptID) + "', 'stateID': '" + parseInt(stateID) + "'}",
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
                        document.getElementById("cphMain_ddlCity").value = i.item.label;
                        document.getElementById("<%=HiddenFieldCity.ClientID%>").value = i.item.val;
                    },
                    change: function (event, ui) {
                        if (ui.item) {

                        }
                        else {
                            document.getElementById("cphMain_ddlCity").value = "";
                            document.getElementById("<%=HiddenFieldCity.ClientID%>").value = "";
                        }
                    }
                });
            }
        }
        function changeCountry() {
            document.getElementById("cphMain_ddlState").value = "";
            document.getElementById("<%=HiddenFieldState.ClientID%>").value = "";
            document.getElementById("cphMain_ddlCity").value = "";
            document.getElementById("<%=HiddenFieldCity.ClientID%>").value = "";
            IncrmntConfrmCounter();
        }
        function changeState() {         
            document.getElementById("cphMain_ddlCity").value = "";
            document.getElementById("<%=HiddenFieldCity.ClientID%>").value = "";
            if (document.getElementById("<%=HiddenFieldState.ClientID%>").value == "") {
                document.getElementById("cphMain_ddlState").value = "";
            }
            IncrmntConfrmCounter();
        }
        function changeCity() {           
            if (document.getElementById("<%=HiddenFieldCity.ClientID%>").value == "") {
                document.getElementById("cphMain_ddlCity").value = "";
            }
            IncrmntConfrmCounter();
        }
         //stop-0006
    </script>
    <script>
        function ErrorMsg() {
            $("#divWarning").html("Some error occured.Please review entered information !");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });         
        }
        function RemoveTag(control) {
            var text = control.value;
            var replaceText1 = text.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            control.value = replaceText2;
        }
        function RemoveTagMultiLine(control) {

            var text = control.value;
            var replaceText1 = text.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            control.value = replaceText2;
        }
        function NumberOnly(control) {
            //     var ret = true;
            var txtPerVal = control.value;
            if (txtPerVal == "") {
                return false;
            }
            else {
                if (!isNaN(txtPerVal) == false) {
                    control.value = "";
                    return false;
                }
                else {
                    //var amt = parseFloat(txtPerVal);
                    //var num = amt;
                    //var n = 0;
                    // for floatting number adjustment from corp global
                    //var FloatingValue = control.value;
                    //if (FloatingValue != "") {
                    //var n = num.toFixed(FloatingValue);
                    //}
                    //control.value = n;

                }
            }
        }

        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }

        function textCheck(field, maxlimit) {
            var text = field.value;
            var replaceText1 = text.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            field.value = replaceText2;
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }
       
        function VisibleContactOne() {
            if ($('#divNewContactOne:visible').length == 0) {
                document.getElementById('divNewContactOne').style.display = "";             
                document.getElementById("<%=txtNameOne.ClientID%>").focus();
            }
            else {
                document.getElementById('divNewContactOne').style.display = "none";
            }
            return false;
        }
        function VisibleContactTwo() {
            if ($('#divNewContactTwo:visible').length == 0) {
                if (document.getElementById("<%=txtNameOne.ClientID%>").value == "") {
                    document.getElementById("<%=txtNameOne.ClientID%>").focus();
                }
                else {
                    if (document.getElementById("<%=txtAddressOne.ClientID%>").value == "") {
                        document.getElementById("<%=txtAddressOne.ClientID%>").focus();
                    }
                    else {
                        document.getElementById('divNewContactTwo').style.display = "";
                        //document.getElementById('ClearTwo').style.display = "";
                        document.getElementById("<%=txtNameTwo.ClientID%>").focus();
                    }
                }
            }
            else {
                document.getElementById('divNewContactTwo').style.display = "none";
              
            }
            return false;
        }
        function VisibleContactThree() {
            if ($('#divNewContactThree:visible').length == 0) {
                if (document.getElementById("<%=txtNameOne.ClientID%>").value == "") {
                    document.getElementById("<%=txtNameOne.ClientID%>").focus();
                }
                else {
                    if (document.getElementById("<%=txtAddressOne.ClientID%>").value == "") {
                        document.getElementById("<%=txtAddressOne.ClientID%>").focus();
                    }
                    else {
                        if (document.getElementById("<%=txtNameTwo.ClientID%>").value == "") {
                            document.getElementById("<%=txtNameTwo.ClientID%>").focus();
                        }
                        else {
                            if (document.getElementById("<%=txtAddressTwo.ClientID%>").value == "") {
                                document.getElementById("<%=txtAddressTwo.ClientID%>").focus();
                            }
                            else {
                                document.getElementById('divNewContactThree').style.display = "";
                                //document.getElementById('ClearThree').style.display = "";
                                document.getElementById("<%=txtNameThree.ClientID%>").focus();
                            }
                        }
                    }
                }
            }
            else {
                document.getElementById('divNewContactThree').style.display = "none";
                //document.getElementById('ClearThree').style.display = "none";
            }
            return false;
        }
        function ClearContactOne() {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to clear this contact details?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=txtNameOne.ClientID%>").value = "";
                    document.getElementById("<%=txtAddressOne.ClientID%>").value = "";
                    document.getElementById("<%=txtMobileOne.ClientID%>").value = "";
                    document.getElementById("<%=txtPhoneOne.ClientID%>").value = "";
                    document.getElementById("<%=txtEmailOne.ClientID%>").value = "";
                    document.getElementById("<%=txtWebsiteOne.ClientID%>").value = "";
                    document.getElementById("<%=txtNameOne.ClientID%>").focus();
                    return false;
                }
                else {
                    document.getElementById("<%=txtNameOne.ClientID%>").focus();
                    return false;
                }
            });           
            return false;
        }

        function ClearContactTwo() {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to clear this contact details?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=txtNameTwo.ClientID%>").value = "";
                    document.getElementById("<%=txtAddressTwo.ClientID%>").value = "";
                    document.getElementById("<%=txtMobileTwo.ClientID%>").value = "";
                    document.getElementById("<%=txtPhoneTwo.ClientID%>").value = "";
                    document.getElementById("<%=txtEmailTwo.ClientID%>").value = "";
                    document.getElementById("<%=txtWebsiteTwo.ClientID%>").value = "";
                    document.getElementById("<%=txtNameTwo.ClientID%>").focus();
                    return false;
                }
                else {
                    document.getElementById("<%=txtNameTwo.ClientID%>").focus();
                    return false;
                }
            });           
            return false;
        }

        function ClearContactThree() {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to clear this contact details?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=txtNameThree.ClientID%>").value = "";
                    document.getElementById("<%=txtAddressThree.ClientID%>").value = "";
                    document.getElementById("<%=txtMobileThree.ClientID%>").value = "";
                    document.getElementById("<%=txtPhoneThree.ClientID%>").value = "";
                    document.getElementById("<%=txtEmailThree.ClientID%>").value = "";
                    document.getElementById("<%=txtWebsiteThree.ClientID%>").value = "";
                    document.getElementById("<%=txtNameThree.ClientID%>").focus();
                    return false;
                }
                else {
                    document.getElementById("<%=txtNameThree.ClientID%>").focus();
                    return false;
                }
            });           
            return false;
        }


        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 38 || keyCodes == 40 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46) {
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
        function isTagForMltline(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
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
        function CustomerFocus() {

            var DropDownCustomer = document.getElementById("<%=ddlExistingCustomer.ClientID%>");
            var DropDownCustomerValue = DropDownCustomer.value;
            document.getElementById("<%=HiddenCustomerFocus.ClientID%>").value = DropDownCustomerValue;
           // alert(document.getElementById("<%=HiddenCustomerFocus.ClientID%>").value);
        }
        function CustomerLoad() {
            var $noC = jQuery.noConflict();
            var DropDownCustomer = document.getElementById("<%=ddlExistingCustomer.ClientID%>");
            var DropDownCustomerValue = DropDownCustomer.value;
            var FocusCustomerValue = document.getElementById("<%=HiddenCustomerFocus.ClientID%>").value
            if (DropDownCustomerValue != FocusCustomerValue) {

                document.getElementById("<%=ddlExistingCustomer.ClientID%>").style.borderColor = "";
                $noC("div#divExistingCust input.ui-autocomplete-input").css("borderColor", "");


                ezBSAlert({
                    type: "confirm",
                    messageText: "If you change the customer/company then  details may change",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        IncrmntConfrmCounter();
                        var ExistCustomer = document.getElementById("<%=ddlExistingCustomer.ClientID%>");



                       var Details = PageMethods.CustomerDetails(ExistCustomer.value, function (response) {

                           var CustomerList = response;
                           var CustLength = response.length;
                           //for (var count = 0; count < CustLength; count++) {

                           document.getElementById("<%=txtAddress1.ClientID%>").value = CustomerList[0];
                        document.getElementById("<%=txtAddress2.ClientID%>").value = CustomerList[1];
                        document.getElementById("<%=txtAddress3.ClientID%>").value = CustomerList[2];

                           //country loading
                           document.getElementById("cphMain_ddlCountry").value=CustomerList[33];
                           $noC("div#divCou input.ui-autocomplete-input").val(CustomerList[3]);
                        
                        //state loading
                           if (document.getElementById('cphMain_ddlCountry').value == "--SELECT YOUR COUNTRY--") { }
                           else {
                               document.getElementById("cphMain_ddlState").value=CustomerList[4];
                               document.getElementById("<%=HiddenFieldState.ClientID%>").value=CustomerList[34];
                        }

                        //city loading
                           if (document.getElementById("<%=HiddenFieldState.ClientID%>").value == "") { }
                           else {
                               document.getElementById("cphMain_ddlCity").value=CustomerList[5];
                               document.getElementById("<%=HiddenFieldCity.ClientID%>").value=CustomerList[35];
                          
                        }


                        document.getElementById("<%=txtZipCode.ClientID%>").value = CustomerList[6];
                       
                        document.getElementById("<%=txtMobile.ClientID%>").value = CustomerList[8];
                        document.getElementById("<%=txtPhone.ClientID%>").value = CustomerList[9];
                        document.getElementById("<%=txtEmail.ClientID%>").value = CustomerList[10];
                        document.getElementById("<%=txtWebSite.ClientID%>").value = CustomerList[11];

                        document.getElementById("<%=txtNameOne.ClientID%>").value = CustomerList[12];
                        document.getElementById("<%=txtAddressOne.ClientID%>").value = CustomerList[13];
                        document.getElementById("<%=txtMobileOne.ClientID%>").value = CustomerList[14];
                        document.getElementById("<%=txtPhoneOne.ClientID%>").value = CustomerList[15];
                        document.getElementById("<%=txtEmailOne.ClientID%>").value = CustomerList[16];
                        document.getElementById("<%=txtWebsiteOne.ClientID%>").value = CustomerList[17];

                        if (CustomerList[30] == "1") {
                            document.getElementById("<%=cbxAllowOtherMailOne.ClientID%>").checked = true;
                        }


                        document.getElementById("<%=txtNameTwo.ClientID%>").value = CustomerList[18];
                        document.getElementById("<%=txtAddressTwo.ClientID%>").value = CustomerList[19];
                        document.getElementById("<%=txtMobileTwo.ClientID%>").value = CustomerList[20];
                        document.getElementById("<%=txtPhoneTwo.ClientID%>").value = CustomerList[21];
                        document.getElementById("<%=txtEmailTwo.ClientID%>").value = CustomerList[22];
                        document.getElementById("<%=txtWebsiteTwo.ClientID%>").value = CustomerList[23];

                        if (CustomerList[31] == "1") {
                            document.getElementById("<%=cbxAllowOtherMailTwo.ClientID%>").checked = true;
                        }

                        document.getElementById("<%=txtNameThree.ClientID%>").value = CustomerList[24];
                        document.getElementById("<%=txtAddressThree.ClientID%>").value = CustomerList[25];
                        document.getElementById("<%=txtMobileThree.ClientID%>").value = CustomerList[26];
                        document.getElementById("<%=txtPhoneThree.ClientID%>").value = CustomerList[27];
                        document.getElementById("<%=txtEmailThree.ClientID%>").value = CustomerList[28];
                        document.getElementById("<%=txtWebsiteThree.ClientID%>").value = CustomerList[29];

                        if (CustomerList[32] == "1") {
                            document.getElementById("<%=cbxAllowOtherMailThree.ClientID%>").checked = true;
                        }
                        //}

                        var Details = PageMethods.MeadiaDetails(ExistCustomer.value, function (response) {
                            var Array = response;
                            var ArrayLength = response.length;
                            for (var count = 0; count < ArrayLength; count++) {
                                var Id = Array[count][0];
                                var Detail = Array[count][1];
                                try {
                                    document.getElementById(Id).value = Detail;
                                    AssignMediaValues(document.getElementById(Id));
                                }
                                catch (err) {
                                }
                            }
                        });

                    });
                     return false;
                    }
                    else {
                        document.getElementById("<%=ddlExistingCustomer.ClientID%>").value = FocusCustomerValue;
                        var a = $noC("#cphMain_ddlExistingCustomer option:selected").text();
                        $noC("div#divExistingCust input.ui-autocomplete-input").val(a);
                        return false;
                    }
                });              
            }
            return false;
        }


        //toload custi=omer data when a new customer is added from customer master
        function NewCustomerLoad() {
            ClearAll();
            IncrmntConfrmCounter();
            var ExistCustomer = document.getElementById("<%=ddlExistingCustomer.ClientID%>");



              var Details = PageMethods.CustomerDetails(ExistCustomer.value, function (response) {

                  var CustomerList = response;
                  var CustLength = response.length;
                  //for (var count = 0; count < CustLength; count++) {

                  document.getElementById("<%=txtAddress1.ClientID%>").value = CustomerList[0];
                        document.getElementById("<%=txtAddress2.ClientID%>").value = CustomerList[1];
                        document.getElementById("<%=txtAddress3.ClientID%>").value = CustomerList[2];




                  //country loading
                  document.getElementById("cphMain_ddlCountry").value=CustomerList[33];
                  $noC("div#divCou input.ui-autocomplete-input").val(CustomerList[3]);
                       

                  //state loading
                  if (document.getElementById('cphMain_ddlCountry').value == "--SELECT YOUR COUNTRY--") { }
                  else {
                      document.getElementById("cphMain_ddlState").value=CustomerList[4];
                      document.getElementById("<%=HiddenFieldState.ClientID%>").value=CustomerList[34];
                           }

                  //city loading
                  if (document.getElementById("<%=HiddenFieldState.ClientID%>").value == "") { }
                  else {
                      document.getElementById("cphMain_ddlCity").value=CustomerList[5];
                      document.getElementById("<%=HiddenFieldCity.ClientID%>").value=CustomerList[35];
                          
                           }


                     


                        document.getElementById("<%=txtZipCode.ClientID%>").value = CustomerList[6];
                       
                        document.getElementById("<%=txtMobile.ClientID%>").value = CustomerList[8];
                        document.getElementById("<%=txtPhone.ClientID%>").value = CustomerList[9];
                        document.getElementById("<%=txtEmail.ClientID%>").value = CustomerList[10];
                        document.getElementById("<%=txtWebSite.ClientID%>").value = CustomerList[11];

                        document.getElementById("<%=txtNameOne.ClientID%>").value = CustomerList[12];
                        document.getElementById("<%=txtAddressOne.ClientID%>").value = CustomerList[13];
                        document.getElementById("<%=txtMobileOne.ClientID%>").value = CustomerList[14];
                        document.getElementById("<%=txtPhoneOne.ClientID%>").value = CustomerList[15];
                        document.getElementById("<%=txtEmailOne.ClientID%>").value = CustomerList[16];
                        document.getElementById("<%=txtWebsiteOne.ClientID%>").value = CustomerList[17];

                        document.getElementById("<%=txtNameTwo.ClientID%>").value = CustomerList[18];
                        document.getElementById("<%=txtAddressTwo.ClientID%>").value = CustomerList[19];
                        document.getElementById("<%=txtMobileTwo.ClientID%>").value = CustomerList[20];
                        document.getElementById("<%=txtPhoneTwo.ClientID%>").value = CustomerList[21];
                        document.getElementById("<%=txtEmailTwo.ClientID%>").value = CustomerList[22];
                        document.getElementById("<%=txtWebsiteTwo.ClientID%>").value = CustomerList[23];

                        document.getElementById("<%=txtNameThree.ClientID%>").value = CustomerList[24];
                        document.getElementById("<%=txtAddressThree.ClientID%>").value = CustomerList[25];
                        document.getElementById("<%=txtMobileThree.ClientID%>").value = CustomerList[26];
                        document.getElementById("<%=txtPhoneThree.ClientID%>").value = CustomerList[27];
                        document.getElementById("<%=txtEmailThree.ClientID%>").value = CustomerList[28];
                        document.getElementById("<%=txtWebsiteThree.ClientID%>").value = CustomerList[29];

                        //}

                        var Details = PageMethods.MeadiaDetails(ExistCustomer.value, function (response) {
                            var Array = response;
                            var ArrayLength = response.length;
                            for (var count = 0; count < ArrayLength; count++) {
                                var Id = Array[count][0];
                                var Detail = Array[count][1];
                                try {
                                    document.getElementById(Id).value = Detail;
                                    AssignMediaValues(document.getElementById(Id));
                                }
                                catch (err) {
                                }
                            }
                        });

                    });

                    return false;

        }
        function ClearAll() {

            var Details = PageMethods.CreateMedia(function (response) {
                var Media = response;
                document.getElementById('cphMain_divMedia').innerHTML = Media;
            });

            document.getElementById("<%=txtCustName.ClientID%>").value = "";
            document.getElementById("<%=txtAddress1.ClientID%>").value = "";
            document.getElementById("<%=txtAddress2.ClientID%>").value = "";
            document.getElementById("<%=txtAddress3.ClientID%>").value = "";          
            document.getElementById("<%=txtZipCode.ClientID%>").value = "";
           
            document.getElementById("<%=txtMobile.ClientID%>").value = "";
            document.getElementById("<%=txtPhone.ClientID%>").value = "";
            document.getElementById("<%=txtEmail.ClientID%>").value = "";
            document.getElementById("<%=txtWebSite.ClientID%>").value = "";

            document.getElementById("<%=txtNameOne.ClientID%>").value = "";
            document.getElementById("<%=txtAddressOne.ClientID%>").value = "";
            document.getElementById("<%=txtMobileOne.ClientID%>").value = "";
            document.getElementById("<%=txtPhoneOne.ClientID%>").value = "";
            document.getElementById("<%=txtEmailOne.ClientID%>").value = "";
            document.getElementById("<%=txtWebsiteOne.ClientID%>").value = "";

            document.getElementById("<%=txtNameTwo.ClientID%>").value = "";
            document.getElementById("<%=txtAddressTwo.ClientID%>").value = "";
            document.getElementById("<%=txtMobileTwo.ClientID%>").value = "";
            document.getElementById("<%=txtPhoneTwo.ClientID%>").value = "";
            document.getElementById("<%=txtEmailTwo.ClientID%>").value = "";
            document.getElementById("<%=txtWebsiteTwo.ClientID%>").value = "";

            document.getElementById("<%=txtNameThree.ClientID%>").value = "";
            document.getElementById("<%=txtAddressThree.ClientID%>").value = "";
            document.getElementById("<%=txtMobileThree.ClientID%>").value = "";
            document.getElementById("<%=txtPhoneThree.ClientID%>").value = "";
            document.getElementById("<%=txtEmailThree.ClientID%>").value = "";
            document.getElementById("<%=txtWebsiteThree.ClientID%>").value = "";



            document.getElementById("cphMain_ddlCountry").value="--SELECT YOUR COUNTRY--";
            $noC("div#divCou input.ui-autocomplete-input").val("--SELECT YOUR COUNTRY--");                                 
           document.getElementById("cphMain_ddlState").value="";
           document.getElementById("<%=HiddenFieldState.ClientID%>").value="";            
           document.getElementById("cphMain_ddlCity").value="";
           document.getElementById("<%=HiddenFieldCity.ClientID%>").value="";
                          


        }

    </script> 
    <script>
        var $noC = jQuery.noConflict();
        function SuccessConfirmation() {
            $("#success-alert").html("New opportunity inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });          
        }
        function SuccessUpdation() {
            $("#success-alert").html("Opportunity updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function NoTeam() {             
            alert('Sorry you are not defined under any team !');
            window.location = '/Transaction/gen_Lead/gen_LeadList.aspx';
        }

        function DuplicationCustomer() {
            $("#divWarning").html("Duplication error!. Customer name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtCustName.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtCustName.ClientID%>").focus();
        }
        function DuplicationProject() {
            $("#divWarning").html("Duplication error!. Project name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtProject.ClientID%>").style.borderColor = "Red";         
            document.getElementById("<%=txtProject.ClientID%>").focus();
            if (document.getElementById("<%=cbxExistingProject.ClientID%>").checked == false) {
                document.getElementById("divExistingProject").style.display = "none";
                document.getElementById("divNewProject").style.display = ""
            }
            else {
                document.getElementById("divNewProject").style.display = "none";
                document.getElementById("divExistingProject").style.display = "";

            }
        }
        function DuplicationProjectClientside() {
            $("#divWarning").html("Duplication error!. Project name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtProject.ClientID%>").style.borderColor = "Red";
               document.getElementById("<%=txtProject.ClientID%>").focus();
               if (document.getElementById("<%=cbxExistingProject.ClientID%>").checked == false) {
                   document.getElementById("divExistingProject").style.display = "none";
                   document.getElementById("divNewProject").style.display = ""
               }
               else {
                   document.getElementById("divNewProject").style.display = "none";
                   document.getElementById("divExistingProject").style.display = "";

               }
           
           }
        function DuplicationClient() {
            $("#divWarning").html("Duplication error!. Client name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtClient.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtClient.ClientID%>").focus();
        }
        function DuplicationContractor() {
            $("#divWarning").html("Duplication error!. Contractor name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtContractor.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtContractor.ClientID%>").focus();
        }
        function DuplicationConsultant() {
            $("#divWarning").html("Duplication error!. Consultant name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtConsultant.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtConsultant.ClientID%>").focus();
        }
        function SaveValidate() {
            var $noC = jQuery.noConflict();
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            //replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtCustName.ClientID%>").value;
            var NamereplaceText1 = NameWithoutReplace.replace(/</g, "");
            var NamereplaceText2 = NamereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCustName.ClientID%>").value = NamereplaceText2;

            var DesptnWithoutReplace = document.getElementById("<%=CKEditorDescription.ClientID%>").value;
           var DesptnreplaceText1 = DesptnWithoutReplace.replace(/</g, "");
            var DesptnreplaceText2 = DesptnreplaceText1.replace(/>/g, "");
            document.getElementById("<%=CKEditorDescription.ClientID%>").value = DesptnreplaceText2;

            var TitleWithoutReplace = document.getElementById("<%=txtTitle.ClientID%>").value;
            var TitlereplaceText1 = TitleWithoutReplace.replace(/</g, "");
            var TitlereplaceText2 = TitlereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTitle.ClientID%>").value = TitlereplaceText2;

            var ComntsWithoutReplace = document.getElementById("<%=txtComments.ClientID%>").value;
            var ComntsreplaceText1 = ComntsWithoutReplace.replace(/</g, "");
            var ComntsreplaceText2 = ComntsreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtComments.ClientID%>").value = ComntsreplaceText2;

            var PjctWithoutReplace = document.getElementById("<%=txtProject.ClientID%>").value;
            var PjctreplaceText1 = PjctWithoutReplace.replace(/</g, "");
            var PjctreplaceText2 = PjctreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtProject.ClientID%>").value = PjctreplaceText2;

            var ClientWithoutReplace = document.getElementById("<%=txtClient.ClientID%>").value;
            var ClientreplaceText1 = ClientWithoutReplace.replace(/</g, "");
            var ClientreplaceText2 = ClientreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtClient.ClientID%>").value = ClientreplaceText2;

            var CnctrWithoutReplace = document.getElementById("<%=txtContractor.ClientID%>").value;
            var CnctrreplaceText1 = CnctrWithoutReplace.replace(/</g, "");
            var CnctrreplaceText2 = CnctrreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtContractor.ClientID%>").value = CnctrreplaceText2;

            var ConsltWithoutReplace = document.getElementById("<%=txtConsultant.ClientID%>").value;
            var ConsltreplaceText1 = ConsltWithoutReplace.replace(/</g, "");
            var ConsltreplaceText2 = ConsltreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtConsultant.ClientID%>").value = ConsltreplaceText2;

            var Add1WithoutReplace = document.getElementById("<%=txtAddress1.ClientID%>").value;
            var Add1replaceText1 = Add1WithoutReplace.replace(/</g, "");
            var Add1replaceText2 = Add1replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAddress1.ClientID%>").value = Add1replaceText2;

            var Add2WithoutReplace = document.getElementById("<%=txtAddress2.ClientID%>").value;
            var Add2replaceText1 = Add2WithoutReplace.replace(/</g, "");
            var Add2replaceText2 = Add2replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAddress2.ClientID%>").value = Add2replaceText2;

            var Add3WithoutReplace = document.getElementById("<%=txtAddress3.ClientID%>").value;
            var Add3replaceText1 = Add3WithoutReplace.replace(/</g, "");
            var Add3replaceText2 = Add3replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAddress3.ClientID%>").value = Add3replaceText2;

            var ZipWithoutReplace = document.getElementById("<%=txtZipCode.ClientID%>").value;
            var ZipreplaceText1 = ZipWithoutReplace.replace(/</g, "");
            var ZipreplaceText2 = ZipreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtZipCode.ClientID%>").value = ZipreplaceText2;

           

            var MobWithoutReplace = document.getElementById("<%=txtMobile.ClientID%>").value;
            var MobreplaceText1 = MobWithoutReplace.replace(/</g, "");
            var MobreplaceText2 = MobreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtMobile.ClientID%>").value = MobreplaceText2;

            var PhoneWithoutReplace = document.getElementById("<%=txtPhone.ClientID%>").value;
            var PhonereplaceText1 = PhoneWithoutReplace.replace(/</g, "");
            var PhonereplaceText2 = PhonereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtPhone.ClientID%>").value = PhonereplaceText2;

            var EmailWithoutReplace = document.getElementById("<%=txtEmail.ClientID%>").value;
            var EmailreplaceText1 = EmailWithoutReplace.replace(/</g, "");
            var EmailreplaceText2 = EmailreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEmail.ClientID%>").value = EmailreplaceText2;

            var WebWithoutReplace = document.getElementById("<%=txtWebSite.ClientID%>").value;
            var WebreplaceText1 = WebWithoutReplace.replace(/</g, "");
            var WebreplaceText2 = WebreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtWebSite.ClientID%>").value = WebreplaceText2;

            document.getElementById("<%=ddlLeadSource.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCustName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "";
            $noC("div#divDiv input.ui-autocomplete-input").css("borderColor", "");
            $noC("div#divTeam input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById("<%=ddlTeam.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtComments.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtConsultant.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtClient.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtProject.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtContractor.ClientID%>").style.borderColor = "";
            document.getElementById("<%=CKEditorDescription.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAddress1.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtMobile.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtNameOne.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAddressOne.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtNameTwo.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAddressTwo.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtNameThree.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAddressThree.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlLeadRate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlExistingProject.ClientID%>").style.borderColor = "";
            $noC("div#divExistingProject input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById("<%=txtProject.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "";

            var ErrorMsg = document.getElementById('ErrorMsgMob').style.display = "none";
            var ProjectMust = document.getElementById("<%=hiddenProjectMust.ClientID%>").value.trim();
            var ProjectName = document.getElementById("<%=txtProject.ClientID%>").value.trim();
            var ProjectList = document.getElementById("<%=ddlExistingProject.ClientID%>").value;
            var customerName = document.getElementById("<%=txtCustName.ClientID%>").value.trim();
            var customerList = document.getElementById("<%=ddlExistingCustomer.ClientID%>").value;
            var Address = document.getElementById("<%=txtAddress1.ClientID%>").value.trim();
            var LeadSource = document.getElementById("<%=ddlLeadSource.ClientID%>").value;

            var date = document.getElementById("<%=txtDate.ClientID%>").value;

            var divsn = document.getElementById("<%=ddlDivision.ClientID%>").value;


            var Team = document.getElementById("<%=ddlTeam.ClientID%>").value;

            var Rating = document.getElementById("<%=ddlLeadRate.ClientID%>").value;

            var Mobile = document.getElementById("<%=txtMobile.ClientID%>").value;

            document.getElementById('ErrorMsgEmail').style.display = "none";
            var Email = document.getElementById("<%=txtEmail.ClientID%>").value;
            var EmailMust = document.getElementById("<%=hiddenEmailMust.ClientID%>").value;
            var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;

            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;


            //if (!filter.test(Email) || Mobile == "" || !mobileregular.test(Mobile) || Address == "" || Team == "--SELECT YOUR TEAM--" ||
            //    divsn == "--SELECT YOUR DIVISION--" || customerName == "" || date == "" || LeadSource == "--SELECT SOURCE--")
            //{
            if (Rating == "--SELECT OPPORTUNITY RATING--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });             
                document.getElementById("<%=ddlLeadRate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlLeadRate.ClientID%>").focus();
                ret = false;
            }
            if (Email == "" && EmailMust == "1" && document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked == false) {


                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
              
                document.getElementById('ErrorMsgEmail').style.display = "";

                document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtEmail.ClientID%>").focus();
                ret = false;

            }
            else {
                if (Email != "" && document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked == false) {
                    if (!filter.test(Email)) {

                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        
                        var ErrorMsg = document.getElementById('ErrorMsgEmail').style.display = "";
                        var OrgMobileFocus = document.getElementById("<%=txtEmail.ClientID%>").focus();
                        document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtEmail.ClientID%>").focus();
                        ret = false;
                    }
                }
            }
            if (Mobile == "" && document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked == false) {

                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
              
                var ErrorMsg = document.getElementById('ErrorMsgMob').style.display = "";
                var OrgMobileFocus = document.getElementById("<%=txtMobile.ClientID%>").focus();
                document.getElementById("<%=txtMobile.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtMobile.ClientID%>").focus();
                ret = false;
            }
            if (!mobileregular.test(Mobile) && document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked == false) {

                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
               

                document.getElementById("<%=txtMobile.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtMobile.ClientID%>").focus();
                ret = false;
            }
            if (Mobile.length < 10 && document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked == false) {

                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
               
                var ErrorMsg = document.getElementById('ErrorMsgMob').style.display = "";
                var OrgMobileFocus = document.getElementById("<%=txtMobile.ClientID%>").focus();
                    document.getElementById("<%=txtMobile.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtMobile.ClientID%>").focus();
                ret = false;
            }

            if (Address == "" && document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked == false){

                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                   
                    document.getElementById("<%=txtAddress1.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtAddress1.ClientID%>").focus();
                    ret = false;
                }
                if (Team == "--SELECT YOUR TEAM--") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=ddlTeam.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddlTeam.ClientID%>").focus();
                    $noC("div#divTeam input.ui-autocomplete-input").css("borderColor", "Red");
                    $noC("#cphMain_ddlTeam").select();
                    ret = false;
                }
                if (divsn == "--SELECT YOUR DIVISION--") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddlDivision.ClientID%>").focus();
                    $noC("div#divDiv input.ui-autocomplete-input").css("borderColor", "Red");
                    $noC("#cphMain_ddlDivision").select();
                ret = false;
            }
            if (document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked == false) {
                if (customerName == "") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtCustName.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtCustName.ClientID%>").focus();
                    ret = false;
                }
            }
            else {
                if (customerList == "--SELECT CUSTOMER/COMPANY--") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=ddlExistingCustomer.ClientID%>").style.borderColor = "Red";
                    $noC("div#divExistingCust input.ui-autocomplete-input").css("borderColor", "Red");
                    document.getElementById("<%=ddlExistingCustomer.ClientID%>").focus();
                    $noC("#cphMain_ddlExistingCustomer").select();
                    ret = false;
                }
            }

            if (document.getElementById("<%=cbxExistingProject.ClientID%>").checked == false) {
                if (ProjectName == "" && ProjectMust=="1") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtProject.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtProject.ClientID%>").focus();
                    ret = false;
                }
                //QCLD4 EVM0012
               
            }
            else {
                if (ProjectList == "--SELECT PROJECT--" && ProjectMust == "1") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=ddlExistingProject.ClientID%>").style.borderColor = "Red";
                    $noC("div#divExistingProject input.ui-autocomplete-input").css("borderColor", "Red");
                    document.getElementById("<%=ddlExistingProject.ClientID%>").focus();
                    $noC("#cphMain_ddlExistingProject").select();
                    ret = false;
                }
            }

            if (date == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtDate.ClientID%>").focus();
                ret = false;
            }
            else {
                //Start- WEM0006
                //check if lead date is greater than current date
                var TaskdatepickerDate = document.getElementById("<%=txtDate.ClientID%>").value;
                var arrDatePickerDate = TaskdatepickerDate.split("-");
                var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
            var arrCurrentDate = CurrentDateDate.split("-");
            var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

            if (dateDateCntrlr > dateCurrentDate) {
                document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtDate.ClientID%>").focus();
                $("#divWarning").html("Sorry, Opportunity date cannot be greater than current date !.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                ret = false;
            }//stop wem 0006

            }
            if (LeadSource == "--SELECT SOURCE--") {

                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=ddlLeadSource.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlLeadSource.ClientID%>").focus();
                ret = false;
            }



            if (ret == false) {
                CheckSubmitZero();
                $('html, body').animate({ scrollTop: 0 }, 500);
                return ret;
            }




            var NameOne = document.getElementById("<%=txtNameOne.ClientID%>").value.trim();
            var AddressOne = document.getElementById("<%=txtAddressOne.ClientID%>").value.trim();
            var MobileOne = document.getElementById("<%=txtMobileOne.ClientID%>").value;
            var PhoneOne = document.getElementById("<%=txtPhoneOne.ClientID%>").value;
            var EmailOne = document.getElementById("<%=txtEmailOne.ClientID%>").value;
            var WebsiteOne = document.getElementById("<%=txtWebsiteOne.ClientID%>").value;

            var NameTwo = document.getElementById("<%=txtNameTwo.ClientID%>").value;
            var AddressTwo = document.getElementById("<%=txtAddressTwo.ClientID%>").value;
            var MobileTwo = document.getElementById("<%=txtMobileTwo.ClientID%>").value;
            var PhoneTwo = document.getElementById("<%=txtPhoneTwo.ClientID%>").value;
            var EmailTwo = document.getElementById("<%=txtEmailTwo.ClientID%>").value;
            var WebsiteTwo = document.getElementById("<%=txtWebsiteTwo.ClientID%>").value;

            var NameThree = document.getElementById("<%=txtNameThree.ClientID%>").value;
            var AddressThree = document.getElementById("<%=txtAddressThree.ClientID%>").value;
            var MobileThree = document.getElementById("<%=txtMobileThree.ClientID%>").value;
            var PhoneThree = document.getElementById("<%=txtPhoneThree.ClientID%>").value;
            var EmailThree = document.getElementById("<%=txtEmailThree.ClientID%>").value;
            var WebsiteThree = document.getElementById("<%=txtWebsiteThree.ClientID%>").value;


            document.getElementById('ErrorMsgMobileOne').style.display = "none";
            document.getElementById('ErrorMsgMobileTwo').style.display = "none";
            document.getElementById('ErrorMsgMobileThree').style.display = "none";
            document.getElementById('ErrorMsgEmailOne').style.display = "none";
            document.getElementById('ErrorMsgEmailTwo').style.display = "none";
            document.getElementById('ErrorMsgEmailThree').style.display = "none";


            document.getElementById("<%=txtMobileOne.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtMobileTwo.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtMobileThree.ClientID%>").style.borderColor = "";

            document.getElementById("<%=txtEmailOne.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtEmailTwo.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtEmailThree.ClientID%>").style.borderColor = "";



            if (NameOne != "" && NameTwo != "") {
                if (NameOne == NameTwo) {
                   
                    document.getElementById('divNewContactOne').style.display = "";
                  
                    $("#divWarning").html("Duplication error!. Contact name can’t be duplicated.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById('divNewContactTwo').style.display = "";
                    //document.getElementById('ClearTwo').style.display = "";
                    document.getElementById("<%=txtNameTwo.ClientID%>").style.borderColor = "Red";
                    ret = false;

                    CheckSubmitZero();

                    return ret;
                }
            }
            if (NameOne != "" && NameThree != "") {
                if (NameOne == NameThree) {
                   
                    document.getElementById('divNewContactOne').style.display = "";
                   
                    $("#divWarning").html("Duplication error!. Contact name can’t be duplicated");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById('divNewContactThree').style.display = "";
                    //document.getElementById('ClearThree').style.display = "";
                    document.getElementById("<%=txtNameThree.ClientID%>").style.borderColor = "Red";
                    ret = false;

                    CheckSubmitZero();

                    return ret;
                }
            }
            if (NameTwo != "" && NameThree != "") {
                if (NameTwo == NameThree) {
                 
                    document.getElementById('divNewContactOne').style.display = "";
                   
                    $("#divWarning").html("Duplication error!. Contact name can’t be duplicated.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById('divNewContactThree').style.display = "";
                   // document.getElementById('ClearThree').style.display = "";
                    document.getElementById("<%=txtNameThree.ClientID%>").style.borderColor = "Red";
                    ret = false;

                    CheckSubmitZero();

                    return ret;
                }
            }

            if (NameThree != "" || AddressThree != "" || MobileThree != "" || PhoneThree != "" || EmailThree != "" || WebsiteThree != "") {


                if (EmailThree != "") {
                    if (!filter.test(EmailThree)) {
                       
                        document.getElementById('divNewContactOne').style.display = "";
                      
                        document.getElementById('divNewContactThree').style.display = "";
                        //document.getElementById('ClearThree').style.display = "";
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        document.getElementById('ErrorMsgEmailThree').style.display = "";
                        document.getElementById("<%=txtEmailThree.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtEmailThree.ClientID%>").focus();
                        ret = false;
                    }
                }

                if (MobileThree != "") {
                    if (!mobileregular.test(MobileThree)) {
                      
                        document.getElementById('divNewContactOne').style.display = "";
                      
                        document.getElementById('divNewContactThree').style.display = "";
                        //document.getElementById('ClearThree').style.display = "";
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        var ErrorMsg = document.getElementById('ErrorMsgMobileThree').style.display = "";
                        document.getElementById("<%=txtMobileThree.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtMobileThree.ClientID%>").focus();
                        ret = false;
                    }
                }




                if (AddressThree == "") {
                   
                    document.getElementById('divNewContactOne').style.display = "";
                   
                    document.getElementById('divNewContactThree').style.display = "";
                    //document.getElementById('ClearThree').style.display = "";
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtAddressThree.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtAddressThree.ClientID%>").focus();
                    ret = false;
                }
                if (NameThree == "") {
                   
                    document.getElementById('divNewContactOne').style.display = "";
                   
                    document.getElementById('divNewContactThree').style.display = "";
                    //document.getElementById('ClearThree').style.display = "";
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtNameThree.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtNameThree.ClientID%>").focus();
                    ret = false;
                }
            }

            if (NameTwo != "" || AddressTwo != "" || MobileTwo != "" || PhoneTwo != "" || EmailTwo != "" || WebsiteTwo != "") {

                if (EmailTwo != "") {
                    if (!filter.test(EmailTwo)) {
                       
                        document.getElementById('divNewContactOne').style.display = "";
                       
                        document.getElementById('divNewContactTwo').style.display = "";
                       // document.getElementById('ClearTwo').style.display = "";
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        var ErrorMsg = document.getElementById('ErrorMsgEmailTwo').style.display = "";
                        document.getElementById("<%=txtEmailTwo.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtEmailTwo.ClientID%>").focus();
                        ret = false;
                    }
                }

                if (MobileTwo != "") {
                    if (!mobileregular.test(MobileTwo)) {
                      
                        document.getElementById('divNewContactOne').style.display = "";
                      
                        document.getElementById('divNewContactTwo').style.display = "";
                        //document.getElementById('ClearTwo').style.display = "";
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        var ErrorMsg = document.getElementById('ErrorMsgMobileTwo').style.display = "";
                        document.getElementById("<%=txtMobileTwo.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtMobileTwo.ClientID%>").focus();
                        ret = false;
                    }
                }



                if (AddressTwo == "") {
                   
                    document.getElementById('divNewContactOne').style.display = "";
                   
                    document.getElementById('divNewContactTwo').style.display = "";
                    //document.getElementById('ClearTwo').style.display = "";
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtAddressTwo.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtAddressTwo.ClientID%>").focus();
                    ret = false;
                }
                if (NameTwo == "") {
                   
                    document.getElementById('divNewContactOne').style.display = "";
                  
                    document.getElementById('divNewContactTwo').style.display = "";
                   // document.getElementById('ClearTwo').style.display = "";
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtNameTwo.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtNameTwo.ClientID%>").focus();
                    ret = false;
                }
            }

            if (NameOne != "" || AddressOne != "" || MobileOne != "" || PhoneOne != "" || EmailOne != "" || WebsiteOne != "") {


                if (EmailOne != "") {
                    if (!filter.test(EmailOne)) {
                       
                        document.getElementById('divNewContactOne').style.display = "";
                       
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        var ErrorMsg = document.getElementById('ErrorMsgEmailOne').style.display = "";
                        document.getElementById("<%=txtEmailOne.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtEmailOne.ClientID%>").focus();
                        ret = false;
                    }
                }

                if (MobileOne != "") {
                    if (!mobileregular.test(MobileOne)) {
                      
                        document.getElementById('divNewContactOne').style.display = "";
                      
                        $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        var ErrorMsg = document.getElementById('ErrorMsgMobileOne').style.display = "";
                        document.getElementById("<%=txtMobileOne.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtMobileOne.ClientID%>").focus();
                        ret = false;
                    }
                }


                if (AddressOne == "") {
                   
                    document.getElementById('divNewContactOne').style.display = "";
                  
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtAddressOne.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtAddressOne.ClientID%>").focus();
                    ret = false;
                }
                if (NameOne == "") {
                   
                    document.getElementById('divNewContactOne').style.display = "";
                  
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtNameOne.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtNameOne.ClientID%>").focus();
                    ret = false;
                }

            }
            if (ret == false) {
                CheckSubmitZero();

            }
            else{
                
                if($(".bid1").hasClass("sel_ab1")){
                    document.getElementById("<%=HiddenFieldddlProjectStatus.ClientID%>").value = 102;
                }
                else if($(".awd1").hasClass("sel_ab1")){
                    document.getElementById("<%=HiddenFieldddlProjectStatus.ClientID%>").value = 101;
                }
                $("#cphMain_txtAddress1").prop('disabled', false);
                $("#cphMain_txtAddress2").prop('disabled', false);
                $("#cphMain_txtAddress3").prop('disabled', false);              
                $("div#divCou input.ui-autocomplete-input").prop('disabled', false);
                $("#cphMain_ddlState").prop('disabled', false);
                $("#cphMain_ddlCity").prop('disabled', false);
                $("#cphMain_txtZipCode").prop('disabled', false);
                $("#cphMain_txtMobile").prop('disabled', false);
                $("#cphMain_txtPhone").prop('disabled', false);
                $("#cphMain_txtEmail").prop('disabled', false);
                $("#cphMain_txtWebSite").prop('disabled', false);
            }
            return ret;
        }



        function SaveValidateProject() {
            document.getElementById("<%=hiddenDupplicatedProject.ClientID%>").value = "";

            var $noC = jQuery.noConflict();
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

            //replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtCustName.ClientID%>").value;
            var NamereplaceText1 = NameWithoutReplace.replace(/</g, "");
            var NamereplaceText2 = NamereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCustName.ClientID%>").value = NamereplaceText2;

            var DesptnWithoutReplace = document.getElementById("<%=CKEditorDescription.ClientID%>").value;
              var DesptnreplaceText1 = DesptnWithoutReplace.replace(/</g, "");
              var DesptnreplaceText2 = DesptnreplaceText1.replace(/>/g, "");
              document.getElementById("<%=CKEditorDescription.ClientID%>").value = DesptnreplaceText2;

            var TitleWithoutReplace = document.getElementById("<%=txtTitle.ClientID%>").value;
              var TitlereplaceText1 = TitleWithoutReplace.replace(/</g, "");
              var TitlereplaceText2 = TitlereplaceText1.replace(/>/g, "");
              document.getElementById("<%=txtTitle.ClientID%>").value = TitlereplaceText2;

            var ComntsWithoutReplace = document.getElementById("<%=txtComments.ClientID%>").value;
              var ComntsreplaceText1 = ComntsWithoutReplace.replace(/</g, "");
              var ComntsreplaceText2 = ComntsreplaceText1.replace(/>/g, "");
              document.getElementById("<%=txtComments.ClientID%>").value = ComntsreplaceText2;

            var PjctWithoutReplace = document.getElementById("<%=txtProject.ClientID%>").value;
              var PjctreplaceText1 = PjctWithoutReplace.replace(/</g, "");
              var PjctreplaceText2 = PjctreplaceText1.replace(/>/g, "");
              document.getElementById("<%=txtProject.ClientID%>").value = PjctreplaceText2;

            var ClientWithoutReplace = document.getElementById("<%=txtClient.ClientID%>").value;
              var ClientreplaceText1 = ClientWithoutReplace.replace(/</g, "");
              var ClientreplaceText2 = ClientreplaceText1.replace(/>/g, "");
              document.getElementById("<%=txtClient.ClientID%>").value = ClientreplaceText2;

            var CnctrWithoutReplace = document.getElementById("<%=txtContractor.ClientID%>").value;
              var CnctrreplaceText1 = CnctrWithoutReplace.replace(/</g, "");
              var CnctrreplaceText2 = CnctrreplaceText1.replace(/>/g, "");
              document.getElementById("<%=txtContractor.ClientID%>").value = CnctrreplaceText2;

            var ConsltWithoutReplace = document.getElementById("<%=txtConsultant.ClientID%>").value;
              var ConsltreplaceText1 = ConsltWithoutReplace.replace(/</g, "");
              var ConsltreplaceText2 = ConsltreplaceText1.replace(/>/g, "");
              document.getElementById("<%=txtConsultant.ClientID%>").value = ConsltreplaceText2;

            var Add1WithoutReplace = document.getElementById("<%=txtAddress1.ClientID%>").value;
              var Add1replaceText1 = Add1WithoutReplace.replace(/</g, "");
              var Add1replaceText2 = Add1replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtAddress1.ClientID%>").value = Add1replaceText2;

            var Add2WithoutReplace = document.getElementById("<%=txtAddress2.ClientID%>").value;
              var Add2replaceText1 = Add2WithoutReplace.replace(/</g, "");
              var Add2replaceText2 = Add2replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtAddress2.ClientID%>").value = Add2replaceText2;

            var Add3WithoutReplace = document.getElementById("<%=txtAddress3.ClientID%>").value;
              var Add3replaceText1 = Add3WithoutReplace.replace(/</g, "");
              var Add3replaceText2 = Add3replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtAddress3.ClientID%>").value = Add3replaceText2;

            var ZipWithoutReplace = document.getElementById("<%=txtZipCode.ClientID%>").value;
              var ZipreplaceText1 = ZipWithoutReplace.replace(/</g, "");
              var ZipreplaceText2 = ZipreplaceText1.replace(/>/g, "");
              document.getElementById("<%=txtZipCode.ClientID%>").value = ZipreplaceText2;

           

            var MobWithoutReplace = document.getElementById("<%=txtMobile.ClientID%>").value;
              var MobreplaceText1 = MobWithoutReplace.replace(/</g, "");
              var MobreplaceText2 = MobreplaceText1.replace(/>/g, "");
              document.getElementById("<%=txtMobile.ClientID%>").value = MobreplaceText2;

            var PhoneWithoutReplace = document.getElementById("<%=txtPhone.ClientID%>").value;
              var PhonereplaceText1 = PhoneWithoutReplace.replace(/</g, "");
              var PhonereplaceText2 = PhonereplaceText1.replace(/>/g, "");
              document.getElementById("<%=txtPhone.ClientID%>").value = PhonereplaceText2;

            var EmailWithoutReplace = document.getElementById("<%=txtEmail.ClientID%>").value;
              var EmailreplaceText1 = EmailWithoutReplace.replace(/</g, "");
              var EmailreplaceText2 = EmailreplaceText1.replace(/>/g, "");
              document.getElementById("<%=txtEmail.ClientID%>").value = EmailreplaceText2;

            var WebWithoutReplace = document.getElementById("<%=txtWebSite.ClientID%>").value;
              var WebreplaceText1 = WebWithoutReplace.replace(/</g, "");
              var WebreplaceText2 = WebreplaceText1.replace(/>/g, "");
              document.getElementById("<%=txtWebSite.ClientID%>").value = WebreplaceText2;


              
              document.getElementById("<%=ddlExistingProject.ClientID%>").style.borderColor = "";
              $noC("div#divExistingProject input.ui-autocomplete-input").css("borderColor", "");
              document.getElementById("<%=txtProject.ClientID%>").style.borderColor = "";
           

        

            var ProjectName = document.getElementById("<%=txtProject.ClientID%>").value.trim();
              var ProjectList = document.getElementById("<%=ddlExistingProject.ClientID%>").value;


            



              //if (!filter.test(Email) || Mobile == "" || !mobileregular.test(Mobile) || Address == "" || Team == "--SELECT YOUR TEAM--" ||
              //    divsn == "--SELECT YOUR DIVISION--" || customerName == "" || date == "" || LeadSource == "--SELECT SOURCE--")
              //{
     

           
            if (ProjectName == "") {
               
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtProject.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtProject.ClientID%>").focus();
                ret = false;
            }
            else {

                var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
                var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
                if (CorpId != '' && CorpId != null && OrgId != '' && OrgId != null ) {

                    DuplicationProjectWebMethod(CorpId, OrgId, ProjectName);

                    var dup = document.getElementById("<%=hiddenDupplicatedProject.ClientID%>").value;

                 if (dup == "") {
                     ret= false;

                 }
                 else {
                     if (dup == "true") {



                         ret = true;
                     }
                     else if (dup == "false") {
                      
                         DuplicationProjectClientside();
                         ret=false;

                     }
                 }
             }

            }
        

      



            if (ret == false) {
                CheckSubmitZero();
           //     $('html, body').animate({ scrollTop: 0 }, 500);
            
            }



         

            return ret;
        }
        function AssignMediaValues(control) {

            var text = control.value;
            var replaceText1 = text.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/'/g, "");
            var replaceText4 = replaceText3.replace(/"/g, "");
            var replaceText5 = replaceText4.replace(/\\/g, "");
            control.value = replaceText5;

            var MediaValue = document.getElementById("<%=hiddenMedia.ClientID%>").value;//Retrieve the stored data            

            if (MediaValue == "") { //If there is no data, initialize an empty array
                MediaValue = [];
            }
            else {
                MediaValue = JSON.parse(MediaValue); //Converts string to object
                //alert(StringObject.length);
            }
            var $add = jQuery.noConflict();
            var client = JSON.stringify({
                MEDIA_ID: "" + control.id + "",
                MEDIA_NAME:null,
                MEDIA_DESCRIPTION: "" + control.value + ""
            });
            MediaValue.push(client);
            document.getElementById("<%=hiddenMedia.ClientID%>").value = JSON.stringify(MediaValue);
            return false;
        }

        //document.onload = PageLoad();
        // window.body.onended = PageLoad();


    </script> 
    <style>
        .error {
             color: red;
               font-size: small;
                font-family: Calibri;
        }    
    </style>
    <script type="text/javascript">
        var Filecounter = 0;
        function AddFileUpload() {
            var FrecRow = '<tr id="FilerowId_' + Filecounter + '" >';
           
            FrecRow += '<td class="col-md-8 tr_l" style="padding-left: 0px;">';
            FrecRow += '<input id="file' + Filecounter + '" name = "file' + Filecounter +'" type="file" onchange="ChangeFile(' + Filecounter + ')" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/ >';
            FrecRow += '<label for="file' + Filecounter + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
            FrecRow += ' <div id="filePath' + Filecounter + '" class="file_n"></div>';
            FrecRow += ' </td>';
            FrecRow += ' <td>';
            FrecRow += '  <div class="btn_stl1">';
            FrecRow += '  <button id="FileIndvlAddMoreRow' + Filecounter + '" class="btn act_btn bn2" onclick="return CheckaddMoreRowsIndividualFiles(' + Filecounter + ');" title="Add">';
            FrecRow += '  <i class="fa fa-plus-circle"></i>';
            FrecRow += '  </button>';
            FrecRow += '  <button class="btn act_btn bn3" onclick = "return RemoveFileUpload(' + Filecounter + ');"" title="Delete">';
            FrecRow += '    <i class="fa fa-trash"></i>';
            FrecRow += '   </button>';
            FrecRow += '  </div>';
            FrecRow += '  </td>';
            FrecRow += ' <td id="FileInx' + Filecounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + Filecounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + Filecounter + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId' + Filecounter + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName' + Filecounter + '" style="display: none;"></td>';
            FrecRow += '</tr>';
            jQuery('#TableFileUploadContainer').append(FrecRow);
            document.getElementById('filePath' + Filecounter).innerHTML = 'No File Selected';
            Filecounter++;

        }
        function EditAttachment(editTransDtlId, EditFileName, EditActualFileName) {
            var FrecRow = '<tr id="FilerowId_' + Filecounter + '" >';
            var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';
            FrecRow += '<td class="col-md-8 tr_l" style="padding-left: 0px;">';
            FrecRow += '<input style="display:none;" id="file' + Filecounter + '" name = "file' + Filecounter + '" type="file" onchange="ChangeFile(' + Filecounter + ')" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/ >';
            FrecRow += '<label style="display:none;" for="file' + Filecounter + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
            FrecRow += ' <div id="filePath' + Filecounter + '" class="file_n">' + tdFileNameEdit + '</div>';
            FrecRow += ' </td>';
            FrecRow += ' <td>';
            FrecRow += '  <div class="btn_stl1">';
            FrecRow += '  <button disabled id="FileIndvlAddMoreRow' + Filecounter + '" class="btn act_btn bn2" onclick="return CheckaddMoreRowsIndividualFiles(' + Filecounter + ');" title="Add">';
            FrecRow += '  <i class="fa fa-plus-circle"></i>';
            FrecRow += '  </button>';
            FrecRow += '  <button class="btn act_btn bn3" onclick = "return RemoveFileUpload(' + Filecounter + ');"" title="Delete">';
            FrecRow += '    <i class="fa fa-trash"></i>';
            FrecRow += '   </button>';
            FrecRow += '  </div>';
            FrecRow += '  </td>';
            FrecRow += ' <td id="FileInx' + Filecounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + Filecounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + Filecounter + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId' + Filecounter + '" style="display: none;">' + editTransDtlId + '</td>';
            FrecRow += '<td id="DbFileName' + Filecounter + '" style="display: none;">' + EditFileName + '</td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadContainer').append(FrecRow);
            //  alert(Filecounter);
            document.getElementById("FileInx" + Filecounter).innerHTML = Filecounter;
            //document.getElementById("FileIndvlAddMoreRow" + Filecounter).style.opacity = "0.3";
            // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
            FileLocalStorageAdd(Filecounter);
            Filecounter++;

        }

        function AddAttachment(editTransDtlId, EditFileName, EditActualFileName) {
            var FrecRow = '<tr id="FilerowId_' + Filecounter + '" >';
            var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFileMailPath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';
            FrecRow += '<td class="col-md-8 tr_l" style="padding-left: 0px;">';
            FrecRow += '<input style="display:none;" id="file' + Filecounter + '" name = "file' + Filecounter + '" type="file" onchange="ChangeFile(' + Filecounter + ')" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/ >';
            FrecRow += '<label style="display:none;" for="file' + Filecounter + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
            FrecRow += ' <div id="filePath' + Filecounter + '" class="file_n">' + tdFileNameEdit + '</div>';
            FrecRow += ' </td>';
            FrecRow += ' <td>';
            FrecRow += '  <div class="btn_stl1">';
            FrecRow += '  <button disabled id="FileIndvlAddMoreRow' + Filecounter + '" class="btn act_btn bn2" onclick="return CheckaddMoreRowsIndividualFiles(' + Filecounter + ');" title="Add">';
            FrecRow += '  <i class="fa fa-plus-circle"></i>';
            FrecRow += '  </button>';
            FrecRow += '  <button class="btn act_btn bn3" onclick = "return RemoveFileUpload(' + Filecounter + ');"" title="Delete">';
            FrecRow += '    <i class="fa fa-trash"></i>';
            FrecRow += '   </button>';
            FrecRow += '  </div>';
            FrecRow += '  </td>';
            FrecRow += ' <td id="FileInx' + Filecounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + Filecounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + Filecounter + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId' + Filecounter + '" style="display: none;">' + editTransDtlId + '</td>';
            FrecRow += '<td id="DbFileName' + Filecounter + '" style="display: none;">' + EditFileName + '</td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadContainer').append(FrecRow);
                    //  alert(Filecounter);
            document.getElementById("FileInx" + Filecounter).innerHTML = Filecounter;
            //document.getElementById("FileIndvlAddMoreRow" + Filecounter).style.opacity = "0.3";


                    // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
            FileLocalStorageAdd(Filecounter);
            Filecounter++;

        }

        function ViewAttachment(editTransDtlId, EditFileName, EditActualFileName) {
            var FrecRow = '<tr id="FilerowId_' + Filecounter + '" >';
            var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';
            FrecRow += '<td class="col-md-8 tr_l" style="padding-left: 0px;">';
            FrecRow += '<input style="display:none;" id="file' + Filecounter + '" name = "file' + Filecounter + '" type="file" onchange="ChangeFile(' + Filecounter + ')" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/ >';
            FrecRow += '<label style="display:none;" for="file' + Filecounter + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
            FrecRow += ' <div id="filePath' + Filecounter + '" class="file_n">' + tdFileNameEdit + '</div>';
            FrecRow += ' </td>';
            FrecRow += ' <td>';
            FrecRow += '  <div class="btn_stl1">';
            FrecRow += '  <button disabled id="FileIndvlAddMoreRow' + Filecounter + '" class="btn act_btn bn2" onclick="return CheckaddMoreRowsIndividualFiles(' + Filecounter + ');" title="Add">';
            FrecRow += '  <i class="fa fa-plus-circle"></i>';
            FrecRow += '  </button>';
            FrecRow += '  <button disabled class="btn act_btn bn3" onclick = "return RemoveFileUpload(' + Filecounter + ');"" title="Delete">';
            FrecRow += '    <i class="fa fa-trash"></i>';
            FrecRow += '   </button>';
            FrecRow += '  </div>';
            FrecRow += '  </td>';
            FrecRow += ' <td id="FileInx' + Filecounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + Filecounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + Filecounter + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId' + Filecounter + '" style="display: none;">' + editTransDtlId + '</td>';
            FrecRow += '<td id="DbFileName' + Filecounter + '" style="display: none;">' + EditFileName + '</td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadContainer').append(FrecRow);
            document.getElementById("FileInx" + Filecounter).innerHTML = Filecounter;
            //document.getElementById("FileIndvlAddMoreRow" + Filecounter).style.opacity = "0.3";
            // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
            FileLocalStorageAdd(Filecounter);
            Filecounter++;

        }
        function RemoveFileUpload(removeNum) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to delete selected file?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var Filerow_index = jQuery('#FilerowId_' + removeNum).index();
                    FileLocalStorageDelete(Filerow_index, removeNum);
                    jQuery('#FilerowId_' + removeNum).remove();


                    var TableFileRowCount = document.getElementById("TableFileUploadContainer").rows.length;

                    if (TableFileRowCount != 0) {
                        var idlast = $noC('#TableFileUploadContainer tr:last').attr('id');
                        //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                        //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                        if (idlast != "") {
                            var res = idlast.split("_");
                            //  alert(res[1]);
                            document.getElementById("FileInx" + res[1]).innerHTML = " ";
                            document.getElementById("FileIndvlAddMoreRow" + res[1]).disabled = false;
                        }
                    }
                    else {
                        AddFileUpload();
                    }
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
        function ChangeFile(x) {
            IncrmntConfrmCounter();
            if (document.getElementById('file' + x).value != "") {
                document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;
            }
            else {
                document.getElementById('filePath' + x).innerHTML = 'No File Selected';
            }
            var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
            //   alert('hi SavedorNot' + SavedorNot);
            if (SavedorNot == "saved") {
                var row_index = jQuery('#FilerowId_' + x).index();
                FileLocalStorageEdit(x, row_index);
            }
            else {
                FileLocalStorageAdd(x);
            }

        }
        function CheckFileUploaded(x) {
            if (document.getElementById('file' + x).value != "") {
                return true;
            }
            else {
                return false;
            }
        }
        function CheckaddMoreRowsIndividualFiles(x) {
            // for add image in each row

            var check = document.getElementById("FileInx" + x).innerHTML;

            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            //  alert(check);
            if (check == " ") {

                var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                if (Fevt != 'UPD') {
                    if (CheckFileUploaded(x) == true) {
                        document.getElementById("FileInx" + x).innerHTML = x;
                        document.getElementById("FileIndvlAddMoreRow" + x).disabled = true;
                        AddFileUpload();
                        return false;
                    }
                }
                else {

                    document.getElementById("FileInx" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRow" + x).disabled = true;
                    AddFileUpload();
                    return false;
                }
            }
            return false;
        }

        function FileLocalStorageAdd(x) {

            var tbClientQuotationFileUpload = localStorage.getItem("tbClientQuotationFileUpload");//Retrieve the stored data

            tbClientQuotationFileUpload = JSON.parse(tbClientQuotationFileUpload); //Converts string to object

            if (tbClientQuotationFileUpload == null) //If there is no data, initialize an empty array
                tbClientQuotationFileUpload = [];


            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            //   alert('FilePath' + FilePath);

            if (Fevt == 'INS') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    //   FILEPATH: "" + FilePath + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"

                });
            }
            else if (Fevt == 'UPD') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    //   FILEPATH: "" + FilePath + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });
            }


            tbClientQuotationFileUpload.push(client);
            localStorage.setItem("tbClientQuotationFileUpload", JSON.stringify(tbClientQuotationFileUpload));

            $addFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientQuotationFileUpload));



            //  alert("The FILE ADDED.");
            //   var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
            //  alert(h);

            document.getElementById("FileSave" + x).innerHTML = "saved";
            //   alert('saved');
            return true;

        }

        function FileLocalStorageDelete(row_index, x) {
            var $DelFile = jQuery.noConflict();
            var tbClientQuotationFileUpload = localStorage.getItem("tbClientQuotationFileUpload");//Retrieve the stored data

            tbClientQuotationFileUpload = JSON.parse(tbClientQuotationFileUpload); //Converts string to object

            if (tbClientQuotationFileUpload == null) //If there is no data, initialize an empty array
                tbClientQuotationFileUpload = [];



            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            tbClientQuotationFileUpload.splice(row_index, 1);
            localStorage.setItem("tbClientQuotationFileUpload", JSON.stringify(tbClientQuotationFileUpload));
            $DelFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientQuotationFileUpload));
            //   alert("FILE deleted.");

            //   var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
            //  alert(h);


            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            if (Fevt == 'UPD') {
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

                if (FdetailId != '') {
                    //      var FCanclIds = document.getElementById("<%=hiddenFileCanclDtlId.ClientID%>").value;

                    //  if (FCanclIds == '') {
                    //      document.getElementById("<%=hiddenFileCanclDtlId.ClientID%>").value = FdetailId;

                    //  }
                    //  else {

                    //      document.getElementById("<%=hiddenFileCanclDtlId.ClientID%>").value = document.getElementById("<%=hiddenFileCanclDtlId.ClientID%>").value + ',' + FdetailId;
                    // }
                    DeleteFileLSTORAGEAdd(x);
                }

            }

            function DeleteFileLSTORAGEAdd(x) {

                var tbClientQuotationFileCancel = localStorage.getItem("tbClientQuotationFileCancel");//Retrieve the stored data

                tbClientQuotationFileCancel = JSON.parse(tbClientQuotationFileCancel); //Converts string to object

                if (tbClientQuotationFileCancel == null) //If there is no data, initialize an empty array
                    tbClientQuotationFileCancel = [];


                var FileName = document.getElementById("DbFileName" + x).innerHTML;
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;




                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    FILENAME: "" + FileName + "",
                    // EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });



                tbClientQuotationFileCancel.push(client);
                localStorage.setItem("tbClientQuotationFileCancel", JSON.stringify(tbClientQuotationFileCancel));

                $addFile("#cphMain_hiddenFileCanclDtlId").val(JSON.stringify(tbClientQuotationFileCancel));



                //     alert("The FILEDELETED ADDED.");
                //     var h = document.getElementById("<%=hiddenFileCanclDtlId.ClientID%>").value;
                //   alert(h);

                //document.getElementById("FileSave" + x).innerHTML = "saved";
                //   alert('saved');
                return true;

            }

        }

        function FileLocalStorageEdit(x, row_index) {
            var tbClientQuotationFileUpload = localStorage.getItem("tbClientQuotationFileUpload");//Retrieve the stored data

            tbClientQuotationFileUpload = JSON.parse(tbClientQuotationFileUpload); //Converts string to object

            if (tbClientQuotationFileUpload == null) //If there is no data, initialize an empty array
                tbClientQuotationFileUpload = [];

            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

            var Fevt = document.getElementById("FileEvt" + x).innerHTML;

            if (Fevt == 'INS') {

                var $FileE = jQuery.noConflict();
                tbClientQuotationFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    //     FILEPATH: "" + FilePath + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"
                });//Alter the selected item on the table
            }
            else {

                var $FileE = jQuery.noConflict();
                tbClientQuotationFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    //   FILEPATH: "" + FilePath + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });//Alter the selected item on the table



            }



            localStorage.setItem("tbClientQuotationFileUpload", JSON.stringify(tbClientQuotationFileUpload));
            $FileE("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientQuotationFileUpload));

            //        alert("The FILE EDITED.");

            //      var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
            //     alert(h);
            return true;
        }
    </script>
    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            
            
            localStorage.clear();
           //   alert('load begin');          

            if (document.getElementById("<%=hiddenMailAttachment.ClientID%>").value != "") {
                var EditAttchmnt = document.getElementById("<%=hiddenMailAttachment.ClientID%>").value;
                
                    //        var findAtt1 = '\\\\';
                    //        var reAtt1 = new RegExp(findAtt1, 'g');
                    //        var resAtt1 = EditAttchmnt.replace(reAtt1, '');

                    var findAtt2 = '\\"\\[';
                    var reAtt2 = new RegExp(findAtt2, 'g');
                    var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                    var findAtt3 = '\\]\\"';
                    var reAtt3 = new RegExp(findAtt3, 'g');
                    var resAtt3 = resAtt2.replace(reAtt3, '\]');
                    //alert(res3);
                    var jsonAtt = $noCon.parseJSON(resAtt3);
                    for (var key in jsonAtt) {
                        if (jsonAtt.hasOwnProperty(key)) {
                            if (jsonAtt[key].LeadAttchmntDtlId != "") {

                                //   alert(jsonAtt[key].ActualFileName);
                                AddAttachment(jsonAtt[key].LeadAttchmntDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName);



                                //  alert(json[key].Amount);
                            }
                        }
                    }


                }


            var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;
            var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;

            if (EditVal != "") {


                if (document.getElementById("<%=hiddenEditAttchmnt.ClientID%>").value != "") {
                    var EditAttchmnt = document.getElementById("<%=hiddenEditAttchmnt.ClientID%>").value;

                    //        var findAtt1 = '\\\\';
                    //        var reAtt1 = new RegExp(findAtt1, 'g');
                    //        var resAtt1 = EditAttchmnt.replace(reAtt1, '');

                    var findAtt2 = '\\"\\[';
                    var reAtt2 = new RegExp(findAtt2, 'g');
                    var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                    var findAtt3 = '\\]\\"';
                    var reAtt3 = new RegExp(findAtt3, 'g');
                    var resAtt3 = resAtt2.replace(reAtt3, '\]');
                    //alert(res3);
                    var jsonAtt = $noCon.parseJSON(resAtt3);
                    for (var key in jsonAtt) {
                        if (jsonAtt.hasOwnProperty(key)) {
                            if (jsonAtt[key].TransDtlId != "") {

                                //   alert(jsonAtt[key].ActualFileName);
                                EditAttachment(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName);



                                //  alert(json[key].Amount);
                            }
                        }
                    }


                }
                if (document.getElementById("<%=HiddenCustomerSet.ClientID%>").value == "0") {
                    document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked = false;
                }
                else {
                    document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked = true;
                }


        }

        else if (ViewVal != "") {

          //  alert(ViewVal);
            if (document.getElementById("<%=hiddenEditAttchmnt.ClientID%>").value != "") {
                    var EditAttchmnt = document.getElementById("<%=hiddenEditAttchmnt.ClientID%>").value;

                    //      var findAtt1 = '\\\\';
                    //       var reAtt1 = new RegExp(findAtt1, 'g');
                    //    var resAtt1 = EditAttchmnt.replace(reAtt1, '');

                    var findAtt2 = '\\"\\[';
                    var reAtt2 = new RegExp(findAtt2, 'g');
                    var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                    var findAtt3 = '\\]\\"';
                    var reAtt3 = new RegExp(findAtt3, 'g');
                    var resAtt3 = resAtt2.replace(reAtt3, '\]');
                    //alert(res3);
                    var jsonAtt = $noCon.parseJSON(resAtt3);
                    for (var key in jsonAtt) {
                        if (jsonAtt.hasOwnProperty(key)) {
                            if (jsonAtt[key].TransDtlId != "") {

                                //   alert(jsonAtt[key].ActualFileName);
                                ViewAttachment(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName);



                                //  alert(json[key].Amount);
                            }
                        }
                    }


                }
                else {
                    document.getElementById("headingFileUpload").innerHTML = "No File Added";
                }

            document.getElementById("<%=cbxExistingClient.ClientID%>").disabled = true;
            document.getElementById("<%=cbxExistingContractor.ClientID%>").disabled = true;
            document.getElementById("<%=cbxExistingConsultant.ClientID%>").disabled = true;
            document.getElementById("<%=cbxExistingProject.ClientID%>").disabled = true;
                document.getElementById("<%=ddlLeadSource.ClientID%>").disabled = true;
                document.getElementById("<%=txtDate.ClientID%>").disabled = true;
                //document.getElementById("imgDate").style.display = "none";
                document.getElementById("<%=CKEditorDescription.ClientID%>").disabled = true;
         //   alert('view1');
             //   document.getElementById("<%=ddlNamePrefix.ClientID%>").disabled = true;
            document.getElementById("<%=txtCustName.ClientID%>").disabled = true;
        //    alert('view2');
          //      document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked = false;
                document.getElementById("<%=cbxExistingCustomer.ClientID%>").disabled = true;
            document.getElementById("<%=ddlDivision.ClientID%>").disabled = true;
            $noC("div#divDiv input.ui-autocomplete-input").prop('disabled', true);
                document.getElementById("<%=txtTitle.ClientID%>").disabled = true;
            document.getElementById("<%=ddlTeam.ClientID%>").disabled = true;
            $noC("div#divTeam input.ui-autocomplete-input").prop('disabled', true);
                document.getElementById("<%=txtComments.ClientID%>").disabled = true;
                document.getElementById("<%=txtProject.ClientID%>").disabled = true;
                document.getElementById("<%=txtClient.ClientID%>").disabled = true;
                document.getElementById("<%=txtContractor.ClientID%>").disabled = true;
                document.getElementById("<%=txtConsultant.ClientID%>").disabled = true;
                document.getElementById("<%=txtAddress1.ClientID%>").disabled = true;
                document.getElementById("<%=txtAddress2.ClientID%>").disabled = true;
            document.getElementById("<%=txtAddress3.ClientID%>").disabled = true;
                $noC("div#divCou input.ui-autocomplete-input").prop('disabled', true);
                document.getElementById("cphMain_ddlState").disabled = true;
                document.getElementById("cphMain_ddlCity").disabled = true;
                document.getElementById("<%=txtZipCode.ClientID%>").disabled = true;
               
                document.getElementById("<%=txtMobile.ClientID%>").disabled = true;
                document.getElementById("<%=txtPhone.ClientID%>").disabled = true;
                document.getElementById("<%=txtEmail.ClientID%>").disabled = true;
                document.getElementById("<%=txtWebSite.ClientID%>").disabled = true;
                document.getElementById("<%=txtNameOne.ClientID%>").disabled = true;
                document.getElementById("<%=txtAddressOne.ClientID%>").disabled = true;
                document.getElementById("<%=txtMobileOne.ClientID%>").disabled = true;
                document.getElementById("<%=txtPhoneOne.ClientID%>").disabled = true;
                document.getElementById("<%=txtEmailOne.ClientID%>").disabled = true;
                document.getElementById("<%=txtWebsiteOne.ClientID%>").disabled = true;
                //   alert('load mdl');
                document.getElementById("<%=txtNameTwo.ClientID%>").disabled = true;

                document.getElementById("<%=txtAddressTwo.ClientID%>").disabled = true;
                document.getElementById("<%=txtMobileTwo.ClientID%>").disabled = true;
                document.getElementById("<%=txtPhoneTwo.ClientID%>").disabled = true;
                document.getElementById("<%=txtEmailTwo.ClientID%>").disabled = true;
                document.getElementById("<%=txtWebsiteTwo.ClientID%>").disabled = true;
                document.getElementById("<%=txtNameThree.ClientID%>").disabled = true;
                document.getElementById("<%=txtAddressThree.ClientID%>").disabled = true;
                document.getElementById("<%=txtMobileThree.ClientID%>").disabled = true;
                document.getElementById("<%=txtPhoneThree.ClientID%>").disabled = true;
                document.getElementById("<%=txtEmailThree.ClientID%>").disabled = true;
                document.getElementById("<%=txtWebsiteThree.ClientID%>").disabled = true;

                // alert('load mdl3');
            document.getElementById("<%=ddlLeadRate.ClientID%>").disabled = true;
            document.getElementById("<%=btnNewProjectddlH.ClientID%>").style.visibility = "hidden";
            document.getElementById("<%=btnNewProjectddl.ClientID%>").style.visibility = "hidden";
            document.getElementById("<%=btnNewProject.ClientID%>").style.visibility = "hidden";
            document.getElementById("<%=btnNewProjectH.ClientID%>").style.visibility = "hidden";
            document.getElementById("<%=btnNewCust.ClientID%>").style.visibility = "hidden";
            document.getElementById("<%=btnNewCustH.ClientID%>").style.visibility = "hidden";
            document.getElementById("<%=btnNewCustddl.ClientID%>").style.visibility = "hidden";
            document.getElementById("<%=btnNewCustddlH.ClientID%>").style.visibility = "hidden";
            if (document.getElementById("<%=HiddenCustomerSet.ClientID%>").value == "0") {
                document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked = false;
            }
            else {
                document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked = true;
            }
            }
            else {

                if (document.getElementById("<%=HiddenCustomerSet.ClientID%>").value == "0") {
                    document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked = false;
                } else {
                    document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked = true;
                }




            }
            //  alert('load middle');
            if (ViewVal == "") {

                AddFileUpload();
            }


            if (document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked == false) {
                document.getElementById("divExistingCust").style.display = "none";
                document.getElementById("divNewCust").style.display = ""
            }
            else {
                document.getElementById("divNewCust").style.display = "none";
                document.getElementById("divExistingCust").style.display = "";
                if (document.getElementById("<%=HiddenCustomerSet.ClientID%>").value =="0") {

                    document.getElementById("<%=ddlExistingCustomer.ClientID%>").value = "--SELECT CUSTOMER/COMPANY--";
                    var a = $noC("#cphMain_ddlExistingCustomer option:selected").text();
                    $noC("div#divExistingCust input.ui-autocomplete-input").val(a);
                
                }
            }

            if (document.getElementById("<%=cbxExistingProject.ClientID%>").checked == false) {
                document.getElementById("divExistingProject").style.display = "none";
                document.getElementById("divNewProject").style.display = ""
            }
            else {
                document.getElementById("divNewProject").style.display = "none";
                document.getElementById("divExistingProject").style.display = "";

            }
            if (document.getElementById("<%=cbxExistingClient.ClientID%>").checked == false) {
                document.getElementById("divExistingClient").style.display = "none";
                document.getElementById("divNewClient").style.display = ""
            }
            else {
                document.getElementById("divNewClient").style.display = "none";
                document.getElementById("divExistingClient").style.display = "";

            }
            if (document.getElementById("<%=cbxExistingContractor.ClientID%>").checked == false) {
                document.getElementById("divExistingContractor").style.display = "none";
                document.getElementById("divNewContractor").style.display = ""
            }
            else {
                document.getElementById("divNewContractor").style.display = "none";
                document.getElementById("divExistingContractor").style.display = "";

            }
            if (document.getElementById("<%=cbxExistingConsultant.ClientID%>").checked == false) {
                document.getElementById("divExistingConsultant").style.display = "none";
                document.getElementById("divNewConsultant").style.display = ""
            }
            else {
                document.getElementById("divNewConsultant").style.display = "none";
                document.getElementById("divExistingConsultant").style.display = "";

            }

            //  alert('loaded');

        });
    </script>

    <script>

        function CbxChange() {
            if (document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked == false) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "The contact details will be cleared if you change the existing customer/company",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        ClearAll();
                        IncrmntConfrmCounter();
                        document.getElementById("divExistingCust").style.display = "none";
                        document.getElementById("divNewCust").style.display = "";
                        $(".dis_1").hide();
                        $(".dis_1_a").show();
                        $("#cphMain_txtAddress1").prop('disabled', false);
                        $("#cphMain_txtAddress2").prop('disabled', false);
                        $("#cphMain_txtAddress3").prop('disabled', false);
                        $("div#divCou input.ui-autocomplete-input").prop('disabled', false);
                        $("#cphMain_ddlState").prop('disabled', false);
                        $("#cphMain_ddlCity").prop('disabled', false);
                        $("#cphMain_txtZipCode").prop('disabled', false);
                        $("#cphMain_txtMobile").prop('disabled', false);
                        $("#cphMain_txtPhone").prop('disabled', false);
                        $("#cphMain_txtEmail").prop('disabled', false);
                        $("#cphMain_txtWebSite").prop('disabled', false);
                        return false;
                    }
                    else {
                        document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked = true;
                        return false;
                    }
                });             
            }
            else {
                $(".dis_1").show();
                $(".dis_1_a").hide();
                $("#cphMain_txtAddress1").prop('disabled', true);
                $("#cphMain_txtAddress2").prop('disabled', true);
                $("#cphMain_txtAddress3").prop('disabled', true);
                $("div#divCou input.ui-autocomplete-input").prop('disabled', true);
                $("#cphMain_ddlState").prop('disabled', true);
                $("#cphMain_ddlCity").prop('disabled', true);
                $("#cphMain_txtZipCode").prop('disabled', true);
                $("#cphMain_txtMobile").prop('disabled', true);
                $("#cphMain_txtPhone").prop('disabled', true);
                $("#cphMain_txtEmail").prop('disabled', true);
                $("#cphMain_txtWebSite").prop('disabled', true);
                IncrmntConfrmCounter();
                document.getElementById("divNewCust").style.display = "none";
                document.getElementById("divExistingCust").style.display = "";
                document.getElementById("<%=ddlExistingCustomer.ClientID%>").value = "--SELECT CUSTOMER/COMPANY--";
                var a = $noC("#cphMain_ddlExistingCustomer option:selected").text();
                $noC("div#divExistingCust input.ui-autocomplete-input").val(a);

            }
            return false;
        }
        function CbxChangeProject() {
            IncrmntConfrmCounter();
            if (document.getElementById("<%=cbxExistingProject.ClientID%>").checked == false) {
                document.getElementById("divExistingProject").style.display = "none";
                document.getElementById("divNewProject").style.display = "";
                //   document.getElementById("<%=txtProject.ClientID%>").value = "";               
                $("#cphMain_ba_box1").prop('disabled', false);
                $("#cphMain_ba_box2").prop('disabled', false);
            }
            else {
                document.getElementById("divNewProject").style.display = "none";
                document.getElementById("divExistingProject").style.display = "";              
                $("#cphMain_ba_box1").prop('disabled', true);
                $("#cphMain_ba_box2").prop('disabled', true);
             //   var desiredValueProject = "--SELECT PROJECT--";
             //   var elProject = document.getElementById("<%=ddlExistingProject.ClientID%>");
             //   for (var i = 0; i < elProject.options.length; i++) {
              //      if (elProject.options[i].value == desiredValueProject) {
              //          elProject.selectedIndex = i;
            //            break;
              //      }
             //   }

            }

            return false;
        }
        function CbxChangeClient() {
            IncrmntConfrmCounter();
            if (document.getElementById("<%=cbxExistingClient.ClientID%>").checked == false) {
                   document.getElementById("divExistingClient").style.display = "none";
                   document.getElementById("divNewClient").style.display = "";
                 //  document.getElementById("<%=txtClient.ClientID%>").value = "";
               }
               else {
                   document.getElementById("divNewClient").style.display = "none";
                   document.getElementById("divExistingClient").style.display = "";
                 //  var desiredValueClient = "--SELECT CLIENT--";
                 //  var elClient = document.getElementById("<%=ddlExistingClient.ClientID%>");
              //  for (var i = 0; i < elClient.options.length; i++) {
              //      if (elClient.options[i].value == desiredValueClient) {
                 //       elClient.selectedIndex = i;
                 //       break;
                 //   }
                //}

            }

            return false;
        }

        function CbxChangeContractor() {
            IncrmntConfrmCounter();
            if (document.getElementById("<%=cbxExistingContractor.ClientID%>").checked == false) {
                document.getElementById("divExistingContractor").style.display = "none";
                document.getElementById("divNewContractor").style.display = "";
            //    document.getElementById("<%=txtContractor.ClientID%>").value = "";
             }
             else {
                document.getElementById("divNewContractor").style.display = "none";
                document.getElementById("divExistingContractor").style.display = "";
              //  var desiredValueContractor = "--SELECT CONTRACTOR--";
              //  var elContractor = document.getElementById("<%=ddlExistingContractor.ClientID%>");
             //   for (var i = 0; i < elContractor.options.length; i++) {
              //      if (elContractor.options[i].value == desiredValueContractor) {
              //          elContractor.selectedIndex = i;
               //            break;
              //         }
              //     }

               }

               return false;
           }
      
        function CbxChangeConsultant() {
            IncrmntConfrmCounter();
            if (document.getElementById("<%=cbxExistingConsultant.ClientID%>").checked == false) {
                document.getElementById("divExistingConsultant").style.display = "none";
                document.getElementById("divNewConsultant").style.display = "";
              //  document.getElementById("<%=txtConsultant.ClientID%>").value = "";
             }
             else {
                document.getElementById("divNewConsultant").style.display = "none";
                document.getElementById("divExistingConsultant").style.display = "";
             //   var desiredValueConsultant = "--SELECT CONSULTANT--";
              //   var elConsultant = document.getElementById("<%=ddlExistingConsultant.ClientID%>");
             //   for (var i = 0; i < elConsultant.options.length; i++) {
             //       if (elConsultant.options[i].value == desiredValueConsultant) {
             //           elConsultant.selectedIndex = i;
               //         break;
                //    }
             //   }

            }

            return false;
        }

        function CustomerSet() {
            document.getElementById("divNewCust").style.display = "none";
            document.getElementById("divExistingCust").style.display = "";
            //  alert('yes');
           
        }

    </script>   
    <script>
        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {
              
                $au('#cphMain_ddlExistingCustomer').selectToAutocomplete1Letter();
                $au('#cphMain_ddlExistingProject').selectToAutocomplete1Letter();
                $au('#cphMain_ddlExistingClient').selectToAutocomplete1Letter();
                $au('#cphMain_ddlExistingContractor').selectToAutocomplete1Letter();
                $au('#cphMain_ddlExistingConsultant').selectToAutocomplete1Letter();  
                
                $au('#cphMain_ddlDivision').selectToAutocomplete1Letter(); 
                $au('#cphMain_ddlTeam').selectToAutocomplete1Letter(); 
                $au('#cphMain_ddlCountry').selectToAutocomplete1Letter();
                
                $au('form').submit(function () {

                    //   alert($au(this).serialize());


                    //   return false;
                });
            });
        })(jQuery);
     </script>
    <script>
        var $au = jQuery.noConflict();
        function UpdatePanelProjectLoad(strPrjctId, strGModeId) {
            //since both are in update panel
            if (document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked == false) {
                document.getElementById("divExistingCust").style.display = "none";
                document.getElementById("divNewCust").style.display = ""
            }
            else {
                document.getElementById("divNewCust").style.display = "none";
                document.getElementById("divExistingCust").style.display = "";

            }
            CheckSubmitZero();
            if (strPrjctId != '') {
                document.getElementById("<%=cbxExistingProject.ClientID%>").checked = true;
                document.getElementById("<%=txtProject.ClientID%>").value = '';
            }
            if (document.getElementById("<%=cbxExistingProject.ClientID%>").checked == false) {
                document.getElementById("divExistingProject").style.display = "none";
                document.getElementById("divNewProject").style.display = ""
            }
            else {
                document.getElementById("divNewProject").style.display = "none";
                document.getElementById("divExistingProject").style.display = "";

            }
      
            $au('#cphMain_ddlExistingProject').selectToAutocomplete1Letter();
            $au('#cphMain_ddlExistingCustomer').selectToAutocomplete1Letter();
            document.getElementById("<%=ddlExistingProject.ClientID%>").style.borderColor = "";
            $au("div#divExistingProject input.ui-autocomplete-input").css("borderColor", "");

            document.getElementById("<%=ddlExistingProject.ClientID%>").value = strPrjctId;          
            if(strGModeId==101){//awarded
                $(".awd1").click();             
            }
            else if(strGModeId==102){//bidding
                $(".bid1").click();             
            }

            var a = $au("#cphMain_ddlExistingProject option:selected").text();
           
            $au("div#divExistingProject input.ui-autocomplete-input").val(a);

            document.getElementById("<%=ddlExistingProject.ClientID%>").focus();
            $au("#cphMain_ddlExistingProject").select();
          
        }

        function ProjectAutoComplete(strGuaranteeModeID) {
            if (document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked == false) {
                document.getElementById("divExistingCust").style.display = "none";
                document.getElementById("divNewCust").style.display = ""
            }
            else {
                document.getElementById("divNewCust").style.display = "none";
                document.getElementById("divExistingCust").style.display = "";

            }
            $au('#cphMain_ddlExistingProject').selectToAutocomplete1Letter();
            $au('#cphMain_ddlExistingCustomer').selectToAutocomplete1Letter();
            document.getElementById("<%=ddlExistingCustomer.ClientID%>").style.borderColor = "";
            $au("div#divExistingCust input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById("<%=ddlExistingProject.ClientID%>").style.borderColor = "";
            $au("div#divExistingProject input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById("divNewProject").style.display = "none";
            document.getElementById("divExistingProject").style.display = "";
            if (strGuaranteeModeID != 0) {             
                if(strGuaranteeModeID==101){//awarded
                    $(".awd1").click();             
                }
                else if(strGuaranteeModeID==102){//bidding
                    $(".bid1").click();             
                }
            }
        }
        function UpdatePanelCustomerLoad(strCustId) {
            document.getElementById("<%=hiddenNewCustId.ClientID%>").value = "";

            //since both are in update panel
            if (document.getElementById("<%=cbxExistingProject.ClientID%>").checked == false) {
                document.getElementById("divExistingProject").style.display = "none";
                document.getElementById("divNewProject").style.display = ""
            }
            else {
                document.getElementById("divNewProject").style.display = "none";
                document.getElementById("divExistingProject").style.display = "";

            }

            CheckSubmitZero();
            if (strCustId != '') {
                document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked = true;
                document.getElementById("<%=txtCustName.ClientID%>").value = '';
            }
            if (document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked == false) {
                document.getElementById("divExistingCust").style.display = "none";
                 document.getElementById("divNewCust").style.display = ""
             }
             else {
                document.getElementById("divNewCust").style.display = "none";
                 document.getElementById("divExistingCust").style.display = "";

             }

            $au('#cphMain_ddlExistingCustomer').selectToAutocomplete1Letter();

             document.getElementById("<%=ddlExistingCustomer.ClientID%>").style.borderColor = "";
            $au("div#divExistingCust input.ui-autocomplete-input").css("borderColor", "");

            document.getElementById("<%=ddlExistingCustomer.ClientID%>").value = strCustId;
            var a = $au("#cphMain_ddlExistingCustomer option:selected").text();

            $au("div#divExistingCust input.ui-autocomplete-input").val(a);

            document.getElementById("<%=ddlExistingCustomer.ClientID%>").focus();
            $au("#cphMain_ddlExistingCustomer").select();
            NewCustomerLoad();
        }

        </script>
        <script type="text/javascript">
            //web method for checking duplication
            function DuplicationProjectWebMethod(CORPID, ORGID, PROJECTNAME) {

                $.ajax({
                    type: "POST",
                    async: false,
                    url: "gen_Lead.aspx/CheckDuplicationProject",
                    data: '{corporateId: "' + CORPID + '",organisationId:"' + ORGID + '" ,ProjectName:"' + PROJECTNAME + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        if (response.d == false) {
                            document.getElementById("<%=hiddenDupplicatedProject.ClientID%>").value = "false";

                    }
                    else {
                        document.getElementById("<%=hiddenDupplicatedProject.ClientID%>").value = "true";

                    }
                }
            });
        }

    </script>

    <script type="text/javascript">
        function NewCustPageLoad(obj) {
            var $noC = jQuery.noConflict();
            ezBSAlert({
                type: "confirm",
                messageText: "If you are adding new customer/company then  details may change",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var CustNme = '';
                    if (obj == "txtCustName") {

                        CustNme = document.getElementById("<%=txtCustName.ClientID%>").value;

                }
                else if (obj == "ddlExistingCustomer") {

                    //    CustNme = $noC("#cphMain_ddlExistingCustomer option:selected").text();
                    //   if(CustNme=='--SELECT CUSTOMER/COMPANY--')
                    //   {

                    //    CustNme="";
                    //    }
                    CustNme = ''
                }
                var nWindow = window.open('/Master/gen_Customer_Master/gen_Customer_Master.aspx?CFAM=' + CustNme + '', 'PoP_Up', 'width=1200,height=630,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                nWindow.focus();
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }

        function NewProjectLoad(obj) {
            var $noC = jQuery.noConflict();
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to add new project?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var PrjctNme = '';
                    var Division = "";
                    var Customer = "";
                    Division = $noC("#cphMain_ddlDivision option:selected").text();
                    if (Division == "--SELECT YOUR DIVISION--") {
                        ezBSAlert({
                            type: "alert",
                            messageText: "Please Select A Division To Continue",
                            alertType: "info"
                        });  
                        //alert("Please Select A Division To Continue");
                        return false;
                    }
                    else {
                        Division = $noC("#cphMain_ddlDivision option:selected").val();

                    }
                    Customer = $noC("#cphMain_ddlExistingCustomer option:selected").text();
                    if (Customer == "--SELECT CUSTOMER/COMPANY--") {

                        Customer = "";
                        //alert("Please Select A Customer/Company To Continue");
                        //return false;
                    }
                    else {
                        Customer = $noC("#cphMain_ddlExistingCustomer option:selected").val();

                    }



                    if (obj == "txtProject") {

                        PrjctNme = document.getElementById("<%=txtProject.ClientID%>").value;

                }
                else if (obj == "ddlExistingProject") {

                    //    CustNme = $noC("#cphMain_ddlExistingCustomer option:selected").text();
                    //   if(CustNme=='--SELECT CUSTOMER/COMPANY--')
                    //   {

                    //    CustNme="";
                    //    }
                    PrjctNme = ''
                }
                var nWindow = window.open('/Master/gen_Projects/gen_Projects.aspx?CFAM=' + PrjctNme + '&CFBM=' + Division + '&CFCM=' + Customer + ' ', 'PoP_Up', 'width=1200,height=630,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                nWindow.focus();
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }

        function closeWindow() {
            window.close();
        }
        function PostbackFun(myVal) {
            document.getElementById("<%=hiddenNewCustId.ClientID%>").value = myVal;
            __doPostBack("<%=btnNewCust.UniqueID %>", "");
            return false;
        }

        function PostbackFunProject(myValPrj) {
            document.getElementById("<%=hiddenNewProjectId.ClientID%>").value = myValPrj;
          __doPostBack("<%=btnNewProject.UniqueID %>", "");
          return false;
      }
        function GetValueFromChild(myVal) {
        
            if (myVal != '')
            {

                //  alert(myVal);
                PostbackFun(myVal);
            //     alert(myVal);
            }
        }
        function GetValueFromChildProject(myVal) {

            if (myVal != '') {

                //  alert(myVal);
                PostbackFunProject(myVal);
                //     alert(myVal);
            }
        }
        //QCLD4 EVM0012

        function loadProjectStatus() {
            var ddlExistingProjectID = document.getElementById("<%=ddlExistingProject.ClientID%>").value;
            if (ddlExistingProjectID != "--SELECT PROJECT--") {
                $.ajax({
                    type: "POST",
                    url: "gen_Lead.aspx/loadProjectStatus",
                    data: '{strExistingPrjID: "' + ddlExistingProjectID + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        //alert(response.d);
                        if (response.d != 0) {                         
                            if(response.d==101){//awarded
                                $(".awd1").click();             
                            }
                            else if(response.d==102){//bidding
                                $(".bid1").click();             
                            }
                            
                        }
                    },
                    failure: function (response) {
                        //   alert(response.d);
                    }
                });
            }

        }
        </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server" >
    
    <asp:HiddenField ID="HiddenFieldddlProjectStatus" runat="server" />
    <asp:HiddenField ID="hiddenL_MODE" runat="server" />
     <asp:HiddenField ID="hiddenAttchmntSlNumber" runat="server" />
     <asp:HiddenField ID="hiddenEdit" runat="server" />
    <asp:HiddenField ID="hiddenView" runat="server" />
        <asp:HiddenField ID="hiddenFilePath" runat="server" />
        <asp:HiddenField ID="hiddenFileMailPath" runat="server" />
      <asp:HiddenField ID="hiddenFileCanclDtlId" runat="server" />
    <asp:HiddenField ID="HiddenField2_FileUpload" runat="server" />
    <asp:HiddenField ID="hiddenEditAttchmnt" runat="server" />
    <asp:HiddenField ID="hiddenMailAttachment" runat="server" />

     <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
      <asp:HiddenField ID="hiddenUserId" runat="server" />
     <asp:HiddenField ID="hiddenFinacialYearId" runat="server" />
      

    <asp:HiddenField ID="HiddenCountryId" runat="server" value="0" />
    <asp:HiddenField ID="HiddenCountryName" runat="server" value="0" />
    <asp:HiddenField ID="HiddenStateId" runat="server" value="0" />
    <asp:HiddenField ID="HiddenStateName" runat="server" value="0" />
    <asp:HiddenField ID="HiddenCityId" runat="server" value="0" />
    <asp:HiddenField ID="HiddenCityName" runat="server" value="0" />
       <asp:HiddenField ID="HiddenFieldState" runat="server" />
    <asp:HiddenField ID="HiddenFieldCity" runat="server" />
 
    <asp:HiddenField ID="HiddenCustomerSet" runat="server" value="1" />
       <asp:HiddenField ID="HiddenCustomerFocus" runat="server" />

        <asp:HiddenField ID="hiddenCurrentDate" runat="server" />

     <asp:HiddenField ID="hiddenProjectMust" runat="server" />
    <asp:HiddenField ID="hiddenEmailMust" runat="server" />

      <asp:HiddenField ID="hiddenDupplicatedProject" runat="server" />
     <asp:HiddenField ID="hiddenNewCustId" runat="server" />
     <asp:HiddenField ID="hiddenNewProjectId" runat="server" />
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
     <ol class="breadcrumb">
       <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
      <li><a href="#" id="ListLink" runat="server">Opportunity</a></li>
      <li id="lblEntryB" runat="server" class="active">New Opportunity</li>
      </ol>
   <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>



    <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">New Opportunity</h2>

        
        <div class="form-group fg2 sa_fg4 sa_480" style=" padding-bottom: 2px;">
          <label for="email" class="fg2_la1">Source:<span class="spn1">*</span></label>
          <select name="ddlLeadSource" id="ddlLeadSource" class="form-control fg2_inp1" autofocus="" runat="server">
            <option value='2' data-image="\Images\opp\fax_b.png" data-imagecss="flag ad" data-title="Fax">Fax</option>
            <option value='1' data-image="\Images\opp\mail_b.png" data-imagecss="flag ae" data-title="Mail">Mail</option>
            <option value='3' data-image="\Images\opp\phone_b.png" data-imagecss="flag af" data-title="Phone">Phone</option>
            <option value='5' data-image="\Images\opp\ref_b.png" data-imagecss="flag ag" data-title="Reference">Reference</option>
            <option value='4' data-image="\Images\opp\oth_b.png" data-imagecss="flag ag" data-title="Others">Others</option>
          </select> 
        </div>
        <div class="form-group fg2 sa_o_fg1">
          <label for="pwd" class="fg2_la1">Date:<span class="spn1">*</span></label>
          <div id="datepicker1" class="input-group date dt_wdt" data-date-format="DD-MM-YYYY">
            <asp:TextBox ID="txtDate" class="form-control inp_bdr inp_mst" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"></asp:TextBox>
            <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
               <script>
                   var $cs = jQuery.noConflict();
                   $cs('#cphMain_txtDate').datepicker({
                       autoclose: true,
                       format: 'dd-mm-yyyy',
                       timepicker: false,
                       endDate: new Date(),
                   });
             </script>
          </div>
        </div>
        <div class="form-group fg2 sa_o_fg1">
          <label for="pwd" class="fg2_la1">Rating & Scoring:<span class="spn1">*</span>
               <asp:DropDownList ID="ddlLeadRate"  class="form-control inp_mst" runat="server"></asp:DropDownList>
        </div>
          <div class="clearfix"></div>
          <div class=" divid"></div>
          <div class="devider"></div>

    <div class="form-group fg12">
      <label for="email" class="fg2_la1">Customer Requirements:<span class="spn1">&nbsp;</span></label><br>
         <CKEditor:CKEditorControl ID="CKEditorDescription" runat="server" Height="200" BasePath="~/ckeditor" RemovePlugins="toolbar" >		
		</CKEditor:CKEditorControl>
<%--<script src="https://cdn.ckeditor.com/4.8.0/full-all/ckeditor.js"></script>
<textarea name="" id="CKEditorDescription" runat="server" cols="30" rows="4">
</textarea>
<script type="text/javascript">
    CKEDITOR.replace('cphMain_CKEditorDescription', {
        skin: 'moono',
        enterMode: CKEDITOR.ENTER_BR,
        shiftEnterMode: CKEDITOR.ENTER_P,
        toolbar: [{ name: 'basicstyles', groups: ['basicstyles'], items: ['Bold', 'Italic', 'Underline', "-", 'TextColor', 'BGColor'] },
                   { name: 'styles', items: ['Format', 'Font', 'FontSize'] },
                   { name: 'scripts', items: ['Subscript', 'Superscript'] },
                   { name: 'justify', groups: ['blocks', 'align'], items: ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'] },
                   { name: 'paragraph', groups: ['list', 'indent'], items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent'] },
                   { name: 'links', items: ['Link', 'Unlink'] },
                   { name: 'insert', items: ['Image'] },
                   { name: 'spell', items: ['jQuerySpellChecker'] },
                   { name: 'table', items: ['Table'] }
        ],
    });

</script>--%>


          <div class="clearfix"></div>
          <div class="free_sp"></div>

          <div class="form-group fg2 fg2_mr">
            <label class="form1 mar_bo">
              <span class="button-checkbox mar_rgt1" style="margin-top: -5px;">
                <label class="switch mar_bo2"  style="margin-bottom: -6px;">
                  <input type="checkbox" id="cbxExistingCustomer"  runat="server" onchange="CbxChange()"/>
                  <span class="slider_tog round"></span>
                </label>
              </span>
              <p class="pz_s mar_bo dis_1" style="padding-top: 0px;display: none;"> Existing Customer/Company:</p>
              <p class="pz_s mar_bo dis_1_a" style="padding-top: 0px;">Customer/Company Name:</p>
              <span class="spn1">*</span> 
            </label>
                <asp:UpdatePanel id="UpdatePanel2" runat="server" >
            <ContentTemplate>

              <asp:DropDownList ID="ddlNamePrefix" style="display:none;" CssClass="leads_field leads_field_dd dd2"  runat="server">   
              </asp:DropDownList>
            <div id="divExistingCust">
                 <asp:DropDownList ID="ddlExistingCustomer" style="display:block;width: 82%!important;" class="form-control fg2_inp1 inp_mst bdr_in_r dt_wdt" runat="server" onblur="return CustomerLoad();" onfocus="CustomerFocus();"  autofocus="autofocus" autocorrect="off" autocomplete="off">                                        
                 </asp:DropDownList>
                 <asp:Button ID="btnNewCustddl" runat="server" class="save" style="margin-left: 0.1%;  padding: 1%;border-radius: 0px;padding-bottom: 1.2%;display:none;" ToolTip="Add Customer/Company" Text="+"  OnClick="btnNewCust_Click"/>
              <a href="#" ID="btnNewCustddlH" runat="server" onclick="return NewCustPageLoad('ddlExistingCustomer');" title="Add New Customer" class="dt_lxt_n"><span class="input-group-addon cur6"><i class="fa fa-plus"></i></span></a>
            </div>
               <div id="divNewCust" >
                 <asp:TextBox ID="txtCustName" class="form-control fg2_inp1 inp_mst dis_1_a" placeholder="Customer/Company Name" runat="server" MaxLength="100" onblur="RemoveTag(this)" style="text-transform:uppercase;"></asp:TextBox>               
                  <a href="#" ID="btnNewCustH" runat="server" style="display:none;" onclick="return NewCustPageLoad('txtCustName');" title="Add New Customer" class="dt_lxt_n"><span class="input-group-addon cur6"><i class="fa fa-plus"></i></span></a>
                  <asp:Button ID="btnNewCust" runat="server" class="save" style="margin-left: 0.1%;  padding: 1%;border-radius: 0px;padding-bottom: 1.2%;display:none;" ToolTip="Add Customer/Company" Text="+"  OnClick="btnNewCust_Click"/>
         </div>
                 </ContentTemplate>
        </asp:UpdatePanel>
          </div>


          <div class="form-group fg2 fg2_mr">
            <label for="email" class="fg2_la1">Address 1:<span class="spn1">*</span></label>
               <asp:TextBox ID="txtAddress1" class="form-control fg2_inp1  inp_mst" placeholder="Address 1" runat="server" MaxLength="150" onblur="RemoveTag(this)"></asp:TextBox>
           
          </div>
          <div class="form-group fg2 fg2_mr">
            <label for="email" class="fg2_la1">Address 2:<span class="spn1"></span></label>
               <asp:TextBox ID="txtAddress2" MaxLength="150" class="form-control fg2_inp1" placeholder="Address 2" runat="server" onblur="RemoveTag(this)"></asp:TextBox>
          </div>
          <div class="form-group fg2 fg2_mr">
            <label for="email" class="fg2_la1">Address 3:<span class="spn1"></span></label>
               <asp:TextBox ID="txtAddress3" class="form-control fg2_inp1" placeholder="Address 3" runat="server" MaxLength="150" onblur="RemoveTag(this)"></asp:TextBox>
          </div>

          <div class="form-group fg2 sa_o_fg4" id="divCou">
           <label for="email" class="fg2_la1">Country:<span class="spn1"></span></label>
               <asp:DropDownList ID="ddlCountry" class="form-control fg2_inp1" runat="server"  onchange="changeCountry();"></asp:DropDownList>
        </div>

              <div class="form-group fg2 sa_o_fg4">
               <label for="email" class="fg2_la1">State:<span class="spn1"></span></label>
                   <asp:TextBox ID="ddlState"  onchange="changeState();" class="form-control fg2_inp1"  placeholder="--SELECT YOUR STATE--"   runat="server"  onkeypress="return selectorToAutocompleteState(event);" onkeydown="return selectorToAutocompleteState(event);"></asp:TextBox>
                          
              </div>

               <div class="form-group fg2 sa_o_fg4">
               <label for="email" class="fg2_la1">City:<span class="spn8"></span></label>
                   <asp:TextBox ID="ddlCity"  onchange="changeCity();" class="form-control fg2_inp1"  placeholder="--SELECT YOUR CITY--"   runat="server"  onkeypress="return selectorToAutocompleteCity(event);" onkeydown="return selectorToAutocompleteCity(event);"></asp:TextBox>         
              </div>

              <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Postal Code:<span class="spn1">&nbsp;</span></label>
                   <asp:TextBox ID="txtZipCode" class="form-control fg2_inp1" placeholder="Postal Code" runat="server" MaxLength="10" onblur="RemoveTag(this)"></asp:TextBox>
              </div>
              <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Mobile#:<span class="spn1">*&nbsp;</span></label>
                 <asp:TextBox ID="txtMobile" class="form-control fg2_inp1 inp_mst" placeholder="Mobile#" runat="server" MaxLength="50" Style="text-transform: uppercase;" onkeydown="return isNumber(event)" onblur="NumberOnly(this)" ></asp:TextBox>
                 <p class="error" id="ErrorMsgMob" style="display:none">Please enter valid mobile number</p>
              </div>
              <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Phone#:<span class="spn1">&nbsp;</span></label>
                   <asp:TextBox ID="txtPhone" class="form-control fg2_inp1" placeholder="Phone#" runat="server" MaxLength="50" onkeydown="return isNumber(event)" onblur="NumberOnly(this)"></asp:TextBox>
              </div>
              <div class="form-group fg2 fg2_mr sa_o_fg4" id="div8">
                <label for="email" class="fg2_la1">Email ID:<span class="spn1" id="h3Email" runat="server">&nbsp;</span></label>
                   <asp:TextBox ID="txtEmail" class="form-control fg2_inp1 inp_mst" placeholder="Email ID" runat="server" MaxLength="100" onblur="RemoveTag(this)"></asp:TextBox>
                    <p class="error" id="ErrorMsgEmail" style="display:none;">Please enter valid email address</p>
              </div>
              <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Website:<span class="spn1">&nbsp;</span></label>
                   <asp:TextBox ID="txtWebSite" class="form-control fg2_inp1" placeholder="Website" runat="server" MaxLength="100" onblur="RemoveTag(this)"></asp:TextBox>
              </div>


       <button class="btn act_btn bn11_chk pull-right" title="Social Media" id="popoverOpener" data-height="400" data-width="600" onclick="return false;">
          <i class="opp_ico_img_ptp1"><img src="/Images/opp/social.png"></i>
        </button>    
         <asp:HiddenField ID="hiddenMedia" runat="server" />
        <div id="popoverWrapper">
          <div class="popover" role="tooltip">
            <div class="arrow"></div>
            <h3 class="popover-title">Social Media</h3>
            <div class="popover-content">
              <table class="table table-bordered tbl_480">
                <tbody id="divMedia" runat="server">                 
                </tbody>
              </table><br><div class="clearfix"></div><div class="devider"></div>
              <button class="btn btn-danger btn-dz flt_r" style="margin-left:4px;"">Close</button>
               <%-- <button class="btn btn-success flt_r">Submit</button>--%>
            </div>
          </div>
        </div>

              <div class="clearfix"></div>
              <div class="devider"></div>

              <p class="plc1 tr_l cont1"></span>Miscellaneous</p>
                <div class="form-group fg2 fg2_mr sa_o_fg1">
                  <label for="email" class="fg2_la1">Opportunity Title:<span class="spn1"></span></label>
                     <asp:TextBox ID="txtTitle" class="form-control fg2_inp1"  placeholder="Opportunity Title" runat="server" MaxLength="999" onblur="RemoveTag(this)"></asp:TextBox>
                 </div>
                <div class="form-group fg2 sa_o_fg1" id="divDiv">
                 <label for="email" class="fg2_la1">Sales Division:<span class="spn1">*</span></label>
                      <asp:DropDownList ID="ddlDivision" class="form-control fg2_inp1 inp_mst" runat="server"></asp:DropDownList>
                </div>

                 <div class="form-group fg2 sa_o_fg1" id="divTeam">
                 <label for="email" class="fg2_la1">Sales Team:<span class="spn1">*</span></label>
                      <asp:DropDownList ID="ddlTeam" class="form-control fg2_inp1 inp_mst" runat="server"></asp:DropDownList>
                </div>
                 <div class="fg2 sa_o_fg1">
                  <div class="">
                    <label for="email" class="fg2_la1">Summary: <span class="spn1">&nbsp;</span></label>
                    <textarea id="txtComments" runat="server" rows="3" cols="40" class="form-control flt_l txt_01 dt_wdt" placeholder="Summary" onblur="RemoveTag(this)" onkeydown="return textCounter(this,2000);" onkeyup="return textCounter(this,2000);"></textarea>
                  </div>
                </div>
              <div class="fg6" style="margin-top: -50px;">
                  <div class="spl_attach dc_top">
                    <label for="email" class="fg2_la1" id="headingFileUpload">Add Documents: <span class="spn1">&nbsp;</span></label>
                    
                     <table id="TableFileUploadContainer" style="width: 100%;">
                     </table>


                  </div>
                </div> 

    <div class="clearfix"></div>
    <div class="devider"></div>

    <p id="headNewContactOne" class="plc1 tr_l bn"><a href="#" title="Click Here to Add Customer Details" onclick="VisibleContactOne()"><span class="badge bel_add"><i class="fa fa-plus"></i></span> Other Contact</a></p>

    <div class="frm" id="divNewContactOne"  style="display:none;">
         <div class="form-group fg2 fg2_mr sa_o_fg4">
            <label for="email" class="fg2_la1">Name:<span class="spn1">*</span></label>
              <asp:TextBox ID="txtNameOne" class="form-control fg2_inp1 inp_mst" placeholder="Name" runat="server" MaxLength="100" Style="text-transform: uppercase;" onblur="RemoveTag(this)" ></asp:TextBox>
          </div>
          <div class="form-group fg2 fg2_mr sa_o_fg4">
            <label for="email" class="fg2_la1">Address:<span class="spn1">*</span></label>
              <asp:TextBox ID="txtAddressOne" class="form-control fg2_inp1 inp_mst"  placeholder="Address" runat="server" MaxLength="150" onblur="RemoveTag(this)"></asp:TextBox>
          </div>
         


          <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Mobile:<span class="spn1"></span></label>
                 <asp:TextBox ID="txtMobileOne" class="form-control fg2_inp1" placeholder="Mobile#" runat="server" MaxLength="50" Style="text-transform: uppercase;" onkeydown="return isNumber(event)" onblur="NumberOnly(this)" ></asp:TextBox>
                 <p class="error" id="ErrorMsgMobileOne" style="display:none">Please enter valid mobile number</p>
              </div>
              <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Phone#:<span class="spn1"></span></label>
                    <asp:TextBox ID="txtPhoneOne" class="form-control fg2_inp1" placeholder="Phone#" runat="server" MaxLength="50" onkeydown="return isNumber(event)" onblur="NumberOnly(this)"></asp:TextBox>
              </div>
              <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Website:<span class="spn1"></span></label>
                   <asp:TextBox ID="txtWebsiteOne" class="form-control fg2_inp1" placeholder="Website" runat="server" MaxLength="100" onblur="RemoveTag(this)"></asp:TextBox>
              </div>
               <div class="form-group fg2 sa_o_2">
                <label for="email" class="fg2_la1">Email:<span class="spn1"></span></label>
                <div class="input-group wid_93p">
                     <asp:TextBox ID="txtEmailOne" class="form-control fg2_inp1 inp_bdr tr_l inp_chec" placeholder="Email" runat="server" MaxLength="100" onblur="RemoveTag(this)"></asp:TextBox>                                   
                  <div class="input-group-addon date1 chec_bx">
                    <div class="check1 flt_n">
                      <div class="">
                        <label class="switch" title="Mail Delivary Allowed">
                          <input type="checkbox" id="cbxAllowOtherMailOne" onkeydown="return DisableEnter(event);"  runat="server">
                          <span class="slider_tog round"></span>
                        </label>
                      </div>
                    </div>
                  </div>
                     <p class="error" id="ErrorMsgEmailOne" style="display:none; ">Please enter valid email address</p> 
                  </div>
                </div>

              <!-- <p class="plc2"><button class="spn1 pull-right cle_oth"><i class="fa fa-refresh"></i> Clear</button></p> -->
              <div class="clearfix"></div>
              <div class="devider"></div>
            
            <p  id="headNewContactTwo" class="plc2 tr_l bl2 sa_1"><a href="#" onclick="VisibleContactTwo()" title="Click Here to Add Other Details"><span class="badge bel_add"><i class="fa fa-plus"></i></span> Other Contact</a></p>

            <div class="frm2" id="divNewContactTwo" style="display: none;">
             <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Name:<span class="spn1">*</span></label>
                  <asp:TextBox ID="txtNameTwo" class="form-control fg2_inp1 inp_mst" placeholder="Name" runat="server" MaxLength="100" Style="text-transform: uppercase;" onblur="RemoveTag(this)"></asp:TextBox>
              </div>

              <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Address:<span class="spn1">*</span></label>
                  <asp:TextBox ID="txtAddressTwo" class="form-control fg2_inp1 inp_mst" placeholder="Address" runat="server" MaxLength="150" onblur="RemoveTag(this)"></asp:TextBox>
              </div>
              
              
           
              <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Mobile:<span class="spn1"></span></label>
                     <asp:TextBox ID="txtMobileTwo" class="form-control fg2_inp1"  placeholder="Mobile#" runat="server" MaxLength="50" Style="text-transform: uppercase;" onkeydown="return isNumber(event)" onblur="NumberOnly(this)" ></asp:TextBox>
                          <p class="error" id="ErrorMsgMobileTwo" style="display:none">Please enter valid mobile number</p>
               
              </div>
              <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Phone#:<span class="spn1"></span></label>
                    <asp:TextBox ID="txtPhoneTwo" class="form-control fg2_inp1" placeholder="Phone#" runat="server" MaxLength="50" onkeydown="return isNumber(event)" onblur="NumberOnly(this)"></asp:TextBox>
              </div>
              <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Website:<span class="spn1"></span></label>
                     <asp:TextBox ID="txtWebsiteTwo" class="form-control fg2_inp1" placeholder="Website" runat="server" MaxLength="100" onblur="RemoveTag(this)"></asp:TextBox>
              </div>
               <div class="form-group fg2 sa_o_2">
                <label for="email" class="fg2_la1">Email:<span class="spn1"></span></label>
                <div class="input-group wid_93p">
                     <asp:TextBox ID="txtEmailTwo" class="form-control fg2_inp1 inp_bdr tr_l inp_chec" placeholder="Email" runat="server" MaxLength="100" onblur="RemoveTag(this)"></asp:TextBox>
                   
                  <div class="input-group-addon date1 chec_bx">
                    <div class="check1 flt_n">
                      <div class="">
                        <label class="switch" title="Mail Delivary Allowed">
                          <input type="checkbox" id="cbxAllowOtherMailTwo" onkeydown="return DisableEnter(event);" runat="server">
                          <span class="slider_tog round"></span>
                        </label>
                      </div>
                    </div>
                  </div>
                      <p class="error" id="ErrorMsgEmailTwo" style="display:none; ">Please enter valid email address</p>
                  </div>
                </div>
              <!---other_contact_2_closed-->
              <!-- <p class="plc2"><button class="spn1 pull-right cle_oth"><i class="fa fa-refresh"></i> Clear</button></p> -->




           <div class="clearfix"></div>
           <div class="devider"></div>
            
            <p  id="headNewContactThree" class="plc2 tr_l bl2 sa_1"><a href="#" onclick="VisibleContactThree()" title="Click Here to Add Other Details"><span class="badge bel_add"><i class="fa fa-plus"></i></span> Other Contact</a></p>

            <div class="frm2" id="divNewContactThree" style="display: none;">
             <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Name:<span class="spn1">*</span></label>
                  <asp:TextBox ID="txtNameThree" class="form-control fg2_inp1 inp_mst" placeholder="Name" runat="server" MaxLength="100" Style="text-transform: uppercase;" onblur="RemoveTag(this)"></asp:TextBox>
              </div>

              <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Address:<span class="spn1">*</span></label>
                  <asp:TextBox ID="txtAddressThree" class="form-control fg2_inp1 inp_mst" placeholder="Address" runat="server" MaxLength="150" onblur="RemoveTag(this)"></asp:TextBox>
              </div>
              
              
           
              <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Mobile:<span class="spn1"></span></label>
                     <asp:TextBox ID="txtMobileThree" class="form-control fg2_inp1"  placeholder="Mobile#" runat="server" MaxLength="50" Style="text-transform: uppercase;" onkeydown="return isNumber(event)" onblur="NumberOnly(this)" ></asp:TextBox>
                          <p class="error" id="ErrorMsgMobileThree" style="display:none">Please enter valid mobile number</p>
               
              </div>
              <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Phone#:<span class="spn1"></span></label>
                    <asp:TextBox ID="txtPhoneThree" class="form-control fg2_inp1" placeholder="Phone#" runat="server" MaxLength="50" onkeydown="return isNumber(event)" onblur="NumberOnly(this)"></asp:TextBox>
              </div>
              <div class="form-group fg2 fg2_mr sa_o_fg4">
                <label for="email" class="fg2_la1">Website:<span class="spn1"></span></label>
                     <asp:TextBox ID="txtWebsiteThree" class="form-control fg2_inp1" placeholder="Website" runat="server" MaxLength="100" onblur="RemoveTag(this)"></asp:TextBox>
              </div>
               <div class="form-group fg2 sa_o_2">
                <label for="email" class="fg2_la1">Email:<span class="spn1"></span></label>
                <div class="input-group wid_93p">
                     <asp:TextBox ID="txtEmailThree" class="form-control fg2_inp1 inp_bdr tr_l inp_chec" placeholder="Email" runat="server" MaxLength="100" onblur="RemoveTag(this)"></asp:TextBox>
                   
                  <div class="input-group-addon date1 chec_bx">
                    <div class="check1 flt_n">
                      <div class="">
                        <label class="switch" title="Mail Delivary Allowed">
                          <input type="checkbox" id="cbxAllowOtherMailThree" onkeydown="return DisableEnter(event);" runat="server">
                          <span class="slider_tog round"></span>
                        </label>
                      </div>
                    </div>
                  </div>
                      <p class="error" id="ErrorMsgEmailThree" style="display:none; ">Please enter valid email address</p>
                  </div>
                </div>
              <!---other_contact_2_closed-->
              <!-- <p class="plc2"><button class="spn1 pull-right cle_oth"><i class="fa fa-refresh"></i> Clear</button></p> -->
            </div>



            </div>
      </div><!--cut_det_closed-->

          <div class="clearfix"></div>
          <div class="devider"></div>



        <p class="plc1 tr_l">Project Details</p>
          <div class="clearfix"></div>

          <div class="form-group fg2 fg2_mr sa_o_fg4">
            <label class="form1 mar_bo" style="width: auto;">
              <span class="button-checkbox mar_rgt1">
                <label class="switch">
                  <input type="checkbox" id="cbxExistingProject"  runat="server" onchange="CbxChangeProject()" >
                  <span class="slider_tog round"></span>
                </label>
              </span>
              <p class="pz_s mr_b_0"> Existing Project:</p><span class="spn1" id="h3Project" runat="server"></span> 
            </label>
              <div class="ch_ab">
                <button class="bid1 sel_ab1" title="Bidding" id="ba_box1" runat="server"><i class="fa fa-stack-exchange"></i> </button>
                <button class="awd1" title="Awarded" id="ba_box2" runat="server"><i class="fa fa-shield"></i> </button>
              </div>
               <asp:UpdatePanel id="UpdatePanel1" UpdateMode="Conditional" runat="server" >
            <ContentTemplate>
                 <div id="divExistingProject">
          
                 <asp:DropDownList ID="ddlExistingProject" class="form-control fg2_inp1 inp_mst"  style="width: 82%!important;" onchange="return loadProjectStatus();"  runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off"  >   

                     </asp:DropDownList>
                      <a href="#"  id="btnNewProjectddlH" runat="server" title="Add new Project" onclick="return NewProjectLoad('ddlExistingProject')"><span class="input-group-addon cur6"><i class="fa fa-plus"></i></span></a>
                       <asp:Button ID="btnNewProjectddl" runat="server" class="save" style="margin-left: 0%;  padding: 1.3%;border-radius: 0px;padding-bottom: 1.9%; padding-top:4px;display:none;" ToolTip="Add Project" Text="+"  OnClick="btnNewProject_Click"/>
                      </div>
                 <div id="divNewProject" >
                       <asp:TextBox ID="txtProject" class="form-control fg2_inp1 inp_mst"  placeholder="Project Name" style="width: 82%!important;text-transform: uppercase;" runat="server" MaxLength="100"  onblur="RemoveTag(this)"></asp:TextBox>

              <a href="#"  id="btnNewProjectH" runat="server" onclick="return NewProjectLoad('txtProject')" title="Add new Project"><span class="input-group-addon cur6"><i class="fa fa-plus"></i></span></a>
                       <asp:Button ID="btnNewProject" runat="server" class="save" style="margin-left: 0%;  padding: 1.3%;border-radius: 0px;padding-bottom: 1.9%; padding-top:4px;display:none;" ToolTip="Add Project" Text="+"  OnClick="btnNewProject_Click"/>
                </div>
                
                 </ContentTemplate>
        </asp:UpdatePanel>
          </div>


          <div class="form-group fg2 fg2_mr sa_o_fg4">
            <label class="form1 mar_bo">
              <span class="button-checkbox mar_rgt1">
                <label class="switch">
                  <input type="checkbox" id="cbxExistingClient"  runat="server" onchange="CbxChangeClient()">
                  <span class="slider_tog round"></span>
                </label>
              </span>
              <p class="pz_s mr_b_0"> Existing Client:</p><span class="spn1"></span>
            </label>
               <div id="divExistingClient" >
                     <asp:DropDownList ID="ddlExistingClient" class="form-control fg2_inp1" runat="server"  ></asp:DropDownList>
               </div>         
               <div id="divNewClient">
                <asp:TextBox ID="txtClient" class="form-control fg2_inp1" placeholder="Client Name" runat="server" MaxLength="100" Style="text-transform: uppercase; " onblur="RemoveTag(this)"></asp:TextBox>
              </div>
          </div>

          <div class="form-group fg2 fg2_mr sa_o_fg4">
            <label class="form1 mar_bo">
              <span class="button-checkbox mar_rgt1">
                <label class="switch" >
                  <input type="checkbox" id="cbxExistingContractor"  runat="server" onchange="CbxChangeContractor()" >
                  <span class="slider_tog round"></span>
                </label>
              </span>
              <p class="pz_s mr_b_0"> Existing Contractor:</p><span class="spn1"></span>
            </label>
               <div id="divNewContractor">
                <asp:TextBox ID="txtContractor" class="form-control fg2_inp1" placeholder="Contractor Name" runat="server" MaxLength="100" Style="text-transform: uppercase; " onblur="RemoveTag(this)"></asp:TextBox>
               </div>
                <div id="divExistingContractor" >
                     <asp:DropDownList ID="ddlExistingContractor" class="form-control fg2_inp1" runat="server"  >         </asp:DropDownList>
                    </div>
          
          </div>

          <div class="form-group fg2 fg2_mr sa_o_fg4">
            <label class="form1 mar_bo">
              <span class="button-checkbox mar_rgt1">
                <label class="switch" >
                  <input type="checkbox" id="cbxExistingConsultant"  runat="server" onchange="CbxChangeConsultant()" >
                  <span class="slider_tog round"></span>
                </label>
              </span>
              <p class="pz_s mr_b_0"> Existing Consultant:</p><span class="spn1"></span>
            </label>
              <div id="divNewConsultant">
                <asp:TextBox ID="txtConsultant" class="form-control fg2_inp1"  placeholder="Consultant Name" runat="server" MaxLength="100" Style="text-transform: uppercase; " onblur="RemoveTag(this)"></asp:TextBox>
                </div>
                <div id="divExistingConsultant" >
                     <asp:DropDownList ID="ddlExistingConsultant" class="form-control fg2_inp1" runat="server"  >         </asp:DropDownList>
                    </div>           
          </div>

      <div class="clearfix"></div>
      <div class="devider"></div>

      <div class="sub_cont pull-right">
        <div class="save_sec">
               <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClientClick="return SaveValidate();" OnClick="btnUpdate_Click" />
                  <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return SaveValidate();" OnClick="btnUpdate_Click" />
                  <asp:Button ID="btnSave" runat="server" class="btn sub1" Text="Save" OnClick="btnSave_Click" OnClientClick="return SaveValidate();" />
                  <asp:Button ID="btnSaveClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnSave_Click" OnClientClick="return SaveValidate();" />
               <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2" Text="Clear"/>
              <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage1();"  />  
              <asp:Button ID="Button1" runat="server" class="btn sub4" Text="Cancel" OnClick="btnCancel_Click" style="display:none;"/>
        </div>
      </div>

             </div>
            </div>
           </div>
         </div>


    <div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">
          <asp:Button ID="btnUpdateF" runat="server" class="btn sub1 bt_b" Text="Update" OnClientClick="return SaveValidate();" OnClick="btnUpdate_Click" />
                  <asp:Button ID="btnUpdateCloseF" runat="server" class="btn sub3 bt_b" Text="Update & Close" OnClientClick="return SaveValidate();" OnClick="btnUpdate_Click" />
                  <asp:Button ID="btnSaveF" runat="server" class="btn sub1 bt_b" Text="Save" OnClick="btnSave_Click" OnClientClick="return SaveValidate();" />
                  <asp:Button ID="btnSaveCloseF" runat="server" class="btn sub3 bt_b" Text="Save & Close" OnClick="btnSave_Click" OnClientClick="return SaveValidate();" />
               <asp:Button ID="btnClearF" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2 bt_b" Text="Clear"/>
              <asp:Button ID="btnCancelF" runat="server" class="btn sub4 bt_b" Text="Cancel" OnClientClick="return ConfirmMessage1();"  />
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
                  .disabledAll{
   background-color: #eee !important;
opacity: 1 !important;
color: #999 !important;
cursor: not-allowed !important;

}
          .flag {
    padding: 0 !important;
    margin: 0 5px 0 0;
}
            #cphMain_ddlLeadSource_msdd:focus {
            border: 1px solid #48acf2 !important;
        }
          .disabledAll{
   background-color: #eee !important;
opacity: 1 !important;
color: #999 !important;
cursor: not-allowed !important;
 border: 1px solid #ffbfbf !important;
}
        h1, h2, h3, h4, h5, h6, p {
            font-family: 'Open Sans', sans-serif;
        }
    </style>
     <script>
         $(document).ready(function () {
             var $aus = jQuery.noConflict();
             $aus("#cphMain_ddlLeadSource").msDropdown({ roundedBorder: false });
             $aus("#cphMain_ddlLeadSource").msDropdown({ visibleRows: 4 });
             $aus("").msDropdown();
             if (document.getElementById("<%=hiddenView.ClientID%>").value == "")
                 document.getElementById("cphMain_ddlLeadSource_msdd").focus();     
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
    <script type="text/javascript">
        $(document).ready(function(){
            $(".popover.left").style('display:block', function(){
                $(this).find('.skp_id').focus();
            });
        });
</script>

<script type="text/javascript">
    'use strict';
class Popover {
    constructor(element, trigger, options) {
        this.options = { // defaults
            position: Popover.LEFT
        };
        this.element = element;
        this.trigger = trigger;
        this._isOpen = false;
        Object.assign(this.options, options);
        this.events();
        this.initialPosition();
    }

    events() {
        this.trigger.addEventListener('click', this.toggle.bind(this));
    }

    initialPosition() {
      let triggerRect = this.trigger.getBoundingClientRect();
        this.element.style.top = ~~triggerRect.top + 'px';
        this.element.style.left = ~~triggerRect.left + 'px';
    }

    toggle(e) {
        e.stopPropagation();
        if (this._isOpen) {
            this.close(e);
        } else {
            this.element.style.display = 'block';
            this._isOpen = true;
            this.outsideClick();
            this.position();
        }
    }

    targetIsInsideElement(e) {
      let target = e.target;
        if (target) {
            do {
                if (target === this.element) {
                    return true;
                }
            } while (target = target.parentNode);
        }
        return false;
    }

    close(e) {
        if (!this.targetIsInsideElement(e)) {
            this.element.style.display = 'block';
            this._isOpen = false;
            this.killOutSideClick();
        }
    }

    position(overridePosition) {
      let triggerRect = this.trigger.getBoundingClientRect(),
        elementRect = this.element.getBoundingClientRect(),
        position = overridePosition || this.options.position;
        this.element.classList.remove(Popover.TOP, Popover.BOTTOM, Popover.LEFT, Popover.RIGHT); // remove all possible values
        this.element.classList.add(position);
        if (position.indexOf(Popover.BOTTOM) !== -1) {
            this.element.style.left = ~~triggerRect.left + ~~((triggerRect.width / 2) - ~~(elementRect.width / 2)) + 'px';
            this.element.style.top = ~~triggerRect.bottom + 'px';
        } else if (position.indexOf(Popover.TOP) !== -1) {
            this.element.style.left = ~~triggerRect.left + ~~((triggerRect.width / 2) - ~~(elementRect.width / 2)) + 'px';
            this.element.style.top = ~~(triggerRect.top - elementRect.height) + 'px';
        } else if (position.indexOf(Popover.LEFT) !== -1) {
            this.element.style.top = ~~((triggerRect.top + triggerRect.height / 2) - ~~(elementRect.height / 2)) + 'px';
            this.element.style.left = ~~(triggerRect.left - elementRect.width) + 'px';
        } else {
            this.element.style.top = ~~((triggerRect.top + triggerRect.height / 2) - ~~(elementRect.height / 2)) + 'px';
            this.element.style.left = ~~triggerRect.right + 'px';
            this.element.classList.add(position);
        }
    }

    outsideClick() {
        document.addEventListener('', this.close.bind(this));
    }

    // killOutSideClick() {
    //   document.removeEventListener('click', this.close.bind(this));
    // }

    isOpen() {
        return this._isOpen;
    }
}

    Popover.TOP = 'top';
    Popover.RIGHT = 'right';
    Popover.BOTTOM = 'bottom';
    Popover.LEFT = 'left';

    document.addEventListener('DOMContentLoaded', function() {
      let btn = document.querySelector('#popoverOpener'),
        template = document.querySelector('.popover'),
        pop = new Popover(template, btn, {
            position: Popover.LEFT
        }),
        links = template.querySelectorAll('.popover-content a');
        for (let i = 0, len = links.length; i < len; ++i) {
          let link = links[i];
            console.log(link);
            link.addEventListener('click', function(e) {
                e.preventDefault();
                pop.position(this.className);
                this.blur();
                return true;
            });
        }
    });

    $(document).on('keydown', function(e) { 
        var keyCode = e.keyCode || e.which; 

        if (keyCode == 27) { 
            $('.popover.left').hide("");
        } 
    });
    $(document).on("click", ".popover.left .btn-dz" , function(){
        $('.popover.left').hide("");
        return false;
    });
</script>
    <script type="text/javascript">
        $(document).ready(function(){
            $(".bid1").click(function(){
                $(".bid1").addClass("sel_ab1");
                $(".awd1").removeClass("sel_ab1");
                return false;
            });
            $(".awd1").click(function(){
                $(".awd1").addClass("sel_ab1");
                $(".bid1").removeClass("sel_ab1");
                return false;
            });
            var strGModeId=document.getElementById("<%=HiddenFieldddlProjectStatus.ClientID%>").value;          
            if(strGModeId==101){//awarded
                $(".awd1").click();             
            }
            else if(strGModeId==102){//bidding
                $(".bid1").click();             
            }
            if (document.getElementById("<%=cbxExistingCustomer.ClientID%>").checked == false) {               
                $(".dis_1").hide();
                $(".dis_1_a").show(); 
                $("#cphMain_txtAddress1").prop('disabled', false);
                $("#cphMain_txtAddress2").prop('disabled', false);
                $("#cphMain_txtAddress3").prop('disabled', false);              
                $("div#divCou input.ui-autocomplete-input").prop('disabled', false);
                $("#cphMain_ddlState").prop('disabled', false);
                $("#cphMain_ddlCity").prop('disabled', false);
                $("#cphMain_txtZipCode").prop('disabled', false);
                $("#cphMain_txtMobile").prop('disabled', false);
                $("#cphMain_txtPhone").prop('disabled', false);
                $("#cphMain_txtEmail").prop('disabled', false);
                $("#cphMain_txtWebSite").prop('disabled', false);
            }
            else {
                $(".dis_1").show();
                $(".dis_1_a").hide();  
                $("#cphMain_txtAddress1").prop('disabled', true);
                $("#cphMain_txtAddress2").prop('disabled', true);
                $("#cphMain_txtAddress3").prop('disabled', true);
                $("div#divCou input.ui-autocomplete-input").prop('disabled', true);
                $("#cphMain_ddlState").prop('disabled', true);
                $("#cphMain_ddlCity").prop('disabled', true);
                $("#cphMain_txtZipCode").prop('disabled', true);
                $("#cphMain_txtMobile").prop('disabled', true);
                $("#cphMain_txtPhone").prop('disabled', true);
                $("#cphMain_txtEmail").prop('disabled', true);
                $("#cphMain_txtWebSite").prop('disabled', true);
            }
        });
</script>
    <style type="text/css">
  .popover-content{max-height:340px;}
  .popover.top{max-width:260px;}
  .popover{min-width: 550px;}
  .cke_chrome {
    display: block;
    border: 1px solid #b6b6b6;
    padding: 0;
    box-shadow: 0 0 3px rgba(0,0,0,.15);
}
  .cke_1.cke_chrome {
    border-color: #b6b6b6 !important;
}
</style>
</asp:Content>

