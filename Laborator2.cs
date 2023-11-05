/**
 * Munteanu Alexandru
 * Grupa: 3131A
 * Laboratorul 2
 * Itemul 2
 **/

using System;
using System.Drawing;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace MainMenu
{
    internal class Laborator2 : GameWindow
    {
        private Vector2 rotation = Vector2.Zero; // Un vector pentru a stoca rotația piramidei
        private Vector2 previousMousePosition = Vector2.Zero; // Vector pentru pozitia anterioara a mouse-ului

        //Constructor-ul
        public Laborator2() : base(1000, 600)
        {
            KeyDown += Keyboard_KeyDown;

            // Obține dimensiunile ecranului principal
            var screen = Screen.PrimaryScreen;

            // Calculează coordonatele pentru centrul ecranului
            int centerX = (screen.Bounds.Width - this.Width) / 2;
            int centerY = (screen.Bounds.Height - this.Height) / 2;

            // Setează poziția ferestrei pe centrul ecranului
            this.Location = new Point(centerX, centerY);
        }

        /**Tastele functionale:
         * ESC - Exit
         * F11 - Fullscreen
        **/
        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            if (e.Key == Key.F11)
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;
        }

        // Setare mediu OpenGL și încarcarea resurselor 
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.Black); //Setarea culorii de pe fundal
        }

        // Actualizează setările de afișare OpenGL la dimensiunile ferestrei curente și proiecția ortografică 2D.
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            float aspectRatio = (float)Width / Height;

            // Ajustează dimensiunile proiecției ortografice
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-10.0f * aspectRatio, 10.0f * aspectRatio, -10.0f, 10.0f, -10.5, 10.5);
        }

        // Aici se desenează o piramidă folosind modul imediat al OpenGL
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            //Axa X
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(-10, 0, 0);
            GL.Vertex3(10, 0, 0);
            GL.End();

            //Axa Z
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Blue);
            GL.Vertex3(0, -10, 0);
            GL.Vertex3(0, 10, 0);
            GL.End();

            //Axa Z
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, -10);
            GL.Vertex3(0, 0, 10);
            GL.End();
            // Cubul
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.Begin(PrimitiveType.Quads);

            // Fața frontală
            GL.Color3(Color.Red);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);

            // Fața din spate
            GL.Color3(Color.Green);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);

            // Fața de sus
            GL.Color3(Color.Blue);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);

            // Fața de jos
            GL.Color3(Color.Yellow);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);

            // Fața din stânga
            GL.Color3(Color.Violet);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);

            // Fața din dreapta
            GL.Color3(Color.Orange);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);

            GL.End();



            SwapBuffers();

        }

        //Funcție ce conține logica de actualizare
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = OpenTK.Input.Keyboard.GetState();
            MouseState mouse = OpenTK.Input.Mouse.GetState();


            // Controlul rotației piramidei cu tastele W, A, S, D
            float rotationSpeed = 1.0f;
            if (keyboard[Key.W]) rotation.X += rotationSpeed * (float)e.Time;
            if (keyboard[Key.S]) rotation.X -= rotationSpeed * (float)e.Time;
            if (keyboard[Key.A]) rotation.Y += rotationSpeed * (float)e.Time;
            if (keyboard[Key.D]) rotation.Y -= rotationSpeed * (float)e.Time;

            // Calculez miscarea mouse-ului intre cadre si actualizez rotatia
            Vector2 pozitieCurentaMouse = new Vector2(mouse.X, mouse.Y);
            Vector2 deltaMouse = pozitieCurentaMouse - previousMousePosition;
            rotation.Y += deltaMouse.X * 0.01f;
            rotation.X += deltaMouse.Y * 0.01f;
            previousMousePosition = pozitieCurentaMouse;

            // Actualizarea matricii de modelare a piramidei în funcție de rotație
            Matrix4 modelview = Matrix4.CreateRotationX(rotation.X) * Matrix4.CreateRotationY(rotation.Y);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
        }
    }
}
