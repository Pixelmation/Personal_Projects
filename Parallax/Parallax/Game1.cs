using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Parallax
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        #region create the layers
        Texture2D parallax1;
        Texture2D parallax2;
        Texture2D parallax3;
        Texture2D parallax4;
        Texture2D parallax5;
        Texture2D parallax6;
        Texture2D parallax7;
        #endregion

        #region Create the rectangles
        Rectangle rectangle11;
        Rectangle rectangle12;
        Rectangle rectangle13;

        Rectangle rectangle21;
        Rectangle rectangle22;
        Rectangle rectangle23;

        Rectangle rectangle31;
        Rectangle rectangle32;
        Rectangle rectangle33;

        Rectangle rectangle41;
        Rectangle rectangle42;
        Rectangle rectangle43;

        Rectangle rectangle51;
        Rectangle rectangle52;
        Rectangle rectangle53;

        Rectangle rectangle61;
        Rectangle rectangle62;
        Rectangle rectangle63;

        Rectangle rectangle71;
        Rectangle rectangle72;
        Rectangle rectangle73;
        #endregion

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
            //make the window 960x540
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 1024;
            graphics.ApplyChanges();

            //Put each trio of rectangles side by side
            #region placing rectangles
            rectangle11 = new Rectangle(0, 0, 1024, 1024);
            rectangle12 = new Rectangle(1024, 0, 1024, 1024);
            rectangle13 = new Rectangle(-1024, 0, 1024, 1024);

            rectangle21 = new Rectangle(0, 0, 1024, 1024);
            rectangle22 = new Rectangle(1024, 0, 1024, 1024);
            rectangle23 = new Rectangle(-1024, 0, 1024, 1024);

            rectangle31 = new Rectangle(0, 0, 1024, 1024);
            rectangle32 = new Rectangle(1024, 0, 1024, 1024);
            rectangle33 = new Rectangle(-1024, 0, 1024, 1024);

            rectangle41 = new Rectangle(0, 0, 960, 540);
            rectangle42 = new Rectangle(960, 0, 960, 540);
            rectangle43 = new Rectangle(-960, 0, 960, 540);

            rectangle51 = new Rectangle(0, 0, 960, 540);
            rectangle52 = new Rectangle(960, 0, 960, 540);
            rectangle53 = new Rectangle(-960, 0, 960, 540);

            rectangle61 = new Rectangle(0, 0, 960, 540);
            rectangle62 = new Rectangle(960, 0, 960, 540);
            rectangle63 = new Rectangle(-960, 0, 960, 540);

            rectangle71 = new Rectangle(0, 0, 960, 540);
            rectangle72 = new Rectangle(960, 0, 960, 540);
            rectangle73 = new Rectangle(-960, 0, 960, 540);
            #endregion

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

            #region load parallax layers
            parallax1 = Content.Load<Texture2D>("Parallax01");
            parallax2 = Content.Load<Texture2D>("Parallax02");
            parallax3 = Content.Load<Texture2D>("background");
            parallax4 = Content.Load<Texture2D>("layer_04");
            parallax5 = Content.Load<Texture2D>("layer_05");
            parallax6 = Content.Load<Texture2D>("layer_06");
            parallax7 = Content.Load<Texture2D>("layer_07");
            #endregion

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
            KeyboardState state = Keyboard.GetState();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            #region bounds check for the parallax layers

            #region layer1 scrolling
            if (rectangle11.X + parallax1.Width / 2 <= 0)
                rectangle11.X = rectangle12.X + parallax1.Width / 2;
            if (rectangle12.X + parallax1.Width / 2 <= 0)
                rectangle12.X = rectangle13.X + parallax1.Width / 2;
            if (rectangle13.X + parallax1.Width / 2 <= 0)
                rectangle13.X = rectangle11.X + parallax1.Width / 2;

            if (rectangle13.X >= 960)
                rectangle13.X = rectangle12.X - parallax1.Width / 2;
            if (rectangle12.X >= 960)
                rectangle12.X = rectangle11.X - parallax1.Width / 2;
            if (rectangle11.X >= 960)
                rectangle11.X = rectangle13.X - parallax1.Width / 2;
            #endregion

            #region layer2 scrolling
            if (rectangle21.X + parallax2.Width / 2 <= 0)
                rectangle21.X = rectangle22.X + parallax2.Width / 2;
            if (rectangle22.X + parallax2.Width / 2 <= 0)
                rectangle22.X = rectangle23.X + parallax2.Width / 2;
            if (rectangle23.X + parallax2.Width / 2 <= 0)
                rectangle23.X = rectangle21.X + parallax2.Width / 2;

            if (rectangle23.X >= 960)
                rectangle23.X = rectangle22.X - parallax2.Width / 2;
            if (rectangle22.X >= 960)
                rectangle22.X = rectangle21.X - parallax2.Width / 2;
            if (rectangle21.X >= 960)
                rectangle21.X = rectangle23.X - parallax2.Width / 2;
            #endregion

            #region layer3 scrolling
            if (rectangle31.X + parallax3.Width / 2 <= 0)
                rectangle31.X = rectangle32.X + parallax3.Width / 2;
            if (rectangle32.X + parallax3.Width / 2 <= 0)
                rectangle32.X = rectangle33.X + parallax3.Width / 2;
            if (rectangle33.X + parallax3.Width / 2 <= 0)
                rectangle33.X = rectangle31.X + parallax3.Width / 2;

            if (rectangle33.X >= 960)
                rectangle33.X = rectangle32.X - parallax3.Width / 2;
            if (rectangle32.X >= 960)
                rectangle32.X = rectangle31.X - parallax3.Width / 2;
            if (rectangle31.X >= 960)
                rectangle31.X = rectangle33.X - parallax3.Width / 2;
            #endregion

            #region layer4 scrolling
            if (rectangle41.X + parallax4.Width / 2 <= 0)
                rectangle41.X = rectangle42.X + parallax4.Width / 2;
            if (rectangle42.X + parallax4.Width / 2 <= 0)
                rectangle42.X = rectangle43.X + parallax4.Width / 2;
            if (rectangle43.X + parallax4.Width / 2 <= 0)
                rectangle43.X = rectangle41.X + parallax4.Width / 2;

            if (rectangle43.X >= 960)
                rectangle43.X = rectangle42.X - parallax4.Width / 2;
            if (rectangle42.X >= 960)
                rectangle42.X = rectangle41.X - parallax4.Width / 2;
            if (rectangle41.X >= 960)
                rectangle41.X = rectangle43.X - parallax4.Width / 2;
            #endregion

            #region layer5 scrolling
            if (rectangle51.X + parallax3.Width / 2 <= 0)
                rectangle51.X = rectangle32.X + parallax5.Width / 2;
            if (rectangle52.X + parallax3.Width / 2 <= 0)
                rectangle52.X = rectangle33.X + parallax5.Width / 2;
            if (rectangle53.X + parallax3.Width / 2 <= 0)
                rectangle53.X = rectangle31.X + parallax5.Width / 2;

            if (rectangle53.X >= 960)
                rectangle53.X = rectangle52.X - parallax5.Width / 2;
            if (rectangle52.X >= 960)
                rectangle52.X = rectangle51.X - parallax5.Width / 2;
            if (rectangle51.X >= 960)
                rectangle51.X = rectangle53.X - parallax5.Width / 2;
            #endregion

            #region layer6 scrolling
            if (rectangle61.X + parallax3.Width / 2 <= 0)
                rectangle61.X = rectangle32.X + parallax3.Width / 2;
            if (rectangle62.X + parallax3.Width / 2 <= 0)
                rectangle62.X = rectangle33.X + parallax3.Width / 2;
            if (rectangle63.X + parallax3.Width / 2 <= 0)
                rectangle63.X = rectangle31.X + parallax3.Width / 2;

            if (rectangle63.X >= 960)
                rectangle63.X = rectangle62.X - parallax6.Width / 2;
            if (rectangle62.X >= 960)
                rectangle62.X = rectangle31.X - parallax6.Width / 2;
            if (rectangle61.X >= 960)
                rectangle61.X = rectangle33.X - parallax6.Width / 2;
            #endregion

            #region layer7 scrolling
            if (rectangle71.X + parallax3.Width / 2 <= 0)
                rectangle71.X = rectangle32.X + parallax3.Width / 2;
            if (rectangle72.X + parallax3.Width / 2 <= 0)
                rectangle72.X = rectangle33.X + parallax3.Width / 2;
            if (rectangle73.X + parallax3.Width / 2 <= 0)
                rectangle73.X = rectangle31.X + parallax3.Width / 2;

            if (rectangle73.X >= 960)
                rectangle73.X = rectangle72.X - parallax7.Width / 2;
            if (rectangle72.X >= 960)
                rectangle72.X = rectangle71.X - parallax7.Width / 2;
            if (rectangle71.X >= 960)
                rectangle71.X = rectangle73.X - parallax7.Width / 2;
            #endregion

            #endregion


            #region moveright
            //move each layer to the right on right arrowkey press
            if (state.IsKeyDown(Keys.Right))
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

                rectangle41.X -= 1;
                rectangle42.X -= 1;
                rectangle43.X -= 1;

                rectangle51.X -= 1 / 2;
                rectangle52.X -= 1 / 2;
                rectangle53.X -= 1 / 2;

                rectangle61.X -= 1 / 4;
                rectangle62.X -= 1 / 4;
                rectangle63.X -= 1 / 4;

                rectangle71.X -= 1 / 8;
                rectangle72.X -= 1 / 8;
                rectangle73.X -= 1 / 8;
            }
            #endregion

            #region moveleft
            //move each layer to the left on left arrowkey press            
            if (state.IsKeyDown(Keys.Left))
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

                rectangle41.X += 1;
                rectangle42.X += 1;
                rectangle43.X += 1;

                rectangle51.X += 1 / 2;
                rectangle52.X += 1 / 2;
                rectangle53.X += 1 / 2;

                rectangle61.X += 1 / 4;
                rectangle62.X += 1 / 4;
                rectangle63.X += 1 / 4;

                rectangle71.X += 1 / 8;
                rectangle72.X += 1 / 8;
                rectangle73.X += 1 / 8;
            }
#endregion

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            #region drawing parallax
            spriteBatch.Draw(parallax7, rectangle71, Color.White);
            spriteBatch.Draw(parallax7, rectangle72, Color.White);
            spriteBatch.Draw(parallax7, rectangle73, Color.White);

            spriteBatch.Draw(parallax6, rectangle61, Color.White);
            spriteBatch.Draw(parallax6, rectangle62, Color.White);
            spriteBatch.Draw(parallax6, rectangle63, Color.White);

            spriteBatch.Draw(parallax5, rectangle51, Color.White);
            spriteBatch.Draw(parallax5, rectangle52, Color.White);
            spriteBatch.Draw(parallax5, rectangle53, Color.White);

            spriteBatch.Draw(parallax4, rectangle41, Color.White);
            spriteBatch.Draw(parallax4, rectangle42, Color.White);
            spriteBatch.Draw(parallax4, rectangle43, Color.White);

            spriteBatch.Draw(parallax3, rectangle31, Color.White);
            spriteBatch.Draw(parallax3, rectangle32, Color.White);
            spriteBatch.Draw(parallax3, rectangle33, Color.White);

            spriteBatch.Draw(parallax2, rectangle21, Color.White);
            spriteBatch.Draw(parallax2, rectangle22, Color.White);
            spriteBatch.Draw(parallax2, rectangle23, Color.White);

            spriteBatch.Draw(parallax1, rectangle11, Color.White);
            spriteBatch.Draw(parallax1, rectangle12, Color.White);
            spriteBatch.Draw(parallax1, rectangle13, Color.White);
            #endregion

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
