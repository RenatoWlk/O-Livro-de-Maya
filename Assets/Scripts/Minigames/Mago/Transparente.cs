using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparente : MonoBehaviour
{
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnMouseOver()
    {
        sprite.color = new Color32(255, 255, 255, 50);
    }

    void OnMouseExit()
    {
        sprite.color = new Color32(255, 255, 255, 255);
    }
}
