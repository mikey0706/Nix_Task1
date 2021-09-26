using System;
using System.Collections;

namespace Nix_Task1
{
    abstract class Dot 
    {

        protected int X;

        protected int Y;

        //Отображение
        public abstract void Display();

        //Масштабирование
        public abstract void Scale(decimal val);

        //Перемещение
        public void Move(int x, int y){

            X = x;
            Y = y;
        }

    }

    class Circle : Dot
    {
        private decimal Radius;

        private readonly Random rnd;

        public Circle(){

            rnd = new Random();

            Radius = rnd.Next(1, 100);
        }
        public override void Display(){

           Console.WriteLine($"Тип фигуры: Круг \n Радиус круга равен:{Radius}; \n " +
               $"координаты точки X:{X}; \n координаты точки У:{Y} \n");
        }

        public override void Scale(decimal val){

            Radius *= val;
        }
    }

    class Rectangle : Dot
    {
        protected decimal dX; 

        protected decimal dY;

        private readonly Random rnd;

        public Rectangle(){

            rnd = new Random();

            int dist1 = rnd.Next(5,100);
            int dist2 = rnd.Next(5, 100);

            //Смещение относительно точки по произволным значениям

            dX = X+dist1;
            dY = Y+dist2;

        }
        public override void Display(){

            Console.WriteLine($"Тип фигуры: Прямоугольник; \n координаты точки dX:{dX}; \n " +
                $"координаты точки dY:{dY}; \n координаты точки X:{X}; \n координаты точки У:{Y} \n");
        }

        public override void Scale(decimal val){

            dX *= val;

            dY *= val;

        }
    }

    class Triangle : Rectangle 
    {
        protected decimal tX; 

        protected decimal tY;

        private readonly Random rnd;

        public Triangle(){

            rnd = new Random();

            int dist1 = rnd.Next(5, 100);
            int dist2 = rnd.Next(5, 100);

            //Смещение относительно точки по произволным значениям

            tX = X + dist1;
            tY = Y + dist2;

        }

        public override void Display(){

            Console.WriteLine($"Тип фигуры: Треугольник; \n координаты точки tХ:{tX}; \n " +
                $"координаты точки tY:{tY}; \n координаты точки dX:{dX};\n координаты точки dY:{dY}; " +
                $" \n координаты точки X:{X}; \n координаты точки У:{Y} \n");

        }

        public override void Scale(decimal val){

            tX *= val;
            tY *= val;
        }
    
    }
    class Image : Rectangle
    {
        private Dot[] arr;

        private readonly Random rnd;

        public Image(){

            rnd = new Random();
        }

        //Добавление элементов
        public void Add(Dot item){

            if (arr == null) // Если пуст создаём новый и добавляем в него элемент
            {

                arr = new Dot[] { item };

            }
            else // Если нет, то перезаписываем старый
            {

                Dot[] temp = new Dot[arr.Length + 1];

                for (int i = 0; i < arr.Length; i++)
                {

                    temp[i] = arr[i];

                }

                temp[arr.Length] = item;

                arr = temp;

            }

            Move(); //Задаём начальные координаты для точки

        }

        public void Move() {

            int x = rnd.Next(2,50);
            int y = rnd.Next(2,50);

            foreach (Dot item in arr){

                item.Move(x, y);
            }
        }

        public override void Scale(decimal val){

            foreach (Dot item in arr){

                item.Scale(val);
            }
        }

        public override void Display() {

            foreach (Dot item in arr){

                item.Display();
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Image img = new Image();

            //Добавление элементов

            img.Add(new Circle());
            img.Add(new Rectangle());
            img.Add(new Triangle());

            img.Move(); //Также метод Move всегда можно вызвать здесь
            
            Console.WriteLine("\nНачальные значения \n");

            img.Display();

            Console.WriteLine("После масштабирования: \n");

            img.Scale(3);

            img.Display();

            Console.ReadLine();
        }
    }
}
