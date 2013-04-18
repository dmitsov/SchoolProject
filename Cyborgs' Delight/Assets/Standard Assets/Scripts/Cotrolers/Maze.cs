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
		private int walls = 0;			
		public int coll;
		private int row;
		private bool hasVisited = false;
		
		
		public Cell(){}
		
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
		
		
		public bool isVisited(){
			return hasVisited;
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
		
	}
	
	public class Maze
	{	
		private Cell[] cells;
		
		
		public Maze ()
		{
			cells = new Cell[50]; 
	
			for(int i = 0; i < 5; i++){
				for(int k = 0; k < 10; k++){
					cells[i*10 + k].Coll = k;
					cells[i*10 + k].Row = i;
					cells[i*10 + k].setWall (Directions.UP|Directions.DOWN|
												Directions.LEFT|Directions.RIGHT);
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
			if(d == Directions.NONE) return cell;
			if(!hasNeighbour(cell,d)) return cell;
			
			
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
			
			switch(d){
				case Directions.UP: cells[row*10 + coll].unsetWall (Directions.DOWN);
									break;
				case Directions.DOWN: cells[row*10 + coll].unsetWall(Directions.UP);
									  break;
				case Directions.LEFT: cells[row*10 +coll].unsetWall(Directions.RIGHT);
									  break;
				case Directions.RIGHT: cells[row*10 + coll].unsetWall(Directions.LEFT);
									   break;
			}
			
			cell.unsetWall(d);
	
			return cells[row*10 + coll];
		}
		
		public Cell getCell(int coll, int row){
			return cells[row*10 + coll];
		}
		
		public Directions GetRandomUnvisitedNeighbour(Cell cell){
			int dir;
			Random rand = new Random();
			int row = cell.Row;
			int coll = cell.Coll;
			int visited = 0;
			Directions d = Directions.NONE;
			
			
			
			while(true){
				dir = rand.Next(4) + 1;
				switch(dir){
					case 1: if(!cells[(row-1)*10 + coll].IsVisited) d = Directions.UP;
							else visited+=1;
							break;
					case 2: if(!cells[row*10 + coll - 1].IsVisited) d = Directions.LEFT;
							else visited+=1;
							break;
					case 3: if(!cells[(row+1)*10 + coll].IsVisited) d = Directions.DOWN;
							else visited+=1;
							break;
					case 4: if(!cells[row*10 + coll + 1].IsVisited) d = Directions.RIGHT;   
							else visited+=1;
							break;
					
				}
				if((d != Directions.NONE) || (visited == 4)) break;
			}
			
			return d;
		}
		
		public void Generate(Cell start){
			while(true){
				Directions dir = GetRandomUnvisitedNeighbour(start);
				if(dir == Directions.NONE) return;
				else{
						Cell next = drill (start,dir);
						next.IsVisited = true;
						Generate(next);
				}
			}
		}

        public void Reset() {
            for (int i = 0; i < 5; i++) {
                for (int k = 0; k < 10; k++) {
                    cells[i * 10 + k].setWall(Directions.UP|Directions.DOWN|Directions.LEFT|Directions.RIGHT);   
                }
            }
        }




	}
}

