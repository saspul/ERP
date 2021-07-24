<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_App.master" AutoEventWireup="true" CodeFile="Compzit_Home_App.aspx.cs" Inherits="MasterPage_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style>
        .bg_ul li {
            /*padding-top:34px;*/
        }

        .ullis {
            padding-bottom: 3px;
        }

        .imgborder {
            display: inline-block;
            position: relative;
            border: 1px solid #a1cbac;
            padding: 3px;
            background: #deefe2;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <div style="width: 40%; float: left; text-align: right;">

        <div class="pacq">
            <!--<a href=""><div class="lic_pack"></div></a>
                	<a href=""><div class="corp_pack"></div></a>
                	<a href=""><div class="master"></div></a>
                	<a href=""><div class="workstn"></div></a>-->
         
            <span id="AncrImageCorp" runat="server" visible="false"><a href="/Master/app_CorporatePack/app_CorporatePackList.aspx">
                <img class="imgborder" src="/Images/Design_Images/images/corp_pack.png" /></a></span>
              <span id="AncrImageLic" runat="server" visible="false"><a href="/Master/app_LicensePack/app_LicensePackList.aspx">
                <img class="imgborder" src="/Images/Design_Images/images/lic_pack.png" /></a></span>
             <span id="AncrImageCountry" runat="server" visible="false"><a href="/Master/gen_Country/gen_CountryList.aspx">
                <img class="imgborder" src="/Images/Design_Images/images/master.png" /></a></span>
            <span id="AncrImageWorkstn" runat="server" visible="false"><a href="/Master/gen_WorkStation/gen_WorkStationList.aspx">
                <img class="imgborder" src="/Images/Design_Images/images/workstn.png" /></a></span>
        </div>

    </div>


    <div id="divRightList" runat="server">
        <%-- <div class="ullis_new" >
                	<ul class="bg_ul_new">
                    	<li class="li_1"><a href="" class="a_1">Organization Types</a></li>
                    	<li class="li_2"><a href="" class="a_2">Organization Verification</a></li>
                    	<li class="li_3"><a href="" class="a_3">Corporate Type</a></li>
                    	<li class="li_4"><a href="" class="a_4">Corporate Definition</a></li>
                    	<li class="li_5"><a href="" class="a_5">Corporate Department</a></li>
                    	<li class="li_6"><a href="" class="a_6">Premise Definition</a></li>
                    	<li class="li_7"><a href="" class="a_7">Premise-Area Definition</a></li>
                    </ul>
                </div>--%>
    </div>
</asp:Content>

