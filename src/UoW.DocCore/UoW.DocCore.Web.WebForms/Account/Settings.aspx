<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="UoW.DocCore.Web.WebForms.Account.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/docCoreCommon.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/settings.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<h2><%: Title %>.</h2>--%>
    <h2>Update account details:</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div id="PictreUpdateUserDiv" class="form-horizontal">
        <asp:PlaceHolder ID="PictreUpdateUserDetailsPH" runat="server">
            <%--<h4>Update account details:</h4>--%>
            <hr />
            <asp:ValidationSummary Visible="false" runat="server" CssClass="text-danger" />
            <div style="float: right;">
                <div class="form-group">
                    <asp:Image runat="server" ID="ImagePreview" Height="164px" Width="125px" />
                    <asp:FileUpload runat="server" ID="ProfilePhotoUpload" onchange="this.form.submit()" />
                    <%--<asp:Button runat="server" OnClick="btnPreview_Click" ID="btnPhotoPreview" Text="Preview" />--%>
                </div>
            </div>
            <div style="float: left;">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="FName" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>First Name:</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="FName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="FName"
                            CssClass="text-danger" ErrorMessage="The First Name field is required." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="LName" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Last Name:</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="LName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="LName"
                            CssClass="text-danger" ErrorMessage="The Last Name field is required." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="FullName" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Full Name:</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="FullName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="FullName"
                            CssClass="text-danger" ErrorMessage="The Full Name field is required." />
                    </div>
                </div>

                <%--<div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UName" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>User Name:</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="UName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UName"
                                    CssClass="text-danger" ErrorMessage="The User Name field is required." />
            </div>
        </div>--%>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Gender" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>I am:</asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList ID="Gender" runat="server" Style="width: 150px" CssClass="form-control">
                            <asp:ListItem Text="Gender:"></asp:ListItem>
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            <asp:ListItem Text="Unspecified" Value="Unspecified"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Gender"
                            CssClass="text-danger" ErrorMessage="The Gender field is required." />
                    </div>
                </div>

                <div class="register-forgot">
                    <div class="register-user" id="divAccountSettings">
                        <p>
                            <asp:HyperLink NavigateUrl="/Account/Manage" Text="[Change your account settings]" ID="AccountSettings" runat="server" />
                        </p>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Security Questions:</asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" ID="SQuestion1" AssociatedControlID="SQuestion1Ans" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span></asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="SQuestion1Ans" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="SQuestion1Ans"
                            CssClass="text-danger" ErrorMessage="Answer to Security Question 1 is required." />
                    </div>
                    <asp:Label runat="server" ID="SQuestion2" AssociatedControlID="SQuestion2Ans" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span></asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="SQuestion2Ans" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="SQuestion2Ans"
                            CssClass="text-danger" ErrorMessage="Answer to Security Question 2 is required." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" ID="lblSaveStatus" Visible="false" CssClass="control-label"></asp:Label>
                </div>

                <div class="form-group">
                    <div style="width: 25%; margin-left: 10%;min-width: 250px;">
                        <div style="float:left;">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" OnClick="btnSave_Click" Text="Save" CssClass="btn btn-default" />
                            </div>
                        </div>
                        <div style="float:right;">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" OnClick="btnCancel_Click" Text="Close" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
    </div>
</asp:Content>
