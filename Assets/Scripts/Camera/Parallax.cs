using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float posInicial; //guarda a posição inicial do objeto no eixo x
    private Transform cam; //guarda o transform da camera
    public float efeito; //valor do parallax

    void Start()
    {
        posInicial = transform.position.x;
        cam = Camera.main.transform;
    }

    void Update()
    {
        float distance = cam.transform.position.x * efeito;
        transform.position = new Vector3(posInicial + distance, transform.position.y, transform.position.z);
    }
}
