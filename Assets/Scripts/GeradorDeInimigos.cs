using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeInimigos : MonoBehaviour{
    [SerializeField] private GameObject objetoInimigo;
    [SerializeField] private float tempoParaGerarMinimo = 3;
    [SerializeField] private float tempoParaGerarMaximo = 10;
    private float tempoParaGerarAtual;
    [SerializeField] private float TempoParaDificuldadeMaxima = 30;
    private float cronometroParaGerar;
    private float cronometro;

    private void Start(){
        this.cronometroParaGerar = 0;
        this.cronometro = 0;
    }

    private void Update(){
        AtualizarDificuldade();
        if (this.cronometroParaGerar < this.tempoParaGerarAtual){
            this.cronometroParaGerar += Time.deltaTime;
        }
        else{
            this.GerarInimigo();
        }
    }

    private void GerarInimigo(){
        Instantiate(this.objetoInimigo, this.transform.position, Quaternion.identity);
        this.cronometroParaGerar = 0;
    }

    private void AtualizarDificuldade(){
        this.cronometro += Time.deltaTime;
        if(this.cronometro < this.TempoParaDificuldadeMaxima){
            tempoParaGerarAtual = -(this.tempoParaGerarMaximo - this.tempoParaGerarMinimo) / this.TempoParaDificuldadeMaxima * this.cronometro + this.tempoParaGerarMaximo;
        }
        else if(this.cronometro >= this.TempoParaDificuldadeMaxima){
            this.tempoParaGerarAtual = this.tempoParaGerarMaximo;
        }
    }

    public void ZerarDificuldade(){
        this.cronometro = 0;
        this.cronometroParaGerar = 0;
    }
}
