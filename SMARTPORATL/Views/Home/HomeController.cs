using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SMARTPORATL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Login() => View();
        public IActionResult Dashboard() => View();
        public IActionResult ComplaintBox() => View();
        public IActionResult Education() => View();
        public IActionResult Employment() => View();
        public IActionResult ComplaintSolution() => View();

        // ===== Agriculture Old =====
        public IActionResult Agriculture() => View();
        public IActionResult AgricultureDetails(string id) { ViewBag.Id = id; return View(); }
        public IActionResult AgricultureForm(string id) { ViewBag.Id = id; return View(); }

        // ===== Health Old =====
        public IActionResult Health() => View();

        // ===== MAIN SCHEME =====
        public IActionResult Scheme() => View();
        public IActionResult Schemes() => View();

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

        public IActionResult GovernmentSchemes() => View("Scheme");
        public IActionResult GovernmentSchemeDetails(string id) { ViewBag.SchemeId = id; ViewBag.Id = id; return View("SchemeDetails"); }

        public IActionResult SchemeForm(string id) { ViewBag.Id = id; return View(); }
        public IActionResult Receipt(string id, string name) { ViewBag.Id = id; ViewBag.Name = name; return View(); }
        public IActionResult GovernmentForm(string scheme) { ViewBag.Scheme = scheme; return View("SchemeForm"); }
        public IActionResult GovernmentReceipt(string scheme, string name, string mobile)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.AppId = "MH-SCHEME-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View("Receipt");
        }

        public IActionResult AgricultureServices() => View();
        public IActionResult AgricultureDevelopment() => View();
        public IActionResult HealthServices() => View();
        public IActionResult HealthDetails(string id) { ViewBag.ServiceId = id; return View(); }
        public IActionResult HealthForm(string scheme) { ViewBag.SchemeName = scheme; return View(); }
        public IActionResult HealthReceipt(string scheme, string name, string mobile)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.AppId = "MH-HEALTH-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        public IActionResult EducationServices() { return View(); }
        public IActionResult EducationDetails(string id) { ViewBag.ServiceId = id; return View(); }
        public IActionResult EducationForm(string scheme) { ViewBag.SchemeName = scheme; return View(); }
        public IActionResult EducationReceipt(string scheme, string name, string mobile)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.AppId = "MH-EDU-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        public IActionResult EmploymentServices() => View();
        public IActionResult EmploymentDetails(string id) { ViewBag.ServiceId = id; return View(); }
        public IActionResult EmploymentForm(string scheme) { ViewBag.SchemeName = scheme; return View(); }
        public IActionResult EmploymentReceipt(string scheme, string name, string mobile, string education, string skill)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.Education = education; ViewBag.Skill = skill;
            ViewBag.AppId = "MH-EMP-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        public IActionResult VillageDevelopment() => View();
        public IActionResult VillageDevelopmentDetails(string id) { ViewBag.ServiceId = id; return View(); }

        [HttpPost]
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

        public IActionResult VillageDevelopmentReceipt(string scheme, string name, string mobile)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.AppId = "MH-VD-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        public IActionResult Transport() => View();
        public IActionResult TransportDetails(string id) { ViewBag.ServiceId = id; return View(); }

        [HttpPost]
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

        public IActionResult TransportReceipt(string scheme, string name, string mobile)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.AppId = "MH-TR-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        public IActionResult Bank() => View();
        public IActionResult BankDetails(string id) { ViewBag.ServiceId = id; return View(); }

        [HttpPost]
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

        public IActionResult BankReceipt(string scheme, string name, string mobile)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.AppId = "MH-BANK-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        public IActionResult PoliceSafety() => View();
        public IActionResult PoliceSafetyDetails(string id) { ViewBag.ServiceId = id; return View(); }

        [HttpPost]
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

        public IActionResult PoliceSafetyReceipt(string scheme, string name, string mobile)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.AppId = "MH-POLICE-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        public IActionResult OnlineServices() => View();
        public IActionResult OnlineServiceDetails(string id) { ViewBag.ServiceId = id; return View(); }

        [HttpPost]
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

        public IActionResult OnlineServiceReceipt(string scheme, string name, string mobile)
        {
            ViewBag.Scheme = scheme; ViewBag.Name = name; ViewBag.Mobile = mobile;
            ViewBag.AppId = "MH-ONLINE-" + new Random().Next(10000, 99999);
            ViewBag.Date = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        // ===== ✅ AI GRAM MITRA - CHATBOT - NEW - 12th CARD =====
        public IActionResult Chatbot() => View();
    }
}