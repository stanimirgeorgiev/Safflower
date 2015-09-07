<%@ Page Title="Home"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Home.aspx.cs"
    Inherits="FaceBook.WebClient.Pages.WebContent.Home" %>

<asp:Content ID="Home" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView runat="server" ID="ListViewPosts"
        ItemType="FaceBook.WebClient.Models.Post"
        DataKeyNames="ID"
        SelectMethod="Select"
        UpdateMethod="Update"
        DeleteMethod="Delete"
        > 
       
        <LayoutTemplate>
            <div class="row">
                <div>
                    <asp:TextBox runat="server" TextMode="MultiLine" />
                    <div>
                        <asp:Button Text="Public" runat="server" ID="PublicPost" />
                        <asp:Button Text="Post" runat="server" ID="PostButton" />
                    </div>
                </div>
            </div>
            <div runat="server" id="itemPlaceHolder"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="row">
                <div>
                    <h3><%#: Item.User.Username %></h3>
                    <p><%#: Item.PostedOn %></p>
                </div>
                <p><%#: Item.Content %></p>
                <p>
                    <asp:Button Text="Like" runat="server" />
                    <asp:Button Text="Comment" runat="server" />
                </p>
                <p>Likes count: <%#: Item.Likes.Count %></p>
                <div>
                    <asp:TextBox runat="server" TextMode="MultiLine" />
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
