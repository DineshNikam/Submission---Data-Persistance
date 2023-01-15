using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public  class BetweenSceneDataManager : MonoBehaviour
{
    public static BetweenSceneDataManager Instatance;
    public string Name;
    public int Score;
    public string session_user ;
    public int session_Score;
    private void Awake()
    {
        if (Instatance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instatance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }
    [System.Serializable] class DataContainer{
        public string Name;
        public int Score;
        public string preSessionName;
    }


    public void SaveData()
    {
        DataContainer data = new DataContainer();
        data.Name = this.Name;
        data.Score = this.Score;
        
        string json = JsonUtility.ToJson(data);
        Debug.Log("Svae Data  :  Name : " + data.Name + " score : " + data.Score);
        File.WriteAllText(Application.persistentDataPath + "/saveData.txt", json);
    }
    public void LoadData()
    {
        Debug.Log(Application.persistentDataPath);
        string path = Application.persistentDataPath + "/saveData.txt";
        if (File.Exists(path))
        {   
           DataContainer  data = JsonUtility.FromJson<DataContainer>(File.ReadAllText( path));
            Name = data.Name;
            Score = data.Score;
            Debug.Log("Load Data  :  Name : " + data.Name + " score : " + data.Score);

        }
        else
        {
            Debug.Log("Data Does Not Exist...");
        }
    }
}
