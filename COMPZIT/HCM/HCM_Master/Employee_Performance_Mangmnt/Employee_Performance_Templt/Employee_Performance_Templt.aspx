<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" CodeFile="Employee_Performance_Templt.aspx.cs" Inherits="HCM_HCM_Master_Employee_Performance_Mangmnt_Employee_Performance_Templt_Employee_Performance_Templt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

     <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>

    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />
    <%--<link href="/css/HCM/main.css" rel="stylesheet" />--%>
    <link href="../../../../css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="../../../../js/jQueryUI/jquery-ui.min.js"></script>
    <script src="../../../../js/jQueryUI/jquery-ui.js"></script>
    <script src="../../../../js/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../../js/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="/js/HCM/Common.js"></script>
    <script src="js/jquery.min.js"></script>

<%--    <script src="js/jquery-1.11.2.min.js"></script> 
<script src="js/jquery.min.js"></script>
<script src="js/bootstrap3.3.5.min.js"></script>--%>

    <script>


        //$(document).ready(function () {

        //    $('#check-show').change(function () {
        //        if ($(this).is(":checked")) {
        //            $('#show-div').slideDown();
        //        }
        //        else {
        //            $('#show-div').slideUp(300);
        //        }

        //    });
        //});

   

        var $noCon1 = jQuery.noConflict();
        $noCon1(window).load(function () {

            var EditVal = document.getElementById("cphMain_hiddenUpdatevw").value;

            if (EditVal != "") {


                // alert('edit  ' + EditVal);

                // var find1 = '\\\\';
                //  var re1 = new RegExp(find1, 'g');
                //  var res1 = EditVal.replace(re1, '');

                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = EditVal.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');
                //   alert('res3' + res3);
                var json = $noCon.parseJSON(res3);
                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        //  if (json[key].TempDetlId != "") {
                        // AddNewGroup();

                        EditListRows(json[key].TempId, json[key].GrpName, json[key].GrpId, json[key].Qstnid, json[key].QstnName, json[key].Api, json[key].Ratescaleid);

                    }
                }
                //addMoreRows();
                AddButtonCheck();

            }
            else {
                AddNewGroup();
            }


          //  AddNewGroup();

        });


        function AddButtonCheck() {
            // HiddenFieldView

          
            addRowtable = document.getElementById("tableGrp");

            for (var i = 0; i < addRowtable.rows.length; i++) {
                //  if (i != addRowtable.rows.length - 1) {
                var row = addRowtable.rows[i];
                var xLoop = (addRowtable.rows[i].cells[0].innerHTML);

           

                addRowtableIn = document.getElementById("TableQstn_" + xLoop);

            
                    //  if (i != addRowtable.rows.length - 1) {
                var rowin = addRowtableIn.rows.length-1;
                var xLoopin = (addRowtableIn.rows[rowin].cells[0].innerHTML);
                var xLoopinnxt = (addRowtableIn.rows[rowin].cells[1].innerHTML);
                document.getElementById("tdInxQstn" + xLoopin).value = "";
                document.getElementById("btnAddQstn_" + xLoopin).style.opacity = "1";

                //btnaddqstn
                document.getElementById("btnImportQstn_" + xLoopin).style.opacity = "1";
                document.getElementById("btnImportQstn_" + xLoopin ).disabled = false;
                
            }

            var maintblid = addRowtable.rows.length-1;
            var mainxLoopin = (addRowtable.rows[maintblid].cells[0].innerHTML);
            document.getElementById("btnGrpAdd" + mainxLoopin).style.opacity = "1";
             document.getElementById("tdInxGrp" + mainxLoopin).value = "";

             if (document.getElementById("cphMain_HiddenFieldView").value == "1") {
                 $("#tableGrp").find("input,button,textarea,select,div").attr("disabled", "disabled");

                //$('.btn btn-primary btn-width').css( 'opacity', .3);
              
                 document.getElementById("dtncpyGrps").disabled = true;
             }

                return false;
            }


        var $noCon = jQuery.noConflict();

        function SuccessConductInsident() {

            '<%Session["MESSG_CONDINCDNT"] = "' + null + '"; %>';

            $noCon("#success-alert").html("Employee conduct incident inserted successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        }
        function SuccessUpdate() {

            '<%Session["MESSG_CONDINCDNT"] = "' + null + '"; %>';

            $noCon("#success-alert").html("Employee conduct incident updated successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        }
        
        function CanclUpdMsg() {

            '<%Session["MESSG_CONDINCDNT"] = "' + null + '"; %>';

            $noCon("#success-alert").html("This action is  denied! This performance template is already canceled .");
               $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
               });
               $noCon("#success-alert").alert();

               return false;
           }
   

        function ConfirmMessage() {

            //  SuccessMsg("SAVE", "Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
            //$noCon("#success-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
            //$noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            //});
            //$noCon("#success-alert").alert();
          
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "Employee_Perfomance_Templt_List.aspx";
                    }

                    else {
                        // window.location.href = "hcm_Emp_Conduct_Incident_List.aspx";
                        return false;
                    }
                });
            }
            else {
                
                window.location.href = "Employee_Perfomance_Templt_List.aspx";
               // return true;
            }
            return false;

        }

 
    var confirmbox = 0;

    function IncrmntConfrmCounter() {
        confirmbox++;
        return false;
    }
   
        </script>
      
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
            <asp:HiddenField ID="hiddenupd" runat="server" />
     <asp:HiddenField ID="HiddenFieldQryString" runat="server" />
     <asp:HiddenField ID="HiddenAllUserDivision" runat="server" />
      <asp:HiddenField ID="HiddenConductInsId" runat="server" />
     <asp:HiddenField ID="HiddenEmailAddress" runat="server" />
      <asp:HiddenField ID="HiddenUserId" runat="server" />
    <asp:HiddenField ID="HiddenRoleUpd" runat="server" />
    <asp:HiddenField ID="HiddenFocus" runat="server" />
       <asp:HiddenField ID="HiddenUserIdValidate" runat="server" />
           <asp:HiddenField ID="HiddenConductId" runat="server" />


           <asp:HiddenField ID="hiddenQstnCanclDtlId" runat="server" />
        <asp:HiddenField ID="hiddenGrpCanclDtlId" runat="server" />
      <asp:HiddenField ID="HiddenFieldSaveTemplate" runat="server" />
     <asp:HiddenField ID="hiddenUpdatevw" runat="server" />
     <asp:HiddenField ID="HiddenFieldView" runat="server" />
         
      <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <%-- <div id="main" role="main">--%>
      
        <div class="cont_rght" >
                  <div style="height:34px;">
  
                    <div class="alert alert-danger" id="divWarning" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>
                    <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button> 
        </div>
            <section id="widget-grid" class="">

                <div class="row">
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <div class="" id="wid-id-0">


        <div id="divReportCaption" runat="server" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <%--  <img src="/Images/BigIcons/Job_Delegation.png" style="vertical-align: middle;" />--%>
     <asp:Label ID="lblEntry" runat="server"></asp:Label>
        </div >
      
        <div  id="divList"  class="list" runat="server" style="position: fixed; right: 1%; top: 42%; height: 26.5px;z-index: 90;" onclick="return ConfirmMessage()">

           
        </div>

                            <br>

  <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: #f6f6f6; float: left">
       
    <div class="auto1">
<div class="cont_rght" style="width:100%">
<div class="sect250">
<div class="row">
<div class="container" style="padding-top:18px;padding-bottom: 33px;">
<%--  <h3 class="box-title" style="text-transform:capitalize;margin-bottom:14px;color:#5e6b47;">
    <i class="fa fa-file-text-o" style="margin-right:10px;" aria-hidden="true"></i>Performance form template
  </h3>--%>
  
  <div class="col-lg-12" style="margin-top:-21px;">

<%--<button class="btn green" style="border-radius:0px;float:right;"><i class="fa fa-eye" style="margin-right:10px;"></i>Preview</button>--%>


<%--<button class="btn btn-primary" style="border-radius:0px;float:right;margin-right:11px;"><i class="fa fa-list-alt" style="margin-right:10px;"></i>List</button>--%>
</div>

  <div class="form-row">
    <div class="form-group col-md-4 padding5">
   
      <label for="inputEmail4" style="margin-bottom:3px;">
     Template Name<span class="red">*</span>
       </label>
        <asp:TextBox ID="txtPefmnceFrm" runat="server"  class="form-control" onblur="return  IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)"  onkeydown="textCounter(cphMain_txtPefmnceFrm,200)" onkeyup="textCounter(cphMain_txtPefmnceFrm,200)" style="float: right;width: 60%;" ></asp:TextBox>
  <%--<input type="text" class="form-control" id="inputEmail4" placeholder="">--%>
    </div>
 
  </div>
   <div class="form-row">
    <div class="form-group col-md-4 padding5">
   
      <label for="inputEmail4" style="margin-bottom:3px;">
     REF#<span class="red">*</span>
       </label>
   <asp:TextBox ID="txtRefNo"  runat="server"  class="form-control" style="width: 81%;float: right;"></asp:TextBox>
  <%--<input type="text" class="form-control" id="inputEmail4" placeholder="">--%>
    </div>
 
  </div>
  
  <div style="clear:both"></div>
  <div class="form-row">
    <%--    <div class="form-group col-md-8 padding5">
      <label for="inputCity" style="margin-bottom:3px;">Ref</label>
          <asp:TextBox ID="txtRefNo" runat="server"  class="form-control" style="width: 81%;float: right;"></asp:TextBox>
   
    </div>--%>

    <div class="form-group col-md-8 padding5">
      <label for="inputCity" style="margin-bottom:3px;">Notes/Instructions</label>
         <asp:TextBox class="form-control" id="txtNote"  onblur="return  IncrmntConfrmCounter();"   TextMode="MultiLine" onkeydown="textCounter(cphMain_txtNote,400)" onkeyup="textCounter(cphMain_txtNote,400)" runat="server"  style="float: right;width: 81%; resize: none;" ></asp:TextBox>
    <%-- <asp:TextBox ID="txtNote" TextMode="MultiLine"  runat="server"  MaxLength="1000" Width="50%" Height="80px" onkeypress="return  isTagEnter(event);" onblur="return textCounter(cphMain_txtNote,500)" onkeydown=" return textCounter(cphMain_txtNote,500)"  Style="resize: none;  font-family: calibri;" TabIndex="2"></asp:TextBox>--%>
        
        
         <%-- <textarea class="form-control" id="exampleFormControlTextarea1" rows="3" style="resize:none"></textarea>--%>
    </div>
 <div style="clear:both"></div>   
    <div class="form-row form-inline">
    <div class="col-sm-4 col-md-4 padding-10" style="margin-top:3px;padding:0;width: 100%;float: right;margin-right: 1%;">
    <div class="form-group col-md-4 padding5">
      <label for="inputState" style="margin-bottom:8px;">Rating Scale</label>

             <asp:DropDownList ID="ddlRating"  CssClass="form-control" class="form1" runat="server" onchange="return  IncrmntConfrmCounter();"   onkeypress="return DisableEnter(event)" style="float: right;margin-right: 41%;">
                           <%-- <asp:ListItem Text="0" Value="0"></asp:ListItem>--%>
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            <asp:ListItem Text="6" Value="6"></asp:ListItem>
                            <asp:ListItem Text="7" Value="7"></asp:ListItem>
                             <asp:ListItem Text="8" Value="8"></asp:ListItem>
                             <asp:ListItem Text="9" Value="9"></asp:ListItem>
                           <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            </asp:DropDownList>
  
    </div>
   
     <div class="col-sm-4 col-md-4" style="margin-top:3px;">
    <div class="form-group form-inline row" style="float: right;margin-right: 60%;">
    <label for="inputPassword" class="col-sm-4 col-form-label" style="margin-right:21px;">Status<span style="color:#F00"></span></label>
   
      <label class="ch" >Active
        <%--<input type="checkbox" id="check-show">
        <span class="checkmark"></span> --%></label>
<%--          <input type="checkbox" id="Chksts"  onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" checked="checked" runat="server" />--%>
                    <asp:CheckBox ID="Chksts" Text="" runat="server"  onchange="IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)"  Checked="true"/>
                 
        </div>
  </div>

             <div class="col-sm-4 col-md-4 ">

            <a >
<button id="dtncpyGrps" onclick="return OpenGroupcopy();" class="btn btn-primary btn-width"data-toggle="modal" data-target=".bs-example-modal-lg"  style="border-radius:0px;margin-right:11px;" ><i class="fa fa-clipboard" style="margin-right:10px;"></i>Import groups from existing template</button></a>
        </div>
</div>
</div>
    
    </div>
<div style="clear:both"></div>

      <div id="DivGroup">
          <table id="tableGrp"  style="width: 100%;">
                                </table>

    </div>


<div>
<div class="col-md-12" style="padding:9px;">
<div style="float:right;">
    <asp:Button ID="bttnsave"   runat="server" OnClientclick="return ValidatePrfmncTemplt();"  class="btn btn-primary btn-grey  btn-width" text="Save"  OnClick="bttnsave_Click"/>
    <%-- <asp:Button ID="bttnsaveChk"   runat="server" OnClientclick="return validateTable();"  class="btn btn-primary btn-grey  btn-width" text="SaveChk"  />--%>
<%--<button class="btn btn-primary btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-save" style="margin-right:10px;"></i>Save</button>--%>
    <asp:Button ID="btnUpdate"   runat="server" OnClientclick="return ValidatePrfmncTemplt();"  class="btn btn-primary btn-grey  btn-width" text="Update" OnClick="btnUpdate_Click" />
   <%-- <asp:Button ID="btnPublishConform"   runat="server" OnClientclick="return ValidateConduct();"  class="btn btn-primary btn-grey  btn-width" text="Publish/Conform"  />--%>
   <%-- <asp:Button ID="btnClear"   runat="server" OnClientclick="return ValidateConduct();"  class="btn btn-primary btn-grey  btn-width" text="Clear" />--%>
    <asp:Button ID="btnCancel"   runat="server" OnClientclick="return ConfirmMessage();"  class="btn btn-primary btn-grey  btn-width" text="Cancel"  />

     <asp:Button ID="ButtnClose"   runat="server" OnClientclick="return CloseWindow();"  class="btn btn-primary btn-grey  btn-width" text="Close"  />


<%--<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-upload" style="margin-right:10px;"></i>Update</button>
<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-check" style="margin-right:10px;"></i>Publish/Conform</button>
<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-refresh" style="margin-right:10px;"></i>Clear</button>
<button class="btn btn-primary  btn-grey  btn-width" style="border-radius:0px;"><i class="fa fa-remove" style="margin-right:10px;"></i>Cancel</button>--%>
</div>
</div>  
</div>
  </div>




<div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">
  <div class="modal-dialog modal-sm">
    <div class="modal-content" style="overflow:auto;border-radius:0px;">
      <div class="modal-header"><h4> <i class="fa fa-info-circle"></i>Confirm</h4></div>
      <div class="modal-body" style="font-size:17px;"><i class="fa fa-question-circle"></i>
      Are you sure you delete the group?</div>
     
<div class="modal-footer">
<button type="button" id="yesbtn" class="btn btn-primary" data-toggle="modal" data-target=".bs-example-modal-sm">Yes</button>&nbsp; 
<a href="#"> <button id="yesbtn1" type="button" class="btn btn-primary" data-toggle="modal" data-target=".bs-example-modal-sm">No</button>
</a></div>
      </div>
    </div>
</div>

    
    
    
   <%-- EVM-0027--%>
    
    <div id="myModelgrp"  data-keyboard="true" tabindex="-1" onkeypress="keyPressHandler(event);" onkeydown="keyPressHandler(event);" class="modal fade bs-example-modal-lg"  role="dialog" aria-labelledby="myLargeModalLabel">
      <%--  //end--%>
  <div class="modal-dialog modal-lg" >
    <div class="modal-content" style="overflow:auto;border-radius:0px;">
      <div class="modal-header" style="background-color:#cacaca">
      <h4 id="CopyPopupText" style="font-weight:bold;"> 
        <i class="fa fa-copy" style="font-weight:bold;"></i>
        &nbsp;&nbsp;Import Questions
      </h4>
     </div>
     
      <div class="modal-body" style="font-size:17px;padding:31px;">
       
  <div class="form-group row"  >
    <label for="inputEmail3" class="col-sm-4 col-form-label">Performance Template<span class="red">*</span></label>
    <div class="col-sm-8">
    <!--  <input type="email" class="form-control" id="inputEmail3" placeholder="Email">-->
   <%--   <select style="width:100%;font-size: 15px;padding: 4px;">
        <option selected>Mentioned the main details about the performance template.</option>
        <option value="1">Mentioned the main details about the performance template.</option>
        <option value="2">Mentioned the main details about the performance template. </option>
        <option value="3">Mentioned the main details about the performance template. </option>
      </select>--%>

         <asp:DropDownList ID="ddlPerfForm" class="form-control"  runat="server" onchange="return LoadQstions();" style="width:64%;font-size: 14.5px;" onkeypress="return DisableEnter(event)" ></asp:DropDownList>
    </div>
  </div>
   <div class="form-group row">
   
   <div class="col-6 col-md-6">
   <ul class="nav nav-tabs" id="myTab" role="tablist">
  <li id="ligrp" class="nav-item active" >
    <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Groups</a>
  </li>
  <li id="liQstn" class="nav-item active">
    <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="true">Questions</a>
  </li>
  
</ul>
<div class="tab-content" id="myTabContent" style="max-height:300px;overflow:auto;line-height:2;">
  <div class="tab-pane fade active in" id="home" role="tabpanel" aria-labelledby="home-tab" style="border:1px solid #dddddd;
border-top: none;
    padding: 3px;min-height:299px">
       <div style="width:100%;" id="DivCopyQstn"></div>
       <div style="width:100%;" id="DivCopyGrp"></div>

  </div>

  
</div>
<div class="form-group row">
    <div class="col-sm-12" style="margin-top:11px;">
      <button id="bttnQstnAdd" type="submit" class="btn btn-primary" style="float:right"><i class="fa fa-plus" style="margin-right:10px;"></i>Add</button>
    </div>
  </div>
   </div>
 
  <div class="col-6 col-md-6" style="margin-top:42px;">
  
<div class="tab-content" id="Div1" style="max-height:300px;overflow:auto;line-height:2;border: 1px solid #dddddd;">
  <div class="tab-pane fade active in" id="Div2" role="tabpanel" aria-labelledby="home-tab" style="border:1px solid #dddddd;
border-top: none;
    padding: 3px;min-height:299px">
       <div style="width:100%" id="DivPasteQstn">

           <table class="list-group bg-grey" style="width:100%" id="TableSelectQstn" ></table>
       </div>
     
 


  </div>
  <div class="tab-pane fade" id="Div3" role="tabpanel" aria-labelledby="profile-tab"  style="border: 1px solid #dddddd;
    border-top: none;
    padding: 3px;"><ul class="list-group" style="font-size:15px;">
  <li class="list-group-item" style="font-weight:bold;"> 
 Group 1
  </li>
  <li class="list-group-item"> 
  <label class="ch">
        <input type="checkbox" id="Checkbox31">
        <span class="checkmark"></span> </label>Raw denim you probably haven't heardRaw denim you probably haven't heardRaw denim you probably haven't heardRaw denim you probably haven't heard</li>
  <li class="list-group-item"><label class="ch">
        <input type="checkbox" id="Checkbox32">
        <span class="checkmark"></span> </label>Raw denim you probably haven't heard</li>
  <li class="list-group-item"><label class="ch">
        <input type="checkbox" id="Checkbox33">
        <span class="checkmark"></span> </label>Raw denim you probably haven't heard</li>
        <li class="list-group-item"><label class="ch">
        <input type="checkbox" id="Checkbox34">
        <span class="checkmark"></span> </label>Raw denim you probably haven't heard</li>
        <li class="list-group-item"><label class="ch">
        <input type="checkbox" id="Checkbox35">
        <span class="checkmark"></span> </label>Raw denim you probably haven't heard</li>
        <li class="list-group-item"><label class="ch">
        <input type="checkbox" id="Checkbox36">
        <span class="checkmark"></span> </label>Raw denim you probably haven't heard</li>
        <li class="list-group-item"><label class="ch">
        <input type="checkbox" id="Checkbox37">
        <span class="checkmark"></span> </label>Raw denim you probably haven't heard</li>
        <li class="list-group-item"  style="font-weight:bold;"> 
  Group 2
  </li>
  <li class="list-group-item"><label class="ch">
        <input type="checkbox" id="Checkbox38">
        <span class="checkmark"></span> </label>Raw denim you probably haven't heard</li>
        <li class="list-group-item"><label class="ch">
        <input type="checkbox" id="Checkbox39">
        <span class="checkmark"></span> </label>Raw denim you probably haven't heard</li>
        <li class="list-group-item"><label class="ch">
        <input type="checkbox" id="Checkbox40">
        <span class="checkmark"></span> </label>Raw denim you probably haven't heard</li>
</ul></div>
  
</div>
<div class="form-group row">
    <div class="col-sm-12" style="margin-top:11px;">
      <button id="bttnRemovetab" type="submit" class="btn btn-primary" style="float:right"><i class="fa fa-remove" style="margin-right:10px;"></i>
      Remove</button>

             <button id="bttnRemovetabQstn" type="submit" class="btn btn-primary" style="float:right"><i class="fa fa-remove" style="margin-right:10px;"></i>
      Remove</button>
    </div>
  </div>

  </div>
   
   </div>
<div style="float:right;margin-bottom:10px;width:18%">  
<%-- <a data-toggle="modal" data-target=".bs-example-modal-lg"> --%>
 <button id="bttnfill" onclick="return ButtnFillClick();"  style="float:left;display:none"   class="btn btn-primary" >Import</button>&nbsp; 
  <%--  //data-dismiss="modal"--%>
    <button id="bttnfillGrp" onclick="return ButtnFillClickGrp();"  style="float:left;display:none" class="btn btn-primary" >Import</button>&nbsp; 
<%-- </a>--%>
<%-- <a data-toggle="modal" data-target=".bs-example-modal-lg">--%>
<button  id="bttnno"  data-dismiss="modal" onclick="return false" class="btn btn-primary">Cancel</button>
<%--</a>--%>
</div>

     </div>
      </div>
    </div>
    
</div>








  
</div>
</div>
</div>








</div>
  
    </div>

  </div>  </article>  </div>  </section>  </div>  </div>





        
    <%--    <div class="eachform" style="float: left; width: 63%;margin-left: 17%;">
                <h2>Status*</h2>
                <asp:CheckBox ID="CbxStatus" Text="" runat="server" onkeydown="return DisableEnter(event)"  onchange="IncrmntConfrmCounter();" class="form2" style="float: left;margin-left: 42%;" TabIndex="3" Checked="true"/>
             <asp:Label ID="lblStatus" style="font-family: calibri;" runat="server" Text="Active"></asp:Label>
        </div>--%>

      <%--  <div class="contentarea">--%>
        



      <%--  </div>--%>
  <%--  </div>--%>

            <br />
       <%-- <div class="eachform">
            <div class="subform" style="width: 72%; margin-top: 5%;float: left;margin-left: 43%;">


               
                <asp:Button ID="btnAdd" runat="server" class="btn btn-primary" Text="Save" OnClientClick=" return ReasonValidate();" OnClick="btnAdd_Click" TabIndex="4"/>
                <asp:Button ID="btnAddClose" runat="server" class="btn btn-primary" Text="Save & Close" TabIndex="5"  OnClientClick=" return ReasonValidate();" OnClick="btnAdd_Click" />
                <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary"  Text="Update" TabIndex="6"  OnClientClick=" return ReasonValidate();" OnClick="btnUpdate_Click"/>
                <asp:Button ID="btnUpdateClose" runat="server" class="btn btn-primary"  Text="Update & Close" TabIndex="7"   OnClientClick=" return ReasonValidate();" OnClick="btnUpdate_Click"/>
                 <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" OnClientClick="return ConfirmMessage();" />
            </div>
        </div>--%>
        <%--</div>--%>
    <style>

        


/*.datepicker table tr td.old{
    color:red;
}*/


    </style>
       <style type="text/css">
        /*.ui-autocomplete {
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
                }*/
    </style>
  <%--  <script src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>--%>
  <%--  <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />--%>

    <script>


        function myFunction() {

            $("#yesbtn").click(function () { $("#group1").hide(); });

        }
        function closebox() {
            $("#boxhide").hide();
        }

        function SuccessMsg() {
            $noCon("#success-alert").html("Performance template inserted successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;

        }

        function SuccessUpdMsg() {
            $noCon("#success-alert").html("Performance template updated successfully");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;

        }

        function ValidatePrfmncTemplt() {
            var ret = true;
            var prfmncName = document.getElementById("<%=txtPefmnceFrm.ClientID%>").value;
            if (prfmncName == "") {
                document.getElementById("<%=txtPefmnceFrm.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtPefmnceFrm.ClientID%>").focus();

                 $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                 $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                 });
                 $noCon("#divWarning").alert();
                 $noCon1(window).scrollTop(0);

                 ret = false;
            }

            if (!(validateTable(ret)))
            {
                ret = false;
            }
            return ret;

        }

       </script>



    <script>
        //  var $noConn = jQuery.noConflict();
        var rowSubCatagory = 0;
        var RowIndex1 = 0;
        function AddNewGroup() {
            //rowSubCatagory++;
            RowIndex1++;

            var FrecRow = '';
            FrecRow = '<tr id="SubGrpRowId_' + RowIndex1 + '" ><td   id="tdidGrpDtls' + RowIndex1 + '" style="display: none" >' + RowIndex1 + '</td>';
            FrecRow += '<td>';
            FrecRow += '<div style="clear:both"></div><div style="display:none" id="groupSubCat' + RowIndex1 + '">' + rowSubCatagory + '</div> <div class="container-fluid"  id="group1_' + RowIndex1 + '" style="height:auto;border:1px solid #7c8272;padding:10px;margin:10px;margin-top:45px;">';
            FrecRow += '<div class="col-lg-12"  style="padding:1px;"><div title="DELETE" id="bttnRemovGrp' + RowIndex1 + '"  class="btn" onclick="return removeRowGrps(' + RowIndex1 + ',\'Are you sure you want to delete this group?\')"  style="float:right;">';

            FrecRow += '<i class="fa fa-close" style="font-size:21px"></i></div> <i style="float: left;margin-top: 1%;width: 9%;" class="fa fa-object-group" aria-hidden="true">Group Name</i>';

            FrecRow += '<input style="float: left;width: 25%;" type="text" onkeypress="return DisableEnter(event);" onkeydown="textCounter(inpGrpName_' + RowIndex1 +' ,200)" onkeyup="textCounter(inpGrpName_' + RowIndex1 + ',200)" onblur="return CheckDuplicationGrp(' + RowIndex1 + ');" class="form-control" id="inpGrpName_' + RowIndex1 + '" name="inpGrpName_' + RowIndex1 + '" placeholder="GROUP NAME"><button id="btnGrpAdd' + RowIndex1 + '" onclick="return FuctionAddGroup(\'' + RowIndex1 + '\')" class="btn green" style="border-radius:0px;float:right;">';
            FrecRow += '<i class="fa fa-plus" style="margin-right:10px;"></i>Create New Group</button></div><div style="clear:both"></div><hr />';





            FrecRow += '<div id="DivGroupQstn_' + RowIndex1 + '">';

            FrecRow += '<table style="width:100%" id="TableQstn_' + RowIndex1 + '">';





            FrecRow += '</table></div></div  </div></td> ';

            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control" value="INS" style="display:none;"  id="tdEvtGrp' + RowIndex1 + '" name="tdEvtGrp' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdTempid' + RowIndex1 + '" name="tdDtlIdTempid' + RowIndex1 + '" placeholder=""/><input type="text" class="form-control"  style="display:none;"  id="tdDtlIdGrp' + RowIndex1 + '" name="tdDtlIdGrp' + RowIndex1 + '" placeholder=""/></td>';
            FrecRow += '<td  style="width:0%;display: none;"><input type="text" class="form-control"  style="display:none;"  id="tdInxGrp' + RowIndex1 + '" name="tdInxGrp' + RowIndex1 + '" placeholder=""/> </td></tr>';
            //  var generateHere = document.getElementById("DivGroup");
            // generateHere.insertBefore(FrecRow, generateHere.lastChild);
            //  generateHere.innerHTML = generateHere.innerHTML + FrecRow;

            jQuery('#tableGrp').append(FrecRow);
            //  alert("s");
            //  $noConn('#tableGrp').append(FrecRow);
            FunctionQustn(RowIndex1, rowSubCatagory);



            return false;

        }



        var currntx = "";
        var currnty = "";
        function FunctionQustn(x, y) {
            // alert();
            y++;
            var FrecRowQst = '';

            FrecRowQst += '<tr id="SubQstnRowId_' + x + '' + y + '" ><td   id="tdidQstnDtls' + x + '' + y + '" style="display: none" >' + x + '' + y + '</td>';
            FrecRowQst += '<td   id="tdvalidate' + x + '' + y + '" style="display: none" >' + x + '</td>';
            FrecRowQst += '<td   id="tdvalidatey' + x + '' + y + '" style="display: none" >' + y + '</td><td>';
            FrecRowQst += '<div class="col-md-12" id="boxhide" style="height:auto;background-color:#eaeaea;padding:10px;overflow: auto;border:#766c7a;border:.5px solid"><div class="col-lg-12" style="padding:0px;">';

            FrecRowQst += '<div title="DELETE" class="btn" onclick="return removeRowQstn(' + x + ',' + y + ',' + x + '' + y + ',\'Are you sure you want to delete this question?\')" style="float:right;"><i class="fa fa-close" style="font-size:21px"></i></div> </div>';
            FrecRowQst += '<div class="form-row">  <div class="form-group col-md-6 padding5"> <label style="margin-bottom:8px;"><i class="fa fa-tasks" aria-hidden="true"></i>   Question <span class="red">*</span>  </label>';

            FrecRowQst += ' <input type="text"  onkeypress="return DisableEnter(event);" onkeydown="textCounter(txtQstn_' + x + '' + y + ',900)" onkeyup="textCounter(txtQstn_' + x + '' + y + ',900)" onblur="return Funistagkpi(\'txtQstn_' + x + '' + y + '\');" class="form-control" id="txtQstn_' + x + '' + y + '" name="txtQstn_' + x + '' + y + '" placeholder=""> </div> <div class="form-group col-md-3 padding5">  <label for="inputState" style="margin-bottom:8px;">Answer Type</label>';
            FrecRowQst += '  <select   onkeydown="return DisableEnter(event);" onchange="return ChangeddlRate(\'' + x + '\',\'' + y + '\');" id="ddlRate_' + x + '' + y + '" class="form-control">  <option value="0">Text Box</option>  <option value="1">Rating </option><option value="2">Check Box </option></select><input type="text" class="form-control" style="display:none;" value="0" id="txtddlValue_' + x + '' + y + '" name="txtddlValue_' + x + '' + y + '" placeholder=""/></div></div>';

            FrecRowQst += '<div class="form-row"> <div class="form-group col-md-8 padding5"> <label for="inputCity" style="margin-bottom:8px;">KPI (Key Performance Indicator)</label><input type="text"  onkeypress="return DisableEnter(event);"  onkeydown="textCounter(txtkpi_' + x + '' + y + ',200)" onkeyup="textCounter(txtkpi_' + x + '' + y + ',200)"  onblur="return Funistagkpi(\'txtkpi_' + x + '' + y + '\');" class="form-control" id="txtkpi_' + x + '' + y + '" name="txtkpi_' + x + '' + y + '" placeholder=""> ';

            FrecRowQst += '</div></div>';

            FrecRowQst += '<div style="clear:both"></div><br /> <div  style="padding:4px;float:right;">   <button id="btnAddQstn_' + x + '' + y + '" class="btn green btn-width" onclick="return CheckaddMoreRowsQstn(\'' + x + '\',\'' + y + '\');" style="border-radius:0px;"> <i class="fa fa-plus" style="margin-right:10px;"></i>Next Question  </button>  ';
            FrecRowQst += '<a > <button  data-toggle="modal" data-target=".bs-example-modal-lg" id="btnImportQstn_' + x + '' + y + '" onclick="return CheckImportMoreRowsQstn(\'' + x + '\',\'' + y + '\');" class="btn btn-primary btn-width" style="border-radius:0px;margin-right:11px;"><i class="fa fa-clipboard" style="margin-right:10px;"></i>Import questions from existing template</button>';
            FrecRowQst += '</a> </div></td>';

            //var generateHereQst = document.getElementById("DivGroupQstn_" + x );
            // generateHereQst.innerHTML = generateHereQst.innerHTML + FrecRowQst;

            FrecRowQst += '<td   style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;" value="INS" id="tdEvtQstn' + x + '' + y + '" name="tdEvtQstn' + x + '' + y + '" placeholder=""/></td>';
            FrecRowQst += '<td style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdDtlIdQstn' + x + '' + y + '" name="tdDtlIdQstn' + x + '' + y + '" placeholder=""/></td>';
            FrecRowQst += '<td  style="width:0%;display: none;"><input type="text" class="form-control" style="display:none;"  id="tdInxQstn' + x + '' + y + '" name="tdInxQstn' + x + '' + y + '" placeholder=""/> </td></tr>';
            jQuery('#TableQstn_' + x).append(FrecRowQst);
            currntx = x;
            currnty = y;
            return false;

        }



        function Funistagkpi(x)
        {
            IncrmntConfrmCounter();
            RemoveTag(x);
            return false;
        }
        function EditListRows(TempId, GrpName, GrpId, Qstnid, QstnName, Api, Ratescaleid) {
            if (GrpName != "") {
                AddNewGroup();
                document.getElementById("inpGrpName_" + currntx).value = GrpName;
                document.getElementById("tdEvtGrp" + currntx).value = "UPD";
                document.getElementById("tdDtlIdGrp" + currntx).value = GrpId;

                document.getElementById("tdInxGrp" + currntx).value = currntx;
                document.getElementById("btnGrpAdd" + currntx).style.opacity = "0.3";
                document.getElementById("tdDtlIdTempid" + currntx).value = TempId;

               
                


            }
            else {
                FunctionQustn(currntx, currnty);
            }
            document.getElementById("txtQstn_" + currntx + '' + currnty).value = QstnName;
            document.getElementById("ddlRate_" + currntx + '' + currnty).value = Ratescaleid;
            document.getElementById("txtddlValue_" + currntx + '' + currnty).value = Ratescaleid;

            document.getElementById("txtkpi_" + currntx + '' + currnty).value = Api;
            document.getElementById("tdEvtQstn" + currntx + '' + currnty).value = "UPD";
            document.getElementById("tdDtlIdQstn" + currntx + '' + currnty).value = Qstnid;

            document.getElementById("tdInxQstn" + currntx + '' + currnty).value = currntx + '' + currnty;
            document.getElementById("btnAddQstn_" + currntx + '' + currnty).style.opacity = "0.3";

            //btnaddqstn
            document.getElementById("btnImportQstn_" + currntx + '' + currnty).style.opacity = "0.3";
            document.getElementById("btnImportQstn_" + currntx + '' + currnty).disabled = true;
            
        }

        function ChangeddlRate(x, y) {
            IncrmntConfrmCounter();
            var ddratechg = document.getElementById("ddlRate_" + x + '' + y).value;

            document.getElementById("txtddlValue_" + x + '' + y).value = ddratechg;

            return false;
        }

        function CheckDuplicationGrp(x) {
            IncrmntConfrmCounter();
         
            var varGrpName = document.getElementById("inpGrpName_" + x).value.trim();
          
            var replaceText1 = varGrpName.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("inpGrpName_" + x).value = replaceText2;
            if (varGrpName != "") {
                document.getElementById("inpGrpName_" + x).style.borderColor = "";
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                var orgid = '<%= Session["ORGID"] %>';
                var userid = '<%= Session["USERID"] %>';
                var GrpDtlid = "-1";
                var TempDtlid = "";
                if (TempDtlid = document.getElementById("<%=HiddenConductId.ClientID%>").value != "") {
                    if (document.getElementById("tdEvtGrp" + x).value == "UPD") {

                        GrpDtlid = document.getElementById("tdDtlIdGrp" + x).value;


                    }
                    TempDtlid = document.getElementById("<%=HiddenConductId.ClientID%>").value;
                    //  var per

                    $noCon.ajax({
                        type: "POST",
                        url: "Employee_Performance_Templt.aspx/DupChkForGrpName",
                        data: '{intGrpid:"' + GrpDtlid + '",intTempid:"' + TempDtlid + '",intGrpname:"' + varGrpName + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" }',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {


                            if (response.d == "false") {
                                document.getElementById("inpGrpName_" + x).value = "";
                                document.getElementById("inpGrpName_" + x).style.borderColor = "Red";
                              

                                $noCon(window).scrollTop(0);
                                $noCon("#divWarning").html("Group name cannot be duplicated.");
                                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                    document.getElementById("inpGrpName_" + x).focus();
                                   
                                });

                                $noCon("#divWarning").alert();
                            }






                        },
                        failure: function (response) {

                        }


                    });
                }

                var table = document.getElementById('tableGrp');
                // alert(table.rows.length);
                for (var i = 0; i < table.rows.length; i++) {
                    if (i != table.rows.length) {
                        // FIX THIS
                        var row = table.rows[i];

                        var xLoop = (table.rows[i].cells[0].innerHTML);

                        if (CheckGrpNameDupl(xLoop, x) == false) {
                            return false;
                        }


                    }
                }
            }

            return false;
        }
        function CheckGrpNameDupl(xLoop, x) {
            if (xLoop != x) {
                var GrpNameName = document.getElementById("inpGrpName_" + x).value.trim();
              
                var GrpNamedup = document.getElementById("inpGrpName_" + xLoop).value.trim();
             

                if (GrpNameName == GrpNamedup) {


                    document.getElementById("inpGrpName_" + x).style.borderColor = "Red";
                    document.getElementById("inpGrpName_" + x).value = "";
                  

                    $noCon(window).scrollTop(0);
                    $noCon("#divWarning").html("Group name cannot be duplicated.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        document.getElementById("inpGrpName_" + x).focus();

                    });

                    $noCon("#divWarning").alert();

                    return false;
                    //alert('entaaer');
                }
             
            }
            return true;
        }

        function FuctionAddGroup(Grpx) {
            IncrmntConfrmCounter();
            var addRowtableGrp;
            var addRowResultGrp = true;
            var check = document.getElementById("tdInxGrp" + Grpx).value;
          
            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (check == "") {
                //  addRowtableGrp = document.getElementById("TableQstn_" + Grpx);

                addRowtableGrp = document.getElementById("TableQstn_" + Grpx);

                for (var i = 0; i < addRowtableGrp.rows.length; i++) {

                    var row = addRowtableGrp.rows[i];
                    var xLoop = (addRowtableGrp.rows[i].cells[0].innerHTML);

                    if (CheckAndHighlightQstn(xLoop, 0) == false) {
                        addRowResultGrp = false;
                    }
                }
                var groupname = document.getElementById("inpGrpName_" + Grpx).value;
                document.getElementById("inpGrpName_" + Grpx).style.borderColor = "";
                if (groupname == "") {
                    // document.getElementById("inpGrpName_" + Grpx).style.borderColor = "";
                    document.getElementById("inpGrpName_" + Grpx).style.borderColor = "Red";
                }

                if (addRowResultGrp == false || groupname == "") {

                    return false;
                }

                else {

                    //  alert();
                    document.getElementById("tdInxGrp" + Grpx).value = Grpx;
                    document.getElementById("btnGrpAdd" + Grpx).style.opacity = "0.3";


                    AddNewGroup();
                    document.getElementById("inpGrpName_" + currntx).focus();
                    return false;
                }
            }
            return false;

        }





        function CheckaddMoreRowsQstn(x, y) {
            IncrmntConfrmCounter();
            var addRowtable;
            var addRowResult = true;
            var check = document.getElementById("tdInxQstn" + x + '' + y).value;

            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (check == "") {
                addRowtable = document.getElementById("TableQstn_" + x);

                for (var i = 0; i < addRowtable.rows.length; i++) {

                    var row = addRowtable.rows[i];
                    var xLoop = (addRowtable.rows[i].cells[0].innerHTML);

                    if (CheckAndHighlightQstn(xLoop, 0) == false) {
                        addRowResult = false;
                    }
                }
                if (addRowResult == false) {

                    return false;
                }
                else {


                    document.getElementById("tdInxQstn" + x + '' + y).value = x + '' + y;
                    document.getElementById("btnAddQstn_" + x + '' + y).style.opacity = "0.3";
                    //btnaddqstn
                    document.getElementById("btnImportQstn_" + x + '' + y).style.opacity = "0.3";
                    document.getElementById("btnImportQstn_" + x + '' + y).disabled = true;

                    FunctionQustn(x, y);
                   
                     document.getElementById("txtQstn_" + currntx + '' + currnty).focus();
                    return false;
                }
            }
            return false;

        }

        // checks every field in row
        function CheckAndHighlightQstn(x, FirstRow) {
            var CheckAndHighlightRet = true;


            document.getElementById("txtQstn_" + x).style.borderColor = "";
            //  document.getElementById("ddlRate_" + x).style.borderColor = "";



            var txtSubCatName = document.getElementById("txtQstn_" + x).value.trim();
            // var txtSubCatSize = document.getElementById("ddlRate_" + x).value;





            if (txtSubCatName == "") {
                document.getElementById("txtQstn_" + x).style.borderColor = "Red";
                // document.getElementById("txtDateTo" + x).focus();
                CheckAndHighlightRet = false;
            }




            return CheckAndHighlightRet;
        }



        function removeRowQstn(Rowid, y, removeNum, CofirmMsg) {
            IncrmntConfrmCounter();
           
            if (document.getElementById("cphMain_HiddenFieldView").value!="1")
                {
            //alert(removeNum);
            if (confirm(CofirmMsg)) {
                var evt = document.getElementById("tdEvtQstn" + removeNum).value;

                if (evt == 'UPD') {
                    var detailId = document.getElementById("tdDtlIdQstn" + removeNum).value;

                    var CanclIds = document.getElementById("cphMain_hiddenQstnCanclDtlId").value;
                    if (CanclIds == '') {
                        document.getElementById("cphMain_hiddenQstnCanclDtlId").value = detailId;
                    }
                    else {
                        document.getElementById("cphMain_hiddenQstnCanclDtlId").value = document.getElementById("cphMain_hiddenQstnCanclDtlId").value + ',' + detailId;
                    }
                }

                var row_index = jQuery('#TarffRowId_' + removeNum).index();


                //  RowIndexTarff--;

                //    var BforeRmvTableRowCount = document.getElementById("TableQstn_").rows.length;


                jQuery('#SubQstnRowId_' + removeNum).remove();

                var TableRowCount = document.getElementById("TableQstn_" + Rowid).rows.length;

                if (TableRowCount != 0) {
                    var idlast = $noCon('#TableQstn_' + Rowid + ' tr:last').attr('id');

                    if (idlast != "") {

                        var res = idlast.split("_");
                        //  alert(res[1]);
                        document.getElementById("tdInxQstn" + res[1]).value = "";
                        document.getElementById("btnAddQstn_" + res[1]).style.opacity = "1";
                        //btnaddqstn
                        document.getElementById("btnImportQstn_" + res[1]).style.opacity = "1";
                        document.getElementById("btnImportQstn_" + res[1]).disabled = false;
                    }
                }
                else {

                    FunctionQustn(Rowid, y);
                }



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

     

            
        function removeRowGrps(removeNum, CofirmMsg) {
            IncrmntConfrmCounter();
            //alert(removeNum);
            if (document.getElementById("cphMain_HiddenFieldView").value != "1") {
                if (confirm(CofirmMsg)) {
                    var evt = document.getElementById("tdEvtGrp" + removeNum).value;

                    if (evt == 'UPD') {
                        var detailId = document.getElementById("tdDtlIdGrp" + removeNum).value;
                        var CanclIds = document.getElementById("cphMain_hiddenGrpCanclDtlId").value;
                        if (CanclIds == '') {
                            document.getElementById("cphMain_hiddenGrpCanclDtlId").value = detailId;
                        }
                        else {
                            document.getElementById("cphMain_hiddenGrpCanclDtlId").value = document.getElementById("cphMain_hiddenGrpCanclDtlId").value + ',' + detailId;
                        }
                    }
                    //    var row_index = jQuery('#SubGrpRowId_' + removeNum).index();


                    //  RowIndexTarff--;

                    //    var BforeRmvTableRowCount = document.getElementById("TableQstn_").rows.length;


                    jQuery('#SubGrpRowId_' + removeNum).remove();

                    var TableRowCount = document.getElementById("tableGrp").rows.length;

                    if (TableRowCount != 0) {
                        var idlast = $noCon('#tableGrp >tbody > tr:not(:has(>td>table)):last').attr('id');

                        if (idlast != "") {

                            var res = idlast.split("_");

                            document.getElementById("tdInxGrp" + res[1]).value = "";
                            document.getElementById("btnGrpAdd" + res[1]).style.opacity = "1";
                        }
                    }
                    else {

                        AddNewGroup();
                    }



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
        function validateTable(retchk) {
            var Result = true;
                var Tvalidate = true;
                var TvalidateInnertable = true;
                var tFocus = "";
                var tFocusinnertable = "";
                var tFocusinnertableNxt = "";
                var Tvalidate = true;
                addRowtable = document.getElementById("tableGrp");

                for (var i = 0; i < addRowtable.rows.length; i++) {
                    //  if (i != addRowtable.rows.length - 1) {
                    var row = addRowtable.rows[i];
                    var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                   
                    //To check group name
                    var groupname = document.getElementById("inpGrpName_" + xLoop).value;
                    document.getElementById("inpGrpName_" + xLoop).style.borderColor = "";
                    if (groupname == "") {
                        Tvalidate = false;
                        if (tFocus == "")
                            tFocus = xLoop;
                        document.getElementById("inpGrpName_" + xLoop).style.borderColor = "Red";
                    }


                    addRowtableIn = document.getElementById("TableQstn_" + xLoop);

                    for (var ii = 0; ii < addRowtableIn.rows.length; ii++) {
                        //  if (i != addRowtable.rows.length - 1) {
                        var rowin = addRowtableIn.rows[ii];
                        var xLoopin = (addRowtableIn.rows[ii].cells[0].innerHTML);
                        var xLoopinnxt = (addRowtableIn.rows[ii].cells[1].innerHTML);



                        if (!(CheckAndHighlightQstnValidate(xLoopin, groupname))) {
                            if (tFocusinnertable == "") {
                                tFocusinnertable = xLoopin;
                                tFocusinnertableNxt = xLoopinnxt;
                            }
                            //if (groupname == "") {
                            //    if (!(CheckQstnValidateNull(xLoopin)))
                            //    {
                            //        if (addRowtable.rows.length!=1 && )
                            //        tFocusinnertable = "";
                            //        tFocusinnertableNxt = "";
                            //        tFocus = "";
                            //        document.getElementById("inpGrpName_" + xLoop).style.borderColor = "";
                            //    }

                            //}
                            
                        }


                        // alert(xLoopin+"in");
                        // }
                    }



                    // }
                }
                if (retchk == true) {
                    if (tFocus != "" && tFocusinnertable != "") {

                        if (tFocus <= tFocusinnertableNxt) {
                            Result = false;
                            document.getElementById("inpGrpName_" + tFocus).focus();
                        }
                        else {
                            Result = false;
                            document.getElementById("txtQstn_" + tFocusinnertable).focus();
                        }

                    }
                    else {

                        if (tFocus != "") {
                            document.getElementById("inpGrpName_" + tFocus).focus();
                            Result = false;
                        }
                        if (tFocusinnertable != "") {
                            document.getElementById("txtQstn_" + tFocusinnertable).focus();
                            Result = false;
                        }

                    }
                }


                if (Result == false) {
                    $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

                    });
                    $noCon("#divWarning").alert();
                    $noCon1(window).scrollTop(0);
                }
            
               // if (ret == true) {
                    var tbClientTotalValues = '';
                    tbClientTotalValues = [];
                   

                    addRowtable = document.getElementById("tableGrp");

                    for (var i = 0; i < addRowtable.rows.length; i++) {


                        var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                        var xLoopin = "";

                        addRowtableIn = document.getElementById("TableQstn_" + xLoop);

                        for (var ii = 0; ii < addRowtableIn.rows.length; ii++) {
                            //  if (i != addRowtable.rows.length - 1) {
                            var rowin = addRowtableIn.rows[ii];
                            if (xLoopin=="")
                                xLoopin = (addRowtableIn.rows[ii].cells[0].innerHTML);
                            else
                                xLoopin = xLoopin+","+(addRowtableIn.rows[ii].cells[0].innerHTML);
                        }


                        var $add = jQuery.noConflict();
                       // if (Name != "") {
                            var client = JSON.stringify({

                                GROUPNUM: "" + xLoop + "",
                                QUSTNNUM: "" + xLoopin + "",


                            });
                            tbClientTotalValues.push(client);
                      //  }
                    }

                    document.getElementById("<%=HiddenFieldSaveTemplate.ClientID%>").value = JSON.stringify(tbClientTotalValues);
                  //  alert(document.getElementById("<%=HiddenFieldSaveTemplate.ClientID%>").value);

               // }

          //  alert(Result);

            return Result;
            }

        function CheckAndHighlightQstnValidate(FirstRow, groupname) {
                var CheckAndHighlightRet = true;


                document.getElementById("txtQstn_" + FirstRow).style.borderColor = "";
                //  document.getElementById("ddlRate_" + x).style.borderColor = "";



                var txtSubCatName = document.getElementById("txtQstn_" + FirstRow).value.trim();
                var txtSubKpi = document.getElementById("txtkpi_" + FirstRow).value.trim();

                var txtSubRate = document.getElementById("ddlRate_" + FirstRow).value;
             

                if (groupname == "") {
                    if (txtSubCatName == "") {
                        if (txtSubKpi != "" && txtSubRate == 1) {
                            document.getElementById("txtQstn_" + FirstRow).style.borderColor = "Red";
                            // document.getElementById("txtDateTo" + x).focus();
                            CheckAndHighlightRet = false;
                        }
                    }
                }
                else {
                    if (txtSubCatName == "") {
                     
                            document.getElementById("txtQstn_" + FirstRow).style.borderColor = "Red";
                            // document.getElementById("txtDateTo" + x).focus();
                            CheckAndHighlightRet = false;
                        
                    }

                }




                return CheckAndHighlightRet;
        }


        function CheckQstnValidateNull(FirstRow) {
            var CheckAndHighlightRet = true;

            var txtSubCatName = document.getElementById("txtQstn_" + FirstRow).value.trim();
            var txtSubKpi = document.getElementById("txtkpi_" + FirstRow).value.trim();

            var txtSubRate = document.getElementById("ddlRate_" + FirstRow).value;
      
                if (txtSubCatName != "") {
                    CheckAndHighlightRet = false;
                }
                  
                //if (txtSubKpi != "" || txtSubRate == 1) {

                //    CheckAndHighlightRet = false;
                //}

              return CheckAndHighlightRet;
        }
        
       </script>

    
       <script>
           
           function LoadQstions()
           {
               IncrmntConfrmCounter();
               var PerTempId = document.getElementById("<%=ddlPerfForm.ClientID%>").value;
          
               $("#TableSelectQstn").empty();
               $("#TableAddQstn").empty();
               //document.getElementById("<%=ddlPerfForm.ClientID%>").value = "--SELECT PERFORMANCE TEMPLATE--";
              
               if (PerTempId != "--SELECT PERFORMANCE TEMPLATE--") {

                   if (document.getElementById("CopyPopupText").innerHTML == "Import Questions") {
                       document.getElementById("bttnfill").style.display = "block";
                       document.getElementById("bttnRemovetabQstn").style.display = "block";
                   }
                   else {
                       document.getElementById("bttnfillGrp").style.display = "block";
                       document.getElementById("bttnRemovetab").style.display = "block";
                   }

                   var corpid = '<%= Session["CORPOFFICEID"] %>';
                   var orgid = '<%= Session["ORGID"] %>';
                   var userid = '<%= Session["USERID"] %>';
                   //  var per

                   $noCon.ajax({
                       type: "POST",
                       url: "Employee_Performance_Templt.aspx/LoadGroupsAndQstns",
                       data: '{intPertempid:"' + PerTempId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" }',
                       contentType: "application/json; charset=utf-8",
                       dataType: "json",
                       success: function (response) {


                           document.getElementById("DivCopyQstn").innerHTML = response.d[0];

                           document.getElementById("DivCopyGrp").innerHTML = response.d[1];




                       },
                       failure: function (response) {

                       }


                   });
               }
               else {
                   document.getElementById("bttnfillGrp").style.display = "none";
                   document.getElementById("bttnfill").style.display = "none";
               }

           }

           $('#bttnQstnAdd').click(function () {
               $('#TableGrp').find('tr').each(function () {
                   var row = $(this);
                   if (row.find('input[type="checkbox"]').is(':checked')) {

                       var rowid = row.find('input[type="checkbox"]').val();

                       row.find('input[type="checkbox"]').prop('checked', false);

                       var tdtext = row.find('#tdGrpnameCpy' + rowid).html();
                       //var tdRate = row.find('#tdRatgCpy' + rowid).html();
                       //var tdKpi = row.find('#tdKpiCpy' + rowid).html();

                      // alert(tdtext + "  " + tdRate + "  " + tdKpi);
                     
                       //  alert(row.find('#tdUsrName' + rowid).html());

                       row.css('display', 'none');
                       var AddRow = "";
                       AddRow = '<tr class="list-group-item" id="SelectRowRemove' + rowid + '" >';
                       AddRow += '<td class="smart-form" style=" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;" > <label class="checkbox " ><input type="checkbox" value="' + rowid + '" id="cbMandatoryRem' + rowid + '"><i  style="margin-top:-15%;"></i></label></td>';
                       AddRow += '  <td value="0" class="smart-form" id="tdUsrNameRem' + rowid + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;">' + tdtext + '</td>';
                       //AddRow += '  <td value="1" class="smart-form" id="tdRatgRem' + rowid + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;">' + tdRate + '</td>';
                       //AddRow += '  <td value="2" class="smart-form" id="tdKpiRem' + rowid + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;">' + tdKpi + '</td>';
                       AddRow += ' </tr>';
                       //  $('#TableSelectQstn tr:last').after(AddRow);
                       jQuery('#TableSelectQstn').append(AddRow);
                   }
               });
               return false;
           });


           $('#bttnQstnAdd').click(function () {
               $('#TableAddQstn').find('tr').each(function () {
                   var row = $(this);
                   if (row.find('input[type="checkbox"]').is(':checked') )
                   {
                   
                       var rowid=row.find('input[type="checkbox"]').val();

                       row.find('input[type="checkbox"]').prop('checked', false);

                       var tdtext = row.find('#tdUsrName' + rowid).html();
                       var tdRate = row.find('#tdRatg' + rowid).html();
                       var tdKpi = row.find('#tdKpi' + rowid).html();

                       //  alert(row.find('#tdUsrName' + rowid).html());

                       row.css('display', 'none');
                       var AddRow = "";
                       AddRow = '<tr class="list-group-item" id="SelectRowRemove' + rowid + '" >';
                       AddRow += '<td class="smart-form" style=" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;" > <label class="checkbox " ><input type="checkbox" value="' + rowid + '" id="cbMandatoryRem' + rowid + '"><i  style="margin-top:-15%;"></i></label></td>';
                       AddRow += '  <td class="smart-form" id="tdUsrNameRem' + rowid + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;">' + tdtext + '</td>';
                       AddRow += '  <td class="smart-form" id="tdRatgRem' + rowid + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;">' + tdRate + '</td>';
                       AddRow += '  <td class="smart-form" id="tdKpiRem' + rowid + '" style="width:15%;word-break: break-all; word-wrap:break-word;text-align: left;display:none;">' + tdKpi + '</td>';
                       AddRow += ' </tr>';
                     //  $('#TableSelectQstn tr:last').after(AddRow);
                       jQuery('#TableSelectQstn').append(AddRow);
                   }
               });
               return false;
           });



           $('#bttnRemovetab').click(function () {
               $('#TableSelectQstn').find('tr').each(function () {
                   var row = $(this);
                   if (row.find('input[type="checkbox"]').is(':checked')) {
                    
                       var rowid = row.find('input[type="checkbox"]').val();

                       row.find('input[type="checkbox"]').prop('checked', false);

                       var tdtext = row.find('#tdUsrName' + rowid).html();

                       //  alert(row.find('#tdUsrName' + rowid).html());
                       jQuery('#SelectRowRemove' + rowid).remove();
                     
                       jQuery('#SelectRowGrp' + rowid).css('display', 'block');
                    
                   }
               });
               return false;
           });
           $('#bttnRemovetabQstn').click(function () {
               $('#TableSelectQstn').find('tr').each(function () {
                   var row = $(this);
                   if (row.find('input[type="checkbox"]').is(':checked')) {

                       var rowid = row.find('input[type="checkbox"]').val();

                       row.find('input[type="checkbox"]').prop('checked', false);

                       var tdtext = row.find('#tdUsrName' + rowid).html();

                       //  alert(row.find('#tdUsrName' + rowid).html());
                       jQuery('#SelectRowRemove' + rowid).remove();
                      

                       jQuery('#SelectRow' + rowid).css('display', 'block');

                   }
               });
               return false;
           });
           var varRowidx = "";
           var varRowidy = "";
           function CheckImportMoreRowsQstn(x,y)
           {
               document.getElementById("CopyPopupText").innerHTML = "Import Questions";
               IncrmntConfrmCounter();
               varRowidx = x;
               varRowidy = y;
               $("#TableSelectQstn").empty();
               $("#TableAddQstn").empty();
               document.getElementById("DivCopyGrp").style.display = "none";
               document.getElementById("ligrp").style.display = "none";

               document.getElementById("bttnfillGrp").style.display = "none";
               document.getElementById("bttnfill").style.display = "none";


               document.getElementById("bttnRemovetab").style.display = "none";
               document.getElementById("bttnRemovetabQstn").style.display = "none";

               document.getElementById("DivCopyQstn").style.display = "block";
               document.getElementById("liQstn").style.display = "block";

               document.getElementById("<%=ddlPerfForm.ClientID%>").value = "--SELECT PERFORMANCE TEMPLATE--";
               setTimeout(function () { focusddlPerfForm() }, 1000);
              
               document.getElementById("<%=ddlPerfForm.ClientID%>").focus();

                             return false;
           }
         
           function focusddlPerfForm() {
              
                document.getElementById("<%=ddlPerfForm.ClientID%>").focus();
              
           }
           function OpenGroupcopy()
           {
               IncrmntConfrmCounter();
               
               document.getElementById("CopyPopupText").innerHTML = "Import Groups";
              // varRowidx = x;
              // varRowidy = y;
               $("#TableGrp").empty();
               $("#TableSelectQstn").empty();

               document.getElementById("bttnfillGrp").style.display = "none";
               document.getElementById("bttnfill").style.display = "none";

               document.getElementById("bttnRemovetab").style.display = "none";
               document.getElementById("bttnRemovetabQstn").style.display = "none";

               document.getElementById("DivCopyGrp").style.display = "block";
               document.getElementById("ligrp").style.display = "block";

               document.getElementById("DivCopyQstn").style.display = "none";
               document.getElementById("liQstn").style.display = "none";


               document.getElementById("<%=ddlPerfForm.ClientID%>").value = "--SELECT PERFORMANCE TEMPLATE--";
              setTimeout(function () { focusddlPerfForm() }, 1000);
               
              
               return false;
           }

           function ButtnFillClick() {


               var rowCount = $('#TableSelectQstn tr').length;

               if (rowCount != 0) {
                   ezBSAlert({
                       type: "confirm",
                       messageText: "Empty group/question will be replace with the imported groups/questions.Are you sure you want to continue?",
                       alertType: "info"
                   }).done(function (e) {
                       if (e == true) {
                          
                           $noCon1('#myModelgrp').modal('hide');
                           //evm-0027
                           $noCon1('.modal-backdrop').hide();
                           //end
                           ButtnFillQstn();
                       }

                       else {
                           // window.location.href = "hcm_Emp_Conduct_Incident_List.aspx";
                           return false;
                       }
                   });
               }

         
               return false;
           }
           //evm-0027
           function keyPressHandler(e) {

               var kC = (window.event) ?    // MSIE or Firefox?
                event.keyCode : e.keyCode;
               var Esc = (window.event) ?

                         27 : e.DOM_VK_ESCAPE // MSIE : Firefox
               if (kC == Esc) {
                  
                   $noCon1('#myModelgrp').modal('hide');

                   $noCon1('.modal-backdrop').hide();
               }
               

           }
           //end
           function ButtnFillClickGrp() {
               var rowCount = $('#TableSelectQstn tr').length;
            
               if (rowCount != 0) {
                   ezBSAlert({
                       type: "confirm",
                       messageText: "Empty group/question will be replace with the imported groups/questions.Are you sure you want to continue?",
                       alertType: "info"
                   }).done(function (e) {
                       if (e == true) {

                           $noCon1('#myModelgrp').modal('hide');
                           //evm-0027
                           $noCon1('.modal-backdrop').hide();
                           //end
                           ButtnFillClickGrp1();
                       }
                    
                       else {
                           // window.location.href = "hcm_Emp_Conduct_Incident_List.aspx";
                           return false;
                       }
                   });
               }
               return false;
           }




           function ButtnFillQstn()
           {
               $('#TableSelectQstn').find('tr').each(function () {
                   var row = $(this);
                   //  if (row.find('input[type="checkbox"]').is(':checked')) {

                   var rowid = row.find('input[type="checkbox"]').val();

                   row.find('input[type="checkbox"]').prop('checked', false);

                   var tdtext = row.find('#tdUsrNameRem' + rowid).html();
                   var tdRate = row.find('#tdRatgRem' + rowid).html();
                   var tdKpi = row.find('#tdKpiRem' + rowid).html();
             

                   //  alert(row.find('#tdUsrName' + rowid).html());
                   //jQuery('#SelectRowRemove' + rowid).remove();
                   //  alert(varRowidx+""+ varRowidy);
                   document.getElementById("tdInxQstn" + varRowidx + '' + varRowidy).value = currntx + '' + currnty;
                   document.getElementById("btnAddQstn_" + varRowidx + '' + varRowidy).style.opacity = "0.3";

                   //btnaddqstn
                   document.getElementById("btnImportQstn_" + varRowidx + '' + varRowidy).style.opacity = "0.3";
                   document.getElementById("btnImportQstn_" + varRowidx + '' + varRowidy).disabled = true;
                   FunctionQustn(varRowidx, varRowidy);
                   varRowidy++;
                   document.getElementById("txtQstn_" + varRowidx + '' + varRowidy).value = tdtext;
                   document.getElementById("ddlRate_" + varRowidx + '' + varRowidy).value = tdRate;
                   document.getElementById("txtddlValue_" + varRowidx + '' + varRowidy).value = tdRate;
                   document.getElementById("txtkpi_" + varRowidx + '' + varRowidy).value = tdKpi;
                   
                   //document.getElementById("txtQstn_" + varRowidx + '' + varRowidy).value = tdKpi;

                   //}
               });

              
               addRowtableIn = document.getElementById("TableQstn_" + varRowidx);

               for (var ii = 0; ii < addRowtableIn.rows.length; ii++) {

                   var QstnCheck = 0;
                   //  if (i != addRowtable.rows.length - 1) {
                   var rowin = addRowtableIn.rows[ii];
                   var xLoopin = (addRowtableIn.rows[ii].cells[0].innerHTML);
                   var xLoopinnxt = (addRowtableIn.rows[ii].cells[1].innerHTML);
                   var xLoopinnxty = (addRowtableIn.rows[ii].cells[2].innerHTML);

                   

                       if (!(CheckQstnValidateNull(xLoopin))) {
                        
                               QstnCheck = 1;

                       }
                       if (QstnCheck != 1)
                       {
                           RemoveQstnOnImport(xLoopin, xLoopinnxt, xLoopinnxty);
                       }
               

               }
         
               return false;
           }
           function RemoveQstnOnImport(removeNum, Rowid, y) {
               var evt = document.getElementById("tdEvtQstn" + removeNum).value;

               if (evt == 'UPD') {
                   var detailId = document.getElementById("tdDtlIdQstn" + removeNum).value;

                   var CanclIds = document.getElementById("cphMain_hiddenQstnCanclDtlId").value;
                   if (CanclIds == '') {
                       document.getElementById("cphMain_hiddenQstnCanclDtlId").value = detailId;
                   }
                   else {
                       document.getElementById("cphMain_hiddenQstnCanclDtlId").value = document.getElementById("cphMain_hiddenQstnCanclDtlId").value + ',' + detailId;
                   }
               }

               var row_index = jQuery('#TarffRowId_' + removeNum).index();


               //  RowIndexTarff--;

               //    var BforeRmvTableRowCount = document.getElementById("TableQstn_").rows.length;


               jQuery('#SubQstnRowId_' + removeNum).remove();

               var TableRowCount = document.getElementById("TableQstn_" + Rowid).rows.length;

               if (TableRowCount != 0) {
                   var idlast = $noCon('#TableQstn_' + Rowid + ' tr:last').attr('id');

                   if (idlast != "") {

                       var res = idlast.split("_");
                       //  alert(res[1]);
                       document.getElementById("tdInxQstn" + res[1]).value = "";
                       document.getElementById("btnAddQstn_" + res[1]).style.opacity = "1";
                       //btnaddqstn
                       document.getElementById("btnImportQstn_" + res[1]).style.opacity = "1";
                       document.getElementById("btnImportQstn_" + res[1]).disabled = false;
                   }
               }
               else {

                   FunctionQustn(Rowid, y);
               }



               return false;
           }


           function RemoveGrpOnImport(removeNum) {
               var evt = document.getElementById("tdEvtGrp" + removeNum).value;

               if (evt == 'UPD') {
                   var detailId = document.getElementById("tdDtlIdGrp" + removeNum).value;
                   var CanclIds = document.getElementById("cphMain_hiddenGrpCanclDtlId").value;
                   if (CanclIds == '') {
                       document.getElementById("cphMain_hiddenGrpCanclDtlId").value = detailId;
                   }
                   else {
                       document.getElementById("cphMain_hiddenGrpCanclDtlId").value = document.getElementById("cphMain_hiddenGrpCanclDtlId").value + ',' + detailId;
                   }
               }
               //    var row_index = jQuery('#SubGrpRowId_' + removeNum).index();


               //  RowIndexTarff--;

               //    var BforeRmvTableRowCount = document.getElementById("TableQstn_").rows.length;


               jQuery('#SubGrpRowId_' + removeNum).remove();

               var TableRowCount = document.getElementById("tableGrp").rows.length;

               if (TableRowCount != 0) {
                   var idlast = $noCon('#tableGrp >tbody > tr:not(:has(>td>table)):last').attr('id');

                   if (idlast != "") {

                       var res = idlast.split("_");

                       document.getElementById("tdInxGrp" + res[1]).value = "";
                       document.getElementById("btnGrpAdd" + res[1]).style.opacity = "1";
                   }
               }
               else {

                   AddNewGroup();
               }



               return false;
           }
          
           function ValidateNullTableValues()
           {
              
               var RowNum = "";
               addRowtable = document.getElementById("tableGrp");

               for (var i = 0; i < addRowtable.rows.length; i++) {
                   //  if (i != addRowtable.rows.length - 1) {
                   var row = addRowtable.rows[i];
                   var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                   
                   //To check group name
                   var groupname = document.getElementById("inpGrpName_" + xLoop).value;
                 
                   if (groupname == "") {
                    
                     
                       RowNum = xLoop;
                      
                   }
                   var QstnCheck = 0;
                   addRowtableIn = document.getElementById("TableQstn_" + xLoop);

                   for (var ii = 0; ii < addRowtableIn.rows.length; ii++) {
                       //  if (i != addRowtable.rows.length - 1) {
                       var rowin = addRowtableIn.rows[ii];
                       var xLoopin = (addRowtableIn.rows[ii].cells[0].innerHTML);
                       var xLoopinnxt = (addRowtableIn.rows[ii].cells[1].innerHTML);
                                         
                  
                       if (groupname == "") {

                           if (!(CheckQstnValidateNull(xLoopin))) {
                               if (QstnCheck == 0)
                                   QstnCheck = 1;

                           }
                       }
                       else {
                           QstnCheck = 1;
                       }

                   }
                 
                   if (RowNum != "" && QstnCheck==0) {
                       RemoveGrpOnImport(RowNum);
                   }
               }
           }


           function ButtnFillClickGrp1()
           {
               $('#TableSelectQstn').find('tr').each(function () {
                   var row = $(this);
                   //  if (row.find('input[type="checkbox"]').is(':checked')) {

                   var rowid = row.find('input[type="checkbox"]').val();

                   row.find('input[type="checkbox"]').prop('checked', false);

                   var tdtext = row.find('#tdUsrNameRem' + rowid).html();
                 
              
                   //alert(tdtext + "tdtext");
                   document.getElementById("tdInxGrp" + currntx).value = currntx;
                   document.getElementById("btnGrpAdd" + currntx).style.opacity = "0.3";
                  // alert("in");
                   AddNewGroup();

                    
                    
                   document.getElementById("inpGrpName_" + currntx).value = tdtext;
                
                   CheckDuplicationGrp(currntx);
             
                   var set = $('#TableGrp tr td.' + rowid + '');
                   var length = set.length;
                 
                   $('#TableGrp tr td.' + rowid + '').each(function (ix, element) {
                       // Do your processing.
                    //   alert(ix + "ix");
                     
                 
                       var rowgrp = $(this);
                       var rowId = $(this).attr('id');
                     //  alert(rowId+"iiiiiiiiiiiiiiiiiii");
                      // alert(rowgrp.html() + "" + currntx + "" + currnty);
                      
                   
                       var str2 = "tdQstNameCpy";
                       var str3 = "tdRatgCpy";
                       var str4 = "tdKpiCpy";
                       if (rowId.indexOf(str2) != -1) {
                         //  console.log(str2 + " found");

                           document.getElementById("txtQstn_" + currntx + '' + currnty).value = rowgrp.html();
                       }
                       else if (rowId.indexOf(str3) != -1)
                       {
                           document.getElementById("ddlRate_" + currntx + '' + currnty).value = rowgrp.html();
                           document.getElementById("txtddlValue_" + currntx + '' + currnty).value = rowgrp.html();
                           
                       }
                       else if (rowId.indexOf(str4) != -1) {
                      


                           document.getElementById("txtkpi_" + currntx + '' + currnty).value = rowgrp.html();
                           if (ix >= 2) {
                               if (ix != length - 1) {
                                   document.getElementById("tdInxQstn" + currntx + '' + currnty).value = currntx + '' + currnty;
                                   document.getElementById("btnAddQstn_" + currntx + '' + currnty).style.opacity = "0.3";

                                   //btnaddqstn
                                   document.getElementById("btnImportQstn_" + currntx + '' + currnty).style.opacity = "0.3";
                                   document.getElementById("btnImportQstn_" + currntx + '' + currnty).disabled = true;

                                   FunctionQustn(currntx, currnty);
                               }
                           }
                       }
                     
                   });




                   //}
               });
               ValidateNullTableValues();
           }

           function CloseWindow() {
               window.close();
           }

     
       </script>

</asp:Content>
