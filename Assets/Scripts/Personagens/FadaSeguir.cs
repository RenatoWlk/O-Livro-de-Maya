using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadaSeguir : MonoBehaviour
{
    public Transform mayaPos;
    private Animator anim;
    private Rigidbody2D rig;
    public float velocidade;
    public float distanciaMaya;
    public static FadaSeguir instance;

    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(InteragirFada.instance.interagiu == true)
        {
            Seguir();
        }
    }

    public void Seguir()
    {
        float distancia = Vector2.Distance(transform.position, mayaPos.position);

        if(distancia > distanciaMaya)
        {
            transform.position = Vector2.MoveTowards(transform.position, mayaPos.position, velocidade * Time.deltaTime);
            anim.SetBool("andando", true);
        }
        else
        {
            anim.SetBool("andando", false);
        }

        if(mayaPos.position.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }
}
