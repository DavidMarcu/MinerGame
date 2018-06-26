﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlocks : MonoBehaviour {

    public GameObject block;

    // Use this for initialization
    void Start () {
        float xCoord = -4f;
        float yCoord = 0f;

        int noBlocksPerColumn = 9;
        int noBlocksPerRow = 14;

        generateBlocks(xCoord, yCoord, 0f, noBlocksPerColumn, noBlocksPerRow); // foreground

        generateBlocks(xCoord, yCoord, 1f, noBlocksPerColumn, noBlocksPerRow); // background
    }

    void generateBlocks(float xCoord, float yCoord, float zCoord, int noBlocksPerColumn, int noBlocksPerRow)
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
