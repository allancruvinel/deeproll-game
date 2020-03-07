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
    public int HpMenosObs1=50;
    public int HpMenosObs2=80;
    public float TempoInvulneravel;
    private float Invulnerabilidade;
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
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //velocidadequegira = scriptcano.speed;
        //transform.Rotate(regulagem * velocidadequegira, 0, 0);  //gira a bola de acordo com a velocidade do cano
        TextoVidaPlayer.text = "Energia " + VidaPlayer.ToString()+"%";
        TextoPontoPlayer.text = "Pontuação "+PontuacaoPlayer.ToString();

        Invulnerabilidade -= Time.deltaTime;

        PontuacaoPlayer+=Time.deltaTime;
	}

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag =="Points"){
            PontuacaoPlayer+=PontosPorEstrela;
            scriptsom.SomEstrelaColeta.Play();
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "ObSimples")
        {
            if (Invulnerabilidade <= 0)
            {
                VidaPlayer -= HpMenosObs1;
                scriptsom.SomDanoPlayer.Play();
                Invulnerabilidade = TempoInvulneravel;
            }
        }
        if(collision.gameObject.tag == "ObSimples2")
        {
            if (Invulnerabilidade <= 0)
            {
                VidaPlayer -= HpMenosObs2;
                scriptsom.SomDanoPlayer.Play();
                Invulnerabilidade = TempoInvulneravel;
            }
        }
    }
}
