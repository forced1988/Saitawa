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
			IslandMap = Enumerable.Repeat((short)TileDefinition.Void, width * height).ToArray();//new short[width * height];//

			this.Width = width;
			this.Height = height;
			this.IslandCount = amountOfIsland;
			this.MinIslandSize = minIslandSize;
			this.MaxIslandSize = maxIslandSize;
		}

		public void GenerateIslands() {
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
					bool xIsEdge = x == 0 || x == width - 1;

					for (int y = 0; y < height; y++) {

						var index = xyStart + (this.Width * y) + x;
						if (index > IslandMap.Length) {
							continue;
						}

						IslandMap[index] = (short)TileDefinition.Grass;

						bool yIsEdge = y == 0 || y == height - 1;
						if(xIsEdge && yIsEdge) {
							if ((x, y) == (0, 0)) {//Top Left Corner
								IslandMap[index] = (short)TileDefinition.GrassEdgeNW;
							} else if ((x, y) == (width - 1, 0)) { //Top Right Corner
								IslandMap[index] = (short)TileDefinition.GrassEdgeNE;
							} else if ((x, y) == (0, height - 1)) { //Bottom Left Corner
								IslandMap[index] = (short)TileDefinition.GrassEdgeSW;

								applyEdgeBleeding(index, new List<TileDefinition>() { 
									TileDefinition.StoneEdgeLeft1, 
									TileDefinition.StoneEdgeLeft2, 
									TileDefinition.StoneEdgeLeft3
								});
							} else if ((x, y) == (width - 1, height - 1)) { //Bottom Right Corner
								IslandMap[index] = (short)TileDefinition.GrassEdgeSE;

								applyEdgeBleeding(index, new List<TileDefinition>() {
									TileDefinition.StoneEdgeRight1,
									TileDefinition.StoneEdgeRight2,
									TileDefinition.StoneEdgeRight3
								});
							}
						} else { 
							if (yIsEdge) {
								if (y == 0) { // Top Side
									IslandMap[index] = (short)TileDefinition.GrassEdgeNN;
								} else { // Bottom Side
									IslandMap[index] = (short)TileDefinition.GrassEdgeSS;

									applyEdgeBleeding(index, new List<TileDefinition>() { TileDefinition.StoneEdge1, TileDefinition.StoneEdge2, TileDefinition.StoneEdge3 });
								}
							}
							if (xIsEdge) {
								if (x == 0) { // Left Side
									IslandMap[index] = (short)TileDefinition.GrassEdgeWW;
								} else { // Right Side
									IslandMap[index] = (short)TileDefinition.GrassEdgeEE;
								}
							}
						}

						//IslandMap[index] = color;
					}
				}
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

		public void applyEdgeBleeding(int index, List<TileDefinition> tiles) {
			var currentIndex = index;
			foreach (var item in tiles) {
				currentIndex += (this.Width * 1);
				if (currentIndex <= IslandMap.Length) {
					IslandMap[currentIndex] = (short)item;
				}
			}
		}
	}
}
