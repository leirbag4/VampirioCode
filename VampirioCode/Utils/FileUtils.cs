using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampDocManager;
using VampirioCode.UI;

namespace VampirioCode.Utils
{
    public class FileUtils
    {
        public static void DeleteFilesAndDirs(string dirPath, string[] except = null)
        {
            if (!Directory.Exists(dirPath))
                return;

            // Normalize all paths 
            if (except != null)
            {
                except = except.Select(path => Path.GetFullPath(path.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar))).ToArray();
            }

            DirectoryInfo di = new DirectoryInfo(dirPath);

            // Delete Files
            foreach (FileInfo file in di.GetFiles())
            {
                string fileFullPath = Path.GetFullPath(file.FullName);

                if (except == null || !except.Contains(fileFullPath, StringComparer.OrdinalIgnoreCase))
                {
                    file.Delete();
                }
            }

            // Delete directories
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                string dirFullPath = Path.GetFullPath(dir.FullName.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));

                if (except == null || !except.Contains(dirFullPath, StringComparer.OrdinalIgnoreCase))
                {
                    dir.Delete(true);
                }
            }
        }
        /*public static void DeleteFilesAndDirs(string dirPath, string[] except = null)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(dirPath);

            foreach (FileInfo file in di.GetFiles())
            {
                if (except == null)
                    file.Delete();
                else
                { 
                    file.FullName
                }
            }

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                if (except == null)
                    dir.Delete(true);
                else
                {
                    dir.FullName
                }
            }
                
        }*/

        public static string[] GetFilesAt(string path)
        {
            return Directory.GetFiles(path);
        }

        public static string[] GetFileNamesAt(string path, bool includeExtension = true)
        {
            if (includeExtension)
            {
                return Directory.GetFiles(path).Select(Path.GetFileName).ToArray();
            }
            else
            {
                return Directory.GetFiles(path)
                        .Select(file => Path.GetFileNameWithoutExtension(file))
                        .ToArray();
            }
        }

        public static bool CopyDirectory(string fromPath, string toPath, bool recursive = true)
        {
            try
            {
                // Get information about the source directory
                DirectoryInfo dir = new DirectoryInfo(fromPath);

                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException($"Source directory does not exist: {fromPath}");
                }

                // Create the destination directory if it doesn't exist
                Directory.CreateDirectory(toPath);

                // Copy all the files from the source directory to the destination
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string tempPath = Path.Combine(toPath, file.Name);
                    file.CopyTo(tempPath, true); // Overwrite if exists
                }

                // If specified, copy the subdirectories and their contents recursively
                if (recursive)
                {
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string tempPath = Path.Combine(toPath, subdir.Name);
                        CopyDirectory(subdir.FullName, tempPath, recursive);
                    }
                }

                return true; // Successfully copied
            }
            catch (DirectoryNotFoundException ex)
            {
                XConsole.PrintError($"Error: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                XConsole.PrintError($"Error: Access denied. {ex.Message}");
            }
            catch (IOException ex)
            {
                XConsole.PrintError($"I/O Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                XConsole.PrintError($"An unexpected error occurred: {ex.Message}");
            }

            return false; // Copy failed
        }

        public static async Task<bool> CopyDirectoryAsync(string fromPath, string toPath, bool recursive = true)
        {
            try
            {
                // Get information about the source directory
                DirectoryInfo dir = new DirectoryInfo(fromPath);

                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException($"Source directory does not exist: {fromPath}");
                }

                // Create the destination directory if it doesn't exist
                Directory.CreateDirectory(toPath);

                // Copy all the files from the source directory to the destination
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string tempPath = Path.Combine(toPath, file.Name);
                    await Task.Run(() => file.CopyTo(tempPath, true)); // Overwrite if exists
                }

                // If specified, copy the subdirectories and their contents recursively
                if (recursive)
                {
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string tempPath = Path.Combine(toPath, subdir.Name);
                        await CopyDirectoryAsync(subdir.FullName, tempPath, recursive);
                    }
                }

                return true; // Successfully copied
            }
            catch (DirectoryNotFoundException ex)
            {
                XConsole.PrintError($"Error: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                XConsole.PrintError($"Error: Access denied. {ex.Message}");
            }
            catch (IOException ex)
            {
                XConsole.PrintError($"I/O Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                XConsole.PrintError($"An unexpected error occurred: {ex.Message}");
            }

            return false; // Copy failed
        }

        public static bool CopyFile(string fromPath, string toPath)
        {
            try
            {
                File.Copy(fromPath, toPath, true); // Overwrite if exists
                return true; // Successfully copied
            }
            catch (FileNotFoundException ex)
            {
                XConsole.PrintError($"Error: Source file not found. {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                XConsole.PrintError($"Error: Access denied. {ex.Message}");
            }
            catch (IOException ex)
            {
                XConsole.PrintError($"I/O Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                XConsole.PrintError($"An unexpected error occurred: {ex.Message}");
            }
            return false; // Copy failed
        }

        public static async Task<bool> CopyFileAsync(string fromPath, string toPath, bool useSameFileName = false)
        {
            // If useSameFileName is true, extract the file name from fromPath and append it to toPath
            if (useSameFileName)
            {
                // Get the file name from the source path
                string fileName = Path.GetFileName(fromPath);

                // Ensure toPath ends with a backslash if it's not a complete file path
                if (!toPath.EndsWith("\\"))
                    toPath += "\\";

                // Concatenate the file name to toPath
                toPath += fileName;
            }

            try
            {
                using (var sourceStream = new FileStream(fromPath, FileMode.Open, FileAccess.Read))
                using (var destinationStream = new FileStream(toPath, FileMode.Create, FileAccess.Write))
                {
                    await sourceStream.CopyToAsync(destinationStream);
                }
                return true; // Successfully copied
            }
            catch (FileNotFoundException ex)
            {
                XConsole.PrintError($"Error: Source file not found. {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                XConsole.Alert($"Error: Access denied. {ex.Message}\nFROM\n{fromPath}\nTO\n{toPath}", true);
            }
            catch (IOException ex)
            {
                XConsole.PrintError($"I/O Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                XConsole.PrintError($"An unexpected error occurred: {ex.Message}");
            }

            return false; // Copy failed
        }

        public static bool IsDirectoryInUse(string directoryPath)
        {
            try
            {
                // Check if the directory exists and try to access its attributes (basic check)
                var dirInfo = new DirectoryInfo(directoryPath);
                var attributes = dirInfo.Attributes; // Accessing attributes can fail if the directory is in use

                // Try to open the files in the directory
                var files = Directory.GetFiles(directoryPath);
                foreach (var file in files)
                {
                    // Attempt to open each file with exclusive access
                    using (FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        // If we successfully open the file, it means it is not in use
                    }
                }

                return false; // Neither the directory nor any files are in use
            }
            catch (IOException)
            {
                // If an IOException is thrown, either the directory or one of the files is in use
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                // Handle cases where there are permission issues accessing the directory or its files
                return true;
            }
        }




        public static string SaveFileDialog()
        { 
            String text;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title =      "Save file as";
            dialog.Filter =     "All Files (*.*)|*.*|Text Files (*.txt)|*.txt";
            dialog.FilterIndex = 1; // set first index

            dialog.ShowDialog();
            return dialog.FileName;
        }

    }
}
