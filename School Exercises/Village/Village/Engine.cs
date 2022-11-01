using System;
using System.Collections.Generic;
using System.Linq;
using Village.Controllers;

namespace Village
{
    public class Engine
    {
        private Controller _controller;
        private bool _isRunning;
        public Engine(Controller controller)
        {
            _controller = controller;
            _isRunning = true;
        }
        public void Run()
        {
            while (_isRunning)
            {
                string result = "";

                List<string> input = Console.ReadLine()
                    .Split()
                    .ToList();

                List<string> arguments = input
                    .Skip(1)
                    .ToList();

                switch (input[0])
                {
                    case "Village":
                        result = _controller.ProcessVillageCommand(arguments);
                        break;
                    case "Settle":
                        result = _controller.ProcessSettleCommand(arguments);
                        break;
                    case "Rebel":
                        result = _controller.ProcessRebelCommand(arguments);
                        break;
                    case "Day":
                        result = _controller.ProcessDayCommand(arguments);
                        break;
                    case "Attack":
                        result = _controller.ProcessAttackCommand(arguments);
                        break;
                    case "Info":
                        result =  _controller.ProcessInfoCommand(arguments);
                        break;
                    case "End":
                        result =  _controller.ProcessEndCommand();
                        _isRunning = false;
                        break;
                    default:
                        result = "Invalid command";
                        break;
                }

                Console.WriteLine(result);
                Console.WriteLine("");
            }
        }
    }
}
