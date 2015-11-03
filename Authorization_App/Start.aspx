<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="Authorization_App.Start" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <br />
        <asp:TextBox runat="server" ID="CodeTextBox"></asp:TextBox>
        <asp:Button runat="server" ID="Submit" OnClick="SubmitBtn_Click" Text="Submit" ButtonCssClass="btn btn-default" />
        <asp:Label runat="server" ID="wrongCodeLabel" Visible="false" CssClass="alert alert-danger">There is no test associated with this code. Please enter a correct code.</asp:Label>
        <br />
    </div>
</asp:Content>
