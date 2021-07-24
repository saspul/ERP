<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_Emp_Personal_Info_List.aspx.cs" Inherits="Master_gen_Emply_Personal_Informn_gen_Emp_Personal_Info_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

      <style>

          .table > thead > tr > th {
    vertical-align: bottom;
    background:#eee;
   color: #5d7199;
   font-size:15px;
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
             padding: 4% 4% 7% 4%;
         }

         .modal-footerCancelView {
             padding: 2% 1%;
           background-color: #91a172;
             color: white;
         }
         .main_table > tbody > tr:nth-child(2n+1) > td, .main_table > tbody > tr:nth-child(2n+1) > th {
    height: 30px;
    background: #E9E9E9;
    font-size: 14px;
    color: #0d0d0e;
}
 .smart-form {
    margin: 0;
    outline: 0;
    color: #070708;
    position: relative;
}
 .ui-dialog .ui-dialog-title {
  text-align: center;
  width: 95%;
}
     </style>
     <style>
        
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

        .select2-results__option[aria-selected] {
            cursor: pointer;
            font-size: small;
            font-family: calibri;
        }
         .select2-selection__choice {
             color:black !important;
         }
    </style>
       <script src="../../JavaScript/jquery-1.8.3.min.js"></script>
     <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
              $noCon(".select2").select2(
                  {
                      //allowClear: true
                  });
              LoadEmployeeList();
              document.getElementById("freezelayer").style.display = "none";
              document.getElementById('MymodalCancelView').style.display = "none";
              var CancelPrimaryId = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
              if (CancelPrimaryId != "") {
                  OpenCancelView();
              }
          });
          </script>
    
    <script type="text/javascript">
        var $Mo = jQuery.noConflict();
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        function OpenCancelView() {



            document.getElementById("MymodalCancelView").style.display = "block";
            document.getElementById("freezelayer").style.display = "";
            document.getElementById("<%=txtCnclReason.ClientID%>").focus();

            return false;

        }
        function CloseCancelView() {
            if (confirm("Do you want to close  without completing Cancellation Process?")) {
                document.getElementById('divMessageArea').style.display = "none";
                document.getElementById('imgMessageArea').src = "";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                document.getElementById("MymodalCancelView").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
                document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = "";
            }
        }



    </script>

         <script>

             //0039
             function SuccessNewID() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Employee rejoined sucessfully with new code.";
                 return false;
             }  

             function SuccessOldID() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Employee rejoined sucessfully with existing user code.";
                 return false;
             }
             //end
             function SuccessConfirmation() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Employee Details Inserted Successfully.";

             }
             function SuccessUpdation() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Employee Details Updated Successfully.";

             }
             function SuccessCancelation() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Employee Cancelled Successfully.";

             }
             function MailsendFail() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Employee Details Inserted Successfully.The Mail Sending To Employee Failed.";

             }
             function MailsendFailReviewMailStng() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Employee Details Inserted Successfully. Review Your Mail Settings For Sending Mail.";

             }

             function getdetails(href) {
                 window.location = href;
                 return false;
             }
             function CancelAlert(href) {

                 if (confirm("Do you want to cancel this Entry?")) {
                     window.location = href;
                     return false;
                 }
                 else {
                     return false;
                 }
             }

             //  var $NoCn = jQuery.noConflict();
             function CancelNotPossible() {
                 alert("Sorry, Cancellation Denied. This Entry is Already Selected Somewhere Or It is a Confirmed Entry!");
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

             //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
             function textCounter(field, maxlimit) {
                 if (field.value.length > maxlimit) {
                     field.value = field.value.substring(0, maxlimit);
                 } else {

                 }
             }
             // for not allowing enter
             function DisableEnter(evt) {
                 evt = (evt) ? evt : window.event;
                 var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                 if (keyCodes == 13) {
                     return false;
                 }
             }
          </script>


    <%--  for giving pagination to the html table--%>
   <%-- <script src="../../JavaScript/JavaScriptPagination1.js"></script>
    <script src="../../JavaScript/JavaScriptPagination2.js"></script>--%>

   <%-- <link rel="Stylesheet" href="../../css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": false

            });
        });


    </script>--%>

    <style>
        #cphMain_divReport {
            float: left;
            width: 93.5%;
        }

        #TableRprtRow .tdT {
            line-height: 100%;
        }


        .cont_rght {
            width: 98%;
        }
    </style>
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
                        document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Cancel reason should be minimum 10 characters";
                        var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                        return false;
                    }
                }
            }

    </script>
 
        <script>
            
            <!---0039>
          
            function RejoinAlert(id)
            {
                //alert(id);
                var userIdType = document.getElementById("<%=hiddenUserIdType.ClientID%>").value;
                //alert(userIdType);
                if (confirm("Do you want to rejoin this employee?"))
                {
                    
                   
                    //window.location = id;
                    //window.location = "hcm_Leave_Settlement_List.aspx";
                    autoGenerate(id, userIdType);
                  
                  
                    return false;
                }
                else
                {
                    return false;
                }
            }

            function autoGenerate(id, userIdType)
            {
                              
                var orgID = '<%= Session["ORGID"] %>';
                var corptID = '<%= Session["CORPOFFICEID"] %>';
                var IndId = id;
                var IndTypeId = userIdType;
                //alert(IndId);
                //alert(IndTypeId);

                if (corptID != "" && corptID != null && orgID != "" && orgID != null && IndId != "" && IndId != null)
                {

                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "gen_Emp_Personal_Info_List.aspx/IdGenerate_Auto",
                        data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",IndId: "' + IndId + '",IndTypeId: "' + IndTypeId + '"}',
                        dataType: "json",
                        success: function (response) {
                            

                            if (IndTypeId == 1) {
                                window.location.href = "gen_Emp_Personal_Info_List.aspx?InsUpd=true";
                                return false;
                            }
                            else if (IndTypeId == 0) {
                                window.location.href = "gen_Emp_Personal_Info_List.aspx?InsUpd=false";
                                return false;
                            }
                        },
                        failure: function (response) {
                            alert("Fail")

                        }
                       
                     });

                 }
             
                 return false;
            }
            //end

            
            function preview(Id)
            {               
                var Details = PageMethods.preview1(Id, function (response)
                    
                {

                    document.getElementById("<%=empdetails.ClientID%>").innerHTML = response;

                });
                $nooC('#dialog_simple').dialog('open');
                $nooC('.ui-dialog-titlebar-close').attr('title', 'Close');
               // document.getElementById("txtefctvedate").value = "";
                return false;
            }
            function InsertToSearchField()
            {
    
                LoadEmployeeList();
                $('.SearchRow input[type="text"]').val('');
                return false;


                var DropdownStatus = document.getElementById("<%=ddlStatus.ClientID%>");
               
                var SelectedValueStatus = DropdownStatus.value;
                var ShwCancel = 0;
                if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked) {
                    ShwCancel = 1;
                }
                else {
                    ShwCancel = 0;
                }

                document.getElementById("<%=hiddenSearchField.ClientID%>").value = SelectedValueStatus + '_' + ShwCancel;
                
                return true;
            }
           </script>

   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <br />

       <asp:HiddenField ID="HiddenFieldBu" runat="server" />
      <asp:HiddenField ID="HiddenFieldDept" runat="server" />
       <asp:HiddenField ID="HiddenFieldExpEmpType" runat="server" />
       <asp:HiddenField ID="HiddenFieldExpSts" runat="server" />

   
     <asp:HiddenField ID="hiddenUserIdType" runat="server" />

    <asp:HiddenField ID="hiddenDesgID" runat="server" />
    <asp:HiddenField ID="hiddenLmtdUser" runat="server" />
    <asp:HiddenField ID="hiddenStatus" runat="server" />
    <asp:HiddenField ID="hiddenCnclSts" runat="server" />
    <asp:HiddenField ID="hiddenfromdate" runat="server" />
    <asp:HiddenField ID="hiddentodate" runat="server" />



      <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
       <asp:HiddenField ID="hiddenSearchField" runat="server" />
     <asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />

       <asp:HiddenField ID="HiddenFieldCorpId" runat="server" />

     <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

            <div id="divMessageArea" style="display: none">
                 <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div class="cont_rght" >
       

        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <img src="../../Images/BigIcons/user regn.png" style="vertical-align: middle;" /> Employee Registration
        </div>
           <%--0006 start--%>
        <div style="width:98%;border: 1px solid #065757;margin-top: 1%;background:#f4f6f0;margin:auto;float:left;margin-bottom:20px;margin-left: 2px;">

        <div class="eachform" style="width: 34%;margin-top: 2%;margin-left:1%;">

                <h2 style=" margin-left:2%;width: 35%;">Status*</h2>

                <asp:DropDownList ID="ddlStatus" Height="30px"   Width="160px" class="form1" runat="server" Style="float:left;margin-left: 10%;margin-bottom:2%;cursor: pointer;">
                    <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Inactive" Value="2"></asp:ListItem>
                     <asp:ListItem Text="On Leave" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Resign" Value="4"></asp:ListItem>                    
                    <asp:ListItem Text="Termination" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Retirement" Value="6"></asp:ListItem>
                    <asp:ListItem Text="Abscond" Value="7"></asp:ListItem>
                    <asp:ListItem Text="Death" Value="8"></asp:ListItem>
                    <asp:ListItem Text="Resume" Value="9"></asp:ListItem>
                    <asp:ListItem Text="Under Police Custody" Value="10"></asp:ListItem>
                    <asp:ListItem Text="Other" Value="11"></asp:ListItem>

                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                </asp:DropDownList>


            </div>
            <div class="eachform" style="width:25%; margin-bottom: 1.2%;">               
                <div class="subform" style="width:100%;">


                    <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" Checked="false" class="form2" />
                    <h3 style="margin-top:1%;">Show Deleted Entries</h3>
                  </div>
               </div>

             <%--0039--%>
    
          <div class="clearfix"></div>

            <div class="eachform" style="width: 35%; float: left;">

                                            <section style="width: 95%; margin-left: 2%;">
                                                <label class="lblh2"  style="margin-left: 3%;float: left;font-size: 16px; font-weight: normal; color: rgb(83, 101, 51); width: 34%; font-family: Calibri">Last Resumed Date</label>
                                             
                                                   <%-- <label class="input" style="float: left;width: 60%;">
           
                                                          <input id="#cphMain_txtFromDateSrch'" class="form1"  name="txtDateFrom"  type="text" onkeypress="return DisableEnter(event)"    data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" onchange="show()" />
                                                                 
                                                    </label>--%>

                                                 <div id="div1" class="input-append date" style="float:right;margin-right:8%;width: 42%;">

                 
                   
                                                  <asp:TextBox ID="txtFromDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="height:22px;width:88.6%;margin-top: 0%;float:left;margin-left: -2.3%;"></asp:TextBox>

                                                  <input type="image" runat="server" id="Image1" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:-0.2%;" />
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
                                                              $noC('#div1').datetimepicker({
                                                                  format: 'dd-MM-yyyy',
                                                                 language: 'en',
                                                                 pickTime: false,
                                                                  //endDate: new Date(),
                                                                  });

                                                                 </script>
                                                           </div>
                                            </section>
             </div>

            <div class="eachform" style="width: 35%; float: left;">

                                            <section style="width: 95%; margin-left:2%;">
                                                <label class="lblh2"  style="float: left;font-size: 16px; font-weight: normal; color: rgb(83, 101, 51); width: 38%; font-family: Calibri">EOS Settlement Date</label>
                                             
                   <%--                                 <label class="input" style="float: left;width: 66%;">                                                           
            
                                                          <input id="Text1"  name="txtDateFrom"  type="text" onkeypress="return DisableEnter(event)"   class="form1"  data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" onchange="show()" />
                                                                 
                                                     </label>--%>

                                                  
                                             <div id="div2" class="input-append date" style="float:right;margin-right:4%;width: 42%;">

                                                <asp:TextBox ID="txtTodate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="height:22px;width:88.6%;margin-top: 0%;float:left;margin-left: -2.3%;"></asp:TextBox>

                                                  <input type="image" runat="server" id="Image2" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:-0.2%;" />
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
                                            $noC('#div2').datetimepicker({
                                                 format: 'dd-MM-yyyy',
                                               language: 'en',
                                                    pickTime: false,
                                                      // startDate: new Date(),
                                                     });

                                                    </script>
                       
                                                    </div>
          
                                            </section>
              </div>

            <%--end--%>
                <div class="eachform" style="width:14%;margin:auto;float:left;">
                             <asp:Button ID="btnSearch"  style="cursor:pointer;margin-top: -0.4%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClick="btnSearch_Click" OnClientClick="return InsertToSearchField();"  />
                     </div>


      <div style="width:14%;margin:auto;float:left;">
             <a id="A2"  data-title="Item Listing"  style="float: right; margin-top:1.5%;color:rgb(83, 101, 51);font-family:Calibri;width: 100%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export employee details" style="max-width: 16%;margin-left:36%;margin-top: 5%;" ><span style="margin-top: 1%;float: right;margin-right: 13%;">Export employee details</span> </a></div> 

        


            </div>

        <%--stop 0006--%>
        <br />

       <div onclick="location.href='gen_Emply_Personal_Informn.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px;right:1%;display:block">


        </div>
      <%--  <br />
        <br />--%>

       
          <div id="diEmployeeList" class="widget-body no-padding" style="margin-top: 0.5%;width: 98%;margin-left:0.2%;">
            <table id="datatable_fixed_column" class="table table-striped table-bordered" width="100%" style="font-family: Calibri;">
                <thead>
                    <tr class="SearchRow" >
                         <th class="hasinput" style="width: 15%">
                            <input  type="text" class="form-control" placeholder="EMPLOYEE ID" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 23%">
                            <input  type="text" class="form-control" placeholder="EMPLOYEE" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 22%">
                            <input type="text" class="form-control" placeholder="DESIGNATION" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 20%">
                            <input type="text" class="form-control" placeholder="DEPARTMENT" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 15%">
                            <input type="text" class="form-control" placeholder="STATUS" onkeydown="return DisableEnter(event)" style="text-align:center;" /></th>
                         <th class="hasinput" style="width: 5%"></th>
                         <th class="hasinput" style="width: 5%"></th>
                         <th class="hasinput" style="width: 5%"></th>
                        

                    </tr>
                    <tr>
                        <th data-class="expand">Employee ID</th>
                        <th data-class="expand">Employee</th>
                        <th data-class="expand">Designation</th>
                        <th data-class="expand">Department</th>
                        <th data-class="expand">Status</th>
                        <th data-class="expand">Edit</th>
                          <th data-class="expand">Preview</th>
                         <th data-class="expand">Rejoin</th>

                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td style="text-align:center!important;" colspan="6" class="dataTables_empty">Loading details...</td>
                    </tr>
                </tbody>
            </table>
        </div>




        <div id="divReport" class="table-responsive" runat="server" style="display:none;">
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

 <asp:Button ID="btnClickExp" class="save" runat="server" Text="Export"   OnClick="btnClickExp_Click" style="display:none;" />
        
           
                                            <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="../../Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 40%; padding-bottom: 0.7%; padding-top: 0.6%;">Employee Master</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>       

    </div>
    <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>


    <div id="dialog_simple"  title="Dialog Simple Title" hidden="hidden" style="font-family:Calibri;font-size:16px;height:100%;">
        <div>
          <table style="box-sizing:content-box;" id="ReportTable"   >
               
                      <thead>
                      <tr>
                     <td  class="thT" style= "width:475px; background-color:#79895f;height:40px; text-align:left;font-family:Calibri;color: #fff;; word-wrap:break-word;">PARTICULARS</td>
                     <td class="thT" style="width:475px;text-align:left; background-color:#79895f; font-family:Calibri;color: #fff;;word-wrap:break-word;">DETAILS</td>
                          </tr>
                       </thead> <tbody></tbody> </table></div>
                     <div class="widget-body smart-form"  style=" width: 100%; ">
                      <div id="empdetails" align="center"  style="width:98.3%; margin-top:0px; height:400px; overflow-y: auto;" class="formdiv" runat="server">
         
                        </div>
                          </div>
           
        </div>
          
    
     
     <div id="dialog_simple1"  title="Dialog Simple Title" hidden="hidden" style="font-family:Calibri;font-size:16px;height:100%;">
        <div>
          <div class="eachform" style="width: 50%;margin-top: 2%;margin:5px 0px 0px;">
                <h2 style="width:22%;" >Business Unit</h2>
                <asp:DropDownList ID="ddlBu" Height="30px"  Width="60%" data-placeholder="All" onchange="return changeBu();"  multiple="multiple" class="form1 select2" runat="server" Style="cursor: pointer;margin-left:5%;">
                </asp:DropDownList>
            </div>
             <div class="eachform" style="width: 40%;margin-top: 2%;margin:5px 0px 0px;">

                <h2>Employee Type</h2>

                <asp:DropDownList ID="ddlEmpType" Height="30px"  Width="50%" class="form1 sk" runat="server" Style="cursor: pointer;font-size:14px;" onchange="IncrmntConfrmCounter();">
                    <asp:ListItem Text="All" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Staff" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Worker" Value="1"></asp:ListItem> 
                </asp:DropDownList>


            </div>
             <div class="eachform" style="width: 50%;margin-top: 2%;margin:5px 0px 0px;">

                <h2 style="width:22%;">Department</h2>

                <asp:DropDownList ID="ddlDep" Height="30px"  Width="60%" data-placeholder="All"  multiple="multiple" class="form1 select2" runat="server" Style="cursor: pointer;" onchange="IncrmntConfrmCounter();">
                </asp:DropDownList>


            </div>
             <div class="eachform" style="width: 40%;margin-top: 2%;margin:5px 0px 0px;">

                <h2>Status</h2>

                <asp:DropDownList ID="ddlStsExp" Height="30px"  Width="50%" class="form1 sk" runat="server" Style="cursor: pointer;font-size:14px;" onchange="IncrmntConfrmCounter();">
                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Inactive" Value="2"></asp:ListItem>
                    <asp:ListItem Text="On Leave" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Resign" Value="4"></asp:ListItem>                    
                    <asp:ListItem Text="Termination" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Retirement" Value="6"></asp:ListItem>
                    <asp:ListItem Text="Abscond" Value="7"></asp:ListItem>
                    <asp:ListItem Text="Death" Value="8"></asp:ListItem>
                    <asp:ListItem Text="Resume" Value="9"></asp:ListItem>
                    <asp:ListItem Text="Under Police Custody" Value="10"></asp:ListItem>
                    <asp:ListItem Text="Other" Value="11"></asp:ListItem>
                </asp:DropDownList>



            </div>
        </div>
                   
         <asp:Button ID="btnExport" class="save" runat="server" Text="Export" OnClientClick="return ExportCsv();" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;font-size: 13px;" />             
         <asp:Button ID="btnCloseExp" class="save" style="width: 90px; float:right;margin-right:40%;margin-top: 3%;font-size: 13px;" onclientclick="CloseExp();" runat="server" Text="Close" />
                       
           
        </div>
        
     <asp:HiddenField ID="HiddenFieldLmtdUser" runat="server" />
     <asp:HiddenField ID="HiddenFieldUserDesgId" runat="server" />

     <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script> 
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>    
    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
       
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />
    <link href="/JavaScript/datepicker/datepicker3.css" rel="stylesheet" />

    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="/JavaScript/datepicker/bootstrap-datepicker.js"></script>
    
     <script>

         var $noConfi = jQuery.noConflict();
         $noConfi(function () {
             $noConfi('#cphMain_txtFromDateSrch').datepicker({
                 autoclose: true,
                 format: 'dd-mm-yyyy',
                 language: 'en',
                 // startDate: new Date()
             });
             $noConfi('#cphMain_txtTodateSrch').datepicker({
                 autoclose: true,
                 format: 'dd-mm-yyyy',
                 language: 'en',
                 //startDate: new Date()
             });
         });
    </script>

      <script>
          //for search option
          var $NoConfi = jQuery.noConflict();
          var $NoConfi3 = jQuery.noConflict();

          function LoadEmployeeList()
          {

            var orgID = '<%= Session["ORGID"] %>';
            var corptID = document.getElementById("<%=HiddenFieldCorpId.ClientID%>").value;; 
            var DesgID = document.getElementById("<%=HiddenFieldUserDesgId.ClientID%>").value;
            var LmtdUser = document.getElementById("<%=HiddenFieldLmtdUser.ClientID%>").value;
            var Status = document.getElementById("cphMain_ddlStatus").value;
            var CnclSts = 0;
              //0039
            var fromdate = document.getElementById("cphMain_txtFromDate").value;
            var todate = document.getElementById("cphMain_txtTodate").value;
              //end

           

            //alert(Status);
            //alert(fromdate);
            //alert(todate);
            if (document.getElementById("cphMain_cbxCnclStatus").checked)
            {
                CnclSts = 1;
            }

              //0039 nw
            document.getElementById("<%=hiddenDesgID.ClientID%>").value = DesgID;
              //alert(document.getElementById("<%=hiddenDesgID.ClientID%>").value);
           
            //hiddenLmtdUser.Value = LmtdUser;
            //hiddenStatus.Value = Status;
            //hiddenCnclSts.Value = CnclSts;
            //hiddenfromdate.Value = fromdate;
            //hiddentodate.Value = todate;
              //end

            var responsiveHelper_datatable_fixed_column = undefined;


            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };

            /* COLUMN FILTER  */

            var otable = $NoConfi3('#datatable_fixed_column').DataTable({

                'bProcessing': false,
                'bServerSide': true,
                'sAjaxSource': 'data.ashx',

                "bDestroy": true,
                "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6 hidden-xs'f><'col-sm-6 col-xs-12 hidden-xs'<'toolbar'>>r>" +
                        "t" +
                        "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
                "autoWidth": true,
                "oLanguage": {
                    "sSearch": ' <span  class="input-group-addon"><i  class="glyphicon glyphicon-search"></i></span>'

                },
                "preDrawCallback": function () {
                    // Initialize the responsive datatables helper once.
                    if (!responsiveHelper_datatable_fixed_column) {
                        responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($NoConfi3('#datatable_fixed_column'), breakpointDefinition);
                    }
                },
                "rowCallback": function (nRow) {
                    responsiveHelper_datatable_fixed_column.createExpandIcon(nRow);
                },
                "drawCallback": function (oSettings) {
                    responsiveHelper_datatable_fixed_column.respond();
                },
                "fnServerParams": function (aoData) {
                    aoData.push({ "name": "ORG_ID", "value": orgID });
                    aoData.push({ "name": "CORPT_ID", "value": corptID });
                    aoData.push({ "name": "STATUS", "value": Status });
                    aoData.push({ "name": "CNCL_STS", "value": CnclSts });
                    aoData.push({ "name": "DESG_ID", "value": DesgID });
                    aoData.push({ "name": "LMTD_USER", "value": LmtdUser });
                    //0039
                    aoData.push({ "name": "FR_DATE", "value": fromdate });
                    aoData.push({ "name": "TO_DATE", "value": todate });
                    //end

                }
            });


            // Apply the filter

            $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                otable
                    .column($NoConfi(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();

            });
            /* END COLUMN FILTER */

        }

    </script>
    <style>
        .table td + td+td+td,
.table th + th+th+th
{
    text-align:center;
}
          #datatable_fixed_column_wrapper {
            border: 1px solid #065757;
        }
        .dt-toolbar  {
    border-bottom: 1px solid  #c8b6b6;
    background: #f4f6f0;
}
.dt-toolbar-footer  {
    border-top: 1px solid  #c8b6b6;
    background: #f4f6f0;
}
.table > thead > tr > th {
    background: #eee;
    color:#fff;
}
.table-bordered, .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
    border-bottom: 1px solid #c8b6b6;
    border-right: 1px solid  #c8b6b6;
}
.table {
    font-size: 13px;
}
.table-striped > tbody > tr:nth-of-type(2n+1) {
    background-color: #eaeaea;
}
        table.dataTable thead .sorting {
              background-color: #79895f;
        }
        table.dataTable thead .sorting_asc, table.dataTable thead .sorting_desc {
    background-color: #92a276;
}
        .table > thead > tr > th {
            padding: 8px 10px;
        }
        .table > tbody > tr > td {
            padding: 5px 10px;
            border-bottom: none;
        }

        .table {
            color: #3e3737;
            font-weight: bolder;
        }
        .dataTables_empty {text-align:center!important;width:100%;}
        </style>
   <!--emp0026-->
        <script src="/js/jQuery/jquery-2.2.3.min.js"></script>  
       <script src="/js/jQueryUI/jquery-ui.min.js"></script>
     <%--   <script src="/js/HCM/Common.js"></script>--%>
       <script type="text/javascript">
           var $nooC = jQuery.noConflict();
 
           $nooC(function () {
             
               $nooC('#dialog_simple').dialog({
                   autoOpen: false,
                   width: 1000,
                   resizable: false,
                   modal: true,
                   title: "EMPLOYEE DETAILS PREVIEW",
               });
               $nooC('#dialog_simple1').dialog({
                   autoOpen: false,
                   width: 1000,
                   resizable: false,
                   modal: true,
                   title: "EXPORT EMPLOYEE DETAILS",
               });
           });
    </script>
    <script>
        function CallCSVBtn() {
            document.getElementById("<%=HiddenFieldBu.ClientID%>").value = "";
            document.getElementById("<%=HiddenFieldDept.ClientID%>").value = "";
            document.getElementById("<%=HiddenFieldExpEmpType.ClientID%>").value = "";
            document.getElementById("<%=HiddenFieldExpSts.ClientID%>").value = "";
            document.getElementById("<%=ddlEmpType.ClientID%>").value = 2;
            document.getElementById("<%=ddlStsExp.ClientID%>").value = 0;          
            $noCon("#cphMain_ddlBu").val(null).trigger("change");
            $noCon("#cphMain_ddlDep").val(null).trigger("change");
            $noCon('#cphMain_ddlDep').prop('disabled', true);
            confirmbox = 0;
            $nooC('#dialog_simple1').dialog('open');
        }
        function CloseExp() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to close without export employee details?")) {
                    $nooC('#dialog_simple1').dialog('close');
                }
                else {
                    return false;
                }
            }
            else {
                $nooC('#dialog_simple1').dialog('close');
            } 
        }
        function ExportCsv() {
            document.getElementById("<%=HiddenFieldBu.ClientID%>").value = $('#cphMain_ddlBu').val();
            document.getElementById("<%=HiddenFieldDept.ClientID%>").value = $('#cphMain_ddlDep').val();
            document.getElementById("<%=HiddenFieldExpEmpType.ClientID%>").value = document.getElementById("<%=ddlEmpType.ClientID%>").value;
            document.getElementById("<%=HiddenFieldExpSts.ClientID%>").value = document.getElementById("<%=ddlStsExp.ClientID%>").value;
            $nooC('#dialog_simple1').dialog('close');
            document.getElementById("<%=btnClickExp.ClientID%>").click();      
            return true;
        }
        function changeBu() {
            IncrmntConfrmCounter();
            $noCon("#cphMain_ddlDep").val(null).trigger("change");
            var orgID = '<%= Session["ORGID"] %>';
            var Bus = $('#cphMain_ddlBu').val();
            Bus = String(Bus).replace(/,/g, '-');
            var arr = Bus.split('-');
            if (arr.length == 1 && arr[0] != "" && arr[0] != null &&arr[0] != "null" && orgID != null && orgID != "" && orgID != "null") {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_Emp_Personal_Info_List.aspx/changeBus",
                    data: '{orgID: "' + orgID + '",Bus: "' + Bus + '"}',
                    dataType: "json",
                    success: function (data) {
                        $noCon('#cphMain_ddlDep').prop('disabled', false);
                        document.getElementById("cphMain_ddlDep").innerHTML = data.d;
                    }
                });
            }
            else {
                document.getElementById("cphMain_ddlDep").innerHTML = "";
                $noCon('#cphMain_ddlDep').prop('disabled', true);
               
            }
            return false;
        }
        function NodataCsv() {
            alert("No records found!");
            return false;
        }
        $noCon(document).on('select2:opening.disabled', ':disabled', function () { return false; });
        $noCon(document).on("keydown keypress keyup", function (e) {            
            var ClasNAme= $(event.target).attr('class');
            var key = event.keyCode || event.charCode;
            if (key == 8 && ClasNAme == "select2-search__field") {
                $noCon(".select2-search__field").val('');
                return false;
            }
        });
    </script>
  </asp:Content>

