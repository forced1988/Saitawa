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


        public Camera(GraphicsDevice gd)
        {
            Position = new Vector2(0, 0);
            this.gd = gd;
            SetCameraPosition();
        }


        public void HandleInput(GameTime gt)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                Position = new Vector2(Position.X - 1, Position.Y);
            }

            if (state.IsKeyDown(Keys.Right))
            {
                Position = new Vector2(Position.X + 1, Position.Y);
            }

            if (state.IsKeyDown(Keys.Up))
            {
                Position = new Vector2(Position.X, Position.Y + 1);
            }

            if (state.IsKeyDown(Keys.Down))
            {
                Position = new Vector2(Position.X, Position.Y - 1);
            }
            SetCameraPosition();
        }

        public void SetCameraPosition()
        {
            topLeft = new Vector2(Position.X - (gd.Viewport.Width / 2), Position.Y - (gd.Viewport.Height / 2));
            bottomRight = new Vector2(topLeft.X + gd.Viewport.Width, topLeft.Y + gd.Viewport.Height);
        }
    }
}
