﻿<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UoW.DocCore.Web.WebForms.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/docCoreCommon.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/home.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/displayDiv.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/font-awesome.min.css" type="text/css">
    <link rel="stylesheet" href="/Content/css/jquery.tagit.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/tagit.ui-zendesk.css" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Content/js/DocCoreBDelegate.js"></script>
    <script src="Content/js/DocCoreHome.js" type="text/javascript"></script>
    <script src="Content/js/tag-it.js" type="text/javascript"></script>
    <script src="Content/js/tag-it.min.js" type="text/javascript"></script>
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

    <script type="text/javascript">   
        function ShowImagePreview(input) {
            document.getElementById("DocID").style.display = "block";
            document.getElementById("description").style.display = "block";
            document.getElementById("tagDiv").style.display = "block";
            document.getElementById("locationField").style.display = "block";
            console.log(input);
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=ImgPrv.ClientID%>').prop('src', e.target.result)
                        .width(252)
                        .height(190);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <script src="Content/js/tag-it.js" type="text/javascript" charset="utf-8"></script>

    <script>
        $(function () {
            var userEmail = $('#DocCore_hdnf_LoggedInUserEmailID').val();

            var editor = {
                setSource: function () {
                    //Replace with All Employees of the project
                    //return GetAllUsersByProjectID(userEmail);
                }
            }

            $.when(editor.setSource()).then(function (friends) {
                var sampleTags = [];

                for (index in friends) {
                    sampleTags.push(friends[index].FullName);
                }

                $('#myULTags').tagit({
                    availableTags: sampleTags, // this param is of course optional. it's for autocomplete.
                    // configure the name of the input field (will be submitted with form), default: item[tags]
                    itemName: 'item',
                    fieldName: 'tags',
                    allowSpaces: true
                });

            });

        });

        function initAutocomplete() {

            autocomplete = new google.maps.places.Autocomplete(
            /** @type {!HTMLInputElement} */(document.getElementById('pac-input')),
                { types: ['geocode'] });

            autocomplete.addListener('place_changed', fillInAddress);
        }

        function fillInAddress() {
            var place = autocomplete.getPlace();
            console.log(place);
        }

        //function DownloadDocument(DocID) {
        //    //PageMethods.ProcessIT(DocID, onSucess, onError);
        //    function onSucess(result) {
        //        alert('Result: ' + result);
        //    }
        //    function onError(result) {
        //        alert('Something went wrong.');
        //    }
        //}

    </script>




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
            <div class="col-md-9" style="min-height: 275px; margin-top: 10px;">
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

        <div id="SharedDocuments" style="overflow-x: auto;">
            <%--<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>--%>
            <table>
                <tr>
                    <td style="vertical-align: top; width: 280px;"></td>
                    <td style="vertical-align: top; height: 100px; width: 660px; background-color: white">
                        <div id="SharedDocumentsContainer" class="SharedDocumentsContainerclass" style="height: auto;"></div>
                    </td>
                </tr>
            </table>
        </div>
    </div>


</asp:Content>
