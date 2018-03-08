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
        Texture2D cursor;

        // attributes for scaling and buttons
        double widthScaleFactor = 1;
        double heightScaleFactor = 1;
        int buttonWidth;
        int buttonHeight;
        int buttonX;

        #region Main Menu
        // main menu textures and attributes
        Texture2D mainMenuBackground;
        Texture2D newGameButton;
        Texture2D loadGameButton;
        Texture2D optionsButton;
        Texture2D exitButton;
        Texture2D teamName;
        Rectangle teamNameRectangle;
        bool newGameButtonHover = false;
        bool loadGameButtonHover = false;
        bool optionsButtonHover = false;
        bool exitButtonHover = false;
        int newGameButtonY;
        int loadGameButtonY;
        int optionsButtonY;
        int exitButtonDimension;
        int exitButtonX;
        int exitButtonY;
        #endregion

        #region Pause Menu
        // pause menu textures and attributes
        Texture2D pauseMenuBackground;
        Texture2D pauseText;
        Texture2D resumeGameButton;
        Texture2D saveGameButton;
        Texture2D exitToMenuButton;
        Texture2D helpButton;
        Rectangle pauseTextRectangle;
        bool resumeGameButtonHover = false;
        bool saveGameButtonHover = false;
        bool exitToMenuButtonHover = false;
        bool helpButtonHover = false;
        int resumeGameButtonY;
        int saveGameButtonY;
        int exitToMenuButtonY;
        int helpButtonDimension;
        int helpButtonX;
        int helpButtonY;
        #endregion

        // screen size attributes
        int screenWidth = 1200;
        int screenHeight = 720;

        // set up game states
        enum GameState { MainMenu, Options, Gameplay, PauseMenu, MapView, GameOver };
        GameState currentState;

        // call classes
        Classes.Player player;
        Classes.SaveLoad saver;
        Classes.Enemy enemy;
        Classes.Obstacles platform;
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

            #region Calculations for Menu Assets
            // scale factors for appropriately resizing buttons depending on screen resolution
            widthScaleFactor = 3440f / screenWidth;
            heightScaleFactor = 2160f / screenHeight;

            // size of the buttons
            buttonWidth = (int)(922 / widthScaleFactor);
            buttonHeight = (int)(181 / heightScaleFactor);

            // button X position
            buttonX = (screenWidth - buttonWidth) / 2;

            #region Main Menu
            // button y positions
            newGameButtonY = (int)(screenHeight * (7f / 12f));
            loadGameButtonY = (int)(newGameButtonY + buttonHeight + screenHeight * (1f / 72f));
            optionsButtonY = loadGameButtonY + 2 * buttonHeight;

            // team name size
            teamNameRectangle.Width = (int)(screenWidth * (91f / 600f));
            teamNameRectangle.Height = (int)(screenHeight * (1f / 12f));

            // team name location
            teamNameRectangle.X = (int)(screenWidth * (1f / 80f));
            teamNameRectangle.Y = (int)(screenHeight - screenHeight * (1f / 48f) - teamNameRectangle.Height);

            // exit button size
            exitButtonDimension = (int)(screenWidth * (1f / 24f));

            // exit button location
            exitButtonX = (int)(screenWidth - screenWidth * (1f / 120f) - exitButtonDimension);
            exitButtonY = (int)(screenHeight * (1f / 72f));
            #endregion

            #region Pause Menu
            // button y positions
            resumeGameButtonY = (int)(screenHeight * (35f / 72f));
            saveGameButtonY = (int)(resumeGameButtonY + buttonHeight + screenHeight * (1f / 72f));
            exitToMenuButtonY = saveGameButtonY + 2 * buttonHeight;

            // pause text size
            pauseTextRectangle.Width = (int)(screenWidth * (1f / 3f));
            pauseTextRectangle.Height = (int)(screenHeight * (13f / 60f));

            // pause text location
            pauseTextRectangle.X = (screenWidth - pauseTextRectangle.Width) / 2;
            pauseTextRectangle.Y = (int)(screenHeight * (169f / 1440f));//(4f / 48f));

            // help button size
            helpButtonDimension = (int)(screenWidth * (7f / 120f));

            // help button location
            helpButtonX = (int)(screenWidth - screenWidth * (1f / 120f) - helpButtonDimension);
            helpButtonY = (int)(screenHeight * (1f / 72f));
            #endregion
            #endregion

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
<<<<<<< HEAD
            player = new Classes.Player(this.Content.Load<Texture2D>("the_smallest_space_pirate"), true, true, true, 2, 3f, 10f, initialPosition, 50, 74);
            enemy = new Classes.Enemy(player, this.Content.Load<Texture2D>("Enemy"), 100, 10, 2f, new Vector2(600, 500), 50, 74, 250, 20);
            platform = new Classes.Obstacles(100, 10, new Vector2(100, 400), Content.Load<Texture2D>("Enemy"));
=======
            player = new Classes.Player(this.Content.Load<Texture2D>("the_smallest_space_pirate"), this.Content.Load<Texture2D>("tempLaser"), true, true, true, 2, 3f, 10f, initialPosition, 50, 74);
            enemy = new Classes.Enemy(player, this.Content.Load<Texture2D>("Enemy"), 100, 10, 2f, new Vector2(600, 500), 50, 74);
>>>>>>> 6a60018bd01758af2536c2469570eb76d6ea8006

            // load the custom cursor
            cursor = Content.Load<Texture2D>("cursor");

            // load main menu assets
            mainMenuBackground = Content.Load<Texture2D>("Main Menu Assets/Beaulax Menu");
            newGameButton = Content.Load<Texture2D>("Main Menu Assets/NewGame");
            loadGameButton = Content.Load<Texture2D>("Main Menu Assets/LoadGame");
            optionsButton = Content.Load<Texture2D>("Main Menu Assets/Options");
            exitButton = Content.Load<Texture2D>("Main Menu Assets/Exit");
            teamName = Content.Load<Texture2D>("Main Menu Assets/ColdHot Studios");

            // load pause menu assets
            pauseMenuBackground = Content.Load<Texture2D>("Pause Menu Assets/Pause BG");
            pauseText = Content.Load<Texture2D>("Pause Menu Assets/PauseText");
            resumeGameButton = Content.Load<Texture2D>("Pause Menu Assets/ResumeGame");
            saveGameButton = Content.Load<Texture2D>("Pause Menu Assets/SaveGame");
            exitToMenuButton = Content.Load<Texture2D>("Pause Menu Assets/ExitToMenu");
            helpButton = Content.Load<Texture2D>("Pause Menu Assets/Help");
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
            // draw the main menu
            spriteBatch.Draw(mainMenuBackground, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            spriteBatch.Draw(newGameButton, new Rectangle(buttonX, newGameButtonY, buttonWidth, buttonHeight), Color.Gray);
            spriteBatch.Draw(loadGameButton, new Rectangle(buttonX, loadGameButtonY, buttonWidth, buttonHeight), Color.Gray);
            spriteBatch.Draw(optionsButton, new Rectangle(buttonX, optionsButtonY, buttonWidth, buttonHeight), Color.Gray);
            spriteBatch.Draw(teamName, teamNameRectangle, Color.White);
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

            // draw the custom cursor
            DrawCursor(spriteBatch);
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
            // draw the custom cursor
            DrawCursor(spriteBatch);
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
            player.Attack(enemy);
            enemy.Movement();
            enemy.Attack();

            KeyboardState kb = Keyboard.GetState();

            // save the game
            if (kb.IsKeyDown(Keys.T))
            {
                saver.Save(player);
            }

            // load the game
            if (kb.IsKeyDown(Keys.G))
            {
                saver.LoadExtP(player);
                //saver.LoadExtE(enemy)
            }

            // pause the game by switching to the pause menu state
            if (kb.IsKeyDown(Keys.Escape))
            {
                currentState = GameState.PauseMenu;
                Thread.Sleep(100);
            }

            if (player.CharacterHealth <= 0)
            {
                currentState = GameState.GameOver;
            }

            player.Update(gameTime);
            platform.Update(gameTime, player);
        }

        /// <summary>
        /// This is called when the gameplay should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void DrawGameplay(GameTime deltaTime)
        {
            enemy.Draw(spriteBatch);
            player.Draw(spriteBatch);
            platform.Draw(spriteBatch);
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
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// This is called when the pause menu should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void DrawPauseMenu(GameTime deltaTime)
        {
            // draw the pause menu
            spriteBatch.Draw(pauseMenuBackground, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            spriteBatch.Draw(pauseText, pauseTextRectangle, Color.White);
            spriteBatch.Draw(resumeGameButton, new Rectangle(buttonX, resumeGameButtonY, buttonWidth, buttonHeight), Color.White);
            spriteBatch.Draw(saveGameButton, new Rectangle(buttonX, saveGameButtonY, buttonWidth, buttonHeight), Color.White);
            spriteBatch.Draw(exitToMenuButton, new Rectangle(buttonX, exitToMenuButtonY, buttonWidth, buttonHeight), Color.White);
            spriteBatch.Draw(helpButton, new Rectangle(helpButtonX, helpButtonY, helpButtonDimension, helpButtonDimension), Color.White);

            // draw the custom cursor
            DrawCursor(spriteBatch);
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
            // draw the custom cursor
            DrawCursor(spriteBatch);
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
            // draw the custom cursor
            DrawCursor(spriteBatch);
        }
        #endregion

        /// <summary>
        /// Draws the custom cursor at the location of the mouse.
        /// </summary>
        /// <param name="spriteBatch">Current SpriteBatch being used for drawing.</param>
        public void DrawCursor(SpriteBatch spriteBatch)
        {
            MouseState mState = Mouse.GetState();

            // calculate the size and location of the cursor
            int cursorDimensions = (int)(screenWidth * (11f / 400f));
            int cursorX = mState.X - cursorDimensions / 2;
            int cursorY = mState.Y - cursorDimensions / 2;

            // draw the cursor
            spriteBatch.Draw(cursor, new Rectangle(cursorX, cursorY, cursorDimensions, cursorDimensions), Color.LightGray);
        }
    }
}
