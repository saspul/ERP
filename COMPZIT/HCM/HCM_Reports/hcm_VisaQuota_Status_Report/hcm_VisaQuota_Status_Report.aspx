<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_VisaQuota_Status_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_VisaQuota_Status_Report_hcm_VisaQuota_Status_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
 <style>
        .cont_rght {
            width: 100%;
        }

    

</style>


<style>
    /*--------------------------------------------------for modal Bundle info------------------------------------------------------*/
         .modalInfoView {
             display: none; /* Hidden by default */
             position: fixed; /* Stay in place */
             z-index: 30; /* Sit on top */
             padding-top: 0%; /* Location of the box */
             left: 10%;
             top: 10%;
             width: 80%; /* Full width */
             height: 250px; /* Full height */
             /*overflow: auto;*/ /* Enable scroll if needed */
             background-color: transparent;
         }

         .modal-InfoView {
             /*position: relative;*/
             background-color: #fefefe;
             margin: auto;
             padding: 0;
             /*border: 1px solid #888;*/
             width: 95.6%;
             box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
         }


         /* The Close Button */
         .closeInfoView {
             color: white;
             float: right;
             font-size: 28px;
             font-weight: bold;
         }

             .closeInfoView:hover,
             .closeInfoView:focus {
                 color: #000;
                 text-decoration: none;
                 cursor: pointer;
             }

         .modal-headerInfoView {
             /*padding: 1% 1%;*/
            background-color: #91a172;
             color: white;
         }

         .modal-bodyInfoView {
             padding: 1% 4% 7% 4%;
         }

         .modal-footerInfoView {
             padding: 2% 1%;
           background-color: #91a172;
             color: white;
         }
            input[type="radio"] {
            display: block;
            float: left;
            font-family: Calibri;
        }
</style>
     <style>
        .subform label {
            float: right;
            color: #697259;
            font-size: 13pt;
            font-family: Calibri;
            cursor: pointer;
        }
    </style>
    <script src="/JavaScript/jquery-1.8.3.min.js"></script>

 <script type="text/javascript">

      var $noCon = jQuery.noConflict();
      $noCon(window).load(function () {
     
      <%--   document.getElementById("MymodalBundleInfo").style.display = "none";
        document.getElementById("freezelayer").style.display = "none";--%>
        

          document.getElementById("<%=divPrintCaptionDetails.ClientID%>").style.visibility = "hidden";
          var Hrid = document.getElementById("<%=HiddenHr.ClientID%>").value;

          var AllBunit = document.getElementById("<%=HiddenAllDivision.ClientID%>").value;
          
          if (AllBunit == 0)

              document.getElementById('divBunit').style.display = "none";

          else {
              document.getElementById('divBunit').style.display = "";
              
              //SearchValidation()
          }
      });

 

     function SearchValidation() {

         var ret = true;
         //selected();
         var AllBunit = document.getElementById("<%=HiddenAllDivision.ClientID%>").value;
         document.getElementById("<%=ddlBusUnit.ClientID%>").style.borderColor = "";
         document.getElementById("<%=ddlNation.ClientID%>").style.borderColor = "";
         var Nation = document.getElementById("<%=ddlNation.ClientID%>").value;
         if (AllBunit != 0)
         {
             //  document.getElementById('divMessageArea').style.display = "";
             var Bussunit = document.getElementById("<%=ddlBusUnit.ClientID%>").value;
           




             if (Bussunit == "--SELECT BUSINESS UNIT--") {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please select Business unit";
                 document.getElementById("<%=ddlBusUnit.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=ddlBusUnit.ClientID%>").focus();
                 
                 ret = false;
             }
             else if (Nation == "--SELECT NATION--") {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please select Nation";
                 document.getElementById("<%=ddlNation.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=ddlNation.ClientID%>").focus();

                 ret = false;

             }


         }
         if (Nation == "--SELECT NATION--") {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please select Nation";
                 document.getElementById("<%=ddlNation.ClientID%>").style.borderColor = "Red";
             document.getElementById("<%=ddlNation.ClientID%>").focus();

             ret = false;

         }
  
    return ret;


}

   

     function CloseVisaDetails() {
             document.getElementById('divMessageArea').style.display = "none";
             document.getElementById('imgMessageArea').src = "";
             document.getElementById("MymodalBundleInfo").style.display = "none";
             document.getElementById("freezelayer").style.display = "none";
        }
   function DetailsPrint() {

         //printing detail table
       
      
       var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
      
       var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;

       var Details = PageMethods.ManpwrDetailsPrint( CorpId, OrgId, function (response) {

           if (response[0] != "" && response[0] != null) {
               document.getElementById("<%=divPrintCaptionDetails.ClientID%>").innerHTML = response[0];
             }

             if (response[1] != "" && response[1] != null) {
                 document.getElementById("<%=lblPrintOnBrdDtls.ClientID%>").innerHTML = response[1];
              }

             if (response[2] != "" && response[2] != null) {
                 document.getElementById("<%=divPrintReportDetails.ClientID%>").innerHTML = response[2];
              }
       

                //var nWindow = window.open('/HCM/HCM_Reports/Print/49_print.htm');
            });

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
                "bSort": false,
                //"pageLength": 25,
                "bLengthChange": false,
                "bPaginate": false
            });
        });


        // for not allowing enter
        function DisableEnter(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
            else {
                return true;
            }
        }
  
        function CallCSVBtn() {
            document.getElementById("<%=BtnCSV.ClientID%>").click();

           }
        </script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
   <%-- EVM-0027--%>
      <asp:HiddenField ID="HiddenHr" runat="server" />
     <asp:HiddenField ID="HiddenAllDivision" runat="server" />
   <%-- END--%>
<asp:HiddenField ID="hiddenCorpId" runat="server" />
<asp:HiddenField ID="hiddenOrgId" runat="server" />
<asp:HiddenField ID="hiddenUserId" runat="server" />
<asp:HiddenField ID="HiddenBundleNo" runat="server" />
    <asp:HiddenField ID="HiddenProfession" runat="server" />
    <asp:HiddenField ID="HiddenNation" runat="server" />
    <asp:HiddenField ID="HiddenGender" runat="server" />
      <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:1.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A3"  data-title="Item Listing"  style="float: right; margin-top:1.9%;color:rgb(83, 101, 51);font-family:Calibri;/*! margin-right: 6.5%; */width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left: 41%;"><span style="margin-top: 2.7px; float: right;margin-right: 18%;">CSV</span> </a>
<div style="cursor: default; float: right; height: 25px; margin-right: -2.5%; margin-top: 2%; font-family: Calibri;" class="print" >
     <a id="print_cap" target="_blank" data-title="Visa Bundle" href="../Print/Common_print.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -28px; float: right;">Print</span></a>                                  
</div>

    <div id="divMessageArea" style="display: none " width:"91%;">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

<div class="cont_rght">
    
    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="\images\BigIcons\Visa Quota Status.png" style="vertical-align: middle;" />
     Visa Quota Status Report
        </div >

    <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;margin-top:1%;height:92px;padding: 1%;">
         <div id="divBunit" class="eachform" style="width: 31%; float: left;margin-top: 1%;">

                            <h2 >Business Unit*</h2>
                                                         
                                    <asp:DropDownList ID="ddlBusUnit" class="form1" runat="server" Style="height:30px;width:58.8%;float:left; margin-left: 7.8%;">
                   
                </asp:DropDownList>
                                                            
                                                         
                                                </div>
         <div id="div2" class="eachform" style="width: 31%; float: left;margin-top: 1%;">

                            <h2 >Bundle Number</h2>
                                                         
                                    <asp:DropDownList ID="ddlBundleNumber" class="form1" runat="server" Style="height:30px;width:58.8%;float:left; margin-left: 7.8%;">
                   
                </asp:DropDownList>
                                                            
                                                         
                                                </div>
        <div id="divAddtn" class="eachform" style="width: 33%; float: left;margin-top: 1%;margin-left: 3%;">

                            <h2 >Visa Profession</h2>
                                                         
                                    <asp:DropDownList ID="ddlVisTyp" class="form1" runat="server" Style="height:30px;width:58.8%;float:left; margin-left: 5.8%;">
                   
                </asp:DropDownList>
                                                            
                                                         
                                                </div>
         <div id="divNation" class="eachform" style="width: 30%; float: left;margin-top: 1%;">

                            <h2 >Nation*</h2>
                                                         
                                    <asp:DropDownList ID="ddlNation" class="form1" runat="server" Style="height:30px;width:60.8%;float:left; margin-left: 6%;">
                   
                </asp:DropDownList>
                                                            
                                                         
                                                </div>
              <div class="eachform" style="float:left;margin-left: 1%;height: 23px;margin-top: 1%;width:32%">
                <h2 >Gender</h2>
                
               
                   <div id="divRadioOther" class="subform" style="float: left;margin-left: 17%;">         
                   <asp:RadioButton  ID ="RadioButtonMale" style="float: left;margin-left: 7.8%;display:block" Text="Male" runat="server" Checked="true" GroupName ="RadioGender" /> 
                   <asp:RadioButton  ID ="RadioButtonFemale" style="float: left;margin-left: 2.8%;" Text="Female" runat="server"  GroupName ="RadioGender"/> 
                   
              
                  </div>             
              
            </div>
      <%--  <div style="float: left;width: 55%;border: 1px solid #9ba48b;height: 100%;">
        <h2 style="float: left;width: 22%;margin-top: 1%;margin-left: 39%;color: #536533;">Expiry Date : </h2>

         <div class="eachform" style="float: left;width: 50%;">
                <h2 style="margin-top: 2%;margin-left: 9%;">From Date</h2>
                
               <div id="divFrmDate" class="input-append date" style="float: left;width: 40%;margin-left: 6%;">
                        
                 <asp:TextBox ID="txtFromDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  Style="height:30px;width:77.6%;margin-top: 0%;float:left;margin-left: -2.3%;" onkeypress="return DisableEnter(event)"></asp:TextBox>

                        <input type="image"  id="Image1" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

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
                                endDate: new Date(),
                            });
                        </script>

                        <p style="visibility: hidden">Please enter</p>
                       </div>

            </div>
      

      <div class="eachform" style="float:left;width:50%;"">
                <h2 style="margin-top: 2%;">To Date</h2>
                
                 <div id="divToDate" class="input-append date" style="float:left;margin-left:15%;width: 46%;"">

                  <asp:TextBox ID="txtToDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  Style="height:30px;width:73.6%;margin-top: 0%;float:left;margin-left: 0%;" onkeypress="return DisableEnter(event)"></asp:TextBox>

                        <input type="image" id="Image2" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;"  />
                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divToDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                 startDate: new Date(),
                            });

                        </script>

                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div>
            </div>--%>
        <asp:Button ID="btnSearch" style="cursor:pointer;margin-right: 9%;margin-top: 1.5%;float:right;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClick="btnSearch_Click" OnClientClick="return SearchValidation()"/>

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

      <div id="divTitle" runat="server" style="display: none">
     Visa Quota Status Report
      </div>
          
     </div>

 <%--------------------------------View for Bundle informatn--------------------------%>

   

     <div id="divPrintCaptionDetails" class="table-responsive" runat="server" style="visibility:hidden;">
            </div>

     <label id="lblPrintOnBrdDtls" runat="server" style="float: left; cursor: inherit;visibility:hidden;" ></label>




     <div id="divPrintReportDetails" class="table-responsive" runat="server" style="visibility:hidden;">
         <br />
         <br />
         <br />
       </div>


   



    <style>
         #ReportTable_filter input {
         height: 22px;
         width: 200px;
         color: #336B16;
         font-size: 14px;
         margin-bottom:5px
     }
  
   
    .open > .dropdown-menu {
    display: none;
}
      </style>


</asp:Content>



