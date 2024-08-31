using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechProjectHub.App_Code;
using TechProjectHub.Models;
using System.IO;

namespace TechProjectHub.Controllers
{
    [Authorize_Manager]
    public class ManagerController : Controller
    {
        // GET: Manager
        Tech_Project_HubDBEntities1 db = new Tech_Project_HubDBEntities1();
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult PostProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostProject(ProjectMaster pm)
        {
            string msg = "";
            try
            {
                string fPath = Server.MapPath("/Content/ManagerPostProject");
                HttpPostedFileBase myfile = Request.Files["Project_File"];
                if (myfile != null)
                {
                    if (myfile.ContentLength > 0)
                    {
                        string fName = Path.GetRandomFileName() + myfile.FileName;
                        string filetype = fName.Substring(fName.LastIndexOf('.')).ToUpper();
                        if (filetype == ".DOC" || filetype == ".DOCX" || filetype == ".RAR" || filetype == ".PDF" || filetype == ".ZIP" || filetype == ".TXT")
                        {
                            if (!Directory.Exists(fPath))
                            {
                                Directory.CreateDirectory(fPath);
                            }
                            myfile.SaveAs(fPath + "/" + fName);
                            pm.Project_DT= DateTime.Now;
                            pm.Project_File= fName;
                            db.ProjectMasters.Add(pm);
                            db.SaveChanges();
                            msg = "Project posted Successfully";
                        }
                    }
                    else
                    {
                        msg = "Invalid file type. Please choose a valid file.";
                    }
                }
                else
                {
                    msg = "Please choose a project file.";
                }
            }
            catch
            {
                msg = "Sorry! Due to some technical issue. We are unable to upload your code";
            }
            ViewBag.Project=msg;
            return View(); 
        }
        public ActionResult WorkRequest()
        {
            List<RequestMaster> rqlst = db.RequestMasters.OrderByDescending(x => x.Request_Id).ToList();
            return View(rqlst);
        }
        public ActionResult SearchDeveloper()
        {
            return View();
        }
        public ActionResult MyProject()
        {
            List<ProjectMaster> pmlst = db.ProjectMasters.OrderByDescending(x => x.Project_Id).ToList();
            return View(pmlst);
        }
        [HttpGet]
        public ActionResult UploadTask()
        {
            List<DeveloperMaster> dmlst = db.DeveloperMasters.ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach(DeveloperMaster dev in dmlst)
            {
                SelectListItem lst = new SelectListItem();
                lst.Text = dev.Name;
                lst.Value = dev.Email_Id;
                list.Add(lst);
            }
            ViewBag.ForDeveloper = list;
            return View();
        }
        [HttpPost]
        public ActionResult UploadTask(TaskMaster tm)
        {
            string msg = "";
            List<DeveloperMaster> dmlst = db.DeveloperMasters.ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DeveloperMaster dev in dmlst)
            {
                SelectListItem lst = new SelectListItem();
                lst.Text = dev.Name;
                lst.Value = dev.Email_Id;
                list.Add(lst);
            }
            ViewBag.ForDeveloper = list;
            
            try
            {
                string fPath = Server.MapPath("/Content/UploadTask");
                HttpPostedFileBase myfile = Request.Files["TaskFile"];
                if (myfile != null)
                {
                    if (myfile.ContentLength > 0)
                    {
                        string fName = Path.GetRandomFileName() + myfile.FileName;
                        string filetype = fName.Substring(fName.LastIndexOf('.')).ToUpper();
                        if (filetype == ".DOC" || filetype == ".DOCX" || filetype == ".RAR" || filetype == ".PDF" || filetype == ".ZIP" || filetype == ".TXT")
                        {
                            if (!Directory.Exists(fPath))
                            {
                                Directory.CreateDirectory(fPath);
                            }
                            myfile.SaveAs(fPath + "/" + fName);
                            tm.UploadedOn = DateTime.Now;
                            tm.TaskFile = fName; //file name
                            db.TaskMasters.Add(tm);
                            db.SaveChanges();
                            msg = "Task Uploaded Successfully";
                        }
                    }
                    else
                    {
                        msg = "Invalid file type. Please choose a valid file.";
                    }
                }
                else
                {
                    msg = "Please choose a task file.";
                }
            }
            catch
            {
                msg = "Sorry! Due to some technical issue. We are unable to upload your task";
            }
            ViewBag.UploadTask = msg;
            return View();
        }
        public ActionResult ViewReport()
        {
            List<WorkReportMaster> wrt = db.WorkReportMasters.OrderByDescending(x => x.Report_Id).ToList();
            return View(wrt);
        }
        public ActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(string SendTo,string Subject, string Message)
        {
            string msg = "";
            EmailSender em = new EmailSender();
            try
            {
                bool res = em.SendMyEmail(SendTo, Subject, Message);
                if(res==true)
                {
                    msg = "Email send successfully";

                }
                else
                {
                    msg = "Sorry! Unabale to send email";
                }
            }
            catch
            {
                msg = "Sorry! We can't process it. ";
            }
            ViewBag.SendMail = msg;
            return View();
        }

        [HttpGet]
        public ActionResult ViewDeveloper()
        {
            List<DeveloperMaster> lst = db.DeveloperMasters.OrderByDescending(x => x.Registered_On).ToList();

            return View(lst);
        }
        [HttpPost]
        public ActionResult ViewDeveloper(string SearchValue)
        {
            List<DeveloperMaster> lst = db.DeveloperMasters.Where(x => x.Name.Contains(SearchValue) || x.Email_Id.Contains(SearchValue) || x.Designation.Contains(SearchValue)).ToList();
            return View(lst);
        }
        public ActionResult RemoveDeveloper(string uid)
        {
           string  msg = "";
            try
            {

                DeveloperMaster dm = db.DeveloperMasters.Find(uid);
                db.DeveloperMasters.Remove(dm);
                db.SaveChanges();
                msg = "Developer Account Deleted Sucessfully";
            }
            catch
            {
                msg = "Sorry! Unable to delete account.";
            }
            TempData["Message"] = msg;
            return RedirectToAction("ViewDeveloper", "Manager");
        }
        public ActionResult DownloadCode()
        {
            List<UploadCodeMaster> ust = db.UploadCodeMasters.OrderByDescending(x => x.Upload_Id).ToList();
            return View(ust);
        }
        public FileResult Download(string fname)
        {
            string Pathfile = "/Content/UploadCode/" + fname;
            return File(Pathfile,"application/force-download",Path.GetFileName(Pathfile));
        }
        public ActionResult EnquiryMgmt()
        {
            List<EnquiryMaster> em = db.EnquiryMasters.OrderByDescending(x => x.Enq_Id).ToList();
            return View(em);
        }
        public ActionResult ManageFeedback()
        {
            List<FeedbackMaster> list = db.FeedbackMasters.OrderByDescending(x=>x.Fid.ToString()).ToList();
            return View(list);
        }
        public ActionResult NotificationMgmt()
        {
            List<NotificationMaster> ntf = db.NotificationMasters.OrderByDescending(x => x.Nid).ToList();
            return View(ntf);
        }
        [HttpPost]
        public ActionResult NotificationMgmt(NotificationMaster nm)
        {
            string msg = "";
            try
            {
                nm.NDT = DateTime.Now.ToString();
                db.NotificationMasters.Add(nm);
                db.SaveChanges();
                msg = "Notification saved successfully.";
            }
            catch
            {
                msg = "Sorry! Unable to save notification.";
            }
            ViewBag.notify = msg;
            List<NotificationMaster> ntf = db.NotificationMasters.OrderByDescending(x => x.Nid).ToList();
            return View(ntf);
        }
        public JsonResult DeleteNotify(int NID)
        {
            string msg = "";
            try
            {
                NotificationMaster nm = db.NotificationMasters.Find(NID);
                db.NotificationMasters.Remove(nm);
                db.SaveChanges();
                msg = "SUCCESS";
            }
            catch
            {
                msg = "FAIL";
            }
            return Json(msg,JsonRequestBehavior.AllowGet);
        }
        public ActionResult ChangePass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePass(string Pass, string ConfPass, string NewPass)
        {

            string msg = "";
            if (ConfPass == NewPass)
            {
                string uid = Session["managerid"].ToString();
                Cyptography cg = new Cyptography();
                Pass = cg.EncryptMyPassword(Pass);
                NewPass = cg.EncryptMyPassword(NewPass);
                LoginMaster l = db.LoginMasters.SingleOrDefault(x => x.Email_Id == uid && x.Pass == Pass);
                if (l != null)
                {
                    l.Pass = NewPass;
                    db.Entry(l);
                    db.SaveChanges();
                    msg = "Password Chnaged Successfully";
                }
            }
            else
            {
                msg = "Password & Confirm Password must be same.";
            }
            ViewBag.Changemsg = msg;
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            Session.Remove("managerid");
            return View();
        }

    }
}