<%@ Page Title="Interview" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Interview.aspx.cs" Inherits="Authorization_App.Interview" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="QuestionText" runat="server" Text=""></asp:Label>
 <%--   <asp:DynamicControl ID="QuestionAnswer" runat="server" />--%>
    <asp:Button ID="NextQuestionBtn" runat="server" OnClick="NextQuestionBtn_Click" CssClass="btn btn-primary" />
</asp:Content>
