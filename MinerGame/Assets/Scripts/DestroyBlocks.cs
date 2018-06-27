using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlocks : MonoBehaviour
{

    public Camera gameCamera;
    public GameObject player;

    private Ray ray;
    private RaycastHit raycastHit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = gameCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycastHit) && cubeIsNearThePlayer())
            {
                Debug.Log(raycastHit.transform.position);
                Destroy(raycastHit.transform.gameObject);
            }
        }
    }

    bool cubeIsNearThePlayer()
    {

        if (player.transform.position.z == raycastHit.transform.position.z)
        {
            if (player.transform.position.y == raycastHit.transform.position.y)
            {
                if(Mathf.Abs(player.transform.position.x - raycastHit.transform.position.x) == 1)
                {
                    return true;
                }
            }

            if (player.transform.position.y == (raycastHit.transform.position.y + 1))
            {
                if (Mathf.Abs(player.transform.position.x - raycastHit.transform.position.x) <= 1)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
