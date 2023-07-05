using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    public Text colouredFont;

    void OnMouseOver()
    {
        colouredFont.color = new Color(); // Color.purple;
    }
}
