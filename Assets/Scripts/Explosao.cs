using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosao : MonoBehaviour {
    [SerializeField] private float danoExplosao = 40;
    [SerializeField] private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "inimigo"){
            this.DarDanoExplosao(this.danoExplosao, collision.gameObject.GetComponent<Inimigo>());
        }
    }

    private void DarDanoExplosao(float dano, Inimigo inimigo){
        inimigo.LevarDano(dano);
    }


    public void Destruir(){
        GameObject.Destroy(this.gameObject);
    }

}
