using Common;
using Common.Message.Server;
using Common.Messages;
using Common.Messages.Client;

namespace SocketServer
{
    public class ServerMessageHandler
    {
        

        public void SendNumRespondToClient<T>(IBaseMessage message, ResponseToMachine toRespond) where T : ClientRequestNumMessage
        {
            throw new NotImplementedException();
        }

        public void ConsumeFactorial<T>(IBaseMessage message, ResponseToMachine toRespond) where T : ClientResponseFactorialMessage
        {
            throw new NotImplementedException();
        }

        public static void HandleString<T>(T message, ResponseToMachine toRespond) where T : StringMessage
        {
            Console.WriteLine(message.Message);
        }
    }
}
