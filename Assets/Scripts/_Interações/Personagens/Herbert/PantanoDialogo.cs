using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PantanoDialogo : MonoBehaviour
{
    [SerializeField]
    private UnityEvent dialogoPantanoInicio;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(IniciarDialogo());
        }
    }

    IEnumerator IniciarDialogo()
    {
        yield return new WaitForSeconds(1f);
        dialogoPantanoInicio.Invoke();
        Destroy(gameObject);
    }
}
