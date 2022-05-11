using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using JLOmobile.DataModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JLOmobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        public ObservableCollection<Order> Items { get; set; }

        public OrderPage()
        {
            InitializeComponent();
            //db get!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            DateTime date = DateTime.Now;
            Items = new ObservableCollection<Order>
            {
               new Order(1, date),
               new Order(2, date),
               new Order(3, date),

            };
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            OrderList.ItemsSource = Items;
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
    }
}
