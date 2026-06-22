namespace Terraria.Chat.Commands
{
	public interface IChatCommand
	{
		void ProcessMessage(string text, byte clientId);
	}
}
