using System;
using UnityEngine;
using System.Collections;
using Maps;
using System.Reflection;
using NUnit.Framework;

namespace TestLib
{

  public class TestMaze{
	Maze maze;
	Cell cell;
	[SetUp]
	public void SetUp(){
		maze = new Maze();
		cell = new Cell();
	}
	
    
	[Test]
	public void TestCell(){
		Cell celltemp = new Cell();
		Assert.AreNotEqual(celltemp,null);
	}
	
	[Test]
	public void TestHasWall(){
		Assert.AreEqual(cell.hasWall(Directions.NONE),true);
	}
		
		
	[Test]
	public void TestCellSetWall(){
	    cell.setWall (Directions.DOWN);
		Assert.AreEqual(cell.hasWall(Directions.DOWN),true);
	}
	
    [Test]
	public void TestCellUnsetWall()
	{
		cell.setWall (Directions.UP);
		cell.unsetWall(Directions.UP);
		Assert.AreEqual(cell.hasWall(Directions.UP),false);
	}
	
	[Test]
	public void TestMazeConstructor(){
		Maze tempmaze = new Maze();
		Assert.AreNotEqual(tempmaze,null);
		
	}
	
	[Test]
	public void TestMazeGetCell(){
		Cell tempcell = maze.getCell(0,2);	
		Assert.AreNotEqual(tempcell,null);
		Assert.AreEqual(tempcell.Row,2);
		Assert.AreEqual(tempcell.Coll,0);
		Assert.AreNotEqual(tempcell.hasWall(Directions.NONE),true);
	}
		
	[Test]
	public void TestMazeHasNeighbour(){
		Cell tempcell = maze.getCell(0,1);
		Assert.AreEqual (maze.hasNeighbour(tempcell,Directions.UP),true);
		Assert.AreEqual(maze.hasNeighbour(tempcell,Directions.RIGHT),true);
		Assert.AreEqual(maze.hasNeighbour(tempcell,Directions.DOWN),true);
		Assert.AreEqual(maze.hasNeighbour(tempcell,Directions.LEFT),false);		
	}
	
	[Test]
	public void TestMazeDrill(){
		Cell tempcell = maze.getCell(0,1);
		maze.drill(tempcell,Directions.DOWN);
		Assert.AreEqual(tempcell.hasWall(Directions.DOWN),false);
		maze.drill (tempcell,Directions.RIGHT);
		Assert.AreEqual(tempcell.hasWall(Directions.RIGHT),false);
	}
	
		
	[Test]
	public void TestMazeGetRandomUnvisitedNeighbour(){
		Cell tempcell = maze.getCell(0,1);
		Directions d = maze.GetRandomUnvisitedNeighbour(tempcell);
		Assert.AreNotEqual(d,Directions.NONE);
		maze.getCell(0,0).IsVisited = true;
		maze.getCell (0,2).IsVisited = true;
		maze.getCell(1,1).IsVisited = true;
		d = maze.GetRandomUnvisitedNeighbour(tempcell);
		Assert.AreEqual(d,Directions.NONE);
	}
		
	[Test]
	public void TestMazeGenerate(){
		maze.Generate();
		bool isChanged = false;
		int count = 0;
		Cell tempcell;
		for(int i = 0; i < 5; i++)
			for(int j = 0; j < 10; j++){
				tempcell = maze.getCell(j,i);
				if((!tempcell.hasWall(Directions.UP) || !tempcell.hasWall(Directions.DOWN) || 
						!tempcell.hasWall(Directions.LEFT) || !tempcell.hasWall(Directions.RIGHT)) && count == 0){
					count++;
					isChanged = true;
				}
			}
		Assert.AreEqual(isChanged,true);
		Assert.AreEqual(count,1);
	}
		
	[Test]
	public void TestMazeReset(){
		maze.Generate();
		bool isChanged = false;
		int count = 0;
		Cell tempcell;
		for(int i = 0; i < 5; i++)
			for(int j = 0; j < 10; j++){
				tempcell = maze.getCell(j,i);
				if((!tempcell.hasWall(Directions.UP) || !tempcell.hasWall(Directions.DOWN) || 
						!tempcell.hasWall(Directions.LEFT) || !tempcell.hasWall(Directions.RIGHT)) && count == 0){
					count++;
					isChanged = true;
				}
			}
		Assert.AreEqual(isChanged,true);
		Assert.AreEqual(count,1);
		
		maze.Reset();
		isChanged = false;
		count = 0;
		
		for(int i = 0; i < 5; i++)
			for(int j = 0; j < 10; j++){
				tempcell = maze.getCell(j,i);
				if(!(tempcell.hasWall(Directions.UP) && tempcell.hasWall(Directions.DOWN) && 
						tempcell.hasWall(Directions.LEFT) && tempcell.hasWall(Directions.RIGHT)) && count == 0){
					count++;
					isChanged = true;
				}
			}
	
		Assert.AreNotEqual(isChanged,true);
  		Assert.AreNotEqual (count,1);
	}
		
  }


}
