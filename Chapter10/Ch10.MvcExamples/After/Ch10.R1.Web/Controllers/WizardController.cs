using Ch10.Mvc.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch10.Mvc.Helpers.Models;

namespace Ch10.Mvc.Web.Controllers
{
    public class WizardController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TitleAndDescription()
        {
            WizardModel model = new WizardModel(GetSteps(0));
            model.CurrentStepIndex = 0;
            return View(model);
        }
        [HttpPost]
        public ActionResult TitleAndDescription(WizardModel model)
        {
            model.CurrentStepIndex = 0;
            model.WizardSteps = GetSteps(1);
            return View(model);
        }

        public ActionResult CollaborationSettings()
        {
            WizardModel model = new WizardModel(GetSteps(1));
            model.CurrentStepIndex = 1;
            return View(model);
        }

        [HttpPost]
        public ActionResult CollaborationSettings(WizardModel model)
        {
            model.CurrentStepIndex = 1;
            model.WizardSteps = GetSteps(1);
            return View(model);
        }

        public ActionResult OpenPositions()
        {
            WizardModel m_model = new WizardModel(GetSteps(2));
            m_model.CurrentStepIndex = 2;
            return View(m_model);
        }
        [HttpPost]
        public ActionResult OpenPositions(WizardModel model)
        {
            model.CurrentStepIndex = 2;
            model.WizardSteps = GetSteps(2);
            return View(model);
        }

        [HttpPost]
        public ActionResult AlertSettings(WizardModel model)
        {
            model.CurrentStepIndex = 3;
            model.WizardSteps = GetSteps(3);
            return View(model);
        }

        IDataExampleRepository m_repository = new EFDataExchangeRepository();
        public ActionResult WizardCompleted()
        {
            WizardModel m_model = new WizardModel(GetSteps(4));
            m_model.CurrentStepIndex = 4;
            m_model.ShowWizardSteps = false;
            //save data here
            if (ModelState.IsValid)
            {
                m_repository.CreateCollaborationSpace(m_model.NewWorkspace);
                m_repository.CreateAds(m_model.NeededSkills);
                m_repository.Save();
            }
            return View(m_model);
        }


        /// <summary>
        /// This is a implementation that uses client side code for changing the Wizard Screens
        /// This is a much simpler approach
        /// </summary>
        /// <returns></returns>
        public ActionResult OnePageWizard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OnePageWizard(WizardModel model)
        {
            if (ModelState.IsValid)
            {
                m_repository.CreateCollaborationSpace(model.NewWorkspace);
                m_repository.CreateAds(model.NeededSkills);
                m_repository.Save();
                return RedirectToAction("OnePageWizardFinish");
            }
            return View(model);
        }

        public ActionResult OnePageWizardFinish()
        {
            return View();
        }

        private List<WizardStep> GetSteps(int currentStepIndex)
        {
            var steps = new List<WizardStep>(){
            new WizardStep{ 
                Action="TitleAndDescription", 
                Controller="Wizard", 
                IsCurrentStep= (0==currentStepIndex),
                StepIndex=0,
                Title="Title &amp; Description "
            },
            new WizardStep{ 
                Action="CollaborationSettings", 
                Controller="Wizard", 
                IsCurrentStep=(1==currentStepIndex),
                StepIndex=1,
                Title="Collaboration Settings"
            },
            new WizardStep{ 
                Action="OpenPositions", 
                Controller="Wizard", 
                IsCurrentStep=(2==currentStepIndex),
                StepIndex=2,
                Title="Open Positions"
            },
            new WizardStep{ 
                Action="AlertSettings", 
                Controller="Wizard", 
                IsCurrentStep=(3==currentStepIndex),
                StepIndex=3,
                Title="Alert Settings"
            },
            new WizardStep{ 
                Action="WizardCompleted", 
                Controller="Wizard", 
                IsCurrentStep=(4==currentStepIndex),
                StepIndex=4,
                Title="Wizard Completed",
                HideOnSideNavigation=true
            }
            };
            return steps;
        }



        protected override void Dispose(bool disposing)
        {
            if((disposing) && (m_repository!=null))
                m_repository.Dispose();

            base.Dispose(disposing);
        }
    }

}
