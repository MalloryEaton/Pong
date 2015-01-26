using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pong1
{
    class PaddleComputer : Paddle
    {
        private Texture2D paddleComputerSprite;
        protected Vector2 paddleComputerPosition;

        #region Private Stuff
        public float X
        {
            get { return paddleComputerPosition.X; }
            set { paddleComputerPosition.X = value; }
        }

        public float Y
        {
            get { return paddleComputerPosition.Y; }
            set { paddleComputerPosition.Y = value; }
        }

        public int Width
        {
            get { return paddleComputerSprite.Width; }
        }

        /// <summary>
        /// Gets the height of the paddle's sprite.
        /// </summary>
        public int Height
        {
            get { return paddleComputerSprite.Height; }
        }
        #endregion

        /// <summary>
        /// Gets the bounding rectangle of the paddle.
        /// </summary>
        public Rectangle Boundary
        {
            get
            {
                return new Rectangle((int)paddleComputerPosition.X, (int)paddleComputerPosition.Y,
                    paddleComputerSprite.Width, paddleComputerSprite.Height);
            }
        }

        public PaddleComputer(Game game)
            : base(game)
        {
        }


        public override void Initialize()
        {
            base.Initialize();

            // Make sure base.Initialize() is called before this or Sprite will be null
            X = (GraphicsDevice.Viewport.Width - Width);
            Y = (GraphicsDevice.Viewport.Height / 2) - (Height / 2);

            //Speed = DEFAULT_X_SPEED;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            paddleComputerSprite = contentManager.Load<Texture2D>(@"Content\Images\dogrobot");
        }

        public override void Update(GameTime gameTime)
        {
            // Scale the movement based on time
            //float moveDistance = Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            float moveDistance = (float)0.04;
            // Move paddle, but don't allow movement off the screen

            Ball ball = Game.Components[0] as Ball;
            float ballMiddle = ball.ballPosition.Y;
            float paddleComputerMiddle = (paddleComputerPosition.Y);
            if((ballMiddle > paddleComputerMiddle) && (Y + paddleComputerSprite.Height + moveDistance <= GraphicsDevice.Viewport.Height))
            {
                float ydown = (ballMiddle - paddleComputerMiddle) * moveDistance;
                Y += ydown;
            }
            else if ((ballMiddle < paddleComputerMiddle) && (Y + moveDistance >= 0))
            {
                float yup = (ballMiddle - paddleComputerMiddle) * moveDistance;
                Y += yup;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(paddleComputerSprite, paddleComputerPosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
