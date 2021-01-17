using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductivityTools.SportsTracker.App.Domain;
using ProductivityTools.SportsTracker.App.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.SportsTracker.App
{
    public class Application
    {
        string UserName, Password;
        private string Address = "https://api.sports-tracker.com/apiserver/v1/";

        HttpClient client;

        HttpClient AnonymousClient
        {
            get
            {
                if (client == null)
                {
                    client = new HttpClient(new LoggingHandler(new HttpClientHandler()));

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                }
                return client;
            }
        }

        HttpClient Client
        {
            get
            {
                if (AnonymousClient.DefaultRequestHeaders.Contains("STTAuthorization") == false)
                {
                    string sessionKey = Login(this.UserName, this.Password);
                    client.DefaultRequestHeaders.Add("STTAuthorization", sessionKey);
                }

                return AnonymousClient;
            }
        }

        public Application(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }

        private Uri GetUri(string end)
        {
            Uri url = new Uri($"{Address}{end.Trim('/')}");
            return url;
        }

        public string Login(string login, string password)
        {

            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("l", login),
                new KeyValuePair<string, string>("p", password)
            });

            var anonymous = new { l = login, p = password };
            var dataAsString = JsonConvert.SerializeObject(anonymous);
            var content = new StringContent(dataAsString, Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage response = AnonymousClient.PostAsync(GetUri("login"), formContent).Result;
            var resultAsString = response.Content.ReadAsStringAsync().Result;
            JObject jobject = (JObject)JsonConvert.DeserializeObject(resultAsString);
            string sessionKey = jobject["sessionkey"].ToString();
            return sessionKey;
        }

        public List<Training> GetTrainingList()
        {
            var trainings = new List<Training>();
            string resultAsString = Client.GetAsync(GetUri("workouts?limited=true&limit=1000000")).Result.Content.ReadAsStringAsync().Result;
            var jobject = JsonConvert.DeserializeObject<ProductivityTools.SportsTracker.App.Dto.TrainingList.Rootobject>(resultAsString);
            foreach (var sttraining in jobject.payload)
            {
                var training = new Training(sttraining);
                trainings.Add(training);
            }
            return trainings;
        }

        public void AddTraining(Training training)
        {
            AddTraining(training, null, null);
        }

        public void AddTraining(Training training, byte[] image)
        {
            AddTraining(training, null, image);
        }

        public void AddTraining(Training training, byte[] gpxFile, byte[] image)
        {
            var addTraining = new ProductivityTools.SportsTracker.App.SportsTrackerDto.ImportTraining.Training();
            addTraining.activityId = (int)training.TrainingType;
            addTraining.description = training.Description;
            addTraining.energyConsumption = training.EnergyConsumption;
            addTraining.sharingFlags = training.SharingFlags;
            addTraining.startTime = training.StartTime;
            addTraining.totalDistance = training.TotalDistance;
            addTraining.duration = training.TotalTime;

            if (gpxFile != null)
            {
                string workoutKey = ImportGpxFile(gpxFile);
                addTraining.workoutKey = workoutKey;
            }

            var dataAsString = JsonConvert.SerializeObject(addTraining);
            var content = new StringContent(dataAsString, Encoding.UTF8, "application/json");
            var result = this.Client.PostAsync(GetUri("workout"), content).Result.Content.ReadAsStringAsync().Result; 

            if (image != null)
            {
                var jobject = JsonConvert.DeserializeObject<ProductivityTools.SportsTracker.App.SportsTrackerDto.ImportGpx.Rootobject>(result);
                var trainingId = jobject.payload.workoutKey;

                ImportFile(GetUri($"workouts/{trainingId}/image/web"),"image", image);
            }
        }

        public string ImportGpxFile(byte[] content)
        {
            var byteArray = new ByteArrayContent(content);
            //byteArray.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
            byteArray.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(byteArray, "file", "pawel.gpx");
            this.Client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            string resultAsString = this.Client.PostAsync(GetUri("workout/importGpx"), form).Result.Content.ReadAsStringAsync().Result;
            var jobject = JsonConvert.DeserializeObject<ProductivityTools.SportsTracker.App.SportsTrackerDto.ImportGpx.Rootobject>(resultAsString);
            return jobject.payload.workoutKey;
            this.Client.DeleteAsync(GetUri($"workouts/{jobject.payload.workoutKey}/delete"));
        }

        private string ImportFile(Uri url, string fileName, byte[] content)
        {
            var byteArray = new ByteArrayContent(content);
            byteArray.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(byteArray, "file", fileName);
            this.Client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            string resultAsString = this.Client.PostAsync(url, form).Result.Content.ReadAsStringAsync().Result;
            return resultAsString;
        }

        public void AddTraining(TrainingType trainingType, string description, int duration, DateTime startTime)
        {
            var newTraining = new ProductivityTools.SportsTracker.App.SportsTrackerDto.NewTraining.Rootobject();
            newTraining.activityId = (int)trainingType;
            newTraining.description = description;
            newTraining.duration = duration;
            newTraining.energy = 0;
            newTraining.sharingFlags = (int)SharintType.Public;
            newTraining.timeZoneOffset = 0;
            newTraining.totalDistance = 0;
            newTraining.startTime = ConvertToUnixTimestamp(startTime) * 1000;
            var dataAsString = JsonConvert.SerializeObject(newTraining);
            var content = new StringContent(dataAsString, Encoding.UTF8, "application/json");

            var result = this.Client.PostAsync(GetUri("workout").ToString(), content).Result.Content.ReadAsStringAsync().Result;
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        //public void ImportGpxFile(string path)
        //{
        //   var x= UploadFile(GetUri("workout/importGpx").ToString(), path).Result;
        //}

        //public async Task<string> UploadFile(string actionUrl, string filePath)
        //{

        //    FileStream fileStream = File.OpenRead(filePath);
        //    var streamContent = new StreamContent(fileStream);
        //    streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
        //    streamContent.Headers.ContentDisposition.Name = "\"file\"";
        //    streamContent.Headers.ContentDisposition.FileName = "\"" + Path.GetFileName(filePath) + "\"";
        //    streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        //    string boundary = "----WebKitFormBoundaryAFqTXNjdlhl0zwKi";
        //    var content = new MultipartFormDataContent(boundary);
        //    content.Headers.Remove("Content-Type");
        //    content.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary);
        //    content.Add(streamContent);
        //    HttpResponseMessage response = null;
        //    try
        //    {
        //        this.Client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
        //        //client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
        //        //client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
        //        //client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("br"));

        //        response = await this.Client.PostAsync(actionUrl, content);
        //    }
        //    catch (WebException ex)
        //    {
        //        // handle web exception
        //        return null;
        //    }
        //    catch (TaskCanceledException ex)
        //    {

        //    }

        //    try
        //    {
        //        response.EnsureSuccessStatusCode();
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    };

        //    string res = await response.Content.ReadAsStringAsync();
        //    return await Task.Run(() => res);
        //}
    }
}


