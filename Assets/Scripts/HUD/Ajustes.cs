using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Ajustes : MonoBehaviour
{
    public AudioMixer mixer, mixerDublagem;
    public Slider sliderVolume, sliderDublagem;
    public TMPro.TMP_Dropdown botaoResolucao;
    Resolution[] resolucoes;

    void Start()
    {
        mixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
        sliderVolume.value = PlayerPrefs.GetFloat("volume");
        mixerDublagem.SetFloat("volume", PlayerPrefs.GetFloat("dublagem"));
        sliderDublagem.value = PlayerPrefs.GetFloat("dublagem");

        resolucoes = Screen.resolutions;
        botaoResolucao.ClearOptions();
        List<string> opcoes = new List<string>();

        int resolucaoAtual = 0;
        for(int i = 0; i < resolucoes.Length; i++)
        {
            string opcao = resolucoes[i].width + "x" + resolucoes[i].height + " " + resolucoes[i].refreshRate + "Hz";
            opcoes.Add(opcao);

            if(resolucoes[i].width == Screen.width && resolucoes[i].height == Screen.height)
            {
                resolucaoAtual = i;
            }
        }

        botaoResolucao.AddOptions(opcoes);
        botaoResolucao.value = resolucaoAtual;
        botaoResolucao.RefreshShownValue();
    }

    public void AjustarVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }

    public void AjustarDublagem(float rogerio)
    {
        mixerDublagem.SetFloat("volume", rogerio);
        PlayerPrefs.SetFloat("dublagem", rogerio);
        PlayerPrefs.Save();
    }

    public void Fullscreen(bool roberto)
    {
        Screen.fullScreen = roberto;
    }

    public void Resolucao(int reginaldo)
    {
        Resolution resolucao =  resolucoes[reginaldo];
        Screen.SetResolution(resolucao.width, resolucao.height, Screen.fullScreen);
    }
}
