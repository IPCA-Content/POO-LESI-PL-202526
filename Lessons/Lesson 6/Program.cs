//-----------------------------------------------------------------
//    <copyright file="Lesson.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>15-10-2025</date>
//    <time>21:00</time>
//    <version>0.1</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using DatesUtilities.Providers;
using Lesson_6.Enums;
using Lesson_6.Models;
using DateUtilities;

namespace Lesson_6
{
    /// <summary>
    /// Main console application for VetCare system demonstration.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // -----------------------------
            // Initialize repositories (withou any class defined)
            // -----------------------------
            Repository<Client> clientRepo = new Repository<Client>();
            Repository<Animal> animalRepo = new Repository<Animal>();
            Repository<Veterinarian> vetRepo = new Repository<Veterinarian>();
            Repository<Appointment> appointmentRepo = new Repository<Appointment>();

            // -----------------------------
            // Create a client and an animal
            // -----------------------------
            Client client1 = new Client("Anna Smith", "+351912345678", "anna@vetcare.com");
            clientRepo.Add(client1);

            // Create an animal for the client
            // Note: Name cannot be null; make sure to provide a valid name
            Animal animal1 = new Animal("Buddy", "Dog", "Labrador", 4, client1);
            client1.AddAnimal(animal1);
            animalRepo.Add(animal1);

            // -----------------------------
            // Create a veterinarian and an appointment
            // -----------------------------
            Veterinarian vet1 = new Veterinarian("Dr. John Silva", "Orthopedics", "VET1234");
            vetRepo.Add(vet1);

            // Schedule an appointment 2 hours from now with a diagnosis
            Appointment appointment1 = new Appointment(animal1, vet1, DateTime.Now.AddHours(2), "Leg injury");
            appointmentRepo.Add(appointment1);

            // -----------------------------
            // Add treatment and medications to the appointment
            // -----------------------------
            Treatment treatment = new Treatment("Pain management");
            treatment.AddMedication(new Medication("Meloxicam", "0.5 mg/kg", 5));
            appointment1.AddTreatment(treatment);

            // -----------------------------
            // Display information
            // -----------------------------
            Console.WriteLine($"Clients: {clientRepo.Count()}");
            client1.DisplayAnimals(); // Show all animals for the client

            Console.WriteLine($"Appointments: {appointmentRepo.Count()}");
            appointment1.DisplayDetails(); // Show appointment details, including treatments

            // -----------------------------
            // Process payment for the appointment
            // -----------------------------
            Payment payment = new Payment(appointment1, PaymentMethod.Card, 60.00m, DateTime.Now);
            payment.ProcessPayment();

            // -----------------------------
            // Veterinarian lists their appointments
            // -----------------------------
            vet1.ListAppointments();

            // -----------------------------
            // Example usage of Utilities
            // -----------------------------
            SystemDateProvider _dateProvider = new SystemDateProvider();
            DateUtils dates = new DateUtils(_dateProvider);
            
            // Calculate age from year, month, day
            int age = dates.Age(2025, 12, 10);

            // Calculate age from DateOnly struct
            age = dates.Age(new DateOnly(2025, 12, 10));
            
            // -----------------------------
            // End of program
            // -----------------------------
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}