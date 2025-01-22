using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.IO;
using VampirioCode.UI;
using VampirioCode.UI.Controls;

namespace VampirioCode.Hardcode
{
    // 
    // This class fixes all Visual Studio Design problems!!!
    // It's not what I like but...
    //
    public class HARDCODE_FIXER
    {

        public static void XCONSOLE_FIX_CLOSE_BTN(XConsole xconsole, ButtonAdv clearButton)
        {
            if (Display.Scale == 100)
            {
                clearButton.Location = new Point(xconsole.Width - 90, 0);
                clearButton.Height = 23;
            }
            else if (Display.Scale == 125)
            {
                clearButton.Location = new Point(xconsole.Width - 350, 0);
                clearButton.Height = 23;
            }
            else if (Display.Scale == 150)
            {
                clearButton.Location = new Point(xconsole.Width - 1430, 0);
                clearButton.Height = 23;
            }
        }

        public static void XCONSOLE_FIX_LOCATION_AND_SIZE(App app, XConsole xconsole, SplitContainer splitContainer)
        {
            if (Display.Scale == 125)
            {
                xconsole.Location = new Point(0, 0);
                xconsole.Width = app.Width + 250;
                xconsole.Height = splitContainer.Panel2.Height + 130;
            }
            else if (Display.Scale == 150)
            {
                xconsole.Location = new Point(0, 0);
                xconsole.Width = app.Width + 1300;
                xconsole.Height = splitContainer.Panel2.Height + 600;
            }
            else
            {
                xconsole.Location = new Point(0, 0);
                xconsole.Width = app.Width;
                xconsole.Height = splitContainer.Panel2.Height;
            }
        }

        public static int MAIN_TABS_FIX_HEIGHT()
        {
            int defaultTabHeight = 22;

            Display.Initialize();

            if (Display.Scale < 125)
                defaultTabHeight = 26;

            return defaultTabHeight;
        }

        public static void CPP_SETTINGS_MSVC(UserControl includeDirsList, UserControl libraryDirsList, UserControl libraryFilesList, UserControl sourceFilesList, UserControl itemListPackages, UserControl macrosList, UserControl postCopyDirsList, UserControl postCopyFilesList)
        {
	        int w0 = 28;
	        int w1 = 25;

            if(Display.Scale >= 125)
            { 
	            includeDirsList.Width += 	w0;
	            libraryDirsList.Width += 	w0;
	            libraryFilesList.Width += 	w0;
	            sourceFilesList.Width += 	w0;
	            itemListPackages.Width += 	w1;
	            macrosList.Width += 		w0;
	            postCopyDirsList.Width += 	w0;
	            postCopyFilesList.Width += 	w0;
            }
        }

        public static void CPP_SETTINGS_GNU_GPP(UserControl includeDirsList, UserControl libraryDirsList, UserControl libraryFilesList, UserControl sourceFilesList, UserControl itemListPackages, UserControl macrosList, UserControl postCopyDirsList, UserControl postCopyFilesList)
        {
	        int w0 = 28;
	        int w1 = 25;

            if(Display.Scale >= 125)
            { 
	            includeDirsList.Width += 	w0;
	            libraryDirsList.Width += 	w0;
	            libraryFilesList.Width += 	w0;
	            sourceFilesList.Width += 	w0;
	            itemListPackages.Width += 	w1;
	            macrosList.Width += 		w0;
	            postCopyDirsList.Width += 	w0;
	            postCopyFilesList.Width += 	w0;
            }
        }

    }
}
