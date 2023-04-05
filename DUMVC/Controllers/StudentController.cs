using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;
using System.Data;
using DUMVC.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace DUMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string baseUrl;
        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
            baseUrl = _configuration["ApiBaseUrl"];
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            List<Student>? std = new List<Student>();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(this.baseUrl + "api/Student/getStudents"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    std = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(apiresponse);
                }
            }
            if (std != null)
            {
                return View(std);
            }
            else
            {
                return View(new List<Student>());
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddStudent()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(this.baseUrl + "api/course/getcourses"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    var cour = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Course>>(apiresponse);
                    List<SelectListItem> list = new List<SelectListItem>();
                    foreach (var item in cour)
                    {

                        list.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
                    }
                    ViewBag.list = list;
                    return View();
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            Student? std = new Student();
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(student),
                    Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(this.baseUrl + "api/student/addstudent/", content))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    std = Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(apiresponse);
                }
            }
            if (std != null && std.FirstName != null)
            {
                TempData["message"] = $"Student {std.FirstName} created successfully";
                return RedirectToAction("getStudents");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var getDelStu = new Student();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(this.baseUrl + "api/Student/getStudentById/" + id))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    getDelStu = Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(apiresponse);
                }
            }
            if (getDelStu != null)
            {
                return View(getDelStu);
            }
            return View(new Student());
        }
        [HttpPost]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            //int id=user.UserId;
            using (var client = new HttpClient())
            {
                using (var response = await client.DeleteAsync(this.baseUrl + "api/student/deletestudent/" + id))
                {
                    var apiresponse = await response.Content.ReadAsStringAsync();
                    //DeletedUser = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(apiresponse);
                }
            }
            return RedirectToAction("getStudents");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Student getEditStu = new Student();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(this.baseUrl + "api/course/getcourses"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    var cour  = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Course>>(apiresponse);
                    List<SelectListItem> list = new List<SelectListItem>();
                    foreach (var item in cour)
                    {

                        list.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
                    }
                    ViewBag.list = list;
                }
                using (var response = await client.GetAsync(this.baseUrl + "api/student/getstudentbyid/" + id))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    getEditStu = Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(apiresponse);
                }
            }

            if (getEditStu != null)
            {
                getEditStu.DOB = getEditStu.DOB.Replace("/", "-");
                return View(getEditStu);
            }
            return View(new Student());
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (student.FirstName == null || student.LastName == null || student.DOB == null)
            {
                return View();
            }
            Student? UpdateStd;
           
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(student),
                Encoding.UTF8, "application/json");
                using (var response = await client.PutAsync(this.baseUrl + "api/student/EditStudent/", content))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    UpdateStd = Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(apiresponse);
                }
            }
            if (UpdateStd != null)
            {
                TempData["message"] = $"BookDetails {UpdateStd.FirstName} updated successfully";
                return RedirectToAction("getStudents");
            }
            else
            {
                return View();
            }
        }

    }
}
