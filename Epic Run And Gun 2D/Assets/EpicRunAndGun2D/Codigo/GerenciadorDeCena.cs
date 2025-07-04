using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorDeCena : MonoBehaviour
{
    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    private void Update()
    {
        // Se não estiver no menu.
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            // Ao apertar M.
            if (Input.GetKeyDown(KeyCode.M))
            {
                CarregarCena(0);
            }
            // Ao apertar R.
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
