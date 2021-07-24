/// <reference path="../../JavaScript/jquery-2.1.1.min.js" />


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

function ConfirmClear() {

    ezBSAlert({
        type: "confirm",
        messageText: "Are you sure you want to clear?",
        alertType: "info"
    }).done(function (e) {
        if (e == true) {
            return true;
        }
        else {
            return false;
        }
    });
}

function DisableEnter(evt) {

    evt = (evt) ? evt : window.event;
    var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
    if (keyCodes == 13) {
        return false;
    }   //emp17
} function isTag(evt) {
  
   // document.getElementById('divMessageArea').style.display = "none";          //emp17

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

} function RemoveTag(obj) {
 
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
  //  document.getElementById('divMessageArea').style.display = "none";          //emp17

    evt = (evt) ? evt : window.event;
    var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

    var charCode = (evt.which) ? evt.which : evt.keyCode;
    var ret = true;
    if (charCode == 60 || charCode == 62 || keyCodes == 13) {
        ret = false;
    }
    return ret;
} function CancelAlert(href) {
    ezBSAlert({
        type: "confirm",
        messageText: "Are you sure you want to cancel?",
        alertType: "info"
    }).done(function (e) {
        if (e == true) {

            window.location = href;
            return false;
        }
        else {
            return false;
        }
    });
    return false;
   
}
function ConfirmMessage(href) {
    ezBSAlert({
        type: "confirm",
        messageText: "Are you sure you want to leave this page?",
        alertType: "info"
    }).done(function (e) {
        if (e == true) {

            window.location = href;
            return false;
        }
        else {
            return false;
        }
    });
    return false;

}


function CancelNotPossible() {
    alert("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
    return false;

}
function isNumberAmount(evt, textboxid) {

    evt = (evt) ? evt : window.event;
    var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    //  alert(textboxid);
    var txtPerVal = document.getElementById(textboxid).value;
    // alert(txtPerVal);
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
        if (textboxid == textboxid) {
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
            //alert("55");
            return false;
        }

    }

    else {
        var ret = true;
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {


            ret = false;
        }
        return ret;
    }
}
function CancelAlert1() {

    ezBSAlert({
        type: "confirm",
        messageText: "Do you want to cancel this entry?",
        alertType: "info"
    }).done(function (e) {
        if (e == true) {

            return true;
        }
        else {
            return false;
        }

    });
    return false;
}

//customised alert

var $noCon4JScommon = jQuery.noConflict();
function ezBSAlert(options) {
    var deferredObject = $noCon4JScommon.Deferred();
    var defaults = {
        type: "alert", //alert, prompt,confirm 
        modalSize: 'modal-sm', //modal-sm, modal-lg
        okButtonText: 'Ok',
        cancelButtonText: 'Cancel',
        yesButtonText: 'Yes',
        noButtonText: 'No',
        headerText: 'Attention',
        messageText: 'Message',
        alertType: 'default', //default, primary, success, info, warning, danger
        inputFieldType: 'text', //could ask for number,email,etc
    }
    $noCon4JScommon.extend(defaults, options);

    var _show = function () {
        var headClass = "navbar-default";
        switch (defaults.alertType) {
            case "primary":
                headClass = "alert-primary";
                break;
            case "success":
                headClass = "alert-success";
                break;
            case "info":
                headClass = "alert-info";
                break;
            case "warning":
                headClass = "alert-warning";
                break;
            case "danger":
                headClass = "alert-danger";
                break;
        }
        $noCon4JScommon('BODY').append(
            '<div id="ezAlerts" class="modal fade">' +
            '<div class="modal-dialog" class="' + defaults.modalSize + '">' +
            '<div class="modal-content">' +
            '<div id="ezAlerts-header" class="modal-header ' + headClass + '">' +
            '<button id="close-button" type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>' +
            '<h4 id="ezAlerts-title" class="modal-title">Modal title</h4>' +
            '</div>' +
            '<div id="ezAlerts-body" class="modal-body">' +
            '<div id="ezAlerts-message" ></div>' +
            '</div>' +
            '<div id="ezAlerts-footer" class="modal-footer">' +
            '</div>' +
            '</div>' +
            '</div>' +
            '</div>'
        );

        $noCon4JScommon('.modal-header').css({
            'padding': '15px 15px',
            '-webkit-border-top-left-radius': '5px',
            '-webkit-border-top-right-radius': '5px',
            '-moz-border-radius-topleft': '5px',
            '-moz-border-radius-topright': '5px',
            'border-top-left-radius': '5px',
            'border-top-right-radius': '5px'
        });

        $noCon4JScommon('#ezAlerts-title').text(defaults.headerText);
        $noCon4JScommon('#ezAlerts-message').html(defaults.messageText);

        var keyb = "false", backd = "static";
        var calbackParam = "";
        switch (defaults.type) {
            case 'alert':
                keyb = "true";
                backd = "true";
                $noCon4JScommon('#ezAlerts-footer').html('<button id="ezok-btn" class="btn btn-' + defaults.alertType + '">' + defaults.okButtonText + '</button>').on('click', ".btn", function () {
                    calbackParam = true;
                    $noCon4JScommon('#ezAlerts').modal('hide');
                });
                break;
            case 'confirm':
                var btnhtml = '<button id="ezok-btn" class="btn btn-primary">' + defaults.yesButtonText + '</button>';
                if (defaults.noButtonText && defaults.noButtonText.length > 0) {
                    btnhtml += '<button id="ezclose-btn" class="btn btn-default">' + defaults.noButtonText + '</button>';
                }
                $noCon4JScommon('#ezAlerts-footer').html(btnhtml).on('click', 'button', function (e) {
                    if (e.target.id === 'ezok-btn') {
                        calbackParam = true;
                        $noCon4JScommon('#ezAlerts').modal('hide');
                    } else if (e.target.id === 'ezclose-btn') {
                        calbackParam = false;
                        $noCon4JScommon('#ezAlerts').modal('hide');
                    }
                });
                break;
            case 'prompt':
                $noCon4JScommon('#ezAlerts-message').html(defaults.messageText + '<br /><br /><div class="form-group"><input type="' + defaults.inputFieldType + '" class="form-control" id="prompt" /></div>');
                $noCon4JScommon('#ezAlerts-footer').html('<button class="btn btn-primary">' + defaults.okButtonText + '</button>').on('click', ".btn", function () {
                    calbackParam = $noCon4JScommon('#prompt').val();
                    $noCon4JScommon('#ezAlerts').modal('hide');
                });
                break;
        }

        $noCon4JScommon('#ezAlerts').modal({
            show: false,
            backdrop: backd,
            keyboard: keyb,
            timeout: 40
        }).on('hidden.bs.modal', function (e) {
            $noCon4JScommon('#ezAlerts').remove();
            deferredObject.resolve(calbackParam);
        }).on('shown.bs.modal', function (e) {
            //btn foucs

            if (defaults.type == "confirm" || defaults.type == "alert") {
                $noCon4JScommon('#ezok-btn').focus();
            }

            if ($noCon4JScommon('#prompt').length > 0) {
                $noCon4JScommon('#prompt').focus();
            }
        }).modal('show');
    }

    _show();
    return deferredObject.promise();
} function isNumber(evt) {

    evt = (evt) ? evt : window.event;
    var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    //at enter
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
    else {
        var ret = true;
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {


            ret = false;
        }
        return ret;
    }
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
function SuccessMsg(Action, Msg) {



    var session = Action;
    //alert(session);
    if (session != null) {

        if (session == "SAVE") {
            ezBSAlert({
                messageText: Msg,
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

              
                }
            });

        }
        else if (session == "UPD") {
            ezBSAlert({
                messageText: Msg,
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    

                }
            });

        }
        else if (session == "DUP") {
            ezBSAlert({
                messageText: Msg,
                alertType: "warning",
               
            }).done(function (e) {
                if (e == true) {

                
            

                }
            });

        }
        else if (session == "ERR") {
            ezBSAlert({
                messageText: Msg,
                alertType: "danger"
            }).done(function (e) {
                if (e == true) {



                }
            });

        }
        
       

    }
}