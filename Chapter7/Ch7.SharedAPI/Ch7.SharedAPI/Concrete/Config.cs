using System;
using System.Collections.Generic;
using System.Text;
using JCBF.Util;

namespace Ch7.SharedAPI.Utility
{
    public class SharedConfig : JCBF.Util.Config
    {
        public static float MaxUploadSizeAudio
        {
            get
            {
                return float.Parse(getStringValueFromAppSettings("MaxUploadSizeAudio", "62914560"));
            }
        }
        public static string FileUploadPathAudio
        {
            get
            {
                return getStringValueFromAppSettings("FileUploadPathAudio", "/Media/Audio/");
            }
        }
        public static string FileUploadPathImages
        {
            get
            {
                return getStringValueFromAppSettings("FileUploadPathDocument", "/Media/Images/");
            }
        }
        public static string FileUploadPathDocument
        {
            get
            {
                return getStringValueFromAppSettings("FileUploadPathDocument", "");
            }
        }
        public static string FileUploadPathMidi
        {
            get
            {
                return getStringValueFromAppSettings("FileUploadPathMidi", "");
            }
        }

        public static string ApplicationURL
        {
            get
            {
                return getStringValueFromAppSettings("ApplicationURL", "http://myonlineband.com");
            }
        }

        public static string DefaultAvitarImage
        {
            get
            {
                return getStringValueFromAppSettings("DefaultAvitarImage", "/Images/defaultProfileImage.png");
            }
        }

        public static string DefaultBandAvitarImage
        {
            get
            {
                return getStringValueFromAppSettings("DefaultBandAvitarImage", "/Images/band_icon.jpg");
            }
        }

        public static string DefaultMediaImage
        {
            get
            {
                return getStringValueFromAppSettings("DefaultAvitarImage", "/Images/SongDefault.jpg");
            }
        }
        public static List<string> BadWords
        {
            get
            {
                string str = getStringValueFromAppSettings("BadWords", "fuck,shit,asshole,cock sucker, mother fucker,tits").ToLower();
                char sep = ',';
                return new List<string>(str.Split(sep));
            }
        }
        public class EmailTemplates
        {

            public static string CommentApproval
            {
                get
                {
                    return getStringValueFromAppSettings("CommentApproval", "MailTemplates\\CommentApproval.htm");
                }
            }
            public static string AuditionApproval
            {
                get
                {
                    return getStringValueFromAppSettings("AuditionApproval", "MailTemplates\\AuditionApproval.htm");
                }
            }
            public static string ProfileCreation
            {
                get
                {
                    return getStringValueFromAppSettings("ProfileCreation", "MailTemplates\\ProfileCreation.htm");
                }
            }
            public static string ProjectInvite
            {
                get
                {
                    return getStringValueFromAppSettings("ProjectInvite", "MailTemplates\\ProjectInvite.htm");
                }
            }
            public static string ProjectInviteInternal
            {
                get
                {
                    return getStringValueFromAppSettings("ProjectInviteInternal", "MailTemplates\\InviteInternal.txt");
                }
            }
            public static string BandInvite
            {
                get
                {
                    return getStringValueFromAppSettings("BandInvite", "MailTemplates\\BandInvite.htm");
                }
            }

            public static string BandAuditionRequest
            {
                get
                {
                    return getStringValueFromAppSettings("BandInvite", "MailTemplates\\BandAuditionRequest.htm");
                }
            }

            public static string WelcomeEmail
            {
                get
                {
                    return getStringValueFromAppSettings("WelcomeEmail", "MailTemplates\\WelcomeEmail.htm");
                }
            }

            public static string EmailVerifyEmail
            {
                get
                {
                    return getStringValueFromAppSettings("EmailVerifyEmail", "NewUserEmail.txt");
                }
            }

            public static string WorkSpacePublished
            {
                get
                {
                    return getStringValueFromAppSettings("WorkSpacePublished", "MailTemplates\\PublishProject.htm");
                }
            }

            public static string WorkSpaceUpdated
            {
                get
                {
                    return getStringValueFromAppSettings("WorkSpacePublished", "MailTemplates\\ProjectUpdateAlert.htm");
                }
            }
            public static string WorkSpacePublishedNoTask
            {
                get
                {
                    return getStringValueFromAppSettings("WorkSpacePublishedNoTask", "MailTemplates\\PublishProjectNoAdd.htm");
                }
            }

            public static string NewMailEmailAlertTemplate
            {
                get
                {
                    return getStringValueFromAppSettings("NewMailEmailAlertTemplate", "MailTemplates\\NewMail.htm");
                }
            }
        }
    }
}
