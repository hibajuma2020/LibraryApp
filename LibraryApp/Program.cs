namespace LibraryApp
{

        internal class Program
        {
            static void Main(string[] args)
            {
                //system storge

                string[] titles = new string[100];
                string[] authors = new string[100];
                string[] isbns = new string[100];
                bool[] isAvailabe = new bool[100];
                string[] borrowers = new string[100];
                string[] categories = new string[100];
                int[] count = new int[100];
            DateOnly[] returnDate = new DateOnly[100];
            double[] lateFees = new double[100];
                int lastBookIndex = -1;

                //seed data
                //book 1 Available

            titles[0] = "Math";
            authors[0] = "Amjed";
            isbns[0] = "ISBN001";
            categories[0] = "Scince";
            isAvailabe[0] = true;
            borrowers[0] = "";
            count[0] = 5;
            returnDate[0] = DateOnly.MinValue;
            lateFees[0] = 0;
                lastBookIndex++;

            //book 2 not Available

            titles[1] = "Physics";
            authors[1] = "Saif";
            isbns[1] = "ISBN002";
            categories[1] = "Scince";
            isAvailabe[1] = false;
            borrowers[0] = "Rimas";
            count[1] =6;
            returnDate[1] = DateOnly.FromDateTime(DateTime.Today).AddDays(10);
            lateFees[1] = 0;
                lastBookIndex++;

                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("Welcome to libary system");
                    Console.WriteLine("1. Add New Book");
                    Console.WriteLine("2. Borrow Book");
                    Console.WriteLine("3. Return Book");
                    Console.WriteLine("4. Search Book");
                    Console.WriteLine("5. List Available Books");
                    Console.WriteLine("6. Transfer Book");
                    Console.WriteLine("7. View Most Popular Books");
                    Console.WriteLine("8. Search Books by Category");
                    Console.WriteLine("9. Exit");
                    Console.Write("Choose an option: ");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {

                        case 1:
                            //option1: add new book
                            Console.Write("Enter book title: ");
                            titles[lastBookIndex + 1] = Console.ReadLine();

                            Console.Write("Enter author name: ");
                            authors[lastBookIndex + 1] = Console.ReadLine();

                            Console.Write("Enter ISBN: ");
                            isbns[lastBookIndex + 1] = Console.ReadLine();

                            Console.WriteLine("Enter category (Fiction, Science, History, etc.):");
                            categories[lastBookIndex + 1] = Console.ReadLine();

                            isAvailabe[lastBookIndex + 1] = true;
                            borrowers[lastBookIndex + 1] = "";
                            count[lastBookIndex + 1] = 0;
                            returnDate[lastBookIndex + 1] = DateOnly.MinValue;
                            lateFees[lastBookIndex + 1] = 0;

                            lastBookIndex++;

                            Console.WriteLine("Book added successfully!");
                            break;


                        case 2:
                            //option2:  Borrow Book

                            Console.Write("Enter ISBN: ");
                            string borrowIsbn = Console.ReadLine();

                            Console.Write("Enter borrower name: ");
                            string borrowerName = Console.ReadLine();


                            for (int i = 0; i <= lastBookIndex; i++)
                            {
                                if (isbns[i] == borrowIsbn)
                                {

                                    if (isAvailabe[i] == true)
                                    {
                                        isAvailabe[i] = false;
                                        borrowers[i] = borrowerName;
                                    count[i]++;
                                    returnDate[i] = DateOnly.FromDateTime(DateTime.Today).AddDays(10);
                                    lateFees[i] = 0;
                                    Console.WriteLine("Book borrowed successfully!");
                                    Console.WriteLine("This book has been borrowed " + count[i] + " times");
                                }
                                    else
                                    {
                                        Console.WriteLine("Book is already borrowed.");
                                    }
                                    break;
                                }
                            }
                           
                            break;

                        case 3:
                            // Option 3: Return Book
                            Console.Write("Enter ISBN: ");
                            string returnIsbn = Console.ReadLine();

                        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
                        bool found = false;

                        for (int i = 0; i <= lastBookIndex; i++)
                            {
                            if (isbns[i] == returnIsbn && !isAvailabe[i])

                            {
                                found = true;

                                if (today > returnDate[i])
                                {

                                    int lateDays = today.DayNumber - returnDate[i].DayNumber;
                                    lateFees[i] = lateDays * 0.5;
                                    Console.WriteLine("Late fee: " + lateFees[i]);
                                }
                                else
                                {
                                    Console.WriteLine("Book returned on time.");
                                }

                                isAvailabe[i] = true;
                                borrowers[i] = "";
                                break;
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Book not found or already available");
                        }

                        break;

                    case 4:
                            // Option 4: Search Book

                            Console.Write("Enter ISBN or Title: ");
                            string searchInput = Console.ReadLine();


                            for (int i = 0; i <= lastBookIndex; i++)
                            {
                            if (isbns[i] == searchInput || titles[i] == searchInput)
                            {
                                Console.WriteLine(titles[i] + " | " + authors[i] + " | " + categories[i] + " | Available: " + isAvailabe[i]);
                            }
                            }
                            break;
                               


                        case 5:
                            //List All Available Books 
                            Console.WriteLine("List All Available Books: ");
                            for (int i = 0; i <= lastBookIndex; i++)
                            {
                                if (isAvailabe[i])
                                {
                                Console.WriteLine(titles[i] + " - " + isbns[i]);

                            }
                        }

                            break;


                        case 6:
                            Console.Write("Enter ISBN: ");
                            string transferIsbn = Console.ReadLine();

                            Console.Write("Enter current borrower name: ");
                            string currentBorrowerName = Console.ReadLine();

                            Console.Write("Enter new borrower name: ");
                            string newBorrowerName = Console.ReadLine();


                            for (int i = 0; i <= lastBookIndex; i++)
                            {
                            if (isbns[i] == transferIsbn && borrowers[i] == currentBorrowerName )

                            {

                                        borrowers[i] = newBorrowerName;
                                        Console.WriteLine("Book transferred successfully!");
                                   
                                    break;
                                }
                            }

                            break;

                        case 7:
                        //Most popular

                        for (int i = 0; i <= lastBookIndex; i++)
                        {
                            Console.WriteLine(titles[i] + " | Borrowed: " + count[i]);
                        }
                        break;

                    case 8:
                        //Category search

                        Console.Write("Enter category: ");
                        string cat = Console.ReadLine();

                        for (int i = 0; i <= lastBookIndex; i++)
                        {
                            if (categories[i] == cat)
                            {
                                Console.WriteLine(titles[i] + " | " + isbns[i] + " | Available: " + isAvailabe[i]);
                            }
                        }
                        break;

                    case 9:
                        exit = true;
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}