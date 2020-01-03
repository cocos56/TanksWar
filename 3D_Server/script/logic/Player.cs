/// <summary>
/// 接口中的方法没有访问修饰符，默认是Public,方法没有定义(不带花括号)
/// 静态方法不能实现接口方法
/// </summary>
public interface IPlayer
{
	/// <summary>
	/// 约定每位玩家应该可以发送信息
	/// </summary>
	/// <param name="msgBase"></param>
	void Send(MsgBase msgBase);
}

public class Player: IPlayer
{
	//id
	public string id = "";
	//指向ClientState
	public ClientState state;
	//构造函数
	public Player(ClientState state){
		this.state = state;
	}
	//坐标和旋转
	public float x; 
	public float y; 
	public float z;
	public float ex; 
	public float ey; 
	public float ez;

	//在哪个房间
	public int roomId = -1;
	//阵营
	public int camp = 1;
	//坦克生命值
	public int hp = 100;

	//数据库数据
	public PlayerData data;

	//发送信息
	public void Send(MsgBase msgBase){
		NetManager.Send(state, msgBase);
	}
}