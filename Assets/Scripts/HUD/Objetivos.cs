using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objetivos : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Objetivo1;
    [SerializeField]
    private TextMeshProUGUI Objetivo2;
    [SerializeField]
    private TextMeshProUGUI Objetivo3;
    private bool iniciarNot;
    public Animator notificacao;

    void Start()
    {
        Objetivo2.text = "";
        Objetivo3.text = "";
    }

    void Update()
    {
        if(iniciarNot == true && Dialogos.instance.dialogoAberto == false)
        {
            StartCoroutine(NotificacaoDeObjetivo());
        }
    }

    public void AtualizarObjetivo1(string texto)
    {
        Objetivo1.text = "";
        Objetivo1.text = texto;
        iniciarNot = true;
    }

    public void AtualizarObjetivo2(string texto)
    {
        Objetivo2.text = "";
        Objetivo2.text = texto;
        iniciarNot = true;
    }

    public void AtualizarObjetivo3(string texto)
    {
        Objetivo3.text = "";
        Objetivo3.text = texto;
        iniciarNot = true;
    }

    IEnumerator NotificacaoDeObjetivo()
    {
        iniciarNot = false;
        notificacao.SetTrigger("inicio");
        yield return new WaitForSeconds(4f);
        notificacao.SetTrigger("fim");
        yield return new WaitForSeconds(0.5f);
        notificacao.SetTrigger("normal");
    }
}
