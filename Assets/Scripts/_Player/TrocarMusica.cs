using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrocarMusica : MonoBehaviour
{
    [SerializeField]
    private UnityEvent trocarMusica;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            TrocarDeMusica();
        }
    }

    void TrocarDeMusica()
    {
        trocarMusica.Invoke();
    }
}
