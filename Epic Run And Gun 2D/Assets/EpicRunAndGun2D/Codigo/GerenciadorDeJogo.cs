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
        ContinuarJogo();
    }

    // Este metódo é chamado pela Unity no incio de cada quadro/frame.
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (Time.timeScale == 1)
                {
                    PausarJogo();
                }
                else
                {
                    ContinuarJogo();
                }
            }
        }
    }

    public void PausarJogo()
    {
        Time.timeScale = 0;

        if (painelJogoPausado == true)
        {
            painelJogoPausado.SetActive(true);
        }
    }

    public void ContinuarJogo()
    {
        Time.timeScale = 1;
        
        if (painelJogoPausado == true)
        {
            painelJogoPausado.SetActive(false);
        }
    }

    public void GanharJogo()
    {
        PausarJogo();
        
        if (somAoGanharJogo == true)
        {
            somAoGanharJogo.Play();
        }
        
        if (painelGanharJogo == true)
        {
            painelGanharJogo.SetActive(true);
        }
    }

    public void PerderJogo()
    {
        if (painelPerderJogo == true)
        {
            painelPerderJogo.SetActive(true);
        }
        
        if (somAoPerderJogo == true)
        {
            somAoPerderJogo.Play();
        }
        
        Time.timeScale = 0;
    }
}
