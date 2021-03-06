﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BatchDownloaderCore;
using Flurl;
using System.IO;
using System.Diagnostics;
using BatchDownloaderCore.ApiMethods;
using RestSharp;
using BatchDownloaderCore.ApiCalls;

namespace BatchDownloaderGUI
{
    public static class Tests
    {

        public static void RunTests()
        {
            //Test_AddDownloads();
            //Test_ParamLessMethods();
            //Test_MethodFactory();
            //Test_Login();
            Test_MethodRepresentations();
        }

        public static void Test_MethodFactory()
        {
            //var gm = new GetPackageInfo(
            //    new Parameter 
            //{ 
            //    Name = "test",
            //    Value = "bla",
            //    Type = ParameterType.GetOrPost 
            //});
        }


        public static void Test_Login()
        {
            var apiCaller = new ApiCaller("192.168.1.35", 8000);

            var loggedIn = apiCaller.Login("nas", "nas");

            var links = new List<Url>
            {
                new Url(@"http://uploaded.net/file/zlrwd0pw"),
                new Url(@"http://uploaded.net/file/zqh6mdzf"),
                new Url(@"http://uploaded.net/file/zwshn6au"),
                new Url(@"http://uploaded.net/file/zxvzn7r5"),
            };

            var pid = apiCaller.AddPackage(links.Select(l => l.ToString()).ToArray());

            var package = apiCaller.GetPackageInfo(pid);

            Console.WriteLine(String.Format("Folder: {0} | {1} of {2} links downloaded", 
                package.folder, package.stats.linksdone, package.stats.linkstotal));

        }

        public static void Test_MethodRepresentations()
        {
            var api = new ApiCaller("192.168.1.35", 8000);

            var l = api.Login("nas", "nas");

            //Debug.WriteLine(l);

            api.UnpauseServer();


        }



    }
}
