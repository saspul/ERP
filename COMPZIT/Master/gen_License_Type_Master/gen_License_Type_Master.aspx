<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit.master" CodeFile="gen_License_Type_Master.aspx.cs" Inherits="AWMS_AWMS_Master_gen_License_Type_Master_gen_License_Type_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
     <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/hcm_ns.css" rel="stylesheet" />
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
         }
         function CheckSubmitZero() {
             submit = 0;
         }
         var $noCon = jQuery.noConflict();
         $noCon(window).load(function () {
             if (document.getElementById("cphMain_lblEntry").innerText == "EDIT LICENSE TYPE") {
                 $(".edit").css("display", "block");
             }
             if (document.getElementById("cphMain_lblEntry").innerText != "ADD LICENSE TYPE") {
                 $(".add").css("display", "none");
             }
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
                            window.location.href = "gen_License_Type_Master_List.aspx";
                            return false;
                        }
                        else {
                            return false;
                        }
                    });
                    return false;
                }
                else {
                    window.location.href = "gen_License_Type_Master_List.aspx";

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
                            window.location.href = "gen_License_Type_Master.aspx";
                            return false;
                        }
                        else {
                            return false;
                        }
                    });
                    return false;
                }
                else {
                    window.location.href = "gen_License_Type_Master.aspx";
                    return false;
                }
                return false;
            }
    </script>
     <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            document.getElementById("<%=txtName.ClientID%>").focus();
            //  if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {

            //      IncrmntConfrmCounter();
            //  }
          //  document.getElementById('cphMain_divImageContainer').style.border = "1px solid";
            document.getElementById('cphMain_divImageContainer').style.borderColor = "rgb(207, 204, 204)";
            //  if (document.getElementById("<%= hiddenSelectedImage.ClientID%>").value != "") {

            //    var ImageId = document.getElementById("<%=hiddenSelectedImage.ClientID%>").value;
            //  document.getElementById("vector-" + ImageId).style.border = ".5px solid";
            // document.getElementById("vector-" + ImageId).style.backgroundColor = "#d7d7d7";


            //  }

        });

        function SelectImage(ImageId) {

            IncrmntConfrmCounter();

            var oldImage = document.getElementById("<%=hiddenSelectedImage.ClientID%>").value;
            if (oldImage != "") {
                document.getElementById("vector-" + oldImage).style.border = ".5px solid";
                document.getElementById("vector-" + oldImage).style.borderColor = "#ceb6b6";
                document.getElementById("vector-" + oldImage).style.backgroundColor = "";
            }
            document.getElementById("vector-" + ImageId).style.border = ".5px solid";
            document.getElementById("vector-" + ImageId).style.backgroundColor = "#d7d7d7";
            document.getElementById("<%=hiddenSelectedImage.ClientID%>").value = ImageId;
            return false;
          }
    </script>

        <script type="text/javascript">

            function FillLicenseTextBox(ImageId) {

                if (ImageId != "") {

                    document.getElementById("vector-" + ImageId).style.border = ".5px solid";
                    document.getElementById("vector-" + ImageId).style.backgroundColor = "#d7d7d7";
                    document.getElementById("<%=hiddenSelectedImage.ClientID%>").value = ImageId;
                }
            }

            function DuplicationName() {


                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
              $("#divWarning").html("Duplication Error!.License Type Can’t be Duplicated.");
              $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });

          }

          function SuccessConfirmation() {
              $("#success-alert").html("License Type details inserted successfully.");
              $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
              });
          }
          function SuccessUpdation() {
              $("#success-alert").html("License Type details updated successfully.");
              $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
              });
          }
          function HideLoading() {
              document.getElementById('divLoading').style.display = "";
          }
          function ErrorMsg() {
              $("#divWarning").html("Some error occured.Please review entered information !");
              $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });
          }

            function SuccessReOpen() {
                $("#divWarning").html("License Type Details ReOpened Successfully.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                
            }

            function SuccessConfirm() {
                $("#divWarning").html("License Type Details Confirmed Successfully.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

            }

            function LicTypeValidate() {

                var $noCon = jQuery.noConflict();
                var ret = true;
                if (CheckIsRepeat() == true) {

                }
                else {
                    ret = false;
                    return ret;
                }
                // replacing < and > tags 
                var CrdNumWithoutReplace = document.getElementById("<%=txtName.ClientID%>").value;
                var replaceText1 = CrdNumWithoutReplace.replace(/</g, "");
                var replaceText2 = replaceText1.replace(/>/g, "");
                document.getElementById("<%=txtName.ClientID%>").value = replaceText2;



                document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";

                //   $noCon("div#divBank input.ui-autocomplete-input").css("borderColor", "");


                var CardNum = document.getElementById("<%=txtName.ClientID%>").value.trim();
                if (document.getElementById("<%=hiddenSelectedImage.ClientID%>").value == "") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted field below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                    document.getElementById('cphMain_divImageContainer').style.border = "1px solid";
                    document.getElementById('cphMain_divImageContainer').style.borderColor = "Red";
                    document.getElementById('divMessageArea').focus();
                    ret = false;
                }
                else {
                    document.getElementById('cphMain_divImageContainer').style.border = "1px solid";
                    document.getElementById('cphMain_divImageContainer').style.borderColor = "rgb(207, 204, 204)";
                }


                if (CardNum == "") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted field below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });

                    document.getElementById("<%=txtName.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtName.ClientID%>").focus();
                    ret = false;
                }
                else {
                    document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";

                }

                if (ret == false) {
                    CheckSubmitZero();

                }
                return ret;
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


            function ConfirmReOpen() {
                if (confirm("Are You Sure You Want To ReOpen This Page?")) {
                    return true;
                }
                else {
                    return false;
                }
            }

    </script>
         <style type="text/css">
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
                        .imgDescription {
            position: absolute;
            /*top: 511px;
            left: 6.5%;*/
            background: rgb(154, 163, 138);
            visibility: hidden;
            opacity: 0;
            padding: 0.1%;
            font-family: Calibri;
            /*remove comment if you want a gradual transition between states
  -webkit-transition: visibility opacity 0.2s;
  */
        }

        .imgWrap:hover .imgDescription {
            visibility: visible;
            opacity: 1;
        }
   
    </style>
    <script src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="../../../css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>




        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

                // $au('#cphMain_ddlHolMode').selectToAutocomplete1Letter();
                // $au('#cphMain_ddlHolType').selectToAutocomplete1Letter();

                $au('form').submit(function () {

                    //   alert($au(this).serialize());


                    //   return false;
                });
            });
        })(jQuery);





                    </script>
   
    <%--FOR DATE TIME PICKER--%>

     <style>

           .textDate:focus {
            border: 1px solid #bbf2cf;
            box-shadow: 0px 0px 4px 2.5px #bbf2cf;
        }
        .textDate {
            border: 1px solid #cfcccc;
        }
            .open > .dropdown-menu {
    display: none;
             }

            .bootstrap-datetimepicker-widget {

    z-index: 100;
}
              .eachform h2 {
                margin: 6px 0 6px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
     <asp:HiddenField ID="hiddenCancelReason" runat="server" />
    <asp:HiddenField ID="hiddenRoleReOpen" runat="server" />
    <asp:HiddenField ID="hiddenRoleConfirm" runat="server" />
     <asp:HiddenField ID="hiddenSelectedImage" runat="server" />




     <!----new--->


      <ol class="breadcrumb">
        <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Hcm.aspx">HCM</a></li>
        <li><a href="gen_License_Type_Master.aspx">License Type</a></li>
         <li class="active" >Add License Type</li>
  </ol>

  <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">Add License Type</h2>

        <div class="form-group fg4 sa_fg1">
          <label for="email" class="fg2_la1">License Type Name:<span class="spn1">*</span></label>
                            <asp:TextBox ID="txtName" class="form-control fg2_inp1 inp_mst" runat="server" onchange="IncrmntConfrmCounter();" placeholder="License Type Name" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onblur="RemoveTag('cphMain_txtName')" autocomplete="off"   MaxLength="100"  TextMode="SingleLine" ></asp:TextBox>

         
        </div>
             
        <div class="form-group fg6 wid_1b4">
        
            <div id="divImageContainer" class="box_veh" runat="server" >

            </div>
          
        </div>
          
           
        <div class="form-group fg7 fg2_mr sa_fg1">
          <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
          <div class="check1">
            <div class="">
              <label class="switch">
                  <asp:CheckBox ID="cbxStatus" Text="" runat="server" Checked="true"/>
                <span class="slider_tog round"></span>
              </label>
            </div>
          </div>
        </div>
        
        
   
        <div class="clearfix"></div>
        <div class="free_sp"></div>
        <div class="devider"></div>

        <div class="sub_cont pull-right">
             <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return LicTypeValidate();"/>
                      <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return LicTypeValidate();"/>
                    <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return LicTypeValidate();"/>
                     <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return LicTypeValidate();"/>
                 <asp:Button ID="btnClear" runat="server"  OnClientClick="return AlertClearAll();"  class="btn sub2" Text="Clear"/>
              
                               <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();"/>

       
        </div>
             </div>
    </div>
    </div>
            <div class="mySave1" id="mySave" runat="server">
                     <asp:Button ID="btnUpdatef" runat="server" class="btn sub1" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnUpdateClosef" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnAddf" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="btnAddClosef" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                     <asp:Button ID="btnClearf" runat="server" class="btn sub2"  OnClientClick="return AlertClearAll();"   Text="Clear"/>
                                   <asp:Button ID="btnCancelf" runat="server"  class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();"  />

</div>
        
   
 <!--content_container_closed------>

<a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
<i class="fa fa-save"></i>
</a>

<a href="gen_License_Type_Master_List.aspx" type="button" class="list_b" title="Back to List">
<i class="fa fa-arrow-circle-left"></i>
</a>
    <script>
        function opensave() {
            document.getElementById("cphMain_mySave").style.width = "120px";
        }

        function closesave() {
            document.getElementById("cphMain_mySave").style.width = "0px";
        }
</script>
    <!----new--->



















    

                   <div id="divMessageArea" style="display: none; margin:0px 0 13px;">
                 <img id="imgMessageArea" src="" >
                <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>

     <br />

          <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:5%; top:42%;height:26.5px;">

            <%-- <a href="gen_ProductBrandList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>

        <div class="fillform" style="width:100%;">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
               
            </div>
            <br />
            <br />

              <div class="eachform" style="width:66%">      
             <h2>License Type Name*</h2>
              
                   </div>
           <%-- <div class="eachform" style="width:66%" >--%>

            
           
           <%--      </div>    --%>     

           
            
    </div>

 
</asp:Content>




