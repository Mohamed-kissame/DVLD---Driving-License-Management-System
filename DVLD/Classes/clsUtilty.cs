using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace DVLD.Classes
{
    public class clsUtilty
    {

        public static string GenerateGuide()
        {
            Guid guid = Guid.NewGuid();

            return guid.ToString();
        }

        public static bool CreateFolderIfDosentExist(string FolderPath)
        {

            if (!Directory.Exists(FolderPath))
            {

                try
                {

                    Directory.CreateDirectory(FolderPath);
                    return true;

                }catch(Exception ex)
                {
                    MessageBox.Show("Error To Creat Folder " + ex.Message);
                    return false;
                }

            }

            return true;
        }
        
        public static string ReplaceFileNameWithNewGuid(string sourceFile)
        {

            string Filename = sourceFile;
            FileInfo file = new FileInfo(Filename);
            string extension = file.Extension;

            return GenerateGuide() + extension;

        }

        public static bool CopyImageToFolderManageImage(ref string sourceFile)
        {

            string DestinationFolder = @"C:\DVLD-People-Images\";
            if (!CreateFolderIfDosentExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithNewGuid(sourceFile);

            try
            {

                File.Copy(sourceFile, destinationFile, true);
            }
            catch(IOException iox)
            {

                MessageBox.Show(iox.Message, "Error");
                return false;
            }

            sourceFile = destinationFile;

            return true;
        }
    }
}
