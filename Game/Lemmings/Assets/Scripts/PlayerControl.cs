using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour {

    public NavMeshSurface surf;
    public Camera mainCamera;
    public Material groundRed;

    Ray mouseRay;
    RaycastHit rayHit;
    int layerMask;
    int area;

    private void Start()
    {
        //Ignores collisions on all layers except int given
        layerMask = 1 << 9; //GROUND
        area = 3; //RED
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Raycast from mouse to background layer
            mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out rayHit, Mathf.Infinity, layerMask))
            {
                GameObject ground = rayHit.collider.gameObject;
                NavMeshModifier mod = ground.GetComponent<NavMeshModifier>();

                mod.area = area;
                surf.BuildNavMesh();

                Renderer groundRenderer = ground.GetComponent<Renderer>();
                groundRenderer.material = groundRed;
            }
        }
    }
}
