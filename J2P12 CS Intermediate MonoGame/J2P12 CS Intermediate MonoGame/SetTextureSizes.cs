using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J2P12_CS_Intermediate_MonoGame
{
    public class SetTextureSizes
    {
        public int halfSizeEnemy;
        public int halfSizePlayer;
        public int halfSizeBullet;
        public void SetSizes(Enemy enemy, Player player, Bullet bullet)
        {
            halfSizeEnemy = enemy.enemyTexture.Width / 2 * (int)player.imageScale;
            halfSizePlayer = player.playerTexture.Width / 2 * (int)player.imageScale;
            halfSizeBullet = bullet.bulletTexture.Width / 2 * (int)player.imageScale;
        }
    }
}
