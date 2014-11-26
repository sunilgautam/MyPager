<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pager</title>
    <style type="text/css">
    ul.grid-pager
    {
        margin: 0;
        padding: 0;
        list-style-type: none;
    }
    
    ul.grid-pager li
    {
        float: left;
        margin-right: 5px;
    }
    
    ul.grid-pager li a
    {
        border: solid 1px #afafaf;
        padding: 5px;
        display: block;
        width: 25px;
        text-align: center;
    }
    
    ul.grid-pager li a.current
    {
        background: #ddd;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Literal ID="lit1" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
