using UnityEngine;

public class MorteComportamento : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D outroObjeto)
    {
        switch (outroObjeto.gameObject.tag)
        {
            case "Player":
                outroObjeto.transform.DetachChildren();
                Destroy(outroObjeto.gameObject);
                break;
            case "Inimigo":
                Destroy(outroObjeto.gameObject);
                break;
        }
    }
    
}
