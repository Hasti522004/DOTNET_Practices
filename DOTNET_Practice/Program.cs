using DOTNET_Practice;

var singleton = SingletonDesignPattern.Instance(10);
Console.WriteLine($"SIngleton Pattern Object is {singleton.Id}");

var singleton2 = SingletonDesignPattern.Instance(20);
Console.WriteLine($"SIngleton Pattern Object is {singleton2.Id}");