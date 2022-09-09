namespace Common.OperationContext
{
    public interface IOperationContext
    {
        void SetContextValue(string key, object value);

        object GetContextValue(string key);

        void ClearContextValue(string key);

        void ClearContext();
    }
}
