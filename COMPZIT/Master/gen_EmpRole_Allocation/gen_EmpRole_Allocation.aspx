<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_EmpRole_Allocation.aspx.cs" EnableEventValidation="false"  Inherits="Master_gen_EmpRole_Allocation_gen_EmpRole_Allocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/hcm_ns.css" rel="stylesheet" />
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
     <script>
         var $au = jQuery.noConflict();
         $au(function () {
             $au('#cphMain_ddlDesignation').selectToAutocomplete1Letter();
             $au('#cphMain_ddlJobrole').selectToAutocomplete1Letter();
             $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
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
        //start-0006
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {
                IncrmntConfrmCounter();
            }
            var FramewrkId = '<%= Session["FRMWRK_ID"] %>';
            var FramewrkTyp = '<%= Session["FRMWRK_TYPE"] %>';
            if (FramewrkTyp == "1" && FramewrkId != "" && FramewrkId != null) {
                          
               
                    $(".btn_app").addClass("selected7");
                    $(".btn_app1").addClass("selected7");
                    $(".btn_sls1, .btn_aws1, .btn_guar1, .btn_hcm1, .btn_fin1, .btn_pro1").removeClass("selected7");
                    $(".btn_app1_a").fadeIn(600);
                    $(".btn_sls1_a, .btn_aws1_a, .btn_guar1_a, .btn_hcm1_a, .btn_fin1_a, .btn_pro1_a").fadeOut(200);
                    
                    document.getElementById("divAPPSelect").style.display = "none";
                    document.getElementById("divAPPCbx").style.display = "none";
                    document.getElementById("hApp").style.display = "none";
                    
            }
            else {
              
                var checkbox = document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value.split(',');

                for (var i = 0; i < checkbox.length; i++) {

                        if (checkbox[i].toString() == '1')//IF APP ADMINISTRATION
                        {
                            $(".btn_app").addClass("selected7");
                            $(".btn_app1").toggle(100);
                        }
                        else if (checkbox[i].toString() == '2')//IF SALES FORCE AUTOMATION 
                        {
                            $(".btn_sls1").toggle(100);
                            $(".btn_sls").addClass("selected7");
                        }
                        else if (checkbox[i].toString() == '3')//IF AUTO WORKSHOP MANAGEMENT
                        {
                            $(".btn_aws1").toggle(100);
                            $(".btn_aws").addClass("selected7");
                        }
                        else if (checkbox[i].toString() == '4')//IF GUARANTEE MANAGEMENT
                        {
                            $(".btn_guar1").toggle(100);
                            $(".btn_guar").addClass("selected7");
                        }
                        else if (checkbox[i].toString() == '5')//IF GUARANTEE MANAGEMENT
                        {
                            $(".btn_hcm1").toggle(100);
                            $(".btn_hcm").addClass("selected7");
                        }
                        else if (checkbox[i].toString() == '6')//IF FINANCE MANAGEMENT
                        {
                            $(".btn_fin1").toggle(100);
                            $(".btn_fin").addClass("selected7");
                        }
                        else if (checkbox[i].toString() == '7')//IF PROCUREMENT MANAGEMENT//PMS
                        {
                            $(".btn_pro1").toggle(100);
                            $(".btn_pro").addClass("selected7");
                        }

                }
            }
            var checkbox = document.getElementById("<%=HiddenFieldcbxChecked.ClientID%>").value.split(',');
            for (var i = 0; i < checkbox.length; i++) {
                $('input[value="' + checkbox[i].toString() + '"]').attr('checked', true);
            }
            if (document.getElementById("<%=lblEntry.ClientID%>").innerText == "VIEW EMPLOYEE ROLE ALLOCATION") {
                $(".btn_app").attr('disabled', true);
                $(".btn_sls").attr('disabled', true);
                $(".btn_aws").attr('disabled', true);
                $(".btn_guar").attr('disabled', true);
                $(".btn_hcm").attr('disabled', true);
                $(".btn_fin").attr('disabled', true);
                $(".btn_pro").attr('disabled', true);
                $('.btn-d,.btn-p').attr('disabled', 'true');
            }
        });
    </script>
    <script>

        //start-0006
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        function ConfirmMessage() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "gen_EmpRole_Allocation_List.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "gen_EmpRole_Allocation_List.aspx";

            }
            return false;
        }
        function AlertClearAll() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to clear all the data from this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "gen_EmpRole_Allocation.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "gen_EmpRole_Allocation.aspx";
                return false;
            }
            return false;
        }
        //stop-0006
    </script>
    <script type="text/javascript">
       
        function changeDesignation() {
            document.getElementById("<%=ddlJobrole.ClientID%>").options.length = 0;
            document.getElementById("<%=ddlEmployee.ClientID%>").options.length = 0;
            var dsgntnId = document.getElementById("<%=ddlDesignation.ClientID%>").value;
            var tableName = "dtTableDivision";
            var $coo = jQuery.noConflict();
            var ddlTestDropDownListXML = $coo(document.getElementById("<%=ddlJobrole.ClientID%>"));


            if (dsgntnId != "--Select Designation--") {
                $coo.ajax({
                    type: "POST",
                    url: "gen_EmpRole_Allocation.aspx/designationChange",
                    data: '{tableName:"' + tableName + '",dsgntnId:"' + dsgntnId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $coo("<option>--Select Job Role--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);
                        // Now find the Table from response and loop through each item (row).
                        $coo(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $coo(this).find('JOBRL_ID').text();
                            var OptionText = $coo(this).find('JOBRL_NAME').text();
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

        function changeJobrole() {
             
             document.getElementById("<%=ddlEmployee.ClientID%>").options.length = 0;
             var jobroleId = document.getElementById("<%=ddlJobrole.ClientID%>").value;
             var tableName = "dtTableDivision";
             var $coo = jQuery.noConflict();
             var ddlTestDropDownListXML = $coo(document.getElementById("<%=ddlEmployee.ClientID%>"));




            if (jobroleId != "--Select Job Role--") {
                $coo.ajax({
                    type: "POST",
                    url: "gen_EmpRole_Allocation.aspx/jobRoleChange",
                    data: '{tableName:"' + tableName + '",jobroleId:"' + jobroleId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $coo("<option>--Select Employee--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);
                        // Now find the Table from response and loop through each item (row).
                        $coo(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $coo(this).find('USR_ID').text();
                            var OptionText = $coo(this).find('USR_NAME').text();
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
        function SuccessConfirmation() {
            $("#success-alert").html("Employee role allocation inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("Employee role allocation updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }

        function Validate() {
           
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
           
            var DesgType = document.getElementById("<%=ddlDesignation.ClientID%>");
            var DesgTypeText = DesgType.options[DesgType.selectedIndex].text;
            
            var JobroleType = document.getElementById("<%=ddlJobrole.ClientID%>");
            var JobroleTypeText = JobroleType.options[JobroleType.selectedIndex].text;

            var EmpType = document.getElementById("<%=ddlEmployee.ClientID%>");
            var EmpTypeText = EmpType.options[EmpType.selectedIndex].text;

            document.getElementById("<%=ddlDesignation.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlJobrole.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "";
            $("div#divDesg input.ui-autocomplete-input").css("borderColor", "");
            $("div#divJobr input.ui-autocomplete-input").css("borderColor", "");
            $("div#divEmp input.ui-autocomplete-input").css("borderColor", "");
            if (EmpTypeText == "--Select Employee--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlEmployee.ClientID%>").focus();

                $("div#divEmp input.ui-autocomplete-input").css("borderColor", "red");
                $("div#divEmp input.ui-autocomplete-input").select();
                $("div#divEmp input.ui-autocomplete-input").focus();
                 ret = false;
            }

            if (JobroleTypeText == "--Select Job Role--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=ddlJobrole.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlJobrole.ClientID%>").focus();

                $("div#divJobr input.ui-autocomplete-input").css("borderColor", "red");
                $("div#divJobr input.ui-autocomplete-input").select();
                $("div#divJobr input.ui-autocomplete-input").focus();
                 ret = false;
             }
           

            if (DesgTypeText == "--Select Designation--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=ddlDesignation.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlDesignation.ClientID%>").focus();

                $("div#divDesg input.ui-autocomplete-input").css("borderColor", "red");
                $("div#divDesg input.ui-autocomplete-input").select();
                $("div#divDesg input.ui-autocomplete-input").focus();
                ret = false;
            }
           
            if (ret == false) {
                CheckSubmitZero();

            }
            else {

                document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value="";
                if($(".btn_app").hasClass("selected7"))
                {
                    document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value += ",1";
                    document.getElementById("<%=HiddenFieldApp.ClientID%>").value = "";
                    $('#cphMain_treeApp input[type=checkbox]:checked').each(function () {
                        document.getElementById("<%=HiddenFieldApp.ClientID%>").value += ","+$(this).val();
                    });                   
                }
                if($(".btn_sls").hasClass("selected7"))
                {
                    document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value += ",2";
                    document.getElementById("<%=HiddenFieldSfa.ClientID%>").value = "";
                    $('#cphMain_treeSfa input[type=checkbox]:checked').each(function () {
                        document.getElementById("<%=HiddenFieldSfa.ClientID%>").value += "," + $(this).val();
                    });
                }
                if($(".btn_aws").hasClass("selected7"))
                {
                    document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value += ",3";
                    document.getElementById("<%=HiddenFieldAwms.ClientID%>").value = "";
                    $('#cphMain_treeAwms input[type=checkbox]:checked').each(function () {
                        document.getElementById("<%=HiddenFieldAwms.ClientID%>").value += "," + $(this).val();
                    });
                }
                if($(".btn_guar").hasClass("selected7"))
                {
                    document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value += ",4";
                    document.getElementById("<%=HiddenFieldGms.ClientID%>").value = "";
                    $('#cphMain_treeGms input[type=checkbox]:checked').each(function () {
                        document.getElementById("<%=HiddenFieldGms.ClientID%>").value += "," + $(this).val();
                    });
                }
                if($(".btn_hcm").hasClass("selected7"))
                {
                    document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value += ",5";
                    document.getElementById("<%=HiddenFieldHcm.ClientID%>").value = "";
                    $('#cphMain_treeHcm input[type=checkbox]:checked').each(function () {
                        document.getElementById("<%=HiddenFieldHcm.ClientID%>").value += "," + $(this).val();
                    });
                }
                if($(".btn_fin").hasClass("selected7"))
                {
                    document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value += ",6";
                    document.getElementById("<%=HiddenFieldFms.ClientID%>").value = "";
                    $('#cphMain_treeFms input[type=checkbox]:checked').each(function () {
                        document.getElementById("<%=HiddenFieldFms.ClientID%>").value += "," + $(this).val();
                    });
                }
                if($(".btn_pro").hasClass("selected7"))
                {
                    document.getElementById("<%=HiddenFieldAppChecked.ClientID%>").value += ",7";
                    document.getElementById("<%=HiddenFieldPms.ClientID%>").value = "";
                    $('#cphMain_treePms input[type=checkbox]:checked').each(function () {
                        document.getElementById("<%=HiddenFieldPms.ClientID%>").value += "," + $(this).val();
                    });
                }

            }

            return ret;
        }


    </script>
    <script type="text/javascript">

        (function () {
            if ("-ms-user-select" in document.documentElement.style && navigator.userAgent.match(/IEMobile\/10\.0/)) {
                var msViewportStyle = document.createElement("style");
                msViewportStyle.appendChild(
                    document.createTextNode("@-ms-viewport{width:auto!important}")
                );
                document.getElementsByTagName("head")[0].appendChild(msViewportStyle);
            }
        })();
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
        function ClickCompzitModule() {
            IncrmntConfrmCounter();
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <ol class="breadcrumb">
       <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_Hcm.aspx">HCM</a></li>
      <li><a href="gen_EmpRole_Allocation_List.aspx">Employee Role Allocation</a></li>
        <li id="lblEntryB" runat="server" class="active">Add Employee Role Allocation</li>
      </ol>
   <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>

    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
    <asp:HiddenField ID="hiddenPrimaryDecision" runat="server" />
    <asp:HiddenField ID="HiddenFieldAppChecked" runat="server" />
    <asp:HiddenField ID="HiddenFieldcbxChecked" runat="server" />

     <asp:HiddenField ID="HiddenFieldApp" runat="server" />
     <asp:HiddenField ID="HiddenFieldSfa" runat="server" />
     <asp:HiddenField ID="HiddenFieldAwms" runat="server" />
     <asp:HiddenField ID="HiddenFieldGms" runat="server" />
     <asp:HiddenField ID="HiddenFieldHcm" runat="server" />
     <asp:HiddenField ID="HiddenFieldFms" runat="server" />
     <asp:HiddenField ID="HiddenFieldPms" runat="server" />

    <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2 id="lblEntry" runat="server">Add Employee Role Allocation</h2>        
        <div class="form-group fg2 sa_fg4 sa_640_i" id="divDesg">
          <label for="email" class="fg2_la1">Designation:<span class="spn1">*</span></label>
           <asp:DropDownList ID="ddlDesignation" class="form-control fg2_inp1 inp_mst" runat="server"  AutoPostBack="True"  OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged"></asp:DropDownList>        
        </div>
        <div class="form-group fg2 sa_fg4 sa_640_i1 sa_480" id="divJobr">
          <label for="email" class="fg2_la1">Job Role:<span class="spn1">*</span></label>
             <asp:DropDownList ID="ddlJobrole" class="form-control fg2_inp1 inp_mst" runat="server"  AutoPostBack="True"  OnSelectedIndexChanged="ddlJobrole_SelectedIndexChanged">
                <asp:ListItem Text="--Select Job Role--" Value="1"></asp:ListItem>
                </asp:DropDownList>
        </div>
        <div class="form-group fg2 sa_fg4 sa_640_i1 sa_480" id="divEmp">
          <label for="email" class="fg2_la1">Employee:<span class="spn1">*</span></label>
             <asp:DropDownList ID="ddlEmployee" class="form-control fg2_inp1 inp_mst" runat="server"  AutoPostBack="True"  OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged" >
                <asp:ListItem Text="--Select Employee--" Value="1"></asp:ListItem>
             </asp:DropDownList>
        </div>
        <div class="clearfix"></div>
        <div class="devider"></div>

          <h3>Products</h3>  
        

        <div class="clearfix"></div>
        
      <div class="col-md-12">
        <div class="col-md-2" id="divAPPCbx">
          <div class="prod_sect" id="divCompzitModuleList" runat="server">
            <button class="prod_ic k1 btn_app" onclick="return false;"><img src="\Images\New Images\images\des_ico\app_7.png" title="App Administration"></button>
            <button class="prod_ic k2 btn_sls" onclick="return false;"><img src="\Images\New Images\images\des_ico\sls7.png" title="Sales Force Automation"></button>
            <button class="prod_ic k3 btn_aws" onclick="return false;"><img src="\Images\New Images\images\des_ico\aws7.png" title="Auto Workshop Management System"></button>
            <button class="prod_ic k4 btn_guar" onclick="return false;"><img src="\Images\New Images\images\des_ico\guaran_7.png" title="Guarantee Management System"></button>
            <button class="prod_ic k5 btn_hcm" onclick="return false;"><img src="\Images\New Images\images\des_ico\hcm7.png" title="Human Capital Management"></button>
            <button class="prod_ic k6 btn_fin" onclick="return false;"><img src="\Images\New Images\images\des_ico\fin7.png" title="Finance Management System"></button>
            <button class="prod_ic k7 btn_pro" onclick="return false;"><img src="\Images\New Images\images\des_ico\pro7.png" title="Procurement Management System"></button>
          </div>
             <div id="divCompzitModuleNoList" runat="server" >
                    <asp:Label ID="Label1" runat="server" Text="No Modules Available."></asp:Label>
                </div>
        </div>
        <div class="col-md-10">
          <div class="col-md-4" id="divAPPSelect">
            <div class="prod_sel">
              <button class="prod_sel2 btn_app1 prod_ic btn_app1 tablinks hei_adbtn" style="display:none;" onclick="return false;">
                <img src="\Images\New Images\images\app_7.png"> App Administration<span class="spn1"></span></button>
            </div>
            <div class="prod_sel">
              <button class="prod_sel2 btn_sls1 prod_ic btn_app2 tablinks hei_adbtn" style="display:none;" onclick="return false;">
                <img src="\Images\New Images\images\sls7.png"> Sales Force Automation<span class="spn1"></span></button>
              </div>
            <div class="prod_sel">
              <button class="prod_sel2 btn_aws1 prod_ic btn_app3 tablinks hei_adbtn" style="display:none;" onclick="return false;">
                <img src="\Images\New Images\images\aws7.png"> Auto Workshop Management System<span class="spn1"></span></button>
              </div>
            <div class="prod_sel">
              <button class="prod_sel2 btn_guar1 prod_ic btn_app4 tablinks hei_adbtn" style="display:none;" onclick="return false;">
                <img src="\Images\New Images\images\guaran_7.png"> Guarantee Management System<span class="spn1"></span></button>
              </div>
            <div class="prod_sel">
              <button class="prod_sel2 btn_hcm1 prod_ic btn_app5 tablinks hei_adbtn" style="display:none;" onclick="return false;">
                <img src="\Images\New Images\images\hcm7.png"> Human Capital Management<span class="spn1"></span></button>
              </div>
            <div class="prod_sel">
              <button class="prod_sel2 btn_fin1 prod_ic btn_app6 tablinks hei_adbtn" style="display:none;" onclick="return false;">
                <img src="\Images\New Images\images\fin7.png"> Finance Management System<span class="spn1"></span></button>
              </div>
            <div class="prod_sel">
              <button class="prod_sel2 btn_pro1 prod_ic btn_app7 tablinks hei_adbtn" style="display:none;" onclick="return false;">
                <img src="\Images\New Images\images\pro7.png"> Procurement Management System<span class="spn1"></span></button>
              </div>
          </div>
          <div class="col-md-8">
          <div class="prod_tree" id="divTree" style="display:none;">

      <!---heirarchy_section_started-->

      <div class="">
        <!------tree_section_started-->
        <div class="box_pro_7 pro_pa">
          <div class="tree7">
            <div class="tree7 wi_tre_1">
            <ul id="myTab1" class="sc_hei btn_app1_a" style="display: none;">
              <h3 class="mar_bo1" id="hApp">App Administration</h3>

                <li id="treeApp" runat="server">                   
                  </li>
                </ul>


<!------tree_section_started-->
            <ul id="Ul1" class="sc_hei btn_sls1_a" style="display: none;">
              <h3>Sales Force Automation</h3>
                <li id="treeSfa" runat="server">                     
                    </li>
                  </ul>
<!------tree_section_closed----->

<!------tree_section_started-->
            <ul id="Ul2" class="sc_hei btn_aws1_a" style="display: none;">
              <h3>Auto Workshop Management System</h3>
                <li id="treeAwms" runat="server">                 
                  </li>
                </ul>
<!------tree_section_closed----->

<!------tree_section_started-->
            <ul id="Ul3" class="sc_hei btn_guar1_a" style="display: none;">
              <h3>Guarantee Management System</h3>
                <li id="treeGms" runat="server">                   
                  </li>
                  </ul>
              
<!------tree_section_closed----->

<!------tree_section_started-->
            <ul id="Ul4" class="sc_hei btn_hcm1_a" style="display: none;">
              <h3>Human Capital Management</h3>
                <li id="treeHcm" runat="server">                    
                  </li>
                </ul>
<!------tree_section_closed----->

<!------tree_section_started-->
            <ul id="Ul5" class="sc_hei btn_fin1_a" style="display: none;">
              <h3>Finance Management System</h3>
                <li id="treeFms" runat="server">                  
                  </li>
                </ul>
<!------tree_section_closed----->

<!------tree_section_started-->
            <ul id="Ul6" class="sc_hei btn_pro1_a" style="display: none;">
              <h3>Procurement Management System</h3>
                <li id="treePms" runat="server">                   
                  </li>
                </ul>



             </div>
           </div>
           </div>
           </div>

<!------tree_section_closed----->


            </div>
        </div>
      </div>
         <div class="sub_cont pull-right">
          <div class="save_sec">



                    <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return Validate(); " />
                    <asp:Button ID="btnUpdateClose" runat="server" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return Validate(); " />
                    <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();  " />
                    <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();  " />
                   <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2" Text="Clear"/>
                   <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />

          </div>
        </div>
        
        
      </div>
    </div>
    </div>
  </div>
     <div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">
           <asp:Button ID="btnUpdateF" runat="server" class="btn sub1 bt_b" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return Validate(); " />
                    <asp:Button ID="btnUpdateCloseF" runat="server" class="btn sub3 bt_b" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return Validate(); " />
                    <asp:Button ID="btnAddF" runat="server" class="btn sub1 bt_b" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();  " />
                    <asp:Button ID="btnAddCloseF" runat="server" class="btn sub3 bt_b" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();  " />
               <asp:Button ID="btnClearF" runat="server" OnClientClick="return AlertClearAll();"  class="btn sub2 bt_b" Text="Clear"/>
              <asp:Button ID="btnCancelF" runat="server" class="btn sub4 bt_b" Text="Cancel" OnClientClick="return ConfirmMessage();"  />
  </div> 
</div>
<a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
<i class="fa fa-save"></i>
</a>

       <!---back_button_fixed_section--->
  <a href="#" type="button" class="list_b" title="Back to List" onclick="return ConfirmMessage();" id="divList" runat="server">
    <i class="fa fa-arrow-circle-left"></i>
  </a>
      <a href="#" id="scroll" style="display: none;"><span class="fa fa-angle-up"></span></a>
<!---back_button_fixed_section--->
  <!--save_pop up_open-->
<script>
    function opensave() {
        document.getElementById("cphMain_mySave").style.width = "140px";
    }

    function closesave() {
        document.getElementById("cphMain_mySave").style.width = "0px";
    }
var acc = document.getElementsByClassName("accordion_role");
    var i;

    for (i = 0; i < acc.length; i++) {
        acc[i].addEventListener("click", function() {
            this.classList.toggle("active");
            var panel_role = this.nextElementSibling;
            if (panel_role.style.maxHeight) {
                panel_role.style.maxHeight = null;
            } else {
                panel_role.style.maxHeight = panel_role.scrollHeight + "px";
            } 
        });
    }
</script>
<!---accodition section_script_closed--->

<!----tree_jquery---->

<!-- <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script> -->
  <script type="text/javascript">
      $(function () {
          $('.tree li:has(ul)').addClass('parent_li').find(' > span').attr('title', 'Collapse this');
          $('.tree li.parent_li > span').on('click', function (e) {
              var children = $(this).parent('li.parent_li').find(' > ul > li');
              if (children.is(":visible")) {
                  children.hide('fast');
              } else {
                  children.show('fast');
              }
              e.stopPropagation();
          });
      });
  </script>
<!----tree_jquery_closed---->


<!----module section_details_started---->
<script>
    $(document).ready(function(){
        $(".module1").click(function(){
            $(".modle_detl1").toggle(100);
        });
    });
</script>
<script>
    $(document).ready(function(){
        $(".module2").click(function(){
            $(".modle_detl2").toggle(100);
        });
    });
</script>
<script>
    $(document).ready(function(){
        $(".module3").click(function(){
            $(".modle_detl3").toggle(100);
        });
    });
</script>
<script>
    $(document).ready(function(){
        $(".module4").click(function(){
            $(".modle_detl4").toggle(100);
        });
    });
</script>
<script>
    $(document).ready(function(){
        $(".module5").click(function(){
            $(".modle_detl5").toggle(100);
        });
    });
</script>
<script>
    $(document).ready(function(){
        $(".module6").click(function(){
            $(".modle_detl6").toggle(100);
        });
    });
</script>
<script>
    $(document).ready(function(){
        $(".module7").click(function(){
            $(".modle_detl7").toggle(100);
        });
    });
</script>

<!----module section_details_closed---->

<script type="text/javascript">
    $( "#war-btn" ).click(function() {
        $( "div.war" ).fadeIn( 200 ).delay( 500 ).fadeOut( 400 );
    });
</script>

<script>
    $(document).ready(function(){
        $(".imprt_o").click(function(){
            $(".import_opt").toggle(300);
        });
    });
</script>

  <script type="text/javascript">
      $(document).ready(function(){ 
          $(".cont_contr").scroll(function(){ 
              if ($(this).scrollTop() > 100) { 
                  $('#scroll').fadeIn(); 
              } else { 
                  $('#scroll').fadeOut(); 
              } 
          }); 
          $('#scroll').click(function(){ 
              $(".cont_contr").animate({ scrollTop: 0 }, 600); 
              return false; 
          }); 
      });
</script>

<!----prodct selected script_section started--->
<script>
    $(document).ready(function(){
        $(".k1").click(function(){
            $(".k1").toggleClass("selected7");
        });
    });
</script>
<script>
    $(document).ready(function(){
        $(".k2").click(function(){
            $(".k2").toggleClass("selected7");
        });
    });
</script>
<script>
    $(document).ready(function(){
        $(".k3").click(function(){
            $(".k3").toggleClass("selected7");
        });
    });
</script>
<script>
    $(document).ready(function(){
        $(".k4").click(function(){
            $(".k4").toggleClass("selected7");
        });
    });
</script>
<script>
    $(document).ready(function(){
        $(".k5").click(function(){
            $(".k5").toggleClass("selected7");
        });
    });
</script>
<script>
    $(document).ready(function(){
        $(".k6").click(function(){
            $(".k6").toggleClass("selected7");
        });
    });
</script>
<script>
    $(document).ready(function(){
        $(".k7").click(function(){
            $(".k7").toggleClass("selected7");
        });
    });
</script>
<!----prodct selected script_section closed-->

<!----tree_jquery---->

<!-- <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script> -->
  <script type="text/javascript">
      $(function () {
          $('.tree li:has(ul)').addClass('parent_li').find(' > span').attr('title', 'Collapse this branch');
          $('.tree li.parent_li > span').on('click', function (e) {
              var children = $(this).parent('li.parent_li').find(' > ul > li');
              if (children.is(":visible")) {
                  children.hide('fast');
                  $(this).attr('title', 'Expand this branch').find(' > i').addClass('icon-plus-sign').removeClass('icon-minus-sign');
              } else {
                  children.show('fast');
                  $(this).attr('title', 'Collapse this branch').find(' > i').addClass('icon-minus-sign').removeClass('icon-plus-sign');
              }
              e.stopPropagation();
          });
      });
  </script>
<!----tree_jquery_closed---->

<!----tab_script_for heirarchy page---->
<script>
    function openCity(evt, cityName) {
        var i, tabcontent, tablinks;
        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }
        tablinks = document.getElementsByClassName("tablinks");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].className = tablinks[i].className.replace(" active", "");
        }
        document.getElementById(cityName).style.display = "block";
        evt.currentTarget.className += " active";
    }
</script>

<!----heirarchy_section_script_started--->
<script>
    $(document).ready(function(){
        $(".organiser").click(function(){
            $(".hire").toggle();
        });
    });
</script>
<!----heirarchy_section_script_closed-->

<script>
    function ck_tog() {
        if (document.getElementById("ck_toz").checked==true) {
            document.getElementById("ck_toz1").checked = false;
        }else
        {
            document.getElementById("ck_toz1").checked = true;
        }  
    }
    function ck_tog1() {
        if (document.getElementById("ck_toz1").checked==true) {
            document.getElementById("ck_toz").checked = false;
        }else
        {
            document.getElementById("ck_toz").checked = true;
        }  
    }
</script>

<script>
    onload = function() {

        // create the tree
        var theTree = new wijmo.nav.TreeView('#theTree', {
            itemsSource: getData(),
            displayMemberPath: 'header',
            childItemsPath: 'items'
        });
        theTree.selectedItem = theTree.itemsSource[0];

        // handle buttons
        document.getElementById('btnFirst').addEventListener('click', function () {
            var newItem = { header: document.getElementById('theInput').value },
                node = theTree.selectedNode;
            if (node) {
                theTree.selectedNode = node.addChildNode(0, newItem);
            } else {
                theTree.selectedNode = theTree.addChildNode(0, newItem);
            }
        });
        document.getElementById('btnLast').addEventListener('click', function () {
            var newItem = { header: document.getElementById('theInput').value },
                node = theTree.selectedNode;
            if (node) {
                var index = node.nodes ? node.nodes.length : 0;
                theTree.selectedNode = node.addChildNode(index, newItem);
            } else {
                var index = theTree.nodes ? theTree.nodes.length : 0;
                theTree.selectedNode = theTree.addChildNode(index, newItem);
            }
        });
        document.getElementById('btnNoSel').addEventListener('click', function () {
            theTree.selectedNode = null;
        });

        // create some data
        function getData() {
            return [
              { header: 'Parent 1', items: [
                { header: 'Child 1.1' },
                { header: 'Child 1.2' },
                { header: 'Child 1.3' }]
              },
              { header: 'Parent 2', items: [
                { header: 'Child 2.1' },
                { header: 'Child 2.2' }]
              },
              { header: 'Parent 3', items: [
                { header: 'Child 3.1' }]
              }
            ];
        }
    }
</script>

<script>
    $(document).ready(function(){
        $(".hei_adbtn").click(function(){
            $("#add_hei").fadeIn();
            $(".sc_hei1").hide();
            $(".sc_hei").show();
            $("#ceo, #sal, #man").fadeOut(100);
            $(".man, .ceo, .sal").removeClass("act_hie");
        });
        $(".ceo_btn").click(function(){
            $("#ceo").fadeIn();
            $("#add_hei, #sal, #man").fadeOut(100);
            $(".ceo").addClass("act_hie");
            $(".add_hei, .sal, .man").removeClass("act_hie");
        });
        $(".sal_btn").click(function(){
            $("#sal").fadeIn();
            $("#add_hei, #ceo, #man").fadeOut(100);
            $(".sal").addClass("act_hie");
            $(".man, .ceo").removeClass("act_hie");
        });
        $(".man_btn").click(function(){
            $("#man").fadeIn();
            $("#add_hei, #ceo, #sal").fadeOut(100);
            $(".man").addClass("act_hie");
            $(".ceo, .sal").removeClass("act_hie");
        });
    });
</script>

<!---new_script-->

  <script>
      $(document).ready(function(){
          $(".btn_app").click(function(){
              $(".btn_app1").toggle(100);
              IncrmntConfrmCounter();
              return false;
          });
          $(".btn_sls").click(function(){
              $(".btn_sls1").toggle(100);
              IncrmntConfrmCounter();
              return false;
          });
          $(".btn_aws").click(function(){
              $(".btn_aws1").toggle(100);
              IncrmntConfrmCounter();
              return false;
          });
          $(".btn_guar").click(function(){
              $(".btn_guar1").toggle(100);
              IncrmntConfrmCounter();
              return false;
          });
          $(".btn_hcm").click(function(){
              $(".btn_hcm1").toggle(100);
              IncrmntConfrmCounter();
              return false;
          });
          $(".btn_fin").click(function(){
              $(".btn_fin1").toggle(100);
              IncrmntConfrmCounter();
              return false;
          });
          $(".btn_pro").click(function(){
              $(".btn_pro1").toggle(100);
              IncrmntConfrmCounter();
              return false;
          });

          $(".btn_app1").click(function(){
              $(".btn_app1").addClass("selected7");
              $(".btn_sls1, .btn_aws1, .btn_guar1, .btn_hcm1, .btn_fin1, .btn_pro1").removeClass("selected7");
              $(".btn_app1_a").fadeIn(600);
              $(".btn_sls1_a, .btn_aws1_a, .btn_guar1_a, .btn_hcm1_a, .btn_fin1_a, .btn_pro1_a").fadeOut(200);
              document.getElementById('divTree').style.display = "";
              
              return false;
          });
          $(".btn_sls1").click(function(){
              $(".btn_sls1").addClass("selected7");
              $(".btn_app1, .btn_aws1, .btn_guar1, .btn_hcm1, .btn_fin1, .btn_pro1").removeClass("selected7");
              $(".btn_sls1_a").fadeIn(600);
              $(".btn_app1_a, .btn_aws1_a, .btn_guar1_a, .btn_hcm1_a, .btn_fin1_a, .btn_pro1_a").fadeOut(200);
              document.getElementById('divTree').style.display = "";
              return false;
          });
          $(".btn_aws1").click(function(){
              $(".btn_aws1").addClass("selected7");
              $(".btn_sls1, .btn_app1, .btn_guar1, .btn_hcm1, .btn_fin1, .btn_pro1").removeClass("selected7");
              $(".btn_aws1_a").fadeIn(600);
              $(".btn_sls1_a, .btn_app1_a, .btn_guar1_a, .btn_hcm1_a, .btn_fin1_a, .btn_pro1_a").fadeOut(200);
              document.getElementById('divTree').style.display = "";
              return false;
          });
          $(".btn_guar1").click(function(){
              $(".btn_guar1").addClass("selected7");
              $(".btn_sls1, .btn_aws1, .btn_app1, .btn_hcm1, .btn_fin1, .btn_pro1").removeClass("selected7");
              $(".btn_guar1_a").fadeIn(600);
              $(".btn_sls1_a, .btn_aws1_a, .btn_app1_a, .btn_hcm1_a, .btn_fin1_a, .btn_pro1_a").fadeOut(200);
              document.getElementById('divTree').style.display = "";
              return false;
          });
          $(".btn_hcm1").click(function(){
              $(".btn_hcm1").addClass("selected7");
              $(".btn_sls1, .btn_aws1, .btn_guar1, .btn_app1, .btn_fin1, .btn_pro1").removeClass("selected7");
              $(".btn_hcm1_a").fadeIn(600);
              $(".btn_sls1_a, .btn_aws1_a, .btn_guar1_a, .btn_app1_a, .btn_fin1_a, .btn_pro1_a").fadeOut(200);
              document.getElementById('divTree').style.display = "";
              return false;
          });
          $(".btn_fin1").click(function(){
              $(".btn_fin1").addClass("selected7");
              $(".btn_sls1, .btn_aws1, .btn_guar1, .btn_hcm1, .btn_app1, .btn_pro1").removeClass("selected7");
              $(".btn_fin1_a").fadeIn(600);
              $(".btn_sls1_a, .btn_aws1_a, .btn_guar1_a, .btn_hcm1_a, .btn_app1_a, .btn_pro1_a").fadeOut(200);
              document.getElementById('divTree').style.display = "";
              return false;
          });
          $(".btn_pro1").click(function(){
              $(".btn_pro1").addClass("selected7");
              $(".btn_sls1, .btn_aws1, .btn_guar1, .btn_hcm1, .btn_fin1, .btn_app1").removeClass("selected7");
              $(".btn_pro1_a").fadeIn(600);
              $(".btn_sls1_a, .btn_aws1_a, .btn_guar1_a, .btn_hcm1_a, .btn_fin1_a, .btn_app1_a").fadeOut(200);
              document.getElementById('divTree').style.display = "";
              return false;
          });
      });
</script>

<!---accodition section_script_opened--->
<script>
    var acc = document.getElementsByClassName("accordion_role");
    var i;

    for (i = 0; i < acc.length; i++) {
        acc[i].addEventListener("click", function() {
            this.classList.toggle("active");
            var panel_role = this.nextElementSibling;
            if (panel_role.style.maxHeight) {
                panel_role.style.maxHeight = null;
            } else {
                panel_role.style.maxHeight = panel_role.scrollHeight + "px";
            } 
        });
    }
</script>
<!---accodition section_script_closed--->

<!----tree_jquery---->

<!-- <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script> -->
  <script type="text/javascript">
      $(function () {
          $('.tree7 li:has(ul)').addClass('parent_li').find(' > span').attr('title', 'Collapse this');
          $('.tree7 li.parent_li > span').on('click', function (e) {
              var children = $(this).parent('li.parent_li').find(' > ul > li');
              if (children.is(":visible")) {
                  children.hide('fast');
              } else {
                  children.show('fast');
              }
              e.stopPropagation();
          });
          $("div#divDesg input.ui-autocomplete-input").select();
          $("div#divDesg input.ui-autocomplete-input").focus();
      });
  </script>
<!----tree_jquery_closed---->
    <style>
         .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            width: 218px;
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
                    background-color: #08c;
                    color: #fff;
                    font-family: Calibri;
                }
    </style>
</asp:Content>

