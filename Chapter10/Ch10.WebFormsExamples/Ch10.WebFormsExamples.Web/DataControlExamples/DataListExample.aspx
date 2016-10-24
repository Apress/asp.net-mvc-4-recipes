<%@ Page Title="DataList Control Example" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataListExample.aspx.cs" Inherits="Ch10.WebFormsExamples.Web.DataControlExamples.DataListExample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
            <style type="text/css">
            .ImageDiv{ float:left; backface-visibility: hidden;}
            .ContentDiv{ float:left; padding:5px; backface-visibility: hidden;}
            .ContentDiv ul{ list-style-type:none; margin:0; padding:0;}
            .ContentDiv li{ padding:2px;}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DataList ID="NewArtistDataList" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" CellSpacing="3" ViewStateMode="Disabled">
        <ItemTemplate>
            <a href="/<%#Eval("UserName")%>">
                <div class="evenbox">
                    <div class="ImageDiv">
                        <img src="<%#Eval("AvatarUrlSample") %>" class="AristImage" alt="Click Image to view full profile" />
                    </div>
                    <div class="ContentDiv">
                        <ul>
                            <li>
                                <%#Eval("UserName")%> 
                            </li>
                            <li><%#Eval("Provence")%></li>
                            <li><%#Eval("Country")%>   </li>
                            <li>Joined :
                                <date><%#Eval("CreateDate","{0:d}")%></date>
                            </li>
                        </ul>
                    </div>
                </div>
            </a>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
