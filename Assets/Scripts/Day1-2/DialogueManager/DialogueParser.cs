using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); //��ȭ ����Ʈ ����
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); //csv���� ������

        string[] data = csvData.text.Split(new char[] { '\n' }); //���� �������� �ɰ�

        //List<string> contextList = new List<string>();
        for (int i=1; i<data.Length;)
        {
            //row�� �ϳ� �þ row[3]
            string[] row = data[i].Split(new char[] { ',' }); //,�������� �ɰ�
            Dialogue dialogue = new Dialogue(); //��� ����Ʈ ����

            dialogue.name = row[1];
            //Debug.Log(i);
            //Debug.Log(row[1]);
            //Debug.Log("row1��");

            List<string> contextList = new List<string>();

            do{
                contextList.Add(row[2]);
                //Debug.Log(i);
                //Debug.Log(row[2]);
                
                if (++i < data.Length){
                    row = data[i].Split(new char[]{ ',' });
                }else{
                    //��� ������ ����� ��
                    break;
                }
            }while(row[0].ToString() == "");

            dialogue.contexts = contextList.ToArray();

            dialogueList.Add(dialogue);
        }

        return dialogueList.ToArray();
    }

    
}
