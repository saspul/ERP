<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="TEST_DATE_CONTROL_NewFolder1_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="dist/css/datepicker.css" rel="stylesheet">
<script src="//code.jquery.com/jquery-2.1.4.min.js"></script>
<script src="dist/js/datepicker.js"></script>

    <script type="text/javascript" language="javascript">
        function isNumber(evt) {
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
           // alert(date);
            var data = date.split("-");
            // using ISO 8601 Date String
            if (isNaN(Date.parse(data[2] + "-" + data[1] + "-" + data[0]))) {
                document.getElementById("txtDatePickerInput").style.borderColor = "Red";
                return false;
               
            }
            
            return true;
        }
        function BlurDate() {
            // replacing < and > tags and _
            var DateWithoutReplace = document.getElementById("txtDatePickerInput").value;
            var replaceText1 = DateWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            var replaceText3 = replaceText2.replace(/_/g, "-");
            document.getElementById("txtDatePickerInput").value = replaceText3;
           

            var date = document.getElementById('txtDatePickerInput').value;
          //  alert(date);
            var data = date.split("-");

            var len0 = parseInt(data[0].length)||0 ;
            if (len0 === 1) {
                data[0] = '0' + data[0];
            }
            if (data[1] != undefined) {
                var len1 = parseInt(data[1].length) || 0;
                if (len1 === 1) {
                    data[1] = '0' + data[1];
                }
            }
            var Dformat ="";
            if (data[2] != undefined) {
                 Dformat = data[0] + "-" + data[1] + "-" + data[2];
            }
            else if (data[1] != undefined) {
                 Dformat = data[0] + "-" + data[1];
            }
            else {
                Dformat = data[0];
            }
            document.getElementById("txtDatePickerInput").value = Dformat;


            /////-------------
            //var dateC = document.getElementById('txtDatePickerInput').value;
            //if (dateC != "") {

            //    var dataCntrl = dateC.split("-");
            //    // using ISO 8601 Date String
            //    if (isNaN(Date.parse(dataCntrl[2] + "-" + dataCntrl[1] + "-" + dataCntrl[0]))) {


            //    }
            //    else {
            //        var datepickerDate = dateC;
            //        var arrDatePickerDate = datepickerDate.split("-");
            //        var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);
                   
            //        var myDatepicker = $('#txtDatePickerInput').datepicker().data('datepicker');
            //       // myDatepicker.clear();
            //       //  myDatepicker.selectDate(dateDateCntrlr);
            //       //  myDatepicker.next();
            //        myDatepicker.date = dateDateCntrlr;
                  
            //    }
            //}
            ////------------

            return false;
        }
        function FocusDate() {
    
            /////-------------
            var dateC = document.getElementById('txtDatePickerInput').value;
            if (dateC != "") {

                var dataCntrl = dateC.split("-");
                // using ISO 8601 Date String
                if (isNaN(Date.parse(dataCntrl[2] + "-" + dataCntrl[1] + "-" + dataCntrl[0]))) {


                }
                else {
                    var datepickerDate = dateC;
                    var arrDatePickerDate = datepickerDate.split("-");
                    var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                 //   var myDatepicker = $('#txtDatePickerInput').datepicker().data('datepicker');
                    // myDatepicker.clear();
                    //  myDatepicker.selectDate(dateDateCntrlr);
                    //  myDatepicker.next();
                //    myDatepicker.date = dateDateCntrlr;
                    $('#txtDatePickerInput').datepicker("defaultDate", dateDateCntrlr);
                }
            }
            ////------------

            return false;
        }


        //$('#selector').datepicker({

        //    // inline mode
        //    inline: false,

        //    // additional CSS class
        //    classes: '',

        //    // language
        //    language: 'ru',

        //    // start date
        //    startDate: new Date(),

        //    // first day
        //    firstDay: '',

        //    // array of day's indexes
        //    weekends: [6, 0],

        //    // custom date format
        //    dateFormat: '',

        //    // Alternative text input. Use altFieldDateFormat for date formatting.
        //    altField: '',

        //    // Date format for alternative field.
        //    altFieldDateFormat: '@',

        //    // remove selection when clicking on selected cell
        //    toggleSelected: true,

        //    // keyboard navigation
        //    keyboardNav: true,

        //    // position
        //    position: 'bottom left',
        //    offset: 12,

        //    // days, months or years
        //    view: 'days',
        //    minView: 'days',

        //    showOtherMonths: true,
        //    selectOtherMonths: true,
        //    moveToOtherMonthsOnSelect: true,

        //    showOtherYears: true,
        //    selectOtherYears: true,
        //    moveToOtherYearsOnSelect: true,

        //    minDate: '',
        //    maxDate: '',
        //    disableNavWhenOutOfRange: true,

        //    multipleDates: false, // Boolean or Number
        //    multipleDatesSeparator: ',',
        //    range: false,

        //    // display today button
        //    todayButton: false,

        //    // display clear button
        //    clearButton: false,

        //    // Event type
        //    showEvent: 'focus',

        //    // auto close after date selection
        //    autoClose: false,

        //    // navigation
        //    monthsFiled: 'monthsShort',
        //    prevHtml: '<svg><path d="M 17,12 l -5,5 l 5,5"></path></svg>',
        //    nextHtml: '<svg><path d="M 14,12 l 5,5 l -5,5"></path></svg>',
        //    navTitles: {
        //        days: 'MM, <i>yyyy</i>',
        //        months: 'yyyy',
        //        years: 'yyyy1 - yyyy2'
        //    },

        //    // callback events
        //    onSelect: '',
        //    onChangeMonth: '',
        //    onChangeYear: '',
        //    onChangeDecade: '',
        //    onChangeView: '',
        //    onRenderCell: ''

        //})
        Datepicker.language['en'] = {
            days: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'],
            daysShort: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
            daysMin: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
            months: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
            monthsShort: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
            today: 'Today',
            clear: 'Clear',
            dateFormat: 'dd-mm-yyyy',
            firstDay: 0
        };
       
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding:150px">
    
            <asp:TextBox ID="txtDatePickerInput" placeholder="DD-MM-YYYY" type='text' class='datepicker-here'  data-language='en'
         data-position='bottom left'   runat="server"  onblur="return BlurDate();" onfocus="return FocusDate();" ></asp:TextBox>
      

              <asp:Button ID="btnAdd" runat="server" class="btn btn-green pull-right" Text="Submit" OnClientClick="return ValidateSubmit();"  />

          <script>
            
              $('#txtDatePickerInput').datepicker({
                  language: 'en',
                  minDate: new Date(),// Now can select only dates, which goes after today              
                  clearButton: true
                
              })

        </script>
    
    </div>
    </form>
</body>
</html>
