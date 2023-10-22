using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public static bool estaEmMinigame()
    {
        if(PantanoMinigame.instance.minigame == false && JardimMinigame.instance.minigame == false && MagoMinigame.instance.minigame == false)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
