using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialData", menuName = "ScriptableObjects/MaterialData", order = 1)]
public class MaterialData : ScriptableObject
{
    public Material playerMaterial;
    public Material upperPipeMaterial;
    public Material lowerPipeMaterial;
}

