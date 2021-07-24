<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_approval_set.aspx.cs" Inherits="Master_gen_approval_set_gen_approval_set" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
 <script src="/js/New%20js/date_pick/datepicker.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

     <asp:HiddenField ID="hiddenMainCanclDbId" runat="server" />
     <asp:HiddenField ID="hiddenSubCanclDbId" runat="server" />
    <asp:HiddenField ID="HiddenFieldCurrentDtlId" runat="server" Value="0" /> 
      <asp:HiddenField ID="HiddenEdit" runat="server"/>
     <asp:HiddenField ID="Hiddenview" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldMainData" runat="server" />
    <asp:HiddenField ID="HiddenFieldSubData" runat="server" />
     <asp:HiddenField ID="HiddenFieldView" runat="server" value="0"/>
    <asp:HiddenField ID="HiddenApprovalId" runat="server" />
    <asp:HiddenField ID="HiddenEditlist" runat="server" />
    <asp:HiddenField ID="HiddenMaincanceldl" runat="server" />
     <asp:HiddenField ID="HiddenFieldReopen" runat="server" Value="0"/>
    <asp:HiddenField ID="HiddenList" runat="server" />
    <asp:HiddenField ID="HiddenAddList" runat="server" />
    <asp:HiddenField ID="HiddenCnfm" runat="server" />
    <asp:HiddenField ID="hiddenPopupSts" runat="server" />

      <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>  
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <ol id="OlSection" runat="server" class="breadcrumb">
        <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
        <li><a href="/Master/gen_approval_set/gen_approval_set_list.aspx">Approval Set</a></li>
        <li class="active">Add Approval Set</li>
    </ol>

<!---breadcrumb_section_started----> 
   
    <div class="content_sec2 cont_contr" >
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con"><asp:Label ID="lblEntry" runat="server">Add Purchase Order</asp:Label></h1>
            
   
          <div class="form-group fg6 fg6_re">
            <label for="email" class="fg2_la1">Approval set name:<span class="spn1">*</span></label>
            <input class="form-control fg2_inp1 fg_chs1 inp_mst" placeholder="Approval set name" id="txt_Name" runat="server" autocomplete="off" onkeyup="return  IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" maxlength="100" />          
          </div>
            
          <div class="form-group fg6 fg6_re">
            <label for="email" class="fg2_la1">Description:<span class="spn1"></span></label>
            <textarea class="form-control fg2_inp1 fg_chs1" placeholder="Description" id="txtdescr" onkeyup="return  IncrmntConfrmCounter();" runat="server" maxlength="500" onkeypress="return DisableEnter(event)"> </textarea>         
          </div>
           
<!---=================section_devider============--->
      <div class="clearfix"></div>
<!---=================section_devider============--->

      <h3>Approval rules</h3>  
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

      <div class="form-group fg2 fg2_a">
        <label for="email" class="fg2_la1">Document section:<span class="spn1">*</span></label>  
          <asp:DropDownList ID="docsection" runat="server"  class="form-control fg2_inp1 fg_chs1 inp_mst" AutoPostBack="true" OnSelectedIndexChanged="docsection_SelectedIndexChanged" onkeypress="return DisableEnter(event)"></asp:DropDownList>
      </div>

<div style="display:none">

    <asp:DropDownList ID="ddlcond" runat="server"></asp:DropDownList>
    <asp:DropDownList ID="ddltype" runat="server"></asp:DropDownList>
    <asp:ListBox ID="lstproductcat" runat="server"  OnSelectedIndexChanged="lstproductcat_SelectedIndexChanged" SelectionMode="Multiple"></asp:ListBox>
    <asp:ListBox ID="lstproduct" runat="server" SelectionMode="Multiple"></asp:ListBox>
    <asp:ListBox ID="lstdept" runat="server" SelectionMode="Multiple"></asp:ListBox>
    <asp:ListBox ID="lstdivision" runat="server" SelectionMode="Multiple"></asp:ListBox>

</div>
           
<!---=================section_devider============--->
      <div class="clearfix"></div>
<!---=================section_devider============--->

<div id="divConditions" runat="server">
      
    <h3>Conditions</h3>


         <div class="tabl_set">
          <table class="table table-bordered tbl_set_fix">
            <thead class="thead1">
              <tr>
                <th class="th_b5">SL#</th>
                <th class="th_b9 tr_l">Conditions</th>
                <th class="th_b4 tr_l">Type</th>
                <th class="th_b10">Value</th>
                <th class="th_b4">Actions</th>
              </tr>
            </thead>

            <tbody id="mainTable">
            </tbody>

          </table>
        </div>
           
</div>    
   <!---table_Set_closed--->



<!---inner_content_sections area_closed--->

<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="free_sp"></div>
<!---=================section_devider============--->


<!--Buttons_Area_started--->
          <div class="sub_cont pull-right">
            <div class="save_sec">
               
                <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClientClick="return mainValidate();" onclick="btnAdd_Click"/>
                <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClientClick="return mainValidate();" onclick="btnAdd_Click" />
                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" OnClientClick="return mainValidateupd();" class="btn sub1" Visible="False"/>
                <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return mainValidateupd();" onclick="btnUpdate_Click" Visible="false" />
                <asp:Button ID="btnCnfrm" runat="server" Text="Confirm" class="btn sub2"  OnClientClick="return mainValidateupd();" OnClick="btnCnfrm_Click" style="display:none" />
                <asp:Button ID="btnCnfrm1" runat="server" Text="Confirm" class="btn sub2"   OnClientClick="return ConfirmAlert();"  Visible="false" />
                <asp:Button ID="btnReopen3" runat="server" Text="Reopen"  class="btn sub3 notv"  OnClick="btnReopen_Click"  style="display:none"/>
                <asp:Button ID="btnReopen" runat="server" Text="Reopen"  class="btn sub3 notv" OnClientClick="return ConfirmReopen();" visible="false"/>
                <asp:Button ID="btnCancel" runat="server" class="btn sub4 notv" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                <asp:Button ID="btnClear" runat="server" class="btn sub2" Text="Clear" OnClientClick="return AlertClearAll();"  />

            </div>
          </div>
<!--Buttons_area_closed--->

          

<!---frame_border_area_closed---->
        </div>
      </div>
    </div>
     

<!----------------------------------------------Content_section_opened------------------------------------------------------------->

</div>

<!---back_button_fixed_section--->
  <a id="divList" runat="server" href="gen_approval_set_list.aspx" type="button" class="list_b" title="Back to List">
    <i class="fa fa-arrow-circle-left"></i>
  </a>
<!---back_button_fixed_section--->

<!----save_quick_actions_started--->
  <a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
    <i class="fa fa-save"></i>
  </a>


  <div class="mySave1" id="mySave">
    <div class="save_sec">
        <asp:Button ID="btnsave" runat="server" class="btn sub1" Text="Save" OnClientClick="return mainValidate();" onclick="btnAdd_Click"/>
        <asp:Button ID="btnsaveclose" runat="server" class="btn sub3" Text="Save & Close" OnClientClick="return mainValidate();" onclick="btnAdd_Click" />
        <asp:Button ID="btnupdate2" runat="server" OnClick="btnUpdate_Click" Text="Update" OnClientClick="return mainValidateupd();" class="btn sub1" Visible="False"/>
        <asp:Button ID="btnupdateclose2" runat="server" class="btn sub3" Text="Update & Close" OnClientClick="return mainValidateupd();" onclick="btnUpdate_Click" Visible="false" />
        <asp:Button ID="btncnfrm2" runat="server" Text="Confirm" class="btn sub2"   OnClientClick="return ConfirmAlert();"  Visible="false" />
        <asp:Button ID="btnreopen2" runat="server" Text="Reopen"  class="btn sub3 notv" OnClientClick="return ConfirmReopen();" visible="false"/>
        <asp:Button ID="btncancel2" runat="server" class="btn sub4 notv" Text="Cancel" OnClientClick="return ConfirmMessage();" />
        <asp:Button ID="btnclear2" runat="server" class="btn sub2" Text="Clear" OnClientClick="return AlertClearAll();"  />
    </div>
  </div>
<!----save_quick_actions_closed--->

     </ContentTemplate>
            </asp:UpdatePanel>
                  
<!-- Modal1 -->
<div class="modal fade" id="mod_add" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog mod2" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">
            <asp:Label ID="title" runat="server" Text=""></asp:Label></h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="addlist()">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        
<div class="col-md-12">

<div class="subject-info-box-1 box2">
  <h3>Choose Items</h3>
    <input type="text" placeholder="Search" id="myprsel" name="search" class="ser_set" onkeyup="filter(this.value)"/>
    <asp:ListBox ID="lstBox1" runat="server" class="sub_1" SelectionMode="Multiple"></asp:ListBox>
    <asp:ListBox ID="lstBox3" runat="server" class="sub_1" SelectionMode="Multiple"></asp:ListBox>
    <asp:ListBox ID="lstBox4" runat="server" class="sub_1" SelectionMode="Multiple"></asp:ListBox>
    <asp:ListBox ID="lstBox5" runat="server" class="sub_1" SelectionMode="Multiple"></asp:ListBox>
</div>

<div class="subject-info-box-2 box2">
  <h3>Selected Items</h3>
    <input type="text" placeholder="Search" id="Text1" onkeyup="filter1(this.value)" name="search" class="ser_set" />
    <asp:ListBox ID="lstprc" runat="server" class="sub_2" SelectionMode="Multiple" ></asp:ListBox>
    <asp:ListBox ID="lstpr" runat="server" class="sub_2" SelectionMode="Multiple"></asp:ListBox>
    <asp:ListBox ID="lstdp" runat="server" class="sub_2" SelectionMode="Multiple"></asp:ListBox>
    <asp:ListBox ID="lstdiv" runat="server" class="sub_2" SelectionMode="Multiple"></asp:ListBox> 
</div>

</div><!---col-md-12_closed--->
      </div>
      <div class="modal-footer" style="text-align: center;">
        <div class="subject-info-arrows text-center arrows">
         <input type='button' id='btnRight' value='Add to list' class="btn btn-success bt_ad" /><br />
         <input type='button' id='btnLeft' value='Remove from list' class="btn btn-danger bt_ad" /><br />
        </div>
      </div>

    </div>
  </div>
</div>

    <script>
        function ConfirmAlert() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to confirm this approval set?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=btnCnfrm.ClientID%>").click();
                }
            });
            return false;
        }
        function ConfirmReopen() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to reopen this approval set?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=btnReopen3.ClientID%>").click();
                }
            });
            return false;
        }
        function DisableEnter(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }
    </script>
    <script>
        function filter(keyword) {
           
            var select = document.getElementById("<%=lstBox1.ClientID%>");
            for (var i = 0; i < select.length; i++) {
                var txt = select.options[i].text;
                var include = txt.toLowerCase().startsWith(keyword.toLowerCase());
                select.options[i].style.display = include ? 'list-item' : 'none';
            }
            var select1 = document.getElementById("<%=lstBox3.ClientID%>");
            for (var i = 0; i < select1.length; i++) {
                var txt1 = select1.options[i].text;
                var include1 = txt1.toLowerCase().startsWith(keyword.toLowerCase());
                select1.options[i].style.display = include1 ? 'list-item' : 'none';
            }
            var select2 = document.getElementById("<%=lstBox4.ClientID%>");
            for (var i = 0; i < select2.length; i++) {
                var txt2 = select2.options[i].text;
                var include2 = txt2.toLowerCase().startsWith(keyword.toLowerCase());
                select2.options[i].style.display = include2 ? 'list-item' : 'none';
            }
            var select3 = document.getElementById("<%=lstBox5.ClientID%>");
            for (var i = 0; i < select3.length; i++) {
                var txt3 = select3.options[i].text;
                var include3 = txt3.toLowerCase().startsWith(keyword.toLowerCase());
                select3.options[i].style.display = include3 ? 'list-item' : 'none';
            }
        }
    </script>
    <script>
        function filter1(keyword) {

            var select = document.getElementById("<%=lstprc.ClientID%>");
            for (var i = 0; i < select.length; i++) {
                var txt = select.options[i].text;
                var include = txt.toLowerCase().startsWith(keyword.toLowerCase());
                select.options[i].style.display = include ? 'list-item' : 'none';
            }
            var select1 = document.getElementById("<%=lstpr.ClientID%>");
            for (var i = 0; i < select1.length; i++) {
                var txt1 = select1.options[i].text;
                var include1 = txt1.toLowerCase().startsWith(keyword.toLowerCase());
                select1.options[i].style.display = include1 ? 'list-item' : 'none';
            }
            var select2 = document.getElementById("<%=lstdp.ClientID%>");
            for (var i = 0; i < select2.length; i++) {
                var txt2 = select2.options[i].text;
                var include2 = txt2.toLowerCase().startsWith(keyword.toLowerCase());
                select2.options[i].style.display = include2 ? 'list-item' : 'none';
            }
            var select3 = document.getElementById("<%=lstdiv.ClientID%>");
            for (var i = 0; i < select3.length; i++) {
                var txt3 = select3.options[i].text;
                var include3 = txt3.toLowerCase().startsWith(keyword.toLowerCase());
                select3.options[i].style.display = include3 ? 'list-item' : 'none';
            }
        }
    </script>
<!-- Modal1_closed -->
   <script>
       function LoadDatas(Val) {

           $("#mainTable").empty();

           RowNumMain = 0;

           var EditVal = Val;

           if (EditVal != "") {


               var find2 = '\\"\\[';
               var re2 = new RegExp(find2, 'g');
               var res2 = EditVal.replace(re2, '\[');

               var find3 = '\\]\\"';
               var re3 = new RegExp(find3, 'g');
               var res3 = res2.replace(re3, '\]');
               var json = $noCon.parseJSON(res3);
               for (var key in json) {
                   if (json.hasOwnProperty(key)) {
                       if (json[key].COND != "") {

                           EditListRows(json[key].COND, json[key].TYPE, json[key].TYNAME, json[key].MIN, json[key].MAX, json[key].DTLID, json[key].DL);

                       }
                   }
               }
           }
           else {
               EditListRows(null);
           }
           if (EditVal == "[]") {
               EditListRows(null);
           }
           if (document.getElementById("<%=Hiddenview.ClientID%>").value == "1") {

               $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select").prop("disabled", true);
           }

       }
   </script>
     <script>
         var $noCon = jQuery.noConflict();
         $noCon(window).load(function () {

             document.getElementById("<%=txt_Name.ClientID%>").focus();

             $("#mainTable").empty();

             RowNumMain = 0;
            
             var EditVal = document.getElementById("<%=HiddenEdit.ClientID%>").value;
             if (EditVal != "") {


                 var find2 = '\\"\\[';
                 var re2 = new RegExp(find2, 'g');
                 var res2 = EditVal.replace(re2, '\[');

                 var find3 = '\\]\\"';
                 var re3 = new RegExp(find3, 'g');
                 var res3 = res2.replace(re3, '\]');
                 var json = $noCon.parseJSON(res3);
                 for (var key in json) {
                     if (json.hasOwnProperty(key)) {
                         //if (json[key].DTLID != "") {

                         EditListRows(json[key].COND, json[key].TYPE, json[key].TYNAME, json[key].MIN, json[key].MAX, json[key].DTLID, json[key].DL);

                         // }
                     }
                 }
             }

             if (document.getElementById("<%=Hiddenview.ClientID%>").value == "1") {

                $(".content_area_container").find("input:not(.notv),button:not(.notv),checkbox,select").prop("disabled", true);
             }

         });
         
    </script>
     
<!--------script section_started---------->

<!-----table_search------------>
 
     <script>
        
         var RowNumMain = 0;
       
         function AddNewRowMain(COND, DTLID, DL) {
             var FrecRow = '';

             var dtlId = COND;
             var a = RowNumMain + 1;
             var Title = "";
             if (COND == "2") {
                 Title = "Product category";
             }
             else if (COND == "3") {
                 Title = "Product";
             }
             else if (COND == "4") {
                 Title = "Department";
             }
             else if (COND == "5") {
                 Title = "Division";
             }

             FrecRow += '<tr id="mainRowId_' + RowNumMain + '" class="tr_act">';
             FrecRow += '<td style="display:none" >' + RowNumMain + '</td>';

             FrecRow += '<td id="dbId_' + RowNumMain + '" style="display: none" >' + DTLID + '</td>';
             FrecRow += '<td id="dbId1_' + RowNumMain + '" style="display: none" >' + DL + '</td>';

             FrecRow += '<td id="sl_' + RowNumMain + '">' + a + '</td>';

             FrecRow += '<td> <select id="ddlcon_' + RowNumMain + '" name="ddlcon" onclick="return AD(\'' + RowNumMain + '\');"  onchange="return changeDesgMain(\'' + RowNumMain + '\',0);"  maxlength="100"  type="text" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw" >';
             FrecRow += '</select></td>';

             FrecRow += '<td>';
             FrecRow += '<select id="ddltype_' + RowNumMain + '" onclick="return Typ(\'' + RowNumMain + '\');" onchange="return changeDesgMain(\'' + RowNumMain + '\',1);"  maxlength="100"  type="text" class="fg2_inp2 fg2_inp3 fg_chs1 in_flw">';
             FrecRow += '</select></td>';

             FrecRow += '<td>';
             FrecRow += '<div id="txt1_' + RowNumMain + '" >';
             FrecRow += '<input type="text" id="txt_min_' + RowNumMain + '" class="fg2_inp2 fg2_inp3 fg_chs1 inp_wd1 tr_r" placeholder="0.00" onchange="validateFloatKeyPress(this);"  onfocus="this.placeholder=\'' + "" + '\';" onblur="this.placeholder=\'' + "0.00" + '\';" autocomplete="off"><input type="text" id="txt_max_' + RowNumMain + '" class="fg2_inp2 fg2_inp3 fg_chs1 inp_wd2 tr_r" placeholder="0.00" onchange="validateFloatKeyPress(this);" onfocus="this.placeholder=\'' + "" + '\';" onblur="this.placeholder=\'' + "0.00" + '\';" autocomplete="off" disabled >';
             FrecRow += '</div>';

             FrecRow += '<div id="txt2_' + RowNumMain + '" ><span class="inp_add">';
             FrecRow += '<a href="javascript:;" class="btn act_btn bn6" title="' + Title + '" data-toggle="modal" data-target="#mod_add" onclick="return FuctionOrganize(\'' + COND + '\',\'' + RowNumMain + '\');" ><i class="fa fa-cubes" ></i></a>';
             FrecRow += '<a href="javascript:;" data-toggle="modal" data-target="#mod_add" onclick="return FuctionOrganize(\'' + COND + '\',\'' + RowNumMain + '\');"><span><b><label id="lab_' + RowNumMain + '"></label></b>&nbsp Options Selected</span></a>';
             FrecRow += '</span></div>';
             FrecRow += '</td>';

             FrecRow += '<td class="td1">';
             FrecRow += '<div class="btn_stl1">';
             FrecRow += '<button id="btnAdd_' + RowNumMain + '" onclick="return FuctionAddMain(\'' + RowNumMain + '\');" class="btn act_btn bn1 mainAdd" title="Add"><i class="fa fa-plus-circle"></i></button>';
             FrecRow += '<button id="btnDele_' + RowNumMain + '" Onclick="return FuctionDeleMain(\'' + RowNumMain + '\');" class="btn act_btn bn3" title="Delete"><i class="fa fa-trash"></i></button>';
             FrecRow += '</div>';
             FrecRow += '</td>';

             FrecRow += '</tr>';

             jQuery('#mainTable').append(FrecRow);

             if (COND == "1") {
                 document.getElementById("txt2_" + RowNumMain).style.display = "none";
                 document.getElementById("txt1_" + RowNumMain).style.display = "block";
             } else {
                 document.getElementById("txt1_" + RowNumMain).style.display = "none";
                 document.getElementById("txt2_" + RowNumMain).style.display = "block";
             }


             $('.mainAdd').attr('disabled', 'disabled');
             var LastRowid = $("#mainTable tr:last td:first").html();
             document.getElementById("btnAdd_" + LastRowid).disabled = false;
             RowNumMain++;

             return false;
         }

</script>

     <script type="text/Javascript">
         function validateFloatKeyPress(el) {
             var v = parseFloat(el.value);
             el.value = (isNaN(v)) ? '' : v.toFixed(2);
         }
         //$('input').click(function () {

         //    $(this).attr('value', '');
         //    $(this).css('color', '#000');

         //});
       

</script>
    <script>
        function EditListRows(COND, TYPE, TYNAME, MIN, MAX, DTLID, DL) {

            AddNewRowMain(COND, DTLID, DL);

            var validRowID = RowNumMain - 1;
            document.getElementById("dbId_" + validRowID).innerHTML = DTLID;

            var a = document.getElementById("<%=ddlcond.ClientID%>");
            var typ = document.getElementById("<%=ddltype.ClientID%>");

            var cond1 = document.getElementById("ddlcon_" + validRowID);
            var type = document.getElementById("ddltype_" + validRowID);

            $('#ddltype_' + validRowID).empty();

            for (var i = 0; i < a.options.length; i++) {
                // 
                var opt = document.createElement("option");
                opt.text = a[i].text;
                opt.value = a[i].value;

                cond1.options.add(opt);
                cond1.value = validRowID + 1;

            }

            if (document.getElementById("<%=HiddenEditlist.ClientID%>").value == "1") {


                document.getElementById("ddlcon_" + validRowID).value = COND;

                var ddlcond = document.getElementById("ddlcon_" + validRowID).value;
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_approval_set.aspx/Loadcndtype",
                    data: '{ddlcond: "' + ddlcond + '"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "" && data.d != null) {

                            var find2 = '\\"\\[';
                            var re2 = new RegExp(find2, 'g');
                            var res2 = data.d.replace(re2, '\[');

                            var find3 = '\\]\\"';
                            var re3 = new RegExp(find3, 'g');
                            var res3 = res2.replace(re3, '\]');
                            var json = $noCon.parseJSON(res3);
                            for (var key in json) {
                                if (json.hasOwnProperty(key)) {

                                    var opt1 = document.createElement("option");
                                    opt1.text = json[key].TYPENAME;
                                    opt1.value = json[key].TYPEID;

                                    type.options.add(opt1);

                                    type.selectedIndex = 0;
                                }
                            }
                        }
                        else {

                        }
                    }

                });

                document.getElementById("ddltype_" + validRowID).value = TYPE;

                if (COND == "1") {

                    document.getElementById("txt_min_" + validRowID).value = MIN;
                    document.getElementById("txt_max_" + validRowID).value = MAX;
                }
                if (document.getElementById("ddlcon_" + validRowID).value == "1") {

                    document.getElementById("txt2_" + validRowID).style.display = "none";
                    document.getElementById("txt1_" + validRowID).style.display = "block";
                } else {
                    document.getElementById("txt1_" + validRowID).style.display = "none";

                    document.getElementById("txt2_" + validRowID).style.display = "block";

                }
                if (document.getElementById("ddltype_" + validRowID).value != "1") {
                    document.getElementById("txt_max_" + validRowID).value = "0.00";
                    document.getElementById("txt_max_" + validRowID).disabled = true;

                }
                if (document.getElementById("ddltype_" + validRowID).value == "1") {
                    document.getElementById("txt_max_" + validRowID).disabled = false;

                }
                if (document.getElementById("<%=HiddenCnfm.ClientID%>").value == "1") {


                    $("#mainTable").find("input,select,textarea,button").attr("disabled", "disabled");
                    addlist();
                }
                addlist();
            }
            else {

                var ddlcond = document.getElementById("ddlcon_" + validRowID).value;

                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_approval_set.aspx/Loadcndtype",
                    data: '{ddlcond: "' + ddlcond + '"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "" && data.d != null) {

                            var find2 = '\\"\\[';
                            var re2 = new RegExp(find2, 'g');
                            var res2 = data.d.replace(re2, '\[');

                            var find3 = '\\]\\"';
                            var re3 = new RegExp(find3, 'g');
                            var res3 = res2.replace(re3, '\]');
                            var json = $noCon.parseJSON(res3);
                            for (var key in json) {
                                if (json.hasOwnProperty(key)) {

                                    var opt1 = document.createElement("option");
                                    opt1.text = json[key].TYPENAME;
                                    opt1.value = json[key].TYPEID;

                                    type.options.add(opt1);

                                    type.selectedIndex = 0;
                                }
                            }
                        }
                        else {

                        }
                    }

                });

                addlist();

            }
        }

        function Typ(RowNum) {
            if (document.getElementById("ddlcon_" + RowNum).value == "1") {
                if (document.getElementById("ddltype_" + RowNum).value != "1") {

                    document.getElementById("txt_max_" + RowNum).disabled = true;
                }
                else {
                    document.getElementById("txt_max_" + RowNum).disabled = false;
                }
            }
        }

        function AD(RowNum) {

            if (document.getElementById("ddlcon_" + RowNum).value == "1") {

                document.getElementById("txt2_" + RowNum).style.display = "none";
                document.getElementById("txt1_" + RowNum).style.display = "block";
            } else {
                document.getElementById("txt1_" + RowNum).style.display = "none";

                document.getElementById("txt2_" + RowNum).style.display = "block";

            }
            var ddlcond = document.getElementById("ddlcon_" + RowNum).value;
            var type = document.getElementById("ddltype_" + RowNum);

            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_approval_set.aspx/Loadcndtype",
                data: '{ddlcond: "' + ddlcond + '"}',
                dataType: "json",
                success: function (data) {
                    if (data.d != "" && data.d != null) {

                        var find2 = '\\"\\[';
                        var re2 = new RegExp(find2, 'g');
                        var res2 = data.d.replace(re2, '\[');

                        var find3 = '\\]\\"';
                        var re3 = new RegExp(find3, 'g');
                        var res3 = res2.replace(re3, '\]');
                        var json = $noCon.parseJSON(res3);
                        for (var key in json) {
                            if (json.hasOwnProperty(key)) {

                                var opt1 = document.createElement("option");
                                opt1.text = json[key].TYPENAME;
                                opt1.value = json[key].TYPEID;

                                type.options.add(opt1);

                                type.selectedIndex = 0;
                            }
                        }
                    }
                    else {

                    }
                }

            });

        }
        function editlist(RowNum) {

            AddNewRowMain(null);
            var a = document.getElementById("<%=ddlcond.ClientID%>");
            var typ = document.getElementById("<%=ddltype.ClientID%>");
            var validrow = RowNumMain - 1;
            var cond1 = document.getElementById("ddlcon_" + validrow);
            var type = document.getElementById("ddltype_" + validrow);
            for (var i = 0; i < a.options.length; i++) {
                var opt = document.createElement("option");
                opt.text = a[i].text;
                opt.value = a[i].value;
                cond1.options.add(opt);
                cond1.value = "";
            }
            for (var j = 0; j < typ.options.length; j++) {
                // 
                var opt1 = document.createElement("option");
                opt1.text = typ[j].text;
                opt1.value = typ[j].value;

                type.options.add(opt1);
            }
        }

       
        function addlist() {

            var totalRowCount = 0;
            var rowCount = 0;
            var table = document.getElementById("mainTable");
            var rows = table.getElementsByTagName("tr")
            for (var i = 0; i < rows.length; i++) {
                totalRowCount++;
                if (rows[i].getElementsByTagName("td").length > 0) {
                    rowCount++;
                }
            }

            var validrow = rowCount + 1;



            var validrow1 = RowNumMain;

            for (var i = 0; i < validrow1; i++) {
                if (document.getElementById("ddlcon_" + i) != null) {
                    var cond1 = document.getElementById("ddlcon_" + i).value;
                }
                else {
                    cond1 = "0";
                }
                //alert(cond1);
                if (cond1 == null) {
                }
                else if (cond1 == "0") {
                }

                else if (cond1 == "2") {

                    document.getElementById("lab_" + i).textContent = document.getElementById("cphMain_lstprc").options.length;
                }
                else if (cond1 == "3") {
                    document.getElementById("lab_" + i).textContent = document.getElementById("cphMain_lstpr").options.length;
                }
                else if (cond1 == "4") {

                    document.getElementById("lab_" + i).textContent = document.getElementById("cphMain_lstdp").options.length;
                }
                else if (cond1 == "5") {
                    document.getElementById("lab_" + i).textContent = document.getElementById("cphMain_lstdiv").options.length;
                }

            }

            document.getElementById("cphMain_lstprc").selectedIndex = -1;
            document.getElementById("cphMain_lstpr").selectedIndex = -1;
            document.getElementById("cphMain_lstdp").selectedIndex = -1;
            document.getElementById("cphMain_lstdiv").selectedIndex = -1;
        }
        function FuctionOrganize(COND, Rownum) {
            COND = document.getElementById("ddlcon_" + Rownum).value;

            document.getElementById("cphMain_lstBox1").style.display = "none";
            document.getElementById("cphMain_lstBox3").style.display = "none";
            document.getElementById("cphMain_lstBox4").style.display = "none";
            document.getElementById("cphMain_lstBox5").style.display = "none";
            document.getElementById("cphMain_lstprc").style.display = "none";
            document.getElementById("cphMain_lstpr").style.display = "none";
            document.getElementById("cphMain_lstdp").style.display = "none";
            document.getElementById("cphMain_lstdiv").style.display = "none";
            if (COND == "2") {
                document.getElementById("cphMain_title").innerHTML = "Approval set - Product category";
                document.getElementById("cphMain_lstBox1").style.display = "block";
                document.getElementById("cphMain_lstprc").style.display = "block";
                var prct = document.getElementById("<%=lstproductcat.ClientID%>");
                var prctg = document.getElementById("cphMain_lstBox1");

                if (document.getElementById("cphMain_lstBox1").options.length == '0') {
                    for (var i = 0; i < prct.options.length; i++) {

                        var opt = document.createElement("option");
                        opt.text = prct[i].text;
                        opt.value = prct[i].value;

                        prctg.options.add(opt);

                        opt.style.wordWrap = "break-word";
                        opt.style.wordBreak = "break-all";
                        opt.style.overflow = "hidden";
                    }
                }
            }
            else if (COND == "3") {
                document.getElementById("cphMain_title").innerHTML = "Approval set - Product";
                document.getElementById("cphMain_lstBox3").style.display = "block";
                document.getElementById("cphMain_lstpr").style.display = "block";
                var prct = document.getElementById("<%=lstproduct.ClientID%>");
                var prctg = document.getElementById("cphMain_lstBox3");
                if (document.getElementById("cphMain_lstBox3").options.length == '0') {
                    for (var i = 0; i < prct.options.length; i++) {

                        var opt = document.createElement("option");
                        opt.text = prct[i].text;
                        opt.value = prct[i].value;

                        prctg.options.add(opt);

                        opt.style.wordWrap = "break-word";
                        opt.style.wordBreak = "break-all";
                        opt.style.overflow = "hidden";
                    }
                }
            }
            else if (COND == "4") {
                document.getElementById("cphMain_title").innerHTML = "Approval set - Department";
                document.getElementById("cphMain_lstBox4").style.display = "block";
                document.getElementById("cphMain_lstdp").style.display = "block";
                var prct = document.getElementById("<%=lstdept.ClientID%>");
                var prctg = document.getElementById("cphMain_lstBox4");
                if (document.getElementById("cphMain_lstBox4").options.length == '0') {
                    for (var i = 0; i < prct.options.length; i++) {

                        var opt = document.createElement("option");
                        opt.text = prct[i].text;
                        opt.value = prct[i].value;

                        prctg.options.add(opt);

                        opt.style.wordWrap = "break-word";
                        opt.style.wordBreak = "break-all";
                        opt.style.overflow = "hidden";
                    }
                }
            }
            else if (COND == "5") {
                document.getElementById("cphMain_title").innerHTML = "Approval set - Division";
                document.getElementById("cphMain_lstBox5").style.display = "block";
                document.getElementById("cphMain_lstdiv").style.display = "block";
                var prct = document.getElementById("<%=lstdivision.ClientID%>");
                var prctg = document.getElementById("cphMain_lstBox5");
                if (document.getElementById("cphMain_lstBox5").options.length == '0') {
                    for (var i = 0; i < prct.options.length; i++) {

                        var opt = document.createElement("option");
                        opt.text = prct[i].text;
                        opt.value = prct[i].value;

                        prctg.options.add(opt);

                        opt.style.wordWrap = "break-word";
                        opt.style.wordBreak = "break-all";
                        opt.style.overflow = "hidden";
                    }
                }
            }

            if (document.getElementById("<%=HiddenCnfm.ClientID%>").value == "1") {

                document.getElementById("<%=lstprc.ClientID%>").disabled = true;
                document.getElementById("<%=lstpr.ClientID%>").disabled = true;
                document.getElementById("<%=lstdiv.ClientID%>").disabled = true;
                document.getElementById("<%=lstdp.ClientID%>").disabled = true;
                document.getElementById("<%=lstBox1.ClientID%>").disabled = true;
                document.getElementById("<%=lstBox3.ClientID%>").disabled = true;
                document.getElementById("<%=lstBox4.ClientID%>").disabled = true;
                document.getElementById("<%=lstBox5.ClientID%>").disabled = true;
                document.getElementById("btnRight").disabled = true;
                document.getElementById("btnLeft").disabled = true;
            }

        }

        function FuctionAddMain(RowNum) {
          
            if (checkMainRow(RowNum) == true) {
               
                IncrmntConfrmCounter();
                editlist(RowNum);
                
            }
            return false;
        }
        function FuctionDeleMain(RowNum) {

            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to cancel this condition?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    IncrmntConfrmCounter();
                    var detailId = document.getElementById("dbId_" + RowNum).innerHTML;
                    var detailId1 = document.getElementById("dbId1_" + RowNum).innerHTML;
                    if (detailId != "") {

                        var CanclIds = document.getElementById("cphMain_hiddenMainCanclDbId").value;
                        if (CanclIds == '') {

                            document.getElementById("cphMain_hiddenMainCanclDbId").value = detailId;
                        }
                        else {
                            document.getElementById("cphMain_hiddenMainCanclDbId").value = document.getElementById("cphMain_hiddenMainCanclDbId").value + ',' + detailId;
                        }
                        if (detailId1 != "") {

                            var CanclIdsdl = document.getElementById("<%=HiddenMaincanceldl.ClientID%>").value;

                            if (CanclIdsdl == '') {
                                document.getElementById("<%=HiddenMaincanceldl.ClientID%>").value = detailId1;
                            }
                            else {
                                document.getElementById("<%=HiddenMaincanceldl.ClientID%>").value = document.getElementById("<%=HiddenMaincanceldl.ClientID%>").value + ',' + detailId1;
                            }
                        }
                    }

                    $('#mainRowId_' + RowNum).remove();
                    var TableRowCount = document.getElementById("mainTable").rows.length;
                    if (TableRowCount != 0) {
                        var LastRowid = $("#mainTable tr:last td:first").html();
                        document.getElementById("btnAdd_" + LastRowid).disabled = false;
                    }
                    else {
                        AddNewRowMain(null);
                    }
                    if (document.getElementById("cphMain_HiddenFieldCurrentDtlId").value == detailId) {
                        $(".hire").hide();
                        $("#subTable").empty();
                        //document.getElementById("cphMain_hiddenSubCanclDbId").value = "";
                    }
                }
                else {
                }
            });
            return false;
        }
        function checkMainRow(RowNum) {
            var ret = true;
            var cond = document.getElementById("ddlcon_" + RowNum).value;
            var type = document.getElementById("ddltype_" + RowNum).value;
         
            document.getElementById("ddlcon_" + RowNum).style.borderColor = "";
            document.getElementById("ddltype_" + RowNum).style.borderColor = "";
          
            if (type == "" || type == "-Select-") {
                document.getElementById("ddltype_" + RowNum).style.borderColor = "red";
                document.getElementById("ddltype_" + RowNum).focus();
                ret = false;
            }
            if (cond == "" ||cond == "-Select-") {
                document.getElementById("ddlcon_" + RowNum).style.borderColor = "red";
                document.getElementById("ddlcon_" + RowNum).focus();
                ret = false;
            }
            return ret;
        }
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
            return false;
        }


        function mainValidate() {

            var ret = true;
            document.getElementById("<%=txt_Name.ClientID%>").style.borderColor = "";
            var NameWithoutReplace = document.getElementById("<%=txt_Name.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txt_Name.ClientID%>").value = replaceText2;
            var Name = document.getElementById("<%=txt_Name.ClientID%>").value.trim();

            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];

            var tableOtherItem = document.getElementById("mainTable");
            if (tableOtherItem != null && tableOtherItem != "null" && tableOtherItem != "") {
                var m = parseInt(tableOtherItem.rows.length) - 1;
                for (var a = m; a >= 0; a--) {
                    var validRowID = (tableOtherItem.rows[a].cells[0].innerHTML);
                    if (checkMainRow(validRowID) == false) {
                        ret = false;
                    }
                    else {

                        var dtlId = (tableOtherItem.rows[a].cells[1].innerHTML);
                        var cond = document.getElementById("ddlcon_" + validRowID).value;
                        var type = document.getElementById("ddltype_" + validRowID).value;
                        if (cond == "1") {
                            var min = document.getElementById("txt_min_" + validRowID).value;

                            var max = document.getElementById("txt_max_" + validRowID).value;


                            if (type == 1) {
                                if (min == "" || max == "") {
                                    var mini = "1";

                                }
                                else {
                                    var mini = "0";
                                    var minimum = parseFloat(min);
                                    var maximum = parseFloat(max);
                                }
                            }
                            else {
                                if (min == "") {
                                    var mini = "1";

                                }
                                else {
                                    var mini = "0";
                                    var minimum = "0";
                                    var maximum = "1";
                                }
                            }
                        }
                        if (cond == "2") {
                            var prct = document.getElementById("<%=lstprc.ClientID%>");
                            var procat = prct.options.length;
                            if (procat == "0") {
                                var proca = "1";
                            }
                        }
                        if (cond == "3") {
                            var prct = document.getElementById("<%=lstpr.ClientID%>");
                            var procat = prct.options.length;
                            if (procat == "0") {
                                var prod = "1";
                            }
                        }
                        if (cond == "4") {
                            var prct = document.getElementById("<%=lstdp.ClientID%>");
                            var procat = prct.options.length;
                            if (procat == "0") {
                                var dpt = "1";
                            }
                        }
                        if (cond == "5") {
                            var prct = document.getElementById("<%=lstdiv.ClientID%>");
                            var procat = prct.options.length;
                            if (procat == "0") {
                                var div = "1";
                            }
                        }
                        var $add = jQuery.noConflict();
                        var client = JSON.stringify({
                            DTLID: "" + dtlId + "",
                            COND: "" + cond + "",
                            Type: "" + type + "",

                        });
                        tbClientJobSheduling.push(client);
                        //alert(client);
                    }
                }
            }

            if (document.getElementById("<%=docsection.ClientID%>").value == "0") {
                document.getElementById("<%=docsection.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=docsection.ClientID%>").focus();
                ret = false;
            }
            if (mini == "1") {
                document.getElementById("txt_min_" + validRowID).style.borderColor = "red";
                document.getElementById("txt_min_" + validRowID).focus();
                document.getElementById("txt_max_" + validRowID).style.borderColor = "red";
                document.getElementById("txt_max_" + validRowID).focus();
                ret = false;
            }

            if (minimum >= maximum) {

                document.getElementById("txt_min_" + validRowID).style.borderColor = "red";
                document.getElementById("txt_min_" + validRowID).focus();
                document.getElementById("txt_max_" + validRowID).style.borderColor = "red";
                document.getElementById("txt_max_" + validRowID).focus();
                $("#divWarning").html("Minimum Amount Should Not be Greater than Maximum Amount");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            if (proca == "1") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the Product Category field below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            if (prod == "1") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the Product field below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            if (dpt == "1") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the Departments field below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            if (div == "1") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the Divisions field below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            if (Name == "") {

                document.getElementById("<%=txt_Name.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=txt_Name.ClientID%>").focus();
                ret = false;
            }
            if (ret == false) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            else {

                var orgID = '<%= Session["ORGID"] %>';
                var corptID = '<%= Session["CORPOFFICEID"] %>';
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_approval_set.aspx/checkDup",
                    data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",Name: "' + Name + '"}',
                    dataType: "json",
                    success: function (data) {

                        if (data.d == "dup") {
                            DupName();
                            ret = false;
                        }
                    }
                });
            }
            if (ret == true) {

                $add("#cphMain_HiddenFieldMainData").val(JSON.stringify(tbClientJobSheduling));
                subValidate();
            }
            return ret;
        }

        function mainValidateupd() {

            var ret = true;
            document.getElementById("<%=txt_Name.ClientID%>").style.borderColor = "";
            var NameWithoutReplace = document.getElementById("<%=txt_Name.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txt_Name.ClientID%>").value = replaceText2;
            var Name = document.getElementById("<%=txt_Name.ClientID%>").value.trim();

            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];

            var tableOtherItem = document.getElementById("mainTable");
            var m = parseInt(tableOtherItem.rows.length) - 1;
            for (var a = m; a >= 0; a--) {
                var validRowID = (tableOtherItem.rows[a].cells[0].innerHTML);
                if (checkMainRow(validRowID) == false) {
                    ret = false;
                }
                else {

                    var dtlId = (tableOtherItem.rows[a].cells[1].innerHTML);

                    var cond = document.getElementById("ddlcon_" + validRowID).value;
                    var type = document.getElementById("ddltype_" + validRowID).value;
                    if (cond == "1") {
                        var min = document.getElementById("txt_min_" + validRowID).value;

                        var max = document.getElementById("txt_max_" + validRowID).value;
                        if (type == 1) {
                            if (min == "" || max == "") {
                                var mini = "1";

                            }
                            else {
                                var mini = "0";
                                var minimum = parseFloat(min);
                                var maximum = parseFloat(max);
                            }
                        }
                        else {
                            if (min == "") {
                                var mini = "1";

                            }
                            else {
                                var mini = "0";
                                var minimum = "0";
                                var maximum = "1";
                            }
                        }
                    }
                    if (cond == "2") {
                        var prct = document.getElementById("<%=lstprc.ClientID%>");
                        var procat = prct.options.length;
                        if (procat == "0") {
                            var proca = "1";
                        }
                    }
                    if (cond == "3") {
                        var prct = document.getElementById("<%=lstpr.ClientID%>");
                        var procat = prct.options.length;
                        if (procat == "0") {
                            var prod = "1";
                        }
                    }
                    if (cond == "4") {
                        var prct = document.getElementById("<%=lstdp.ClientID%>");
                        var procat = prct.options.length;
                        if (procat == "0") {
                            var dpt = "1";
                        }
                    }
                    if (cond == "5") {
                        var prct = document.getElementById("<%=lstdiv.ClientID%>");
                        var procat = prct.options.length;
                        if (procat == "0") {
                            var div = "1";
                        }
                    }
                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        DTLID: "" + dtlId + "",
                        COND: "" + cond + "",
                        Type: "" + type + "",

                    });
                    tbClientJobSheduling.push(client);
                    //alert(client);
                }
            }
            if (document.getElementById("<%=docsection.ClientID%>").value == "0") {
                document.getElementById("<%=docsection.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=docsection.ClientID%>").focus();
                ret = false;
            }
            if (mini == "1") {
                document.getElementById("txt_min_" + validRowID).style.borderColor = "red";
                document.getElementById("txt_min_" + validRowID).focus();
                document.getElementById("txt_max_" + validRowID).style.borderColor = "red";
                document.getElementById("txt_max_" + validRowID).focus();
                ret = false;
            }

            if (minimum >= maximum) {
                document.getElementById("txt_min_" + validRowID).style.borderColor = "red";
                document.getElementById("txt_min_" + validRowID).focus();
                document.getElementById("txt_max_" + validRowID).style.borderColor = "red";
                document.getElementById("txt_max_" + validRowID).focus();
                $("#divWarning").html("Minimum Amount Should Not be Greater than Maximum Amount");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            if (proca == "1") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the Product Category field below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            if (prod == "1") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the Product field below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            if (dpt == "1") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the Departments field below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            if (div == "1") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the Divisions field below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            if (Name == "") {

                document.getElementById("<%=txt_Name.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=txt_Name.ClientID%>").focus();
                ret = false;
            }
            if (ret == false) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }

            if (ret == true) {

                $add("#cphMain_HiddenFieldMainData").val(JSON.stringify(tbClientJobSheduling));
                subValidate();
            }
            return ret;
        }
        function subValidate() {
            var ret = true;
            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];

            var tableOtherItem = document.getElementById("mainTable");
            var m = parseInt(tableOtherItem.rows.length) - 1;
            for (var a = m; a >= 0; a--) {
                var validRowID = (tableOtherItem.rows[a].cells[0].innerHTML);
                if (checkMainRow(validRowID) == false) {
                    ret = false;
                }
                else {

                    var dtlId = (tableOtherItem.rows[a].cells[1].innerHTML);
                    var dl = (tableOtherItem.rows[a].cells[2].innerHTML);
                    var cond = document.getElementById("ddlcon_" + validRowID).value;


                    //alert(cond);
                    var lst = "";
                    if (cond == "1") {
                        // cond = 1;
                        var type = document.getElementById("ddltype_" + validRowID).value;
                        var min = document.getElementById("txt_min_" + validRowID).value;

                        var max = document.getElementById("txt_max_" + validRowID).value;
                        if (max == "") {
                            max = "0";
                        }
                        lst = 0;

                        //lst = 0;

                    }
                    if (cond == "2") {
                        lst = "";
                        var prct = document.getElementById("<%=lstprc.ClientID%>");

                        for (var i = 0; i < prct.options.length; i++) {
                            //cond = 2;
                            var min = 0;

                            var max = 0;
                            var type = document.getElementById("ddltype_" + validRowID).value;
                            var opt = document.createElement("option");
                            opt.text = prct[i].text;
                            opt.value = prct[i].value;
                            if (lst == "") {
                                lst = prct[i].value;
                            }
                            else {
                                lst = lst + "," + prct[i].value;
                            }
                        }

                    }
                    if (cond == "3") {
                        lst = "";
                        min = 0;
                        max = 0;
                        var type = document.getElementById("ddltype_" + validRowID).value;
                        var prct = document.getElementById("<%=lstpr.ClientID%>");
                        for (var i = 0; i < prct.options.length; i++) {

                            var opt = document.createElement("option");
                            opt.text = prct[i].text;
                            opt.value = prct[i].value;

                            if (lst == "") {
                                lst = prct[i].value;
                            }
                            else {
                                lst = lst + "," + prct[i].value;
                            }
                        }

                    }
                    if (cond == "4") {
                        lst = "";
                        min = 0;
                        max = 0;
                        var type = document.getElementById("ddltype_" + validRowID).value;
                        var prct = document.getElementById("<%=lstdp.ClientID%>");
                        for (var i = 0; i < prct.options.length; i++) {

                            var opt = document.createElement("option");
                            opt.text = prct[i].text;
                            opt.value = prct[i].value;

                            if (lst == "") {
                                lst = prct[i].value;
                            }
                            else {
                                lst = lst + "," + prct[i].value;
                            }
                        }

                    }
                    if (cond == "5") {
                        lst = "";
                        min = 0;
                        max = 0;
                        var type = document.getElementById("ddltype_" + validRowID).value;
                        var prct = document.getElementById("<%=lstdiv.ClientID%>");
                        for (var i = 0; i < prct.options.length; i++) {

                            var opt = document.createElement("option");
                            opt.text = prct[i].text;
                            opt.value = prct[i].value;

                            if (lst == "") {
                                lst = prct[i].value;
                            }
                            else {
                                lst = lst + "," + prct[i].value;
                            }
                        }

                    }

                    var $add = jQuery.noConflict();
                    var client = JSON.stringify({
                        DTLID: "" + dtlId + "",
                        DL: "" + dl + "",
                        COND: "" + cond + "",
                        TYPE: "" + type + "",
                        MAX: "" + max + "",
                        MIN: "" + min + "",
                        LST: "" + lst + ""
                    });

                    tbClientJobSheduling.push(client);

                }
            }

            if (ret == false) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }
            if (ret == true) {
                $add("#cphMain_HiddenFieldSubData").val(JSON.stringify(tbClientJobSheduling));
            }
            return ret;
        }
        </script>

    <script>
        function changeDesgMain(RowNum,Mode) {

            IncrmntConfrmCounter();
            document.getElementById("ddlcon_" + RowNum).style.borderColor = "";

            var COND = document.getElementById("ddlcon_" + RowNum).value;
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';

            if (COND != "") {

                if (Mode == "0") {
                    $('#ddltype_' + RowNum).empty();
                }

                var tableOtherItem = document.getElementById("mainTable");
                var m = parseInt(tableOtherItem.rows.length) - 1;
                for (var a = m; a >= 0; a--) {
                    var validRowID = (tableOtherItem.rows[a].cells[0].innerHTML);
                    var CheckEmpId = document.getElementById("ddlcon_" + validRowID).value;
                    if (RowNum != validRowID && COND == CheckEmpId) {
                        $("#divWarning").html("Duplication Error!.Conditions can’t be duplicated.");
                        $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        document.getElementById("ddlcon_" + RowNum).style.borderColor = "red";
                        document.getElementById("ddlcon_" + RowNum).focus();
                        document.getElementById("ddlcon_" + RowNum).value = "";
                        document.getElementById("ddlcon_" + RowNum).value = "";
                        return false;
                    }
                }


            }
            return false;
        }
    </script>
















<!--save_pop up_open-->
<script>
    function opensave() {
        document.getElementById("mySave").style.width = "140px";
    }

    function closesave() {
        document.getElementById("mySave").style.width = "0px";
    }
</script>
<!--save_pop up_closed-->

<!----hide/Show_section---->
<script>
    $(document).ready(function () {
        $("#hide").click(function () {
            $(".c1h").hide();
        });
        $("#show").click(function () {
            $(".c1h").show();
        });
    });
</script>

<!----hide/Show_section2---->
<script>
    $(document).ready(function () {
        $("#hide").click(function () {
            $(".c2h").hide();
        });
        $("#show1").click(function () {
            $(".c2h").show();
        });
    });
</script>

<!-----Enable_disable script--->
<script>
    $(document).ready(function () {
        $(".bu1").click(function () {
            $("#mySe1").toggle();
        });
    });
</script>
<script>
    $(document).ready(function () {
        $(".bu").click(function () {
            $("#mySe").toggle();
        });
    });
</script>
<!-----Enable_disable script_closed--->

<!---draggable_div_script_started of myinp---->



      <script>
          function SuccessIns() {
              $("#success-alert").html("Approval Set details inserted successfully");
              $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
              });
              return false;
          }
          function SuccessUpd() {
              $("#success-alert").html("Approval set details updated successfully");
              $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
              });
              return false;
          }
          function SuccessCnfm() {
              $("#success-alert").html("Approval set details Confirmed successfully");
              $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
              });
              return false;
          }
          function SuccessReopen() {
              $("#success-alert").html("Approval set details Reopened successfully");
              $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
              });
              return false;
          }
          function DupName() {
              $("#divWarning").html("Duplication Error!.Approval name can’t be duplicated.");
              $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });
              document.getElementById("cphMain_txt_Name").style.borderColor = "red";
              document.getElementById("cphMain_txt_Name").focus();
              return false;
          }
          function ConfirmMessage() {
              if (confirmbox > 0) {
                  
                  ezBSAlert({
                      type: "confirm",
                      messageText: "Are you sure you want to leave this page?",
                      alertType: "info"
                  }).done(function (e) {
                      if (e == true) {

                          if (document.getElementById("cphMain_hiddenPopupSts").value != "") {
                              window.location.href = "gen_approval_set_List.aspx?VId=" + document.getElementById("cphMain_hiddenPopupSts").value + "";
                          }
                          else {
                              window.location.href = "gen_approval_set_List.aspx";
                          }
                      }
                      else {
                          return false;
                      }
                  });
                  return false;
              }
              else {
                  if (document.getElementById("cphMain_hiddenPopupSts").value != "") {
                      window.location.href = "gen_approval_set_List.aspx?VId=" + document.getElementById("cphMain_hiddenPopupSts").value + "";
                  }
                  else {
                      window.location.href = "gen_approval_set_List.aspx";
                  }
                  return false;
              }
          }
          function ConfirmMessageSub() {
              if (confirmbox > 0) {
                  ezBSAlert({
                      type: "confirm",
                      messageText: "Are you sure you want to cancel?",
                      alertType: "info"
                  }).done(function (e) {
                      if (e == true) {
                          $(".hire").hide();
                          $("#subTable").empty();
                          document.getElementById("cphMain_hiddenSubCanclDbId").value = "";
                      }
                      else {
                          return false;
                      }
                  });
                  return false;
              }
              else {
                  $(".hire").hide();
                  $("#subTable").empty();
                  document.getElementById("cphMain_hiddenSubCanclDbId").value = "";
                  return false;
              }
          }
          function AlertClearAll() {
              if (confirmbox > 0) {
                  ezBSAlert({
                      type: "confirm",
                      messageText: "Are you sure you want clear all data in this page?",
                      alertType: "info"
                  }).done(function (e) {
                      if (e == true) {
                          window.location.href = "gen_approval_set.aspx";
                          return false;
                      }
                      else {
                          return false;
                      }
                  });
                  return false;
              }
              else {
                  window.location.href = "gen_approval_set.aspx";
                  return false;
              }
              return false;
          }
          var confirmbox = 0;
          function IncrmntConfrmCounter() {
              confirmbox++;
              return false;
          }


    </script>
<!---draggable_div_script_closed of myinaS---->

<!---help_pop_over_script--->
<script>
    $(document).ready(function () {
        $('[data-toggle="popover"]').popover();
    });
</script>
<!---help_pop_over_script_closed--->


<script type="text/javascript">
   
    function strDes(a, b) {
        if (a.value > b.value) return 1;
        else if (a.value < b.value) return -1;
        else return 0;
    }
   
    console.clear();
    (function () {
        $('#btnRight').click(function (e) {
            var selectedOpts = $('#cphMain_lstBox1 option:selected');
            var selectedOpts1 = $('#cphMain_lstBox3 option:selected');
            var selectedOpts2 = $('#cphMain_lstBox4 option:selected');
            var selectedOpts3 = $('#cphMain_lstBox5 option:selected');
           // var selecop = "";
            if (selectedOpts.length != 0) {
               
                $('#cphMain_lstprc').append($(selectedOpts).clone());
                $(selectedOpts).remove();
              
                e.preventDefault();
               
            }
          
            else if (selectedOpts1.length != 0) {
             
                $('#cphMain_lstpr').append($(selectedOpts1).clone());
                $(selectedOpts1).remove();

                e.preventDefault();
           
            }
            
           else if (selectedOpts2.length != 0) {
           
         
               $('#cphMain_lstdp').append($(selectedOpts2).clone());
                $(selectedOpts2).remove();

                e.preventDefault();
            }
           
           else if (selectedOpts3.length != 0) {

               $('#cphMain_lstdiv').append($(selectedOpts3).clone());
               $(selectedOpts3).remove();

             
               e.preventDefault();
           }
           else {
              
               alert("Please, select one option.");
             
               e.preventDefault();
              
                }
            $(this).val("Add to list");
            addlist();
        });

        $('#btnAllRight').click(function (e) {
            var selectedOpts = $('#cphMain_lstBox1 option');
            if (selectedOpts.length == 0) {
                alert("Please, select one option.");
                e.preventDefault();
            }

            $('#lstprc').append($(selectedOpts).clone());
            $(selectedOpts).remove();
            e.preventDefault();
        });

        $('#btnLeft').click(function (e) {
            var selectedOpts = $('#cphMain_lstprc option:selected');
            var selectedOpts1 = $('#cphMain_lstpr option:selected');
            var selectedOpts2 = $('#cphMain_lstdp option:selected');
            var selectedOpts3 = $('#cphMain_lstdiv option:selected');
            if (selectedOpts.length != 0) {
                $('#cphMain_lstBox1').append($(selectedOpts).clone());
                $(selectedOpts).remove();
                e.preventDefault();
            }
          else  if (selectedOpts1.length != 0) {
              
                $('#cphMain_lstBox3').append($(selectedOpts1).clone());
                $(selectedOpts1).remove();
                e.preventDefault();
          }
          else if (selectedOpts2.length != 0) {
             
              $('#cphMain_lstBox4').append($(selectedOpts2).clone());
              $(selectedOpts2).remove();
              e.preventDefault();
          }
          else if (selectedOpts3.length != 0) {

              $('#cphMain_lstBox5').append($(selectedOpts3).clone());
              $(selectedOpts3).remove();
              e.preventDefault();
          }
          else {
              alert("Please, select one option.");
              e.preventDefault();
               }
            $(this).val("Remove from list");
            addlist();

        });

        $('#btnAllLeft').click(function (e) {
            var selectedOpts = $('#lstprc option');
            if (selectedOpts.length == 0) {
                alert("Please, select one option.");
                e.preventDefault();
            }

            $('#cphMain_lstBox1').append($(selectedOpts).clone());
            $(selectedOpts).remove();
            e.preventDefault();
        });
    }(jQuery));

  
</script>
   
</asp:Content>

