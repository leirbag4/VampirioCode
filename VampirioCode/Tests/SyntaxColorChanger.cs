using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampDocManager;
using VampEditor;
using VampirioCode.Command.Dotnet.Params;
using VampirioCode.UI;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.VerticalItemListManagement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VampirioCode.Tests
{
    public partial class SyntaxColorChanger : VampirioForm
    {
        class LangStyle
        {
            public string fullName;
            public string type;
            public string language;
            public string constantName;
            public int constValue;
            public Color defaultColor;
        }

        private LangStyle CurrLangStyle { get { return currLangStyle; } }
        private Style CurrStyle { get { return editor.Styles[CurrLangStyle.constValue]; } }

        private VampirioEditor editor;
        private VampDocManager.Document document;

        private Dictionary<string, LangStyle> styles = new Dictionary<string, LangStyle>();
        private Assembly assembly;
        private LangStyle currLangStyle = null;
        private Color copyColor = Color.Empty;
        private bool _enableInputEvents = true;
        private bool _enableColorPickerEvents = true;
        private bool _enableSliderEvents = true;

        public SyntaxColorChanger()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            DocumentType docType = document.DocType;

            docTypeLabel.Text = "Document: " + docType;

            //assembly = Assembly.LoadFrom("Scintilla.NET.dll");
            assembly = Assembly.Load("Scintilla.NET, Culture=neutral, PublicKeyToken=null");

            if ((docType == DocumentType.CSHARP) ||
                    (docType == DocumentType.CPP) ||
                    (docType == DocumentType.JAVA) ||
                    (docType == DocumentType.JS) ||
                    (docType == DocumentType.TXT))
            {
                AddStyle("Style.Cpp.Identifier");
                AddStyle("Style.Cpp.Comment");
                AddStyle("Style.Cpp.CommentLine");
                AddStyle("Style.Cpp.CommentLineDoc");
                AddStyle("Style.Cpp.Number");
                AddStyle("Style.Cpp.Word");
                AddStyle("Style.Cpp.Word2");
                AddStyle("Style.Cpp.String");
                AddStyle("Style.Cpp.StringEol");
                AddStyle("Style.Cpp.Character");
                AddStyle("Style.Cpp.Verbatim");
                AddStyle("Style.Cpp.Operator");
                AddStyle("Style.Cpp.Preprocessor");
                AddStyle("19");
            }
            else if (docType == DocumentType.HTML)
            {
                // HTML
                AddStyle("Style.Html.Default");
                AddStyle("Style.Html.Tag");
                AddStyle("Style.Html.TagUnknown");
                AddStyle("Style.Html.Attribute");
                AddStyle("Style.Html.AttributeUnknown");
                AddStyle("Style.Html.Number");
                AddStyle("Style.Html.DoubleString");
                AddStyle("Style.Html.SingleString");
                AddStyle("Style.Html.Other");
                AddStyle("Style.Html.Comment");
                AddStyle("Style.Html.Entity");
                AddStyle("Style.Html.TagEnd");
                AddStyle("Style.Html.XmlStart");
                AddStyle("Style.Html.XmlEnd");
                AddStyle("Style.Html.Script");
                AddStyle("Style.Html.Asp");
                AddStyle("Style.Html.AspAt");
                AddStyle("Style.Html.CData");
                AddStyle("Style.Html.Question");
                AddStyle("Style.Html.Value");
                AddStyle("Style.Html.XcComment");

                // JAVASCRIPT
                AddStyle("Style.JavaScript.Start");
                AddStyle("Style.JavaScript.Default");
                AddStyle("Style.JavaScript.Comment");
                AddStyle("Style.JavaScript.CommentLine");
                AddStyle("Style.JavaScript.CommentDoc");
                AddStyle("Style.JavaScript.Number");
                AddStyle("Style.JavaScript.Word");
                AddStyle("Style.JavaScript.Keyword");
                AddStyle("Style.JavaScript.DoubleString");
                AddStyle("Style.JavaScript.SingleString");
                AddStyle("Style.JavaScript.Symbols");
                AddStyle("Style.JavaScript.StringEol");
                AddStyle("Style.JavaScript.Regex");
            }
            else if (docType == DocumentType.PHP)
            {
                AddStyle("Style.PhpScript.Default");
                AddStyle("Style.PhpScript.HString");
                AddStyle("Style.PhpScript.SimpleString");
                AddStyle("Style.PhpScript.Word");
                AddStyle("Style.PhpScript.Number");
                AddStyle("Style.PhpScript.Variable");
                AddStyle("Style.PhpScript.Comment");
                AddStyle("Style.PhpScript.CommentLine");
                AddStyle("Style.PhpScript.HStringVariable");
                AddStyle("Style.PhpScript.Operator");
                AddStyle("18");
                AddStyle("121");
                AddStyle("104");
            }


            FillList();

            styleList.SelectedItemChanged += OnSelectedItemChanged;

            styleList.SelectedIndex = 0;
        }

        private void OnSelectedItemChanged(object sender)
        {
            LangStyle langStyle = (LangStyle)(styleList.SelectedItem.Tag);

            Color color = editor.Styles[langStyle.constValue].ForeColor;

            _enableInputEvents = false;
            _enableColorPickerEvents = false;
            _enableSliderEvents = false;

            SetInputColor(color);
            colorPicker.SelectedColor = color;
            redSlider.Value = color.R;
            greenSlider.Value = color.G;
            blueSlider.Value = color.B;

            _enableInputEvents = true;
            _enableColorPickerEvents = true;
            _enableSliderEvents = true;

            currLangStyle = langStyle;
        }

        private void SetInputColor(Color color)
        {
            redInput.value = color.R;
            greenInput.value = color.G;
            blueInput.value = color.B;
        }

        private void FillList()
        {
            SItem item;
            List<Control> items = new List<Control>();

            foreach (var style in styles)
            {
                item = new SItem();
                item.Text = style.Value.constantName;
                item.Tag = style.Value;

                items.Add(item);
            }

            styleList.AddItems(items);
        }


        private void AddStyle(string styleName)
        {
            int constValue;
            LangStyle style = null;

            if (int.TryParse(styleName, out constValue))
            {
                string str = styleName.ToString();
                style = new LangStyle() { fullName = styleName, type = styleName, language = styleName, constantName = styleName, constValue = constValue };
            }
            else
            {
                string typeName = "ScintillaNET." + styleName.Substring(0, styleName.LastIndexOf('.'));
                string language = typeName.Substring(typeName.LastIndexOf('.') + 1);
                typeName = typeName.Substring(0, typeName.LastIndexOf('.'));
                string constantName = styleName.Substring(styleName.LastIndexOf('.') + 1);

                Type type = assembly.GetType(typeName + "+" + language);
                int val = GetConstantValue<int>(type, constantName);

                style = new LangStyle() { fullName = styleName, type = typeName, language = language, constantName = constantName, constValue = val };
            }

            style.defaultColor = editor.Styles[style.constValue].ForeColor;
            styles.Add(styleName, style);
        }

        private T GetConstantValue<T>(Type type, string constantName)
        {
            FieldInfo field = type.GetField(constantName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (field == null)
            {
                throw new ArgumentException($"No se pudo encontrar el campo '{constantName}'.");
            }
            object value = field.GetValue(null);
            return (T)value;
        }


        public void Setup(VampirioEditor editor, VampDocManager.Document document)
        {
            this.editor = editor;
            this.document = document;
        }

        private void OnGeneratePressed(object sender, EventArgs e)
        {

            Clear();

            foreach (var style in styles)
            {
                LangStyle langStyle = style.Value;

                Color color = editor.Styles[langStyle.constValue].ForeColor;

                if ((langStyle.defaultColor != color) || generateAllCKBox.Checked)
                {
                    String str = $"Styles[{langStyle.fullName}].ForeColor = CColor({color.R}, {color.G}, {color.B});";
                    Println(str);
                }
            }
        }

        private void OnColorInputEnterPressed(object sender, VampirioCode.UI.Controls.Events.KeyPressedEventArgs e)
        {
            if (CurrLangStyle == null)
                return;

            IntTextBox txtBox;

            if (sender == redInput) txtBox = redInput;
            else if (sender == greenInput) txtBox = greenInput;
            else if (sender == blueInput) txtBox = blueInput;
        }

        private void OnColorInputTextChanged(object sender, EventArgs e)
        {
            if (!_enableInputEvents)
                return;

            if (CurrLangStyle == null)
                return;

            Color color = editor.Styles[CurrLangStyle.constValue].ForeColor;
            Color newColor = Color.Empty;

            if (sender == redInput)
            {
                newColor = Color.FromArgb(redInput.value, color.G, color.B);
            }
            else if (sender == greenInput)
            {
                newColor = Color.FromArgb(color.R, greenInput.value, color.B);
            }
            else if (sender == blueInput)
            {
                newColor = Color.FromArgb(color.R, color.G, blueInput.value);
            }


            _enableColorPickerEvents = false;
            _enableSliderEvents = false;
            colorPicker.SelectedColor = newColor;
            redSlider.Value = newColor.R;
            greenSlider.Value = newColor.G;
            blueSlider.Value = newColor.B;
            _enableColorPickerEvents = true;
            _enableSliderEvents = true;

            editor.Styles[CurrLangStyle.constValue].ForeColor = newColor;
        }

        private void OnCopyCode(object sender, EventArgs e)
        {
            Clipboard.SetText(outp.Text);
        }


        private void OnColorPickerChanged(object sender, Color color)
        {
            if (!_enableColorPickerEvents)
                return;

            SetInputColor(color);
        }

        private void Clear()
        {
            outp.Clear();
        }


        private void Println(String str)
        {
            int length = outp.TextLength;  // at end of text
            str = str + "\n";
            outp.AppendText(str);
            outp.ScrollToCaret();
        }

        private void OnSliderChanged(object sender, EventArgs e)
        {
            if (sender == redSlider) redInput.value = redSlider.Value;
            else if (sender == greenSlider) greenInput.value = greenSlider.Value;
            else if (sender == blueSlider) blueInput.value = blueSlider.Value;
        }

        private void OnResetThemeToDefaultPressed(object sender, EventArgs e)
        {
            foreach (var style in styles)
            {
                LangStyle langStyle = style.Value;
                editor.Styles[langStyle.constValue].ForeColor = langStyle.defaultColor;
            }

            SetInputColor(CurrStyle.ForeColor);
        }

        private void OnRevertColorPressed(object sender, EventArgs e)
        {
            SetInputColor(CurrLangStyle.defaultColor);
        }

        private void OnCopyColorPressed(object sender, EventArgs e)
        {
            copyColor = CurrStyle.ForeColor;
        }

        private void OnPasteColorPressed(object sender, EventArgs e)
        {
            if (copyColor != Color.Empty)
                SetInputColor(copyColor);
        }
    }
}
