using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IR_BackOffice.Objects
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Methods to remove HTML from strings.
    /// </summary>
    public static class HtmlRemoval
    {
        public static string ScrubHtml(string value)
        {
            var step1 = Regex.Replace(value, @"<[^>]+>
                    |&nbsp;
                    |&quot;
                    |&amp;
                    |&lt;
                    |&gt;
                    |&nbsp;
                    |&iexcl;
                    |&cent;
                    |&pound;
                    |&curren;
                    |&yen;
                    |&brvbar;
                    |&sect;
                    |&uml;
                    |&copy;
                    |&ordf;
                    |&laquo;
                    |&not;
                    |&shy;
                    |&reg;
                    |&macr;
                    |&deg;
                    |&plusmn;
                    |&sup2;
                    |&sup3;
                    |&acute;
                    |&micro;
                    |&para;
                    |&middot;
                    |&cedil;
                    |&sup1;
                    |&ordm;
                    |&raquo;
                    |&frac14;
                    |&frac12;
                    |&frac34;
                    |&iquest;
                    |&Agrave;
                    |&Aacute;
                    |&Acirc;
                    |&Atilde;
                    |&Auml;
                    |&Aring;
                    |&AElig;
                    |&Ccedil;
                    |&Egrave;
                    |&Eacute;
                    |&Ecirc;
                    |&Euml;
                    |&Igrave;
                    |&Iacute;
                    |&Icirc;
                    |&Iuml;
                    |&ETH;
                    |&Ntilde;
                    |&Ograve;
                    |&Oacute;
                    |&Ocirc;
                    |&Otilde;
                    |&Ouml;
                    |&times;
                    |&Oslash;
                    |&Ugrave;
                    |&Uacute;
                    |&Ucirc;
                    |&Uuml;
                    |&Yacute;
                    |&THORN;
                    |&szlig;
                    |&agrave;
                    |&aacute;
                    |&acirc;
                    |&atilde;
                    |&auml;
                    |&aring;
                    |&aelig;
                    |&ccedil;
                    |&egrave;
                    |&eacute;
                    |&ecirc;
                    |&euml;
                    |&igrave;
                    |&iacute;
                    |&icirc;
                    |&iuml;
                    |&eth;
                    |&ntilde;
                    |&ograve;
                    |&oacute;
                    |&ocirc;
                    |&otilde;
                    |&ouml;
                    |&divide;
                    |&oslash;
                    |&ugrave;
                    |&uacute;
                    |&ucirc;
                    |&uuml;
                    |&yacute;
                    |&thorn;
                    |&yuml;
                    |&euro;
                    |&gt;
                    |<p>
                    |</p>
                    ", "").Trim();
            var step2 = Regex.Replace(step1, @"\s{2,}", " ");
            return step2;
        }

        /// <summary>
        /// Remove HTML from string with Regex.
        /// </summary>
        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }

        /// <summary>
        /// Compiled regular expression for performance.
        /// </summary>
        static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

        /// <summary>
        /// Remove HTML from string with compiled Regex.
        /// </summary>
        public static string StripTagsRegexCompiled(string source)
        {
            return _htmlRegex.Replace(source, string.Empty);
        }

        /// <summary>
        /// Remove HTML tags from string using char array.
        /// </summary>
        public static string StripTagsCharArray(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
    }
}