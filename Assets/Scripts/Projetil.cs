using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour {
    [SerializeField] private float dano = 40;
    [SerializeField] private GameObject explosao;

    private void OnTriggerEnter2D(Collider2D target){
        if (target.gameObject.tag == "chao"){
            Debug.Log("projeti: explodi");
            this.Explodir();
        }else if(target.gameObject.tag == "inimigo"){
            this.DarDano(this.dano, target.GetComponent<Inimigo>());
            this.Explodir();
        }
    }

    public void DarDano(float dano, Inimigo inimigo){
        Debug.Log("projetil: acertei inimigo");
        inimigo.LevarDano(dano);
        
        this.Destruir();
    }

    private void Explodir(){
        Instantiate(this.explosao, this.transform.position, Quaternion.identity);
        this.Destruir();
    }

    private void Destruir(){
        GameObject.Destroy(this.gameObject);
    }
}   
