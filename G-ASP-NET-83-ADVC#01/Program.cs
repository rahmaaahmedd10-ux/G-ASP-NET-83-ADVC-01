


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
#region Question 11
// Q11: What is the base class constraint? Write an example.

// Explanation:
// The base class constraint restricts the type parameter T to be 
// or derive from a specific base class. This ensures T inherits all properties 
// and methods defined in that base class.

public class Person
{
    public string Name { get; set; }
}

public class PersonPrinter<T> where T : Person
{
    public void PrintName(T person)
    {
        Console.WriteLine(person.Name);
    }
}
#endregion
#region Question 12
// Q12: How to combine multiple generic constraints? Write an example.

// Explanation:
// Multiple constraints can be combined using the 'where' keyword.
// The order must be: Base Class first, then Interfaces, then new() constructor last.

public interface IPrintable
{
    void Print();
}

public class BaseEntity
{
    public int Id { get; set; }
}

public class Processor<T> where T : BaseEntity, IPrintable, new()
{
    public void Process(T item)
    {
        Console.WriteLine($"Processing ID: {item.Id}");
        item.Print();
    }
}
#endregion
#region Question 13
// Q13: What is default(T) in Generics? Write an example.

// Explanation:
// The 'default' keyword returns the default value for a given type parameter T.
// For Reference Types (class), it returns null.
// For Value Types (struct/int/bool), it returns zero or the zero-initialized structure.

public class Utility<T>
{
    public T GetDefaultValue()
    {
        return default(T); // Returns null for class, 0 for int, false for bool, etc.
    }
}
#endregion
#region Question 14
// Q14: What is the difference between non-generic and generic collections? Write an example.

// Explanation:
// Non-generic collections (like ArrayList) store elements as 'object', which lacks type safety 
// and causes performance overhead due to Boxing/Unboxing.
// Generic collections (like List<T>) enforce type safety at compile time and offer better performance.

public class CollectionExample
{
    public void Demonstrate()
    {
        // Non-Generic Collection
        System.Collections.ArrayList nonGenericList = new System.Collections.ArrayList();
        nonGenericList.Add(10); // Boxing occurs

        // Generic Collection
        System.Collections.Generic.List<int> genericList = new System.Collections.Generic.List<int>();
        genericList.Add(10); // Type-safe, no boxing
    }
}
#endregion
#region Question 15
// Q15: What is Covariance and Contravariance in Generics? Write an example.

// Explanation:
// Covariance (out) allows returning a more derived type than defined in the generic parameter.
// Contravariance (in) allows accepting a less derived (base) type as a method argument.

// Covariance example using 'out'
public interface ICovariant<out T>
{
    T GetItem();
}

// Contravariance example using 'in'
public interface IContravariant<in T>
{
    void ProcessItem(T item);
}
#endregion

#region Question 16
// Q16: What is contravariance? Explain the 'in' keyword.

// Explanation:
// Contravariance allows a generic interface or delegate to accept a less derived (base) type 
// than originally specified. 
// The 'in' keyword marks the generic type parameter as contravariant, meaning it can ONLY be 
// used as an INPUT parameter (method argument), not as a return type.

public interface IReceiver<in T>
{
    void Process(T item); // T is used as input ONLY
}

public class Example
{
    public void Test()
    {
        // Object is a base type of string. Contravariance allows this assignment:
        IReceiver<object> objectReceiver = null!;
        IReceiver<string> stringReceiver = objectReceiver;
    }
}
#endregion
#region Question 17
// Q17: What is the difference between covariance and contravariance?

// Explanation:
// 1. Covariance (out): Allows a method to return a more derived type. Used for OUTPUT only.
// 2. Contravariance (in): Allows a method to accept a less derived (base) type. Used for INPUT only.

// Covariance Example (out -> Output)
public interface ICovariant2<out T>
{
    T GetItem();
}

// Contravariance Example (in -> Input)
public interface IContravariant2<in T>
{
    void SetItem(T item);
}
#endregion
#region Question 18
// Q18: How do static members work in generic types?

// Explanation:
// Static members in a generic class are NOT shared across different type arguments.
// Each closed generic type (e.g., GenericClass<int> and GenericClass<string>) 
// gets its own separate copy of the static field.

public class GenericCounter<T>
{
    public static int Count = 0;
}

public class StaticGenericExample
{
    public void Demonstrate()
    {
        GenericCounter<int>.Count = 5;
        GenericCounter<string>.Count = 10;

        // GenericCounter<int>.Count is still 5
        // GenericCounter<string>.Count is 10
    }
}
#endregion
