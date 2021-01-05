using InheritanceExample2.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceExample2.Entities
{
    public abstract class Shape
    {
        public Color Color { get; set; }

        protected Shape(Color color)
        {
            Color = color;
        }

        public abstract double Area();
       
    }
}
