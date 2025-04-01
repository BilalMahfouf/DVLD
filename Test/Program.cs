using System;
using System.Data;
using BusinessLogicLayer;


public static class clsPersonTest
{
    public static void RunAllTests()
    {
        Console.WriteLine("=== Running Person Tests ===\n");

        TestConstructorDefaults();
        TestFindPersonByID(1);        // Existing ID
        TestFindPersonByID(-999);     // Non-existent ID
        TestFindPersonByNationalNo("TEST-123");  // Existing
        TestFindPersonByNationalNo("INVALID_NAT"); // Non-existent
        TestAddNewPerson();
        TestUpdatePerson();
        TestDeletePerson();
        TestGetAllPeople();
        TestIsExistByID(1);             // Test with existing ID
        TestIsExistByID(-999);          // Test with non-existent ID
        TestIsExistByNationalNo("N1");  // Existing national number
        TestIsExistByNationalNo("INVALID-123"); //

        Console.WriteLine("\n=== Person Tests Completed ===");
    }

    public static void TestConstructorDefaults()
    {
        Console.WriteLine("\n[Test] Constructor Defaults");

        try
        {
            clsPerson person = new clsPerson();

            Console.WriteLine("Result: Success");
            Console.WriteLine($"PersonID: {person.PersonID} (Expected: -1)");
            Console.WriteLine($"FirstName: '{person.FirstName}' (Expected: '')");
            Console.WriteLine($"Mode: {person.Mode} (Expected: AddNew)");
            Console.WriteLine($"DateOfBirth: {person.DateOfBirth.ToShortDateString()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("FAILED");
        }
    }

    public static void TestFindPersonByID(int ID)
    {
        Console.WriteLine($"\n[Test] FindPersonByID({ID})");

        try
        {
            clsPerson person = clsPerson.Find(ID);

            if (person != null)
            {
                Console.WriteLine("Result: Found");
                Console.WriteLine($"PersonID: {person.PersonID}");
                Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
                Console.WriteLine($"NationalNo: {person.NationalNo}");
                Console.WriteLine($"DOB: {person.DateOfBirth.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine("Result: Not Found (Expected for invalid ID)");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("FAILED");
        }
    }

    public static void TestFindPersonByNationalNo(string nationalNo)
    {
        Console.WriteLine($"\n[Test] FindPersonByNationalNo('{nationalNo}')");

        try
        {
            clsPerson person = clsPerson.Find(nationalNo);

            if (person != null)
            {
                Console.WriteLine("Result: Found");
                Console.WriteLine($"PersonID: {person.PersonID}");
                Console.WriteLine($"Phone: {person.Phone}");
                Console.WriteLine($"Email: {person.Email}");
            }
            else
            {
                Console.WriteLine("Result: Not Found (Expected for invalid NationalNo)");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("FAILED");
        }
    }

    public static void TestAddNewPerson()
    {
        Console.WriteLine("\n[Test] AddNewPerson");

        try
        {
            clsPerson person = new clsPerson();
            person.NationalNo = "TEST-" + DateTime.Now.Ticks.ToString().Substring(0, 4);
            person.FirstName = "Test";
            person.LastName = "User";
            person.DateOfBirth = new DateTime(1990, 1, 1);
            person.Gendor = 1;
            person.Phone = "555-1234";
            person.NationalityCountryID = 3;

            bool result = person.Save();
            Console.WriteLine($"Result: {(result ? "Success" : "Failed")}");
            Console.WriteLine($"New PersonID: {person.PersonID} (Expected: >0)");
            Console.WriteLine($"New Mode: {person.Mode} (Expected: Update)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("FAILED");
        }
    }

    public static void TestUpdatePerson()
    {
        Console.WriteLine("\n[Test] UpdatePerson");

        try
        {
            // Find an existing person (or create one if none exists)
            clsPerson person = clsPerson.Find(1) ?? CreateTestPerson();

            string originalName = person.FirstName;
            person.FirstName = "Updated_" + DateTime.Now.Second;

            bool result = person.Save();
            Console.WriteLine($"Result: {(result ? "Success" : "Failed")}");
            Console.WriteLine($"Updated name: {person.FirstName}");

            // Restore original
            person.FirstName = originalName;
            person.Save();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("FAILED");
        }
    }

    public static void TestDeletePerson()
    {
        Console.WriteLine("\n[Test] DeletePerson");

        try
        {
            clsPerson tempPerson = CreateTestPerson();
            Console.WriteLine($"Created test person with ID: {tempPerson.PersonID}");

            bool result = clsPerson.DeletePerson(tempPerson.PersonID);
            Console.WriteLine($"Result: {(result ? "Success" : "Failed")}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("FAILED");
        }
    }

    public static void TestGetAllPeople()
    {
        Console.WriteLine("\n[Test] GetAllPeople");

        try
        {
            DataTable peopleTable = clsPerson.GetAllPerson();
            Console.WriteLine($"Found {peopleTable.Rows.Count} people");

            if (peopleTable.Rows.Count > 0)
            {
                Console.WriteLine("\nSample Data:");
                for (int i = 0; i < Math.Min(3, peopleTable.Rows.Count); i++)
                {
                    Console.WriteLine($"ID: {peopleTable.Rows[i]["PersonID"]} " +
                                  $"Name: {peopleTable.Rows[i]["FirstName"]} " +
                                  $"NationalNo: {peopleTable.Rows[i]["NationalNo"]}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("FAILED");
        }
    }
    public static void TestIsExistByID(int personID)
    {
        Console.WriteLine($"\n[Test] isExist(PersonID: {personID})");

        try
        {
            bool exists = clsPerson.isExist(personID);
            Console.WriteLine($"Result: {(exists ? "Exists" : "Not Found")}");

            // Additional verification for positive test cases
            if (exists)
            {
                var person = clsPerson.Find(personID);
                Console.WriteLine($"Verification: Found person - {person.FirstName} {person.LastName}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("FAILED");
        }
    }
    public static void TestIsExistByNationalNo(string nationalNo)
    {
        Console.WriteLine($"\n[Test] isExist(NationalNo: '{nationalNo}')");

        try
        {
            bool exists = clsPerson.isExist(nationalNo);
            Console.WriteLine($"Result: {(exists ? "Exists" : "Not Found")}");

            // Additional verification for positive test cases
            if (exists)
            {
                var person = clsPerson.Find(nationalNo);
                Console.WriteLine($"Verification: Found person - ID: {person.PersonID}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("FAILED");
        }
    }


    private static clsPerson CreateTestPerson()
    {
        clsPerson person = new clsPerson();
        person.NationalNo = "TEST-" + DateTime.Now.Ticks.ToString().Substring(0, 6);
        person.FirstName = "Test";
        person.LastName = "User";
        person.DateOfBirth = new DateTime(1990, 1, 1);
        person.Gendor = 1;
        person.Phone = "555-1234";
        person.NationalityCountryID = 3;
        person.Save();
        return person;
    }


}



    public static class clsCountriesTest
    {
        public static void RunAllTests()
        {
            Console.WriteLine("=== Running Countries Tests ===\n");

            TestGetAllCountries();

            Console.WriteLine("\n=== Countries Tests Completed ===");
        }

        public static void TestGetAllCountries()
        {
            Console.WriteLine("\n[Test] GetAllCountries()");

            try
            {
                DataTable countriesTable = clsCountries.GetAllCountries();

                Console.WriteLine($"Result: Success ({countriesTable.Rows.Count} countries found)");

                if (countriesTable.Rows.Count > 0)
                {
                    Console.WriteLine("\nSample Data:");
                    for (int i = 0; i < Math.Min(3, countriesTable.Rows.Count); i++)
                    {
                        DataRow row = countriesTable.Rows[i];
                        Console.WriteLine($"ID: {row["CountryID"]} | Name: {row["CountryName"]}");
                    }
                }
                else
                {
                    Console.WriteLine("Warning: No countries found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("FAILED");
            }
        }
    }


class clsPersonTester
{
    static void Main()
    {
        Console.WriteLine("Running clsPerson Tests...\n");

        clsPersonTest.RunAllTests();

        //clsCountriesTest.RunAllTests(); // test true 




        Console.WriteLine("\nAll tests completed.");
    }

    
    
}