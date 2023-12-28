using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI
{
    public enum DialogButtons
    {
        AbortRetryIgnore,
        OK,
        OKCancel,
        RetryCancel,
        YesNo,
        YesNoCancel
    }

    public enum DialogIcon
    {
        Question,
        Info,
        Warning,
        Error
    }

    public partial class MsgBox : VampirioCode.UI.Controls.VampirioForm
    {
        private DialogButtons currButtons;

        private static string[] buttons_str = new string[]{
            "Abort",
            "Cancel",
            "Ignore",
            "No",
            "OK",
            "Retry",
            "Yes"};

        private const int _abort = 0;
        private const int _cancel = 1;
        private const int _ignore = 2;
        private const int _no = 3;
        private const int _ok = 4;
        private const int _retry = 5;
        private const int _yes = 6;

        public MsgBox()
        {
            InitializeComponent();
        }

        private void module_initialize(String title, String description, DialogButtons buttons, DialogIcon dialogIcon)
        {
            Text = title;
            descLabel.Text = description;
            currButtons = buttons;
            DialogResult = DialogResult.Cancel;
            SetupIcon(dialogIcon);
            SetupButtons(buttons);
        }

        public static DialogResult Show(String description, DialogButtons buttons = DialogButtons.OK, DialogIcon dialogIcon = DialogIcon.Question)
        {
            return Show(null, "", description, buttons, dialogIcon);
        }

        public static DialogResult Show(ContainerControl parent, String description, DialogButtons buttons = DialogButtons.OK, DialogIcon dialogIcon = DialogIcon.Question)
        {
            return Show(parent, "", description, buttons, dialogIcon);
        }

        public static DialogResult Show(String title, String description, DialogButtons buttons = DialogButtons.OK, DialogIcon dialogIcon = DialogIcon.Question)
        {
            return Show(null, title, description, buttons, dialogIcon);
        }

        public static DialogResult Show(ContainerControl parent, String title, String description, DialogButtons buttons = DialogButtons.OK, DialogIcon dialogIcon = DialogIcon.Question)
        {
            MsgBox msgBox = new MsgBox();

            msgBox.module_initialize(title, description, buttons, dialogIcon);
            msgBox.ShowMe(parent);

            return msgBox.DialogResult;
        }

        protected void SetupIcon(DialogIcon dialogIcon)
        {
            /*if (dialogIcon == DialogIcon.Question)
                icon.Image = LizardEngine.Properties.Resources.dialog_question_med;
            else if (dialogIcon == DialogIcon.Info)
                icon.Image = LizardEngine.Properties.Resources.dialog_info_med;
            else if (dialogIcon == DialogIcon.Warning)
                icon.Image = LizardEngine.Properties.Resources.dialog_warning_info_med;
            else if (dialogIcon == DialogIcon.Error)
                icon.Image = LizardEngine.Properties.Resources.dialog_error_info_med;*/
        }

        protected void SetupButtons(DialogButtons buttons)
        {
            if (buttons == DialogButtons.AbortRetryIgnore)
                _SetButtons(DialogResult.Abort, DialogResult.Retry, DialogResult.Ignore);
            else if (buttons == DialogButtons.OK)
                _SetButtons(DialogResult.OK);
            else if (buttons == DialogButtons.OKCancel)
                _SetButtons(DialogResult.OK, DialogResult.Cancel);
            else if (buttons == DialogButtons.RetryCancel)
                _SetButtons(DialogResult.Retry, DialogResult.Cancel);
            else if (buttons == DialogButtons.YesNo)
                _SetButtons(DialogResult.Yes, DialogResult.No);
            else if (buttons == DialogButtons.YesNoCancel)
                _SetButtons(DialogResult.Yes, DialogResult.No, DialogResult.Cancel);
        }

        protected void _SetButtons(DialogResult button01Dialog)
        {
            ShowButtons(button0, true);
            Assign(button0, button01Dialog);
            button0.Select();
        }

        protected void _SetButtons(DialogResult button01Dialog, DialogResult button02Dialog)
        {
            ShowButtons(button1, button2);
            Assign(button1, button01Dialog);
            Assign(button2, button02Dialog);
        }

        protected void _SetButtons(DialogResult button01Dialog, DialogResult button02Dialog, DialogResult button03Dialog)
        {
            ShowButtons(button0, button1, button2);
            Assign(button0, button01Dialog);
            Assign(button1, button02Dialog);
            Assign(button2, button03Dialog);
        }

        protected void ShowButtons(Button butA, bool center = false)
        {
            HideButtons();
            butA.Visible = true;
            if (center)
                butA.Location = new Point((this.Width >> 1) - (butA.Width >> 1), butA.Location.Y);
        }

        protected void ShowButtons(Button butA, Button butB)
        {
            HideButtons();
            butA.Visible = butB.Visible = true;
        }

        protected void ShowButtons(Button butA, Button butB, Button butC)
        {
            HideButtons();
            butA.Visible = butB.Visible = butC.Visible = true;
        }

        private void HideButtons()
        {
            button0.Visible = button1.Visible = button2.Visible = false;
        }

        protected void Assign(Button ubutton, DialogResult buttonType)
        {
            ubutton.DialogResult = buttonType;
            ubutton.Click += OnButtonPressed;

            if (buttonType == DialogResult.Abort)
            {
                ubutton.Text = buttons_str[_abort];
            }
            else if (buttonType == DialogResult.Cancel)
            {
                ubutton.Text = buttons_str[_cancel];
            }
            else if (buttonType == DialogResult.Ignore)
            {
                ubutton.Text = buttons_str[_ignore];
            }
            else if (buttonType == DialogResult.No)
            {
                ubutton.Text = buttons_str[_no];
            }
            else if (buttonType == DialogResult.OK)
            {
                ubutton.Text = buttons_str[_ok];
            }
            else if (buttonType == DialogResult.Retry)
            {
                ubutton.Text = buttons_str[_retry];
            }
            else if (buttonType == DialogResult.Yes)
            {
                ubutton.Text = buttons_str[_yes];
            }
        }

        private void OnButtonPressed(object sender, EventArgs e)
        {
            DialogResult = (sender as Button).DialogResult;
            this.Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
