<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Cheque_Template.aspx.cs" Inherits="FMS_FMS_Master_fms_Cheque_Template_fms_Cheque_Template" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/js/New%20js/js/jquery-1.12.4.js"></script>
    <script src="/js/New%20js/js/jquery-ui.js"></script>
    <link href="/css/New%20css/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
    <script>
        var $noCondfs = jQuery.noConflict();
        $noCondfs(function () {
            if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                $noCondfs(".draggable").draggable({ containment: "#cphMain_divImgPreview" });
            }
            else {
                document.getElementById("lblfileupload").style.pointerEvents = "none";
            }
            if (document.getElementById("<%=HiddenView.ClientID%>").value != "1") {
                var wid = document.getElementById("cphMain_divImgPreview").style.width;
                wid = wid.replace(/px/, '') * 1
                if (wid > 500) {

                    $(".in_ch1").css('font-size', 'smaller');
                }
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
                //EVM-0027 Aug 28
                img.onload = function () {
                    document.getElementById("cphMain_divImgPreview").style.width = this.width + "px";
                    if (this.width > 500) {
                        $(".in_ch1").css('font-size', 'smaller');
                    }
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
                d.style.left = document.getElementById("cphMain_lblPayeeLeft").value + 'px';
                d.style.top = document.getElementById("cphMain_lblPayeeTop").value + 'px';


                var d = document.getElementById('span2');
                d.style.left = document.getElementById("cphMain_lblDateLeft").value + 'px';
                d.style.top = document.getElementById("cphMain_lblDateTop").value + 'px';


                var d = document.getElementById('span3');
                d.style.left = document.getElementById("cphMain_lblAmntWordLeft").value + 'px';
                d.style.top = document.getElementById("cphMain_lblAmntWordTop").value + 'px';

                var d = document.getElementById('span4');
                d.style.left = document.getElementById("cphMain_lblAmntNumLeft").value + 'px';
                d.style.top = document.getElementById("cphMain_lblAmntNumTop").value + 'px';


                var d = document.getElementById('span5');
                d.style.left = document.getElementById("cphMain_lblAmntWordLeft1").value + 'px';
                d.style.top = document.getElementById("cphMain_lblAmntWordTop1").value + 'px';

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

                $noCon(window).scrollTop(0);
                ret = false;
            }

            if (document.getElementById("<%=Label5.ClientID%>").textContent == "No File selected") {
                document.getElementById("<%=FileUploadRecharge.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=FileUploadRecharge.ClientID%>").focus();
                $noCon("#divWarning").html("Please upload image of cheque.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                $noCon(window).scrollTop(0);
                ret = false;
            }
            if (prfmncName == "") {
                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtName.ClientID%>").focus();
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                $noCon(window).scrollTop(0);
                ret = false;
            }

            if (ret == true) {

                if (x == 0) {

                    document.getElementById("cphMain_lblHeight").value = $('#cphMain_divImgPreview').height() + 2;
                    document.getElementById("cphMain_lblWidth").value = $('#cphMain_divImgPreview').width() + 2;

                    document.getElementById("cphMain_PlblPayeeTop").value = $('#span1').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_PlblPayeeLeft").value = $('#cphMain_TextBox1').offset().left - $('#cphMain_divImgPreview').offset().left;

                    document.getElementById("cphMain_PlblDateTop").value = $('#span2').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_PlblDateLeft").value = $('#cphMain_TextBox2').offset().left - $('#cphMain_divImgPreview').offset().left;

                    document.getElementById("cphMain_PlblAmntWordTop").value = $('#span3').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_PlblAmntWordLeft").value = $('#cphMain_TextBox3').offset().left - $('#cphMain_divImgPreview').offset().left;


                    document.getElementById("cphMain_PlblAmntWordTop1").value = $('#span5').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_PlblAmntWordLeft1").value = $('#cphMain_TextBox5').offset().left - $('#cphMain_divImgPreview').offset().left;

                    document.getElementById("cphMain_PlblAmntNumTop").value = $('#span4').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_PlblAmntNumLeft").value = $('#cphMain_TextBox4').offset().left - $('#cphMain_divImgPreview').offset().left;


                    //document.getElementById("cphMain_lblPayeeTop").value = $('#span1').offset().top - $('#cphMain_divImgPreview').offset().top;
                    //document.getElementById("cphMain_lblPayeeLeft").value = $('#cphMain_TextBox1').offset().left - $('#cphMain_divImgPreview').offset().left;

                    //document.getElementById("cphMain_lblDateTop").value = $('#span2').offset().top - $('#cphMain_divImgPreview').offset().top;
                    //document.getElementById("cphMain_lblDateLeft").value = $('#cphMain_TextBox2').offset().left - $('#cphMain_divImgPreview').offset().left;

                    //document.getElementById("cphMain_lblAmntWordTop").value = $('#span3').offset().top - $('#cphMain_divImgPreview').offset().top;
                    //document.getElementById("cphMain_lblAmntWordLeft").value = $('#cphMain_TextBox3').offset().left - $('#cphMain_divImgPreview').offset().left;


                    //document.getElementById("cphMain_lblAmntWordTop1").value = $('#span5').offset().top - $('#cphMain_divImgPreview').offset().top;
                    //document.getElementById("cphMain_lblAmntWordLeft1").value = $('#cphMain_TextBox5').offset().left - $('#cphMain_divImgPreview').offset().left;

                    //document.getElementById("cphMain_lblAmntNumTop").value = $('#span4').offset().top - $('#cphMain_divImgPreview').offset().top;
                    //document.getElementById("cphMain_lblAmntNumLeft").value = $('#cphMain_TextBox4').offset().left - $('#cphMain_divImgPreview').offset().left;

                }
                else {


                    //txtWord1Count
                    document.getElementById("cphMain_lblHeight").value = $('#cphMain_divImgPreview').height() + 2;
                    document.getElementById("cphMain_lblWidth").value = $('#cphMain_divImgPreview').width() + 2;
                    //alert($('#span1').offset().top);
                    //alert($('#cphMain_TextBox1').offset().top);
                    //alert($('#cphMain_divImgPreview').offset().top);
                    //alert($('#divImgPreviewHead').offset().top);
                  
                    document.getElementById("cphMain_txtWord1Count").value = document.getElementById("cphMain_TextBox3").value.length;
                    document.getElementById("cphMain_lblPayeeTop").value = $('#span1').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_lblPayeeLeft").value = $('#cphMain_TextBox1').offset().left - $('#cphMain_divImgPreview').offset().left;

                    document.getElementById("cphMain_lblDateTop").value = $('#span2').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_lblDateLeft").value = $('#cphMain_TextBox2').offset().left - $('#cphMain_divImgPreview').offset().left;

                    document.getElementById("cphMain_lblAmntWordTop").value = $('#span3').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_lblAmntWordLeft").value = $('#cphMain_TextBox3').offset().left - $('#cphMain_divImgPreview').offset().left;


                    document.getElementById("cphMain_lblAmntWordTop1").value = $('#span5').offset().top - $('#cphMain_divImgPreview').offset().top;
                    document.getElementById("cphMain_lblAmntWordLeft1").value = $('#cphMain_TextBox5').offset().left - $('#cphMain_divImgPreview').offset().left;

                    document.getElementById("cphMain_lblAmntNumTop").value = $('#span4').offset().top - $('#cphMain_divImgPreview').offset().top;
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

            return false;
        }
        function SuccessUpdMsg() {
            $noCon("#success-alert").html("Cheque template updated successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });

            return false;
        }

        function CanclUpdMsg() {
            $noCon("#divWarning").html("Cheque template already cancelled");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

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
            if (paymentdate != "") {
                isValid = regex.test(paymentdate);
                if (isValid == false) {
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
    <style>
        #draggable {
            width: 150px;
            height: 150px;
            padding: 0.5em;
        }
    </style>
    <script src="../js/jquery-1.12.4.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script>
        $noCon(function () {
            $noCon(".draggable1").draggable();
        });
    </script>
    <script>
        $noCon(function () {
            $noCon(".draggable2").draggable();
        });
    </script>
    <script>
        $noCon(function () {
            $noCon(".draggable3").draggable();
        });
    </script>
    <script>
        $noCon(function () {
            $noCon(".draggable4").draggable();
        });
    </script>
    <script>
        $noCon(function () {
            $noCon(".draggable5").draggable();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
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

    <div id="divLinkSection" runat="server">
        <ol class="breadcrumb sticky1">
            <li><a id="aHome" runat="server" href="">Home</a></li>
            <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
            <li><a href="fms_Cheque_Template_List.aspx">Cheque</a></li>
            <li class="active">Add Cheque</li>
        </ol>
    </div>

    <div class="myAlert-bottom alert alert-danger" id="divWarning" style="display: none">
        <button type="button" class="close" data-dismiss="alert">x</button>
    </div>
    <div class="myAlert-top alert alert-success" id="success-alert" style="display: none">
        <button type="button" class="close" data-dismiss="alert">x</button>
    </div>
    <div id="divList" class="list_b" runat="server" style="cursor: pointer;" onclick="return ConfirmMessage()" title="Back to List">
        <i class="fa fa-arrow-circle-left"></i>
    </div>

    <div id="divPrint">
        <a onclick="return ValidateTaxDeducted(0);" id="A1" class="print_o" target="_blank" href="/FMS/FMS_Master/fms_Cheque_Template/18_Print.htm">
            <i class="fa fa-print"></i>
        </a>
    </div>
    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">
            <div class="content_box1 cont_contr">
                <h2>
                    <asp:Label ID="lblEntry" runat="server"></asp:Label></h2>
                <div class="clm">
                    <div class="form-group fg4 ">
                        <label for="email" class="fg2_la1">Cheque Template Name:<span class="spn1">*</span></label>
                        <asp:TextBox ID="txtName" runat="server" MaxLength="100" class="form-control fg2_inp1 inp_mst" onblur="return  DuplicationCheck();" onkeypress="return DisableEnter(event)"></asp:TextBox>
                    </div>

                    <div class="form-group fg4">
                        <label for="example-text-input" class="col-md-4 col-form-label">Position*</label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddlPosition" class="form-control fg2_inp1 inp_mst fg_chs1" runat="server" onkeydown="return DisableEnter(event)" onkeypress="return DisableEnter(event)" Style="">
                                <asp:ListItem Text="Horizontal" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Vertical" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group fg4 ">
                        <label for="example-text-input" class="fg2_la1 pad_l">Image Of Cheque<span class="spn1">&nbsp;</span></label>
                        <div id="fileupload">
                            <label id="lblfileupload" for="cphMain_FileUploadRecharge" class="la_up" tabindex="0">
                                <i class="fa fa-upload" aria-hidden="true"></i>Upload</label>
                            <asp:FileUpload ID="FileUploadRecharge" class="fileUpload" runat="server" Style="display: none;" accept="image/png, image/gif, image/jpeg" onchange="ClearDivDisplayImage1()" />
                            <div id="divImageDisplay1" class="file_n" runat="server" style="display: none;">
                            </div>
                            <div>
                                <asp:Label ID="Label5" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
                            </div>
                            <div id="divImageDisplay12" style="float: left; margin-left: 18%; display: none;" runat="server">
                            </div>
                        </div>
                    </div>

                    <div class="clearfix"></div>
                    <div class="free_sp"></div>
                    <div class="devider divid"></div>

                    <div class="row" id="divImgPreviewHead" style="display: none;">
                        <label class="col-md-2 col-form-label">Cheque Image preview</label>
                    </div>
                    <div class="cheq_img" id="divImgPreview" style="display: none;" runat="server">
                        <div id="span2" class="ui-widget-content draggable5">
                            <div class="mydrag wod3">
                                <div id="myinprr1" class="arr1_bx">
                                    <i class="fa fa-arrows arr1 ar_w"></i>
                                </div>
                                <asp:TextBox ID="TextBox2" onchange="validateDateFormate();" placeholder="ddmmyyyy" runat="server" MaxLength="75" class="in_ch1" onkeypress="return DisableEnter(event)"></asp:TextBox>
                            </div>
                        </div>

                        <div id="span1" class="ui-widget-content draggable1">
                            <div id="Div7" class="mydrag wod3">
                                <div id="Div8" class="arr1_bx">
                                    <i class="fa fa-arrows arr1 ar_w"></i>
                                </div>
                                <asp:TextBox ID="TextBox1" placeholder="Payee Name" runat="server" MaxLength="50" class="in_ch1" onkeypress="return DisableEnter(event)"></asp:TextBox>
                            </div>
                        </div>

                        <div id="span3" class="ui-widget-content draggable2">
                            <div class="mydrag wod3">
                                <div class="arr1_bx">
                                    <i class="fa fa-arrows arr1 ar_w"></i>
                                </div>
                                <asp:TextBox ID="TextBox3" placeholder="amount in words1" runat="server" MaxLength="150" class="in_ch1" onkeypress="return DisableEnter(event)"></asp:TextBox>
                            </div>
                        </div>

                        <div id="span4" class="ui-widget-content draggable4">
                            <div id="Div5" class="mydrag wod3">
                                <div id="Div6" class="arr1_bx">
                                    <i class="fa fa-arrows arr1 ar_w"></i>
                                </div>
                                <asp:TextBox ID="TextBox4" placeholder="amount in number" runat="server" MaxLength="15" class="in_ch1" onkeypress="return isDecimalNumber(event,'cphMain_TextBox4')" onkeydown="return isDecimalNumber(event,'cphMain_TextBox4')"></asp:TextBox>

                            </div>
                        </div>
                        <div id="span5" class="ui-widget-content draggable3">
                            <div class="mydrag wod3">
                                <div class="arr1_bx">
                                    <i class="fa fa-arrows arr1 ar_w"></i>
                                </div>
                                <asp:TextBox ID="TextBox5" placeholder="amount in words2" runat="server" MaxLength="150" class="in_ch1" onkeypress="return DisableEnter(event)"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <%--  Print Section--%>
                    <div style="clear: both"></div>
                    <input type="text" id="txtWord1Count" style="display: none;" runat="server" />
                    <input type="text" id="lblWidth" style="display: none;" runat="server" />
                    <input type="text" id="lblHeight" style="display: none;" runat="server" />
                    <input type="text" id="PlblPayeeTop" style="display: none;" runat="server" />
                    <input type="text" id="PlblPayeeLeft" style="display: none;" runat="server" />
                    <input type="text" id="PlblDateTop" style="display: none;" runat="server" />
                    <input type="text" id="PlblDateLeft" style="display: none;" runat="server" />
                    <input type="text" id="PlblAmntWordTop" style="display: none;" runat="server" />
                    <input type="text" id="PlblAmntWordLeft" style="display: none;" runat="server" />
                    <input type="text" id="PlblAmntWordTop1" style="display: none;" runat="server" />
                    <input type="text" id="PlblAmntWordLeft1" style="display: none;" runat="server" />
                    <input type="text" id="PlblAmntNumTop" style="display: none;" runat="server" />
                    <input type="text" id="PlblAmntNumLeft" style="display: none;" runat="server" />
                    <input type="text" id="lblPayeeTop" style="display: none;" runat="server" />
                    <input type="text" id="lblPayeeLeft" style="display: none;" runat="server" />
                    <input type="text" id="lblDateTop" style="display: none;" runat="server" />
                    <input type="text" id="lblDateLeft" style="display: none;" runat="server" />
                    <input type="text" id="lblAmntWordTop" style="display: none;" runat="server" />
                    <input type="text" id="lblAmntWordLeft" style="display: none;" runat="server" />
                    <input type="text" id="lblAmntWordTop1" style="display: none;" runat="server" />
                    <input type="text" id="lblAmntWordLeft1" style="display: none;" runat="server" />
                    <input type="text" id="lblAmntNumTop" style="display: none;" runat="server" />
                    <input type="text" id="lblAmntNumLeft" style="display: none;" runat="server" />
                    <input type="text" id="lblPayeeTopS" style="display: none;" runat="server" />
                    <input type="text" id="lblDateTopS" style="display: none;" runat="server" />
                    <input type="text" id="lblAmntWordTopS" style="display: none;" runat="server" />
                    <input type="text" id="lblAmntWordTop1S" style="display: none;" runat="server" />
                    <input type="text" id="lblAmntNumTopS" style="display: none;" runat="server" />

                    <div class="free_sp"></div>
                    <div class="sub_cont pull-right">
                        <div class="save_sec">
                            <asp:Button ID="bttnsave" runat="server" OnClientClick="return ValidateTaxDeducted(1);" class="btn sub1" Text="Save" OnClick="bttnsave_Click" />
                            <asp:Button ID="btnUpdate" runat="server" OnClientClick="return ValidateTaxDeducted(1);" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" />
                            <input type="button" id="btnCancel" runat="server" onclick="return ConfirmMessage()" value="Cancel" class="btn sub4" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

