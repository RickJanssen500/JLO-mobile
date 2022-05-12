using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JLOmobile.DataModels;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JLOmobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        public ObservableCollection<Order> Items;
        static readonly HttpClient client = new HttpClient();

        public OrderPage()
        {
            InitializeComponent();
            GetOrders();
            
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            ListView lv = (ListView)sender;
            Order order = (Order)lv.SelectedItem;

            await Navigation.PushAsync(new ProductPage(order.Id));

            
            ((ListView)sender).SelectedItem = null;
        }

        public async void GetOrders()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://i454010.luna.fhict.nl/api/Order/GetAll");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                Items = JsonConvert.DeserializeObject<ObservableCollection<Order>>(responseBody);
                OrderList.ItemsSource = Items;
                Console.WriteLine("success");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                Items = new ObservableCollection<Order>
                {
                   new Order(-404, DateTime.Now),
                };
                OrderList.ItemsSource = Items;
            }
        }
    }
}
