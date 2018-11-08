<%@ Page Title="login Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="whodat.aspx.vb" Inherits="whodat" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table class="bordernone">
    <tr><td class="bordernone" colspan="2">User:<asp:TextBox id="USREnter" runat="server" autopostback="True" MaxLength="8" /></td></tr>
    <tr><td class="bordernone" colspan="2"></td></tr>
    <tr><td class="bordernone" colspan="2">Pass:<asp:TextBox id="USRpass" runat="server" autopostback="True" MaxLength="10" /></td></tr>
    <tr><td class="bordernone"><div style="align-content:flex-start">
        <asp:Button ID="btnGood" runat="server" Text="Log in" /></div>
    </td><td class="bordernone">
        <div style="align-content:flex-end"><asp:Button ID="btnBad" runat="server" Text="Cancel" /></div>
   </td></tr></table>
</asp:Content>