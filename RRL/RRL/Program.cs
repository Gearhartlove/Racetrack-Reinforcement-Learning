using System;

namespace RRL {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            State testState = new State(false, false);
            testState.TimeStep(1, 1);
            testState.TimeStep(1, -1);
        }
    }
}