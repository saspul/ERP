<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="flt_Duty_Roster_Report.aspx.cs" Inherits="AWMS_AWMS_Reports_flt_Duty_Roster_Report_flt_Duty_Roster_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style>
 input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
            cursor:default;
        }
        .searchlist_btn_rght {
        
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
          #ReportTable_filter input {
              height: 19px;
              width: 208px;
              color: #336B16;
              font-size: 14px;
              margin-bottom: 5%;
          }

        input[type="radio"] {
    display: block;
    float:left;
}
                         #divRadio {
    font-size: 15px;
    color: rgb(83, 101, 51);
    font-family: Calibri;
}
                             .Previous {
    background: url(/Images/BigIcons/Previous.png) no-repeat 0 0;
    width: 90px;
}
    </style>
      
    <script type="text/javascript">



        function getdetails(href) {
            window.location = href;
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
        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
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
    <script src="/JavaScript/JavaScriptPagination1.js"></script>                           <%--emp17--%>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
   <%-- <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
            });

        });


    </script>--%>
    <style>
        #cphMain_divReport {
            float: left;
            width: 98.5%;
        }

        #cphMain_divAdd {
            position: fixed;
            /*right: 4%;*/
            padding-left: 83.5%;
        }

        #TableRprtRow .tdT {
            line-height: 100%;
        }


        .cont_rght {
            width: 98%;
        }
    </style>
    <script type="text/javascript">

        function DisableDiv(mode) {

            if (mode == "RadioBtnEmply") {

                document.getElementById("divdatesearch").style.display = "none";
                document.getElementById("divemplysearch").style.display = "";
                document.getElementById("divoption").style.display = "";

            }
            else if (mode == "RadioBtnDate") {

                document.getElementById("divemplysearch").style.display = "none";
                document.getElementById("divoption").style.display = "none";

                document.getElementById("divdatesearch").style.display = "";
            }
        }









        function ConfirmMessage() {


            var x = document.getElementById("<%=HiddenFieldBack.ClientID%>").value;
            var y = x.split(',');
            var z = document.getElementById("<%=HiddenFieldBackIn.ClientID%>").value;
            window.location.href = "/AWMS/AWMS_Reports/flt_Duty_Roster_Report/flt_Duty_Roster_Report_EmpList.aspx?Id=" + z + "&fromdate=" + y[1] + "&todate=" + y[2];
        }

               </script>

      <script>

     
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    

    
    <asp:HiddenField ID="Hiddenstoretodate" runat="server" />     
    <asp:HiddenField ID="HiddenFieldBackIn" runat="server" />  
    <asp:HiddenField ID="HiddenFieldBack" runat="server" />    
    <asp:HiddenField ID="hiddenNext" runat="server" />
    <asp:HiddenField ID="hiddenPrevious" runat="server" />
    <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
    <asp:HiddenField ID="hiddenDate" runat="server" />
    <asp:HiddenField ID="hiddensysdate" runat="server" />
    <asp:HiddenField ID="hiddenMemorySize" runat="server" />    
    <asp:HiddenField ID="hiddenSearch" runat="server" Value="--SELECT ALL DIVISION--" />
    <asp:HiddenField ID="HiddenTYPE" runat="server" Value="--SELECT ALL TYPE--" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <asp:HiddenField ID="hiddenEmployee" runat="server" />
    <asp:HiddenField ID="hiddenOnDate" runat="server" />


    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
   <%-- <div style="cursor: default; float: right; height: 25px; margin-right:5.5%;margin-top:5%;font-family:Calibri;" class="print" onclick="printredirect()">            
                                 <a id="print_cap" target="_blank" data-title="Item Listing"  href="../Print/28_Print.htm" style="color:rgb(83, 101, 51)" >
                                <img src="../../../Images/Other%20Images/imgPrint.png" style="max-width: 45%">
                                 Print</a>                                    
                                </div>--%>

    <div id="divSuccessUpd" style="visibility: hidden">
        <asp:Label ID="lblSuccessUpd" runat="server"></asp:Label>
    </div>
    <div class="cont_rght">

         <div id="divList" class="Previous"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:0%; top:31%;height:26.5px;cursor:pointer"></div>


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="../../../Images/BigIcons/dutyrosterreport.png" style="vertical-align: middle;" />
           Duty Roster Report
        </div>
        
        <br />
   <div style="border-color: #9ba48b;background-color: #f3f3f3;width: 98.5%;margin-top:1%;">



            <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke;float:left">
            <div id="div1" style="width:100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;float:left">
                <asp:Label ID="lblEntry" runat="server">Job Details</asp:Label>
            </div>

            <div style="float: left; width: 80%;padding: 10px;margin-top: 2%;font-family:Calibri; border: 1px solid #929292;background-color: #c9c9c9;">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Employee Name:</h2>
                    <asp:Label ID="lblEmply" class="form1" runat="server"></asp:Label>
                </div>
                
            </div>
                     <%-- <div style="float:left;width: 8%;padding: 5px;background: white;margin-left: 4%;margin-top: 5%;">
                    <asp:Button ID="Btnsave" runat="server" class="save" Text="Save" OnClientClick="return getselected();" OnClick="Btnsave_Click"/>
                    <asp:Button ID="Btnconfirm" runat="server" class="save" Text="Confirm"   OnClientClick="return validateNotify();" />
                    <asp:Button ID="Btncancl" runat="server" class="save" Text="Clear" OnClientClick="return validateNotify();"  />
                     <asp:Button ID="Btnclr" runat="server" class="save" Text="Cancel" OnClientClick="return validateNotify();"  />
                --%>
                          <asp:HiddenField ID="HiddenreqstId" runat="server" />
                               <asp:HiddenField ID="HiddenShortlistMasterid" runat="server" />
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
    <div id="divtile" runat="server" style="display: none"></div>
      <div id="divPrintReport" runat="server" style="display: none">
                                    <br />
                                </div>
        <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
    </div>
</asp:Content>

