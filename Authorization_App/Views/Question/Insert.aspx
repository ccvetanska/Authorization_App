<%@ Page Title="QuestionInsert" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Insert.aspx.cs" Inherits="Authorization_App.Views.Question.Insert" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <p>&nbsp;</p>
        <asp:FormView runat="server"
            ItemType="Authorization_App.Models.Question" DefaultMode="Insert"
            InsertItemPosition="FirstItem" InsertMethod="InsertItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <InsertItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Insert Question</legend>
                    <asp:ValidationSummary runat="server" CssClass="alert alert-danger" />
                    <asp:DynamicControl Mode="ReadOnly" DataField="AuthorId" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="QuestionType" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="Title" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="Description" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="Tags" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="Level" runat="server" />
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button runat="server" ID="InsertButton" CommandName="Insert" Text="Insert" CssClass="btn btn-primary" />
                            <asp:Button runat="server" ID="AddOptionButton" CommandName="Add_Option" Text="Add Option" CssClass="btn btn-default" />
                            <asp:Button runat="server" ID="CancelButton" CommandName="Cancel" Text="Cancel" CausesValidation="false" CssClass="btn btn-default" />
                        </div>
                    </div>
                </fieldset>
            </InsertItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>
