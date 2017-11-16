<%@ Page Title="Create Project" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="UoW.DocCore.Web.WebForms.Admin.Project" %>
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
   <h2>Create Project</h2>
    <hr />
   
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label1" runat="server" Text="Project Name" > </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBox1" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label2" runat="server" Text="Project Manager" ></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        
                        <asp:ListBox ID="ListBox1" runat="server" Width="100%" SelectionMode="Multiple" CssClass="form-control"></asp:ListBox>
                      </asp:TableCell>
                    </asp:TableRow>
                <asp:TableRow >
                    <asp:TableCell Height="30px" >
                        
                    </asp:TableCell>
                     
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="50%" HorizontalAlign="Center" >
                        <asp:Button ID="Button1" runat="server" Text="Create" OnClick="CreateProject" CssClass="btn btn-default"  />  
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                          <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="DeleteProject" CssClass="btn btn-default" />  
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        
   

    </div>
</asp:Content>
