using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;

namespace TreadRun.Core.Helpers
{
    class GPIOHelper
    {
        private static Dictionary<int, IGpioPin> gpios = new Dictionary<int, IGpioPin>();

        public static void SetAsOutput(int pin)
        {
            if(gpios.ContainsKey(pin))
            {
                gpios[pin].PinMode = GpioPinDriveMode.Output;
            }
            else
            {
                var gpio = Pi.Gpio[pin];
                gpio.PinMode = GpioPinDriveMode.Output;
                gpios.Add(pin, gpio);
            }
        }

        public static void SetAsOutput(BcmPin pin)
        {
            if (gpios.ContainsKey((int)pin))
            {
                gpios[(int)pin].PinMode = GpioPinDriveMode.Output;
            }
            else
            {
                var gpio = Pi.Gpio[pin];
                gpio.PinMode = GpioPinDriveMode.Output;
                gpios.Add((int)pin, gpio);
            }
        }

        public static void SetAsInput(int pin)
        {
            if (gpios.ContainsKey(pin))
            {
                gpios[pin].PinMode = GpioPinDriveMode.Input;
            }
            else
            {
                var gpio = Pi.Gpio[pin];
                gpio.PinMode = GpioPinDriveMode.Input;
                gpios.Add(pin, gpio);
            }
        }

        public static void SetAsInput(BcmPin pin)
        {
            if (gpios.ContainsKey((int)pin))
            {
                gpios[(int)pin].PinMode = GpioPinDriveMode.Input;
            }
            else
            {
                var gpio = Pi.Gpio[pin];
                gpio.PinMode = GpioPinDriveMode.Input;
                gpios.Add((int)pin, gpio);
            }
        }

        public static bool ReadDigital(int gpioPin)
        {
            SetAsInput(gpioPin);
            return gpios[gpioPin].Read();
        }

        public static bool ReadDigital(BcmPin gpioPin)
        {
            SetAsInput(gpioPin);
            return gpios[(int)gpioPin].Read();
        }

        public static void WriteDigital(int gpioPin, bool high = true)
        {
            SetAsOutput(gpioPin);
            gpios[gpioPin].Write(high);
        }

        public static void WriteDigital(BcmPin gpioPin, bool high = true)
        {
            SetAsOutput(gpioPin);
            gpios[(int)gpioPin].Write(high);
        }
    }
}
