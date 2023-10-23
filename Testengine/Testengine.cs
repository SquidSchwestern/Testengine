using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace Testengine
{
    public class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }

        
        
        
       
        private void InitializeComponent(TestGame testGame)
        {
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Name = "Canvas";
            this.ResumeLayout(false);

        }

        private void Canvas_Load(object sender, EventArgs e)
        {

        }

        private void Canvas_Load_1(object sender, EventArgs e)
        {

        }
    }
    public abstract class Testengine
    {
        public static Vector ScreenSize = new Vector(1920, 1080);
        public string Title = "";
        public static Canvas Window = null;
        private Thread GameLoopThread = null;
        public static List<Shape> RenderStack = new List<Shape>();
        public static bool W, A, S, D, O, E, P, R;
        public static double CameraPositionX = 0;
        public static double CameraPositionY = 0;
        public double deltaX = 5;
        public double deltaY = 5;
        
        public enum Type
        {
            Quad, Sprite
        };
        public Testengine(Vector Screensize, string title)
        {
            ScreenSize = Screensize;
            this.Title = title;
            Window = new Canvas();
            Window.Size = new System.Drawing.Size((int)ScreenSize.X, (int)ScreenSize.Y);
            Window.Text = this.Title;
            Window.Paint += Renderer;                            //Создание Окна
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.SetApartmentState(ApartmentState.STA);
            GameLoopThread.Start();
            
            System.Windows.Forms.Application.Run(Window);
        }
        public static void RegisterShape(Shape s)
        {
            if (s != null)
            {
                RenderStack.Add(s);                     //Рендер
            }
        }
        public static void ClearRoom()
        {
            RenderStack.Clear();

        }
        public static List<Shape> GetShapes(string tag)
        {
            List<Shape> found = new List<Shape>();
            foreach (Shape s in RenderStack)
            {
                if (s.Tag == tag)
                {
                    found.Add(s);                     
                }
            }
            return found;
        }
        private void GameLoop()
        {
            OnLoad();
            while (true)
            {          
                try
                {
                    W = ((Keyboard.GetKeyStates(Key.W) & KeyStates.Down) > 0) ? true : false;
                    A = ((Keyboard.GetKeyStates(Key.A) & KeyStates.Down) > 0) ? true : false;   //Проверка нажатий клавиш
                    S = ((Keyboard.GetKeyStates(Key.S) & KeyStates.Down) > 0) ? true : false;
                    D = ((Keyboard.GetKeyStates(Key.D) & KeyStates.Down) > 0) ? true : false;
                    E = ((Keyboard.GetKeyStates(Key.E) & KeyStates.Down) > 0) ? true : false;
                    P = ((Keyboard.GetKeyStates(Key.P) & KeyStates.Down) > 0) ? true : false;
                    R = ((Keyboard.GetKeyStates(Key.R) & KeyStates.Down) > 0) ? true : false;
                    //LM = ((Keyboard.GetKeyStates(Key.Q) & KeyStates.Down) > 0) ? true : false;
                    //Window.MouseDown += new System.Windows.Forms.MouseEventHandler(Form1_MouseDown);
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(16);
                    
                }
                catch (Exception) { }
                
            }    

        }
        //private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        //Console.WriteLine("Левая кнопка");
        //    }                                                            //Спам при нажатии мышки FUCKING DIES
        //    else if (e.Button == MouseButtons.Right)
        //    {
        //        Console.WriteLine("Правая кнопка");
        //    }
        //}

       
        public void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);
            List<Shape> Renderer = new List<Shape>(RenderStack);
            foreach (Shape s in Renderer)
            {
                if (s.type == Type.Quad)
                {
                    // Смещаем координаты объекта на противоположное относительно камеры значение
                    int x = (int)(s.Position.X - CameraPositionX);
                    int y = (int)(s.Position.Y - CameraPositionY);
                    g.FillRectangle(new SolidBrush(s.color), x, y, (int)s.Scale.X, (int)s.Scale.Y);
                }
                if (s.type == Type.Sprite)
                {
                    // Аналогично для спрайтов
                    int x = (int)(s.Position.X - CameraPositionX);
                    int y = (int)(s.Position.Y - CameraPositionY);
                    g.DrawImageUnscaledAndClipped(s.image, new Rectangle(x, y, (int)s.Scale.X, (int)s.Scale.Y));
                }
            }
            
            
            
        }
        public abstract void OnLoad();
        public abstract void OnUpdate();
    }
}
