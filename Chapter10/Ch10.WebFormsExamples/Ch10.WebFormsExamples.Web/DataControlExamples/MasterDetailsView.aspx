<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MasterDetailsView.aspx.cs" Inherits="Ch10.WebFormsExamples.Web.DataControlExamples.MasterDetailsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="ObjectDataSourceList" runat="server" SelectMethod="GetNewArtistList" TypeName="Ch10.WebFormsExamples.Web.ObjectDataSources.ExampleDataSource"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSourceDetail" SelectMethod="GetArtistDetails" TypeName="Ch10.WebFormsExamples.Web.ObjectDataSources.ExampleDataSource" runat="server">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="id" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <section class="MasterList">
        <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSourceList" AutoGenerateColumns="False" DataKeyNames="ArtistId">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="UserName" HeaderText="User Name" />
                <asp:BoundField DataField="Country" HeaderText="Country" />
                <asp:BoundField DataField="Provence" HeaderText="Provence" />
                <asp:BoundField DataField="CreateDate" HeaderText="Create Date" />
            </Columns>
        </asp:GridView>
    </section>
    <section class="DetailsList">
                <h3>Details</h3>
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" DataSourceID="ObjectDataSourceDetail" EmptyDataText="Please select a record"></asp:DetailsView>
    </section>
</asp:Content>
