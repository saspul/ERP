<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Vehicle_Master_List.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Vehicle_Master_gen_Vehicle_Master_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
             <style>
input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
            cursor:default;
        }
    .searchlist_btn_rght {
        padding: 3px 38px 3px 38px;
         cursor:pointer;
         font-size: 13px; 
         float:left;
        }
            .searchlist_btn_rght:hover {
                background: #7B866A;
            }
             .searchlist_btn_rght:focus {
                background: #7B866A;
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
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {

              document.getElementById("freezelayer").style.display = "none";
              document.getElementById('MymodalCancelView').style.display = "none";
              var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
              if (CancelPrimaryId != "") {
                  OpenCancelView();
              }
          });


          </script>
     <script type="text/javascript">
         var $Mo = jQuery.noConflict();

         function OpenCancelView() {



             document.getElementById("MymodalCancelView").style.display = "block";
             document.getElementById("freezelayer").style.display = "";
             document.getElementById("<%=txtCnclReason.ClientID%>").focus();

            return false;

        }
        function CloseCancelView() {
            if (confirm("Do you want to close  without completing Cancellation Process?")) {
                document.getElementById('divMessageArea').style.display = "none";
                document.getElementById('imgMessageArea').src = "";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                document.getElementById("MymodalCancelView").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
                document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
            }
        }



    </script>
      <style>

        #cphMain_btnNext.aspNetDisabled {
            width: 202px;
            height: 33px;
            margin-top: -5px;
            font-size: 13px;
            cursor: default;
        }
        #cphMain_btnPrevious.aspNetDisabled {
            width: 202px;
            height: 33px;
            margin-top: -5px;
            font-size: 13px;
            cursor: default;
        }
        .searchlist_btn_rght {
            cursor: pointer;
        }
           input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
        }
        #a_Caption:hover {
        color: rgb(83, 101, 51);
        
        }
        #a_Caption {
        color: rgb(88, 134, 7);
        
        }
        #a_Caption:focus {
        color: rgb(83, 101, 51);
        
        }
         .searchlist_btn_lft:hover {
        background:url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        
        }
        .searchlist_btn_lft:focus {
        background:url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        
        }
        input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
            cursor:default;
        }
         .searchlist_btn_rght:hover {
                background: #7B866A;
            }
             .searchlist_btn_rght:focus {
                background: #7B866A;
            }
    </style>


    <script type="text/javascript">


        function DuplicationTrailerReg() {
           
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.Trailer Registration Number Can’t be Duplicated.";
        }

        function DuplicationTrailerIns() {
           
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.Trailer Insurance Number Can’t be Duplicated.";

        }
         function DuplicationName() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Recalling Denied!. Vehicle Number Can’t be Duplicated.";
        }
        function DuplicationPermit() {

            var permitname = "";
            if (document.getElementById("<%=hiddenPermitLabelName.ClientID%>").value != "") {
                permitname = document.getElementById("<%=hiddenPermitLabelName.ClientID%>").value;
            }
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Recalling Denied!." + permitname + " Number Can’t be Duplicated.";
        }
        function DuplicationInsurance() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Recalling Denied!. Insurance Number Can’t be Duplicated.";
        }
        function DuplicationChasis() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Recalling Denied!. Chassis Number Can’t be Duplicated.";
        }

        function DuplicationRFid() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Recalling Denied!. RF ID Tag Number Can’t be Duplicated.";
        }
        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Details Inserted Successfully.";
        }

        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Details Updated Successfully.";
        }

        function SuccessCancelation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Cancelled Successfully.";
        }
      function RecallCancelation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Recalled Successfully.";
        }
        function getdetails(href) {
            window.location = href;
            return false;
        }

        function CancelAlert(href) {

            if (confirm("Do you want to cancel this Entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }
        function RecallAlert(href) {

            if (confirm("Do you want to Recall this Entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }
      

        function CancelNotPossible() {
            alert("Sorry, Cancellation Denied. This Entry is Already Selected Somewhere Or It is a Confirmed Entry!");
            return false;
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

        function NextPrevValidation() {

            var varhiddenValue = document.getElementById("<%=HiddenSearchField.ClientID%>").value
            var searchStatus = 0;
            var cbx = 0;
            var searchWord = "";



            if (varhiddenValue == "") {
                searchStatus = 1;
                cbx = 0;

            }

            else {


                var varhiddenValueSplit = varhiddenValue.split(",");
                searchWord = varhiddenValueSplit[0];
                searchStatus = varhiddenValueSplit[1];
                cbx = varhiddenValueSplit[2];


            }


            var el = document.getElementById("<%=ddlStatus.ClientID%>");
            for (var i = 0; i < el.options.length; i++) {
                if (el.options[i].value == searchStatus) {
                    el.selectedIndex = i;
                    break;
                }
            }
            if (cbx == "1") {
                document.getElementById("<%=cbxCnclStatus.ClientID%>").checked = true;
      }
      else {

          document.getElementById("<%=cbxCnclStatus.ClientID%>").checked = false;
      }
      document.getElementById("<%=txtProviderName.ClientID%>").value = searchWord;



        }


        function SearchValidation() {
            var ddlVehClass = document.getElementById("<%=ddlVehicleClass.ClientID%>").value;
            if (ddlVehClass == '--SELECT ALL CLASS--') {
                ddlVehClass = 0;
            }

            var searchStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
            var cbxStatus = document.getElementById("<%=cbxCnclStatus.ClientID%>");
            var cbx = 0;

            if (cbxStatus.checked) {
                cbx = 1;
            }
            else {
                cbx = 0;
            }

            var SearchWithoutReplace = document.getElementById("<%=txtProviderName.ClientID%>").value;
      var replaceText1 = SearchWithoutReplace.replace(/</g, "");
      var replaceText2 = replaceText1.replace(/>/g, "");
      document.getElementById("<%=txtProviderName.ClientID%>").value = replaceText2;
            var SearchWord = document.getElementById("<%=txtProviderName.ClientID%>").value;
            if (SearchWord == "") {
                document.getElementById("<%=HiddenSearchField.ClientID%>").value = "" + ',' + searchStatus + ',' + cbx + ',' + ddlVehClass;
                return true;
      }
      else {
          if (SearchWord.length >= 3) {

              document.getElementById("<%=HiddenSearchField.ClientID%>").value = SearchWord + ',' + searchStatus + ',' + cbx + ',' + ddlVehClass;
                    return true;
                }
                else {
                    document.getElementById("<%=txtProviderName.ClientID%>").value = "";
              document.getElementById("<%=HiddenSearchField.ClientID%>").value = "" + ',' + searchStatus + ',' + cbx + ',' + ddlVehClass;
                    return true;
                }
            }

           
        }

        function RemoveTag() {
            var SearchWithoutReplace = document.getElementById("<%=txtProviderName.ClientID%>").value;
            var replaceText1 = SearchWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtProviderName.ClientID%>").value = replaceText2;
        }

        </script>

      <%--  for giving pagination to the html table--%>
    <script src="../../../JavaScript/JavaScriptPagination1.js"></script>
    <script src="../../../JavaScript/JavaScriptPagination2.js"></script>
    <link href="../../../css/StyleSheetPagination.css" rel="stylesheet" />

    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bInfo": false,
                "bDestroy": true,
            });
        });


            </script>



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

     <script>

         // for not allowing enter
         function DisableEnter(evt) {

             evt = (evt) ? evt : window.event;
             var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
             if (keyCodes == 13) {
                 return false;
             }
         }



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
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <asp:HiddenField ID="hiddenRoleRecall" runat="server" />
    <asp:HiddenField ID="hiddenPermitLabelName" runat="server" />
        <br />
    
    <%--<asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />--%>



    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>

    <div id="divSuccessUpd" style="visibility: hidden">
        <asp:Label ID="lblSuccessUpd" runat="server"></asp:Label>
    </div>

        <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
    <div class="cont_rght">

        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/Vehicle-Master.png" style="vertical-align: middle;"  />
            <a id="a_Caption" href="gen_Vehicle_Master_List.aspx" >Vehicle</a>
        </div>
   <%--0006 start--%>
       <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 93.5%;">

       <div class="eachform" style="width: 50%; padding-left: 0.5%;padding-top:1% ;float: left;">
            <h2 style="margin-top: 0.5%;">Vehicle Class</h2>

            <asp:DropDownList ID="ddlVehicleClass" class="form1" TabIndex="1"  style="height:25px;width:52%;margin-right: 24%;" runat="server"></asp:DropDownList>


        </div>

         <div class="eachform" style="width: 70%; padding-left: 0.5%;float: left;">
            <h2 style="margin-top: 1%;">Register Number</h2>
            <asp:HiddenField ID="hiddenSearchDataBaseField" runat="server" Value="FLT_VEHICLES.VHCL_NUMBR" />
            <asp:HiddenField ID="HiddenSearchField" runat="server" />
            <asp:TextBox ID="txtProviderName" placeholder="Minimum 3 Characters for Searching" class="form1" runat="server" 
                MaxLength="300" TabIndex="2"  style="height:25px;width:35%;text-transform: uppercase; margin-left: 18px; margin-right: 8px; float: left" onblur="RemoveTag()"></asp:TextBox>
            <asp:Button ID="btnSearch" TabIndex="5" style="cursor:pointer;margin-top: -0.2%;margin-left: 8%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClick="btnSearch_Click" OnClientClick="return SearchValidation();"/>

        </div>



        <div class="eachform" style="width: 50.4%;margin-top: -.5%;margin-left: .5%;">

                <h2 style="margin-top:1%;">Status*</h2>

                <asp:DropDownList ID="ddlStatus" class="form1" runat="server" TabIndex="3" style="height:30px;width:29%;margin-bottom:2%;margin-right: 47%;">
                   <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Inactive" Value="2"></asp:ListItem>
                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                   
                </asp:DropDownList>

                 
            <div class="subform" style="width:39%;margin-top: -6.5%;margin-right: 3%;">
                    <asp:CheckBox ID="cbxCnclStatus" Text="" TabIndex="4" runat="server" onkeypress="return DisableEnter(event);" Checked="false" class="form2" />
                    <h3 style="margin-top:1%;">Show Deleted Entries</h3>
                  </div>

            </div>

       <table style="float:right">
            <tr>
                <td style="width:50%;">
                    <asp:Button ID="btnPrevious" TabIndex="6"  Width="98%" runat="server" class="searchlist_btn_rght" Text="Show Previous 500 Records" OnClick="btnPrevious_Click" OnClientClick="SetHiddenSearchCriteria();" />
                </td>
                <td style="width:50%;">

                    <asp:Button ID="btnNext" Width="98%" TabIndex="7" runat="server" class="searchlist_btn_rght" Text="Show Next 500 Records" OnClick="btnNext_Click" OnClientClick="SetHiddenSearchCriteria();"/>
                </td>
            </tr>
        </table>

              </div>

        <br />

        <div onclick="location.href='gen_Vehicle_Master.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;">

           <%-- <a href="gen_Product_Category.aspx">
                <img src="../../Images/BigIcons/add.png" alt="Add" />
            </a>--%>
        </div>
         <asp:HiddenField ID="hiddenNext" runat="server" />
        <asp:HiddenField ID="hiddenPrevious" runat="server" />
    <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
     <asp:HiddenField ID="hiddenMemorySize" runat="server" />
         <asp:HiddenField ID="hiddenRoleAdd" runat="server" />
         <asp:HiddenField ID="hiddenRoleUpdate" runat="server" />
         <asp:HiddenField ID="hiddenRoleCancel" runat="server" />
        <asp:HiddenField ID="hiddenCommodityValue" runat="server" />
        <%--  <br />
        <br />--%>
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

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 40%; padding-bottom: 0.7%; padding-top: 0.6%;">Vehicle Master</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
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



