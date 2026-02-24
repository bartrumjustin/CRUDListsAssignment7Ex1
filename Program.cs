namespace CRUDListsAssignment7Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {//Menu for lists
            int choice = Menu();
            //read return from menu pass to switch
            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        UseQueueList();
                        break;
                    case 2:
                        UseStackList();
                        break;
                    case 3:
                        UseLinkedList();
                        break;
                    case 4:
                        UseDictionary();
                        break;
                    case 5:
                        UseHashSet();
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
                choice = Menu();
            }

        }
        static int Menu()
        {
            int choice = 0;
            Console.WriteLine("Welcome, please make your selection\n" +
                "[1] Call Waiting Queue\n" +
                "[2] Violatile Product Stack\n" +
                "[3] Playlist Linked List\n" +
                "[4] Workload assignment Dictionary\n" +
                "[5] Employee Email log Hashset\n");
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("your selection should be between 1-5");
            }
            return choice;
        }
        //Call Watiting Queue
        static void UseQueueList()
        {
            Console.Clear();
            bool endSim = false;
            //color change
            Console.ForegroundColor = ConsoleColor.Red;
            Queue<string> CallWaiting = new Queue<string>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Enter Name of Caller {i + 1} of 5");
                string temp = Console.ReadLine();
                CallWaiting.Enqueue(temp);
                Console.WriteLine($"{temp} has been added to the queue, " +
                    $"Callers in Wait status {i + 1}\n");
            }
            Console.WriteLine("Max item amount reached\n");
            //print all items in queue
            while (!endSim)
            {
                foreach (var Q in CallWaiting)
                {
                    Console.WriteLine(Q + "\n");
                }
                //count items and display
                Console.WriteLine($"Callers : {CallWaiting.Count}\n" +
                    $"Select option:\n" +
                    $"[1] Complete Call/Remove from Oldest Queued\n" +
                    $"[2] Search for Caller in Queue\n" +
                    $"[any other key] to exit\n");
                if (!int.TryParse(Console.ReadLine(), out int ans))
                {
                    ans = 3;
                }
                switch (ans)
                {
                    //remove an item from the list
                    case 1:
                        Console.WriteLine($"You have completed the call with {CallWaiting.Peek()}\n" +
                            $"Removed from Queue...");
                        CallWaiting.Dequeue();
                        break;
                    case 2:
                        //check for specific calls, display but do not remove
                        Console.WriteLine(
                    $"Type name of caller you wish to find:");
                        string search = Console.ReadLine();
                        if (CallWaiting.Contains(search))
                        {
                            Console.WriteLine("Caller is in queue");
                        }
                        else
                        {
                            Console.WriteLine("Caller not found in Queue");
                        }
                        break;
                    default:
                        endSim = true;
                        break;
                }
            }
            Console.WriteLine("end of simulation [any key] to main menu...\n");
            Console.ReadKey();
            Console.Clear();

            //color back to default
            Console.ForegroundColor = ConsoleColor.White;


        }
        //Stack List
        static void UseStackList()
        {
            //color change 
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            //add 5 items
            Stack<string> product = new Stack<string>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter product:");
                string prod = Console.ReadLine();
                product.Push(prod);
            }
            //count items and display count
            Console.WriteLine($"Number of products: {product.Count}");
            //display stack items
            foreach (var S in product)
            {
                Console.WriteLine(S);

            }
            //check for item and display
            Console.WriteLine("Enter product name to check if available");
            string check = Console.ReadLine();
            if (product.Contains(check))
            {
                Console.WriteLine("Is available for purchase");
            }
            else
            {
                Console.WriteLine("Product not available");
            }
            //remove item
            Console.WriteLine("Customer wants a product, selling latest product");
            product.Pop();
            foreach (var S in product)
            {
                Console.WriteLine(S);

            }
            Console.WriteLine("End of Simulation [any key] to exit");
            Console.ReadKey();
            Console.Clear();
            //default color
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void UseLinkedList()
        {
            //color change 
            Console.ForegroundColor = ConsoleColor.Yellow;
            //add 5 items
            LinkedList<string> playList = new LinkedList<string>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter File to add to List:");
                string file = Console.ReadLine();
                playList.AddLast(file);
                Console.WriteLine($"added {file}\n");
            }
            //count and display list count
            Console.WriteLine("list count: " + playList.Count);
            //retrieve and display first node
            Console.WriteLine($"First file on play list: {playList.First.Value}");

            //retrieve and display last node
            Console.WriteLine($"Last file on play list: {playList.Last.Value}");
            //add a 6th item to the middle of list
            Console.WriteLine("Check for file and add to top and remove from previous position, if not present will be added to top");
            string check = Console.ReadLine();
            LinkedListNode<string> node = playList.Find(check);
            if (node != null)
            {
                //remove a node from list
                playList.Remove(check);
                Console.WriteLine("Currently in list, adding to top of list and removing from previous position");
                playList.AddFirst(node);

            }
            else
            {
                Console.WriteLine("file not in list, adding and placing on top");
                playList.AddFirst(check);
            }
            //print list
            foreach (var L in playList)
            {
                Console.WriteLine(L);
            }
            Console.WriteLine("End of Simulation [any key] to exit");
            Console.ReadKey();
            Console.Clear();
            //default color 
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void UseDictionary()
        {
            //change color
            Console.ForegroundColor = ConsoleColor.Blue;
            //add 5 items
            Dictionary<string, string> WorkList = new Dictionary<string, string>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter Name of Worker");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Work to be assigned: ");
                string value = Console.ReadLine();
                WorkList[name] = value;
            }
            //display count of items
            Console.WriteLine($"total: {WorkList.Count}");
            //retrieve and display all keys
            Console.WriteLine("\nKeys: ");
            foreach (var name in WorkList.Keys)
            {
                Console.WriteLine(name);
            }
            //retrieve and display all values
            Console.WriteLine("\nvalues: ");
            foreach (var V in WorkList.Values)
            {
                Console.WriteLine(V);
            }

            //remove item
            Console.WriteLine("Remove a Worker from list: ");
            string worker = Console.ReadLine();
            if (WorkList.ContainsKey(worker))
            {
                WorkList.Remove(worker);
            }
            else
            {
                Console.WriteLine("not found");
            }
            //retrieve and display both
            Console.WriteLine("\nAll: ");
            foreach (var W in WorkList)
            {
                Console.WriteLine(W.Key + " : " + W.Value);
            }
            Console.WriteLine("End of Simulation [any key] to exit");
            Console.ReadKey();
            Console.Clear();
            //default color
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void UseHashSet()
        {
            //color change
            Console.ForegroundColor = ConsoleColor.Magenta;
            //add 5 items
            Console.WriteLine("Add employee: ");
            HashSet<string> employee1 = new HashSet<string>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"employee {i + 1}: ");
                string name = Console.ReadLine();
                Console.WriteLine($"employee {i + 1} email: ");
                string email = Console.ReadLine();
                employee1.Add(name + " : " + email);
            }
            //create a similiar hash with 5 items
            Console.WriteLine("Add employee: ");
            HashSet<string> employee2 = new HashSet<string>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"employee {i + 1}: ");
                string name = Console.ReadLine();
                Console.WriteLine($"employee {i + 1} email: ");
                string email = Console.ReadLine();
                employee2.Add(name + " : " + email);
            }
            //third hash and 5 more items (1 from first and 1 from second hash
            //creating an array for the previous lists to insert 1 item for the third list
            //did not want to add Linq and already had the known size
            string[] insertArr = new string[employee1.Count];
            employee1.CopyTo(insertArr);
            string[] insert2Arr = new string[employee2.Count];
            employee2.CopyTo(insert2Arr);
            Console.WriteLine("Add employee: ");
            HashSet<string> employee3 = new HashSet<string>();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"employee {i + 1}: ");
                string name = Console.ReadLine();
                Console.WriteLine($"employee {i + 1} email: ");
                string email = Console.ReadLine();
                employee3.Add(name + " : " + email);
            }
            Console.WriteLine("Adding 1 item from list 1 and 2");
            employee3.Add(insertArr[1]);
            employee3.Add(insert2Arr[2]);
            Console.WriteLine($"Added {insertArr[1]} and {insert2Arr[2]}");
            foreach (var e1 in employee1)
            {
                Console.WriteLine(e1);
            }
            Console.WriteLine("\n");
            foreach (var e2 in employee2)
            {
                Console.WriteLine(e2);
            }
            Console.WriteLine("\n");
            foreach (var e3 in employee3)
            {
                Console.WriteLine(e3);
            }
            Console.WriteLine("\n");
            //use command to combine first and second items store in first 
            Console.WriteLine("combining List 1 and 2 with duplicates removed");
            employee1.UnionWith(employee2);
            foreach (var e1 in employee1)
            {
                Console.WriteLine(e1);
            }
            Console.WriteLine("\n");
            foreach (var e2 in employee2)
            {
                Console.WriteLine(e2);
            }
            Console.WriteLine("\n");
            //combine first and third items and store in first hash
            //print first hash
            Console.WriteLine("combining list 3 with 1");
            employee1.UnionWith(employee3);
            foreach (var e1 in employee1)
            {
                Console.WriteLine(e1);
            }
            Console.WriteLine("End of Simulation [any key] to exit");
            Console.ReadKey();
            Console.Clear();
            //default color
            Console.ForegroundColor = ConsoleColor.White;
        }




    }
}
