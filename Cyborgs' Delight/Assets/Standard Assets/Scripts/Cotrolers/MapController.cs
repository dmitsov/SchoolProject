using System.Collections;
using System;
using UnityEngine;
using Maps;


namespace Maps
{
	public sealed class MapController
	{
		private static readonly MapController instance = new MapController();
		
		public static MapController Instance{
			get{
				return instance;
			}
		}
		
		public IMap map;
		
		public MapController ()
		{}
		
		public void SetMap(int i){
			try{
				map = MapCatalouge.Instance.getMap(i);
			}catch(MissingMapException e){
				System.Console.WriteLine("Map is Missing!!!");
			}
		}
		
		
		
		public void CreateMap(){
			map.CreateMap();
		}
		
		public void RearangeMap(){
			map.RearangeMap();
		}
	}
	
	public interface IMap{
		void CreateMap();
		void RearangeMap();
		//void SetEnemySpawnPoint();
		//void SeTTurretLocation();
	}
	
}

