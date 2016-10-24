<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GridViewExample.aspx.cs" Inherits="Ch10.WebFormsExamples.Web.DataControlExamples.GridViewExample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2><asp:Label ID="ProjectsFoundLabel" runat="server" Text="50 projects found"></asp:Label></h2>
    Click on the column headers to sort the projects.
    <nav id="SideBar" class="float-left leftColumn">
        <ul class="voice">
            <asp:Repeater ID="CategoriesRepeater" runat="server">
                <ItemTemplate>
                    <li><a href="/DataControlExamples/GridViewExample.aspx?filter=<%# Eval("GenreLookUpId")%>"><%# Eval("GenreName")%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </nav>
    <div id="main" class="float-right rightColumn">
        <asp:GridView ID="WorkspaceGridView" runat="server" Width="100%"
            AutoGenerateColumns="False" GridLines="None"
            OnPageIndexChanging="WorkspaceGridView_PageIndexChanging"
            OnSorting="WorkspaceGridView_Sorting"
            AllowPaging="True"
            EmptyDataText="MyonlineBand cannot find any projects that match your criteria.">
            <Columns>
                <asp:TemplateField SortExpression="ProjectName" HeaderText="Project">
                    <ItemTemplate>
                        <a href="/MusicianCollaboration/SongWorkspace/<%# Eval("CollaborationSpaceId") %>"
                            title="Click here to view project."
                            class="CollaborationSpaceTitle">
                            <%# Eval("Title") %></a><br />
                        <%# Eval("Description")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Artist" SortExpression="Artist">
                    <ItemTemplate>
                        <a href="<%# Eval("WebSite")%>"><%# Eval("UserName")%>
                            <br />
                            <img src="<%# Eval("AvatarUrl")%>" class="AristImage" alt="Click the image to view this artist's profile" /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField SortExpression="DateCreated" HeaderText="Created">
                    <ItemTemplate>
                        <%# Eval("CreateDate")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Updated" SortExpression="DateModified">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ModifiedDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stats" SortExpression="Stats">
                    <ItemTemplate>
                        <ul class="ItemList">
                            <li>
                                Hits: <asp:Label ID="HitsLabel" runat="server" Text='<%# Bind("NumberViews") %>'></asp:Label>
                            </li>
                            <li>
                                Posts: <asp:Label ID="PostsLabel" runat="server" Text='<%# Bind("NumberComments") %>'></asp:Label>
                            </li>
                            <li>
                                Status: <asp:Label ID="Label2" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                            </li>
                        </ul>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
