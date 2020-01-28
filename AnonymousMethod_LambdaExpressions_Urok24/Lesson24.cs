using System;

namespace AnonymousMethod_LambdaExpressions_Urok24
{
    class Lesson24
    {
        public string Name { get; }

        public DateTime Begin { get; private set; }

        public event EventHandler<DateTime> Started;

        public Lesson24(string name)
        {
            // Здесь обязательно должна быть проверка входных аргументов.
            Name = name;
        }

        public void Start()
        {
            Begin = DateTime.Now;
            Started?.Invoke(this, Begin);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
