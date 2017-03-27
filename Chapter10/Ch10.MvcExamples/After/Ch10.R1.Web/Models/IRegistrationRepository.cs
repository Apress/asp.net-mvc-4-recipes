using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch10.Mvc.Web.Models
{
    public interface IRegistrationRepository
    {
        bool VerifyUserNameIsValid(string name, out string reason, out string[] suggestions);
        void CreateArtist(Artist artist);
        void SendVerification(Artist artist);
        void ReSendVerification(Artist artist);
        string Verify(string verificationCode);
        void SendWelcome(string email, string userName);
    }
}