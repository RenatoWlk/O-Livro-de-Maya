using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TalesDialogo : MonoBehaviour
{
    [SerializeField]
    private UnityEvent dialogoTales;
    public GameObject bloqueioPantano;
    public bool primeiroDialogo;
    public static TalesDialogo instance;

    void Start()
    {
        instance = this;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dialogoTales.Invoke();
            Inventario.instance.AdicionarItem(2);
            Destroy(gameObject);
            Destroy(bloqueioPantano);
            primeiroDialogo = true;
        }
    }
}
