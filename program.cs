using System;
using System.Collections.Generic;


public interface IComponent
{
    public void Operation();
}
public class Leaf:IComponent
{
    public string Name { get; set; }

    public Leaf(string name)
    {
        Name = name;
    }
    public void Operation()
    {
        Console.WriteLine("Leaf Operation: " + Name);
    }
}


public class Composite:IComponent
{
    private List<IComponent> _children = new List<IComponent>();
    public void Add(IComponent component)
    {
        _children.Add(component);
    }
    public void Remove(IComponent component)
    {
        _children.Remove(component);
    }
    public void Operation()
    {
        foreach (var child in _children)
        {
            child.Operation();
        }
    }
}

public class Client
{
    public static void Main(string[] args)
    {
        IComponent leaf1 = new Leaf("Leaf 1");
        IComponent leaf2 = new Leaf("Leaf 2");
        Composite composite1 = new Composite();
        Composite composite2 = new Composite();
        composite1.Add(leaf1);
        composite1.Add(leaf2);
        composite1.Operation();  // This works fine
        composite2.Add(composite1);
        composite2.Operation();  
    }
}
