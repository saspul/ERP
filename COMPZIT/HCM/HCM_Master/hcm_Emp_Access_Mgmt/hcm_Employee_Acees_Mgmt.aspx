<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Employee_Acees_Mgmt.aspx.cs" Inherits="HCM_HCM_Master_hcm_Employee_Acees_Mgmt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>

    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />

    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />
      <script src="/js/HCM/Common.js"></script>

    <style type="text/css">
        #TableHeaderBilling {
            background-color: #A4B487;
            color: white;
            font-weight: bold;
            font-family: calibri;
            line-height: 30px;
        }



        #TableFooterBilling {
            color: red;
            font-weight: bold;
            font-family: calibri;
            line-height: 25px;
        }



        #myTable {
            background-color: #039ED1;
            color: white;
            font-weight: bold;
            line-height: 30px;
        }

        .TableEmpAttendence {
            background-color: #667A43;
            color: white;
            font-weight: bold;
            font-family: calibri;
            line-height: 25px;
        }
    </style>
    <style>
        .cont_rght {
            padding-bottom: 2%;
            padding-top: 2%;
            width: 95%;
        }
    </style>
    <script src="/JavaScript/jquery-1.8.3.min.js"></script>
    <script src="../../js/HCM/Common.js"></script>
    <script type="text/javascript">

    </script>
    <script>
       


       
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
        function DeleteRow(number) {



            if (confirm("Are you sure you want to remove the row from daily attendance sheet?")) {

                var row = document.getElementById("row" + number);
                row.parentNode.removeChild(row);
                var CanclIds = document.getElementById("<%=HiddenCancelId.ClientID%>").value;
                if (CanclIds == '') {
                    document.getElementById("<%=HiddenCancelId.ClientID%>").value = number;
                }
                else {
                    document.getElementById("<%=HiddenCancelId.ClientID%>").value = document.getElementById("<%=HiddenCancelId.ClientID%>").value + ',' + number;
                }

                return false;
            }
        }
        // Pagination For correct List
        function CorrectPagination(Mode) {
            var NextId = document.getElementById("<%=HiddenCorrectNext.ClientID%>").value;
            var CorrectList = document.getElementById("<%=HiddenCrctJsonList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenCrctListCount.ClientID%>").value
            var Create = PageMethods.ServiceCorrectListToHtml(CorrectList, NextId, Mode, TotalCount, function (response) {
                var ReturnList = response;
                document.getElementById('cphMain_divEmpCorrectList').innerHTML = ReturnList[0];
                document.getElementById("<%=HiddenCorrectNext.ClientID%>").value = ReturnList[1];
                var lastCount = ReturnList[1];
                if (TotalCount > lastCount) {
                    document.getElementById("<%=btnCorrectNext.ClientID%>").disabled = false;
                } else {
                    document.getElementById("<%=btnCorrectNext.ClientID%>").disabled = true;
                }
                if (lastCount - 100 <= 0) {
                    document.getElementById("<%=btnCorrectPrevious.ClientID%>").disabled = true;
                } else {
                    document.getElementById("<%=btnCorrectPrevious.ClientID%>").disabled = false;
                }
                return false;
            })
            return false;
        }

        function InCorrectPagination(Mode) {
            var NextId = document.getElementById("<%=HiddenIncorrectNext.ClientID%>").value;
            var InCorrectList = document.getElementById("<%=HiddenIncrctJsonList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenIncrctListCount.ClientID%>").value
            var Create = PageMethods.ServiceInCorrectListToHtml(InCorrectList, NextId, Mode, TotalCount, function (response) {
                var returnList = response;
                document.getElementById('cphMain_divEmpIncorrectList').innerHTML = returnList[0];
                document.getElementById("<%=HiddenIncorrectNext.ClientID%>").value = returnList[1];
                var lastCount = returnList[1];
                if (TotalCount > lastCount) {
                    document.getElementById("<%=btnInCorrectNext.ClientID%>").disabled = false;
                } else {
                    document.getElementById("<%=btnInCorrectNext.ClientID%>").disabled = true;
                }
                if (lastCount - 100 <= 0) {
                    document.getElementById("<%=btnInCorrectPrevious.ClientID%>").disabled = true;
                } else {
                    document.getElementById("<%=btnInCorrectPrevious.ClientID%>").disabled = false;
                }
                return false;
            });
            return false;

        }

        function EarlyPagination(Mode) {
            var NextId = document.getElementById("<%=HiddenEarlyNext.ClientID%>").value;
            var EarlyList = document.getElementById("<%=HiddenEarlyJsonList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenEarliListCount.ClientID%>").value
            var Create = PageMethods.ServiceEarlygoToHtml(EarlyList, NextId, Mode, TotalCount, function (response) {
                var returnList = response;
                document.getElementById('cphMain_divEmpEarlyGoingList').innerHTML = returnList[0];
                document.getElementById("<%=HiddenEarlyNext.ClientID%>").value = returnList[1];
                 var lastCount = returnList[1];
                 if (TotalCount > lastCount) {
                     document.getElementById("<%=btnEarlyNext.ClientID%>").disabled = false;
                } else {
                    document.getElementById("<%=btnEarlyNext.ClientID%>").disabled = true;
                }
                if (lastCount - 100 <= 0) {
                    document.getElementById("<%=btnEarlyPrevious.ClientID%>").disabled = true;
                } else {
                    document.getElementById("<%=btnEarlyPrevious.ClientID%>").disabled = false;
                }
                return false;
            });
            return false;

        }

        function LatePagination(Mode) {
            var NextId = document.getElementById("<%=HiddenLateNext.ClientID%>").value;
            var LateList = document.getElementById("<%=HiddenLateComeJsonList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenLateComeListCount.ClientID%>").value
            var Create = PageMethods.ServiceLateComeListToHtml(LateList, NextId, Mode, TotalCount, function (response) {
                var returnList = response;
                document.getElementById('cphMain_divEmpLateComers').innerHTML = returnList[0];
                document.getElementById("<%=HiddenLateNext.ClientID%>").value = returnList[1];
                var lastCount = returnList[1];
                if (TotalCount > lastCount) {
                    document.getElementById("<%=btnLateNext.ClientID%>").disabled = false;
                 } else {
                     document.getElementById("<%=btnLateNext.ClientID%>").disabled = true;
                 }
                if (lastCount - 100 <= 0) {
                    document.getElementById("<%=btnLatePrevious.ClientID%>").disabled = true;
                } else {
                    document.getElementById("<%=btnLatePrevious.ClientID%>").disabled = false;
                }
                return false;
            });
            return false;

        }


       

    </script>
    <script>
        function ViewDuplication() {
            if (document.getElementById("<%=HiddenDupListCount.ClientID%>").value == '0') {
                document.getElementById("MyModalDuplicate").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
            }
            else {
                document.getElementById("MyModalDuplicate").style.display = "block";
                document.getElementById("freezelayer").style.display = "";
            }
            return false;

        }
        function ClosModalView() {
            if (confirm("Are you sure you want to cancel this action?")) {
                document.getElementById("MyModalDuplicate").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
            }
            else {

            }
            return false;
        }

        function ViewNextWindow() {
            if (document.getElementById("cphMain_divEmpCorrectList").style.display != "none") {
                document.getElementById("TabCorrectbtn").style.display = "none";
                document.getElementById("cphMain_divEmpCorrectList").style.display = "none";
                document.getElementById("cphMain_divEmpIncorrectList").style.display = "block";
                document.getElementById("TabInCorrectbtn").style.display = "block";
                document.getElementById("lblListTitle").innerText = "Incorrect List";
                document.getElementById("cphMain_btnPreviousPage").disabled = false;
                document.getElementById("cphMain_btnPreviousPage").style.background = "#3c8295";

                if (document.getElementById("<%=HiddenDupJsonList.ClientID%>").value != "") {
                    ViewDuplication();
                    
                } else {
                   
                }
                document.getElementById("cphMain_btnSave").style.display = "none";
            } else if (document.getElementById("cphMain_divEmpIncorrectList").style.display != "none") {
                document.getElementById("TabInCorrectbtn").style.display = "none";
                document.getElementById("cphMain_divEmpIncorrectList").style.display = "none";
                document.getElementById("cphMain_divEmpEarlyGoingList").style.display = "block";
                document.getElementById("TabEarlyButton").style.display = "block";
                document.getElementById("lblListTitle").innerText = "Early Going List";

                document.getElementById("cphMain_btnSave").style.display = "none";
            } else if (document.getElementById("cphMain_divEmpEarlyGoingList").style.display != "none") {
                document.getElementById("TabEarlyButton").style.display = "none";
                document.getElementById("cphMain_divEmpEarlyGoingList").style.display = "none";
                document.getElementById("cphMain_divEmpLateComers").style.display = "block";
                document.getElementById("TabLateButton").style.display = "block";
                document.getElementById("lblListTitle").innerText = "Late Comers List";

                document.getElementById("cphMain_btnNextPage").disabled = true;
                document.getElementById("cphMain_btnNextPage").style.background = "#b1bcbf";

                document.getElementById("cphMain_btnSave").style.display = "block";
            }
            //else if (document.getElementById("cphMain_divEmpLateComers").style.display != "none") {
            //    document.getElementById("cphMain_divEmpLateComers").style.display = "none";
            //    document.getElementById("TabLateButton").style.display = "none";
            //    document.getElementById("cphMain_divEmpOverdutyList").style.display = "block";
            //    document.getElementById("TabOverButton").style.display = "block";
            //    document.getElementById("lblListTitle").innerText = "Over Duty List";
            //    document.getElementById("cphMain_btnNextPage").disabled = true;
            //    document.getElementById("cphMain_btnNextPage").style.background = "#b1bcbf";
            //}

            return false;
        }
        function ViewPrevWindow() {
            //if (document.getElementById("cphMain_divEmpOverdutyList").style.display != "none") {
            //    document.getElementById("cphMain_divEmpOverdutyList").style.display = "none";
            //    document.getElementById("TabOverButton").style.display = "none";
            //    document.getElementById("cphMain_divEmpLateComers").style.display = "block";
            //    document.getElementById("TabLateButton").style.display = "block";
            //    document.getElementById("lblListTitle").innerText = "Late Comers List";
            //    document.getElementById("cphMain_btnNextPage").disabled = false;
            //    document.getElementById("cphMain_btnNextPage").style.background = "#3c8295";
            //} else
            if (document.getElementById("cphMain_divEmpLateComers").style.display != "none") {
                document.getElementById("cphMain_divEmpLateComers").style.display = "none";
                document.getElementById("TabLateButton").style.display = "none";
                document.getElementById("cphMain_divEmpEarlyGoingList").style.display = "block";
                document.getElementById("TabEarlyButton").style.display = "block";
                document.getElementById("lblListTitle").innerText = "Early Going List";
                document.getElementById("cphMain_btnNextPage").disabled = false;
                document.getElementById("cphMain_btnNextPage").style.background = "#3c8295";

                document.getElementById("cphMain_btnSave").style.display = "none";
            } else if (document.getElementById("cphMain_divEmpEarlyGoingList").style.display != "none") {
                document.getElementById("cphMain_divEmpEarlyGoingList").style.display = "none";
                document.getElementById("TabEarlyButton").style.display = "none";
                document.getElementById("cphMain_divEmpIncorrectList").style.display = "block";
                document.getElementById("TabInCorrectbtn").style.display = "block";
                document.getElementById("lblListTitle").innerText = "Incorrect List";
                document.getElementById("cphMain_btnSave").style.display = "none";
            } else if (document.getElementById("cphMain_divEmpIncorrectList").style.display != "none") {
                document.getElementById("cphMain_divEmpIncorrectList").style.display = "none";
                document.getElementById("TabInCorrectbtn").style.display = "none";
                document.getElementById("cphMain_divEmpCorrectList").style.display = "block";
                document.getElementById("TabCorrectbtn").style.display = "block";
                document.getElementById("lblListTitle").innerText = "Correct List";
                document.getElementById("cphMain_btnPreviousPage").disabled = true;
                document.getElementById("cphMain_btnPreviousPage").style.background = "#b1bcbf";
                document.getElementById("cphMain_btnSave").style.display = "none";
            }

            return false;
        }
    </script>

      <script>
          var $noCon = jQuery.noConflict();
          //show messages 
          function AddSuccesMessage() {
              $noCon("#success-alert").html("Employee details inserted successfully.");
              $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {

              });
              $noCon("#success-alert").alert();
              return false;
          }

          function ValidateAndSave() {

              //ezBSAlert({
              //    type: "confirm",
              //    messageText: "Are you sure?. you want to save the following daily attendance sheet.",
              //    alertType: "info"
              //}).done(function (e) {
              //    if (e == true) {
              //        ViewDuplication();
              //    } else {
              //        return false;
              //    }
              //});


              if (confirm("Are you sure you want to add the following daily attendance sheet to the table")) {

                  return true;
              }
              else {
                  return false;
              }
          }

          function ConfirmCancel() {
              if (document.getElementById("<%=HiddenCrctJsonList.ClientID%>").value != "" || document.getElementById("<%=HiddenIncrctJsonList.ClientID%>").value != "") {

                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to cancel this entry?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        return true;
                    } else {
                        return false;
                    }
                });
              } else {
                  return true;
                //window.location.href = "hcm_Employee_Acees_Mgmt.aspx";
            }

          }
          var $noConfig = jQuery.noConflict();
          function OverWriteDup() {
              var RoWCount = "";
              $('#DupEmpList tbody tr').each(function () {
                  var RowId = $(this).attr('id');
                  var SplitId = RowId.split('_');
                  var RowIdName = SplitId[0];
                  var MainCount = SplitId[1];
                  var Itemselect = $noConfig("#Dupcbx_" + MainCount);
                  if (Itemselect.length) {
                      if (document.getElementById('Dupcbx_' + MainCount).checked == true) {
                          RoWCount = RoWCount + "," + document.getElementById('tdDupRowCount_' + MainCount).innerHTML;
                      }
                  }
              });
              document.getElementById("<%=HiddenDupRows.ClientID%>").value = RoWCount;

              document.getElementById("MyModalDuplicate").style.display = "none";
              document.getElementById("freezelayer").style.display = "none";
              return false;
          }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="HiddenDupListCount" runat="server" />
    <asp:HiddenField ID="HiddenIncrctListCount" runat="server" />
    <asp:HiddenField ID="HiddenCrctListCount" runat="server" />
    <asp:HiddenField ID="HiddenEarliListCount" runat="server" />
    <asp:HiddenField ID="HiddenLateComeListCount" runat="server" />
    <asp:HiddenField ID="HiddenOverDutyListCount" runat="server" />

    <asp:HiddenField ID="HiddenDupJsonList" runat="server" />
    <asp:HiddenField ID="HiddenIncrctJsonList" runat="server" />
    <asp:HiddenField ID="HiddenCrctJsonList" runat="server" />
    <asp:HiddenField ID="HiddenEarlyJsonList" runat="server" />
    <asp:HiddenField ID="HiddenLateComeJsonList" runat="server" />
    <asp:HiddenField ID="HiddenOverDutyJsonList" runat="server" />

        <asp:HiddenField ID="HiddenDupJsonListSave" runat="server" />
    <asp:HiddenField ID="HiddenIncrctJsonListSave" runat="server" />
    <asp:HiddenField ID="HiddenCrctJsonListSave" runat="server" />
    <asp:HiddenField ID="HiddenEarlyJsonListSave" runat="server" />
    <asp:HiddenField ID="HiddenLateComeJsonListSave" runat="server" />
    <asp:HiddenField ID="HiddenOverDutyJsonListSave" runat="server" />

      <asp:HiddenField ID="HiddenDupRows" runat="server" />

    <asp:HiddenField ID="HiddenIncorrectNext" runat="server" />
    <asp:HiddenField ID="HiddenIncorrectPreviuos" runat="server" />
    <asp:HiddenField ID="HiddenCorrectNext" runat="server" />
    <asp:HiddenField ID="HiddenCorrectPreviuos" runat="server" />
    <asp:HiddenField ID="HiddenEarlyNext" runat="server" />
    <asp:HiddenField ID="HiddenEarlyPrevious" runat="server" />
    <asp:HiddenField ID="HiddenLateNext" runat="server" />
    <asp:HiddenField ID="HiddenLatePrevious" runat="server" />
    <asp:HiddenField ID="HiddenOverNext" runat="server" />
    <asp:HiddenField ID="HiddenOverPrevious" runat="server" />

    <asp:HiddenField ID="HiddenMissingData" runat="server" />

    <asp:HiddenField ID="HiddenCancelId" runat="server" />
    <asp:HiddenField ID="HiddenFile" runat="server" />
    <asp:Label ID="lblIndex" runat="server" Text="Label" Style="display: none"></asp:Label>
    <div id="main" role="main">
        <div id="content">
            <div class="alert alert-success" id="success-alert" style="display: none">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>

            <div class="alert alert-danger" id="success-alert-danger" style="display: none">
                <button type="button" class="close" data-dismiss="alert">x</button>

            </div>

            <div id="divList" class="list" runat="server" style="position: fixed; right: 4px; height: 26.5px; float: right;display:none;">
            </div>


            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; width: 80%;">
                <asp:Label ID="lblEntry" runat="server">Employee Attendance Porting</asp:Label>
            </div>
          
            <br />
           

            <div id="divEmpAttendenceContainer" class="leads_form">

                <div id="divTemplate2" runat="server" style="margin: 1%; background-color: #e3e3e3; padding: 1%; border: 1px solid #bfbfbf; height: 50px;">
                    <div id="divFileUploader" class="eachform" style="height: 30px; width: 52%; float: left;">
                        <h2 style="float: left; color: #084460; padding-top: 0.4%; padding-left: 1.2%;">Choose CSV File for Importing Data:</h2>
                        <asp:FileUpload ID="fupImportCsv" runat="server" Accept=".csv"
                            Style="margin-left: 4%; cursor: pointer; display: block; float: left" />
                         
                        <a href="/CustomFiles/csvTemplate/Attendance Porting.csv"><img src="../../../Images/Icons/CSV.PNG" title="Sample CSV File" style="float: right;margin-right: 14%;margin-top: -6%;" /></a>
                       
                    </div>
                   
                    <div class="subform" style="width: 130px; margin-bottom: 2%;">
                        
                        <asp:Button ID="btnImportCsv" runat="server" class="save" Style="background: #3c8295;" Text="Import" OnClick="btnImport_Click" />
                    </div>

                    <div style="float: left; width: 20%;">

                        <div>

                            <asp:CheckBox ID="cbxImprtHasHeader" Text="" runat="server" Checked="false" class="form2" Style="margin-top: -0.4%;" onkeypress=" return DisableEnter(event);" />
                            <label style="font-family: Calibri; color: #3c8295; cursor: pointer;font-size:15px" for="cphMain_cbxImprtHasHeader">My data has Headers</label>
                        </div>
                    </div>
                </div>

                <div id="divLists" style="width: 98%; float: left; margin: 1%; background-color: #e3e3e3; padding: 1%; border: 1px solid #bfbfbf;">
                    <div style="float: left; width: 100%">
                        <asp:Button ID="btnNextPage" Style="cursor: pointer; background: #3c8295; padding: 3px 10px; float: right;" runat="server" class="save" Text="Next >>" OnClientClick="return ViewNextWindow();" />
                        <asp:Button ID="btnSave" runat="server" class="save" Text="Save" Style="display: none; cursor: pointer; background: #3c8295; padding: 3px 10px; float: right;" OnClientClick="return ValidateAndSave();" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" class="save" Text="Cancel" Style="cursor: pointer; background: #3c8295; padding: 3px 10px; float: right;" OnClientClick="return ConfirmCancel();" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnPreviousPage" disabled="disabled" Style="cursor: pointer; background: #b1bcbf; padding: 3px 10px; float: right;" runat="server" class="save" Text="<< Previous" OnClientClick="return ViewPrevWindow();" />
                        <label id="lblListTitle" style="margin-left: 38%; font-size: 22px; color: #500b03; font-family: calibri;">Correct List</label>
                    </div>
                    <table id="TabCorrectbtn" style="float: left; margin-left: .8%;">
                        <tr>
                            <td style="width: 50%;">
                                <asp:Button ID="btnCorrectPrevious" disabled="disabled" Style="cursor: pointer; width: 100%; background: #3c8295; padding: 3px 10px;" runat="server" class="searchlist_btn_rght" Text="Previous 100 Records" OnClientClick="return CorrectPagination(0);" />
                            </td>
                            <td style="width: 50%;">

                                <asp:Button ID="btnCorrectNext"   Style="cursor: pointer; width: 100%; background: #3c8295; padding: 3px 10px;" runat="server" class="searchlist_btn_rght" Text="Next 100 Records" OnClientClick="return CorrectPagination(1);" />
                            </td>
                        </tr>
                    </table>
                    <table id="TabInCorrectbtn" style="float: left; margin-left: .8%; display: none;">
                        <tr>
                            <td style="width: 50%;">
                                <asp:Button ID="btnInCorrectPrevious" disabled="disabled" Style="cursor: pointer; width: 100%; background: #3c8295; padding: 3px 10px;" runat="server" class="searchlist_btn_rght" Text="Previous 100 Records" OnClientClick="return InCorrectPagination(0);" />
                            </td>
                            <td style="width: 50%;">

                                <asp:Button ID="btnInCorrectNext"  Style="cursor: pointer; width: 100%; background: #3c8295; padding: 3px 10px;" runat="server" class="searchlist_btn_rght" Text="Next 100 Records" OnClientClick="return InCorrectPagination(1);" />
                            </td>
                        </tr>
                    </table>
                    <table id="TabEarlyButton" style="float: left; margin-left: .8%; display: none;">
                        <tr>
                            <td style="width: 50%;">
                                <asp:Button ID="btnEarlyPrevious" disabled="disabled" Style="cursor: pointer; width: 100%; background: #3c8295; padding: 3px 10px;" runat="server" class="searchlist_btn_rght" Text="Previous 100 Records" OnClientClick="return EarlyPagination(0);" />
                            </td>
                            <td style="width: 50%;">

                                <asp:Button ID="btnEarlyNext"  Style="cursor: pointer; width: 100%; background: #3c8295; padding: 3px 10px;" runat="server" class="searchlist_btn_rght" Text="Next 100 Records" OnClientClick="return EarlyPagination(1);" />
                            </td>
                        </tr>
                    </table>
                    <table id="TabLateButton" style="float: left; margin-left: .8%; display: none;">
                        <tr>
                            <td style="width: 50%;">
                                <asp:Button ID="btnLatePrevious" disabled="disabled" Style="cursor: pointer; width: 100%; background: #3c8295; padding: 3px 10px;" runat="server" class="searchlist_btn_rght" Text="Previous 100 Records" OnClientClick="return LatePagination(0);" />
                            </td>
                            <td style="width: 50%;">

                                <asp:Button ID="btnLateNext"  Style="cursor: pointer; width: 100%; background: #3c8295; padding: 3px 10px;" runat="server" class="searchlist_btn_rght" Text="Next 100 Records" OnClientClick="return LatePagination(1);" />
                            </td>
                        </tr>
                    </table>
                    <table id="TabOverButton" style="float: left; margin-left: .8%; display: none;">
                        <tr>
                            <td style="width: 50%;">
                                <asp:Button ID="btnOverPrevious" disabled="disabled" Style="cursor: pointer; width: 100%; background: #3c8295; padding: 3px 10px;" runat="server" class="searchlist_btn_rght" Text="Previous 100 Records" OnClientClick="return OverPagination(0);" />
                            </td>
                            <td style="width: 50%;">

                                <asp:Button ID="btnOverNext" Style="cursor: pointer; width: 100%; background: #3c8295; padding: 3px 10px;" runat="server" class="searchlist_btn_rght" Text="Next 100 Records" OnClientClick="return OverPagination(1);" />
                            </td>
                        </tr>
                    </table>
                    <div id="divTables" style="width: 98%; margin: 1%; padding: 0.6%; border: 1px solid #6f93ae; background-color: #fcfff7; float: left; margin-top: 0.2%;">
                        <table id="TableHeaderEmpAttendence" class="TableEmpAttendence" rules="all" style="width: 100%; float: left;">

                            <tr>
                                <td style="font-size: 14px; width: 5%; padding-left: 0.5%;text-align: left;">Sl#</td>
                                <td style="font-size: 14px; width: 15%; padding-left: 0.5%;text-align: left;">Employee ID</td>
                                <td style="font-size: 14px; width: 20%; padding-left: 0.5%;text-align: left;">First Name</td>
                                <td style="font-size: 14px; width: 20%; padding-left: 0.5%;text-align: left;">Last Name</td>
                                <td style="font-size: 14px; width: 15%; padding-left: 0.5%;text-align: center;">Date</td>
                                <td style="font-size: 14px; width: 12.5%; padding-left: 0.5%;text-align: center;">Check In</td>
                                <td style="font-size: 14px; width: 12.5%; padding-left: 0.5%;text-align: center;">Check Out</td>

                            </tr>
                        </table>

                        <div id="divEmpCorrectList" runat="server" style="width: 100%; min-height: 200px; overflow-y: auto;">
                            <table id="CorrectEmpList" class="tableCsv dataTable " style="width:100%;float:left;" cellspacing="0" cellpadding="2px">
                                <tbody>
                                    <tr>
                                        <td colspan="7"> 
                                            <p style="text-align: center;font-family: calibri;">No Data Available</p>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                        </div>
                        
                        <div id="divEmpIncorrectList" runat="server" style="display: none; width: 100%; min-height: 200px; overflow-y: auto;">
                        <table id="InCorrectEmpList" class="tableCsv dataTable " style="width:100%;float:left;" cellspacing="0" cellpadding="2px">
                                <tbody>
                                    <tr>
                                        <td colspan="7"> 
                                            <p style="text-align: center;font-family: calibri;">No Data Available</p>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div id="divEmpEarlyGoingList" runat="server" style="display: none; width: 100%; min-height: 200px; overflow-y: auto;">
                        <table id="EarlyEmpList" class="tableCsv dataTable " style="width:100%;float:left;" cellspacing="0" cellpadding="2px">
                                <tbody>
                                    <tr>
                                        <td colspan="7"> 
                                            <p style="text-align: center;font-family: calibri;">No Data Available</p>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div id="divEmpLateComers" runat="server" style="display: none; width: 100%; min-height: 200px; overflow-y: auto;">
                        <table id="LateEmpList" class="tableCsv dataTable " style="width:100%;float:left;" cellspacing="0" cellpadding="2px">
                                <tbody>
                                    <tr>
                                        <td colspan="7"> 
                                            <p style="text-align: center;font-family: calibri;">No Data Available</p>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div id="divEmpOverdutyList" runat="server" style="display: none; width: 100%; min-height: 200px; overflow-y: auto;">
                        </div>
                    </div>


                </div>

            </div>

        </div>
        <div id="MyModalDuplicate" class="MyModalDuplicate">
            <div id="divDuplicate">
                <div id="divSubHeader" style="height: 30px; background-color: #6f7b5a;">

                    <label style="margin-left: 32%; font-size: 20px; color: #fff; font-family: calibri;">Duplicated/Already-Uploaded Employee List</label>

                    <img class="closeCancelView" style="margin-top: .5%; margin-right: 1%; float: right; cursor: pointer;" onclick="return ClosModalView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
                </div>

                <div id="divErrorNotificationSb" style="visibility: hidden">
                    <asp:Label ID="lblErrorNotificationSb" runat="server"></asp:Label>
                </div>

                <div id="divDupTable" runat="server" style="float: left; width: 96%; margin-left: 1%; padding: 11px;max-height: 400px;overflow: auto;">
                </div>

                <asp:Button ID="btnOverWrite" class="btn btn-primary" runat="server" Text="Overwrite" Style="width: 105px; float: left; margin-left: 37%; margin-top: 1%; margin-bottom: 0.5%;" OnClientClick="return OverWriteDup();" OnClick="btnOverWrite_Click" />
                <input type="button" id="btnSubCncl" class="btn btn-primary" style="width: 90px; float: left; margin-left: 1%; margin-top: 1%; margin-bottom: 0.5%;" onclick="return ClosModalView();" value="Cancel" />
            </div>
        </div>

        <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: black; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.8; z-index: 29; height: auto !important; display: none;"
            class="freezelayer" id="freezelayer">
        </div>
    </div>

    <style>
        .tableCsv {
            font-family: Calibri;
        }

            .tableCsv > tbody > tr:nth-child(2n+1) > td {
                height: 30px;
                background: #d5d5d5;
                font-size: 14px;
                color: black;
            }

            .tableCsv > tbody > tr:nth-child(2n) > td {
                height: 30px;
                font-size: 14px;
                background: #ededed;
                color: #5c5c5e;
            }

            .tableCsv td {
                border-right: 1px solid white;
            }

        .MyModalDuplicate {
            display: none;
            position: fixed;
            z-index: 100;
            padding-top: 0%;
            left: 8%;
            top: 10%;
            width: 84%;
            background-color: white;
            border: 3px solid;
            border-color: #6f7b5a;
        }

        .save {
            background: #3c8295;
        }

            .save:hover {
                background: #4398b0;
            }

        .TableEmpAttendence {
            background-color: #3c8295;
        }

        .leads_form {
            background: #f4feff;
            border: 1px solid #0e7e90;
        }

        .searchlist_btn_rght:disabled {
            background: #a7a7a7 !important;
        }
    </style>
 
  

</asp:Content>

