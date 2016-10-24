<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomValidation.aspx.cs" Inherits="Ch10.WebFormsExamples.Web.Forms.CustomValidation" %>
<%@ Register Assembly="Ch10.WebFormsExamples.ControlLibrary" Namespace="Ch10.WebFormsExamples.ControlLibrary"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2><asp:Label ID="MessageLabel" runat="server" Text="Please Try and Save"></asp:Label></h2>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <cc1:RequiredFieldValidatorForCheckBox ID="IAgreeCheckBoxRequired" 
                            runat="server" ControlToValidate="IAgreeCheckBox" Display="Dynamic" 
                            ErrorMessage="You must check the box." 
                            >
    </cc1:RequiredFieldValidatorForCheckBox>
                        <br />
    <asp:CheckBox ID="IAgreeCheckBox" runat="server" Text="You Must check this box otherwise we don't like you" />
    <asp:CheckBoxList ID="MustCheckAtleastOne" runat="server"></asp:CheckBoxList>
    <p>
    <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
    </p>
</asp:Content>
