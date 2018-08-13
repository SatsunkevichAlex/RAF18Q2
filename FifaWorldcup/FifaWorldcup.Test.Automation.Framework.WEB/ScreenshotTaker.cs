using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects
{
    public class ScreenshotTaker
    {
        List<Screenshot> FailedTestsScreenshots;
        List<string> Faildtestname;

        public ScreenshotTaker()
        {
            this.FailedTestsScreenshots = new List<Screenshot>();
            this.Faildtestname = new List<string>();
        }
        /// <summary>
        /// method add screenshot to list
        /// </summary>
        public void MakeScreen()
        {
            int pointer = 1;
            var stackTrace = new StackTrace(true);
            var methodnameandclassname = stackTrace.GetFrame(pointer);
            Screenshot myScreenShot = ((ITakesScreenshot)Browser.Driver).GetScreenshot();
            FailedTestsScreenshots.Add(myScreenShot);
            Faildtestname.Add(methodnameandclassname.GetType().Name+methodnameandclassname.GetMethod().Name);
        }

        /// <summary>
        /// this method print screenshots of faild tests to the specified directory
        /// </summary>
        /// <param name="directory">path to directory</param>
        public void PrintScreenshotsTo(string directory = "")
        {
            directory = (
                directory == string.Empty || directory == null ? directory = Directory.GetCurrentDirectory() : directory
                );
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            int i = 0;
            foreach (Screenshot screenshot in FailedTestsScreenshots)
            {
                screenshot.SaveAsFile(directory + Faildtestname[i] + DateTime.Now.ToString("dd.MM") + ".png");
                i++;
            }
        }
    }
}