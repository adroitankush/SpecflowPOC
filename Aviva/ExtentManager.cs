using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace Aviva
{
    public class ExtentManager
    {
        public static ExtentHtmlReporter htmlReporter;

        private static ExtentReports extent;
        private ExtentManager()
        {

        }

        public static ExtentReports getInstance(String reportName)
        {
            if (extent == null)
            {
                string filepath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                filepath = Directory.GetParent(Directory.GetParent(filepath).FullName).FullName;
                htmlReporter = new ExtentHtmlReporter(filepath + "/Reports/" + reportName + ".html");
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
                extent.AddSystemInfo("Host Name", Environment.MachineName.ToString());
                extent.AddSystemInfo("Environment", "NA");
                extent.AddSystemInfo("Username", Environment.UserName.ToString());
                htmlReporter.LoadConfig(filepath + "\\extent-config.xml");
            }
            return extent;
        }
    }
}
