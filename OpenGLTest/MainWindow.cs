using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace OpenGLTest
{
    public sealed class MainWindow : GameWindow
    {

        private int _program;
        private double _time;
        private string _title = "Test";
        List<RenderObject> _renderObjects = new List<RenderObject>();

        public MainWindow()
            : base(
                 1280,
                 720,
                 GraphicsMode.Default,
                 "test",
                 GameWindowFlags.Default,
                 DisplayDevice.Default,
                 4,
                 0,
                 GraphicsContextFlags.ForwardCompatible)
        {
            _title += ": OpenGL Version: " + GL.GetString(StringName.Version);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
        }

        protected override void OnLoad(EventArgs e)
        {
            CursorVisible = true;
            _program = CreateProgram();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.PatchParameter(PatchParameterInt.PatchVertices, 3);
            Closed += OnClosed;

            _renderObjects.Add(new RenderObject(VertexFactory.GenerateSquare(Color4.Blue)));


        }

        private void OnClosed(object sender, EventArgs eventArgs)
        {
            Exit();
        }

        public override void Exit()
        {
            GL.DeleteProgram(_program);
            base.Exit();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            var keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Key.Escape))
            {
                Exit();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            _time += e.Time;
            Title = $"{_title}: (Vsync: {VSync}) FPS: {1f / e.Time:0}";

            Color4 backColour;
            backColour.A = 1.0f;
            backColour.R = 0.1f;
            backColour.G = 0.1f;
            backColour.B = 0.3f;
            GL.ClearColor(backColour);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            foreach (RenderObject obj in _renderObjects)
            {
                obj.Render();
            }

            GL.UseProgram(_program);
            SwapBuffers();
        }

        private int CompileShader(ShaderType type, string path)
        {
            var shader = GL.CreateShader(type);
            var src = File.ReadAllText(path);
            GL.ShaderSource(shader, src);
            GL.CompileShader(shader);
            var info = GL.GetShaderInfoLog(shader);
            if (!string.IsNullOrWhiteSpace(info))
            {
                Console.WriteLine($"GL.CompileShader [{type}] had info log: {info}");
            }
            return shader;
        }

        private int CreateProgram()
        {
            var program = GL.CreateProgram();
            var shaders = new List<int>();
            shaders.Add(CompileShader(ShaderType.VertexShader, @"Components/Shaders/Vertex/vertexShader.c"));
            shaders.Add(CompileShader(ShaderType.FragmentShader, @"Components/Shaders/Fragment/fragmentShader.c"));

            foreach (var shader in shaders)
            {
                GL.AttachShader(program, shader);
            }

            GL.LinkProgram(program);

            var info = GL.GetProgramInfoLog(program);
            if (!string.IsNullOrWhiteSpace(info))
            {
                Console.WriteLine($"GL.LinkProgram had info log: {info}");
            }

            foreach (var shader in shaders)
            {
                GL.DetachShader(program, shader);
                GL.DeleteShader(shader);
            }

            return program;
        }
    }
}
