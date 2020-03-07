using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public float minutosVelMax;
    public float velocidadeCanoInicial;
    public float velocidadeCanoFinal;
    public float instanciarQuadradosInicial;
    public float instanciarQuadradosFinal;
    public float instanciarParedeInicial;
    public float instanciarParedeFinal;
    private GameObject Player;
    private GameObject Cano;
    private GameObject Instanciador;
    public GameObject GameOverUI;
    public bool GameOver;
    bolagira ScriptPlayer;
    rodatextue ScriptCano;
    criaobstaculo ScriptObstaculo;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        ScriptPlayer = Player.GetComponent<bolagira>();
        Cano = GameObject.FindGameObjectWithTag("cano");
        ScriptCano = Cano.GetComponent<rodatextue>();
        Instanciador = GameObject.FindGameObjectWithTag("InstanciaObj");
        ScriptObstaculo = Instanciador.GetComponent<criaobstaculo>(); 
        //GameOverUI = GameObject.FindGameObjectWithTag("gamingover");


        minutosVelMax = 3f;
        velocidadeCanoInicial = 1f;
        velocidadeCanoFinal = 3.1f;
        instanciarQuadradosInicial = 1f;
        instanciarQuadradosFinal = 0.3f;
        instanciarParedeInicial = 4f;
        instanciarParedeFinal = 1f;
        ScriptCano.speed = velocidadeCanoInicial;
        ScriptObstaculo.DelayObs1 = instanciarQuadradosInicial;
        ScriptObstaculo.DelayObs2 = instanciarParedeInicial;

        
        GameOver = false;

        Time.timeScale = 1f;
    }
        float number = 0f;
        float number2 = 0f;
        float number3 = 0f;
    // Update is called once per frame
    void FixedUpdate()
    {
        ScriptCano.speed = Mathf.Lerp(velocidadeCanoInicial, velocidadeCanoFinal,number+=(Time.deltaTime/(minutosVelMax*60)));

        ScriptObstaculo.DelayObs1 = Mathf.Lerp(instanciarQuadradosInicial, instanciarQuadradosFinal,number2+=(Time.deltaTime/(minutosVelMax*60)));

        ScriptObstaculo.DelayObs2 = Mathf.Lerp(instanciarParedeInicial, instanciarParedeFinal,number3+=(Time.deltaTime/(minutosVelMax*60)));

        if(ScriptPlayer.VidaPlayer<=0){
            GameOver = true;
            Time.timeScale = 0f;
            GameOverUI.SetActive(true);
        }

    }
}
