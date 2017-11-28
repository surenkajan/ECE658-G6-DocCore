<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="UoW.DocCore.Web.WebForms.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/docCoreCommon.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/myprofile.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/displayDiv.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/font-awesome.min.css" type="text/css">
    <link rel="stylesheet" href="/Content/css/jquery.tagit.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/tagit.ui-zendesk.css" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Content/js/DocCoreBDelegate.js"></script>
    <script src="Content/js/DocCoreMyProfile.js" type="text/javascript"></script>
    <table>
        <tr>
            <td style="width: 1000px;">
                <asp:Label ID="MyProfileHeading" Font-Size="20pt" runat="server" Text=""></asp:Label>
                <asp:Label ID="MyProfileHeading1" Font-Size="20pt" runat="server">'s Profile</asp:Label>
            </td>
        </tr>
    </table>
    <hr />

    <div id="MyProfilePicture" style="overflow-x: auto;">
        <table>
            <tr>
                <td style="vertical-align: top">
                    <div style="margin: 0 auto;">
                        <table style="align-self: auto">
                            <tr>
                                <td>
                                    <asp:Image runat="server" ID="ImagePreview" Height="164px" Width="125px" Style="border-radius: 6px;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="MyProfileNameLabel" runat="server"><b>Name </b></asp:Label>
                                    <asp:Label ID="MyProfileName" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="MyProfileDOBLabel" runat="server"><b>DOB: </b></asp:Label>
                                    <asp:Label ID="MyProfileDOB" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="MyProfileEmailLabel" runat="server"><b>Email: </b></asp:Label>
                                    <asp:Label ID="MyProfileEmail" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="vertical-align: top; height: 100px; width: 660px; background-color: white">
                    <div id="UploadedDocumentsContainer" class="UploadedDocumentsContainerclass" style="height: auto;"></div>
                </td>
            </tr>
        </table>
    </div>
    <!-- Modal -->
    <div class="modal fade" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document" style="margin-top: 200px; width: 400px">
            <div class="modal-content">
                <div class="modal-body">
                    <button type="button" class="close" data-dismiss="modal" onclick="location.reload()">&times;</button>
                    <p style="font-size: 18px; margin-top: 20px"><strong>Are you sure you want to delete the Document? </strong></p>
                </div>
                <div class="modal-footer">
                    <button id="ModalDeleteButton" type="button" class="btn btn-default" data-dismiss="modal">Delete</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
