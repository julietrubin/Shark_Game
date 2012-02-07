using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.Collections;

namespace Shark
{

    class Bullet
    {
        public float X;
        public float Y; 
        public bool mRight { get; private set; }

        public Bullet(int x, int y, bool right)
        {
            X = x;
            Y = y;
            mRight = right;
        }
    } 




    public class Weapon
    {
        ArrayList mPosition;
        float mSpeed; 
        Enemy mGame; 

        public Weapon(float speed)
        {
            mPosition = new ArrayList();
            mSpeed = speed; 
        }

        virtual public void Update(GameTime gameTime, Rectangle enemy, Rectangle player, bool front, Collision collision)
        {
            if (newBullet(gameTime))
            {
                if (front)
                    mPosition.Add(new Bullet(enemy.X + enemy.Width, enemy.Y + 13, false));

                else
                    mPosition.Add(new Bullet(enemy.X, enemy.Y + 13, true));
            }

            for (int i = 0; i < mPosition.Count; i++)
            {
                Bullet current = (Bullet)mPosition[i];
                float direction = current.mRight ? -mSpeed : mSpeed;
                current.X = current.X + direction * gameTime.ElapsedGameTime.Milliseconds;
                if (player.Contains((int)current.X, (int)current.Y) && !collision.playerHit)
                    collision.playerHit = true; 


            }
        }

        private bool newBullet(GameTime gameTime)
        {
            if ((gameTime.TotalGameTime.Milliseconds % 1000) == 0)
               return true;
            return false;

        }
        virtual public void Draw(SpriteBatch s,  Texture2D texture)
        {
            foreach (Bullet r in mPosition)
                s.Draw(texture, new Vector2(r.X, r.Y), Color.Green);

        }
    }
}
