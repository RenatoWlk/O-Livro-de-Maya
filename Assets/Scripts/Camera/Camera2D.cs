using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    public Transform maya; //guarda a posição da maya para a camera seguir
    public Vector3 offset; //muda o eixo z da camera para consertar bugs
    [Range(1,10)]
    public float velocidadeLerp; //velocidade do lerp da camera
    public float xMin, yMin, xMax, yMax; //valores minimos e maximos da camera
    public static Camera2D instance; //mudo valores desse script em outros, ex: PassarFase e EntrarCasaMago

    void Start()
    {
        instance = this;
    }
    
    void FixedUpdate()
    {
        Seguir(); 
    }

    void Seguir()
    {
        if(yMax != yMin)
        {
            yMax = yMin;
        }
        Vector3 posicaoMaya = maya.position + offset; //cria uma variável que guarda a posição da maya e corrige o eixo z
        Vector3 lerp = Vector3.Lerp(transform.position, posicaoMaya, velocidadeLerp * Time.fixedDeltaTime); //calcula o lerp da camera
        transform.position = new Vector3(Mathf.Clamp(lerp.x, xMin, xMax), Mathf.Clamp(lerp.y, yMin, yMax), offset.z); //faz a posição da camera com o lerp e as delimitações
    }
}
