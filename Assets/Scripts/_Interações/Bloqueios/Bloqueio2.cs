using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bloqueio2 : MonoBehaviour
{
    [SerializeField]
    private UnityEvent colidiuFada;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            colidiuFada.Invoke();
        }
    }
}
