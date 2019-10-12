using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lab_48_use_todo_api
{
    class Program
    {

        static string URL = "https://localhost:44324/api/taskitems/";
        static string URLPost = "https://localhost:44324/";
        public static List<TaskItem> todoItems = new List<TaskItem>();
        static void Main(string[] args)
        {
            //Console.WriteLine($"Is the local network live: {System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()}");
            // Console.WriteLine($"Is connect to the internet {IsNetworkLive()}");

            TaskItem TaskToUpdate = new TaskItem
            {
                Description = "Task Update"
            };

            //GetAPIDataAsync().Wait();

            Console.ReadLine();
            //CreateTodoItemAsync().Wait();
            //EditTodoItemAsync(2).Wait();
            EditTodoItemAsync(6, TaskToUpdate).Wait();
            //DeleteTodoItemsAsync(5).Wait();
            Console.ReadLine();
            GetTodoItemsAsync().Wait();
            GetTodoItemAsync(1).Wait();
            Console.ReadLine();
        }

        public static bool IsNetworkLive()
        {
            var pingGoogle = new Ping();
            var pingOptions = new PingOptions();
            pingOptions.DontFragment = true;
            string data = "abcdefghijklomnopqrstuvwxyz";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            var timeout = 120;

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Loop {i}");
                var reply = pingGoogle.Send("8.8.8.8", timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
            }

            return false;
            //return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        public static async Task GetTodoItemsAsync()
        {
            using (var client = new HttpClient())
            {
                var JSONString = await client.GetStringAsync(URL);
                todoItems = JsonConvert.DeserializeObject<List<TaskItem>>(JSONString);
            }
            printitems();
        }

        public static async Task GetTodoItemAsync( int taskID )
        {
            using (var client = new HttpClient())
            {
                var JSONString = await client.GetStringAsync(URL + $"{taskID}");
                TaskItem todoItem = JsonConvert.DeserializeObject<TaskItem>(JSONString);
                Console.WriteLine($"{todoItem.TaskItemID,-5} {todoItem.Description,-20} Completed: {todoItem.TaskDone,-6} {todoItem.DateDue}");
            }
            
        }

        public static async Task DeleteTodoItemsAsync(int taskid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URLPost);
                client.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage response = await client.DeleteAsync($"/api/taskitems/{taskid}");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Task {taskid} Deleted");
                }
                else
                {
                    Console.WriteLine($"Failed to delete Task");
                }
            }
        }

        public static async Task CreateTodoItemAsync()
        {
            using (var client = new HttpClient())
            {
                var todo = new TaskItem
                {
                    Description = "Urgent new task",
                    DateDue = DateTime.Parse("2019-04-04"),
                    TaskDone = false,
                    UserID = 2,
                    CategoryID = 2
                };

                client.BaseAddress = new Uri(URLPost);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(todo), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("/api/taskitems", content);
                if (response.IsSuccessStatusCode)
                {
                    string jsonTask = await response.Content.ReadAsStringAsync();
                    TaskItem t = JsonConvert.DeserializeObject<TaskItem>(jsonTask);
                    Console.WriteLine($"To do item posted id was {t.TaskItemID}");
                }
                else
                {
                    Console.WriteLine($"Failed to post item. Status code:{response.StatusCode}");
                }
            }
        }

        public static async Task EditTodoItemAsync(int itemid, TaskItem updateTask)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(URLPost);

                var JSONString = await client.GetStringAsync($"/api/taskitems/{itemid}");
                var ToDoItem = JsonConvert.DeserializeObject<TaskItem>(JSONString);

                //ToDoItem.Description = updateTask.Description.Equals("") ? ToDoItem.Description : updateTask.Description;
                //ToDoItem.DateDue = updateTask.DateDue == DateTime.MinValue ? ToDoItem.DateDue : updateTask.DateDue;
                //ToDoItem.TaskDone = updateTask.TaskDone.ToString().Equals("") ? ToDoItem.TaskDone : updateTask.TaskDone;
                //ToDoItem.CategoryID = updateTask.CategoryID.ToString().Equals("") ? ToDoItem.CategoryID : updateTask.CategoryID;
                
                JObject toDoItem = JObject.Parse(JsonConvert.SerializeObject(ToDoItem));
                JObject toDoItemUpdate = JObject.Parse(JsonConvert.SerializeObject(updateTask));
                
                toDoItem.Merge(toDoItemUpdate, new JsonMergeSettings
                { 
                    MergeArrayHandling = MergeArrayHandling.Merge 
                });

                TaskItem merged = JsonConvert.DeserializeObject<TaskItem>(toDoItem.ToString());

                Console.WriteLine($"{merged.TaskItemID,-5} {merged.Description,-20} Completed: {merged.TaskDone,-6} {merged.DateDue}");
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //var content = new StringContent(JsonConvert.SerializeObject(JsonConvert.DeserializeObject<TaskItem>(toDoItem.ToString())), Encoding.UTF8, "application/json");

                //HttpResponseMessage response = await client.PutAsync($"/api/taskitems/{itemid}", content);
                //if (response.IsSuccessStatusCode)
                //{
                //    Console.WriteLine("To do item updated");
                //}
                //else
                //{
                //    Console.WriteLine($"Failed to update item. Status code:{response.StatusCode}");
                //}
            }
        }

        public static void printitems()
        {
            todoItems.ForEach(t => Console.WriteLine($"{t.TaskItemID, -5} {t.Description,-20} Completed: {t.TaskDone, -6} {t.DateDue}"));
        }
    }

    public class TaskItem
    {
        public int TaskItemID { get; set; }

        public string? Description { get; set; }

        public bool? TaskDone { get; set; }

        [Display(Name = "Date Due")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateDue { get; set; }

        public int? UserID { get; set; }

        public int? CategoryID { get; set; }

    }
    public class Category
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}
