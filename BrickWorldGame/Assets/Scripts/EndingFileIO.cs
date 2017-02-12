using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;

public class EndingFileIO : MonoBehaviour {

    private StreamReader SR;
    private StreamWriter SW;
    private List<KeyValuePair<string, int>> Dic;
    private int counter,lineread;
    private Text[] names;
    private Text[] scores;
    private List<int> scoresordering;
    private Button button;
    private int playerscorewon;
    private GameManagerScript GM;
	[SerializeField] GameObject GM_prefab;


	// Use this for initialization
	void Start ()
    {
        //initiaze text arrays to hold text gameobjects
        names = new Text[3];
        scores = new Text[3];
        scoresordering = new List<int>();
        Dic = new List<KeyValuePair<string, int>>();
        button = GameObject.Find("EnterButton").GetComponent<Button>();
        button.onClick.AddListener(EnterName);
        GM = GameObject.Find("GM").GetComponent<GameManagerScript>();
        playerscorewon = GM.Score;
        GameObject.Find("PlayerScore").GetComponent<Text>().text = playerscorewon.ToString();
        for (int x =1;x<4;x++)
        {
            names[x-1] = GameObject.Find("Name" + x).GetComponent<Text>();
            scores[x-1] = GameObject.Find("Score" + x).GetComponent<Text>();
        }
        this.makeleaderboard();
       
	}
	
	// Update is called once per frame
	void Update ()
    {
       
    }



    public void EnterName()
    {
        string name = GameObject.Find("InputField").GetComponent<InputField>().text;
        if (name != "")
        {
            SW = new StreamWriter("Assets/text_file/highscore.txt",true);
            string score = GameObject.Find("PlayerScore").GetComponent<Text>().text;
            SW.WriteLine(name + " " + score);
            SW.Close();
            GameObject.Find("EnterText").GetComponent<Text>().text = "Quit";
            this.makeleaderboard();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(quitevent);
        }
    }

    public void quitevent()
    {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		return;
		#endif

        Application.Quit();
    }

	public void resetGame (){
		GameObject.Destroy(GameObject.Find("GM"));
		GameObject gm =GameObject.Instantiate(GM_prefab,Vector3.zero, Quaternion.identity);
		gm.name="GM";
		GameObject.Destroy(gameObject.transform.parent.gameObject);
	}

    public void makeleaderboard()
    {
        counter = 1;
        lineread = 0;
        if (File.Exists("Assets/text_file/highscore.txt"))
        {
            //open the file
            SR = new StreamReader("Assets/text_file/highscore.txt");
            //initalize temps vars
            string line;
            string name;
            int score;
            //read line by line and place into dictionary
            Dic.Clear();
            while ((line = SR.ReadLine()) != null && line != "")
            {
                
                string[] ListofNameandNumber = line.Split(' ');
                name = ListofNameandNumber[0];
                score = int.Parse(ListofNameandNumber[1]);
                Dic.Add(new KeyValuePair<string, int>(name, score));
            }
            SR.Close();



            //order it 
            Dic.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            Dic.Reverse();
            //find the value and put it in the new dic


            //read the top 3
            foreach (KeyValuePair<string, int> something in Dic)
            {
                if (counter < 4)
                {
                    string namein = something.Key;
                    int scorein = something.Value;
                    names[counter - 1].text = namein;
                    scores[counter - 1].text = scorein.ToString();
                    counter++;
                }
                else
                {
                    break;
                }
            }


        }
    }
}
