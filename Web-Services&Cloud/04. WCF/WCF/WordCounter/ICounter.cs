using System.ServiceModel;

namespace WordCounter
{
    [ServiceContract]
    public interface ICounter
    {
        [OperationContract]
        int GetData(string substring, string word);
    }
}
