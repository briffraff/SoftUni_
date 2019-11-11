using System;
using System.IO;

namespace copyBinaryFile
{
    class copyBinaryFile
    {
        static void Main(string[] args)
        {
            string path = "../../04. Streams-Exercise";
            string fileName = "copyMe.png";
            string pathCombo = Path.Combine(path, fileName);

            string fileNameCopy = "copyMe-copy.png";
            string pathComboCopy = Path.Combine(path, fileNameCopy);

            using (FileStream reader = new FileStream(pathCombo, FileMode.Open))
            {
                var size = reader.Length;
                byte[] buffer = new byte[size];
                reader.Read(buffer, 0, buffer.Length);

                using (FileStream writer = new FileStream(pathComboCopy, FileMode.Create))
                {
                    writer.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
