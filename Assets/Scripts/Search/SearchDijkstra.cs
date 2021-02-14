using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Priority_Queue;
public static class SearchDijkstra
{
	public static bool Search(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps)
    {

		bool found = false;

		SimplePriorityQueue<GraphNode> nodes = new SimplePriorityQueue<GraphNode>();
		source.cost = 0;
		nodes.Enqueue(source, source.cost);

		int steps = 0;

		while(!found && nodes.Count > 0 && steps++ < maxSteps)
        {
			GraphNode node = nodes.Dequeue();
			if(node == destination)
            {
				found = true;
				continue;
            }

			foreach (var edge in node.edges)
            {
				float cost = node.cost + Vector3.Distance(edge.nodeA.transform.position, edge.nodeB.transform.position);
				if(cost < edge.nodeB.cost)
                {
					edge.nodeB.cost = cost;
					edge.nodeB.parent = node;

					nodes.EnqueueWithoutDuplicates(edge.nodeB, edge.nodeB.cost);
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
			while(nodes.Count > 0)
            {
				path.Add(nodes.Dequeue());
            }
		}

		return found;
	}
}
