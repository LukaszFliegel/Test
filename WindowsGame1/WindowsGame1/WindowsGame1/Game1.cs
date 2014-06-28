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

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Model model;
        private Model model2;

        private Matrix world = Matrix.CreateTranslation(new Vector3(0, 0, 0));
        private Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 10), new Vector3(0, 0, 0), Vector3.UnitY);
        private Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 100f);

        private Vector3 position;
        private Vector3 position2;

        private float angle;
        private float angle2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            position = new Vector3(0, 0, 0);
            position2 = new Vector3(0, 0, 0);

            angle = 0;
            angle2 = 0;

            model = Content.Load<Model>("Models/torus");
            model2 = Content.Load<Model>("Models/torus");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            KeyboardState state = Keyboard.GetState();

            //position += new Vector3(0, 0.01f, 0);

            if (state.IsKeyDown(Keys.Left))
            {
                position += new Vector3(-0.03f, 0, 0);
            }

            if (state.IsKeyDown(Keys.Right))
            {
                position += new Vector3(0.03f, 0, 0);
            }

            if (state.IsKeyDown(Keys.Up))
            {
                position += new Vector3(0, 0.03f, 0);
            }

            if (state.IsKeyDown(Keys.Down))
            {
                position += new Vector3(0, -0.03f, 0);
            }

            if (state.IsKeyDown(Keys.A))
            {
                position2 += new Vector3(-0.03f, 0, 0);
            }

            if (state.IsKeyDown(Keys.D))
            {
                position2 += new Vector3(0.03f, 0, 0);
            }

            if (state.IsKeyDown(Keys.W))
            {
                position2 += new Vector3(0, 0.03f, 0);
            }

            if (state.IsKeyDown(Keys.S))
            {
                position2 += new Vector3(0, -0.03f, 0);
            }

            angle += 0.03f;
            angle2 += 0.03f;

            world = Matrix.CreateRotationY(angle) * Matrix.CreateTranslation(position) * Matrix.CreateRotationY(angle2) * Matrix.CreateTranslation(position2);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            DrawModel(model, world, view, projection);

            base.Draw(gameTime);
        }

        private void DrawModel(Model model, Matrix world, Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;

                    effect.EnableDefaultLighting();
                }

                mesh.Draw();
            }

            foreach (ModelMesh mesh in model2.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;

                    effect.EnableDefaultLighting();
                }

                mesh.Draw();
            }
        }
    }
}
