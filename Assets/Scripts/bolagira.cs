using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bolagira : MonoBehaviour {

    //Script Oficial do Player

    #region Variaveis de Status do Player
    public int VidaPlayer;
    public int PontosPorEstrela = 5;
    public float PontuacaoPlayer;
    public int pontoplayerInt;
    public int HpMenosObs1=50;
    public int HpMenosObs2=80;
    public float TempoInvulneravel;
    private float Invulnerabilidade;
    public float timeBetweenBlinks=.2f;
    private float decaingBlinkTime;
    #endregion

    #region Variáveis de UI
    public Text TextoVidaPlayer;
    public Text TextoPontoPlayer;
    #endregion

    #region Variáveis que pegam referencias de outros objetos
    GameObject fundocenario;
    rodatextue scriptcano;
    GameObject ObjetoSom;
    GerenciadorSons scriptsom;
    Renderer render;
    
    #endregion

    //public float velocidadequegira = 0f;
    //private float regulagem = 16f;

    // Use this for initialization
    void Start () {
        fundocenario = GameObject.FindGameObjectWithTag("cano");
        scriptcano = fundocenario.GetComponent<rodatextue>(); //pega a referencia do scrip que gira a textura do cano
        ObjetoSom = GameObject.FindGameObjectWithTag("GerenciaSom");
        scriptsom = ObjetoSom.GetComponent<GerenciadorSons>();
        VidaPlayer = 100;
        PontuacaoPlayer = 0;
        render = GetComponent<Renderer>();
        decaingBlinkTime = timeBetweenBlinks;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //velocidadequegira = scriptcano.speed;
        //transform.Rotate(regulagem * velocidadequegira, 0, 0);  //gira a bola de acordo com a velocidade do cano
        TextoVidaPlayer.text = "Energia " + VidaPlayer.ToString()+"%";
        pontoplayerInt = (int)PontuacaoPlayer;
        TextoPontoPlayer.text = "Pontuação:  "+pontoplayerInt.ToString();

        Invulnerabilidade -= Time.deltaTime;

        PontuacaoPlayer+=Time.deltaTime*3;



        if(Invulnerabilidade>0){
            decaingBlinkTime-=Time.deltaTime;
            if(decaingBlinkTime<0){
                render.enabled = !render.enabled;
                decaingBlinkTime = timeBetweenBlinks;
            }   
        }
        else{
            render.enabled=true;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag =="Points"){
            PontuacaoPlayer+=PontosPorEstrela;
            VidaPlayer+=1;
            if(VidaPlayer>100){
                VidaPlayer=100;
            }
            scriptsom.SomEstrelaColeta.Play();
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "ObSimples")
        {
            if (Invulnerabilidade <= 0)
            {
                VidaPlayer -= HpMenosObs1;
                if(VidaPlayer<0){
                    VidaPlayer=0;
                }
                scriptsom.SomDanoPlayer.Play();
                Invulnerabilidade = TempoInvulneravel;
            }
        }
        if(collision.gameObject.tag == "ObSimples2")
        {
            if (Invulnerabilidade <= 0)
            {
                VidaPlayer -= HpMenosObs2;
                if(VidaPlayer<0){
                    VidaPlayer=0;
                }
                scriptsom.SomDanoPlayer.Play();
                Invulnerabilidade = TempoInvulneravel;
            }
        }
    }

    
}
