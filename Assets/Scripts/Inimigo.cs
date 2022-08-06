using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {
    protected Diretor diretor;
    protected Jogador jogador;
    [SerializeField] protected string nome;
    [SerializeField] protected BarraDeVida barraDeVida;
    [SerializeField] protected float vida = 100;
    protected Rigidbody2D fisica;
    protected bool podeAndar;
    protected bool estaNoChao;
    protected bool podeAtacar;
    [SerializeField] protected float forçaCima = 10;
    [SerializeField] protected float forçaesquerda = 10;
    [SerializeField] protected float forçaDano = 10;
    [SerializeField] protected float danoAoSerAtingido = 40;
    [SerializeField] protected BarraDeCoolDown barraDeCoolDown;
    [SerializeField] protected float danoAoAtacar = 5;
    [SerializeField] protected float TempodeEspera = 5;
    private float cronometroAtaque;

    protected virtual void Awake(){
        this.diretor = GameObject.FindObjectOfType<Diretor>();
        this.jogador = GameObject.FindObjectOfType<Jogador>();
        this.fisica = this.GetComponentInChildren<Rigidbody2D>();
        this.barraDeVida.SetVidaMax(this.vida);
        this.cronometroAtaque = this.TempodeEspera;
        this.barraDeCoolDown.SetTempoDeCoolDown(this.cronometroAtaque);
        this.podeAndar = true;
        this.estaNoChao = false;
        this.podeAtacar = false;
    }

    private void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.tag == "jogador"){
            this.podeAtacar = true;
            this.podeAndar = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "jogador"){
            this.podeAtacar = false;
            this.podeAndar = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D){
        if (collision2D.gameObject.tag == "chao"){
            this.estaNoChao = true;
        }
        
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.L)){
            this.fisica.AddForce(Vector2.right * 2 * this.forçaesquerda);
        }

        if (this.cronometroAtaque < this.TempodeEspera){
            this.cronometroAtaque += Time.deltaTime;
            this.barraDeCoolDown.SetCooldown(this.cronometroAtaque);
        }

        if(this.podeAtacar && this.cronometroAtaque >= this.TempodeEspera){
            this.Atacar(danoAoAtacar);

        }

        if (this.estaNoChao && this.podeAndar){
            this.Andar();
        }
    }

    public virtual void Andar(){
        this.fisica.AddForce(Vector2.up * this.forçaCima + Vector2.left * this.forçaesquerda);
        this.fisica.velocity = Vector2.left * 0;
        this.estaNoChao = false;
    }

    public virtual void LevarDano(float dano){
        this.fisica.velocity = Vector2.left * 0;
        this.vida -= dano;
        this.barraDeVida.SetVida(vida);
        if(this.vida <= 0){
            Morrer();
        }
    }

    public virtual void Atacar(float dano){
        this.podeAndar = false;
        this.jogador.LevarDano(dano);
        this.cronometroAtaque = 0;
        this.barraDeCoolDown.SetCooldown(this.cronometroAtaque);
    }

    protected virtual void Morrer(){
        this.diretor.AtualizarPontos();
        GameObject.Destroy(this.gameObject);
    }
}
