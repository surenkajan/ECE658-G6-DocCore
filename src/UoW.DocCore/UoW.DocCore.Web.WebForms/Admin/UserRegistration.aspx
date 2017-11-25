<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="UoW.DocCore.Web.WebForms.UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/docCoreCommon.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
        type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=ListBox1]').multiselect({
                includeSelectAllOption: true
            });
        });
    </script>

    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div id="DocCoreRegisterUserDiv" class="form-horizontal">
        <asp:PlaceHolder ID="DocCoreRegisterUserPH" runat="server">
            <h4>Create a new account</h4>
            <hr />
            <asp:ValidationSummary Visible="false" runat="server" CssClass="text-danger" />
            <h4>User Details:</h4>
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
            <h4>Permission Level:</h4>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ddlRole" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Role</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control" style="max-width: 280px;"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="lstBoxProject" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Project</asp:Label>
                <div class="col-md-10">
                    <asp:ListBox ID="lstBoxProject" runat="server" SelectionMode="Multiple" Width="100%" CssClass="form-control" style="max-width: 280px;"></asp:ListBox>
                </div>
            </div>

            <div class="form-group">
                <div style="width: 25%; margin-left: 10%; min-width: 250px;">
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
                <asp:Label ID="registerStatus" runat="server" CssClass="control-label DocCore-success-msg"></asp:Label>
            </div>
        </asp:PlaceHolder>

    </div>



    <%--<div>--%>
    <%--<h3>User Access</h3>
        <hr />
        <h4>User Details</h4>
        <table>
            <tr style="margin-bottom: 4px">
                <td style="width: 200px">
                    <asp:Label runat="server" ID="label3"> First Name(userId):</asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="width: 200px">
                    <asp:Label runat="server" ID="label1"> Last Name:</asp:Label>


                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="width: 200px">
                    <asp:Label runat="server" ID="label2">  Password:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
        </table>--%>
    <%--<h4>Access Level</h4>
        <table>
            <tr>
                <td style="width: 200px">Role:
                </td>
                <td style="width: 200px">
                    <asp:DropDownList Width="200px" ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td>Project:
                </td>
                <td>
                    <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Width="100%" CssClass="form-control"></asp:ListBox>
                </td>


            </tr>
            <tr>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Create" OnClick="CreateProject" CssClass="btn btn-default" />
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="DeleteProject" CssClass="btn btn-default" />
                </td>
            </tr>
        </table>--%>

    <%--</div>--%>
</asp:Content>
