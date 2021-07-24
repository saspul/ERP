<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Corp_Division.aspx.cs" Inherits="MasterPage_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
     <script language="javascript" type="text/javascript">
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
         var $noCon = jQuery.noConflict();
         $noCon(window).load(function () {
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
                            window.location.href = "gen_Corp_DivisionList.aspx";
                            return false;
                        }
                        else {
                            return false;
                        }
                    });
                    return false;
                }
                else {
                    window.location.href = "gen_Corp_DivisionList.aspx";

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
                            window.location.href = "gen_Corp_Division.aspx";
                            return false;
                        }
                        else {
                            return false;
                        }
                    });
                    return false;
                }
                else {
                    window.location.href = "gen_Corp_Division.aspx";
                    return false;
                }
                return false;
            }
    </script>
  <style>
   
         .error {
              
               color: red;
               font-size: small;
                font-family: Calibri;
                width: 95%;
           }       
          /* Styles the thumbnail */
        a.lightbox img {
            height: 150px;
            border: 3px solid white;
            box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
            margin: 94px 20px 20px 20px;
        }

        /* Styles the lightbox, removes it from sight and adds the fade-in transition */
        .lightbox-target {
            position: fixed;
            top: -100%;
            width: 100%;
            background: rgba(0, 0, 0, 0.7);
            width: 60%;
            opacity: 0;
            -webkit-transition: opacity .5s ease-in-out;
            -moz-transition: opacity .5s ease-in-out;
            -o-transition: opacity .5s ease-in-out;
            transition: opacity .5s ease-in-out;
            overflow: hidden;
        }

            /* Styles the lightbox image, centers it vertically and horizontally, adds the zoom-in transition and makes it responsive using a combination of margin and absolute positioning */
            .lightbox-target img {
                margin: auto;
                position: absolute;
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                max-height: 0%;
                max-width: 0%;
                border: 3px solid white;
                box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
                box-sizing: border-box;
                -webkit-transition: .5s ease-in-out;
                -moz-transition: .5s ease-in-out;
                -o-transition: .5s ease-in-out;
                transition: .5s ease-in-out;
            }

        /* Styles the close link, adds the slide down transition */
        a.lightbox-close {
            display: block;
            width: 50px;
            height: 50px;
            box-sizing: border-box;
            background: white;
            color: black;
            text-decoration: none;
            position: absolute;
            top: -80px;
            right: 0;
            -webkit-transition: .5s ease-in-out;
            -moz-transition: .5s ease-in-out;
            -o-transition: .5s ease-in-out;
            transition: .5s ease-in-out;
        }

            /* Provides part of the "X" to eliminate an image from the close link */
            a.lightbox-close:before {
                content: "";
                display: block;
                height: 30px;
                width: 1px;
                background: black;
                position: absolute;
                left: 26px;
                top: 10px;
                -webkit-transform: rotate(45deg);
                -moz-transform: rotate(45deg);
                -o-transform: rotate(45deg);
                transform: rotate(45deg);
            }

            /* Provides part of the "X" to eliminate an image from the close link */
            a.lightbox-close:after {
                content: "";
                display: block;
                height: 30px;
                width: 1px;
                background: black;
                position: absolute;
                left: 26px;
                top: 10px;
                -webkit-transform: rotate(-45deg);
                -moz-transform: rotate(-45deg);
                -o-transform: rotate(-45deg);
                transform: rotate(-45deg);
            }

        /* Uses the :target pseudo-class to perform the animations upon clicking the .lightbox-target anchor */
        .lightbox-target:target {
            opacity: 1;
            top: 0;
            bottom: 0;
            z-index: 3;
            right: 18%;
            z-index: 2000;
        }

            .lightbox-target:target img {
                max-height: 100%;
                max-width: 80%;
            }

            .lightbox-target:target a.lightbox-close {
                top: 0px;
            }
    </style>
    <script type="text/javascript">

        function DuplicationName() {
            $("#divWarning").html("Duplication error!. Division name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%= txtDivisionName.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%= txtDivisionName.ClientID%>").focus();
        }
        function DuplicationEmail() {
            $("#divWarning").html("Duplication error!. Email id can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%= txtEmail.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%= txtEmail.ClientID%>").focus();
        }
        function DuplicationCode() {
            $("#divWarning").html("Duplication error!. Division code can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%= txtDivCode.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%= txtDivCode.ClientID%>").focus();
        }


        function SuccessConfirmation() {
            $("#success-alert").html("Corporate division details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("Corporate division details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }

       

        function ValidateFileUpload() {
            var fuData = document.getElementById("<%=FileUpload1.ClientID%>");
            var FileUploadPath = fuData.value;
            var hiddnImage = document.getElementById("<%=HiddenDivImage.ClientID%>").value;//it has value when editing if previously stored image
            var hidnImageSize = document.getElementById("<%=hiddenImageSize.ClientID%>").value;

            if (FileUploadPath == '' && hiddnImage == "") {
                //if (confirm("Are you sure you  want to Save without uploading  Image of Employee?")) {

                //    return true;
                //}
                //else {
                //    return false;
                //}
                return true;

            } else {
                if (FileUploadPath == '') {
                    return true;
                }
                else {
                    var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();



                    if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                                || Extension == "jpeg" || Extension == "jpg") {


                        if (fuData.files && fuData.files[0]) {

                            var size = fuData.files[0].size;
                            var convertToKb = hidnImageSize / 1000;
                            if (size > hidnImageSize) {
                                $("#divWarning").html("Sorry maximum file size exceeds. Please upload image of size less than " + convertToKb + "KB !.");
                                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                });
                                document.getElementById("<%=FileUpload1.ClientID%>").focus();
                                return false;
                            } else { return true; }
                            //else {
                            //var reader = new FileReader();

                            //reader.onload = function (e) {
                            //    $('#blah').attr('src', e.target.result);
                            //}

                            //reader.readAsDataURL(fuData.files[0]);
                            //}
                        }

                    }



                    else {
                        $("#divWarning").html("The specified file could not be uploaded. Image type not supported. Allowed types are png, jpeg, gif");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        return false;
                    }
                }
            }
        }


        function ClearImage() {

            if (document.getElementById("<%=HiddenDivImage.ClientID%>").value != "" || document.getElementById("<%=FileUpload1.ClientID%>").value != "") {

                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to remove selected icon ?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        document.getElementById("<%=divImageDisplay.ClientID%>").innerHTML = "";
                        document.getElementById("<%=HiddenDivImage.ClientID%>").value = "";
                        document.getElementById("<%=FileUpload1.ClientID%>").value = "";
                        document.getElementById("<%=Label1.ClientID%>").textContent = "No File Selected";
                        IncrmntConfrmCounter();
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            return false;
        }

        function ClearDivDisplayImage() {
           

          

            var hidnImageSize = document.getElementById("<%=hiddenImageSize.ClientID%>").value;

            var fuData = document.getElementById("<%=FileUpload1.ClientID%>");
            var size = fuData.files[0].size;
            var convertToKb = hidnImageSize / 1000;
            if (size > hidnImageSize) {
                document.getElementById("<%=FileUpload1.ClientID%>").value = "";
                document.getElementById("<%=Label1.ClientID%>").textContent = "No File Selected";
                $("#divWarning").html("Sorry maximum file size exceeds. Please upload image of size less than " + convertToKb + "KB  !.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
               // return false;
                }
                else {
                    if (document.getElementById("<%=FileUpload1.ClientID%>").value != "") {
                        document.getElementById("<%=Label1.ClientID%>").textContent = document.getElementById("<%=FileUpload1.ClientID%>").value;
                        document.getElementById("<%=divImageDisplay.ClientID%>").innerHTML = "";
                        document.getElementById("<%=HiddenDivImage.ClientID%>").value = "";
                    }

                 //   return true;
                }
            IncrmntConfrmCounter();
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

            var NameWithoutReplace = document.getElementById("<%=txtDivisionName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtDivisionName.ClientID%>").value = replaceText2;

            var EmailWithoutReplace = document.getElementById("<%=txtEmail.ClientID%>").value;
            var EmailreplaceText1 = EmailWithoutReplace.replace(/</g, "");
            var EmailreplaceText2 = EmailreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEmail.ClientID%>").value = EmailreplaceText2;

            var CodeWithoutReplace = document.getElementById("<%=txtDivCode.ClientID%>").value;
            var CodereplaceText1 = CodeWithoutReplace.replace(/</g, "");
            var CodereplaceText2 = CodereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtDivCode.ClientID%>").value = CodereplaceText2.trim();

            var DivName = document.getElementById("<%=txtDivisionName.ClientID%>").value.trim();
            document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtDivCode.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtDivisionName.ClientID%>").style.borderColor = "";

            var StoreEmailWithoutReplace = document.getElementById("<%=txtMailStoreEmail.ClientID%>").value;
            var StoreEmailreplaceText1 = StoreEmailWithoutReplace.replace(/</g, "");
            var StoreEmailreplaceText2 = StoreEmailreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtMailStoreEmail.ClientID%>").value = StoreEmailreplaceText2;

            //  alert(activeViewIndex);

            
            var Email = document.getElementById("<%=txtEmail.ClientID%>");
            var StoreEmail = document.getElementById("<%=txtMailStoreEmail.ClientID%>");
            document.getElementById('ErrorMsgUsrEmail').style.display = "none";
            document.getElementById('ErrorDivCode').style.display = "none";
            document.getElementById('ErrorMsgMailStoreEmail').style.display = "none";


            var DivCode = document.getElementById("<%=txtDivCode.ClientID%>").value;

            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

          
            StorageEmail = document.getElementById("<%=txtMailStoreEmail.ClientID%>").value;
            if (StorageEmail != null && StorageEmail != "") {
                var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                if (!filter.test(StoreEmail.value)) {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById('ErrorMsgMailStoreEmail').style.display = "";
                    document.getElementById("<%=txtMailStoreEmail.ClientID%>").focus();
                    document.getElementById("<%=txtMailStoreEmail.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
            }

            if (DivName == "" || Email == "" || DivCode == "" || !filter.test(Email.value) || DivCode.length != 3) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                ret = false;

                if (DivCode == "" || DivCode.length!=3) {

                    document.getElementById("<%=txtDivCode.ClientID%>").focus();
                    document.getElementById("<%=txtDivCode.ClientID%>").style.borderColor = "Red";
                    document.getElementById('ErrorDivCode').style.display = "";
                   
                    

                }
                if (!filter.test(Email.value)) {
                    var ErrorMsg = document.getElementById('ErrorMsgUsrEmail').style.display = "";
                    EmailAdd = "";
                    document.getElementById("<%=txtEmail.ClientID%>").focus();
                    document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "Red";
                 
                }
                if (DivName == "") {
                    document.getElementById("<%=txtDivisionName.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtDivisionName.ClientID%>").focus();
                   
                }
                if (ret == false) {
                    CheckSubmitZero();

                }

                return ret;
            }
            //this for mail storage email id
           

            if (ValidateFileUpload() == true) {
               
            }
            else {

                ret=false;
            }
           
            
            if (ret == false) {
                CheckSubmitZero();

            }
            return ret;

        }

        function ViewMailSettings() {
            document.getElementById('ContactHeadOne').style.display = "";            
        }
        function OpenMail() {
            var DesgValue = document.getElementById("<%=hiddenDivId.ClientID%>").value;
            var WinMail = window.open('../gen_Corp_Division/gen_Corp_Div_MailSettings.aspx?Id=' + DesgValue);
            WinMail.focus();
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


    </script>
    <%-- <script>
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=ImgPrw.ClientID%>').prop('src', e.target.result)
                        .width(50)
                        .height(50);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }


    </script>--%>

    <%--   <script type="text/javascript" language="javascript">
       var ifIgnoreError = false;
       function UpLoadStarted(sender, e) {
           var fileName = e.get_fileName();
           var fileExtension = fileName.substring(fileName.lastIndexOf('.') + 1);
           if (fileExtension == 'jpg' || fileExtension == 'jpeg') {
               //file is good -- go ahead
           }
           else {
               //stop upload
               ifIgnoreError = true;
               sender._stopLoad();
           }
       }
       function UploadError(sender, e) {
           if (ifIgnoreError) {
               alert("Wrong file type");
           }
           else {
               alert(e.get_message());
           }
       }


    </script>--%>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenImageSize" runat="server" />
    <asp:HiddenField ID="hiddenImagePath" runat="server" />
    <asp:HiddenField ID="HiddenDivImage" runat="server" />
    <asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDivId" runat="server" />

     <ol class="breadcrumb">
       <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
      <li><a href="gen_Corp_DivisionList.aspx">Corporate Division</a></li>
        <li id="lblEntryB" runat="server" class="active">Add Corporate Division</li>
      </ol>
   <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
    
    <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">Add Corporate Division</h2>

        <div class="form-group fg4 sa_o_fg6 sa_480">
          <label for="email" class="fg2_la1">Division Name:<span class="spn1">*</span></label>
          <input id="txtDivisionName"  runat="server" maxlength="150" style="text-transform: uppercase;" type="text" class="form-control fg2_inp1 inp_mst"  placeholder="Division Name" name="">
        </div>
        <div class="form-group fg4 sa_o_fg6 sa_480">
          <label for="email" class="fg2_la1">Division Code:<span class="spn1">*</span></label>
          <input id="txtDivCode" runat="server" maxlength="3" style="text-transform: uppercase;" type="text" class="form-control fg2_inp1 inp_mst"  placeholder="Division Code" name="">
        <p class="error" id="ErrorDivCode" style="display:none; font-family:Calibri;">Division code must have 3 letters</p>
             </div>

        <div class="form-group fg2 sa_o_fg6 sa_480">
          <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
          <div class="check1">
            <div class=" tr_l">
              <label class="switch">
                <input type="checkbox" id="cbxStatus" runat="server" checked="checked">
                <span class="slider_tog round"></span>
              </label>
            </div>
          </div>
        </div>
        <div class="clearfix"></div>

        <div class="form-group fg4 sa_o_fg6 sa_480">
          <label for="email" class="fg2_la1">Enquiry Email ID:<span class="spn1">*</span></label>
          <input type="text" id="txtEmail"  runat="server" maxlength="100" class="form-control fg2_inp1 inp_mst" placeholder="Enquiry Email ID" name="">
             <p class="error" id="ErrorMsgUsrEmail" style="display:none; font-family:Calibri;">Please enter valid email address</p>
        </div>

          <div class="form-group fg4 sa_o_fg6 sa_480">
            <label for="email" class="fg2_la1">Common Mail Storage Email ID:<span class="spn1"></span></label>
            <input type="text" class="form-control fg2_inp1" id="txtMailStoreEmail"  runat="server" maxlength="100" placeholder="Common Mail Storage Email ID">
              <p class="error" id="ErrorMsgMailStoreEmail" style="display:none; font-family:Calibri;">Please enter valid email address</p>
          </div>
          <div class="form-group fg2 sa_480">
            <label for="email" class="fg2_la1 pad_l">Remove Mails From Common Mail Storage:<span class="spn1"></span></label>
            <div class="check1">
              <div class=" tr_l">
                <label class="switch">
                  <input type="checkbox" id="cbxRemoveMails" Checked="false" runat="server">
                  <span class="slider_tog round"></span>
                </label>
              </div>
            </div>
          </div>

           <div class="clearfix"></div>
          <div class="free_sp" style="width:100%;height:0px;margin-top:5px;"></div>



        <div class="form-group fg4 sa_o_fg6 sa_480">
          <label for="email" class="fg2_la1 pad_l">Division Logo: <span class="spn1">&nbsp;</span></label>
          <asp:FileUpload ID="FileUpload1" runat="server" Style="display:none;" onchange="ClearDivDisplayImage()" Accept="image/png, image/gif, image/jpeg"  />
         <label for="cphMain_FileUpload1" class="la_up" tabindex="0"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>
          <div class="file_n" id="Label1" runat="server">No File selected</div>
            <div id="divImageEdit" runat="server" style=" width: 100%;">
               
                 <button class="btn act_btn bn3 bdr_rd2" title="Remove Selected Logo" style="margin-left: 10px;" id="imgClear" runat="server" onclick="return ClearImage();">
            <i class="fa fa-times"></i>
          </button> 
                     <div id="divImageDisplay" runat="server" style="float:left;width:100%;">
                        </div>    
                    </div>
          
        </div>

          <div class="clearfix"></div>
          <div class="free_sp"></div>
          <div class="devider"></div>

              <div class="sub_cont pull-right">
                <div class="save_sec">
                     <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save"  OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                     <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                      <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return Validate();" />
                     <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return Validate();" />
                      <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2" Text="Clear"/>
                     <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();"  />
                
                </div>
              </div>
           
             </div>
            </div>
           </div>
    <div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">

      <asp:Button ID="btnAddF" runat="server" class="btn sub1 bt_b" Text="Save"  OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                     <asp:Button ID="btnAddCloseF" runat="server" class="btn sub3 bt_b" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                      <asp:Button ID="btnUpdateF" runat="server" class="btn sub1 bt_b" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return Validate();" />
                     <asp:Button ID="btnUpdateCloseF" runat="server" class="btn sub3 bt_b" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return Validate();" />
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
</asp:Content>

