using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CutscenesInicio : MonoBehaviour
{
    public List<GameObject> cenas;
    public int contador = 0;
    [SerializeField]
    private UnityEvent comeco;
    [SerializeField]
    private UnityEvent dialogo;
    public GameObject caixaDialogo;

    void Start()
    {
        contador = 0;
        dialogo.Invoke();
    }

    public void TrocarDeCena()
    {
        contador++;
        if(contador < 13)
        {
            cenas[contador].SetActive(true);
        }

        if(contador == 2)
        {
            caixaDialogo.SetActive(false);
        }

        if(contador == 3)
        {
            caixaDialogo.SetActive(true);
        }

        if(contador == 12)
        {
            caixaDialogo.SetActive(false);
        }

        if(contador == 13)
        {
            comeco.Invoke();
            Destroy(caixaDialogo);
        }
    }
}
