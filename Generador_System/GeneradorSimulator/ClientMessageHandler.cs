using Common;
using Common.Message.Server;
using Common.Messages;

namespace SocketClient
{
    public class ClientMessageHandler
    {

        public void HandleTargetType<T>(IBaseMessage message, ResponseToMachine toRespond) where T : ServerResponseNumMessage
        {
            throw new NotImplementedException();
        }

        public static void HandleString<T>(T message, ResponseToMachine toRespond) where T : StringMessage
        {
            Console.WriteLine(message.Message);
        }
    }
}
