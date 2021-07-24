<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master"  CodeFile="hcm_Experiance_Certificate.aspx.cs" Inherits="HCM_HCM_Master_hcm_Exit_Management_hcm_Experiance_Certificate_hcm_Experiance_Certificate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <style>
        
         #divErrorRsnAWMS {
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
     <script src="/JavaScript/jquery-1.8.3.min.js"></script>
        
   
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
              
              //  document.getElementById("<%=txtReason.ClientID%>").focus();

              document.getElementById("divprint").style.display = "none";

              if (document.getElementById("<%=HiddenPrint.ClientID%>").value == "true") {
                  document.getElementById("divprint").style.display = "";
              }
            
          });


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

      //function ConfirmMessage() {

      //    if (confirm("Are you sure you want to leave this page?")) {
      //        window.location.href = "hcm_Experiance_Certificate_List.apsx";
      //        return true;
      //    }
      //    else {
      //        return false;
      //    }
      //}

      function PrintExperinceCert() {
          var EmpId = document.getElementById("<%=ddlEmployee.ClientID%>").value;
          //window.location.href = "../../../../CustomFiles/messagepdf/EXPERIENCE CERTIFICATE_" + EmpId + ".pdf";
          window.open("../../../../CustomFiles/messagepdf/EXPERIENCE CERTIFICATE_" + EmpId + ".pdf");
      }


      function AlertClearAll() {
        
          if (confirmbox > 0) {
              if (confirm("Are you sure you want to cancel this page?")) {
                  window.location.href = "hcm_Experiance_Certificate_List.aspx";
                  return true;
              }
              else {
                  return false;
              }
          }
          else {
             
              window.location.href = "hcm_Experiance_Certificate_List.aspx";
              return true;
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
      function DisableEnter(evt) {
          //  var b = new Date(); alert(b);

          evt = (evt) ? evt : window.event;
          var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
          var charCode = (evt.which) ? evt.which : evt.keyCode;
          var ret = true;
          if (charCode == 60 || charCode == 62) {
              ret = false;
          }
          return ret;
      }

      //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
      function textCounter(field, maxlimit) {
          if (field.value.length > maxlimit) {
              field.value = field.value.substring(0, maxlimit);
          } else {

          }

      }
      function showdivUserform() {

          document.getElementById("divUserform").style.display = "block";
          document.getElementById("divButtons").style.display = "block";
          return false;
      }

      function SuccessCertfct(EMPID) {
          document.getElementById('divMessageArea').style.display = "";
          document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
          document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Certificate generated successfully.";
          ReadEmpDetailsAFTRsAVE(EMPID);
      }
      function SuccessUpdtCertfct(EMPID) {
          document.getElementById('divMessageArea').style.display = "";
          document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
          document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Certificate generated updated successfully.";
          ReadEmpDetailsAFTRsAVE(EMPID);
      }
      function SuccessUpd() {
          document.getElementById('divMessageArea').style.display = "";
          document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
          document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Resignation details updated successfully.";
      }
      function SuccessCnfrm() {
          document.getElementById('divMessageArea').style.display = "";
          document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
          document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Resignation details confirmed successfully.";
      }
      function SuccessCancel() {
          document.getElementById('divMessageArea').style.display = "";
          document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
          document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Resignation details cancelled successfully.";
      }
 

      function ResignValidate() {


          var ret = true;
          if (CheckIsRepeat() == true) {

          }
          else {
              ret = false;
              return ret;
          }
          // replacing < and > tags
      

             var CrdExpWithoutReplace = document.getElementById("<%=txtReason.ClientID%>").value.trim();
          var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
          var replaceCode2 = replaceCode1.replace(/>/g, "");
          document.getElementById("<%=txtReason.ClientID%>").value = replaceCode2;

         
          var Reason = document.getElementById("<%=txtReason.ClientID%>").value;

          var presenrdate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
          var arrpresenrdate = presenrdate.split("-");
          var datepresenrdate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);




          if (Reason == "") {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            document.getElementById("<%=txtReason.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtReason.ClientID%>").focus();
                            ret = false;
                        }

   


                        if (ret == false) {

                            CheckSubmitZero();

                        }

                        return ret;
      }

      function ConfirmMessage() {
          if (confirmbox > 0 > 0) {
              if (confirm("Are you sure you want to leave this page?")) {
                  window.location.href = "hcm_Experiance_Certificate_List.aspx";
              }
              else {
                  return false;
              }
          }
          else {
              window.location.href = "hcm_Experiance_Certificate_List.aspx";

          }
      }
      function ReadEmpDetails()
      {
          IncrmntConfrmCounter();
          var EmpId = document.getElementById("<%=ddlEmployee.ClientID%>").value;
         
          if (EmpId != "--SELECT EMPLOYEE--") {
              var $NonCon = jQuery.noConflict();
              $NonCon.ajax({
                  type: "POST",
                  async: false,
                  contentType: "application/json; charset=utf-8",
                  url: "hcm_Experiance_Certificate.aspx/ReadCandidateData",
                  data: '{intCandId: "' + EmpId + '"}',
                  dataType: "json",
                  success: function (data) {
                      var addrss = data.d.empdatails[4];
                      if (data.d.empdatails[6] != "" && data.d.empdatails[6] != null)
                      {
                          addrss = addrss + "," + data.d.empdatails[6];
                      }
                      if (data.d.empdatails[7] != "" && data.d.empdatails[7] != null) {
                          addrss = addrss + "," + data.d.empdatails[7];
                      }
                      if (data.d.empdatails[8] != "" && data.d.empdatails[8] != null) {
                          addrss = addrss + "," + data.d.empdatails[8];
                      }
                      //evm-0023
                      document.getElementById('divConduct').style.display = "";
                      document.getElementById('divAttnPerfc').style.display = "";
                      document.getElementById('divTradPerfc').style.display = "";

                      if (data.d.empdatails[12] == 0) {
                          document.getElementById('divConduct').style.display = "none";
                          document.getElementById('divAttnPerfc').style.display = "none";
                          document.getElementById('divTradPerfc').style.display = "none";
                      }


                      document.getElementById("<%=lblEmpname.ClientID%>").innerText = data.d.empdatails[0];
                      document.getElementById("<%=lblDesg.ClientID%>").innerText = data.d.empdatails[1];
                      document.getElementById("<%=Divsn.ClientID%>").innerText = data.d.empdivision;
                      document.getElementById("<%=lblDeprtmnt.ClientID%>").innerText = data.d.empdatails[2];
                      document.getElementById("<%=lblPaygrd.ClientID%>").innerText = data.d.empdatails[3];
                      document.getElementById("<%=lblSonof.ClientID%>").innerText = data.d.empDependntName;
                      document.getElementById("<%=addrs.ClientID%>").innerText = addrss;
                      document.getElementById("<%=TextBox1.ClientID%>").value = data.d.empJoinDate;
                      document.getElementById("<%=HiddenFrmDate.ClientID%>").value = data.d.empJoinDate;
                      document.getElementById("<%=HiddenToDate.ClientID%>").value = data.d.empLevDate;

                      //EVM-0023
                      document.getElementById("<%=txtConduct.ClientID%>").value = data.d.empdatails[9];
                      document.getElementById("<%=txtAttendancePerfo.ClientID%>").value = data.d.empdatails[10];
                      document.getElementById("<%=txtTradePerfo.ClientID%>").value = data.d.empdatails[11];
                      
                      
                      document.getElementById("<%=TextBox2.ClientID%>").value = data.d.empLevDate;
                      
                      
                  }
              });
          }
      }
      function ReadEmpDetailsAFTRsAVE(EMPID) {
      
         
              var $NonCon = jQuery.noConflict();
              $NonCon.ajax({
                  type: "POST",
                  async: false,
                  contentType: "application/json; charset=utf-8",
                  url: "hcm_Experiance_Certificate.aspx/ReadCandidateData",
                  data: '{intCandId: "' + EMPID + '"}',
                  dataType: "json",
                  success: function (data) {
                      
                      var addrss = data.d.empdatails[4];
                      if (data.d.empdatails[6] != "" && data.d.empdatails[6] != null) {
                          addrss = addrss + "," + data.d.empdatails[6];
                      }
                      if (data.d.empdatails[7] != "" && data.d.empdatails[7] != null) {
                          addrss = addrss + "," + data.d.empdatails[7];
                      }
                      if (data.d.empdatails[8] != "" && data.d.empdatails[8] != null) {
                          addrss = addrss + "," + data.d.empdatails[8];
                      }


                      //EVM-0023
                      document.getElementById('divConduct').style.display = "";
                      document.getElementById('divAttnPerfc').style.display = "";
                      document.getElementById('divTradPerfc').style.display = "";

                      if (data.d.empdatails[12] == 0) {                        
                          document.getElementById('divConduct').style.display = "none";
                          document.getElementById('divAttnPerfc').style.display = "none";
                          document.getElementById('divTradPerfc').style.display = "none";
                      }


                      document.getElementById("<%=lblEmpname.ClientID%>").innerText = data.d.empdatails[0];
                      document.getElementById("<%=lblDesg.ClientID%>").innerText = data.d.empdatails[1];
                      document.getElementById("<%=Divsn.ClientID%>").innerText = data.d.empdivision;
                      document.getElementById("<%=lblDeprtmnt.ClientID%>").innerText = data.d.empdatails[2];
                      document.getElementById("<%=lblPaygrd.ClientID%>").innerText = data.d.empdatails[3];
                      document.getElementById("<%=lblSonof.ClientID%>").innerText = data.d.empDependntName;
                      document.getElementById("<%=addrs.ClientID%>").innerText = addrss;
                      
                      document.getElementById("<%=TextBox1.ClientID%>").value = data.d.empJoinDate;
                      document.getElementById("<%=HiddenFrmDate.ClientID%>").value = data.d.empJoinDate;
                      document.getElementById("<%=HiddenToDate.ClientID%>").value = data.d.empLevDate;


                      document.getElementById("<%=TextBox2.ClientID%>").value = data.d.empLevDate;
                      document.getElementById("<%=txtReason.ClientID%>").value = data.d.empdatails[5];
                      //EVM-0023
                      document.getElementById("<%=txtConduct.ClientID%>").value = data.d.empdatails[9];
                      document.getElementById("<%=txtAttendancePerfo.ClientID%>").value = data.d.empdatails[10];
                      document.getElementById("<%=txtTradePerfo.ClientID%>").value = data.d.empdatails[11];

                     // document.getElementById("<%=ddlEmployee.ClientID%>").value = EMPID;
                      document.getElementById("<%=ddlEmployee.ClientID%>").disabled = true;
                      document.getElementById("<%=btnUpdate.ClientID%>").style.display = "block";
                      

                  }
              });
          document.getElementById("<%=ddlEmployee.ClientID%>").value = EMPID;
          document.getElementById("<%=Hiddenedit.ClientID%>").value = EMPID;
          
      }
       </script>

  <%--FOR DATE TIME PICKER--%>
<script type="text/javascript" src="../../../../JavaScript/Date/JavaScriptDate1_8_3.js"></script>                      
<script type="text/javascript" src="../../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
<script type="text/javascript" src="../../../../JavaScript/Date/bootstrap-datepicker.js"></script>
<script type="text/javascript"src="../../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
<link href="../../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
<link href="../../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />

     <style>

           .textDate:focus {
            border: 1px solid #bbf2cf;
            box-shadow: 0px 0px 4px 2.5px #bbf2cf;
        }
        .textDate {
            border: 1px solid #cfcccc;
        }
            .open > .dropdown-menu {
    display: none;
             }

            .bootstrap-datetimepicker-widget {

    z-index: 100;
}
              .eachform h2 {
                margin: 6px 0 6px;
            }
    </style>
 

      
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
        
     <asp:HiddenField ID="HiddenFieldCancelUsrRole" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
     <asp:HiddenField ID="HiddenFieldEmpId" runat="server" />
     <asp:HiddenField ID="HiddenFieldResgntnSts" runat="server" />
     <asp:HiddenField ID="HiddenFieldResgntnId" runat="server" />
       <asp:HiddenField ID="HiddenFrmDate" runat="server" />
       <asp:HiddenField ID="HiddenToDate" runat="server" />
         <asp:HiddenField ID="Hiddenedit" runat="server" />
    <asp:HiddenField ID="HiddenPrint" runat="server" />

    <%--target="_blank" href="" --%>
    <div id="divprint" style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 5%; font-family: Calibri;" class="print">
     <a id="print_cap" data-title="Experience Certificate" onclick="PrintExperinceCert()"  style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -22px; float: right;">Print the Certificate</span></a>                                  
   </div>

    <div id="divMessageArea" style="display: none;width:99%;">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div id="div5" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 0%; top: 40%; height: 26.5px;">


        </div>
    <div class="cont_rght">

      

        <div style="width: 98.5%; border: 1px solid #8e8f8e; padding: 10px; background-color: white;float:left">
            <div id="divReportCaption" style="width:100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;float:left">
                <asp:Label ID="lblEntry" runat="server">Experience Certificate Generation</asp:Label>
            </div>


                      
                        <div class="eachform" style="width: 59%;margin-top:0.5%;margin-left:1%;float: left;margin-top:3%">

                <h2 style="margin-top:1%;">Employee*</h2>

                <asp:DropDownList ID="ddlEmployee"   class="form1" onchange="ReadEmpDetails()" runat="server" Style="height:28px;width:160px;height:31px;width:52%;float:left; margin-left: 25%;">
             
      
                </asp:DropDownList>


            </div> 


  <div style="float: left; width: 97.5%;padding: 10px;margin-top: 2%;border: 1px solid #929292;background-color: rgb(227, 227, 227);">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Employee</h2>
                    <asp:Label ID="lblEmpname" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Designation</h2>
                    <asp:Label ID="lblDesg" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Department</h2>
                    <asp:Label ID="lblDeprtmnt" class="form5"  runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Pay Grade</h2>
                    <asp:Label ID="lblPaygrd" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
               <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Son of</h2>
                    <asp:Label ID="lblSonof" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
           <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;width: 24%;">Permanent Residential Address</h2>
                    <asp:Label ID="addrs" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;word-wrap: break-word;width: 70%;"></asp:Label>
                </div>
             <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Division</h2>
                    <asp:Label ID="Divsn" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                <%-- <div class="eachform" style="width: 47%; float: right;">                   
                <asp:Button ID="btnResign" runat="server" class="cancel" Text="Resign" OnClientClick="return showdivUserform();"/>
                </div>--%>
    </div>
     <div id="divUserform" style="float: left; width: 97.5%;padding: 10px;margin-top: 2%;border: 1px solid #929292;">

                 <div class="eachform" style="width: 47%; float: left;">
                    <asp:Label ID="lblResgnMsg" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
               
                <div class="eachform" style="width: 100%; float: left;">
                    <h2>Remark*</h2>
                     <asp:TextBox ID="txtReason" class="form1" runat="server" MaxLength="50" TextMode="MultiLine" Style="width: 30%;  margin-left: 16.6%; height: 80px; resize:none;font-family: calibri;float:left;" onblur="textCounter(cphMain_txtReason,450)" onkeydown="textCounter(cphMain_txtReason,450)" onkeyup="textCounter(cphMain_txtReason,450)"></asp:TextBox>
                </div>
         
         <%--//EVM-0023--%>
                 <div id="divConduct" class="eachform" style="width: 100%; float: left;">
                    <h2>Conduct</h2>
                     <asp:TextBox ID="txtConduct" class="form1" runat="server" MaxLength="50"  Style="width: 30%;  margin-left: 16.9%; height: 30px; resize:none;font-family: calibri;float:left;" onblur="textCounter(cphMain_txtReason,450)" onkeydown="textCounter(cphMain_txtReason,450)" onkeyup="textCounter(cphMain_txtReason,450)"></asp:TextBox>
                </div>

                <div id="divAttnPerfc" class="eachform" style="width: 100%; float: left;">
                    <h2>Attendance performance</h2>
                     <asp:TextBox ID="txtAttendancePerfo" class="form1" runat="server" MaxLength="50"  Style="width: 30%;  margin-left: 4.8%; height: 30px; resize:none;font-family: calibri;float:left;" onblur="textCounter(cphMain_txtReason,450)" onkeydown="textCounter(cphMain_txtReason,450)" onkeyup="textCounter(cphMain_txtReason,450)"></asp:TextBox>
                </div>

                <div id="divTradPerfc" class="eachform" style="width: 100%; float: left;">
                    <h2>Trade performance</h2>
                     <asp:TextBox ID="txtTradePerfo" class="form1" runat="server" MaxLength="50"  Style="width: 30%;  margin-left: 9.2%; height: 30px; resize:none;font-family: calibri;float:left;" onblur="textCounter(cphMain_txtReason,450)" onkeydown="textCounter(cphMain_txtReason,450)" onkeyup="textCounter(cphMain_txtReason,450)"></asp:TextBox>
                </div>




               
                     <div class="eachform" style="width: 100%; float: left;">
                    <h2>Joining Date</h2>
                     <asp:TextBox ID="TextBox1" class="form1" runat="server" MaxLength="20"  Style="width: 30%;  margin-left: 14.3%; height: 30px; resize:none;font-family: calibri;float:left;"></asp:TextBox>
                </div>
          <div class="eachform" style="width: 100%; float: left;">
                    <h2>Leaving Date</h2>
                     <asp:TextBox ID="TextBox2" class="form1" runat="server" MaxLength="20"  Style="width: 30%;  margin-left: 13.9%; height: 30px; resize:none;font-family: calibri;float:left;" ></asp:TextBox>
                </div>  
 
  </div>        
        
            
            
          <div id="divButtons" class="eachform" style="">
                <div class="subform" style="width: 62%; margin-top:5%">

                   <%--   <asp:Button ID="btnConfirm" runat="server" class="save" Text="Confirm" OnClick="btnConfirm_Click" OnClientClick="return ResignValidate();"/>
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return ResignValidate();"/>--%>
                  <%--    <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return ResignValidate();"/>--%>
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Generate Certificate"  OnClientClick="return ResignValidate();" OnClick="btnAdd_Click"/>
                      <asp:Button ID="btnUpdate" runat="server" Style="display:none" class="save" Text="Generate Certificate" OnClick="btnUpdate_Click" OnClientClick="return ResignValidate();"/>
<%--                     <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return ResignValidate();"/>--%>
                  <%--   <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" OnClientClick="return CancelAlert();"/>--%>
                 <input type="button" id="btnClear" runat="server" style="margin-left: 13px;" onclick="return AlertClearAll();"  class="cancel" value="Cancel"/>
                </div>
            </div>
      
                </div>
    
        </div>

    <div id="divPrintReport" runat="server" style="display: none">
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>

  <style>
         .form5 {
    width: 70%;
    padding: 0px 8px;  
    float: right;
    color: #000;
    font-size: 13px;
    margin-top:2%;
}

  </style>
 

</asp:Content>




