using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Better_Parallax
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D Parallax1;

        Texture2D Parallax2;

        Texture2D Parallax3;


        Rectangle rectangle11;
        Rectangle rectangle12;
        Rectangle rectangle13;

        Rectangle rectangle21;
        Rectangle rectangle22;
        Rectangle rectangle23;

        Rectangle rectangle31;
        Rectangle rectangle32;
        Rectangle rectangle33;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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

            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 1024;
            graphics.ApplyChanges();

            rectangle11 = new Rectangle(0, 0, 1024, 1024);
            rectangle12 = new Rectangle(960, 0, 1024, 1024);
            rectangle13 = new Rectangle(-960, 0, 1024, 1024);

            rectangle21 = new Rectangle(0, 0, 1024, 1024);
            rectangle22 = new Rectangle(960, 0, 1024, 1024);
            rectangle23 = new Rectangle(-960, 0, 1024, 1024);

            rectangle31 = new Rectangle(0, 0, 1024, 1024);
            rectangle32 = new Rectangle(960, 0, 1024, 1024);
            rectangle33 = new Rectangle(-960, 0, 1024, 1024);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Parallax1 = Content.Load<Texture2D>("background");
            Parallax2 = Content.Load<Texture2D>("Parallax01");
            Parallax3 = Content.Load<Texture2D>("Parallax02");

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

            KeyboardState KBState = new KeyboardState();

            #region layer1 scrolling
            if (rectangle11.X + Parallax1.Width / 2 <= 0)
                rectangle11.X = rectangle12.X + Parallax1.Width / 2;
            if (rectangle12.X + Parallax1.Width / 2 <= 0)
                rectangle12.X = rectangle13.X + Parallax1.Width / 2;
            if (rectangle13.X + Parallax1.Width / 2 <= 0)
                rectangle13.X = rectangle11.X + Parallax1.Width / 2;

            if (rectangle13.X >= 960)
                rectangle13.X = rectangle12.X - Parallax1.Width / 2;
            if (rectangle12.X >= 960)
                rectangle12.X = rectangle11.X - Parallax1.Width / 2;
            if (rectangle11.X >= 960)
                rectangle11.X = rectangle13.X - Parallax1.Width / 2;
            #endregion

            #region layer2 scrolling
            if (rectangle21.X + Parallax2.Width / 2 <= 0)
                rectangle21.X = rectangle22.X + Parallax2.Width / 2;
            if (rectangle22.X + Parallax2.Width / 2 <= 0)
                rectangle22.X = rectangle23.X + Parallax2.Width / 2;
            if (rectangle23.X + Parallax2.Width / 2 <= 0)
                rectangle23.X = rectangle21.X + Parallax2.Width / 2;

            if (rectangle23.X >= 960)
                rectangle23.X = rectangle22.X - Parallax2.Width / 2;
            if (rectangle22.X >= 960)
                rectangle22.X = rectangle21.X - Parallax2.Width / 2;
            if (rectangle21.X >= 960)
                rectangle21.X = rectangle23.X - Parallax2.Width / 2;
            #endregion

            #region layer3 scrolling
            if (rectangle31.X + Parallax3.Width / 2 <= 0)
                rectangle31.X = rectangle32.X + Parallax3.Width / 2;
            if (rectangle32.X + Parallax3.Width / 2 <= 0)
                rectangle32.X = rectangle33.X + Parallax3.Width / 2;
            if (rectangle33.X + Parallax3.Width / 2 <= 0)
                rectangle33.X = rectangle31.X + Parallax3.Width / 2;

            if (rectangle33.X >= 960)
                rectangle33.X = rectangle32.X - Parallax3.Width / 2;
            if (rectangle32.X >= 960)
                rectangle32.X = rectangle31.X - Parallax3.Width / 2;
            if (rectangle31.X >= 960)
                rectangle31.X = rectangle33.X - Parallax3.Width / 2;
            #endregion

            if (KBState.IsKeyDown(Keys.Right))
            {
                rectangle11.X -= 10;
                rectangle12.X -= 10;
                rectangle13.X -= 10;

                rectangle21.X -= 5;
                rectangle22.X -= 5;
                rectangle23.X -= 5;

                rectangle31.X -= 2;
                rectangle32.X -= 2;
                rectangle33.X -= 2;
            }

            if (KBState.IsKeyDown(Keys.Left))
            {
                rectangle11.X += 10;
                rectangle12.X += 10;
                rectangle13.X += 10;
                              
                rectangle21.X += 5;
                rectangle22.X += 5;
                rectangle23.X += 5;
                              
                rectangle31.X += 2;
                rectangle32.X += 2;
                rectangle33.X += 2;
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            spriteBatch.Draw(Parallax1, rectangle11, Color.White);
            spriteBatch.Draw(Parallax1, rectangle12, Color.White);
            spriteBatch.Draw(Parallax1, rectangle13, Color.White);

            spriteBatch.Draw(Parallax2, rectangle21, Color.White);
            spriteBatch.Draw(Parallax2, rectangle22, Color.White);
            spriteBatch.Draw(Parallax2, rectangle23, Color.White);

            spriteBatch.Draw(Parallax3, rectangle31, Color.White);
            spriteBatch.Draw(Parallax3, rectangle32, Color.White);
            spriteBatch.Draw(Parallax3, rectangle33, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
