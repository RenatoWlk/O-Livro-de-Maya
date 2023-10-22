using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piscar : MonoBehaviour
{
    private Animator anim;
    float tempo;
    public float tempoMax;
    public float tempoPiscada;

    void Start()
    {
        tempo = tempoMax;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        tempo -= Time.deltaTime;

        if(tempo <= 0f)
        {
            StartCoroutine(Pisca());
            tempo = tempoMax;
        }
    }

    IEnumerator Pisca()
    {
        anim.SetBool("piscou", true);
        yield return new WaitForSeconds(tempoPiscada);
        anim.SetBool("piscou", false);
    }
}
