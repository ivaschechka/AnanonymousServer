using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AnanonymousServer.Models
{
    public static class FileWorker
    {
        private static string token = "swHMsrLwHtNN5Wr0lGzq";
        private const string StartPath = "Data\\";

        public static string Format(Info data)
        {
            var directory = StartPath + data.Path.Replace('.', '\\');
            Directory.CreateDirectory(directory);
            var path = $"{directory}\\{data.Name}.b";
            return path;
        }

        public static bool Check(string path, string idRow)
        {
            try
            {
                using (var sr = new StreamReader(path, Encoding.Default))
                {
                    var text = sr.ReadToEnd();
                    return text.Contains(idRow);

                }
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }

        public static string Write(string path, string data)
        {
            string idRow;
            for (var i = 0; ; i++)
            {
                idRow = Crypto.GetMd5Hash($"{i}{token}");

                if (!Check(path, idRow))
                    break;
            }
            try
            {
                using (var sw = new StreamWriter(path, true, Encoding.Default))
                {
                    sw.WriteAsync($"{idRow};{data}\n");

                }

            }
            catch (FileNotFoundException)
            {
            }
            return idRow;
        }

        public static List<string> Read(string path)
        {
            var dataList = new List<string>();
            try
            {
                using (var sr = new StreamReader(path, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var lineData = line.Split(';');
                        dataList.Add(lineData[(int)Description.Data]);
                    }
                }
                if (dataList.Count > 0)
                {
                    using (var sw = new StreamWriter(path, false, Encoding.Default))
                    {

                    }
                }
            }
            catch (FileNotFoundException)
            {

            }

            return dataList;
        }
    }
}
