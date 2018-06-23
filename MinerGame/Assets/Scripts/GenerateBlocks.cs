using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlocks : MonoBehaviour {

    public GameObject block;

    private float xCoord = -4f;
    private float yCoord = 0f;

    private int noBlocksPerColumn = 9;
    private int noBlocksPerRow = 14;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < noBlocksPerRow; ++i)
        {
            for (int j = 0; j < noBlocksPerColumn; ++j)
            {
                Instantiate(block, new Vector3((xCoord + j), (yCoord - i), 0f), Quaternion.identity);
            }
        }
	}
}
