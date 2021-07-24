<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_App.master" AutoEventWireup="true" CodeFile="app_CorporatePackList.aspx.cs" Inherits="Master_app_CorporatePack_app_CorporatePackList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script type="text/javascript">


        function getdetails(href) {
            window.location = href;
            return false;
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

    <script>
        function SuccessConfirmation() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Corporate Pack Details Inserted Successfully.";
        }
        function SuccessUpdation() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Corporate Pack Details Updated Successfully.";
        }

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">


    <div class="cont_rght">


         <div id="divErrorTotal" style="visibility: hidden">
            <asp:Label ID="lblErrorTotal" runat="server"></asp:Label>
        </div>




        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="../../Images/BigIcons/CorpPack.png" style="vertical-align: middle;" />
            Corporate Pack 
        </div>
                 <%--0006 start--%>
        <div class="eachform" style="width: 22%;margin-top: 2%;">

                <h2 style="margin-top:1%;">Status*</h2>

                <asp:DropDownList ID="ddlStatus" Height="30px" Width="160px" class="form1" runat="server" Style="margin-left: 15%;margin-bottom:2%;">
                       <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Inactive" Value="2"></asp:ListItem>
                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                </asp:DropDownList>


            </div>

                <div class="eachform" style="width:25%; margin-left: 7%;">
                <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: -0.4%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClick="btnSearch_Click"  />
                     </div>
        <%--stop 0006--%>
        <br />
        <div onclick="location.href='app_CorporatePack.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;" >
           <%-- <a href="app_CorporatePack.aspx">
                <img src="../../Images/BigIcons/add.png" alt="Add" />

            </a>--%>
        </div>


        <%--  <br />--%>
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
