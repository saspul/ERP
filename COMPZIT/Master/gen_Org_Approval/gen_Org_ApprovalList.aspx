<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_App.master" AutoEventWireup="true" CodeFile="gen_Org_ApprovalList.aspx.cs" Inherits="Master_gen_Org_Approval_Pending_gen_ApprovalList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
      <style>
    
       .modalBackground {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.7;
        }

        .modalPopup {
            background-color: #FFFFFF;
            width: 700px;
            border: 3px solid #7d8966;
            padding: 0;
            height: 528px;
        }

            .modalPopup .header {
                background-color: #91a172;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

    </style>
    
    <script type="text/javascript">



        function SuccessRejection() {
            document.getElementById('divSuccessUpd').style.visibility = "visible";
            document.getElementById("<%=lblSuccessUpd.ClientID%>").innerHTML = "Organization Rejected Successfully.";
        }
        function SuccessApproval() {
            document.getElementById('divSuccessUpd').style.visibility = "visible";
            document.getElementById("<%=lblSuccessUpd.ClientID%>").innerHTML = "Organization Approved Successfully.";
        }

        function getdetails(href) {
            window.location = href;
            return false;
        }

        function ApproveAlert(href) {

            if (confirm("Do you want to Approve this Organisation Registration?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }
        function RejectAlert(href) {

            if (confirm("Do you want to Reject this Organisation Registration?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }
        // for not allowing <> tags
        function isTag(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
          
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }

        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }
    </script>
    <%--  for giving pagination to the html table--%>
    <script src="../../JavaScript/JavaScriptPagination1.js"></script>
    <script src="../../JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="../../css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": false

            });
        });


    </script>



    <style>
       #cphMain_divReport {
            float: left;
            width: 93.5%;
        }

        #cphMain_divAdd {
            position: fixed;
            /*right: 4%;*/
              right:1%;
        }

        #TableRprtRow .tdT {
            line-height: 100%;
        }


        .cont_rght {
            width: 98%;
        }
    </style>

    <script>

        function HideModalPopupCnclRsn() {

            if (confirm("Do you want to close  without completing Rejection Process?")) {
                document.getElementById('divSuccessUpd').style.visibility = "hidden";
                document.getElementById("<%=lblSuccessUpd.ClientID%>").innerHTML = "";
                document.getElementById('divErrorRsn').style.visibility = "hidden";
                $find("mpeC").hide();


                window.location.href = "gen_Org_ApprovalList.aspx";


            }

        }

        //validation when cancel process
        function ValidateCancelReason() {
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtCnclReason.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCnclReason.ClientID%>").value = replaceText2;

            var divErrorMsg = document.getElementById('divErrorRsn').style.visibility = "hidden";
            var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "";
            var Reason = document.getElementById("<%=txtCnclReason.ClientID%>").value;
            if (Reason == "") {
                document.getElementById('divErrorRsn').style.visibility = "visible";
                document.getElementById("<%=lblErrorRsn.ClientID%>").innerHTML = "Please fill this out";
                document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                return false;
            }
            else {
                Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                Reason = Reason.replace(/[ ]{2,}/gi, " ");
                Reason = Reason.replace(/\n /, "\n");
                if (Reason.length < "10") {
                    document.getElementById('divErrorRsn').style.visibility = "visible";
                    document.getElementById("<%=lblErrorRsn.ClientID%>").innerHTML = "Rejection reason should be minimum 10 characters";
                    var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                    return false;
                }
            }
        }

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />

    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
    <cc1:modalpopupextender id="ModalPopupExtenderCncl" behaviorid="mpeC" runat="server"
        popupcontrolid="PanelCncl" targetcontrolid="lnkCancel" backgroundcssclass="modalBackground">
    </cc1:modalpopupextender>

    <asp:Panel ID="PanelCncl" runat="server" CssClass="modalPopup" Style="display: none; max-height: 275px; max-width: 610px">

        <div class="header">
            <span style="font-size: 17px; font-weight: bold;font-family:Calibri;">Organization Approval</span>
            <div onclick="HideModalPopupCnclRsn() " style="float: right; width: 20px; cursor: pointer; ">
                <img src="../../Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px">
            </div>
        </div>
        <div class="body">
            <div id="divErrorRsn" style="visibility: hidden">
                <asp:Label ID="lblErrorRsn" runat="server"></asp:Label>
            </div>
            <br />
            <div >
                

                    <table  class="eachform" style="width: 100%">
                        <tr>
                            <td style="padding-left: 50px; text-align: left;">
                             
                                     <h2>Organization Rejection Reason*</h2>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtCnclReason" class="form1" runat="server" MaxLength="150" Width="250px" Height="115px" TextMode="MultiLine" Style="resize: none;" onkeydown="textCounter(cphMain_txtCnclReason,140)" onkeyup="textCounter(cphMain_txtCnclReason,140)"></asp:TextBox>
                            </td>
                            <td>

                                <asp:HiddenField ID="hiddenRsnid" runat="server" />
                            </td>
                        </tr>

                    </table>
             

             


                <div style="text-align: center;" class="subform">

                    <asp:Button ID="btnRsnSave" runat="server" class="save" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" />
                    <input id="btnRsnCncl" type="button" class="cancel" value="Close"
                        onclick=" HideModalPopupCnclRsn();" />

                </div>
            </div>
        </div>
    </asp:Panel>

    <div id="divSuccessUpd" style="visibility: hidden">
                        <asp:Label ID="lblSuccessUpd" runat="server"></asp:Label>
                    </div>

    <div class="cont_rght">

     
                    


                         <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                       <img src="../../Images/BigIcons/08.png" style="vertical-align: middle;" />  Organizaion Approval List
                    </div>
                    <br />

                
                    <div id="divReport" class="table-responsive" runat="server">
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </div>

                
    </div>
</asp:Content>
