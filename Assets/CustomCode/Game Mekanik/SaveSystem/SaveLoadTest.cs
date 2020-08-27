using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadTest : MonoBehaviour {
    // Start is called before the first frame update

    [Header ("Save Data")]
    public ExampleData data1 = new ExampleData (1, "1", 1.1f);
    public ExampleData2 data2 = new ExampleData2 ("2");

    [Header ("Load Data")]
    public ExampleData loadData1;
    public ExampleData2 loadData2;

    public string path;

    [SerializeField] string saveData1 = "saveData1.dat";
    [SerializeField] string saveData2 = "saveData2.dat";
    void Start () {
        path = Application.dataPath;
    }

    public void MakeSave () {
        SaveLoadManager.SaveData<ExampleData> (data1, path, saveData1);
        SaveLoadManager.SaveData<ExampleData2> (data2, path, saveData2);
    }

    public void LoadSaveData () {
        SaveLoadManager.LoadData<ExampleData> (path, saveData1, out ExampleData resultData);
        SaveLoadManager.LoadData<ExampleData2> (path, saveData2, out ExampleData2 resultData2);
        loadData1 = resultData;
        loadData2 = resultData2;
    }

    // Update is called once per frame
    void Update () {

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