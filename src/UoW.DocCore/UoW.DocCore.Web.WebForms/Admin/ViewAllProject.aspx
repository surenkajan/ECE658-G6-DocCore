<%@ Page Title="View All Projects" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAllProject.aspx.cs" Inherits="UoW.DocCore.Web.WebForms.Admin.ViewAllProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
      <link rel="stylesheet" href="/Content/css/docCoreCommon.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">  
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css">

    <script src="//code.jquery.com/jquery-1.9.1.js"></script>
  <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script src="../Content/js/DocCoreBDelegate.js" type="text/javascript"></script>
    <script src="../Content/js/searchbox_Project.js" type="text/javascript"></script>
    <asp:Panel runat ="server" ScrollBars="Auto">
        
         <table>
        <tr>
            <td><h2>View All Project </h2></td>
            </tr>
             <tr>
  <td><asp:Label ID="Label1" runat="server" Text="Search:" > </asp:Label></td>
   
    <td><asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" /></td>
  <%--  <td><asp:Button Text="Search" runat="server" OnClick="Search" CssClass="btn btn-default" /></td>--%>
            </tr>
        </table>
        <hr />
   <asp:DataList ID="DataList1" runat="server"  
            BorderStyle="None"  CellPadding="3" CellSpacing="2"
            Font-Names="Verdana" Font-Size="Small" GridLines="Horizontal" RepeatColumns="1" RepeatDirection="Horizontal"
            Width="100%" OnItemDataBound="outerRep_ItemDataBound"  >

           
            
       <ItemStyle BackColor="White"   />
        <ItemTemplate>
            <asp:Table runat="server">

                <asp:TableRow Height="30px" >
                    
                    <asp:TableCell HorizontalAlign="Left" Width="40%">
                       
                   <asp:Label ID="lblName" runat="server" Font-Size="Medium" ForeColor="#3366cc" Text='<%# Bind( "projectName")%>' /></li>
                      
                            <asp:HiddenField runat="server" id="HiddenField1" Value='<%# Bind("pID") %>' />
                            
                    </asp:TableCell></asp:TableRow>

             
                 <asp:TableRow>
                    <asp:TableCell Height="20px">

                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top"  >
                        <b>Project Managers</b>
                         </asp:TableCell><asp:TableCell Width="50%">
                         <asp:DataList ID="DataList2" runat="server">
                    <ItemTemplate > 
                        <ul>
                    <li><asp:Label ID="lblName1" runat="server" Text='<%# Bind( "FullName")%>'></asp:Label></li>
                            </ul>
                     </ItemTemplate>

                </asp:DataList>
                   </asp:TableCell>
                 </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Height="20px">

                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow  >
                    
                    <asp:TableCell VerticalAlign="Top" >
                        <b>Team Members</b>
                    </asp:TableCell>
                    <asp:TableCell >
                        <asp:DataList ID="DataList3" runat="server">
                    <ItemTemplate  >
                       <ul>
                           <li>
                       <asp:Label ID="lblName3" runat="server" Text='<%# Bind( "FullName")%>'></asp:Label></li>
                           </ul>
                     </ItemTemplate>


                </asp:DataList>
                    </asp:TableCell>
                     <asp:TableCell  HorizontalAlign="Center" Width="40%">
                       
                         <asp:HyperLink Runat =server NavigateUrl ='<%#"Project.aspx?Uid=" + DataBinder.Eval(Container.DataItem, "pID").ToString()%>' ID="Hyperlink1">
                              Edit Project
                           </asp:HyperLink>
                          

                         <%--<asp:Button ID="Button3" runat="server" Text="Edit Project" OnClick="UpdateProject" CssClass="btn btn-default" />  --%>
                      
                     </asp:TableCell>
                </asp:TableRow></asp:Table></ItemTemplate></asp:DataList></asp:Panel></asp:Content>