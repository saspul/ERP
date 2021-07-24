<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Immigration_Rounds_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_Immigration_hcm_Immigration_Rounds_hcm_Immigration_Rounds_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

<style>
         #divMessageArea {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: 0%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }

        #imgMessageArea {
            float: left;
            margin-left: 1%;
            margin-top: -0.2%;
        }
               /*--------------------------------------------------for modal Cancel Reason------------------------------------------------------*/
         .modalCancelView {
             display: none; /* Hidden by default */
             position: fixed; /* Stay in place */
             z-index: 30; /* Sit on top */
             padding-top: 0%; /* Location of the box */
             left: 23%;
             top: 30%;
             width: 50%; /* Full width */
             /*height: 58%;*/ /* Full height */
             overflow: auto; /* Enable scroll if needed */
             background-color: transparent;
         }


         /* Modal Content */
         .modal-CancelView {
             /*position: relative;*/
             background-color: #fefefe;
             margin: auto;
             padding: 0;
             /*border: 1px solid #888;*/
             width: 95.6%;
             box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
         }


         /* The Close Button */
         .closeCancelView {
             color: white;
             float: right;
             font-size: 28px;
             font-weight: bold;
         }

             .closeCancelView:hover,
             .closeCancelView:focus {
                 color: #000;
                 text-decoration: none;
                 cursor: pointer;
             }

         .modal-headerCancelView {
             /*padding: 1% 1%;*/
            background-color: #91a172;
             color: white;
         }

         .modal-bodyCancelView {
             padding: 4% 4% 7% 4%;
         }

         .modal-footerCancelView {
             padding: 2% 1%;
           background-color: #91a172;
             color: white;
         }
         #divErrorRsnAWMS {
    border-radius: 4px;
    background: #fff;
    color: #53844E;
    font-size: 12.5px;
    font-family: Calibri;
    font-weight: bold;
    border: 2px solid #53844E;
    margin-top: -3.5%;
    margin-bottom: 2%;
}
</style>

<style>
        #cphMain_divReport {
            float: left;
            width: 93.5%;
        }

        #TableRprtRow .tdT {
            line-height: 100%;
        }

        .cont_rght {
            width: 98%;
        }
    </style>


    <script src="/JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {

              document.getElementById("freezelayer").style.display = "none";
              document.getElementById('MymodalCancelView').style.display = "none";
              var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
              document.getElementById("<%=ddlStatus.ClientID%>").focus();

              if (CancelPrimaryId != "") {
                  OpenCancelView();
              }
          });


          </script>
      <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
            });
        });
    </script>

    <script>
        function CancelAlert(href) {

            if (confirm("Do you want to cancel this entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }
        function CancelNotPossible() {
            alert("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
            return false;
        }

        function StatusChngNotPossible() {
            alert("Sorry, status change is not allowed. This entry is already selected somewhere or it is a confirmed entry!");
            return false;
        }
        function getdetails(href) {
            window.location = href;
            return false;
        }
        function OpenCancelView() {
            document.getElementById("MymodalCancelView").style.display = "block";
            document.getElementById("freezelayer").style.display = "";
            document.getElementById("<%=txtCnclReason.ClientID%>").focus();
            return false;
        }
        function CloseCancelView() {
            if (confirm("Do you want to close  without completing cancellation process?")) {
                document.getElementById('divMessageArea').style.display = "none";
                document.getElementById('imgMessageArea').src = "";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                document.getElementById("MymodalCancelView").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
                document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
              }
          }
    </script>

<script>
    //validation when cancel process
    function ValidateCancelReason() {
        // replacing < and > tags
        var NameWithoutReplace = document.getElementById("<%=txtCnclReason.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCnclReason.ClientID%>").value = replaceText2;

             var divErrorMsg = document.getElementById('divErrorRsnAWMS').style.visibility = "hidden";
             var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "";
            var Reason = document.getElementById("<%=txtCnclReason.ClientID%>").value.trim();
            if (Reason == "") {
                document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Please fill this out";
                 document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                 return false;
             }
             else {
                 Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                 Reason = Reason.replace(/[ ]{2,}/gi, " ");
                 Reason = Reason.replace(/\n /, "\n");
                 if (Reason.length < "10") {
                     document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                     document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Cancel reason should be minimum 10 characters";
                    var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                    return false;
                }
            }
    }


    // for not allowing <> tags
    function isTag(evt) {
        IncrmntConfrmCounter();
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
    function isTagWithEnter(evt) {
        IncrmntConfrmCounter();
        evt = (evt) ? evt : window.event;
        var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
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
        else {
            return true;
        }
    }

    function textCounter(field, maxlimit) {
        if (field.value.length > maxlimit) {
            field.value = field.value.substring(0, maxlimit);
        } else {
        }
    }


    function ChangeStatus(catId) {
        if (confirm("Do you want to change the status of this entry?")) {
            return true;
        }
        else {
            return false;
        }
    }

</script>
 <script>
     function SuccessIns() {
         document.getElementById('divMessageArea').style.display = "";
         document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
         document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Immigration Round status inserted successfully.";
         $(window).scrollTop(0);
        }
   
     function SuccessUpdation() {
         document.getElementById('divMessageArea').style.display = "";
         document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
         document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Immigration Round status updated successfully.";
        }
     function SuccessCancelation() {
         document.getElementById('divMessageArea').style.display = "";
         document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
         document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Immigration Round cancelled successfully.";
     }
     function SuccessStatusChange() {
         document.getElementById('divMessageArea').style.display = "";
         document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
         document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Immigration Round status changed successfully.";
     }

 </script>






</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">


    <asp:HiddenField ID="hiddenEnableModify" runat="server" />
    <asp:HiddenField ID="hiddenEnableCancl" runat="server" />
    <asp:HiddenField ID="hiddenRsnid" runat="server" />


        <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">

    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="" style="vertical-align: middle;" />
           Immigration Rounds </div >

    <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;width: 93.5%;margin-top:1%; height: 90px;">

        <div id="DivStatus" class="eachform" style="width: 40%;margin-top:2.5%;">
                <h2 style="margin-top:1%;width: 16%;margin-left: 8%;">Status </h2>
            <asp:DropDownList ID="ddlStatus" Height="30px" Width="160px" class="form1" runat="server" Style="height:30px;width:160px;height:30px;width:55.2%;float:left; margin-left: 7%;">
                <asp:ListItem Text="Active" Value="1" />
                <asp:ListItem Text="Inactive" Value="0" />
                <asp:ListItem Text="All" Value="2" />
            </asp:DropDownList></div>

        <div id="DivCheck" class="eachform" style="width: 25%;margin-top:2.5%;margin-left: 6%;">
            <div class="subform" style="width:215px;float: left;margin-left: 0%;">
                    <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" onkeypress="return DisableEnter(event);" Checked="false" class="form2" />
                    <h3 style="margin-top:1%;">Show Deleted Entries</h3>
                </div>
                  </div>

        <div class="eachform" style="width:15%;float: right;margin-right: 2%;margin-top: 2%;">
           <asp:Button ID="btnSearch" style="cursor:pointer;float:left;margin-top:2.5%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClick="btnSearch_Click" />
        </div>

        
    </div>

    <div onclick="location.href='hcm_Immigration_Round.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;"></div>
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


                        <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Immigration Round</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" OnClick="btnRsnSave_Click" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   

         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>


        </div>

</asp:Content>

