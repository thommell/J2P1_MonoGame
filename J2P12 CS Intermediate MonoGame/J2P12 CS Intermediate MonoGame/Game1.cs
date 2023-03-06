using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

namespace J2P12_CS_Intermediate_MonoGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public int i = 0;
        private SpriteBatch _spriteBatch;
        Player player;
        Enemy enemy;
        public List<Bullet> bullets = new List<Bullet>();
        public List<Bullet> bulletsToRemove = new List<Bullet>();
        private float shootingCooldown = 0f;
        


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

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            shootingCooldown -= deltaTime;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && shootingCooldown <= 0f)
            {
                shootingCooldown = 0.5f;
                Bullet bullet = new Bullet(player, Content.Load<Texture2D>("bullet"));
                bullets.Add(bullet);
                Debug.WriteLine("user has pressed space!");
            }

            foreach (Bullet bullet in bullets)
            {
                bullet.BulletUpdate(gameTime);
                if (bullet.bulletPosition.X >= 850) // removes (game)object if the X-axis of ANY bullet goes above 850 OR is 850. 
                {
                    bulletsToRemove.Add(bullet);
                }
            }
            // extra foreach loop to check if any bullet is in the bulletsToRemove list.
            foreach (Bullet bullet in bulletsToRemove)
            {
                bullets.Remove(bullet);
            }
            base.Update(gameTime);


        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

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