using System.Reactive.Subjects;
namespace TradingParty
{
    public class BroadcastService : IDisposable
    {        
        private readonly Subject<int> subject = new();
        public readonly List<IDisposable> disposables = new();

        public void Dispose()
        {
            subject?.Dispose();
            foreach (var item in disposables)
            {
                item?.Dispose();
            }
        }

        public void Broadcast(int payload)
        {
            subject.OnNext(payload);
        }

        public void Subscribe(Action<int> action)
        {
            disposables.Add(subject.Subscribe(action));
        }
    }
}
