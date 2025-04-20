public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public bool IsAdult()
    {
        return Age >= 18;
    }

    public int GetYearOfBirth(int currentYear)
    {
        return currentYear - Age;
    }
}
// task 2
List<int> numbers = new List<int> { 9, 12, 15, 7, 18, 20 };
int c = 0;
for (int i=0; i<numbers.Count; i++)
{
    if (numbers[i] % 3 == 0 && numbers[i] > 10)
    {
       c++;
    }
}
// task 3
public string ReverseWords(string sentence)
{
    string[] words = sentence.Split(' ');
    Array.Reverse(words);
    return string.Join(" ", words);
}
// task 4
public void FizzBuzz() {
    for (int i=1; i<=100; i++) {
        int divThree = i % 3;
        int divFive = i % 5;
        if (divFive == 0 && divThree == 0) {
            System.Console.WriteLine("FizzBuzz");
        } 
        else if (divFive == 0) {
            System.Console.WriteLine("Buzz");
        }
        else if (divThree == 0) {
            System.Console.WriteLine("Fizz");
        } else {
            System.Console.WriteLine(i);
        }
    }
}
// task 5
public int FindMissingNumber(int[] nums)
{
    var hashSet = new HashSet<int>();
    
    for (int i = 0; i < nums.Length; i++)
    {
        hashSet.Add(nums[i]);
    }

    for (int i = 1; i <= nums.Length + 1; i++)
    {
        if (!hashSet.Contains(i))
        {
            return i;
        }
    }

    return -1; // shouldn't happen with valid input
}

// Dictionary (Hash Map) Example
public void DictionaryBasics()
{
    // Create a dictionary (key-value pairs)
    Dictionary<string, int> ages = new Dictionary<string, int>();
    
    // Add items
    ages.Add("John", 25);
    ages["Mary"] = 30;  // Alternative way to add
    
    // Access a value
    int johnsAge = ages["John"];  // 25
    
    // Check if key exists
    if (ages.ContainsKey("Bob"))
    {
        Console.WriteLine("Bob's age is known");
    }
    
    // Safely get a value
    int age;
    if (ages.TryGetValue("Sarah", out age))
    {
        Console.WriteLine($"Sarah is {age}");
    }
    else
    {
        Console.WriteLine("Sarah not found");
    }
    
    // Iterate through all entries
    foreach (KeyValuePair<string, int> pair in ages)
    {
        Console.WriteLine($"{pair.Key} is {pair.Value} years old");
    }
    
    // Remove an item
    ages.Remove("John");
}

// List (Dynamic Array) Example
public void ListBasics()
{
    // Create a list
    List<string> fruits = new List<string>();
    
    // Add items
    fruits.Add("Apple");
    fruits.Add("Banana");
    fruits.Add("Orange");
    
    // Access by index
    string secondFruit = fruits[1];  // "Banana"
    
    // Insert at specific position
    fruits.Insert(1, "Mango");  // Inserts at index 1
    
    // Check if contains item
    bool hasApple = fruits.Contains("Apple");  // true
    
    // Find index of item
    int bananaIndex = fruits.IndexOf("Banana");
    
    // Remove by value
    fruits.Remove("Orange");
    
    // Remove by index
    fruits.RemoveAt(0);  // Removes first item
    
    // Get count of items
    int count = fruits.Count;
    
    // Clear all items
    fruits.Clear();
}

// Array Example
public void ArrayBasics()
{
    // Initialize with size
    int[] numbers = new int[5];
    numbers[0] = 1;
    numbers[1] = 2;
    
    // Initialize with values
    string[] colors = { "Red", "Green", "Blue" };
    
    // Access elements
    string firstColor = colors[0];  // "Red"
    
    // Get length
    int length = numbers.Length;  // 5
    
    // Iterate
    foreach (string color in colors)
    {
        Console.WriteLine(color);
    }
    
    // Multi-dimensional array
    int[,] grid = new int[3, 2] { {1, 2}, {3, 4}, {5, 6} };
    int value = grid[1, 0];  // 3
}

// HashSet Example (Unique Collection)
public void HashSetBasics()
{
    // Create a hashset
    HashSet<int> uniqueNumbers = new HashSet<int>();
    
    // Add items
    uniqueNumbers.Add(1);
    uniqueNumbers.Add(2);
    uniqueNumbers.Add(3);
    uniqueNumbers.Add(1);  // Duplicate, will be ignored
    
    // Check if contains item
    bool hasTwo = uniqueNumbers.Contains(2);  // true
    
    // Remove item
    uniqueNumbers.Remove(3);
    
    // Count items
    int count = uniqueNumbers.Count;  // 2
    
    // Clear all items
    uniqueNumbers.Clear();
}

// Stack Example (LIFO - Last In First Out)
public void StackBasics()
{
    // Create a stack
    Stack<string> books = new Stack<string>();
    
    // Push items (add to top)
    books.Push("Book 1");
    books.Push("Book 2");
    books.Push("Book 3");
    
    // Peek (view top item without removing)
    string topBook = books.Peek();  // "Book 3"
    
    // Pop (remove and return top item)
    string removed = books.Pop();  // "Book 3"
    
    // Check if contains
    bool hasBook1 = books.Contains("Book 1");  // true
    
    // Count items
    int count = books.Count;  // 1
    
    // Clear all items
    books.Clear();
}

// Queue Example (FIFO - First In First Out)
public void QueueBasics()
{
    // Create a queue
    Queue<string> customers = new Queue<string>();
    
    // Enqueue items (add to end)
    customers.Enqueue("Person 1");
    customers.Enqueue("Person 2");
    customers.Enqueue("Person 3");
    
    // Peek (view front item without removing)
    string frontPerson = customers.Peek();  // "Person 1"
    
    // Dequeue (remove and return front item)
    string served = customers.Dequeue();  // "Person 1"
    
    // Check if contains
    bool hasPerson2 = customers.Contains("Person 2");  // true
    
    // Count items
    int count = customers.Count;  // 2
    
    // Clear all items
    customers.Clear();
}

// LinkedList Example
public void LinkedListBasics()
{
    // Create a linked list
    LinkedList<int> numbers = new LinkedList<int>();
    
    // Add to beginning/end
    numbers.AddFirst(1);
    numbers.AddLast(3);
    
    // Get reference to a node
    LinkedListNode<int> firstNode = numbers.First;
    LinkedListNode<int> lastNode = numbers.Last;
    
    // Insert between nodes
    numbers.AddAfter(firstNode, 2);
    
    // Remove nodes
    numbers.Remove(2);
    numbers.RemoveFirst();
    numbers.RemoveLast();
    
    // Check if empty
    bool isEmpty = numbers.Count == 0;
}

// SortedDictionary (Ordered Hash Map)
public void SortedDictionaryBasics()
{
    // Create a sorted dictionary
    SortedDictionary<string, int> scores = new SortedDictionary<string, int>();
    
    // Add items
    scores.Add("Charlie", 70);
    scores.Add("Alice", 90);
    scores.Add("Bob", 80);
    
    // Keys will be automatically sorted (Alice, Bob, Charlie)
    foreach (var pair in scores)
    {
        Console.WriteLine($"{pair.Key}: {pair.Value}");
    }
    
    // Access, check, remove work the same as Dictionary
}
// Task 6: Student Class with Grade Average
public class Student
{
    public string Name { get; set; }
    public List<int> Grades { get; set; }

    public Student()
    {
        Grades = new List<int>();
    }

    public double GetAverageGrade()
    {
        if (Grades.Count == 0)
            return 0;

        int sum = 0;
        foreach (int grade in Grades)
        {
            sum += grade;
        }
        return (double)sum / Grades.Count;
    }

    public string GetLetterGrade()
    {
        double avg = GetAverageGrade();
        
        if (avg >= 90) return "A";
        if (avg >= 80) return "B";
        if (avg >= 70) return "C";
        if (avg >= 60) return "D";
        return "F";
    }
}

// Task 7: Count Words in a String
public int CountWords(string text)
{
    if (string.IsNullOrEmpty(text))
        return 0;
    
    string[] words = text.Split(new char[] { ' ', '\t', '\n' }, 
                               StringSplitOptions.RemoveEmptyEntries);
    return words.Length;
}

// Task 8: Find Max Value in an Array
public int FindMaxValue(int[] array)
{
    if (array == null || array.Length == 0)
        throw new ArgumentException("Array cannot be null or empty");
    
    int max = array[0];
    
    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] > max)
        {
            max = array[i];
        }
    }
    
    return max;
}

// Task 9: Check if String is Palindrome
public bool IsPalindrome(string input)
{
    if (string.IsNullOrEmpty(input))
        return true;
    
    // Remove spaces and convert to lowercase
    input = input.Replace(" ", "").ToLower();
    
    int left = 0;
    int right = input.Length - 1;
    
    while (left < right)
    {
        if (input[left] != input[right])
            return false;
        
        left++;
        right--;
    }
    
    return true;
}

// Task 10: Sum of Even Numbers
public int SumOfEvenNumbers(List<int> numbers)
{
    int sum = 0;
    
    foreach (int num in numbers)
    {
        if (num % 2 == 0)
        {
            sum += num;
        }
    }
    
    return sum;
}

// Task 11: Bank Account Class
public class BankAccount
{
    public string AccountNumber { get; private set; }
    public string OwnerName { get; set; }
    private double _balance;
    
    public BankAccount(string accountNumber, string ownerName)
    {
        AccountNumber = accountNumber;
        OwnerName = ownerName;
        _balance = 0;
    }
    
    public double GetBalance()
    {
        return _balance;
    }
    
    public bool Deposit(double amount)
    {
        if (amount <= 0)
            return false;
        
        _balance += amount;
        return true;
    }
    
    public bool Withdraw(double amount)
    {
        if (amount <= 0 || amount > _balance)
            return false;
        
        _balance -= amount;
        return true;
    }
}

// Task 12: Filter List by Condition
public List<string> GetLongWords(List<string> words, int minLength)
{
    List<string> result = new List<string>();
    
    foreach (string word in words)
    {
        if (word.Length >= minLength)
        {
            result.Add(word);
        }
    }
    
    return result;
}

// Task 13: Find Common Elements in Two Arrays
public int[] FindCommonElements(int[] array1, int[] array2)
{
    HashSet<int> set1 = new HashSet<int>(array1);
    HashSet<int> resultSet = new HashSet<int>();
    
    foreach (int num in array2)
    {
        if (set1.Contains(num))
        {
            resultSet.Add(num);
        }
    }
    
    return resultSet.ToArray();
}

// Task 14: Rectangle Class
public class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
    
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    
    public double GetArea()
    {
        return Width * Height;
    }
    
    public double GetPerimeter()
    {
        return 2 * (Width + Height);
    }
    
    public bool IsSquare()
    {
        return Width == Height;
    }
}

// Task 15: Frequency Counter
public Dictionary<string, int> CountWordFrequency(string text)
{
    Dictionary<string, int> frequency = new Dictionary<string, int>();
    
    if (string.IsNullOrEmpty(text))
        return frequency;
    
    string[] words = text.ToLower().Split(new char[] { ' ', '.', ',', '!', '?', '\n', '\t' }, 
                                         StringSplitOptions.RemoveEmptyEntries);
    
    foreach (string word in words)
    {
        if (frequency.ContainsKey(word))
        {
            frequency[word]++;
        }
        else
        {
            frequency[word] = 1;
        }
    }
    
    return frequency;
}

// Task 16: Remove Duplicates
public int[] RemoveDuplicates(int[] array)
{
    if (array == null || array.Length == 0)
        return array;
    
    HashSet<int> uniqueValues = new HashSet<int>(array);
    return uniqueValues.ToArray();
}

// Task 17: Check if Number is Prime
public bool IsPrime(int number)
{
    if (number <= 1)
        return false;
    
    if (number == 2 || number == 3)
        return true;
    
    if (number % 2 == 0)
        return false;
    
    int sqrt = (int)Math.Sqrt(number);
    
    for (int i = 3; i <= sqrt; i += 2)
    {
        if (number % i == 0)
            return false;
    }
    
    return true;
}

// Task 18: Shopping Cart Class
public class ShoppingCart
{
    private Dictionary<string, double> _items;
    
    public ShoppingCart()
    {
        _items = new Dictionary<string, double>();
    }
    
    public void AddItem(string name, double price)
    {
        if (_items.ContainsKey(name))
        {
            _items[name] = price;
        }
        else
        {
            _items.Add(name, price);
        }
    }
    
    public void RemoveItem(string name)
    {
        if (_items.ContainsKey(name))
        {
            _items.Remove(name);
        }
    }
    
    public double GetTotalPrice()
    {
        double total = 0;
        
        foreach (var price in _items.Values)
        {
            total += price;
        }
        
        return total;
    }
    
    public int GetItemCount()
    {
        return _items.Count;
    }
}

// Task 19: Capitalize First Letter of Each Word
public string CapitalizeWords(string sentence)
{
    if (string.IsNullOrEmpty(sentence))
        return sentence;
    
    string[] words = sentence.Split(' ');
    
    for (int i = 0; i < words.Length; i++)
    {
        if (!string.IsNullOrEmpty(words[i]))
        {
            char[] letters = words[i].ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            words[i] = new string(letters);
        }
    }
    
    return string.Join(" ", words);
}

// Task 20: Find Second Largest Number
public int FindSecondLargest(int[] array)
{
    if (array == null || array.Length < 2)
        throw new ArgumentException("Array must contain at least two elements");
    
    int largest = int.MinValue;
    int secondLargest = int.MinValue;
    
    foreach (int num in array)
    {
        if (num > largest)
        {
            secondLargest = largest;
            largest = num;
        }
        else if (num > secondLargest && num < largest)
        {
            secondLargest = num;
        }
    }
    
    if (secondLargest == int.MinValue)
        throw new ArgumentException("All elements are identical");
    
    return secondLargest;
}