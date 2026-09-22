using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SMARTPORATL.Controllers
{
    [AllowAnonymous] // <-- POORA CONTROLLER PUBLIC KAR DIYA
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index() => View();

        [AllowAnonymous]
        public IActionResult Login() => View();

        [AllowAnonymous]
        public IActionResult Register() => View();

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(string FullName, string Village, string Mobile, string Password)
        {
            TempData["UserName"] = FullName;
            TempData["Village"] = Village;
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string Mobile, string Password)
        {
            TempData["UserName"] = Mobile;
            return RedirectToAction("Dashboard");
        }

        [AllowAnonymous]
        public IActionResult Dashboard() => View();

        [AllowAnonymous]
        public IActionResult ComplaintBox() => View();
        [AllowAnonymous]
        public IActionResult Education() => View();
        [AllowAnonymous]
        public IActionResult Employment() => View();
        [AllowAnonymous]
        public IActionResult ComplaintSolution() => View();

        [AllowAnonymous]
        public IActionResult Agriculture() => View();
        [AllowAnonymous]
        public IActionResult AgricultureDetails(string id) { ViewBag.Id = id; return View(); }
        [AllowAnonymous]
        public IActionResult AgricultureForm(string id) { ViewBag.Id = id; return View(); }

        [AllowAnonymous]
        public IActionResult Health() => View();

        [AllowAnonymous]
        public IActionResult Scheme() => View();
        [AllowAnonymous]
        public IActionResult Schemes() => View();

        [AllowAnonymous]
        public IActionResult SchemeDetails(string id)
        {
            ViewBag.SchemeId = id;
            ViewBag.Id = id;
            var d = new Dictionary<string, string>();
            if (id == "PMKisan") d = new Dictionary<string, string> { { "Title", "PM Kisan Yojana" }, { "Benefit", "Rs.6000/year" }, { "Obj", "Chhote kisano ko arthik sahayata" }, { "Elig", "2 hectare tak jamin" }, { "Docs", "Aadhar, 7/12, Bank Passbook" }, { "Process", "pmkisan.gov.in par apply" }, { "Link", "https://pmkisan.gov.in" } };
            else if (id == "LadkiBahin") d = new Dictionary<string, string> { { "Title", "Mazi Ladki Bahin Yojana" }, { "Benefit", "Rs.1500/month" }, { "Obj", "Mahilao ko sashakt banana" }, { "Elig", "Age 21-65, Income < 2.5 Lakh" }, { "Docs", "Aadhar, Domicile, Bank Passbook" }, { "Process", "Nari Shakti Doot App / ladakibahin.maharashtra.gov.in" }, { "Link", "https://ladakibahin.maharashtra.gov.in" } };
            else if (id == "MahilaRojgar") d = new Dictionary<string, string> { { "Title", "Mahila Rojgar Yojana" }, { "Benefit", "Rs.20000 Credit, Loan up to 10 Lakh" }, { "Obj", "Mahila Bachat Gat ko rojgar" }, { "Elig", "SHG Member" }, { "Docs", "Aadhar, Bank Passbook, SHG Certificate" }, { "Process", "Gram Panchayat / MAVIM" }, { "Link", "https://mavimindia.org" } };
            else if (id == "LIC") d = new Dictionary<string, string> { { "Title", "LIC Bima Sakhi Yojana" }, { "Benefit", "Rs.7000/month Stipend" }, { "Obj", "Mahila LIC agent banna" }, { "Elig", "10th Pass, 18-70 years" }, { "Docs", "Aadhar, Education Cert, Bank Account" }, { "Process", "Visit LIC Branch" }, { "Link", "https://licindia.in" } };
            else if (id == "MutualFund") d = new Dictionary<string, string> { { "Title", "Mutual Fund - Sahi Hai" }, { "Benefit", "Rs.500 SIP Start, Wealth Creation" }, { "Obj", "Chhote nivesh se bada fund" }, { "Elig", "PAN Card holder" }, { "Docs", "PAN, Aadhar, Bank Account" }, { "Process", "Groww / ET Money App" }, { "Link", "https://www.amfiindia.com" } };
            else if (id == "Mediclaim" || id == "Ayushman") d = new Dictionary<string, string> { { "Title", "Mediclaim Health Insurance / Ayushman Bharat" }, { "Benefit", "Rs.5 Lakh free treatment" }, { "Obj", "Garib parivar ko free ilaj" }, { "Elig", "BPL / Yellow Ration Card" }, { "Docs", "Aadhar, Ration Card" }, { "Process", "PHC / pmjay.gov.in se Golden Card" }, { "Link", "https://pmjay.gov.in" } };
            else d = new Dictionary<string, string> { { "Title", id }, { "Benefit", "Direct Benefit" }, { "Obj", "Government welfare scheme" }, { "Elig", "All Castes eligible" }, { "Docs", "Aadhar, Bank Passbook" }, { "Process", "Apply at Gram Panchayat" }, { "Link", "https://www.maharashtra.gov.in" } };
            ViewBag.Data = d;
            return View();
        }

        [AllowAnonymous]
        public IActionResult GovernmentSchemes() => View("Scheme");
        [AllowAnonymous]
        public IActionResult GovernmentSchemeDetails(string id) { ViewBag.SchemeId = id; ViewBag.Id = id; return View("SchemeDetails"); }

        [AllowAnonymous]
        public IActionResult SchemeForm(string id) { ViewBag.Id = id; return View(); }
        [AllowAnonymous]
        public IActionResult Receipt(string id, string name) { ViewBag.Id = id; ViewBag.Name = name; return View(); }
        [AllowAnonymous]
        public IActionResult GovernmentForm(string scheme) { ViewBag.Scheme = scheme; return View("SchemeForm"); }
        [AllowAnonymous]
        public IActionResult GovernmentReceipt(string scheme, string name, string mobile)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.AppId = "MH-SCHEME-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View("Receipt");
        }

        [AllowAnonymous]
        public IActionResult AgricultureServices() => View();
        [AllowAnonymous]
        public IActionResult AgricultureDevelopment() => View();
        [AllowAnonymous]
        public IActionResult HealthServices() => View();
        [AllowAnonymous]
        public IActionResult HealthDetails(string id) { ViewBag.ServiceId = id; return View(); }
        [AllowAnonymous]
        public IActionResult HealthForm(string scheme) { ViewBag.SchemeName = scheme; return View(); }
        [AllowAnonymous]
        public IActionResult HealthReceipt(string scheme, string name, string mobile)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.AppId = "MH-HEALTH-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        [AllowAnonymous]
        public IActionResult EducationServices() { return View(); }
        [AllowAnonymous]
        public IActionResult EducationDetails(string id) { ViewBag.ServiceId = id; return View(); }
        [AllowAnonymous]
        public IActionResult EducationForm(string scheme) { ViewBag.SchemeName = scheme; return View(); }
        [AllowAnonymous]
        public IActionResult EducationReceipt(string scheme, string name, string mobile)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.AppId = "MH-EDU-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        [AllowAnonymous]
        public IActionResult EmploymentServices() => View();
        [AllowAnonymous]
        public IActionResult EmploymentDetails(string id) { ViewBag.ServiceId = id; return View(); }
        [AllowAnonymous]
        public IActionResult EmploymentForm(string scheme) { ViewBag.SchemeName = scheme; return View(); }
        [AllowAnonymous]
        public IActionResult EmploymentReceipt(string scheme, string name, string mobile, string education, string skill)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.Education = education; ViewBag.Skill = skill;
            ViewBag.AppId = "MH-EMP-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        [AllowAnonymous]
        public IActionResult VillageDevelopment() => View();
        [AllowAnonymous]
        public IActionResult VillageDevelopmentDetails(string id) { ViewBag.ServiceId = id; return View(); }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SubmitVillageComplaint(string type, string description, IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "VillageDevelopment");
                if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);
                var filePath = Path.Combine(uploadPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create)) { await photo.CopyToAsync(stream); }
            }
            TempData["Msg"] = type + " complaint saved successfully with photo!";
            return RedirectToAction("VillageDevelopment");
        }

        [AllowAnonymous]
        public IActionResult VillageDevelopmentReceipt(string scheme, string name, string mobile)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.AppId = "MH-VD-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        [AllowAnonymous]
        public IActionResult Transport() => View();
        [AllowAnonymous]
        public IActionResult TransportDetails(string id) { ViewBag.ServiceId = id; return View(); }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SubmitTransportComplaint(string type, string description, IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "Transport");
                if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);
                var filePath = Path.Combine(uploadPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create)) { await photo.CopyToAsync(stream); }
            }
            TempData["Msg"] = type + " transport complaint saved successfully!";
            return RedirectToAction("Transport");
        }

        [AllowAnonymous]
        public IActionResult TransportReceipt(string scheme, string name, string mobile)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.AppId = "MH-TR-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        [AllowAnonymous]
        public IActionResult Bank() => View();
        [AllowAnonymous]
        public IActionResult BankDetails(string id) { ViewBag.ServiceId = id; return View(); }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SubmitBankComplaint(string type, string description, IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "Bank");
                if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);
                var filePath = Path.Combine(uploadPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create)) { await photo.CopyToAsync(stream); }
            }
            TempData["Msg"] = type + " bank enquiry saved successfully!";
            return RedirectToAction("BankDetails", new { id = type });
        }

        [AllowAnonymous]
        public IActionResult BankReceipt(string scheme, string name, string mobile)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.AppId = "MH-BANK-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        [AllowAnonymous]
        public IActionResult PoliceSafety() => View();
        [AllowAnonymous]
        public IActionResult PoliceSafetyDetails(string id) { ViewBag.ServiceId = id; return View(); }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SubmitPoliceComplaint(string type, string description, IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "PoliceSafety");
                if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);
                var filePath = Path.Combine(uploadPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create)) { await photo.CopyToAsync(stream); }
            }
            TempData["Msg"] = type + " police complaint saved successfully!";
            return RedirectToAction("PoliceSafetyDetails", new { id = type });
        }

        [AllowAnonymous]
        public IActionResult PoliceSafetyReceipt(string scheme, string name, string mobile)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.AppId = "MH-POLICE-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        [AllowAnonymous]
        public IActionResult OnlineServices() => View();
        [AllowAnonymous]
        public IActionResult OnlineServiceDetails(string id) { ViewBag.ServiceId = id; return View(); }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SubmitOnlineServiceRequest(string type, string description, IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "OnlineServices");
                if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);
                var filePath = Path.Combine(uploadPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create)) { await photo.CopyToAsync(stream); }
            }
            TempData["Msg"] = type + " online service request saved successfully!";
            return RedirectToAction("OnlineServiceDetails", new { id = type });
        }

        [AllowAnonymous]
        public IActionResult OnlineServiceReceipt(string scheme, string name, string mobile)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.AppId = "MH-ONLINE-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        [AllowAnonymous]
        public IActionResult Chatbot() => View();
    }
}