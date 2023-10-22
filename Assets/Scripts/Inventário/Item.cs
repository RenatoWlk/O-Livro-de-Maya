using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    //classe item guarda o id e os sprites que serão alterados durante o jogo (classe usada no script do Inventário)
    public string id;
    public GameObject imagem;
    public GameObject silhueta;
    public GameObject usou;
}
