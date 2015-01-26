using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Pong1
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Paddle : Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region Private Members
        protected SpriteBatch spriteBatch;
        protected ContentManager contentManager;

        // Paddle sprite
        //protected Texture2D paddleSprite;

        // Paddle location
        protected Vector2 paddlePosition;

        protected const float DEFAULT_X_SPEED = 250;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the paddle horizontal speed.
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// Gets or sets the X position of the paddle.
        /// </summary>
        public float X
        {
            get { return paddlePosition.X; }
            set { paddlePosition.X = value; }
        }

        /// <summary>
        /// Gets or sets the Y position of the paddle.
        /// </summary>
        public float Y
        {
            get { return paddlePosition.Y; }
            set { paddlePosition.Y = value; }
        }

        //public int Width
        //{
        //    get { return paddleSprite.Width; }
        //}

        ///// <summary>
        ///// Gets the height of the paddle's sprite.
        ///// </summary>
        //public int Height
        //{
        //    get { return paddleSprite.Height; }
        //}

        #endregion

        public Paddle(Game game)
            : base(game)
        {
            contentManager = new ContentManager(game.Services);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            //// Scale the movement based on time
            //float moveDistance = Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //// Move paddle, but don't allow movement off the screen

            //KeyboardState newKeyState = Keyboard.GetState();
            //if (newKeyState.IsKeyDown(Keys.Right) && X + paddleSprite.Width
            //    + moveDistance <= GraphicsDevice.Viewport.Width)
            //{
            //    X += moveDistance;
            //}
            //else if (newKeyState.IsKeyDown(Keys.Left) && X - moveDistance >= 0)
            //{
            //    X -= moveDistance;
            //}

            //base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            //spriteBatch.Begin();
            //spriteBatch.Draw(paddleSprite, paddlePosition, Color.White);
            //spriteBatch.End();

            //base.Draw(gameTime);
        }
    }
}
