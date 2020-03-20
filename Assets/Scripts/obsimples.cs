using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsimples : MonoBehaviour {

    
    public float velocidade = 0f;
    Rigidbody Corpo;
    GameObject fundocenario;
    rodatextue scriptcano;
    public bool colidiu = false;
	
	void Start () {
       
        Corpo = GetComponent<Rigidbody>();
        fundocenario = GameObject.FindGameObjectWithTag("cano");
        scriptcano = fundocenario.GetComponent<rodatextue>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (!colidiu)
        {
            Corpo.velocity = new Vector3(0, 0, -scriptcano.speed * 3.09f);
        }
        if(Input.GetKey(KeyCode.A)){
            Debug.Log("Apertou A");
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            colidiu = true;
        }
        
    }

}
