using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using TechProjectHub.App_Code;
using TechProjectHub.Models;

namespace TechProjectHub.Controllers
{
    public class GeneralController : Controller
    {
        Tech_Project_HubDBEntities1 db = new Tech_Project_HubDBEntities1();

        static string[] PicAndName = new string[2];
        [NonAction]
        void CreateNewCaptcha()
        {
            RandomCodeGenrator rg = new RandomCodeGenrator();
            PicAndName = rg.GetCaptchaImgAndCode();
            ViewBag.CaptchaPicName = PicAndName[0];
        }
        public JsonResult GetNewCaptchaByAJAX()
        {
            CreateNewCaptcha();
            string s = PicAndName[0];
            return Json(s, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            List<NotificationMaster> lst = db.NotificationMasters.OrderByDescending(x => x.Nid).Take(4).ToList();
            return View(lst);
        }
        public ActionResult Aboutus()
        {
            return View();
        }
        public ActionResult TdProject()
        {
            List<ProjectMaster> pm = db.ProjectMasters.Take(6).ToList();
            return View(pm);
        }
        [NonAction]
        void BindQualifiactionAndDesignation()
        {
            //First DDL
            string[] qualification = new string[] { "Matriculation(10th)", "Senior Secondary(10+2)", "Diploma(CS)", "Diploma(IT)", "B.Sc", "M.Sc", "BCA", "MCA" };
            List<SelectListItem> lstqlt = new List<SelectListItem>();
            foreach(string qn in qualification)
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = qn;
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
                lstdesig.Add(sli);
            }
            ViewBag.Designation = lstdesig;
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            BindQualifiactionAndDesignation();
            CreateNewCaptcha();
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(DeveloperMaster dm,string Pass, string CnfPass, string TxtCaptcha)
        {
            string msg = string.Empty;

            if (TxtCaptcha == PicAndName[1]) //Captcha Verification
            {
                if(Pass==CnfPass) //Password and Confirm password verification
                {
                    HttpPostedFileBase myfile = Request.Files["ProfilePic"]; //Reading and saving profile pic
                    bool IsFileError=false;
                    string UserPicName = string.Empty;
                    if(myfile!=null)
                    {
                        if(myfile.ContentLength>0)
                        {
                            UserPicName = Path.GetRandomFileName() + myfile.FileName;
                            string ftype = UserPicName.Substring(UserPicName.LastIndexOf('.')).ToUpper();
                            if(ftype==".JPG" ||ftype==".JPEG" || ftype==".PNG")
                            {
                                string folderPath = Server.MapPath("/Content/UserPics/");
                                if (!Directory.Exists(folderPath))
                                    Directory.CreateDirectory(folderPath);
                                myfile.SaveAs(folderPath + "/" + UserPicName);
                                    dm.ProfilePic=UserPicName;
                            }
                            else
                            {
                                msg = "Invalid Picture.PleaseChoose correct image file";
                                IsFileError=true;
                            }
                        }
                    }
                    if(IsFileError==false)
                    {
                        dm.Registered_On = DateTime.Now;
                        db.DeveloperMasters.Add(dm);
                        LoginMaster lg = new LoginMaster();
                        lg.Email_Id = dm.Email_Id;
                        Cyptography cg = new Cyptography();
                        lg.Pass = cg.EncryptMyPassword(Pass);
                        lg.Utype = "DEVELOPER";
                        db.LoginMasters.Add(lg);
                        db.SaveChanges();
                        msg = "Congratulations! you are registered successfully.";
                        //sending email
                        EmailSender em = new EmailSender();
                        string msgs = "Hi, " + dm.Name + " \n Congratulations you are registered successfully. Welcome to our portal. Thanks for joining us, we will get in touch with you.";
                        em.SendMyEmail(dm.Email_Id, "TechProjectHub", msgs);
                    }
                }
                else
                {
                    msg = "Password and Confirm password must be same.";
                }
            }
            else
            {
                msg = "Invalid Captcha Code.Please try again.";
            }
            ViewBag.Message = msg;
            BindQualifiactionAndDesignation();
            CreateNewCaptcha();
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginMaster lg)
        {
            Cyptography cg = new Cyptography();
            lg.Pass = cg.EncryptMyPassword(lg.Pass);
            LoginMaster lgdb=db.LoginMasters.SingleOrDefault(x=>x.Email_Id==lg.Email_Id && x.Pass==lg.Pass && x.Utype==lg.Utype);
            if(lgdb!=null)
            {
                if(lgdb.Utype=="DEVELOPER")
                {
                    Session["developerid"] = lgdb.Email_Id;
                    return RedirectToAction("Welcome", "Developer");
                }
                else if(lgdb.Utype=="MANAGER")
                {
                    Session["managerid"] = lgdb.Email_Id;
                    return RedirectToAction("Dashboard", "Manager");
                }
            }
            ViewBag.Message = "Invalid userid or password";
            return View();
        }
        public JsonResult SaveEnquiryByAJAX(EnquiryMaster em)
        {
            string msg = string.Empty;
            try
            {
                em.Enq_DT = DateTime.Now;
                db.EnquiryMasters.Add(em);
                db.SaveChanges();
                msg = "SUCCESS";
                //Sending Email
                EmailSender sm = new EmailSender();
                string msgs = "Hi, " + em.Name + " \n Thanks for your query. We will contact you soon.\nFrom:\nTeam Tech Project Hub";
                sm.SendMyEmail(em.EmailId, "Thanks from Tech Project Hub", msgs);
            }
            catch
            {
                msg = "FAIL";
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MyIntro()
        {
            return View();
        }
    }
}