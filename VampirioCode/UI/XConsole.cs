using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.IO;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.TabManagement;

namespace VampirioCode.UI
{
    public partial class XConsole : UserControl
    {
        private static RichTextBox _outp;
        private static RichTextBox _savedOutp;
        private static FooterUI _footer;

        public XConsole()
        {
            InitializeComponent();

            
            // set tab panel skin
            SetupTabSkin();

            // create tabs
            TabItem consoleItem =   new TabItem("console");
            TabItem errorsItem =    new TabItem("errors");

            // console textbox
            RichTextBox outp =    new RichTextBox();
            outp.BackColor =      Color.FromArgb(30, 30, 30);
            outp.ForeColor =      Color.Silver;
            outp.BorderStyle =    BorderStyle.None;
            outp.Dock =           DockStyle.Fill;

            // add textbox to console item
            consoleItem.Content.Controls.Add(outp);

            // add tabs
            tabPanel.Add(consoleItem);
            tabPanel.Add(errorsItem);

            // set output
            SetOutput(outp);
        }

        private void SetupTabSkin()
        { 
            // tab panel skin
            //tabPanel.SetSkin(TabSkin.DarkRectThin);

            tabPanel.AllowDragging =                    false;
            tabPanel.SelectedTabSize.paddingTop =       0;
            tabPanel.SelectedTabSize.paddingBottom =    0;
            tabPanel.NormalTabSize.paddingTop =         0;
            tabPanel.NormalTabSize.paddingBottom =      0;
            tabPanel.TabBorderSize =                    1;

            tabPanel.TabBarHeight =                 23;
            tabPanel.TabBar.BackColor =             Color.FromArgb(40, 40, 40);
            
            tabPanel.SelectedStyle.BackColor =      Color.FromArgb(170, 60, 85);
            tabPanel.SelectedStyle.TextColor =      Color.White;
            tabPanel.SelectedStyle.BorderColor =    Color.FromArgb(143, 50, 71);
            tabPanel.NormalStyle.BackColor =        Color.FromArgb(39, 40, 34);
            tabPanel.NormalStyle.TextColor =        Color.White;
            tabPanel.OverStyle.BackColor =          Color.FromArgb(46, 45, 40);
            tabPanel.OverStyle.TextColor =          Color.White;

            tabPanel.SizeMode =         UI.Controls.TabManagement.TabSizeMode.Fixed;
            tabPanel.MaxTabWidth =      75;
            tabPanel.LeftPadding =      0;
            tabPanel.RightPadding =     0;
        }

        public static void Setup(FooterUI footer)
        {
            _footer = footer;
        }

        private static Color CColor(int red, int green, int blue)
        { 
            return Color.FromArgb(red, green, blue);
        }

        public static void SetOutput(RichTextBox outp)
        {
            _outp = outp;
        }

        public static void Push()
        {
            _savedOutp = _outp;
        }

        public static void Pop()
        {
            _outp = _savedOutp;
        }

        public static void Alert(string str)
        { 
            MessageBox.Show(str);
        }

        public static void ErrorAlert(string str)
        {
            MessageBox.Show(str, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Alert(string[] strArr)
        {
            foreach(var str in strArr)
                MessageBox.Show(str);
        }

        public static void Clear()
        {
            if (_outp.InvokeRequired)
            {
                _outp.Invoke(new MethodInvoker(delegate { _outp.Text = ""; }));
            }
            else
                _outp.Text = "";
        }

        public static void Print(String str)
        {
            if (_outp.InvokeRequired)
            {
                _outp.Invoke(new MethodInvoker(delegate { _Print(str); }));
            }
            else
                _Print(str);
        }

        public static void Print(String str, Color color)
        {
            if (_outp.InvokeRequired)
            {
                _outp.Invoke(new MethodInvoker(delegate { _Print(str, color); }));
            }
            else
                _Print(str, color);
        }

        private static void _Print(String str, Color color)
        {
            int length = _outp.TextLength;  // at end of text
            _outp.AppendText(str);
            _outp.SelectionStart =  length;
            _outp.SelectionLength = str.Length;
            _outp.SelectionColor =  color;
            _outp.ScrollToCaret();
        }

        private static void _Print(String str)
        {
            int length = _outp.TextLength;  // at end of text
            _outp.AppendText(str);
            _outp.ScrollToCaret();
        }

        
        public static void Println(String str)
        {
            if (_outp.InvokeRequired)
            {
                _outp.Invoke(new MethodInvoker(delegate { _Println(str); }));
            }
            else
                _Println(str);
        }

        public static void Println(String str, Color color)
        {
            if (_outp.InvokeRequired)
            {
                _outp.Invoke(new MethodInvoker(delegate { _Println(str, color); }));
            }
            else
                _Println(str, color);
        }

        public static void PrintArr(String[] strArr)
        {
            foreach (var str in strArr)
            {
                if (_outp.InvokeRequired)
                {
                    _outp.Invoke(new MethodInvoker(delegate { _Println(str); }));
                }
                else
                    _Println(str);
            }
        }

        public static void PrintError(String str)
        {
            Println(str, Color.Red);
        }

        public static void PrintError(ErrorInfo error)
        {
            XConsole.PrintError(error.ToString());
        }

        public static void PrintWarning(String str)
        {
            Println(str, Color.Orange);
        }

        /*public static void PrintError(ErrorInfo error)
        {
            XConsole.PrintError(error.ToString());
        }*/
        private static void _Println(String str, Color color)
        {
            int length = _outp.TextLength;  // at end of text
            str = str + "\n";
            _outp.AppendText(str);
            _outp.SelectionStart = length;
            _outp.SelectionLength = str.Length;
            _outp.SelectionColor = color;
            _outp.ScrollToCaret();
        }

        private static void _Println(String str)
        {
            int length = _outp.TextLength;  // at end of text
            str = str + "\n";
            _outp.AppendText(str);
            _outp.ScrollToCaret();
        }

        public static void FooterInfo(String str)
        {
            _footer.SetInfo(str);
        }

    }
}
