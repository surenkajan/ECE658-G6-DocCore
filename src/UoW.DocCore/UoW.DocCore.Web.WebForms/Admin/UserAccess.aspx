<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserAccess.aspx.cs" Inherits="UoW.DocCore.Web.WebForms.WebForm1" %>
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
        


  <div>
    <h3>User Access</h3>
    <hr />
    <h4>User Details</h4>
        <table>
            <tr style="margin-bottom:4px">
                <td style="width:200px">
            <asp:Label runat="server" ID="label3" > First Name(userId):</asp:Label>
                   
                </td>
                <td >
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height:20px">

                </td>
            </tr>
            <tr>
                <td style="width:200px">
     <asp:Label runat="server" ID="label1" > Last Name:</asp:Label>
             
                   
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                </td>

            </tr>
             <tr>
                <td style="height:20px">

                </td>
            </tr>
            <tr>
                <td style="width:200px">
         <asp:Label runat="server" ID="label2"  >  Password:</asp:Label>
       </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
        </table>
        <h4>Access Level</h4>
        <table>
            <tr>
                  <td style="width:200px">
                    Role:
                  </td>
                  <td style="width:200px">
                    <asp:DropDownList Width="200px" ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td style="height:20px">

                </td>
            </tr>
            <tr>
                <td>
                    Project:
                </td>
                <td>
                     <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Width="100%" CssClass="form-control"></asp:ListBox>
                </td>


            </tr>
             <tr>
                <td style="height:20px">

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Create" OnClick="CreateProject" CssClass="btn btn-default"  />  
                </td>
                <td>
        <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="DeleteProject" CssClass="btn btn-default" /> 
                </td>
            </tr>
        </table>

</div> 
</asp:Content>