using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

[System.Serializable]
public class PlayerInfo
{
    public int coins;
    public List<int> items = new List<int>();
}

public class SaveData : MonoBehaviour
{
    public PlayerInfo info;
    public static SaveData instance;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);
    [DllImport("__Internal")]
    private static extern void LoadExtern();

    private void Awake()
    {
        if (instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            instance = this;
            LoadExtern();
        }
        else Destroy(gameObject);
    }

    public void Save()
    {
        string json = JsonConvert.SerializeObject(info);
        SaveExtern(json);
    }
    public void SetInfo(string value)
    {
        info = JsonConvert.DeserializeObject<PlayerInfo>(value);
    }
}
