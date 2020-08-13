using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
   public class FileCommon
    {
        /// <summary>
        /// Existses the specified p file path.
        /// </summary>
        /// <param name="pFilePath">The p file path.</param>
        /// <returns></returns>
        public static bool Exists(string pFilePath)
        {
            return File.Exists(pFilePath);
        }

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Array of byte</returns>
        public static byte[] ReadFileToByte(string fileName)
        {
            byte[] buffer = null;

            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }

            return buffer;
        }

        /// <summary>
        /// Writes the byte array to file.
        /// </summary>
        /// <param name="buff">The buff.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static void WriteByteToFile(byte[] buff, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(buff);

            bw.Close();
        }


        /// <summary>
        /// Creates the folder.
        /// </summary>
        /// <param name="pPath">The p app path.</param>
        public static void CreateFolder(string pPath)
        {
            if (!Directory.Exists(pPath))
            {
                Directory.CreateDirectory(pPath);
            }
        }

        /// <summary>
        /// Deletes the folder.
        /// </summary>
        /// <param name="pPath">The p path.</param>
        public static void DeleteFolder(string pPath)
        {
            if (Directory.Exists(pPath))
            {
                Directory.Delete(pPath, true);
            }
        }

        /// <summary>
        /// Determines whether [is file open or read only] [the specified file name].
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>
        /// 	<c>true</c> if [is file open or read only] [the specified file name]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFileOpenOrReadOnly(string fileName)
        {
            try
            {
                // Check if file is not existed
                if (!File.Exists(fileName))
                {
                    return false;
                }

                // First make sure it's not a read only file
                if ((File.GetAttributes(fileName) & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
                {
                    // First we open the file with a FileStream
                    using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None))
                    {
                        try
                        {
                            stream.ReadByte();
                            return false;
                        }
                        catch (IOException)
                        {
                            return true;
                        }
                        finally
                        {
                            stream.Close();
                            stream.Dispose();
                        }
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (IOException)
            {
                return true;
            }
        }
    }
}
