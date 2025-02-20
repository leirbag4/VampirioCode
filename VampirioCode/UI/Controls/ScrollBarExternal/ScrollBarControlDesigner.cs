﻿namespace VampirioCode.UI.Controls.ScrollBarExternal
{
   using System.ComponentModel;
   using System.Windows.Forms.Design;

   /// <summary>
   /// The designer for the <see cref="ScrollBarExternal"/> control.
   /// </summary>
   internal class ScrollBarControlDesigner : ControlDesigner
   {
      /// <summary>
      /// Gets the <see cref="SelectionRules"/> for the control.
      /// </summary>
      public override SelectionRules SelectionRules
      {
         get
         {
            // gets the property descriptor for the property "Orientation"
            PropertyDescriptor propDescriptor =
               TypeDescriptor.GetProperties(this.Component)["Orientation"];

            // if not null - we can read the current orientation of the scroll bar
            if (propDescriptor != null)
            {
               // get the current orientation
               ScrollBarOrientation orientation =
                  (ScrollBarOrientation) propDescriptor.GetValue(this.Component);

               // if vertical orientation
               if (orientation == ScrollBarOrientation.Vertical)
               {
                  return SelectionRules.Visible
                     | SelectionRules.Moveable
                     | SelectionRules.BottomSizeable
                     | SelectionRules.TopSizeable;
               }

               return SelectionRules.Visible | SelectionRules.Moveable
                  | SelectionRules.LeftSizeable | SelectionRules.RightSizeable;
            }

            return base.SelectionRules;
         }
      }

      /// <summary>
      /// Prefilters the properties so that unnecessary properties are hidden
      /// in the property browser of Visual Studio.
      /// </summary>
      /// <param name="properties">The property dictionary.</param>
      protected override void PreFilterProperties(
         System.Collections.IDictionary properties)
      {
         properties.Remove("Text");
         properties.Remove("BackgroundImage");
         properties.Remove("ForeColor");
         properties.Remove("ImeMode");
         properties.Remove("Padding");
         properties.Remove("BackgroundImageLayout");
         properties.Remove("BackColor");
         properties.Remove("Font");
         properties.Remove("RightToLeft");

         base.PreFilterProperties(properties);
      }
   }
}
