using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalisationSystem
{
   public enum Language
   {
       English,
       French
   }

   public static Language language = Language.English;

   private static Dictionary<string, string> localisedEN;
   private static Dictionary<string, string> localisedFR;

   public static bool isInit;

   public static void Init()
   {
       Debug.Log("Initalizing the localisation system...");
       CSVLoader csvLoader = new CSVLoader();
       csvLoader.LoadCSV();

       localisedEN = csvLoader.GetDictionaryValues("en");
       localisedFR = csvLoader.GetDictionaryValues("fr");

       isInit = true;
       Debug.Log("Loaded the values for the localisation system.");
   }

   public static string GetLocalisedValue(string key)
   {
       if (!isInit) { Init(); }

       string value = key;

       switch (language)
       {
            case Language.English:
                localisedEN.TryGetValue(key, out value);
                break;
            case Language.French:
                localisedFR.TryGetValue(key, out value);
                break;

       }

       return value;
   }

}
