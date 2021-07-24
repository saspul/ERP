<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Immigration_tasks_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_Immigration_tasks_Report_hcm_Immigration_tasks_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
  
      
     
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

                  font-size: 14px;
    border: solid #aeaeae 1px;
    outline: 0;
}
       .select2-results__options {
    list-style: none;
    margin: 0;
    padding: 0;
    font-size: 14px;
}
    </style>

<style>
        .cont_rght {
            width: 98%;
        }
        .col-md-4 {

    width: 32.333%;

}
    /*--------------------------------------------------for modal ManPower Requirement info------------------------------------------------------*/
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
             padding: 4% 4% 7% 4%;
         }

         .modal-footerInfoView {
             padding: 1% 1%;
           background-color: #91a172;
             color: white;
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

        #ReportTable_filter input {
            height: 19px;
            width: 208px;
            color: #336B16;
            font-size: 14px;
            margin-bottom: 5%;
        }

        input[type="radio"] {
            display: block;
            float: left;
        }

        #divRadio {
            font-size: 15px;
            color: rgb(83, 101, 51);
            font-family: Calibri;
        }
    </style>

 <script src="/JavaScript/jquery-1.8.3.min.js"></script>

 <script type="text/javascript">

     var $noCon = jQuery.noConflict();
     $noCon(window).load(function () {

    
         document.getElementById("<%=divPrintCaptionDetails.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=lblPrintOnBrdDtls.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=divPrintReportDetails.ClientID%>").style.visibility = "hidden";
 

     });
     


     function printsorted() {
         document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
      //   $('#cphMain_divPrintReportSorted table tr').find('td:eq(4),th:eq(4)').remove();
     }


     //function SearchValidation() {

     //    return true;
     //}
     function DetailsPrint() {

         //printing detail table

         var ManpwrId = document.getElementById("<%=hiddenManpwrId.ClientID%>").value;
         var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
         var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;

         var Details = PageMethods.ManpwrDetailsPrint(ManpwrId, CorpId, OrgId, function (response) {

             if (response[0] != "" && response[0] != null) {
                 document.getElementById("<%=divPrintCaptionDetails.ClientID%>").innerHTML = response[0];
             }

              if (response[1] != "" && response[1] != null) {
                  document.getElementById("<%=lblPrintOnBrdDtls.ClientID%>").innerHTML = response[1];
             }

              if (response[2] != "" && response[2] != null) {
                  document.getElementById("<%=divPrintReportDetails.ClientID%>").innerHTML = response[2];
             }

          });


     }

     function CloseManPowerRequiremtDetails() {
         document.getElementById('divMessageArea').style.display = "none";
         document.getElementById('imgMessageArea').src = "";
         document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
         document.getElementById("MymodalBundleInfo").style.display = "none";
         document.getElementById("freezelayer").style.display = "none";
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
                 // "pageLength": 25,
                  "bDestroy": true,
                  "bLengthChange": false,
                  "bPaginate": false
              });

          });

     </script>

     <%-- <script src="/JavaScript/multiselect/jQuery/jquery-3.1.1.min.js"></script>--%>
      <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
<link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
<script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
<link href="/JavaScript/multiselect/AdminLTE.min.css" rel="stylesheet" />
    
   
     <script>
         //var $au = jQuery.noConflict();
         //(function ($au) {
         //    $au(function () {
         //        $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
         //        $au('form').submit(function () {
         //        });
         //    });
         //})(jQuery);
         var $noCon = jQuery.noConflict();
         $noCon2 = jQuery.noConflict();
         $noCon(function () {
             // LoadEmpList();
             $noCon2(".select2").select2();


             var data = document.getElementById("<%=hiddenselectedlist.ClientID%>").value;
            var totalString = data;
            var eachString = totalString.split(',');
            var newVar = new Array();
            for (count = 0; count < eachString.length; count++) {
                if (eachString[count] != "") {
                    newVar.push(eachString[count]);
                    //alert(newVar);
                }
            }

            $noCon2('#cphMain_ddlCandidate').val(newVar);
            $noCon2("#cphMain_ddlCandidate").trigger("change");



        });


        function selected() {
       
            var a;
            var sel = "";


            a = $noCon2('#cphMain_ddlCandidate').val();
            $noCon2("#cphMain_ddlCandidate option:selected").each(function () {
                var $noCon2this = $noCon2(this);
               
                if ($noCon2this.length) {
                    var selText = $noCon2this.text();
                    sel = sel + selText + ",";

                    document.getElementById("<%=Hiddenselectedtext.ClientID%>").value = sel;
                    
                }
            });
            document.getElementById("<%=hiddensearchby.ClientID%>").value = "Candidate";
            document.getElementById("<%=hiddenselectedlist.ClientID%>").value = a;
           // alert(  document.getElementById("<%=hiddenselectedlist.ClientID%>").value );
            return true;
        }
</script>

    <script>
        $noCon = jQuery.noConflict();
        $noCon2 = jQuery.noConflict();
        $noCon(function () {
            //Initialize Select2 Elements
            $noCon2(".select2").select2();

            //  checkclickedradio();
            document.getElementById("<%=ddlCandidate.ClientID%>").style.borderColor = "";


          });



          </script>

    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

    <script>

        
    var $au = jQuery.noConflict();
           (function ($au) {
               $au(function () {
                   var prm = Sys.WebForms.PageRequestManager.getInstance();
                   //  prm.add_initializeRequest(InitializeRequest);
                   prm.add_endRequest(EndRequest);
                   
                 // $au('#cphMain_ddlRound').selectToAutocomplete1Letter();
                  $au('#cphMain_ddlProject').selectToAutocomplete1Letter();
                   $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
                   $au('form').submit(function () {
                   });
               });
           })(jQuery);


           function EndRequest(sender, args) {
               // after update occur on UpdatePanel re-init the Autocomplete
            //  $au('#cphMain_ddlRound').selectToAutocomplete1Letter();
             $au('#cphMain_ddlProject').selectToAutocomplete1Letter();
               $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
               //$p('#ReportTable').DataTable({
               //    "pagingType": "full_numbers",
               //    "bSort": true,
               //    "pageLength": 25,
               //    "bDestroy": true
               //});

          }



        
           function SearchValidation() {

               var ret = true;
          selected();
              
                 return ret;


           }
         
           function CallCSVBtn() {
               document.getElementById("<%=BtnCSV.ClientID%>").click();

          }
         
        
           
    </script>





</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

<asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenCorpId" runat="server" />
    <asp:HiddenField ID="hiddenOrgId" runat="server" />
    <asp:HiddenField ID="hiddenManpwrId" runat="server" />
        <asp:HiddenField ID="Hiddenselectedtext" runat="server" />
    <asp:HiddenField ID="hiddensearchby" runat="server" />
       <asp:HiddenField ID="hiddenselectedlist" runat="server" />
     <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:1.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A3"  data-title="Item Listing"  style="float: right; margin-top:3.4%;color:rgb(83, 101, 51);font-family:Calibri;/*! margin-right: 6.5%; */width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left: 50%;" ><span style="margin-top: 3%;float: right;margin-right: 6%;">CSV</span></a>
        <div style="cursor: default; float: right; height: 25px; margin-right: -3.5%; margin-top: 3.5%; font-family: Calibri;" class="print" onclick="printsorted()">
     <a id="A1" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/sort_EmpDtlsRprt.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -28px; float: right;">Print</span></a>                                  
</div>
    <div style="display:none;cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 3.5%; font-family: Calibri;" class="print">
     <a id="print_cap" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/Common_print.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -28px; float: right;">Print</span></a>                                  
</div>


    <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght" style="min-height: 256px;">
    
    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="\Images\BigIcons\Immigration Tasks Report.png" style="vertical-align: middle;" />
    Immigration Task Report
        </div >

        <%--  <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
   <ContentTemplate>--%>
      
    <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;width: 100%;margin-top:3%;height:auto;margin-bottom: 2%;">
          
         <div class="row">
 <br />
     
     <div class="col-md-4" style="float: left;margin-left: 1%;width: 37%;">
        <%--<div style="margin-top:2.5%;margin-left:5%">--%>
         <h2 >Immigration Round   </h2>
         <div id="divddlRound">
        <asp:DropDownList ID="ddlRound" class="form1" runat="server" Style="height: 28px;  width: 56%; float: right;"  >
           </asp:DropDownList></div>
        <%--</div>--%>
 </div>

       <div class="col-sm-4">
           <%--<div  style="margin-top: 2.5%; margin-left: 8%">--%>
           <h2 style="width: 26%;margin-left: 3%;">Candidate </h2>

           <asp:DropDownList ID="ddlCandidate" class="form-control select2" multiple="multiple" onchange="return selected()"  data-placeholder="Select a Candidate"  Style="height: 25px; width: 68%; margin-left: 8%; margin-top: 0%; float: right; margin-bottom: 2%;font-size:14px" runat="server" >
                        </asp:DropDownList>
           <%--</div>--%>
       </div>
      <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>

  <div class="col-sm-4" style="width: 26%;">
      <%--<div  style="margin-top:2.5%;margin-left:10%">--%>
       
         <h2>Project </h2>
    
        <asp:DropDownList ID="ddlProject" class="form1" runat="server" Style="height: 28px; width: 62%;">
           </asp:DropDownList>
        <%--</div>--%>

         </div>
            
            
  </div>

<%--        <asp:UpdatePanel EnableViewState="true" UpdateMode="Conditional" runat="server">
   <ContentTemplate>
    
        <div style="margin-top:2.5%;margin-left:5%">
         <h2 >Department  * </h2>
        <asp:DropDownList ID="ddlDepartmnt" class="form1" runat="server" Style="height: 28px; width: 20%; float: left; margin-left: 2%;" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartmnt_SelectedIndexChanged">
           </asp:DropDownList>
        </div>--%>
            <%--//Evm -27--%>

        <%--<div  style="margin-top: 2.5%; margin-left: 8%">
            <h2 style="margin-left: 2%;">Division </h2>
            <asp:DropDownList ID="ddlDivision" class="form1" runat="server" Style="height: 28px; width: 20%; float: left; margin-left: 2%;">
            </asp:DropDownList>
        </div>
      --%>
        <br />
         <div class="row">
  <div class="col-sm-4" style="float: left;margin-left: 1%;width: 40%; "  >

   
         <h2>Assigned To  </h2>
        <asp:DropDownList ID="ddlEmployee" class="form1" runat="server" Style="height: 28px; margin-top:1.5%; width: 48%; float: left; margin-left: 18%;">
           </asp:DropDownList>  

  </div>
  
           
             <asp:Button ID="btnSearch" Style="cursor: pointer; float: right; margin-right: 5%; margin-top: 1%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation()" OnClick="btnSearch_Click" />
 
    
    <%--</div>--%>
</div> 
<br />
 
   

      
  

      

 

        </div>
        
         <%--<div style="margin-top:2.5%; margin-left: -4%;">--%>
       
          
        
       
        <%-- <div style="margin-top:2.5%;margin-left: 1%">--%>
       
        
             <%-- </div>--%>
             
             
        
       
      
              
            


        
             
          
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
      Immigration Task Report
      </div>

               <div id="divPrintReportSorted" runat="server" style="display: none">
                                    <br />
                                </div>
    

 <%--------------------------------View for ManPower Requirement informatn--------------------------%>



    <div id="divPrintCaptionDetails" class="table-responsive" runat="server">
            </div>

   <label id="lblPrintOnBrdDtls" runat="server" style="float: left; cursor: inherit"></label>

    <div id="divPrintReportDetails" class="table-responsive" runat="server">
         <br />
       </div>

     <%--   </ContentTemplate>
        </asp:UpdatePanel>--%>

    <style>


    #ReportTableDtl_length {
    margin-bottom: 1%;
    font-family: Calibri;
    font-weight: bold;
    font-size: 14px;
    padding-bottom: 0.7%;
}

    #ReportTableDtl_filter {
    font-family: Calibri;
    font-weight: bold;
    font-size: 14px;
}

    #ReportTableDtl_info {
    font-family: Calibri;
    font-weight: 600;
    font-size: 14px;
}

    #ReportTableDtl_paginate {
    font-family: Calibri;
    font-size: 13px;
}


      .open > .dropdown-menu {
            display: none;
        }
    </style>

  
</asp:Content>

