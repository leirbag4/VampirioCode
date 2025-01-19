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

        public static string[] GetDirectoryNamesAt(string path)
        {
            // Retrieves all directories at the specified path
            return Directory.GetDirectories(path)
                            .Select(Path.GetFileName)
                            .ToArray();
        }

        public static bool MoveDirectoryContents(string fromPath, string toPath)
        {
            return CopyDirectoryContents(fromPath, toPath, true, true);
        }

        public static bool CopyDirectoryContents(string fromPath, string toPath, bool recursive = true, bool deleteSource = false)
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
                        CopyDirectoryContents(subdir.FullName, tempPath, recursive);
                    }
                }

                // If deleteSource is true, delete the contents of the source directory
                if (deleteSource)
                {
                    DeleteDirectoryContents(fromPath);
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

        public static void DeleteDirectoryContents(string directoryPath)
        {
            try
            {
                // Delete all files in the directory
                foreach (var file in Directory.GetFiles(directoryPath))
                {
                    File.Delete(file);
                }

                // Delete all subdirectories in the directory
                foreach (var subdirectory in Directory.GetDirectories(directoryPath))
                {
                    Directory.Delete(subdirectory, true); // Delete recursively
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting contents: {ex.Message}");
            }
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

        /// <summary>
        /// Copy a directory and its content filtering by extension
        /// </summary>
        /// <param name="fromPath">Like 'C:\\test2\\source'</param>
        /// <param name="toPath">Like 'C:\\test2\\destination'</param>
        /// <param name="includeExtensions">Like {'.cpp', '.h', '.inc'} </param>
        /// <param name="dontIncludeRelativeFiles">Like 'main.cpp' and 'C:\\test2\\source\\main.cpp' won't be copyed</param>
        /// <param name="recursive">Recursive mode directory by directory</param>
        /// <returns>true if copyed done</returns>
        public static async Task<bool> CopyDirectoryAdvAsync(string fromPath, string toPath, string[] includeExtensions = null, string[] dontIncludeRelativeFiles = null, bool recursive = true, bool deleteFromOrigin = false)
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

                // Normalize 'dontCopyRelativeFiles' to use correct directory separator
                if (dontIncludeRelativeFiles != null)
                {
                    for (int i = 0; i < dontIncludeRelativeFiles.Length; i++)
                    {
                        dontIncludeRelativeFiles[i] = dontIncludeRelativeFiles[i].Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
                    }
                }

                // Copy all the files from the source directory to the destination
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    // Skip files that are in the dontCopyRelativeFiles array
                    string relativeFilePath = Path.GetRelativePath(fromPath, file.FullName);
                    if (dontIncludeRelativeFiles != null && dontIncludeRelativeFiles.Contains(relativeFilePath))
                    {
                        continue; // Skip this file
                    }

                    // Skip files that do not match the includeExtensions array
                    if (includeExtensions != null && !includeExtensions.Contains(file.Extension, StringComparer.OrdinalIgnoreCase))
                    {
                        continue; // Skip this file
                    }

                    // Build the destination file path and copy the file
                    string tempPath = Path.Combine(toPath, file.Name);

                    if(deleteFromOrigin)
                        await Task.Run(() => file.MoveTo(tempPath, true)); // Overwrite if exists
                    else
                        await Task.Run(() => file.CopyTo(tempPath, true)); // Overwrite if exists
                }

                // If specified, copy the subdirectories and their contents recursively
                if (recursive)
                {
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string tempPath = Path.Combine(toPath, subdir.Name);
                        await CopyDirectoryAdvAsync(subdir.FullName, tempPath, includeExtensions, dontIncludeRelativeFiles, recursive);
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

        public static List<string> GetFilesAdv(string fromPath, string[] includeExtensions = null, string[] dontIncludeRelativeFiles = null, bool recursive = true, bool fullPath = false)
        { 
            return GetFilesAdvAsync(fromPath, includeExtensions, dontIncludeRelativeFiles, recursive, fullPath).GetAwaiter().GetResult();
        }

        public static async Task<List<string>> GetFilesAdvAsync(string fromPath, string[] includeExtensions = null, string[] dontIncludeRelativeFiles = null, bool recursive = true, bool fullPath = false, bool excludeVampDir = false)
        {
            List<string> resultFiles = new List<string>();

            try
            {
                // Get information about the source directory
                DirectoryInfo dir = new DirectoryInfo(fromPath);

                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException($"Source directory does not exist: {fromPath}");
                }

                // Skip this directory if it's or is within a "_vamp" folder
                if (excludeVampDir && IsVampDirectory(dir))
                {
                    return resultFiles;
                }

                // Normalize 'dontCopyRelativeFiles' to use correct directory separator
                if (dontIncludeRelativeFiles != null)
                {
                    for (int i = 0; i < dontIncludeRelativeFiles.Length; i++)
                    {
                        dontIncludeRelativeFiles[i] = dontIncludeRelativeFiles[i].Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
                    }
                }

                // Get all the files from the current directory
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    // Get the relative path of the file
                    string relativeFilePath = Path.GetRelativePath(fromPath, file.FullName);
                    string fullFilePath = file.FullName;

                    // Skip files listed in 'dontCopyRelativeFiles'
                    if (dontIncludeRelativeFiles != null && dontIncludeRelativeFiles.Contains(relativeFilePath))
                    {
                        continue;
                    }

                    // Skip files if their extensions are not in 'includeExtensions'
                    if (includeExtensions != null && !includeExtensions.Contains(file.Extension, StringComparer.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (fullPath)
                    {
                        resultFiles.Add(fullFilePath);
                    }
                    else
                    {
                        // Add the relative path to the result
                        resultFiles.Add(relativeFilePath);
                    }
                }

                // If recursive is true, process subdirectories
                if (recursive)
                {
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        // Recursively get files from subdirectories
                        List<string> subDirFiles = await GetFilesAdvAsync(subdir.FullName, includeExtensions, dontIncludeRelativeFiles, recursive, fullPath);

                        // Add the relative paths of subdirectory files
                        resultFiles.AddRange(subDirFiles.Select(subDirFile => Path.Combine(subdir.Name, subDirFile)));
                    }
                }

                return resultFiles;
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

            return resultFiles;
        }

        // Helper method to determine if a directory is or is within a "_vamp" folder
        private static bool IsVampDirectory(DirectoryInfo dir)
        {
            while (dir != null)
            {
                if (dir.Name.Equals(AppInfo.VampTempDir, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                dir = dir.Parent;
            }
            return false;
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

        public static async Task CopyFileAsync2(string sourceFile, string destinationFile, CancellationToken cancellationToken = default)
        {
            var fileOptions = FileOptions.Asynchronous | FileOptions.SequentialScan;
            var bufferSize = 4096;

            using (var sourceStream =
                  new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, fileOptions))

            using (var destinationStream =
                  new FileStream(destinationFile, FileMode.CreateNew, FileAccess.Write, FileShare.None, bufferSize, fileOptions))

                await sourceStream.CopyToAsync(destinationStream, bufferSize, cancellationToken)
                                  .ConfigureAwait(false);
        }

        public static async Task CopyFileWithDirsAsync(string sourceFilePath, string destinationFilePath)
        {
            // check if directory exists. If not, creates one
            string destinationDirectory = Path.GetDirectoryName(destinationFilePath);
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            // Open files in async mode to read and write
            using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
            {
                await sourceStream.CopyToAsync(destinationStream);
            }
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
