using BCU_Test.Core.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BCU_Test
{
    public class BattleCatsUltimate : Game
    {
        public static BattleCatsUltimate Instance;
        public static Texture2D Pixel { get; private set; }
        public GraphicsDeviceManager GraphicsManager { get; private init; }
        public SpriteBatch SpriteBatch { get; private set; }
        static int[] MinBufferSize = [900, 600];
        private Panel GUIPanel;
        public KeyboardState KeysState { get; private set; }
        public KeyboardState OldKeysState { get; private set; }
        public MouseState MouseState { get; private set; }
        public Vector2 MousePosition { get; private set; }
        public MouseState OldMouseState { get; private set; }

        public bool BCAccurateRounding { get; private set; }
        public bool Running60Fps { get; private set; }
        public Random Rand { get; private set; }
        public BattleCatsUltimate()
        {
            Instance = this;
            GraphicsManager = new GraphicsDeviceManager(this);
            GraphicsManager.PreferredBackBufferWidth = MinBufferSize[0];
            GraphicsManager.PreferredBackBufferHeight = MinBufferSize[1];
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += OnWindowResized;
            BCAccurateRounding = true;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Pixel = Content.Load<Texture2D>("Pixel");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeysState = Keyboard.GetState();
            MouseState = Mouse.GetState();
            MousePosition = MouseState.Position.ToVector2();
            if(MouseState.LeftButton != OldMouseState.LeftButton)
            {
                if (MouseState.LeftButton == ButtonState.Pressed)
                    GUIPanel.OnMousePress(MousePosition, false);
                else
                    GUIPanel.OnMouseRelease(MousePosition, false);
            }
            if(MouseState.RightButton != OldMouseState.RightButton)
            {
                if (MouseState.RightButton == ButtonState.Pressed)
                    GUIPanel.OnMousePress(MousePosition, true);
                else
                    GUIPanel.OnMouseRelease(MousePosition, true);
            }
            GUIPanel.OnKeyPress(KeysState.GetPressedKeys());

            OldKeysState = KeysState;
            MouseState = MouseState;
            // TODO: Add your update logic here
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            SpriteBatch.Begin();

            GUIPanel.Draw(SpriteBatch);

            SpriteBatch.End();

            base.Draw(gameTime);
        }

        private void OnWindowResized(object sender, EventArgs e)
        {
            Window.ClientSizeChanged -= OnWindowResized;
            GraphicsManager.PreferredBackBufferWidth = Math.Max(GraphicsManager.PreferredBackBufferWidth  , MinBufferSize[0]);
            GraphicsManager.PreferredBackBufferHeight = Math.Max(GraphicsManager.PreferredBackBufferHeight, MinBufferSize[1]);
            GraphicsManager.ApplyChanges();
            Window.ClientSizeChanged += OnWindowResized;
            GUIPanel.OnWindowResize();
        }
    }
}
