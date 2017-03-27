<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wizard.aspx.cs" Inherits="Ch10.WebFormsExamples.Web.Forms.Wizard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <asp:ValidationSummary runat="server" />      
    <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" OnActiveStepChanged="Wizard1_ActiveStepChanged" OnCancelButtonClick="Wizard1_CancelButtonClick" OnFinishButtonClick="Wizard1_FinishButtonClick" FinishDestinationPageUrl="~/">
        <WizardSteps>
            <asp:WizardStep ID="WizardStep1" runat="server" Title="Title & Description">
                <fieldset>
                    <legend>Describe your project</legend>
                    <label>Title</label>
                    <div>
                    <asp:TextBox ID="projectNameTextBox" runat="server" MaxLength="40" Width="350px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="projectNameRequiredFieldValidator" Display="None" 
                                ControlToValidate="projectNameTextBox" runat="server" 
                                ErrorMessage="Please enter a project name."></asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <label>Project Description</label>
                        <asp:TextBox ID="projectDescriptionFreeTextBox" runat="server" TextMode="MultiLine" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="projectDescriptionValidator"
                                ControlToValidate="projectDescriptionFreeTextBox" runat="server" Display="None"
                                ErrorMessage="Please enter a description for the project."></asp:RequiredFieldValidator>
                    </div>
                </fieldset>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="Collaboration Setting">
                <fieldset>
                    <legend>Choose who can collaborate with you on your project</legend>
                    <asp:RadioButtonList ID="CollaborationMode" runat="server" RepeatDirection="Vertical">
                        <asp:ListItem Selected="True" Text="Let anyone contribute"></asp:ListItem>
                        <asp:ListItem  Text="Allow anyone to see the project by only allow members of my band to contribute"></asp:ListItem>
                        <asp:ListItem  Text="Keep this workspace hidden and only allow members of my band to contribute"></asp:ListItem>
                    </asp:RadioButtonList>
                </fieldset>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep3" runat="server" Title="Open Positions">
                <fieldset>
                    <legend>Create Want Ads to get help on your project</legend>
                    <div>
                        <asp:CheckBoxList ID="AuditionsCheckBoxList" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Bass Guitar"></asp:ListItem>
                                <asp:ListItem Text="Drums"></asp:ListItem>
                                <asp:ListItem Text="Guitar"></asp:ListItem>
                                <asp:ListItem Text="Keyboards"></asp:ListItem>
                                <asp:ListItem Text="Vocal"></asp:ListItem>
                                <asp:ListItem Text="Lyricist"></asp:ListItem>
                                <asp:ListItem Value="Producer" Text="Mixing / Production"></asp:ListItem>
                                <asp:ListItem Text="Songwriter"></asp:ListItem>
                            </asp:CheckBoxList>
                    </div>
                    <div>
                        <label>General Comment about skills needed</label>
                        <asp:TextBox ID="AuditionCommentTextBox" runat="server" TextMode="MultiLine" ></asp:TextBox>
                    </div>
                    <div>
                          <label>Skill Level</label>
                        <asp:RadioButtonList ID="skillLevelRadioButton" runat="server" RepeatDirection="Horizontal"
                                ToolTip="What is your overall skill level for this talent.">
                                <asp:ListItem>Master</asp:ListItem>
                                <asp:ListItem>Advanced</asp:ListItem>
                                <asp:ListItem Selected="True">Intermediate</asp:ListItem>
                                <asp:ListItem>Beginner</asp:ListItem>
                            </asp:RadioButtonList>
                    </div>
                </fieldset>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep4" runat="server" Title="Alert Settings">
                <asp:CheckBox ID="EmailAlertCheckBox" runat="server" Text="Send me an email alert when a new file or comment is added to this workspace." />
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
        </section>
</asp:Content>
