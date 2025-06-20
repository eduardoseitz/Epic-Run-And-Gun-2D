using System;
using Unity.VisualScripting;
using UnityEngine;

public class MovimentoJogador : MonoBehaviour
{
    // Variaveis publicas.
    public float velocidadeCaminhar = 5f;
    public float forcaPulo = 7f;
    public Rigidbody2D rigidbody2D;
    
    // Variaveis privadas.
    private float controleHorizontal;
    private bool seEstaNoChao = true;
    private Vector2 escalaOriginal;
    private bool estaSeAbaixando = false;

    // Este metódo é chamado pela Unity no incio do jogo.
    void Start()
    {
        escalaOriginal = transform.localScale;
    }

    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    private void Update()
    {
        controleHorizontal = Input.GetAxis("Horizontal");
        Caminhar();
        
        if(Input.GetButtonDown("Pular"))
        {
            Pular();
        }
        
        if(Input.GetButtonDown("Abaixar"))
        {
            Abaixar();
        }
        else if(Input.GetButtonUp("Abaixar"))
        {
            Levantar();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        seEstaNoChao = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        seEstaNoChao = false;
    }

    private void Caminhar()
    {
        if (estaSeAbaixando == false)
        {
            transform.Translate(new Vector2(controleHorizontal * velocidadeCaminhar * Time.deltaTime, 0));   
        }
    }

    private void Pular()
    {
        if (rigidbody2D == true && seEstaNoChao == true)
        {
            rigidbody2D.AddForceY(forcaPulo, ForceMode2D.Impulse);
        }
    }

    private void Abaixar()
    {
        if (seEstaNoChao == true && estaSeAbaixando == false)
        {
            transform.localScale = new Vector2(escalaOriginal.x, escalaOriginal.y / 2);
            estaSeAbaixando = true;
        }
    }
    
    private void Levantar()
    {
        if (estaSeAbaixando == true)
        {
            transform.localScale = escalaOriginal;
            estaSeAbaixando = false;
        }
    }
}
