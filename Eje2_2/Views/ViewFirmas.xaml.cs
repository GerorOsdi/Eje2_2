using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eje2_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewFirmas : ContentPage
    {
        public ViewFirmas()
        {
            InitializeComponent();
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            lstFirmas.ItemsSource = await App.dbFirmas.GetFirmas();
            
        }

        private ImageSource convertToImage(Byte[] byteImage) { 
            if(byteImage != null)
            {
                ImageSource fill;
                
                fill = ImageSource.FromStream(() => new MemoryStream(byteImage));

                return fill;
            }
            return null;
        }
    }

}