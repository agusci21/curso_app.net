public class HelloWorldService : IHelloWorldService
{
    public string getHelloWorld(){
        return "Hello world";
    }
}

public interface IHelloWorldService{
    string getHelloWorld();
}