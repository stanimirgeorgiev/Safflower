<%@ Page Title="Search results"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Search.aspx.cs"
    Inherits="FaceBook.WebClient.Pages.WebContent.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:ListView runat="server" ID="ListViewSearchedUsers"
            ItemType="FaceBook.WebClient.Models.BindingModels.UserBindingModel"
            SelectMethod="ListViewSearchedUsers_GetData">
            <LayoutTemplate>
                <div>
                    <h2>People:</h2>
                    <div runat="server" id="itemPlaceHolder"></div>
                </div>
            </LayoutTemplate>

            <ItemTemplate>
                <div>
                    <asp:LinkButton runat="server" CommandName="<%# Item.UserId %>" OnCommand="GoToUserWall">
                        <p>Name: <%#: Item.Username %></p>
                        <p>Email: <%#: Item.Email %></p>
                    </asp:LinkButton>
                </div>
            </ItemTemplate>

            <EmptyDataTemplate>
                <div>
                    <h2>People:</h2>
                    <p>No results...</p>
                </div>
            </EmptyDataTemplate>
        </asp:ListView>
    </div>

    <%--    <div>
        <asp:ListView runat="server" ID="ListViewSearchedGroups"
            ItemType="group">
            <LayoutTemplate>
                <div>
                    <h2>Groups:</h2>
                    <div runat="server" id="itemPlaceHolder"></div>
                </div>
            </LayoutTemplate>

            <ItemTemplate>

            </ItemTemplate>
        </asp:ListView>
    </div>--%>
</asp:Content>
