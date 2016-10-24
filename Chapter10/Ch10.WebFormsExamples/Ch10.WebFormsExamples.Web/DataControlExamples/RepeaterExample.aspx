<%@ Page Title="Repeater Example" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RepeaterExample.aspx.cs" Inherits="Ch10.WebFormsExamples.Web.DataControlExamples.RepeaterExample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        This example shows how to use the Repeater control with a custom data object. It is using the new ItemType property which was introduced in ASP.NET 4.5 to provide Intellisence when creating web forms.  It also demonstrates the use of an ItemDataBound event to populate the contents of the location column.
    </p>
    <p>
Recipe 10-1 will show you how to create a functionally equivalent example using ASP.NET MVC with the Razor view engine.
    </p>
    
    <asp:Repeater ID="ArtistsRepeater" 
        runat="server" 
        ItemType="Ch7.SharedAPI.Artist"  
        OnItemDataBound="ArtistsRepeater_ItemDataBound">
        <HeaderTemplate>
            <table width="95%" cellpadding="5" cellspacing="5">
        <thead>
            <tr>
                <th>
                    User
                </th>
                <th>
                    Location
                </th>
                <th>
                    Account Creation Date
                </th>
            </tr>
        </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr bgcolor="#AAAAAA" valign="top">
            <td width="150px">
                <asp:Image Height="100px" Width="100px" 
                    ImageUrl="<%# Item.AvatarUrlSample %>" 
                    AlternateText="<%# Item.UserName %>" runat="server" />
                <br />
                <asp:HyperLink NavigateUrl="/<%# Item.UserName %>" 
                    Text="<%# Item.UserName %>" 
                    runat="server" 
                    ID="ProfileHyperLink"></asp:HyperLink>
            </td>
            <td width="150px">
               <asp:Label ID="LocationLabel" runat="server"></asp:Label>
            </td>
            <td>
                <%# Item.CreateDate.ToShortDateString()%>
            </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr bgcolor="#EEEEEE" valign="top">
            <td width="150px">
                <asp:Image ID="Image1" Height="100px"
                     Width="100px" 
                    ImageUrl="<%# Item.AvatarUrlSample %>" 
                    AlternateText="<%# Item.UserName %>" 
                    runat="server" />
                <br />
                <asp:HyperLink ID="ProfileHyperLink" 
                    NavigateUrl="/<%# Item.UserName %>" 
                    Text="<%# Item.UserName %>" 
                    runat="server"></asp:HyperLink>
            </td>
            <td width="150px">
                <asp:Label ID="LocationLabel" runat="server"></asp:Label>
            </td>
                <td>
                    <%# Item.CreateDate.ToShortDateString()%>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <SeparatorTemplate>
            <tr>
                <td colspan="3" 
                    style="background-color:#DDDDDD; height:1px;"></td>
            </tr>
        </SeparatorTemplate>
        <FooterTemplate>
             </table>
        </FooterTemplate>
    </asp:Repeater>
    
</asp:Content>
