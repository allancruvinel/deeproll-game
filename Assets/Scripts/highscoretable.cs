using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscoretable : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> listainicial;
    private List<Transform> highScoreEntryTranformList;
    private void Awake() {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false); 


        /*
        listainicial = new List<HighScoreEntry>(){
            new HighScoreEntry{score = Score},
            new HighScoreEntry{score = 4854},
            new HighScoreEntry{score = 12456},
            new HighScoreEntry{score = 89654},
            new HighScoreEntry{score = 12478},
            new HighScoreEntry{score = 65821},
            new HighScoreEntry{score = 77412},
            new HighScoreEntry{score = 98654}
        };
        */
        
    
        
        /*
        Highscores highscores = new Highscores{ClassHighscoreEntrylist = highscoreEntrylist};
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("ScoreSalvo",json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("ScoreSalvo"));*/
        
        

    }

    private void CreateHighCoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformlist){
            float templateHeight = 65f;
            Transform entryTransform = Instantiate(entryTemplate,container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0,-templateHeight*transformlist.Count);
            entryTransform.gameObject.SetActive(true);

            int rank = transformlist.Count+1;
            string rankString;
            switch(rank){
                default: rankString = rank + "TH";break;
                case 1: rankString = "1ST";break;
                case 2: rankString = "2ND";break;
                case 3: rankString = "3RD";break;
            }

            entryTransform.Find("postext").GetComponent<Text>().text = rankString;

            int Score = highScoreEntry.score;

            entryTransform.Find("scoretext").GetComponent<Text>().text = Score.ToString();

            transformlist.Add(entryTransform);
    }

    
    [System.Serializable]
    private class Highscores{
        public List<HighScoreEntry> ClassHighscoreEntrylist;
    }
    

    [System.Serializable]
    private class HighScoreEntry{
        public int score;
    }

    public void addScoreEntry(int Score){
        HighScoreEntry highscoreentry = new HighScoreEntry{score = Score};

        string a = PlayerPrefs.GetString("scoreplayerfile");
        if(a==""){
            
            listainicial = new List<HighScoreEntry>(){
            new HighScoreEntry{score = Score}
            };

            Highscores highscores = new Highscores{ClassHighscoreEntrylist = listainicial};
            string json = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("scoreplayerfile",json);
            PlayerPrefs.Save();

            
        }
        else{

            string jsonscores = PlayerPrefs.GetString("scoreplayerfile");
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonscores);
            highscores.ClassHighscoreEntrylist.Add(highscoreentry);

            string json = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("scoreplayerfile",json);
            PlayerPrefs.Save();
        }

    }

    public void geraScore(){

        string jsonscores = PlayerPrefs.GetString("scoreplayerfile");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonscores);
        
        for(int i =0;i<highscores.ClassHighscoreEntrylist.Count;i++){
            for(int j = i + 1; j<highscores.ClassHighscoreEntrylist.Count;j++){
                if(highscores.ClassHighscoreEntrylist[j].score>highscores.ClassHighscoreEntrylist[i].score){
                    HighScoreEntry aux = highscores.ClassHighscoreEntrylist[i];
                    highscores.ClassHighscoreEntrylist[i] = highscores.ClassHighscoreEntrylist[j];
                    highscores.ClassHighscoreEntrylist[j]= aux;
                }
            }
        }

        highScoreEntryTranformList = new List<Transform>();
        int maxExibition = 10;
        int ActualExibition = 0;
        foreach(HighScoreEntry highScoreEntry in highscores.ClassHighscoreEntrylist){
            if(ActualExibition<maxExibition){
            CreateHighCoreEntryTransform(highScoreEntry,entryContainer,highScoreEntryTranformList);
            ActualExibition++;
            }
        }
    }

    
}
