using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscoretable : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform entryContainer;
    private Transform entryTemplate;
    float templateHeight = 65f;
    private List<HighScoreEntry> highscoreEntrylist;
    private List<Transform> highScoreEntryTranformList;
    private void Start() {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        Debug.Log("entrou no Awake");
        entryTemplate.gameObject.SetActive(false);  

        highscoreEntrylist = new List<HighScoreEntry>(){
            new HighScoreEntry{score = 51245},
            new HighScoreEntry{score = 4854},
            new HighScoreEntry{score = 12456},
            new HighScoreEntry{score = 89654},
            new HighScoreEntry{score = 12478},
            new HighScoreEntry{score = 65821},
            new HighScoreEntry{score = 77412},
            new HighScoreEntry{score = 98654}
        };
        highscoreEntrylist.Add(new HighScoreEntry(10000));
        highscoreEntrylist.Add(new HighScoreEntry(99999));
        highscoreEntrylist.Add(new HighScoreEntry(99999));

        for(int i =0;i<highscoreEntrylist.Count;i++){
            for(int j = i + 1; j<highscoreEntrylist.Count;j++){
                if(highscoreEntrylist[j].score>highscoreEntrylist[i].score){
                    HighScoreEntry aux = highscoreEntrylist[i];
                    highscoreEntrylist[i] = highscoreEntrylist[j];
                    highscoreEntrylist[j]= aux;
                }
            }
        }

        highScoreEntryTranformList = new List<Transform>();
        foreach(HighScoreEntry highScoreEntry in highscoreEntrylist){
            CreateHighCoreEntryTransform(highScoreEntry,entryContainer,highScoreEntryTranformList);
        }


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

    private class HighScoreEntry{
        public int score;

        public HighScoreEntry(){
            
        }
        public HighScoreEntry(int Score){
            this.score = Score;
        }
    }
}
