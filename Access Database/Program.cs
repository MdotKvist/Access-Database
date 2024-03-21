using System.Data.Common;
using Npgsql;

// Remember to insert your database credentials in this string
var connectionString = "INSERT YOUR DATABASE CREDENTIALS HERE";
await using var dataSource = NpgsqlDataSource.Create(connectionString);




//Reading
await using (var cmd = dataSource.CreateCommand("SELECT * FROM test"))
await using (var reader = await cmd.ExecuteReaderAsync())
{
    while (reader.Read())
    {
        Console.WriteLine(reader.GetValue(0));
    }
}


//Writing
await using (var cmd = dataSource.CreateCommand("INSERT INTO test (text) VALUES ($1)"))
{
    cmd.Parameters.AddWithValue(Console.ReadLine());
    await cmd.ExecuteNonQueryAsync();
}