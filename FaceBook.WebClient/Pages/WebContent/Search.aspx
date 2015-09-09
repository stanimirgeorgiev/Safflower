<%@ Page Title="Search results"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Search.aspx.cs"
    Inherits="FaceBook.WebClient.Pages.WebContent.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:ListView runat="server" ID="ListViewSearchedUsers">
            <ItemTemplate></ItemTemplate>
        </asp:ListView>
    </div>

    <div>
        <asp:ListView runat="server" ID="ListViewSearchedGroups"> 
            <ItemTemplate></ItemTemplate>
        </asp:ListView>
    </div>

</asp:Content>
