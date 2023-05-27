using System.Text.RegularExpressions;

private const string types = "build|feat|ci|chore|docs|fix|perf|refactor|revert|style|test|wip";
private const string scopes = "candidate search|requisitions|job adverts|settings|screening|project";

var pattern = @"^(?=.{{1,90}}$)(?:build|feat|ci|chore|docs|fix|perf|refactor|revert|style|test|wip)(?:\()(?:candidate search|requisitions|job adverts|settings|screening|project)(?:\): )\d{{5,}} .+$";
private var msg = File.ReadAllLines(Args[0])[0];

if (Regex.IsMatch(msg, string.Format(pattern,types,scopes)))
    return 0;

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Invalid commit message");
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("e.g: 'type(scope): TASK_NUMBER description'");
Console.WriteLine($"available types: {types}");
Console.WriteLine($"available scopes: {scopes}");
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine("more info: https://www.conventionalcommits.org/en/v1.0.0/");

return 1;