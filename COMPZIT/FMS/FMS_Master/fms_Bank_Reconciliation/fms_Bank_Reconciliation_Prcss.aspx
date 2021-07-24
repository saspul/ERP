<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzitFinance.master" CodeFile="fms_Bank_Reconciliation_Prcss.aspx.cs" Inherits="FMS_FMS_Master_fms_Bank_Reconciliation_fms_Bank_Reconciliation_Prcss" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    
      <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>

    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/bootstrap.min.css" rel="stylesheet" />

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
    <script src="js/jquery.min.js"></script>


     <script>
         function ConfirmMessage() {
             if (confirmbox > 0) {
                 ezBSAlert({
                     type: "confirm",
                     messageText: "Are you sure you want to leave this page?",
                     alertType: "info"
                 }).done(function (e) {
                     if (e == true) {
                         window.location.href = "fms_Receipt_Account_List.aspx";
                     }
                     else {
                         return false;
                     }
                 });
                 return false;
             }
             else {
                 window.location.href = "fms_Receipt_Account_List.aspx";
                 return false;
             }
         }
         function SuccessMsg() {

             $noCon("#success-alert").html("Receipt details inserted successfully.");
             $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
             });
             $noCon("#success-alert").alert();

             return false;


         }
         function SuccessUpdMsg() {

             $noCon("#success-alert").html("Receipt details updated successfully.");
             $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
             });
             $noCon("#success-alert").alert();

             return false;


         }

         function addCommas(textboxid) {
             //   alert(textboxid);
             nStr = document.getElementById(textboxid).value;
             //  alert(nStr);
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


    </script>

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
           



        });


    </script>

    <script>


        function Validate()
        {
            var ret = true;
            var flag = 0;
            var Varcount = document.getElementById("<%=HiddenRowCount.ClientID%>").value;
            if (Varcount == "0") {
                 ret = false;
            }
            else {
                $('#TableVouchers').find('input[type="checkbox"]:checked').each(function () {
                    var row = $(this);
                    flag++;
                    //this is the current checkbox
                  //  row.val();

                    if (document.getElementById("<%=HiddenVouchers.ClientID%>").value == "") {
                        document.getElementById("<%=HiddenVouchers.ClientID%>").value = row.val();
                    }
                    else {
                        document.getElementById("<%=HiddenVouchers.ClientID%>").value = document.getElementById("<%=HiddenVouchers.ClientID%>").value + "," + row.val();
                    }
                    
                });

               
            }
            if (flag != 0)
            {
                ret = false;
            }
            return false;
        }

       


    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

        <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
     <asp:HiddenField ID="Hiddentxtefctvedate" runat="server" />
    <asp:HiddenField ID="HiddentxtefctvedateTo" runat="server" />
      <asp:HiddenField ID="HiddenFieldTaxId" runat="server" />
      <asp:HiddenField ID="HiddenRowCount" runat="server" />
       <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
      <asp:HiddenField ID="Hiddenreturnfun" runat="server" />
      <asp:HiddenField ID="HiddenVouchers" runat="server" />
      <asp:HiddenField ID="HiddenVouchrTyp" runat="server" />


      
     <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <%-- <div id="main" role="main">--%>
      
        <div class="cont_rght" >
                  <div style="height:34px;">
  
                    <div class="alert alert-danger" id="divWarning" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>
                    <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button> 
        </div>
            <section id="widget-grid" class="">

                <div class="row">
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <div class="" id="wid-id-0">


        <div id="divReportCaption" runat="server" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <%--  <img src="/Images/BigIcons/Job_Delegation.png" style="vertical-align: middle;" />--%>
     <asp:Label ID="lblEntry" runat="server"></asp:Label>
        </div >
      
        <div  id="divList"  class="list" runat="server" style="position: fixed; right: 1%; top: 42%; height: 26.5px;z-index: 90;" onclick="return ConfirmMessage()">

           
        </div>

                            <br>

  <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: #f6f6f6; float: left">
       

<div class="row">
<div class="container" style="padding-top:18px;padding-bottom: 33px;">

  
  <div class="col-lg-12" style="margin-top:-21px;">


</div>


 

     <div class="row">
                          <div class="col-md-12" style="margin-bottom:20px;">
                      <div runat="server" style="width:55%" id="divBank"></div>
                          </div>
                              
                            
          <script>

            
              function DisableEnter(evt) {
                  evt = (evt) ? evt : window.event;
                  var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                  if (keyCodes == 13) {
                      return false;
                  }
              }
       </script>
                  
 


    
         
         
                                
                                  </div>

             <script>




       </script>

                                    

        
   
  
  <div style="clear:both"></div>
 
      
   
 
    




<div>
<div class="col-md-12" style="padding:9px;">
<div style="float:right;">
    <asp:Button ID="bttnsave"   runat="server" OnClientclick="return Validate();" OnClick="bttnsave_Click"  class="btn btn-primary btn-grey  btn-width" text="PROCESS"    />
 
<%--    <asp:Button ID="btnUpdate"   runat="server" OnClientclick="return ValidateReceiptAccnt();"  class="btn btn-primary btn-grey  btn-width" text="Update" OnClick="btnUpdate_Click"  />
  
    <asp:Button ID="btnConfirm1"   runat="server"  class="btn btn-primary"  Text="Confirm"  OnClick="btnUpdate_Click"/>
<asp:Button ID="btnConfirm" runat="server" class="btn btn-primary" Text="Confirm"  OnClientclick="return ConfirmAlert();"/>
    <input type="button"  id="btnCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn btn-primary btn-grey  btn-width" />--%>
     
</div>
</div>  
</div>
  </div>




  
</div>
<%--</div>
</div>








</div>--%>
  
    </div>

  </div>  </article>  </div>  </section>  </div>  </div>    <br />
    <style>
        .padding5 {
    padding: 5px;
    margin: 0 !important;
}
        .table {
    width: 100%;
    max-width: 100%;
    margin-bottom: 0px;
}
    </style>
    <script type="text/javascript">
        function ConfirmAlert() {
            if (ValidateReceiptAccnt() == true) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to confirm this receipt?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                     
                }
                else {
                    return false;
                }

                });
            return false;
        }
        else {
            return false;

        }
    }

    function isTagEnter(evt) {

        evt = (evt) ? evt : window.event;
        var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

        var charCode = (evt.which) ? evt.which : evt.keyCode;
        var ret = true;
        if (charCode == 60 || charCode == 62) {
            ret = false;
        }
        return ret;
    }

         function isNumber(evt) {

             evt = (evt) ? evt : window.event;
             var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
             var charCode = (evt.which) ? evt.which : evt.keyCode;
             //at enter
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
             else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40 || keyCodes == 110) {
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
    </script>

   <script>
 



       //$aa(document).ready(function () {

       //});
    </script>

    <%--<script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>--%>
  
     <script>
       
         function DisableEnter(evt) {
             evt = (evt) ? evt : window.event;
             var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
             if (keyCodes == 13) {
                 return false;
             }
         }


 
         </script>
</asp:Content>

