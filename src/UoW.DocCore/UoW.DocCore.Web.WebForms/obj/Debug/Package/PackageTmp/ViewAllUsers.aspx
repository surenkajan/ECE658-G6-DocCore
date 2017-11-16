<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAllUsers.aspx.cs" Inherits="UoW.DocCore.Web.WebForms.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
     <link rel="stylesheet" href="/Content/css/docCoreCommon.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>View All Users</h3>
   
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        
        table
        {
            border: 1px solid #ccc;
        }
        
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        
        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
        table tbody table
        {
            padding: 5px;
            border-color: #fff !important;
        }
    </style>
    <table>
        <tr>
  <td><asp:Label ID="Label1" runat="server" Text="Search:" > </asp:Label></td>
   
    <td><asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" /></td>
    <td><asp:Button Text="Search" runat="server" OnClick="Search" CssClass="btn btn-default" /></td>
            </tr>
        </table>
    <hr />
    <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false" 
        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="gvCustomers_SelectedIndexChanged" >
        <Columns>
            <asp:BoundField HeaderStyle-Width="150px"  DataField="ImageUrl"  HeaderText="First Name"
                ItemStyle-CssClass="ContactName" HtmlEncode = "false"  />
            <asp:BoundField HeaderStyle-Width="150px" DataField="Profile_Name" HeaderText="Last Name" />
            <asp:HyperLinkField DataNavigateUrlFields="Action" HeaderText="Action" DataNavigateUrlFormatString="UserAccess.aspx?Edit={0}" DataTextField="Action" />
           
            
        </Columns>
    </asp:GridView>









</asp:Content>
