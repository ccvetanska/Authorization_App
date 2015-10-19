<%@ Page Title="QuestionOptionEdit" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Edit.aspx.cs" Inherits="Authorization_App.Views.QuestionOption.Edit" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <p>&nbsp;</p>
        <asp:FormView runat="server"
            ItemType="Authorization_App.Models.QuestionOption" DefaultMode="Edit" DataKeyNames="Id"
            UpdateMethod="UpdateItem" SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the QuestionOption with Id <%: Request.QueryString["Id"] %>
            </EmptyDataTemplate>
            <EditItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Edit QuestionOption</legend>
                    <asp:ValidationSummary runat="server" CssClass="alert alert-danger" />
                    <asp:DynamicControl Mode="Edit" DataField="isCorrect" runat="server" />
                    <asp:DynamicControl Mode="Edit"
                        DataField="QuestionRefId"
                        DataTypeName="Authorization_App.Models.Question"
                        DataTextField="AuthorId"
                        DataValueField="Id"
                        UIHint="ForeignKey" runat="server" />
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button runat="server" ID="UpdateButton" CommandName="Update" Text="Update" CssClass="btn btn-primary" />
                            <asp:Button runat="server" ID="AddContentButton" CommandName="Add_Content" Text="Add Content" CssClass="btn btn-primary" /> 
                            <asp:Button runat="server" ID="CancelButton" CommandName="Cancel" Text="Cancel" CausesValidation="false" CssClass="btn btn-default" />
                        </div>
                    </div>
                </fieldset>
            </EditItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>

