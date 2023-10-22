using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirMenu : MonoBehaviour
{
    public GameObject menu, inventario, objetivos, ajustes;

    public void AbrirOMenu()
    {
        if(Dialogos.instance.dialogoAberto == false && menu.activeSelf == false)
        {
            menu.SetActive(true);
        }
    }

    public void Voltar()
    {
        menu.SetActive(false);
    }

    public void AbrirInventario()
    {
        inventario.SetActive(true);
        objetivos.SetActive(false);
        ajustes.SetActive(false);
    }

    public void AbrirObjetivos()
    {
        objetivos.SetActive(true);
        inventario.SetActive(false);
        ajustes.SetActive(false);
    }

    public void AbrirAjustes()
    {
        ajustes.SetActive(true);
        objetivos.SetActive(false);
        inventario.SetActive(false);
    }

    public void VoltarProMenu()
    {
        inventario.SetActive(false);
        objetivos.SetActive(false);
        ajustes.SetActive(false);
    }
}
