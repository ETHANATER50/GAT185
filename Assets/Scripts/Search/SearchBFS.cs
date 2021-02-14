using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public static class SearchBFS
{
	public static bool Search(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps)
    {
		Queue<GraphNode> nodes = new Queue<GraphNode>();

		source.visited = true;

		nodes.Enqueue(source);

		bool found = false;
		int steps = 0;
		while (!found && nodes.Count > 0 && steps++ < maxSteps)
		{
			GraphNode node = nodes.Dequeue();
	
			foreach (GraphNode.Edge edge in node.edges)
			{
				if (edge.nodeB.visited == false)
				{
					edge.nodeB.visited = true;
					edge.nodeB.parent = node;
					nodes.Enqueue(edge.nodeB);
				}
				if (edge.nodeB == destination)
				{
					found = true;
					break;
				}
			}
		}

		path = new List<GraphNode>();
		if (found)
		{
			GraphNode node = destination;
			while (node != null)
			{
				path.Add(node);
				node = node.parent;
			}
			path.Reverse();
		}
		else
		{
			path = nodes.ToList();
		}

		return found;
	}
}
