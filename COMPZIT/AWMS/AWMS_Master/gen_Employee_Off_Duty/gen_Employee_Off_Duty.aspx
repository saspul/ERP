<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Employee_Off_Duty.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Employee_Off_duty_gen_Employee_Off_duty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
    <style>
table, th {
    border: 1px solid black;
    padding: 0px;
}
table {
    background-color:peachpuff;
    border-spacing: 0px;
}

        td {
                border: 1px solid black;
    padding: 5px;
            background-color:white;
        }
        .selected {
            background-color: #f67d26;
        }
         .hover {
            background-color: #ff4e00;
            cursor:pointer;
        }
        div.product:last-child {
	margin:0px;
}

div.day:hover {
	border:1px solid #878787;
	-moz-border-radius:3px;
	border-radius:3px;
}

div.day.unselected {
	opacity:0.6;
	filter:alpha(opacity=60);
  background color:red;
}

div.day.selected {
	border:1px solid #32a24e;
	-moz-border-radius:3px;
	border-radius:3px;
}
</style>

    <script type="text/javascript">
        var $a = jQuery.noConflict();
        $a(window).load(function () {
            var total;
            var num;
            var c="";
            //  
            if (document.getElementById('<%=hiddenweeklydataforload.ClientID %>').value != "")
            {
               
                 c = document.getElementById('<%=hiddenweeklydataforload.ClientID %>').value;
             //  alert(c);
               
                tableload(c);
               
            }
           // alert("hi");
            if (document.getElementById('<%=hiddenmonthlydataforload.ClientID %>').value != "")
            {
             //   alert("hi mnth1");
                for (i = 0; i < 6; i++)
                {
                    if (i == 0)
                    {
                       // alert("hi mnth1");
                        c = document.getElementById('<%=hiddenmonthlydataforload1.ClientID %>').value;
                      //  alert("hi mnth1");
                        // alert(c+'first');
                        tableload1(c);

                    }
                    if (i== 1)
                    {
                       // alert("hi mnth2");
                        c = document.getElementById('<%=hiddenmonthlydataforload2.ClientID %>').value;
                        tableload2(c);
                    }
                    if (i == 2)
                    {
                        c = document.getElementById('<%=hiddenmonthlydataforload3.ClientID %>').value;
                        tableload3(c);
                    }
                    if (i == 3)
                    {
                        c = document.getElementById('<%=hiddenmonthlydataforload4.ClientID %>').value;

                        tableload4(c);
                    }
                    if (i == 4)
                    {
                        c = document.getElementById('<%=hiddenmonthlydataforload5.ClientID %>').value;

                        tableload5(c);
                    }
                    if (i == 5)
                    {
                        c = document.getElementById('<%=hiddenmonthlydataforload6.ClientID %>').value;

                        tableload6(c);
                    }
                }
              }






          //  var tableslis="";
            $a("table").on("click", "td", function () {
              //  document.getElementById('<%=saveOffduty.ClientID %>').removeAttribute('disabled');
            //    document.getElementById('<%=saveOffduty.ClientID %>').removeAttribute('disabled');
                $a(this).toggleClass('selected');
               
              
                var $parentTr = $a(this).closest('tr');
                total = "";
               // tableslis = "";
               // tableslist = [];
                $parentTr.find('.selected').each(function () {
                    
                    //tableslis += ($a(this).closest('table').attr('id'));
                    //tableslist.toString();

                
                 
                    num = $a(this).text();
                    if (num == 'SUN') {
                        // alert('1');
                        total += ',1'
                    }
                    else if (num == 'MON') {
                        // alert('2');
                        total += ',2'
                    }
                    else if (num == 'TUE') {
                        // alert('3');
                        total +=',3'
                    }
                    else if (num == 'WED') {
                        // alert('3');
                        total += ',4'
                    }
                    else if (num == 'THUR') {
                        // alert('3');
                        total += ',5'
                    }
                    else if (num == 'FRI') {
                        // alert('3');
                        total += ',6'
                    }
                    else if (num == 'SAT') {
                        // alert('3');
                        total += ',7'
                    }
                 //   var result = total.slice(1, -1);
                  //  tableslist.push(tableslis);
                   // alert(total.toString());

                  //  document.getElementById('<%=hiddenweeklydata.ClientID %>').value = total;
                    
                  //  alert(result.toString());
                });
              //   alert(result.toString());
              //  alert(tableslist.toString());
            });
            
            $a("table").on("hover", "td", function () {

                $a(this).toggleClass('hover');
                //alert("SSXF");
            
               
            });

     
            
           
        });
    
      
       

         </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
     <asp:HiddenField ID="hiddenCancelReason" runat="server" />
    <asp:HiddenField ID="hiddenRoleReOpen" runat="server" />
        <div class="cont_rght"  width:100%>
             <div id="divMessageArea" style="display: none; margin:0px 0 13px;">
                 <img id="imgMessageArea" src="" >
                <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>

     <br />
    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;margin-top: 0%;">
            <img src="/Images/BigIcons/Employee-Off-Duty.png" style="vertical-align: middle;">
            Employee Off Duty
        </div>
    <div id="weekly" style="float:left;margin-top:4% ;width: 77%;font-size: 19px ; color: rgb(83, 101, 51); font-family: Calibri;">


    
                    <asp:Label ID="Label1" style="float: left;margin-left: 9%;margin-top: 1%;" class=h2 runat="server" Text="Weekly Off"></asp:Label>
       

        <table id = "test" class="logo" style="width:50%;float:right;margin-right:2%;height:10%">
            <tr>
                <td id="id1">SUN</td>
                <td id="id2">MON</td>
                <td id="id3">TUE</td>
                <td id="id4">WED</td>
                <td id="id5">THUR</td>
                <td id="id6">FRI</td>
                <td id="id7">SAT</td>
            </tr>
        </table>




    </div>
    <div id="monthly" width="100%" style="font-size: 19px ; color: rgb(83, 101, 51); font-family: Calibri;">
       
        <div id="div6" style="float:left;margin-top:5%; width: 77%;">


    
                    <asp:Label ID="Label2" style="float: left;margin-left: 9%;margin-top: 1%;" runat="server" Text="Monthly Off"></asp:Label>
       
            <asp:DropDownList ID="ddltype1"  class="form1" runat="server" style="margin-top: 1%;margin-left: 4%;float: left;
width: 13%; ">
                <asp:ListItem>Alternate</asp:ListItem>
            </asp:DropDownList>
        <table id = "Table1" class="logo" style="width:50%;float:right;margin-right:2%;height:10%">
            <tr>
                <td id="Td1">SUN</td>
                <td id="Td2">MON</td>
                <td id="Td3">TUE</td>
                <td id="Td4">WED</td>
                <td id="Td5">THUR</td>
                <td id="Td6">FRI</td>
                <td id="Td71">SAT</td>
            </tr>
        </table>




    </div>
       <div id="div7" style="float:left;margin-top:1%;width: 77%; ">


    
                    <asp:Label ID="Label3" style="float: left;margin-left: 9%;margin-top: 1%;" runat="server" Text="Monthly Off"></asp:Label>
         <asp:DropDownList ID="ddltype2"  class="form1" runat="server" style="margin-top: 1%;margin-left: 4%;float: left;width: 13%;">
                <asp:ListItem>Alternate</asp:ListItem>
             </asp:DropDownList>
        <table id = "Table2" class="logo" style="width:50%;float:right;margin-right:2%;height:10%">
            <tr>
              <td id="Td7">SUN</td>
                <td id="Td8">MON</td>
                <td id="Td9">TUE</td>
                <td id="Td10">WED</td>
                <td id="Td11">THUR</td>
                <td id="Td12">FRI</td>
                <td id="Td13">SAT</td>
            </tr>
        </table>




    </div>
      <div id="div8" style="float:left;margin-top:1% ;width: 77%;">


    
                    <asp:Label ID="Label4" style="float: left;margin-left: 9%;margin-top: 1%;" runat="server" Text="Monthly Off"></asp:Label>
       
            <asp:DropDownList ID="ddltype3"  class="form1" runat="server" style="margin-top: 1%;margin-left: 4%;float: left;width: 13%;">
                <asp:ListItem>Alternate</asp:ListItem> </asp:DropDownList>
        <table id = "Table3" class="logo" style="width:50%;float:right;margin-right:2%;height:10%">
            <tr>
          <td id="Td14">SUN</td>
                <td id="Td15">MON</td>
                <td id="Td16">TUE</td>
                <td id="Td17">WED</td>
                <td id="Td18">THUR</td>
                <td id="Td19">FRI</td>
                <td id="Td20">SAT</td>
            </tr>
        </table>




    </div>
     <div id="div9" style="float:left;margin-top:1%;width: 77%; ">

    
                    <asp:Label ID="Label5" style="float: left;margin-left: 9%;margin-top: 1%;" runat="server" Text="Monthly Off"></asp:Label>
       
           <asp:DropDownList ID="ddltype4"  class="form1" runat="server" style="margin-top: 1%;margin-left: 4%;float: left;width: 13%;">
                <asp:ListItem>Alternate</asp:ListItem> </asp:DropDownList>
        <table id = "Table4" class="logo" style="width:50%;float:right;margin-right:2%;height:10%">
            <tr>
              <td id="Td21">SUN</td>
                <td id="Td22">MON</td>
                <td id="Td23">TUE</td>
                <td id="Td24">WED</td>
                <td id="Td25">THUR</td>
                <td id="Td26">FRI</td>
                <td id="Td27">SAT</td>
                </tr>
        </table>




    </div>
    <br />
       <div id="div10" style="float:left;margin-top:1%;width: 77%; ">


    
                    <asp:Label ID="Label6" style="float: left;margin-left: 9%;margin-top: 1%;" runat="server" Text="Monthly Off"></asp:Label>
       
             <asp:DropDownList ID="ddltype5"  class="form1" runat="server" style="margin-top: 1%;margin-left: 4%;float: left;width: 13%;">
                <asp:ListItem>Alternate</asp:ListItem> </asp:DropDownList>
        <table id = "Table5" class="logo" style="width:50%;float:right;margin-right:2%;height:10%">
            <tr>
             <td id="Td28">SUN</td>
                <td id="Td29">MON</td>
                <td id="Td30">TUE</td>
                <td id="Td31">WED</td>
                <td id="Td32">THUR</td>
                <td id="Td33">FRI</td>
                <td id="Td34">SAT</td>
            </tr>
        </table>




    </div>
    <div id="div11" style="float:left;margin-top:1%;width: 77%; ">


    
                    <asp:Label ID="Label7" style="float: left;margin-left: 9%;margin-top: 1%;" runat="server" Text="Monthly Off"></asp:Label>
       
          <asp:DropDownList ID="ddltype6"  class="form1" runat="server" style="margin-top: 1%;margin-left: 4%;float: left;width: 13%;">
                <asp:ListItem>Alternate</asp:ListItem>
              </asp:DropDownList>
        <table id = "Table6" class="logo" style="width:50%;float:right;margin-right:2%;height:10%">
            <tr>
            <td id="Td35">SUN</td>
                <td id="Td36">MON</td>
                <td id="Td37">TUE</td>
                <td id="Td38">WED</td>
                <td id="Td49">THUR</td>
                <td id="Td40">FRI</td>
                <td id="Td41">SAT</td>
            </tr>
        </table>




    </div>
                   
        <div id="div13" style="float:right;margin-top:5%;width: 25%; ">
            <asp:Button ID="saveOffduty" runat="server"  OnClientClick="return validate();"   Text="Save" class="save" OnClick="saveOffduty_Click"  />
               <asp:Button ID="btncancel" runat="server" OnClientClick="return AlertClearAll();" Text="Cancel" class="cancel" />
            </div>
        <script type="text/javascript">

           

            function validate() {

                document.getElementById('<%=hiddenmonthlydata1.ClientID %>').value = "";
                document.getElementById('<%=hiddenmonthlydata2.ClientID %>').value = "";
                document.getElementById('<%=hiddenmonthlydata3.ClientID %>').value = "";
                document.getElementById('<%=hiddenmonthlydata4.ClientID %>').value = "";
                document.getElementById('<%=hiddenmonthlydata5.ClientID %>').value = "";
                document.getElementById('<%=hiddenmonthlydata6.ClientID %>').value = "";

               
            
                var total_days;
                var total1 = '';
                var total2 = '';
                var total3 = '';
                var total4 = '';
                var total5 = '';
                var total = '';

                var total6 = '';

                var total7 = '';

                var num;
                var tableslist = [];
                var tableslist1 = [];
                tableslist1 = totalid();
                document.getElementById('<%=hiddenmonthlydata.ClientID %>').value = tableslist1.toString();
         //     alert("have " + tableslist1);
                function totalid() {

                    tableslist1 += document.getElementById('<%=ddltype1.ClientID %>').value + ',';

                    tableslist1 += document.getElementById('<%=ddltype2.ClientID %>').value + ',';
                    tableslist1 += document.getElementById('<%=ddltype3.ClientID %>').value + ',';
                    tableslist1 += document.getElementById('<%=ddltype4.ClientID %>').value + ',';
                    tableslist1 += document.getElementById('<%=ddltype5.ClientID %>').value + ',';
                    tableslist1 += document.getElementById('<%=ddltype6.ClientID %>').value;

                    //alert("have data" + tableslist1.toString());
                    sametypes(tableslist1);
                    //alert(tableslist1);
                  
                    return tableslist1;

                }
               $a('#Table1 td.selected').each(function () {
                    //alert("have data");
                 
                 num = $a(this).text();
                    if (num == 'SUN') {
                        // alert('1');
                        total += ',1'
                    }
                    else if (num == 'MON') {
                        // alert('2');
                        total += ',2'
                    }
                    else if (num == 'TUE') {
                        // alert('3');
                        total += ',3'
                    }
                    else if (num == 'WED') {
                        // alert('3');
                        total += ',4'
                    }
                    else if (num == 'THUR') {
                        // alert('3');
                        total += ',5'
                    }
                    else if (num == 'FRI') {
                        // alert('3');
                        total += ',6'
                    }
                    else if (num == 'SAT') {
                        // alert('3');
                        total += ',7'
                    }
                 //  $a.unique(total);
                  // alert('table1:' + total);
                   var temp = [];
                   temp.push(total);
                   $a.unique(temp);
                 //  alert('table1:' + temp);
                   tableslist.push(total);
       
                    document.getElementById('<%=hiddensavemonthly.ClientID %>').value = 'Yes'; 
                  // alert('table1:' + total);
                   document.getElementById('<%=hiddenmonthlydata1.ClientID %>').value = temp.toString(); 

                  // document.getElementById('<%=hiddenmonthlydata.ClientID %>').value += document.getElementById('<%=ddltype1.ClientID %>').value;
               });
                $a('#Table2 td.selected').each(function () {
                  //  alert("have data");
                 
                    num = $a(this).text();
                    if (num == 'SUN') {
                        // alert('1');
                        total2 += ',1'
                    }
                    else if (num == 'MON') {
                        // alert('2');
                        total2 += ',2'
                    }
                    else if (num == 'TUE') {
                        // alert('3');
                        total2 += ',3'
                    }
                    else if (num == 'WED') {
                        // alert('3');
                        total2 += ',4'
                    }
                    else if (num == 'THUR') {
                        // alert('3');
                        total2 += ',5'
                    }
                    else if (num == 'FRI') {
                        // alert('3');
                        total2 += ',6'
                    }
                    else if (num == 'SAT') {
                        // alert('3');
                        total2 += ',7'
                    }
                   // $a.unique(total2);
                    var temp = [];
                    temp.push(total2);
                    $a.unique(temp);
                 
                    tableslist.push(temp);
                    document.getElementById('<%=hiddensavemonthly.ClientID %>').value = 'Yes';
                  //  alert('table2:' + tableslist1.toString());
                    document.getElementById('<%=hiddenmonthlydata2.ClientID %>').value = temp.toString(); 
                  //  document.getElementById('<%=hiddenmonthlydata.ClientID %>').value += document.getElementById('<%=ddltype2.ClientID %>').value;

                });
                $a('#Table3 td.selected').each(function () {
                   // alert("have data");
                  
                    num = $a(this).text();
                    if (num == 'SUN') {
                        // alert('1');
                        total3 += ',1'
                    }
                    else if (num == 'MON') {
                        // alert('2');
                        total3 += ',2'
                    }
                    else if (num == 'TUE') {
                        // alert('3');
                        total3 += ',3'
                    }
                    else if (num == 'WED') {
                        // alert('3');
                        total3 += ',4'
                    }
                    else if (num == 'THUR') {
                        // alert('3');
                        total3 += ',5'
                    }
                    else if (num == 'FRI') {
                        // alert('3');
                        total3 += ',6'
                    }
                    else if (num == 'SAT') {
                        // alert('3');
                        total3 += ',7'
                    }
                    var temp = [];
                    temp.push(total3);
                    $a.unique(temp);
                  //  $a.unique(total3);
                    tableslist.push(temp);
                    document.getElementById('<%=hiddensavemonthly.ClientID %>').value = 'Yes';
                  //  alert('table3:' + total3);
                    document.getElementById('<%=hiddenmonthlydata3.ClientID %>').value = temp.toString(); 
                 //   document.getElementById('<%=hiddenmonthlydata.ClientID %>').value += document.getElementById('<%=ddltype3.ClientID %>').value;

                });
                $a('#Table4 td.selected').each(function () {
                  // alert("have data");
               
                    num = $a(this).text();
                    if (num == 'SUN') {
                        // alert('1');
                        total4 += ',1'
                    }
                    else if (num == 'MON') {
                        // alert('2');
                        total4 += ',2'
                    }
                    else if (num == 'TUE') {
                        // alert('3');
                        total4 += ',3'
                    }
                    else if (num == 'WED') {
                        // alert('3');
                        total4 += ',4'
                    }
                    else if (num == 'THUR') {
                        // alert('3');
                        total4 += ',5'
                    }
                    else if (num == 'FRI') {
                        // alert('3');
                        total4 += ',6'
                    }
                    else if (num == 'SAT') {
                        // alert('3');
                        total4 += ',7'
                    }
                   // $a.unique(total4);
                    var temp = [];
                    temp.push(total4);
                    $a.unique(temp);
                    //  $a.unique(total3);
                    tableslist.push(temp);
                    document.getElementById('<%=hiddensavemonthly.ClientID %>').value = 'Yes';
                   // alert('table4:' + total4);
                    document.getElementById('<%=hiddenmonthlydata4.ClientID %>').value = temp.toString(); 
                 //   document.getElementById('<%=hiddenmonthlydata.ClientID %>').value += document.getElementById('<%=ddltype4.ClientID %>').value;

                });
                $a('#Table5 td.selected').each(function () {
                  //  alert("have data");
                 
                    num = $a(this).text();
                    if (num == 'SUN') {
                        // alert('1');
                        total5 += ',1'
                    }
                    else if (num == 'MON') {
                        // alert('2');
                        total5 += ',2'
                    }
                    else if (num == 'TUE') {
                        // alert('3');
                        total5 += ',3'
                    }
                    else if (num == 'WED') {
                        // alert('3');
                        total5 += ',4'
                    }
                    else if (num == 'THUR') {
                        // alert('3');
                        total5 += ',5'
                    }
                    else if (num == 'FRI') {
                        // alert('3');
                        total5 += ',6'
                    }
                    else if (num == 'SAT') {
                        // alert('3');
                        total5 += ',7'
                    }

                    var temp = [];
                    temp.push(total5);
                    $a.unique(temp);
                    //  $a.unique(total3);
                    tableslist.push(temp);
                    document.getElementById('<%=hiddensavemonthly.ClientID %>').value = 'Yes';
                    //  alert('table5:' + total5);
                    //alert(tableslist);
                    document.getElementById('<%=hiddenmonthlydata5.ClientID %>').value = temp.toString(); 
                  //  document.getElementById('<%=hiddenmonthlydata.ClientID %>').value += document.getElementById('<%=ddltype5.ClientID %>').value;
                 
                });
                $a('#Table6 td.selected').each(function () {
               //    alert("have data");
              
                    num = $a(this).text();
                    if (num == 'SUN') {
                        // alert('1');
                        total6 += ',1'
                    }
                    else if (num == 'MON')
                    {
                        // alert('2');
                        total6 += ',2'
                    }
                    else if (num == 'TUE')
                    {
                        // alert('3');
                        total6 += ',3'
                    }
                    else if (num == 'WED')
                    {
                        // alert('3');
                        total6 += ',4'
                    }
                    else if (num == 'THUR')
                    {
                        // alert('3');
                        total6 += ',5'
                    }
                    else if (num == 'FRI')
                    {
                        // alert('3');
                        total6 += ',6'
                    }
                    else if (num == 'SAT')
                    {
                        // alert('3');
                        total6 += ',7'
                    }
                    var temp = [];
                    temp.push(total6);
                    $a.unique(temp);
                    //  $a.unique(total3);
                    tableslist.push(temp);
                    document.getElementById('<%=hiddensavemonthly.ClientID %>').value = 'Yes';
                   // alert('table6:' + temp);
                   // alert('final:' + tableslist1.toString());
                    document.getElementById('<%=hiddenmonthlydata6.ClientID %>').value = temp.toString(); 
       
                 //   document.getElementById('<%=hiddenmonthlydata.ClientID %>').value += document.getElementById('<%=ddltype6.ClientID %>').value;
                        });
                $a('#weekly td.selected').each(function ()
                {
                //alert("have week");
         
                 // var week = [];
                    num = $a(this).text();
                    if (num == 'SUN')
                    {
                        // alert('1');
                        total7 += ',1'
                       // week.push('1,');
                    }
                    else if (num == 'MON')
                    {
                        // alert('2');
                        total7 += ',2'
                        //total6.push('2,');
                    }
                    else if (num == 'TUE')
                    {
                        // alert('3');
                        total7 += ',3'
                      //  week.push('3,');
                    }
                    else if (num == 'WED')
                    {
                        // alert('3');
                        total7 += ',4'
                      //  week.push('4,');
                    }
                    else if (num == 'THUR')
                    {
                        // alert('3');
                        total7 += ',5'
                      //  week.push('5,');
                    }
                    else if (num == 'FRI')
                    {
                        // alert('3');
                        total7 += ',6'
                      //  week.push('6,');
                    }
                    else if (num == 'SAT')
                    {
                        // alert('3');
                        total7 += ',7'
                       // week.push('7,');
                    }
                   // alert("wweklsssy" + temp1);
                    var temp1 = [];
                    temp1 = [];
                    temp1.pop();
                    temp1.push(total7);
                    $a.unique(temp1);
                    //  $a.unique(total3);
                   // alert("wwekly"+temp1);
                    document.getElementById('<%=hiddenweeklydata.ClientID %>').value = temp1.toString();
                    
                    document.getElementById('<%=hiddensaveweekly.ClientID %>').value = 'Yes';

            //        alert("wwekly");
                   // document.getElementById('<%=hiddenweeklydata.ClientID %>').value = 'Yes';
                    document.getElementById('<%=hiddensaveweekly.ClientID %>').value = 'Yes';
                });





                //Start:-EMP-0009
                var x =0;
                for (var i = 1; i <= 6; i++) {
                    document.getElementById("cphMain_ddltype" + i).style.borderColor = "";
                    $a('#Table' + i + ' td.selected').each(function () {
                        if (x == 0) {
                            x = i;
                        }
                        else {
                            if (String(x).indexOf(String(i)) <0) {
                                x += "," + i;
                            }                         

                        }
                    });
                }

                var y = x.split(',');
                for (var i = 0; i < y.length; i++) {
                    for (var j = 0; j < y.length; j++) {
                        if (i != j) {
                            var ddl1 = document.getElementById("cphMain_ddltype" + y[i]).value;
                            var ddl2 = document.getElementById("cphMain_ddltype" + y[j]).value;
                            if (ddl1 == ddl2) {
                                document.getElementById("cphMain_ddltype" + y[i]).style.borderColor = "Red";
                                document.getElementById("cphMain_ddltype" + y[j]).style.borderColor = "Red";
                            }
                        }
                    }
                }

                for (var i = 1; i <= 6; i++) {
                    if (document.getElementById("cphMain_ddltype" + i).style.borderColor == "red") {
                        document.getElementById("cphMain_ddltype" + i).focus();
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error!.Monthly off type can’t be duplicated.";
                        return false;
                    }
                    
                }
                //End:-EMP-0009
               


               

                return true;

            }
            function tableload(c)
            {
               
                var str = c;
             // alert(str);
                var temp = new Array();
                // this will return an array with strings "1", "2", etc.
                temp = str.split(",");
              //  alert('b4' + temp);
                $a.unique(temp);
                //alert('a' + temp);
             //   alert(temp.toString());

                for (a in temp ) {
                    temp[a] = parseInt(temp[a], 10); // Explicitly include base as per Álvaro's comment
                
                    
                }
                for (var i in temp) {

                    if($a.isNumeric(temp[i]))
                    {
                    //  alert(temp[i]);
                        switch (temp[i]) {
                            case 1:
                              
                                $a('#id1').toggleClass('selected');
                               // $('#id1').addClass('selected');
                                break;
                            case 2:
                                $a('#id2').toggleClass('selected');
                                break;
                            case 3:
                                $a('#id3').toggleClass('selected');
                                break;
                            case 4:
                               // alert('wed!');
                                $a('#id4').toggleClass('selected');
                        
                                break;
                            case 5:
                                 //alert('5!');
                                $a('#id5').toggleClass('selected');
                                break;
                            case 6:
                                $a('#id6').toggleClass('selected');
                                break;
                            case 7:
                        
                                $a('#id7').addClass('selected');
                                break;
                            default:
                              //  alert('Nobody Wins!');
                        }
                    }
                    
                }
            
            
            }
                
            function tableload1(c) {

                var str = c;
            //   alert(str);
                var temp = new Array();
                // this will return an array with strings "1", "2", etc.
                temp = str.split(",");
                $a.unique(temp);
                //   alert(temp.toString());

                for (a in temp) {
                    temp[a] = parseInt(temp[a], 10); // Explicitly include base as per Álvaro's comment


                }
                for (var i in temp) {

                    if ($a.isNumeric(temp[i])) {
                        //  alert(temp[i]);
                        switch (temp[i]) {
                            case 1:

                               // $a('#Td1').toggleClass('selected');
                                $a('#Td1').toggleClass('selected');
                                break;
                            case 2:
                                $a('#Td2').toggleClass('selected');
                                break;
                            case 3:
                                $a('#Td3').toggleClass('selected');
                                break;
                            case 4:
                                // alert('wed!');
                                $a('#Td4').toggleClass('selected');

                                break;
                            case 5:
                                $a('#Td5').toggleClass('selected');
                                break;
                            case 6:
                                $a('#Td6').toggleClass('selected');
                                break;
                            case 7:
                                $a('#Td71').toggleClass('selected');
                                break;
                            default:
                             //   alert('Nobody Wins!');
                        }
                    }

                }


            }
            function tableload2(c) {

                var str = c;
                //   alert(str);
                var temp = new Array();
                // this will return an array with strings "1", "2", etc.
                temp = str.split(",");
                $a.unique(temp);
                //   alert(temp.toString());

                for (a in temp) {
                    temp[a] = parseInt(temp[a], 10); // Explicitly include base as per Álvaro's comment


                }
                for (var i in temp) {

                    if ($a.isNumeric(temp[i])) {
                        //  alert(temp[i]);
                        switch (temp[i]) {
                            case 1:

                                // $a('#Td1').toggleClass('selected');
                                $a('#Td7').toggleClass('selected');
                                break;
                            case 2:
                                $a('#Td8').toggleClass('selected');
                                break;
                            case 3:
                                $a('#Td9').addClass('selected');
                                break;
                            case 4:
                                // alert('wed!');
                                $a('#Td10').toggleClass('selected');

                                break;
                            case 5:
                                $a('#Td11').toggleClass('selected');
                                break;
                            case 6:
                                $a('#Td12').toggleClass('selected');
                                break;
                            case 7:
                                $a('#Td13').toggleClass('selected');
                                break;
                            default:
                             //   alert('Nobody Wins!');
                        }
                    }

                }


            }
            function tableload3(c) {

                var str = c;
                //   alert(str);
                var temp = new Array();
                // this will return an array with strings "1", "2", etc.
                temp = str.split(",");
                $a.unique(temp);
                //   alert(temp.toString());

                for (a in temp) {
                    temp[a] = parseInt(temp[a], 10); // Explicitly include base as per Álvaro's comment


                }
                for (var i in temp) {

                    if ($a.isNumeric(temp[i])) {
                        //  alert(temp[i]);
                        switch (temp[i]) {
                            case 1:

                                // $a('#Td1').toggleClass('selected');
                                $a('#Td14').toggleClass('selected');
                                break;
                            case 2:
                                $a('#Td15').toggleClass('selected');
                                break;
                            case 3:
                                $a('#Td16').toggleClass('selected');
                                break;
                            case 4:
                                // alert('wed!');
                                $a('#Td17').toggleClass('selected');

                                break;
                            case 5:
                                $a('#Td18').toggleClass('selected');
                                break;
                            case 6:
                                $a('#Td19').toggleClass('selected');
                                break;
                            case 7:
                                $a('#Td20').toggleClass('selected');
                                break;
                            default:
                               // alert('Nobody Wins!');
                        }
                    }

                }


            }
            function tableload4(c) {

                var str = c;
                //   alert(str);
                var temp = new Array();
                // this will return an array with strings "1", "2", etc.
                temp = str.split(",");
                $a.unique(temp);
                //   alert(temp.toString());

                for (a in temp) {
                    temp[a] = parseInt(temp[a], 10); // Explicitly include base as per Álvaro's comment


                }
                for (var i in temp) {

                    if ($a.isNumeric(temp[i])) {
                        //  alert(temp[i]);
                        switch (temp[i]) {
                            case 1:

                                // $a('#Td1').toggleClass('selected');
                                $a('#Td21').toggleClass('selected');
                                break;
                            case 2:
                                $a('#Td22').toggleClass('selected');
                                break;
                            case 3:
                                $a('#Td23').toggleClass('selected');
                                break;
                            case 4:
                                // alert('wed!');
                                $a('#Td24').toggleClass('selected');

                                break;
                            case 5:
                                $a('#Td25').toggleClass('selected');
                                break;
                            case 6:
                                $a('#Td26').toggleClass('selected');
                                break;
                            case 7:
                                $a('#Td27').toggleClass('selected');
                                break;
                            default:
                           //     alert('Nobody Wins!');
                        }
                    }

                }


            }
            function tableload5(c) {

                var str = c;
                //   alert(str);
                var temp = new Array();
                // this will return an array with strings "1", "2", etc.
                temp = str.split(",");
                $a.unique(temp);
                //   alert(temp.toString());

                for (a in temp) {
                    temp[a] = parseInt(temp[a], 10); // Explicitly include base as per Álvaro's comment


                }
                for (var i in temp) {

                    if ($a.isNumeric(temp[i])) {
                        //  alert(temp[i]);
                        switch (temp[i]) {
                            case 1:

                                // $a('#Td1').toggleClass('selected');
                                $a('#Td28').toggleClass('selected');
                                break;
                            case 2:
                                $a('#Td29').toggleClass('selected');
                                break;
                            case 3:
                                $a('#Td30').addClass('selected');
                                break;
                            case 4:
                                // alert('wed!');
                                $a('#Td31').toggleClass('selected');

                                break;
                            case 5:
                                $a('#Td32').toggleClass('selected');
                                break;
                            case 6:
                                $a('#Td33').toggleClass('selected');
                                break;
                            case 7:
                                $a('#Td34').toggleClass('selected');
                                break;
                            default:
                               // alert('Nobody Wins!');
                        }
                    }

                }


            }
            function tableload6(c) {

                var str = c;
                //   alert(str);
                var temp = new Array();
                // this will return an array with strings "1", "2", etc.
                temp = str.split(",");
                $a.unique(temp);
                //   alert(temp.toString());

                for (a in temp) {
                    temp[a] = parseInt(temp[a], 10); // Explicitly include base as per Álvaro's comment


                }
                for (var i in temp) {

                    if ($a.isNumeric(temp[i])) {
                        //  alert(temp[i]);
                        switch (temp[i]) {
                            case 1:

                                // $a('#Td1').toggleClass('selected');
                                $a('#Td35').toggleClass('selected');
                                break;
                            case 2:
                                $a('#Td36').toggleClass('selected');
                                break;
                            case 3:
                                $a('#Td37').toggleClass('selected');
                                break;
                            case 4:
                                // alert('wed!');
                                $a('#Td38').toggleClass('selected');

                                break;
                            case 5:
                                $a('#Td49').toggleClass('selected');
                                break;
                            case 6:
                                $a('#Td40').toggleClass('selected');
                                break;
                            case 7:
                                $a('#Td41').toggleClass('selected');
                                break;
                            default:
                              //  alert('Nobody Wins!');
                        }
                    }

                }


            }
            </script>
         <asp:HiddenField ID="hiddenupdate" runat="server" Value="No"/>
        <asp:HiddenField ID="hiddensavemonthly" runat="server" Value="Yes"/>
          <asp:HiddenField ID="hiddensaveweekly" runat="server" Value="No"/>
            <asp:HiddenField ID="hiddenRoleConfirm" runat="server" />
             <asp:HiddenField ID="hiddenweeklydata" runat="server" />
             <asp:HiddenField ID="hiddenweeklydataforload" runat="server" />
                <asp:HiddenField ID="HiddenField1" runat="server" />
             <asp:HiddenField ID="hiddenmonthlydata" runat="server" />
           <asp:HiddenField ID="hiddenmonthlydata1" runat="server" />
                   <asp:HiddenField ID="HiddenFieldid" runat="server" />
           <asp:HiddenField ID="hiddenmonthlydata2" runat="server" />
           <asp:HiddenField ID="hiddenmonthlydata3" runat="server" />   
           <asp:HiddenField ID="hiddenmonthlydata4" runat="server" />
           <asp:HiddenField ID="hiddenmonthlydata5" runat="server" />
           <asp:HiddenField ID="hiddenmonthlydata6" runat="server" />
          <asp:HiddenField ID="hiddenmonthlydataforload" runat="server" />
           <asp:HiddenField ID="hiddenmonthlydataforload1" runat="server" />

           <asp:HiddenField ID="hiddenmonthlydataforload2" runat="server" />
           <asp:HiddenField ID="hiddenmonthlydataforload3" runat="server" />   
           <asp:HiddenField ID="hiddenmonthlydataforload4" runat="server" />
           <asp:HiddenField ID="hiddenmonthlydataforload5" runat="server" />
           <asp:HiddenField ID="hiddenmonthlydataforload6" runat="server" />
      <asp:HiddenField ID="hiddenRoleAdd" runat="server" />
        </div>
     </div>
    <br style="clear:both" />
    <script type="text/javascript">

        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Off Duty Details Inserted Successfully.";
            }

            function SuccessUpdation() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Off Duty Details Updated Successfully.";
            }


        function DuplicationName() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.  Type Name Can’t be Duplicated.";
            window.location();
        }

        function sametypes(tableslist1) {
          //  alert('am in');
            for (i = 0; i < 6; i++) {

                var str = tableslist1;
                //   alert(str);
                var temp = new Array();
                // this will return an array with strings "1", "2", etc.
                temp = str.split(",");
               // $a.unique(temp);
                //   alert(temp.toString());

                for (a in temp)
                {
                    temp[a] = parseInt(temp[a], 10); // Explicitly include base as per Álvaro's comment


                }
                count(temp);
            }
        }
        function count(array_elements) {

           // array_elements = ["2", "1", "2", "2", "3", "4", "3", "3", "3", "5"];

            array_elements.sort();
            var temp = new Array();
            var current = null;
            var cnt = 0;
            for (var i = 0; i < array_elements.length; i++) {
                if (array_elements[i] != current) {
                    if (cnt > 1) {
                        temp.push(current);
                       
                    }
                    current = array_elements[i];
                    cnt = 1;
                } else {
                    cnt++;
                }
            }
            if (cnt > 0) {
            //  alert(current + ' comes --> ' + cnt + ' times');
            }

        }
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        function AlertClearAll() {
      
            if (confirmbox >= 0) {
                if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                    window.location.href = "gen_Employee_Off_duty.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "gen_Employee_Off_duty.aspx";
                return false;
            }
        }
    </script>
</asp:Content>


