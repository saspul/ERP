<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage_Compzit_GMS.master" AutoEventWireup="true" CodeFile="gen_Bank_Guarantee.aspx.cs" Inherits="GMS_GMS_Master_gen_Bank_Guarantee_gen_Bank_Guarantee" %>

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
          .form1 {
              width: 232px;
              height: 31px;
              padding: 0px 8px;
              border: 1px solid #cfcccc;
              float: right;
              color: #000;
              font-size: 13px;
          }
          .form11
          {
              width: 232px;
              height: 26px;
              padding: 0px 8px;
              border: 1px solid #cfcccc;
              float: right;
              color: #000;
              font-size: 13px;
          }
          /*--------------------------------------------------for modal Cancel Reason------------------------------------------------------*/
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
              padding: 1% 4% 0% 4%;
          }

          .modal-footerCancelView {
              padding: 1.5% 1%;
              background-color: #91a172;
              color: white;
          }

          #divErrorRsnAWMS {
              border-radius: 4px;
              background: #fff;
              color: #53844E;
              font-size: 12.5px;
              font-family: Calibri;
              font-weight: bold;
              border: 2px solid #53844E;
              margin-top: 0%;
              margin-bottom: 0%;
          }
      </style>
  <style>
      .cont_rght {
          width: 98%;
      }

      .GreySection {
          background-color: #efefef;
          border: 1px solid;
          border-color: #cfcfcf;
          padding: 15px;
          height: auto;
      }

      .eachform h2 {
          margin: 8px 0 6px;
      }

      #divAwardedContainer {
          width: 46%;
          float: right;
          margin-top: -17%;
          margin-left: 3%;
          border: 1px solid;
          height: auto;
          border-color: #11839c;
          background-color: white;
          min-height: 180px;
      }

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
  </style>
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

         input[type="radio"] {
             display: inline-block;
         }

         .imgDescription {
             position: absolute;
             /*top: 511px;
            left: 6.5%;*/
             background: rgb(154, 163, 138);
             visibility: hidden;
             opacity: 0;
             padding: 0.1%;
             font-family: Calibri;
             /*remove comment if you want a gradual transition between states
  -webkit-transition: visibility opacity 0.2s;
  */
         }

         .imgWrap:hover .imgDescription {
             visibility: visible;
             opacity: 1;
         }
     </style>
     <style>
         /*for file upload*/
         input[type="file"] {
             position: relative;
             z-index: 1;
             margin-left: -78px;
             display: none;
         }

         .AnchorAttachmntEdit, .AnchorAttachmntEdit:hover, .AnchorAttachmntEdit:focus {
             color: #1884c7;
             font-family: OpenSans Regular;
         }

         .custom-file-upload {
             border: 1px solid #ccc;
             display: inline-block;
             padding: 3px 8px;
             cursor: pointer;
             position: relative;
             z-index: 2;
             background: white;
         }

         #scrollToTop {
             cursor: pointer;
             background-color: #97c83a;
             display: inline-block;
             height: 40px;
             width: 40px;
             color: #fff;
             font-size: 16pt;
             text-align: center;
             text-decoration: none;
             line-height: 40px;
             border-radius: 35px;
         }

         .textareaa {
             height: 28px;
             padding: 0px 4px;
             border: 1px solid #cfcccc;
             float: right;
             color: #000;
             font-family: Calibri;
             font-size: 15px;
             border-radius: 0px;
             width: 282px;
             background-color: #e3e3e3;
             cursor: auto;
         }

                        #DivTemplateContainer {
    width: 90%;
    min-height: 200px;
    float: left;
    margin-left: 5%;
    border: 1px solid;
    border-color: #0b9aab;
    background: #fffcf2;
}
                input[type="radio"] {
    display: inline-block;
}



                .ClearDur{
    font-family: Calibri;
    font-size: 12px;
    color: #45ff00;
    padding: 5px 18px 5px;
    margin: 0 11px 6px 2px;
    line-height: 1;
    font-weight: normal;
    float: left;
    background: #1280a4;
    border: none;
    border-radius: 2px;
    cursor: pointer;
    text-transform: uppercase;
}


        .clsSmallDiv {
             border: 1px solid;
             padding: 2px;
             border-color: #229ed8;
         }

         select[disabled], textarea[disabled], input[readonly], select[readonly], textarea[readonly] {
             cursor: not-allowed;
             background-color: #eee;
         }
     </style>

   <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

           <script>
               function addCommas() {

                   nStr = document.getElementById("<%=txtAmount.ClientID%>").value;
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




                   if (isNaN(x2))
                       document.getElementById("<%=txtAmount.ClientID%>").value = x1;
                       //return x1;
                   else
                       document.getElementById("<%=txtAmount.ClientID%>").value = x1 + "." + x2;
                   // return x1 + "." + x2;
                   document.getElementById("<%=HiddenFieldAmount.ClientID%>").value = document.getElementById("<%=txtAmount.ClientID%>").value;
               }

    </script>
       <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            ChangeDivDisplays();

            document.getElementById("freezelayer").style.display = "none";
            document.getElementById('MymodalCancelView').style.display = "none";

            localStorage.clear();

            GuaranteeLoadFunction();

            InsuranceLoadFunction();

        });


        function GuaranteeLoadFunction() {


            // var myDiv = document.getElementById("divfileupl");

            // myDiv.scrollTop = myDiv.scrollHeight;



            var importchk = document.getElementById("<%=HiddenImportaddchk.ClientID%>").value;
            /// alert(importchk);
            if (document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
                document.getElementById("divfleupld").style.display = "";
                // document.getElementById("divfileupl").style.display = "";
            }

            if (document.getElementById("<%=HiddenFieldChckUpdate.ClientID%>").value == "1" || document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value == "1" || document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {

                if (document.getElementById("<%=hiddenEditAttchmnt.ClientID%>").value != "") {


                    var EditAttchmnt = document.getElementById("<%=hiddenEditAttchmnt.ClientID%>").value;

                    //        var findAtt1 = '\\\\';
                    //        var reAtt1 = new RegExp(findAtt1, 'g');
                    //        var resAtt1 = EditAttchmnt.replace(reAtt1, '');

                    var findAtt2 = '\\"\\[';
                    var reAtt2 = new RegExp(findAtt2, 'g');
                    var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                    var findAtt3 = '\\]\\"';
                    var reAtt3 = new RegExp(findAtt3, 'g');
                    var resAtt3 = resAtt2.replace(reAtt3, '\]');
                    //alert(res3);
                    var jsonAtt = $noCon.parseJSON(resAtt3);
                    for (var key in jsonAtt) {
                        if (jsonAtt.hasOwnProperty(key)) {
                            if (jsonAtt[key].PictureAttchmntDtlId != "") {


                                AddAttachment(jsonAtt[key].PictureAttchmntDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                //  alert(json[key].Amount);
                            }
                        }
                    }


                    if (document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value != "1") {
                        AddFileUpload();
                    }

                    document.getElementById("<%=hiddenValueChangeNtfr.ClientID%>").value = "0";
                    if (document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
                        document.getElementById("divfleupld").style.display = "block";
                        AddFileUpload();
                        // document.getElementById("divfileupl").style.display = "";
                    }

                }
                else {

                    if (document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value == "1") {
                        //alert("none");

                        if (document.getElementById("<%=HiddenRenew.ClientID%>").value != "1") {
                            document.getElementById("divfleupld").style.display = "none";

                            // document.getElementById("divfileupl").style.display = "";
                        }
                        else {
                            AddFileUpload();
                        }



                        //document.getElementById("divFileuploadScroll").style.display = "none";

                    }
                }
            }
            else {

                if (document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value != "1") {
                    AddFileUpload();
                }
                if (document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
                    AddFileUpload();
                }

            }

            //if (CancelPrimaryId != "") {
            //    OpenCancelView();
            // }


            if (document.getElementById("<%=radioClient.ClientID%>").checked == true) {

                document.getElementById("<%=ddlGteeType.ClientID%>").focus();

                document.getElementById("DivGrntyTypeDrpDwn").style.display = "none";
                document.getElementById("DivGrntyTyplabl").style.display = "";
                document.getElementById("divSubContract").style.display = "none";
                // if (document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value == "") {
                //document.getElementById("<%=txtAmount.ClientID%>").disabled = true;
                //  }
                document.getElementById("h2cuscontractr").innerHTML = 'Customer*';
                document.getElementById("<%=LblProject.ClientID%>").style.display = "none";
                document.getElementById("<%=LabelCustmrContrctr.ClientID%>").style.display = "none";
                document.getElementById("<%=ddlCustomerList.ClientID%>").style.display = "";
                //document.getElementById("Currencyddl").style.display = "none";
                //document.getElementById("CurrencyLabl").style.display = "";
                document.getElementById("imgImport").onmouseup = true;
                document.getElementById("imgImport").onmousedown = true;
                document.getElementById("imgImport").onclick = OpenImport;
                document.getElementById("imgImport").style.opacity = "";
                document.getElementById("ImportrfgLabel").style.opacity = "";
                if (document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value == "1" || document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
                    document.getElementById("<%=HiddenImportaddchk.ClientID%>").value = "1";
                    document.getElementById("imgImport").onmouseup = false;
                    document.getElementById("imgImport").onmousedown = false;
                    document.getElementById("imgImport").onclick = false;
                    document.getElementById("imgImport").style.opacity = .2;
                    document.getElementById("ImportrfgLabel").style.opacity = .2;

                }

                if (document.getElementById("<%=HiddenGuarStatus.ClientID%>").value == "2") {
                    document.getElementById("imgImport").onmouseup = false;
                    document.getElementById("imgImport").onmousedown = false;
                    document.getElementById("imgImport").onclick = false;
                    document.getElementById("imgImport").style.opacity = .2;
                    document.getElementById("ImportrfgLabel").style.opacity = .2;

                }
                if (document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
                    document.getElementById("imgImport").onmouseup = false;
                    document.getElementById("imgImport").onmousedown = false;
                    document.getElementById("imgImport").onclick = false;
                    document.getElementById("imgImport").style.opacity = .2;
                    document.getElementById("ImportrfgLabel").style.opacity = .2;

                }

            }

            else if (document.getElementById("<%=radioSuplier.ClientID%>").checked == true) {

                document.getElementById("<%=ddlGuarntyp.ClientID%>").focus();
                document.getElementById("DivGrntyTypeDrpDwn").style.display = "";
                document.getElementById("DivGrntyTyplabl").style.display = "none";
                document.getElementById("divSubContract").style.display = "";
                document.getElementById("imgImport").onmouseup = false;
                document.getElementById("imgImport").onmousedown = false;
                document.getElementById("imgImport").onclick = false;
                document.getElementById("imgImport").style.opacity = .2;
                document.getElementById("ImportrfgLabel").style.opacity = .2;
                if (document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value == "" || document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
                    document.getElementById("<%=txtAmount.ClientID%>").disabled = false;
                }
                document.getElementById("h2cuscontractr").innerHTML = 'Contractor';

                //  if (document.getElementById("<%=HiddenSubContractSlct.ClientID%>").value != "1") {
                //    document.getElementById("<%=LabelCustmrContrctr.ClientID%>").innerHTML = 'Contractor';
                // }
                //document.getElementById("CurrencyLabl").style.display = "none";
                // document.getElementById("Currencyddl").style.display = "";
                document.getElementById("<%=LblProject.ClientID%>").style.display = "";
                document.getElementById("<%=LabelCustmrContrctr.ClientID%>").style.display = "";
                document.getElementById("<%=ddlCustomerList.ClientID%>").style.display = "none";
                document.getElementById("divProjectsDdl").style.display = "none";
            }
            if (document.getElementById("<%=cbxExistingEmployee.ClientID%>").checked == false) {

                //IncrmntConfrmCounter();
                document.getElementById("divExistingEmp").style.display = "none";
                document.getElementById("divNewEmp").style.display = "";


            }
            else {
                //IncrmntConfrmCounter();
                document.getElementById("divNewEmp").style.display = "none";
                document.getElementById("divExistingEmp").style.display = "";

            }

            if (document.getElementById("<%=cbxPrjct.ClientID%>").checked == true) {
                document.getElementById("divSelectProjct").style.display = "";
                document.getElementById("divNewPrjct").style.display = "none";
            }
            else {
                document.getElementById("divNewPrjct").style.display = "";
                document.getElementById("divSelectProjct").style.display = "none";
            }

            if (document.getElementById("<%=radioLimited.ClientID%>").checked == true) {
                //document.getElementById("<%=txtValidity.ClientID%>").disabled = false;
                document.getElementById("img1").disabled = false;

                if (document.getElementById("<%=HiddenFieldChckUpdate.ClientID%>").value == "1") {

                    document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = false;
                }
                if (document.getElementById("<%=HiddenGuarStatus.ClientID%>").value == "2") {
                    document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;
                    document.getElementById("img1").disabled = true;
                    document.getElementById("<%=txtAmount.ClientID%>").disabled = true;
                }
                if (document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
                    // if (document.getElementById("<%=HiddenGuarStatus.ClientID%>").value == "2") {
                    document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = false;
                    document.getElementById("img1").disabled = false;
                    document.getElementById("<%=txtAmount.ClientID%>").disabled = false;
                    //}
                }
                else {
                    if (document.getElementById("<%=HiddenFieldChckUpdate.ClientID%>").value == "1") {
                        document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = false;
                        document.getElementById("img1").disabled = false;
                    } else {

                        document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;
                        document.getElementById("img1").disabled = true;
                    }
                }
                //document.getElementById("<%=txtAmount.ClientID%>").disabled = false;
            }
            else if (document.getElementById("<%=radioOpen.ClientID%>").checked == true) {
                //   document.getElementById("<%=txtValidity.ClientID%>").disabled = true;
                document.getElementById("img1").disabled = true;
                document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;
                if (document.getElementById("<%=HiddenGuarStatus.ClientID%>").value == "2") {

                    document.getElementById("<%=txtAmount.ClientID%>").disabled = true;
                }
                if (document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
                    //  if (document.getElementById("<%=HiddenGuarStatus.ClientID%>").value == "2") {

                    document.getElementById("<%=txtAmount.ClientID%>").disabled = false;
                    document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;
                    document.getElementById("img1").disabled = true;
                    // }
                }
                else {
                    document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;
                    document.getElementById("img1").disabled = true;
                }
                // document.getElementById("<%=txtAmount.ClientID%>").disabled = false;
            }

            if (document.getElementById("<%=HiddenDuplictnchk.ClientID%>").value == "1") {

                document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = false;
                document.getElementById("img1").disabled = false;
                TextDateChange();
            }

            AmountChecking('cphMain_txtAmount');

            addCommas();

            if (document.getElementById("<%=hiddenTemplateLoadingMode.ClientID%>").value == "FromTemp") {

                if (document.getElementById("<%=hiddenEachTemplateDetail.ClientID%>").value != 0) {
                    var EditEachTemplate = document.getElementById("<%=hiddenEachTemplateDetail.ClientID%>").value;
                    var findAtt2 = '\\"\\[';
                    var reAtt2 = new RegExp(findAtt2, 'g');
                    var resAtt2 = EditEachTemplate.replace(reAtt2, '\[');

                    var findAtt3 = '\\]\\"';
                    var reAtt3 = new RegExp(findAtt3, 'g');
                    var resAtt3 = resAtt2.replace(reAtt3, '\]');
                    //alert(res3);
                    var jsonAtt = $noCon.parseJSON(resAtt3);
                    for (var key in jsonAtt) {
                        if (jsonAtt.hasOwnProperty(key)) {

                            if (jsonAtt[key].TempDetailId != "") {

                                //   alert(jsonAtt[key].ActualFileName);
                                EditMoreEachTemplate(jsonAtt[key].TempDetailId, jsonAtt[key].NotifyMod, jsonAtt[key].NotifyVia, jsonAtt[key].NotifyDur);



                                //  alert(json[key].Amount);
                            }
                        }
                    }


                }
                else {

                    addMoreEachTemplate();
                }
            }
            else if (document.getElementById("<%=hiddenTemplateLoadingMode.ClientID%>").value == "FromBnk") {
                if (document.getElementById("<%=hiddenEachTemplateDetail.ClientID%>").value != 0) {
                    var EditEachTemplate = document.getElementById("<%=hiddenEachTemplateDetail.ClientID%>").value;
                    var findAtt2 = '\\"\\[';
                    var reAtt2 = new RegExp(findAtt2, 'g');
                    var resAtt2 = EditEachTemplate.replace(reAtt2, '\[');

                    var findAtt3 = '\\]\\"';
                    var reAtt3 = new RegExp(findAtt3, 'g');
                    var resAtt3 = resAtt2.replace(reAtt3, '\]');

                    var jsonAtt = $noCon.parseJSON(resAtt3);
                    for (var key in jsonAtt) {
                        if (jsonAtt.hasOwnProperty(key)) {

                            if (jsonAtt[key].TempDetailId != "") {


                                EditMoreEachTemplateBnk(jsonAtt[key].TempDetailId, jsonAtt[key].NotifyMod, jsonAtt[key].NotifyVia, jsonAtt[key].NotifyDur);

                            }
                        }
                    }


                }
                else {

                    addMoreEachTemplate();
                }
            }
            if (document.getElementById("<%=hiddenEachTemplateDetail.ClientID%>").value == 0) {
                clearhidd();
            }
            //  document.getElementById("<%=HiddenImportaddchk.ClientID%>").value=importchk;


        }


    </script>
    <script src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="../../../css/Autocomplete/jquery-ui.css" rel="stylesheet" />
   
       <script>




           var $au = jQuery.noConflict();

           (function ($au) {
               $au(function () {
                 
                   $au('#cphMain_ddlOwnershp').selectToAutocomplete1Letter();
                   //re
                   if (document.getElementById("<%=cbxPrjct.ClientID%>").checked == true) {
                       $au('#cphMain_ddlProjects').selectToAutocomplete1Letter();
                   }
                   $au('#cphMain_ddlBank').selectToAutocomplete1Letter();
                   
               
                   $au('form').submit(function () {

                   


                       //   return false;
                   });
               });
           })(jQuery);





                    </script>
    <script>







        var Filecounter = 0;

        function AddFileUpload() {


            var FrecRow = '<tr id="FilerowId_' + Filecounter + '" >';



            var labelForStyle = '<label  for="file' + Filecounter + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
            var tdInner = labelForStyle + '<input   id="file' + Filecounter + '" name = "file' + Filecounter +

                           '" type="file" onchange="ChangeFile(\'' + Filecounter + '\')" accept="image/*,.pdf,.jpeg,.jpg,.png"/>';

            FrecRow += '<td style="width:22%;border:none;padding-left: 3%;" >' + tdInner + '</td>';


            //var tdInner = labelForStyle + '<input   id="textbx' + Filecounter + '" name = "textbx' + Filecounter +

            //              '" type="text" class="inptxt"  MaxLength="250" style="text-transform:uppercase;" />';


            FrecRow += '<td style="font-family: Calibri;border-right:none;width: 37%;word-break: break-all;" id="filePath' + Filecounter + '"  ></td  >';

            FrecRow += '<td style="width: 23%;border:none;" > <input   id="textbx' + Filecounter + '" name = "textbx' + Filecounter +

     '" type="text" class="form1" placeholder="Caption"  MaxLength="100" onkeypress="return isTag(event);" onkeydown="return DisableEnter(event);" onfocus="prevValueChk(\'' + Filecounter + '\');"  onblur="LinkChangeFile(\'' + Filecounter + '\',event);"  style="text-transform:uppercase;" /> </td>';

            //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

            //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';

            FrecRow += '<td id="FileIndvlAddMoreRow' + Filecounter + '"  style="width: 1.5%;border:none; padding-left: 4px;"> <input type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFiles(\'' + Filecounter + '\');" style="  cursor: pointer;"></td>';
            FrecRow += '<td style="width: 1.5%;border:none; padding-left: 1px;"><input type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUpload(\'' + Filecounter + '\');"    style=" cursor: pointer;" ></td><br/>';


            FrecRow += ' <td id="FileInx' + Filecounter + '" style="display: none;" ></td>';
            FrecRow += '<td id="FileSave' + Filecounter + '" style="display: none;"></td>';
            FrecRow += '<td id="FileEvt' + Filecounter + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId' + Filecounter + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName' + Filecounter + '" style="display: none;"></td>';
            FrecRow += '</tr>';
            // FrecRow += '<tr id="FilerowId2_' + Filecounter + '" >';

            //FrecRow += '</tr>';
            jQuery('#TableFileUploadContainer').append(FrecRow);

            document.getElementById('filePath' + Filecounter).innerHTML = 'No File Selected';
            // $('#divFileuploadScroll').scrollTop($('#divFileuploadScroll')[0].scrollHeight);

            $('#divfileupl').scrollTop($('#divfileupl')[0].scrollHeight);
            Filecounter++;

        }


        function AddAttachment(editTransDtlId, EditFileName, EditActualFileName, EditImageLink, ImgPostn, DivId) {

            

            var FrecRow = '<tr id="FilerowId_' + Filecounter + '" >';

            var labelForStyle = '<label  for="file' + Filecounter + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
            var tdInner = labelForStyle + '<input   id="file' + Filecounter + '" name = "file' + Filecounter +

                          '" type="file" onchange="ChangeFile(\'' + Filecounter + '\')" />';

            FrecRow += '<td style="width:22%;border:none;padding-left: 3%;display:none;" >' + tdInner + '</td>';


            var tdFileNameEdit = '<a class="AnchorAttachmntEdit" style="word-wrap: break-word;" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

            FrecRow += '<td colspan="2" id="filePath' + Filecounter + '" style="font-family: Calibri;;border-right:none;border-bottom: 1px dotted rgb(205, 237, 196);word-break: break-all;"' + '  ><div style="width: 93%;float: right;">' + tdFileNameEdit + '</div></td >';

            FrecRow += '<td style="width: 23%;border:none;" > <input   id="textbx' + Filecounter + '" name = "textbx' + Filecounter +

     '" type="text"  disabled="true" class="form1" value=\'' + EditImageLink + '\' MaxLength="100"  onblur="LinkChangeFile(\'' + Filecounter + '\',event);" style="text-transform:uppercase;" /> </td>';
            //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

            //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';

            FrecRow += '<td id="FileIndvlAddMoreRow' + Filecounter + '"  style="width: 1.5%; padding-left: 4px;border:none;"> <input type="image"  class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFiles(\'' + Filecounter + '\');" style="  cursor: pointer;"></td>';
            FrecRow += '<td style="width: 1.5%; padding-left: 1px;border:none;"><input type="image" AutoPostBack="true" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete" onclick = "return RemoveFileUpload(\'' + Filecounter + '\');" style=" cursor: pointer;" ></td>';

           

            FrecRow += ' <td id="FileInx' + Filecounter + '" style="display: none;" ></td>';
            FrecRow += '<td id="FileSave' + Filecounter + '" style="display: none;"></td>';
            FrecRow += '<td id="FileEvt' + Filecounter + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId' + Filecounter + '" style="display: none;">' + editTransDtlId + '</td>';
            FrecRow += '<td id="DbFileName' + Filecounter + '" style="display: none;">' + EditFileName + '</td>';

            FrecRow += '</tr>';


            jQuery('#TableFileUploadContainer').append(FrecRow);

     
            document.getElementById("FileInx" + Filecounter).innerHTML = Filecounter;
            document.getElementById("FileIndvlAddMoreRow" + Filecounter).style.opacity = "0.3";




            // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
            FileLocalStorageAdd(Filecounter);
            Filecounter++;

        }




    </script>
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

         var confirmbox = 0;

         function IncrmntConfrmCounter() {
             confirmbox++;
         }
         function OpenImport() {
             var $Mo = jQuery.noConflict();


             //var GuaranteCustomer = document.getElementById("<%=ddlSuplCus.ClientID%>").value;
             // var GuaranteMode = document.getElementById("<%=ddlGuaranteeMde.ClientID%>").value;

             document.getElementById("<%=ddlGuaranteeMde.ClientID%>").selectedIndex = "0";
             document.getElementById("<%=ddlSuplCus.ClientID%>").selectedIndex = "0";
             //   var Moddl = document.getElementById("<%=ddlGuaranteeMde.ClientID%>");
             // Moddl.options[Moddl.selectedIndex].value = 0;

             var varOrgId = document.getElementById("<%=HiddenOrgansId.ClientID%>").value;
             var varCorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
             var varUserId = document.getElementById("<%=HiddenUserId.ClientID%>").value;

             $Mo.ajax({

                 type: "POST",
                 async: false,
                 contentType: "application/json; charset=utf-8",
                 url: "gen_Bank_Guarantee.aspx/ReadReqstListClient",
                 data: '{StrOrgId:"' + varOrgId + '",StrCorpId:"' + varCorpId + '",StrUserId:"' + varUserId + '"}',
                 dataType: "json",
                 success: function (data) {

                     if (data.d != '') {

                        
                         // vardata = data.d;
                         // $Mo('#divReport').html(data.d);


                         document.getElementById('divReport').innerHTML = data.d;

                     }

                 },
                 error: function (result) {
                    
                 }
             });



             OpenCancelView();

         }

         function ConfirmMessage() {
             if (confirmbox > 0) {
                 if (confirm("Are you sure you want to leave this page?")) {
                     window.location.href = "gen_Bank_Guarantee_List.aspx";
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Bank_Guarantee_List.aspx";

             }
         }
         function AlertClearAll() {
             if (confirmbox > 0) {
                 if (confirm("Are you sure you want clear all data in this page?")) {
                     window.location.href = "gen_Bank_Guarantee.aspx";
                     return false;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Bank_Guarantee.aspx";
                 return false;
             }
         }
         function Alertrenew()
         {
             if (confirm("Are you sure you want renew the bank guarantee?")) {
                 // window.location.href = "gen_Bank_Guarantee.aspx";
                 var ret = Validate();

                 if (ret == true) {
                     return true;
                 }
                 else
                     return false;
             }
             else {
                 return false;
             }

         }

         function SuccessGuaranteeRenewed() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Bank guarantee details renewed successfully.";
         }

         function SuccessUpdation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Bank guarantee details updated successfully.";
         }
         function SuccessUpdationPrjct() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Bank guarantee updated successfully.";
         }

         function SuccessConfirmation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Bank guarantee details inserted successfully.";
         }
         function SuccessConfirmationCntrct() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Bank guarantee inserted successfully.";
         }
         function SuccessConfirmationPrjct() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Bank guarantee inserted successfully.";
         }

         function SuccessReOpen() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Bank guarantee details reopened successfully.";
         }
         function SuccessConfirm() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Bank guarantee details confirmed successfully.";
         }
         function StsChkClsRenew() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Renew denied.entry is already closed.";
         }
         function StsChkReopnRenew() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Renew denied.entry is already re-opened.";
         }
         

         function Autocomplete() {
             $au('#cphMain_ddlOwnershp').selectToAutocomplete1Letter();
           //  $au('#cphMain_ddlExistingEmp').selectToAutocomplete1Letter();
             //$au('#cphMain_ddlSubContrct').selectToAutocomplete1Letter();
             if (document.getElementById("<%=cbxExistingEmployee.ClientID%>").checked == false) {

                 document.getElementById("divExistingEmp").style.display = "none";
                 document.getElementById("divNewEmp").style.display = "";

             }
             else {

                 document.getElementById("divNewEmp").style.display = "none";
                 document.getElementById("divExistingEmp").style.display = "";


             }
         }
    </script>
      <script type="text/javascript" >
          function isNumber(evt, textboxid) {
              evt = (evt) ? evt : window.event;
              var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
              var charCode = (evt.which) ? evt.which : evt.keyCode;

              var txtPerVal = document.getElementById(textboxid).value;
              //enter
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
                  // . period and numpad . period
              else if (keyCodes == 190 || keyCodes == 110) {
                  var ret = true;
                  if (textboxid == "cphMain_txtAmount") {
                      var count = txtPerVal.split('.').length - 1;

                      if (count > 0) {

                          ret = false;
                      }
                      else {
                          ret = true;
                      }
                      return ret;
                  }
                  else {
                      return false;
                  }

              }

              else {
                  var ret = true;
                  if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                      ret = false;
                  }
                  return ret;
              }
          }

          function AmountChecking(textboxid) {
              var txtPerVal = document.getElementById(textboxid).value;

              txtPerVal = txtPerVal.replace(/,/g, "");



              if (txtPerVal == "") {
                  return false;
              }
              else {
                  if (!isNaN(txtPerVal) == false) {
                      document.getElementById('' + textboxid + '').value = "";
                      return false;
                  }
                  else {
                      if (txtPerVal < 0) {
                          document.getElementById('' + textboxid + '').value = "";
                          return false;
                      }
                      var amt = parseFloat(txtPerVal);
                      var num = amt;
                      var n = 0;
                      // for floatting number adjustment from corp global
                      var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                      if (FloatingValue != "") {
                          var n = num.toFixed(FloatingValue);
                      }
                      document.getElementById('' + textboxid + '').value = n;

                  }
              }

              addCommas();
          }

          // for not allowing <> tags  and enter
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
          function isTagOnly(evt) {

              evt = (evt) ? evt : window.event;
              var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
              var charCode = (evt.which) ? evt.which : evt.keyCode;
              var ret = true;
              if (charCode == 60 || charCode == 62) {
                  ret = false;
              }
              return ret;
          }
          // for not allowing <> tags
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



          function Validate() {
              //alert(document.getElementById("<%=ddlOwnershp.ClientID%>").value);
              document.getElementById("<%=HiddenOwnership.ClientID%>").value = document.getElementById("<%=ddlOwnershp.ClientID%>").value;
              var ret = true;
              if (CheckIsRepeat() == true) {
              }
              else {
                  ret = false;
                  return ret;
              }
              document.getElementById('divMessageArea').style.display = "none";
              document.getElementById('imgMessageArea').src = "";
              if (document.getElementById("<%=HiddenGurntNumDupChk.ClientID%>").value == "1")
              {
                  Duplication();
                  CheckSubmitZero();
                  return false;
              }
              // replacing < and > tags
              var NameWithoutReplace = document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtOpngDate.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtOpngDate.ClientID%>").value = replaceText2;


              var NameWithoutReplace = document.getElementById("<%=txtGuarnteno.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtGuarnteno.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtAmount.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtAmount.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtadress.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtadress.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtSubjct.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtSubjct.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtDescrptn.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtDescrptn.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtEmpName.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtEmpName.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtCntctMail.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtCntctMail.ClientID%>").value = replaceText2;


              var NameWithoutReplace = document.getElementById("<%=txtRemarks.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtRemarks.ClientID%>").value = replaceText2;


              document.getElementById("<%=txtPrjctClsngDate.ClientID%>").style.borderColor = "";
             document.getElementById("<%=txtOpngDate.ClientID%>").style.borderColor = "";
             document.getElementById("<%=txtGuarnteno.ClientID%>").style.borderColor = "";
             document.getElementById("<%=txtAmount.ClientID%>").style.borderColor = "";
             document.getElementById("<%=txtadress.ClientID%>").style.borderColor = "";
             document.getElementById("<%=txtSubjct.ClientID%>").style.borderColor = "";
             document.getElementById("<%=txtDescrptn.ClientID%>").style.borderColor = "";
             document.getElementById("<%=txtEmpName.ClientID%>").style.borderColor = "";
             document.getElementById("<%=txtCntctMail.ClientID%>").style.borderColor = "";

             document.getElementById("<%=GuarTypeContainer.ClientID%>").style.border = "none";
             $noCon("div#divProject input.ui-autocomplete-input").css("borderColor", "");
             $noCon("div#divCustomer input.ui-autocomplete-input").css("borderColor", "");
             $noCon("div#divGuaranteCat input.ui-autocomplete-input").css("borderColor", "");
             $noCon("div#divCurrency input.ui-autocomplete-input").css("borderColor", "");
             $noCon("div#divSubContract input.ui-autocomplete-input").css("borderColor", "");
             document.getElementById("<%=ddlTemplate.ClientID%>").style.borderColor = "";


             var Validity = document.getElementById("<%=txtValidity.ClientID%>").value.trim();
              var Amount = document.getElementById("<%=txtAmount.ClientID%>").value.trim();
             var CloseDate = document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value.trim();
             var opengDate = document.getElementById("<%=txtOpngDate.ClientID%>").value.trim();
             var GuarnteNo = document.getElementById("<%=txtGuarnteno.ClientID%>").value.trim();
             var Address = document.getElementById("<%=txtadress.ClientID%>").value.trim();


             var GurMethd = document.getElementById("<%=ddlGuarntyp.ClientID%>");
             var GuarMEthdText = GurMethd.options[GurMethd.selectedIndex].text;

             var GurMethd2 = document.getElementById("<%=ddlGteeType.ClientID%>");
             var GuarMEthdText2 = GurMethd2.options[GurMethd2.selectedIndex].text;


             var SubContrct = document.getElementById("<%=ddlSubContrct.ClientID%>");
              var SubContrctText = SubContrct.options[SubContrct.selectedIndex].text;

              var GurCurrency = document.getElementById("<%=ddlCurrency.ClientID%>");
              var GurCurrencyText = GurCurrency.options[GurCurrency.selectedIndex].text;


              var GurBank = document.getElementById("<%=ddlBank.ClientID%>");
              var GurBankText = GurBank.options[GurBank.selectedIndex].text;

             

              var ddlOwner = document.getElementById("<%=ddlOwnershp.ClientID%>");
              var ddlOwnershpText = ddlOwner.options[ddlOwner.selectedIndex].value;

              var ddlExistEmp = document.getElementById("<%=ddlExistingEmp.ClientID%>");
              var ddlExistEmpText = ddlExistEmp.options[ddlExistEmp.selectedIndex].value;

              var ddlTemplate = document.getElementById("<%=ddlTemplate.ClientID%>");
              var ddlTemplateText = ddlTemplate.options[ddlTemplate.selectedIndex].value;

              var ContactEmail = document.getElementById("<%=txtCntctMail.ClientID%>").value;
              var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

              document.getElementById('divMessageArea').style.display = "none";
              document.getElementById('imgMessageArea').src = "";


              var tbClientImageValidation = localStorage.getItem("tbClientImageValidation");//Retrieve the stored data

              tbClientImageValidation = JSON.parse(tbClientImageValidation); //Converts string to object

              if (tbClientImageValidation == null) //If there is no data, initialize an empty array
                  tbClientImageValidation = [];



              for (var i = 0; i < tbClientImageValidation.length; i++) {

                  var rowid = tbClientImageValidation[i];
                  rowid = rowid.split(":");
                  rowid = rowid[1];
                  rowid = rowid.replace(/"/g, "");
                  rowid = rowid.replace(/}/g, "");
                
                  if (CheckValidation(rowid)) {

                      ret = true;

                  }
                  else {
                      ret = false;
                      break;
                  }

              }

              if (ContactEmail != "") {
                  if (!filter.test(ContactEmail)) {

                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please Enter A Valid Email Address.";
                      document.getElementById("<%=txtCntctMail.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=txtCntctMail.ClientID%>").focus();
                      ret = false;
                  }
                  else {

                      document.getElementById("<%=txtCntctMail.ClientID%>").style.borderColor = "";
                  }

              }


              if (ddlTemplateText == "--SELECT TEMPLATE--") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=ddlTemplate.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=ddlTemplate.ClientID%>").focus();
                  ret = false;
              }

              if (Address == "") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txtadress.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtadress.ClientID%>").focus();
                  ret = false;
              }
              else {
                  document.getElementById("<%=txtadress.ClientID%>").style.borderColor = "";
              }
              //removed ddlOwner checking from here
              



              if (document.getElementById("<%=radioLimited.ClientID%>").checked == true) {


                 if (CloseDate == "") {

                     document.getElementById('divMessageArea').style.display = "";
                     document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                     document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                      document.getElementById("<%=txtPrjctClsngDate.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=txtPrjctClsngDate.ClientID%>").focus();
                      ret = false;
                  }

                  else {

                      var presentdate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                      var arrpresentdate = presentdate.split("-");
                      var datepresentdate = new Date(arrpresentdate[2], arrpresentdate[1] - 1, arrpresentdate[0]);


                      document.getElementById("<%=txtPrjctClsngDate.ClientID%>").style.borderColor = "";
                      var TaskdatepickerDate = document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value;
                      var arrDatePickerDate = TaskdatepickerDate.split("-");
                      var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                      // var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                      var arrCurrentDate = opengDate.split("-");
                      var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);
                      if (dateDateCntrlr < dateCurrentDate) {
                          document.getElementById("<%=txtPrjctClsngDate.ClientID%>").style.borderColor = "Red";
                          document.getElementById("<%=txtPrjctClsngDate.ClientID%>").focus();
                          document.getElementById('divMessageArea').style.display = "";
                          document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                          document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, Expiry Date should be greater than Guarantee Date !";
                          ret = false;

                      }
                      // if (document.getElementById("<%=HiddenRenew.ClientID%>").value == "1")
                      // {
                      if (dateDateCntrlr < datepresentdate) {
                          // document.getElementById("<%=txtPrjctClsngDate.ClientID%>").style.borderColor = "Red";
                          //    document.getElementById("<%=txtPrjctClsngDate.ClientID%>").focus();
                          //   document.getElementById('divMessageArea').style.display = "";
                          //   document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                          // document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, Expiry Date should be greater or equal to the Current Date !";
                          // ret = false;
                          if (confirm("Bank guarantee has expired already. Are you sure you want to continue?")) {
                              // ret = true;
                          }
                          else {

                              // CheckSubmitZero();
                              ret = false;
                          }

                      }

                      // }
                  }
              }

              if (opengDate == "") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                      document.getElementById("<%=txtOpngDate.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=txtOpngDate.ClientID%>").focus();
                      ret = false;
                  }
                  else {

                      document.getElementById("<%=txtOpngDate.ClientID%>").style.borderColor = "";
                  }






             //  if (document.getElementById("<%=radioLimited.ClientID%>").checked == true) {
             //   if (Validity == "") {
             //      document.getElementById('divMessageArea').style.display = "";
             //      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
             //       document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
             //        document.getElementById("<%=txtValidity.ClientID%>").style.borderColor = "Red";
             //        document.getElementById("<%=txtValidity.ClientID%>").focus();
             //       ret = false;
             //   }
             // }
             if (document.getElementById("<%=cbxExistingEmployee.ClientID%>").checked == true) {
                 //if (ddlExistEmpText == "--SELECT EMPLOYEE--") {
                 //   alert("9");
                 //   document.getElementById('divMessageArea').style.display = "";
                 //  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                 //  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";


                  //  $noCon("div#divContactPersn input.ui-autocomplete-input").css("borderColor", "red");
                  //  $noCon("div#divContactPersn input.ui-autocomplete-input").focus();
                  //  $noCon("div#divContactPersn input.ui-autocomplete-input").select();
                  //  ret = false;
                  //  }
              }


             if (document.getElementById("<%=radioClient.ClientID%>").checked == true) {
                 //Check for import or User input data
                 var IsValidInput = validateUserInputData();
                 if (IsValidInput == false)
                 {
                     document.getElementById('divMessageArea').style.display = "";
                     document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                     document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.Please import the necessary datas. ";
                     
                     ret = false;
                 }


             }

           
              if (document.getElementById("<%=radioSuplier.ClientID%>").checked == true) {


                 if (GurCurrencyText == "--SELECT CURRENCY--") {

                     document.getElementById('divMessageArea').style.display = "";
                     document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                     document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                      // $noCon("div#divCurrency input.ui-autocomplete-input").css("borderColor", "red");
                      // $noCon("div#divCurrency input.ui-autocomplete-input").focus();
                      //$noCon("div#divCurrency input.ui-autocomplete-input").select();
                      document.getElementById("<%=ddlCurrency.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=ddlCurrency.ClientID%>").focus();
                      ret = false;
                      ret = false;
                  }
                  else {
                      document.getElementById("<%=ddlCurrency.ClientID%>").style.borderColor = "";
                  }
                  if (Amount == "") {

                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                      document.getElementById("<%=txtAmount.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=txtAmount.ClientID%>").focus();
                      ret = false;
                  }
                  else {

                      document.getElementById("<%=txtAmount.ClientID%>").style.borderColor = "";
                  }
                  if (SubContrctText == "--SELECT SUB-CONTRACT--") {

                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                      document.getElementById("<%=ddlSubContrct.ClientID%>").style.borderColor = "Red";
                       document.getElementById("<%=ddlSubContrct.ClientID%>").focus();
                      //$noCon("div#divSubContract input.ui-autocomplete-input").css("borderColor", "red");
                      //$noCon("div#divSubContract input.ui-autocomplete-input").focus();
                      //$noCon("div#divSubContract input.ui-autocomplete-input").select();
                      ret = false;
                  }
                  else {
                      // document.getElementById("<%=ddlSubContrct.ClientID%>").style.borderColor = "";
                      $noCon("div#divSubContract input.ui-autocomplete-input").css("borderColor", "");
                  }
              }
            
              if (GurBankText == "--SELECT BANK--") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                 // document.getElementById("<%=ddlBank.ClientID%>").style.borderColor = "Red";
                 // document.getElementById("<%=ddlBank.ClientID%>").focus();
                   $noCon("div#divGuaranteCat input.ui-autocomplete-input").css("borderColor", "red");
                  $noCon("div#divGuaranteCat input.ui-autocomplete-input").focus();
                   $noCon("div#divGuaranteCat input.ui-autocomplete-input").select();
                  ret = false;
              }
              else {
                  $noCon("div#divGuaranteCat input.ui-autocomplete-input").css("borderColor", "");
              }

              if (GuarnteNo == "") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txtGuarnteno.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtGuarnteno.ClientID%>").focus();
                  ret = false;
              }
              else {
                  document.getElementById("<%=txtGuarnteno.ClientID%>").style.borderColor = "";
              }

              if (document.getElementById("<%=radioSuplier.ClientID%>").checked == true) {
                  if (GuarMEthdText == "--SELECT GUARANTEE MODE--") {

                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                      document.getElementById("<%=ddlGuarntyp.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=ddlGuarntyp.ClientID%>").focus();
                      ret = false;
                  }
                  else {

                      document.getElementById("<%=ddlGuarntyp.ClientID%>").style.borderColor = "";
                  }
              }
              else {

                  if (GuarMEthdText2 == "--SELECT GUARANTEE MODE--") {

                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                      document.getElementById("<%=ddlGteeType.ClientID%>").style.borderColor = "Red";
                       document.getElementById("<%=ddlGteeType.ClientID%>").focus();
                       ret = false;
                   }
                   else {

                       document.getElementById("<%=ddlGteeType.ClientID%>").style.borderColor = "";
                   }
              }
             

              var Count = document.getElementById("<%=hiddenTemplateCount.ClientID%>").value;
             
              var TotalValue = "";
              var DeletedValue = "";
              for (intCount = 1; intCount <= Count; intCount++) {

                  if (localStorage.getItem("tbClientTemplateUpload_" + intCount) != null && localStorage.getItem("tbClientTemplateUpload_" + intCount) != "[]") {

                      document.getElementById('divEachTemplate_' + intCount).style.border = "1px dotted";
                      document.getElementById('divEachTemplate_' + intCount).style.borderColor = "green";

                      TotalValue = TotalValue + "!" + localStorage.getItem("tbClientTemplateUpload_" + intCount);
                      DeletedValue = DeletedValue + "!" + localStorage.getItem("tbClientTemplateUploadDelete_" + intCount);
                      
                  }
                  else {
                      document.getElementById('divEachTemplate_' + intCount).style.border = "2px dotted";
                      document.getElementById('divEachTemplate_' + intCount).style.borderColor = "red";



                      document.getElementById('divMessageArea').style.display = "";
                      document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                         CheckSubmitZero();
                         return false;
                     }

                     document.getElementById("txtDuration_" + intCount).style.borderColor = "";
                     if (document.getElementById("txtDuration_" + intCount).value == "") {
                         document.getElementById('divMessageArea').style.display = "";
                         document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                         document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                     document.getElementById("txtDuration_" + intCount).style.borderColor = "red";
                     CheckSubmitZero();
                     return false;
                 }



              }

              
              document.getElementById("<%=hiddenEachSliceData.ClientID%>").value = TotalValue;
              document.getElementById("<%=hiddenDeleteSliceData.ClientID%>").value = DeletedValue;


             if (ret == false) {
                 CheckSubmitZero();

             }
             if (ret == true) {
                
                  document.getElementById("<%=hiddenDivisionddlData.ClientID%>").value = 0;
                  document.getElementById("<%=hiddenDesignationddlData.ClientID%>").value = 0;
                 document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value = 0;

                 clearhidd_INSRNC();
              }

             $(window).scrollTop(0);
             return ret;
         }
          function validateUserInputData() {
              ret = true;
              var NameWithoutReplace = document.getElementById("<%=txtAmount.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var AmountText = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtAmount.ClientID%>").value = AmountText;

              if (document.getElementById("<%=cbxPrjct.ClientID%>").checked == true) {
                  //re
                  // document.getElementById("<%=ddlProjects.ClientID%>").style.borderColor = "";
                  $noCon("div#divProjectsDdl input.ui-autocomplete-input").css("borderColor", "");

                  var GteeType = document.getElementById("<%=ddlGteeType.ClientID%>");
                  var GteeTypeText = GteeType.options[GteeType.selectedIndex].text;

                  if (GteeTypeText == "--SELECT GUARANTEE MODE--") {
                      document.getElementById("<%=ddlGteeType.ClientID%>").style.borderColor = "Red";
                      ret = false;
                  }
                  // alert(document.getElementById("<%=HiddenImportaddchk.ClientID%>").value);
                  if (document.getElementById("<%=HiddenImportaddchk.ClientID%>").value != "1") {
                      var DdlProject = document.getElementById("<%=ddlProjects.ClientID%>");
                      var DdlProjectText = DdlProject.options[DdlProject.selectedIndex].text;

                      if (DdlProjectText == "--SELECT PROJECT--") {
                          //re
                          //document.getElementById("<%=ddlProjects.ClientID%>").style.borderColor = "Red";
                          $noCon("div#divProjectsDdl input.ui-autocomplete-input").css("borderColor", "red");

                          ret = false;
                      }

                      var DdlCustomerList = document.getElementById("<%=ddlCustomerList.ClientID%>");
                      var DdlCustomerListText = DdlCustomerList.options[DdlCustomerList.selectedIndex].text;

                      if (DdlCustomerListText == "--SELECT CUSTOMER--") {
                          document.getElementById("<%=ddlCustomerList.ClientID%>").style.borderColor = "Red";
                          ret = false;
                      }

                      if (AmountText <= 0) {
                          document.getElementById("<%=txtAmount.ClientID%>").style.borderColor = "Red";
                          ret = false;
                      }
                      if (document.getElementById("<%=txtAmount.ClientID%>").value != 1) {
                          if (DdlCustomerListText == "--SELECT CUSTOMER--") {
                              document.getElementById("<%=ddlCustomerList.ClientID%>").focus();
                          }
                          if (AmountText <= 0) {
                              document.getElementById("<%=txtAmount.ClientID%>").focus();
                          }
                          if (DdlProjectText == "--SELECT PROJECT--") {
                              //re
                              //document.getElementById("<%=ddlProjects.ClientID%>").focus();
                              $noCon("div#divProjectsDdl input.ui-autocomplete-input").focus();
                          }
                          if (GteeTypeText == "--SELECT GUARANTEE MODE--") {
                              document.getElementById("<%=ddlGteeType.ClientID%>").focus();
                          }
                      }
                  }
              }
              else {

                  document.getElementById("<%=txtPrjctName.ClientID%>").style.borderColor = "";

                  var prjctName = document.getElementById("<%=txtPrjctName.ClientID%>").value;

                  var GteeType = document.getElementById("<%=ddlGteeType.ClientID%>");
                          var GteeTypeText = GteeType.options[GteeType.selectedIndex].text;

                          if (GteeTypeText == "--SELECT GUARANTEE MODE--") {
                              document.getElementById("<%=ddlGteeType.ClientID%>").style.borderColor = "Red";
                      ret = false;
                  }
                  // alert(document.getElementById("<%=HiddenImportaddchk.ClientID%>").value);
                  if (document.getElementById("<%=HiddenImportaddchk.ClientID%>").value != "1") {
                      var DdlProject = document.getElementById("<%=ddlProjects.ClientID%>");
                      var DdlProjectText = DdlProject.options[DdlProject.selectedIndex].text;

                      if (prjctName == "") {
                          document.getElementById("<%=txtPrjctName.ClientID%>").style.borderColor = "Red";
                          ret = false;
                      }
                      var DdlCustomerList = document.getElementById("<%=ddlCustomerList.ClientID%>");
                      var DdlCustomerListText = DdlCustomerList.options[DdlCustomerList.selectedIndex].text;

                      if (DdlCustomerListText == "--SELECT CUSTOMER--") {
                          document.getElementById("<%=ddlCustomerList.ClientID%>").style.borderColor = "Red";
                          ret = false;
                      }

                      if (AmountText <= 0) {
                          document.getElementById("<%=txtAmount.ClientID%>").style.borderColor = "Red";
                          ret = false;
                      }
                      if (document.getElementById("<%=txtAmount.ClientID%>").value != 1) {
                          if (DdlCustomerListText == "--SELECT CUSTOMER--") {
                              document.getElementById("<%=ddlCustomerList.ClientID%>").focus();
                          }
                          if (AmountText <= 0) {
                              document.getElementById("<%=txtAmount.ClientID%>").focus();
                          }

                          if (prjctName == "") {
                              document.getElementById("<%=txtPrjctName.ClientID%>").focus();
                          }
                          if (GteeTypeText == "--SELECT GUARANTEE MODE--") {
                              document.getElementById("<%=ddlGteeType.ClientID%>").focus();
                          }
                      }
                  }
              }
             
              return ret;
          }
      </script>
    <script>
        function ConfirmAlert() {
            var chck = Validate();

            if (chck == true) {

                if (confirm("Are you sure you want to confirm?")) {
                    return true;
                }
                else {

                    CheckSubmitZero();
                    return false;
                }
            } else {

                CheckSubmitZero();
                return false;
            }

        }

        function ConfirmReOpen() {


            if (confirm("Are you sure you want to reopen?")) {
                document.getElementById("<%=hiddenDivisionddlData.ClientID%>").value = 0;
                document.getElementById("<%=hiddenDesignationddlData.ClientID%>").value = 0;
                document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value = 0;

                clearhidd_INSRNC();
                return true;
            }
            else {

                CheckSubmitZero();
                return false;
            }

        }
        function ConfirmClose() {


            if (confirm("Are you sure you want to close?")) {
                document.getElementById("<%=hiddenDivisionddlData.ClientID%>").value = 0;
                document.getElementById("<%=hiddenDesignationddlData.ClientID%>").value = 0;
                document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value = 0;
                return true;
            }
            else {

                CheckSubmitZero();
                return false;
            }

        }
        function closeWindow() {
            window.close();
        }


        function CbxChange() {
            IncrmntConfrmCounter();
            if (document.getElementById("<%=cbxExistingEmployee.ClientID%>").checked == false) {

                //IncrmntConfrmCounter();
                document.getElementById("divExistingEmp").style.display = "none";
                document.getElementById("divNewEmp").style.display = "";

                document.getElementById("<%=ddlExistingEmp.ClientID%>").value = "--SELECT EMPLOYEE--";
                document.getElementById("<%=txtCntctMail.ClientID%>").value = "";
            }
            else {
                $noC = jQuery.noConflict();
                //IncrmntConfrmCounter();
                document.getElementById("divNewEmp").style.display = "none";
                document.getElementById("divExistingEmp").style.display = "";
                document.getElementById("<%=ddlExistingEmp.ClientID%>").value = "--SELECT EMPLOYEE--";

                //var a = $noC("#cphMain_ddlExistingEmp option:selected").text();
                //$noC("div#divExistingEmp input.ui-autocomplete-input").val(a);

            }

            return false;
        }

        function FocusOnPostBck(usrid, cstmrid, MailAdd) {


            $au('#cphMain_ddlGuaranteCat').selectToAutocomplete1Letter();
            $au('#cphMain_ddlProject').selectToAutocomplete1Letter();

            $au('#cphMain_ddlCurrency').selectToAutocomplete1Letter();
           // $au('#cphMain_ddlExistingEmp').selectToAutocomplete1Letter();
            $noCon("div#divProject input.ui-autocomplete-input").focus();




            $au("div#divCustomer input.ui-autocomplete-input").val(CustVal);

            if (usrid != 0) {
                document.getElementById("<%=ddlExistingEmp.ClientID%>").value = usrid;
                var EmpVal = $au("#cphMain_ddlExistingEmp option:selected").text();

                $au("div#divExistingEmp input.ui-autocomplete-input").val(EmpVal);

                document.getElementById("divNewEmp").style.display = "none";
                document.getElementById("divExistingEmp").style.display = "";
            }

            if (MailAdd != "") {
                document.getElementById("<%=txtCntctMail.ClientID%>").value = MailAdd;
            }
            else {
                document.getElementById("<%=txtCntctMail.ClientID%>").value = "";
            }

            if (document.getElementById("<%=radioOpen.ClientID%>").checked == true) {
                // document.getElementById("<%=txtValidity.ClientID%>").disabled = true;
            }
            else {
                // document.getElementById("<%=txtValidity.ClientID%>").disabled = false;
            }

        }

        function FocusOnPostBck2() {

    
            $au('#cphMain_ddlOwnershp').selectToAutocomplete1Letter();
            //$au('#cphMain_ddlGuaranteCat').selectToAutocomplete1Letter();
            //$au('#cphMain_ddlProject').selectToAutocomplete1Letter();
            // $au('#cphMain_ddlCustomer').selectToAutocomplete1Letter();
            //  $au('#cphMain_ddlCurrency').selectToAutocomplete1Letter();
           // $au('#cphMain_ddlExistingEmp').selectToAutocomplete1Letter();
       
        }

    </script>
   <script>
       function AutocompleteEmp() {
         //  $au('#cphMain_ddlExistingEmp').selectToAutocomplete1Letter();
          // $au('#cphMain_ddlSubContrct').selectToAutocomplete1Letter();
           if (document.getElementById("<%=cbxExistingEmployee.ClientID%>").checked == false) {

               document.getElementById("divExistingEmp").style.display = "none";
               document.getElementById("divNewEmp").style.display = "";

           }
           else {

               document.getElementById("divNewEmp").style.display = "none";
               document.getElementById("divExistingEmp").style.display = "";


           }
       }
       function Autocomplete() {

           $au('#cphMain_ddlOwnershp').selectToAutocomplete1Letter();
          // $au('#cphMain_ddlSubContrct').selectToAutocomplete1Letter();
           // $au('#cphMain_ddlGuaranteCat').selectToAutocomplete1Letter();
           // $au('#cphMain_ddlProject').selectToAutocomplete1Letter();
         //  $au('#cphMain_ddlExistingEmp').selectToAutocomplete1Letter();
           if (document.getElementById("<%=cbxExistingEmployee.ClientID%>").checked == false) {

               document.getElementById("divExistingEmp").style.display = "none";
               document.getElementById("divNewEmp").style.display = "";

           }
           else {

               document.getElementById("divNewEmp").style.display = "none";
               document.getElementById("divExistingEmp").style.display = "";


           }
       }
       function DuplicationRequestId() {
           document.getElementById('divMessageArea').style.display = "";
           document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
           document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.This Request Already Added in Bank Guarantee.";

           document.getElementById("<%=HiddenImportaddchk.ClientID%>").value = "";
           // document.getElementById("<%=txtGuarnteno.ClientID%>").style.borderColor = "Red";



       }
       function Duplicationx(x, y) {
           document.getElementById('divMessageArea').style.display = "";
           document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
           document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Guarantee Number Can’t be Duplicated.";
           document.getElementById("<%=txtGuarnteno.ClientID%>").style.borderColor = "Red";
           document.getElementById("<%=ddlGteeType.ClientID%>").focus();
           document.getElementById("<%=HiddenTextValidty.ClientID%>").value = y;

           ImportViewDuplcn(x);
       }
       function Duplication() {
           document.getElementById('divMessageArea').style.display = "";
           document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
           document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Guarantee Number Can’t be Duplicated.";
           document.getElementById("<%=txtGuarnteno.ClientID%>").style.borderColor = "Red";
           document.getElementById("<%=ddlGteeType.ClientID%>").focus();

       }
       function StatusCheck()
       {

           document.getElementById('divMessageArea').style.display = "";
           document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
           document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Confirm Denied.Entry Is Already Confirmed.";
           //document.getElementById("<%=txtGuarnteno.ClientID%>").style.borderColor = "Red";
           //document.getElementById("<%=ddlGteeType.ClientID%>").focus();
       }
       
       function StatusCheckReopn() {

           document.getElementById('divMessageArea').style.display = "";
           document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
           document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Reopen Denied.Entry Is Already Reopened.";
             //document.getElementById("<%=txtGuarnteno.ClientID%>").style.borderColor = "Red";
             //document.getElementById("<%=ddlGteeType.ClientID%>").focus();
       }
       function   StatusCheckClsReopn() {

           document.getElementById('divMessageArea').style.display = "";
           document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
           document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Reopen Denied.Entry Is Already Closed.";
              //document.getElementById("<%=txtGuarnteno.ClientID%>").style.borderColor = "Red";
              //document.getElementById("<%=ddlGteeType.ClientID%>").focus();
          }
     
       function FocusOnPostBckEmp(strEmail) {
        
           $au('#cphMain_ddlOwnershp').selectToAutocomplete1Letter();
       //    $au('#cphMain_ddlExistingEmp').selectToAutocomplete1Letter();
           //$au('#cphMain_ddlSubContrct').selectToAutocomplete1Letter();
          
           if (document.getElementById("<%=radioClient.ClientID%>").checked == true) {

               document.getElementById("<%=ddlGteeType.ClientID%>").focus();
               document.getElementById("DivGrntyTypeDrpDwn").style.display = "none";
               document.getElementById("DivGrntyTyplabl").style.display = "";
               document.getElementById("divSubContract").style.display = "none";
               // if (document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value == "") {
               document.getElementById("<%=txtAmount.ClientID%>").disabled = true;
               //}

               if (document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value == "" && document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value == "") {
               document.getElementById("<%=txtAmount.ClientID%>").disabled = false;
             }

               if (document.getElementById("<%=HiddenImportaddchk.ClientID%>").value == "" && document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value != "") {
                   document.getElementById("<%=txtAmount.ClientID%>").disabled = true;
               }
               document.getElementById("h2cuscontractr").innerHTML = 'Customer*';

               //document.getElementById("<%=LabelCustmrContrctr.ClientID%>").innerHTML = 'Customer';
              // document.getElementById("Currencyddl").style.display = "none";
              // document.getElementById("CurrencyLabl").style.display = "";
               document.getElementById("<%=LblProject.ClientID%>").style.display = "none";
               document.getElementById("<%=LabelCustmrContrctr.ClientID%>").style.display = "none";
               document.getElementById("<%=ddlCustomerList.ClientID%>").style.display = "";
           }
           else if (document.getElementById("<%=radioSuplier.ClientID%>").checked == true) {
               document.getElementById("<%=ddlGuarntyp.ClientID%>").focus();
                document.getElementById("DivGrntyTypeDrpDwn").style.display = "";
                document.getElementById("DivGrntyTyplabl").style.display = "none";
                document.getElementById("divSubContract").style.display = ""; 
                if (document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value == "") {
                    document.getElementById("<%=txtAmount.ClientID%>").disabled = true;
                }
              
                document.getElementById("h2cuscontractr").innerHTML = 'Contractor';

                //  if (document.getElementById("<%=HiddenSubContractSlct.ClientID%>").value != "1") {
                //    document.getElementById("<%=LabelCustmrContrctr.ClientID%>").innerHTML = 'Contractor';
                // }
                //document.getElementById("CurrencyLabl").style.display = "none";
               //document.getElementById("Currencyddl").style.display = "";
               document.getElementById("<%=LblProject.ClientID%>").style.display = "";
               document.getElementById("<%=LabelCustmrContrctr.ClientID%>").style.display = "";
               document.getElementById("<%=ddlCustomerList.ClientID%>").style.display = "none";
           }
          
        if (document.getElementById("<%=radioLimited.ClientID%>").checked == true) {
               //document.getElementById("<%=txtValidity.ClientID%>").disabled = false;
               document.getElementById("img1").disabled = false;
               document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = false;
               // document.getElementById("<%=txtAmount.ClientID%>").disabled = false;
           }
           else if (document.getElementById("<%=radioOpen.ClientID%>").checked == true) {
               //   document.getElementById("<%=txtValidity.ClientID%>").disabled = true;
                document.getElementById("img1").disabled = true;
                document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;
            }
        if (document.getElementById("<%=cbxExistingEmployee.ClientID%>").checked == false) {

               document.getElementById("divExistingEmp").style.display = "none";
               document.getElementById("divNewEmp").style.display = "";

           }
           else {

               document.getElementById("divNewEmp").style.display = "none";
               document.getElementById("divExistingEmp").style.display = "";


           }
           //$noCon("div#divExistingEmp input.ui-autocomplete-input").focus();
          
           setTimeout(FillCntctmail(strEmail),30);
           document.getElementById("<%=txtCntctMail.ClientID%>").value = strEmail;
           document.getElementById("<%=ddlExistingEmp.ClientID%>").focus();
       }

       function FillCntctmail(strEmail) {
          
           document.getElementById("<%=txtCntctMail.ClientID%>").value = strEmail;
       }
       function FocusOnPostSubContrct(prjctid, contrctid) {
           document.getElementById("<%=HiddenFieldPRJCTID.ClientID%>").value = prjctid;
           document.getElementById("<%=HiddenFieldCustmor.ClientID%>").value = contrctid;
           $au('#cphMain_ddlOwnershp').selectToAutocomplete1Letter();
          // $au('#cphMain_ddlExistingEmp').selectToAutocomplete1Letter();
           //$au('#cphMain_ddlSubContrct').selectToAutocomplete1Letter();

           if (document.getElementById("<%=radioClient.ClientID%>").checked == true) {

               document.getElementById("<%=ddlGteeType.ClientID%>").focus();
               document.getElementById("DivGrntyTypeDrpDwn").style.display = "none";
               document.getElementById("DivGrntyTyplabl").style.display = "";
               document.getElementById("divSubContract").style.display = "none";
               // if (document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value == "") {
               //document.getElementById("<%=txtAmount.ClientID%>").disabled = true;
               // }
               document.getElementById("h2cuscontractr").innerHTML = 'Customer*';

               //document.getElementById("<%=LabelCustmrContrctr.ClientID%>").innerHTML = 'Customer';
              // document.getElementById("Currencyddl").style.display = "none";
               //document.getElementById("CurrencyLabl").style.display = "";
               document.getElementById("<%=LblProject.ClientID%>").style.display = "none";
               document.getElementById("<%=LabelCustmrContrctr.ClientID%>").style.display = "none";
               document.getElementById("<%=ddlCustomerList.ClientID%>").style.display = "";
           }
           else if (document.getElementById("<%=radioSuplier.ClientID%>").checked == true) {
               document.getElementById("<%=ddlGuarntyp.ClientID%>").focus();
                document.getElementById("DivGrntyTypeDrpDwn").style.display = "";
                document.getElementById("DivGrntyTyplabl").style.display = "none";
                document.getElementById("divSubContract").style.display = "";
                if (document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value == "") {
                    document.getElementById("<%=txtAmount.ClientID%>").disabled = false;
                }
               
                document.getElementById("h2cuscontractr").innerHTML = 'Contractor';

                //  if (document.getElementById("<%=HiddenSubContractSlct.ClientID%>").value != "1") {
                //    document.getElementById("<%=LabelCustmrContrctr.ClientID%>").innerHTML = 'Contractor';
                // }
                //document.getElementById("CurrencyLabl").style.display = "none";
               //  document.getElementById("Currencyddl").style.display = "";
               document.getElementById("<%=LblProject.ClientID%>").style.display = "";
               document.getElementById("<%=LabelCustmrContrctr.ClientID%>").style.display = "";
               document.getElementById("<%=ddlCustomerList.ClientID%>").style.display = "none";
               document.getElementById("divProjectsDdl").style.display = "none";
            }
        if (document.getElementById("<%=radioLimited.ClientID%>").checked == true) {
               //document.getElementById("<%=txtValidity.ClientID%>").disabled = false;
            document.getElementById("img1").disabled = false;
            document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = false;
           }
           else if (document.getElementById("<%=radioOpen.ClientID%>").checked == true) {
            //   document.getElementById("<%=txtValidity.ClientID%>").disabled = true;
                document.getElementById("img1").disabled = true;
                document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;
            }
        if (document.getElementById("<%=cbxExistingEmployee.ClientID%>").checked == false) {

               document.getElementById("divExistingEmp").style.display = "none";
               document.getElementById("divNewEmp").style.display = "";

           }
           else {

               document.getElementById("divNewEmp").style.display = "none";
               document.getElementById("divExistingEmp").style.display = "";


        }
           $au('#cphMain_ddlBank').selectToAutocomplete1Letter();
           document.getElementById("<%=ddlSubContrct.ClientID%>").focus();
       }

       //validation when cancel process
       function ValidateCancelReason() {
           replacing < and > tags
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
                   document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Cancel reason should be minimum 10 characters";
                    var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                    return false;
                }
            }
        }
        function ChangeFile(x) {
            if (ClearDivDisplayImage(x)) {

                IncrmntConfrmCounter();
                if (document.getElementById('file' + x).value != "") {
                    document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;

                    var tbClientImageValidation = localStorage.getItem("tbClientImageValidation");//Retrieve the stored data

                    tbClientImageValidation = JSON.parse(tbClientImageValidation);
                    if (tbClientImageValidation == null) //If there is no data, initialize an empty array
                        tbClientImageValidation = [];
                    var $addFile = jQuery.noConflict();
                    var client = JSON.stringify({
                        ROWID: "" + x + "",

                    });


                    if (client != "") {

                        tbClientImageValidation.push(client);
                        localStorage.setItem("tbClientImageValidation", JSON.stringify(tbClientImageValidation));

                        $addFile("#cphMain_HiddenFieldValidation").val(JSON.stringify(tbClientImageValidation));

                    }
                    else {
                        document.getElementById('filePath' + x).innerHTML = 'No File Uploaded';


                    }
                    var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                 
                    if (SavedorNot == "saved") {
                        var row_index = jQuery('#FilerowId_' + x).index();
                        // FileLocalStorageEdit(x, row_index);
                    }
                    else {
                        // FileLocalStorageAdd(x);
                    }
                }


            }
        }
        function prevValueChk(x) {

            document.getElementById("<%=hiddenFieldPrevValueChk.ClientID%>").value = document.getElementById('textbx' + x).value;
           }

           function isNumber(evt, textboxid) {
               evt = (evt) ? evt : window.event;
               var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
               var charCode = (evt.which) ? evt.which : evt.keyCode;

               var txtPerVal = document.getElementById(textboxid).value;
               //enter
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
                   // . period and numpad . period
               else if (keyCodes == 190 || keyCodes == 110) {
                   var ret = true;
                   if (textboxid == "cphMain_txtAmount") {
                       var count = txtPerVal.split('.').length - 1;

                       if (count > 0) {

                           ret = false;
                       }
                       else {
                           ret = true;
                       }
                       return ret;
                   }
                   else {
                       return false;
                   }

               }

               else {
                   var ret = true;
                   if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                       ret = false;
                   }
                   return ret;
               }
           }

           function LinkChangeFile(x, y) {


               if (isTag(y)) {


                   document.getElementById("file" + x).style.borderColor = "";

                   if (document.getElementById('textbx' + x).value != "") {

                       var prevtxtValue = document.getElementById("<%=hiddenFieldPrevValueChk.ClientID%>").value;
                       var vartxtbox = document.getElementById('textbx' + x).value;

                       IncrmntConfrmCounter();
                       //if (document.getElementById('file' + x).value != "") {

                       //    document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;

                       //}
                       if (prevtxtValue != vartxtbox) {

                           //var tbClientImageValidation = localStorage.getItem("tbClientImageValidation");//Retrieve the stored data

                           //tbClientImageValidation = JSON.parse(tbClientImageValidation);
                           //if (tbClientImageValidation == null) //If there is no data, initialize an empty array
                           //    tbClientImageValidation = [];
                           //var $addFile = jQuery.noConflict();
                           //var client = JSON.stringify({
                           //    ROWID: "" + x + "",

                           //});


                           //if (client != "") {

                           //    tbClientImageValidation.push(client);
                           //    localStorage.setItem("tbClientImageValidation", JSON.stringify(tbClientImageValidation));

                           //    $addFile("#cphMain_HiddenFieldValidation").val(JSON.stringify(tbClientImageValidation));

                         

                           var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                        
                           if (SavedorNot == "saved") {
                               var row_index = jQuery('#FilerowId_' + x).index();
                           

                               FileLocalStorageEdit(x, row_index);
                           }
                           else {


                               FileLocalStorageAdd(x);
                           }
                       }
                       document.getElementById("<%=hiddenValueChangeNtfr.ClientID%>").value = "1";

                   }
               }
               else {


               }

           }


           function FileLocalStorageEdit(x, row_index) {
               var tbClientPicLinkUpload = localStorage.getItem("tbClientPicLinkUpload");
               var tbClientPictureUpload = localStorage.getItem("tbClientPictureUpload");//Retrieve the stored data

               tbClientPictureUpload = JSON.parse(tbClientPictureUpload); //Converts string to object
               tbClientPicLinkUpload = JSON.parse(tbClientPicLinkUpload);

               if (tbClientPictureUpload == null) //If there is no data, initialize an empty array
                   tbClientPictureUpload = [];

               if (tbClientPicLinkUpload == null) //If there is no data, initialize an empty array
                   tbClientPicLinkUpload = [];

               var FilePath = document.getElementById("filePath" + x).innerHTML;
               var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

               var Fevt = document.getElementById("FileEvt" + x).innerHTML;

               if (Fevt == 'INS') {

                   var $FileE = jQuery.noConflict();
                   tbClientPictureUpload[row_index] = JSON.stringify({
                       ROWID: "" + x + "",
                       //     FILEPATH: "" + FilePath + "",
                       EVTACTION: "" + Fevt + "",
                       DTLID: "0"
                   });//Alter the selected item on the table
                   tbClientPicLinkUpload[row_index] = JSON.stringify({
                       ROWID: "" + x + "",
                       // FILEPATH: "" + FilePath + "",
                       EVTACTION: "" + Fevt + "",
                       DTLID: "0"

                   });

               }
               else {

                   var $FileE = jQuery.noConflict();
                   tbClientPictureUpload[row_index] = JSON.stringify({
                       ROWID: "" + x + "",
                       //   FILEPATH: "" + FilePath + "",
                       EVTACTION: "" + Fevt + "",
                       DTLID: "" + FdetailId + ""

                   });//Alter the selected item on the table

                   tbClientPicLinkUpload[row_index] = JSON.stringify({
                       ROWID: "" + x + "",
                       // FILEPATH: "" + FilePath + "",
                       EVTACTION: "" + Fevt + "",
                       DTLID: "" + FdetailId + ""

                   });



               }



               localStorage.setItem("tbClientPictureUpload", JSON.stringify(tbClientPictureUpload));
               $FileE("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPictureUpload));
               localStorage.setItem("tbClientPicLinkUpload", JSON.stringify(tbClientPicLinkUpload));
               $addFile("#cphMain_HiddenField2_FileUploadLnk").val(JSON.stringify(tbClientPicLinkUpload));



               return true;
           }

           function FileLocalStorageAdd(x) {



               var tbClientPicLinkUpload = localStorage.getItem("tbClientPicLinkUpload");//Retrieve the stored data
               var tbClientPictureUpload = localStorage.getItem("tbClientPictureUpload");//Retrieve the stored data

               tbClientPictureUpload = JSON.parse(tbClientPictureUpload); //Converts string to object
               tbClientPicLinkUpload = JSON.parse(tbClientPicLinkUpload); //Converts string to object

               if (tbClientPictureUpload == null) //If there is no data, initialize an empty array
                   tbClientPictureUpload = [];

               if (tbClientPicLinkUpload == null) //If there is no data, initialize an empty array
                   tbClientPicLinkUpload = [];

               // var Linktxt = document.getElementById("textbx" + x).innerHTML;


               var FilePath = document.getElementById("filePath" + x).innerHTML;
               var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
               var Fevt = document.getElementById("FileEvt" + x).innerHTML;
               
               if (Fevt == 'INS') {

                   var $addFile = jQuery.noConflict();

                   var client = JSON.stringify({

                       ROWID: "" + x + "",
                       //   FILEPATH: "" + FilePath + "",
                       EVTACTION: "" + Fevt + "",
                       DTLID: "0"

                   });

                   var clientLink = JSON.stringify({
                       ROWID: "" + x + "",
                       // FILEPATH: "" + FilePath + "",
                       EVTACTION: "" + Fevt + "",
                       // LNKTXT: "" + Linktxt + "",

                       DTLID: "0"
                   });

               }
               else if (Fevt == 'UPD') {
                   var $addFile = jQuery.noConflict();
                   var client = JSON.stringify({
                       ROWID: "" + x + "",
                       //   FILEPATH: "" + FilePath + "",
                       EVTACTION: "" + Fevt + "",
                       DTLID: "" + FdetailId + ""

                   });

                   var clientLink = JSON.stringify({
                       ROWID: "" + x + "",
                       // FILEPATH: "" + FilePath + "",
                       EVTACTION: "" + Fevt + "",
                       //LNKTXT: "" + Linktxt + "",

                       DTLID: "" + FdetailId + ""

                   });
               }


               tbClientPictureUpload.push(client);
               localStorage.setItem("tbClientPictureUpload", JSON.stringify(tbClientPictureUpload));

               $addFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPictureUpload));
               if (clientLink != "" && clientLink != null) {
                   tbClientPicLinkUpload.push(clientLink);
                   localStorage.setItem("tbClientPicLinkUpload", JSON.stringify(tbClientPicLinkUpload));
                   $addFile("#cphMain_HiddenField2_FileUploadLnk").val(JSON.stringify(tbClientPicLinkUpload));

               }

               
              

               document.getElementById("FileSave" + x).innerHTML = "saved";
         

               return true;

           }
           function CheckaddMoreRowsIndividualFiles(x) {

               var check = document.getElementById("FileInx" + x).innerHTML;
               if (check =="") {

                   var Fevt = document.getElementById("FileEvt" + x).innerHTML;

                   if (Fevt != 'UPD') {

                       if (CheckFileUploaded(x) == true) {

                           document.getElementById("FileInx" + x).innerHTML = x;
                           document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";

                           if (document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value != "1") {
                               AddFileUpload();
                           }
                           else if (document.getElementById("<%=HiddenRenew.ClientID%>").value == "1")
                           {
                               AddFileUpload();
                           }
                               

                           return false;
                       }
                   }
                   else {

                       document.getElementById("FileInx" + x).innerHTML = x;
                       document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                       if (document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value != "1") {
                           AddFileUpload();
                       }
                       else if (document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
                           AddFileUpload();
                       }
                       return false;
                   }
               }
               return false;

           }
           function RemoveFileUpload(removeNum) {
         

               var ret = true;
               if (document.getElementById("<%=HiddenFieldviewchck.ClientID%>").value != "1" || document.getElementById("<%=HiddenRenew.ClientID%>").value == "1") {
               if (confirm("Are you sure you want to delete selected row?")) {
           
                   var Filerow_index = jQuery('#FilerowId_' + removeNum).index();

                   FileLocalStorageDelete(Filerow_index, removeNum);
                   jQuery('#FilerowId_' + removeNum).remove();



                   var TableFileRowCount = document.getElementById("TableFileUploadContainer").rows.length;


                   if (TableFileRowCount != 0) {
                       var idlast = $('#TableFileUploadContainer tr:last').attr('id');
                       //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                       //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                       if (idlast != "") {
                           var res = idlast.split("_");

                           document.getElementById("FileInx" + res[1]).innerHTML = "";
                           document.getElementById("FileIndvlAddMoreRow" + res[1]).style.opacity = "1";

                           ret = true;
                       }

                   }
                   else {

                       AddFileUpload();

                       ret = true;

                   }

               }
               else {

                   ret = false;
               }
           }

           else {
               ret = false;
           }

           document.getElementById("<%=hiddenValueChangeNtfr.ClientID%>").value = "1"

           return ret;
          

       }
       function FileLocalStorageDelete(row_index, x) {

           var $DelFile = jQuery.noConflict();
           var tbClientPictureUpload = localStorage.getItem("tbClientPictureUpload");//Retrieve the stored data
           var tbClientPicLinkUpload = localStorage.getItem("tbClientPicLinkUpload");

           tbClientPictureUpload = JSON.parse(tbClientPictureUpload); //Converts string to object
           tbClientPicLinkUpload = JSON.parse(tbClientPicLinkUpload);
           if (tbClientPictureUpload == null) //If there is no data, initialize an empty array
               tbClientPictureUpload = [];

           if (tbClientPicLinkUpload == null) //If there is no data, initialize an empty array
               tbClientPicLinkUpload = [];

           // Using splice() we can specify the index to begin removing items, and the number of items to remove.
           for (var i = 0; i < tbClientPictureUpload.length; i++) {

               var rowid = tbClientPictureUpload[i];
               rowid = rowid.split(",");
               rowid = rowid[0];
               rowid = rowid.split(":");
               rowid = rowid[1];
               rowid = rowid.replace(/"/g, "");


               if (rowid == x) {

                   tbClientPictureUpload.splice(i, 1);

                   break;
               }

           }

           // tbClientPictureUpload.splice(row_index, 1);
           localStorage.setItem("tbClientPictureUpload", JSON.stringify(tbClientPictureUpload));
           $DelFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPictureUpload));
           var hidd = document.getElementById("<%=HiddenField2_FileUploadLnk.ClientID%>").value;


           for (var i = 0; i < tbClientPicLinkUpload.length; i++) {
               var rowid = tbClientPicLinkUpload[i];
               rowid = rowid.split(",");
               rowid = rowid[0];
               rowid = rowid.split(":");
               rowid = rowid[1];
               rowid = rowid.replace(/"/g, "");


               if (rowid == x) {

                   tbClientPicLinkUpload.splice(i, 1);

                   break;
               }
           }

           // tbClientPicLinkUpload.splice(row_index, 1);
           localStorage.setItem("tbClientPicLinkUpload", JSON.stringify(tbClientPicLinkUpload));
           $DelFile("#cphMain_HiddenField2_FileUploadLnk").val(JSON.stringify(tbClientPicLinkUpload));
           var hiddn = document.getElementById("<%=HiddenField2_FileUploadLnk.ClientID%>").value;

           var Fevt = document.getElementById("FileEvt" + x).innerHTML;
  
            if (Fevt == 'UPD') {
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

                if (FdetailId != '') {

                    DeleteFileLSTORAGEAddFile(x);
                }

            }
          //  alert(document.getElementById("<%=HiddenField2_FileUploadLnk.ClientID%>").value);
        }
       function DeleteFileLSTORAGEAddFile(x) {


            var tbClientPictureFileCancel = localStorage.getItem("tbClientPictureFileCancel");//Retrieve the stored data

            tbClientPictureFileCancel = JSON.parse(tbClientPictureFileCancel); //Converts string to object

            if (tbClientPictureFileCancel == null) //If there is no data, initialize an empty array
                tbClientPictureFileCancel = [];


            var FileName = document.getElementById("DbFileName" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;



            var $addFile = jQuery.noConflict();
            var client = JSON.stringify({
                ROWID: "" + x + "",
                FILENAME: "" + FileName + "",
                // EVTACTION: "" + Fevt + "",
                DTLID: "" + FdetailId + ""
            });



            if (client != "") {

                tbClientPictureFileCancel.push(client);
                localStorage.setItem("tbClientPictureFileCancel", JSON.stringify(tbClientPictureFileCancel));

                $addFile("#cphMain_hiddenFileCanclDtlId").val(JSON.stringify(tbClientPictureFileCancel));

                ret = true;
            }

            return ret;


        }

        function CheckFileUploaded(x) {

            if (document.getElementById('file' + x).value != "") {
                //&& document.getElementById('textbx' + x).value != ""
                return true;
            }
            else {

                return false;
            }

            return false;
        }
        function CheckValidation(x) {

           
            if (document.getElementById('file' + x)!=undefined) {

            
            if (document.getElementById('file' + x).value != "" && document.getElementById('textbx' + x).value != "") {

                //document.getElementById('file' + x).value != "" &&
                return true;
            }
            else {
                if (document.getElementById('file' + x).value != "") {
                    if (document.getElementById('textbx' + x).value == "") {
                        document.getElementById('textbx' + x).style.borderColor = "RED";
                        document.getElementById('textbx' + x).focus();
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    }
                }
       
      
                return false;
            }
        }

return true;
       }

       function ClearDivDisplayImage(x) {

           var fuData = document.getElementById('file' + x);
           var FileUploadPath = fuData.value;
           var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();



           if (Extension == "png" || Extension == "pdf" || Extension == "jpeg" || Extension == "jpg") {


               return true;




               //    return true;

           }
           else {
               document.getElementById('file' + x).value = "";
               document.getElementById('filePath' + x).innerHTML = 'No File Selected';
               alert("The specified file could not be uploaded. Image type not supported. Allowed types are png, jpeg, gif");
               return false;
           }
       }




   </script>
      <script type="text/javascript">
          var $Mo = jQuery.noConflict();

          function ImportView(x) {
              if (confirm("Do you want to import the data?")) {
                  document.getElementById('divMessageArea').style.display = "none";
                  document.getElementById('imgMessageArea').src = "";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  document.getElementById("MymodalCancelView").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";
                  //document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";HiddenImportaddchk
                  document.getElementById("<%=HiddenImportaddchk.ClientID%>").value = "1";
                  document.getElementById("<%=HiddenFieldRequestCltId.ClientID%>").value = x;
                  if (document.getElementById("<%=HiddenFieldRequestCltId.ClientID%>").value != "") {

                      $.ajax({
                          type: "POST",
                          async: false,
                          contentType: "application/json; charset=utf-8",
                          url: "gen_Bank_Guarantee.aspx/ReadReqstgurnte",
                          data: '{GuarnteId: "' + x + '"}',
                          dataType: "json",
                          success: function (data) {

                              if (data.d != '') {


                                  document.getElementById("<%=LabelCustmrContrctr.ClientID%>").innerHTML = data.d.strCustName;
                                 
                                  var textToFindCustomer = data.d.strCustName;
                                
                                  var ddlCustomerConData = document.getElementById("<%=ddlCustomerList.ClientID%>");
                                  for (var i = 0; i < ddlCustomerConData.options.length; i++) {
                                      if (ddlCustomerConData.options[i].text === textToFindCustomer) {
                                          ddlCustomerConData.selectedIndex = i;
                                          break;
                                      }
                                  }
                                  document.getElementById("<%=txtadress.ClientID%>").innerText = data.d.strCustmrAddress;
                                  document.getElementById("<%=LblProject.ClientID%>").innerHTML = data.d.strProjctName;
                                  //document.getElementById("lblGuarntMde").innerHTML = data.d.strCtacgryNme;
                                  var textToFind = data.d.strCtacgryNme;

                                  var ddlGteeTypeData = document.getElementById("<%=ddlGteeType.ClientID%>");
                                   for (var i = 0; i < ddlGteeTypeData.options.length; i++) {
                                       if (ddlGteeTypeData.options[i].text === textToFind) {
                                           ddlGteeTypeData.selectedIndex = i;
                                           break;
                                       }
                                   }
                                  //document.getElementById("<%=txtAmount.ClientID%>").disabled = false;
                                  //  alert(data.d.decAmount);
                                  document.getElementById("<%=txtAmount.ClientID%>").value = data.d.decAmount;
                                  // alert("22222");
                                  document.getElementById("<%=txtAmount.ClientID%>").disabled = true;
                                  //document.getElementById().innerHTML = data.d.strCurracyName;
                                  var textToFind = data.d.strCurracyName;

                                  var ddlData = document.getElementById("<%=ddlCurrency.ClientID%>")
                                  for (var i = 0; i < ddlData.options.length; i++) {
                                      if (ddlData.options[i].text === textToFind) {
                                          ddlData.selectedIndex = i;
                                          break;
                                      }
                                  }
                                  var ddlProjectData = document.getElementById("<%=ddlProjects.ClientID%>");
                                  var opt = new Option( data.d.strProjctName,data.d.intProjctId);
                                  ddlProjectData.options.add(opt);
                                  var textToFindPrj = data.d.strProjctName;
                                  for (var i = 0; i < ddlProjectData.options.length; i++) {
                                      if (ddlProjectData.options[i].text === textToFindPrj) {
                                          //re
                                          //  ddlProjectData.selectedIndex = i;
                                         
                                       $noCon("div#divProjectsDdl input.ui-autocomplete-input").val(textToFindPrj);
                                        
                                          break;
                                      }
                                  }
                              
                                  document.getElementById("<%=HiddenFieldPRJCTID.ClientID%>").value = data.d.intProjctId;
                                  document.getElementById("<%=HiddenFieldCustmor.ClientID%>").value = data.d.intCustNameId;
                                  document.getElementById("<%= HiddenFieldMode.ClientID%>").value = data.d.intCtacgryId;
                                  document.getElementById("<%=HiddenFieldAmount.ClientID%>").value = data.d.decAmount;
                                  document.getElementById("<%=HiddenFieldCurrcy.ClientID%>").value = data.d.intCurracyId;
                                  document.getElementById("<%=HiddenFieldRequestCltId.ClientID%>").value = data.d.intRequestGrdId;
                                  //alert('trying to disable');
                                  //re
                                  //document.getElementById("<%=ddlProjects.ClientID%>").disabled = true;
                                  $noCon("div#divProjectsDdl input.ui-autocomplete-input").attr("disabled", "disabled");
                                  document.getElementById("cphMain_btnNewProject").disabled = true;
                                 // document.getElementById("divProjectsDdl").disabled = true;

                                   document.getElementById("<%=ddlCurrency.ClientID%>").disabled = true;
                                  document.getElementById("<%=ddlGteeType.ClientID%>").disabled = true;
                                  document.getElementById("<%=ddlCustomerList.ClientID%>").disabled = true;
                                  document.getElementById("<%=txtAmount.ClientID%>").disabled = true;
                                  if (data.d.intGurnttyp == 101) {

                                      document.getElementById("<%=radioOpen.ClientID%>").checked = true;
                                      document.getElementById("<%=radioLimited.ClientID%>").checked = false;
                                      document.getElementById("<%=txtOpngDate.ClientID%>").value = "";
                                      document.getElementById("<%=txtValidity.ClientID%>").value = "";
                                      document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value = "";
                                      document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;
                                      document.getElementById("img1").disabled = true;
                                     

                                  }
                                  else {


                                      document.getElementById("<%=HiddenExpireDate.ClientID%>").value = data.d.strExpireDate;

                                      document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value = data.d.strExpireDate;
                                      document.getElementById("<%=txtValidity.ClientID%>").value = data.d.intNoOfDays;
                                      document.getElementById("<%=HiddenValidatedays.ClientID%>").value = data.d.intNoOfDays;
                                      document.getElementById("<%=txtOpngDate.ClientID%>").value = data.d.stropngDate;
                                      document.getElementById("<%=radioLimited.ClientID%>").checked = true;
                                      document.getElementById("<%=radioOpen.ClientID%>").checked = false;
                                      document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = false;
                                      document.getElementById("img1").disabled = false;
                                      //TextDateChange();
                                  }
                                  AmountChecking('cphMain_txtAmount');
                                  // CalculateTotalAmountWhenBlur(x);


                              }
                          },
                          error: function (result) {
                              // alert("Error");
                          }
                      });

                  }
              }
          }

          function ImportViewDuplcn(x) {
              // if (confirm("Do you want to import the data?")) {
              // document.getElementById('divMessageArea').style.display = "none";
              //document.getElementById('imgMessageArea').src = "";
              // document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
              // document.getElementById("MymodalCancelView").style.display = "none";
              //  document.getElementById("freezelayer").style.display = "none";

              document.getElementById("<%=HiddenImportaddchk.ClientID%>").value = "1";
              document.getElementById("<%=HiddenFieldRequestCltId.ClientID%>").value = x;
              if (document.getElementById("<%=HiddenFieldRequestCltId.ClientID%>").value != "") {

                  $.ajax({
                      type: "POST",
                      async: false,
                      contentType: "application/json; charset=utf-8",
                      url: "gen_Bank_Guarantee.aspx/ReadReqstgurnte",
                      data: '{GuarnteId: "' + x + '"}',
                      dataType: "json",
                      success: function (data) {

                          if (data.d != '') {


                              document.getElementById("<%=LabelCustmrContrctr.ClientID%>").innerHTML = data.d.strCustName;
                              document.getElementById("<%=txtadress.ClientID%>").innerText = data.d.strCustmrAddress;
                              document.getElementById("<%=LblProject.ClientID%>").innerHTML = data.d.strProjctName;
                             // document.getElementById("lblGuarntMde").innerHTML = data.d.strCtacgryNme;
                              var textToFind = data.d.strCtacgryNme;

                              var ddlGteeTypeData = document.getElementById("<%=ddlGteeType.ClientID%>")
                              for (var i = 0; i < ddlGteeTypeData.options.length; i++) {
                                  if (ddlGteeTypeData.options[i].text === textToFind) {
                                      ddlGteeTypeData.selectedIndex = i;
                                      break;
                                  }
                              }
                              //document.getElementById("<%=txtAmount.ClientID%>").disabled = false;
                              //  alert(data.d.decAmount);
                              document.getElementById("<%=txtAmount.ClientID%>").value = data.d.decAmount;
                              // alert("22222");
                              document.getElementById("<%=txtAmount.ClientID%>").disabled = true;
                              //document.getElementById().innerHTML = data.d.strCurracyName;
                              var textToFind = data.d.strCurracyName;

                              var ddlData = document.getElementById("<%=ddlCurrency.ClientID%>")
                               for (var i = 0; i < ddlData.options.length; i++) {
                                   if (ddlData.options[i].text === textToFind) {
                                       ddlData.selectedIndex = i;
                                       break;
                                   }
                               }
                               var ddlProjectData = document.getElementById("<%=ddlProjects.ClientID%>");
                               var opt = new Option(data.d.strProjctName, data.d.intProjctId);
                               ddlProjectData.options.add(opt);
                               var textToFindPrj = data.d.strProjctName;
                               for (var i = 0; i < ddlProjectData.options.length; i++) {
                                   if (ddlProjectData.options[i].text === textToFindPrj) {
                                       // ddlProjectData.selectedIndex = i;
                                      // document.getElementById("<%=ddlProjects.ClientID%>").value = i;
                                       $noCon("div#divProjectsDdl input.ui-autocomplete-input").val(textToFindPrj);
                                           //val(textToFindPrj);
                                       break;
                                   }
                               }
                              
                              document.getElementById("<%=HiddenFieldPRJCTID.ClientID%>").value = data.d.intProjctId;
                              document.getElementById("<%=HiddenFieldCustmor.ClientID%>").value = data.d.intCustNameId;
                              document.getElementById("<%= HiddenFieldMode.ClientID%>").value = data.d.intCtacgryId;
                              document.getElementById("<%=HiddenFieldAmount.ClientID%>").value = data.d.decAmount;
                              document.getElementById("<%=HiddenFieldCurrcy.ClientID%>").value = data.d.intCurracyId;
                              document.getElementById("<%=HiddenFieldRequestCltId.ClientID%>").value = data.d.intRequestGrdId;
                              //re
                              //document.getElementById("<%=ddlProjects.ClientID%>").disabled = true;
                              //document.getElementById("divProjectsDdl").disabled = true;
                             // $noCon("<%=ddlProjects.ClientID%>").attr('autocomplete', 'off');
                              $noCon("div#divProjectsDdl input.ui-autocomplete-input").attr("disabled", "disabled");
                              
                              document.getElementById("cphMain_btnNewProject").disabled = true;
                              document.getElementById("<%=ddlCurrency.ClientID%>").disabled = true;
                              document.getElementById("<%=ddlGteeType.ClientID%>").disabled = true;
                              if (data.d.intGurnttyp == 101) {

                                  document.getElementById("<%=radioOpen.ClientID%>").checked = true;
                                      document.getElementById("<%=radioLimited.ClientID%>").checked = false;
                                      document.getElementById("<%=txtOpngDate.ClientID%>").value = "";
                                      document.getElementById("<%=txtValidity.ClientID%>").value = "";
                                      document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;
                                  document.getElementById("img1").disabled = true;
                                
                                 
                                  }
                                  else {
                                      document.getElementById("<%=HiddenExpireDate.ClientID%>").value = data.d.strExpireDate;
                                      document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value = data.d.strExpireDate;
                                      document.getElementById("<%=txtValidity.ClientID%>").value = data.d.intNoOfDays;
                                      document.getElementById("<%=txtOpngDate.ClientID%>").value = data.d.stropngDate;
                                      document.getElementById("<%=HiddenValidatedays.ClientID%>").value = data.d.intNoOfDays;
                                      document.getElementById("<%=radioLimited.ClientID%>").checked = true;
                                      document.getElementById("<%=radioOpen.ClientID%>").checked = false;
                                      document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = false;
                                      document.getElementById("img1").disabled = false;
                                      //TextDateChange();
                                      document.getElementById("<%=HiddenDuplictnchk.ClientID%>").value = "1";
                                  }
                                  AmountChecking('cphMain_txtAmount');
                              // CalculateTotalAmountWhenBlur(x);


                              }
                      },
                      error: function (result) {
                          // alert("Error");
                      }
                  });

                  }
              // }
              }

              function SearchValidation() {

                  var GuaranteCustomer = document.getElementById("<%=ddlSuplCus.ClientID%>").value;
              var GuaranteMode = document.getElementById("<%=ddlGuaranteeMde.ClientID%>").value;
              var varOrgId = document.getElementById("<%=HiddenOrgansId.ClientID%>").value;
              var varCorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
              var varUserId = document.getElementById("<%=HiddenUserId.ClientID%>").value;

              var vardata = [];
              $Mo.ajax({

                  type: "POST",
                  async: false,
                  contentType: "application/json; charset=utf-8",
                  url: "gen_Bank_Guarantee.aspx/ReadReqstListBySrch",
                  data: '{GuarnteModeId: "' + GuaranteMode + '",CustmerId:"' + GuaranteCustomer + '",StrOrgId:"' + varOrgId + '",StrCorpId:"' + varCorpId + '",StrUserId:"' + varUserId + '"}',
                  dataType: "json",
                  success: function (data) {

                      if (data.d != '') {


                          // vardata = data.d;
                          // $Mo('#divReport').html(data.d);


                          document.getElementById('divReport').innerHTML = data.d;
                          // alert(document.getElementById('divReport').innerHTML);

                      }

                  },
                  error: function (result) {
                      // alert("Error");
                  }
              });

          }

          function OpenCancelView() {



              document.getElementById("MymodalCancelView").style.display = "block";
              document.getElementById("freezelayer").style.display = "";
             // document.getElementById("<%=txtCnclReason.ClientID%>").focus();
              document.getElementById("<%=ddlGuaranteeMde.ClientID%>").focus();
              return false;

          }
          function CloseCancelView() {
              //   if (confirm("Do you want to close  without completing Closing Process?")) {
              document.getElementById('divMessageArea').style.display = "none";
              document.getElementById('imgMessageArea').src = "";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  document.getElementById("MymodalCancelView").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";
              //document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
              // }
          }
          function RadioClientClick() {

              IncrmntConfrmCounter();
              $au('#cphMain_ddlOwnershp').selectToAutocomplete1Letter();

              //document.getElementById("<%=txtValidity.ClientID%>").disabled = true;
              document.getElementById("<%=HiddenImportaddchk.ClientID%>").value = "";
              document.getElementById("DivGrntyTypeDrpDwn").style.display = "none";
              document.getElementById("DivGrntyTyplabl").style.display = "";
              document.getElementById("divSubContract").style.display = "none";
              //document.getElementById("<%=txtAmount.ClientID%>").disabled = true;
              document.getElementById("h2cuscontractr").innerHTML = 'Customer*';
              // document.getElementById("<%=LabelCustmrContrctr.ClientID%>").innerHTML = 'Customer';
              //  document.getElementById("Currencyddl").style.display = "none";
              //document.getElementById("CurrencyLabl").style.display = "";
              // document.getElementById("<%=txtAmount.ClientID%>").Text = 'Amount';
              document.getElementById("imgImport").onmouseup = true;
              document.getElementById("imgImport").onmousedown = true;
              document.getElementById("imgImport").onclick = OpenImport;
              document.getElementById("imgImport").style.opacity = "";
              document.getElementById("ImportrfgLabel").style.opacity = "";
              document.getElementById("divProjectsDdl").style.display = "";

              document.getElementById("<%=LblProject.ClientID%>").style.display = "none";
              document.getElementById("<%=LabelCustmrContrctr.ClientID%>").style.display = "none";
              document.getElementById("<%=ddlCustomerList.ClientID%>").style.display = "";

              if (document.getElementById("<%=radioLimited.ClientID%>").checked == true) {
                  document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = false;

              }
              else {
                  document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;
              }

              CbxChangeProject();

              if (document.getElementById("<%=cbxPrjct.ClientID%>").checked == true) {
                  $au('#cphMain_ddlProjects').selectToAutocomplete1Letter();
                  $noCon("div#divProjectsDdl input.ui-autocomplete-input").focus();
              }
              FocusDate();
              FocusOnDate();
          }


          function RadioSupplierClick() {
              IncrmntConfrmCounter();
              
              // document.getElementById("<%=txtValidity.ClientID%>").disabled = false;
              document.getElementById("DivGrntyTypeDrpDwn").style.display = "";
              document.getElementById("DivGrntyTyplabl").style.display = "none";
              document.getElementById("divSubContract").style.display = "";

              document.getElementById("<%=txtAmount.ClientID%>").disabled = false;

              document.getElementById("h2cuscontractr").innerHTML = 'Contractor';
             
             // document.getElementById("CurrencyLabl").style.display = "none";
            //  document.getElementById("Currencyddl").style.display = "";
              document.getElementById("imgImport").onmouseup = false;
              document.getElementById("imgImport").onmousedown = false;
              document.getElementById("imgImport").onclick = false;
              document.getElementById("imgImport").style.opacity = .2;
              document.getElementById("ImportrfgLabel").style.opacity = .2;
              $au('#cphMain_ddlOwnershp').selectToAutocomplete1Letter();
              document.getElementById("divProjectsDdl").style.display = "none";
              document.getElementById("<%=LblProject.ClientID%>").style.display = "";
              document.getElementById("<%=LabelCustmrContrctr.ClientID%>").style.display = "";
              document.getElementById("<%=ddlCustomerList.ClientID%>").style.display = "none";
              if (document.getElementById("<%=radioLimited.ClientID%>").checked == true) {
                  document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = false;

                }
                else {
                    document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;
              }
              $au('#cphMain_ddlBank').selectToAutocomplete1Letter();
              FocusDate();
              FocusOnDate();
          }
          function RadioopenClick() {
              IncrmntConfrmCounter();

              // document.getElementById("<%=txtValidity.ClientID%>").disabled = true;
              document.getElementById("img1").disabled = true;
              document.getElementById("img1").style.pointerEvents = "none";
              document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = true;

          }
          function RadioLimitedClick() {
              IncrmntConfrmCounter();
              document.getElementById("img1").disabled = false;
              document.getElementById("img1").style.pointerEvents = "";
              //document.getElementById("<%=txtValidity.ClientID%>").disabled = false;
              document.getElementById("<%=txtPrjctClsngDate.ClientID%>").disabled = false;
          }
          function TextDateChange() {

              var chk = document.getElementById("<%=txtOpngDate.ClientID%>").value;

              if(document.getElementById("<%=radioLimited.ClientID%>").checked==true){

                  if (document.getElementById("<%=txtOpngDate.ClientID%>").value != "" && document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value != "") {

                      var OPeningDate = document.getElementById("<%=txtOpngDate.ClientID%>").value;
                      var arrOPeningDate = OPeningDate.split("-");
                      var dateOPeningDate = new Date(arrOPeningDate[2], arrOPeningDate[1] - 1, arrOPeningDate[0]);

                      var ExpireDate = document.getElementById("<%=txtPrjctClsngDate.ClientID%>").value.trim();
                      //alert(ExpireDate);
                      var arrDateExpireDate = ExpireDate.split("-");
                      var datearrDateExpireDate = new Date(arrDateExpireDate[2], arrDateExpireDate[1] - 1, arrDateExpireDate[0]);

                      var timeDiff = Math.abs(datearrDateExpireDate.getTime() - dateOPeningDate.getTime());
                      var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
                      diffDays = diffDays + 1;
                      document.getElementById("<%=txtValidity.ClientID%>").value = diffDays;
                      document.getElementById("<%=HiddenTextValidty.ClientID%>").value = diffDays;
                      document.getElementById("<%=HiddenValidatedays.ClientID%>").value = diffDays;

                  }
                  else {
                      document.getElementById("<%=txtValidity.ClientID%>").value = "";
                      document.getElementById("<%=HiddenTextValidty.ClientID%>").value = "";
                      document.getElementById("<%=HiddenValidatedays.ClientID%>").value = "";
                  }
              }
          }

    </script>


    <script>
        //----------------for notification template-----------------

        var $noC = jQuery.noConflict();
        var EachTemp = 0;

        function EditMoreEachTemplateBnk(TempDetailId, NotifyMod, NotifyVia, NotifyDur) {

            EachTemp++;

            var recRow = '<tr id="TemplateRowId_' + EachTemp + ' >';
            //recRow += '<td>';
            recRow = '<div id=\"divEachTemplate_' + EachTemp + '\" style=\"float:left;margin-top:1%;padding:10px; width:80%;min-height: 170px;margin-left: 10%;border: 1px dotted;border-color: green;\">';
            recRow += '<div id=\"divTempLeftPart_' + EachTemp + '\" class=\"eachform\" style=\"float:left;width: 25%;height: 169px;border-right: 1px dotted;border-color: green;\">';
            recRow += '<h2 style=\"margin-left: 33%;font-size: 20px;color: #006475;\">Period *</h2>';


            recRow += '<div style=\"width:70%;margin-top: 19%;margin-left: 14%;background-color: wheat;color: #076309;border: 1px solid;\" >';

            recRow += '<input id=\"radioDays_' + EachTemp + '\" type=\"radio\" checked="true" onclick=\"UpdateNotifyMOde(' + EachTemp + ');\" name=\"radType' + EachTemp + '\" onkeypress="return DisableEnter(event)" />';

            recRow += '<label style=\"font-family:Calibri\" for=\"radioDays_' + EachTemp + '\">Days</label>';


            recRow += '<input id=\"radioHours_' + EachTemp + '\" type=\"radio\" onclick=\"UpdateNotifyMOde(' + EachTemp + ');\" name=\"radType' + EachTemp + '\" style=\"margin-left: 26px;\" onkeypress="return DisableEnter(event)"/>';
            recRow += '<label style=\"font-family:Calibri\" for=\"radioHours_' + EachTemp + '\">Hours</label>';

            recRow += '</div>';
            recRow += '<div style=\"width: 97%;margin-top: 6%;\">';

            recRow += ' <input type=\"text\" id=\"txtDuration_' + EachTemp + '\" class=\"form1\" onblur=\"UpdateNotifyDuration(' + EachTemp + ');\" onkeydown=\"return isNumber(event);\"  MaxLength=\"4\" Style=\"width: 30%; text-transform: uppercase; margin-right: 31.7%; height: 30px\" onkeypress="return DisableEnter(event)" />';

            recRow += ' <input type=\"button\" id=\"btnDurClear_' + EachTemp + '\" onclick=\"return ClearDur(' + EachTemp + ');\" class=\"ClearDur\" value=\"Clear\" style=\"margin-top: 13%;margin-left: 29%;\" />';
            recRow += ' </div></div>';


            recRow += '<div id="divTempRightPart_' + EachTemp + '" style="float:right;width: 74%;">';
            recRow += '<h2 style="margin-left: 42%;font-size: 20px;color: #006475;">Intimation *</h2>';

            recRow += '<div id=\"divTempRightContainer_' + EachTemp + '\" style=\"height: 135px;overflow: auto;width: 100%;\">';
            recRow += '<table id=\"TableEachTempSliceContainer_' + EachTemp + '\" style=\"width: 100%;\">';
            recRow += '</table>';

            recRow += ' </div>';
            recRow += '<div id=\"divBtmPortion_' + EachTemp + '\">';
            recRow += '<h2 style=\"float:left; margin-left: 1%;font-size: 16px;color: #000;padding-top: 3px;margin-top: 0px;\">Notification*</h2>';
            recRow += '<input type=\"checkbox\" id=\"cbxDashboard_' + EachTemp + '\" onchange=\"UpdateNotifyVia(' + EachTemp + ',\'cbxDashboard_\');\" style=\"float: left;margin-left: 2%\;" Checked=\"true\" class=\"form2\ " onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">DashBoard</h3>';
            recRow += '<input type=\"checkbox\" id="cbxEmail_' + EachTemp + '" onchange=\"UpdateNotifyVia(' + EachTemp + ',\'cbxEmail_\');\" style="float: left;margin-left: 3%;" Checked="true" class="form2" onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">Email</h3>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '<div style=\"float:right;\"><input id="AddEachTempButton_' + EachTemp + '" type=\"image\" src=\"/Images/Icons/black add.png\" onclick="return EachTemplateAddition();" alt=\"Add\" style=\"cursor: pointer;\" /></div>';
            recRow += '<div id="TemplateId_' + EachTemp + '" style="display: none;">' + TempDetailId + '</div>';
            recRow += '<div id="TemplateEvent_' + EachTemp + '" style="display: none;">UPD</div>';

            //recRow += '</td>';
            // recRow += '</tr>';

            jQuery('#TableTemplateContainer').append(recRow);
            document.getElementById("<%=hiddenTemplateCount.ClientID%>").value = EachTemp;

            document.getElementById("txtDuration_" + EachTemp).value = NotifyDur;
            document.getElementById("cbxDashboard_" + EachTemp).checked = false;
            document.getElementById("cbxEmail_" + EachTemp).checked = false;
            if (NotifyMod == 1) {
                document.getElementById("radioHours_" + EachTemp).checked = true;
            }
            else if (NotifyMod == 2) {
                document.getElementById("radioDays_" + EachTemp).checked = true;
            }
            if (NotifyVia != "") {
                if (NotifyVia.indexOf("D") >= 0) {
                    document.getElementById("cbxDashboard_" + EachTemp).checked = true;
                }

                if (NotifyVia.indexOf("E") >= 0) {
                    document.getElementById("cbxEmail_" + EachTemp).checked = true;
                }
            }

            AddDefaultTemplateValues(EachTemp);

            //FOR FILLING EACH SLICE DATA
            var EditEachSliceFullData = document.getElementById("<%=hiddenTemplateAlertData.ClientID%>").value;
            var EditEachTempliceData = EditEachSliceFullData.split("!");

            var findAtt2 = '\\"\\[';
            var reAtt2 = new RegExp(findAtt2, 'g');
            var resAtt2 = EditEachTempliceData[EachTemp].replace(reAtt2, '\[');

            var findAtt3 = '\\]\\"';
            var reAtt3 = new RegExp(findAtt3, 'g');
            var resAtt3 = resAtt2.replace(reAtt3, '\]');

            var jsonAtt = $noCon.parseJSON(resAtt3);

            for (var key in jsonAtt) {
                if (jsonAtt.hasOwnProperty(key)) {
                    if (jsonAtt[key].TempAlertId != "") {
                        EditEachTempSliceBnk(EachTemp, jsonAtt[key].TempAlertId, jsonAtt[key].AlertOpt, jsonAtt[key].AlertNtfyId);
                    }
                }
            }

            if (document.getElementById("<%=hiddenEditMode.ClientID%>").value == "View") {
                document.getElementById("cbxDashboard_" + EachTemp).disabled = true;
                document.getElementById("cbxEmail_" + EachTemp).disabled = true;
                document.getElementById("radioDays_" + EachTemp).disabled = true;
                document.getElementById("radioHours_" + EachTemp).disabled = true;
                document.getElementById("txtDuration_" + EachTemp).disabled = true;
                document.getElementById("AddEachTempButton_" + EachTemp).disabled = true;
            }


            return false;
        }

        function InitialTempValues() {

            EachTemp = 0;
            InitialiseCount();
        }

        function EditMoreEachTemplate(TempDetailId, NotifyMod, NotifyVia, NotifyDur) {

            EachTemp++;

            var recRow = '<tr id="TemplateRowId_' + EachTemp + ' >';
            //recRow += '<td>';
            recRow = '<div id=\"divEachTemplate_' + EachTemp + '\" style=\"float:left;margin-top:1%;padding:10px; width:80%;min-height: 170px;margin-left: 10%;border: 1px dotted;border-color: green;\">';
            recRow += '<div id=\"divTempLeftPart_' + EachTemp + '\" class=\"eachform\" style=\"float:left;width: 25%;height: 169px;border-right: 1px dotted;border-color: green;\">';
            recRow += '<h2 style=\"margin-left: 33%;font-size: 20px;color: #006475;\">Period *</h2>';


            recRow += '<div style=\"width:70%;margin-top: 19%;margin-left: 14%;background-color: wheat;color: #076309;border: 1px solid;\" >';

            recRow += '<input id=\"radioDays_' + EachTemp + '\" type=\"radio\" checked="true" onclick=\"UpdateNotifyMOde(' + EachTemp + ');\" name=\"radType' + EachTemp + '\" onkeypress="return DisableEnter(event)" />';

            recRow += '<label style=\"font-family:Calibri\" for=\"radioDays_' + EachTemp + '\">Days</label>';


            recRow += '<input id=\"radioHours_' + EachTemp + '\" type=\"radio\" onclick=\"UpdateNotifyMOde(' + EachTemp + ');\" name=\"radType' + EachTemp + '\" style=\"margin-left: 26px;\" onkeypress="return DisableEnter(event)"/>';
            recRow += '<label style=\"font-family:Calibri\" for=\"radioHours_' + EachTemp + '\">Hours</label>';

            recRow += '</div>';
            recRow += '<div style=\"width: 97%;margin-top: 6%;\">';

            recRow += ' <input type=\"text\" id=\"txtDuration_' + EachTemp + '\" class=\"form1\" onblur=\"UpdateNotifyDuration(' + EachTemp + ');\" onkeydown=\"return isNumber(event);\"  MaxLength=\"4\" Style=\"width: 30%; text-transform: uppercase; margin-right: 31.7%; height: 30px\" onkeypress="return DisableEnter(event)" />';

            recRow += ' <input type=\"button\" id=\"btnDurClear_' + EachTemp + '\" onclick=\"return ClearDur(' + EachTemp + ');\" class=\"ClearDur\" value=\"Clear\" style=\"margin-top: 13%;margin-left: 29%;\" />';
            recRow += ' </div></div>';


            recRow += '<div id="divTempRightPart_' + EachTemp + '" style="float:right;width: 74%;">';
            recRow += '<h2 style="margin-left: 42%;font-size: 20px;color: #006475;">Intimation *</h2>';

            recRow += '<div id=\"divTempRightContainer_' + EachTemp + '\" style=\"height: 135px;overflow: auto;width: 100%;\">';
            recRow += '<table id=\"TableEachTempSliceContainer_' + EachTemp + '\" style=\"width: 100%;\">';
            recRow += '</table>';

            recRow += ' </div>';
            recRow += '<div id=\"divBtmPortion_' + EachTemp + '\">';
            recRow += '<h2 style=\"float:left; margin-left: 1%;font-size: 16px;color: #000;padding-top: 3px;margin-top: 0px;\">Notification*</h2>';
            recRow += '<input type=\"checkbox\" id=\"cbxDashboard_' + EachTemp + '\" onchange=\"UpdateNotifyVia(' + EachTemp + ',\'cbxDashboard_\');\" style=\"float: left;margin-left: 2%\;" Checked=\"true\" class=\"form2\ " onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">DashBoard</h3>';
            recRow += '<input type=\"checkbox\" id="cbxEmail_' + EachTemp + '" onchange=\"UpdateNotifyVia(' + EachTemp + ',\'cbxEmail_\');\" style="float: left;margin-left: 3%;" Checked="true" class="form2" onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">Email</h3>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '<div style=\"float:right;\"><input id="AddEachTempButton_' + EachTemp + '" type=\"image\" src=\"/Images/Icons/black add.png\" onclick="return EachTemplateAddition();" alt=\"Add\" style=\"cursor: pointer;\" /></div>';
            recRow += '<div id="TemplateId_' + EachTemp + '" style="display: none;"></div>';
            recRow += '<div id="TemplateEvent_' + EachTemp + '" style="display: none;">INS</div>';

            //recRow += '</td>';
            // recRow += '</tr>';

            jQuery('#TableTemplateContainer').append(recRow);
            document.getElementById("<%=hiddenTemplateCount.ClientID%>").value = EachTemp;

            document.getElementById("txtDuration_" + EachTemp).value = NotifyDur;
            document.getElementById("cbxDashboard_" + EachTemp).checked = false;
            document.getElementById("cbxEmail_" + EachTemp).checked = false;
            if (NotifyMod == 1) {
                document.getElementById("radioHours_" + EachTemp).checked = true;
            }
            else if (NotifyMod == 2) {
                document.getElementById("radioDays_" + EachTemp).checked = true;
            }
            if (NotifyVia != "") {
                if (NotifyVia.indexOf("D") >= 0) {
                    document.getElementById("cbxDashboard_" + EachTemp).checked = true;
                }

                if (NotifyVia.indexOf("E") >= 0) {
                    document.getElementById("cbxEmail_" + EachTemp).checked = true;
                }
            }


            AddDefaultTemplateValues(EachTemp);

            //FOR FILLING EACH SLICE DATA
            var EditEachSliceFullData = document.getElementById("<%=hiddenTemplateAlertData.ClientID%>").value;
            var EditEachTempliceData = EditEachSliceFullData.split("!");

            var findAtt2 = '\\"\\[';
            var reAtt2 = new RegExp(findAtt2, 'g');
            var resAtt2 = EditEachTempliceData[EachTemp].replace(reAtt2, '\[');

            var findAtt3 = '\\]\\"';
            var reAtt3 = new RegExp(findAtt3, 'g');
            var resAtt3 = resAtt2.replace(reAtt3, '\]');
            //alert(res3);
            $noCon = jQuery.noConflict();
            var jsonAtt = $noCon.parseJSON(resAtt3);
            for (var key in jsonAtt) {
                if (jsonAtt.hasOwnProperty(key)) {
                    if (jsonAtt[key].TempAlertId != "") {


                        EditEachTempSlice(EachTemp, jsonAtt[key].TempAlertId, jsonAtt[key].AlertOpt, jsonAtt[key].AlertNtfyId);


                    }
                }
            }

            if (document.getElementById("<%=hiddenEditMode.ClientID%>").value == "View") {
                document.getElementById("cbxDashboard_" + EachTemp).disabled = true;
                document.getElementById("cbxEmail_" + EachTemp).disabled = true;
                document.getElementById("radioDays_" + EachTemp).disabled = true;
                document.getElementById("radioHours_" + EachTemp).disabled = true;
                document.getElementById("txtDuration_" + EachTemp).disabled = true;
                document.getElementById("AddEachTempButton_" + EachTemp).disabled = true;
            }


            return false;
        }

        function addMoreEachTemplate() {

            EachTemp++;


            var recRow = '<tr id="TemplateRowId_' + EachTemp + ' >';
            //recRow += '<td>';
            recRow = '<div id=\"divEachTemplate_' + EachTemp + '\" style=\"float:left;margin-top:1%;padding:10px; width:80%;min-height: 170px;margin-left: 10%;border: 1px dotted;border-color: green;\">';
            recRow += '<div id=\"divTempLeftPart_' + EachTemp + '\" class=\"eachform\" style=\"float:left;width: 25%;height: 169px;border-right: 1px dotted;border-color: green;\">';
            recRow += '<h2 style=\"margin-left: 33%;font-size: 20px;color: #006475;\">Period *</h2>';


            recRow += '<div style=\"width:70%;margin-top: 19%;margin-left: 14%;background-color: wheat;color: #076309;border: 1px solid;\" >';
            recRow += '<input id=\"radioDays_' + EachTemp + '\" type=\"radio\" checked="true" onclick=\"UpdateNotifyMOde(' + EachTemp + ');\" name=\"radType' + EachTemp + '\" onkeypress="return DisableEnter(event)" />';
            recRow += '<label style=\"font-family:Calibri\" for=\"radioDays_' + EachTemp + '\">Days</label>';


            recRow += '<input id=\"radioHours_' + EachTemp + '\" type=\"radio\" onclick=\"UpdateNotifyMOde(' + EachTemp + ');\" name=\"radType' + EachTemp + '\" style=\"margin-left: 26px;\" onkeypress="return DisableEnter(event)"/>';
            recRow += '<label style=\"font-family:Calibri\" for=\"radioHours_' + EachTemp + '\">Hours</label>';

            recRow += '</div>';
            recRow += '<div style=\"width: 97%;margin-top: 6%;\">';


            recRow += ' <input type=\"text\" id=\"txtDuration_' + EachTemp + '\" class=\"form1\" onblur=\"UpdateNotifyDuration(' + EachTemp + ');\" onkeydown=\"return isNumber(event);\"  MaxLength=\"4\" Style=\"width: 30%; text-transform: uppercase; margin-right: 31.7%; height: 30px\" onkeypress="return DisableEnter(event)" />';
            recRow += ' <input type=\"button\" id=\"btnDurClear_' + EachTemp + '\" onclick=\"return ClearDur(' + EachTemp + ');\" class=\"ClearDur\" value=\"Clear\" style=\"margin-top: 13%;margin-left: 29%;\" />';
            recRow += ' </div></div>';


            recRow += '<div id="divTempRightPart_' + EachTemp + '" style="float:right;width: 74%;">';
            recRow += '<h2 style="margin-left: 42%;font-size: 20px;color: #006475;">Intimation *</h2>';

            recRow += '<div id=\"divTempRightContainer_' + EachTemp + '\" style=\"height: 135px;overflow: auto;width: 100%;\">';

            recRow += '<table id=\"TableEachTempSliceContainer_' + EachTemp + '\" style=\"width: 100%;\">';
            recRow += '</table>';

            recRow += ' </div>';
            recRow += '<div id=\"divBtmPortion_' + EachTemp + '\">';
            recRow += '<h2 style=\"float:left; margin-left: 1%;font-size: 16px;color: #000;padding-top: 3px;margin-top: 0px;\">Notification*</h2>';
            recRow += '<input type=\"checkbox\" id=\"cbxDashboard_' + EachTemp + '\" checked="true" onchange=\"UpdateNotifyVia(' + EachTemp + ',\'cbxDashboard_\');\" style=\"float: left;margin-left: 2%\;" Checked=\"true\" class=\"form2\ " onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">DashBoard</h3>';
            recRow += '<input type=\"checkbox\" id="cbxEmail_' + EachTemp + '" checked="true" onchange=\"UpdateNotifyVia(' + EachTemp + ',\'cbxEmail_\');\" style="float: left;margin-left: 3%;" Checked="true" class="form2" onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">Email</h3>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '<div style=\"float:right;\"><input type=\"image\" src=\"/Images/Icons/black add.png\" onclick="return EachTemplateAddition();" alt=\"Add\" style=\"cursor: pointer;\" /></div>';
            recRow += '<div id="TemplateId_' + EachTemp + '" style="display: none;"> </div>';
            recRow += '<div id="TemplateEvent_' + EachTemp + '" style="display: none;">INS</div>';

            //recRow += '</td>';
            // recRow += '</tr>';

            jQuery('#TableTemplateContainer').append(recRow);
            AddDefaultTemplateValues(EachTemp);
            AddEachTempSlice(EachTemp);
            document.getElementById("<%=hiddenTemplateCount.ClientID%>").value = EachTemp;

            return false;
        }



        var SliceCounter = 0;

        var EachTeCou = 0;
        var blurcounter = 0;



        function InitialiseCount() {
            EachTemp = 0;
            SliceCounter = 0;
            EachTeCou = 0;
            blurcounter = 0;
        }
        function EditEachTempSliceBnk(EachTempCount, AlertId, AlertOpt, AlrtNtfyId) {

            var FrecRow = '<tr id="EachSliceRowId_' + EachTempCount + '_' + SliceCounter + '" >';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDivi_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/divisions.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DivisionClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div></td>';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDesig_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/designation.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DesignationClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';

            FrecRow += '<td style=\"width:5%\"><div id="divSmallEmp_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/employee.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return EmployeeClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div>  </td>';
            FrecRow += '<td style=\"width:5%\"><div id="divSmallMail_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/generic mail.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return GenericMailClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';
            FrecRow += '<td style=\"width:63%;background-color: #e7e7e7;\">';
            FrecRow += '<select id="ddlDivision_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlDivision_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;" />';
            FrecRow += '<select id="ddlDesignation_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlDesignation_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<select id="ddlEmployee_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlEmployee_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<input type=\"text\" id="txtGenMail_' + EachTempCount + '_' + SliceCounter + '" onblur="TempChangeFile(\'txtGenMail_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;display:none;" MaxLength=\"100\" placeholder="Enter Generic Mail Id" onkeypress="return DisableEnter(event)" />';
            FrecRow += '</td>';
            FrecRow += '<td id="FileIndvlAddMoreRow_' + EachTempCount + '_' + SliceCounter + '"  style=\"width:7%;opacity:1;\"><input id="inputAddRow_' + EachTempCount + '_' + SliceCounter + '" type=\"image\" src=\"/Images/Icons/eachtempadd.png\" alt=\"Add\" onclick="return TempCheckaddMoreRowsIndividualFiles(' + EachTempCount + ',' + SliceCounter + ');" style=\"cursor: pointer;\" /> </td>';
            FrecRow += '<td style=\"width:10%\"><input id="inputDeleteRow_' + EachTempCount + '_' + SliceCounter + '" type=\"image\" src=\"/Images/Icons/eachtempclose.png\" alt=\"Add\" onclick = "return RemoveEachSlice(' + EachTempCount + ',' + SliceCounter + ');"  style=\"cursor: pointer;\" /> </td>';

            FrecRow += '<td id="FileInx_' + EachTempCount + '_' + SliceCounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">' + AlertId + '</td>';
            FrecRow += '<td id="DbFileName_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '<td id="Replace_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">NO</td>';
            FrecRow += '<td id="ReplaceRow_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableEachTempSliceContainer_' + EachTempCount).append(FrecRow);

            // $('#divTempRightContainer_' + EachTempCount).scrollTop($('#divTempRightContainer_' + EachTempCount)[0].scrollHeight);

            document.getElementById("inputAddRow_" + EachTempCount + "_" + SliceCounter).disabled = false;



            if (EachTeCou != EachTempCount && EachTeCou != 0) {

                blurcounter = 0;
            }
            EachTeCou = EachTempCount;

            if (blurcounter != 0) {
                blurSlice = SliceCounter - 1;
                document.getElementById("FileIndvlAddMoreRow_" + EachTempCount + "_" + blurSlice).style.opacity = "0.3";
                document.getElementById("inputAddRow_" + EachTempCount + "_" + blurSlice).disabled = true;

            }

            blurcounter++;


            if (AlertOpt == 0) {
                FillDivisionDdl(EachTempCount, SliceCounter);
                document.getElementById("divSmallDivi_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";
                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "block";
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "none";

                setTimeout(selectDropDown("ddlDivision_", EachTempCount, SliceCounter, AlrtNtfyId), 100);
                FillDesignationDdl(EachTempCount, SliceCounter);
                FillEmployeeDdl(EachTempCount, SliceCounter);

                TempChangeFile('ddlDivision_', EachTempCount, SliceCounter);
            }
            else if (AlertOpt == 1) {
                FillDesignationDdl(EachTempCount, SliceCounter);
                document.getElementById("divSmallDesig_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";

                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "block";
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "none";

                setTimeout(selectDropDown("ddlDesignation_", EachTempCount, SliceCounter, AlrtNtfyId), 100);
                FillDivisionDdl(EachTempCount, SliceCounter);
                FillEmployeeDdl(EachTempCount, SliceCounter);
                TempChangeFile('ddlDesignation_', EachTempCount, SliceCounter);
            }
            else if (AlertOpt == 2) {
                FillEmployeeDdl(EachTempCount, SliceCounter);
                document.getElementById("divSmallEmp_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";

                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "block";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "none";


                setTimeout(selectDropDown("ddlEmployee_", EachTempCount, SliceCounter, AlrtNtfyId), 100);
                FillDesignationDdl(EachTempCount, SliceCounter);
                FillDivisionDdl(EachTempCount, SliceCounter);
                TempChangeFile('ddlEmployee_', EachTempCount, SliceCounter);
            }
            else if (AlertOpt == 3) {

                document.getElementById("divSmallMail_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";
                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "block";

                selectDropDown("txtGenMail_", EachTempCount, SliceCounter, AlrtNtfyId);
                FillEmployeeDdl(EachTempCount, SliceCounter);
                FillDesignationDdl(EachTempCount, SliceCounter);
                FillDivisionDdl(EachTempCount, SliceCounter);
                TempChangeFile('txtGenMail_', EachTempCount, SliceCounter);
            }


            if (document.getElementById("<%=hiddenEditMode.ClientID%>").value == "View") {
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("inputAddRow_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("inputDeleteRow_" + EachTempCount + "_" + SliceCounter).disabled = true;

            }



            SliceCounter++;

            return false;
        }

        function EditEachTempSlice(EachTempCount, AlertId, AlertOpt, AlrtNtfyId) {

            
            var FrecRow = '<tr id="EachSliceRowId_' + EachTempCount + '_' + SliceCounter + '" >';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDivi_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/divisions.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DivisionClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div></td>';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDesig_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/designation.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DesignationClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';

            FrecRow += '<td style=\"width:5%\"><div id="divSmallEmp_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/employee.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return EmployeeClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div>  </td>';
            FrecRow += '<td style=\"width:5%\"><div id="divSmallMail_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/generic mail.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return GenericMailClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';
            FrecRow += '<td style=\"width:63%;background-color: #e7e7e7;\">';
            FrecRow += '<select id="ddlDivision_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlDivision_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;" />';
            FrecRow += '<select id="ddlDesignation_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlDesignation_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<select id="ddlEmployee_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlEmployee_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<input type=\"text\" id="txtGenMail_' + EachTempCount + '_' + SliceCounter + '" onblur="TempChangeFile(\'txtGenMail_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;display:none;" MaxLength=\"100\" placeholder="Enter Generic Mail Id" onkeypress="return DisableEnter(event)" />';
            FrecRow += '</td>';
            FrecRow += '<td id="FileIndvlAddMoreRow_' + EachTempCount + '_' + SliceCounter + '"  style=\"width:7%;opacity:1;\"><input id="inputAddRow_' + EachTempCount + '_' + SliceCounter + '" type=\"image\" src=\"/Images/Icons/eachtempadd.png\" alt=\"Add\" onclick="return TempCheckaddMoreRowsIndividualFiles(' + EachTempCount + ',' + SliceCounter + ');" style=\"cursor: pointer;\" /> </td>';
            FrecRow += '<td style=\"width:10%\"><input id="inputDeleteRow_' + EachTempCount + '_' + SliceCounter + '" type=\"image\" src=\"/Images/Icons/eachtempclose.png\" alt=\"Add\" onclick = "return RemoveEachSlice(' + EachTempCount + ',' + SliceCounter + ');"  style=\"cursor: pointer;\" /> </td>';

            FrecRow += '<td id="FileInx_' + EachTempCount + '_' + SliceCounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">' + AlertId + '</td>';
            FrecRow += '<td id="DbFileName_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '<td id="Replace_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">NO</td>';
            FrecRow += '<td id="ReplaceRow_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableEachTempSliceContainer_' + EachTempCount).append(FrecRow);

            // $('#divTempRightContainer_' + EachTempCount).scrollTop($('#divTempRightContainer_' + EachTempCount)[0].scrollHeight);

            document.getElementById("inputAddRow_" + EachTempCount + "_" + SliceCounter).disabled = false;



            if (EachTeCou != EachTempCount && EachTeCou != 0) {

                blurcounter = 0;
            }
            EachTeCou = EachTempCount;

            if (blurcounter != 0) {
                blurSlice = SliceCounter - 1;
                document.getElementById("FileIndvlAddMoreRow_" + EachTempCount + "_" + blurSlice).style.opacity = "0.3";
                document.getElementById("inputAddRow_" + EachTempCount + "_" + blurSlice).disabled = true;

            }

            blurcounter++;


            if (AlertOpt == 0) {
                FillDivisionDdl(EachTempCount, SliceCounter);
                document.getElementById("divSmallDivi_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";
                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "block";
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "none";

                setTimeout(selectDropDown("ddlDivision_", EachTempCount, SliceCounter, AlrtNtfyId), 100);
                FillDesignationDdl(EachTempCount, SliceCounter);
                FillEmployeeDdl(EachTempCount, SliceCounter);

                TempChangeFile('ddlDivision_', EachTempCount, SliceCounter);
            }
            else if (AlertOpt == 1) {
                FillDesignationDdl(EachTempCount, SliceCounter);
                document.getElementById("divSmallDesig_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";

                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "block";
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "none";

                setTimeout(selectDropDown("ddlDesignation_", EachTempCount, SliceCounter, AlrtNtfyId), 100);
                FillDivisionDdl(EachTempCount, SliceCounter);
                FillEmployeeDdl(EachTempCount, SliceCounter);
                TempChangeFile('ddlDesignation_', EachTempCount, SliceCounter);
            }
            else if (AlertOpt == 2) {
                FillEmployeeDdl(EachTempCount, SliceCounter);
                document.getElementById("divSmallEmp_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";

                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "block";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "none";


                setTimeout(selectDropDown("ddlEmployee_", EachTempCount, SliceCounter, AlrtNtfyId), 100);
                FillDesignationDdl(EachTempCount, SliceCounter);
                FillDivisionDdl(EachTempCount, SliceCounter);
                TempChangeFile('ddlEmployee_', EachTempCount, SliceCounter);
            }
            else if (AlertOpt == 3) {

                document.getElementById("divSmallMail_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";
                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).style.display = "none";
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).style.display = "block";

                selectDropDown("txtGenMail_", EachTempCount, SliceCounter, AlrtNtfyId);
                FillEmployeeDdl(EachTempCount, SliceCounter);
                FillDesignationDdl(EachTempCount, SliceCounter);
                FillDivisionDdl(EachTempCount, SliceCounter);
                TempChangeFile('txtGenMail_', EachTempCount, SliceCounter);
            }


            if (document.getElementById("<%=hiddenEditMode.ClientID%>").value == "View") {
                document.getElementById("txtGenMail_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("ddlEmployee_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("ddlDesignation_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("ddlDivision_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("inputAddRow_" + EachTempCount + "_" + SliceCounter).disabled = true;
                document.getElementById("inputDeleteRow_" + EachTempCount + "_" + SliceCounter).disabled = true;

            }



            SliceCounter++;

            return false;
        }


        function AddEachTempSlice(EachTempCount) {


            var FrecRow = '<tr id="EachSliceRowId_' + EachTempCount + '_' + SliceCounter + '" >';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDivi_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/divisions.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DivisionClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div></td>';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDesig_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/designation.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DesignationClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';

            FrecRow += '<td style=\"width:5%\"><div id="divSmallEmp_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/employee.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return EmployeeClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div>  </td>';
            FrecRow += '<td style=\"width:5%\"><div id="divSmallMail_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/generic mail.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return GenericMailClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';
            FrecRow += '<td style=\"width:63%;background-color: #e7e7e7;\">';
            FrecRow += '<select id="ddlDivision_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlDivision_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;" />';
            FrecRow += '<select id="ddlDesignation_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlDesignation_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<select id="ddlEmployee_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlEmployee_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<input type=\"text\" id="txtGenMail_' + EachTempCount + '_' + SliceCounter + '" onblur="TempChangeFile(\'txtGenMail_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;display:none;" placeholder="Enter Generic Mail Id" onkeypress="return DisableEnter(event)" />';
            FrecRow += '</td>';
            FrecRow += '<td id="FileIndvlAddMoreRow_' + EachTempCount + '_' + SliceCounter + '"  style=\"width:7%;opacity:1;\"><input id="inputAddRow_' + EachTempCount + '_' + SliceCounter + '" type=\"image\" src=\"/Images/Icons/eachtempadd.png\" alt=\"Add\" onclick="return TempCheckaddMoreRowsIndividualFiles(' + EachTempCount + ',' + SliceCounter + ');" style=\"cursor: pointer;\" /> </td>';
            FrecRow += '<td style=\"width:10%\"><input type=\"image\" src=\"/Images/Icons/eachtempclose.png\" alt=\"Add\" onclick = "return RemoveEachSlice(' + EachTempCount + ',' + SliceCounter + ');"  style=\"cursor: pointer;\" /> </td>';

            FrecRow += '<td id="FileInx_' + EachTempCount + '_' + SliceCounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '<td id="Replace_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">NO</td>';
            FrecRow += '<td id="ReplaceRow_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableEachTempSliceContainer_' + EachTempCount).append(FrecRow);
            // $('#divTempRightContainer_' + EachTempCount).scrollTop($('#divTempRightContainer_' + EachTempCount)[0].scrollHeight);
            FillDivisionDdl(EachTempCount, SliceCounter);
            FillDesignationDdl(EachTempCount, SliceCounter);
            FillEmployeeDdl(EachTempCount, SliceCounter);
            document.getElementById("divSmallDivi_" + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";
            SliceCounter++;

            return false;
        }


        function AddEachTempSliceReplace(EachTempCount, Slice, SelectDiv, SelectDrp, opacity) {


            var FrecRow = '<tr id="EachSliceRowId_' + EachTempCount + '_' + SliceCounter + '" >';
            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDivi_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/divisions.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DivisionClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div></td>';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDesig_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/designation.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DesignationClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';

            FrecRow += '<td style=\"width:5%\"><div id="divSmallEmp_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/employee.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return EmployeeClick(' + EachTempCount + ',' + SliceCounter + ')\" /></div>  </td>';
            FrecRow += '<td style=\"width:5%\"><div id="divSmallMail_' + EachTempCount + '_' + SliceCounter + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/generic mail.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return GenericMailClick(' + EachTempCount + ',' + SliceCounter + ')\" /> </div> </td>';
            FrecRow += '<td style=\"width:63%;background-color: #e7e7e7;\">';
            FrecRow += '<select id="ddlDivision_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlDivision_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<select id="ddlDesignation_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlDesignation_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<select id="ddlEmployee_' + EachTempCount + '_' + SliceCounter + '" onchange="TempChangeFile(\'ddlEmployee_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<input type=\"text\" id="txtGenMail_' + EachTempCount + '_' + SliceCounter + '" onblur="TempChangeFile(\'txtGenMail_\',' + EachTempCount + ',' + SliceCounter + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;display:none;" placeholder="Enter Generic Mail Id" />';
            FrecRow += '</td>';
            FrecRow += '<td id="FileIndvlAddMoreRow_' + EachTempCount + '_' + SliceCounter + '"  style=\"width:7%;opacity:1;\"><input id="inputAddRow_' + EachTempCount + '_' + SliceCounter + '" type=\"image\" src=\"/Images/Icons/eachtempadd.png\" alt=\"Add\" onclick="return TempCheckaddMoreRowsIndividualFiles(' + EachTempCount + ',' + SliceCounter + ');" style=\"cursor: pointer;\" /> </td>';
            FrecRow += '<td style=\"width:10%\"><input type=\"image\" src=\"/Images/Icons/eachtempclose.png\" alt=\"Add\" onclick = "return RemoveEachSlice(' + EachTempCount + ',' + SliceCounter + ');"  style=\"cursor: pointer;\" /> </td>';

            FrecRow += '<td id="FileInx_' + EachTempCount + '_' + SliceCounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '<td id="Replace_' + EachTempCount + '_' + SliceCounter + '" style="display: none;">YES</td>';
            FrecRow += '<td id="ReplaceRow_' + EachTempCount + '_' + SliceCounter + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            $('#EachSliceRowId_' + EachTempCount + '_' + Slice).replaceWith(FrecRow);
            FillDivisionDdl(EachTempCount, SliceCounter);
            FillDesignationDdl(EachTempCount, SliceCounter);
            FillEmployeeDdl(EachTempCount, SliceCounter);
            document.getElementById(SelectDiv + EachTempCount + "_" + SliceCounter).style.backgroundColor = "#0246bd";
            document.getElementById(SelectDrp + EachTempCount + "_" + SliceCounter).style.display = "block";

            if (opacity == 0.3) {
                document.getElementById("FileIndvlAddMoreRow_" + EachTempCount + "_" + SliceCounter).style.opacity = "0.3";
                document.getElementById("inputAddRow_" + EachTempCount + "_" + SliceCounter).disabled = true;
            }
            else {
                document.getElementById("FileIndvlAddMoreRow_" + EachTempCount + "_" + SliceCounter).style.opacity = "1";
                document.getElementById("inputAddRow_" + EachTempCount + "_" + SliceCounter).disabled = false;
            }

            SliceCounter++;

            return false;
        }


        function selectDropDown(ddlid, TempCount, SliceCount, ddlvalue) {
            document.getElementById(ddlid + TempCount + "_" + SliceCount).value = ddlvalue;

        }

        function ClearDur(EachTemp) {
            IncrmntConfrmCounter();
            document.getElementById("txtDuration_" + EachTemp).value = "";
            return false;
        }
        //----------for selection process------//
        function ChangeBGColor(divName, Temp, Slice) {
            document.getElementById("divSmallDivi_" + Temp + "_" + Slice).style.backgroundColor = "#fff";
            document.getElementById("divSmallDesig_" + Temp + "_" + Slice).style.backgroundColor = "#fff";
            document.getElementById("divSmallEmp_" + Temp + "_" + Slice).style.backgroundColor = "#fff";
            document.getElementById("divSmallMail_" + Temp + "_" + Slice).style.backgroundColor = "#fff";

            document.getElementById(divName + Temp + "_" + Slice).style.backgroundColor = "#0246bd";

        }
        function DivisionClick(Temp, Slice) {
            IncrmntConfrmCounter();
            ChangeBGColor("divSmallDivi_", Temp, Slice);
            document.getElementById("ddlDivision_" + Temp + "_" + Slice).style.display = "block";
            document.getElementById("ddlDesignation_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlEmployee_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("txtGenMail_" + Temp + "_" + Slice).style.display = "none";

            document.getElementById("ddlDesignation_" + Temp + "_" + Slice).value = 0;
            document.getElementById("ddlEmployee_" + Temp + "_" + Slice).value = 0;
            document.getElementById("txtGenMail_" + Temp + "_" + Slice).value = "";
            var Filerow_index = jQuery('#EachSliceRowId_' + Temp + '_' + Slice).index();
            TempFileLocalStorageDelete(Filerow_index, Temp, Slice);

            document.getElementById("FileEvt_" + Temp + '_' + Slice).innerHTML = "INS";
            document.getElementById("FileSave_" + Temp + '_' + Slice).innerHTML = " ";
            //jQuery('#EachSliceRowId_' + Temp + '_' + Slice).parent().append('');

            opacitypass = document.getElementById("FileIndvlAddMoreRow_" + Temp + "_" + Slice).style.opacity;

            AddEachTempSliceReplace(Temp, Slice, "divSmallDivi_", "ddlDivision_", opacitypass);
            return false;
        }
        function DesignationClick(Temp, Slice) {
            IncrmntConfrmCounter();
            ChangeBGColor("divSmallDesig_", Temp, Slice);
            document.getElementById("ddlDivision_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlDesignation_" + Temp + "_" + Slice).style.display = "block";
            document.getElementById("ddlEmployee_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("txtGenMail_" + Temp + "_" + Slice).style.display = "none";

            document.getElementById("ddlDivision_" + Temp + "_" + Slice).value = 0;
            document.getElementById("ddlEmployee_" + Temp + "_" + Slice).value = 0;
            document.getElementById("txtGenMail_" + Temp + "_" + Slice).value = "";
            var Filerow_index = jQuery('#EachSliceRowId_' + Temp + '_' + Slice).index();
            TempFileLocalStorageDelete(Filerow_index, Temp, Slice);
            document.getElementById("FileEvt_" + Temp + '_' + Slice).innerHTML = "INS";
            document.getElementById("FileSave_" + Temp + '_' + Slice).innerHTML = " ";

            opacitypass = document.getElementById("FileIndvlAddMoreRow_" + Temp + "_" + Slice).style.opacity;
            AddEachTempSliceReplace(Temp, Slice, "divSmallDesig_", "ddlDesignation_", opacitypass);
            return false;
        }
        function EmployeeClick(Temp, Slice) {
            IncrmntConfrmCounter();

            document.getElementById("ddlDivision_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlDesignation_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlEmployee_" + Temp + "_" + Slice).style.display = "block";
            document.getElementById("txtGenMail_" + Temp + "_" + Slice).style.display = "none";

            document.getElementById("ddlDivision_" + Temp + "_" + Slice).value = 0;
            document.getElementById("ddlDesignation_" + Temp + "_" + Slice).value = 0;
            document.getElementById("txtGenMail_" + Temp + "_" + Slice).value = "";

            ChangeBGColor("divSmallEmp_", Temp, Slice);
            var Filerow_index = jQuery('#EachSliceRowId_' + Temp + '_' + Slice).index();
            TempFileLocalStorageDelete(Filerow_index, Temp, Slice);
            document.getElementById("FileEvt_" + Temp + '_' + Slice).innerHTML = "INS";
            document.getElementById("FileSave_" + Temp + '_' + Slice).innerHTML = " ";

            opacitypass = document.getElementById("FileIndvlAddMoreRow_" + Temp + "_" + Slice).style.opacity;
            AddEachTempSliceReplace(Temp, Slice, "divSmallEmp_", "ddlEmployee_", opacitypass);
            return false;
        }
        function GenericMailClick(Temp, Slice) {
            IncrmntConfrmCounter();
            ChangeBGColor("divSmallMail_", Temp, Slice);
            document.getElementById("ddlDivision_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlDesignation_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlEmployee_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("txtGenMail_" + Temp + "_" + Slice).style.display = "block";

            document.getElementById("ddlDivision_" + Temp + "_" + Slice).value = 0;
            document.getElementById("ddlDesignation_" + Temp + "_" + Slice).value = 0;
            document.getElementById("ddlEmployee_" + Temp + "_" + Slice).value = 0;

            var Filerow_index = jQuery('#EachSliceRowId_' + Temp + '_' + Slice).index();
            TempFileLocalStorageDelete(Filerow_index, Temp, Slice);
            document.getElementById("FileEvt_" + Temp + '_' + Slice).innerHTML = "INS";
            document.getElementById("FileSave_" + Temp + '_' + Slice).innerHTML = " ";

            opacitypass = document.getElementById("FileIndvlAddMoreRow_" + Temp + "_" + Slice).style.opacity;
            AddEachTempSliceReplace(Temp, Slice, "divSmallMail_", "txtGenMail_", opacitypass);
            return false;
        }
        //----------end selection process------//

        //--------for binding dropdown list----------//


        function FillDivisionDdl(Temp, Slice) {
            
            var ddlTestDropDownListXML = $noCon("#ddlDivision_" + Temp + "_" + Slice);

            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableDivision";
            if (document.getElementById("<%=hiddenDivisionddlData.ClientID%>").value != 0) {
                
                dropdowndata = document.getElementById("<%=hiddenDivisionddlData.ClientID%>").value;
                var OptionStart = $noCon("<option>--SELECT DIVISION--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);
                $noCon(dropdowndata).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noCon(this).find('CPRDIV_ID').text();
                    var OptionText = $noCon(this).find('CPRDIV_NAME').text();
                    // Create an Option for DropDownList.
                    var option = $noCon("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    ddlTestDropDownListXML.append(option);
                });

            }
            else {

                var IntCorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                var IntOrgId = document.getElementById("<%=HiddenOrgansId.ClientID%>").value;
                $noCon.ajax({
                    async: false,
                    type: "POST",
                    url: "gen_Bank_Guarantee.aspx/DropdownDivisionBind",
                    data: '{tableName:"' + tableName + '",CorpId:"' + IntCorpId + '",OrgId:"' + IntOrgId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $noCon("<option>--SELECT DIVISION--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);

                        // Now find the Table from response and loop through each item (row).
                        $noCon(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noCon(this).find('CPRDIV_ID').text();
                            var OptionText = $noCon(this).find('CPRDIV_NAME').text();
                            // Create an Option for DropDownList.
                            var option = $noCon("<option>" + OptionText + "</option>");
                            option.attr("value", OptionValue);

                            ddlTestDropDownListXML.append(option);
                        });


                    },
                    failure: function (response) {

                    }
                });
            }
           // alert('delay');
        }

        function FillDesignationDdl(Temp, Slice) {

            var ddlTestDropDownListXML = $noCon("#ddlDesignation_" + Temp + "_" + Slice);

            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableDesignation";
            if (document.getElementById("<%=hiddenDesignationddlData.ClientID%>").value != 0) {
                dropdownDesData = document.getElementById("<%=hiddenDesignationddlData.ClientID%>").value;
                var OptionStart = $noCon("<option>--SELECT DESIGNATION--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);
                // Now find the Table from response and loop through each item (row).
                $noCon(dropdownDesData).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noCon(this).find('DSGN_ID').text();
                    var OptionText = $noCon(this).find('DSGN_NAME').text();
                    // Create an Option for DropDownList.
                    var option = $noCon("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    ddlTestDropDownListXML.append(option);
                });
            }
            else {

                var IntCorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                var IntOrgId = document.getElementById("<%=HiddenOrgansId.ClientID%>").value;
                $noCon.ajax({
                    async: false,
                    type: "POST",
                    url: "gen_Bank_Guarantee.aspx/DropdownDesignationBind",
                    data: '{tableName:"' + tableName + '",CorpId:"' + IntCorpId + '",OrgId:"' + IntOrgId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $noCon("<option>--SELECT DESIGNATION--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);
                        // Now find the Table from response and loop through each item (row).
                        $noCon(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noCon(this).find('DSGN_ID').text();
                            var OptionText = $noCon(this).find('DSGN_NAME').text();
                            // Create an Option for DropDownList.
                            var option = $noCon("<option>" + OptionText + "</option>");
                            option.attr("value", OptionValue);

                            ddlTestDropDownListXML.append(option);
                        });
                    },
                    failure: function (response) {

                    }
                });
            }
        }
        function FillEmployeeDdl(Temp, Slice) {

            var ddlTestDropDownListXML = $noCon("#ddlEmployee_" + Temp + "_" + Slice);

            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableEmployee";
            if (document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value != 0) {
                ddlEmpdata = document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value;
                var OptionStart = $noCon("<option>--SELECT EMPLOYEE--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);
                // Now find the Table from response and loop through each item (row).
                $noCon(ddlEmpdata).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noCon(this).find('USR_ID').text();
                    var OptionText = $noCon(this).find('USR_NAME').text();
                    // Create an Option for DropDownList.
                    var option = $noCon("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    ddlTestDropDownListXML.append(option);
                });
            }

            else {
                var IntCorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                var IntOrgId = document.getElementById("<%=HiddenOrgansId.ClientID%>").value;
                $noCon.ajax({
                    async: false,
                    type: "POST",
                    url: "gen_Bank_Guarantee.aspx/DropdownEmployeeBind",
                    data: '{tableName:"' + tableName + '",CorpId:"' + IntCorpId + '",OrgId:"' + IntOrgId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $noCon("<option>--SELECT EMPLOYEE--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);
                        // Now find the Table from response and loop through each item (row).
                        $noCon(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noCon(this).find('USR_ID').text();
                            var OptionText = $noCon(this).find('USR_NAME').text();
                            // Create an Option for DropDownList.
                            var option = $noCon("<option>" + OptionText + "</option>");
                            option.attr("value", OptionValue);

                            ddlTestDropDownListXML.append(option);
                        });
                    },
                    failure: function (response) {

                    }
                });
            }
        }


        //---------end dropdown bind-------//

        function EachTemplateAddition() {
            IncrmntConfrmCounter();
            if (confirm("Are you sure you want to add new template section? You will not be able to delete it in future.")) {

                if (CheckEachTemp() == true) {
                    addMoreEachTemplate();
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }

        function CheckEachTemp() {

            var Count = document.getElementById("<%=hiddenTemplateCount.ClientID%>").value;

              var TempValue = ""
              for (intCount = 1; intCount <= Count; intCount++) {

                  TempValue = localStorage.getItem("tbClientTemplateUpload_" + intCount);
                  if (TempValue == null) {
                      return false;
                  }
              }

              return true;
          }


          function AddDefaultTemplateValues(TempCount) {

              var Fevt = document.getElementById("TemplateEvent_" + TempCount).innerHTML;
              var TemplateId = document.getElementById("TemplateId_" + TempCount).innerHTML;

              //----for notification mode
              var Mode = "";
              if (document.getElementById("radioDays_" + TempCount).checked == true) {
                  Mode = "D";
              }
              else if (document.getElementById("radioHours_" + TempCount).checked == true) {
                  Mode = "H";
              }


              var tbClientNotifyMode = localStorage.getItem("tbClientNotifyMode");
              tbClientNotifyMode = JSON.parse(tbClientNotifyMode); //Converts string to object

              if (tbClientNotifyMode == null) {//If there is no data, initialize an empty array
                  var $FileZ = jQuery.noConflict();

                  if ($FileZ("#cphMain_hiddenNotificationMOde").val() != 0) {
                      var HiddenValue = $FileZ("#cphMain_hiddenNotificationMOde").val();
                      tbClientNotifyMode = JSON.parse(HiddenValue);
                  }
                  else {

                      tbClientNotifyMode = [];
                  }
              }
              if (Fevt == 'INS') {
                  var client = JSON.stringify({
                      ROWID: "" + TempCount + "",
                      NOTMODE: "" + Mode + "",
                      TEMPID: "0"

                  });
              }
              else if (Fevt == 'UPD') {
                  var client = JSON.stringify({
                      ROWID: "" + TempCount + "",
                      NOTMODE: "" + Mode + "",
                      TEMPID: "" + TemplateId + ""

                  });
              }
              tbClientNotifyMode.push(client);
              localStorage.setItem("tbClientNotifyMode", JSON.stringify(tbClientNotifyMode));

              var $FileE = jQuery.noConflict();
              $FileE("#cphMain_hiddenNotificationMOde").val(JSON.stringify(tbClientNotifyMode));

              //---------
              //---for notify via what---
              var Via = "";
              if (document.getElementById("cbxEmail_" + TempCount).checked == true) {
                  Via = Via + "E";
              }
              if (document.getElementById("cbxDashboard_" + TempCount).checked == true) {
                  Via = Via + "," + "D";
              }

              var tbClientNotifyVia = localStorage.getItem("tbClientNotifyVia");
              tbClientNotifyVia = JSON.parse(tbClientNotifyVia); //Converts string to object

              if (tbClientNotifyVia == null) {//If there is no data, initialize an empty array
                  var $FileW = jQuery.noConflict();
                  if ($FileW("#cphMain_hiddenNotifyVia").val() != 0) {
                      var HiddenViaValue = $FileW("#cphMain_hiddenNotifyVia").val();
                      tbClientNotifyVia = JSON.parse(HiddenViaValue);
                  }
                  else {
                      tbClientNotifyVia = [];
                  }
              }

              if (Fevt == 'INS') {


                  var client2 = JSON.stringify({
                      ROWID: "" + TempCount + "",
                      NOTVIA: "" + Via + "",
                      TEMPID: "0"
                  });//Alter the selected item on the table

              }
              else {
                  var client2 = JSON.stringify({
                      ROWID: "" + TempCount + "",
                      NOTVIA: "" + Via + "",
                      TEMPID: "" + TemplateId + ""

                  });

              }

              tbClientNotifyVia.push(client2);
              localStorage.setItem("tbClientNotifyVia", JSON.stringify(tbClientNotifyVia));
              var $FileF = jQuery.noConflict();
              $FileF("#cphMain_hiddenNotifyVia").val(JSON.stringify(tbClientNotifyVia));
              //-----

              //----for notification duration--
              var Duration = document.getElementById("txtDuration_" + TempCount).value;
              var tbClientNotifyDur = localStorage.getItem("tbClientNotifyDur");
              tbClientNotifyDur = JSON.parse(tbClientNotifyDur); //Converts string to object

              if (tbClientNotifyDur == null) { //If there is no data, initialize an empty array
                  var $FileA = jQuery.noConflict();
                  if ($FileA("#cphMain_hiddenNotificationDuration").val() != 0) {
                      var HiddenDurValue = $FileA("#cphMain_hiddenNotificationDuration").val();
                      tbClientNotifyDur = JSON.parse(HiddenDurValue);
                  }
                  else {
                      tbClientNotifyDur = [];
                  }
              }

              if (Fevt == 'INS') {


                  var client3 = JSON.stringify({
                      ROWID: "" + TempCount + "",
                      NOTDUR: "" + Duration + "",
                      TEMPID: "0"
                  });//Alter the selected item on the table

              }
              else {
                  var client3 = JSON.stringify({
                      ROWID: "" + TempCount + "",
                      NOTDUR: "" + Duration + "",
                      TEMPID: "" + TemplateId + ""

                  });

              }

              tbClientNotifyDur.push(client3);
              localStorage.setItem("tbClientNotifyDur", JSON.stringify(tbClientNotifyDur));
              var $FileG = jQuery.noConflict();
              $FileG("#cphMain_hiddenNotificationDuration").val(JSON.stringify(tbClientNotifyDur));
              return false;
          }


          function UpdateNotifyMOde(TempCount) {

              var Fevt = document.getElementById("TemplateEvent_" + TempCount).innerHTML;
              var TemplateId = document.getElementById("TemplateId_" + TempCount).innerHTML;

              var Mode = "";
              if (document.getElementById("radioDays_" + TempCount).checked == true) {
                  Mode = "D";
              }
              else if (document.getElementById("radioHours_" + TempCount).checked == true) {
                  Mode = "H";
              }

              var row_index = TempCount - 1;
              //var row_index = jQuery('#TemplateRowId_' + TempCount ).index();

              var tbClientNotifyMode = localStorage.getItem("tbClientNotifyMode");
              if (tbClientNotifyMode == null) {
                  var $FileG = jQuery.noConflict();
                  tbClientNotifyMode = $FileG("#cphMain_hiddenNotificationMOde").val();
              }


              tbClientNotifyMode = JSON.parse(tbClientNotifyMode); //Converts string to object


              if (tbClientNotifyMode == null) //If there is no data, initialize an empty array
                  tbClientNotifyMode = [];


              if (Fevt == 'INS') {

                  tbClientNotifyMode[row_index] = JSON.stringify({
                      ROWID: "" + TempCount + "",
                      NOTMODE: "" + Mode + "",
                      TEMPID: " 0"
                  });//Alter the selected item on the table
              }
              else {
                  tbClientNotifyMode[row_index] = JSON.stringify({
                      ROWID: "" + TempCount + "",
                      NOTMODE: "" + Mode + "",
                      TEMPID: "" + TemplateId + ""

                  });

              }

              localStorage.setItem("tbClientNotifyMode", JSON.stringify(tbClientNotifyMode));
              var $FileE = jQuery.noConflict();
              $FileE("#cphMain_hiddenNotificationMOde").val(JSON.stringify(tbClientNotifyMode));

          }
          function UpdateNotifyDuration(TempCount) {


              var NameWithoutReplace = document.getElementById("txtDuration_" + TempCount).value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("txtDuration_" + TempCount).value = replaceText2;

              var txtPerVal = document.getElementById("txtDuration_" + TempCount).value;
              document.getElementById("txtDuration_" + TempCount).style.borderColor = "";

              if (txtPerVal.indexOf('.') !== -1) {
                  document.getElementById("txtDuration_" + TempCount).value = "";
                  document.getElementById("txtDuration_" + TempCount).style.borderColor = "red";

              }
              if (!isNaN(txtPerVal) == false) {

                  document.getElementById("txtDuration_" + TempCount).value = "";
                  document.getElementById("txtDuration_" + TempCount).style.borderColor = "red";

              }
              else {
                  if (txtPerVal < 0) {
                      document.getElementById("txtDuration_" + TempCount).value = "";
                      document.getElementById("txtDuration_" + TempCount).style.borderColor = "red";

                  }
              }


              var Fevt = document.getElementById("TemplateEvent_" + TempCount).innerHTML;
              var TemplateId = document.getElementById("TemplateId_" + TempCount).innerHTML;
              var Duration = document.getElementById("txtDuration_" + TempCount).value;
              var row_index = TempCount - 1;
              //var row_index = jQuery('#TemplateRowId_' + TempCount).index();

              var tbClientNotifyDur = localStorage.getItem("tbClientNotifyDur");

              if (tbClientNotifyDur == null) {
                  var $FileM = jQuery.noConflict();
                  tbClientNotifyDur = $FileM("#cphMain_hiddenNotificationDuration").val();

              }

              tbClientNotifyDur = JSON.parse(tbClientNotifyDur); //Converts string to object

              if (tbClientNotifyDur == null) //If there is no data, initialize an empty array
                  tbClientNotifyDur = [];

              if (Fevt == 'INS') {


                  tbClientNotifyDur[row_index] = JSON.stringify({
                      ROWID: "" + TempCount + "",
                      NOTDUR: "" + Duration + "",
                      TEMPID: "0"
                  });//Alter the selected item on the table

              }
              else {
                  tbClientNotifyDur[row_index] = JSON.stringify({
                      ROWID: "" + TempCount + "",
                      NOTDUR: "" + Duration + "",
                      TEMPID: "" + TemplateId + ""

                  });

              }

              localStorage.setItem("tbClientNotifyDur", JSON.stringify(tbClientNotifyDur));
              var $FileG = jQuery.noConflict();
              $FileG("#cphMain_hiddenNotificationDuration").val(JSON.stringify(tbClientNotifyDur));

          }
          function UpdateNotifyVia(TempCount, ClickedCbx) {

              var Fevt = document.getElementById("TemplateEvent_" + TempCount).innerHTML;
              var TemplateId = document.getElementById("TemplateId_" + TempCount).innerHTML;
              var Via = "";
              if (document.getElementById("cbxEmail_" + TempCount).checked == true) {

                  Via = Via + "," + "E";
              }
              if (document.getElementById("cbxDashboard_" + TempCount).checked == true) {

                  Via = Via + "," + "D";
              }

              var row_index = TempCount - 1;

              //var row_index = jQuery('#TemplateRowId_' + TempCount).index();

              var tbClientNotifyVia = localStorage.getItem("tbClientNotifyVia");

              if (tbClientNotifyVia == null) {
                  var $FileH = jQuery.noConflict();
                  tbClientNotifyVia = $FileH("#cphMain_hiddenNotifyVia").val();

              }

              tbClientNotifyVia = JSON.parse(tbClientNotifyVia); //Converts string to object

              if (tbClientNotifyVia == null) //If there is no data, initialize an empty array
                  tbClientNotifyVia = [];

              if (Fevt == 'INS') {


                  tbClientNotifyVia[row_index] = JSON.stringify({
                      ROWID: "" + TempCount + "",
                      NOTVIA: "" + Via + "",
                      TEMPID: "0"
                  });//Alter the selected item on the table

              }
              else {
                  tbClientNotifyVia[row_index] = JSON.stringify({
                      ROWID: "" + TempCount + "",
                      NOTVIA: "" + Via + "",
                      TEMPID: "" + TemplateId + ""

                  });

              }

              localStorage.setItem("tbClientNotifyVia", JSON.stringify(tbClientNotifyVia));
              var $FileF = jQuery.noConflict();
              $FileF("#cphMain_hiddenNotifyVia").val(JSON.stringify(tbClientNotifyVia));

          }

          function RemoveEachSlice(TempCount, removeNum) {
              if (confirm("Are you sure you want to delete?")) {
                  //  alert('ASD');
                  var Filerow_index = jQuery('#EachSliceRowId_' + TempCount + '_' + removeNum).index();
                  TempFileLocalStorageDelete(Filerow_index, TempCount, removeNum);
                  jQuery('#EachSliceRowId_' + TempCount + '_' + removeNum).remove();

                  // alert(Filerow_index);

                  var TableFileRowCount = document.getElementById("TableEachTempSliceContainer_" + TempCount).rows.length;

                  if (TableFileRowCount != 0) {
                      var idlast = $noC('#TableEachTempSliceContainer_' + TempCount + ' tr:last').attr('id');

                      //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                      //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                      if (idlast != "") {
                          var res = idlast.split("_");
                          //  alert(res[1]);
                          document.getElementById("FileInx_" + TempCount + '_' + res[2]).innerHTML = " ";
                          document.getElementById("FileIndvlAddMoreRow_" + TempCount + '_' + res[2]).style.opacity = "1";
                          document.getElementById("inputAddRow_" + TempCount + "_" + res[2]).disabled = false;
                      }
                  }
                  else {
                      AddEachTempSlice(TempCount);


                  }

              }
              else {

                  return false;
              }
          }


    </script>
      <script>
          function TempChangeFile(DDL, TempCount, Slice) {

              IncrmntConfrmCounter();
              ret = true;
              if (DDL == "txtGenMail_") {
                  var NameWithoutReplace = document.getElementById(DDL + TempCount + "_" + Slice).value;
                  var replaceText1 = NameWithoutReplace.replace(/</g, "");
                  var replaceText2 = replaceText1.replace(/>/g, "");
                  document.getElementById(DDL + TempCount + "_" + Slice).value = replaceText2;

                  document.getElementById(DDL + TempCount + "_" + Slice).style.borderColor = "";
                  var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                  var ToMail = document.getElementById(DDL + TempCount + "_" + Slice).value;
                  var ToMailSplit = [];
                  ToMailSplit = ToMail.split(',');
                  if (ToMailSplit != "") {
                      for (ArrCount = 0; ArrCount < ToMailSplit.length; ArrCount++) {


                          if (!filter.test(ToMailSplit[ArrCount])) {
                              document.getElementById(DDL + TempCount + "_" + Slice).style.borderColor = "red";

                              ret = false;
                          }

                      }
                  }
              }
              if (DDL == "txtGenMail_") {
                  if (ret == true) {
                      var SavedorNot = document.getElementById("FileSave_" + TempCount + "_" + Slice).innerHTML;

                      if (SavedorNot == "saved") {

                          var row_index = jQuery('#EachSliceRowId_' + TempCount + '_' + Slice).index();

                          TempFileLocalStorageEdit(DDL, TempCount, Slice, row_index);
                      }
                      else {

                          TempFileLocalStorageAdd(DDL, TempCount, Slice);
                      }
                  }
                  else {
                      var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_" + TempCount);//Retrieve the stored data

                      tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload);

                      if (tbClientTemplateUpload != null && tbClientTemplateUpload != []) {
                          var Filerow_index = jQuery('#EachSliceRowId_' + TempCount + '_' + Slice).index();
                          TempFileLocalStorageDelete(Filerow_index, Temp, Slice);

                      }
                  }
              }
              else {
                  var DropDownValue = document.getElementById(DDL + TempCount + '_' + Slice).value;
                  if (DropDownValue != 0) {
                      //------for deciding add or edit---------

                      var SavedorNot = document.getElementById("FileSave_" + TempCount + "_" + Slice).innerHTML;

                      if (SavedorNot == "saved") {

                          var row_index = jQuery('#EachSliceRowId_' + TempCount + '_' + Slice).index();

                          TempFileLocalStorageEdit(DDL, TempCount, Slice, row_index);
                      }
                      else {

                          TempFileLocalStorageAdd(DDL, TempCount, Slice);
                      }
                  }
                  else {

                      var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_" + TempCount);//Retrieve the stored data

                      tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload);
                      if (tbClientTemplateUpload != null && tbClientTemplateUpload != []) {
                          var Filerow_index = jQuery('#EachSliceRowId_' + TempCount + '_' + Slice).index();
                          TempFileLocalStorageDelete(Filerow_index, TempCount, Slice);
                      }
                  }

              }

          }

          function TempCheckaddMoreRowsIndividualFiles(TempCount, x) {

              if (CheckEachDdl(TempCount, x)) {

                  var check = document.getElementById("FileInx_" + TempCount + "_" + x).innerHTML;
                  if (check == " ") {
                      var Fevt = document.getElementById("FileEvt_" + TempCount + "_" + x).innerHTML;
                      if (Fevt != 'UPD') {

                          document.getElementById("FileInx_" + TempCount + "_" + x).innerHTML = TempCount + "_" + x;
                          document.getElementById("FileIndvlAddMoreRow_" + TempCount + "_" + x).style.opacity = "0.3";


                          AddEachTempSlice(TempCount);
                          document.getElementById("inputAddRow_" + TempCount + "_" + x).disabled = true;
                          return false;

                      }
                      else {

                          document.getElementById("FileInx_" + TempCount + "_" + x).innerHTML = TempCount + "_" + x;
                          document.getElementById("FileIndvlAddMoreRow_" + TempCount + "_" + x).style.opacity = "0.3";

                          AddEachTempSlice(TempCount);
                          document.getElementById("inputAddRow_" + TempCount + "_" + x).disabled = true;
                          return false;
                      }
                  }
              }
              else {
                  return false;
              }

          }

          function CheckEachDdl(Temp, Slice) {

              if (document.getElementById("ddlDivision_" + Temp + "_" + Slice).value == 0 && document.getElementById("ddlDesignation_" + Temp + "_" + Slice).value == 0 && document.getElementById("ddlEmployee_" + Temp + "_" + Slice).value == 0 && document.getElementById("txtGenMail_" + Temp + "_" + Slice).value == "") {
                  return false;
              }
              else {
                  return true;
              }

          }


          function TempFileLocalStorageAdd(ddl, TempCount, Slice) {


              var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_" + TempCount);//Retrieve the stored data

              tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload); //Converts string to object

              if (tbClientTemplateUpload == null) //If there is no data, initialize an empty array
                  tbClientTemplateUpload = [];

              if (document.getElementById("Replace_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML == "") {

                  editedIndex = tbClientTemplateUpload.length;
                  document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML = editedIndex;
              }


              var DropDownValue = document.getElementById(ddl + TempCount + '_' + Slice).value;
              var FdetailId = document.getElementById("FileDtlId_" + TempCount + '_' + Slice).innerHTML;
              var Fevt = document.getElementById("FileEvt_" + TempCount + '_' + Slice).innerHTML;
              //   alert('FilePath' + FilePath);

              if (Fevt == 'INS') {
                  var client = JSON.stringify({
                      ROWID: "" + Slice + "",
                      DDLVALUE: "" + DropDownValue + "",
                      DDLMODE: "" + ddl + "",
                      EVTACTION: "" + Fevt + "",
                      DTLID: "0"

                  });
              }
              else if (Fevt == 'UPD') {
                  var client = JSON.stringify({
                      ROWID: "" + Slice + "",
                      DDLVALUE: "" + DropDownValue + "",
                      DDLMODE: "" + ddl + "",
                      EVTACTION: "" + Fevt + "",
                      DTLID: "" + FdetailId + ""

                  });
              }

              tbClientTemplateUpload.push(client);
              localStorage.setItem("tbClientTemplateUpload_" + TempCount, JSON.stringify(tbClientTemplateUpload));

              //alert("temp  "+localStorage.getItem("tbClientTemplateUpload_" + TempCount));

              // $addFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientQuotationFileUpload));




              document.getElementById("FileSave_" + TempCount + '_' + Slice).innerHTML = "saved";
              //   alert('saved');
              return true;

          }

          function TempFileLocalStorageEdit(ddl, TempCount, Slice, row_index) {

              if (document.getElementById("Replace_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML != "") {
                  row_index = document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML;
              }

              var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_" + TempCount);//Retrieve the stored data

              tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload); //Converts string to object

              if (tbClientTemplateUpload == null) //If there is no data, initialize an empty array
                  tbClientTemplateUpload = [];
              var DropDownValue = document.getElementById(ddl + TempCount + '_' + Slice).value;
              var FdetailId = document.getElementById("FileDtlId_" + TempCount + '_' + Slice).innerHTML;
              var Fevt = document.getElementById("FileEvt_" + TempCount + '_' + Slice).innerHTML;

              var tbClientTemplateUploadCancel = localStorage.getItem("tbClientTemplateUploadDelete_" + TempCount);//Retrieve the stored data

              tbClientTemplateUploadCancel = JSON.parse(tbClientTemplateUploadCancel);
              if (tbClientTemplateUploadCancel == null) //If there is no data, initialize an empty array
                  tbClientTemplateUploadCancel = [];
              deleteLength = tbClientTemplateUploadCancel.length;

              if (document.getElementById("Replace_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML != "") {
                  row_index = document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML;

              }
              else if (document.getElementById("Replace_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML == "") {

              }
              else {

                  row_index = row_index - deleteLength;

              }


              if (Fevt == 'INS') {


                  tbClientTemplateUpload[row_index] = JSON.stringify({
                      ROWID: "" + Slice + "",
                      DDLVALUE: "" + DropDownValue + "",
                      DDLMODE: "" + ddl + "",
                      EVTACTION: "" + Fevt + "",
                      DTLID: "0"
                  });//Alter the selected item on the table

              }
              else {
                  tbClientTemplateUpload[row_index] = JSON.stringify({
                      ROWID: "" + Slice + "",
                      DDLVALUE: "" + DropDownValue + "",
                      DDLMODE: "" + ddl + "",
                      EVTACTION: "" + Fevt + "",
                      DTLID: "" + FdetailId + ""

                  });//Alter the selected item on the table



              }

              localStorage.setItem("tbClientTemplateUpload_" + TempCount, JSON.stringify(tbClientTemplateUpload));
              //$FileE("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientTemplateUpload));
              return true;
          }

          function TempFileLocalStorageDelete(row_index, TempCount, Slice) {

              var $DelFile = jQuery.noConflict();
              var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_" + TempCount);//Retrieve the stored data

              tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload); //Converts string to object
              if (tbClientTemplateUpload == null) //If there is no data, initialize an empty array
                  tbClientTemplateUpload = [];

              ContentCount = tbClientTemplateUpload.length;
              // Using splice() we can specify the index to begin removing items, and the number of items to remove.
              var tbClientTemplateUploadCancel = localStorage.getItem("tbClientTemplateUploadDelete_" + TempCount);//Retrieve the stored data

              tbClientTemplateUploadCancel = JSON.parse(tbClientTemplateUploadCancel);
              if (tbClientTemplateUploadCancel == null) //If there is no data, initialize an empty array
                  tbClientTemplateUploadCancel = [];
              deleteLength = tbClientTemplateUploadCancel.length;



              if (document.getElementById("Replace_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML != "") {
                  row_index = document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML;

                  if (ContentCount == 1) {
                      row_index = 0;
                  }

                  tbClientTemplateUpload.splice(row_index, 1);
              }
              else if (document.getElementById("Replace_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_" + TempCount + '_' + Slice).innerHTML == "") {

              }
              else {

                  row_index = row_index - deleteLength;


                  if (ContentCount == 1) {
                      row_index = 0;
                  }

                  tbClientTemplateUpload.splice(row_index, 1);
              }
              localStorage.setItem("tbClientTemplateUpload_" + TempCount, JSON.stringify(tbClientTemplateUpload));
              // $DelFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientTemplateUpload));


              var Fevt = document.getElementById("FileEvt_" + TempCount + '_' + Slice).innerHTML;
              if (Fevt == 'UPD') {
                  var FdetailId = document.getElementById("FileDtlId_" + TempCount + '_' + Slice).innerHTML;

                  if (FdetailId != '') {

                      DeleteFileLSTORAGEAdd(TempCount, Slice);
                  }

              }
          }

          function DeleteFileLSTORAGEAdd(TempCount, Slice) {


              var tbClientTemplateUploadCancel = localStorage.getItem("tbClientTemplateUploadDelete_" + TempCount);//Retrieve the stored data

              tbClientTemplateUploadCancel = JSON.parse(tbClientTemplateUploadCancel); //Converts string to object

              if (tbClientTemplateUploadCancel == null) //If there is no data, initialize an empty array
                  tbClientTemplateUploadCancel = [];

              var FdetailId = document.getElementById("FileDtlId_" + TempCount + "_" + Slice).innerHTML;

              var $addFile = jQuery.noConflict();
              var client = JSON.stringify({
                  ROWID: "" + Slice + "",
                  // FILENAME: "" + FileName + "",
                  // EVTACTION: "" + Fevt + "",
                  DTLID: "" + FdetailId + ""

              });



              tbClientTemplateUploadCancel.push(client);
              localStorage.setItem("tbClientTemplateUploadDelete_" + TempCount, JSON.stringify(tbClientTemplateUploadCancel));

              $addFile("#cphMain_hiddenDeleteSliceData").val(JSON.stringify(tbClientTemplateUploadCancel));


              return true;

          }

          function TemplateLoad(a) {

              localStorage.clear();
              document.getElementById("<%=HiddenImportaddchk.ClientID%>").value = a;
              document.getElementById("<%=hiddenNotificationMOde.ClientID%>").value = 0;
              document.getElementById("<%=hiddenNotifyVia.ClientID%>").value = 0;
              document.getElementById("<%=hiddenNotificationDuration.ClientID%>").value = 0;

              if (document.getElementById("<%=hiddenEachTemplateDetail.ClientID%>").value != 0) {
                  var EditEachTemplate = document.getElementById("<%=hiddenEachTemplateDetail.ClientID%>").value;
                  var findAtt2 = '\\"\\[';
                  var reAtt2 = new RegExp(findAtt2, 'g');
                  var resAtt2 = EditEachTemplate.replace(reAtt2, '\[');

                  var findAtt3 = '\\]\\"';
                  var reAtt3 = new RegExp(findAtt3, 'g');
                  var resAtt3 = resAtt2.replace(reAtt3, '\]');
                  //alert(res3);
                  var jsonAtt = $noCon.parseJSON(resAtt3);
                  for (var key in jsonAtt) {
                      if (jsonAtt.hasOwnProperty(key)) {

                          if (jsonAtt[key].TempDetailId != "") {

                              //   alert(jsonAtt[key].ActualFileName);
                              EditMoreEachTemplate(jsonAtt[key].TempDetailId, jsonAtt[key].NotifyMod, jsonAtt[key].NotifyVia, jsonAtt[key].NotifyDur);



                              //  alert(json[key].Amount);
                          }
                      }
                  }


              }
              else {

                  addMoreEachTemplate();
              }

              document.getElementById("<%=ddlTemplate.ClientID%>").focus();
          }

          function ImportNotPossible() {
              alert("Sorry, this request has been already added in bank guarantee");
              return false;

          }
          function clearHiddenTemp() {

              clearhidd_INSRNC();
             // ret = true;
              IncrmntConfrmCounter();
              document.getElementById("<%=hiddenDivisionddlData.ClientID%>").value = 0;
              document.getElementById("<%=hiddenDesignationddlData.ClientID%>").value = 0;
              document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value = 0;
             // var SubContract = document.getElementById("<%=ddlSubContrct.ClientID%>").value;
              //if (SubContract == "--SELECT SUBCONTRACT--")
              //{
              //    ret = false;
              //}
             // alert(ret);
              return ret;
          }
         
          function clearHidden() {

              clearhidd_INSRNC();

              IncrmntConfrmCounter();
              
              document.getElementById("<%=hiddenDivisionddlData.ClientID%>").value = 0;
              document.getElementById("<%=hiddenDesignationddlData.ClientID%>").value = 0;
              document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value = 0;

              document.getElementById("<%=hiddenTemplateChange.ClientID%>").value = "CHANGED";
              InitialiseCount();
            //  alert(document.getElementById("<%=HiddenImportaddchk.ClientID%>").value);
              return true;
          }
          function AlertGoProject() {
              if (confirm("Are you sure you want to leave the page?")) {
                  window.location = "/Master/gen_Projects/gen_ProjectsList.aspx";
                  return false;
              }
              else {
                  return false;
              }
          }
         
          function clearhidd()
          {
              //alert("11");
              document.getElementById("<%=hiddenDivisionddlData.ClientID%>").value = 0;
              document.getElementById("<%=hiddenDesignationddlData.ClientID%>").value = 0;
              document.getElementById("<%=hiddenEmployeeDdlData.ClientID%>").value = 0;
            
          }
          function PostBackDdl() {
              clearhidd();
              clearhidden_INSRNC();
              
              var a = document.getElementById("<%=ddlGteeType.ClientID%>").value;
 
              if (a != "--SELECT GUARANTEE MODE--") {
                  __doPostBack('cphMain_ddlGteeType');
              }
          }
          function PostBackProjectDdl() {
              clearhidd();
              clearhidden_INSRNC();

              if (document.getElementById("<%=ddlPolicyType.ClientID%>").value == "1") {
                  //   alert();
                  var a = $noCon("#cphMain_ddlProjects option:selected").val();


                  if (a != "--SELECT PROJECT--" && a != "") {
                      var OrgId = document.getElementById("<%=HiddenOrgansId.ClientID%>").value;
                      var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;

                      var Details = PageMethods.ReadCusByPrjctId(a, OrgId, CorpId, function (response) {

                          document.getElementById("<%=HiddenProjctsave.ClientID%>").value = a;
                          if (response[2] == "1") {
                              LoadCustomer(response[0], response[1]);
                          }
                          else {
                              document.getElementById("<%=ddlCustomerList.ClientID%>").value = "--SELECT CUSTOMER--";
                              document.getElementById("<%=txtadress.ClientID%>").value = "";

                          }

                      });
                  }
                  // if (a == "--SELECT PROJECT--") {

                  //  document.getElementById("<%=ddlCustomerList.ClientID%>").value = "--SELECT CUSTOMER--";
                  //  document.getElementById("<%=txtadress.ClientID%>").value = "";
                  // }
                  //alert(a);
                  //if ( a == "") {
                  //    __doPostBack('cphMain_ddlProjects');
                  //}
                  //if (a != "--SELECT PROJECT--" && a!="") {
                  //    __doPostBack('cphMain_ddlProjects');
                  //}
                  //$noCon('#cphMain_ddlProjects').selectToAutocomplete1Letter();
                  return false;
              }
          }
          function cancelClickClearHidd() {
              clearhidd();
              clearHidden();
              clearHiddenTemp();
              clearhidden_INSRNC();
              clearhidden_INSRNC();
              clearhiddenTemp_INSRNC();
          }
          function LoadCustomer(intCustmrid, strAddress) {
              var ddlCustomerData = document.getElementById("<%=ddlCustomerList.ClientID%>");
             
              for (var i = 0; i < ddlCustomerData.options.length; i++) {
                  
                  if (ddlCustomerData.options[i].value == intCustmrid) {
                      
                      ddlCustomerData.options[i].selected = true;
                      break;
                  }
              }
             
              document.getElementById("<%=txtadress.ClientID%>").value = strAddress;
          }
          function DuplctnGuarntNum() {
       
              var OrgId = document.getElementById("<%=HiddenOrgansId.ClientID%>").value;
              var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
              var GurntId = document.getElementById("<%=HiddenFieldGuarntId.ClientID%>").value;
            
              var NameWithoutReplace = document.getElementById("<%=txtGuarnteno.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtGuarnteno.ClientID%>").value = replaceText2;
              var GurntNo = document.getElementById("<%=txtGuarnteno.ClientID%>").value.trim();
              var Details = PageMethods.DuplctnGurntNumChk(OrgId, CorpId, GurntId,GurntNo, function (response) {
                  
                  document.getElementById("<%=HiddenGurntNumDupChk.ClientID%>").value = response;
                 
              });
              return false;
          }
        
          function CustomerOnchange() {
              var OrgId = document.getElementById("<%=HiddenOrgansId.ClientID%>").value;
              var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
              var CustId = document.getElementById("<%=ddlCustomerList.ClientID%>").value;
              var Details = PageMethods.CustomerChange(OrgId, CorpId, CustId, function (response) {
                  document.getElementById("<%=txtadress.ClientID%>").value = response;

              });

          }

          function ddlExistEmpChange() {
              clearhidd();
              clearhidden_INSRNC();
              IncrmntConfrmCounter();


              var OrgId = document.getElementById("<%=HiddenOrgansId.ClientID%>").value;
              var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
              var EmpId = document.getElementById("<%=ddlExistingEmp.ClientID%>").value;

              var Details = PageMethods.CallExistEmpChange(OrgId, CorpId, EmpId, function (response) {

                  document.getElementById("<%=txtCntctMail.ClientID%>").value = response[0];
                  document.getElementById("<%=hiddenFieldUserId.ClientID%>").value = response[1];
              });
          }

          function NewProjectLoad() {

              if (document.getElementById("<%=ddlGteeType.ClientID%>").value != "--SELECT GUARANTEE MODE--") {

                  if (confirm('Are you sure you want to add new project?') == true) {

                      var PrjctNme = '';

                      var nWindow = window.open('/Master/gen_Projects/gen_Projects.aspx?PRFG=' + PrjctNme + '&RFGP=RFG', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                      nWindow.focus();
                  }
                  $au('#cphMain_ddlBank').selectToAutocomplete1Letter();
              }
              else {
                  alert("Please select the guarantee mode under which project is to be added first!");
                  document.getElementById("<%=ddlGteeType.ClientID%>").focus();
              }

              return false;
          }
          function PostbackFunProject(myValPrj) {

              clearhidd();
              clearhidden_INSRNC();
              //alert(myValPrj);

              document.getElementById("<%=hiddenNewProjectId.ClientID%>").value = myValPrj;
             
                   __doPostBack("<%=btnNewProject.UniqueID %>", "");
                   return false;
          }
          function GetValueFromChildProject(myVal) {

              if (myVal != '') {

                  if (document.getElementById("<%=ddlPolicyType.ClientID%>").value == 1) {
                      //alert();
                      PostbackFunProject(myVal);
                  }
                  else if (document.getElementById("<%=ddlPolicyType.ClientID%>").value == 2) {

                      PostbackFunProject_INSRNC(myVal);
                  }
              }

          }

          function UpdatePanelProjectLoad(strPrjctId) {
              //since both are in update panel



              CheckSubmitZero();

        // document.getElementById("<%=ddlProjects.ClientID%>").value = strPrjctId;
             //re
            //  $au("div#divProjectsDdl input.ui-autocomplete-input").val(strPrjctId);
              //  document.getElementById("<%=ddlProjects.ClientID%>").focus();
              $noCon("div#divProjectsDdl input.ui-autocomplete-input").focus();
              $au('#cphMain_ddlBank').selectToAutocomplete1Letter();
              PostBackProjectDdl();
          }
          function AutocomProjct()
          {
              $au('#cphMain_ddlBank').selectToAutocomplete1Letter();
              if (document.getElementById("<%=cbxPrjct.ClientID%>").checked == true) {
                  $au('#cphMain_ddlProjects').selectToAutocomplete1Letter();
                  $noCon("div#divProjectsDdl input.ui-autocomplete-input").focus();
              }
          }
          //evm-0012 Adding Contracts
          function NewContractLoad() {
            
              if (confirm('Are you sure you want to add new contract?') == true) {            

                  var nWindow = window.open('/GMS/GMS_Master/gen_Contract_Master/gen_Contract_Master.aspx?RFGP=RFG', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                  nWindow.focus();
              }
              AutocomProjct();
              return false;
          }
          function GetValueFromChildContract(myVal) {

              if (myVal != '') {

                  //  alert(myVal);
                  PostbackFunContract(myVal);
                    
              }
          }

          function PostbackFunContract(myValCon) {

              clearhidd();
              clearhidden_INSRNC();

              document.getElementById("<%=hiddenNewContractId.ClientID%>").value = myValCon;

                __doPostBack("<%=btnNewContract.UniqueID %>", "");
                return false;
          }

          </script>

    <style>

        #DivTemplateContainer_INSRNC {
            width: 90%;
            min-height: 200px;
            float: left;
            margin-left: 5%;
            border: 1px solid;
            border-color: #0b9aab;
            background: #fffcf2;
        }
    </style>

    <script>

          //--------------------INSURANCE------------------------

        //evm-0023
          (function ($au1) {
              $au1(function () {
                  $au1('#cphMain_ddlProjects_INSRNC').selectToAutocomplete1Letter();
                  $au1('#cphMain_ddlExistingEmp_INSRNC').selectToAutocomplete1Letter();
                  $au1('#cphMain_ddlInsurncPrvdr').selectToAutocomplete1Letter();
                  $au1('#cphMain_ddlInsurncTyp').selectToAutocomplete1Letter();

                  $au1("div#divddlInsurncPrvdr input.ui-autocomplete-input").focus();
                  $au1("div#divddlInsurncPrvdr input.ui-autocomplete-input").select();
                  $au1("div#divddlInsurancType input.ui-autocomplete-input").focus();
                  $au1("div#divddlInsurancType input.ui-autocomplete-input").select();
              });
          })(jQuery);
        //evm-0023 end


          function CbxChange_INSRNC() {
              IncrmntConfrmCounter_INSRNC();
              if (document.getElementById("<%=cbxExistingEmployee_INSRNC.ClientID%>").checked == false) {
                    document.getElementById("divExistingEmp_INSRNC").style.display = "none";
                    document.getElementById("divNewEmp_INSRNC").style.display = "";
                    document.getElementById("<%=ddlExistingEmp_INSRNC.ClientID%>").value = "--SELECT EMPLOYEE--";
                    document.getElementById("<%=txtCntctMail_INSRNC.ClientID%>").value = "";
                }
                else {
                    document.getElementById("divNewEmp_INSRNC").style.display = "none";
                    document.getElementById("divExistingEmp_INSRNC").style.display = "";
                    document.getElementById("<%=ddlExistingEmp_INSRNC.ClientID%>").value = "--SELECT EMPLOYEE--";
                }
                return false;
            }

            function radioOpen_INSRNCClick() {
                IncrmntConfrmCounter_INSRNC();
                document.getElementById("<%=img1_INSRNC.ClientID%>").disabled = true;
                document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").disabled = true;
                document.getElementById("<%=img1_INSRNC.ClientID%>").style.pointerEvents = "none";
            }

            function radioLimited_INSRNCClick() {
                IncrmntConfrmCounter_INSRNC();
                document.getElementById("<%=img1_INSRNC.ClientID%>").disabled = false;
                document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").disabled = false;
                document.getElementById("<%=img1_INSRNC.ClientID%>").style.pointerEvents = "";
            }

            function NewProjectLoad_INSRNC() {
                if (confirm('Are you sure you want to add new project?') == true) {

                    var PrjctNme = '';

                    var nWindow = window.open('/Master/gen_Projects/gen_Projects.aspx?PRFG=' + PrjctNme + '&RFGP=RFG', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                    nWindow.focus();
                }
                return false;
            }

            //function GetValueFromChildProject(myVal) {
            //    if (myVal != '') {
            //        PostbackFunProject_INSRNC(myVal);
            //    }
            //}

            function PostbackFunProject_INSRNC(myValPrj) {

                clearhidd();
                clearhidd_INSRNC();

                document.getElementById("<%=hiddenNewProjectId_INSRNC.ClientID%>").value = myValPrj;
                __doPostBack("<%=btnNewProject_INSRNC.UniqueID %>", "");
                return false;
            }

        function addCommas_INSRNC() {

            nStr = document.getElementById("<%=txtAmount_INSRNC.ClientID%>").value;
            nStr += '';
            var x = nStr.split('.');
            var x1 = x[0];
            var x2 = x[1];

            if (document.getElementById("<%=hiddenCurrencyModeId_INSRNC.ClientID%>").value == "1") {
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

            if (document.getElementById("<%=hiddenCurrencyModeId_INSRNC.ClientID%>").value == "2") {
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
            if (document.getElementById("<%=hiddenCurrencyModeId_INSRNC.ClientID%>").value == "3") {
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

            if (isNaN(x2))
                document.getElementById("<%=txtAmount_INSRNC.ClientID%>").value = x1;
                //return x1;
            else
                document.getElementById("<%=txtAmount_INSRNC.ClientID%>").value = x1 + "." + x2;
            // return x1 + "." + x2;
            document.getElementById("<%=HiddenFieldAmount_INSRNC.ClientID%>").value = document.getElementById("<%=txtAmount_INSRNC.ClientID%>").value;
        }

    </script>



    <script>
        var confirmbox_INSRNC = 0;

        function IncrmntConfrmCounter_INSRNC() {
            confirmbox_INSRNC++;
        }

        function InsuranceLoadFunction() {

            if (document.getElementById("<%=cbxExistingEmployee_INSRNC.ClientID%>").checked == false) {
                    document.getElementById("divExistingEmp_INSRNC").style.display = "none";
                    document.getElementById("divNewEmp_INSRNC").style.display = "";
                }
                else {
                    document.getElementById("divNewEmp_INSRNC").style.display = "none";
                    document.getElementById("divExistingEmp_INSRNC").style.display = "";
            }

            if (document.getElementById("<%=cbxPrjct_INSRNC.ClientID%>").checked == true) {
                document.getElementById("divSelectProjct_INSRNC").style.display = "";
                document.getElementById("divNewPrjct_INSRNC").style.display = "none";
            }
            else {
                document.getElementById("divNewPrjct_INSRNC").style.display = "";
                document.getElementById("divSelectProjct_INSRNC").style.display = "none";
            }

                if (document.getElementById("<%=radioLimited_INSRNC.ClientID%>").checked == true) {

                  document.getElementById("<%=img1_INSRNC.ClientID%>").disabled = false;
                    document.getElementById("<%=img1_INSRNC.ClientID%>").style.pointerEvents = "";

                    if (document.getElementById("<%=hiddenStatus.ClientID%>").value == "2") {
                        document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").disabled = true;
                        document.getElementById("<%=img1_INSRNC.ClientID%>").disabled = true;
                        document.getElementById("<%=txtAmount_INSRNC.ClientID%>").disabled = true;
                        document.getElementById("<%=img1_INSRNC.ClientID%>").style.pointerEvents = "none";
                    }
                    if (document.getElementById("<%=HiddenRenew_INSRNC.ClientID%>").value == "1") {
                        document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").disabled = false;
                        document.getElementById("<%=img1_INSRNC.ClientID%>").disabled = false;
                        document.getElementById("<%=txtAmount_INSRNC.ClientID%>").disabled = false;
                        document.getElementById("<%=img1_INSRNC.ClientID%>").style.pointerEvents = "";
                    }
                    else {
                        if (document.getElementById("<%=HiddenFieldUpdate_INSRNC.ClientID%>").value == "1") {
                            document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").disabled = false;
                            document.getElementById("<%=img1_INSRNC.ClientID%>").disabled = false;
                            document.getElementById("<%=img1_INSRNC.ClientID%>").style.pointerEvents = "";
                        }
                        else {
                            document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").disabled = true;
                            document.getElementById("<%=img1_INSRNC.ClientID%>").disabled = true;
                            document.getElementById("<%=img1_INSRNC.ClientID%>").style.pointerEvents = "none";
                        }
                    }
                }
                else if (document.getElementById("<%=radioOpen_INSRNC.ClientID%>").checked == true) {

                    document.getElementById("<%=img1_INSRNC.ClientID%>").disabled = true;
                    document.getElementById("<%=img1_INSRNC.ClientID%>").style.pointerEvents = "none";
                    document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").disabled = true;

                    if (document.getElementById("<%=hiddenStatus.ClientID%>").value == "2") {
                        document.getElementById("<%=txtAmount_INSRNC.ClientID%>").disabled = true;
                    }
                    if (document.getElementById("<%=HiddenRenew_INSRNC.ClientID%>").value == "1") {
                        document.getElementById("<%=txtAmount_INSRNC.ClientID%>").disabled = false;
                        document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").disabled = true;
                        document.getElementById("<%=img1_INSRNC.ClientID%>").disabled = true;
                        document.getElementById("<%=img1_INSRNC.ClientID%>").style.pointerEvents = "none";
                    }
                    else {
                        document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").disabled = true;
                        document.getElementById("<%=img1_INSRNC.ClientID%>").disabled = true;
                        document.getElementById("<%=img1_INSRNC.ClientID%>").style.pointerEvents = "none";
                    }
                }

            if (document.getElementById("<%=HiddenDuplictnchk_INSRNC.ClientID%>").value == "1") {
                  document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").disabled = false;
                    document.getElementById("<%=img1_INSRNC.ClientID%>").disabled = false;
                    document.getElementById("<%=img1_INSRNC.ClientID%>").style.pointerEvents = "";
                    TextDateChange_INSRNC();
                }

                AmountChecking_INSRNC('cphMain_txtAmount_INSRNC');

                addCommas_INSRNC();

              //----attachmnt----

                if (document.getElementById("<%=HiddenFieldUpdate_INSRNC.ClientID%>").value == "1" || document.getElementById("<%=HiddenFieldView_INSRNC.ClientID%>").value == "1" || document.getElementById("<%=HiddenRenew_INSRNC.ClientID%>").value == "1") {

                    if (document.getElementById("<%=hiddenEditAttchmnt_INSRNC.ClientID%>").value != "") {

                        var EditAttchmnt = document.getElementById("<%=hiddenEditAttchmnt_INSRNC.ClientID%>").value;

                        var findAtt2 = '\\"\\[';
                        var reAtt2 = new RegExp(findAtt2, 'g');
                        var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                        var findAtt3 = '\\]\\"';
                        var reAtt3 = new RegExp(findAtt3, 'g');
                        var resAtt3 = resAtt2.replace(reAtt3, '\]');
                        var jsonAtt = $noCon.parseJSON(resAtt3);
                        for (var key in jsonAtt) {
                            if (jsonAtt.hasOwnProperty(key)) {
                                if (jsonAtt[key].PictureAttchmntDtlId != "") {

                                    AddAttachment_INSRNC(jsonAtt[key].PictureAttchmntDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);
                                }
                            }
                        }

                        if (document.getElementById("<%=HiddenFieldView_INSRNC.ClientID%>").value != "1") {
                            AddFileUpload_INSRNC();
                        }

                        if (document.getElementById("<%=HiddenRenew_INSRNC.ClientID%>").value == "1") {
                            document.getElementById("divfleupld_INSRNC").style.display = "block";
                            AddFileUpload_INSRNC();
                        }

                    }
                    else {
                        if (document.getElementById("<%=HiddenFieldView_INSRNC.ClientID%>").value == "1") {
                            if (document.getElementById("<%=HiddenRenew_INSRNC.ClientID%>").value != "1") {
                                document.getElementById("divfleupld_INSRNC").style.display = "none";
                            }
                            else {
                                AddFileUpload_INSRNC();
                            }
                        }
                        else {
                            AddFileUpload_INSRNC();
                        }
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenFieldView_INSRNC.ClientID%>").value != "1") {
                        AddFileUpload_INSRNC();
                    }
                    if (document.getElementById("<%=HiddenRenew_INSRNC.ClientID%>").value == "1") {
                        AddFileUpload_INSRNC();
                    }
                }

              //----notification template----



                if (document.getElementById("<%=hiddenTemplateLoadingMode_INSRNC.ClientID%>").value == "FromTemp") {

                  if (document.getElementById("<%=hiddenEachTemplateDetail_INSRNC.ClientID%>").value != 0) {
                        var EditEachTemplate = document.getElementById("<%=hiddenEachTemplateDetail_INSRNC.ClientID%>").value;
                        var findAtt2 = '\\"\\[';
                        var reAtt2 = new RegExp(findAtt2, 'g');
                        var resAtt2 = EditEachTemplate.replace(reAtt2, '\[');

                        var findAtt3 = '\\]\\"';
                        var reAtt3 = new RegExp(findAtt3, 'g');
                        var resAtt3 = resAtt2.replace(reAtt3, '\]');

                        $noCon = jQuery.noConflict();
                        var jsonAtt = $noCon.parseJSON(resAtt3);
                        for (var key in jsonAtt) {
                            if (jsonAtt.hasOwnProperty(key)) {

                                if (jsonAtt[key].TempDetailId != "") {

                                    EditMoreEachTemplate_INSRNC(jsonAtt[key].TempDetailId, jsonAtt[key].NotifyMod, jsonAtt[key].NotifyVia, jsonAtt[key].NotifyDur);

                                }
                            }
                        }
                    }
                    else {
                        addMoreEachTemplate_INSRNC();
                    }
                }
                else if (document.getElementById("<%=hiddenTemplateLoadingMode_INSRNC.ClientID%>").value == "FromBnk") {

                    if (document.getElementById("<%=hiddenEachTemplateDetail_INSRNC.ClientID%>").value != 0) {
                        var EditEachTemplate = document.getElementById("<%=hiddenEachTemplateDetail_INSRNC.ClientID%>").value;

                        var findAtt2 = '\\"\\[';
                        var reAtt2 = new RegExp(findAtt2, 'g');
                        var resAtt2 = EditEachTemplate.replace(reAtt2, '\[');

                        var findAtt3 = '\\]\\"';
                        var reAtt3 = new RegExp(findAtt3, 'g');
                        var resAtt3 = resAtt2.replace(reAtt3, '\]');

                        var jsonAtt = $noCon.parseJSON(resAtt3);
                        for (var key in jsonAtt) {
                            if (jsonAtt.hasOwnProperty(key)) {

                                if (jsonAtt[key].TempDetailId != "") {
                                    EditMoreEachTemplate_INSRNCBnk(jsonAtt[key].TempDetailId, jsonAtt[key].NotifyMod, jsonAtt[key].NotifyVia, jsonAtt[key].NotifyDur);

                                }
                            }
                        }

                    }
                    else {
                        addMoreEachTemplate_INSRNC();
                    }
                }

            if (document.getElementById("<%=hiddenEachTemplateDetail_INSRNC.ClientID%>").value == 0) {
                clearhidd_INSRNC();
            }

          }


        function clearhidd_INSRNC() {
            document.getElementById("<%=hiddenDivisionddlData_INSRNC.ClientID%>").value = 0;
            document.getElementById("<%=hiddenDesignationddlData_INSRNC.ClientID%>").value = 0;
            document.getElementById("<%=hiddenEmployeeDdlData_INSRNC.ClientID%>").value = 0;
        }


        function TextDateChange_INSRNC() {

            var chk = document.getElementById("<%=txtOpngDate_INSRNC.ClientID%>").value;

            if (document.getElementById("<%=txtOpngDate_INSRNC.ClientID%>").value != "" && document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").value != "") {

                var OPeningDate = document.getElementById("<%=txtOpngDate_INSRNC.ClientID%>").value;
                var arrOPeningDate = OPeningDate.split("-");
                var dateOPeningDate = new Date(arrOPeningDate[2], arrOPeningDate[1] - 1, arrOPeningDate[0]);

                var ExpireDate = document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").value.trim();
                var arrDateExpireDate = ExpireDate.split("-");
                var datearrDateExpireDate = new Date(arrDateExpireDate[2], arrDateExpireDate[1] - 1, arrDateExpireDate[0]);

                var timeDiff = Math.abs(datearrDateExpireDate.getTime() - dateOPeningDate.getTime());
                var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
                diffDays = diffDays + 1;
                document.getElementById("<%=txtValidity_INSRNC.ClientID%>").value = diffDays;
                document.getElementById("<%=HiddenTextValidty_INSRNC.ClientID%>").value = diffDays;
                document.getElementById("<%=HiddenValidatedays_INSRNC.ClientID%>").value = diffDays;
            }
        }


    </script>


    <script>

        //----------------for file upload----------------

        var Filecounter_INSRNC = 0;

        function AddFileUpload_INSRNC() {



            var FrecRow = '<tr id="FilerowId_INSRNC_' + Filecounter_INSRNC + '" >';

            var labelForStyle = '<label  for="file_INSRNC_' + Filecounter_INSRNC + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
            var tdInner = labelForStyle + '<input   id="file_INSRNC_' + Filecounter_INSRNC + '" name = "file_INSRNC_' + Filecounter_INSRNC + '" type="file" onchange="ChangeFile_INSRNC(\'' + Filecounter_INSRNC + '\')" accept="image/*,.pdf,.jpeg,.jpg,.png"/>';

            FrecRow += '<td style="width:22%;border:none;padding-left: 3%;" >' + tdInner + '</td>';

            FrecRow += '<td style="font-family: Calibri;border-right:none;width: 37%;word-break: break-all;" id="filePath_INSRNC' + Filecounter_INSRNC + '"  ></td  >';

            FrecRow += '<td style="width: 23%;border:none;" > <input   id="textbx_INSRNC' + Filecounter_INSRNC + '" name = "textbx_INSRNC' + Filecounter_INSRNC + '" type="text" class="form1" placeholder="Caption"  MaxLength="100" onkeypress="return isTag(event);" onkeydown="return DisableEnter(event);" onfocus="prevValueChk_INSRNC(\'' + Filecounter_INSRNC + '\');"  onblur="LinkChangeFile_INSRNC(\'' + Filecounter_INSRNC + '\',event);"  style="text-transform:uppercase;" /> </td>';

            FrecRow += '<td id="FileIndvlAddMoreRow_INSRNC' + Filecounter_INSRNC + '"  style="width: 1.5%;border:none; padding-left: 4px;"> <input type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFiles_INSRNC(\'' + Filecounter_INSRNC + '\');" style="  cursor: pointer;"></td>';
            FrecRow += '<td style="width: 1.5%;border:none; padding-left: 1px;"><input type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUpload_INSRNC(\'' + Filecounter_INSRNC + '\');"    style=" cursor: pointer;" ></td><br/>';


            FrecRow += ' <td id="FileInx_INSRNC' + Filecounter_INSRNC + '" style="display: none;" ></td>';
            FrecRow += '<td id="FileSave_INSRNC' + Filecounter_INSRNC + '" style="display: none;"></td>';
            FrecRow += '<td id="FileEvt_INSRNC' + Filecounter_INSRNC + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId_INSRNC' + Filecounter_INSRNC + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName_INSRNC' + Filecounter_INSRNC + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadContainer_INSRNC').append(FrecRow);

            document.getElementById('filePath_INSRNC' + Filecounter_INSRNC).innerHTML = 'No File Selected';

            $('#divfileupl_INSRNC').scrollTop($('#divfileupl_INSRNC')[0].scrollHeight);
            Filecounter_INSRNC++;

        }


        function AddAttachment_INSRNC(editTransDtlId, EditFileName, EditActualFileName, EditDescrptn) {

            var FrecRow = '<tr id="FilerowId_INSRNC_' + Filecounter_INSRNC + '" >';

            var labelForStyle = '<label  for="file_INSRNC_' + Filecounter_INSRNC + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
            var tdInner = labelForStyle + '<input   id="file_INSRNC_' + Filecounter_INSRNC + '" name = "file_INSRNC_' + Filecounter_INSRNC + '" type="file" onchange="ChangeFile_INSRNC(\'' + Filecounter_INSRNC + '\')" />';

            FrecRow += '<td style="width:22%;border:none;padding-left: 3%;display:none;" >' + tdInner + '</td>';


            var tdFileNameEdit = '<a class="AnchorAttachmntEdit" style="word-wrap: break-word;" target="_blank" href=' + document.getElementById("<%=hiddenFilePath_INSRNC.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

            FrecRow += '<td colspan="2" id="filePath_INSRNC' + Filecounter_INSRNC + '" style="font-family: Calibri;;border-right:none;border-bottom: 1px dotted rgb(205, 237, 196);word-break: break-all;"' + '  ><div style="width: 93%;float: right;">' + tdFileNameEdit + '</div></td >';

            FrecRow += '<td style="width: 23%;border:none;" > <input disabled="true"  id="textbx_INSRNC' + Filecounter_INSRNC + '" name = "textbx_INSRNC' + Filecounter_INSRNC + '" value="' + EditDescrptn + '" type="text" class="form1" placeholder="Caption"  MaxLength="100" onkeypress="return isTag(event);" onkeydown="return DisableEnter(event);" onfocus="prevValueChk_INSRNC(\'' + Filecounter_INSRNC + '\');"  onblur="LinkChangeFile_INSRNC(\'' + Filecounter_INSRNC + '\',event);"  style="text-transform:uppercase;" /> </td>';

            FrecRow += '<td id="FileIndvlAddMoreRow_INSRNC' + Filecounter_INSRNC + '"  style="width: 1.5%; padding-left: 4px;border:none;"> <input type="image"  class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFiles_INSRNC(\'' + Filecounter_INSRNC + '\');" style="  cursor: pointer;"></td>';
            FrecRow += '<td style="width: 1.5%; padding-left: 1px;border:none;"><input type="image" AutoPostBack="true" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete" onclick = "return RemoveFileUpload_INSRNC(\'' + Filecounter_INSRNC + '\');" style=" cursor: pointer;" ></td>';

            FrecRow += '<td id="FileInx_INSRNC' + Filecounter_INSRNC + '" style="display: none;" ></td>';
            FrecRow += '<td id="FileSave_INSRNC' + Filecounter_INSRNC + '" style="display: none;"></td>';
            FrecRow += '<td id="FileEvt_INSRNC' + Filecounter_INSRNC + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId_INSRNC' + Filecounter_INSRNC + '" style="display: none;">' + editTransDtlId + '</td>';
            FrecRow += '<td id="DbFileName_INSRNC' + Filecounter_INSRNC + '" style="display: none;">' + EditFileName + '</td>';

            FrecRow += '</tr>';


            jQuery('#TableFileUploadContainer_INSRNC').append(FrecRow);


            document.getElementById("FileInx_INSRNC" + Filecounter_INSRNC).innerHTML = Filecounter_INSRNC;
            document.getElementById("FileIndvlAddMoreRow_INSRNC" + Filecounter_INSRNC).style.opacity = "0.3";

            FileLocalStorageAdd_INSRNC(Filecounter_INSRNC);
            Filecounter_INSRNC++;

        }

        function ChangeFile_INSRNC(x) {
            if (ClearDivDisplayImage_INSRNC(x)) {

                IncrmntConfrmCounter_INSRNC();
                if (document.getElementById('file_INSRNC_' + x).value != "") {
                    document.getElementById('filePath_INSRNC' + x).innerHTML = document.getElementById('file_INSRNC_' + x).value;

                    var tbClientImageValidation = localStorage.getItem("tbClientImageValidation_INSRNC");//Retrieve the stored data

                    tbClientImageValidation = JSON.parse(tbClientImageValidation);
                    if (tbClientImageValidation == null) //If there is no data, initialize an empty array
                        tbClientImageValidation = [];
                    var $addFile = jQuery.noConflict();
                    var client = JSON.stringify({
                        ROWID: "" + x + "",

                    });


                    if (client != "") {

                        tbClientImageValidation.push(client);
                        localStorage.setItem("tbClientImageValidation_INSRNC", JSON.stringify(tbClientImageValidation));

                        $addFile("#cphMain_HiddenFieldValidation_INSRNC").val(JSON.stringify(tbClientImageValidation));

                    }
                    else {
                        document.getElementById('filePath_INSRNC' + x).innerHTML = 'No File Uploaded';


                    }
                    var SavedorNot = document.getElementById("FileSave_INSRNC" + x).innerHTML;

                    if (SavedorNot == "saved") {
                        var row_index = jQuery('#FilerowId_INSRNC_' + x).index();
                    }
                    else {
                    }
                }


            }
        }
        function prevValueChk_INSRNC(x) {

            document.getElementById("<%=hiddenFieldPrevValueChk_INSRNC.ClientID%>").value = document.getElementById('textbx_INSRNC' + x).value;
        }

        function LinkChangeFile_INSRNC(x, y) {

            if (isTag(y)) {


                document.getElementById("file" + x).style.borderColor = "";

                if (document.getElementById('textbx_INSRNC' + x).value != "") {

                    var prevtxtValue = document.getElementById("<%=hiddenFieldPrevValueChk_INSRNC.ClientID%>").value;
                    var vartxtbox = document.getElementById('textbx_INSRNC' + x).value;

                    IncrmntConfrmCounter_INSRNC();

                    if (prevtxtValue != vartxtbox) {

                        var SavedorNot = document.getElementById("FileSave_INSRNC" + x).innerHTML;

                        if (SavedorNot == "saved") {
                            var row_index = jQuery('#FilerowId_INSRNC_' + x).index();


                            FileLocalStorageEdit_INSRNC(x, row_index);
                        }
                        else {


                            FileLocalStorageAdd_INSRNC(x);
                        }
                    }

                }
            }
            else {


            }

        }

        function FileLocalStorageAdd_INSRNC(x) {

            var tbClientPicLinkUpload = localStorage.getItem("tbClientPicLinkUpload_INSRNC");//Retrieve the stored data
            var tbClientPictureUpload = localStorage.getItem("tbClientPictureUpload_INSRNC");//Retrieve the stored data

            tbClientPictureUpload = JSON.parse(tbClientPictureUpload); //Converts string to object
            tbClientPicLinkUpload = JSON.parse(tbClientPicLinkUpload); //Converts string to object

            if (tbClientPictureUpload == null) //If there is no data, initialize an empty array
                tbClientPictureUpload = [];

            if (tbClientPicLinkUpload == null) //If there is no data, initialize an empty array
                tbClientPicLinkUpload = [];

            // var Linktxt = document.getElementById("textbx_INSRNC" + x).innerHTML;


            var filePath_INSRNC = document.getElementById("filePath_INSRNC" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId_INSRNC" + x).innerHTML;
            var Fevt = document.getElementById("FileEvt_INSRNC" + x).innerHTML;

            if (Fevt == 'INS') {

                var $addFile = jQuery.noConflict();

                var client = JSON.stringify({

                    ROWID: "" + x + "",
                    //   filePath_INSRNC: "" + filePath_INSRNC + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"

                });

                var clientLink = JSON.stringify({
                    ROWID: "" + x + "",
                    // filePath_INSRNC: "" + filePath_INSRNC + "",
                    EVTACTION: "" + Fevt + "",
                    // LNKTXT: "" + Linktxt + "",

                    DTLID: "0"
                });

            }
            else if (Fevt == 'UPD') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    //   filePath_INSRNC: "" + filePath_INSRNC + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });

                var clientLink = JSON.stringify({
                    ROWID: "" + x + "",
                    // filePath_INSRNC: "" + filePath_INSRNC + "",
                    EVTACTION: "" + Fevt + "",
                    //LNKTXT: "" + Linktxt + "",

                    DTLID: "" + FdetailId + ""

                });
            }


            tbClientPictureUpload.push(client);
            localStorage.setItem("tbClientPictureUpload_INSRNC", JSON.stringify(tbClientPictureUpload));

            $addFile("#cphMain_HiddenField2_FileUpload_INSRNC").val(JSON.stringify(tbClientPictureUpload));
            if (clientLink != "" && clientLink != null) {
                tbClientPicLinkUpload.push(clientLink);
                localStorage.setItem("tbClientPicLinkUpload_INSRNC", JSON.stringify(tbClientPicLinkUpload));
                $addFile("#cphMain_HiddenField2_FileUploadLnk_INSRNC").val(JSON.stringify(tbClientPicLinkUpload));

            }

            document.getElementById("FileSave_INSRNC" + x).innerHTML = "saved";


            return true;

        }

        function FileLocalStorageEdit_INSRNC(x, row_index) {
            var tbClientPicLinkUpload = localStorage.getItem("tbClientPicLinkUpload_INSRNC");
            var tbClientPictureUpload = localStorage.getItem("tbClientPictureUpload_INSRNC");//Retrieve the stored data

            tbClientPictureUpload = JSON.parse(tbClientPictureUpload); //Converts string to object
            tbClientPicLinkUpload = JSON.parse(tbClientPicLinkUpload);

            if (tbClientPictureUpload == null) //If there is no data, initialize an empty array
                tbClientPictureUpload = [];

            if (tbClientPicLinkUpload == null) //If there is no data, initialize an empty array
                tbClientPicLinkUpload = [];

            var filePath_INSRNC = document.getElementById("filePath_INSRNC" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId_INSRNC" + x).innerHTML;

            var Fevt = document.getElementById("FileEvt_INSRNC" + x).innerHTML;

            if (Fevt == 'INS') {

                var $FileE = jQuery.noConflict();
                tbClientPictureUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    //     filePath_INSRNC: "" + filePath_INSRNC + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"
                });//Alter the selected item on the table
                tbClientPicLinkUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    // filePath_INSRNC: "" + filePath_INSRNC + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"

                });

            }
            else {

                var $FileE = jQuery.noConflict();
                tbClientPictureUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    //   filePath_INSRNC: "" + filePath_INSRNC + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });//Alter the selected item on the table

                tbClientPicLinkUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    // filePath_INSRNC: "" + filePath_INSRNC + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });



            }



            localStorage.setItem("tbClientPictureUpload_INSRNC", JSON.stringify(tbClientPictureUpload));
            $FileE("#cphMain_HiddenField2_FileUpload_INSRNC").val(JSON.stringify(tbClientPictureUpload));
            localStorage.setItem("tbClientPicLinkUpload_INSRNC", JSON.stringify(tbClientPicLinkUpload));
            $addFile("#cphMain_HiddenField2_FileUploadLnk_INSRNC").val(JSON.stringify(tbClientPicLinkUpload));



            return true;
        }



        function CheckaddMoreRowsIndividualFiles_INSRNC(x) {

            var check = document.getElementById("FileInx_INSRNC" + x).innerHTML;
            if (check == "") {

                var Fevt = document.getElementById("FileEvt_INSRNC" + x).innerHTML;

                if (Fevt != 'UPD') {

                    if (CheckFileUploaded_INSRNC(x) == true) {

                        document.getElementById("FileInx_INSRNC" + x).innerHTML = x;
                        document.getElementById("FileIndvlAddMoreRow_INSRNC" + x).style.opacity = "0.3";

                        if (document.getElementById("<%=HiddenFieldView_INSRNC.ClientID%>").value != "1") {
                            AddFileUpload_INSRNC();
                        }
                        else if (document.getElementById("<%=HiddenRenew_INSRNC.ClientID%>").value == "1") {
                            AddFileUpload_INSRNC();
                        }


                        return false;
                    }
                }
                else {

                    document.getElementById("FileInx_INSRNC" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRow_INSRNC" + x).style.opacity = "0.3";
                    if (document.getElementById("<%=HiddenFieldView_INSRNC.ClientID%>").value != "1") {
                        AddFileUpload_INSRNC();
                    }
                    else if (document.getElementById("<%=HiddenRenew_INSRNC.ClientID%>").value == "1") {
                        AddFileUpload_INSRNC();
                    }
                    return false;
                }
            }
            return false;

        }

        function CheckFileUploaded_INSRNC(x) {

            if (document.getElementById('file_INSRNC_' + x).value != "") {

                return true;
            }
            else {

                return false;
            }

            return false;
        }

        function RemoveFileUpload_INSRNC(removeNum) {


            var ret = true;
            if (document.getElementById("<%=HiddenFieldView_INSRNC.ClientID%>").value != "1" || document.getElementById("<%=HiddenRenew_INSRNC.ClientID%>").value == "1") {
                if (confirm("Are you sure you want to delete selected row?")) {

                    var Filerow_index = jQuery('#FilerowId_INSRNC_' + removeNum).index();

                    FileLocalStorageDelete_INSRNC(Filerow_index, removeNum);
                    jQuery('#FilerowId_INSRNC_' + removeNum).remove();



                    var TableFileRowCount = document.getElementById("TableFileUploadContainer_INSRNC").rows.length;


                    if (TableFileRowCount != 0) {
                        var idlast = $('#TableFileUploadContainer_INSRNC tr:last').attr('id');
                        //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                        //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                        if (idlast != "") {
                            var res = idlast.split("_");

                            document.getElementById("FileInx_INSRNC" + res[1]).innerHTML = "";
                            document.getElementById("FileIndvlAddMoreRow_INSRNC" + res[1]).style.opacity = "1";

                            ret = true;
                        }

                    }
                    else {

                        AddFileUpload_INSRNC();

                        ret = true;

                    }

                }
                else {

                    ret = false;
                }
            }

            else {
                ret = false;
            }

            return ret;

        }

        function FileLocalStorageDelete_INSRNC(row_index, x) {

            var $DelFile = jQuery.noConflict();
            var tbClientPictureUpload = localStorage.getItem("tbClientPictureUpload_INSRNC");//Retrieve the stored data
            var tbClientPicLinkUpload = localStorage.getItem("tbClientPicLinkUpload_INSRNC");

            tbClientPictureUpload = JSON.parse(tbClientPictureUpload); //Converts string to object
            tbClientPicLinkUpload = JSON.parse(tbClientPicLinkUpload);
            if (tbClientPictureUpload == null) //If there is no data, initialize an empty array
                tbClientPictureUpload = [];

            if (tbClientPicLinkUpload == null) //If there is no data, initialize an empty array
                tbClientPicLinkUpload = [];

            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            for (var i = 0; i < tbClientPictureUpload.length; i++) {

                var rowid = tbClientPictureUpload[i];
                rowid = rowid.split(",");
                rowid = rowid[0];
                rowid = rowid.split(":");
                rowid = rowid[1];
                rowid = rowid.replace(/"/g, "");


                if (rowid == x) {

                    tbClientPictureUpload.splice(i, 1);

                    break;
                }

            }

            // tbClientPictureUpload.splice(row_index, 1);
            localStorage.setItem("tbClientPictureUpload_INSRNC", JSON.stringify(tbClientPictureUpload));
            $DelFile("#cphMain_HiddenField2_FileUpload_INSRNC").val(JSON.stringify(tbClientPictureUpload));
            var hidd = document.getElementById("<%=HiddenField2_FileUploadLnk_INSRNC.ClientID%>").value;


            for (var i = 0; i < tbClientPicLinkUpload.length; i++) {
                var rowid = tbClientPicLinkUpload[i];
                rowid = rowid.split(",");
                rowid = rowid[0];
                rowid = rowid.split(":");
                rowid = rowid[1];
                rowid = rowid.replace(/"/g, "");


                if (rowid == x) {

                    tbClientPicLinkUpload.splice(i, 1);

                    break;
                }
            }

            // tbClientPicLinkUpload.splice(row_index, 1);
            localStorage.setItem("tbClientPicLinkUpload_INSRNC", JSON.stringify(tbClientPicLinkUpload));
            $DelFile("#cphMain_HiddenField2_FileUploadLnk_INSRNC").val(JSON.stringify(tbClientPicLinkUpload));
            var hiddn = document.getElementById("<%=HiddenField2_FileUploadLnk_INSRNC.ClientID%>").value;

            var Fevt = document.getElementById("FileEvt_INSRNC" + x).innerHTML;

            if (Fevt == 'UPD') {
                var FdetailId = document.getElementById("FileDtlId_INSRNC" + x).innerHTML;

                if (FdetailId != '') {

                    DeleteFileLSTORAGEAddFile_INSRNC(x);
                }

            }

        }

        function DeleteFileLSTORAGEAddFile_INSRNC(x) {


            var tbClientPictureFileCancel = localStorage.getItem("tbClientPictureFileCancel_INSRNC");//Retrieve the stored data

            tbClientPictureFileCancel = JSON.parse(tbClientPictureFileCancel); //Converts string to object

            if (tbClientPictureFileCancel == null) //If there is no data, initialize an empty array
                tbClientPictureFileCancel = [];


            var FileName = document.getElementById("DbFileName_INSRNC" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId_INSRNC" + x).innerHTML;



            var $addFile = jQuery.noConflict();
            var client = JSON.stringify({
                ROWID: "" + x + "",
                FILENAME: "" + FileName + "",
                // EVTACTION: "" + Fevt + "",
                DTLID: "" + FdetailId + ""
            });



            if (client != "") {

                tbClientPictureFileCancel.push(client);
                localStorage.setItem("tbClientPictureFileCancel_INSRNC", JSON.stringify(tbClientPictureFileCancel));

                $addFile("#cphMain_hiddenFileCanclDtlId_INSRNC").val(JSON.stringify(tbClientPictureFileCancel));

                ret = true;
            }

            return ret;

        }



        function CheckValidation_INSRNC(x) {

            if (document.getElementById('file_INSRNC_' + x) != undefined) {


                if (document.getElementById('file_INSRNC_' + x).value != "" && document.getElementById('textbx_INSRNC' + x).value != "") {

                    return true;
                }
                else {
                    if (document.getElementById('file_INSRNC_' + x).value != "") {
                        if (document.getElementById('textbx_INSRNC' + x).value == "") {
                            document.getElementById('textbx_INSRNC' + x).style.borderColor = "RED";
                            document.getElementById('textbx_INSRNC' + x).focus();
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        }
                    }


                    return false;
                }
            }

            return true;
        }

        function ClearDivDisplayImage_INSRNC(x) {

            var fuData = document.getElementById('file_INSRNC_' + x);
            var FileUploadPath = fuData.value;
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

            if (Extension == "png" || Extension == "pdf" || Extension == "jpeg" || Extension == "jpg") {


                return true;

            }
            else {
                document.getElementById('file_INSRNC_' + x).value = "";
                document.getElementById('filePath_INSRNC' + x).innerHTML = 'No File Selected';
                alert("The specified file could not be uploaded. Image type not supported. Allowed types are png, jpeg, gif");
                return false;
            }
        }

    </script>


    <script>

        //----------------for notification template-----------------

        var EachTemp_INSRNC = 0;

        function InitialTempValues_INSRNC() {

            EachTemp_INSRNC = 0;
            InitialiseCount_INSRNC();
        }

        function EditMoreEachTemplate_INSRNC(TempDetailId, NotifyMod, NotifyVia, NotifyDur) {//default

            EachTemp_INSRNC++;

            var recRow = '<tr id="TemplateRowId_INSRNC_' + EachTemp_INSRNC + ' >';

            recRow = '<div id=\"divEachTemplate_INSRNC_' + EachTemp_INSRNC + '\" style=\"float:left;margin-top:1%;padding:10px; width:80%;min-height: 170px;margin-left: 10%;border: 1px dotted;border-color: green;\">';
            recRow += '<div id=\" divTempLeftPart_INSRNC_' + EachTemp_INSRNC + '\" class=\"eachform\" style=\"float:left;width: 25%;height: 169px;border-right: 1px dotted;border-color: green;\">';
            recRow += '<h2 style=\"margin-left: 33%;font-size: 20px;color: #006475;\">Period *</h2>';


            recRow += '<div style=\"width:70%;margin-top: 19%;margin-left: 14%;background-color: wheat;color: #076309;border: 1px solid;\" >';

            recRow += '<input id=\"radioDays_INSRNC_' + EachTemp_INSRNC + '\" type=\"radio\" checked="true" onclick=\"UpdateNotifyMOde_INSRNC(' + EachTemp_INSRNC + ');\" name=\"radType_INSRNC' + EachTemp_INSRNC + '\" onkeypress="return DisableEnter(event)" />';

            recRow += '<label style=\"font-family:Calibri\" for=\"radioDays_INSRNC_' + EachTemp_INSRNC + '\">Days</label>';


            recRow += '<input id=\"radioHours_INSRNC_' + EachTemp_INSRNC + '\" type=\"radio\" onclick=\"UpdateNotifyMOde_INSRNC(' + EachTemp_INSRNC + ');\" name=\"radType_INSRNC' + EachTemp_INSRNC + '\" style=\"margin-left: 26px;\" onkeypress="return DisableEnter(event)"/>';
            recRow += '<label style=\"font-family:Calibri\" for=\"radioHours_INSRNC_' + EachTemp_INSRNC + '\">Hours</label>';

            recRow += '</div>';
            recRow += '<div style=\"width: 97%;margin-top: 6%;\">';

            recRow += ' <input type=\"text\" id=\"txtDuration_INSRNC_' + EachTemp_INSRNC + '\" class=\"form1\" onblur=\"UpdateNotifyDuration_INSRNC(' + EachTemp_INSRNC + ');\" onkeydown=\"return isNumber_INSRNC(event);\"  MaxLength=\"4\" Style=\"width: 30%; text-transform: uppercase; margin-right: 31.7%; height: 30px\" onkeypress="return DisableEnter(event)" />';

            recRow += ' <input type=\"button\" id=\"btnDurClear_INSRNC_' + EachTemp_INSRNC + '\" onclick=\"return ClearDur_INSRNC(' + EachTemp_INSRNC + ');\" class=\"ClearDur\" value=\"Clear\" style=\"margin-top: 13%;margin-left: 29%;\" />';
            recRow += ' </div></div>';


            recRow += '<div id="divTempRightPart_INSRNC_' + EachTemp_INSRNC + '" style="float:right;width: 74%;">';
            recRow += '<h2 style="margin-left: 42%;font-size: 20px;color: #006475;">Intimation *</h2>';

            recRow += '<div id=\"divTempRightContainer_INSRNC_' + EachTemp_INSRNC + '\" style=\"height: 135px;overflow: auto;width: 100%;\">';
            recRow += '<table id=\"TableEachTempSliceContainer_INSRNC_' + EachTemp_INSRNC + '\" style=\"width: 100%;\">';
            recRow += '</table>';

            recRow += ' </div>';
            recRow += '<div id=\"divBtmPortion_INSRNC_' + EachTemp_INSRNC + '\">';
            recRow += '<h2 style=\"float:left; margin-left: 1%;font-size: 16px;color: #000;padding-top: 3px;margin-top: 0px;\">Notification*</h2>';
            recRow += '<input type=\"checkbox\" id=\"cbxDashboard_INSRNC_' + EachTemp_INSRNC + '\" onchange=\"UpdateNotifyVia_INSRNC(' + EachTemp_INSRNC + ',\'cbxDashboard_INSRNC_\');\" style=\"float: left;margin-left: 2%\;" Checked=\"true\" class=\"form2\ " onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">DashBoard</h3>';
            recRow += '<input type=\"checkbox\" id="cbxEmail_INSRNC_' + EachTemp_INSRNC + '" onchange=\"UpdateNotifyVia_INSRNC(' + EachTemp_INSRNC + ',\'cbxEmail_INSRNC_\');\" style="float: left;margin-left: 3%;" Checked="true" class="form2" onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">Email</h3>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '<div style=\"float:right;\"><input id="AddEachTempButton_INSRNC_' + EachTemp_INSRNC + '" type=\"image\" src=\"/Images/Icons/black add.png\" onclick="return EachTemplateAddition_INSRNC();" alt=\"Add\" style=\"cursor: pointer;\" /></div>';
            recRow += '<div id="TemplateId_INSRNC_' + EachTemp_INSRNC + '" style="display: none;"></div>';
            recRow += '<div id="TemplateEvent_INSRNC_' + EachTemp_INSRNC + '" style="display: none;">INS</div>';

            jQuery('#TableTemplateContainer_INSRNC').append(recRow);
            document.getElementById("<%=hiddenTemplateCount_INSRNC.ClientID%>").value = EachTemp_INSRNC;

            document.getElementById("txtDuration_INSRNC_" + EachTemp_INSRNC).value = NotifyDur;
            document.getElementById("cbxDashboard_INSRNC_" + EachTemp_INSRNC).checked = false;
            document.getElementById("cbxEmail_INSRNC_" + EachTemp_INSRNC).checked = false;
            if (NotifyMod == 1) {
                document.getElementById("radioHours_INSRNC_" + EachTemp_INSRNC).checked = true;
            }
            else if (NotifyMod == 2) {
                document.getElementById("radioDays_INSRNC_" + EachTemp_INSRNC).checked = true;
            }
            if (NotifyVia != "") {
                if (NotifyVia.indexOf("D") >= 0) {
                    document.getElementById("cbxDashboard_INSRNC_" + EachTemp_INSRNC).checked = true;
                }

                if (NotifyVia.indexOf("E") >= 0) {
                    document.getElementById("cbxEmail_INSRNC_" + EachTemp_INSRNC).checked = true;
                }
            }


            AddDefaultTemplateValues_INSRNC(EachTemp_INSRNC);


            //FOR FILLING EACH SLICE DATA
            var EditEachSliceFullData = document.getElementById("<%=hiddenTemplateAlertData_INSRNC.ClientID%>").value;
            var EditEachTempliceData = EditEachSliceFullData.split("!");

            var findAtt2 = '\\"\\[';
            var reAtt2 = new RegExp(findAtt2, 'g');
            var resAtt2 = EditEachTempliceData[EachTemp_INSRNC].replace(reAtt2, '\[');

            var findAtt3 = '\\]\\"';
            var reAtt3 = new RegExp(findAtt3, 'g');
            var resAtt3 = resAtt2.replace(reAtt3, '\]');

            $noCon = jQuery.noConflict();
            var jsonAtt = $noCon.parseJSON(resAtt3);
            for (var key in jsonAtt) {
                if (jsonAtt.hasOwnProperty(key)) {
                    if (jsonAtt[key].TempAlertId != "") {


                        EditEachTempSlice_INSRNC(EachTemp_INSRNC, jsonAtt[key].TempAlertId, jsonAtt[key].AlertOpt, jsonAtt[key].AlertNtfyId);


                    }
                }
            }

            if (document.getElementById("<%=hiddenEditMode_INSRNC.ClientID%>").value == "View") {
                document.getElementById("cbxDashboard_INSRNC_" + EachTemp_INSRNC).disabled = true;
                document.getElementById("cbxEmail_INSRNC_" + EachTemp_INSRNC).disabled = true;
                document.getElementById("radioDays_INSRNC_" + EachTemp_INSRNC).disabled = true;
                document.getElementById("radioHours_INSRNC_" + EachTemp_INSRNC).disabled = true;
                document.getElementById("txtDuration_INSRNC_" + EachTemp_INSRNC).disabled = true;
                document.getElementById("AddEachTempButton_INSRNC_" + EachTemp_INSRNC).disabled = true;
            }


            return false;
        }

        function EditMoreEachTemplate_INSRNCBnk(TempDetailId, NotifyMod, NotifyVia, NotifyDur) {//edit


            EachTemp_INSRNC++;

            var recRow = '<tr id="TemplateRowId_INSRNC_' + EachTemp_INSRNC + ' >';

            recRow = '<div id=\"divEachTemplate_INSRNC_' + EachTemp_INSRNC + '\" style=\"float:left;margin-top:1%;padding:10px; width:80%;min-height: 170px;margin-left: 10%;border: 1px dotted;border-color: green;\">';
            recRow += '<div id=\" divTempLeftPart_INSRNC_' + EachTemp_INSRNC + '\" class=\"eachform\" style=\"float:left;width: 25%;height: 169px;border-right: 1px dotted;border-color: green;\">';
            recRow += '<h2 style=\"margin-left: 33%;font-size: 20px;color: #006475;\">Period *</h2>';


            recRow += '<div style=\"width:70%;margin-top: 19%;margin-left: 14%;background-color: wheat;color: #076309;border: 1px solid;\" >';

            recRow += '<input id=\"radioDays_INSRNC_' + EachTemp_INSRNC + '\" type=\"radio\" checked="true" onclick=\"UpdateNotifyMOde_INSRNC(' + EachTemp_INSRNC + ');\" name=\"radType_INSRNC' + EachTemp_INSRNC + '\" onkeypress="return DisableEnter(event)" />';

            recRow += '<label style=\"font-family:Calibri\" for=\"radioDays_INSRNC_' + EachTemp_INSRNC + '\">Days</label>';


            recRow += '<input id=\"radioHours_INSRNC_' + EachTemp_INSRNC + '\" type=\"radio\" onclick=\"UpdateNotifyMOde_INSRNC(' + EachTemp_INSRNC + ');\" name=\"radType_INSRNC' + EachTemp_INSRNC + '\" style=\"margin-left: 26px;\" onkeypress="return DisableEnter(event)"/>';
            recRow += '<label style=\"font-family:Calibri\" for=\"radioHours_INSRNC_' + EachTemp_INSRNC + '\">Hours</label>';

            recRow += '</div>';
            recRow += '<div style=\"width: 97%;margin-top: 6%;\">';

            recRow += ' <input type=\"text\" id=\"txtDuration_INSRNC_' + EachTemp_INSRNC + '\" class=\"form1\" onblur=\"UpdateNotifyDuration_INSRNC(' + EachTemp_INSRNC + ');\" onkeydown=\"return isNumber_INSRNC(event);\"  MaxLength=\"4\" Style=\"width: 30%; text-transform: uppercase; margin-right: 31.7%; height: 30px\" onkeypress="return DisableEnter(event)" />';

            recRow += ' <input type=\"button\" id=\"btnDurClear_INSRNC_' + EachTemp_INSRNC + '\" onclick=\"return ClearDur_INSRNC(' + EachTemp_INSRNC + ');\" class=\"ClearDur\" value=\"Clear\" style=\"margin-top: 13%;margin-left: 29%;\" />';
            recRow += ' </div></div>';


            recRow += '<div id="divTempRightPart_INSRNC_' + EachTemp_INSRNC + '" style="float:right;width: 74%;">';
            recRow += '<h2 style="margin-left: 42%;font-size: 20px;color: #006475;">Intimation *</h2>';

            recRow += '<div id=\"divTempRightContainer_INSRNC_' + EachTemp_INSRNC + '\" style=\"height: 135px;overflow: auto;width: 100%;\">';
            recRow += '<table id=\"TableEachTempSliceContainer_INSRNC_' + EachTemp_INSRNC + '\" style=\"width: 100%;\">';
            recRow += '</table>';

            recRow += ' </div>';
            recRow += '<div id=\"divBtmPortion_INSRNC_' + EachTemp_INSRNC + '\">';
            recRow += '<h2 style=\"float:left; margin-left: 1%;font-size: 16px;color: #000;padding-top: 3px;margin-top: 0px;\">Notification*</h2>';
            recRow += '<input type=\"checkbox\" id=\"cbxDashboard_INSRNC_' + EachTemp_INSRNC + '\" onchange=\"UpdateNotifyVia_INSRNC(' + EachTemp_INSRNC + ',\'cbxDashboard_INSRNC_\');\" style=\"float: left;margin-left: 2%\;" Checked=\"true\" class=\"form2\ " onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">DashBoard</h3>';
            recRow += '<input type=\"checkbox\" id="cbxEmail_INSRNC_' + EachTemp_INSRNC + '" onchange=\"UpdateNotifyVia_INSRNC(' + EachTemp_INSRNC + ',\'cbxEmail_INSRNC_\');\" style="float: left;margin-left: 3%;" Checked="true" class="form2" onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">Email</h3>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '<div style=\"float:right;\"><input id="AddEachTempButton_INSRNC_' + EachTemp_INSRNC + '" type=\"image\" src=\"/Images/Icons/black add.png\" onclick="return EachTemplateAddition_INSRNC();" alt=\"Add\" style=\"cursor: pointer;\" /></div>';
            recRow += '<div id="TemplateId_INSRNC_' + EachTemp_INSRNC + '" style="display: none;">' + TempDetailId + '</div>';
            recRow += '<div id="TemplateEvent_INSRNC_' + EachTemp_INSRNC + '" style="display: none;">UPD</div>';

            jQuery('#TableTemplateContainer_INSRNC').append(recRow);
            document.getElementById("<%=hiddenTemplateCount_INSRNC.ClientID%>").value = EachTemp_INSRNC;

            document.getElementById("txtDuration_INSRNC_" + EachTemp_INSRNC).value = NotifyDur;
            document.getElementById("cbxDashboard_INSRNC_" + EachTemp_INSRNC).checked = false;
            document.getElementById("cbxEmail_INSRNC_" + EachTemp_INSRNC).checked = false;
            if (NotifyMod == 1) {
                document.getElementById("radioHours_INSRNC_" + EachTemp_INSRNC).checked = true;
            }
            else if (NotifyMod == 2) {
                document.getElementById("radioDays_INSRNC_" + EachTemp_INSRNC).checked = true;
            }
            if (NotifyVia != "") {
                if (NotifyVia.indexOf("D") >= 0) {
                    document.getElementById("cbxDashboard_INSRNC_" + EachTemp_INSRNC).checked = true;
                }

                if (NotifyVia.indexOf("E") >= 0) {
                    document.getElementById("cbxEmail_INSRNC_" + EachTemp_INSRNC).checked = true;
                }
            }

            AddDefaultTemplateValues_INSRNC(EachTemp_INSRNC);

            //FOR FILLING EACH SLICE DATA
            var EditEachSliceFullData = document.getElementById("<%=hiddenTemplateAlertData_INSRNC.ClientID%>").value;

            var EditEachTempliceData = EditEachSliceFullData.split("!");

            var findAtt2 = '\\"\\[';
            var reAtt2 = new RegExp(findAtt2, 'g');
            var resAtt2 = EditEachTempliceData[EachTemp_INSRNC].replace(reAtt2, '\[');

            var findAtt3 = '\\]\\"';
            var reAtt3 = new RegExp(findAtt3, 'g');
            var resAtt3 = resAtt2.replace(reAtt3, '\]');

            $noCon = jQuery.noConflict();
            var jsonAtt = $noCon.parseJSON(resAtt3);
            for (var key in jsonAtt) {
                if (jsonAtt.hasOwnProperty(key)) {
                    if (jsonAtt[key].TempAlertId != "") {
                        EditEachTempSlice_INSRNCBnk(EachTemp_INSRNC, jsonAtt[key].TempAlertId, jsonAtt[key].AlertOpt, jsonAtt[key].AlertNtfyId);


                    }
                }
            }

            if (document.getElementById("<%=hiddenEditMode_INSRNC.ClientID%>").value == "View") {
                document.getElementById("cbxDashboard_INSRNC_" + EachTemp_INSRNC).disabled = true;
                document.getElementById("cbxEmail_INSRNC_" + EachTemp_INSRNC).disabled = true;
                document.getElementById("radioDays_INSRNC_" + EachTemp_INSRNC).disabled = true;
                document.getElementById("radioHours_INSRNC_" + EachTemp_INSRNC).disabled = true;
                document.getElementById("txtDuration_INSRNC_" + EachTemp_INSRNC).disabled = true;
                document.getElementById("AddEachTempButton_INSRNC_" + EachTemp_INSRNC).disabled = true;
            }


            return false;
        }


        function addMoreEachTemplate_INSRNC() {//add

            EachTemp_INSRNC++;

            var recRow = '<tr id="TemplateRowId_INSRNC_' + EachTemp_INSRNC + ' >';
            recRow = '<div id=\"divEachTemplate_INSRNC_' + EachTemp_INSRNC + '\" style=\"float:left;margin-top:1%;padding:10px; width:80%;min-height: 170px;margin-left: 10%;border: 1px dotted;border-color: green;\">';
            recRow += '<div id=\" divTempLeftPart_INSRNC_' + EachTemp_INSRNC + '\" class=\"eachform\" style=\"float:left;width: 25%;height: 169px;border-right: 1px dotted;border-color: green;\">';
            recRow += '<h2 style=\"margin-left: 33%;font-size: 20px;color: #006475;\">Period *</h2>';


            recRow += '<div style=\"width:70%;margin-top: 19%;margin-left: 14%;background-color: wheat;color: #076309;border: 1px solid;\" >';
            recRow += '<input id=\"radioDays_INSRNC_' + EachTemp_INSRNC + '\" type=\"radio\" checked="true" onclick=\"UpdateNotifyMOde_INSRNC(' + EachTemp_INSRNC + ');\" name=\"radType_INSRNC' + EachTemp_INSRNC + '\" onkeypress="return DisableEnter(event)" />';
            recRow += '<label style=\"font-family:Calibri\" for=\"radioDays_INSRNC_' + EachTemp_INSRNC + '\">Days</label>';


            recRow += '<input id=\"radioHours_INSRNC_' + EachTemp_INSRNC + '\" type=\"radio\" onclick=\"UpdateNotifyMOde_INSRNC(' + EachTemp_INSRNC + ');\" name=\"radType_INSRNC' + EachTemp_INSRNC + '\" style=\"margin-left: 26px;\" onkeypress="return DisableEnter(event)"/>';
            recRow += '<label style=\"font-family:Calibri\" for=\"radioHours_INSRNC_' + EachTemp_INSRNC + '\">Hours</label>';

            recRow += '</div>';
            recRow += '<div style=\"width: 97%;margin-top: 6%;\">';


            recRow += ' <input type=\"text\" id=\"txtDuration_INSRNC_' + EachTemp_INSRNC + '\" class=\"form1\" onblur=\"UpdateNotifyDuration_INSRNC(' + EachTemp_INSRNC + ');\" onkeydown=\"return isNumber_INSRNC(event);\"  MaxLength=\"4\" Style=\"width: 30%; text-transform: uppercase; margin-right: 31.7%; height: 30px\" onkeypress="return DisableEnter(event)" />';
            recRow += ' <input type=\"button\" id=\"btnDurClear_INSRNC_' + EachTemp_INSRNC + '\" onclick=\"return ClearDur_INSRNC(' + EachTemp_INSRNC + ');\" class=\"ClearDur\" value=\"Clear\" style=\"margin-top: 13%;margin-left: 29%;\" />';
            recRow += ' </div></div>';


            recRow += '<div id="divTempRightPart_INSRNC_' + EachTemp_INSRNC + '" style="float:right;width: 74%;">';
            recRow += '<h2 style="margin-left: 42%;font-size: 20px;color: #006475;">Intimation *</h2>';

            recRow += '<div id=\"divTempRightContainer_INSRNC_' + EachTemp_INSRNC + '\" style=\"height: 135px;overflow: auto;width: 100%;\">';

            recRow += '<table id=\"TableEachTempSliceContainer_INSRNC_' + EachTemp_INSRNC + '\" style=\"width: 100%;\">';
            recRow += '</table>';

            recRow += ' </div>';
            recRow += '<div id=\"divBtmPortion_INSRNC_' + EachTemp_INSRNC + '\">';
            recRow += '<h2 style=\"float:left; margin-left: 1%;font-size: 16px;color: #000;padding-top: 3px;margin-top: 0px;\">Notification*</h2>';
            recRow += '<input type=\"checkbox\" id=\"cbxDashboard_INSRNC_' + EachTemp_INSRNC + '\" checked="true" onchange=\"UpdateNotifyVia_INSRNC(' + EachTemp_INSRNC + ',\'cbxDashboard_INSRNC_\');\" style=\"float: left;margin-left: 2%\;" Checked=\"true\" class=\"form2\ " onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">DashBoard</h3>';
            recRow += '<input type=\"checkbox\" id="cbxEmail_INSRNC_' + EachTemp_INSRNC + '" checked="true" onchange=\"UpdateNotifyVia_INSRNC(' + EachTemp_INSRNC + ',\'cbxEmail_INSRNC_\');\" style="float: left;margin-left: 3%;" Checked="true" class="form2" onkeypress="return DisableEnter(event)" />';
            recRow += '<h3 style=\"float: left;font-size: 15px;padding-top: 1px;font-family: calibri;\">Email</h3>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '</div>';
            recRow += '<div style=\"float:right;\"><input type=\"image\" src=\"/Images/Icons/black add.png\" onclick="return EachTemp_INSRNClateAddition_INSRNC();" alt=\"Add\" style=\"cursor: pointer;\" /></div>';
            recRow += '<div id="TemplateId_INSRNC_' + EachTemp_INSRNC + '" style="display: none;"> </div>';
            recRow += '<div id="TemplateEvent_INSRNC_' + EachTemp_INSRNC + '" style="display: none;">INS</div>';

            jQuery('#TableTemplateContainer_INSRNC').append(recRow);
            AddDefaultTemplateValues_INSRNC(EachTemp_INSRNC);
            AddEachTempSlice_INSRNC(EachTemp_INSRNC);
            document.getElementById("<%=hiddenTemplateCount_INSRNC.ClientID%>").value = EachTemp_INSRNC;

            return false;
        }

        var SliceCounter_INSRNC = 0;
        var EachTeCou_INSRNC = 0;
        var blurcounter_INSRNC = 0;



        function InitialiseCount_INSRNC() {
            EachTemp_INSRNC = 0;
            SliceCounter_INSRNC = 0;
            EachTeCou_INSRNC = 0;
            blurcounter_INSRNC = 0;
        }

        function EditEachTempSlice_INSRNC(EachTempCount, AlertId, AlertOpt, AlrtNtfyId) {//default sub



            var FrecRow = '<tr id="EachSliceRowId_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" >';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDivi_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/divisions.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DivisionClick_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ')\" /></div></td>';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDesig_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/designation.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DesignationClick_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ')\" /> </div> </td>';

            FrecRow += '<td style=\"width:5%\"><div id="divSmallEmp_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/employee.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return EmployeeClick_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ')\" /></div>  </td>';
            FrecRow += '<td style=\"width:5%\"><div id="divSmallMail_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/generic mail.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return GenericMailClick_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ')\" /> </div> </td>';
            FrecRow += '<td style=\"width:63%;background-color: #e7e7e7;\">';
            FrecRow += '<select id="ddlDivision_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" onchange="TempChangeFile_INSRNC(\'ddlDivision_INSRNC_\',' + EachTempCount + ',' + SliceCounter_INSRNC + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;" />';
            FrecRow += '<select id="ddlDesignation_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" onchange="TempChangeFile_INSRNC(\'ddlDesignation_INSRNC_\',' + EachTempCount + ',' + SliceCounter_INSRNC + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<select id="ddlEmployee_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" onchange="TempChangeFile_INSRNC(\'ddlEmployee_INSRNC_\',' + EachTempCount + ',' + SliceCounter_INSRNC + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<input type=\"text\" id="txtGenMail_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" onblur="TempChangeFile_INSRNC(\'txtGenMail_INSRNC_\',' + EachTempCount + ',' + SliceCounter_INSRNC + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;display:none;" MaxLength=\"100\" placeholder="Enter Generic Mail Id" onkeypress="return DisableEnter(event)" />';
            FrecRow += '</td>';
            FrecRow += '<td id="FileIndvlAddMoreRow_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '"  style=\"width:7%;opacity:1;\"><input id="inputAddRow_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" type=\"image\" src=\"/Images/Icons/eachtempadd.png\" alt=\"Add\" onclick="return TempCheckaddMoreRowsIndividualFiles_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ');" style=\"cursor: pointer;\" /> </td>';
            FrecRow += '<td style=\"width:10%\"><input id="inputDeleteRow_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" type=\"image\" src=\"/Images/Icons/eachtempclose.png\" alt=\"Add\" onclick = "return RemoveEachSlice_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ');"  style=\"cursor: pointer;\" /> </td>';

            FrecRow += '<td id="FileInx_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;">' + AlertId + '</td>';
            FrecRow += '<td id="DbFileName_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;"></td>';
            FrecRow += '<td id="Replace_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;">NO</td>';
            FrecRow += '<td id="ReplaceRow_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableEachTempSliceContainer_INSRNC_' + EachTempCount).append(FrecRow);

            // $('#divTempRightContainer_INSRNC_' + EachTempCount).scrollTop($('#divTempRightContainer_INSRNC_' + EachTempCount)[0].scrollHeight);

            document.getElementById("inputAddRow_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).disabled = false;

            if (EachTeCou_INSRNC != EachTempCount && EachTeCou_INSRNC != 0) {
                blurcounter_INSRNC = 0;
            }

            EachTeCou_INSRNC = EachTempCount;

            if (blurcounter_INSRNC != 0) {
                blurSlice = SliceCounter_INSRNC - 1;
                document.getElementById("FileIndvlAddMoreRow_INSRNC_" + EachTempCount + "_" + blurSlice).style.opacity = "0.3";
                document.getElementById("inputAddRow_INSRNC_" + EachTempCount + "_" + blurSlice).disabled = true;
            }

            blurcounter_INSRNC++;

            if (AlertOpt == 0) {
                FillDivisionDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                document.getElementById("divSmallDivi_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.backgroundColor = "#0246bd";
                document.getElementById("ddlDivision_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "block";
                document.getElementById("ddlDesignation_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("ddlEmployee_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("txtGenMail_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";

                setTimeout(selectDropDown_INSRNC("ddlDivision_INSRNC_", EachTempCount, SliceCounter_INSRNC, AlrtNtfyId), 200);
                FillDesignationDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                FillEmployeeDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);

                TempChangeFile_INSRNC('ddlDivision_INSRNC_', EachTempCount, SliceCounter_INSRNC);
            }
            else if (AlertOpt == 1) {
                FillDesignationDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                document.getElementById("divSmallDesig_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.backgroundColor = "#0246bd";

                document.getElementById("ddlDivision_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("ddlDesignation_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "block";
                document.getElementById("ddlEmployee_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("txtGenMail_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";

                setTimeout(selectDropDown_INSRNC("ddlDesignation_INSRNC_", EachTempCount, SliceCounter_INSRNC, AlrtNtfyId), 200);
                FillDivisionDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                FillEmployeeDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                TempChangeFile_INSRNC('ddlDesignation_INSRNC_', EachTempCount, SliceCounter_INSRNC);
            }
            else if (AlertOpt == 2) {
                FillEmployeeDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                document.getElementById("divSmallEmp_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.backgroundColor = "#0246bd";

                document.getElementById("ddlDivision_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("ddlDesignation_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("ddlEmployee_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "block";
                document.getElementById("txtGenMail_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";


                setTimeout(selectDropDown_INSRNC("ddlEmployee_INSRNC_", EachTempCount, SliceCounter_INSRNC, AlrtNtfyId), 200);
                FillDesignationDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                FillDivisionDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                TempChangeFile_INSRNC('ddlEmployee_INSRNC_', EachTempCount, SliceCounter_INSRNC);
            }
            else if (AlertOpt == 3) {

                document.getElementById("divSmallMail_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.backgroundColor = "#0246bd";
                document.getElementById("ddlDivision_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("ddlDesignation_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("ddlEmployee_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("txtGenMail_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "block";

                selectDropDown_INSRNC("txtGenMail_INSRNC_", EachTempCount, SliceCounter_INSRNC, AlrtNtfyId);
                FillEmployeeDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                FillDesignationDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                FillDivisionDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                TempChangeFile_INSRNC('txtGenMail_INSRNC_', EachTempCount, SliceCounter_INSRNC);
            }


            if (document.getElementById("<%=hiddenEditMode_INSRNC.ClientID%>").value == "View") {
                document.getElementById("txtGenMail_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).disabled = true;
                document.getElementById("ddlEmployee_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).disabled = true;
                document.getElementById("ddlDesignation_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).disabled = true;
                document.getElementById("ddlDivision_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).disabled = true;
                document.getElementById("inputAddRow_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).disabled = true;
                document.getElementById("inputDeleteRow_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).disabled = true;

                document.getElementById("divSmallMail_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.pointerEvents = "none";
                document.getElementById("divSmallEmp_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.pointerEvents = "none";
                document.getElementById("divSmallDesig_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.pointerEvents = "none";
                document.getElementById("divSmallDivi_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.pointerEvents = "none";

                document.getElementById("btnDurClear_INSRNC_" + EachTempCount).style.pointerEvents = "none";
            }

            SliceCounter_INSRNC++;

            return false;
        }

        function EditEachTempSlice_INSRNCBnk(EachTempCount, AlertId, AlertOpt, AlrtNtfyId) {//edit sub


            var FrecRow = '<tr id="EachSliceRowId_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" >';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDivi_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/divisions.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DivisionClick_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ')\" /></div></td>';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDesig_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/designation.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DesignationClick_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ')\" /> </div> </td>';

            FrecRow += '<td style=\"width:5%\"><div id="divSmallEmp_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/employee.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return EmployeeClick_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ')\" /></div>  </td>';
            FrecRow += '<td style=\"width:5%\"><div id="divSmallMail_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/generic mail.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return GenericMailClick_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ')\" /> </div> </td>';
            FrecRow += '<td style=\"width:63%;background-color: #e7e7e7;\">';
            FrecRow += '<select id="ddlDivision_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" onchange="TempChangeFile_INSRNC(\'ddlDivision_INSRNC_\',' + EachTempCount + ',' + SliceCounter_INSRNC + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;" />';
            FrecRow += '<select id="ddlDesignation_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" onchange="TempChangeFile_INSRNC(\'ddlDesignation_INSRNC_\',' + EachTempCount + ',' + SliceCounter_INSRNC + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<select id="ddlEmployee_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" onchange="TempChangeFile_INSRNC(\'ddlEmployee_INSRNC_\',' + EachTempCount + ',' + SliceCounter_INSRNC + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<input type=\"text\" id="txtGenMail_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" onblur="TempChangeFile_INSRNC(\'txtGenMail_INSRNC_\',' + EachTempCount + ',' + SliceCounter_INSRNC + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;display:none;" MaxLength=\"100\" placeholder="Enter Generic Mail Id" onkeypress="return DisableEnter(event)" />';
            FrecRow += '</td>';
            FrecRow += '<td id="FileIndvlAddMoreRow_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '"  style=\"width:7%;opacity:1;\"><input id="inputAddRow_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" type=\"image\" src=\"/Images/Icons/eachtempadd.png\" alt=\"Add\" onclick="return TempCheckaddMoreRowsIndividualFiles_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ');" style=\"cursor: pointer;\" /> </td>';
            FrecRow += '<td style=\"width:10%\"><input id="inputDeleteRow_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" type=\"image\" src=\"/Images/Icons/eachtempclose.png\" alt=\"Add\" onclick = "return RemoveEachSlice_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ');"  style=\"cursor: pointer;\" /> </td>';

            FrecRow += '<td id="FileInx_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;">' + AlertId + '</td>';
            FrecRow += '<td id="DbFileName_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;"></td>';
            FrecRow += '<td id="Replace_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;">NO</td>';
            FrecRow += '<td id="ReplaceRow_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableEachTempSliceContainer_INSRNC_' + EachTempCount).append(FrecRow);

            document.getElementById("inputAddRow_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).disabled = false;

            if (EachTeCou_INSRNC != EachTempCount && EachTeCou_INSRNC != 0) {

                blurcounter_INSRNC = 0;
            }
            EachTeCou_INSRNC = EachTempCount;

            if (blurcounter_INSRNC != 0) {
                blurSlice = SliceCounter_INSRNC - 1;
                document.getElementById("FileIndvlAddMoreRow_INSRNC_" + EachTempCount + "_" + blurSlice).style.opacity = "0.3";
                document.getElementById("inputAddRow_INSRNC_" + EachTempCount + "_" + blurSlice).disabled = true;

            }

            blurcounter_INSRNC++;
            if (AlertOpt == 0) {
                FillDivisionDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                document.getElementById("divSmallDivi_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.backgroundColor = "#0246bd";
                document.getElementById("ddlDivision_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "block";
                document.getElementById("ddlDesignation_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("ddlEmployee_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("txtGenMail_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";

                setTimeout(selectDropDown_INSRNC("ddlDivision_INSRNC_", EachTempCount, SliceCounter_INSRNC, AlrtNtfyId), 150);
                FillDesignationDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                FillEmployeeDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);

                TempChangeFile_INSRNC('ddlDivision_INSRNC_', EachTempCount, SliceCounter_INSRNC);
            }
            else if (AlertOpt == 1) {
                FillDesignationDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                document.getElementById("divSmallDesig_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.backgroundColor = "#0246bd";

                document.getElementById("ddlDivision_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("ddlDesignation_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "block";
                document.getElementById("ddlEmployee_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("txtGenMail_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";

                setTimeout(selectDropDown_INSRNC("ddlDesignation_INSRNC_", EachTempCount, SliceCounter_INSRNC, AlrtNtfyId), 150);
                FillDivisionDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                FillEmployeeDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                TempChangeFile_INSRNC('ddlDesignation_INSRNC_', EachTempCount, SliceCounter_INSRNC);
            }
            else if (AlertOpt == 2) {
                FillEmployeeDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                document.getElementById("divSmallEmp_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.backgroundColor = "#0246bd";

                document.getElementById("ddlDivision_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("ddlDesignation_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("ddlEmployee_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "block";
                document.getElementById("txtGenMail_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";


                setTimeout(selectDropDown_INSRNC("ddlEmployee_INSRNC_", EachTempCount, SliceCounter_INSRNC, AlrtNtfyId), 150);
                FillDesignationDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                FillDivisionDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                TempChangeFile_INSRNC('ddlEmployee_INSRNC_', EachTempCount, SliceCounter_INSRNC);
            }
            else if (AlertOpt == 3) {

                document.getElementById("divSmallMail_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.backgroundColor = "#0246bd";
                document.getElementById("ddlDivision_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("ddlDesignation_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("ddlEmployee_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "none";
                document.getElementById("txtGenMail_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "block";

                selectDropDown_INSRNC("txtGenMail_INSRNC_", EachTempCount, SliceCounter_INSRNC, AlrtNtfyId);
                FillEmployeeDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                FillDesignationDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                FillDivisionDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
                TempChangeFile_INSRNC('txtGenMail_INSRNC_', EachTempCount, SliceCounter_INSRNC);
            }


            if (document.getElementById("<%=hiddenEditMode_INSRNC.ClientID%>").value == "View") {
                document.getElementById("txtGenMail_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).disabled = true;
                document.getElementById("ddlEmployee_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).disabled = true;
                document.getElementById("ddlDesignation_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).disabled = true;
                document.getElementById("ddlDivision_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).disabled = true;
                document.getElementById("inputAddRow_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).disabled = true;
                document.getElementById("inputDeleteRow_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).disabled = true;

                document.getElementById("divSmallMail_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.pointerEvents = "none";
                document.getElementById("divSmallEmp_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.pointerEvents = "none";
                document.getElementById("divSmallDesig_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.pointerEvents = "none";
                document.getElementById("divSmallDivi_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.pointerEvents = "none";

                document.getElementById("btnDurClear_INSRNC_" + EachTempCount).style.pointerEvents = "none";
            }

            SliceCounter_INSRNC++;

            return false;
        }

        function AddEachTempSlice_INSRNC(EachTempCount) {//add sub


            var FrecRow = '<tr id="EachSliceRowId_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" >';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDivi_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/divisions.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DivisionClick_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ')\" /></div></td>';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDesig_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/designation.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DesignationClick_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ')\" /> </div> </td>';

            FrecRow += '<td style=\"width:5%\"><div id="divSmallEmp_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/employee.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return EmployeeClick_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ')\" /></div>  </td>';
            FrecRow += '<td style=\"width:5%\"><div id="divSmallMail_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/generic mail.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return GenericMailClick_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ')\" /> </div> </td>';
            FrecRow += '<td style=\"width:63%;background-color: #e7e7e7;\">';
            FrecRow += '<select id="ddlDivision_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" onchange="TempChangeFile_INSRNC(\'ddlDivision_INSRNC_\',' + EachTempCount + ',' + SliceCounter_INSRNC + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;" />';
            FrecRow += '<select id="ddlDesignation_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" onchange="TempChangeFile_INSRNC(\'ddlDesignation_INSRNC_\',' + EachTempCount + ',' + SliceCounter_INSRNC + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<select id="ddlEmployee_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" onchange="TempChangeFile_INSRNC(\'ddlEmployee_INSRNC_\',' + EachTempCount + ',' + SliceCounter_INSRNC + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<input type=\"text\" id="txtGenMail_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" onblur="TempChangeFile_INSRNC(\'txtGenMail_INSRNC_\',' + EachTempCount + ',' + SliceCounter_INSRNC + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;display:none;" placeholder="Enter Generic Mail Id" onkeypress="return DisableEnter(event)" />';
            FrecRow += '</td>';
            FrecRow += '<td id="FileIndvlAddMoreRow_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '"  style=\"width:7%;opacity:1;\"><input id="inputAddRow_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" type=\"image\" src=\"/Images/Icons/eachtempadd.png\" alt=\"Add\" onclick="return TempCheckaddMoreRowsIndividualFiles_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ');" style=\"cursor: pointer;\" /> </td>';
            FrecRow += '<td style=\"width:10%\"><input type=\"image\" src=\"/Images/Icons/eachtempclose.png\" alt=\"Add\" onclick = "return RemoveEachSlice_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ');"  style=\"cursor: pointer;\" /> </td>';

            FrecRow += '<td id="FileInx_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;"></td>';
            FrecRow += '<td id="Replace_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;">NO</td>';
            FrecRow += '<td id="ReplaceRow_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableEachTempSliceContainer_INSRNC_' + EachTempCount).append(FrecRow);
            // $('#divTempRightContainer_INSRNC_' + EachTempCount).scrollTop($('#divTempRightContainer_INSRNC_' + EachTempCount)[0].scrollHeight);
            FillDivisionDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
            FillDesignationDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
            FillEmployeeDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
            document.getElementById("divSmallDivi_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.backgroundColor = "#0246bd";
            SliceCounter_INSRNC++;

            return false;
        }


        function AddEachTempSliceReplace_INSRNC(EachTempCount, Slice, SelectDiv, SelectDrp, opacity) {


            var FrecRow = '<tr id="EachSliceRowId_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" >';
            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDivi_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/divisions.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DivisionClick_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ')\" /></div></td>';

            FrecRow += ' <td style=\"width:5%\"><div id="divSmallDesig_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/designation.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return DesignationClick_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ')\" /> </div> </td>';

            FrecRow += '<td style=\"width:5%\"><div id="divSmallEmp_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/employee.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return EmployeeClick_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ')\" /></div>  </td>';
            FrecRow += '<td style=\"width:5%\"><div id="divSmallMail_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" class=\"clsSmallDiv\"><input type=\"image\" src=\"/Images/Icons/generic mail.png\" alt=\"Add\" style=\"cursor: pointer;\" onclick=\"return GenericMailClick_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ')\" /> </div> </td>';
            FrecRow += '<td style=\"width:63%;background-color: #e7e7e7;\">';
            FrecRow += '<select id="ddlDivision_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" onchange="TempChangeFile_INSRNC(\'ddlDivision_INSRNC_\',' + EachTempCount + ',' + SliceCounter_INSRNC + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<select id="ddlDesignation_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" onchange="TempChangeFile_INSRNC(\'ddlDesignation_INSRNC_\',' + EachTempCount + ',' + SliceCounter_INSRNC + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<select id="ddlEmployee_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" onchange="TempChangeFile_INSRNC(\'ddlEmployee_INSRNC_\',' + EachTempCount + ',' + SliceCounter_INSRNC + ')" class="form1" Style="float: right; width: 83% !important; margin-right: 10%;display:none;" />';
            FrecRow += '<input type=\"text\" id="txtGenMail_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" onblur="TempChangeFile_INSRNC(\'txtGenMail_INSRNC_\',' + EachTempCount + ',' + SliceCounter_INSRNC + ')" class="form1" Style="float: right; width: 78% !important; margin-right: 10%;display:none;" placeholder="Enter Generic Mail Id" />';
            FrecRow += '</td>';
            FrecRow += '<td id="FileIndvlAddMoreRow_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '"  style=\"width:7%;opacity:1;\"><input id="inputAddRow_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" type=\"image\" src=\"/Images/Icons/eachtempadd.png\" alt=\"Add\" onclick="return TempCheckaddMoreRowsIndividualFiles_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ');" style=\"cursor: pointer;\" /> </td>';
            FrecRow += '<td style=\"width:10%\"><input type=\"image\" src=\"/Images/Icons/eachtempclose.png\" alt=\"Add\" onclick = "return RemoveEachSlice_INSRNC(' + EachTempCount + ',' + SliceCounter_INSRNC + ');"  style=\"cursor: pointer;\" /> </td>';

            FrecRow += '<td id="FileInx_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;"></td>';
            FrecRow += '<td id="Replace_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;">YES</td>';
            FrecRow += '<td id="ReplaceRow_INSRNC_' + EachTempCount + '_' + SliceCounter_INSRNC + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            $('#EachSliceRowId_INSRNC_' + EachTempCount + '_' + Slice).replaceWith(FrecRow);
            FillDivisionDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
            FillDesignationDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
            FillEmployeeDdl_INSRNC(EachTempCount, SliceCounter_INSRNC);
            document.getElementById(SelectDiv + EachTempCount + "_" + SliceCounter_INSRNC).style.backgroundColor = "#0246bd";
            document.getElementById(SelectDrp + EachTempCount + "_" + SliceCounter_INSRNC).style.display = "block";

            if (opacity == 0.3) {
                document.getElementById("FileIndvlAddMoreRow_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.opacity = "0.3";
                document.getElementById("inputAddRow_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).disabled = true;
            }
            else {
                document.getElementById("FileIndvlAddMoreRow_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).style.opacity = "1";
                document.getElementById("inputAddRow_INSRNC_" + EachTempCount + "_" + SliceCounter_INSRNC).disabled = false;
            }

            SliceCounter_INSRNC++;

            return false;
        }

        //----------Template slice-----------

        function selectDropDown_INSRNC(ddlid, TempCount, SliceCount, ddlvalue) {
            document.getElementById(ddlid + TempCount + "_" + SliceCount).value = ddlvalue;
            //alert(document.getElementById(ddlid + TempCount + "_" + SliceCount).value);
        }

        function ClearDur_INSRNC(EachTemp) {
            IncrmntConfrmCounter_INSRNC();
            document.getElementById("txtDuration_INSRNC_" + EachTemp).value = "";
            return false;
        }

        //for selection process
        function ChangeBGColor_INSRNC(divName, Temp, Slice) {
            document.getElementById("divSmallDivi_INSRNC_" + Temp + "_" + Slice).style.backgroundColor = "#fff";
            document.getElementById("divSmallDesig_INSRNC_" + Temp + "_" + Slice).style.backgroundColor = "#fff";
            document.getElementById("divSmallEmp_INSRNC_" + Temp + "_" + Slice).style.backgroundColor = "#fff";
            document.getElementById("divSmallMail_INSRNC_" + Temp + "_" + Slice).style.backgroundColor = "#fff";

            document.getElementById(divName + Temp + "_" + Slice).style.backgroundColor = "#0246bd";
        }

        function DivisionClick_INSRNC(Temp, Slice) {

            IncrmntConfrmCounter_INSRNC();
            ChangeBGColor_INSRNC("divSmallDivi_INSRNC_", Temp, Slice);
            document.getElementById("ddlDivision_INSRNC_" + Temp + "_" + Slice).style.display = "block";
            document.getElementById("ddlDesignation_INSRNC_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlEmployee_INSRNC_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("txtGenMail_INSRNC_" + Temp + "_" + Slice).style.display = "none";

            document.getElementById("ddlDesignation_INSRNC_" + Temp + "_" + Slice).value = 0;
            document.getElementById("ddlEmployee_INSRNC_" + Temp + "_" + Slice).value = 0;
            document.getElementById("txtGenMail_INSRNC_" + Temp + "_" + Slice).value = "";
            var Filerow_index = jQuery('#EachSliceRowId_INSRNC_' + Temp + '_' + Slice).index();
            TempFileLocalStorageDelete_INSRNC(Filerow_index, Temp, Slice);

            document.getElementById("FileEvt_INSRNC_" + Temp + '_' + Slice).innerHTML = "INS";
            document.getElementById("FileSave_INSRNC_" + Temp + '_' + Slice).innerHTML = " ";

            opacitypass = document.getElementById("FileIndvlAddMoreRow_INSRNC_" + Temp + "_" + Slice).style.opacity;

            AddEachTempSliceReplace_INSRNC(Temp, Slice, "divSmallDivi_INSRNC_", "ddlDivision_INSRNC_", opacitypass);
            return false;
        }

        function DesignationClick_INSRNC(Temp, Slice) {
            IncrmntConfrmCounter_INSRNC();
            ChangeBGColor_INSRNC("divSmallDesig_INSRNC_", Temp, Slice);
            document.getElementById("ddlDivision_INSRNC_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlDesignation_INSRNC_" + Temp + "_" + Slice).style.display = "block";
            document.getElementById("ddlEmployee_INSRNC_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("txtGenMail_INSRNC_" + Temp + "_" + Slice).style.display = "none";

            document.getElementById("ddlDivision_INSRNC_" + Temp + "_" + Slice).value = 0;
            document.getElementById("ddlEmployee_INSRNC_" + Temp + "_" + Slice).value = 0;
            document.getElementById("txtGenMail_INSRNC_" + Temp + "_" + Slice).value = "";
            var Filerow_index = jQuery('#EachSliceRowId_INSRNC_' + Temp + '_' + Slice).index();
            TempFileLocalStorageDelete_INSRNC(Filerow_index, Temp, Slice);
            document.getElementById("FileEvt_INSRNC_" + Temp + '_' + Slice).innerHTML = "INS";
            document.getElementById("FileSave_INSRNC_" + Temp + '_' + Slice).innerHTML = " ";

            opacitypass = document.getElementById("FileIndvlAddMoreRow_INSRNC_" + Temp + "_" + Slice).style.opacity;
            AddEachTempSliceReplace_INSRNC(Temp, Slice, "divSmallDesig_INSRNC_", "ddlDesignation_INSRNC_", opacitypass);
            return false;
        }
        function EmployeeClick_INSRNC(Temp, Slice) {
            IncrmntConfrmCounter_INSRNC();

            document.getElementById("ddlDivision_INSRNC_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlDesignation_INSRNC_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlEmployee_INSRNC_" + Temp + "_" + Slice).style.display = "block";
            document.getElementById("txtGenMail_INSRNC_" + Temp + "_" + Slice).style.display = "none";

            document.getElementById("ddlDivision_INSRNC_" + Temp + "_" + Slice).value = 0;
            document.getElementById("ddlDesignation_INSRNC_" + Temp + "_" + Slice).value = 0;
            document.getElementById("txtGenMail_INSRNC_" + Temp + "_" + Slice).value = "";

            ChangeBGColor_INSRNC("divSmallEmp_INSRNC_", Temp, Slice);
            var Filerow_index = jQuery('#EachSliceRowId_INSRNC_' + Temp + '_' + Slice).index();
            TempFileLocalStorageDelete_INSRNC(Filerow_index, Temp, Slice);
            document.getElementById("FileEvt_INSRNC_" + Temp + '_' + Slice).innerHTML = "INS";
            document.getElementById("FileSave_INSRNC_" + Temp + '_' + Slice).innerHTML = " ";

            opacitypass = document.getElementById("FileIndvlAddMoreRow_INSRNC_" + Temp + "_" + Slice).style.opacity;
            AddEachTempSliceReplace_INSRNC(Temp, Slice, "divSmallEmp_INSRNC_", "ddlEmployee_INSRNC_", opacitypass);
            return false;
        }
        function GenericMailClick_INSRNC(Temp, Slice) {
            IncrmntConfrmCounter_INSRNC();
            ChangeBGColor_INSRNC("divSmallMail_INSRNC_", Temp, Slice);
            document.getElementById("ddlDivision_INSRNC_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlDesignation_INSRNC_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("ddlEmployee_INSRNC_" + Temp + "_" + Slice).style.display = "none";
            document.getElementById("txtGenMail_INSRNC_" + Temp + "_" + Slice).style.display = "block";

            document.getElementById("ddlDivision_INSRNC_" + Temp + "_" + Slice).value = 0;
            document.getElementById("ddlDesignation_INSRNC_" + Temp + "_" + Slice).value = 0;
            document.getElementById("ddlEmployee_INSRNC_" + Temp + "_" + Slice).value = 0;

            var Filerow_index = jQuery('#EachSliceRowId_INSRNC_' + Temp + '_' + Slice).index();
            TempFileLocalStorageDelete_INSRNC(Filerow_index, Temp, Slice);
            document.getElementById("FileEvt_INSRNC_" + Temp + '_' + Slice).innerHTML = "INS";
            document.getElementById("FileSave_INSRNC_" + Temp + '_' + Slice).innerHTML = " ";

            opacitypass = document.getElementById("FileIndvlAddMoreRow_INSRNC_" + Temp + "_" + Slice).style.opacity;
            AddEachTempSliceReplace_INSRNC(Temp, Slice, "divSmallMail_INSRNC_", "txtGenMail_INSRNC_", opacitypass);
            return false;
        }


        function FillDivisionDdl_INSRNC(Temp, Slice) {

            var ddlTestDropDownListXML = $noCon("#ddlDivision_INSRNC_" + Temp + "_" + Slice);

            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableDivision";

            //alert(document.getElementById("<%=hiddenDivisionddlData_INSRNC.ClientID%>").value);

            if (document.getElementById("<%=hiddenDivisionddlData_INSRNC.ClientID%>").value != 0) {

                dropdowndata = document.getElementById("<%=hiddenDivisionddlData_INSRNC.ClientID%>").value;
                var OptionStart = $noCon("<option>--SELECT DIVISION--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);
                $noCon(dropdowndata).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noCon(this).find('CPRDIV_ID').text();
                    var OptionText = $noCon(this).find('CPRDIV_NAME').text();
                    // Create an Option for DropDownList.
                    var option = $noCon("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    ddlTestDropDownListXML.append(option);
                });

            }
            else {

                var IntCorpId = document.getElementById("<%=HiddenCorpId_INSRNC.ClientID%>").value;
                var IntOrgId = document.getElementById("<%=HiddenOrgansId_INSRNC.ClientID%>").value;
                $noCon.ajax({
                    async: false,
                    type: "POST",
                    url: "gen_Bank_Guarantee.aspx/DropdownDivisionBind_INSRNC",
                    data: '{tableName:"' + tableName + '",CorpId:"' + IntCorpId + '",OrgId:"' + IntOrgId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $noCon("<option>--SELECT DIVISION--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);

                        // Now find the Table from response and loop through each item (row).
                        $noCon(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noCon(this).find('CPRDIV_ID').text();
                            var OptionText = $noCon(this).find('CPRDIV_NAME').text();
                            // Create an Option for DropDownList.
                            var option = $noCon("<option>" + OptionText + "</option>");
                            option.attr("value", OptionValue);

                            ddlTestDropDownListXML.append(option);
                        });


                    },
                    failure: function (response) {

                    }
                });
            }
            // alert('delay');
        }

        function FillDesignationDdl_INSRNC(Temp, Slice) {

            var ddlTestDropDownListXML = $noCon("#ddlDesignation_INSRNC_" + Temp + "_" + Slice);

            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableDesignation";
            if (document.getElementById("<%=hiddenDesignationddlData_INSRNC.ClientID%>").value != 0) {
                dropdownDesData = document.getElementById("<%=hiddenDesignationddlData_INSRNC.ClientID%>").value;
                var OptionStart = $noCon("<option>--SELECT DESIGNATION--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);
                // Now find the Table from response and loop through each item (row).
                $noCon(dropdownDesData).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noCon(this).find('DSGN_ID').text();
                    var OptionText = $noCon(this).find('DSGN_NAME').text();
                    // Create an Option for DropDownList.
                    var option = $noCon("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    ddlTestDropDownListXML.append(option);
                });
            }
            else {

                var IntCorpId = document.getElementById("<%=HiddenCorpId_INSRNC.ClientID%>").value;
                var IntOrgId = document.getElementById("<%=HiddenOrgansId_INSRNC.ClientID%>").value;
                $noCon.ajax({
                    async: false,
                    type: "POST",
                    url: "gen_Bank_Guarantee.aspx/DropdownDesignationBind_INSRNC",
                    data: '{tableName:"' + tableName + '",CorpId:"' + IntCorpId + '",OrgId:"' + IntOrgId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $noCon("<option>--SELECT DESIGNATION--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);
                        // Now find the Table from response and loop through each item (row).
                        $noCon(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noCon(this).find('DSGN_ID').text();
                            var OptionText = $noCon(this).find('DSGN_NAME').text();
                            // Create an Option for DropDownList.
                            var option = $noCon("<option>" + OptionText + "</option>");
                            option.attr("value", OptionValue);

                            ddlTestDropDownListXML.append(option);
                        });
                    },
                    failure: function (response) {

                    }
                });
            }
        }

        function FillEmployeeDdl_INSRNC(Temp, Slice) {

            var ddlTestDropDownListXML = $noCon("#ddlEmployee_INSRNC_" + Temp + "_" + Slice);

            // Provide Some Table name to pass to the WebMethod as a paramter.
            var tableName = "dtTableEmployee";
            if (document.getElementById("<%=hiddenEmployeeDdlData_INSRNC.ClientID%>").value != 0) {
                ddlEmpdata = document.getElementById("<%=hiddenEmployeeDdlData_INSRNC.ClientID%>").value;
                var OptionStart = $noCon("<option>--SELECT EMPLOYEE--</option>");
                OptionStart.attr("value", 0);
                ddlTestDropDownListXML.append(OptionStart);
                // Now find the Table from response and loop through each item (row).
                $noCon(ddlEmpdata).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $noCon(this).find('USR_ID').text();
                    var OptionText = $noCon(this).find('USR_NAME').text();
                    // Create an Option for DropDownList.
                    var option = $noCon("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    ddlTestDropDownListXML.append(option);
                });
            }

            else {
                var IntCorpId = document.getElementById("<%=HiddenCorpId_INSRNC.ClientID%>").value;
                var IntOrgId = document.getElementById("<%=HiddenOrgansId_INSRNC.ClientID%>").value;
                $noCon.ajax({
                    async: false,
                    type: "POST",
                    url: "gen_Bank_Guarantee.aspx/DropdownEmployeeBind_INSRNC",
                    data: '{tableName:"' + tableName + '",CorpId:"' + IntCorpId + '",OrgId:"' + IntOrgId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $noCon("<option>--SELECT EMPLOYEE--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);
                        // Now find the Table from response and loop through each item (row).
                        $noCon(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $noCon(this).find('USR_ID').text();
                            var OptionText = $noCon(this).find('USR_NAME').text();
                            // Create an Option for DropDownList.
                            var option = $noCon("<option>" + OptionText + "</option>");
                            option.attr("value", OptionValue);

                            ddlTestDropDownListXML.append(option);
                        });
                    },
                    failure: function (response) {

                    }
                });
            }
        }

        function TemplateLoad_INSRNC() {

            localStorage.clear();
            document.getElementById("<%=hiddenNotificationMOde_INSRNC.ClientID%>").value = 0;
            document.getElementById("<%=hiddenNotifyVia_INSRNC.ClientID%>").value = 0;
            document.getElementById("<%=hiddenNotificationDuration_INSRNC.ClientID%>").value = 0;

            if (document.getElementById("<%=hiddenEachTemplateDetail_INSRNC.ClientID%>").value != 0) {
                var EditEachTemplate = document.getElementById("<%=hiddenEachTemplateDetail_INSRNC.ClientID%>").value;
                var findAtt2 = '\\"\\[';
                var reAtt2 = new RegExp(findAtt2, 'g');
                var resAtt2 = EditEachTemplate.replace(reAtt2, '\[');

                var findAtt3 = '\\]\\"';
                var reAtt3 = new RegExp(findAtt3, 'g');
                var resAtt3 = resAtt2.replace(reAtt3, '\]');
                //alert(res3);
                var jsonAtt = $noCon.parseJSON(resAtt3);
                for (var key in jsonAtt) {
                    if (jsonAtt.hasOwnProperty(key)) {

                        if (jsonAtt[key].TempDetailId != "") {

                            EditMoreEachTemplate_INSRNC(jsonAtt[key].TempDetailId, jsonAtt[key].NotifyMod, jsonAtt[key].NotifyVia, jsonAtt[key].NotifyDur);
                        }
                    }
                }
            }
            else {

                addMoreEachTemplate_INSRNC();
            }

            document.getElementById("<%=ddlTemplate_INSRNC.ClientID%>").focus();
        }

        function TempChangeFile_INSRNC(DDL, TempCount, Slice) {

            IncrmntConfrmCounter_INSRNC();
            ret = true;
            if (DDL == "txtGenMail_INSRNC_") {
                var NameWithoutReplace = document.getElementById(DDL + TempCount + "_" + Slice).value;
                var replaceText1 = NameWithoutReplace.replace(/</g, "");
                var replaceText2 = replaceText1.replace(/>/g, "");
                document.getElementById(DDL + TempCount + "_" + Slice).value = replaceText2;

                document.getElementById(DDL + TempCount + "_" + Slice).style.borderColor = "";
                var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                var ToMail = document.getElementById(DDL + TempCount + "_" + Slice).value;
                var ToMailSplit = [];
                ToMailSplit = ToMail.split(',');
                if (ToMailSplit != "") {
                    for (ArrCount = 0; ArrCount < ToMailSplit.length; ArrCount++) {


                        if (!filter.test(ToMailSplit[ArrCount])) {
                            document.getElementById(DDL + TempCount + "_" + Slice).style.borderColor = "red";

                            ret = false;
                        }

                    }
                }
            }
            if (DDL == "txtGenMail_INSRNC_") {
                if (ret == true) {
                    var SavedorNot = document.getElementById("FileSave_INSRNC_" + TempCount + "_" + Slice).innerHTML;

                    if (SavedorNot == "saved") {

                        var row_index = jQuery('#EachSliceRowId_INSRNC_' + TempCount + '_' + Slice).index();

                        TempFileLocalStorageEdit_INSRNC(DDL, TempCount, Slice, row_index);
                    }
                    else {

                        TempFileLocalStorageAdd_INSRNC(DDL, TempCount, Slice);
                    }
                }
                else {
                    var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_INSRNC_" + TempCount);//Retrieve the stored data

                    tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload);

                    if (tbClientTemplateUpload != null && tbClientTemplateUpload != []) {
                        var Filerow_index = jQuery('#EachSliceRowId_INSRNC_' + TempCount + '_' + Slice).index();
                        TempFileLocalStorageDelete_INSRNC(Filerow_index, Temp, Slice);

                    }
                }
            }
            else {

               // alert(document.getElementById(DDL + TempCount + '_' + Slice).value);

                var DropDownValue = document.getElementById(DDL + TempCount + '_' + Slice).value;

                if (DropDownValue != 0) {
                    //------for deciding add or edit---------

                    var SavedorNot = document.getElementById("FileSave_INSRNC_" + TempCount + "_" + Slice).innerHTML;

                    if (SavedorNot == "saved") {

                        var row_index = jQuery('#EachSliceRowId_INSRNC_' + TempCount + '_' + Slice).index();

                        TempFileLocalStorageEdit_INSRNC(DDL, TempCount, Slice, row_index);
                    }
                    else {

                        TempFileLocalStorageAdd_INSRNC(DDL, TempCount, Slice);
                    }
                }
                else {

                    var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_INSRNC_" + TempCount);//Retrieve the stored data

                    tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload);
                    if (tbClientTemplateUpload != null && tbClientTemplateUpload != []) {
                        var Filerow_index = jQuery('#EachSliceRowId_INSRNC_' + TempCount + '_' + Slice).index();
                        TempFileLocalStorageDelete_INSRNC(Filerow_index, TempCount, Slice);
                    }
                }

            }

        }

        function TempCheckaddMoreRowsIndividualFiles_INSRNC(TempCount, x) {

            if (CheckEachDdl_INSRNC(TempCount, x)) {

                var check = document.getElementById("FileInx_INSRNC_" + TempCount + "_" + x).innerHTML;
                if (check == " ") {
                    var Fevt = document.getElementById("FileEvt_INSRNC_" + TempCount + "_" + x).innerHTML;
                    if (Fevt != 'UPD') {

                        document.getElementById("FileInx_INSRNC_" + TempCount + "_" + x).innerHTML = TempCount + "_" + x;
                        document.getElementById("FileIndvlAddMoreRow_INSRNC_" + TempCount + "_" + x).style.opacity = "0.3";


                        AddEachTempSlice_INSRNC(TempCount);
                        document.getElementById("inputAddRow_INSRNC_" + TempCount + "_" + x).disabled = true;
                        return false;

                    }
                    else {

                        document.getElementById("FileInx_INSRNC_" + TempCount + "_" + x).innerHTML = TempCount + "_" + x;
                        document.getElementById("FileIndvlAddMoreRow_INSRNC_" + TempCount + "_" + x).style.opacity = "0.3";

                        AddEachTempSlice_INSRNC(TempCount);
                        document.getElementById("inputAddRow_INSRNC_" + TempCount + "_" + x).disabled = true;
                        return false;
                    }
                }
            }
            else {
                return false;
            }

        }

        function CheckEachDdl_INSRNC(Temp, Slice) {

            if (document.getElementById("ddlDivision_INSRNC_" + Temp + "_" + Slice).value == 0 && document.getElementById("ddlDesignation_INSRNC_" + Temp + "_" + Slice).value == 0 && document.getElementById("ddlEmployee_INSRNC_" + Temp + "_" + Slice).value == 0 && document.getElementById("txtGenMail_INSRNC_" + Temp + "_" + Slice).value == "") {
                return false;
            }
            else {
                return true;
            }

        }


        function TempFileLocalStorageAdd_INSRNC(ddl, TempCount, Slice) {

            var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_INSRNC_" + TempCount);//Retrieve the stored data

            tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload); //Converts string to object

            if (tbClientTemplateUpload == null) //If there is no data, initialize an empty array
                tbClientTemplateUpload = [];

            if (document.getElementById("Replace_INSRNC_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_INSRNC_" + TempCount + '_' + Slice).innerHTML == "") {

                editedIndex = tbClientTemplateUpload.length;
                document.getElementById("ReplaceRow_INSRNC_" + TempCount + '_' + Slice).innerHTML = editedIndex;
            }


            var DropDownValue = document.getElementById(ddl + TempCount + '_' + Slice).value;
            var FdetailId = document.getElementById("FileDtlId_INSRNC_" + TempCount + '_' + Slice).innerHTML;
            var Fevt = document.getElementById("FileEvt_INSRNC_" + TempCount + '_' + Slice).innerHTML;
            //   alert('filePath_INSRNC' + filePath_INSRNC);

            if (Fevt == 'INS') {
                var client = JSON.stringify({
                    ROWID: "" + Slice + "",
                    DDLVALUE: "" + DropDownValue + "",
                    DDLMODE: "" + ddl + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"

                });
            }
            else if (Fevt == 'UPD') {
                var client = JSON.stringify({
                    ROWID: "" + Slice + "",
                    DDLVALUE: "" + DropDownValue + "",
                    DDLMODE: "" + ddl + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });
            }

            tbClientTemplateUpload.push(client);
            localStorage.setItem("tbClientTemplateUpload_INSRNC_" + TempCount, JSON.stringify(tbClientTemplateUpload));

            document.getElementById("FileSave_INSRNC_" + TempCount + '_' + Slice).innerHTML = "saved";
            //   alert('saved');
            return true;

        }

        function TempFileLocalStorageEdit_INSRNC(ddl, TempCount, Slice, row_index) {

            if (document.getElementById("Replace_INSRNC_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_INSRNC_" + TempCount + '_' + Slice).innerHTML != "") {
                row_index = document.getElementById("ReplaceRow_INSRNC_" + TempCount + '_' + Slice).innerHTML;
            }


            var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_INSRNC_" + TempCount);//Retrieve the stored data

            tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload); //Converts string to object

            if (tbClientTemplateUpload == null) //If there is no data, initialize an empty array
                tbClientTemplateUpload = [];
            var DropDownValue = document.getElementById(ddl + TempCount + '_' + Slice).value;
            var FdetailId = document.getElementById("FileDtlId_INSRNC_" + TempCount + '_' + Slice).innerHTML;
            var Fevt = document.getElementById("FileEvt_INSRNC_" + TempCount + '_' + Slice).innerHTML;

            var tbClientTemplateUploadCancel = localStorage.getItem("tbClientTemplateUploadDelete_INSRNC_" + TempCount);//Retrieve the stored data

            tbClientTemplateUploadCancel = JSON.parse(tbClientTemplateUploadCancel);
            if (tbClientTemplateUploadCancel == null) //If there is no data, initialize an empty array
                tbClientTemplateUploadCancel = [];
            deleteLength = tbClientTemplateUploadCancel.length;

            if (document.getElementById("Replace_INSRNC_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_INSRNC_" + TempCount + '_' + Slice).innerHTML != "") {
                row_index = document.getElementById("ReplaceRow_INSRNC_" + TempCount + '_' + Slice).innerHTML;

            }
            else if (document.getElementById("Replace_INSRNC_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_INSRNC_" + TempCount + '_' + Slice).innerHTML == "") {

            }
            else {

                row_index = row_index - deleteLength;

            }


            if (Fevt == 'INS') {


                tbClientTemplateUpload[row_index] = JSON.stringify({
                    ROWID: "" + Slice + "",
                    DDLVALUE: "" + DropDownValue + "",
                    DDLMODE: "" + ddl + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"
                });//Alter the selected item on the table

            }
            else {
                tbClientTemplateUpload[row_index] = JSON.stringify({
                    ROWID: "" + Slice + "",
                    DDLVALUE: "" + DropDownValue + "",
                    DDLMODE: "" + ddl + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });//Alter the selected item on the table



            }

            localStorage.setItem("tbClientTemplateUpload_INSRNC_" + TempCount, JSON.stringify(tbClientTemplateUpload));
            return true;
        }

        function TempFileLocalStorageDelete_INSRNC(row_index, TempCount, Slice) {

            var $DelFile = jQuery.noConflict();
            var tbClientTemplateUpload = localStorage.getItem("tbClientTemplateUpload_INSRNC_" + TempCount);//Retrieve the stored data

            tbClientTemplateUpload = JSON.parse(tbClientTemplateUpload); //Converts string to object
            if (tbClientTemplateUpload == null) //If there is no data, initialize an empty array
                tbClientTemplateUpload = [];

            ContentCount = tbClientTemplateUpload.length;
            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            var tbClientTemplateUploadCancel = localStorage.getItem("tbClientTemplateUploadDelete_INSRNC_" + TempCount);//Retrieve the stored data

            tbClientTemplateUploadCancel = JSON.parse(tbClientTemplateUploadCancel);
            if (tbClientTemplateUploadCancel == null) //If there is no data, initialize an empty array
                tbClientTemplateUploadCancel = [];
            deleteLength = tbClientTemplateUploadCancel.length;



            if (document.getElementById("Replace_INSRNC_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_INSRNC_" + TempCount + '_' + Slice).innerHTML != "") {
                row_index = document.getElementById("ReplaceRow_INSRNC_" + TempCount + '_' + Slice).innerHTML;

                if (ContentCount == 1) {
                    row_index = 0;
                }

                tbClientTemplateUpload.splice(row_index, 1);
            }
            else if (document.getElementById("Replace_INSRNC_" + TempCount + '_' + Slice).innerHTML == "YES" && document.getElementById("ReplaceRow_INSRNC_" + TempCount + '_' + Slice).innerHTML == "") {

            }
            else {

                row_index = row_index - deleteLength;


                if (ContentCount == 1) {
                    row_index = 0;
                }

                tbClientTemplateUpload.splice(row_index, 1);
            }
            localStorage.setItem("tbClientTemplateUpload_INSRNC_" + TempCount, JSON.stringify(tbClientTemplateUpload));

            var Fevt = document.getElementById("FileEvt_INSRNC_" + TempCount + '_' + Slice).innerHTML;
            if (Fevt == 'UPD') {
                var FdetailId = document.getElementById("FileDtlId_INSRNC_" + TempCount + '_' + Slice).innerHTML;

                if (FdetailId != '') {

                    DeleteFileLSTORAGEAdd_INSRNC(TempCount, Slice);
                }

            }
        }

        function DeleteFileLSTORAGEAdd_INSRNC(TempCount, Slice) {

            var tbClientTemplateUploadCancel = localStorage.getItem("tbClientTemplateUploadDelete_INSRNC_" + TempCount);//Retrieve the stored data

            tbClientTemplateUploadCancel = JSON.parse(tbClientTemplateUploadCancel); //Converts string to object

            if (tbClientTemplateUploadCancel == null) //If there is no data, initialize an empty array
                tbClientTemplateUploadCancel = [];

            var FdetailId = document.getElementById("FileDtlId_INSRNC_" + TempCount + "_" + Slice).innerHTML;

            var $addFile = jQuery.noConflict();
            var client = JSON.stringify({
                ROWID: "" + Slice + "",
                // FILENAME: "" + FileName + "",
                // EVTACTION: "" + Fevt + "",
                DTLID: "" + FdetailId + ""

            });



            tbClientTemplateUploadCancel.push(client);
            localStorage.setItem("tbClientTemplateUploadDelete_INSRNC" + TempCount, JSON.stringify(tbClientTemplateUploadCancel));

            $addFile("#cphMain_hiddenDeleteSliceData_INSRNC").val(JSON.stringify(tbClientTemplateUploadCancel));


            return true;

        }

        //-------------Template-----------
        function EachTemplateAddition_INSRNC() {
            IncrmntConfrmCounter_INSRNC();
            if (confirm("Are you sure you want to add new template section?.You will not be able to delete it in future")) {

                if (CheckEachTemp_INSRNC() == true) {
                    addMoreEachTemplate_INSRNC();
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }

        function CheckEachTemp_INSRNC() {

            var Count = document.getElementById("<%=hiddenTemplateCount_INSRNC.ClientID%>").value;

            var TempValue = ""
            for (intCount = 1; intCount <= Count; intCount++) {

                TempValue = localStorage.getItem("tbClientTemplateUpload_INSRNC_" + intCount);
                if (TempValue == null) {
                    return false;
                }
            }

            return true;
        }


        function AddDefaultTemplateValues_INSRNC(TempCount) {

            var Fevt = document.getElementById("TemplateEvent_INSRNC_" + TempCount).innerHTML;
            var TemplateId = document.getElementById("TemplateId_INSRNC_" + TempCount).innerHTML;

            //----for notification mode
            var Mode = "";
            if (document.getElementById("radioDays_INSRNC_" + TempCount).checked == true) {
                Mode = "D";
            }
            else if (document.getElementById("radioHours_INSRNC_" + TempCount).checked == true) {
                Mode = "H";
            }


            var tbClientNotifyMode = localStorage.getItem("tbClientNotifyMode_INSRNC");
            tbClientNotifyMode = JSON.parse(tbClientNotifyMode); //Converts string to object

            if (tbClientNotifyMode == null) {//If there is no data, initialize an empty array
                var $FileZ = jQuery.noConflict();

                if ($FileZ("#cphMain_hiddenNotificationMOde_INSRNC").val() != 0) {
                    var HiddenValue = $FileZ("#cphMain_hiddenNotificationMOde_INSRNC").val();
                    tbClientNotifyMode = JSON.parse(HiddenValue);
                }
                else {

                    tbClientNotifyMode = [];
                }
            }
            if (Fevt == 'INS') {
                var client = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTMODE: "" + Mode + "",
                    TEMPID: "0"

                });
            }
            else if (Fevt == 'UPD') {
                var client = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTMODE: "" + Mode + "",
                    TEMPID: "" + TemplateId + ""

                });
            }
            tbClientNotifyMode.push(client);
            localStorage.setItem("tbClientNotifyMode_INSRNC", JSON.stringify(tbClientNotifyMode));

            var $FileE = jQuery.noConflict();
            $FileE("#cphMain_hiddenNotificationMOde_INSRNC").val(JSON.stringify(tbClientNotifyMode));

            //---for notify via what---
            var Via = "";
            if (document.getElementById("cbxEmail_INSRNC_" + TempCount).checked == true) {
                Via = Via + "E";
            }
            if (document.getElementById("cbxDashboard_INSRNC_" + TempCount).checked == true) {
                Via = Via + "," + "D";
            }

            var tbClientNotifyVia = localStorage.getItem("tbClientNotifyVia_INSRNC");
            tbClientNotifyVia = JSON.parse(tbClientNotifyVia); //Converts string to object

            if (tbClientNotifyVia == null) {//If there is no data, initialize an empty array
                var $FileW = jQuery.noConflict();
                if ($FileW("#cphMain_hiddenNotifyVia_INSRNC").val() != 0) {
                    var HiddenViaValue = $FileW("#cphMain_hiddenNotifyVia_INSRNC").val();
                    tbClientNotifyVia = JSON.parse(HiddenViaValue);
                }
                else {
                    tbClientNotifyVia = [];
                }
            }

            if (Fevt == 'INS') {


                var client2 = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTVIA: "" + Via + "",
                    TEMPID: "0"
                });//Alter the selected item on the table

            }
            else {
                var client2 = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTVIA: "" + Via + "",
                    TEMPID: "" + TemplateId + ""

                });

            }

            tbClientNotifyVia.push(client2);
            localStorage.setItem("tbClientNotifyVia_INSRNC", JSON.stringify(tbClientNotifyVia));
            var $FileF = jQuery.noConflict();
            $FileF("#cphMain_hiddenNotifyVia_INSRNC").val(JSON.stringify(tbClientNotifyVia));

            //----for notification duration--
            var Duration = document.getElementById("txtDuration_INSRNC_" + TempCount).value;
            var tbClientNotifyDur = localStorage.getItem("tbClientNotifyDur_INSRNC");
            tbClientNotifyDur = JSON.parse(tbClientNotifyDur); //Converts string to object

            if (tbClientNotifyDur == null) { //If there is no data, initialize an empty array
                var $FileA = jQuery.noConflict();
                if ($FileA("#cphMain_hiddenNotificationDuration_INSRNC").val() != 0) {
                    var HiddenDurValue = $FileA("#cphMain_hiddenNotificationDuration_INSRNC").val();
                    tbClientNotifyDur = JSON.parse(HiddenDurValue);
                }
                else {
                    tbClientNotifyDur = [];
                }
            }

            if (Fevt == 'INS') {


                var client3 = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTDUR: "" + Duration + "",
                    TEMPID: "0"
                });//Alter the selected item on the table

            }
            else {
                var client3 = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTDUR: "" + Duration + "",
                    TEMPID: "" + TemplateId + ""

                });

            }

            tbClientNotifyDur.push(client3);
            localStorage.setItem("tbClientNotifyDur_INSRNC", JSON.stringify(tbClientNotifyDur));
            var $FileG = jQuery.noConflict();
            $FileG("#cphMain_hiddenNotificationDuration_INSRNC").val(JSON.stringify(tbClientNotifyDur));
            return false;
        }


        function UpdateNotifyMOde_INSRNC(TempCount) {

            var Fevt = document.getElementById("TemplateEvent_INSRNC_" + TempCount).innerHTML;
            var TemplateId = document.getElementById("TemplateId_INSRNC_" + TempCount).innerHTML;

            var Mode = "";
            if (document.getElementById("radioDays_INSRNC_" + TempCount).checked == true) {
                Mode = "D";
            }
            else if (document.getElementById("radioHours_INSRNC_" + TempCount).checked == true) {
                Mode = "H";
            }

            var row_index = TempCount - 1;

            var tbClientNotifyMode = localStorage.getItem("tbClientNotifyMode_INSRNC");
            if (tbClientNotifyMode == null) {
                var $FileG = jQuery.noConflict();
                tbClientNotifyMode = $FileG("#cphMain_hiddenNotificationMOde_INSRNC").val();
            }


            tbClientNotifyMode = JSON.parse(tbClientNotifyMode); //Converts string to object


            if (tbClientNotifyMode == null) //If there is no data, initialize an empty array
                tbClientNotifyMode = [];


            if (Fevt == 'INS') {

                tbClientNotifyMode[row_index] = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTMODE: "" + Mode + "",
                    TEMPID: " 0"
                });//Alter the selected item on the table
            }
            else {
                tbClientNotifyMode[row_index] = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTMODE: "" + Mode + "",
                    TEMPID: "" + TemplateId + ""

                });

            }

            localStorage.setItem("tbClientNotifyMode_INSRNC", JSON.stringify(tbClientNotifyMode));
            var $FileE = jQuery.noConflict();
            $FileE("#cphMain_hiddenNotificationMOde_INSRNC").val(JSON.stringify(tbClientNotifyMode));

        }

        function UpdateNotifyDuration_INSRNC(TempCount) {


            var NameWithoutReplace = document.getElementById("txtDuration_INSRNC_" + TempCount).value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("txtDuration_INSRNC_" + TempCount).value = replaceText2;

            var txtPerVal = document.getElementById("txtDuration_INSRNC_" + TempCount).value;
            document.getElementById("txtDuration_INSRNC_" + TempCount).style.borderColor = "";

            if (txtPerVal.indexOf('.') !== -1) {
                document.getElementById("txtDuration_INSRNC_" + TempCount).value = "";
                document.getElementById("txtDuration_INSRNC_" + TempCount).style.borderColor = "red";

            }
            if (!isNaN(txtPerVal) == false) {

                document.getElementById("txtDuration_INSRNC_" + TempCount).value = "";
                document.getElementById("txtDuration_INSRNC_" + TempCount).style.borderColor = "red";

            }
            else {
                if (txtPerVal < 0) {
                    document.getElementById("txtDuration_INSRNC_" + TempCount).value = "";
                    document.getElementById("txtDuration_INSRNC_" + TempCount).style.borderColor = "red";

                }
            }


            var Fevt = document.getElementById("TemplateEvent_INSRNC_" + TempCount).innerHTML;
            var TemplateId = document.getElementById("TemplateId_INSRNC_" + TempCount).innerHTML;
            var Duration = document.getElementById("txtDuration_INSRNC_" + TempCount).value;
            var row_index = TempCount - 1;

            var tbClientNotifyDur = localStorage.getItem("tbClientNotifyDur_INSRNC");

            if (tbClientNotifyDur == null) {
                var $FileM = jQuery.noConflict();
                tbClientNotifyDur = $FileM("#cphMain_hiddenNotificationDuration_INSRNC").val();

            }

            tbClientNotifyDur = JSON.parse(tbClientNotifyDur); //Converts string to object

            if (tbClientNotifyDur == null) //If there is no data, initialize an empty array
                tbClientNotifyDur = [];

            if (Fevt == 'INS') {


                tbClientNotifyDur[row_index] = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTDUR: "" + Duration + "",
                    TEMPID: "0"
                });//Alter the selected item on the table

            }
            else {
                tbClientNotifyDur[row_index] = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTDUR: "" + Duration + "",
                    TEMPID: "" + TemplateId + ""

                });

            }

            localStorage.setItem("tbClientNotifyDur_INSRNC", JSON.stringify(tbClientNotifyDur));
            var $FileG = jQuery.noConflict();
            $FileG("#cphMain_hiddenNotificationDuration_INSRNC").val(JSON.stringify(tbClientNotifyDur));

        }

        function UpdateNotifyVia_INSRNC(TempCount, ClickedCbx) {

            var Fevt = document.getElementById("TemplateEvent_INSRNC_" + TempCount).innerHTML;
            var TemplateId = document.getElementById("TemplateId_INSRNC_" + TempCount).innerHTML;
            var Via = "";
            if (document.getElementById("cbxEmail_INSRNC_" + TempCount).checked == true) {

                Via = Via + "," + "E";
            }
            if (document.getElementById("cbxDashboard_INSRNC_" + TempCount).checked == true) {

                Via = Via + "," + "D";
            }

            var row_index = TempCount - 1;

            var tbClientNotifyVia = localStorage.getItem("tbClientNotifyVia_INSRNC");

            if (tbClientNotifyVia == null) {
                var $FileH = jQuery.noConflict();
                tbClientNotifyVia = $FileH("#cphMain_hiddenNotifyVia_INSRNC").val();

            }

            tbClientNotifyVia = JSON.parse(tbClientNotifyVia); //Converts string to object

            if (tbClientNotifyVia == null) //If there is no data, initialize an empty array
                tbClientNotifyVia = [];

            if (Fevt == 'INS') {


                tbClientNotifyVia[row_index] = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTVIA: "" + Via + "",
                    TEMPID: "0"
                });//Alter the selected item on the table

            }
            else {
                tbClientNotifyVia[row_index] = JSON.stringify({
                    ROWID: "" + TempCount + "",
                    NOTVIA: "" + Via + "",
                    TEMPID: "" + TemplateId + ""

                });

            }

            localStorage.setItem("tbClientNotifyVia_INSRNC", JSON.stringify(tbClientNotifyVia));
            var $FileF = jQuery.noConflict();
            $FileF("#cphMain_hiddenNotifyVia_INSRNC").val(JSON.stringify(tbClientNotifyVia));

        }

        function RemoveEachSlice_INSRNC(TempCount, removeNum) {
            if (confirm("Are you sure you want to delete?")) {
                var Filerow_index = jQuery('#EachSliceRowId_INSRNC_' + TempCount + '_' + removeNum).index();
                TempFileLocalStorageDelete_INSRNC(Filerow_index, TempCount, removeNum);
                jQuery('#EachSliceRowId_INSRNC_' + TempCount + '_' + removeNum).remove();

                var TableFileRowCount = document.getElementById("TableEachTempSliceContainer_INSRNC_" + TempCount).rows.length;

                if (TableFileRowCount != 0) {
                    var idlast = $noC('#TableEachTempSliceContainer_INSRNC_' + TempCount + ' tr:last').attr('id');

                    if (idlast != "") {
                        var res = idlast.split("_");
                        document.getElementById("FileInx_INSRNC_" + TempCount + '_' + res[2]).innerHTML = " ";
                        document.getElementById("FileIndvlAddMoreRow_INSRNC_" + TempCount + '_' + res[2]).style.opacity = "1";
                        document.getElementById("inputAddRow_INSRNC_" + TempCount + "_" + res[2]).disabled = false;
                    }
                }
                else {
                    AddEachTempSlice_INSRNC(TempCount);


                }

            }
            else {

                return false;
            }
        }

    </script>


    <script>

        //evm-0023
        function Validate_INSRNC() {

            var ret = true;
            if (CheckIsRepeat_INSRNC() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            document.getElementById('divMessageArea').style.display = "none";
            document.getElementById('imgMessageArea').src = "";

            if (document.getElementById("<%=HiddenGurntNumDupChk_INSRNC.ClientID%>").value == "1") {
                Duplication_INSRNC();
                CheckSubmitZero_INSRNC();
                return false;
            }

            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtOpngDate_INSRNC.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOpngDate_INSRNC.ClientID%>").value = replaceText2;


            var NameWithoutReplace = document.getElementById("<%=txtInsuranceno.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtInsuranceno.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtAmount_INSRNC.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAmount_INSRNC.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtDescrptn_INSRNC.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtDescrptn_INSRNC.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtEmpName_INSRNC.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEmpName_INSRNC.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtCntctMail_INSRNC.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCntctMail_INSRNC.ClientID%>").value = replaceText2;

            document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtOpngDate_INSRNC.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtInsuranceno.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAmount_INSRNC.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtDescrptn_INSRNC.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtEmpName_INSRNC.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCntctMail_INSRNC.ClientID%>").style.borderColor = "";
            $noCon("div#divddlInsurncPrvdr input.ui-autocomplete-input").css("borderColor", "");           
            $noCon("div#divddlInsurancType input.ui-autocomplete-input").css("borderColor", "");  
            $noCon("div#divProject input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById("<%=ddlTemplate_INSRNC.ClientID%>").style.borderColor = "";

            var InsuranceNo = document.getElementById("<%=txtInsuranceno.ClientID%>").value.trim();

            var InsrPrvdr = document.getElementById("<%=ddlInsurncPrvdr.ClientID%>");
            var InsrPrvdrText = InsrPrvdr.options[InsrPrvdr.selectedIndex].text;

            var InsrTyp = document.getElementById("<%=ddlInsurncTyp.ClientID%>");
            var InsrTypText = InsrTyp.options[InsrTyp.selectedIndex].text;

            var CloseDate = document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").value.trim();
            var opengDate = document.getElementById("<%=txtOpngDate_INSRNC.ClientID%>").value.trim();
            var Amount = document.getElementById("<%=txtAmount_INSRNC.ClientID%>").value.trim();
            var Currency = document.getElementById("<%=ddlCurrency_INSRNC.ClientID%>");
            var CurrencyText = Currency.options[Currency.selectedIndex].text;
            var Validity = document.getElementById("<%=txtValidity_INSRNC.ClientID%>").value.trim();

            var ddlExistEmp = document.getElementById("<%=ddlExistingEmp_INSRNC.ClientID%>");
            var ddlExistEmpText = ddlExistEmp.options[ddlExistEmp.selectedIndex].value;

            var ddlTemplate_INSRNC = document.getElementById("<%=ddlTemplate_INSRNC.ClientID%>");
            var ddlTemplate_INSRNCText = ddlTemplate_INSRNC.options[ddlTemplate_INSRNC.selectedIndex].value;

            var ContactEmail = document.getElementById("<%=txtCntctMail_INSRNC.ClientID%>").value;
            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

            document.getElementById('divMessageArea').style.display = "none";
            document.getElementById('imgMessageArea').src = "";


            var tbClientImageValidation = localStorage.getItem("tbClientImageValidation_INSRNC");//Retrieve the stored data

            tbClientImageValidation = JSON.parse(tbClientImageValidation); //Converts string to object

            if (tbClientImageValidation == null) //If there is no data, initialize an empty array
                tbClientImageValidation = [];

            for (var i = 0; i < tbClientImageValidation.length; i++) {

                var rowid = tbClientImageValidation[i];
                rowid = rowid.split(":");
                rowid = rowid[1];
                rowid = rowid.replace(/"/g, "");
                rowid = rowid.replace(/}/g, "");

                if (CheckValidation_INSRNC(rowid)) {

                    ret = true;

                }
                else {
                    ret = false;
                    break;
                }

            }

            if (ContactEmail != "") {
                if (!filter.test(ContactEmail)) {

                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please enter a valid email address.";
                    document.getElementById("<%=txtCntctMail_INSRNC.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtCntctMail_INSRNC.ClientID%>").focus();
                    ret = false;
                }
                else {

                    document.getElementById("<%=txtCntctMail_INSRNC.ClientID%>").style.borderColor = "";
                }
            }


            if (ddlTemplate_INSRNCText == "--SELECT TEMPLATE--") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlTemplate_INSRNC.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlTemplate_INSRNC.ClientID%>").focus();
                ret = false;
            }

            if (document.getElementById("<%=radioLimited_INSRNC.ClientID%>").checked == true) {

                if (CloseDate == "") {

                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").focus();
                    ret = false;
                }

                else {

                    var presentdate = document.getElementById("<%=hiddenCurrentDate_INSRNC.ClientID%>").value;
                    var arrpresentdate = presentdate.split("-");
                    var datepresentdate = new Date(arrpresentdate[2], arrpresentdate[1] - 1, arrpresentdate[0]);

                    document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").style.borderColor = "";
                    var TaskdatepickerDate = document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").value;
                    var arrDatePickerDate = TaskdatepickerDate.split("-");
                    var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                    var arrCurrentDate = opengDate.split("-");
                    var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);
                    if (dateDateCntrlr < dateCurrentDate) {
                        document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtPrjctClsngDate_INSRNC.ClientID%>").focus();
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, expiry date should be greater than insurance date !";
                        ret = false;

                    }

                    if (dateDateCntrlr < datepresentdate) {

                        if (confirm("Insurance has been already expired. Are you sure you want to continue?")) {

                        }
                        else {
                            ret = false;
                        }
                    }
                }
            }

            if (opengDate == "") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtOpngDate_INSRNC.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtOpngDate_INSRNC.ClientID%>").focus();
                ret = false;
            }
            else {

                document.getElementById("<%=txtOpngDate_INSRNC.ClientID%>").style.borderColor = "";
            }

            if (CurrencyText == "--SELECT CURRENCY--") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlCurrency_INSRNC.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlCurrency_INSRNC.ClientID%>").focus();
                ret = false;
            }
            else {
                document.getElementById("<%=ddlCurrency_INSRNC.ClientID%>").style.borderColor = "";
            }
            if (Amount == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtAmount_INSRNC.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtAmount_INSRNC.ClientID%>").focus();
                ret = false;
            }
            else {

                document.getElementById("<%=txtAmount_INSRNC.ClientID%>").style.borderColor = "";
            }

            var IsValidInput = validateUserInputData_INSRNC();

            if (IsValidInput == false) {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";

                ret = false;
            }

            if (InsuranceNo == "") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtInsuranceno.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtInsuranceno.ClientID%>").focus();
                ret = false;
            }
            else {
                document.getElementById("<%=txtInsuranceno.ClientID%>").style.borderColor = "";
            }

            if (InsrPrvdrText == "--SELECT INSURANCE PROVIDER--") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                //document.getElementById("<%=ddlInsurncPrvdr.ClientID%>").style.borderColor = "Red";
                //document.getElementById("<%=ddlInsurncPrvdr.ClientID%>").focus();

                $noCon("div#divddlInsurncPrvdr input.ui-autocomplete-input").css("borderColor", "red");
                $noCon("div#divddlInsurncPrvdr input.ui-autocomplete-input").focus();
                $noCon("div#divddlInsurncPrvdr input.ui-autocomplete-input").select();
                ret = false;
            }

            if (InsrTypText == "--SELECT INSURANCE TYPE--") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                $noCon("div#divddlInsurancType input.ui-autocomplete-input").css("borderColor", "red");
                $noCon("div#divddlInsurancType input.ui-autocomplete-input").focus();
                $noCon("div#divddlInsurancType input.ui-autocomplete-input").select();
                ret = false;
              }

            var Count = document.getElementById("<%=hiddenTemplateCount_INSRNC.ClientID%>").value;

            var TotalValue = "";
            var DeletedValue = "";
            for (intCount = 1; intCount <= Count; intCount++) {

                if (localStorage.getItem("tbClientTemplateUpload_INSRNC_" + intCount) != null && localStorage.getItem("tbClientTemplateUpload_INSRNC_" + intCount) != "[]") {

                    document.getElementById('divEachTemplate_INSRNC_' + intCount).style.border = "1px dotted";
                    document.getElementById('divEachTemplate_INSRNC_' + intCount).style.borderColor = "green";

                    TotalValue = TotalValue + "!" + localStorage.getItem("tbClientTemplateUpload_INSRNC_" + intCount);
                    DeletedValue = DeletedValue + "!" + localStorage.getItem("tbClientTemplateUploadDelete_INSRNC_" + intCount);

                }
                else {
                    document.getElementById('divEachTemplate_INSRNC_' + intCount).style.border = "2px dotted";
                    document.getElementById('divEachTemplate_INSRNC_' + intCount).style.borderColor = "red";



                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    CheckSubmitZero_INSRNC();
                    return false;
                }

                document.getElementById("txtDuration_INSRNC_" + intCount).style.borderColor = "";
                if (document.getElementById("txtDuration_INSRNC_" + intCount).value == "") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("txtDuration_INSRNC_" + intCount).style.borderColor = "red";
                    CheckSubmitZero_INSRNC();
                    return false;
                }
            }

            document.getElementById("<%=hiddenEachSliceData_INSRNC.ClientID%>").value = TotalValue;
            document.getElementById("<%=hiddenDeleteSliceData_INSRNC.ClientID%>").value = DeletedValue;


            if (ret == false) {
                CheckSubmitZero_INSRNC();

            }
            if (ret == true) {

                document.getElementById("<%=hiddenDivisionddlData_INSRNC.ClientID%>").value = 0;
                document.getElementById("<%=hiddenDesignationddlData_INSRNC.ClientID%>").value = 0;
                document.getElementById("<%=hiddenEmployeeDdlData_INSRNC.ClientID%>").value = 0;

                clearhidd();
            }

            $(window).scrollTop(0);
            return ret;
        }
        //evm-0023 end


        function validateUserInputData_INSRNC() {

            ret = true;

            var NameWithoutReplace = document.getElementById("<%=txtAmount_INSRNC.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var AmountText = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAmount_INSRNC.ClientID%>").value = AmountText;

          
            if (document.getElementById("<%=cbxPrjct_INSRNC.ClientID%>").checked == true) {

                $noCon("div#divProjectsDdl_INSRNC input.ui-autocomplete-input").css("borderColor", "");

                var DdlProject = document.getElementById("<%=ddlProjects_INSRNC.ClientID%>");
                var DdlProjectText = DdlProject.options[DdlProject.selectedIndex].text;

                if (DdlProjectText == "--SELECT PROJECT--") {
                    $noCon("div#divProjectsDdl_INSRNC input.ui-autocomplete-input").css("borderColor", "red");
                    ret = false;
                }

                if (AmountText <= 0) {
                    document.getElementById("<%=txtAmount_INSRNC.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (document.getElementById("<%=txtAmount_INSRNC.ClientID%>").value != 1) {
                    if (AmountText <= 0) {
                        document.getElementById("<%=txtAmount_INSRNC.ClientID%>").focus();
                    }
                    if (DdlProjectText == "--SELECT PROJECT--") {
                        $noCon("div#divProjectsDdl_INSRNC input.ui-autocomplete-input").focus();
                        $noCon("div#divProjectsDdl_INSRNC input.ui-autocomplete-input").select();
                    }
                }

            }
            else {

                document.getElementById("<%=txtPrjctName_INSRNC.ClientID%>").style.borderColor = "";

                var prjctName = document.getElementById("<%=txtPrjctName_INSRNC.ClientID%>").value;

                if (prjctName == "") {
                    document.getElementById("<%=txtPrjctName_INSRNC.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }

                if (AmountText <= 0) {
                    document.getElementById("<%=txtAmount_INSRNC.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (document.getElementById("<%=txtAmount_INSRNC.ClientID%>").value != 1) {
                    if (AmountText <= 0) {
                        document.getElementById("<%=txtAmount_INSRNC.ClientID%>").focus();
                    }
                    if (prjctName == "") {
                        document.getElementById("<%=txtPrjctName_INSRNC.ClientID%>").focus();
                    }
                }

            }

            return ret;
        }


        function ConfirmAlert_INSRNC() {
            var chck = Validate_INSRNC();

            if (chck == true) {

                if (confirm("Are you sure you want to confirm?")) {
                    return true;
                }
                else {

                    CheckSubmitZero_INSRNC();
                    return false;
                }
            } else {

                CheckSubmitZero_INSRNC();
                return false;
            }

        }

        function ConfirmReOpen_INSRNC() {

            if (confirm("Are you sure you want to reopen?")) {
                document.getElementById("<%=hiddenDivisionddlData_INSRNC.ClientID%>").value = 0;
                document.getElementById("<%=hiddenDesignationddlData_INSRNC.ClientID%>").value = 0;
                document.getElementById("<%=hiddenEmployeeDdlData_INSRNC.ClientID%>").value = 0;

                clearhidd();

                return true;
            }
            else {

                CheckSubmitZero_INSRNC();
                return false;
            }

        }

        function Alertrenew_INSRNC() {
            if (confirm("Are you sure you want renew the insurance?")) {
                var ret = Validate_INSRNC();

                if (ret == true) {
                    return true;
                }
                else
                    return false;
            }
            else {
                return false;
            }
        }

        function closeWindow_INSRNC() {
            window.close();
        }

        function SuccessGuaranteeRenewed_INSRNC() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance details renewed successfully.";
        }
        function SuccessUpdation_INSRNC() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance details updated successfully.";
         }
         function SuccessConfirmation_INSRNC() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance details inserted successfully.";
         }
         function SuccessReOpen_INSRNC() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance details reopened successfully.";
         }
         function SuccessConfirm_INSRNC() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance details confirmed successfully.";
         }
         function StsChkClsRenew_INSRNC() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Renew denied.This insurance is already closed.";
         }
         function StsChkReopnRenew_INSRNC() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Renew Denied.This insurance is already reopened.";
         }
        function Duplication_INSRNC() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error!. Insurance number can’t be duplicated.";
            document.getElementById("<%=txtInsuranceno.ClientID%>").style.borderColor = "Red";
            if (document.getElementById("<%=radioLimited_INSRNC.ClientID%>").checked == true) {
                document.getElementById("<%=HiddenDuplictnchk_INSRNC.ClientID%>").value = "1";
                TextDateChange_INSRNC();
            }
        }
        function StatusCheck_INSRNC() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Confirm denied.This insurance is already confirmed.";
        }

        function StatusCheckReopn_INSRNC() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Reopen denied.This insurance is already reopened.";
        }
        function StatusCheckClsReopn_INSRNC() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Reopen denied.This insurance is already closed.";
        }


        function cancelClickclearhidd_INSRNC() {


            if (confirmbox_INSRNC > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href = "gen_Bank_Guarantee.aspx";
                    clearhidd_INSRNC();
                    clearhidden_INSRNC();
                    clearhiddenTemp_INSRNC();

                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                // window.location.href = "gen_Bank_Guarantee.aspx";
                clearhidd_INSRNC();
                clearhidden_INSRNC();
                clearhiddenTemp_INSRNC();
                return true;
            }
            return false;


        }

        function clearhiddenTemp_INSRNC() {

            clearhidd();

            IncrmntConfrmCounter_INSRNC();
            document.getElementById("<%=hiddenDivisionddlData_INSRNC.ClientID%>").value = 0;
            document.getElementById("<%=hiddenDesignationddlData_INSRNC.ClientID%>").value = 0;
            document.getElementById("<%=hiddenEmployeeDdlData_INSRNC.ClientID%>").value = 0;
            return ret;
        }

        function clearhidden_INSRNC() {

            clearhidd();

            IncrmntConfrmCounter_INSRNC();
            document.getElementById("<%=hiddenDivisionddlData_INSRNC.ClientID%>").value = 0;
            document.getElementById("<%=hiddenDesignationddlData_INSRNC.ClientID%>").value = 0;
            document.getElementById("<%=hiddenEmployeeDdlData_INSRNC.ClientID%>").value = 0;
            document.getElementById("<%=hiddenTemplateChange_INSRNC.ClientID%>").value = "CHANGED";
            InitialiseCount_INSRNC();
            return true;
        }

        function AlertClearAll_INSRNC() {
            if (confirmbox_INSRNC > 0) {
                if (confirm("Are you sure you want clear all data in this page?")) {
                    window.location.href = "gen_Bank_Guarantee.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_Bank_Guarantee.aspx";
                return false;
            }
        }

        var submit = 0;
        function CheckIsRepeat_INSRNC() {
            if (++submit > 1) {

                return false;
            }
            else {
                return true;
            }
        }
        function CheckSubmitZero_INSRNC() {
            submit = 0;
        }

        function AmountChecking_INSRNC(textboxid) {
            var txtPerVal = document.getElementById(textboxid).value;

            txtPerVal = txtPerVal.replace(/,/g, "");

            if (txtPerVal == "") {
                return false;
            }
            else {
                if (!isNaN(txtPerVal) == false) {
                    document.getElementById('' + textboxid + '').value = "";
                    return false;
                }
                else {
                    if (txtPerVal < 0) {
                        document.getElementById('' + textboxid + '').value = "";
                        return false;
                    }
                    var amt = parseFloat(txtPerVal);
                    var num = amt;
                    var n = 0;
                    // for floatting number adjustment from corp global
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount_INSRNC.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);
                    }
                    document.getElementById('' + textboxid + '').value = n;

                }
            }

            addCommas_INSRNC();
        }

        function RemoveTag(obj) {

            var txt = document.getElementById(obj).value.trim();
            var replaceText1 = txt.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(obj).value = replaceText2;
        }

        function isNumber_INSRNC(evt, textboxid) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            var txtPerVal = document.getElementById(textboxid).value;
            //enter
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
                // . period and numpad . period
            else if (keyCodes == 190 || keyCodes == 110) {
                var ret = true;
                if (textboxid == "cphMain_txtAmount_INSRNC") {
                    var count = txtPerVal.split('.').length - 1;

                    if (count > 0) {

                        ret = false;
                    }
                    else {
                        ret = true;
                    }
                    return ret;
                }
                else {
                    return false;
                }

            }

            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                }
                return ret;
            }
        }

        function ChangeDivDisplays() {

            document.getElementById("<%=hiddenPolicyChange.ClientID%>").value = "1";

            if (document.getElementById("<%=ddlPolicyType.ClientID%>").value == 1) {

                document.getElementById("<%=divGuaranteeMaster.ClientID%>").style.display = "block";
                document.getElementById("<%=divInsuranceMaster.ClientID%>").style.display = "none";

                document.getElementById("divFullPolicy").style.display = "block";

                if (document.getElementById("<%=hiddenAddPage.ClientID%>").value == "1") {
                    document.getElementById("<%=lblEntry.ClientID%>").innerHTML = "Add Bank Guarantee";
                }

                

                document.getElementById("<%=ddlPolicyType.ClientID%>").focus();
                
            }
            else if (document.getElementById("<%=ddlPolicyType.ClientID%>").value == 2) {

                document.getElementById("<%=divGuaranteeMaster.ClientID%>").style.display = "none";
                document.getElementById("<%=divInsuranceMaster.ClientID%>").style.display = "block";

                document.getElementById("divFullPolicy").style.display = "block";

                if (document.getElementById("<%=hiddenAddPage.ClientID%>").value == "1") {
                    document.getElementById("<%=lblEntry.ClientID%>").innerHTML = "Add Insurance";
                }

                

                document.getElementById("<%=ddlPolicyType.ClientID%>").focus();
            }
            else {

                document.getElementById("<%=divGuaranteeMaster.ClientID%>").style.display = "none";
                document.getElementById("<%=divInsuranceMaster.ClientID%>").style.display = "none";

                document.getElementById("divFullPolicy").style.display = "none";

            }

            document.getElementById("freezelayer").style.display = "none";
            document.getElementById('MymodalCancelView').style.display = "none";

            document.getElementById("<%=ddlPolicyType.ClientID%>").focus();
        }

        function CbxChangeProject() {

            IncrmntConfrmCounter();
            if (document.getElementById("<%=cbxPrjct.ClientID%>").checked == true) {
                document.getElementById("divSelectProjct").style.display = "";
                document.getElementById("divNewPrjct").style.display = "none";
                $au('#cphMain_ddlProjects').selectToAutocomplete1Letter();
            }
            else {
                document.getElementById("divNewPrjct").style.display = "";
                document.getElementById("divSelectProjct").style.display = "none";
                //document.getElementById("<%=txtPrjctName.ClientID%>").value = "";
            }
        }

        function CbxChangeProject_INSRNC() {

            IncrmntConfrmCounter_INSRNC();
            if (document.getElementById("<%=cbxPrjct_INSRNC.ClientID%>").checked == true) {
                document.getElementById("divSelectProjct_INSRNC").style.display = "";
                document.getElementById("divNewPrjct_INSRNC").style.display = "none";
                $au('#cphMain_ddlProjects_INSRNC').selectToAutocomplete1Letter();
            }
            else {
                document.getElementById("divNewPrjct_INSRNC").style.display = "";
                document.getElementById("divSelectProjct_INSRNC").style.display = "none";
                //document.getElementById("<%=txtPrjctName_INSRNC.ClientID%>").value = "";
            }
        }
        

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
        <asp:HiddenField ID="HiddenOwnership" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenNewCustId" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenDup" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenCustomerFocus" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenRsnid" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenRoleReOpen" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenRoleConfirm" runat="server" Value="0" />
            <asp:HiddenField ID="hiddenRoleAdd" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenRoleClose" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenCurrentDate" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" Value="0" />
       <asp:HiddenField ID="hiddenConfirmOrNot" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" Value="0" />
         <asp:HiddenField ID="HiddenField2_FileUploadLnk" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenField2_FileUpload" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenValueChangeNtfr" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFileCanclDtlId" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenFieldPrevValueChk" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFieldRefNumber" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenFieldUserId" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenAttchmntSlNumber" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenFilePath" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenBankGuarenteeId" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldValidation" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldCurrcy" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldCustmor" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldMode" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenEditAttchmnt" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldChckUpdate" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldRefNumber2" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldviewchck" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenSubContractSlct" runat="server" Value="0" />
       <asp:HiddenField ID="HiddenFieldPRJCTID" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldSuplier" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldClient" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenGuarStatus" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenRenew" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenTextValidty" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenSearchField" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldRequestCltId" runat="server" Value="0" />
   <asp:HiddenField ID="HiddenFieldAmount" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenImportaddchk" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenOrgansId" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenCorpId" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenUserId" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenDuplictnchk" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenDeleteSliceData" runat="server" Value="0" />
   <asp:HiddenField ID="hiddenTemplateLoadingMode" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenTemplateChange" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenExpireDate" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenValidatedays" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenRFGImportedGtee" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenFieldGuarntId" runat="server" Value="0" />
      <asp:HiddenField ID="HiddenGurntNumDupChk" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenNewProjectId" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenRoleAddProjct" runat="server" Value="0" />
      <asp:HiddenField ID="HiddenProjctsave" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenNewContractId" runat="server" Value="0" />


      <asp:HiddenField ID="hiddenDecimalCount_INSRNC" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenRoleReOpen_INSRNC" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenRoleConfirm_INSRNC" runat="server" Value="0" />
            <asp:HiddenField ID="hiddenRoleAdd_INSRNC" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenCurrentDate_INSRNC" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId_INSRNC" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenCurrencyModeId_INSRNC" runat="server" Value="0" />
         <asp:HiddenField ID="HiddenField2_FileUploadLnk_INSRNC" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenField2_FileUpload_INSRNC" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFileCanclDtlId_INSRNC" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenFieldPrevValueChk_INSRNC" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenAttchmntSlNumber_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenFilePath_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenInsuranceId" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldValidation_INSRNC" runat="server" Value="0" />
      <asp:HiddenField ID="hiddenEditAttchmnt_INSRNC" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldUpdate_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldView_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenStatus" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenRenew_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenTextValidty_INSRNC" runat="server" Value="0" />
   <asp:HiddenField ID="HiddenFieldAmount_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenOrgansId_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenCorpId_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenDuplictnchk_INSRNC" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenDeleteSliceData_INSRNC" runat="server" Value="0" />
   <asp:HiddenField ID="hiddenTemplateLoadingMode_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenTemplateChange_INSRNC" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenValidatedays_INSRNC" runat="server" Value="0" />
      <asp:HiddenField ID="HiddenGurntNumDupChk_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenNewProjectId_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenRoleAddProjct_INSRNC" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenduplic_INSRNC" runat="server" Value="0" />

    <asp:HiddenField ID="hiddenPolicyChange" runat="server" Value="0" />

    <asp:HiddenField ID="hiddenAddPage" runat="server" Value="0" />


    <div class="cont_rght">
        
        <div id="divMessageArea" style="display: none; margin: 0px 0 13px;">
            <img id="imgMessageArea" src="">
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 0%; top: 22%; height: 26.5px;">
        </div>


            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>


        <div class="fillform">

             <div class="eachform" style="width: 100%; float: left; margin-top: 1%;">
                    <h2 style="width:20%;">Policy Type*</h2>
                      <div style="width: 80%;float: left;">
                         <asp:DropDownList ID="ddlPolicyType" class="form1" Style="float: right; width: 77.8% !important; margin-right: 14%;" runat="server" onchange="ChangeDivDisplays()">
                           <asp:ListItem Value="1">BANK GUARANTEE</asp:ListItem>
                           <asp:ListItem Value="2">INSURANCE</asp:ListItem>
                         </asp:DropDownList>
                      </div>
            </div>

        </div>

       <div id="divFullPolicy" class="fillform" style="width: 100%;display:none;">

                     <%---------------------GUARANTEE------------------------%>


             <div id="divGuaranteeMaster" runat="server" class="GreySection" style="display:none;background-color: #efefef;border: 1px solid;border-color: #cfcfcf;padding: 15px;height:1700px; ">
               
                <div id="divImage" style="float: right;margin-right:3%;margin-top:-7%">
                       
                        <asp:ImageButton ID="imgbtnReOpen" runat="server" OnClientClick="return ConfirmReOpen();" Style="margin-left: 0%;" OnClick="imgbtnReOpen_Click" />
                         <p id="imgReOpen" class="imgDescription" style="color: white">ReOpen Confirmed Entry</p>
                    </div>

<%--                <div class="eachform" style="width: 49%; float: left; margin-top: 3.8%;">--%>
                     <%-- <h2 style="margin-left: 8%;margin-top:8%">Guarantee Type *</h2>--%>

                    <div id="GuarTypeContainer" runat="server" style="margin-top: 3.8%;float:left;width:22%;height: 247px;/*! margin-right: 0%; */">
                       
                        <div style="width:56%;float:left;margin-left: 18%;">
                        <img src="/Images/Icons/Client_Guarantee.png" alt="X" style="margin-left: 29%; margin-top: 0%; float:left"/>
                            <div style="width:182%;float:left" >
                          <input id="radioClient" type="radio" runat="server" name="radType"  onchange="RadioClientClick()" onkeypress="return DisableEnter(event)"/>
                                <label style="font-family:Calibri" for="cphMain_radioClient">Client Guarantee</label>
                            </div>
                           </div>
                            <br />
                        <div style="width:60%;/*! float:left; */margin-left: 18%;margin-top: 37%;">
                          <img src="/Images/Icons/Suplier_Guarantee.png" alt="X" style="margin-left: 27%; margin-top: 0%;"/>
                       <div style="width:200%;float:left">
                          <input id="radioSuplier" type="radio" runat="server" name="radType" onchange="RadioSupplierClick()"  onkeypress="return DisableEnter(event)" />
                                <label style="font-family:Calibri" for="cphMain_radioSuplier">Supplier Guarantee</label>
                            </div>
                                                 
                        </div>
                       
                    </div>
               <%-- </div>--%>
              <div class="eachform" style="width: 29%; float: right; margin-top:3.8%;height: 163px;">
                  <div id="divimg" style="width:26%;float:right;margin-right: 14%;margin-top: 0%;">
                          <img id="imgImport" src="/Images/Icons/Import_Guarantee.png" alt="X" onclick="OpenImport();" style="margin-left: 5%; margin-top: 0%; width: 90%;cursor:pointer"/>
                      <%-- <p id="P1" class="imgDescription" style="color: white">Import RFG</p>--%>
                      <p id="ImportrfgLabel" style="margin-left: -11px; width: 118px; font-family: Calibri;"> IMPORT REQUEST FOR GUARANTEE </p>
                      </div>
                   </div>


                    <div class="eachform" style="width: 49%; float: left; margin-top: 3%;">
                    <h2 style="margin-left: 8%">Ref*</h2>
                    
                    <asp:Label ID="LabelRefnum" class="form11" runat="server" Style="padding-top:2px; margin-right: 1.6%;font-family:Calibri;font-size:15px;background-color: #e3e3e3;width: 46.3%;overflow: hidden;"></asp:Label>
                        
                    
                </div>
              <asp:UpdatePanel ID="UpdatePanel1"  EnableViewState="true" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                  
                 <div class="eachform" style="width: 49%; float: left; margin-top: .5%;">
                    <h2 style="margin-left: 8%">Guarantee Mode*</h2>
                      <div id="DivGrntyTyplabl" style="/*! padding-top:2px; */ /*! margin-right: 15%; */width: 62%;float: right;">
                          <asp:DropDownList ID="ddlGteeType" runat="server" onchange="PostBackDdl();"  AutoPostBack="false" OnSelectedIndexChanged="ddlGteeType_SelectedIndexChanged" class="form1"  Style="float: left; width: 80.2% !important; margin-left: 17.5%;" autofocus="autofocus" autocorrect="off" autocomplete="off" ></asp:DropDownList>
                    <%--<asp:Label ID="lblGuarntMde" class="form11" runat="server" Style="padding-top:2px; margin-right: 2%;font-family:Calibri;font-size:15px;background-color: #e3e3e3;width: 75.5%;overflow: hidden;"></asp:Label>--%>
                          </div>
                      <div id="DivGrntyTypeDrpDwn" style="/*! padding-top:2px; */ /*! margin-right: 15%; */width: 62%;float: right;">
                         <asp:DropDownList ID="ddlGuarntyp" AutoPostBack="false"  class="form1" Style="float: left; width: 80.2% !important; margin-left: 17.5%;" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off" >
                                    </asp:DropDownList>
                          </div>
                </div>
                     
                 <div id="divProject" class="eachform" style="width: 49%; float: right; margin-top: .5%;">
                    <h2 style="margin-left: 8%">Guarantee No.*</h2>
                      <asp:TextBox ID="txtGuarnteno" class="form1" runat="server" MaxLength="90" onblur="return DuplctnGuarntNum();" Style="width: 47% !important; text-transform: uppercase; margin-right: 1%; height: 30px"></asp:TextBox>
                   
                </div>

              <div id="divGuaranteCat" class="eachform" style="width: 49%; float: Left;margin-top: .5%;">
                    <h2 style="margin-left: 8%">Bank*</h2>
                   
                    <asp:DropDownList ID="ddlBank" class="form1" Style="float: right; width: 46.9% !important; margin-right: 1%;" runat="server" AutoPostBack="false" autofocus="autofocus" autocorrect="off" autocomplete="off">
                    </asp:DropDownList>
                </div>
                  

                 <div id="divSubContract" class="eachform" style="width: 53%; float: left;margin-top:.5%">
                    <h2 style="margin-left: 8%">Sub-Contract*</h2>
                    
                    <asp:DropDownList ID="ddlSubContrct" AutoPostBack="true" class="form1" Style="float: left; width: 46.5% !important; margin-left: 21.1%;" runat="server"  onchange=" clearHiddenTemp();" OnSelectedIndexChanged="ddlSubContrct_SelectedIndexChanged"  autofocus="autofocus" autocorrect="off" autocomplete="off" onkeypress="return DisableEnter(event)">
                    </asp:DropDownList>
                     <%--//evm-0012 Adding Contracts--%>
                     <asp:Button ID="btnNewContract" runat="server" class="save" style="margin-left: -0.5%;  padding: 1%;border-radius: 0px;padding-bottom: 1.7%; padding-top:6px;float: left;height: 31px;" ToolTip="Add Contract" Text="+" OnClientClick="return NewContractLoad()" OnClick="btnNewContract_Click"/>
                </div>


                <div class="eachform" style="width: 53%; float: left;margin-top:.5%">
                  <h2 style="margin-left: 8%">Project* </h2>

                   <div id="divProjectsDdl" style="display:block;">

                    <div class="subform" style="width: 30%; margin-right: 25.5%; padding-top: 7px;">
                       <span>
                         <asp:CheckBox ID="cbxPrjct" Text="" runat="server" Checked="true" onchange="CbxChangeProject()" class="form2" onkeypress="return DisableEnter(event)" />
                         <label style="color: rgb(135, 146, 116); font-family: Calibri;" for="cphMain_cbxPrjct">Select Project</label>
                       </span>
                    </div>

                  <div id="divSelectProjct">
                    <asp:DropDownList ID="ddlProjects" AutoPostBack="false"  class="form1" Style="float: left; width: 43.4%; margin-left: 28%;" onchange="return PostBackProjectDdl();"   runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off" onkeypress="return DisableEnter(event)"></asp:DropDownList>
                     <asp:Button ID="btnNewProject" runat="server" class="save" style="margin-left: -0.5%;  padding: 1%;border-radius: 0px;padding-bottom: 1.7%; padding-top:6px;float: left;height: 33px;" ToolTip="Add Project" Text="+" OnClientClick="return NewProjectLoad()" OnClick="btnNewProject_Click"/>
                    </div>
                   <div id="divNewPrjct">
                         <asp:TextBox ID="txtPrjctName" class="form1" runat="server" MaxLength="90" onblur="RemoveTag(this)" Style="float: left; width: 43%; margin-left: 45.5%;" onkeypress="return DisableEnter(event)"></asp:TextBox>
                   </div>

                  </div>

                    <asp:Label ID="LblProject" class="form11" runat="server" Style="padding-top: 2px; margin-right: 8.11%; font-family: Calibri; font-size: 15px; width: 43.8%; background-color: rgb(227, 227, 227); overflow: hidden;"></asp:Label>
                     </div>
                   
                        <div class="eachform" style="width: 100%; float: left; margin-top: .5%;height: 130px;">
                          
                      <h2 style="margin-left: 26%;margin-top:3%;">Guarantee Category *</h2>

                    <div id="Div2" runat="server" style="float:right;width:23.5%;margin-right: 29.5%;padding: 6px;background-color: #e1e1e1;">
                       
                        <div style="width:49%;float:left;margin-left: 0%;">
                        <img src="/Images/Icons/Open_Guarantee.png" alt="X" style="margin-left: 33%; margin-top: 0%; /*! width: 90%; */float:left"/>
                            <div style="width:51%;float:left;margin-left: 25%;">
                          <input id="radioOpen" type="radio" runat="server" onchange="RadioopenClick()" name="radTypenxt" onkeypress="return DisableEnter(event)"  />
                                <label style="font-family:Calibri" for="cphMain_radioOpen">Open</label>
                            </div>

                        </div>
                        <div style="width:49%;float:left;margin-left: 0%;">
                          <img src="/Images/Icons/Closed_Guarantee.png" alt="X" style="margin-left: 21%; margin-top: 0%; /*! width: 90%; */"/>
                       <div style="width:59%;float:left;margin-left: 15%;">
                          <input id="radioLimited" type="radio" runat="server" onchange="RadioLimitedClick()" name="radTypenxt" onkeypress="return DisableEnter(event)" />
                                <label style="font-family:Calibri" for="cphMain_radioLimited">Limited</label>
                            </div>
                            
                      </div>
                      
                    </div>
                           
                </div>
                        
                 <div class="eachform" style="width: 49%; float: left;margin-top:1%">
                  <h2 style="margin-left: 8%">Amount * </h2>
                    <asp:TextBox ID="txtAmount" class="form1" runat="server" MaxLength="12" Style="width: 47%; text-transform: uppercase;text-align:right; margin-right: 8%; height: 30px" onkeydown="return isNumber(event,'cphMain_txtAmount');" onkeyup="addCommas()" onblur="AmountChecking('cphMain_txtAmount');"></asp:TextBox>
                </div>
                 <div id="divCurrency" class="eachform" style="width: 49%; float: right; margin-top: 1%;">
                    <h2 style="margin-left: 10%">Currency *</h2>
                      <div id="CurrencyLabl"  style="/*! padding-top:2px; */ /*! margin-right: 15%; */width: 62%;float: right;">
                    <%--<asp:Label ID="currcyLabl" class="form11" runat="server" Style="padding-top:4px; margin-right: 14%; font-family:Calibri;font-size:15px;width: 72.5%;background-color: #e3e3e3;"></asp:Label>--%>
                          </div>
                      <div id="Currencyddl" style="/*! padding-top:2px; */ /*! margin-right: 15%; */width: 62%;float: right;">
                         <asp:DropDownList ID="ddlCurrency" class="form1" Style="float: right; width: 77.8% !important; margin-right: 14%;" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                    </asp:DropDownList>
                          </div>
                   
                </div>
               
                <div class="eachform" style="width: 52%; float: left;">
                 <h2 style="margin-left: 7.6%;float:left">Date*</h2>
                        <div id="Div3" class="input-append date" style="font-family:Calibri;float:right;width:50%;margin-right:7%;margin-top: 1%;">
                 <asp:TextBox ID="txtOpngDate" class="textDate form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onblur="return TextDateChange()" Style="width:44.8%;height:27px; font-family: calibri;float: left;margin-left: -7%;" ></asp:TextBox>

                        <input type="image" id= "img2" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return TextDateChange()" style=" height:19px;float:left; width:12px; cursor:pointer;" />

                   <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
                   <script src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
                   <script src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
                   <script src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
                   <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                   <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                        <script type="text/javascript">
                            var $noC2 = jQuery.noConflict();
                            $noC2('#Div3').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //startDate: new Date(),


                            });
                            function FocusDate() {

                                $noC2('#Div3').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    // startDate: new Date(),


                                });
                            }
                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>
                  <asp:TextBox ID="txtValidity" class="form1" placeholder="No. Of Days" runat="server"  MaxLength="8"  Style="width: 7%;text-align:right; text-transform: uppercase; /*! margin-right: 1.7%; */ height: 29px;float:left;margin-left: -15.5%;margin-top: 4px;"></asp:TextBox>
                  

                 <div id="divProjectClosingDate" class="eachform" runat="server" style="width: 48%;float:right">
                 <h2 id="Project_Closing_Date" style="font-size:17px;margin-left:8%" runat="server">Expiry Date*</h2>
               <div id="ClosingDate" class="input-append date" style="font-family:Calibri;float:right;width:52%;margin-right:6%;margin-top: 1%;">
                 <asp:TextBox ID="txtPrjctClsngDate" class="textDate form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onblur="return TextDateChange()" Style="width:78.8%;height:27px; font-family: calibri;float: left;" ></asp:TextBox>

                        <input type="image" id="img1" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return TextDateChange()" style=" height:19px;float:left; width:12px; cursor:pointer;" />

                   <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
                   <script src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
                   <script src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
                   <script src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
                   <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                   <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                        <script type="text/javascript">
                            var $noC2 = jQuery.noConflict();
                            $noC2('#ClosingDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                               // startDate: new Date(),


                            });
                            function FocusOnDate() {

                                $noC2('#ClosingDate').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                  //  startDate: new Date(),


                                });
                            }
                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>
                          

                <div class="eachform" style="width: 49%; float: left;margin-top:1%">
                  <h2 id="h2cuscontractr" style="margin-left: 8%">Customer* </h2>
                   <asp:Label ID="LabelCustmrContrctr" class="form11" runat="server" Style="padding-top:4px; margin-right: 8%; font-family:Calibri;font-size:15px;width: 47%;background-color: #e3e3e3;overflow: hidden;"></asp:Label>
                  
                <asp:DropDownList id="ddlCustomerList" onblur="clearhidd()" class="form1" Style="float: right; width: 50% !important; margin-right: 8%;" runat="server" OnChange="CustomerOnchange()" autofocus="autofocus" autocorrect="off" autocomplete="off" >
                    </asp:DropDownList>
                   
                 
                </div>
                 <div id="divOwnership" class="eachform" style="width: 49%; float: right; margin-top: 1%;">
                    <h2 style="margin-left: 10%">Ownership</h2>
                     
                     
                         <asp:DropDownList ID="ddlOwnershp" AutoPostBack="false" class="form1" Style="float: right; width: 45% !important; margin-right: 8.5%;" runat="server"   autofocus="autofocus" autocorrect="off" autocomplete="off">
                    </asp:DropDownList>
                          
                   
                </div>

                 <div class="eachform" style="width: 52%; float: left;margin-top:0.5%">
                  <h2 style="margin-left: 7.8%">Address*</h2>
                    <asp:TextBox ID="txtadress" class="form1" runat="server" TextMode="MultiLine" MaxLength="950" onkeydown="textCounter(cphMain_txtadress,950)" onkeyup="textCounter(cphMain_txtadress,950)" Style="resize:none; width: 45%;height:100px;font-family:Calibri; margin-right: 13%;"></asp:TextBox>
                </div>
                   
              
                <div class="eachform" style="width: 48%; float: left;margin-top:0.5%">
                  <h2 style="margin-left: 8%">Subject </h2>
                    <asp:TextBox ID="txtSubjct" class="form1" runat="server" TextMode="MultiLine" MaxLength="450" onkeydown="textCounter(cphMain_txtSubjct,450)" onkeyup="textCounter(cphMain_txtSubjct,450)" Style="resize:none; width: 46%;height:100px; text-transform: uppercase;font-family:Calibri; margin-right: 8.5%;"></asp:TextBox>
                </div>
                 <div class="eachform" style="width:100%; float: left;margin-top:0.5%">
                  <h2 style="margin-left: 4%">Description </h2>
                    <asp:TextBox ID="txtDescrptn" class="form1" runat="server" TextMode="MultiLine" MaxLength="950" onkeydown="textCounter(cphMain_txtDescrptn,1950)" onkeyup="textCounter(cphMain_txtDescrptn,950)" Style="resize:none; width: 74%;height:100px;font-family:Calibri; margin-right: 4%;"></asp:TextBox>
                </div>

                  <div class="eachform" style="width: 49%; float: left;margin-top:0%">
                   
                    <div class="subform" style="width: 30%; margin-right: 27.5%; padding-top: 7px;">
                        <span>
                        <asp:CheckBox ID="cbxExistingEmployee" Text="" runat="server" Checked="true" onchange="CbxChange()" class="form2" />
                         <label style="color: rgb(135, 146, 116); font-family: Calibri;" for="cphMain_cbxExistingCustomer">Select Employee</label>
                            </span>
                       

                    </div>
                </div>
                
                   
                        <div id="divContactPersn" class="eachform" style="width: 52%; float: left">

                            <h2 style="margin-left: 7.6%">Contact Person </h2>
                            <div style="width: 57.5%; float: right;">
                                <div id="divNewEmp">
                                    <asp:TextBox ID="txtEmpName" class="form1" runat="server" MaxLength="45" onblur="RemoveTag(this)" Style="float: left; width: 80%!important; margin-left: -5.5%; text-transform: uppercase;"></asp:TextBox>
                                  
                                     </div>

                                <div id="divExistingEmp">
                                    <%--<asp:DropDownList ID="ddlExistingEmp" AutoPostBack="true" TabIndex="20" class="form1"  Style="float: left; width: 83% !important; margin-left: -5.5%;" onclick="clearhidd()" onfocus="clearhidd()"  runat="server"  OnSelectedIndexChanged="ddlExistingEmp_SelectedIndexChanged" autofocus="autofocus" autocorrect="off" autocomplete="off"  >
                                    </asp:DropDownList>--%>
                                    <asp:DropDownList ID="ddlExistingEmp" class="form1"  Style="float: left; width: 83% !important; margin-left: -5.5%;" runat="server" OnChange="ddlExistEmpChange()" autofocus="autofocus" autocorrect="off" autocomplete="off" >
                                    </asp:DropDownList>
                               </div>
                            </div>

                        </div>
                         <div class="eachform" style="width: 49%; float: right;margin-top:-3.5%">
                  <h2 style="margin-left:10%">Contact Person Email </h2>
                    <asp:TextBox ID="txtCntctMail" class="form1" runat="server" MaxLength="90" Style="width:45%; margin-right: 8%; height: 30px"></asp:TextBox>
                </div>
                       </ContentTemplate>
                     
                     </asp:UpdatePanel>
                 <div class="eachform" style="width:100%; float: left;margin-top:0.5%">
                  <h2 style="margin-left: 4%">Remarks </h2>
                    <asp:TextBox ID="txtRemarks" class="form1" runat="server" TextMode="MultiLine" MaxLength="950" onkeydown="textCounter(cphMain_txtRemarks,1950)" onkeyup="textCounter(cphMain_txtRemarks,950)" Style="resize:none; width: 74%;height:100px; font-family:Calibri; margin-right: 4%;"></asp:TextBox>
                </div>
               
                <div id="divfleupld" class="eachform"  style="width: 100%; float: left">

                            <h2  style="margin-left: 4%;margin-top: 3%;">Attachments </h2>
                  <div id="divfileupl" class="form-group"  style="margin-top: -4%;float: left;width: 73%; height: 97px;overflow: auto;margin-left: 20.5%;border: 1px solid rgb(207, 204, 204);font-family: Calibri;background-color: white;padding: 13px;">
                       <div id="divFileuploadScroll"  style="margin-top:1%;float:right;margin-right:2.5%; width:95.5%;max-height: 265px;overflow: auto;">
                        <table id="TableFileUploadContainer" style="width: 99%;">
                        </table>

                        <br />
               </div>
                 <div id="div1" style="margin-top:1%;float:right;margin-right:2.5%; width:65.5%;max-height: 265px;overflow: auto;">
                        <table id="Table1" style="width: 99%;">
                        </table>

                        <br />
               </div>   
                      </div> 
                    </div>
                <div  class="eachform"  style="display:none; width: 49%; float: left;margin-top:0.5%; ">
                 <label for="cphMain_FileUploadProPic" class="custom-file-upload">
                    <img src="../../Images/Icons/cloud_upload.jpg" />Upload File</label>

              

                <asp:FileUpload ID="FileUploadProPic" class="fileUpload"  runat="server" Style="height: 30px; display:none;" onchange="ClearDivDisplayImage()" Accept="image/png, image/gif, image/jpeg" />
                    <asp:Label ID="Label1" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
                    </div>


                    <asp:UpdatePanel ID="updPanelTempl" runat="server" EnableViewState="true" UpdateMode="Conditional">
                        <ContentTemplate>
                             <%--for notification template--%>
     <asp:HiddenField ID="hiddenTemplateCount" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenTemplateAlertData" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenEditMode" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenDivisionddlData" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenDesignationddlData" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenEmployeeDdlData" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenNotificationDuration" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenNotificationMOde" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenNotifyVia" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenEachTemplateDetail" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenEachSliceData" runat="server" Value="0" />
                        

                 <div class="eachform" style="width: 100%; float: left;margin-top:0%">
                   <h2 style="margin-left: 4%;margin-top: 2%;">Template* </h2>
                    <div class="subform" style="width: 52%; margin-right: 27.5%; padding-top: 7px;">
                      <div  style="float: left;width: 55%;margin-top: 2%;">
                         <asp:DropDownList ID="ddlTemplate" AutoPostBack="true" class="form1" Style=" width: 93% !important; margin-left: 0%;float: left;" runat="server" onchange="clearHidden()" OnSelectedIndexChanged="ddlTemplate_SelectedIndexChanged" autofocus="autofocus" autocorrect="off" autocomplete="off" >
                         </asp:DropDownList>
                        </div>
                        <div style="float: left;border: 1px solid;width: 67px;border-color: #6a8a32;background-color: #e0efee;">
                            <div style="width:100%;padding: 3px;float: left;">
                                <label style="font-family: calibri;font-size: 12px;color: #a50505;">Don't Notify</label>
                            </div>
                             <label for="cphMain_cbxDontNotify"><img src="/Images/Icons/DontNotify.png" style="margin-left: 8px;margin-bottom: 3px;" /></label>
                            <span>
                              <asp:CheckBox ID="cbxDontNotify" runat="server" onchange="CbxChange()" onkeypress="return DisableEnter(event)" />
                               
                            </span>
                        </div>
                    </div>
                </div>
                   

                 <div  class="eachform"  style="width: 95%; float: left;margin-top:2.5%; margin-left: 2.5%;background-color: white;">
                      <div id="DivTemplateContainer" style="width:86%;min-height:200px;padding: 25px;margin-top: 3%;background-color: #e0efee;margin-left: 4%;margin-bottom: 3%;" >
                    <table id="TableTemplateContainer" style="width: 100%;">
                    
                     </table>
                </div>


                 </div>
             </ContentTemplate>
                    </asp:UpdatePanel>



                 <%-- <div id="divJobCategory" class="eachform" style="width: 49%; float: left;margin-top:0.5%">
                    <h2 style="margin-left: 8%">Job Category</h2>
                    <asp:DropDownList ID="ddlJobCategory" TabIndex="15" class="form1" Style="float: right; width: 47%!important; margin-right: 7%;" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                    </asp:DropDownList>
                </div>--%>

             
                <div class="eachform" style="width: 99%; margin-top: 3%; float: left">
                    <div class="subform" style="width: 70%; margin-left: 38%">
                     <asp:Button ID="btnConfirm" runat="server" class="save" Text="Confirm" OnClick="btnConfirm_Click" OnClientClick="return ConfirmAlert();"/>
                     <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClientClick="return Validate();"  OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClientClick="return Validate();"  OnClick="btnUpdate_Click"  />
                    <asp:Button ID="btnAdd"  runat="server" class="save" Text="Save" OnClientClick="return Validate();"  OnClick="btnAdd_Click"/>
                    <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClientClick="return Validate();"  OnClick="btnAdd_Click"  />
                        <asp:Button ID="btnrenew" runat="server"  OnClientClick="return Alertrenew();" OnClick="btnrenew_Click" class="save" Text="Renew"/>   
                     <asp:Button ID="btnCancel"  runat="server" class="cancel" Text="Cancel" OnClick="btnCancel_Click" OnClientClick="cancelClickClearHidd();" />
                     <asp:Button ID="btnClear" runat="server" style="margin-left: 19px;" OnClientClick="return AlertClearAll();"  class="cancel" Text="Clear"/>
                      
               </div>
                    </div>

                 </div>


                    <%--<div id="divReport" class="table-responsive" runat="server">
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
        </div>--%>

                     <%-- <div id="div1" style="float: right;margin-right:3%;margin-top:-7%">
                       
                        <asp:ImageButton ID="imgBtnClose" class="tooltip" title="Close" TabIndex="22" runat="server" OnClientClick="return ConfirmClose();" Style="margin-left: 0%;opacity:1;position:relative"  />
                         
                    </div>--%>



                         <%---------------------INSURANCE------------------------%>

        <div id="divInsuranceMaster" runat="server" class="GreySection" style="display:none;background-color: #efefef;border: 1px solid;border-color: #cfcfcf;padding: 15px;height:1221px;">

                <div id="div4" style="float: right;margin-right:3%;margin-top:-7%">
                       <asp:ImageButton ID="imgbtnReOpen_INSRNC" runat="server" OnClientClick="return ConfirmReOpen_INSRNC();" src="/Images/Icons/Reopen.png" Style="margin-left: 0%;" OnClick="imgbtnReOpen_INSRNC_Click"  />
                       <p class="imgDescription" style="color: white">ReOpen Confirmed Entry</p>
                </div>


                <div class="eachform" style="width: 49%; float: left; margin-top: .5%;">
                    <h2 style="margin-left: 8%">Ref*</h2>
                    <asp:Label ID="LabelRefnum_INSRNC" class="form11" runat="server" Style="padding-top:2px; margin-right: 8%;font-family:Calibri;font-size:15px;background-color: #e3e3e3;width: 46%;overflow: hidden;"></asp:Label>   
                </div>


            <%--evm-0023 start--%>

               
              <div class="eachform" style="width: 49%; float: right;margin-top: .5%;">
                    <h2 style="margin-left: 10%">Insurance Type*</h2>
                   <div id="divddlInsurancType" >
                     <asp:DropDownList ID="ddlInsurncTyp" class="form1" Style="float: right; width: 43.4%; margin-right: 10%;" runat="server" AutoPostBack="false" autofocus="autofocus" autocorrect="off" autocomplete="off" onkeypress="return DisableEnter(event)">
                    </asp:DropDownList>
                   </div>
                   
              </div>

                 <div class="eachform" style="width: 49%; float: left; margin-top: .5%;">
                    <h2 style="margin-left: 8%">Insurance No.*</h2>       
                      <asp:TextBox ID="txtInsuranceno" class="form1" runat="server" MaxLength="90" Style="width: 46%; text-transform: uppercase; margin-right: 8%; height: 30px" onkeypress="return DisableEnter(event)"></asp:TextBox>
     
               </div>

               <div class="eachform" style="width: 49%; float: right;margin-top: .5%;">
                    <h2 style="margin-left: 10%">Insurance Provider*</h2>
                   <div id="divddlInsurncPrvdr" >
                     <asp:DropDownList ID="ddlInsurncPrvdr" class="form1" Style="float: right; width: 43.4%; margin-right: 10%;" runat="server" AutoPostBack="false" autofocus="autofocus" autocorrect="off" autocomplete="off" onkeypress="return DisableEnter(event)">
                    </asp:DropDownList>
                   </div>
                   
              </div>
                    
          

                <div class="eachform" style="width: 49%; float: left;margin-top:.5%">
                  <h2 style="margin-left: 8%">Project* </h2>

                    <div class="subform" style="width: 30%; margin-right: 27.5%; padding-top: 7px;">
                       <span>
                         <asp:CheckBox ID="cbxPrjct_INSRNC" Text="" runat="server" Checked="true" onchange="CbxChangeProject_INSRNC()" class="form2" onkeypress="return DisableEnter(event)"/>
                         <label style="color: rgb(135, 146, 116); font-family: Calibri;" for="cphMain_cbxPrjct_INSRNC">Select Project</label>
                       </span>
                    </div>


                   <div id="divProjectsDdl_INSRNC" style="display:block;">

                    <div id="divSelectProjct_INSRNC">
                      <asp:DropDownList ID="ddlProjects_INSRNC" AutoPostBack="false"  class="form1" Style="float: left; width: 43.4%; margin-left: 25%;"    runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off" onkeypress="return DisableEnter(event)"></asp:DropDownList>
                      <asp:Button ID="btnNewProject_INSRNC" runat="server" class="save" style="margin-left: -0.5%;  padding: 1%;border-radius: 0px;padding-bottom: 1.7%; padding-top:6px;float: left;height: 33px;" ToolTip="Add Project" Text="+" OnClientClick="return NewProjectLoad_INSRNC()" OnClick="btnNewProject_INSRNC_Click" />
                    </div>

                   <div id="divNewPrjct_INSRNC">
                         <asp:TextBox ID="txtPrjctName_INSRNC" class="form1" runat="server" MaxLength="90" onblur="RemoveTag(this)" Style="float: left; width: 43%; margin-left: 25%;  " onkeypress="return DisableEnter(event)"></asp:TextBox>
                   </div>
  
                  </div>
                 </div>
                   
                 <div class="eachform" style="width: 49%; float: right; margin-top: .5%;height: 100px;">     
                   <h2 style="margin-left: 10%;margin-top:3%;">Insurance Category*</h2>

                   <div id="Div5" runat="server" style="float:left;width:46%;margin-left: 8.5%;padding: 6px;background-color: #e1e1e1;">
                       
                      <div style="width:49%;float:left;margin-left: 0%;">
                        <img src="/Images/Icons/Open_Guarantee.png" alt="X" style="margin-left: 33%; margin-top: 0%; float:left"/>
                            <div style="width:51%;float:left;margin-left: 25%;">
                          <input id="radioOpen_INSRNC" type="radio" runat="server" onchange="radioOpen_INSRNCClick()" name="radTypenxt_INSRNC" onkeypress="return DisableEnter(event)"  />
                                <label style="font-family:Calibri" for="cphMain_radioOpen_INSRNC">Open</label>
                            </div>
                      </div>

                      <div style="width:49%;float:left;margin-left: 0%;">
                          <img src="/Images/Icons/Closed_Guarantee.png" alt="X" style="margin-left: 21%; margin-top: 0%; "/>
                            <div style="width:59%;float:left;margin-left: 15%;">
                             <input id="radioLimited_INSRNC" type="radio" runat="server" onchange="radioLimited_INSRNCClick()" name="radTypenxt_INSRNC" onkeypress="return DisableEnter(event)" />
                                <label style="font-family:Calibri" for="cphMain_radioLimited_INSRNC">Limited</label>
                            </div>
                      </div>
                      
                    </div>      
                </div>

            <%--evm-0023 end--%>
                        
                 <div class="eachform" style="width: 49%; float: left;margin-top:1%">
                  <h2 style="margin-left: 8%">Amount * </h2>
                    <asp:TextBox ID="txtAmount_INSRNC" class="form1" runat="server" MaxLength="12" Style="width: 47%; text-transform: uppercase;text-align:right; margin-right: 8%; height: 30px" onkeydown="return isNumber_INSRNC(event,'cphMain_txtAmount_INSRNC');" onkeyup="addCommas_INSRNC()" onblur="AmountChecking_INSRNC('cphMain_txtAmount_INSRNC');" onkeypress="return DisableEnter(event)"></asp:TextBox>
                </div>

                <div class="eachform" style="width: 49%; float: right; margin-top: 1%;">
                    <h2 style="margin-left: 10%">Currency *</h2>
                      <div style="width: 62%;float: right;">
                        </div>
                      <div style="width: 62%;float: right;">
                         <asp:DropDownList ID="ddlCurrency_INSRNC" class="form1" Style="float: right; width: 77.8% !important; margin-right: 14%;" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off" onkeypress="return DisableEnter(event)">
                           </asp:DropDownList>
                      </div>
                </div>
               
                <div class="eachform" style="width: 52%; float: left;">
                 <h2 style="margin-left: 7.6%;float:left">Date*</h2>

                   <div id="Div3_INSRNC" class="input-append date" style="font-family:Calibri;float:right;width:50%;margin-right:7%;margin-top: 1%;">
                      <asp:TextBox ID="txtOpngDate_INSRNC" class="textDate form1" onkeypress="return DisableEnter(event)" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onblur="return TextDateChange_INSRNC()" Style="width:44.8%;height:27px; font-family: calibri;float: left;margin-left: -7%;" ></asp:TextBox>
                      <input type="image" id= "img2_INSRNC" runat="server" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter_INSRNC()" onblur="return TextDateChange_INSRNC()" style=" height:19px;float:left; width:12px; cursor:pointer;" />

                   <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
                   <script src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
                   <script src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
                   <script src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
                   <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                   <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                        <script type="text/javascript">
                            $noC2('#Div3_INSRNC').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //startDate: new Date(),


                            });
                            function FocusDate_INSRNC() {

                                $noC2('#Div3_INSRNC').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    // startDate: new Date(),


                                });
                            }
                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>
                  <asp:TextBox ID="txtValidity_INSRNC" class="form1" placeholder="No. Of Days" runat="server"  MaxLength="8"  Style="width: 7%;text-align:right; text-transform: uppercase; height: 29px;float:left;margin-left: -15.5%;margin-top: 4px;"></asp:TextBox>
                  

              <div id="Div6" class="eachform" runat="server" style="width: 48%;float:right">
                 <h2 id="H1" style="font-size:17px;margin-left:8%" runat="server">Expiry Date*</h2>
                 
                  <div id="ClosingDate_INSRNC" class="input-append date" style="font-family:Calibri;float:right;width:52%;margin-right:6%;margin-top: 1%;">
                  
                      <asp:TextBox ID="txtPrjctClsngDate_INSRNC" class="textDate form1" placeholder="DD-MM-YYYY" onkeypress="return DisableEnter(event)" MaxLength="20" runat="server" onblur="return TextDateChange_INSRNC()" Style="width:78.8%;height:27px; font-family: calibri;float: left;" ></asp:TextBox>
                      <input type="image" id="img1_INSRNC" runat="server" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter_INSRNC()" onblur="return TextDateChange_INSRNC()" style=" height:19px;float:left; width:12px; cursor:pointer;" />

                   <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
                   <script src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
                   <script src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
                   <script src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
                   <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                   <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                        <script type="text/javascript">
                            $noC2('#ClosingDate_INSRNC').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                // startDate: new Date(),


                            });
                            function FocusOnDate_INSRNC() {

                                $noC2('#ClosingDate_INSRNC').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    //  startDate: new Date(),


                                });
                            }
                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>

               <div class="eachform" style="width:100%; float: left;margin-top:0.5%">
                  <h2 style="margin-left: 4%">Description </h2>
                    <asp:TextBox ID="txtDescrptn_INSRNC" class="form1" runat="server" TextMode="MultiLine" MaxLength="950" onkeydown="textCounter(cphMain_txtDescrptn_INSRNC,1950)" onkeyup="textCounter(cphMain_txtDescrptn_INSRNC,950)" Style="resize:none; width: 74%;height:100px;font-family:Calibri; margin-right: 4%;"></asp:TextBox>
               </div>

               <div class="eachform" style="width: 49%; float: left;margin-top:0%">
                   <div class="subform" style="width: 30%; margin-right: 27.5%; padding-top: 7px;">
                       <span>
                          <asp:CheckBox ID="cbxExistingEmployee_INSRNC" Text="" onkeypress="return DisableEnter(event)" runat="server" Checked="true" onchange="CbxChange_INSRNC()" class="form2" />
                          <label style="color: rgb(135, 146, 116); font-family: Calibri;" for="cbxExistingEmployee_INSRNC">Select Employee</label>
                       </span>
                   </div>
                </div>
                
                   
                 <div class="eachform" style="width: 52%; float: left">
                            <h2 style="margin-left: 7.6%">Contact Person </h2>
                            <div style="width: 57.5%; float: right;">
                                <div id="divNewEmp_INSRNC">
                                    <asp:TextBox ID="txtEmpName_INSRNC" class="form1" runat="server" MaxLength="45" onblur="RemoveTag(this)" Style="float: left; width: 80%!important; margin-left: -5.5%; text-transform: uppercase;" onkeypress="return DisableEnter(event)"></asp:TextBox>
                                 </div>

                                <div id="divExistingEmp_INSRNC">
                                    <asp:DropDownList ID="ddlExistingEmp_INSRNC" class="form1"  Style="float: left; width: 83% !important; margin-left: -5.5%;" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off" onkeypress="return DisableEnter(event)">
                                    </asp:DropDownList>
                               </div>
                            </div>
                  </div>

                <div class="eachform" style="width: 49%; float: right;margin-top:-3.5%">
                  <h2 style="margin-left:10%">Contact Person Email </h2>
                    <asp:TextBox ID="txtCntctMail_INSRNC" onkeypress="return isTag(event);" class="form1" runat="server" MaxLength="90" Style="width:45%; margin-right: 8%; height: 30px"></asp:TextBox>
                </div>
               
               <div id="divfleupld_INSRNC" class="eachform"  style="width: 100%; float: left">

                 <h2  style="margin-left: 4%;margin-top: 3%;">Attachments </h2>
                  <div id="divfileupl_INSRNC" class="form-group"  style="margin-top: -4%;float: left;width: 73%; height: 97px;overflow: auto;margin-left: 20.5%;border: 1px solid rgb(207, 204, 204);font-family: Calibri;background-color: white;padding: 13px;">
                     <div id="divFileuploadScroll_INSRNC"  style="margin-top:1%;float:right;margin-right:2.5%; width:95.5%;max-height: 265px;overflow: auto;">
                        <table id="TableFileUploadContainer_INSRNC" style="width: 99%;">
                        </table>
                        <br />
                     </div>
                     <div style="margin-top:1%;float:right;margin-right:2.5%; width:65.5%;max-height: 265px;overflow: auto;">
                        <table id="Table1_INSRNC" style="width: 99%;">
                        </table>
                        <br />
                     </div>   
                 </div>
                    
               </div>


              <%--for notification template--%>

      <asp:UpdatePanel ID="updPanelTempl_INSRNC" runat="server" EnableViewState="true" UpdateMode="Conditional">
       <ContentTemplate>
                           
     <asp:HiddenField ID="hiddenTemplateCount_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenTemplateAlertData_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenEditMode_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenDivisionddlData_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenDesignationddlData_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenEmployeeDdlData_INSRNC" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenNotificationDuration_INSRNC" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenNotificationMOde_INSRNC" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenNotifyVia_INSRNC" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenEachTemplateDetail_INSRNC" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenEachSliceData_INSRNC" runat="server" Value="0" />
                        

                 <div class="eachform" style="width: 100%; float: left;margin-top:0%">
                   <h2 style="margin-left: 4%;margin-top: 2%;">Template* </h2>
                    <div class="subform" style="width: 52%; margin-right: 27.5%; padding-top: 7px;">
                      <div  style="float: left;width: 55%;margin-top: 2%;">
                         <asp:DropDownList ID="ddlTemplate_INSRNC" AutoPostBack="true" class="form1" Style=" width: 93% !important; margin-left: 0%;float: left;" runat="server" onchange="clearhidden_INSRNC()" autofocus="autofocus" autocorrect="off" autocomplete="off" OnSelectedIndexChanged="ddlTemplate_INSRNC_SelectedIndexChanged" >
                         </asp:DropDownList>
                        </div>
                        <div style="float: left;border: 1px solid;width: 67px;border-color: #6a8a32;background-color: #e0efee;">
                            <div style="width:100%;padding: 3px;float: left;">
                                <label style="font-family: calibri;font-size: 12px;color: #a50505;">Don't Notify</label>
                            </div>
                             <label for="cphMain_cbxDontNotify_INSRNC"><img src="/Images/Icons/DontNotify.png" style="margin-left: 8px;margin-bottom: 3px;" /></label>
                            <span>
                              <asp:CheckBox ID="cbxDontNotify_INSRNC" runat="server" onchange="CbxChange_INSRNC()" onkeypress="return DisableEnter(event)" />
                               
                            </span>
                        </div>
                    </div>
                </div>
                   

              <div class="eachform"  style="width: 95%; float: left;margin-top:2.5%; margin-left: 2.5%;background-color: white;">
                 <div id="DivTemplateContainer_INSRNC" style="width:86%;min-height:200px;padding: 25px;margin-top: 3%;background-color: #e0efee;margin-left: 4%;margin-bottom: 3%;" >
                    <table id="TableTemplateContainer_INSRNC" style="width: 100%;">
                    
                     </table>
                </div>
              </div>

             </ContentTemplate>
          </asp:UpdatePanel>



               <div class="eachform" style="width: 99%; margin-top: 3%; float: left">
                   <div class="subform" style="width: 70%; margin-left: 38%">

                    <asp:Button ID="btnConfirm_INSRNC" runat="server" class="save" Text="Confirm" OnClientClick="return ConfirmAlert_INSRNC();" OnClick="btnConfirm_INSRNC_Click"/>
                    <asp:Button ID="btnUpdate_INSRNC" runat="server" class="save" Text="Update" OnClientClick="return Validate_INSRNC();" OnClick="btnUpdate_INSRNC_Click"/>
                    <asp:Button ID="btnUpdateClose_INSRNC" runat="server" class="save" Text="Update & Close" OnClientClick="return Validate_INSRNC();" OnClick="btnUpdate_INSRNC_Click"/>
                    <asp:Button ID="btnAdd_INSRNC"  runat="server" class="save" Text="Save" OnClientClick="return Validate_INSRNC();" OnClick="btnAdd_INSRNC_Click" />
                    <asp:Button ID="btnAddClose_INSRNC" runat="server" class="save" Text="Save & Close" OnClientClick="return Validate_INSRNC();" OnClick="btnAdd_INSRNC_Click" />
                    <asp:Button ID="btnrenew_INSRNC" runat="server"  OnClientClick="return Alertrenew_INSRNC();"  class="save" Text="Renew" OnClick="btnrenew_INSRNC_Click"/>   
                    <asp:Button ID="btnCancel_INSRNC" runat="server" class="cancel" Text="Cancel"  OnClientClick="return cancelClickclearhidd_INSRNC();" OnClick="btnCancel_INSRNC_Click" />
                    <asp:Button ID="btnClear_INSRNC" runat="server" style="margin-left: 19px;" OnClientClick="return AlertClearAll_INSRNC();"  class="cancel" Text="Clear"/>

                   </div>
        </div>


     </div>

            
            <%--<asp:Button runat="server"  PostBackUrl="/GMS/GMS_Master/Template_Mail_Service/Template_Mail_Service.aspx"/>--%>

           

         



     </div>







  </div>
  
               
 



                                     <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 1%; margin-right: 1%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 42%; padding-bottom: 0.7%; padding-top: 0.6%;">Bank Guarantee</h3>
                    </div>
                    <div class="modal-bodyCancelView" style="overflow: auto;height: 360px;">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; display:none">Close Reason*</label>
                       <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;display:none" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTagOnly(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                        <div style="float: left;width: 100%;">
                          <div class="eachform" style="width:25%;float:left;margin-top:10px;margin-left:1px;border: 1px solid;border-color: #9ba48b;">
                       <%-- <div class="eachform" style="width: 100%;margin-top:0%;">--%>

                <h2 style="margin-top:1%;margin-left: 15%">Guarantee Mode</h2>
           <%-- </div>--%>
                  <div class="eachform" style="width: 100%; padding-left: 0.5%;padding-top:1% ;float: left;">
                        <asp:DropDownList ID="ddlGuaranteeMde" class="form1" style="height:25px;width:90%;margin-left: 5%;margin-top: 0%;float: left;margin-bottom: 2%;" runat="server">
                  
                  
                     </asp:DropDownList>
        </div>
 </div>
                                   <div class="eachform" style="width: 25%; float: left;border: 1px solid;border-color: #9ba48b;margin-top: 1%;margin-left: 1%;height: 68px;">
            <h2 style="margin-top: 0.5%;margin-left: 32%;">Customer</h2>
                 <div id="divcustomer">
            <asp:DropDownList ID="ddlSuplCus" class="form1" style="height:25px;width:90%;margin-right: 5%;margin-bottom: 2%;margin-top: 1%;" runat="server"></asp:DropDownList>
                  </div>
                       </div>
                             <div class="eachform"  style="width:16%;float: right;margin-right: 1%;margin-top: 3%;">
                <input type="button"  id="btnSearch" style="cursor:pointer;margin-top: -0.4%;"   class="searchlist_btn_lft" value="Search" onclick="SearchValidation();" />
                     </div>

               </div>
                        
                           <div id="divReport" class="table-responsive"  style="margin-top: 9%;">
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
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   

         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>




  




    <style>
            .tooltipp {
    
    z-index: 1030;
    display: block;
    padding: 5px;
    font-size: 11px;
    opacity: 0;
    filter: alpha(opacity=0);
    visibility: visible;
}



        .modalCancelView {
            display: none;
            position: fixed;
            z-index: 30;
            padding-top: 0%;
            left: 2%;
            top: 20%;
            width: 96%;
            height: 475px;
            overflow: auto;
            background-color: transparent;
        }

        .open > .dropdown-menu {
            display: none;
        }
    </style>
</asp:Content>


