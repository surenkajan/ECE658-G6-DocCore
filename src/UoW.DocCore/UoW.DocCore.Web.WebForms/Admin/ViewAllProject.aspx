<%@ Page Title="View All Projects" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAllProject.aspx.cs" Inherits="UoW.DocCore.Web.WebForms.Admin.ViewAllProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
      <link rel="stylesheet" href="/Content/css/docCoreCommon.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">  
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css">

    <script src="//code.jquery.com/jquery-1.9.1.js"></script>
  <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script src="/Content/js/DocCoreBDelegate.js" type="text/javascript"></script>
    <script src="/Content/js/searchbox_Project.js" type="text/javascript"></script>
    
    <asp:Panel runat ="server" ScrollBars="Auto">
        
         <table>
        <tr>
            <td style="align-self:center"><h2>View All Project </h2></td>
            </tr>
             <tr>
  <td><asp:Label ID="Label1" runat="server" Text="Search:" Font-Size="Medium" > </asp:Label></td>
   
    <td style="text-align:left"><asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" /></td>
  <%--  <td><asp:Button Text="Search" runat="server" OnClick="Search" CssClass="btn btn-default" /></td>--%>
            </tr>
        </table>
        <hr />
   <asp:DataList ID="DataList1" runat="server"  CellPadding="4"
            Font-Names="Verdana" Font-Size="Small" RepeatColumns="1" RepeatDirection="Horizontal"
            Width="70%" OnItemDataBound="outerRep_ItemDataBound" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="#333333"  >

           
            
       <AlternatingItemStyle BackColor="White" />
       <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
       <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

           
            
       <ItemStyle BackColor="#EFF3FB"   />
        <ItemTemplate>
            <asp:Table runat="server">

                <asp:TableRow Height="30px" >
                    
                    <asp:TableCell HorizontalAlign="Left" Width="50%">
                       
                   <asp:Label ID="lblName" runat="server" Font-Size="Medium" ForeColor="#3366cc" Text='<%# Bind( "projectName")%>' /></li>
                      
                            <asp:HiddenField runat="server" id="HiddenField1" Value='<%# Bind("pID") %>' />
                         <asp:HyperLink Runat =server NavigateUrl ='<%#"Project.aspx?Uid=" + DataBinder.Eval(Container.DataItem, "pID").ToString()%>' ToolTip="Edit Project"  ID="Hyperlink1">
                              <img src="../Content/Images/extNew/edit.png" height="25" width="25" />
                         </asp:HyperLink>   
                    </asp:TableCell><asp:TableCell>
                          
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell Height="20px">

                    </asp:TableCell></asp:TableRow><asp:TableRow>
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
                   </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell Height="20px">

                    </asp:TableCell></asp:TableRow><asp:TableRow  >
                    
                    <asp:TableCell VerticalAlign="Top" >
                        <b>Team Members</b>
                    </asp:TableCell><asp:TableCell >
                        <asp:DataList ID="DataList3" runat="server">
                    <ItemTemplate  >
                       <ul>
                           <li>
                       <asp:Label ID="lblName3" runat="server" Text='<%# Bind( "FullName")%>'></asp:Label></li>
                           </ul>
                     </ItemTemplate>


                </asp:DataList>
                    </asp:TableCell><asp:TableCell  HorizontalAlign="Center" Width="40%">
                       
                       
                          

                         <%--<asp:Button ID="Button3" runat="server" Text="Edit Project" OnClick="UpdateProject" CssClass="btn btn-default" />  --%>
                      
                     </asp:TableCell></asp:TableRow></asp:Table></ItemTemplate><SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" /></asp:DataList></asp:Panel></asp:Content>