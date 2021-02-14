using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNodeSelector : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject selection;

    public bool isActive { get { return selection.activeSelf; } }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMask))
        {
            GraphNode graphNode = hitInfo.collider.GetComponent<GraphNode>();

            selection.SetActive(true);
            selection.transform.position = hitInfo.collider.transform.position;

            if (Input.GetMouseButtonDown(1))
            {
                if (Input.GetKey(KeyCode.S))
                {
                    GraphNode.clearNodeType(GraphNode.Type.Source);
                    graphNode.type = GraphNode.Type.Source;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    GraphNode.clearNodeType(GraphNode.Type.Destination);
                    graphNode.type = GraphNode.Type.Destination;
                }
            }

        }
        else
        {
            selection.SetActive(false);
        }
    }
}
