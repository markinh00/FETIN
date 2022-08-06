using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canhao : MonoBehaviour {
    [SerializeField] private KeyCode teclaRodarEsquerda;
    [SerializeField] private KeyCode teclaRodarDireita;
    [SerializeField] private float graus;
    [SerializeField] private float rotacaoMinima = -90;
    [SerializeField] private float rotacaoMaxima = 90;
    private float grauAtual;

    private void Awake(){
        this.grauAtual = 0;
    }

    private void Update(){

        if (Input.GetKey(teclaRodarDireita) && grauAtual > rotacaoMinima){
            RodarParaDIreita();
            grauAtual -= graus;
        }
        else if (Input.GetKey(teclaRodarEsquerda) && grauAtual < rotacaoMaxima){
            RodarParaEsquerda();
            grauAtual += graus;
        }
    }

    private void RodarParaEsquerda(){
        this.transform.Rotate(0, 0, graus);
    }

    private void RodarParaDIreita(){
        this.transform.Rotate(0, 0, -graus);
    }
}
