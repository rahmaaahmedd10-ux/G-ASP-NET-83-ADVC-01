namespace G_ASP_NET_83_ADVC_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // هنا بنستدعي الكود بس
        }
    }

    #region Question 1
    // Q1: What is a generic class? Why use generics?

    // 1. How to use a Generic Class:
    // When creating a new object, we specify the actual type inside < > instead of the Type Parameter.
    // We write the actual data type inside < > right after the 'new' keyword.

    // 2. Why use Generics?
    // - Type Safety: Prevents runtime errors by catching type mismatches at compile-time.
    // - Performance: Avoids Boxing/Unboxing overhead when dealing with Value Types.
    // - Code Reusability: Write the logic once and use it with any data type (DRY Principle).

    #endregion

    #region Question 2
    // Q2: Write a generic class Container<T> with Add and Get methods.

    public class Container<T>
    {
        private T _item;

        public void Add(T item)
        {
            _item = item;
        }

        public T Get()
        {
            return _item;
        }
    }
    #endregion
    #region Question 3
    // Q3: What are multiple type parameters? Write Pair<TKey, TValue>.

    // Explanation:
    // Multiple type parameters allow a generic class or method to accept 
    // more than one placeholder type (e.g., <TKey, TValue>), enabling flexibility 
    // when working with data structures that hold pairs of different data types.

    public class Pair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
    #endregion

}
#region Question 4
// Q4: What is a generic method? Write Swap<T> method.


public class Helper
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
}
#endregion