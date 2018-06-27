using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlocks : MonoBehaviour
{

    public Camera gameCamera;
    public GameObject player;

    private Ray ray;
    private RaycastHit raycastHit;

    private Vector3 newPosition;
    
    public float animationTime = 3f;
    private float currentTime;
    private bool ableToMove = false;

    private void Start()
    {
        newPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = gameCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycastHit) && cubeIsNearThePlayer())
            {
                //Debug.Log(raycastHit.transform.position);
                Destroy(raycastHit.transform.gameObject);
                setNewPositionToThePlayer();
                //ableToMove = true;
                //currentTime = Time.time;
            }
        }

        moveThePlayer();
    }

    void moveThePlayer()
    {
        // && (Time.time < (currentTime + animationTime))
        //if (ableToMove)
        //{
            player.transform.position = Vector3.MoveTowards(player.transform.position, newPosition, Time.deltaTime * animationTime);
        //}
        /*else
        {
            ableToMove = false;
            player.transform.position = newPosition;
        }*/
        //Debug.Log(Mathf.Sin(Time.time));
    }

    void setNewPositionToThePlayer()
    {
        if(cubeIsSidewaysThePlayer())
        {
            newPosition = new Vector3(raycastHit.transform.position.x, player.transform.position.y, player.transform.position.z);
            //player.transform.position = Vector3.Lerp(player.transform.position, newPosition, Time.deltaTime*lerpSpeed);
        }

        if(cubeIsUnderThePlayer())
        {
            newPosition = player.transform.position + Vector3.down;
            //gameCamera.transform.position += Vector3.down;
        }
    }

    bool cubeIsNearThePlayer()
    {

        if (player.transform.position.z == raycastHit.transform.position.z)
        {
            if(cubeIsSidewaysThePlayer() || cubeIsUnderThePlayer())
            {
                return true;
            }
        }

        return false;
    }

    bool cubeIsUnderThePlayer()
    {
        if (Mathf.Abs(raycastHit.transform.position.x) != Mathf.Abs(GenerateBlocks.xCoord))
        {
            if (player.transform.position.y == (raycastHit.transform.position.y + 1))
            {
                if (player.transform.position.x == raycastHit.transform.position.x)
                {
                    ShiftLayersUp.shiftLayersUp();
                    return true;
                }
            }
        }
        
        return false;
    }

    bool cubeIsSidewaysThePlayer()
    {
        if (Mathf.Abs(raycastHit.transform.position.x) != Mathf.Abs(GenerateBlocks.xCoord))
        {
            if (player.transform.position.y == raycastHit.transform.position.y)
            {
                if (Mathf.Abs(player.transform.position.x - raycastHit.transform.position.x) == 1)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
