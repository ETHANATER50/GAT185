using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Priority_Queue;
public static class SearchAStar
{
	public static bool Search(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps)
    {

		bool found = false;

		SimplePriorityQueue<GraphNode> nodes = new SimplePriorityQueue<GraphNode>();

		source.cost = 0;
		source.heuristic = Vector3.Distance(source.transform.position, destination.transform.position);
		nodes.Enqueue(source, source.cost + source.heuristic);

		int steps = 0;

		while(!found && nodes.Count > 0 && steps++ < maxSteps)
        {
			var node = nodes.Dequeue();

			if(node == destination)
            {
				found = true;
				continue;
            }

			foreach(var edge in node.edges)
            {
				float cost = node.cost + Vector3.Distance(edge.nodeA.transform.position, edge.nodeB.transform.position);
				if(cost < edge.nodeB.cost)
                {
					edge.nodeB.cost = cost;
					edge.nodeB.parent = node;

					edge.nodeB.heuristic = Vector3.Distance(edge.nodeB.transform.position, destination.transform.position);
					nodes.EnqueueWithoutDuplicates(edge.nodeB, edge.nodeB.cost + edge.nodeB.heuristic);
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
			while (nodes.Count > 0)
			{
				path.Add(nodes.Dequeue());
			}
		}

		return found;
	}
}
