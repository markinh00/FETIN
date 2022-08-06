using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeCoolDown : MonoBehaviour{
    [SerializeField] private Slider slider;

    public void SetTempoDeCoolDown(float tempo){
        slider.maxValue = tempo;
        slider.value = tempo;
    }

    public void SetCooldown(float tempo){
        slider.value = tempo;
    }
}
