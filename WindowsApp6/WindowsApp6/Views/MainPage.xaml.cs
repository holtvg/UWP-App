using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsApp6.ViewModels;
using System.Collections.Specialized;
using Windows.UI.ViewManagement;
using Windows.Foundation;

namespace WindowsApp6.Views
{
    public sealed partial class MainPage : Page
    {

        ObservableCollection<item> list = new ObservableCollection<item>();

        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            //  ApplicationView.PreferredLaunchViewSize = new Size(480, 880);
            //  ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            var client = new HttpClient();
            //  {
            var response = "";
            Task task = Task.Run(async () =>
            {
                //  response = await client.GetStringAsync(App.BaseUri);
                //  response = await client.GetStringAsync(new Uri("http://localhost:1234/api/user"));
                //  response = await client.GetStringAsync(new Uri("http://localhost:63193/"));
                response = await client.GetStringAsync(new Uri("http://localhost:63193/api/item"));
                //  response = await client.GetStringAsync(new Uri("http://localhost:56851"));
            });
            task.Wait(); // Wait
                         //  listView.ItemsSource = JsonConvert.DeserializeObject<List<item>>(response);

            list = JsonConvert.DeserializeObject<ObservableCollection<item>>(response);
            listView.ItemsSource = list;
            //  listView.ItemsSource = JsonConvert.DeserializeObject<ObservableCollection<item>>(response);
            //  App.ActiveUser = JsonConvert.DeserializeObject<List<item>>(response)[0];
            //  }
        }

        private async void button_Click_1(object sender, RoutedEventArgs e)
        {


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:63193/");


            //  string id = textBlock.Text;

            int id = 0;
          //  string category = null;
            string category = "";


            // id = int.Parse(textBox.Text);

            //  if (category != null)
            // {

            string name = textBox2.Text;
            category = textBox3.Text;
            //  if (category != null)
            if (category != "")
            {
                    var response2 = "";
                    Task task2 = Task.Run(async () =>
                    {
                    //  response = await client.GetStringAsync(Uri);
                    //  if(id!=null)
                    response2 = await client.GetStringAsync(new Uri($"http://localhost:63193/api/item/category/{category}"));
                    });
                    task2.Wait();

                    ObservableCollection<item> list = new ObservableCollection<item>();

                    list = JsonConvert.DeserializeObject<ObservableCollection<item>>(response2);

                    listView.ItemsSource = list;
                }


            {
                try
                {
                    id = int.Parse(textBox.Text);
                }
                catch (Exception) { }

                if (id != 0)
                {
                    var response = "";
                    Task task = Task.Run(async () =>
                    {
                    //  response = await client.GetStringAsync(Uri);
                    //  if(id!=null)
                    response = await client.GetStringAsync(new Uri($"http://localhost:63193/api/item/{id}"));
                    });
                    task.Wait(); // Wait
                                 //  listView.ItemsSource = JsonConvert.DeserializeObject<List<item>>(response);
                                 // var source = JsonConvert.DeserializeObject<List<item>>(response);
                                 //  var source = JsonConvert.DeserializeObject<item>(response);

                    //  List<item> list = new List<item>();



                    var itm = JsonConvert.DeserializeObject<item>(response);

                    ObservableCollection<item> list2 = new ObservableCollection<item>();

                    list2.Add(itm);

                    //  var list = JsonConvert.DeserializeObject<List<item>>(response);

                    //if(list.Contains

                    //         list.ForEach(item.id)
                    //         list.ToString

                    listView.ItemsSource = list2;
                }
                
            }

            //  id = 0;
          //  category = null;



            // item[] arr= JsonConvert.DeserializeObject<item[]>(response);

            //  listView.ItemsSource = JsonConvert.DeserializeObject<item[]>(response);

        }

        //public List<T> Deserialize<T>(this string SerializedJSONString)
        //{
        //    var stuff = JsonConvert.DeserializeObject<List<T>>(SerializedJSONString);
        //    return stuff;
        //}

        // }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:63193");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var user = new item();

            user.id = int.Parse(textBox.Text);
            user.name = textBox2.Text;
            user.category = textBox3.Text;
            user.price = decimal.Parse(textBox4.Text);

            //  ObservableCollection<item> list = new ObservableCollection<item>();
            list.Add(user);
            list.CollectionChanged += myList_CollectionChanged;
            //  listView.ItemsSource = list;

            var response = client.PostAsJsonAsync("api/item", user).Result;   //install-package Microsoft.AspNet.WebApi.Client
                                                                              // var response = client.PostAsync("api/item", user).Result;
                                                                              //  var response = client.PostAsync("api/item", new StringContent(
                                                                              // new JavaScriptSerializer().Serialize(user), Encoding.UTF8, "application/json")).Result;

            //  Button_Click(sender,e);
            //  button3.Click


        }

        private void myList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                listView.ItemsSource = list;
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                listView.ItemsSource = list;
            }
        }

        private void button_Click_3(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:63193/");

            // var id = textBox.Text;

            //  var id = int.Parse(textBox.Text);
            string category = textBox3.Text;

            // list.Remove(new item { id = id });
            list.Remove(new item { category = category });
            // listView.ItemsSource = list;

            //  var url = "api/item/" + id;
            var url = "api/item/category/" + category;

            HttpResponseMessage response = client.DeleteAsync(url).Result;

            //  Button_Click(sender, e);
        }

        private void ResultTextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void textBlock5_Copy_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}


