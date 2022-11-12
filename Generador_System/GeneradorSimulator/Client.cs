﻿using Common;
using Common.MessageHandlers;
using Common.Messages;

using System.Net;
using System.Net.Sockets;

public class Client : MessageSender, IDisposable
{
    public static Client Instance;

    readonly Socket _clientSocket;
    readonly IPEndPoint _ipEndPoint;


    public Client(string server, int port)
    {
        Instance = this;
        IPHostEntry hostEntry = Dns.GetHostEntry(server);
        foreach (IPAddress address in hostEntry.AddressList)
        {
            _ipEndPoint = new IPEndPoint(address, port);
            _clientSocket = new Socket(_ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            _clientSocket.Connect(_ipEndPoint);

            if (_clientSocket.Connected)
            {
                Console.WriteLine("Socket connected to {0}",
                    _clientSocket.RemoteEndPoint.ToString());
                return;
            }
            else
            {
                continue;
            }

            throw new Exception("ERROR");
        }
    }

    public void Send(IBaseMessage message)
    {
        base.Send(message, _clientSocket);
    }

    public void Send(byte[] buffer)
    {
        // Send the data through the socket.
        _clientSocket.Send(buffer);
    }

    public void Receive()
    {
        byte[] bytes = new byte[8192];
        _clientSocket.Receive(bytes);

        MessageHandle.HandleMessage(bytes, _clientSocket);
    }

    public void Dispose()
    {
        // Release the socket.
        _clientSocket.Shutdown(SocketShutdown.Both);
        _clientSocket.Close();
    }
}