using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EndingFileIO : MonoBehaviour {

    private StreamReader SR;
    private StreamWriter SW;
    private Dictionary<string, int> Dic;
    private int counter;
	// Use this for initialization
	void Start ()
    {
        counter = 0;
        Dic = new Dictionary<string, int>();
        if (File.Exists("Assets/text_file/highscore.txt"))
        {
            SR = new StreamReader("Assets/text_file/highscore.txt");
            string line;
            string name;
            int score;
            while ((line = SR.ReadLine()) != null)
            {
                string[] ListofNameandNumber = line.Split(' ');
                name = ListofNameandNumber[0];
                score = int.Parse(ListofNameandNumber[1]);
                Dic.Add(name, score);
            }
            SR.Close();
        }
        else
        {
            SW = new StreamWriter("Assets/text_file/highscore.txt");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        foreach (KeyValuePair<string, int> entry in Dic)
        {
            
        }
    }
}
