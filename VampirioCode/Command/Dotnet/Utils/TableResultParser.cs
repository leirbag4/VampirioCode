using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.IO;
using static System.Windows.Forms.AxHost;

namespace VampirioCode.Command.Dotnet.Utils
{
    public class TableResultRow
    {
        public string[] Items;
    }

    public class TableResultParser
    {
        public bool Error { get; set; } = false;
        public ErrorInfo ErrorInfo { get; set; }
        public List<TableResultRow> Rows { get; set; }

        private int state = 0;
        private int[] columnWidth;
        private int _spacesSeparation = 2;

        public void Parse(List<string> data)
        {
            Parse(data.ToArray());
        }

        public void Parse(string[] data)
        {
            Rows = new List<TableResultRow>();
            state = 0;

            foreach (var line in data) 
            {
                ReadLine(line);
            }
        }


        /*
         [ TABLE EXAMPLE ] 
         
         Template Name       Short Name                        Author          Language  Type              Tags           Package Name / Owners                                                     Trusted  Downloads
        ------------------  --------------------------------  --------------  --------  ----------------  -------------  ------------------------------------------------------------------------  -------  ---------
        BLiP Console (....  blip-console                      take            [C#]      project           Console/Bots   Take.Blip.Client.Templates / takenet                                                  695k
        Console Applica...  console                                           Q#        project           Common/Con...  Microsoft.Quantum.ProjectTemplates / Microsoft, QuantumEngineering           V        100k
        XrmFramework Co...  xrmConsoleProject                 Christophe ...  [C#]      project           Common/Con...  XrmFramework.Templates / cgoconseils                                                  57k
        Wasi Console App    wasiconsole                       Microsoft       [C#]      project           Wasi/WasiC...  Microsoft.NET.Runtime.WebAssembly.Templates / dotnetframework, Microsoft     V        51k
        WebAssembly Con...  wasmconsole                       Microsoft       [C#]      project           Web/WebAss...  Microsoft.NET.Runtime.WebAssembly.Templates / dotnetframework, Microsoft     V        51k
        [       item0   ][*][           item1             ][*][    item2  ][*][  i3  ][*][..
        
        [*] -> 2 spaces always
        
         */
        private void ReadLine(string data) 
        {
            try
            {
                // [ TITLES ]
                // Wait until any divider line (----) appear and count columns
                // example:
                //         Template Name       Short Name     Author     Language
                //         -------------       ----------     ------     --------
                if (state == 0)
                {
                    // find a minimum amout of continuous line '----'
                    if (data.IndexOf("----") != -1)
                    {
                        string[] arr = data.Split(new[] { "  " }, StringSplitOptions.RemoveEmptyEntries);
                        columnWidth = new int[arr.Length];

                        // count characters per column and assign them as column width
                        for (int a = 0; a < columnWidth.Length; a++)
                        {
                            // count characters line -> '--------' and add 2 spaces which divides lines
                            columnWidth[a] = arr[a].Length + _spacesSeparation; // _spacesSeparation = 2
                        }

                        state = 1;
                    }
                }
                else if (state == 1)
                {
                    // [END of DATA]
                    // An empty line or an space symbol appear as first char
                    if ((data.Length <= 0) || (data[0] == ' '))
                    {
                        state = 2;
                    }
                    // [READ DATA]
                    // example:
                    //         [ Console Application       console       C#        project ]
                    else
                    {
                        //string[] dataArr = new string[columnWidth.Length];
                        int startChar = 0;
                        TableResultRow row = new TableResultRow();
                        row.Items = new string[columnWidth.Length];


                        for (int a = 0; a < row.Items.Length; a++)
                        {
                            int colWidth = columnWidth[a];

                            if (a == (row.Items.Length - 1))
                                row.Items[a] = data.Substring(startChar).Trim();
                            else
                                row.Items[a] = data.Substring(startChar, colWidth).Trim();

                            startChar += colWidth;

                        }

                        Rows.Add(row);

                    }
                }
            }
            catch (Exception e)
            {
                Error =     true;
                ErrorInfo = ErrorInfo.Create("Can't parse item", e);
            }
        }

    }
}
