<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Ch10.WebFormsExamples.Web.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Your app description page.</h2>
    </hgroup>

    <article>
        <p>        
            This application is used in Chapter 10 of the Apress title ASP.NET Recipes and Problem Solution Approach by John Ciliberti. This chapter demonstrates common techniques that have been used in ASP.NET Web Forms programing for the past 12 years. It is purposely using outdated techniques for markup such as tables for layout, HTML markup for colors, and inline style sheets. 
        </p>

        <p>        
            
The Examples in Chapter 10 show how to create the equivocal functionality in ASP.NET MVC 4 and correct that bad markup to modern techniques.

        </p>

        <p>        
            The database uses in this chapter is based on the data from the author’s toy website <a href="http://myonlineband.com">MyOnlineBand.com</a>. This is a real website that allows musicians from every walk of life and almost every nation on the planet to freely collaborate on writing and recording music.
        </p>
    </article>

    <aside>
        <h3>Aside Title</h3>
        <p>        
            If you have questions, you can contact the author at the following email address:
            <br />
            MVCBookQuestions@myonlineband.com
        </p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/About.aspx">About</a></li>
        </ul>
    </aside>
</asp:Content>