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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState keyboard;

        int score;
        bool gameOver = false;
        SpriteFont font;

        private Enemy enemy;
        private Player player;
        private Weapon weapon;
        private Collision collision;
        private PlayerManager playerManager; 

        private Texture2D mSharkFront;
        private Texture2D mSharkBack;
        private Texture2D mEnemyBack;
        private Texture2D mEnemyFront;
        private Texture2D mSpark;

        private Rectangle mBounds;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            score = 0; 
        }

        protected override void LoadContent()
        {
            mSharkFront = Content.Load<Texture2D>("shark");
            mSharkBack = Content.Load<Texture2D>("sharkback");
            mEnemyFront = Content.Load<Texture2D>("scuba");
            mEnemyBack = Content.Load<Texture2D>("scubaback");
            mSpark = Content.Load<Texture2D>("spark");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("SpriteFont1");
            mBounds = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            enemy = new Enemy(new Vector2(0.1f, 0.1f), new Vector2(300, 300), mEnemyFront.Width, mEnemyFront.Height, mBounds);
            player = new Player();
            weapon = new Weapon(0.3f);
            collision = new Collision(); 
            playerManager = new PlayerManager(0, 0, mSharkFront.Width, mSharkFront.Height, 0.3f, mBounds);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Escape))
                this.Exit();

            if (!gameOver)
            {
                player.Update(gameTime, keyboard, playerManager);
                enemy.Update(gameTime);
                weapon.Update(gameTime, enemy.BoundingBox, playerManager.BoundingBox, enemy.mFront, collision);
            }
             base.Update(gameTime);
               
        }
          
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if (!gameOver)
            {
                if(!collision.playerHit)
                    spriteBatch.Draw(playerManager.isFront ? mSharkFront : mSharkBack, new Vector2(playerManager.BoundingBox.X, playerManager.BoundingBox.Y), Color.White);
                   // player.Draw(spriteBatch, mSharkFront, mSharkBack);
                enemy.Draw(spriteBatch,mEnemyFront, mEnemyBack);
                weapon.Draw(spriteBatch, mSpark);
            }
            else
                spriteBatch.DrawString(font, "score " + score.ToString(),
                    new Vector2((mBounds.X + mBounds.Width) / 2 - 20, (mBounds.Y + mBounds.Height) / 2 - 20), Color.Red);
           
     
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
