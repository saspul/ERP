<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/MasterPage/MasterPageCompzit_Hcm.master" EnableEventValidation="false" CodeFile="gen_Emply_Personal_Informn.aspx.cs" Inherits="Master_gen__Emply_Personal__Informn_gen__Emply_Personal__Informn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="../../JavaScript/jquery-1.8.3.min.js"></script>
    <%-- /*--------------------------------------------------for modal Cancel Reason------------------------------------------------------*/--%>
    <style>
         .modalCancelView {
             display: none; /* Hidden by default */
             position: fixed; /* Stay in place */
             z-index: 30; /* Sit on top */
             padding-top: 0%; /* Location of the box */
             left: 23%;
             top: 13%;
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
         .modal-headerCancelView {
    padding: 1% 1%;
    background-color: #91a172;
    color: white;
}
         .modal-footerCancelView {
             padding: 2% 1%;
           background-color: #91a172;
             color: white;
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


    
          <script src="/js/jQuery/jquery-2.2.3.min.js"></script>  
       <script src="/js/jQueryUI/jquery-ui.min.js"></script>
     <script type="text/javascript">





         var $nooC = jQuery.noConflict();

         $nooC(function () {

             $nooC('#dialog_simple').dialog({
                 autoOpen: false,
                 width: 1000,
                 resizable: false,
                 modal: true,
                 title: "WELFARE SERVICE",

             });
         });
    </script>
    <style>
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

        #divMessageAreaRS {
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

        /*evm-0023-20-2*/
          #divMessageAreaSalaryAllwc {
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

          #divMessageAreaSalaryDedctn {
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
            margin-left: 17.5%;
            max-height: 220px;
            margin-top: 2%;
            border: 1px solid #b7b0b0;
            font-weight: bold;
            font-size: 15px;
            color: #4b7206;
        }

        #divDpartmnt {
            text-align: left;
            overflow: auto;
            margin-left: 17.5%;
            max-height: 220px;
            font-family: Calibri;
            background: #f3ffef;
            font-weight: bold;
            font-size: 15px;
            color: #4b7206;
            padding: 0px 19px 0px 0px;
            border: 1px solid #b7b0b0;
        }
           /*#cphMain_divReport1 {
            text-align: left;
            overflow: auto;
            margin-left: 17.5%;
            max-height: 220px;
            font-family: Calibri;
            background: #eef9eb;
            font-weight: bold;
            font-size: 15px;
            
            padding: 0px 19px 0px 0px;
            /*border: 1px solid #b7b0b0;*/
        /*}*/

        #divDivision {
            text-align: left;
            overflow: auto;
            margin-left: 17.5%;
            max-height: 220px;
            font-family: Calibri;
            background: #f3ffef;
            font-weight: bold;
            font-size: 15px;
            color: #4b7206;
            padding: 0px 19px 0px 0px;
            border: 1px solid #b7b0b0;
        }
        /*//0013*/
        #userRolTre {
            text-align: left;
            overflow: auto;
            margin-left: 17.5%;
            max-height: 220px;
            font-family: Calibri;
            background: #f3ffef;
            font-weight: bold;
            font-size: 15px;
            color: #4b7206;
            padding: 0px 19px 0px 0px;
            border: 1px solid #b7b0b0;
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
            margin-left: 17.5%;
            max-height: 220px;
            font-family: Calibri;
            background: #f3ffef;
            font-weight: bold;
            font-size: 15px;
            color: #4b7206;
            padding: 0px 19px 0px 0px;
            border: 1px solid #b7b0b0;
        }
         #cphMain_divAcsBU {
            text-align: left;
            overflow: auto;
            margin-left: 17.5%;
            max-height: 220px;
            font-family: Calibri;
            background: #f3ffef;
            font-weight: bold;
            font-size: 15px;
            color: #4b7206;
            padding: 0px 19px 0px 0px;
            border: 1px solid #b7b0b0;
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

            background: rgba(123, 150, 100, 0.7);
            visibility: hidden;
            opacity: 0;
            padding: 0.1%;
            font-family: Calibri;
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

         .show-result {
   margin: -13px;
  padding: 9px;
  color: green;
  font-size: 17px;
               }

.star-rating s:hover,
.star-rating s.active {
    color:darkblue;
}
.star-rating-rtl s:hover,
.star-rating-rtl s.active {
    color: red;
}

.star-rating s,
.star-rating-rtl s {
    color: #868686;
    font-size: 50px;
    cursor: default;
    text-decoration: none;
    line-height: 50px;
}
.star-rating {
    padding: 2px;
}
.star-rating-rtl {
    background: #555;
    display: inline-block;
    border: 2px solid #444;
}
.star-rating-rtl s {
    color: yellow;
}
.star-rating s:hover:before,
.star-rating s.rated:before,
.star-rating s.active:before {
    content: "\2605";
}
.star-rating s:before {
    content: "\2606";
}
.star-rating-rtl s:hover:after,
.star-rating-rtl s.rated:after,
.star-rating-rtl s.active:after {
    content: "\2605";
}

.star-rating-rtl s:after {
    content: "\2606";
}
    </style>

     <%--  for giving pagination to the html table--%>
    <script src="../../JavaScript/JavaScriptPagination1.js"></script>
    <script src="../../JavaScript/JavaScriptPagination2.js"></script>

   <%-- <link rel="Stylesheet" href="../../css/StyleSheetPagination.css" type="text/css" />--%>
    <script>
     // var $p = jQuery.noConflict();
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


           <script>

               var confirmbox = 0;

               function IncrmntConfrmCounter() {
                   confirmbox++;
               }
               function ConfirmMessage() {
                   if (confirmbox > 0) {
                       if (confirm("Are you sure you want to leave this page?")) {
                           window.location.href = "gen_Emp_Personal_Info_List.aspx";
                       }
                       else {
                           return false;
                       }
                   }
                   else {
                       window.location.href = "gen_Emp_Personal_Info_List.aspx";

                   }
               }
               function AlertClearAll() {
                   if (confirmbox > 0) {
                       if (confirm("Are you sure you want clear all data in this page?")) {
                           window.location.href = "gen_Insurnace_Provider.aspx";
                       }
                       else {
                           return false;
                       }
                   }
                   else {
                       window.location.href = "gen_Insurnace_Provider.aspx";

                   }
               }

    </script>

     <%--Contact Details 08-05--%>
         <script>
         
             var confirmbox = 0;

             function IncrmntConfrmCounter() {
                 confirmbox++;
             }
             function ConfirmMessageCDCancel() {
                 if (confirmbox > 0 || CounterEmergency>0) {
                     if (confirm("Are you sure you want to leave this page?")) {
                         window.location.href = "gen_Emp_Personal_Info_List.aspx";
                         return false;
                     }
                     else {
                         return false;
                     }
                 }
                 else {
                     window.location.href = "gen_Emp_Personal_Info_List.aspx";
                     return false;
                 }
             }
             function AlertClearAllCD() {
                 if (confirmbox > 0) {
                     if (confirm("Are you sure you want clear all data in this page?")) {
                         $('#divTblid2').find('input[type=checkbox]:checked').removeAttr('checked');
                         $('#divTblid2 input[type="text"]').val('');
                         $('#divTblid2 textarea[type="multiline"]').val('');
                         document.getElementById("<%=ddlCountryCD.ClientID%>").value = "--Select Country--";
                         document.getElementById("<%=ddlCommuCountryCD.ClientID%>").value = "--Select Country--";  
                         document.getElementById("<%=ddlEmrgRelat.ClientID%>").value = "--Select Relation--";
                         document.getElementById("<%=ddlStateCD.ClientID%>").value = "";
                         document.getElementById("<%=ddlCityCD.ClientID%>").value = "";
                         
                         document.getElementById("<%=ddlCommuStateCD.ClientID%>").value = "";        
                         tableClick('divTblid2', cphMain_Tblid2);
                         return false;
                     }
                     else {
                         return false;
                     }
                 }
                 else {
                     //window.location.href = "gen_Emp_Personal_Informn.aspx";
                     return false;
                 }
             }
    </script>
     <%--End Contact Details--%>
      
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
          function IncrmntConfrmCounterSklCer() {
              confirmboxSklCer++;
          }
          function IncrmntConfrmCounterLang() {
              confirmboxLang++;
          }
          function AlertClearAllWrkExp() {
              if (confirmboxWrkExp > 0) {
                  if (confirm("Are you sure you want clear all data in this page?")) {
                      $('#divWorkExp input[type="text"]').val('');
                      document.getElementById("<%=txtWrkCmnt.ClientID%>").value = "";
                      document.getElementById("<%=cbxRefCheck.ClientID%>").checked = false;
                      tableClick('divTblid7', cphMain_Tblid7);  //15emp17
                      return false;  }
                  else {
                      return false;  tableClick('divTblid7', cphMain_Tblid7);  //15emp17
                      return false;
                  }
              }
              else {
                  $('#divWorkExp input[type="text"]').val('');
                  document.getElementById("<%=txtWrkCmnt.ClientID%>").value = "";
                  document.getElementById("<%=cbxRefCheck.ClientID%>").checked = false;
                  tableClick('divTblid7', cphMain_Tblid7);  //15emp17
                  return false;
              }
          }

          function AlertClearAllEdu() {
              if (confirmboxEdu > 0) {
                  if (confirm("Are you sure you want clear all data in this page?")) {
                      $('#divEductn input[type="text"]').val('');
                      document.getElementById("<%=ddlEduLvl.ClientID%>").value = "--Select Level--";
                      tableClick('divTblid7', cphMain_Tblid7);  //15emp17
                      return false;
                  }
                  else {tableClick('divTblid7', cphMain_Tblid7);  //15emp17
                      return false;
                  }
              }
              else {
                
                  $('#divEductn input[type="text"]').val('');
                  document.getElementById("<%=ddlEduLvl.ClientID%>").value = "--Select Level--";
                  tableClick('divTblid7', cphMain_Tblid7);  //15emp17
                  return false;             
              }
          }
          function AlertClearAllSkCer() {
              if (confirmboxSklCer > 0) {
                  if (confirm("Are you sure you want clear all data in this page?")) {
                      $('#divSkillCer input[type="text"]').val('');
                      document.getElementById("<%=txtSCcmnt.ClientID%>").value = "";
                      document.getElementById("cphMain_lblSKCerImg").innerText = "No File selected";
                 
                      document.getElementById("<%=ddlSCSkill.ClientID%>").value = "--Select Skill--";
                      tableClick('divTblid7', cphMain_Tblid7);  //12emp17
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {
                  $('#divSkillCer input[type="text"]').val('');
                  document.getElementById("<%=txtSCcmnt.ClientID%>").value = "";
                  document.getElementById("cphMain_lblSKCerImg").innerText = "No File selected";
                  document.getElementById("<%=ddlSCSkill.ClientID%>").value = "--Select Skill--";
                  document.getElementById("<%=radioSkill.ClientID%>").checked = true;
                  tableClick('divTblid7', cphMain_Tblid7); 
                  return false;       //12emp17

              }
          }
          function AlertClearAllLang() {         //12emp17 full
              if (confirmboxLang > 0) {
                  if (confirm("Are you sure you want clear all data in this page?")) {
                      $('#divLang').find('input[type=checkbox]:checked').removeAttr('checked');
                      document.getElementById("<%=txtLangCmnt.ClientID%>").value = "";
                      selectingstar(0);
                      document.getElementById("<%=ddlQuLang.ClientID%>").value = "--Select Language--";
                      tableClick('divTblid7', cphMain_Tblid7);   
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {
                  $('#divLang').find('input[type=checkbox]:checked').removeAttr('checked');
                  document.getElementById("<%=txtLangCmnt.ClientID%>").value = "";

                  document.getElementById("<%=ddlQuLang.ClientID%>").value = "--Select Language--";
                  tableClick('divTblid7', cphMain_Tblid7);
                  return false;
              }
          }
          function ConfirmCnclWrkExp() {
              if (confirmboxWrkExp > 0) {
                  if (confirm("Are you sure you want to cancel this page?")) {
                      window.location.href = "gen_Emp_Personal_Info_List.aspx";
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {

                  window.location.href = "gen_Emp_Personal_Info_List.aspx";
                  return false;
              }
          }
          function ConfirmCnclEdu() {
              if (confirmboxEdu > 0) {
                  if (confirm("Are you sure you want to cancel this page?")) {
                      window.location.href = "gen_Emp_Personal_Info_List.aspx";
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {

                  window.location.href = "gen_Emp_Personal_Info_List.aspx";
                  return false;
              }
          }
          function ConfirmCnclSkCer() {
              if (confirmboxSklCer > 0) {
                  if (confirm("Are you sure you want to cancel this page?")) {
                      window.location.href = "gen_Emp_Personal_Info_List.aspx";
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {

                  window.location.href = "gen_Emp_Personal_Info_List.aspx";
                  return false;
              }
          }
          function ConfirmCnclLang() {
              if (confirmboxLang > 0) {
                  if (confirm("Are you sure you want to cancel this page?")) {
                      window.location.href = "gen_Emp_Personal_Info_List.aspx";
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {

                  window.location.href = "gen_Emp_Personal_Info_List.aspx";
                  return false;
              }
          }
          // 22/02 evm-0024
          function DisableVisa() {

              $('#cphMain_RadioButtonDocList_1').prop('disabled',true);
              $('#cphMain_RadioButtonDocList_2').prop('disabled',false);
          }
          //end

    </script>
      <%---------------End Qualification ----------%>
    <script>
        var confirmbox = 0;
        var confirmboxDepnt = 0;

        //SALARY DETAILS
        var confirmboxSalryPaygrd = 0;
        var confirmboxSalryAllwnce = 0;
        var confirmboxSalryDedctn = 0;
        function IncrmntConfrmCounter() {

            confirmbox++;
        }
        function IncrmntConfrmCounterDepnt() {
         
            confirmboxDepnt++;
        }

        function IncrmntConfrmCounterSalryPaygrd() {
            confirmboxSalryPaygrd++;
        }
        function IncrmntConfrmCounterSalryAllwnce() {
            confirmboxSalryAllwnce++;
        }
        function IncrmntConfrmCounterSalryDedctn() {
            confirmboxSalryDedctn++;
        }
        function AlertClearAll() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want clear all data in this page?")) {
                    window.location.href = "gen_Emply_Personal_Informn.aspx";
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_Emply_Personal_Informn.aspx";

            }
        }
        function AlertClearAllDepnt() {
            if (confirmboxDepnt > 0) {
                if (confirm("Are you sure you want clear all data in this page?")) {
                    window.location.href = "gen_Emply_Personal_Informn.aspx";
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_Emply_Personal_Informn.aspx";

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
        // for not allowing <> tags
        function isTagEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }
        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            //alert("ss");
            IncrmntConfrmCounterOther();
            IncrmntConfrmCounterProj();
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }

        //SALARY DETAILS
        function OpenCancelView() {



            document.getElementById("MymodalCancelView").style.display = "block";
            document.getElementById("freezelayer").style.display = "";
            document.getElementById("<%=txtCnclReason.ClientID%>").focus();

            return false;

        }

       // evm-0023-20-2
        function CloseCancelView() {
            if (confirm("Do you want to close  without completing Cancellation Process?")) {
                document.getElementById('divMessageAreaSalary').style.display = "none";
                document.getElementById('imgMessageAreaSalary').src = "";

                document.getElementById('divMessageAreaSalaryAllwc').style.display = "none";
                document.getElementById('imgMessageAreaSalaryAllwc').src = "";
                document.getElementById("<%=lblMessageAreaSalaryAllwc.ClientID%>").innerHTML = "";

                document.getElementById('divMessageAreaSalaryDedctn').style.display = "none";
                document.getElementById('imgMessageAreaSalaryDedctn').src = "";
                document.getElementById("<%=lblMessageAreaSalaryDedctn.ClientID%>").innerHTML = "";

                document.getElementById("<%=lblMessageAreaSalary.ClientID%>").innerHTML = "";
                document.getElementById("MymodalCancelView").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
                document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
                tableClick('divTblid6', cphMain_Tblid6);
            }
            return false;
        }


        var $Mo = jQuery.noConflict();
        function tableClick(x,Y) {
            
            if (confirmbox != 0 && confirmboxDepnt != 0 && confirmboxSalryPaygrd != 0 && confirmboxSalryAllwnce != 0 && confirmboxSalryDedctn != 0) {
                if (confirm("Do you want to cancel this entry?")) {

                    var data;


                    var $MoparentTr = $Mo('td').closest('tr');

                    $MoparentTr.find('.selected').each(function () {
                        data = $Mo(this).attr('id').replace('cphMain_','');
                        document.getElementById("div" + data).style.display = "none";
                        $Mo(this).removeClass("selected");
                    });


                    var selected = $Mo(Y).hasClass("selected");
                    $Mo(Y).removeClass("selected");
                    if (!selected) {
                        $Mo(Y).addClass("selected");
                        document.getElementById(x).style.display = "block";


                    }

                }
                else {

                }
            }
            else {
                var data;


                var $MoparentTr = $Mo('td').closest('tr');

                $MoparentTr.find('.selected').each(function () {
                    data = $Mo(this).attr('id').replace('cphMain_','');
                    document.getElementById("div" + data).style.display = "none";
                    $Mo(this).removeClass("selected");
                });

                var selected = $Mo(Y).hasClass("selected");
                $Mo(Y).removeClass("selected");

                if (!selected) {
                    $Mo(Y).addClass("selected");

                    document.getElementById(x).style.display = "block";
                    if($Mo(Y).attr('id').toString()=="cphMain_Tblid2")
                    {     
                        document.getElementById("<%=txtAdr1.ClientID%>").focus();
                    }
                }
            }
            var id1=x;            
            if(id1=="divTblid7")

            {
                document.getElementById('cphMain_txtWrkCompny').focus();

            }
            if(id1=="divTblid4")

            {
                document.getElementById('cphMain_Txtelgblestats').focus();
            }
            if(id1=="divTblid5")

            {
                
                document.getElementById('cphMain_txtJoineddate').focus();
            }
            if(id1=="divTblid1") 
            {
               
                document.getElementById('cphMain_Txtemplyid').focus();
                CheckMandatory();
            } 
            if(id1=="divTblid3")
            {             
                document.getElementById('cphMain_txtDepndtName').focus();
            }
            if(id1=="divTblid6"){
                LoadListPageallwnce();
            }
        }
        
    </script>

         <script>

             function cbxSelected()
             {
                 document.getElementById("<%=hiddendeptchng.ClientID%>").value="";

               
                 var usrid=   document.getElementById("<%=HiddenEmployeeId.ClientID%>").value ;
                // alert(usrid);
                 var desgid=document.getElementById("<%=ddlUsrDsgn.ClientID%>").value ;
                 var strDivId="";

                

                 var deptId = $('#<%= rbtnCropDept.ClientID %> input:checked').val();
                
                
            //  var deptId=document.getElementById("<%=rbtnCropDept.ClientID%>").value ;
                // alert(usrid);        //  alert(desgid);
                 
                 var table = document.getElementById('cphMain_cbxlCorporateDvsn');
                //alert(table.rows.length);
                 for (var i = 0; i < table.rows.length; i++) {
                     if (i != table.rows.length) {
                         // FIX THIS
                         var row = table.rows[i];
                         //EVM-0027
                         if(document.getElementById("cphMain_cbxlCorporateDvsn_" +i).checked==false)
                         {
                             document.getElementById("radioDivision"+i).checked=false;
                             document.getElementById("lblPrimary"+i).innerHTML="";
                         }
                         //END
                         if(document.getElementById("cphMain_cbxlCorporateDvsn_" +i).checked==true)
                         {
                            
                             var DvsnId = document.getElementById("<%=HiddenDivision.ClientID%>").value;
                             tid=document.getElementById("cphMain_cbxlCorporateDvsn_" +i). value;

                             if(document.getElementById("<%=hiddenPrimaryDivision.ClientID%>").value==""){
                                 //EVM-0027
                                 //document.getElementById("radioDivision"+i).checked=true;
                                 //document.getElementById("lblPrimary"+i).innerHTML="Primary";
                                 
                               //  document.getElementById("<%=hiddenPrimaryDivision.ClientID%>").value=document.getElementById("cphMain_cbxlCorporateDvsn_" +i). value;
                                 //END

                             }


                             if (strDivId == "") {
                                 document.getElementById("<%=HiddenDivision.ClientID%>").value = document.getElementById("cphMain_cbxlCorporateDvsn_" +i). value;
                                 //EVM-0027
                                 //  strDivId=document.getElementById("cphMain_cbxlCorporateDvsn_" +i). value;
                                 //END
                }
                             else {
                              
                                 if (strDivId.includes(tid) == false)
                                 {
                                     document.getElementById("<%=HiddenDivision.ClientID%>").value = document.getElementById("<%=HiddenDivision.ClientID%>").value + ',' + document.getElementById("cphMain_cbxlCorporateDvsn_" +i). value;
                                     strDivId=  document.getElementById("<%=HiddenDivision.ClientID%>").value;
                                 }
                }

                           //  alert(strDivId);
                         }
                         }


                     }
            
                 $.ajax({
                     type: "POST",
                     url: "gen_Emply_Personal_Informn.aspx/LoadWelfareService",
                     data: '{struid: "' + usrid + '",strdesgid:"' + desgid + '",strdeptid:"' + deptId + '" ,strdivid:"'+strDivId+'"}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (response) {
                 
                         // document.getElementById('cphMain_divReport1').innerHTML = response.d;

                     if(response.d!="")
                     {
                       
                       //  document.getElementById('cphMain_divReport1').innerHTML = response.d;
                         document.getElementById("<%=divReport1.ClientID%>").innerHTML = response.d;
                         document.getElementById('cphMain_divwelfareSrevc').style.display= "";
                         //document.getElementById('cphMain_lblWelfareSrvc').style.display = "";
                     }
                        
                     },
                     failure: function (response) {

                     }
                 });



                // alert();

             }


             
           

             function addCommasSummry(nStr) {
                 nStr += '';
                 var x = nStr.split('.');
                 var x1 = x[0];
                 var x2 = x[1];

                 if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "1") {
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

                 if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "2") {
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
                 if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "3") {
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

                 if (isNaN(x2))
                     document.getElementById("<%=Hiddenreturnfun.ClientID%>").value = x1;
                     //return x1;
                 else
                     document.getElementById("<%=Hiddenreturnfun.ClientID%>").value = x1 + "." + x2;
                       

             }
             function addCommas(textboxid) {

                 nStr = document.getElementById(textboxid).value;
                 nStr += '';
                 var x = nStr.split('.');
                 var x1 = x[0];
                 var x2 = x[1];

                 if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "1") {
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

                 if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "2") {
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
                 if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "3") {
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

                 if (isNaN(x2))
                     document.getElementById('' + textboxid + '').value = x1;
                 else
                     document.getElementById('' + textboxid + '').value = x1 + "." + x2;
               
             }

    </script>
    <script type="text/javascript">

        var $NoConfi = jQuery.noConflict();

        $NoConfi(document).ready(function () {
            document.getElementById("<%=hiddenAccountTyp.ClientID%>").value=document.getElementById("<%=ddlAccntTyp.ClientID%>").value;
        });


        var $a = jQuery.noConflict();
        $a(window).load(function () {


          

                
            document.getElementById("freezelayer").style.display = "none";

            if(  document.getElementById("<%=HiddenFieldRsgnSts.ClientID%>").value=="1")   
            {
               
                
                $("#divEmpGnDtl *").attr('disabled','disabled');
                $("#divTblid1 *").attr('disabled','disabled');
                $("#divTblid2 *").attr('disabled','disabled');
                $("#divDepnt *").attr('disabled','disabled');
                $("#divTblid4 *").attr('disabled','disabled');
                $("#divTblid5 *").attr('disabled','disabled');
                $("#DivPaygrd *").attr('disabled','disabled');
                $("#cphMain_divAllnce *").attr('disabled','disabled');
                $("#cphMain_divdedcn *").attr('disabled','disabled');
                $("#DivSalrysumry *").attr('disabled','disabled');
                $("#divWorkExp *").attr('disabled','disabled');
                $("#divEductn *").attr('disabled','disabled');
                $("#divSkillCer *").attr('disabled','disabled');
                $("#divLang *").attr('disabled','disabled');
            }
          



            var messFrom=document.getElementById("<%=DdlMess.ClientID%>").value;   
            if(messFrom!="--SELECT--")
            {
                CheckMess();
            }


            document.getElementById("<%=hiddenAccountTyp.ClientID%>").value=document.getElementById("<%=ddlAccntTyp.ClientID%>").value;
            document.getElementById("divPayCrd").style.display = "none";

            if(document.getElementById("<%=hiddenPaycrdSal.ClientID%>").value!=""){
                loadsaved();
            }
            if(document.getElementById("<%=hiddenBankDtls.ClientID%>").value!=""){
                ShowHideDiv('cphMain_ddlBank');
            }
            if(document.getElementById("<%=lblEntry.ClientID%>").innerText=="Add Employee"){
                IsAdd();
            }
            document.getElementById("freezelayer").style.display = "none";
            document.getElementById('MymodalCancelView').style.display = "none";
            document.getElementById('divmodalCancelViewForimig').style.display = "none";
            document.getElementById('divMessageArea').style.display = "none";
            document.getElementById('imgMessageArea').src = "";
            var IdChk = "";
            var $aa = jQuery.noConflict();
            var $aaoparentTr = $aa('td').closest('tr');
            $aaoparentTr.find('.selected').each(function () {
                IdChk = $aa(this).attr('id');
            });
            if (IdChk == "") {     
                tableClick('divTblid8', cphMain_Tblid8);
                document.getElementById("<%=TxtFrstName.ClientID%>").focus();
            }        
            var QuafcnMode = document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value;
            if (QuafcnMode == "Education") {
                divButtonEductnClick();
            }
            else if (QuafcnMode == "Skl&Cer") {
                divButtonSkillClick();
            }
            else if (QuafcnMode == "Language") {
                divButtonLangClick();
            }
            else if(QuafcnMode == "Work"){
                divButtonWrkExpClick();
            }
            else
                divButtonWrkExpClick();
            //SALARY DETAILS
            
             //evm-0023-20-2 start
            if (document.getElementById("<%=HiddenSalaryDedctnId.ClientID%>").value == "") {



                document.getElementById("<%=radPercntge.ClientID%>").checked = true;
                document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = true; 
                RadioPerClick();


                document.getElementById("<%=rdbAllwcPerc.ClientID%>").checked = true;
                document.getElementById("<%=rdbBascPayAllwc.ClientID%>").checked = true; 
                 RadioPerClickAllwc();

            }
            //evm-0023-20-2 end
            addCommas('cphMain_txtAmntRedcnFrom');
            addCommas('cphMain_txtAmntRgeFrm');
            addCommas('cphMain_txtBasicpayFrm');
            addCommas('cphMain_txtperctg');

            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var basicpay=parseFloat(document.getElementById("<%=HiddenSalarSummry.ClientID%>").value);
            var a = parseFloat(basicpay).toFixed(FloatingValue);
            toatlpay= parseFloat(a);
            addCommasSummry(a);
            a = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
          
            document.getElementById('SumryPayRng').innerHTML = a+" "+document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
            var totalpay=parseFloat(document.getElementById("<%=HiddenSalarSummry.ClientID%>").value);
            totalpay=totalpay+parseFloat(document.getElementById("<%=HiddenTotalpay.ClientID%>").value);

            SetTextforperiod();
        });
  
 
        
        function IsAdd(){
            var $a = jQuery.noConflict();
            $a(function(){
                $a('#cphMain_Tblid2').css('pointer-events', 'none');

                $a('#cphMain_Tblid3').css('pointer-events', 'none');
                $a('#cphMain_Tblid4').css('pointer-events', 'none'); 
                $a('#cphMain_Tblid1').css('pointer-events', 'none');
                $a('#cphMain_Tblid7').css('pointer-events', 'none');
                //$a('#cphMain_Tblid5').css('pointer-events', 'none');
                $a('#cphMain_Tblid6').css('pointer-events', 'none');
            });
            
           
        }
        function Notadd(){
            var $a = jQuery.noConflict();
            $a(function(){
                $a('#cphMain_Tblid2').css('pointer-events', 'all');

                $a('#cphMain_Tblid3').css('pointer-events', 'all');
                $a('#cphMain_Tblid4').css('pointer-events', 'all'); 
                $a('#cphMain_Tblid1').css('pointer-events', 'all');

                $a('#cphMain_Tblid5').css('pointer-events', 'all');
                $a('#cphMain_Tblid6').css('pointer-events', 'all');
            });
            
           
        }
        function NumChecking(textboxid) {
            
            var txtPerVal = document.getElementById(textboxid).value;

            txtPerVal = txtPerVal.replace(/,/g, "");
       


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
                    textCounter(textboxid, 6);
                }
            }

           
        }
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
        function RadioAmountClick() {

            document.getElementById('divperclk').style.display = "none";
            document.getElementById('divAmtClk').style.display = "block";

        }
        function RadioPerClick() {
            document.getElementById('divperclk').style.display = "block";
            document.getElementById('divAmtClk').style.display = "none";
        }

         //evm-0023-20-2
        function RadioAmountClickAllwc() {
            document.getElementById('divPerClkAllwnc').style.display = "none";
            document.getElementById('divAmtClkAllwnc').style.display = "block";

        }
         //evm-0023-20-2
        function RadioPerClickAllwc() {
            document.getElementById('divPerClkAllwnc').style.display = "block";
            document.getElementById('divAmtClkAllwnc').style.display = "none";
        }

        function AmountChecking(textboxid) {
            
            var txtPerVal = document.getElementById(textboxid).value;

            txtPerVal = txtPerVal.replace(/,/g, "");



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
                    var amt = parseFloat(txtPerVal);
                    var num = amt;
                    var n = 0;
                    // for floatting number adjustment from corp global
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);

                    }
                    document.getElementById('' + textboxid + '').value = n;

                }
            }

            addCommas(textboxid);
        }
        function isNumberSalary(evt, textboxid) {
            //  alert('a');
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
           
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40 ||keyCodes==118||keyCodes==17) {
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
                    if(keyCodes==118||keyCodes==17)
                        ret=true;
                }
                if(keyCodes==86||keyCodes==17 || keyCodes==67)
                    ret=true;
             
              
                return ret;
            }
        }
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //enter
            if (keyCodes == 13) {
                // return false;
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
        function CancelAlert(href) {

            if (confirm("Do you want to cancel this Entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }

        var confirmboxother=0;      //emp17
        function IncrmntConfrmCounterOther() {
            confirmboxother++;
            //alert(confirmboxother);
        }
        function ConfirmCnclPD() {
            if (confirmboxother > 0) {     //emp17
                if (confirm("Are you sure you want to cancel this page?")) {
                    window.location.href = "gen_Emp_Personal_Info_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {

                window.location.href = "gen_Emp_Personal_Info_List.aspx";
                return false;
            }
        }
    
        //var confirmboxother=0;
        //function IncrmntConfrmCounterOther() {
        //    confirmboxother++;
        //}
        function AlertClearAllOthers() {
            if (confirmboxother > 0) {       //emp17
                if (confirm("Are you sure you want clear all data in this page?")) {
                    //document.getElementById("<%=txtRefNum.ClientID%>").value = "";//emp17
                    //document.getElementById("<%=Txtemplyid.ClientID%>").value = "";//emp17
             
      
                    document.getElementById("<%=txtBirthPlc.ClientID%>").value = "";
                    document.getElementById("<%=TxtdivExpiryDate.ClientID%>").value = "";
                    document.getElementById("<%=txtJoinDate.ClientID%>").value = "";
                     document.getElementById("<%=TextIssuueddate.ClientID%>").value = "";
                    //ddlReligion.Items.Insert(0, "--Select Religion--");
                    document.getElementById("<%=ddlReligion.ClientID%>").selectedIndex = 0; //emp17
                    document.getElementById("<%=ddlBldGrp.ClientID%>").selectedIndex = 0; //emp17

                    document.getElementById("<%=txtNickName.ClientID%>").value = "";

                    document.getElementById("<%=txtHobbies.ClientID%>").value = "";
                    document.getElementById("<%=ddlAccmdtn.ClientID%>").selectedIndex = 0;
                    document.getElementById("<%=ddlCategry.ClientID%>").selectedIndex = 0;
                    document.getElementById("<%=ddlSubCat.ClientID%>").selectedIndex = 0;
                    document.getElementById("<%=DdlMess.ClientID%>").selectedIndex = 0;
                    document.getElementById("<%=ddlBank.ClientID%>").selectedIndex = 0;//evm-0023
                    document.getElementById("<%=ddlAccntTyp.ClientID%>").selectedIndex = 1;//evm-0023
                    document.getElementById("<%=txtBranch.ClientID%>").value = ""; //evm-0023
                    document.getElementById("<%=txtIban.ClientID%>").value = ""; //evm-0023
                    document.getElementById("<%=txtCardNo.ClientID%>").value = "";
                    CheckMessClick();
                    tableClick('divTblid1', cphMain_Tblid1);
                    return false;
                }
                else 
                {
                    return false;
                }
            }
            else {
                //document.getElementById("<%=txtRefNum.ClientID%>").value = "";//emp17
                //document.getElementById("<%=Txtemplyid.ClientID%>").value = "";//emp17
             
      
                document.getElementById("<%=txtBirthPlc.ClientID%>").value = "";
                document.getElementById("<%=TxtdivExpiryDate.ClientID%>").value = "";
                document.getElementById("<%=TextIssuueddate.ClientID%>").value = "";
                document.getElementById("<%=ddlReligion.ClientID%>").selectedIndex = 0; //emp17
                document.getElementById("<%=ddlBldGrp.ClientID%>").selectedIndex = 0; //emp17

                document.getElementById("<%=txtNickName.ClientID%>").value = "";

                document.getElementById("<%=txtHobbies.ClientID%>").value = "";
              
                document.getElementById("<%=ddlAccmdtn.ClientID%>").selectedIndex = 0;
                document.getElementById("<%=ddlCategry.ClientID%>").selectedIndex = 0;
                document.getElementById("<%=ddlSubCat.ClientID%>").selectedIndex = 0;
                document.getElementById("<%=DdlMess.ClientID%>").selectedIndex = 0;
                document.getElementById("<%=ddlBank.ClientID%>").selectedIndex = 0;//evm-0023
                document.getElementById("<%=ddlAccntTyp.ClientID%>").selectedIndex = 1;//evm-0023
                document.getElementById("<%=txtCardNo.ClientID%>").value = "";
                CheckMessClick();
              
                tableClick('divTblid1', cphMain_Tblid1);
                
                //tableClick('divTblid1', Tblid1);
                return false;
            }
        } //emp17
      
        var $noconflic = jQuery.noConflict();
        //-----personal detail-------
        function ValidatePerDtl() {
            var ret = true;
          
            var emplyid = document.getElementById("cphMain_Txtemplyid").value.trim(); //emp17
            var NameWithoutReplace = document.getElementById("<%=txtNickName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtNickName.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtHobbies.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtHobbies.ClientID%>").value = replaceText2;

           
           NameWithoutReplace = document.getElementById("<%=OccupyDate.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=OccupyDate.ClientID%>").value = replaceText2;

           NameWithoutReplace = document.getElementById("<%=txtBranch.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtBranch.ClientID%>").value = replaceText2;

           NameWithoutReplace = document.getElementById("<%=txtIban.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtIban.ClientID%>").value = replaceText2;

           NameWithoutReplace = document.getElementById("<%=txtCardNo.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCardNo.ClientID%>").value = replaceText2;
            
           NameWithoutReplace = document.getElementById("<%=txtEmpId.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEmpId.ClientID%>").value = replaceText2;

        
           var birthplc = document.getElementById("<%=txtBirthPlc.ClientID%>").value.trim();
            var nickname = document.getElementById("<%=txtNickName.ClientID%>").value.trim();
            var birthplc = document.getElementById("<%=txtHobbies.ClientID%>").value.trim();

            var religion=document.getElementById("<%=ddlReligion.ClientID%>").value;
            //bank
            var Bank = document.getElementById("<%=ddlBank.ClientID%>").value;
            var Branch=document.getElementById("<%=txtBranch.ClientID%>").value.trim();
            var AccntTyp=document.getElementById("<%=ddlAccntTyp.ClientID%>").value;
            var IbanNo=document.getElementById("<%=txtIban.ClientID%>").value.trim();
            var EmpId=document.getElementById("<%=txtEmpId.ClientID%>").value.trim();

            var CardNo=document.getElementById("<%=txtCardNo.ClientID%>").value.trim();
            document.getElementById("<%=txtCardNo.ClientID%>").value=CardNo;
            var joindate = document.getElementById("cphMain_txtJoinDate").value.trim();   //emp17
            var arrDatePickerDate1 = joindate.split("-");
            var convjndate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
            var Accmdtn = document.getElementById("<%=ddlAccmdtn.ClientID%>").value;

            if(Accmdtn !="--SELECT--" && Accmdtn!="0")
            {
                var AccmdtnCatgry = document.getElementById("<%=ddlCategry.ClientID%>").value;
               var OccupyDate = document.getElementById("<%=OccupyDate.ClientID%>").value;   //emp25
               var SubcatgId = document.getElementById("<%=ddlSubCat.ClientID%>").value; 

           }
             var dob = document.getElementById("cphMain_TxtDOB").value.trim();
           var arrDatePickerDate1 = dob.split("-");
           var convdob = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]); //emp17
           var cdate=new Date();

           document.getElementById("<%=txtEmpId.ClientID%>").style.borderColor = "";

            document.getElementById("<%=ddlAccmdtn.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlCategry.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlSubCat.ClientID%>").style.borderColor = "";
            document.getElementById("<%=OccupyDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=DdlMess.ClientID%>").style.borderColor = "";

            document.getElementById("<%=Txtemplyid.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtBirthPlc.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtNickName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtHobbies.ClientID%>").style.borderColor = "";

            document.getElementById("<%=ddlReligion.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlBldGrp.ClientID%>").style.borderColor = "";
            document.getElementById("<%=TxtDOB.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtJoinDate.ClientID%>").style.borderColor = "";
           document.getElementById('divMessageAreaPD').style.display = "none";
            document.getElementById('imgMessageAreaPD').src = "";

            document.getElementById("<%=ddlBank.ClientID%>").style.borderColor = "";
           document.getElementById("<%=txtBranch.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtIban.ClientID%>").style.borderColor = "";
            $noconflic("div#divBnk input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById("<%=txtMessFromDate.ClientID%>").style.borderColor = "";
            if(Bank!="--Select Bank--")
            {

                if(AccntTyp==1)
                {
                    if(IbanNo =="")
                    {
                        document.getElementById("<%=txtIban.ClientID%>").style.borderColor = "Red";
                       document.getElementById("<%=txtIban.ClientID%>").focus();   
                       ret = false;
                   }
               }

               if(Branch =="")
               {
                   document.getElementById("<%=txtBranch.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtBranch.ClientID%>").focus();   
                    ret = false;
                }
                ShowHideDiv('cphMain_ddlBank');

            }

            if((Branch!="" && AccntTyp==1)||(Branch!="" && AccntTyp==1 && IbanNo!="")||(Branch=="" && AccntTyp==1 && IbanNo!=""))
            {

                if(IbanNo =="")
                {
                    document.getElementById("<%=txtIban.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtIban.ClientID%>").focus();
                    ret = false;
                }
                if(Branch=="")
                {
                    document.getElementById("<%=txtBranch.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtBranch.ClientID%>").focus();   
                    ret = false;
                }
                if(Bank=="--Select Bank--")
                {
                    document.getElementById("<%=ddlBank.ClientID%>").style.borderColor = "Red";
                    noconflic("div#divBnk input.ui-autocomplete-input").css("borderColor", "red");
                    $noconflic("div#divBnk input.ui-autocomplete-input").focus();
                    document.getElementById("<%=ddlBank.ClientID%>").focus();
                    ret = false;
                }
                ShowHideDiv('cphMain_ddlBank');
            }
            else if((Branch!="" && AccntTyp==2)||CardNo!="")
            {

                if(EmpId =="")
                {
                    document.getElementById("<%=txtEmpId.ClientID%>").style.borderColor = "Red";
                    ocument.getElementById("<%=txtEmpId.ClientID%>").focus();
                    ret = false;
                }
                if(Branch=="")
                {
                    document.getElementById("<%=txtBranch.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtBranch.ClientID%>").focus();   
                    ret = false;
                }
                if(Bank=="--Select Bank--")
                {
                    document.getElementById("<%=ddlBank.ClientID%>").style.borderColor = "Red";
                    $noconflic("div#divBnk input.ui-autocomplete-input").css("borderColor", "red");
                    $noconflic("div#divBnk input.ui-autocomplete-input").focus();
                    document.getElementById("<%=ddlBank.ClientID%>").focus();
                    ret = false;
                }
                ShowHideDiv('cphMain_ddlBank');
            }

        if(document.getElementById("<%=hiddenBankDtls.ClientID%>").value!=""){

                if(AccntTyp==1)
                {
                    if(IbanNo =="")
                    {
                        document.getElementById("<%=txtIban.ClientID%>").style.borderColor = "Red";
                       document.getElementById("<%=txtIban.ClientID%>").focus();   
                       ret = false;
                   }
               }

               if(Branch =="")
               {
                   document.getElementById("<%=txtBranch.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtBranch.ClientID%>").focus();   
                    ret = false;
                }

                if(Bank=="--Select Bank--"){

                    document.getElementById("<%=ddlBank.ClientID%>").style.borderColor = "Red";
                    $noconflic("div#divBnk input.ui-autocomplete-input").css("borderColor", "red");
                    $noconflic("div#divBnk input.ui-autocomplete-input").focus();
                    document.getElementById("<%=ddlBank.ClientID%>").focus();   
                    ret = false;
                }
                ShowHideDiv('cphMain_ddlBank');
            }

            if(Accmdtn !="--SELECT--" || Accmdtn==0)
            {
               
                if( AccmdtnCatgry=="--SELECT--" || AccmdtnCatgry==0)
                {
                    document.getElementById("<%=ddlCategry.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddlCategry.ClientID%>").focus();
                    document.getElementById("<%=HiddenAccCat.ClientID%>").value=0;
                    ret = false;
                }
               
                if( SubcatgId=="--SELECT--"|| SubcatgId==0)
                {
                    document.getElementById("<%=ddlSubCat.ClientID%>").focus();
                    document.getElementById("<%=ddlSubCat.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=HiddenAccSubCat.ClientID%>").value=0;
                    ret = false;
                }
                if(OccupyDate==""||OccupyDate==0)
                {
                   
                  // document.getElementById("<%=OccupyDate.ClientID%>").focus();
                    document.getElementById("<%=OccupyDate.ClientID%>").style.borderColor = "Red";
                    ret = false
                }
           
                else
                {
                    document.getElementById("<%=HiddenAccSubCat.ClientID%>").value=SubcatgId;
                }
                document.getElementById("<%=HiddenAccCat.ClientID%>").value=AccmdtnCatgry;
               
            }
            var mess=document.getElementById("<%=DdlMess.ClientID%>").value;
           
            if(mess !="--SELECT--" && mess!="0")
            {
               var messFromdate = document.getElementById("<%=txtMessFromDate.ClientID%>").value;

               if( messFromdate==""||messFromdate==0)
               
               { 
                   document.getElementById("<%=txtMessFromDate.ClientID%>").focus();
                    document.getElementById("<%=txtMessFromDate.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }

                 
            }
          
            if(convdob > cdate)  //emp17
            {
                document.getElementById("<%=TxtDOB.ClientID%>").focus();
                document.getElementById("<%=TxtDOB.ClientID%>").style.borderColor = "Red";
                ret = false;
            
            }

            if(convjndate<=convdob)  //emp17
            {
                document.getElementById('divMessageAreaPD').style.display = "";
                document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=TxtDOB.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = "Date of birth should be less than  joining date."; //EMP17
                document.getElementById("<%=TxtDOB.ClientID%>").focus();
 
                return false;
            
            }
            if (religion == "--Select Religion--") {
                document.getElementById("<%=ddlReligion.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlReligion.ClientID%>").focus();
                ret = false;
            }

        <%--    if(emplyid=="") 
            {
                document.getElementById("<%=Txtemplyid.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=Txtemplyid.ClientID%>").focus();
                ret = false;
            } --%>
            if (joindate == "") {
               
                document.getElementById("<%=txtJoinDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtJoinDate.ClientID%>").focus();
                ret = false;
            }
            
            if(ret==false)
            {
                document.getElementById('divMessageAreaPD').style.display = "";
                document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML =  "Some of the information you entered is not correct or missing. Please check the highlighted fields below.."; 
        
            }
     
            return ret;
        }

        function DuplicationEmpId() {
            document.getElementById('divMessageAreaPD').style.display = "";
            document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML ="Duplication Error!. Employee Id Can’t be Duplicated.";
            document.getElementById("<%=Txtemplyid.ClientID%>").style.borderColor = "Red";
            tableClick('divTblid1', cphMain_Tblid1);
        }


        function SuccessConfirmationPD() {
            document.getElementById('divMessageAreaPD').style.display = "";
            document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = " Details inserted successfully.";   //EMP17
            document.getElementById("<%=txtBirthPlc.ClientID%>").focus();
          //  MarrgdtlsDepClear();

            tableClick('divTblid1', cphMain_Tblid1);
            // UpdateAccomdtn();

            //   LoadSubCategry();
        
        }
       
        function SuccessUpdationPD() {
            document.getElementById('divMessageAreaPD').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = " Details updated successfully.";//EMP17
            document.getElementById("<%=txtBirthPlc.ClientID%>").focus();
            tableClick('divTblid1', cphMain_Tblid1);
        }

        function SuccessConfirmationDepnt() {
            document.getElementById('divMessageAreaDpnt').style.display = "";
            document.getElementById('imgMessageAreaDpnt').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaDpnt.ClientID%>").innerHTML = "Dependent details inserted successfully.";
            DepClear();
            tableClick('divTblid3', cphMain_Tblid3);
        }
        function SuccessUpdationDepnt() {
            document.getElementById('divMessageAreaDpnt').style.display = "";
            document.getElementById('imgMessageAreaDpnt').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaDpnt.ClientID%>").innerHTML = "Dependent details updated successfully.";
            DepClear();
            tableClick('divTblid3', cphMain_Tblid3);
        }
        function SuccessDeletionDepnt() {
            document.getElementById('divMessageAreaDpnt').style.display = "";
            document.getElementById('imgMessageAreaDpnt').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaDpnt.ClientID%>").innerHTML = "Dependent details deleted successfully.";
            $p('#ReportTableDep').DataTable({
                "pagingType": "full_numbers",
                "bSort": true

            }); 
            DepClear();
            tableClick('divTblid3', cphMain_Tblid3);
        }
        function DepClear()
        {
        
            document.getElementById("<%=ddlReltnshp.ClientID%>").selectedIndex = 0;
            document.getElementById("<%=txtRPexpDate.ClientID%>").value = "";
            document.getElementById("<%=txtRPissDate.ClientID%>").value = "";
            document.getElementById("<%=txtRPnum.ClientID%>").value = "";
            document.getElementById("<%=txtPsprtDate.ClientID%>").value = "";
            document.getElementById("<%=txtPasprtNum.ClientID%>").value = "";
            document.getElementById("<%=txtDepndtName.ClientID%>").value = "";
        }
       
        function AlertDepCancel() {
            if (confirmboxDepnt > 0) {     //emp17
                if (confirm("Are you sure you want to cancel this page?")) {
                    window.location.href = "gen_Emp_Personal_Info_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {

                window.location.href = "gen_Emp_Personal_Info_List.aspx";
                return false;
            }
        }

        function AlertDepClear() {
            if (confirmboxDepnt > 0) {       //emp17
                if (confirm("Are you sure you want clear all data in this page?")) {
                    //document.getElementById("<%=txtRefNum.ClientID%>").value = "";//emp17
                    //document.getElementById("<%=Txtemplyid.ClientID%>").value = "";//emp17
             
      
                    document.getElementById("<%=ddlReltnshp.ClientID%>").selectedIndex = 0;
                    document.getElementById("<%=txtRPexpDate.ClientID%>").value = "";
                    document.getElementById("<%=txtRPissDate.ClientID%>").value = "";
                    document.getElementById("<%=txtRPnum.ClientID%>").value = "";
                    document.getElementById("<%=txtPsprtDate.ClientID%>").value = "";
                    document.getElementById("<%=txtPasprtNum.ClientID%>").value = "";
                    document.getElementById("<%=txtDepndtName.ClientID%>").value = "";
                    tableClick('divTblid3', cphMain_Tblid3);
                    return false;
                }
                else 
                {
                    return false;
                }
            }
            else {
                //document.getElementById("<%=txtRefNum.ClientID%>").value = "";//emp17
                //document.getElementById("<%=Txtemplyid.ClientID%>").value = "";//emp17
             
      
                document.getElementById("<%=ddlReltnshp.ClientID%>").selectedIndex = 0;
                document.getElementById("<%=txtRPexpDate.ClientID%>").value = "";
                document.getElementById("<%=txtRPissDate.ClientID%>").value = "";
                document.getElementById("<%=txtRPnum.ClientID%>").value = "";
                document.getElementById("<%=txtPsprtDate.ClientID%>").value = "";
                document.getElementById("<%=txtPasprtNum.ClientID%>").value = "";
                document.getElementById("<%=txtDepndtName.ClientID%>").value = "";
                tableClick('divTblid3', cphMain_Tblid3);
                
               
                return false;
            }
        } //emp17      
        function ValidateDepnt() {
            var ret = true;
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtDepndtName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtDepndtName.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtPasprtNum.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtPasprtNum.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtPsprtDate.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtPsprtDate.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtRPnum.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtRPnum.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtRPissDate.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtRPissDate.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtRPexpDate.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtRPexpDate.ClientID%>").value = replaceText2;

            var name = document.getElementById("<%=txtDepndtName.ClientID%>").value.trim();
            var relationship = document.getElementById("<%=ddlReltnshp.ClientID%>").value;
            var pasprtNum = document.getElementById("<%=txtPasprtNum.ClientID%>").value.trim();
            var pasprtIssdate = document.getElementById("<%=txtPsprtDate.ClientID%>").value.trim();
            var RPnum = document.getElementById("<%=txtRPnum.ClientID%>").value.trim();
            var RPissDate = document.getElementById("<%=txtRPissDate.ClientID%>").value.trim();
            var RPexpDate = document.getElementById("<%=txtRPexpDate.ClientID%>").value.trim();


            
            var datepickerDateCRNE = document.getElementById("<%=txtRPissDate.ClientID%>").value;
            var arrDatePickerDate = datepickerDateCRNE.split("-");
            var dateCRNExp = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);



            var datepickerDateCRNEA = document.getElementById("<%=txtRPexpDate.ClientID%>").value;
            var arrDatePickerDateA = datepickerDateCRNEA.split("-");
            var dateCRNExpA = new Date(arrDatePickerDateA[2], arrDatePickerDateA[1] - 1, arrDatePickerDateA[0]);


            var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
            var arrCurrentDate = CurrentDateDate.split("-");
            var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);



            document.getElementById("<%=txtDepndtName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlReltnshp.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtPsprtDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtRPissDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtRPexpDate.ClientID%>").style.borderColor = "";
            document.getElementById('divMessageAreaDpnt').style.display = "none";
            document.getElementById('imgMessageAreaDpnt').src = "";




            if(datepickerDateCRNE!="" && datepickerDateCRNEA!=""){
                if (dateCRNExp > dateCRNExpA) {
                    document.getElementById("<%=txtRPexpDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtRPexpDate.ClientID%>").focus();
                    document.getElementById('divMessageAreaDpnt').style.display = "";
                    document.getElementById('imgMessageAreaDpnt').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaDpnt.ClientID%>").innerHTML = "Sorry, Issue Date cannot be Greater than Expiry Date !.";
                    ret = false;
                }
            }



            if(datepickerDateCRNE!=""){
                if (dateCRNExp > dateCurrentDate) {
                    document.getElementById("<%=txtRPissDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtRPissDate.ClientID%>").focus();
                    document.getElementById('divMessageAreaDpnt').style.display = "";
                    document.getElementById('imgMessageAreaDpnt').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaDpnt.ClientID%>").innerHTML = "Sorry, Issue Date cannot be Greater than Current Date !.";
                    ret = false;
                }
            }


            if (relationship == "--Select Relationship--") {
                document.getElementById('divMessageAreaDpnt').style.display = "";
                document.getElementById('imgMessageAreaDpnt').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaDpnt.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlReltnshp.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlReltnshp.ClientID%>").focus();
                ret = false;
            }

            if (name == "") {
                document.getElementById('divMessageAreaDpnt').style.display = "";
                document.getElementById('imgMessageAreaDpnt').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaDpnt.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtDepndtName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtDepndtName.ClientID%>").focus();
                ret = false;
            }
            return ret;
        }

        function updateDepntById(Id) {
            document.getElementById("<%=HiddenDepntId.ClientID%>").value = Id;
            
            var Details = PageMethods.ReadDepntDtlById(Id, function (response) {
               
                document.getElementById("<%=txtDepndtName.ClientID%>").value = response.Name;
                document.getElementById("<%=txtPasprtNum.ClientID%>").value = response.pasprtNum;
                document.getElementById("<%=txtPsprtDate.ClientID%>").value = response.pasprtExpDate;
                document.getElementById("<%=txtRPnum.ClientID%>").value = response.RpNum;
                document.getElementById("<%=txtRPissDate.ClientID%>").value = response.RpIssDate;
                document.getElementById("<%=txtRPexpDate.ClientID%>").value = response.RpExpDate;
               
                if (response.reltnshpStsId == "1") {
                    document.getElementById("<%=ddlReltnshp.ClientID%>").value = response.reltnshpId;
                }
                else if (response.reltnshpStsId == "0") {
                    var $Mo = jQuery.noConflict();
                    var newOption = "<option value='" + response.reltnshpId + "'>" + response.reltnshpName + "</option>";

                    $Mo('#<%=ddlReltnshp.ClientID%>').append(newOption);
                    //SORTING DDL
                    var options = $Mo("#<%=ddlReltnshp.ClientID%> option");                    // Collect options         
                    options.detach().sort(function (a, b) {               // Detach from select, then Sort
                        var at = $Mo(a).text();
                        var bt = $Mo(b).text();
                        return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                    });
                    options.appendTo('#<%=ddlReltnshp.ClientID%>');
                    document.getElementById("<%=ddlReltnshp.ClientID%>").value = response.reltnshpId;

                }
                document.getElementById("cphMain_btnAddDepnt").style.display= "none";
                document.getElementById("cphMain_btnClearDepnt").style.display = "none";            
                document.getElementById("cphMain_btnUpdateDepnt").style.display = "block";
                document.getElementById("cphMain_lblDepntHead").innerText = "Edit Dependent"
               
            });
        return false;
    }

    function deleteDepntById(Id) {
        document.getElementById("<%=HiddenDepntId.ClientID%>").value = Id;
        var empId= document.getElementById("<%=HiddenEmpUserId.ClientID%>").value
            
        if (confirm("Do you want to cancel this Entry?")) {
            var Details = PageMethods.deleteDepntDtlById(Id,empId, function (response) {

                document.getElementById("cphMain_divReport").innerHTML = response.strDepntLIst;
                SuccessDeletionDepnt();
            });
        }
        else {
               
        }
           
     
    }
    //----------------------end personal info & dependent--------------------

    //SALARY DETAILS
    function waitSeconds(iMilliSeconds) {
        //  alert(iMilliSeconds);
        var counter= 0
            , start = new Date().getTime()
            , end = 0;
        while (counter < iMilliSeconds) {
            end = new Date().getTime();
            counter = end - start;
        }
    }
    function RestrictionCaln()
    {
        IncrmntConfrmCounterSalryPaygrd();
        var AllwOrDed=0;
        var varddlAddtn = document.getElementById("<%=ddlPayGrd.ClientID%>");
        var ddlAddtnText = varddlAddtn.options[varddlAddtn.selectedIndex].value;
        document.getElementById("<%=txtBasicpayFrm.ClientID%>").value="";
        if(ddlAddtnText!= "--SELECT PAY GRADE--")
            CheckForRestriction(ddlAddtnText, AllwOrDed);
        
    }


        //evm-0023-20-2
    function  RestrictionCalnAllownce()
    {
     
        IncrmntConfrmCounterSalryAllwnce();
        var AllwOrDed=1;
        var varddlAddtn = document.getElementById("<%=ddlAddtn.ClientID%>");
            var ddlAddtnText = varddlAddtn.options[varddlAddtn.selectedIndex].value;
           
            document.getElementById("<%=ddlAddtn.ClientID%>").style.borderColor = "";

            document.getElementById("divMessageAreaSalaryAllwc").style.display = "none";

            if(ddlAddtnText!="--SELECT SALARY ADDITION--")
            {
                CheckForRestriction(ddlAddtnText, AllwOrDed);
            }
            else
            {
                document.getElementById("idRestrctnRangePercAllwnc").innerHTML = "";
                document.getElementById("AllowRestrctrang").innerHTML = "";
                document.getElementById("divPyrollTypAllwc").style.display = "none";
                document.getElementById("cphMain_txtAmntRgeFrm").value = "";                
            }


    }

        //evm-0023-20-2
        function RestrictionCalnDedcn()
        {
        
            IncrmntConfrmCounterSalryAllwnce();
            var AllwOrDed=2;
            var varddlAddtn = document.getElementById("<%=ddldedctn.ClientID%>");
            var ddlAddtnText = varddlAddtn.options[varddlAddtn.selectedIndex].value;
            //  alert(ddlAddtnText);
            
            document.getElementById("<%=ddldedctn.ClientID%>").style.borderColor = "";
            document.getElementById("divMessageAreaSalaryDedctn").style.display = "none";

            if(ddlAddtnText!="--SELECT SALARY DEDUCTION--")
            {

                CheckForRestriction(ddlAddtnText, AllwOrDed);

            }
            else
            {
                document.getElementById("DedctnRestrctrang").innerHTML = "";
                document.getElementById("idDedRestrctnRangePerc").innerHTML = "";
                document.getElementById("divPyrollTypDedctn").style.display = "none";
                document.getElementById("cphMain_txtAmntRedcnFrom").value = "";
            }
        }

        function AlertClearAllPaygrd() {
            if (confirmboxSalryPaygrd > 0) {
                if (confirm("Are you sure you want clear all data in this section?")) {
                    // window.location.href = "gen_Bank_Guarantee.aspx";
                    document.getElementById("<%=ddlPayGrd.ClientID%>").selectedIndex = 0;
                    document.getElementById("<%=txtBasicpayFrm.ClientID%>").value = "";
                    document.getElementById('cphMain_divAllnce').style.display = "block";
                    document.getElementById('cphMain_divdedcn').style.display = "block";
                    ClearAddition();
                    ClearDedAll();

                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                //window.location.href = "gen_Bank_Guarantee.aspx";
                document.getElementById("<%=ddlPayGrd.ClientID%>").selectedIndex = 0;

                document.getElementById("<%=txtBasicpayFrm.ClientID%>").value = "";
                document.getElementById('cphMain_divAllnce').style.display = "block";
                document.getElementById('cphMain_divdedcn').style.display = "block";
                ClearAddition();
                ClearDedAll();
                return false;
            }
        }
        function UpdatePayGradePayGrade(x) {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Pay grade details updated successfully.";
            // ClearAllPaygrd();
            LoadListPageallwnce();
            // LoadListPageDed();
            document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value = x;
            tableClick('divTblid6', cphMain_Tblid6);
            //  LoadddlAllwncededctn();
            document.getElementById("<%=ddlPayGrd.ClientID%>").value = x;
            document.getElementById("<%=ButtnSalryupd.ClientID%>").style.display = "none";
            document.getElementById("<%=ButtonAdd.ClientID%>").style.display = "block";
            LoadListPageallwnce();
            // LoadListPageDed();
            document.getElementById("<%=HiddenSalarSummry.ClientID%>").value = document.getElementById("<%=HiddenAmountRngeChk.ClientID%>").value;
            document.getElementById("<%=ButtnSalryupd.ClientID%>").style.display = "block";
            document.getElementById("<%=ButtonAdd.ClientID%>").style.display = "none";

        }
        function DuplicationPaygrdName() {


            document.getElementById('divMessageAreaSalary').style.display = "";
            document.getElementById('imgMessageAreaSalary').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaSalary.ClientID%>").innerHTML = "Duplication error.Pay grade can't be duplicated.";
            document.getElementById("<%=ddlPayGrd.ClientID%>").style.borderColor = "Red";
            LoadListPageallwnce();
            //LoadListPageDed();
            // LoadddlAllwncededctn();
            
            tableClick('divTblid6', cphMain_Tblid6);
            document.getElementById("<%=ButtnSalryupd.ClientID%>").style.display = "block";
            document.getElementById("<%=ButtonAdd.ClientID%>").style.display = "none";
        }
        function SuccessConfirmationPayGrade(x) {
           
            document.getElementById('divMessageAreaSalary').style.display = "";
            document.getElementById('imgMessageAreaSalary').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaSalary.ClientID%>").innerHTML = "Pay grade details inserted successfully.";
            //  ClearAllPaygrd();
            // document.getElementById('cphMain_divAllnce').style.display = "block";
            // document.getElementById('cphMain_divdedcn').style.display = "block";
            document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value = x;
            tableClick('divTblid6', cphMain_Tblid6);
            //  LoadddlAllwncededctn();
            document.getElementById("<%=ddlPayGrd.ClientID%>").value = x;
            LoadListPageallwnce();
            // LoadListPageDed();
            document.getElementById("<%=HiddenSalarSummry.ClientID%>").value = document.getElementById("<%=HiddenAmountRngeChk.ClientID%>").value;
            
           document.getElementById("<%=ButtnSalryupd.ClientID%>").style.display = "block";
            document.getElementById("<%=ButtonAdd.ClientID%>").style.display = "none";
           
        }
        function SuccessConfirmationPayGradeUpd(x) {
           
            document.getElementById('divMessageAreaSalary').style.display = "";
            document.getElementById('imgMessageAreaSalary').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaSalary.ClientID%>").innerHTML = "Pay grade details updated successfully.";
                 //  ClearAllPaygrd();
                 // document.getElementById('cphMain_divAllnce').style.display = "block";
                 // document.getElementById('cphMain_divdedcn').style.display = "block";
            document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value = x;
            tableClick('divTblid6', cphMain_Tblid6);
                 //  LoadddlAllwncededctn();
                 document.getElementById("<%=ddlPayGrd.ClientID%>").value = x;
            LoadListPageallwnce();
                 // LoadListPageDed();
            document.getElementById("<%=HiddenSalarSummry.ClientID%>").value = document.getElementById("<%=HiddenAmountRngeChk.ClientID%>").value;
            
            document.getElementById("<%=ButtnSalryupd.ClientID%>").style.display = "block";
                 document.getElementById("<%=ButtonAdd.ClientID%>").style.display = "none";
           
             }
        
        function SuccessChangeStatus(AllwOrDed) {
            
            if(AllwOrDed == 0)
            {
                document.getElementById('divMessageAreaSalaryAllwc').style.display = "";
                document.getElementById('imgMessageAreaSalaryAllwc').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageAreaSalaryAllwc.ClientID%>").innerHTML = "Status changed successfully.";
            }
            else
            {
                document.getElementById('divMessageAreaSalaryDedctn').style.display = "";
                document.getElementById('imgMessageAreaSalaryDedctn').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageAreaSalaryDedctn.ClientID%>").innerHTML = "Status changed successfully.";
            }
        }
        // function SuccessCancelationDedctn() {
        // document.getElementById('divMessageAreaSalary').style.display = "";
        //  document.getElementById('imgMessageAreaSalary').src = "/Images/Icons/imgMsgAreaInfo.png";
        //  document.getElementById("<%=lblMessageAreaSalary.ClientID%>").innerHTML = "Deduction Cancelled Successfully.";
        //  tableClick('divTblid6', Tblid6);
        // }
        function ValidatePayGrade() {

            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            // HiddenPayGradechnge.Value="0";
            document.getElementById("<%=HiddenPayGradechnge.ClientID%>").value="0";
            var NameWithoutReplace = document.getElementById("<%=txtBasicpayFrm.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtBasicpayFrm.ClientID%>").value = replaceText2;
            // document.getElementById('SumryPayRng').innerHTML = replaceText2;

            //  document.getElementById("<%=HiddenSalarSummry.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtBasicpayFrm.ClientID%>").value;
            var AmntFrom = NameWithoutReplace.replace(/,/g, "");

            document.getElementById("<%=txtBasicpayFrm.ClientID%>").style.borderColor = "";

            document.getElementById("<%=ddlPayGrd.ClientID%>").style.borderColor = "";

            // var AmntFrom = document.getElementById("<%=txtBasicpayFrm.ClientID%>").value.trim();

            var varddlAddtn = document.getElementById("<%=ddlPayGrd.ClientID%>");
            var ddlAddtnText = varddlAddtn.options[varddlAddtn.selectedIndex].text;

            //Check for restriction AllwOrDed :0-SALRY RESTRCTION CHECK,1-ALLOWANCE RESTRCTION CHECK,2-DEDCTION RESTRCTION CHECK
            var RestrctedChk = 0, Restrcted = 0, AllwOrDed = 0;
            var RestrFrm, RestrTo;
            var Amountsummry;
            if (AmntFrom == "") {


                document.getElementById('divMessageAreaSalary').style.display = "";
                document.getElementById('imgMessageAreaSalary').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaSalary.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtBasicpayFrm.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtBasicpayFrm.ClientID%>").focus();
                ret = false;
              
            }
            else {

                document.getElementById("<%=txtBasicpayFrm.ClientID%>").style.borderColor = "";
            }
          
            if (AmntFrom != "") {

                if (ddlAddtnText != "--SELECT PAY GRADE--") {
                    // var ddlAddtnValue = varddlAddtn.options[varddlAddtn.selectedIndex].value;
                 
                    //CheckForRestriction(ddlAddtnValue, AllwOrDed);
                  
                    // waitSeconds(200);
             
              
                   
                    RestrctnChk = document.getElementById("<%=HiddenRestrctRange.ClientID%>").value;
                 
                    RestrctnChk = RestrctnChk.split(",");

                    if (RestrctnChk != "") {
                        RestrFrm = RestrctnChk[0];
                        RestrTo = RestrctnChk[1];
                        Restrcted = RestrctnChk[2];

                        if (parseFloat(AmntFrom) < parseFloat(RestrFrm) || parseFloat(AmntFrom) > parseFloat(RestrTo)) {
                           
                            RestrctedChk = 0;
                        }
                        else {
                           
                            RestrctedChk = 1;
                        }

                    }

                }
            }
            var retricted=false;
            if (RestrctedChk == 0) {
                if (Restrcted == 1) {
                    document.getElementById('divMessageAreaSalary').style.display = "";
                    document.getElementById('imgMessageAreaSalary').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaSalary.ClientID%>").innerHTML = "Basic pay should be in restricted range";
                    document.getElementById("<%=txtBasicpayFrm.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtBasicpayFrm.ClientID%>").focus();
                   
                    ret = false;
                }
                if (Restrcted == 0) {

                }
                //  retricted=true;
            }

            // if (AmntTo != "" && AmntFrom != "") {

            //    if (AmntTo < AmntFrom) {
            //        document.getElementById('divMessageArea').style.display = "";
            //         document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            //       document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "In Basic Pay Range,From Range Cannot exceed To Range.";
            //       document.getElementById("<%=txtBasicpayFrm.ClientID%>").style.borderColor = "Red";

            //        document.getElementById("<%=txtBasicpayFrm.ClientID%>").focus();
            //       ret = false;
            //   }

            // }

            if (ddlAddtnText == "--SELECT PAY GRADE--") {

                document.getElementById('divMessageAreaSalary').style.display = "";
                document.getElementById('imgMessageAreaSalary').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaSalary.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlPayGrd.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlPayGrd.ClientID%>").focus();
                ret = false;
            }
            if(ret==true)
            {
                if (ddlAddtnText != "--SELECT PAY GRADE--") {
                    var ddlPygrd = varddlAddtn.options[varddlAddtn.selectedIndex].value;
                    if( document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value!="" && document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value!=ddlPygrd)
                    {
              
                 
                
                        if (confirm("If you change the pay grade then the allowance and deduction reset accordingly, Do you really want to change ?")) {
                            document.getElementById("<%=HiddenPayGradechnge.ClientID%>").value="1";
                            ClearAddition();
                            ClearDedAll();
                            //  return true;
                            ret=true;
                        }
                        else
                        {
                            //    document.getElementById("<%=ddlPayGrd.ClientID%>").value=document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value;
                            ret=false;
                        }
                
            
                    }
                }
            
            }
            CheckSubmitZero();
            //SALARY DETAILS 0008
            if (ret == true) {
                Amountsummry = AmntFrom;
                document.getElementById("<%=HiddenAmountRngeChk.ClientID%>").value = Amountsummry;
                
                //document.getElementById('SumryPayRng').innerHTML = Amountsummry + "  " +  document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;

            }
            // if(retricted==true)
            return ret;
          
        }
        //SALARY DETAILS
        function SuccessConfirmationAllwnce(x) {

            document.getElementById('divMessageAreaSalaryAllwc').style.display = "";
            document.getElementById('imgMessageAreaSalaryAllwc').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaSalaryAllwc.ClientID%>").innerHTML = "Salary allowance details inserted successfully.";
            document.getElementById('cphMain_divAllnce').style.display = "block";
            document.getElementById('cphMain_divdedcn').style.display = "block";
            document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value = x;

            LoadListPageallwnce();
            //  LoadListPageDed();
            // LoadddlAllwncededctn();
            ClearAddition();
            tableClick('divTblid6', cphMain_Tblid6);
            document.getElementById("<%=ddlPayGrd.ClientID%>").focus();
            $(window).scrollTop(0);


        }
        function UpdatePayGradeAllwnce(x) {
            document.getElementById('divMessageAreaSalaryAllwc').style.display = "";
            document.getElementById('imgMessageAreaSalaryAllwc').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaSalaryAllwc.ClientID%>").innerHTML = "Allowance details updated successfully.";
            document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "block";
            document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "none";
            document.getElementById('cphMain_divAllnce').style.display = "block";
            document.getElementById('cphMain_divdedcn').style.display = "block";
            document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value = x;

            LoadListPageallwnce();
            //LoadListPageDed();
            //  LoadddlAllwncededctn();
            ClearAddition();
            tableClick('divTblid6', cphMain_Tblid6);
            document.getElementById("<%=ddlPayGrd.ClientID%>").focus();
            $(window).scrollTop(0);
        }

        //evm-0023-20-2
        function DuplicationSalaryAllwnce() {
            document.getElementById('divMessageAreaSalaryAllwc').style.display = "block";
            document.getElementById('imgMessageAreaSalaryAllwc').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaSalaryAllwc.ClientID%>").innerHTML = "Duplication error.Salary allowance can't be duplicated.";
            document.getElementById("<%=ddlAddtn.ClientID%>").style.borderColor = "Red";
            tableClick('divTblid6', cphMain_Tblid6);
            document.getElementById("<%=ddlPayGrd.ClientID%>").focus();

            document.getElementById("lblErrDupAllwnc").style.display = "block";

            if(document.getElementById("<%=rdbAllwcAmt.ClientID%>").checked)
            {
                RadioAmountClickAllwc();
            }
           else
            {
                RadioPerClickAllwc();
            }


            $(window).scrollTop(0);
        }

        //evm-0023-20-2
        function SuccessCancelationAllwnce() {
            document.getElementById('divMessageAreaSalaryAllwc').style.display = "";
            document.getElementById('imgMessageAreaSalaryAllwc').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaSalaryAllwc.ClientID%>").innerHTML = "Allowance cancelled successfully.";
            // document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value = x;
            LoadListPageallwnce();
            // LoadListPageDed();
            //LoadddlAllwncededctn();
            tableClick('divTblid6', cphMain_Tblid6);
            document.getElementById("<%=ddlPayGrd.ClientID%>").focus();
            ClearAddition();
            $(window).scrollTop(0);
        }
        //evm-0023-20-2
        function ClearAddition() {
            document.getElementById("<%=ddlAddtn.ClientID%>").selectedIndex = 0;
            document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value = "";
            document.getElementById("<%=txtPerctgAllwnc.ClientID%>").value = "";


        }
        //evm-0023-20-2
        function AlertClearAddition() {
            if (confirmboxSalryAllwnce > 0) {
                if (confirm("Are you sure you want clear all data in this section?")) {
                    // window.location.href = "gen_Bank_Guarantee.aspx";
                    document.getElementById("<%=ddlAddtn.ClientID%>").selectedIndex = 0;
                    document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value = "";
                    document.getElementById("<%=txtPerctgAllwnc.ClientID%>").value = "";
                    document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "block";

                    
                    document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "none";

                    document.getElementById("cphMain_rdbAllwcAmt").disabled = false;
                    document.getElementById("cphMain_rdbAllwcPerc").disabled = false;
                    document.getElementById("cphMain_rdbAllwcPerc").checked = true;


                    document.getElementById("idRestrctnRangePercAllwnc").innerHTML = "";
                    document.getElementById("AllowRestrctrang").innerHTML = "";
                    document.getElementById("divPyrollTypAllwc").style.display = "none";
                    document.getElementById("divPyrollTypDedctn").style.display = "none";

                    
                    document.getElementById("<%=ddlAddtn.ClientID%>").style.borderColor = "";

                    document.getElementById("divMessageAreaSalaryAllwc").style.display = "none";

                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                //window.location.href = "gen_Bank_Guarantee.aspx";
                document.getElementById("<%=ddlAddtn.ClientID%>").selectedIndex = 0;
                document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value = "";
                document.getElementById("<%=txtPerctgAllwnc.ClientID%>").value = "";

                document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "block";
                document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "none";

                document.getElementById("cphMain_rdbAllwcAmt").disabled = false;
                document.getElementById("cphMain_rdbAllwcPerc").disabled = false;
                document.getElementById("cphMain_rdbAllwcPerc").checked = true;

                document.getElementById("idRestrctnRangePercAllwnc").innerHTML = "";
                document.getElementById("AllowRestrctrang").innerHTML = "";
                document.getElementById("divPyrollTypAllwc").style.display = "none";
                document.getElementById("divPyrollTypDedctn").style.display = "none";
                document.getElementById("<%=ddlAddtn.ClientID%>").style.borderColor = "";

                document.getElementById("divMessageAreaSalaryAllwc").style.display = "none";
                return false;
            }
        }

        //evm-0023-20-2
        function ValidateAllwnce() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value = replaceText2;



            var NameWithoutReplace = document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value;
            var AmntFrom = NameWithoutReplace.replace(/,/g, "");

            document.getElementById("<%=txtAmntRgeFrm.ClientID%>").style.borderColor = "";
            document.getElementById('DivPaygrd').style.borderColor = "";
            document.getElementById("<%=txtAmntRgeFrm.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlAddtn.ClientID%>").style.borderColor = "";
            // var AmntFrom = document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value.trim();

            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtPerctgAllwnc.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtPerctgAllwnc.ClientID%>").value = replaceText2;



            var NameWithoutReplace = document.getElementById("<%=txtPerctgAllwnc.ClientID%>").value;
            var Percentage = NameWithoutReplace.replace(/,/g, "");

            document.getElementById("<%=txtPerctgAllwnc.ClientID%>").style.borderColor = "";
            document.getElementById('DivPaygrd').style.borderColor = "";
            document.getElementById("<%=txtPerctgAllwnc.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlAddtn.ClientID%>").style.borderColor = "";



            var varddlAddtn = document.getElementById("<%=ddlAddtn.ClientID%>");
            var ddlAddtnText = varddlAddtn.options[varddlAddtn.selectedIndex].text;


            //Check for restriction AllwOrDed :0-SALRY RESTRCTION CHECK,1-ALLOWANCE RESTRCTION CHECK,2-DEDCTION RESTRCTION CHECK
            var RestrctedChk = 0, Restrcted = 0, AllwOrDed = 1;
            var RestrFrm, RestrTo;
            if (document.getElementById("<%=rdbAllwcAmt.ClientID%>").checked == true)
            {
                if (AmntFrom == "") {
                    document.getElementById('divMessageAreaSalaryAllwc').style.display = "";
                    document.getElementById('imgMessageAreaSalaryAllwc').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaSalaryAllwc.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtAmntRgeFrm.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtAmntRgeFrm.ClientID%>").focus();
                 ret = false;
                }
               else {

                      document.getElementById("<%=txtAmntRgeFrm.ClientID%>").style.borderColor = "";
                }

                
                if (AmntFrom != "") {

                    if (ddlAddtnText != "--SELECT SALARY ADDITION--") {
                        var ddlAddtnValue = varddlAddtn.options[varddlAddtn.selectedIndex].value;

                        document.getElementById("<%=HiddenddlAllDed.ClientID%>").value = ddlAddtnValue;

                    // CheckForRestriction(ddlAddtnValue, AllwOrDed);
                    var RestrctnChk = document.getElementById("<%=HiddenRestrctRangeAllw.ClientID%>").value;
                 
                      

                    RestrctnChk = RestrctnChk.split(",");
                    
                    if (RestrctnChk != "") {
                        RestrFrm = RestrctnChk[0];
                        RestrTo = RestrctnChk[1];
                        Restrcted = RestrctnChk[2];

                        if (parseFloat(AmntFrom) < parseFloat(RestrFrm) || parseFloat(AmntFrom) > parseFloat(RestrTo)) {
                            RestrctedChk = 0;
                        }
                        else {

                            RestrctedChk = 1;
                        }

                    }

                }
                }

                if (RestrctedChk == 0) {                 
                    if (Restrcted == 1) {
                        document.getElementById('divMessageAreaSalaryAllwc').style.display = "";
                        document.getElementById('imgMessageAreaSalaryAllwc').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageAreaSalaryAllwc.ClientID%>").innerHTML = "Amount should be in restricted range";
                    document.getElementById("<%=txtAmntRgeFrm.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtAmntRgeFrm.ClientID%>").focus();
                    ret = false;
                }
                if (Restrcted == 0) {

                }
            }
            }

            if (document.getElementById("<%=rdbAllwcPerc.ClientID%>").checked == true)
            {

                if (Percentage == "") {
                    document.getElementById('divMessageAreaSalaryAllwc').style.display = "";
                    document.getElementById('imgMessageAreaSalaryAllwc').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaSalaryAllwc.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtPerctgAllwnc.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtPerctgAllwnc.ClientID%>").focus();
                    ret = false;
                }
                else {

                    document.getElementById("<%=txtPerctgAllwnc.ClientID%>").style.borderColor = "";
                }



                if (Percentage != "") {

                    if (ddlAddtnText != "--SELECT SALARY ADDITION--") {
                        var ddlAddtnValue = varddlAddtn.options[varddlAddtn.selectedIndex].value;

                        document.getElementById("<%=HiddenddlAllDed.ClientID%>").value = ddlAddtnValue;

                        // CheckForRestriction(ddlAddtnValue, AllwOrDed);
                        var RestrctnChkPerc = document.getElementById("<%=HiddenRestrctRangeAllw.ClientID%>").value;
                 
                        RestrctnChkPerc = RestrctnChkPerc.split(",");

                        if (RestrctnChkPerc != "") {
                            RestrFrm = RestrctnChkPerc[0];
                            RestrTo = RestrctnChkPerc[1];
                            Restrcted = RestrctnChkPerc[2];

                            if (parseFloat(Percentage) < parseFloat(RestrFrm) || parseFloat(Percentage) > parseFloat(RestrTo)) {                               
                                RestrctedChk = 0;
                            }
                            else {

                                RestrctedChk = 1;
                            }

                        }

                    }
                }
          

               

                if (RestrctedChk == 0) {
                    if (Restrcted == 1) {
                        document.getElementById('divMessageAreaSalaryAllwc').style.display = "";
                        document.getElementById('imgMessageAreaSalaryAllwc').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageAreaSalaryAllwc.ClientID%>").innerHTML = "Percentage should be in restricted range";
                        document.getElementById("<%=txtPerctgAllwnc.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtPerctgAllwnc.ClientID%>").focus();
                        ret = false;
                    }
                    if (Restrcted == 0) {

                    }
                }
            }
            if (ddlAddtnText == "--SELECT SALARY ADDITION--") {

                document.getElementById('divMessageAreaSalaryAllwc').style.display = "";
                document.getElementById('imgMessageAreaSalaryAllwc').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaSalaryAllwc.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlAddtn.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlAddtn.ClientID%>").focus();
                ret = false;
            }
            else
            {
                var ddlAddtnValues = varddlAddtn.options[varddlAddtn.selectedIndex].value;

                document.getElementById("<%=HiddenddlAllDed.ClientID%>").value = ddlAddtnValues;
            }
         
            if (document.getElementById("<%=HiddenEmpSalryId.ClientID%>").value == "") {
                document.getElementById('divMessageAreaSalaryAllwc').style.display = "";
                document.getElementById('imgMessageAreaSalaryAllwc').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaSalaryAllwc.ClientID%>").innerHTML = "Please add salary section to proceed.";
                document.getElementById('DivPaygrd').style.borderColor = "Red";
                document.getElementById("<%=ddlPayGrd.ClientID%>").focus();
                ret = false;
            }
            CheckSubmitZero();
            return ret;
        }
        function SuccessConfirmationDedctn(x) {
            document.getElementById('divMessageAreaSalaryDedctn').style.display = "";
            document.getElementById('imgMessageAreaSalaryDedctn').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaSalaryDedctn.ClientID%>").innerHTML = "Salary deduction details inserted successfully.";

            document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value = x;
            document.getElementById('cphMain_divAllnce').style.display = "block";
            document.getElementById('cphMain_divdedcn').style.display = "block";

            LoadListPageallwnce();
            // LoadListPageDed();
            // LoadddlAllwncededctn();
            ClearDedAll();
            tableClick('divTblid6', cphMain_Tblid6);
            document.getElementById("<%=ddlPayGrd.ClientID%>").focus();
            $(window).scrollTop(0);
        }
        function DuplicationSalaryDedctn() {
            document.getElementById('divMessageAreaSalaryDedctn').style.display = "";
            document.getElementById('imgMessageAreaSalaryDedctn').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaSalaryDedctn.ClientID%>").innerHTML = "Duplication error.Salary deduction can't be duplicated.";
            document.getElementById("<%=ddldedctn.ClientID%>").style.borderColor = "Red";
            tableClick('divTblid6', cphMain_Tblid6);
            document.getElementById("<%=ddlPayGrd.ClientID%>").focus();
           if(document.getElementById("<%=radAmnt.ClientID%>").checked)
            {
                RadioAmountClick();
            }
            else
            {
                RadioPerClick();
            }
            $(window).scrollTop(0);
        }
        function SuccessCancelationDedctn() {
            document.getElementById('divMessageAreaSalaryDedctn').style.display = "";
            document.getElementById('imgMessageAreaSalaryDedctn').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaSalaryDedctn.ClientID%>").innerHTML = "Deduction cancelled successfully.";
            // document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value = x;
            ClearDedAll();
            LoadListPageallwnce();
            // LoadListPageDed();
            // LoadddlAllwncededctn();
            tableClick('divTblid6', cphMain_Tblid6);
            document.getElementById("<%=ddlPayGrd.ClientID%>").focus();
            $(window).scrollTop(0);
        }
        function UpdatePayGradeDedctn(x) {
          
            document.getElementById('divMessageAreaSalaryDedctn').style.display = "";
            document.getElementById('imgMessageAreaSalaryDedctn').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaSalaryDedctn.ClientID%>").innerHTML = "Deduction details updated successfully.";
            document.getElementById("<%=SaveDedctn.ClientID%>").style.display = "block";
            document.getElementById("<%=UpdateDedctn.ClientID%>").style.display = "none";
            document.getElementById('cphMain_divAllnce').style.display = "block";
            document.getElementById('cphMain_divdedcn').style.display = "block";
            document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value = x;
            ClearDedAll();
            LoadListPageallwnce();
            //LoadListPageDed();
            //  LoadddlAllwncededctn();
             
            
            tableClick('divTblid6', cphMain_Tblid6);
            document.getElementById("<%=ddlPayGrd.ClientID%>").focus();
          
            $(window).scrollTop(0);
        }
        function AlertClearDedAll() {
            if (confirmboxSalryDedctn > 0) {
                if (confirm("Are You Sure You Want Clear All Data In This Section?")) {
                    // window.location.href = "gen_Bank_Guarantee.aspx";
                    document.getElementById("<%=ddldedctn.ClientID%>").selectedIndex = 0;
                    document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value = "";


                    document.getElementById("<%=txtperctg.ClientID%>").value = "";


                    document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = true;
                    document.getElementById("<%=radPercntge.ClientID%>").checked = true;

                    document.getElementById("<%=SaveDedctn.ClientID%>").style.display = "block";
                    document.getElementById("<%=UpdateDedctn.ClientID%>").style.display = "none";
                    document.getElementById("<%=ddldedctn.ClientID%>").style.borderColor = "";
                    document.getElementById("divMessageAreaSalaryDedctn").style.display = "none";


                    RadioPerClick();

                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                //window.location.href = "gen_Bank_Guarantee.aspx";
                document.getElementById("<%=ddldedctn.ClientID%>").selectedIndex = 0;
                document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value = "";


                document.getElementById("<%=txtperctg.ClientID%>").value = "";


                document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = true;
                document.getElementById("<%=radPercntge.ClientID%>").checked = true;

                document.getElementById("<%=SaveDedctn.ClientID%>").style.display = "block";
                document.getElementById("<%=UpdateDedctn.ClientID%>").style.display = "none";

                document.getElementById("<%=ddldedctn.ClientID%>").style.borderColor = "";
                document.getElementById("divMessageAreaSalaryDedctn").style.display = "none";
                RadioPerClick();
                return false;
            }
        }

        function ClearDedAll() {
            document.getElementById("<%=ddldedctn.ClientID%>").selectedIndex = 0;
            document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value = "";
            document.getElementById("<%=txtperctg.ClientID%>").value = "";

            document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = true;
            document.getElementById("<%=radPercntge.ClientID%>").checked = true;
            RadioPerClick();

        }

        //evm-0023-20-2
        //SALARY DETAILS
        function ValidateDedctn(buttnId) {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            
            var NameWithoutReplace = document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value = replaceText2;


            var NameWithoutReplace = document.getElementById("<%=txtperctg.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtperctg.ClientID%>").value = replaceText2;


            var NameWithoutReplace = document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value;
            var AmntFrom = NameWithoutReplace.replace(/,/g, "");


            var NameWithoutReplace = document.getElementById("<%=txtperctg.ClientID%>").value;
            var Perctge = NameWithoutReplace.replace(/,/g, "");

            document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").style.borderColor = "";
                document.getElementById("<%=ddldedctn.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtperctg.ClientID%>").style.borderColor = "";
            document.getElementById('DivPaygrd').style.borderColor = "";
            // var AmntFrom = document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value.trim();


            var varddlAddtn = document.getElementById("<%=ddldedctn.ClientID%>");
            var ddlDedctnText = varddlAddtn.options[varddlAddtn.selectedIndex].text;

          


            //Check for restriction AllwOrDed :0-SALRY RESTRCTION CHECK,1-ALLOWANCE RESTRCTION CHECK,2-DEDCTION RESTRCTION CHECK
            var RestrctedChk = 0, Restrcted = 0, AllwOrDed = 2;
            var RestrFrm, RestrTo;
            if (document.getElementById("<%=radAmnt.ClientID%>").checked == true) {
                if (AmntFrom == "") {


                    document.getElementById('divMessageAreaSalaryDedctn').style.display = "";
                    document.getElementById('imgMessageAreaSalaryDedctn').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaSalaryDedctn.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").focus();
                        ret = false;
                    }
                    else {

                        document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").style.borderColor = "";
                    }

                    if (AmntFrom != "") {

                        if (ddlDedctnText != "--SELECT SALARY DEDUCTION--") {
                            var ddlAddtnValue = varddlAddtn.options[varddlAddtn.selectedIndex].value;

                            document.getElementById("<%=HiddenddlAllDed.ClientID%>").value = ddlAddtnValue;
                           
                    
                        // CheckForRestriction(ddlAddtnValue, AllwOrDed);
                        var RestrctnChk = document.getElementById("<%=HiddenRestrctRangeDedctn.ClientID%>").value;
                        RestrctnChk = RestrctnChk.split(",");

                        if (RestrctnChk != "") {
                            RestrFrm = RestrctnChk[0];
                            RestrTo = RestrctnChk[1];
                            Restrcted = RestrctnChk[2];

                            if (parseFloat(AmntFrom) < parseFloat(RestrFrm) || parseFloat(AmntFrom) > parseFloat(RestrTo)) {
                                RestrctedChk = 0;
                            }
                            else {

                                RestrctedChk = 1;
                            }

                        }

                    }
                }


                if (RestrctedChk == 0) {
                    if (Restrcted == 1) {
                        document.getElementById('divMessageAreaSalaryDedctn').style.display = "";
                        document.getElementById('imgMessageAreaSalaryDedctn').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageAreaSalaryDedctn.ClientID%>").innerHTML = "Amount should be in restricted range";
                        document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").focus();
                        ret = false;
                    }
                    if (Restrcted == 0) {

                    }
                }




            }
            else if (document.getElementById("<%=radPercntge.ClientID%>").checked == true) {
                if (Perctge == "") {
                    document.getElementById('divMessageAreaSalaryDedctn').style.display = "";
                    document.getElementById('imgMessageAreaSalaryDedctn').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaSalaryDedctn.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById("<%=txtperctg.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtperctg.ClientID%>").focus();
                        ret = false;
                    }
                    else
                    {
                        if (parseFloat(Perctge) > parseFloat(100))
                        {
                       
                            document.getElementById('divMessageAreaSalaryDedctn').style.display = "";
                            document.getElementById('divMessageAreaSalaryDedctn').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageAreaSalaryDedctn.ClientID%>").innerHTML = "Percentage should not exceed hundred.";
                        document.getElementById("<%=txtperctg.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtperctg.ClientID%>").focus();
                        ret = false;
                    }
                    else
                    {
                        var perTotalChek=0;
                     
                        var PerTotal= parseFloat(document.getElementById("<%=HiddenTotalPerTotal.ClientID%>").value);
                      
                        var PerBasic= parseFloat(document.getElementById("<%=HiddenTotalPerBasic.ClientID%>").value);
                      
                        // perTotalChek=parseFloat(PerTotal)+parseFloat(PerBasic)+parseFloat(Perctge) ;
                      
                        if(buttnId=='UpdateDedctn')
                        {
                            
                            perTotalChek=parseFloat(PerTotal)+parseFloat(PerBasic)-parseFloat(Perctge) ;
                           
                        }
                        else if(buttnId=='SaveDedctn')
                        {
                           
                            perTotalChek=parseFloat(PerTotal)+parseFloat(PerBasic)+parseFloat(Perctge) ;
                           
                        }
                        if(parseFloat(perTotalChek)>parseFloat(100))
                        {
                            document.getElementById('divMessageAreaSalaryDedctn').style.display = "";
                            document.getElementById('imgMessageAreaSalaryDedctn').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageAreaSalaryDedctn.ClientID%>").innerHTML = "Sum of percentage in deduction should be less than or equal to hundred.";
                            document.getElementById("<%=txtperctg.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtperctg.ClientID%>").focus();
                            ret = false;
                        }




                            if (Perctge != "") {
 
                                if (ddlDedctnText != "--SELECT SALARY DEDUCTION--") {
                                    var ddlAddtnValue = varddlAddtn.options[varddlAddtn.selectedIndex].value;

                                    document.getElementById("<%=HiddenddlAllDed.ClientID%>").value = ddlAddtnValue;
                           
                    
                            // CheckForRestriction(ddlAddtnValue, AllwOrDed);
                            var RestrctnChk = document.getElementById("<%=HiddenRestrctRangeDedctn.ClientID%>").value;
                            RestrctnChk = RestrctnChk.split(",");

                            if (RestrctnChk != "") {
                                RestrFrm = RestrctnChk[0];
                                RestrTo = RestrctnChk[1];
                                Restrcted = RestrctnChk[2];

                                if (parseFloat(Perctge) < parseFloat(RestrFrm) || parseFloat(Perctge) > parseFloat(RestrTo)) {
                                    RestrctedChk = 0;
                                }
                                else {

                                    RestrctedChk = 1;
                                }

                            }

                        }
                    }

                      if (RestrctedChk == 0) {
                         if (Restrcted == 1) {
                             document.getElementById('divMessageAreaSalaryDedctn').style.display = "";
                             document.getElementById('imgMessageAreaSalaryDedctn').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageAreaSalaryDedctn.ClientID%>").innerHTML = "Percentage should be in restricted range";
                        document.getElementById("<%=txtperctg.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtperctg.ClientID%>").focus();
                        ret = false;
                    }
                    if (Restrcted == 0) {

                    }
                }


                    }
                }
            }
        if (ddlDedctnText == "--SELECT SALARY DEDUCTION--") {


            document.getElementById("<%=HiddenddlAllDed.ClientID%>").value = ddlAddtnValue;
            document.getElementById('divMessageAreaSalaryDedctn').style.display = "";
            document.getElementById('imgMessageAreaSalaryDedctn').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageAreaSalaryDedctn.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
            document.getElementById("<%=ddldedctn.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=ddldedctn.ClientID%>").focus();
            ret = false;
        }
        else {
            var ddlAddtnValues = varddlAddtn.options[varddlAddtn.selectedIndex].value;

            document.getElementById("<%=HiddenddlAllDed.ClientID%>").value = ddlAddtnValues;
        }

        if (document.getElementById("<%=HiddenEmpSalryId.ClientID%>").value == "") {
            document.getElementById('divMessageAreaSalaryDedctn').style.display = "";
            document.getElementById('imgMessageAreaSalaryDedctn').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaSalaryDedctn.ClientID%>").innerHTML = "Please add salary section to proceed.";
                document.getElementById('DivPaygrd').style.borderColor = "Red";
                document.getElementById("<%=ddlPayGrd.ClientID%>").focus();
                    ret = false;
                }
                CheckSubmitZero();
                return ret;

            }
            var $noConf = jQuery.noConflict();



            //evm-0023-20-2

            function CheckForRestriction(ddlAddtnValue, AllwOrDed) {
                
                //For Salary Allowance Message
                document.getElementById('divMessageAreaSalaryAllwc').style.display = "none";
                document.getElementById('imgMessageAreaSalaryAllwc').src = "";
                document.getElementById("<%=lblMessageAreaSalaryAllwc.ClientID%>").innerHTML = "";

                //For Salary Deduction Message
                document.getElementById('divMessageAreaSalaryDedctn').style.display = "none";
                document.getElementById('imgMessageAreaSalaryDedctn').src = "";
                document.getElementById("<%=lblMessageAreaSalaryDedctn.ClientID%>").innerHTML = "";

                document.getElementById("<%=radAmnt.ClientID%>").disabled=false;
                document.getElementById("<%=radPercntge.ClientID%>").disabled=false;


                document.getElementById("divPyrollTypAllwc").style.display = "none";
                document.getElementById("divPyrollTypDedctn").style.display = "none";





                var Orgid = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
            var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;

                var Details = PageMethods.CheckForRestriction(ddlAddtnValue, Orgid, CorpId, AllwOrDed, function (response) {
                //  alert(response.Amnt);
                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                 var baicrange=response.Amnt.split(",");
                 if (AllwOrDed == "0")
                 {
                     document.getElementById("<%=HiddenRestrctRange.ClientID%>").value = response.Amnt;
                   
                    document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value = response.strCurrcAbbrv;
                    var RestrctedChk=response.RestrctSts;

                    var r1 = parseFloat(baicrange[0]).toFixed(FloatingValue);
                    var r2 = parseFloat(baicrange[1]).toFixed(FloatingValue);
                    addCommasSummry(r1);
                    r1 = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                    addCommasSummry(r2);
                    r2 = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                    document.getElementById("cphMain_BasicRestrctrang").innerHTML=r1+" - "+r2+"  "+document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
             

                    if (RestrctedChk == 1) {
                        document.getElementById("cphMain_IdRestrctdRngBasic").innerHTML="Restricted Range";

                        $noConf("#cphMain_BasicRestrctrang").css({
                            'margin-left':16.5+'%'
                        });
                    }
                    else if (RestrctedChk == 0){
                        document.getElementById("cphMain_IdRestrctdRngBasic").innerHTML="Amount Range";

                        $noConf("#cphMain_BasicRestrctrang").css({
                            'margin-left':17.5+'%'
                        });
                    }
                }
                 if (AllwOrDed == "1")
                 {
                     var r1 = parseFloat(baicrange[0]).toFixed(FloatingValue);
                     var r2 = parseFloat(baicrange[1]).toFixed(FloatingValue);
                     addCommasSummry(r1);
                     r1 = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                    addCommasSummry(r2);
                    r2 = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;


                     if(response.PerOrAmntck == 0)
                     {
                         document.getElementById("<%=rdbAllwcAmt.ClientID%>").checked=true;
                         document.getElementById("<%=rdbAllwcAmt.ClientID%>").disabled=false;

                         document.getElementById("<%=rdbAllwcPerc.ClientID%>").disabled=true;
                         document.getElementById("divAmtClkAllwnc").style.display="block";
                         document.getElementById("divPerClkAllwnc").style.display="none";
                         document.getElementById("AllowRestrctrang").innerHTML=r1+" - "+r2+"  "+document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
                     }
                     else
                     {
                         document.getElementById("<%=rdbAllwcPerc.ClientID%>").checked=true;
                         document.getElementById("<%=rdbAllwcPerc.ClientID%>").disabled=false;

                         document.getElementById("<%=rdbAllwcAmt.ClientID%>").disabled=true;
                         document.getElementById("divAmtClkAllwnc").style.display="none";
                         document.getElementById("divPerClkAllwnc").style.display="block";
                         document.getElementById("idRestrctnRangePercAllwnc").innerHTML=r1+"% - "+r2+"%";
                     }
                    
                     document.getElementById("<%=HiddenRestrctRangeAllw.ClientID%>").value = response.Amnt;

                     if(response.PayrolTypSts == 0)
                     {
                         document.getElementById("divPyrollTypAllwc").style.display = "block";
                         document.getElementById("idPyrollTypAllwc").innerHTML = "Fixed";
                     }
                     else
                     {
                         document.getElementById("divPyrollTypAllwc").style.display = "block";

                         document.getElementById("idPyrollTypAllwc").innerHTML = "Variable";
                     }
                     
     
                }
                 if (AllwOrDed == "2")
                 {         
                   
                     var r1 = parseFloat(baicrange[0]).toFixed(FloatingValue);
                     var r2 = parseFloat(baicrange[1]).toFixed(FloatingValue);
                     addCommasSummry(r1);
                     r1 = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                    addCommasSummry(r2);
                    r2 = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                     
                     if(response.PerOrAmntck == 0)
                     {
                         document.getElementById("<%=radAmnt.ClientID%>").checked=true;
                         document.getElementById("<%=radPercntge.ClientID%>").disabled=true;
                         document.getElementById("divAmtClk").style.display="block";
                         document.getElementById("divperclk").style.display="none";
                         document.getElementById("DedctnRestrctrang").innerHTML=r1+" - "+r2+"  "+document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
                     }
                     else
                     {
                         document.getElementById("<%=radPercntge.ClientID%>").checked=true;

                         document.getElementById("<%=radAmnt.ClientID%>").disabled=true;
                         document.getElementById("divperclk").style.display="block";
                         document.getElementById("divAmtClk").style.display="none";
                         document.getElementById("idDedRestrctnRangePerc").innerHTML=r1+"% - "+r2+"%";
                     }

                     
                     document.getElementById("<%=HiddenRestrctRangeDedctn.ClientID%>").value = response.Amnt;

                     if(response.PayrolTypSts == 0)
                     {
                         document.getElementById("divPyrollTypDedctn").style.display = "block";
                         document.getElementById("idPyrollTypDedctn").innerHTML = "Fixed";
                     }
                     else
                     {
                         document.getElementById("divPyrollTypDedctn").style.display = "block";
                         document.getElementById("idPyrollTypDedctn").innerHTML = "Variable";
                     }

                }
                 //return true;
             });
      
        }

          //evm-0023-20-2


        function LoadddlAllwncededctn() {

            var $Mo = jQuery.noConflict();
            var varddlAddtn = document.getElementById("<%=ddlPayGrd.ClientID%>");
            var ddlpygdeValue = varddlAddtn.options[varddlAddtn.selectedIndex].value;
            
            var Orgid = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
        
               var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
          
            var tableName = "dtTableAllwnce";
            var Details = PageMethods.Loadallwceddl(ddlpygdeValue, Orgid, CorpId, function (response) {


                var OptionStart = $Mo("<option>--SELECT SALARY ADDITION--</option>");

                OptionStart.attr("value", 0);
                $Mo('#<%=ddlAddtn.ClientID%>').empty();
                   $Mo('#<%=ddlAddtn.ClientID%>').append(OptionStart);

                   // Now find the Table from response and loop through each item (row).
                   $Mo(response).find(tableName).each(function () {
                       // Get the OptionValue and OptionText Column values.
                       var OptionValue = $Mo(this).find('PGALLCE_ID').text();
                       var OptionText = $Mo(this).find('PAYRL_NAME').text();
                       // Create an Option for DropDownList.
                       var option = $Mo("<option>" + OptionText + "</option>");
                       option.attr("value", OptionValue);
                       $Mo('#<%=ddlAddtn.ClientID%>').append(option);

            });
                   // return false;
               });
        LoadDedctionddl();
    }

    function LoadDedctionddl() {

        var $Mo = jQuery.noConflict();
        var varddlAddtn = document.getElementById("<%=ddlPayGrd.ClientID%>");
               var ddlpygdeValue = varddlAddtn.options[varddlAddtn.selectedIndex].value;
               var Orgid = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
               var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
               var tableName = "dtTableDedctn";
               var Details = PageMethods.LoadDedctionddl(ddlpygdeValue, Orgid, CorpId, function (response) {


                   var OptionStart = $Mo("<option>--SELECT SALARY DEDCTION--</option>");

                   OptionStart.attr("value", 0);
                   $Mo('#<%=ddldedctn.ClientID%>').empty();
                   $Mo('#<%=ddldedctn.ClientID%>').append(OptionStart);

                   // Now find the Table from response and loop through each item (row).
                   $Mo(response).find(tableName).each(function () {
                       // Get the OptionValue and OptionText Column values.
                       var OptionValue = $Mo(this).find('PGDEDTN_ID').text();
                       var OptionText = $Mo(this).find('PAYRL_NAME').text();
                       // Create an Option for DropDownList.
                       var option = $Mo("<option>" + OptionText + "</option>");

                       option.attr("value", OptionValue);

                       $Mo('#<%=ddldedctn.ClientID%>').append(option);

                });
                   // return false;
               });
        }

        function LoadListPageallwnce() {
               
          
            var toatlpay=0;
            var EnableCanl = document.getElementById("<%=HiddnEnableCacel.ClientID%>").value;
          
                var CurrcyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
          
                var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
         
                var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
         
                var varddlAddtn = document.getElementById("<%=HiddenEmployeeMasterId.ClientID%>").value;
          

                var Details = PageMethods.LoadListPageallwncee(EnableCanl, CurrcyId, CorpId, OrgId, varddlAddtn, function (response) {

                    // alert(response);
                    //  reporttable();

                    document.getElementById('cphMain_divAllwList').innerHTML = response.strhtml;
               
                    //document.getElementById('SumryAdtnRng').innerHTML = response.strSummry;
                    // parseFloat(document.getElementById("<%=HiddenTotalpay.ClientID%>").value);
                    if (response.strSummry != "") {
                   
                        var n,n1;
                        var num = response.strSummry;
                        var sumry = num;
                        var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

                    if (FloatingValue != "") {
                        sumry = sumry.replace(/,/g, "");
                          
                        n = parseFloat(sumry).toFixed(FloatingValue);
                        toatlpay= parseFloat(n);
                        addCommasSummry(n);
                        n = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                          
                          
                          
                    }
                    document.getElementById('SumryAdtnRng').innerHTML = n + "  " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
                   
                    // alert(toatlpay+"1s");
                    document.getElementById("<%=HiddenTotalpay.ClientID%>").value=toatlpay;
                    LoadListPageDed();
                          
                        
                }
                else {
                    document.getElementById('SumryAdtnRng').innerHTML = response.strSummry;
                    document.getElementById("<%=HiddenTotalpay.ClientID%>").value=toatlpay;
                }
               
                    var Finaltotalpay=document.getElementById("<%=HiddenSalarSummry.ClientID%>").value;
           
                    //  Finaltotalpay=Finaltotalpay.replace(/,/g, "");
                    // Finaltotalpay=parseFloat(Finaltotalpay)+parseFloat(document.getElementById("<%=HiddenTotalpay.ClientID%>").value);
         
                    // document.getElementById('SumryTotalpay').innerHTML =Finaltotalpay+" "+document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;;
                    // alert( document.getElementById("<%=HiddenTotalpay.ClientID%>").value);
                });
                waitSeconds(100);
                // setTimeout(LoadListPageDed(),5000);
                LoadListPageDed();
            }

            function LoadListPageDed() {
                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                var basicpay=parseFloat(document.getElementById("<%=HiddenSalarSummry.ClientID%>").value);
           
                var toatlpay=0,vardedctn=0;
                var EnableCanl = document.getElementById("<%=HiddnEnableCacel.ClientID%>").value;
            var CurrcyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
                var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
                var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                var varddlAddtn = document.getElementById("<%=HiddenEmployeeMasterId.ClientID%>").value;
                var Details = PageMethods.LoadListPageDed(EnableCanl, CurrcyId, CorpId, OrgId, varddlAddtn, function (response) {

                    // alert(response);
                    // reporttables();


                    document.getElementById('cphMain_divList').innerHTML = response.strhtml;
                 
                    document.getElementById("<%=HiddenTotalPerTotal.ClientID%>").value=response.strPerFromTotal;
                document.getElementById("<%=HiddenTotalPerBasic.ClientID%>").value=response.strPerFromBasic;
               
              
                //document.getElementById('SumryDedctnRng').innerHTML = response.strSummry;
           
                //=parseFloat(document.getElementById("<%=HiddenTotalpay.ClientID%>").value);
                
            
                if (response.strSummry != "") {
                    var n,n1;
                    var num = response.strSummry;
                    var sumry = num;
                    FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

                    if (FloatingValue != "") {
                        sumry = sumry.replace(/,/g, "");
                        vardedctn=sumry;
                        n = parseFloat(sumry).toFixed(FloatingValue);
                        toatlpay= parseFloat(n);
                        addCommasSummry(n);
                        n = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                          
                        // Substractdedctn(vardedctn);
                          
                    }
                    document.getElementById('SumryDedctnRng').innerHTML = n + "  " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
                    Substractdedctn(vardedctn);
                 
                    // alert(parseFloat(n));
                  
                    //alert(toatlpay);
                    document.getElementById("<%=HiddenTotalpayAllw.ClientID%>").value=parseFloat(0)+toatlpay;
                }
                else {
                   
                    document.getElementById('SumryDedctnRng').innerHTML = response.strSummry;
                    document.getElementById("<%=HiddenTotalpayAllw.ClientID%>").value=parseFloat(toatlpay)+parseFloat(0);
                }
               
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
           
                //DataTable
                //  ReportTable
            });
                // waitSeconds(100);
            var Finaltotalpay=document.getElementById("<%=HiddenSalarSummry.ClientID%>").value;
          
            
                Finaltotalpay=parseFloat(Finaltotalpay)+parseFloat(document.getElementById("<%=HiddenTotalpay.ClientID%>").value);
            
                // alert(document.getElementById("<%=HiddenTotalpayAllw.ClientID%>").value+"sustractn");
                Finaltotalpay=parseFloat(Finaltotalpay)- parseFloat(document.getElementById("<%=HiddenTotalpayAllw.ClientID%>").value);
                Finaltotalpay=parseFloat(Finaltotalpay)- parseFloat(document.getElementById("<%=HiddenTotalpayAllw.ClientID%>").value);
                var PerTotal= parseFloat(document.getElementById("<%=HiddenTotalPerTotal.ClientID%>").value);
                var PerBasic= parseFloat(document.getElementById("<%=HiddenTotalPerBasic.ClientID%>").value);
                var totalpercentage=0;
                if(PerTotal!=0)
                {
              
                    PerTotal=parseFloat(PerTotal)/100;
             
                    PerTotal=Finaltotalpay*PerTotal;
                    Finaltotalpay=Finaltotalpay-PerTotal;
           
                    totalpercentage=parseFloat(totalpercentage)+PerTotal;
             
              
                }
                if(PerBasic!=0)
                {
            
                    PerBasic=parseFloat(PerBasic)/100;
             
                    PerBasic=parseFloat(basicpay)*PerBasic;
                    Finaltotalpay=Finaltotalpay-PerBasic;
                    totalpercentage=parseFloat(totalpercentage)+PerBasic;
              
                }
          
                var a = parseFloat(Finaltotalpay).toFixed(FloatingValue);
                toatlpay= parseFloat(a);
                addCommasSummry(a);
                a = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                // alert(Finaltotalpay+"substarcted val");
            document.getElementById('SumryTotalpay').innerHTML =a+" "+document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;

                totalpercentage=parseFloat(totalpercentage)+parseFloat(vardedctn);
                var b = parseFloat(totalpercentage).toFixed(FloatingValue);
                toatlpay= parseFloat(b);
                addCommasSummry(b);
                b = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
                // if(b!=0)
            document.getElementById("SumryDedctnRng").innerHTML= b + "  " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
          
           
           
            }


            function Substractdedctn(vardedctn)
            {
                var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var Finaltotalpay=document.getElementById("<%=HiddenSalarSummry.ClientID%>").value;
            var basicpay=parseFloat(document.getElementById("<%=HiddenSalarSummry.ClientID%>").value);
          
            Finaltotalpay=parseFloat(Finaltotalpay)+parseFloat(document.getElementById("<%=HiddenTotalpay.ClientID%>").value);
            
            // alert(document.getElementById("<%=HiddenTotalpayAllw.ClientID%>").value+"sustractn");
            Finaltotalpay=parseFloat(Finaltotalpay);
            //- parseFloat(document.getElementById("<%=HiddenTotalpayAllw.ClientID%>").value);
            
            var PerTotal= parseFloat(document.getElementById("<%=HiddenTotalPerTotal.ClientID%>").value);
            var PerBasic= parseFloat(document.getElementById("<%=HiddenTotalPerBasic.ClientID%>").value);
            var totalpercentage=0;
            if(PerTotal!=0)
            {
              
                PerTotal=parseFloat(PerTotal)/100;
             
                PerTotal=Finaltotalpay*PerTotal;
                Finaltotalpay=Finaltotalpay-PerTotal;
           
                totalpercentage=parseFloat(totalpercentage)+PerTotal;
               

            }
            if(PerBasic!=0)
            {
            
                PerBasic=parseFloat(PerBasic)/100;
             
                PerBasic=basicpay*PerBasic;
                
                Finaltotalpay=parseFloat(Finaltotalpay)-PerBasic;
             
                totalpercentage=parseFloat(totalpercentage)+PerBasic;
              
            }
            var n = parseFloat(Finaltotalpay).toFixed(FloatingValue);
            n=n-parseFloat(document.getElementById("<%=HiddenTotalpayAllw.ClientID%>").value);
            toatlpay= parseFloat(n);
            addCommasSummry(n);
            n = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
            // alert(Finaltotalpay+"substarcted val");
            document.getElementById('SumryTotalpay').innerHTML =n+" "+document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;
            totalpercentage=parseFloat(totalpercentage)+parseFloat(vardedctn);
          
            var b = parseFloat(totalpercentage).toFixed(FloatingValue);
            toatlpay= parseFloat(b);
            addCommasSummry(b);
            b = document.getElementById("<%=Hiddenreturnfun.ClientID%>").value;
           
            // if(b!="0")
            document.getElementById('SumryDedctnRng').innerHTML= b + "  " + document.getElementById("<%=HiddenSalaryAbbrv.ClientID%>").value;

          

        }
        function ChangeStatus(CatId, CatStatus, AllwOrDed) {

            if (confirm("Do You Want To Change The Status Of This Entry?")) {
                //  var SearchString = document.getElementById("<%=HiddnEnableCacel.ClientID%>").value;
                // reporttable();

                var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
                var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;

                var Details = PageMethods.ChangeContractStatus(CatId, CatStatus, AllwOrDed, OrgId, CorpId, function (response) {
                    var SucessDetails = response;

                    if (SucessDetails == "success") {
                        // window.location = 'gen_Pay_Grade_Master.aspx?InsUpd=StsCh';
                        //reporttable();
                        SuccessChangeStatus(AllwOrDed);
                        LoadListPageallwnce();
                        // LoadListPageDed();
                    }
                    else {
                        // window.location = 'gen_Pay_Grade_Master_List.aspx?InsUpd=Error';
                    }
                });
            }
            else {
                return false;
            }
        }

        //evm-0023-20-2
        function getdetailsAllwceById(x) {
          

            var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
            var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
            var Details = PageMethods.ReadAllwceById(x, CorpId, OrgId, function (response) { 

                if (response.PerOrAmntck == 0) {
                    document.getElementById("<%=txtAmntRgeFrm.ClientID%>").value = response.FrmAmount;
                }
                else
                {
                    document.getElementById("<%=txtPerctgAllwnc.ClientID%>").value = response.FrmAmount;

                }

                // document.getElementById("<%=ddlAddtn.ClientID%>").value = response.ddlselectedVal;

                if (response.ddlBinding == 0) {
                    document.getElementById("<%=ddlAddtn.ClientID%>").value = response.ddlselectedVal;
                }
                else if (response.ddlBinding == 1) {
                    var $Mo = jQuery.noConflict();
                    var newOption = "<option value='" + response.ddlselectedVal + "'>" + response.ddltext + "</option>";

                    $Mo('#<%=ddlAddtn.ClientID%>').append(newOption);
                    //SORTING DDL
                    var options = $Mo("#<%=ddlAddtn.ClientID%> option");                    // Collect options         
                    options.detach().sort(function (a, b) {               // Detach from select, then Sort
                        var at = $Mo(a).text();
                        var bt = $Mo(b).text();
                        return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                    });
                    options.appendTo('#<%=ddlAddtn.ClientID%>');
                    document.getElementById("<%=ddlAddtn.ClientID%>").value = response.ddlselectedVal;

                }
                document.getElementById("<%=HiddenSalaryAllwceId.ClientID%>").value = response.SalaryAllwceId;

                document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value = response.PaygrdId;

                document.getElementById("<%=HiddenddlAllDed.ClientID%>").value = response.ddlselectedVal;
                document.getElementById("<%=SaveAddtn.ClientID%>").style.display = "none";
                document.getElementById("<%=UpdateAddtn.ClientID%>").style.display = "block";
                var AllwOrDed=1;
                CheckForRestriction( response.ddlselectedVal,AllwOrDed);

            });
            return false;
        }

        function CancelAlertAllwceById(x, AllwOrDed) {
            if (confirm("Do you want to cancel this entry?")) {

                document.getElementById("<%=HiddenDelChk.ClientID%>").value = AllwOrDed;
                document.getElementById("<%=hiddenRsnid.ClientID%>").value = x;
                var userId = document.getElementById("<%=HiddenUserId.ClientID%>").value;
                var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                var Details = PageMethods.CancelAlertAllwceById(x, userId, CorpId, AllwOrDed, function (response) {

                    LoadListPageallwnce();
                    // LoadListPageDed();

                    if (response == 1) {
                        //OpenCancelView();
                        SuccessCancelationDedctn();
                    }
                    else if(response == 0) {
                      
                        SuccessCancelationAllwnce();
                    }

                });
                return false;
            }
            else {
                return false;
            }

        }

        function getdetailsDedctnById(x) {

            var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
            var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
            var Details = PageMethods.ReadDedctnId(x, CorpId, OrgId, function (response) {

                document.getElementById("<%=txtAmntRedcnFrom.ClientID%>").value = response.FrmAmount;

                if (response.ddlBinding == 0) {
                    document.getElementById("<%=ddldedctn.ClientID%>").value = response.ddlselectedVal;
                }
                else if (response.ddlBinding == 1) {

                    var $Mo = jQuery.noConflict();
                    var newOption = "<option value='" + response.ddlselectedVal + "'>" + response.ddltext + "</option>";

                    $Mo('#<%=ddldedctn.ClientID%>').append(newOption);
                    //SORTING DDL
                    var options = $Mo("#<%=ddldedctn.ClientID%> option");                    // Collect options         
                    options.detach().sort(function (a, b) {               // Detach from select, then Sort
                        var at = $Mo(a).text();
                        var bt = $Mo(b).text();
                        return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                    });
                    options.appendTo('#<%=ddldedctn.ClientID%>');
                    document.getElementById("<%=ddldedctn.ClientID%>").value = response.ddlselectedVal;

                }

                if (response.BasicOrTotl == 1) {

                    document.getElementById("<%=radioBascPay.ClientID%>").checked = false;
                    document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = true;
                }
                else {
                    document.getElementById("<%=radioTotlAmnt.ClientID%>").checked = false;
                    document.getElementById("<%=radioBascPay.ClientID%>").checked = true;
                }
                if (response.PerOrAmntck == 1) {
                    document.getElementById("<%=txtperctg.ClientID%>").value = response.strperct;
                    document.getElementById("<%=radPercntge.ClientID%>").checked = true;
                    document.getElementById("<%=radAmnt.ClientID%>").checked = false;
                    RadioPerClick();
                }
                else {

                    document.getElementById("<%=radAmnt.ClientID%>").checked = true;
                    document.getElementById("<%=radPercntge.ClientID%>").checked = false;
                    RadioAmountClick();
                }
                document.getElementById("<%=HiddenSalaryDedctnId.ClientID%>").value = response.SalaryAllwceId;



                document.getElementById("<%=HiddenddlAllDed.ClientID%>").value = response.ddlselectedVal;

                document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value = response.PaygrdId;
                document.getElementById("<%=SaveDedctn.ClientID%>").style.display = "none";
                document.getElementById("<%=UpdateDedctn.ClientID%>").style.display = "block";
                var AllwOrDed=2;
                CheckForRestriction( response.ddlselectedVal,AllwOrDed);
            });
            return false;


        }


        // CONTACT DETAILS VALIDATION
        var CounterEmergency=0;
        function IncrmntConfrmCounterEmrg() {
            CounterEmergency++;     
        }
        function HideShowEmrg() {
            if (document.getElementById('EmrgInfo').style.display == "block") {
                document.getElementById('EmrgInfo').style.display = "none";

            }else if (document.getElementById('EmrgInfo').style.display == "none") {
                document.getElementById('EmrgInfo').style.display = "block";
                
            }
            
          
        }
        function ValidateCD() {
           
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

            // replacing < and > tags


            var Add1WithoutReplace = document.getElementById("<%=txtAdr1.ClientID%>").value;
            var Add1replaceText1 = Add1WithoutReplace.replace(/</g, "");
            var Add1replaceText2 = Add1replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAdr1.ClientID%>").value = Add1replaceText2;

            var Add2WithoutReplace = document.getElementById("<%=txtAdr2.ClientID%>").value;
            var Add2replaceText1 = Add2WithoutReplace.replace(/</g, "");
            var Add2replaceText2 = Add2replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAdr2.ClientID%>").value = Add2replaceText2;

            var Add3WithoutReplace = document.getElementById("<%=txtAdr3.ClientID%>").value;
            var Add3replaceText1 = Add3WithoutReplace.replace(/</g, "");
            var Add3replaceText2 = Add3replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtAdr3.ClientID%>").value = Add3replaceText2;

            var ZipWithoutReplace = document.getElementById("<%=txtPostalCode.ClientID%>").value;
            var ZipreplaceText1 = ZipWithoutReplace.replace(/</g, "");
            var ZipreplaceText2 = ZipreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtPostalCode.ClientID%>").value = ZipreplaceText2;

            var MobWithoutReplace = document.getElementById("<%=txtMobile.ClientID%>").value;
            var MobreplaceText1 = MobWithoutReplace.replace(/</g, "");
            var MobreplaceText2 = MobreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtMobile.ClientID%>").value = MobreplaceText2;

            var phoneWithoutReplace = document.getElementById("<%=txtPhone.ClientID%>").value;
            var PhonereplaceText1 = phoneWithoutReplace.replace(/</g, "");
            var PhonereplaceText2 = PhonereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtPhone.ClientID%>").value = PhonereplaceText2;

            var EmailWithoutReplace = document.getElementById("<%=txtEmail.ClientID%>").value;
            var EmailreplaceText1 = EmailWithoutReplace.replace(/</g, "");
            var EmailreplaceText2 = EmailreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEmail.ClientID%>").value = EmailreplaceText2;

            var FaxWithoutReplace = document.getElementById("<%=txtFax.ClientID%>").value;
            var FaxreplaceText1 = FaxWithoutReplace.replace(/</g, "");
            var FaxreplaceText2 = FaxreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtFax.ClientID%>").value = FaxreplaceText2;

            var CommuAdd1WithoutReplace = document.getElementById("<%=txtCommuAddr1.ClientID%>").value;
            var CmmAdd1replaceText1 = CommuAdd1WithoutReplace.replace(/</g, "");
            var cmmAdd1replaceText2 = CmmAdd1replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCommuAddr1.ClientID%>").value = cmmAdd1replaceText2;

            var cmAdd2WithoutReplace = document.getElementById("<%=txtCommuAddr2.ClientID%>").value;
            var cmAdd2replaceText1 = cmAdd2WithoutReplace.replace(/</g, "");
            var cmAdd2replaceText2 = cmAdd2replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCommuAddr2.ClientID%>").value = cmAdd2replaceText2;

            var cmAdd3WithoutReplace = document.getElementById("<%=txtCommuAddr3.ClientID%>").value;
            var cmAdd3replaceText1 = cmAdd3WithoutReplace.replace(/</g, "");
            var cmAdd3replaceText2 = cmAdd3replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCommuAddr3.ClientID%>").value = cmAdd3replaceText2;

            var cmZipWithoutReplace = document.getElementById("<%=txtCommuPostalCode.ClientID%>").value;
            var cmZipreplaceText1 = cmZipWithoutReplace.replace(/</g, "");
            var cmZipreplaceText2 = cmZipreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCommuPostalCode.ClientID%>").value = cmZipreplaceText2;

            var cmMobWithoutReplace = document.getElementById("<%=txtCommuMobile.ClientID%>").value;
            var cmMobreplaceText1 = cmMobWithoutReplace.replace(/</g, "");
            var cmMobreplaceText2 = cmMobreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCommuMobile.ClientID%>").value = cmMobreplaceText2;

            var cmphoneWithoutReplace = document.getElementById("<%=txtCommuPhone.ClientID%>").value;
            var cmPhonereplaceText1 = cmphoneWithoutReplace.replace(/</g, "");
            var cmPhonereplaceText2 = cmPhonereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCommuPhone.ClientID%>").value = cmPhonereplaceText2;

            var cmEmailWithoutReplace = document.getElementById("<%=txtCmmuEmail.ClientID%>").value;
            var cmEmailreplaceText1 = cmEmailWithoutReplace.replace(/</g, "");
            var cmEmailreplaceText2 = cmEmailreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCmmuEmail.ClientID%>").value = cmEmailreplaceText2;

            var cmFaxWithoutReplace = document.getElementById("<%=txtCommuFax.ClientID%>").value;
            var cmFaxreplaceText1 = cmFaxWithoutReplace.replace(/</g, "");
            var cmFaxreplaceText2 = cmFaxreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCommuFax.ClientID%>").value = cmFaxreplaceText2;

            var emrnameWithoutReplace = document.getElementById("<%=txtEmrgName.ClientID%>").value;
            var emrNamereplaceText1 = emrnameWithoutReplace.replace(/</g, "");
            var emrNamereplaceText2 = emrNamereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEmrgName.ClientID%>").value = emrNamereplaceText2;

            var emrAdd1WithoutReplace = document.getElementById("<%=txtEmrgAddr.ClientID%>").value;
            var EmrAdd1replaceText1 = emrAdd1WithoutReplace.replace(/</g, "");
            var EmrAdd1replaceText2 = EmrAdd1replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEmrgAddr.ClientID%>").value = EmrAdd1replaceText2;

            var cmphoneWithoutReplace = document.getElementById("<%=txtEmrgPhone.ClientID%>").value;
            var cmPhonereplaceText1 = cmphoneWithoutReplace.replace(/</g, "");
            var cmPhonereplaceText2 = cmPhonereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEmrgPhone.ClientID%>").value = cmPhonereplaceText2;

            var emrMobWithoutReplace = document.getElementById("<%=txtEmrgMobile.ClientID%>").value;
            var emrMobreplaceText1 = emrMobWithoutReplace.replace(/</g, "");
            var emrMobreplaceText2 = emrMobreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEmrgMobile.ClientID%>").value = emrMobreplaceText2;

            var emrEmailWithoutReplace = document.getElementById("<%=txtEmrgEmail.ClientID%>").value;
            var emrEmailreplaceText1 = emrEmailWithoutReplace.replace(/</g, "");
            var emrEmailreplaceText2 = emrEmailreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEmrgEmail.ClientID%>").value = emrEmailreplaceText2;

            var emrFaxWithoutReplace = document.getElementById("<%=txtEmrgFax.ClientID%>").value;
            var emrFaxreplaceText1 = emrFaxWithoutReplace.replace(/</g, "");
            var emrFaxreplaceText2 = emrFaxreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEmrgFax.ClientID%>").value = emrFaxreplaceText2;

            document.getElementById("<%=ddlCountryCD.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAdr1.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtMobile.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCommuAddr1.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlCommuCountryCD.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCommuMobile.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtEmrgName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlEmrgRelat.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtEmrgMobile.ClientID%>").style.borderColor = "";

            //  document.getElementById('ErrorMsgCorpEmail').style.visibility = "hidden";
            document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "";
            document.getElementById('divMessageAreaCD').style.display = "none";
            document.getElementById('imgMessageAreaCD').src = "";


            var Country = document.getElementById("<%=ddlCountryCD.ClientID%>");
            var PermntCountry = Country.options[Country.selectedIndex].text.trim();
            var relation = document.getElementById("<%=ddlEmrgRelat.ClientID%>");
            var realtionEmerg = relation.options[relation.selectedIndex].text.trim();

            var EmpAdd = document.getElementById("<%=txtAdr1.ClientID%>").value.trim();
            var EmpEmrgName = document.getElementById("<%=txtEmrgName.ClientID%>").value.trim();
            var EmpMobile = document.getElementById("<%=txtMobile.ClientID%>").value.trim();
            var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;

            var EmailAdd = document.getElementById("<%=txtEmail.ClientID%>").value.trim();
            var Email = document.getElementById("<%=txtEmail.ClientID%>").value.trim();

            var TxCountry = document.getElementById("<%=ddlCommuCountryCD.ClientID%>");
            var CommuCountry = TxCountry.options[TxCountry.selectedIndex].text.trim();

            var EmpCommuAddr = document.getElementById("<%=txtCommuAddr1.ClientID%>").value.trim();
            var EmpEmrgAddr = document.getElementById("<%=txtEmrgAddr.ClientID%>").value.trim();
            var EmpCommuMobile = document.getElementById("<%=txtCommuMobile.ClientID%>").value.trim();
            var EmailAddCommu = document.getElementById("<%=txtCmmuEmail.ClientID%>").value.trim();
            var EmailAddEmerg = document.getElementById("<%=txtEmrgEmail.ClientID%>").value.trim();
            var EmpEmrgMobile = document.getElementById("<%=txtEmrgMobile.ClientID%>").value.trim();

            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            var re = /^(http[s]?:\/\/){0,1}(www\.){0,1}[a-zA-Z0-9\.\-]+\.[a-zA-Z]{2,5}[\.]{0,1}/;
            //// AFTER if validation is true in above case

            //new code

            if (document.getElementById("<%=ddlStateCD.ClientID%>").value != null && document.getElementById("<%=ddlStateCD.ClientID%>").value != "--Select State--" && document.getElementById("<%=ddlStateCD.ClientID%>").value != 0) {
                document.getElementById("<%=HiddenStateValueCD.ClientID%>").value = document.getElementById("<%=ddlStateCD.ClientID%>").value;
            }
            if (document.getElementById("<%=ddlCityCD.ClientID%>").value != null && document.getElementById("<%=ddlCityCD.ClientID%>").value != "--Select City--" && document.getElementById("<%=ddlCityCD.ClientID%>").value != 0) {
                document.getElementById("<%=HiddenCityValueCD.ClientID%>").value = document.getElementById("<%=ddlCityCD.ClientID%>").value;
            }

            if (document.getElementById("<%=ddlStateCD.ClientID%>").value != null && document.getElementById("<%=ddlCommuStateCD.ClientID%>").value != "--Select State--" && document.getElementById("<%=ddlCommuStateCD.ClientID%>").value != 0) {

                document.getElementById("<%=HiddenCommuStateValueCD.ClientID%>").value = document.getElementById("<%=ddlCommuStateCD.ClientID%>").value;
            }
            if (document.getElementById("<%=ddlCommuCityCD.ClientID%>").value != null && document.getElementById("<%=ddlCommuCityCD.ClientID%>").value != "--Select City--" && document.getElementById("<%=ddlCommuCityCD.ClientID%>").value != 0) {
                document.getElementById("<%=HiddenCommuCityValueCD.ClientID%>").value = document.getElementById("<%=ddlCommuCityCD.ClientID%>").value;
             }

             if(EmpEmrgName=="" && EmpEmrgMobile=="" && realtionEmerg=="--Select Relation--" && EmpEmrgMobile=="" && EmpEmrgAddr=="" && EmailAddEmerg=="")
             {
                 CounterEmergency=0;
             }

             if(document.getElementById("<%=txtEmrgFax.ClientID%>").value.trim()!="" || document.getElementById("<%=txtEmrgPhone.ClientID%>").value.trim()!="" ||  document.getElementById("<%=txtEmrgAddr.ClientID%>").value.trim()!="" || document.getElementById("<%=txtEmrgName.ClientID%>").value.trim()!="" || document.getElementById("<%=txtEmrgMobile.ClientID%>").value.trim()!="" || document.getElementById("<%=ddlEmrgRelat.ClientID%>").value !="--Select Relation--")
            {
                CounterEmergency++;
                confirmbox++;

            }
            if (PermntCountry == "--Select Country--") {
                document.getElementById('divMessageAreaCD').style.display = "";
                document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlCountryCD.ClientID%>").style.borderColor = "Red";
                var OrgnTypeFocus = document.getElementById("<%=ddlCountryCD.ClientID%>").focus();
                ret = false;
            }
            if (CommuCountry == "--Select Country--") {
                document.getElementById('divMessageAreaCD').style.display = "";
                document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlCommuCountryCD.ClientID%>").style.borderColor = "Red";
                var OrgnTypeFocus2 = document.getElementById("<%=ddlCountryCD.ClientID%>").focus();
                ret = false;
            }
            
           
           
            if(CounterEmergency!=0)
            {
                if (realtionEmerg == "--Select Relation--") {
                    CounterEmergency++;
                    document.getElementById('divMessageAreaCD').style.display = "";
                    document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=ddlEmrgRelat.ClientID%>").style.borderColor = "Red";
                    var OrgnTypeFocus = document.getElementById("<%=ddlEmrgRelat.ClientID%>").focus();
                    ret = false;
                }  
            }
            
           
            if (Email != "") {
                if (!filter.test(Email)) {
                    document.getElementById('divMessageAreaCD').style.display = "";
                    document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtEmail.ClientID%>").focus();
                    document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "Red";
                    document.getElementById('ErrorMsgEmail').style.display = "";
                    document.getElementById("<%=txtEmail.ClientID%>").focus();
                    document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                else
                {
                    document.getElementById('ErrorMsgEmail').style.display = "none";
                    document.getElementById("<%=txtEmail.ClientID%>").style.borderColor = "";
                }
            }
           

            if (EmailAddCommu != "") {
                if (!filter.test(EmailAddCommu)) {
                    document.getElementById('divMessageAreaCD').style.display = "";
                    document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtCmmuEmail.ClientID%>").focus();
                    document.getElementById("<%=txtCmmuEmail.ClientID%>").style.borderColor = "Red";
                    document.getElementById('ErrorMsgCommuEmail').style.display = "";
                    document.getElementById("<%=txtCmmuEmail.ClientID%>").focus();
                    document.getElementById("<%=txtCmmuEmail.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                else
                {
                    document.getElementById('ErrorMsgCommuEmail').style.display = "none";
                    document.getElementById("<%=txtCmmuEmail.ClientID%>").style.borderColor = "";
                }
            }
            

            if (EmailAddEmerg != "") {
                if (!filter.test(EmailAddEmerg)) {
                    document.getElementById('divMessageAreaCD').style.display = "";
                    document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtEmrgEmail.ClientID%>").focus();
                    document.getElementById("<%=txtEmrgEmail.ClientID%>").style.borderColor = "Red";
                    document.getElementById('ErrorMsgEmrgEmail').style.display = "";
                    document.getElementById("<%=txtEmrgEmail.ClientID%>").focus();
                    document.getElementById("<%=txtEmrgEmail.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                else
                {
                    document.getElementById('ErrorMsgEmrgEmail').style.display = "none";
                    document.getElementById("<%=txtEmrgEmail.ClientID%>").style.borderColor = "";
                }
            }
           
            if(EmpMobile!="")
            {
                if (!mobileregular.test(EmpMobile)) {
                    document.getElementById('divMessageAreaCD').style.display = "";
                    document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    var OrgMobileFocus = document.getElementById("<%=txtMobile.ClientID%>").focus();
                    document.getElementById("<%=txtMobile.ClientID%>").style.borderColor = "Red";
                    document.getElementById('ErrorMsgMob').style.display = "";
                    document.getElementById("<%=txtMobile.ClientID%>").focus();
                    document.getElementById("<%=txtMobile.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                else {
                    document.getElementById('ErrorMsgMob').style.display = "none";
                    document.getElementById("<%=txtMobile.ClientID%>").style.borderColor = "";
                }
            }
           
            if(EmpCommuMobile!="")
            {
                if (!mobileregular.test(EmpCommuMobile)) {
                    document.getElementById('divMessageAreaCD').style.display = "";
                    document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    var OrgMobileFocus = document.getElementById("<%=txtCommuMobile.ClientID%>").focus();
                    document.getElementById("<%=txtCommuMobile.ClientID%>").style.borderColor = "Red";
                    document.getElementById('ErrorMsgCommuMob').style.display = "";
                    document.getElementById("<%=txtCommuMobile.ClientID%>").focus();
                    document.getElementById("<%=txtCommuMobile.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                else {
                    document.getElementById('ErrorMsgCommuMob').style.display = "none";
                    document.getElementById("<%=txtCommuMobile.ClientID%>").style.borderColor = "";     
                }
               
            }
            if(EmpEmrgMobile!="")
            {                
                if(CounterEmergency!=0)
                {
                    if (!mobileregular.test(EmpEmrgMobile)) {
                        CounterEmergency++;
                        document.getElementById('divMessageAreaCD').style.display = "";
                        document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        var OrgMobileFocus = document.getElementById("<%=txtEmrgMobile.ClientID%>").focus();
                        document.getElementById("<%=txtEmrgMobile.ClientID%>").style.borderColor = "Red";
                        document.getElementById('ErrorMsgEmrgMob').style.display = "";
                        document.getElementById("<%=txtEmrgMobile.ClientID%>").focus();
                        document.getElementById("<%=txtEmrgMobile.ClientID%>").style.borderColor = "Red";
                        ret = false;
                    }
                    else
                    {                       
                        document.getElementById('ErrorMsgEmrgMob').style.display = "none";
                        document.getElementById("<%=txtEmrgMobile.ClientID%>").style.borderColor = "";
                    }
                }
                else
                {   
                    //  document.getElementById("<%=txtEmrgMobile.ClientID%>").style.borderColor = "";
                }
            }
            else if(CounterEmergency!=0)
            {
                // alert("ggg");
                CounterEmergency++;
                document.getElementById("<%=txtEmrgMobile.ClientID%>").style.borderColor = "Red";   
                document.getElementById('divMessageAreaCD').style.display = "";
                document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtEmrgMobile.ClientID%>").focus();
                ret=false;
            }
        
        if(EmpCommuAddr == "") {
            document.getElementById('divMessageAreaCD').style.display = "";
            document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
            document.getElementById("<%=txtCommuAddr1.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtCommuAddr1.ClientID%>").focus();
            ret = false;
        }

        if (EmpAdd == "") {
            document.getElementById('divMessageAreaCD').style.display = "";
            document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
            document.getElementById("<%=txtAdr1.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=txtAdr1.ClientID%>").focus();
            ret = false;
        }
        if(EmpEmrgName == "") {
            if(CounterEmergency!=0){
                CounterEmergency++;
                document.getElementById('divMessageAreaCD').style.display = "";
                document.getElementById('imgMessageAreaCD').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtEmrgName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtEmrgName.ClientID%>").focus();
                ret = false;
            }
        }
        else {CounterEmergency++;}


    
          
      
        if (ret == false) {
            CheckSubmitZero();

        }
        $(window).scrollTop(0);
        return ret;
    }
     
    // END CONTACT DETAILS VALIDATION
    // CONTACT DETAILS
    function addDetails() {

        if (document.getElementById("<%=cbxSameAddr.ClientID%>").checked == true) {

            document.getElementById("<%=txtCommuAddr1.ClientID%>").value = document.getElementById("<%=txtAdr1.ClientID%>").value;
            document.getElementById("<%=txtCommuAddr2.ClientID%>").value = document.getElementById("<%=txtAdr2.ClientID%>").value;
            document.getElementById("<%=txtCommuAddr3.ClientID%>").value = document.getElementById("<%=txtAdr3.ClientID%>").value;
            document.getElementById("<%=txtCmmuEmail.ClientID%>").value = document.getElementById("<%=txtEmail.ClientID%>").value;
            document.getElementById("<%=txtCommuPostalCode.ClientID%>").value = document.getElementById("<%=txtPostalCode.ClientID%>").value;
            document.getElementById("<%=txtCommuPhone.ClientID%>").value = document.getElementById("<%=txtPhone.ClientID%>").value;
            document.getElementById("<%=txtCommuMobile.ClientID%>").value = document.getElementById("<%=txtMobile.ClientID%>").value;
            document.getElementById("<%=txtCommuFax.ClientID%>").value = document.getElementById("<%=txtFax.ClientID%>").value;
            document.getElementById("<%=ddlCommuCountryCD.ClientID%>").value = document.getElementById("<%=ddlCountryCD.ClientID%>").value;
            var cid = document.getElementById("<%=ddlCountryCD.ClientID%>").value;
            if (cid != "--Select Country--") {
                changeCountryCommu(cid);

                var sid = document.getElementById("<%=ddlStateCD.ClientID%>").value;
                    //alert("KKK"+sid)
                    changeStateCommu(sid);
                    //alert("KKK" + sid)
                    setTimeout(selectdropDownState, 200);
                    setTimeout(selectdropDownCity, 600);
                }


            }

            return false;
        }

        function selectdropDownState() {
            var selectObjState = document.getElementById('cphMain_ddlCommuStateCD');
            var stateId = document.getElementById("<%=ddlStateCD.ClientID%>").value;
            //alert(selectObjState.options.length);
            //alert(selectObjState.options.length);
            for (var i = 0; i < selectObjState.options.length; i++) {
                if (selectObjState.options[i].value == stateId) {
                    selectObjState.options[i].selected = true;
                }
            }
            document.getElementById("<%=ddlCommuStateCD.ClientID%>").value = document.getElementById("<%=ddlStateCD.ClientID%>").value;
            return;
        }
        function selectdropDownCity() {
            var selectObjCity = document.getElementById('cphMain_ddlCommuCityCD');
            var cityId = document.getElementById("<%=ddlCityCD.ClientID%>").value;
            for (var i = 0; i < selectObjCity.options.length; i++) {
                if (selectObjCity.options[i].value == cityId) {
                    selectObjCity.options[i].selected = true;
                }
            }
            document.getElementById("<%=ddlCommuCityCD.ClientID%>").value = document.getElementById("<%=ddlCityCD.ClientID%>").value;
            return;
        }




        // END CD
        // START CONTACT DETAILS

        function changeCountryCD() {
            document.getElementById("cphMain_ddlCityCD").options.length = 0;
            if (document.getElementById("<%=ddlCountryCD.ClientID%>").value != "--Select Country--") {
                var countryId = document.getElementById("<%=ddlCountryCD.ClientID%>").value;
                var text = document.getElementById("<%=ddlCountryCD.ClientID%>");
                var tableName = "dtTableDivision";
                var $coo = jQuery.noConflict();
                var ddlTestDropDownListXML = $coo(document.getElementById("<%=ddlStateCD.ClientID%>"));
            }

            IncrmntConfrmCounter();
            $(ddlTestDropDownListXML).empty();
            if (text != "--Select Country--") {
                $coo.ajax({
                    type: "POST",
                    url: "gen_Emply_Personal_Informn.aspx/countryChangeCD",
                    data: '{tableName:"' + tableName + '",countryId:"' + countryId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $coo("<option>--Select State--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);
                        // Now find the Table from response and loop through each item (row).
                        $coo(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $coo(this).find('STATE_ID').text();
                            var OptionText = $coo(this).find('STATE_NAME').text();
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
        function changeCountryCommu(id) {

            document.getElementById("cphMain_ddlCommuCityCD").options.length = 0;
            if (id == "" || id == null)
                var countryId = document.getElementById("<%=ddlCommuCountryCD.ClientID%>").value;
           else
               countryId = id;
           var tableName = "dtTableDivision";
           var $coo = jQuery.noConflict();
           var ddlTestDropDownListXML = $coo(document.getElementById("<%=ddlCommuStateCD.ClientID%>"));


                IncrmntConfrmCounter();


                $(ddlTestDropDownListXML).empty();

                if (countryId != "--Select Country--") {
                    $coo.ajax({
                        type: "POST",
                        url: "gen_Emply_Personal_Informn.aspx/countryChangeCommu",
                        data: '{tableName:"' + tableName + '",countryId:"' + countryId + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {

                            var OptionStart = $coo("<option>--Select State--</option>");
                            OptionStart.attr("value", 0);
                            ddlTestDropDownListXML.append(OptionStart);
                            // Now find the Table from response and loop through each item (row).
                            $coo(response.d).find(tableName).each(function () {
                                // Get the OptionValue and OptionText Column values.
                                var OptionValue = $coo(this).find('STATE_ID').text();
                                var OptionText = $coo(this).find('STATE_NAME').text();
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
      
            function changeStateCD() {
                document.getElementById("cphMain_ddlCityCD").options.length = 0;
                var stateId = document.getElementById("<%=ddlStateCD.ClientID%>").value;
                var tableName = "cphMain_Tblid2";
            var $coo = jQuery.noConflict();
            var ddlTestDropDownListXML = $coo(document.getElementById("cphMain_ddlCityCD"));


            IncrmntConfrmCounter();
            $(ddlTestDropDownListXML).empty();
            if (stateId != "--Select State--") {
                $coo.ajax({
                    type: "POST",
                    url: "gen_Emply_Personal_Informn.aspx/stateChangeCD",
                    data: '{tableName:"' + tableName + '",stateId:"' + stateId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $coo("<option>--Select City--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);
                        // Now find the Table from response and loop through each item (row).
                        $coo(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $coo(this).find('CITY_ID').text();
                            var OptionText = $coo(this).find('CITY_NAME').text();
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

        function changeStateCommu(id) {
            document.getElementById("cphMain_ddlCommuCityCD").options.length = 0;
            if (id == "" || id == null) {
                var stateId = document.getElementById("<%=ddlCommuStateCD.ClientID%>").value;
            }
            else
                stateId = id;
            var tableName = "cphMain_Tblid2";
            var $coo = jQuery.noConflict();
            var ddlTestDropDownListXML = $coo(document.getElementById("cphMain_ddlCommuCityCD"));


            IncrmntConfrmCounter();
            $(ddlTestDropDownListXML).empty();
            if (stateId != "--Select State--") {
                $coo.ajax({
                    type: "POST",
                    url: "gen_Emply_Personal_Informn.aspx/stateChangeCommu",
                    data: '{tableName:"' + tableName + '",stateId:"' + stateId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var OptionStart = $coo("<option>--Select City--</option>");
                        OptionStart.attr("value", 0);
                        ddlTestDropDownListXML.append(OptionStart);
                        // Now find the Table from response and loop through each item (row).
                        $coo(response.d).find(tableName).each(function () {
                            // Get the OptionValue and OptionText Column values.
                            var OptionValue = $coo(this).find('CITY_ID').text();
                            var OptionText = $coo(this).find('CITY_NAME').text();
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
        function changeCity() {
            return false;
        }

       
        function SuccessConfirmationCD() {
            document.getElementById('divMessageAreaCD').style.display = "";
            document.getElementById('imgMessageAreaCD').src ="/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Contact details inserted successfully.";
            tableClick('divTblid2', cphMain_Tblid2);
         
           
        }
        function SuccessUpdationCD() {
            document.getElementById('divMessageAreaCD').style.display = "";
            document.getElementById('imgMessageAreaCD').src ="/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaCD.ClientID%>").innerHTML = "Contact details updated successfully.";
            tableClick('divTblid2', cphMain_Tblid2);
        }
        function CheckBoxChange(count)
        {
            var RowCount =count;
            for (i = 0; i < RowCount; i++) {
                if( document.getElementById('cblwelfarescvc_' + i).checked == false)
                {
                    document.getElementById('cbxSelectAll').checked = false;
                }
            }

        }


        function selectAll(count) {  //EMP0025
          
            //alert(count);
            //  var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
       
            var RowCount =count;
             var strAmntList = "";
             if (document.getElementById('cbxSelectAll').checked == true) {
                 for (i = 0; i < RowCount; i++) {

                     document.getElementById('cblwelfarescvc_' + i).checked = true;


                 }
             }
             else {
                 for (i = 0; i < RowCount; i++) {

                     document.getElementById('cblwelfarescvc_' + i).checked = false;

                 }
             }
            

        }
        function isTagText(evt) {

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

            //0-9
            if (charCode >= 65 || charCode >= 90) {
                return false;
            }
            //numpad 0-9


            // . period and numpad . period
            if (keyCodes == 190 || keyCodes == 110) {
                var ret = false;

            }
            if (charCode == 8 || charCode == 46) {
                return true;
            }


            var tbClientValues = '';
            tbClientValues = [];
            //alert();
            MainTable = $('#ReportTable > tbody > tr');

            $(MainTable).each(function () {
                var RowId = $(this).attr('id');
                // alert(RowId);
                var SplitId = RowId.split('_');
                var CntMain = SplitId[1];
                if (SplitId[0] == "trId") {


                    if ($('#cblwelfarescvc_' + CntMain).length) {

                       

                        var LIMIT = $('#txtlmt_' + CntMain).val().trim();
                        
                            var QtyLimt = document.getElementById('tdlimit1_' + CntMain).innerHTML;
                          //  var mandatory = document.getElementById('tdChecked_' + CntMain).innerHTML;
                           // if (mandatory == 1) {

                           //   if (parseFloat( LIMIT) >parseFloat(QtyLimt)) {

                              //    $('#txtlmt_' + CntMain).css('border-color', 'red');

                                //    document.getElementById('divError').style.visibility = "visible";
                                 //   document.getElementById("<%=lblError.ClientID%>").innerHTML = "Welfare service quantity shoud not be greater than  welfare service limt. Please check the highlighted fields below.";

                                //    return false;

                              //  }
                        //   }
                      
                        if (LIMIT == "") {

                                    $('#txtlmt_' + CntMain).css('border-color', 'red');
                              
                                    document.getElementById('divError').style.visibility = "visible";
                                    document.getElementById("<%=lblError.ClientID%>").innerHTML = "Welfare service limit should not be empty. Please check the highlighted fields below.";
                                   
                                    
                                    return false;
                        }

                       
                                else {
                                    document.getElementById('divError').style.visibility = "hidden";
                                    $('#txtlmt_' + CntMain).css('border-color', '');
                                }
                            
                

                    }
                }
            });


            return ret;
        }


        function getselected(rowCount) {   //EMP0025
          // alert('call');
           // alert(document.getElementById("<%=hiddenRowCount.ClientID%>").value );
            document.getElementById("<%=HiddenWelfareSubid.ClientID%>").value="";
             document.getElementById("<%=Hiddenchecklist.ClientID%>").value=[];

             //  alert();
             var tbClientValues = '';
             tbClientValues = [];

             if (rowCount > 0) {
                 MainTable = $('#ReportTableWelfare > tbody > tr');
                 $(MainTable).each(function () {
                     var RowId = $(this).attr('id');
                     //alert(RowId);
                     var SplitId = RowId.split('_');
                     var CntMain = SplitId[1];
                     if (SplitId[0] == "trId") {
//
                       // alert(CntMain);
                         if ($('#cblwelfarescvc_' + CntMain).length) {
                          // alert('enter');
                             var SubDtlId="";
                             SubDtlId= document.getElementById('tdSubtId_' + CntMain).innerHTML;
                           //  alert(document.getElementById('tdSubtId_' + CntMain).innerHTML+"rtrt");
                             

                             document.getElementById("<%=HiddenWelfareSubid.ClientID%>").value =document.getElementById("<%=HiddenWelfareSubid.ClientID%>").value +SubDtlId+",";
                             //alert( document.getElementById("<%=HiddenWelfareSubid.ClientID%>").value );
                             var checked=0;

                             if ($('#cblwelfarescvc_' + CntMain).is(':checked')) {
                                 checked=1;
                             }
                           //  alert(checked);
                             var MyTable = document.getElementById("tdchkSts_" + CntMain+"").innerHTML;
                            // alert(MyTable);

                               
                                 //alert(document.getElementById('txtlmt_' + CntMain).text);
                                 // alert(document.getElementById('tdDesgId_' + CntMain).innerHTML);
                                 // alert( document.getElementById("<%=HiddenEmployeeId.ClientID%>").value);
                             var EMPID = document.getElementById("<%=HiddenEmployeeId.ClientID%>").value;
                             //  alert(EMPID);


                            
                                 var SubId = document.getElementById('tdSubtId_' + CntMain).innerHTML;
                                 var WELFARID = document.getElementById('tdWelfareId_' + CntMain).innerHTML;
                                 var LIMIT = $('#txtlmt_' + CntMain).val();
                                 var QtyLimt = document.getElementById('tdlimit1_' + CntMain).innerHTML;

                                // alert(QtyLimt);
                                 var client = JSON.stringify({
                                     EmpId: "" + EMPID + "",
                                     WelfareId: "" + WELFARID + "",
                                     limit: "" + LIMIT + "",
                                     WelfareSubId: "" + SubId + "",
                                     ActLimt: "" + QtyLimt + "",
                                     chkSts: "" + MyTable + "",
                                     CheckboxSts: "" + checked + "",
                                 });
                                 tbClientValues.push(client);
                           //  }
                         }
                     }
                 });
             }
           // alert(MyTable);
             document.getElementById("<%=Hiddenchecklist.ClientID%>").value = JSON.stringify(tbClientValues);
   // alert(document.getElementById("<%=Hiddenchecklist.ClientID%>").value);
             //alert(DesgId);
        }



        function preview(Id) {
            //  alert(Id);

            document.getElementById("freezlyr").style.display = "";
            document.getElementById("ModelCnclView").style.display = "block";
         document.getElementById("cphMain_divwelfareSrevc").style.display = "none";
            
            var str = Id;

            var globalFileTypeId = str.split(',');
            var id1 = globalFileTypeId[0];
            var id2 = globalFileTypeId[1];
            var id3=globalFileTypeId[2];
            
            var id4=deptId =document.getElementById("<%=HiddenUserCrprtDept.ClientID%>").value
         //  alert(id4);
          
            var desgnid=document.getElementById("<%=ddlUsrDsgn.ClientID%>").value ;
            document.getElementById("<%=divSeviceName.ClientID%>").innerHTML =id3
            document.getElementById("<%=HiddenWelfareId.ClientID%>").value =id1;
          
              // alert(id1); alert(id2);

              $.ajax({
                  type: "POST",
                  url: "gen_Emply_Personal_Informn.aspx/preview1",
                  data: '{strid: "' + id1 + '",strempid:"' + id2 + '",deptid:"'+ id4 +'",deptid:"'+ id4 +'",desgid:"'+desgnid+'"}',

                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (response) {
                     // alert(response.d);
                    //  document.getElementById("cphMain_divwelfareSrevc").style.display = "block";
                    //  document.getElementById("cphMain_divReportTable").innerHTML = response.d;
                      document.getElementById("<%=divReportTable.ClientID%>").innerHTML = response.d;
                     //
                    //  document.getElementById('divReport1').innerHTML = response.d;

                },
                failure: function (response) {

                }

            });

              // OpenCancelView();
                $nooC('#dialog_simple').dialog('open');
                $nooC('.ui-dialog-titlebar-close').attr('title', 'Close');

              // document.getElementById("txtefctvedate").value = "";




                return false;
        }
        function CloseCncllView() {
            document.getElementById('divError').style.visibility = "hidden";
        
            document.getElementById("cphMain_divwelfareSrevc").style.display = "block";
            document.getElementById("freezlyr").style.display = "none";
            document.getElementById("ModelCnclView").style.display = "none";
               
            
            return false;
        }
        function validateWelfare() {

            var ret = true;
            document.getElementById('divError').style.visibility = "hidden";

            var totalRowCount = 0;

            var rowCount = 0;

            var table = document.getElementById("ReportTableWelfare");

            var rows = table.getElementsByTagName("tr")

            for (var i = 0; i < rows.length; i++) {

                totalRowCount++;

                if (rows[i].getElementsByTagName("td").length > 0) {

                    rowCount++;

                }

            }

            MainTable = $('#ReportTableWelfare > tbody > tr');


          
                 
            var check = 0;
            for (var j = 0; j < rowCount; j++)
            {
            
                if ($('#cblwelfarescvc_' + j).is(':checked')) {
                    check = check + 1;
                    var LIMIT = $('#txtlmt_' + j).val().trim();
                    if (LIMIT == "") {
                        $('#txtlmt_' + j).css('border-color', 'red');
                         document.getElementById('divError').style.visibility = "visible";
                        document.getElementById("<%=lblError.ClientID%>").innerHTML = "Welfare service limit should not be empty. Please check the highlighted fields below.";
                                   
                        ret = false;
                    }
                 
                }
            }
            var EMPID = document.getElementById("<%=HiddenEmployeeId.ClientID%>").value;
                               
                                    
           
            if(EMPID==0)
            {
                document.getElementById('divError').style.visibility = "visible";
                document.getElementById("<%=lblError.ClientID%>").innerHTML = "Please add employee to continue.";
                           ret=false;
                        }
                        
          //  if (check == 0) {
             
             //   document.getElementById('divError').style.visibility = "visible";
              //  document.getElementById("<%=lblError.ClientID%>").innerHTML = "Please Select Welfare service to continue.";
            //
              // ret = false;
               

             
            // }


           if (ret == true)
           {
               getselected(rowCount);
           }
           return ret;
              //alert(count);

        }

        function ErrorMessage() {

            document.getElementById('divError').style.visibility = "visible";
            document.getElementById("<%=lblError.ClientID%>").innerHTML = "Welfare service limit should not be empty. Please check the highlighted fields below.";
                                   
                                    
            return false;
      

        }

        function SuccessMessage() {

            document.getElementById('divMessageAreaMain').style.display = "block";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Welfare service saved Successfully.";
            tableClick('divTblid8', cphMain_Tblid8);

        }
        function ValueNotFoundMessage()
        {
            document.getElementById('divMessageAreaMain').style.display = "block";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Selected  welfare service not allowed.";
            
           // $('#cphMain_divReport1').attr('style', 'borderColor: Red !important;width:40% !important;word-break: break-all !important;word-wrap:break-word !important;text-align: left !important');
            // $('#cphMain_divReport1').css('border-color', 'red');max-height: 100px;overflow: auto;
        document.getElementById("cphMain_divReport1").style.borderColor = "Red";
            
        tableClick('divTblid8', cphMain_Tblid8);
            return false;
        }
        //END CONTACT DETAILS
    </script>
     <%--Immigration details--%>
  <script>
   
      var confirmboxImig=0;
      function IncrmntConfrmCounterImig() {
        
          confirmboxImig++;
      }
      function AlertClearAllImmig() {
          if (confirmboxImig > 0) {
              if (confirm("Are you sure you want clear all data in this page?")) {
                  document.getElementById("<%=Ddlvisatype.ClientID%>").value = "--Select Visa Type--";
                  document.getElementById("<%=RadioButtonDocList.ClientID%>").value = "";
                  document.getElementById("<%=TxtEligiblervwdate.ClientID%>").value = "";
                  document.getElementById("<%=ddlIssuedby.ClientID%>").value = "--Select Country--";
      
                  document.getElementById("<%=TxtEligiblervwdate.ClientID%>").value = "";
                  document.getElementById("<%=TxtdivExpiryDate.ClientID%>").value = "";
      
                  document.getElementById("<%=Txtelgblestats.ClientID%>").value = "";
                  document.getElementById("<%=TextIssuueddate.ClientID%>").value = "";
                  document.getElementById("<%=Textnumber.ClientID%>").value = "";
                  document.getElementById("<%=TxtComments.ClientID%>").value = "";
                  document.getElementById("<%=FileUploadRecharge.ClientID%>").value = "";

                  document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";

                  document.getElementById("<%=TxtCntrnum.ClientID%>").value = "";
                  document.getElementById("<%=HcExpDate.ClientID%>").value = "";
                 
                  document.getElementById("<%=Label5.ClientID%>").textContent = "No File Selected";
                  tableClick('divTblid4', cphMain_Tblid4);
                  return false;
              }
              else 
              {
                  return false;
              }
          }
          else {
              document.getElementById("<%=Ddlvisatype.ClientID%>").value = "--Select Visa Type--";
              document.getElementById("<%=RadioButtonDocList.ClientID%>").value = "";
              document.getElementById("<%=TxtEligiblervwdate.ClientID%>").value = "";
              document.getElementById("<%=ddlIssuedby.ClientID%>").value ="--Select Country--";
      
              document.getElementById("<%=TxtEligiblervwdate.ClientID%>").value = "";
              document.getElementById("<%=TxtdivExpiryDate.ClientID%>").value = "";
      
              document.getElementById("<%=Txtelgblestats.ClientID%>").value = "";
              document.getElementById("<%=TextIssuueddate.ClientID%>").value = "";
              document.getElementById("<%=Textnumber.ClientID%>").value = "";
              document.getElementById("<%=TxtComments.ClientID%>").value = "";
              document.getElementById("<%=FileUploadRecharge.ClientID%>").value = "";
              document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";
              document.getElementById("<%=TxtCntrnum.ClientID%>").value = "";
              document.getElementById("<%=HcExpDate.ClientID%>").value = "";
              document.getElementById("<%=Label5.ClientID%>").textContent = "No File Selected";
           
              tableClick('divTblid4', cphMain_Tblid4);
              return false;
          }
      }
      function OpenCancelViewForImig() {



          document.getElementById("divmodalCancelViewForimig").style.display = "block";
          document.getElementById("freezelayer").style.display = "";
          document.getElementById("<%=TxtRsnimig.ClientID%>").focus();

          return false;

      }
      function CloseCancelViewForImig() {
          if (confirm("Do you want to close  without completing cancellation process?")) {
              document.getElementById('divMessageAreaforimig').style.display = "none";
              document.getElementById('imgMessageforimig').src = "";
              document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "";
              document.getElementById("divmodalCancelViewForimig").style.display = "none";
              document.getElementById("freezelayer").style.display = "none";
              document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
              tableClick('divTblid4', cphMain_Tblid4);
              return false;
          }
      }
        
      function ClearDivDisplayImagepropic() {
          
          IncrmntConfrmCounter();
           
          var hidnImageSize = document.getElementById("<%=hiddenUserImageSize.ClientID%>").value;
            
            var fuData = document.getElementById("<%=FileUploadProPic.ClientID%>");
            var size = fuData.files[0].size;
            var convertToKb = hidnImageSize/1000;
            if (size > hidnImageSize) {
                document.getElementById("<%=FileUploadProPic.ClientID%>").value="";
                document.getElementById("<%=Label10.ClientID%>").textContent="No file selected";
                alert(" Sorry maximum file size exceeds. Please upload image of size less than " + convertToKb + "KB !.");
                //return false;
            }
            else{
                
                if (document.getElementById("<%=FileUploadProPic.ClientID%>").value != "") {
                    document.getElementById("<%=Label10.ClientID%>").textContent = document.getElementById("<%=FileUploadProPic.ClientID%>").value;
                    document.getElementById("<%=divImageDisplaypropic.ClientID%>").innerHTML="";
                    document.getElementById("<%=hiddenUserImage.ClientID%>").value="";
                }
               
                //    return true;
            
            }
        }

        function ClearDivDisplayImage1() {

            IncrmntConfrmCounterImig();
            var FileUploadPath = document.getElementById("<%=FileUploadRecharge.ClientID%>").value;

            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();







            if (document.getElementById("<%=FileUploadRecharge.ClientID%>").value != "") {
                document.getElementById("<%=Label5.ClientID%>").textContent = document.getElementById("<%=FileUploadRecharge.ClientID%>").value;
                //document.getElementById("<%=divImageDisplay1.ClientID%>").innerHTML = "";
                document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";
            }
        }
        function ClearImage1() {
            if (document.getElementById("<%=hiddenUserImage.ClientID%>").value != "" || document.getElementById("<%=FileUploadRecharge.ClientID%>").value != "") {
                        if (confirm("Do you want to remove selected attachment?")) {

                            document.getElementById("<%=FileUploadRecharge.ClientID%>").value = "";
                            document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";
                   
                            document.getElementById("<%=Label5.ClientID%>").textContent = "No file selected";
                            //  alert("Image has been Removed Sucessfully. ");
                        }
                        else {

                        }

                    }
                }
    
                function validateJobsave(Sou) 
                {
                    ret = true;

                    // SetTextforperiod()
                    //    var emplyid = document.getElementById("cphMain_Txtemplyid").value.trim(); //emp17
                    var NameWithoutReplace = document.getElementById("<%=Txtprojloc.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=Txtprojloc.ClientID%>").value = replaceText2;
            var NameWithoutReplace = document.getElementById("<%=TxtjobTitle.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TxtjobTitle.ClientID%>").value = replaceText2;
            var NameWithoutReplace = document.getElementById("<%=TxtJobDesc.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TxtJobDesc.ClientID%>").value = replaceText2;
            //  var NameWithoutReplace = document.getElementById("<%=TxtLocation.ClientID%>").value;
            // var replaceText1 = NameWithoutReplace.replace(/</g, "");
            //  var replaceText2 = replaceText1.replace(/>/g, "");
            //  document.getElementById("<%=TxtLocation.ClientID%>").value = replaceText2;

            document.getElementById("<%=txtJoineddate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtProbationdate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtpermanencyDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlDesignation.ClientID%>").style.borderColor = "";
            document.getElementById('divMessageAreaforjob').style.display = "none";
            document.getElementById("<%=ddtype.ClientID%>").style.borderColor = "";
                    //EVM-0027
           // document.getElementById("<%=ddlSponsor.ClientID%>").style.borderColor = "";
                    // document.getElementById("<%=ddlProject.ClientID%>").style.borderColor = "";
                    //document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "";
                    //END
            document.getElementById("<%=txtJoineddate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlEmployeeType.ClientID%>").style.borderColor = "";
          
            // var designtaion = document.getElementById("<%=ddlDesignation.ClientID%>").value.trim();
            var type = document.getElementById("<%=ddtype.ClientID%>").value.trim();
            var sponsor = document.getElementById("<%=ddlSponsor.ClientID%>").value.trim();
            var project = document.getElementById("<%=ddlProject.ClientID%>").value.trim();
            var joindate= document.getElementById("<%=txtJoineddate.ClientID%>").value.trim();
            var emptype= document.getElementById("<%=ddlEmployeeType.ClientID%>").value.trim();
            var joineddate= document.getElementById("<%=txtJoineddate.ClientID%>").value.trim();
            var division= document.getElementById("<%=ddlDivision.ClientID%>").value.trim();
         
            var arrDatePickerDate1 = joindate.split("-");
            var datejoin = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

           
            var probdate= document.getElementById("<%=txtProbationdate.ClientID%>").value.trim();
            var arrDatePickerDate1 = probdate.split("-");
            var probdate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

            var permnncydate= document.getElementById("<%=txtpermanencyDate.ClientID%>").value.trim();
          var arrDatePickerDate1 = permnncydate.split("-");
          var permnncydate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

         
       
          var CurrentDate= document.getElementById("<%=hiddenCurrentDate.ClientID%>").value.trim();
          var arrDatePickerDateCurr = CurrentDate.split("-");
          var TodayDate = new Date(arrDatePickerDateCurr[2], arrDatePickerDateCurr[1] - 1, arrDatePickerDateCurr[0]);
          
      
       
            //if (designtaion == "--SELECT DESIGNATION--") {
            //  document.getElementById('divMessageAreaforjob').style.display = "";
            //  document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
            //  document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
            //  document.getElementById("<%=ddlDesignation.ClientID%>").style.borderColor = "Red";
            //  document.getElementById("<%=ddlDesignation.ClientID%>").focus();
            //  ret = false;
            //}
          //  if (type == "--SELECT TYPE--") {
             //   document.getElementById('divMessageAreaforjob').style.display = "";
             //   document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
               // document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
              //  document.getElementById("<%=ddtype.ClientID%>").style.borderColor = "Red";
             //   document.getElementById("<%=ddtype.ClientID%>").focus();
           //     ret = false;
         //   }
           
                    //EVM-0027
       //     if (project == "--SELECT PROJECT--")
      //      {

          //      document.getElementById('divMessageAreaforjob').style.display = "";
          //      document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
           //     document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
           //   document.getElementById("<%=ddlProject.ClientID%>").style.borderColor = "Red";
            //  document.getElementById("<%=ddlProject.ClientID%>").focus();

           //   ret = false;
          //  }
                    

        // if (division == "--SELECT DIVISION--") 
        //  {
          //    document.getElementById('divMessageAreaforjob').style.display = "";
          ////    document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
          //    document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
            //  document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "Red";
            //  document.getElementById("<%=ddlDivision.ClientID%>").focus();
            //  ret = false;
         // } 
      <%--    if (emptype == "--SELECT TYPE--") {
              document.getElementById('divMessageAreaforjob').style.display = "";
              document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
              document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
              document.getElementById("<%=ddlEmployeeType.ClientID%>").style.borderColor = "Red";
              document.getElementById("<%=ddlEmployeeType.ClientID%>").focus();
              ret = false;
          }--%>
          
       //   if (sponsor == "--SELECT SPONSOR--") {
          //    document.getElementById('divMessageAreaforjob').style.display = "";
          ///    document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
           //   document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
           //   document.getElementById("<%=ddlSponsor.ClientID%>").style.borderColor = "Red";
          //    document.getElementById("<%=ddlSponsor.ClientID%>").focus();
         //     ret = false;
                    //    }  
                    //END
                    if (joineddate == "")
                    {                      
                        document.getElementById('divMessageAreaforjob').style.display = "";
                        document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById("<%=txtJoineddate.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtJoineddate.ClientID%>").focus();

                        ret = false;
                    }
                    else{

                        var limit=document.getElementById("<%=HiddenFieldJoinDateLimit.ClientID%>").value;                     
                        var timeDiff = Math.abs(TodayDate.getTime() - datejoin.getTime());
                        var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));




                        if(document.getElementById("<%=hiddenJoiningDateOnPageLoad.ClientID%>").value != joindate)
                        {
                            if(parseInt(diffDays)>parseInt(limit)  && (datejoin<TodayDate)){                              
                                document.getElementById('divMessageAreaforjob').style.display = "";
                                document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Date of joining and current date difference cannot be greater than "+limit+" days.";
                                document.getElementById("<%=txtJoineddate.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=txtJoineddate.ClientID%>").focus();
                                ret = false;
                            }
                        }
                    }
             
                    
          if (permnncydate<joindate)
          {

              document.getElementById('divMessageAreaforjob').style.display = "";
              document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
              document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
              document.getElementById("<%=txtpermanencyDate.ClientID%>").style.borderColor = "Red";
              document.getElementById("<%=txtpermanencyDate.ClientID%>").focus();

              ret = false;
          }
                   

          if (joindate != ""&&probdate!=""){
              if (datejoin>probdate)
              {
                  document.getElementById('divMessageAreaforjob').style.display = "";
                  document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txtProbationdate.ClientID%>").style.borderColor = "Red"; 
                  document.getElementById("<%=txtProbationdate.ClientID%>").focus();

                  ret = false;
              }
          }
        
                    if(Sou==0 && ret==true){
                        if(BssicInfoValidation(1)==false){
                            tableClick('divTblid8', cphMain_Tblid8);
                            ret= false;
                        }
                    }

                    if(ret==true)
                    {              
                        if(Sou==0)//adding
                        {
                            document.getElementById("Div21").style.display = "block";
                            document.getElementById("freezelayer").style.display = "";
                        }
                    }
            // alert(ret);             
          return ret;

      }                
      
      function validateprojectsave() {
          ret = true;

          if (document.getElementById("<%=Hiddenjobid.ClientID%>").value != "") {
              document.getElementById("<%=txtProjectEndDate.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtprojectstartdate.ClientID%>").style.borderColor = "";
              document.getElementById("<%=TxtProjectComments.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddlprojectassign.ClientID%>").style.borderColor = "";



              var EndDate = document.getElementById("<%=txtProjectEndDate.ClientID%>").value.trim();
              var startdate = document.getElementById("<%=txtprojectstartdate.ClientID%>").value.trim();
              var Comments = document.getElementById("<%=TxtProjectComments.ClientID%>").value.trim();
              //  var birthplc = document.getElementById("<%=txtBirthPlc.ClientID%>").value.trim();
              var project = document.getElementById("<%=ddlprojectassign.ClientID%>").value.trim();
              var arrDatePickerDate1 = EndDate.split("-");
              var EndDate1 = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
              var arrDatePickerDate1 = startdate.split("-");
              var startdate1 = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

             
               

              if (EndDate == "") {
                  document.getElementById('divMessageAreaforjob').style.display = "";
                  document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txtProjectEndDate.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtProjectEndDate.ClientID%>").focus();
                  ret = false;
              }
              if (startdate == "") {
                  document.getElementById('divMessageAreaforjob').style.display = "";
                  document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txtprojectstartdate.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtprojectstartdate.ClientID%>").focus();
                  ret = false;
              }
              if(EndDate1<startdate1)
              {
                
                  document.getElementById('divMessageAreaforjob').style.display = "";
                  document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Start date cannot be greater than end date";
                    document.getElementById("<%=txtprojectstartdate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtProjectEndDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtprojectstartdate.ClientID%>").focus();
                    ret = false;
                   
                
                
                }
                if (project == "--SELECT PROJECT--") {

                    document.getElementById('divMessageAreaforjob').style.display = "";
                    document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=ddlprojectassign.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddlprojectassign.ClientID%>").focus();

                    ret = false;
                }
                return ret;

            }
            else 
            {

                if (confirm("Save the job details?")) 
                {
                    document.getElementById("<%=BtnsaveJob.ClientID%>").focus();
                                 document.getElementById('divMessageAreaforjob').style.display = "";
                                 document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
                                 document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Job details should be saved first";

                  return false;
              }
              else 
              {
                  document.getElementById('divMessageAreaforjob').style.display = "";
                  document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Job details should be saved first";
                    return false;
                }
                return false;
            }
        }
               
        
        function ImigSuccessConfirmation() {
            document.getElementById('divMessageAreaforimig').style.display = "";

            document.getElementById('imgMessageAreaforimig').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17
            document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Immigration details inserted successfully.";
            //document.getElementById("<%=RadioButtonDocList.ClientID%>").value = "";
            document.getElementById("<%=Ddlvisatype.ClientID%>").value = "--Select Visa Type--";
            document.getElementById("<%=ddlIssuedby.ClientID%>").value = "--Select Country--";
            document.getElementById("<%=TxtEligiblervwdate.ClientID%>").value = "";
            // document.getElementById("<%=ddlIssuedby.ClientID%>").SelectedIndex = 0;
            document.getElementById("<%=RadioButtonDocList.ClientID%>").SelectedIndex = 0;
            document.getElementById("<%=TxtEligiblervwdate.ClientID%>").value = "";
            document.getElementById("<%=TxtdivExpiryDate.ClientID%>").value = "";
      
            document.getElementById("<%=Txtelgblestats.ClientID%>").value = "";
            document.getElementById("<%=TextIssuueddate.ClientID%>").value = "";
            document.getElementById("<%=Textnumber.ClientID%>").value = "";
            document.getElementById("<%=TxtComments.ClientID%>").value = "";
            document.getElementById('divMessageAreaforimig').style.display = "";
            document.getElementById("<%=TxtCntrnum.ClientID%>").value = "";
            document.getElementById("<%=HcExpDate.ClientID%>").value = "";
            document.getElementById('imgMessageAreaforimig').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17
            document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Immigration details inserted successfully.";
                         document.getElementById("<%=Txtelgblestats.ClientID%>").focus();
            tableClick('divTblid4', cphMain_Tblid4);
        }
        function immigrationSuccessDuplication() { //3emp17
            document.getElementById('divMessageAreaforimig').style.display = "";
            document.getElementById('imgMessageAreaforimig').src="/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Duplication error.Number can't be duplicated.";
                         document.getElementById('cphMain_Textnumber').focus();
                         document.getElementById('cphMain_Textnumber').style.borderColor="red";
                         show_updatebutton();
                         hide_saveebutton();
                         hide_clearbutton();
                         tableClick('divTblid4', cphMain_Tblid4);
                         document.getElementById('cphMain_Textnumber').focus();
                         if(document.getElementById('cphMain_RadioButtonDocList_1').checked==true){
                             document.getElementById("Divvisatype").style.display = "";
                         }
                     }   

                     function immigrationSuccessDuplicationSave() { //3emp17
                         document.getElementById('divMessageAreaforimig').style.display = "";
                         document.getElementById('imgMessageAreaforimig').src="/Images/Icons/imgMsgAreaWarning.png";
                         document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Duplication error.Number can't be duplicated.";
                         document.getElementById('cphMain_Textnumber').focus();
                         document.getElementById('cphMain_Textnumber').style.borderColor="red";

                         tableClick('divTblid4', cphMain_Tblid4);
                         document.getElementById('cphMain_Textnumber').focus();
                         if(document.getElementById('cphMain_RadioButtonDocList_1').checked==true){
                             document.getElementById("Divvisatype").style.display = "";
                         }
                     }  
                     function ImigSuccessUpdation() {
                         //  alert("5454");

                         document.getElementById('divMessageAreaforimig').style.display = "";
                         document.getElementById('imgMessageAreaforimig').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17
                         document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Immigration details updated successfully.";
          document.getElementById("<%=RadioButtonDocList.ClientID%>").value = "";
          document.getElementById("<%=TxtEligiblervwdate.ClientID%>").value = "";
          document.getElementById("<%=ddlIssuedby.ClientID%>").value = "";
      
          document.getElementById("<%=TxtCntrnum.ClientID%>").value = "";
          document.getElementById("<%=HcExpDate.ClientID%>").value = "";
          document.getElementById("<%=TxtEligiblervwdate.ClientID%>").value = "";
          document.getElementById("<%=TxtdivExpiryDate.ClientID%>").value = "";
      
          document.getElementById("<%=Txtelgblestats.ClientID%>").value = "";
          document.getElementById("<%=TextIssuueddate.ClientID%>").value = "";
          document.getElementById("<%=Textnumber.ClientID%>").value = "";
          document.getElementById("<%=TxtComments.ClientID%>").value = "";
          document.getElementById("<%=RadioButtonDocList.ClientID%>").SelectedValue = 1;
      
          document.getElementById("<%=Ddlvisatype.ClientID%>").value = "--Select Visa Type--";
          document.getElementById("<%=ddlIssuedby.ClientID%>").value = "--Select Country--";
          document.getElementById("<%=Txtelgblestats.ClientID%>").focus();
                         tableClick('divTblid4', cphMain_Tblid4);
      }
      function ImigSuccessCancelation() {
          
          document.getElementById('divMessageAreaforimig').style.display = "";
          document.getElementById('imgMessageAreaforimig').src = "/Images/Icons/imgMsgAreaInfo.png";
          document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Immigration details cancelled successfully.";
          document.getElementById("<%=Txtelgblestats.ClientID%>").focus();
          tableClick('divTblid4', cphMain_Tblid4);
      }

      function JobSuccessConfirmation() {
     
          document.getElementById('divMessageAreaforjob').style.display = "";
          document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaInfo.png";
          document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Job details inserted successfully.";
          document.getElementById('cphMain_txtJoineddate').focus();
          tableClick('divTblid5', cphMain_Tblid5);
      }
      function JobSuccessUpdation() {
        
          document.getElementById('divMessageAreaforjob').style.display = "";
          document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaInfo.png";
          document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Job details updated successfully.";
          document.getElementById('cphMain_txtJoineddate').focus();
          tableClick('divTblid5', cphMain_Tblid5);
      }
      function JobSuccessCancelation() {
          document.getElementById('divMessageAreaforjob').style.display = "";
          document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaInfo.png";
          document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Job details cancelled successfully.";
            document.getElementById('cphMain_txtJoineddate').focus();
            tableClick('divTblid5', cphMain_Tblid5);
        }
        function projectSuccessConfirmation() {
            document.getElementById('divMessageAreaforjob').style.display = "";
            document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Project details saved successfully.";
            document.getElementById('cphMain_ddlprojectassign').focus();
            tableClick('divTblid5', cphMain_Tblid5);
        }       
        function projectSuccessUpdation() {
            document.getElementById('divMessageAreaforjob').style.display = "";
            document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Project details updated successfully.";
            document.getElementById('cphMain_ddlprojectassign').focus();
            document.getElementById("<%=ddlprojectassign.ClientID%>").SelectedIndex =0;
            document.getElementById("<%=txtprojectstartdate.ClientID%>").value = "";
            document.getElementById("<%=txtProjectEndDate.ClientID%>").value = "";
            document.getElementById("<%=TxtProjectComments.ClientID%>").value = "";
            document.getElementById("<%=ddlprojectassign.ClientID%>").focus();
                    
            tableClick('divTblid5', cphMain_Tblid5);
        }
        function projectSuccessCancelation() {
            document.getElementById('divMessageAreaforjob').style.display = "";
            document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Project cancelled successfully.";
            document.getElementById('cphMain_ddlprojectassign').focus();
            document.getElementById("<%=ddlprojectassign.ClientID%>").SelectedIndex =0;
            document.getElementById("<%=txtprojectstartdate.ClientID%>").value = "";
            document.getElementById("<%=txtProjectEndDate.ClientID%>").value = "";
            document.getElementById("<%=TxtProjectComments.ClientID%>").value = "";
            document.getElementById("<%=ddlprojectassign.ClientID%>").focus();
                    
            tableClick('divTblid5', cphMain_Tblid5);
        }
        function projectSuccessDuplication() {
            document.getElementById('divMessageAreaforjob').style.display = "";
            document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Duplication error.Project can't be duplicated.";
            document.getElementById('cphMain_ddlprojectassign').focus();
            document.getElementById('cphMain_ddlprojectassign').style.borderColor="red";
            tableClick('divTblid5', cphMain_Tblid5);
        }
    </script>
    <script>
        
        var confirmboxjob=0;
        function IncrmntConfrmCounterJob() {
           // document.getElementById('divMessageAreaforjob').style.display = "none";
            confirmboxjob++;
        }
        function AlertClearAllJob() {
            if (confirmboxjob > 0) {
                if (confirm("Are you sure you want clear all data in this pages?")) {
                    document.getElementById("<%=txtJoineddate.ClientID%>").value = "";
                    document.getElementById("<%=txtProbationdate.ClientID%>").value = "";
                    //  document.getElementById("<%=ddlIssuedby.ClientID%>").value = 0;
      
                    document.getElementById("<%=txtpermanencyDate.ClientID%>").value = "";
                    document.getElementById("<%=TxtPeriod.ClientID%>").value = "";
      
                    document.getElementById("<%=ddlDesignation.ClientID%>").value = "";
                    document.getElementById("<%=ddlSponsor.ClientID%>").value = "";
                    document.getElementById("<%=ddlEmployeeType.ClientID%>").value = "";
                    document.getElementById("<%=ddlProject.ClientID%>").value = "";
                    document.getElementById("<%=ddlDivision.ClientID%>").value = "";
                    document.getElementById("<%=ddlDepartment.ClientID%>").value = "";

                    document.getElementById("<%=txtHobbies.ClientID%>").value = "";

                    document.getElementById("<%=ddtype.ClientID%>").value = "";   
                    document.getElementById("<%=Txtprojloc.ClientID%>").value = ""; 
                    document.getElementById("<%=TxtjobTitle.ClientID%>").value = "";
                    document.getElementById("<%=TxtJobDesc.ClientID%>").value = "";
                    // document.getElementById("<%=TxtLocation.ClientID%>").value = "";
                    //document.getElementById("<%=ddlAccomodation.ClientID%>").value = "";
                    tableClick('divTblid5', cphMain_Tblid5);
                    return false;
                }
                else 
                {
                    return false;
                }
            }
            else {
                tableClick('divTblid5', cphMain_Tblid5);
                return false;
            }
        }
        function ConfirmCncljob() {
            
            if (confirmboxjob > 0) {
                if (confirm("Are you sure you want to cancel this page?")) {
                    window.location.href = "gen_Emp_Personal_Info_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {

                window.location.href = "gen_Emp_Personal_Info_List.aspx";
                return false;
            }
        }

        //    if (confirmboxjob > 0) {
        //        if (confirm("Are you sure you want to cancel this page?")) {
        //            window.location.href = "gen_Emp_Personal_Info_List.aspx";
        //            return false;
        //        }
        //        else {
        //            return false;
        //        }
        //    }
        //    else {

        //        window.location.href = "gen_Emp_Personal_Info_List.aspx";
        //        return false;
        //    }
        //}

         
        function loadprojassign()
        {        //  alert("ss");
            IncrmntConfrmCounterJob();
            var e = document.getElementById("<%=ddlProject.ClientID%>");  
            var selectedLocation = e.options[e.selectedIndex].text;
            var selectedvalue = e.options[e.selectedIndex].value;
            //var selecteditem= e.options[e.selected].value; 
            // alert(selectedLocation);
            //alert(selecteditem);
            //  var value=document.getElementById("<%=ddlProject.ClientID%>").SelectedIndex;
            //  alert(value);
            document.getElementById("<%=txtProjectEndDate.ClientID%>").SelectedIndex=selectedLocation;
            var e = document.getElementById("<%=ddlprojectassign.ClientID%>");  
            e.options[e.selectedIndex].text =selectedLocation;
            e.options[e.selectedIndex].value =selectedvalue;

            return false;
        }



    </script>

    <script>
        
        var confirmboxproj=0;
        function IncrmntConfrmCounterProj() {
            confirmboxproj++;
        }
        function AlertClearAllProj() {
            if (confirmboxproj > 0) {
                if (confirm("Are you sure you want clear all data in this page?")) {
                    document.getElementById("<%=ddlprojectassign.ClientID%>").value ="--SELECT PROJECT--";
                    document.getElementById("<%=txtprojectstartdate.ClientID%>").value = "";
                    document.getElementById("<%=txtProjectEndDate.ClientID%>").value = "";
                    document.getElementById("<%=TxtProjectComments.ClientID%>").value = "";
                    document.getElementById("<%=ddlprojectassign.ClientID%>").focus();
                    tableClick('divTblid5', cphMain_Tblid5);
                    return false;
                }
                else 
                {

                    return false;
                }
            }
            else {
                document.getElementById("<%=ddlprojectassign.ClientID%>").text ="--SELECT PROJECT--";
                document.getElementById("<%=txtprojectstartdate.ClientID%>").value = "";
                document.getElementById("<%=txtProjectEndDate.ClientID%>").value = "";
                document.getElementById("<%=TxtProjectComments.ClientID%>").value = "";
                document.getElementById("<%=ddlprojectassign.ClientID%>").focus();
                  
                tableClick('divTblid5', cphMain_Tblid5);
                return false;
            }
        }
        function ConfirmCnclproj() {
            //  alert();
            if (confirmboxproj > 0) {
                if (confirm("Are you sure you want to cancel this page?")) {
                    window.location.href = "gen_Emp_Personal_Info_List.aspx";
                    return false;
                }
                else {
                    //alert("else");
                    return false;
                }
            }
            else {
                // alert();
                window.location.href = "gen_Emp_Personal_Info_List.aspx";
                return false;
            }
        }





    </script>
      <script type="text/javascript">

          function Validateimmigration() 
          {
              var ret = true;
          
              // replacing < and > tags
              var ret = true;
              // replacing < and > tags
              var NameWithoutReplace = document.getElementById("<%=Textnumber.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=Textnumber.ClientID%>").value = replaceText2;

              NameWithoutReplace = document.getElementById("<%=TxtComments.ClientID%>").value;
              replaceText1 = NameWithoutReplace.replace(/</g, "");
              replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=TxtComments.ClientID%>").value = replaceText2;

              NameWithoutReplace = document.getElementById("<%=Txtelgblestats.ClientID%>").value;
              replaceText1 = NameWithoutReplace.replace(/</g, "");
              replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=Txtelgblestats.ClientID%>").value = replaceText2;


              var NameWithoutReplace = document.getElementById("<%=TxtComments.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=TxtComments.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=TxtCntrnum.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=TxtCntrnum.ClientID%>").value = replaceText2;

              document.getElementById('divMessageAreaforimig').style.display = "none";
              document.getElementById('imgMessageAreaforimig').src = "";

              document.getElementById("<%=HcExpDate.ClientID%>").style.borderColor = "";
          

              document.getElementById("<%=RadioButtonDocList.ClientID%>").style.borderColor = "";
              document.getElementById("<%=TxtEligiblervwdate.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddlIssuedby.ClientID%>").style.borderColor = "";
      
              document.getElementById("<%=TxtEligiblervwdate.ClientID%>").style.borderColor = "";
              document.getElementById("<%=TxtdivExpiryDate.ClientID%>").style.borderColor = "";
      
              document.getElementById("<%=Txtelgblestats.ClientID%>").style.borderColor = "";
              document.getElementById("<%=TextIssuueddate.ClientID%>").style.borderColor = "";
              document.getElementById("<%=Textnumber.ClientID%>").style.borderColor = "";
              document.getElementById("<%=Textnumber.ClientID%>").style.borderColor = "";
              document.getElementById("lblfileupload").style.borderColor = "";
              var visa = document.getElementById("<%=Ddlvisatype.ClientID%>").value;
            
              var radio = document.getElementById("<%=hiddenvisa.ClientID%>").value;
              // alert(radio);
              // var Country = document.getElementById("<%=ddlIssuedby.ClientID%>");
  
              var fileupload = document.getElementById("<%=FileUploadRecharge.ClientID%>").value;
 
              var expry = document.getElementById("<%=TxtdivExpiryDate.ClientID%>").value;
              var arrDatePickerDate = expry.split("-");
              var dateexpiry = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

              var stat =document.getElementById("<%=Txtelgblestats.ClientID%>").value;
      
              var issudate = document.getElementById("<%=TextIssuueddate.ClientID%>").value;
              var arrDatePickerDate1 = issudate.split("-");
              var dateissued = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

              var cdate=new Date();
              var num = document.getElementById("<%=Textnumber.ClientID%>").value.trim()
              var cntry = document.getElementById("<%=ddlIssuedby.ClientID%>").value.trim()
        
              var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;

              var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
              //  alert(dateissued);
              // alert(dateexpiry);
              var HcexpryDate = document.getElementById("<%=HcExpDate.ClientID%>").value;

              if (dateissued > cdate) { //3emp17
                  document.getElementById("<%=TextIssuueddate.ClientID%>").style.borderColor = "Red";
                  //document.getElementById("<%=TxtdivExpiryDate.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=TextIssuueddate.ClientID%>").focus();
                  document.getElementById('divMessageAreaforimig').style.display = "";
                  document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Sorry, issue date cannot be greater than current date !.";
                  ret = false;
              }

              if (dateissued > dateexpiry) {
                  document.getElementById("<%=TextIssuueddate.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=TxtdivExpiryDate.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=TxtdivExpiryDate.ClientID%>").focus();
                  document.getElementById('divMessageAreaforimig').style.display = "";
                  document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Sorry, issue date cannot be greater than expiry date !."; //3emp17
                  ret = false;
              }//3emp17
              
              if (radio !="4")
              {
                  if (expry == "")
                  {
            
                      document.getElementById('divMessageAreaforimig').style.display = "";
                      document.getElementById('imgMessageAreaforimig').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                      // var ErrorMsg = document.getElementById('ErrorMsgMob').style.display = "";
         
                      document.getElementById("<%=TxtdivExpiryDate.ClientID%>").focus();
         
                      document.getElementById("<%=TxtdivExpiryDate.ClientID%>").style.borderColor = "red";
            
                      ret=false;
                  }
              }
              
              if (radio =="4")
              {
                  if(HcexpryDate=="")
                  {
                      document.getElementById('divMessageAreaforimig').style.display = "";
                      document.getElementById('imgMessageAreaforimig').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                      // var ErrorMsg = document.getElementById('ErrorMsgMob').style.display = "";
         
                      var OrgMobileFocus = document.getElementById("<%=HcExpDate.ClientID%>").focus();
         
                      document.getElementById("<%=HcExpDate.ClientID%>").style.borderColor = "red";
            
                      ret=false;
                  }
              }

              if (num == "")
              {
            
                  document.getElementById('divMessageAreaforimig').style.display = "";
                  document.getElementById('imgMessageAreaforimig').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  // var ErrorMsg = document.getElementById('ErrorMsgMob').style.display = "";
         
                  var OrgMobileFocus = document.getElementById("<%=Textnumber.ClientID%>").focus();
         
                  document.getElementById("<%=Textnumber.ClientID%>").style.borderColor = "red";
            
                  ret=false;
              }
             
              if (radio =="2")
              {//alert(radio);
                  if(visa=="--Select Visa Type--"||visa=="")
                  {
                      document.getElementById('divMessageAreaforimig').style.display = "";
                      document.getElementById('imgMessageAreaforimig').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                      // var ErrorMsg = document.getElementById('ErrorMsgMob').style.display = "";
         
                      var OrgMobileFocus = document.getElementById("<%=Textnumber.ClientID%>").focus();
         
                      document.getElementById("<%=Ddlvisatype.ClientID%>").style.borderColor = "red";
            
                      ret=false;
                  }
              }

            
              //  if (fileupload == "") {

              // document.getElementById('divMessageAreaforimig').style.display = "";
              //  document.getElementById('imgMessageAreaforimig').src = "/Images/Icons/imgMsgAreaWarning.png";
              //  document.getElementById("<%=lblMessageAreaforimig.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
              // var ErrorMsg = document.getElementById('ErrorMsgMob').style.display = "";

              //   var OrgMobileFocus = document.getElementById("lblfileupload").focus();

              //    document.getElementById("lblfileupload").style.borderColor = "red";
             
              //    ret = false;
              // }
        
              //22/02 evm-0024
              if(document.getElementById('cphMain_RadioButtonDocList_2').checked == true)
              {

                  $('#cphMain_RadioButtonDocList_1').prop('disabled',true);
                  $('#cphMain_RadioButtonDocList_2').prop('disabled',false);
              }         
              //end

             

             

        
              return ret;
          }




          //Qualification
          function divButtonWrkExpClick() {
              //hiding other
              document.getElementById('divButtonEducation').style.backgroundColor = "#CBCBCB";
              document.getElementById('divButtonSkill').style.backgroundColor = "#CBCBCB";
              document.getElementById('divButtonLang').style.backgroundColor = "#CBCBCB";

              document.getElementById('divEductn').style.display = "none";
              document.getElementById('divSkillCer').style.display = "none";
              document.getElementById('divLang').style.display = "none";


              //displaying current
              document.getElementById('divButtonWrkExp').style.backgroundColor = "#f9f9f9";
              document.getElementById('divWorkExp').style.display = "block";
              document.getElementById('cphMain_txtWrkCompny').focus();       //12emp17

          }
          function divButtonEductnClick() {
              //hiding other
              document.getElementById('divButtonWrkExp').style.backgroundColor = "#CBCBCB";
              document.getElementById('divButtonSkill').style.backgroundColor = "#CBCBCB";
              document.getElementById('divButtonLang').style.backgroundColor = "#CBCBCB";

              document.getElementById('divWorkExp').style.display = "none";
              document.getElementById('divSkillCer').style.display = "none";
              document.getElementById('divLang').style.display = "none";


              //displaying current
              document.getElementById('divButtonEducation').style.backgroundColor = "#f9f9f9";
              document.getElementById('divEductn').style.display = "block";
              document.getElementById('cphMain_ddlEduLvl').focus(); 

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
              document.getElementById('divButtonSkill').style.backgroundColor = "#f9f9f9";
              document.getElementById('divSkillCer').style.display = "block";
              document.getElementById('cphMain_ddlSCSkill').focus();    //12emp17

          }
          function divButtonLangClick() {
              
              //hiding other
              document.getElementById('divButtonEducation').style.backgroundColor = "#CBCBCB";
              document.getElementById('divButtonSkill').style.backgroundColor = "#CBCBCB";
              document.getElementById('divButtonWrkExp').style.backgroundColor = "#CBCBCB";

              document.getElementById('divEductn').style.display = "none";
              document.getElementById('divSkillCer').style.display = "none";
              document.getElementById('divWorkExp').style.display = "none";


              //displaying current
              document.getElementById('divButtonLang').style.backgroundColor = "#f9f9f9";
              document.getElementById('divLang').style.display = "block";
              document.getElementById('cphMain_ddlQuLang').focus();   //12emp17

          }
          function refVerClick() {
              if (document.getElementById("<%=cbxRefCheck.ClientID%>").checked == true) {
                  document.getElementById("<%=txtWrkRefName.ClientID%>").disabled = false;
                  document.getElementById("<%=txtWrkRefDesg.ClientID%>").disabled = false;
              }
              else {
                  document.getElementById("<%=txtWrkRefName.ClientID%>").value = "";
                  document.getElementById("<%=txtWrkRefDesg.ClientID%>").value = "";
                  document.getElementById("<%=txtWrkRefName.ClientID%>").disabled = true;
                  document.getElementById("<%=txtWrkRefDesg.ClientID%>").disabled = true;
              }

          }
          function ValidateWrkExp() {
              var ret = true;
              // replacing < and > tags
              var NameWithoutReplace = document.getElementById("<%=txtWrkCompny.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtWrkCompny.ClientID%>").value = replaceText2;

              NameWithoutReplace = document.getElementById("<%=txtWrkJobTle.ClientID%>").value;
              replaceText1 = NameWithoutReplace.replace(/</g, "");
              replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtWrkJobTle.ClientID%>").value = replaceText2;

              NameWithoutReplace = document.getElementById("<%=txtWrkFromDate.ClientID%>").value;
              replaceText1 = NameWithoutReplace.replace(/</g, "");
              replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtWrkFromDate.ClientID%>").value = replaceText2;

              NameWithoutReplace = document.getElementById("<%=txtWrkToDate.ClientID%>").value;
              replaceText1 = NameWithoutReplace.replace(/</g, "");
              replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtWrkToDate.ClientID%>").value = replaceText2;

              NameWithoutReplace = document.getElementById("<%=txtWrkCmnt.ClientID%>").value;
              replaceText1 = NameWithoutReplace.replace(/</g, "");
              replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtWrkCmnt.ClientID%>").value = replaceText2;

              NameWithoutReplace = document.getElementById("<%=txtWrkRefName.ClientID%>").value;
              replaceText1 = NameWithoutReplace.replace(/</g, "");
              replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtWrkRefName.ClientID%>").value = replaceText2;

              NameWithoutReplace = document.getElementById("<%=txtWrkRefDesg.ClientID%>").value;
              replaceText1 = NameWithoutReplace.replace(/</g, "");
              replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtWrkRefDesg.ClientID%>").value = replaceText2;

              var cmpny = document.getElementById("<%=txtWrkCompny.ClientID%>").value.trim();
              var JobTitle = document.getElementById("<%=txtWrkJobTle.ClientID%>").value.trim();
              var RefName = document.getElementById("<%=txtWrkRefName.ClientID%>").value.trim();
              var FromDate = document.getElementById("<%=txtWrkFromDate.ClientID%>").value.trim();   //emp17
              var arrDatePickerDate1 = FromDate.split("-");
              var confrmdate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
              var ToDate = document.getElementById("<%=txtWrkToDate.ClientID%>").value.trim();
              var arrDatePickerDate1 = ToDate.split("-");
              var contodate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]); //emp17
              var cdate=new Date();//emp17
              document.getElementById("<%=txtWrkCompny.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtWrkJobTle.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtWrkRefName.ClientID%>").style.borderColor = "";
              document.getElementById('divMessageAreaWrkExp').style.display = "none";
              document.getElementById('imgMessageAreaWrkExp').src = "";
              if(contodate < confrmdate)       //emp17
              {
                  document.getElementById('divMessageAreaWrkExp').style.display = "";
                  document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "From date Should be less than to date";
                  document.getElementById("<%=txtWrkFromDate.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtWrkFromDate.ClientID%>").focus();
                  document.getElementById("<%=txtWrkToDate.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtWrkToDate.ClientID%>").focus();
                  ret = false;
              } 

              if(contodate > cdate)
              {         document.getElementById('divMessageAreaWrkExp').style.display = "";
                  document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "Date should not be greater than current date";
                  document.getElementById("<%=txtWrkFromDate.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtWrkFromDate.ClientID%>").focus();
                  document.getElementById("<%=txtWrkToDate.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtWrkToDate.ClientID%>").focus();
                  ret = false;
              }//emp17
              if (document.getElementById("<%=cbxRefCheck.ClientID%>").checked == true) {

                  if (RefName == "") {
                      document.getElementById('divMessageAreaWrkExp').style.display = "";
                      document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                      document.getElementById("<%=txtWrkRefName.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=txtWrkRefName.ClientID%>").focus();
                      ret = false;
                  }

              }

              if (JobTitle == "") {
                  document.getElementById('divMessageAreaWrkExp').style.display = "";
                  document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txtWrkJobTle.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtWrkJobTle.ClientID%>").focus();
                  ret = false;
              }
              if (cmpny == "") {
                  document.getElementById('divMessageAreaWrkExp').style.display = "";
                  document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txtWrkCompny.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtWrkCompny.ClientID%>").focus();
                  ret = false;
              }

              return ret;
          }

          function ClearDivDisplayImageWrkExp() {

              IncrmntConfrmCounterWrkExp();
              var FileUploadPath = document.getElementById("<%=FileUploadWrk.ClientID%>").value.replace("C:\\fakepath\\", "");
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

            if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                        || Extension == "jpeg" || Extension == "jpg") {

            }
            else {
                document.getElementById("<%=FileUploadWrk.ClientID%>").value = "";
                document.getElementById("<%=LabelWrkAttmnt.ClientID%>").textContent = "No File Selected";
                alert("The specified file type could not be uploaded.Only support image files");

            }


            if (document.getElementById("<%=FileUploadWrk.ClientID%>").value != "") {
                document.getElementById("<%=LabelWrkAttmnt.ClientID%>").textContent = document.getElementById("<%=FileUploadWrk.ClientID%>").value.replace("C:\\fakepath\\", "");
                document.getElementById("<%=divWrkImgdis.ClientID%>").innerHTML = "";
                document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";
            }
        }




        function ClearImageWrkExp() {
            if (document.getElementById("<%=hiddenUserImage.ClientID%>").value != "" || document.getElementById("<%=FileUploadWrk.ClientID%>").value != "") {
                if (confirm("Do You Want To Remove Selected Photo?")) {

                    document.getElementById("<%=FileUploadWrk.ClientID%>").value = "";
                    document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";
                    document.getElementById("<%=divWrkImgdis.ClientID%>").innerHTML = "";
                    document.getElementById("<%=LabelWrkAttmnt.ClientID%>").textContent = "No File Selected";
                    //  alert("Image has been Removed Sucessfully. ");
                }
                else {

                }

            }
        }
        function SuccessConfirmationWrkExp() {
            document.getElementById('divMessageAreaWrkExp').style.display = "";
            document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17
      
            document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "Work experience details inserted successfully.";
            $('#divWorkExp input[type="text"]').val('');
            document.getElementById("<%=txtWrkCmnt.ClientID%>").value = "";
            document.getElementById("<%=cbxRefCheck.ClientID%>").checked = false;
            document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value = "Work";
            tableClick('divTblid7', cphMain_Tblid7);

        }
        function SuccessUpdationWrkExp() {
            document.getElementById('divMessageAreaWrkExp').style.display = "";
            document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17
      
            document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "Work experience details updated successfully.";
            $('#divWorkExp input[type="text"]').val('');
            document.getElementById("<%=txtWrkCmnt.ClientID%>").value = "";
            document.getElementById("<%=cbxRefCheck.ClientID%>").checked = false;
            document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value = "Work";
            tableClick('divTblid7', cphMain_Tblid7);
        }

        function SuccessDeletionWrkExp() {
            document.getElementById('divMessageAreaWrkExp').style.display = "";
            document.getElementById('imgMessageAreaWrkExp').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17
      
            document.getElementById("<%=lblMessageAreaWrkExp.ClientID%>").innerHTML = "Work experience details deleted successfully.";

        }

        function updateWrkExpById(Id) {
            $(window).scrollTop(0);    //12emp17
            document.getElementById("<%=txtWrkCompny.ClientID%>").focus();    //emp17focus
            document.getElementById("<%=HiddenWorkExpDtlId.ClientID%>").value = Id;
            var Details = PageMethods.ReadWrkExpDtlById(Id, function (response) {
                document.getElementById("<%=txtWrkCompny.ClientID%>").value = response.Company;
                        document.getElementById("<%=txtWrkJobTle.ClientID%>").value = response.JobTitle;
                        document.getElementById("<%=txtWrkFromDate.ClientID%>").value = response.FromDate;
                        document.getElementById("<%=txtWrkToDate.ClientID%>").value = response.ToDate;
                        document.getElementById("<%=txtWrkCmnt.ClientID%>").value = response.Comment;
                        if (response.RefCheckId == 1) {
                            document.getElementById("<%=cbxRefCheck.ClientID%>").checked = true;
                    document.getElementById("<%=txtWrkRefName.ClientID%>").disabled = false;
                    document.getElementById("<%=txtWrkRefDesg.ClientID%>").disabled = false;
                    document.getElementById("<%=txtWrkRefName.ClientID%>").value = response.RefName;
                    document.getElementById("<%=txtWrkRefDesg.ClientID%>").value = response.RefDesg;
                }
                else {
                    document.getElementById("<%=cbxRefCheck.ClientID%>").checked = false;
                }

                        document.getElementById("cphMain_divWrkImgdis").innerHTML = response.strImg;
                        document.getElementById("<%=hiddenUserImage.ClientID%>").value = response.Fname;

                document.getElementById("cphMain_btnAddWrkExp").style.display = "none";
                document.getElementById("cphMain_btnClearWrkExp").style.display = "none";
                document.getElementById("cphMain_btnUpdateWrkExp").style.display = "block";
                document.getElementById("cphMain_lblWrkExpCaptn").innerText = "Edit Work Experience"

                    });
            return false;
        }
        function deleteWrkExpById(Id) {

            var empId = document.getElementById("<%=HiddenEmpUserId.ClientID%>").value

              if (confirm("Do you want to cancel this Entry?")) {
                  var Details = PageMethods.deleteWrkExpById(Id, empId, function (response) {

                      document.getElementById("cphMain_divListWrkExp").innerHTML = response.strWrkExpList;
                      SuccessDeletionWrkExp();
                      $p('#ReportTableWrkExp').DataTable({ //emp17
                          "pagingType": "full_numbers",
                          "bSort": true

                      });      //emp17

             
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

            NameWithoutReplace = document.getElementById("<%=txtEduMjr.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEduMjr.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtEduYear.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEduYear.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtEduGPA.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEduGPA.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtEduStrtDate.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEduStrtDate.ClientID%>").value = replaceText2;

            NameWithoutReplace = document.getElementById("<%=txtEduEndDate.ClientID%>").value;
            replaceText1 = NameWithoutReplace.replace(/</g, "");
            replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEduEndDate.ClientID%>").value = replaceText2;


            var level = document.getElementById("<%=ddlEduLvl.ClientID%>").value;
            var startDate = document.getElementById("<%=txtEduStrtDate.ClientID%>").value.trim();   //15emp17
            var arrDatePickerDate2 = startDate.split("-");
            var convstartdate = new Date(arrDatePickerDate2[2], arrDatePickerDate2[1] - 1, arrDatePickerDate2[0]);
            var endDate = document.getElementById("<%=txtEduEndDate.ClientID%>").value.trim();
            var arrDatePickerDate3 = endDate.split("-");
            var convenddate = new Date(arrDatePickerDate3[2], arrDatePickerDate3[1] - 1, arrDatePickerDate3[0]);
            var cdate=new Date();//15emp17

            document.getElementById("<%=ddlEduLvl.ClientID%>").style.borderColor = "";
            document.getElementById('divMessageAreaEdu').style.display = "none";
            document.getElementById('imgMessageAreaEdu').src = "";



            if (level == "--Select Level--") {
                document.getElementById('divMessageAreaEdu').style.display = "";
                document.getElementById('imgMessageAreaEdu').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaEdu.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlEduLvl.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlEduLvl.ClientID%>").focus();
                ret = false;
            }
            if(convstartdate > cdate)     //15emp17
            {         document.getElementById('divMessageAreaEdu').style.display = "";
                document.getElementById('imgMessageAreaEdu').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaEdu.ClientID%>").innerHTML = "Date cannot be greater than current date";
                document.getElementById("<%=txtEduStrtDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtEduStrtDate.ClientID%>").focus();
                
                ret = false;
            }
            
            if(convenddate > cdate)
            {   document.getElementById('divMessageAreaEdu').style.display = "";
                document.getElementById('imgMessageAreaEdu').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaEdu.ClientID%>").innerHTML = "Date cannot be greater than current date.";
                document.getElementById("<%=txtEduEndDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtEduEndDate.ClientID%>").focus();
               
                ret = false;
            }
            
            if(startDate!="")
            {
                if(endDate!="")
                {
                    if(endDate < startDate)       
                    {
                        document.getElementById('divMessageAreaEdu').style.display = "";
                        document.getElementById('imgMessageAreaEdu').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageAreaEdu.ClientID%>").innerHTML = "Start date cannot be greater than end  date";
                        document.getElementById("<%=txtEduStrtDate.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtEduStrtDate.ClientID%>").focus();
                        document.getElementById("<%=txtEduEndDate.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtEduEndDate.ClientID%>").focus();
                        ret = false;
                    }    //15emp17
                }
            }


            return ret;
        }
        function ClearDivDisplayImageEdu() {

            IncrmntConfrmCounterEdu();
            var FileUploadPath = document.getElementById("<%=FileUploadEdu.ClientID%>").value.replace("C:\\fakepath\\", "");
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

            if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                        || Extension == "jpeg" || Extension == "jpg") {

            }
            else {
                document.getElementById("<%=FileUploadEdu.ClientID%>").value = "";
                document.getElementById("<%=lblEduImage.ClientID%>").textContent = "No File Selected";
                alert("The specified file type could not be uploaded.Only support image files");

            }


            if (document.getElementById("<%=FileUploadEdu.ClientID%>").value != "") {
                document.getElementById("<%=lblEduImage.ClientID%>").textContent = document.getElementById("<%=FileUploadEdu.ClientID%>").value.replace("C:\\fakepath\\", "");
                    document.getElementById("<%=divEduImgdis.ClientID%>").innerHTML = "";
                    document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";
                }
            }




            function ClearImageEdu() {
                if (document.getElementById("<%=hiddenUserImage.ClientID%>").value != "" || document.getElementById("<%=FileUploadEdu.ClientID%>").value != "") {
                if (confirm("Do You Want To Remove Selected Photo?")) {

                    document.getElementById("<%=FileUploadEdu.ClientID%>").value = "";
                      document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";
                      document.getElementById("<%=divEduImgdis.ClientID%>").innerHTML = "";
                      document.getElementById("<%=lblEduImage.ClientID%>").textContent = "No File Selected";
                      //  alert("Image has been Removed Sucessfully. ");
                  }
                  else {

                  }

              }
          }
          function SuccessConfirmationEdu() {
              document.getElementById('divMessageAreaEdu').style.display = "";
              document.getElementById('imgMessageAreaEdu').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17
              document.getElementById("<%=lblMessageAreaEdu.ClientID%>").innerHTML = "Education details inserted successfully.";
            $('#divEductn input[type="text"]').val('');
            document.getElementById("<%=ddlEduLvl.ClientID%>").value = "--Select Level--";
             document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value = "Education";
              tableClick('divTblid7', cphMain_Tblid7);

        }
        function SuccessUpdationEdu() {
            document.getElementById('divMessageAreaEdu').style.display = "";
            document.getElementById('imgMessageAreaEdu').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17
            document.getElementById("<%=lblMessageAreaEdu.ClientID%>").innerHTML = "Education details updated successfully.";
             $('#divEductn input[type="text"]').val('');
             document.getElementById("<%=ddlEduLvl.ClientID%>").value = "--Select Level--";
            document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value = "Education";
            tableClick('divTblid7', cphMain_Tblid7);
         }
         function SuccessDeletionEdu() {
             document.getElementById('divMessageAreaEdu').style.display = "";
             document.getElementById('imgMessageAreaEdu').src = "/Images/Icons/imgMsgAreaInfo.png"; //2emp17
             document.getElementById("<%=lblMessageAreaEdu.ClientID%>").innerHTML = "Education details deleted successfully.";

        }
        function updateEduDtlById(Id) {

             
            document.getElementById('cphMain_ddlEduLvl').focus();    //15emp17
            document.getElementById("<%=HiddenEductnDtlId.ClientID%>").value = Id;
            var Details = PageMethods.ReadEduDtlById(Id, function (response) {

                if (response.LvlSts == "1") {
                    document.getElementById("<%=ddlEduLvl.ClientID%>").value = response.LvlId;
                }
                else if (response.LvlSts == "0") {
                    var $Mo = jQuery.noConflict();
                    var newOption = "<option value='" + response.LvlId + "'>" + response.LvlName + "</option>";

                    $Mo('#<%=ddlEduLvl.ClientID%>').append(newOption);
                    //SORTING DDL
                    var options = $Mo("#<%=ddlEduLvl.ClientID%> option");                    // Collect options         
                    options.detach().sort(function (a, b) {               // Detach from select, then Sort
                        var at = $Mo(a).text();
                        var bt = $Mo(b).text();
                        return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                    });
                    options.appendTo('#<%=ddlEduLvl.ClientID%>');
                    document.getElementById("<%=ddlEduLvl.ClientID%>").value = response.LvlId;

                }



                document.getElementById("<%=txtEduInstite.ClientID%>").value = response.Institute;
                document.getElementById("<%=txtEduMjr.ClientID%>").value = response.MjrSpec;
                document.getElementById("<%=txtEduYear.ClientID%>").value = response.year;
                document.getElementById("<%=txtEduGPA.ClientID%>").value = response.Score;
                document.getElementById("<%=txtEduStrtDate.ClientID%>").value = response.StartDate;
                document.getElementById("<%=txtEduEndDate.ClientID%>").value = response.EndDate;
                document.getElementById("cphMain_divEduImgdis").innerHTML = response.strImg;
                document.getElementById("<%=hiddenUserImage.ClientID%>").value = response.Fname;

                document.getElementById("cphMain_BtnAddEdu").style.display = "none";
                document.getElementById("cphMain_BtnClearEdu").style.display = "none";
                document.getElementById("cphMain_BtnUpdateEdu").style.display = "block";
                document.getElementById("cphMain_lblEduCaptn").innerText = "Edit Education";
                $(Window).scrollTop(0);    //15emp17
        
            });
            return false;
        }

        function deleteEduDtlById(Id) {
            document.getElementById('cphMain_ddlEduLvl').focus();    //15emp17
            var empId = document.getElementById("<%=HiddenEmpUserId.ClientID%>").value

            if (confirm("Do you want to cancel this Entry?")) {
                var Details = PageMethods.deleteEduById(Id, empId, function (response) {

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


        function SkillCerRadioChange() {
            IncrmntConfrmCounterSklCer();
            var empId = document.getElementById("<%=HiddenEmpUserId.ClientID%>").value
            var mode = 0;
            if (document.getElementById("<%=radioSkill.ClientID%>").checked == true) {
                mode = 0;
                document.getElementById("divSkill").style.display = "block";
                document.getElementById("divCer").style.display = "none";
            }
            else {
                mode = 1;
                document.getElementById("divSkill").style.display = "none";
                document.getElementById("divCer").style.display = "block";
            }


            var Details = PageMethods.readSklCerList(empId, mode, function (response) {

                document.getElementById("cphMain_divSkCerList").innerHTML = response.SklCerList;
                $p('#ReportTableSkCer').DataTable({               //12emp17
                    "pagingType": "full_numbers",
                    "bSort": true


                });
            });
        }
        function ValidateSkCer() {
            var ret = true;
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtSCCertfcn.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtSCCertfcn.ClientID%>").value = replaceText2;

              NameWithoutReplace = document.getElementById("<%=txtSCYearExp.ClientID%>").value;
              replaceText1 = NameWithoutReplace.replace(/</g, "");
              replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtSCYearExp.ClientID%>").value = replaceText2;

              NameWithoutReplace = document.getElementById("<%=txtSCcmnt.ClientID%>").value;
              replaceText1 = NameWithoutReplace.replace(/</g, "");
              replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtSCcmnt.ClientID%>").value = replaceText2;




              var skill = document.getElementById("<%=ddlSCSkill.ClientID%>").value;
              var Certfcn = document.getElementById("<%=txtSCCertfcn.ClientID%>").value.trim();


              document.getElementById("<%=ddlSCSkill.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtSCCertfcn.ClientID%>").style.borderColor = "";
              document.getElementById('divMessageAreaSkCer').style.display = "none";
              document.getElementById('imgMessageAreaSkCer').src = "";

              if (document.getElementById("<%=radioSkill.ClientID%>").checked == true) {

                  if (skill == "--Select Skill--") {
                      document.getElementById('divMessageAreaSkCer').style.display = "";
                      document.getElementById('imgMessageAreaSkCer').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=lblMessageAreaSkCer.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=ddlSCSkill.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddlSCSkill.ClientID%>").focus();
                    ret = false;
                }
            }
            else {

                if (Certfcn == "") {
                    document.getElementById('divMessageAreaSkCer').style.display = "";
                    document.getElementById('imgMessageAreaSkCer').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaSkCer.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtSCCertfcn.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtSCCertfcn.ClientID%>").focus();
                    ret = false;
                }
            }

            return ret;
        }
        function ClearDivDisplayImageSkCer() {

            IncrmntConfrmCounterSklCer();
            var FileUploadPath = document.getElementById("<%=FileUploadSkCer.ClientID%>").value.replace("C:\\fakepath\\", "");
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

            if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                        || Extension == "jpeg" || Extension == "jpg") {

            }
            else {
                document.getElementById("<%=FileUploadSkCer.ClientID%>").value = "";
                document.getElementById("<%=lblSKCerImg.ClientID%>").textContent = "No File Selected";
                alert("The specified file type could not be uploaded.Only support image files");

            }


            if (document.getElementById("<%=FileUploadSkCer.ClientID%>").value != "") {
                document.getElementById("<%=lblSKCerImg.ClientID%>").textContent = document.getElementById("<%=FileUploadSkCer.ClientID%>").value.replace("C:\\fakepath\\", "");
                document.getElementById("<%=divSkCerImgDis.ClientID%>").innerHTML = "";
                document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";
            }
        }




        function ClearImageSkCer() {
            if (document.getElementById("<%=hiddenUserImage.ClientID%>").value != "" || document.getElementById("<%=FileUploadSkCer.ClientID%>").value != "") {
                if (confirm("Do You Want To Remove Selected Photo?")) {

                    document.getElementById("<%=FileUploadSkCer.ClientID%>").value = "";
                    document.getElementById("<%=hiddenUserImage.ClientID%>").value = "";
                    document.getElementById("<%=divSkCerImgDis.ClientID%>").innerHTML = "";
                    document.getElementById("<%=lblSKCerImg.ClientID%>").textContent = "No File Selected";
                    //  alert("Image has been Removed Sucessfully. ");
                }
                else {

                }

            }
        }
        function SuccessConfirmationSkCer() {
            document.getElementById('divMessageAreaSkCer').style.display = "";

            document.getElementById("<%=lblMessageAreaSkCer.ClientID%>").innerHTML = "Skill & certification details inserted successfully.";
            document.getElementById('imgMessageAreaSkCer').src = "/Images/Icons/imgMsgAreaInfo.png";
      
            $('#divSkillCer input[type="text"]').val('');
            document.getElementById("<%=txtSCcmnt.ClientID%>").value = "";
             document.getElementById("<%=ddlSCSkill.ClientID%>").value = "--Select Skill--";
            if( document.getElementById("<%=radioSkill.ClientID%>").checked == true)
            {
             
                document.getElementById("<%=radioSkill.ClientID%>").checked = true;
             }
             else
                 document.getElementById("<%=radioCer.ClientID%>").checked = true;
        
            //SkillCerRadioChange();
             document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value = "Skl&Cer";
            tableClick('divTblid7', cphMain_Tblid7);
        }
        function SuccessUpdationSkCer() {
            document.getElementById('imgMessageAreaSkCer').src = "/Images/Icons/imgMsgAreaInfo.png";
      
            document.getElementById('divMessageAreaSkCer').style.display = "";
            document.getElementById("<%=lblMessageAreaSkCer.ClientID%>").innerHTML = "Skill & certification details updated successfully.";
             $('#divSkillCer input[type="text"]').val('');
             document.getElementById("<%=txtSCcmnt.ClientID%>").value = "";
             document.getElementById("<%=ddlSCSkill.ClientID%>").value = "--Select Skill--";
             if( document.getElementById("<%=radioSkill.ClientID%>").checked == true)
             {
             
                 document.getElementById("<%=radioSkill.ClientID%>").checked = true;
             }
             else
                 document.getElementById("<%=radioCer.ClientID%>").checked = true;
        
             //SkillCerRadioChange();
       
             document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value = "Skl&Cer";
            tableClick('divTblid7', cphMain_Tblid7);
         }
         function SuccessDeletionSkCer() {
             document.getElementById('imgMessageAreaSkCer').src = "/Images/Icons/imgMsgAreaInfo.png";
      
             document.getElementById('divMessageAreaSkCer').style.display = "";
             document.getElementById("<%=lblMessageAreaSkCer.ClientID%>").innerHTML = "Skill & certification details deleted successfully.";

         }

         function updateSklCerDtlById(Id) {
             $(window).scrollTop(0);     //12emp17
             document.getElementById("<%=HiddenFieldSkCerDtlId.ClientID%>").value = Id;
            var Details = PageMethods.ReadSklCerDtlById(Id, function (response) {
                if (document.getElementById("<%=radioSkill.ClientID%>").checked == true) {
                      if (response.SkillSts == "1") {
                          document.getElementById("<%=ddlSCSkill.ClientID%>").value = response.SkillId;
                    }
                    else if (response.SkillSts == "0") {
                        var $Mo = jQuery.noConflict();
                        var newOption = "<option value='" + response.SkillId + "'>" + response.SkillName + "</option>";

                        $Mo('#<%=ddlSCSkill.ClientID%>').append(newOption);
                        //SORTING DDL
                        var options = $Mo("#<%=ddlSCSkill.ClientID%> option");                    // Collect options         
                        options.detach().sort(function (a, b) {               // Detach from select, then Sort
                            var at = $Mo(a).text();
                            var bt = $Mo(b).text();
                            return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                        });
                        options.appendTo('#<%=ddlSCSkill.ClientID%>');
                        document.getElementById("<%=ddlSCSkill.ClientID%>").value = response.SkillId;

                    }

            }
            else {
                document.getElementById("<%=txtSCCertfcn.ClientID%>").value = response.Certfcn;
                  }

                  document.getElementById("<%=txtSCYearExp.ClientID%>").value = response.YearExp;
                  document.getElementById("<%=txtSCcmnt.ClientID%>").value = response.comment;

                  document.getElementById("cphMain_divSkCerImgDis").innerHTML = response.strImg;
                  document.getElementById("<%=hiddenUserImage.ClientID%>").value = response.Fname;

                document.getElementById("cphMain_BtnAddSkCer").style.display = "none";
                document.getElementById("cphMain_BtnClearSkCer").style.display = "none";
                document.getElementById("cphMain_BtnUpdateSkCer").style.display = "block";
                document.getElementById("cphMain_lblSkillCer").innerText = "Edit Skills & Certifications";

              });
            return false;
        }
        function deleteSklCerDtlById(Id) {

            var empId = document.getElementById("<%=HiddenEmpUserId.ClientID%>").value
            var mode = 0;
            if (document.getElementById("<%=radioSkill.ClientID%>").checked == true) {
                mode = 0;
            }
            else {
                mode = 1;
            }

            if (confirm("Do you want to cancel this Entry?")) {
                var Details = PageMethods.deleteSklCerDtlById(Id, empId, mode, function (response) {

                    document.getElementById("cphMain_divSkCerList").innerHTML = response.SklCerList;
                    SuccessDeletionSkCer();

                    $p('#ReportTableSkCer').DataTable({               //12emp17
                        "pagingType": "full_numbers",
                        "bSort": true


                    });
                });
            }
            else {

            }


        }



        function ValidateLang() {
            var ret = true;
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtLangCmnt.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtLangCmnt.ClientID%>").value = replaceText2;

            var language = document.getElementById("<%=ddlQuLang.ClientID%>").value;

            document.getElementById("<%=ddlQuLang.ClientID%>").style.borderColor = "";
            document.getElementById("divSkillCbx").style.borderColor = "#cfcccc";
            document.getElementById('divMessageAreaLang').style.display = "none";
            document.getElementById('imgMessageAreaLang').src = "";


            if (document.getElementById("<%=CbxLangWrt.ClientID%>").checked == false && document.getElementById("<%=CbxLangRead.ClientID%>").checked == false && document.getElementById("<%=CbxLangSpk.ClientID%>").checked == false) {
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
        function SuccessConfirmationLang() {
            document.getElementById('divMessageAreaLang').style.display = "";
            document.getElementById('imgMessageAreaLang').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageAreaLang.ClientID%>").innerHTML = "Language details inserted successfully.";
             $('#divLang').find('input[type=checkbox]:checked').removeAttr('checked');
             document.getElementById("<%=txtLangCmnt.ClientID%>").value = "";
             document.getElementById("<%=ddlQuLang.ClientID%>").value = "--Select Language--";
             document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value = "Language";
            tableClick('divTblid7', cphMain_Tblid7);
         }
         function SuccessUpdationLang() {
             document.getElementById('divMessageAreaLang').style.display = "";
             document.getElementById('imgMessageAreaLang').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageAreaLang.ClientID%>").innerHTML = "Language details updated successfully.";
            $('#divLang').find('input[type=checkbox]:checked').removeAttr('checked');
            document.getElementById("<%=txtLangCmnt.ClientID%>").value = "";
            document.getElementById("<%=ddlQuLang.ClientID%>").value = "--Select Language--";
            document.getElementById("<%=HiddenFieldQualfcnMode.ClientID%>").value = "Language";
             tableClick('divTblid7', cphMain_Tblid7);
        }
        function SuccessDeletionLang() {
            document.getElementById('divMessageAreaLang').style.display = "";
            document.getElementById("<%=lblMessageAreaLang.ClientID%>").innerHTML = "Language details deleted successfully.";

        }
        function updateLangDtlById(Id) {

            $(window).scrollTop(0);//12emp17
            document.getElementById("<%=ddlQuLang.ClientID%>").focus(); //12emp17
            document.getElementById("<%=HiddenFieldLangDtlId.ClientID%>").value = Id;
            var Details = PageMethods.updateLangDtlById(Id, function (response) {

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
                      document.getElementById("<%=ddlQuLang.ClientID%>").value = response.LangId;

                }
                if (response.LangWrtId == 1) {
                    document.getElementById("<%=CbxLangWrt.ClientID%>").checked = true;
                }
                if (response.LangRedId == 1) {
                    document.getElementById("<%=CbxLangRead.ClientID%>").checked = true;
                }
                if (response.LangSpkId == 1) {
                    document.getElementById("<%=CbxLangSpk.ClientID%>").checked = true;
                }
                var FlUencYPAss="s"+response.FlncyLvlId;
             
                if(response.FlncyLvlId=="")
                {
                    selectingstar(0);
               
                }
                else
                {
                    selectingstar(FlUencYPAss);
                }

                document.getElementById("<%=txtLangCmnt.ClientID%>").value = response.comment;

                document.getElementById("cphMain_BtnLangAdd").style.display = "none";
                document.getElementById("cphMain_BtnLangClear").style.display = "none";
                document.getElementById("cphMain_BtnLangUpdate").style.display = "block";
                document.getElementById("cphMain_lblLangCaptn").innerText = "Edit Language";

            });
            return false;
        }
        function deleteLangDtlById(Id) {

            var empId = document.getElementById("<%=HiddenEmpUserId.ClientID%>").value

            if (confirm("Do you want to cancel this entry?")) {
                var Details = PageMethods.deleteLangDtlById(Id, empId, function (response) {

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
        function LoadMessLoad()
        {
          
            var $Mo = jQuery.noConflict();
             
           
             
              
          
        }
        function UpdateAccomdtn(x,y,a,b)
        {
            
            if(x!="" && x!=0 && y!="")
            {
                var $Mo = jQuery.noConflict();
                var newOption = "<option value='" + x + "'>" + y + "</option>";

                $Mo('#<%=ddlCategry.ClientID%>').append(newOption);
                  //SORTING DDL
                  var options = $Mo("#<%=ddlCategry.ClientID%> option");                    // Collect options         
                  options.detach().sort(function (a, b) {               // Detach from select, then Sort
                      var at = $Mo(a).text();
                      var bt = $Mo(b).text();
                      return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                  });
                  options.appendTo('#<%=ddlCategry.ClientID%>');
                  document.getElementById("<%=ddlCategry.ClientID%>").value =x;
              }

              if(a!="" && a!=0 && b!="")
              {

                  var $Moo = jQuery.noConflict();
                  var newOption = "<option value='" + a + "'>" + b + "</option>";

                  $Moo('#<%=ddlSubCat.ClientID%>').append(newOption);
                  //SORTING DDL
                  var options = $Moo("#<%=ddlSubCat.ClientID%> option");                    // Collect options         
                  options.detach().sort(function (a, b) {               // Detach from select, then Sort
                      var at = $Moo(a).text();
                      var bt = $Moo(b).text();
                      return (at > bt) ? 1 : ((at < bt) ? -1 : 0);            // Tell the sort function how to order
                  });
                  options.appendTo('#<%=ddlSubCat.ClientID%>');
                  document.getElementById("<%=ddlSubCat.ClientID%>").value =a;
              }
          }
        

          function LoadSubCategry()
          {
              var $Mo = jQuery.noConflict();
              var accmdtn=  document.getElementById("<%=ddlAccmdtn.ClientID%>").value;
              var accmdtnCat=  document.getElementById("<%=ddlCategry.ClientID%>").value;
             if(accmdtn!="--SELECT--")
             {
                 if(accmdtnCat!="--SELECT--")
                 {
                     var tableName = "dtTableAllwnce";
                     var Details = PageMethods.LoadAcccmdtnSubCat(accmdtn,accmdtnCat, function (response) {


                         var OptionStart = $Mo("<option>--SELECT--</option>");

                         OptionStart.attr("value", 0);
                         $Mo('#<%=ddlSubCat.ClientID%>').empty();
                          $Mo('#<%=ddlSubCat.ClientID%>').append(OptionStart);

                          // Now find the Table from response and loop through each item (row).
                          $Mo(response).find(tableName).each(function () {
                              // Get the OptionValue and OptionText Column values.
                              var OptionValue = $Mo(this).find('ACSUBCATDTL_ID').text();
                              var OptionText = $Mo(this).find('ACSUBCATDTL_NAME').text();
                              // Create an Option for DropDownList.
                              var option = $Mo("<option>" + OptionText + "</option>");
                              option.attr("value", OptionValue);
                              $Mo('#<%=ddlSubCat.ClientID%>').append(option);

                          });
                          // return false;
                      });
                  }
                  else
                  {
                      document.getElementById("<%=ddlSubCat.ClientID%>").selectedIndex=0;
                  }

              }

          }
          function CheckMandatory()
          {
              var accmdtn=  document.getElementById("<%=ddlAccmdtn.ClientID%>").value;
            
              if(accmdtn!="--SELECT--")
              {
                  document.getElementById("AccSubCat1").style.display="block";
                  document.getElementById("AccRoom1").style.display="block";
                  document.getElementById("AccDate1").style.display="block";
                  document.getElementById("AccSubCat").style.display="none";
                  document.getElementById("AccRoom").style.display="none";
                  document.getElementById("AccDate").style.display="none";
              }
              else
              {
                  document.getElementById("AccSubCat1").style.display="none";
                  document.getElementById("AccRoom1").style.display="none";
                  document.getElementById("AccDate1").style.display="none";
                  document.getElementById("AccSubCat").style.display="block";
                  document.getElementById("AccRoom").style.display="block";
                  document.getElementById("AccDate").style.display="block";
                  document.getElementById("<%=OccupyDate.ClientID%>").value="";   
                  document.getElementById("<%=txtAcmdtnToDate.ClientID%>").value="";  
              }
          }
          function CheckMess()    //emp25
          {
             
              var mess=document.getElementById("<%=DdlMess.ClientID%>").value;
           
              if(mess!="--SELECT--")
              {
                
                
                  document.getElementById("lblDtFrmMess1").style.display="block";
                  document.getElementById("lblDtFrmMess").style.display="none";
              
                  
              }
              else
              {
               
                  document.getElementById("lblDtFrmMess1").style.display="none";
              
                  document.getElementById("lblDtFrmMess").style.display="block";

                  document.getElementById("<%=txtMessFromDate.ClientID%>").value="";
                  document.getElementById("<%=txtMessToDate.ClientID%>").value="";
              }


          }

          
          
    </script>
    <script>
        function LoadCategry()
        { 
              
            var $Mo = jQuery.noConflict();
            var accmdtn=  document.getElementById("<%=ddlAccmdtn.ClientID%>").value;
              CheckMandatory();
                         if(accmdtn!="--SELECT--")
              {
                  var tableName = "dtTableAllwnce";
                  var Details = PageMethods.LoadAcccmdtnCat(accmdtn, function (response) {


                      var OptionStart = $Mo("<option>--SELECT--</option>");

                      OptionStart.attr("value", 0);
                      $Mo('#<%=ddlCategry.ClientID%>').empty();
                      $Mo('#<%=ddlCategry.ClientID%>').append(OptionStart);

                      // Now find the Table from response and loop through each item (row).
                      $Mo(response).find(tableName).each(function () {
                          // Get the OptionValue and OptionText Column values.
                          var OptionValue = $Mo(this).find('ACCOMDTNCATSUB_ID').text();
                          var OptionText = $Mo(this).find('ACCOMDTNCATSUB_NAME').text();
                          // Create an Option for DropDownList.
                          var option = $Mo("<option>" + OptionText + "</option>");
                          option.attr("value", OptionValue);
                          $Mo('#<%=ddlCategry.ClientID%>').append(option);

                      });
                      // return false;
                  });
                 
                  var OptionStart = $Mo("<option>--SELECT--</option>");

                  OptionStart.attr("value", 0);
                  $Mo('#<%=ddlSubCat.ClientID%>').empty();
                  $Mo('#<%=ddlSubCat.ClientID%>').append(OptionStart);

                            

              }
              else
              {
                  var OptionStart = $Mo("<option>--SELECT--</option>");

                  OptionStart.attr("value", 0);
                  $Mo('#<%=ddlCategry.ClientID%>').empty();
                  $Mo('#<%=ddlCategry.ClientID%>').append(OptionStart);
                  var OptionStart = $Mo("<option>--SELECT--</option>");

                  OptionStart.attr("value", 0);
                  $Mo('#<%=ddlSubCat.ClientID%>').empty();
                  $Mo('#<%=ddlSubCat.ClientID%>').append(OptionStart);
                                           }
          
        }


        //emp-0043 start
        function paymentClick()
        {
            if(document.getElementById("<%=RadioBank.ClientID%>").checked==true)
              {
                  document.getElementById("<%=ddlBank.ClientID%>").disabled=false;
                  document.getElementById("<%=txtBranch.ClientID%>").disabled=false;
                  document.getElementById("<%=ddlAccntTyp.ClientID%>").disabled=false;
                  document.getElementById("<%=txtIban.ClientID%>").disabled=false;
                  document.getElementById("<%=txtCardNo.ClientID%>").disabled=false;
                  $("div#divddlbnk input.ui-autocomplete-input").removeAttr("disabled");
              }
              else
              {
                  //document.getElementById("<%=ddlBank.ClientID%>").value="";
                  // document.getElementById("<%=txtBranch.ClientID%>").value="";
                  // document.getElementById("<%=ddlAccntTyp.ClientID%>").value="";
                  // document.getElementById("<%=txtIban.ClientID%>").value="";
                  document.getElementById("<%=ddlBank.ClientID%>").disabled=true;
                  document.getElementById("<%=txtBranch.ClientID%>").disabled=true;
                  document.getElementById("<%=ddlAccntTyp.ClientID%>").disabled=true;
                  document.getElementById("<%=txtIban.ClientID%>").disabled=true;
                  document.getElementById("<%=txtCardNo.ClientID%>").disabled=true;
                  $("div#divddlbnk input.ui-autocomplete-input").attr("disabled", "disabled");
              }
              //end
          }
         
    </script>
    <link href="../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen"
        href="../../css/Date/StyleSheetDate.css" />
     <script type="text/javascript" src="../../JavaScript/Date/JavaScriptDate1_8_3.js"></script>
                        
    <script type="text/javascript"
                            src="../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                        </script>
                        <script type="text/javascript"
                            src="../../JavaScript/Date/bootstrap-datepicker.js">
                        </script>
                        <script type="text/javascript"
                            src="../../JavaScript/Date/bootstrap-datepicker_pt_br.js">
                        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
     <asp:HiddenField ID="hiddenJoiningDateOnPageLoad" runat="server" /> 
     <asp:HiddenField ID="HiddenFieldJoinDateLimit" runat="server" /> 


     <%--  Start:-Empcode--%>
        <asp:HiddenField ID="HiddenFieldNewNextId" runat="server" /> 
        <asp:HiddenField ID="HiddenFieldInsdate" runat="server" /> 
     <%--  End:-Empcode--%>

     <asp:HiddenField ID="HiddenEmployeeMasterId" runat="server" />
    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="hiddenCancelReason" runat="server" />
    <asp:HiddenField ID="hiddenRoleReOpen" runat="server" />
    <asp:HiddenField ID="hiddenUserImageSize" runat="server" />
    <asp:HiddenField ID="hiddenUserImage" runat="server" />
    <asp:HiddenField ID="hiddenImageName" runat="server" />     
      
    <asp:HiddenField ID="HiddenAccCat" runat="server" /> 
    <asp:HiddenField ID="HiddenAccSubCat" runat="server" /> 
    <asp:HiddenField ID="HiddenEmpType" runat="server" /> 
      <asp:HiddenField ID="HiddenFieldRsgnSts" runat="server" />

     <asp:HiddenField ID="HiddenEmployeeId" runat="server" />
    <asp:HiddenField ID="HiddenView" runat="server" />
   
     <asp:HiddenField ID="Hiddenchecklist" runat="server" />
        <asp:HiddenField ID="HiddenWelfareId" runat="server" /> <%--emp00025--%>
     <asp:HiddenField ID="HiddenWelfareSubid" runat="server" />
   <%-- <div id="weekly" style="float:left;margin-top:1% ;width: 77%;">

          <%-- //SALARY DETAILS--%>
      <%-- //SALARY DETAILS--%>
        <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />  
     <asp:HiddenField ID="hiddenDecimalCount" runat="server" />  
       <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />  
     <asp:HiddenField ID="HiddenOrgId" runat="server" />  
      <asp:HiddenField ID="HiddenCorpId" runat="server" />
      <asp:HiddenField ID="HiddenJobProbId" runat="server" />                   
      <asp:HiddenField ID="HiddenJobRenew" runat="server" />
     <asp:HiddenField ID="HiddenRestrctRange" runat="server" />
     <asp:HiddenField ID="HiddenEmpSalryId" runat="server" />
     <asp:HiddenField ID="HiddenPayGrdeId" runat="server" />
      <asp:HiddenField ID="HiddenddlAllDed" runat="server" />
      <asp:HiddenField ID="HiddnEnableCacel" runat="server" />
    <asp:HiddenField ID="HiddenUserId" runat="server" />
     <asp:HiddenField ID="HiddenDelChk" runat="server" />
     <asp:HiddenField ID="hiddenRsnid" runat="server" />

     <asp:HiddenField ID="HiddenSalaryAllwceId" runat="server" />
     <asp:HiddenField ID="HiddenSalaryDedctnId" runat="server" />
     <asp:HiddenField ID="HiddenSalarSummry" runat="server" />
     <asp:HiddenField ID="HiddenEmplyId" runat="server" />
     <asp:HiddenField ID="HiddenAmountRngeChk" runat="server" />
     <asp:HiddenField ID="HiddenSalaryAbbrv" runat="server" />
     <asp:HiddenField ID="HiddenRestrctRangeAllw" runat="server" />
     <asp:HiddenField ID="HiddenRestrctRangeDedctn" runat="server" />
      <asp:HiddenField ID="Hiddenreturnfun" runat="server" />
   
     <asp:HiddenField ID="HiddenTotalpay" Value="0" runat="server" />
     <asp:HiddenField ID="HiddenTotalpayAllw" Value="0" runat="server" />
     <asp:HiddenField ID="HiddenTotalPerTotal" Value="0" runat="server" />
      <asp:HiddenField ID="HiddenTotalPerBasic" Value="0" runat="server" />
       <asp:HiddenField ID="HiddenPayGradechnge" Value="0" runat="server" />
     <asp:HiddenField ID="HiddenAccmdtnSaveChk" Value="0" runat="server" />
         <asp:HiddenField ID="HiddenDivision" Value="0" runat="server" />

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

     <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />
    <%---Start Contact details --%>
        <asp:HiddenField ID="hiddenConfirmValueCD" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDateCD" runat="server" />
      <asp:HiddenField ID="HiddenContactUserId" runat="server" />
    
         <asp:HiddenField ID="HiddenStateValueCD" runat="server"/>
    <asp:HiddenField ID="HiddenCityValueCD" runat="server"/>
        <asp:HiddenField ID="HiddenCommuStateValueCD" runat="server"/>
    <asp:HiddenField ID="HiddenCommuCityValueCD" runat="server"/>
    <asp:HiddenField ID="HiddenCommuCountryValueCD" runat="server"/>
    <asp:HiddenField ID="HiddenCountryValueCD" runat="server"/>
        <%--end Contact details ---%>
       <%----------------- Start Qualification -------------%>
     <asp:HiddenField ID="HiddenWorkExpDtlId" runat="server" />  
     <asp:HiddenField ID="HiddenField4" runat="server" />
     <asp:HiddenField ID="HiddenEductnDtlId" runat="server" />
     <asp:HiddenField ID="HiddenFieldSkCerDtlId" runat="server" />
     <asp:HiddenField ID="HiddenFieldLangDtlId" runat="server" />
     <asp:HiddenField ID="HiddenFieldQualfcnMode" runat="server" />
 
        <asp:HiddenField ID="HiddenFluency" runat="server" />
      <%------------------End Qualification ----------------%>

        <div id="emplyoptn" style="float:left;margin-top: 3%;margin-left: 0%;width: 13%;">
        <table id = "test" class="logo" style="width:99%;float:left;margin-right:0%;height:10%; border:  2px solid #06558f;border-spacing: 10px;font-family:Calibri">
             <tr id="TrTblid8" runat="server">
                <td  id="Tblid8"  onclick="tableClick('divTblid8',cphMain_Tblid8);" style="font-family:Calibri">Personal Details</td></tr>
            <tr id="TrTblid1" runat="server">
                <td   id="Tblid1"  onclick="tableClick('divTblid1',cphMain_Tblid1);">Other Details</td> </tr>
            <tr id="TrTblid2" runat="server">
                <td  id="Tblid2"  onclick="tableClick('divTblid2',cphMain_Tblid2);">Contact Details</td></tr>
               <tr id="TrTblid3" runat="server">
                    <td  id="Tblid3"  onclick="tableClick('divTblid3',cphMain_Tblid3);">Dependents</td></tr>
            <tr id="TrTblid4" runat="server">

                <td  id="Tblid4"  onclick="tableClick('divTblid4',cphMain_Tblid4);">Immigration</td></tr>
             <tr id="TrTblid5" runat="server">
                <td  id="Tblid5"  onclick="tableClick('divTblid5',cphMain_Tblid5);">Job</td></tr>
            <tr id="TrTblid6" runat="server">

                <td  id="Tblid6"  onclick="tableClick('divTblid6',cphMain_Tblid6);">Salary</td></tr>
            <tr id="TrTblid7" runat="server">

                <td  id="Tblid7"  onclick="tableClick('divTblid7',cphMain_Tblid7);">Qualification</td></tr>
     <tr id="TrTblid9" runat="server">

                <td  id="Tblid9"  onclick="tableClick('divTblid9',cphMain_Tblid9);">Resignation</td></tr>
   

           
        </table>


            </div>

 <%--   </div>--%>
   
    
          <div id="div1" class="list"  onclick="return ConfirmMessage();"  runat="server" style="position:fixed; right:0%; top:42%;height:26.5px;">

        </div>
  
    
         
        <div id="divMain" style="width: 82%; margin-top: 3%;float: left;margin-left: 0%; ">
              <div id="divMessageArea" style="display:none; width: 84%; margin-left: 6%;margin-top: -12px;">
                 <img id="imgMessageArea" src="" />
                 <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
                 </div>
               <asp:HiddenField ID="hiddendetailidresignation" runat="server" />

                  <%--------------------Resign details start--------------------------%>
             <div id="divTblid9" style="float: left; background-color: #f3f3f3; width: 100%; border: 2px solid; border-color: #06558f; padding: 2%; display: none;">
                <div id="divMessageAreaRS" style="display: none; width: 84%; margin-left: 6%;">
                    <img id="imgMessageAreaRS" src="" />
                    <asp:Label ID="lblMessageAreaRes" runat="server"></asp:Label>
                </div>
                <div id="divReportCaptionRS" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; width: 99%;">
                    <asp:Label ID="lblEntryRS" runat="server">FINAL STAGE</asp:Label>
                </div>
                <br />
                <br />
                <div style="float: left; width: 47%">
            
                 
                      <div class="eachform" style="float:left;width:98%;">
                <h2>Leaving Date*</h2>
                
               <div id="DivLeavingDate" class="input-append date">

                 
                   
                        <asp:TextBox ID="txtleavingdate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height:30px;width:43.7%;margin-top: 0%;float:left;margin-left:25.9%;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image19" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#DivLeavingDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                              
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
              


            </div>
                    
                    <div class="eachform" style="float: left; width: 99%">
                        <h2>Status</h2>
                        <asp:DropDownList ID="ddlresignstatus"  Height="30px" Width="54%" class="form1" runat="server" Style="text-align: left;">
                       <asp:ListItem Text="Resign" Value="1"></asp:ListItem>
            <asp:ListItem Text="Retirement" Value="2"></asp:ListItem>
            <asp:ListItem Text="Termination" Value="3"></asp:ListItem>
            <asp:ListItem Text="Abscond" Value="4"></asp:ListItem>
            <asp:ListItem Text="Death" Value="5"></asp:ListItem>
            <asp:ListItem Text="Rejoin" Value="6"></asp:ListItem>
            <asp:ListItem Text="Under Police custody" Value="7"></asp:ListItem>
            <asp:ListItem Text="Other" Value="8"></asp:ListItem>
                   
                                      
          

                        </asp:DropDownList>
                   
                         </div>
                   

                         <div class="eachform" style="float: left; width: 99%">
                            <h2>Reason</h2>
                        <textarea id="txtResgnreasn" class="form1" runat="server" type="multiline" maxlength="100" tabindex="0" style="resize: none; width:50%; height:53px; font-family: calibri;"></textarea>
                        </div>                                          
                       
                    </div>
                    <div class="eachform" style="margin-top: 4%; margin-left: 20%;">
                        <div class="subform" style="width: 448px;">
                            <div class="form-group">
                                 <asp:Button ID="btnAddRS" runat="server" Visible="false" class="save" Text="Save" OnClick="btnAddRS_Click" OnClientClick="return ValidateRS();" />
                               
                            </div>
                        </div>
                    </div>
                </div>


           


                  <%--------------------Resign details start--------------------------%>


            <%--------------------personal details start--------------------------%>
                <div id="divTblid1" style="float: left;background-color: #f3f3f3;  width: 100%;border: 2px solid;border-color: #06558f;padding: 2%;display:none;">
            <div id="divMessageAreaPD" style="display:none; width: 84%; margin-left: 6%;margin-top: -12px;">
                 <img id="imgMessageAreaPD" src="" />
                 <asp:Label ID="lblMessageAreaPD" runat="server"></asp:Label>
                 </div>


              <div id="divcaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <asp:Label ID="LblEntryother" runat="server">Add Other Details</asp:Label>
             </div>
            <br />
          
    
            <div class="eachform" style="float:right; display:none;">
                <h2>Employee Id*</h2>
               
                <asp:TextBox ID="Txtemplyid" Enabled="true" class="form1" runat="server" MaxLength="500" Width="50%" Height="30px"  Style="resize:none; text-transform: uppercase; font-family: calibri;" onchange="changetxtempid();"></asp:TextBox>
             
            </div>

           
          
            <div class="eachform" style="float:left; display:none;">
                <h2>Reference Number*</h2>
               
                <asp:TextBox ID="txtRefNum" Enabled="false" class="form1" runat="server"   MaxLength="500" Width="50%" Height="30px"  Style="height:30px;width:49%;resize:none; text-transform: uppercase; font-family: calibri;float: left;margin-left: 18%;"></asp:TextBox>
             
            </div>  <div class="eachform" style="float:left;">
                <h2>Place Of Birth</h2>
               
                <asp:TextBox ID="txtBirthPlc" class="form1" runat="server"   MaxLength="500" Width="50%" Height="30px"  Style="height:30px;width:49%;resize:none; text-transform: uppercase; font-family: calibri;float: left;margin-left: 27%;"></asp:TextBox>
             
            </div>
            <div class="eachform" style="float:right;">
                <h2>Expected Join Date*</h2>
               
               <div id="DivJoiningDate" class="input-append date" style="width: 53%; float: right;">

                
                  
                        <asp:TextBox ID="txtJoinDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" style="height: 30px; width: 80%; float: left;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image1" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style="height: 22px; width: 22px; margin-top: 0%; float: right;" />

                      
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

           

              
           <div class="eachform" style="float:left;width: 49%;margin-left: 0%;">
                <h2>Marital Status</h2>
               
              
                   <div id="divRadioMrtlSts" class="subform"style="margin-left: 25%;" >        
                   <asp:RadioButton  ID ="RadioMarried" style="float:left;" Text="Married" runat="server" Checked="true" GroupName ="RadioMrtlSts" />
                   <asp:RadioButton  ID ="RadioUnmarried" style="float:left;" Text="Unmarried" runat="server"  GroupName ="RadioMrtlSts"/>
                  
             
                  </div>            
             
            </div>
              <div class="eachform" style="float:left;width: 49%;margin-left: 2%;">
                <h2 style="margin-left: 2%;">Religion*</h2>
               
                  <asp:DropDownList ID="ddlReligion" Height="30px" Width="52.5%" class="form1" runat="server" Style="text-align:left;"></asp:DropDownList>
             
            </div>          <div class="eachform" style="float:left;margin-top:1.5%;">
                <h2>Blood Group</h2>
               
                  <asp:DropDownList ID="ddlBldGrp" Height="30px" Width="54%" class="form1" runat="server" Style="height:30px;width:52.7%;text-align:left;float: left;margin-left: 28.5%;"></asp:DropDownList>
             
            </div>
             <div class="eachform" style="float:right;">
                <h2>Date Of Birth</h2>
               
               <div id="divDOB" class="input-append date">

                
                  
                    
                        <asp:TextBox ID="TxtDOB" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="margin-top: 0%;float:left;margin-left:28%;" onkeypress="return DisableEnter(event);"></asp:TextBox>      <%--//emp17--%>

             
                        <input type="image" runat="server" id="Image18" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

                      
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
  
             <div class="eachform" style="float:left;">
                <h2>Nick Name</h2>
               
                <asp:TextBox ID="txtNickName" class="form1" runat="server"   MaxLength="100" Width="50%" Height="30px"  Style="height:30px;width:48.8%;resize:none; text-transform: uppercase; font-family: calibri;margin-left: 31%;float: left;"></asp:TextBox>
             
            </div>

             

                 <div class="eachform" style="float:right;">
                <h2>Hobbies</h2>
               
                <asp:TextBox ID="txtHobbies" class="form1" runat="server" TextMode="MultiLine"   MaxLength="1000" Width="50%" Height="81px"  Style="resize:none;  font-family: calibri;" onblur="textCounter(cphMain_txtHobbies,950)" onkeydown="textCounter(cphMain_txtHobbies,950)" onkeyup="textCounter(cphMain_txtHobbies,950)"></asp:TextBox>
             
            </div>
                 <div class="eachform" style="float:left;">
                       
                       
                        <div style="margin-left:45.3%;">
                        <asp:CheckBox ID="cbxSmoker" Text="" runat="server" onkeypress="return isTag(event);" onClick="IncrmntConfrmCounter();"  class="form2" />
                        <h2 >Smoker</h2>
                         </div>
                      
                        <div style="margin-left:64.3%;" >
                        <asp:CheckBox ID="cbxAlchlc" Text="" runat="server" onkeypress="return isTag(event);" onClick="IncrmntConfrmCounter();"  class="form2" />
                        <h2 >Alcoholic</h2>
                         </div>
                        </div>

                 <div class="eachform" style="float:left;">
                      <%-- emp-0043 start--%>
                        <h2>Payment Type</h2>
                       <div id="div22" class="subform"style="margin-left: 25%;" >        
                   <asp:RadioButton  ID ="RadioBank" style="float:left;" Text="Bank" runat="server" onClick="paymentClick()" Checked="true" GroupName ="Radiopaytype" />
                   <asp:RadioButton  ID ="RadioCash" style="float:left;" Text="Cash" runat="server" onClick="paymentClick()" GroupName ="Radiopaytype"/>
                  <%--end--%>
             
                  </div>    
                </div>

                   
                   <div id="div14" runat="server" style="float:left;width:100%;border: 2px solid rgb(207, 204, 204);margin-left: 0%;margin-top: 3%;">

                <div id="div15" style="margin-top: 1%;padding-left: 1%;font-size: 22px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
           <%-- <img src="/Images/BigIcons/Contract_Master48x48.png" style="vertical-align: middle;" />--%>
            Accommodation Details
        </div >
                    <div class="eachform" style="width: 48%;margin-left: 0%;float: left;">
                                <h2 style="margin-top: 1%;margin-left: 2%;">Accommodation</h2>

                                <asp:DropDownList ID="ddlAccmdtn" Width="268px" class="form1" onchange="LoadCategry()" style="height:30px;width:268px;height:30px;width:258px;float: left;margin-left: 21%;" runat="server" Height="30px"></asp:DropDownList>
                             
                            </div>
                    <div class="eachform" style="float:left;width: 49%;margin-left: 3%;">
                <h2 id="AccSubCat" style="margin-left: 2%;">Accommodation premises</h2>
                          <h2 id="AccSubCat1" style="margin-left: 1%;display:none">Accommodation premises*</h2>
               
                  <asp:DropDownList ID="ddlCategry" Height="30px" Width="51.5%" class="form1" onchange="LoadSubCategry()" runat="server" Style="height:30px;width:51.5%;height:30px;width:51.5%;height:30px;width:51.5%;height:30px;width:52.5%;text-align:left;float: right;margin-right: 0.5%;"></asp:DropDownList>
             
            </div>  

                                <div class="eachform" style="float:left;width: 50%;margin-left: 0%;">
                <h2 id="AccRoom" style="margin-left: 2%;">Room Name</h2>
                  <h2 id="AccRoom1" style="margin-left: 2%;display:none">Room Name*</h2>
                  <asp:DropDownList ID="ddlSubCat" Height="30px" Width="51%" class="form1"   runat="server" Style="height:30px;width:51%;height:30px;width:51%;height:30px;width:51.5%;height:30px;width:51.3%;height:30px;width:50.7%;text-align:left;float: right;margin-right: 5.1%;"></asp:DropDownList>
             
            </div> 
                       <br />

                              
                         <div id="div16" runat="server" style="float:left;width:98.5%;border: 2px solid rgb(207, 204, 204);margin-left: .5%;margin-top: 0%;height: 45px;margin-bottom: 1%;">
                         <div class="eachform" style="float:left;">
                <h2 id="AccDate" style="display: block;margin-left: 1%;">From Date</h2>
                  <h2 id="AccDate1" style="display:none;margin-left:1%">From Date*</h2>
               <div id="DivOccupyDate" class="input-append date">

                
                  
                        <asp:TextBox ID="OccupyDate" class="form1" onchange="return checkAcmdtnDate('cphMain_OccupyDate');" onblur="return checkAcmdtnDate('cphMain_OccupyDate');" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="42.5%" Style="height:30px;width:42.5%;height:30px;width:43%;margin-top: 0%;float:right;margin-right:7.5%;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image20" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onblur="return checkAcmdtnDate('cphMain_OccupyDate');" style="  height:22px; width:22px;margin-top:0%;float: right;margin-right: -53%;" />

                      
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#DivOccupyDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),
                                // endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
             
            </div>

                    <div class="eachform" style="float:right;">
                <h2 id="H7">To Date</h2>
                  <h2 id="H8" style="display:none;margin-left:-1%">To Date*</h2>
               <div id="DivAcmdtnToDate" class="input-append date">

                
                  
                        <asp:TextBox ID="txtAcmdtnToDate" class="form1" onchange="return checkAcmdtnDate('cphMain_txtAcmdtnToDate');" onblur="return checkAcmdtnDate('cphMain_txtAcmdtnToDate');" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="42.5%" Style="height:30px;width:42.5%;height:30px;width:43%;margin-top: 0%;float:right;margin-right:7.5%;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image24" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onblur="return checkAcmdtnDate('cphMain_txtAcmdtnToDate');" style="  height:22px; width:22px;margin-top:0%;float: right;margin-right: -53%;" />

                      
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#DivAcmdtnToDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),
                                // endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
             
            </div>
                                  
                               </div>
                          </div>

                    <%--BANK DETAILS--%>
                  <asp:HiddenField ID="hiddenPaycrdSal" runat="server" />
                                       <%-- emp-0043 start--%>
                     <asp:HiddenField ID="hiddenEmpBankId" runat="server" />
                  <%--  end--%>
                     
                    <div id="divMessDtls" style="float:left;width:100%;border: 2px solid rgb(207, 204, 204);margin-left: 0%;margin-top: 3%;">
                        <div id="div19" style="margin-top: 1%;padding-left: 1%;font-size: 22px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                         Mess Details </div >

                         <div class="eachform" style="float:left;width: 50%;margin-left: 0%;">
            
                   <h2 style="margin-top: .5%;float: left;margin-left: 1%;"> Mess From</h2>
                  <asp:DropDownList ID="DdlMess" Height="30px" Width="51.5%" class="form1" onchange="CheckMess();" runat="server" Style="height:30px;width:51%;height:30px;width:51%;height:30px;width:51%;height:30px;width:51.5%;height:30px;width:51.3%;height:30px;width:50.7%;text-align:left;float: right;margin-right: 5.1%;" ></asp:DropDownList>
             
            </div>
                         <div id="div20" runat="server" style="float:left;width:98.5%;border: 2px solid rgb(207, 204, 204);margin-left: .5%;margin-top: 0%;height: 45px;margin-bottom: 1%;">
                         <div class="eachform" style="float:left;width: 49%;margin-left: 3%;">

                <h2 id="lblDtFrmMess" style="margin-left: -5%;">From Date</h2>
                <h2 id="lblDtFrmMess1" style="margin-left: -5%; display:none">From Date*</h2>
               <div id="DivMessFromDate" class="input-append date">

                
                  
                        <asp:TextBox ID="txtMessFromDate" class="form1" onblur="return checkMessDate('cphMain_txtMessFromDate');" onchange="return checkMessDate('cphMain_txtMessFromDate');" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="42.5%" Style="height:30px;width:42.5%;height:30px;width:43%;margin-top: 0%;float:right;margin-right:14.5%;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image22" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onblur="return checkMessDate('cphMain_txtMessFromDate');" style="  height:22px; width:22px;margin-top:0%;float: right;margin-right: -53%;" />

                      
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#DivMessFromDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),
                                // endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
             
            </div>
                         <div class="eachform" style="float:right;">
                <h2 id="lblDtToMess1">To Date</h2>
                
               <div id="DivMessToDate" class="input-append date">

                
                  
                        <asp:TextBox ID="txtMessToDate" class="form1" onblur="return checkMessDate('cphMain_txtMessToDate');"  onchange="return checkMessDate('cphMain_txtMessToDate');" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="42.5%" Style="height:30px;width:42.5%;height:30px;width:43%;margin-top: 0%;float:right;margin-right:7.5%;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image23" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onblur="return checkMessDate('cphMain_txtMessToDate');" style="  height:22px; width:22px;margin-top:0%;float: right;margin-right: -53%;" />

                      
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#DivMessToDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),
                                // endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
             
            </div>
                             </div>
                          </div>

    <div id="divBnkDtls" style="float:left;width:100%;border: 2px solid rgb(207, 204, 204);margin-left: 0%;margin-top: 3%;">


                      <div id="div17" style="margin-top: 1%;padding-left: 1%;font-size: 22px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                         Bank Details </div >

                      <div id="divBnk" class="eachform" style="width: 48%;margin-left: 0%;float: left;">
                          <h2 id="lblBank" style="margin-top: 1%;margin-left: 2%;">Bank </h2>
                       
                          <div id="divddlbnk">
                           <asp:DropDownList ID="ddlBank" Width="240px" class="form1" style="height:30px;width:240px;float: right;margin-right:1%" runat="server" Height="30px" onchange="ShowHideDiv('cphMain_ddlBank');" onkeypress="return DisableEnter(event);"></asp:DropDownList>
                            </div> 
                            </div>

                      <div class="eachform" style="float:left;width: 49%;margin-left: 3%;">
                <h2 id="lblBranch" style="margin-left: 2%;">Branch </h2>
                       
               
               <asp:TextBox ID="txtBranch" class="form1" runat="server" Width="50%" Height="30px"  Style="height:30px;width:50%;resize:none; text-transform: uppercase; font-family: calibri;width:47.5%;float: left;margin-left: 33.5%;" onchange="ShowHideDiv('cphMain_ddlBank')" onkeypress="return DisableEnter(event);" onblur="return isTag(event)" onkeydown="textCounter(cphMain_txtBranch,45)"></asp:TextBox>
             
                    </div>

                      <div class="eachform" style="width: 48%;margin-left: 0%;float: left;">
                             <h2 id="lblAcntTyp" style="margin-top: 1%;margin-left: 2%;">Account Type </h2>

                               <asp:DropDownList ID="ddlAccntTyp" Width="268px" class="form1" style="height:30px;width:268px;height:30px;width:258px;float: right;margin-right:1%" onchange="loadsalpaycrd();" runat="server" Height="30px" onkeypress="return DisableEnter(event);">
                                     <asp:ListItem Text="Salary Account" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="Pay Card" Value="2"></asp:ListItem>
                                  </asp:DropDownList>
                            </div>
                      <div id="divSalary">
                       <div class="eachform" style="float:left;width: 49%;margin-left: 3%;">
                <h2 id="lblIban" style="margin-left: 2%;">IBAN </h2>
              
                            <%--evm-0023-20-2--%>
                 <asp:TextBox ID="txtIban" class="form1" runat="server" Width="50%" Height="30px"  Style="height:30px;width:50%;resize:none; text-transform: uppercase; font-family: calibri;width:47.5%;float: left;margin-left: 36.5%;" onchange="ShowHideDiv('cphMain_ddlBank')" onkeypress="return AllowAlphaNumeric(event);" onblur="return BlurAllowAlphaNumeric(event);" onkeydown="return AllowAlphaNumeric(event)"></asp:TextBox>

                <%--<asp:TextBox ID="txtIban" class="form1" runat="server" Width="50%" Height="30px"  Style="height:30px;width:50%;resize:none; text-transform: uppercase; font-family: calibri;width:47.5%;float: left;margin-left: 36.5%;" onchange="ShowHideDiv('cphMain_ddlBank')" onkeypress="return isTag(event,cphMain_ddlBank);" onblur="AllowAlphaNumeric(event);" onkeydown="textCounter(cphMain_txtIban,34)"></asp:TextBox>--%>
             
                    </div>
                      </div>

                      <div id="divPayCrd">

                  <div class="eachform" style="float:left;width: 49%;margin-left: 3%;">
                <h2 id="lblEmpId" style="margin-left: 2%;">Employee ID </h2>
              
               <asp:TextBox ID="txtEmpId" class="form1" runat="server" Enabled="false" MaxLength="100" Width="50%" Height="30px"  Style="height:30px;width:50%;resize:none; text-transform: uppercase; font-family: calibri;width:47.5%;float: left;margin-left: 25.5%;" onchange="ShowHideDiv('cphMain_ddlBank')" onkeypress="return DisableEnter(event);" ></asp:TextBox>
             
                    </div>

                      <div class="eachform" style="width: 50%;margin-left: 0%;float: left;">
                                <h2 style="margin-top: 1%;margin-left: 1.5%;">Card Number </h2>

                            <asp:TextBox ID="txtCardNo" class="form1" runat="server" Width="50%" Height="30px"  Style="height:30px;width:50%;height:30px;width:50%;resize:none; text-transform: uppercase; font-family: calibri;width:47.2%;float: left;margin-left: 24.5%;" onchange="ShowHideDiv('cphMain_ddlBank')" onkeypress="return DisableEnter(event);" onblur="return isTag(event)" onkeydown="textCounter(cphMain_txtCardNo,25)"></asp:TextBox>
                             
                            </div>
                      </div>


              </div>





                    <div id="divLeav" style="float:left;width:100%;border: 2px solid rgb(207, 204, 204);margin-left: 0%;margin-top: 3%;">

                       <div id="divLeaveHead" style="margin-top: 1%;padding-left: 1%;font-size: 22px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                         Leave Type Details </div>

                        <div id="divLeaveType" runat="server" style="float:left;width:100%;margin-left: 5%;margin-top: 3%;">   </div>

                        </div>





                <div class="eachform" style="margin-top:4%;margin-left:35%;">
                <div class="subform" style="width:448px;">
                    <div class="form-group" >
                    
                        <asp:Button ID="btnUpdatePD" runat="server" class="save" Text="Update" OnClick="btnUpdatePersnlDtls_Click"   OnClientClick="return ValidatePerDtl(); " />
                         <asp:Button ID="btnAddPD" runat="server" class="save" Text="Save" OnClick="btnAddPersnlDtls_Click"  OnClientClick="return ValidatePerDtl();" />
                         <asp:Button ID="btnClearPD" runat="server" style="margin-left: 11px;" OnClientClick="return AlertClearAllOthers();"   class="cancel" Text="Clear"/>
                        <asp:Button ID="btncanclpd" runat="server" style="margin-left: 11px;" OnClientClick="return ConfirmCnclPD();"   class="cancel" Text="Cancel"/>
                  
                   
                   
                    </div>
                </div>

            </div>
          </div>
    

            <%------------------------end personal details --------------------------------------%>




                          <%------------------------Start Contact details --------------------------------------%>
           

            <div id="divTblid2" style="float: left; background-color: #f3f3f3; width: 100%; border: 2px solid; border-color: #06558f; padding: 2%; display: none;">
                <div id="divMessageAreaCD" style="display: none; width: 84%; margin-left: 6%;">
                    <img id="imgMessageAreaCD" src="" />
                    <asp:Label ID="lblMessageAreaCD" runat="server"></asp:Label>
                </div>
                <div id="divReportCaptionCD" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; width: 99%;">
                    <asp:Label ID="lblEntryCD" runat="server">Contact Details</asp:Label>
                </div>
                <br />
                <br />
                <div style="float: left; width: 47%">
                    <div style="width: 99%; float: left; font-size: 18px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; text-decoration: underline;">Permanent Address</div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="eachform" style="float: left; width: 99%">
                        <h2>Address1*</h2>
                        <asp:TextBox ID="txtAdr1" class="form1" runat="server" MaxLength="100" Width="50.7%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                    </div>
                    <div class="eachform" style="float: left; width: 99%">
                        <h2>Address2</h2>
                        <asp:TextBox ID="txtAdr2" class="form1" runat="server" MaxLength="100" Width="50.7%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                    </div>
                    <div class="eachform" style="float: left; width: 99%">
                        <h2>Address3</h2>
                        <asp:TextBox ID="txtAdr3" class="form1" runat="server" MaxLength="100" Width="50.7%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                    </div>
                    <div class="eachform" style="float: left; width: 99%">
                        <h2>Country*</h2>
                        <asp:DropDownList ID="ddlCountryCD" Height="30px" Width="54.3%" class="form1" runat="server" Style="text-align: left;" onChange="return changeCountryCD();"></asp:DropDownList>
                    </div>
                    <div class="eachform" style="float: left; width: 99%">
                        <h2>State</h2>
                        <asp:DropDownList ID="ddlStateCD" Height="30px" Width="54.3%" class="form1" runat="server" Style="text-align: left;" onChange="return changeStateCD();"></asp:DropDownList>
                    </div>
                    <div class="eachform" style="float: left; width: 99%">
                        <h2>City</h2>
                        <asp:DropDownList ID="ddlCityCD" Height="30px" Width="54.3%" class="form1" runat="server" Style="text-align: left;"></asp:DropDownList>
                    </div>
                    <div class="eachform" style="float: left; width: 99%">
                        <h2>Zip/Postal Code</h2>
                        <asp:TextBox ID="txtPostalCode" class="form1" runat="server" MaxLength="25" Width="50.5%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                    </div>
                    <div class="eachform" style="float: left; width: 99%">
                        <h2>Email</h2>          
                        <asp:TextBox ID="txtEmail" class="form1" runat="server" MaxLength="100" Width="50.5%" Height="30px" Style="resize: none; font-family: calibri;" onblur="RemoveTag(this)"></asp:TextBox>
                     <p class="error" id="ErrorMsgEmail" style="display:none">Please enter valid email id</p>
                    </div>


                    <div class="eachform" style="float: left; width: 99%">
                        <h2>Mobile</h2>
                        <asp:TextBox ID="txtMobile" class="form1" runat="server" MaxLength="50" Width="50.5%" Height="30px" Style="resize: none; font-family: calibri;" onkeydown="return isNumber(event)"></asp:TextBox>
                    <p class="error" id="ErrorMsgMob" style="display:none">Please enter valid mobile number</p>
                    </div>

                    <div class="eachform" style="float: left; width: 99%">
                        <h2>Phone</h2>
                        <asp:TextBox ID="txtPhone" class="form1" runat="server" MaxLength="50" Width="50.2%" Height="30px" Style="resize: none; font-family: calibri;" onkeydown="return isNumber(event)"></asp:TextBox>
                    </div>

                    <div class="eachform" style="float: left; width: 99%">
                        <h2>Fax</h2>
                        <asp:TextBox ID="txtFax" class="form1" runat="server" MaxLength="100" Width="50.2%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;" onblur="RemoveTag(this)"></asp:TextBox>
                    </div>
                </div>

                <div style="float: right; width: 48%">
                    <div style="width: 99%; float: right; font-size: 18px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; text-decoration: underline;">Address For Communication</div>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbxSameAddr" Text="" runat="server" class="form2" onChange="return addDetails();" />
                    <h2 style="margin-top: 3px; font-size: 100%;">Same As Permanent Address</h2>
                    <br />
                    <br />
                    <div class="eachform" style="float: right; width: 99%">
                        <h2>Address1*</h2>
                        <asp:TextBox ID="txtCommuAddr1" class="form1" runat="server" MaxLength="100" Width="50.3%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                    </div>
                    <div class="eachform" style="float: right; width: 99%">
                        <h2>Address2</h2>
                        <asp:TextBox ID="txtCommuAddr2" class="form1" runat="server" MaxLength="100" Width="50.2%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                    </div>
                    <div class="eachform" style="float: right; width: 99%">
                        <h2>Address3</h2>
                        <asp:TextBox ID="txtCommuAddr3" class="form1" runat="server" MaxLength="100" Width="50.2%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
                    </div>

                    <div class="eachform" style="float: right; width: 99%">
                        <h2>Country*</h2>
                        <asp:DropDownList ID="ddlCommuCountryCD" Height="30px" Width="53.7%" class="form1" runat="server" Style="text-align: left;" onChange="return changeCountryCommu(null);"></asp:DropDownList>
                    </div>

                    <div class="eachform" style="float: right; width: 99%">
                        <h2>State</h2>
                        <asp:DropDownList ID="ddlCommuStateCD" Height="30px" Width="53.6%" class="form1" runat="server" Style="text-align: left;" onChange="return changeStateCommu(null);"></asp:DropDownList>
                    </div>
                    <div class="eachform" style="float: right; width: 99%">
                        <h2>City</h2>
                        <asp:DropDownList ID="ddlCommuCityCD" Height="30px" Width="53.6%" class="form1" runat="server" Style="text-align: left;"></asp:DropDownList>
                    </div>

                    <div class="eachform" style="float: right; width: 99%">
                        <h2>Zip/Postal Code</h2>
                        <asp:TextBox ID="txtCommuPostalCode" class="form1" runat="server" MaxLength="25" Width="49.8%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;" onblur="RemoveTag(this)"></asp:TextBox>
                    </div>

                    <div class="eachform" style="float: right; width: 99%">
                        <h2>Email</h2>
                        <asp:TextBox ID="txtCmmuEmail" class="form1" runat="server" MaxLength="100" Width="49.8%" Height="30px" Style="resize: none; font-family: calibri;" onblur="RemoveTag(this)"></asp:TextBox>
                        <p class="error" id="ErrorMsgCommuEmail" style="display:none">Please enter valid email id</p>
                    </div>
                    <div class="eachform" style="float: right; width: 99%">
                        <h2>Mobile</h2>
                        <asp:TextBox ID="txtCommuMobile" class="form1" runat="server" MaxLength="50" Width="49.8%" Height="30px" Style="resize: none; font-family: calibri;" onkeydown="return isNumber(event)"></asp:TextBox>
                    <p class="error" id="ErrorMsgCommuMob" style="display:none">Please enter valid mobile number</p>
                    </div>

                    <div class="eachform" style="float: right; width: 99%">
                        <h2>Phone</h2>
                        <asp:TextBox ID="txtCommuPhone" class="form1" runat="server" MaxLength="50" Width="49.8%" Height="30px" Style="resize: none; font-family: calibri;" onkeydown="return isNumber(event)"></asp:TextBox>
                    </div>
                    <div class="eachform" style="float: right; width: 99%">
                        <h2>Fax</h2>
                        <asp:TextBox ID="txtCommuFax" class="form1" runat="server" MaxLength="100" Width="49.8%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;" onblur="RemoveTag(this)"></asp:TextBox>
                    </div>
                </div>


                <div class="eachform" style="font-size: 16px; color: rgb(83, 101, 51); font-family: Calibri; width: 100%">
                    <br />
                    <div class="eachform" style="width: 100%">
                        <br />
                        <div style="width: 100%; float: left; font-size: 18px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; text-decoration: underline; cursor:pointer" onclick="HideShowEmrg();">Emergency Contact+</div>
                        <br />
                        <br />
                    </div>
                    <div id="EmrgInfo" style="display:none;">
                        <div class="eachform" style="float: left; width: 47%;margin-bottom: 0%;">
                            <h2>Name*</h2>
                            <asp:TextBox ID="txtEmrgName" class="form1" runat="server" MaxLength="100" Width="50%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;margin-bottom:0%"></asp:TextBox>
                        </div>
                        <div class="eachform" style="float: right; width: 47%">
                            <h2>Relationship*</h2>
                            <asp:DropDownList ID="ddlEmrgRelat" Height="30px" Width="54%" class="form1" runat="server" AutoPostBack="false" onChange="return getRelate();" Style="text-align: left;"></asp:DropDownList>
                        </div>
                        <div class="eachform" style="float: left; width: 47%">
                            <h2 style="margin-top:3%;">Mobile*</h2>
                            <asp:TextBox ID="txtEmrgMobile" class="form1" runat="server" MaxLength="50" Width="50%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;margin-top:1.5%;" onkeydown="return isNumber(event)"></asp:TextBox>
                            <p class="error" id="ErrorMsgEmrgMob" style="display: none;padding-top: 1%;padding-left: 0%;">Please enter valid mobile number</p>
                        </div>
                        <div class="eachform" style="float: right; width: 47%">
                            <h2>Phone</h2>
                            <asp:TextBox ID="txtEmrgPhone" class="form1" runat="server" MaxLength="50" Width="50%" Height="30px" Style="resize: none; font-family: calibri;" onkeydown="return isNumber(event)"></asp:TextBox>
                        </div>
                        <div class="eachform" style="float: left; width: 47%">
                            <h2>Email</h2>
                            <asp:TextBox ID="txtEmrgEmail" class="form1" runat="server" MaxLength="100" Width="50%" Height="30px" Style="resize: none; font-family: calibri;" onblur="RemoveTag(this)"></asp:TextBox>
                            <p class="error" id="ErrorMsgEmrgEmail" style="display: none;padding-top: 1%;padding-left: 0%;">Please enter valid email id</p>
                        </div>
                        <div class="eachform" style="float: right; width: 47%">
                            <h2>Fax</h2>
                            <asp:TextBox ID="txtEmrgFax" class="form1" runat="server" MaxLength="100" Width="50%" Height="30px" Style="resize: none; text-transform: uppercase; font-family: calibri;" onblur="RemoveTag(this)"></asp:TextBox>
                        </div>
                         <div class="eachform" style="float: left; width: 47%">
                            <h2>Address</h2>
                        <textarea id="txtEmrgAddr" class="form1" runat="server" type="multiline" maxlength="100" tabindex="0" style="resize: none; width:50%; height:53px; font-family: calibri;"></textarea>
                        </div>                                         
                      
                    </div>
                    <div class="eachform" style="margin-top: 4%; margin-left: 20%;">
                        <div class="subform" style="width: 448px;">
                            <div class="form-group">
                                <asp:Button ID="btnUpdateCD" runat="server" class="save" Text="Update" OnClick="btnUpdateCD_Click" OnClientClick="return ValidateCD();" />
                                <asp:Button ID="btnAddCD" runat="server" class="save" Text="Save" OnClick="btnAddCD_Click" OnClientClick="return ValidateCD();" />
                                <asp:Button ID="btnClearCD" runat="server" Style="margin-left: -1%;" OnClientClick="return AlertClearAllCD();"  class="cancel" Text="Clear" />
                               <asp:Button ID="btnCancelCD" runat="server" class="cancel" Text="Cancel" Style="margin-left: 2%;" OnClientClick="return ConfirmMessageCDCancel();"  PostBackUrl="~/Master/gen_Emply_Personal_Informn/gen_Emp_Personal_Info_List.aspx" />
                        
                            </div>
                        </div>
                    </div>
                </div>


            </div>
            <script>
                function AlertCancelAllCD() {
                    if (confirmbox > 0) {
                        if (confirm("Are you sure you want cancel in this page?")) {                         
                            window.location.href = "gen_Emp_Personal_Info_List.aspx";
                            return false;
                        }
                        else {
                            return false;
                        }
                    }
                    else {
                        window.location.href = "gen_Emp_Personal_Info_List.aspx";
                        return false;
                    }
                }
            </script>

             <%------------------------End Contact details --------------------------------------%>
            <%----------------------------marriage info start-----------------------------------------%>

            <div id="divTblid3" style="float: left;  width: 100%;background-color: #f3f3f3;border: 2px solid;border-color: #06558f;padding: 2%;display:none;">
                 <div id="divMessageAreaDpnt" style="display:none; width: 84%; margin-left: 6%;margin-top: -12px;">
                 <img id="imgMessageAreaDpnt" src="" />
                 <asp:Label ID="lblMessageAreaDpnt" runat="server"></asp:Label>
                 </div>            
                <div id="divDepnt" style="width:98%;border: 1px solid;border-color: darkgrey;padding: 1%;margin-top:1%;" >
               <div id="divDepntHead" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <asp:Label ID="lblDepntHead" runat="server">Add Dependent</asp:Label>
               </div>
              <br />
                 <div class="eachform" style="float:left;">
                <h2>Name*</h2>
                
                <asp:TextBox ID="txtDepndtName" class="form1" runat="server"   MaxLength="100" Width="50%" Height="30px"  Style="resize:none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
              
               </div> 
                <div class="eachform" style="float:right;">
                <h2>Relationship*</h2>
                
                  <asp:DropDownList ID="ddlReltnshp" Height="30px" Width="53.5%" class="form1" runat="server" Style="text-align:left;"></asp:DropDownList>
              
                </div>
                <div class="eachform" style="float:left;margin-right:5%;">
                <h2>Passport Number</h2>
                
                <asp:TextBox ID="txtPasprtNum" class="form1" runat="server"   MaxLength="100" Width="50%" Height="30px"  Style="resize:none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
              
               </div> 
                 <div class="eachform" style="float:right;margin-top:-4%;">
                <h2>Passport Expiry Date</h2>
                
               <div id="divPasprtExpDate" class="input-append date" style="float: right; width: 54%;">

                 
                   
                        <asp:TextBox ID="txtPsprtDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height: 30px; width: 81%; float: left;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image3" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style="height:22px; width:22px;margin-top:0%;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divPasprtExpDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div>
                <div class="eachform" style="float:left;">
                <h2>Residency Permit Number</h2>
                
                <asp:TextBox ID="txtRPnum" class="form1" runat="server"   MaxLength="500" Width="50%" Height="30px"  Style="resize:none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
              
               </div> 
                 <div class="eachform" style="float:right;margin-top:0.5%;">
                <h2>Residency Permit Issue Date</h2>
                
               <div id="divRPissDate" class="input-append date" style="float: right; width: 54%;">

                 
                   
                        <asp:TextBox ID="txtRPissDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height: 30px; float: left; width: 81%;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image4" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divRPissDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div>
              <div class="eachform" style="float:left;">
                <h2>Residency Permit Expiry Date</h2>
                
               <div id="divRPexpDate" class="input-append date" style="float: right; width: 54%;">

                 
                   
                        <asp:TextBox ID="txtRPexpDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height: 30px; float: left; width: 81%;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image5" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divRPexpDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
               

            </div>
              <div class="eachform" style="margin-top:2%;margin-left:19%;">
                <div class="subform" style="width:448px;">
                    <div class="form-group" >
                     
                        <asp:Button ID="btnUpdateDepnt"  runat="server" style="display:none;" class="save" Text="Update" OnClick="btnUpdateDepnt_Click" OnClientClick="return ValidateDepnt();"  />
                         <asp:Button ID="btnAddDepnt" runat="server" class="save" Text="Save" OnClick="btnAddDepnt_Click"    OnClientClick="return ValidateDepnt();" />
                         <asp:Button ID="btnClearDepnt" runat="server" style="margin-left: 11px;" OnClientClick="return AlertDepClear();"   class="cancel" Text="Clear"/>
                           <asp:Button ID="btncancldepndt" runat="server" style="margin-left: 23px;" OnClientClick="return ConfirmCnclDepndnt();"   class="cancel" Text="Cancel"/>
                    
                          </div>
                </div>

            </div>
   <div class="eachform" style="float:left;width:100%">
       <h2 style="font-size: 24px;font-weight: bold;color: rgb(83, 101, 51);font-family: Calibri;margin-top: 1%;">List Dependents</h2>
         </div>
 
             <div id="divReport" class="table-responsive" style="width:100%;font-family:Calibri" runat="server">
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

            <%-----------------------------------------end marriage info-----------------------------------------%>
                    <script>
                        var $a=jQuery.noConflict();
                        $a(document).ready(function () {
                            document.getElementById("cphMain_RadioButtonDocList_0").checked=true;
                            $a('#cphMain_RadioButtonDocList_1').change(function () {
                                document.getElementById("cphMain_btnUpdateImigrationDtls").style.display = "none";
                                document.getElementById("cphMain_btnAddImigrationDtls").style.display = "block";
                                document.getElementById("cphMain_BtnclrImig").style.display = "block";

                                // The one that fires the event is always the
                                // checked one; you don't need to test for this
                                // VisaRadioChange();

                                var id=$a(this).val();
                                if(id==2)
                                {       //  alert("ff");  
                                    document.getElementById("Divvisatype").style.display = "";
                                    //  document.getElementById("<style.display = "block";
                                    //  alert($a(this).val());
                                    document.getElementById("<%=hiddenvisa.ClientID%>").value =id;
                                    document.getElementById("Hc_Number1").style.display = "none";
                                    document.getElementById("IssDate1").style.display = "none";
                                    //id ;
                                    // document.getElementById("Divvisatype").style.display = "";
                                    document.getElementById("DivIssuBy").style.display = "";
                                 //   document.getElementById("DivElgbleDate").style.display = "";
                                    document.getElementById("DivExpDate").style.display = "";
                                    document.getElementById("DivCommnts").style.display = "";
                                    document.getElementById("DivUpload").style.display = "";
                                   // document.getElementById("Hc_Number").style.display = "";
                                    document.getElementById("IssDate").style.display = "";
                                    // var el=$(divIssued);
                                    //  el.css('margin-right','10%')
                                }
                                //23/02 EVM-0024
                              //  document.getElementById("<%=ddlIssuedby.ClientID%>").value="";
                                document.getElementById("<%=Textnumber.ClientID%>").value="";
                                document.getElementById("<%=TextIssuueddate.ClientID%>").value="";
                                document.getElementById("<%=TxtdivExpiryDate.ClientID%>").value="";
                                document.getElementById("<%=TxtComments.ClientID%>").value="";
                       
                            });
                            $a('#cphMain_RadioButtonDocList_0').change(function () {
                                document.getElementById("cphMain_btnUpdateImigrationDtls").style.display = "none";
                                document.getElementById("cphMain_btnAddImigrationDtls").style.display = "block";
                                document.getElementById("cphMain_BtnclrImig").style.display = "block";
                                var id=$a(this).val();
                                document.getElementById("<%=hiddenvisa.ClientID%>").value =id;
                                document.getElementById("Divvisatype").style.display = "none";
                                document.getElementById("Hc_Number1").style.display = "none";
                                document.getElementById("IssDate1").style.display = "none";

                                document.getElementById("DivIssuBy").style.display = "";

                                document.getElementById("DivExpDate").style.display = "";
                                document.getElementById("DivCommnts").style.display = "";
                                document.getElementById("DivUpload").style.display = "";
                              //  document.getElementById("Hc_Number").style.display = "";
                                document.getElementById("IssDate").style.display = "";

                                document.getElementById("<%=btnUpdateImigrationDtls.ClientID%>").disabled=false;
                                document.getElementById("<%=Txtelgblestats.ClientID%>").disabled=false;
                                document.getElementById("<%=ddlIssuedby.ClientID%>").disabled=false;
                                document.getElementById("<%=TextIssuueddate.ClientID%>").disabled=false;
                                document.getElementById("<%=TxtComments.ClientID%>").disabled=false; 
                                document.getElementById("<%=Ddlvisatype.ClientID%>").disabled=false;
                                document.getElementById("<%=Textnumber.ClientID%>").disabled=false;
                                document.getElementById("<%=TxtEligiblervwdate.ClientID%>").disabled=false;
                                document.getElementById("<%=TxtdivExpiryDate.ClientID%>").disabled=false;
                                //23/02 EVM-0024
                               // document.getElementById("<%=ddlIssuedby.ClientID%>").value="";
                                document.getElementById("<%=Textnumber.ClientID%>").value="";
                                document.getElementById("<%=TextIssuueddate.ClientID%>").value="";
                                document.getElementById("<%=TxtdivExpiryDate.ClientID%>").value="";
                                document.getElementById("<%=TxtComments.ClientID%>").value="";
                            });
                            $a('#cphMain_RadioButtonDocList_2').change(function () {

                                document.getElementById("cphMain_btnUpdateImigrationDtls").style.display = "none";
                                document.getElementById("cphMain_btnAddImigrationDtls").style.display = "block";
                                document.getElementById("cphMain_BtnclrImig").style.display = "block";

                                // The one that fires the event is always the
                                // checked one; you don't need to test for this
                                // VisaRadioChange();
                                // alert("ff");
                                var id=$a(this).val();
                                document.getElementById("<%=hiddenvisa.ClientID%>").value =id ;
                            
                                document.getElementById("Divvisatype").style.display = "none";
                                //     document.getElementById("<%=Ddlvisatype.ClientID%>").style.display = "none";
                      
                                document.getElementById("Hc_Number1").style.display = "none";
                                document.getElementById("IssDate1").style.display = "none";

                                // document.getElementById("Divvisatype").style.display = "";
                                document.getElementById("DivIssuBy").style.display = "";
                             //   document.getElementById("DivElgbleDate").style.display = "";
                                document.getElementById("DivExpDate").style.display = "";
                                document.getElementById("DivCommnts").style.display = "";
                                document.getElementById("DivUpload").style.display = "";
                            //    document.getElementById("Hc_Number").style.display = "";
                                document.getElementById("IssDate").style.display = "";
                                //  var el=$(divIssued);
                                // el.css('margin-right','10%')
                                //23/02 EVM-0024
                              //  document.getElementById("<%=ddlIssuedby.ClientID%>").value="";
                                document.getElementById("<%=Textnumber.ClientID%>").value="";
                                document.getElementById("<%=TextIssuueddate.ClientID%>").value="";
                                document.getElementById("<%=TxtdivExpiryDate.ClientID%>").value="";
                                document.getElementById("<%=TxtComments.ClientID%>").value="";
                       
                            });
                            $a('#cphMain_RadioButtonDocList_3').change(function () {
                                document.getElementById("cphMain_btnUpdateImigrationDtls").style.display = "none";
                                document.getElementById("cphMain_btnAddImigrationDtls").style.display = "block";
                                document.getElementById("cphMain_BtnclrImig").style.display = "block";

                                // The one that fires the event is always the
                                // checked one; you don't need to test for this
                                // VisaRadioChange();
                                // alert("ff");
                                var id=$a(this).val();
                                document.getElementById("<%=hiddenvisa.ClientID%>").value =id ;
                            
                                document.getElementById("Divvisatype").style.display = "none";
                                document.getElementById("DivIssuBy").style.display = "none";
                             //   document.getElementById("DivElgbleDate").style.display = "none";
                                document.getElementById("DivExpDate").style.display = "none";
                                document.getElementById("DivCommnts").style.display = "none";
                                document.getElementById("DivUpload").style.display = "none";
                           //     document.getElementById("Hc_Number").style.display = "none";
                                document.getElementById("IssDate").style.display = "none";
                                document.getElementById("Hc_Number1").style.display = "";
                                document.getElementById("IssDate1").style.display = "";
                                //  var el=$(divIssued);
                                //el.css('margin-right','8%')
                                // document.getElementById("divIssued").style.marginRight=8;
                                //     document.getElementById("<%=Ddlvisatype.ClientID%>").style.display = "none";
                      
                                // 22/02 evm-0024
                                document.getElementById("<%=btnUpdateImigrationDtls.ClientID%>").disabled=false;
                                document.getElementById("<%=Txtelgblestats.ClientID%>").disabled=false;
                                document.getElementById("<%=ddlIssuedby.ClientID%>").disabled=false;
                                document.getElementById("<%=TextIssuueddate.ClientID%>").disabled=false;
                                document.getElementById("<%=TxtComments.ClientID%>").disabled=false; 
                                document.getElementById("<%=Ddlvisatype.ClientID%>").disabled=false;
                                document.getElementById("<%=Textnumber.ClientID%>").disabled=false;
                                document.getElementById("<%=TxtEligiblervwdate.ClientID%>").disabled=false;
                                document.getElementById("<%=TxtdivExpiryDate.ClientID%>").disabled=false;
                   
                                //23/02 EVM-0024
                           //     document.getElementById("<%=ddlIssuedby.ClientID%>").value="";
                                document.getElementById("<%=Textnumber.ClientID%>").value="";
                                document.getElementById("<%=TextIssuueddate.ClientID%>").value="";
                                document.getElementById("<%=TxtdivExpiryDate.ClientID%>").value="";
                                document.getElementById("<%=TxtComments.ClientID%>").value="";

                                document.getElementById("<%=TxtCntrnum.ClientID%>").value="";
                                document.getElementById("<%=HcExpDate.ClientID%>").value="";
                               
                            });
                            
                        });



            </script>

            <%----------------------------Immigrationinfo start-----------------------------------------%>

          <div id="divTblid4"  style="float: left;background-color: #f3f3f3;  width: 100%;border: 2px solid;border-color: #06558f;padding: 2%;display:none;">

 <div id="divImgratn" style="width:98%;border: 1px solid;border-color: darkgrey;padding: 1%;margin-bottom:1%; font-family: Calibri" >
               <div id="div3" style="font-size: 24px; font-weight:bold; color: rgb(83, 101, 51); font-family: Calibri">
                 <div id="divMessageAreaforimig" style="display:none;width:84%;margin-left:8%;">
                 <img id="imgMessageAreaforimig" style="float:left"  src="" />
                 <asp:Label ID="lblMessageAreaforimig" runat="server"></asp:Label>
          </div>
                   
                   
                    <asp:Label ID="LabelImmighead" runat="server">Add Immigration</asp:Label>
               </div>
              <br />
                 <div style="width:100%;">
                <div class="eachform" style="float:left; width:50%; height: 34px;margin-left: 0%;margin-bottom: 0%;">
                <h2>Document*</h2>
                
               
                       <asp:radiobuttonlist id="RadioButtonDocList" runat="server" onkeypress="return isTag(event);" style="float: left; margin-left: 21%;width:55% ;" RepeatDirection="Horizontal"  onchange="return VisaRadioChange();"> <%--//3emp17--%>
                  <asp:listitem value="1">Passport</asp:listitem>
                <asp:listitem value="2" >Visa</asp:listitem>
                 <asp:listitem value="3">RP</asp:listitem>
         <asp:listitem value="4">Health Card</asp:listitem>
                </asp:radiobuttonlist>
              
            </div>
         </div>
         <div id="Divvisatype" class="eachform" style="float:right;width:50%;display:none">
                <h2>Visa Type*</h2>
                
                 <asp:DropDownList ID="Ddlvisatype"  Height="30px" Width="50%" class="form1" runat="server" Style="height:30px;text-align:left;margin-right:10%;"></asp:DropDownList> <%--3emp17--%>
               </div> 
                <div id= "masterdiv"  style="float:right;width:100%;" > 
                        <div id="Hc_Number" class="eachform" style="float:left;width:50%;margin-bottom: 0%;display:none"> <%--//3emp17--%>
                <h2 >Eligible Status</h2>
                    
                <asp:TextBox ID="Txtelgblestats" class="form1" runat="server" MaxLength="50" Width="46%" Height="30px" Style="float:right;resize:none; text-transform: uppercase; font-family: calibri;float: left;margin-left: 18.7%;"></asp:TextBox>
            
                </div>

                      <div id="Hc_Number1" class="eachform" style="float:left;width:50%;margin-bottom: 0%;display:none"> <%--//3emp17--%>
            
                       <h2  >Center Number</h2>
                <asp:TextBox ID="TxtCntrnum" class="form1" runat="server" MaxLength="50" Width="46%" Height="30px" Style="height:30px;width:49%;float:right;resize:none; text-transform: uppercase; font-family: calibri;float: left;margin-left: 17.7%;"></asp:TextBox>
            
                </div>
				<div class="eachform" style="float:left;width:50%">
                <h2>Number*</h2>
                   
               <asp:TextBox ID="Textnumber" class="form1" runat="server" onkeypress="return isTag(event);"  MaxLength="45" Width="49.7%" Height="30px"  Style="float:right;resize:none; text-transform: uppercase; font-family: calibri;margin-right:8%;"  ></asp:TextBox>   <%--3emp17--%>
       
				<p class="error" id="ErrorMsgMob1" style="display:none">Please enter Valid data</p>
				</div>  
             
				  
				<div id="DivIssuBy" class="eachform" style="float:left;width:50%">
                <h2 >Issued By</h2>
                
                  <asp:DropDownList ID="ddlIssuedby" Height="30px" class="form1" runat="server" Style="height:30px;width:50%;text-align:left;margin-right: 10%;"></asp:DropDownList>
             
               </div> 
			   
			      <div id="DivElgbleDate" class="eachform" style="float:right;width:50% ;margin-top:2%; display:none;">
                <h2>Eligible Review Date</h2>
                
               <div id="divEligiblervwdate" class="input-append date" style="float:left;margin-left:13%;width:57%">

                 
                   
                        <asp:TextBox ID="TxtEligiblervwdate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return DisableEnter(event);" onkeypress="return isTag(event);" onblur="IncrmntConfrmCounterImig();" Height="30px" Width="75%" Style="margin-top: 0%;float:left;margin-left:2.7%;"></asp:TextBox>

                        <input type="image" runat="server" id="Image7" onblur="IncrmntConfrmCounterImig();" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:-0.1%;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divEligiblervwdate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div>
				</div> 
               
                <div id="IssDate" class="eachform" style="float:left;width:50%;">
                <h2 >Issued Date </h2>
                
                <div id="divIssued" class="input-append date" style="float:right;margin-right:11%;width: 50%;">

                 
                   
                        <asp:TextBox ID="TextIssuueddate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" onblur="IncrmntConfrmCounterImig();" Width="103%" Style="height:30px;width:103%;height:30px;width:85%;float:left;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image8" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onblur="IncrmntConfrmCounterImig();" style=" height:22px; width:22px;margin-top:0;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divIssued').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(),
                                // startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div> 

           <div id="IssDate1" class="eachform" style="float:left;width:50%;display:none">
               
                    <h2 >Expiry Date* </h2>
                <div id="div18" class="input-append date" style="float:right;width:61%;">

                 
                   
                        <asp:TextBox ID="HcExpDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" onblur="IncrmntConfrmCounterImig();" Width="70%" Style="float:left;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image21" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onblur="IncrmntConfrmCounterImig();" style=" height:22px; width:22px;margin-top:0;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#div18').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //-0024 endDate: new Date(),
                                // startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div> 
                 <div id="DivExpDate" class="eachform" style="float:left;width:50%">
                <h2>Expiry Date*</h2>
                
               <div id="divExpiryDate" class="input-append date" style="float:right;width: 60%;">

                 
                   
                        <asp:TextBox ID="TxtdivExpiryDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" onblur="IncrmntConfrmCounterImig();" runat="server" Height="30px"  Style="float:left;width: 66%;"></asp:TextBox>

                        <input type="image" runat="server" id="Image6" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onblur="IncrmntConfrmCounterImig();" style=" height:22px; width:22px;margin-top:-0.1%;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divExpiryDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                // startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
            </div>

              <div id="DivCommnts" class="eachform" style="float:left;width:50%;margin-top:1%">
                <h2>Comments</h2>
                
               <div id="div7" class="input-append date" style="float:right;height: 16%;margin-right: 8%;">

                 
                   
                                    <asp:TextBox id="TxtComments" TextMode="multiline" class="form1" Columns="50" Rows="5" MaxLength="450" runat="server" onkeypress="return  isTagEnter(event);" onblur="textCounter(cphMain_TxtComments,450)" onkeydown="textCounter(cphMain_TxtComments,450)" Style="margin-top: 0%;float:right;font-family:Calibri; width:250px;height:100%;resize:none"   />  <%--//3emp17--%>
                        <p style="visibility: hidden">Please enter</p>
                       </div>
               

            </div>
                     <div id="DivUpload" class="eachform" style="width: 50%;float:left;">
              
                    <h2 style="margin-top: 1%;">Upload Photo</h2>

                         <div></div>
               <div id="fileupload" style="float:right;width: 62%;margin-right: 9%;">
                <label id="lblfileupload" for="cphMain_FileUploadRecharge" class="custom-file-upload" tabindex="0" style="float: left;">
                    <img src="/Images/Icons/cloud_upload.jpg" />Attachment</label>
                <%--<input id="file" name = "file" type="file" onchange="ClearDivDisplayImage()" accept="image/png, image/gif, image/jpeg" />--%>

                <asp:FileUpload ID="FileUploadRecharge" class="fileUpload" runat="server" Style="height: 30px; display:none;" onchange="ClearDivDisplayImage1()" Accept="All" />


                <div id="divImageDisplay1" runat="server" style="float: right; width: 7%; height: 20px; margin-top: 1%;">
                    <div class="imgWrap">
                        <img id="ClearImage" src="/Images/Icons/clear-image-green.png" alt="Clear" onclick="ClearImage1()" onmouseover="ImagePosition('ClearImage')"; style="cursor: pointer; float: right;" />
                        <p id="RemovePhoto" class="imgDescription" style="color: white;top: 578.233px;position: absolute;left: 79.1%;">Remove Selected File</p>
                    </div>
                    
                  
                </div>
                <div>   
                <asp:Label ID="Label5" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
                    </div>
             <div id="divImageDisplay12" style="float: left;margin-left: 18%;" runat ="server">
                    </div>
            </div>

                </div>
                                   
               <div class="eachform" style="margin-top:7%;float:left; width:50%;height: 33px;" >
                <div class="subform" style="width:448px; float:left">
                    <div class="form-group" >
                     
                        <asp:Button ID="btnUpdateImigrationDtls" runat="server" class="save" Text="Update"  style="display:none"  OnClientClick="return Validateimmigration(); " OnClick="btnUpdateImigrationDtls_Click" />
                         <asp:Button ID="btnAddImigrationDtls" runat="server" class="save" Text="Save"    OnClientClick="return Validateimmigration();" OnClick="btnAddImigrationDtls_Click"/>
                           <asp:Button ID="BtnclrImig" runat="server" style="margin-left: 11px;" OnClientClick="return AlertClearAllImmig();" class="cancel" Text="Clear"/>
              <asp:HiddenField ID="hiddenvisa" runat="server" />        
                                <asp:Button ID="btncancelImigrtn" runat="server" style="margin-left: 11px;" OnClientClick="return ConfirmCnclimig();" OnClick="btnClear_ClickImig" class="cancel" Text="Cancel"/>
                         </div>
                </div>

            </div>
     <div class="eachform" style="float:left;width:100%">
       <h2 style="font-size: 24px;font-weight: bold;color: rgb(83, 101, 51);font-family: Calibri;margin-top: 1%;">List Immigration</h2>
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
                 <%-----------------------------------------end Immigration info-----------------------------------------%>
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
                  padding: 2% 1%;
                  background-color: #91a172;
                  color: white;
              }

              #divErrorRsnAWMS1 {
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
                 #divError {
     border-radius: 4px;
    background: #fff;
    color: #53844E;
    font-size: 12.5px;
    font-family: Calibri;
    font-weight: bold;
    border: 2px solid #53844E;
    margin-top: -3.5%;
    margin-bottom: 2%;
    margin-left: 0%;
}
          </style>

                  <div id="divmodalCancelViewForimig" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelViewForimig();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Immigration</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS1" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="Label2" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="TxtRsnimig" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="textCounter(cphMain_TxtRsnimig,250)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_TxtRsnimig,250)" onkeyup="textCounter(cphMain_TxtRsnimig,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="BtnRsnSaveImig" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSaveImig_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="BtnRsnCancelImig" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCancelViewForImig();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div> 
              <%----------------------------JOB info start-----------------------------------------%>
 
     <div id="divTblid5"  style="float: left;background-color: #f3f3f3;  width: 100%;border: 2px solid;border-color: #06558f;padding: 2%;display:none;">
                            <div id="divMessageAreaforjob" style="display: none;width:84%;margin-left:6%;">
                 <img id="imgMessageAreaforjob" src="" />
                 <asp:Label ID="lblMessageAreaforjob" runat="server"></asp:Label>
          </div>
                                       <div style="float:left">
                                    <asp:Label ID="Label6" style="width: 60%; float: left; font-size: 18px;font-weight: bold;color: rgb(83, 101, 51);font-family: Calibri;text-decoration: underline;" runat="server" Text="Employment Commencement " ></asp:Label>
                                           
                             
<div id="divJoineddate" class="input-append date" style="float:left;width:47%;margin-top:2%">

                 
                  <h2 style="font-size:17px;margin-top:7px;">Date Of Joining*  </h2>
                   
                        <asp:TextBox ID="txtJoineddate" class="form1" placeholder="DD-MM-YYYY" onblur="SetTextforperiod()"  onchange="SetTextforperiod()" MaxLength="20" runat="server" Height="30px" Width="42.9%" Style="float:left;margin-left:17%;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image14" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:-0.1%;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divJoineddate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(),
                            });
                            if(document.getElementById("cphMain_txtJoineddate").disabled==true){
                                $noC('#divJoineddate').datetimepicker('disable');
                            }
                        </script>

    


                        <p style="visibility: hidden">Please enter</p>
                       </div>



 <div id="divRenewImg" runat="server">
                                           <input type="image" title="Renew" runat="server" id="ImgRenew" class="add-on" src="../../../Images/Icons/Renewal_Big1.png" style="width: 3%; float: right; cursor: pointer; margin-top: 2%;" onclick="return OpenViewRenwl();" />   <%-- emp25--%>
                                                      </div> 
                                      <div id="divProbationdate" class="input-append date" style="float:left;margin-left:2%;width:466px;margin-top:2%">

                 
                  <h2 style="font-size:17px;margin-left: 4.2%;margin-top:7px"> Probation End Date   </h2>

                                           <div style="float: left; width: 27%;margin-left: 12.6%;">

                                <asp:DropDownList ID="ddlPlusWeek" class="form1" Style="width: 97%; float: none; margin-left: 2%;height: 31px;" runat="server" onchange="return PlusWeek();"></asp:DropDownList>
                            </div>
                   
                        <asp:TextBox ID="txtProbationdate" onblur="SetTextforperiod()"  onchange="SetTextforperiod()" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  Style="height:30px;width:16.5%;float:left;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image"  runat="server" id="Image9" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;float: right;" onblur="SetTextforperiod()"  />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divProbationdate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                               
                            });
                            
                            function PlusWeek() {




                                var DropdownListWeek = document.getElementById("<%=ddlPlusWeek.ClientID%>");
                                var SelectedValueWeek = DropdownListWeek.value;
                                var dateCurrentDate = document.getElementById("<%=txtJoineddate.ClientID%>").value;
                                if(dateCurrentDate!="")
                                {
                                    var arrDateCurrentDate = dateCurrentDate.split("-");
                                    // var CurrentDate = new Date(arrDateCurrentDate[2], arrDateCurrentDate[1] - 1, arrDateCurrentDate[0]);
                                    var dateDateCntrlr = new Date(arrDateCurrentDate[2], arrDateCurrentDate[1] - 1, arrDateCurrentDate[0]);
                                    //= new Date();
                                    if (SelectedValueWeek != '--Select Week--') {
                                        var week = parseInt(SelectedValueWeek);

                                        dateDateCntrlr.setDate(dateDateCntrlr.getDate() + week * 30);
                                    }
                                    var dd = dateDateCntrlr.getDate();
                                    var mm = dateDateCntrlr.getMonth() + 1; //January is 0!

                                    var yyyy = dateDateCntrlr.getFullYear();
                                    if (dd < 10) {
                                        dd = '0' + dd
                                    }
                                    if (mm < 10) {
                                        mm = '0' + mm
                                    }
                                    var ddmmyyyyDate = dd + '-' + mm + '-' + yyyy;
                                   // alert(ddmmyyyyDate);

                                    document.getElementById("<%=txtProbationdate.ClientID%>").value = ddmmyyyyDate;
                                }
                                else
                                {
                                    document.getElementById("<%=txtProbationdate.ClientID%>").value = "";
                                }
                                SetTextforperiod();

                                return false;
                            }

                        </script>
   <script type="text/javascript">
       function GetDays(){
           var dropdt = new Date(document.getElementById("txtProbationdate").value);
           var pickdt = new Date(document.getElementById("txtJoineddate").value);
           return parseInt((dropdt - pickdt) / (24 * 3600 * 1000));
       }

       function cal(){
          

           if(document.getElementById("txtProbationdate")){
               document.getElementById("TxtPeriod").value=GetDays();
           }  
       }

    </script>
<script>
    function SetTextforperiod()
    { //alert("isn");
        IncrmntConfrmCounterJob();
   
        var $noC = jQuery.noConflict();
        var joindate = document.getElementById("<%=txtJoineddate.ClientID%>").value;
        var enddate = document.getElementById("<%=txtProbationdate.ClientID%>").value;

        var arrDatePickerDate1 = joindate.split("-");
        //var datetemp= new Date(joindate);      
        var datejoinedd = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
        //alert(datejoinedd.getMonth());

        var arrDatePickerDate1 = enddate.split("-");
        var dateendd = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
        //dateendd.setDate(dateendd.getDate() - datejoinedd.getDate());
        //alert(dateendd);
        //  alert(datejoinedd); 

        if(joindate!=""&&enddate!="")
        { 
            if (datejoinedd > dateendd) {
                document.getElementById("<%=txtProbationdate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtProbationdate.ClientID%>").focus();
                document.getElementById('divMessageAreaforjob').style.display = "";
                document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML =  "Sorry, Date of joining cannot be greater than probation end date !.";
                document.getElementById("<%=TxtPeriod.ClientID%>").value=0;
                return false;
            }
        }

        var months = monthDiff(datejoinedd, dateendd);
        //  if(months==0)
        //{}else{ 
        //    months=months+1;
        
        // }
        if(joindate!="")
        { 
            if(enddate!=""){
                document.getElementById("<%=TxtPeriod.ClientID%>").value=months+1;
            }
    }
    else
    {
        document.getElementById("<%=TxtPeriod.ClientID%>").value=0;
        }
        //   PlusWeek();

    }
    
    function monthDiff(d1, d2) {
        var months;
        //months = (d2.getFullYear() - d1.getFullYear());
        //alert(months);
        //months -= d1.getMonth() + 1;
        //  months += d2.getMonth();
        ////  alert(months);
        //  return months <= 0 ? 0 : months;
        //  var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24)); 
        var diffDays = parseInt((d2 - d1) / (1000 * 60 * 60 * 24)); 
        //  alert(diffDays);
        return diffDays;
        //var d1Y = d1.getFullYear();
        //var d2Y = d2.getFullYear();
        //var d1M = d1.getMonth();
        //var d2M = d2.getMonth();
        //months=(d2M+12*d2Y)-(d1M+12*d1Y);
        // alert(months);
        //return (d2M+12*d2Y)-(d1M+12*d1Y);
    }
  
</script>


                        <p style="visibility: hidden">Please enter</p>
                       </div>
    


                                     <div class="eachform" style="float:left;width:47%;">
                <h2  style="font-size:17px;margin-top:7px">Probation Period </h2>
                   
                <asp:TextBox ID="TxtPeriod" class="form1" runat="server"   MaxLength="500" Width="50%" Height="30px" Text="0"  Style="float:right;resize:none; text-transform: uppercase; font-family: calibri;float: right;margin-right:5.5%;"></asp:TextBox>
            
                </div>
                                      <div id="divpermanencyDate" class="input-append date" style="float:left;margin-left:4%;width:490px;margin-top:1%;">

                    
                    <h2 style="font-size:17px;margin-top:7px">Date Of Permanency </h2>

                                          <asp:TextBox ID="txtpermanencyDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height:30px;width:43%;height:30px;width: 41%;margin-top: 0%;float: left;margin-left: 52px;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image10" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style="float:right;height:22px;width:22px;margin-top:0%;margin-right:43px;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divpermanencyDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                               
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
                                    </div>
               <div style="float: left;width:100%" >
                                       <asp:Label ID="Label7" runat="server" Style="float:left;width:86% ;font-size: 18px;font-weight: bold;color: rgb(83, 101, 51);font-family: Calibri;text-decoration: underline;" Text="Job Details"></asp:Label>
                                           <div class="eachform" style="float:left; display:none">
                <h2>Designation*</h2>
                
                  <asp:DropDownList ID="ddlDesignation" Height="30px" Width="54%" class="form1"  runat="server" Style="text-align:left;float: right;margin-right: 5%;display:none"></asp:DropDownList>
              
            </div>
                                       <div class="eachform" style="float:left">
                <h2 style="float:left">Sponsor</h2>
                
                  <asp:DropDownList ID="ddlSponsor"  class="form1" runat="server" Style="height:30px;width:53%;margin-right:7%;text-align:left;float:right"></asp:DropDownList>
              
            </div>
                                       <div class="eachform" style="float:left;margin-left: 3%; display:none;">
                <h2 style="float:left" >Employee Type*</h2>
                
                  <asp:DropDownList ID="ddlEmployeeType" class="form1" runat="server" Style=" height:30px;width:53%;margin-right:7%;text-align:left;float: right;"></asp:DropDownList>
              
            </div>
                   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                       <ContentTemplate>
                                       <div class="eachform" style="float:left;float: left;margin-left: 3%;width: 47%;margin-top: 1%;">
                <h2 style="float:left">Division</h2>
                
                  <asp:DropDownList ID="ddlDivision"  class="form1" runat="server" Style="height:30px;width:53%;margin-right:30px;text-align:left;float:right" OnSelectedIndexChanged="ddlDivsn_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
              
            </div>
                            
                 <div class="eachform" style="float:left; display:none">
                <h2 style="float:left">Department </h2>
                
                  <asp:DropDownList ID="ddlDepartment" class="form1" runat="server" Style=" height:30px;width:53%;margin-right:7%;text-align:left;float: right;"></asp:DropDownList>
              
            </div>
<div class="eachform" style="float:left;float: left;width: 50%;margin-top: 1%;">
                <h2 style="float:left">Project</h2>
                
                  <asp:DropDownList ID="ddlProject"  class="form1" runat="server"  Style=" height:30px;width:51%;margin-right:10.7%;float:right;resize:none; text-transform: uppercase; font-family: calibri;" onchange="return loadprojassign();"></asp:DropDownList>
              
            </div>
                           </ContentTemplate>
            </asp:UpdatePanel>
         <div class="eachform" style="float:left;margin-left: 1%;">
                <h2  style="float:left">Project Location </h2>
              <asp:TextBox ID="Txtprojloc" class="form1" runat="server"   MaxLength="50"   Style="height:30px;width:48.6%;margin-right:8%;float:right;resize:none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
     
            </div>
                                    
              <div class="eachform" style="float:left; display:none">
                <h2 style="float:left">Staff/Labour*</h2>
                
                  <asp:DropDownList ID="ddtype"  class="form1" runat="server"  Style="height:30px;width:53%;margin-right:7%;text-align:left;float: right;"></asp:DropDownList>
              
            </div>
                                      <div class="eachform" style="float:left;width: 47%;margin-top: 1%;">
                <h2 style="float:left">Job Title  </h2>
                
              <asp:TextBox ID="TxtjobTitle" class="form1" runat="server" MaxLength="20"  Style="height:30px;width:50.6%;margin-right:25px;float:right;resize:none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
      
            </div>  
                                      <div class="eachform" style="float:left;margin-left: 4%;">
                <h2 style="float:left">Job Description  </h2>
                
              <asp:TextBox ID="TxtJobDesc" class="form1" runat="server" MaxLength="500" Style="height:30px;width:48.6%;margin-right:8%;margin-top: 0%;float:right;" ></asp:TextBox>
      
            </div>
                    </div>
                <div  style="float:left; width: 100%; ">       
            <div  style="float:left; width: 100%; display:none"> 
                    <asp:Label ID="Label8" runat="server" Text="Other Details" style="float:left; width: 86%;font-size: 18px;font-weight: bold;color: rgb(83, 101, 51);font-family: Calibri;text-decoration: underline;"></asp:Label>
                                              <div class="eachform" style="float:left;">
                <h2>Accommodation  </h2>
                
                  <asp:DropDownList ID="ddlAccomodation" Height="30px" Width="53.5%" class="form1" runat="server" Style="text-align:left;float:left;margin-left: 16.7%;"></asp:DropDownList>
              
            </div>
                                    <div class="eachform" style="float:left;width: 49%;">
                <h2 style="margin-left: 6%;">Location   </h2>
                
              <asp:TextBox ID="TxtLocation" class="form1" MaxLength="20" runat="server" Height="30px" Width="49.3%" Style="margin-top: 0%;float:left;margin-left:28.7%;"></asp:TextBox>
      
            </div>
                </div>
    <div style="float:left;margin-left: 3%;width:40%">
                          <asp:HiddenField ID="HiddenField1" runat="server" />
                   <asp:Button ID="BtnsaveJob" runat="server" class="save"  Text="Save" style="margin: 4%;" OnClientClick="return validateJobsave(0);" OnClick="btnAdd_ClickUsrRegistr"  />
                      <asp:Button ID="BtnupdateJob" runat="server" class="save"  Text="Update " style="margin: 4%;"  OnClientClick="return validateJobsave(1);" OnClick="btnUpdateJobDtls_Click"  />
               
    <asp:Button ID="Btncanceljob" runat="server" class="save" OnClientClick="return ConfirmCncljob();" Text="Cancel"  style="margin: 4%;" />
  <%--<asp:Button ID="Button2" runat="server" class="save" OnClientClick="validate();" Text="Cancel" style="margin: 4%;" />--%>
                               
         <asp:Button ID="Btnclrjob" runat="server" class="save" OnClientClick="return AlertClearAllJob();" Text="Clear" style="margin: 4%;"  />
               </div>
    

                 <%--   //project--%>
                       </div>


          <div id="Div21" class="modalLoadingMail">

                <!-- Modal content -->
                <div>

                    <img src="../../Images/Other Images/LoadingMail.gif" style="width: 12%;" />


                </div>

            </div>



                <div  style="float:left; background-color: rgb(243, 243, 243);width: 94%;border: 2px solid rgb(6, 85, 143);padding: 2%;display: block "> 
                     
                     <asp:Label ID="Label9" runat="server" Style="float:left;width:86%;font-size: 18px;font-weight: bold;color: rgb(83, 101, 51);font-family: Calibri;text-decoration: underline;" Text="Project Assign"></asp:Label>     
                          <div id="div8" style="display: none;width:84%;margin-left:6%;">
                 <img id="img6" src="" />
                 <asp:Label ID="Label4" runat="server"></asp:Label>
          </div>  
                     <div style="float:left;width:48%">
                 
                    <div class="eachform" style="float:left;width:100%">
         
                              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>
               
                                   <h2 style="margin-left:3%">Project*  </h2>
         <asp:DropDownList ID="ddlprojectassign" Height="30px" Width="56%" class="form1" runat="server" AutoPostBack="true" Style="text-align:left;margin-right: 0%;" OnSelectedIndexChanged="ddlprojectassign_SelectedIndexChanged"></asp:DropDownList>
       
            </div></ContentTemplate>
                           </asp:UpdatePanel>
                              
                         <div id="divprojectstartdate" class="input-append date" style="float:left;margin-left:3%;width:99% ;margin-top:2%">

                                        <h2 style="font-size:17px">Project Start Date*</h2>
                                  <input type="image" runat="server" id="Image12" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style="float:right; height:22px; width:22px;margin-top:0%;margin-right:2%" />
                   
                                   <asp:TextBox ID="txtprojectstartdate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="45%" Style="float:right;margin-top: 0%;float:left;margin-left:12.7%;" onkeypress="return DisableEnter(event);"></asp:TextBox>


                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divprojectstartdate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
                                      <div id="divProjectEndDate" class="input-append date" style="float:left;margin-left:2%;width:99%;margin-top:2%">

                 
                  <h2 style="font-size:17px;margin-left: 1%;">Project End Date* </h2>
                   
                        <asp:TextBox ID="txtProjectEndDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="45.5%" Style="margin-top: 0%;float:left;margin-left:14%;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image13" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:23px;margin-top:0%;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divProjectEndDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                              
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
                          
            </div>

                    
                      <div class="eachform" style="float:left;width:60%;margin-top:1%">
                <h2  style="font-size:17px;margin-left: 3%;">Comments</h2>
                
               <div id="div9" style="float:left;height: 16%;margin-left:  14%;">

                 
                   
                                    <asp:TextBox id="TxtProjectComments" class="form1" TextMode="multiline" Columns="95" Rows="5" runat="server" onblur="textCounter(cphMain_TxtProjectComments,95)" onkeydown="textCounter(cphMain_TxtProjectComments,95)" Style="margin-top: 0%;float:left;margin-left:10%;width:243px;height:100%;resize: none;" />
                        <p style="visibility: hidden">Please enter</p>
                       </div>
      
</div>
                      <div style="float:left;margin-left: 3%;margin-top: -9%;">
                          <asp:HiddenField ID="Hiddenjobid" runat="server" />
                   <asp:Button ID="btnprojectsave" runat="server" class="save"  OnClientClick="return validateprojectsave();"   Text="Save" style="width: 50%;margin: 4%;" OnClick="btnAddProjDtls_Click"  />
               <asp:Button ID="btnupdateproj" class="save" runat="server" OnClientClick="return validateprojectsave();" Text="Update" style="width: 50%;margin: 4%;display:none" OnClick="btnUpdateProjDtls_Click"/>
                       
                             <asp:Button ID="btnprojectcancel" runat="server" class="save" OnClientClick="return ConfirmCnclproj();" Text="Cancel" style="width: 50%;margin: 4%;" />
                            <asp:Button ID="btnprojectclr" class="save" runat="server" OnClientClick="return AlertClearAllProj();" Text="Clear" style="width: 50%;margin: 4%;"  />
                         
                             
                                  <asp:HiddenField ID="Hiddenempid" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                            <asp:HiddenField ID="Hiddenprojassgn" runat="server" />
                                                    <asp:HiddenField ID="HiddenField3" runat="server" />

                      </div>
                    <div class="table-responsive">
                           <div id="divreportforProject" class="table-responsive" runat="server" style="overflow:auto;float: left;width:100%;font-family:Calibri">

        </div>
             </div>      

                </div>
       





            </div>

             <script>
                 function ConfirmCnclimig() {
                     if (confirmboxImig > 0) {
                         if (confirm("Are you sure you want to cancel this page?")) {
                             window.location.href = "gen_Emp_Personal_Info_List.aspx";
                             return false;
                         }
                         else {
                             return false;
                         }
                     }
                     else {

                         window.location.href = "gen_Emp_Personal_Info_List.aspx";
                         return false;
                     }
                 } function ConfirmCnclDepndnt() {
                     if (confirmboxDepnt > 0) {
                         if (confirm("Are you sure you want to cancel this page?")) {
                             window.location.href = "gen_Emp_Personal_Info_List.aspx";
                             return false;
                         }
                         else {
                             return false;
                         }
                     }
                     else {

                         window.location.href = "gen_Emp_Personal_Info_List.aspx";
                         return false;
                     }
                 }
                 function EditprojectByid(x) {

                     // var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
                     // var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;

                     var Details = PageMethods.ReadProjectById(x, function (response) {
                         //  alert('inside');
                         document.getElementById("<%=ddlprojectassign.ClientID%>").value = response.ProjectId;
                         // alert('inside1');
                         document.getElementById("<%=txtprojectstartdate.ClientID%>").value = response.ProjAssgnCanReason;

                         //  alert('inside2');
                         document.getElementById("<%=txtProjectEndDate.ClientID%>").value = response.ProjectName;
                         document.getElementById("<%=TxtProjectComments.ClientID%>").value = response.Project_Comments

                         document.getElementById("<%=Hiddenprojassgn.ClientID%>").value = response.Project_Asgn_Id;

                         document.getElementById("<%=btnprojectsave.ClientID%>").style.display = "none";
                         document.getElementById("<%=btnupdateproj.ClientID%>").style.display = "block";
                         document.getElementById("<%=btnupdateproj.ClientID%>").style.display = "block";
                         document.getElementById("<%=btnprojectclr.ClientID%>").style.display ="none";
        
                         // document.getElementById("<%=BtnclrImig.ClientID%>").style.display = "block";

                     });
                     //    alert('fggggf');
                     return false;
                 }
                 function DeleteprojectByid(x, jobid) {
                     var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                     if (confirm("Do you want to delete this project ")) {


                         PageMethods.DeleteProjectById(x, jobid,CorpId, function (response) {
                             document.getElementById("<%=divreportforProject.ClientID%>").innerHTML = response.projectdetaillist;
                           
                            
                          
                             //  if(response.ifRsnShw!="")
                             //  {
                             // document.getElementById("<%=hiddenRsnid.ClientID%>").value = x;
                             // OpenCancelView();
                             //   document.getElementById("<%=divreportforProject.ClientID%>").innerHTML = response.projectdetaillist;
                             // projectSuccessCancelation();
                             //  document.getElementById("<%=hiddenRsnid.ClientID%>").value = response.IfRsnShw;
                             //OpenCancelViewForImig(x);
                             // }
                             //  else
                             projectSuccessCancelation();
                             $p('#ReportTableforprojectweb').DataTable({
                                 "pagingType": "full_numbers",
                                 "bSort": true

                             }); 
                        
                        
                        
                        
                        
                        
                         });

                     }
                 }
                 function EditImigrationByid(x, empid) {

                     document.getElementById('cphMain_Txtelgblestats').focus();

                     document.getElementById("<%=Hiddenempid.ClientID%>").value = empid;
                     var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
                     var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;

                     document.getElementById('divMessageAreaforimig').style.display = "none";
         
                     var Details = PageMethods.ReadImigrationByid(x, CorpId, OrgId, empid, function (response) {
                         document.getElementById("<%=btnUpdateImigrationDtls.ClientID%>").style.display ="block";
                                      document.getElementById("<%=btnAddImigrationDtls.ClientID%>").style.display ="none";
     

                                      var RB1 = document.getElementById("<%=RadioButtonDocList.ClientID%>");

                                      var radio = RB1.getElementsByTagName("input");
                                      radio[response.EMPIMG_DOC_TYPEID-1].checked=true;

                                      //evm-0023 start

                        if(response.EMPIMG_DOC_TYPEID==2 && document.getElementById("<%=HiddenRPStatus.ClientID%>").value=="1")
                         {                
                             $('#cphMain_Txtelgblestats').submit(function() {

                                 $('input').blur();

                             });               
                            
                             document.getElementById("<%=btnUpdateImigrationDtls.ClientID%>").disabled=true; 
                             document.getElementById("<%=Txtelgblestats.ClientID%>").disabled=true;
                             document.getElementById("<%=ddlIssuedby.ClientID%>").disabled=true;
                             document.getElementById("<%=TextIssuueddate.ClientID%>").disabled=true;
                             document.getElementById("<%=TxtComments.ClientID%>").disabled=true; 
                             document.getElementById("<%=Ddlvisatype.ClientID%>").disabled=true;

                             document.getElementById("<%=Textnumber.ClientID%>").disabled=true;
                             document.getElementById("<%=TxtEligiblervwdate.ClientID%>").disabled=true;
                            document.getElementById("<%=TxtdivExpiryDate.ClientID%>").disabled=true;
                            
                         }
                         else
                         {
                             document.getElementById("<%=btnUpdateImigrationDtls.ClientID%>").disabled=false;
                             document.getElementById("<%=Txtelgblestats.ClientID%>").disabled=false;
                             document.getElementById("<%=ddlIssuedby.ClientID%>").disabled=false;
                             document.getElementById("<%=TextIssuueddate.ClientID%>").disabled=false;
                             document.getElementById("<%=TxtComments.ClientID%>").disabled=false; 
                             document.getElementById("<%=Ddlvisatype.ClientID%>").disabled=false;
                             document.getElementById("<%=Textnumber.ClientID%>").disabled=false;
                             document.getElementById("<%=TxtEligiblervwdate.ClientID%>").disabled=false;
                             document.getElementById("<%=TxtdivExpiryDate.ClientID%>").disabled=false;
                         }


                                      if(response.EMPIMG_DOC_TYPEID==1 || response.EMPIMG_DOC_TYPEID==2||response.EMPIMG_DOC_TYPEID==3)
                                      {
                            
                                          if(response.EMPIMG_DOC_TYPEID==1||response.EMPIMG_DOC_TYPEID==3 )
                                          {
                                              //document.getElementById("divTxtNumber").style.display = "none";                               
                                              document.getElementById("Hc_Number1").style.display = "none";                              
                                              document.getElementById("IssDate1").style.display = "none";

                                 
                                              document.getElementById("Divvisatype").style.display ="none";
                                              document.getElementById("DivIssuBy").style.display = "";
                                              document.getElementById("DivExpDate").style.display = "";
                                              document.getElementById("DivCommnts").style.display = "";
                                              document.getElementById("DivUpload").style.display = "";
                                              document.getElementById("IssDate").style.display = "";
                                 
                               
                                 

                                          }




                                          if(response.EMPIMG_DOC_TYPEID==2)
                                          {           
   
                                              document.getElementById("Divvisatype").style.display = "";

                                              document.getElementById("Hc_Number1").style.display = "none";                              
                                              document.getElementById("IssDate1").style.display = "none";
                                      
                                              document.getElementById("DivIssuBy").style.display = "";
                                              document.getElementById("DivExpDate").style.display = "";
                                              document.getElementById("DivCommnts").style.display = "";
                                              document.getElementById("DivUpload").style.display = "";
                                              document.getElementById("IssDate").style.display = "";

                                              document.getElementById("<%=Ddlvisatype.ClientID%>").value=response.visatype;                            
                             }
                             else
                             {
                                 document.getElementById("Divvisatype").style.display = "none";
                             }

                         }


                                      if(response.EMPIMG_DOC_TYPEID==4)
                                      {
             

                                          document.getElementById("Divvisatype").style.display = "none";
                                          document.getElementById("DivIssuBy").style.display = "none";
                   
                                          document.getElementById("DivExpDate").style.display = "none";
                                          document.getElementById("DivCommnts").style.display = "none";
                                          document.getElementById("DivUpload").style.display = "none";
        
                                          document.getElementById("IssDate").style.display = "none";
                                          document.getElementById("Hc_Number1").style.display = "";
                                          document.getElementById("IssDate1").style.display = "";
                                          document.getElementById("<%=Textnumber.ClientID%>").value = response.DOCUMENT;
                             document.getElementById("<%=HcExpDate.ClientID%>").value = response.EXPIRY;
                             document.getElementById("<%=TxtCntrnum.ClientID%>").value = response.Centernum;
                         }
                                      // Textnumber
                             


                                      //evm-0023 end
                                      document.getElementById("<%=Textnumber.ClientID%>").value = response.DOCUMENT;

                                      document.getElementById("<%=TextIssuueddate.ClientID%>").value = response.issudate;
                                      document.getElementById("<%=TxtdivExpiryDate.ClientID%>").value = response.EXPIRY;

                                      document.getElementById("<%=Txtelgblestats.ClientID%>").value = response.EMPIMG_ELIGBLE_STATUS;
                                      if(response.CNTRY_NAME!="")
                                      {
                                          document.getElementById("<%=ddlIssuedby.ClientID%>").value = response.CNTRY_NAME;
                         }
                                      document.getElementById("<%=TxtComments.ClientID%>").value = response.EMPIMG_DOC_COMMENTS;
                                      document.getElementById("<%=divImageDisplay12.ClientID%>").innerHTML = response.EMPIMG_DOC_ATTACHMENT;
                                      document.getElementById("<%=HiddenImmigid.ClientID%>").value = response.Imig_Id;
                      
                                      document.getElementById("<%=TxtEligiblervwdate.ClientID%>").value = response.REVIEWDATE;



                                      document.getElementById("<%=hiddenUserImage.ClientID%>").value=response.attachname;
                        
                       
                                      document.getElementById("<%=btnUpdateImigrationDtls.ClientID%>").style.display = "block";

                                      $(Window).scrollTop(0);   //3emp17  
                                      document.getElementById("<%=btnAddImigrationDtls.ClientID%>").style.display ="none";
                         document.getElementById("<%=BtnclrImig.ClientID%>").style.display = "none";
                        
                                  });

                                  hide_clearbutton();

                                  return false;
                              }
                 function DeleteImigrationByid(x,emp_Id,doctype) {      //3emp17

                 
                    var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
                    var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
                    if (confirm("Do you want To delete this  entry ")) {

                        var userid= document.getElementById("<%=Hiddenempid.ClientID%>");
                         //  alert(userid.value);
                         // alert(emp_Id);
                         PageMethods.DeleteImigrationByid(x, CorpId, OrgId, userid.value, emp_Id, function (response)
                         {
                             document.getElementById("<%=divImigList.ClientID%>").innerHTML = response.strhtml; //2emp17
                             ImigSuccessCancelation();//2emp17
                             $p('#ReportTableImgrtn').DataTable({
                                 "pagingType": "full_numbers",
                                 "bSort": true

                             });
                         });

                        //23/2 EVM-0024
                        if(doctype=="RP")
                        {
                            $('#cphMain_RadioButtonDocList_1').prop('disabled',false);
                            document.getElementById("<%=HiddenRPStatus.ClientID%>").value="2";
                        }
                        //end
                              
                     }
                 }
            </script>
                       <%-----------------------------------------end Job info-----------------------------------------%>

            <%------------------------------------- start SLARY DETAILS----------------------------%>
        <div id="divTblid6" style="float: left;background-color: #f3f3f3;  width: 100%;border: 2px solid;border-color: #06558f;padding: 2%;display:none;">
               <div id="divMessageAreaSalary" style="display:none; width: 84%; margin-left: 6%;margin-top: -12px;">
                 <img id="imgMessageAreaSalary" style="float: left;margin-left: 1%;margin-top: -0.2%;" src="" />
                 <asp:Label ID="lblMessageAreaSalary" runat="server"></asp:Label>
                 </div>
           <div class="cont_rght" style="width: 98%;padding-top:0%">

         
       
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 99.5%;margin-top:1%;">
            <div id="DivPaygrd" style="float:left;width:96%;margin-left: 1%;margin-top: 1%;border: 1px solid;padding: 10px;">
                  <div style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
         Salary
        </div >
         <div style="float:left;width:98%">
               

            
           
        <div id="Divcurrncy" class="eachform" style="width: 98%;margin-top:1%;">

                <h2 style="margin-top:1%;width: 10%;margin-left: 20%;">Pay Grade*</h2>

                <asp:DropDownList ID="ddlPayGrd"  class="form1" runat="server" onchange="RestrictionCaln();" Style="height:30px;width:28.8%;float:left; margin-left: 14.6%;">
                   
                </asp:DropDownList>


            </div>
               <div class="eachform" style="width: 79%;margin-top:0%;float: left;">
                  <h2 style="margin-top:1%;width: 11%;margin-left: 25%;">Basic Pay*</h2>
                    <asp:TextBox ID="txtBasicpayFrm"  class="form1" runat="server"  MaxLength="12" Style="width: 11%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 19.5%;" onkeydown="return isNumberSalary(event,'cphMain_txtBasicpayFrm');" onkeyup="addCommas('cphMain_txtBasicpayFrm')" onblur="AmountChecking('cphMain_txtBasicpayFrm');"></asp:TextBox>
                   </div>
                 <div class="eachform" style="width: 72%;">
                <h2 runat="server" id="IdRestrctdRngBasic" style="margin-left: 27.5%;">Amount Range  </h2>    <h2 runat="server" id="BasicRestrctrang" style="margin-left:18.5%;"> </h2>
              </div>
             
                <div class="eachform" style="width: 21%;  float: right;margin-top: 0%;">
                    <div class="subform" style="width: 58%; margin-left: 46%;padding: 2%;border: 2px solid rgb(207, 204, 204);">

                                 <asp:Button ID="ButtnSalryupd" runat="server" class="save" Text="Update" style="width: 95%;" OnClientClick="return ValidatePayGrade();"  OnClick="btnUpdate_Click"  />
                    <asp:Button ID="ButtonAdd"  runat="server" style="width: 95%;" class="save" Text="Save" OnClientClick="return ValidatePayGrade();" OnClick="btnAdd_Click" />
                     <asp:Button ID="ButtonClr"  runat="server" style="width: 95%;margin-top: 4%;margin-left: 1%;" OnClientClick="return AlertClearAllPaygrd();"  class="cancel" Text="Clear"/>
                    <asp:Button ID="ButtonCancel"  runat="server" style="width: 95%;margin-top: 4%;margin-left: 1%;" OnClientClick="return CancelSalary();"  class="cancel" Text="Cancel"/>
                
                     </div>
                    </div>
             
                
                 </div>
         </div>


           <%-- evm-0023-20-2 strt--%>


    <%-- NEXT DIV   allowance benifit --%>
            

              <div id="divAllnce" runat="server" style="float: left; width:97%; border : 2px solid rgb(207, 204, 204);margin-left : 1.3%;margin-top: 3%;">

                 <div id="divMessageAreaSalaryAllwc" style="display:none; width: 84%; margin-left: 6%;margin-top: 15px;">
                 <img id="imgMessageAreaSalaryAllwc" style="float: left;margin-left: 1%;margin-top: -0.2%;" src="/Images/Icons/imgMsgAreaInfo.png;" />
                 <asp:Label ID="lblMessageAreaSalaryAllwc" runat="server"></asp:Label>
                 </div>

                <div id="div2" style="font-size: 20px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;padding: 1%;">
            Allowance/Benefits
        </div >
                  <div id="divAddtn" class="eachform" style="width: 99%; float: left;margin-top: 1%;">

                            <h2 style="margin-left: 18.5%;">Salary Addition*</h2>
                                                         
                  <asp:DropDownList ID="ddlAddtn" class="form1" onchange="RestrictionCalnAllownce();" runat="server" Style="height:30px;width:28.8%;float:left; margin-left: 12.8%;">
                   
                </asp:DropDownList>

                       


<%--                 <div id="divPyrollTypAllwc" class="eachform" style="width: 98%;float: left;display:none">
                  <h2 style="width: 13%;margin-left: 18.5%;">Payroll Type</h2>

                  <label id="idPyrollTypAllwc" class="form1" style="width: 11.2%; text-transform: uppercase; height: 30px;float: left;margin-left: 12.5%;margin-top: 1%;border: 0;"> </label>

                   </div>--%>



               <div id="divPyrollTypAllwc" class="eachform" style="width: 72%;margin-top:4%;display:none;">
                <h2  style="margin-left: 25.8%;">Payroll Type  </h2>   <h2 id="idPyrollTypAllwc" style="margin-left:22%;"> </h2>
              </div>



                 <div class="eachform" style="width: 26%; float: left; margin-top: 1.5%;/*! height: 130px; */margin-left: 42.5%;">
                                                              
                            <div style="width:31%;float:left;margin-left: 1%;">
                          <input id="rdbAllwcAmt" type="radio" runat="server" onkeydown="return DisableEnter(event)" onchange="RadioAmountClickAllwc()" name="radTyp"  />
                                <label style="font-family:Calibri" for="cphMain_rdbAllwcAmt">Amount</label>
                            </div>

                       
                        
                       <div style="width:39%;float:left;margin-left: 16%;">
                          <input id="rdbAllwcPerc" type="radio" runat="server" onkeydown="return DisableEnter(event)" onchange="RadioPerClickAllwc()" name="radTyp" />
                                <label style="font-family:Calibri" for="cphMain_rdbAllwcPerc">Percentage</label>
                            </div>
                     
                </div>


                  </div>


                                          <div id="divAmtClkAllwnc" >

              <div class="eachform" style="width: 98%;margin-top:0%;float: left;">
                  <h2 style="margin-top:1%;width: 13%;margin-left: 18.5%;">Amount *</h2>
                    <asp:TextBox ID="txtAmntRgeFrm"  class="form1" runat="server" MaxLength="12" Style="width: 11.2%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 12%;" onkeydown="return isNumberSalary(event,'cphMain_txtAmntRgeFrm');" onkeyup="addCommas('cphMain_txtAmntRgeFrm')" onblur="AmountChecking('cphMain_txtAmntRgeFrm','cphMain_txtAmntRgeFrm','cphMain_txtAmntRgeTo');"></asp:TextBox>
                   </div>
                    <div class="eachform" style="width: 72%;">
                <h2  style="margin-left: 25.2%;">Amount Range  </h2>   <h2 id="AllowRestrctrang" style="margin-left:17.5%;"> </h2>
              </div>
                          </div>




                                          <div id="divPerClkAllwnc">

                              <div class="eachform" style="width: 98%;margin-top:0%;float: left;border: 2px solid rgb(207, 204, 204);background-color: #edecec;margin-left: .8%;">
                  <h2 style="margin-top:1%;width: 11%;margin-left: 17.5%;">Percentage *</h2>
                    <asp:TextBox ID="txtPerctgAllwnc"  class="form1" runat="server" MaxLength="3" Style="width: 11.2%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 14.2%;margin-top: .5%;" onkeydown="return isNumberSalary(event,'cphMain_txtPerctgAllwnc');" onkeyup="addCommas('cphMain_txtPerctgAllwnc')" onblur="AmountChecking('cphMain_txtPerctgAllwnc','cphMain_txtPerctgAllwnc','cphMain_txtperctg');"></asp:TextBox>

                                       <div class="eachform" style="width: 26%; float: left; margin-top: 1%;/*! height: 130px; */margin-left: 16.4%;">
                                                              
                            <div style="width:33%;float:left;margin-left: 6%;">
                          <input id="rdbBascPayAllwc" type="radio" runat="server" onkeydown="return DisableEnter(event)" onchange="RadioopenClick()" name="radTypenxt"  />
                                <label style="font-family:Calibri" for="cphMain_radioOpen">Basic Pay</label>
                            </div>                                              
                      
                </div>
                  
               <div class="eachform" style="width: 72%;">
                <h2  style="margin-left: 24.3%;">Percentage Range  </h2>   <h2 id="idRestrctnRangePercAllwnc" style="margin-left:17.5%;"> </h2>
              </div>

                </div>

                          </div>



                 <div class="eachform" style="width: 21%;  float: right;margin-top: 0%;">
                    <div class="subform" style="width: 58%; margin-left: 33%;padding: 2%;border: 2px solid rgb(207, 204, 204);margin-right: 3%;">
                         
                     <asp:Button ID="UpdateAddtn"  runat="server" class="save" style="display:none;width:95%" Text="Update" OnClientClick="return ValidateAllwnce();" OnClick="btnUpdate_Addtn_Click" />
                     <asp:Button ID="SaveAddtn"  runat="server" style="width:95%" class="save" Text="Save" OnClientClick="return ValidateAllwnce();"  OnClick="btnAdd_Addtn_Click" />
                     <asp:Button ID="ClearAddtn"  runat="server" style="margin-left: 2px;width:95%" OnClientClick="return AlertClearAddition();"  class="cancel" Text="Clear"/>
                        </div>
                     </div>
                 <div id="divAllwList" class="table-responsive" runat="server" style="float: left;margin-left: 1.5%;width: 96.6%;font-family:Calibri;">
            <br />
          
                   <%--  style="margin-left: 3.2%;margin-bottom: 1%;"--%>
        </div>
                <br /><br /><br />
                </div>


        <%-- NEXT DIV  deduction  --%>


                      <div id="divdedcn" runat="server" style="float:left;width:97%;border : 2px solid rgb(207, 204, 204);margin-left: 1.3%;margin-top: 3%;">


                  <div id="divMessageAreaSalaryDedctn" style="display:none; width: 84%; margin-left: 6%;margin-top: 15px;">
                 <img id="imgMessageAreaSalaryDedctn" style="float: left;margin-left: 1%;margin-top: -0.2%;" src="/Images/Icons/imgMsgAreaInfo.png;" />
                 <asp:Label ID="lblMessageAreaSalaryDedctn" runat="server"></asp:Label>
                 </div>


                <div id="div4" style="font-size: 20px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;padding: 1%;">
            Deduction
        </div >
                  <div id="div5" class="eachform" style="width: 99%; float: left;margin-top: 1%;">

                            <h2 style="margin-left: 18.3%;">Salary Deduction*</h2>
                                                         
                                    <asp:DropDownList ID="ddldedctn" class="form1" onchange="RestrictionCalnDedcn();" runat="server" Style="height:30px;width:28.8%;float:left; margin-left: 11.8%;">
                                        
                   
                </asp:DropDownList>

                  
               <div id="divPyrollTypDedctn" class="eachform" style="width: 72%;margin-top:4%;display:none;">
                <h2  style="margin-left: 25.8%;">Payroll Type  </h2>   <h2 id="idPyrollTypDedctn" style="margin-left:22%;"> </h2>
              </div>


                        <div class="eachform" style="width: 26%; float: left;margin-left: 42.5%;margin-top: 1%">
                                                              
                            <div style="width:31%;float:left;margin-left: 2.2%;">
                          <input id="radAmnt" type="radio" runat="server" onkeydown="return DisableEnter(event)" onchange="RadioAmountClick()" name="radTyp"  />
                                <label style="font-family:Calibri" for="cphMain_radAmnt">Amount</label>
                            </div>

                       
                        
                       <div style="width:39%;float:left;margin-left: 16%;">
                          <input id="radPercntge" type="radio" runat="server" onkeydown="return DisableEnter(event)" onchange="RadioPerClick()" name="radTyp" />
                                <label style="font-family:Calibri" for="cphMain_radPercntge">Percentage</label>
                            </div>
                     
                </div>
                                                            
                                                         
                                                </div>
                          <div id="divAmtClk" >

              <div class="eachform" style="width: 98%;margin-top:0%;float: left;">
                  <h2 style="margin-top:1%;width: 13%;margin-left: 18.5%;">Amount *</h2>
                    <asp:TextBox ID="txtAmntRedcnFrom"  class="form1" runat="server" MaxLength="12" Style="width: 11.2%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 12%;" onkeydown="return isNumberSalary(event,'cphMain_txtAmntRedcnFrom');" onkeyup="addCommas('cphMain_txtAmntRedcnFrom')" onblur="AmountChecking('cphMain_txtAmntRedcnFrom','cphMain_txtAmntRedcnFrom','cphMain_txtAmntRedcnTo');"></asp:TextBox>
                   </div>
<div class="eachform" style="width: 72%;">
                <h2  style="margin-left: 25.2%;">Amount Range  </h2>   <h2 id="DedctnRestrctrang" style="margin-left:17.5%;"> </h2>
              </div>
                          </div>
                          <div id="divperclk">

                              <div class="eachform" style="width: 98%;margin-top:0%;float: left;border: 2px solid rgb(207, 204, 204);background-color: #edecec;margin-left: .8%;">
                  <h2 style="margin-top:1%;width: 11%;margin-left: 17.5%;">Percentage *</h2>
                    <asp:TextBox ID="txtperctg"  class="form1" runat="server" MaxLength="3" Style="width: 11.2%; text-transform: uppercase;text-align:right;  height: 30px;float: left;margin-left: 14.2%;margin-top: .5%;" onkeydown="return isNumberSalary(event,'cphMain_txtperctg');" onkeyup="addCommas('cphMain_txtperctg')" onblur="AmountChecking('cphMain_txtperctg','cphMain_txtperctg','cphMain_txtperctg');"></asp:TextBox>

                                       <div class="eachform" style="width: 26%; float: left; margin-top: 1%;/*! height: 130px; */margin-left: 16.4%;">
                                                              
                            <div style="width:33%;float:left;margin-left: 6%;">
                          <input id="radioBascPay" type="radio" runat="server" onkeydown="return DisableEnter(event)" onchange="RadioopenClick()" name="radTypenxt"  />
                                <label style="font-family:Calibri" for="cphMain_radioOpen">Basic Pay</label>
                            </div>

                       
                        
                       <div style="width:46%;float:left;margin-left: 14%;">
                          <input id="radioTotlAmnt" type="radio" runat="server" onkeydown="return DisableEnter(event)" onchange="RadioLimitedClick()" name="radTypenxt" />
                                <label style="font-family:Calibri" for="cphMain_radioLimited">Total Amount</label>
                            </div>
                      
                </div>
                  
               <div class="eachform" style="width: 72%;">
                <h2  style="margin-left: 24.3%;">Percentage Range  </h2>   <h2 id="idDedRestrctnRangePerc" style="margin-left:17.5%;"> </h2>
              </div>

                </div>

                          </div>
                       

                            <div class="eachform" style="width: 21%;  float: right;margin-top: 0%;">
                    <div class="subform" style="width: 58%; margin-left: 33%;padding: 2%;border: 2px solid rgb(207, 204, 204);margin-right: 3%;">
                      
                     <asp:Button ID="UpdateDedctn"  runat="server" class="save" style="display:none;width:95%" Text="Update" OnClientClick="return ValidateDedctn();" OnClick="btnUpdate_Dedctn_Click" />
                     <asp:Button ID="SaveDedctn" style="width:95%;" runat="server"  class="save" Text="Save" OnClientClick="return ValidateDedctn();" OnClick="btnAdd_Dedctn_Click"  />
                     <asp:Button ID="ClearDedctn"  runat="server" style="margin-left: 2px;width:95%;" OnClientClick="return AlertClearDedAll();"  class="cancel" Text="Clear"/>
                        </div>
                     </div>
                 <div id="divList" class="table-responsive" runat="server" style="margin-left: 2.2%;margin-bottom: 1%;float: left;width: 96%;font-family:Calibri;">
            <br />
          
        </div>
                </div>
              <div id="DivSalrysumry" class="eachform" style="float:left;width:97%;border: 2px solid rgb(207, 204, 204);margin-left: 1.3%;margin-top: 3%;">
                          <div id="div6"  style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
         <h3 style="padding-left: 1%;font-size: 23px;margin-top: 1%"> Salary Summary </h3>   
                              <div style="padding:5%">
                               <h2 style="width:10%">Basic Pay  </h2>   <h2 id="SumryPayRng" style="width:15%;text-align:right;"> </h2> <br />
                               <h2 style="width:10%">Addition  </h2>   <h2 id="SumryAdtnRng" style="width:15%;text-align:right;"></h2> <br />
                               <h2 style="width:10%">Deduction </h2>     <h2 id="SumryDedctnRng" style="width:15%;text-align:right;"></h2>  <br />
                                    <h2 style="width:10%">Total pay </h2>     <h2 id="SumryTotalpay" style="width:15%;text-align:right;"></h2>  <br />
                                  </div>
        </div >
                  </div>

           <%-- evm-0023-20-2 end--%>

            <br style="clear: both" />
            </div>
        <br />
</div>

            </div>
            <%------------------------------end salary details---------------------------------%>


            <div id="divTblid7"  style="float: left;background-color: #f3f3f3;  width: 100%;border: 2px solid;border-color: #06558f;padding: 2%;display:none;">
                   <%--Qualification --%>
              <div style="width: 99%;border: 1px solid;margin-top: -1%;padding: 4px;border-color: #144c96;background: #51828a;">
            <div id="divButtonWrkExp" onclick="divButtonWrkExpClick()" class="divbutton" >Work Experience</div>
            <div id="divButtonEducation" onclick="divButtonEductnClick()" class="divbutton" >Education</div> 
            <div id="divButtonSkill" onclick="divButtonSkillClick()" class="divbutton" >Skills & Certifications</div>
            <div id="divButtonLang" onclick="divButtonLangClick()" class="divbutton" >Language</div> 
                  </div>  
            <%--Start:Qualification:Work Experience--%>   
            <div id="divWorkExp" style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 96%; margin-top:1%;padding:2%;"> 
                 <div id="divMessageAreaWrkExp" style="display:none; width: 84%; margin-left: 6%;margin-top: -1%;">
                 <img id="imgMessageAreaWrkExp" src="" />
                 <asp:Label ID="lblMessageAreaWrkExp" runat="server"></asp:Label>
                 </div>          
            <div id="divwrkExpCaptn" class="Quacaption" >
            <asp:Label ID="lblWrkExpCaptn" runat="server">Add Work Experience</asp:Label>
            </div> 
                <br />
             <div class="eachform" style="float:left;">
             <h2>Company*</h2>             
             <asp:TextBox ID="txtWrkCompny" class="form1" runat="server"   MaxLength="100" Height="30px"  Style="height:30px;width:55%;resize:none; text-transform: uppercase; font-family: calibri;margin-right: 5%;"></asp:TextBox> 
            </div>
              <div class="eachform" style="float:right">
             <h2>Job Title*</h2>             
             <asp:TextBox ID="txtWrkJobTle" class="form1" runat="server"   MaxLength="100" Height="30px"  Style="height:30px;width:55%;resize:none; text-transform: uppercase; font-family: calibri;margin-right: 5%;"></asp:TextBox> 
            </div>

             <div class="eachform" style="float:left">
                <h2>From</h2>
                
               <div id="divWrkFrom" class="input-append date" style="float: right;width: 59%;margin-right: 5%;">

                 
                   
                        <asp:TextBox ID="txtWrkFromDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height:30px;width:81%;margin-top: 0%;float:left;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image11" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divWrkFrom').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
               

            </div>
             <div class="eachform" style="float:right;">
                <h2>To</h2>
                
               <div id="divWrkTo" class="input-append date" style="float: right;width: 59%;margin-right: 5%;">

                 
                   
                        <asp:TextBox ID="txtWrkToDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="43%" Style="height:30px;width:81%;margin-top: 0%;float:left;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image15" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divWrkTo').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
               

            </div>
             <div class="eachform" style="float:left;">
                <h2>Comment</h2>
                
                <asp:TextBox ID="txtWrkCmnt" class="form1" runat="server" TextMode="MultiLine"   MaxLength="500" Width="50%" Height="81px"  Style="height:81px;width:55%;resize:none;  font-family: calibri;margin-right: 5%;" onblur="textCounter(cphMain_txtWrkCmnt,450)" onkeydown="textCounter(cphMain_txtWrkCmnt,450)" onkeyup="textCounter(cphMain_txtWrkCmnt,450)"></asp:TextBox>    <%--//emp17--%>
              
            </div>
            <div class="eachform" style="float:right;" >          
                        <h2 >Attachment</h2>

                           <div style="margin-right:5%;float: right;width: 59%;">
                <label for="cphMain_FileUploadWrk" class="custom-file-upload" style="margin-left: 0%;" tabindex="0">
                    <img src="../../Images/Icons/cloud_upload.jpg" />Upload File</label>
                <%--<input id="file" name = "file" type="file" onchange="ClearDivDisplayImage()" accept="image/png, image/gif, image/jpeg" />--%>

                <asp:FileUpload ID="FileUploadWrk" class="fileUpload" runat="server" Style="height: 30px; display: none;" onchange="ClearDivDisplayImageWrkExp()" Accept="image/png, image/gif, image/jpeg" />


                <div id="divWrkImageEdit" runat="server" style=" width: 100%;margin-left: 43.3%;float: right; height: 20px; margin-top: -1%;">
                    

                    <div class="imgWrap" id="div10" runat="server">
                        <img id="Img1" src="../../Images/Icons/clear-image-green.png" class="tooltip" style="position: relative;float: right;opacity: 1;z-index: 100;margin-top:-3%;" title="Remove Selected Photo" alt="Clear" onclick="ClearImageWrkExp()"  style="cursor: pointer; float: right;" />
                        <%--<p id="RemovePhoto" class="imgDescription" style="color: white">Remove Selected Photo</p>--%>
                    </div>
                    <div id="divWrkImgdis" runat="server">
                    </div>
                </div>
                <asp:Label ID="LabelWrkAttmnt" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
            
                       </div>

                  </div>
               
                <div id="divWrkRef" style="width:98%;border:.5px solid;border-color: #9ba48b;padding:1%;float:left;margin-top:1%;background-color: #e9e9e9;">
                 <div style="float:left;width:100%">
                  <asp:CheckBox ID="cbxRefCheck" Text="" runat="server" onkeypress="return isTag(event);" onClick="refVerClick();"  class="form2" />
                   <h2 style="font-size:18px;">Reference Check Verified</h2>
                   </div>
                 <div class="eachform" style="width:49%;">
                <h2>Name*</h2>
                
                <asp:TextBox ID="txtWrkRefName" class="form1" runat="server" Enabled="false"   MaxLength="100" Width="50%" Height="30px"  Style="resize:none; margin-left: 24%; float: left; text-transform: uppercase; font-family: calibri;"></asp:TextBox>  <%--//12emp17--%>
              
                </div>
                <div class="eachform" style="width:49%;">
               <h2 style="float: left;margin-left: 5%;">Designation</h2>    <%--emp17--%>
                
                <asp:TextBox ID="txtWrkRefDesg" class="form1" runat="server" Enabled="false"   MaxLength="100" Width="50%" Height="30px"  Style="resize:none; text-transform: uppercase; float: left;margin-left: 19%; font-family: calibri;"></asp:TextBox>   <%--//12emp17--%>
              
                </div>
               </div>

                 <div class="eachform" style="margin-top:2%;margin-left:17%;">
                <div class="subform" style="width:448px;">
                    <div class="form-group" >
                     
                        <asp:Button ID="btnUpdateWrkExp" runat="server" style="display:none;"  class="save" Text="Update" OnClick="btnUpdateWrkExp_Click" OnClientClick="return ValidateWrkExp(); " />
                         <asp:Button ID="btnAddWrkExp" runat="server" class="save" Text="Save" OnClick="btnAddWrkExp_Click" OnClientClick="return ValidateWrkExp();" />
                         <asp:Button ID="btnClearWrkExp" runat="server" style="margin-left: 11px;" OnClientClick="return AlertClearAllWrkExp();"    class="cancel" Text="Clear"/>
                         <asp:Button ID="btnCancelWrkExp" runat="server" class="cancel" style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCnclWrkExp();" />
                         </div>
                </div>

            </div>
                                 <div id="Div13" class="Quacaption" >     <%--//15emp17--%>
            <asp:Label ID="label12" runat="server">List Work Experience</asp:Label>
            </div>
             <div id="divListWrkExp" class="table-responsive" runat="server" style="border: 1px solid;border-color: #428734;margin-top: 2%;padding: 14px;width: 100%;margin-left: -1.5%;font-family:Calibri">
              
           
        </div>

            
            </div>  
            <%--End:Qualification:Work Experience--%> 


            <%--Start:Qualification:Education--%> 
            <div id="divEductn" style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 96%; margin-top:1%;padding:2%;font-family:Calibri">   
             <div id="divMessageAreaEdu" style="display:none; width: 84%; margin-left: 6%;margin-top: -1%;">
             <img id="imgMessageAreaEdu" src="" />
             <asp:Label ID="lblMessageAreaEdu" runat="server"></asp:Label>
             </div>        
            <div id="divEduCaptn" class="Quacaption" >
            <asp:Label ID="lblEduCaptn" runat="server">Add Education</asp:Label>
            </div> 
             <br />
              <div class="eachform" style="float:left;">
                <h2>Level*</h2>
                
                <asp:DropDownList ID="ddlEduLvl"  class="form1" runat="server" Style="height:30px;width:55%;text-align:left;margin-right: 3%;"></asp:DropDownList>
              
              </div>
              <div class="eachform" style="float:right;">
             <h2 style="margin-left: 3%;">Institute</h2>             
             <asp:TextBox ID="txtEduInstite" class="form1" runat="server"   MaxLength="200"   Style="width:55%;margin-right: 3%; text-transform: uppercase; font-family: calibri;"></asp:TextBox> 
             </div>
             <div class="eachform" style="float:left;">
             <h2>Major/Specialization</h2>             
             <asp:TextBox ID="txtEduMjr" class="form1" runat="server"   MaxLength="50"  Style="height:30px;width:51%; text-transform: uppercase; font-family: calibri;margin-right: 3%;"></asp:TextBox> 
             </div>
             <div class="eachform" style="float:right">
             <h2 style="margin-left: 3%;">Year</h2>             
             <asp:TextBox ID="txtEduYear" class="form1" runat="server"   MaxLength="4" Style="height:30px;width:55%;  font-family: calibri;margin-right: 3%;" onblur="return NumChecking('cphMain_txtEduYear');" OnKeydown="return isNumber(event);"></asp:TextBox> 
             </div>
             <div class="eachform" style="float:left;">
             <h2>GPA/Score</h2>             
             <asp:TextBox ID="txtEduGPA" class="form1" runat="server"   MaxLength="6" Style=" text-transform: uppercase; font-family: calibri;margin-right: 3%;width: 51%;" onblur="return NumChecking('cphMain_txtEduGPA');" OnKeydown="return isNumber(event);"></asp:TextBox> 
             </div>
              <div class="eachform" style="float:right;">
                <h2 style="margin-left: 3%;">Start Date</h2>
                
               <div id="divEduStrtDate" class="input-append date" style="float: right;width: 62%;">

                 
                   
                        <asp:TextBox ID="txtEduStrtDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="height:30px;width:77%;margin-top: 0%;float:left;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image16" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

                       
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
             <div class="eachform" style="float:left;">
                <h2>End Date</h2>
                
               <div id="divEduEndDate" class="input-append date" style="float: right;width: 58%;">

                 
                   
                        <asp:TextBox ID="txtEduEndDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="height:30px;width:76%;margin-top: 1%;float:left;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image" runat="server" id="Image17" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0.9%;" />

                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divEduEndDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
               

            </div>
             <div class="eachform" style="float:right;" >          
                        <h2 style="margin-left: 3%;" >Attachment</h2>

                           <div style="float: right;width: 62%;"> 
                <label for="cphMain_FileUploadEdu" class="custom-file-upload" tabindex="0" style="margin-left: 0%;">
                    <img src="../../Images/Icons/cloud_upload.jpg" />Upload File</label>
                <%--<input id="file" name = "file" type="file" onchange="ClearDivDisplayImage()" accept="image/png, image/gif, image/jpeg" />--%>

                <asp:FileUpload ID="FileUploadEdu" class="fileUpload" runat="server" Style="height: 30px; display: none;" onchange="ClearDivDisplayImageEdu()" Accept="image/png, image/gif, image/jpeg" />


                <div id="divEduImageEdit" runat="server" style=" width: 100%;margin-left: 43.3%;float: right; height: 20px; margin-top: -1%;">
                    

                    <div class="imgWrap" id="div11" runat="server">
                        <img id="Img2" src="../../Images/Icons/clear-image-green.png" class="tooltip" style="position: relative;float: right;opacity: 1;z-index: 100;margin-top:-3%;" title="Remove Selected Photo" alt="Clear" onclick="ClearImageEdu()"  style="cursor: pointer; float: right;" />
                        <%--<p id="RemovePhoto" class="imgDescription" style="color: white">Remove Selected Photo</p>--%>
                    </div>
                    <div id="divEduImgdis" runat="server">
                    </div>
                </div>
                <asp:Label ID="lblEduImage" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
            
                       </div>

                  </div>
               <div class="eachform" style="margin-top:2%;margin-left:29%;">
                <div class="subform" style="width:448px;margin-left:11%">
                    <div class="form-group" >
                     
                        <asp:Button ID="BtnUpdateEdu" runat="server" style="display:none;" class="save" Text="Update" OnClick="btnUpdateEdu_Click"  OnClientClick="return ValidateEdu(); " />
                         <asp:Button ID="BtnAddEdu" runat="server" class="save" Text="Save" OnClick="btnAddEdu_Click" OnClientClick="return ValidateEdu();" />
                         <asp:Button ID="BtnClearEdu" runat="server" style="margin-left: 11px;" OnClientClick="return AlertClearAllEdu();"    class="cancel" Text="Clear"/>
                          <asp:Button ID="ButtonCnclEdu" runat="server" class="cancel" style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCnclEdu();" />
                         </div>
                </div>

            </div>
                 <div id="listedcn" class="Quacaption" >     <%--//15emp17--%>
            <asp:Label ID="label_list" runat="server">List Education</asp:Label>
            </div> 

             <div id="divListEdu" class="table-responsive" runat="server" style="border: 1px solid;border-color: #428734;margin-top: 2%;padding: 14px;width: 100%;margin-left: -1.5%;font-family:Calibri">
            <br />
            <br />
            
           
        </div>

            </div>  
            <%--End:Qualification:Education--%> 

            <%--Start:Qualification:Skill&certification--%> 
            <div id="divSkillCer" style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 96%; margin-top:1%;padding:2%;">           
             <div id="divMessageAreaSkCer" style="display:none; width: 84%; margin-left: 6%;margin-top: -1%;">
             <img id="imgMessageAreaSkCer" src="" />
             <asp:Label ID="lblMessageAreaSkCer" runat="server"></asp:Label>
             </div>
            <div id="divSkillCerCaptn"   >
            <asp:Label ID="lblSkillCer" class="Quacaption" runat="server">Add Skills & Certifications</asp:Label> 
               <div id="divRadioSkCer" style="width: 248px;float: right;" >         
                   <asp:RadioButton  ID ="radioSkill" Text="Skill" runat="server" Checked="true" OnChange="SkillCerRadioChange();"  GroupName ="RadioSkCer" style="float:left;font-family: calibri"/>  <%--//12emp17--%>
                   <asp:RadioButton  ID ="radioCer" Text="Certification" runat="server" OnChange="SkillCerRadioChange();"  GroupName ="RadioSkCer" style="float:left;font-family: calibri"/>  <%--//12emp17--%> 
                   
              
                  </div>       
            </div>
              <br />  
               
              <div id="divSkill" class="eachform" style="float:left;">
                <h2>Skill*</h2>
                
                <asp:DropDownList ID="ddlSCSkill" class="form1" runat="server" Style="height:30px;width:58%;text-align:left;margin-right: 5%;"></asp:DropDownList>
              
              </div>
              <div id="divCer" class="eachform" style="display:none;float:left;">
             <h2>Certification*</h2>             
             <asp:TextBox ID="txtSCCertfcn" class="form1" runat="server"   MaxLength="100" Width="55%" Height="30px"  Style="height:30px;width:55%;resize:none; text-transform: uppercase; font-family: calibri;float: right;margin-right: 4%;"></asp:TextBox> 
             </div>   
               <div class="eachform" style="float:right;">
             <h2>Years Of Experience</h2>             
             <asp:TextBox ID="txtSCYearExp" class="form1" runat="server"   MaxLength="2" Width="55%" Height="30px" onblur="return NumChecking('cphMain_txtSCYearExp');" Style="resize:none; text-transform: uppercase; font-family: calibri;" OnKeydown="return isNumber(event);"></asp:TextBox>  <%--12emp17--%>
             </div>  
              <div class="eachform" style="float:left;">
                <h2>Comment</h2>
                
                <asp:TextBox ID="txtSCcmnt" class="form1" runat="server" TextMode="MultiLine"   MaxLength="500"  Style="height:81px;width:54%;resize:none;  font-family: calibri;margin-right: 5%;" onblur="textCounter(cphMain_txtSCcmnt,450);" onkeydown="textCounter(cphMain_txtSCcmnt,450)" onkeyup="textCounter(cphMain_txtSCcmnt,450)"></asp:TextBox> <%--12emp17--%>
              
            </div>
            <div class="eachform" style="float:right;" >          
                        <h2 >Attachment</h2>

                           <div style="float:right;width: 59%;">
                <label for="cphMain_FileUploadSkCer" class="custom-file-upload" tabindex="0" style="margin-left: 0%;">
                    <img src="../../Images/Icons/cloud_upload.jpg" />Upload File</label>
                <%--<input id="file" name = "file" type="file" onchange="ClearDivDisplayImage()" accept="image/png, image/gif, image/jpeg" />--%>

                <asp:FileUpload ID="FileUploadSkCer" class="fileUpload" runat="server" Style="height: 30px; display: none;" onchange="ClearDivDisplayImageSkCer()" Accept="image/png, image/gif, image/jpeg" />


                <div id="divSkCerImgEdit" runat="server" style=" width: 100%;margin-left: 43.3%;float: right; height: 20px; margin-top: -1%;">
                    

                    <div class="imgWrap" id="div12" runat="server">
                        <img id="Img3" src="../../Images/Icons/clear-image-green.png" class="tooltip" style="position: relative;float: right;opacity: 1;z-index: 100;margin-top:-3%;" title="Remove Selected Photo" alt="Clear" onclick="ClearImageSkCer()"  style="cursor: pointer; float: right;" />
                        <%--<p id="RemovePhoto" class="imgDescription" style="color: white">Remove Selected Photo</p>--%>
                    </div>
                    <div id="divSkCerImgDis" runat="server">
                    </div>
                </div>
                <asp:Label ID="lblSKCerImg" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
            
                       </div>

                  </div>    
                 <div class="eachform" style="margin-top:2%;margin-left:29%;">
                <div class="subform" style="width:448px;margin-left: 11%;">
                    <div class="form-group" >
                     
                        <asp:Button ID="BtnUpdateSkCer" runat="server" style="display:none;" class="save" Text="Update" OnClick="btnUpdateSkCer_Click"  OnClientClick="return ValidateSkCer(); " />
                         <asp:Button ID="BtnAddSkCer" runat="server" class="save" Text="Save" OnClick="btnAddSkCer_Click"  OnClientClick="return ValidateSkCer();" />
                         <asp:Button ID="BtnClearSkCer" runat="server" style="margin-left: 11px;" OnClientClick="return AlertClearAllSkCer();"    class="cancel" Text="Clear"/>
                          <asp:Button ID="ButtonCnclSkCer" runat="server" class="cancel" style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCnclSkCer();" />
                         </div>
                </div>

            </div>
                 <div id="skilllist"> <%--//12emp17--%>
            <asp:Label ID="Label3" class="Quacaption" runat="server">List Skills & Certifications</asp:Label>              
            </div><%--//12emp17--%>
           
             <div id="divSkCerList" class="table-responsive" runat="server" style="border: 1px solid;font-family:Calibri; border-color: #428734;margin-top: 2%;padding: 14px;width: 100%;margin-left: -1.5%;font-family:Calibri"> <%--//12emp17--%>
            <br />
            <br />
            
           
        </div>
                 
            </div> 
              <%--End:Qualification:Skill&certification--%> 

            <%--Start:Qualification:Language--%> 
            <div id="divLang" style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 96%; margin-top:1%;padding:2%;">           
            <div id="divMessageAreaLang" style="display:none; width: 84%; margin-left: 6%;margin-top: -1%;">
             <img id="imgMessageAreaLang" src="" />
             <asp:Label ID="lblMessageAreaLang" runat="server"></asp:Label>
             </div>
             <div id="divLangCaptn" class="Quacaption" >
            <asp:Label ID="lblLangCaptn" runat="server">Add Language</asp:Label>
            </div>
                 <br />
              <div class="eachform" style="float:left;">
                <h2>Language*</h2>
                
                <asp:DropDownList ID="ddlQuLang" Height="30px" Width="54%" class="form1" runat="server" Style="text-align:left;"></asp:DropDownList>
              
              </div> 

                 <div class="eachform" style="float:right;margin-bottom: 11px;">
                        
                        <h2>Skill*</h2> 
                     <div id="divSkillCbx" style="width:53.5%;height:23px;border:1px solid #cfcccc;margin-left:46%;">
                        <div style="margin-left:4%;">
                        <asp:CheckBox ID="CbxLangWrt" Text="" runat="server" onkeypress="return isTag(event);" onClick="IncrmntConfrmCounter();"  class="form2" />
                        <h2 style="font-size:15px;margin-top:1.8%;" >Write</h2>
                         </div>
                       
                        <div style="margin-left:31%;" >
                        <asp:CheckBox ID="CbxLangRead" Text="" runat="server" onkeypress="return isTag(event);" onClick="IncrmntConfrmCounter();"  class="form2" />
                          <h2 style="font-size:15px;margin-top:1.8%;" >Read</h2>
                         </div>
                        <div style="margin-left:57%;" >
                        <asp:CheckBox ID="CbxLangSpk" Text="" runat="server" onkeypress="return isTag(event);" onClick="IncrmntConfrmCounter();"  class="form2" />
                          <h2 style="font-size:15px;margin-top:3%;" >Speak</h2>
                         </div>
                     </div>
                    </div>

             <div class="eachform" style="float:left;margin-right:5%;">
                <h2 style="margin-top: 4%";>Fluency Level</h2>
                   <div id="ddlLangFlncyLvl" class="star-rating" style="float:right;width:39%;text-align:left;"><s id="s1" style="font-size:44px"><s id="s2"style="font-size:44px"><s id="s3"style="font-size:44px"><s id="s4"style="font-size:44px"><s id="s5"style="font-size:44px"></s></s></s></s></s></div>
                       <div class="show-result"style="float:right;width:15%" ></div> 
                 </div> 
                 <div class="eachform" style="float:right;margin-top:-4%;">
                <h2>Comment</h2>
                
                <asp:TextBox ID="txtLangCmnt" class="form1" runat="server" TextMode="MultiLine"   MaxLength="500" Width="50%" Height="81px"  Style="resize:none;  font-family: calibri;" onkeydown="textCounter(cphMain_txtLangCmnt,500)" onkeyup="textCounter(cphMain_txtLangCmnt,500)"></asp:TextBox>
              
            </div>
               <div class="eachform" style="margin-top:2%;margin-left:29%;">
                <div class="subform" style="width:448px; float: left;margin-left: 10.8%;" ><%-- 12emp17--%>

                    <div class="form-group" >
                     
                        <asp:Button ID="BtnLangUpdate" runat="server" style="display:none;" class="save" Text="Update" OnClick="btnUpdLang_Click"  OnClientClick="return ValidateLang(); " />
                         <asp:Button ID="BtnLangAdd" runat="server" class="save" Text="Save" OnClick="btnAddLang_Click"     OnClientClick="return ValidateLang();" />
                         <asp:Button ID="BtnLangClear" runat="server" style="margin-left: 11px;" OnClientClick="return AlertClearAllLang();"    class="cancel" Text="Clear"/>
                          <asp:Button ID="BtnLangCncl" runat="server" class="cancel" style="margin-left: 20px;" Text="Cancel" OnClientClick="return ConfirmCnclLang();" />
                         </div>
                </div>

            </div>
                  <br /><%--12emp17--%>
                <div id="listcaption" class="Quacaption" style="height: 41px;" >
            <asp:Label ID="Label1" runat="server">List Language</asp:Label>
            </div><%--12emp17--%>
             
             <div id="divListLang" class="table-responsive" runat="server" style="border: 1px solid;font-family:Calibri; border-color: #428734;margin-top: 2%;padding: 14px;width: 100%;margin-left: -1.5%;font-family:Calibri"> <%--12emp17--%>
            <br />
            <br />
            
           
        </div>  
                 
            </div> 
            <%--End:Qualification:Language--%> 

               

            <%--Qualification --%>
            </div>
         
           <div id="divTblid8"  style="float: left;background-color: #f3f3f3;  width: 100%;border: 2px solid;border-color: #06558f;padding: 2%;display:none;">
            
    <asp:HiddenField ID="hiddenLicenseTypeId" runat="server" />
    <asp:HiddenField ID="HiddenField5" runat="server" />
    <asp:HiddenField ID="HiddenField6" runat="server" />
    <asp:HiddenField ID="hiddenUserLicenseCopy" runat="server" />
    <asp:HiddenField ID="hiddenUserEditId" runat="server" />
   
    <asp:HiddenField ID="HiddenField7" runat="server" />
    <asp:HiddenField ID="hiddenLicenseCopyName" runat="server" />
    <asp:HiddenField ID="HiddenField8" runat="server" />
    <asp:HiddenField ID="HiddenJobrole" runat="server" />
             
    <div class="cont_rght">

         <div id="divMessageAreaMain" style="display:none;width:84%;margin-left:8%;">
                 <img id="imgMessageAreaMain" style="float:left"  src="" />
                 <asp:Label ID="LblMessageAreaMain" runat="server"></asp:Label>
          </div>
       
        <%--<h2>Add Personal Details</h2>--%>
   
              <%--<asp:Label ID="Labelcaption" runat="server"></asp:Label>--%>
        <div id="divEmpGnDtl"  class="fillform">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
                    
                    
         <div class="eachform" style="float:left;">
                <h2>First Name*</h2>
                
                <asp:TextBox ID="TxtFrstName" class="form1" runat="server"   MaxLength="100" Width="51.5%" Height="30px"  Style="resize:none; text-transform: uppercase; font-family: calibri;float: left;margin-left: 18.4%;"></asp:TextBox>
              
            </div>
            <div class="eachform" style="float:right;">
                <h2 style="margin-left: -4%;float:left">Middle Name</h2>
                
                <asp:TextBox ID="TxtMidleName" class="form1" runat="server"   MaxLength="100" Width="51%" Height="30px"  Style="resize:none; text-transform: uppercase; font-family: calibri;"></asp:TextBox>
              
            </div>

              
               
            <div class="eachform" style="float:left;">
                <h2>Last Name*</h2>
                
                <asp:TextBox ID="TxtLstName" class="form1" runat="server"   MaxLength="100" Width="51.5%" Height="30px"  Style="resize:none; text-transform: uppercase; font-family: calibri;float: left;margin-left: 19%;"></asp:TextBox>
              
            </div>
                    
       
             <asp:UpdatePanel ID="UpdatePanelTree" runat="server"  UpdateMode="Conditional">
       <ContentTemplate>
            <asp:HiddenField ID="hiddenDsgnContrl" runat="server" />
             <asp:HiddenField ID="HiddenRPStatus" runat="server" /> 
             <asp:HiddenField ID="HiddenStaffWorkr" runat="server" />
             <asp:HiddenField ID="Hiddenusermode" runat="server" /> 
            <asp:HiddenField ID="hiddenRowCount" runat="server" />
            <div class="eachform " style="float: right; width: 50%;">

                <h2 style="margin-top: 1%;">Designation*</h2>
    
                <asp:DropDownList ID="ddlUsrDsgn" Width="268px" class="form1" runat="server" Height="30px" AutoPostBack="true" OnSelectedIndexChanged="ddlUsrDsgn_SelectedIndexChanged"></asp:DropDownList>
           
                <p class="error" id="P2" style="display: none">Please enter </p>


            </div>

      
            <div style="float:left;width:100%;height: 50px;">
            <div class="eachform" style="float: left; width: 50%;">

                <h2 style="margin-top: 1%;">Role*</h2>

                <asp:DropDownList ID="ddlJobRole" Width="268px" class="form1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlJobRole_SelectedIndexChanged"  Height="30px" style="float: right;margin-right: 13%;"></asp:DropDownList>
                <p style="visibility: hidden">Please enter</p>
            </div>
            <%--    0013--%>




         

            <div class="eachform" style="width: 50%;float: right;margin-top: 1%;">

                <h2 style="margin-top: 1%;">National ID Number</h2>

                <asp:TextBox ID="txtNationalIdNmbr" style="float: right;margin-right: 0.3%;" class="form1" runat="server" MaxLength="100" Height="30px" Width="250px" onblur="ReplaceTagOnBlur('cphMain_txtNationalIdNmbr');"></asp:TextBox>
                <p style="visibility: hidden">Please enter</p>
            </div>
            </div>
     
    
            <div class="eachform" style="float: left; width: 50%;">

                <h2 style="margin-top: 1%;">Employment Type*</h2>
                <asp:DropDownList ID="ddlEmpType" Width="268px" class="form1" runat="server" Height="30px" style="float: right;margin-right: 13%;"></asp:DropDownList>
              
            </div>

             <div class="eachform" style="width: 50%;float: right;height: 35px;">

                <h2 style="margin-top: 1%;">Mobile </h2>
                <asp:TextBox ID="txtUsrMob" class="form1" runat="server" MaxLength="50" Height="30px" Width="250px" onkeydown="return isNumber(event)" onblur="return BlurNotNumber('cphMain_txtUsrMob')" Style="text-transform: uppercase;float: right;margin-right: 0%;"></asp:TextBox>

                <p class="error" id="ErrorMsgUsrMob" style="visibility: hidden; font-family: Calibri; font-size: small;margin-top:0%;margin-left:0%;">Please enter valid Mobile Number</p>

            </div>
            <div style="clear:both;"></div>
                <div class="eachform" style="float:left;">
                <h2>Nationality*</h2>
                
                  <asp:DropDownList ID="ddlNationality" Height="30px" Width="55.1%" class="form1" runat="server" Style="text-align:left;margin-left: 18%;float: left;"></asp:DropDownList>
              
            </div>
            <div class="eachform" style="float:left;margin-left: 2%;height: 23px;">
                <h2 style="margin-top:-1.5%;">Gender*</h2>
                
               
                   <div id="divRadioOther" class="subform" style="float: left;margin-left: 32%;margin-top:-2%;">         
                   <asp:RadioButton  ID ="RadioButtonMale" style="float: left;margin-left: 7.8%;" Text="Male" runat="server" Checked="true" GroupName ="RadioGender" /> 
                   <asp:RadioButton  ID ="RadioButtonFemale" style="float: left;margin-left: 2.8%;" Text="Female" runat="server"  GroupName ="RadioGender"/> 
                   <asp:RadioButton  ID ="RadioButtonOther"  style="float: left;margin-left: 1.8%;" Text="Other" runat="server"    GroupName ="RadioGender" />  
              
                  </div>             
              
            </div>
            <div style="clear:both;"></div>

            <div id="divEmptype" class="eachform" style="width:50%;float:left;margin-top: 1%;">
               <h2 style="float:left">Employee Type*</h2>

                <asp:DropDownList ID="ddlStafftype" class="form1" runat="server" Style="height:30px;width:53%;text-align:left;float: left;margin-left: 11.5%;"></asp:DropDownList>

             </div>

           

            <div class="eachform" style="float: right; width: 50%;">

                <h2 id="lblEmail" style="margin-top: 1%;">Permanent Email</h2>

                <asp:TextBox ID="txtUsrEmail" class="form1" runat="server" MaxLength="100" Height="30px" Width="250px" onkeypress="return isTag(event)" onblur="ReplaceTagOnBlur('cphMain_txtUsrEmail');" style=""></asp:TextBox>

                <p class="error" id="ErrorMsgUsrEmail" style="visibility: hidden; padding-left: 6%; font-family: Calibri; font-size: small;margin-top: 1px;margin-left: 42%;">Please enter valid email address</p>

            </div>
            <div style="clear:both;"></div>
            <%-- division file upload --%>

            <div class="eachform" style="width: 45%; height: 50px;float:left;overflow:hidden">


                <h2 style="margin-top: 1%;">Upload Photo</h2>
                <label for="cphMain_FileUploadProPic" class="custom-file-upload" tabindex="0">
                    <img src="../../Images/Icons/cloud_upload.jpg" />Upload File</label>
                <%--<input id="file" name = "file" type="file" onchange="ClearDivDisplayImage()" accept="image/png, image/gif, image/jpeg" />--%>

                <asp:FileUpload ID="FileUploadProPic" class="fileUpload" runat="server" Style="height: 30px; display: none;" onchange="ClearDivDisplayImagepropic()" Accept="image/png, image/gif, image/jpeg" />

                <asp:Label ID="Label10" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
                <div id="divImageEdit" runat="server" style="float: right; width: 33%; height: 20px; margin-top: 0%;margin-right:4%;">
                    <div class="imgWrap">
                        <img id="Img5" src="../../Images/Icons/clear-image-green.png" alt="Clear" onclick="ClearImage()" onmouseover="ImagePosition('ClearImage','RemovePhoto');" style="cursor: pointer; float: right;" />
                        <p id="P3" class="imgDescription" style="color: white;margin-top: 2%;margin-left: 4%;">Remove Selected Photo</p>
                    </div>
                    <div id="divImageDisplaypropic" runat="server">
                    </div>
                </div>
                
            </div>

            <div class="eachform" style="float: left; width: 50%; margin-top: 1%;margin-left: 5%;height: 50px;">
                <h2 style="width: 42%;">Use this email as "From mail" while sending*</h2>
                    <%--<h2 style="margin-left: -19.8%;margin-top: 3.3%;">while sending*</h2>--%>
                <div class="subform" style="margin-left: 47.3%; margin-top: 0.3%;float:none">

                    <asp:CheckBox ID="cbxMailSendStatus" Text="Yes" runat="server" Checked="false" class="form2" />
                    <%--<h3>Active</h3>--%>
                </div>
            </div>

            <div class="eachform" style="width: 45%; margin-top: 15px;float: left;height: 30px;">
                <h2 >Status*</h2>
                <div class="subform" style="margin-left: 28.2%;">

                    <asp:CheckBox ID="cbxStatus" Text="Active" runat="server" Checked="true" class="form2" />
                    <%--<h3>Active</h3>--%>
                </div>
            </div>
            <div class="eachform " style="float: right; width: 50%;margin-top: 15px;height: 30px;">

                <h2 style="margin-top: 0%;">Read Mail From This Mail*</h2>

                <div class="subform" style="margin-left: 11.6%;">

                    <asp:CheckBox ID="cbxReadMail" Text="Yes" runat="server" Checked="false" class="form2" />
                    <%--<h3>Active</h3>--%>
                </div>

            </div>
           
                    <div class="eachform" style="float: left; width: 50%;">

                <h2 id="H2" style="margin-top: 1%;">Official Email</h2>

                <asp:TextBox ID="txtOfflMail" class="form1" runat="server" MaxLength="100" Height="30px" Width="250px" onkeypress="return isTag(event)" onblur="ReplaceTagOnBlur('cphMain_txtOfflMail');" style="height:30px;width:250px;margin-left: 17%;float: left;"></asp:TextBox>

                 <p class="error" id="ofcclMail" style="visibility: hidden; padding-left: 6%; font-family: Calibri; font-size: small;margin-top: 1px;margin-left: 29%;">Please enter valid email address</p>   <%-- emp0025--%>

            </div>

          <div class="eachform " style="float: right; width: 50%;height: 54px;">
                 <h2 style="margin-left: 0%;">Reporting To</h2>

                  <asp:DropDownList ID="ddlRepotingTo" class="form1" runat="server" Style="height:30px;width:51.5%;height:30px;width:52.5%;text-align:left;float: right;margin-left: 28.6%;"></asp:DropDownList>

                </div>
           


            <asp:UpdatePanel ID="UpdatePanelSingleCorporate" runat="server" style="width: 100%;float: left;" UpdateMode="Conditional">
                <ContentTemplate>

                        <asp:HiddenField ID="hiddendeptchng" runat="server" />
                        <asp:HiddenField ID="hiddenPrimaryDivision" runat="server" />


                    <asp:MultiView ID="mvUsrCorporate" runat="server">

                        <asp:View ID="vMultiple" runat="server">
                            <div class="eachform" style="width:100%;" >
                                <h2 style="margin-top: 1%;">Business unit</h2>
                                <div runat="server" id="mydiv" style="font-family: Calibri;">
                                    <asp:CheckBoxList ID="cbxlCorporateOffc" runat="server" CellPadding="10" class="form2"></asp:CheckBoxList>
                                </div>
                            </div>
                        </asp:View>
                        <asp:View ID="vSingle" runat="server">


                            <div class="eachform" style="width:  100%;">
                        <div class="eachform" style="width:50%;float:left;">


                                <h2 style="margin-top: 1%;">Business unit*</h2>

                                <asp:DropDownList ID="ddlUsrCorporate" runat="server" AutoPostBack="True" class="form1" OnSelectedIndexChanged="ddlUsrCorporate_SelectedIndexChanged" Width="268px" Height="30px" style="float: left;margin-left:15%;">
                                </asp:DropDownList>

                                <p class="error" id="ErrorMsgUsrCorporate" style="visibility: hidden;visibility: hidden;margin-top: 0%;padding-top: 2%;">Please select</p>
                            </div>

                            </div>

                            <div id="divDept" runat="server">
                            <div class="eachform" id="DeptDiv" style="float: right; width: 100%;">

                                <h2 style="margin-top: 1%;">Corporate Department*</h2>
                                <%--<h2 style="margin-top: 1%;">Department*</h2>--%>
                                <div id="divDpartmnt">
                                     <asp:RadioButtonList ID="rbtnCropDept" runat="server" CellPadding="10" class="form2" AutoPostBack="True" OnSelectedIndexChanged="radioCorporateDept_SelectedIndexChanged" ></asp:RadioButtonList>
                                </div>

                            </div>
                             </div>

                        </asp:View>
                    </asp:MultiView>

                     <div class="eachform " style="float: left; width: 50%;margin-top: 1%;">

                <h2 id="lblEmployeeCode" style="margin-top: 2%;">Employee Id*</h2>

                <asp:TextBox ID="txtEmployeeCode" class="form1" runat="server" MaxLength="50" Height="30px" Width="245px" Style="text-transform: uppercase;display: block;margin-right: 13%;" onblur="ReplaceTagOnBlur('cphMain_txtEmployeeCode');"></asp:TextBox>

                <p class="error" id="P4" style="visibility: hidden;margin-top: 0px;">Please enter </p>

            </div>



                    <div id="divDiv" runat="server">
                        <div class="eachform" id="CorpDiv" runat="server" style="width:  100%;margin-top:-0.5%;">
                            <h2 id="H1" runat="server" style="margin-top: 1%;">Accessible Divisions</h2>
                            <%--<h2 id="H1" runat="server" style="margin-top: 1%;">Sub Business Unit</h2>--%>
                            <div id="divDivision">



                                <asp:CheckBoxList ID="cbxlCorporateDvsn" runat="server" CellPadding="10" class="form2" onchange="cbxSelected();" ></asp:CheckBoxList>

                                 <div id="divPrimaryDivision" runat="server"></div>

                            </div>
                        </div>
                    </div>
                    <div id="bussiDiv" runat="server" style="width: 100%;float: left;" >
                      <div id="divBusi" class="eachform" style="width: 100%;" runat="server">
               <h2 style="margin-top: 1%;">Sub Business Units</h2>
                <div id="divSubBus">


                    <asp:CheckBoxList ID="cbxBussiness" runat="server" CellPadding="10" class="form2"></asp:CheckBoxList>

                </div>
            </div>
                        </div>

    

           <div class="eachform" id="divAcsBUContainer" runat="server" style="width: 100%; clear:both;">
              <h2>Accessible Business Units</h2>
                <div id="divAcsBU" runat="server">

                    <asp:CheckBoxList ID="cbxListAccsBU" runat="server">
                    </asp:CheckBoxList>


                </div>
           </div> 
            <div id="divwelfareSrevc" runat="server" style=" width: 100%; display:none ;" >
              <%-- <div id="div21" runat="server" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">--%>
                 <asp:Label ID="lblWelfareSrvc"  runat="server" Text="Welfare Services" style="font-size: 17px;  color:#909c7b; font-family: Calibri;float: left;margin-left: 0%;display:block "  ></asp:Label>
           <%-- </div>--%>

        
  
           <div id="divReport1" class="table-responsive" runat="server" style="max-height: 100px;overflow: auto;  text-align: left;  margin-left: 17.5%;font-family: Calibri;background: #eef9eb;font-weight: bold; font-size: 15px;border: 1px solid #b7b0b0;">  
            
       
        </div>
          
                 </div>
</ContentTemplate>
            </asp:UpdatePanel>
           <div id="divCompzitModules" style="display:none;">
                <h2 style="margin-top: 1%;">Compzit Modules</h2>
                <div class="subform" id="divCompzitModuleList" style="margin-left: 5.4%; width: 40%; margin-top: 1%" runat="server">

                    <asp:CheckBoxList ID="cbxlCompzitModules" runat="server" onchange=" return ClickCompzitModule();">
                    </asp:CheckBoxList>


                </div>
                <div id="divCompzitModuleNoList" runat="server" style="margin-left: 47.4%; color: #3b5113; font-family: Calibri;">
                    <asp:Label ID="Label11" runat="server" Text="No Modules Available."></asp:Label>



                </div>
           </div>
                 

                
         
         
         
           <script>
              
               function UserTree(x)
               {                  
                   //  document.getElementById("accordion-1").style.display = "none";
               
                   //  var Treeheightnow=$("#accordion-1").height();
                 
                   // $("#accordion-1").animate({display:'block'});
                   if(x=="lblAppAdmin")
                   {
                       if(document.getElementById("accordion-2").style.display=="block" ||document.getElementById("accordion-2").style.display=="")
                           $("#accordion-2").slideUp(500);
                       if(document.getElementById("accordion-3").style.display=="block" ||document.getElementById("accordion-3").style.display=="")
                           $("#accordion-3").slideUp(500);
                       if(document.getElementById("accordion-4").style.display=="block" ||document.getElementById("accordion-4").style.display=="")
                           $("#accordion-4").slideUp(500);
                       if(document.getElementById("accordion-5").style.display=="block" ||document.getElementById("accordion-5").style.display=="")
                           $("#accordion-5").slideUp(500);
                       if(document.getElementById("accordion-6").style.display=="block" ||document.getElementById("accordion-6").style.display=="")
                           $("#accordion-6").slideUp(500);
                       if(document.getElementById("accordion-7").style.display=="block" ||document.getElementById("accordion-7").style.display=="")//PMS
                           $("#accordion-7").slideUp(500);//PMS

                       if(document.getElementById("accordion-1").style.display=="none" )
                       {
                           $("#accordion-1").slideDown(500);
                       }
                       else
                       {
                           $("#accordion-1").slideUp(500);
                           //  $("#accordion-1").animate({height:'0px'});
                       }

                   }
                   else if(x=="lblSalesForse")
                   {
                       if(document.getElementById("accordion-1").style.display=="block" ||document.getElementById("accordion-1").style.display=="")
                           $("#accordion-1").slideUp(500);
                       if(document.getElementById("accordion-3").style.display=="block" ||document.getElementById("accordion-3").style.display=="")
                           $("#accordion-3").slideUp(500);
                       if(document.getElementById("accordion-4").style.display=="block" ||document.getElementById("accordion-4").style.display=="")
                           $("#accordion-4").slideUp(500);
                       if(document.getElementById("accordion-5").style.display=="block" ||document.getElementById("accordion-5").style.display=="")
                           $("#accordion-5").slideUp(500);
                       if(document.getElementById("accordion-6").style.display=="block" ||document.getElementById("accordion-6").style.display=="")
                           $("#accordion-6").slideUp(500);
                       if(document.getElementById("accordion-7").style.display=="block" ||document.getElementById("accordion-7").style.display=="")//PMS
                           $("#accordion-7").slideUp(500);//PMS

                       if(document.getElementById("accordion-2").style.display=="none" )
                       {
                           $("#accordion-2").slideDown(500);
                       }
                       else
                       {
                           $("#accordion-2").slideUp(500);
                       }
                
                   }
                   else  if(x=="lblAutoWork")
                   {
                   
                       if(document.getElementById("accordion-1").style.display=="block" ||document.getElementById("accordion-1").style.display=="")
                           $("#accordion-1").slideUp(500);
                       if(document.getElementById("accordion-2").style.display=="block" ||document.getElementById("accordion-2").style.display=="")
                           $("#accordion-2").slideUp(500);
                       if(document.getElementById("accordion-4").style.display=="block" ||document.getElementById("accordion-4").style.display=="")
                           $("#accordion-4").slideUp(500);
                       if(document.getElementById("accordion-5").style.display=="block" ||document.getElementById("accordion-5").style.display=="")
                           $("#accordion-5").slideUp(500);
                       if(document.getElementById("accordion-6").style.display=="block" ||document.getElementById("accordion-6").style.display=="")
                           $("#accordion-6").slideUp(500);
                       if(document.getElementById("accordion-7").style.display=="block" ||document.getElementById("accordion-7").style.display=="")
                           $("#accordion-7").slideUp(500);//PMS

                       if(document.getElementById("accordion-3").style.display=="none" )
                       {
                           $("#accordion-3").slideDown(500);
                       }
                       else
                       {
                           $("#accordion-3").slideUp(500);
                       }
                     
                   }
                   else if(x=="lblGurantMang")
                   {
                       if(document.getElementById("accordion-1").style.display=="block" ||document.getElementById("accordion-1").style.display=="")
                           $("#accordion-1").slideUp(500);
                       if(document.getElementById("accordion-2").style.display=="block" ||document.getElementById("accordion-2").style.display=="")
                           $("#accordion-2").slideUp(500);
                       if(document.getElementById("accordion-3").style.display=="block" ||document.getElementById("accordion-3").style.display=="")
                           $("#accordion-3").slideUp(500);
                       if(document.getElementById("accordion-5").style.display=="block" ||document.getElementById("accordion-5").style.display=="")
                           $("#accordion-5").slideUp(500);
                       if(document.getElementById("accordion-6").style.display=="block" ||document.getElementById("accordion-6").style.display=="")
                           $("#accordion-6").slideUp(500);
                       if(document.getElementById("accordion-7").style.display=="block" ||document.getElementById("accordion-7").style.display=="")
                           $("#accordion-7").slideUp(500);//PMS

                       if(document.getElementById("accordion-4").style.display=="none" )
                       {
                           $("#accordion-4").slideDown(500);
                       }
                       else
                       {
                           $("#accordion-4").slideUp(500);
                       }
                     
                   }
                   else if(x=="lblHuman")
                   {
                       if(document.getElementById("accordion-1").style.display=="block" ||document.getElementById("accordion-1").style.display=="")
                           $("#accordion-1").slideUp(500);
                       if(document.getElementById("accordion-2").style.display=="block" ||document.getElementById("accordion-2").style.display=="")
                           $("#accordion-2").slideUp(500);
                       if(document.getElementById("accordion-3").style.display=="block" ||document.getElementById("accordion-3").style.display=="")
                           $("#accordion-3").slideUp(500);
                       if(document.getElementById("accordion-4").style.display=="block" ||document.getElementById("accordion-4").style.display=="")
                           $("#accordion-4").slideUp(500);
                       if(document.getElementById("accordion-6").style.display=="block" ||document.getElementById("accordion-6").style.display=="")
                           $("#accordion-6").slideUp(500);
                       if(document.getElementById("accordion-7").style.display=="block" ||document.getElementById("accordion-7").style.display=="")
                           $("#accordion-7").slideUp(500);//PMS

                       if(document.getElementById("accordion-5").style.display=="none" )
                       {
                           $("#accordion-5").slideDown(500);
                       }
                       else
                       {
                           $("#accordion-5").slideUp(500);
                       }
                     
                   }
                   else if(x=="lblFinance")
                   {
                       if(document.getElementById("accordion-1").style.display=="block" ||document.getElementById("accordion-1").style.display=="")
                           $("#accordion-1").slideUp(500);
                       if(document.getElementById("accordion-2").style.display=="block" ||document.getElementById("accordion-2").style.display=="")
                           $("#accordion-2").slideUp(500);
                       if(document.getElementById("accordion-3").style.display=="block" ||document.getElementById("accordion-3").style.display=="")
                           $("#accordion-3").slideUp(500);
                       if(document.getElementById("accordion-4").style.display=="block" ||document.getElementById("accordion-4").style.display=="")
                           $("#accordion-4").slideUp(500);
                       if(document.getElementById("accordion-5").style.display=="block" ||document.getElementById("accordion-5").style.display=="")
                           $("#accordion-5").slideUp(500);
                       if(document.getElementById("accordion-7").style.display=="block" ||document.getElementById("accordion-7").style.display=="")
                           $("#accordion-7").slideUp(500);//PMS

                       if(document.getElementById("accordion-6").style.display=="none" )
                       {
                           $("#accordion-6").slideDown(500);
                       }
                       else
                       {
                           $("#accordion-6").slideUp(500);
                       }

                   }
                   else if(x=="lblProcurmnt")//PMS
                   {
                       if(document.getElementById("accordion-1").style.display=="block" ||document.getElementById("accordion-1").style.display=="")
                           $("#accordion-1").slideUp(500);
                       if(document.getElementById("accordion-2").style.display=="block" ||document.getElementById("accordion-2").style.display=="")
                           $("#accordion-2").slideUp(500);
                       if(document.getElementById("accordion-3").style.display=="block" ||document.getElementById("accordion-3").style.display=="")
                           $("#accordion-3").slideUp(500);
                       if(document.getElementById("accordion-4").style.display=="block" ||document.getElementById("accordion-4").style.display=="")
                           $("#accordion-4").slideUp(500);
                       if(document.getElementById("accordion-5").style.display=="block" ||document.getElementById("accordion-5").style.display=="")
                           $("#accordion-5").slideUp(500);
                       if(document.getElementById("accordion-6").style.display=="block" ||document.getElementById("accordion-6").style.display=="")
                           $("#accordion-6").slideUp(500);

                       if(document.getElementById("accordion-7").style.display=="none" )
                       {
                           $("#accordion-7").slideDown(500);
                       }
                       else
                       {
                           $("#accordion-7").slideUp(500);
                       }
                   }

               }
           </script>
     
            <h2 style="font-size: 17px;float: right;margin-right: 85%;">Select the User role *</h2>
            <div id="divTtree"  class="eachform" style="width:  100%;">



                <div class="accordion" style="font-family: Calibri;">

                    <div class="accordion-section" id="divAccordionAppAdmin" style="display:none;">
                        <label id="lblAppAdmin"  onclick="return UserTree('lblAppAdmin')"><a href="#" class="accordion-section-title" onclick="return false;">APP ADMINISTRATION</a></label>
                        <div id="accordion-1" style="display:none" >
                            <div id="divCompzit_AppAdminstration" runat="server"  >
                                <div>
                                    <div>
                                        <div>
                                            <div>
                                                <div>

                                                    <%--<h1>ONLINE</h1>--%>     
                                                    <asp:TreeView ID="TreeViewCompzit_AppAdminstration" runat="server"
                                                        ShowCheckBoxes="All" ExpandDepth="0" CssClass="MyTreeView" Target="_self">
                                                    </asp:TreeView>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                        <!--end .accordion-section-content-->
                    </div>
                    <!--end .accordion-section-->

                    <div class="accordion-section" id="divAccordionSFA" style="display:none;">
                        <label id="lblSalesForse"  onclick="return UserTree('lblSalesForse')"><a href="#" class="accordion-section-title" onclick="return false;">SALES FORCE AUTOMATION</a></label>
                        <div id="accordion-2" style="display:none" >
                            <div id="divAccordionCompzit_SalesAutomation" runat="server">
                                <div>
                                    <div>

                                        <%--<h1>ONLINE</h1>--%>      
                                        <asp:TreeView ID="TreeViewCompzit_SalesAutomation" runat="server"
                                            ShowCheckBoxes="All" ExpandDepth="0" CssClass="MyTreeView">
                                        </asp:TreeView>

                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                        <!--end .accordion-section-content-->
                    </div>
                    <!--end .accordion-section-->

                    <div class="accordion-section" id="divAccordionAWMS" style="display:none;">
                        <label id="lblAutoWork"  onclick="return UserTree('lblAutoWork')"><a href="#" class="accordion-section-title" onclick="return false;">AUTO WORKSHOP MANAGEMENT SYSTEM</a></label>
                        <div id="accordion-3"  style="display:none">
                            <div id="divAccordionCompzit_AutoWorkshopManagement" runat="server">
                                <div>
                                    <div>
                                                   
                                        <%--<h1>ONLINE</h1>--%>
                                        <asp:TreeView ID="TreeViewCompzit_AutoWorkshopManagement" runat="server"
                                            ShowCheckBoxes="All" ExpandDepth="0" CssClass="MyTreeView">
                                        </asp:TreeView>

                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                        <!--end .accordion-section-content-->
                    </div>

                    <div class="accordion-section" id="divAccordionGMS" style="display:none;">
                        <label id="lblGurantMang"  onclick="return UserTree('lblGurantMang')"><a href="#" class="accordion-section-title" onclick="return false;">GUARANTEE MANAGEMENT SYSTEM</a></label>
                        <div id="accordion-4"  style="display:none">
                            <div id="divAccordionCompzit_GuaranteeManagement" runat="server">
                                <div>
                                    <div>
                                                   
                                        <%--<h1>ONLINE</h1>--%>
                                        <asp:TreeView ID="TreeViewCompzit_GuaranteeManagement" runat="server"
                                            ShowCheckBoxes="All" ExpandDepth="0" CssClass="MyTreeView">
                                        </asp:TreeView>

                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                        <!--end .accordion-section-content-->
                    </div>

                    <div class="accordion-section" id="divAccordionHCM" style="display:none;">
                        <label id="lblHuman"  onclick="return UserTree('lblHuman')"><a href="#" class="accordion-section-title" onclick="return false;">HUMAN CAPITAL MANAGEMENT</a></label>
                        <div id="accordion-5" style="display:none">
                            <div id="divAccordionCompzit_HumanCapitalManagement" runat="server">
                                <div>
                                    <div>
                                                    
                                        <%--<h1>ONLINE</h1>--%>
                                        <asp:TreeView ID="TreeViewCompzit_HumanCapitalManagement" runat="server"
                                            ShowCheckBoxes="All" ExpandDepth="0" CssClass="MyTreeView">
                                        </asp:TreeView>

                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                        <!--end .accordion-section-content-->
                    </div>

                    <div class="accordion-section" id="divAccordionFMS" style="display:none;">
                        <label id="lblFinance"  onclick="return UserTree('lblFinance')"><a href="#" class="accordion-section-title" onclick="return false;">FINANCE MANAGEMENT SYSTEM</a></label>
                        <div id="accordion-6" style="display:none">
                            <div id="divAccordionCompzit_FinanceManagementSystem" runat="server">
                                <div>
                                    <div>
                                                    
                                        <%--<h1>ONLINE</h1>--%>
                                        <asp:TreeView ID="TreeViewCompzit_FinanceManagementSystem" runat="server"
                                            ShowCheckBoxes="All" ExpandDepth="0" CssClass="MyTreeView">
                                        </asp:TreeView>

                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                        <!--end .accordion-section-content-->
                    </div>
                    

                   <div class="accordion-section" id="divAccordionPMS" style="display:none;">
                        <label id="lblProcurmnt"  onclick="return UserTree('lblProcurmnt')"><a href="#" class="accordion-section-title" onclick="return false;">PROCUREMENT MANAGEMENT SYSTEM</a></label>
                        <div id="accordion-7" style="display:none">
                            <div id="divAccordionCompzit_ProcurementManagementSystem" runat="server">
                                <div>
                                    <div>
                                                    
                                        <%--<h1>ONLINE</h1>--%>
                                        <asp:TreeView ID="TreeViewCompzit_ProcurementManagementSystem" runat="server"
                                            ShowCheckBoxes="All" ExpandDepth="0" CssClass="MyTreeView">
                                        </asp:TreeView>

                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                        <!--end .accordion-section-content-->
                    </div>





                   <!--end .accordion-section-->
                </div>
                <!--end .accordion-->

               
              


            </div>
         
                                                     </ContentTemplate>
   </asp:UpdatePanel>
            <br />
 
            
            <script type="text/javascript">
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
                function EndRequestHandler(sender, args) {
                    if (args.get_error() == undefined) {
                        $(function () {
                            //Your script
                        });
                    }
                }
    </script>
         
            
    <div id="divLoginDetailsSection" runat="server" style="border: 1px solid #cad1be; padding: 1% 2% 3% 2%; margin-top: 0%;">

                <div id="divLoginDetailsHeader" style="width: 100%; float: left;">

                    <asp:CheckBox ID="cbxMustLogin" Text="Login Details" runat="server" Checked="false" class="caption" onclick="ShowHideDiv('cphMain_cbxMustLogin')" />

                </div>

                <div id="divLoginDetailsContent" style="display: none;">

                    <div class="eachform " style="width: 45%;">

                        <h2 style="margin-top: 2%;">Login Name*</h2>

                        <asp:TextBox ID="txtLoginName" class="form1" runat="server" MaxLength="100" Height="30px" Width="250px"  onblur="ReplaceTagAndAtOnBlur('cphMain_txtLoginName');"></asp:TextBox>

                        <p id="P5" style="visibility: hidden;color: red;font-size: small;">Please enter </p>

                    </div>

                    <%-- //005 start--%>

                    <div class="eachform" style="float: right; width: 50%;">

                        <div class="subform" style="margin-left: 42.8%; margin-top: -0.7%">

                            <asp:CheckBox ID="cbxLimitedUser" Text="Limited User" runat="server" Checked="true" class="form2" />
                            <asp:CheckBox ID="cbxPswExpiry" Text="Enforce Password Expiration" runat="server" Checked="true" class="form2" />
                            <%--<h3>Active</h3>--%>
                            <%--<p style="visibility: hidden">Please enter</p>--%>
                        </div>

                    </div>

                    <div id="divPassword" runat="server" class="eachform" style="width: 45%;">
                        <h2 style="margin-top: 2%;">Password*</h2>

                        <asp:TextBox ID="txtUsrPwd" class="form1" runat="server" MaxLength="16" Height="30px" Width="250px" oncopy="return false" TextMode="Password" onblur="ReplaceTagOnBlur('cphMain_txtUsrPwd');"></asp:TextBox>

                        <div class='form-tooltip'>Password Must Contain 6-16 Characters with atleast one number, special character & alphabet</div>
                        <p id="PwdMsg" style="visibility: hidden; font-family: Calibri;color: red;font-size: small;"></p>
                    </div>

                    <div id="divCPassword" runat="server" class="eachform" style="float: right; width: 50%; margin-top: 1%;">

                        <h2 style="margin-top: 2%;">Confirm Password*</h2>

                        <asp:TextBox ID="txtUsrConPwd" class="form1" runat="server" MaxLength="16" Height="30px" onPaste="return false" Width="258px" TextMode="Password" onblur="ReplaceTagOnBlur('cphMain_txtUsrConPwd');"></asp:TextBox>

                        <p id="ErrorMsgUsrConPwd" style="visibility: hidden; padding-left: 6%; font-family: Calibri; font-size: small;color: red;font-size: small;">Both passwords must be equal</p>

                    </div>
                    <div class="eachform" style="" id="divShowPassword" runat="server">
                        <h2 style="margin-left: 35.4%;"></h2>
                        <div style="font-family: Calibri; color: #697259;">
                            <asp:CheckBox ID="cbxPswdVisible" Text="Show Password" runat="server" class="form2" onchange="return onChanging();" />
                        </div>
                    </div>

                </div>

            </div>

            <div id="divAutoWorkshopSection" runat="server" style="border: 1px solid #cad1be; padding: 1% 2% 3% 2%; margin-top: 2%;">

                <div id="divAutoWorkshopHeader" style="width: 100%; float: left;">

                    <asp:CheckBox ID="cbxMustAutoWorkshop" Text="Auto Workshop Related Information" runat="server" Checked="false" class="caption" onclick="ShowHideDiv('cphMain_cbxMustAutoWorkshop');" />

                </div>

                <div id="divAutoWorkshopContent" style="display: none;">

                    <div class="eachform " style="width: 45%;">

                        <h2 style="margin-top: 2%;">Driving License No.*</h2>

                        <asp:TextBox ID="txtLicenceNumbr" class="form1" runat="server" MaxLength="100" Height="30px" Width="250px" Style="text-transform: uppercase" onblur="ReplaceTagOnBlur('cphMain_txtLicenceNumbr');"></asp:TextBox>

                        <p  id="P6" style="visibility: hidden;color: red;font-size: small;">Please enter </p>

                    </div>


                    <div class="eachform " style="float: right; width: 50%;">

                        <h2 style="margin-top: 1%;">License Expiry Date*</h2>

                        <div id="dateLicenseExpDate" class="input-append date" style="float: right;">
                            <asp:TextBox ID="txtLicenseExpDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="218px" Style="margin-top: 0%; float: left" onkeypress="return DisableEnter(event);"></asp:TextBox>

                            <img class="add-on" src="../../../Images/Icons/CalandarIcon.png" style="height: 22px; width: 22px; cursor: pointer;margin-top:0%" />

                            <script type="text/javascript"
                                src="../../JavaScript/Date/JavaScriptDate1_8_3.js">
                            </script>
                            <script type="text/javascript"
                                src="../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                            </script>
                            <script type="text/javascript"
                                src="../../JavaScript/Date/bootstrap-datepicker.js">
                            </script>
                            <script type="text/javascript"
                                src="../../JavaScript/Date/bootstrap-datepicker_pt_br.js">
                            </script>
                            <script type="text/javascript">
                                var $noC = jQuery.noConflict();
                                $noC('#dateLicenseExpDate').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false
                                    // startDate: new Date(),
                                });

                            </script>




                            <p style="visibility: hidden">Please enter</p>
                        </div>

                    </div>
                    <asp:UpdatePanel ID="UpdatePanelAutoWorkShopAccommodation" runat="server" style="margin-top: 2%;">
                        <ContentTemplate>
                            <div class="eachform" style="width: 45%;display:none;">
                                <h2 style="margin-top: 1%;">Accommodation</h2>

                                <asp:DropDownList ID="ddlAccommodatn" Width="268px" class="form1" runat="server" Height="30px"></asp:DropDownList>
                                <p style="visibility: hidden">Please enter</p>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="eachform" style="float: right; width: 50%;margin-top: 0%;">
                        <h2>Allow Duty Roster*</h2>
                        <div class="subform" style="margin-left: 17.5%;">

                            <asp:CheckBox ID="cbxDutyRoster" Text="Yes" runat="server" Checked="false" class="form2" />
                            <%--<h3>Active</h3>--%>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanelAutoWorkShop" runat="server" style="margin-top: 2%;">
                        <ContentTemplate>

                            <div class="eachform" style="width: 48%; margin-top: 0px;">
                                <h2 style="margin-top: 1%;">Upload License Copy*</h2>
                                <label for="cphMain_FileUploadLicenseCopy" class="custom-file-upload" tabindex="0" style="margin-left: 3.8%;">
                                    <img src="../../Images/Icons/cloud_upload.jpg" />Upload File</label>
                                <%--<input id="file" name = "file" type="file" onchange="ClearDivDisplayImage()" accept="image/png, image/gif, image/jpeg" />--%>

                                <asp:FileUpload ID="FileUploadLicenseCopy" class="fileUpload" runat="server" Style="height: 30px; display: none;" onchange="ClearDivDisplayLicenseCopy()" />


                                <div id="divLicenseEdit" runat="server" style="float: right; width: 54%; height: 20px; margin-top: 1%;margin-right:11%;">
                                    <div class="imgWrap">
                                        <img id="ClearLicenseCopy" src="../../Images/Icons/clear-image-green.png" alt="Clear" onclick="ClearLicenseCopy()" onmouseover="ImagePosition('ClearLicenseCopy','RemoveLicenseCopy');" style="cursor: pointer; float: right;" />
                                        <p id="RemoveLicenseCopy" class="imgDescription" style="color: white; margin-left: 0%; margin-top: 0%;">Remove Selected License Copy</p>
                                    </div>
                                    <div id="divLicenseCopyDisplay" runat="server">
                                    </div>
                                </div>
                                <asp:Label ID="lblLicenseCopy" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>


                            </div>


                            <div id="divLicenseTypeContainer" class="eachform" style="width: 100%; height: 163px; min-height: 85px; margin-top: 0%;">
                                <h2 style="margin-top: 1%;">Select License Type* </h2>
                                <%--<label id="lblLicenseType">Select Vehicle Class* </label>--%>
                                <div class="subform" style="margin-left: 2.5%;" id="divLicenseType" runat="server">
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>





            <br />

            <div class="eachform"style="width:  94%;">
                <div class="subform" style="width: 38%;">


                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_ClickUsrRegistr" OnClientClick="return BssicInfoValidation(1); " />
                    <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClick="btnUpdate_ClickUsrRegistr" OnClientClick="return BssicInfoValidation(1); " />
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClientClick="return BssicInfoValidation(0); " OnClick="btnAdd_ClickUsrRegistr" />
                    <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClientClick="return BssicInfoValidation(0); " OnClick="btnAdd_ClickUsrRegistr" />
                    <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" PostBackUrl="~/Master/gen_Emply_Personal_Informn/gen_Emp_Personal_Info_List.aspx" />
                      <asp:Button ID="btnCancelCan" runat="server" class="cancel" Text="Cancel" PostBackUrl="~/Hcm/Hcm_Master/hcm_OnBoarding/gen_Candidate_Registration/gen_Candidate_Personal_Info_List.aspx" />
                    <%--<asp:Button ID="Button1" runat="server" class="cancel" Text="test" OnClientClick="return testLicenseType();" />--%>
                </div>
            </div>

                <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezlyr">
                    </div>


          <div id="ModelCnclView" class="modalCancelView" > <%-- emp0025--%>
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCncllView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <asp:Label ID="lblServiceName" runat="server"></asp:Label>
                        <div id="divSeviceName" runat="server" style="margin-left: 43%;"></div>
                     <%--   <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; ">Welfare Service</h3>--%>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divError"  style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblError" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                      
                       
                    

                           <div id="divReportTable" class="table-responsive" runat="server">  
            <br />
            <br />
            <br />
            <br />
            <br />
           
          
        </div>



                   
                         <asp:Button ID="btnWelfr" class="save" runat="server" Text="Save" OnClientClick="return validateWelfare();" OnClick="btnRenSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;"/>
                    
                   <%-- <asp:Button ID="Button2" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%; " onclientclick="CloseCncllView();" runat="server" Text="Close" />--%>
                        <input type="button" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%; " onclick="CloseCncllView();" value="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div> 


            <div style="float: right;" align="right">
                <a href="javascript:;" id="scrollToTop" title="Goto Top">&#x25B2;</a>
            </div>
            <!-- The Modal Loading MAIL -->
            <div id="myModalLoadingMail" class="modalLoadingMail">

                <!-- Modal content -->
                <div>

                    <img src="../../Images/Other Images/LoadingMail.gif" style="width: 12%;" />


                </div>

            </div>


     
            <%--test modal stop--%>
        </div>

    </div>

    </div>
       </div>
           
            </div>

        <style>
            input[type="radio"] {
                display: inline;
            }
        </style>
    


    <link href="../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" media="screen"
        href="../../css/Date/StyleSheetDate.css" />
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
        var confirmbox = 0;
        
        function IncrmntConfrmCounter() {

            confirmbox++;    
        }

        function IncrmntConfrmCounter(count) {
       
            confirmbox++;
            document.getElementById("<%=hiddenRowCount.ClientID%>").value=count;
            
        }
        function ConfirmMessage() {
            //alert(confirmboxother);
            if (confirmboxother > 0)     
            {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href="gen_Emp_Personal_Info_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
           
            
           
            else   if (confirmboxjob > 0)     
            {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href="gen_Emp_Personal_Info_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
           
            
            



            else     if (confirmbox > 0)     
            {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href="gen_Emp_Personal_Info_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
           
            
         
            
            else   if (confirmboxWrkExp > 0)     
            {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href="gen_Emp_Personal_Info_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
           
            
           
            else     if (confirmboxEdu > 0)     
            {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href="gen_Emp_Personal_Info_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
           
            
          
            else    if (confirmboxLang > 0)     
            {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href="gen_Emp_Personal_Info_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
           
            
          
            else    if (confirmboxSklCer > 0)     
            {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href="gen_Emp_Personal_Info_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
           
            
          
                // alert(confirmboxImig+"ss");
            else   if (confirmboxImig >0)     
            {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href="gen_Emp_Personal_Info_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
           
            else   if (confirmboxSalryPaygrd >0)     
            {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href="gen_Emp_Personal_Info_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else   if (confirmboxSalryAllwnce >0)     
            {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href="gen_Emp_Personal_Info_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else   if (confirmboxSalryDedctn >0)     
            {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href="gen_Emp_Personal_Info_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
           
            else
            {
                window.location.href="gen_Emp_Personal_Info_List.aspx";
                return false;
            }
        }
        
        function CancelSalary(){
            if(confirmboxSalryPaygrd >0)     
            {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href="gen_Emp_Personal_Info_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else
                window.location.href="gen_Emp_Personal_Info_List.aspx";
            return false;
        
        }


        //stop-0006
    </script>
    <%-- for file upload css --%>
    <style>
        #scrollToTop {
            cursor: pointer;
            background-color: #97c83a;
            display: inline-block;
            height: 40px;
            width: 40px;
            color: #fff;
            font-size: 16pt;
            text-align: center;
            text-decoration: none;
            line-height: 40px;
            border-radius: 35px;
        }

        .dropdown-menu {
            z-index: 100;
        }
        /*005 start*/
        .modalLoadingMail {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 30; /* Sit on top */
            padding-top: 19%; /* Location of the box */
            left: 0;
            top: 0;
            width: 90%; /* Full width */
            /*height: 58%;*/ /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: transparent;
            padding-left: 45%; /* Location of the box */
        }
        /*for file upload*/
        /*input[type="file"] {*/
        .fileUpload {
            margin-left: -17%;
            position: relative;
            z-index: 1;
        }

        .custom-file-upload {
            margin-left: 18%;
            border: 1px solid #ccc;
            display: inline-block;
            padding: 2px 4px;
            cursor: pointer;
            position: relative;
            z-index: 2;
            font-family: Calibri;
            background: white;
        }
        /*//0013*/
        #cphMain_divCheckBox label {
            /*float: right;*/
            margin-bottom: 0px;
            color: #16682a;
            font-family: Calibri;
            font-size: 15px;
        }

            #cphMain_divCheckBox label.hover {
                color: #1acc45;
            }

        #cphMain_divCheckBox input[type="checkbox"] {
            float: left;
            margin: 3px 8px 3px 3px;
        }

        .eachform h2 {
            margin: 6px 0 6px;
        }

        #divCheckBox {
            float: right;
            width: 53%;
            max-height: 100px;
            overflow: auto;
            border: 1px solid;
            border-color: #90a8b0;
            background-color: #f9f9f9;
            overflow-x: auto;
            white-space: nowrap;
        }
    </style>
     <link href="../../css/Accordiondemo.css" type="text/css" rel="stylesheet" />
    <script src="../../JavaScript/jquery1.11.1_min.js"></script>
    <%--	<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>--%>

    <script src="../../JavaScript/accordion/accordion.js"></script>
    <%--for image delete description position--%>
    <script>
        function ImagePosition(object,obj2)
        {
            var $Mo = jQuery.noConflict();
            
            var offset = $Mo("#" + object).offset();
           
            var posY = 0;
            var posX = 0;
            posY = offset.top;
            
            posX = offset.left

            if(object=='ClearImage')
            {
                posX = 7.1;
            }
            else if (object=='ClearLicenseCopy')
            {
                posX = 47;
            }
            var d = document.getElementById(obj2);
            d.style.position = "absolute";
            d.style.left = posX + '%';
            if(object=='ClearImage')
            {
                d.style.top = posY -52 +'px';
            } 
            else if (object=='ClearLicenseCopy')
            {
                d.style.top = posY +27 +'px';
            }
        }

    </script>

    <%-- for show password  --%>
    <script>

        // var labelForStyle = '<label for="file' + counter + '" class="custom-file-upload" > <img src="../../Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
        //  div.innerHTML = labelForStyle+'<input  id="file' + counter + '" name = "file' + counter +

        //                 '" type="file" />';


        function alertJobRolChange(){
           
          
            if (confirm("Are You Sure You Want To Change The Job Role?")) {
                return true;
            }
            else {
                   
                return false;
            }
           
           
        }
        function onChanging(){
            
            IncrmntConfrmCounter();
            if(document.getElementById("<%= cbxPswdVisible.ClientID %>").checked  == true)
            {
                document.getElementById("<%= txtUsrPwd.ClientID %>").type = 'text';
                document.getElementById("<%= txtUsrConPwd.ClientID %>").type = 'text';
                 
            }
            else
            {  document.getElementById("<%= txtUsrPwd.ClientID %>").type = 'password';
                document.getElementById("<%= txtUsrConPwd.ClientID %>").type = 'password';
                 
            }
            return false;
        }
    </script>
  

  
    

    
    <%--005 start--%>
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">


        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {                        
           var joindate= document.getElementById("<%=txtJoineddate.ClientID%>").value.trim();
           document.getElementById("<%=hiddenJoiningDateOnPageLoad.ClientID%>").value = joindate;
           
            document.getElementById("<%=hiddendeptchng.ClientID%>").value ="";

            if(document.getElementById("<%=hiddenPrimaryDivision.ClientID%>").value!=""){

                var PrimaryDivsn=document.getElementById("<%=hiddenPrimaryDivision.ClientID%>").value;
                checkRadioPrimary(PrimaryDivsn);
                //EVM-0027
              
                //END
            }
          
            // Run code
            //   alert('loaded statr'); 
            //22/02 evm-0024
           
            document.getElementById("freezlyr").style.display = "none";
            document.getElementById("ModelCnclView").style.display = "none";
         //   document.getElementById("cphMain_divwelfareSrevc").style.display = "block";
            if(  document.getElementById("<%=HiddenRPStatus.ClientID%>").value=="1")
            {

                $('#cphMain_RadioButtonDocList_1').prop('disabled',true);
                $('#cphMain_RadioButtonDocList_2').prop('disabled',false);

            }
            //end

          
            if(  document.getElementById("<%=HiddenPayGrdeId.ClientID%>").value=="")
            {
                RadioPerClick() ;
            }
            if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {
             
                IncrmntConfrmCounter();
            }
            var FramewrkId = '<%= Session["FRMWRK_ID"] %>';
            var FramewrkTyp = '<%= Session["FRMWRK_TYPE"] %>';
            if (FramewrkTyp == "1" && FramewrkId != "" && FramewrkId != null) {
                document.getElementById('divAccordionAppAdmin').style.display = "";
                document.getElementById('accordion-1').style.display = "block";
                document.getElementById('cphMain_cbxlCompzitModules_0').checked = true;
                document.getElementById('cphMain_cbxlCompzitModules_1').checked = false;
                document.getElementById('cphMain_cbxlCompzitModules_2').checked = false;
                document.getElementById('cphMain_cbxlCompzitModules_3').checked = false;
                document.getElementById('cphMain_cbxlCompzitModules_4').checked = false;
                document.getElementById('cphMain_cbxlCompzitModules_5').checked = false;
                document.getElementById('divCompzitModules').style.display = "none";
                $("#lblAppAdmin").hide();
                if (document.getElementById("<%=ddlUsrDsgn.ClientID%>").value == "--SELECT--" || document.getElementById("<%=ddlJobRole.ClientID%>").value == "--Select Job Role--") {
                    document.getElementById('accordion-1').style.display = "none";
                }               
            }
            else {
                document.getElementById('divCompzitModules').style.display = "block";

                var CHK = document.getElementById("<%=cbxlCompzitModules.ClientID%>");

                var checkbox = CHK.getElementsByTagName("input");

                var label = CHK.getElementsByTagName("label");

                for (var i = 0; i < checkbox.length; i++) {

                    if (checkbox[i].checked) {
                    
                        //  alert("Selected = " + checkbox[i].value);
                        if (checkbox[i].value.toString() == '1')//IF APP ADMINISTRATION
                        {
                            document.getElementById('divAccordionAppAdmin').style.display = "";
                        }
                        else if (checkbox[i].value.toString() == '2')//IF SALES FORCE AUTOMATION 
                        {
                            document.getElementById('divAccordionSFA').style.display = "";
                        }
                        else if (checkbox[i].value.toString() == '3')//IF AUTO WORKSHOP MANAGEMENT
                        {
                            document.getElementById('divAccordionAWMS').style.display = "";
                        }
                        else if (checkbox[i].value.toString() == '4')//IF GUARANTEE MANAGEMENT
                        {
                            document.getElementById('divAccordionGMS').style.display = "";
                        }
                        else if (checkbox[i].value.toString() == '5')//IF HUMAN CAPITAL MANAGEMENT
                        {
                            document.getElementById('divAccordionHCM').style.display = "";
                        }
                        else if (checkbox[i].value.toString() == '6')//IF FINANCE MANAGEMENT
                        {
                            document.getElementById('divAccordionFMS').style.display = "";
                        }
                        else if (checkbox[i].value.toString() == '7')//IF PROCUREMENT MANAGEMENT//PMS
                        {
                            document.getElementById('divAccordionPMS').style.display = "";
                        }


                    }

                }
            }
            document.getElementById("myModalLoadingMail").style.display = "none";
            
            document.getElementById("freezelayer").style.display = "none";

          
            // alert(document.getElementById("<%=divLoginDetailsSection.ClientID%>").innerHTML);
            if(document.getElementById("<%=divLoginDetailsSection.ClientID%>").style.display!="none" )
            {
                if(document.getElementById("<%=cbxMustLogin.ClientID%>").checked)
                {
                    document.getElementById('divLoginDetailsContent').style.display = "block";
                    document.getElementById('lblEmployeeCode').innerText="Employee Id*";
                    document.getElementById('lblEmail').innerText="Email*";
                }
                else
                {
                   
                    document.getElementById('divLoginDetailsContent').style.display = "none";
                    //  document.getElementById('lblEmployeeCode').innerText="Employee Code";
                    document.getElementById('lblEmployeeCode').innerText="Employee Id*";
                    document.getElementById('lblEmail').innerText="Email";
                
                }
            
            }
            if(document.getElementById("<%=divAutoWorkshopSection.ClientID%>").style.display!="none")
            {
                if(document.getElementById("<%=cbxMustAutoWorkshop.ClientID%>").checked)
                {
                    document.getElementById('divAutoWorkshopContent').style.display = "block";
                }
                else
                { 
                    document.getElementById('divAutoWorkshopContent').style.display = "none";
                
                }
                var LicenseTypeSlctdValues=document.getElementById("<%=hiddenLicenseTypeId.ClientID%>").value;
                if(LicenseTypeSlctdValues!="")
                {
                    var LicTypes = LicenseTypeSlctdValues.split(",");
                    //  alert('bla' +PreviousSlctdValues);
                    //    alert(LicTypes.length);
                    for (i = 0; i < LicTypes.length; i++) {
                        if(LicTypes[i].toString() !="")
                        {
                            if( document.getElementById("divImageLicenseType-" + LicTypes[i]))
                            {
                                document.getElementById("divImageLicenseType-" + LicTypes[i]).style.border = ".5px solid";
                                document.getElementById("divImageLicenseType-" + LicTypes[i]).style.backgroundColor = "rgb(56, 255, 128)";              
                
                            }

                        }
                    }
                }
            }
            //  alert('load end');

            //emp-0043 start
            paymentClick();
        });
    </script>
              <script>
                  function EmployeeConfirmation() {
                      document.getElementById('divMessageAreaMain').style.display = "block";
                      document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaInfo.png";
                      document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Employee Details Inserted Successfully.";
                      tableClick('divTblid8', cphMain_Tblid8);
                  }
                  function EmployeeDep() {
                      document.getElementById('divMessageAreaMain').style.display = "block";
                      document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                      document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Please Select One Department.";
                      tableClick('divTblid8', cphMain_Tblid8);
                  }
                  function EmployeeUpdation() {
                      document.getElementById('divMessageAreaMain').style.display = "block";
                      document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaInfo.png";
                      document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Employee Details Updated Successfully.";
                      tableClick('divTblid8', cphMain_Tblid8);
                  }
                  function MailsendFail() {
                      document.getElementById('divMessageAreaMain').style.display = "block";
                      document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaInfo.png";
                      document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Employee Details Inserted Successfully.The Mail Sending To Employee Failed.";
                      tableClick('divTblid8', cphMain_Tblid8);
                  }
                  function MailsendFailReviewMailStng() {
                      document.getElementById('divMessageAreaMain').style.display = "block";
                      document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaInfo.png";
                      document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Employee Details Inserted Successfully. Review Your Mail Settings For Sending Mail.";
                      tableClick('divTblid8', cphMain_Tblid8);
                }



            </script>
    <script type="text/javascript">

        //Start:-Empcode
        function EmpRefChange(NewCode) {

            var oldCode= document.getElementById("cphMain_txtEmployeeCode").value;
            if(NewCode!=oldCode && oldCode!=""){
                if (confirm("Are you sure you want to change the employee id?")) 
                {

                    if(NewCode==undefined )
                    {
                        NewCode="";
                    }
                    document.getElementById("cphMain_txtEmployeeCode").value= NewCode;
                }
            }
        }
        function PartialLoad(NewCode) {

            var oldCode= document.getElementById("cphMain_txtEmployeeCode").value;
            if(NewCode!=undefined && NewCode!="" && NewCode!=oldCode){
                if (confirm("Are you sure you want to change the employee id?")) {
                    document.getElementById("cphMain_txtEmployeeCode").value= NewCode;
                }
            }
           
            //End:-Empcode

            document.getElementById("<%=hiddenLicenseTypeId.ClientID%>").value="";
            if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {
             
                IncrmntConfrmCounter();
            }

            document.getElementById("myModalLoadingMail").style.display = "none";
            
            document.getElementById("freezelayer").style.display = "none";

          
            // alert(document.getElementById("<%=divLoginDetailsSection.ClientID%>").innerHTML);
            if(document.getElementById("<%=divLoginDetailsSection.ClientID%>").style.display!="none" )
            {
                if(document.getElementById("<%=cbxMustLogin.ClientID%>").checked)
                {
                    document.getElementById('divLoginDetailsContent').style.display = "block";
                    document.getElementById('lblEmployeeCode').innerText="Employee Id*";
                    document.getElementById('lblEmail').innerText="Email*";
                }
                else
                {
                   
                    document.getElementById('divLoginDetailsContent').style.display = "none";
                    document.getElementById('lblEmployeeCode').innerText="Employee Id*";
                    document.getElementById('lblEmail').innerText="Email";
                
                }
            
            }
            if(document.getElementById("<%=divAutoWorkshopSection.ClientID%>").style.display!="none")
            {
                if(document.getElementById("<%=cbxMustAutoWorkshop.ClientID%>").checked)
                {
                    document.getElementById('divAutoWorkshopContent').style.display = "block";
                }
                else
                { 
                    document.getElementById('divAutoWorkshopContent').style.display = "none";
                
                }
            
            }
        }
        function DuplicationEmployeeCode() {    //emp0025
            document.getElementById('divMessageAreaMain').style.display = "block";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=txtEmployeeCode.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Duplication Error!. Employee Id Can’t be Duplicated.";
            tableClick('divTblid8', cphMain_Tblid8);
        }
        function DuplicationName() {
            document.getElementById('divMessageAreaMain').style.display = "block";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=txtLoginName.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Duplication Error!. Employee Login Name Can’t be Duplicated.";
            tableClick('divTblid8', cphMain_Tblid8);
        }
        function DuplicationEmail() {
            document.getElementById('divMessageAreaMain').style.display = "block";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=txtUsrEmail.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Duplication Error!. Employee Email Can’t be Duplicated.";
            tableClick('divTblid8', cphMain_Tblid8);
        }
        function DuplicationOffclEmail() {
            document.getElementById('divMessageAreaMain').style.display = "block";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=txtOfflMail.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Duplication Error!. Employee Email Can’t be Duplicated.";
        }
    <%--    function DuplicationEmpCode() {
            document.getElementById('divMessageAreaMain').style.display = "block";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=txtEmployeeCode.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Duplication Error!. Employee Code Can’t be Duplicated.";
        }--%>
        function EmptyCorporate() {
            document.getElementById('divMessageAreaMain').style.display = "block";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=ddlUsrCorporate.ClientID%>").style.borderColor = "Red";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
        }
        function EmptyDepartment() {
            document.getElementById('divMessageAreaMain').style.display = "block";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
            //0013
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Please Select One Department.";
        }

     

        function  Confirmation() {
            document.getElementById('divMessageAreaMain').style.display = "block";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Employee Details Inserted Successfully.";
        }
        function SuccessDep() {
            document.getElementById('divMessageAreaMain').style.display = "block";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Please Select One Department.";
        }
        function SuccessUpdation() {
            document.getElementById('divMessageAreaMain').style.display = "block";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Employee Details Updated Successfully.";
        }
        function MailsendFail() {
            document.getElementById('divMessageAreaMain').style.display = "block";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Employee Details Inserted Successfully.The Mail Sending To Employee Failed.";
        }
        function MailsendFailReviewMailStng() {
            document.getElementById('divMessageAreaMain').style.display = "block";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Employee Details Inserted Successfully. Review Your Mail Settings For Sending Mail.";
        }
        //005 start
        function ShowLoading() {
           
            document.getElementById("myModalLoadingMail").style.display = "block";
            document.getElementById("freezelayer").style.display = "";
        }
        function HideLoading() {
            document.getElementById("myModalLoadingMail").style.display = "none";
            document.getElementById("freezelayer").style.display = "none";
        }
       

        function ValidateFileUpload() {
            document.getElementById('divMessageAreaMain').style.display = "block";
            document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "";
            var fuData = document.getElementById("<%=FileUploadProPic.ClientID%>");
            var FileUploadPath = fuData.value;
            var  hiddnImage= document.getElementById("<%=hiddenUserImage.ClientID%>").value;//it has value when editing if previously stored image
            var hidnImageSize = document.getElementById("<%=hiddenUserImageSize.ClientID%>").value;
           
            if (FileUploadPath == '' &&hiddnImage=="") {
                //if (confirm("Are you sure you  want to Save without uploading Image of Employee?")) {

                //    return true;
                //}
                //else {
                //    return false;
                //}
                return true;

            } else {
                if (FileUploadPath == '')
                {
                    return true;
                }
                else
                {
                    var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();



                    if (Extension == "gif" || Extension == "png" || Extension == "bmp"
                                || Extension == "jpeg" || Extension == "jpg") {


                        if (fuData.files && fuData.files[0]) {

                            var size = fuData.files[0].size;
                            var convertToKb = hidnImageSize/1000;
                            if (size > hidnImageSize) {
                                alert(" Sorry Maximum file size exceeds. Please Upload Image of less size than " + convertToKb + "KB !.");
                                document.getElementById("<%=FileUploadProPic.ClientID%>").focus();
                                return false;
                            } else { return true;
                                //var reader = new FileReader();

                                //reader.onload = function (e) {
                                //    $('#blah').attr('src', e.target.result);
                                //}

                                //reader.readAsDataURL(fuData.files[0]);
                            }
                        }

                    }
                


                    else {
                        document.getElementById('divMessageAreaMain').style.display = "block";
                        document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "The specified file could not be uploaded. Image type not supported. Allowed types are png, jpeg, gif";
               
                        return false;
                    }
                }
            }
        }

        function ReplaceTagOnBlur(obj)
        {
        
        
            var WithoutReplace = document.getElementById(obj).value;
            var replaceText1 = WithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(obj).value = replaceText2;
        
        }
        function ReplaceTagAndAtOnBlur(obj)
        {
        
        
            var WithoutReplace = document.getElementById(obj).value;
            var replaceText1 = WithoutReplace.replace(/</g, "");           
            var replaceText2 = replaceText1.replace(/>/g, "");           
         //   var replaceText3 = replaceText2.replace(/@/g, "");
          //  alert(replaceText3);
            document.getElementById(obj).value = replaceText3;
        
        }

        function BssicInfoValidation(Sou) 
        {
            //alert(Sou);


            var LoginMust=false;
            var AutoWrkShopMust=false;
            var ret = true;
            var Editing=false;
           
            if (CheckIsRepeat() == true) 
            {
            }
            else 
            {
                ret = false;
                return ret;
            }
            
            if(document.getElementById("<%=hiddenUserEditId.ClientID%>").value.trim()!="")
            {
                Editing=true;
            
            }
     
          
            

            document.getElementById("<%=TxtFrstName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=TxtLstName.ClientID%>").style.borderColor = "";

            document.getElementById("<%=TxtMidleName.ClientID%>").style.borderColor = "";
          
            document.getElementById("<%=ddlUsrDsgn.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlJobRole.ClientID%>").style.borderColor = "";
       
            document.getElementById("<%=ddlEmpType.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtNationalIdNmbr.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtEmployeeCode.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtUsrMob.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtUsrEmail.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtOfflMail.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlNationality.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtEmployeeCode.ClientID%>").style.borderColor = "";


            if(document.getElementById("<%=divLoginDetailsSection.ClientID%>").style.display!="none" )
            { 
                if(document.getElementById("<%=cbxMustLogin.ClientID%>").checked)
                {
                    LoginMust=true;
                    document.getElementById("<%=txtLoginName.ClientID%>").style.borderColor = "";
                    if(Editing==false)
                    {
                        document.getElementById("<%=txtUsrConPwd.ClientID%>").style.borderColor = "";
                        document.getElementById("<%=txtUsrPwd.ClientID%>").style.borderColor = "";
                        document.getElementById('PwdMsg').style.visibility = "hidden";
                        document.getElementById('ErrorMsgUsrConPwd').style.visibility = "hidden";
                    }
                }
                              
            }
            if(document.getElementById("<%=divAutoWorkshopSection.ClientID%>").style.display!="none")
            {
                if(document.getElementById("<%=cbxMustAutoWorkshop.ClientID%>").checked)
                {   AutoWrkShopMust=true;
                    document.getElementById("<%=txtLicenceNumbr.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtLicenseExpDate.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=ddlAccommodatn.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=FileUploadLicenseCopy.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=divLicenseType.ClientID%>").style.borderColor = "";
                }
               
            
            }
            //0039
            var JoinDt = document.getElementById("<%=txtJoineddate.ClientID%>").value;
            //end

            var FrstName =       document.getElementById("<%=TxtFrstName.ClientID%>").value.trim();  
            var LstName =    document.getElementById("<%=TxtLstName.ClientID%>").value.trim();  

            var MiddleName =    document.getElementById("<%=TxtMidleName.ClientID%>").style.borderColor = "";
            var Stafftype = document.getElementById("<%=ddlStafftype.ClientID%>").value; //EVM-0024@
            var UsrName = document.getElementById("<%=TxtFrstName.ClientID%>").value.trim();  
            var Dsgn = document.getElementById("<%=ddlUsrDsgn.ClientID%>");
            var Role = document.getElementById("<%=ddlJobRole.ClientID%>").value;
           
            var country=document.getElementById("<%=ddlNationality.ClientID%>").value;
            var DsgnText = Dsgn.options[Dsgn.selectedIndex].text.trim();
            var DropdownListEmpType = document.getElementById('<%=ddlEmpType.ClientID %>');
            var SelectedValueEmpType = DropdownListEmpType.value;
            var EmployeeId = document.getElementById("<%=txtEmployeeCode.ClientID%>").value.trim();  
            var Mobile = document.getElementById("<%=txtUsrMob.ClientID%>").value.trim();
            document.getElementById('ErrorMsgUsrMob').style.visibility = "hidden";
            var Email = document.getElementById("<%=txtUsrEmail.ClientID%>");
            document.getElementById('ErrorMsgUsrEmail').style.visibility = "hidden";

            var OffclEmail = document.getElementById("<%=txtOfflMail.ClientID%>");
            document.getElementById('ofcclMail').style.visibility = "hidden";
            
            var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;

            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            var minNumberofChars = 6;
            var maxNumberofChars = 16;
            //var regularExpression = /(?=.*\d)(?=.*[~!@#$%^&*])(?=.*[a-z])|(?=.*[A-Z])[0-9!@#$%^&*].{6,16}/;
            var regularExpression = /(?=.*\d)(?=.*[~!@#$%^&*])(?=.*[A-Za-z]).{6,16}/;

            
           
            if(Role=="--Select Job Role--")
            { 
                document.getElementById("<%=ddlJobRole.ClientID%>").style.borderColor="red";
                document.getElementById('divMessageAreaMain').style.display = "block";
                document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                ret=false;
                          
            }  
            

            //0039
            if(Sou == 1)
            {
                if(JoinDt=="")
                { 
                    {                      
                        document.getElementById('divMessageAreaforjob').style.display = "";
                        document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById("<%=txtJoineddate.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtJoineddate.ClientID%>").focus();
                        tableClick('divTblid5',cphMain_Tblid5);
                        ret = false;
                    }
                } 
            }
            //end
            if(Stafftype==2)
            { 
                document.getElementById("<%=ddlStafftype.ClientID%>").style.borderColor="red";
                document.getElementById("<%=ddlStafftype.ClientID%>").focus();
                document.getElementById('divMessageAreaMain').style.display = "block";
                document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                ret=false;
                          
            }  
            
            if(country=="--Select Country--") //emp17
            { 
                document.getElementById("<%=ddlNationality.ClientID%>").style.borderColor="red";
                document.getElementById("<%=ddlNationality.ClientID%>").focus();
                document.getElementById('divMessageAreaMain').style.display = "block";
                document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                ret=false;
                      
            
            }
            
            if(EmployeeId=="") //emp17
            { 
                document.getElementById("<%=txtEmployeeCode.ClientID%>").style.borderColor="red";
                document.getElementById("<%=txtEmployeeCode.ClientID%>").focus();
                document.getElementById('divMessageAreaMain').style.display = "block";
                document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                ret=false;
                      
            
            }


            var flagAutoWrkShop=true; 

            if(AutoWrkShopMust==true)
            {
                var DrvngLicNo= document.getElementById("<%=txtLicenceNumbr.ClientID%>").value.trim();
                var LicExpDate = document.getElementById("<%=txtLicenseExpDate.ClientID%>").value.trim();              
                var FupLicCopy = document.getElementById("<%=FileUploadLicenseCopy.ClientID%>").value.trim();             
                var LicTypeId = document.getElementById("<%=hiddenLicenseTypeId.ClientID%>").value.trim();

                if (LicTypeId == "") 
                {

                    document.getElementById("<%=divLicenseType.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=divLicenseType.ClientID%>").focus();
                    flagAutoWrkShop=false;
                }
                if( document.getElementById("<%=hiddenUserLicenseCopy.ClientID%>").value=="" && document.getElementById("<%=FileUploadLicenseCopy.ClientID%>").value=="")
                {
                   
                    document.getElementById("<%=FileUploadLicenseCopy.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=FileUploadLicenseCopy.ClientID%>").focus();
                    document.getElementById("<%=lblLicenseCopy.ClientID%>").style.color="red";
                    document.getElementById("<%=lblLicenseCopy.ClientID%>").textContent = "Please Upload License Copy";
                    flagAutoWrkShop=false;
                }
                if (LicExpDate == "")
                {

                    document.getElementById("<%=txtLicenseExpDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtLicenseExpDate.ClientID%>").focus();
                    flagAutoWrkShop=false;
                }
                if (DrvngLicNo == "")
                {
                    document.getElementById("<%=txtLicenceNumbr.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtLicenceNumbr.ClientID%>").focus();
                    flagAutoWrkShop=false;
                }
                    
            }

           
            var flagLogin=true; 
          
           
            if(LoginMust==true)
            {
                var LogName = document.getElementById("<%=txtLoginName.ClientID%>").value.trim();
                var EmpCode = document.getElementById("<%=txtEmployeeCode.ClientID%>").value.trim();
                var Pwd ="";
                var ConPwd ="";

                if(Editing==false)
                {
                    Pwd = document.getElementById("<%=txtUsrPwd.ClientID%>").value.trim();
             
                    ConPwd = document.getElementById("<%=txtUsrConPwd.ClientID%>").value.trim();

                }

                if(Editing==false)
                {
                    if (!regularExpression.test(Pwd)) {
                       
                        document.getElementById("<%=txtUsrPwd.ClientID%>").focus();
                        document.getElementById("<%=txtUsrPwd.ClientID%>").style.borderColor = "Red";
                        flagLogin=false;
                    }
                    if (Pwd.length < minNumberofChars || Pwd.length > maxNumberofChars) {
                      
                        document.getElementById("<%=txtUsrPwd.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtUsrPwd.ClientID%>").focus();
                        flagLogin=false;
                    }
                    if (ConPwd != Pwd) {
                        var ErrorMsg = document.getElementById('ErrorMsgUsrConPwd').style.visibility = "visible";
                        var OrgConPwdFocus = document.getElementById("<%=txtUsrConPwd.ClientID%>").focus();
                        document.getElementById("<%=txtUsrConPwd.ClientID%>").style.borderColor = "Red";
                        flagLogin=false;
                    }
                }
                if (LogName == "") {

                    document.getElementById("<%=txtLoginName.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtLoginName.ClientID%>").focus();
                    flagLogin=false;
                }
            }
            if(document.getElementById("<%=cbxMustLogin.ClientID%>").checked)
            {
                 
                if (Email.value == "") 
                {
                    document.getElementById("<%=txtUsrEmail.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtUsrEmail.ClientID%>").focus();
                    flagLogin=false;
                }   
            }
            if (EmpCode == "") 
            {

                document.getElementById("<%=txtEmployeeCode.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtEmployeeCode.ClientID%>").focus();
                flagLogin=false;
            }
            if (FrstName == "") 
            {

                document.getElementById("<%=TxtFrstName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=TxtFrstName.ClientID%>").focus();
                flagLogin=false;
            }
            if (LstName == "") 
            {

                document.getElementById("<%=TxtLstName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=TxtLstName.ClientID%>").focus();
                flagLogin=false;
            }
                     
            if ((!filter.test(OffclEmail.value)) && (OffclEmail.value.trim()!= "")) {
                   
                var ErrorMsg = document.getElementById('ofcclMail').style.visibility = "visible";
                //  EmailAdd = "";
                document.getElementById("<%=txtOfflMail.ClientID%>").focus();
                document.getElementById("<%=txtOfflMail.ClientID%>").style.borderColor = "Red";
                document.getElementById('divMessageAreaMain').style.display = "block";
                document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                ret = false;
            }
            if ((!filter.test(Email.value)) && (Email.value.trim()!= "")) {
                   
                var ErrorMsg = document.getElementById('ErrorMsgUsrEmail').style.visibility = "visible";
                //  EmailAdd = "";
                document.getElementById("<%=txtUsrEmail.ClientID%>").focus();
                document.getElementById("<%=txtUsrEmail.ClientID%>").style.borderColor = "Red";
                document.getElementById('divMessageAreaMain').style.display = "block";
                document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                ret = false;
            }

            if (Mobile.length != 0) {
                if (!mobileregular.test(Mobile)) {
                    var ErrorMsg = document.getElementById('ErrorMsgUsrMob').style.visibility = "visible";
                    var OrgMobileFocus = document.getElementById("<%=txtUsrMob.ClientID%>").focus();
                    document.getElementById("<%=txtUsrMob.ClientID%>").style.borderColor = "Red";
                    document.getElementById('divMessageAreaMain').style.display = "block";
                    document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    ret = false;
                }
            }
            //  alert('activeViewIndex');
            var activeViewIndex = <%=mvUsrCorporate.ActiveViewIndex %>;
           
            
            var flagactiveindexCorpControl=0;
            //0013-1
            if(activeViewIndex==1)
            {
                if(DsgnText != "--SELECT--")
                {
               
                    var bus = document.getElementById("<%=ddlUsrCorporate.ClientID%>").value;
                
                    if(bus=="--SELECT--")
                    { 
                        document.getElementById("<%=ddlUsrCorporate.ClientID%>").style.borderColor="red";
                        document.getElementById('divMessageAreaMain').style.display = "block";
                        document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        ret=false;
                        
                    }
                    //0013 radio
         
                }
            }
           
              
           
            if (UsrName == "" ||  DsgnText == "--SELECT--" || SelectedValueEmpType == "--SELECT--"||SelectedValueEmpType=="" ||Role=="--Select Job Role--"||Role=="--No Job Role Avilable--"||  flagactiveindexCorpControl==1 ||flagLogin==false||flagAutoWrkShop==false) {
                
                document.getElementById('divMessageAreaMain').style.display = "block";
                document.getElementById('imgMessageAreaMain').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=LblMessageAreaMain.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
             
                
                if ((!filter.test(OffclEmail.value)) && (OffclEmail.value.trim()!= "")) {
                   
                    var ErrorMsg = document.getElementById('ofcclMail').style.visibility = "visible";
                    //  EmailAdd = "";
                    document.getElementById("<%=txtOfflMail.ClientID%>").focus();
                    document.getElementById("<%=txtOfflMail.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if ((!filter.test(Email.value)) && (Email.value.trim()!= "")) {
                   
                    var ErrorMsg = document.getElementById('ErrorMsgUsrEmail').style.visibility = "visible";
                    //  EmailAdd = "";
                    document.getElementById("<%=txtUsrEmail.ClientID%>").focus();
                    document.getElementById("<%=txtUsrEmail.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }

                if (Mobile.length != 0) {
                    if (!mobileregular.test(Mobile)) {
                        var ErrorMsg = document.getElementById('ErrorMsgUsrMob').style.visibility = "visible";
                        var OrgMobileFocus = document.getElementById("<%=txtUsrMob.ClientID%>").focus();
                        document.getElementById("<%=txtUsrMob.ClientID%>").style.borderColor = "Red";
                        ret = false;
                    }
                }
                if (SelectedValueEmpType == "--SELECT--"||SelectedValueEmpType=="") {

                    document.getElementById("<%=ddlEmpType.ClientID%>").focus();             
                    document.getElementById("<%=ddlEmpType.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
 
                        
                if (DsgnText == "--SELECT--") {
                    document.getElementById("<%=ddlUsrDsgn.ClientID%>").focus();
                
                    document.getElementById("<%=ddlUsrDsgn.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
               
                if(DsgnText!= "--SELECT--")
                {
                           
                    if(Role=="--Select Job Role--"||Role=="--No Job Role Avilable--")
                    {
                        document.getElementById("<%=ddlJobRole.ClientID%>").style.borderColor = "Red";
                        ret = false;
                    }
                           
                }
                if (UsrName == "") {

                      
                    document.getElementById("<%=TxtFrstName.ClientID%>").style.borderColor = "Red";
                    var OrgnTypeFocus = document.getElementById("<%=TxtFrstName.ClientID%>").focus();
                    ret = false;
                }
             
                if(flagactiveindexCorpControl==1)
                {
                    ret=false;
                }
                if(flagLogin==false)
                {
                    ret=false;
                }
                if(flagAutoWrkShop==false)
                {
                    ret=false;
                }
            }

            
            
            //EVM-0027
            //if(ret==true)
            //{
            //    if(ValidatePrimaryDivsn()==true)
            //    {

            //        if (ValidateFileUpload() == true) {
            //            ret=true;
            //        }
            //        else{
            //            ret=false;
            //        }
            //    }
            //    else {

            //        ret= false;
            //    }
            //}
            //END

            if(Sou==0 && ret==true){
                if(validateJobsave(1)==false){
                    tableClick('divTblid5', cphMain_Tblid5);
                    ret= false;
                }
            }

            if (ret == false)
            {
                CheckSubmitZero();

            }
            
            if(ret==true)
            {              
                if(Editing==false)//adding
                {
                    ShowLoading();
                }
            }

            //EVM-0027
            var Elements=document.getElementsByClassName('divcls');
            document.getElementById("<%=hiddenPrimaryDivision.ClientID%>").value= ""; 
            for(var j=0;Elements[j];j++){
               
                if(document.getElementById("radioDivision"+j).checked==true)
                {
                    document.getElementById("<%=hiddenPrimaryDivision.ClientID%>").value=  document.getElementById("cphMain_cbxlCorporateDvsn_" +j).value;
                   
                }
                             
               
            }
           
            //END
             
            return ret;
            
        }


        




        function ClearDivDisplayLicenseCopy() {
          
            IncrmntConfrmCounter();
           
        
            
            var fuData = document.getElementById("<%=FileUploadLicenseCopy.ClientID%>");
           
          
            
                
            if (document.getElementById("<%=FileUploadLicenseCopy.ClientID%>").value != "") {
                document.getElementById("<%=lblLicenseCopy.ClientID%>").style.color="black";
                document.getElementById("<%=lblLicenseCopy.ClientID%>").textContent = document.getElementById("<%=FileUploadLicenseCopy.ClientID%>").value;
                document.getElementById("<%=divLicenseCopyDisplay.ClientID%>").innerHTML="";
                document.getElementById("<%=hiddenUserLicenseCopy.ClientID%>").value="";
            }
               
            //    return true;
            
            
        }
      
        function ClearLicenseCopy() {
            if( document.getElementById("<%=hiddenUserLicenseCopy.ClientID%>").value!="" || document.getElementById("<%=FileUploadLicenseCopy.ClientID%>").value!="")
                {
                    if (confirm("Do You Want To Remove Selected License Copy?")) {
                        IncrmntConfrmCounter();
                        document.getElementById("<%=FileUploadLicenseCopy.ClientID%>").value="";
                    document.getElementById("<%=hiddenUserLicenseCopy.ClientID%>").value="";                   
                    document.getElementById("<%=divLicenseCopyDisplay.ClientID%>").innerHTML="";
                    document.getElementById("<%=lblLicenseCopy.ClientID%>").style.color="black";
                    document.getElementById("<%=lblLicenseCopy.ClientID%>").textContent="No File Selected";
                    //  alert("Image has been Removed Sucessfully. ");
                }
                else {
                    
                }
              
            }
        }


    </script>
    <script type="text/javascript">
        // for not allowing <> tags
        function isTag(evt) {
            
            document.getElementById('divMessageAreaforimig').style.display = "none";
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
        // for not allowing <> and @ tags
        function isTagAndAT(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
            if (keyCodes == 64) {
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
    </script>
    <script type="text/javascript">
        function isNumber(evt) {
         
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //enter
            if (keyCodes == 13) {
                // return false;
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
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46|| keyCodes == 38 || keyCodes == 40) {
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

        function Password_Strength( event) {

            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            var charCode = (event.which) ? event.which : event.keyCode;
            var OrgPwd = document.getElementById("<%=txtUsrPwd.ClientID%>").value;
            var ErrorMsg = document.getElementById('PwdMsg').style.visibility = "hidden";
            if (keyCode == 13) {
               
                return false;
            }
           
          
            if (charCode == 60 || charCode == 62) {
                return false;
            }
         


            else {
                if (Pwd.length >= 6 && OrgPwd.length < 10) {

                    document.getElementById('PwdMsg').style.visibility = "visible";
                    document.getElementById('PwdMsg').style.color = "red";
                    document.getElementById('PwdMsg').innerHTML = "WEAK";
                    return true;
                }
                if (Pwd.length >= 10 && OrgPwd.length < 13) {
                    document.getElementById('PwdMsg').style.visibility = "visible";
                    document.getElementById('PwdMsg').style.color = "orange";
                    document.getElementById('PwdMsg').innerHTML = "MEDUIM";
                    return true;
                }
                if (Pwd.length >= 13) {
                    document.getElementById('PwdMsg').style.visibility = "visible";
                    document.getElementById('PwdMsg').style.color = "green";
                    document.getElementById('PwdMsg').innerHTML = "STRONG";
                    return true;
                }
                return true;
            }
        }

        function SelectLicenseType(LicenseTypId) {
            var  blCheckedPrevious=false;
            var PreviousSlctdValues=document.getElementById("<%=hiddenLicenseTypeId.ClientID%>").value;
            var LicTypes = PreviousSlctdValues.split(",");
            //  alert('bla' +PreviousSlctdValues);
            //    alert(LicTypes.length);
            for (i = 0; i < LicTypes.length; i++) {
                if(LicTypes[i].toString()==LicenseTypId.toString() && LicTypes[i].toString() !="")
                {
                    blCheckedPrevious=true;
                    document.getElementById("divImageLicenseType-" + LicenseTypId).style.border = ".5px solid";
                    document.getElementById("divImageLicenseType-" + LicenseTypId).style.borderColor = "#ceb6b6";
                    document.getElementById("divImageLicenseType-" + LicenseTypId).style.backgroundColor = "";
                
                }
            }
           

            // var oldImage = document.getElementById("<%=hiddenLicenseTypeId.ClientID%>").value;
            //if (oldImage != "") {
            //    document.getElementById("divImageLicenseType-" + oldImage).style.border = ".5px solid";
            //    document.getElementById("divImageLicenseType-" + oldImage).style.borderColor = "#ceb6b6";
            //    document.getElementById("divImageLicenseType-" + oldImage).style.backgroundColor = "";
            //}
            if(blCheckedPrevious==false)
            {// if not selected previously
                document.getElementById("divImageLicenseType-" + LicenseTypId).style.border = ".5px solid";
                document.getElementById("divImageLicenseType-" + LicenseTypId).style.backgroundColor = "rgb(56, 255, 128)";
                if(document.getElementById("<%=hiddenLicenseTypeId.ClientID%>").value=="")
                {
                    document.getElementById("<%=hiddenLicenseTypeId.ClientID%>").value = LicenseTypId+",";
                }
                else
                {
                    document.getElementById("<%=hiddenLicenseTypeId.ClientID%>").value = document.getElementById("<%=hiddenLicenseTypeId.ClientID%>").value+LicenseTypId+",";
            
                }
            }
            else
            {
            
                var replacedValue = PreviousSlctdValues.replace(LicenseTypId+",",""); 
                document.getElementById("<%=hiddenLicenseTypeId.ClientID%>").value=replacedValue;
            
            }

            
        }

        function testLicenseType()
        {
        
            return false;
        }

        var $noConflicti = jQuery.noConflict();

        function ShowHideDiv(obj) {
            if(obj=="cphMain_cbxMustLogin")
            {
                if(document.getElementById(obj).checked)
                {
                    document.getElementById('divLoginDetailsContent').style.display = "block";
                    document.getElementById('lblEmployeeCode').innerText="Employee Id*";
                    document.getElementById('lblEmail').innerText="Email*";
                    
                }
                else
                {
                    alert('If you are not selecting this Section then information in this Section will not be saved or updated !');
                    document.getElementById('divLoginDetailsContent').style.display = "none";
                    //          document.getElementById('lblEmployeeCode').innerText="Employee Code";
                    document.getElementById('lblEmployeeCode').innerText="Employee Id*";
                    document.getElementById('lblEmail').innerText="Email";
                }
            
            }
            else if(obj=="cphMain_cbxMustAutoWorkshop")
            {
                if(document.getElementById(obj).checked)
                {
                    document.getElementById('divAutoWorkshopContent').style.display = "block";
                }
                else
                {    alert('If you are not selecting this Section then information in this Section will not be saved or updated !');
                    document.getElementById('divAutoWorkshopContent').style.display = "none";
                
                }
            
            }
            else if(obj=="cphMain_ddlBank")
            {
                document.getElementById('lblBank').innerText="Bank*";
                document.getElementById('lblBranch').innerText="Branch*";
                document.getElementById('lblIban').innerText="IBAN No*";
                document.getElementById('lblEmpId').innerText="Employee ID*";
                document.getElementById('lblAcntTyp').innerText="Account Type*";

                $noConflicti("#cphMain_txtIban").css({
                    'margin-left':155.5+'px'

                });

                IncrmntConfrmCounterOther();
            }
           
            
      
        }

       
    </script>
    <script>
        function LoadddlRole() {

            var $Mo = jQuery.noConflict();
            var varddldesig = document.getElementById("<%=ddlUsrDsgn.ClientID%>").value;
         
            var Orgid = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
              
            var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
               
            var tableName = "dtrole";
            
            var Details = PageMethods.LoadRole(varddldesig, Orgid, CorpId, function (response) {


                var OptionStart = $Mo("<option>--Select Job Role--</option>");

                OptionStart.attr("value", 0);
                $Mo('#<%=ddlJobRole.ClientID%>').empty();
                $Mo('#<%=ddlJobRole.ClientID%>').append(OptionStart);

                // Now find the Table from response and loop through each item (row).
                $Mo(response).find(tableName).each(function () {
                    // Get the OptionValue and OptionText Column values.
                    var OptionValue = $Mo(this).find('JOBRL_ID').text();
                    var OptionText = $Mo(this).find('JOBRL_NAME').text();
                    // Create an Option for DropDownList.
                    var option = $Mo("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);
                    $Mo('#<%=ddlJobRole.ClientID%>').append(option);

                });
                // return false;
            });
    

        }

        function LoadFromRole() {

            var $Mo = jQuery.noConflict();
            var varddlAddtn = document.getElementById("<%=ddlJobRole.ClientID%>").value;
            // var ddlpygdeValue = varddlAddtn.options[varddlAddtn.selectedIndex].value;
            var Orgid = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
            var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
            var tableName = "dtTablefortree";
            var Details = PageMethods.LoadRoleTree(varddlAddtn, Orgid, CorpId, function (response) {


                var OptionStart = $Mo("<option>--SELECT SALARY DEDCTION--</option>");

                OptionStart.attr("value", 0);
                $Mo('#<%=ddldedctn.ClientID%>').empty();
                    $Mo('#<%=ddldedctn.ClientID%>').append(OptionStart);

                    // Now find the Table from response and loop through each item (row).
                    $Mo(response).find(tableName).each(function () {
                        // Get the OptionValue and OptionText Column values.
                        var OptionValue = $Mo(this).find('PGDEDTN_ID').text();
                        var OptionText = $Mo(this).find('PAYRL_NAME').text();
                        // Create an Option for DropDownList.
                        var option = $Mo("<option>" + OptionText + "</option>");

                        option.attr("value", OptionValue);

                        $Mo('#<%=ddldedctn.ClientID%>').append(option);

                    });
                    // return false;
                });
            }







    </script>





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



               <%--------------------------------View for error Reason of salary--------------------------%>
             <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Pay Grade</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:7%; padding-right: 2%;width: 24%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="return CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   
    <div id="divProbationUpdView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseRenewView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Renew Probation Date</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                     <div id="divProbLayer" style="width: 100%; float: left;">
                          <section style="width: 95%; margin-left: 3%; float: left;">

                               <div style="float: left; width: 34%;">
                                 <h2 style="font-size:17px;margin-left: 4.2%;margin-top:7px"> Probation End Date   </h2>
                                   </div>
                                      <div style="float: left; width: 27%;">

                                <asp:DropDownList ID="DrpProbEndDate" class="form1" Style="width: 97%; float: left; margin-left: 2%;height: 31px;" runat="server" onchange="return ProbationMonth();"></asp:DropDownList>
                                    </div>
                              <div id="divDateProbation" style="float:left;margin-left: 9px;">
                        <asp:TextBox ID="txtprobPeriod" onblur="SetProbationPeriod()"  onchange="SetProbationPeriod()" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  Style="width: 54%; height: 30px; float: left;" onkeypress="return DisableEnter(event);"></asp:TextBox>

                        <input type="image"id="Image25" class="add-on" src="../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:2%;" onblur="SetProbationPeriod()"  />
                                                                
                                                                    <script type="text/javascript"
                                                                    src="../../JavaScript/Date/JavaScriptDate1_8_3.js">
                                                                    </script>
                                                                     <script type="text/javascript"
                                                                        src="../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                                                                    </script>
                                                                     <script type="text/javascript"
                                                                       src="../../JavaScript/Date/bootstrap-datepicker.js">
                                                                     </script>
                                                                    <script type="text/javascript"
                                                                   src="../../JavaScript/Date/bootstrap-datepicker_pt_br.js">
                                                                   </script>
                                                                     <script type="text/javascript">                                                                  
                                                                         var $noC = jQuery.noConflict();
                                                                         $noC('#divDateProbation').datetimepicker({
                                                                             format: 'dd-MM-yyyy',
                                                                             language: 'en',
                                                                             pickTime: false,
                              
                                                                         });
                                                                </script>
                                             </div>              
                                  </section>
                             </div>
                         <input type="button" id="btnRenew" class="save" style="width: 90px; float:right;margin-right:44%;margin-top: 3%;" onclick="RenewProbation();" runat="server" value="Save" />
                  </div>

                 <div class="modal-footerCancelView" style="margin-top: 43px;">
                    </div>
                       
                    </div>
                    
                   


                </div>
         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
          </div>
    






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
           /*float: left;*/
        }
    </style>
      <%--EVM-0024--%>
  <script>
      function ProbationMonth() {
          var DropdownListWeek = document.getElementById("<%=DrpProbEndDate.ClientID%>");
          var SelectedValueWeek = DropdownListWeek.value;
          var dateCurrentDate = document.getElementById("<%=txtJoineddate.ClientID%>").value;
          if(dateCurrentDate!="")
          {
              var arrDateCurrentDate = dateCurrentDate.split("-");
              // var CurrentDate = new Date(arrDateCurrentDate[2], arrDateCurrentDate[1] - 1, arrDateCurrentDate[0]);
              var dateDateCntrlr = new Date(arrDateCurrentDate[2], arrDateCurrentDate[1] - 1, arrDateCurrentDate[0]);
              //= new Date();
                                    
              if (SelectedValueWeek != '--Select Month--') {
                  var week = parseInt(SelectedValueWeek);                                      
                  dateDateCntrlr.setDate(dateDateCntrlr.getDate() + week * 30);
              }
              var dd = dateDateCntrlr.getDate();
              var mm = dateDateCntrlr.getMonth() + 1; //January is 0!

              var yyyy = dateDateCntrlr.getFullYear();
              if (dd < 10) {
                  dd = '0' + dd
              }
              if (mm < 10) {
                  mm = '0' + mm
              }
              var ddmmyyyyDate = dd + '-' + mm + '-' + yyyy;

              document.getElementById("<%=txtprobPeriod.ClientID%>").value = ddmmyyyyDate;
          }
          else
          {
              document.getElementById("<%=txtprobPeriod.ClientID%>").value = "";
          }
          SetProbationPeriod();

          return false;
      }
      function SetProbationPeriod()
      { 
          IncrmntConfrmCounterJob();
   
          var $noC = jQuery.noConflict();
          var joindate = document.getElementById("<%=txtJoineddate.ClientID%>").value;
          var enddate = document.getElementById("<%=txtprobPeriod.ClientID%>").value;
          var arrDatePickerDate1 = joindate.split("-");
          var datejoinedd = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
          var arrDatePickerDate1 = enddate.split("-");
          var dateendd = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

          if(joindate!=""&&enddate!="")
          { 
              if (datejoinedd > dateendd) {
                  document.getElementById("<%=txtprobPeriod.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtprobPeriod.ClientID%>").focus();
                  document.getElementById('divMessageAreaforjob').style.display = "";
                  document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML =  "Sorry, Date of joining cannot be greater than probation end date !.";
                  document.getElementById("<%=TxtPeriod.ClientID%>").value=0;
                  return false;
              }
          }

          var months = monthDiff(datejoinedd, dateendd);
          if(joindate!="")
          { 
              if(enddate!="")
                  document.getElementById("<%=TxtPeriod.ClientID%>").value=months+1;
          
          }
          else
          {
              document.getElementById("<%=TxtPeriod.ClientID%>").value=0;
          }
      }

      function OpenViewRenwl() {
          var jobId=document.getElementById("<%=HiddenJobProbId.ClientID%>").value;
          $.ajax({
              type: "POST",
              async: false,
              contentType: "application/json; charset=utf-8",
              url: "gen_Emply_Personal_Informn.aspx/readprobation",
              data: '{strJobId: "' + jobId + '"}',
              dataType: "json",
              success: function (data) {
                  document.getElementById("<%=txtprobPeriod.ClientID%>").value=data.d[0]; 
                   
              }
                   });
              document.getElementById("<%=HiddenJobRenew.ClientID%>").value = jobId;
          document.getElementById("divProbationUpdView").style.display = "block";
          document.getElementById("freezelayer").style.display = "";
          return false;
      }
      function RenewProbation() {
          var EmpJobId = document.getElementById("<%=HiddenJobRenew.ClientID%>").value;
          var ProbDate = document.getElementById("<%=txtprobPeriod.ClientID%>").value;
          var Perid = document.getElementById("<%=TxtPeriod.ClientID%>").value;
          if (ProbDate != "") {
              $.ajax({
                  type: "POST",
                  async: false,
                  contentType: "application/json; charset=utf-8",
                  url: "gen_Emply_Personal_Informn.aspx/RenewProbationUpdate",
                  data: '{strJobsId: "' + EmpJobId + '",strProbDate:"' + ProbDate + '",strProbPeriod:"' + Perid + '"}',
                  dataType: "json",
                  success: function (data) {
                      document.getElementById("<%=txtProbationdate.ClientID%>").value=ProbDate;
                  }
              });
              CloseRenewView();
              ConfirmRenewMessage();
          }
          else {
              document.getElementById("<%=txtprobPeriod.ClientID%>").style.borderColor = "red";
             }
         }
         function CloseRenewView() {
             document.getElementById("divProbationUpdView").style.display = "none";
             document.getElementById("freezelayer").style.display = "none";
         }
         function ConfirmRenewMessage() {
             document.getElementById('divMessageAreaforjob').style.display = "";
             document.getElementById('imgMessageAreaforjob').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageAreaforjob.ClientID%>").innerHTML = "Employee probation period renewed successfully.";
      }
      </script>
   <%-- END--%>
  <script>
      function hide_updatebutton()
      {
          document.getElementById("<%=btnUpdateImigrationDtls.ClientID%>").style.display ="none";
                    
      }
      function show_updatebutton()
      {
          document.getElementById("<%=btnUpdateImigrationDtls.ClientID%>").style.display ="block";
                    
      }
      function show_saveebutton()
      {
          document.getElementById("<%=btnAddImigrationDtls.ClientID%>").style.display ="block";
                    
      }
      function hide_saveebutton()
      {
          document.getElementById("<%=btnAddImigrationDtls.ClientID%>").style.display ="none";
                    
      }
      function hide_clearbutton()
      {
          document.getElementById("<%=BtnclrImig.ClientID%>").style.display ="none";
                    
      }
      function show_clearbutton()
      {
          document.getElementById("<%=BtnclrImig.ClientID%>").style.display ="block";
                    
      }
      function hide_clearbuttonproj()
      {
          document.getElementById("<%=btnprojectclr.ClientID%>").style.display ="none";
                    
      }
      function show_clearbuttonproj()
      {
          document.getElementById("<%=btnprojectclr.ClientID%>").style.display ="block";
                    
      }
      function show_Resigndiv()
      {//alert();

         
          var FramewrkTyp = '<%= Session["FRMWRK_TYPE"] %>';
          if (FramewrkTyp != "1" ) {
              document.getElementById("cphMain_Tblid9").style.display ="none";
          }
                    
      }
      function SuccessResignation() {
          document.getElementById('imgMessageAreaRS').src = "/Images/Icons/imgMsgAreaInfo.png";
      
          document.getElementById('divMessageAreaRS').style.display = "";
          document.getElementById("<%=lblMessageAreaRes.ClientID%>").innerHTML = "Resignations details updated successfully.";
          tableClick('divTblid9', cphMain_Tblid9);
      }
      //new 15
      function ValidateRS() { 
          var joindate = document.getElementById("cphMain_txtleavingdate").value.trim();
          document.getElementById("cphMain_txtleavingdate").style.borderColor="";

          document.getElementById("divMessageAreaRS").style.display="none";

          
          if(joindate=="")
          {document.getElementById("cphMain_txtleavingdate").style.borderColor="red";
              document.getElementById("divMessageAreaRS").style.display="";
              document.getElementById("<%=lblMessageAreaRes.ClientID%>").innerHTML = "Leaving date cannot be empty";
              return false;
          }else return true;
      
      }
      function check(count){
     
          document.getElementById("cphMain_cbxlCorporateDvsn_" +count).checked = true;

      }
      function textCounter(field, maxlimit) {
          if (field.value.length > maxlimit) {
              field.value = field.value.substring(0, maxlimit);
          } else {
              isTag(event);
          }
      }

  </script>

            <asp:HiddenField ID="hiddenWorkerId" runat="server" />
            <asp:HiddenField ID="hiddenBankDtls" runat="server" />
     <asp:HiddenField ID="HiddenUserCrprtDept" runat="server" />
    <script>
        function checkAcmdtnDate(obj)   //emp25
        {

       
            document.getElementById('divMessageAreaPD').style.display = "none";
            document.getElementById('imgMessageAreaPD').src = "";
            var Accmdtn = document.getElementById("<%=ddlAccmdtn.ClientID%>").value;
            var ret=true;
            document.getElementById("<%=OccupyDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtAcmdtnToDate.ClientID%>").style.borderColor = "";
           
            var OccupyDate = document.getElementById("<%=OccupyDate.ClientID%>").value;   //emp25
            var arrDatePickerDate = OccupyDate.split("-");
            var ocpncDate = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);
            
            var OccupyDateTo=document.getElementById("<%=txtAcmdtnToDate.ClientID%>").value;
            var arrDatePickerDate = OccupyDateTo.split("-");
            var ocpncDateTo = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);
            
            if(ocpncDate>ocpncDateTo)
            {
               
                document.getElementById('divMessageAreaPD').style.display = "";
                document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById(obj).style.borderColor = "Red";
                document.getElementById(obj).value="";
                document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = "Sorry, From date should be Less than To date !";
                document.getElementById(obj).focus();
                
                ret = false;

            }
            return ret;
        }

        function checkMessDate(obj)      //emp25
        {
          
            document.getElementById('divMessageAreaPD').style.display = "none";
            document.getElementById('imgMessageAreaPD').src = "";

            var mess= document.getElementById("<%=DdlMess.ClientID%>").value;   
            var ret=true;
           

            
           document.getElementById("<%=txtMessFromDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtMessToDate.ClientID%>").style.borderColor = "";
            var messFromdate = document.getElementById("<%=txtMessFromDate.ClientID%>").value;
            var arrDatePickerDate = messFromdate.split("-");
            var datemssFrmDt = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);
              

            var messToDate = document.getElementById("<%=txtMessToDate.ClientID%>").value;
                var arrDatePickerDate = messToDate.split("-");
                var datemssToDt = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);
                 
                
                if(datemssFrmDt>datemssToDt)                
                {
                    document.getElementById(obj).style.borderColor = "Red";
                    document.getElementById(obj).value="";
                    document.getElementById(obj).focus();
                    document.getElementById('divMessageAreaPD').style.display = "";
                    document.getElementById('imgMessageAreaPD').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageAreaPD.ClientID%>").innerHTML = "Sorry, From date should be less than To date !";
                    ret = false;
                }
                return ret;  
        
            }
        

    </script>


            <script>
                function loadsalpaycrd(){



                    if (confirm("Changing the account type may change some fields.Are you sure you want to continue?")) {
                        if (document.getElementById("<%=ddlAccntTyp.ClientID%>").value == "1")
                        {
                            document.getElementById("divPayCrd").style.display = "none";
                            document.getElementById("divSalary").style.display = "";
                            return true;
                        }
                        else if (document.getElementById("<%=ddlAccntTyp.ClientID%>").value == "2")
                        {
                            document.getElementById("divPayCrd").style.display = "";
                            document.getElementById("divSalary").style.display = "none";
                            document.getElementById("<%=txtEmpId.ClientID%>").value = document.getElementById("<%=txtEmployeeCode.ClientID%>").value;
                          <%--  document.getElementById("<%=txtEmpId.ClientID%>").value = document.getElementById("<%=Txtemplyid.ClientID%>").value;--%>
                            return true;
                        }
                }
                else{
                    document.getElementById("<%=ddlAccntTyp.ClientID%>").value=document.getElementById("<%=hiddenAccountTyp.ClientID%>").value;
                        if (document.getElementById("<%=ddlAccntTyp.ClientID%>").value == "1")
                        {
                            document.getElementById("divPayCrd").style.display = "none";
                            document.getElementById("divSalary").style.display = "";
                            return true;
                        }
                        else if (document.getElementById("<%=ddlAccntTyp.ClientID%>").value == "2")
                        {
                            document.getElementById("divPayCrd").style.display = "";
                            document.getElementById("divSalary").style.display = "none";
                            //evm-0024
                            document.getElementById("<%=txtEmpId.ClientID%>").value = document.getElementById("<%=txtEmployeeCode.ClientID%>").value;
                         <%--    document.getElementById("<%=txtEmpId.ClientID%>").value = document.getElementById("<%=Txtemplyid.ClientID%>").value;--%>
                            return true;
                        }
                    return false;
                }


                IncrmntConfrmCounterOther();
            }


            function loadsaved(){

                if (document.getElementById("<%=ddlAccntTyp.ClientID%>").value == "1")
                    {
                        document.getElementById("divPayCrd").style.display = "none";
                        document.getElementById("divSalary").style.display = "";
                        return true;
                    }
                    else if (document.getElementById("<%=ddlAccntTyp.ClientID%>").value == "2")
                        {
                            document.getElementById("divPayCrd").style.display = "";
                            document.getElementById("divSalary").style.display = "none";
                        //evm-0024
                            document.getElementById("<%=txtEmpId.ClientID%>").value = document.getElementById("<%=txtEmployeeCode.ClientID%>").value; 
                       <%-- document.getElementById("<%=txtEmpId.ClientID%>").value = document.getElementById("<%=Txtemplyid.ClientID%>").value;--%>
                            return true;
                        }            
                }

                function changetxtempid(){
                    //EVm-0024
                    document.getElementById("<%=txtEmpId.ClientID%>").value = document.getElementById("<%=txtEmployeeCode.ClientID%>").value; 
                       <%-- document.getElementById("<%=txtEmpId.ClientID%>").value = document.getElementById("<%=Txtemplyid.ClientID%>").value;--%>
                }

            </script>
            <asp:HiddenField ID="hiddenAccountTyp" runat="server" />



                  <style>
                      .ui-autocomplete {
                          padding: 0;
                          list-style: none;
                          background-color: #fff;
                          width: 218px;
                          border: 1px solid #B0BECA;
                          max-height: 135px;
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
                                  background-color: #D5E5F4;
                                  color: #161A1C;
                                  font-family: Calibri;
                              }
                      /*.form1 {
                          height: 30px;width: 250px;
                      }*/
                  </style>

    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />



    <script>
        var $au = jQuery.noConflict();

        $au(function () {
            $au('#cphMain_ddlBank').selectToAutocomplete1Letter();
        });

        function FocusDept(x){
            document.getElementById("cphMain_rbtnCropDept_"+x).focus();
        }
    </script>
  
  
       <script>
           function reload()
           {
               var CHK = document.getElementById("<%=cbxlCompzitModules.ClientID%>");

                    var checkbox = CHK.getElementsByTagName("input");

                    var label = CHK.getElementsByTagName("label");

                    for (var i = 0; i < checkbox.length; i++) {

                        if (checkbox[i].checked) {
                    
                            //  alert("Selected = " + checkbox[i].value);
                            if (checkbox[i].value.toString() == '1')//IF APP ADMINISTRATION
                            {
                                document.getElementById('divAccordionAppAdmin').style.display = "";
                            }
                            else if (checkbox[i].value.toString() == '2')//IF SALES FORCE AUTOMATION 
                            {
                                document.getElementById('divAccordionSFA').style.display = "";
                            }
                            else if (checkbox[i].value.toString() == '3')//IF AUTO WORKSHOP MANAGEMENT
                            {
                                document.getElementById('divAccordionAWMS').style.display = "";
                            }
                            else if (checkbox[i].value.toString() == '4')//IF GUARANTEE MANAGEMENT
                            {
                                document.getElementById('divAccordionGMS').style.display = "";
                            }
                            else if (checkbox[i].value.toString() == '5')//IF HUMAN CAPITAL MANAGEMENT
                            {
                                document.getElementById('divAccordionHCM').style.display = "";
                            }
                            else if (checkbox[i].value.toString() == '6')//IF FINANCE MANAGEMENT
                            {
                                document.getElementById('divAccordionFMS').style.display = "";
                            }
                            else if (checkbox[i].value.toString() == '7')//IF PROCUREMENT MANAGEMENT//PMS
                            {
                                document.getElementById('divAccordionPMS').style.display = "";
                            }


                        }

                    }
                    document.getElementById("myModalLoadingMail").style.display = "none";
            
                    document.getElementById("freezelayer").style.display = "none";

          
                    // alert(document.getElementById("<%=divLoginDetailsSection.ClientID%>").innerHTML);
                    if(document.getElementById("<%=divLoginDetailsSection.ClientID%>").style.display!="none" )
                    {
                        if(document.getElementById("<%=cbxMustLogin.ClientID%>").checked)
                        {
                            document.getElementById('divLoginDetailsContent').style.display = "block";
                            document.getElementById('lblEmployeeCode').innerText="Employee Id*";
                            document.getElementById('lblEmail').innerText="Email*";
                        }
                        else
                        {
                   
                            document.getElementById('divLoginDetailsContent').style.display = "none";
                           // document.getElementById('lblEmployeeCode').innerText="Employee Code";
                            document.getElementById('lblEmployeeCode').innerText="Employee Id*";
                            document.getElementById('lblEmail').innerText="Email";
                
                        }
            
                    }
                    if(document.getElementById("<%=divAutoWorkshopSection.ClientID%>").style.display!="none")
                    {
                        if(document.getElementById("<%=cbxMustAutoWorkshop.ClientID%>").checked)
                        {
                            document.getElementById('divAutoWorkshopContent').style.display = "block";
                        }
                        else
                        { 
                            document.getElementById('divAutoWorkshopContent').style.display = "none";
                
                        }
                        var LicenseTypeSlctdValues=document.getElementById("<%=hiddenLicenseTypeId.ClientID%>").value;
                        if(LicenseTypeSlctdValues!="")
                        {
                            var LicTypes = LicenseTypeSlctdValues.split(",");
                            //  alert('bla' +PreviousSlctdValues);
                            //    alert(LicTypes.length);
                            for (i = 0; i < LicTypes.length; i++) {
                                if(LicTypes[i].toString() !="")
                                {
                                    if( document.getElementById("divImageLicenseType-" + LicTypes[i]))
                                    {
                                        document.getElementById("divImageLicenseType-" + LicTypes[i]).style.border = ".5px solid";
                                        document.getElementById("divImageLicenseType-" + LicTypes[i]).style.backgroundColor = "rgb(56, 255, 128)";              
                
                                    }

                                }
                            }
                        }
                    }
                }
                </script>
    

  
      <script>
          function ClickCompzitModule() {
           
              IncrmntConfrmCounter();

              document.getElementById('divAccordionAppAdmin').style.display = "none";
              document.getElementById('divAccordionSFA').style.display = "none";
              document.getElementById('divAccordionAWMS').style.display = "none";
              document.getElementById('divAccordionGMS').style.display = "none";
              document.getElementById('divAccordionHCM').style.display = "none";
              document.getElementById('divAccordionFMS').style.display = "none";
              document.getElementById('divAccordionPMS').style.display = "none";


              var FramewrkId = '<%= Session["FRMWRK_ID"] %>';
              var FramewrkTyp = '<%= Session["FRMWRK_TYPE"] %>';
              if (FramewrkTyp == "1" && FramewrkId != "" && FramewrkId != null) {
                  document.getElementById('divAccordionAppAdmin').style.display = "";
                  document.getElementById('accordion-1').style.display = "block";
                  document.getElementById('cphMain_cbxlCompzitModules_0').checked = true;
                  document.getElementById('divCompzitModules').style.display = "none";
                  $("#lblAppAdmin").hide();
                  if (document.getElementById("<%=ddlUsrDsgn.ClientID%>").value == "--SELECT--" || document.getElementById("<%=ddlJobRole.ClientID%>").value == "--Select Job Role--") {
                      document.getElementById('accordion-1').style.display = "none";
                  }               
              }
              else {

                  var CHK = document.getElementById("<%=cbxlCompzitModules.ClientID%>");

                  var checkbox = CHK.getElementsByTagName("input");

                  var label = CHK.getElementsByTagName("label");

                  for (var i = 0; i < checkbox.length; i++) {

                      if (checkbox[i].checked) {

                          //  alert("Selected = " + checkbox[i].value);
                          if (checkbox[i].value.toString() == '1')//IF APP ADMINISTRATION
                          {
                              document.getElementById('divAccordionAppAdmin').style.display = "";
                          }
                          else if (checkbox[i].value.toString() == '2')//IF SALES FORCE AUTOMATION 
                          {
                              document.getElementById('divAccordionSFA').style.display = "";
                          }
                          else if (checkbox[i].value.toString() == '3')//IF AUTO WORKSHOP MANAGEMENT
                          {
                              document.getElementById('divAccordionAWMS').style.display = "";
                          }
                          else if (checkbox[i].value.toString() == '4')//IF AUTO WORKSHOP MANAGEMENT
                          {
                              document.getElementById('divAccordionGMS').style.display = "";
                          }
                          else if (checkbox[i].value.toString() == '5')//IF HUMAN CAPITAL MANAGEMENT
                          {
                              document.getElementById('divAccordionHCM').style.display = "";
                          }
                          else if (checkbox[i].value.toString() == '6')//IF FINANCE MANAGEMENT
                          {
                              document.getElementById('divAccordionFMS').style.display = "";
                          }
                          else if (checkbox[i].value.toString() == '7')//IF PROCUREMENT MANAGEMENT//PMS
                          {
                              document.getElementById('divAccordionPMS').style.display = "";
                          }

                      }

                  }
              }
            if(document.getElementById("<%=HiddenEmployeeMasterId.ClientID%>").value=="")
            {
                IsAdd();
            }
            return false;

        }
    
    </script>
    <script type="text/javascript">
        var $Tf = jQuery.noConflict();

        //----------------------------------SFA------------------------------------

        $Tf(function () {

            $Tf("[id*=TreeViewCompzit_SalesAutomation] input[type=checkbox]").bind("click", function () {
                IncrmntConfrmCounter();
                var Ftable = $Tf(this).closest("table");
                if (Ftable.next().length > 0 && Ftable.next()[0].tagName == "DIV") {
                    //Is Parent CheckBox
                    var FchildDiv = Ftable.next();
                    var isChecked = $Tf(this).is(":checked");
                    $Tf("input[type=checkbox]", FchildDiv).each(function () {
                        if (isChecked) {
                            $Tf(this).attr("checked", "checked");

                        } else {
                            $Tf(this).removeAttr("checked");

                        }
                    });



                    var FparentDIV = $Tf(this).closest("DIV");
                    if ($Tf("input[type=checkbox]:checked", FparentDIV).length > 0) {

                        $Tf("input[type=checkbox]", FparentDIV.prev()).attr("checked", "checked");


                        var FrootDiv = FparentDIV.parent();
                        $Tf("input[type=checkbox]", FrootDiv.prev()).attr("checked", "checked");
                    }
                    else {

                        $Tf("input[type=checkbox]", FparentDIV.prev()).removeAttr("checked");
                        var FrootDiv = FparentDIV.parent();
                        var FrootparentDIV = $Tf(FrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", FrootparentDIV).length > 0) {
                        }
                        else {
                            $Tf("input[type=checkbox]", FrootDiv.prev()).removeAttr("checked");
                            var FrootrootDiv = FrootparentDIV.parent();

                            var FrootrootparentDIV = $Tf(FrootrootDiv).closest("DIV");
                            if ($Tf("input[type=checkbox]:checked", FrootrootparentDIV).length > 0) {
                            }
                            else {
                                $Tf("input[type=checkbox]", FrootrootDiv.prev()).removeAttr("checked");
                                var FrootrootrootDiv = FrootrootparentDIV.parent();

                                var FrootrootrootparentDIV = $Tf(FrootrootrootDiv).closest("DIV");
                                if ($Tf("input[type=checkbox]:checked", FrootrootrootparentDIV).length > 0) {
                                }
                                else {
                                    $Tf("input[type=checkbox]", FrootrootrootDiv.prev()).removeAttr("checked");
                                }
                            }
                        }
                    }

                } else {


                    //Is Child CheckBox
                    var FparentDIV = $Tf(this).closest("DIV");


                    if ($Tf("input[type=checkbox]:checked", FparentDIV).length > 0) {
                        $Tf("input[type=checkbox]", FparentDIV.prev()).attr("checked", "checked");
                        var FrootDiv = FparentDIV.parent();
                        $Tf("input[type=checkbox]", FrootDiv.prevUntil()).attr("checked", "checked");
                        var FrootparentDIV = $Tf(FrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", FrootparentDIV).length > 0) {
                            $Tf("input[type=checkbox]", FrootparentDIV.prev()).attr("checked", "checked");
                            var FrootrootDiv = FrootparentDIV.parent();
                            $Tf("input[type=checkbox]", FrootrootDiv.prev()).attr("checked", "checked");
                        }
                        else {

                        }
                    }
                    else {

                        $Tf("input[type=checkbox]", FparentDIV.prev()).removeAttr("checked");
                        var FrootDiv = FparentDIV.parent();
                        var FrootparentDIV = $Tf(FrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", FrootparentDIV).length > 0) {
                        }
                        else {
                            $Tf("input[type=checkbox]", FrootDiv.prev()).removeAttr("checked");
                            var FrootrootDiv = FrootparentDIV.parent();

                            var FrootrootparentDIV = $Tf(FrootrootDiv).closest("DIV");
                            if ($Tf("input[type=checkbox]:checked", FrootrootparentDIV).length > 0) {
                            }
                            else {
                                $Tf("input[type=checkbox]", FrootrootDiv.prev()).removeAttr("checked");
                                var FrootrootrootDiv = FrootrootparentDIV.parent();

                                var FrootrootrootparentDIV = $Tf(FrootrootrootDiv).closest("DIV");
                                if ($Tf("input[type=checkbox]:checked", FrootrootrootparentDIV).length > 0) {
                                }
                                else {
                                    $Tf("input[type=checkbox]", FrootrootrootDiv.prev()).removeAttr("checked");
                                }
                            }
                        }
                    }
                }
            });

        });

        //----------------------------------APP------------------------------------

        $Tf(function () {

            $Tf("[id*=TreeViewCompzit_AppAdminstration] input[type=checkbox]").bind("click", function () {
                IncrmntConfrmCounter();
                var Ntable = $Tf(this).closest("table");
                if (Ntable.next().length > 0 && Ntable.next()[0].tagName == "DIV") {
                    //Is Parent CheckBox
                    var NchildDiv = Ntable.next();
                    var isChecked = $Tf(this).is(":checked");
                    $Tf("input[type=checkbox]", NchildDiv).each(function () {
                        if (isChecked) {
                            $Tf(this).attr("checked", "checked");

                        } else {
                            $Tf(this).removeAttr("checked");

                        }
                    });



                    var NparentDIV = $Tf(this).closest("DIV");
                    if ($Tf("input[type=checkbox]:checked", NparentDIV).length > 0) {
                        $Tf("input[type=checkbox]", NparentDIV.prev()).attr("checked", "checked");
                        var NrootDiv = NparentDIV.parent();
                        $Tf("input[type=checkbox]", NrootDiv.prev()).attr("checked", "checked");
                    }
                    else {

                        $Tf("input[type=checkbox]", NparentDIV.prev()).removeAttr("checked");
                        var NrootDiv = NparentDIV.parent();
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                        }
                        else {
                            $Tf("input[type=checkbox]", NrootDiv.prev()).removeAttr("checked");
                            var NrootrootDiv = NrootparentDIV.parent();

                            var NrootrootparentDIV = $Tf(NrootrootDiv).closest("DIV");
                            if ($Tf("input[type=checkbox]:checked", NrootrootparentDIV).length > 0) {
                            }
                            else {
                                $Tf("input[type=checkbox]", NrootrootDiv.prev()).removeAttr("checked");
                                var NrootrootrootDiv = NrootrootparentDIV.parent();

                                var NrootrootrootparentDIV = $Tf(NrootrootrootDiv).closest("DIV");
                                if ($Tf("input[type=checkbox]:checked", NrootrootrootparentDIV).length > 0) {
                                }
                                else {
                                    $Tf("input[type=checkbox]", NrootrootrootDiv.prev()).removeAttr("checked");
                                }
                            }
                        }
                    }

                } else {


                    //Is Child CheckBox
                    var NparentDIV = $Tf(this).closest("DIV");


                    if ($Tf("input[type=checkbox]:checked", NparentDIV).length > 0) {
                        $Tf("input[type=checkbox]", NparentDIV.prev()).attr("checked", "checked");
                        var NrootDiv = NparentDIV.parent();
                        $Tf("input[type=checkbox]", NrootDiv.prev()).attr("checked", "checked");
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                            $Tf("input[type=checkbox]", NrootparentDIV.prev()).attr("checked", "checked");
                            var NrootrootDiv = NrootparentDIV.parent();
                            $Tf("input[type=checkbox]", NrootrootDiv.prev()).attr("checked", "checked");
                        }
                        else {

                        }
                    }
                    else {

                        $Tf("input[type=checkbox]", NparentDIV.prev()).removeAttr("checked");
                        var NrootDiv = NparentDIV.parent();
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                        }
                        else {
                            $Tf("input[type=checkbox]", NrootDiv.prev()).removeAttr("checked");
                            var NrootrootDiv = NrootparentDIV.parent();

                            var NrootrootparentDIV = $Tf(NrootrootDiv).closest("DIV");
                            if ($Tf("input[type=checkbox]:checked", NrootrootparentDIV).length > 0) {
                            }
                            else {
                                $Tf("input[type=checkbox]", NrootrootDiv.prev()).removeAttr("checked");
                                var NrootrootrootDiv = NrootrootparentDIV.parent();

                                var NrootrootrootparentDIV = $Tf(NrootrootrootDiv).closest("DIV");
                                if ($Tf("input[type=checkbox]:checked", NrootrootrootparentDIV).length > 0) {
                                }
                                else {
                                    $Tf("input[type=checkbox]", NrootrootrootDiv.prev()).removeAttr("checked");
                                }
                            }
                        }
                    }
                }
            });

        });

        //----------------------------------AWMS------------------------------------

        $Tf(function () {

            $Tf("[id*=TreeViewCompzit_AutoWorkshopManagement] input[type=checkbox]").bind("click", function () {
                IncrmntConfrmCounter();
                var Ntable = $Tf(this).closest("table");
                if (Ntable.next().length > 0 && Ntable.next()[0].tagName == "DIV") {
                    //Is Parent CheckBox
                    var NchildDiv = Ntable.next();
                    var isChecked = $Tf(this).is(":checked");
                    $Tf("input[type=checkbox]", NchildDiv).each(function () {
                        if (isChecked) {
                            $Tf(this).attr("checked", "checked");

                        } else {
                            $Tf(this).removeAttr("checked");

                        }
                    });



                    var NparentDIV = $Tf(this).closest("DIV");
                    if ($Tf("input[type=checkbox]:checked", NparentDIV).length > 0) {
                        $Tf("input[type=checkbox]", NparentDIV.prev()).attr("checked", "checked");
                        var NrootDiv = NparentDIV.parent();
                        $Tf("input[type=checkbox]", NrootDiv.prev()).attr("checked", "checked");
                    }
                    else {

                        $Tf("input[type=checkbox]", NparentDIV.prev()).removeAttr("checked");
                        var NrootDiv = NparentDIV.parent();
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                        }
                        else {
                            $Tf("input[type=checkbox]", NrootDiv.prev()).removeAttr("checked");
                            var NrootrootDiv = NrootparentDIV.parent();

                            var NrootrootparentDIV = $Tf(NrootrootDiv).closest("DIV");
                            if ($Tf("input[type=checkbox]:checked", NrootrootparentDIV).length > 0) {
                            }
                            else {
                                $Tf("input[type=checkbox]", NrootrootDiv.prev()).removeAttr("checked");
                                var NrootrootrootDiv = NrootrootparentDIV.parent();

                                var NrootrootrootparentDIV = $Tf(NrootrootrootDiv).closest("DIV");
                                if ($Tf("input[type=checkbox]:checked", NrootrootrootparentDIV).length > 0) {
                                }
                                else {
                                    $Tf("input[type=checkbox]", NrootrootrootDiv.prev()).removeAttr("checked");
                                }
                            }
                        }
                    }

                } else {


                    //Is Child CheckBox
                    var NparentDIV = $Tf(this).closest("DIV");


                    if ($Tf("input[type=checkbox]:checked", NparentDIV).length > 0) {
                        $Tf("input[type=checkbox]", NparentDIV.prev()).attr("checked", "checked");
                        var NrootDiv = NparentDIV.parent();
                        $Tf("input[type=checkbox]", NrootDiv.prev()).attr("checked", "checked");
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                            $Tf("input[type=checkbox]", NrootparentDIV.prev()).attr("checked", "checked");
                            var NrootrootDiv = NrootparentDIV.parent();
                            $Tf("input[type=checkbox]", NrootrootDiv.prev()).attr("checked", "checked");
                        }
                        else {

                        }
                    }
                    else {

                        $Tf("input[type=checkbox]", NparentDIV.prev()).removeAttr("checked");
                        var NrootDiv = NparentDIV.parent();
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                        }
                        else {
                            $Tf("input[type=checkbox]", NrootDiv.prev()).removeAttr("checked");
                            var NrootrootDiv = NrootparentDIV.parent();

                            var NrootrootparentDIV = $Tf(NrootrootDiv).closest("DIV");
                            if ($Tf("input[type=checkbox]:checked", NrootrootparentDIV).length > 0) {
                            }
                            else {
                                $Tf("input[type=checkbox]", NrootrootDiv.prev()).removeAttr("checked");
                                var NrootrootrootDiv = NrootrootparentDIV.parent();

                                var NrootrootrootparentDIV = $Tf(NrootrootrootDiv).closest("DIV");
                                if ($Tf("input[type=checkbox]:checked", NrootrootrootparentDIV).length > 0) {
                                }
                                else {
                                    $Tf("input[type=checkbox]", NrootrootrootDiv.prev()).removeAttr("checked");
                                }
                            }
                        }
                    }
                }
            });

        });

        //----------------------------------GMS------------------------------------

        $Tf(function () {

            $Tf("[id*=TreeViewCompzit_GuaranteeManagement] input[type=checkbox]").bind("click", function () {
                IncrmntConfrmCounter();
                var Ntable = $Tf(this).closest("table");
                if (Ntable.next().length > 0 && Ntable.next()[0].tagName == "DIV") {
                    //Is Parent CheckBox
                    var NchildDiv = Ntable.next();
                    var isChecked = $Tf(this).is(":checked");
                    $Tf("input[type=checkbox]", NchildDiv).each(function () {
                        if (isChecked) {
                            $Tf(this).attr("checked", "checked");

                        } else {
                            $Tf(this).removeAttr("checked");

                        }
                    });



                    var NparentDIV = $Tf(this).closest("DIV");
                    if ($Tf("input[type=checkbox]:checked", NparentDIV).length > 0) {
                        $Tf("input[type=checkbox]", NparentDIV.prev()).attr("checked", "checked");
                        var NrootDiv = NparentDIV.parent();
                        $Tf("input[type=checkbox]", NrootDiv.prev()).attr("checked", "checked");
                    }
                    else {

                        $Tf("input[type=checkbox]", NparentDIV.prev()).removeAttr("checked");
                        var NrootDiv = NparentDIV.parent();
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                        }
                        else {
                            $Tf("input[type=checkbox]", NrootDiv.prev()).removeAttr("checked");
                            var NrootrootDiv = NrootparentDIV.parent();

                            var NrootrootparentDIV = $Tf(NrootrootDiv).closest("DIV");
                            if ($Tf("input[type=checkbox]:checked", NrootrootparentDIV).length > 0) {
                            }
                            else {
                                $Tf("input[type=checkbox]", NrootrootDiv.prev()).removeAttr("checked");
                                var NrootrootrootDiv = NrootrootparentDIV.parent();

                                var NrootrootrootparentDIV = $Tf(NrootrootrootDiv).closest("DIV");
                                if ($Tf("input[type=checkbox]:checked", NrootrootrootparentDIV).length > 0) {
                                }
                                else {
                                    $Tf("input[type=checkbox]", NrootrootrootDiv.prev()).removeAttr("checked");
                                }
                            }
                        }
                    }

                } else {


                    //Is Child CheckBox
                    var NparentDIV = $Tf(this).closest("DIV");


                    if ($Tf("input[type=checkbox]:checked", NparentDIV).length > 0) {
                        $Tf("input[type=checkbox]", NparentDIV.prev()).attr("checked", "checked");
                        var NrootDiv = NparentDIV.parent();
                        $Tf("input[type=checkbox]", NrootDiv.prev()).attr("checked", "checked");
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                            $Tf("input[type=checkbox]", NrootparentDIV.prev()).attr("checked", "checked");
                            var NrootrootDiv = NrootparentDIV.parent();
                            $Tf("input[type=checkbox]", NrootrootDiv.prev()).attr("checked", "checked");
                        }
                        else {

                        }
                    }
                    else {

                        $Tf("input[type=checkbox]", NparentDIV.prev()).removeAttr("checked");
                        var NrootDiv = NparentDIV.parent();
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                        }
                        else {
                            $Tf("input[type=checkbox]", NrootDiv.prev()).removeAttr("checked");
                            var NrootrootDiv = NrootparentDIV.parent();

                            var NrootrootparentDIV = $Tf(NrootrootDiv).closest("DIV");
                            if ($Tf("input[type=checkbox]:checked", NrootrootparentDIV).length > 0) {
                            }
                            else {
                                $Tf("input[type=checkbox]", NrootrootDiv.prev()).removeAttr("checked");
                                var NrootrootrootDiv = NrootrootparentDIV.parent();

                                var NrootrootrootparentDIV = $Tf(NrootrootrootDiv).closest("DIV");
                                if ($Tf("input[type=checkbox]:checked", NrootrootrootparentDIV).length > 0) {
                                }
                                else {
                                    $Tf("input[type=checkbox]", NrootrootrootDiv.prev()).removeAttr("checked");
                                }
                            }
                        }
                    }
                }
            });

        });

        //----------------------------------HCM------------------------------------

        $Tf(function () {

            $Tf("[id*=TreeViewCompzit_HumanCapitalManagement] input[type=checkbox]").bind("click", function () {
                IncrmntConfrmCounter();
                var Ntable = $Tf(this).closest("table");
                if (Ntable.next().length > 0 && Ntable.next()[0].tagName == "DIV") {
                    //Is Parent CheckBox
                    var NchildDiv = Ntable.next();
                    var isChecked = $Tf(this).is(":checked");
                    $Tf("input[type=checkbox]", NchildDiv).each(function () {
                        if (isChecked) {
                            $Tf(this).attr("checked", "checked");

                        } else {
                            $Tf(this).removeAttr("checked");

                        }
                    });



                    var NparentDIV = $Tf(this).closest("DIV");
                    if ($Tf("input[type=checkbox]:checked", NparentDIV).length > 0) {
                        $Tf("input[type=checkbox]", NparentDIV.prev()).attr("checked", "checked");
                        var NrootDiv = NparentDIV.parent();
                        $Tf("input[type=checkbox]", NrootDiv.prev()).attr("checked", "checked");
                    }
                    else {

                        $Tf("input[type=checkbox]", NparentDIV.prev()).removeAttr("checked");
                        var NrootDiv = NparentDIV.parent();
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                        }
                        else {
                            $Tf("input[type=checkbox]", NrootDiv.prev()).removeAttr("checked");
                            var NrootrootDiv = NrootparentDIV.parent();

                            var NrootrootparentDIV = $Tf(NrootrootDiv).closest("DIV");
                            if ($Tf("input[type=checkbox]:checked", NrootrootparentDIV).length > 0) {
                            }
                            else {
                                $Tf("input[type=checkbox]", NrootrootDiv.prev()).removeAttr("checked");
                                var NrootrootrootDiv = NrootrootparentDIV.parent();

                                var NrootrootrootparentDIV = $Tf(NrootrootrootDiv).closest("DIV");
                                if ($Tf("input[type=checkbox]:checked", NrootrootrootparentDIV).length > 0) {
                                }
                                else {
                                    $Tf("input[type=checkbox]", NrootrootrootDiv.prev()).removeAttr("checked");
                                }
                            }
                        }
                    }

                } else {


                    //Is Child CheckBox
                    var NparentDIV = $Tf(this).closest("DIV");


                    if ($Tf("input[type=checkbox]:checked", NparentDIV).length > 0) {
                        $Tf("input[type=checkbox]", NparentDIV.prev()).attr("checked", "checked");
                        var NrootDiv = NparentDIV.parent();
                        $Tf("input[type=checkbox]", NrootDiv.prev()).attr("checked", "checked");
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                            $Tf("input[type=checkbox]", NrootparentDIV.prev()).attr("checked", "checked");
                            var NrootrootDiv = NrootparentDIV.parent();
                            $Tf("input[type=checkbox]", NrootrootDiv.prev()).attr("checked", "checked");
                        }
                        else {

                        }
                    }
                    else {

                        $Tf("input[type=checkbox]", NparentDIV.prev()).removeAttr("checked");
                        var NrootDiv = NparentDIV.parent();
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                        }
                        else {
                            $Tf("input[type=checkbox]", NrootDiv.prev()).removeAttr("checked");
                            var NrootrootDiv = NrootparentDIV.parent();

                            var NrootrootparentDIV = $Tf(NrootrootDiv).closest("DIV");
                            if ($Tf("input[type=checkbox]:checked", NrootrootparentDIV).length > 0) {
                            }
                            else {
                                $Tf("input[type=checkbox]", NrootrootDiv.prev()).removeAttr("checked");
                                var NrootrootrootDiv = NrootrootparentDIV.parent();

                                var NrootrootrootparentDIV = $Tf(NrootrootrootDiv).closest("DIV");
                                if ($Tf("input[type=checkbox]:checked", NrootrootrootparentDIV).length > 0) {
                                }
                                else {
                                    $Tf("input[type=checkbox]", NrootrootrootDiv.prev()).removeAttr("checked");
                                }
                            }
                        }
                    }
                }
            });

        });

        //----------------------------------FMS------------------------------------

        $Tf(function () {

            $Tf("[id*=TreeViewCompzit_FinanceManagementSystem] input[type=checkbox]").bind("click", function () {
                IncrmntConfrmCounter();
                var Ntable = $Tf(this).closest("table");
                if (Ntable.next().length > 0 && Ntable.next()[0].tagName == "DIV") {
                    //Is Parent CheckBox
                    var NchildDiv = Ntable.next();
                    var isChecked = $Tf(this).is(":checked");
                    $Tf("input[type=checkbox]", NchildDiv).each(function () {
                        if (isChecked) {
                            $Tf(this).attr("checked", "checked");

                        } else {
                            $Tf(this).removeAttr("checked");

                        }
                    });



                    var NparentDIV = $Tf(this).closest("DIV");
                    if ($Tf("input[type=checkbox]:checked", NparentDIV).length > 0) {
                        $Tf("input[type=checkbox]", NparentDIV.prev()).attr("checked", "checked");
                        var NrootDiv = NparentDIV.parent();
                        $Tf("input[type=checkbox]", NrootDiv.prev()).attr("checked", "checked");
                    }
                    else {

                        $Tf("input[type=checkbox]", NparentDIV.prev()).removeAttr("checked");
                        var NrootDiv = NparentDIV.parent();
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                        }
                        else {
                            $Tf("input[type=checkbox]", NrootDiv.prev()).removeAttr("checked");
                            var NrootrootDiv = NrootparentDIV.parent();

                            var NrootrootparentDIV = $Tf(NrootrootDiv).closest("DIV");
                            if ($Tf("input[type=checkbox]:checked", NrootrootparentDIV).length > 0) {
                            }
                            else {
                                $Tf("input[type=checkbox]", NrootrootDiv.prev()).removeAttr("checked");
                                var NrootrootrootDiv = NrootrootparentDIV.parent();

                                var NrootrootrootparentDIV = $Tf(NrootrootrootDiv).closest("DIV");
                                if ($Tf("input[type=checkbox]:checked", NrootrootrootparentDIV).length > 0) {
                                }
                                else {
                                    $Tf("input[type=checkbox]", NrootrootrootDiv.prev()).removeAttr("checked");
                                }
                            }
                        }
                    }

                } else {


                    //Is Child CheckBox
                    var NparentDIV = $Tf(this).closest("DIV");


                    if ($Tf("input[type=checkbox]:checked", NparentDIV).length > 0) {
                        $Tf("input[type=checkbox]", NparentDIV.prev()).attr("checked", "checked");
                        var NrootDiv = NparentDIV.parent();
                        $Tf("input[type=checkbox]", NrootDiv.prev()).attr("checked", "checked");
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                            $Tf("input[type=checkbox]", NrootparentDIV.prev()).attr("checked", "checked");
                            var NrootrootDiv = NrootparentDIV.parent();
                            $Tf("input[type=checkbox]", NrootrootDiv.prev()).attr("checked", "checked");
                        }
                        else {

                        }
                    }
                    else {

                        $Tf("input[type=checkbox]", NparentDIV.prev()).removeAttr("checked");
                        var NrootDiv = NparentDIV.parent();
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                        }
                        else {
                            $Tf("input[type=checkbox]", NrootDiv.prev()).removeAttr("checked");
                            var NrootrootDiv = NrootparentDIV.parent();

                            var NrootrootparentDIV = $Tf(NrootrootDiv).closest("DIV");
                            if ($Tf("input[type=checkbox]:checked", NrootrootparentDIV).length > 0) {
                            }
                            else {
                                $Tf("input[type=checkbox]", NrootrootDiv.prev()).removeAttr("checked");
                                var NrootrootrootDiv = NrootrootparentDIV.parent();

                                var NrootrootrootparentDIV = $Tf(NrootrootrootDiv).closest("DIV");
                                if ($Tf("input[type=checkbox]:checked", NrootrootrootparentDIV).length > 0) {
                                }
                                else {
                                    $Tf("input[type=checkbox]", NrootrootrootDiv.prev()).removeAttr("checked");
                                }
                            }
                        }
                    }
                }
            });

        });

        //----------------------------------PMS------------------------------------

        $Tf(function () {

            $Tf("[id*=TreeViewCompzit_ProcurementManagementSystem] input[type=checkbox]").bind("click", function () {
                IncrmntConfrmCounter();
                var Ntable = $Tf(this).closest("table");
                if (Ntable.next().length > 0 && Ntable.next()[0].tagName == "DIV") {
                    //Is Parent CheckBox
                    var NchildDiv = Ntable.next();
                    var isChecked = $Tf(this).is(":checked");
                    $Tf("input[type=checkbox]", NchildDiv).each(function () {
                        if (isChecked) {
                            $Tf(this).attr("checked", "checked");

                        } else {
                            $Tf(this).removeAttr("checked");

                        }
                    });



                    var NparentDIV = $Tf(this).closest("DIV");
                    if ($Tf("input[type=checkbox]:checked", NparentDIV).length > 0) {
                        $Tf("input[type=checkbox]", NparentDIV.prev()).attr("checked", "checked");
                        var NrootDiv = NparentDIV.parent();
                        $Tf("input[type=checkbox]", NrootDiv.prev()).attr("checked", "checked");
                    }
                    else {

                        $Tf("input[type=checkbox]", NparentDIV.prev()).removeAttr("checked");
                        var NrootDiv = NparentDIV.parent();
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                        }
                        else {
                            $Tf("input[type=checkbox]", NrootDiv.prev()).removeAttr("checked");
                            var NrootrootDiv = NrootparentDIV.parent();

                            var NrootrootparentDIV = $Tf(NrootrootDiv).closest("DIV");
                            if ($Tf("input[type=checkbox]:checked", NrootrootparentDIV).length > 0) {
                            }
                            else {
                                $Tf("input[type=checkbox]", NrootrootDiv.prev()).removeAttr("checked");
                                var NrootrootrootDiv = NrootrootparentDIV.parent();

                                var NrootrootrootparentDIV = $Tf(NrootrootrootDiv).closest("DIV");
                                if ($Tf("input[type=checkbox]:checked", NrootrootrootparentDIV).length > 0) {
                                }
                                else {
                                    $Tf("input[type=checkbox]", NrootrootrootDiv.prev()).removeAttr("checked");
                                }
                            }
                        }
                    }

                } else {


                    //Is Child CheckBox
                    var NparentDIV = $Tf(this).closest("DIV");


                    if ($Tf("input[type=checkbox]:checked", NparentDIV).length > 0) {
                        $Tf("input[type=checkbox]", NparentDIV.prev()).attr("checked", "checked");
                        var NrootDiv = NparentDIV.parent();
                        $Tf("input[type=checkbox]", NrootDiv.prev()).attr("checked", "checked");
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                            $Tf("input[type=checkbox]", NrootparentDIV.prev()).attr("checked", "checked");
                            var NrootrootDiv = NrootparentDIV.parent();
                            $Tf("input[type=checkbox]", NrootrootDiv.prev()).attr("checked", "checked");
                        }
                        else {

                        }
                    }
                    else {

                        $Tf("input[type=checkbox]", NparentDIV.prev()).removeAttr("checked");
                        var NrootDiv = NparentDIV.parent();
                        var NrootparentDIV = $Tf(NrootDiv).closest("DIV");
                        if ($Tf("input[type=checkbox]:checked", NrootparentDIV).length > 0) {
                        }
                        else {
                            $Tf("input[type=checkbox]", NrootDiv.prev()).removeAttr("checked");
                            var NrootrootDiv = NrootparentDIV.parent();

                            var NrootrootparentDIV = $Tf(NrootrootDiv).closest("DIV");
                            if ($Tf("input[type=checkbox]:checked", NrootrootparentDIV).length > 0) {
                            }
                            else {
                                $Tf("input[type=checkbox]", NrootrootDiv.prev()).removeAttr("checked");
                                var NrootrootrootDiv = NrootrootparentDIV.parent();

                                var NrootrootrootparentDIV = $Tf(NrootrootrootDiv).closest("DIV");
                                if ($Tf("input[type=checkbox]:checked", NrootrootrootparentDIV).length > 0) {
                                }
                                else {
                                    $Tf("input[type=checkbox]", NrootrootrootDiv.prev()).removeAttr("checked");
                                }
                            }
                        }
                    }
                }
            });

        });


        $(function() {
            $("div.star-rating > s, div.star-rating-rtl > s").on("click", function(e) {
                // remove all active classes first, needed if user clicks multiple times
                $(this).closest('div').find('.active').removeClass('active');

                $(e.target).parentsUntil("div").addClass('active'); // all elements up from the clicked one excluding self
                $(e.target).addClass('active');  // the element user has clicked on


                var numStars = $(e.target).parentsUntil("div").length+1;
                document.getElementById("<%=HiddenFluency.ClientID%>").value =numStars;
               
                $('.show-result').text(numStars + (numStars == 1 ? " star" : " stars!"));
            });

         });

        function selectingstar(count)
        {
            if(count==0||count=="")
            {
                $('#s1').closest('div').find('.active').removeClass('active'); 
            }
            else
            {
                $('#'+ count).closest('div').find('.active').removeClass('active');
                $('#'+count).parentsUntil("div").addClass('active'); // all elements up from the clicked one excluding self
                $('#'+count).addClass('active');  
            }// the element user has clicked on
        }
      

        
        function PrimaryChange(i){
            
            document.getElementById("<%=hiddendeptchng.ClientID%>").value="";
            document.getElementById("<%=hiddenPrimaryDivision.ClientID%>").value="";

          
            document.getElementById("cphMain_cbxlCorporateDvsn_" +i).checked = true; 


            if( document.getElementById("radioDivision"+i).checked==true)
            {
               
                document.getElementById("<%=hiddenPrimaryDivision.ClientID%>").value=  document.getElementById("cphMain_cbxlCorporateDvsn_" +i).value;
                document.getElementById("lblPrimary"+i).innerHTML="Primary";
            }
            else
            {
                document.getElementById("lblPrimary"+i).innerHTML="";
               
            }
          
            cbxSelected();
          
            var Elements=document.getElementsByClassName('divcls');
            for(var j=0;Elements[j];j++){
                if(i!=j)
                {
                    document.getElementById("radioDivision"+j).checked=false;
                    document.getElementById("lblPrimary"+j).innerHTML="";
                }
               
               
            }


        }

        function ValidatePrimaryDivsn(){//evm-20

            var ret=true;

            var cnt=0;

            if(document.getElementById("<%=HiddenDivision.ClientID%>").value!="" && document.getElementById("<%=HiddenDivision.ClientID%>").value!="0"){

               // alert(document.getElementById("<%=hiddendeptchng.ClientID%>").value);

                if(document.getElementById("<%=hiddendeptchng.ClientID%>").value==""){

                    var table = document.getElementById('cphMain_cbxlCorporateDvsn');

                    for (var i = 0; i < table.rows.length; i++) {
                        if(document.getElementById("radioDivision"+i).checked==true)
                        {

                            if(document.getElementById("cphMain_cbxlCorporateDvsn_" +i).checked == true){

                                cnt++;
                            }
                        }
                    }
                    //EVM-0027
                    
                    //if(cnt==0){
                    //    alert("Primary division must be selected!");
                       
                      //  ret=false;
                    // }
                    //END
                }
            }
            return ret;
        }

        //EVM-0027

        function checkRadioPrimary(id){

            var Elements=document.getElementsByClassName('divcls');

            for(var j=0;Elements[j];j++){
                if(document.getElementById("cphMain_cbxlCorporateDvsn_" +j).value==id){
                    document.getElementById("radioDivision"+j).checked=true;
                    document.getElementById("lblPrimary"+j).innerHTML="Primary";
                }
            }
        }

//END

    </script>
    
   
    <%--evm-0023-20-2--%>
<script>
    function AllowAlphaNumeric(e)
    {

       var specialKeys = new Array();
        specialKeys.push(8);  //Backspace
        specialKeys.push(9);  //Tab
        specialKeys.push(46); //Delete
        specialKeys.push(36); //Home
        specialKeys.push(35); //End
        specialKeys.push(37); //Left
        specialKeys.push(39); //Right

        var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
        var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || keyCode == 32 || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));     
        return ret;
    }

    function BlurAllowAlphaNumeric()
    {
        value=document.getElementById("cphMain_txtIban").value;        
        value = value.replace(/[^a-z0-9]/gi,'');        
        document.getElementById("cphMain_txtIban").value = value;
    }

</script>

</asp:Content>



