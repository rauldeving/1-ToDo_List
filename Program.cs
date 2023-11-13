Console.WriteLine("Hello!");




bool shallExit = false;

var todos = new List<string>();

while(shallExit != true)
{
    Console.WriteLine("What do you want to do?");

    Console.WriteLine("[S]ee all todos");

    Console.WriteLine("[A]dd a todo");

    Console.WriteLine("[R]emove a todo");

    Console.WriteLine("[E]xit");

    var userChoice = Console.ReadLine();

  

    switch (userChoice)
    {
        case "E":
        case "e":
            shallExit = true;
            break;
        case "S":
        case "s":
            SeeAllTodos();
            break;
        case "A":
        case "a":
            AddToDo();
            break;
        case "R":
        case "r":
            RemoveATodo();
            break;
        default:
            Console.WriteLine("Invalid choice!");
            break;

    }

}

void SeeAllTodos()
{
    if (todos.Count == 0)
    {
        NoTodoFound();
    }
    else
    {


        for (int i = 0; i < todos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {todos[i]}");
        }
    }
}

void AddToDo()
{
    string description;
    do
    {
        Console.WriteLine("Enter a ToDo description: ");
        description = Console.ReadLine();

        
    }while(!IsDescriptionValid(description));
    todos.Add(description);

}



void RemoveATodo()
{

    if (todos.Count == 0)
    {
        NoTodoFound();
        return;
    }
    bool isIndexValid = false;
    while (!isIndexValid)
    {
        Console.WriteLine("Selece the index of the ToDo you want to remove: ");
        SeeAllTodos();
        var userInput = Console.ReadLine();
        if(userInput == "")
        {
            Console.WriteLine("The index should not be empty!");
            continue;
        }
        if(int.TryParse(userInput, out int index) && index>=1 && index <= todos.Count)
        {
            todos.RemoveAt(index - 1);
            isIndexValid = true;
        }
        else
        {
            Console.WriteLine("The given index is not valid");
        }
    }
    

}

bool IsDescriptionValid(string description)
{
        if (description == "")
        {
            Console.WriteLine("Todo description cannot be empty!");
        }
        else if (todos.Contains(description))
        {
            Console.WriteLine("The description must be unique");
            return false;
        }
    
    return true;
}

static void NoTodoFound()
{
    Console.WriteLine("There is no ToDo added.");
}

Console.ReadKey();