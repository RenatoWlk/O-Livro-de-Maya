using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CutscenesFinal : MonoBehaviour
{
    public List<GameObject> cenas;
    public int contador = 0;
    [SerializeField]
    private UnityEvent dialogo;
    [SerializeField]
    private UnityEvent carta;
    public GameObject caixaDialogo;

    void Start()
    {
        contador = 0;
        dialogo.Invoke();
    }

    void Update()
    {
        if(contador == 0)
        {
            caixaDialogo.SetActive(false);
        }
    }

    public void TrocarDeCena()
    {
        contador++;
        if(contador < 14)
        {
            cenas[contador].SetActive(true);
        }

        if(contador == 1)
        {
            caixaDialogo.SetActive(true);
        }

        if(contador == 10)
        {
            caixaDialogo.SetActive(false);
        }

        if(contador == 11)
        {
            caixaDialogo.SetActive(true);
        }

        if(contador == 13)
        {
            caixaDialogo.SetActive(false);
        }

        if(contador == 14)
        {
            Destroy(caixaDialogo);
            carta.Invoke();
        }
    }
}
