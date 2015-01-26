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
    class PaddleHuman : Paddle
    {
        private Texture2D paddleHumanSprite;
        private Vector2 paddleHumanPosition;

        public float X
        {
            get { return paddleHumanPosition.X; }
            set { paddleHumanPosition.X = value; }
        }

        public float Y
        {
            get { return paddleHumanPosition.Y; }
            set { paddleHumanPosition.Y = value; }
        }

        public int Width
        {
            get { return paddleHumanSprite.Width; }
        }

        /// <summary>
        /// Gets the height of the paddle's sprite.
        /// </summary>
        public int Height
        {
            get { return paddleHumanSprite.Height; }
        }

        /// <summary>
        /// Gets the bounding rectangle of the paddle.
        /// </summary>
        public Rectangle Boundary
        {
            get
            {
                return new Rectangle((int)paddleHumanPosition.X, (int)paddleHumanPosition.Y,
                    paddleHumanSprite.Width, paddleHumanSprite.Height);
            }
        }


        public PaddleHuman(Game game)
            : base(game)
        {
        }


        public override void Initialize()
        {
            base.Initialize();

            // Make sure base.Initialize() is called before this or handSprite will be null
            X = 0;
            Y = (GraphicsDevice.Viewport.Height / 2) - (Height / 2);

            Speed = DEFAULT_X_SPEED;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            paddleHumanSprite = contentManager.Load<Texture2D>(@"Content\Images\hand");
        }

        public override void Update(GameTime gameTime)
        {
            // Scale the movement based on time
            float moveDistance = Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Move paddle, but don't allow movement off the screen

            KeyboardState newKeyState = Keyboard.GetState();
            if (newKeyState.IsKeyDown(Keys.Down) && Y + paddleHumanSprite.Height
                + moveDistance <= GraphicsDevice.Viewport.Height)
            {
                Y += moveDistance;
            }
            else if (newKeyState.IsKeyDown(Keys.Up) && Y - moveDistance >= 0)
            {
                Y -= moveDistance;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(paddleHumanSprite, paddleHumanPosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
