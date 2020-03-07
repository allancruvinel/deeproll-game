using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criaobstaculo : MonoBehaviour {
    public GameObject obs1;
    public GameObject obs2;
    public GameObject Estrela;
    public Quaternion rotacao;

    GameObject criaOsb1;
    GameObject criaOsb2;

    private float TempoObs1 =0;
    public float DelayObs1 = 3f;

    private float TempoObs2 = 0;
    public float DelayObs2 = 3f;

    public int TempoSafeZoneAtivo=2;
    public float TempoEntreEstrelas=0.3f;
    private float TempoSafeZone;
    private float TempoEntreInvocacaoDeEstrela;
    public int PorcentagemAtivarSafeZone=10;
    public int SegundosParaAplicarPorcentagem=3;
    private float tempoTentativaSafeZone;
    public bool SafeZone = false;
    int posicaoEstrelas;

    // Use this for initialization
    void Start () {
        tempoTentativaSafeZone=SegundosParaAplicarPorcentagem;
        TempoSafeZone=TempoSafeZoneAtivo;
        TempoEntreInvocacaoDeEstrela=TempoEntreEstrelas;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if(SafeZone)
        {
            TempoSafeZone-= Time.deltaTime;

            TempoEntreInvocacaoDeEstrela-=Time.deltaTime;
            if(TempoEntreInvocacaoDeEstrela<=0){
                criaOsb1 = Instantiate(Estrela, transform.position, rotacao = Quaternion.Euler(0,0,posicaoEstrelas));
                TempoEntreInvocacaoDeEstrela=TempoEntreEstrelas;
            }
            if(TempoSafeZone<=0){
                SafeZone=false;
                TempoSafeZone=TempoSafeZoneAtivo;
            }
        }
        else
        {

            tempoTentativaSafeZone-=Time.deltaTime;
            if(tempoTentativaSafeZone<=0){
                if(Random.Range(0,100)<PorcentagemAtivarSafeZone){
                    SafeZone = true;
                    posicaoEstrelas = Random.Range(0,360);
                    tempoTentativaSafeZone = SegundosParaAplicarPorcentagem;
                    TempoSafeZone = Random.Range(1,3);
                }
                tempoTentativaSafeZone = SegundosParaAplicarPorcentagem;
            }


            TempoObs1 -= Time.deltaTime;
            if (TempoObs1 <= 0)
            {

                criaOsb1 = Instantiate(obs1, transform.position, rotacao = Quaternion.Euler(0,0,Random.Range(0,360)));
                TempoObs1 = DelayObs1;
            }

            TempoObs2 -= Time.deltaTime;
            if (TempoObs2 <= 0)
            {

                criaOsb2 = Instantiate(obs2, transform.position, rotacao = Quaternion.Euler(0, 0, Random.Range(0, 360)));
                TempoObs2 = DelayObs2;
            }

        }

    }
    void InvocarEstrela(){
        Debug.Log("Printou");
    }
    
}
