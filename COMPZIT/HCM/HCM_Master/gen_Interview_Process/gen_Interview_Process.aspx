<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_Interview_Process.aspx.cs" Inherits="HCM_HCM_Master_gen_Interview_Process_gen_Interview_Process" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
   
    <style>
         .TableHeader {
            background-color: #A4B487;
            color: white;
            font-weight: bold;
            font-family: calibri;
            line-height: 27px;
        }
    </style>
    <style>
     .modalCancelView {
              display: none; /* Hidden by default */
              position: fixed; /* Stay in place */
              z-index: 30; /* Sit on top */
              padding-top: 0%; /* Location of the box */
              left: 23%;
              top: 30%;
              width: 50%; /* Full width */
              /*height: 58%;*/ /* Full height */
              overflow: auto; /* Enable scroll if needed */
              background-color: transparent;
          }


          /* Modal Content */
          .modal-CancelView {
              /*position: relative;*/
              background-color: #fefefe;
              margin: auto;
              padding: 0;
              /*border: 1px solid #888;*/
              width: 95.6%;
              box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
          }


          /* The Close Button */
          .closeCancelView {
              color: white;
              float: right;
              font-size: 28px;
              font-weight: bold;
          }

              .closeCancelView:hover,
              .closeCancelView:focus {
                  color: #000;
                  text-decoration: none;
                  cursor: pointer;
              }

          .modal-headerCancelView {
              /*padding: 1% 1%;*/
              background-color: #91a172;
              color: white;
          }

          .modal-bodyCancelView {
              padding: 4% 4% 7% 4%;
          }

          .modal-footerCancelView {
              padding: 2% 1%;
              background-color: #91a172;
              color: white;
          }
      </style>
    <script>
        var submit = 0;
        function CheckIsRepeat() {

            if (++submit > 1) {

                return false;
            }
            else {
                return true;
            }
        }
        function CheckSubmitZero() {
            submit = 0;
        }
    </script>

    <script>
        var submitPR = 0;
        function CheckIsRepeatPR() {

            if (++submitPR > 1) {

                return false;
            }
            else {
                return true;
            }
        }
        function CheckSubmitZeroPR() {
            submitPR = 0;
        }
    </script>
     <%--auto completion files--%>

    <script type="text/javascript" src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="../../../css/Autocomplete/jquery-ui.css" rel="stylesheet" />
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
            /*width: 218px;*/
            border: 1px solid #B0BECA;
            max-height: 140px;
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

    <script src="../../../JavaScript/multiselect/jQuery/jquery-3.1.1.min.js"></script>
    <script src="../../../JavaScript/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../JavaScript/datepicker/datepicker3.css" rel="stylesheet" />
  
      <script type="text/javascript">
         
        var $noCon = jQuery.noConflict();

        $noCon(function () {

              localStorage.clear();          
              document.getElementById("freezelayer").style.display = "none";
             

          });


         
          var confirmbox = 0;
          function IncrmntConfrmCounter() {
           
              confirmbox++;
          }


          var confirmboxAsmnt = 0;
          function IncrmntConfrmCounterAsmnt() {

              confirmboxAsmnt++;
          }

          var submit = 0;
          function CheckIsRepeat() {
              if (++submit > 1) {

                  return false;
              }
              else {
                  return true;
              }
          }
          function CheckSubmitZero() {
              submit = 0;
          }

          function ConfirmMessage() {
              if (confirmbox > 0) {
                  if (confirm("Are you sure you want to leave this page?")) {
                      window.location.href = "gen_Interview_Process_List.aspx";
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {
                  window.location.href = "gen_Interview_Process_List.aspx";
                  return false;
              }
          }

          function ConfirmMessageCncl() {
              document.getElementById("<%=HiddenFieldScoreDdl.ClientID%>").value = "";
              if (confirmbox > 0) {
                  if (confirm("Are you sure you want to leave this page?")) {
                     
                      window.location.href = "gen_Interview_Process_List.aspx?Id=" + HiddenFieldQryString.Value + "";
                      
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {
                  window.location.href = "gen_Interview_Process_List.aspx?Id=" + HiddenFieldQryString.Value + "";
                 
                  return false;
              }
          }
        

          function ConfirmClear() {
            
              var QryStrng = document.getElementById("<%=HiddenFieldQryString.ClientID%>").value;
              var CandId = document.getElementById("<%=HiddenFieldCandId.ClientID%>").value;

              if (confirmbox > 0) {
                  if (confirm("Are you sure you want clear all data in this page?")) {
                      document.getElementById("<%=HiddenFieldScoreDdl.ClientID%>").value = "";
                      window.location.href = "gen_Interview_Process.aspx?Id=" + QryStrng + "&Hld=" + 0 + "&CandId=" + CandId + "";
                     
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {
                  document.getElementById("<%=HiddenFieldScoreDdl.ClientID%>").value = "";
                  window.location.href = "gen_Interview_Process.aspx?Id=" + QryStrng + "&Hld=" + 0 + "&CandId=" + CandId + "";
                 
                  return false;
              }
          }


          </script>
    <script>
        function OpenAsmnt(id, ctgryId, RowCnt) {

            document.getElementById("<%=HiddenFieldSchdlLvlId.ClientID%>").value = id;
            document.getElementById("<%=HiddenFieldCtgryId.ClientID%>").value = ctgryId;


            var ReqrmntId = document.getElementById("<%=HiddenFieldReqrmntId.ClientID%>").value;
            var CandId = document.getElementById("<%=HiddenFieldCandId.ClientID%>").value;


            document.getElementById("MyModalJobSubmit").style.display = "block";
            document.getElementById("freezelayer").style.display = "";
            var $NonCon = jQuery.noConflict();
            $NonCon.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_Interview_Process.aspx/ReadAsmntInfo",
                data: '{intId: "' + id + '",intRqrmntId: "' + ReqrmntId + '",intCandId: "' + CandId + '"}',
                dataType: "json",
                success: function (data) {



                    if (document.getElementById("ddlDecsn" + RowCnt).disabled == false) {

                        if (data.d[1] != '' && data.d[1] != null) {


                            var EditValDayWise = data.d[1];
                            if (EditValDayWise != "") {


                                var find2 = '\\"\\[';
                                var re2 = new RegExp(find2, 'g');
                                var res2 = EditValDayWise.replace(re2, '\[');
                                var find3 = '\\]\\"';
                                var re3 = new RegExp(find3, 'g');
                                var res3 = res2.replace(re3, '\]');
                                var json = $noCon.parseJSON(res3);
                                for (var key in json) {

                                    if (json.hasOwnProperty(key)) {
                                        if (json[key].TransId != "") {

                                            EditListRowsAddtnlJobs(json[key].AsmntTableId, json[key].CtgryDtlId, json[key].CatgryId, json[key].AsmntName, json[key].Score);

                                        }
                                    }
                                }


                            }



                        }


                        else {

                            if (data.d[0] != '' && data.d[0] != null) {


                                var EditValDayWise = data.d[0];
                                if (EditValDayWise != "") {


                                    var find2 = '\\"\\[';
                                    var re2 = new RegExp(find2, 'g');
                                    var res2 = EditValDayWise.replace(re2, '\[');
                                    var find3 = '\\]\\"';
                                    var re3 = new RegExp(find3, 'g');
                                    var res3 = res2.replace(re3, '\]');
                                    var json = $noCon.parseJSON(res3);
                                    for (var key in json) {

                                        if (json.hasOwnProperty(key)) {
                                            if (json[key].TransId != "") {

                                                EditListRowsAddtnlJobs(json[key].AsmntTableId, json[key].CtgryDtlId, json[key].CatgryId, json[key].AsmntName, json[key].Score);

                                            }
                                        }
                                    }


                                }

                            }

                        }

                        document.getElementById("cphMain_btnSubSave").style.display = "";
                        document.getElementById("btnSubCncl").style.display = "";

                        addMoreRowsAddtnlJobs(this.form, false, 1, false, 0);
                        var x = document.getElementById("<%=HiddenFieldAsmntRowCount.ClientID%>").value;
                        SbmsnNotChckd(x);

                    }

                    else if (document.getElementById("ddlDecsn" + RowCnt).disabled == true) {

                        if (data.d[1] != '' && data.d[1] != null) {


                            var EditValDayWise = data.d[1];
                            if (EditValDayWise != "") {


                                var find2 = '\\"\\[';
                                var re2 = new RegExp(find2, 'g');
                                var res2 = EditValDayWise.replace(re2, '\[');
                                var find3 = '\\]\\"';
                                var re3 = new RegExp(find3, 'g');
                                var res3 = res2.replace(re3, '\]');
                                var json = $noCon.parseJSON(res3);
                                for (var key in json) {

                                    if (json.hasOwnProperty(key)) {
                                        if (json[key].TransId != "") {

                                            ViewListRowsAddtnlJobs(json[key].AsmntTableId, json[key].CtgryDtlId, json[key].CatgryId, json[key].AsmntName, json[key].Score);

                                        }
                                    }
                                }


                            }



                        }


                        else {

                            if (data.d[0] != '' && data.d[0] != null) {


                                var EditValDayWise = data.d[0];
                                if (EditValDayWise != "") {


                                    var find2 = '\\"\\[';
                                    var re2 = new RegExp(find2, 'g');
                                    var res2 = EditValDayWise.replace(re2, '\[');
                                    var find3 = '\\]\\"';
                                    var re3 = new RegExp(find3, 'g');
                                    var res3 = res2.replace(re3, '\]');
                                    var json = $noCon.parseJSON(res3);
                                    for (var key in json) {

                                        if (json.hasOwnProperty(key)) {
                                            if (json[key].TransId != "") {

                                                ViewListRowsAddtnlJobs(json[key].AsmntTableId, json[key].CtgryDtlId, json[key].CatgryId, json[key].AsmntName, json[key].Score);

                                            }
                                        }
                                    }


                                }

                            }

                        }
                        document.getElementById("cphMain_btnSubSave").style.display = "none";
                        document.getElementById("btnSubCncl").style.display = "none";
                    }

                },
                error: function (result) {

                }
            });
            return false;
        }


        function SbmsnNotChckd(x) {
            var SchdlId = document.getElementById("<%=HiddenFieldSchdlLvlId.ClientID%>").value;
            var tableName = "dtTableDivision";
            var $coo = jQuery.noConflict();
            var ddlTestDropDownListXML = $coo(document.getElementById("txtselectorAsmnt"+x));
            if (SchdlId != "") {
                $coo.ajax({
                    type: "POST",
                    url: "gen_Interview_Process.aspx/SbmsnNotChckd",
                    data: '{tableName:"' + tableName + '",SchdlId:"' + SchdlId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                       
                        var OptionStart = $coo("<option>--Select Point--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);
                        // Now find the Table from response and loop through each item (row).
                        $coo(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $coo(this).find('INTWCTGRYDTL_ID').text();
                            var OptionText = $coo(this).find('INTWCTGRYDTL_NAME').text();
                            // Create an Option for DropDownList.
                            var option = $coo("<option>" + OptionText + "</option>");
                            option.attr("value", OptionValue);
                            ddlTestDropDownListXML.append(option);

                           
                        });
                       
                    },
                    failure: function (response) {

                    }
                });



            }
            return false;
        }






       function CloseAsmnt() {

           
               if (confirmboxAsmnt > 0) {
                   if (confirm("Are you sure you want to leave this page?")) {
                       document.getElementById("MyModalJobSubmit").style.display = "none";
                       document.getElementById("freezelayer").style.display = "none";
                       jQuery('#TableAddtnlJobs tr').remove();
                       localStorage.clear();
                       InitializeAdd();
                       document.getElementById("<%=HiddenFieldAddtnlJobs.ClientID%>").value = "";
                       document.getElementById('divErrorNotificationSb').style.visibility = "hidden";
                       document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "";
                       document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value = "";
                       confirmboxAsmnt = 0;
                   }
                   else {
                       return false;
                   }
               }
               else {
                   document.getElementById("MyModalJobSubmit").style.display = "none";
                   document.getElementById("freezelayer").style.display = "none";
                   jQuery('#TableAddtnlJobs tr').remove();
                   localStorage.clear();
                   InitializeAdd();
                   document.getElementById("<%=HiddenFieldAddtnlJobs.ClientID%>").value = "";
                   document.getElementById('divErrorNotificationSb').style.visibility = "hidden";
                   document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "";
                   document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value = "";
               }
         

       }
       function EditNotPsble() {
           alert('Candidate is rejected.Edit not possible');
       }
       function EditNot() {
           alert('Interview level is not scheduled ');
       }
      

       function getCandInfo(CandId,qualfd) {
           
           document.getElementById("cphMain_btnAdd").style.display = "none";
           document.getElementById('divMessageArea').style.display = "none";
           document.getElementById('imgMessageArea').src = "";
           document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";


           document.getElementById('divErrorNotificationSd').style.visibility = "hidden";
           document.getElementById("<%=lblErrorNotificationSd.ClientID%>").innerHTML = "";
           
          var CorpId= document.getElementById("<%=HiddenCorp.ClientID%>").value; 
          var OrgId= document.getElementById("<%=HiddenOrg.ClientID%>").value; 

           var ReqrmntId = document.getElementById("<%=HiddenFieldReqrmntId.ClientID%>").value; 
           document.getElementById("<%=HiddenFieldCandId.ClientID%>").value = CandId;
           var Details = PageMethods.ReadEmpSchdlInfoById(CandId, ReqrmntId,CorpId,OrgId, function (response) {
             
              
               document.getElementById("divButtons").style.display = "block";
               document.getElementById("divCandidateInfo").style.display = "block";
               document.getElementById("<%=lblCandtName.ClientID%>").innerHTML = response.CandName;
               document.getElementById("<%=lblLoctn.ClientID%>").innerHTML = response.Location;
               document.getElementById("<%=lblRefEmp.ClientID%>").innerHTML = response.Reference;
               document.getElementById("<%=lblResume.ClientID%>").innerHTML = response.FileName;
               document.getElementById("<%=divSchdlList.ClientID%>").innerHTML = response.SchdlList;
            
               document.getElementById("<%=divPrintReport1.ClientID%>").innerHTML = response.SchdlListPrint;
               document.getElementById("<%=divPrintCaption1.ClientID%>").innerHTML = response.SchdlListPrintcAPTION;
               




                           
             
               $(window).scrollTop(1000);
               

               var rowCount = $p('#ReportTableSchdl tr').length - 1;

               for (var i = 0; i < rowCount; i++) {

               
                  $noCon('#dateIntvew'+i).datepicker({
                       autoclose: true,
                       format: 'dd-mm-yyyy',
                       language: 'en',
                       endDate: new Date()
                   });


                   bindScore(i);
                   bindDecsn(i);
               }

               if (response.ScdlLVlEditInfo[0] != '' && response.ScdlLVlEditInfo[0] != null) {

                   var EditValDayWise = response.ScdlLVlEditInfo[0];
                   if (EditValDayWise != "") {

                       var x = 0;
                       var find2 = '\\"\\[';
                       var re2 = new RegExp(find2, 'g');
                       var res2 = EditValDayWise.replace(re2, '\[');

                       var find3 = '\\]\\"';
                       var re3 = new RegExp(find3, 'g');
                       var res3 = res2.replace(re3, '\]');
                       //   alert('res3' + res3);
                       var json = $noCon.parseJSON(res3);
                       for (var key in json) {
                           if (json.hasOwnProperty(key)) {
                               if (json[key].TransId != "") {
                               
                                   for (var i = 0; i < rowCount; i++) {
                                      
                                       var scdlId = document.getElementById("SchdlId" + i).innerHTML;
                                       if (scdlId == json[key].SchdlLvlId) {
                                           if (json[key].DescnId != "") {
                                               if (json[key].ScoreId != "") {
                                                   document.getElementById("ddlscore" + i).value = json[key].ScoreId;
                                               }
                                           document.getElementById("ddlDecsn" + i).value = json[key].DescnId;
                                           document.getElementById("dateIntvew" + i).value = json[key].IntervDate;
                                           //if (json[key].DescnId == "2") {
                                           //    document.getElementById("divButtons").style.display = "none";
                                           //    document.getElementById("divCandidateInfo").style.display = "none";
                                           //}
                                       }
                                           document.getElementById("savedLvl" + i).innerHTML = json[key].SchdlTableId;                                          
                                       }
                                   }

                                                                         }
                                    }
                                }
                            }
                        }

               //Start:- disable             
             
             
               if (document.getElementById("<%=HiddenFieldIns.ClientID%>").value == "ins") {
                   SuccessAsnmnt();
               }
               else if (document.getElementById("<%=HiddenFieldIns.ClientID%>").value == "insLvl") {
                   SuccessSave();
               }
               document.getElementById("<%=HiddenFieldIns.ClientID%>").value == "";


              

               var Active = 500;
             
               for (var i = 0; i < rowCount; i++) {
                   var SavedTable = document.getElementById("savedLvl" + i).innerHTML;
                   var scr=document.getElementById("ddlscore" + i).value;
                   var des=document.getElementById("ddlDecsn" + i).value;
                   var dat=document.getElementById("dateIntvew" + i).value;
                   if (des == 0 || des == 3||dat == "") {
                       Active = i;
                       break;
                   }
               }
             


              



              
               for (var i = 0; i < rowCount; i++) {

                
                   var ValidateLvl = document.getElementById("ValidateLvl" + i).innerHTML;
                   var ScoreChckSts = document.getElementById("ScoreChck" + i).innerHTML;
                                                       

                       if (ScoreChckSts == "0") {

                           document.getElementById("ddlscore" + i).disabled = true;

                       }
                       if (ValidateLvl == "1" && Active != i) {

                           document.getElementById("ddlscore" + i).disabled = true;
                           document.getElementById("ddlDecsn" + i).disabled = true;
                           document.getElementById("dateIntvew" + i).disabled = true;
                           document.getElementById("LinkId" + i).style.pointerEvents = "";

                       }
                       else if (ValidateLvl == "0") {

                           var des = document.getElementById("ddlDecsn" + i).value;
                           var dat = document.getElementById("dateIntvew" + i).value;
                           if (des != 0 && dat != "") {
                               document.getElementById("ddlscore" + i).disabled = true;
                               document.getElementById("ddlDecsn" + i).disabled = true;
                               document.getElementById("dateIntvew" + i).disabled = true;
                               document.getElementById("LinkId" + i).style.pointerEvents = "";
                           }

                       }

                   }
           
             
               document.getElementById("cphMain_btnAdd").style.display = "block";
               document.getElementById("cphMain_btnClear").style.display = "block";
             
               //End:-disable
               if (document.getElementById("<%=HiddenFieldHoldStatus.ClientID%>").value == "1" || qualfd == true ) {
                 
               for (var i = 0; i < rowCount; i++) {
                  
                       document.getElementById("ddlscore" + i).disabled = true;
                       document.getElementById("ddlDecsn" + i).disabled = true;
                       document.getElementById("dateIntvew" + i).disabled = true;
                       document.getElementById("LinkId" + i).style.pointerEvents = "";
               }
               document.getElementById("cphMain_btnAdd").style.display = "none";
               document.getElementById("cphMain_btnClear").style.display = "none";
               }


               $p('#ReportTableSchdl').DataTable({
                   "pagingType": "full_numbers",
                  "bSort": true,
                   "pageLength": 25
               });



           });
          
           return false;
       }
        function bindScore(x) {

            document.getElementById("ddlscore" + x).options.length = 0;
            var $coo = jQuery.noConflict();
            var ddlTestDropDownListXML = $coo(document.getElementById("ddlscore" + x));
            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableDivision";

            if (document.getElementById("<%=HiddenFieldScoreDdl.ClientID%>").value !=0) {              
                dropdowndata = document.getElementById("<%=HiddenFieldScoreDdl.ClientID%>").value;

                var OptionStart = $coo("<option>--Select Score--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);

                $noCon(dropdowndata).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $coo(this).find('INTSCR_ID').text();
                    var OptionText = $coo(this).find('INTSCR_NAME').text();
                    // Create an Option for DropDownList.
                    var option = $coo("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);
                    ddlTestDropDownListXML.append(option);
                });

            }

        }

        function bindDecsn(x) {

            document.getElementById("ddlDecsn" + x).options.length = 0;
            var $coo = jQuery.noConflict();
            var ddlTestDropDownListXML = $coo(document.getElementById("ddlDecsn" + x));
           
            var OptionStart = $coo("<option>--Select Decision--</option>");
            OptionStart.attr("value", 0);
            ddlTestDropDownListXML.append(OptionStart);

            var OptionStart = $coo("<option>QUALIFIED</option>");
            OptionStart.attr("value", 1);
            ddlTestDropDownListXML.append(OptionStart);

            var OptionStart = $coo("<option>REJECTED</option>");
            OptionStart.attr("value", 2);
            ddlTestDropDownListXML.append(OptionStart);

            var OptionStart = $coo("<option>WAITING LIST</option>");
            OptionStart.attr("value", 3);
            ddlTestDropDownListXML.append(OptionStart);
        }
    </script>
    <script>
        function addAsmnt() {
            var $noC = jQuery.noConflict();
          
            var strId = document.getElementById("<%=HiddenFieldCtgryId.ClientID%>").value;           
           
            document.getElementById('divErrorNotificationSb').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "";
            if (confirm('Are you sure.Do you want to add new assessment point?') == true) {                           
                var nWindow = window.open('/HCM/HCM_Master/gen_Interview_Category/gen_Interview_Category.aspx?StrId=' + strId + '', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                nWindow.focus();
            }

            return false;
        }
        function GetValueFromChild(saved) {
            if (saved == "saved") {
              

                document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Assessment point inserted successfully.";
      
                var rowcount = document.getElementById("<%=HiddenFieldAsmntRowCount.ClientID%>").value;
                var DeleteRowNumData = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;
                var DeleteRowNum = DeleteRowNumData.split(',');
                var count = DeleteRowNum.length;
                 for (var x = 1; x <= rowcount ; x++) {

                     var deleSTS = "false";
                     for (var i = 0; i < count; i++) {
                         if (x == DeleteRowNum[i]) {
                             deleSTS = "true";
                         }
                     }

                     if (deleSTS == "false") {

                         var detailId = document.getElementById("tdDtlId" + x).innerHTML;
                         if (detailId == "") {
                             var AsmntId = document.getElementById("txtselectorAsmnt" + x).value;
                             document.getElementById("txtselectorAsmnt" + x).options.length = 0;
                             SbmsnNotChckd(x);
                             setTimeout(selectasmnt(x, AsmntId), 100);
                         
                         }
                         

                     }


                 }

            }
        }
      
        function selectasmnt(x, AsmntId) {
    
            if (AsmntId != "0") {


                var objSelect = document.getElementById("txtselectorAsmnt" + x);
                       for (var i = 0; i < objSelect.options.length; i++) {
     
                    if (objSelect.options[i].value == AsmntId) {
                       
                        objSelect.options[i].selected = true;
                           
                        }
                    }
              
                document.getElementById("txtselectorAsmnt" + x).value = AsmntId;
            
            }
        }
    </script>
    <script>
      

       var $noC = jQuery.noConflict();
        var rowCount = 0;      
       

        function InitializeAdd() {
            rowCount = 0;
        }
        var RowIndex = 0;
        function addMoreRowsAddtnlJobs(frm, boolFocus, JobMode, boolAppendorNot, row_index) {

            rowCount++;
            RowIndex++;

           
            var recRow = '<tr id="rowId_' + rowCount + '" >';
            recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
            recRow += '<td id="tdTableId' + rowCount + '" style="display: none;"></td>';
            recRow += '<td id="tdSchdlIdAsmnt' + rowCount + '" style="display: none;">' + document.getElementById("<%=HiddenFieldSchdlLvlId.ClientID%>").value + '</td>';


            recRow += ' <td id="tdAsmntSelect' + rowCount + '" style="width: 87%;"><div class="Cls' + rowCount + '">';
            //recRow += ' <input  style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 100%;margin-left: 0.1%;" id="txtselectorAsmnt' + rowCount + '" class="BillngEntryField" type="text"  value="--Select Point--"    /> ';
            recRow += '<select id="txtselectorAsmnt' + rowCount + '" style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 98%;margin-left: 0.1%;height:26px;" onkeydown="return isTag(event)" onchange="return ChangeAsmnt(' + rowCount + ')" ></select>';
            recRow += '<input id="addNewAsmnt' + rowCount + '" title="Add"  type="image" class="BillngEntryField" src="../../../Images/Icons/add.png" alt="Add" onclick="return addAsmnt();"  style="  cursor: pointer;margin-left:0.5%;">';
            recRow += ' </div> </td> ';
            //recRow += ' <td  style="display: none;"><input id="txtselectorAsmntId' + rowCount + '"   type="text"   /></td>';
            //recRow += ' <td  style="display: none;"><input id="txtselectorAsmntName' + rowCount + '"   type="text" maxlength=100  /></td>';


            recRow += ' <td id="tdScore' + rowCount + '" style="width: 14%;"><div class="Cls' + rowCount + '">';
            recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 92%;" id="txtselectorScore' + rowCount + '" class="BillngEntryField" type="text"  value="0"  maxlength=2 onkeydown="return isNumber(event)" onblur="return BlurScore(' + rowCount +')"/> ';
            recRow += ' </div> </td> ';
          


            recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input title="Add" id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);"  style="  cursor: pointer;"></td>';
            recRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowAddtnlJobs(' + rowCount + ',\'Are you sure you want to Delete this Entry?\',true);" style=" cursor: pointer;" ></td>';


            recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
            recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
            recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">INS</td>';
            recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;"></td>';


            recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
            recRow += '</tr>';


            document.getElementById("<%=HiddenFieldAsmntRowCount.ClientID%>").value = rowCount;
            



            if (boolAppendorNot == false) {

                jQuery('#TableAddtnlJobs').append(recRow);
            }
            else {

                // to insert in perticular position
                var $NoAppnd = jQuery.noConflict();
                if (parseInt(row_index) != 0) {
                    $NoAppnd('#TableAddtnlJobs' > tbody > tr).eq(parseInt(row_index) - 1).after(recRow);
                }
                else {

                    var TableRowCount = document.getElementById(TableName).rows.length;

                    if (parseInt(TableRowCount) != 0) {
                        $NoAppnd('#TableAddtnlJobs' > tbody > tr).eq(parseInt(row_index)).before(recRow);
                    }
                    else {
                        //if table row count is 0
                        jQuery('#TableAddtnlJobs').append(recRow);
                    }
                }
            }

            //var $au = jQuery.noConflict();

            //(function ($au) {
            //    $au(function () {
            //        selectorToAutocompleteAsmnt('txtselectorAsmnt', rowCount);
            //        $au('form').submit(function () {

            //        });
            //    });
            //})(jQuery);

        }



        function EditListRowsAddtnlJobs(EditAsmntTableId,EditCtgrydtlId, EditCtgryId, EditAsmntName,EditScore) {

           
            if (EditCtgrydtlId.toString() != "" && EditCtgryId.toString != "" && EditAsmntName != "" ) {


                rowCount++;
                RowIndex++;

              

                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td id="tdTableId' + rowCount + '" style="display: none;">' + EditAsmntTableId+ '</td>';
                recRow += '<td id="tdSchdlIdAsmnt' + rowCount + '" style="display: none;">' + document.getElementById("<%=HiddenFieldSchdlLvlId.ClientID%>").value + '</td>';
              


                recRow += ' <td id="tdAsmntSelect' + rowCount + '" style="width: 87%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input disabled style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 100%;margin-left: 0.1%;" id="txtselectorAsmnt' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditAsmntName + '"    /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input id="txtselectorAsmntId' + rowCount + '"  value="' + EditCtgrydtlId + '" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><input id="txtselectorAsmntName' + rowCount + '"  value="' + EditAsmntName + '" type="text" maxlength=100  /></td>';


                recRow += ' <td id="tdScore' + rowCount + '" style="width: 14%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 92%;" id="txtselectorScore' + rowCount + '" class="BillngEntryField" type="text" value="' + EditScore + '"  maxlength=2 onkeydown="return isNumber(event)" onblur="return BlurScore(' + rowCount + ')"/> ';
                recRow += ' </div> </td> ';
               


                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input title="Add" id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);"  style="  cursor: pointer;"></td>';
                recRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" disabled type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRowAddtnlJobs(' + rowCount + ',\'Are you sure you want to Delete this Entry?\',true);" style=" cursor: pointer;" ></td>';


                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';
                if (EditAsmntTableId == "") {
                recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">INS</td>';
                }

                else {
                    recRow += '<td id="tdEvt' + rowCount + '" style="display: none;">INS</td>';
                }
                recRow += '<td id="tdDtlId' + rowCount + '" style="display: none;">' + EditCtgrydtlId + '</td>';
                recRow += '<td id="tdChanged' + rowCount + '" style="display: none;"></td>';
                recRow += '</tr>';

                jQuery('#TableAddtnlJobs').append(recRow);
                document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";


               

            }

        }


        function ViewListRowsAddtnlJobs(EditAsmntTableId, EditCtgrydtlId, EditCtgryId, EditAsmntName, EditScore) {


            if (EditCtgrydtlId.toString() != "" && EditCtgryId.toString != "" && EditAsmntName != "") {


                rowCount++;
                RowIndex++;



                var recRow = '<tr id="rowId_' + rowCount + '" >';
                recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';
                recRow += '<td id="tdTableId' + rowCount + '" style="display: none;">' + EditAsmntTableId + '</td>';
                recRow += '<td id="tdSchdlIdAsmnt' + rowCount + '" style="display: none;">' + document.getElementById("<%=HiddenFieldSchdlLvlId.ClientID%>").value + '</td>';

                recRow += ' <td id="tdAsmntSelect' + rowCount + '" style="width: 87%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input disabled style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 100%;margin-left: 0.1%;" id="txtselectorAsmnt' + rowCount + '" class="BillngEntryField" type="text"  value="' + EditAsmntName + '"    /> ';
                recRow += ' </div> </td> ';
                recRow += ' <td  style="display: none;"><input disabled id="txtselectorAsmntId' + rowCount + '"  value="' + EditCtgrydtlId + '" type="text"   /></td>';
                recRow += ' <td  style="display: none;"><input disabled id="txtselectorAsmntName' + rowCount + '"  value="' + EditAsmntName + '" type="text" maxlength=100  /></td>';


                recRow += ' <td id="tdScore' + rowCount + '" style="width: 14%;"><div class="Cls' + rowCount + '">';
                recRow += ' <input disabled style="line-height: 20px; margin-top: 0px; margin-bottom: 2px; width: 92%;" id="txtselectorScore' + rowCount + '" class="BillngEntryField" type="text" value="' + EditScore + '"  maxlength=2 onkeydown="return isNumber(event)" onblur="return BlurScore(' + rowCount + ')"/> ';
                recRow += ' </div> </td> ';



                recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" style="width: 1.5%; padding-left: 4px;"> <input title="Add" id="tdIndvlAddMoreRowPic' + rowCount + '"  type="image" class="BillngEntryField" src="../../../Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);"  style="  cursor: pointer;"></td>';
                recRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" disabled="disabled" type="image" class="BillngEntryField" src="../../../Images/Icons/deleteEntry.png" alt="Delete" style=" cursor: pointer;" ></td>';


                recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';

                jQuery('#TableAddtnlJobs').append(recRow);
                document.getElementById("tdInx" + rowCount).innerHTML = rowCount;
                document.getElementById("tdIndvlAddMoreRow" + rowCount).style.opacity = "0.3";
            }

        }



        function selectorToAutocompleteAsmnt(obj, x) {
             
            var $coo = jQuery.noConflict();
            var SchdlId = document.getElementById("<%=HiddenFieldSchdlLvlId.ClientID%>").value;
            if (SchdlId != '' && SchdlId != null && (!isNaN(SchdlId))) {
                $coo("#txtselectorAsmnt"+ x).autocomplete({
                     source: function (request, response) {
                         $coo.ajax({
                             url: '<%=ResolveUrl("WebServiceInterviewProcess.asmx/GetAsmnt") %>',
                             data: "{ 'strLikeAsmnt': '" + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + "', 'intSchdlId': '" + parseInt(SchdlId) + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {

                                response($coo.map(data.d, function (item) {
                                    return {
                                        label: item.split('<->')[0],
                                        val: item.split('<->')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                              
                            },
                            failure: function (response) {
                               
                            }
                        });
                    },
                    autoFocus: true,

                    select: function (e, i) {
                        document.getElementById("txtselectorAsmntId" + x).value = i.item.val;
                        document.getElementById("txtselectorAsmntName" + x).value = i.item.label;
                    },

                    minLength: 1

                });

            }

        }

       



        function CheckaddMoreRowsIndividual(x, retBool) {

            var check = document.getElementById("tdInx" + x).innerHTML;

            if (check == " ") {

                if (retBool == true) {

                    if (CheckAllRowFieldAndHighlight(x) == true) {

                        document.getElementById("tdInx" + x).innerHTML = x;
                        document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";
                        addMoreRowsAddtnlJobs(this.form, retBool, 1, false, 0);
                        var count = document.getElementById("<%=HiddenFieldAsmntRowCount.ClientID%>").value;
                        SbmsnNotChckd(count);
                        return false;
                    }
                }
                else if (retBool == false) {
                    var row_index = jQuery('#rowId_' + x).index();
                    if (CheckAllRowField(x, row_index, TableName) == true) {
                        document.getElementById("tdInx" + x).innerHTML = x;
                        document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";
                        addMoreRowsAddtnlJobs(this.form, retBool, 1, false, 0);
                        var count = document.getElementById("<%=HiddenFieldAsmntRowCount.ClientID%>").value;
                        SbmsnNotChckd(count);

                        return false;
                    }
                }
            }
            return false;
        }


        // checks every field in row
        function CheckAllRowFieldAndHighlight(x) {

            var ret = true;

            document.getElementById("txtselectorAsmnt" + x).style.borderColor = "";
           

            var Asmnt = document.getElementById("txtselectorAsmnt" + x).value;
            if (Asmnt == "--Select Point--" || Asmnt == "0") {
                document.getElementById("txtselectorAsmnt" + x).style.borderColor = "Red";
                document.getElementById("txtselectorAsmnt" + x).focus();
                $noCon("#txtselectorAsmnt" + x).select();
                return false;

            }
           
            return true;
        }

        function CheckAllRowField(x) {

            var ret = true;

            var Asmnt = document.getElementById("txtselectorAsmnt" + x).value;
            if (Asmnt == "--Select Point--" || Asmnt == "0") {              
                ret=false;
            }

            return ret;
        }

        function removeRowAddtnlJobs(removeNum, CofirmMsg, boolAskConfirm) {

           
            var blConfirm = true;
            if (boolAskConfirm == true) {
                if (confirm(CofirmMsg)) {
                    blConfirm = true;
                }
                else {
                    blConfirm = false;
                }
            }

            if (blConfirm == true) {


                var TableName = "TableAddtnlJobs";
                var row_index = jQuery('#rowId_' + removeNum).index();
              
                var BforeRmvTableRowCount = document.getElementById(TableName).rows.length;

                LocalStorageDeletejobAddtnl(row_index, removeNum, TableName);

                jQuery('#rowId_' + removeNum).remove();
                RowIndex--;
              
                var TableRowCount = document.getElementById(TableName).rows.length;

                if (TableRowCount != 0) {
                    var idlast = $noC('#' + TableName + ' tr:last').attr('id');
                    if (idlast != "") {
                        var res = idlast.split("_");
                        //  alert(res[1]);
                        document.getElementById("tdInx" + res[1]).innerHTML = " ";
                        document.getElementById("tdIndvlAddMoreRow" + res[1]).style.opacity = "1";
                    }
                }
                else {

                    addMoreRowsAddtnlJobs(this.form, true, 1, false, 0);

                }


                //for focussing to next or previous accordingly
                // While delete, then focus to be moved to next row (If there is any row below of current row) 
                // While delete, then focus to be moved to previous row (If there is any row above of current row) 
                if (BforeRmvTableRowCount > 1) {

                    if ((BforeRmvTableRowCount - 1) == row_index) {

                        var table = document.getElementById(TableName);
                        var preRowId = table.rows[row_index - 1].id;

                        if (preRowId != "") {
                            var res = preRowId.split("_");
                            if (res[1] != "") {


                                //document.getElementById("txtselectorJob" + res[1]).focus();
                                //$noCon("#txtselectorJob" + res[1]).select();
                                //ReNumberTable(TableName);

                            }
                        }
                    }
                    else {
                        //     alert('entered 2 case');
                        var table = document.getElementById(TableName);
                        var NxtRowId = table.rows[row_index].id;
                        //  alert('NxtRowId ' + NxtRowId);
                        if (NxtRowId != "") {
                            var res = NxtRowId.split("_");
                            if (res[1] != "") {

                                //document.getElementById("txtselectorJob" + res[1]).focus();
                                //$noCon("#txtselectorJob" + res[1]).select();
                                //ReNumberTable(TableName);

                            }
                        }


                    }
                }
                //   alert('removeRow-end' );
                return false;
            }
            else {
                //    alert('removeRow-end' );
                return false;

            }
        }
    </script>
    <script>
      
        function BlurScore(x) {
            //alert('call');

            IncrmntConfrmCounterAsmnt();
            var score = parseInt(document.getElementById("txtselectorScore" + x).value);
           
            if (score > 10 || isNaN(score)) {
                document.getElementById("txtselectorScore" + x).value = 0;
            }
            else {

                if (CheckAllRowField(x) == true) {
                   
                    var row_index = jQuery('#rowId_' + x).index();                  
                    var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
                    if (SavedorNot == "saved") {

                        LocalStorageEditjobAddtnl(x, row_index);

                    }

                    else {

                        LocalStorageAddjobAddtnl(x);

                    }
                }
            }
          
        }
        function ChangeAsmnt(x) {
           
            IncrmntConfrmCounterAsmnt();

            var row_index = jQuery('#rowId_' + x).index();
            document.getElementById("txtselectorAsmnt" + x).style.borderColor = "";
            document.getElementById('divErrorNotificationSb').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "";
            var Asmnt = document.getElementById("txtselectorAsmnt" + x).value;
            var Chck = 0;
            var rowcount = document.getElementById("<%=HiddenFieldAsmntRowCount.ClientID%>").value;
            var NoRows = $p('#TableAddtnlJobs tr').length - 1;
            var DeleteRowNumData = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;
            var DeleteRowNum = DeleteRowNumData.split(',');
            var count = DeleteRowNum.length;
            for (var i = rowcount; i > 0  ; i--) {
              
                    var deleSTS = "false";
                    for (var j = 0; j < count; j++) {
                        if (i == DeleteRowNum[j]) {
                            deleSTS = "true";
                        }
                    }

                    if (deleSTS == "false") {

                       
                        var detailId = document.getElementById("tdDtlId" + i).innerHTML;
                        if (detailId == "") {
                            var AsmntId = document.getElementById("txtselectorAsmnt" + i).value;
                        }
                        else {
                            var AsmntId = detailId;
                        }
                       
                       
                        if (x != i && Asmnt == AsmntId) {
                           
                            Chck = 1;
                        }
                    }
            }

            if (Chck == 1) {
                document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Duplication error!.Assessment point can’t be duplicated."
                document.getElementById("txtselectorAsmnt" + x).value = 0;
                document.getElementById("txtselectorAsmnt" + x).style.borderColor = "Red";
                document.getElementById("txtselectorAsmnt" + x).focus();
                return false;
            }

           
            if (Asmnt != "0") {
                var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
                if (SavedorNot == "saved") {
                   
                    LocalStorageEditjobAddtnl(x, row_index);

                }

                else {
                    //alert('add');
                    LocalStorageAddjobAddtnl(x);

                }
            }
            
        }
        // FOR TYPING NUMBER ONLY
        function isNumber(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //at enter
            if (keyCodes == 13) {
                return false;
            }
                //0-9
            else if (keyCodes >= 48 && keyCodes <= 57) {
                return true;
            }
                //numpad 0-9
            else if (keyCodes >= 96 && keyCodes <= 105) {
                return true;
            }
                //left arrow key,right arrow key,home,end ,delete
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                return true;

            }
            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                }
                return ret;
            }
        }
        function LocalStorageAddjobAddtnl(x) {
            var row_index = jQuery('#rowId_' + x).index();
          
            var tbClientJobSheduling = '';
            tbClientJobSheduling = localStorage.getItem("tbClientAddtnlJobs");//Retrieve the stored data      
            tbClientJobSheduling = JSON.parse(tbClientJobSheduling); //Converts string to object

            if (tbClientJobSheduling == null) //If there is no data, initialize an empty array
                tbClientJobSheduling = [];
            var detailId = document.getElementById("tdDtlId" + x).innerHTML;
            if (detailId == "") {
                var AsmntId = document.getElementById("txtselectorAsmnt" + x).value;
            }
            else {
                var AsmntId = detailId;
            }

            var ShdlLvlId = document.getElementById("tdSchdlIdAsmnt" + x).innerHTML;
            var evt = document.getElementById("tdEvt" + x).innerHTML;
            var TableId = document.getElementById("tdTableId" + x).innerHTML;


            if (evt == 'INS') {

                var $add = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    SCHDLID: "" + ShdlLvlId + "",
                    ASMNTID: "" + AsmntId + "",
                    SCORE: $add("#txtselectorScore" + x).val(),
                    EVTACTION: "" + evt + "",
                    DTLID: "0",
                    TBLID: "0"

                });
            }
            else if (evt == 'UPD') {

                var $add = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    SCHDLID: "" + ShdlLvlId + "",
                    ASMNTID: "" + AsmntId + "",
                    SCORE: $add("#txtselectorScore" + x).val(),
                    EVTACTION: "" + evt + "",
                    DTLID: "" + detailId + "",
                    TBLID: "" + TableId + ""
                });
            }

           
            tbClientJobSheduling.push(client); 
            localStorage.setItem("tbClientAddtnlJobs", JSON.stringify(tbClientJobSheduling));
            $add("#cphMain_HiddenFieldAddtnlJobs").val(JSON.stringify(tbClientJobSheduling));

            document.getElementById("tdSave" + x).innerHTML = "saved";
            //alert(document.getElementById("<%=HiddenFieldAddtnlJobs.ClientID%>").value);
            return true;

        }
        function LocalStorageDeletejobAddtnl(row_index, x, TableName) {

           
            var tbClientJobSheduling = '';
            tbClientJobSheduling = localStorage.getItem("tbClientAddtnlJobs");//Retrieve the stored data
            tbClientJobSheduling = JSON.parse(tbClientJobSheduling); //Converts string to object

            if (tbClientJobSheduling == null) //If there is no data, initialize an empty array
                tbClientJobSheduling = [];

            tbClientJobSheduling.splice(row_index, 1);
            localStorage.setItem("tbClientAddtnlJobs", JSON.stringify(tbClientJobSheduling));


            var evt = document.getElementById("tdEvt" + x).innerHTML;
            if (evt == 'UPD') {
                var detailId = document.getElementById("tdDtlId" + x).innerHTML;

                if (detailId != '') {
                    var CanclIds = document.getElementById("<%=HiddenFieldCancelAddtnJobDtlId.ClientID%>").value;

                      if (CanclIds == '') {
                          document.getElementById("<%=HiddenFieldCancelAddtnJobDtlId.ClientID%>").value = detailId;

                    }
                    else {

                        document.getElementById("<%=HiddenFieldCancelAddtnJobDtlId.ClientID%>").value = document.getElementById("<%=HiddenFieldCancelAddtnJobDtlId.ClientID%>").value + ',' + detailId;
                    }

                }
            }

            var CanclRowNum = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;

            if (CanclRowNum == '') {
                document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value = x;

            }
            else {

                document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value + ',' + x;
            }

           // alert(document.getElementById("<%=HiddenFieldAddtnlJobs.ClientID%>").value);
        }

        function LocalStorageEditjobAddtnl(x,row_index) {
           
           
            var tbClientJobSheduling = '';
            tbClientJobSheduling = localStorage.getItem("tbClientAddtnlJobs");//Retrieve the stored data
            tbClientJobSheduling = JSON.parse(tbClientJobSheduling); //Converts string to object

            if (tbClientJobSheduling == null) //If there is no data, initialize an empty array
                tbClientJobSheduling = [];
            var detailId = document.getElementById("tdDtlId" + x).innerHTML;
            if (detailId == "") {
                var AsmntId = document.getElementById("txtselectorAsmnt" + x).value;
            }
            else {
                var AsmntId = detailId;
            }

            var evt = document.getElementById("tdEvt" + x).innerHTML;
            var ShdlLvlId = document.getElementById("tdSchdlIdAsmnt" + x).innerHTML;
            var TableId = document.getElementById("tdTableId" + x).innerHTML;
            //alert(evt); 
            if (evt == 'INS') {
              
                var $E = jQuery.noConflict();
                tbClientJobSheduling[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    SCHDLID: "" + ShdlLvlId + "",
                    ASMNTID: "" + AsmntId + "",
                    SCORE: $E("#txtselectorScore" + x).val(),
                    EVTACTION: "" + evt + "",
                    DTLID: "0",
                    TBLID: "0"

                });
            }
            else if (evt == 'UPD') {
                var $E = jQuery.noConflict();
                tbClientJobSheduling[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    SCHDLID: "" + ShdlLvlId + "",
                    ASMNTID: "" + AsmntId + "",
                    SCORE: $E("#txtselectorScore" + x).val(),
                    EVTACTION: "" + evt + "",
                    DTLID: "" + detailId + "",
                    TBLID: "" + TableId + ""

                });
            }

            localStorage.setItem("tbClientAddtnlJobs", JSON.stringify(tbClientJobSheduling));
            $E("#cphMain_HiddenFieldAddtnlJobs").val(JSON.stringify(tbClientJobSheduling));
          // alert(document.getElementById("<%=HiddenFieldAddtnlJobs.ClientID%>").value);
            return true;
        }
    </script>
    <script>
        function validateSubmit() {


            var ret = true;
            //if (CheckIsRepeat() == true) {

            //}
            //else {
            //    ret = false;
            //    return ret;
            //}
            //alert('validate');

            document.getElementById('divErrorNotificationSb').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "";

          
             var rowcount = document.getElementById("<%=HiddenFieldAsmntRowCount.ClientID%>").value;
             var DeleteRowNumData = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;
             var DeleteRowNum = DeleteRowNumData.split(',');
             var count = DeleteRowNum.length;
             var NoRows = $p('#TableAddtnlJobs tr').length - 1;
             for (var x = rowcount; x > 0 ; x--) {

                 var deleSTS = "false";
                 for (var i = 0; i < count; i++) {
                     if (x == DeleteRowNum[i]) {
                         deleSTS = "true";
                     }
                 }


                 if (deleSTS == "false") {

                     for (var i = 0; i < count; i++) {
                         if (rowcount == DeleteRowNum[i]) {
                             var STS = "true";
                         }
                     }


                     if (STS != "true") {
                         var FrmTime = document.getElementById("txtselectorAsmnt" + rowcount).value;
                         var ToTime = document.getElementById("txtselectorScore" + rowcount).value;
                       
                         if (x == rowcount && FrmTime == "0" && ToTime == "0" ) {
                         }
                         else {

                             document.getElementById("txtselectorAsmnt" + x).style.borderColor = "";
                           

                             var FrmTime = document.getElementById("txtselectorAsmnt" + x).value;
                             if (FrmTime == "0" ) {
                                 document.getElementById("txtselectorAsmnt" + x).style.borderColor = "Red";
                                 document.getElementById("txtselectorAsmnt" + x).focus();
                                 document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                                 document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                                ret = false;

                            }
                          
                        }
                    }
                    else {
                        

                         document.getElementById("txtselectorAsmnt" + x).style.borderColor = "";


                         var FrmTime = document.getElementById("txtselectorAsmnt" + x).value;
                         if (FrmTime == "0") {
                             document.getElementById("txtselectorAsmnt" + x).style.borderColor = "Red";
                             document.getElementById("txtselectorAsmnt" + x).focus();
                             document.getElementById('divErrorNotificationSb').style.visibility = "visible";
                             document.getElementById("<%=lblErrorNotificationSb.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                             ret = false;

                             }

                    }

                }
            }

            //alert('true');


             if (ret == false) {

                 CheckSubmitZero();

             }
             else {

                 //alert('hidden level');
                 var tbClientJobSheduling = '';
                 tbClientJobSheduling = [];
                 var rowCount = $p('#ReportTableSchdl tr').length - 1;
                 for (var x = 0; x < rowCount; x++) {


                     var JobSbmnDtTimeFrom = document.getElementById("ddlscore" + x).value;
                     var JobSbmnDtTimeTo = document.getElementById("ddlDecsn" + x).value;
                     var JobSbmnPesntMlg = document.getElementById("dateIntvew" + x).value.trim();

                     //if (JobSbmnPesntMlg != "" && JobSbmnDtTimeTo != "0" && JobSbmnDtTimeFrom != "0") {
                     var saveAsmnt = document.getElementById("savedAsmnt" + x).innerHTML;
                     var scdlId = document.getElementById("SchdlId" + x).innerHTML;
                     var TableId = document.getElementById("savedLvl" + x).innerHTML;
                     var IntervwrId = document.getElementById("intervrId" + x).innerHTML;

                     var $add = jQuery.noConflict();
                     var client = JSON.stringify({
                         SCHDLID: "" + scdlId + "",
                         SAVEASMNT: "" + saveAsmnt + "",
                         SCOREID: $add("#ddlscore" + x).val(),
                         DECSNID: $add("#ddlDecsn" + x).val(),
                         DATEINTVEW: $add("#dateIntvew" + x).val(),
                         INTERVWRID: "" + IntervwrId + "",
                         TBLID: "" + TableId + ""
                     });
                     tbClientJobSheduling.push(client);
                     //}
                 }
                 $add("#cphMain_HiddenFieldJobSbmsnDtls").val(JSON.stringify(tbClientJobSheduling));
                 //CloseAsmnt();
                 //document.getElementById('divErrorNotificationSd').style.visibility = "visible";
                 //alert('hiiii');
                 var rowcount = document.getElementById("<%=HiddenFieldAsmntRowCount.ClientID%>").value;
                 var DeleteRowNumData = document.getElementById("<%=HiddenFieldCancelAddtnJobRowNum.ClientID%>").value;
                 var DeleteRowNum = DeleteRowNumData.split(',');
                 var count = DeleteRowNum.length;
                 var tbClientJobSheduling = '';
                 tbClientJobSheduling = [];
             
                 document.getElementById("<%=HiddenFieldAddtnlJobs.ClientID%>").value = "";                
                 for (var x = 1; x <= rowcount ; x++) {
                    
                     var deleSTS = "false";
                     for (var i = 0; i < count; i++) {
                         if (x == DeleteRowNum[i]) {
                             deleSTS = "true";
                         }
                     }

                     if (deleSTS == "false") {

                         var detailId = document.getElementById("tdDtlId" + x).innerHTML;
                         if (detailId == "") {
                             var AsmntId = document.getElementById("txtselectorAsmnt" + x).value;
                         }
                         else {
                             var AsmntId = detailId;
                         }

                         var ShdlLvlId = document.getElementById("tdSchdlIdAsmnt" + x).innerHTML;
                         var evt = document.getElementById("tdEvt" + x).innerHTML;
                         var TableId = document.getElementById("tdTableId" + x).innerHTML;


                         if (evt == 'INS' && AsmntId!="0") {

                             var $add = jQuery.noConflict();
                             var client = JSON.stringify({
                                 ROWID: "" + x + "",
                                 SCHDLID: "" + ShdlLvlId + "",
                                 ASMNTID: "" + AsmntId + "",
                                 SCORE: $add("#txtselectorScore" + x).val(),
                                 EVTACTION: "" + evt + "",
                                 DTLID: "0",
                                 TBLID: "0"

                             });
                             tbClientJobSheduling.push(client);
                         }
                         
                     }

                                     
                 }
                 $add("#cphMain_HiddenFieldAddtnlJobs").val(JSON.stringify(tbClientJobSheduling));
                
              
                // alert(document.getElementById("<%=HiddenFieldAddtnlJobs.ClientID%>").value);

                //document.getElementById("<%=lblErrorNotificationSd.ClientID%>").innerHTML = "Assessment Points Details Inserted Successfully.";
                 document.getElementById("<%=HiddenFieldScoreDdl.ClientID%>").value = "";
                 document.getElementById("<%=HiddenFieldSenderButton.ClientID%>").value = "asmnt";
             }


             return ret;
         }

    </script>

    <script>
        function isTagDate(event) {

            //    alert("The Unicode key code is: " + event.keyCode);
            var keyCodes = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            var charCode = (event.which) ? event.which : event.keyCodes;
            // alert('isTagDate');

            //    alert(keyCodes);
            if (keyCodes == 13) {
                return false;

            }
                //0-9
            else if (keyCodes >= 48 && keyCodes <= 57) {
                return true;
            }
                //numpad 0-9
            else if (keyCodes >= 96 && keyCodes <= 105) {
                return true;
            }
                //left arrow key,right arrow key,home,end ,delete
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40 || keyCodes == 17 || keyCodes == 67 || keyCodes == 86) {
                return true;

            }
                // -   given or as'-' have different keycode in browsers
            else if (keyCodes == 173 || keyCodes == 189) {
                return true;

            }

            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    return false;
                }
                return ret;
            }


        }


        function DateCheck(obj, x, rtn) {


            document.getElementById('divErrorNotificationSd').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotificationSd.ClientID%>").innerHTML = "";


            document.getElementById(obj + x).style.borderColor = "";
            var ret = true;
            var Val = document.getElementById(obj + x).value;
            var Rcptdate = document.getElementById(obj + x).value;


            if (Rcptdate == "") {
                ret = false;
            }
            else {
                var RCPTdata = Rcptdate.split("-");
                if (isNaN(parseInt(RCPTdata[0])) == true || isNaN(parseInt(RCPTdata[1])) == true || isNaN(parseInt(RCPTdata[2])) == true) {
                    ret = false;
                   
                }
                else {

                   
                    if (isNaN(Date.parse(RCPTdata[2] + "-" + RCPTdata[1] + "-" + RCPTdata[0]))) {
                        ret = false;
                      
                    }
                    else {

                       
                        var FormatDatearr = Rcptdate.split("-");
                        var txtDay = FormatDatearr[0];
                        var txtMonth = FormatDatearr[1];
                        var txtYear = FormatDatearr[2];

                        if (txtDay < 10) {
                            txtDay = "0" + parseInt(txtDay);
                        }
                        if (txtMonth < 10) {
                            txtMonth = "0" + parseInt(txtMonth);
                        }


                        document.getElementById(obj + x).value = txtDay + '-' + txtMonth + '-' + txtYear;
                       
                        if (isNaN(Date.parse(txtYear + "-" + txtMonth + "-" + txtDay))) {                         
                            ret = false;                        
                        }
                       
                    }

                }
               
                if (ret == false) {

                    document.getElementById('divErrorNotificationSd').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotificationSd.ClientID%>").innerHTML = "Please enter a valid date !";
                    document.getElementById(obj + x).style.borderColor = "Red";
                    document.getElementById(obj + x).focus();
                }
            }



            if (ret == false) {

               

                document.getElementById(obj + x).value = "";
            }

              
            else {

              
               
                var RcptdatepickerDate = Rcptdate;
                var RarrDatePickerDate = RcptdatepickerDate.split("-");
                var RdateDateCntrlr = new Date(RarrDatePickerDate[2], RarrDatePickerDate[1] - 1, RarrDatePickerDate[0]);
              

                var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                if (RdateDateCntrlr > dateCurrentDate) {
                    document.getElementById('divErrorNotificationSd').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotificationSd.ClientID%>").innerHTML = "Sorry, date of interview cannot be greater than current date !.";
                    document.getElementById(obj + x).style.borderColor = "Red";
                    document.getElementById(obj + x).focus();
                }
               
            }
            if (rtn == true) {
                IncrmntConfrmCounter();
                return ret;
            }
        }



        function BlurJSTime(obj, x) {
          
            if (DateCheck(obj, x, true) == true) {
                return true;
            }
        }

        function validateSchdlLvl() {

            var ret = true;
            if (CheckIsRepeatPR() == true) {

            }
            else {
                ret = false;
                return ret;
            }

           // document.getElementById("cphMain_btnAdd").style.display = "none";
            document.getElementById('divErrorNotificationSd').style.visibility = "hidden";
            document.getElementById("<%=lblErrorNotificationSd.ClientID%>").innerHTML = "";

            var rowcount = $p('#ReportTableSchdl tr').length -1;
         
            var trcount = $p('#ReportTableSchdl td').length - 1;   //emp25
        
            if (trcount == 0) {
                
                document.getElementById('divErrorNotificationSd').style.visibility = "visible";
                
                document.getElementById("<%=lblErrorNotificationSd.ClientID%>").innerHTML = " No data avalilable , Please select an interview panel !";

                return false;
            }

            for (var i = rowcount-1; i >= 0; i--) {

                document.getElementById("ddlscore" + i).style.borderColor = "";
                document.getElementById("ddlDecsn" + i).style.borderColor = "";
                document.getElementById("dateIntvew" + i).style.borderColor = "";


                var ScoreChckSts = document.getElementById("ScoreChck" + i).innerHTML;
                var JobSbmnDtTimeFrom = document.getElementById("ddlscore" + i).value;
                var JobSbmnDtTimeTo = document.getElementById("ddlDecsn" + i).value;
                var JobSbmnPesntMlg = document.getElementById("dateIntvew" + i).value.trim();
                var validteLvl = document.getElementById("ValidateLvl" + i).innerHTML;
            
                if (validteLvl == "1") {
                    if (JobSbmnDtTimeTo != "") {
                        document.getElementById("cphMain_btnAdd").style.display = "block";

                    }

                    if (document.getElementById("ddlDecsn" + i).disabled == false) {
                        if (JobSbmnPesntMlg == "") {

                            document.getElementById("dateIntvew" + i).style.borderColor = "red";
                            //document.getElementById("dateIntvew" + i).focus();
                            document.getElementById('divErrorNotificationSd').style.visibility = "visible";
                            document.getElementById("<%=lblErrorNotificationSd.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            ret = false;
                        }
                        else {

                            var RcptdatepickerDate = JobSbmnPesntMlg;
                            var RarrDatePickerDate = RcptdatepickerDate.split("-");
                            var RdateDateCntrlr = new Date(RarrDatePickerDate[2], RarrDatePickerDate[1] - 1, RarrDatePickerDate[0]);


                var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                if (RdateDateCntrlr > dateCurrentDate) {
                    document.getElementById('divErrorNotificationSd').style.visibility = "visible";
                    document.getElementById("<%=lblErrorNotificationSd.ClientID%>").innerHTML = "Sorry, date of interview cannot be greater than current date !.";
                    document.getElementById("dateIntvew" + i).style.borderColor = "red";
                    //document.getElementById("dateIntvew" + i).focus();
                    ret = false;
                }

                        }




                        if (JobSbmnDtTimeTo == "0") {
                            document.getElementById("ddlDecsn" + i).style.borderColor = "red";
                            document.getElementById("ddlDecsn" + i).focus();
                            document.getElementById('divErrorNotificationSd').style.visibility = "visible";
                            document.getElementById("<%=lblErrorNotificationSd.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            ret = false;
                        }
                        if (ScoreChckSts == "1") {
                            if (JobSbmnDtTimeFrom == "0") {

                                document.getElementById("ddlscore" + i).style.borderColor = "red";
                                document.getElementById("ddlscore" + i).focus();
                                document.getElementById('divErrorNotificationSd').style.visibility = "visible";
                                document.getElementById("<%=lblErrorNotificationSd.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                                ret = false;

                            }
                        }

                    }

                }
                else {
                    if (JobSbmnPesntMlg != "" || JobSbmnDtTimeTo != "0" || JobSbmnDtTimeFrom != "0") {
                        if (JobSbmnPesntMlg == "") {

                            document.getElementById("dateIntvew" + i).style.borderColor = "red";
                            //document.getElementById("dateIntvew" + i).focus();
                            document.getElementById('divErrorNotificationSd').style.visibility = "visible";
                            document.getElementById("<%=lblErrorNotificationSd.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            ret = false;
                        }

                        else {

                            var RcptdatepickerDate = JobSbmnPesntMlg;
                            var RarrDatePickerDate = RcptdatepickerDate.split("-");
                            var RdateDateCntrlr = new Date(RarrDatePickerDate[2], RarrDatePickerDate[1] - 1, RarrDatePickerDate[0]);


                            var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                            var arrCurrentDate = CurrentDateDate.split("-");
                            var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                            if (RdateDateCntrlr > dateCurrentDate) {
                                document.getElementById('divErrorNotificationSd').style.visibility = "visible";
                                document.getElementById("<%=lblErrorNotificationSd.ClientID%>").innerHTML = "Sorry, date of interview cannot be greater than current date !.";
                    document.getElementById("dateIntvew" + i).style.borderColor = "red";
                    //document.getElementById("dateIntvew" + i).focus();
                    ret = false;
                }

            }
                        if (JobSbmnDtTimeTo == "0") {
                            document.getElementById("ddlDecsn" + i).style.borderColor = "red";
                            document.getElementById("ddlDecsn" + i).focus();
                            document.getElementById('divErrorNotificationSd').style.visibility = "visible";
                            document.getElementById("<%=lblErrorNotificationSd.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            ret = false;
                        }
                        if (ScoreChckSts == "1") {
                            if (JobSbmnDtTimeFrom == "0") {

                                document.getElementById("ddlscore" + i).style.borderColor = "red";
                                document.getElementById("ddlscore" + i).focus();
                                document.getElementById('divErrorNotificationSd').style.visibility = "visible";
                                document.getElementById("<%=lblErrorNotificationSd.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                                ret = false;

                            }
                        }
                    }
                   

                }



            }

            if (ret == true) {


                //For job submission table
                var tbClientJobSheduling = '';
                tbClientJobSheduling = [];
                var rowCount = $p('#ReportTableSchdl tr').length - 1;
                for (var x = 0; x < rowCount; x++) {


                    var JobSbmnDtTimeFrom = document.getElementById("ddlscore" + x).value;
                    var JobSbmnDtTimeTo = document.getElementById("ddlDecsn" + x).value;
                    var JobSbmnPesntMlg = document.getElementById("dateIntvew" + x).value.trim();

                    //if (JobSbmnPesntMlg != "" && JobSbmnDtTimeTo != "0" && JobSbmnDtTimeFrom != "0") {
                    var saveAsmnt = document.getElementById("savedAsmnt" + x).innerHTML;
                    var scdlId = document.getElementById("SchdlId" + x).innerHTML;
                    var TableId = document.getElementById("savedLvl" + x).innerHTML;
                    var IntervwrId = document.getElementById("intervrId" + x).innerHTML;

                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        SCHDLID: ""+scdlId+"",
                        SAVEASMNT: "" + saveAsmnt + "",
                        SCOREID: $add("#ddlscore" + x).val(),
                        DECSNID: $add("#ddlDecsn" + x).val(),
                        DATEINTVEW: $add("#dateIntvew" + x).val(),
                        INTERVWRID: "" + IntervwrId + "",
                        TBLID: "" + TableId + ""
                    });
                    tbClientJobSheduling.push(client);
                //}
                }
                $add("#cphMain_HiddenFieldJobSbmsnDtls").val(JSON.stringify(tbClientJobSheduling));

            }


            if (ret == false) {
              
                CheckSubmitZeroPR();

            }
            else {
                document.getElementById("<%=HiddenFieldScoreDdl.ClientID%>").value = "";
                document.getElementById("<%=HiddenFieldSenderButton.ClientID%>").value = "schdl";
                
            }
          
            return ret;

        }


    </script>
      <script>



          //validation when cancel process
          function ValidateCancelReason() {
              // replacing < and > tags
              var NameWithoutReplace = document.getElementById("<%=txtCnclReason.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtCnclReason.ClientID%>").value = replaceText2;

             var divErrorMsg = document.getElementById('divErrorRsnAWMS').style.visibility = "hidden";
             var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "";
             var Reason = document.getElementById("<%=txtCnclReason.ClientID%>").value.trim();
             if (Reason == "") {
                 document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                 document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Please fill this out";
                 document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                 return false;
             }
             else {
                 Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                 Reason = Reason.replace(/[ ]{2,}/gi, " ");
                 Reason = Reason.replace(/\n /, "\n");
                 if (Reason.length < "10") {
                     document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                     document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Close reason should be minimum 10 characters";
                     var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                     return false;
                 }
             }
              document.getElementById("<%=HiddenFieldScoreDdl.ClientID%>").value = "";
         }
          function clearScore() {
              document.getElementById("<%=HiddenFieldScoreDdl.ClientID%>").value = "";
          }
          function CloseCancelView() {
              if (confirm("Do you want to close  without completing closing process?")) {
                  document.getElementById('divMessageArea').style.display = "none";
                  document.getElementById('imgMessageArea').src = "";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  document.getElementById("MymodalCancelView").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";
              }
              return false;
        }

          function OpenCancelView() {

              document.getElementById("MymodalCancelView").style.display = "block";
              document.getElementById("freezelayer").style.display = "";
              document.getElementById("<%=txtCnclReason.ClientID%>").focus();
              return false;

        }

          function SuccessAsnmnt() {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Assessment points details inserted successfully.";
          }
        function SuccessSave() {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Interview process details inserted successfully.";
        }
        function SuccessReopen() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Interview process details reopened successfully.";
        }
        function SuccessHold() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Interview process details holded successfully.";
        }
        function SuccessClose() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Interview process details closed successfully.";
        }

    </script>
     <style>
          .MyModalJobShedule {
    display: none;
    position: fixed;
    z-index: 100;
    padding-top: 0%;
    left: 8%;
    top: 8%;
    width: 84%;
    height: 88%;
    overflow: auto;
    background-color: white;
    border: 3px solid;
    border-color: #6f7b5a;
}
           #divErrorNotificationSb {
   border-radius: 8px;
background: #fff;
padding: 0px;
font-weight: bold;
text-align: center;
font-size: 17px;
color: #53844E;
margin-top: 4.5%;
font-family: Calibri;
border: 2px solid #53844E;
width: 99%;
margin-bottom: 2%;
}
#divErrorNotificationSd {
    border-radius: 8px;
    background: #fff;
    padding: 0px;
    font-weight: bold;
    text-align: center;
    font-size: 17px;
    color: #53844E;
    margin-top: 14%;
    font-family: Calibri;
    border: 2px solid #53844E;
    height: 21px;
    width: 91.5%;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="HiddenFieldReqrmntId" runat="server" />
    <asp:HiddenField ID="HiddenFieldAsmntRowCount" runat="server" />
    <asp:HiddenField ID="HiddenFieldScoreDdl" runat="server" />
    <asp:HiddenField ID="HiddenFieldSchdlLvlId" runat="server" />
    <asp:HiddenField ID="HiddenFieldAddtnlJobs" runat="server" />
    <asp:HiddenField ID="HiddenFieldCancelAddtnJobDtlId" runat="server" />
     <asp:HiddenField ID="HiddenFieldCancelAddtnJobRowNum" runat="server" />
    <asp:HiddenField ID="HiddenFieldJobSbmsnDtls" runat="server" />
     <asp:HiddenField ID="HiddenFieldCandId" runat="server" />  
      <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
     <asp:HiddenField ID="HiddenFieldIntervewProcessId" runat="server" />
     <asp:HiddenField ID="HiddenFieldHoldStatus" runat="server" />
     <asp:HiddenField ID="HiddenFieldQryString" runat="server" />
     <asp:HiddenField ID="HiddenFieldSenderButton" runat="server" />
     <asp:HiddenField ID="HiddenFieldIns" runat="server" />
     <asp:HiddenField ID="HiddenFieldCtgryId" runat="server" />
     <asp:HiddenField ID="HiddenOrg" runat="server" />
     <asp:HiddenField ID="HiddenCorp" runat="server" />
    <asp:HiddenField ID="HiddenreqId" runat="server" />
    <asp:HiddenField ID="HiddenId" runat="server" />
    <div id="divMessageArea" style="display: none;width:100%;">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div class="cont_rght">

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: absolute; right: 5%; top: 43.5%; height: 26.5px;">
        </div>

        <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke;float:left;margin-bottom:1%;">
            <div id="divReportCaption" style="width:100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;float:left">
                <asp:Label ID="lblEntry" runat="server">Interview Process</asp:Label>
            </div>

            <div style="float: left; width: 80%;padding: 10px;margin-top: 2%;border: 1px solid #929292;background-color: #c9c9c9;font-family: Calibri;">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Ref#</h2>
                    <asp:Label ID="lblRefNum"  class="form1" runat="server" style="word-wrap: break-word;font-size:14px;font-family:Calibri;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Date Of Request</h2>
                    <asp:Label ID="lblDateOfReq" class="form1" runat="server" style="word-wrap: break-word;font-size:14px;font-family:Calibri;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">No.of Resources</h2>
                    <asp:Label ID="lblNumber" class="form1" runat="server" style="word-wrap: break-word;font-size:14px;font-family:Calibri;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Designation</h2>
                    <asp:Label ID="lblDesign" class="form1" runat="server" style="word-wrap: break-word;font-size:14px;font-family:Calibri;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Department</h2>
                    <asp:Label ID="lblDeprtmnt" class="form1" runat="server" style="word-wrap: break-word;font-size:14px;font-family:Calibri;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Project</h2>
                    <asp:Label ID="lblPrjct" class="form1" runat="server" style="word-wrap: break-word;font-size:14px;font-family:Calibri;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Experience</h2>
                    <asp:Label ID="lblExprnce" class="form1" runat="server" style="word-wrap: break-word;font-size:14px;font-family:Calibri;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Pay Grade</h2>
                    <asp:Label ID="lblPaygrd" class="form1" runat="server" style="word-wrap: break-word;font-size:14px;font-family:Calibri;"></asp:Label>
                </div>
            </div>


              <div style="cursor: default; float: right; height: 25px; margin-right:11.5%;margin-top:2.5%;font-family:Calibri;" class="print" onclick="printredirect()">            
                                 <a id="print_cap" target="_blank" data-title="Item Listing"  href="/Reports/Print/28_Print.htm" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
                                 Print</a>                                    
                                </div>

            <div id="divReportCaptionList" style="width:100%; font-size: 18px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;float:left;margin-top:2%;">
                <asp:Label ID="lblEntryList" runat="server">Shortlisted Candidate</asp:Label>
                <asp:Label ID="lblCount" runat="server" style="float:right;color:green;"></asp:Label>
            </div>

            <div id="divCandidateList"  runat="server" style="float:left;width:100%;margin-top: 2%;">

            </div>


            <div style="float:left;width: 20%;padding: 5px;margin-left: 37%;margin-top: 2%;">
                  <asp:Button ID="btnClose" runat="server" class="save" Text="Close"  OnClientClick="return OpenCancelView();" style="width:43%;" />
                  <asp:Button ID="btnOnHold" runat="server" class="save" Text="OnHold" OnClientClick="clearScore();" OnClick="btnOnHold_Click"   />
                  <asp:Button ID="btnReopen" runat="server" class="save" Text="ReOpen" OnClientClick="clearScore();" OnClick="btnReopen_Click"  style="margin-bottom:0%;" />
             </div>
              

            <div>

             <div id="divCandidateInfo" style="float: left; width: 80%;padding: 10px;margin-top: 2%;border: 1px solid #929292;background-color: #c9c9c9;display:none;font-family: Calibri;">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Candidate Name</h2>
                    <asp:Label ID="lblCandtName"  class="form1" runat="server" style="word-wrap: break-word;font-size:14px;font-family:Calibri;"></asp:Label> 
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Location</h2>
                    <asp:Label ID="lblLoctn" class="form1" runat="server" style="word-wrap: break-word;font-size:14px;font-family:Calibri;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Reference</h2>
                    <asp:Label ID="lblRefEmp" class="form1" runat="server" style="word-wrap: break-word;font-size:14px;font-family:Calibri;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Resume</h2>
                    <asp:Label ID="lblResume" class="form1" runat="server" style="word-wrap: break-word;font-size:14px;font-family:Calibri;"></asp:Label>
                </div>
                
                   <div style="cursor: default; float: right; height: 25px; margin-right:1.5%;margin-top:-1.5%;font-family:Calibri;" class="print" onclick="printredirect()">            
                                 <a id="A1" target="_blank" data-title="Item Listing"  href="/Reports/Print/29_Print.htm" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
                                 Print</a>                                    
                                </div>

            <div id="divCandInfoHead" style="width:100%; font-size: 18px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;float:left;margin-top:2%;">
                <asp:Label ID="lblCandInfoHead" runat="server">Evaluation</asp:Label>
            </div>

                <div id="divErrorNotificationSd" style="visibility: hidden">
                    <asp:Label ID="lblErrorNotificationSd" runat="server"></asp:Label>
                </div>

            <div id="divSchdlList"  runat="server" style="float:left;width:92%;margin-top: 1%;">

            </div>


            </div>
                     <div id="divPrintReport" runat="server" style="display: none">
                                    <br />
                                </div>
         <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
    </div>

                 <div id="divPrintReport1" runat="server" style="display: none">
                                    <br />
                                </div>
         <div id="divPrintCaption1" runat="server" style="display: none; height: 150px">
    </div>
        <div id="divtile" runat="server" style="display: none"></div>

             <div  id="divButtons" style="float: left; width: 10%;margin-top: 2%;border: 1px solid #929292;margin-left:2%;padding:1%;display:none;">

                 
                  <asp:Button ID="btnAdd" runat="server" class="cancel" Text="Save" OnClientClick="return validateSchdlLvl();" OnClick="btnAdd_Click" />
                  <asp:Button ID="btnClear" runat="server" class="cancel" Text="Clear" OnClientClick="return ConfirmClear();" />
                  <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel"  style="margin-bottom:0%;"  OnClientClick="return ConfirmMessage();" />
                  
             </div>
            </div>

        </div>
    </div>

    <style>
        .cont_rght {
            width: 100%;
        }
    .cancel {
    width:100%;
    margin-bottom:10%;

    }
       
    </style>



     <div id="MyModalJobSubmit" class="MyModalJobShedule" >
         <div id="divJobSubmit">
             <div id="divSubHeader" style="height: 30px;background-color: #6f7b5a;">
                 
            <label style="margin-left: 43%;font-size: 22px;color: #fff;font-family: calibri;">Assessment Points</label>

                   <img class="closeCancelView" style= "margin-top: .5%; margin-right: 1%;float: right; cursor: pointer;" onclick="CloseAsmnt();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
             </div>            
            
             <div id="divErrorNotificationSb" style="visibility: hidden">
                    <asp:Label ID="lblErrorNotificationSb" runat="server"></asp:Label>
                </div>

            
             <div id="divAddtnlJobs" style="float: left;width: 98%;margin-left: 1%;margin-top: 8px;padding: 11px;">
                 
                 <table class="TableHeader" rules="all" style="width: 90%;">
                        <tr>
                           
                            <%--<td style="font-size: 14px; width: 5%; padding-left: 0.5%; text-align: left;">SL#</td>--%>
                            <td style="font-size: 14px; width: 70%; padding-left: 0.5%; text-align: left;">Assessment Points</td>
                            <td style="font-size: 14px; width: 10%; padding-left: 0.5%; text-align: left;">Score (Out Of 10)</td>
                           

                        </tr>
                    </table>

                    <div style="width: 100%; min-height: 75px; overflow-y: auto;">
                        <table id="TableAddtnlJobs" style="width: 96%;">
                        </table>
                       
                    </div>
             </div>
            
                       

               <asp:Button ID="btnSubSave" class="save" runat="server" Text="Save" style="width: 90px; float:left;margin-left:37%;margin-top: 3%;" OnClientClick="return validateSubmit();"  OnClick="btnAdd_Click" />     
               <input type="button" id="btnSubCncl" class="save" style="width: 90px; float:left;margin-left:1%;margin-top: 3%;" onclick="CloseAsmnt();" value="Cancel" /> 

         </div>

         </div>



     <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 40%; padding-bottom: 0.7%; padding-top: 0.6%;">Interview Process</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Close Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="return CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>       





     <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: black; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.8; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>
    <style>
   #ReportTableSchdl {
    width: 99.9%;
}
 #ReportTableSchdl th,  #ReportTableSchdle td {
    -webkit-box-sizing: content-box;
    -moz-box-sizing: content-box;
    box-sizing: content-box;
}
 #ReportTableSchdl {
    width: 100%;
    margin: 0 auto;
    clear: both;
    border-collapse: collapse;
    border-spacing: 0;
}
.main_table {
    border: 1px solid #c9c9c9;
}
.main_table {
    width: 100%;
    height: 36px;
    margin: 0 0 35px;
    border-bottom: 1px solid #c9c9c9;
}

 #ReportTableSchdl tbody tr {
    background-color: #ffffff;
}
main_table > tbody > tr:nth-child(2n+1) > td, .main_table > tbody > tr:nth-child(2n+1) > th {
    height: 30px;
    background: #E9E9E9;
    font-size: 14px;
    color: #5c5c5e;
}
 #ReportTableSchdl tbody td {
    padding-top: 0px;
    padding-bottom: 0px;
    padding-left: 1%;
    padding-right: 1%;
}
 /*#ReportTableSchdl tbody th,  #ReportTableSchdl tbody td {
    padding: 7px 10px;
}*/

.tdT {
    height: 30px;
    padding: 0 0 0 14px;
    border-right: 1px solid #c9c9c9;
    font-family: Calibri;
    font-size: 14px;
}
.tabinnertable {
  
    border-collapse: collapse;
    width: 96%;
}

   .datepicker table tr td, .datepicker table tr th {
            text-align: center;
            width: 0px;
            height: 0px;
            border-radius: 4px;
            border: none;
        }

        .datepicker table tr td.disabled, .datepicker table tr td.disabled:hover {
            background: none;
            color: #c5c5c5;
            cursor: default;
        }
    </style>

</asp:Content>

