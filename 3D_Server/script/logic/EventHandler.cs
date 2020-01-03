using System;

public partial class EventHandler
{
	public static void OnDisconnect(ClientState c){
		Console.WriteLine("Close");
		//Player下线
		if(c.player != null){
			//离开战场
			int roomId = c.player.roomId;
			if(roomId >= 0){
				Room room = RoomManager.GetRoom(roomId);
				room.RemovePlayer(c.player.id);
			}
			//保存数据
			DbManager.UpdatePlayerData(c.player.id, c.player.data);
			//移除
			PlayerManager.RemovePlayer(c.player.id);
		}
	}

	/// <summary>
	/// 处理定时器事件
	/// 当服务端很久没有收到MsgPing时， 可以认为连接已经断开。在服务端的定时事件中(EventHandler的OnTimer方法）编写心跳机制的处理函数。CheckPing方法会遍历所有的客户端信息， 然后判断连接是否超时。
	/// </summary>
	public static void OnTimer(){
		CheckPing();
		RoomManager.Update();
	}

	//Ping检查
	public static void CheckPing(){
		//现在的时间戳
		long timeNow = NetManager.GetTimeStamp();
		//遍历，删除
		foreach(ClientState s in NetManager.clients.Values){
			if(timeNow - s.lastPingTime > NetManager.pingInterval*4){
				Console.WriteLine("Ping Close " + s.socket.RemoteEndPoint.ToString());
				NetManager.Close(s);
				return;
			}
		}
	}
}