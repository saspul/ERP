

function textCounter(field, maxlimit) {

    if (field.value.length > maxlimit) {
        field.value = field.value.substring(0, maxlimit);
    }
    else {
    }
    var txt = field.value;
    var replaceText1 = txt.replace(/</g, "");
    var replaceText2 = replaceText1.replace(/>/g, "");
    field.value = replaceText2;
}

function getdetails(href) {
    window.location = href;
    return false;
}

function isDecimalNumber(evt, textboxid) {

    evt = (evt) ? evt : window.event;
    var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
    var charCode = (evt.which) ? evt.which : evt.keyCode;

    var txtPerVal = document.getElementById(textboxid).value;

    if (keyCodes == 13) {
        return false;
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
    else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 38 || keyCodes == 40) {
        return true;
    }
    else if (keyCodes == 34 || keyCodes == 33 || keyCodes == 36 || keyCodes == 35 || keyCodes == 41) {

        return true;
    }
    else if ((keyCodes == 65 || keyCodes == 86 || keyCodes == 67) && (evt.ctrlKey === true || evt.metaKey === true)) {
        return true;
    }
    else if (keyCodes == 46) {
        return true;
    }
        // . period and numpad . period
    else if (keyCodes == 190 || keyCodes == 110) {
        var ret = true;

        var count = txtPerVal.split('.').length - 1;

        if (count > 0) {
            ret = false;
        }
        else {
            ret = true;
        }
        return ret;
    }
    else {
        var ret = true;
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            ret = false;
        }
        return ret;
    }
}

function DisableEnter(evt) {

    evt = (evt) ? evt : window.event;
    var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
    if (keyCodes == 13) {
        return false;
    }
}

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

function RemoveTagWithNumber(obj) {

    var txt = document.getElementById(obj).value.trim();
    var numbers = /^[0-9]+$/;
    if (!numbers.test(txt)) {
        document.getElementById(obj).value = "";
    }
    txt = document.getElementById(obj).value.trim();
    var replaceText1 = txt.replace(/</g, "");
    var replaceText2 = replaceText1.replace(/>/g, "");
    document.getElementById(obj).value = replaceText2;
}

function RemoveTag(obj) {

    var txt = document.getElementById(obj).value.trim();
    var replaceText1 = txt.replace(/</g, "");
    var replaceText2 = replaceText1.replace(/>/g, "");
    document.getElementById(obj).value = replaceText2;
}

function RemoveTagforfield(obj) {

    var txt = obj.value.trim();
    var replaceText1 = txt.replace(/</g, "");
    var replaceText2 = replaceText1.replace(/>/g, "");
    obj.value = replaceText2;
}

function isTagEnter(evt) {
    var ret = true;
    evt = (evt) ? evt : window.event;
    var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

    if (keyCodes == 13) {
        ret = false;
    }
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode == 60 || charCode == 62) {
        ret = false;
    }
    return ret;
}

function isNumberAmount(evt, textboxid) {

    evt = (evt) ? evt : window.event;
    var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
    var charCode = (evt.which) ? evt.which : evt.keyCode;

    var txtPerVal = document.getElementById(textboxid).value;

    if (keyCodes == 13) {
        return false;
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
    else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 38 || keyCodes == 40) {
        return true;
    }
    else if (keyCodes == 34 || keyCodes == 33 || keyCodes == 36 || keyCodes == 35 || keyCodes == 41) {

        return true;
    }
    else if ((keyCodes == 65 || keyCodes == 86 || keyCodes == 67) && (evt.ctrlKey === true || evt.metaKey === true)) {
        return true;
    }
    else if (keyCodes == 46) {
        return true;
    }
        // . period and numpad . period
    else if (keyCodes == 190 || keyCodes == 110) {
        var ret = true;

        var count = txtPerVal.split('.').length - 1;

        if (count > 0) {
            ret = false;
        }
        else {
            ret = true;
        }
        return ret;
    }
    else {
        var ret = true;
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            ret = false;
        }
        return ret;
    }
}

function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
    var charCode = (evt.which) ? evt.which : evt.keyCode;

    if ((keyCodes == 65 || keyCodes == 86 || keyCodes == 67) && (evt.ctrlKey === true || evt.metaKey === true)) {
        return true;
    }
    else if (keyCodes == 13) {
        return false;
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
    else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 38 || keyCodes == 40) {
        return true;
    }
    else if (keyCodes == 34 || keyCodes == 33 || keyCodes == 36 || keyCodes == 35 || keyCodes == 41 || keyCodes == 37 || keyCodes == 39) {
        return true;
    }
    else if (keyCodes == 46) {
        return true;
    }
        // . period and numpad . period
    else if (keyCodes == 190 || keyCodes == 110) {
        //var ret = false;
        return false;
    }
    else {
        var ret = true;
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            ret = false;
        }
    }

    return ret;
}

function isNumberWithSource(evt, textboxid) {
   
    evt = (evt) ? evt : window.event;
    var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
    var charCode = (evt.which) ? evt.which : evt.keyCode;

    var txtPerVal = document.getElementById(textboxid).value;
    //enter
    if (keyCodes == 13) {
        return false;
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
    else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
        return true;

    }
        // . period and numpad . period
    else if (keyCodes == 190 || keyCodes == 110) {
        var ret = true;

        var count = txtPerVal.split('.').length - 1;

        if (count > 0) {

            ret = false;
        }
        else {
            ret = true;
        }
        return ret;

    }

    else {
        var ret = true;
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {


            ret = false;
        }
        return ret;
    }
}

function RemoveNaN_OnBlur(obj) {
 
    var txt = document.getElementById(obj).value;

    if (txt != "") {
        if (txt.indexOf('.') !== -1) {
            document.getElementById(obj).value = "";
            document.getElementById(obj).focus();
            return false;
        }
        if (isNaN(txt)) {
            document.getElementById(obj).value = "";
            document.getElementById(obj).focus();
            return false;

        }
        if (txt < 0) {
            document.getElementById(obj).value = "";
            document.getElementById(obj).focus();
            return false;
        }

        RemoveTag(obj);
    }
}


function addCommasReturn(nStr, CrncyMode) {

    nStr += '';
    var x = nStr.split('.');
    var x1 = x[0];
    var x2 = x[1];

    if (CrncyMode == "1") {
        var rgx = /(\d+)(\d{7})/;
        if (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
        rgx = /(\d+)(\d{5})/;
        if (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
        rgx = /(\d+)(\d{3})/;
        if (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
    }

    if (CrncyMode == "2") {
        var rgx = /(\d+)(\d{9})/;
        if (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }

        rgx = /(\d+)(\d{6})/;
        if (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
        rgx = /(\d+)(\d{5})/;
        if (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
        rgx = /(\d+)(\d{3})/;
        if (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
    }
    if (CrncyMode == "3") {
        var rgx = /(\d+)(\d{9})/;
        if (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
        rgx = /(\d+)(\d{6})/;
        if (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
        rgx = /(\d+)(\d{3})/;
        if (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
    }

    var strReturn = "";

    if (isNaN(x2)) {
        strReturn = x1;
    }
    else {
        strReturn = x1 + "." + x2;
    }

    return strReturn;
}


function BlurAmountReturn(txtPerVal, DecCnt) {

    var ret = true;

    var strReturn = txtPerVal;

    var Text = txtPerVal.toString();
    Text = Text.replace(/,/g, "");

    if (Text == "") {
        ret = false;
    }
    else {
        if (!isNaN(Text) == false) {
            ret = false;
        }
        else {
            if (parseFloat(Text) < 0) {
                txtPerVal = "";
                ret = false;
            }
            var amt = parseFloat(txtPerVal);
            var num = amt;
            var n = num;

            var FloatingValue = "";
            FloatingValue = DecCnt;

            if (FloatingValue != "") {
                n = num.toFixed(FloatingValue);
            }
            strReturn = n;
        }
    }

    if (ret == false) {
        strReturn = "";
    }

    return strReturn;
}
