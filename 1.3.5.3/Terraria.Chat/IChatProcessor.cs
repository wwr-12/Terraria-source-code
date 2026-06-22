namespace Terraria.Chat
{
	public interface IChatProcessor
	{
		bool ProcessReceivedMessage(ChatMessage message, int clientId);

		bool ProcessOutgoingMessage(ChatMessage message);
	}
}
