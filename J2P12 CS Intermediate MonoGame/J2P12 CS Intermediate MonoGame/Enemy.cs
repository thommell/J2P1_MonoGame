using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J2P12_CS_Intermediate_MonoGame
{
    public class Enemy
    {
        Player player;

        public int enemyHealth = 10;
        public Texture2D enemyTexture;
        
        public Vector2 enemyPosition;
        public Vector2 enemyBulletPosition;
        public Texture2D enemyBullet;

        public Texture2D enemyBulletTexture;
        public Rectangle enemyBullRect;

        public float enemyPosY = 200;
        public float enemySpeed = 5;
        public float enemyBulletSpeed = 4f;

        public string enemyInfo = "up";

        private float enemyShootingCooldown;

        public SpriteBatch sb;

        public Enemy(Player player)
        {
            this.player = player;
        }

        public void DrawEnemy()
        {
            if (enemyTexture != null)
            {
                sb.Draw(enemyTexture, enemyPosition, null, Color.White, 0f, new Vector2(player.playerTexture.Width / 2, player.playerTexture.Height / 2), player.imageScale, SpriteEffects.None, 0f);
            }
            if (enemyBullet != null)
            {
                sb.Draw(enemyBullet, enemyBulletPosition, null, Color.White, 0f, new Vector2(player.playerTexture.Width / 2, player.playerTexture.Height / 2), player.imageScale, SpriteEffects.FlipHorizontally, 0f);
            }
            
        }

        public void EnemyUpdate(GameTime gameTime, Rectangle enemyColl)
        {
            Random rng = new Random();
            int randomNumber = rng.Next(100, 700);
            enemyPosition = new Vector2(700, enemyPosY);
            enemyColl.Y = (int)enemyPosY;

            switch (enemyInfo)
            {
                case "up":
                    enemyPosY += enemySpeed;
                    break;
                case "down":
                    enemyPosY -= enemySpeed;
                    break;
            }
            if (enemyPosY <= 50)
            {
                enemyInfo = "up";
            }
            else if (enemyPosY >= 450)
            {
                enemyInfo = "down";
            }

        }
        public void CreateNewEnemy(bool enemySpawn, Texture2D enemyTex)
        {
            if (enemySpawn)
            {
                enemySpawn = false;
                Debug.WriteLine("new enemy");
                enemyTexture = enemyTex;
            }
        }
        public void EnemyShooting(GameTime gameTime, Bullet bullet, float deltaTime)
        {
            enemyShootingCooldown -= deltaTime;

            if (enemyShootingCooldown <= 0)
            {
                enemyBullRect = new Rectangle((int)bullet.bulletPosition.X, (int)bullet.bulletPosition.Y, bullet.bulletTexture.Width / 25, bullet.bulletTexture.Height / 25);
                enemyBulletPosition = new Vector2(700, enemyPosY);
                enemyBullet = enemyBulletTexture;
                enemyShootingCooldown = 5f;
                Debug.WriteLine(enemyBullRect);
            }  
        }
        public void EnemyBulletUpdate(GameTime gameTime)
        {
            enemyBulletPosition.X -= enemyBulletSpeed;            
        }
    }
}
