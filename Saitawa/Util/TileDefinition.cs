using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saitawa.Util
{
	[Flags]
	public enum TileDefinition
	{
		Grass = 27,
		GrassEdgeNN = 1,
		GrassEdgeNE = 5,
		GrassEdgeEE = 28,
		GrassEdgeSE = 97,
		GrassEdgeSS = 94,
		GrassEdgeSW = 92,
		GrassEdgeWW = 23,
		GrassEdgeNW = 0,

		StoneEdgeLeft1 = 115,
		StoneEdgeLeft2 = 115 + 23,
		StoneEdgeLeft3 = 115 + 23 + 23,

		StoneEdge1 = 117,
		StoneEdge2 = 117 + 23,
		StoneEdge3 = 117 + 23 + 23,

		StoneEdgeRight1 = 119,
		StoneEdgeRight2 = 119 + 23,
		StoneEdgeRight3 = 119 + 23 + 23,
		Void = 183
	}

	public enum TileDirection
	{
		NN, NE, EE, SE, SS, SW, WW, NW
	}

	public class AdjecentTile
	{
		public TileDefinition Self;
		public List<TileDefinition> NN { get; set; }
		public List<TileDefinition> NE { get; set; }
		public List<TileDefinition> EE { get; set; }
		public List<TileDefinition> SE { get; set; }
		public List<TileDefinition> SS { get; set; }
		public List<TileDefinition> SW { get; set; }
		public List<TileDefinition> WW { get; set; }
		public List<TileDefinition> NW { get; set; }

		public static List<AdjecentTile> Definition = new List<AdjecentTile>() {
			new AdjecentTile(){
				Self = TileDefinition.Grass,
				NN = new List<TileDefinition>(){ TileDefinition.Grass, TileDefinition.GrassEdgeNN},
				NE = new List<TileDefinition>(){ TileDefinition.Grass, TileDefinition.GrassEdgeNE},
				EE = new List<TileDefinition>(){ TileDefinition.Grass, TileDefinition.GrassEdgeEE},
				SE = new List<TileDefinition>(){ TileDefinition.Grass, TileDefinition.GrassEdgeSE},
				SS = new List<TileDefinition>(){ TileDefinition.Grass, TileDefinition.GrassEdgeSS},
				SW = new List<TileDefinition>(){ TileDefinition.Grass, TileDefinition.GrassEdgeSW},
				WW = new List<TileDefinition>(){ TileDefinition.Grass, TileDefinition.GrassEdgeWW},
				NW = new List<TileDefinition>(){ TileDefinition.Grass, TileDefinition.GrassEdgeNW},
			},
			new AdjecentTile(){
				Self = TileDefinition.Void,
				NN = new List<TileDefinition>(){ TileDefinition.Void, TileDefinition.GrassEdgeSS},
				NE = new List<TileDefinition>(){ TileDefinition.Void, TileDefinition.GrassEdgeSW},
				EE = new List<TileDefinition>(){ TileDefinition.Void, TileDefinition.GrassEdgeWW},
				SE = new List<TileDefinition>(){ TileDefinition.Void, TileDefinition.GrassEdgeNW},
				SS = new List<TileDefinition>(){ TileDefinition.Void, TileDefinition.GrassEdgeNN},
				SW = new List<TileDefinition>(){ TileDefinition.Void, TileDefinition.GrassEdgeNE},
				WW = new List<TileDefinition>(){ TileDefinition.Void, TileDefinition.GrassEdgeEE},
				NW = new List<TileDefinition>(){ TileDefinition.Void, TileDefinition.GrassEdgeSE},
			},
			new AdjecentTile(){
				Self = TileDefinition.GrassEdgeNW,
				EE = new List<TileDefinition>(){ TileDefinition.GrassEdgeNN}
			},
			new AdjecentTile(){
				Self = TileDefinition.GrassEdgeNN,
				EE = new List<TileDefinition>(){ TileDefinition.GrassEdgeNN,  TileDefinition.GrassEdgeNE }
			},

		};

		public static TileDefinition GetAdjecentTile(TileDefinition tile, TileDirection direction) {
			var definition = Definition.Where(x => x.Self == tile).FirstOrDefault();
			if (definition == null) {
				return TileDefinition.Void;
			}

			switch (direction) {
				case TileDirection.NN: return definition.NN.Any() ? definition.NN.OrderBy(qu => Guid.NewGuid()).FirstOrDefault() : TileDefinition.Void;
				case TileDirection.NE: return definition.NE.Any() ? definition.NE.OrderBy(qu => Guid.NewGuid()).FirstOrDefault() : TileDefinition.Void;
				case TileDirection.EE: return definition.EE.Any() ? definition.EE.OrderBy(qu => Guid.NewGuid()).FirstOrDefault() : TileDefinition.Void;
				case TileDirection.SE: return definition.SE.Any() ? definition.SE.OrderBy(qu => Guid.NewGuid()).FirstOrDefault() : TileDefinition.Void;
				case TileDirection.SS: return definition.SS.Any() ? definition.SS.OrderBy(qu => Guid.NewGuid()).FirstOrDefault() : TileDefinition.Void;
				case TileDirection.SW: return definition.SW.Any() ? definition.SW.OrderBy(qu => Guid.NewGuid()).FirstOrDefault() : TileDefinition.Void;
				case TileDirection.WW: return definition.WW.Any() ? definition.WW.OrderBy(qu => Guid.NewGuid()).FirstOrDefault() : TileDefinition.Void;
				case TileDirection.NW: return definition.NW.Any() ? definition.NW.OrderBy(qu => Guid.NewGuid()).FirstOrDefault() : TileDefinition.Void;
			}

			return TileDefinition.Void;
		}
	}
}
