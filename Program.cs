
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plenom.Components.Busylight.Sdk;
namespace ConsoleApplication2
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            var controller = new BusylightLyncController();
            //ChangeColour(controller);

            //DimmingLIght(controller);

            //SoundAlert(controller);

            //DimmingLightSmoothly(controller);

            Console.WriteLine("Press Any Key");
            Console.ReadKey();

        }

        private static void DimmingLightSmoothly(BusylightLyncController controller)
        {
            for (int i = 1; i <= 255; i++)
            {
                controller.Light(new BusylightColor()
                {
                    RedRgbValue = i,
                    GreenRgbValue = 0,
                    BlueRgbValue = 0
                });
                Thread.Sleep((50));
            }

            for (int i = 255; i > 0; i--)
            {
                controller.Light(new BusylightColor()
                {
                    RedRgbValue = i,
                    GreenRgbValue = 0,
                    BlueRgbValue = 0
                });
                Thread.Sleep((50));
            }

            controller.Light(BusylightColor.Off);
        }

        private static void SoundAlert(BusylightLyncController controller)
        {
            controller.Alert(BusylightColor.Red,
                             BusylightSoundClip.FairyTale,
                             BusylightVolume.Low);

            Thread.Sleep(10000);
            controller.Light(BusylightColor.Off);
        }

        private static void DimmingLIght(BusylightLyncController controller)
        {
            
            var sequence = new PulseSequence();
            sequence.Color = BusylightColor.Red;
            sequence.Step1 = 1;
            sequence.Step2 = 64;
            sequence.Step3 = 128;
            sequence.Step4 = 255;
            sequence.Step5 = 255;
            sequence.Step6 = 128;
            sequence.Step7 = 64; 
            sequence.Step8 = 1;

            controller.Pulse(sequence);
        }

        private static void ChangeColour(BusylightLyncController controller)
        {
           
            controller.Light(BusylightColor.Red);
            Thread.Sleep(500);

            controller.Light(BusylightColor.Blue);
            Thread.Sleep(500);
            controller.Light(BusylightColor.Yellow);
            Thread.Sleep(500);
            controller.Light(BusylightColor.Green);
            //Thread.Sleep(500);
            //controller.Light(BusylightColor.Off);
            controller.Light(new BusylightColor()
            {
                RedRgbValue = 0,
                GreenRgbValue = 2,
                BlueRgbValue = 2
            });
        }
    }
}
