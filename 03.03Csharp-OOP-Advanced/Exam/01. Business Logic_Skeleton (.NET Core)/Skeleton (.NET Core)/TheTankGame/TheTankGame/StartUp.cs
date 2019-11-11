using TheTankGame.Core;
using TheTankGame.Core.Contracts;
using TheTankGame.IO;
using TheTankGame.IO.Contracts;

namespace TheTankGame
{

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IBattleOperator battleOperator = new TankBattleOperator();
            IManager manager = new TankManager(battleOperator);

            ICommandInterpreter commandInterpreter = new CommandInterpreter(manager);

            IEngine engine = new Engine(reader,writer,commandInterpreter);

            engine.Run();
        }
    }
}
