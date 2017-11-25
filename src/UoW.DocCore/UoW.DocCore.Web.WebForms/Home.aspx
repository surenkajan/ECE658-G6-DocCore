<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UoW.DocCore.Web.WebForms.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/docCoreCommon.css" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Upload New Documents to DocCore:</h4>
    <div class="form-horizontal">
        <asp:FileUpload ID="DocumentUpload" runat="server" onchange="this.form.submit()" />
        <asp:PlaceHolder ID="UploadedDocumentDetailsPH" runat="server" Visible="false">
            <div class="form-group">
                <asp:Image ID="FileExtImage" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Document Name:</asp:Label>
                <div class="col-md-10">
                    <asp:Label ID="lblDocName" runat="server" CssClass="col-md-3 control-label"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Uploaded By:</asp:Label>
                <div class="col-md-10">
                    <asp:Label ID="lblUploadedBy" runat="server" CssClass="col-md-2 control-label"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Uploaded Date:</asp:Label>
                <div class="col-md-10">
                    <asp:Label ID="lblUploadedDate" runat="server" CssClass="col-md-2 control-label"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Share with:</asp:Label>
                <div class="col-md-10">
                    <%-- People Picker--%>
                </div>
            </div>
            <div class="form-group">
                <div style="width: 25%; margin-left: 10%; min-width: 250px;">
                    <div style="float: left;">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="btnUpload_Click" Text="Upload" CssClass="btn btn-default" />
                        </div>
                    </div>
                    <div style="float: right;">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="btnCancel_Click" Text="Cancel" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
    </div>
</asp:Content>
