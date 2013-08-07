using System;
using Users.Data;

class Program
{
    /* 11. Create a database holding users and groups. Create a transactional EF 
     * based method that creates an user and puts it in a group "Admins". In case the group 
     * "Admins" do not exist, create the group in the same transaction.
     * If some of the operations fail (e.g. the username already exist), cancel the entire transaction.
     */

    static void Main(string[] args)
    {
        var userName = "Pesho Admina";

        InserAdminUser(userName);
    }

    static void InserAdminUser(string userName)
    {
        using (var dbCon = new UsersAndGroupsEntities())
        {
            dbCon.usp_InsertUserIntoAdmins(userName);

            Console.WriteLine("User {0} was added to Admin Group", userName);
        }
    }
}

