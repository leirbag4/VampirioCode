using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VampEditor.Language;
using VampirioCode.Command.JDK.Params;
using VampirioCode.Command.JDK.Result;
using VampirioCode.Properties;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VampirioCode.Command.JDK
{
    //
    // https://docs.oracle.com/javase/8/docs/technotes/tools/windows/javac.html
    //
    public class BuildCmd : BaseCmd
    {

        //---------------------------------------------------------------
        //---------------------------------------------------------------
        //---                      OPTIONS                            ---
        //---------------------------------------------------------------
        //---------------------------------------------------------------

        /// <summary>
        /// Specifies where to find user class files, and (optionally) annotation processors and source files. This class path overrides the user class path in the CLASSPATH environment variable. If neither CLASSPATH, -cp nor -classpath is specified, then the user class path is the current directory.
        /// </summary>
        public List<string> ClassPath { get; set; } = new List<string>();
        /// <summary>
        /// Sets the destination directory for class files. The directory must already exist because javac does not create it.If a class is part of a package, then javac puts the class file in a subdirectory that reflects the package name and creates directories as needed.
        /// If you specify -d C:\myclasses and the class is called com.mypackage.MyClass, then the class file is C:\myclasses\com\mypackage\MyClass.class.
        /// If the -d option is not specified, then javac puts each class file in the same directory as the source file from which it was generated.
        /// Note: The directory specified by the -d option is not automatically added to your user class path.
        /// </summary>
        public string OutputDir { get; set; } = "";
        /// <summary>
        /// -g  Generates all debugging information, including local variables.By default, only line number and source file information is generated.
        /// -g:none  Does not generate any debugging information.
        /// -g:[keyword list]
        ///     source
        ///         Source file debugging information.
        ///     lines
        ///         Line number debugging information.
        ///     vars
        ///         Local variable debugging information.
        /// </summary>
        public GDebug GDebug { get; set; } = GDebug.DoNotUse;
        /// <summary>
        /// Disables warning messages. This option operates the same as the -Xlint:none option.
        /// </summary>
        public bool NoWarn { get; set; } = false;
        /// <summary>
        /// Stores formal parameter names of constructors and methods in the generated class file so that the method java.lang.reflect.Executable.getParameters from the Reflection API can retrieve them.
        /// </summary>
        public bool Parameters { get; set; } = false;
        /// <summary>
        /// Specifies the version of source code accepted.
        /// </summary>
        public SourceVersion SourceVersion { get; set; } = SourceVersion.None;
        /// <summary>
        /// Uses verbose output, which includes information about each class loaded and each source file compiled.
        /// </summary>
        public bool Verbose { get; set; } = false;
        /// <summary>
        /// Prints release information.
        /// </summary>
        public bool Version { get; set; } = false;
        /// <summary>
        /// Terminates compilation when warnings occur.
        /// </summary>
        public bool WError { get; set; } = false;
        /// <summary>
        /// Displays information about nonstandard options and exits.
        /// </summary>
        public bool X { get; set; } = false;


        //---------------------------------------------------------------
        //---------------------------------------------------------------
        //---                     SOURCE FILES                        ---
        //---------------------------------------------------------------
        //---------------------------------------------------------------

        /// <summary>
        /// One or more source files to be compiled(such as MyClass.java).
        /// </summary>
        public List<string> Sources { get; set; } = new List<string>();


        //---------------------------------------------------------------
        //---------------------------------------------------------------
        //---                      CLASSES                            ---
        //---------------------------------------------------------------
        //---------------------------------------------------------------

        /// <summary>
        /// One or more classes to be processed for annotations(such as MyPackage.MyClass).
        /// </summary>
        public List<string> Classes { get; set; } = new List<string>();



        public async Task<BuildResult> BuildAsync()
        {
            // Options
            SetIfExists("-d",           OutputDir);
            SetClassPath("-classpath",  ClassPath);
            Set(/*-g*/                  GDebugInfo.Get(GDebug), GDebug != GDebug.DoNotUse);
            Set("-nowarn",              NoWarn);
            Set("-parameters",          Parameters);
            SetIfExists("source",       SourceVersionInfo.Get(SourceVersion));
            Set("-verbose",             Verbose);
            Set("-version",             Version);
            Set("-werror",              WError);
            Set("-X",                   X);

            // Source Files
            SetIfExists(Sources);

            // Classes
            SetIfExists(Classes);

            //AutoTriggerErrors = false;
            return await CreateCommand<BuildResult>(_quotes(Javac.ProgramPath), cmd.Trim());
        }

        private void SetClassPath(string commandName, List<string> paths)
        {
            string pathSeparator;

            if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                pathSeparator = ";";
            else // Linux and Mac
                pathSeparator = ":";

            if ((paths != null) && (paths.Count > 0))
            {
                cmd += commandName + " ";

                foreach (string path in paths)
                    cmd += path + pathSeparator;
                
                cmd = cmd.Substring(0, cmd.Length - 1) + " ";
            }
        }

        protected override void OnDataReceived(string data)
        {
            Println("data: " + data);
        }

        protected override void OnErrorDataReceived(string data)
        {
            //PrintError("error: " + data);
        }

        protected override void OnComplete(BaseResult result)
        {
            Println("[complete]");
        }
    }
}
