using System;

using System.Collections;
using Maps;

namespace Maps
{
	public enum Directions{
		NONE = 0,
		UP = 1,
		RIGHT = 1 << 1,
		DOWN = 1 << 2,
		LEFT = 1 << 3
	}
	
	public class Cell{
		private int walls;			
		public int coll;
		private int row;
		private bool hasVisited;
		
		
		public Cell(){
			walls = 0;
			coll = 0;
			row = 0;
			hasVisited = false;
		}
		
		public bool IsVisited{
			get{return hasVisited;}
			set{hasVisited = value;}
		}
		
		public int Coll{
			get{return coll;}
			set{coll = value;}
		}
		
		public int Row{
			get{return row;}
			set{row = value;}
		}
		
		

		public void setWall(Directions d){
			if(d == Directions.NONE) return;
			if(!((walls & (int)d) > 0)) walls = walls | (byte)d;
		}
		
		public void unsetWall(Directions d){
			if(d == Directions.NONE) return;
			if((walls & (int)d) > 0){
				int temp = 0;
				if(((walls & (int)Directions.UP) > 0) && !(d == Directions.UP)) temp = temp | (int)Directions.UP;
				if(((walls & (int)Directions.RIGHT) > 0) && !(d == Directions.RIGHT)) temp = temp | (int)Directions.RIGHT;
				if(((walls & (int)Directions.DOWN) > 0) && !(d == Directions.DOWN)) temp = temp | (int)Directions.DOWN;
				if(((walls & (int)Directions.LEFT) > 0) && !(d == Directions.LEFT)) temp = temp | (int)Directions.LEFT;
				walls = temp;
			}
		}
		
		public bool hasWall(Directions d){
			return (walls & (int)d) > 0;
		}
		
	}
	
	public class Maze
	{	
		private ArrayList cells;
		
		
		public Maze ()
		{
			cells = new ArrayList(); 
	
			
			for(int i = 0; i < 5; i++){
				for(int k = 0; k < 10; k++){
					Cell cell = new Cell();
					cell.IsVisited = false;
					cell.Coll = k;
					cell.Row = i;
					cell.setWall (Directions.UP|Directions.DOWN|
												Directions.LEFT|Directions.RIGHT);
					cells.Add(cell);
				}
			}
			
		}
		
		public bool hasNeighbour(Cell cell, Directions d){
			bool hasNeighbour = true;
			if((cell.Row == 0) && (d == Directions.UP)) hasNeighbour = false;
			if((cell.Row == 4) && (d == Directions.DOWN)) hasNeighbour = false;
			if((cell.Coll == 0) &&(d == Directions.LEFT)) hasNeighbour = false;
			if((cell.Coll == 9) && (d == Directions.RIGHT)) hasNeighbour = false;
			
			return hasNeighbour;
		}
		
		public Cell drill(Cell cell, Directions d){
			
			int row = cell.Row;
			int coll = cell.Coll;
			
			switch(d){
				case Directions.UP: row -=1;
									break;
				case Directions.LEFT: coll -= 1;
									  break;
				case Directions.DOWN: row+=1;
									  break;
				case Directions.RIGHT: coll +=1; 
									   break;
			}
			
			Cell currentCell = getCell(coll,row);
			
			switch(d){
				
				case Directions.UP: currentCell.unsetWall (Directions.DOWN);
									break;
				case Directions.DOWN: currentCell.unsetWall(Directions.UP);
									  break;
				case Directions.LEFT: currentCell.unsetWall(Directions.RIGHT);
									  break;
				case Directions.RIGHT: currentCell.unsetWall(Directions.LEFT);
									   break;
			}
			
			cell.unsetWall(d);
	
			return currentCell;
		}
		
		public Cell getCell(int coll, int row){
			IEnumerator cellEnum = cells.GetEnumerator();
			cellEnum.MoveNext();
			for(int i = 0; i < (row*10 + coll); i++) cellEnum.MoveNext();
			Cell cell = (Cell)cellEnum.Current;
			return cell;
		}
		
		public Directions GetRandomUnvisitedNeighbour(Cell cell){
			int dir;
			Random rand = new Random();
			int row = cell.Row;
			int coll = cell.Coll;
			Cell neighbour;
			Directions d = Directions.NONE;
			bool up = false,
				 down = false,
				 left = false,
			     right = false;
	

			while(true){
				dir = rand.Next(4) + 1;
				switch(dir){			
					case 1:	if(hasNeighbour(cell,Directions.UP)){ 
								neighbour = getCell (coll,row - 1);	
								if(!neighbour.IsVisited) d = Directions.UP;
							}
							up = true;
							break;
					
					case 2: if(hasNeighbour(cell,Directions.LEFT)){
								neighbour = getCell(coll - 1, row);
								if(!neighbour.IsVisited) d = Directions.LEFT;
							}
							left = true;
							break;
					
					case 3: if(hasNeighbour(cell,Directions.DOWN)){
								neighbour = getCell (coll,row + 1);
								if(!neighbour.IsVisited) d = Directions.DOWN;
							}
							down = true;
							break;
					
					case 4: if(hasNeighbour(cell,Directions.RIGHT)){
								neighbour = getCell(coll + 1,row);	
								if(!neighbour.IsVisited) d = Directions.RIGHT;   
							}
							right = true;
							break;
					
					default: d = Directions.NONE;
							 break;
				}
				if((d != Directions.NONE) || (right == true && down == true && up == true && left == true)) break;
			}
			
			return d;
		}
		
		public void Generate(int row = 1, int coll = 0){
			while(true){
				Cell cell = getCell(coll,row);
				Directions dir = GetRandomUnvisitedNeighbour(cell);
				if(dir == Directions.NONE) return;
				cell.IsVisited = true;
				Cell next = drill (cell,dir);
				next.IsVisited = true;
				Generate(next.Row,next.Coll);
				
			}
		}
		
		public void showWalls(){
			IEnumerator cellEnum = cells.GetEnumerator();
			
			for(int i = 0; i < 200; i++){
				cellEnum.MoveNext();
				if(((Cell)cellEnum.Current).hasWall(Directions.UP)) Console.Write("UP");
				if(((Cell)cellEnum.Current).hasWall(Directions.DOWN)) Console.Write("DOWN");
				if(((Cell)cellEnum.Current).hasWall(Directions.LEFT)) Console.Write("LEFT");
				if(((Cell)cellEnum.Current).hasWall(Directions.RIGHT)) Console.Write ("RIGHT \n");
			}
		}
		
        public void Reset() {
			
           for(int row = 0; row < 5; row++)
				for(int coll = 0; coll < 10; coll++){
					Cell cell = getCell(coll,row);
					cell.setWall(Directions.DOWN|Directions.LEFT|Directions.RIGHT|Directions.UP);
				}
        }




	}
}

