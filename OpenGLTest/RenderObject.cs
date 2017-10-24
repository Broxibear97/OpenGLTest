using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
namespace OpenGLTest
{
    public class RenderObject : IDisposable
    {
        private bool _initialised;
        private readonly int _verticeCount;

        private int VBO;
        private int VAO;

        public RenderObject(Vertex[] vertices)
        {
            _verticeCount = vertices.Length;
            VAO = GL.GenVertexArray();
            VBO = GL.GenBuffer();

            GL.BindVertexArray(VAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, Vertex.Size * _verticeCount, vertices, BufferUsageHint.StaticDraw);



            _initialised = true;
        }

        public void Render()
        {
            GL.BindVertexArray(VAO);
            GL.DrawArrays(PrimitiveType.Triangles, 0, _verticeCount);
            GL.BindVertexArray(0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_initialised)
                {
                    GL.DeleteVertexArray(VAO);
                    GL.DeleteBuffer(VBO);
                    _initialised = false;
                }
            }
        }
    }
}
