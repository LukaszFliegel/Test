using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Interfaces;

namespace Test.Classes
{
    public class MovableObject : Alpha3DModel, IAlphaUpdateable
    {
        private bool useArrowskeys;

        public MovableObject(string _modelName, Vector3 _position, bool _useArrowskeys = true)
            : base(_modelName, _position)
        {
            useArrowskeys = _useArrowskeys;
        }

        public MovableObject(string _modelName, float _posX, float _posY, float _posZ, bool _useArrowskeys = true)
            : this(_modelName, new Vector3(_posX, _posY, _posZ), _useArrowskeys)
        {

        }

        public override void Draw(Matrix _world, Matrix _view, Matrix _projection)
        {
            //_world *= Matrix.CreateTranslation(position);

            base.Draw(Matrix.CreateWorld(position, Vector3.Forward, Vector3.Up), _view, _projection);
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (useArrowskeys)
            {
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    position.X -= 0.2f;
                }

                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    position.X += 0.2f;
                }

                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    position.Y += 0.2f;
                }

                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    position.Y -= 0.2f;
                }
            }
            else
            {
                if (keyboardState.IsKeyDown(Keys.A))
                {
                    position.X -= 0.2f;
                }

                if (keyboardState.IsKeyDown(Keys.D))
                {
                    position.X += 0.2f;
                }

                if (keyboardState.IsKeyDown(Keys.W))
                {
                    position.Y += 0.2f;
                }

                if (keyboardState.IsKeyDown(Keys.S))
                {
                    position.Y -= 0.2f;
                }
            }
        }
    }
}
