using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Object_collecting_game
{
    //change Content.mgcb to be opened with Common Editor Factory
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        AnimatedSprite sprite;
        int score = 0;
        SpriteFont Font;

        Texture2D Coin;

        Coin CoinRect1;
        Coin CoinRect2;
        Coin CoinRect3;
        Coin CoinRect4;
        Coin CoinRect5;
        Coin CoinRect6;

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
            //make the window 960x540
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 540;
            graphics.ApplyChanges();

            CoinRect1 = new Coin(160, 20, 55, 63);
            CoinRect2 = new Coin(760, 20, 55, 63);
            CoinRect3 = new Coin(60, 230, 55, 63);
            CoinRect4 = new Coin(860, 230, 55, 63);
            CoinRect5 = new Coin(160, 440, 55, 63);
            CoinRect6 = new Coin(760, 440, 55, 63);


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

            // TODO: use this.Content to load your game content here
            sprite = new AnimatedSprite(Content.Load<Texture2D>("SpriteSheet"), 1, 56, 88)
            {
                Position = new Vector2(480, 270)
            };

            Coin = Content.Load<Texture2D>("Coin");

            Font = Content.Load<SpriteFont>("Font");

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

            // TODO: Add your update logic here
            sprite.HandleSpriteMovement(gameTime);


            if (sprite.CollisionRect.Intersects(CoinRect1.CoinRect))
            {
                if (CoinRect1.HasBeenPickedUp == false)
                {
                    CoinRect1.HasBeenPickedUp = true;
                    score++;
                }
            }
            if (sprite.CollisionRect.Intersects(CoinRect2.CoinRect))
            {
                if (CoinRect2.HasBeenPickedUp == false)
                {
                    CoinRect2.HasBeenPickedUp = true;
                    score++;
                }
            }
            if (sprite.CollisionRect.Intersects(CoinRect3.CoinRect))
            {
                if (CoinRect3.HasBeenPickedUp == false)
                {
                    CoinRect3.HasBeenPickedUp = true;
                    score++;
                }
            }
            if (sprite.CollisionRect.Intersects(CoinRect4.CoinRect))
            {
                if (CoinRect4.HasBeenPickedUp == false)
                {
                    CoinRect4.HasBeenPickedUp = true;
                    score++;
                }
            }
            if (sprite.CollisionRect.Intersects(CoinRect5.CoinRect))
            {
                if (CoinRect5.HasBeenPickedUp == false)
                {
                    CoinRect5.HasBeenPickedUp = true;
                    score++;
                }
            }
            if (sprite.CollisionRect.Intersects(CoinRect6.CoinRect))
            {
                if (CoinRect6.HasBeenPickedUp == false)
                {
                    CoinRect6.HasBeenPickedUp = true;
                    score++;
                }
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkOliveGreen);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(sprite.Texture, sprite.Position, sprite.SourceRect, Color.White, 0f, sprite.Origin, 1.0f, SpriteEffects.None, 0);
            if (CoinRect1.HasBeenPickedUp == false)
            {
                spriteBatch.Draw(Coin, CoinRect1.CoinRect, Color.White);
            }
            if (CoinRect2.HasBeenPickedUp == false)
            {
                spriteBatch.Draw(Coin, CoinRect2.CoinRect, Color.White);
            }
            if (CoinRect3.HasBeenPickedUp == false)
            {
                spriteBatch.Draw(Coin, CoinRect3.CoinRect, Color.White);
            }
            if (CoinRect4.HasBeenPickedUp == false)
            {
                spriteBatch.Draw(Coin, CoinRect4.CoinRect, Color.White);
            }
            if (CoinRect5.HasBeenPickedUp == false)
            {
                spriteBatch.Draw(Coin, CoinRect5.CoinRect, Color.White);
            }
            if (CoinRect6.HasBeenPickedUp == false)
            {
                spriteBatch.Draw(Coin, CoinRect6.CoinRect, Color.White);
            }

            string scoreString = "You collected " + score + " Coins";
            string winMessage = "YOU WIN!";

            var scoreStringDisplay = Font.MeasureString(scoreString);
            var winMessageDisplay = Font.MeasureString(winMessage);

            spriteBatch.DrawString(Font, scoreString, new Vector2(480 -  scoreStringDisplay.X / 2, 10), Color.White);
            if ( score == 6)
            {
                spriteBatch.DrawString(Font, "YOU WIN!", new Vector2(480 - winMessageDisplay.X / 2, 270), Color.White);
            }
            
            spriteBatch.End();

            base.Draw(gameTime);

        }       
    }
}
