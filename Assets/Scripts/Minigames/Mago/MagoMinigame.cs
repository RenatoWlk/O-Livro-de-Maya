using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MagoMinigame : MonoBehaviour
{
    [SerializeField] private UnityEvent dialogoInicio;
    [SerializeField] private UnityEvent dialogoFim;
    private Camera cam;
    public Animator transicao;
    public bool minigame;
    private bool iniciar = false, mirtilo = false, morango = false, laranja = false, sair;
    public bool Iniciar { get {return iniciar;} set { if(iniciar != value){ iniciar = value; StartCoroutine(IniciarMG()); } } }
    public bool Mirtilo { get {return mirtilo;} set { if(mirtilo != value){ mirtilo = value; contador++; } } }
    public bool Morango { get {return morango;} set { if(morango != value){ morango = value; contador++; } } }
    public bool Laranja { get {return laranja;} set { if(laranja != value){ laranja = value; contador++; } } }
    public float tempoTransicao;
    private int contador;
    public static MagoMinigame instance;
    
    void Start()
    {
        instance = this;
        cam = Camera.main;
    }

    void Update()
    {
        ContadorDeSucos();
        SairMinigame();
    }
    
    IEnumerator IniciarMG()
    {
        transicao.SetTrigger("inicio");
        yield return new WaitForSeconds(tempoTransicao);
        minigame = true;
        cam.GetComponent<Camera2D>().enabled = false;
        Camera2D.instance.yMin = 120f;
        cam.transform.position = new Vector3(0f, 125f, -10f);
        transicao.SetTrigger("fim");
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(4.43f, 108.55f, 0f);
        StartCoroutine(IniciarDialogo());
    }

    IEnumerator Sair()
    {
        transicao.SetTrigger("inicio");
        yield return new WaitForSeconds(tempoTransicao);
        minigame = false;
        cam.GetComponent<Camera2D>().enabled = true;
        Camera2D.instance.yMin = 110f;
        transicao.SetTrigger("fim");
    }

    IEnumerator IniciarDialogo()
    {
        yield return new WaitForSeconds(0.5f);
        dialogoInicio.Invoke();
    }

    void ContadorDeSucos()
    {
        if(PegarMirtilo.instance.clicou == true)
        {
            Mirtilo = true;
        }
        if(PegarMorango.instance.clicou == true)
        {
            Morango = true;
        }
        if(PegarLaranja.instance.clicou == true)
        {
            Laranja = true;
        }
    }

    void SairMinigame()
    {
        if(contador == 3)
        {
            dialogoFim.Invoke();
            sair = true;
            contador++;
        }

        if(Dialogos.instance.dialogoAberto == false && sair)
        {
            StartCoroutine(Sair());
            sair = false;
        }
    }
}
