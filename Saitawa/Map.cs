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


        public void Draw(GameTime time, Camera camera)
        {
            sb.Begin(SpriteSortMode.Texture,BlendState.AlphaBlend);

            // Map
            // Fixed X/Y position (tile based => pixels = * tileSize)

            // Viewport
            // Screensize Width && Height

            // Camera
            // Use screensize && camera location to render the X/Y based map on the correct position

            var cpCamera = camera.Position;
            var tlCamera = camera.topLeft;
            var brCamera = camera.bottomRight;

            //00000000000
            //00000000000
            //00000000000

            //0,1,2,3,4,5
            //0,32,64,96,128,160ize;
            for (int x = (int)camera.topLeft.X; x < (int)camera.bottomRight.X + tileSize; x += tileSize) {
                for (int y = (int)camera.topLeft.Y; y < (int)camera.bottomRight.Y + tileSize; y += tileSize) {

                    //WhereToDraw
                    int textureIndexX = x / tileSize;
                    int textureIndexY = y / tileSize;

                    //TextureMapIndex
                    var flatIndex = (textureIndexY * width + textureIndexX);

                    if (flatIndex < 0 || flatIndex > textureMap.Length) {
                        continue;
                    }

                    float texturePositionX = textureIndexX * tileSize;
                    float texturePositionY = textureIndexY * tileSize;

                    

                    sb.Draw(textureMap[flatIndex], new Vector2(texturePositionX, texturePositionY));
                }

            }

            //tlCamera == (Map + offset)



            sb.End();
        }
    }
}
