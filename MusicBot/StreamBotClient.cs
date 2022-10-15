using Discord.WebSocket;
using Discord.Commands;
using System.Text.Json;
using Discord;

namespace MusicBot;

public class StreamBotClient
{
    private DiscordSocketClient _client;
    private CommandService _cmdService;

    

    public StreamBotClient(DiscordSocketClient client = null, CommandService cmdService = null)
    {
        _client = client ?? new DiscordSocketClient(new DiscordSocketConfig {
            AlwaysDownloadUsers = true,
            MessageCacheSize = 50, 
            LogLevel = LogSeverity.Debug
        });

        _cmdService = cmdService ?? new CommandService(new CommandServiceConfig {
            LogLevel = LogSeverity.Verbose,
            CaseSensitiveCommands = false
        });
    }

    public async Task InitializeAsync() 
    {
        Token? token;
        using (StreamReader r = new StreamReader("config.json"))
        {
            string json = r.ReadToEnd();
            token = JsonSerializer.Deserialize<Token>(json);
        }


        await _client.LoginAsync(TokenType.Bot, token?.token);
        await _client.StartAsync();

        await Task.Delay(-1);

    }

}