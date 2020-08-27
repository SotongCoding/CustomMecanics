using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadTest : MonoBehaviour {
    // Start is called before the first frame update

    [Header ("Save Data")]
    public ExampleData data1 = new ExampleData (1, "1", 1.1f);
    public ExampleData2 data2 = new ExampleData2 ("2");

    public List<ExampleData> listData1 = new List<ExampleData> () {
        new ExampleData (101, "101", 1.01f),
        new ExampleData (102, "102", 1.02f),
        new ExampleData (103, "103", 1.03f)
    };
    public List<ExampleData2> listData2 = new List<ExampleData2> () {
        new ExampleData2 ("1"),
        new ExampleData2 ("2"),
        new ExampleData2 ("3")
    };

    [Header ("Load Data")]
    public ExampleData loadData1;
    public ExampleData2 loadData2;

    public List<ExampleData> loadListData1;
    public List<ExampleData2> loadListData2;

    public string path;

    [SerializeField] string saveData1 = "saveData1.dat";
    [SerializeField] string saveData2 = "saveData2.dat";
    [SerializeField] string LsaveData1 = "listSaveData1.dat";
    [SerializeField] string LsaveData2 = "listSaveData2.dat";
    void Start () {
        path = Application.dataPath + "/CustomCode/Game Mekanik/SaveSystem";
    }

    public void MakeSave () {
        //Individual Data
        SaveLoadManager.SaveData<ExampleData> (data1, path, saveData1);
        SaveLoadManager.SaveData<ExampleData2> (data2, path, saveData2);

        //ListData
        SaveLoadManager.SaveData<ExampleData> (listData1, path, LsaveData1);
        SaveLoadManager.SaveData<ExampleData2> (listData2, path, LsaveData2);

    }

    public void LoadSaveData () {
        SaveLoadManager.LoadData<ExampleData> (path, saveData1, out ExampleData resultData);
        SaveLoadManager.LoadData<ExampleData2> (path, saveData2, out ExampleData2 resultData2);

        SaveLoadManager.LoadData<ExampleData> (path, LsaveData1, out List<ExampleData> LresultData);
        SaveLoadManager.LoadData<ExampleData2> (path, LsaveData2, out List<ExampleData2> LresultData2);

        loadListData1 = LresultData;
        loadListData2 = LresultData2;

        loadData1 = resultData;
        loadData2 = resultData2;
    }
}

[Serializable]
public class ExampleData {
    public int intVal;
    public string stringVal;
    public float floatVal;

    public ExampleData (int intDat, string stringDat, float floatDat) {
        intVal = intDat;
        stringVal = stringDat;
        floatVal = floatDat;
    }
    public ExampleData () {

    }
}

[Serializable]
public class ExampleData2 {
    public string data;

    public ExampleData2 (string input) {
        data = input;
    }
    public ExampleData2 () {

    }
}