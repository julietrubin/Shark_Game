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
    public class Player
    { 
        virtual public void Update(GameTime gameTime, KeyboardState keyboard, PlayerManager playerManager)
        {
            Rectangle playerRec = playerManager.BoundingBox;
            Rectangle playerBoun = playerManager.playerBounds; 

            if (keyboard.IsKeyDown(Keys.Down) && playerRec.Y + playerRec.Height <= playerBoun.Y + playerBoun.Height)
                playerManager.down(gameTime.ElapsedGameTime.Milliseconds);
            if (keyboard.IsKeyDown(Keys.Up) && playerRec.Y >= 0)
                playerManager.up(gameTime.ElapsedGameTime.Milliseconds);
            if (keyboard.IsKeyDown(Keys.Right))
            {
                if (playerRec.X + playerRec.Width <= playerBoun.X + playerBoun.Width)
                   playerManager.right(gameTime.ElapsedGameTime.Milliseconds);
                playerManager.isFront = true; 
            }
            if (keyboard.IsKeyDown(Keys.Left))
            {
                if (playerRec.X >= 40)
                   playerManager.left(gameTime.ElapsedGameTime.Milliseconds);
                playerManager.isFront = false; 
            }
        }
        /*
        virtual public void Draw(SpriteBatch s, Texture2D front, Texture2D back)
        {
                s.Draw(mFront ? front : back, mPosition, Color.White);
        }
         * */
    }
}
