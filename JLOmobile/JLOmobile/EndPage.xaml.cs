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
            // order complete function!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //send ID
            await Navigation.PushAsync(new MainPage());
        }
    }
}