/**
 * Munteanu Alexandru
 * Grupa: 3131A
 * Laboratorul 2
 * Itemul 1
 **/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;

namespace Project
{
    class Laborator1 : GameWindow
    {

        // Constructor-ul
        public Laborator1() : base(1000, 600)
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
         * S - Modifica viewpoint-ul
         * R - Reseteaza viewpoint-ul
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

            if (e.Key == Key.R)
                GL.Viewport(0, 0, Width, Height);

            if (e.Key == Key.S)
                GL.Viewport(0, 100, Width, Height);
        }

        // Setare mediu OpenGL și încarcarea resurselor 
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.Black); //Setarea culorii de pe fundal
        }

        // Actualizează setările de afișare OpenGL la dimensiunile ferestrei curente și proiecția ortografică 2D.
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        // Această funcție ar trebui să conțină logica de actualizare pentru jocul sau aplicația curentă, dar momentan este goală.
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            //Empty
        }

        // Aici se desenează un triunghi folosind modul imediat al OpenGL și îl afișez pe ecran și îi atribui culori fiecărui colț 
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            //Începutu modului imediat
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Green);
            GL.Vertex2(-1.0f, 1.0f);

            GL.Color3(Color.Blue);
            GL.Vertex2(0.0f, -1.0f);

            GL.Color3(Color.Green);
            GL.Vertex2(1.0f, 1.0f);

            GL.End();
            // Sfârșitul modului imediat

            this.SwapBuffers();
        }

    }
}
