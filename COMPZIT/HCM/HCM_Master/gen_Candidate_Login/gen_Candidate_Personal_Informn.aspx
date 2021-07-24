<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageHcmCandidate.master" EnableEventValidation="false" CodeFile="gen_Candidate_Personal_Informn.aspx.cs" Inherits="Master_gen__Cand_Personal__Informn_gen__Cand_Personal__Informn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/JavaScript/jquery-1.8.3.min.js"></script>
    <style>
        /*other detatils multi file uploder*/

        .div-Contact-details {
            padding: 1% 2% 3% 2%;
            min-height: 104px;
            border: .5px solid;
            border-color: #9ba48b;
            background-color: #f3f3f3;
            width: 96%;
            margin-top: 0%;
        }

        /*other detatils multi file uploder*/
        #test th {
            border: 2px solid #0b0404;
            padding: 3px;
        }

        #test {
            background-color: #51828a;
            border-spacing: 10px;
            border-collapse: initial !important;
        }

            #test td {
                border: 2px solid #a1a1a1;
                padding: 6px;
                background-color: whitesmoke;
            }

            #test .selected {
                background-color: #24955b;
                color: white;
            }

            #test .highlight {
                background-color: papayawhip;
            }

            #test td:hover {
                background-color: #0e7777;
                color: white;
                cursor: pointer;
            }

        div.product:last-child {
            margin: 0px;
        }

        div.day:hover {
            border: 1px solid #878787;
            -moz-border-radius: 3px;
            border-radius: 3px;
        }

        div.day.unselected {
            opacity: 0.6;
            filter: alpha(opacity=60);
            background-color: red;
        }

        div.day.selected {
            border: 1px solid #32a24e;
            -moz-border-radius: 3px;
            border-radius: 3px;
        }

        .cont_rght {
            width: 100%;
            display: block;
            float: none;
            padding: 57px 0 0;
            margin: auto;
        }

        .eachform {
            width: 48%;
            margin-top: 1%;
        }

        .input-append .add-on {
            margin-top: -5%;
            padding-top: 2%;
            padding-bottom: 3%;
            cursor: pointer;
        }

        input[type="radio"] {
            display: block;
            float: left;
            font-family: Calibri;
        }

        /*Contact details*/
        .error {
            padding-top: 7%;
            padding-left: 35%;  
            color: red;
            font-size: small;
            margin-left: 11%;
            font-family: calibri;
        }
    </style>
    <style type="text/css">
        input[type="file"] {
            position: relative;
            z-index: 1;
            margin-left: -78px;
            display: none;
        }

        .custom-file-upload {
            border: 1px solid #ccc;
            display: inline-block;
            padding: 3px 8px;
            cursor: pointer;
            position: relative;
            z-index: 2;
            background: white;
            font-family: Calibri;
        }


        a.lightbox img {
            height: 150px;
            border: 3px solid white;
            box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
            margin: 94px 20px 20px 20px;
        }

        /* Styles the lightbox, removes it from sight and adds the fade-in transition */
        .lightbox-target {
            position: fixed;
            top: -100%;
            width: 100%;
            background: rgba(0, 0, 0, 0.7);
            width: 60%;
            opacity: 0;
            -webkit-transition: opacity .5s ease-in-out;
            -moz-transition: opacity .5s ease-in-out;
            -o-transition: opacity .5s ease-in-out;
            transition: opacity .5s ease-in-out;
            overflow: hidden;
        }

            /* Styles the lightbox image, centers it vertically and horizontally, adds the zoom-in transition and makes it responsive using a combination of margin and absolute positioning */
            .lightbox-target img {
                margin: auto;
                position: absolute;
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                max-height: 0%;
                max-width: 0%;
                border: 3px solid white;
                box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
                box-sizing: border-box;
                -webkit-transition: .5s ease-in-out;
                -moz-transition: .5s ease-in-out;
                -o-transition: .5s ease-in-out;
                transition: .5s ease-in-out;
            }

        /* Styles the close link, adds the slide down transition */
        a.lightbox-close {
            display: block;
            width: 50px;
            height: 50px;
            box-sizing: border-box;
            background: white;
            color: black;
            text-decoration: none;
            position: absolute;
            top: -80px;
            right: 0;
            -webkit-transition: .5s ease-in-out;
            -moz-transition: .5s ease-in-out;
            -o-transition: .5s ease-in-out;
            transition: .5s ease-in-out;
        }

            /* Provides part of the "X" to eliminate an image from the close link */
            a.lightbox-close:before {
                content: "";
                display: block;
                height: 30px;
                width: 1px;
                background: black;
                position: absolute;
                left: 26px;
                top: 10px;
                -webkit-transform: rotate(45deg);
                -moz-transform: rotate(45deg);
                -o-transform: rotate(45deg);
                transform: rotate(45deg);
            }

            /* Provides part of the "X" to eliminate an image from the close link */
            a.lightbox-close:after {
                content: "";
                display: block;
                height: 30px;
                width: 1px;
                background: black;
                position: absolute;
                left: 26px;
                top: 10px;
                -webkit-transform: rotate(-45deg);
                -moz-transform: rotate(-45deg);
                -o-transform: rotate(-45deg);
                transform: rotate(-45deg);
            }

        /* Uses the :target pseudo-class to perform the animations upon clicking the .lightbox-target anchor */
        .lightbox-target:target {
            opacity: 1;
            top: 0;
            bottom: 0;
            z-index: 3;
            right: 18%;
            z-index: 102;
        }

            .lightbox-target:target img {
                max-height: 100%;
                max-width: 80%;
            }

            .lightbox-target:target a.lightbox-close {
                top: 0px;
            }
    </style>
    <style>
        #divMessageAreaMain {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: -2%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }

        #divMessageAreaPD {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: 0%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }

        #divMessageAreaDpnt {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: 0%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }

        /*SALARY DETAILS -0008*/
        #divMessageAreaSalary {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: 0%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }
        /*CONTACT DETAILS -0014*/
        #divMessageAreaCD {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: 0%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }
    </style>

    <style>
        #divMessageAreaforimig {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: 0%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }
    </style>


    <%--  job--%>
    <style>
        #divMessageAreaforjob {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: 0%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }
    </style>
    <%---------------Start Qualification ----------%>
    <style>
        .divbutton {
            display: inline-block;
            color: #0C7784;
            border: 1px solid #999;
            background: #CBCBCB;
            /*box-shadow: 0 0 5px -1px rgba(0,0,0,0.2);*/
            cursor: pointer;
            vertical-align: middle;
            width: 23.5%;
            padding: 5px;
            text-align: center;
            font-family: calibri;
        }

            .divbutton:active {
                color: red;
                box-shadow: 0 0 5px -1px rgba(0,0,0,0.6);
            }

        .Quacaption {
            font-size: 21px;
            font-weight: bold;
            color: rgb(83, 101, 51);
            font-family: Calibri;
        }

        #divMessageAreaWrkExp {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: 0%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }

        #divMessageAreaEdu {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: 0%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }

        #divMessageAreaSkCer {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: 0%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }

        #divMessageAreaLang {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: 0%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }
    </style>

    <%--  Styles for personal info--%>
    <style>
        .form-tooltip {
            display: table-cell;
            visibility: hidden;
            position: absolute;
            box-sizing: content-box;
            height: 0;
            margin-left: 33%;
            margin-top: 2.5%;
            /*margin-bottom: -8px;*/
            cursor: help;
            width: 235px;
            word-break: break-all;
            word-wrap: break-word;
            padding: 4px 5px;
            background: #bbb;
            color: #fff;
            font-weight: 600;
            font-size: 12px;
            /*line-height: 16px;*/
            font-family: Calibri;
        }

        :focus + .form-tooltip {
            margin-bottom: 0;
            height: auto;
            visibility: visible;
        }
    </style>
    <style>
        /* Styles the thumbnail */
        a.lightbox img {
            height: 150px;
            border: 3px solid white;
            box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
            margin: 94px 20px 20px 20px;
        }

        /* Styles the lightbox, removes it from sight and adds the fade-in transition */
        .lightbox-target {
            position: fixed;
            top: -100%;
            width: 100%;
            background: rgba(0, 0, 0, 0.7);
            width: 60%;
            opacity: 0;
            -webkit-transition: opacity .5s ease-in-out;
            -moz-transition: opacity .5s ease-in-out;
            -o-transition: opacity .5s ease-in-out;
            transition: opacity .5s ease-in-out;
            overflow: hidden;
        }

            /* Styles the lightbox image, centers it vertically and horizontally, adds the zoom-in transition and makes it responsive using a combination of margin and absolute positioning */
            .lightbox-target img {
                margin: auto;
                position: absolute;
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                max-height: 0%;
                max-width: 0%;
                border: 3px solid white;
                box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
                box-sizing: border-box;
                -webkit-transition: .5s ease-in-out;
                -moz-transition: .5s ease-in-out;
                -o-transition: .5s ease-in-out;
                transition: .5s ease-in-out;
            }

        /* Styles the close link, adds the slide down transition */
        a.lightbox-close {
            display: block;
            width: 50px;
            height: 50px;
            box-sizing: border-box;
            background: white;
            color: black;
            text-decoration: none;
            position: absolute;
            top: -80px;
            right: 0;
            -webkit-transition: .5s ease-in-out;
            -moz-transition: .5s ease-in-out;
            -o-transition: .5s ease-in-out;
            transition: .5s ease-in-out;
        }

            /* Provides part of the "X" to eliminate an image from the close link */
            a.lightbox-close:before {
                content: "";
                display: block;
                height: 30px;
                width: 1px;
                background: black;
                position: absolute;
                left: 26px;
                top: 10px;
                -webkit-transform: rotate(45deg);
                -moz-transform: rotate(45deg);
                -o-transform: rotate(45deg);
                transform: rotate(45deg);
            }

            /* Provides part of the "X" to eliminate an image from the close link */
            a.lightbox-close:after {
                content: "";
                display: block;
                height: 30px;
                width: 1px;
                background: black;
                position: absolute;
                left: 26px;
                top: 10px;
                -webkit-transform: rotate(-45deg);
                -moz-transform: rotate(-45deg);
                -o-transform: rotate(-45deg);
                transform: rotate(-45deg);
            }

        /* Uses the :target pseudo-class to perform the animations upon clicking the .lightbox-target anchor */
        .lightbox-target:target {
            opacity: 1;
            top: 0;
            bottom: 0;
            z-index: 3;
            right: 18%;
            z-index: 102;
        }

            .lightbox-target:target img {
                max-height: 100%;
                max-width: 80%;
            }

            .lightbox-target:target a.lightbox-close {
                top: 0px;
            }
    </style>

    <style>
        .fillform {
            width: 100%;
        }

        .subform {
            float: left;
            margin-left: 38.8%;
        }

        .fillform p {
            color: red;
            margin-top: 5%;
            margin-left: 40%;
        }

        .fillform h2 {
        }


        #cphMain_divCompzitModuleList label {
            float: left;
            margin-bottom: 0px;
            color: #16682a;
            font-family: Calibri;
            font-size: 15px;
        }

        #cphMain_divCompzitModuleList input[type="checkbox"] {
            float: left;
            margin: 3px 8px 3px 3px;
        }

        #cphMain_mydiv {
            background: #F3FFEF;
            text-align: left;
            overflow: auto;
            margin-left: 18%;
            max-height: 220px;
        }

        #divDpartmnt {
            text-align: left;
            overflow: auto;
            margin-left: 18%;
            max-height: 220px;
            font-family: Calibri;
            box-shadow: 0px 0px 3px rgb(3, 185, 57);
            border-radius: 7px;
            background: #edf6dc;
            font-weight: bold;
            font-size: 15px;
            color: #4b7206;
            padding: 0px 19px 0px;
        }

        #divDivision {
            text-align: left;
            overflow: auto;
            margin-left: 18%;
            max-height: 220px;
            font-family: Calibri;
            box-shadow: 0px 0px 3px rgb(3, 185, 57);
            border-radius: 7px;
            background: #edf6dc;
            font-weight: bold;
            font-size: 15px;
            color: #4b7206;
            padding: 0px 19px 0px;
        }
        /*//0013*/
        #userRolTre {
            text-align: left;
            overflow: auto;
            margin-left: 18%;
            max-height: 220px;
            font-family: Calibri;
            box-shadow: 0px 0px 3px rgb(3, 185, 57);
            border-radius: 7px;
            background: #edf6dc;
            font-weight: bold;
            font-size: 15px;
            color: #4b7206;
            padding: 0px 19px 0px;
        }

        a {
            color: #4abe66;
        }

            a:hover {
                color: #08661f;
            }
        /*//0013*/
        #divSubBus {
            text-align: left;
            overflow: auto;
            margin-left: 18%;
            max-height: 220px;
            font-family: Calibri;
            box-shadow: 0px 0px 3px rgb(3, 185, 57);
            border-radius: 7px;
            background: #edf6dc;
            font-weight: bold;
            font-size: 15px;
            color: #4b7206;
            padding: 0px 19px 0px;
        }

        .accordion-section-title {
            color: #c9f9d5;
        }

            .accordion-section-title:hover {
                color: #e2f3c7;
            }

        #cphMain_cbxlCorporateDvsn label {
            cursor: pointer;
        }

        .imgDescription {
            position: absolute;
            /*top: 511px;
            left: 6.5%;*/
            background: rgba(123, 150, 100, 0.7);
            visibility: hidden;
            opacity: 0;
            padding: 0.1%;
            font-family: Calibri;
            /*remove comment if you want a gradual transition between states
  -webkit-transition: visibility opacity 0.2s;
  */
        }

        .imgWrap:hover .imgDescription {
            visibility: visible;
            opacity: 1;
        }

        .caption {
            font-family: Calibri;
            font-size: 18px;
            float: left;
            text-align: left;
            color: rgb(81, 107, 36);
            padding: 0;
            margin: 0px -1.2% 1.3%;
            line-height: 1;
            font-weight: normal;
        }
    </style>

    <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true


            });
            $p('#ReportTableWrkExp').DataTable({         //emp17  pagination after delete
                "pagingType": "full_numbers",
                "bSort": true

            });



            $p('#ReportTableEdu').DataTable({
                "pagingType": "full_numbers",
                "bSort": true


            });
            $p('#ReportTableLang').DataTable({
                "pagingType": "full_numbers",
                "bSort": true


            });
            $p('#ReportTableSkCer').DataTable({
                "pagingType": "full_numbers",
                "bSort": true


            });

            $p('#ReportTableAllow').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "bDestroy": true


            });
            $p('#ReportTableDedtn').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "bDestroy": true


            });
            $p('#ReportTableImgrtn').DataTable({
                "pagingType": "full_numbers",
                "bSort": true

            });
            $p('#ReportTableImgrtn1').DataTable({
                "pagingType": "full_numbers",
                "bSort": true

            });

            $p('#ReportTableJob').DataTable({
                "bSort": true

            });
            $p('#ReportTableforproject').DataTable({
                "pagingType": "full_numbers",
                "bSort": true

            });
            $p('#ReportTableDep').DataTable({
                "pagingType": "full_numbers",
                "bSort": true

            });


        });


    </script>

    <script>function divButtonWrkExpClick() {
    //hiding other
    document.getElementById('divButtonEducation').style.backgroundColor = "#CBCBCB";
    // document.getElementById('divButtonSkill').style.backgroundColor = "#CBCBCB";
    document.getElementById('divButtonLang').style.backgroundColor = "#CBCBCB";

    document.getElementById('divEductn').style.display = "none";
    // document.getElementById('divSkillCer').style.display = "none";
    document.getElementById('divLang').style.display = "none";


    //displaying current
    document.getElementById('divButtonWrkExp').style.backgroundColor = "#f9f9f9";
    document.getElementById('divWorkExp').style.display = "block";
    document.getElementById('cphMain_txtNameOfEmployerWrkExp').focus();       //12emp17

}
        function divButtonEductnClick() {
            //hiding other
            document.getElementById('divButtonWrkExp').style.backgroundColor = "#CBCBCB";
            // document.getElementById('divButtonSkill').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonLang').style.backgroundColor = "#CBCBCB";

            document.getElementById('divWorkExp').style.display = "none";
            //    document.getElementById('divSkillCer').style.display = "none";
            document.getElementById('divLang').style.display = "none";


            //displaying current
            document.getElementById('divButtonEducation').style.backgroundColor = "#f9f9f9";
            document.getElementById('divEductn').style.display = "block";
            document.getElementById('cphMain_ddlEduType').focus();

        }
        function divButtonSkillClick() {
            //hiding other
            document.getElementById('divButtonEducation').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonWrkExp').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonLang').style.backgroundColor = "#CBCBCB";

            document.getElementById('divEductn').style.display = "none";
            document.getElementById('divWorkExp').style.display = "none";
            document.getElementById('divLang').style.display = "none";


            //displaying current
            //   document.getElementById('divButtonSkill').style.backgroundColor = "#f9f9f9";
            //   document.getElementById('divSkillCer').style.display = "block";
            //  document.getElementById('cphMain_ddlSCSkill').focus();    //12emp17

        }
        function divButtonLangClick() {

            //hiding other
            document.getElementById('divButtonEducation').style.backgroundColor = "#CBCBCB";
            //     document.getElementById('divButtonSkill').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonWrkExp').style.backgroundColor = "#CBCBCB";

            document.getElementById('divEductn').style.display = "none";
            // document.getElementById('divSkillCer').style.display = "none";
            document.getElementById('divWorkExp').style.display = "none";


            //displaying current
            document.getElementById('divButtonLang').style.backgroundColor = "#f9f9f9";
            document.getElementById('divLang').style.display = "block";
            document.getElementById('cphMain_ddlQuLang').focus();   //12emp17

        }</script>
    <script>


        var $Mo = jQuery.noConflict();
        function tableClick(x, Y) {

            if (confirmboxDep != 0 && confirmboxDep != 0) {
             //   if (confirm("Do you want to cancel this entry?")) {

                    var data;


                    var $MoparentTr = $Mo('td').closest('tr');

                    $MoparentTr.find('.selected').each(function () {
                        data = $Mo(this).attr('id');
                        //alert('selecte' + data);
                        document.getElementById("div" + data).style.display = "none";
                        $Mo(this).removeClass("selected");
                    });


                    // $Mo("td").removeClass("selected");
                    var selected = $Mo(Y).hasClass("selected");
                    $Mo(Y).removeClass("selected");
                    //alert(selected);
                    if (!selected) {
                        $Mo(Y).addClass("selected");
                        // alert("IDSELECTED");
                        // document.getElementById("div1").style.display = "block";
                        document.getElementById(x).style.display = "block";


                    }

              //  }
                else {

                    }
                   // var id = document.getElementById("<%=HiddenCandidateId.ClientID%>").value;
                
                //var Details = PageMethods.ReadDepntDtlTable(id, function (response) {
                        
                
                //        document.getElementById("cphMain_divReportforDependent").innerHTML = response;
                //        $p('#ReportTableDep').DataTable({
                //            "pagingType": "full_numbers",
                //            "bSort": true

                //        });

                //    });
            }
            else {
                var data;


                var $MoparentTr = $Mo('td').closest('tr');

                $MoparentTr.find('.selected').each(function () {
                    data = $Mo(this).attr('id');
                    //alert('selecte' + data);
                    document.getElementById("div" + data).style.display = "none";
                    $Mo(this).removeClass("selected");
                });


                // $Mo("td").removeClass("selected");
                var selected = $Mo(Y).hasClass("selected");
                $Mo(Y).removeClass("selected");

                if (!selected) {
                    $Mo(Y).addClass("selected");

                    document.getElementById(x).style.display = "block";
                    //contact details
                    if ($Mo(Y).attr('id').toString() == "Tblid2") {
                        document.getElementById("<%=txtPermAddrsSCD.ClientID%>").focus();
                }

                //stop contact details
                }
               // var id = document.getElementById("<%=HiddenCandidateId.ClientID%>").value;
            
                //var Details = PageMethods.ReadDepntDtlTable(id, function (response) {
                   
                //    document.getElementById("cphMain_divReportforDependent").innerHTML = response;
                //    $p('#ReportTableDep').DataTable({
                //        "pagingType": "full_numbers",
                //        "bSort": true

                //    });
                //});
        }
        var id1 = x;             //emp17
        if (id1 == "divTblid7") {
            divButtonEductnClick();
            var id = document.getElementById("<%=HiddenCandidateId.ClientID%>").value;
            var Corpid = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
            var orgid = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
            var Details = PageMethods.ReadQualificTablee(id, Corpid, orgid, function (response) {
          
                document.getElementById("cphMain_divListEdu").innerHTML = response[0];
               document.getElementById("cphMain_divListWrkExp").innerHTML = response[2];
               document.getElementById("cphMain_divListLang").innerHTML = response[1];
                $p('#ReportTableEdu').DataTable({
                    "pagingType": "full_numbers",
                    "bSort": true

                });
                $p('#ReportTableWrkExp').DataTable({
                    "pagingType": "full_numbers",
                    "bSort": true

                });
                $p('#ReportTableLang').DataTable({
                    "pagingType": "full_numbers",
                    "bSort": true

                });
            });

            document.getElementById('cphMain_txtNameOfEmployerWrkExp').focus();

        }
        if (id1 == "divTblid8") {
            divButtonEductnClick();
            document.getElementById('cphMain_txtName').focus();

        }
        if (id1 == "divTblid4") {
            var id = document.getElementById("<%=HiddenCandidateId.ClientID%>").value;
            var Corpid = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
            var orgid = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
            
            
            var Details = PageMethods.ReadImmigrationTable(id,Corpid,orgid, function (response) {

                document.getElementById("cphMain_divImigList").innerHTML = response;
                $p('#ReportTableImgrtn').DataTable({
                    "pagingType": "full_numbers",
                    "bSort": true

                });
            });

            document.getElementById('cphMain_Ddlvisatype').focus();
        }//emp17
        if (id1 == "divTblid5") {

            document.getElementById('cphMain_txtJoineddate').focus();
        }//emp17
        //emp17
        //  var id1=x;             //emp17
        if (id1 == "divTblid1") //emp17

        {

            document.getElementById('cphMain_TextName1').focus();
        } //emp17
        if (id1 == "divTblid3") //emp17

        {
            var id = document.getElementById("<%=HiddenCandidateId.ClientID%>").value;

            var Details = PageMethods.ReadDepntDtlTable(id, function (response) {

                document.getElementById("cphMain_divReportforDependent").innerHTML = response;
                $p('#ReportTableDep').DataTable({
                    "pagingType": "full_numbers",
                    "bSort": true

                });
            });

            if (document.getElementById("<%=HiddenDisplayMrgDtl.ClientID%>").value == "0") {
                document.getElementById("<%=txtDepndtNameFM.ClientID%>").focus();
            }
            else {

                document.getElementById("<%=txtDepndtNameFM.ClientID%>").focus();
            }


        } //emp17

    }

    </script>


    <script type="text/javascript">
        var $a = jQuery.noConflict();
        $a(window).load(function () {

            //loc
            if (document.getElementById("<%=HiddenStaffHR.ClientID%>").value == "HR") {

                document.getElementById("divHrContact").style.display = "";

            }
            else {
                document.getElementById("divHrContact").style.display = "none";

            }
            // LoadListPageallwnce();

            //  document.getElementById("DivJoiningDate").style.display = "none";
            //   document.getElementById("freezelayer").style.display = "none";
            //  document.getElementById('MymodalCancelView').style.display = "none";
            //document.getElementById('divmodalCancelViewForimig').style.display = "none";
            //    document.getElementById('divMessageArea').style.display = "none";
            //    document.getElementById('imgMessageArea').src = "";
            var IdChk = "";
            var $aa = jQuery.noConflict();
            var $aaoparentTr = $aa('td').closest('tr');
            $aaoparentTr.find('.selected').each(function () {
                IdChk = $aa(this).attr('id');

            });
            if (IdChk == "") {

                tableClick('divTblid8', Tblid8);
                //document.getElementById("<%%>").focus();
            }


            if (document.getElementById("<%=HiddenDisplayMrgDtl.ClientID%>").value == "0") {
                // document.getElementById("divMrgInfo").style.display = "block";
            }
            else {

                //  document.getElementById("divMrgInfo").style.display = "none";
                document.getElementById("divDepnt").style.border = "";
                document.getElementById("<%=txtDepndtNameFM.ClientID%>").focus();
            }



            //Qualification
            var QuafcnMode = document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value;



            if (QuafcnMode == "Education") {
                divButtonEductnClick();
            }
            else if (QuafcnMode == "Skl&Cer") {
                // divButtonSkillClick();
            }
            else if (QuafcnMode == "Language") {
                divButtonLangClick();
            }
            else if (QuafcnMode == "Work") {
                divButtonWrkExpClick();
            }
            else
                divButtonEductnClick();




        });



        function IsAdd() {
            var $a = jQuery.noConflict();
            $a(function () {
                $a('#Tblid2').css('pointer-events', 'none');

                $a('#Tblid3').css('pointer-events', 'none');
                $a('#Tblid4').css('pointer-events', 'none');
                $a('#Tblid1').css('pointer-events', 'none');
                $a('#Tblid7').css('pointer-events', 'none');
                $a('#Tblid5').css('pointer-events', 'none');
                $a('#Tblid6').css('pointer-events', 'none');
            });


        }
        function Notadd() {
            var $a = jQuery.noConflict();
            $a(function () {
                $a('#Tblid2').css('pointer-events', 'all');

                $a('#Tblid3').css('pointer-events', 'all');
                $a('#Tblid4').css('pointer-events', 'all');
                $a('#Tblid1').css('pointer-events', 'all');

                $a('#Tblid5').css('pointer-events', 'all');
                $a('#Tblid7').css('pointer-events', 'all');
                $a('#Tblid6').css('pointer-events', 'all');


            });


        }

        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        //function textCounter(field, maxlimit) {
        //  RemoveTag(field);
        //    if (field.value.length > maxlimit) {
        //        field.value = field.value.substring(0, maxlimit);

        //    } else {

        //    }
        //}
        //Qualification
    </script>
    <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen"
        href="/css/Date/StyleSheetDate.css" />
    <script type="text/javascript" src="/JavaScript/Date/JavaScriptDate1_8_3.js"></script>

    <script type="text/javascript"
        src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
    </script>
    <script type="text/javascript"
        src="/JavaScript/Date/bootstrap-datepicker.js">
    </script>
    <script type="text/javascript"
        src="/JavaScript/Date/bootstrap-datepicker_pt_br.js">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="HiddenStaffHR" runat="server" />
    <asp:HiddenField ID="HiddenEmployeeMasterId" runat="server" />
    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="hiddenCancelReason" runat="server" />
    <asp:HiddenField ID="hiddenRoleReOpen" runat="server" />
    <asp:HiddenField ID="hiddenUserImageSize" runat="server" />
    <asp:HiddenField ID="hiddenUserImage" runat="server" />
    <asp:HiddenField ID="hiddenImageName" runat="server" />
    <asp:HiddenField ID="HiddenDisplayMrgDtl" runat="server" />
    <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <asp:HiddenField ID="HiddnEnableCacel" runat="server" />
    <%-- <div id="weekly" style="float:left;margin-top:1% ;width: 77%;">

         

    <%------Start Dependent details --------%>
    <asp:HiddenField ID="HiddenDepntId" runat="server" />
    <asp:HiddenField ID="HiddenEmpUserId" runat="server" />
    <%------End Dependent details --------%>
    <%------Start immigration details --------%>
    <asp:HiddenField ID="HiddenImmigid" runat="server" />
    <asp:HiddenField ID="HiddenEmpoyeeid" runat="server" />

    <%------End Dependent details --------%>
    <%------Start immigration details --------%>
    <asp:HiddenField ID="HiddenJobdtlId" runat="server" />


    <%---Start Contact details --%>
    <asp:HiddenField ID="hiddenConfirmValueCD" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDateCD" runat="server" />
    <asp:HiddenField ID="HiddenContactUserId" runat="server" />

    <asp:HiddenField ID="HiddenStateValueCD" runat="server" />
    <asp:HiddenField ID="HiddenCityValueCD" runat="server" />
    <asp:HiddenField ID="HiddenCommuStateValueCD" runat="server" />
    <asp:HiddenField ID="HiddenCommuCityValueCD" runat="server" />
    <asp:HiddenField ID="HiddenCommuCountryValueCD" runat="server" />
    <asp:HiddenField ID="HiddenCountryValueCD" runat="server" />
    <%--end Contact details ---%>
    <%----------------- Start Qualification -------------%>
    <asp:HiddenField ID="HiddenWorkExpDtlId" runat="server" />
    <asp:HiddenField ID="HiddenField4" runat="server" />
    <asp:HiddenField ID="HiddenEductnDtlId" runat="server" />
    <asp:HiddenField ID="HiddenFieldSkCerDtlId" runat="server" />
    <asp:HiddenField ID="HiddenFieldLangDtlId" runat="server" />
    <asp:HiddenField ID="HiddenFieldQualfcnMode" runat="server" />
    <%------------------End Qualification ----------------%>

    <div id="emplyoptn" style="float: left; margin-top: 3%; margin-left: 0%; width: 13%;">
        <table id="test" class="logo" style="width: 99%; float: left; margin-right: 0%; height: 10%; border: 2px solid #06558f; border-spacing: 10px; font-family: Calibri">
            <tr>
                <%--Menu list--%>
                <td id="Tblid8" onclick="tableClick('divTblid8',Tblid8);" style="font-family: Calibri">Personal Details</td>
            </tr>

            <tr>
                <td id="Tblid2" onclick="tableClick('divTblid2',Tblid2);">Contact Details</td>
            </tr>
            <tr>
                <td id="Tblid3" onclick="tableClick('divTblid3',Tblid3);">Family Details</td>
            </tr>
            <tr>

                <td id="Tblid4" onclick="tableClick('divTblid4',Tblid4);">Immigration</td>
            </tr>
            <tr>
                <td id="Tblid7" onclick="tableClick('divTblid7',Tblid7);">Qualification</td>
            </tr>
            <tr>
                <td id="Tblid1" onclick="tableClick('divTblid1',Tblid1);">Other Details</td>
            </tr>

           <tr>

                <asp:Button ID="btnCnfrmPrsn" runat="server" Style="width: 97%; border: 2px solid #005f5b; background: #51828a;" class="save" Text="Confirm" OnClientClick="return ValidateAll();" OnClick="btnCnfrmPrsn_Click" />

           </tr>

        </table>


    </div>

    <%--   </div>--%>


    <%-- <div id="div1" class="list"  onclick="return ConfirmMessage();"  runat="server" style="position:fixed; right:0%; top:42%;height:26.5px;">

        </div>--%>



    <div id="divMain" style="width: 85%; margin-top: 3%; float: left; margin-left: 0%;">
        <div id="divMessageArea" style="display: none; width: 84%; margin-left: 6%; margin-top: -12px;">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
        <%--------------------personal details start--------------------------%>
        <%------------------emp0021--------------------------%>
        <div id="divTblid8" style="float: left; background-color: #f3f3f3; width: 100%; border: 2px solid; border-color: #06558f; padding: 2%; display: none">

            <asp:HiddenField ID="HiddenField2_FileUpload" runat="server" />
            <asp:HiddenField ID="HiddenView" runat="server" />
            <asp:HiddenField ID="HiddenEdit" runat="server" />
            <asp:HiddenField ID="HiddenDelView" runat="server" />
            <asp:HiddenField ID="HiddenFilePath" runat="server" />
            <asp:HiddenField ID="hiddenPerFileCanclDtlId" runat="server" />
            <%------------------emp0021--------------------------%>
            <asp:HiddenField ID="hiddenLicenseTypeId" runat="server" />
            <asp:HiddenField ID="HiddenField13" runat="server" />
            <asp:HiddenField ID="HiddenField14" runat="server" />
            <asp:HiddenField ID="hiddenUserLicenseCopy" runat="server" />
            <asp:HiddenField ID="hiddenUserEditId" runat="server" />
            <asp:HiddenField ID="hiddenDsgnContrl" runat="server" />
            <asp:HiddenField ID="HiddenField15" runat="server" />
            <asp:HiddenField ID="hiddenLicenseCopyName" runat="server" />
            <asp:HiddenField ID="HiddenField16" runat="server" />
            <asp:HiddenField ID="HiddenJobrole" runat="server" />

            <div class="cont_rght">

                <div id="divMessageAreaMain" style="display: none; width: 84%; margin-left: 8%;">
                    <img id="imgMessageAreaMain" style="float: left" src="" />
                    <asp:Label ID="LblMessageAreaMain" runat="server"></asp:Label>
                </div>

                <%--<h2>Add Personal Details</h2>--%>

                <%--<asp:Label ID="Labelcaption" runat="server"></asp:Label>--%>
                <div>
                    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                        <asp:Label ID="lblEntry" runat="server"></asp:Label>
                    </div>








                    <%--   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
       <ContentTemplate>--%>



                    <div style="float: left; width: 95%">
                        <div style="width: 100%; float: left" id="Divcand" runat="server">
                            <div class="eachform " style="float: left; width: 36%;">

                                <h2 style="margin-top: 0%;">Candidate*</h2>

                                <asp:DropDownList ID="ddlCandidateName" Width="265px" class="form1" onchange="return IncrmntConfrmCounterpd();" runat="server" Height="30px"></asp:DropDownList>

                                <p class="error" id="P6" style="visibility: hidden; font-family: Calibri; font-size: small; margin-top: 0%; margin-left: 0%;">Please enter </p>


                            </div>
                        </div>
                        <div id="div7" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                            <asp:Label ID="Label3" runat="server">Personal Details</asp:Label>
                        </div>
                        <br />

                            

                      
                        <div class="eachform" style="width: 51%; float: left; height: 35px;">

                            <h2 style="margin-top: 0%;">Name as per the passport* </h2>
                            <asp:TextBox ID="txtName" class="form1" onchange="return IncrmntConfrmCounterpd();" runat="server" MaxLength="49" Height="30px" Width="250px" onkeydown="return isTag(event)" onblur="return RemoveTag('cphMain_txtName')" Style="text-transform: uppercase; float: right; margin-left: 10.5%;"></asp:TextBox>

                            <p class="error" id="P1" style="visibility: hidden; font-family: Calibri; font-size: small; margin-top: 0%; margin-left: 0%;">Please enter valid Contact Number</p>

                        </div>
                           <div class="eachform" style="width: 45%; float: right;">

                            <h2 style="margin-top: 0%;">First Name* </h2>
                            <asp:TextBox ID="TxtFirstName" class="form1" runat="server" onchange="return IncrmntConfrmCounterpd();" MaxLength="49" Height="30px" Width="55%" onkeydown="return isTag(event)" onblur="return RemoveTag('cphMain_TxtFirstName')" Style="text-transform: uppercase; float: right; margin-top: 0%"></asp:TextBox>

                           
                                  </div>

                           <div class="eachform" style="width: 51%; float: left; height: 35px;">

                            <h2 style="margin-top: 0%;">Middle Name</h2>
                            <asp:TextBox ID="TxtMiddleName" class="form1" onchange="return IncrmntConfrmCounterpd();" runat="server" MaxLength="49" Height="30px" Width="250px" onkeydown="return isTag(event)" onblur="return RemoveTag('cphMain_TxtMiddleName')" Style="text-transform: uppercase; float: right; margin-left: 10.5%;"></asp:TextBox>

                           

                        </div>
                          <div class="eachform" style="width: 45%; float: right;">

                            <h2 style="margin-top: 0%;">Last Name* </h2>
                            <asp:TextBox ID="TxtLastName" class="form1" runat="server" onchange="return IncrmntConfrmCounterpd();" MaxLength="49" Height="30px" Width="55%" onkeydown="return isTag(event)" onblur="return RemoveTag('cphMain_TxtLastName')" Style="text-transform: uppercase; float: right; margin-top: 0%"></asp:TextBox>

                           
                                  </div>
                  

                    </div>
                    <div style="float: left; width: 95%" id="divDivforHRPd" runat="server">
                        <div class="eachform" style="float: left; width: 45%;">
                            <h2 style="margin-top: 0%;">Division*</h2>

                            <asp:DropDownList ID="ddlDivison" Height="30px" Width="267px" onchange="return IncrmntConfrmCounterpd();" class="form1" runat="server" Style="text-align: left; margin-left: 7.5%; float: left; margin-top: 0%;"></asp:DropDownList>

                        </div>






                        <div class="eachform " style="float: right; width: 45%;">

                            <h2 style="margin-top: 0%;">Designation*</h2>

                            <asp:DropDownList ID="ddlUsrDsgn" Width="265px" class="form1" onchange="return IncrmntConfrmCounterpd();" runat="server" Height="30px"></asp:DropDownList>

                            <p class="error" id="P2" style="visibility: hidden; font-family: Calibri; font-size: small; margin-top: 0%; margin-left: 0%;">Please enter </p>


                        </div>


                        <%--    0013--%>


                        <%--                           </ContentTemplate>
   </asp:UpdatePanel>--%>
                    </div>


                    <div style="float: left; width: 95%">

                        <div class="eachform" style="width: 51%; float: left; height: 35px;">

                            <h2 style="">Mobile </h2>
                            <asp:TextBox ID="txtUsrMob" class="form1" runat="server" onchange="return IncrmntConfrmCounterpd();" MaxLength="20" Height="30px" Width="250px" onkeydown="return isNumber(event)" onblur="return BlurNotNumber('cphMain_txtUsrMob')" Style="text-transform: uppercase; float: right;"></asp:TextBox>                          
                        
<%--                            <p class="error" id="ErrorMsgUsrMob" style="display: none; padding-left: 6%; font-family: Calibri; font-size: small; margin-top: 1px; margin-left: 12%;">Please enter valid Mobile Number</p>--%>
                     <p class="error" id="ErrorMsgUsrMob" style="display:none;padding-left:36.5%;">Please enter valid mobile number</p> <%--evm-0023--%>
                                      

                        </div>
                        <div class="eachform" style="float: right;">
                            <h2 style="margin-left: 7%; margin-top: 0%;">Nationality*</h2>

                            <asp:DropDownList ID="ddlNationality" Height="30px" Width="55%" onchange="return IncrmntConfrmCounterpd();" class="form1" runat="server" Style="text-align: left; float: right;"></asp:DropDownList>
                            <p class="error" id="P5" style="visibility: hidden; padding-left: 6%; font-family: Calibri; font-size: small; margin-top: 1px; margin-left: 42%;">Please select</p>

                        </div>

                    </div>


               <div style="float: left; width: 95%">

                    <div class="eachform" style="float: left; width: 51%;">

                        <h2 id="lblEmail" style="">Email*</h2>

                        <asp:TextBox ID="txtUsrEmail" class="form1" runat="server" onchange="return IncrmntConfrmCounterpd();" MaxLength="99" Height="30px" Width="250px" onkeypress="return isTag(event)" onblur="RemoveTag('cphMain_txtUsrEmail');" Style="float:right"></asp:TextBox>

                        <%--<p class="error" id="ErrorMsgUsrEmail" style="display: none; padding-left: 6%; font-family: Calibri; font-size: small; margin-top: 1px; margin-left: 12%;">Please enter valid email address</p>--%>
                        <p class="error" id="ErrorMsgUsrEmail" style="display:none;padding-left:36.5%;">Please enter valid email address</p> <%--evm-0023--%>

                    </div>
                         <div class="eachform" style="width: 45%; float: right;">

                            <h2 style="margin-top: 0%;">Local Contact Number </h2>
                            <asp:TextBox ID="txtloccontact" class="form1" runat="server" onchange="return IncrmntConfrmCounterpd();" MaxLength="20" Height="30px" Width="55%" onkeydown="return isNumber(event)" onblur="return BlurNotNumber('cphMain_txtloccontact')" Style="text-transform: uppercase; float: right; margin-top: 0%"></asp:TextBox>

                            <%--<p class="error" id="ErrorMsgUsrMob1" style="visibility: hidden; font-family: Calibri; font-size: small; margin-top: 0%; margin-left: 0%;">Please enter valid Contact Number</p>--%>
                             <p class="error" id="ErrorMsgUsrMob1" style="display:none;padding-left:36.5%;">Please enter valid Contact Number</p> <%--evm-0023--%>

                        </div>

                   </div>
                    












                    <br />

                    <div class="eachform" style="width: 94%;">
                        <div class="subform" style="width: 38%;">


                            <asp:Button ID="btnUpdatepersonal" runat="server" class="save" Text="Update" OnClientClick="return BssicInfoValidation('update');" OnClick="btnUpdatePersonalDtls_Click" />
                            <asp:Button ID="btnUpdateClosepersonal" runat="server" class="save" Text="Update & Close" OnClientClick="return BssicInfoValidation('update'); " OnClick="btnUpdatePersonalDtls_Click" />
                            <asp:Button ID="btnAddpersonal" runat="server" class="save" Text="Save" OnClientClick="return BssicInfoValidation('add'); " OnClick="btnAddPersnl_Click" />
                            <asp:Button ID="btnAddClosepersonal" runat="server" class="save" Text="Save & Close" OnClientClick="return BssicInfoValidation('add'); " OnClick="btnAddPersnl_Click" />
                            <asp:Button ID="btnCancelpersonal" runat="server" class="cancel" Text="Cancel" OnClientClick="return ConfirmMessagePDCancel();" />
                            <%--<asp:Button ID="Button1" runat="server" class="cancel" Text="test" OnClientClick="return testLicenseType();" />--%>
                        </div>
                    </div>

                    <%--    <div style="float: right;" align="right">
                <a href="javascript:;" id="scrollToTop" title="Goto Top">&#x25B2;</a>
            </div>--%>
                    <!-- The Modal Loading MAIL -->
                    <div id="myModalLoadingMail" class="modalLoadingMail">

                        <!-- Modal content -->
                        <%-- <div>

                    <img src="../../Images/Other Images/LoadingMail.gif" style="width: 12%;" />


                </div>--%>
                    </div>



                    <%--test modal stop--%>
                </div>

            </div>
        </div>
        <script>
            function AssignCanidateid() {
                var Canidate = document.getElementById("<%=ddlCandidateName.ClientID%>").value;
           if (Canidate != "--SELECT CANDIDATE--") {
               document.getElementById("<%=HiddenCandidateId.ClientID%>").value = Canidate;
               //alert(Canidate);
           }
       }


        </script>


        <%------------------------end personal details --------------------------------------%>




        <%------------------------Start Contact details --------------------------------------%>


        <div id="divTblid2" style="float: left; background-color: #f3f3f3; width: 100%; border: 2px solid; border-color: #06558f; padding: 2%; display: none">

            <asp:HiddenField ID="HiddenField3" runat="server" />
            <asp:HiddenField ID="HiddenField5" runat="server" />
            <asp:HiddenField ID="HiddenField6" runat="server" />
            <asp:HiddenField ID="HiddenMasterid" runat="server" />
            <asp:HiddenField ID="HiddenField7" runat="server" />
            <asp:HiddenField ID="HiddenField8" runat="server" />
            <asp:HiddenField ID="HiddenField9" runat="server" />
            <asp:HiddenField ID="HiddenField10" runat="server" />
            <asp:HiddenField ID="HiddenField11" runat="server" />
            <asp:HiddenField ID="HiddenField12" runat="server" />




            <div id="divMessageAreaCD" style="display: none; width: 84%; margin-left: 6%;">
                <img id="imgMessageAreaCD" src="" />
                <asp:Label ID="lblMessageAreaCD" runat="server"></asp:Label>
            </div>
            <div id="divReportCaptionCD" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; width: 99%;">
                <asp:Label ID="lblEntryCD" runat="server">Contact Details</asp:Label>
            </div>
            <br />
            <br />
            <div style="float: left; width: 100%">
                <div style="width: 99%; float: left; font-size: 18px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; text-decoration: underline;">Permanent Address</div>
                <div class="eachform" style="float: left;">
                    <h2 style="width: 46%;">Permanent Residential Address*</h2>
                    <asp:TextBox ID="txtPermAddrsSCD" class="form1" runat="server" onkeydown="textCounter(cphMain_txtPermAddrsSCD, 450);" onblur="textCounter(cphMain_txtPermAddrsSCD, 450);" onchange="return IncrmntConfrmCounterCD();" TextMode="MultiLine" MaxLength="450" Style="margin-right: 3.5%; resize: none; width: 46%; height: 100px; text-transform: uppercase; font-family: Calibri; margin-right: 3.5%;"></asp:TextBox>
                </div>
                <div class="eachform" style="float: right;">
                    <h2>In case of Emergency Contact*</h2>
                    <asp:TextBox ID="txtEmrgCntcSCD" class="form1" runat="server" onchange="return IncrmntConfrmCounterCD();" MaxLength="100" Width="46.5%" Height="30px" TextMode="MultiLine" onkeydown="textCounter(cphMain_txtEmrgCntcSCD, 450);" onblur="textCounter(cphMain_txtEmrgCntcSCD, 450);" Style="margin-right: 3.5%; resize: none; width: 46%; height: 100px; text-transform: uppercase; font-family: Calibri; margin-right: 3.5%;"></asp:TextBox>
                </div>

                <div id="divHrContact" style="display: block;">
                    <div class="eachform" style="float: left;">
                        <h2>Location of Stay</h2>
                        <asp:DropDownList ID="ddlLoctnSCD" Height="30px" Width="50%" onchange="return IncrmntConfrmCounterCD();" class="form1" runat="server" Style="margin-right: 3%; text-align: left;"></asp:DropDownList>
                    </div>

                    <div class="eachform" style="float: right;">
                        <h2>Recruited Through*</h2>
                        <asp:DropDownList ID="ddlRcrtdSCD" Height="30px" Width="50%" onchange="return IncrmntConfrmCounterCD();" class="form1" runat="server" Style="text-align: left; margin-right: 3%;">
                            <asp:ListItem Text="--SELECT REFERENCE--" Value="--SELECT REFERENCE--"></asp:ListItem>
                            <asp:ListItem Text="CONSULTANCY" Value="1"></asp:ListItem>
                            <asp:ListItem Text="DIVISION" Value="2"></asp:ListItem>
                            <asp:ListItem Text="DEPARTMENT" Value="3"></asp:ListItem>
                            <asp:ListItem Text="EMPLOYEE" Value="4"></asp:ListItem>





                        </asp:DropDownList>
                    </div>
                    <div class="eachform" style="float: left; width: 100%;">
                        <h2>Present Sponsor </h2>
                        <asp:RadioButton ID="RadioSponsor1" onclick="DisableSponsor('Sponsor1')" Style="float: left; margin-left: 11.5%; font-family: Calibri; color: #697259;" Text="Yes" onchange="return IncrmntConfrmCounterOther();" runat="server" GroupName="RadioSponsor" />
                        <asp:RadioButton ID="RadioSponsor2" onclick="DisableSponsor('Sponsor2')" Style="float: left; font-family: Calibri; color: #697259;" Text="No" onchange="return IncrmntConfrmCounterOther();" runat="server" GroupName="RadioSponsor" />
                        <h2 style="margin-left: 22.5%;">Sponsor*</h2>
                        <asp:DropDownList ID="ddlSpnsrSCD" Height="30px" Width="24%" class="form1" runat="server" Style="text-align: left; margin-right: 1.5%;"></asp:DropDownList>
                    </div>
                </div>

            </div>
            <div class="eachform" style="margin-top: 4%; margin-left: 20%;">
                <div class="subform" style="width: 448px;">
                    <div class="form-group">
                        <asp:Button ID="btnUpdateSCD" runat="server" class="save" Text="Update" OnClick="btnUpdateSCD_Click" OnClientClick="return validateSCD();" />
                        <asp:Button ID="btnAddSCD" runat="server" class="save" Text="Save" OnClick="btnAddCloseSCD_Click" OnClientClick="return validateSCD();" />
                        <asp:Button ID="btnClearSCD" runat="server" Style="margin-left: -1%;" OnClientClick="return AlertClearAllCD();" class="cancel" Text="Clear" />
                        <asp:Button ID="btnCancelSCD" runat="server" class="cancel" Text="Cancel" OnClientClick="return AlertCancelAllCD();" Style="margin-left: 2%;" />

                    </div>
                </div>
            </div>
        </div>


        <script>
            var confirmboxCD = 0;
            function IncrmntConfrmCounterCD() {
                confirmboxCD++;
            }
            var confirmbox = 0;
            function IncrmntConfrmCounter() {
                confirmbox++;
            }
            function AlertCancelAllCD() {
                if (confirmboxCD > 0) {
                    if (confirm("Are you sure you want cancel in this page?")) {
                        window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                    return false;
                }
            }


            function AlertClearAllCD1() {
                if (confirmboxCD > 0) {
                    if (confirm("Are you sure you want clear all data in this page?")) {
                        document.getElementById("<%=txtEmrgCntcSCD.ClientID%>").value = "";
                     document.getElementById("<%=txtPermAddrsSCD.ClientID%>").value = "";

                     return false;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 document.getElementById("<%=txtEmrgCntcSCD.ClientID%>").value = "";
                 document.getElementById("<%=txtPermAddrsSCD.ClientID%>").value = "";
                 //tableClick('divTblid1', Tblid1);
                 //tableClick('divTblid1', Tblid1);
                 return false;
             }
         }
         function validateSCD() {
             ret = true;

             var NameWithoutReplace = document.getElementById("<%=txtPermAddrsSCD.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtPermAddrsSCD.ClientID%>").value = replaceText2;

             NameWithoutReplace = document.getElementById("<%=txtEmrgCntcSCD.ClientID%>").value;
             replaceText1 = NameWithoutReplace.replace(/</g, "");
             replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtEmrgCntcSCD.ClientID%>").value = replaceText2;

             var hrStatus = document.getElementById("<%=HiddenStaffHR.ClientID%>").value;

             var EmrgCntcSCD = document.getElementById("<%=txtEmrgCntcSCD.ClientID%>").value;
             document.getElementById("<%=txtEmrgCntcSCD.ClientID%>").style.borderColor = "";
             // if (EmrgCntcSCD == "") {
             //    document.getElementById("<%=txtEmrgCntcSCD.ClientID%>").style.borderColor = "Red";
             //     document.getElementById('divMessageAreaCD').style.display = "block";
             //     document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
             //    document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

             //   ret = false;
             // }
             //txtPermAddrsSCD

             var txtEmrgCntcSCD = document.getElementById("<%=txtEmrgCntcSCD.ClientID%>").value.trim();
             document.getElementById("<%=txtEmrgCntcSCD.ClientID%>").value = txtEmrgCntcSCD;
             document.getElementById("<%=txtEmrgCntcSCD.ClientID%>").style.borderColor = "";
             if (txtEmrgCntcSCD == "") {
                 document.getElementById("<%=txtEmrgCntcSCD.ClientID%>").style.borderColor = "Red";
                 document.getElementById('divMessageAreaCD').style.display = "block";
                 document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
                 document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                 ret = false;
                 document.getElementById("<%=txtEmrgCntcSCD.ClientID%>").focus();
             }


             var txtPermAddrsSCD = document.getElementById("<%=txtPermAddrsSCD.ClientID%>").value.trim();
             document.getElementById("<%=txtPermAddrsSCD.ClientID%>").value = txtPermAddrsSCD;
             document.getElementById("<%=txtPermAddrsSCD.ClientID%>").style.borderColor = "";
             if (txtPermAddrsSCD == "") {
                 document.getElementById("<%=txtPermAddrsSCD.ClientID%>").style.borderColor = "Red";
                 document.getElementById('divMessageAreaCD').style.display = "block";
                 document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
                 document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                 ret = false;
                 document.getElementById("<%=txtPermAddrsSCD.ClientID%>").focus(); 
             }

             //ddlSpnsrSCD  HiddenStaffHR 

             if (hrStatus == "HR") {

                 var ddlSpnsrSCD = document.getElementById("<%=ddlSpnsrSCD.ClientID%>").value;
                 document.getElementById("<%=ddlSpnsrSCD.ClientID%>").style.borderColor = "";
                 if (document.getElementById("<%=RadioSponsor1.ClientID%>").checked == true) {
                     if (ddlSpnsrSCD == "--SELECT SPONSER--") {
                         document.getElementById("<%=ddlSpnsrSCD.ClientID%>").style.borderColor = "Red";
                         document.getElementById('divMessageAreaCD').style.display = "block";
                         document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
                         document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                         document.getElementById("<%=ddlSpnsrSCD.ClientID%>").focus(); 
                         ret = false;
                     }
                 }
                 var ddlRcrtdSCD = document.getElementById("<%=ddlRcrtdSCD.ClientID%>").value;
                 document.getElementById("<%=ddlRcrtdSCD.ClientID%>").style.borderColor = "";
                 if (ddlRcrtdSCD == "--SELECT REFERENCE--") {
                     document.getElementById("<%=ddlRcrtdSCD.ClientID%>").style.borderColor = "Red";
                         document.getElementById('divMessageAreaCD').style.display = "block";
                         document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
                         document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                     document.getElementById("<%=ddlRcrtdSCD.ClientID%>").focus(); 
                   
                     ret = false;
                 }

             }

             return ret;
         }
        </script>





        <%------------------------End Contact details --------------------------------------%>
        <%----------------------------Dependent info start-----------------------------------------%>


        <%------Start Dependent details --------%>
        <asp:HiddenField ID="HiddenCandidateId" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <%------End Dependent details --------%>
        <div id="divTblid3" style="float: left; width: 100%; background-color: #f3f3f3; border: 2px solid; border-color: #06558f; padding: 2%; display: none;">
            <div id="divMessageAreaDpnt" style="display: none; width: 84%; margin-left: 6%; margin-top: -12px;">
                <img id="imgMessageAreaDpnt" src="" />
                <asp:Label ID="lblMessageAreaDpnt" runat="server"></asp:Label>
            </div>


            <div id="divDepnt" style="width: 98%; border: 1px solid; border-color: darkgrey; padding: 1%; margin-top: 1%;">
                <div id="divDepntHead" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                    <asp:Label ID="lblDepntHead" runat="server">Add Dependent</asp:Label>
                </div>
                <br />
                <div class="eachform" style="float: left; margin-bottom: 0%;">
                    <h2>Name*</h2>

                    <asp:TextBox ID="txtDepndtNameFM" class="form1" runat="server" onchange="IncrmntConfrmCounterDep();" onkeypress="return isTag(event);" MaxLength="49" Width="50%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>

                </div>
                <div class="eachform" style="float: right;">
                    <h2>Relationship*</h2>

                    <asp:DropDownList ID="ddlReltnshpFM" Height="30px" Width="54%" onchange="IncrmntConfrmCounterDep();" onkeypress="return isTag(event);" class="form1" runat="server" Style="text-align: left;"></asp:DropDownList>

                </div>
                <div class="eachform" style="float: left;">
                    <h2>Occupation</h2>

                    <asp:TextBox ID="txtOccptnFM" class="form1" runat="server" onchange="IncrmntConfrmCounterDep();" onkeypress="return isTag(event);" MaxLength="100" Width="50%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>

                </div>

                <div class="eachform" style="float: right; margin-bottom: 1%">
                    <h2>Date Of Birth</h2>

                        <div id="div1" class="input-append date" style="float: left; margin-left: 17%; width: 64%;">

                        <div id="Div5" class="input-append date" style="font-family: Calibri; float: right; width: 87%; margin-right: -4%; margin-top: 0%;">
                            <asp:TextBox ID="txtAgeFM" onchange="IncrmntConfrmCounterImig();" onblur="return TextCurrentDate()" class="textDate form1" onkeypress="return IsEnter(event)" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width: 80%; height: 30px; font-family: calibri; float: left;margin-left: 0%;"></asp:TextBox>

                            <input type="image" id="Image3" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return TextCurrentDate()" style="height: 22px; float: left; margin-top: 0%; width: 18px; cursor: pointer;" />

                            <script type="text/javascript">
                                var $noC2 = jQuery.noConflict();
                                $noC2('#Div5').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    endDate: new Date(),


                                });
                                function TextCurrentDate()
                                {


                                    document.getElementById('divMessageAreaDpnt').style.display = "none";
                                    document.getElementById('imgMessageAreaDpnt').src = "";

                                    var dateCurrentDate = document.getElementById("<%=HiddenCurrentDatee.ClientID%>").value;
                                    var arrDateCurrentDate = dateCurrentDate.split("-");
                                    var CurrentDate = new Date(arrDateCurrentDate[2], arrDateCurrentDate[1] - 1, arrDateCurrentDate[0]);
         
                                    if (document.getElementById("<%=txtAgeFM.ClientID%>").value != "") {
                                        var datepickerDate1 = document.getElementById("<%=txtAgeFM.ClientID%>").value;
                                        var arrDatePickerDate1 = datepickerDate1.split("-");
                                        var dateTxIss1 = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);




                                        if (CurrentDate < dateTxIss1) {
                                            document.getElementById('imgMessageAreaDpnt').src = "/Images/Icons/imgMsgAreaWarning.png";
                                            document.getElementById("<%=lblMessageAreaDpnt.ClientID%>").innerHTML = "Sorry, date of birth should be less than  current date !";
                                            

                                            document.getElementById("<%=txtAgeFM.ClientID%>").focus();
                                            document.getElementById("<%=txtAgeFM.ClientID%>").value = "";
                                            document.getElementById('divMessageAreaDpnt').style.display = "";
                                            return false;

                                        }
                                        else {
                                            document.getElementById('divMessageArea').style.display = "none";
                                        }
                                    }
                                  
                                }

                            </script>

                        </div>


                    </div>

                   <%-- <asp:TextBox ID="txtAgeFM" class="form1" runat="server" onchange="IncrmntConfrmCounterDep();" onkeypress="return isTag(event);" MaxLength="3" Width="50.5%" Height="30px" onblur="NumCheckingForAge('cphMain_txtAgeFM')" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>--%>


                </div>
                <div style="margin-top: 5%; float: left; margin-left: 32%;">
                    <asp:Button ID="btnUpdateDepnt" runat="server" class="save" Style="display: none;" Text="Update" OnClick="btnUpdateDepnt_Click" OnClientClick="return ValidateDepnt('adddep');" />
                    <asp:Button ID="btnAddDepnt" runat="server" class="save" Text="Save" OnClick="btnAddDepnt_Click" OnClientClick="return ValidateDepnt('adddep');" />
                    <asp:Button ID="btnClearDepnt" runat="server" Style="margin-left: 11px;" OnClientClick="return AlertDepClear('Dependent');" class="cancel" Text="Clear" />
                    <asp:Button ID="BtnCancelDept" runat="server" Style="margin-left: 23px;" OnClientClick="return ConfirmCnclDepn();" class="cancel" Text="Cancel" />
                </div>
                <%--emp-0021--%>
                <%--<asp:Button ID="btnDepndncySave" runat="server" class="save" Text="SaveDependency" OnClick="btnAddDepnt_Click" style="margin-left:51%;margin-top:10%;"  />--%>
                <%--emp-0021--%>
                <div class="eachform" style="float: left; width: 100%">
                    <h2 style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; margin-top: 1%;">List Dependents</h2>
                </div>

                <div id="divReportforDependent" class="table-responsive" style="width: 100%; font-family: Calibri" runat="server">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </div>
            </div>
            <%--
            <div id="div8" style="width: 98%; border: 1px solid; border-color: darkgrey; padding: 1%; margin-top: 1%;">

                <div id="div10" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                    <asp:Label ID="Label2" runat="server">Add Guardian</asp:Label>
                </div>

                <div class="eachform" style="float: left; width: 49%;">
                    <h2>Relation</h2>


                    <div id="div15" class="subform" style="margin-left: 33%;">
                        <asp:RadioButton ID="RbFatherDP" onkeypress="return isTag(event);" Style="float: left;" Text="Father" runat="server" Checked="True" onchange="IncrmntConfrmCounterDep();" GroupName="RadioHusfathernone" />
                        <asp:RadioButton ID="RbHusbandDP" onkeypress="return isTag(event);" Style="float: left;" Text="Husband" runat="server" onchange="IncrmntConfrmCounterDep();" GroupName="RadioHusfathernone" />
                        <asp:RadioButton ID="RbNoneDP" onkeypress="return isTag(event);" Style="float: left;" Text="None" runat="server" onchange="IncrmntConfrmCounterDep();" GroupName="RadioHusfathernone" />
                    </div>

                </div>

                 <div class="eachform" style="float: right; width: 49%; margin-right: -1%;">
                    <h2>Marital Status</h2>


                    <div id="div14" class="subform" style="margin-left: 26%;">
                         <asp:RadioButton  ID ="RbMaritalStatusDP1" style="float:left;"   onchange="IncrmntConfrmCounterDep();"  Text="Married"  runat="server"  GroupName ="RadioMrtlSts" /> 
                   <asp:RadioButton  ID ="RbMaritalStatusDP2" style="float:left;" onchange="IncrmntConfrmCounterDep();"  Text="Unmarried" runat="server"  GroupName ="RadioMrtlSts"/> 
                       
                        <asp:RadioButtonList ID="rblMarrStatus" RepeatDirection="Horizontal"  onchange="ShowHidespouse();"  onkeypress="return isTag(event);" runat="server">
                            <asp:ListItem Text="Married" Selected="True" Value="1" />
                            <asp:ListItem Text="Single" Value="0" />
                        </asp:RadioButtonList>
                    </div>
                    <script>
                        function ShowHidespouse() {
                            // IncrmntConfrmCounterDep();

                            // var a = document.getElementById("<%=rblMarrStatus.ClientID%>").SelectedItem;
                            // alert(a);
                            if (document.getElementById('cphMain_rblMarrStatus_0').checked) {
                                //document.getElementById("<%=txtSpouseNameDP.ClientID%>").disabled = false;
                                document.getElementById("<%=divSpouse.ClientID%>").style.display = "";
                            }
                            else {
                                //document.getElementById("<%=txtSpouseNameDP.ClientID%>").disabled = true;
                                document.getElementById('cphMain_rblMarrStatus_0').checked = false;
                                //document.getElementById("<%=txtSpouseNameDP.ClientID%>").value = "";
                                document.getElementById("<%=divSpouse.ClientID%>").style.display = "none";
                                document.getElementById("<%=txtSpouseNameDP.ClientID%>").value = "";
                            }
                        }

                    </script>
                </div>





                <div class="eachform" style="float: left;">
                    <h2>Guardian name</h2>
                    <asp:TextBox ID="txtHusbandNameDP" class="form1" runat="server" onkeypress="return isTag(event);" onchange="IncrmntConfrmCounterDep();" MaxLength="49" Width="50%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>

                </div>

                 <div class="eachform" style="float: right;">
                    <h2>Occupation</h2>

                    <asp:TextBox ID="txtOccuDP" class="form1" runat="server" onkeypress="return isTag(event);" onchange="IncrmntConfrmCounterDep();" onblur="return RemoveTagandSpace('cphMain_txtOccuDP')" MaxLength="100" Width="50%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>

                </div>

                <div id="divSpouse" runat="server" class="eachform" style="float: left;">
                    <h2>Spouse Name</h2>

                    <asp:TextBox ID="txtSpouseNameDP" class="form1" runat="server" onkeypress="return isTag(event);" onchange="IncrmntConfrmCounterDep();" onblur="return RemoveTagandSpace('cphMain_txtSpouseNameDP')" MaxLength="100" Width="50%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>

                </div>

                <div class="eachform" style="margin-top: 2%; margin-left: 19%;">
                    <div class="subform" style="width: 448px;">
                        <div class="form-group">

                            <asp:Button ID="btnUpdateDepntfamily" runat="server" Style="" class="save" Text="Update" OnClick="btnUpdateFamily_Click" OnClientClick="return ValidateDepnt();" />
                            <asp:Button ID="btnAddDepntfamily" runat="server" class="save" Text="Save" OnClick="btnFamilySave_Click" OnClientClick="return ValidateDepnt();" />
                            <asp:Button ID="btnClearDepntFamily" runat="server" Style="margin-left: 11px;" OnClientClick="return AlertDepClear();" class="cancel" Text="Clear" />
                            <asp:Button ID="btncancldepndtfamily" runat="server" Style="margin-left: 23px;" OnClientClick="return ConfirmCnclDepn();" class="cancel" Text="Cancel" />

                        </div>
                    </div>

                </div>


            </div>
            --%>
        </div>
        <script>
            function RemoveTagandSpace(obj) {
                var txt = document.getElementById(obj).value.trim();
                var replaceText1 = txt.replace(/</g, "");
                var replaceText2 = replaceText1.replace(/>/g, "");
                document.getElementById(obj).value = replaceText2;

            }
            var confirmboxDep = 0;
            function IncrmntConfrmCounterDep() {
                confirmboxDep++;

            }
            function ConfirmCnclDepn() {

                if (confirmboxDep > 0) {
                    if (confirm("Are you sure you want to cancel this page?")) {
                        window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                }
                else {

                    window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                    return false;
                }
            }
            function AlertDepClear(mode) {

                if (confirmboxDep > 0) {
                    if (confirm("Are you sure you want clear all data in this page?")) {
                        confirmboxDep = 0;
                        if (mode == "Dependent") {
                            document.getElementById("<%=txtDepndtNameFM.ClientID%>").value = "";



                                document.getElementById("<%=ddlReltnshpFM.ClientID%>").selectedIndex = "--Select Relationship--";
                                document.getElementById("<%=txtOccptnFM.ClientID%>").value = "";
                            document.getElementById("<%=txtAgeFM.ClientID%>").value = "";
                            document.getElementById("<%=txtDepndtNameFM.ClientID%>").focus();
                        }
                            <%--
                            else {
                           
                                document.getElementById("<%=txtHusbandNameDP.ClientID%>").value = "";
                                document.getElementById("<%=txtOccuDP.ClientID%>").value = "";
                            document.getElementById("<%=txtSpouseNameDP.ClientID%>").value = "";
                            document.getElementById("<%=RbFatherDP.ClientID%>").focus();

                            }--%>


                            //tableClick('divTblid1', Tblid1);
                            return false;
                        }
                        else {
                            return false;
                        }
                    }
                    else {
                        if (mode == "Dependent") {
                            document.getElementById("<%=txtDepndtNameFM.ClientID%>").value = "";

                            document.getElementById("<%=ddlReltnshpFM.ClientID%>").selectedIndex = "--Select Relationship--";
                            document.getElementById("<%=txtOccptnFM.ClientID%>").value = "";
                            document.getElementById("<%=txtAgeFM.ClientID%>").value = "";
                            document.getElementById("<%=txtDepndtNameFM.ClientID%>").focus();

                        }
<%--
                        else {

                            document.getElementById("<%=txtHusbandNameDP.ClientID%>").value = "";
                            document.getElementById("<%=txtOccuDP.ClientID%>").value = "";
                            document.getElementById("<%=txtSpouseNameDP.ClientID%>").value = "";
                            document.getElementById("<%=RbFatherDP.ClientID%>").focus();
                        }--%>
                        //tableClick('divTblid1', Tblid1);
                        //tableClick('divTblid1', Tblid1);
                        return false;
                    }
                }
                function ValidateDepnt(btnDpCheck) {
                    var ret = true;
                    document.getElementById("<%=txtDepndtNameFM.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=ddlReltnshpFM.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtOccptnFM.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtAgeFM.ClientID%>").style.borderColor = "";
                    document.getElementById('divMessageAreaDpnt').style.display = "none";
                    document.getElementById('imgMessageAreaDpnt').src = "";
                    // replacing < and > tags
                    var NameWithoutReplace = document.getElementById("<%=txtDepndtNameFM.ClientID%>").value;
                    var replaceText1 = NameWithoutReplace.replace(/</g, "");
                    var replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("<%=txtDepndtNameFM.ClientID%>").value = replaceText2;

                    NameWithoutReplace = document.getElementById("<%=txtOccptnFM.ClientID%>").value;
                    replaceText1 = NameWithoutReplace.replace(/</g, "");
                    replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("<%=txtOccptnFM.ClientID%>").value = replaceText2;

                    NameWithoutReplace = document.getElementById("<%=txtAgeFM.ClientID%>").value;
                    replaceText1 = NameWithoutReplace.replace(/</g, "");
                    replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("<%=txtAgeFM.ClientID%>").value = replaceText2;

                   <%-- NameWithoutReplace = document.getElementById("<%=txtHusbandNameDP.ClientID%>").value;
                    replaceText1 = NameWithoutReplace.replace(/</g, "");
                    replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("<%=txtHusbandNameDP.ClientID%>").value = replaceText2;--%>

                    if (btnDpCheck == "adddep") {
                        var name = document.getElementById("<%=txtDepndtNameFM.ClientID%>").value.trim();
                        var relationship = document.getElementById("<%=ddlReltnshpFM.ClientID%>").value;

                        if (relationship == "--Select Relationship--") {
                            document.getElementById('divMessageAreaDpnt').style.display = "";
                            document.getElementById('imgMessageAreaDpnt').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageAreaDpnt.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            document.getElementById("<%=ddlReltnshpFM.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=ddlReltnshpFM.ClientID%>").focus();
                            ret = false;
                        }

                        if (name == "") {
                            document.getElementById('divMessageAreaDpnt').style.display = "";
                            document.getElementById('imgMessageAreaDpnt').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageAreaDpnt.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            document.getElementById("<%=txtDepndtNameFM.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtDepndtNameFM.ClientID%>").focus();
                            ret = false;
                        }


                    } 
                     return ret;
                }

        </script>
        <script>

            function updateDepntById(Id) {
                document.getElementById("<%=txtDepndtNameFM.ClientID%>").style.borderColor = "";
                document.getElementById("<%=ddlReltnshpFM.ClientID%>").style.borderColor = "";
               
          
                document.getElementById("<%=HiddenDepntId.ClientID%>").value = Id;

                  var Details = PageMethods.ReadDepntDtlById(Id, function (response) {

                      document.getElementById("<%=txtDepndtNameFM.ClientID%>").value = response.Name;
                      document.getElementById("<%=txtOccptnFM.ClientID%>").value = response.occupation;
                      document.getElementById("<%=txtAgeFM.ClientID%>").value = response.age;

                      if (response.reltnshpStsId == "1") {
                          document.getElementById("<%=ddlReltnshpFM.ClientID%>").value = response.reltnshpId;
                      }
                      else if (response.reltnshpStsId == "0") {
                          var $Mo = jQuery.noConflict();
                          var newOption = "<option value='" + response.reltnshpId + "'>" + response.reltnshpName + "</option>";

                          $Mo('#<%=ddlReltnshpFM.ClientID%>').append(newOption);
                          //SORTING DDL
                          var options = $Mo("#<%=ddlReltnshpFM.ClientID%> option");                    // Collect options         
                          options.detach().sort(function (a, b) {               // Detach from select, then Sort
                              var at = $Mo(a).text();
                              var bt = $Mo(b).text();
                              return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                          });
                          options.appendTo('#<%=ddlReltnshpFM.ClientID%>');
                    document.getElementById("<%=ddlReltnshpFM.ClientID%>").value = response.reltnshpId;

                      }
                      document.getElementById("cphMain_btnAddDepnt").style.display = "none";
                      document.getElementById("cphMain_btnClearDepnt").style.display = "none";
                      document.getElementById("cphMain_btnUpdateDepnt").style.display = "block";
                      document.getElementById("cphMain_lblDepntHead").innerText = "Edit Dependent";
                      document.getElementById("<%=txtDepndtNameFM.ClientID%>").focus();

                  });
              return false;
          }

          function deleteDepntById(Id) {
              var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
        var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
        document.getElementById("<%=HiddenDepntId.ClientID%>").value = Id;
        var empId = document.getElementById("<%=HiddenCandidateId.ClientID%>").value

        if (confirm("Do you want to cancel this Entry?")) {
            var Details = PageMethods.deleteDepntDtlById(Id, empId, OrgId, CorpId, function (response) {

      


                document.getElementById("<%=divReportforDependent.ClientID%>").innerHTML = response.strDepntLIst;
                SuccessDeletionDepnt();
                $p('#ReportTableDep').DataTable({
                    "pagingType": "full_numbers",
                    //"bSort": true,


                });

            });


        }
        else {

        }


    }
        </script>
        <%-----------------------------------------end Dependent info-----------------------------------------%>


        <%----------------------------Immigrationinfo start-----------------------------------------%>
        <asp:HiddenField ID="HiddenOrgId" runat="server" />
        <asp:HiddenField ID="Hiddenempid" runat="server" />
        <asp:HiddenField ID="hiddenuserid" runat="server" />
          <asp:HiddenField ID="HiddenCurrentDatee" runat="server" />
        
        <asp:HiddenField ID="HiddenMAsteridImig" runat="server" />
        <script src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
        <script src="/JavaScript/Date/bootstrap-datepicker.js"></script>
        <script src="/JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
        <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
        <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
        <script type="text/javascript">
            var $noC2 = jQuery.noConflict();
            $noC2('#DivExpre').datetimepicker({
                format: 'dd-MM-yyyy',
                language: 'en',
                pickTime: false,
                //startDate: new Date(),


            });

        </script>

        <script>

            function EditImigrationByid(x, empid) {
                //document.getElementById('cphMain_Ddlvisatype').focus();
                document.getElementById("<%=Ddlvisatype.ClientID%>").focus();

                document.getElementById("<%=HiddenMAsteridImig.ClientID%>").value = empid;

            document.getElementById("<%=Hiddenempid.ClientID%>").value = empid;
            var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
            var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;

            //      document.getElementById('divMessageAreaforimig').style.display = "none";

            var Details = PageMethods.ReadImigrationByid(x, CorpId, OrgId, empid, function (response) {
                document.getElementById("<%=btnUpdateStaffImigrationDtls.ClientID%>").style.display = "block";
                document.getElementById("<%=btnAddStaffImigrationDtls.ClientID%>").style.display = "none";
                document.getElementById("<%=BtnclrImig.ClientID%>").style.display = "none";

                // document.getElementById("cphMain_Ddlvisatype").style.display = "";
                //   alert(response.visatype);
                document.getElementById("<%=Ddlvisatype.ClientID%>").value = response.visatype;

                document.getElementById("<%=TextVisa.ClientID%>").value = response.VISANUMBER;

                document.getElementById("<%=txtVisaExpDate.ClientID%>").value = response.VISAEXPIRY;
                document.getElementById("<%=txtPassExpDate.ClientID%>").value = response.PassEXPIRY;

                document.getElementById("<%=TextPass.ClientID%>").value = response.PASSNUMBER;


           

                document.getElementById("<%=btnUpdateStaffImigrationDtls.ClientID%>").style.display = "block";

            
                document.getElementById("<%=btnAddStaffImigrationDtls.ClientID%>").style.display = "none";
                $a(Window).scrollTop(0);
            });

            // hide_clearbutton();

            return false;
        }
        function DeleteImigrationByid(x, emp_Id) {
            // alert(emp_Id);
            // alert(x);
            var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
                    var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                    if (confirm("Do you want To cancel this  entry?")) {

                        var userid = document.getElementById("<%=hiddenuserid.ClientID%>").value;
                        //   alert(userid.value);
                        // alert(x + " " + CorpId + " " + OrgId + " " + userid + " " + emp_Id);
                        PageMethods.DeleteImigrationByid(x, CorpId, OrgId, userid, emp_Id, function (response) {

                            document.getElementById("<%=divImigList.ClientID%>").innerHTML = response.strhtml; //2emp17
                             ImigSuccessCancelation();//2emp17
                             $p('#ReportTableImgrtn').DataTable({
                                 "pagingType": "full_numbers",
                                 "bSort": true

                             });
                         });

                         }
        }
            function ChkCurrntDate()
            {
                if (document.getElementById("<%=txtPassExpDate.ClientID%>").value != "") {
                    var datepickerDate1 = document.getElementById("<%=txtPassExpDate.ClientID%>").value;
                      var arrDatePickerDate1 = datepickerDate1.split("-");
                      var dateTxIss1 = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);


                      var dateCurrentDate = document.getElementById("<%=HiddenCurrentDatee.ClientID%>").value;
                 var arrDateCurrentDate = dateCurrentDate.split("-");
                 var CurrentDate = new Date(arrDateCurrentDate[2], arrDateCurrentDate[1] - 1, arrDateCurrentDate[0]);
                
                 if (CurrentDate > dateTxIss1) {
                     alert("Sorry, passport expiry date should be greater than or equal to current date !");
                     document.getElementById("<%=txtPassExpDate.ClientID%>").value = "";
                  }
              }

            }
            function TextDateChangeVisa() {
                if (document.getElementById("<%=txtVisaExpDate.ClientID%>").value != "") {
                       var datepickerDate1 = document.getElementById("<%=txtVisaExpDate.ClientID%>").value;
                    var arrDatePickerDate1 = datepickerDate1.split("-");
                    var dateTxIss1 = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);


                    var dateCurrentDate = document.getElementById("<%=HiddenCurrentDatee.ClientID%>").value;
                      var arrDateCurrentDate = dateCurrentDate.split("-");
                      var CurrentDate = new Date(arrDateCurrentDate[2], arrDateCurrentDate[1] - 1, arrDateCurrentDate[0]);

                      if (CurrentDate > dateTxIss1) {
                          alert("Sorry, visa expiry date should be greater than or equal to current date !");
                          document.getElementById("<%=txtVisaExpDate.ClientID%>").value = "";
                 }
             }

         }
            
         
        </script>

        <div id="divTblid4" style="float: left; background-color: #f3f3f3; width: 100%; border: 2px solid; border-color: #06558f; padding: 2%; display: none">

            <div id="divImgratn" style="width: 98%; border: 1px solid; border-color: darkgrey; padding: 1%; margin-bottom: 1%; font-family: Calibri">
                <div id="div3" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                    <div id="divMessageAreaforimig" style="display: none; width: 84%; margin-left: 8%;">
                        <img id="imgMessageAreaforimig" style="float: left" src="" />
                        <asp:Label ID="lblMessageAreaforimig" runat="server"></asp:Label>
                       
                    </div>
                    <%--  <asp:HiddenField ID="HiddenCurrentDate" runat="server" />--%>

                    <asp:Label ID="LabelImmighead" runat="server">Add Immigration</asp:Label>
                </div>
                <br />

                <div id="Divvisatype" class="eachform" style="float: left; width: 49%;">
                    <h2>Visa Type*</h2>

                    <asp:DropDownList ID="Ddlvisatype" onchange="IncrmntConfrmCounterImig();" Height="30px" Width="47%" class="form1" runat="server" Style="margin-left: 28.5%; float: left; text-align: left;"></asp:DropDownList>
                </div>


                <div class="eachform" style="float: right; width: 49%">
                    <h2>Visa Number</h2>

                    <asp:TextBox ID="TextVisa" class="form1" onchange="IncrmntConfrmCounterImig();" runat="server" onkeypress="return isTag(event);" MaxLength="49" Width="49.7%" Height="30px" Style="height: 30px; width: 49.3%; float: right; resize: none; text-transform: uppercase; font-family: calibri; margin-right: 4%;"></asp:TextBox>
                    <%--3emp17--%>

                    <p class="error" id="ErrorMsgMob1" style="display: none">Please enter Valid data</p>
                </div>



                <div class="eachform" style="float: left; width: 49%; margin-bottom: 0%;">
                    <h2>Visa Expiry Date</h2>

                    <div id="divEligiblervwdate" class="input-append date" style="float: left; margin-left: 13%; width: 57%">

                        <div id="Div2" class="input-append date" style="font-family: Calibri; float: right; width: 83%; margin-right: 3%; margin-top: 1%;">
                            <asp:TextBox ID="txtVisaExpDate" onchange="IncrmntConfrmCounterImig();" onblur="return TextDateChangeVisa()" class="textDate form1" onkeypress="return IsEnter(event)" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width: 80%; height: 27px; font-family: calibri; float: left;"></asp:TextBox>
                        <%-- evm-0023 onclick="IncrmntConfrmCounterImig()"--%>
                            <input type="image" id="img2" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounterImig()" onblur="return TextDateChangeVisa()" style="height: 19px; float: left; margin-top: 0%; width: 18px; cursor: pointer;" />

                            <script type="text/javascript">
                                var $noC2 = jQuery.noConflict();
                                $noC2('#Div2').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    startDate: new Date(),


                                });

                            </script>

                        </div>


                    </div>
                </div>

                <div class="eachform" style="float: right; width: 49%">
                    <h2>Passport Number</h2>

                    <asp:TextBox ID="TextPass" class="form1" onchange="IncrmntConfrmCounterImig();" runat="server" onkeypress="return isTag(event);" MaxLength="49" Width="49.7%" Height="30px" Style="height: 30px; width: 49.3%; float: right; resize: none; text-transform: uppercase; font-family: calibri; margin-right: 4%;"></asp:TextBox>
                    <%--3emp17--%>

                    <p class="error" id="P3" style="display: none">Please enter Valid data</p>
                </div>
                <div class="eachform" style="float: left; width: 48%">
                    <h2>Passport Expiry Date</h2>

                    <div id="Div4" class="input-append date" style="font-family: Calibri; float: right; width: 56%; margin-top: 1%;">
                        <asp:TextBox ID="txtPassExpDate" class="textDate form1" onchange="IncrmntConfrmCounterImig();"  onblur="return ChkCurrntDate()"  onkeypress="return IsEnter(event)" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width: 68.8%; height: 27px; font-family: calibri; float: left;"></asp:TextBox>

                        <%--evm-0023  onclick="IncrmntConfrmCounterImig();" --%>
                        <input type="image" id="Image1" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounterImig();" onblur="return ChkCurrntDate()" style="margin-top: 0%; height: 19px; float: left; width: 18px; cursor: pointer;" />

                        <script type="text/javascript">
                            var $noC2 = jQuery.noConflict();
                            var year = (new Date).getFullYear();
                            year = year + 2;
                            $noC2('#Div4').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //startDate: new Date(),
                                endDate: new Date(year, '0', '0'),
                                startDate: new Date(),

                            });

                        </script>

                    </div>


                </div>








                <div class="eachform" style="margin-top: 7%; float: left; width: 50%; height: 33px;">
                    <div class="subform" style="width: 448px; float: left">
                        <div class="form-group">

                            <asp:Button ID="btnUpdateStaffImigrationDtls" runat="server" class="save" Text="Update" Style="display: none" OnClientClick="return Validateimmigration(); " OnClick="btnUpdateStaffImigrationDtls_Click" />
                            <asp:Button ID="btnAddStaffImigrationDtls" runat="server" class="save" Text="Save" OnClick="btnAddStaffImigrationDtls_Click" OnClientClick="return Validateimmigration(); " />
                            <asp:Button ID="BtnclrImig" runat="server" Style="margin-left: 11px;" OnClientClick="return AlertClearAllImmig();" class="cancel" Text="Clear" />
                            <asp:HiddenField ID="hiddenvisa" runat="server" />
                            <asp:Button ID="btncancelImigrtn" runat="server" Style="margin-left: 11px;" OnClientClick="return ConfirmCnclimig();" class="cancel" Text="Cancel" />
                        </div>
                    </div>

                </div>
                <script>

                    function DisableIllness(ill) {
                        if (ill == "illness1") {
                            document.getElementById("<%=TextIllDtls.ClientID%>").disabled = false;
             }
             else if (ill == "illness2") {
                 document.getElementById("<%=TextIllDtls.ClientID%>").disabled = true;
             }
     }
     function DisableApllied(app) {
         if (app == "Applied1") {
             document.getElementById("<%=TextApliedBfrDtls.ClientID%>").disabled = false;
             }
             else if (app == "Applied2") {
                 document.getElementById("<%=TextApliedBfrDtls.ClientID%>").disabled = true;
             }

     }
     function DisableSponsor(spo) {
         if (spo == "Sponsor1") {
             document.getElementById("<%=ddlSpnsrSCD.ClientID%>").disabled = false;
             }
             else if (spo == "Sponsor2") {
                 document.getElementById("<%=ddlSpnsrSCD.ClientID%>").disabled = true;
             }
     }

     function Validateimmigration() {

         var ret = true;


         var NameWithoutReplace = document.getElementById("<%=TextVisa.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=TextVisa.ClientID%>").value = replaceText2;

             NameWithoutReplace = document.getElementById("<%=TextPass.ClientID%>").value;
             replaceText1 = NameWithoutReplace.replace(/</g, "");
             replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=TextPass.ClientID%>").value = replaceText2;

             NameWithoutReplace = document.getElementById("<%=txtVisaExpDate.ClientID%>").value;
             replaceText1 = NameWithoutReplace.replace(/</g, "");
             replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtVisaExpDate.ClientID%>").value = replaceText2;
             var NameWithoutReplace = document.getElementById("<%=txtPassExpDate.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtPassExpDate.ClientID%>").value = replaceText2;

             document.getElementById('divMessageAreaforimig').style.display = "none";
             document.getElementById('imgMessageAreaforimig').src = "";



             document.getElementById("<%=Ddlvisatype.ClientID%>").style.borderColor = "";


             var visa = document.getElementById("<%=Ddlvisatype.ClientID%>").value;





             var expry = document.getElementById("<%=txtVisaExpDate.ClientID%>").value;
             var arrDatePickerDate = expry.split("-");
             var dateexpiry = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);


             var issudate = document.getElementById("<%=txtPassExpDate.ClientID%>").value;
             var arrDatePickerDate1 = issudate.split("-");
             var dateissued = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

             var cdate = new Date();







             if (visa == "--Select Visa Type--") {

                 document.getElementById('divMessageAreaforimig').style.display = "";
                 document.getElementById('imgMessageAreaforimig').src = "/Images/Icons/imgMsgAreaWarning.png";
                 document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                 var OrgMobileFocus = document.getElementById("<%=Ddlvisatype.ClientID%>").focus();
                 document.getElementById("<%=Ddlvisatype.ClientID%>").style.borderColor = "red";
                 ret = false;
             }









             return ret;
         }
         //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
         function DisableEnter(evt) {

             evt = (evt) ? evt : window.event;
             var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
             if (keyCodes == 13) {
                 return false;
             }
         }

                </script>
                <div class="eachform" style="float: left; width: 100%">
                    <h2 style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; margin-top: 1%;">List Immigration</h2>
                </div>
                <div id="divImigList" class="table-responsive" runat="server">

                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </div>







            </div>


        </div>

        <%-------------    ----------------------------end Immigration info-----------------------------------------%>


        <%-------------    ----------------------------Start Other info-----------------------------------------%>

        <div id="divTblid1" style="float: left; background-color: #f3f3f3; width: 100%; border: 2px solid; border-color: #06558f; padding: 2%; display: none;">
            <div id="divMessageAreaPD" style="display: none; width: 84%; margin-left: 6%; margin-top: -12px;">
                <img id="imgMessageAreaPD" src="" />
                <asp:Label ID="lblMessageAreaPD" runat="server"></asp:Label>
                     <asp:HiddenField ID="hiddenOtherUpdChk" runat="server" />
                  <asp:HiddenField ID="HiddenfileuploadChk" runat="server" />
            </div>


            <div id="divcaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="LblEntryother" runat="server">Add Other Details</asp:Label>
            </div>
            <br />
            <div style="width: 48%; float: left">
                <div style="float: left; background-color: rgb(243, 243, 243); width: 99%; border: 1px solid #428734; padding: 2%; display: block;">
                    <h2 style="width: 46%;">Reference 1</h2>
                    <div class="eachform" style="float: left; width: 99%">
                        <h2 style="width: 46%;">Name*</h2>
                        <asp:TextBox ID="TextName1" class="form1" runat="server" onchange="return IncrmntConfrmCounterOther();" MaxLength="49" Width="50%" Height="30px" onkeypress="return isTag(event);" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                    </div>
                    <div class="eachform" style="float: left; width: 99%">
                        <h2>Address* </h2>
                        <asp:TextBox ID="TextAddr1" class="form1" runat="server" onchange="return IncrmntConfrmCounterOther();" MaxLength="499" Width="50%" Height="30px" onkeypress="return isTag(event);" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                    </div>


                    <div class="eachform" style="float: left; width: 99%">
                        <h2>Occupation*</h2>
                        <asp:TextBox ID="TextOccp1" class="form1" runat="server" onchange="return IncrmntConfrmCounterOther();" MaxLength="100" Width="50%" Height="30px" onkeypress="return isTag(event);" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                    </div>

                    <div class="eachform" style="float: left; width: 99%">
                        <h2>Phone Number   *</h2>
                        <asp:TextBox ID="TextPhn1" class="form1" runat="server" onchange="return IncrmntConfrmCounterOther();" MaxLength="19" Width="50%" Height="30px" onkeydown="return isNumber(event);" onblur="return BlurNotNumber('cphMain_TextPhn1');" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                        <p class="error" id="ErrorMsgMob" style="display: none">Please enter valid mobile number</p>

                    </div>
                </div>
            </div>




            <div style="width: 48%; float: right">
                <div style="float: right; background-color: rgb(243, 243, 243); width: 99%; border: 1px solid #428734; padding: 2%; display: block;">
                    <h2 style="width: 46%;">Reference 2</h2>
                    <div class="eachform" style="float: left; width: 99%">
                        <h2 style="width: 46%;">Name</h2>
                        <asp:TextBox ID="TextName2" class="form1" onchange="return IncrmntConfrmCounterOther();" runat="server" MaxLength="49" Width="50%" Height="30px" onkeypress="return isTag(event);" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                    </div>
                    <div class="eachform" style="float: left; width: 99%">
                        <h2>Address </h2>
                        <asp:TextBox ID="TextAddr2" class="form1" onchange="return IncrmntConfrmCounterOther();" runat="server" MaxLength="500" Width="50%" Height="30px" onkeypress="return isTag(event);" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                    </div>


                    <div class="eachform" style="float: left; width: 99%">
                        <h2>Occupation</h2>
                        <asp:TextBox ID="TextOccp2" class="form1" onchange="return IncrmntConfrmCounterOther();" runat="server" MaxLength="100" Width="50%" Height="30px" onkeypress="return isTag(event);" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                    </div>

                    <div class="eachform" style="float: left; width: 99%">
                        <h2>Phone Number</h2>
                        <asp:TextBox ID="TextPhn2" class="form1" onchange="return IncrmntConfrmCounterOther();" runat="server" MaxLength="19" Width="50%" Height="30px" onkeydown="return isNumber(event)" onblur="return BlurNotNumber('cphMain_TextPhn2');" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                        <p class="error" id="ErrorMsgMob11" style="display: none">Please enter valid mobile number</p>
                    </div>
                </div>



            </div>


                <div class="eachform" style="height: 30px; width: 51%; text-align: left; float: left;">
                    <h2>Blood Group*</h2>

                    <asp:DropDownList ID="ddlBldGrp" Height="30px" Width="50%" onchange="return IncrmntConfrmCounterOther();" class="form1" runat="server" Style="height: 30px; width: 50%; text-align: left; margin-left: 145px; float: left;"></asp:DropDownList>

                </div>
                <div class="eachform" style="float: right;">
                    <h2 style="">Join Date*</h2>

                    <div id="DivJoiningDate" class="input-append date">



                        <asp:TextBox ID="txtJoinDate" class="form1" onkeypress="return isTag(event);" onchange="return IncrmntConfrmCounterOther();" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="margin-top: 0%; float: left; margin-left: 31.7%;"></asp:TextBox>

                        <input type="image" runat="server" id="Image2" class="add-on" src="/Images/Icons/CalandarIcon.png" style="height: 22px; width: 22px; margin-top: 0%;" />


                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#DivJoiningDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                    </div>

                </div>


            <div class="eachform" style="float: left;width: 51%;">
                <h2>Occupation Of Spouse</h2>
                <asp:TextBox ID="TextSpOcu" class="form1" runat="server" onchange="return IncrmntConfrmCounterOther();" MaxLength="49" Width="47%" Height="30px" onkeypress="return isTag(event);" Style="resize: none; text-transform: uppercase; font-family: calibri; margin-left: 16.2%; float: left;"></asp:TextBox>



            </div>
            <div class="eachform" style="float: right;">
                <h2>Date Of Birth</h2>

                <div id="divDOB" class="input-append date" style="float: right; width: 74%;">




                    <asp:TextBox ID="TxtDOB" class="form1" onkeypress="return isTag(event);" onchange="return IncrmntConfrmCounterOther();" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="58%" Style="margin-top: 0%; float: left; margin-left: 27%;"></asp:TextBox>
                    <%--//emp17--%>


                    <input type="image" runat="server" id="Image18" class="add-on" src="/Images/Icons/CalandarIcon.png" style="height: 22px; width: 22px; margin-top: 0%;" />


                    <script type="text/javascript">
                        var $noC = jQuery.noConflict();
                        $noC('#divDOB').datetimepicker({
                            format: 'dd-MM-yyyy',
                            language: 'en',
                            pickTime: false,
                            endDate: new Date(),
                        });

                    </script>




                    <p style="visibility: hidden">Please enter</p>
                </div>

            </div>

            <div class="eachform" style="float: left; width: 100%;">
                <div style="float: left; width: 50%">
                    <%--<asp:CheckBox ID="CheckBoxIllSts" Text="" runat="server" onchange="return IncrmntConfrmCounterOther();" onkeypress="return isTag(event);" onClick="refVerClick();" style="float: right;" class="form2" />--%>
                    <h2 style="font-size: 18px; width: 44%;">Have you suffered from any major illness? </h2>

                    <asp:RadioButton ID="RBillness1" onclick="DisableIllness('illness1')" onkeydown="return DisableEnter(event);" Style="float: left; font-family: Calibri; color: #697259;" Text="Yes" onchange="return IncrmntConfrmCounterOther();" runat="server" GroupName="Radioillness" />
                    <asp:RadioButton ID="RBillness2" onclick="DisableIllness('illness2')" onkeydown="return DisableEnter(event);" Style="float: left; font-family: Calibri; color: #697259;" Text="No" onchange="return IncrmntConfrmCounterOther();" runat="server" GroupName="Radioillness" />
                </div>
                <div class="eachform" style="float: right; width: 48%">
                    <h2>If Yes, please give details</h2>
                    <asp:TextBox ID="TextIllDtls" class="form1" onkeydown="textCounter(cphMain_TextIllDtls,450)" onkeyup="textCounter(cphMain_TextIllDtls,450)" onchange="return IncrmntConfrmCounterOther();" onkeypress="return isTagWithEnter(event)" onblur="textCounter(cphMain_TextIllDtls, 450);" TextMode="MultiLine" runat="server" MaxLength="499" Width="50%" Height="100px" Style="resize: none; text-transform: uppercase; font-family: calibri;margin-right: 3%;"></asp:TextBox>

                </div>



            </div>


            <div class="eachform" style="float: left; width: 100%;">
                <div style="float: left; width: 50%">
                    <%--<asp:CheckBox ID="CheckBoxIllSts" Text="" runat="server" onchange="return IncrmntConfrmCounterOther();" onkeypress="return isTag(event);" onClick="refVerClick();" style="float: right;" class="form2" />--%>
                    <h2 style="font-size: 18px; width: 44%;">Have you applied for an employment with AL BALAGH earlier? </h2>

                    <asp:RadioButton ID="RadioAppliedYes" onclick="DisableApllied('Applied1')" onkeydown="return DisableEnter(event);"  Style="float: left; font-family: Calibri; color: #697259;" Text="Yes" onchange="return IncrmntConfrmCounterOther();" runat="server" GroupName="RadioApplied" />
                    <asp:RadioButton ID="RadioAppliedNo" onclick="DisableApllied('Applied2')"  onkeydown="return DisableEnter(event);" Style="float: left; font-family: Calibri; color: #697259;" Text="No" onchange="return IncrmntConfrmCounterOther();" runat="server" GroupName="RadioApplied" />
                </div>
                <div class="eachform" style="float: right; width: 48%">
                    <h2>If Yes, please give details</h2>
                    <asp:TextBox ID="TextApliedBfrDtls" class="form1" TextMode="MultiLine" onkeydown="textCounter(cphMain_TextApliedBfrDtls,450)" onkeyup="textCounter(cphMain_TextApliedBfrDtls,450)" onkeypress="return isTagWithEnter(event)" onblur="textCounter(cphMain_TextApliedBfrDtls, 450);" onchange="return IncrmntConfrmCounterOther();" runat="server" MaxLength="499" Width="50%" Height="100px" Style="resize: none; text-transform: uppercase; font-family: calibri;margin-right: 3%;"></asp:TextBox>

                </div>
            </div>

            <div class="eachform" style="float: left; width: 100%;">
                <div style="float: left; width: 50%">
                    <%--<asp:CheckBox ID="CheckBoxIllSts" Text="" runat="server" onchange="return IncrmntConfrmCounterOther();" onkeypress="return isTag(event);" onClick="refVerClick();" style="float: right;" class="form2" />--%>
                    <h2 style="font-size: 18px; width: 44%;">Are you related to any past / present employee / director of this Company? </h2>

                    <asp:RadioButton ID="RadioRelate1" onkeydown="return DisableEnter(event);" Style="float: left; font-family: Calibri; color: #697259;" Text="Yes" onchange="return IncrmntConfrmCounterOther();" runat="server" GroupName="RadioRelate" />
                    <asp:RadioButton ID="RadioRelate2" onkeydown="return DisableEnter(event);" Style="float: left; font-family: Calibri; color: #697259;" Text="No" onchange="return IncrmntConfrmCounterOther();" runat="server" Checked="true" GroupName="RadioRelate" />
                </div>
                <div style="float: left; width: 48%; margin-left: 2%;">
                    <%--<asp:CheckBox ID="CheckBoxIllSts" Text="" runat="server" onchange="return IncrmntConfrmCounterOther();" onkeypress="return isTag(event);" onClick="refVerClick();" style="float: right;" class="form2" />--%>
                    <h2 style="font-size: 18px; width: 46%;">Do you have any objection to our securing report from your present and previous employers: (if required) </h2>

                    <asp:RadioButton ID="RadioObj1" onkeydown="return DisableEnter(event);" Style="float: left; font-family: Calibri; color: #697259;" Text="Yes" onchange="return IncrmntConfrmCounterOther();" runat="server" GroupName="Radioobj" />
                    <asp:RadioButton ID="RadioObj2" onkeydown="return DisableEnter(event);" Style="float: left; font-family: Calibri; color: #697259;" Text="No" onchange="return IncrmntConfrmCounterOther();" runat="server" Checked="true" GroupName="Radioobj" />
                </div>
            </div>


            <%--  <div id="Div6" class="eachform" style="float:right;">
                      <h2> Other documents attach</h2>
                <label id="LabelDoc" for="cphMain_FileUploadOthrdoc" class="custom-file-upload" tabindex="0" style="float: left;margin-left: 13%;">
                    <img src="/Images/Icons/cloud_upload.jpg" />Upload</label>--%>
            <%--<input id="file" name = "file" type="file" onchange="ClearDivDisplayImage()" accept="image/png, image/gif, image/jpeg" />--%>

            <%-- <asp:FileUpload ID="FileUploadOthrdoc" class="fileUpload" runat="server" Style="height: 30px;" onchange="ClearDivDisplayImage1()" Accept="All" />


                <div id="divFileImage" runat="server" style="float: right; width: 7%; height: 20px; margin-top: 1%;">
                    <div class="imgWrap">
                        <img id="Img1" src="/Images/Icons/clear-image-green.png" alt="Clear" onclick="ClearImage1()" onmouseover="ImagePosition('ClearImage')"; style="cursor: pointer; float: right;" />
                        <p id="P4" class="imgDescription" style="color: white;top: 519.233px;position: absolute;left: 51.1%;">Remove Selected File</p>
                    </div>
                    
                  
                </div>
                <div>   
                <asp:Label ID="Label6" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
                    </div>
             <div id="div9" style="float: left;margin-left: 18%;" runat ="server">
                    </div>--%>
            <%--</div>--%>


            <%--MULTIPLE FILE UPLODER BEGIN--%>


            <div id="div-Contact-details1" class="div-Contact-details" style="float: left; margin-left: 0%;">
                <div class="eachform" style="width: 100%; float: left;">
                    <h2>Other Document Attach</h2>
                </div>
                <div id="divPerAtch" runat="server" style="overflow-y: auto; height: 127px; width: 98%;">


                    <table id="TableFileUploadContainerPermit" style="width: 100%;">
                    </table>
                </div>



            </div>


            <%--MULTIPLE FILE UPLODER END--%>


            <div class="eachform" style="margin-top: 4%; margin-left: 35%;">
                <div class="subform" style="width: 448px;">
                    <div class="form-group">
                        <asp:Button ID="btnUpdatePD" runat="server" class="save" Text="Update" OnClick="btnUpdateOthrDtls_Click" OnClientClick="return ValidateOtherDtl(); " />
                        <asp:Button ID="btnAddPD" runat="server" class="save" Text="Save" OnClick="btnAddOtherDtls_Click" OnClientClick="return ValidateOtherDtl();" />
                        <asp:Button ID="btnClearPD" runat="server" Style="margin-left: 11px;" OnClientClick="return AlertClearAllOthers();" class="cancel" Text="Clear" />
                        <asp:Button ID="btncanclpd" runat="server" Style="margin-left: 11px;" OnClientClick="return ConfirmCnclOther();" class="cancel" Text="Cancel" />
                        <%--<asp:Button ID="Button1" runat="server" style="margin-left: 11px;" OnClick="Button1_Click"   class="cancel" Text="Cancel"/>--%>
                    </div>
                </div>
            </div>
        </div>
        <script>

            var confirmboxother = 0;
            function IncrmntConfrmCounterOther() {
                confirmbox++;
                confirmboxother++;
            }



            function AlertClearAllOthers() {
                if (confirmboxother > 0) {
                    if (confirm("Are you sure you want clear all data in this page?")) {
                        document.getElementById("<%=TextName1.ClientID%>").value = "";
                            document.getElementById("<%=TextAddr1.ClientID%>").value = "";


                            document.getElementById("<%=TextOccp1.ClientID%>").value = "";
                            document.getElementById("<%=TextPhn1.ClientID%>").value = "";

                            document.getElementById("<%=TextName2.ClientID%>").value = "";
                            document.getElementById("<%=TextAddr2.ClientID%>").value = "";
                            document.getElementById("<%=TextOccp2.ClientID%>").value = "";
                            document.getElementById("<%=TextPhn2.ClientID%>").value = "";

                            //ddlReligion.Items.Insert(0, "--Select Religion--");
                            document.getElementById("<%=ddlBldGrp.ClientID%>").selectedIndex = "--Select Blood Group--";
                            document.getElementById("<%=txtJoinDate.ClientID%>").value = "";
                            document.getElementById("<%=TxtDOB.ClientID%>").value = "";
                            document.getElementById("<%=TextSpOcu.ClientID%>").value = "";
                            document.getElementById("<%=TextIllDtls.ClientID%>").value = "";
                            document.getElementById("<%=TextApliedBfrDtls.ClientID%>").value = "";

                            //tableClick('divTblid1', Tblid1);
                            return false;
                        }
                        else {
                            return false;
                        }
                    }
                    else {
                        document.getElementById("<%=TextName1.ClientID%>").value = "";
                        document.getElementById("<%=TextAddr1.ClientID%>").value = "";


                        document.getElementById("<%=TextOccp1.ClientID%>").value = "";
                        document.getElementById("<%=TextPhn1.ClientID%>").value = "";

                        document.getElementById("<%=TextName2.ClientID%>").value = "";
                        document.getElementById("<%=TextAddr2.ClientID%>").value = "";
                        document.getElementById("<%=TextOccp2.ClientID%>").value = "";
                        document.getElementById("<%=TextPhn2.ClientID%>").value = "";

                        //ddlReligion.Items.Insert(0, "--Select Religion--");
                        document.getElementById("<%=ddlBldGrp.ClientID%>").selectedIndex = "--Select Blood Group--";
                        document.getElementById("<%=txtJoinDate.ClientID%>").value = "";
                        document.getElementById("<%=TxtDOB.ClientID%>").value = "";
                        document.getElementById("<%=TextSpOcu.ClientID%>").value = "";
                        document.getElementById("<%=TextIllDtls.ClientID%>").value = "";
                        document.getElementById("<%=TextApliedBfrDtls.ClientID%>").value = "";
                        //tableClick('divTblid1', Tblid1);
                        //tableClick('divTblid1', Tblid1);
                        return false;
                    }
                }
                function ConfirmCnclOther() {
                    if (confirmboxother > 0) {
                        if (confirm("Are you sure you want to cancel this page?")) {
                            window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                            return false;
                        }
                        else {
                            return false;
                        }
                    }
                    else {
                        window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                        return false;
                    }
                }
                function ValidateOtherDtl() {
                    var ret = true;
                    // replacing < and > tags
                    var NameWithoutReplace = document.getElementById("<%=TextName1.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TextName1.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=TextAddr1.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TextAddr1.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=TextOccp1.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TextOccp1.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=TextPhn1.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TextPhn1.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=TextName2.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TextName2.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=TextAddr2.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TextAddr2.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=TextOccp2.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TextOccp2.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=TextPhn2.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TextPhn2.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=TextSpOcu.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TextSpOcu.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=TextIllDtls.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TextIllDtls.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=TextApliedBfrDtls.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TextApliedBfrDtls.ClientID%>").value = replaceText2;
            //txtJoinDate
            NameWithoutReplace = document.getElementById("<%=txtJoinDate.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtJoinDate.ClientID%>").value = replaceText2;
            //TxtDOB
            NameWithoutReplace = document.getElementById("<%=TxtDOB.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TxtDOB.ClientID%>").value = replaceText2;

            var Name = document.getElementById("<%=TextName1.ClientID%>").value.trim();
            var Address = document.getElementById("<%=TextAddr1.ClientID%>").value.trim();
            var Ocupation = document.getElementById("<%=TextOccp1.ClientID%>").value.trim();
            var Phone = document.getElementById("<%=TextPhn1.ClientID%>").value.trim();


            var BGroup = document.getElementById("<%=ddlBldGrp.ClientID%>").value;

            var joindate = document.getElementById("cphMain_txtJoinDate").value.trim();
            var arrDatePickerDate1 = joindate.split("-");
            var convjndate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
            var dob = document.getElementById("cphMain_TxtDOB").value.trim();
            var arrDatePickerDate1 = dob.split("-");
            var convdob = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
            var cdate = new Date();

            document.getElementById("<%=TextName1.ClientID%>").style.borderColor = "";
            document.getElementById("<%=TextAddr1.ClientID%>").style.borderColor = "";
            document.getElementById("<%=TextOccp1.ClientID%>").style.borderColor = "";
            document.getElementById("<%=TextPhn1.ClientID%>").style.borderColor = "";

            document.getElementById("<%=ddlBldGrp.ClientID%>").style.borderColor = "";
            document.getElementById("<%=TxtDOB.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtJoinDate.ClientID%>").style.borderColor = "";
            document.getElementById('divMessageAreaPD').style.display = "none";
            document.getElementById('imgMessageAreaPD').src = "";
            document.getElementById('ErrorMsgMob').style.display = "none";
            document.getElementById('ErrorMsgMob11').style.display = "none";

            var Mobile = document.getElementById("<%=TextPhn1.ClientID%>").value.trim();
            var Mobile2 = document.getElementById("<%=TextPhn2.ClientID%>").value.trim();

            var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;

            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            var minNumberofChars = 6;
            var maxNumberofChars = 16;
            var regularExpression = /(?=.*\d)(?=.*[~!@#$%^&*])(?=.*[A-Za-z]).{6,16}/;

            if (Mobile.length != 0) {
                if (!mobileregular.test(Mobile)) {
                    document.getElementById("<%=TextPhn1.ClientID%>").focus();
                    document.getElementById("<%=TextPhn1.ClientID%>").style.borderColor = "Red";
                    document.getElementById('divMessageAreaPD').style.display = "block";
                    document.getElementById('ErrorMsgMob').style.display = "";

                    document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    var OrgMobileFocus = document.getElementById("<%=TextPhn1.ClientID%>").focus();
                    ret = false;
                }
            }
            if (Mobile2.length != 0) {
                if (!mobileregular.test(Mobile2)) {
                    document.getElementById("<%=TextPhn2.ClientID%>").focus();

                    document.getElementById("<%=TextPhn2.ClientID%>").style.borderColor = "Red";
                    document.getElementById('divMessageAreaPD').style.display = "block";
                    document.getElementById('ErrorMsgMob11').style.display = "";
                    // alert(""); 
                    document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    var OrgMobileFocus = document.getElementById("<%=TextPhn2.ClientID%>").focus();
                    ret = false;
                }
            }

            if (convdob > cdate) {
                document.getElementById('divMessageAreaPD').style.display = "";
                document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=TxtDOB.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below."; //EMP17
                document.getElementById("<%=TxtDOB.ClientID%>").focus();

                ret = false;

            }

            if (convjndate <= convdob) {
                document.getElementById('divMessageAreaPD').style.display = "";
                document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=TxtDOB.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = "Date of birth should be less than  joining date.";
                document.getElementById("<%=TxtDOB.ClientID%>").focus();


                ret = false;

            }

         
     
        
        
         
            if (joindate == "") {
                document.getElementById('divMessageAreaPD').style.display = "";
                document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=txtJoinDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.."; //EMP17
                document.getElementById("<%=txtJoinDate.ClientID%>").focus();
                ret = false;
            }
                    if (BGroup == "--Select Blood Group--") {
                        document.getElementById('divMessageAreaPD').style.display = "";
                        document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=ddlBldGrp.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.."; //EMP17
                           document.getElementById("<%=ddlBldGrp.ClientID%>").focus();
                           ret = false;
                       }
                    if (Phone == "") //emp17
                    {
                        document.getElementById('divMessageAreaPD').style.display = "";
                        document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=TextPhn1.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.."; //EMP17
                           document.getElementById("<%=TextPhn1.ClientID%>").focus();
                           ret = false;
                       }
                    if (Ocupation == "") //emp17
                    {
                        document.getElementById('divMessageAreaPD').style.display = "";
                        document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=TextOccp1.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.."; //EMP17
                            document.getElementById("<%=TextOccp1.ClientID%>").focus();
                            ret = false;
                        }
                    if (Address == "") {
                        document.getElementById('divMessageAreaPD').style.display = "";
                        document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=TextAddr1.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.."; //EMP17
                            document.getElementById("<%=TextAddr1.ClientID%>").focus();
                            ret = false;
                        }
                    if (Name == "") {
                        document.getElementById('divMessageAreaPD').style.display = "";
                        document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=TextName1.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.."; //EMP17
                               document.getElementById("<%=TextName1.ClientID%>").focus();
                               ret = false;
                           }

            return ret;
        }
        </script>
        <script>



            var FileCounterPer = 0;

            function AddFileUploadPer() {

                var FrecRow = '<tr id="FilerowId_' + FileCounterPer + '" >';
                var labelForStyle = '<label tabindex="0"  for="file' + FileCounterPer + '" class="custom-file-upload" style="margin-left: 0%;font-family: Calibri;"> <img src="/Images/Icons/cloud_upload.jpg"></img>Upload Document</label>';
                var tdInner = labelForStyle + '<input   id="file' + FileCounterPer + '" name = "file' + FileCounterPer +

                               '" type="file" onchange="ChangeFilePer(' + FileCounterPer + ');" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/>';

                FrecRow += '<td  style="width: 34%;" >' + tdInner + '</td>';

                FrecRow += '<td  style="word-break: break-all;font-family: Calibri;" id="filePath' + FileCounterPer + '"  ></td  >';
                FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterPer + '"  style="width: 1.5%; padding-left: 4px;"> <input type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" title="Add" onclick="return CheckaddMoreRowsIndividualFilesPer(' + FileCounterPer + ');" style="  cursor: pointer;"></td>';
                FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" id="FieldId' + FileCounterPer + '" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete" title="Delete" onclick = "return RemoveFileUploadPer(' + FileCounterPer + ');"    style=" cursor: pointer;" ></td>';

                FrecRow += ' <td id="FileInx' + FileCounterPer + '" style="display: none;" > </td>';
                FrecRow += '<td id="FileSave' + FileCounterPer + '" style="display: none;"> </td>';
                FrecRow += '<td id="FileEvt' + FileCounterPer + '" style="display: none;">INS</td>';
                FrecRow += '<td id="FileDtlId' + FileCounterPer + '" style="display: none;"></td>';
                FrecRow += '<td id="DbFileName' + FileCounterPer + '" style="display: none;"></td>';
                FrecRow += '</tr>';
                jQuery('#TableFileUploadContainerPermit').append(FrecRow);



                document.getElementById('filePath' + FileCounterPer).innerHTML = 'No File Uploaded';

                FileCounterPer++;

            }
            function EditAttachmentPer(editTransDtlId, EditFileName, EditActualFileName) {

                var FrecRow = '<tr id="FilerowId_' + FileCounterPer + '" >';


                var labelForStyle = '<label for="file' + FileCounterPer + '" class="custom-file-upload" > <img src="/Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
                var tdInner = labelForStyle + '<input   id="file' + FileCounterPer + '" name = "file' + FileCounterPer +

                               '" type="file" onchange="ChangeFilePer(' + FileCounterPer + ')" />';

                FrecRow += '<td style="width: 25%; display:none;" >' + tdInner + '</td>';

                var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=HiddenFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

                     FrecRow += '<td colspan="2"  id="filePath' + FileCounterPer + '" style="border-bottom: 1px dotted rgb(205, 237, 196); font-family:calibri;"' + '  >' + tdFileNameEdit + '</td  >';



                     FrecRow += '<td id="FileIndvlAddMoreRow' + FileCounterPer + '"  style="width: 1.5%; padding-left: 4px;"> <input type="image" class="QuotnEntryField" src="/../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFilesPer(' + FileCounterPer + ');" style="  cursor: pointer;"></td>';
                     FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="QuotnEntryField" src="/../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUploadPer(' + FileCounterPer + ');"    style=" cursor: pointer;" ></td>';


                     FrecRow += ' <td id="FileInx' + FileCounterPer + '" style="display: none;" > </td>';
                     FrecRow += '<td id="FileSave' + FileCounterPer + '" style="display: none;"> </td>';
                     FrecRow += '<td id="FileEvt' + FileCounterPer + '" style="display: none;">UPD</td>';
                     FrecRow += '<td id="FileDtlId' + FileCounterPer + '" style="display: none;">' + editTransDtlId + '</td>';
                     FrecRow += '<td id="DbFileName' + FileCounterPer + '" style="display: none;">' + EditFileName + '</td>';
                     FrecRow += '</tr>';

                     jQuery('#TableFileUploadContainerPermit').append(FrecRow);
                     document.getElementById("FileInx" + FileCounterPer).innerHTML = FileCounterPer;
                     document.getElementById("FileIndvlAddMoreRow" + FileCounterPer).style.opacity = "0.3";
                     // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
                     FileLocalStorageAddPer(FileCounterPer);
                     FileCounterPer++;

                 }
                 function RemoveFileUploadPer(removeNum) {
                     if (confirm("Are you Sure you want to Delete Selected File?")) {

                         var Filerow_index = jQuery('#FilerowId_' + removeNum).index();

                         FileLocalStorageDeletePer(Filerow_index, removeNum);
                         jQuery('#FilerowId_' + removeNum).remove();




                         // alert(Filerow_index);
                         var $noC = jQuery.noConflict();
                         var TableFileRowCount = document.getElementById("TableFileUploadContainerPermit").rows.length;

                         if (TableFileRowCount != 0) {
                             var idlast = $noC('#TableFileUploadContainerPermit tr:last').attr('id');
                             //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                             //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                             if (idlast != "") {
                                 var res = idlast.split("_");
                                 //  alert(res[1]);
                                 document.getElementById("FileInx" + res[1]).innerHTML = " ";
                                 document.getElementById("FileIndvlAddMoreRow" + res[1]).style.opacity = "1";
                             }
                         }
                         else {
                             AddFileUploadPer();


                         }




                     }
                     else {

                         return false;
                     }
                 }
                 function CheckaddMoreRowsIndividualFilesPer(x) {
                     var check = document.getElementById("FileInx" + x).innerHTML;

                     if (check == " ") {

                         var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                         if (Fevt != 'UPD') {
                             if (CheckFileUploaded(x) == true) {
                                 document.getElementById("FileInx" + x).innerHTML = x;
                                 document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                                 AddFileUploadPer();
                                 return false;
                             }
                         }
                         else {
                             document.getElementById("FileInx" + x).innerHTML = x;
                             document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                             AddFileUploadPer();
                             return false;
                         }
                     }
                     return false;
                 }
                 function ChangeFilePer(x) {
                     if (ClearDivDisplayImage1(x)) {
                         IncrmntConfrmCounter();
                         if (document.getElementById('file' + x).value != "") {
                             document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;

                         }
                         else {
                             document.getElementById('filePath' + x).innerHTML = 'No File Uploaded';


                         }
                         var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
                         //   alert('hi SavedorNot' + SavedorNot);
                         if (SavedorNot == "saved") {
                             var row_index = jQuery('#FilerowId_' + x).index();
                             FileLocalStorageEditPer(x, row_index);
                         }
                         else {
                             FileLocalStorageAddPer(x);
                         }
                     }
                 }
                 function ClearDivDisplayImage1(x) {

                     var fuData = document.getElementById('file' + x);
                     var FileUploadPath = fuData.value;
                     var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();



                     if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                                 || Extension == "jpeg" || Extension == "jpg" || Extension == "xlsx" || Extension == "xls" || Extension == "doc" ||
                         Extension == "docx" || Extension == "csv" || Extension == "ppt" || Extension == "pptx"
                        || Extension == "txt" || Extension == "pdf") {


                         return true;

                     }
                     else {
                         document.getElementById('file' + x).value = "";
                         document.getElementById('filePath' + x).innerHTML = 'No File Selected';
                         alert("The specified file type could not be uploaded.Only support image files and document files");
                         return false;
                     }
                 }


                 function FileLocalStorageAddPer(x) {
                     var tbClientPermitFileUpload = localStorage.getItem("tbClientPermitFileUpload");//Retrieve the stored data

                     tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

                     if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                         tbClientPermitFileUpload = [];


                     var FilePath = document.getElementById("filePath" + x).innerHTML;
                     var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
                     var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                     // alert('FilePath' + FilePath);
                     //  alert('descrptn' + descrptn);
                     if (Fevt == 'INS') {
                         var $addFile = jQuery.noConflict();
                         var client = JSON.stringify({
                             ROWID: "" + x + "",

                             EVTACTION: "" + Fevt + "",
                             DTLID: "0"

                         });
                     }
                     else if (Fevt == 'UPD') {
                         var $addFile = jQuery.noConflict();
                         var client = JSON.stringify({
                             ROWID: "" + x + "",

                             EVTACTION: "" + Fevt + "",
                             DTLID: "" + FdetailId + ""

                         });
                     }


                     tbClientPermitFileUpload.push(client);
                     localStorage.setItem("tbClientPermitFileUpload", JSON.stringify(tbClientPermitFileUpload));

                     $addFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));
                     document.getElementById("FileSave" + x).innerHTML = "saved";
                     return true;

                 }
                 function FileLocalStorageDeletePer(row_index, x) {

                     var $DelFile = jQuery.noConflict();
                     var tbClientPermitFileUpload = localStorage.getItem("tbClientPermitFileUpload");//Retrieve the stored data

                     tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

                     if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                         tbClientPermitFileUpload = [];



                     // Using splice() we can specify the index to begin removing items, and the number of items to remove.
                     tbClientPermitFileUpload.splice(row_index, 1);
                     localStorage.setItem("tbClientPermitFileUpload", JSON.stringify(tbClientPermitFileUpload));
                     $DelFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));





                     var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                     if (Fevt == 'UPD') {
                         var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

                         if (FdetailId != '') {

                             DeleteFileLSTORAGEAddPer(x);
                         }

                     }

                     function DeleteFileLSTORAGEAddPer(x) {
                         document.getElementById("<%=HiddenfileuploadChk.ClientID%>").value = "1";
                         var tbClientPermitFileUploadCancel = localStorage.getItem("tbClientPermitFileUploadCancel");//Retrieve the stored data

                         tbClientPermitFileUploadCancel = JSON.parse(tbClientPermitFileUploadCancel); //Converts string to object

                         if (tbClientPermitFileUploadCancel == null) //If there is no data, initialize an empty array
                             tbClientPermitFileUploadCancel = [];


                         var FileName = document.getElementById("DbFileName" + x).innerHTML;
                         var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;




                         var $addFile = jQuery.noConflict();
                         var client = JSON.stringify({
                             ROWID: "" + x + "",
                             FILENAME: "" + FileName + "",
                             // EVTACTION: "" + Fevt + "",
                             DTLID: "" + FdetailId + ""

                         });

                         //alert('delete db');

                         tbClientPermitFileUploadCancel.push(client);
                         localStorage.setItem("tbClientPermitFileUploadCancel", JSON.stringify(tbClientPermitFileUploadCancel));

                         $addFile("#cphMain_hiddenPerFileCanclDtlId").val(JSON.stringify(tbClientPermitFileUploadCancel));





                         //document.getElementById("FileSave" + x).innerHTML = "saved";
                         //   alert('saved');
                         return true;

                     }

                 }
                 function FileLocalStorageEditPer(x, row_index) {
                     var tbClientPermitFileUpload = localStorage.getItem("tbClientPermitFileUpload");//Retrieve the stored data

                     tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

                     if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                         tbClientPermitFileUpload = [];

                     var FilePath = document.getElementById("filePath" + x).innerHTML;
                     var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
                     var Fevt = document.getElementById("FileEvt" + x).innerHTML;

                     if (Fevt == 'INS') {

                         var $FileE = jQuery.noConflict();
                         tbClientPermitFileUpload[row_index] = JSON.stringify({
                             ROWID: "" + x + "",


                             EVTACTION: "" + Fevt + "",
                             DTLID: "0"
                         });//Alter the selected item on the table
                     }
                     else {

                         var $FileE = jQuery.noConflict();
                         tbClientPermitFileUpload[row_index] = JSON.stringify({
                             ROWID: "" + x + "",


                             EVTACTION: "" + Fevt + "",
                             DTLID: "" + FdetailId + ""

                         });//Alter the selected item on the table



                     }



                     localStorage.setItem("tbClientPermitFileUpload", JSON.stringify(tbClientPermitFileUpload));
                     $FileE("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientPermitFileUpload));
                     return true;
                 }
                 function CheckFileUploaded(x) {

                     if (document.getElementById('file' + x).value != "") {
                         return true;
                     }
                     else {
                         return false;
                     }


                 }

                 //emp0021/////
                 var $noCon = jQuery.noConflict();
                 $noCon(window).load(function () {


                     localStorage.clear();
                     
                     document.getElementById("<%=hiddenPerFileCanclDtlId.ClientID%>").value = "";
                     if (document.getElementById("<%=hiddenOtherUpdChk.ClientID%>").value == "1")
                     {
                         IncrmntConfrmCounterOther();
                     }
                     var EditVal = document.getElementById("<%=HiddenEdit.ClientID%>").value;
            var ViewVal = document.getElementById("<%=HiddenView.ClientID%>").value;


                    if (document.getElementById("<%=RadioAppliedNo.ClientID%>").checked == true) {
                        DisableApllied('Applied2');
                    }
                    if (document.getElementById("<%=RBillness2.ClientID%>").checked == true) {
                        DisableIllness('illness2')
                    }


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
                                if (json[key].TransDtlId != "") {
                                  //  if (document.getElementById("<%=HiddenfileuploadChk.ClientID%>").value != "1")
                                    EditAttachmentPer(json[key].TransDtlId, json[key].FileName, json[key].ActualFileName);

                                }
                            }
                        }
                        
                     // if(document.getElementById("<%=HiddenfileuploadChk.ClientID%>").value!="1")
                        AddFileUploadPer();
                    }
                    else {
                        //if (document.getElementById("<%=HiddenfileuploadChk.ClientID%>").value != "1")
                        AddFileUploadPer();
                    }



                });


        </script>

        <%-----------------------------------------end Other info-----------------------------------------%>

        <%--evm-0012   ----------------------------------------------  Qualification start------------------------------------------------------------------------------%>

        <script>
            var confirmboxWrkExp = 0;
            var confirmboxEdu = 0;
            var confirmboxSklCer = 0;
            var confirmboxLang = 0;
            function IncrmntConfrmCounterWrkExp() {
                confirmboxWrkExp++;
            }
            function IncrmntConfrmCounterEdu() {
                confirmboxEdu++;
            }

            function IncrmntConfrmCounterLang() {
                confirmboxLang++;
            }
            function AlertClearAllWrkExp() {
                if (confirmboxWrkExp > 0) {
                    if (confirm("Are you sure you want clear all data in this page?")) {
                        $('#divWorkExp input[type="text"]').val('');
                        document.getElementById("<%=txtNameOfEmployerWrkExp.ClientID%>").value = "";
                      document.getElementById("<%=txtAddressOfEmployerWrkExp.ClientID%>").value = "";
                      document.getElementById("<%=txtDateOfJoiningWrkExp.ClientID%>").value = "";
                      document.getElementById("<%=txtWorkExpYearsWrkExp.ClientID%>").value = "";
                      document.getElementById("<%=txtDateOfLeavingWrkExp.ClientID%>").value = "";
                      document.getElementById("<%=txtDesignationWrkExp.ClientID%>").value = "";
                        document.getElementById("<%=txtSalaryWrkExp.ClientID%>").value = "";
                        divButtonWrkExpClick();
                      //tableClick('divTblid7', Tblid7);
                      return false;
                  }
                    else {
                        divButtonWrkExpClick();
                       // tableClick('divTblid7', Tblid7);
                    
                      return false;
                  }
              }
              else {
                  $('#divWorkExp input[type="text"]').val('');
                  document.getElementById("<%=txtNameOfEmployerWrkExp.ClientID%>").value = "";
                  document.getElementById("<%=txtAddressOfEmployerWrkExp.ClientID%>").value = "";
                  document.getElementById("<%=txtDateOfJoiningWrkExp.ClientID%>").value = "";
                  document.getElementById("<%=txtWorkExpYearsWrkExp.ClientID%>").value = "";
                  document.getElementById("<%=txtDateOfLeavingWrkExp.ClientID%>").value = "";
                  document.getElementById("<%=txtDesignationWrkExp.ClientID%>").value = "";
                    document.getElementById("<%=txtSalaryWrkExp.ClientID%>").value = "";
                    divButtonWrkExpClick();
                //  tableClick('divTblid7', Tblid7);
                  return false;
              }
          }

          function AlertClearAllEdu() {
              if (confirmboxEdu > 0) {
                  if (confirm("Are you sure you want clear all data in this page?")) {
                      $('#divEductn input[type="text"]').val('');
                      document.getElementById("<%=ddlEduType.ClientID%>").value = "--Select Type--";
                    
                      var $coo = jQuery.noConflict();
                     // $coo('cphMain_ddlEduQualification').empty();
                      var ddlTestDropDownListXML = $coo("#cphMain_ddlEduQualification");
                      ddlTestDropDownListXML.empty();
                      var OptionStart = $coo("<option>--Select Course--</option>");
                      OptionStart.attr("value", 0);
                      ddlTestDropDownListXML.append(OptionStart);
                     // alert();
                      document.getElementById("<%=ddlEduQualification.ClientID%>").value = "0";
                     // document.getElementById("<%=ddlEduQualification.ClientID%>").value = "--Select Course--";
                      document.getElementById("<%=ddlMonthEdu.ClientID%>").value = "--MONTH--";
                      document.getElementById("<%=ddlYearEdu.ClientID%>").value = "--YEAR--";

                  

                      document.getElementById("<%=txtEduSpecialization.ClientID%>").value = "";
                      document.getElementById("<%=txtEduDegree.ClientID%>").value = "";
                      document.getElementById("<%=txtEduPercentage.ClientID%>").value = "";
                      document.getElementById("<%=txtEduStrtDate.ClientID%>").value = "";
                      document.getElementById("<%=txtEduInstite.ClientID%>").value = "";

                      tableClick('divTblid7', Tblid7);
                      return false;
                  }
                  else {
                      tableClick('divTblid7', Tblid7);
                      return false;
                  }
              }
              else { // evm-0023 remove ddlEduQualification ddl value

                  $('#divEductn input[type="text"]').val('');
                  tableClick('divTblid7', Tblid7);

                  document.getElementById("<%=ddlEduType.ClientID%>").value = "--Select Type--";
                 
                  //document.getElementById("<%=ddlEduQualification.ClientID%>").value = "--Select Type--"; //remov evm-0023
                  
                  var $coo = jQuery.noConflict();
                  // $coo('cphMain_ddlEduQualification').empty();
                  var ddlTestDropDownListXML = $coo("#cphMain_ddlEduQualification");
                  ddlTestDropDownListXML.empty();
                  var OptionStart = $coo("<option>--Select Course--</option>");
                  OptionStart.attr("value", 0);
                  ddlTestDropDownListXML.append(OptionStart);

                  //document.getElementById("<%=ddlEduQualification.ClientID%>").value = "--Select Type--"; //remov evm-0023

                  document.getElementById("<%=txtEduSpecialization.ClientID%>").value = "";
                  document.getElementById("<%=txtEduDegree.ClientID%>").value = "";
                  document.getElementById("<%=txtEduPercentage.ClientID%>").value = "";
                  document.getElementById("<%=txtEduStrtDate.ClientID%>").value = "";
                  document.getElementById("<%=txtEduInstite.ClientID%>").value = "";
                  document.getElementById("<%=ddlMonthEdu.ClientID%>").value = "--MONTH--";
                  document.getElementById("<%=ddlYearEdu.ClientID%>").value = "--YEAR--";
                  return false;
              }
          }

          function AlertClearAllLang() {
              if (confirmboxLang > 0) {
                  if (confirm("Are you sure you want clear all data in this page?")) {
                      $('#divLang').find('input[type=checkbox]:checked').removeAttr('checked');
                      document.getElementById("<%=ddlQuLang.ClientID%>").value = "--Select Language--";
                      divButtonLangClick();
                      //tableClick('divTblid7', Tblid7);
                      return false;
                  }
                  else {
                      divButtonLangClick();
                      return false;
                  }
              }
              else {
                  $('#divLang').find('input[type=checkbox]:checked').removeAttr('checked');
                  document.getElementById("<%=ddlQuLang.ClientID%>").value = "--Select Language--";
                  divButtonLangClick();
                 // tableClick('divTblid7', Tblid7);
                  return false;
              }
          }
          function ConfirmCnclWrkExp() {
              if (confirmboxWrkExp > 0) {
                  if (confirm("Are you sure you want to cancel this page?")) {
                      window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {

                  window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                  return false;
              }
          }
          function ConfirmCnclEdu() {
              if (confirmboxEdu > 0) {
                  if (confirm("Are you sure you want to cancel this page?")) {
                      window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {

                  window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                  return false;
              }
          }

          function ConfirmCnclLang() {
              if (confirmboxLang > 0) {
                  if (confirm("Are you sure you want to cancel this page?")) {
                      window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {

                  window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                  return false;
              }
          }
          function NumChecking(textboxid) {
              
              var txtPerVal = document.getElementById(textboxid).value;
              
              txtPerVal = txtPerVal.replace(/,/g, "");


              //evm-0023 start
              if (txtPerVal > 100) {              
                 document.getElementById("<%=txtEduPercentage.ClientID%>").value ="";
                  return false;
              }
              //evm-0023 end


              if (txtPerVal == "") {
                  return false;
              }
              else {
                  if (!isNaN(txtPerVal) == false) {
                      document.getElementById('' + textboxid + '').value = "";
                      return false;
                  }
                  else {
                      if (txtPerVal < 0) {
                          document.getElementById('' + textboxid + '').value = "";
                          return false;
                      }
                      //   textCounter(textboxid, 6);
                  }
              }


          }

          function NumCheckingForAge(textboxid) {
              //NameWithoutReplace.replace(/</g, "");
              var txtPerVal = document.getElementById(textboxid).value;

              txtPerVal = txtPerVal.replace(/,/g, "");

              txtPerVal = txtPerVal.replace(/\./g, "");
              document.getElementById('' + textboxid + '').value = txtPerVal.trim();

              if (txtPerVal == "") {
                  return false;
              }
              else {
                  if (!isNaN(txtPerVal) == false) {
                      document.getElementById('' + textboxid + '').value = "";
                      return false;
                  }
                  else {
                      if (txtPerVal < 0) {
                          document.getElementById('' + textboxid + '').value = "";
                          return false;
                      }
                      //   textCounter(textboxid, 6);
                  }
              }


          }

        </script>
        <%----------------- Start Qualification -------------%>
        <asp:HiddenField ID="HiddenField17" runat="server" />
        <asp:HiddenField ID="HiddenField18" runat="server" />
        <asp:HiddenField ID="HiddenField19" runat="server" />
        <asp:HiddenField ID="HiddenField20" runat="server" />
        <asp:HiddenField ID="HiddenField21" runat="server" />
        <asp:HiddenField ID="HiddenField22" runat="server" />
        <%------------------End Qualification ----------------%>
        <div id="divTblid7" style="float: left; background-color: #f3f3f3; width: 94%; border: 2px solid; border-color: #06558f; padding: 2%; display: none;">
            <%--Qualification --%>
            <div style="width: 99%; border: 1px solid; margin-top: -1%; padding: 4px; border-color: #144c96; background: #51828a;">
                <div id="divButtonEducation" onclick="divButtonEductnClick()" style="margin-left: 10%;" class="divbutton">Academic</div>
                <div id="divButtonWrkExp" onclick="divButtonWrkExpClick()" class="divbutton">Work Experience</div>

                <%--<div id="divButtonSkill" onclick="divButtonSkillClick()" class="divbutton" >Skills & Certifications</div>--%>
                <div id="divButtonLang" onclick="divButtonLangClick()" class="divbutton">Language</div>
            </div>
            <asp:HiddenField ID="HiddenField23" runat="server" />
            <asp:HiddenField ID="HiddenCorpId" runat="server" />
            <asp:HiddenField ID="hiddenWrkExpDtlID" runat="server" />

            <script>   function SuccessInsertionWrkExp() {

       document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").

           document.getElementById('divMessageAreaWrkExp').style.display = "";
       document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17

       document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "Work experience details inserted successfully.";
       $('#divWorkExp input[type="text"]').val('');

       document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value = "Work";
       tableClick('divTblid7', Tblid7);

   }
   function SuccessUpdationWrkExp() {
       document.getElementById('divMessageAreaWrkExp').style.display = "";
       document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17

       document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "Work experience details updated successfully.";
       $('#divWorkExp input[type="text"]').val('');

       document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value = "Work";
       tableClick('divTblid7', Tblid7);
   }

   function SuccessDeletionWrkExp() {
       document.getElementById('divMessageAreaWrkExp').style.display = "";
       document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17
       document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "Work experience details deleted successfully.";
                    }

                    function updateWrkExpById(Id, candID) {
                      
                        document.getElementById("<%=txtNameOfEmployerWrkExp.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=txtDateOfJoiningWrkExp.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=txtDesignationWrkExp.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=txtAddressOfEmployerWrkExp.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=txtNameOfEmployerWrkExp.ClientID%>").focus();    //emp17focus
            document.getElementById("<%=HiddenWorkExpDtlId.ClientID%>").value = Id;
            var OrgIDStaff = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
            var CorpidIDStaff = document.getElementById("<%=HiddenCorpId.ClientID%>").value;

            var Details = PageMethods.ReadWrkExpDtlById(Id, candID, OrgIDStaff, CorpidIDStaff, function (response) {
                document.getElementById("<%=txtNameOfEmployerWrkExp.ClientID%>").value = response.WrkEmpName;
                document.getElementById("<%=txtWorkExpYearsWrkExp.ClientID%>").value = response.WrkExpYears;
                document.getElementById("<%=txtGCCExpYearsWrkExp.ClientID%>").value = response.WrkGCCExpYears;
                document.getElementById("<%=txtAddressOfEmployerWrkExp.ClientID%>").value = response.WrkAddress;
                document.getElementById("<%=txtDateOfJoiningWrkExp.ClientID%>").value = response.LastWrkJoiningDate;
                document.getElementById("<%=txtDateOfLeavingWrkExp.ClientID%>").value = response.LastWrkLeavingDate;
                document.getElementById("<%=txtDesignationWrkExp.ClientID%>").value = response.Designation;
                document.getElementById("<%=txtSalaryWrkExp.ClientID%>").value = response.Salary;


                document.getElementById("<%=hiddenWrkExpDtlID.ClientID%>").value = response.WorkExpDtl_id;
                document.getElementById("cphMain_btnAddWrkExp").style.display = "none";
                document.getElementById("cphMain_btnClearWrkExp").style.display = "none";
                document.getElementById("cphMain_btnUpdateWrkExp").style.display = "block";
                document.getElementById("cphMain_lblWrkExpCaptn").innerText = "Edit Work Experience"
                $(window).scrollTop(0);
            });
            return false;
        }
        function deleteWrkExpById(Id, empId) {



            if (confirm("Do you want to cancel this Entry?")) {
                var OrgIDStaff = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
                   var CorpidIDStaff = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                   var Details = PageMethods.deleteWrkExpById(Id, empId, OrgIDStaff, CorpidIDStaff, function (response) {

                       document.getElementById("cphMain_divListWrkExp").innerHTML = response.strWrkExpList;
                       SuccessDeletionWrkExp();
                       $p('#ReportTableWrkExp').DataTable({
                           //emp17
                           "pagingType": "full_numbers",
                           "bSort": true

                       });      //emp17


                   });
               }
               else {

               }


           }

 <%--evm 0019 workexperience--%>
                function DateChkSearch() {

                    if (document.getElementById("<%=txtDateOfJoiningWrkExp.ClientID%>").value != "" && document.getElementById("<%=txtDateOfLeavingWrkExp.ClientID%>").value != "") {
                            var datepickerDate = document.getElementById("<%=txtDateOfJoiningWrkExp.ClientID%>").value;
                            var arrDatePickerDate = datepickerDate.split("-");
                            var dateTxIss = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                            var datepickerDate = document.getElementById("<%=txtDateOfLeavingWrkExp.ClientID%>").value;
                            var arrDatePickerDate = datepickerDate.split("-");
                            var dateCompExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                            if (dateTxIss >= dateCompExp) {
                                document.getElementById("<%=txtDateOfLeavingWrkExp.ClientID%>").value = "";
                    alert("Sorry, leaving date should be greater than from date !");
                }
            }
            return false;

        }

                    <%--evm 0019 workexperience--%>


                function ValidateWrkExp() {
                    var ret = true;

                    document.getElementById("<%=txtDateOfJoiningWrkExp.ClientID%>").style.borderColor = "";
               document.getElementById("<%=txtDateOfLeavingWrkExp.ClientID%>").style.borderColor = "";

               document.getElementById("<%=txtDesignationWrkExp.ClientID%>").style.borderColor = "";
               document.getElementById("<%=txtAddressOfEmployerWrkExp.ClientID%>").style.borderColor = "";
               document.getElementById("<%=txtNameOfEmployerWrkExp.ClientID%>").style.borderColor = "";
               // replacing < and > tags
               var NameWithoutReplace = document.getElementById("<%=txtNameOfEmployerWrkExp.ClientID%>").value;
               var replaceText1 = NameWithoutReplace.replace(/</g, "");
               var replaceText2 = replaceText1.replace(/>/g, "");
               document.getElementById("<%=txtNameOfEmployerWrkExp.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtAddressOfEmployerWrkExp.ClientID%>").value;
               replaceText1 = NameWithoutReplace.replace(/</g, "");
               replaceText2 = replaceText1.replace(/>/g, "");
               document.getElementById("<%=txtAddressOfEmployerWrkExp.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtGCCExpYearsWrkExp.ClientID%>").value;
               replaceText1 = NameWithoutReplace.replace(/</g, "");
               replaceText2 = replaceText1.replace(/>/g, "");
               document.getElementById("<%=txtGCCExpYearsWrkExp.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtWorkExpYearsWrkExp.ClientID%>").value;
               replaceText1 = NameWithoutReplace.replace(/</g, "");
               replaceText2 = replaceText1.replace(/>/g, "");
               document.getElementById("<%=txtWorkExpYearsWrkExp.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtDesignationWrkExp.ClientID%>").value;
               replaceText1 = NameWithoutReplace.replace(/</g, "");
               replaceText2 = replaceText1.replace(/>/g, "");
               document.getElementById("<%=txtDesignationWrkExp.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtSalaryWrkExp.ClientID%>").value;
               replaceText1 = NameWithoutReplace.replace(/</g, "");
               replaceText2 = replaceText1.replace(/>/g, "");
               document.getElementById("<%=txtSalaryWrkExp.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtDateOfJoiningWrkExp.ClientID%>").value;
               replaceText1 = NameWithoutReplace.replace(/</g, "");
               replaceText2 = replaceText1.replace(/>/g, "");
               document.getElementById("<%=txtDateOfJoiningWrkExp.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtDateOfLeavingWrkExp.ClientID%>").value;
               replaceText1 = NameWithoutReplace.replace(/</g, "");
               replaceText2 = replaceText1.replace(/>/g, "");
               document.getElementById("<%=txtDateOfLeavingWrkExp.ClientID%>").value = replaceText2;

            var EmployerWrkExp = document.getElementById("<%=txtNameOfEmployerWrkExp.ClientID%>").value.trim();
               var AddressOfEmployer = document.getElementById("<%=txtAddressOfEmployerWrkExp.ClientID%>").value.trim();
               var DesignationWrkExp = document.getElementById("<%=txtDesignationWrkExp.ClientID%>").value.trim();
               var FromDate = document.getElementById("<%=txtDateOfJoiningWrkExp.ClientID%>").value.trim();
               var ToDate = document.getElementById("<%=txtDateOfLeavingWrkExp.ClientID%>").value.trim();
               if (FromDate == "") {
                   document.getElementById('divMessageAreaWrkExp').style.display = "";
                   document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaWarning.png";
                   document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtDateOfJoiningWrkExp.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtDateOfJoiningWrkExp.ClientID%>").focus();
                ret = false;


            }
            if (FromDate != "" && ToDate != "") {

                // var joindate = document.getElementById("cphMain_txtJoinDate").value.trim();  
                var arrDatePickerDate1 = FromDate.split("-");
                var convFromDate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
                //   var dob = document.getElementById("cphMain_TxtDOB").value.trim();
                var arrDatePickerDate2 = ToDate.split("-");
                var convToDate = new Date(arrDatePickerDate2[2], arrDatePickerDate2[1] - 1, arrDatePickerDate2[0]);

                if (convToDate <= convFromDate) {
                    document.getElementById('divMessageAreaWrkExp').style.display = "";
                    document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=txtDateOfJoiningWrkExp.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtDateOfLeavingWrkExp.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "Date of joining should be less than Date of leaving.";
                    document.getElementById("<%=txtDateOfJoiningWrkExp.ClientID%>").focus();
                    ret = false;

                }
            }

            if (DesignationWrkExp == "") {
                document.getElementById('divMessageAreaWrkExp').style.display = "";
                document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            document.getElementById("<%=txtDesignationWrkExp.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtDesignationWrkExp.ClientID%>").focus();
                            ret = false;
                        }
                        if (AddressOfEmployer == "") {
                            document.getElementById('divMessageAreaWrkExp').style.display = "";
                            document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
            document.getElementById("<%=txtAddressOfEmployerWrkExp.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtAddressOfEmployerWrkExp.ClientID%>").focus();
            ret = false;
        }
        if (EmployerWrkExp == "") {
            document.getElementById('divMessageAreaWrkExp').style.display = "";
            document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            document.getElementById("<%=txtNameOfEmployerWrkExp.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtNameOfEmployerWrkExp.ClientID%>").focus();
                            ret = false;
                        }
                        return ret;
                    }
            </script>
            <%--Start:Qualification:Work Experience--%>
            <div id="divWorkExp" style="border: .5px solid; border-color: #9ba48b; background-color: #f3f3f3; width: 96%; margin-top: 1%; padding: 2%;">
                <div id="divMessageAreaWrkExp" style="display: none; width: 84%; margin-left: 6%; margin-top: -1%;">
                    <img id="imgMessageAreaWrkExp" src="" />
                    <asp:Label ID="lblMessageAreaWrkExp" runat="server"></asp:Label>
                </div>
                <div id="divwrkExpCaptn" class="Quacaption">
                    <asp:Label ID="lblWrkExpCaptn" runat="server">Add Work Experience</asp:Label>
                </div>
                <br />
                <div class="eachform" style="float: left;">
                    <h2>Name of last Employer*</h2>
                    <asp:TextBox ID="txtNameOfEmployerWrkExp" class="form1" runat="server" onkeypress="return isTag(event);" onchange="return IncrmntConfrmCounterWrkExp();" MaxLength="49" Height="30px" Style="height: 30px; width: 50%; resize: none; text-transform: uppercase; font-family: calibri; margin-right: 5%;"></asp:TextBox>
                </div>

                <div class="eachform" style="float: right">
                    <h2>GCC Experience</h2>
                    <asp:TextBox ID="txtGCCExpYearsWrkExp" class="form1" runat="server" onkeypress="return isTag(event);" onchange="return IncrmntConfrmCounterWrkExp();" onblur="NumChecking('cphMain_txtGCCExpYearsWrkExp');" MaxLength="3" Height="30px" onkeydown="return isNumber(event);" Style="height: 30px; width: 50%; resize: none; text-transform: uppercase; font-family: calibri; margin-right: 5%;"></asp:TextBox>
                </div>
                <div class="eachform" style="float: left">
                    <h2>Work Experience in Years</h2>
                    <asp:TextBox ID="txtWorkExpYearsWrkExp" class="form1" runat="server" onkeypress="return isTag(event);" onchange="return IncrmntConfrmCounterWrkExp();" onblur="NumChecking('cphMain_txtWorkExpYearsWrkExp');" MaxLength="3" Height="30px" onkeydown="return isNumber(event);" Style="height: 30px; width: 50%; resize: none; text-transform: uppercase; font-family: calibri; margin-right: 5%;"></asp:TextBox>
                </div>

                <div class="eachform" style="float: right">
                    <h2>Date of joining*</h2>

                    <div id="divDateOfJoiningWrkExp" class="input-append date" style="float: right; width: 53%; margin-right: 6%;">

                        <%--evm 0019 workexperience--%>

                        <asp:TextBox ID="txtDateOfJoiningWrkExp" class="form1" onblur="DateChkSearch();" onkeypress="return isTag(event);" onchange="return IncrmntConfrmCounterWrkExp();" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height: 30px; width: 81%; margin-top: 0%; float: left;"></asp:TextBox>
                       <%-- evm-0023 onclick="return IncrmntConfrmCounterWrkExp();"--%>
                        <input type="image" runat="server" id="Image11" onclick="return IncrmntConfrmCounterWrkExp();" class="add-on" onblur="return DateChkSearch()" src="/Images/Icons/CalandarIcon.png" style="height: 22px; width: 22px; margin-top: 0%;" />
                        <%--evm 0019 workexperience--%>

                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divDateOfJoiningWrkExp').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                    </div>


                </div>
                <div class="eachform" style="float: left;">
                    <h2>Date of leaving</h2>

                    <div id="divDateOfLeavingWrkExp" class="input-append date" style="float: right; width: 53%; margin-right: 6%;">


                        <%--evm 0019 workexperience--%>
                        <asp:TextBox ID="txtDateOfLeavingWrkExp" class="form1" onblur="DateChkSearch();" onkeypress="return isTag(event);" onchange="return IncrmntConfrmCounterWrkExp();" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height: 30px; width: 81%; margin-top: 0%; float: left;"></asp:TextBox>
                        <%-- evm-0023 onclick="return IncrmntConfrmCounterWrkExp();"--%>
                        <input type="image" runat="server" id="Image15" onclick="return IncrmntConfrmCounterWrkExp();" class="add-on" onblur="return DateChkSearch()" src="/Images/Icons/CalandarIcon.png" style="height: 22px; width: 22px; margin-top: 0%;" />
                        <%--evm 0019 workexperience--%>

                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divDateOfLeavingWrkExp').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                    </div>


                </div>
                <div class="eachform" style="float: right;">
                    <h2>Designation*</h2>

                    <asp:TextBox ID="txtDesignationWrkExp" class="form1" runat="server" onkeypress="return isTag(event);" onchange="return IncrmntConfrmCounterWrkExp();" MaxLength="99" Height="30px" Style="height: 30px; width: 50%; resize: none; text-transform: uppercase; font-family: calibri; margin-right: 5%;"></asp:TextBox>

                </div>

                <div class="eachform" style="float: left;">
                    <h2>Take Home Salary / Month</h2>

                    <asp:TextBox ID="txtSalaryWrkExp" class="form1" runat="server" onkeypress="return isTag(event);" onchange="return IncrmntConfrmCounterWrkExp();" onkeydown="return isNumber(event);" onblur="NumChecking('cphMain_txtSalaryWrkExp');" MaxLength="16" Height="30px" Style="height: 30px; width: 50%; resize: none; text-transform: uppercase; font-family: calibri; margin-right: 5%;"></asp:TextBox>
                </div>
                <div class="eachform" style="float: right">
                    <h2>Address of last Employer*</h2>
                    <asp:TextBox ID="txtAddressOfEmployerWrkExp" class="form1" onkeypress="return isTagWithEnter(event);" onkeydown="textCounter(cphMain_txtAddressOfEmployerWrkExp, 499);" onblur="textCounter(cphMain_txtAddressOfEmployerWrkExp, 499);" onchange="return IncrmntConfrmCounterWrkExp();" runat="server" TextMode="MultiLine" MaxLength="499" Width="50%" Height="81px" Style="height: 81px; width: 50%; resize: none; font-family: calibri; margin-right: 5%;"></asp:TextBox>
                    <%--//emp17--%>
                </div>
                <div id="divFileUploader" class="eachform" style="height: 40px; margin-top: 2%; float: left; width: 51%; display: none">
                    <h2 style="padding-top: 0.4%; padding-left: 2%;">Choose CSV File*</h2>


                    <label id="lblFileUpload" for="cphMain_FileUploader" class="custom-file-upload" style="margin-left: 17.6%; color: black">
                        <img src="/../Images/Icons/cloud_upload.jpg" />Upload File </label>
                    <asp:FileUpload ID="FileUploader" class="imageUpload" onchange="FupSelectedFileName()" runat="server" Accept=".csv"
                        Style="display: none; padding-left: 24.5%;" />

                    <!--<asp:TextBox ID="TextBox1" Text="No File selected"  runat="server"></asp:TextBox>-->
                    <asp:Label ID="Label4" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
                </div>

                <div class="eachform" style="margin-top: 2%; margin-left: 17%;">
                    <div class="subform" style="width: 448px;">
                        <div class="form-group">

                            <asp:Button ID="btnUpdateWrkExp" runat="server" Style="display: none;" class="save" Text="Update" OnClick="btnUpdateWrkExp_Click" OnClientClick="return ValidateWrkExp(); " />
                            <asp:Button ID="btnAddWrkExp" runat="server" class="save" Text="Save" OnClick="btnAddWrkExp_Click" OnClientClick="return ValidateWrkExp();" />
                            <asp:Button ID="btnClearWrkExp" runat="server" Style="margin-left: 11px;" OnClientClick="return AlertClearAllWrkExp();" class="cancel" Text="Clear" />
                            <asp:Button ID="btnCancelWrkExp" runat="server" class="cancel" Style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCnclWrkExp();" />
                        </div>
                    </div>

                </div>
                <div id="Div13" class="Quacaption">
                    <%--//15emp17--%>
                    <asp:Label ID="label12" runat="server">List Work Experience</asp:Label>
                </div>
                <div id="divListWrkExp" class="table-responsive" runat="server" style="border: 1px solid; border-color: #428734; margin-top: 2%; padding: 14px; width: 100%; margin-left: -1.5%; font-family: Calibri">
                    <br />
                    <br />


                </div>


            </div>
            <%--End:Qualification:Work Experience--%>


            <%--Start:Qualification:Education--%>
            <div id="divEductn" style="border: .5px solid; border-color: #9ba48b; background-color: #f3f3f3; width: 96%; margin-top: 1%; padding: 2%; font-family: Calibri">
                <div id="divMessageAreaEdu" style="display: none; width: 84%; margin-left: 6%; margin-top: -1%;">
                    <img id="imgMessageAreaEdu" src="" />
                    <asp:Label ID="lblMessageAreaEdu" runat="server"></asp:Label>
                </div>
                <div id="divEduCaptn" class="Quacaption">
                    <asp:Label ID="lblEduCaptn" runat="server">Add Education</asp:Label>
                </div>
                <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="eachform" style="float: left;">
                            <h2>Type*</h2>

                            <asp:DropDownList ID="ddlEduType" class="form1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEduType_SelectedIndexChanged" onkeypress="return isTag(event)" Style="height: 30px; width: 55%; text-align: left; margin-right: 3%;">
                                <asp:ListItem Text="--Select Type--" Value="--Select Type--"></asp:ListItem>
                                <asp:ListItem Text="PG" Value="1"></asp:ListItem>
                                <asp:ListItem Text="UG" Value="2"></asp:ListItem>
                                <asp:ListItem Text="HSE" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Other" Value="4"></asp:ListItem>

                            </asp:DropDownList>

                        </div>

                        <div class="eachform" style="float: right;">
                            <h2>Qualification*</h2>

                            <asp:DropDownList ID="ddlEduQualification" class="form1" onchange="return IncrmntConfrmCounterEdu();" onkeypress="return isTag(event)" runat="server" Style="height: 30px; width: 55%; text-align: left; margin-right: 3%;"></asp:DropDownList>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="eachform" style="float: left; margin-bottom: 0%;">
                    <h2>Specialization</h2>
                    <asp:TextBox ID="txtEduSpecialization" class="form1" runat="server" onkeypress="return isTag(event)" onchange="return IncrmntConfrmCounterEdu();" MaxLength="50" Style="height: 30px; width: 51%; text-transform: uppercase; font-family: calibri; margin-right: 3%;"></asp:TextBox>
                </div>
                <div class="eachform" style="float: right;">
                    <h2>Institution Name & Place</h2>
                    <asp:TextBox ID="txtEduInstite" class="form1" runat="server" onkeypress="return isTag(event)" onchange="return IncrmntConfrmCounterEdu();" MaxLength="200" Style="width: 51%; margin-right: 3%; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                </div>


                <div class="eachform" style="float: left; margin-top: 2%;">
                    <h2>Percentage</h2>
                    <%--evm-0023 MaxLength="5"--%>
                    <asp:TextBox ID="txtEduPercentage" class="form1" runat="server" onkeypress="return isTag(event)" onchange="return IncrmntConfrmCounterEdu();" MaxLength="5" Style="text-transform: uppercase; font-family: calibri; margin-right: 3%; width: 51%;" onblur="return NumChecking('cphMain_txtEduPercentage');" OnKeydown="return isNumber(event);"></asp:TextBox>
                </div>
                <div class="eachform" style="float: right">
                    <h2>Year & Month Of Passing</h2>
                    <div id="divEduStrtDate" class="input-append date" style="float: right; width: 58%;">

                        <asp:DropDownList ID="ddlMonthEdu" Height="30px" Width="50%" onchange="return IncrmntConfrmCounterEdu();" class="form1" runat="server" Style="height: 30px; width: 50%; height: 30px; width: 48%; text-align: left; margin-left: 0%; float: left;"></asp:DropDownList>
                        <asp:DropDownList ID="ddlYearEdu" Height="30px" Width="50%" onchange="return IncrmntConfrmCounterEdu();" class="form1" runat="server" Style="height: 30px; width: 50%; height: 30px; width: 46%; text-align: left; margin-left: 0%; float: left;"></asp:DropDownList>

                        <asp:TextBox ID="txtEduStrtDate" class="form1" onkeypress="return isTag(event)" onchange="return IncrmntConfrmCounterEdu();" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="height: 30px; width: 77%; margin-top: 0%; float: left; display: none;"></asp:TextBox>

                        <input type="image" runat="server" id="Image16" class="add-on" src="/Images/Icons/CalandarIcon.png" style="height: 22px; width: 22px; margin-top: 0%; display: none" />


                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divEduStrtDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                    </div>
                </div>
                <div class="eachform" style="float: left;">
                    <h2> University Name</h2>
                    <asp:TextBox ID="txtEduDegree" class="form1" onkeypress="return isTag(event);" runat="server" onchange="return IncrmntConfrmCounterEdu();" MaxLength="200" Style="width: 51%; margin-right: 3%; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                </div>
                <div class="eachform" style="margin-top: 2%; margin-left: 29%;">
                    <div class="subform" style="width: 448px; margin-left: 11%">
                        <div class="form-group">

                            <asp:Button ID="BtnUpdateEdu" runat="server" Style="display: none;" class="save" Text="Update" OnClick="btnUpdateEdu_Click" OnClientClick="return ValidateEdu(); " />
                            <asp:Button ID="BtnAddEdu" runat="server" class="save" Text="Save" OnClick="btnAddEdu_Click" OnClientClick="return ValidateEdu();" />
                            <asp:Button ID="BtnClearEdu" runat="server" Style="margin-left: 11px;" OnClientClick="return AlertClearAllEdu();" class="cancel" Text="Clear" />
                            <asp:Button ID="ButtonCnclEdu" runat="server" class="cancel" Style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCnclEdu();" />
                        </div>
                    </div>

                </div>
                <div id="listedcn" class="Quacaption">
                    <%--//15emp17--%>
                    <asp:Label ID="label_list" runat="server">List Education</asp:Label>
                </div>

                <div id="divListEdu" class="table-responsive" runat="server" style="border: 1px solid; border-color: #428734; margin-top: 2%; padding: 14px; width: 100%; margin-left: -1.5%; font-family: Calibri">
                    <br />
                    <br />


                </div>

            </div>
            <asp:HiddenField ID="Hiddenddlselect" runat="server" />
            <script>
                function SuccessConfirmationEdu() {
                    document.getElementById('divMessageAreaEdu').style.display = "";
                    document.getElementById('imgMessageAreaEdu').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17
                    document.getElementById("<%=lblMessageAreaEdu.ClientID%>").innerHTML = "Education details inserted successfully.";
                        $('#divEductn input[type="text"]').val('');
                        document.getElementById("<%=ddlEduType.ClientID%>").value = "--Select Type--";
                        document.getElementById("<%=ddlEduQualification.ClientID%>").value = "--Select Course--";
                        document.getElementById("<%=ddlMonthEdu.ClientID%>").value = "--MONTH--";
                        document.getElementById("<%=ddlYearEdu.ClientID%>").value = "--YEAR--";

                        document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value = "Education";
                        tableClick('divTblid7', Tblid7);

                    }
                    function SuccessUpdationEdu() {
                        document.getElementById('divMessageAreaEdu').style.display = "";
                        document.getElementById('imgMessageAreaEdu').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17
                        document.getElementById("<%=lblMessageAreaEdu.ClientID%>").innerHTML = "Education details updated successfully.";
                        $('#divEductn input[type="text"]').val('');
                        document.getElementById("<%=ddlEduType.ClientID%>").value = "--Select Type--";
                        document.getElementById("<%=ddlEduQualification.ClientID%>").value = "--Select Course--";
                        document.getElementById("<%=ddlMonthEdu.ClientID%>").value = "--MONTH--";
                        document.getElementById("<%=ddlYearEdu.ClientID%>").value = "--YEAR--";

                        document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value = "Education";
                        tableClick('divTblid7', Tblid7);
                    }
                    function SuccessDeletionEdu() {
                        document.getElementById('divMessageAreaEdu').style.display = "";
                        document.getElementById('imgMessageAreaEdu').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17
                        document.getElementById("<%=lblMessageAreaEdu.ClientID%>").innerHTML = "Education details deleted successfully.";

                    }
                    function updateEduDtlById(Id, CandID) {
                        //  alert();
                        document.getElementById('divMessageAreaEdu').style.display = "none"; //evm-0023
                        document.getElementById("<%=ddlEduType.ClientID%>").style.borderColor = ""; //evm-0023
                        document.getElementById("<%=ddlEduQualification.ClientID%>").style.borderColor = ""; //evm-0023

                        document.getElementById("<%=ddlMonthEdu.ClientID%>").value = "--MONTH--";
                        document.getElementById("<%=ddlYearEdu.ClientID%>").value = "--YEAR--";
                        document.getElementById("<%=HiddenEductnDtlId.ClientID%>").value = Id;

                        var Details = PageMethods.ReadEduDtlById(Id, CandID, function (response) {
                          //  alert(response.EduType);
                            if (response.EduType != "") {
                              
                                document.getElementById("<%=ddlEduType.ClientID%>").value = response.EduType;
                            
                                document.getElementById("<%=Hiddenddlselect.ClientID%>").value = response.CourseID; 
                              //  __doPostBack('<%= ddlEduType.ClientID %>', '');
                               
                            }
                            if (response.CourseID != "") {
                                var ddlTestDropDownListXML = $noCon("#cphMain_ddlEduQualification");
                                ddlTestDropDownListXML.empty();
                                var OptionStart = $noCon("<option>--Select Course--</option>");
                                OptionStart.attr("value", 0);
                                ddlTestDropDownListXML.append(OptionStart);
                                //  alert(ddlTestDropDownListXML);
           
                                var tableName = "dtTableQualfTyp";
                              
                                ddlEmpdata = response.QulfctnLoad;
                
                  
                 
                  // Now find the Table from response and loop through each item (row).
                  $noCon(ddlEmpdata).find(tableName).each(function () {
                      // Get the OptionValue and OptionText Column values.
                      var OptionValue = $noCon(this).find('QUAL_COURSE_ID').text();
                      var OptionText = $noCon(this).find('COURSE').text();
                      // Create an Option for DropDownList.
                      var option = $noCon("<option>" + OptionText + "</option>");
                      option.attr("value", OptionValue);

                      ddlTestDropDownListXML.append(option);
                  });
                             }

                            document.getElementById("<%=txtEduInstite.ClientID%>").value = response.Institution;
                            document.getElementById("<%=txtEduSpecialization.ClientID%>").value = response.Specialization;
                            document.getElementById("<%=txtEduStrtDate.ClientID%>").value = response.PassingYear;
                            document.getElementById("<%=txtEduPercentage.ClientID%>").value = response.Percentage;

                            document.getElementById("<%=txtEduDegree.ClientID%>").value = response.Degree;
                            var textYear = response.Year;
                            // alert(textYear);
                            if (textYear != "") {
                                document.getElementById("<%=ddlYearEdu.ClientID%>").value = response.Year;
                            }
                            var textMnth = response.Month;
                       
                            if (textMnth != "") {

                                document.getElementById("<%=ddlMonthEdu.ClientID%>").value = response.Month;
                            }
                            //var textYear = response.Year;

                            // var ddlYearEdu = document.getElementById("<%=ddlYearEdu.ClientID%>");
                            // for (var i = 0; i < ddlYearEdu.options.length; i++) {
                            //   if (ddlYearEdu.options[i].text === textYear) {
                            //      ddlYearEdu.selectedIndex = i;
                            //break;
                            //  }
                            //  }
                            //  var textMnth = response.Month;
                            //  alert(textYear + textMnth);

                            //   var ddlMonthEdu = document.getElementById("<%=ddlMonthEdu.ClientID%>");
                            //   for (var i = 0; i < ddlMonthEdu.options.length; i++) {
                            //      if (ddlMonthEdu.options[i].text === textMnth) {
                            //  ddlMonthEdu.selectedIndex = i;
                            //          break;
                            //       }
                            //   }
                            setTimeout(QualfctnLoad(response.CourseID), 20);


                            document.getElementById("cphMain_BtnAddEdu").style.display = "none";
                            document.getElementById("cphMain_BtnClearEdu").style.display = "none";
                            document.getElementById("cphMain_BtnUpdateEdu").style.display = "block";
                            document.getElementById("cphMain_lblEduCaptn").innerText = "Edit Education";
                           // $(Window).scrollTop(0);    //15emp17
                            $(window).scrollTop(0);
                        });
                        return false;
                    }
                function delayddl(CourseID)
                {
                  //  __doPostBack('<%= ddlEduType.ClientID %>', '');
                    document.getElementById("<%=ddlEduQualification.ClientID%>").value = CourseID;
                }
                    function QualfctnLoad(CourseID) {
                        // alert();
                        if (CourseID != "") {
                            //  alert(CourseID+"ssss");
                            document.getElementById("<%=ddlEduQualification.ClientID%>").value = CourseID;
                        }
                    }

                    function deleteEduDtlById(Id, CandID) {

                        if (confirm("Do you want to cancel this Entry?")) {
                            var Details = PageMethods.deleteEduById(Id, CandID, function (response) {

                                document.getElementById("cphMain_divListEdu").innerHTML = response.strEduList;
                                SuccessDeletionEdu();
                                $p('#ReportTableEdu').DataTable({       //15emp17
                                    "pagingType": "full_numbers",
                                    "bSort": true


                                });
                            });

                            $ds = jQuery.noConflict();
                            $ds('#ReportTableEdu').DataTable({
                                "pagingType": "full_numbers",
                                "bSort": true


                            });


                        }
                        else {

                        }

                    }

                    function ValidateEdu() {
                        var ret = true;
                        // replacing < and > tags
                        var NameWithoutReplace = document.getElementById("<%=txtEduInstite.ClientID%>").value;
                          var replaceText1 = NameWithoutReplace.replace(/</g, "");
                          var replaceText2 = replaceText1.replace(/>/g, "");
                          document.getElementById("<%=txtEduInstite.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtEduSpecialization.ClientID%>").value;
                          replaceText1 = NameWithoutReplace.replace(/</g, "");
                          replaceText2 = replaceText1.replace(/>/g, "");
                          document.getElementById("<%=txtEduSpecialization.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtEduInstite.ClientID%>").value;
                          replaceText1 = NameWithoutReplace.replace(/</g, "");
                          replaceText2 = replaceText1.replace(/>/g, "");
                          document.getElementById("<%=txtEduInstite.ClientID%>").value = replaceText2;


            NameWithoutReplace = document.getElementById("<%=txtEduPercentage.ClientID%>").value;
                          replaceText1 = NameWithoutReplace.replace(/</g, "");
                          replaceText2 = replaceText1.replace(/>/g, "");
                          document.getElementById("<%=txtEduPercentage.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtEduDegree.ClientID%>").value;
                          replaceText1 = NameWithoutReplace.replace(/</g, "");
                          replaceText2 = replaceText1.replace(/>/g, "");
                          document.getElementById("<%=txtEduDegree.ClientID%>").value = replaceText2;

            var month = document.getElementById("<%=ddlMonthEdu.ClientID%>").value;
                          var year = document.getElementById("<%=ddlYearEdu.ClientID%>").value;

                          var Type = document.getElementById("<%=ddlEduType.ClientID%>").value;
                          var Course = document.getElementById("<%=ddlEduQualification.ClientID%>").value;
                          //  var startDate = document.getElementById("<%=txtEduStrtDate.ClientID%>").value.trim();   //15emp17
                          //  var arrDatePickerDate2 = startDate.split("-");
                          //  var convstartdate = new Date(arrDatePickerDate2[2], arrDatePickerDate2[1] - 1, arrDatePickerDate2[0]);

                          var cdate = new Date();
                          document.getElementById("<%=ddlEduType.ClientID%>").style.borderColor = "";
            document.getElementById('divMessageAreaEdu').style.display = "none";
            document.getElementById('imgMessageAreaEdu').src = "";
        


                          //Course
        
                          if (month != "--MONTH--")     //15emp17

                          {
                              if (year == "--YEAR--") {
                                  document.getElementById('divMessageAreaEdu').style.display = "";
                                  document.getElementById('imgMessageAreaEdu').src = "/Images/Icons/imgMsgAreaWarning.png";
                                  document.getElementById("<%=lblMessageAreaEdu.ClientID%>").innerHTML = "Enter year";
                                  document.getElementById("<%=ddlYearEdu.ClientID%>").style.borderColor = "Red";
                                  document.getElementById("<%=ddlYearEdu.ClientID%>").focus();

                                  ret = false;
                              }
                          }
                          else {

                              if (year != "--YEAR--") {
                                  document.getElementById('divMessageAreaEdu').style.display = "";
                                  document.getElementById('imgMessageAreaEdu').src = "/Images/Icons/imgMsgAreaWarning.png";
                                  document.getElementById("<%=lblMessageAreaEdu.ClientID%>").innerHTML = "Enter Month";
                                  document.getElementById("<%=ddlMonthEdu.ClientID%>").style.borderColor = "Red";
                                  document.getElementById("<%=ddlMonthEdu.ClientID%>").focus();

                                  ret = false;
                              }

                          }
                        if (Course == "--Select Course--" || Course == "") {
                            document.getElementById('divMessageAreaEdu').style.display = "";
                            document.getElementById('imgMessageAreaEdu').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageAreaEdu.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            document.getElementById("<%=ddlEduQualification.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=ddlEduQualification.ClientID%>").focus();
                            ret = false;
                        }
                        else {
                            
                            document.getElementById("<%=Hiddenddlselect.ClientID%>").value = Course;
                        }
                        if (Type == "--Select Type--") {
                            document.getElementById('divMessageAreaEdu').style.display = "";
                            document.getElementById('imgMessageAreaEdu').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageAreaEdu.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlEduType.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=ddlEduType.ClientID%>").focus();
                                ret = false;
                            }
                          return ret;
                      }
            </script>
            <%--End:Qualification:Education--%>


            <%--Start:Qualification:Language evm-0012--%>
            <div id="divLang" style="border: .5px solid; border-color: #9ba48b; background-color: #f3f3f3; width: 96%; margin-top: 1%; padding: 2%;">
                <div id="divMessageAreaLang" style="display: none; width: 84%; margin-left: 6%; margin-top: -1%;">
                    <img id="imgMessageAreaLang" src="" />
                    <asp:Label ID="lblMessageAreaLang" runat="server"></asp:Label>
                </div>
                <div id="divLangCaptn" class="Quacaption">
                    <asp:Label ID="lblLangCaptn" runat="server">Add Language</asp:Label>
                </div>
                <br />
                <div class="eachform" style="float: left;">
                    <h2>Language*</h2>

                    <asp:DropDownList ID="ddlQuLang" Height="30px" Width="54%" onkeypress="return isTag(event);" onchange="return IncrmntConfrmCounterLang();" class="form1" runat="server" Style="text-align: left;"></asp:DropDownList>

                </div>

                <div class="eachform" style="float: right;">

                    <h2>Skill*</h2>
                    <div id="divSkillCbx" style="width: 75%; height: 23px; border: 1px solid #cfcccc; margin-left: 26%;">
                        <div style="margin-left: 4%;">
                            <asp:CheckBox ID="CbxLangWrt" Text="" runat="server" onkeypress="return isTag(event);" onClick="IncrmntConfrmCounterLang();" class="form2" />
                            <h2 style="font-size: 15px; margin-top: 1.8%;">Write</h2>
                        </div>

                        <div style="margin-left: 24%;">
                            <asp:CheckBox ID="CbxLangRead" Text="" runat="server" onkeypress="return isTag(event);" onClick="IncrmntConfrmCounterLang();" class="form2" />
                            <h2 style="font-size: 15px; margin-top: 1.8%;">Read</h2>
                        </div>
                        <div style="margin-left: 43%;">
                            <asp:CheckBox ID="CbxLangSpk" Text="" runat="server" onkeypress="return isTag(event);" onClick="IncrmntConfrmCounterLang();" class="form2" />
                            <h2 style="font-size: 15px; margin-top: 3%;">Speak</h2>
                        </div>
                        <div style="margin-left: 3%;">
                            <asp:CheckBox ID="cbxLangMotherTongue" Text="" runat="server" onkeypress="return isTag(event);" onClick="IncrmntConfrmCounterLang();" class="form2" />
                            <h2 style="font-size: 15px; margin-top: 1.5%;">Mother tongue</h2>
                        </div>

                    </div>
                </div>

                <div class="eachform" style="margin-top: 2%; margin-left: 29%;">
                    <div class="subform" style="width: 448px; float: left; margin-left: 10.8%;">
                        <%-- 12emp17--%>

                        <div class="form-group">

                            <asp:Button ID="BtnLangUpdate" runat="server" Style="display: none;" class="save" Text="Update" OnClick="btnUpdLang_Click" OnClientClick="return ValidateLang(); " />
                            <asp:Button ID="BtnLangAdd" runat="server" class="save" Text="Save" OnClick="btnAddLang_Click" OnClientClick="return ValidateLang();" />
                            <asp:Button ID="BtnLangClear" runat="server" Style="margin-left: 11px;" OnClientClick="return AlertClearAllLang();" class="cancel" Text="Clear" />
                            <asp:Button ID="BtnLangCncl" runat="server" class="cancel" Style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCnclLang();" />
                        </div>
                    </div>

                </div>
                <br />
                <%--12emp17--%>
                <div id="listcaption" class="Quacaption" style="height: 41px;">
                    <asp:Label ID="Label1" runat="server">List Language</asp:Label>
                </div>
                <%--12emp17--%>

                <div id="divListLang" class="table-responsive" runat="server" style="border: 1px solid; font-family: Calibri; border-color: #428734; margin-top: 2%; padding: 14px; width: 100%; margin-left: -1.5%; font-family: Calibri">
                    <%--12emp17--%>
                    <br />
                    <br />


                </div>

            </div>
            <script>
                function SuccessConfirmationLang() {
                    document.getElementById('divMessageAreaLang').style.display = "";
                    document.getElementById('imgMessageAreaLang').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageAreaLang.ClientID%>").innerHTML = "Language details inserted successfully.";
                        $('#divLang').find('input[type=checkbox]:checked').removeAttr('checked');
                        document.getElementById("<%=ddlQuLang.ClientID%>").value = "--Select Language--";
                        document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value = "Language";
                        tableClick('divTblid7', Tblid7);
                    }
                    function SuccessUpdationLang() {
                        document.getElementById('divMessageAreaLang').style.display = "";
                        document.getElementById('imgMessageAreaLang').src = "/Images/Icons/imgMsgAreaInfo.png";
                        document.getElementById("<%=lblMessageAreaLang.ClientID%>").innerHTML = "Language details updated successfully.";
                        $('#divLang').find('input[type=checkbox]:checked').removeAttr('checked');

                        document.getElementById("<%=ddlQuLang.ClientID%>").value = "--Select Language--";
                        document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value = "Language";
                        tableClick('divTblid7', Tblid7);
                    }
                    function SuccessDeletionLang() {
                        document.getElementById('divMessageAreaLang').style.display = "";
                        document.getElementById("<%=lblMessageAreaLang.ClientID%>").innerHTML = "Language details deleted successfully.";

                    }
                    function updateLangDtlById(Id, CandID) {

                        $(window).scrollTop(0);//12emp17
                        document.getElementById("<%=ddlQuLang.ClientID%>").focus(); //12emp17
                        document.getElementById("<%=HiddenFieldLangDtlId.ClientID%>").value = Id;
                        var Details = PageMethods.updateLangDtlById(Id, CandID, function (response) {




                            if (response.LangSts == "1") {
                                document.getElementById("<%=ddlQuLang.ClientID%>").value = response.LangId;
        }
        else if (response.LangSts == "0") {
            var $Mo = jQuery.noConflict();
            var newOption = "<option value='" + response.LangId + "'>" + response.LangName + "</option>";

            $Mo('#<%=ddlQuLang.ClientID%>').append(newOption);
            //SORTING DDL
            var options = $Mo("#<%=ddlQuLang.ClientID%> option");                    // Collect options         
            options.detach().sort(function (a, b) {               // Detach from select, then Sort
                var at = $Mo(a).text();
                var bt = $Mo(b).text();
                return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
            });
            options.appendTo('#<%=ddlQuLang.ClientID%>');
            //document.getElementById("<%=ddlQuLang.ClientID%>").value = response.LangId;

        }
        if (response.Write == "1") {
            document.getElementById("<%=CbxLangWrt.ClientID%>").checked = true;
        }
        else {
            document.getElementById("<%=CbxLangWrt.ClientID%>").checked = false;
        }
        if (response.Read == "1") {
            document.getElementById("<%=CbxLangRead.ClientID%>").checked = true;
        }
        else {
            document.getElementById("<%=CbxLangRead.ClientID%>").checked = false;

        }

        if (response.Speak == "1") {
            document.getElementById("<%=CbxLangSpk.ClientID%>").checked = true;
        }
        else {
            document.getElementById("<%=CbxLangSpk.ClientID%>").checked = false;

        }
        if (response.MotherTongue == "1") {
            document.getElementById("<%=cbxLangMotherTongue.ClientID%>").checked = true;
        }
        else {
            document.getElementById("<%=cbxLangMotherTongue.ClientID%>").checked = false;

        }




        document.getElementById("cphMain_BtnLangAdd").style.display = "none";
        document.getElementById("cphMain_BtnLangClear").style.display = "none";
        document.getElementById("cphMain_BtnLangUpdate").style.display = "block";
        document.getElementById("cphMain_lblLangCaptn").innerText = "Edit Language";

    });
    return false;
}
function deleteLangDtlById(Id, CandID) {


    if (confirm("Do you want to cancel this entry?")) {
        var Details = PageMethods.deleteLangDtlById(Id, CandID, function (response) {

            document.getElementById("cphMain_divListLang").innerHTML = response.SklLangList;
            SuccessDeletionLang();
            $p('#ReportTableLang').DataTable({             //12emp17
                "pagingType": "full_numbers",
                "bSort": true


            });                                              //12emp17
        });
    }
    else {

    }


}

function ValidateLang() {
    var ret = true;



    var language = document.getElementById("<%=ddlQuLang.ClientID%>").value;

            document.getElementById("<%=ddlQuLang.ClientID%>").style.borderColor = "";
            document.getElementById("divSkillCbx").style.borderColor = "#cfcccc";
            document.getElementById('divMessageAreaLang').style.display = "none";
            document.getElementById('imgMessageAreaLang').src = "";





            if (document.getElementById("<%=CbxLangWrt.ClientID%>").checked == false && document.getElementById("<%=CbxLangRead.ClientID%>").checked == false && document.getElementById("<%=CbxLangSpk.ClientID%>").checked == false && document.getElementById("<%=cbxLangMotherTongue.ClientID%>").checked == false) {
                document.getElementById('divMessageAreaLang').style.display = "";
                document.getElementById('imgMessageAreaLang').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaLang.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("divSkillCbx").style.borderColor = "Red";
                document.getElementById("<%=CbxLangWrt.ClientID%>").focus();
                ret = false;
            }
            if (language == "--Select Language--") {
                document.getElementById('divMessageAreaLang').style.display = "";
                document.getElementById('imgMessageAreaLang').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaLang.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            document.getElementById("<%=ddlQuLang.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=ddlQuLang.ClientID%>").focus();
                            ret = false;
                        }
                        return ret;
                    }
            </script>
            <%--End:Qualification:Language--%>



            <%--Qualification --%>
        </div>
        <%--evm-0012   ----------------------------------------------  Qualification start------------------------------------------------------------------------------%>













        <%-- new --%>
        <style>
            .subform label {
                float: right;
                color: #697259;
                font-size: 13pt;
                font-family: Calibri;
                cursor: pointer;
            }
        </style>
        <style>
            #cphMain_divAdd {
                position: fixed;
                right: 4%;
                /*padding-left: 76%;*/
            }
        </style>

        <style>
            #cphMain_divLicenseType {
                width: 69%;
                margin-top: 1%;
                height: 98%;
                border: 0.5px solid;
                border-color: #9BE3B1;
                overflow: auto;
            }

            .divImageLicenseType {
                /*height: 70px;*/
                border: 1px solid;
                border-color: #005C56;
                margin: 3px;
                font-size: 15px;
                min-width: 32%;
                max-width: 98.5%;
                overflow-wrap: break-word;
            }

                .divImageLicenseType:hover {
                    background-color: #9BE3B1;
                }
        </style>
        <script type="text/javascript">
            var $GoTop = jQuery.noConflict();
            $GoTop(function () {
                $GoTop('#scrollToTop').bind("click", function () {
                    $GoTop('html, body').animate({ scrollTop: 0 }, 500);

                    return false;
                });
            });
        </script>
        <%--------------------------------End for error PersonalEmployre--------------------------%>





        <style>
            #ReportTableDep_filter input {
                margin-bottom: 2%;
            }

            #ReportTable_filter input {
                height: 17px;
            }

            .dataTables_filter input {
                height: 13px;
            }

            #ReportTableLang_length { /*12emp17 class creatd*/
                margin-bottom: 5px;
            }

            #ReportTableEdu_length { /*15emp17 class creatd*/
                margin-bottom: 5px;
            }

            #ReportTableImgrtn_length { /*2emp17 class creatd*/
                margin-bottom: 5px;
            }

            .dataTables_filter input { /*3emp17 obj creatd*/
                width: 200px;
                height: 16px;
            }

            a {
                color: #095a35;
                text-decoration: none;
            }

            #ReportTableSkCer {
                margin-top: 1%;
                float: left;
            }

            #ReportTableAllow {
                margin-top: .7%;
                float: left;
            }

            #ReportTableDedtn {
                margin-top: .7%;
                float: left;
            }

            #ReportTableforproject {
                margin-top: .7%;
                float: left;
            }

            #ReportTableWrkExp {
                margin-top: .7%;
                float: left;
            }
        </style>


    </div>



    <script>

        //personaldetails

        var confirmboxPD = 0;

        function IncrmntConfrmCounterpd() {
            confirmboxPD++;
        }
        function ConfirmMessagePDCancel() {
            if (confirmboxPD > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                return false;
            }
        }

    </script>
    <%--Contact Details 08-05--%>
    <script>

        var confirmboxcd = 0;

        function IncrmntConfrmCountercd() {
            confirmboxcd++;
        }
        function ConfirmMessageCDCancel() {
            if (confirmboxcd > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                return false;
            }
        }
        function AlertClearAllCD() {
            if (confirmboxCD > 0) {
                if (confirm("Are you sure you want clear all data in this page?")) {
                    $('#divTblid2').find('input[type=checkbox]:checked').removeAttr('checked');
                    $('#divTblid2 input[type="text"]').val('');
                    $('#divTblid2 textarea[type="multiline"]').val('');
                    document.getElementById("<%=txtPermAddrsSCD.ClientID%>").value = "";
                         document.getElementById("<%=txtEmrgCntcSCD.ClientID%>").value = "";
                         document.getElementById("<%=ddlLoctnSCD.ClientID%>").value = "--SELECT LOCATION--";
                         document.getElementById("<%=ddlRcrtdSCD.ClientID%>").value = "--SELECT REFERENCE--";
                         document.getElementById("<%=ddlSpnsrSCD.ClientID%>").value = "--SELECT SPONSER--";

                         //document.getElementById("<%%>").value = "";
                         tableClick('divTblid2', Tblid2);
                         return false;
                     }
                     else {
                         return false;
                     }
                 }
                 else {
                     $('#divTblid2').find('input[type=checkbox]:checked').removeAttr('checked');
                     $('#divTblid2 input[type="text"]').val('');
                     $('#divTblid2 textarea[type="multiline"]').val('');
                     document.getElementById("<%=txtPermAddrsSCD.ClientID%>").value = "";
                     document.getElementById("<%=txtEmrgCntcSCD.ClientID%>").value = "";
                     document.getElementById("<%=ddlLoctnSCD.ClientID%>").value = "--SELECT LOCATION--";
                     document.getElementById("<%=ddlRcrtdSCD.ClientID%>").value = "--SELECT REFERENCE--";
                     document.getElementById("<%=ddlSpnsrSCD.ClientID%>").value = "--SELECT SPONSER--";

                     //document.getElementById("<%%>").value = "";
                     tableClick('divTblid2', Tblid2);
                     return false;
                     return false;
                 }
             }
    </script>
    <script>

        function ValidateAll() {
            // alert('validity');
            //var countValid = 0;
            //if (BssicInfoValidation() == false) {
            //    countValid++;
            //}
            //if (validateSCD() == false) {
            //    countValid++;
            //}
            //if (ValidateDepnt() == false) {
            //    countValid++;
            //}
            //if (Validateimmigration() == false) {
            //    countValid++;
            //}
            //if (ValidateOtherDtl() == false) {
            //    countValid++;
            //}

            //if (ValidateWrkExp() == false) {
            //    countValid++;
            //} if (ValidateEdu() == false) {
            //    countValid++;
            //} if (ValidateLang() == false) {
            //    countValid++;
            //}
            //if (countValid != 0) {
            //    return false;
            //}
            //else {
            //    return true;
            //}
        }
        function BssicInfoValidation(Mode) {
            var LoginMust = false;
            var AutoWrkShopMust = false;
            var ret = true;

            document.getElementById('divMessageAreaMain').style.display = "none";
            document.getElementById("<%=txtName.ClientID%>").style.borderColor = "";
               document.getElementById("<%=txtloccontact.ClientID%>").style.borderColor = "";
               document.getElementById("<%=txtUsrMob.ClientID%>").style.borderColor = "";

               document.getElementById("<%=ddlNationality.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtUsrEmail.ClientID%>").style.borderColor = "";

            document.getElementById("<%=TxtFirstName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=TxtLastName.ClientID%>").style.borderColor = "";

              document.getElementById('ErrorMsgUsrEmail').style.display = "none";  //evm-0023
              document.getElementById('ErrorMsgUsrMob').style.display = "none";  //evm-0023
              document.getElementById('ErrorMsgUsrMob1').style.display = "none";  //evm-0023

               var FrstName = document.getElementById("<%=txtName.ClientID%>").value.trim();

            var FirstName = document.getElementById("<%=TxtFirstName.ClientID%>").value.trim();
            var LastName = document.getElementById("<%=TxtLastName.ClientID%>").value.trim();

            var Mobile2 = document.getElementById("<%=txtloccontact.ClientID%>").value.trim(); //evm-0023
               var Mobile = document.getElementById("<%=txtUsrMob.ClientID%>").value.trim();
               // document.getElementById('ErrorMsgUsrMob').style.visibility = "hidden";
               var Email = document.getElementById("<%=txtUsrEmail.ClientID%>").value;
               //    document.getElementById('ErrorMsgUsrEmail').style.visibility = "hidden";

               var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;

               var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
               var minNumberofChars = 6;
               var maxNumberofChars = 16;
               //var regularExpression = /(?=.*\d)(?=.*[~!@#$%^&*])(?=.*[a-z])|(?=.*[A-Z])[0-9!@#$%^&*].{6,16}/;
               var regularExpression = /(?=.*\d)(?=.*[~!@#$%^&*])(?=.*[A-Za-z]).{6,16}/;
               //var regularExpression = /(?=.*\d)(?=.*[~!@#$%^&*])(?=.*[a-z])|(?=.*[A-Z])[0-9!@#$%^&*].{6,16}/
               var country = document.getElementById("<%=ddlNationality.ClientID%>").value;


               if (document.getElementById("<%=HiddenStaffHR.ClientID%>").value == "HR") {
                   //  alert(document.getElementById("<%=HiddenStaffHR.ClientID%>").value);
                   document.getElementById("<%=ddlUsrDsgn.ClientID%>").style.borderColor = "";

                   var desgntn = document.getElementById("<%=ddlUsrDsgn.ClientID%>").value.trim();

                   var division = document.getElementById("<%=ddlDivison.ClientID%>").value.trim();


                   document.getElementById("<%=ddlDivison.ClientID%>").style.borderColor = "";

                   if (Mode == "add") {
                       var candidate = document.getElementById("<%=ddlCandidateName.ClientID%>").value.trim();
                       if (candidate == "--SELECT CANDIDATE--") {
                           document.getElementById("<%=ddlCandidateName.ClientID%>").style.borderColor = "red";
                           document.getElementById('divMessageAreaMain').style.display = "block";
                           document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                           document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                           ret = false;
                           document.getElementById("<%=ddlCandidateName.ClientID%>").focus();

                       }
                   }
                   if (country == "--SELECT NATIONALITY--") {
                       document.getElementById("<%=ddlNationality.ClientID%>").style.borderColor = "red";
                       document.getElementById('divMessageAreaMain').style.display = "block";
                       document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                       document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                   ret = false;
                   document.getElementById("<%=ddlNationality.ClientID%>").focus();

           

               }
               if (division == "--SELECT DIVISION--") {
                   document.getElementById("<%=ddlDivison.ClientID%>").style.borderColor = "red";
                       document.getElementById('divMessageAreaMain').style.display = "block";
                       document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                       document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                   ret = false;
                   document.getElementById("<%=ddlDivison.ClientID%>").focus();

                   }
                   if (desgntn == "--SELECT DESIGNATION--") {
                       document.getElementById("<%=ddlUsrDsgn.ClientID%>").style.borderColor = "red";
                       document.getElementById('divMessageAreaMain').style.display = "block";
                       document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                       document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                       ret = false;
                       document.getElementById("<%=ddlUsrDsgn.ClientID%>").focus();

                   }


                   if (Mobile.length != 0) {
                       
                       if (!mobileregular.test(Mobile)) {
                           
                           document.getElementById("<%=txtUsrMob.ClientID%>").focus();
                           document.getElementById("<%=txtUsrMob.ClientID%>").style.borderColor = "Red";

                           document.getElementById('divMessageAreaMain').style.display = "block";
                           document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                           document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                     
                           

                           // document.getElementById('ErrorMsgMob').innerHTML = "Inavalid Mobile Number";
                           var OrgMobileFocus = document.getElementById("<%=txtUsrMob.ClientID%>").focus();
                           ret = false;
                       }
                   }
                   if (Email != "") {
                       if ((!filter.test(Email)) && (Email != "")) {

                           document.getElementById("<%=txtUsrEmail.ClientID%>").focus();
                           document.getElementById("<%=txtUsrEmail.ClientID%>").style.borderColor = "Red";

                           document.getElementById('divMessageAreaMain').style.display = "block";
                           document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                           document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                           document.getElementById('ErrorMsgUsrEmail').style.display = "";

                          // ErrorMsgUsrEmail
                           var OrgMobileFocus = document.getElementById("<%=txtUsrEmail.ClientID%>").focus();
                           ret = false;
                       }
                   }


                   if (Email == "") {
                       document.getElementById("<%=txtUsrEmail.ClientID%>").style.borderColor = "red";
                       document.getElementById('divMessageAreaMain').style.display = "block";
                       document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                       document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                       ret = false;
                       document.getElementById("<%=txtUsrEmail.ClientID%>").focus();

                   }
                   if (LastName == "") {
                       document.getElementById("<%=TxtLastName.ClientID%>").style.borderColor = "red";
                             document.getElementById('divMessageAreaMain').style.display = "block";
                             document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                             document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                             ret = false;
                             document.getElementById("<%=TxtLastName.ClientID%>").focus();
                   }
                   if (FirstName == "") {
                       document.getElementById("<%=TxtFirstName.ClientID%>").style.borderColor = "red";
                           document.getElementById('divMessageAreaMain').style.display = "block";
                           document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                           document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                       ret = false;
                       document.getElementById("<%=TxtFirstName.ClientID%>").focus();
                   }
                   
             
                   if (FrstName == "") {
                       document.getElementById("<%=txtName.ClientID%>").style.borderColor = "red";
                       document.getElementById('divMessageAreaMain').style.display = "block";
                       document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                       document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                       ret = false;
                       document.getElementById("<%=txtName.ClientID%>").focus();
                   }


               }


               else {




                   if (Mobile.length != 0) {
                       if (!mobileregular.test(Mobile)) {
                           document.getElementById("<%=txtUsrMob.ClientID%>").focus();
                           document.getElementById("<%=txtUsrMob.ClientID%>").style.borderColor = "Red";

                           document.getElementById('divMessageAreaMain').style.display = "block";
                           document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                           document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            document.getElementById('ErrorMsgUsrMob').style.display = ""; //evm-0023
                           // document.getElementById('ErrorMsgMob').innerHTML = "Inavalid Mobile Number"; 
                           var OrgMobileFocus = document.getElementById("<%=txtUsrMob.ClientID%>").focus();
                           ret = false;
                       }
                   }


                   //evm-0023 start
                   if (Mobile2.length != 0) {
                    
                       if (!mobileregular.test(Mobile2)) {
                           document.getElementById("<%=TextPhn2.ClientID%>").focus();

                    document.getElementById("<%=txtloccontact.ClientID%>").style.borderColor = "Red";
                           document.getElementById('divMessageAreaMain').style.display = "block";
                    document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                           document.getElementById('ErrorMsgUsrMob1').style.display = ""; //evm-0023
                    var OrgMobileFocus = document.getElementById("<%=TextPhn2.ClientID%>").focus();
                    ret = false;
                }
                   }
                   //evm-0023 end



                   if (Email != "") {
                       if ((!filter.test(Email)) && (Email != "")) {

                           document.getElementById("<%=txtUsrEmail.ClientID%>").focus();
                           document.getElementById("<%=txtUsrEmail.ClientID%>").style.borderColor = "Red";

                           document.getElementById('divMessageAreaMain').style.display = "block";
                           document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                           document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                           document.getElementById('ErrorMsgUsrEmail').style.display = "";

              document.getElementById("<%=txtUsrEmail.ClientID%>").focus();
                           ret = false;
                       }
                   }
                   if (Email == "") {
                       document.getElementById("<%=txtUsrEmail.ClientID%>").style.borderColor = "red";
                         document.getElementById('divMessageAreaMain').style.display = "block";
                         document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                         document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                       ret = false;
                       document.getElementById("<%=txtUsrEmail.ClientID%>").focus();


                   }
                   if (country == "--SELECT NATIONALITY--") //emp17
                   {
                       document.getElementById("<%=ddlNationality.ClientID%>").style.borderColor = "red";
                       document.getElementById('divMessageAreaMain').style.display = "block";
                       document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                       document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                       ret = false;

                   document.getElementById("<%=ddlNationality.ClientID%>").focus();

                   }

                   if (LastName == "") {
                       document.getElementById("<%=TxtLastName.ClientID%>").style.borderColor = "red";
                           document.getElementById('divMessageAreaMain').style.display = "block";
                           document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                           document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                             ret = false;
                             document.getElementById("<%=TxtLastName.ClientID%>").focus();
                         }
                         if (FirstName == "") {
                             document.getElementById("<%=TxtFirstName.ClientID%>").style.borderColor = "red";
                       document.getElementById('divMessageAreaMain').style.display = "block";
                       document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                       document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                           ret = false;
                           document.getElementById("<%=TxtFirstName.ClientID%>").focus();
                   }

                   if (FrstName == "") {
                       document.getElementById("<%=txtName.ClientID%>").style.borderColor = "red";
                       document.getElementById('divMessageAreaMain').style.display = "block";
                       document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                       document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                       ret = false;
                       document.getElementById("<%=txtName.ClientID%>").focus();


                   }
                   //   alert(candidate);
                   if (candidate == "--SELECT CANDIDATE--") {
                       document.getElementById("<%=ddlCandidateName.ClientID%>").style.borderColor = "red";
                       document.getElementById('divMessageAreaMain').style.display = "block";
                       document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                       document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                       ret = false;
                       document.getElementById("<%=ddlCandidateName.ClientID%>").focus();

                   }


               }


               return ret;
           }



    </script>
    <script>

        //emp-0023 isTagEnter fn
        function isTagEnter(evt) {
            document.getElementById('divMessageArea').style.display = "none";          

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62 || keyCodes == 13) {
                ret = false;
            }
            return ret;
        }

        function RemoveTag(obj) {
            var txt = document.getElementById(obj).value;
            var replaceText1 = txt.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(obj).value = replaceText2;

        }

        function IsEnter(evt) {
        
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;

            if (charCode == 13) {
                ret = false;
            }

            return ret;
        }

        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }

        function isTag(evt) {
            IncrmntConfrmCounter();
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
        function isTagWithEnter(evt) {
            IncrmntConfrmCounter();
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;


            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }

            return ret;
        }
        function isNumber(evt) {


            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
          
            //enter
            if (keyCodes == 110 || keyCodes == 190) {
                return true;
            }
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
                //left arrow key,right arrow key,home,end ,delete,UP ARROW ,DOWN ARROW
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

        function BlurNotNumber(obj) {
            var txt = document.getElementById(obj).value;

            if (txt != "") {

                if (isNaN(txt)) {
                    document.getElementById(obj).value = "";
                    document.getElementById(obj).focus();
                    return false;

                }


            }
        }
    </script>
    <script>
        function ConfirmCnclimig() {
            if (confirmboxImig > 0) {
                if (confirm("Are you sure you want to cancel this page?")) {
                    window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {

                window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                return false;
            }
        } var confirmboxImig = 0;
        function IncrmntConfrmCounterImig() {

            confirmboxImig++;
        }
        function AlertClearAllImmig() {
            if (confirmboxImig > 0) {
                if (confirm("Are you sure you want clear all data in this page?")) {
                    document.getElementById("<%=Ddlvisatype.ClientID%>").value = "--Select Visa Type--";

                    document.getElementById("<%=txtVisaExpDate.ClientID%>").value = "";
                    //  document.getElementById("<%=Ddlvisatype.ClientID%>").value = "--Select Country--";

                    document.getElementById("<%=TextVisa.ClientID%>").value = "";
                    document.getElementById("<%=TextPass.ClientID%>").value = "";

                    document.getElementById("<%=txtPassExpDate.ClientID%>").value = "";
                    document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";


                    //tableClick('divTblid4', Tblid4);
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                document.getElementById("<%=Ddlvisatype.ClientID%>").value = "--Select Visa Type--";

                document.getElementById("<%=txtVisaExpDate.ClientID%>").value = "";
                //  document.getElementById("<%=Ddlvisatype.ClientID%>").value = "--Select Country--";

                document.getElementById("<%=TextVisa.ClientID%>").value = "";
                document.getElementById("<%=TextPass.ClientID%>").value = "";

                document.getElementById("<%=txtPassExpDate.ClientID%>").value = "";
                document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";

                //tableClick('divTblid4', Tblid4);
                return false;
            }
        }

    </script>
    <style>
        .open > .dropdown-menu {
            display: none;
        }
    </style>
    <script>
        function ConfirmMessage() {
            //alert(confirmboxother);confirmboxWrkExp = 0;
            if (confirmboxother > 0 || confirmboxDep > 0 || confirmboxCD > 0 || confirmboxPD > 0 || confirmboxImig > 0 || confirmboxEdu > 0 || confirmboxLang > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else
                window.location.href = "/Hcm/Hcm_Master/gen_Candidate_Login/gen_Candidate_Login.aspx";

        }


    </script>

    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>
    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        function SuccessConfirmationPD() {
            document.getElementById('divMessageAreaMain').style.display = "";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Details inserted successfully.";   //EMP17
            document.getElementById("<%=txtName.ClientID%>").focus();
            // MarrgdtlsDepClear();
            tableClick('divTblid8', Tblid8);

        } function SuccessUpdationPD() {
            document.getElementById('divMessageAreaMain').style.display = "";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Details updated successfully.";//EMP17
            document.getElementById("<%=txtName.ClientID%>").focus();
            tableClick('divTblid8', Tblid8);
        }
        function SuccessUpdationOth() {
            document.getElementById('divMessageAreaPD').style.display = "";
            document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = "Details updated successfully.";//EMP17
            document.getElementById("<%=txtName.ClientID%>").focus();
            tableClick('divTblid1', Tblid1);
        } function SuccessConfirmationOth() {
            document.getElementById('divMessageAreaPD').style.display = "";
            document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = "Details inserted successfully.";   //EMP17
            document.getElementById("<%=txtName.ClientID%>").focus();
            //  MarrgdtlsDepClear();
            tableClick('divTblid1', Tblid1);

        }

        function SuccessConfirmationMrg() {
            document.getElementById('divMessageAreaDpnt').style.display = "";
            document.getElementById('imgMessageAreaDpnt').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaDpnt.ClientID%>").innerHTML = "Family details inserted successfully.";
              //MarrgdtlsDepClear();
              tableClick('divTblid3', Tblid3);
          }
          function SuccessUpdationMrg() {
              document.getElementById('divMessageAreaDpnt').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
              document.getElementById("<%=lblMessageAreaDpnt.ClientID%>").innerHTML = "Family details updated successfully.";
              tableClick('divTblid3', Tblid3);
          }
          function SuccessConfirmationDepnt() {
              document.getElementById('divMessageAreaDpnt').style.display = "";
              document.getElementById('imgMessageAreaDpnt').src = "/Images/Icons/imgMsgAreaInfo.png";
              document.getElementById("<%=lblMessageAreaDpnt.ClientID%>").innerHTML = "Dependent details inserted successfully.";

            DepClear();
            tableClick('divTblid3', Tblid3);
        }
        function SuccessUpdationDepnt() {
            document.getElementById('divMessageAreaDpnt').style.display = "";
            document.getElementById('imgMessageAreaDpnt').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaDpnt.ClientID%>").innerHTML = "Dependent details updated successfully.";
            DepClear();
            document.getElementById("cphMain_btnUpdateDepnt").style.display = "none";
            document.getElementById("cphMain_btnAddDepnt").style.display = "";


            tableClick('divTblid3', Tblid3);
        }
        function SuccessDeletionDepnt() {


            document.getElementById('divMessageAreaDpnt').style.display = "";
            document.getElementById('imgMessageAreaDpnt').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaDpnt.ClientID%>").innerHTML = "Dependent details deleted successfully.";

            DepClear();
            //  tableClick('divTblid3', Tblid3);

        }
        function DepClear() {

            document.getElementById("<%=txtDepndtNameFM.ClientID%>").value = "";
            document.getElementById("<%=ddlReltnshpFM.ClientID%>").selectedIndex = 0;
            document.getElementById("<%=txtOccptnFM.ClientID%>").value = "";
            document.getElementById("<%=txtAgeFM.ClientID%>").value = "";


        }
        function SuccessConfirmationCD() {
            document.getElementById('divMessageAreaCD').style.display = "";
            document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Contact details inserted successfully.";
            tableClick('divTblid2', Tblid2);


        }
        function SuccessUpdationCD() {
            document.getElementById('divMessageAreaCD').style.display = "";
            document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Contact details updated successfully.";
            tableClick('divTblid2', Tblid2);
        }
        function immigrationSuccessDuplicationSave() { //3emp17
            document.getElementById('divMessageAreaforimig').style.display = "";
            document.getElementById('imgMessageAreaforimig').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Duplication error.Number can't be duplicated.";
            document.getElementById('cphMain_Textnumber').focus();
            document.getElementById('cphMain_Textnumber').style.borderColor = "red";

            tableClick('divTblid4', Tblid4);
            document.getElementById('cphMain_Textnumber').focus();
            if (document.getElementById('cphMain_RadioButtonDocList_1').checked == true) {
                document.getElementById("Divvisatype").style.display = "";
            }
        }
        function ImigSuccessUpdation() {
            document.getElementById('divMessageAreaforimig').style.display = "";
            document.getElementById('imgMessageAreaforimig').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17
            document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Immigration details updated successfully.";
            document.getElementById("<%=Ddlvisatype.ClientID%>").focus();
            document.getElementById("<%=Ddlvisatype.ClientID%>").value = "--Select Visa Type--";

            document.getElementById("<%=txtVisaExpDate.ClientID%>").value = "";
            //  document.getElementById("<%=Ddlvisatype.ClientID%>").value = "--Select Country--";

            document.getElementById("<%=TextVisa.ClientID%>").value = "";
            document.getElementById("<%=TextPass.ClientID%>").value = "";

            document.getElementById("<%=txtPassExpDate.ClientID%>").value = "";
              tableClick('divTblid4', Tblid4);
        }
        function ImigSuccessCancelation() {
            document.getElementById('divMessageAreaforimig').style.display = "";
            document.getElementById('imgMessageAreaforimig').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Immigration details cancelled successfully.";
            document.getElementById("<%=Ddlvisatype.ClientID%>").focus();
            //   tableClick('divTblid4', Tblid4);
        }
        function SuccessConfirmationWrkExp() {
            document.getElementById('divMessageAreaWrkExp').style.display = "";
            document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17

            document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "Work experience details inserted successfully.";

          document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value = "Work";
          $('#divWorkExp input[type="text"]').val('');
          document.getElementById("<%=txtNameOfEmployerWrkExp.ClientID%>").value = "";
          document.getElementById("<%=txtAddressOfEmployerWrkExp.ClientID%>").value = "";
          document.getElementById("<%=txtDateOfJoiningWrkExp.ClientID%>").value = "";
          document.getElementById("<%=txtWorkExpYearsWrkExp.ClientID%>").value = "";
          document.getElementById("<%=txtDateOfLeavingWrkExp.ClientID%>").value = "";
          document.getElementById("<%=txtDesignationWrkExp.ClientID%>").value = "";
          document.getElementById("<%=txtSalaryWrkExp.ClientID%>").value = "";

          tableClick('divTblid7', Tblid7);

      }

      function ImigSuccessConfirmation() {
          document.getElementById('divMessageAreaforimig').style.display = "";

          document.getElementById('imgMessageAreaforimig').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17
          document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Immigration details inserted successfully.";
          document.getElementById("<%=Ddlvisatype.ClientID%>").value = "--Select Visa Type--";

          document.getElementById("<%=txtVisaExpDate.ClientID%>").value = "";
          //  document.getElementById("<%=Ddlvisatype.ClientID%>").value = "--Select Country--";

          document.getElementById("<%=TextVisa.ClientID%>").value = "";
          document.getElementById("<%=TextPass.ClientID%>").value = "";

          document.getElementById("<%=txtPassExpDate.ClientID%>").value = "";
          document.getElementById('divMessageAreaforimig').style.display = "";
          document.getElementById('imgMessageAreaforimig').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17
          document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Immigration details inserted successfully.";
            document.getElementById("<%=Ddlvisatype.ClientID%>").focus();
          tableClick('divTblid4', Tblid4);
      }

    </script>
    <style>
        table.dataTable.no-footer {
            border-bottom: 1px solid #c9c9c9;
        }
    </style>
</asp:Content>



