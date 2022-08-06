using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceGameOver : MonoBehaviour{
    [SerializeField] private Text TextoRecorde;

    public void AtualizarInterfaceGrafica(){
        int recorde = PlayerPrefs.GetInt("recorde");
        this.TextoRecorde.text = recorde.ToString();
    }

}
