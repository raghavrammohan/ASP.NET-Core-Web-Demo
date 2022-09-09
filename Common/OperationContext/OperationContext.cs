namespace Common.OperationContext
{
    public class OperationContext : IOperationContext
    {
        private Dictionary<string, object> _context = new Dictionary<string, object>();
        public void SetContextValue(string key, object value) => _context[key] = value;

        public object GetContextValue(string key) => _context[key];

        public void ClearContextValue(string key) => _context.Remove(key);

        public void ClearContext() => _context.Clear();
    }
}
