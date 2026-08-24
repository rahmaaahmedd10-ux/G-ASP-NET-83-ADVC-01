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
#region Question 5
// Q5: Write a generic method FindMax<T> that finds maximum value

// Explanation:
// We use the 'where T : IComparable<T>' constraint to ensure that 
// the type T supports comparison (CompareTo method).

public class MathHelper
{
    public static T FindMax<T>(T a, T b) where T : IComparable<T>
    {
        return a.CompareTo(b) > 0 ? a : b;
    }
}
#endregion
#region Question 6
// Q6: What is a generic interface? Write IRepository<T>.

// Explanation:
// A generic interface defines a contract using type parameters (like <T>), 
// allowing implementing classes to provide concrete implementations for any data type.

public interface IRepository<T>
{
    void Add(T entity);
    T GetById(int id);
    IEnumerable<T> GetAll();
    void Delete(T entity);
}
#endregion
#region Question 7
// Q7: What is the 'struct' constraint? Write an example.

// Explanation:
// The 'struct' constraint restricts the type parameter T to be a Value Type 
// (such as int, double, bool, or custom structs). It cannot be a Reference Type.

public class ValueCalculator<T> where T : struct
{
    public T Value { get; set; }

    public ValueCalculator(T value)
    {
        Value = value;
    }
}
#endregion
#region Question 8
// Q8: What is the 'class' constraint? Write an example.

// Explanation:
// The 'class' constraint restricts the type parameter T to be a Reference Type 
// (such as class, interface, delegate, or array). It cannot be a Value Type.

public class DataManager<T> where T : class
{
    private T _data;

    public void Save(T data)
    {
        _data = data;
    }
}
#endregion
#region Question 9
// Q9: What is the 'new()' constraint? Write an example.

// Explanation:
// The 'new()' constraint restricts the type parameter T to have a public parameterless constructor. 
// This allows the generic class to instantiate new objects of type T using 'new T()'.

public class Factory<T> where T : new()
{
    public T CreateInstance()
    {
        return new T();
    }
}
#endregion
#region Question 10
// Q10: What is the interface constraint? Write an example.

// Explanation:
// The interface constraint restricts the type parameter T to only accept 
// types that implement a specific interface. This guarantees that T 
// contains the methods declared in that interface.

public interface IEntity
{
    int Id { get; set; }
}

public class EntityRepository<T> where T : IEntity
{
    public void DisplayId(T entity)
    {
        Console.WriteLine(entity.Id);
    }
}
#endregion