class Program
{
    /* 2. Create a DAO class with static methods which provide functionality for inserting, 
     * modifying and deleting customers. Write a testing class.*/

    static void Main(string[] args)
    {
        DBFunction.Add("uque2", "Some Company", "Some name");
        DBFunction.Update("uque2", "New Company");
        DBFunction.Delete("uque2");
        DBFunction.ListAll();
    }
}

