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
        private SpriteFont font;
        private int tileSize;



        public Map(SpriteBatch sb, GraphicsDevice gd, int width, int height,int tileSize = 16, SpriteFont font = null)
        {
            this.width = width;
            this.height = height;
            this.sb = sb;
            this.gd = gd;
            this.tileSize = tileSize;
            this.textureMap = new Texture2D[width*height];
            this.textureGenerator = new TextureGen(gd);
            this.font = font;
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
            //sb.Begin(SpriteSortMode.Texture,BlendState.AlphaBlend);

            // Map
            // Fixed X/Y position (tile based => pixels = * tileSize)

            // Viewport
            // Screensize Width && Height

            // Camera
            // Use screensize && camera location to render the X/Y based map on the correct position


            //0,1,2,3,4,5
            //0,32,64,96,128,160;

            int minX = Math.Max(0, (int)camera.TopLeft.X);
            int minY = Math.Max(0, (int)camera.TopLeft.Y);

            int maxX = Math.Min(width * tileSize, (int)camera.BottomRight.X) + tileSize;
            int maxY = Math.Min(height * tileSize, (int)camera.BottomRight.Y) + tileSize;

            for (int x = minX; x < maxX ; x += tileSize) {
                for (int y = minY; y < maxY; y += tileSize) {
                    //WhereToDraw
                    int textureIndexX = x / tileSize;
                    int textureIndexY = y / tileSize;

                    if (textureIndexX >= width)
                    {
                        continue;
                    }


                    //TextureMapIndex
                    var flatIndex = (textureIndexY * width + textureIndexX);

                    float texturePositionX = textureIndexX * tileSize;
                    float texturePositionY = textureIndexY * tileSize;

                    if(textureMap.Length <= flatIndex) {
                        continue;
                    }

                    sb.Draw(textureMap[flatIndex], new Vector2(texturePositionX, texturePositionY));
                    sb.DrawString(this.font, $"{textureIndexX}", new Vector2(texturePositionX, texturePositionY), Color.Black);
                    sb.DrawString(this.font, $"{textureIndexY}", new Vector2(texturePositionX, texturePositionY + 12), Color.Black);
                    //sb.DrawString(this.font, $"{flatIndex}", new Vector2(texturePositionX, texturePositionY + 12), Color.Black);
                }

            }

            //tlCamera == (Map + offset)



            //sb.End();
        }
    }
}
