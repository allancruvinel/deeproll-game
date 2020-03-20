using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscoretable : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform entryContainer;
    private Transform entryTemplate;
    private void Start() {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        Debug.Log("entrou no Awake");
        entryTemplate.gameObject.SetActive(false);
        float templateHeight = 65f;

        for(int i =0; i<10;i++){
            Transform entryTransform = Instantiate(entryTemplate,entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0,-templateHeight*i);
            entryTemplate.gameObject.SetActive(true);

            int rank = i+1;
            string rankString;
            switch(rank){
                default: rankString = rank + "TH";break;
                case 1: rankString = "1ST";break;
                case 2: rankString = "2ND";break;
                case 3: rankString = "3RD";break;
            }

            entryTransform.Find("postext").GetComponent<Text>().text = "";

            
        }
        
    }
}
