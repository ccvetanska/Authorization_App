<%@ Page Title="TestSetupInsert" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Insert.aspx.cs" Inherits="Authorization_App.Views.TestSetup.Insert" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <p>&nbsp;</p>
        <asp:FormView runat="server" ID="formviewID"
            ItemType="Authorization_App.Model.TestSetup" DefaultMode="Insert"
            InsertItemPosition="FirstItem" InsertMethod="InsertItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <InsertItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Insert TestSetup</legend>
                    <asp:ValidationSummary runat="server" CssClass="alert alert-danger" />
                    <asp:DynamicControl Mode="ReadOnly" DataField="TestId" runat="server" />
                    <asp:DropDownList runat="server" ID="testDrpdwn">
<%--                        DataSourceID="" DataTextField="" DataValueField=""--%>
                    </asp:DropDownList>
              
                    <asp:Calendar runat="server" ID="ExpiresAtClndr"
                        OnSelectionChanged="ExpiresAtClndr_SelectionChanged" 
                        SelectedDate="<%# DateTime.Today.AddDays(1) %>" >
                    </asp:Calendar>

                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button runat="server" ID="InsertButton" CommandName="Insert" Text="Insert" CssClass="btn btn-primary" />
                            <asp:Button runat="server" ID="CancelButton" CommandName="Cancel" Text="Cancel" CausesValidation="false" CssClass="btn btn-default" />
                        </div>
                    </div>
                </fieldset>
            </InsertItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>
