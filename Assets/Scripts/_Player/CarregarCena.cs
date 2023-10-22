using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarregarCena : MonoBehaviour
{
    public float tempoDeTransicao;
    public GameObject fade;
    public Animator transicao;
    public Slider slider;

    public void Start()
    {
        fade.SetActive(true);
    }

    public void MudarCena(string nomeFase)
    {
        StartCoroutine(Loading(nomeFase));
    }

    IEnumerator Loading(string proximaFase)
    {
        transicao.SetTrigger("inicio");
        AsyncOperation operacao = SceneManager.LoadSceneAsync(proximaFase);

        while(!operacao.isDone)
        {
            float progresso = Mathf.Clamp01(operacao.progress / 0.9f);
            slider.value = progresso;
            yield return null;
        }
    }
}
