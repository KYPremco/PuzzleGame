using System.IO;
using System.Net;
using System.Text;

namespace PuzzleGame
{
    public static class WebApi
    {
        public static void AddNewLevel(string name, string grid)
        {
            SendPost("http://puzzle.runotrack.com/addLevel.php", string.Format("levelName={0}&levelGrid={1}", name, grid), "application/x-www-form-urlencoded");
        }

        public static string GetAllLevels()
        {
            return SendPost("http://puzzle.runotrack.com/getLevels.php", "levelList", "application/x-www-form-urlencoded");
        }

        public static string GetLevelByName(string name)
        {
            return SendPost("http://puzzle.runotrack.com/loadLevel.php", string.Format("levelName={0}", name), "application/x-www-form-urlencoded");
        }

        private static string SendPost(string uri, string data, string contentType, string method = "POST")
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytes.Length;
            request.ContentType = contentType;
            request.Method = method;

            using (Stream requestBody = request.GetRequestStream())
            {
                requestBody.Write(dataBytes, 0, dataBytes.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static string SendGet(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
