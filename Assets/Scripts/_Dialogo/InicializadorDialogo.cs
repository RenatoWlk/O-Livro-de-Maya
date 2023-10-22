using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializadorDialogo : MonoBehaviour
{
    //script para iniciar o dialogo (coloquei esse script em tudo que começa um diálogo)
    [SerializeField]
    private Dialogos gerenciador; //guarda o gerenciador que contém os objetos do diálogo na cena e os métodos de inicialização
    [SerializeField]
    private Dialogo dialogo; //guarda o dialogo que eu colocar no objeto que tiver esse script

    public void Inicializa() //chamo esse método quando precisar iniciar o dialogo
    {
        if(gerenciador == null) 
        {
            return; //se não tiver gerenciador ele não inicializa
        }

        gerenciador.Inicializa(dialogo); //usa o método de inicialização e inicializa o dialogo que eu coloquei
    }
}
