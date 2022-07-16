using SignaturePad.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;

namespace Eje2_2
{
    public partial class MainPage : ContentPage
    {
        //private List<SKPath> skPaths = new List<SKPath>();
        //private List<SKPath> temporaryPaths = new List<SKPath>();
        Stream image;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.ViewFirmas());
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                image = await firmaView.GetImageStreamAsync(SignatureImageFormat.Jpeg);

                if (txtNombre.Text != null || txtDesc.Text != null)
                {
                    var reg = new Models.ModelsFrimas
                    {
                        Id = 0,
                        Descp = txtDesc.Text,
                        Name = txtNombre.Text,
                        foto = convertFirma()
                    };
                    //var directory = new Java.I
                    //var path = Path.Combine()
                    //using (FileStream file = new FileStream())
                        var result = await App.dbFirmas.SaveFirma(reg);
                        limpiar();

                }
                else
                {
                    await DisplayAlert("Aviso", "Debe de llenar todos los campos", "Ok");
                }
            }
            catch (Exception) { }
        }

        private Byte[] convertFirma()
        {
            if(image != null)
            {
                using (MemoryStream dato = new MemoryStream())
                {
                    Stream stream = image;
                    stream.CopyTo(dato);
                    return dato.ToArray();
                }
            }
            return null;
        }

        public void limpiar()
        {
            txtDesc.Text = "";
            txtNombre.Text = "";
            firmaView.Clear();
        }

       /* private async void saveStore()
        {
            var pict = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreMediaOptions
            {
                Directory = "MisFotos",
                Name = "firma.jpg"
                //SaveToAlbum = true

            });
        }*/

        /* private void PaintSample_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
         {
             var surface = e.Surface;
             var canvas = surface.Canvas;
             canvas.Clear(SKColors.Bisque);

             var stroke = new SKPaint
             {
                 Color = SKColors.Black,
                 StrokeWidth = 5,
                 Style = SKPaintStyle.Stroke
             };

             foreach (var touchPath in skPaths)
             {
                 canvas.DrawPath(touchPath, stroke);
             }
         }

         private void OnTouch(object sender, SKTouchEventArgs e)
         {
             switch (e.ActionType)
             {
                 case SKTouchAction.Pressed:
                     var pun = new SKPath();
                     pun.MoveTo(e.Location);
                     temporaryPaths[(int)e.Id] = pun;
                     break;
                 case SKTouchAction.Moved:
                     if (e.InContact)
                         temporaryPaths[(int)e.Id].LineTo(e.Location);
                     break;
                 case SKTouchAction.Released:
                     skPaths.Add(temporaryPaths[(int)e.Id]);
                     //temporaryPaths.Remove(e);
                     break;
             }

             e.Handled = true;

             ((SKCanvasView)sender).InvalidateSurface();
         }*/
    }
}
