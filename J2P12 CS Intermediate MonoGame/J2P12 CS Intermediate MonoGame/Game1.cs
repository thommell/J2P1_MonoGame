using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace J2P12_CS_Intermediate_MonoGame
{
    public class Game1 : Game
    {
        //FEEDBACK: Let op je Access Modifiers (private, protected, public).
        // Als je em weg laat is het automatisch private, kies ervoor om OF altijd private weg te laten OF om altijd private ervoor te zetten
        // private Fields hebben inconsistent prefix (_graphics heeft een underscore, player heeft geen prefix). Wees hier consistent in!
        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;
        Player player;
        Enemy enemy;
        public List<Bullet> bullets = new List<Bullet>();


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
            enemy = new Enemy();



            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player.sb = _spriteBatch;
            player.playerTexture = Content.Load<Texture2D>("playerImageRed");

            player.SetPlayerSize();

            enemy.sb = _spriteBatch;
            //enemy.enemyTexture = Content.Load<Texture2D>("");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            player.MovementUpdate(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Bullet bullet = new Bullet(player, Content.Load<Texture2D>("bullet"));
                bullets.Add(bullet);
            }

            foreach (Bullet bullet in bullets)
            {
                bullet.BulletUpdate(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();


            //FEEDBACK: Je zou hier ook de _spriteBatch kunnen meegeven, net zoals bij de bullet.Draw(...) functie hieronder
            // Dan hoef je geen SpriteBatch Field te gebruiken in de Player class.
            player.Draw();

            foreach (Bullet bullet in bullets)
            {
                bullet.Draw(_spriteBatch);
            }




            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}