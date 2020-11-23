using System;
using System.IO;
using AspnetMVC_FirebaseTutorial.Models;
//using Firebase.Auth;
//using Firebase.Storage;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspnetMVC_FirebaseTutorial.Controllers
{
    public class FileController : Controller
    {
        private static string ApiKey = "AIzaSyDRr1WqIf33SZ0-O6rq9aJ5Mhd2Wcesz7o";
        private static string Bucket = "messageapp-be75d.appspot.com";
        private static string AuthEmail = "storagetest@gmail.com";
        private static string AuthPassword = "123456";

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "K1gx42hN8eWfrk6XGGsf6Wy9ufpqJrKogi6nPeua",
            BasePath = "https://messageapp-be75d.firebaseio.com/"

        };
        IFirebaseClient client;

        // GET: File
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(Department department, HttpPostedFileBase file)
        {
            FileStream stream;
            if (file.ContentLength > 0)
            {
                string _strFileName = $"f_{Guid.NewGuid().ToString().Substring(10)}-{file.FileName}";
                string path = Path.Combine(Server.MapPath("~/upload/"), _strFileName);
                file.SaveAs(path);
                stream = new FileStream(Path.Combine(path), FileMode.Open);
                await Task.Run(() => Upload(stream, _strFileName));

                AddStudentToFirebase(department, _strFileName);
                ModelState.AddModelError(string.Empty, "Added Successfully!");
            }
            return View();
        }
        public async void Upload(FileStream stream, string fileName)
        {
            var auth = new Firebase.Auth.FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

            // You can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            var task = new Firebase.Storage.FirebaseStorage(
                Bucket,
                new Firebase.Storage.FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true // when you cansel the upload, exception is thrown, By default no exception is thrown

                })
                .Child("images")
                .Child(fileName)
                .PutAsync(stream, cancellation.Token);

            try
            {
                // error during upload will be thrown when await the task
                string link = await task;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception was thrown: {0}", ex);
            }
        }
        private void AddStudentToFirebase(Department department, string _strFile)
        {
            client = new FireSharp.FirebaseClient(config);
            //  var data = department;
            var data = new Department { DepartmentName = department.DepartmentName, FromFile = _strFile };
            PushResponse response = client.Push("Departments/", data);
            data.id = response.Result.name;
            SetResponse setResponse = client.Set("Departments/" + data.id, data);
        }
    }
}