using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Saitawa.Util
{
    public class TextureGen
    {
        private GraphicsDevice gd;
        private Random rn;
        public TextureGen(GraphicsDevice gd)
        {
            this.gd = gd;
            rn = new Random();
        }


        public Texture2D GetRandomTextureWithBorder(int textureSize = 16)
        {
            int size = textureSize * textureSize;
            Color[] mapcolors = new Color[size];
            Color tileColor = new Color(
                (byte)rn.Next(0, 255),
                (byte)rn.Next(0, 255),
                (byte)rn.Next(0, 255));

            for (int y = 0; y < textureSize; y++)
            {
                for (int x = 0; x < textureSize; x++)
                {
                    if (y == 0 || y == textureSize - 1)
                    {
                        mapcolors[y * textureSize + x] = Color.Black;
                        continue;
                    }
                    if (x == 0 || x == textureSize - 1)
                    {
                        mapcolors[y * textureSize + x] = Color.Black;
                        continue;
                    }
                    mapcolors[y * textureSize + x] = tileColor;
                }
            }

            var tex = new Texture2D(gd, textureSize, textureSize, false, SurfaceFormat.Color);
            tex.SetData(mapcolors);

            return tex;
        }

    }
}
