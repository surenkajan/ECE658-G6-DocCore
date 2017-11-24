<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="UoW.DocCore.Web.WebForms.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/docCoreCommon.css" type="text/css" />
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div id="PictreRegisterUserDiv" class="form-horizontal">
        <asp:PlaceHolder ID="PictreRegisterUserPH" runat="server">
            <h4>Create a new account</h4>
            <hr />
            <asp:ValidationSummary Visible="false" runat="server" CssClass="text-danger" />

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

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="DOB" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Date of Birth:</asp:Label>
                <div class="col-md-10">
                    <div style="float: left;">
                        <asp:TextBox runat="server" ID="DOB" CssClass="form-control" />
                    </div>
                    <div>
                        <asp:Image ID="calenderImg" Style="height: 40px; width: 40px;" runat="server" ImageUrl="../Content/Images/Google-Calendar-icon.png" />
                    </div>

                    <ajaxToolkit:CalendarExtender runat="server"
                        TargetControlID="DOB"
                        Format="MMMM d, yyyy" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="DOB" PopupButtonID="calenderImg"></ajaxToolkit:CalendarExtender>

                    <asp:RequiredFieldValidator runat="server" ControlToValidate="DOB"
                        CssClass="text-danger" ErrorMessage="The Date of Birth field is required." />
                </div>
            </div>

            <div class="form-group">


                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Your Email:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                        CssClass="text-danger" ErrorMessage="The email field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Password</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                        CssClass="text-danger" ErrorMessage="The password field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Confirm password</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label" style="text-decoration: underline;">Security Questions:</asp:Label>
                <br />
                <br />
                <asp:Label runat="server" ID="SQuestion1" AssociatedControlID="SQuestion1Ans" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span></asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="SQuestion1Ans" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="SQuestion1Ans"
                        CssClass="text-danger" ErrorMessage="Answer to Security Question 1 is required." />
                </div>
                <br />
                <asp:Label runat="server" ID="SQuestion2" AssociatedControlID="SQuestion2Ans" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span></asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="SQuestion2Ans" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="SQuestion2Ans"
                        CssClass="text-danger" ErrorMessage="Answer to Security Question 2 is required." />
                </div>
            </div>

            <div class="form-group">
                <div style="width: 25%; margin-left: 10%;min-width: 250px;">
                    <div style="float: left;">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
                        </div>
                    </div>
                    <div style="float: right;">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="CreateUserCancel_Click" Text="Cancel" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </div>

        </asp:PlaceHolder>

        <asp:PlaceHolder ID="RegisterStatusPH" Visible="false" runat="server">
            <div class="form-group">
                <asp:Label ID="registerStatus" runat="server" CssClass="control-label pictre-success-msg"></asp:Label>
            </div>
        </asp:PlaceHolder>

    </div>


    
</asp:Content>
