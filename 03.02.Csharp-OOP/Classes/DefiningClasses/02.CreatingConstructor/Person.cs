using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

public class Person
{

    private string name;
    private int age;

    public Person()
    {
        this.name = "No name";
        this.age = 1;
    }

    public Person(int age)
        : this()
    {
        this.age = age;
    }

    public Person(string name, int age)
        : this()
    {
        this.name = name;
        this.age = age;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

}
