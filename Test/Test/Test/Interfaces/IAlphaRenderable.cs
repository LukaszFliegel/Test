using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Interfaces
{
    interface IAlphaRenderable
    {
        void Draw(Matrix _world, Matrix _view, Matrix _projection);
    }
}
