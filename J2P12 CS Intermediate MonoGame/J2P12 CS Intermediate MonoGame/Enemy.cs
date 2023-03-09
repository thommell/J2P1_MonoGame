﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J2P12_CS_Intermediate_MonoGame
{
    public class Enemy
    {
        Player player;
        Game1 game;

        public int enemyHealth = 10;
        public Texture2D enemyTexture;
        public Vector2 enemyPosition;
        public float enemyPosY = 200;
        public float enemySpeed = 5;
        public string enemyInfo = "up";

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
            
        }

        public void EnemyMovement(GameTime gameTime, Rectangle enemyColl)
        {
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
        public void HandleEnemyCollision(GameTime gameTime, Texture2D enemyTex, Texture2D bulletTex, Enemy enemy) 
        {
            Rectangle rect1 = new Rectangle(0, 0, enemyTex.Width, bulletTex.Height);
            Rectangle rect2 = new Rectangle(0, 0, bulletTex.Width, bulletTex.Height);

            // coll check
            if (rect1.Intersects(rect2))
            {
                enemyTexture = null;
            }
        }
    }
}
