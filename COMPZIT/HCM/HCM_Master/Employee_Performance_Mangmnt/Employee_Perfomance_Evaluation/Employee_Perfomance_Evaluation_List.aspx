<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="Employee_Perfomance_Evaluation_List.aspx.cs" Inherits="Employee_Perfomance_Evaluation_Employee_Perfomance_Evaluation_List" %>

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
    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="/js/jQueryUI/jquery-ui.min.js"></script>
    <script src="/js/jQueryUI/jquery-ui.js"></script>
    <script src="/js/datepicker/bootstrap-datepicker.js"></script>
    <link href="/js/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="/js/HCM/Common.js"></script>

    <script>
    
       
        var $noCon1= jQuery.noConflict();
        $noCon1(window).load(function () {
           
           // alert(document.getElementById("<%=Hiddencncl.ClientID%>").value);
           
            LoadEmpList();   // emp0025
      
         //   loadTableDesg();
           
        });



        function LoadEmpList() {      // emp0025


            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';



            var responsiveHelper_datatable_fixed_column = undefined;


            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };

            /* COLUMN FILTER  */
            var otable = $NoConfi3('#datatable_fixed_column').DataTable({
                //"bfilter": false,
                //"binfo": false,
                //"blengthchange": false
                //"bautowidth": false,
               // "bpaginate": false,
                //"bstatesave": true // saves sort state using localstorage
                "bDestroy": true,

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
                }

            });

            // custom toolbar
            //$NoConfi("div.toolbar").html('<div class="text-right"><select / style="Margin-top:10px;"></div>');

            // Apply the filter
            $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                otable
                    .column($NoConfi(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();

            });




            /* END COLUMN FILTER */

        }

       
        function SuccessInsert() {



            $noCon("#success-alert").html("Performance evaluation saved successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        }
        function SuccessUpdate() {



            $noCon("#success-alert").html("Performance evaluation updatesd successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        }
        function ConfirmError() {



            $noCon("#divWarning").html("Performance evaluation already confirmed.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#divWarning").alert();

            return false;
        }
        function SuccessConfirm() {



            $noCon("#success-alert").html("Performance evaluation confirmed successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        }

        function validateEvaluation() {
            var ret = true;
           document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "none";
            document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "none";
            var txtfrmDt = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var txtToDate = document.getElementById("<%=txtTodate.ClientID%>").value;
            var flag = 0;
           

        
            if (txtToDate == "" && txtfrmDt == "")
            {

                document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtFromDate.ClientID%>").focus();
                 $noCon("#divWarning").html("Please select a date range.");
                 $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                 });
                 // $noCon("#divWarning").alert();
                 $noCon1(window).scrollTop(0);
                 flag = 1;
                 ret = false;



            }
           


            else if (txtfrmDt == "") {
                document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtFromDate.ClientID%>").focus();
                $noCon("#divWarning").html("Please select a date range.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                // $noCon("#divWarning").alert();
                $noCon1(window).scrollTop(0);
                flag = 1;

                ret = false;

           }
         else   if (txtToDate == "") {
             document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtTodate.ClientID%>").focus();
                 $noCon("#divWarning").html("Please select a date range.");
                 $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                 });
                 // $noCon("#divWarning").alert();
                 $noCon1(window).scrollTop(0);


                 ret = false;
             }
            if (flag == 0) {

              
                // alert(frmdate);
                var arrDatePickerDate1 = txtfrmDt.split("-");
                txtfrmDt = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
                var arrDatePickerDate1 = txtToDate.split("-");
                txtToDate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

                if ((txtfrmDt!="" && txtToDate!="") && txtfrmDt >= txtToDate) {
                    document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTodate.ClientID%>").focus();
                    $noCon("#divWarning").html("From date should be greater than To date");
                    $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    // $noCon("#divWarning").alert();
                    $noCon1(window).scrollTop(0);

                    ret = false;
                }
            }

            return ret;
        }


    

        //function loadTableDesg() {

        //    $noCon(function () {
        //        $noCon('#dialog_simple').dialog({
        //            autoOpen: false,
        //            width: 600,
        //            resizable: false,
        //            modal: true,
        //            title: "Employee conduct category",
        //        });
        //    });
        //}
      


      
        var $noCon = jQuery.noConflict();
      
      
        //for search option
        var $NoConfi = jQuery.noConflict();
        var $NoConfi3 = jQuery.noConflict();


    
        function getdetails(href) {
            window.location = href;
            return false;
        }
      


        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {
              
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                //  prm.add_initializeRequest(InitializeRequest);
                prm.add_endRequest(EndRequest);
            });
        })(jQuery);

        function EndRequest(sender, args) {
            // after update occur on UpdatePanel re-init the Autocomplete
            LoadEmpList();

        }
        function DeletePerfomanceTmplt(Id) {
           // alert(Id);
        }


        
        var $con2 = jQuery.noConflict();
    
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

       <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenEditID" runat="server" />
    <asp:HiddenField ID="hiddenViewID" runat="server" />
    <asp:HiddenField ID="hiddenCnclrsnMust" runat="server" />
    <asp:HiddenField ID="hiddenDeleteID" runat="server" />
        <asp:HiddenField ID="HiddenRoleEdit" runat="server" />
      <asp:HiddenField ID="HiddenResponseType" runat="server" />
      <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
     <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
       <asp:HiddenField ID="Hiddencnclsts" runat="server" />
           <asp:HiddenField ID="Hiddencncl" runat="server" />
       <asp:HiddenField ID="hiddenEnableCancl" runat="server" /> 
     <asp:HiddenField ID="HiddenCorpId" runat="server" /> 
     <asp:HiddenField ID="Hiddenorgid" runat="server" /> 


    <asp:Button ID="btnEdit" runat="server" Text="Button" style="display:none"/>
      <div class="alert alert-danger" id="divWarning" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>
              <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button> 
        </div>
     
        <div class="cont_rght">

                   
        
        

        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/PERFORMANCE EVALUATION.png" style="vertical-align: middle;" />
          Performance Evaluation List
        </div >
                        

         <div style="width: 99%; float: left;  border: 1px solid #c3c3c3;height: 50px; background:#fafafa;margin-bottom: 7px;margin-top: 2%;height: auto;">

                    <div class="eachform" style="width: 24%; margin-top: 1.5%; float: left; margin-left: 3%;">
                <h2>From Date*</h2>
                
               <div id="div1" class="input-append date" style="margin-right: 16%; width: 39%; float: right;">

                 
                   
                        <asp:TextBox ID="txtFromDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  onkeypress="return DisableEnter(event)"  Height="30px" Width="71%" Style="float: left; width: 97.6%; height: 30px;" ></asp:TextBox>

                        <input type="image" runat="server" id="Image1" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style="  height:30px; width:31px;" />
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




                        <p style="visibility: hidden">Please enter</p>
                       </div>

                        

              

            </div>
                            <div class="eachform" style="width: 28%; margin-top: 1.5%; float: left; margin-left: 8%;">
                <h2>To Date*</h2>
                
               <div id="div2" class="input-append date" style="float: right; margin-right: 31%; width: 33%;">

                        <asp:TextBox ID="txtTodate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeypress="return DisableEnter(event)"  Height="30px" Width="71%" Style="height: 30px; float: left; width: 94.6%;"></asp:TextBox>

                        <input type="image" runat="server" id="Image2" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style="  height:30px; width:31px;" />
                    <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                            
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#div2').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                // startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div> 
               
              <div class="eachform" style="width: 36%; margin-top: 1.5%; float: left; display:none ">
                <h2> Response Type*</h2>
                
               <div id="div5" class="input-append date" style="float: left; margin-left: 10%; width: 51%;">

                     
                   <asp:DropDownList ID="ddlResponsType" class="form1"   Height="30px" Width="71%" Style="height: 30px; width: 90.6%; margin-top: 0%; float: left; margin-left: 12.7%;" runat="server"  >   

                        <asp:ListItem Text="--Select Response Type--" Value="--Select Response Type--"></asp:ListItem>
                        <asp:ListItem Text="SELF" Value="0"></asp:ListItem>
                    <asp:ListItem Text="RERPORTING OFFICER" Value="1"></asp:ListItem>
                       <asp:ListItem Text="DIVISION MANAGER" Value="2"></asp:ListItem>
                       <asp:ListItem Text="GENERAL MANAGER" Value="3"></asp:ListItem>
                       <asp:ListItem Text="HR" Value="4"></asp:ListItem>
                   </asp:DropDownList>
                      
                       </div>
            
                    
            </div>
                 <%-- <div style="width: 10%; float: left;margin-left: 85%;margin-bottom: 1%;">     --%>          
                        <asp:Button ID="btnCnclSearch" style=" width: 101px; margin-top: 1.5%; float: right; margin-right: 4%;" runat="server" class="btn btn-primary" Text="Search" OnClientclick="return validateEvaluation();"   OnClick="btnCnclSearch_Click"  />     
            <%--   </div>--%>
             

                        </div>

         <div id="divList" runat="server" class="widget-body" style="margin-top:2%;width: 99%;">
             <br />
             <br />
         </div>

               
               <%--------------------------------View for error Reason--------------------------%>


        <div id="dialog_simple" title="Dialog Simple Title"  style="display:none;">
            <!-- widget content -->

            <div class="widget-body no-padding" id="divCancelPopUp">

                <div class="alert alert-danger fade in" id="divErrMsgCnclRsn" style="display: none; margin-top: 1%">

                    <i class="fa-fw fa fa-times"></i>
                    <strong>Error!</strong>&nbsp;<label id="lblErrMsgCancelReason"> Please fill this out</label>
                </div>

                <div style="width: 100%; float: left; clear: both; margin-top: 5%">

                    <section style="width: 95%; margin-left: 5%;">
                        <label class="lblh2" style="float: left; width: 35%;">Cancel Reason*</label>

                        <label class="input" style="float: left; width: 60%;">
                            <textarea name="txtCancelReason" rows="2" cols="20" id="txtCancelReason" class="form-control" style="text-transform: uppercase; resize: none;"   onkeydown="textCounter(txtCancelReason,500)" onkeyup="textCounter(txtCancelReason,500)"></textarea>
                        </label>

                    </section>
                </div>

                <div class="ui-dialog-buttonpane ui-widget-content ui-helper-clearfix" style="border-top: none;">
                    <div class="ui-dialog-buttonset">
                        <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-danger"><i class="fa fa-trash-o"></i>&nbsp; SAVE</button>
                        <button type="button" class="btn btn-default" onclick="return CloseCancelView();"  ><i class="fa fa-times"></i>&nbsp; Cancel</button>
                    </div>

                </div>
            </div>

     </div>

   </div>
    <style>
        .fa {
            font-size: large;
        }
        .alert-danger {
    border-color: #953b39;
    color: #fff;
    background-color: #c26565;
    text-shadow: none;
}
        .alert {
    margin-bottom: 20px;
    margin-top: 0;
  
    border-width: 0;
        border-left-width: 0px;
    border-left-width: 5px;
    padding: 10px;
    border-radius: 0;
    -webkit-border-radius: 0;
    -moz-border-radius: 0;
}

       input[type="search"] {

    -webkit-box-sizing: content-box;
    -moz-box-sizing: content-box;
    box-sizing: content-box;
    -webkit-appearance: textfield;
    height: 16px;
    margin-bottom: 3px;

}

        .btn-primary {
    color: #fff;
    background-color: #3276b1;
    border-color: #2c699d;
}
        .alert-success {
    border-color: #8ac38b;
    color: #356635;
    background-color: #cde0c4;
}
    </style>

</asp:Content>

