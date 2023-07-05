using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scene", menuName = "Example/Scene")]
public class SceneObject : ScriptableObject
{
    public float totalTime;
    public int cameraPosition;
    public Sprite characterSprite;
}
