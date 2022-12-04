using OrleansHelloWorld.Grains.Abstractions;

namespace OrleansHelloWorld.Grains;

public class HelloWorld : Grain, IHelloWorld
{
    public Task<string> SayHelloAsync(string name) => Task.FromResult($"Hi {name} from Orleans!");
}