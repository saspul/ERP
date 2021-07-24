<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="TEST_DATE_CONTROL_NewFolder2_Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link href="css/bootstrap-datetimepicker.min.css" rel="stylesheet">--%>
    <%--<script src="js/bootstrap-datetimepicker.min.js"></script>--%>
    <link href="StyleSheetDate.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" media="screen"
        href="StyleSheetDate2.css">


    <script type="text/javascript" language="javascript">
        function isNumberDate(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //enter
            if (keyCodes == 13) {
                return false;
            }
                //dash
            else if (keyCodes ==173) {
                return true;
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46) {
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
  
    </script>
    <script>
        function ValidateSubmit() {
            document.getElementById("txtDatePickerInput").style.borderColor = "";
            var date = document.getElementById('txtDatePickerInput').value;
             alert(date);
            var data = date.split("-");
            // using ISO 8601 Date String
            if (isNaN(Date.parse(data[2] + "-" + data[1] + "-" + data[0]))) {
                document.getElementById("txtDatePickerInput").style.borderColor = "Red";
                return false;
               
            }
            
            return true;
        }

        </script>




</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="datetimepicker" class="input-append date">
                <asp:TextBox ID="txtDatePickerInput"  placeholder="DD-MM-YYYY" runat="server" ></asp:TextBox>
                <%--<div class="add-on">--%>
                    <%--<i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>--%>
 <img class="add-on" src="../../../Images/Icons/CalandarIcon.png"  height="21" width="21"/> 
                <%--</div>--%>
            </div>
            <script type="text/javascript"
                src="JavaScriptDate1_8_3.js">
            </script>
            <script type="text/javascript"
                src="JavaScriptDate2_2_2_bootstap.js">
            </script>
            <script type="text/javascript"
                src="bootstrap-datepicker.js">
            </script>
            <script type="text/javascript"
                src="bootstrap-datepicker_pt_br.js">
            </script>
            <script type="text/javascript">
                $('#datetimepicker').datetimepicker({
                    format: 'dd-MM-yyyy',
                    language: 'en',
                    pickTime: false,
                    startDate: new Date(),
                });

            </script>

            <asp:Button ID="btnAdd" runat="server" class="btn btn-green pull-right" Text="Submit" OnClientClick="return ValidateSubmit();"  />
        </div>
    </form>
</body>
</html>
