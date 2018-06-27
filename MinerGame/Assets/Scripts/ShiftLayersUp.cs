using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftLayersUp : MonoBehaviour {

    private static GameObject player;
    private static GameObject[] blocks;

    public static void shiftLayersUp()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        blocks = GameObject.FindGameObjectsWithTag("Block");

        player.transform.position += Vector3.up;

        foreach (GameObject block in blocks)
        {
            block.transform.position += Vector3.up;
        }
    }
}
