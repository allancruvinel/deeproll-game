using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorUI : MonoBehaviour
{
    public bool pause;

    private GameObject gf;
    private GameObject pausedUI;
    public GameObject girBola;
    GameFlow ScriptGameFlow;
    playerroda ScriptGiraPlayer;
    //public bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        gf = GameObject.FindGameObjectWithTag("GameFlow");
        ScriptGameFlow = gf.GetComponent<GameFlow>();
        pausedUI = GameObject.FindGameObjectWithTag("PauseedUI");
        ScriptGiraPlayer = girBola.GetComponent<playerroda>();
        pausedUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayAgain(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu(){
        SceneManager.LoadScene("Menu_Scene");
    }
    public void PauseGame(){
        pause = !pause;
        if (pause){
            ScriptGameFlow.enabled=false;
            ScriptGiraPlayer.enabled=false;
            pausedUI.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            ScriptGameFlow.enabled=true;
            ScriptGiraPlayer.enabled=true;
            pausedUI.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
