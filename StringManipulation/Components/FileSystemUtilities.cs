using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace StringManipulation.Components
{
    public class FileSystemUtilities
    {
        // Copy the specified Sourcefile from the source file location to the destination file location
        public static void FileCopy(string sourceFileLocation, string destinationFileLocation, string sourceFileName)
        {
            File.Copy(
                Path.Combine(sourceFileLocation, sourceFileName), Path.Combine(destinationFileLocation, sourceFileName),
                true);
        }

        // Retrieving the files collection from the specified directory
        public static List<string> GetFiles(string sourceFolder)
        {
            string[] fileArray = Directory.GetFiles(sourceFolder);
            List<string> filelist = fileArray.ToList();

            return filelist;
        }

// Retrieving the files collection from the specified directory
        public static List<string> GetFilesNoPath(string sourceFolder)
        {
            List<string> filelist = GetFiles(sourceFolder);

            List<string> fileNoPathList = new List<string>();
            foreach (var file in filelist)
            {
                fileNoPathList.Add(GetFileName(file));
            }

            return fileNoPathList;
        }

        // Retrieving the sub directory collection from the specified directory
        public static string[] ListDirectories(string sourceFolder)
        {
            string[] directoryList = Directory.GetDirectories(sourceFolder);
            return directoryList;
        }

        // Retrieving the file name of a specified file with its location
        public static string GetFileName(string fileLocation)
        {
            return Path.GetFileName(fileLocation);
        }

        // Move the specified Sourcefile from the source file location to the destination file location
        public static void FileMove(string sourceFileLocation, string destinationFileLocation, string sourceFileName,
            string destinationFileName)
        {
            var user = System.Security.Principal.WindowsIdentity.GetCurrent();
            var name = user == null ? string.Empty : user.Name;

            File.Move(Path.Combine(sourceFileLocation, sourceFileName),
                Path.Combine(destinationFileLocation, destinationFileName));
        }

        // Checking the specified direcotry exisits
        public static bool DirectoryExists(string directoryLocation)
        {
            if (Directory.Exists(directoryLocation))
            {
                return true;
            }

            return false;
        }

        // Creating the specified direcotry 
        public static void CreateDirectory(string directoryLocation)
        {
            Directory.CreateDirectory(directoryLocation);
        }

        // Delete the specified directory 
        public static void DeleteDirectory(string directoryLocation, bool deleteAllContents)
        {
            if (deleteAllContents)
            {
                Directory.Delete(directoryLocation, true);
            }
            else
            {
                Directory.Delete(directoryLocation);
            }
        }

        // Read the file into a string
        public static string ReadFileToString(string fileNameToRead)
        {
            string text = System.IO.File.ReadAllText(fileNameToRead);
            return text;
        }
    }
}

