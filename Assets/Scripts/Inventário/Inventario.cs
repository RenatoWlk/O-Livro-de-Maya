using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public Item[] item; //adiciona a classe item ao script do inventário
    public static Inventario instance; //usar os métodos desse script em outros

    void Start()
    {
        instance = this;
    }

    public void AdicionarItem(int itemId) //método para adicionar itens no inventário, usa como parâmetro o id do item
    {
        item[itemId].imagem.SetActive(true); //ativa a imagem do item no inventário
        item[itemId].silhueta.SetActive(false); //desativa a silhueta do item
    }

    public void UsarItem(int itemId) //método para ativar o símbolo de usado quando o item é usado
    {
        item[itemId].usou.SetActive(true); //ativa o símbolo
    }
}