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
    [Authorize_Developer]
    public class DeveloperController : Controller
    {
        // GET: Developer
        Tech_Project_HubDBEntities1 db = new Tech_Project_HubDBEntities1();
        static string uid;
        [NonAction]
        
        void SetUserPicAndName()
        {
            if (Session["developerid"]!=null)
            {
                uid = Session["developerid"].ToString();
                DeveloperMaster dm = db.DeveloperMasters.Find(uid); 
                string picname = "";
                if(dm.ProfilePic==string.Empty)
                {
                    if(dm.Gender.ToUpper().Trim()=="MALE")
                    {
                        picname = "/Content/Images/Default_male.png";
                    }
                    else
                        picname = "/Content/Images/Default_female.png";
                }
                else
                    picname= "/Content/UserPics/" + dm.ProfilePic;
                ViewBag.Picture=picname;
                ViewBag.Name = dm.Name;
            }
        }
        [NonAction]
        void BindQualifiactionAndDesignation(string myqualification,string mydesignation)
        {
            //First DDL
            string[] qualification = new string[] { "Matriculation(10th)", "Senior Secondary(10+2)", "Diploma(CS)", "Diploma(IT)", "B.Sc", "M.Sc", "BCA", "MCA" };
            List<SelectListItem> lstqlt = new List<SelectListItem>();
            foreach (string qn in qualification)
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = qn;
                if (qn == myqualification)
                    sli.Selected = true;
                lstqlt.Add(sli);
            }
            ViewBag.Qualification = lstqlt;
            //Second DDL
            string[] designation = new string[] { "Software Engineer", "Web Developer", "Android Developer", "Project Manager", "General Manager", "Senior Software Engineer", "Trainee", "System Anlyst" };
            List<SelectListItem> lstdesig = new List<SelectListItem>();
            foreach (string ds in designation)
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = ds;
                if (ds == mydesignation)
                    sli.Selected = true;
                lstdesig.Add(sli);
            }
            ViewBag.Designation = lstdesig;
        }
        public ActionResult Welcome()
        {
            SetUserPicAndName();
            return View();
        }
        public ActionResult Feedback()
        {
            SetUserPicAndName();
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(FeedbackMaster fm)
        {
            string msg = "";
            try
            {
                fm.DeveloperId = Session["developerid"].ToString();
                fm.MsgDT = DateTime.Now;
                db.FeedbackMasters.Add(fm);
                db.SaveChanges();
                msg = "Feedback saved successfully";
            }
            catch
            {
                msg = "Sorry!Feedback not saved";
            }
            ViewBag.Message=msg;
            SetUserPicAndName();
            return View();
        }
        [HttpGet]
        public ActionResult SearchP()
        {
            List<ProjectMaster> pm = db.ProjectMasters.OrderByDescending(x => x.Project_Id).ToList();
            SetUserPicAndName();
            return View(pm);
        }
        [HttpPost]
        public ActionResult SearchP(string SearchValue)
        {
            SetUserPicAndName();
            List<ProjectMaster> lst = db.ProjectMasters.Where(x =>x.Project_Title.Contains(SearchValue)).ToList();
            return View(lst);
        }
        public FileResult DownloadProject(string fname)
        {
            string Pathfile = "/Content/ManagerPostProject/" + fname;
            return File(Pathfile, "application/force-download", Path.GetFileName(Pathfile));
        }
        public FileResult DownloadTask(string fname)
        {
            string Pathfile = "/Content/UploadTask/" + fname;
            return File(Pathfile, "application/force-download", Path.GetFileName(Pathfile));
        }
        public ActionResult RqForProject()
        {
            SetUserPicAndName();
            return View();
        }
        [HttpPost]
        public ActionResult RqForProject(RequestMaster rm)
        {
            string msg = "";
            string uid = Session["developerid"].ToString();
            //ProjectMaster pm = new ProjectMaster();
            try
            {
                rm.Request_DT = DateTime.Now;
                rm.Requested_By = uid;
                //rm.Request_For = pm.Project_Id;
                db.RequestMasters.Add(rm);
                db.SaveChanges();
                msg = "Your request submitted successfully";
            }
            catch
            {
                msg = "Sorry! Unable to submit request";
            }
            TempData["RqProject"] =msg;
            SetUserPicAndName();
            return RedirectToAction("SearchP", "Developer");
        }
        public ActionResult MyProjects()
        {
            string uid = Session["developerid"].ToString();
            List<RequestMaster> rmlst = db.RequestMasters.Where(x => x.Requested_By==uid).ToList();
            SetUserPicAndName();
            return View(rmlst);
        }

        
        public ActionResult TodayTask()
        {
            SetUserPicAndName();
            string uid = Session["developerid"].ToString();
            List<TaskMaster> tm = db.TaskMasters.Where(x => x.ForDeveloper == uid).ToList();
            return View(tm);
        }
        [HttpGet]
        public ActionResult UploadCode()
        {
            SetUserPicAndName();
            return View();
        }
        [HttpPost]
        public ActionResult UploadCode(UploadCodeMaster um)
        {
            string msg = string.Empty;
            try
            {
                string fPath = Server.MapPath("/Content/UploadCode");
                HttpPostedFileBase myfile = Request.Files["CodeFile_Name"];
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
                            um.Uploaded_By = uid;
                            um.Uploaded_DT = DateTime.Now;
                            um.CodeFile_Name = fName;
                            db.UploadCodeMasters.Add(um);
                            db.SaveChanges();
                            msg = "File Uploaded Successfully";
                        }
                    }
                    else
                    {
                        msg = "Invalid file type. Please choose a valid file.";
                    }
                }
                else
                {
                    msg = "Please Upload a code.";
                }
            }
            catch
            {
                msg = "Sorry! Due to some technical issue. We are unable to upload your code";
            }
            ViewBag.message = msg;
            SetUserPicAndName();
            return View();
        }
        public ActionResult WorkReport()
        {
            SetUserPicAndName();
            return View();
        }
        [HttpPost]
        public ActionResult WorkReport(WorkReportMaster wm)
        {
            string msg = "";
            if(wm.IsHelpNeeded!=true)
            {
                wm.IsHelpNeeded = false;
            }
            try
            {
                string div = Session["developerid"].ToString();
                wm.Submitted_By = div;
                wm.Submitted_DT = DateTime.Now;
                db.WorkReportMasters.Add(wm);
                db.SaveChanges();
                msg = "Work report submitted successfully";
            }
            catch
            {
                msg="Sorry! Unable to submit the report";
            }
            ViewBag.Message=msg;
            SetUserPicAndName();
            return View();
        }
        [HttpGet]
        public ActionResult MyProfile()
        {
            string uid = "";
            uid = Session["developerid"].ToString();
            //Getting Details of original databse
            DeveloperMaster dm = db.DeveloperMasters.Find(uid);
            BindQualifiactionAndDesignation(dm.Qualification, dm.Designation);
            SetUserPicAndName();
            return View(dm);
        }
        [HttpPost]
        public ActionResult MyProfile(DeveloperMaster dm)
        {
            string uid = "";
            string msg = "";
            uid = Session["developerid"].ToString();
            DeveloperMaster dmdb = db.DeveloperMasters.Find(uid);
            HttpPostedFileBase myfile = Request.Files["ProfilePic"]; //Reading and saving profile pic
            bool IsFileError = false;
            string UserPicName = string.Empty;
            if (myfile != null)
            {
                if (myfile.ContentLength > 0)
                {
                    UserPicName = Path.GetRandomFileName() + myfile.FileName;
                    string ftype = UserPicName.Substring(UserPicName.LastIndexOf('.')).ToUpper();
                    if (ftype == ".JPG" || ftype == ".JPEG" || ftype == ".PNG")
                    {
                        string folderPath = Server.MapPath("/Content/UserPics");
                        if (!Directory.Exists(folderPath))
                            Directory.CreateDirectory(folderPath);
                        myfile.SaveAs(folderPath + "/" + UserPicName);
                        dmdb.ProfilePic = UserPicName;
                    }
                    else
                    {
                        msg = "Invalid Picture.Please Choose correct image file";
                        IsFileError = true;
                    }
                }
            }
            if (IsFileError == false)
            {
                try
                {
                    dmdb.Name = dm.Name;
                    dmdb.Address = dm.Address;
                    dmdb.Mobile_No = dm.Mobile_No;
                    dmdb.Gender = dm.Gender;
                    dmdb.Qualification = dm.Qualification;
                    dmdb.Designation = dm.Designation;
                    db.Entry(dmdb);
                    db.SaveChanges();
                    msg = "Profile Updated Successfully.";
                }
                catch
                {
                    msg = "Sorry! Profile not updated";
                }
            }
            ViewBag.message=msg;
            DeveloperMaster d = db.DeveloperMasters.Find(uid);
            BindQualifiactionAndDesignation(d.Qualification, d.Designation);
            SetUserPicAndName();
            return View(d);
        }
        public ActionResult ChangePass()
        {
            SetUserPicAndName();
            return View();
        }
        [HttpPost]
        public ActionResult ChangePass(string Pass, string ConfPass, string NewPass)
        {

            string msg = "";
            if(ConfPass==NewPass)
            {
                string uid = Session["developerid"].ToString();
                Cyptography cg = new Cyptography();
                Pass = cg.EncryptMyPassword(Pass);
                NewPass = cg.EncryptMyPassword(NewPass);
                LoginMaster l=db.LoginMasters.SingleOrDefault(x=>x.Email_Id==uid && x.Pass==Pass);
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
            ViewBag.Message = msg;
            SetUserPicAndName();
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            Session.Remove("developerid");
            return View();
        }

    }
}