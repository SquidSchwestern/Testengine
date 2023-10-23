using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testengine
{
    public class Shape
    {
        public Vector Position { get; set; }
        public Vector Scale { get; set; }
        public Color color = Color.Black;
        public string Tag;
        public Testengine.Type type;
        public Image image;
        bool isActive = false;
        public Shape(Vector position, Vector scale, Color color,bool isActive, string tag, Testengine.Type type, Image image )
        {
            Position = position;
            Scale = scale;
            this.color = color;        //Конструктор  квадрата
            Tag = tag;
            this.type = type;
            this.image = image;
            this.isActive = isActive;
            Testengine.RegisterShape(this);
        }
        public bool IsCollided(Shape shape, string tag)
        {
            List<Shape> p = Testengine.GetShapes(tag);
            foreach (Shape s in p)
            {
                if (s.Position.Y + s.Scale.Y > shape.Position.Y && shape.Position.Y + shape.Scale.Y > s.Position.Y
                    && s.Position.X + s.Scale.X > shape.Position.X && shape.Position.X + shape.Scale.X > s.Position.X)
                {         //Проверка на Коллизию
                    return true;
                }
            }
            return false;
        }
        public bool IsActive()
        {
            return isActive;
        }

        public void SetActive(bool active)
        {
            isActive = active;
        }
    }
}
