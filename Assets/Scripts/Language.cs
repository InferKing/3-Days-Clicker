using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class Language : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetLang();
    public string currentLanguage; 
    public static Language instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //currentLanguage = GetLang();
        }
        else Destroy(gameObject);
    }
}
