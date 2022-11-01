using Village.Controllers;

namespace Village
{
    public class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            Engine engine = new Engine(controller);
            engine.Run();
        }
    }
}