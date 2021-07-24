<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefaultMultiSelect.aspx.cs" Inherits="TEST_MultiSelect_DefaultMultiSelect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="chosen.jquery.js"></script>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <select class="my_select_box" data-placeholder="Select Your Options">
    <option value="1">Option 1</option>
    <option value="2" selected>Option 2</option>
    <option value="3" disabled>Option 3</option>
  </select>
         <script>
             $(".my_select_box").chosen({
                 disable_search_threshold: 10,
                 no_results_text: "Oops, nothing found!",
                 width: "95%"
             });
        </script>
    </div>
    </form>
</body>
</html>
