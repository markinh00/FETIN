using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeProjetil : MonoBehaviour{
    [SerializeField] private KeyCode tecla;
    [SerializeField] private Rigidbody2D projetil;
    [SerializeField] private GameObject ObjetoBarraDeForça;
    [SerializeField] private float tempoDeEspera = 3;
    [SerializeField] private BarraDeCoolDown cooldown;
    [SerializeField] private BarraDeForça barraDeForça;
    [SerializeField] private float forçaMaxima = 650;
    private float forçaAtual;
    [SerializeField] private float forçaMinima = 100;
    [SerializeField] private float tempoParaForçaMaxima = 5;
    private float cronometroTiro;
    private float cronometroForça;

    private void Awake(){
        this.cronometroTiro = this.tempoDeEspera;
        this.cronometroForça = 0;
        this.cooldown.SetTempoDeCoolDown(this.tempoDeEspera);
        this.barraDeForça.SetForçaMaxima(this.forçaMaxima);
        this.barraDeForça.SetForçaMinima(this.forçaMinima);
        this.ObjetoBarraDeForça.SetActive(false);
    }

    void Update(){
        if(this.cronometroTiro < this.tempoDeEspera){
        this.cronometroTiro += Time.deltaTime;
        }
        this.cooldown.SetCooldown(cronometroTiro);

        if (Input.GetKey(tecla) && this.cronometroTiro >= this.tempoDeEspera && this.forçaAtual < this.forçaMaxima){
            this.ObjetoBarraDeForça.SetActive(true);
            this.cronometroForça += Time.deltaTime;
            this.forçaAtual = ((this.forçaMaxima - this.forçaMinima) / this.tempoParaForçaMaxima) * this.cronometroForça + this.forçaMinima;
            this.barraDeForça.SetForça(this.forçaAtual);
        }
        if (Input.GetKeyUp(tecla) && this.cronometroTiro >= this.tempoDeEspera){
            this.GerarProjetil(forçaAtual);
            this.ObjetoBarraDeForça.SetActive(false);
        }
    }

    private void GerarProjetil(float força){
        Rigidbody2D projectileInstance;
        projectileInstance = Instantiate(this.projetil, this.transform.position, this.transform.rotation) as Rigidbody2D;
        projectileInstance.AddForce(transform.right * this.forçaAtual);

        this.cronometroTiro = 0;
        this.cronometroForça = 0;
        this.forçaAtual = this.forçaMinima;
        this.barraDeForça.SetForça(this.forçaAtual);
    }
}
