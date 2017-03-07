using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MsgPack;
using System.IO;
using System.Net.Sockets;


namespace Network
{
public class Score
{
	const int gameServerPort = 5296;
	const int networkTimeout = 3000;
	public static int GetCurrentHighScore()
	{
		TcpClient tcp;
		try {
			tcp = new TcpClient(Manager.GameSuperior.Instance.gameServerHost, gameServerPort);
		}
		catch(SocketException)
		{
			return UI.ScoreBoard.Instance.HighScore;
		}

		NetworkStream networkStream = tcp.GetStream();
		networkStream.ReadTimeout = networkTimeout; //ms
		networkStream.WriteTimeout = networkTimeout;

		//send
		byte[] payload = GetCurrentHighScoreCommand();

		networkStream.Write(payload, 0, payload.Length);

		//recv
		MemoryStream memStream = new MemoryStream();
		byte[] readBuffer = new byte[16];
		int readSize = 0;

		do
		{
			readSize = networkStream.Read(readBuffer, 0, readBuffer.Length);
			if (readSize == 0) break;
			memStream.Write(readBuffer, 0, readSize);

		} while (networkStream.DataAvailable);

		object[] result = UnpackScorePayload(memStream.GetBuffer());

		return (int)result[0];
	}

	public static void PostHighScore(int highScore)
	{
		TcpClient tcp;
		try {
			tcp = new TcpClient(Manager.GameSuperior.Instance.gameServerHost, gameServerPort);
		}
		catch(SocketException)
		{
			//run in local mode
			return;
		}

        NetworkStream networkStream = tcp.GetStream();
        networkStream.ReadTimeout = networkTimeout; //ms
        networkStream.WriteTimeout = networkTimeout;

		//send
		byte[] payload = GetPostHighScoreCommand(highScore);
		networkStream.Write(payload, 0, payload.Length);
	}

	private static byte[] GetCurrentHighScoreCommand()
	{
		MsgPack.BoxingPacker packer = new MsgPack.BoxingPacker();
		byte[] result = packer.Pack(new object[] { 1 });
		return result;
	}

	private static object[] UnpackScorePayload(byte[] payload)
	{
		MsgPack.BoxingPacker packer = new MsgPack.BoxingPacker();
		object[] result = (object [])packer.Unpack(payload, 0, payload.Length);
		return result;
	}

	private static byte[] GetPostHighScoreCommand(int highScore)
	{
		MsgPack.BoxingPacker packer = new MsgPack.BoxingPacker();
		byte[] result = packer.Pack(new object[] { 0, highScore });
		return result;
	}
}


}
