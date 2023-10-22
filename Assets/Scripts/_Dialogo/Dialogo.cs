using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Dialogo //classe do dialogo que retorna cada fala colocada
{
    [SerializeField]
    private TextoDialogo[] frases; //adiciona a classe que contém os nomes, as frases, as reações e as dublagens

    public TextoDialogo[] GetFrases() //método que retorna as frases
    {
        return frases;
    }
}
