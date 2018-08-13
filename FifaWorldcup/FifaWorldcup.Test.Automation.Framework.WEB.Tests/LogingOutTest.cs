﻿using NUnit.Framework;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class LogingOutTest : BaseWebTest
    {
        [Test]
        public void LogOut()
        {
            HomeForm home = new HomeForm();
            string expected = "2018 FIFA World Cup Russia™";
            string actual = home.Header.GetTitleText;
            Assert.AreEqual(expected.ToLower(), actual.ToLower());
            home.Header.OpenLoginForm();

            LoginPopup loginPopup = new LoginPopup();
            expected = loginPopup.GetLoginDescription;
            actual = "Please sign in to your FIFA.com user account below. This will allow you to make the most of your account with personalization, plus get access to commenting tools, exclusive games, the chance to win cool football prizes and much, much more.";
            Assert.AreEqual(expected, actual);
            loginPopup.Login();

            LoginForm loginForm = new LoginForm();
            loginForm.SubmitLoginForm("atlabtestemail@mail.ru", "2lVyjYxxXks5K");
            loginForm.SignIn();

            home.Header.OpenLoginForm();
            loginPopup.LogOut();
            home.Header.OpenLoginForm();
            expected = loginPopup.GetLoginDescription;
            actual = "Please sign in to your FIFA.com user account below. This will allow you to make the most of your account with personalization, plus get access to commenting tools, exclusive games, the chance to win cool football prizes and much, much more.";
            Assert.AreEqual(expected, actual);
        }
    }
}
