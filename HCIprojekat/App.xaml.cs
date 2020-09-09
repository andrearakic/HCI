﻿using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Globalization;
using System.Windows.Markup;

namespace HCIprojekat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Member variables
        public static App Instance;
        public static String Directory;
        public event EventHandler LanguageChangedEvent;
        private String _DefaultStyle = "WhiteStyle.xaml";
        #endregion

        #region Constructor
        public App()
        {
            // Initialize static variables
            Instance = this;
            Directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            // Load the Localization Resource Dictionary based on OS language
            SetLanguageResourceDictionary(GetLocXAMLFilePath(CultureInfo.CurrentCulture.Name));

            string stringsFile = Path.Combine(Directory, "Styles", _DefaultStyle);
            LoadStyleDictionaryFromFile(stringsFile);
        }

        #endregion

        #region Functions
        /// <summary>
        /// Dynamically load a Localization ResourceDictionary from a file
        /// </summary>
        public void SwitchLanguage(string inFiveCharLang)
        {
            if (CultureInfo.CurrentCulture.Name.Equals(inFiveCharLang))
                return;

            var ci = new CultureInfo(inFiveCharLang);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            SetLanguageResourceDictionary(GetLocXAMLFilePath(inFiveCharLang));
            if (null != LanguageChangedEvent)
            {
                LanguageChangedEvent(this, new EventArgs());
            }
        }

        /// <summary>
        /// Returns the path to the ResourceDictionary file based on the language character string.
        /// </summary>
        /// <param name="inFiveCharLang"></param>
        /// <returns></returns>
        private string GetLocXAMLFilePath(string inFiveCharLang)
        {
            string locXamlFile = "LocalizationDictionary." + inFiveCharLang + ".xaml";
            return Path.Combine(Directory, inFiveCharLang, locXamlFile);
        }

        /// <summary>
        /// Sets or replaces the ResourceDictionary by dynamically loading
        /// a Localization ResourceDictionary from the file path passed in.
        /// </summary>
        /// <param name="inFile"></param>
        private void SetLanguageResourceDictionary(String inFile)
        {
            if (File.Exists(inFile))
            {
                // Read in ResourceDictionary File
                var languageDictionary = new ResourceDictionary();
                languageDictionary.Source = new Uri(inFile);

                // Remove any previous Localization dictionaries loaded
                int langDictId = -1;
                for (int i = 0; i < Resources.MergedDictionaries.Count; i++)
                {
                    var md = Resources.MergedDictionaries[i];
                    // Make sure your Localization ResourceDictionarys have the ResourceDictionaryName
                    // key and that it is set to a value starting with "Loc-".
                    if (md.Contains("ResourceDictionaryName"))
                    {
                        if (md["ResourceDictionaryName"].ToString().StartsWith("Loc-"))
                        {
                            langDictId = i;
                            break;
                        }
                    }
                }
                if (langDictId == -1)
                {
                    // Add in newly loaded Resource Dictionary
                    Resources.MergedDictionaries.Add(languageDictionary);
                }
                else
                {
                    // Replace the current langage dictionary with the new one
                    Resources.MergedDictionaries[langDictId] = languageDictionary;
                }
            }
        }
        #endregion

        /// <summary>
        /// This funtion loads a ResourceDictionary from a file at runtime
        /// </summary>
        public void LoadStyleDictionaryFromFile(string inFileName)
        {
            if (File.Exists(inFileName))
            {
                try
                {
                    using (var fs = new FileStream(inFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        // Read in ResourceDictionary File
                        var dic = (ResourceDictionary)XamlReader.Load(fs);
                        // Clear any previous dictionaries loaded
                        Resources.MergedDictionaries.Clear();
                        // Add in newly loaded Resource Dictionary
                        Resources.MergedDictionaries.Add(dic);
                    }
                }
                catch
                {
                }
            }
        }
    }
}


