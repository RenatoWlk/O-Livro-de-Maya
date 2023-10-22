using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float tempoDeTransicao;
    public GameObject fade;
    public Animator transicao;

    public void Start()
    {
        fade.SetActive(true);
    }

    public void MudarCena(string nomeFase)
    {
        StartCoroutine(ProximaCena(nomeFase));
    }

    public void Sair()
    {
        Application.Quit();
    }

    IEnumerator ProximaCena(string proximaFase)
    {
        transicao.SetTrigger("inicio");
        yield return new WaitForSeconds(tempoDeTransicao);
        SceneManager.LoadScene(proximaFase);
    }
}
