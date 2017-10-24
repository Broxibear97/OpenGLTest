using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGLTest
{
    public struct Vertex
    {
        public const int Size = (4 + 4) * 4;

        private readonly Vector4 _position;
        private readonly Color4 _colour;

        public Vertex(Vector4 position, Color4 colour)
        {
            _position = position;
            _colour = colour;
        }
    }
}
