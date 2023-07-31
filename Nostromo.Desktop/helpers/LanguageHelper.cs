using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Xml.Linq;

namespace Nostromo.Desktop.helpers
{
    public class LanguageHelper
    {
        public const string KEY_NOT_FOUND = "Key not found";

        private XDocument _translations;

        #region Constructors
        public LanguageHelper(LANGUAGE lang)
        {
            string resourcesFileFullNane = string.Empty;

            switch (lang)
            {
                case LANGUAGE.SPANISH:
                    resourcesFileFullNane = @".\resources\language\language_ES.resx";
                    break;
                default:
                    resourcesFileFullNane = @".\resources\language\language_EN.resx";
                    break;
            }

            _translations = XDocument.Load(resourcesFileFullNane); // @"resources\languages\es-ES.resx");
        }
        #endregion


        public string Translate(string key)
        {
            var result = KEY_NOT_FOUND;

            if (_translations != null)
            {
                var data = _translations.Descendants().FirstOrDefault(x => x.Attributes().Any(a => a.Value == key))?.Value;
                if (data != null)
                {
                    data = data?.Replace(@"\n", string.Empty);
                    data = data?.Trim();
                    result = data;
                }
            }

            return result;
        }
    }
}
