using System;
using UnityEngine;
    
public class GanharJogo : MonoBehaviour
{
    public GerenciadorDeJogo gerenciadorDeJogo;

    private void OnTriggerEnter2D(Collider2D outroObjeto)
    {
        if (outroObjeto.gameObject.tag == "Player")
        {
            gerenciadorDeJogo.GanharJogo();
        }
    }
}