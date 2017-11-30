<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UoW.DocCore.Web.WebForms.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/Content/css/docCoreCommon.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/home.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/displayDiv.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/font-awesome.min.css" type="text/css">
    <link rel="stylesheet" href="/Content/css/jquery.tagit.css" type="text/css" />
    <link rel="stylesheet" href="/Content/css/tagit.ui-zendesk.css" type="text/css" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="//code.jquery.com/jquery-1.9.1.js"></script>
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script src="Content/js/DocCoreBDelegate.js"></script>
    <script src="Content/js/DocCoreHome.js" type="text/javascript"></script>
    <script src="Content/js/tag-it.js" type="text/javascript"></script>
    <script src="Content/js/tag-it.min.js" type="text/javascript"></script>

    <%--<script type="text/javascript">   
        function ShowDocumentPreview(input) {
            document.getElementById("DocID").style.display = "block";
            document.getElementById("description").style.display = "block";
            document.getElementById("tagDiv").style.display = "block";
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
    </script>--%>
    <script src="Content/js/tag-it.js" type="text/javascript" charset="utf-8"></script>

    <script>
        $(function () {
            var userEmail = $('#DocCore_hdnf_LoggedInUserEmailID').val();

            var editor = {
                setSource: function () {
                    //Replace with All Employees of the project
                    // return GetAllUsersByProjectID(userEmail);


                    //return GetAllUsers();
                    return GetAllPossibleValuesforSharedWith(userEmail);
                }
            }

            $.when(editor.setSource()).then(function (users) {
                var sampleTags = [];

                for (index in users) {
                    //sampleTags.push(users[index].FullName);
                    sampleTags.push(users[index].FullName);
                }

                $("#MainContent_txtSharedWith").tagit({
                    availableTags: sampleTags, // this param is of course optional. it's for autocomplete.
                    // configure the name of the input field (will be submitted with form), default: item[tags]
                    itemName: 'item',
                    fieldName: 'tags',
                    allowSpaces: true
                });

            });

        });

        //$.ajax({
        //    type: "GET",
        //    dataType: "json",
        //    url: DocCoreServicesBaseAddress + "/userRest/GetAllUsers",
        //    success: function (members) {

        //        for (index in members) {
        //            members[index].value = members[index].FullName;
        //        }
        //        $("#MainContent_txtSharedWith").autocomplete({
        //            source: members,
        //            minLength: 1,
        //            focus: function (event, ui) {
        //                $("#MainContent_txtSharedWith").val(ui.item.FullName)
        //                return false;
        //            },
        //            select: function (event, ui) {
        //                //location.href = DocCoreAppBaseAddress + "/Admin/ViewAllUsers?Uid=" + ui.item.Uid;
        //                //return false;
        //            }
        //        });
        //    }
        //});

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


    <%--    <div class="container">
        <!-- Trigger the modal with a button -->
        <button type="button" class="btn btn-default btn-lg" data-toggle="modal" data-target="#myModal" style="margin-left: 470px; width: 200px; margin-top: 20px"><span class="glyphicon glyphicon-picture"></span>&nbsp;Upload Document</button>

        <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content Style="border-radius: 6px; background-color: #e7e7e7; color: black; width: 32%;"-->
                <div class="modal-content">
                    <div id="DocID" class="modal-header" style="display: none">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <asp:Image ID="Image1" Height="188px" Width="254px" runat="server" Style="border: dashed; border-radius: 4px; border-width: 1px; border-style: inset; margin-top: 40px; float: left" /><br />

                    </div>
                    <div class="modal-body">
                        <div id="description" class="tagorCheckin" data-placeholder="Say something about this..." contenteditable="true" style="height: 80px; display: none"></div>


                    </div>
                    <div class="modal-body">

                        <div id="tagDiv" class="tagorCheckin" data-placeholder="Tag your friends..." contenteditable="true" style="display: none; border: none; margin-top: -20px; margin-left: -5px;">
                            <div id="wrapper">
                                <div id="content">
                                    <form>
                                        <ul id="myULTags">
                                            <!-- Existing list items will be pre-added to the tags. -->
                                        </ul>
                                    </form>

                                </div>

                            </div>
                        </div>
                        <hr />
                        <label class="file-upload">
                            <span><strong style="font-size: 18px">Select Document</strong></span>
                            <asp:FileUpload ID="FileUpload2" runat="server" onchange="ShowDocumentPreview(this)"></asp:FileUpload>
                        </label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-default" data-dismiss="modal" onclick="HandleUpload()">Upload</button>

                    </div>
                </div>

            </div>
            <div style="display: none; width: 600px; height: 300px; position: relative">
                <canvas id="image" width="800px" height="400px" style="display: none"></canvas>
            </div>
        </div>

    </div>--%>





    <div class="form-horizontal">
        <asp:PlaceHolder ID="UploadPlaceHolder" runat="server">
            <div class="doccore-upload-section" style="margin-right: 30%; margin-left: 32%; margin-top: 2%;margin-bottom: 2%;">
                <h4>Upload New Documents:</h4>
                <asp:FileUpload ID="DocumentUpload" runat="server" onchange="this.form.submit()" />
            </div>
        </asp:PlaceHolder>
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
        <%--<asp:Button runat="server" OnClick="btnTest_Click" Text="Test" CssClass="btn btn-default" />--%>

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
