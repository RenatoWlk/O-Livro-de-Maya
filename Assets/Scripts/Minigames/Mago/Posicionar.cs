using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posicionar : MonoBehaviour
{
    public List<Vector3> posicoes = new List<Vector3>();
    private int num;
    List<int> numsUsados = new List<int>();
    public GameObject[] sucos;

    void Start()
    {
        PosicionarObjetos();
    }

    void Update()
    {
        if(PegarMorango.instance.objeto == null || PegarMirtilo.instance.objeto == null || PegarLaranja.instance.objeto == null)
        {
            PosicionarObjetos();
        }
    }

    void PosicionarObjetos()
    {
        numsUsados.Clear();
        for(int i = 0; i < sucos.Length; i++)
        {
            do
            {
                num = Random.Range(0, posicoes.Count);
            } 
            while(numsUsados.Contains(num));
            sucos[i].transform.position = posicoes[num];
            numsUsados.Add(num);
        }
    }
}
