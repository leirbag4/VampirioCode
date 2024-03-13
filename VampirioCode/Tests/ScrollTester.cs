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
            hscrollBar.Minimum = (int)minimumInput.value;
            hscrollBar.Maximum = (int)maximumInput.value;
            hscrollBar.SmallChange = (int)smallChangeInput.value;
            hscrollBar.LargeChange = (int)largeChangeInput.value;

            hscrollBarOrig.Minimum = (int)minimumInput.value;
            hscrollBarOrig.Maximum = (int)maximumInput.value;
            hscrollBarOrig.SmallChange = (int)smallChangeInput.value;
            hscrollBarOrig.LargeChange = (int)largeChangeInput.value;
        }

        private void OnHScrollChanged(object sender, ScrollEventArgs e)
        {
            hscrollOutp.value = hscrollBar.Value;
        }

        private void OnHScrollOrigChanged(object sender, ScrollEventArgs e)
        {
            hscrollOrigOutp.value = hscrollBarOrig.Value;
        }
    }
}
