using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Text_Input
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //initializes a string
        string result = "";

        //creates an event handler for on text entered
        EventHandler<TextInputEventArgs> onTextEntered;

        //prev keyboard state for checking special chars later
        KeyboardState _prevKeyState;

        //the font file
        SpriteFont Font;

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

            //handles the text input methods
            Window.TextInput += TextEntered;
            onTextEntered += HandleInput;

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

            //loads an ariel 48 font
            Font = Content.Load<SpriteFont>("Font");

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

            KeyboardState keyState = Keyboard.GetState();

            // TODO: Add your update logic here

            if ((keyState.IsKeyDown(Keys.LeftShift) && _prevKeyState.IsKeyDown(Keys.D0)) && (keyState.IsKeyUp(Keys.LeftShift) && _prevKeyState.IsKeyUp(Keys.D0)))
            {
                onTextEntered.Invoke(this, new TextInputEventArgs('('));
            }

            if ((keyState.IsKeyDown(Keys.LeftShift) && _prevKeyState.IsKeyDown(Keys.D0)) && (keyState.IsKeyUp(Keys.LeftShift) && _prevKeyState.IsKeyUp(Keys.D0)))
            {
                onTextEntered.Invoke(this, new TextInputEventArgs(')'));
            }

            if (keyState.IsKeyDown(Keys.Back) && _prevKeyState.IsKeyUp(Keys.Back))
            {
                onTextEntered.Invoke(this, new TextInputEventArgs('\b'));
            }

            // Handle other special characters here (such as tab )

            _prevKeyState = keyState;
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

            //draw result
            spriteBatch.Begin();
            spriteBatch.DrawString(Font, result, new Vector2(100, 100), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Collects the text entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextEntered(object sender, TextInputEventArgs e)
        {
            if (onTextEntered != null)
                onTextEntered.Invoke(sender, e);
        }

        /// <summary>
        /// turns the text entered into a char, then adds it to result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleInput(object sender, TextInputEventArgs e)
        {
            char charEntered = e.Character;
            result += charEntered;
        }
    }
}
