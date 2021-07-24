<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" CodeFile="hcm_Experiance_Certificate_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_Exit_Management_hcm_Experiance_Certificate_hcm_Experiance_Certificate_List" %>

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
         #ReportTable_filter input {
    height: 17px;
    width: 200px;
    color: #336B16;
    font-size: 14px;
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

            document.getElementById("<%=ddlEmployee.ClientID%>").focus();
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


        function DateChkSearch() {

            if (document.getElementById("<%=txtFromDate.ClientID%>").value != "" && document.getElementById("<%=txtToDate.ClientID%>").value != "") {
                var datepickerDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var datepickerDate = document.getElementById("<%=txtToDate.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                if (dateTxIss >= dateCompExp) {
                    document.getElementById("<%=txtToDate.ClientID%>").value = "";
                       alert("Sorry, leaving date should be greater than joining date !");
                   }
               }
               return false;

           }


        function SearchValidation() {
            ret = true;

            var CrdExpWithoutReplace = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtFromDate.ClientID%>").value = replaceCode2;

            var CrdExpWithoutReplace = document.getElementById("<%=txtToDate.ClientID%>").value;
            var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtToDate.ClientID%>").value = replaceCode2;

            var FromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value;


         

            if (cbxStatus.checked) {
                cbx = 1;
            }
            else {
                cbx = 0;
            }

            if (ret == true) {

                document.getElementById("<%=HiddenSearchField.ClientID%>").value = FromDate + ',' + ToDate ;
            }


            return ret;

        }
        function getdetails(href) {
            window.location = href;
            return false;
        }

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
     <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
        <asp:HiddenField ID="HiddenSearchField" runat="server" />
    

   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="/Images/BigIcons/Experience_Certificate.png" style="vertical-align: middle;" />
     Experience Certificate Generation
        </div >
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 93.5%;margin-top:0.5%;height:10%;">

  
            <div style="width:100%;float:left;margin-top:14px">
                 
                        <div class="eachform" style="width: 27%;margin-top:0.5%;margin-left:2%;float: left;">

                <h2 style="margin-top:1%;">Employee</h2>

                <asp:DropDownList ID="ddlEmployee"   class="form1" runat="server" Style="height:25px;width:160px;height:25px;width:69%;float:left; margin-left: 8%;">
             
      
                </asp:DropDownList>


            </div> 
     

         <div class="eachform" style="float: left;width: 29%;">
                <h2 style="margin-top: 2%;margin-left: 9%;">Joining Date</h2>
                
               <div id="divFrmDate" class="input-append date" style="float: left;width: 40%;margin-left: 6%;">
                        
                 <asp:TextBox ID="txtFromDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onblur="DateChkSearch()" Style="height:30px;width:77.6%;margin-top: 0%;float:left;margin-left: -2.3%;" onkeypress="return DisableEnter(event)"></asp:TextBox>

                        <input type="image" onblur="DateChkSearch()" id="Image1" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

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
                            $noC('#divFrmDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                               // endDate: new Date(),
                            });
                        </script>

                        <p style="visibility: hidden">Please enter</p>
                       </div>

            </div>
      

      <div class="eachform" style="float:left;width:27%;"">
                <h2 style="margin-top: 2%;">Leaving Date</h2>
                
                 <div id="divToDate" class="input-append date" style="float:left;margin-left:7%;width: 46%;"">

                  <asp:TextBox ID="txtToDate" class="form1" onblur="DateChkSearch()" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  Style="height:30px;width:73.6%;margin-top: 0%;float:left;margin-left: 0%;" onkeypress="return DisableEnter(event)"></asp:TextBox>

                        <input type="image" onblur="DateChkSearch()" id="Image2" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;"  />
                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divToDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                               // startDate: new Date(),
                            });

                        </script>

                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div>
            
             
                   <div class="eachform" style="width:14%;float: left;">
                <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: 2.6%;margin-left: 10%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />
                     </div>
                </div>
             
            <br style="clear: both" />
            </div>
        <br />
          <div onclick="location.href='hcm_Experiance_Certificate.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;">

          <%--  <a href="gen_Projects.aspx">
                <img src="../../Images/BigIcons/add.png" alt="Add" />
            </a>--%>
        </div>

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
        <style>
           

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