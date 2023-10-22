using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Carta : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Texto;
    [TextArea(1,10)]
    public string textoCarta;
    public float tempoDeEscrita;
    public Animator cartaAnim, botaoAnim;
    public AudioSource dublagem;
    private bool roger;
    public GameObject botao, carta, creditos, creditos2;
    [SerializeField] private UnityEvent voltarMenu;

    void Start()
    {
        Texto.text = "";
        StartCoroutine(DigitarTexto(textoCarta));
        StartCoroutine(DublarCarta());

        cartaAnim.SetTrigger("aparecer");
    }

    void Update()
    {
        if(Texto.text == textoCarta && roger == false)
        {
            botao.SetActive(true);
            roger = true;
        }
    }

    IEnumerator DigitarTexto(string fraseAtual)
    {
        yield return new WaitForSeconds(2f);
        Texto.text = "";
        foreach(char letra in fraseAtual.ToCharArray())
        {
            Texto.text += letra;
            yield return new WaitForSeconds(tempoDeEscrita);
        }
    }

    IEnumerator DublarCarta()
    {
        yield return new WaitForSeconds(2f);
        dublagem.Play();
    }

    public void BotaoContinuar()
    {
        StartCoroutine(SumirCarta());
    }

    IEnumerator SumirCarta()
    {
        cartaAnim.SetTrigger("sumir");
        botaoAnim.SetTrigger("sumir");
        yield return new WaitForSeconds(2f);
        carta.SetActive(false);
        botao.SetActive(false);
        StartCoroutine(AparecerCreditos());
    }

    IEnumerator AparecerCreditos()
    {
        creditos.SetActive(true);
        yield return new WaitForSeconds(15f);
        creditos.SetActive(false);
        StartCoroutine(AparecerCreditos2());
    }

    IEnumerator AparecerCreditos2()
    {
        creditos2.SetActive(true);
        yield return new WaitForSeconds(15f);
        creditos2.SetActive(false);
        voltarMenu.Invoke();
    }
}
