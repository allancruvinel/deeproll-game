using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerroda : MonoBehaviour {

    //codigo que gira a bola de acordo com o dedo tocando a tela, bem legal
    private GameObject UiReference;
    GerenciadorUI ScriptUI;
    private float baseAngle = 0.0f;


    void Start()
    {
        UiReference = GameObject.FindGameObjectWithTag("canvas");
        ScriptUI = UiReference.GetComponent<GerenciadorUI>();
    }

    void Update() {
        
    }
    void OnMouseDown()
    {
        if(!ScriptUI.pause){
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            pos = Input.mousePosition - pos;
            baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
            baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg; //mantem a posição atual da bola ao tocar na tela
        }
    }

    void OnMouseDrag()
    {
        if(!ScriptUI.pause){
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        float ang = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle;
        transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);  //gira o objeto de acordo com o arrastar
        }
    }
}
