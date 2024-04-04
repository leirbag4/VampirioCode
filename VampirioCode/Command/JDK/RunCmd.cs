using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.JDK.Result;

namespace VampirioCode.Command.JDK
{
    
    // https://docs.oracle.com/en/java/javase/17/docs/specs/man/java.html

    public class RunCmd : BaseCmd
    {
        //---------------------------------------------------------------
        //---------------------------------------------------------------
        //---                      OPTIONS                            ---
        //---------------------------------------------------------------
        //---------------------------------------------------------------

        /// <summary>
        /// A semicolon (;) separated list of directories, JAR archives, and ZIP archives to search for class files.
        /// Specifying classpath overrides any setting of the CLASSPATH environment variable. If the class path option isn't used and classpath isn't set, then the user class path consists of the current directory 
        /// As a special convenience, a class path element that contains a base name of an asterisk (*) is considered equivalent to specifying a list of all the files in the directory with the extension .jar or .JAR . A Java program can't tell the difference between the two invocations. For example, if the directory mydir contains a.jar and b.JAR, then the class path element mydir/* is expanded to A.jar:b.JAR, except that the order of JAR files is unspecified. All .jar files in the specified directory, even hidden ones, are included in the list. A class path entry consisting of an asterisk (*) expands to a list of all the jar files in the current directory. The CLASSPATH environment variable, where defined, is similarly expanded. Any class path wildcard expansion that occurs before the Java VM is started. Java programs never see wildcards that aren't expanded except by querying the environment, such as by calling System.getenv("CLASSPATH").
        /// </summary>
        public List<string> ClassPath { get; set; } = new List<string>();


        //---------------------------------------------------------------
        //---------------------------------------------------------------
        //---                      FileName                           ---
        //---------------------------------------------------------------
        //---------------------------------------------------------------

        /// <summary>
        /// Can be a Main Class or a .Jar file
        /// </summary>
        public string Filename { get; set; } = "";
        /// <summary>
        /// To launch the main class in a JAR file
        /// </summary>
        public bool Jar { get; set; } = false;
        /// <summary>
        /// To launch the main class in a module
        /// </summary>
        public bool Module { get; set; } = false;

        public async Task<RunResult> RunAsync()
        {
            LogParams = false;

            SetClassPath("-classpath", ClassPath);
            Set("-jar", Jar);
            Set("-m",   Module);
            SetIfExists(Filename);

            return await CreateCommand<RunResult>(_quotes(Java.ProgramPath), cmd.Trim());
        }

        private void SetClassPath(string commandName, List<string> paths)
        {
            string pathSeparator;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
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
            Println(data);
        }

        protected override void OnErrorDataReceived(string data)
        {
            PrintError("err: " + data);
        }

        protected override void OnComplete(BaseResult result)
        {
            //Println("[complete]");
        }
    }
}
