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

namespace BusinessSimGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Button Images and their Vectors
        private Texture2D startButton;
        private Vector2 startButtonPosition;

        // Mouse and Key handlers
        private MouseState mouseState;
        private MouseState prevMouseState;

        // Game State Enumerator
        enum GameState
        {
            StartMenu,
            MainDisplay
        }
        GameState gameState = GameState.StartMenu;
        private bool isLoading = false;

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
            IsMouseVisible = true;

            mouseState = Mouse.GetState();
            prevMouseState = mouseState;

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
            if (gameState == GameState.StartMenu)
                LoadMenu();
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            // wait for a mouse click
            mouseState = Mouse.GetState();

            if (prevMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
            {
                MouseClicked(mouseState.X, mouseState.Y);
            }

            prevMouseState = mouseState;

            if (gameState == GameState.MainDisplay && isLoading)
            {
                // Load the Main Display Resources here i.e. LoadMainScreen() or LoadGame()
                isLoading = false;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            switch (gameState)
            {
                case GameState.StartMenu:
                    spriteBatch.Draw(startButton, startButtonPosition, Color.White);
                    break;

                case GameState.MainDisplay:
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        void LoadMenu()
        {
            startButton = Content.Load<Texture2D>(@"startgame");
            startButtonPosition = new Vector2((GraphicsDevice.Viewport.Width / 2) - (startButton.Width / 2), (GraphicsDevice.Viewport.Height / 2) - (startButton.Height / 2));
        }

        void MouseClicked(int x, int y)
        {
            //creates a rectangle of 10x10 around the place where the mouse was clicked
            Rectangle mouseClickRect = new Rectangle(x, y, 10, 10);

            switch (gameState)
            {
                //check the startmenu
                case GameState.StartMenu:
                    Rectangle startButtonRect = new Rectangle((int)startButtonPosition.X, (int)startButtonPosition.Y, startButton.Width, startButton.Height);

                    if (mouseClickRect.Intersects(startButtonRect)) //player clicked start button
                    {
                        gameState = GameState.MainDisplay;
                        isLoading = true;
                    }
                    break;

                case GameState.MainDisplay:
                    break;
            }
        }
    }
}
