using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeForça : MonoBehaviour{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    public void SetForçaMaxima(float força){
        this.slider.maxValue = força;
    }

    public void SetForçaMinima(float força){
        this.slider.minValue = força;
        this.slider.value = força;
        this.fill.color = this.gradient.Evaluate(força);
    }

    public void SetForça(float força){
        this.slider.value = força;
        this.fill.color = this.gradient.Evaluate(this.slider.normalizedValue);
    }
   
}
