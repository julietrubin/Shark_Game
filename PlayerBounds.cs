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
    public class PlayerManager
    {
        private int X;
        private int Y;
        private int Width;
        private int Height;
        private float Speed;
        public Rectangle playerBounds { get; set; }
        public bool isFront { get;  set; }
        public bool isHit{ get; set;} 


        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(X, Y, Width, Height);
            }
        }

        public PlayerManager(int x, int y, int width, int height, float speed, Rectangle bounds)
        {
            X = x;
            Y = y; 
            Width = width;
            Height = height;
            Speed = speed;
            playerBounds = bounds;
            isFront = true;
            isHit = false;

        }

        public void down(float gameElapse)
        {
            Y += (int)(Speed * gameElapse); 
        }
        public void up(float gameElapse)
        {
            Y += (int)(-Speed * gameElapse);
        }
        public void left(float gameElapse)
        {
            X += (int)(-Speed * gameElapse);
        }
        public void right(float gameElapse)
        {
            X += (int)(Speed * gameElapse);
        }

    }
}
