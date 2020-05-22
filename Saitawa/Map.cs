using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Saitawa.Generators;
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

        private short[] tileMap;
        private Texture2D tileMapTexture;
        private TextureGen textureGenerator;
        private SpriteFont font;
        private int tileSize;

        //23x8

        public Map(SpriteBatch sb, GraphicsDevice gd, int width, int height,int tileSize = 16, SpriteFont font = null,Texture2D tileMapTexture = null)
        {
            this.width = width;
            this.height = height;
            this.sb = sb;
            this.gd = gd;
            this.tileSize = tileSize;
            this.textureMap = new Texture2D[width*height];
            this.tileMap = new short[width * height];
            this.textureGenerator = new TextureGen(gd);
            this.font = font;
            this.tileMapTexture = tileMapTexture;

        }

        public void GenerateRandomMap()
        {
            Random rnd = new Random();

            var island = new IslandGenerator(width, height, 50);
            island.GenerateIslands();

            tileMap = island.IslandMap;
        }


        public void Draw(GameTime time, Camera camera)
        {
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

                    //sb.Draw(textureMap[flatIndex], new Vector2(texturePositionX, texturePositionY));
                    var tileNumber = tileMap[flatIndex];

                    //181
                    //181 / 23
                    //7
                    //181 - (7 * 23)

                    int yTilePos = tileNumber / (tileMapTexture.Width / tileSize);
                    int xTilePos = tileNumber - (yTilePos * (tileMapTexture.Width / tileSize));

                    //if(tileNumber == TileDefinition.Void) {
                    //    Color[] background = new Color[] { new Color((float)16.1, (float)14.9, (float)20.4) };
                    //    var tex = new Texture2D(gd, textureSize, textureSize, false, SurfaceFormat.Color);
                    //    tex.SetData(background)

                    //    Vector2 tilePosition = new Vector2(xTilePos * tileSize, yTilePos * tileSize);
                    //    sb.Draw(tex, new Vector2(texturePositionX, texturePositionY), sourceRectangle: new Rectangle((int)tilePosition.X, (int)tilePosition.Y, tileSize, tileSize));

                    //} else { 
                    //}

                    Vector2 tilePosition = new Vector2(xTilePos * tileSize,yTilePos * tileSize);
                    sb.Draw(tileMapTexture, new Vector2(texturePositionX, texturePositionY), sourceRectangle:new Rectangle((int)tilePosition.X,(int)tilePosition.Y,tileSize,tileSize));

                    //sb.DrawString(this.font, $"{textureIndexX}", new Vector2(texturePositionX, texturePositionY), Color.Black);
                    //sb.DrawString(this.font, $"{textureIndexY}", new Vector2(texturePositionX, texturePositionY + 12), Color.Black);
                    //sb.DrawString(this.font, $"{flatIndex}", new Vector2(texturePositionX, texturePositionY + 12), Color.Black);
                }

            }

            //tlCamera == (Map + offset)



            //sb.End();
        }

        public void DrawVoid() {

        }
    }
}
