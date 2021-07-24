<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzitFinance.master" AutoEventWireup="true" CodeFile="fms_Cheque_Template.aspx.cs" Inherits="FMS_FMS_Master_fms_Cheque_Template_fms_Cheque_Template" %>

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
    <link href="../../../../css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="../../../../js/jQueryUI/jquery-ui.min.js"></script>
    <script src="../../../../js/jQueryUI/jquery-ui.js"></script>
    <script src="../../../../js/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../../js/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="/js/HCM/Common.js"></script>
    <script src="js/jquery.min.js"></script>
    
    <script>
        var $noCondfs = jQuery.noConflict();
        $noCondfs(function () {
            if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                $noCondfs(".draggable").draggable({ containment: "#cphMain_divImgPreview" });
                //$noCondfs(".resizable").resizable({
                //    containment: "#cphMain_divImgPreview"
                //});
            }
            else {
                document.getElementById("lblfileupload").style.pointerEvents = "none";   
            }
        });
    </script>
     <script>
         function ClearDivDisplayImage1() {
             var fi = document.getElementById("<%=FileUploadRecharge.ClientID%>");
             if (fi.files.length > 0) {
                 IncrmntConfrmCounter();
                 for (var i = 0; i <= fi.files.length - 1; i++) {
                     var fileName, fileExtension, fileSize, fileType, dateModified;
                     // FILE NAME AND EXTENSION.
                     fileName = fi.files.item(i).name;
                     fileExtension = fileName.replace(/^.*\./, '');
                     // CHECK IF ITS AN IMAGE FILE.
                     // TO GET THE IMAGE WIDTH AND HEIGHT, WE'LL USE fileReader().
                     if (fileExtension == 'png' || fileExtension == 'jpg' || fileExtension == 'jpeg') {
                         readImageFile(fi.files.item(i));             // GET IMAGE INFO USING fileReader().
                         document.getElementById("<%=Label5.ClientID%>").textContent = document.getElementById("<%=FileUploadRecharge.ClientID%>").value;
                         document.getElementById("divImgPreviewHead").style.display = "block";
                         document.getElementById("cphMain_divImgPreview").style.display = "block";
                         document.getElementById("divPrint").style.display = "block";

                         document.getElementById("cphMain_lblPayeeTopS").value = $('#span1').offset().top;
                         document.getElementById("cphMain_lblDateTopS").value = $('#span2').offset().top;
                         document.getElementById("cphMain_lblAmntWordTopS").value = $('#span3').offset().top;
                         document.getElementById("cphMain_lblAmntWordTop1S").value = $('#span5').offset().top;
                         document.getElementById("cphMain_lblAmntNumTopS").value = $('#span4').offset().top;
                     }
                     else {
                         alert("Please choose an image file");
                         document.getElementById("<%=Label5.ClientID%>").textContent = "No File selected";
                         document.getElementById("<%=FileUploadRecharge.ClientID%>").value = "";
                     }
                 }                               
             }
             else {
                 document.getElementById("divImgPreviewHead").style.display = "none";
                 document.getElementById("cphMain_divImgPreview").style.display = "none";
                 document.getElementById("divPrint").style.display = "none";
             }
         }
            // GET THE IMAGE WIDTH AND HEIGHT USING fileReader() API.
            function readImageFile(file) {
                var reader = new FileReader(); // CREATE AN NEW INSTANCE.
                reader.onload = function (e) {
                    var img = new Image();      
                    img.src = e.target.result;
                    img.onload = function () {
                        document.getElementById("cphMain_divImgPreview").style.width = this.width + "px";
                        document.getElementById("cphMain_divImgPreview").style.height = this.height + "px";
                        document.getElementById("cphMain_divImgPreview").style.backgroundImage = "url(" + reader.result + ")";
                    }
                };
                reader.readAsDataURL(file);
            }
</script>
    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
       
            if (document.getElementById("<%=Label5.ClientID%>").textContent != "No File selected") {
          
                document.getElementById("divImgPreviewHead").style.display = "block";
                document.getElementById("cphMain_divImgPreview").style.display = "block";

                var d = document.getElementById('span1');
                d.style.left =document.getElementById("cphMain_lblPayeeLeft").value + 'px';
                d.style.top = document.getElementById("cphMain_lblPayeeTop").value + 'px';
               

                var d = document.getElementById('span2');
                d.style.left = document.getElementById("cphMain_lblDateLeft").value + 'px';
                d.style.top = document.getElementById("cphMain_lblDateTop").value + 'px';


                var d = document.getElementById('span3');
                d.style.left =document.getElementById("cphMain_lblAmntWordLeft").value + 'px';
                d.style.top = document.getElementById("cphMain_lblAmntWordTop").value + 'px';

                var d = document.getElementById('span4');
                d.style.left = document.getElementById("cphMain_lblAmntNumLeft").value + 'px';
                d.style.top = document.getElementById("cphMain_lblAmntNumTop").value + 'px';
              

                var d = document.getElementById('span5');
                d.style.left =document.getElementById("cphMain_lblAmntWordLeft1").value + 'px';
                d.style.top =document.getElementById("cphMain_lblAmntWordTop1").value + 'px';   

                document.getElementById("divPrint").style.display = "block";

                var tops = document.getElementById("<%=HiddenFieldRelativeTop.ClientID%>").value.split(',');

                document.getElementById("cphMain_lblPayeeTopS").value = tops[0];
                document.getElementById("cphMain_lblDateTopS").value = tops[1];
                document.getElementById("cphMain_lblAmntWordTopS").value = tops[2];
                document.getElementById("cphMain_lblAmntWordTop1S").value = tops[4];
                document.getElementById("cphMain_lblAmntNumTopS").value = tops[3];
            }
        });            
    </script>
    <script>      
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        function DuplicationCheck() {
            var varGrpName = document.getElementById("cphMain_txtName").value.trim();
            var replaceText1 = varGrpName.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("cphMain_txtName").value = replaceText2;
            if (varGrpName != "") {
                IncrmntConfrmCounter();
                document.getElementById("cphMain_txtName").style.borderColor = "";
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                var orgid = '<%= Session["ORGID"] %>';
                var userid = '<%= Session["USERID"] %>';
                Taxid = document.getElementById("<%=HiddenFieldTaxId.ClientID%>").value;
                $noCon.ajax({
                    type: "POST",
                    url: "fms_Cheque_Template.aspx/DupChkName",
                    data: '{intTaxid:"' + Taxid + '",intGrpname:"' + varGrpName + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d == "false") {
                            document.getElementById("cphMain_txtName").value = "";
                            document.getElementById("cphMain_txtName").style.borderColor = "Red";
                            $noCon(window).scrollTop(0);
                            $noCon("#divWarning").html("Template name cannot be duplicated.");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                document.getElementById("cphMain_txtName").focus();
                            });
                            $noCon("#divWarning").alert();
                        }
                    },
                    failure: function (response) {
                    }
                });
            }
            return false;
        }

        function ConfirmMessage() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Cheque_Template_List.aspx";
                    }
                    else {
                        return false;
                    }
                });
            }
            else {
                window.location.href = "fms_Cheque_Template_List.aspx";
                return true;
            }
            return false;
        }
        function ValidateTaxDeducted(x) {
            var ret = true;
            var prfmncName = document.getElementById("<%=txtName.ClientID%>").value.trim();    
            var ChequeFile = document.getElementById("<%=FileUploadRecharge.ClientID%>").value;
            var DateV = document.getElementById("<%=TextBox2.ClientID%>").value.trim(); 

            if (DateV == "") {
                document.getElementById("<%=TextBox2.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=TextBox2.ClientID%>").focus();
                 $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                 $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                 });
                 $noCon("#divWarning").alert();
                 $noCon(window).scrollTop(0);
                 ret = false;
             }

            if (document.getElementById("<%=Label5.ClientID%>").textContent == "No File selected"){
                document.getElementById("<%=FileUploadRecharge.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=FileUploadRecharge.ClientID%>").focus();
                $noCon("#divWarning").html("Please upload image of cheque.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $noCon("#divWarning").alert();
                $noCon(window).scrollTop(0);
                ret = false;
            }
            if (prfmncName == "") {
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtName.ClientID%>").focus();
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $noCon("#divWarning").alert();
                $noCon(window).scrollTop(0);
                ret = false;
            }
            if (ret == true) {

                if (x == 0) {

                    document.getElementById("cphMain_lblHeight").value = $('#cphMain_divImgPreview').height() + 2;
                    document.getElementById("cphMain_lblWidth").value = $('#cphMain_divImgPreview').width() + 2;

                    document.getElementById("cphMain_PlblPayeeTop").value = $('#cphMain_TextBox1').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_PlblPayeeLeft").value = $('#cphMain_TextBox1').offset().left - $('#cphMain_divImgPreview').offset().left;

                    document.getElementById("cphMain_PlblDateTop").value = $('#cphMain_TextBox2').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_PlblDateLeft").value = $('#cphMain_TextBox2').offset().left - $('#cphMain_divImgPreview').offset().left;

                    document.getElementById("cphMain_PlblAmntWordTop").value = $('#cphMain_TextBox3').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_PlblAmntWordLeft").value = $('#cphMain_TextBox3').offset().left - $('#cphMain_divImgPreview').offset().left;


                    document.getElementById("cphMain_PlblAmntWordTop1").value = $('#cphMain_TextBox5').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_PlblAmntWordLeft1").value = $('#cphMain_TextBox5').offset().left - $('#cphMain_divImgPreview').offset().left;

                    document.getElementById("cphMain_PlblAmntNumTop").value = $('#cphMain_TextBox4').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_PlblAmntNumLeft").value = $('#cphMain_TextBox4').offset().left - $('#cphMain_divImgPreview').offset().left;

                }
                else {

                    document.getElementById("cphMain_lblHeight").value = $('#cphMain_divImgPreview').height() + 2;
                    document.getElementById("cphMain_lblWidth").value = $('#cphMain_divImgPreview').width() + 2;

                    document.getElementById("cphMain_lblPayeeTop").value = $('#cphMain_TextBox1').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_lblPayeeLeft").value = $('#cphMain_TextBox1').offset().left - $('#cphMain_divImgPreview').offset().left;

                    document.getElementById("cphMain_lblDateTop").value = $('#cphMain_TextBox2').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_lblDateLeft").value = $('#cphMain_TextBox2').offset().left - $('#cphMain_divImgPreview').offset().left;

                    document.getElementById("cphMain_lblAmntWordTop").value = $('#cphMain_TextBox3').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_lblAmntWordLeft").value = $('#cphMain_TextBox3').offset().left - $('#cphMain_divImgPreview').offset().left;


                    document.getElementById("cphMain_lblAmntWordTop1").value = $('#cphMain_TextBox5').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_lblAmntWordLeft1").value = $('#cphMain_TextBox5').offset().left - $('#cphMain_divImgPreview').offset().left;

                    document.getElementById("cphMain_lblAmntNumTop").value = $('#cphMain_TextBox4').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_lblAmntNumLeft").value = $('#cphMain_TextBox4').offset().left - $('#cphMain_divImgPreview').offset().left;


                    var relTop1 = document.getElementById("cphMain_lblPayeeTopS").value;
                    var relTop2 = document.getElementById("cphMain_lblDateTopS").value;
                    var relTop3 = document.getElementById("cphMain_lblAmntWordTopS").value;
                    var relTop5 = document.getElementById("cphMain_lblAmntNumTopS").value;
                    var relTop4 = document.getElementById("cphMain_lblAmntWordTop1S").value;


                    var FrelTop1 = $('#span1').offset().top;
                    var FrelTop2 = $('#span2').offset().top;
                    var FrelTop3 = $('#span3').offset().top;
                    var FrelTop5 = $('#span4').offset().top;
                    var FrelTop4 = $('#span5').offset().top;


                    document.getElementById("<%=HiddenFieldRelativeTop.ClientID%>").value = relTop1 + "," + relTop2 + "," + relTop3 + "," + relTop5 + "," + relTop4;
                    document.getElementById("<%=HiddenFieldRelativeTopFinal.ClientID%>").value = FrelTop1 + "," + FrelTop2 + "," + FrelTop3 + "," + FrelTop5 + "," + FrelTop4;
                }
            }
            return ret;
        }
        function SuccessMsg() {
            $noCon("#success-alert").html("Cheque template inserted successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();
            return false;
        }
        function SuccessUpdMsg() {
            $noCon("#success-alert").html("Cheque template updated successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();
            return false;
        }

        function CanclUpdMsg() {
            $noCon("#divWarning").html("Cheque template already cancelled");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#divWarning").alert();
            return false;
        }
        function DisableEnter(evt) {

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

        function validateDateFormate() {
            var isValid = false;
            var regex = /^[DMY0-9-/_ ]*$/;
            var paymentdate = document.getElementById("<%=TextBox2.ClientID%>").value.trim();
            if(paymentdate != "")
            {
                isValid = regex.test(paymentdate);
                if (isValid==false) {
                    document.getElementById("<%=TextBox2.ClientID%>").value = "";
                }
            }
        }

        function isDecimalNumber(evt, textboxid) {
            DisableEnter(evt);
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 38 || keyCodes == 40) {
                return false;

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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

     <asp:HiddenField ID="HiddenFieldRelativeTop" runat="server" />
     <asp:HiddenField ID="HiddenFieldRelativeTopFinal" runat="server" />

     <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
     <asp:HiddenField ID="Hiddentxtefctvedate" runat="server" />
    <asp:HiddenField ID="HiddentxtefctvedateTo" runat="server" />
      <asp:HiddenField ID="HiddenFieldTaxId" runat="server" />
    
      <asp:HiddenField ID="HiddenChkSts" runat="server" />
     <asp:HiddenField ID="HiddenView" runat="server" />
      <asp:HiddenField ID="HiddenCurrentDate" runat="server" />
    


    <div id="divPrint" style="cursor: default; float: right; height: 39px; margin-right: 5%; margin-top: 0%; font-family: Calibri;" class="print">
     <a onclick="return ValidateTaxDeducted(0);"  id="print_cap" target="_blank"  href="/FMS/FMS_Master/fms_Cheque_Template/18_Print.htm" style="color: rgb(83, 101, 51)">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%;margin-bottom:-46%;margin-left:-18%;">
        <span style="margin-top: 2px; margin-left:35%;">Print</span></a>                                  
   </div>



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

  <div class="row" style="margin-top:3%;">
      <div class="form-group col-md-4">
          <label for="example-text-input" class="col-md-2 col-form-label">Name*</label>
          <div class="col-md-10">
              <asp:TextBox ID="txtName" runat="server" MaxLength="100" class="form-control" onblur="return  DuplicationCheck();" onkeypress="return DisableEnter(event)"></asp:TextBox>
          </div>
      </div>

      <div class="form-group col-md-3">
          <label for="example-text-input" class="col-md-4 col-form-label">Position*</label>
          <div class="col-md-8">
              <asp:DropDownList ID="ddlPosition" class="form-control fg2_inp1 inp_mst fg_chs1" runat="server" onkeydown="return DisableEnter(event)" onkeypress="return DisableEnter(event)" Style="">
                  <asp:ListItem Text="Horizontal" Value="0"></asp:ListItem>
                  <asp:ListItem Text="Vertical" Value="1"></asp:ListItem>
              </asp:DropDownList>
          </div>
      </div>


      <div class="form-group col-md-5">
          <label for="example-text-input" class="col-md-4 col-form-label">Image Of Cheque*</label>
          <div id="fileupload" class="col-md-8">
              <label id="lblfileupload" for="cphMain_FileUploadRecharge" class="custom-file-upload" tabindex="0" style="float: left;">
                  <img src="/Images/Icons/cloud_upload.jpg" />Upload</label>
              <asp:FileUpload ID="FileUploadRecharge" class="fileUpload" runat="server" Style="height: 30px; display: none;" accept="image/png, image/gif, image/jpeg" onchange="ClearDivDisplayImage1()" />
              <div id="divImageDisplay1" runat="server" style="float: right; width: 7%; height: 20px; margin-top: 1%; display: none;">
              </div>
              <div>
                  <asp:Label ID="Label5" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
              </div>
              <div id="divImageDisplay12" style="float: left; margin-left: 18%; display: none;" runat="server">
              </div>
          </div>

      </div>
  </div>
      <div class="row" id="divImgPreviewHead" style="display:none;">
       <label  class="col-md-2 col-form-label">Cheque Image preview</label>
      </div>
      <div id="divImgPreview" style="border: 1px solid #8e8f8e;display:none;" class="ui-widget-content" runat="server">

           <span  style="cursor:pointer;" id="span2" class="draggable">*  
              <asp:TextBox ID="TextBox2" onchange="validateDateFormate();"  placeholder="ddmmyyyy" Style="padding: 0px 0px;width: 20%;text-transform:uppercase;height: 20px;" runat="server" MaxLength="50" class="form-control resizable" onkeypress="return DisableEnter(event)" ></asp:TextBox>
          </span>
          <span style="cursor:pointer;"  id="span1" class="draggable">*  
             <asp:TextBox ID="TextBox1" placeholder="Payee Name" Style="padding: 0px 0px;width: 65%;text-transform:uppercase;height: 20px;" runat="server" MaxLength="50" class="form-control resizable" onkeypress="return DisableEnter(event)"></asp:TextBox>
          </span>    
          <span style="cursor:pointer;"  id="span3" class="draggable">* 
             <asp:TextBox ID="TextBox3" placeholder="amount in words1" Style="padding: 0px 0px;width: 59%;text-transform:uppercase;height: 20px;" runat="server" MaxLength="50" class="form-control resizable" onkeypress="return DisableEnter(event)" ></asp:TextBox>
          </span>
           <span style="cursor:pointer;"  id="span4" class="draggable">* 
               <asp:TextBox ID="TextBox4" placeholder="amount in number" Style="padding: 0px 0px;width: 19%;text-transform:uppercase;height: 25px;" runat="server" MaxLength="15" class="form-control resizable" onkeypress="return isDecimalNumber(event,'cphMain_TextBox4')" onkeydown="return isDecimalNumber(event,'cphMain_TextBox4')"></asp:TextBox>
          </span>
           <span style="cursor:pointer;" id="span5" class="draggable">* 
               <asp:TextBox ID="TextBox5" placeholder="amount in words2" Style="padding: 0px 0px;width: 64%;text-transform:uppercase;height: 20px;" runat="server" MaxLength="50" class="form-control resizable" onkeypress="return DisableEnter(event)"></asp:TextBox>
          </span>
         
          
      </div>
        </div>
      
  <div style="clear:both"></div>
 
     <input type="text" id="lblWidth" style="display:none;" runat="server"/>  
     <input type="text" id="lblHeight" style="display:none;" runat="server"/>  
    
     <input type="text" id="PlblPayeeTop" style="display:none;" runat="server"/>   
     <input type="text" id="PlblPayeeLeft" style="display:none;" runat="server"/>   
     <input type="text" id="PlblDateTop" style="display:none;" runat="server"/>   
     <input type="text" id="PlblDateLeft" style="display:none;" runat="server"/>   
     <input type="text" id="PlblAmntWordTop" style="display:none;" runat="server"/>   
     <input type="text" id="PlblAmntWordLeft" style="display:none;" runat="server"/> 
     <input type="text" id="PlblAmntWordTop1" style="display:none;" runat="server"/>   
     <input type="text" id="PlblAmntWordLeft1" style="display:none;" runat="server"/>
     <input type="text" id="PlblAmntNumTop" style="display:none;" runat="server"/>   
     <input type="text" id="PlblAmntNumLeft" style="display:none;" runat="server"/>   

     <input type="text" id="lblPayeeTop" style="display:none;" runat="server"/>   
     <input type="text" id="lblPayeeLeft" style="display:none;" runat="server"/>   
     <input type="text" id="lblDateTop" style="display:none;" runat="server"/>   
     <input type="text" id="lblDateLeft" style="display:none;" runat="server"/>   
     <input type="text" id="lblAmntWordTop" style="display:none;" runat="server"/>   
     <input type="text" id="lblAmntWordLeft" style="display:none;" runat="server"/> 
     <input type="text" id="lblAmntWordTop1" style="display:none;" runat="server"/>   
     <input type="text" id="lblAmntWordLeft1" style="display:none;" runat="server"/>
     <input type="text" id="lblAmntNumTop" style="display:none;" runat="server"/>   
     <input type="text" id="lblAmntNumLeft" style="display:none;" runat="server"/>  
    
     <input type="text" id="lblPayeeTopS" style="display:none;" runat="server"/>   
     <input type="text" id="lblDateTopS" style="display:none;" runat="server"/>   
     <input type="text" id="lblAmntWordTopS" style="display:none;" runat="server"/>   
     <input type="text" id="lblAmntWordTop1S" style="display:none;" runat="server"/>   
     <input type="text" id="lblAmntNumTopS" style="display:none;" runat="server"/>  

<div>
<div class="col-md-12" style="padding:9px;">
<div style="float:right;">
    <asp:Button ID="bttnsave"   runat="server" OnClientclick="return ValidateTaxDeducted(1);"  class="btn btn-primary btn-grey  btn-width" text="Save"   OnClick="bttnsave_Click" />
    <asp:Button ID="btnUpdate"   runat="server" OnClientclick="return ValidateTaxDeducted(1);"  class="btn btn-primary btn-grey  btn-width" text="Update" OnClick="btnUpdate_Click" />
    <input type="button"  id="btnCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn btn-primary btn-grey  btn-width" />
</div>
</div>  
</div>
  </div>  
</div>  
    </div>

  </div>  </article>  </div>  </section>  </div>  </div>    <br />
    <style>
        .padding5 {
    padding: 5px;
    margin: 0 !important;
}
    </style>
      <style type="text/css">
         input[type="file"] {
             position: relative;
             z-index: 1;
             margin-left: -78px;
             display: none;
         }
         .custom-file-upload {
             border: 1px solid #ccc;
             display: inline-block;
             padding: 3px 8px;
             cursor: pointer;
             position: relative;
             z-index: 2;
             background: white;
             font-family: Calibri;
         }       
     </style>
</asp:Content>

