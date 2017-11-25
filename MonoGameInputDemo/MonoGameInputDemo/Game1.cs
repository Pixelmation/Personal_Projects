using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameInputDemo
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 position;
        Vector2 origin;
        KeyboardState previousState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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

            base.Initialize();
            position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2,
                                   graphics.GraphicsDevice.Viewport.Height / 2);
            origin = new Vector2(64, 64);
            previousState = Keyboard.GetState();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = this.Content.Load<Texture2D>("Blac_Mage_flat");

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
            #region arrowkeys control
            KeyboardState state = Keyboard.GetState();
            
            if (state.IsKeyDown(Keys.Escape))
                Exit();
            
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (var key in state.GetPressedKeys())
                sb.Append("Keys: ").Append(key).Append(" pressed ");
            
            if (sb.Length > 0)
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            else
                System.Diagnostics.Debug.WriteLine("No Keys Pressed");
            
            if (state.IsKeyDown(Keys.Up)) //& !previousState.IsKeyDown(Keys.Up))
                position.Y -= 10;
            if (state.IsKeyDown(Keys.Down)) //& !previousState.IsKeyDown(Keys.Down))
                position.Y += 10;
            if (state.IsKeyDown(Keys.Left)) //& !previousState.IsKeyDown(Keys.Left))
                position.X -= 10;
            if (state.IsKeyDown(Keys.Right)) //& !previousState.IsKeyDown(Keys.Right))
                position.X += 10;
            #endregion
            #region mouse control
            //MouseState state = Mouse.GetState();
            //
            //position.X = state.X;
            //position.Y = state.Y;
            //
            //System.Diagnostics.Debug.WriteLine(state.X.ToString() + "," + state.Y.ToString());
            //
            //if (state.LeftButton == ButtonState.Pressed)
            //    Exit();
            #endregion
            #region gamepad control
            //GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
            //
            //if (capabilities.IsConnected)
            //{
            //    GamePadState state = GamePad.GetState(PlayerIndex.One);
            //    if(capabilities.HasLeftXThumbStick)
            //    {
            //        if (state.ThumbSticks.Left.X < -0.5f)
            //            position.X -= 10.0f;
            //        if (state.ThumbSticks.Left.X > 0.5f)
            //            position.X += 10.0f;
            //        if (state.ThumbSticks.Left.Y < -0.5f)
            //            position.Y += 10.0f;
            //        if (state.ThumbSticks.Left.Y > 0.5f)
            //            position.Y -= 10.0f;
            //    }
            //
            //    if (capabilities.HasStartButton)
            //    {
            //        if (state.IsButtonDown(Buttons.Start))
            //            Exit();
            //    }
            //}
            #endregion

            base.Update(gameTime);

            previousState = state;
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
#pragma warning disable CS0618 // Type or member is obsolete
            spriteBatch.Draw(texture, position, origin:origin);
#pragma warning restore CS0618 // Type or member is obsolete
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
