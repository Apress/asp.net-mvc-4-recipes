<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ch10.WebFormsExamples.Web._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
                <p>
                This project contains the Web Forms examples used in Chapter 10.
            </p>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h1>Chapter 10 Examples</h1>

            <h2>Data Controls Examples</h2>
            <ol>
                <li><a href="DataControlExamples/RepeaterExample.aspx">Repeater Example</a></li>
                <li><a href="DataControlExamples/DataListExample.aspx">DataList Example</a></li>
                <li><a href="DataControlExamples/GridViewExample.aspx">GridView Example</a></li>
                <li><a href="DataControlExamples/MasterDetailsView.aspx">Master Details View Example</a></li>
            </ol>
    <h2>Forms Examples</h2>
    <ol start="5">
        <li><a href="Forms/CustomValidation.aspx">Custom Validation</a></li>
        <li><a href="UsesMasterNestedMasterPage.aspx">Uses Nested Master Page</a></li>
        <li><a href="Forms/Wizard.aspx">Wizard Example</a></li>
    </ol>

</asp:Content>
