<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gen_Vehicle_Status_Master.aspx.cs"  MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" Inherits="AWMS_AWMS_Master_gen_Vehicle_Status_Master_gen_Vehicle_Status_Master" %>



            
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

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

           var confirmbox = 0;

           function IncrmntConfrmCounter() {
               confirmbox++;
           }
           function ConfirmMessage() {
               if (confirmbox > 0) {
                   if (confirm("Are You Sure You Want To Leave This Page?")) {
                       window.location.href = "gen_Vehicle_Status_Master_List.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "gen_Vehicle_Status_Master_List.aspx";

               }
           }

           function AlertClearAll() {
               if (confirmbox > 0) {
                   if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                       window.location.href = "gen_Vehicle_Status_Master.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "gen_Vehicle_Status_Master.aspx";

               }
           }


    </script>

     <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            document.getElementById("<%=TypNme.ClientID%>").focus();

            if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {

          

                IncrmntConfrmCounter();
            }
            

        });
    </script>

        <script type="text/javascript">

            function DuplicationName() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=TypNme.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Vehicle Status Name Can’t be Duplicated.";
            }



            function SuccessConfirmation() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Status Details Inserted Successfully.";
            }

            function SuccessUpdation() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Status Details Updated Successfully.";
            }

            function SuccessReOpen() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Status Details ReOpened Successfully.";
            }

            function SuccessConfirm() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Status Details Confirmed Successfully.";
            }

            function VehicleStatusValidate() {

                var $noCon = jQuery.noConflict();
                var ret = true;
                if (CheckIsRepeat() == true) {

                }
                else {
                    ret = false;
                    return ret;
                }
                // replacing < and > tags 
               
                var CrdNumWithoutReplace = document.getElementById("<%=TypNme.ClientID%>").value;
                var replaceText1 = CrdNumWithoutReplace.replace(/</g, "");
                var replaceText2 = replaceText1.replace(/>/g, "");
                document.getElementById("<%=TypNme.ClientID%>").value = replaceText2;
                               
                document.getElementById("<%=TypNme.ClientID%>").style.borderColor = "";
               


                var VehStsNam = document.getElementById("<%=TypNme.ClientID%>").value.trim();
                         var Typddl = document.getElementById("<%=ddlCtgry.ClientID%>");
                var VehStsTyp = Typddl.options[Typddl.selectedIndex].text;

                if (VehStsTyp == "--SELECT STATUS TYPE--") {

                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=ddlCtgry.ClientID%>").style.borderColor = "Red";
                  
                      document.getElementById("<%=ddlCtgry.ClientID%>").focus();
                      ret = false;
                  }
                  else {

                      document.getElementById("<%=ddlCtgry.ClientID%>").style.borderColor = "";
                  }
               
                             

                if (VehStsNam == "") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=TypNme.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=TypNme.ClientID%>").focus();
                    ret = false;
                }
                else {
                    document.getElementById("<%=TypNme.ClientID%>").style.borderColor = "";

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
    
    <script>




        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

             

                $au('form').submit(function () {

                   
                });
            });
        })(jQuery);





                    </script>
   
  

     <style>

         
              .eachform h2 {
                margin: 6px 0 6px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
     <asp:HiddenField ID="hiddenCancelReason" runat="server" />
    <asp:HiddenField ID="hiddenRoleReOpen" runat="server" />
    <asp:HiddenField ID="hiddenRoleConfirm" runat="server" />


    <div class="cont_rght">


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
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
            <br />

              <div class="eachform" style="width:66%">      
             <h2>Vehicle Status Name*</h2>
                <asp:TextBox ID="TypNme" Height="30px" Width="50%" class="form1" runat="server" MaxLength="50"  Style="text-transform: uppercase; margin-right: 4%;" ></asp:TextBox>
              
                   </div>
   
       
                         
              <div class="eachform"  style=" width: 66%;margin-left: 0%;" >
                <h2 style="margin-left: 0%;">Status Type*</h2>
                <asp:DropDownList ID="ddlCtgry"  class="form1" runat="server" Style="height:30px; width:53%;margin-right: 4%;" onkeydown="return DisableEnter(event)" ></asp:DropDownList>

            </div>
           
            <div class="eachform"  style="width:57%;padding-top: 0%;">
                  <h2>Status*</h2>
                <div class="subform" style="margin-right: 7%; margin-top: 1.5%;">


                    <asp:CheckBox ID="cbxStatus" Text="" runat="server" onkeydown="return DisableEnter(event)" Checked="true" class="form2" />
                    <h3 style="padding: 1%;">Active</h3>

                </div>
                

            </div>

           
       
   
          
         
         
            <br />
            <div class="eachform">
                <div class="subform" style="width: 72%; margin-top:5%">

                    
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return VehicleStatusValidate();"/>
                      <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return VehicleStatusValidate();"/>
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return VehicleStatusValidate();"/>
                     <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return VehicleStatusValidate();"/>
                     <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" PostBackUrl="~/AWMS/AWMS_Master/gen_Vehicle_Status_Master/gen_Vehicle_Status_Master_List.aspx"/>
                 <asp:Button ID="btnClear" runat="server" style="margin-left: 13px;" OnClientClick="return AlertClearAll();" OnClick="btnClear_Click" class="cancel" Text="Clear"/>
                </div>
            </div>

        </div>
    </div>

 
</asp:Content>
