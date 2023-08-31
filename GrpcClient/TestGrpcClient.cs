using Grpc.Net.Client;
using Grpc.Net.ClientFactory;
using TestGrpc;
using static TestGrpc.TestGrpcService;

public class TestGrpcClient
{
    protected GrpcChannel _chanel { get; set; }
    protected TestGrpcServiceClient client { get; set; }
    public TestGrpcClient()
    {
        _chanel = GrpcChannel.ForAddress("https://localhost:6001");
        client = new TestGrpcServiceClient(_chanel);
        Task.Run(InfinityTask);
    }

    private void InfinityTask()
    {
        while (true)
        {
            try
            {
                var a=client.GetCommand(new TestRequest()
                {
                    IsActive = false,
                    Name = "dsdsd",
                    TestList = new TestObject()
                    {
                        Phone = "2321321"
                    }
                });
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Получена команда");
                Console.WriteLine(a.Command);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Произошла ошибка");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(e);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ждём 20 сек");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"{20-i}");
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}