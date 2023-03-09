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
        public SpriteBatch _spriteBatch;
        Player player;
        Enemy enemy;
        CollisionManager coll;
        Bullet bullet;
        SetTextureSizes sts;

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
            sts = new SetTextureSizes();
            enemy = new Enemy(player, sts);
            coll = new CollisionManager(enemy, _spriteBatch);
            
            
            
            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player.sb = _spriteBatch;
            player.playerTexture = Content.Load<Texture2D>("playerImageRed");
            player.SetPlayerSize();

            enemy.sb = _spriteBatch;
            enemy.enemyTexture = Content.Load<Texture2D>("enemy_ghost");
            bullet = new Bullet(player, bullet.bulletTexture);
            sts.SetSizes(enemy, player, bullet);
            coll.AssignRectangle();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            player.MovementUpdate(gameTime);
            enemy.EnemyMovement(gameTime);
            coll.CollisionCheck(gameTime, bullet.bullets, enemy.enemyTexture, bullet);

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            shootingCooldown -= deltaTime;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && shootingCooldown <= 0f)
            {
                shootingCooldown = 0.5f;
                Bullet bullet = new Bullet(player, Content.Load<Texture2D>("bullet"));
                bullet.bullets.Add(bullet);
                Debug.WriteLine("user has pressed space!");
            }

            foreach (Bullet bullet in bullet.bullets)
            {
                bullet.BulletUpdate(gameTime);
                if (bullet.bulletPosition.X >= 850) // removes (game)object if the X-axis of ANY bullet goes above 850 OR is 850. 
                {
                    bullet.bulletsToRemove.Add(bullet);
                }
            }
            // extra foreach loop to check if any bullet is in the bulletsToRemove list.
            foreach (Bullet bullet in bullet.bulletsToRemove)
            {
                bullet.bullets.Remove(bullet);
            }

            // i've had to make 2 lists here because i wanted to iterate through the entries
            // and make changes to the list, this isn't allowed and got me an error.
            // after thinking about it I made a seperate list to remove the bullets there.
            // instead of removing it in the same list.

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            
            player.Draw();
            enemy.DrawEnemy();
            coll.DrawHitboxes(_spriteBatch, bullet, sts, player);

            foreach (Bullet bullet in bullet.bullets)
            {
                bullet.Draw(_spriteBatch);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
} 