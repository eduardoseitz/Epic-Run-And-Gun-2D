using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorDeCena : MonoBehaviour
{
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                CarregarCena(0);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                ReiniciarCena();
            }
        }
    }

    // Carrega a cena especifica pelo numero.
    public void CarregarCena(int indexDaCena = 1)
    {
        SceneManager.LoadScene(indexDaCena);
    }
    
    // Recarrega a cena atual.
    public void ReiniciarCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
