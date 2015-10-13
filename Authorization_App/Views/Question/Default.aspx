<%@ Page Title="QuestionList" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="Authorization_App.Views.Question.Default" %>
<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Question List</h2>
    <p>
        <asp:HyperLink runat="server" NavigateUrl="Insert" Text="Create new" />
    </p>
    <div>
        <asp:ListView id="ListView1" runat="server"
            DataKeyNames="Id" 
			ItemType="Authorization_App.Models.Question"
            SelectMethod="GetData">
            <EmptyDataTemplate>
                There are no entries found for Question
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table">
                    <thead>
                        <tr>
                            <th>
								<asp:LinkButton Text="Id" CommandName="Sort" CommandArgument="Id" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="AuthorId" CommandName="Sort" CommandArgument="AuthorId" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="QuestionType" CommandName="Sort" CommandArgument="QuestionType" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Title" CommandName="Sort" CommandArgument="Title" runat="Server" />
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
                            <th>
								<asp:LinkButton Text="CreatedAt" CommandName="Sort" CommandArgument="CreatedAt" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="UpdatedAt" CommandName="Sort" CommandArgument="UpdatedAt" runat="Server" />
							</th>
                            <th>&nbsp;</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder" />
                    </tbody>
                </table>
				<asp:DataPager PageSize="5"  runat="server">
					<Fields>
                        <asp:NextPreviousPagerField ShowLastPageButton="False" ShowNextPageButton="False" ButtonType="Button" ButtonCssClass="btn" />
                        <asp:NumericPagerField ButtonType="Button"  NumericButtonCssClass="btn" CurrentPageLabelCssClass="btn disabled" NextPreviousButtonCssClass="btn" />
                        <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowPreviousPageButton="False" ButtonType="Button" ButtonCssClass="btn" />
                    </Fields>
				</asp:DataPager>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
							<td>
								<asp:DynamicControl runat="server" DataField="Id" ID="Id" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="AuthorId" ID="AuthorId" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="QuestionType" ID="QuestionType" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="Title" ID="Title" Mode="ReadOnly" />
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
							<td>
								<asp:DynamicControl runat="server" DataField="CreatedAt" ID="CreatedAt" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="UpdatedAt" ID="UpdatedAt" Mode="ReadOnly" />
							</td>
                    <td>
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Views/Question/Details", Item.Id) %>' Text="Details" /> | 
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Views/Question/Edit", Item.Id) %>' Text="Edit" /> | 
                        <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Views/Question/Delete", Item.Id) %>' Text="Delete" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

