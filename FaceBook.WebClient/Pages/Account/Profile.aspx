<%@ Page Title="Profile"
     Language="C#" 
    MasterPageFile="~/Site.Master"
     AutoEventWireup="true"
     CodeBehind="Profile.aspx.cs"
     Inherits="FaceBook.WebClient.Pages.Account.Profile" %>

<asp:Content ID="ContentProfile" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView runat="server" ID="FormViewUserProfile" 
        ItemType="FaceBook.WebClient.Models.BindingModels.UserBindingModel" 
        SelectMethod="FormViewUserProfile_GetItem">
        <ItemTemplate>
            <p><%#: Item.Username %></p>
            <p><%#: Item.Email %></p>
            <p><%#: Item.UserId %></p>
        </ItemTemplate>
    </asp:FormView>

</asp:Content>
