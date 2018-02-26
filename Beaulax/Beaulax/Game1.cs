using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Beaulax
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        #region Declarations
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 initialPosition;

        #region Main Menu
        // main menu textures and attributes
        Texture2D mainMenuBackground;
        Texture2D newGameButton;
        Texture2D loadGameButton;
        Texture2D optionsButton;
        Texture2D exitButton;
        Texture2D teamName;
        bool newGameButtonHover = false;
        bool loadGameButtonHover = false;
        bool optionsButtonHover = false;
        bool exitButtonHover = false;
        int buttonWidth;
        int buttonHeight;
        int buttonX;
        int newGameButtonY;
        int loadGameButtonY;
        int optionsButtonY;
        int teamNameWidth;
        int teamNameHeight;
        int teamNameX;
        int teamNameY;
        int exitButtonDimension;
        int exitButtonX;
        int exitButtonY;
        #endregion

        // screen size attributes
        int screenWidth = 1200;
        int screenHeight = 720;
        double widthScaleFactor = 1;
        double heightScaleFactor = 1;

        // set up game states
        enum GameState { MainMenu, Options, Gameplay, PauseMenu, MapView, GameOver };
        GameState currentState;

        // call classes
        Classes.Player player;
        Classes.SaveLoad saver;
        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // set the default resolution
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();
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

            // set initial position of the player
            initialPosition = new Vector2(50, 500);
            saver = new Classes.SaveLoad();

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
            player = new Classes.Player(this.Content.Load<Texture2D>("the_smallest_space_pirate"), true, true, true, 2, 3f, 10f, initialPosition);

            // load main menu assets
            mainMenuBackground = Content.Load<Texture2D>("Main Menu Assets/Beaulax Menu");
            newGameButton = Content.Load<Texture2D>("Main Menu Assets/NewGame");
            loadGameButton = Content.Load<Texture2D>("Main Menu Assets/LoadGame");
            optionsButton = Content.Load<Texture2D>("Main Menu Assets/Options");
            exitButton = Content.Load<Texture2D>("Main Menu Assets/Exit");
            teamName = Content.Load<Texture2D>("Main Menu Assets/ColdHot Studios");
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Delete))
                Exit();

            // TODO: Add your update logic here

            // run the update method for the current game state
            switch (currentState)
            {
                case GameState.MainMenu:
                    UpdateMainMenu(gameTime);
                    break;
                case GameState.Options:
                    UpdateOptions(gameTime);
                    break;
                case GameState.Gameplay:
                    UpdateGameplay(gameTime);
                    break;
                case GameState.PauseMenu:
                    UpdatePauseMenu(gameTime);
                    break;
                case GameState.MapView:
                    UpdateMapView(gameTime);
                    break;
                case GameState.GameOver:
                    UpdateGameOver(gameTime);
                    break;
                default:
                    break;
            }

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
            spriteBatch.Begin();

            // run the draw method for the current game state
            switch (currentState)
            {
                case GameState.MainMenu:
                    DrawMainMenu(gameTime);
                    break;
                case GameState.Options:
                    DrawOptions(gameTime);
                    break;
                case GameState.Gameplay:
                    DrawGameplay(gameTime);
                    break;
                case GameState.PauseMenu:
                    DrawPauseMenu(gameTime);
                    break;
                case GameState.MapView:
                    DrawMapView(gameTime);
                    break;
                case GameState.GameOver:
                    DrawGameOver(gameTime);
                    break;
                default:
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        #region MainMenu Methods
        /// <summary>
        /// Logic for updating the main menu.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void UpdateMainMenu(GameTime gameTime)
        {
            MouseState mState = Mouse.GetState();

            // check if the mouse is in the X position that the buttons are located at
            if (mState.X >= buttonX && mState.X <= buttonX + buttonWidth)
            {
                // start new game when new game button is left clicked
                if (mState.Y >= newGameButtonY && mState.Y <= newGameButtonY + buttonHeight)
                {
                    // set to true when the mouse is over the button
                    newGameButtonHover = true;

                    // if the left mouse button is clicked then switch states
                    if (mState.LeftButton == ButtonState.Pressed)
                    {
                        currentState = GameState.Gameplay;
                    }
                }
                // set to false when the mouse is not over the button
                else
                {
                    newGameButtonHover = false;
                }

                // load the saved game when load game button is left clicked
                if (mState.Y >= loadGameButtonY && mState.Y <= loadGameButtonY + buttonHeight)
                {
                    // set to true when the mouse is over the button
                    loadGameButtonHover = true;

                    // if the left mouse button is clicked then load the save and switch states
                    if (mState.LeftButton == ButtonState.Pressed)
                    {
                        saver.Load(player);
                        currentState = GameState.Gameplay;
                    }
                }
                // set to false when the mouse is not over the button
                else
                {
                    loadGameButtonHover = false;
                }

                // open the options menu when the options button is left clicked
                if (mState.Y >= optionsButtonY && mState.Y <= optionsButtonY + buttonHeight)
                {
                    // set to true when the mouse is over the button
                    optionsButtonHover = true;

                    // if the left mouse button is clicked then switch states
                    if (mState.LeftButton == ButtonState.Pressed)
                    {
                        currentState = GameState.Options;
                    }
                }
                // set to false when the mouse is not over the button
                else
                {
                    optionsButtonHover = false;
                }
            }
            // set to false when the mouse is not over the button
            else
            {
                newGameButtonHover = false;
                loadGameButtonHover = false;
                optionsButtonHover = false;
            }

            // open the options menu when the options button is left clicked
            if (mState.Y >= exitButtonY && mState.Y <= exitButtonY + exitButtonDimension && mState.X >= exitButtonX && mState.X <= exitButtonX + exitButtonDimension)
            {
                // set to true when the mouse is over the button
                exitButtonHover = true;

                // if the left mouse button is clicked then exit the game
                if (mState.LeftButton == ButtonState.Pressed)
                {
                    Environment.Exit(0);
                }
            }
            // set to false when the mouse is not over the button
            else
            {
                exitButtonHover = false;
            }
        }

        /// <summary>
        /// This is called when the main menu should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void DrawMainMenu(GameTime deltaTime)
        {
            IsMouseVisible = true;

            // calculate scale factors for appropriately resizing buttons depending on screen resolution
            widthScaleFactor = (float)mainMenuBackground.Width / screenWidth;
            heightScaleFactor = (float)mainMenuBackground.Height / screenHeight;

            // calculate the size of the buttons
            buttonWidth = (int)(newGameButton.Width / widthScaleFactor);
            buttonHeight = (int)(newGameButton.Height / heightScaleFactor);

            // calculate button locations
            buttonX = (screenWidth - buttonWidth) / 2;
            newGameButtonY = (int)(screenHeight / (12f / 7f));
            loadGameButtonY = (int)(newGameButtonY + buttonHeight + screenHeight * (1f / 72f));
            optionsButtonY = loadGameButtonY + 2 * buttonHeight;

            // calculate team name size
            teamNameWidth = (int)(screenWidth * (91f / 600f));
            teamNameHeight = (int)(screenHeight * (1f / 12f));

            // calculate team name location
            teamNameX = (int)(screenWidth * (1f / 80f));
            teamNameY = (int)(screenHeight - screenHeight * (1f / 48f) - teamNameHeight);

            // calculate exit button size
            exitButtonDimension = (int)(screenWidth * (1f / 24f));

            // calculate exit button location
            exitButtonX = (int)(screenWidth - screenWidth * (1f / 120f) - exitButtonDimension);
            exitButtonY = (int)(screenHeight * (1f / 72f));
            
            // draw the main menu
            spriteBatch.Draw(mainMenuBackground, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            spriteBatch.Draw(newGameButton, new Rectangle(buttonX, newGameButtonY, buttonWidth, buttonHeight), Color.Gray);
            spriteBatch.Draw(loadGameButton, new Rectangle(buttonX, loadGameButtonY, buttonWidth, buttonHeight), Color.Gray);
            spriteBatch.Draw(optionsButton, new Rectangle(buttonX, optionsButtonY, buttonWidth, buttonHeight), Color.Gray);
            spriteBatch.Draw(teamName, new Rectangle(teamNameX, teamNameY, teamNameWidth, teamNameHeight), Color.White);
            spriteBatch.Draw(exitButton, new Rectangle(exitButtonX, exitButtonY, exitButtonDimension, exitButtonDimension), Color.Gray);

            // if the mouse is over a button then make that button lighter
            if (newGameButtonHover)
            {
                spriteBatch.Draw(newGameButton, new Rectangle(buttonX, newGameButtonY, buttonWidth, buttonHeight), Color.White);
            }
            if (loadGameButtonHover)
            {
                spriteBatch.Draw(loadGameButton, new Rectangle(buttonX, loadGameButtonY, buttonWidth, buttonHeight), Color.White);
            }
            if (optionsButtonHover)
            {
                spriteBatch.Draw(optionsButton, new Rectangle(buttonX, optionsButtonY, buttonWidth, buttonHeight), Color.White);
            }
            if (exitButtonHover)
            {
                spriteBatch.Draw(exitButton, new Rectangle(exitButtonX, exitButtonY, exitButtonDimension, exitButtonDimension), Color.White);
            }
        }
        #endregion

        #region Options Methods
        /// <summary>
        /// Logic for updating the options menu.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void UpdateOptions(GameTime gameTime)
        {

        }

        /// <summary>
        /// This is called when the options menu should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void DrawOptions(GameTime deltaTime)
        {
            IsMouseVisible = true;
        }
        #endregion

        #region Gameplay Methods
        /// <summary>
        /// Logic for updating the gameplay.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void UpdateGameplay(GameTime gameTime)
        {
            player.Movement();

            KeyboardState kb = Keyboard.GetState();

            // save the game
            if (kb.IsKeyDown(Keys.T))
            {
                saver.Save(player);
            }

            // load the game
            if (kb.IsKeyDown(Keys.G))
            {
                saver.Load(player);
            }

            // pause the game by switching to the pause menu state
            if (kb.IsKeyDown(Keys.Escape))
            {
                currentState = GameState.PauseMenu;
                Thread.Sleep(150);
            }
        }

        /// <summary>
        /// This is called when the gameplay should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void DrawGameplay(GameTime deltaTime)
        {
            IsMouseVisible = false;
            player.Draw(spriteBatch);
        }
        #endregion

        #region PauseMenu Methods
        /// <summary>
        /// Logic for updating the pause menu.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void UpdatePauseMenu(GameTime gameTime)
        {
            KeyboardState kb = Keyboard.GetState();

            // resume the game by switching to the gameplay state
            if (kb.IsKeyDown(Keys.Escape))
            {
                currentState = GameState.Gameplay;
                Thread.Sleep(150);
            }
        }

        /// <summary>
        /// This is called when the pause menu should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void DrawPauseMenu(GameTime deltaTime)
        {
            IsMouseVisible = true;
        }
        #endregion

        #region MapView Methods
        /// <summary>
        /// Logic for updating the map view.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void UpdateMapView(GameTime gameTime)
        {

        }

        /// <summary>
        /// This is called when the map view should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void DrawMapView(GameTime deltaTime)
        {
            IsMouseVisible = true;
        }
        #endregion

        #region GameOver Methods
        /// <summary>
        /// Logic for updating the game over screen.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void UpdateGameOver(GameTime gameTime)
        {

        }

        /// <summary>
        /// This is called when the game over screen should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void DrawGameOver(GameTime deltaTime)
        {
            IsMouseVisible = true;
        }
        #endregion
    }
}
