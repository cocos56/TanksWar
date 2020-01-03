using System;

namespace Game
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//连接数据库
			///匿名委托
			if (!ConnectDB(delegate () { Show(); })){
				Console.ReadKey();
				return;
			}

			//启动程序并监听82端口
			NetManager.StartLoop(82);
		}

		public static bool ConnectDB(System.Action action)
		{
			//invoke表是同步执行指定的委托
			action.Invoke();
			return DbManager.getIns().Connect(DBConfiguration.db, DBConfiguration.ip, DBConfiguration.port, DBConfiguration.user, DBConfiguration.pw);
		}

		public static void Show()
		{
			Console.WriteLine("[数据库]正在连接数据库");
		}
	}
}