using Microsoft.Xna.Framework.Graphics;
using Saitawa.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saitawa.Generators
{
	class IslandGenerator
	{
		public short[] IslandMap;
		private static Random Random = new Random(5646854);
		private readonly int Width;
		private readonly int Height;
		private readonly int IslandCount;
		private readonly int MinIslandSize;
		private readonly int MaxIslandSize;

		public IslandGenerator(int width, int height, int amountOfIsland = 1, int minIslandSize = 3, int maxIslandSize = 10) {
			IslandMap = new short[width * height];
			this.Width = width;
			this.Height = height;
			this.IslandCount = amountOfIsland;
			this.MinIslandSize = minIslandSize;
			this.MaxIslandSize = maxIslandSize;
		}

		public void GenerateIslands() {
			//Select random points in the Map.Length
			short color = 16;
			for (int i = 0; i < IslandCount; i++) {
				var location = Random.Next(0, IslandMap.Length);
				var width = Random.Next(this.MinIslandSize, this.MaxIslandSize);
				var height = Random.Next(this.MinIslandSize, this.MaxIslandSize);

				var xyStart = location;

				//------------
				//--.####-----
				//------------
				//------------
				//------------

				

				for (int x = 0; x < width; x++) 
				{
					IslandMap[xyStart + x] = color;
					for (int y = 0; y < height; y++) {
						var index = xyStart + (this.Width * y) + x;
						if(index > IslandMap.Length) {
							continue;
						}
						IslandMap[index] = color;
					}
				}
				color += 16;
			}

			//Check each position with value > 0
			//Check N, NE, E, SE, S, SW ,W, NW
			//Pick the correct texture


			//-----------
			//-----?#----
			//------?----
			//TileDefinition.GrassEdgeNE

			//-----------
			//---?##?----
			//TileDefinition.GrassEdgeNN




		}

	}
}
