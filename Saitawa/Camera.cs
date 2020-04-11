using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Saitawa
{
    public class Camera
    {
        public Vector2 Position { get; set; }
        public Vector2 topLeft { get; set; }
        public Vector2 bottomRight { get; set; }
        private GraphicsDevice gd;
        private float speed = 2f;

        public Camera(GraphicsDevice gd)
        {
            Position = new Vector2(gd.Viewport.Width / 2, gd.Viewport.Height / 2);
            this.gd = gd;
            SetCameraPosition();
        }


        public void HandleInput(GameTime gt)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                Position = new Vector2(Position.X - speed, Position.Y);
            }

            if (state.IsKeyDown(Keys.Right))
            {
                Position = new Vector2(Position.X + speed, Position.Y);
            }

            if (state.IsKeyDown(Keys.Up))
            {
                Position = new Vector2(Position.X, Position.Y - speed);
            }

            if (state.IsKeyDown(Keys.Down))
            {
                Position = new Vector2(Position.X, Position.Y + speed);
            }
            SetCameraPosition();
        }

        public void SetCameraPosition()
        {
            topLeft = new Vector2(Position.X - (gd.Viewport.Width / 4), Position.Y - (gd.Viewport.Height / 4));
            bottomRight = new Vector2(topLeft.X + gd.Viewport.Width / 2, topLeft.Y + gd.Viewport.Height / 2);
        }


        public void Draw(GameTime time, SpriteBatch sb) {
            sb.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend);
            Texture2D SimpleTexture = new Texture2D(gd, 1, 1, false, SurfaceFormat.Color);
            SimpleTexture.SetData(new[] { Color.White });
            sb.Draw(SimpleTexture, new Rectangle((int)topLeft.X, (int)bottomRight.Y, gd.Viewport.Width / 2, 1), Color.White);

            sb.Draw(SimpleTexture, new Rectangle((int)topLeft.X, (int)topLeft.Y, 1, gd.Viewport.Height / 2), Color.White);
            sb.Draw(SimpleTexture, new Rectangle((int)bottomRight.X, (int)topLeft.Y, 1, gd.Viewport.Height / 2), Color.White);

            sb.Draw(SimpleTexture, new Rectangle((int)topLeft.X, (int)topLeft.Y, gd.Viewport.Width / 2, 1), Color.White);
            sb.End();
        }
    }
}
