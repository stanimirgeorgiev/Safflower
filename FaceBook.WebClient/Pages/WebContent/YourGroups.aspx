<%@ Page Title="Your groups"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="YourGroups.aspx.cs"
    Inherits="FaceBook.WebClient.Pages.WebContent.YourGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <asp:ListView runat="server" ID="ListViewYourGroups"
            ItemType="FaceBook.WebClient.Models.BindingModels.GroupBindingModel"
            SelectMethod="GetUserGroups">
            <LayoutTemplate>
                <div>
                    <h2>Groups:</h2>
                    <div runat="server" id="itemPlaceHolder"></div>
                </div>
            </LayoutTemplate>

            <ItemTemplate>
                <div>
                    <asp:LinkButton runat="server" CommandName="<%# Item.Id %>" OnCommand="GoToGroupWall">
                        <p>Name: <%#: Item.Name %></p>
                        <p>Participants: <%#: Item.NumberOfParticipants %></p>
                    </asp:LinkButton>
                </div>
            </ItemTemplate>

            <EmptyDataTemplate>
                <div>
                    <h2>Groups:</h2>
                    <p>You have no groups...</p>
                </div>
            </EmptyDataTemplate>
        </asp:ListView>
    </div>

</asp:Content>
