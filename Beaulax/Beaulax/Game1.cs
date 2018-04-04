using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;


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

        // delay counters
        int mainMenuDelayCount = 0;
        int pauseMenuDelayCount = 0;

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

        #region Map Reader Attributes
        // attributes
        int rows = 12;
        int columns = 20;
        int pxlPerBox = 60;
        string thisRow;
        string[] longRows;
        string doorID = "";
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
        List<Classes.Enemy> enemies = new List<Classes.Enemy>();
        List<Classes.Obstacles> plats = new List<Classes.Obstacles>();
        List<Classes.Door> doors = new List<Classes.Door>();
        Classes.Computer comp;
        Classes.MapRoom map;
        Classes.Collectibles clct;
        //MapReader mr = new MapReader(1);

        // create texture classes
        public Texture2D playerText;
        public Texture2D enemyText;
        public Texture2D platformText;
        public Texture2D doorText;
        public Texture2D laserText;

        // character stats
        public bool hasFlash = false;
        public bool hasJump = true;
        public bool hasTank = false;
        public int access = 0;
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
            resumeGameButtonY = (int)(screenHeight * (5f / 12f));
            saveGameButtonY = (int)(resumeGameButtonY + buttonHeight + screenHeight * (1f / 72f));
            exitToMenuButtonY = saveGameButtonY + 2 * buttonHeight;

            // pause text size
            pauseTextRectangle.Width = (int)(screenWidth * (16f / 75f));
            pauseTextRectangle.Height = (int)(screenHeight * (5f / 36f));

            // pause text location
            pauseTextRectangle.X = (screenWidth - pauseTextRectangle.Width) / 2;
            pauseTextRectangle.Y = (int)(screenHeight * (5f / 24f));

            // help button size
            helpButtonDimension = (int)(screenWidth * (7f / 120f));

            // help button location
            helpButtonX = (int)(screenWidth - screenWidth * (7f / 50f) - helpButtonDimension);
            helpButtonY = (int)(screenHeight * (7f / 36f));
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
            playerText = Content.Load<Texture2D>("playerWalkingSprite");
            laserText = Content.Load<Texture2D>("tempLaser");
            enemyText = Content.Load<Texture2D>("enemyWalkingSprite");
            platformText = Content.Load<Texture2D>("BlackSquare");

            //player = new Classes.Player(playerText, laserText, true, true, true, 2, 3f, 10f, initialPosition, 50, 74);
            //enemy = new Classes.Enemy(player, enemyText, 100, 10, 2f, new Vector2(600, 500), 50, 74, 250, 20);
            //platform = new Classes.Obstacles(100, 10, new Vector2(100, 450), platformText);

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

            // initialize game
            this.ReadMap("01");
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
            // delay the method until the count is high enough
            if (mainMenuDelayCount < 20)
            {
                mainMenuDelayCount++;
                return;
            }

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
            // set to false when the mouse is not over a button
            else
            {
                newGameButtonHover = false;
                loadGameButtonHover = false;
                optionsButtonHover = false;
            }

            // close the game when the exit button is left clicked
            if (mState.Y >= exitButtonY && mState.Y <= exitButtonY + exitButtonDimension && mState.X >= exitButtonX && mState.X <= exitButtonX + exitButtonDimension)
            {
                // set to true when the mouse is over the button
                exitButtonHover = true;

                // if the left mouse button is clicked then exit the game
                if (mState.LeftButton == ButtonState.Pressed)
                {
                    Exit();
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
            if (player != null)
            {
                player.Movement();
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                player.Attack(enemies[i]);
                enemies[i].Movement();
                enemies[i].Attack();
            }
            

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
                for (int i = 0; i < enemies.Count; i++)
                {
                    saver.LoadExtE(enemies[i]);
                }
            }

            // pause the game by switching to the pause menu state
            if (kb.IsKeyDown(Keys.Escape))
            {
                currentState = GameState.PauseMenu;
                pauseMenuDelayCount = 0;
            }

            // if the player dies then display the game over screen
            if (player != null)
            {
                if (player.CharacterHealth <= 0)
                {
                    currentState = GameState.GameOver;
                }
            }

            if (player != null)
            {
                player.Update(gameTime);
            }
            if (plats.Count != 0)
            {
                for (int i = 0; i < plats.Count; i++)
                {
                    plats[i].Update(gameTime, player);
                }
            }
            if (enemies.Count != 0)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].Update(gameTime);
                }
            }
            if (doors.Count != 0)
            {
                for (int i = 0; i < doors.Count; i++)
                {
                    doors[i].EnterDoor(player);
                }
            }
        }

        /// <summary>
        /// This is called when the gameplay should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void DrawGameplay(GameTime deltaTime)
        {
            if (enemies.Count != 0)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].Draw(spriteBatch);
                }

            }
            player.Draw(spriteBatch);
            if (plats.Count != 0)
            {
                for (int i = 0; i < plats.Count; i++)
                {
                    plats[i].Draw(spriteBatch);
                }
            }
            if (doors.Count != 0)
            {
                for (int i = 0; i < doors.Count; i++)
                {
                    doors[i].EnterDoor(player);
                }
            }
        }
        #endregion

        #region PauseMenu Methods
        /// <summary>
        /// Logic for updating the pause menu.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void UpdatePauseMenu(GameTime gameTime)
        {
            // delay the method until the count is high enough
            if (pauseMenuDelayCount < 20)
            {
                pauseMenuDelayCount++;
                return;
            }

            KeyboardState kb = Keyboard.GetState();
            MouseState mState = Mouse.GetState();

            // resume the game by switching to the gameplay state
            if (kb.IsKeyDown(Keys.Escape))
            {
                currentState = GameState.Gameplay;
                Thread.Sleep(100);
            }
            if (kb.IsKeyDown(Keys.L))
            {
                saver.Load(player);
                currentState = GameState.Gameplay;
            }

            // check if the mouse is in the X position that the buttons are located at
            if (mState.X >= buttonX && mState.X <= buttonX + buttonWidth)
            {
                // return to the gameplay state when the resume game button is left clicked
                if (mState.Y >= resumeGameButtonY && mState.Y <= resumeGameButtonY + buttonHeight)
                {
                    // set to true when the mouse is over the button
                    resumeGameButtonHover = true;

                    // if the left mouse button is clicked then switch states
                    if (mState.LeftButton == ButtonState.Pressed)
                    {
                        currentState = GameState.Gameplay;
                    }
                }
                // set to false when the mouse is not over the button
                else
                {
                    resumeGameButtonHover = false;
                }

                // save the game when the save game button is left clicked
                if (mState.Y >= saveGameButtonY && mState.Y <= saveGameButtonY + buttonHeight)
                {
                    // set to true when the mouse is over the button
                    saveGameButtonHover = true;

                    // if the left mouse button is clicked then save the game
                    if (mState.LeftButton == ButtonState.Pressed)
                    {
                        saver.Save(player);
                    }
                }
                // set to false when the mouse is not over the button
                else
                {
                    saveGameButtonHover = false;
                }

                // switch to the main menu state when the exit to menu button is left clicked
                if (mState.Y >= exitToMenuButtonY && mState.Y <= exitToMenuButtonY + buttonHeight)
                {
                    // set to true when the mouse is over the button
                    exitToMenuButtonHover = true;

                    // if the left mouse button is clicked then save and switch states
                    if (mState.LeftButton == ButtonState.Pressed)
                    {
                        saver.Save(player);
                        currentState = GameState.MainMenu;
                        mainMenuDelayCount = 0;
                    }
                }
                // set to false when the mouse is not over the button
                else
                {
                    exitToMenuButtonHover = false;
                }
            }
            // set to false when the mouse is not over a button
            else
            {
                resumeGameButtonHover = false;
                saveGameButtonHover = false;
                exitToMenuButtonHover = false;
            }

            // show the controls when the help button is clicked
            if (mState.Y >= helpButtonY && mState.Y <= helpButtonY + helpButtonDimension && mState.X >= helpButtonX && mState.X <= helpButtonX + helpButtonDimension)
            {
                // set to true when the mouse is over the button
                helpButtonHover = true;

                // if the left mouse button is clicked then show the controls
                if (mState.LeftButton == ButtonState.Pressed)
                {
                    //TODO add code for the help screen
                }
            }
            // set to false when the mouse is not over the button
            else
            {
                helpButtonHover = false;
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
            spriteBatch.Draw(resumeGameButton, new Rectangle(buttonX, resumeGameButtonY, buttonWidth, buttonHeight), Color.Gray);
            spriteBatch.Draw(saveGameButton, new Rectangle(buttonX, saveGameButtonY, buttonWidth, buttonHeight), Color.Gray);
            spriteBatch.Draw(exitToMenuButton, new Rectangle(buttonX, exitToMenuButtonY, buttonWidth, buttonHeight), Color.Gray);
            spriteBatch.Draw(helpButton, new Rectangle(helpButtonX, helpButtonY, helpButtonDimension, helpButtonDimension), Color.Gray);

            // if the mouse is over a button then make that button lighter
            if (resumeGameButtonHover)
            {
                spriteBatch.Draw(resumeGameButton, new Rectangle(buttonX, resumeGameButtonY, buttonWidth, buttonHeight), Color.White);
            }
            if (saveGameButtonHover)
            {
                spriteBatch.Draw(saveGameButton, new Rectangle(buttonX, saveGameButtonY, buttonWidth, buttonHeight), Color.White);
            }
            if (exitToMenuButtonHover)
            {
                spriteBatch.Draw(exitToMenuButton, new Rectangle(buttonX, exitToMenuButtonY, buttonWidth, buttonHeight), Color.White);
            }
            if (helpButtonHover)
            {
                spriteBatch.Draw(helpButton, new Rectangle(helpButtonX, helpButtonY, helpButtonDimension, helpButtonDimension), Color.White);
            }

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

        /// <summary>
        /// Reads the map from the file and prints it on screen
        /// </summary>
        /// <param name="roomNum"></param>
        public void ReadMap(string roomNum)
        {
            Stream inStream = File.OpenRead("Rooms.txt");

            try
            {
                StreamReader sr = new StreamReader(inStream);

                while ((thisRow = sr.ReadLine()) != null)
                {
                    if (thisRow == roomNum)
                    {
                        thisRow = sr.ReadLine();

                        longRows = thisRow.Split(',');

                        for (int i = 0; i < rows; i++)
                        {
                            thisRow = sr.ReadLine();

                            if (longRows.Contains(Convert.ToString(i)))
                            {
                                for (int x = 0; x < columns + 4; x++)
                                {
                                    /*if (x == (columns + 3))
                                    {
                                        Console.WriteLine(thisRow[x]);
                                    }
                                    else
                                    {
                                        Console.Write(thisRow[x]);
                                    }*/
                                    switch (thisRow[x])
                                    {
                                        case '!':
                                            break;

                                        case '~':
                                            Classes.Obstacles platform = new Classes.Obstacles(pxlPerBox, pxlPerBox, new Vector2((pxlPerBox * x), (pxlPerBox * i)), this.platformText);
                                            plats.Add(platform);
                                            break;

                                        case '0':
                                            doorID += thisRow[x + 1];
                                            doorID += thisRow[x + 2];

                                            doors.Add(new Classes.Door(Convert.ToInt32(doorID), 0, new Rectangle((pxlPerBox * x), (pxlPerBox * i), pxlPerBox, pxlPerBox)));

                                            x += 2;
                                            break;

                                        case '1':
                                            doorID += thisRow[x + 1];
                                            doorID += thisRow[x + 2];

                                            doors.Add(new Classes.Door(Convert.ToInt32(doorID), 1, new Rectangle((pxlPerBox * x), (pxlPerBox * i), pxlPerBox, pxlPerBox)));

                                            x += 2;
                                            break;

                                        case '2':
                                            doorID += thisRow[x + 1];
                                            doorID += thisRow[x + 2];

                                            doors.Add(new Classes.Door(Convert.ToInt32(doorID), 2, new Rectangle((pxlPerBox * x), (pxlPerBox * i), pxlPerBox, pxlPerBox)));

                                            x += 2;
                                            break;

                                        case '3':
                                            doorID += thisRow[x + 1];
                                            doorID += thisRow[x + 2];

                                            doors.Add(new Classes.Door(Convert.ToInt32(doorID), 3, new Rectangle((pxlPerBox * x), (pxlPerBox * i), pxlPerBox, pxlPerBox)));

                                            x += 2;
                                            break;

                                        case '4':
                                            doorID += thisRow[x + 1];
                                            doorID += thisRow[x + 2];

                                            doors.Add(new Classes.Door(Convert.ToInt32(doorID), 4, new Rectangle((pxlPerBox * x), (pxlPerBox * i), pxlPerBox, pxlPerBox)));

                                            x += 2;
                                            break;

                                        case '5':
                                            doorID += thisRow[x + 1];
                                            doorID += thisRow[x + 2];

                                            doors.Add(new Classes.Door(Convert.ToInt32(doorID), 5, new Rectangle((pxlPerBox * x), (pxlPerBox * i), pxlPerBox, pxlPerBox)));

                                            x += 2;
                                            break;

                                        case 'C':
                                            comp = new Classes.Computer();
                                            break;

                                        case 'P':
                                            player = new Classes.Player(playerText, laserText, this.hasFlash, this.hasJump, this.hasTank, this.access, 3f, 10f, new Vector2((pxlPerBox * x), (pxlPerBox * i)), pxlPerBox, pxlPerBox);
                                            break;

                                        case 'M':
                                            map = new Classes.MapRoom();
                                            break;

                                        case 'E':
                                            enemies.Add(new Classes.Enemy(player, this.enemyText, 100, 10, 2f, new Vector2((pxlPerBox * x), (pxlPerBox * (i + 1)) - 75), 50, 74, 250, 20));
                                            break;

                                        case 'H':
                                            clct = new Classes.Collectibles("healthpack", new Vector2((pxlPerBox * x), (pxlPerBox * i)), pxlPerBox, pxlPerBox);
                                            break;

                                        case 'J':
                                            clct = new Classes.Collectibles("jumppack", new Vector2((pxlPerBox * x), (pxlPerBox * i)), pxlPerBox, pxlPerBox);
                                            break;

                                        case 'O':
                                            clct = new Classes.Collectibles("tank", new Vector2((pxlPerBox * x), (pxlPerBox * i)), pxlPerBox, pxlPerBox);
                                            break;

                                        case 'F':
                                            clct = new Classes.Collectibles("flashlight", new Vector2((pxlPerBox * x), (pxlPerBox * i)), pxlPerBox, pxlPerBox);
                                            break;

                                        case 'B':
                                            enemies.Add(new Classes.Enemy());
                                            break;
                                    }
                                    
                                }
                            }
                            else
                            {
                                for (int x = 0; x < columns; x++)
                                {
                                    /*if (x == (columns -1))
                                    {
                                        Console.WriteLine(thisRow[i]);
                                    }
                                    else
                                    {
                                        Console.Write(thisRow[i]);
                                    }*/
                                    switch (thisRow[x])
                                    {
                                        case '!':
                                            break;

                                        case '~':
                                            Classes.Obstacles platform = new Classes.Obstacles(pxlPerBox, pxlPerBox, new Vector2((pxlPerBox * x), (pxlPerBox * i)), this.platformText);
                                            plats.Add(platform);
                                            break;

                                        case '0':
                                            doorID += thisRow[x + 1];
                                            doorID += thisRow[x + 2];

                                            doors.Add(new Classes.Door(Convert.ToInt32(doorID), 0, new Rectangle((pxlPerBox * x), (pxlPerBox * i), pxlPerBox, pxlPerBox)));

                                            x += 2;
                                            break;

                                        case '1':
                                            doorID += thisRow[x + 1];
                                            doorID += thisRow[x + 2];

                                            doors.Add(new Classes.Door(Convert.ToInt32(doorID), 1, new Rectangle((pxlPerBox * x), (pxlPerBox * i), pxlPerBox, pxlPerBox)));

                                            x += 2;
                                            break;

                                        case '2':
                                            doorID += thisRow[x + 1];
                                            doorID += thisRow[x + 2];

                                            doors.Add(new Classes.Door(Convert.ToInt32(doorID), 2, new Rectangle((pxlPerBox * x), (pxlPerBox * i), pxlPerBox, pxlPerBox)));

                                            x += 2;
                                            break;

                                        case '3':
                                            doorID += thisRow[x + 1];
                                            doorID += thisRow[x + 2];

                                            doors.Add(new Classes.Door(Convert.ToInt32(doorID), 3, new Rectangle((pxlPerBox * x), (pxlPerBox * i), pxlPerBox, pxlPerBox)));

                                            x += 2;
                                            break;

                                        case '4':
                                            doorID += thisRow[x + 1];
                                            doorID += thisRow[x + 2];

                                            doors.Add(new Classes.Door(Convert.ToInt32(doorID), 4, new Rectangle((pxlPerBox * x), (pxlPerBox * i), pxlPerBox, pxlPerBox)));

                                            x += 2;
                                            break;

                                        case '5':
                                            doorID += thisRow[x + 1];
                                            doorID += thisRow[x + 2];

                                            doors.Add(new Classes.Door(Convert.ToInt32(doorID), 5, new Rectangle((pxlPerBox * x), (pxlPerBox * i), pxlPerBox, pxlPerBox)));

                                            x += 2;
                                            break;

                                        case 'C':
                                            comp = new Classes.Computer();
                                            break;

                                        case 'P':
                                            player = new Classes.Player(this.playerText, this.laserText, this.hasFlash, this.hasJump, this.hasTank, this.access, 3f, 10f, new Vector2((pxlPerBox * x), (pxlPerBox * i)), pxlPerBox, pxlPerBox);
                                            break;

                                        case 'M':
                                            map = new Classes.MapRoom();
                                            break;

                                        case 'E':
                                            enemies.Add(new Classes.Enemy(player, this.enemyText, 100, 10, 2f, new Vector2((pxlPerBox * x), (pxlPerBox * (i + 1)) - 75), 50, 74, 250, 20));
                                            break;

                                        case 'H':
                                            clct = new Classes.Collectibles("healthpack", new Vector2((pxlPerBox * x), (pxlPerBox * i)), pxlPerBox, pxlPerBox);
                                            break;

                                        case 'J':
                                            clct = new Classes.Collectibles("jumppack", new Vector2((pxlPerBox * x), (pxlPerBox * i)), pxlPerBox, pxlPerBox);
                                            break;

                                        case 'O':
                                            clct = new Classes.Collectibles("tank", new Vector2((pxlPerBox * x), (pxlPerBox * i)), pxlPerBox, pxlPerBox);
                                            break;

                                        case 'F':
                                            clct = new Classes.Collectibles("flashlight", new Vector2((pxlPerBox * x), (pxlPerBox * i)), pxlPerBox, pxlPerBox);
                                            break;

                                        case 'B':
                                            enemies.Add(new Classes.Enemy());
                                            break;
                                    }
                                    
                                }
                            }
                        }

                        //return;
                    }
                    else
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            sr.ReadLine();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading map: " + e.Message);
            }
            finally
            {
                inStream.Close();
            }
        }
    }
}
