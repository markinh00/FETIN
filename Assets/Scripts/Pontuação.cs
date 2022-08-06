using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuação : MonoBehaviour{
    private int pontos;
    [SerializeField] Text textoPontos;

    private void Start(){
        this.pontos = 0;
    }

    public void ContarPontos(){
        this.pontos++;
        this.textoPontos.text = this.pontos.ToString();

        if(this.pontos > PlayerPrefs.GetInt("recorde")){
            SalvarRecord(this.pontos);
        }
    }

    public void SalvarRecord(int novoRecorde){
        PlayerPrefs.SetInt("recorde", novoRecorde);
    }

    public void Reiniciar(){
        this.pontos = 0;
        this.textoPontos.text = this.pontos.ToString();
    }
}
