using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadaSair : MonoBehaviour
{
    public Transform saida;
    private Animator anim;
    public float velocidade;
    public static FadaSair instance;

    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0f, 180f, 0f);
        transform.position = Vector2.MoveTowards(transform.position, saida.position, velocidade * Time.deltaTime);
        anim.SetBool("andando", true);

        if(Vector3.Distance(gameObject.transform.position, saida.position) < 0.5f)
        {
            gameObject.SetActive(false);
        }
    }
}
