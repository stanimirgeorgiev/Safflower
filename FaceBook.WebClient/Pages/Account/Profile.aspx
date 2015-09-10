<%@ Page Title="Profile"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs"
    Inherits="FaceBook.WebClient.Pages.Account.Profile" %>

<asp:Content ID="ContentProfile" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
    <asp:FormView runat="server" ID="FormViewUserProfile"
        ItemType="FaceBook.WebClient.Models.BindingModels.FullUserProfileData"
        SelectMethod="FormViewUserProfile_GetItem"
        UpdateMethod="FormViewUserProfile_UpdateItem"
        DefaultMode="Edit">
        <EditItemTemplate>
                <h2>Profile</h2>
                <p>Update information about your profile</p>
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Information</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label Text="Username" runat="server" AssociatedControlID="TextBoxUserName" />
                            </td>
                            <td>
                                <asp:TextBox CssClass="form-control" runat="server" Text="<%#: Item.Username %>" ID="TextBoxUserName" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Email" runat="server" AssociatedControlID="TextBoxEmail" />
                            </td>
                            <td>
                                <asp:TextBox CssClass="form-control" runat="server" Text="<%#: Item.Email %>" ID="TextBoxEmail" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Town" runat="server" AssociatedControlID="TextBoxTown" />
                            </td>
                            <td>
                                <asp:TextBox CssClass="form-control" runat="server" Text="<%#: Item.Town %>" ID="TextBoxTown" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="First Name" runat="server" AssociatedControlID="TextBoxFirstName" />
                            </td>
                            <td>
                                <asp:TextBox CssClass="form-control" runat="server" Text="<%#: Item.FirstName %>" ID="TextBoxFirstName" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Middle Name" runat="server" AssociatedControlID="TextBoxMiddleName" />
                            </td>
                            <td>
                                <asp:TextBox CssClass="form-control" runat="server" Text="<%#: Item.MiddleName %>" ID="TextBoxMiddleName" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Family Name" runat="server" AssociatedControlID="TextBoxFamilyName" />
                            </td>
                            <td>
                                <asp:TextBox CssClass="form-control" runat="server" Text="<%#: Item.FamilyName %>" ID="TextBoxFamilyName" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Gender" runat="server" AssociatedControlID="TextBoxGender" />
                            </td>
                            <td>
                                <asp:TextBox CssClass="form-control" runat="server" Text="<%#: Item.Gender.ToString() %>" ID="TextBoxGender" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label  Text="Relashionship status" runat="server" AssociatedControlID="TextBoxRelationShipStatus" />
                            </td>
                            <td>
                                <asp:TextBox CssClass="form-control" runat="server" Text="<%#: Item.RelationshipStatus.ToString() %>" ID="TextBoxRelationShipStatus" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Phone number" runat="server" AssociatedControlID="TextBoxPN" />
                            </td>
                            <td>
                                <asp:TextBox CssClass="form-control" runat="server" Text="<%#: Item.PhoneNumber %>" ID="TextBoxPN" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Text="Interested in" runat="server" AssociatedControlID="TextBoxInterestedIn" />
                            </td>
                            <td>
                                <asp:TextBox CssClass="form-control" runat="server" Text="<%#: Item.InterestedIn.ToString() %>" ID="TextBoxInterestedIn" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button CssClass="btn btn-block btn-primary" Text="Save" runat="server" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            
        </EditItemTemplate>
            
    </asp:FormView>
</div>
</asp:Content>
