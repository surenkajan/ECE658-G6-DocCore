<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UoW.DocCore.Web.WebForms.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/docCoreCommon.css" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<script type="text/javascript">
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=ImgPrv.ClientID%>').prop('src', e.target.result)
                        .width(240)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
    </script>--%>

    <h4>Upload New Documents to DocCore:</h4>
    <div class="form-horizontal">
        <asp:FileUpload ID="DocumentUpload" runat="server" onchange="this.form.submit()" />
        <%--<asp:FileUpload ID="DocumentUpload" runat="server"  onchange="ShowImagePreview(this);" />--%>
        <asp:PlaceHolder ID="UploadedDocumentDetailsPH" runat="server" Visible="false">
            <div class="col-md-3" style="margin-top: 10px;">
                <div class="form-group">
                    <asp:Image ID="FileExtImage" runat="server" />
                    <asp:Image ID="ImgPrv" runat="server" /><br />
                </div>
            </div>
            <div class="col-md-9" style="min-height: 275px;margin-top: 10px;">
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Document Name:</asp:Label>
                    <div class="col-md-10">
                        <%--<asp:Label ID="lblDocName" runat="server" CssClass="control-label"></asp:Label>--%>
                        <asp:TextBox ID="txtDocName" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Document Size(KB):</asp:Label>
                    <div class="col-md-10">
                        <asp:Label ID="lblDocSize" runat="server" CssClass="control-label"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Uploaded By:</asp:Label>
                    <div class="col-md-10">
                        <asp:Label ID="lblUploadedBy" runat="server" CssClass="control-label"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Uploaded Date:</asp:Label>
                    <div class="col-md-10">
                        <asp:Label ID="lblUploadedDate" runat="server" CssClass="control-label"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Description:</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtFileDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label"><span class="man-ast-field">*</span>Share with:</asp:Label>
                    <div class="col-md-10">
                        <%-- People Picker--%>
                        <asp:TextBox ID="txtSharedWith" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div style="width: 25%; margin-left: 10%; min-width: 250px;">
                        <div style="float: left;">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" OnClick="btnSave_Click" Text="Save" CssClass="btn btn-default" />
                            </div>
                        </div>
                        <div style="float: right;">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" OnClick="btnCancel_Click" Text="Cancel" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
    </div>
</asp:Content>
