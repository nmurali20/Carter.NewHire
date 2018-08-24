using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carter.Framework.Email;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using WebGrease.Css.Extensions;
using Carter.NewHire.Model.Interface;
using Carter.NewHireUI.Service.Factories;
using NewHireUI.Models;


namespace NewHireUI.Controllers
{
    public class SafetyController : Controller
    {
        // GET: Safety
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult DataGridRead([DataSourceRequest] DataSourceRequest request)
        {
           var result = NewHireRequestTestDetailsServiceFactory.GetCurrent.GetAllRequests().Select(d => new NewHireRequestTestViewModel(d)).ToDataSourceResult(request);

                return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DataGridStatusUpdate([DataSourceRequest] DataSourceRequest request, NewHireRequestTestViewModel newHire)
        {
            string emailstatus;
            if (ModelState.IsValid)
            {
                NewHireRequestTestDetailsServiceFactory.GetCurrent.Update(newHire.Id,newHire.Status);
                emailstatus = CheckUpdatedStatus(newHire.Status,newHire.Emailto,newHire.EmpName);
            }

            return Json(ModelState.IsValid ? new NewHireRequestTestViewModel() : ModelState.ToDataSourceResult());

        }

        private string CheckUpdatedStatus(string status, string emailto,string Empname)
        {
            var environment = ConfigurationManager.AppSettings["Environment"].ToString(CultureInfo.InvariantCulture);
            var devEmail = ConfigurationManager.AppSettings["DevEmail"].ToString(CultureInfo.InvariantCulture);
            var ManagerEmail = emailto;
            var subject = ConfigurationManager.AppSettings["EmailSubject2"].ToString(CultureInfo.InvariantCulture);
            string body = null;


            List<string> to = new List<string>();

            to.Add(environment.ToLower() != "dev" ? ManagerEmail : devEmail);

            switch (status)
            {
                case "Fail":
                    body = ConfigurationManager.AppSettings["EmailTextResult"].ToString(CultureInfo.InvariantCulture)+ Empname+"has FAILED the DrugTest.";
                    break;
                case "Rescheduled":
                    body = ConfigurationManager.AppSettings["EmailTextReschedule"].ToString(CultureInfo.InvariantCulture)+ Empname;
                    break;
                case "Pass":
                    body = ConfigurationManager.AppSettings["EmailTextResult"].ToString(CultureInfo.InvariantCulture)+Empname+"has "+"PASSED "+"the "+"DrugTest.Please "+"complete "+"and "+"submit "+"the "+"NewEmployee "+"form "+"accessible "+"via "+"the "+"provided "+"link-EmployeeForm/Home";
                    break;
            }

            EmailServiceFactory.GetCurrentInstance.SendMail(to, subject, body);
            return "email sent";
        }

        public JsonResult GetAllStatuses([DataSourceRequest] DataSourceRequest request)
        {
            var result = StatusServiceFactory.GetCurrent.GetStatuses().Select(x => new StatusViewModel(x));
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
    }

    
}
