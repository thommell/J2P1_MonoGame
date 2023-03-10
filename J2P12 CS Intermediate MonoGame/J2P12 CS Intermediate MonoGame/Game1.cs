using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Transactions;

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
        public List<Bullet> bullets = new List<Bullet>();
        public List<Bullet> bulletsToRemove = new List<Bullet>();
        private float shootingCooldown = 0f;
        private float spawnCooldown = 1f;
        public Rectangle enemyCollider;
        public Rectangle playerCollider;
        public bool timerCheck = false;
        public bool enemySpawn = false;
        
        public int playerScore = 0;
        public string playerScoreString;
        SpriteFont font;

        private Texture2D rectangleTexture;
        private Texture2D rectangleTexture2;


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
            enemy = new Enemy(player);
            coll = new CollisionManager(enemy, _spriteBatch);


            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player.sb = _spriteBatch;
            player.playerTexture = Content.Load<Texture2D>("playerImageRed");
            player.SetPlayerSize();
            bullet = new Bullet(player, Content.Load<Texture2D>("bullet"));
            enemy.sb = _spriteBatch;
            enemy.enemyTexture = Content.Load<Texture2D>("enemy_ghost");

            enemy.enemyBulletTexture = Content.Load<Texture2D>("bullet");

            font = Content.Load<SpriteFont>("font2");



            // Create a new Texture2D with a width and height of 1 pixel
            rectangleTexture = new Texture2D(GraphicsDevice, 1, 1);

            // Set the color of the texture to solid white
            rectangleTexture.SetData(new[] { Color.White });

            // Create a new Texture2D with a width and height of 1 pixel
            rectangleTexture2 = new Texture2D(GraphicsDevice, 1, 1);

            // Set the color of the texture to solid white
            rectangleTexture2.SetData(new[] { Color.White });








            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            // TODO: Add your update logic here
            player.MovementUpdate(gameTime);
            enemy.EnemyUpdate(gameTime, enemyCollider);
            coll.CollisionCheck(gameTime, bullets, enemy.enemyTexture);
            enemy.EnemyShooting(gameTime, bullet, deltaTime);


            shootingCooldown -= deltaTime;
            
            if (timerCheck)
            {
                spawnCooldown -= deltaTime;
                if (spawnCooldown <= 0f)
                {
                    timerCheck = false;
                    enemySpawn = true;
                    spawnCooldown = 1f;
                    enemy.CreateNewEnemy(enemySpawn, Content.Load<Texture2D>("enemy_ghost"));
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && shootingCooldown <= 0f)
            {
                shootingCooldown = 0.5f;
                Bullet bullet = new Bullet(player, Content.Load<Texture2D>("bullet"));
                bullets.Add(bullet);
                Debug.WriteLine("user has pressed space!");
            }

            if (enemy.enemyTexture != null)
            {
               enemyCollider = new Rectangle((int)enemy.enemyPosition.X, (int)enemy.enemyPosition.Y, enemy.enemyTexture.Width / 25, enemy.enemyTexture.Height / 25);

            }

            if (player.playerTexture != null) 
            {
                playerCollider = new Rectangle((int)35, (int)player.playerPosition.Y - 35, player.playerTexture.Width / 20, player.playerTexture.Height / 20);
            }
            
            foreach (Bullet bullet in bullets)
            {
                bullet.BulletUpdate(gameTime);
                if (bullet.bulletPosition.X >= 850) // removes (game)object if the X-axis of ANY bullet goes above 850 OR is 850. 
                {
                    bulletsToRemove.Add(bullet);
                }
                Rectangle bulletRectangle = new Rectangle((int)bullet.bulletPosition.X, (int)bullet.bulletPosition.Y, bullet.bulletTexture.Width / 25, bullet.bulletTexture.Height / 25);
                
                // enemy collision check
                if (bulletRectangle.Intersects(enemyCollider))
                {
                    timerCheck = true;
                    Debug.WriteLine("yo");
                    enemy.enemyTexture = null;
                    enemyCollider = new Rectangle(0, 0, 0, 0);
                    playerScore++;
                    
                }
            }
            // player collision check
            if (enemy.enemyBullRect.Intersects(playerCollider) && enemy.enemyBulletPosition.X < 400)
            {
                Debug.WriteLine("hrbhsubhr");
                enemy.enemyBullRect = new Rectangle(0,0,0,0);
                Exit();
            }
            enemy.EnemyBulletUpdate(gameTime, playerCollider);
            // extra foreach loop to check if any bullet is in the bulletsToRemove list.
            foreach (Bullet bullet in bulletsToRemove)
            {
                bullets.Remove(bullet);
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
            coll.DrawHitboxes(_spriteBatch, bullet);



            // Debug to draw the hitboxes
         //   _spriteBatch.Draw(rectangleTexture, new Rectangle((int)35, (int)player.playerPosition.Y - 30, player.playerTexture.Width / 20, player.playerTexture.Height / 20), Color.Red);
        //    _spriteBatch.Draw(rectangleTexture2, new Rectangle((int)bullet.bulletPosition.X, (int)bullet.bulletPosition.Y, bullet.bulletTexture.Width / 25, bullet.bulletTexture.Height / 25), Color.Red);





            foreach (Bullet bullet in bullets)
            {
                bullet.Draw(_spriteBatch);
            }
            playerScoreString = playerScore.ToString();
            Vector2 textMidPoint = font.MeasureString(playerScoreString) / 2;
            Vector2 textPos = new Vector2(Window.ClientBounds.Width / 2, Window.ClientBounds.Height * 0.05f);
            _spriteBatch.DrawString(font, playerScoreString, textPos, Color.White, 0, textMidPoint, 1.0f, SpriteEffects.None, 1f);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}