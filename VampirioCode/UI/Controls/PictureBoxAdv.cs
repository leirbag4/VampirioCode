using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls
{
    public class PictureBoxAdv : PictureBox
    {

        [Localizable(true)]
        [Category("Extra Events")]
        [Description("Image Changed Event")]
        [Browsable(true)]
        public event EventHandler ImageChanged;

        private Bitmap originalColorImage = null;
        private Bitmap grayscaleImage = null;

        private bool canDetectEvent = true;

        public Image Image
        {
            get
            {
                return base.Image;
            }
            set
            {
                base.Image = value;
                if (canDetectEvent)
                {
                    originalColorImage = (Bitmap)base.Image;
                    grayscaleImage = null;
                    if (this.ImageChanged != null)
                        this.ImageChanged(this, new EventArgs());
                }
            }
        }

        public bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                if ((grayscaleImage == null) && (originalColorImage != null))
                    grayscaleImage = toGrayScale(originalColorImage);

                if (value)
                {
                    canDetectEvent = false;
                    this.Image = originalColorImage;
                    canDetectEvent = true;
                }
                else
                {
                    canDetectEvent = false;
                    this.Image = grayscaleImage;
                    canDetectEvent = true;
                }

                base.Enabled = value;
            }
        }


        private Bitmap toGrayScale(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
              {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
              });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

    }
}
