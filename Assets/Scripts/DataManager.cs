using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string bestScoreName;
    public int bestScoreInt;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null){
            Destroy(gameObject);
        }

        Debug.Log(Application.persistentDataPath);

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    [System.Serializable]
    public class SaveData{
        public string prevPlayerName = "Player";
        public string bestScoreName = " ";
        public int bestScoreInt = 0;
    }

    public void SaveName(){
        SaveData data = LoadAllData();
        data.prevPlayerName = playerName;

        string newJson = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", newJson);
    }

    public void SaveScore(){
        SaveData data = LoadAllData();
        data.bestScoreName = playerName;
        data.bestScoreInt = bestScoreInt;

        string newJson = JsonUtility.ToJson(data);   

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", newJson);
    }

    public SaveData LoadAllData(){
        string path = Application.persistentDataPath + "/savefile.json";

        SaveData data = new SaveData();

        if(File.Exists(path)){
            string json = File.ReadAllText(path);

            data = JsonUtility.FromJson<SaveData>(json);

        }

        return data;
    }

}
