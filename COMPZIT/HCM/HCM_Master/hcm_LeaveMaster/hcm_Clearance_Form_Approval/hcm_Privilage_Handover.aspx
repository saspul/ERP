<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Privilage_Handover.aspx.cs" Inherits="HCM_HCM_Master_hcm_LeaveMaster_hcm_Clearance_Form_Approval_hcm_Privilage_Handover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
       <script src="/JavaScript/jquery-1.8.3.min.js"></script>
     <script src="/JavaScript/JavaScriptPagination2.js"></script>
        <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <!-- include jQuery -->
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.js"></script>
<!-- include BlockUI -->
    <script src="../../../../demo/jquery.blockUI.js"></script>

<script>
// invoke blockUI as needed -->
    $(document).on('click', '#cphMain_btnOnBoard', function () {
        alert();
        $p(document).ajaxStart($p.blockUI).ajaxStop($p.unblockUI);      // $p.blockUI("sfdsfd");
});
</script>
    <style>
        #growlCSS {
				width:350px;
				top:10px;
				left:	0	;
				right:		10px;
				border:		none;
				padding:	5px;
				opacity:	0.6;
				cursor:		default;
				color:		#fff;
				background-color: #000;
				-webkit-border-radius:10px;
				-moz-border-radius:	10px;
				border-radius:		10px;
			}

    </style>
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            //alert();
            $p(document).on('click', '#btnOnBoard', function () {
                alert();
                $.blockUI();
                $p('#ReportTable').DataTable({
                    "pagingType": "full_numbers",
                    "bSort": true,
                    "pageLength": 25
                });
            });
        });
    </script>
    <style>
        #cphMain_divReport {
            float: left;
            width: 93.5%;
        }



        #TableRprtRow .tdT {
            line-height: 100%;
        }
  </style>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
         
              document.getElementById("freezelayer").style.display = "none";
              document.getElementById('MymodalProcessSingle').style.display = "none";
              });


          </script>
    
    <script>
     function CloseProcessSingle() {
            document.getElementById("MymodalProcessSingle").style.display = "none";
            document.getElementById("freezelayer").style.display = "none";

           



            $('#MymodalProcessSingle').find(':input').prop('disabled', false);
        }

     function ValidateProcessSingle() {
         getdata();
            var ret = true;
          
        


              return ret;
          }

          function ValidateProcessMulty() {
              var ret = true;
              if (CheckIsRepeat() == true) {
              }
              else {
                  ret = false;
                  return ret;
              }

           

              return ret;

          }
        
           function ShowProcess_Multy() {

               document.getElementById("MymodalProcessSingle").style.display = "";
            
        var $p = jQuery.noConflict();
       
          
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
            });
     
  
        }

           function CloseCancelView() {
            document.getElementById("MymodalProcessSingle").style.display = "none";
        }

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <div>
              <input type="button" id="btnOnBoard" runat="server" style="width: 114px; float: left; margin-left: 0.5%; margin-top: 0%; background: #127c8f; border: 2px solid #b12709;" class="save" value="OnBoard" onclick="ShowProcess_Multy()" />
          <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: black; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.8; z-index: 29; height: auto !important;"
        class="freezelayer" id="freezelayer">
    </div>
         </div>

        <div id="MymodalProcessSingle">
                <!-- Modal content -->
                <div class="block"style="overflow:auto">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="return CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
                      
                      <h3 style="font-family: Calibri; font-size: 18px; margin-left: 40%; padding-bottom: 0.7%; padding-top: 0.6%;">Mark The Status Assign</h3>
                    </div>
                    <div class="modal-bodyCancelView1">
                         

        <div style="padding-top: 0%;margin-left:3%;float:left;width:100%">
                 <div id="div1" style="display:none">
            <img id="img1" src="" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            </div>
                        <div id="divmodalPopup"  runat="server" style="width: 98%; margin: 1%; padding-top: 0.6%;">



                        </div>
              <asp:Button ID="btnProcessSingleSave" class="save" runat="server" Text="Submit" Style="width: 105px; float: left; margin-left: 34%;" OnClientClick="return ValidateProcessSingle()" OnClick="btnProcessSingleSave_Click"  />
                <%--<input type="button" id="btnProcessMultyClr" class="save" style="width: 90px; float: left;" value="Clear" />--%>
                <input type="button" id="btnProcessSingleCancel" onclick="ConfirmCancel();" class="save" style="width: 90px; float: left;" value="Cancel" />

           
             
                    </div>  
                              <div class="modal-footerCancelView" style="">
                    </div>
                </div>


             
            </div>

        </div>
    <asp:HiddenField ID="hiddenjsondtails" runat="server" />

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
           /* padding: 2% 1%;*/
           background-color: #91a172;
             color: white;
             margin-top: 26%;
width: 102%;

         }
            .modal-bodyCancelView1 {

             padding: 4% 4% 0% 0%;
         }
         .modal-footerCancelView {
             padding: 2% 1%;
           background-color: #91a172;
             color: white;
         }
           .modalCancelView1 {
             display: none; /* Hidden by default */
             position: fixed; /* Stay in place */
             z-index: 30; /* Sit on top */
             padding-top: 0%; /* Location of the box */
             left: 23%;
             top: 10%;
             width: 25%; /* Full width */
             /*height: 58
                 %;*/ /* Full height */
             /*overflow: auto;*/ /* Enable scroll if needed */
             background-color: transparent;
         }


         /* Modal Content */
         .modal-CancelView1 {
             /*position: relative;*/
             background-color: #fefefe;
             margin: auto;
             padding: 0;
             /*border: 1px solid #888;*/
             width: 60.6%;
             box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
         }
            .modal-bodyCancelView21 {
             padding: 4% 4% 7% 0%;
         }
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
    <script>
        function getdata() {
            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];
            var rowCount = $p('#ReportTable tr').length - 1;
            for (var x = 0; x < rowCount; x++) {


                var Decsn = document.getElementById("ddlDecision" + x).value;
                var Comments = document.getElementById("txtComments" + x).value;
            
                var tableid = document.getElementById("tdid" + x).innerHTML;
                var $add = jQuery.noConflict();
                var client = JSON.stringify({
                    DECSNID: "" + Decsn + "",
                    COMNTS: "" + Comments + "",
                    TBLID: "" + tableid + ""
                });
                tbClientJobSheduling.push(client);
                //}
            }
            $add("#cphMain_hiddenjsondtails").val(JSON.stringify(tbClientJobSheduling));
         
        }
    </script>
</asp:Content>

