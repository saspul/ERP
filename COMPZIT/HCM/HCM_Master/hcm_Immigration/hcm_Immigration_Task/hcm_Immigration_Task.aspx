<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Immigration_Task.aspx.cs" EnableEventValidation="false" Inherits="HCM_HCM_Master_hcm_Immigration_hcm_Immigration_Task_hcm_Immigration_Task" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <style>
     .divbutton {
            display: inline-block;
            color: #0C7784;
            border: 1px solid #999;
            background: #CBCBCB;
            /*box-shadow: 0 0 5px -1px rgba(0,0,0,0.2);*/
            cursor: pointer;
            vertical-align: middle;
            min-width: 15%;
            padding: 5px;
            text-align: center;
            font-family: calibri;
            word-break: break-all;
        }

            .divbutton:active {
                color: red;
                box-shadow: 0 0 5px -1px rgba(0,0,0,0.6);
            }

        #divMessageAreaVisa {
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
            word-break: break-all;
        }
        .datelbl {
            margin-left: 27.5%;
            font-size: 15px;
            font-family: Calibri;
        }
       
        </style>
     <style type="text/css">
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
             font-family: Calibri;
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
             z-index: 3;
             right: 18%;
             z-index: 102;
         }

             .lightbox-target:target img {
                 max-height: 100%;
                 max-width: 80%;
             }

             .lightbox-target:target a.lightbox-close {
                 top: 0px;
             }
     </style>
    <style>
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
             padding: 4% 4% 7% 4%;
         }

         .modal-footerCancelView {
             padding: 2% 1%;
           background-color: #91a172;
             color: white;
         }
         #divErrorMV {
    border-radius: 4px;
    background: #fff;
    color: #53844E;
    font-size: 12.5px;
    font-family: Calibri;
    font-weight: bold;
    border: 2px solid #53844E;
    margin-top: -3.5%;
    margin-bottom: 2%;
}
    </style>
    <script src="../../../../JavaScript/jquery-1.8.3.min.js"></script>
    <script>

       
        function TabClick(x) {
            
            if (x != document.getElementById("<%=HiddenFieldRoundNo.ClientID%>").value) {
                document.getElementById('divMessageAreaVisa').style.display = "none";
            }


            document.getElementById("Tab" + document.getElementById("<%=HiddenFieldRoundNo.ClientID%>").value).style.pointerEvents = "";
            document.getElementById("Tab" + x).style.pointerEvents = "none";
           

            document.getElementById("<%=HiddenFieldRoundNo.ClientID%>").value = x;
            var NoRnd = document.getElementById("<%=HiddenFieldNoRnd.ClientID%>").value;
            var RndName = document.getElementById("Tab" + x).innerHTML;
            document.getElementById("<%=HiddenFieldRoundName.ClientID%>").value =RndName;         
            var CandId = document.getElementById("<%=HiddenFieldCandId.ClientID%>").value;  

            if (confirmboxVisa > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    document.getElementById("<%=txtScdldDate.ClientID%>").style.borderColor = "";
                    confirmboxVisa = 0;


                    for (var i = 0; i < NoRnd; i++) {
                        if (i != x) {
                            document.getElementById("Tab" + i).style.backgroundColor = "#CBCBCB";
                        }
                        else {
                            document.getElementById("Tab" + i).style.backgroundColor = "#f9f9f9";
                            document.getElementById('cphMain_ddlVisaSts').focus();
                           
                        }
                       
                    }
                   
                  
                   
                    var Details = PageMethods.ReadRoundDtlsByCandId(CandId, RndName, function (response) {
                       
                        document.getElementById("<%=lblVisaTrgtDate.ClientID%>").innerText = response.ExpTrgDate;
                        document.getElementById("<%=HiddenFieldTrgtDate.ClientID%>").value = response.ExpTrgDate;
                        document.getElementById("<%=HiddenFieldImmgrtnId.ClientID%>").value = response.ImmgrtnId;
                        document.getElementById("<%=HiddenFieldImmgrtnDtlId.ClientID%>").value = response.ImmgrtnDtlId;
                        
                        document.getElementById("<%=HiddenFieldRoundId.ClientID%>").value = response.RoundId;
                        DDlBindSts(response.StsId, response.StsActiveStatus, response.strStsName);
                        document.getElementById("<%=txtScdldDate.ClientID%>").value = response.ShdlDate;
                        document.getElementById("cphMain_divWrkImgdis").innerHTML = response.strImg;
                        document.getElementById("<%=hiddenUserImage.ClientID%>").value = response.Fname;
                        document.getElementById("<%=lblStatus.ClientID%>").style.display = "none";
                    if (response.FinishSts == 1 || response.CloseSts == 1) {
                        visaDis();
                        if (response.FinishSts == 1) {
                            document.getElementById("<%=lblStatus.ClientID%>").innerText = "Finished";
                            document.getElementById("<%=lblStatus.ClientID%>").style.display = "";

                        }
                        if (response.CloseSts == 1) {
                            document.getElementById("<%=lblStatus.ClientID%>").innerText = "Closed";
                            document.getElementById("<%=lblStatus.ClientID%>").style.display = "";

                        }
                    }
                    else {
                        visaUnDis();
                    }
                    });
                    
                }
            }
            else {
                document.getElementById("<%=txtScdldDate.ClientID%>").style.borderColor = "";
                for (var i = 0; i < NoRnd; i++) {
                    if (i != x) {
                        document.getElementById("Tab" + i).style.backgroundColor = "#CBCBCB";
                    }
                    else {
                        document.getElementById("Tab" + i).style.backgroundColor = "#f9f9f9";
                        document.getElementById('cphMain_ddlVisaSts').focus();
                    }
                }
               
                var Details = PageMethods.ReadRoundDtlsByCandId(CandId, RndName, function (response) {
                    document.getElementById("<%=lblVisaTrgtDate.ClientID%>").innerText = response.ExpTrgDate;
                    document.getElementById("<%=HiddenFieldRoundId.ClientID%>").value = response.RoundId;
                    document.getElementById("<%=HiddenFieldTrgtDate.ClientID%>").value = response.ExpTrgDate;
                    document.getElementById("<%=HiddenFieldImmgrtnId.ClientID%>").value = response.ImmgrtnId;
                    document.getElementById("<%=HiddenFieldImmgrtnDtlId.ClientID%>").value = response.ImmgrtnDtlId;
                   // alert(response.StsId + "sts " + response.StsActiveStatus + "Name " + response.strStsName);

                    DDlBindSts(response.StsId, response.StsActiveStatus, response.strStsName);


                    document.getElementById("<%=txtScdldDate.ClientID%>").value = response.ShdlDate;
                    document.getElementById("cphMain_divWrkImgdis").innerHTML = response.strImg;
                    document.getElementById("<%=hiddenUserImage.ClientID%>").value = response.Fname;
                    document.getElementById("<%=lblStatus.ClientID%>").style.display = "none";
                    if (response.FinishSts == 1 || response.CloseSts == 1) {

                        visaDis();
                        if (response.FinishSts == 1) {
                            document.getElementById("<%=lblStatus.ClientID%>").innerText = "Finished";
                              document.getElementById("<%=lblStatus.ClientID%>").style.display = "";

                          }
                          if (response.CloseSts == 1) {
                              document.getElementById("<%=lblStatus.ClientID%>").innerText = "Closed";
                            document.getElementById("<%=lblStatus.ClientID%>").style.display = "";

                        }
                    }
                    else {
                        visaUnDis();
                    }
                });          
                
               
            }
        }
        function DDlBindSts(id,StsActiveStatus,strStsName) {
           
            document.getElementById("<%=ddlVisaSts.ClientID%>").options.length = 0;
            var RndId = document.getElementById("<%=HiddenFieldRoundId.ClientID%>").value;
            var tableName = "dtTableDivision";
            var $coo = jQuery.noConflict();
            var ddlTestDropDownListXML = $coo(document.getElementById("<%=ddlVisaSts.ClientID%>"));
                if (RndId != "") {
                    $coo.ajax({
                        type: "POST",
                        url: "hcm_Immigration_Task.aspx/DDLbind",
                        data: '{tableName:"' + tableName + '",RndId:"' + RndId + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            ddlTestDropDownListXML.empty();

                            var CompOptnValue;
                            var CompOptnText;
                            //var OptionStart = $coo("<option>Job Assigned</option>");
                            //OptionStart.attr("value", 0);
                            //ddlTestDropDownListXML.append(OptionStart);
                            // Now find the Table from response and loop through each item (row).
                            $coo(response.d).find(tableName).each(function () {
                                // Get the OptionValue and OptionText Column values.
                                var OptionValue = $coo(this).find('IMGRTNRNDDTL_ID').text();
                                var OptionText = $coo(this).find('IMGRTNRNDDTL_NAME').text();
                                var CompleteOptn = $coo(this).find('IMGRTNRNDDTL_CMPLT').text();
                                if (CompleteOptn != 1) {
                                    // Create an Option for DropDownList.
                                    var option = $coo("<option>" + OptionText + "</option>");
                                    option.attr("value", OptionValue);
                                    ddlTestDropDownListXML.append(option);
                                }
                                else {
                                   CompOptnValue = $coo(this).find('IMGRTNRNDDTL_ID').text();
                                   CompOptnText = $coo(this).find('IMGRTNRNDDTL_NAME').text();
                                   
                                }


                            });

                            var valueExists = 0;
                         
                            if (StsActiveStatus == 0) {
                                var option1 = $coo("<option>" + strStsName + "</option>");
                                option1.attr("value", id);
                                ddlTestDropDownListXML.append(option1);
                            }
                        
                            var option = $coo("<option>" + CompOptnText + "</option>");
                            option.attr("value", CompOptnValue);
                            ddlTestDropDownListXML.append(option);

                            document.getElementById("<%=ddlVisaSts.ClientID%>").value = id;

                        },
                        failure: function (response) {

                        }
                    });



                }
                
        }
    </script>
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
        function SuccessAdd() {
            TabClick(document.getElementById("<%=HiddenFieldRoundNo.ClientID%>").value);
            document.getElementById('divMessageAreaVisa').style.display = "";
            document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = document.getElementById("<%=HiddenFieldRoundName.ClientID%>").value+" details saved successfully.";
            document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaInfo.png";
           

        }
      
        function SuccessClose() {
            document.getElementById("<%=lblStatus.ClientID%>").innerText = "Closed";
            document.getElementById("<%=lblStatus.ClientID%>").style.display = "";
            document.getElementById('divMessageAreaVisa').style.display = "";
            document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = document.getElementById("<%=HiddenFieldRoundName.ClientID%>").value + " details closed successfully.";
            document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaInfo.png";
           

        }
        
        function DupFinishCls() {
            document.getElementById('divMessageAreaVisa').style.display = "";
            document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = document.getElementById("<%=HiddenFieldRoundName.ClientID%>").value + " details finished or closed by another user.";
            document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaInfo.png";


        }
        function SuccessFinish() {
            document.getElementById('divMessageAreaVisa').style.display = "";
            //alert(document.getElementById("<%=HiddenFieldRoundName.ClientID%>").value);
            document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = document.getElementById("<%=HiddenFieldRoundName.ClientID%>").value + " details finished successfully.";
            document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaInfo.png";
          

        }
        function SuccessRescdl() {
            document.getElementById('divMessageAreaVisa').style.display = "";
            document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = document.getElementById("<%=HiddenFieldRoundName.ClientID%>").value + " details rescheduled successfully.";
            document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaInfo.png";

        }
        
        function visaDis() {
            document.getElementById("<%=ddlVisaSts.ClientID%>").disabled = true;
            document.getElementById("<%=txtVisaExptdDate.ClientID%>").disabled = true;
            document.getElementById("divVisaExpDate").style.pointerEvents = "none";
            document.getElementById("cphMain_btnAddVisa").style.display = "none";
            document.getElementById("cphMain_btnClearVisa").style.display = "none";
            document.getElementById("cphMain_divVisaClose").style.display = "none";
            document.getElementById("cphMain_divVisaFinish").style.display = "none";
            document.getElementById("<%=txtScdldDate.ClientID%>").disabled = true;
            document.getElementById("divShdlDate").style.pointerEvents = "none";
            document.getElementById("cphMain_FileUploadWrk").disabled = true;
        }
        function visaUnDis() {
            document.getElementById("<%=ddlVisaSts.ClientID%>").disabled = false;
            document.getElementById("<%=txtVisaExptdDate.ClientID%>").disabled = false;
            document.getElementById("divVisaExpDate").style.pointerEvents = "";
            document.getElementById("cphMain_btnAddVisa").style.display = "block";
            document.getElementById("cphMain_btnClearVisa").style.display = "block";
            document.getElementById("cphMain_divVisaClose").style.display = "block";
            document.getElementById("cphMain_divVisaFinish").style.display = "block";
            document.getElementById("<%=txtScdldDate.ClientID%>").disabled = false;
            document.getElementById("divShdlDate").style.pointerEvents = "";
            document.getElementById("cphMain_FileUploadWrk").disabled = false;
        }
        function CloseVisa() {
            var rndNameOnClose = document.getElementById("<%=HiddenFieldRoundName.ClientID%>").value;
            if (confirm("Are you sure you want to close " + rndNameOnClose + " details?")) {
            var OnbrdId = document.getElementById("<%=HiddenFieldRoundId.ClientID%>").value;
            var CandId = document.getElementById("<%=HiddenFieldCandId.ClientID%>").value;
            var UserId = document.getElementById("<%=HiddenFieldLogUserId.ClientID%>").value;
           

            var ImgrtnId = document.getElementById("<%=HiddenFieldImmgrtnId.ClientID%>").value;
            var ImgrtnDtlId = document.getElementById("<%=HiddenFieldImmgrtnDtlId.ClientID%>").value;
            var StsId = document.getElementById("<%=ddlVisaSts.ClientID%>").value

            var Details = PageMethods.CloseRound(OnbrdId, CandId, UserId, ImgrtnId, ImgrtnDtlId, StsId, function (response) {
                visaDis();
                if (response == "false") {
                    DupFinishCls();
                }
                else {
                    SuccessClose();
                }             
               
            });
            }
            
        }
       
        function finishVisa() {
            var OnbrdId = document.getElementById("<%=HiddenFieldRoundId.ClientID%>").value;
            var CandId = document.getElementById("<%=HiddenFieldCandId.ClientID%>").value;
            var UserId = document.getElementById("<%=HiddenFieldLogUserId.ClientID%>").value;
            var ReshdlDate = document.getElementById("<%=txtReshdlDate.ClientID%>").value;
            var Details = PageMethods.finisRound(OnbrdId, CandId, UserId, ReshdlDate, function (response) {
               
                if (ReshdlDate == "") {
                    visaDis();
                    SuccessFinish();
                }
                else {
                    SuccessRescdl();
                }
                
            });
        }
       
    </script>
    <script>
        function ClearDivDisplayImageWrkExp() {

            IncrmntConfrmCounterVisa();
            var FileUploadPath = document.getElementById("<%=FileUploadWrk.ClientID%>").value.replace("C:\\fakepath\\", "");
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

            if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                        || Extension == "jpeg" || Extension == "jpg") {

            }
            else {
                document.getElementById("<%=FileUploadWrk.ClientID%>").value = "";
                document.getElementById("<%=LabelWrkAttmnt.ClientID%>").textContent = "No File Selected";
                alert("The specified file type could not be uploaded.Only support image files");

            }


            if (document.getElementById("<%=FileUploadWrk.ClientID%>").value != "") {
                 document.getElementById("<%=LabelWrkAttmnt.ClientID%>").textContent = document.getElementById("<%=FileUploadWrk.ClientID%>").value.replace("C:\\fakepath\\", "");
                document.getElementById("<%=divWrkImgdis.ClientID%>").innerHTML = "";
                document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";
            }
        }

        function ClearImageWrkExpClear() {
          

                    document.getElementById("<%=FileUploadWrk.ClientID%>").value = "";
                    document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";
                    document.getElementById("<%=divWrkImgdis.ClientID%>").innerHTML = "";
                    document.getElementById("<%=LabelWrkAttmnt.ClientID%>").textContent = "No File Selected";
                    //  alert("Image has been Removed Sucessfully. ");
              
        }


        function ClearImageWrkExp() {
            if (document.getElementById("<%=hiddenUserImage.ClientID%>").value != "" || document.getElementById("<%=FileUploadWrk.ClientID%>").value != "") {
                if (confirm("Do You Want To Remove Selected Photo?")) {

                    document.getElementById("<%=FileUploadWrk.ClientID%>").value = "";
                    document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";
                    document.getElementById("<%=divWrkImgdis.ClientID%>").innerHTML = "";
                    document.getElementById("<%=LabelWrkAttmnt.ClientID%>").textContent = "No File Selected";
                    //  alert("Image has been Removed Sucessfully. ");
                }
                else {

                }

            }
        }
    </script>
    <script>
        function OpenCancelView() {
            if (VisaAdd()) {


                document.getElementById("divAlocate").style.display = "block";
                document.getElementById("freezelayer").style.display = "";
                document.getElementById("<%=headPopup.ClientID%>").innerHTML = document.getElementById("<%=HiddenFieldRoundName.ClientID%>").value + " STATUS";
                RadioChange();
                return false;
            }
                  
          }
         // function CloseCancelView() {
           //   if (confirm("Do you want to close this window?")) {
             //     document.getElementById('divMessageArea').style.display = "none";
               //   document.getElementById('imgMessageArea').src = "";
                 // document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  //document.getElementById("divAlocate").style.display = "none";
                  //document.getElementById("freezelayer").style.display = "none";
        
        //      }
          //    return false;
          //}

            function closeVisaModelView() {
                document.getElementById('divMessageArea').style.display = "none";
                document.getElementById('imgMessageArea').src = "";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
               // document.getElementById("divAlocate").style.display = "none";
                document.getElementById("MymodalCancelView").style.display = "none";
                
                document.getElementById("freezelayer").style.display = "none";
            }
        function CloseCancelView() {
            if (confirm("Do you want to close  without completing Closing Process?")) {
                closeVisaModelView();
                return false;

            }
            else {
                return false;
            }
        }

        function ValidateFinish() {
          
            document.getElementById("<%=HiddenFieldDDlStsId.ClientID%>").value = document.getElementById("<%=ddlVisaSts.ClientID%>").value;

            document.getElementById('divErrorMV').style.visibility = "hidden";
            document.getElementById("<%=txtReshdlDate.ClientID%>").style.borderColor = "";
            if (document.getElementById("<%=radioNotAttend.ClientID%>").checked == true) {
              
                if (document.getElementById("<%=txtReshdlDate.ClientID%>").value == "") {

                    document.getElementById('divErrorMV').style.visibility = "visible";
                    document.getElementById("<%=lblErrorMV.ClientID%>").innerHTML = "Please enter reschedule date";
                    document.getElementById("<%=txtReshdlDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtReshdlDate.ClientID%>").focus();
                    return false;
                }
                else {
                    var RcptdatepickerDate = document.getElementById("<%=txtReshdlDate.ClientID%>").value;
                    var RarrDatePickerDate = RcptdatepickerDate.split("-");
                    var RdateDateCntrlr = new Date(RarrDatePickerDate[2], RarrDatePickerDate[1] - 1, RarrDatePickerDate[0]);

                    var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                    var arrCurrentDate = CurrentDateDate.split("-");
                    var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);


                    if (RdateDateCntrlr < dateCurrentDate) {
                        document.getElementById('divErrorMV').style.visibility = "visible";
                        document.getElementById("<%=lblErrorMV.ClientID%>").innerHTML = "Reschedule date should be greater than or equal to current date";
                         document.getElementById("<%=txtReshdlDate.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtReshdlDate.ClientID%>").focus();
                        return false;                     
                    }
                }
                var ExpDate = document.getElementById("<%=txtVisaExptdDate.ClientID%>").value;
                if (document.getElementById("<%=txtReshdlDate.ClientID%>").value != "") {
                    var datepickerDate = document.getElementById("<%=txtReshdlDate.ClientID%>").value;
                      var arrDatePickerDate = datepickerDate.split("-");
                      var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                      if (ExpDate == "") {
                          var datepickerDate = document.getElementById("<%=lblVisaTrgtDate.ClientID%>").innerText;
                }
                else {
                    var datepickerDate = document.getElementById("<%=txtVisaExptdDate.ClientID%>").value;
                }
                var arrDatePickerDate = datepickerDate.split("-");
                var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                if (dateTxIss > dateCompExp) {

                    document.getElementById('divErrorMV').style.visibility = "visible";
                    document.getElementById("<%=lblErrorMV.ClientID%>").innerHTML = "Scheduled date should be less than or equal to target date";
                      document.getElementById("<%=txtReshdlDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtReshdlDate.ClientID%>").focus();
                    return false;
                }
            }
            
            }
            

        }
        function RadioChange() {


            if (document.getElementById("<%=radioNotAttend.ClientID%>").checked == true) {
                document.getElementById("<%=txtReshdlDate.ClientID%>").disabled = false;
                document.getElementById("divRescdlDate").style.pointerEvents = "";
             }
             else {
                document.getElementById("<%=txtReshdlDate.ClientID%>").disabled = true;
                document.getElementById("divRescdlDate").style.pointerEvents = "none";
                document.getElementById("<%=txtReshdlDate.ClientID%>").value = "";
             }

         }
    </script>
    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            document.getElementById("freezelayer").style.display = "none";
            document.getElementById('divAlocate').style.display = "none";

            if (document.getElementById("<%=HiddenFieldShowDiv.ClientID%>").value == "false") {
                document.getElementById("divVisa").style.display = "none";
            }
            else {


                var NoRnd = document.getElementById("<%=HiddenFieldNoRnd.ClientID%>").value;
                var x = document.getElementById("<%=HiddenFieldRoundNo.ClientID%>").value;
                if (NoRnd > 0) {
                    TabClick(x);
                }

            }
            var MsgType = document.getElementById("<%=hiddenMsgType.ClientID%>").value;
            if (MsgType != "") {
      
                if (MsgType == "SuccessAdd") {
                    SuccessAdd();
                }
                else if (MsgType == "SuccessRescdl") {
                    SuccessRescdl();
                }
                else if (MsgType == "SuccessFinish") {
                    SuccessFinish();
                }
                else if (MsgType == "DupFinishCls") {
                    DupFinishCls();
                }
            }

        });



var confirmboxVisa = 0;
function IncrmntConfrmCounterVisa() {

    confirmboxVisa++;
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
    if (confirmboxVisa > 0 ) {
        if (confirm("Are you sure you want to leave this page?")) {
            window.location.href = "hcm_Immigration_Task_List.aspx";
            return false;
        }
        else {
            return false;
        }
    }
    else {
        window.location.href = "hcm_Immigration_Task_List.aspx";
        return false;
    }
}
function ConfirmCancel() {
    if (confirmboxVisa > 0 ) {
        if (confirm("Are you sure you want to cancel this page?")) {
            window.location.href = "hcm_Immigration_Task_List.aspx";
            return false;
        }
        else {
            return false;
        }
    }
    else {
        window.location.href = "hcm_Immigration_Task_List.aspx";
        return false;
    }
}

function AlertClearVisa() {
    if (confirmboxVisa > 0) {
        if (confirm("Are you sure you want clear all data in this page?")) {
            confirmboxVisa = 0;
            //TabClick(document.getElementById("<%=HiddenFieldRoundNo.ClientID%>").value); 
            document.getElementById("<%=txtVisaExptdDate.ClientID%>").value = "";
            document.getElementById("<%=txtScdldDate.ClientID%>").value = "";
            
            ClearImageWrkExpClear();
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
        //TabClick(document.getElementById("<%=HiddenFieldRoundNo.ClientID%>").value);
        document.getElementById("<%=txtVisaExptdDate.ClientID%>").value = "";
        document.getElementById("<%=txtScdldDate.ClientID%>").value = "";
        ClearImageWrkExpClear();
                return false;
            }
        }


       
        function VisaAdd() {
            var ret = true;
            
            if (CheckIsRepeat() == true) {
 
            }

            else {
   
                ret = false;
                return ret;
            }

            // replacing < and > tags
           
            document.getElementById("<%=txtVisaExptdDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtScdldDate.ClientID%>").style.borderColor = "";

            var Scdldate = document.getElementById("<%=txtScdldDate.ClientID%>").value;
            var ExpDate = document.getElementById("<%=txtVisaExptdDate.ClientID%>").value;
            
            if (Scdldate == "") {
                
                document.getElementById('divMessageAreaVisa').style.display = "";
                document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtScdldDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtScdldDate.ClientID%>").focus();
                ret = false;
                
            }
            if (Scdldate != "") {
                var datepickerDate = document.getElementById("<%=txtScdldDate.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                if (ExpDate == "") {
                    var datepickerDate = document.getElementById("<%=lblVisaTrgtDate.ClientID%>").innerText;
                }
                else {
                    var datepickerDate = document.getElementById("<%=txtVisaExptdDate.ClientID%>").value;
                }
                var arrDatePickerDate = datepickerDate.split("-");
                var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);


                //if (dateTxIss > dateCompExp) {
                      
                      //document.getElementById('divMessageAreaVisa').style.display = "";
                     // document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaWarning.png";
                     // document.getElementById("<%=lblMessageAreaVisa.ClientID%>//").innerHTML = "Scheduled date should be less than or equal to target date";
                     // document.getElementById("<%=txtScdldDate.ClientID%>").style.borderColor = "Red";
                     // document.getElementById("<%=txtScdldDate.ClientID%>").focus();
                     // ret = false;
               // }
            }



            var RcptdatepickerDate = Scdldate;
            var RarrDatePickerDate = RcptdatepickerDate.split("-");
            var RdateDateCntrlr = new Date(RarrDatePickerDate[2], RarrDatePickerDate[1] - 1, RarrDatePickerDate[0]);


           



            var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
            var arrCurrentDate = CurrentDateDate.split("-");
            var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

            if (document.getElementById("<%=txtVisaExptdDate.ClientID%>").value != "") {
                var datepickerDate = document.getElementById("<%=txtVisaExptdDate.ClientID%>").value;
                var arrDatePickerDate = datepickerDate.split("-");
                var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                if (dateCompExp < dateCurrentDate) {
                    document.getElementById('divMessageAreaVisa').style.display = "";
                    document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = "Expected target date should be greater than or equal to current date";
                    document.getElementById("<%=txtVisaExptdDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtVisaExptdDate.ClientID%>").focus();
                    ret = false;  
                }
            }

               // if (RdateDateCntrlr < dateCurrentDate) {
                  //  document.getElementById('divMessageAreaVisa').style.display = "";
                 //   document.getElementById('imgMessageAreaVisa').src = "/Images/Icons/imgMsgAreaWarning.png";
                   // document.getElementById("<%=lblMessageAreaVisa.ClientID%>").innerHTML = "Scheduled date should be greater than or equal to current date";
                   //   document.getElementById("<%=txtScdldDate.ClientID%>").style.borderColor = "Red";
                //    document.getElementById("<%=txtScdldDate.ClientID%>").focus();
               //     ret = false;
              //  }
        
            if (ret == false) {
                CheckSubmitZero();

            }
            document.getElementById("<%=HiddenFieldDDlStsId.ClientID%>").value = document.getElementById("<%=ddlVisaSts.ClientID%>").value;
          
            return ret;
        }
       
    </script>
                  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
        <asp:HiddenField ID="hiddenMsgType" runat="server" />

     <asp:HiddenField ID="HiddenFieldNoRnd" runat="server" />
     <asp:HiddenField ID="hiddenUserImageSize" runat="server" />
     <asp:HiddenField ID="hiddenUserImage" runat="server" />
     <asp:HiddenField ID="hiddenImageName" runat="server" />  
     <asp:HiddenField ID="HiddenFieldCandId" runat="server" />
     <asp:HiddenField ID="HiddenFieldRoundId" runat="server" />
    <asp:HiddenField ID="HiddenFieldLogUserId" runat="server" />
     <asp:HiddenField ID="HiddenFieldDDlStsId" runat="server" />
     <asp:HiddenField ID="HiddenFieldRoundName" runat="server" />
    <asp:HiddenField ID="HiddenFieldRoundNo" runat="server" />
     <asp:HiddenField ID="HiddenFieldShowDiv" runat="server" />
     <asp:HiddenField ID="HiddenFieldVisaSts" runat="server" />
      <asp:HiddenField ID="HiddenFieldTrgtDate" runat="server" />

     <asp:HiddenField ID="HiddenFieldOnbrdId" runat="server" />
     <asp:HiddenField ID="HiddenFieldQryId" runat="server" />

     <asp:HiddenField ID="HiddenFieldImmgrtnId" runat="server" />
     <asp:HiddenField ID="HiddenFieldImmgrtnDtlId" runat="server" />
     <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
    
    <div id="divMessageArea" style="display: none;width:100%;">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div class="cont_rght">

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: absolute; right: 5%; top: 43.5%; height: 26.5px;">
        </div>

        <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke;float:left;margin-bottom:1%;">
            <div id="divReportCaption" style="width:100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;float:left">
                <asp:Label ID="lblEntry" runat="server">Immigration-Tasks</asp:Label>
            </div>

            <div style="float: left; width: 98%;padding: 10px;margin-top: 2%;border: 1px solid #929292;background-color: #c9c9c9;font-family: Calibri;">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">REF#</h2>
                    <asp:Label ID="lblCandtName"  class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Employee Id</h2>
                    <asp:Label ID="lblLoctn" class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">First Name</h2>
                    <asp:Label ID="lblRefEmp" class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Designation</h2>
                    <asp:Label ID="lblResume" class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Employee Type</h2>
                    <asp:Label ID="lblNation" class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Role</h2>
                    <asp:Label ID="lblVisa" class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
               <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Joining Date</h2>
                    <asp:Label ID="lblJoinDate" class="form1" runat="server" style="word-wrap: break-word;"></asp:Label>
                </div>
            </div>



             <%--Start Tabs --%>
            <div id="divTabs" style="width: 99%;margin-top: 25%;padding: 0px;" runat="server">
            
                  </div>  
            <%--Start:Visa--%>   
            <div id="divVisa" style="border:.5px solid;border-color: #9ba48b;background-color:white;width: 96%; margin-top:1%;padding:2%;"> 
                 <div id="divMessageAreaVisa" style="display:none; width: 84%; margin-left: 6%;margin-top: -1%;">
                 <img id="imgMessageAreaVisa" src="" />
                 <asp:Label ID="lblMessageAreaVisa" runat="server"></asp:Label>
                 </div>          
           
                <br />
                    <div class="eachform" style="float: right; width: 13%;">
             <asp:Label  ID="lblStatus" class="datelbl" runat="server" Text="" style="display:none; padding:3%;word-wrap:break-word;font-family:calibri;font-size:20px;color:#377438;border-style:solid;"></asp:Label>
                 </div>
             <div class="eachform" style="float:left;width:80%;">
             <h2>Target Date</h2>             
             <asp:Label ID="lblVisaTrgtDate" class="datelbl"  runat="server" style="word-wrap: break-word;"></asp:Label>
            </div>
              <div class="eachform" style="float:left;margin-top:1%;width:80%;">
             <h2>Status*</h2>             
             <asp:DropDownList ID="ddlVisaSts"  class="form1" runat="server" Style="height:30px;width:42%;text-align:left;margin-right: 20%;" onchange="IncrmntConfrmCounterVisa();">
             </asp:DropDownList>
            </div>

             <div  id="divVisaClose" runat="server" style="width: 10%;margin-left: 81%;margin-top: 3%;cursor:pointer" onclick="CloseVisa()">
             <img id="imgVisaClose" runat="server" src="/Images/Icons/close guarantee.png" style="margin-left:23%;width:37%;"/>
              <h2 style="margin-top: 1%;font-size:15px;margin-left:21%;">CLOSE</h2>
              </div>


                 <div class="eachform" style="float:left;margin-top:1%;width:80%;">
                <h2>Scheduled Date*</h2>
                
               <div id="divShdlDate" class="input-append date" style="float: right;width: 43%;margin-right: 19%;">

                 
                   
                        <asp:TextBox ID="txtScdldDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height:30px;width:81%;margin-top: 0%;float:left;" onchange="IncrmntConfrmCounterVisa();"></asp:TextBox>

                        <input type="image" runat="server" id="Image1" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

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
                            $noC('#divShdlDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
               

            </div>


             <div class="eachform" style="float:left;margin-top:1%;width:80%;">
                <h2>Expected Target Date</h2>
                
               <div id="divVisaExpDate" class="input-append date" style="float: right;width: 43%;margin-right: 19%;">

                 
                   
                        <asp:TextBox ID="txtVisaExptdDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height:30px;width:81%;margin-top: 0%;float:left;" onchange="IncrmntConfrmCounterVisa();"></asp:TextBox>

                        <input type="image" runat="server" id="Image11" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

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
                            $noC('#divVisaExpDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
               

            </div>
            

                 <div class="eachform" style="float:left;width:80%;margin-top:1%;" >          
                        <h2 >File Uploader</h2>

                           <div style="margin-right:3%;float: right;width: 59%;">
                <label for="cphMain_FileUploadWrk" class="custom-file-upload" style="margin-left: 0%;" tabindex="0">
                    <img src="/Images/Icons/cloud_upload.jpg" />Upload File</label>
                <%--<input id="file" name = "file" type="file" onchange="ClearDivDisplayImage()" accept="image/png, image/gif, image/jpeg" />--%>

                <asp:FileUpload ID="FileUploadWrk" class="fileUpload" runat="server" Style="height: 30px; display: none;" onchange="ClearDivDisplayImageWrkExp()" Accept="image/png, image/gif, image/jpeg" />


                <div id="divWrkImageEdit" runat="server" style=" width: 100%;margin-right: 0.3%;float: right; height: 20px; margin-top: 0%;">
                    

                    <div class="imgWrap" id="div10" runat="server">
                        <img id="Img1" src="/Images/Icons/clear-image-green.png" class="tooltip" style="position: relative;float: right;opacity: 1;z-index: 10;margin-top:0%;margin-right:45%;" title="Remove Selected Photo" alt="Clear" onclick="ClearImageWrkExp()"  style="cursor: pointer; float: right;" />
                        <%--<p id="RemovePhoto" class="imgDescription" style="color: white">Remove Selected Photo</p>--%>
                    </div>
                    <div id="divWrkImgdis" runat="server">
                    </div>
                </div>
                <asp:Label ID="LabelWrkAttmnt" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
            
                       </div>

                  </div>


              <div  id="divVisaFinish" runat="server" style="width: 10%;margin-left: 81%;margin-top: 4%;cursor:pointer" onclick="OpenCancelView()">
             <img id="imgVisaFinish" runat="server" src="/Images/new_Icons32/Quotation.png" style="margin-left:23%;width:37%;"/>
              <h2 style="margin-top: -65%;font-size:15px;margin-left:18%;">FINISH</h2>
              </div>
           
                 <div class="eachform" style="margin-top:2%;">
                <div class="subform" style="width:448px;margin-right:19%;">
                    <div class="form-group" >                     
                         <asp:Button ID="btnAddVisa" runat="server" class="save" Text="Save" OnClientClick="return VisaAdd();" OnClick="btnAddVisa_Click" />
                         <asp:Button ID="btnClearVisa" runat="server" style="margin-left: 11px;" class="cancel" Text="Clear" OnClientClick="return AlertClearVisa();"/>
                         <asp:Button ID="btnCancelVisa" runat="server" class="cancel" style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCancel();"/>
                         </div>
                </div>

            </div>
                              
           
            
           
        </div>
          
            <%--End:Visa--%> 

          

       
    </div>


          <%--------------------------------For Finish popup window--------------------------%>

         <div id="divAlocate" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="return CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 id="headPopup" runat="server" style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;"></h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorMV" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorMV" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>
                       
                <div  class="eachform" style="width: 65.3%; float: left; padding: 5px; border: 1px solid #c3c3c3;">
                    <h2>Status :</h2>
                    <div style="float: right; margin-right: -6%; width: 61%;">
                        <asp:RadioButton ID="radioAttend" onkeypress="return isTag(event);" Text="Attended" runat="server" Checked="true" GroupName="RadioSkCer" Style="float: left; font-family: calibri" OnChange="RadioChange();" />
                        <asp:RadioButton ID="radioNotAttend" onkeypress="return isTag(event);" Text="Not Attended" runat="server" GroupName="RadioSkCer" Style="float: left; font-family: calibri; margin-left: 6%;" OnChange="RadioChange();" />
                    </div>
                </div>
                <div class="eachform" style="float:left;margin-top:1%;width:80%;">
                <h2>Reschedule</h2>
                
               <div id="divRescdlDate" class="input-append date" style="float: right;width: 43%;margin-right: 19%;">

                 
                   
                        <asp:TextBox ID="txtReshdlDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height:30px;width:81%;margin-top: 0%;float:left;" onkeypress="return isTag(event);" onchange="IncrmntConfrmCounterVisa();"></asp:TextBox>

                        <input type="image" runat="server" id="Image2" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

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
                            $noC('#divRescdlDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
               

            </div>


           
                       
                         <asp:Button ID="btnOkMV" class="save" runat="server" Text="Confirm"  style="width: 90px; float:left;margin-left:34%;margin-top: 1%;" OnClientClick="return ValidateFinish();" OnClick="btnConfirm_Click" />
                        <asp:Button ID="btnCnclMV" class="save" style="width: 90px; float:right;margin-right:32%;margin-top: 1%;" onclientclick="return CloseCancelView();" runat="server" Text="Cancel" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 15%;">
                    </div>


                </div>
            </div>   
         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>
        </div>
    <style>
           input[type="radio"] {
            display: table-cell;
        }
         .open > .dropdown-menu {
            display: none;
        }
    </style>
</asp:Content>
