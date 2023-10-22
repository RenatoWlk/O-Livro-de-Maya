using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TextoDialogo
{
    [SerializeField]
    private string nome; //guarda o nome colocado
    [SerializeField]
    [TextArea(1,3)]
    private string frase; //guarda a frase colocada
    [SerializeField]
    private Sprite reacao; //guarda a imagem de reação colocada
    [SerializeField]
    private AudioClip dublagem; //guarda o áudio de dublagem colocado

    public string GetNome() //método que retorna o nome colocado
    {
        return nome;
    }

    public string GetFrase() //método que retorna a frase colocada
    {
        return frase;
    }

    public Sprite GetReacao() //método que retorna a imagem da reação
    {
        return reacao;
    }

    public AudioClip GetDublagem() //método que retorna o áudio de dublagem colocado
    {
        return dublagem;
    }
}
