
       $(function () {
           ManageAppMode.Load();
          // ManageHelpDocs.Load();
       })

var ManageAppMode = {
    Load: function () {
        ManageAppMode.GetAppMode();
    },

    GetAppMode: function () {
        var AppMode = document.getElementById('hiddenappmode').value;
       // if (AppMode == "") {
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "/MasterPage/WebServiceMaster.asmx/GetAppMode",
                data: '{ }',
                dataType: "json",
                success: function (response) {
                    if (response.d == 0) {
                        document.getElementById("divAddHelpIcon").style.display = "none";
                        AppMode = 0;
                    }
                    else if (response.d == 1) {
                        document.getElementById("divAddHelpIcon").style.display = "block";
                        AppMode = 1;
                    }
                },
                error: function (result) {
                    alert("Fail")
                }
            });

        if (AppMode == 1) {
            document.getElementById('idBootstrapCSS').setAttribute('href', '/css/New%20Plugins/bootstrap.min.css');
            document.getElementById('idJquery_uiCSS').setAttribute('href', '/js/libs/jquery-ui/1.8/jquery-ui.css');
            document.getElementById('idJquery_uiJS').setAttribute('src', '/js/libs/jquery-ui/1.8/jquery-ui.min.js');
            ManageHelpDocs.Load();
        }

    },       
}



var ManageHelpDocs = {

    Load: function () {
        ManageHelpDocs.BindEvents();
    },
    BindEvents: function () {
        ManageHelpDocs.LoadCurrentPageControls();
   


        $("#btnSaveMain").click(function () {

            var result = ManageHelpDocs.Validation(this.id);
            if (result == true) {
                ManageHelpDocs.SaveData(this.id);
            }
            else {
                return false;
            }
        });

        $("#btnUpdateMain").click(function () {
            var result = ManageHelpDocs.Validation(this.id);
            if (result == true) {
                ManageHelpDocs.UpdateData(this.id);
            }
            else {
                return false;
            }
        });

        $("#btnSaveSub").click(function () {

            var result = ManageHelpDocs.Validation(this.id);
            if (result == true) {
                ManageHelpDocs.SaveData(this.id);
            }
            else {
                return false;
            }
        });

        $("#btnSaveControl").click(function () {
            var result = ManageHelpDocs.Validation(this.id);
            if (result == true) {
                ManageHelpDocs.SaveData(this.id);
            }
            else {
                return false;
            }
        });

        $("#btnUpdateControl").click(function () {
            var result = ManageHelpDocs.Validation(this.id);
            if (result == true) {
                ManageHelpDocs.UpdateData(this.id);
            }
            else {
                return false;
            }
        });

        var Sections = "";
        // Main Section //
        $("#aidSection").click(function () {

            Sections = "MainSection";
            ManageHelpDocs.EditView(Sections);
            ManageHelpDocs.MainSection();
           
        });


        // Sub Section //
        $("#aidSubSection").click(function () {
            Sections = "SubSection";
            ManageHelpDocs.EditView(Sections);
            ManageHelpDocs.SubSection();
        });

        // Control Section //
        $(':input').on('focus', function () {
            if (this.id == "btnAddHelp" || this.id == "aidSection" || this.id == "aidSubSection" || this.id == "aidControls" || this.id == "btnSaveControl" || this.id == "btnUpdateControl" || this.id == "divddlSection" || this.id == "txtTitle" || this.id == "txtPriority" || this.id == "cbxStatus" || this.id == "textddlSection") {
            }
            else {
                document.getElementById("hiddenControlId").value = this.id;
            }
        });


        $("#aidControls").click(function () {
            document.getElementById("hiddenControlIdFinal").value = document.getElementById("hiddenControlId").value;

            Sections = "ControlSection";
            ManageHelpDocs.EditView(Sections);
            ManageHelpDocs.SubSection();

            if (document.getElementById("hiddenControlIdFinal").value == "") {
                alert("Please select a control");
                return false;
            }

            document.getElementById("txtControlName").value = document.getElementById("hiddenControlIdFinal").value;
        });

    },

    LoadCurrentPageControls: function () {

        var host = window.location.host;      //host name                        
        var PageURL = window.location.href;   //page URL
        var CurrentPageName = PageURL.substring(PageURL.lastIndexOf('/') + 1); //Page Name

        var strFullURL = PageURL.split(host);
        strFullURL = strFullURL[1];
        var strURL = strFullURL.split(CurrentPageName);
        strURL = strURL[0];

        if (document.getElementById('hiddenappmode').value == 1) {
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "/MasterPage/HelpDocWebService.asmx/GetCurrentPageControls",
                data: '{strURL: "' + strURL + '",strFullURL: "' + strFullURL + '"}',
                dataType: "json",
                success: function (data) {
                    var find2 = '\\"\\[';
                    var re2 = new RegExp(find2, 'g');
                    var res2 = data.d.replace(re2, '\[');

                    var find3 = '\\]\\"';
                    var re3 = new RegExp(find3, 'g');
                    var res3 = res2.replace(re3, '\]');

                    var json = $.parseJSON(res3);

                    for (var key in json) {
                        if (json.hasOwnProperty(key)) {
                            $("<a href='#' onclick=onClickHelpControlForPopup(" + json[key].HELPDOC_SECTION_ID + ",'" + json[key].HELPDOC_DTLS_CONTROL_ID + "');><i class='fa fa-question-circle' style='font-size:11px;padding-left: 0px;padding-top: 3px;'></i></a>").insertAfter("#" + json[key].HELPDOC_DTLS_CONTROL_ID);
                        }
                    }
                },

                error: function (result) {
                    alert("Fail")
                }
            });
        }
},


    EditView: function (Mode) { 
        var host = window.location.host;      //host name                        
        var PageURL = window.location.href;   //page URL
        var CurrentPageName = PageURL.substring(PageURL.lastIndexOf('/') + 1); //Page Name

        var strFullURL = PageURL.split(host);
        strFullURL = strFullURL[1];
        var strURL = strFullURL.split(CurrentPageName);
        strURL = strURL[0];


        var ControlId = "";
        if (Mode == "ControlSection") {
            ControlId = document.getElementById("hiddenControlIdFinal").value;
        }

        $.ajax({
            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: "/MasterPage/HelpDocWebService.asmx/EditView",
            data: '{strURL: "' + strURL + '",strFullURL: "' + strFullURL + '",Mode: "' + Mode + '",ControlId: "' + ControlId + '"}',
            dataType: "json",
            success: function (data) {
                if (data.d[0] == 'AddView') {
                   
                    if (Mode == "MainSection")
                    {
                        document.getElementById("idHelpHead").innerHTML = "Add Section";
                        document.getElementById("btnSaveMain").style.display = "block";
                        document.getElementById("btnUpdateMain").style.display = "none";
                      
                       
                    }
                    if (Mode == "SubSection")
                    {
                        document.getElementById("idHelpHead").innerHTML = "Add Subsection";
                        document.getElementById("btnSaveSub").style.display = "block";
                        document.getElementById("btnUpdateSub").style.display = "none";
                    }
                    
                    if (Mode == "ControlSection")
                    {
                        document.getElementById("btnSaveControl").style.display = "block";
                        document.getElementById("btnUpdateControl").style.display = "none";
                        document.getElementById("idHelpHead").innerHTML = "Add Control";
                    }


                    $('#myModalAddHelp').find('input:text').val('');
                    CKEDITOR.instances['editor1'].setData("")

                }

                if (data.d[0] == 'EditView') {

                    if (Mode == "MainSection") {
                        document.getElementById("btnSaveMain").style.display = "none";
                        document.getElementById("btnUpdateMain").style.display = "block";
                        document.getElementById("idHelpHead").innerHTML = "Edit Section";
                    }
                    if (Mode == "ControlSection") {
                        document.getElementById("btnSaveControl").style.display = "none";
                        document.getElementById("btnUpdateControl").style.display = "block";
                        document.getElementById("idHelpHead").innerHTML = "Edit Control";
                    }

                    document.getElementById("txtSectionName").value = data.d[1];
                    document.getElementById("textddlSection").value = data.d[1];
                    document.getElementById("textMainMenu").value = data.d[2];
                    document.getElementById("textSubMenu").value = data.d[3];

                    if (data.d[2] == "") {
                        document.getElementById("textMainMenu").value = data.d[3];
                        document.getElementById("textSubMenu").value = "";
                    }

                    document.getElementById("txtTitle").value = data.d[4];
                    document.getElementById("txtPriority").value = data.d[5];
                    if (data.d[6] == 1) {
                        document.getElementById("cbxStatus").checked = true;
                    }
                    else {
                        document.getElementById("cbxStatus").checked = false;
                    }
                    CKEDITOR.instances['editor1'].setData(data.d[7])
                    document.getElementById("hiddenMainUserRollId").value = data.d[8];
                    document.getElementById("hiddenSubUserRollId").value = data.d[9];
                    document.getElementById("hiddenSectionId").value = data.d[10];
                    document.getElementById("hiddenDocDetailId").value = data.d[11];
                }
            },
            error: function (result) {
                alert("Fail")
            }
        });
    },

    MainSection: function () {                
        var host = window.location.host;      //host name                        
        var PageURL = window.location.href;   //page URL
        var CurrentPageName = PageURL.substring(PageURL.lastIndexOf('/') + 1); //Page Name

        var strFullURL = PageURL.split(host);
        strFullURL = strFullURL[1];
        var strURL = strFullURL.split(CurrentPageName);
        strURL = strURL[0];

        if (strURL != "") {
            var AppMode = 1;
            var $noC = jQuery.noConflict();
            $noC("#textMainMenu").autocomplete({
                source: function (request, response) {
                    var StrSearchString = request.term;
                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "/MasterPage/HelpDocWebService.asmx/GetUserRolByURL",
                        data: '{strURL: "' + strURL + '",strFullURL: "' + strFullURL + '",StrSearchString: "' + StrSearchString + '"}',
                        dataType: "json",
                        success: function (data) {
                            response($noC.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },

                        error: function (result) {
                            alert("Fail")
                        }
                    });
                },
                select: function (e, i) {

                    $("#hiddenMainUserRollId").val(i.item.val);

                    var ParentId = document.getElementById("hiddenMainUserRollId").value;

                    if (ParentId != "") {
                        $noC("#textSubMenu").autocomplete({
                            source: function (request, response) {
                                var StrSearchString = request.term;
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    contentType: "application/json; charset=utf-8",
                                    url: "/MasterPage/HelpDocWebService.asmx/GetUserRolsByUserRolId",
                                    data: '{ParentId: "' + ParentId + '",StrSearchString: "' + StrSearchString + '"}',
                                    dataType: "json",
                                    success: function (data) {
                                        response($noC.map(data.d, function (item) {
                                            return {
                                                label: item.split('-')[0],
                                                val: item.split('-')[1]
                                            }
                                        }))
                                    },
                                    error: function (result) {
                                        alert("Fail")
                                    }
                                });
                            },
                            select: function (e, i) {      
                                $("#hiddenSubUserRollId").val(i.item.val);
                                var UserRollId = document.getElementById("hiddenSubUserRollId").value;
                            },

                            change: function (event, ui) {
                                if (ui.item === null) {
                                    $(this).val('');
                                    $('#textSubMenu').val('');
                                }
                            },

                            minLength: 1
                        });

                    }
                },

                change: function (event, ui) {
                    if (ui.item === null) {
                        $(this).val('');
                        $('#textMainMenu').val('');
                    }
                },
                minLength: 1
            });
        }
    },

    SubSection: function () {
        var host = window.location.host;      //host name                        
        var PageURL = window.location.href;   //page URL
        var CurrentPageName = PageURL.substring(PageURL.lastIndexOf('/') + 1); //Page Name

        var strFullURL = PageURL.split(host);
        strFullURL = strFullURL[1];
        var strURL = strFullURL.split(CurrentPageName);
        strURL = strURL[0];

        if (strURL != "") {
            var $noC = jQuery.noConflict();
            $noC("#textddlSection").autocomplete({
                source: function (request, response) {
                    var StrSearchString = request.term;
                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "/MasterPage/HelpDocWebService.asmx/GetSectionsByURL",
                        data: '{strURL: "' + strURL + '",strFullURL: "' + strFullURL + '",StrSearchString: "' + StrSearchString + '"}',
                        dataType: "json",
                        success: function (data) {
                            response($noC.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (result) {
                            alert("Fail")
                        }
                    });
                },
                select: function (e, i) {
                    $("#hiddenSectionId").val(i.item.val);
                    var SectionId = document.getElementById("hiddenSectionId").value;
                },

                change: function (event, ui) {
                    if (ui.item === null) {
                        $(this).val('');
                        $('#textddlSection').val('');
                        document.getElementById("hiddenSectionId").value = "";

                    }
                },

                minLength: 1
            });
        }

    },

    SaveData: function (id) {
        var UserId = document.getElementById('hiddenuseridsession').value;
        if (UserId == "" || UserId == null) {
            window.location.href = "/Default.aspx";
        }

        var BtnSaveMode = "";
        if (id == 'btnSaveMain') {
            BtnSaveMode = "btnSaveMain";
        }
        if (id == 'btnSaveSub') {
            BtnSaveMode = "btnSaveSub";
        }
        if (id == 'btnSaveControl') {
            BtnSaveMode = "btnSaveControl";
        }

 
        SectionName = document.getElementById("txtSectionName").value;
        MainMenu = document.getElementById("hiddenMainUserRollId").value
        SubMenu = document.getElementById("hiddenSubUserRollId").value;


        Title = document.getElementById("txtTitle").value;
        Priority = document.getElementById("txtPriority").value;
        if (document.getElementById("cbxStatus").checked == true) {
            Status = 1;
        }
        else {
            Status = 0;
        }
        Description = CKEDITOR.instances.editor1.getData();

        SectionId = document.getElementById("hiddenSectionId").value;
        ControlName = document.getElementById("hiddenControlIdFinal").value;


        var objData = {};
        objData.SectionName = SectionName;
        objData.MainMenu = MainMenu;
        objData.SubMenu = SubMenu;
        objData.Title = Title;
        objData.Priority = Priority;
        objData.Status = Status;
        objData.Description = Description;
        objData.UserId = UserId;
        objData.SectionId = SectionId;
        objData.ControlName = ControlName;
        objData.BtnSaveMode = BtnSaveMode;

        $.ajax({
            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: "/MasterPage/HelpDocWebService.asmx/SaveHelpDoc",
            data: JSON.stringify(objData),
            dataType: "json",
            success: function (data) {
                SuccessConfirmation(BtnSaveMode);
            },
            error: function (result) {
                alert("Fail")
            }
        });
    },


    UpdateData: function (id) {
        var UserId = document.getElementById('hiddenuseridsession').value;
        if (UserId == "" || UserId == null) {
            window.location.href = "/Default.aspx";
        }

        var BtnUpdateMode = "";
        if (id == 'btnUpdateMain') {
            BtnUpdateMode = "btnUpdateMain";
        }
        if (id == 'btnUpdateSub') {
            BtnUpdateMode = "btnUpdateSub";
        }
        if (id == 'btnUpdateControl') {
            BtnUpdateMode = "btnUpdateControl";
        }

        SectionName = document.getElementById("txtSectionName").value;
        MainMenu = document.getElementById("hiddenMainUserRollId").value;
        SubMenu = document.getElementById("hiddenSubUserRollId").value;
        Title = document.getElementById("txtTitle").value;
        Priority = document.getElementById("txtPriority").value;
        if (document.getElementById("cbxStatus").checked == true) {
            Status = 1;
        }
        else {
            Status = 0;
        }
        Description = CKEDITOR.instances.editor1.getData();

        SectionId = document.getElementById("hiddenSectionId").value
        ControlName = document.getElementById("hiddenControlIdFinal").value;
        DocDtlId = document.getElementById("hiddenDocDetailId").value
        var objData = {};
        objData.SectionName = SectionName;
        objData.MainMenu = MainMenu;
        objData.SubMenu = SubMenu;
        objData.Title = Title;
        objData.Priority = Priority;
        objData.Status = Status;
        objData.Description = Description;
        objData.UserId = UserId;
        objData.SectionId = SectionId;
        objData.ControlName = ControlName;
        objData.DocDtlId = DocDtlId;
        objData.BtnUpdateMode = BtnUpdateMode;

        $.ajax({
            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: "/MasterPage/HelpDocWebService.asmx/UpdateHelpDoc",
            data: JSON.stringify(objData),
            dataType: "json",
            success: function (data) {
                SuccessUpdation(BtnUpdateMode);
                return false;
            },
            error: function (result) {
                alert("Fail")
            }
        });
    },

    Validation: function (id) {
        var ret = true;

        if (document.getElementById("txtPriority").value == "") {
            document.getElementById("txtPriority").style.borderColor = "red";
            document.getElementById("txtPriority").focus();
            ret = false;
        }

        if (document.getElementById("txtTitle").value == "") {
            document.getElementById("txtTitle").style.borderColor = "red";
            document.getElementById("txtTitle").focus();
            ret = false;
        }

        if (id == 'btnSaveSub' || id == 'btnSaveControl' || id == 'btnUpdateSub' || id == 'btnUpdateControl') {
            if (document.getElementById("textddlSection").value == "" || document.getElementById("hiddenSectionId").value == "") {
                document.getElementById("textddlSection").style.borderColor = "red";
                document.getElementById("textddlSection").focus();
                ret = false;
            }
        }
        
        if (id == 'btnSaveMain' || id == 'btnUpdateMain') {
            if (document.getElementById("textMainMenu").value == "" || document.getElementById("hiddenMainUserRollId").value == "") {
                document.getElementById("textMainMenu").style.borderColor = "red";
                document.getElementById("textMainMenu").focus();
                ret = false;
            }

            if (document.getElementById("txtSectionName").value == "") {
                document.getElementById("txtSectionName").style.borderColor = "red";
                document.getElementById("txtSectionName").focus();
                ret = false;
            }
        }

        return ret;
    },

}



$('#myModalAddHelp').on('shown.bs.modal', function () {
    $('#txtSectionName').focus();
    $('#textddlSection').focus()
});

function SuccessConfirmation(SectionMode) {
    if (SectionMode == "btnSaveMain") {
        toastr.success('Help doc section details saved successfully.', '', { timeOut: 1500 });
    }

    if (SectionMode == "btnSaveSub") {
        toastr.success('Help doc sub section details saved successfully.', '', { timeOut: 1500 });
    }

    if (SectionMode == "btnSaveControl") {
        toastr.success('Help doc control details saved successfully.', '', { timeOut: 1500 });
    }

    return false;
}
function SuccessUpdation(SectionMode) {

    if (SectionMode == "btnUpdateMain") {
        toastr.success('Help doc section details updated successfully.', '', { timeOut: 1500 });
    }

    if (SectionMode == "btnUpdateControl") {
        toastr.success('Help doc control details updated successfully.', '', { timeOut: 1500 });
    }                
    return false;
}


function onClickHelpControlForPopup(SectionId, ControlId) {
    $.ajax({
        type: "POST",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "/MasterPage/HelpDocWebService.asmx/GetControlDescription",
        data: '{SectionId: "' + SectionId + '",ControlId: "' + ControlId + '"}',
        dataType: "json",
        success: function (data) {

            if (data.d != "") {
                document.getElementById("pidDescrptnHelpDoc").innerHTML = data.d;
                document.getElementById('btnModalDescrptn').click();
            }
            else {
            }
        },

        error: function (result) {
            alert("Fail")
        }
    });
}

function onClickAddHelpContent(id) {

    document.getElementById("txtPriority").style.borderColor = "";
    document.getElementById("txtTitle").style.borderColor = "";
    document.getElementById("textddlSection").style.borderColor = "";
    document.getElementById("textMainMenu").style.borderColor = "";
    document.getElementById("textSubMenu").style.borderColor = "";
    document.getElementById("txtSectionName").style.borderColor = "";

    if (id == 'aidSection') {



        document.getElementById("hiddenControlCheck").value = "1";

        document.getElementById('divSection').style.display = 'block';
        document.getElementById('divddlMainMenu').style.display = 'block';
        document.getElementById('divddlSubMenu').style.display = 'block';
        document.getElementById('divControl').style.display = 'none';
        document.getElementById('divddlSection').style.display = 'none';

        document.getElementById('divMain').style.display = 'block';
        document.getElementById('divSub').style.display = 'none';
        document.getElementById('divCntrl').style.display = 'none';

    }

    if (id == 'aidSubSection') {
        document.getElementById("hiddenControlCheck").value = "1";

        document.getElementById('divddlSection').style.display = 'block';

        document.getElementById('divSection').style.display = 'none';
        document.getElementById('divControl').style.display = 'none';
        document.getElementById('divddlMainMenu').style.display = 'none';
        document.getElementById('divddlSubMenu').style.display = 'none';

        document.getElementById('divMain').style.display = 'none';
        document.getElementById('divSub').style.display = 'block';
        document.getElementById('divCntrl').style.display = 'none';
    }

    if (id == 'aidControls') {
        document.getElementById('divddlSection').style.display = 'block';
        document.getElementById('divControl').style.display = 'block';

        document.getElementById('divSection').style.display = 'none';
        document.getElementById('divddlMainMenu').style.display = 'none';
        document.getElementById('divddlSubMenu').style.display = 'none';

        document.getElementById('divMain').style.display = 'none';
        document.getElementById('divSub').style.display = 'none';
        document.getElementById('divCntrl').style.display = 'block';
    }
}


function isNumber(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function isPositiveInteger() {
    s = document.getElementById('txtPriority').value;
    if (!!s.match(/^[0-9]+$/) == false) {
        s = document.getElementById('txtPriority').value = "";
    }
}

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




