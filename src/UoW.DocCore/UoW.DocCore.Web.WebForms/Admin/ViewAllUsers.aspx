<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAllUsers.aspx.cs" Inherits="UoW.DocCore.Web.WebForms.ViewAllUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
     <link rel="stylesheet" href="/Content/css/docCoreCommon.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css">

    <script src="//code.jquery.com/jquery-1.9.1.js"></script>
  <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script src="../Content/js/DocCoreBDelegate.js" type="text/javascript"></script>
    <script src="../Content/js/searchbox.js" type="text/javascript"></script>

    <h3>View All Users</h3>
   
    <style type="text/css">
        body {
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
   
    <td><asp:TextBox ID="txtSearch" runat="server" OnTextChanged="Search" CssClass="form-control" /></td>
   <%-- <td><asp:Button Text="Search" runat="server" OnClick="Search" CssClass="btn btn-default" /></td>--%>
            </tr>
        </table>
    <hr />
		<asp:gridview ID="gvCustomers" runat="server" 
AutoGenerateColumns="False" CellPadding="4" PageSize="2"
 AllowPaging="True"
OnPageIndexChanging="gvCustomers_PageIndexChanging" OnSelectedIndexChanged="gvCustomers_SelectedIndexChanged"  EmptyDataText="No Friends Found!!!">
<pagersettings mode="NextPreviousFirstLast"
            nextpagetext="Next"
            previouspagetext="Prev" />
            <alternatingrowstyle BackColor="White" ForeColor="#284775"></alternatingrowstyle>
       
        
        
        <Columns>
            <asp:BoundField HeaderStyle-Width="150px"  DataField="FullName"  HeaderText="Full Name"
                ItemStyle-CssClass="ContactName" HtmlEncode = "false"  />
            <asp:BoundField HeaderStyle-Width="150px" DataField="ProjectRole" HeaderText="Project Role" />
            <asp:HyperLinkField DataNavigateUrlFields="Uid" HeaderText="Action" DataNavigateUrlFormatString="UserRegistration.aspx?Uid={0}" DataTextField="Action" />
           
            
        </Columns>
    </asp:GridView>









</asp:Content>
