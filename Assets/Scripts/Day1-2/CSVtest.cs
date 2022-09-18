using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVtest : MonoBehaviour
{
    public void Start()
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");

        for (int i = 0; i < data_Dialog.Count; i++)
        {
            print(data_Dialog[i]["Content"].ToString());
        }
    }
}
