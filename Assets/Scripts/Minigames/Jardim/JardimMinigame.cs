using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JardimMinigame : MonoBehaviour
{
    private Camera cam;
    public Animator transicao, vitrola;
    public GameObject yafit2, yafit3, yafit4, discosVitrola, girassois, felizes, assustadas, dormindo, decidir;
    [SerializeField] private UnityEvent dialogoInicial;
    public bool minigame;
    private bool azul, vermelho, amarelo;
    private bool iniciar = false;
    public bool Iniciar { get {return iniciar;} set { if(iniciar != value){ iniciar = value; StartCoroutine(IniciarMG()); } } }
    public float tempoTransicao;
    public static JardimMinigame instance;
    
    void Start()
    {
        instance = this;
        cam = Camera.main;
    }

    void Update()
    {
        if(azul == true && amarelo == true && vermelho == true)
        {
            decidir.SetActive(true);
        }
    }
    
    public IEnumerator IniciarMG()
    {
        transicao.SetTrigger("inicio");
        yield return new WaitForSeconds(tempoTransicao);
        minigame = true;
        cam.GetComponent<Camera2D>().enabled = false;
        Camera2D.instance.yMin = 95.5f;
        cam.transform.position = new Vector3(0f, 95.5f, -10f);
        transicao.SetTrigger("fim");
        yield return new WaitForSeconds(0.5f);
        dialogoInicial.Invoke();
        yafit4.transform.position = new Vector3(15.935f, 30.69f, 0f);
        Destroy(yafit2);
        Destroy(yafit3);
    }

    public IEnumerator Sair()
    {
        transicao.SetTrigger("inicio");
        yield return new WaitForSeconds(tempoTransicao);
        minigame = false;
        cam.GetComponent<Camera2D>().enabled = true;
        Camera2D.instance.yMin = 33f;
        transicao.SetTrigger("fim");
    }

    public void SairMinigame()
    {
        StartCoroutine(Sair());
    }

    public void Discos()
    {
        discosVitrola.SetActive(true);
    }

    public void DiscoAzul()
    {
        azul = true;
        dormindo.SetActive(true);
        vitrola.SetBool("azul", true);
        vitrola.SetBool("amarelo", false);
        vitrola.SetBool("vermelho", false);
        girassois.SetActive(false);
        felizes.SetActive(false);
        assustadas.SetActive(false);
    }

    public void DiscoAmarelo()
    {
        amarelo = true;
        felizes.SetActive(true);
        vitrola.SetBool("amarelo", true);
        vitrola.SetBool("azul", false);
        vitrola.SetBool("vermelho", false);
        girassois.SetActive(false);
        dormindo.SetActive(false);
        assustadas.SetActive(false); 
    }

    public void DiscoVermelho()
    {
        vermelho = true;
        assustadas.SetActive(true);
        vitrola.SetBool("vermelho", true);
        vitrola.SetBool("amarelo", false);
        vitrola.SetBool("azul", false);
        girassois.SetActive(false);
        dormindo.SetActive(false);
        felizes.SetActive(false);
    }

    public void GirassoisNormais()
    {
        girassois.SetActive(true);
        vitrola.SetBool("vermelho", false);
        vitrola.SetBool("amarelo", false);
        vitrola.SetBool("azul", false);
        assustadas.SetActive(false);
        dormindo.SetActive(false);
        felizes.SetActive(false);
    }
}
