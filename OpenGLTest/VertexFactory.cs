using OpenTK.Graphics.OpenGL4;
using OpenTK;
using OpenTK.Graphics;

namespace OpenGLTest
{
    public static class VertexFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colour">Colour for the entire triangle</param>
        /// <returns name="points">Returns a list of Vertex to render.</returns>
        public static Vertex[] GenerateTriangle3D(Color4 colour)
        {
            Vertex[] points = new Vertex[5];
            points[0] = new Vertex(new Vector4(-1, 0, -1, 1), colour);
            points[1] = new Vertex(new Vector4(-1, 0, 1, 1), colour);
            points[2] = new Vertex(new Vector4(1, 0, -1, 1), colour);
            points[3] = new Vertex(new Vector4(1, 0, 1, 1), colour);
            points[4] = new Vertex(new Vector4(0, 1, 0, 1), colour);

            return points;
        }

        public static Vertex[] GenerateSquare(Color4 colour)
        {
            Vertex[] points =
            {
                new Vertex(new Vector4(-0.5f, -0.5f, -0.5f, 1), colour), // front bottom left  0
                new Vertex(new Vector4(0.5f, -0.5f, -0.5f, 1), colour), // front bottom right 1
                new Vertex(new Vector4(0.5f,  0.5f, -0.5f, 1), colour), // front top right    2
                new Vertex(new Vector4(-0.5f,  0.5f, -0.5f, 1), colour), // front top left     3
                new Vertex(new Vector4(-0.5f, -0.5f, 0.5f, 1), colour), // back bottom left   4
                new Vertex(new Vector4(0.5f, -0.5f, 0.5f, 1), colour), // back bottom right  5
                new Vertex(new Vector4(0.5f,  0.5f, 0.5f, 1), colour),// back top right     6
                new Vertex(new Vector4(-0.5f,  0.5f, 0.5f, 1), colour)  // back top left      7
            };

            return points;
        }
    }
}
