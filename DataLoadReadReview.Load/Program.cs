using System;
using System.IO;
using Newtonsoft.Json;
using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;
using Dapper;
using Npgsql;
using System.Linq;


namespace DataLoadReadReview.Load
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var connection = new NpgsqlConnection("Host=127.0.0.1;port=5701;Username=arun;Password=V0zxKQd6M0Qp;Database=hiring"))

            {
                connection.Open();

                Console.WriteLine("\nEnter Table name ? ");
                var name = Console.ReadLine();

                NpgsqlCommand command = new NpgsqlCommand("Select * from " + name + " ", connection);

                var value = connection.Query<string>("Select * from " + name + " ;");
                NpgsqlDataReader dr = command.ExecuteReader();         

                FileStream ostrm;
                StreamWriter writer;
                try
                {
                    ostrm = new FileStream("C:/" + name + ".tsv", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    writer = new StreamWriter(ostrm);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot open " + name + ".tsv for writing");
                    Console.WriteLine(e.Message);
                    return;
                }

                Console.SetOut(writer);
                while (dr.Read())
                    Console.WriteLine("{0}\t{1}\t{2} \n", dr[0], dr[1], dr[2]);

                writer.Close();
                ostrm.Close();

                Console.Read();


            }

            Console.Read();


            var credentialsPath = "auth\\GCP.Client.Secret.Candidate.Task.json";
            var credentialsJson = File.ReadAllText(credentialsPath);
            var googleCredential = GoogleCredential.FromJson(credentialsJson);
            var storageClient = StorageClient.Create(googleCredential);
            storageClient.Service.HttpClient.Timeout = new TimeSpan(1, 0, 0);

            var fileInfo = new FileInfo(credentialsPath);
            var fileStream = fileInfo.OpenRead();

            var bucketName = "gd-hiring-tri";
            storageClient.UploadObject(
               bucketName,
               "C:/film.tsv",
                "text/html",
                fileStream
                );

            Console.ReadLine();


        }
    }
}