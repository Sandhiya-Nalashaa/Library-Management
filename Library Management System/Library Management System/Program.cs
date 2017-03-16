using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {      
                Console.WriteLine("***LIBRARY MANAGEMENT SYSTEM***\n");
                List<Book> ListofBooks = populateBookData();
                List<Members> ListofMembers = populateMemberData();
                mainMenu(ListofBooks, ListofMembers);
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static List<Book> populateBookData()
        {

            var ListofBooks = new List<Book>();
            ListofBooks.Add(new Book() { AuthorLastName = "Last1", AuthorFirstName = "First1", Title = "Book1", bookCount = 5 });
            ListofBooks.Add(new Book() { AuthorLastName = "Last2", AuthorFirstName = "First2", Title = "Book2", bookCount = 10 });
            ListofBooks.Add(new Book() { AuthorLastName = "Last3", AuthorFirstName = "First3", Title = "Book3", bookCount = 1 });
            return ListofBooks;
        }

        private static List<Members> populateMemberData()
        {
            var ListofMembers = new List<Members>();
            ListofMembers.Add(new Members() { Name = "Member1", ID = 1 });
            ListofMembers.Add(new Members() { Name = "Member2", ID = 2 });
            ListofMembers.Add(new Members() { Name = "Member3", ID = 3 });
            return ListofMembers;
        }

        private static void searchBook(List<Book> ListofBooks,List<Members> ListofMembers)
        {
            Console.WriteLine("Enter your search criteria- a.BookTitle; b-AuthorFirstName; c-AuthorLastName;");
            string searchCriteria = Console.ReadLine().ToLower().ToString();
            if (searchCriteria == "a")
            {
                Console.WriteLine("Enter Book Title: ");
                string titleEntered = Console.ReadLine().ToString();
                //List<string> BooksListAvailable = new List<string>();
                var SearchResult = new List<Book>();
                foreach (var li in ListofBooks)
                {                    
                    if (li.Title.ToLower().Contains(titleEntered.ToLower()))
                    {
                        SearchResult.Add(new Book() { AuthorLastName = li.AuthorLastName, AuthorFirstName = li.AuthorFirstName, Title = li.Title, bookCount = li.bookCount });
                    }
                }
                if (SearchResult.Count != 0)
                {
                    Console.WriteLine(string.Format("Book with the title containing {0} is available. And the list of books available with this name are: ", titleEntered));
                    foreach (var s in SearchResult)
                    {
                        Console.WriteLine(string.Format("BookTitle: {0}, Author: {1} {2} , Count Available: {3}", s.Title, s.AuthorFirstName, s.AuthorLastName, s.bookCount));
                    }
                    //BooksListAvailable.ForEach(Console.WriteLine);
                    Console.WriteLine("Do you wish to borrow any of these books. Y/N :");
                    var option = Console.ReadLine().ToString();
                    if (option == "N" || option == "n")
                    {
                        repeat(ListofBooks, ListofMembers);
                    }
                    else if (option == "Y" || option == "y")
                    {
                        Console.WriteLine("Enter Book Name: ");
                        var bookName = Console.ReadLine().ToString(); issueBook(bookName, ListofBooks, ListofMembers);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                        mainMenu(ListofBooks, ListofMembers);
                    }
                }
                else
                {
                    Console.WriteLine("Books with specified title not found");
                    repeat(ListofBooks, ListofMembers);
                }
            }

            if (searchCriteria == "b")
            {
                Console.WriteLine("Enter Author's FirstName: ");
                string nameEntered = Console.ReadLine().ToString();
                var SearchResult = new List<Book>();
               
                foreach (var li in ListofBooks)
                {
                    if (li.AuthorFirstName.ToLower().Contains(nameEntered.ToLower()))
                    {
                        SearchResult.Add(new Book() { AuthorLastName = li.AuthorLastName, AuthorFirstName = li.AuthorFirstName, Title = li.Title,bookCount=li.bookCount });
                    }
                }

                if (SearchResult.Count != 0)
                {
                    Console.WriteLine(string.Format("List of books with the author's first name containing {0} are: ", nameEntered));
                    foreach (var s in SearchResult)
                    {
                        Console.WriteLine(string.Format("BookTitle: {0}, Author: {1} {2} , Count Available: {3}", s.Title, s.AuthorFirstName, s.AuthorLastName, s.bookCount));
                    }
                    Console.WriteLine("Do you wish to borrow any of these books. Y/N :");
                    var option = Console.ReadLine().ToString();
                    if (option == "N" || option == "n")
                    {
                        repeat(ListofBooks, ListofMembers);
                    }
                    if (option == "Y" || option == "y")
                    {
                        Console.WriteLine("Enter Book Name: ");
                        var bookName = Console.ReadLine().ToString(); issueBook(bookName, ListofBooks, ListofMembers);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                        mainMenu(ListofBooks, ListofMembers);
                    }
                }
                else
                {
                    Console.WriteLine("Books with specified author name not found");
                    repeat(ListofBooks, ListofMembers);
                }
            }

            if (searchCriteria == "c")
            {
                Console.WriteLine("Enter Author's LastName: ");
                string nameEntered = Console.ReadLine().ToString();
                var SearchResult = new List<Book>();
                if (SearchResult.Count != 0)
                {
                    foreach (var li in ListofBooks)
                    {
                        if (li.AuthorLastName.Contains(nameEntered))
                        {
                            SearchResult.Add(new Book() { AuthorLastName = li.AuthorLastName, AuthorFirstName = li.AuthorFirstName, Title = li.Title, bookCount = li.bookCount });
                        }
                    }

                    Console.WriteLine(string.Format("Book with the author's last name containing {0} is available. And the list of books available with this name are: ", nameEntered));
                    foreach (var s in SearchResult)
                    {
                        Console.WriteLine(string.Format("BookTitle: {0}, Author: {1} {2} , Count Available: {3}", s.Title, s.AuthorFirstName, s.AuthorLastName, s.bookCount));
                    }

                    Console.WriteLine("Do you wish to borrow any of these books. Y/N :");
                    var option = Console.ReadLine().ToString();
                    if (option == "N" || option == "n")
                    {
                        repeat(ListofBooks, ListofMembers);
                    }
                    if (option == "Y" || option == "y")
                    {
                        Console.WriteLine("Enter Book Name: ");
                        var bookName = Console.ReadLine().ToString();
                        issueBook(bookName, ListofBooks, ListofMembers);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                        mainMenu(ListofBooks, ListofMembers);
                    }
                }
                else
                {
                    Console.WriteLine("Books with specified author name not found");
                    repeat(ListofBooks, ListofMembers);
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
                repeat(ListofBooks, ListofMembers);
            }
        }

        private static void issueBook(string bookName, List<Book> ListofBooks, List<Members> ListofMembers)
        {
            Console.WriteLine("Are you a member? Y/N");
            var optionGiven = Console.ReadLine().ToLower().ToString();
            if (optionGiven == "n")
            {
                Console.WriteLine("Would you like to add to the members list? Y/N : ");
                var opt = Console.ReadLine().ToString();
                if (opt.ToLower() == "y")
                {
                    addMember(ListofBooks, ListofMembers);                    
                }
                else if (opt.ToLower() == "n")
                {
                    repeat(ListofBooks, ListofMembers);
                }
                else
                {
                    Console.WriteLine("Please enter valid input");
                    repeat(ListofBooks, ListofMembers);
                }

            }
            else if (optionGiven == "y")
            {
                Console.WriteLine("Enter member ID: ");
                var memberID = int.Parse(Console.ReadLine().ToString());
                bool isMem = checkMember(memberID, ListofBooks, ListofMembers);
                if (isMem)
                {
                    bool isbookavail = checkBook(bookName, ListofBooks, ListofMembers);
                    if (isbookavail)
                    {
                        foreach (var li in ListofBooks)
                        {
                            if (li.isBookAvailable && li.bookCount>0 && li.bookAvailableWithMember!=memberID)
                            {
                                Console.WriteLine("Book Issued");
                                li.bookCount--;
                                li.bookAvailableWithMember = memberID;
                                Console.WriteLine(string.Format("Count of {0} available is {1}", li.Title.ToString(), li.bookCount));
                                Console.WriteLine(string.Format("Book {0} is currently available with member having ID {1}", li.Title.ToString(), li.bookAvailableWithMember));
                                repeat(ListofBooks, ListofMembers);
                            }

                            else if (li.bookCount == 0 && li.isBookAvailable && li.bookAvailableWithMember != memberID)
                            {
                                Console.WriteLine("Book out of stock");
                                repeat(ListofBooks, ListofMembers);
                            }

                            else if (li.bookCount > 0 && li.isBookAvailable && li.bookAvailableWithMember == memberID)
                            {
                                Console.WriteLine("You are not allowed to take more than one copy of the same book");
                                repeat(ListofBooks, ListofMembers);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Book with title " + bookName + "is not available in library");
                        repeat(ListofBooks, ListofMembers);
                    }
                }
                else if (!isMem)
                {
                    Console.WriteLine("Invalid Member ID");
                    repeat(ListofBooks, ListofMembers);
                }
            }
            else
            {
                Console.WriteLine("Please enter valid input");
                repeat(ListofBooks, ListofMembers);
            }

        }

        private static void submitBook(string bookName, List<Book> ListofBooks, List<Members> ListofMembers)
        {
            Console.WriteLine("Enter member ID: ");
            var memberID = int.Parse(Console.ReadLine().ToString());
            bool isMem = checkMember(memberID, ListofBooks, ListofMembers);

            if (isMem)
            {
                bool isbookavail = checkBook(bookName, ListofBooks, ListofMembers);
                if (isbookavail)
                {
                    foreach (var li in ListofBooks)
                    {
                        if (li.isBookAvailable && li.bookAvailableWithMember == memberID)
                        {
                            li.bookCount++;
                            li.bookLastReturnedFromMember = memberID;
                            li.bookAvailableWithMember = 0;
                            Console.WriteLine(string.Format("Count of {0} available is {1}", li.Title.ToString(), li.bookCount));
                            Console.WriteLine("Book Submitted");
                            repeat(ListofBooks, ListofMembers);
                        }
                        else if (li.isBookAvailable && li.bookAvailableWithMember != memberID)
                        {
                            Console.WriteLine("Book is not available with the specified member ID");
                            repeat(ListofBooks, ListofMembers);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Book with Name " + bookName + "is not available");
                    repeat(ListofBooks, ListofMembers);
                }
            }
            else if (!isMem)
            {
                Console.WriteLine("Invalid Member ID");
                repeat(ListofBooks, ListofMembers);
            }
        }

        private static void addMember(List<Book> ListofBooks, List<Members> ListofMembers)
        {
            Console.WriteLine("Please enter member Name: ");
            string memberName = Console.ReadLine().ToString();
            var listcount = ListofMembers.Count+1;
            ListofMembers.Add(new Members() { Name = memberName, ID = listcount });
            Console.WriteLine("Member Added");
            Console.WriteLine("Member Details: Name :" + ListofMembers[listcount-1].Name + " ; ID :"+ ListofMembers[listcount-1].ID+""); 
            repeat(ListofBooks, ListofMembers);
        }

        private static bool checkMember(int memberID, List<Book> ListofBooks, List<Members> ListofMembers)
        {
            bool isMember=false;
            foreach (var lm in ListofMembers)
            {
                if (lm.ID == memberID)
                {
                    isMember = true;
                }                
            }
            return isMember;
        }

        private static bool checkBook(string bookName, List<Book> ListofBooks, List<Members> ListofMembers)
        {
            bool isBookAvail = false;
            var newList = new List<Book>(); ;
            foreach (var lm in ListofBooks)
            {
                if (lm.Title.ToLower() == bookName.ToLower())
                {
                    isBookAvail=true;
                    newList.Add(new Book(){Title=lm.Title,AuthorFirstName=lm.AuthorFirstName,AuthorLastName=lm.AuthorLastName,bookCount=lm.bookCount,isBookAvailable=isBookAvail});
                    lm.isBookAvailable = isBookAvail;
                }
            }
            return isBookAvail;
        }

        private static void mainMenu(List<Book> ListofBooks, List<Members> ListofMembers)
        {
            Console.WriteLine("Please Enter your Choice\n");
            Console.WriteLine("1 - Search for a book in the list; ");
            Console.WriteLine("2 - Get a book ; ");
            Console.WriteLine("3 - Submit/Return a book;  ");
            Console.WriteLine("4 - Add a new Member;");
            Console.WriteLine("5 - Exit the application; ");
            var getOption = Console.ReadLine().ToString();
           
            //Option 1: Search for a book
            if (getOption == "1")
            {
                searchBook(ListofBooks, ListofMembers);
            }

            //Option 2: Issue a book
            if (getOption == "2")
            {
                Console.WriteLine("Enter Book Name: ");
                var bookName = Console.ReadLine().ToString();
                issueBook(bookName, ListofBooks, ListofMembers);
            }
            //Option 3: Submit a book
            if (getOption == "3")
            {
                Console.WriteLine("Enter Book Name: ");
                var bookName = Console.ReadLine().ToString();
                submitBook(bookName, ListofBooks, ListofMembers);
            }
            //Option:4 Add Membership
            if (getOption == "4")
            {
                Console.WriteLine("Please enter member details");
                addMember(ListofBooks, ListofMembers);
            }

            //Option 5: Exit App
            if (getOption == "5")
            {
                Console.WriteLine("Exit Application ");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Would you like to perform some other funtion? Y/N : ");
                var opt1 = Console.ReadLine().ToString();
                if (opt1 == "Y" || opt1 == "y")
                {
                    mainMenu(ListofBooks, ListofMembers);
                }
                else { Environment.Exit(0); }
            }
        }

        private static void repeat(List<Book> ListofBooks, List<Members> ListofMembers)
        {
            Console.WriteLine("Would you like to perform some other funtion? Y/N : ");
            var opt = Console.ReadLine().ToString();
            if (opt.ToLower() == "y")
            {
                mainMenu(ListofBooks, ListofMembers);
            }
            else if (opt.ToLower() == "n")
            {
                Environment.Exit(0); 
            }
            else 
            {
                Console.WriteLine("Please enter valid input");
                repeat(ListofBooks, ListofMembers);
            }
        }
    }


    public class Book
    {
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string Title { get; set; }
        public int bookCount { get; set; }
        public int bookAvailableWithMember {get;set;}
        public int bookLastReturnedFromMember { get; set; }
        public bool isBookAvailable { get; set; }
    }
    public class Members
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
          
}
