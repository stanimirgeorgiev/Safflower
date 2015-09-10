<%@ Page Title="Profile"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs"
    Inherits="FaceBook.WebClient.Pages.Account.Profile" %>

<asp:Content ID="ContentProfile" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView runat="server" ID="FormViewUserProfile"
        ItemType="FaceBook.WebClient.Models.BindingModels.FullUserProfileData"
        SelectMethod="FormViewUserProfile_GetItem"
        UpdateMethod="FormViewUserProfile_UpdateItem"
        DefaultMode="Edit">
        <EditItemTemplate>
            <asp:Label Text="Username" runat="server" AssociatedControlID="TextBoxUserName" />
            <asp:TextBox runat="server" Text="<%#: Item.Username %>" ID="TextBoxUserName" />
            <br />
            <asp:Label Text="Email" runat="server" AssociatedControlID="TextBoxEmail" />
            <asp:TextBox runat="server" Text="<%#: Item.Email %>" ID="TextBoxEmail" />
            <br />
            <asp:Label Text="Town" runat="server" AssociatedControlID="TextBoxTown" />
            <asp:TextBox runat="server" Text="<%#: Item.Town %>" ID="TextBoxTown" />
            <br />
            <asp:Label Text="First Name" runat="server" AssociatedControlID="TextBoxFirstName" />
            <asp:TextBox runat="server" Text="<%#: Item.FirstName %>" ID="TextBoxFirstName" />
            <br />
            <asp:Label Text="Middle Name" runat="server" AssociatedControlID="TextBoxMiddleName" />
            <asp:TextBox runat="server" Text="<%#: Item.MiddleName %>" ID="TextBoxMiddleName" />
            <br />
            <asp:Label Text="Family Name" runat="server" AssociatedControlID="TextBoxFamilyName" />
            <asp:TextBox runat="server" Text="<%#: Item.FamilyName %>" ID="TextBoxFamilyName" />
            <br />
            <asp:Label Text="Gender" runat="server" AssociatedControlID="TextBoxGender" />
            <asp:TextBox runat="server" Text="<%#: Item.Gender.ToString() %>" ID="TextBoxGender" />
            <br />
            <asp:Label Text="Relashionship status" runat="server" AssociatedControlID="TextBoxRelationShipStatus" />
            <asp:TextBox runat="server" Text="<%#: Item.RelationshipStatus.ToString() %>" ID="TextBoxRelationShipStatus" />
            <br />
            <asp:Label Text="Phone number" runat="server" AssociatedControlID="TextBoxPN" />
            <asp:TextBox runat="server" Text="<%#: Item.PhoneNumber %>" ID="TextBoxPN" />
            <br />
            <asp:Label Text="Interested in" runat="server" AssociatedControlID="TextBoxInterestedIn" />
            <asp:TextBox runat="server" Text="<%#: Item.InterestedIn.ToString() %>" ID="TextBoxInterestedIn" />
            <asp:Button Text="Save" runat="server" />
        </EditItemTemplate>
    </asp:FormView>

</asp:Content>
