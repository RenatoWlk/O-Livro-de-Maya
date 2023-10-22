using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bloqueio : MonoBehaviour
{
    [SerializeField]
    private UnityEvent colidiu;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            colidiu.Invoke();
        }
    }
}
