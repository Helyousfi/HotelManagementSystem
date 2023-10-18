using System;

namespace TestConcepts_HotelReservationSystem
{
    public class Program
    {
        public event EventHandler? OnPressedSpace;

        public void Subscriber(object sender, EventArgs e)
        {
            Console.WriteLine("Space");
        }

        public void SpacePressed()
        {
            while (true)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Spacebar)
                {
                    OnPressedSpace?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.OnPressedSpace += program.Subscriber;

            Console.WriteLine("Press the spacebar to trigger the event.");
            program.SpacePressed();
        }
    }
}
