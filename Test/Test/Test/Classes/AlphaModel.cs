using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Interfaces;

namespace Test.Classes
{
    public class AlphaModel : IAlphaRenderable
    {
        private string modelName;
        private Model model;

        public Vector3 position;

        public virtual void Draw(Matrix _world, Matrix _view, Matrix _projection) 
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = _world;
                    effect.View = _view;
                    effect.Projection = _projection;

                    effect.EnableDefaultLighting();
                }

                mesh.Draw();
            }
        }

        public AlphaModel(string _modelName, Vector3 _position)
        {
            modelName = _modelName;
            position = _position;
        }

        public AlphaModel(string _modelName, float _posX, float _posY, float _posZ)
            :this(_modelName, new Vector3(_posX, _posY, _posZ))
        {

        }

        public void LoadContent(ContentManager _content)
        {
            model = _content.Load<Model>("Models/" + modelName);
        }
    }
}
