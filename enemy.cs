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
    public class Enemy
    {
        public bool mFront;
        Vector2 mVelocity;
        public Vector2 mPosition { get; private set; }
        int mWidth;
        int mHeight;
        Rectangle mBounds;
        bool mHit; 

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int) mPosition.X, (int) mPosition.Y, mWidth, mHeight);
            }
        }

      
        public Enemy(Vector2 velocity, Vector2 position, int width, int height, Rectangle bounds)
        {
            mFront = true; 
            mVelocity = velocity;
            mPosition = position;
            mWidth = width;
            mHeight = height;
            mBounds = bounds;
            mHit = false; 
        }


        public void isHit()
        {
            mHit = true; 
        }

        virtual public void Update(GameTime gameTime)
        {
         
            mPosition +=  mVelocity * gameTime.ElapsedGameTime.Milliseconds;

            if (mPosition.X + mWidth >= mBounds.X + mBounds.Width)
            {
                mVelocity.X = -mVelocity.X;
                mFront = false;
            }
            else if (mPosition.X <= 0)
            {
                mFront = true; 
                mVelocity.X = -mVelocity.X;
            }
            else if (mPosition.Y + mHeight >= mBounds.Y + mBounds.Height || mPosition.Y <= 0)
                mVelocity.Y = -mVelocity.Y;

        }

        virtual public void Draw(SpriteBatch s, Texture2D front, Texture2D back)
        {
            s.Draw(mFront ? front: back, mPosition, Color.White);
        }
    }
}
