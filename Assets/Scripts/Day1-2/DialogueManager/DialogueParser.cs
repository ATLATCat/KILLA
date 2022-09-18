using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); //대화 리스트 생성
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); //csv파일 가져옴

        string[] data = csvData.text.Split(new char[] { '\n' }); //엔터 기준으로 쪼갬

        //List<string> contextList = new List<string>();
        for (int i=1; i<data.Length;)
        {
            //row가 하나 늘어남 row[3]
            string[] row = data[i].Split(new char[] { ',' }); //,기준으로 쪼갬
            Dialogue dialogue = new Dialogue(); //대사 리스트 생성

            dialogue.name = row[1];
            //Debug.Log(i);
            //Debug.Log(row[1]);
            //Debug.Log("row1후");

            List<string> contextList = new List<string>();

            do{
                contextList.Add(row[2]);
                //Debug.Log(i);
                //Debug.Log(row[2]);
                
                if (++i < data.Length){
                    row = data[i].Split(new char[]{ ',' });
                }else{
                    //대사 범위가 벗어나면 끝
                    break;
                }
            }while(row[0].ToString() == "");

            dialogue.contexts = contextList.ToArray();

            dialogueList.Add(dialogue);
        }

        return dialogueList.ToArray();
    }

    
}
