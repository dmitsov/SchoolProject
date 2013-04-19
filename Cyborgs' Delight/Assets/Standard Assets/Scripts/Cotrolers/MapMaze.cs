using System;
using System.Collections;
using UnityEngine;
using Maps;



namespace Maps
{
	public class MapMaze:  MonoBehaviour, IMap
	{
		private Maze maze;
		private Vector3[] corners;


        public void Start() { 
  	
			maze = new Maze();
			corners = new Vector3[66];
		}
		
		public void CreateMap(){
			maze.Generate();
            for (int row = 0; row < 6; row++) { }			
			
		}
		
		public void RearangeMap(){
			maze.ResetMaze();
		}
		

	}
}

