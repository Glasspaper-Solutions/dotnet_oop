### EXAMPLE: CLANG compared to JS
JS: 
```js
function printStringToConsole(input)
{
    console.log(input);
}
```
C#: 
```c#
public void PrintStringToConsole(string input)
{
    Console.Writeline(input);
}
```

### Tasks - Rewrite this javascript in a c# console app
```js
function addTwoNumbers(a,b)
{
    return a+b;
} // addTwoNumbers(1,1) => 2
function numbersToStringArray(a,b)
{
    var array = [];
    array[0] = a.toString();
    array[1] = b.toString();
    return array;
} //  numbersToStringArray(22,323) => ["22","323"]
function getFirstOrNull(arrayOfStrings)
{
    if(!arrayOfStrings){
        return null;
    }
    if(arrayOfStrings.length == 0){
        return null;
    }
    var first = arrayOfStrings[0];
    if(first === undefined){
        return null;
    }
    return first;
}// getFirstOrNull(["1","1111"]) => "1"
 // getFirstOrNull([undefined,undefined,undefined]) => null
 // getFirstOrNull(null) => null
```
### Tasks - Complete this c# code
```c#
public class Person 
{
    public Person Person(string name,int age)
    {
        this.Name = name;
        this.Age = age;
    }
    public string Name {get;set;}
    public int Age {get;set;}
}
public static class PersonTasks
{
    public static void PrintNameAndAgeToConsole(Person person)
    {
      // magic happens here
      // returns "Name is: Donald Trump, Age is: 150"
    }
    public static Person FindTheOldestPerson(IEnumberable<Person> people)
    {
        Person oldestPerson;
        foreach(var person in people)
        {
           // magic happens here
           // set oldest person if they are older than previous oldestPerson
        }    
        return oldestPerson;
    }
    public static void PrintNameAndAgeOfOldestPerson(IEnumberable<Person> people)
    {
       // magic happens here
       // hint use previous functions
    }
}
```