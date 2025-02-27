﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollTestProject1.Reports
{
    public class ExtentReportsManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private static string _reportpath =
            Path.Combine(Directory.GetCurrentDirectory(),"TestResult","Extentreport.html");
        public static void InitReport()
        {
            var sparkReport = new ExtentSparkReporter(_reportpath);
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReport);
        }
        public static void StartTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }
        public static void LogStep(bool isSuccess, string stepDetails)
        {
            if (isSuccess)
            {
                _test.Log(Status.Pass, stepDetails);
            }
            else
            {
                _test.Log(Status.Fail, stepDetails);
            }
        }
        public static void flushReport()
        {
            _extent.Flush();
        }
    }
}
