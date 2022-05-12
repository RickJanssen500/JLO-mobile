using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JLOmobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EndPage : ContentPage
    {
        int ID;
        public EndPage(int id)
        {
            InitializeComponent();
            ID = id;
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync($"https://i454010.luna.fhict.nl/api/Order/Complete/{ID}", null);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            await Navigation.PushAsync(new MainPage());
        }
    }
}