using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour{
    private Diretor diretor;
    private float vidaAtual;
    [SerializeField] private float vidaMax = 100;
    [SerializeField] private BarraDeVida barraDeVida;
    private Collider2D jogador;

    private void Awake(){
        this.vidaAtual = this.vidaMax;
        this.barraDeVida.SetVidaMax(this.vidaMax);
        this.diretor = GameObject.FindObjectOfType<Diretor>();
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            LevarDano(40);
        }
    }

    public void LevarDano(float dano){
        this.vidaAtual -= dano;
        barraDeVida.SetVida(this.vidaAtual);

        if(this.vidaAtual <= 0){
            Morrer();
        }
    }

    public void Morrer(){
        diretor.GameOver();
    }

    public void RestaurarVida(){
        this.vidaAtual = this.vidaMax;
        this.barraDeVida.SetVidaMax(this.vidaMax);
    }
}
