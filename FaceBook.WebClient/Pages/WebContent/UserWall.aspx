<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="UserWall.aspx.cs"
    Inherits="FaceBook.WebClient.Pages.WebContent.UserWall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-3">
            <div>
                <asp:LinkButton ID="ButtonAddFriend" Text="Add friend" runat="server" OnClick="ButtonAddFriend_Click" />
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="panel-title">
                        <i class="glyphicon glyphicon-wrench pull-right"></i>
                        <h4>Post Request</h4>
                    </div>
                </div>
                <div class="panel-body">
                    <label>Message</label>
                    <div class="controls">
                        <asp:TextBox CssClass="form-control" runat="server" ID="TextBoxPostContent" TextMode="MultiLine" />
                    </div>
                    <div class="controls post-buttons">
                        <asp:Button CssClass="btn btn-primary" Text="Public" runat="server" ID="PublicPost" />
                        <asp:Button CssClass="btn btn-primary" Text="Post" runat="server" ID="PostButton" OnClick="PostButton_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-9">
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
                    <div class="row posts">
                        <div>
                            <h3><%#: Item.Author.Username %></h3>
                            <p><%#: Item.PostedOn %></p>
                        </div>
                        <h4>
                            <i class="glyphicon glyphicon-comment"></i>
                        </h4>
                        <div class="tab-pane well"><%#: Item.Content %></div>
                        <span class="badge pull-right">Likes: <%#: Item.LikesCount %></span>
                        <div>
                            <div class="comment-like-buttons">
                                <asp:Button CssClass="btn btn-sm btn-primary" Text="Like" runat="server" CommandName="<%# Item.Id %>" OnCommand="CommandLikePost" />
                                <span class="glyphicon glyphicon-hand-up"></span>
                                <asp:Button CssClass="btn btn-sm btn-success" Text="Comment" runat="server" CommandName="<%# Item.Id %>" OnCommand="CommandPostComment" />
                                <br />
                            </div>
                            <asp:TextBox CssClass="form-control" runat="server" TextMode="MultiLine" />
                        </div>


                        <label>Coments:</label>
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
                                        <h4>
                                            <i class="glyphicon glyphicon-comment"></i>
                                        </h4>
                                        <div class="commentText"><%#: Item.Author.Username %></div>
                                        <span class="date sub-text"><%#: Item.PostedOn %></span>
                                    </div>
                                    <div class="commentText"><%#: Item.Content %></div>
                                    <div>
                                        <asp:Button CssClass="btn btn-xs btn-primary" Text="Like" runat="server" CommandName="<%# Item.Id %>" OnCommand="CommandLikeComment" />
                                        <span class="glyphicon glyphicon-thumbs-up"></span>
                                        <span class="badge pull-right">Likes: <%#: Item.LikesCount %></span>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>

                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
