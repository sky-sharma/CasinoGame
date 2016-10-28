<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CasinoMegaChallenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="imagesPanel" runat="server">
            <asp:Image ID="image0" runat="server" Height="98px" Width="92px" />
            <asp:Image ID="image1" runat="server" Height="98px" Width="92px" />
            <asp:Image ID="image2" runat="server" Height="98px" Width="92px" />
        </asp:Panel>
    
    </div>
        <p>
            Your Bet:
            <asp:TextBox ID="betTextBox" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="leverButton" runat="server" OnClick="leverButton_Click" Text="Pull the Lever!" />
        </p>
        <p>
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="moneyLabel" runat="server"></asp:Label>
        </p>
        1 Cherry - x2 Your Bet<br />
        2 Cherries - x3 Your Bet<br />
        3 Cherries - x4 Your Bet<br />
        HOWEVER...if there&#39;s even one BAR you win NOTHING!</form>
</body>
</html>
