using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public static MaterialManager Instance;
    public MaterialData materialData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeMaterials()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject[] upperObstacles = GameObject.FindGameObjectsWithTag("UpperObstacle");
        GameObject[] lowerObstacles = GameObject.FindGameObjectsWithTag("LowerObstacle");

        if (player != null && upperObstacles.Length > 0 && lowerObstacles.Length > 0)
        {
            GameObject upperObstacle = upperObstacles[0];
            GameObject lowerObstacle = lowerObstacles[0];

            if (upperObstacle != null && lowerObstacle != null)
            {
                Material tempMaterial = player.GetComponent<Renderer>().material;
                player.GetComponent<Renderer>().material = upperObstacle.GetComponent<Renderer>().material;
                upperObstacle.GetComponent<Renderer>().material = lowerObstacle.GetComponent<Renderer>().material;
                lowerObstacle.GetComponent<Renderer>().material = tempMaterial;
            }
        }
    }
}


