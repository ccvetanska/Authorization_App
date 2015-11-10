<%@ Page Title="TestEdit" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Edit.aspx.cs" Inherits="Authorization_App.Views.Test.Edit" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <p>&nbsp;</p>
        <asp:FormView runat="server"
            ItemType="Authorization_App.Model.Test" DefaultMode="Edit" DataKeyNames="Id"
            UpdateMethod="UpdateItem" SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false"
            Id="formViewId">
            <EmptyDataTemplate>
                Cannot find the Test with Id <%: Request.QueryString["Id"] %>
            </EmptyDataTemplate>
            <EditItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Edit Test</legend>
                    <asp:ValidationSummary runat="server" CssClass="alert alert-danger" />
                    <asp:DynamicControl Mode="Edit" DataField="Name" runat="server" />
                    <asp:DynamicControl Mode="Edit" DataField="isActive" runat="server" />

                    <asp:ListView ID="qListView_edit" runat="server"
                        DataKeyNames="Id"
                        ItemType="Authorization_App.Model.Question"
                        SelectMethod="GetData">                       
                        <EmptyDataTemplate>
                            There are no entries found for Question
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th>
                                            <asp:LinkButton Id="isAdded" Text="IsAdded" CommandArgument="IsAdded" runat="Server" Enabled="false"/>
                                        </th>
                                        <th>
                                            <asp:LinkButton Text="Title" CommandName="Sort" CommandArgument="Title" runat="Server" />
                                        </th>
                                        <th>
                                            <asp:LinkButton Text="QuestionType" CommandName="Sort" CommandArgument="QuestionType" runat="Server" />                                            
                                        </th>
                                        <th>
                                            <asp:LinkButton Text="Description" CommandName="Sort" CommandArgument="Description" runat="Server" />
                                        </th>
                                        <th>
                                            <asp:LinkButton Text="Tags" CommandName="Sort" CommandArgument="Tags" runat="Server" />
                                        </th>
                                        <th>
                                            <asp:LinkButton Text="Level" CommandName="Sort" CommandArgument="Level" runat="Server" />
                                        </th>
                                        <th>&nbsp;</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr runat="server" id="itemPlaceholder" />
                                </tbody>
                            </table>
                            <asp:DataPager PageSize="5" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ShowLastPageButton="False" ShowNextPageButton="False" ButtonType="Button" ButtonCssClass="btn" />
                                    <asp:NumericPagerField ButtonType="Button" NumericButtonCssClass="btn" CurrentPageLabelCssClass="btn disabled" NextPreviousButtonCssClass="btn" />
                                    <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowPreviousPageButton="False" ButtonType="Button" ButtonCssClass="btn" />
                                </Fields>
                            </asp:DataPager>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" ID="QuestionCheckbox" Checked='<%# Convert.ToBoolean(isAdded(DataBinder.Eval(Container.DataItem, "Id").ToString())) ? true : false %>' OnCheckedChanged="QuestionCheckbox_CheckedChanged" AutoPostBack="true"/>
                                    <asp:HiddenField ID="hdnId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Id").ToString() %>' />
                                </td>
                                <td>
                                    <asp:DynamicControl runat="server" DataField="Title" ID="Title" Mode="ReadOnly" />
                                </td>
                                <td>
                                    <asp:DynamicControl runat="server" DataField="QuestionType" ID="QuestionType" Mode="ReadOnly" />
                                </td>
                                <td>
                                    <asp:DynamicControl runat="server" DataField="Description" ID="Description" Mode="ReadOnly" />
                                </td>
                                <td>
                                    <asp:DynamicControl runat="server" DataField="Tags" ID="Tags" Mode="ReadOnly" />
                                </td>
                                <td>
                                    <asp:DynamicControl runat="server" DataField="Level" ID="Level" Mode="ReadOnly" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button runat="server" ID="AddButton" CommandName="Add" Text="Add Selected Questions" CssClass="btn btn-primary" OnClick="AddButton_Click"/>
                            <asp:Button runat="server" ID="UpdateButton" CommandName="Update" Text="Update" CssClass="btn btn-primary" />
                            <asp:Button runat="server" ID="CancelButton" CommandName="Cancel" Text="Cancel" CausesValidation="false" CssClass="btn btn-default" />
                        </div>
                    </div>
                </fieldset>
            </EditItemTemplate>
        </asp:FormView>
    </div>
    
</asp:Content>


