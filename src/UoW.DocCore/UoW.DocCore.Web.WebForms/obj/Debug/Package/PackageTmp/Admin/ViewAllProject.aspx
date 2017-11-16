<%@ Page Title="View All Projects" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAllProject.aspx.cs" Inherits="UoW.DocCore.Web.WebForms.Admin.ViewAllProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
      <link rel="stylesheet" href="/Content/css/docCoreCommon.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat ="server" ScrollBars="Auto">
        <h2>View All Project </h2>
        <hr />
   <asp:DataList ID="DataList1" runat="server"  
            BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
            Font-Names="Verdana" Font-Size="Small" GridLines="Both" RepeatColumns="1" RepeatDirection="Horizontal"
            Width="100%" OnItemDataBound="outerRep_ItemDataBound"  >
           
            
       <ItemStyle BackColor="White"   BorderWidth="2px" />
        <ItemTemplate>
            <asp:Table runat="server">
                <asp:TableRow Height="30px" >
                    <asp:TableCell VerticalAlign="Top" Width="200px">
                   <b>Project</b> 
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                    <asp:Label ID="lblName" runat="server"  Text='<%# Bind( "Name")%>' />
                    </asp:TableCell></asp:TableRow>
                 <asp:TableRow>
                    <asp:TableCell Height="20px">

                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell VerticalAlign="Top" Width="200px">
                        <b>Project Managers</b>
                         </asp:TableCell><asp:TableCell>
                         <asp:DataList ID="DataList2" runat="server">
                    <ItemTemplate > 
                        <ul>
                    <li><asp:Label ID="lblName1" runat="server" Text='<%# Bind( "testName")%>'></asp:Label></li>
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
                    
                    <asp:TableCell VerticalAlign="Top" Width="200px">
                        <b>Team Members</b>
                    </asp:TableCell>
                    <asp:TableCell >
                        <asp:DataList ID="DataList3" runat="server">
                    <ItemTemplate  >
                       <ul>
                           <li>
                       <asp:Label ID="lblName3" runat="server" Text='<%# Bind( "testName")%>'></asp:Label></li>
                           </ul>
                     </ItemTemplate>

                </asp:DataList>
                    </asp:TableCell></asp:TableRow></asp:Table></ItemTemplate></asp:DataList></asp:Panel></asp:Content>