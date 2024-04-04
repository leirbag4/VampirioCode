using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.VerticalItemListManagement
{
    public class SItemImage
    {

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Image")]
        [Browsable(true)]
        public virtual Image Image
        {
            set { _image = value; _originalImage = value; }
            get { return _image; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Image Align")]
        [Browsable(true)]
        public ContentAlignment ImageAlign
        {
            set{ _imageAlign = value; }
            get { return _imageAlign; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Aspect")]
        [Browsable(true)]
        public bool ConserveAspect
        {
            set { _conserveAspect = value; if (_image != null) { if ((_resizeImage.Width != 0) && (_resizeImage.Height != 0)) Size = new Size(_resizeImage.Width, _resizeImage.Height); } }
            get { return _conserveAspect; }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Size")]
        [Browsable(true)]
        public Size Size
        {
            set
            {
                if (_image != null)
                {
                    _resizeImage = value;

                    if ((_resizeImage.Width > 0) && (_resizeImage.Height > 0))
                        _image = VampirioCode.UI.VampGraphics.VampirioGraphics.ResizeBitmap((Bitmap)_originalImage, _resizeImage.Width, _resizeImage.Height, _conserveAspect);
                }
            }
            get { return _resizeImage; }

        }


        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }


        private Image _originalImage;
        private Image _image;
        private ContentAlignment _imageAlign = ContentAlignment.MiddleCenter;
        private bool _conserveAspect = true;
        protected Size _resizeImage;
        private bool _visible = true;

        public Point Offsets;//0, 0 by default

        public SItemImage()
        {

        }

        public SItemImage(Image img)
        {
            _image =            img;
            _originalImage =    img;
        }

        public SItemImage(Image img, int width)
        {
            _image =            img;
            _originalImage =    img;
            _conserveAspect=    true;
            Size =              new Size(width, img.Height); //doesn't care on height
        }

    }
}
