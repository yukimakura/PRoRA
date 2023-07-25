using CommandLine;

public record CLIOptions
{
    
    [Option('r', "regex", Required = false, HelpText = "環境変数名のフィルタリング用正規表現")]
    public string Regex { get; set; } = string.Empty;

}