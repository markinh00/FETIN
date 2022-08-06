using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diretor : MonoBehaviour{
    private Jogador jogador;
    private GeradorDeInimigos geradorDeInimigos;
    private InterfaceGameOver interfaceGameOver;
    [SerializeField] GameObject panelGameOver;
    [SerializeField] Pontuação pontuação;

    private void Awake(){
        this.jogador = GameObject.FindObjectOfType<Jogador>();
        this.interfaceGameOver = GameObject.FindObjectOfType<InterfaceGameOver>();
        this.geradorDeInimigos = GameObject.FindObjectOfType<GeradorDeInimigos>();
        this.panelGameOver.SetActive(false);
    }

    public void AtualizarPontos(){
        this.pontuação.ContarPontos();
    }

    public void GameOver(){
        Time.timeScale = 0;
        this.interfaceGameOver.AtualizarInterfaceGrafica();
        this.panelGameOver.SetActive(true);
    }

    public void Restart(){
        GameObject[] InimigosParaMatar = GameObject.FindGameObjectsWithTag("inimigo");

        foreach (var inimigo in InimigosParaMatar){
            GameObject.Destroy(inimigo);
        }

        this.pontuação.Reiniciar();
        this.geradorDeInimigos.ZerarDificuldade();
        this.jogador.RestaurarVida();
        this.panelGameOver.SetActive(false);
        Time.timeScale = 1;
    }
}
