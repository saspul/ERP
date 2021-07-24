<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="Payroll_Structure_Master.aspx.cs" Inherits="HCM_Payroll_Structure_master_Payroll_Structure_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
  

     <%--  <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>--%>
  
    <script src="/js/Common/Common.js"></script> 
  
<%-- <script src="../../js/New%20js/js/ajax.js"></script>--%>
   <%--<link href="/css/New css/pro_mng.css" rel="stylesheet" />--%>
   <%--  for giving pagination to the html table--%>

   <link href="../../css/New%20css/hcm_ns.css" rel="stylesheet" />

    
<link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i" rel="stylesheet">

    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>


    <style>
  .table-bordered>tbody>tr>td, .table-bordered>tbody>tr>th, .table-bordered>tfoot>tr>td, .table-bordered>tfoot>tr>th, .table-bordered>thead>tr>td, .table-bordered>thead>tr>th{padding:3px!important;}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
  
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
       <div>
  <ol class="breadcrumb">
        
        <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_Hcm.aspx">HCM</a></li>
        <li><a href="Payroll_Structure_list.aspx">Payroll Configuration</a></li>
         <li class="active">Add Payroll Configuration</li>
  </ol>
           </div>

    <div class="myAlert-top alert alert-success" id="success-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Success!</strong> Changes completed succesfully
</div>

<div class="myAlert-bottom alert alert-danger" id="danger-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Danger!</strong> Request not conmpleted
</div>

    <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con">Payroll Configuration</h1>

          <div class="top_br_container">
            <div class="top_br_1 br_1_et">

          <h2 class="h1_con h2_con" runat="server" id="lblEntry">Add Payroll</h2>

          <div class="form-group fg2 sa_640 sa_1">
              <label for="email" class="fg2_la1">Name:<span class="spn1">*</span></label>
             
  <asp:TextBox ID="txtPyrlName" runat="server" autocomplete="off" MaxLength="100" class="form-control fg2_inp1 inp_mst" placeholder="Name" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);" onkeyup="IncrmntConfrmCounter()" ></asp:TextBox>   
            </div>

            <div class="form-group fg2 sa_640 sa_1">
              <label for="email" class="fg2_la1">Code:</label>
              
                 <asp:TextBox ID="txtcode" runat="server" autocomplete="off" MaxLength="100" class="form-control fg2_inp1" placeholder="Code" onkeydown="return isTagEnter(event);" onkeypress="return isTagEnter(event);"  onkeyup="IncrmntConfrmCounter()"></asp:TextBox>   
            </div>

              <div class="form-group fg2 sa_640 sa_1">
                <label for="email" class="fg2_la1">Mode:<span class="spn1">*</span></label>
                    <asp:DropDownList ID="ddlmode" class="form-control fg2_inp1 inp_mst" runat="server"  required="">
                        <asp:ListItem Value="1">Addition</asp:ListItem>
                        <asp:ListItem Value="2">Deduction</asp:ListItem>
                    </asp:DropDownList>
              </div>

              <div class="form-group fg8 fg2_mr sa_fg4">
          <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1"></span></label>
          <div class="check1">
            <div class="">
              <label class="switch">
                <input id="cbxStatus" type="checkbox" runat="server"  checked="checked" onkeypress="return DisableEnter(event)" />
                <span class="slider_tog round"></span>
              </label>
            </div>
          </div>
        </div>

        <div class="form-group fg8 fg2_mr sa_fg4">
          <label for="email" class="fg2_la1 pad_l">Primary:<span class="spn1"></span></label>
          <div class="check1">
            <div class="">
              <label class="switch">
                <input id="cbxprimary" type="checkbox" runat="server"  checked="checked" onkeypress="return DisableEnter(event)" />
                <span class="slider_tog round"></span>
              </label>
            </div>
          </div>
        </div>

              <div class="clearfix"></div>
              <div class="free_sp" style="margin-top: 0px;"></div>

              <!-- <div class="fg4 fg2_hc4 sa_1">
          <label class="form1 mar_bo mar_tp">
            <span class="button-checkbox">
              <button type="button" class="btn-d" data-color="p" onclick="myFunct()" ng-model="all"></button>
              <input type="checkbox" class="hidden" />
            </span>
            <p class="pz_s">Available in manually updating module for addition/ deduction</p>
          </label>
        </div> -->
        <div class="form-group fg2 fg2_mr sa_fg4">
          <label for="email" class="fg2_la1 pad_l">Visible in manual entry:<span class="spn1"></span></label>
          <div class="check1">
            <div class="">
              <label class="switch">
               <input id="cbxvisible" type="checkbox" runat="server"   onkeypress="return DisableEnter(event)" />
                <span class="slider_tog round"></span>
              </label>
            </div>
          </div>
        </div>

        <div class="form-group fg5 fg2_blk fg2_blk1 sa_1">
          <label for="email" class="fg2_la1">Type:<span class="spn1"></span></label>
          <div class="row rl_prt">
            <div class="prtd_rat">
              <div class="form-check">
                
                <asp:RadioButton  ID ="Radiofix"  class="form-check-input"  runat="server" Checked="true"    GroupName ="Radiotype" />
                <label class="form-check-label" for="gridRadios1">Fixed</label>
               <asp:RadioButton  ID ="Radiovar"  class="form-check-input"  runat="server"    GroupName ="Radiotype" />
                <label class="form-check-label" for="gridRadios2">Variable</label>
              </div>
            </div>
          </div>
        </div>

       <div class="clearfix"></div>
        <div class="free_sp"></div>
        <div class="devider"></div>

        <div class="sub_cont pull-right">
          <div class="save_sec">
           <%-- <button type="submit" class="btn sub1">Save</button>
            <button type="submit" class="btn sub3">Save & Close</button>
            <button type="submit" class="btn sub4">Cancel</button>
            <button type="submit" class="btn sub2">Clear</button>--%>

              <asp:Button ID="btnSave"  runat="server" OnClientClick="return ValidatePyrl();" class="btn sub1" Text="Save" OnClick="btnSave_Click" />
              <asp:Button ID="btnSaveAndClose"  runat="server" OnClientClick="return ValidatePyrl();" class="btn sub3" Text="Save & Close" OnClick="btnSave_Click"  />
              <asp:Button ID="btnUpdate"  runat="server" OnClientClick="return ValidatePyrl();" class="btn sub1" Text="Update"  OnClick="btnUpdate_Click" />
              <asp:Button ID="btnUpdateAndClose"  runat="server" OnClientClick="return ValidatePyrl();" class="btn sub3" Text="Update & Close" OnClick="btnUpdate_Click" />
              <asp:Button ID="btnClear" runat="server"  class="btn sub2" OnClientClick="return AlertClearAll();" Text="Clear" />
              <asp:Button ID="btnCancel" runat="server"  class="btn sub4" OnClientClick="return ConfirmMessageList();" Text="Cancel" />
          </div>

          <%--<div class="edit_sec">
            <button type="submit" class="btn sub1">Update</button>
            <button type="submit" class="btn sub3">Update & Close</button>
            <button type="submit" class="btn sub2">Confirm</button>
            <button type="submit" class="btn sub4">Cancel</button>
          </div>--%>
        </div>
        
        
      </div>
    </div>
    </div>
  </div>
</div><!--content_container_closed------>
   
    
        
      </div>
   <%-- </div>
    </div>
  </div>
</div><--%>

<%--<a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
<i class="fa fa-save"></i>
</a>--%>

<a href="Payroll_Structure_list.aspx" type="button" class="list_b" title="Back to List">
<i class="fa fa-arrow-circle-left"></i>
</a>



    <script>


        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }


        function ValidatePyrl() {

            var ret = true;

            document.getElementById("<%=ddlmode.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtPyrlName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtcode.ClientID%>").style.borderColor = "";
           

            
            var Code = document.getElementById("<%=txtcode.ClientID%>").value.trim();
            var Name = document.getElementById("<%=txtPyrlName.ClientID%>").value.trim();

            if (document.getElementById("<%=cbxvisible.ClientID%>").checked == true) {


            if (Code == "") {
                document.getElementById("<%=txtcode.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtcode.ClientID%>").focus();
                ret = false;
            }

        }

             if (Name == "") {
                 document.getElementById("<%=txtPyrlName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtPyrlName.ClientID%>").focus();
                ret = false;
             }
            if (ret == false) {
                $("#danger-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
            }

            return ret;
        }




        function SuccessInsertion() {
            $("#success-alert").html("Payroll inserted successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function SuccessUpdation() {
            $("#success-alert").html("Payroll updated successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function DuplicationMsg() {
            document.getElementById("<%=txtPyrlName.ClientID%>").style.borderColor = "Red";
            $("#danger-alert").html("Duplication error! Payroll name cannot be duplicated.");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function DuplicationMsgC() {
            document.getElementById("<%=txtcode.ClientID%>").style.borderColor = "Red";
            $("#danger-alert").html("Duplication error! Payroll code cannot be duplicated.");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function Error() {
            $("#danger-alert").html("Some error occured!");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }





        function ConfirmMessageList() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "Payroll_Structure_list.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "Payroll_Structure_list.aspx";
                return false;
            }
            return false;
        }



        function AlertClearAll() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want clear all data in this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "Payroll_Structure_Master.aspx";
                        return false;
                    }
                    
                });
                return false;
            }
            else {
                window.location.href = "Payroll_Structure_Master.aspx";
                return false;
            }
            return false;
        }


    </script>


    
<%--<script>
    $(document).ready(function () {
        $("#hide").click(function () {
            $("p").hide();
        });
        $("#show").click(function () {
            $("p").show();
        });
    });
</script>

<script>
    $(document).ready(function () {
        $(".slide-toggle").click(function () {
            $(".content_sec1").animate({
                width: "18%"
            });
        });
    });

</script>--%>

<!--searchbox_list_script_opened------->

<script>
    function myFunction() {
        var input, filter, ul, li, a, i;
        input = document.getElementById("myInput");
        filter = input.value.toUpperCase();
        ul = document.getElementById("myUL");
        li = ul.getElementsByTagName("li");
        for (i = 0; i < li.length; i++) {
            a = li[i].getElementsByTagName("a")[0];
            if (a.innerHTML.toUpperCase().indexOf(filter) > -1) {
                li[i].style.display = "";
            } else {
                li[i].style.display = "none";
            }
        }
    }
</script>

<!----checkbox_started--->
<script type="text/javascript">
    //$(function () {
    //    $('.button-checkbox').each(function () {

    //        // Settings
    //        var $widget = $(this),
    //            $button = $widget.find('button'),
    //            $checkbox = $widget.find('input:checkbox'),
    //            color = $button.data('color'),
    //            settings = {
    //                on: {
    //                    icon: 'fa fa-check-square-o'
    //                },
    //                off: {
    //                    icon: 'fa fa-square-o gly2'
    //                }
    //            };

    //        // Event Handlers
    //        $button.on('click', function () {
    //            $checkbox.prop('checked', !$checkbox.is(':checked'));
    //            $checkbox.triggerHandler('change');
    //            updateDisplay();
    //        });
    //        $checkbox.on('change', function () {
    //            updateDisplay();
    //        });

    //        // Actions
    //        function updateDisplay() {
    //            var isChecked = $checkbox.is(':checked');

    //            // Set the button's state
    //            $button.data('state', (isChecked) ? "on" : "off");

    //            // Set the button's icon
    //            $button.find('.state-icon')
    //                .removeClass()
    //                .addClass('state-icon ' + settings[$button.data('state')].icon);

    //            // Update the button's color
    //            if (isChecked) {
    //                $button
    //                    .removeClass('btn-d')
    //                    .addClass('btn-' + color + ' active');
    //            }
    //            else {
    //                $button
    //                    .removeClass('btn-' + color)
    //                    .addClass('btn-d' + ' active');
    //            }
    //        }

    //        // Initialization
    //        function init() {

    //            updateDisplay();

    //            // Inject the icon if applicable
    //            if ($button.find('.state-icon').length == 0) {
    //                $button.prepend('<i class="state-icon ' + settings[$button.data('state')].icon + '"></i> ');
    //            }
    //        }
    //        init();
    //    });
    //});

</script>
<!--checkbox_closed-->

<%--<script>
    function openCity(evt, cityName) {
        var i, tabcontent, tablinks;
        tabcontent = document.getElementsByClassName("tab2content");
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

    // Get the element with id="defaultOpen" and click on it
    document.getElementById("defaultOpen").click();
</script>--%>


<%--<script type="text/javascript">
    $(function () {
        $("#datepicker").datepicker({
            autoclose: true,
            todayHighlight: true
        }).datepicker('update', new Date());
    });
</script>
<script type="text/javascript">
    $(function () {
        $("#datepicker1").datepicker({
            autoclose: true,
            todayHighlight: true
        }).datepicker('update', new Date());
    });
</script>
<script type="text/javascript">
    $(function () {
        $("#datepicker2").datepicker({
            autoclose: true,
            todayHighlight: true
        }).datepicker('update', new Date());
    });
</script>
<script type="text/javascript">
    $(function () {
        $("#datepicker3").datepicker({
            autoclose: true,
            todayHighlight: true
        }).datepicker('update', new Date());
    });
</script>
<script type="text/javascript">
    $(function () {
        $("#datepicker4").datepicker({
            autoclose: true,
            todayHighlight: true
        }).datepicker('update', new Date());
    });
</script>--%>
<!--date_picker--->

<%--<link href="../date_pick/datepicker.css" rel="stylesheet" type="text/css" /><!-- 
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script> -->
<script src="../date_pick/datepicker.js"></script>--%>

<!---date_picker_closed-->

<!--------tooltips------------>
<%--<script>
    $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });
</script>

<script>
    $(document).ready(function () {
        $('[data-toggle="tooltip1"]').tooltip();
    });
</script>

<!--add new div---->
<script>
    $(document).ready(function () {
        $("#btx1").click(function () {
            $("p").append(" <b>Appended text</b>.");
        });
    });
</script>--%>

<!--button_click_disable --->
<script>
    function myFunct() {
        //document.getElementById("myinpb").disabled = false;
        //document.getElementById("myinpc").disabled = true;
        //document.getElementById("myinpc1").disabled = true;
        //document.getElementById("myinpc2").disabled = true;
        //document.getElementById("myinpc3").disabled = true;
    }
</script>

<script>
    function mysave() {
        var x = document.getElementById("mysav");
        if (x.style.display === "block") {
            x.style.display = "none";
        } else {
            x.style.display = "block";
        }
    }
</script>

<script>
    function issue_chk() {
        var x = document.getElementById("is_chk");
        if (x.style.display === "block") {
            x.style.display = "none";
        } else {
            x.style.display = "block";
        }
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

<!------hide and visible div--->
<script>
    function sel1() {
        var x = document.getElementById('sel');
        if (x.style.display === 'none') {
            x.style.display = 'block';
        } else {
            x.style.display = 'none';
        }
    }
</script>
<!------hide and visible div_closed--->


<!-----table_sec_fixed--->
<%--<script type="text/javascript">
    // requires jquery library
    jQuery(document).ready(function () {
        jQuery(".main-table").clone(true).appendTo('#table-scroll').addClass('clone');
    });

</script>--%>
</asp:Content>

