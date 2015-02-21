using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Social_Media_Service_Panel.Helper
{
    public class FileHelper
    {
        public static String ReadStringFromTextfile(string filepath)
        {
            StreamReader reader = new StreamReader(filepath);
            string fileText = reader.ReadToEnd();
            reader.Close();
            return fileText;
        }

        public static void AppendStringToTextfileNewLine(String content, string filepath)
        {

            StreamWriter writer = new StreamWriter(filepath, true);

            StringReader reader = new StringReader(content);

            string temptext = "";

            while ((temptext = reader.ReadLine()) != null)
            {
                writer.WriteLine(temptext);
            }

            writer.Close();
        }
    }
}