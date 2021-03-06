<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WPS_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_WPS_List_WPS_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WPS List</title>
     <link rel="icon" href="../../Images/Icons/Print-title.png" type="image/x-icon"/>
    <style type="text/css">

        
        body
        {
            font-size: 12px;
            font-family: Tahoma,Arial;
            
        }
        .top_row
        {
            font-size: 10px;
            font-weight: Bold;
            text-align:center;
        }
         .thT {
            border-right:solid 1px #939191;
        }
        .section
        {
            font-weight: Bold;
            background-color: #e7e7e7;
        }
        .row1
        {
            
        }
        .D0
        {
            display: none;
        }
        .tab tr td
        {
            padding: 4px 2px;
            border: solid 1px #939191;
            border-collapse: collapse;
        }
        .tab
        {
            border: solid 1px #555555;
            border-collapse: collapse;
            width:96%;
        }
        
        
        a
        {
            color: #000000;
            text-decoration: none;
        }
        
        .hidden1
        {
            display: none;
        }
         .hidden2
        {
            display: none;
        }
        .pagehead
        {
            color: #09045E;
            font-family: calibri,tahoma;
            font-size: 10pt;
            font-weight: bold;
            text-transform: uppercase;
        }
        .bordertop td
        {
            border-top: solid 1px #000000;
        }
        .clear
        {
            clear: both;
            font-size: 0px;
            padding: 0px;
            line-height: 0px;
            height: 0px;
        }
        .table_heading{font-weight:bold}
        .table_heading1{font-weight:bold}
        .table_heading2{font-weight:bold}
        .companyName{font-weight:bold}
         .footersummary
        {
            border-collapse:collapse;
        }
        .footersummary td
        {
            border:#fff solid 1px !important;   
            font-weight:bold;
        }
        @media print
        {
            body
            {
                font-size: 12px;
                font-family: Tahoma,Arial;
                color: #555555;
            }
            .top_row
            {
                font-size: 12px;
                font-weight: Bold;
                 text-align:center;
            }
            .section
            {
                font-weight: Bold;
            }
            .row1
            {
                background-color: #e7e7e7;
            }
        
            .tab tr td
            {
                padding: 4px 2px;
                border: solid 1px #939191;
                border-collapse: collapse;
            }
            .tab
            {
                border: solid 1px #555555;
                border-collapse: collapse;
                width:90%;
            }
        
            #printimg
            {
                display: none;
            }
           
        
            .clear
            {
                clear: both;
                font-size: 0px;
                padding: 0px;
                line-height: 0px;
                height: 0px;
            }
           
        }
    </style>
    <style type="text/css">
        #prntOuter
        {
            width: 760px;
            margin: 0 auto;
            border: solid 1px #ababab;
            height: 1000px;
        }
        #topSec
        {
            width: 100%;
        }
        #bottSec
        {
           
            width: 100%;
        }
        .tabInsForm
        {
            width: 100%;
            border-collapse: collapse;
            font-family: Arial;
        }
        .tabInsForm th
        {
            font-size: 12px;
            font-weight: bold;
            background-color: #efefef;
            border: solid 1px #a0a0a0;
            color: #565656;
        }
        .tabInsForm td
        {
            font-size: 12px;
            background-color: #fefefe;
            border: solid 1px #a0a0a0;
            color: #676767;
            width: 50%;
            padding: 3px;
        }
        .tabPreEx
        {
            width: 100%;
            border-collapse: collapse;
        }
        .tabPreEx td
        {
            border: none;
             background-color: #fafafa;
            border: solid 1px #eeeeee;
        }
        .tabPreEx th
        {
           font-size: 12px;
            font-weight: bold;
            background-color: #f2f2f2;
            border: solid 1px #dedede;
            color: #565656;
        }
        @media print
        {
             #prntOuter
        {
            width: 760px;
            margin: 0 auto;
            border: solid 1px #ababab;
            height: 1000px;
        }
        #topSec
        {
            width: 100%;
        }
        #bottSec
        {
           
            width: 100%;
        }
        .tabInsForm
        {
            width: 100%;
            border-collapse: collapse;
            font-family: Arial;
        }
        .tabInsForm th
        {
            font-size: 12px;
            font-weight: bold;
            background-color: #efefef;
            border: solid 1px #a0a0a0;
            color: #565656;
        }
        .tabInsForm td
        {
            font-size: 12px;
            background-color: #fefefe;
            border: solid 1px #a0a0a0;
            color: #676767;
            width: 50%;
            padding: 3px;
        }
        .tabPreEx
        {
            width: 100%;
            border-collapse: collapse;
        }
        .tabPreEx td
        {
            border: none;
             background-color: #fafafa;
            border: solid 1px #eeeeee;
        }
        .tabPreEx th
        {
           font-size: 12px;
            font-weight: bold;
            background-color: #f2f2f2;
            border: solid 1px #dedede;
            color: #565656;
        }
        }
    </style>
      <style type="text/css">
        #coumnLeft {
            text-align: left;
        }

        #TableRprtRow {
            font-size: 11px;
             text-align: center;
        }
         #divPrintCaption   .CompanyName { 
              font-size: 14px;
            font-weight: bold; 
            line-height: 8px;
          }
          #divPrintCaption  .CompanyAddr {
              font-size: 10px;
                       
          }
        #divPrintCaption    .RprtDate {
        line-height: 20px;
        font-size: 12px;
          }
         #divPrintCaption   .CapTitle {
              font-size: 13px;
              font-weight: bold;
              line-height: 20px;
          }
          #divPrintCaption  .PrintCaptionTable {
             
          }
            #TableRprtRow .rowHeight {
                line-height: 8px;
            }
          #divPrintCaption {
              
       
          }
           #countColumn {
            width: 18%;
        }
          .btnDown {
              font-family: Calibri;
    font-size: 14px;
    color: #fff;
    padding: 4px 24px 5px;
    margin: 0 14px 6px 2px;
    line-height: 1;
    font-weight: normal;
    float: left;
    background: #9ba48b;
    border: none;
    border-radius: 2px;
    cursor: pointer;
    text-transform: uppercase;
}
          }
           
    </style>
   
</head>
<body onload="showreport();">
    <form id="form1" runat="server">
            <div  id="printimg" onclick="window.print();" class="formtxt" style="cursor: pointer;
        float: right">
     
        <img src="/Images/Other Images/imgPrint.png" />
        <strong style="font-size:15px;">Print &nbsp &nbsp</strong></div>
   
    <div style="clear: both;">
    </div>
     <div id="divPrintCaption">
    </div>
    <div id="prntTable">
    </div>
       <div id="Div1"  style="margin-top: 65px;">
    </div>
     <div id="divPath"  style="margin-top: 65px; display:none">
    </div>
    <div>
        <asp:Button ID="btnDownload" CssClass="btnDown"  runat="server" Text="Download CSV" Style="float:right;background-color: #1c74a4;"  OnClick="btnDownload_Click" />
    </div>
    </form>
</body>
     <script type="text/javascript">

         function showreport() {
             
             document.getElementById("prntTable").innerHTML = window.opener.document.getElementById("cphMain_divSIFHeader").innerHTML;

             document.getElementById("Div1").innerHTML = window.opener.document.getElementById("cphMain_divSIFbody").innerHTML;
            

         }

         window.onload = showreport();

    </script>
</html>
