using System;
using UnityEngine;
using System.Collections;
using System.Reflection;
using SharpUnit;
using Maps;

namespace TestLib
{	
	public class TestMapMaze: TestCase{
	private GameObject floor;
	private MapMaze mapMaze;
	
	public void SetUp(){
		floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
		Vector3 size = new Vector3(500f,1f,100);
		mapMaze = floor.AddComponent<MapMaze>();
		if(mapMaze == null)
			throw new Exception();
	
		
	}
	
	[UnitTest]
	public void TestStart(){	 
	/*	MethodInfo startMethod = typeof(MapMaze).GetMethod("Start");
		if(startMethod != null){
			startMethod.Invoke (mapMaze,null);		
		}
	*/
	}
	
		
	}
}

