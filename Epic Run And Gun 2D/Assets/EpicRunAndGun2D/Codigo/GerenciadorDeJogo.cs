using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorDeJogo : MonoBehaviour
{
    // Variaveis publicas.
    public GameObject painelGanharJogo;
    public AudioSource somAoGanharJogo;
    public GameObject painelPerderJogo;
    public AudioSource somAoPerderJogo;
    public GameObject painelJogoPausado;

    // Este metódo é chamado pela Unity no incio do jogo.
    private void Start()
    {
        // Despausa o jogo.
        ContinuarJogo();
    }

    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            // Ao apertar P.
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (Time.timeScale == 1)
                {
                    // Pausa o jogo.
                    PausarJogo();
                }
                else
                {
                    // Despausa o jogo.
                    ContinuarJogo();
                }
            }
        }
    }

    // Pausa o jogo.
    public void PausarJogo()
    {
        // Pausa o tempo e a física.
        Time.timeScale = 0;

        // Mostra a tela de pausado.
        if (painelJogoPausado == true)
        {
            painelJogoPausado.SetActive(true);
        }
    }

    // Despausa o jogo.
    public void ContinuarJogo()
    {
        // Despausa o tempo e a física.
        Time.timeScale = 1;

        // Oculta a tela de pausado.
        if (painelJogoPausado == true)
        {
            painelJogoPausado.SetActive(false);
        }
    }

    public void GanharJogo()
    {
        // Printa no console.
        Debug.Log("Jogo ganho.");

        // Mostra tela de jogo ganho.
        if (painelGanharJogo == true)
        {
            painelGanharJogo.SetActive(true);
        }

        // Toca som.
        if (somAoGanharJogo == true)
        {
            somAoGanharJogo.Play();
        }
        
        // Pausa o tempo e a física.
        Time.timeScale = 0;
    }

    public void PerderJogo()
    {
        // Printa no console.
        Debug.Log("Game over.");

        // Mostra tela de gamer over.
        if (painelPerderJogo == true)
        {
            painelPerderJogo.SetActive(true);
        }
        
        // Toca som.
        if (somAoPerderJogo == true)
        {
            somAoPerderJogo.Play();
        }
        
        // Pausa o tempo e a física.
        Time.timeScale = 0;
    }
}
