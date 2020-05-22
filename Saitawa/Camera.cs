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
        public Matrix Transform { get; private set; }
        public Vector2 Position { get; set; }
        private GraphicsDevice GraphicsDevice;
        private float Speed = 2f;

        public Vector2 TopLeft { get; set; }
        public Vector2 BottomRight { get; set; }

        public Camera(GraphicsDevice gd)
        {
            this.GraphicsDevice = gd;
            Position = new Vector2(gd.Viewport.Width / 2, gd.Viewport.Height / 2);
        }

        public void Update(GameTime gameTime)
        {
            HandleInput(gameTime);
            CalculateTransform(Matrix.CreateTranslation(-Position.X, -Position.Y, 0));
            CalculateBounds();
        }

        public void CalculateTransform(Matrix position)
        {
            var offset = Matrix.CreateTranslation(
                GraphicsDevice.Viewport.Width / 2,
                GraphicsDevice.Viewport.Height / 2,
                0);

            Transform = position * offset;
        }

        public void HandleInput(GameTime gt)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                Position = new Vector2(Position.X - Speed, Position.Y); 
            }

            if (state.IsKeyDown(Keys.Right))
            {
                Position = new Vector2(Position.X + Speed, Position.Y);
            }

            if (state.IsKeyDown(Keys.Up))
            {
                Position = new Vector2(Position.X, Position.Y - Speed);
            }

            if (state.IsKeyDown(Keys.Down))
            {
                Position = new Vector2(Position.X, Position.Y + Speed);
            }


            //MouseState mouseState = Mouse.GetState();

            //// Update our sprites position to the current cursor 
            //Position = new Vector2(mouseState.X, mouseState.Y + Speed);
        }

        public void CalculateBounds() {
            TopLeft = new Vector2(Position.X - (GraphicsDevice.Viewport.Width / 2), Position.Y - (GraphicsDevice.Viewport.Height / 2));
            BottomRight = new Vector2(TopLeft.X + GraphicsDevice.Viewport.Width, TopLeft.Y + GraphicsDevice.Viewport.Height);

            //TopLeft = new Vector2(Position.X - (GraphicsDevice.Viewport.Width / 2) + 32, Position.Y - (GraphicsDevice.Viewport.Height / 2) + 32);
            //BottomRight = new Vector2(TopLeft.X + GraphicsDevice.Viewport.Width - 64, TopLeft.Y + GraphicsDevice.Viewport.Height - 64);
        }

        public void Draw(GameTime time, SpriteBatch sb) {
            //Texture2D SimpleTexture = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            //SimpleTexture.SetData(new[] { Color.White });
            //sb.Draw(SimpleTexture, new Rectangle((int)TopLeft.X, (int)BottomRight.Y, GraphicsDevice.Viewport.Width / 2, 1), Color.White);

            //sb.Draw(SimpleTexture, new Rectangle((int)TopLeft.X, (int)TopLeft.Y, 1, GraphicsDevice.Viewport.Height / 2), Color.White);
            //sb.Draw(SimpleTexture, new Rectangle((int)BottomRight.X, (int)TopLeft.Y, 1, GraphicsDevice.Viewport.Height / 2), Color.White);

            //sb.Draw(SimpleTexture, new Rectangle((int)TopLeft.X, (int)TopLeft.Y, GraphicsDevice.Viewport.Width / 2, 1), Color.White);
        }
    }

    //public class Camera
    //{
    //    public Vector2 Position { get; set; }
    //    public Vector2 TopLeft { get; set; }
    //    public Vector2 BottomRight { get; set; }
    //    private GraphicsDevice gd;
    //    private float speed = 2f;

    //    public Camera(GraphicsDevice gd)
    //    {
    //        Position = new Vector2(gd.Viewport.Width / 2, gd.Viewport.Height / 2);
    //        this.gd = gd;
    //        SetCameraPosition();
    //    }


    //    public void HandleInput(GameTime gt)
    //    {
    //        KeyboardState state = Keyboard.GetState();
    //        if (state.IsKeyDown(Keys.Left))
    //        {
    //            Position = new Vector2(Position.X - speed, Position.Y);
    //        }

    //        if (state.IsKeyDown(Keys.Right))
    //        {
    //            Position = new Vector2(Position.X + speed, Position.Y);
    //        }

    //        if (state.IsKeyDown(Keys.Up))
    //        {
    //            Position = new Vector2(Position.X, Position.Y - speed);
    //        }

    //        if (state.IsKeyDown(Keys.Down))
    //        {
    //            Position = new Vector2(Position.X, Position.Y + speed);
    //        }
    //        SetCameraPosition();
    //    }

    //    public void SetCameraPosition()
    //    {
    //        TopLeft = new Vector2(Position.X - (gd.Viewport.Width / 4), Position.Y - (gd.Viewport.Height / 4));
    //        BottomRight = new Vector2(TopLeft.X + gd.Viewport.Width / 2, TopLeft.Y + gd.Viewport.Height / 2);
    //    }


    //    public void Draw(GameTime time, SpriteBatch sb)
    //    {
    //        sb.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend);
    //        Texture2D SimpleTexture = new Texture2D(gd, 1, 1, false, SurfaceFormat.Color);
    //        SimpleTexture.SetData(new[] { Color.White });
    //        sb.Draw(SimpleTexture, new Rectangle((int)TopLeft.X, (int)BottomRight.Y, gd.Viewport.Width / 2, 1), Color.White);

    //        sb.Draw(SimpleTexture, new Rectangle((int)TopLeft.X, (int)TopLeft.Y, 1, gd.Viewport.Height / 2), Color.White);
    //        sb.Draw(SimpleTexture, new Rectangle((int)BottomRight.X, (int)TopLeft.Y, 1, gd.Viewport.Height / 2), Color.White);

    //        sb.Draw(SimpleTexture, new Rectangle((int)TopLeft.X, (int)TopLeft.Y, gd.Viewport.Width / 2, 1), Color.White);
    //        sb.End();
    //    }
    //}
}
