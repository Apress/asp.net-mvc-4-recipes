function WizardSubmit(action, formId) {
    if (undefined == formId)
        formId = 0;
    document.forms[formId].action = "/" + action;
    document.forms[formId].submit();
}

var m_CurrentStep, m_TotalSteps, m_CanShowFinish;

function ShowWizardStep(wizardStepNumber) {
    $("#WizardStep_" + m_CurrentStep).removeClass("selected");
    $("#WizardStep_Div_" + m_CurrentStep).hide();
    $("#WizardStep_" + wizardStepNumber).addClass("selected");
    $("#WizardStep_Div_" + wizardStepNumber).show();
    m_CurrentStep = wizardStepNumber;
    ShowHideButtons();
}

function WizardNext() {
    if ($("#WizardForm0").valid()) {
        $("#WizardStep_" + m_CurrentStep).removeClass("selected");
        $("#WizardStep_Div_" + m_CurrentStep).hide("slide", { direction: "right" },
            function () {
                $("#WizardStep_" + m_CurrentStep).addClass("selected");
                m_CurrentStep = m_CurrentStep + 1;
                $("#WizardStep_Div_" + m_CurrentStep).show("slide", { direction: "left" });
                ShowHideButtons();
            });
    }

}


function WizardBack() {
    $("#WizardStep_" + m_CurrentStep).removeClass("selected");
    $("#WizardStep_Div_" + m_CurrentStep).hide("slide",{direction: "left"},
        function () {
            m_CurrentStep = m_CurrentStep - 1;
            $("#WizardStep_" + m_CurrentStep).addClass("selected");
            $("#WizardStep_Div_" + m_CurrentStep).show("slide", { direction: "right" });
            ShowHideButtons();
        });


}

function ShowHideButtons() {
    if (m_CurrentStep == 0)
        $("#BackButton").hide();
    else
        $("#BackButton").show();

    if (m_CurrentStep == (m_TotalSteps - 1))
        $("#NextButton").hide();
    else
        $("#NextButton").show();
    if (m_CurrentStep > 2)
        m_CanShowFinish = true;
    if (m_CanShowFinish == true)
        $("#FinishButton").show();
    else
        $("#FinishButton").hide();
}

function WizardInit(numberOfSteps) {
    m_CurrentStep = 0;
    m_TotalSteps = numberOfSteps;
    m_CanShowFinish = false;
    $("#WizardStep_0").addClass("selected");
    $("#WizardStep_Div_0").show();
    $("#BackButton").hide();
    $("#FinishButton").hide();

}

