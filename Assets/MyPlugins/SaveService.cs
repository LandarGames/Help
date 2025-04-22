using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class SaveService
{
    public const string FIRSTLAUNCH = "First_Launch"; 

    public static void SetInt(string key, int value) => PlayerPrefs.SetInt(key, value);
    public static void SetSFloat(string key, float value) => PlayerPrefs.SetFloat(key, value);
    public static void SetString(string key, string value) => PlayerPrefs.SetString(key, value);
    public static void SetBool(string key, bool value) => PlayerPrefs.SetInt(key, value ? 1 : 0);

    public static int GetInt(string key) => PlayerPrefs.GetInt(key);
    public static float GetFloat(string key) => PlayerPrefs.GetFloat(key);
    public static string GetString(string key) => PlayerPrefs.GetString(key);
    public static bool GetBool(string key) { if (PlayerPrefs.GetInt(key) == 1) return true; else return false; }

    public static void Save() => PlayerPrefs.Save();
    public static bool HasKey(string key) => PlayerPrefs.HasKey(key);
    public static void DeleteKey(string key) => PlayerPrefs.DeleteKey(key);
    public static void DeleteAll() => PlayerPrefs.DeleteAll();

    public static bool CheckFirstLaunch()
    {
        var isFirstLaunch = !GetBool(FIRSTLAUNCH);

        SetBool(FIRSTLAUNCH, true);

        return isFirstLaunch;
    }
}
