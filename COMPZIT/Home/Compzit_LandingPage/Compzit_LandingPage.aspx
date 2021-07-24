<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Compzit_LandingPage.aspx.cs" Inherits="Home_Compzit_LandingPage_Compzit_LandingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Compzit</title>
     <link rel="shortcut icon" href="/css/Login/image/short-icon.png"/>

    <link rel="stylesheet" type="text/css" href="/css/Design-CSS/main.css" />
    <link rel="stylesheet" type="text/css" href="/css/Design-CSS/responsive.css" />


    
      
    <style>
        .app_sales {
            margin: 155.8px 0px 155px;
            width: 1148px;
            height:495px;
        }
        .app_admin {
            width:210px;
        }
        .sales {
             width:210px;
             margin: 0 15px 0 0 !important;
        }
        .workshop {
             width:210px;
             margin: 0 15px 0 0 !important;
        }
          .Guarantee {
            width: 210px;
            margin: 0 15px 0 0 !important;
        }
          .Hcm {
            width: 210px;
            margin: 0 15px 0 0 !important;
        }

        #hcmImage:hover {
            width: 215px;
        }
        
        #appImage:hover {
            width: 215px;
        }
        
        #salesImage:hover {
            width: 215px;
        }
        
        #workImage:hover {
            width: 215px;
        }
       #guarImage:hover {
            width: 215px;
        }
    </style>

</head>
<body>
    <div class="bodyarea">
        <div class="auto">
            <div class="login2">
                <a href="">
                    <img src="/Images/Design_Images/images/logo.png" class="logo_img" /></a>
            </div>
            <div class="login2">
                <div class="app_sales">

                    <a id="DivAppIcon" runat="server" href="/Home/Compzit_Home/Compzit_Home_App.aspx">
                        <img id="appImage" class="app_admin" src="/Images/Design_Images/images/app_admin.png" /></a>


                    <a id="divSalesIcon" runat="server" href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">
                        <img id="salesImage" class="sales" src="/Images/Design_Images/images/sales.png" /></a>

                    
                    <a id="divAwmsIcon" runat="server" href="/Home/Compzit_Home/Compzit_Home_Awms.aspx">
                        <img id="workImage" class="workshop" src="/Images/Design_Images/images/workshop.png" /></a>

                       <a id="divGmsIcon" runat="server" href="/Home/Compzit_Home/Compzit_Home_Gms.aspx">
                        <img id="guarImage" class="Guarantee" src="/Images/Design_Images/images/GUARANTEE MANAGEMENT ICON 2.png" /></a>


                    <a id="divHcmIcon" runat="server" href="/Home/Compzit_Home/Compzit_Home_Hcm.aspx">
                        <img id="hcmImage" class="Hcm" src="/Images/Design_Images/images/HumanCapitalManagement.png" /></a>

                    
                       <a id="divFinanceIcon" runat="server" href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">
                        <img id="fmsImage" class="Hcm" src="/Images/Design_Images/images/FMS.png" /></a>

                        <a id="divProcuremntIcon" runat="server" href="/Home/Compzit_Home/Compzit_Home_Pms.aspx">
                        <img id="pmsImage" class="Hcm" src="/Images/Design_Images/images/PMS.png" /></a>
                  
                </div>
                
            </div>
        </div>

        <div class="footer">
            <div class="auto">
                <h3 id="divcopyright" runat="server">© 2016 Copyright</h3>
                <h4 id="divdevelop" runat="server">Developed by</h4>
            </div>
        </div>
    </div>
</body>
</html>
