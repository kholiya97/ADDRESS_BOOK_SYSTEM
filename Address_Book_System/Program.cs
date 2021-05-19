using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    class AddressBook
    {

        List<Person> adressBookList;//create list
        public AddressBook()//default constructor
        {
            this.adressBookList = new List<Person>();
        }
        public void AddContact(string firstName, string lastName, string address, string city, string state, long phoneNumber, string email, int zip)
        {
            bool flag = this.adressBookList.Any(item => item.firstName == firstName && item.lastName == lastName);
            if (!flag)
            {
                Person person = new Person(firstName, lastName, city, state, email, phoneNumber, zip);//create new object of person class
                adressBookList.Add(person);//adding person details in addressbookList 
                Console.WriteLine("Contact added Successfully");
            }
            else
            {
                Console.WriteLine("{0}{1} this contact already exist in Address Book :", firstName, lastName);
            }
        }
        public void displayPerson()
        {
            Console.WriteLine("\nEntered Person Details is:");
            foreach (var person in adressBookList)
            {
                Console.WriteLine("FirstName: {0}, LastName: {1}, city: {2}, state: {3}, email: {4}, phoneNumber: {5}", person.firstName, person.lastName, person.city, person.state, person.email, person.phoneNumber);
            }
        }

        public void displayPersonInOrder()
        {
            Console.WriteLine("\nEntered Person Details is in Order :");
            foreach (var person in adressBookList.OrderBy(Key => Key.firstName))//orderBy sorts the vlues of collection in ascending or decending order
            {
                Console.WriteLine("FirstName: {0}, LastName: {1}, city: {2}, state: {3}, email: {4}, phoneNumber: {5}", person.firstName, person.lastName, person.city, person.state, person.email, person.phoneNumber);
            }
        }

        public void searchPerson()
        {
            Console.WriteLine("\n Enter city or state ");
            string city = Console.ReadLine();
            string state = Console.ReadLine();
            //findall method is used to retrive all the elements that match the conditions define the specified predeicate
            foreach (Person person in adressBookList.FindAll(item => item.city == city && item.state == state).ToList())
            {
                Console.WriteLine("\n{0}\t{1}", person.firstName, person.lastName);
            }
        }

        public void sameCityPerson()
        {
            Console.WriteLine("\n Enter city for display Same city contacts ");
            string city = Console.ReadLine();
            foreach (Person person in adressBookList.FindAll(item => item.city == city).ToList())
            {
                Console.WriteLine("\n{0}\t{1}", person.firstName, person.lastName);
            }
        }

        public void sameStatePerson()
        {
            Console.WriteLine("\n Enter state for display Same State contacts ");
            string stateCheck = Console.ReadLine();
            foreach (Person person in adressBookList.FindAll(item => item.state == stateCheck).ToList())
            {
                Console.WriteLine("\n{0}\t{1}", person.firstName, person.lastName);
            }
        }

        public void findCountSameStateOrCityPerson()
        {
            Console.WriteLine("\n Enter city and state");
            string city = Console.ReadLine();
            string state = Console.ReadLine();
            int count2 = 0;
            foreach (Person person in adressBookList.FindAll(item => item.city == city && item.state == state).ToList())
            {
                Console.WriteLine("\n{0}\t{1}", person.firstName, person.lastName);
                count2++;
            }
            Console.WriteLine("This {0} persons are in same state {1} \t {2} ", count2, state, city);
        }
        public void editPerson()
        {
            Console.WriteLine("\n enter First name to edit details:");
            string name = Console.ReadLine();
            foreach (var person in adressBookList)
            {
                if (name.Equals(person.firstName))
                {
                    Console.WriteLine("Choose one of the following options: ");
                    Console.WriteLine("#1 Phone Number");
                    Console.WriteLine("#2 Email");
                    Console.WriteLine("#3 City");
                    Console.WriteLine("#4 State");
                    Console.WriteLine("#5 Quit");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("enter new Mobile number:");
                            long mobileNo = Convert.ToInt64(Console.ReadLine());
                            person.setPhoneNumber(mobileNo);
                            Console.WriteLine("mobile no. is updated\n");
                            break;
                        case 2:
                            Console.WriteLine("enter new Email-id:");
                            String email = Console.ReadLine();
                            person.setEmail(email);
                            Console.WriteLine("Email-id is updated\n");
                            break;
                        case 3:
                            Console.WriteLine("enter your city");
                            String city = Console.ReadLine();
                            person.setCity(city);
                            break;
                        case 4:
                            Console.WriteLine("enter your state");
                            String state = Console.ReadLine();
                            person.setState(state);
                            person.setState(state);
                            Console.WriteLine("Address is updated\n");
                            break;
                        default:
                            Console.WriteLine("please enter right choice");
                            break;
                    }
                }
            }
        }


        public void deletePerson()
        {
            Console.WriteLine("Enter firstName of the user you want to remove");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter lastname of the user you want to remove");
            var lastName = Console.ReadLine();
            adressBookList.RemoveAll(item => item.firstName == firstName && item.lastName == lastName);
        }
    }
    class Person
    {
        public string firstName;
        public string lastName;
        public string city;
        public string state;
        public string email;
        public long phoneNumber;
        public int zip;
        public Person(string firstName, string lastName, string city, string state, string email, long phoneNumber, int zip)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.city = city;
            this.state = state;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.zip = zip;
        }
        public String getFirstName()
        {
            return firstName;
        }

        public void setFirstName(String firstName)
        {
            this.firstName = firstName;
        }

        public String getLastName()
        {
            return lastName;
        }

        public void setLastName(String lastName)
        {
            this.lastName = lastName;
        }

        public String getCity()
        {
            return city;
        }

        public void setCity(String city)
        {
            this.city = city;
        }

        public String getState()
        {
            return state;
        }

        public void setState(String state)
        {
            this.state = state;
        }
        public long getPhoneNumber()
        {
            return phoneNumber;
        }

        public void setPhoneNumber(long phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public String getEmail()
        {
            return email;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }

        public int getZip()
        {
            return zip;
        }

        public void setZip(int zip)
        {
            this.zip = zip;
        }
    }
    class Program
    {
        /// <summary>
        /// Entery point 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(String[] args)
        {
            // AddressBook obj = new AddressBook();//create object of AddressBook class


            Console.WriteLine("Welcome in Address book System");
            Console.WriteLine("*********************");
            //creating dictionary abDict
            Dictionary<string, AddressBook> abDict = new Dictionary<string, AddressBook>();//store Key ValuePair String is Key and AddressBook is value
            bool Result = true;

            Console.WriteLine("\nHow many address Book you want to create : ");
            int numAddressBooks = Convert.ToInt32(Console.ReadLine());//covert string into int with the help of ToInt32()
            for (int i = 1; i <= numAddressBooks; i++)
            {
                Console.WriteLine("Enter the name of address book " + i + ": ");
                string bookName = Console.ReadLine();
                AddressBook addressBook = new AddressBook();//create obj 
                abDict.Add(bookName, addressBook);//Add bookName in dictionary
            }
            Console.WriteLine("\nYou have created following Address Books : ");
            foreach (var item in abDict) //var is used and it is store any data type value.
            {
                Console.WriteLine("{0}", item.Key);
            }
            while (Result)
            {
                Console.WriteLine("\nChoose option \n1.Add Contact \n2.Edit Contact \n3.Delete Contact  \n4.Display Contacts \n5.Search Person By City & State \n6.Display Contacts Same City \n7.Display Contacts Same State \n8.View number of contacts of city and state  \n9.Display Contacts in Sorted \n10.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nEnter Existing Address Book Name for adding contacts");
                        string contactName = Console.ReadLine();
                        if (abDict.ContainsKey(contactName))//DEtermine whether the dictionary contains specified key
                        {
                            Console.WriteLine("\nEnter the number of contacts you want to add in address book");
                            int numberOfContacts = Convert.ToInt32(Console.ReadLine());//taling i/p from user and convert into int with the help of ToInt32()
                            for (int i = 1; i <= numberOfContacts; i++)
                            {
                                addContactBook(abDict[contactName]);
                            }
                            abDict[contactName].displayPerson();
                        }
                        else
                        {
                            Console.WriteLine("No AddressBook exist with name {0}", contactName);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Address Book Name for edit contact");
                        string editcontactName = Console.ReadLine();
                        if (abDict.ContainsKey(editcontactName))//check whether the dictionary contains specified key
                        {
                            abDict[editcontactName].editPerson();
                            abDict[editcontactName].displayPerson();
                        }
                        else
                        {
                            Console.WriteLine("No Address book exist with name {0} ", editcontactName);
                        }
                        break;
                    case 3:
                        Console.WriteLine("\nEnter Address Book Name for delete contact");
                        string deleteContact = Console.ReadLine();
                        if (abDict.ContainsKey(deleteContact))
                        {
                            abDict[deleteContact].deletePerson();
                            abDict[deleteContact].displayPerson();
                        }
                        else
                        {
                            Console.WriteLine("No Address book exist with name {0} ", deleteContact);
                        }
                        break;
                    case 4:
                        Console.WriteLine("\nEnter Address Book Name for display contacts");
                        string displayContactsInAddressBook = Console.ReadLine();
                        abDict[displayContactsInAddressBook].displayPerson();
                        break;
                    case 5:
                        Console.WriteLine("\n Enter address book name :");
                        string searchContacts = Console.ReadLine();
                        if (abDict.ContainsKey(searchContacts))
                        {
                            abDict[searchContacts].searchPerson();
                        }
                        else
                        {
                            Console.WriteLine("No Address book exist with name {0} ", searchContacts);
                        }
                        break;
                    case 6:
                        Console.WriteLine("\n Enter address book name :");
                        string displayContacts = Console.ReadLine();
                        if (abDict.ContainsKey(displayContacts))
                        {
                            abDict[displayContacts].sameCityPerson();
                        }
                        else
                        {
                            Console.WriteLine("No Address book exist with name {0} ", displayContacts);
                        }
                        break;
                    case 7:
                        Console.WriteLine("\n Enter address book name :");
                        string displayContacts2 = Console.ReadLine();
                        if (abDict.ContainsKey(displayContacts2))
                        {
                            abDict[displayContacts2].sameStatePerson();
                        }
                        else
                        {
                            Console.WriteLine("No Address book exist with name {0} ", displayContacts2);
                        }
                        break;
                    case 8:
                        Console.WriteLine("\n Enter address book name :For counting same city or state");
                        string displayContacts3 = Console.ReadLine();
                        if (abDict.ContainsKey(displayContacts3))
                        {
                            abDict[displayContacts3].findCountSameStateOrCityPerson();
                        }
                        else
                        {
                            Console.WriteLine("No Address book exist with name {0} ", displayContacts3);
                        }
                        break;

                    case 9:
                        Console.WriteLine("\nEnter Address Book Name for display contacts in sorted order");
                        string nameAddressBook = Console.ReadLine();
                        abDict[nameAddressBook].displayPersonInOrder();
                        break;

                    case 10:
                        Result = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid option");
                        break;
                }

            }
            void addContactBook(AddressBook addressBook)
            {
                Console.WriteLine("Enter First Name : ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name : ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter Address : ");
                string address = Console.ReadLine();
                Console.WriteLine("Enter City : ");
                string city = Console.ReadLine();
                Console.WriteLine("Enter State : ");
                string state = Console.ReadLine();
                Console.WriteLine("Enter Phone Number : ");
                long phoneNumber = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Email id :");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Zip : ");
                int zip = Convert.ToInt32(Console.ReadLine());
                addressBook.AddContact(firstName, lastName, address, city, state, phoneNumber, email, zip);
            }

        }
    }
}
