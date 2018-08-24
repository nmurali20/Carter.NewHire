using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Carter.Framework.Email;
using Carter.NewHire.Model.Interface;
using Carter.NewHire.Model;
using Carter.NewHireUI.Service.Factories;
using Kendo.Mvc.UI;
using NewHireUI.Models;
//using Kendo.Mvc.Extensions;
//using Kendo.Mvc.UI;

namespace NewHireUI.Controllers
{
    
    public class RequestTestController : Controller
    {

        public ActionResult Reqtest()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult SubmitRequest(string empName, DateTime Datereq, DateTime Timereq, NewHireRequestTestViewModel newhire )
        {
            var adInfo = Carter.Framework.ADProvider.ADServiceFactory.GetCurrentInstance.GetCurrentUserInfo(HttpContext.User.Identity.Name);
            var newRecord = newhire.toModel();
            newRecord.EmpName = empName;
            var dating = Datereq.ToShortDateString();
            newRecord.Date = dating;
            //int time = Timereq.Hour;
            var timing = Timereq.ToString("H:mm");
            newRecord.Time = timing;
            //newRecord.CreatedBy = HttpContext.User.Identity.Name;
            newRecord.CreatedBy = "nmurali";
            //newRecord.Emailto = adInfo.Email;
            newRecord.Emailto = "hi@carter-logistics";
            //newRecord.Department = adInfo.Department;
            newRecord.Department = "IT";
            newRecord.Status = "Pending";
            var result = NewHireRequestTestDetailsServiceFactory.GetCurrent.Insert(newRecord);
            var emailrequest = EmailSafety(result.CreatedBy,result.Department,result.Emailto);

            return Json(result != null ? new {Success = true} : new {Success = false});
        }

        private string EmailSafety(string createdby,string department,string emailto)
        {
            var environment = ConfigurationManager.AppSettings["Environment"].ToString(CultureInfo.InvariantCulture);
            var devEmail = ConfigurationManager.AppSettings["DevEmail"].ToString(CultureInfo.InvariantCulture);
            var safetyEmail = ConfigurationManager.AppSettings["SafetyEmail"].ToString(CultureInfo.InvariantCulture);
            var body = ConfigurationManager.AppSettings["EmailText1"].ToString(CultureInfo.InvariantCulture)+createdby+" from " + department + ".Request was submitted on " + DateTime.Now.Date.ToShortDateString()+ ".";
            var subject = ConfigurationManager.AppSettings["EmailSubject"].ToString(CultureInfo.InvariantCulture);

            List<string> to = new List<string>();

            to.Add(environment.ToLower() != "dev" ? safetyEmail : devEmail);

            EmailServiceFactory.GetCurrentInstance.SendMail(to, subject, body);

            return "Submitted";
        }
    }
}