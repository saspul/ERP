<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Vehicle_Master.aspx.cs"  Inherits="AWMS_AWMS_Master_gen_Vehicle_Master_gen_Vehicle_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
    <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />

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
           function ConfirmMessage() {
               if (confirmbox > 0) {
                   if (confirm("Are You Sure You Want To Leave This Page?")) {
                       window.location.href = "gen_Vehicle_Master_List.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "gen_Vehicle_Master_List.aspx";

               }
           }

           function AlertClearAll() {
               if (confirmbox > 0) {
                   if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                       window.location.href = "gen_Vehicle_Master.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "gen_Vehicle_Master.aspx";

               }
           }

    </script>
        <style>
.divbutton {
    display:inline-block;
    color:#0C7784;
    border:1px solid #999;
    background:#CBCBCB;
    /*box-shadow: 0 0 5px -1px rgba(0,0,0,0.2);*/
    cursor:pointer;
    vertical-align:middle;
    width: 15.36%;
    padding: 5px;
    text-align: center;
    font-family: calibri;
}
.divbutton:active {
    color:red;
    box-shadow: 0 0 5px -1px rgba(0,0,0,0.6);
}
   input[type="file"] {
            position: relative;
            z-index: 1;
            margin-left: -78px;
            display: none;
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
    </style>
     <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {



            if (document.getElementById("<%=hiddenVehicleClassImg.ClientID%>").value != "" || document.getElementById("<%=hiddenFuelTypImg.ClientID%>").value != "") {

                if (document.getElementById("<%=hiddenVehicleClassImg.ClientID%>").value != "") {
                    document.getElementById("<%=divVehicleImage.ClientID%>").innerHTML = document.getElementById("<%=hiddenVehicleClassImg.ClientID%>").value;
                }

                if (document.getElementById("<%=hiddenFuelTypImg.ClientID%>").value != "") {
                    document.getElementById("<%=divFuelTypeImage.ClientID%>").innerHTML = document.getElementById("<%=hiddenFuelTypImg.ClientID%>").value;
                }

                TankerDivVisibility();
                TrailerDivVisibility();
            }
            else {

                if (document.getElementById("<%=hiddenFuelTypeId.ClientID%>").value != "") {

                    FuelTypDisplayImage();
                }
                if (document.getElementById("<%=hiddenVehicleClassId.ClientID%>").value != "") {

                    VehicleDisplayImage();
                }
            }
            

            if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {

                IncrmntConfrmCounter();
            }
           
            AmountCheck('cphMain_txtEngineCapacity');
            AmountCheck('cphMain_txtKML');
            AmountCheck('cphMain_txtFuelLimit');
            MoneyCheck('cphMain_txtInsuranceAmount');
            AmountCheck('cphMain_txtTankerCapacity');
            MoneyCheck('cphMain_txtAmountPerBarrel');
            MoneyCheck('cphMain_txtPrice');
            MoneyCheck('cphMain_txtTrInsAmnt');
            //displaying current
            localStorage.clear();
          
            var EditVal = document.getElementById("<%=hiddenEdit.ClientID%>").value;
            var ViewVal = document.getElementById("<%=hiddenView.ClientID%>").value;
          


            if (EditVal != "") {
            
                //document.getElementById('cphMain_divStatus').style="";

                if (document.getElementById("<%=hiddenEditPrmtAttchmnt.ClientID%>").value != "") {
                    var EditAttchmnt = document.getElementById("<%=hiddenEditPrmtAttchmnt.ClientID%>").value;
                   // alert('editval' + EditAttchmnt);
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
                            if (jsonAtt[key].TransDtlId != "") {

                                //   alert(jsonAtt[key].ActualFileName);
                                EditAttachmentPer(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                //  alert(json[key].Amount);
                            }
                        }
                    }


                }

           

                if (document.getElementById("<%=hiddenEditInsurAttchmnt.ClientID%>").value != "") {
                    var EditAttchmnt = document.getElementById("<%=hiddenEditInsurAttchmnt.ClientID%>").value;
                    // alert('editval' + EditAttchmnt);
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
                             if (jsonAtt[key].TransDtlId != "") {

                                 //   alert(jsonAtt[key].ActualFileName);
                                 EditAttachmentIns(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                 //  alert(json[key].Amount);
                             }
                         }
                     }


                 }



                if (document.getElementById("<%=hiddenEditVhclAttchmnt.ClientID%>").value != "") {
                    var EditAttchmnt = document.getElementById("<%=hiddenEditVhclAttchmnt.ClientID%>").value;
                     // alert('editval' + EditAttchmnt);
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
                              if (jsonAtt[key].TransDtlId != "") {

                                  //   alert(jsonAtt[key].ActualFileName);
                                  EditAttachmentVhcl(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                  //  alert(json[key].Amount);
                              }
                          }
                      }


                }
              


                if (document.getElementById("<%=hiddenEditPrmtAttchmntTR.ClientID%>").value != "") {
                    var EditAttchmnt = document.getElementById("<%=hiddenEditPrmtAttchmntTR.ClientID%>").value;
                         // alert('editval' + EditAttchmnt);
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
                                 if (jsonAtt[key].TransDtlId != "") {

                                     //   alert(jsonAtt[key].ActualFileName);
                                     EditAttachmentPerTR(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                     //  alert(json[key].Amount);
                                 }
                             }
                         }


                     }



                     if (document.getElementById("<%=hiddenEditInsurAttchmntTR.ClientID%>").value != "") {
                    var EditAttchmnt = document.getElementById("<%=hiddenEditInsurAttchmntTR.ClientID%>").value;
                    // alert('editval' + EditAttchmnt);
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
                            if (jsonAtt[key].TransDtlId != "") {

                                //   alert(jsonAtt[key].ActualFileName);
                                EditAttachmentInsTR(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                //  alert(json[key].Amount);
                            }
                        }
                    }


                }







                if (document.getElementById("<%=hiddenIsPrmtRenwed.ClientID%>").value == "") {
                    AddFileUploadPer();
                }
                if (document.getElementById("<%=hiddenIsInsurRenwed.ClientID%>").value == "") {
                    AddFileUploadIns();
                }
                AddFileUploadVhcl();
                if (document.getElementById("<%=hiddenIsPrmtRenwedTR.ClientID%>").value == "") {
                    AddFileUploadPerTR();
                }
                if (document.getElementById("<%=hiddenIsInsurRenwedTR.ClientID%>").value == "") {
                    AddFileUploadInsTR();
                }
            }


           

            else if (ViewVal != "") {

                //document.getElementById('cphMain_divStatus').style = "";

                if (document.getElementById("<%=hiddenEditPrmtAttchmnt.ClientID%>").value != "") {
                    var EditAttchmnt = document.getElementById("<%=hiddenEditPrmtAttchmnt.ClientID%>").value;
                    //alert('editval' + EditAttchmnt);
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
                            if (jsonAtt[key].TransDtlId != "") {

                                //   alert(jsonAtt[key].ActualFileName);
                                ViewAttachmentPer(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                //  alert(json[key].Amount);
                            }
                        }
                    }


                }



                if (document.getElementById("<%=hiddenEditInsurAttchmnt.ClientID%>").value != "") {
                    var EditAttchmnt = document.getElementById("<%=hiddenEditInsurAttchmnt.ClientID%>").value;
                    //alert('editval' + EditAttchmnt);
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
                            if (jsonAtt[key].TransDtlId != "") {

                                //   alert(jsonAtt[key].ActualFileName);
                                ViewAttachmentIns(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                //  alert(json[key].Amount);
                            }
                        }
                    }


                }



                if (document.getElementById("<%=hiddenEditVhclAttchmnt.ClientID%>").value != "") {
                    var EditAttchmnt = document.getElementById("<%=hiddenEditVhclAttchmnt.ClientID%>").value;
                   // alert('editval' + EditAttchmnt);
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
                            if (jsonAtt[key].TransDtlId != "") {

                                //   alert(jsonAtt[key].ActualFileName);
                                ViewAttachmentVhcl(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                //  alert(json[key].Amount);
                            }
                        }
                    }


                }

                if (document.getElementById("<%=hiddenEditPrmtAttchmntTR.ClientID%>").value != "") {
                    var EditAttchmnt = document.getElementById("<%=hiddenEditPrmtAttchmntTR.ClientID%>").value;
                     //alert('editval' + EditAttchmnt);
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
                             if (jsonAtt[key].TransDtlId != "") {

                                 //   alert(jsonAtt[key].ActualFileName);
                                 ViewAttachmentPerTR(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                 //  alert(json[key].Amount);
                             }
                         }
                     }


                 }



                 if (document.getElementById("<%=hiddenEditInsurAttchmntTR.ClientID%>").value != "") {
                    var EditAttchmnt = document.getElementById("<%=hiddenEditInsurAttchmntTR.ClientID%>").value;
                    //alert('editval' + EditAttchmnt);
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
                            if (jsonAtt[key].TransDtlId != "") {

                                //   alert(jsonAtt[key].ActualFileName);
                                ViewAttachmentInsTR(jsonAtt[key].TransDtlId, jsonAtt[key].FileName, jsonAtt[key].ActualFileName, jsonAtt[key].Description);



                                //  alert(json[key].Amount);
                            }
                        }
                    }


                }

            }
            else {
                AddFileUploadPer();
                AddFileUploadIns();
                AddFileUploadVhcl();
                AddFileUploadPerTR();
                AddFileUploadInsTR();

            }


                //oldFuelType = document.getElementById("<%=hiddenFuelTypeId.ClientID%>").value;
               

               
                //document.getElementById("divFuel-" + oldFuelType).style.border = ".5px solid";
               
                //document.getElementById("divFuel-" + oldFuelType).style.backgroundColor = "rgb(164, 227, 160)";
                //document.getElementById("divFuel-" + oldFuelType).style.borderColor = " rgb(13, 13, 14)";
               
              
                //var $Mo = jQuery.noConflict();

                //var offset = $Mo("#divFuel-" + oldFuelType).offset(); 

                //var posY = 0;
                //var posX = 0;
                //posY = offset.top;

                //document.getElementById('cphMain_divFuelImage').scrollTop = posY-210;


            //if (document.getElementById("<%=hiddenVehicleClassId.ClientID%>").value!="")
            //{
            //var VehClassId = document.getElementById("<%=hiddenVehicleClassId.ClientID%>").value;
            //document.getElementById("divImageVehicle-" + VehClassId).style.border = ".5px solid";
            //document.getElementById("divImageVehicle-" + VehClassId).style.backgroundColor = "rgb(164, 227, 160)";
            //document.getElementById("divImageVehicle-" + VehClassId).style.borderColor = " rgb(13, 13, 14)";

            //var $Mo = jQuery.noConflict();

            //var offset = $Mo("#divImageVehicle-" + VehClassId).offset();

            //var posY = 0;
            //var posX = 0;
            //posY = offset.top;
        
            //document.getElementById('cphMain_divVehicleClass').scrollTop = posY-288;
            //}

            if (document.getElementById("<%=hiddenOpenPrmtORIns.ClientID%>").value != "0") {
 

                var mode = document.getElementById("<%=hiddenOpenPrmtORIns.ClientID%>").value;
                var TR = document.getElementById("<%=HiddenFieldTR.ClientID%>").value;
               
                if (TR == "1") {
                    if (mode == "INS") {
                        document.getElementById('divButtonInsuranceDetails').style.backgroundColor = "#f9f9f9";
                        document.getElementById('divButtonInsuranceDetails').style.borderBottom = "none";
                        document.getElementById('divInsuranceDetails').style.display = "block";
                    }
                    else if (mode == "PER") {
                        document.getElementById('divButtonPermitDetails').style.backgroundColor = "#f9f9f9";
                        document.getElementById('divButtonPermitDetails').style.borderBottom = "none";
                        document.getElementById('divPermitDetails').style.display = "block";
                    }
                }
                else if (TR == "2") {
                    document.getElementById('divButtonTrailerDetails').style.backgroundColor = "#f9f9f9";
                    document.getElementById('divButtonTrailerDetails').style.borderBottom = "none";
                    document.getElementById('divTrailerDetails').style.display = "block";
                }
            }
            else {
               
                if (document.getElementById("<%=HiddenDivAddinlDis.ClientID%>").value != "hide") {
                    document.getElementById('divButtonAdditional').style.backgroundColor = "#f9f9f9";
                    document.getElementById('divButtonAdditional').style.borderBottom = "none";
                    document.getElementById('divAdditionalInfo').style.display = "block";
                }
            }
           
        });
    </script>
     <script type="text/javascript">

        
         var FileCounterPer = 0;
         var FileCounterIns = 100;
         var FileCounterVhcl = 200;
         var FileCounterPerTR = 300;
         var FileCounterInsTR = 400;
         function AddFileUploadPer() {
            
             var FrecRow = '<tr id="FilerowId_' + FileCounterPer + '" >';


             var labelForStyle = '<label  for="file' + FileCounterPer + '" class="custom-file-upload" style="margin-left: 0%;"> <img src="/Images/Icons/cloud_upload.jpg"></img>Upload Document</label>';
             var tdInner = labelForStyle + '<input   id="file' + FileCounterPer + '" name = "file' + FileCounterPer +

                            '" type="file" onchange="ChangeFilePer(' + FileCounterPer + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/>';

             FrecRow += '<td  style="width: 30%;" >' + tdInner + '</td>';

             FrecRow += '<td  style="word-break: break-all;font-size: 14px;" id="filePath' + FileCounterPer + '"  ></td  >';

             //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

             //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><textarea id="descrptn' + FileCounterPer + '"    style="resize: none;border: 1px solid #ccc;height: 45px;font-family: calibri;"  MaxLength="50" value="--Description--" onfocus="focusTxtDescrptn(' + FileCounterPer + ');" onkeypress="return RemoveTag(event);"  onblur="blurTxtDescrptnPer(' + FileCounterPer + ');"  onkeydown="textCounter(descrptn' + FileCounterPer + ',99);" onkeyup="textCounter(descrptn' + FileCounterPer + ',99);"></textarea></td>';
             FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterPer + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesPer(' + FileCounterPer + ');" style="  cursor: pointer;"></td>';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" type="image" id="FieldId' + FileCounterPer + '" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadPer(' + FileCounterPer + ');"    style=" cursor: pointer;" ></td>';

             FrecRow += ' <td id="FileInx' + FileCounterPer + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterPer + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterPer + '" style="display: none;">INS</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterPer + '" style="display: none;"></td>';
             FrecRow += '<td id="DbFileName' + FileCounterPer + '" style="display: none;"></td>';
             FrecRow += '</tr>';
            
             jQuery('#TableFileUploadContainerPermit').append(FrecRow);
            
             document.getElementById("descrptn" + FileCounterPer).value = "--Description--";

            // $noCon('#divPerAtch').scrollTop($noCon('#divPerAtch')[0].scrollHeight);
            
             //var objDiv = document.getElementById('divPerAtch');
             //objDiv.scrollTop = objDiv.scrollHeight;
            
             
              document.getElementById('filePath' + FileCounterPer).innerHTML = 'No File Uploaded';
               
              FileCounterPer++;

         }
         function EditAttachmentPer(editTransDtlId, EditFileName, EditActualFileName, EditDescription) {
             
             if (EditDescription == "") {
                 EditDescription = "--Description--";
             }
             var FrecRow = '<tr id="FilerowId_' + FileCounterPer + '" >';


             var labelForStyle = '<label for="file' + FileCounterPer + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
             var tdInner = labelForStyle + '<input   id="file' + FileCounterPer + '" name = "file' + FileCounterPer +

                            '" type="file" onchange="ChangeFilePer(' + FileCounterPer + ')" />';

             FrecRow += '<td style="width: 25%; display:none;" >' + tdInner + '</td>';

             var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

             FrecRow += '<td colspan="2"  id="filePath' + FileCounterPer + '" style="border-bottom: 1px dotted rgb(205, 237, 196);font-size: 14px;"' + '  >' + tdFileNameEdit + '</td  >';

              //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

              //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><textarea disabled id="descrptn' + FileCounterPer + '"    style="resize: none;border: 1px solid #ccc;height: 45px;font-family: calibri;"  MaxLength="50" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterPer + ');" onkeypress="return RemoveTag(event);"  onblur="blurTxtDescrptnPer(' + FileCounterPer + ');" onkeydown="textCounter(descrptn' + FileCounterPer + ',99);" onkeyup="textCounter(descrptn' + FileCounterPer + ',99);"></textarea></td>';
            
             if (document.getElementById("<%=hiddenIsPrmtRenwed.ClientID%>").value == "") {
                 FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterPer + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesPer(' + FileCounterPer + ');" style="  cursor: pointer;"></td>';
                 FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadPer(' + FileCounterPer + ');"    style=" cursor: pointer;" ></td>';
               
             }
             else {
                 FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterPer + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesPer(' + FileCounterPer + ');" style="  cursor: pointer;"></td>';
                 FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadPer(' + FileCounterPer + ');"    style=" cursor: pointer;" ></td>';
               
             }
            FrecRow += ' <td id="FileInx' + FileCounterPer + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + FileCounterPer + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + FileCounterPer + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId' + FileCounterPer + '" style="display: none;">' + editTransDtlId + '</td>';
            FrecRow += '<td id="DbFileName' + FileCounterPer + '" style="display: none;">' + EditFileName + '</td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadContainerPermit').append(FrecRow);

            document.getElementById("descrptn" + FileCounterPer).value = EditDescription;

            document.getElementById("FileInx" + FileCounterPer).innerHTML = FileCounterPer;
            document.getElementById("FileIndvlAddMoreRow" + FileCounterPer).style.opacity = "0.3";
              // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
            FileLocalStorageAddPer(FileCounterPer);
            FileCounterPer++;

         }
         //Start:-For Trailer Attachment
         function AddFileUploadPerTR() {

             var FrecRow = '<tr id="FilerowId_' + FileCounterPerTR + '" >';


             var labelForStyle = '<label  for="file' + FileCounterPerTR + '" class="custom-file-upload" style="margin-left: 0%;"> <img src="/Images/Icons/cloud_upload.jpg"></img>Upload Document</label>';
             var tdInner = labelForStyle + '<input   id="file' + FileCounterPerTR + '" name = "file' + FileCounterPerTR +

                            '" type="file" onchange="ChangeFilePerTR(' + FileCounterPerTR + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/>';

             FrecRow += '<td  style="width: 34%;" >' + tdInner + '</td>';

             FrecRow += '<td  style="word-break: break-all;font-size: 14px;" id="filePath' + FileCounterPerTR + '"  ></td  >';

            
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><textarea id="descrptn' + FileCounterPerTR + '"    style="resize: none;border: 1px solid #ccc;height: 45px;font-family: calibri;"  MaxLength="50" value="--Description--" onfocus="focusTxtDescrptn(' + FileCounterPerTR + ');" onkeypress="return RemoveTag(event);"  onblur="blurTxtDescrptnPerTR(' + FileCounterPerTR + ');" onkeydown="textCounter(descrptn' + FileCounterPerTR + ',99);" onkeyup="textCounter(descrptn' + FileCounterPerTR + ',99);"></textarea></td>';
             FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterPerTR + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesPerTR(' + FileCounterPerTR + ');" style="  cursor: pointer;"></td>';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" type="image" id="FieldId' + FileCounterPerTR + '" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadPerTR(' + FileCounterPerTR + ');"    style=" cursor: pointer;" ></td>';

             FrecRow += ' <td id="FileInx' + FileCounterPerTR + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterPerTR + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterPerTR + '" style="display: none;">INS</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterPerTR + '" style="display: none;"></td>';
             FrecRow += '<td id="DbFileName' + FileCounterPerTR + '" style="display: none;"></td>';
             FrecRow += '</tr>';

             jQuery('#tableTrPerFiles').append(FrecRow);
             document.getElementById("descrptn" + FileCounterPerTR).value = "--Description--";
             document.getElementById('filePath' + FileCounterPerTR).innerHTML = 'No File Uploaded';

             FileCounterPerTR++;

         }
         function EditAttachmentPerTR(editTransDtlId, EditFileName, EditActualFileName, EditDescription) {

             if (EditDescription == "") {
                 EditDescription = "--Description--";
             }
             var FrecRow = '<tr id="FilerowId_' + FileCounterPerTR + '" >';


             var labelForStyle = '<label for="file' + FileCounterPerTR + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
             var tdInner = labelForStyle + '<input   id="file' + FileCounterPerTR + '" name = "file' + FileCounterPerTR +

                            '" type="file" onchange="ChangeFilePerTR(' + FileCounterPerTR + ')" />';

             FrecRow += '<td style="width: 25%; display:none;" >' + tdInner + '</td>';

             var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

             FrecRow += '<td colspan="2"  id="filePath' + FileCounterPerTR + '" style="border-bottom: 1px dotted rgb(205, 237, 196);font-size: 14px;"' + '  >' + tdFileNameEdit + '</td  >';

             //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

             //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><textarea disabled id="descrptn' + FileCounterPerTR + '"    style="resize: none;border: 1px solid #ccc;height: 45px;font-family: calibri;"  MaxLength="50" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterPerTR + ');" onkeypress="return RemoveTag(event);"  onblur="blurTxtDescrptnPerTR(' + FileCounterPerTR + ');" onkeydown="textCounter(descrptn' + FileCounterPerTR + ',99);" onkeyup="textCounter(descrptn' + FileCounterPerTR + ',99);"></textarea></td>';

             if (document.getElementById("<%=hiddenIsPrmtRenwedTR.ClientID%>").value == "") {
                 FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterPerTR + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesPerTR(' + FileCounterPerTR + ');" style="  cursor: pointer;"></td>';
                 FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadPerTR(' + FileCounterPerTR + ');"    style=" cursor: pointer;" ></td>';

             }
             else {
                 FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterPerTR + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesPerTR(' + FileCounterPerTR + ');" style="  cursor: pointer;"></td>';
                 FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadPerTR(' + FileCounterPerTR + ');"    style=" cursor: pointer;" ></td>';

             }
             FrecRow += ' <td id="FileInx' + FileCounterPerTR + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterPerTR + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterPerTR + '" style="display: none;">UPD</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterPerTR + '" style="display: none;">' + editTransDtlId + '</td>';
             FrecRow += '<td id="DbFileName' + FileCounterPerTR + '" style="display: none;">' + EditFileName + '</td>';
             FrecRow += '</tr>';

             jQuery('#tableTrPerFiles').append(FrecRow);

             document.getElementById("descrptn" + FileCounterPerTR).value = EditDescription;
             document.getElementById("FileInx" + FileCounterPerTR).innerHTML = FileCounterPerTR;
             document.getElementById("FileIndvlAddMoreRow" + FileCounterPerTR).style.opacity = "0.3";
            
             FileLocalStorageAddPerTR(FileCounterPerTR);
             FileCounterPerTR++;

         }
         function AddFileUploadInsTR() {

             var FrecRow = '<tr id="FilerowId_' + FileCounterInsTR + '" >';


             var labelForStyle = '<label  for="file' + FileCounterInsTR + '" class="custom-file-upload" style="margin-left: 0%;"> <img src="/Images/Icons/cloud_upload.jpg"></img>Upload Document</label>';
             var tdInner = labelForStyle + '<input   id="file' + FileCounterInsTR + '" name = "file' + FileCounterInsTR +

                            '" type="file" onchange="ChangeFileInsTR(' + FileCounterInsTR + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/>';

             FrecRow += '<td  style="width: 34%;" >' + tdInner + '</td>';

             FrecRow += '<td  style="word-break: break-all;font-size: 14px;" id="filePath' + FileCounterInsTR + '"  ></td  >';


             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><textarea id="descrptn' + FileCounterInsTR + '"    style="resize: none;border: 1px solid #ccc;height: 45px;font-family: calibri;"  MaxLength="50" value="--Description--" onfocus="focusTxtDescrptn(' + FileCounterInsTR + ');" onkeypress="return RemoveTag(event);"  onblur="blurTxtDescrptnInsTR(' + FileCounterInsTR + ');" onkeydown="textCounter(descrptn' + FileCounterInsTR + ',99);" onkeyup="textCounter(descrptn' + FileCounterInsTR + ',99);"></textarea></td>';
             FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterInsTR + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesInsTR(' + FileCounterInsTR + ');" style="  cursor: pointer;"></td>';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" type="image" id="FieldId' + FileCounterInsTR + '" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadInsTR(' + FileCounterInsTR + ');"    style=" cursor: pointer;" ></td>';

             FrecRow += ' <td id="FileInx' + FileCounterInsTR + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterInsTR + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterInsTR + '" style="display: none;">INS</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterInsTR + '" style="display: none;"></td>';
             FrecRow += '<td id="DbFileName' + FileCounterInsTR + '" style="display: none;"></td>';
             FrecRow += '</tr>';

             jQuery('#tableTrInsFiles').append(FrecRow);
             document.getElementById("descrptn" + FileCounterInsTR).value = "--Description--";
             document.getElementById('filePath' + FileCounterInsTR).innerHTML = 'No File Uploaded';

             FileCounterInsTR++;

         }
         function EditAttachmentInsTR(editTransDtlId, EditFileName, EditActualFileName, EditDescription) {

             if (EditDescription == "") {
                 EditDescription = "--Description--";
             }
             var FrecRow = '<tr id="FilerowId_' + FileCounterInsTR + '" >';


             var labelForStyle = '<label for="file' + FileCounterInsTR + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
             var tdInner = labelForStyle + '<input   id="file' + FileCounterInsTR + '" name = "file' + FileCounterInsTR +

                            '" type="file" onchange="ChangeFileInsTR(' + FileCounterInsTR + ')" />';

             FrecRow += '<td style="width: 25%; display:none;" >' + tdInner + '</td>';

             var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

             FrecRow += '<td colspan="2"  id="filePath' + FileCounterInsTR + '" style="border-bottom: 1px dotted rgb(205, 237, 196);font-size: 14px;"' + '  >' + tdFileNameEdit + '</td  >';

             //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

             //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><textarea disabled id="descrptn' + FileCounterInsTR + '"    style="resize: none;border: 1px solid #ccc;height: 45px;font-family: calibri;"  MaxLength="50" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterInsTR + ');" onkeypress="return RemoveTag(event);"  onblur="blurTxtDescrptnInsTR(' + FileCounterInsTR + ');" onkeydown="textCounter(descrptn' + FileCounterInsTR + ',99);" onkeyup="textCounter(descrptn' + FileCounterInsTR + ',99);"></textarea></td>';

             if (document.getElementById("<%=hiddenIsInsurRenwedTR.ClientID%>").value == "") {
                 FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterInsTR + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesInsTR(' + FileCounterInsTR + ');" style="  cursor: pointer;"></td>';
                 FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadInsTR(' + FileCounterInsTR + ');"    style=" cursor: pointer;" ></td>';

             }
             else {
                 FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterInsTR + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesInsTR(' + FileCounterInsTR + ');" style="  cursor: pointer;"></td>';
                 FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadInsTR(' + FileCounterInsTR + ');"    style=" cursor: pointer;" ></td>';

             }
             FrecRow += ' <td id="FileInx' + FileCounterInsTR + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterInsTR + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterInsTR + '" style="display: none;">UPD</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterInsTR + '" style="display: none;">' + editTransDtlId + '</td>';
             FrecRow += '<td id="DbFileName' + FileCounterInsTR + '" style="display: none;">' + EditFileName + '</td>';
             FrecRow += '</tr>';

             jQuery('#tableTrInsFiles').append(FrecRow);

             document.getElementById("descrptn" + FileCounterInsTR).value = EditDescription;
             document.getElementById("FileInx" + FileCounterInsTR).innerHTML = FileCounterInsTR;
             document.getElementById("FileIndvlAddMoreRow" + FileCounterInsTR).style.opacity = "0.3";
             FileLocalStorageAddInsTR(FileCounterInsTR);
             FileCounterInsTR++;

         }

         function ViewAttachmentPerTR(editTransDtlId, EditFileName, EditActualFileName, EditDescription) {
             if (EditDescription == "") {
                 EditDescription = "--Description--";
             }
             var FrecRow = '<tr id="FilerowId_' + FileCounterPerTR + '" >';


             var labelForStyle = '<label for="file' + FileCounterPerTR + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
             var tdInner = labelForStyle + '<input   id="file' + FileCounterPerTR + '" name = "file' + FileCounterPerTR +

                            '" type="file" onchange="ChangeFilePerTR(' + FileCounterPerTR + ')" />';

             FrecRow += '<td style="width: 25%; display:none;" >' + tdInner + '</td>';

             var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

             FrecRow += '<td colspan="2"  id="filePath' + FileCounterPerTR + '" style="font-size: 14px;"  >' + tdFileNameEdit + '</td  >';

               //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

               //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><textarea disabled id="descrptn' + FileCounterPerTR + '"    style="resize: none;border: 1px solid #ccc;height: 45px;font-family: calibri;"  MaxLength="50" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterPerTR + ');" onkeypress="return RemoveTag(event);"  onblur="blurTxtDescrptnPerTR(' + FileCounterPerTR + ');" onkeydown="textCounter(descrptn' + FileCounterPerTR + ',99);" onkeyup="textCounter(descrptn' + FileCounterPerTR + ',99);"></textarea></td>';
             FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterPerTR + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesPerTR(' + FileCounterPerTR + ');" style="  cursor: pointer;"></td>';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadPerTR(' + FileCounterPerTR + ');"    style=" cursor: pointer;" ></td>';

             FrecRow += ' <td id="FileInx' + FileCounterPerTR + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterPerTR + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterPerTR + '" style="display: none;">UPD</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterPerTR + '" style="display: none;">' + editTransDtlId + '</td>';
             FrecRow += '<td id="DbFileName' + FileCounterPerTR + '" style="display: none;">' + EditFileName + '</td>';
             FrecRow += '</tr>';

             jQuery('#tableTrPerFiles').append(FrecRow);

             document.getElementById("descrptn" + FileCounterPerTR).value = EditDescription;
             document.getElementById("FileInx" + FileCounterPerTR).innerHTML = FileCounterPerTR;
             document.getElementById("FileIndvlAddMoreRow" + FileCounterPerTR).style.opacity = "0.3";
               // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
             FileLocalStorageAddPerTR(FileCounterPerTR);
             FileCounterPerTR++;

         }
         function ViewAttachmentInsTR(editTransDtlId, EditFileName, EditActualFileName, EditDescription) {
             if (EditDescription == "") {
                 EditDescription = "--Description--";
             }
             var FrecRow = '<tr id="FilerowId_' + FileCounterInsTR + '" >';


             var labelForStyle = '<label for="file' + FileCounterInsTR + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
             var tdInner = labelForStyle + '<input   id="file' + FileCounterInsTR + '" name = "file' + FileCounterInsTR +

                            '" type="file" onchange="ChangeFileInsTR(' + FileCounterInsTR + ')" />';

             FrecRow += '<td style="width: 25%; display:none;" >' + tdInner + '</td>';

             var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

             FrecRow += '<td colspan="2"  id="filePath' + FileCounterInsTR + '"  style="font-size: 14px;" >' + tdFileNameEdit + '</td  >';

            
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><textarea disabled id="descrptn' + FileCounterInsTR + '"    style="resize: none;border: 1px solid #ccc;height: 45px;font-family: calibri;"  MaxLength="50" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterInsTR + ');" onkeypress="return RemoveTag(event);"  onblur="blurTxtDescrptnInsTR(' + FileCounterInsTR + ');" onkeydown="textCounter(descrptn' + FileCounterInsTR + ',99);" onkeyup="textCounter(descrptn' + FileCounterInsTR + ',99);"></textarea></td>';
             FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterInsTR + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesInsTR(' + FileCounterInsTR + ');" style="  cursor: pointer;"></td>';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadInsTR(' + FileCounterInsTR + ');"    style=" cursor: pointer;" ></td>';

             FrecRow += ' <td id="FileInx' + FileCounterInsTR + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterInsTR + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterInsTR + '" style="display: none;">UPD</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterInsTR + '" style="display: none;">' + editTransDtlId + '</td>';
             FrecRow += '<td id="DbFileName' + FileCounterInsTR + '" style="display: none;">' + EditFileName + '</td>';
             FrecRow += '</tr>';

             jQuery('#tableTrInsFiles').append(FrecRow);

             document.getElementById("descrptn" + FileCounterInsTR).value = EditDescription;
             document.getElementById("FileInx" + FileCounterInsTR).innerHTML = FileCounterInsTR;
             document.getElementById("FileIndvlAddMoreRow" + FileCounterInsTR).style.opacity = "0.3";
              
             FileLocalStorageAddInsTR(FileCounterInsTR);
             FileCounterInsTR++;

         }


         function RemoveFileUploadPerTR(removeNum) {
             if (confirm("Are you Sure you want to Delete Selected File?")) {
                 //  alert('ASD');
                 var Filerow_index = jQuery('#FilerowId_' + removeNum).index();
                 FileLocalStorageDeletePerTR(Filerow_index, removeNum);
                 jQuery('#FilerowId_' + removeNum).remove();




                 // alert(Filerow_index);

                 var TableFileRowCount = document.getElementById("tableTrPerFiles").rows.length;

                 if (TableFileRowCount != 0) {
                     var idlast = $noC('#tableTrPerFiles tr:last').attr('id');
                     //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                     //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                     if (idlast != "") {
                         var res = idlast.split("_");
                         //  alert(res[1]);
                         document.getElementById("FileInx" + res[1]).innerHTML = " ";
                         document.getElementById("FileIndvlAddMoreRow" + res[1]).style.opacity = "1";
                     }
                 }
                 else {
                     AddFileUploadPerTR();


                 }




             }
             else {

                 return false;
             }
         }

         function ChangeFilePerTR(x) {
             if (ClearDivDisplayImage1(x)) {
                 IncrmntConfrmCounter();
                 if (document.getElementById('file' + x).value != "") {
                     document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;

                 }
                 else {
                     document.getElementById('filePath' + x).innerHTML = 'No File Uploaded';


                 }
                 var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                 //   alert('hi SavedorNot' + SavedorNot);
                 if (SavedorNot == "saved") {
                     var row_index = jQuery('#FilerowId_' + x).index();
                     FileLocalStorageEditPerTR(x, row_index);
                 }
                 else {
                     FileLocalStorageAddPerTR(x);
                 }
             }
         }


         function CheckaddMoreRowsIndividualFilesPerTR(x) {
             // for add image in each row
             //alert(x);
             var check = document.getElementById("FileInx" + x).innerHTML;

             //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
             //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
             //  alert(check);
             if (check == " ") {

                 var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                 if (Fevt != 'UPD') {
                     if (CheckFileUploaded(x) == true) {
                         document.getElementById("FileInx" + x).innerHTML = x;
                         document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                         AddFileUploadPerTR();
                         return false;
                     }
                 }
                 else {

                     document.getElementById("FileInx" + x).innerHTML = x;
                     document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                     AddFileUploadPerTR();
                     return false;
                 }
             }
             return false;
         }

         function FileLocalStorageAddPerTR(x) {

             var tbClientPermitFileUpload = localStorage.getItem("tbClientPermitFileUploadTR");//Retrieve the stored data

             tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

             if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                 tbClientPermitFileUpload = [];


             var FilePath = document.getElementById("filePath" + x).innerHTML;
             var descrptn = document.getElementById("descrptn" + x).value;
             var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
             var Fevt = document.getElementById("FileEvt" + x).innerHTML;
             // alert('FilePath' + FilePath);
             //  alert('descrptn' + descrptn);
             if (Fevt == 'INS') {
                 var $addFile = jQuery.noConflict();
                 var client = JSON.stringify({
                     ROWID: "" + x + "",
                     DESCRPTN: "" + descrptn + "",
                     EVTACTION: "" + Fevt + "",
                     DTLID: "0"

                 });
             }
             else if (Fevt == 'UPD') {
                 var $addFile = jQuery.noConflict();
                 var client = JSON.stringify({
                     ROWID: "" + x + "",
                     DESCRPTN: "" + descrptn + "",
                     EVTACTION: "" + Fevt + "",
                     DTLID: "" + FdetailId + ""

                 });
             }


             tbClientPermitFileUpload.push(client);
             localStorage.setItem("tbClientPermitFileUploadTR", JSON.stringify(tbClientPermitFileUpload));

             $addFile("#cphMain_HiddenField5_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));



             // alert("The PERMIT FILE ADDED.");
             // var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
              // alert(h);

              document.getElementById("FileSave" + x).innerHTML = "saved";
              //  alert('saved');
              return true;

          }

          function FileLocalStorageDeletePerTR(row_index, x) {

              var $DelFile = jQuery.noConflict();
              var tbClientPermitFileUpload = localStorage.getItem("tbClientPermitFileUploadTR");//Retrieve the stored data

              tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

              if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                  tbClientPermitFileUpload = [];



              // Using splice() we can specify the index to begin removing items, and the number of items to remove.
              tbClientPermitFileUpload.splice(row_index, 1);
              localStorage.setItem("tbClientPermitFileUploadTR", JSON.stringify(tbClientPermitFileUpload));
              $DelFile("#cphMain_HiddenField5_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));
              //   alert("FILE deleted.");

              //var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
            // alert(h);


            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            if (Fevt == 'UPD') {
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

                if (FdetailId != '') {

                    DeleteFileLSTORAGEAddPerTR(x);
                }

            }

            function DeleteFileLSTORAGEAddPerTR(x) {

                var tbClientPermitFileUploadCancel = localStorage.getItem("tbClientPermitFileUploadCancelTR");//Retrieve the stored data

                tbClientPermitFileUploadCancel = JSON.parse(tbClientPermitFileUploadCancel); //Converts string to object

                if (tbClientPermitFileUploadCancel == null) //If there is no data, initialize an empty array
                    tbClientPermitFileUploadCancel = [];


                var FileName = document.getElementById("DbFileName" + x).innerHTML;
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
                var descrptn = document.getElementById("descrptn" + x).value;



                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",

                    DESCRPTN: "" + descrptn + "",
                    // EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });

                //alert('delete db');

                tbClientPermitFileUploadCancel.push(client);
                localStorage.setItem("tbClientPermitFileUploadCancelTR", JSON.stringify(tbClientPermitFileUploadCancel));

                $addFile("#cphMain_hiddenPerFileCanclDtlIdTR").val(JSON.stringify(tbClientPermitFileUploadCancel));





                //document.getElementById("FileSave" + x).innerHTML = "saved";
                //   alert('saved');
                return true;

            }

        }

        function FileLocalStorageEditPerTR(x, row_index) {
            var tbClientPermitFileUpload = localStorage.getItem("tbClientPermitFileUploadTR");//Retrieve the stored data

            tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

            if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                tbClientPermitFileUpload = [];

            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var descrptn = document.getElementById("descrptn" + x).value;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;

            if (Fevt == 'INS') {

                var $FileE = jQuery.noConflict();
                tbClientPermitFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",

                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"
                });//Alter the selected item on the table
            }
            else {

                var $FileE = jQuery.noConflict();
                tbClientPermitFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",

                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });//Alter the selected item on the table



            }



            localStorage.setItem("tbClientPermitFileUploadTR", JSON.stringify(tbClientPermitFileUpload));
            $FileE("#cphMain_HiddenField5_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));

            //alert("The FILE EDITED.");

            //var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
            //alert(h);
            return true;
        }






















         function RemoveFileUploadInsTR(removeNum) {
             if (confirm("Are you Sure you want to Delete Selected File?")) {
                 //  alert('ASD');
                 var Filerow_index = jQuery('#FilerowId_' + removeNum).index();
                 FileLocalStorageDeleteInsTR(Filerow_index, removeNum);
                 jQuery('#FilerowId_' + removeNum).remove();




                 // alert(Filerow_index);

                 var TableFileRowCount = document.getElementById("tableTrInsFiles").rows.length;

                 if (TableFileRowCount != 0) {
                     var idlast = $noC('#tableTrInsFiles tr:last').attr('id');
                     //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                     //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                     if (idlast != "") {
                         var res = idlast.split("_");
                         //  alert(res[1]);
                         document.getElementById("FileInx" + res[1]).innerHTML = " ";
                         document.getElementById("FileIndvlAddMoreRow" + res[1]).style.opacity = "1";
                     }
                 }
                 else {
                     AddFileUploadInsTR();


                 }




             }
             else {

                 return false;
             }
         }

         function ChangeFileInsTR(x) {
             if (ClearDivDisplayImage1(x)) {
                 IncrmntConfrmCounter();
                 if (document.getElementById('file' + x).value != "") {
                     document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;

                 }
                 else {
                     document.getElementById('filePath' + x).innerHTML = 'No File Uploaded';


                 }
                 var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                 //   alert('hi SavedorNot' + SavedorNot);
                 if (SavedorNot == "saved") {
                     var row_index = jQuery('#FilerowId_' + x).index();
                     FileLocalStorageEditInsTR(x, row_index);
                 }
                 else {
                     FileLocalStorageAddInsTR(x);
                 }
             }
         }


         function CheckaddMoreRowsIndividualFilesInsTR(x) {
             // for add image in each row
             //alert(x);
             var check = document.getElementById("FileInx" + x).innerHTML;

             //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
             //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
             //  alert(check);
             if (check == " ") {

                 var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                 if (Fevt != 'UPD') {
                     if (CheckFileUploaded(x) == true) {
                         document.getElementById("FileInx" + x).innerHTML = x;
                         document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                         AddFileUploadInsTR();
                         return false;
                     }
                 }
                 else {

                     document.getElementById("FileInx" + x).innerHTML = x;
                     document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                     AddFileUploadInsTR();
                     return false;
                 }
             }
             return false;
         }

         function FileLocalStorageAddInsTR(x) {

             var tbClientPermitFileUpload = localStorage.getItem("tbClientInsFileUploadTR");//Retrieve the stored data

             tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

             if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                 tbClientPermitFileUpload = [];


             var FilePath = document.getElementById("filePath" + x).innerHTML;
             var descrptn = document.getElementById("descrptn" + x).value;
             var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
             var Fevt = document.getElementById("FileEvt" + x).innerHTML;
             // alert('FilePath' + FilePath);
             //  alert('descrptn' + descrptn);
             if (Fevt == 'INS') {
                 var $addFile = jQuery.noConflict();
                 var client = JSON.stringify({
                     ROWID: "" + x + "",
                     DESCRPTN: "" + descrptn + "",
                     EVTACTION: "" + Fevt + "",
                     DTLID: "0"

                 });
             }
             else if (Fevt == 'UPD') {
                 var $addFile = jQuery.noConflict();
                 var client = JSON.stringify({
                     ROWID: "" + x + "",
                     DESCRPTN: "" + descrptn + "",
                     EVTACTION: "" + Fevt + "",
                     DTLID: "" + FdetailId + ""

                 });
             }


             tbClientPermitFileUpload.push(client);
             localStorage.setItem("tbClientInsFileUploadTR", JSON.stringify(tbClientPermitFileUpload));

             $addFile("#cphMain_HiddenField6_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));



             // alert("The PERMIT FILE ADDED.");
             // var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
             // alert(h);

             document.getElementById("FileSave" + x).innerHTML = "saved";
             //  alert('saved');
             return true;

         }

         function FileLocalStorageDeleteInsTR(row_index, x) {

             var $DelFile = jQuery.noConflict();
             var tbClientPermitFileUpload = localStorage.getItem("tbClientInsFileUploadTR");//Retrieve the stored data

             tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

             if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                 tbClientPermitFileUpload = [];



             // Using splice() we can specify the index to begin removing items, and the number of items to remove.
             tbClientPermitFileUpload.splice(row_index, 1);
             localStorage.setItem("tbClientInsFileUploadTR", JSON.stringify(tbClientPermitFileUpload));
             $DelFile("#cphMain_HiddenField6_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));
             //   alert("FILE deleted.");

             //var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
              // alert(h);


              var Fevt = document.getElementById("FileEvt" + x).innerHTML;
              if (Fevt == 'UPD') {
                  var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

                  if (FdetailId != '') {

                      DeleteFileLSTORAGEAddInsTR(x);
                  }

              }

              function DeleteFileLSTORAGEAddInsTR(x) {

                  var tbClientPermitFileUploadCancel = localStorage.getItem("tbClientInsFileUploadCancelTR");//Retrieve the stored data

                  tbClientPermitFileUploadCancel = JSON.parse(tbClientPermitFileUploadCancel); //Converts string to object

                  if (tbClientPermitFileUploadCancel == null) //If there is no data, initialize an empty array
                      tbClientPermitFileUploadCancel = [];


                  var FileName = document.getElementById("DbFileName" + x).innerHTML;
                  var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
                  var descrptn = document.getElementById("descrptn" + x).value;



                  var $addFile = jQuery.noConflict();
                  var client = JSON.stringify({
                      ROWID: "" + x + "",

                      DESCRPTN: "" + descrptn + "",
                      // EVTACTION: "" + Fevt + "",
                      DTLID: "" + FdetailId + ""

                  });

                  //alert('delete db');

                  tbClientPermitFileUploadCancel.push(client);
                  localStorage.setItem("tbClientInsFileUploadCancelTR", JSON.stringify(tbClientPermitFileUploadCancel));

                  $addFile("#cphMain_hiddenInsFileCanclDtlIdTR").val(JSON.stringify(tbClientPermitFileUploadCancel));





                  //document.getElementById("FileSave" + x).innerHTML = "saved";
                  //   alert('saved');
                  return true;

              }

          }
         FileLocalStorageEditPerTR
          function FileLocalStorageEditInsTR(x, row_index) {
              var tbClientPermitFileUpload = localStorage.getItem("tbClientInsFileUploadTR");//Retrieve the stored data

              tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

              if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                  tbClientPermitFileUpload = [];

              var FilePath = document.getElementById("filePath" + x).innerHTML;
              var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
              var descrptn = document.getElementById("descrptn" + x).value;
              var Fevt = document.getElementById("FileEvt" + x).innerHTML;

              if (Fevt == 'INS') {

                  var $FileE = jQuery.noConflict();
                  tbClientPermitFileUpload[row_index] = JSON.stringify({
                      ROWID: "" + x + "",

                      DESCRPTN: "" + descrptn + "",
                      EVTACTION: "" + Fevt + "",
                      DTLID: "0"
                  });//Alter the selected item on the table
              }
              else {

                  var $FileE = jQuery.noConflict();
                  tbClientPermitFileUpload[row_index] = JSON.stringify({
                      ROWID: "" + x + "",

                      DESCRPTN: "" + descrptn + "",
                      EVTACTION: "" + Fevt + "",
                      DTLID: "" + FdetailId + ""

                  });//Alter the selected item on the table



              }



              localStorage.setItem("tbClientInsFileUploadTR", JSON.stringify(tbClientPermitFileUpload));
              $FileE("#cphMain_HiddenField6_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));

              //alert("The FILE EDITED.");

              //var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
            //alert(h);
            return true;
        }
         //End:-For Trailer Attachment


         function EditAttachmentIns(editTransDtlId, EditFileName, EditActualFileName, EditDescription) {

             if (EditDescription == "") {
                 EditDescription = "--Description--";
             }
             var FrecRow = '<tr id="FilerowId_' + FileCounterIns + '" >';


             var labelForStyle = '<label for="file' + FileCounterIns + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
             var tdInner = labelForStyle + '<input   id="file' + FileCounterIns + '" name = "file' + FileCounterIns +

                            '" type="file" onchange="ChangeFileIns(' + FileCounterIns + ')" />';

             FrecRow += '<td style="width: 25%; display:none;" >' + tdInner + '</td>';

             var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

             FrecRow += '<td colspan="2"  id="filePath' + FileCounterIns + '" style="border-bottom: 1px dotted rgb(205, 237, 196);font-size: 14px;"' + '  >' + tdFileNameEdit + '</td  >';

               //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

               //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';



             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><textarea disabled id="descrptn' + FileCounterIns + '"    style="resize: none;border: 1px solid #ccc;height: 45px;font-family: calibri;"  MaxLength="50" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterIns + ');" onkeypress="return RemoveTag(event);"  onblur="blurTxtDescrptnIns(' + FileCounterIns + ');" onkeydown="textCounter(descrptn' + FileCounterIns + ',99);" onkeyup="textCounter(descrptn' + FileCounterIns + ',99);"></textarea></td>';
           if (document.getElementById("<%=hiddenIsInsurRenwed.ClientID%>").value == "") {
               FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterIns + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesIns(' + FileCounterIns + ');" style="  cursor: pointer;"></td>';
               FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadIns(' + FileCounterIns + ');"    style=" cursor: pointer;" ></td>';
           }
           else {
               FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterIns + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesIns(' + FileCounterIns + ');" style="  cursor: pointer;"></td>';
               FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadIns(' + FileCounterIns + ');"    style=" cursor: pointer;" ></td>';
           }
             FrecRow += ' <td id="FileInx' + FileCounterIns + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterIns + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterIns + '" style="display: none;">UPD</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterIns + '" style="display: none;">' + editTransDtlId + '</td>';
             FrecRow += '<td id="DbFileName' + FileCounterIns + '" style="display: none;">' + EditFileName + '</td>';
             FrecRow += '</tr>';

             jQuery('#TableFileUploadContainerInsurance').append(FrecRow);
             document.getElementById("descrptn" + FileCounterIns).value = EditDescription;

             document.getElementById("FileInx" + FileCounterIns).innerHTML = FileCounterIns;
             document.getElementById("FileIndvlAddMoreRow" + FileCounterIns).style.opacity = "0.3";
               // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
             FileLocalStorageAddIns(FileCounterIns);
             FileCounterIns++;

         }


         function EditAttachmentVhcl(editTransDtlId, EditFileName, EditActualFileName, EditDescription) {

             if (EditDescription == "") {
                 EditDescription = "--Description--";
             }
             var FrecRow = '<tr id="FilerowId_' + FileCounterVhcl + '" >';


             var labelForStyle = '<label for="file' + FileCounterVhcl + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
             var tdInner = labelForStyle + '<input   id="file' + FileCounterVhcl + '" name = "file' + FileCounterVhcl +

                            '" type="file" onchange="ChangeFileVhcl(' + FileCounterVhcl + ')" />';

             FrecRow += '<td style="width: 25%; display:none;" >' + tdInner + '</td>';

             var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

             FrecRow += '<td colspan="2"  id="filePath' + FileCounterVhcl + '" style="border-bottom: 1px dotted rgb(205, 237, 196);font-size: 14px;"' + '  >' + tdFileNameEdit + '</td  >';

               //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

               //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><textarea disabled id="descrptn' + FileCounterVhcl + '"    style="resize: none;border: 1px solid #ccc;height: 45px;font-family: calibri;"  MaxLength="50" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterVhcl + ');" onkeypress="return RemoveTag(event);"  onblur="blurTxtDescrptnVhcl(' + FileCounterVhcl + ');" onkeydown="textCounter(descrptn' + FileCounterVhcl + ',99);" onkeyup="textCounter(descrptn' + FileCounterVhcl + ',99);"></textarea></td>';
             FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterVhcl + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesVhcl(' + FileCounterVhcl + ');" style="  cursor: pointer;"></td>';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadVhcl(' + FileCounterVhcl + ');"    style=" cursor: pointer;" ></td>';

             FrecRow += ' <td id="FileInx' + FileCounterVhcl + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterVhcl + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterVhcl + '" style="display: none;">UPD</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterVhcl + '" style="display: none;">' + editTransDtlId + '</td>';
             FrecRow += '<td id="DbFileName' + FileCounterVhcl + '" style="display: none;">' + EditFileName + '</td>';
             FrecRow += '</tr>';

             jQuery('#TableFileUploadContainerVehicleImg').append(FrecRow);
             document.getElementById("descrptn" + FileCounterVhcl).value = EditDescription;

             document.getElementById("FileInx" + FileCounterVhcl).innerHTML = FileCounterVhcl;
             document.getElementById("FileIndvlAddMoreRow" + FileCounterVhcl).style.opacity = "0.3";
               // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
             FileLocalStorageAddVhcl(FileCounterVhcl);
             FileCounterVhcl++;

         }

         function ViewAttachmentPer(editTransDtlId, EditFileName, EditActualFileName, EditDescription) {
             if (EditDescription == "") {
                 EditDescription = "--Description--";
             }
             var FrecRow = '<tr id="FilerowId_' + FileCounterPer + '" >';


             var labelForStyle = '<label for="file' + FileCounterPer + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
             var tdInner = labelForStyle + '<input   id="file' + FileCounterPer + '" name = "file' + FileCounterPer +

                            '" type="file" onchange="ChangeFilePer(' + FileCounterPer + ')" />';

             FrecRow += '<td style="width: 25%; display:none;" >' + tdInner + '</td>';

             var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

             FrecRow += '<td colspan="2"  id="filePath' + FileCounterPer + '" style="font-size: 14px;"  >' + tdFileNameEdit + '</td  >';

              //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

              //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><textarea disabled id="descrptn' + FileCounterPer + '"   style="resize: none;border: 1px solid #ccc;height: 45px;font-family: calibri;"  MaxLength="50" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterPer + ');" onkeypress="return RemoveTag(event);"  onblur="blurTxtDescrptnPer(' + FileCounterPer + ');" onkeydown="textCounter(descrptn' + FileCounterPer + ',99);" onkeyup="textCounter(descrptn' + FileCounterPer + ',99);"></textarea></td>';
             FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterPer + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesPer(' + FileCounterPer + ');" style="  cursor: pointer;"></td>';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadPer(' + FileCounterPer + ');"    style=" cursor: pointer;" ></td>';

             FrecRow += ' <td id="FileInx' + FileCounterPer + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterPer + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterPer + '" style="display: none;">UPD</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterPer + '" style="display: none;">' + editTransDtlId + '</td>';
             FrecRow += '<td id="DbFileName' + FileCounterPer + '" style="display: none;">' + EditFileName + '</td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadContainerPermit').append(FrecRow);
            document.getElementById("descrptn" + FileCounterPer).value = EditDescription;

            document.getElementById("FileInx" + FileCounterPer).innerHTML = FileCounterPer;
            document.getElementById("FileIndvlAddMoreRow" + FileCounterPer).style.opacity = "0.3";
              // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
            FileLocalStorageAddPer(FileCounterPer);
            FileCounterPer++;

         }

         function ViewAttachmentIns(editTransDtlId, EditFileName, EditActualFileName, EditDescription) {
             if (EditDescription == "") {
                 EditDescription = "--Description--";
             }
             var FrecRow = '<tr id="FilerowId_' + FileCounterIns + '" >';


             var labelForStyle = '<label for="file' + FileCounterIns + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
             var tdInner = labelForStyle + '<input   id="file' + FileCounterIns + '" name = "file' + FileCounterIns +

                            '" type="file" onchange="ChangeFileIns(' + FileCounterIns + ')" />';

             FrecRow += '<td style="width: 25%; display:none;" >' + tdInner + '</td>';

             var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

             FrecRow += '<td colspan="2"  id="filePath' + FileCounterIns + '" style="font-size: 14px;"  >' + tdFileNameEdit + '</td  >';

             //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

             //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><textarea disabled id="descrptn' + FileCounterIns + '"    style="resize: none;border: 1px solid #ccc;height: 45px;font-family: calibri;"  MaxLength="50" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterIns + ');" onkeypress="return RemoveTag(event);"  onblur="blurTxtDescrptnIns(' + FileCounterIns + ');" onkeydown="textCounter(descrptn' + FileCounterIns + ',99);" onkeyup="textCounter(descrptn' + FileCounterIns + ',99);"></textarea></td>';
             FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterIns + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesIns(' + FileCounterIns + ');" style="  cursor: pointer;"></td>';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadIns(' + FileCounterIns + ');"    style=" cursor: pointer;" ></td>';

             FrecRow += ' <td id="FileInx' + FileCounterIns + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterIns + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterIns + '" style="display: none;">UPD</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterIns + '" style="display: none;">' + editTransDtlId + '</td>';
             FrecRow += '<td id="DbFileName' + FileCounterIns + '" style="display: none;">' + EditFileName + '</td>';
             FrecRow += '</tr>';

             jQuery('#TableFileUploadContainerInsurance').append(FrecRow);

             document.getElementById("descrptn" + FileCounterIns).value = EditDescription;
             document.getElementById("FileInx" + FileCounterIns).innerHTML = FileCounterIns;
             document.getElementById("FileIndvlAddMoreRow" + FileCounterIns).style.opacity = "0.3";
             // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
             FileLocalStorageAddIns(FileCounterIns);
             FileCounterIns++;

         }

         function ViewAttachmentVhcl(editTransDtlId, EditFileName, EditActualFileName, EditDescription) {
             if (EditDescription == "") {
                 EditDescription = "--Description--";
             }
             var FrecRow = '<tr id="FilerowId_' + FileCounterVhcl + '" >';


             var labelForStyle = '<label for="file' + FileCounterVhcl + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
             var tdInner = labelForStyle + '<input   id="file' + FileCounterVhcl + '" name = "file' + FileCounterVhcl +

                            '" type="file" onchange="ChangeFileVhcl(' + FileCounterVhcl + ')" />';

             FrecRow += '<td style="width: 25%; display:none;" >' + tdInner + '</td>';

             var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

             FrecRow += '<td colspan="2"  id="filePath' + FileCounterVhcl + '" style="font-size: 14px;"  >' + tdFileNameEdit + '</td  >';

             //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

             //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><textarea disabled id="descrptn' + FileCounterVhcl + '"   style="resize: none;border: 1px solid #ccc;height: 45px;font-family: calibri;"  MaxLength="50" value="' + EditDescription + '" onfocus="focusTxtDescrptn(' + FileCounterVhcl + ');" onkeypress="return RemoveTag(event);"  onblur="blurTxtDescrptnVhcl(' + FileCounterVhcl + ');" onkeydown="textCounter(descrptn' + FileCounterVhcl + ',99);" onkeyup="textCounter(descrptn' + FileCounterVhcl + ',99);"></textarea></td>';
             FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterVhcl + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesVhcl(' + FileCounterVhcl + ');" style="  cursor: pointer;"></td>';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" disabled type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadvhcl(' + FileCounterVhcl + ');"    style=" cursor: pointer;" ></td>';

             FrecRow += ' <td id="FileInx' + FileCounterVhcl + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterVhcl + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterVhcl + '" style="display: none;">UPD</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterVhcl + '" style="display: none;">' + editTransDtlId + '</td>';
             FrecRow += '<td id="DbFileName' + FileCounterVhcl + '" style="display: none;">' + EditFileName + '</td>';
             FrecRow += '</tr>';

             jQuery('#TableFileUploadContainerVehicleImg').append(FrecRow);

             document.getElementById("descrptn" + FileCounterVhcl).value = EditDescription;
             document.getElementById("FileInx" + FileCounterVhcl).innerHTML = FileCounterVhcl;
             document.getElementById("FileIndvlAddMoreRow" + FileCounterVhcl).style.opacity = "0.3";
             // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
             FileLocalStorageAddVhcl(FileCounterVhcl);
             FileCounterVhcl++;

         }
         function AddFileUploadIns() {
            
             var FrecRow = '<tr id="FilerowId_' + FileCounterIns + '" >';


             var labelForStyle = '<label for="file' + FileCounterIns + '" class="custom-file-upload" style="margin-left: 0%;"> <img src="/Images/Icons/cloud_upload.jpg"></img>Upload Document</label>';
             var tdInner = labelForStyle + '<input   id="file' + FileCounterIns + '" name = "file' + FileCounterIns +

                            '" type="file" onchange="ChangeFileIns(' + FileCounterIns + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/>';

             FrecRow += '<td style="width: 30%;" >' + tdInner + '</td>';

             FrecRow += '<td style="word-break: break-all;font-size: 14px;" id="filePath' + FileCounterIns + '"  ></td  >';

             //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

             //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><textarea id="descrptn' + FileCounterIns + '"    style="resize: none;border: 1px solid #ccc;height: 45px;font-family: calibri;"  MaxLength="50" value="--Description--" onfocus="focusTxtDescrptn(' + FileCounterIns + ');" onkeypress="return RemoveTag(event);"  onblur="blurTxtDescrptnIns(' + FileCounterIns + ');" onkeydown="textCounter(descrptn' + FileCounterIns + ',99);" onkeyup="textCounter(descrptn' + FileCounterIns + ',99);"></textarea></td>';
             FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterIns + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesIns(' + FileCounterIns + ');" style="  cursor: pointer;"></td>';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadIns(' + FileCounterIns + ');"    style=" cursor: pointer;" ></td>';

             FrecRow += ' <td id="FileInx' + FileCounterIns + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterIns + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterIns + '" style="display: none;">INS</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterIns + '" style="display: none;"></td>';
             FrecRow += '<td id="DbFileName' + FileCounterIns + '" style="display: none;"></td>';
             FrecRow += '</tr>';

             jQuery('#TableFileUploadContainerInsurance').append(FrecRow);
             document.getElementById("descrptn" + FileCounterIns).value = "--Description--";
             document.getElementById('filePath' + FileCounterIns).innerHTML = 'No File Uploaded';
             FileCounterIns++;

           
         }
         function AddFileUploadVhcl() {

             var FrecRow = '<tr id="FilerowId_' + FileCounterVhcl + '" >';


             var labelForStyle = '<label for="file' + FileCounterVhcl + '" class="custom-file-upload" style="margin-left: 0%;"> <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
             var tdInner = labelForStyle + '<input   id="file' + FileCounterVhcl + '" name = "file' + FileCounterVhcl +

                            '" type="file" onchange="ChangeFileVhcl(' + FileCounterVhcl + ');" accept="image/*"/>';

             FrecRow += '<td style="width: 23%;" >' + tdInner + '</td>';

             FrecRow += '<td style="word-break: break-all;font-size: 14px;" id="filePath' + FileCounterVhcl + '"  ></td  >';

             //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

             //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><textarea id="descrptn' + FileCounterVhcl + '"    style="resize: none;border: 1px solid #ccc;height: 45px;font-family: calibri;"  MaxLength="50" value="--Description--" onfocus="focusTxtDescrptn(' + FileCounterVhcl + ');" onkeypress="return RemoveTag(event);"  onblur="blurTxtDescrptnVhcl(' + FileCounterVhcl + ');" onkeydown="textCounter(descrptn' + FileCounterVhcl + ',99);" onkeyup="textCounter(descrptn' + FileCounterVhcl + ',99);"></textarea></td>';
             FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterVhcl + '"  style="width: 1.5%; padding-left: 4px;"> <input title="Add" type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesVhcl(' + FileCounterVhcl + ');" style="  cursor: pointer;"></td>';
             FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input title="Delete" type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadVhcl(' + FileCounterVhcl + ');"    style=" cursor: pointer;" ></td>';

             FrecRow += ' <td id="FileInx' + FileCounterVhcl + '" style="display: none;" > </td>';
             FrecRow += '<td id="FileSave' + FileCounterVhcl + '" style="display: none;"> </td>';
             FrecRow += '<td id="FileEvt' + FileCounterVhcl + '" style="display: none;">INS</td>';
             FrecRow += '<td id="FileDtlId' + FileCounterVhcl + '" style="display: none;"></td>';
             FrecRow += '<td id="DbFileName' + FileCounterVhcl + '" style="display: none;"></td>';
             FrecRow += '</tr>';

             jQuery('#TableFileUploadContainerVehicleImg').append(FrecRow);
             document.getElementById("descrptn" + FileCounterVhcl).value = "--Description--";
             document.getElementById('filePath' + FileCounterVhcl).innerHTML = 'No File Uploaded';
             FileCounterVhcl++;


         }


       


        function RemoveFileUploadPer(removeNum) {
            if (confirm("Are you Sure you want to Delete Selected File?")) {
             
                var Filerow_index = jQuery('#FilerowId_' + removeNum).index();
                
                FileLocalStorageDeletePer(Filerow_index, removeNum);
                jQuery('#FilerowId_' + removeNum).remove();


               

                // alert(Filerow_index);
              
                var TableFileRowCount = document.getElementById("TableFileUploadContainerPermit").rows.length;

                    if (TableFileRowCount != 0) {
                        var idlast = $noC('#TableFileUploadContainerPermit tr:last').attr('id');
                        //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                        //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                        if (idlast != "") {
                            var res = idlast.split("_");
                            //  alert(res[1]);
                            document.getElementById("FileInx" + res[1]).innerHTML = " ";
                            document.getElementById("FileIndvlAddMoreRow" + res[1]).style.opacity = "1";
                        }
                    }
                    else {
                        AddFileUploadPer();


                    }
               

              
               
            }
            else {

                return false;
            }
        }

        function RemoveFileUploadIns(removeNum) {
            if (confirm("Are you Sure you want to Delete Selected File?")) {
                //  alert('ASD');
                var Filerow_index = jQuery('#FilerowId_' + removeNum).index();
                FileLocalStorageDeleteIns(Filerow_index, removeNum);
                jQuery('#FilerowId_' + removeNum).remove();




                // alert(Filerow_index);

                var TableFileRowCount = document.getElementById("TableFileUploadContainerInsurance").rows.length;

                if (TableFileRowCount != 0) {
                    var idlast = $noC('#TableFileUploadContainerInsurance tr:last').attr('id');
                    //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                    //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                    if (idlast != "") {
                        var res = idlast.split("_");
                        //  alert(res[1]);
                        document.getElementById("FileInx" + res[1]).innerHTML = " ";
                        document.getElementById("FileIndvlAddMoreRow" + res[1]).style.opacity = "1";
                    }
                }
                else {
                    AddFileUploadIns();


                }




            }
            else {

                return false;
            }
        }
        function RemoveFileUploadVhcl(removeNum) {
            if (confirm("Are you Sure you want to Delete Selected File?")) {
                //  alert('ASD');
                var Filerow_index = jQuery('#FilerowId_' + removeNum).index();
                FileLocalStorageDeleteVhcl(Filerow_index, removeNum);
                jQuery('#FilerowId_' + removeNum).remove();




                // alert(Filerow_index);

                var TableFileRowCount = document.getElementById("TableFileUploadContainerVehicleImg").rows.length;

                if (TableFileRowCount != 0) {
                    var idlast = $noC('#TableFileUploadContainerVehicleImg tr:last').attr('id');
                    //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                    //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                    if (idlast != "") {
                        var res = idlast.split("_");
                        //  alert(res[1]);
                        document.getElementById("FileInx" + res[1]).innerHTML = " ";
                        document.getElementById("FileIndvlAddMoreRow" + res[1]).style.opacity = "1";
                    }
                }
                else {
                    AddFileUploadVhcl();


                }




            }
            else {

                return false;
            }
        }

        function ChangeFilePer(x) {
            if (ClearDivDisplayImage1(x)) {
                IncrmntConfrmCounter();
                if (document.getElementById('file' + x).value != "") {
                    document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;

                }
                else {
                    document.getElementById('filePath' + x).innerHTML = 'No File Uploaded';


                }
                var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                //   alert('hi SavedorNot' + SavedorNot);
                if (SavedorNot == "saved") {
                    var row_index = jQuery('#FilerowId_' + x).index();
                    FileLocalStorageEditPer(x, row_index);
                }
                else {
                    FileLocalStorageAddPer(x);
                }
            }
        }
        function ChangeFileIns(x) {
            if (ClearDivDisplayImage1(x)) {
                IncrmntConfrmCounter();
                if (document.getElementById('file' + x).value != "") {
                    document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;

                }
                else {
                    document.getElementById('filePath' + x).innerHTML = 'No File Uploaded';


                }
                var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                //   alert('hi SavedorNot' + SavedorNot);
                if (SavedorNot == "saved") {
                    var row_index = jQuery('#FilerowId_' + x).index();
                    FileLocalStorageEditIns(x, row_index);
                }
                else {
                    FileLocalStorageAddIns(x);
                }
            }
        }

     
        function ClearDivDisplayImage1(x) {

            var fuData = document.getElementById('file' + x);
            var FileUploadPath = fuData.value;
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();



            if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                        || Extension == "jpeg" || Extension == "jpg" || Extension == "xlsx" || Extension == "xls" || Extension == "doc" ||
                Extension == "docx" || Extension == "csv" || Extension == "ppt" || Extension == "pptx"
               || Extension == "txt" || Extension == "pdf") {


                return true;

            }
            else {
                document.getElementById('file' + x).value = "";
                document.getElementById('filePath' + x).innerHTML = 'No File Selected';
                alert("The specified file type could not be uploaded.Only support image files and document files");
                return false;
            }
        }
        function ClearDivDisplayImage(x) {

            var fuData = document.getElementById('file' + x);
            var FileUploadPath = fuData.value;
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();



            if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                        || Extension == "jpeg" || Extension == "jpg") {
               

                return true;

                }
                else {
                    document.getElementById('file' + x).value = "";
                    document.getElementById('filePath' + x).innerHTML = 'No File Selected';
                    alert("The specified file type could not be uploaded.Only support image files");
                    return false;
                }
            }
        function ChangeFileVhcl(x) {
            if (ClearDivDisplayImage(x)) {
                IncrmntConfrmCounter();
                if (document.getElementById('file' + x).value != "") {

                    document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;

                }

                else {
                    document.getElementById('filePath' + x).innerHTML = 'No File Uploaded';


                }
                var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                //   alert('hi SavedorNot' + SavedorNot);
                if (SavedorNot == "saved") {
                    var row_index = jQuery('#FilerowId_' + x).index();
                    FileLocalStorageEditVhcl(x, row_index);
                }
                else {
                    FileLocalStorageAddVhcl(x);
                }
            }
        }
        function CheckFileUploaded(x) {

            if (document.getElementById('file' + x).value != "") {
                return true;
            }
            else {
                return false;
            }


        }
        function CheckaddMoreRowsIndividualFilesPer(x) {
            // for add image in each row

            var check = document.getElementById("FileInx" + x).innerHTML;

            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            //  alert(check);
            if (check == " ") {

                var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                if (Fevt != 'UPD') {
                    if (CheckFileUploaded(x) == true) {
                        document.getElementById("FileInx" + x).innerHTML = x;
                        document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                        AddFileUploadPer();
                        
                        return false;
                    }
                }
                else {

                    document.getElementById("FileInx" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                    AddFileUploadPer();
                    
                    return false;
                }
            }
            return false;
        }
        function CheckaddMoreRowsIndividualFilesIns(x) {
            // for add image in each row
           // alert(x);
            var check = document.getElementById("FileInx" + x).innerHTML;

            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            //  alert(check);
            if (check == " ") {

                var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                if (Fevt != 'UPD') {
                    if (CheckFileUploaded(x) == true) {
                        document.getElementById("FileInx" + x).innerHTML = x;
                        document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                        AddFileUploadIns();
                        return false;
                    }
                }
                else {

                    document.getElementById("FileInx" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                    AddFileUploadIns();
                    return false;
                }
            }
            return false;
        }
        function CheckaddMoreRowsIndividualFilesVhcl(x) {
            // for add image in each row
            //alert(x);
            var check = document.getElementById("FileInx" + x).innerHTML;

            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            //  alert(check);
            if (check == " ") {

                var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                if (Fevt != 'UPD') {
                    if (CheckFileUploaded(x) == true) {
                        document.getElementById("FileInx" + x).innerHTML = x;
                        document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                        AddFileUploadVhcl();
                        return false;
                    }
                }
                else {

                    document.getElementById("FileInx" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                    AddFileUploadVhcl();
                    return false;
                }
            }
            return false;
        }
        function focusTxtDescrptn(x) {
            if (document.getElementById("descrptn" + x).value == "--Description--")
                document.getElementById("descrptn" + x).value = "";




        }


      



        function blurTxtDescrptnPerTR(x) {
            var val = document.getElementById("descrptn" + x).value;
            if (val == "") {
                document.getElementById("descrptn" + x).value = "--Description--";
            }
            else {
                if (val != "--Description--") {
                    IncrmntConfrmCounter();
                    var WithoutReplace = val;

                    var replaceText1 = WithoutReplace.replace(/</g, "");
                    var replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("descrptn" + x).value = replaceText2.trim();
                }
                var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                if (SavedorNot == "saved") {
                    var row_index = jQuery('#FilerowId_' + x).index();
                    FileLocalStorageEditPerTR(x, row_index);
                }
            }
        }
        function blurTxtDescrptnInsTR(x) {
            var val = document.getElementById("descrptn" + x).value;
            if (val == "") {
                document.getElementById("descrptn" + x).value = "--Description--";
            }
            else {
                if (val != "--Description--") {
                    IncrmntConfrmCounter();
                    var WithoutReplace = val;

                    var replaceText1 = WithoutReplace.replace(/</g, "");
                    var replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("descrptn" + x).value = replaceText2.trim();
                }
                var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                if (SavedorNot == "saved") {
                    var row_index = jQuery('#FilerowId_' + x).index();
                    FileLocalStorageEditInsTR(x, row_index);
                }
            }
        }





        function blurTxtDescrptnPer(x) {
            var val = document.getElementById("descrptn" + x).value;
            if (val == "") {
                document.getElementById("descrptn" + x).value = "--Description--";
            }
            else {
                if (val != "--Description--") {
                    IncrmntConfrmCounter();
                    var WithoutReplace = val;

                    var replaceText1 = WithoutReplace.replace(/</g, "");
                    var replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("descrptn" + x).value = replaceText2.trim();
                }
                var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                if (SavedorNot == "saved") {
                    var row_index = jQuery('#FilerowId_' + x).index();
                    FileLocalStorageEditPer(x, row_index);
                }
            }
        }
        function blurTxtDescrptnIns(x) {
            var val = document.getElementById("descrptn" + x).value;
            if (val == "") {
                document.getElementById("descrptn" + x).value = "--Description--";
            }
            else {
                if (val != "--Description--") {
                    IncrmntConfrmCounter();
                    var WithoutReplace = val;

                    var replaceText1 = WithoutReplace.replace(/</g, "");
                    var replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("descrptn" + x).value = replaceText2.trim();
                }
                var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                if (SavedorNot == "saved") {
                    var row_index = jQuery('#FilerowId_' + x).index();
                    FileLocalStorageEditIns(x, row_index);
                }
            }
        }
        function blurTxtDescrptnVhcl(x) {
            var val = document.getElementById("descrptn" + x).value;
            if (val == "") {
                document.getElementById("descrptn" + x).value = "--Description--";
            }
            else {
                if (val != "--Description--") {
                    IncrmntConfrmCounter();
                    var WithoutReplace = val;

                    var replaceText1 = WithoutReplace.replace(/</g, "");
                    var replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("descrptn" + x).value = replaceText2.trim();
                }
                var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                if (SavedorNot == "saved") {
                    var row_index = jQuery('#FilerowId_' + x).index();
                    FileLocalStorageEditVhcl(x, row_index);
                }
            }
        }
        // for not allowing enter
        function DisableEnter(evt) {
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


        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }

        function RemoveTag(evt) {

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }
         </script>
   
    <script>
        //For permit files
        function FileLocalStorageAddPer(x) {

            var tbClientPermitFileUpload = localStorage.getItem("tbClientPermitFileUpload");//Retrieve the stored data

            tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

            if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                tbClientPermitFileUpload = [];


            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var descrptn = document.getElementById("descrptn" + x).value;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            // alert('FilePath' + FilePath);
            //  alert('descrptn' + descrptn);
            if (Fevt == 'INS') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",                   
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"

                });
            }
            else if (Fevt == 'UPD') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });
            }


            tbClientPermitFileUpload.push(client);
            localStorage.setItem("tbClientPermitFileUpload", JSON.stringify(tbClientPermitFileUpload));

            $addFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));



          // alert("The PERMIT FILE ADDED.");
           // var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
           // alert(h);

            document.getElementById("FileSave" + x).innerHTML = "saved";
            //  alert('saved');
            return true;

        }

        function FileLocalStorageDeletePer(row_index, x) {

            var $DelFile = jQuery.noConflict();
            var tbClientPermitFileUpload = localStorage.getItem("tbClientPermitFileUpload");//Retrieve the stored data

            tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

            if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                tbClientPermitFileUpload = [];



            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            tbClientPermitFileUpload.splice(row_index, 1);
            localStorage.setItem("tbClientPermitFileUpload", JSON.stringify(tbClientPermitFileUpload));
            $DelFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));
            //   alert("FILE deleted.");

            //var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
            // alert(h);


            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            if (Fevt == 'UPD') {
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

                if (FdetailId != '') {

                    DeleteFileLSTORAGEAddPer(x);
                }

            }

            function DeleteFileLSTORAGEAddPer(x) {

                var tbClientPermitFileUploadCancel = localStorage.getItem("tbClientPermitFileUploadCancel");//Retrieve the stored data

                tbClientPermitFileUploadCancel = JSON.parse(tbClientPermitFileUploadCancel); //Converts string to object

                if (tbClientPermitFileUploadCancel == null) //If there is no data, initialize an empty array
                    tbClientPermitFileUploadCancel = [];


                var FileName = document.getElementById("DbFileName" + x).innerHTML;
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
                var descrptn = document.getElementById("descrptn" + x).value;



                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                   
                    DESCRPTN: "" + descrptn + "",
                    // EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });

                //alert('delete db');

                tbClientPermitFileUploadCancel.push(client);
                localStorage.setItem("tbClientPermitFileUploadCancel", JSON.stringify(tbClientPermitFileUploadCancel));

                $addFile("#cphMain_hiddenPerFileCanclDtlId").val(JSON.stringify(tbClientPermitFileUploadCancel));





                //document.getElementById("FileSave" + x).innerHTML = "saved";
                //   alert('saved');
                return true;

            }

        }

        function FileLocalStorageEditPer(x, row_index) {
            var tbClientPermitFileUpload = localStorage.getItem("tbClientPermitFileUpload");//Retrieve the stored data

            tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

            if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                tbClientPermitFileUpload = [];

            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var descrptn = document.getElementById("descrptn" + x).value;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;

            if (Fevt == 'INS') {

                var $FileE = jQuery.noConflict();
                tbClientPermitFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                   
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"
                });//Alter the selected item on the table
            }
            else {

                var $FileE = jQuery.noConflict();
                tbClientPermitFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                  
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });//Alter the selected item on the table



            }



            localStorage.setItem("tbClientPermitFileUpload", JSON.stringify(tbClientPermitFileUpload));
            $FileE("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));

            //alert("The FILE EDITED.");

            //var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
            //alert(h);
            return true;
        }
        //for insurance files
        function FileLocalStorageAddIns(x) {

            var tbClientInsurFileUpload = localStorage.getItem("tbClientInsurFileUpload");//Retrieve the stored data

            tbClientInsurFileUpload = JSON.parse(tbClientInsurFileUpload); //Converts string to object

            if (tbClientInsurFileUpload == null) //If there is no data, initialize an empty array
                tbClientInsurFileUpload = [];


            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var descrptn = document.getElementById("descrptn" + x).value;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            // alert('FilePath' + FilePath);
            //  alert('descrptn' + descrptn);
            if (Fevt == 'INS') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                   
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"

                });
            }
            else if (Fevt == 'UPD') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                  
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });
            }


            tbClientInsurFileUpload.push(client);
            localStorage.setItem("tbClientInsurFileUpload", JSON.stringify(tbClientInsurFileUpload));

            $addFile("#cphMain_HiddenField3_FileUpload").val(JSON.stringify(tbClientInsurFileUpload));



           //alert("The INSURANCE FILE ADDED.");
          // var h = document.getElementById("<%=HiddenField3_FileUpload.ClientID%>").value;
           // alert(h);

            document.getElementById("FileSave" + x).innerHTML = "saved";
             //  alert('saved');
            return true;

        }

        function FileLocalStorageDeleteIns(row_index, x) {

            var $DelFile = jQuery.noConflict();
            var tbClientInsurFileUpload = localStorage.getItem("tbClientInsurFileUpload");//Retrieve the stored data

            tbClientInsurFileUpload = JSON.parse(tbClientInsurFileUpload); //Converts string to object

            if (tbClientInsurFileUpload == null) //If there is no data, initialize an empty array
                tbClientInsurFileUpload = [];



            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            tbClientInsurFileUpload.splice(row_index, 1);
            localStorage.setItem("tbClientInsurFileUpload", JSON.stringify(tbClientInsurFileUpload));
            $DelFile("#cphMain_HiddenField3_FileUpload").val(JSON.stringify(tbClientInsurFileUpload));
            //   alert("FILE deleted.");

            //   var h = document.getElementById("<%=HiddenField3_FileUpload.ClientID%>").value;
            //  alert(h);


            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            if (Fevt == 'UPD') {
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

                if (FdetailId != '') {

                    DeleteFileLSTORAGEAddIns(x);
                }

            }

            function DeleteFileLSTORAGEAddIns(x) {

                var tbClientInsurFileUploadCancel = localStorage.getItem("tbClientInsurFileUploadCancel");//Retrieve the stored data

                tbClientInsurFileUploadCancel = JSON.parse(tbClientInsurFileUploadCancel); //Converts string to object

                if (tbClientInsurFileUploadCancel == null) //If there is no data, initialize an empty array
                    tbClientInsurFileUploadCancel = [];


                var FileName = document.getElementById("DbFileName" + x).innerHTML;
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
                var descrptn = document.getElementById("descrptn" + x).value;



                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                  
                    DESCRPTN: "" + descrptn + "",
                    // EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });



                tbClientInsurFileUploadCancel.push(client);
                localStorage.setItem("tbClientInsurFileUploadCancel", JSON.stringify(tbClientInsurFileUploadCancel));

                $addFile("#cphMain_hiddenInsFileCanclDtlId").val(JSON.stringify(tbClientInsurFileUploadCancel));





                //document.getElementById("FileSave" + x).innerHTML = "saved";
                //   alert('saved');
                return true;

            }

        }

        function FileLocalStorageEditIns(x, row_index) {
            var tbClientInsurFileUpload = localStorage.getItem("tbClientInsurFileUpload");//Retrieve the stored data

            tbClientInsurFileUpload = JSON.parse(tbClientInsurFileUpload); //Converts string to object

            if (tbClientInsurFileUpload == null) //If there is no data, initialize an empty array
                tbClientInsurFileUpload = [];

            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var descrptn = document.getElementById("descrptn" + x).value;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;

            if (Fevt == 'INS') {

                var $FileE = jQuery.noConflict();
                tbClientInsurFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                   
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"
                });//Alter the selected item on the table
            }
            else {

                var $FileE = jQuery.noConflict();
                tbClientInsurFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                   
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });//Alter the selected item on the table



            }



            localStorage.setItem("tbClientInsurFileUpload", JSON.stringify(tbClientInsurFileUpload));
            $FileE("#cphMain_HiddenField3_FileUpload").val(JSON.stringify(tbClientInsurFileUpload));

            //alert("The FILE EDITED.");

            //var h = document.getElementById("<%=HiddenField3_FileUpload.ClientID%>").value;
            //alert(h);
            return true;
        }
        //for vehicle images
        function FileLocalStorageAddVhcl(x) {

            var tbClientVehicleFileUpload = localStorage.getItem("tbClientVehicleFileUpload");//Retrieve the stored data

            tbClientVehicleFileUpload = JSON.parse(tbClientVehicleFileUpload); //Converts string to object

            if (tbClientVehicleFileUpload == null) //If there is no data, initialize an empty array
                tbClientVehicleFileUpload = [];


            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var descrptn = document.getElementById("descrptn" + x).value;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            // alert('FilePath' + FilePath);
            //  alert('descrptn' + descrptn);
            if (Fevt == 'INS') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                   
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"

                });
            }
            else if (Fevt == 'UPD') {
                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                  
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });
            }


            tbClientVehicleFileUpload.push(client);
            localStorage.setItem("tbClientVehicleFileUpload", JSON.stringify(tbClientVehicleFileUpload));

            $addFile("#cphMain_HiddenField4_FileUpload").val(JSON.stringify(tbClientVehicleFileUpload));



           // alert("The VEHICLE FILE ADDED.");
           // var h = document.getElementById("<%=HiddenField4_FileUpload.ClientID%>").value;
           // alert(h);

            document.getElementById("FileSave" + x).innerHTML = "saved";
            //  alert('saved');
            return true;

        }

        function FileLocalStorageDeleteVhcl(row_index, x) {
            var $DelFile = jQuery.noConflict();
            var tbClientVehicleFileUpload = localStorage.getItem("tbClientVehicleFileUpload");//Retrieve the stored data

            tbClientVehicleFileUpload = JSON.parse(tbClientVehicleFileUpload); //Converts string to object

            if (tbClientVehicleFileUpload == null) //If there is no data, initialize an empty array
                tbClientVehicleFileUpload = [];



            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            tbClientVehicleFileUpload.splice(row_index, 1);
            localStorage.setItem("tbClientVehicleFileUpload", JSON.stringify(tbClientVehicleFileUpload));
            $DelFile("#cphMain_HiddenField4_FileUpload").val(JSON.stringify(tbClientVehicleFileUpload));
            //   alert("FILE deleted.");

            //   var h = document.getElementById("<%=HiddenField4_FileUpload.ClientID%>").value;
            //  alert(h);


            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            if (Fevt == 'UPD') {
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

                if (FdetailId != '') {

                    DeleteFileLSTORAGEAddVhcl(x);
                }

            }


            function DeleteFileLSTORAGEAddVhcl(x) {

                var tbClientVehicleFileUploadCancel = localStorage.getItem("tbClientVehicleFileUploadCancel");//Retrieve the stored data

                tbClientVehicleFileUploadCancel = JSON.parse(tbClientVehicleFileUploadCancel); //Converts string to object

                if (tbClientVehicleFileUploadCancel == null) //If there is no data, initialize an empty array
                    tbClientVehicleFileUploadCancel = [];


                var FileName = document.getElementById("DbFileName" + x).innerHTML;
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
                var descrptn = document.getElementById("descrptn" + x).value;



                var $addFile = jQuery.noConflict();
                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    
                    DESCRPTN: "" + descrptn + "",
                    // EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });



                tbClientVehicleFileUploadCancel.push(client);
                localStorage.setItem("tbClientVehicleFileUploadCancel", JSON.stringify(tbClientVehicleFileUploadCancel));

                $addFile("#cphMain_hiddenVhclFileCanclDtlId").val(JSON.stringify(tbClientVehicleFileUploadCancel));





                //document.getElementById("FileSave" + x).innerHTML = "saved";
                //   alert('saved');
                return true;

            }

        }

        function FileLocalStorageEditVhcl(x, row_index) {
            var tbClientVehicleFileUpload = localStorage.getItem("tbClientVehicleFileUpload");//Retrieve the stored data

            tbClientVehicleFileUpload = JSON.parse(tbClientVehicleFileUpload); //Converts string to object

            if (tbClientVehicleFileUpload == null) //If there is no data, initialize an empty array
                tbClientVehicleFileUpload = [];

            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var descrptn = document.getElementById("descrptn" + x).value;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;

            if (Fevt == 'INS') {

                var $FileE = jQuery.noConflict();
                tbClientVehicleFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"
                });//Alter the selected item on the table
            }
            else {

                var $FileE = jQuery.noConflict();
                tbClientVehicleFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                   
                    DESCRPTN: "" + descrptn + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });//Alter the selected item on the table



            }



            localStorage.setItem("tbClientVehicleFileUpload", JSON.stringify(tbClientVehicleFileUpload));
            $FileE("#cphMain_HiddenField4_FileUpload").val(JSON.stringify(tbClientVehicleFileUpload));

            //alert("The FILE EDITED.");

            //var h = document.getElementById("<%=HiddenField4_FileUpload.ClientID%>").value;
            //alert(h);
            return true;
        }
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
    <script src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="../../../css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>




        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

                $au('#cphMain_ddlModalYear').selectToAutocomplete1Letter();

                $au('#cphMain_ddlVehicleCls').selectToAutocomplete1Letter();

                $au('#cphMain_ddlFuelTyp').selectToAutocomplete1Letter();

                $au('form').submit(function () {

                    //   alert($au(this).serialize());


                    //   return false;
                });
            });
        })(jQuery);





                    </script>




      
    <script type="text/javascript">
        
        var $MstrnoCon = jQuery.noConflict();

        function DuplicationRFid() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. RF ID Tag Number Can’t be Duplicated.";
            document.getElementById('divButtonAdditional').style.color = "Red";
            DivAdditionClick('2');
            document.getElementById("<%=txtRFIDTagNum.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtRFIDTagNum.ClientID%>").focus();
        }
        function DuplicationName() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=txtVehicleNumber.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtVehicleNumber.ClientID%>").focus();
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Registration Number Can’t be Duplicated.";
        }
        
        function DuplicationInsurance() {
            
            document.getElementById("<%=HiddenDivAddinlDis.ClientID%>").value = "hide";
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Insurance Number Can’t be Duplicated.";
            document.getElementById('divButtonInsuranceDetails').style.color = "Red";
            InsureClick('2');
            document.getElementById("<%=txtInsurance.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtInsurance.ClientID%>").focus();
            

            
        } 
        function DuplicationChasis() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=txtChasisNumber.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtChasisNumber.ClientID%>").focus();
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Chassis Number Can’t be Duplicated.";
        }

            function SuccessConfirmation() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Details Inserted Successfully.";
        }

        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Details Updated Successfully.";
        }





        function SuccessConfirmationAsgn() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Assigned Successfully.";
            }

            function SuccessUpdationAsgn() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Assign Updated Successfully.";
            }

        function SuccessConfirmationOther() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Assigned To Other Status Successfully.";
            }

            function SuccessUpdationOther() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Assign Updated Successfully.";
        }










        function DuplicationTrailerReg() {
            document.getElementById("<%=HiddenDivAddinlDis.ClientID%>").value = "hide";
          
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";         
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.Trailer Registration Number Can’t be Duplicated.";
            DivTrailerClick('2');
            document.getElementById("<%=txtBedIstamara.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtBedIstamara.ClientID%>").focus();


        }

        function DuplicationTrailerIns() {
            document.getElementById("<%=HiddenDivAddinlDis.ClientID%>").value = "hide";
          
          
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";         
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.Trailer Insurance Number Can’t be Duplicated.";
            
            DivTrailerClick('2');
            document.getElementById("<%=txtBedInsNumber.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtBedInsNumber.ClientID%>").focus();
            document.getElementById("<%=HiddenFieldInsFocus.ClientID%>").value = "1";
            
        }

       
        function VehicleMasterValidate() {
           // var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
          //  alert(h);
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            var permitname = "";
            if (document.getElementById("<%=hiddenPermitLabelName.ClientID%>").value != "") {
                permitname = document.getElementById("<%=hiddenPermitLabelName.ClientID%>").value;
                  }
            // replacing < and > tags
            var VehNumberWithoutReplace = document.getElementById("<%=txtVehicleNumber.ClientID%>").value;
            var replaceText1 = VehNumberWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtVehicleNumber.ClientID%>").value = replaceText2;

            var DescriptionWithoutReplace = document.getElementById("<%=txtDescription.ClientID%>").value;
            var replaceCode1 = DescriptionWithoutReplace.replace(/</g, "");
                var replaceCode2 = replaceCode1.replace(/>/g, "");
                document.getElementById("<%=txtDescription.ClientID%>").value = replaceCode2;

           

            var ChasisNumWithoutReplace = document.getElementById("<%=txtChasisNumber.ClientID%>").value;
            var replaceCode1 = ChasisNumWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtChasisNumber.ClientID%>").value = replaceCode2;

            var EngineCapaWithoutReplace = document.getElementById("<%=txtEngineCapacity.ClientID%>").value;
            var replaceCode1 = EngineCapaWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtEngineCapacity.ClientID%>").value = replaceCode2;

            var PurchaseDateWithoutReplace = document.getElementById("<%=txtPurchaseDate.ClientID%>").value;
            var replaceCode1 = PurchaseDateWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtPurchaseDate.ClientID%>").value = replaceCode2;

            var CurMileageWithoutReplace = document.getElementById("<%=txtCurrentMileage.ClientID%>").value;
            var replaceCode1 = CurMileageWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtCurrentMileage.ClientID%>").value = replaceCode2;

            var PrmtExpWithoutReplace = document.getElementById("<%=txtPermitExpiryDate.ClientID%>").value;
            var replaceCode1 = PrmtExpWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtPermitExpiryDate.ClientID%>").value = replaceCode2;

            var InsuranceWithoutReplace = document.getElementById("<%=txtInsurance.ClientID%>").value;
            var replaceCode1 = InsuranceWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtInsurance.ClientID%>").value = replaceCode2;

            var InsExpiryWithoutReplace = document.getElementById("<%=txtInsuranceExpiry.ClientID%>").value;
            var replaceCode1 = InsExpiryWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtInsuranceExpiry.ClientID%>").value = replaceCode2;

            var InsTagNumberWithoutReplace = document.getElementById("<%=txtRFIDTagNum.ClientID%>").value;
            var replaceCode1 = InsTagNumberWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtRFIDTagNum.ClientID%>").value = replaceCode2;

            var InsTankCapacityWithoutReplace = document.getElementById("<%=txtTankerCapacity.ClientID%>").value;
            var replaceCode1 = InsTankCapacityWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtTankerCapacity.ClientID%>").value = replaceCode2;

            var InsAmountPerBarelWithoutReplace = document.getElementById("<%=txtAmountPerBarrel.ClientID%>").value;
            var replaceCode1 = InsAmountPerBarelWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtAmountPerBarrel.ClientID%>").value = replaceCode2;



            var ModelWithoutReplace = document.getElementById("<%=txtModel.ClientID%>").value;
            var replaceCode1 = ModelWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtModel.ClientID%>").value = replaceCode2;

            var DealerWithoutReplace = document.getElementById("<%=txtDealer.ClientID%>").value;
            var replaceCode1 = DealerWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtDealer.ClientID%>").value = replaceCode2;

            var ContactWithoutReplace = document.getElementById("<%=txtContact.ClientID%>").value;
            var replaceCode1 = ContactWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtContact.ClientID%>").value = replaceCode2;

            var PriceWithoutReplace = document.getElementById("<%=txtPrice.ClientID%>").value;
            var replaceCode1 = PriceWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtPrice.ClientID%>").value = replaceCode2;

            var TrailerIstaWithoutReplace = document.getElementById("<%=txtBedIstamara.ClientID%>").value;
            var replaceCode1 = TrailerIstaWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtBedIstamara.ClientID%>").value = replaceCode2;

            var TrailerInsWithoutReplace = document.getElementById("<%=txtBedInsNumber.ClientID%>").value;
            var replaceCode1 = TrailerInsWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtBedInsNumber.ClientID%>").value = replaceCode2;




            var TRregExpDateWithoutReplace = document.getElementById("<%=txtTrPerExpDate.ClientID%>").value;
            var replaceCode1 = TRregExpDateWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtTrPerExpDate.ClientID%>").value = replaceCode2;

            var TRregExpDateWithoutReplace = document.getElementById("<%=txtTrInsAmnt.ClientID%>").value;
            var replaceCode1 = TRregExpDateWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtTrInsAmnt.ClientID%>").value = replaceCode2;

            var TRregExpDateWithoutReplace = document.getElementById("<%=txtTRinsExpDate.ClientID%>").value;
            var replaceCode1 = TRregExpDateWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtTRinsExpDate.ClientID%>").value = replaceCode2;

            




            $noCon("div#DIVVhclCls input.ui-autocomplete-input").css("borderColor", "");
            $noCon("div#DIVFuelTyp input.ui-autocomplete-input").css("borderColor", "");

            $noCon("div#divModalYear input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById("<%=txtEngineCapacity.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtKML.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlInsuranceProvider.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlVehicleType.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtInsuranceExpiry.ClientID%>").style.borderColor = ""; 
            document.getElementById("<%=txtVehicleNumber.ClientID%>").style.borderColor = ""; 
           

            document.getElementById("<%=ddlMake.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtModel.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtDealer.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtContact.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtPrice.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTrnsmn.ClientID%>").style.borderColor = ""; 
            document.getElementById("<%=ddlColor.ClientID%>").style.borderColor = ""; 
            document.getElementById("<%=ddlCoverageType.ClientID%>").style.borderColor = ""; 
            document.getElementById("<%=txtBedIstamara.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtBedInsNumber.ClientID%>").style.borderColor = "";

            document.getElementById("<%=txtPermitExpiryDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCurrentMileage.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtPurchaseDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtInsurance.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtRFIDTagNum.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTankerCapacity.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAmountPerBarrel.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtInsuranceAmount.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlRegiType.ClientID%>").style.borderColor = "";
            //document.getElementById('cphMain_divVehicleClass').style.border = "solid";
            //document.getElementById('divFuelTypeContainer').style.border = "1px solid";
            //document.getElementById('cphMain_divVehicleClass').style.borderColor = "#969696";
            //document.getElementById('divFuelTypeContainer').style.borderColor = "#008641";
            //document.getElementById('divButtonAdditional').style.color = "#0C7784";
            //document.getElementById('divButtonPermitDetails').style.color = "#0C7784";
            //document.getElementById('divButtonInsuranceDetails').style.color = "#0C7784";
            //document.getElementById('divButtonTankerDetails').style.color = "#0C7784";
            //document.getElementById('divButtonTrailerDetails').style.color = "#0C7784";


            document.getElementById("<%=txtBedInsNumber.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtBedIstamara.ClientID%>").style.borderColor = "";

            document.getElementById("<%=txtTrPerExpDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTRinsPrvdr.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTRinsExpDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTrInsAmnt.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTrInsCvrgeTyp.ClientID%>").style.borderColor = "";
         




            var CoverageType = document.getElementById("<%=ddlCoverageType.ClientID%>");
            var CoverageTypeText = CoverageType.options[CoverageType.selectedIndex].text;

            var VehicleType = document.getElementById("<%=ddlVehicleType.ClientID%>");
            var VehicleTypeText = VehicleType.options[VehicleType.selectedIndex].text;

            var ModalYear = document.getElementById("<%=ddlModalYear.ClientID%>");
            var ModalYearText = ModalYear.options[ModalYear.selectedIndex].text;

            var InsuProvider = document.getElementById("<%=ddlInsuranceProvider.ClientID%>");
            var InsuProviderText = InsuProvider.options[InsuProvider.selectedIndex].text;

            var RegType = document.getElementById("<%=ddlRegiType.ClientID%>");
            var RegTypeText = RegType.options[RegType.selectedIndex].text;

            var Make = document.getElementById("<%=ddlMake.ClientID%>");
            var MakeText = Make.options[Make.selectedIndex].text;

            var VehNUmber = document.getElementById("<%=txtVehicleNumber.ClientID%>").value.trim();
           
            var PermitExp = document.getElementById("<%=txtPermitExpiryDate.ClientID%>").value.trim();
            var CurrMileage = document.getElementById("<%=txtCurrentMileage.ClientID%>").value.trim(); 
            var PurchaseDate = document.getElementById("<%=txtPurchaseDate.ClientID%>").value.trim();
            var KiloMeterPerLit = document.getElementById("<%=txtKML.ClientID%>").value.trim();
            var EngineCapacity = document.getElementById("<%=txtEngineCapacity.ClientID%>").value.trim();
            var Insurance = document.getElementById("<%=txtInsurance.ClientID%>").value.trim();
            var InsExpDate = document.getElementById("<%=txtInsuranceExpiry.ClientID%>").value.trim();
            var InsAmount = document.getElementById("<%=txtInsuranceAmount.ClientID%>").value.trim();
            var RfIdNumber = document.getElementById("<%=txtRFIDTagNum.ClientID%>").value.trim();


            var VehicleClassId = document.getElementById("<%=hiddenVehicleClassId.ClientID%>").value; 
            var FuelTypeId = document.getElementById("<%=hiddenFuelTypeId.ClientID%>").value;

          
            var Model = document.getElementById("<%=txtModel.ClientID%>").value.trim();




            if (document.getElementById("<%=hiddenCategoryName.ClientID%>").value == "TRAILER") {


                var TrailerRegNum = document.getElementById("<%=txtBedIstamara.ClientID%>").value.trim();
                var TrailerInsNum = document.getElementById("<%=txtBedInsNumber.ClientID%>").value.trim();
                var RegNum = document.getElementById("<%=txtVehicleNumber.ClientID%>").value;
                var InsNum = document.getElementById("<%=txtInsurance.ClientID%>").value;

                var TRregExpDate = document.getElementById("<%=txtTrPerExpDate.ClientID%>").value;
                var TRinsPrvdr = document.getElementById("<%=ddlTRinsPrvdr.ClientID%>").value;
                var TRinsExpDate = document.getElementById("<%=txtTRinsExpDate.ClientID%>").value;
                var TRinsAmnt = document.getElementById("<%=txtTrInsAmnt.ClientID%>").value;
                var TRinsCvrgTyp = document.getElementById("<%=ddlTrInsCvrgeTyp.ClientID%>").value;

                if (TRinsCvrgTyp == "--SELECT--") {
                    DivTrailerClick('2');
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                     document.getElementById("<%=ddlTrInsCvrgeTyp.ClientID%>").style.borderColor = "Red";
                     document.getElementById("<%=ddlTrInsCvrgeTyp.ClientID%>").focus();
                     document.getElementById('divButtonTrailerDetails').style.color = "Red";

                     ret = false;
                 }

                if (TRinsAmnt == "") {
                    DivTrailerClick('2');
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtTrInsAmnt.ClientID%>").style.borderColor = "Red";
                     document.getElementById("<%=txtTrInsAmnt.ClientID%>").focus();
                     document.getElementById('divButtonTrailerDetails').style.color = "Red";

                     ret = false;
                 }
                if (TRinsExpDate == "") {
                    DivTrailerClick('2');
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtTRinsExpDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTRinsExpDate.ClientID%>").focus();
                    document.getElementById('divButtonTrailerDetails').style.color = "Red";

                    ret = false;
                }

                if (TRinsPrvdr == "--SELECT--") {
                    DivTrailerClick('2');
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=ddlTRinsPrvdr.ClientID%>").style.borderColor = "Red";
                     document.getElementById("<%=ddlTRinsPrvdr.ClientID%>").focus();
                     document.getElementById('divButtonTrailerDetails').style.color = "Red";

                     ret = false;
                 }


                if (TrailerInsNum == "") {
                     DivTrailerClick('2');
                     document.getElementById('divMessageArea').style.display = "";
                     document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                     document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtBedInsNumber.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtBedInsNumber.ClientID%>").focus();
                    document.getElementById('divButtonTrailerDetails').style.color = "Red";

                    ret = false;
                }
                if (InsNum == TrailerInsNum) {
                    DivTrailerClick('2');
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.Trailer Insurance Number Can’t be Duplicated.";
                     document.getElementById("<%=txtBedInsNumber.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtBedInsNumber.ClientID%>").focus();
                    document.getElementById('divButtonTrailerDetails').style.color = "Red";

                    ret = false;
                }



                if (TRregExpDate == "") {
                    DivTrailerClick('2');
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtTrPerExpDate.ClientID%>").style.borderColor = "Red";
                     document.getElementById("<%=txtTrPerExpDate.ClientID%>").focus();
                     document.getElementById('divButtonTrailerDetails').style.color = "Red";

                     ret = false;
                 }


                if (TrailerRegNum == "") {
                    DivTrailerClick('2');
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtBedIstamara.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtBedIstamara.ClientID%>").focus();
                    document.getElementById('divButtonTrailerDetails').style.color = "Red";

                    ret = false;
                }
                if (RegNum == TrailerRegNum) {
                    DivTrailerClick('2');
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.Trailer Registration Number Can’t be Duplicated.";
                    document.getElementById("<%=txtBedIstamara.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtBedIstamara.ClientID%>").focus();
                    document.getElementById('divButtonTrailerDetails').style.color = "Red";

                }
               
            }

          



            if (document.getElementById("<%=hiddenCategoryName.ClientID%>").value== "TANKER") {


                var TankerCapacity = document.getElementById("<%=txtTankerCapacity.ClientID%>").value.trim();
                var AmountPerBarel = document.getElementById("<%=txtAmountPerBarrel.ClientID%>").value.trim();


                if (AmountPerBarel == "") {
                    DivTankerClick('2');
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtAmountPerBarrel.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtAmountPerBarrel.ClientID%>").focus();
                    document.getElementById('divButtonTankerDetails').style.color = "Red";
                  
                    ret = false;
                }
                if (TankerCapacity == "") {
                    DivTankerClick('2');
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                     document.getElementById("<%=txtTankerCapacity.ClientID%>").style.borderColor = "Red";
                     document.getElementById("<%=txtTankerCapacity.ClientID%>").focus();
                     document.getElementById('divButtonTankerDetails').style.color = "Red";
                     
                     ret = false;
                 }
            }

            if (CoverageTypeText == "--SELECT--") {
                InsureClick('2');
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlCoverageType.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=ddlCoverageType.ClientID%>").focus();
                 document.getElementById('divButtonInsuranceDetails').style.color = "Red";

                 ret = false;
             }

            if (InsAmount == "") {
                InsureClick('2');
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtInsuranceAmount.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtInsuranceAmount.ClientID%>").focus();
                document.getElementById('divButtonInsuranceDetails').style.color = "Red";

                ret = false;
            }

            if (InsExpDate == "") {
                InsureClick('2');
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtInsuranceExpiry.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtInsuranceExpiry.ClientID%>").focus();
                document.getElementById('divButtonInsuranceDetails').style.color = "Red";
               
                 ret = false;
            }
            if (InsuProviderText == "--SELECT--") {
                InsureClick('2');
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlInsuranceProvider.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=ddlInsuranceProvider.ClientID%>").focus();
                document.getElementById('divButtonInsuranceDetails').style.color = "Red";
              
                 ret = false;
             }
            if (Insurance == "") {
                InsureClick('2');
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtInsurance.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtInsurance.ClientID%>").focus();
                document.getElementById('divButtonInsuranceDetails').style.color = "Red";
                
                 ret = false;
             }
            if (PermitExp == "") {
                DivPermitClick('2');
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtPermitExpiryDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtPermitExpiryDate.ClientID%>").focus();
                document.getElementById('divButtonPermitDetails').style.color = "Red";
                
                 ret = false;
            }

            if (CurrMileage == "") {
                DivAdditionClick('2');
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtCurrentMileage.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCurrentMileage.ClientID%>").focus();
                document.getElementById('divButtonAdditional').style.color = "Red"; 
                ret = false;
              }
            else if (CurrMileage < 0) {
                document.getElementById("<%=txtCurrentMileage.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCurrentMileage.ClientID%>").focus();
                document.getElementById('divButtonAdditional').style.color = "Red";
                DivAdditionClick('2');
                ret = false;
            }
           
            if (RfIdNumber == "") {
                DivAdditionClick('2');
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtRFIDTagNum.ClientID%>").focus();
                document.getElementById("<%=txtRFIDTagNum.ClientID%>").style.borderColor = "Red";
                document.getElementById('divButtonAdditional').style.color = "Red";
                
                  ret = false;
              }
          


            if (PurchaseDate == "") {
                DivAdditionClick('2');
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtPurchaseDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtPurchaseDate.ClientID%>").focus();
                document.getElementById('divButtonAdditional').style.color = "Red";
               
                ret = false; 
            }
            if (VehicleTypeText == "--SELECT--") {
                DivAdditionClick('2');
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlVehicleType.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlVehicleType.ClientID%>").focus();
                document.getElementById('divButtonAdditional').style.color = "Red";
                
                  ret = false;
              }
            if (RegTypeText == "--SELECT--") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlRegiType.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlRegiType.ClientID%>").focus();
             

                            ret = false;
            }

            if (KiloMeterPerLit != "") {
                if (KiloMeterPerLit < 0) {

                    document.getElementById("<%=txtKML.ClientID%>").style.borderColor = "Red";

                    document.getElementById("<%=txtKML.ClientID%>").focus();
                    ret = false;
                }
            }
            if (ModalYearText == "--SELECT--") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                $noCon("div#divModalYear input.ui-autocomplete-input").css("borderColor", "red");
                $noCon("div#divModalYear input.ui-autocomplete-input").focus();
                $noCon("div#divModalYear input.ui-autocomplete-input").select();
                ret = false;
            }
            if (EngineCapacity != "") {
                if (EngineCapacity < 0) {
                   
                    document.getElementById("<%=txtEngineCapacity.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtEngineCapacity.ClientID%>").focus();
                    ret = false;
                }
            }
            if (Model == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                 document.getElementById("<%=txtModel.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtModel.ClientID%>").focus();


                 ret = false;
            }
           
            if (MakeText == "--SELECT--") {


                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlMake.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlMake.ClientID%>").focus();


                ret = false;
             }
            if (VehNUmber == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtVehicleNumber.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtVehicleNumber.ClientID%>").focus();
                 ret = false;
            }
           
            

            if (FuelTypeId == "") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                $noCon("div#DIVFuelTyp input.ui-autocomplete-input").css("borderColor", "red");
                $noCon("div#DIVFuelTyp input.ui-autocomplete-input").select();
                ret = false;
            }

            if (VehicleClassId == "") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                $noCon("div#DIVVhclCls input.ui-autocomplete-input").css("borderColor", "red");
                $noCon("div#DIVVhclCls input.ui-autocomplete-input").select();
                ret = false;
            }

            var x = 0;

            if (ret == true) {
                if (PermitExp != "" || InsExpDate != "") {

                    var permitname = "";
                    if (document.getElementById("<%=hiddenPermitLabelName.ClientID%>").value != "") {
                        permitname = document.getElementById("<%=hiddenPermitLabelName.ClientID%>").value;
                    }

                    var TaskdatepickerDate = document.getElementById("<%=txtInsuranceExpiry.ClientID%>").value;
                    var arrDatePickerDate = TaskdatepickerDate.split("-");
                    var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                    var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                    var arrCurrentDate = CurrentDateDate.split("-");
                    var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);


                    var TaskdatepickerpurchDate = document.getElementById("<%=txtPermitExpiryDate.ClientID%>").value;
                    var arrDatePickerPurchDate = TaskdatepickerpurchDate.split("-");
                    var dateDateCntrlr2 = new Date(arrDatePickerPurchDate[2], arrDatePickerPurchDate[1] - 1, arrDatePickerPurchDate[0]);

                    if (dateDateCntrlr < dateCurrentDate && dateDateCntrlr2 < dateCurrentDate) {
                        x = 1;
                        if (confirm("Both insurance and " + permitname + " of vehicle has been expired Already. Are you sure You want to continue?")) {
                            ret = true;
                        }
                        else {
                            if (dateDateCntrlr < dateCurrentDate) {
                                document.getElementById("<%=txtInsuranceExpiry.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=txtInsuranceExpiry.ClientID%>").focus();
                               
                            }
                            if (dateDateCntrlr2 < dateCurrentDate) {
                                document.getElementById("<%=txtPermitExpiryDate.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=txtPermitExpiryDate.ClientID%>").focus();

                            }

                            ret = false;
                        }
                    }

                    if (dateDateCntrlr < dateCurrentDate && dateDateCntrlr2 >= dateCurrentDate) {
                        x = 1;
                        if (confirm("Vehicle insurance has been expired Already. Are you sure You want to continue?")) {
                            ret = true;
                       
                        }
                        else {
                            document.getElementById("<%=txtInsuranceExpiry.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtInsuranceExpiry.ClientID%>").focus();

                            ret = false;
                        }
                    }

                    if (dateDateCntrlr >= dateCurrentDate && dateDateCntrlr2 < dateCurrentDate) {
                        x = 1;
                        if (confirm("Vehicle " + permitname + " has been expired Already. Are you sure You want to continue?")) {
                            ret=true
                        }
                        else {
                            document.getElementById("<%=txtPermitExpiryDate.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtPermitExpiryDate.ClientID%>").focus();

                            ret = false;
                        }
                    }

                }


                //Start:-For trailer insurance And permit expiry date
                

                if (x == 0){

                    if (TRregExpDate != "" || TRinsExpDate != "") {

                        var permitname = "";
                        if (document.getElementById("<%=hiddenPermitLabelName.ClientID%>").value != "") {
                            permitname = document.getElementById("<%=hiddenPermitLabelName.ClientID%>").value;
                        }

                        var TaskdatepickerDate = document.getElementById("<%=txtTRinsExpDate.ClientID%>").value;
                        var arrDatePickerDate = TaskdatepickerDate.split("-");
                        var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                        var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                        var arrCurrentDate = CurrentDateDate.split("-");
                        var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);


                        var TaskdatepickerpurchDate = document.getElementById("<%=txtTrPerExpDate.ClientID%>").value;
                        var arrDatePickerPurchDate = TaskdatepickerpurchDate.split("-");
                        var dateDateCntrlr2 = new Date(arrDatePickerPurchDate[2], arrDatePickerPurchDate[1] - 1, arrDatePickerPurchDate[0]);

                        if (dateDateCntrlr < dateCurrentDate && dateDateCntrlr2 < dateCurrentDate) {
                            if (confirm("Both insurance and " + permitname + " of trailer has been expired Already. Are you sure You want to continue?")) {
                                ret = true;
                            }
                            else {
                                if (dateDateCntrlr < dateCurrentDate) {
                                    document.getElementById("<%=txtTRinsExpDate.ClientID%>").style.borderColor = "Red";
                                    document.getElementById("<%=txtTRinsExpDate.ClientID%>").focus();
                                }
                                if (dateDateCntrlr2 < dateCurrentDate) {
                                    document.getElementById("<%=txtTrPerExpDate.ClientID%>").style.borderColor = "Red";
                                    document.getElementById("<%=txtTrPerExpDate.ClientID%>").focus();

                                }

                                ret = false;
                            }
                        }

                        if (dateDateCntrlr < dateCurrentDate && dateDateCntrlr2 >= dateCurrentDate) {
                            if (confirm("Trailer insurance has been expired Already. Are you sure You want to continue?")) {
                                ret = true;

                            }
                            else {
                                document.getElementById("<%=txtTRinsExpDate.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=txtTRinsExpDate.ClientID%>").focus();

                                ret = false;
                            }
                        }

                        if (dateDateCntrlr >= dateCurrentDate && dateDateCntrlr2 < dateCurrentDate) {
                            if (confirm("Trailer " + permitname + " has been expired Already. Are you sure You want to continue?")) {
                                ret = true
                            }
                            else {
                                document.getElementById("<%=txtTrPerExpDate.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=txtTrPerExpDate.ClientID%>").focus();

                                ret = false;
                            }
                        }

                    }

            }


               //End:-For trailer insurance And permit expiry date

            }

            document.getElementById("<%=hiddenVehicleClassImg.ClientID%>").value = "";
            document.getElementById("<%=hiddenFuelTypImg.ClientID%>").value = "";


            if (ret == false) {
                CheckSubmitZero();

            }
            if (ret == false) {
                $MstrnoCon('html, body').animate({ scrollTop: 0 }, 'fast');
            }
          
                return ret;
            }

        function SelectVehicleClass(VehClassId,VhclCtgryName) 
        {
           
            IncrmntConfrmCounter();
                var oldVehClass = document.getElementById("<%=hiddenVehicleClassId.ClientID%>").value;
            if (oldVehClass != "") {
                document.getElementById("divImageVehicle-" + oldVehClass).style.border = ".5px solid";
                document.getElementById("divImageVehicle-" + oldVehClass).style.backgroundColor = "#d5d5d5";
                document.getElementById("divImageVehicle-" + oldVehClass).style.borderColor = "#0031BC";
                  }
            document.getElementById("divImageVehicle-" + VehClassId).style.border = ".5px solid";
            document.getElementById("divImageVehicle-" + VehClassId).style.backgroundColor = "rgb(164, 227, 160)";
            document.getElementById("divImageVehicle-" + VehClassId).style.borderColor =" rgb(13, 13, 14)";
            document.getElementById("<%=hiddenVehicleClassId.ClientID%>").value = VehClassId;
            document.getElementById("<%=hiddenCategoryName.ClientID%>").value = VhclCtgryName;
           
               
            TankerDivVisibility();
            TrailerDivVisibility();
            
        }
        function SelectFuelType(FuelTypeId) {
           
            IncrmntConfrmCounter();
            var oldFuelType = document.getElementById("<%=hiddenFuelTypeId.ClientID%>").value; 
            if (oldFuelType != "") {
             
                //document.getElementById("cbxFuelType" + oldFuelType).checked = false;
                //document.getElementById("cbxFuelTyp" + oldFuelType).checked = false;
                document.getElementById("divFuel-" + oldFuelType).style.border = ".5px solid";
                document.getElementById("divFuel-" + oldFuelType).style.backgroundColor = "#d5d5d5";
                document.getElementById("divFuel-" + oldFuelType).style.borderColor = "#0031BC";
            }
          
            //document.getElementById("cbxFuelType" + FuelTypeId).checked = true;
            document.getElementById("divFuel-" + FuelTypeId).style.border = ".5px solid";
            document.getElementById("divFuel-" + FuelTypeId).style.backgroundColor = "rgb(164, 227, 160)";
            document.getElementById("divFuel-" + FuelTypeId).style.borderColor = " rgb(13, 13, 14)";
            document.getElementById("<%=hiddenFuelTypeId.ClientID%>").value = FuelTypeId;
           

        }

       
    </script>


        <script type="text/javascript" language="javascript">







            // for not allowing <> tags
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
            // for not allowing enter
            function DisableEnter(evt) {

                evt = (evt) ? evt : window.event;
                var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                if (keyCodes == 13) {
                    return false;
                }
            }
            function controlTab(obj, event) {
                var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
                if (keyCode == 9) {
                    document.getElementById(obj).focus();
                    return false;
                }

                else {
                    return true;
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
            function isNumberMob(evt) {

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
                else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40 || keyCodes == 107 || keyCodes == 109) {
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
            function isDecimalNumber(evt, textboxid) {
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
                    var ret = true;
                    if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                        ret = false;
                    }
                    return ret;
                }
            }
            function BlurNotNumber(obj) {
               
                var txt = document.getElementById(obj).value;
        
                if (txt != "") {

                    if (isNaN(txt)) {
                        document.getElementById(obj).value = "";
                        document.getElementById(obj).focus();
                        return false;

                    }
                    else {
                        if (txt.indexOf(".") > 0) {
                            document.getElementById(obj).value = "";
                            document.getElementById(obj).focus();
                            return false;
                        }



                    }



                }


            }



            //FOR DECIMAL NUMBER

            function AmountCheckTanker(textboxid) {

                var txtPerVal = document.getElementById(textboxid).value;
                if (txtPerVal == "") {
                    return false;
                }
                else {
                    if (!isNaN(txtPerVal) == false) {
                        document.getElementById('' + textboxid + '').value = "";
                        return false;
                    }
                    else {
                        if (txtPerVal <= 0) {
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

            }

            function AmountCheck(textboxid) {
            
                var txtPerVal = document.getElementById(textboxid).value;
                if (txtPerVal == "") {
                    return false;
                }
                else {
                    if (!isNaN(txtPerVal) == false) {
                        document.getElementById('' + textboxid + '').value = "";
                        return false;
                    }
                    else {
                        if(txtPerVal<0) {
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

            }
            function MoneyCheckTanker(textboxid) {

                var txtPerVal = document.getElementById(textboxid).value.split(',').join('');
                if (txtPerVal == "") {
                    return false;
                }
                else {
                    if (!isNaN(txtPerVal) == false) {
                        document.getElementById('' + textboxid + '').value = "";
                        return false;
                    }
                    else {
                        if (txtPerVal <= 0) {
                            document.getElementById('' + textboxid + '').value = "";
                            return false;
                        }
                        var amt = parseFloat(txtPerVal);
                        var num = amt;
                        var n = 0;
                        // for floatting number adjustment from corp global

                        var FloatingValue = document.getElementById("<%=hiddenDecimalCountMoney.ClientID%>").value;
                        if (FloatingValue != "") {
                            var n = num.toFixed(FloatingValue);
                        }
                        document.getElementById('' + textboxid + '').value = addCommas(n);

                    }
                }

            }
            function MoneyCheck(textboxid) {
               
                var txtPerVal = document.getElementById(textboxid).value.split(',').join('');
               
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

                        var FloatingValue = document.getElementById("<%=hiddenDecimalCountMoney.ClientID%>").value;
                        if (FloatingValue != "") {
                            var n = num.toFixed(FloatingValue);
                        }
                        document.getElementById('' + textboxid + '').value = addCommas(n);

                    }
                }

            }




           


            //for insurance file upload

            function addCommas(nStr) {

                nStr += '';
                var x = nStr.split('.');
                var x1 = x[0];
                var x2 = x[1];
                //var a = document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value;
                //alert('hi'+a);
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
                    return x1;
                else
                    return x1 + "." + x2;
            }






        
    </script>
    <%--for delete image description--%>
     <script>

       

         function ImagePosition(object) {
 
             var $Mo = jQuery.noConflict();

             var offset = $Mo("#" + object).offset();

             var posY = 0;
             var posX = 0;
             posY = offset.top;

             posX = offset.left

             posX = 48.1;

             var d = document.getElementById('RemovePhoto');
           
             d.style.position = "absolute";
             d.style.left = posX + '%';
             d.style.top = posY +15 + 'px';
         }
         function ImagePositionInsur(object) {
 
             var $Mo = jQuery.noConflict();

             var offset = $Mo("#" + object).offset();

             var posY = 0;
             var posX = 0;
             posY = offset.top;

             posX = offset.left

             posX = 48.1;

             var d = document.getElementById('RemovePhotoInsur');
           
             d.style.position = "absolute";
             d.style.left = posX + '%';
             d.style.top = posY +15 + 'px';
         }
         function ImagePosition2(object) {

             var $Mo = jQuery.noConflict();

             var offset = $Mo("#" + object).offset();

             var posY = 0;
             var posX = 0;
             posY = offset.top;

             posX = offset.left

             posX = 67.1;

             var d = document.getElementById('RemovePhoto2');
             d.style.position = "absolute";
             d.style.left = posX + '%';
             d.style.top = posY + 15 + 'px';
         }

         function ImagePosition3(object) {

             var $Mo = jQuery.noConflict();

             var offset = $Mo("#" + object).offset();

             var posY = 0;
             var posX = 0;
             posY = offset.top;

             posX = offset.left

             posX = 67.1;

             var d = document.getElementById('RemovePhoto3');
             d.style.position = "absolute";
             d.style.left = posX + '%';
             d.style.top = posY + 15 + 'px';
         }


         
         //for the visibility of different sections under vehicle
         function DivAdditionClick(type) {
             //hiding other
             document.getElementById('divButtonPermitDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonPermitDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divPermitDetails').style.display = "none";

             document.getElementById('divButtonInsuranceDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonInsuranceDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divInsuranceDetails').style.display = "none";

             document.getElementById('divButtonVehicleImages').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonVehicleImages').style.borderBottom = "1px solid #999";
             document.getElementById('divVehicleImages').style.display = "none";

             document.getElementById('divButtonTankerDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonTankerDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divTankerDetails').style.display = "none";

             document.getElementById('divButtonTrailerDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonTrailerDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divTrailerDetails').style.display = "none";

             //displaying current
             document.getElementById('divButtonAdditional').style.backgroundColor = "#f9f9f9";
             document.getElementById('divButtonAdditional').style.borderBottom = "none";
             document.getElementById('divAdditionalInfo').style.display = "block";
             if (type == "1") {
                 document.getElementById('cphMain_ddlVehicleType').focus();
             }

         }
         function DivPermitClick(type) {

             //hiding other
             document.getElementById("<%=HiddenAtchmntMode.ClientID%>").value = "PERMIT";
            
             document.getElementById('divButtonAdditional').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonAdditional').style.borderBottom = "1px solid #999";
             document.getElementById('divAdditionalInfo').style.display = "none";

             document.getElementById('divButtonInsuranceDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonInsuranceDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divInsuranceDetails').style.display = "none";

             document.getElementById('divButtonVehicleImages').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonVehicleImages').style.borderBottom = "1px solid #999";
             document.getElementById('divVehicleImages').style.display = "none";

             document.getElementById('divButtonTankerDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonTankerDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divTankerDetails').style.display = "none";

             document.getElementById('divButtonTrailerDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonTrailerDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divTrailerDetails').style.display = "none";

             //displaying current
             document.getElementById('divButtonPermitDetails').style.backgroundColor = "#f9f9f9";
             document.getElementById('divButtonPermitDetails').style.borderBottom = "none";
             document.getElementById('divPermitDetails').style.display = "block";
             if (type == "1") {
                 document.getElementById('cphMain_txtPermitExpiryDate').focus();
             }
         }
         function InsureClick(type) {
             //hiding other
             document.getElementById("<%=HiddenAtchmntMode.ClientID%>").value = "INSUR";
           
             document.getElementById('divButtonPermitDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonPermitDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divPermitDetails').style.display = "none";

             document.getElementById('divButtonAdditional').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonAdditional').style.borderBottom = "1px solid #999";
             document.getElementById('divAdditionalInfo').style.display = "none";

             document.getElementById('divButtonVehicleImages').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonVehicleImages').style.borderBottom = "1px solid #999";
             document.getElementById('divVehicleImages').style.display = "none";

             document.getElementById('divButtonTankerDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonTankerDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divTankerDetails').style.display = "none";

             document.getElementById('divButtonTrailerDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonTrailerDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divTrailerDetails').style.display = "none";
             //displaying current
             document.getElementById('divButtonInsuranceDetails').style.backgroundColor = "#f9f9f9";
             document.getElementById('divButtonInsuranceDetails').style.borderBottom = "none";
             document.getElementById('divInsuranceDetails').style.display = "block";
             if (type == "1") {
                 document.getElementById('cphMain_txtInsurance').focus();
             }
         }


         function DivImagesClick(type) {
             //hiding other
             document.getElementById("<%=HiddenAtchmntMode.ClientID%>").value = "VHCLIMG";
             
             document.getElementById('divButtonPermitDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonPermitDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divPermitDetails').style.display = "none";

             document.getElementById('divButtonAdditional').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonAdditional').style.borderBottom = "1px solid #999";
             document.getElementById('divAdditionalInfo').style.display = "none";

             document.getElementById('divButtonInsuranceDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonInsuranceDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divInsuranceDetails').style.display = "none";

             document.getElementById('divButtonTankerDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonTankerDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divTankerDetails').style.display = "none";

             document.getElementById('divButtonTrailerDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonTrailerDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divTrailerDetails').style.display = "none";
             //displaying current
             document.getElementById('divButtonVehicleImages').style.backgroundColor = "#f9f9f9";
             document.getElementById('divButtonVehicleImages').style.borderBottom = "none";
             document.getElementById('divVehicleImages').style.display = "block";

         }

         function DivTankerClick(type) {
             //hiding other
             document.getElementById('divButtonPermitDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonPermitDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divPermitDetails').style.display = "none";

             document.getElementById('divButtonAdditional').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonAdditional').style.borderBottom = "1px solid #999";
             document.getElementById('divAdditionalInfo').style.display = "none";

             document.getElementById('divButtonInsuranceDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonInsuranceDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divInsuranceDetails').style.display = "none";

             document.getElementById('divButtonVehicleImages').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonVehicleImages').style.borderBottom = "1px solid #999";
             document.getElementById('divVehicleImages').style.display = "none";

             document.getElementById('divButtonTrailerDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonTrailerDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divTrailerDetails').style.display = "none";

             //displaying current

             document.getElementById('divButtonTankerDetails').style.backgroundColor = "#f9f9f9";
             document.getElementById('divButtonTankerDetails').style.borderBottom = "none";
             document.getElementById('divTankerDetails').style.display = "block";
             
                 if (document.getElementById("<%=hiddenCategoryName.ClientID%>").value != "TANKER") {
                     alert("Vehicle you selected is not a Tanker vehice")
                     document.getElementById('divButtonPermitDetails').style.backgroundColor = "#CBCBCB";
                     document.getElementById('divButtonPermitDetails').style.borderBottom = "1px solid #999";
                     document.getElementById('divPermitDetails').style.display = "none";

                     document.getElementById('divButtonInsuranceDetails').style.backgroundColor = "#CBCBCB";
                     document.getElementById('divButtonInsuranceDetails').style.borderBottom = "1px solid #999";
                     document.getElementById('divInsuranceDetails').style.display = "none";

                     document.getElementById('divButtonTankerDetails').style.backgroundColor = "#CBCBCB";
                     document.getElementById('divButtonTankerDetails').style.borderBottom = "1px solid #999";
                     document.getElementById('divTankerDetails').style.display = "none";

                     document.getElementById('divButtonTrailerDetails').style.backgroundColor = "#CBCBCB";
                     document.getElementById('divButtonTrailerDetails').style.borderBottom = "1px solid #999";
                     document.getElementById('divTrailerDetails').style.display = "none";

                     document.getElementById('divButtonAdditional').style.backgroundColor = "#f9f9f9";
                     document.getElementById('divButtonAdditional').style.borderBottom = "none";
                     document.getElementById('divAdditionalInfo').style.display = "block";

                   
                 }
             if (type == "1") {
                 document.getElementById('cphMain_txtTankerCapacity').focus();
             }
         
         }



         function DivTrailerClick(type) {
             //hiding other

           
             document.getElementById('divButtonPermitDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonPermitDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divPermitDetails').style.display = "none";

             document.getElementById('divButtonAdditional').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonAdditional').style.borderBottom = "1px solid #999";
             document.getElementById('divAdditionalInfo').style.display = "none";

             document.getElementById('divButtonInsuranceDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonInsuranceDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divInsuranceDetails').style.display = "none";

             document.getElementById('divButtonVehicleImages').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonVehicleImages').style.borderBottom = "1px solid #999";
             document.getElementById('divVehicleImages').style.display = "none";


             document.getElementById('divButtonTankerDetails').style.backgroundColor = "#CBCBCB";
             document.getElementById('divButtonTankerDetails').style.borderBottom = "1px solid #999";
             document.getElementById('divTankerDetails').style.display = "none";
             //displaying current



             document.getElementById('divButtonTrailerDetails').style.backgroundColor = "#f9f9f9";
             document.getElementById('divButtonTrailerDetails').style.borderBottom = "none";
             document.getElementById('divTrailerDetails').style.display = "block";

             if (document.getElementById("<%=hiddenCategoryName.ClientID%>").value != "TRAILER") {
                 alert("Vehicle you selected is not a Trailer vehice")
                 document.getElementById('divButtonPermitDetails').style.backgroundColor = "#CBCBCB";
                 document.getElementById('divButtonPermitDetails').style.borderBottom = "1px solid #999";
                 document.getElementById('divPermitDetails').style.display = "none";

                 document.getElementById('divButtonInsuranceDetails').style.backgroundColor = "#CBCBCB";
                 document.getElementById('divButtonInsuranceDetails').style.borderBottom = "1px solid #999";
                 document.getElementById('divInsuranceDetails').style.display = "none";

                 document.getElementById('divButtonTankerDetails').style.backgroundColor = "#CBCBCB";
                 document.getElementById('divButtonTankerDetails').style.borderBottom = "1px solid #999";
                 document.getElementById('divTankerDetails').style.display = "none";


                 document.getElementById('divButtonTrailerDetails').style.backgroundColor = "#CBCBCB";
                 document.getElementById('divButtonTrailerDetails').style.borderBottom = "1px solid #999";
                 document.getElementById('divTrailerDetails').style.display = "none";

                 document.getElementById('divButtonAdditional').style.backgroundColor = "#f9f9f9";
                 document.getElementById('divButtonAdditional').style.borderBottom = "none";
                 document.getElementById('divAdditionalInfo').style.display = "block";


             }
             if (type == "1") {

                
                 document.getElementById('cphMain_txtBedIstamara').focus();
             }
         }


         function InsuranceRenewalRedirect(x) {

             var VehicleId = document.getElementById("<%=hiddenVehicleIdForRenew.ClientID%>").value;
             if (confirmbox > 0) {
                 if (confirm("Are You Sure You Want To Renew Insurance?")) {
                     
                     window.location.href = "/AWMS/AWMS_Master/gen_Insurance_and_PermitRenewal/gen_Insurnc_And_Prmt_Exp_details.aspx?insd=" + VehicleId + "&Bck=vhcl&Mode="+x;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "/AWMS/AWMS_Master/gen_Insurance_and_PermitRenewal/gen_Insurnc_And_Prmt_Exp_details.aspx?insd=" + VehicleId + "&Bck=vhcl&Mode="+x;

             }
         }

         function PermitRenewalRedirect(x) {

           
             var VehicleId = document.getElementById("<%=hiddenVehicleIdForRenew.ClientID%>").value;
             if (confirmbox > 0) {
                 if (confirm("Are You Sure You Want To Renew Insurance?")) {

                     window.location.href = "/AWMS/AWMS_Master/gen_Insurance_and_PermitRenewal/gen_Insurnc_And_Prmt_Exp_details.aspx?permd=" + VehicleId + "&Bck=vhcl&Mode="+x;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "/AWMS/AWMS_Master/gen_Insurance_and_PermitRenewal/gen_Insurnc_And_Prmt_Exp_details.aspx?permd=" + VehicleId + "&Bck=vhcl&Mode="+x;

             }
         }


         function TankerDivVisibility() {
             //IncrmntConfrmCounter();

             if (document.getElementById("<%=hiddenCategoryName.ClientID%>").value == "TANKER") {

                 document.getElementById('divTankCapacity').style.visibility = "visible";
                 document.getElementById('divAmountPerbarrel').style.visibility = "visible";
                 
                 document.getElementById("<%=txtTankerCapacity.ClientID%>").focus();
             }
             else {
                 
                 document.getElementById('divTankCapacity').style.visibility = "hidden";
                 document.getElementById('divAmountPerbarrel').style.visibility = "hidden";
             }
         }

         function TrailerDivVisibility() {
             //IncrmntConfrmCounter();

             //InsuranceProviderLoad();
             //InsuranceCovrageTypeLoad();
          
             if (document.getElementById("<%=hiddenCategoryName.ClientID%>").value == "TRAILER") {
               
                 document.getElementById('divTrailerIstamara').style.visibility = "visible";
                 document.getElementById('divTrailerIns').style.visibility = "visible";

               
                 if (document.getElementById("<%=HiddenFieldInsFocus.ClientID%>").value == "1") {
                     document.getElementById("<%=txtBedInsNumber.ClientID%>").focus();

                 }
                 else {
                     document.getElementById("<%=txtBedIstamara.ClientID%>").focus();
                 }
             }
             else {

                 document.getElementById('divTrailerIstamara').style.visibility = "hidden";
                 document.getElementById('divTrailerIns').style.visibility = "hidden";
             }

             document.getElementById("<%=HiddenFieldInsFocus.ClientID%>").value ="";
         }

         //evm-0023

         function InsuranceProviderLoad() {

             var OrgId = '<%= Session["ORGID"] %>';
             var CorpId = '<%= Session["CORPOFFICEID"] %>';
             var varInsrPrvddl = $(document.getElementById("<%=ddlTRinsPrvdr.ClientID%>"));

             var Details = PageMethods.InsuranceProviderDDList(OrgId, CorpId, function (response) {
                 varInsrPrvddl.children().remove();
                 var optionstart = $("<option>--SELECT--</option>");
                 optionstart.attr("value", "--SELECT--");
                 varInsrPrvddl.append(optionstart);

                 $(response).find("dtTrailerInsrProv").each(function () {

                     var optionvalue = $(this).find('INSURPRVDR_ID').text();
                     var optiontext = $(this).find('INSURPRVDR_NAME').text();
                     var option = $("<option>" + optiontext + "</option>");
                     option.attr("value", optionvalue);

                     varInsrPrvddl.append(option);
                 });

             });

             setTimeout(SelectInsrncPrvdr(varInsrPrvddl), 100);

         }

         function SelectInsrncPrvdr(varInsrPrvddl) {

             if (document.getElementById("<%=hiddenEdit.ClientID%>").value != "") {

                 if (document.getElementById("<%=hiddenInsrncPrvdrSelctd.ClientID%>").value != "") {
                     document.getElementById("<%=ddlTRinsPrvdr.ClientID%>").value = document.getElementById("<%=hiddenInsrncPrvdrSelctd.ClientID%>").value;
                 }
                 else {
                     var optiontextAdd = document.getElementById("<%=hiddenInsPrvdrNameSelctd.ClientID%>").value;
                     var optionvalueAdd = document.getElementById("<%=hiddenInsrncPrvdrSelctd.ClientID%>").value;
                     var optionAdd = $("<option>" + optiontextAdd + "</option>");
                     optionAdd.attr("value", optionvalueAdd);
                     varInsrPrvddl.append(optionAdd);
                 }
             }
         }


         function InsuranceCovrageTypeLoad() {
             var varCovrgTypddl = $(document.getElementById("<%=ddlTrInsCvrgeTyp.ClientID%>"));

             var Details = PageMethods.InsuranceCovrgTypDDList(function (response) {
                 varCovrgTypddl.children().remove();

                 var optionstart = $("<option>--SELECT--</option>");
                 optionstart.attr("value", "--SELECT--");
                 varCovrgTypddl.append(optionstart);

                 $(response).find("dtTrailerInsrCovrgTyp").each(function () {

                     var optionvalue = $(this).find('COVRGTYP_ID').text();
                     var optiontext = $(this).find('COVRGTYP_NAME').text();
                     var option = $("<option>" + optiontext + "</option>");
                     option.attr("value", optionvalue);

                     varCovrgTypddl.append(option);
                 });

             });

             setTimeout(SelectCoverage(varCovrgTypddl), 100);
         }

         function SelectCoverage(varCovrgTypddl) {

             if (document.getElementById("<%=hiddenEdit.ClientID%>").value != "") {

                 if (document.getElementById("<%=hiddenCovergTypSelctd.ClientID%>").value != "") {
                     document.getElementById("<%=ddlTRinsPrvdr.ClientID%>").value = document.getElementById("<%=hiddenCovergTypSelctd.ClientID%>").value;
                 }
                 else {
                     var optiontextAdd = document.getElementById("<%=hiddenInsPrvdrNameSelctd.ClientID%>").value;
                     var optionvalueAdd = document.getElementById("<%=hiddenCovergTypSelctd.ClientID%>").value;
                     var optionAdd = $("<option>" + optiontextAdd + "</option>");
                     optionAdd.attr("value", optionvalueAdd);
                     varCovrgTypddl.append(optionAdd);
                 }
             }
         }




         function VehicleDisplayImage() {

             var VehiclClsId = 0;
             if (document.getElementById("<%=ddlVehicleCls.ClientID%>").value != "") {
                 VehiclClsId = document.getElementById("<%=ddlVehicleCls.ClientID%>").value;
             }

             var Details = PageMethods.VehicleImageLoad(VehiclClsId, function (response) {

                 if (response[0] != "") {
                     document.getElementById("<%=divVehicleImage.ClientID%>").innerHTML = response[0];
                     document.getElementById("<%=hiddenVehicleClassImg.ClientID%>").value = response[0];
                 }

                 document.getElementById("<%=hiddenVehicleClassId.ClientID%>").value = VehiclClsId;
                 if (response[2] != "") {
                     document.getElementById("<%=hiddenCategoryName.ClientID%>").value = response[2];
                 }

                 TankerDivVisibility();
                 TrailerDivVisibility();
             });

         }

         function FuelTypDisplayImage() {

             var FuelTyp = 0;
             if (document.getElementById("<%=ddlFuelTyp.ClientID%>").value != "") {
                  FueltypId = document.getElementById("<%=ddlFuelTyp.ClientID%>").value;
             }

             var Details = PageMethods.FuelTypImageLoad(FueltypId, function (response) {

                 if (response[1] != "") {
                     document.getElementById("<%=divFuelTypeImage.ClientID%>").innerHTML = response[1];
                     document.getElementById("<%=hiddenFuelTypImg.ClientID%>").value = response[1];
                 }

                 document.getElementById("<%=hiddenFuelTypeId.ClientID%>").value = FueltypId;
             });

         }

         function Cleardivimages() {


             document.getElementById("<%=hiddenVehicleClassImg.ClientID%>").value = "";
             document.getElementById("<%=hiddenFuelTypImg.ClientID%>").value = "";
         }

    </script>


<script>
    //Pass vehicle id and name for multiple row
    function PassSavedVehicleId(strId, strName, Row) {
        if (window.opener != null && !window.opener.closed) {
            window.opener.GetValueFromChildVehicle(strId, strName, Row);
        }
        window.close();
    }
</script>


     <style>
         .colmcenter {
             width: 75%;
         }


           a.lightbox img {
            height: 150px;
            border: 3px solid white;
            box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
            margin: 94px 20px 20px 20px;
        }

        /* Styles the lightbox, removes it from sight and adds the fade-in transition */
        .lightbox-target {
            position: fixed;
            top: -100%;
            width: 100%;
            background: rgba(0, 0, 0, 0.7);
            width: 60%;
            opacity: 0;
            -webkit-transition: opacity .5s ease-in-out;
            -moz-transition: opacity .5s ease-in-out;
            -o-transition: opacity .5s ease-in-out;
            transition: opacity .5s ease-in-out;
            overflow: hidden;
        }

            /* Styles the lightbox image, centers it vertically and horizontally, adds the zoom-in transition and makes it responsive using a combination of margin and absolute positioning */
            .lightbox-target img {
                margin: auto;
                position: absolute;
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                max-height: 0%;
                max-width: 0%;
                border: 3px solid white;
                box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
                box-sizing: border-box;
                -webkit-transition: .5s ease-in-out;
                -moz-transition: .5s ease-in-out;
                -o-transition: .5s ease-in-out;
                transition: .5s ease-in-out;
            }

        /* Styles the close link, adds the slide down transition */
        a.lightbox-close {
            display: block;
            width: 50px;
            height: 50px;
            box-sizing: border-box;
            background: white;
            color: black;
            text-decoration: none;
            position: absolute;
            top: -80px;
            right: 0;
            -webkit-transition: .5s ease-in-out;
            -moz-transition: .5s ease-in-out;
            -o-transition: .5s ease-in-out;
            transition: .5s ease-in-out;
        }

            /* Provides part of the "X" to eliminate an image from the close link */
            a.lightbox-close:before {
                content: "";
                display: block;
                height: 30px;
                width: 1px;
                background: black;
                position: absolute;
                left: 26px;
                top: 10px;
                -webkit-transform: rotate(45deg);
                -moz-transform: rotate(45deg);
                -o-transform: rotate(45deg);
                transform: rotate(45deg);
            }

            /* Provides part of the "X" to eliminate an image from the close link */
            a.lightbox-close:after {
                content: "";
                display: block;
                height: 30px;
                width: 1px;
                background: black;
                position: absolute;
                left: 26px;
                top: 10px;
                -webkit-transform: rotate(-45deg);
                -moz-transform: rotate(-45deg);
                -o-transform: rotate(-45deg);
                transform: rotate(-45deg);
            }

        /* Uses the :target pseudo-class to perform the animations upon clicking the .lightbox-target anchor */
        .lightbox-target:target {
            opacity: 1;
            top: 0;
            bottom: 0;
          
            right: 18%;
            z-index: 103;
        }

            .lightbox-target:target img {
                max-height: 100%;
                max-width: 80%;
            }

            .lightbox-target:target a.lightbox-close {
                top: 0px;
            }

                    .form-group p {
            color: red;
            margin-top: 1%;
            margin-left: 40%;
        }



        #cphMain_mydiv {
            background: #C2DFEF;
            text-align: left;
            overflow: auto;
            margin-left: 14.5%;
            max-height: 220px;
            margin-top:-2%;
        }


        .form2 label {
        padding-left:1.5%;
        }
       
            
        .imgDescription {
            position: absolute;
            /*top: 511px;
            left: 6.5%;*/
            background: rgb(54, 117, 152);
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
       #cphMain_mydiv td {
            border-right:0px;
        }
        #cphMain_cbxlCorporateOffc {
        width:100%;
        }
      
    #goofy {
            right:17%;
            top:53px;
            width:60%;
        }
  </style>
    <style>
        #divErrorNotification {
    font-weight: bold;
    text-align: center;
    font-size: 17px;
    color: #53844E;
    font-family: Calibri;
             }
        #lblVehicleClass {
            
            color: #0077A7;
            margin-left: 35%;
            font-family: calibri;
        }
        #cphMain_divVehicleClass {
            width: 92%;
            margin-left: 3%;
            margin-top: 1%;
            height: 76%;
            border: solid;
            border-color:#779E99;
            overflow: auto;
        }
        .divImageVehicle {

         /*height: 70px;*/
         background-color: #d5d5d5;
         border: 1px solid;
         border-color: #0031BC;
         margin: 3px;
        font-size: 15px;
        min-width: 48%;
        max-width: 98%;
        overflow-wrap: break-word;
        }
        .divImageVehicle:hover {
            background-color:#93bfc9;
        }
        .textDate:focus {
            border: 1px solid #bbf2cf;
            box-shadow: 0px 0px 4px 2.5px #bbf2cf;
        }
        .textDate {
            border: 1px solid #cfcccc;
        }

    </style>
    <%--style for block div--%>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
  <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
    <asp:HiddenField ID="hiddenPermitFileSize" runat="server" />
    <asp:HiddenField ID="hiddenPermitFile" runat="server" />
    <asp:HiddenField ID="hiddenPermitFileDeleted" runat="server" />
    <asp:HiddenField ID="hiddenInsuranceFile" runat="server" />
    <asp:HiddenField ID="hiddenInsuranceFileDeleted" runat="server" />
    <asp:HiddenField ID="hiddenFuelTypeId" runat="server" />
    <asp:HiddenField ID="hiddenVehicleClassId" runat="server" />
    <asp:HiddenField ID="hiddenAttachSerialNum" runat="server" />
    <asp:HiddenField ID="hiddenVehicleImg1" runat="server" />
    <asp:HiddenField ID="hiddenVehicleImg1Deleted" runat="server" />
    <asp:HiddenField ID="hiddenVehicleImg3" runat="server" />
    <asp:HiddenField ID="hiddenVehicleImg3Deleted" runat="server" />
    <asp:HiddenField ID="hiddenPermitLabelName" runat="server" />
     <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
     <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
     <asp:HiddenField ID="hiddenDecimalCountMoney" runat="server" />
    <asp:HiddenField ID="hiddenViewMode" runat="server" />
    <asp:HiddenField ID="hiddenOpenPrmtORIns" runat="server" />
        <asp:HiddenField ID="hiddenVehicleIdForRenew" runat="server" />
    <asp:HiddenField ID="hiddenDuplication" runat="server" />
     <asp:HiddenField ID="HiddenField2_FileUpload" runat="server" />
     <asp:HiddenField ID="HiddenField3_FileUpload" runat="server" />
     <asp:HiddenField ID="HiddenField4_FileUpload" runat="server" />
      <asp:HiddenField ID="HiddenField5_FileUpload" runat="server" />
    <asp:HiddenField ID="HiddenField6_FileUpload" runat="server" />
     <asp:HiddenField ID="HiddenAtchmntMode" runat="server" />
     <asp:HiddenField ID="hiddenFilePath" runat="server" />
     <asp:HiddenField ID="hiddenAttchmntPrmtSlNumber" runat="server" />
     <asp:HiddenField ID="hiddenEditPrmtAttchmnt" runat="server" />
    <asp:HiddenField ID="hiddenAttchmntInsurSlNumber" runat="server" />
     <asp:HiddenField ID="hiddenEditInsurAttchmnt" runat="server" />
     <asp:HiddenField ID="hiddenAttchmntVhclSlNumber" runat="server" />
     <asp:HiddenField ID="hiddenEditVhclAttchmnt" runat="server" />


     <asp:HiddenField ID="hiddenAttchmntPrmtSlNumberTR" runat="server" />
     <asp:HiddenField ID="hiddenEditPrmtAttchmntTR" runat="server" />

      <asp:HiddenField ID="hiddenAttchmntInsurSlNumberTR" runat="server" />
     <asp:HiddenField ID="hiddenEditInsurAttchmntTR" runat="server" />

     <asp:HiddenField ID="hiddenEdit" runat="server" />
     <asp:HiddenField ID="hiddenView" runat="server" />
    <asp:HiddenField ID="hiddenPerFileCanclDtlId" runat="server" />
    <asp:HiddenField ID="hiddenInsFileCanclDtlId" runat="server" />
    <asp:HiddenField ID="hiddenVhclFileCanclDtlId" runat="server" />
     <asp:HiddenField ID="hiddenPerFileCanclDtlIdTR" runat="server" />
     <asp:HiddenField ID="hiddenInsFileCanclDtlIdTR" runat="server" />

    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />

    <asp:HiddenField ID="hiddenIsPrmtRenwed" runat="server" />
    <asp:HiddenField ID="hiddenIsInsurRenwed" runat="server" />

      <asp:HiddenField ID="hiddenIsPrmtRenwedTR" runat="server" />
    <asp:HiddenField ID="hiddenIsInsurRenwedTR" runat="server" />

     <asp:HiddenField ID="hiddenCategoryName" runat="server" />

     <asp:HiddenField ID="hiddenImportError" runat="server" />
     <asp:HiddenField ID="hiddenQtnTemplateId" runat="server" />
    <asp:HiddenField ID="hiddenCSVvalues" runat="server" />
    <asp:HiddenField ID="hiddenConfirmImportErrors" runat="server" />
    <asp:HiddenField ID="HiddenVehicleId" runat="server" />
        <asp:HiddenField ID="HiddenDivAddinlDis" runat="server" />


      <asp:HiddenField ID="HiddenFieldInsFocus" runat="server" />

     <asp:HiddenField ID="HiddenFieldTR" runat="server" />


     <asp:HiddenField ID="hiddenVehicleClassImg" runat="server" />
       <asp:HiddenField ID="hiddenFuelTypImg" runat="server" />
           <asp:HiddenField ID="hiddenVehicleCatgryNm" runat="server" />
           <asp:HiddenField ID="hiddenInsrncPrvdrSelctd" runat="server" />
           <asp:HiddenField ID="hiddenCovergTypSelctd" runat="server" />
               <asp:HiddenField ID="hiddenInsPrvdrNameSelctd" runat="server" />
           <asp:HiddenField ID="hiddenCovrgNameSelctd" runat="server" />

    <div class="cont_rght">

                   <div id="divMessageArea" style="display: none; margin:0px 0 13px;">
                 <img id="imgMessageArea" src="" >
                <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>


          <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:0%; top:20%;height:26.5px;">

          <%--   <a href="gen_ProductBrandList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>

        <div class="fillform" style="width:100%;">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>



            <div class="eachform" style="background-color: #f5f5f5;margin: 0 0 1px;">
                
                <div id="divVehicleClassContainer" runat="server" style="float: left;width: 35%;height: 218px;border:1px solid;border-color: #008641;margin: 1%;">
                <label id="lblVehicleClass" style="cursor:auto;font-size: 17px;font-weight: bold;">Select Vehicle Class*</label>
                    <div id="divVehicleClass" style="height:77%;display:none;" runat="server">
                     
                    </div>

               <div class="eachform" style="float: left;width: 85%;margin-top: 6%;">
                   <div id="DIVVhclCls">
                     <asp:DropDownList ID="ddlVehicleCls" class="form1" runat="server" Style="height:30px;width:85%;" onkeydown="return DisableEnter(event)" onchange="VehicleDisplayImage()"></asp:DropDownList>
                    </div>
               </div>

                    <div id="divVehicleImage" runat="server"></div>

                </div>
               
           
                <div id="divFuelTypeContainer" style="width: 21%;min-width:95px; float: left;margin-left: 1%;margin-top:1%; height: 218px;border:1px solid;border-color: #008641;">
                    <label id="Label1" style="color: #0077AE;font-family: calibri; margin-left: 15%;cursor:auto;font-size: 17px;font-weight: bold;">Select Fuel Type* </label>
                    <div id="divFuelImage" runat="server" style="display:none;width: 77%;margin-left: 7%;overflow:auto;max-height: 86%;border: solid;border-color: #779E99;">

                    </div>

               <div class="eachform" style="float: left;width: 85%;margin-top: 10%;">
                   <div id="DIVFuelTyp">
                     <asp:DropDownList ID="ddlFuelTyp" class="form1" runat="server" Style="height:30px;width:85%;" onkeydown="return DisableEnter(event)" onchange="FuelTypDisplayImage()"></asp:DropDownList>
                   </div>
               </div>

                     <div id="divFuelTypeImage" runat="server"></div>

                </div>
           

                <div class="subform" style="width: 36%;margin-top:1%;background-color: #eaeaea;padding: 13px;float: right;margin-right: 1%;margin-bottom: 1%;border: 1px solid;border-color: #d5d5d5;">
                <div style="width: 100%;">
                     <h2>Registration Number*</h2>
                <asp:TextBox ID="txtVehicleNumber" class="form1" runat="server" MaxLength="99" Style="width:55%;margin-right:5%; text-transform: uppercase;"></asp:TextBox>

                </div>
                     <div style="width: 100%;margin-top: 9%;">
                     <h2>Description</h2>
                <asp:TextBox ID="txtDescription" class="form1" runat="server" MaxLength="140" Style="width:55%;margin-right:5%;"></asp:TextBox>

                </div>
                 <div style="width: 100%;margin-top: 18%;">
                     <h2>Make*</h2>
                 <asp:DropDownList ID="ddlMake" class="form1" runat="server" MaxLength="100" Style="height:30px;width:59%;margin-right:5%;" onkeydown="return DisableEnter(event)"></asp:DropDownList>

                </div>
                 
                     <div style="width: 100%;margin-top: 27%;">
                     <h2>Model*</h2>
                <asp:TextBox ID="txtModel" class="form1" runat="server" MaxLength="100" Style="width:55%;margin-right:5%;text-transform: uppercase;"></asp:TextBox>

                </div>

                 <div id="divTrnsmn" style="width:100%;margin-top: 36%;">
                     <h2>Transmission</h2>
                 <asp:DropDownList ID="ddlTrnsmn" class="form1" runat="server" Style="height:30px;width:59%;margin-right: 5%;" onkeydown="return DisableEnter(event)"></asp:DropDownList>

                </div>

                  <div style="width: 100%;margin-top: 45%;">
                     <h2>Color</h2>
                <asp:DropDownList ID="ddlColor" class="form1" runat="server" Style="height:30px;width:59%;margin-right: 5%;" onkeydown="return DisableEnter(event)"></asp:DropDownList>

                </div> 

                <div style="width: 100%;margin-top: 54%;">
                     <h2>Chassis Number</h2>
                <asp:TextBox ID="txtChasisNumber" class="form1" runat="server" MaxLength="100" Style="width:55%;margin-right:5%;text-transform: uppercase;"></asp:TextBox>

                </div>
                    <div style="width: 100%;margin-top: 63%;">
                     <h2>Engine Capacity</h2>
                        <h2 style="margin-top: 2%;margin-right: 5%;float:right">Ltrs</h2>
                <asp:TextBox ID="txtEngineCapacity" class="form1" MaxLength="9" Style="width:47.5%; text-transform: uppercase;text-align:right ;float: right;margin-right: 2%;" onkeydown="return isDecimalNumber(event,'cphMain_txtEngineCapacity');" onblur="AmountCheck('cphMain_txtEngineCapacity');"  runat="server"></asp:TextBox>
                 
                </div>
                     <div id="divModalYear" style="width:59%;margin-top: 72%;">
                     <h2>Model Year*</h2>
                 <asp:DropDownList ID="ddlModalYear" class="form1" runat="server" Style="height:30px;width:84px;margin-right: 0%;float: right;" onkeydown="return DisableEnter(event)"></asp:DropDownList>

                </div>
                    <%--EVM-0027--%>
                     <div style="width: 37%; margin-top: -6.5%; float: right">
                        <h2>KMPL</h2>
                        <asp:TextBox ID="txtKML" class="form1" runat="server" MaxLength="7" Style="width: 75px; text-align: right; text-transform: uppercase; float: right; margin-right: 14%;" onkeydown="return isDecimalNumber(event,'cphMain_txtKML');" onblur="AmountCheck('cphMain_txtKML');"></asp:TextBox>

                    </div>
                  <%--  END--%>
                     <div style="width:100%;margin-top: 2%;float:right">
                     <h2>Registration Type*</h2>
                 <asp:DropDownList ID="ddlRegiType" class="form1" runat="server" Style="height:30px;width:59%;margin-right: 5%;float: right;" onkeydown="return DisableEnter(event)"></asp:DropDownList>

                </div>


                     <div class="eachform" style="margin-top: 1%;">
                <h2>Status*</h2>
                <div class="subform" style="margin-left: 1%;float: left;margin-left: 23%;padding-top: 8px;">


                    <asp:CheckBox ID="cbxStatus" Text="" runat="server" Checked="true" onclick="IncrmntConfrmCounter()" onkeydown="return DisableEnter(event)" class="form2" />
                    <h3>Active</h3>

                </div>
            </div>
                </div>

                 <div id="divCSVFileUpload" runat="server" style="width:55.2%;float: left;background-color: #eaeaea;padding: 19px;margin-left: 1%;height: 187px;margin-bottom: 1%;border: 1px solid;border-color: #d5d5d5;">
                
                 <div id="divCSV" runat="server" style="width:37%;height:47px;float:left;">
                <div style="float: left;margin-left: 0%;margin-top:2%;">
                <asp:Button ID="btnImportCsv" runat="server" class="save" Text="Click Here To Import CSV File" OnClick="btnImportCsvVhcl_Click" OnClientClick="Cleardivimages()"  />

                </div>
                </div>

                <div id="divStatus" runat="server" style="display:none;width:59%;height:47px;float:right;">
                <div id="divS" runat="server" style="margin-top: 0%;float:right;width:60%;">
                     <h2>Vehicle Status</h2>
                <asp:TextBox ID="txtVhclSts" Enabled="false" class="form1" runat="server" MaxLength="50" style="width:53%;text-align:left; text-transform: uppercase;float: right;margin-right:4%;"  ></asp:TextBox>

                </div>

                 <div style="float: right;margin-right: 0%;margin-top:1%;">
                 <asp:Button ID="btnChangeSts" runat="server" class="save" Text="Click Here To Change Status" OnClick="btnChangeSts_Click"   />

                </div>
               </div>

                </div>


                </div>


           


             <div class="eachform" style="border: 1px solid;border-color: #9ba48b; margin-top:1px;">
                 <div id="divButtonAdditional" class="divbutton" onclick="DivAdditionClick('1')" >Additional Information*</div>

                 <div id="divButtonPermitDetails" class="divbutton" onclick="DivPermitClick('1')" > <label id="LabelPermit_Details" runat="server">Permit Details* </label></div>

                 <div id="divButtonInsuranceDetails" onclick="InsureClick('1')" class="divbutton" >Insurance Details*</div>
                 <div id="divButtonVehicleImages" onclick="DivImagesClick('1')" class="divbutton" >Vehicle Images</div>
                 <div id="divButtonTankerDetails"   onclick="DivTankerClick('1')" class="divbutton" >Tanker Details*</div>
                 <div id="divButtonTrailerDetails"   onclick="DivTrailerClick('1')" class="divbutton" >Trailer Details*</div>


                 <%--additional info--%>
                 <div id="divAdditionalInfo" style="width: 100%;height:310px; float: left;padding-bottom:2%;background-color: #f9f9f9;display:none">

                <div id="divVehicleType" style="width: 45%;margin-top: 3%;margin-left: 2%;float:left">
                     <h2 style="float: left;margin-left: 5%;">Ownership*</h2>
                     <asp:DropDownList ID="ddlVehicleType" class="form1" runat="server" Style="height:30px;width:42%;margin-right: 20%;float: right;" onkeydown="return DisableEnter(event)" ></asp:DropDownList>
                </div>
                    <div style="width: 45%;margin-top: 3%;margin-right: 5%;float: right;">
                 <h2>Vehicle Purchase Date*</h2>
               <div id="datetimepicker" class="input-append date" style="font-family:Calibri;float:right;width:62.5%">
                 <asp:TextBox ID="txtPurchaseDate" class="textDate" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width:58.8%;height:23px; font-family: calibri;" ></asp:TextBox>

                        <img id= "imgDate" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style=" height:17px; width:12px; cursor:pointer;" />

                        <script type="text/javascript"
                            src="../../../JavaScript/Date/JavaScriptDate1_8_3.js"></script>
                        
                        <script type="text/javascript"
                            src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                        </script>
                        <script type="text/javascript"
                            src="../../../JavaScript/Date/bootstrap-datepicker.js">
                        </script>
                        <script type="text/javascript"
                            src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js">
                        </script>
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#datetimepicker').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,

                            });

                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>
                      

                      <div style="width: 45%;margin-top: 1%;margin-left: 2%;float: left;">
                         <h2 style="float: left;margin-left: 5%;">Price</h2>
                <asp:TextBox ID="txtPrice" class="form1" runat="server" MaxLength="8" style="width:39%;text-align:right; text-transform: uppercase;float: right;margin-right: 20%;" onkeydown="return isDecimalNumber(event,'cphMain_txtPrice');" onblur="MoneyCheck('cphMain_txtPrice')"></asp:TextBox>
                       </div>

                     <div style="width: 45%;margin-top: 1%;margin-left: 2%;float: left;">
                         <h2 style="float: left;margin-left: 2%;">Dealer Name</h2>
                <asp:TextBox ID="txtDealer" class="form1" runat="server" MaxLength="50" style="width:39%;text-align:left; text-transform: uppercase;float: right;margin-right: 18%;" ></asp:TextBox>
                       </div>
                      <div style="width: 45%;margin-top: 1%;margin-left: 2%;float: left;">
                         <h2 style="float: left;margin-left: 5%;">Contact Number</h2>
                <asp:TextBox ID="txtContact" class="form1" runat="server" MaxLength="15" style="width:39%;text-align:left; text-transform: uppercase;float: right;margin-right: 20%;"  onkeydown="return isNumber(event);" onblur="BlurNotNumber('cphMain_txtContact')" ></asp:TextBox>
                       </div>
                       <div style="width: 45%;margin-top: 1%;margin-right: 5%;float:right">
                         <h2>RF ID Tag Number*</h2>
                <asp:TextBox ID="txtRFIDTagNum" class="form1" runat="server" MaxLength="30" style="width:39%; text-transform: uppercase;float: right;margin-right: 20%;"></asp:TextBox>
                        </div>
                      <div style="width: 45%;margin-top: 1%;margin-left: 2%;float: left;">
                         <h2 style="margin-left:5%;">Current Mileage*</h2>
                <asp:TextBox ID="txtCurrentMileage" class="form1" runat="server" MaxLength="7" style="width:39%;text-align:right; text-transform: uppercase;float: right;margin-right: 20%;" onkeydown="return isNumber(event);" onblur="BlurNotNumber('cphMain_txtCurrentMileage')"></asp:TextBox>
                       </div>
                  
                    <div style="width: 45%;margin-top: 1%;margin-right: 5%;float:right">
                         <h2 >Fuel Limit Per Day</h2>
                <asp:TextBox ID="txtFuelLimit" class="form1" runat="server" MaxLength="7" style="width:39%;text-align:right; text-transform: uppercase;float: right;margin-right: 20%;" onkeydown="return isDecimalNumber(event,'cphMain_txtFuelLimit');" onblur="AmountCheck('cphMain_txtFuelLimit');"></asp:TextBox>

                        </div>
                 </div>

                 <%--divpermit details--%>
                  <div id="divPermitDetails" style="width: 100%;height:310px; float: left;padding-bottom:2%;background-color: #f9f9f9;display:none;">
                      <div style="width: 96%;margin-top:.5%;margin-right: 2%;float:right;color: #008641;">
                    <asp:Label ID="lblPermitRnwlNtPosible" runat="server" Text="Renewal Has Been Done.Amendment Denied!" Style="float:right; font-family: Calibri; font-size: 17px;"></asp:Label>
                    </div>
                     
                <div id="divPermitExpiryDate" runat="server" style="width: 42%;margin-top: 2%;margin-left: 1%;float:left;">
                 <h2 id="Permit_Exp_Date" runat="server">Permit Expiry Date*</h2>
               <div id="expryDate" class="input-append date" style="font-family:Calibri;float:right;width:59.5%">
                 <asp:TextBox ID="txtPermitExpiryDate" class="textDate" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width:63.8%;height:23px; font-family: calibri;" ></asp:TextBox>

                        <img id= "img1" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style=" height:17px; width:12px; cursor:pointer;" />

                        <script type="text/javascript">
                            var $noC2 = jQuery.noConflict();
                            $noC2('#expryDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,



                            });

                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>
          
                       <div style="width: 45%; float: right;margin-top: 2%;margin-right:11%;">
                    <div class="leads_form_left" style="width: 100%;font-family: Calibri;">
                        <div id="headingFileUploadPermit" style="width: 97%; background-color: rgb(147, 164, 116); color: white; font-size: 17px; font-weight: bold; padding-bottom: 0.3%; padding-top: 0.3%; margin-bottom: -1%; padding-left: 1%;">Add Files</div>
                        &nbsp;&nbsp;

  

                        <div id="divPerAtch" runat="server"  style="overflow-y: auto;height: 200px;width: 98%;">


                        <table id="TableFileUploadContainerPermit" style="width: 100%;">
                        </table>
                        </div>
                        <br />

                     
                    </div>


                </div>
                      <div id="divRenewPermit" runat="server" style="width: 10%;height: 107px;float: right;margin-right: -57%;margin-top: 12%;cursor:pointer" onclick="PermitRenewalRedirect(1)">
                          <img id="imgPermitRenewal" src="/Images/Icons/Renewal_Big.png" style="margin-left: 21%;" />
                      <h2 style="margin-top: 1%;">Click To Renew</h2>
                           </div>


               </div>

                 <%--div Insurance details--%>

                  <div id="divInsuranceDetails" style="width: 100%;height:310px; float: left;padding-bottom:2%;background-color: #f9f9f9;display:none;">
                    <div style="width: 96%;margin-top:.5%;margin-right: 2%;float:right;color: #008641;">
                    <asp:Label ID="lblInsEditNotPsbl" runat="server" Text="Renewal Has Been Done.Amendment Denied!" Style="float:right; font-family: Calibri; font-size: 17px;"></asp:Label>
                    </div>

                  <div style="width: 45%;margin-top:1%;margin-left: -0.5%;float:left">
                     <h2 style="float: left;margin-left: 5%;">Insurance Number*</h2>
                <asp:TextBox ID="txtInsurance" class="form1" runat="server" MaxLength="100" style="width:44%;float: right;margin-right:-3%;"></asp:TextBox>

                </div>
                   <div id="divInsurProvider" style="width: 45%;margin-top: 1%;margin-right: 2%;float: right;">
                     <h2>Insurance Provider*</h2>
                 <asp:DropDownList ID="ddlInsuranceProvider" class="form1" runat="server" Style="height:30px;width:47.5%;margin-right: 12%;float: right;" onkeydown="return DisableEnter(event)" ></asp:DropDownList>

                </div>

                        <div style="width: 49%; float: left;margin-top: 1%;">
                    <div class="leads_form_left" style="width: 100%;font-family: Calibri;">
                        <div id="headingFileUploadInsurance" style="width: 89%; background-color: rgb(147, 164, 116); color: white; font-size: 17px; font-weight: bold; padding-bottom: 0.3%; padding-top: 0.3%; margin-bottom: -1%; padding-left: 1%;">Add Files</div>
                        &nbsp;&nbsp;

   

                          <div id="divInsAtch" style="overflow-y: auto;height: 175px;width: 90%;">
                        <table id="TableFileUploadContainerInsurance" style="width: 100%;">

                        </table>
                        </div>
                        <br />

                      
                    </div>


                </div>





                      <div id="divInsureexpirydate" runat="server" style="width: 45%;margin-top: 1%;margin-right: 2%;float:right">
                 <h2 style="float: left;margin-left: 0%;">Insurance Expiry Date*</h2>
               <div id="InsuranceExpiry" class="input-append date" style="font-family:Calibri;float:right;width:59.5%">
                 <asp:TextBox ID="txtInsuranceExpiry" class="textDate" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width:69.8%;height:23px; font-family: calibri;" ></asp:TextBox>

                        <img id= "img4" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style=" height:17px; width:12px; cursor:pointer;" />

                        <script type="text/javascript">
                            var $noC3 = jQuery.noConflict();
                            $noC3('#InsuranceExpiry').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,



                            });

                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>

                <div style="width: 45%;margin-top: 1%;margin-right: 2%;float: right;">
                     <h2 style="float: left;margin-left:0%;">Insurance Amount*</h2>
                <asp:TextBox ID="txtInsuranceAmount" class="form1" runat="server" MaxLength="15" style="text-align:right; width:44%;float: right;margin-right: 12%;" onkeydown="return isDecimalNumber(event,'cphMain_txtInsuranceAmount');" onblur="MoneyCheck('cphMain_txtInsuranceAmount');"></asp:TextBox>

                </div>

                 <div id="div2" style="width: 45%;margin-top: 1%;margin-right: 2%;float: right;">
                     <h2>Insurance Coverage Type*</h2>
                 <asp:DropDownList ID="ddlCoverageType" class="form1" runat="server" Style="height:30px;width:47.5%;margin-right: 12%;float: right;" onkeydown="return DisableEnter(event)" ></asp:DropDownList>

                </div>

            
                <div id="divInsuranceRenewal" runat="server" style="width: 14%;height: 107px;margin-left: 91%;margin-top: 17%;cursor:pointer" onclick="InsuranceRenewalRedirect(1)">
                          <img id="imgInsuranceRenewal" runat="server" src="/Images/Icons/Renewal_Big.png" style="margin-left:15%;width:37%;"/>
                           <h2 style="margin-top: 1%;">Click To Renew</h2>
                      </div>
                 </div>

             <div id="divVehicleImages" style="width: 100%;height:310px; float:left;padding-bottom:2%;background-color: #f9f9f9;display:none;">

          <div style="display:none;width: 45%;margin-top: 6%;margin-left: 24%;float:left">
              
                <h2 style="margin-top: 1%;">Upload Images</h2>
                <label for="cphMain_FileUploadVehImg1" class="custom-file-upload" tabindex="0" style="margin-left: 20%;">
                    <img src="/Images/Icons/cloud_upload.jpg" />Upload File</label>
    

                <asp:FileUpload ID="FileUploadVehImg1" class="fileUpload" runat="server" Style="height: 30px; display:none;" onchange="ClearDivDisplayVehicle2()" Accept="image/png, image/gif, image/jpeg" />


                <div id="div1" runat="server" style="float: right; width: 54%; height: 20px; margin-top: -1%;">
                    <div class="imgWrap">
                        <img id="ClearImage2" src="/Images/Icons/clear-image-green.png" alt="Clear" onclick="ClearImage2()" onmouseover="ImagePosition2('ClearImage2')"; style="cursor: pointer; float: right;" />
                        <p id="RemovePhoto2" class="imgDescription" style="color: white">Remove Selected Photo</p>
                    </div>
                    <div id="divImageDisplay2" runat="server">
                    </div>
                </div>
                <asp:Label ID="Label6" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
           
            </div>
             <div style="display:none;width: 33%;margin-top: 2%;margin-right: 31%;float: right;">
              
                <label for="cphMain_FileUploadVehImg2" class="custom-file-upload" tabindex="0" style="margin-left: 18%;">
                    <img src="/Images/Icons/cloud_upload.jpg" />Upload File</label>

                <asp:FileUpload ID="FileUploadVehImg2" class="fileUpload" runat="server" Style="height: 30px; display:none;" onchange="ClearDivDisplayVehicle3()" Accept="image/png, image/gif, image/jpeg" />


                <div id="div3" runat="server" style="float: right; width: 74%; height: 20px; margin-top: -1%;">
                    <div class="imgWrap">
                        <img id="ClearImage3" src="/Images/Icons/clear-image-green.png" alt="Clear" onclick="ClearImage3()" onmouseover="ImagePosition3('ClearImage3')"; style="cursor: pointer; float: right;" />
                        <p id="RemovePhoto3" class="imgDescription" style="color: white">Remove Selected Photo</p>
                    </div>
                    <div id="divImageDisplay3" runat="server">
                    </div>
                </div>
                <asp:Label ID="Label7" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
           
            </div>
                  <div style="width: 54%; float: left;margin-top: 3%;margin-left: 24%;">
                    <div class="leads_form_left" style="width: 100%;font-family: Calibri;">
                        <div id="headingFileUploadVhclImage" style="width: 80%; background-color: rgb(147, 164, 116); color: white; font-size: 17px; font-weight: bold; padding-bottom: 0.3%; padding-top: 0.3%; margin-bottom: -1%; padding-left: 1%;">Add Files</div>
                        &nbsp;&nbsp;

    <%--<input id="Button1" class="save" type="button" value="add" onclick="AddFileUpload()" />--%>

                         <div style="overflow-y: auto;height: 185px;width: 84%;">
                        <table id="TableFileUploadContainerVehicleImg" style="width: 97%;">
                        </table>
                        </div>
                        <br />

                        <%--  <asp:Button ID="btnUpload" runat="server" 
                            Text="Upload" OnClick="btnUploadFile_Click" />--%>
                    </div>


                </div>

                 </div>
           

                 <div id="divTankerDetails" style="width: 100%;height:310px; float: left;padding-bottom:2%;background-color: #f9f9f9;display:none;">
                    
               



                      <div id="divTankCapacity" style="width: 45%;margin-top: 3%;margin-left: 27%;float:left;visibility:hidden">
                     <h2>Tanker Capacity*</h2>
                 <h2 style="margin-top: 2%;margin-right: 11%;float:right">Barrel</h2>
                <asp:TextBox ID="txtTankerCapacity" class="form1" runat="server" MaxLength="7" style="width:40%;float: right;text-align:right; margin-right: 2%;" onkeydown="return isDecimalNumber(event,'cphMain_txtTankerCapacity');" onblur="AmountCheckTanker('cphMain_txtTankerCapacity');"></asp:TextBox>
                           
                </div>
                     <div id="divAmountPerbarrel" style="width: 45%;margin-top: 2%;margin-left: 27%;float:left;visibility:hidden">
                
                  <h2 style="margin-top: 2%;margin-right: 10%;float:left">Amount Per Barrel*</h2>
                <asp:TextBox ID="txtAmountPerBarrel" class="form1" runat="server" MaxLength="7" style="text-align:right; width:40%;float: right;margin-right: 20.5%;" onkeydown="return isDecimalNumber(event,'cphMain_txtAmountPerBarrel');" onblur="MoneyCheckTanker('cphMain_txtAmountPerBarrel');"></asp:TextBox>
                           
                </div>

                      </div>





                 
                 <div id="divTrailerDetails" style="width: 100%;height:310px; float: left;padding-bottom:2%;background-color: #f9f9f9;display:none;">
                       
                                 
                  <div id="divTrailerIstamara" style="width: 49%;float:left;visibility:hidden;border: 1px solid;border-color: #d5d5d5;height: 320px;margin:6px 6px 6px 6px;">
                     

                       <div style="width: 96%;margin-top:.5%;margin-right: 2%;float:right;color: #008641;margin-bottom:0.5%;">
                    <asp:Label ID="lblTRprmtRnwlNotPos" runat="server" Text="Renewal Has Been Done.Amendment Denied!" Style="float:right; font-family: Calibri; font-size: 17px;"></asp:Label>
                    </div>


                      <div id="divRegNum" style="margin-top:2%;">
                  <h2 style="margin-left:1%;">Trailer Registration Number*</h2>               
                 <asp:TextBox ID="txtBedIstamara" class="form1" runat="server" MaxLength="100" style="width:40%;float: right;text-align:left; margin-right: 2%;height:24px;text-transform: uppercase;"  ></asp:TextBox>
                       </div>
                         
                       <div id="divTRperExpDate" runat="server" style="width: 100%;margin-top: 2%;margin-left: 1%;float:left;">
                 <h2  runat="server">Registration Expiry Date*</h2>
               <div id="Div5" runat="server" class="input-append date" style="font-family:Calibri;float:right;width:59.5%">
                 <asp:TextBox ID="txtTrPerExpDate" class="textDate" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width:63.8%;height:23px; font-family: calibri;margin-left:22%;" ></asp:TextBox>

                        <img id= "img2" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style=" height:17px; width:12px; cursor:pointer;" />

                        <script type="text/javascript">
                            var $noC9 = jQuery.noConflict();
                            $noC9('#cphMain_Div5').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,



                            });

                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>

                       <div style="width: 100%; float: right;margin-top: 2%;">
                    <div class="leads_form_left" style="width: 100%;font-family: Calibri;margin: 0 0 6px 7px;">
                        <div id="Div6" style="width: 97%; background-color: rgb(147, 164, 116); color: white; font-size: 17px; font-weight: bold; ">Add Files</div>
                        &nbsp;&nbsp;
                        <div id="div7" runat="server"  style="overflow-y: auto;width: 98%;height:90px;">


                        <table id="tableTrPerFiles" style="width: 100%;">
                        </table>
                        </div>
                        <br />
                    </div>


                </div>
                   

                       <div id="divTrRnwlIconPrmt" runat="server" style="width: 20%;height: 107px;float: right;margin-right: -100%;margin-top: 32.5%;cursor:pointer" onclick="PermitRenewalRedirect(2)">
                          <img id="img3" src="/Images/Icons/Renewal_Big.png" style="margin-left: 38%;width:26%;" />
                      <h2 style="margin-top: 1%;margin-left:12%;font-size:15px;">Click To Renew</h2>
                           </div>
        
                 </div>



                     <div id="divTrailerIns" style="width: 49%;float:left;visibility:hidden;border: 1px solid;border-color: #d5d5d5;height: 320px;margin:6px 6px 6px 0px;">
                    
                         
                          <div style="width: 96%;margin-top:.5%;margin-right: 2%;float:right;color: #008641;">
                    <asp:Label ID="lblTrInsRnwlPos" runat="server" Text="Renewal Has Been Done.Amendment Denied!" Style="float:right; font-family: Calibri; font-size: 17px;"></asp:Label>
                    </div>
                              
                <div id="divTrInsNum" style="margin-top:1%;">
                  <h2 style="margin-left:1%;">Trailer Insurance Number*</h2>
                <asp:TextBox ID="txtBedInsNumber" class="form1" runat="server" MaxLength="100" style="text-align:left; width:40%;float: right;margin-right: 2%;margin-top:1%;height:24px;" ></asp:TextBox>
                   </div> 
                      <div id="divTrInsPrvdr" runat="server" style="width: 100%;margin-top:8.5%;">
                     <h2 style="margin-left:1%;margin-top:1%;">Insurance Provider*</h2>
                 <asp:DropDownList ID="ddlTRinsPrvdr" class="form1" runat="server" Style="height:24px;width:43%;margin-right: 2%;float: right;" onkeydown="return DisableEnter(event)" ></asp:DropDownList>

                </div>

                     
                      <div id="divTrInsExpDate" runat="server" style="width: 100%;margin-top:15%;">
                 <h2 style="float: left;margin-left: 1%;">Insurance Expiry Date*</h2>
               <div id="Div13" class="input-append date" style="font-family:Calibri;float:right;width:45.5%">
                 <asp:TextBox ID="txtTRinsExpDate" class="textDate" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width:82.8%;height:23px; font-family: calibri;margin-left:1%;" ></asp:TextBox>

                        <img id= "img5" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style=" height:17px; width:12px; cursor:pointer;" />

                        <script type="text/javascript">
                            var $noC3 = jQuery.noConflict();
                            $noC3('#Div13').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,



                            });

                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>

                <div style="width: 100%;margin-top: 0.5%;float: right;">
                     <h2 style="float: left;margin-left:1%;">Insurance Amount*</h2>
                <asp:TextBox ID="txtTrInsAmnt" class="form1" runat="server" MaxLength="15" style="text-align:right; width:40%;float: right;margin-right: 2%;height:24px;" onkeydown="return isDecimalNumber(event,'cphMain_txtTrInsAmnt');" onblur="MoneyCheck('cphMain_txtTrInsAmnt');"></asp:TextBox>

                </div>

                 <div id="div14" style="width: 100%;margin-top: 1%;float: right;">
                     <h2 style="float: left;margin-left:1%;">Insurance Coverage Type*</h2>
                 <asp:DropDownList ID="ddlTrInsCvrgeTyp" class="form1" runat="server" Style="height:24px;width:43%;margin-right: 2%;float: right;" onkeydown="return DisableEnter(event)" ></asp:DropDownList>

                </div>

               <div style="width: 100%;">
                    <div class="leads_form_left" style="width: 97%;font-family: Calibri;margin: 6px 0 6px 7px;">
                        <div id="Div10" style=" background-color: rgb(147, 164, 116); color: white; font-size: 17px; font-weight: bold; padding-bottom: 0.3%; padding-top: 0.3%; margin-bottom: -1%; padding-left: 1%;">Add Files</div>
                        &nbsp;&nbsp;

                          <div id="div11" style="overflow-y: auto;width: 100%;height:51px;">
                        <table id="tableTrInsFiles" style="width: 100%;">

                        </table>
                        </div>
                        <br />
                    </div>


                </div>
            
                 
                          <div id="divTRrnwlIconIns" runat="server" style="width: 20%;height: 107px;float: right;margin-right: 0%;margin-top: -6%;cursor:pointer" onclick="InsuranceRenewalRedirect(2)">
                          <img id="img6" src="/Images/Icons/Renewal_Big.png" style="margin-left: 38%;width:26%;" />
                      <h2 style="margin-top: 1%;margin-left:12%;font-size:15px;">Click To Renew</h2>
                           </div>
                         
                                     
                </div>

                    

                 </div>

              </div>
            
                       
           


            <br />
            <div class="eachform">
                <div class="subform" style="width: 65%; margin-top:2%">


                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return VehicleMasterValidate();"/>
                      <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return VehicleMasterValidate();"/>
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return VehicleMasterValidate();"/>
                     <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return VehicleMasterValidate();"/>
                     <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" PostBackUrl="/AWMS/AWMS_Master/gen_Vehicle_Master/gen_Vehicle_Master_List.aspx"/>
                <asp:Button ID="btnClear" runat="server" style="margin-left: 19px;" OnClientClick="return AlertClearAll();" OnClick="btnClear_Click" class="cancel" Text="Clear"/>
                </div>
            </div>

        </div>
    </div>




            <style>
         
        .fileUpload {
            margin-left: -17%;
            position: relative;
            z-index: 1;
        }

        .custom-file-upload {
            margin-left: 20%;
            border: 1px solid #ccc;
            display: inline-block;
            padding: 2px 4px;
            cursor: pointer;
            position: relative;
            z-index: 2;
            font-family: Calibri;
            background: white;
        }

         .imgDescription {
            position: absolute;
            /*top: 511px;
            left: 6.5%;*/
            background: rgba(123, 150, 100, 0.7);
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
.open > .dropdown-menu {
    display: none;
}


            .eachform h2 {
                margin: 6px 0 6px;
                color:#657844;
            }

            .cont_rght {
    width: 98%;
    display: block;
    float: none;
    padding: 57px 0 0;
    margin: auto;
    padding-top: 1%;
    margin-left: 0.2%;
}

    </style>
</asp:Content>



