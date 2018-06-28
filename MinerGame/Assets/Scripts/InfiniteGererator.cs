using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGererator : MonoBehaviour {

    public static bool allowToGenerate = false;

    public GameObject block;

    private float yPos = -7f;
    private float xPos = -4f;
    private int noBlocksPerColumn = 9;
    private int noBlocksPerRow = 1;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        if (allowToGenerate)
        {
            GenerateBlockLayers(xPos, yPos, 0f, noBlocksPerColumn, noBlocksPerRow);
            GenerateBlockLayers(xPos, yPos, 1f, noBlocksPerColumn, noBlocksPerRow);
            allowToGenerate = false;
        }

    }

    public void GenerateBlockLayers(float xCoord, float yCoord, float zCoord, int noBlocksPerColumn, int noBlocksPerRow)
    {
        for (int i = 0; i < noBlocksPerRow; ++i)
        {
            for (int j = 0; j < noBlocksPerColumn; ++j)
            {
                Instantiate(block, new Vector3((xCoord + j), (yCoord - i), zCoord), Quaternion.identity);
            }
        }
    }

}
