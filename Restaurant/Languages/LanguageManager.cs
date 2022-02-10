using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Languages
{
    public class LanguageManager
    {
        public static List<Languages> AvailableLanguages =
            new List<Languages>()
            {
                new Languages
                {
                    LanguageName = "English",
                    LanguageCultureName = "en"
                },
                new Languages
                {
                    LanguageName = "Romana",
                    LanguageCultureName = "ro"
                }
            };
    }
    public class Languages
    {
        public string LanguageName { get; set; }
        public string LanguageCultureName { get; set; }
    }
}
