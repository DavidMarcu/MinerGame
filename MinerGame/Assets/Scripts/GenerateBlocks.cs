using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlocks : MonoBehaviour {

    public GameObject block;
    public const float xCoord = -4f;

    // Use this for initialization
    void Start () {
        float yCoord = 0f;

        int noBlocksPerColumn = 9;
        int noBlocksPerRow = 15;

        GenerateBlockLayers(xCoord, yCoord, 0f, noBlocksPerColumn, noBlocksPerRow); // foreground

        GenerateBlockLayers(xCoord, yCoord, 1f, noBlocksPerColumn, noBlocksPerRow); // background
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
