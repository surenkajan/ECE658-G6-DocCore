<%@ Page Title="Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="UoW.DocCore.Web.WebForms.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/docCoreCommon.css" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 id="ErrorTitle"></h2>
    <div id="PictreRegisterUserDiv" class="form-horizontal">
        <h4 id="ErrorDescription" style="color:red;">
            <asp:Label ID="lblErrorDescription" runat="server" Text=""></asp:Label></h4>
        <%--<asp:PlaceHolder ID="DocCoreErrorPage" runat="server">
            <div class="form-group">

            </div>
        </asp:PlaceHolder>--%>
        <div class="form-group">
            <div style="width: 25%; margin-left: 10%; min-width: 250px;">
                <div style="float: left;">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="Close_Click" Text="Close" CssClass="btn btn-default" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
