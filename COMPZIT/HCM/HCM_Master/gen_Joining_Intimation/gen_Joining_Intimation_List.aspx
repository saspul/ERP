<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gen_Joining_Intimation_List.aspx.cs" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" Inherits="HCM_HCM_Master_gen_Joining_Intimation_gen_Joining_Intimation_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <script src="../../../JavaScript/jquery_2.1.3_jquery_min.js"></script>
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

            <script src="/JavaScript/datepicker/bootstrap-datepicker.js"></script>
    <link href="/JavaScript/datepicker/datepicker3.css" rel="stylesheet" />


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="HiddenConsultancyId" runat="server" />
    <asp:HiddenField ID="HiddenFieldCbxCheck" runat="server" />
     <asp:HiddenField ID="HiddenPaygrdScale" runat="server" />
         <asp:HiddenField ID="hiddenCurrencyId" runat="server" />
             <asp:HiddenField ID="hiddenPaygrdFrm" runat="server" />
                 <asp:HiddenField ID="hiddenPaygrdTo" runat="server" />
                         <asp:HiddenField ID="hiddenDesgId" runat="server" />
                             <asp:HiddenField ID="hiddenPaygradeId" runat="server" />
                             <asp:HiddenField ID="hiddenExperience" runat="server" />
                                 <asp:HiddenField ID="hiddenParametersSelctd" runat="server" />


    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div class="cont_rght">

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 5%; top: 42%; height: 26.5px;">
        </div>

        <div style="width: 98%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke; float: left">
            <div id="divReportCaption" style="width: 100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; float: left">
                <asp:Label ID="lblEntry" runat="server">Candidate ShortListing</asp:Label>
            </div>

            <div style="float: left; width: 80%; padding: 10px; margin-top: 2%; border: 1px solid #929292; background-color: #c9c9c9;">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Ref#</h2>
                    <asp:Label ID="lblRefNum" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Date Of Request</h2>
                    <asp:Label ID="lblDateOfReq" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">No.of Resources</h2>
                    <asp:Label ID="lblNumber" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Designation</h2>
                    <asp:Label ID="lblDesign" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Department</h2>
                    <asp:Label ID="lblDeprtmnt" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Project</h2>
                    <asp:Label ID="lblPrjct" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Experience</h2>
                    <asp:Label ID="lblExprnce" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Pay Grade</h2>
                    <asp:Label ID="lblPaygrd" class="lblTop" runat="server"></asp:Label>
                </div>
            </div>

            <asp:HiddenField ID="HiddenreqstId" runat="server" />
            <asp:HiddenField ID="HiddenShortlistMasterid" runat="server" />
            <asp:HiddenField ID="HiddenStatus" runat="server" />
        </div>

        <div style="float: left; width: 100%; margin-top: 2%;">
        </div>


        <div id="divPayment" runat="server" style="display:none">

        </div>

        <div style="float: left; width: 100%; margin-top: 2%; ">
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
        <div class="eachform" style="width: 59%; margin-top: 3%; float: right">
            <asp:Button ID="btnAdd"  runat="server" class="cancel" Text="Send Intimation" OnClientClick="return Validate();" />


            <asp:Button ID="btnCancel"  runat="server" Style="margin-left: 19px;" class="cancel" OnClientClick="return AlertClearAll();" Text="Cancel" />
            <asp:Button ID="btnClear" runat="server" Style="margin-left: 19px;" OnClientClick="return ClearAll();" class="cancel" Text="Clear" />
            <asp:HiddenField ID="hiddenRowCount" runat="server" />
            <asp:HiddenField ID="Hiddenchecklist" runat="server" />
             <asp:HiddenField ID="HiddenImgLocation" runat="server" />

        </div>
    </div>
    <div id="myModalLoadingMail" class="modalLoadingMail">

        <!-- Modal content -->
        <div>

            <img src="/Images/Other Images/LoadingMail.gif" style="width: 12%;" />


        </div>

    </div>
    <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
        class="freezelayer" id="freezelayer">
    </div>


   <%-- Joining Date--%>

     <div id="MyModalProcessDate" class="MyModalProcessMultiple" style="padding-bottom:2%">
           <div>
                <div style="height: 30px; background-color: #6f7b5a;">
                    
                    <img class="closeCancelView" style="margin-top: .5%; margin-right: 1%; float: right; cursor: pointer;" onclick="return ClosePopup();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
                
                    <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;color: white;">Send Intimation</h3>
                
                </div>

                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                    </div>

              <div style="width: 100%;" class="eachform">
                  <div style="width: 66%; margin-top: 6.2%; margin-left:18%" class="eachform">
                      <h2 style="float:left;margin-top: 1%;">Join Date *</h2>
                      <asp:TextBox ID="txtJoinDt" style="margin-left:10%;float:left;width: 64%;" runat="server" placeholder="DD-MM-YYYY" class="form1" onkeypress="return DisableEnter(event)"></asp:TextBox>
                   </div>

               <div id="divParameters" style="float: left;margin-left: 17%;margin-top:1%;">

                    <table id="tableParamtrs" style="width:100%;overflow:auto;">
                     </table>

                   </div>

              <div style="width: 47%; margin-top: 7%; margin-left:36%" class="eachform">
                 <asp:Button ID="btnConfirm" runat="server" class="save" Text="Confirm" Style="width:55%;" OnClientClick="return ValidateDatePick();" OnClick="btnAdd_Click"/>
                  </div>
            </div>
          </div>
        </div>

    <%-- Joining Date--%>

    <script>
        $('.drop1').css({ opacity: 1.0, visibility: "visible" }).animate({ opacity: 0 }, 200);

        var $noC = jQuery.noConflict();

        $noC('#cphMain_txtJoinDt').datepicker({
            autoclose: true,
            format: 'dd-mm-yyyy',
            language: 'en',
            startDate: new Date()
        });


    </script>
    <style>
        .cont_rght {
            width: 97%;
        }

        .save {
            width: 100%;
        }


        .lblTop {
            width: 232px;
            padding: 0px 8px;
            border: 1px solid #cfcccc;
            float: right;
            color: #000;
            font-size: 14px;
            font-family: calibri;
            word-wrap: break-word;
        }

        .modalLoadingMail {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 30; /* Sit on top */
            padding-top: 19%; /* Location of the box */
            left: 0;
            top: 0;
            width: 90%; /* Full width */
            /*height: 58%;*/ /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: transparent;
            padding-left: 45%; /* Location of the box */
        }

        /* Modal Content */
        .modal-contentLoadingMail {
            /*position: relative;*/
            background-color: #fefefe;
            margin: auto;
            padding: 0;
            /*border: 1px solid #888;*/
            width: 95.6%;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
        }
    </style>
    <script language="javascript" type="text/javascript">
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

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {


            HideLoading();

            // var IdCheckboc="cblcandidatelist";
            document.getElementById('cblcandidatelist').focus();

        });
        function Validate() {
            var ret = true;
           

            document.getElementById('divMessageArea').style.display = "hidden";
            var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
           
            var strAmntList = "";
            var strAlreadySendList = "";
            
                 for (i = 0; i < RowCount; i++) {
                     // alert("dddddd");

                     if (document.getElementById('cblcandidatelist' + i).checked) {

                         //   alert(document.getElementById('tdcandiateid').innerHTML);
                         if (document.getElementById('tdSendStatus' + i).innerHTML != "SEND") {
                             if (strAmntList == "") {
                                 strAmntList =  document.getElementById('tdcandiateid' + i).innerHTML + ':' + document.getElementById('ddlJoiningSts' + i).value ;
                             }
                             else {
                                 strAmntList = strAmntList + ',' + document.getElementById('tdcandiateid' + i).innerHTML + ':' + document.getElementById('ddlJoiningSts' + i).value ;

                             }
                         }
                         else {
                             if (strAlreadySendList == "") {
                                 strAlreadySendList = document.getElementById('tdcandiateid' + i).innerHTML + ':' + document.getElementById('ddlJoiningSts' + i).value;

                             }
                             else {
                                 strAlreadySendList = strAlreadySendList + ',' + document.getElementById('tdcandiateid' + i).innerHTML + ':' + document.getElementById('ddlJoiningSts' + i).value;
                             }
                         }
                         
                     }
                 }
                
                 if (strAmntList != "" || strAlreadySendList !="") {
                     document.getElementById("<%=Hiddenchecklist.ClientID%>").value = strAmntList + ","+ strAlreadySendList;
                ret = true;
                 }
                 else {
                     ret = false;
                 }
            //   alert(document.getElementById("<%=Hiddenchecklist.ClientID%>").value);

            if (ret == false) {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please select atleast one candidate.";
                var $Mo = jQuery.noConflict();
                $Mo(window).scrollTop(0);
            }
            else {

                document.getElementById("<%=txtJoinDt.ClientID%>").value = "";

                ParametersLoad();

                document.getElementById("MyModalProcessDate").style.display = "block";
                document.getElementById("freezelayer").style.display = "";

                return false;
            }
            return ret;
        }

        function ValidateDatePick() {
            var ret = true;
            var JoinDt = document.getElementById("<%=txtJoinDt.ClientID%>").value;

            if (JoinDt == "") {
                document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Please fill this out";
                document.getElementById("<%=txtJoinDt.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtJoinDt.ClientID%>").focus();
                return false;
            }

            if (!JoinDt.match(/^(0[1-9]|[12][0-9]|3[01])[\- \/.](?:(0[1-9]|1[012])[\- \/.](201)[2-9]{1})$/)) {
                document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Please fill this out";
                document.getElementById("<%=txtJoinDt.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtJoinDt.ClientID%>").focus();
                return false;
            }

            else {
                if (confirm("Are you sure you want to confirm?")) {
                    document.getElementById("<%=txtJoinDt.ClientID%>").style.borderColor = "";

                    var tbClientTotalValues = '';
                    tbClientTotalValues = [];

                    var table = document.getElementById("tableParamtrs");

                    for (var i = 0; i < table.rows.length; i++) {

                            var $add = jQuery.noConflict();

                            var cbValue = 0;
                            if ($add("#cbxParamtr" + i).is(":checked")) {

                            var Id = document.getElementById("cbxParamtr" + i).value;
                            var Head = document.getElementById("head" + i).innerHTML;
                            var Descrptn = document.getElementById("txtDescrptn" + i).value;

                            if (Id != "") {

                                var client = JSON.stringify({
                                    HEADER_ID: "" + Id + "",
                                    HEADER_NAME: "" + Head + "",
                                    DESCRIPTN: "" + Descrptn + ""

                                });
                                tbClientTotalValues.push(client);
                            }
                        }
                    }
                    document.getElementById("<%=hiddenParametersSelctd.ClientID%>").value = JSON.stringify(tbClientTotalValues);

                    document.getElementById("MyModalProcessDate").style.display = "none";
                    document.getElementById("freezelayer").style.display = "none";

                    CheckSubmitZero();
                    $noC(document).scrollTop(0);

                    ShowLoading();
                }
                else {
                    document.getElementById("<%=txtJoinDt.ClientID%>").value = "";
                    return false;
                }
            }
            return ret;
        }

        function ShowLoading() {

            document.getElementById("myModalLoadingMail").style.display = "block";

            document.getElementById("freezelayer").style.display = "";
        }
        //EVm-0024
        function MissingCandidateMailID() {

            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Candidate mail ID is missing.";
        }
        //END
        function HideLoading() {

            document.getElementById("myModalLoadingMail").style.display = "none";

            document.getElementById("freezelayer").style.display = "none";
        }
        function SuccessConfirmation() {

            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Join intimation sent successfully.";
        }
        function SendingFailed() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Join intimation sending failed.";
        }
        function AlertClearAll() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href = "gen_Joining_Intimation.aspx";
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_Joining_Intimation.aspx";

            }
            return false;
        }

        function ClosePopup() {
            if (confirm("Are you sure you want to close this window")) {
                document.getElementById("<%=txtJoinDt.ClientID%>").value = "";
                document.getElementById("MyModalProcessDate").style.display = "none";
              document.getElementById("freezelayer").style.display = "none";
              return true;
          }
          else {
              return false;
          }
      }
    </script>
    <script>
        var confirmbox = 0;
        function ConfirmMessage() {
            if (confirmbox > 0) {
                if (confirm("Are You Sure You Want To Leave This Page?")) {
                    window.location.href = "gen_Joining_Intimation.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_Joining_Intimation.aspx";
                return false;
            }
        }
    </script>
    <script>
        function SuccessIns() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Candidate shortlist data inserted successfully.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Candidate shortlist data updated successfully.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }

    </script>
    <script type="text/javascript">
        function changeAll() {

            var RowCount = document.getElementById("<%=HiddenFieldCbxCheck.ClientID%>").value;


            IncrmntConfrmCounter();
                 if (document.getElementById("cblcandidatelist").checked == true) {


                     for (var i = 0; i < RowCount; i++) {
                         if (document.getElementById("cblcandidatelist" + i).disabled == false) {
                             document.getElementById("cblcandidatelist" + i).checked = true;
                         }

                     }



                 }
                 else {

                     for (var i = 0; i < RowCount; i++) {
                         if (document.getElementById("cblcandidatelist" + i).disabled == false) {
                             document.getElementById("cblcandidatelist" + i).checked = false;
                         }

                     }

                 }

                 return false;
             }
    </script>
    <script>
        function getselected() {
            var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
             var strcandiateid = "";
             for (i = 0; i < RowCount; i++) {
                 // alert("dddddd");

                 if (document.getElementById('cblcandidatelist' + i).checked) {

                     //   alert(document.getElementById('tdcandiateid').innerHTML);
                     strcandiateid = strAmntList + document.getElementById('tdcandiateid' + i).innerHTML + ',';

                 }
             }
             document.getElementById("<%=Hiddenchecklist.ClientID%>").value = strcandiateid;
             //   alert(document.getElementById("<%=Hiddenchecklist.ClientID%>").value);
             return true;
         }

        //evm-0019 Start
         var $noCon = jQuery.noConflict();
         $noCon(window).load(function () {

             localStorage.clear();
             document.getElementById("freezelayer").style.display = "none";

             $noCon(window).scrollTop(0);
         });


         var confirmbox = 0;

         function IncrmntConfrmCounter() {
             confirmbox++;
         }

         function IncrmntChange(ddlId, CandId,intRowId,Emailsts) {
            
             IncrmntConfrmCounter();

             if (confirm("Are you sure you want to change the status?")) {
                 var strSts = document.getElementById(ddlId).value;
                 var strId = "";
                 $co = jQuery.noConflict();
                 $co.ajax({
                     type: "POST",
                     async: false,
                     contentType: "application/json; charset=utf-8",
                     url: "gen_Joining_Intimation_List.aspx/JoiningStatus",
                     data: '{strSts:"' + strSts + '",strId:"' + CandId + '"}',

                    dataType: "json",
                     success: function (data) {
                         if (strSts == "0" || strSts == "1") {
                             if (Emailsts == 0) {
                                 document.getElementById("cblcandidatelist" + intRowId).disabled = false;
                             }
                             else {
                                 document.getElementById("cblcandidatelist" + intRowId).disabled = true;
                             }
                         }
                         else {
                             document.getElementById("cblcandidatelist" + intRowId).checked = false;
                             document.getElementById("cblcandidatelist" + intRowId).disabled = true;
                         }


                     },
                     error: function (response) {

                     }

                 });
             }

             else {

                 var id = document.getElementById("<%=HiddenStatus.ClientID%>").value;
               
                 window.location.href = "gen_Joining_Intimation_List.aspx?Id=" + id;
             }

         }
        //evm-0019 end
    </script>

     <script>
         function ParametersLoad() {

             var CorpId = '<%=Session["CORPOFFICEID"]%>';
              var OrgId = '<%=Session["ORGID"]%>';

             $noCon.ajax({
                  type: "POST",
                  url: "gen_Joining_Intimation_List.aspx/LoadParmtrsChkbox",
                  data: '{strCorpId : "' + CorpId + '",strOrgId : "' + OrgId + '"}',
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (response) {

                      var ChkBoxData = response.d;

                      $noCon("#tableParamtrs").empty();
                      if (ChkBoxData != "" && ChkBoxData != "[]") {
                          CounterTime = 0;
                          var EditAttchmnt = ChkBoxData;

                          var findAtt2 = '\\"\\[';
                          var reAtt2 = new RegExp(findAtt2, 'g');
                          var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');
                          var findAtt3 = '\\]\\"';
                          var reAtt3 = new RegExp(findAtt3, 'g');
                          var resAtt3 = resAtt2.replace(reAtt3, '\]');
                          var jsonAtt = $noCon.parseJSON(resAtt3);
                          for (var key in jsonAtt) {
                              if (jsonAtt.hasOwnProperty(key)) {
                                  if (jsonAtt[key].APPT_LTR_PARAM_ID != "") {

                                      LoadParameters(jsonAtt[key].APPT_LTR_PARAM_ID, jsonAtt[key].APPT_LTR_PARAM_HEAD, jsonAtt[key].APPT_LTR_PARAM_DESCRIPTION);

                                  }
                              }
                          }
                      }


                  },
                  error: function (response) {
                  }
              });
          }

         var Counter = 0;

          function LoadParameters(Id, Head, Descrptn) {

              var FrecRow = "";
              FrecRow = '<tr style="width:200px;"><td id="RowId_' + Counter + '" style="width:0%;display: none;" >' + Counter + '</td>';
              FrecRow += '<td style="width:0.5%; word-break: break-all; word-wrap: break-word;"><input type="checkbox" value=' + Id + '  id="cbxParamtr' + Counter + '"  onkeypress="return isTag(event)" checked="true" onkeydown="return DisableEnter(event)" onchange="return Changecbx(' + Counter + ');" style="float:left;"><h2 id="head' + Counter + '">' + Head + '</h2></td></tr>';
              FrecRow += '<tr id="trDescriptn' + Counter + '" style=""><td style="width:0.5%; word-break: break-all; word-wrap: break-word;float: left;"><textarea class="form-control" maxlength="980" Style="height:90px;width:370px;resize:none;border: 1px solid #cfcccc;font-family: calibri;" id="txtDescrptn' + Counter + '" onkeypress="return isTagEnter(event)" onblur="textCounter(\'txtDescrptn' + Counter + ',450\)" >' + Descrptn + '</textarea></td>';
              FrecRow += '</tr>';
              jQuery('#tableParamtrs').append(FrecRow);

              Counter++;

              return false;
          }

          function Changecbx(Counter) {

              if (document.getElementById("cbxParamtr" + Counter).checked == true) {

                  document.getElementById("trDescriptn" + Counter).style.display = "";
              }
              else {
                  document.getElementById("trDescriptn" + Counter).style.display = "none";
              }
          }


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

          function isTagEnter(evt) {

              evt = (evt) ? evt : window.event;
              var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

              var charCode = (evt.which) ? evt.which : evt.keyCode;
              var ret = true;
              if (charCode == 60 || charCode == 62) {
                  ret = false;
              }
              return ret;
          }

          function DisableEnter(evt) {

              evt = (evt) ? evt : window.event;
              var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
              if (keyCodes == 13) {
                  return false;
              }
          }

          function textCounter(field, maxlimit) {
              if (field.value.length > maxlimit) {
                  field.value = field.value.substring(0, maxlimit);
              } else {

              }
          }

    </script>


    <style>
        .tdT {
            height: 30px;
            padding: 0 0 0 8px;
            border-right: 1px solid #c9c9c9;
            font-family: Calibri;
            font-size: 14px;
        }

                 .MyModalProcessMultiple {
            display: none;
            position: fixed;
            z-index: 113;
            padding-top: 0%;
            left: 27%;
            top: 13%;
            width: 42%;
            height: 80%;
            /*overflow: auto;*/
            background-color: white;
            border: 3px solid;
            border-color: #6f7b5a;
        }

        .datepicker table tr td, .datepicker table tr th {
            text-align: center;
            width: 0px;
            height: 0px;
            border-radius: 4px;
            border: none;
        }

        .table > thead > tr > th {
            vertical-align: bottom;
            background: #7b7b7b;
            color: #fff;
        }

        .datepicker table tr td.disabled, .datepicker table tr td.disabled:hover {
            background: none;
            color: #c5c5c5;
            cursor: default;
        }

          #divErrorRsnAWMS {
              border-radius: 4px;
              background: #fff;
              color: #53844E;
              font-size: 12.5px;
              font-family: Calibri;
              font-weight: bold;
              border: 2px solid #53844E;
              margin-top: 2.5%;
              margin-bottom: 2%;
          }

        #divParameters {
            height: 285px;
            max-height: 290px;
            overflow-x: auto;
            overflow-y: auto;
            width: 70%;
            max-width: 70%;
        }

    </style>


     



</asp:Content>

