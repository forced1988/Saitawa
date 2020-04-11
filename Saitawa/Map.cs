using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Saitawa.Player;
using Saitawa.Util;

namespace Saitawa
{
    public class Map
    {
        private int width;
        private int height;
        private SpriteBatch sb;
        private GraphicsDevice gd;

        private Texture2D[] textureMap;
        private TextureGen textureGenerator;
        private int tileSize;



        public Map(SpriteBatch sb, GraphicsDevice gd, int width, int height,int tileSize = 16)
        {
            this.width = width;
            this.height = height;
            this.sb = sb;
            this.gd = gd;
            this.tileSize = tileSize;
            this.textureMap = new Texture2D[width*height];
            this.textureGenerator = new TextureGen(gd);
        }


        public void GenerateRandomMap()
        {
            for (int i = 0; i < textureMap.Length; i++)
            {
                textureMap[i] = textureGenerator.GetRandomTextureWithBorder(tileSize);
            }
        }


        public void Draw(GameTime time,Camera camera)
        {
            sb.Begin(SpriteSortMode.Texture,BlendState.AlphaBlend);


            
          
            sb.End();
        }
    }
}
