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
			corners = new GameObject[50];
			maze = new Maze();
		}
		
		public void CreateMap(){
			floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
		}
		
		public void RearangeMap(){
			
		}
		

	}
}

