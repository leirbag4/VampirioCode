using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TreeViewAdvance
{
    public class TIcon
    {
        //public int X { get; set; } = 0;
        //public int Y { get; set; } = 0;
        public int Width { 		get { return _width; } 		set{ _width = 		value; /*treeView.RefreshAll();*/ } }
        public int Height { 	get { return _height; } 	set{ _height = 		value;} }
        public int LeftSpace { 	get { return _leftSpace; } 	set{ _leftSpace = 	value; /*treeView.RefreshAll();*/ } }
        public bool Active { 	get { return _active; } 	set{ _active = 		value; /*treeView.RefreshAll();*/ } }
        public TRect Rect { get; set; }

        // Position
        public PositionMode PositionMode { get; set; } = PositionMode.Centered;
        public int IconOffsetX { get; set; } = 0;
        public int IconOffsetY { get; set; } = 0;
        /// <summary>
        /// From 0.0001 to 1.0
        /// </summary>
        public float IconOffsetScale { get; set; } = 1.0f;

        // Private
        private TreeViewAdv treeView = null;
        private int _width = 		14;
        private int _height = 		14;
        private int _leftSpace = 	2;
        private bool _active = 		false;


        public TIcon(TreeViewAdv treeView, int width, int height = 14, int leftSpace = 2, bool active = true) 
        {
            this.treeView =     treeView;
            this._width =	    width;
            this._height =		height;
            this._leftSpace =   leftSpace;
            this._active =		active;
        }

        /*public void SetPos(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Rectangle ToRect()
        { 
            return new Rectangle(X, Y, _width, _height);
        }*/
    }
}
