using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchBuilder : MonoBehaviour
{
	public TMP_Text infoText;

	delegate bool SearchAlgorithm(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps);
	SearchAlgorithm Search;

	List<GraphNode> path;
	int maxSteps = int.MaxValue;

	private void Start()
	{
		Search = SearchBFS.Search;
	}

	public void SearchNodes()
	{
		GraphNode source = GraphNode.getGraphNode(GraphNode.Type.Source);
		GraphNode destination = GraphNode.getGraphNode(GraphNode.Type.Destination);

		if (source == null || destination == null) return;

		// reset nodes
		GraphNode.reset();

		// search for path from source to destination nodes		
		bool found = Search(source, destination, ref path, maxSteps);

		// set all path nodes to path type amd draw lines
		foreach (GraphNode graphNode in path)
		{
			if (graphNode.type == GraphNode.Type.Default)
			{
				graphNode.type = (found) ? GraphNode.Type.Path : GraphNode.Type.Visited;
			}
		}

        if (found)
        {
			float distance = 0;

            for (int i = 0; i < path.Count - 1; i++)
            {
				distance += Vector3.Distance(path[i].transform.position, path[i + 1].transform.position);
            }

			infoText.text = "nodes: " + path.Count + "\ndistance: " + distance;

        }
	}

	public void OnSearch()
	{
		maxSteps = int.MaxValue;
		SearchNodes();
	}

	public void OnSteps(float steps)
	{
		maxSteps = (int)steps;
		SearchNodes();
	}

	public void OnReset()
	{
		GraphNode.reset();
	}

	public void onSearchSelect(int index)
	{
		switch (index)
		{
			case 0:
				Search = SearchDFS.Search;
				break;
			case 1:
				Search = SearchBFS.Search;
				break;
			case 2:
				Search = SearchDijkstra.Search;
				break;
			case 3:
				break;
		}
	}
}
