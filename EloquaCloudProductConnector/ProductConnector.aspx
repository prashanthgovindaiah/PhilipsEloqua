<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductConnector.aspx.cs" Inherits="Philips.DigitalServices.Eloqua.EloquaCloudProductConnector.ProductConnector" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="width:489px">
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="SegmentListName" runat="server" Text="Segment List Name     "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnContactProduct" runat="server" BackColor="#99CCFF" BorderStyle="Solid" Height="45px" OnClick="btnContactProduct_Click" style="font-weight: 700" Text="Generate Contact &amp; Product Association" Width="275px" />
        </p>
        <p style="margin-left: 160px">
            &nbsp;</p>
    </form>
    </body>
</html>
