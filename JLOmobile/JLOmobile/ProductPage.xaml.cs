using JLOmobile.DataModels;
using Newtonsoft.Json;
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
    public partial class ProductPage : ContentPage
    {
        int picked;
        int amount;
        int ID;
        int prodid;
        HttpClient client = new HttpClient();
        Product product;
        public ProductPage(int id)
        {
            InitializeComponent();
            ID = id;
            picked = 0;
            if (id == -404)
            {
                Alabel.IsVisible = false;
                Glabel.Text = "Er is iets fout gegaan met data ophalen";
                Name.Text = "Error";
                ButtonGrid.IsVisible = false;
                Commit.IsVisible = false;
            }
            else
            {
                GetItem(id);
            }
           
        }


        async private void End() 
        {
            await Navigation.PushAsync(new EndPage(ID));
        }



        private void Min_Clicked(object sender, EventArgs e)
        {
            picked--;
            if (picked < 0)
            {
                picked = 0;
            }
            pickedlabel.Text = picked.ToString();
        }

        private void Plus_Clicked(object sender, EventArgs e)
        {
            picked++;
            if (picked > amount)
            {
                picked = amount;
            }
            pickedlabel.Text = picked.ToString();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            
            HttpResponseMessage response = await client.PostAsync($"https://i454010.luna.fhict.nl/api/OrderProduct/Add/{prodid}/{picked}", null);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            await Navigation.PushAsync(new ProductPage(ID));
        }



        public async void GetItem(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://i454010.luna.fhict.nl/api/OrderProduct/Get/{id}");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<Product>(responseBody);
                if (product.Name == "EndPicking")
                {
                    End();

                }
                else
                {
                    
                    prodid = product.Id;
                    Name.Text = product.Name;
                    Amount.Text = product.Amount.ToString();
                    amount = product.Amount;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                
            }
        }
    }
}