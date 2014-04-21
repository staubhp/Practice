#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace MonoGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D background;        
        private AnimatedSprite animatedSprite;
        GameObject topWall;
        GameObject bottomWall;
        GameObject shuttle;

        LevelLoader level;

        public Game1()
            : base()
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
            
            //background = Content.Load<Texture2D>("stars");

            level = new LevelLoader("../../../Levels/Level.xml", this.Content);            
            
            Texture2D animatedSpriteTexture = Content.Load<Texture2D>("SmileyWalk");
            animatedSprite = new AnimatedSprite(animatedSpriteTexture, 4, 4);

            Texture2D wallTexture = Content.Load<Texture2D>("Wall");
            topWall = new GameObject (wallTexture, Vector2.Zero );
            bottomWall = new GameObject (wallTexture, new Vector2(0, Window.ClientBounds.Height - wallTexture.Height ));

            Texture2D shuttleTexture = Content.Load<Texture2D>("Shuttle");
            shuttle = new GameObject(shuttleTexture, new Vector2(100, 100));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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

            animatedSprite.Update();

            #region Movement
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {                
                shuttle.Position.X -= 5;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                shuttle.Position.X += 5;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                shuttle.Position.Y += 5;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                shuttle.Position.Y -= 5;
            }          
            #endregion

            #region Crude Collision Detection
            if (shuttle.BoundingBox.Intersects(topWall.BoundingBox))
            {
                shuttle.Position.Y = topWall.BoundingBox.Bottom;
            }
            if (shuttle.BoundingBox.Intersects(bottomWall.BoundingBox))
            {
                shuttle.Position.Y = bottomWall.BoundingBox.Y - shuttle.BoundingBox.Height;
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

            //spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);            

            level.Draw(spriteBatch);

            animatedSprite.Draw(spriteBatch, new Vector2(50, 50));

            topWall.Draw(spriteBatch);
            bottomWall.Draw(spriteBatch);

            shuttle.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
