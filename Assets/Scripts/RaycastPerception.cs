using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPerception : Perception
{
    public Transform raycastTransform;
    [Range(1, 40)] public float distance;
    [Range(0, 90)] public float angle;
    [Min(2)] public int numRaycast = 1;

    public override GameObject[] getGameObjects()
    {
        List<GameObject> gameObjects = new List<GameObject>();

        float angleOffset = 2 * angle / numRaycast - 1;

        for (int i = 0; i < numRaycast; i++)
        {
            float rayDistance = distance;


            Quaternion rotation = Quaternion.AngleAxis(-angle + angleOffset * i, Vector3.up);
            Vector3 forward = rotation * raycastTransform.forward;

            Ray ray = new Ray(raycastTransform.position, forward);
            if(Physics.Raycast(ray, out RaycastHit raycastHit, distance))
            {
                rayDistance = raycastHit.distance;
                gameObjects.Add(raycastHit.collider.gameObject);
            }
            Debug.DrawRay(ray.origin, ray.direction * rayDistance);
        }


        return gameObjects.ToArray();

    }
}
