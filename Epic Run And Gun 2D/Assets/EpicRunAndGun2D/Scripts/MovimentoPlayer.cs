using System;
using Unity.VisualScripting;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    // Variaveis publicas.
    public float velocidadeCaminhar = 5f;
    public float forcaPulo = 7f;
    public Rigidbody2D rigidbody2D;
    private bool seEstaNoChao = true;
    
    // Variaveis privadas.
    private float controleHorizontal;
    
    // Este metódo é chamado pela Unity no incio do jogo.
    private void Start()
    {
        
    }

    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    private void Update()
    {
        controleHorizontal = Input.GetAxis("Horizontal");
        Caminhe();
        
        if(Input.GetButtonDown("Jump"))
        {
            Pule();
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

    private void Caminhe()
    {
        transform.Translate(new Vector2(controleHorizontal * velocidadeCaminhar * Time.deltaTime, 0));
    }

    private void Pule()
    {
        if (rigidbody2D == true && seEstaNoChao == true)
        {
            rigidbody2D.AddForceY(forcaPulo, ForceMode2D.Impulse);
        }
    }
}
