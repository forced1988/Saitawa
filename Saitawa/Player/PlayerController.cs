using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Saitawa.Player
{
    public class PlayerController
    {
        public Vector2 Position { get; set; }

        public PlayerController()
        {
            Position = new Vector2(0,0);
        }


        public void HandleInput(GameTime gt)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                Position = new Vector2(Position.X - 1,Position.Y);
            }

            if (state.IsKeyDown(Keys.Right))
            {
                Position = new Vector2(Position.X + 1, Position.Y);
            }

            if (state.IsKeyDown(Keys.Up))
            {
                Position = new Vector2(Position.X , Position.Y + 1);
            }

            if (state.IsKeyDown(Keys.Down))
            {
                Position = new Vector2(Position.X , Position.Y -1);
            }
        }
    }
}
