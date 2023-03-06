using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public int enemyHealth = 10;
        public Texture2D enemyTexture;
        Vector2 enemyPosition = new(300, 0);

        public SpriteBatch sb;

        public Enemy()
        {
           
        }
<<<<<<< Updated upstream
=======

        public void Draw()
        {
            sb.Draw(enemyTexture, enemyPosition, null, Color.White, 0f, new Vector2(enemyTexture.Width / 2, enemyTexture.Height / 2), player.imageScale, SpriteEffects.None, 0f);
        }

        public void EnemyMovement()
        {

        }
>>>>>>> Stashed changes
    }
}
