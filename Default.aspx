<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table class="bordernone">
        <tr><td class="bordernone" style="text-align: center;">
          <asp:Label ID="USERNAME" runat="server" Text="Label" />
        </td></tr>
        <tr><td class="bordernone">
<%--    Enter Job: <asp:TextBox id="JobEnter" runat="server" TextChanged="JobEnter_CheckME();" autopostback="True" MaxLength="8" />--%>
    Enter Job: <asp:TextBox id="JobEnter" runat="server" autopostback="True" MaxLength="8" />
        </td></tr>
        <tr><td class="bordernone">
    <asp:Panel ID="pnlValid" runat="server" Visible="False">
        <asp:Label ID="lCompany" runat="server" Text="Label" />
        <asp:Button ID="btnGood" runat="server" Text="Correct" />
        <asp:Button ID="btnBad" runat="server" Text="Cancel" />
    </asp:Panel>
        </td></tr>
    </table>
</asp:Content>