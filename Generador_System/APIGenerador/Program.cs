using APIGenerador.Business;

using Common;
using Common.Message.Server;
using Common.MessageHandlers;
using Common.Messages;
using Common.Messages.Client;

using SocketClient;

using SocketServer;

MessageConfig msgConf = new MessageConfig();
msgConf.Initialize();
MessageHandle.Initialize(msgConf);

BusinessLogic businessLogic = new();

businessLogic.Logic();

Console.ReadKey();
Console.WriteLine("Shutting down...");
Console.ReadKey();