using System;
using System.Collections;
using UnityEngine;
using Maps;



namespace Maps
{
	public class MapMaze:  MonoBehaviour, IMap
	{
		private Maze maze;
		private GameObject floor;
		private GameObject[] corners;
		
		
		public MapMaze()
		{
			floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
			maze = new Maze();
		}
		
		public void CreateMap(){
			maze.Generate();
		}
		
		public void RearangeMap(){
			maze.ResetMaze();
		}
		

	}
}

