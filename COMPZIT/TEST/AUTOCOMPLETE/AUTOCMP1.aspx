<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AUTOCMP1.aspx.cs" Inherits="TEST_AUTOCOMPLETE_AUTOCMP1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
	<script src="../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
	<script src="../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
	<script>
	    (function ($) {
	        $(function () {
	            $('#ddlTest').selectToAutocomplete();
	            $('form').submit(function () {
	                alert($(this).serialize());
	                document.getElementById('Label1').innerHTML = $(this).serialize();
	                return false;
	            });
	        });
	    })(jQuery);
	    function Validate() {

	        var ddlC = document.getElementById("<%=ddlTest.ClientID%>");

	        var ddl = ddlC.options[ddlC.selectedIndex].value;
	        alert(ddl);
	        return false;
	    }
	</script>
	<link rel="stylesheet" href="../../css/Autocomplete/jquery-ui.css">
	<style>
	  body {
	    font-family: Arial, Verdana, sans-serif;
	    font-size: 13px;
	  }
    .ui-autocomplete {
      padding: 0;
      list-style: none;
      background-color: #fff;
      width: 218px;
      border: 1px solid #B0BECA;
      max-height: 350px;
      overflow-x: hidden;
    }
    .ui-autocomplete .ui-menu-item {
      border-top: 1px solid #B0BECA;
      display: block;
      padding: 4px 6px;
      color: #353D44;
      cursor: pointer;
    }
    .ui-autocomplete .ui-menu-item:first-child {
      border-top: none;
    }
    .ui-autocomplete .ui-menu-item.ui-state-focus {
      background-color: #D5E5F4;
      color: #161A1C;
    }
	</style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
     <select name="Country" id="country-selector" autofocus="autofocus" autocorrect="on" autocomplete="on">
      <option value="" selected="selected">Select Country</option>
      <option value="Afghanistan" data-alternative-spellings="AF افغانستان">Afghanistan</option>
      <option value="Åland Islands" data-alternative-spellings="AX Aaland Aland" data-relevancy-booster="0.5">Åland Islands</option>
      <option value="1" data-alternative-spellings="AL">Albania</option>
      <option value="Algeria" data-alternative-spellings="DZ الجزائر">Algeria</option>
      <option value="American Samoa" data-alternative-spellings="AS" data-relevancy-booster="0.5">American Samoa</option>
      <option value="Andorra" data-alternative-spellings="AD" data-relevancy-booster="0.5">Andorra</option>
      <option value="Angola" data-alternative-spellings="AO">Angola</option>
      <option value="Anguilla" data-alternative-spellings="AI" data-relevancy-booster="0.5">Anguilla</option>
      <option value="Antarctica" data-alternative-spellings="AQ" data-relevancy-booster="0.5">Antarctica</option>
      <option value="Antigua And Barbuda" data-alternative-spellings="AG" data-relevancy-booster="0.5">Antigua And Barbuda</option>
      <option value="Argentina" data-alternative-spellings="AR">Argentina</option>
      <option value="Armenia" data-alternative-spellings="AM Հայաստան">Armenia</option>
      <option value="Aruba" data-alternative-spellings="AW" data-relevancy-booster="0.5">Aruba</option>
      <option value="Australia" data-alternative-spellings="AU" data-relevancy-booster="1.5">Australia</option>
      <option value="Austria" data-alternative-spellings="AT Österreich Osterreich Oesterreich ">Austria</option>
      <option value="Azerbaijan" data-alternative-spellings="AZ">Azerbaijan</option>
      <option value="Bahamas" data-alternative-spellings="BS">Bahamas</option>
      <option value="Bahrain" data-alternative-spellings="BH البحرين">Bahrain</option>
      <option value="Bangladesh" data-alternative-spellings="BD বাংলাদেশ" data-relevancy-booster="2">Bangladesh</option>
      <option value="Barbados" data-alternative-spellings="BB">Barbados</option>
      <option value="Belarus" data-alternative-spellings="BY Беларусь">Belarus</option>
      <option value="Belgium" data-alternative-spellings="BE België Belgie Belgien Belgique" data-relevancy-booster="1.5">Belgium</option>
      <option value="Belize" data-alternative-spellings="BZ">Belize</option>
      <option value="Benin" data-alternative-spellings="BJ">Benin</option>
      <option value="Bermuda" data-alternative-spellings="BM" data-relevancy-booster="0.5">Bermuda</option>
      <option value="Bhutan" data-alternative-spellings="BT भूटान">Bhutan</option>
      <option value="Bolivia" data-alternative-spellings="BO">Bolivia</option>
      <option value="Bonaire, Sint Eustatius and Saba" data-alternative-spellings="BQ">Bonaire, Sint Eustatius and Saba</option>
      <option value="Bosnia and Herzegovina" data-alternative-spellings="BA BiH Bosna i Hercegovina Босна и Херцеговина">Bosnia and Herzegovina</option>
      <option value="Botswana" data-alternative-spellings="BW">Botswana</option>
      <option value="Bouvet Island" data-alternative-spellings="BV">Bouvet Island</option>
      <option value="Brazil" data-alternative-spellings="BR Brasil" data-relevancy-booster="2">Brazil</option>
      <option value="British Indian Ocean Territory" data-alternative-spellings="IO">British Indian Ocean Territory</option>
      <option value="Brunei Darussalam" data-alternative-spellings="BN">Brunei Darussalam</option>
      <option value="Bulgaria" data-alternative-spellings="BG България">Bulgaria</option>
      <option value="Burkina Faso" data-alternative-spellings="BF">Burkina Faso</option>
      <option value="Burundi" data-alternative-spellings="BI">Burundi</option>
      <option value="Cambodia" data-alternative-spellings="KH កម្ពុជា">Cambodia</option>
      <option value="Cameroon" data-alternative-spellings="CM">Cameroon</option>
      <option value="Canada" data-alternative-spellings="CA" data-relevancy-booster="2">Canada</option>
      <option value="Cape Verde" data-alternative-spellings="CV Cabo">Cape Verde</option>
      <option value="Cayman Islands" data-alternative-spellings="KY" data-relevancy-booster="0.5">Cayman Islands</option>
      <option value="Central African Republic" data-alternative-spellings="CF">Central African Republic</option>
      <option value="Chad" data-alternative-spellings="TD تشاد‎ Tchad">Chad</option>
      <option value="Chile" data-alternative-spellings="CL">Chile</option>
      <option value="China" data-relevancy-booster="3.5" data-alternative-spellings="CN Zhongguo Zhonghua Peoples Republic 中国/中华">China</option>
      <option value="Christmas Island" data-alternative-spellings="CX" data-relevancy-booster="0.5">Christmas Island</option>
      <option value="Cocos (Keeling) Islands" data-alternative-spellings="CC" data-relevancy-booster="0.5">Cocos (Keeling) Islands</option>
      <option value="Colombia" data-alternative-spellings="CO">Colombia</option>
      <option value="Comoros" data-alternative-spellings="KM جزر القمر">Comoros</option>
      <option value="Congo" data-alternative-spellings="CG">Congo</option>
           <option value="Zambia" data-alternative-spellings="ZM">Zambia</option>
      <option value="Zimbabwe" data-alternative-spellings="ZW">Zimbabwe</option>
    </select>
    
        <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="return Validate();"/>
        <asp:DropDownList ID="ddlTest" runat="server">
             <asp:ListItem Value=""><select></asp:ListItem>
            <asp:ListItem Value="1">first</asp:ListItem>
            <asp:ListItem Value="2">second</asp:ListItem>
            <asp:ListItem Value="3">Third</asp:ListItem>
            <asp:ListItem Value="4">four</asp:ListItem>
            <asp:ListItem Value="5">five</asp:ListItem>
            <asp:ListItem Value="6">six</asp:ListItem>
            <asp:ListItem Value="7">seven</asp:ListItem>
        </asp:DropDownList>
        <div>
            <a href="../TEST_TABLE/test.aspx">sdf</a>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
