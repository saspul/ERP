<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="flt_Traffic_Violation_Report.aspx.cs" Inherits="AWMS_AWMS_Reports_flt_Traffic_Violation_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/JavaScript/multiselect/jQuery/jquery-3.1.1.min.js"></script>
<link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
<script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
<link href="/JavaScript/multiselect/AdminLTE.min.css" rel="stylesheet" />
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

    </style>
      <script>
          
                   function addCommasSummry(nStr) {
                       nStr += '';
                       var x = nStr.split('.');
                       var x1 = x[0];
                       var x2 = x[1];

                       if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "1") {
                           var rgx = /(\d+)(\d{7})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }
                           rgx = /(\d+)(\d{5})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }
                           rgx = /(\d+)(\d{3})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }
                       }

                       if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "2") {
                           var rgx = /(\d+)(\d{9})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }

                           rgx = /(\d+)(\d{6})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }
                           rgx = /(\d+)(\d{5})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }
                           rgx = /(\d+)(\d{3})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }
                       }
                       if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "3") {
                           var rgx = /(\d+)(\d{9})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }
                           rgx = /(\d+)(\d{6})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }
                           rgx = /(\d+)(\d{3})/;
                           if (rgx.test(x1)) {
                               x1 = x1.replace(rgx, '$1' + ',' + '$2');
                           }
                       }

                      // if (isNaN(x2))
                           
                           //return x1;
                     //  else
                   
                      

                   }


    </script>
    <script type="text/javascript">

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            //   alert();
            document.getElementById("cphMain_radioemploye").focus();
            $("#cphMain_ddlEmployee").select2("val", "");
            $("#cphMain_ddlvechcle").select2("val", "");

            if (document.getElementById("<%=hiddenselectedlist.ClientID%>").value != "") {
                //alert();
                $noCon2("#cphMain_ddlEmployee").val(document.getElementById("<%=hiddenselectedlist.ClientID%>").value).trigger("change");
               // alert();
            }
            //var tokens = hiddenselectedlist.Value.Split(',');
            //  foreach (ListItem itemCheckBoxModules in cblcandidatelist.Items)
            // {
           // alert(tokens);
            //for (int i = 0; i < tokens.Count() ; i++)
            //{
                  

                // alert();
            //$noCon2("#cphMain_ddlEmployee").select2({
            //    placeholder: "Select a customer",

            //});
            //$noCon2("#cphMain_ddlvechcle").select2({
            //    placeholder: "Select a customer",

            //});
         
        });

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
                       <%--emp17--%>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>
    <script src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
    <script src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
            <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                                    <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
     <script>
         var $p = jQuery.noConflict();
         $p(document).ready(function () {
         //    $p('#ReportTable').DataTable({
         //        "pagingType": "full_numbers",
         //        "bSort": false,
         //        "pageLength": 25,
         //          "bDestroy": true

         //    });
            // alert("dd");
             //if (document.getElementById("<%=hiddenselectedlist.ClientID%>").value != "") {
                // if (document.getElementById("<%=hiddenselectedlist.ClientID%>").value != "") {
          
                 //var vakues = $noCon2('#cphMain_hiddenselectedue.list').val();
                // alert(vakues);
                 //$noCon2("#cphMain_ddlEmployee").val(vakues);
             //   alert();
             //  }
             //alert();
           //  $noC('#cphMain_ddlEmployee').focus();
             var type = document.getElementById("<%=hiddensearchby.ClientID%>").value;

             var data = document.getElementById("<%=hiddenselectedlist.ClientID%>").value;
             var totalString = data;
           var  eachString = totalString.split(',');
             var newVar = new Array();
             for (count = 0; count < eachString.length; count++) {
                 if (eachString[count] != "") {
                     newVar.push(eachString[count]);
                     //alert(newVar);
                 }
             }
             if (type == "Employee") {
                 $noC('#cphMain_ddlEmployee').val(newVar);
                 $noC("#cphMain_ddlEmployee").trigger("change");
            
             }
             else {
                 $noC('#cphMain_ddlvechcle').val(newVar);
                 $noC("#cphMain_ddlvechcle").trigger("change");
             }

             //evm-0023 changed focus on employee-vehicle radio button
             if (document.getElementById("<%=radioemploye.ClientID%>").checked == true) {

                 // document.getElementById("<%=ddlEmployee.ClientID%>").focus();
                }
             else {
                // document.getElementById("<%=ddlvechcle.ClientID%>").focus();

             }

             document.getElementById("<%=radioemploye.ClientID%>").focus();
                     });
         

         function checkselecteed()
         {
         
             if (document.getElementById("<%=radioemploye.ClientID%>").checked == true) {
                 ShowOrHideDdl("Employee");
             }
             else {
                 ShowOrHideDdl("vehicle");

             }

         }

             // var modeText = modeDdl.options[modeDdl.selectedIndex].text;
             // if (modeText == "Custom period") {
             //  document.getElementById("<%=divDateTime.ClientID%>").style.visibility = "visible";

             //  if (document.getElementById("<%=hiddenDate.ClientID%>").value == " ") {
             //   document.getElementById('cphMain_txtToDate').value = $.datetimepickerTo.formatDate('dd-MM-yyyy', new Date());;
             // }
             // else {
            // document.getElementById('cphMain_txtToDate').value = document.getElementById("<%=hiddenDate.ClientID%>").value;
             // }
             //   }
             //  else {
             //       document.getElementById("<%=divDateTime.ClientID%>").style.visibility = "hidden";
             // document.getElementById("<%=hiddenDate.ClientID%>").value = null;


             // }

             // });


         </script>
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

        
                input[type="radio"] {
    display: block;
    float:left;
}

    </style>
    <!-- Page script -->

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    
    <asp:HiddenField ID="Hiddenstoretodate" runat="server" />     <%--   emp17--%>
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
          <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <asp:HiddenField ID="hiddenNext" runat="server" />
    <asp:HiddenField ID="hiddenPrevious" runat="server" />
    <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
    <asp:HiddenField ID="hiddenDate" runat="server" />
    <asp:HiddenField ID="hiddensysdate" runat="server" />
    <asp:HiddenField ID="hiddenMemorySize" runat="server" />    
    <asp:HiddenField ID="hiddenSearch" runat="server" Value="--SELECT ALL DIVISION--" />
        <asp:HiddenField ID="HiddenTYPE" runat="server" Value="--SELECT ALL TYPE--" />
       <asp:HiddenField ID="hiddenSelectdNo" runat="server" />
           <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
      <asp:HiddenField ID="Hiddenselectedtext" runat="server" />

    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
    <div style="cursor: default; float: right; height: 25px; margin-right:5.5%;margin-top:5%;font-family:Calibri;" class="print" onclick="printredirect()">            
                                 <a id="print_cap"  target="_blank" data-title="Item Listing"  href="../../../Reports/Print/48_Print.htm" style="color:rgb(83, 101, 51)" >
                                <img src="../../../Images/Other%20Images/imgPrint.png" style="max-width: 45%">
                                 Print</a>                                    
                                </div>

    <div id="divSuccessUpd" style="visibility: hidden">
        <asp:Label ID="lblSuccessUpd" runat="server"></asp:Label>
    </div>
    <div class="cont_rght">




        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="../../../Images/BigIcons/traffic violationreport.png" style="vertical-align: middle;" />
           Traffic Violation Report
        </div>
         
        <br />
   
                <div style="border:1px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 98.3%;margin-top:1%;">

     

       

              


                <div id="div3" class="eachform" style="padding: 1%;margin-left: 1%;width: 20%; float: Left;border:1px solid;border-color: #9ba48b;margin-top: 1%;">
                      <div style="float:left;margin-left: 14%">
                          <%--evm-0023 tabindex removed(8 tab index removed)--%>
                   <asp:RadioButton  ID ="radioemploye" Text="Employee"   runat="server" onclick="ShowOrHideDdl('Employee');" onkeypress="return DisableEnter(event)" GroupName ="RadioGroup2"/> 
                   </div> 
                    <div style="float:left;margin-left: 1%">
                   <asp:RadioButton  ID ="radiovechcle" Text="Vehicle"   runat="server" onclick="ShowOrHideDdl('Vehicle');" onkeypress="return DisableEnter(event)" GroupName ="RadioGroup2"/> 
                  
                        
                           </div> 
                   
                       <div id="ddlEmployee1" style="width:100%;float:left;margin-left: 4%;">
                      <asp:DropDownList ID="ddlEmployee"   class="form-control select2" multiple="multiple" data-placeholder="Select an Employee*" Style="margin-left: 2%;width: 92%;margin-top: 4%;display:block;float: left; margin-right: 14%;" runat="server" >
                    </asp:DropDownList>
                               </div>
                           <div id="ddlvechcle1" style="width:100%;float:left;margin-left: 4%;">
                       <asp:DropDownList ID="ddlvechcle"  class="form-control select2" multiple="multiple" data-placeholder="Select a Vehicle*" Style="margin-left: 2%;width: 92%;margin-top: 4%;display:block;float: left; margin-right: 14%;" runat="server" >
               
                        <%--<asp:DropDownList ID="ddlvechcle"  tabindex="2" class="form1" Style="margin-left: 2%;width: 45%;margin-top: 4%;display:block;float: left; margin-right: 14%;" runat="server" >--%>
                    </asp:DropDownList>
                  </div>
                  </div>


                  
               
        



                
            <div id="divoption" class="eachform" style="width:26%;border:1px solid;border-color: #9ba48b;float:left;margin-top:1%;height: 54px;margin-left: 1%;padding: 1%;" runat="server">               
               
                
                
                
                 <div id="divDateTime" runat="server" class="subform"  style="width: 99%; float: left; margin-top: -2%; ">


                                       
                           <div id="datetimepickerTo" class="input-append date" style=style="font-family: Calibri; width: 98%; height: 47px; float: left; /*! margin-right: 48%; */ margin-top: 0%;"    >
                                <span style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri; margin-left: 0%;float: left;">  From Date</span>
                                <div style="float:left; width:63%;margin-left: 10%;">
                                    <asp:TextBox ID="txtfromdate"    runat="server" class="form1" placeholder="DD-MM-YYYY" style="width: 75%;  font-family: calibri; float:left;height:30px; font-size:15px;" type="text"></asp:TextBox>
                                <%--<input id="fromdate" name="ctl00$cphMain$txtToDate" maxlength="20"  runat="server" class="form1" placeholder="DD-MM-YYYY" onkeydown="return isNumberDate(event);" style="width: 75%;  font-family: calibri; float: left;height:30px; font-size:15px;" type="text">--%>                                                                    
                                    <img class="add-on" src="/Images/Icons/CalandarIcon.png" style="height: 22px; float:left;/*! margin-left:280%; *//*! margin-bottom:20%; */ cursor:pointer">

                           
                                <script type="text/javascript">
                                    var $noC = jQuery.noConflict();
                                    $noC('#datetimepickerTo').datetimepicker({
                                        format: 'dd-MM-yyyy',
                                        language: 'en',
                                        pickTime: false,

                                    

                                    });
                    
                                </script>
                            &nbsp;</div>
                               </div>   
                  </div>
                <div id="div1" runat="server" class="subform"  style="width: 99%; float: left; margin-top: 1%; ">


                                       
                           <div id="datetimepickerfrom" class="input-append date" style="font-family: Calibri; width: 98%; height: 47px; float: left; /*! margin-right: 48%; */ margin-top: 0%;"    >
                                <span style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri; margin-left: 0%;float: left;">To Date</span>
                                <div style="float:left; width:71%;margin-left: 10%;">
                                    <asp:TextBox ID="txttodate" runat="server"   placeholder="DD-MM-YYYY" class="form1" onkeydown="return isNumberDate(event);" style="width: 68.2%;  font-family: calibri; float: left;height:30px; font-size:15px;margin-left: 9%;" type="text"></asp:TextBox>
                                <%--<input id="todate" name="ctl00$cphMain$txtToDate" maxlength="20"  class="form1" runat="server" placeholder="DD-MM-YYYY" onkeydown="return isNumberDate(event);" style="width: 75%;  font-family: calibri; float: left;height:30px; font-size:15px;" type="text">--%>                                                                    
                                    <img class="add-on" src="/Images/Icons/CalandarIcon.png" style="height: 22px; float:right;/*! margin-left:280%; *//*! margin-bottom:20%; */ cursor:pointer">
                                   
                                <script type="text/javascript">
                                    var $noC = jQuery.noConflict();
                                    $noC('#datetimepickerfrom').datetimepicker({
                                        format: 'dd-MM-yyyy',
                                        language: 'en',
                                        pickTime: false,

                                    

                                    });
                   

                                </script>

                                        <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                                    <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                              
                            &nbsp;</div>
                               </div>   
                  </div>
                </div>
               
          
        <div class="eachform" style="width: 29%;margin-top:2%;margin-bottom: 0%;margin-left: 2%;">

                <h2 style="margin-top:1%;">Status</h2>

                       <asp:DropDownList ID="ddlStatus" class="form1"   style="height:25px;width:53.3%;margin-left: 9.0%;float:left;display:block" onchange="Disablediv1();"  runat="server"  AutoPostBack="true">                <%--emp17--%>
<%--<asp:ListItem Value="0" Text="--SELECT--">--%>
<asp:ListItem Value="2" Text="--SELECT--">
</asp:ListItem><asp:ListItem Value="1" Text="SETTLED">
</asp:ListItem><asp:ListItem Value="0" Text="NOT SETTLED">
</asp:ListItem>
                </asp:DropDownList>
                <script type="text/javascript">

                    function ShowOrHideDdl(modeText) {


                        if (modeText == "Employee") {
                            $noCon2('#cphMain_ddlEmployee').val('');
                            document.getElementById("ddlEmployee1").style.display = "";
                            document.getElementById("ddlvechcle1").style.display = "none";
                            $noCon2("#cphMain_ddlEmployee option:selected").prop("selected", false);
                          //  $noCon2("#cphMain_ddlEmployee").select2("val", "");
                            $noCon2("#cphMain_ddlEmployee").val('').trigger("change");
                           // alert();

                        }
                        else {
                            // document.getElementById("ddlvechcle").innerText = "--SELECT VEHICLE--";

                            document.getElementById("ddlEmployee1").style.display = "none";
                            document.getElementById("ddlvechcle1").style.display = "block";
                            $noCon2("#cphMain_ddlvechcle").val('').trigger("change");
                          //  document.getElementById("ddlvechcle1").style.display = "block";
                        }
                        //$noCon2("#cphMain_ddlEmployee").select2({
                        //    placeholder: "Select a customer",
                      
                        //});
                        //$noCon2("#cphMain_ddlvechcle").select2({
                        //    placeholder: "Select a customer",

                        //});
                    }

               </script>

            </div>
                
                     <div class="eachform" style="width:0%;float: right;margin-top: 2%;margin-right: 14%;">
                <asp:Button ID="btnsearch"   style="cursor:pointer;margin-top: -0.4%; margin-top: 13.6%; margin-left: 63%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return selected();" OnClick ="btnsearch_Click"   />
                     </div>
            <br style="clear: both" />
            </div>
        <asp:HiddenField ID="hiddenselectedlist" runat="server" />       
         <asp:HiddenField ID="hiddensearchby" runat="server" />
        <br />

<%--        <div class="eachform" style="width: 66%; float: right;">
            
            <asp:Button ID="btnSearch" style="cursor:pointer; padding: 3px 19px 3px 38px;margin-top: -0.4%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClick="btnSearch_Click" OnClientClick="return SearchValidation();" />

        </div>--%>

        <br />
         <asp:Label ID="lblNumRec" runat="server" style="font-family: Calibri;font-size: 17px;color: rgb(83, 101, 51);"></asp:Label>
      <%--  <table>
            <tr>
                <td style="width:50%;">
                    <asp:Button ID="btnPrevious"   Width="98%" runat="server" class="searchlist_btn_rght" Text="Show Previous 500 Records"  Visible="false" />
                </td>
                <td style="width:50%;">

                    <asp:Button ID="btnNext" Width="98%"  runat="server" Visible="false" class="searchlist_btn_rght" Text="Show Next 500 Records"/>
                </td>
            </tr>
        </table>
         --%>
       
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
        <style>
            #ReportTable_filter input {
    height: 16px;
    width: 200px;
    color: #336B16;
    font-size: 14px;

}

 .cont_rght {
    width: 102%;
}
        </style>
         <div id="divPrintReport" runat="server" style="display: none">
                                    <br />
                                </div>
        <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
    </div>
   </div>

    <script>
        $noCon = jQuery.noConflict();
        $noCon2 = jQuery.noConflict();
        $noCon(function () {
            //Initialize Select2 Elements
            $noCon2(".select2").select2();


        });
</script>
        <script>
           
            function selected() {
                var a; var sel = "";
                //  alert($noCon2('#cphMain_ddlEmployee').val());
                if (document.getElementById("<%=radioemploye.ClientID%>").checked == true)
                {
                    a = $noCon2('#cphMain_ddlEmployee').val();
                    document.getElementById("<%=hiddensearchby.ClientID%>").value = "Employee";
                    $noCon2("#cphMain_ddlEmployee option:selected").each(function () {
                        var $noCon2this = $noCon2(this);
                        if ($noCon2this.length) {
                            var selText = $noCon2this.text();
                            sel = sel + selText + ",";

                            document.getElementById("<%=Hiddenselectedtext.ClientID%>").value = sel;
                          //  alert(sel);
                       }
                     });

                }
                else
                {
                    a = $noCon2('#cphMain_ddlvechcle').val();

                    document.getElementById("<%=hiddensearchby.ClientID%>").value = "vechcle";
                    $noCon2("#cphMain_ddlvechcle option:selected").each(function () {
                        var $noCon2this = $noCon2(this);
                        if ($noCon2this.length) {
                            var selText = $noCon2this.text();
                            sel = sel + selText + ",";

                            document.getElementById("<%=Hiddenselectedtext.ClientID%>").value = sel;
                           // alert(sel);
                        }
                     });
           
                }
                //alert(a);
                document.getElementById("<%=hiddenselectedlist.ClientID%>").value = a;
                //alert();
              // alert(hiddenselectedlist.value);
              return  searchvalidate();
                //return true;
            }
            function searchvalidate()
            {
                var ret = true;
                var frmdatefld = document.getElementById("<%=txtfromdate.ClientID%>").value.trim();
                var searchitm = document.getElementById("<%=hiddenselectedlist.ClientID%>").value.trim();
                var searchby = document.getElementById("<%=hiddensearchby.ClientID%>").value.trim();

                var frmdate = document.getElementById("<%=txtfromdate.ClientID%>").value.trim();
                var arrDatePickerDate1 = frmdate.split("-");
                frmdate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
                var todate = document.getElementById("<%=txttodate.ClientID%>").value.trim();
                var arrDatePickerDate1 = todate.split("-");
                todate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
                if (searchitm == "")
                {
                    if (searchby == "Employee") {
                        document.getElementById("div3").style.borderColor = "Red";
                        document.getElementById("<%=ddlEmployee.ClientID%>").focus();
                    }
                    document.getElementById("<%=ddlvechcle.ClientID%>").focus();
                  
                    document.getElementById("div3").style.borderColor = "Red";
                    ret = false;
                }
                   
                    //  document.getElementById('divMessageArea').style.display = "";
                   // document.getElementById("<%=lblSuccessUpd.ClientID%>").innerHTML = "Sorry,request date cannot be greater than Rrquired date !.";
                    //  alert("ss");
               
                
                if (frmdate > todate) { //3emp17
                
                    document.getElementById("<%=txtfromdate.ClientID%>").style.borderColor = "Red";
                 
                   document.getElementById("<%=txttodate.ClientID%>").focus();
                 //  document.getElementById('divMessageArea').style.display = "";
                   document.getElementById("<%=lblSuccessUpd.ClientID%>").innerHTML = "Sorry,request date cannot be greater than Rrquired date !.";
                  //  alert("ss");
                    ret = false;
                   
              }
                return ret;
            }
    </script>
    <style>
        
        #tblOnBoardMult > tbody > tr:nth-child(2n+1) > td, .main_table > tbody > tr:nth-child(2n+1) > th {
            height: 30px;
            background: #DDD;
            font-size: 14px;
            color: #5c5c5e;
        }

        #tblOnBoardMult > tbody > tr:nth-child(2n) > td, .main_table > tbody > tr:nth-child(2n) > th {
            height: 30px;
            background: #C2C2C2;
            font-size: 14px;
            color: #000;
        }

        .select2-container--default .select2-selection--multiple .select2-selection__choice {
            background-color: #a5a5a5;
            border-color: #8d8d8d;
            padding: 1px 5px;
            color: #fff;
            font-size: 14px;
            margin: 2px;
            max-width: 260px;
        }
        .select2-container--default .select2-selection--multiple .select2-selection__choice__remove {
    color: #fff;
    cursor: pointer;
    display: inline-block;
    font-weight: bold;
    margin-right: 5px;
}

        .select2-container--default.select2-container--focus .select2-selection--multiple {
    border: solid #aeaeae 1px;
    outline: 0;
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
    </script>
</asp:Content>









