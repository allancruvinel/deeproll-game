using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{

    public GameObject CreditsUI;
    private GameObject ads;
    adMobScript ScriptAD;
    // Start is called before the first frame update
    void Start()
    {
        ads = GameObject.FindGameObjectWithTag("ADMOB");
        ScriptAD = ads.GetComponent<adMobScript>();
        ScriptAD.RequestBanner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        ScriptAD.RemoveBanner();
        SceneManager.LoadScene("Game_Scene");

    }
    public void OpenCredits(){
        CreditsUI.gameObject.SetActive(true);
    }
    public void CloseCredits(){
        CreditsUI.gameObject.SetActive(false);
    }
}
