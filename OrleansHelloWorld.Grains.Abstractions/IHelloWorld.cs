namespace OrleansHelloWorld.Grains.Abstractions;

public interface IHelloWorld : IGrainWithStringKey
{
    Task<string> SayHelloAsync(string name);
}