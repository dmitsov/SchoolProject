using System;
using System.Collections;
using Maps;

namespace Maps
{
	public class MissingMapException:System.Exception{}
	
	public sealed class MapCatalouge
	{
		private ArrayList mapList;
		
		private static readonly MapCatalouge instance = new MapCatalouge();
		public static MapCatalouge Instance{
			get{
				return instance;
			}
		}
		
		public MapCatalouge ()
		{
			mapList = new ArrayList();
		}
		
		
		public IMap getMap(int i){
			try{
				return (IMap)mapList[i];
			}catch(System.ArgumentOutOfRangeException e){
				throw new MissingMapException();
			}
		}
		
		public void AddMap(){
			
		}
	}
}

