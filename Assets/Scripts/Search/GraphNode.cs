using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNode : SearchNode
{

    public enum Type
    {
        Default,
        Source,
        Destination,
        Path,
        Visited
    }

    Color[] colors =
    {
        Color.white,
        Color.green,
        Color.red,
        Color.yellow,
        Color.blue
    };

    public struct Edge
    {
        public GraphNode nodeA;
        public GraphNode nodeB;
    }

    public List<Edge> edges { get; set; } = new List<Edge>();
    public Type type { get; set; } = Type.Default;
    public bool visited { get; set; } = false;
    public GraphNode parent { get; set; } = null;

    public float cost { get; set; } = float.MaxValue;
    public float heuristic { get; set; } = 0;

    void Update()
    {
        GetComponent<Renderer>().material.color = colors[(int)type];

        foreach (var edge in edges)
        {
            Debug.DrawLine(edge.nodeA.transform.position, edge.nodeB.transform.position);
        }
    }

    public static GraphNode[] getGraphNodes()
    {
        return GameObject.FindObjectsOfType<GraphNode>();
    }

    public static GraphNode getGraphNode(Type type)
    {
        GraphNode graphNode = null;

        GraphNode[] graphNodes = getGraphNodes();

        foreach (var node in graphNodes)
        {
            if (node.type == type)
            {
                graphNode = node;
                break;
            }
        }
        return graphNode;
    }

    public static void unlinkNodes()
    {
        GraphNode[] graphNodes = getGraphNodes();

        foreach (var node in graphNodes)
        {
            node.edges.Clear();
        }
    }

    public static void linkNodes(float range)
    {
        GraphNode[] graphNodes = getGraphNodes();

        foreach (var node in graphNodes)
        {
            linkNode(node, range);
        }
    }

    public static void linkNode(GraphNode node, float range)
    {
        Collider[] colliders = Physics.OverlapSphere(node.transform.position, range);
        foreach (var collider in colliders)
        {
            GraphNode otherNode = collider.GetComponent<GraphNode>();
            if (otherNode != null && otherNode != node)
            {
                GraphNode.Edge edge;
                edge.nodeA = node;
                edge.nodeB = otherNode;

                node.edges.Add(edge);
            }
        }
    }

    public static void clearNodeType(Type type)
    {
        GraphNode[] graphNodes = getGraphNodes();

        foreach (var node in graphNodes)
        {
            if (node.type == type)
            {
                node.type = Type.Default;
            }
        }
    }

    public static void reset()
    {
        clearNodeType(Type.Path);
        clearNodeType(Type.Visited);

        GraphNode[] graphNodes = getGraphNodes();

        foreach (var node in graphNodes)
        {
            node.visited = false;
            node.parent = null;
            node.cost = float.MaxValue;
        }
    }
}
