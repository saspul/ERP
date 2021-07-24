<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Pasprt_hndovr.aspx.cs" Inherits="HCM_HCM_Master_hcm_Pasprt_hndovr_sts_hcm_Pasprt_hndovr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
      <script src="/JavaScript/multiselect/jQuery/jquery-3.1.1.min.js"></script>
        <script src="/JavaScript/datepicker/bootstrap-datepicker.js"></script>
    <link href="/JavaScript/datepicker/datepicker3.css" rel="stylesheet" />

   <script>
      
       function Handover() {

           document.getElementById("<%=txthandOvrDt.ClientID%>").style.borderColor = "";

           var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
           var strAmntList = "";
           checked = false;
           count = 0;
           for (i = 0; i < RowCount; i++) {
               if (document.getElementById('cblcandidatelist' + i).checked) {

                   checked = true;
                   count++;
                   strAmntList = strAmntList + document.getElementById('tdcandiateid' + i).innerHTML + ',';
                   document.getElementById("<%=Hiddenchecklist.ClientID%>").value = strAmntList;
                   document.getElementById('divErrorlabel').style.visibility = "hidden";
               }

           }
           if (count > 0) {

               if (document.getElementById("<%=HiddenStatus.ClientID%>").value == 1) {

                   document.getElementById("lblImmiHead").innerHTML = "Passport Hand Over To Hr";
               }
               else if (document.getElementById("<%=HiddenStatus.ClientID%>").value == 0) {

                   document.getElementById("lblImmiHead").innerHTML = "Passport Hand Over To Employee";
               }

               document.getElementById("MyModalProcessMultiple").style.display = "block";
               document.getElementById("freezelayer").style.display = "";
           }
           else {
               document.getElementById('divErrorlabel').style.visibility = "visible";
           }

           //document.getElementById("<%=txthandOvrDt.ClientID%>").focus();
       }


       function ClosePopup() {
          if (confirm("Are you sure you want to close this window")) {
              document.getElementById("<%=txthandOvrDt.ClientID%>").value = "";
              document.getElementById("MyModalProcessMultiple").style.display = "none";
              document.getElementById("freezelayer").style.display = "none";
              return true;
          }
          else {
              return false;
          }
       }

       function selectAllEmployees() {

           var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
           var strAmntList = "";
           if (document.getElementById('cbxSelectAll').checked == true) {
               for (i = 0; i < RowCount; i++) {

                   document.getElementById('cblcandidatelist' + i).checked = true;

               }
           }
           else {
               for (i = 0; i < RowCount; i++) {

                   document.getElementById('cblcandidatelist' + i).checked = false;

               }
           }
       }


      function validation() {
          var ret = true;
              var handover = document.getElementById("<%=txthandOvrDt.ClientID%>").value;

              if (handover == "") {
                  document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                  document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Please fill this out";
                  document.getElementById("<%=txthandOvrDt.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txthandOvrDt.ClientID%>").focus();
                  return false;
              }

          if (!handover.match(/^(0[1-9]|[12][0-9]|3[01])[\- \/.](?:(0[1-9]|1[012])[\- \/.](201)[2-9]{1})$/)) {
              document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
              document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Please fill this out";
              document.getElementById("<%=txthandOvrDt.ClientID%>").style.borderColor = "Red";
              document.getElementById("<%=txthandOvrDt.ClientID%>").focus();
              return false;
          }

          else {
              if (confirm("Are you sure you want to confirm?")) {
                  document.getElementById("<%=txthandOvrDt.ClientID%>").style.borderColor = "";
              }
              else {
                  document.getElementById("<%=txthandOvrDt.ClientID%>").value = "";
                  return false;
              }
          }
              return ret;
          }

      

       var $noCon = jQuery.noConflict();
       $noCon(function () {
          
           document.getElementById("freezelayer").style.display = "none";

       });

       // for not allowing enter
       function DisableEnter(evt) {

           evt = (evt) ? evt : window.event;
           var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
           if (keyCodes == 13) {
               return false;
           }
       }

       function SuccessUpdation() {
           document.getElementById('divMessageArea').style.display = "";
           document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
           document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Passport Handover Status updated successfully.";
        }

        </script>


    <script>
        var $au = jQuery.noConflict();
        $au(function () {
            $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
        });


        function ImagePosition(object) {

            var $Mo = jQuery.noConflict();

            var offset = $Mo("#" + object).offset();

            var posY = 0;
            var posX = 0;
            posY = offset.top;

            posX = offset.left

            posX = 47;

            var d = document.getElementById('ui-id-1');
            d.style.position = "absolute";
            d.style.left = posX + -6.5 + '%';
            d.style.top = posY + 53.5 + '%';
        }
    </script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <style>
         .MyModalProcessMultiple {
            display: none;
            position: fixed;
            z-index: 113;
            padding-top: 0%;
            left: 30%;
            top: 15%;
            width: 35%;
            height: 80%;
            /*overflow: auto;*/
            background-color: white;
            border: 3px solid;
            border-color: #6f7b5a;
        }

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

    </style>
<%--    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>--%>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    
    
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenCandidateId" runat="server" />
    <asp:HiddenField ID="HiddenreqstId" runat="server" />
    <asp:HiddenField ID="HiddenShortlistMasterid" runat="server" />
    <asp:HiddenField ID="hiddenRowCount" runat="server" />
    <asp:HiddenField ID="Hiddenchecklist" runat="server" />
    <asp:HiddenField ID="hiddenFinishStatus" runat="server" />
    <asp:HiddenField ID="hiddenCloseStatus" runat="server" />
    <asp:HiddenField ID="hiddenRecallStatus" runat="server" />
    <asp:HiddenField ID="hiddenAlreadyClosed" runat="server" />
    <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="hiddenAsignId" runat="server" />
    <asp:HiddenField ID="hiddenTotalData" runat="server" />
    <asp:HiddenField ID="HiddenStatus" runat="server" />
   
    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label> 
    </div>
     <div class="cont_rght">


 <div style="cursor: default; float: right;  font-family: Calibri; margin-bottom:1%" class="print">
     <a id="print_cap" target="_blank" data-title="Passport Hand OVer Status" href="/HCM/HCM_Reports/Print/48_Print.htm" style="color: rgb(83, 101, 51)">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%;margin-bottom:-46%;margin-left:-18%;">
        <span style="margin-top: 2px; margin-left:35%;">Print</span></a>                                  
</div>
        <div id="divReportCaption" style="width: 80%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; float: left">
            <asp:Label ID="lblEntry" runat="server">Passport Hand Over Status</asp:Label>
        </div>
        <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke; float: left">

                 <div class="eachform" style="width: 30%; float: left;">
                    <h2>Department </h2>

                    <asp:DropDownList ID="ddldep" class="form1" runat="server" Style="height: 30px; width: 61%; float: left; margin-left: 5%;" AutoPostBack="true" OnSelectedIndexChanged="ddldep_SelectedIndexChanged">
                    </asp:DropDownList>

                  </div>

               <div class="eachform" style="width: 30%; float: left;">
                    <h2>Division </h2>

                    <asp:DropDownList ID="ddldiv" class="form1" runat="server" Style="height: 30px; width: 63%; float: left; margin-left: 9%;" AutoPostBack="true" OnSelectedIndexChanged="ddldiv_SelectedIndexChanged">
                    </asp:DropDownList>

                  </div>


            <div style="width: 38%; float: left; padding: 5px; border: 1px solid #c3c3c3;">
                   
                    <div style="float: right; margin-right: 0%; width: 89%;">
                        <asp:RadioButton ID="radioAHr" Text="With HR" runat="server" Checked="true" GroupName="RadioSkCer" Style="float: left; font-family: calibri" OnKeypress="return DisableEnter(event)" />
                        <asp:RadioButton ID="radioEmployee" Text="With Employee" runat="server" GroupName="RadioSkCer" Style="float: left; font-family: calibri; margin-left: 6%;" OnKeypress="return DisableEnter(event)" />
                    </div>
                </div>

            <div style="width:100%;float:left">

                <div class="eachform" style="width: 30%; float: left;margin-top: 3%;">
                    <h2>Designation </h2>

                    <asp:DropDownList ID="ddldesig" class="form1" runat="server" Style="height: 30px; width: 62%; float: left; margin-left: 5%;" AutoPostBack="true" OnSelectedIndexChanged="ddldesig_SelectedIndexChanged">
                    </asp:DropDownList>

                </div>


               <div class="eachform" style="width: 28%; float: left;margin-top: 3%;">
                    <h2>Employee </h2>
                    <asp:DropDownList ID="ddlEmployee" class="form1" runat="server" onkeydown="ImagePosition('cphMain_ddlEmployee')" Style="height: 30px; width: 62%; float: left; margin-left: 5%;">
                    </asp:DropDownList>

                </div>

              <div class="eachform" style="width: 29%; float: right;margin-top: 3%;">
                      <asp:Button ID="btnSearch" Style="cursor: pointer; margin-left: 10%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click"  />
           </div>
                            </div>

            <div id="divReport" class="table-responsive" runat="server" style="float: left; width: 100%; margin-top: 1%">
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
            <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    <div id="divPrintReport" runat="server" style="display: none">
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>

            <div id="divErrorlabel" style="float: left; margin-left: 21%; visibility: hidden;">
                <label style="color: red; font-family: calibri;">Please select atleast one Employee</label>
            </div>
            <input type="button" id="btnAssign" runat="server" style="width: 114px; float: right; margin-right: 87.5%; margin-top: -2%; background: #127c8f; border:2px solid #c5c5c5;" class="save" value="Hand Over" onclick="return Handover();" />

        </div>

    </div>
    <div id="MyModalProcessMultiple" class="MyModalProcessMultiple" style="height:240px;">
            <div id="divJbFull">
                <div id="DivEmpHeader" style="height: 30px; background-color: #6f7b5a;">

                    <label id="lblImmiHead" style="margin-left: 29%; font-size: 18px; color: #fff; font-family: calibri;"></label>

                    <img class="closeCancelView" style="margin-top: .5%; margin-right: 1%; float: right; cursor: pointer;" onclick="return ClosePopup();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
                </div>

                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

              <div id="divCardNumber" style="width: 100%; margin-top: 2.2%;" class="eachform">
                        <div id="div1" style="width: 66%; margin-top: 6.2%; margin-left:18%" class="eachform">
                             <asp:TextBox ID="txthandOvrDt" style="margin-left:1%;float:right;" runat="server" placeholder="DD-MM-YYYY" onkeypress="return DisableEnter(event)"></asp:TextBox>
            <h2 style="float:left;">Hand Over Date *</h2>
                      </div>
                  <div id="divdatepick" style="width: 47%; margin-top: 7%; margin-left:34%" class="eachform">
        <asp:Button ID="btnAdd" runat="server" class="save" Text="Confirm" OnClientClick="return validation();" OnClick="btnSave_Click" />
                      </div>
        </div>
                </div>
        </div>
     <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>


    <script>
        var $noC = jQuery.noConflict();

        $noC('#cphMain_txthandOvrDt').datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            language: 'en',
            //startDate: new Date()
        });
    </script>
      <style>
         #ReportTable_filter input {
         height: 23px;
         width: 200px;
         color: #336B16;
         font-size: 14px;
     }
    </style>
    
      <style>
     input[type="radio"] {
            display: table-cell;
        }



          .cont_rght {
              width: 95%;
          }

           .datepicker table tr td, .datepicker table tr th {
            text-align: center;
            width: 0px;
            height: 0px;
            border-radius: 4px;
            border: none;
        }

        .table > thead > tr > th {
            vertical-align: bottom;
            background: #7b7b7b;
            color: #fff;
        }

        .datepicker table tr td.disabled, .datepicker table tr td.disabled:hover {
            background: none;
            color: #c5c5c5;
            cursor: default;
        }

          #divErrorRsnAWMS {
              border-radius: 4px;
              background: #fff;
              color: #53844E;
              font-size: 12.5px;
              font-family: Calibri;
              font-weight: bold;
              border: 2px solid #53844E;
              margin-top: 2.5%;
              margin-bottom: 2%;
          }

            </style>
</asp:Content>

