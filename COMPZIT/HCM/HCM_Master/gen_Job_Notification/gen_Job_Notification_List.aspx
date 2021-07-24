<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_Job_Notification_List.aspx.cs" Inherits="HCM_HCM_Master_gen_Job_Notification_gen_Job_Notification_List" %>

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
        

     </style>
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
     
    <script type="text/javascript">
        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Job description details inserted successfully.";
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Job description details updated successfully.";
        }
        

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
    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>

    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

    <script>


        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {
                // $au('#cphMain_ddlCustomer').selectToAutocomplete1Letter();


            });
        })(jQuery);





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


       
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
     <asp:HiddenField ID="hiddenDecimalCount" runat="server" />

   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="/Images/BigIcons/Job_Notify.png" style="vertical-align: middle;" />
     Job Notification
        </div >
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 93.5%;margin-top:0.5%;height:10%;">



     
            <div style="width:100%;float:left;margin-top:14px">
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
                      <div class="eachform" style="width: 27%;margin-top:0.5%;margin-left:2%;float: left;">
            <h2 style="margin-top:1%;"> Department</h2>

            <asp:DropDownList ID="ddlDep" class="form1" style="height:25px;width:160px;height:25px;width:69%;float:left; margin-left: 3%;" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDep_SelectedIndexChanged">      </asp:DropDownList>
             
        </div>
            
           <div class="eachform" style="width: 29%; padding-left: 2%;padding-top:0.5% ;float: left;">   <%--emp25--%>

                <h2 style="margin-top: 0.5%;margin-left: 0%;">Division</h2>

                <asp:DropDownList ID="ddlDivision" AutoPostBack="true" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" class="form1" runat="server" Style="height:25px;width:65%;float: left;margin-left: 6%;">
             
      
                </asp:DropDownList>


            </div>                       
                <div class="eachform" style="width: 24%; padding-left: 2%;padding-top:0.5% ;float: left;">
            <h2 style="margin-top: 0.5%;margin-left: 0%;"> Project</h2>

            <asp:DropDownList ID="ddlProject" class="form1"  style="height:25px;width:74%;float: left;margin-left: 6%;" runat="server">      </asp:DropDownList>
             
        </div>
                </ContentTemplate>
   </asp:UpdatePanel>
                   <div class="eachform" style="width:14%;float: left;">
                <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: 2.6%;margin-left: 10%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />
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

          
    </div>
</asp:Content>



