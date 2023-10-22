using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bloqueio3 : MonoBehaviour
{
    [SerializeField]
    private UnityEvent colidiuFada2;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            colidiuFada2.Invoke();
        }
    }
}
