using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.UI;

namespace VampirioCode.Tests
{
    public partial class ScrollTester : Form
    {
        public ScrollTester()
        {
            InitializeComponent();
            ResetScrollBars();
            RefreshScrollBars();
        }

        private void ResetScrollBars()
        {
            minimumInput.value = 0;
            maximumInput.value = 100;
            smallChangeInput.value = 1;
            largeChangeInput.value = 10;
        }

        private void OnInputEnterPressed(object sender, VampirioCode.UI.Controls.Events.KeyPressedEventArgs e)
        {
            RefreshScrollBars();
        }

        private void OnInputTextChanged(object sender, EventArgs e)
        {
            RefreshScrollBars();
        }

        private void RefreshScrollBars()
        {
            int min = (int)minimumInput.value;
            int max = (int)maximumInput.value;
            int small = (int)smallChangeInput.value;
            int large = (int)largeChangeInput.value;

            hscrollBarEx.Minimum = min;
            hscrollBarEx.Maximum = max;
            hscrollBarEx.SmallChange = small;
            hscrollBarEx.LargeChange = large;

            hscrollBarOrig.Minimum = min;
            hscrollBarOrig.Maximum = max;
            hscrollBarOrig.SmallChange = small;
            hscrollBarOrig.LargeChange = large;

            hscrollBarX.Minimum = min;
            hscrollBarX.Maximum = max;
            hscrollBarX.SmallChange = small;
            hscrollBarX.LargeChange = large;
        }

        private void OnHScrollChanged(object sender, ScrollEventArgs e)
        {
            XConsole.PrintError("value changed adv: " + hscrollBarEx.Value);
            hscrollExOutp.value = hscrollBarEx.Value;
        }

        private void OnHScrollOrigChanged(object sender, ScrollEventArgs e)
        {
            XConsole.PrintError("value changed orig: " + hscrollBarOrig.Value);
            hscrollOrigOutp.value = hscrollBarOrig.Value;
        }

        private void OnHScrollXChanged(int newValue, int oldValue)
        {
            XConsole.PrintWarning("value changed: " + hscrollBarX.Value);
            hscrollXOutp.value = hscrollBarX.Value;
        }

        private void OnSetValuePressed(object sender, EventArgs e)
        {
            hscrollBarX.Value = (int)hscrollXOutp.value;
        }

        private void OnReadValuesPressed(object sender, EventArgs e)
        {
            hscrollExOutp.value = hscrollBarEx.Value;
            hscrollOrigOutp.value = hscrollBarOrig.Value;
            hscrollXOutp.value = hscrollBarX.Value;
        }

        private void OnSetOriginalPressed(object sender, EventArgs e)
        {
            hscrollBarOrig.Value = (int)hscrollOrigOutp.value;
        }

        private void OnSetExPressed(object sender, EventArgs e)
        {
            hscrollBarEx.Value = (int)hscrollExOutp.value;
        }

    }
}
