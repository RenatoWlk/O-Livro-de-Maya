using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAteMenu : MonoBehaviour
{
    public float tempo = 25;
    public bool irAteHUD;
    public Transform HUD;

    void Update()
    {
        if(irAteHUD)
        {
            transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(HUD.position), tempo * Time.deltaTime);

            if((Vector2)transform.position == (Vector2)Camera.main.ScreenToWorldPoint(HUD.position))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
