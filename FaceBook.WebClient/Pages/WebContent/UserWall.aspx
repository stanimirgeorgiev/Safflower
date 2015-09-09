<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="UserWall.aspx.cs"
    Inherits="FaceBook.WebClient.Pages.WebContent.UserWall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:LinkButton ID="ButtonAddFriend" Text="Add friend" runat="server" OnClick="ButtonAddFriend_Click" />
    </div>

    <div>
        <asp:TextBox runat="server" ID="TextBoxPostContent" TextMode="MultiLine" />
        <div>
            <asp:Button Text="Public" runat="server" ID="PublicPost" />
            <asp:Button Text="Post" runat="server" ID="PostButton" OnClick="PostButton_Click" />
        </div>
    </div>

    <asp:ListView runat="server" ID="ListViewPosts"
        ItemType="FaceBook.WebClient.Models.BindingModels.PostBindingModel"
        DataKeyNames="ID"
        SelectMethod="Select"
        UpdateMethod="Update"
        DeleteMethod="Delete">

        <LayoutTemplate>
            <div runat="server" id="itemPlaceHolder"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="row">
                <div>
                    <h3><%#: Item.Author.Username %></h3>
                    <p><%#: Item.PostedOn %></p>
                </div>
                <div><%#: Item.Content %></div>
                <div>Likes: <%#: Item.LikesCount %></div>
                <div>
                    <asp:Button Text="Like" runat="server" CommandName="<%# Item.Id %>" OnCommand="CommandLikePost" />
                    <asp:Button Text="Comment" runat="server" CommandName="<%# Item.Id %>" OnCommand="CommandPostComment" />
                    <br />
                    <asp:TextBox runat="server" TextMode="MultiLine" />
                </div>

                <div>
                    <asp:ListView runat="server" ItemType="FaceBook.WebClient.Models.BindingModels.CommentBindingModel"
                        DataSource="<%# Item.Comments %>" ID="ListViewComments">
                        <LayoutTemplate>
                            <ul>
                                <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li>
                                <div>
                                    <h3><%#: Item.Author.Username %></h3>
                                    <p><%#: Item.PostedOn %></p>
                                </div>
                                <div><%#: Item.Content %></div>
                                <div>
                                    <asp:Button Text="Like" runat="server" CommandName="<%# Item.Id %>" OnCommand="CommandLikeComment" />
                                    <span>Likes: <%#: Item.LikesCount %></span>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
