using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J2P12_CS_Intermediate_MonoGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        

        Player player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            player = new Player(new Vector2(35, _graphics.PreferredBackBufferHeight / 2), GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            player.sb = _spriteBatch = new SpriteBatch(GraphicsDevice);
            player.playerTexture = Content.Load<Texture2D>("playerImageRed");
            


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            player.MovementUpdate(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            player.Draw();
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}