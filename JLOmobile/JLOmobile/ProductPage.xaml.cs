using JLOmobile.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
        bool check;
        int prodid;
        public ProductPage(int id)
        {
            InitializeComponent();
            ID = id;
            picked = 0;
            Product product = new Product();
            //db get!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // send ID
            product.Name = "test";
            product.Id = 24;
            product.Amount = 2;
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (product == null)
            {
                check = false;
            }
            else 
            {
                check = true;
                prodid = product.Id;
                Name.Text = product.Name;
                Amount.Text = product.Amount.ToString();
                amount = product.Amount;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!check) 
            {
                End();
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
            ///Save function!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            /////  picked en  prodid gebruiken
            await Navigation.PushAsync(new ProductPage(ID));
        }
    }
}