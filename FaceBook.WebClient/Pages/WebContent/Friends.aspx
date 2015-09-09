<%@ Page Title="Friends"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Friends.aspx.cs"
    Inherits="FaceBook.WebClient.Pages.WebContent.Friends" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:ListView runat="server" ID="ListViewFriends"
            ItemType="FaceBook.WebClient.Models.BindingModels.UserBindingModel"
            SelectMethod="ListViewFriends_GetData">
            <LayoutTemplate>
                <div>
                    <h2>Friends:</h2>
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
                    <h2>Friends:</h2>
                    <p>No friends...</p>
                </div>
            </EmptyDataTemplate>
        </asp:ListView>
    </div>

</asp:Content>
