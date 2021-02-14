using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistancePerception : Perception
{
    public float distance = 10.0f;
    public float angle = 30.0f;
    public string tagName = "";

    public override GameObject[] getGameObjects()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tagName);

        gameObjects = GetGameObjectsInDistance(gameObjects, distance);
        gameObjects = GetGameObjectsInAngle(gameObjects, angle);
        gameObjects = sortGameObjectsByDistance(gameObjects);

        return gameObjects;
    }

    public GameObject[] GetGameObjectsInDistance(GameObject[] gameObjects, float maxDistance)
    {
        List<GameObject> result = new List<GameObject>();

        foreach(GameObject gameObject in gameObjects)
        {
            if (gameObject == this.gameObject) continue;

            float distance = Vector3.Distance(transform.position, gameObject.transform.position);
            if (distance <= maxDistance)
            {
                result.Add(gameObject);
            }
        }

        return result.ToArray();
    }

    public GameObject[] GetGameObjectsInAngle(GameObject[] gameObjects, float maxAngle)
    {
        List<GameObject> result = new List<GameObject>();

        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject == this.gameObject) continue;

            Vector3 direction = (gameObject.transform.position - transform.position).normalized;

            float dot = Utilities.Dot(transform.forward, direction);
            dot = Mathf.Clamp(dot, -0.99f, 1);
            float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

            if (angle <= maxAngle)
            {
                result.Add(gameObject);
            }
        }

        return result.ToArray();
    }

    public GameObject[] sortGameObjectsByDistance(GameObject[] gameObjects)
    {
        List<GameObject> sortGameObjects = new List<GameObject>(gameObjects);

        sortGameObjects.Sort(sortByDistance);

        return sortGameObjects.ToArray();
    }

    int sortByDistance(GameObject gameObjectA, GameObject gameObjectB)
    {
        float distanceA = Vector3.Distance(gameObjectA.transform.position, transform.position);
        float distanceB = Vector3.Distance(gameObjectB.transform.position, transform.position);

        return distanceA.CompareTo(distanceB);

    }
}
