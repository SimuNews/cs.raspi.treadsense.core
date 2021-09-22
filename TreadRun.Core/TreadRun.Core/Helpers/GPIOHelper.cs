using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;

namespace TreadSense.Helpers
{
    class GPIOHelper
    {
        private static Dictionary<int, IGpioPin> gpios = new Dictionary<int, IGpioPin>();

        /// <summary>
        /// Set a GPIO as an output
        /// </summary>
        /// <param name="pin">GPIO ID</param>
        public static void SetAsOutput(int pin)
        {
            if(gpios.ContainsKey(pin))
            {
                gpios[pin].PinMode = GpioPinDriveMode.Output;
            }
            else
            {
                IGpioPin gpio = Pi.Gpio[pin];
                gpio.PinMode = GpioPinDriveMode.Output;
                gpios.Add(pin, gpio);
            }
        }

        /// <summary>
        /// Set a GPIO as an output
        /// </summary>
        /// <param name="pin">GPIO ID</param>
        public static void SetAsOutput(BcmPin pin)
        {
            SetAsOutput(pin);
        }

        /// <summary>
        /// Set a GPIO as an input
        /// </summary>
        /// <param name="pin">GPIO ID</param>
        public static void SetAsInput(int pin)
        {
            if (gpios.ContainsKey(pin))
            {
                gpios[pin].PinMode = GpioPinDriveMode.Input;
            }
            else
            {
                IGpioPin gpio = Pi.Gpio[pin];
                gpio.PinMode = GpioPinDriveMode.Input;
                gpios.Add(pin, gpio);
            }
        }

        /// <summary>
        /// Set a GPIO as an input
        /// </summary>
        /// <param name="pin">GPIO ID</param>
        public static void SetAsInput(BcmPin pin)
        {
            SetAsInput(pin);
        }

        /// <summary>
        /// Reads the state of a GPIO
        /// </summary>
        /// <param name="gpioPin">GPIO ID</param>
        /// <returns>True, if high</returns>
        public static bool ReadDigital(int gpioPin)
        {
            SetAsInput(gpioPin);
            return gpios[gpioPin].Read();
        }

        /// <summary>
        /// Reads the state of a GPIO
        /// </summary>
        /// <param name="gpioPin">GPIO ID</param>
        /// <returns>True, if high</returns>
        public static bool ReadDigital(BcmPin gpioPin)
        {
            return ReadDigital(gpioPin);
        }

        /// <summary>
        /// Writes a digital signal 5V / 0V
        /// </summary>
        /// <param name="gpioPin">GPIO ID</param>
        /// <param name="high">True = 5V | False = 0V</param>
        public static void WriteDigital(int gpioPin, bool high = true)
        {
            SetAsOutput(gpioPin);
            gpios[gpioPin].Write(high);
        }

        /// <summary>
        /// Writes a digital signal 5V / 0V
        /// </summary>
        /// <param name="gpioPin">GPIO ID</param>
        /// <param name="high">True = 5V | False = 0V</param>
        public static void WriteDigital(BcmPin gpioPin, bool high = true)
        {
            WriteDigital(gpioPin, high);
        }
    }
}
