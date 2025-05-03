using System;
using System.Data;
using BusinessLogicLayer;


public static class clsPersonTest
{
    public static void RunAllTests()
    {
        Console.WriteLine("=== Running Person Tests ===\n");

        TestFindPersonByID(1);

        //TestConstructorDefaults();
        //       // Existing ID
        //TestFindPersonByID(-999);     // Non-existent ID
        //TestFindPersonByNationalNo("TEST-123");  // Existing
        //TestFindPersonByNationalNo("INVALID_NAT"); // Non-existent
        //TestAddNewPerson();
        //TestUpdatePerson();
        //TestDeletePerson();
        //TestGetAllPeople();
        //TestIsExistByID(1);             // Test with existing ID
        //TestIsExistByID(-999);          // Test with non-existent ID
        //TestIsExistByNationalNo("N1");  // Existing national number
        //TestIsExistByNationalNo("INVALID-123"); //

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
            person.Gender = 1;
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
        person.Gender = 1;
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

public static class clsApplicationTypesTest
{
    public static void RunAllTests()
    {
        Console.WriteLine("=== Running Application Types Tests ===\n");

        TestGetAllApplicationTypes();
        TestFindApplicationType();
        //TestSaveApplicationType();

        Console.WriteLine("\n=== Application Types Tests Completed ===");
    }

    public static void TestGetAllApplicationTypes()
    {
        Console.WriteLine("\n[Test] GetAllApplicationTypes()");

        try
        {
            DataTable appTypesTable = clsApplicationType.GetAllApplicationTypes();

            Console.WriteLine($"Result: Success ({appTypesTable.Rows.Count} application types found)");

            if (appTypesTable.Rows.Count > 0)
            {
                Console.WriteLine("\nSample Data:");
                for (int i = 0; i < Math.Min(3, appTypesTable.Rows.Count); i++)
                {
                    DataRow row = appTypesTable.Rows[i];
                    Console.WriteLine($"ID: {row["ApplicationTypeID"]} | Title: {row["ApplicationTypeTitle"]} | Fee: {row["ApplicationFees"]}");
                }
            }
            else
            {
                Console.WriteLine("Warning: No application types found in database");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("FAILED");
        }
    }

    public static void TestFindApplicationType()
    {
        Console.WriteLine("\n[Test] Find(int ApplicationTypeID)");

        try
        {
            int testID = 1; // <-- make sure this ID exists in your database
            clsApplicationType appType = clsApplicationType.Find(testID);

            if (appType != null)
            {
                Console.WriteLine($"Result: Found");
                Console.WriteLine($"ID: {appType.ApplicationTypeID} | Title: {appType.ApplicationTitle}");
            }
            else
            {
                Console.WriteLine($"Result: Not Found (No record with ID = {testID})");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("FAILED");
        }
    }

    public static void TestSaveApplicationType()
    {
        Console.WriteLine("\n[Test] Save() — Update ApplicationType");

        clsApplicationType a = clsApplicationType.Find(1);
        if (a != null)
        {
            a.ApplicationFee = 15;
            a.ApplicationTitle = "New Local Driving License Service";
            if (a.Save())
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }

}
    public static class clsUserTest
    {
        public static void RunAllTests()
        {
            Console.WriteLine("=== Running User Tests ===\n");

            TestGetAllUsers();
            TestFindUserByID();
            TestFindUserByCredentials();
            TestAddNewUser();
            TestUpdateUser();
            TestDeleteUser();

            Console.WriteLine("\n=== User Tests Completed ===");
        }

        public static void TestGetAllUsers()
        {
            Console.WriteLine("\n[Test] GetAllUsers()");

            try
            {
                DataTable usersTable = clsUser.GetAllUsers();
                Console.WriteLine($"Result: Success ({usersTable.Rows.Count} users found)");

                if (usersTable.Rows.Count > 0)
                {
                    Console.WriteLine("\nSample Data:");
                    for (int i = 0; i < Math.Min(3, usersTable.Rows.Count); i++)
                    {
                        DataRow row = usersTable.Rows[i];
                        Console.WriteLine($"UserID: {row["UserID"]} | UserName: {row["UserName"]} | PersonID: {row["PersonID"]} | IsActive: {row["IsActive"]}");
                    }
                }
                else
                {
                    Console.WriteLine("Warning: No users found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("FAILED");
            }
        }

        public static void TestFindUserByID()
        {
            Console.WriteLine("\n[Test] Find(int userID)");

            try
            {
                // Replace with valid ID in your DB
                clsUser user = clsUser.Find(17);

                if (user != null)
                {
                    DisplayUserData(user);
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("FAILED");
            }
        }

        public static void TestFindUserByCredentials()
        {
            Console.WriteLine("\n[Test] Find(string username, string password)");

            try
            {
                string username = "Msaqer77";   // Replace with valid username
                string password = "1234";   // Replace with correct password
                clsUser user = clsUser.Find(username, password);

                if (user != null)
                {
                    DisplayUserData(user);
                }
                else
                {
                    Console.WriteLine("Invalid credentials or user not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("FAILED");
            }
        }

        public static void TestAddNewUser()
        {
            Console.WriteLine("\n[Test] Add New User (Save with AddNew mode)");

            try
            {
                clsUser newUser = new clsUser
                {
                    PersonID = 1091, // Replace with valid PersonID from DB
                    UserName = "TestUser_" + Guid.NewGuid().ToString().Substring(0, 5),
                    Password = "123456",
                    IsActive = true
                };

                bool result = newUser.Save();

                Console.WriteLine(result
                    ? $"New user added successfully. UserID = {newUser.UserID}"
                    : "Failed to add new user.");

                if (result) DisplayUserData(newUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("FAILED");
            }
        }

        public static void TestUpdateUser()
        {
            Console.WriteLine("\n[Test] Update User (Save with Update mode)");

            try
            {
                clsUser user = clsUser.Find(17); // Replace with valid ID
                if (user == null)
                {
                    Console.WriteLine("User not found for update.");
                    return;
                }

                user.UserName = "_Updated";
                user.Password = "newpass";
                user.IsActive = !user.IsActive;

                bool result = user.Save();

                Console.WriteLine(result
                    ? $"User updated successfully."
                    : "Failed to update user.");

                if (result) DisplayUserData(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("FAILED");
            }
        }

        public static void TestDeleteUser()
        {
            Console.WriteLine("\n[Test] Delete User");

            try
            {
                // First, create a test user to delete
                clsUser tempUser = new clsUser
                {
                    PersonID = 1092, // Replace with valid PersonID
                    UserName = "ToDelete_" + Guid.NewGuid().ToString().Substring(0, 5),
                    Password = "temp",
                    IsActive = true
                };

                if (!tempUser.Save())
                {
                    Console.WriteLine("Could not create user to delete.");
                    return;
                }

                Console.WriteLine("Created user for deletion:");
                DisplayUserData(tempUser);

                bool deleted = clsUser.DeleteUser(tempUser.UserID);

                Console.WriteLine(deleted
                    ? $"User deleted successfully. ID = {tempUser.UserID}"
                    : "Failed to delete user.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("FAILED");
            }
        }

        private static void DisplayUserData(clsUser user)
        {
            Console.WriteLine("User Data:");
            Console.WriteLine($"UserID   : {user.UserID}");
            Console.WriteLine($"PersonID : {user.PersonID}");
            Console.WriteLine($"UserName : {user.UserName}");
            Console.WriteLine($"Password : {user.Password}");
            Console.WriteLine($"IsActive : {user.IsActive}");
            Console.WriteLine($"Mode     : {user.Mode}");
        }
}

public static class clsTestTypesTest
{
    public static void RunAllTests()
    {
        Console.WriteLine("=== Running Test Types Tests ===\n");

        TestGetAllTestTypes();
        TestFindTestType();
       // TestSaveTestType();

        Console.WriteLine("\n=== Test Types Tests Completed ===");
    }

    public static void TestGetAllTestTypes()
    {
        Console.WriteLine("\n[Test] GetAllTestTypes()");

        try
        {
            DataTable testTypesTable = clsTestType.GetAllTestTypes();

            Console.WriteLine($"Result: Success ({testTypesTable.Rows.Count} test types found)");

            if (testTypesTable.Rows.Count > 0)
            {
                Console.WriteLine("\nSample Data:");
                for (int i = 0; i < Math.Min(3, testTypesTable.Rows.Count); i++)
                {
                    DataRow row = testTypesTable.Rows[i];
                    Console.WriteLine($"ID: {row["TestTypeID"]} | Title: {row["TestTypeTitle"]} | Fees: {row["TestTypeFees"]}");
                }
            }
            else
            {
                Console.WriteLine("Warning: No test types found in database");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("FAILED");
        }
    }

    public static void TestFindTestType()
    {
        Console.WriteLine("\n[Test] Find(int TestTypeID)");

        try
        {
            int testID = 1; // Make sure this ID exists in your DB
            clsTestType testType = clsTestType.Find(testID);

            if (testType != null)
            {
                Console.WriteLine("Result: Found");
                Console.WriteLine($"ID: {testType.TestTypeID} | Title: {testType.TestTypeTitle} | Fees: {testType.TestTypeFees}");
            }
            else
            {
                Console.WriteLine($"Result: Not Found (No record with ID = {testID})");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("FAILED");
        }
    }

    public static void TestSaveTestType()
    {
        Console.WriteLine("\n[Test] Save() — Update TestType");

        try
        {
            clsTestType testTestType = clsTestType.Find(1);
            testTestType.TestTypeTitle = "Vision Test";
            testTestType.TestTypeFees = 10;



            bool result = testTestType.Save();

            if (result)
            {
                Console.WriteLine("Result: Success (Test type updated)");
            }
            else
            {
                Console.WriteLine("Result: FAILED to update test type.");
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
        Console.WriteLine(DateTime.UtcNow.ToString());
        }



    }
