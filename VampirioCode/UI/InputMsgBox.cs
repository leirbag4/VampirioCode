using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.UI.Controls;

namespace VampirioCode.UI
{
    public partial class InputMsgBox : VampirioForm
    {
        public static string InputText { get { return _inputText; } }

        private static string _inputText = "";

        public InputMsgBox()
        {
            InitializeComponent();
        }

        private void ModuleInitialize(ContainerControl parent, string title, string inputText, string okButtonText, string cancelButtonText, string description)
        {
            Text = title;
            inputLabel.Text = inputText;
            descLabel.Text = description;
            okButton.Text = okButtonText;
            cancelButton.Text = cancelButtonText;

            //input.Text = "";
            //input.Focus();
            //input.SelectAll();
        }

        public static DialogResult Show(ContainerControl parent, string title, string inputText, string description)
        {
            return Show(parent, title, inputText, description, "OK", "Cancel");
        }

        public static DialogResult Show(ContainerControl parent, string title, string inputText, string description, string okButtonText, string cancelButtonText)
        {
            InputMsgBox inputMsgBox = new InputMsgBox();
            inputMsgBox.ModuleInitialize(parent, title, inputText, okButtonText, cancelButtonText, description);
            inputMsgBox.ShowMe(parent);
            return inputMsgBox.DialogResult;
        }

        private void OnOkPressed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            _inputText = input.Text;
            this.Close();
        }

        private void OnCancelPressed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            _inputText = "";
            this.Close();
        }

        private void OnEnterPressed(object sender, VampirioCode.UI.Controls.Events.KeyPressedEventArgs e)
        {
            OnOkPressed(null, EventArgs.Empty);
        }
    }
}
