using System;
using System.Data.SQLite;

class Program{
    static void Main(){
        var dbHelper = new DataBaseHelper();
        dbHelper.InitializeDatabase();
        Console.WriteLine("DataBase initialized!!");
    }
}