using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Saitawa.Generators;
using Saitawa.Player;

namespace Saitawa
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Saitawa : Game
    {
        GraphicsDeviceManager Graphics;
        SpriteBatch SpriteBatch;
        Map Map;
        Camera Camera;

        public int ScreenHeight { get; private set; }
        public int ScreenWidth { get; private set; }

        public Saitawa()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ScreenHeight = Graphics.PreferredBackBufferHeight;
            ScreenWidth = Graphics.PreferredBackBufferWidth;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Camera = new Camera(GraphicsDevice);

            SpriteFont font = Content.Load<SpriteFont>("fonts/Arial");
            Texture2D tileMapTexture = Content.Load<Texture2D>("tileset/tiles_packed");


            Map = new Map(SpriteBatch,GraphicsDevice,100,100,16, font,tileMapTexture);
            Map.GenerateRandomMap();

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Camera.Update(gameTime);

            Camera.HandleInput(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Transparent);


            SpriteBatch.Begin(transformMatrix: Camera.Transform);

            Map.Draw(gameTime, Camera);
            Camera.Draw(gameTime, SpriteBatch);

            SpriteBatch.End();

            
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
