using System;
using BusinessLogicLayer;

class clsPersonTester
{
    static void Main()
    {
        Console.WriteLine("Running clsPerson Tests...\n");

        // Run all tests
        // true testConstructorDefaults(); true

        //true  testFindPersonByID(1);        // Test with existing ID
        // true  testFindPersonByID(-999);     // Test with non-existent ID
        testFindPersonByNationalNo("N1");  // Existing
        testFindPersonByNationalNo("INVALID_NAT"); // Non-existent
        //testAddNewPerson();
        //testUpdatePerson();
        //testDeletePerson();
        //testGetAllPeople();

        Console.WriteLine("\nAll tests completed.");
    }

    static void testConstructorDefaults()
    {
        Console.WriteLine("\nTesting Constructor Defaults:");
        clsPerson person = new clsPerson();

        Console.WriteLine($"PersonID: {person.PersonID} (Expected: -1)");
        Console.WriteLine($"FirstName: '{person.FirstName}' (Expected: '')");
        Console.WriteLine($"Mode: {person.Mode} (Expected: AddNew)");
        Console.WriteLine($"DateOfBirth: {person.DateOfBirth.ToShortDateString()}");
    }

    static void testFindPersonByID(int ID)
    {
        Console.WriteLine($"\nTesting FindPersonByID({ID}):");
        clsPerson person = clsPerson.Find(ID);

        if (person != null)
        {
            Console.WriteLine($"PersonID: {person.PersonID}");
            Console.WriteLine($"NationalNo: {person.NationalNo}");
            Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
            Console.WriteLine($"DOB: {person.DateOfBirth.ToShortDateString()}");
            Console.WriteLine($"Mode: {person.Mode}");
        }
        else
        {
            Console.WriteLine("0 (Person not found)");
        }
    }

    static void testFindPersonByNationalNo(string nationalNo)
    {
        Console.WriteLine($"\nTesting FindPersonByNationalNo('{nationalNo}'):");
        clsPerson person = clsPerson.Find(nationalNo);

        if (person != null)
        {
            Console.WriteLine($"PersonID: {person.PersonID}");
            Console.WriteLine($"NationalNo: {person.NationalNo}");
            Console.WriteLine($"Phone: {person.Phone}");
            Console.WriteLine($"Email: {person.Email}");
        }
        else
        {
            Console.WriteLine("0 (Person not found)");
        }
    }

    static void testAddNewPerson()
    {
        Console.WriteLine("\nTesting AddNewPerson:");
        clsPerson person = new clsPerson();

        // Set properties
        person.NationalNo = "TEST-123";
        person.FirstName = "Test";
        person.LastName = "User";
        person.DateOfBirth = new DateTime(1990, 1, 1);
        person.Gendor = 1;
        person.Phone = "555-1234";

        bool result = person.Save();
        Console.WriteLine($"Save result: {result} (Expected: True)");
        Console.WriteLine($"New PersonID: {person.PersonID} (Expected: >0)");
        Console.WriteLine($"New Mode: {person.Mode} (Expected: Update)");
    }

    static void testUpdatePerson()
    {
        Console.WriteLine("\nTesting UpdatePerson:");

        // First find an existing person
        clsPerson person = clsPerson.Find(1);
        if (person == null)
        {
            Console.WriteLine("Cannot test update - no person found");
            return;
        }

        string originalName = person.FirstName;
        person.FirstName = "Updated_" + originalName;

        bool result = person.Save();
        Console.WriteLine($"Update result: {result} (Expected: True)");
        Console.WriteLine($"Updated name: {person.FirstName}");

        // Restore original value
        person.FirstName = originalName;
        person.Save();
    }

    static void testDeletePerson()
    {
        Console.WriteLine("\nTesting DeletePerson:");

        // First create a test person to delete
        clsPerson tempPerson = new clsPerson();
        tempPerson.NationalNo = "TO-DELETE";
        tempPerson.FirstName = "Temp";
        tempPerson.LastName = "User";
        tempPerson.Save();

        Console.WriteLine($"Created temp person with ID: {tempPerson.PersonID}");
        bool result = clsPerson.DeletePerson(tempPerson.PersonID);
        Console.WriteLine($"Delete result: {result} (Expected: True)");
    }

    static void testGetAllPeople()
    {
        Console.WriteLine("\nTesting GetAllPeople:");
        var peopleTable = clsPerson.GetAllPerson();

        Console.WriteLine($"Found {peopleTable.Rows.Count} people");
        if (peopleTable.Rows.Count > 0)
        {
            Console.WriteLine("First 3 records:");
            for (int i = 0; i < Math.Min(3, peopleTable.Rows.Count); i++)
            {
                Console.WriteLine($"ID: {peopleTable.Rows[i]["PersonID"]} " +
                                  $"Name: {peopleTable.Rows[i]["FirstName"]} " +
                                  $"NationalNo: {peopleTable.Rows[i]["NationalNo"]}");
            }
        }
    }
}