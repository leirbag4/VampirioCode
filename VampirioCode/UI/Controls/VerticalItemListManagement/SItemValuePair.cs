using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.Controls.VerticalItemListManagement.Components;

namespace VampirioCode.UI.Controls.VerticalItemListManagement
{
    public class SItemValuePair : SItem
    {

        public string LeftValue { get { return Text0.Text; } set { Text0.Text = value; } }
        public string RightValue { get { return Text1.Text; } set { Text1.Text = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Division")]
        [Browsable(true)]
        public float Division { get { return _division; } set { SetDivision(value); } }

        private float _division = 0.5f;

        public SItemValuePair() : base()
        {
            type = SItemType.ValuePair;

            Text0.TextAlign = ContentAlignment.MiddleLeft;
            Text0.SetPercents(0.02f, 0.51f, 0.10f, 0.10f);
            Text0.SetBackColors(Color.FromArgb(58, 64, 72), Color.FromArgb(54, 62, 73), Color.FromArgb(60, 65, 71));
            Text0.Truncated = true;
            Text0.StateMode = SItemTextStateMode.OwnBehaviour;

            Text1.TextAlign = ContentAlignment.MiddleLeft;
            Text1.SetPercents(0.51f, 0.02f, 0.10f, 0.10f);
            Text1.SetBackColors(Color.FromArgb(72, 74, 88), Color.FromArgb(73, 76, 94), Color.FromArgb(71, 73, 84));
            Text1.Truncated = true;
            Text1.StateMode = SItemTextStateMode.OwnBehaviour;

            SetDivision(0.5f);
        }

        private void SetDivision(float division)
        { 
            _division = division;

            Text0.RightPercent = 1.0f - _division + 0.01f;
            Text1.LeftPercent =  _division + 0.01f;

            Invalidate();
        }

        
    }
}
