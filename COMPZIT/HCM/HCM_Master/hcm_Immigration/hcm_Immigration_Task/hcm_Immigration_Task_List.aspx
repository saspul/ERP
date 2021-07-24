<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Immigration_Task_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_Immigration_hcm_Immigration_Task_hcm_Immigration_Task_List" %>

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
             .tooltips {
    position: inherit;
    z-index: 1030;
    display: block;
    padding: 5px;
    font-size: 11px;
    opacity: 0;
    filter: alpha(opacity=0);
    visibility: visible;
}

     </style>
    <script src="/JavaScript/jquery-1.8.3.min.js"></script>
  
     
    <script type="text/javascript">
      


        function getdetails(href) {
            window.location = href;
            return false;
        }


        </script>

   <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            RadioChange();
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
            });
        });


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
    </style>
   


    <style>
        #cphMain_divReport {
            float: left;
            width: 100%;
        }

      

        #TableRprtRow .tdT {
            line-height: 100%;
        }


        .cont_rght {
            width: 98%;
        }
    </style>

    <script>


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

        function SearchValidation() {
            ret = true;
            document.getElementById('divMessageArea').style.display = "none";
            document.getElementById('imgMessageArea').src = "";

           


            var IssueDate = document.getElementById("<%=txtAsgnedDate.ClientID%>").value;
            var ExpDate = document.getElementById("<%=txtTodate.ClientID%>").value;
            if (ExpDate != "" && IssueDate != "") {
                var datepickerDate = document.getElementById("<%=txtAsgnedDate.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var datepickerDate = document.getElementById("<%=txtTodate.ClientID%>").value;
                  var arrDatePickerDate = datepickerDate.split("-");
                  var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                  if (dateTxIss >= dateCompExp) {
                      document.getElementById("<%=txtTodate.ClientID%>").value = "";
                    ExpDate = "";
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "To date should be greater than assigned date";
                var txthighlit = document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTodate.ClientID%>").focus();
                    ret = false;
                }
            }
            return ret;

        }

        function RadioChange() {
          
           
              if (document.getElementById("<%=radioSingle.ClientID%>").checked == true) {
                  document.getElementById("cphMain_btnEdit").style.display = "none";
                  document.getElementById("cphMain_divReport").style.display = "block";
                  document.getElementById("cphMain_divReportMul").style.display = "none";
              }
              else {                
                  document.getElementById("cphMain_btnEdit").style.display = "block";
                  document.getElementById("cphMain_divReport").style.display = "none";
                  document.getElementById("cphMain_divReportMul").style.display = "block";
              }
           
          }
        </script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
     <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="hiddenRowCount" runat="server" />
    
   <div id="divMessageArea" style="display: none;width:91%;">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="/Images/BigIcons/Employee-Sponser-Master.png" style="vertical-align: middle;" />
   Immigration Tasks
        </div >
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 100%;margin-top:0.5%;height:10%;">


             <div style="width: 14%; float: left; padding: 5px; border: 1px solid #c3c3c3;margin-top:1.5%;margin-left:1%;display:none;">
                    
                    <div style="float: left; margin-right: 0%; width: 100%;">
                        <asp:RadioButton ID="radioSingle" Text="Single" runat="server" Checked="true" GroupName="RadioSkCer" OnChange="RadioChange();" Style="float: left; font-family: calibri" />
                        <asp:RadioButton ID="radioMultiple" Text="Multiple" runat="server" GroupName="RadioSkCer" OnChange="RadioChange();" Style="float: left; font-family: calibri; margin-left: 6%;" />
                    </div>
                </div>

    <div class="eachform" style="float:left;width:25%;margin-top:1.5%;margin-left:3%;">
                <h2 style="margin-top:1%;">Assigned Date</h2>
                
               <div id="div1" class="input-append date" style="float:right;margin-right:8%;width: 49%;">

                 
                   
                        <asp:TextBox ID="txtAsgnedDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="height:30px;width:68.6%;margin-top: 0%;float:left;margin-left: -2.3%;"></asp:TextBox>

                        <input type="image" runat="server" id="Image1" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:-0.2%;" />
                           <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                               <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
                           <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate1_8_3.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker_pt_br.js">
                            </script>
                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#div1').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div>
      

      <div class="eachform" style="float:left;width:25%;margin-top:1.5%;margin-left:2%;">
                <h2 style="margin-top:1%;">To</h2>
                
               <div id="div2" class="input-append date" style="float:right;margin-right:38%;width: 52%;">

                        <asp:TextBox ID="txtTodate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="height:30px;width:68.6%;margin-top: 0%;float:left;margin-left: 5.7%;"></asp:TextBox>

                        <input type="image" runat="server" id="Image2" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:-0.2%;" />
                    <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                               <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
                           <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate1_8_3.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker_pt_br.js">
                            </script>
                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#div2').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                // startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div>
            
                <div class="eachform" style="width: 25% ;float: left;margin-top:1.5%;margin-left:-3%;">
            <h2 style="margin-top: 1%;margin-left: 0%;">Employee</h2>

            <asp:DropDownList ID="ddlEmp" class="form1"   style="height:30px;width:63%;float: right;margin-right: 3%;" runat="server">      </asp:DropDownList>
             
        </div>
 
             <div style="width:12%;float:right;margin-left: 0%;margin-top:1.5%;">


        
                <div class="eachform" style="width:98%;float: left;">
                <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: -0.4%;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />
                     </div>
                 </div>

             <div style="width:12%;float:right;margin-left: 0%;margin-top:0.5%;">


        
                <div class="eachform" style="width:98%;float: left;margin-left:100%;">
                <asp:Button ID="btnEdit" style="cursor:pointer;margin-top: -0.4%;width:86%;display:none;"  runat="server" class="save" Text="Edit" OnClientClick="return SearchValidation();"  />
                     </div>
                 </div>
            <br style="clear: both" />
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
         <div id="divReportMul" class="table-responsive" runat="server">
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
     <style>
           input[type="radio"] {
            display: table-cell;
        }
         .open > .dropdown-menu {
            display: none;
        }

    #ReportTable_filter input {
    height: 17px;
    width: 200px;
    color: #336B16;
    font-size: 14px;
      }

    </style>
</asp:Content>



