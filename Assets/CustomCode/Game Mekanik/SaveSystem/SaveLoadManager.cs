﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour {

    ExampleData dataOnGame;

    static SaveLoadManager instance;

    private void Awake () {
        if (instance == null) {
            DontDestroyOnLoad (gameObject);
            instance = this;
        } else if (instance != this) {
            Destroy (gameObject);
        }
    }

    private void Start () {

    }
    public static void SaveData (ExampleData rawData, string path, string fileName) {
        BinaryFormatter bf = new BinaryFormatter ();
        FileStream file = File.Create (path + "/" + fileName);

        ExampleData data = new ExampleData ();

        data.intVal = rawData.intVal;
        data.stringVal = rawData.stringVal;
        data.floatVal = rawData.floatVal;

        bf.Serialize (file, data);
        file.Close ();
    }
    public static void LoadData (string path, string fileName) {
        if (File.Exists (path + "/" + fileName)) {
            BinaryFormatter bf = new BinaryFormatter ();
            FileStream file = File.Open (path + "/" + fileName, FileMode.Open);
            ExampleData data = (ExampleData) bf.Deserialize (file);
            file.Close ();

            instance.dataOnGame = data;

            //OR
            // instance.dataOnGame.floatVal = data.floatVal;
            // instance.dataOnGame.stringVal = data.stringVal;
        }
    }
    public static void SaveData1<T> (T rawData, string path, string fileName) {
        BinaryFormatter bf = new BinaryFormatter ();
        FileStream file = File.Create (path + "/" + fileName);

        T data = rawData;

        bf.Serialize (file, data);
        file.Close ();
    }
    public static void LoadData2<T> (string path, string fileName, out T targetData) {
        targetData = default(T);

        if (File.Exists (path + "/" + fileName)) {
            BinaryFormatter bf = new BinaryFormatter ();
            FileStream file = File.Open (path + "/" + fileName, FileMode.Open);
            T data = (T) bf.Deserialize (file);
            file.Close ();

            targetData = data;

            //OR
            // instance.dataOnGame.floatVal = data.floatVal;
            // instance.dataOnGame.stringVal = data.stringVal;
        }

    }
}

[Serializable]
public class ExampleData {
    public int intVal;
    public string stringVal;
    public float floatVal;
}