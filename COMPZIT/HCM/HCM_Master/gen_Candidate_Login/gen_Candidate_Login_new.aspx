<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gen_Candidate_Login_new.aspx.cs" Inherits="HCM_HCM_Master_gen_Candidate_Login_gen_Candidate_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style> 
        /*login form*/
.Login_12
{
	border:#CCC solid 1px;
	background-color:#e3e2e2;
	width:100%;
	height:180px;
	margin-left:3px;
	
	
}
.Login_12_text
{

 font-size:18px; 
 font-family:Verdana, Geneva, sans-serif;
 width: 53%; 
 color: darkgray;
 margin-top:4.5%;
 margin-left: 30%;
}
.user_sty
{
 font-size:15px; 
 font-family:Verdana, Geneva, sans-serif;
 width: 53%; 
 color:#666666;
 margin-top:6%;
 margin-left:6%;
}
.form3 {
    width:55%;
    height: 28px;
    border: 1px solid #cfcccc;
    color: #000;
    font-size: 13px;
	/*margin-left:30%;*/
	float:left;
	margin:-5% 0 0 30%;
}
.red
{color:#F00;}
.submit_sty
{
	width:100px;
	height:35px;
	margin:0 0 0 45%;
	font-size:16px;
	font-weight:700;
	background-color:#97C83A;
	border:none;
	color:#FFF;
}
.submit_sty:hover
{
	border:#FFF solid 1px;
	text-align:center;
}

 @media only screen and (max-width:500px)

{
	.Login_12
{
	border:#CCC solid 1px;
	background-color:#e3e2e2;
	width:100%;
	height:180px;
	margin-left:3px;
	
	
}
.Login_12_text
{

 font-size:14px; 
 font-family:Verdana, Geneva, sans-serif;
 text-align:center;
 width: 53%; 
 color: darkgray;
 margin-top:5%;
 margin-left:10%;
}
.user_sty
{
 font-size:15px; 
 font-family:Verdana, Geneva, sans-serif;
 width: 53%; 
 color:#666666;
 margin-top:6%;
 margin-left:3%;
 margin-bottom:5%;
}
.form3 {
    width:55%;
    height: 28px;
    border: 1px solid #cfcccc;
    color: #000;
    font-size: 13px;
	/*margin-left:30%;*/
	float:left;
	margin:0 0 0 0;
}
.red
{color:#F00;}
.submit_sty
{
	width:100px;
	height:35px;
	margin:0 0 0 33%;
	font-size:16px;
	font-weight:700;
	background-color:#97C83A;
	border:none;
	color:#FFF;
	margin-top:2%;
}
.submit_sty:hover
{
	border:#FFF solid 1px;
	text-align:center;
}
}
    </style>
     <style>
               .BODYAREA1 {
                   width: 100%;
height: auto;
/*background: url(/../../../Images/Design_Images/images/ulli2/candidatelogin.jpg) no-repeat center top;*/

               }

               .LOGIN1 {
                 width: 500px;
                 /*background: url(/../../../Images/Design_Images/images/ulli2/candidatelogin.jpg) no-repeat center top;*/

    /*background: rgba(17, 17, 17, 0.7);;*/
    display: inline-block;
    padding: 36px 0 38px;
    border: 1px solid #e4e6e8;
background: #FFF;

}
           </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="BODYAREA1">
            <asp:HiddenField ID="hiddenCorpList" runat="server" />
              <asp:HiddenField ID="HiddenConfirm" runat="server" />
           
                <div class="loginarea">
                    <div class="logo">

                    </div>
                    <div class="col-lg-3 Login_12" >
                         <h1 class="Login_12_text">Candidate Login</h1>
             
                        <div >
                            <h1 class="user_sty">Candidate Id<span class="red"> *</span></h1>
                            <asp:TextBox ID="txtcandidate" class="form3 form1" style="margin-left: 33%;" runat="server"></asp:TextBox>

                        </div>
                        <br/>
                            <div >
                        <asp:Label ID="Label1" runat="server" Text="" style="float: left;margin-left: 48%;font-family: calibri;font-size: 13px;color: red;"></asp:Label>

                            <asp:Button ID="btnLogin" Text="Submit" runat="server" class="submit_sty" OnClick="SignIn_Click"/>

                        </div>
                        


               

                    </div>
                </div>
            </div>
    </div>
    </form>
</body>
</html>
