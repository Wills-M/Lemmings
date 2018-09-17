using System;
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
    int offset;

    private void Start()
    {
        //Ignores collisions on all layers except int given
        layerMask = 1 << 9; //GROUND
        offset = 2;
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

                int currColor = Mathf.Clamp(mod.area - offset, 0, 7);
                int newColor = currColor ^ (int)Player.Instance.CurrentColor;
                mod.area = newColor + offset;
                surf.BuildNavMesh();

                Renderer groundRenderer = ground.GetComponent<Renderer>();

                switch ((Color)newColor)
                {
                    case Color.None:
                        groundRenderer.material.color = UnityEngine.Color.white;
                        break;
                    case Color.Red:
                        groundRenderer.material.color = new UnityEngine.Color(0.6981132f, 0.02305092f, 0.02305092f);
                        break;
                    case Color.Yellow:
                        groundRenderer.material.color = UnityEngine.Color.yellow;
                        break;
                    case Color.Orange:
                        groundRenderer.material.color = new UnityEngine.Color(1f, 0.5568628f, 0);
                        break;
                    case Color.Blue:
                        groundRenderer.material.color = UnityEngine.Color.blue;
                        break;
                    case Color.Purple:
                        groundRenderer.material.color = new UnityEngine.Color(0.6074608f, 0, 0.8867924f);
                        break;
                    case Color.Green:
                        groundRenderer.material.color = UnityEngine.Color.green;
                        break;
                    case Color.Black:
                        groundRenderer.material.color = UnityEngine.Color.black;
                        break;
                }
            }
        }
    }
}
