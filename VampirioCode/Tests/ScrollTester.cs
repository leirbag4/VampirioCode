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

            hscrollBar.Minimum = min;
            hscrollBar.Maximum = max;
            hscrollBar.SmallChange = small;
            hscrollBar.LargeChange = large;

            hscrollBarOrig.Minimum = min;
            hscrollBarOrig.Maximum = max;
            hscrollBarOrig.SmallChange = small;
            hscrollBarOrig.LargeChange = large;

            hscrollBarX.Minimum = min;
            hscrollBarX.Maximum = max;
            hscrollBarX.SmallChange = small;
            hscrollBarX.LargeChange = large;
            hscrollBarX.Invalidate();
        }

        private void OnHScrollChanged(object sender, ScrollEventArgs e)
        {
            hscrollOutp.value = hscrollBar.Value;
        }

        private void OnHScrollOrigChanged(object sender, ScrollEventArgs e)
        {
            hscrollOrigOutp.value = hscrollBarOrig.Value;
        }

        private void OnHScrollXChanged(int newValue, int oldValue)
        {
            hscrollXOutp.value = hscrollBarX.Value;
        }

        private void OnSetValuePressed(object sender, EventArgs e)
        {
            hscrollBarX.Value = (int)hscrollXOutp.value;
            hscrollBarX.Invalidate();
        }

        private void OnReadValuesPressed(object sender, EventArgs e)
        {
            hscrollOutp.value =     hscrollBar.Value;
            hscrollOrigOutp.value = hscrollBarOrig.Value;
            hscrollXOutp.value =    hscrollBarX.Value;
        }
    }
}
