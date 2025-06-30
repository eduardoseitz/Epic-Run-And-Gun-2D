using UnityEngine;

public class NaoDestruirAoCarregarCena : MonoBehaviour
{
    private void Awake()
    {
        transform.SetParent(null);
        DontDestroyOnLoad(this.gameObject);
    }
}
