using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rodatextue : MonoBehaviour {

    //script que gira a textura do cano

    public float speed;  //velocidade que gira a textura do cano
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 offset = new Vector2(0, Time.time * speed); //cria um vetor de velocidade para o cano
        // speed += Time.deltaTime * Time.deltaTime; //aumenta a velocidade do cano atravez do tempo
        GetComponent<Renderer>().material.mainTextureOffset = offset; //aplica o giro da textura do cano
	}
}
