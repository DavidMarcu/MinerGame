using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlocks : MonoBehaviour
{
    private GameObject[] blocks;
    private Vector3[] newBlockPositions;
    private float animationTimeBlock = 5f;

    public Camera gameCamera;
    public GameObject player;

    private Ray ray;
    private RaycastHit raycastHit;

    private Vector3 newPosition;
    
    public float playerSpeed = 3f;

    private void Start()
    {
        newPosition = player.transform.position;

        SetBlockPositions();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = gameCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycastHit) && CubeIsNearThePlayer())
            {
                Destroy(raycastHit.transform.gameObject);
            }
        }

        MoveThePlayer();
        MoveTheBlocks();
    }

    private void SetBlockPositions()
    {
        blocks = GameObject.FindGameObjectsWithTag("Block");
        int initialize = blocks.Length;
        newBlockPositions = new Vector3[initialize];
        int i = 0;
        foreach (GameObject block in blocks)
        {
            newBlockPositions[i] = block.transform.position;
            i++;
        }
    }

    private void SetBlocksNewPositions()
    {
        blocks = GameObject.FindGameObjectsWithTag("Block");
        newBlockPositions = null;
        int initialize = blocks.Length;
        newBlockPositions = new Vector3[initialize];
        int i = 0;
        foreach (GameObject block in blocks)
        {
            newBlockPositions[i] = block.transform.position + Vector3.up;
            i++;
        }
    }

    void MoveThePlayer()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, newPosition, Time.deltaTime * playerSpeed);
    }

    void MoveTheBlocks()
    {
        int i = 0;
        foreach (GameObject block in blocks)
        {
            if (block != null)
                block.transform.position = Vector3.MoveTowards(block.transform.position, newBlockPositions[i], Time.deltaTime * animationTimeBlock);
            i++;
        }
    }
   

    bool CubeIsNearThePlayer()
    {

        if (player.transform.position.z == raycastHit.transform.position.z)
        {
            if(CubeIsSidewaysThePlayer() || CubeIsUnderThePlayer())
            {
                return true;
            }
        }

        return false;
    }

    bool CubeIsUnderThePlayer()
    {
        if (Mathf.Abs(raycastHit.transform.position.x) != Mathf.Abs(GenerateBlocks.xCoord))
        {
            if (player.transform.position.y == (raycastHit.transform.position.y + 1))
            {
                if (player.transform.position.x == raycastHit.transform.position.x)
                {
                    // change blocks positions
                    SetBlocksNewPositions();
                    InfiniteGererator.allowToGenerate = true; // permitem generarea unui nou layer
                    return true;
                }
            }
        }
        
        return false;
    }

    bool CubeIsSidewaysThePlayer()
    {
        if (Mathf.Abs(raycastHit.transform.position.x) != Mathf.Abs(GenerateBlocks.xCoord))
        {
            if (player.transform.position.y == raycastHit.transform.position.y)
            {
                if (Mathf.Abs(player.transform.position.x - raycastHit.transform.position.x) == 1)
                {
                    // change the player's position
                    newPosition = new Vector3(raycastHit.transform.position.x, player.transform.position.y, player.transform.position.z);
                    return true;
                }
            }
        }

        return false;
    }
}
