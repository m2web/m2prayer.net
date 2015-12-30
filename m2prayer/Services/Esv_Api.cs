using System.IO;
using System.Net;
using System.Text;

namespace m2prayer.Services
{
    public interface IEsvApi
    {
        string GetVerse(string verseReference);
        string GetDailyVerse();
    }

    public class EsvApi : IEsvApi
    {

        private static string ApiKey
        {
            get { return "687d2878725c2801"; }
        }

        private static string[] VerseOptions
        {
            get
            {
                string[] verseOptions =
                {
                    "include-short-copyright=0",
                    "include-passage-horizontal-lines=0",
                    "include-heading-horizontal-lines=0",
                    "include-footnotes=false",
                    "include-short-copyright=false",
                    "include-subheadings=false",
                    "include-headings=false",
                    "include-content-type=false"
                };
                return verseOptions;
            }
        }

        public string GetVerse(string verseReference)
        {
            var sUrl = new StringBuilder();
            sUrl.Append("http://www.esvapi.org/v2/rest/passageQuery");
            sUrl.Append("?key=" + ApiKey);
            sUrl.Append("&passage=" + System.Web.HttpUtility.UrlEncode(verseReference));

            var verseOptions = VerseOptions;

            sUrl.Append(string.Join("&", verseOptions));

            WebRequest oReq = WebRequest.Create(sUrl.ToString());
            StreamReader sStream = new StreamReader(oReq.GetResponse().GetResponseStream());

            StringBuilder sOut = new StringBuilder();
            sOut.Append(sStream.ReadToEnd());
            sStream.Close();

            return sOut.ToString();
        }

        public string GetDailyVerse()
        {
            var sUrl = new StringBuilder();
            sUrl.Append("http://www.esvapi.org/v2/rest/dailyVerse");
            sUrl.Append("?key=" + ApiKey + "&");

            sUrl.Append(string.Join("&", VerseOptions));

            WebRequest oReq = WebRequest.Create(sUrl.ToString());
            StreamReader sStream = new StreamReader(oReq.GetResponse().GetResponseStream());

            StringBuilder sOut = new StringBuilder();
            sOut.Append(sStream.ReadToEnd());
            sStream.Close();

            return sOut.ToString();
        }
    }
}