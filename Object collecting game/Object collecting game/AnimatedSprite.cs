﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Object_collecting_game
{
    class AnimatedSprite
    {
        KeyboardState currentKBState;
        KeyboardState previousKBState;

        Texture2D spriteTexture;
        float timer = 0f;
        float interval = 200f;
        int currentFrame = 0;
        int spriteWidth = 56;
        int spriteHeight = 88;
        int spriteSpeed = 2;
        Rectangle sourceRect;
        Vector2 position;
        Vector2 origin;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public Texture2D Texture
        {
            get { return spriteTexture; }
            set { spriteTexture = value; }
        }
        public Rectangle SourceRect
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }

        public Rectangle CollisionRect
        {
            get { return new Rectangle((int)position.X - spriteWidth / 2, (int)position.Y - spriteHeight / 2, sourceRect.Width, sourceRect.Height); }
            
        }


        public AnimatedSprite(Texture2D texture, int currentFrame, int spriteWidth, int spriteHeight)
        {
            this.spriteTexture = texture;
            this.currentFrame = currentFrame;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
 
        }

        public void HandleSpriteMovement(GameTime gameTime)
        {
            previousKBState = currentKBState;
            currentKBState = Keyboard.GetState();

            sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);

            #region if the player stops moving, reset frames to standing
            if (currentKBState.GetPressedKeys().Length == 0)
            {
                if (currentFrame > 0 && currentFrame < 4)
                {
                    currentFrame = 0;
                }
                if (currentFrame > 4 && currentFrame < 8)
                {
                    currentFrame = 4;
                }
                if (currentFrame > 8 && currentFrame < 12)
                {
                    currentFrame = 8;
                }
                if (currentFrame > 12 && currentFrame < 16)
                {
                    currentFrame = 12;
                }
            }
            #endregion

            //sprint check
            if (currentKBState.IsKeyDown(Keys.LeftShift))
            {
                spriteSpeed = 4;
                interval = 100;
            }
            if (currentKBState.IsKeyUp(Keys.LeftShift))
            {
                spriteSpeed = 2;
                interval = 100;
            }

            //call movement animation and set speed to zero if sprite will move offscreen
            #region movement UP
            if (currentKBState.IsKeyDown(Keys.Up))
            {
                AnimateUp(gameTime);
                if (position.Y > 43)
                {
                    position.Y -= spriteSpeed;
                }
            }
            #endregion

            #region movement Down
            if (currentKBState.IsKeyDown(Keys.Down))
            {
                AnimateDown(gameTime);
                if (position.Y < 494)
                {
                    position.Y += spriteSpeed;
                }
            }
            #endregion

            #region movement Left
            if (currentKBState.IsKeyDown(Keys.Left))
            {
                AnimateLeft(gameTime);
                if (position.X > 28)
                {
                    position.X -= spriteSpeed;
                }
            }
            #endregion

            #region movement Right
            if (currentKBState.IsKeyDown(Keys.Right))
            {
                AnimateRight(gameTime);
                if (position.X < 932)
                {
                    position.X += spriteSpeed;
                }
            }
            #endregion

            //places the player sprite in the center
            origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);

        }

        //animate frames during movement

        #region UP frames
        public void AnimateUp(GameTime gameTime)
        {
            if (currentKBState != previousKBState)
            {
                currentFrame = 13;
            }

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame > 15)
                {
                    currentFrame = 12;
                }
                timer = 0f;
            }
        }
        #endregion

        #region DOWN frames
        public void AnimateDown(GameTime gameTime)
        {
            if (currentKBState != previousKBState)
            {
                currentFrame = 1;
            }

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame > 3)
                {
                    currentFrame = 0;
                }
                timer = 0f;
            }
        }
        #endregion

        #region LEFT frames
        public void AnimateLeft(GameTime gameTime)
        {
            if (currentKBState != previousKBState)
            {
                currentFrame = 5;
            }

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame > 7)
                {
                    currentFrame = 4;
                }
                timer = 0f;
            }
        }
        #endregion

        #region RIGHT frames
        public void AnimateRight(GameTime gameTime)
        {
            if (currentKBState != previousKBState)
            {
                currentFrame = 9;
            }

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame > 11)
                {
                    currentFrame = 8;
                }
                timer = 0f;
            }
        }
        #endregion
    }
}
