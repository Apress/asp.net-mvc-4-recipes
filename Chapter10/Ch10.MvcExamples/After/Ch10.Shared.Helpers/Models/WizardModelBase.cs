using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch10.Mvc.Helpers.Models
{
    public class WizardModelBase
    {
        public WizardModelBase() { }
        public WizardModelBase(List<WizardStep> wizardSteps)
        { 
            WizardSteps = wizardSteps;
            ShowWizardSteps = true;
        }

        public int CurrentStepIndex { get; set; }
        public bool AllowFinish { get; set; }

        public string CurrentStep(int step)
        {
            if (step == CurrentStepIndex)
                return "selected";
            else
                return "step";
        }

        public bool ShowBackButton
        {
            get
            {
                //hide on first step and on finished page
                return CurrentStepIndex > 0 && (CurrentStepIndex!=WizardSteps.Count - 1);
            }
        }

        public bool ShowWizardSteps { get; set; }

        public bool ShowNextButton
        {
            get
            {
                return WizardSteps != null &&  
                    WizardSteps.Count!=0 &&
                    CurrentStepIndex != WizardSteps.Count - 1;
            }
        }

        public WizardStep FinishAction {
            get
            {
                if (WizardSteps != null)
                    return WizardSteps[WizardSteps.Count - 1];
                else
                    return null;
            }
        }
        public List<WizardStep> WizardSteps { get; set; }
        public WizardStep LastWizardStep
        {
            get
            {
                if (WizardSteps != null)
                {
                    if (CurrentStepIndex == 0)
                        return WizardSteps[0];
                    else
                        return WizardSteps[CurrentStepIndex - 1];
                }
                return null;
            }
        }

        public WizardStep NextWizardStep
        {
            get
            {
                if (WizardSteps != null)
                {
                    if (CurrentStepIndex == (WizardSteps.Count-1))
                        return WizardSteps[CurrentStepIndex];
                    else if((CurrentStepIndex == (WizardSteps.Count - 1)) &&
                        CurrentStepIndex==0)
                        return WizardSteps[CurrentStepIndex];
                    else
                        return WizardSteps[CurrentStepIndex + 1];
                }
                return null;
            }
        }
    }

    public class WizardStep
    {
        public int StepIndex { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Title { get; set; }
        public bool IsCurrentStep { get; set; }
        public bool HideOnSideNavigation { get; set; }
    }
}