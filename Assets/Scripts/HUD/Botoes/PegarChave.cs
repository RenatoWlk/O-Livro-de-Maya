using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarChave : MonoBehaviour
{
    public static PegarChave instance;

    void Start()
    {
        instance = this;
    }

    public void SeguirMouse(bool cleber)
    {
        if(cleber == true)
        {
            gameObject.SetActive(true);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            Vector3 posicaoInt = new Vector3(mousePosition.x + 1.1f, mousePosition.y, mousePosition.z);
            transform.position = posicaoInt;
        }

        if(cleber == false)
        {
            gameObject.SetActive(false);
        }
    }
}
