<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Sales.master" AutoEventWireup="true" CodeFile="Cmpzit_DashboardMailList.aspx.cs" Inherits="Home_Compzit_DashboardList_Cmpzit_DashboardMailList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style>
        input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
            cursor: default;
        }

        .searchlist_btn_rght {
            cursor: pointer;
            font-size: 13px;
            float: left;
        }

            .searchlist_btn_rght:hover {
                background: #7B866A;
            }

            .searchlist_btn_rght:focus {
                background: #7B866A;
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
            background: url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        }

        .searchlist_btn_lft:focus {
            background: url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        }
    </style>

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
                "bSort": false,
                "bInfo": false

            });
        });


    </script>



    <style>
        #cphMain_divReport {
            float: left;
            width: 98.5%;
        }

        #cphMain_divAdd {
            position: fixed;
            /*right: 4%;*/
            /*padding-left: 83.5%;*/
            right: 1%;
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <asp:HiddenField ID="hiddenNext" runat="server" />
    <asp:HiddenField ID="hiddenPrevious" runat="server" />
    <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
    <asp:HiddenField ID="hiddenMemorySize" runat="server" />



    <div id="divSuccessUpd" style="visibility: hidden">
        <asp:Label ID="lblSuccessUpd" runat="server"></asp:Label>
    </div>
    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="../../Images/BigIcons/Product-Master48x48.png" style="vertical-align: middle;" />
            <a>Unattended Mail List</a>
        </div>

        <br />




        <br />
        <table>
            <tr>
                <td style="width: 50%;">
                    <asp:Button ID="btnPrevious" Width="98%" runat="server" class="searchlist_btn_rght" Text="Show Previous 10 Records" OnClick="btnPrevious_Click" OnClientClick="SetHiddenSearchCriteria()" />
                </td>
                <td style="width: 50%;">

                    <asp:Button ID="btnNext" Width="98%" runat="server" class="searchlist_btn_rght" Text="Show Next 10 Records" OnClick="btnNext_Click" OnClientClick="SetHiddenSearchCriteria()" />
                </td>
            </tr>
        </table>


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
          </div>
       
</asp:Content>
