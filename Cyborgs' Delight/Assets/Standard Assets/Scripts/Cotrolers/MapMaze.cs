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
		GameObject northWall;
		GameObject westWall;
		GameObject eastWall;
		GameObject southWall;


        public void Start() {
			maze = new Maze();
			
			float x = transform.position.x - 50f;
			float z = transform.position.z + 25f;
			float y = transform.position.y;
			corners = new Vector3[50];
			
			for(int row = 0; row < 5; row++)
				for(int col = 0; col < 10; col++){
					corners[row*10 + col] = new Vector3(x + 10*col,y,z - 10*row);	
				}
			CreateMap();
		}
		
		
		public void CreateMap(){	
			
			maze.Generate ();
	
			
			
			northWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
			northWall.transform.position = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z + 25F);
			northWall.transform.localScale = new Vector3(transform.localScale.x,5f,0.2f);
			
			westWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
			westWall.transform.position = new Vector3(transform.position.x - 50f,transform.position.y + 2.5f, transform.position.z);
			westWall.transform.localScale = new Vector3(transform.localScale.z,5f,0.2f);
			westWall.transform.rotation = Quaternion.FromToRotation(Vector3.right,Vector3.forward);
			
			
			Cell cell;
			GameObject wall1;
			GameObject wall2;
			
			
			for(int row = 0; row < 5; row++)
				for(int coll = 0; coll < 10; coll++){
					cell = maze.getCell(coll,row);
					if(cell.hasWall(Directions.RIGHT)){
						float x = corners[10*row + coll].x + 10f;
						float y = corners[10*row + coll].y + 1f;
						float z = corners[10*row + coll].z - 5f;	
					
						wall1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
						wall1.transform.position = new Vector3(x,y,z);
						wall1.transform.localScale = new Vector3(10f,2.5f,0.2f);
						wall1.transform.rotation = Quaternion.FromToRotation(Vector3.right,Vector3.forward);
					}
				
					if(cell.hasWall(Directions.DOWN)){
						float x = corners[10*row + coll].x + 5f;
						float y = corners[10*row + coll].y + 1f;
						float z = corners[10*row + coll].z - 10f;	
					
						wall2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
						wall2.transform.position = new Vector3(x,y,z);
						wall2.transform.localScale = new Vector3(10f,2.5f,0.2f);
					}
				}
			
		}
		
		public void RearangeMap(){
			maze.Reset ();
			maze.Generate();
			
			Cell cell;
			GameObject wall1;
			GameObject wall2;
			
			for(int row = 0; row < 5; row++)
				for(int coll = 0; coll < 10; coll++){
					cell = maze.getCell(coll,row);
					if(cell.hasWall(Directions.RIGHT)){
						float x = corners[10*row + coll].x + 10f;
						float y = corners[10*row + coll].y + 1f;
						float z = corners[10*row + coll].z - 5f;	
					
						wall1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
						wall1.transform.position = new Vector3(x,y,z);
						wall1.transform.localScale = new Vector3(10f,2.5f,0.2f);
						wall1.transform.rotation = Quaternion.FromToRotation(Vector3.right,Vector3.forward);
					}
				
					if(cell.hasWall(Directions.DOWN)){
						float x = corners[10*row + coll].x + 5f;
						float y = corners[10*row + coll].y + 1f;
						float z = corners[10*row + coll].z - 10f;	
					
						wall2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
						wall2.transform.position = new Vector3(x,y,z);
						wall2.transform.localScale = new Vector3(10f,2.5f,0.2f);
					}
				}
			
		}	

	}
}

